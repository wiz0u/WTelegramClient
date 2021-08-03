using System;
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
	public sealed class Client : IDisposable
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
		private ITLObject _lastSentMsg;
		private Type _lastRpcResultType = typeof(object);
		private readonly List<long> _msgsToAck = new();
		private int _unexpectedSaltChange;

		public Client(Func<string,string> configProvider = null, Func<ITLObject, Task> updateHandler = null)
		{
			_config = configProvider ?? DefaultConfigOrAsk;
			_updateHandler = updateHandler;
			_apiId = int.Parse(_config("api_id"));
			_apiHash = _config("api_hash");
			_session = Session.LoadOrCreate(_config("session_pathname"));
		}

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
			_ => null // api_id api_hash phone_number... it's up to you to reply to these correctly
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

		public async Task ConnectAsync()
		{
			var endpoint = _session.DataCenter == null ? IPEndPoint.Parse(_config("server_address"))
				: new IPEndPoint(IPAddress.Parse(_session.DataCenter.ip_address), _session.DataCenter.port);
			Console.WriteLine($"Connecting to {endpoint}...");
			_tcpClient = new TcpClient(endpoint.AddressFamily);
			await _tcpClient.ConnectAsync(endpoint.Address, endpoint.Port);
			_networkStream = _tcpClient.GetStream();
			_frame_seqTx = _frame_seqRx = 0;

			if (_session.AuthKey == null)
				await CreateAuthorizationKey(this, _session);

			TLConfig = await CallAsync(new InvokeWithLayer<Config>
			{
				layer = Schema.Layer,
				query = new InitConnection<Config>
				{
					api_id = _apiId,
					device_model = _config("device_model"),
					system_version = _config("system_version"),
					app_version = _config("app_version"),
					system_lang_code = _config("system_lang_code"),
					lang_pack = _config("lang_pack"),
					lang_code = _config("lang_code"),
					query = new Help_GetConfig()
				}
			});
		}

		private async Task MigrateDCAsync(int dcId)
		{
			Console.WriteLine($"Migrate to DC {dcId}...");
			//TODO: Export/Import client authorization?
			var prevFamily = _tcpClient.Client.RemoteEndPoint.AddressFamily;
			_tcpClient.Close();
			var dcOptions = TLConfig.dc_options.Where(dc => dc.id == dcId && (dc.flags & (DcOption.Flags.media_only | DcOption.Flags.cdn)) == 0);
			if (prevFamily == AddressFamily.InterNetworkV6) // try to stay in the same connectivity
				dcOptions = dcOptions.OrderByDescending(dc => dc.flags & DcOption.Flags.ipv6);  // list ipv6 first
			else
				dcOptions = dcOptions.OrderBy(dc => dc.flags & DcOption.Flags.ipv6);                // list ipv4 first
			var dcOption = dcOptions.FirstOrDefault();
			_session.DataCenter = dcOption ?? throw new ApplicationException($"Could not find adequate dcOption for DC {dcId}");
			_session.AuthKeyID = _session.Salt = _session.Seqno = 0;
			_session.AuthKey = null;
			await ConnectAsync();
		}

		public void Dispose()
		{
			CheckMsgsToAck().Wait(1000);
			_networkStream?.Dispose();
			_tcpClient?.Dispose();
		}

		public async Task SendAsync(ITLObject msg, bool isContent = true)
		{
			if (_session.AuthKeyID != 0) await CheckMsgsToAck();
			using var memStream = new MemoryStream(1024);   //TODO: choose a useful capacity
			using var writer = new BinaryWriter(memStream, Encoding.UTF8);
			writer.Write(0);                // int32 frame_len (to be patched with full frame length)
			writer.Write(_frame_seqTx++);   // int32 frame_seq

			(long msgId, int seqno) = _session.NewMsg(isContent);

			if (_session.AuthKeyID == 0) // send unencrypted message
			{
				Console.WriteLine($"Sending   {msg.GetType().Name}...");
				writer.Write(0L);					// int64 auth_key_id = 0 (Unencrypted)
				writer.Write(msgId);				// int64 message_id
				writer.Write(0);					// int32 message_data_length (to be patched)
				Schema.Serialize(writer, msg);		// bytes message_data
				Helpers.LittleEndian(memStream.GetBuffer(), 24, (int)memStream.Length - 28);    // patch message_data_length
			}
			else
			{
				Console.WriteLine($"Sending   {msg.GetType().Name}... (seqno {seqno})");
				//TODO: Implement MTProto 2.0
				using var clearStream = new MemoryStream(1024);   //TODO: choose a useful capacity
				using var clearWriter = new BinaryWriter(clearStream, Encoding.UTF8);
				clearWriter.Write(_session.Salt);		// int64 salt
				clearWriter.Write(_session.Id);			// int64 session_id
				clearWriter.Write(msgId);				// int64 message_id
				clearWriter.Write(seqno);				// int32 msg_seqno
				clearWriter.Write(0);					// int32 message_data_length (to be patched)
				Schema.Serialize(clearWriter, msg);		// bytes message_data
				int clearLength = (int)clearStream.Length;  // length before padding (= 32 + message_data_length)
				int padding = (0x7FFFFFF0 - clearLength) % 16;
				clearStream.SetLength(clearLength + padding);
				byte[] clearBuffer = clearStream.GetBuffer();
				Helpers.LittleEndian(clearBuffer, 28, clearLength - 32);    // patch message_data_length
				RNG.GetBytes(clearBuffer, clearLength, padding);
				var clearSha1 = SHA1.HashData(clearBuffer.AsSpan(0, clearLength)); // padding excluded from computation!
				byte[] encrypted_data = EncryptDecryptMessage(clearBuffer.AsSpan(0, clearLength + padding), true, _session.AuthKey, clearSha1);

				writer.Write(_session.AuthKeyID);	// int64 auth_key_id
				writer.Write(clearSha1, 4, 16);		// int128 msg_key = low 128-bits of SHA1(clear message body)
				writer.Write(encrypted_data);		// bytes encrypted_data
			}

			var buffer = memStream.GetBuffer();
			int frameLength = (int)memStream.Length;
			//TODO: support Quick Ack?
			Helpers.LittleEndian(buffer, 0, frameLength + 4); // patch frame_len with correct value
			uint crc = Force.Crc32.Crc32Algorithm.Compute(buffer, 0, frameLength);
			writer.Write(crc);              // int32 frame_crc
			var frame = memStream.GetBuffer().AsMemory(0, frameLength + 4);
			//TODO: support Transport obfuscation?

			await _networkStream.WriteAsync(frame);
			_lastSentMsg = msg;
		}

		internal async Task<object> RecvInternalAsync()
		{
			var data = await RecvFrameAsync();
			if (data.Length == 4 && data[3] == 0xFF)
				throw new ApplicationException($"Server replied with error code: {TransportError(-BitConverter.ToInt32(data))}");
			if (data.Length < 24) // authKeyId+msgId+length+ctorNb | authKeyId+msgKey
				throw new ApplicationException($"Packet payload too small: {data.Length}");

			//TODO: ignore msgId <= lastRecvMsgId, ignore MsgId >= 30 sec in the future or < 300 sec in the past
			long authKeyId = BitConverter.ToInt64(data);
			if (authKeyId == 0) // Unencrypted message
			{
				using var reader = new BinaryReader(new MemoryStream(data, 8, data.Length - 8));
				long msgId = reader.ReadInt64();
				if ((msgId & 1) == 0) throw new ApplicationException($"Invalid server msgId {msgId}");
				int length = reader.ReadInt32();
				if (length != data.Length - 20) throw new ApplicationException($"Unexpected unencrypted length {length} != {data.Length - 20}");

				var ctorNb = reader.ReadUInt32();
				if (!Schema.Mappings.TryGetValue(ctorNb, out var realType))
					throw new ApplicationException($"Cannot find type for ctor #{ctorNb:x}");
				Console.WriteLine($"Receiving {realType.Name,-50} timestamp={_session.MsgIdToStamp(msgId)} isResponse={(msgId & 2) != 0} unencrypted");
				return Schema.DeserializeObject(reader, realType);
			}
			else if (authKeyId != _session.AuthKeyID)
				throw new ApplicationException($"Received a packet encrypted with unexpected key {authKeyId:X}");
			else
			{
				byte[] decrypted_data = EncryptDecryptMessage(data.AsSpan(24), false, _session.AuthKey, data[4..24]);
				if (decrypted_data.Length < 36) // header below+ctorNb
					throw new ApplicationException($"Decrypted packet too small: {decrypted_data.Length}");
				using var reader = new BinaryReader(new MemoryStream(decrypted_data));
				var serverSalt = reader.ReadInt64();	// int64 salt
				var sessionId = reader.ReadInt64();		// int64 session_id
				var msgId = reader.ReadInt64();			// int64 message_id
				var seqno = reader.ReadInt32();			// int32 msg_seqno
				var length = reader.ReadInt32();		// int32 message_data_length

				if (serverSalt != _session.Salt)
					if (++_unexpectedSaltChange >= 10)
						throw new ApplicationException($"Server salt changed unexpectedly more than 10 times during this run");
				if (sessionId != _session.Id) throw new ApplicationException($"Unexpected session ID {_session.Id} != {_session.Id}");
				if ((msgId & 1) == 0) throw new ApplicationException($"Invalid server msgId {msgId}");
				if ((seqno & 1) != 0) lock(_msgsToAck) _msgsToAck.Add(msgId);
				if (decrypted_data.Length - 32 - length is < 0 or > 15) throw new ApplicationException($"Unexpected decrypted message_data_length {length} / {decrypted_data.Length - 32}");
				if (!data.AsSpan(8, 16).SequenceEqual(SHA1.HashData(decrypted_data.AsSpan(0, 32 + length)).AsSpan(4)))
					throw new ApplicationException($"Mismatch between MsgKey & decrypted SHA1");

				var ctorNb = reader.ReadUInt32();
				if (!Schema.Mappings.TryGetValue(ctorNb, out var realType))
					throw new ApplicationException($"Cannot find type for ctor #{ctorNb:x}");
				Console.WriteLine($"Receiving {realType.Name,-50} timestamp={_session.MsgIdToStamp(msgId)} isResponse={(msgId & 2) != 0} {(seqno == -1 ? "clearText" : "isContent")}={(seqno & 1) != 0}");
				if (realType == typeof(RpcResult))
					return DeserializeRpcResult(reader); // hack necessary because some RPC return bare types like bool or int[]
				else
					return Schema.DeserializeObject(reader, realType);
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
			await FullReadAsync(frame, 8);
			int length = BitConverter.ToInt32(frame) - 12;
			if (length <= 0 || length >= 0x10000)
				throw new ApplicationException("Invalid frame_len");
			int seqno = BitConverter.ToInt32(frame, 4);
			if (seqno != _frame_seqRx++)
			{
				Trace.TraceWarning($"Unexpected frame_seq received: {seqno} instead of {_frame_seqRx}");
				_frame_seqRx = seqno + 1;
			}
			var payload = new byte[length];
			await FullReadAsync(payload, length);
			uint crc32 = Force.Crc32.Crc32Algorithm.Compute(frame, 0, 8);
			crc32 = Force.Crc32.Crc32Algorithm.Append(crc32, payload);
			await FullReadAsync(frame, 4);
			if (crc32 != BitConverter.ToUInt32(frame))
				throw new ApplicationException("Invalid envelope CRC32");
			return payload;
		}

		private async Task FullReadAsync(byte[] buffer, int length)
		{
			for (int offset = 0; offset != length;)
			{
				var read = await _networkStream.ReadAsync(buffer.AsMemory(offset, length - offset));
				if (read == 0) throw new ApplicationException("Connection shut down");
				offset += read;
			} 
		}

		private object DeserializeRpcResult(BinaryReader reader)
		{
			long reqMsgId = reader.ReadInt64();
			var rpcResult = new RpcResult { req_msg_id = reqMsgId };
			if (reqMsgId == _session.LastSentMsgId)
				rpcResult.result = Schema.DeserializeValue(reader, _lastRpcResultType);
			else
				rpcResult.result = Schema.Deserialize<object>(reader);
			return rpcResult;
		}

		public class RpcException : Exception
		{
			public readonly int Code;
			public RpcException(int code, string message) : base(message) => Code = code;
		}

		public async Task<X> CallAsync<X>(ITLFunction<X> request) 
		{
			await SendAsync(request);
			_lastRpcResultType = typeof(X);
			for (; ;)
			{
				var reply = await RecvInternalAsync();
				if (reply is RpcResult rpcResult && rpcResult.req_msg_id == _session.LastSentMsgId)
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

		private async Task HandleMessageAsync(object obj)
		{
			switch (obj)
			{
				case MsgContainer container:
					foreach (var msg in container.messages)
					{
						Console.Write($"          → {msg.body?.GetType().Name}");
						Console.WriteLine($"{new string(' ', Math.Max(0, 60 - Console.CursorLeft))} timestamp={_session.MsgIdToStamp(msg.msg_id)} isResponse={(msg.msg_id & 2) != 0} {(msg.seqno == -1 ? "clearText" : "isContent")}={(msg.seqno & 1) != 0}");
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
					Console.WriteLine($"BadMsgNotification {badMsgNotification.error_code} for msg {badMsgNotification.bad_msg_seqno}");
					break;
				case RpcResult rpcResult:
					if (_session.MsgIdToStamp(rpcResult.req_msg_id) >= _session.SessionStart)
						throw new ApplicationException($"Got RpcResult({rpcResult.result.GetType().Name}) for unknown msgId {rpcResult.req_msg_id}");
					break; // silently ignore results for msg_id from previous sessions
				default:
					//_updateHandler?.Invoke(obj);
					break;
			}
		}

		public async Task<User> UserAuthIfNeeded(CodeSettings settings = null)
		{
			if (_session.User != null)
				return Schema.Deserialize<User>(_session.User);
			string phone_number = _config("phone_number");
			var sentCode = await CallAsync(new Auth_SendCode
			{
				phone_number = phone_number,
				api_id = _apiId,
				api_hash = _apiHash,
				settings = settings ?? new()
			});
			Console.WriteLine($"A verification code has been sent via {sentCode.type.GetType().Name[17..]}");
			var verification_code = _config("verification_code");
			var authorization = await CallAsync(new Auth_SignIn
			{
				phone_number = phone_number,
				phone_code_hash = sentCode.phone_code_hash,
				phone_code = verification_code
			});
			if (authorization is not Auth_Authorization { user: User user } auth_success)
				throw new ApplicationException("Failed to get Authorization: " + authorization.GetType().Name);
			//TODO: support Auth_AuthorizationSignUpRequired?
			_session.User = Schema.Serialize(user);
			return user;
		}
	}
}
