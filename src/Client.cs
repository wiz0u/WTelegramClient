using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TL;
using static WTelegram.Encryption;

namespace WTelegram
{
	public sealed partial class Client : IDisposable
	{
		public Config TLConfig { get; private set; }
		private readonly Func<string, string> _config;
		private readonly Func<ITLObject, Task> _updateHandler;
		private readonly int _apiId;
		private readonly string _apiHash;
		private readonly Session _session;
		private TcpClient _tcpClient;
		private NetworkStream _networkStream;
		private int _frame_seqTx = 0, _frame_seqRx = 0;
		private ITLFunction<object> _lastSentMsg;
		private Type _lastRpcResultType = typeof(object);
		private readonly List<long> _msgsToAck = new();
		private int _unexpectedSaltChange;
		private readonly Random _random = new();
		private readonly SHA256 _sha256 = SHA256.Create();
				
		public Client(Func<string,string> configProvider = null, Func<ITLObject, Task> updateHandler = null)
		{
			_config = configProvider ?? DefaultConfigOrAsk;
			_updateHandler = updateHandler;
			_apiId = int.Parse(Config("api_id"));
			_apiHash = Config("api_hash");
			_session = Session.LoadOrCreate(Config("session_pathname"), Convert.FromHexString(_apiHash));
		}

		public string Config(string config)
			=> _config(config) ?? DefaultConfig(config) ?? throw new ApplicationException("You must provide a config value for " + config);

		public static string DefaultConfig(string config) => config switch
		{
			"session_pathname" => Path.Combine(
				Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory.TrimEnd(Path.DirectorySeparatorChar))),
				"WTelegram.session"),
#if DEBUG
			"server_address" => "149.154.167.40:443",
#else
			"server_address" => "149.154.167.50:443",
#endif
			"device_model" => Environment.Is64BitOperatingSystem ? "PC 64bit" : "PC 32bit",
			"system_version" => System.Runtime.InteropServices.RuntimeInformation.OSDescription,
			"app_version" => Assembly.GetEntryAssembly().GetName().Version.ToString(),
			"system_lang_code" => CultureInfo.InstalledUICulture.TwoLetterISOLanguageName,
			"lang_pack" => "",
			"lang_code" => CultureInfo.CurrentUICulture.TwoLetterISOLanguageName,
			_ => null // api_id api_hash phone_number verification_code... it's up to you to reply to these correctly
		};

		public static string DefaultConfigOrAsk(string config)
		{
			var value = DefaultConfig(config);
			if (value != null) return value;
			Console.Write($"Enter {config.Replace('_', ' ')}: ");
			return Console.ReadLine();
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822")]
		public void LoadPublicKey(string pem) => Encryption.LoadPublicKey(pem);

		public void Reset() // disconnect and reset session (forget server address, current user and authkey)
		{
			_tcpClient.Close();
			_session.Reset();
		}

		public async Task ConnectAsync()
		{
			var endpoint = _session.DataCenter == null ? IPEndPoint.Parse(Config("server_address"))
				: new IPEndPoint(IPAddress.Parse(_session.DataCenter.ip_address), _session.DataCenter.port);
			Helpers.Log(2, $"Connecting to {endpoint}...");
			//TODO: maintain different connections/sessions to different DCs for main API/file download/file upload?
			_tcpClient = new TcpClient(endpoint.AddressFamily);
			await _tcpClient.ConnectAsync(endpoint.Address, endpoint.Port);
			_networkStream = _tcpClient.GetStream();
			_frame_seqTx = _frame_seqRx = 0;

			if (_session.AuthKey == null)
				await CreateAuthorizationKey(this, _session);

			TLConfig = await InvokeWithLayer(Schema.Layer,
				InitConnection<Config>(_apiId,
					Config("device_model"),
					Config("system_version"),
					Config("app_version"),
					Config("system_lang_code"),
					Config("lang_pack"),
					Config("lang_code"),
					Help_GetConfig));
		}

		private async Task MigrateDCAsync(int dcId)
		{
			Helpers.Log(2, $"Migrate to DC {dcId}...");
			Auth_ExportedAuthorization exported = null;
			if (_session.User != null)
				exported = await Auth_ExportAuthorization(dcId);
			var prevFamily = _tcpClient.Client.RemoteEndPoint.AddressFamily;
			_tcpClient.Close();
			var dcOptions = TLConfig.dc_options.Where(dc => dc.id == dcId && (dc.flags & (DcOption.Flags.media_only | DcOption.Flags.cdn)) == 0);
			if (prevFamily == AddressFamily.InterNetworkV6) // try to stay in the same connectivity
				dcOptions = dcOptions.OrderByDescending(dc => dc.flags & DcOption.Flags.ipv6);  // list ipv6 first
			else
				dcOptions = dcOptions.OrderBy(dc => dc.flags & DcOption.Flags.ipv6);                // list ipv4 first
			var dcOption = dcOptions.FirstOrDefault();
			_session.Reset(dcOption ?? throw new ApplicationException($"Could not find adequate dcOption for DC {dcId}"));
			await ConnectAsync();
			if (exported != null)
			{
				var authorization = await Auth_ImportAuthorization(exported.id, exported.bytes);
				if (authorization is not Auth_Authorization { user: User user })
					throw new ApplicationException("Failed to get Authorization: " + authorization.GetType().Name);
				_session.User = user.Serialize();
			}
		}

		public void Dispose()
		{
			CheckMsgsToAck().Wait(1000);
			_networkStream?.Dispose();
			_tcpClient?.Dispose();
		}

		public Task SendAsync(ITLObject msg, bool isContent = true)
			=> SendAsync<object>(writer =>
			{
				writer.WriteTLObject(msg);
				return msg.GetType().Name;
			}, isContent);

		public async Task SendAsync<X>(ITLFunction<X> msgSerializer, bool isContent = true)
		{
			if (_session.AuthKeyID != 0) await CheckMsgsToAck();
			using var memStream = new MemoryStream(1024);
			using var writer = new BinaryWriter(memStream, Encoding.UTF8);
			writer.Write(0);                // int32 frame_len (to be patched with full frame length)
			writer.Write(_frame_seqTx++);   // int32 frame_seq

			(long msgId, int seqno) = _session.NewMsg(isContent && _session.AuthKeyID != 0);

			if (_session.AuthKeyID == 0) // send unencrypted message
			{
				writer.Write(0L);						// int64 auth_key_id = 0 (Unencrypted)
				writer.Write(msgId);					// int64 message_id
				writer.Write(0);						// int32 message_data_length (to be patched)
				var typeName = msgSerializer(writer);	// bytes message_data
				Helpers.Log(1, $"Sending   {typeName}...");
				BinaryPrimitives.WriteInt32LittleEndian(memStream.GetBuffer().AsSpan(24), (int)memStream.Length - 28);    // patch message_data_length
			}
			else
			{
				using var clearStream = new MemoryStream(1024);
				using var clearWriter = new BinaryWriter(clearStream, Encoding.UTF8);
#if MTPROTO1
				const int prepend = 0;
#else
				const int prepend = 32;
				clearWriter.Write(_session.AuthKey, 88, prepend);
#endif
				clearWriter.Write(_session.Salt);			// int64 salt
				clearWriter.Write(_session.Id);				// int64 session_id
				clearWriter.Write(msgId);					// int64 message_id
				clearWriter.Write(seqno);					// int32 msg_seqno
				clearWriter.Write(0);						// int32 message_data_length (to be patched)
				var typeName = msgSerializer(clearWriter);	// bytes message_data
				Helpers.Log(1, $"Sending   {typeName,-50} #{(short)msgId.GetHashCode():X4}");
				int clearLength = (int)clearStream.Length - prepend;  // length before padding (= 32 + message_data_length)
				int padding = (0x7FFFFFF0 - clearLength) % 16;
#if !MTPROTO1
				padding += _random.Next(1, 64) * 16;		// MTProto 2.0 padding must be between 12..1024 with total length divisible by 16
#endif
				clearStream.SetLength(prepend + clearLength + padding);
				byte[] clearBuffer = clearStream.GetBuffer();
				BinaryPrimitives.WriteInt32LittleEndian(clearBuffer.AsSpan(prepend + 28), clearLength - 32);    // patch message_data_length
				RNG.GetBytes(clearBuffer, prepend + clearLength, padding);
#if MTPROTO1
				var msgKeyLarge = SHA1.HashData(clearBuffer.AsSpan(0, clearLength)); // padding excluded from computation!
				const int msgKeyOffset = 4;	// msg_key = low 128-bits of SHA1(plaintext)
#else
				var msgKeyLarge = SHA256.HashData(clearBuffer.AsSpan(0, prepend + clearLength + padding));
				const int msgKeyOffset = 8; // msg_key = middle 128-bits of SHA256(authkey_part+plaintext+padding)
#endif
				byte[] encrypted_data = EncryptDecryptMessage(clearBuffer.AsSpan(prepend, clearLength + padding), true, _session.AuthKey, msgKeyLarge);

				writer.Write(_session.AuthKeyID);				// int64 auth_key_id
				writer.Write(msgKeyLarge, msgKeyOffset, 16);	// int128 msg_key
				writer.Write(encrypted_data);					// bytes encrypted_data
			}

			var buffer = memStream.GetBuffer();
			int frameLength = (int)memStream.Length;
			//TODO: support Quick Ack?
			BinaryPrimitives.WriteInt32LittleEndian(buffer, frameLength + 4); // patch frame_len with correct value
			uint crc = Force.Crc32.Crc32Algorithm.Compute(buffer, 0, frameLength);
			writer.Write(crc);              // int32 frame_crc
			var frame = memStream.GetBuffer().AsMemory(0, frameLength + 4);
			//TODO: support Transport obfuscation?

			await _networkStream.WriteAsync(frame);
			_lastSentMsg = writer => msgSerializer(writer);
		}

		internal async Task<ITLObject> RecvInternalAsync()
		{
			var data = await RecvFrameAsync();
			if (data.Length == 4 && data[3] == 0xFF)
			{
				int error_code = -BinaryPrimitives.ReadInt32LittleEndian(data);
				throw new RpcException(error_code, TransportError(error_code));
			}
			if (data.Length < 24) // authKeyId+msgId+length+ctorNb | authKeyId+msgKey
				throw new ApplicationException($"Packet payload too small: {data.Length}");

			//TODO: ignore msgId <= lastRecvMsgId, ignore MsgId >= 30 sec in the future or < 300 sec in the past
			long authKeyId = BinaryPrimitives.ReadInt64LittleEndian(data);
			if (authKeyId == 0) // Unencrypted message
			{
				using var reader = new BinaryReader(new MemoryStream(data, 8, data.Length - 8));
				long msgId = reader.ReadInt64();
				if ((msgId & 1) == 0) throw new ApplicationException($"Invalid server msgId {msgId}");
				int length = reader.ReadInt32();
				if (length != data.Length - 20) throw new ApplicationException($"Unexpected unencrypted length {length} != {data.Length - 20}");

				return reader.ReadTLObject((type, _) =>
					Helpers.Log(1, $"Receiving {type.Name,-50} timestamp={_session.MsgIdToStamp(msgId)} isResponse={(msgId & 2) != 0} unencrypted"));
			}
			else if (authKeyId != _session.AuthKeyID)
				throw new ApplicationException($"Received a packet encrypted with unexpected key {authKeyId:X}");
			else
			{
#if MTPROTO1
				byte[] msgKeyLarge = data[4..24];
#else
				byte[] msgKeyLarge = data[0..24];
#endif
				byte[] decrypted_data = EncryptDecryptMessage(data.AsSpan(24), false, _session.AuthKey, msgKeyLarge);
				if (decrypted_data.Length < 36) // header below+ctorNb
					throw new ApplicationException($"Decrypted packet too small: {decrypted_data.Length}");
				using var reader = new BinaryReader(new MemoryStream(decrypted_data));
				var serverSalt = reader.ReadInt64();	// int64 salt
				var sessionId = reader.ReadInt64();		// int64 session_id
				var msgId = reader.ReadInt64();			// int64 message_id
				var seqno = reader.ReadInt32();			// int32 msg_seqno
				var length = reader.ReadInt32();		// int32 message_data_length

				if (serverSalt != _session.Salt)
				{
					Helpers.Log(3, $"Server salt has changed: {_session.Salt:X8} -> {serverSalt:X8}");
					_session.Salt = serverSalt;
					if (++_unexpectedSaltChange >= 10)
						throw new ApplicationException($"Server salt changed unexpectedly more than 10 times during this run");
				}
				if (sessionId != _session.Id) throw new ApplicationException($"Unexpected session ID {_session.Id} != {_session.Id}");
				if ((msgId & 1) == 0) throw new ApplicationException($"Invalid server msgId {msgId}");
				if ((seqno & 1) != 0) lock(_msgsToAck) _msgsToAck.Add(msgId);
#if MTPROTO1
				if (decrypted_data.Length - 32 - length is < 0 or > 15) throw new ApplicationException($"Unexpected decrypted message_data_length {length} / {decrypted_data.Length - 32}");
				if (!data.AsSpan(8, 16).SequenceEqual(SHA1.HashData(decrypted_data.AsSpan(0, 32 + length)).AsSpan(4)))
					throw new ApplicationException($"Mismatch between MsgKey & decrypted SHA1");
#else
				if (decrypted_data.Length - 32 - length is < 12 or > 1024) throw new ApplicationException($"Unexpected decrypted message_data_length {length} / {decrypted_data.Length - 32}");
				_sha256.TransformBlock(_session.AuthKey, 96, 32, null, 0);
				_sha256.TransformFinalBlock(decrypted_data, 0, decrypted_data.Length);
				if (!data.AsSpan(8, 16).SequenceEqual(_sha256.Hash.AsSpan(8, 16)))
					throw new ApplicationException($"Mismatch between MsgKey & decrypted SHA1");
#endif
				return reader.ReadTLObject((type, obj) =>
				{
					Helpers.Log(1, $"Receiving {type.Name,-50} timestamp={_session.MsgIdToStamp(msgId)} isResponse={(msgId & 2) != 0} {(seqno == -1 ? "clearText" : "isContent")}={(seqno & 1) != 0}");
					if (type == typeof(RpcResult))
						DeserializeRpcResult(reader, (RpcResult)obj); // necessary hack because some RPC return bare types like bool or int[]
				});
		}

			static string TransportError(int error_code) => error_code switch
			{
				404 => "Auth key not found",
				429 => "Transport flood",
				_ => ((HttpStatusCode)error_code).ToString(),
			};
		}

		private async Task<byte[]> RecvFrameAsync()
		{
			byte[] frame = new byte[8];
			if (await FullReadAsync(_networkStream, frame, 8) != 8)
				throw new ApplicationException("Could not read frame prefix : Connection shut down");
			int length = BinaryPrimitives.ReadInt32LittleEndian(frame) - 12;
			if (length <= 0 || length >= 0x10000)
				throw new ApplicationException("Invalid frame_len");
			int seqno = BinaryPrimitives.ReadInt32LittleEndian(frame.AsSpan(4));
			if (seqno != _frame_seqRx++)
			{
				Trace.TraceWarning($"Unexpected frame_seq received: {seqno} instead of {_frame_seqRx}");
				_frame_seqRx = seqno + 1;
			}
			var payload = new byte[length];
			if (await FullReadAsync(_networkStream, payload, length) != length)
				throw new ApplicationException("Could not read frame data : Connection shut down");
			uint crc32 = Force.Crc32.Crc32Algorithm.Compute(frame, 0, 8);
			crc32 = Force.Crc32.Crc32Algorithm.Append(crc32, payload);
			if (await FullReadAsync(_networkStream, frame, 4) != 4)
				throw new ApplicationException("Could not read frame CRC : Connection shut down");
			if (crc32 != BinaryPrimitives.ReadUInt32LittleEndian(frame))
				throw new ApplicationException("Invalid envelope CRC32");
			return payload;
		}

		private static async Task<int> FullReadAsync(Stream stream, byte[] buffer, int length)
		{
			for (int offset = 0; offset != length;)
			{
				var read = await stream.ReadAsync(buffer.AsMemory(offset, length - offset));
				if (read == 0) return offset;
				offset += read;
			}
			return length;
		}

		private void DeserializeRpcResult(BinaryReader reader, RpcResult rpcResult)
		{
			if ((rpcResult.req_msg_id = reader.ReadInt64()) == _session.LastSentMsgId)
				rpcResult.result = reader.ReadTLValue(_lastRpcResultType);
			else
				rpcResult.result = reader.ReadTLObject();
			Helpers.Log(1, $"        → {rpcResult.result.GetType().Name,-50} #{(short)rpcResult.req_msg_id.GetHashCode():X4}");
		}

		public class RpcException : Exception
		{
			public readonly int Code;
			public RpcException(int code, string message) : base(message) => Code = code;
		}

		public async Task<X> CallAsync<X>(ITLFunction<X> request)
		{
			await SendAsync(request);
			// TODO: create a background reactor system that handles incoming packets and wake up awaiting tasks when their result has arrived
			// This would allow parallelization of Send task and avoid the risk of calling RecvInternal concurrently
			_lastRpcResultType = typeof(X);
			for (; ;)	//TODO: implement a timeout
			{
				var reply = await RecvInternalAsync();
				if (reply is X plainResult) return plainResult;
				else if (reply is RpcResult rpcResult && rpcResult.req_msg_id == _session.LastSentMsgId)
				{
					if (rpcResult.result is RpcError rpcError)
					{
						int migrateDC;
						if (rpcError.error_code == 303 && ((migrateDC = rpcError.error_message.IndexOf("_MIGRATE_")) > 0))
						{
							migrateDC = int.Parse(rpcError.error_message[(migrateDC + 9)..]);
							await MigrateDCAsync(migrateDC);
							await SendAsync(request);
						}
						else
							throw new RpcException(rpcError.error_code, rpcError.error_message);
					}
					else if (rpcResult.result is X result)
						return result;
					else
						throw new ApplicationException($"{request.GetType().Name} call got a result of type {rpcResult.result.GetType().Name} instead of {typeof(X).Name}");
				}
				else
					await HandleMessageAsync(reply);
			}
		}

		private async Task CheckMsgsToAck()
		{
			MsgsAck msgsAck = null;
			lock (_msgsToAck)
				if (_msgsToAck.Count != 0)
				{
					msgsAck = new MsgsAck { msg_ids = _msgsToAck.ToArray() };
					_msgsToAck.Clear();
				}
			if (msgsAck != null)
				await SendAsync(msgsAck, false);
		}

		private async Task HandleMessageAsync(ITLObject obj)
		{
			switch (obj)
			{
				case MsgContainer container:
					foreach (var msg in container.messages)
					{
						Helpers.Log(1, $"          → {msg.body?.GetType().Name,-48} timestamp={_session.MsgIdToStamp(msg.msg_id)} isResponse={(msg.msg_id & 2) != 0} {(msg.seqno == -1 ? "clearText" : "isContent")}={(msg.seqno & 1) != 0}");
						if ((msg.seqno & 1) != 0) lock (_msgsToAck) _msgsToAck.Add(msg.msg_id);
						if (msg.body != null) await HandleMessageAsync(msg.body);
					}
					break;
				case BadServerSalt badServerSalt:
					_session.Salt = badServerSalt.new_server_salt;
					if (badServerSalt.bad_msg_id == _session.LastSentMsgId)
						await SendAsync(_lastSentMsg);
					break;
				case BadMsgNotification badMsgNotification:
					Helpers.Log(3, $"BadMsgNotification {badMsgNotification.error_code} for msg {badMsgNotification.bad_msg_seqno}");
					break;
				case RpcResult rpcResult:
					if (_session.MsgIdToStamp(rpcResult.req_msg_id) >= _session.SessionStart)
						throw new ApplicationException($"Got RpcResult({rpcResult.result.GetType().Name}) for unknown msgId {rpcResult.req_msg_id}");
					break; // silently ignore results for msg_id from previous sessions
				default:
					if (_updateHandler != null) await _updateHandler?.Invoke(obj);
					break;
			}
		}

		public async Task<User> UserAuthIfNeeded(CodeSettings settings = null)
		{
			if (_session.User != null)
				return Schema.Deserialize<User>(_session.User);
			string phone_number = Config("phone_number");
			var sentCode = await Auth_SendCode(phone_number, _apiId, _apiHash, settings ?? new());
			Helpers.Log(3, $"A verification code has been sent via {sentCode.type.GetType().Name[17..]}");
			var verification_code = Config("verification_code");
			Auth_AuthorizationBase authorization;
			try
			{
				authorization = await Auth_SignIn(phone_number, sentCode.phone_code_hash, verification_code);
			}
			catch (RpcException e) when (e.Code == 401 && e.Message == "SESSION_PASSWORD_NEEDED")
			{
				var accountPassword = await Account_GetPassword();
				Helpers.Log(3, $"This account has enabled 2FA. A password is needed. {accountPassword.hint}");
				var checkPasswordSRP = Check2FA(accountPassword, Config("password"));
				authorization = await Auth_CheckPassword(checkPasswordSRP);
			}
			if (authorization is Auth_AuthorizationSignUpRequired signUpRequired)
			{
				var waitUntil = DateTime.UtcNow.AddSeconds(3);
				if (signUpRequired.terms_of_service != null && _updateHandler != null)
					await _updateHandler?.Invoke(signUpRequired.terms_of_service); // give caller the possibility to read and accept TOS
				var first_name = Config("first_name");
				var last_name = Config("last_name");
				var wait = waitUntil - DateTime.UtcNow;
				if (wait > TimeSpan.Zero) await Task.Delay(wait); // we get a FLOOD_WAIT_3 if we SignUp too fast
				authorization = await Auth_SignUp(phone_number, sentCode.phone_code_hash, first_name, last_name);
			}
			if (authorization is not Auth_Authorization { user: User user })
				throw new ApplicationException("Failed to get Authorization: " + authorization.GetType().Name);
			_session.User = user.Serialize();
			_session.Save();
			return user;
		}

		#region TL-Helpers
		/// <summary>Helper function to upload a file to Telegram</summary>
		/// <returns>an <see cref="InputFile"/> or <see cref="InputFileBig"/> than can be used in various requests</returns>
		public Task<InputFileBase> UploadFileAsync(string pathname)
			=> UploadFileAsync(File.OpenRead(pathname), Path.GetFileName(pathname));

		public async Task<InputFileBase> UploadFileAsync(Stream stream, string filename)
		{
			using var md5 = MD5.Create();
			using (stream)
			{
				long length = stream.Length;
				var isBig = length >= 10 * 1024 * 1024;
				const int partSize = 512 * 1024;
				int file_total_parts = (int)((length - 1) / partSize) + 1;
				long file_id = Helpers.RandomLong();
				var bytes = new byte[Math.Min(partSize, length)];
				int file_part = 0, read;
				for (long bytesLeft = length; bytesLeft != 0; file_part++)
				{
					//TODO: parallelize several parts sending through a N-semaphore? (needs a reactor first)
					read = await FullReadAsync(stream, bytes, (int)Math.Min(partSize, bytesLeft));
					if (isBig)
						await Upload_SaveBigFilePart(file_id, file_part, file_total_parts, bytes);
					else
					{
						await Upload_SaveFilePart(file_id, file_part, bytes);
						md5.TransformBlock(bytes, 0, read, null, 0);
					}
					bytesLeft -= read;
					if (read < partSize && bytesLeft != 0) throw new ApplicationException($"Failed to fully read stream ({read},{bytesLeft})");
				}
				if (!isBig) md5.TransformFinalBlock(bytes, 0, 0);
				return isBig ? new InputFileBig { id = file_id, parts = file_total_parts, name = filename }
					: new InputFile { id = file_id, parts = file_total_parts, name = filename, md5_checksum = md5.Hash };
			}
		}

		/// <summary>Helper function to send a text or media message more easily</summary>
		/// <param name="peer">destination of message</param>
		/// <param name="caption">media caption</param>
		/// <param name="mediaFile">media file already uploaded to TG <i>(see <see cref="UploadFileAsync"/>)</i></param>
		/// <param name="mimeType"><see langword="null"/> for automatic detection, <c>"photo"</c> for an inline photo, or a MIME type to send as a document</param>
		public Task<UpdatesBase> SendMediaAsync(InputPeer peer, string caption, InputFileBase mediaFile, string mimeType = null, int reply_to_msg_id = 0, MessageEntity[] entities = null, DateTime schedule_date = default, bool disable_preview = false)
		{
			var filename = mediaFile is InputFile iFile ? iFile.name : (mediaFile as InputFileBig)?.name;
			mimeType ??= Path.GetExtension(filename).ToLowerInvariant() switch
			{
				".jpg" or ".jpeg" or ".png" or ".bmp" => "photo",
				".gif" => "image/gif",
				".webp" => "image/webp",
				".mp4" => "video/mp4",
				".mp3" => "audio/mpeg",
				".wav" => "audio/x-wav",
				_ => "", // send as generic document with undefined MIME type
			};
			if (mimeType == "photo")
				return SendMessageAsync(peer, caption, new InputMediaUploadedPhoto { file = mediaFile },
					reply_to_msg_id, entities, schedule_date, disable_preview);
			var attributes = filename == null ? Array.Empty<DocumentAttribute>() : new[] { new DocumentAttributeFilename { file_name = filename } };
			return SendMessageAsync(peer, caption, new InputMediaUploadedDocument
			{
				file = mediaFile, mime_type = mimeType, attributes = attributes
			}, reply_to_msg_id, entities, schedule_date, disable_preview);
		}

		/// <summary>Helper function to send a text or media message</summary>
		/// <param name="peer">destination of message</param>
		/// <param name="text">text, or media caption</param>
		/// <param name="media">media specification or <see langword="null"/></param>
		public Task<UpdatesBase> SendMessageAsync(InputPeer peer, string text, InputMedia media = null, int reply_to_msg_id = 0, MessageEntity[] entities = null, DateTime schedule_date = default, bool disable_preview = false)
		{
			if (media == null)
				return Messages_SendMessage(peer, text, Helpers.RandomLong(),
					no_webpage: disable_preview, reply_to_msg_id: reply_to_msg_id, entities: entities, schedule_date: schedule_date);
			else
				return Messages_SendMedia(peer, media, text, Helpers.RandomLong(),
					reply_to_msg_id: reply_to_msg_id, entities: entities, schedule_date: schedule_date);
		}
		#endregion
	}
}
