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
using System.Threading;
using System.Threading.Tasks;
using TL;
using static WTelegram.Encryption;

// necessary for .NET Standard 2.0 compilation:
#pragma warning disable CA1835 // Prefer the 'Memory'-based overloads for 'ReadAsync' and 'WriteAsync'

namespace WTelegram
{
	public sealed class Client : IDisposable
	{
		public event Action<ITLObject> Update;
		public Config TLConfig { get; private set; }
		public int MaxAutoReconnects { get; set; } = 5; // number of automatic reconnections on connection/reactor failure

		private readonly Func<string, string> _config;
		private readonly int _apiId;
		private readonly string _apiHash;
		private readonly Session _session;
		private Session.DCSession DCSession => _session.CurrentDCSession;
		private static readonly byte[] IntermediateHeader = new byte[4] { 0xee, 0xee, 0xee, 0xee };
		private TcpClient _tcpClient;
		private NetworkStream _networkStream;
		private ITLFunction _lastSentMsg;
		private long _lastRecvMsgId;
		private readonly List<long> _msgsToAck = new();
		private readonly Random _random = new();
		private int _unexpectedSaltChange;
		private Task _reactorTask;
		private long _bareRequest;
		private readonly Dictionary<long, (Type type, TaskCompletionSource<object> tcs)> _pendingRequests = new();
		private SemaphoreSlim _sendSemaphore = new(0);
		private CancellationTokenSource _cts;
		private int _reactorReconnects = 0;

		/// <summary>Welcome to WTelegramClient! 😀</summary>
		/// <param name="configProvider">Config callback, is queried for: api_id, api_hash, session_pathname</param>
		public Client(Func<string, string> configProvider = null)
		{
			_config = configProvider ?? DefaultConfigOrAsk;
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
			"user_id" => "-1",
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

		public void Dispose()
		{
			Helpers.Log(2, "Disposing the client");
			if (CheckMsgsToAck() is MsgsAck msgsAck) 
				SendAsync(MakeFunction(msgsAck), false).Wait(1000);
			_cts?.Cancel();
			_reactorTask = null;
			_tcpClient?.Dispose();
		}

		// disconnect and eventually reset sessions (forget servers, current user)
		public void Reset(bool resetSessions = true)
		{
			_cts?.Cancel();
			_sendSemaphore = new(0);
			_reactorTask = null;
			_tcpClient?.Dispose();
			if (resetSessions)
			{
				_session.DCSessions.Clear();
				_session.User = null;
			}
		}

		/// <summary>Establish connection to Telegram servers. Config callback is queried for: server_address</summary>
		/// <returns>Most methods of this class are async Task, so please use <see langword="await"/></returns>
		public async Task ConnectAsync(int dc = default)
		{
			if (_reactorTask != null)
				throw new ApplicationException("Already connected!");
			_session.ChangeDC(dc);
			var endpoint = DCSession?.EndPoint ?? Compat.IPEndPoint_Parse(Config("server_address"));
			Helpers.Log(2, $"Connecting to {endpoint}...");
			_tcpClient = new TcpClient(endpoint.AddressFamily);
			await _tcpClient.ConnectAsync(endpoint.Address, endpoint.Port);
			_networkStream = _tcpClient.GetStream();
			await _networkStream.WriteAsync(IntermediateHeader, 0, 4);
			_cts = new();
			_reactorTask = Reactor(_networkStream, _cts);
			_sendSemaphore.Release();

			try
			{
				if (DCSession.AuthKeyID == 0)
					await CreateAuthorizationKey(this, DCSession);

				var keepAliveTask = KeepAlive(_cts.Token);
				TLConfig = await this.InvokeWithLayer<Config>(Layer.Version,
					Schema.InitConnection(_apiId,
						Config("device_model"),
						Config("system_version"),
						Config("app_version"),
						Config("system_lang_code"),
						Config("lang_pack"),
						Config("lang_code"),
						Schema.Help_GetConfig));
				if (DCSession.DataCenter == null)
				{
					DCSession.DataCenter = TLConfig.dc_options.Where(dc => dc.id == TLConfig.this_dc)
						.OrderByDescending(dc => dc.ip_address == endpoint.Address.ToString())
						.ThenByDescending(dc => dc.port == endpoint.Port).First();
					_session.DCSessions[TLConfig.this_dc] = DCSession;
				}
				if (_session.MainDC == 0) _session.MainDC = TLConfig.this_dc;
			}
			finally
			{
				_session.Save();
			}
			Helpers.Log(2, $"Connected to {(TLConfig.test_mode ? "Test DC" : "DC")} {TLConfig.this_dc}... {TLConfig.flags & (Config.Flags)~0xE00}");
		}

		public async Task MigrateDCAsync(int dcId = 0)
		{
			if (dcId == 0) dcId = _session.MainDC;
			if (DCSession.DataCenter?.id == dcId) return;
			Helpers.Log(2, $"Migrate to DC {dcId}...");
			Auth_ExportedAuthorization exported = null;
			if (_session.User != null && DCSession.DataCenter.id == _session.MainDC)
				exported = await this.Auth_ExportAuthorization(dcId);
			if (CheckMsgsToAck() is MsgsAck msgsAck)
				await SendAsync(MakeFunction(msgsAck), false);
			var prevFamily = _tcpClient.Client.RemoteEndPoint.AddressFamily;
			Reset(false);
			var dcOptions = TLConfig.dc_options.Where(dc => dc.id == dcId && (dc.flags & (DcOption.Flags.media_only | DcOption.Flags.cdn)) == 0);
			if (prevFamily == AddressFamily.InterNetworkV6) // try to stay in the same connectivity
				dcOptions = dcOptions.OrderByDescending(dc => dc.flags & DcOption.Flags.ipv6);  // list ipv6 first
			else
				dcOptions = dcOptions.OrderBy(dc => dc.flags & DcOption.Flags.ipv6);                // list ipv4 first
			var dcOption = dcOptions.FirstOrDefault() ?? throw new ApplicationException($"Could not find adequate dcOption for DC {dcId}");
			_session.DCSessions.GetOrCreate(dcId).DataCenter = dcOption;
			await ConnectAsync(dcId);
			if (exported != null)
			{
				var authorization = await this.Auth_ImportAuthorization(exported.id, exported.bytes);
				if (authorization is not Auth_Authorization { user: User user })
					throw new ApplicationException("Failed to get Authorization: " + authorization.GetType().Name);
				_session.User = user;
			}
		}

		private async Task KeepAlive(CancellationToken ct)
		{
			int ping_id = _random.Next();
			while (!ct.IsCancellationRequested)
			{
				await Task.Delay(60000, ct);
				await this.PingDelayDisconnect(ping_id++, 75);
			}
		}

		private async Task Reactor(NetworkStream stream, CancellationTokenSource cts)
		{
			const int MinBufferSize = 1024;
			var data = new byte[MinBufferSize];
			while (!cts.IsCancellationRequested)
			{
				ITLObject obj = null;
				try
				{
					if (await FullReadAsync(stream, data, 4, cts.Token) != 4)
						throw new ApplicationException("Could not read payload length : Connection shut down");
					int payloadLen = BinaryPrimitives.ReadInt32LittleEndian(data);
					if (payloadLen > data.Length)
						data = new byte[payloadLen];
					else if (Math.Max(payloadLen, MinBufferSize) < data.Length / 4)
						data = new byte[Math.Max(payloadLen, MinBufferSize)];
					if (await FullReadAsync(stream, data, payloadLen, cts.Token) != payloadLen)
						throw new ApplicationException("Could not read frame data : Connection shut down");

					obj = ReadFrame(data, payloadLen);
				}
				catch (Exception ex) // an exception in RecvAsync is always fatal
				{
					if (cts.IsCancellationRequested) return;
					Helpers.Log(5, $"An exception occured in the reactor: {ex}");
					var oldSemaphore = _sendSemaphore;
					await oldSemaphore.WaitAsync(cts.Token); // prevent any sending while we reconnect
					try
					{
						lock (_pendingRequests) // abort all pending requests
						{
							foreach (var (_, tcs) in _pendingRequests.Values)
								_ = Task.Run(() => tcs.SetException(ex), default);
							_pendingRequests.Clear();
							_bareRequest = 0;
						}
						_reactorReconnects = (_reactorReconnects + 1) % MaxAutoReconnects;
						if (_reactorReconnects != 0)
						{
							Reset(false);
							await ConnectAsync(); // start a new reactor
						}
						else
							OnUpdate(new ReactorError { Exception = ex });
					}
					finally
					{
						oldSemaphore.Release();
					}
					cts.Cancel(); // always stop the reactor
				}
				if (obj != null)
					await HandleMessageAsync(obj);
			}
		}

		internal ITLObject ReadFrame(byte[] data, int dataLen)
		{
			if (dataLen == 4 && data[3] == 0xFF)
			{
				int error_code = -BinaryPrimitives.ReadInt32LittleEndian(data);
				throw new RpcException(error_code, TransportError(error_code));
			}
			if (dataLen < 24) // authKeyId+msgId+length+ctorNb | authKeyId+msgKey
				throw new ApplicationException($"Packet payload too small: {dataLen}");

			long authKeyId = BinaryPrimitives.ReadInt64LittleEndian(data);
			if (authKeyId != DCSession.AuthKeyID)
				throw new ApplicationException($"Received a packet encrypted with unexpected key {authKeyId:X}");
			if (authKeyId == 0) // Unencrypted message
			{
				using var reader = new TL.BinaryReader(new MemoryStream(data, 8, dataLen - 8), this);
				long msgId = _lastRecvMsgId = reader.ReadInt64();
				if ((msgId & 1) == 0) throw new ApplicationException($"Invalid server msgId {msgId}");
				int length = reader.ReadInt32();
				if (length != dataLen - 20) throw new ApplicationException($"Unexpected unencrypted length {length} != {dataLen - 20}");

				var obj = reader.ReadTLObject();
				Helpers.Log(1, $"Receiving {obj.GetType().Name,-50} {_session.MsgIdToStamp(msgId):u} {((msgId & 2) == 0 ? "" : "NAR")} unencrypted");
				return obj;
			}
			else
			{
				byte[] decrypted_data = EncryptDecryptMessage(data.AsSpan(24, dataLen - 24), false, DCSession.AuthKey, data, 8);
				if (decrypted_data.Length < 36) // header below+ctorNb
					throw new ApplicationException($"Decrypted packet too small: {decrypted_data.Length}");
				using var reader = new TL.BinaryReader(new MemoryStream(decrypted_data), this);
				var serverSalt = reader.ReadInt64();            // int64 salt
				var sessionId = reader.ReadInt64();             // int64 session_id
				var msgId = _lastRecvMsgId = reader.ReadInt64();// int64 message_id
				var seqno = reader.ReadInt32();                 // int32 msg_seqno
				var length = reader.ReadInt32();                // int32 message_data_length
				var msgStamp = _session.MsgIdToStamp(msgId);

				if (serverSalt != DCSession.Salt)
				{
					Helpers.Log(2, $"Server salt has changed: {DCSession.Salt:X} -> {serverSalt:X}");
					DCSession.Salt = serverSalt;
					if (++_unexpectedSaltChange >= 30)
						throw new ApplicationException($"Server salt changed unexpectedly more than 30 times during this session");
				}
				if (sessionId != _session.Id) throw new ApplicationException($"Unexpected session ID {_session.Id} != {_session.Id}");
				if ((msgId & 1) == 0) throw new ApplicationException($"Invalid server msgId {msgId}");
				if ((seqno & 1) != 0) lock (_msgsToAck) _msgsToAck.Add(msgId);
				if ((msgStamp - DateTime.UtcNow).Ticks / TimeSpan.TicksPerSecond is > 30 or < -300)
					return null;
#if MTPROTO1
				if (decrypted_data.Length - 32 - length is < 0 or > 15) throw new ApplicationException($"Unexpected decrypted message_data_length {length} / {decrypted_data.Length - 32}");
				if (!data.AsSpan(8, 16).SequenceEqual(Sha1Recv.ComputeHash(decrypted_data, 0, 32 + length).AsSpan(4)))
					throw new ApplicationException($"Mismatch between MsgKey & decrypted SHA1");
#else
				if (decrypted_data.Length - 32 - length is < 12 or > 1024) throw new ApplicationException($"Unexpected decrypted message_data_length {length} / {decrypted_data.Length - 32}");
				Sha256Recv.Initialize();
				Sha256Recv.TransformBlock(DCSession.AuthKey, 96, 32, null, 0);
				Sha256Recv.TransformFinalBlock(decrypted_data, 0, decrypted_data.Length);
				if (!data.AsSpan(8, 16).SequenceEqual(Sha256Recv.Hash.AsSpan(8, 16)))
					throw new ApplicationException($"Mismatch between MsgKey & decrypted SHA1");
#endif
				var ctorNb = reader.ReadUInt32();
				if (ctorNb == Layer.MsgContainerCtor)
				{
					Helpers.Log(1, $"Receiving {"MsgContainer",-50} {msgStamp:u} (svc)");
					return ReadMsgContainer(reader);
				}
				else if (ctorNb == Layer.RpcResultCtor)
				{
					Helpers.Log(1, $"Receiving {"RpcResult",-50} {msgStamp:u}");
					return ReadRpcResult(reader);
				}
				else
				{
					var obj = reader.ReadTLObject(ctorNb);
					Helpers.Log(1, $"Receiving {obj.GetType().Name,-50} {msgStamp:u} {((seqno & 1) != 0 ? "" : "(svc)")} {((msgId & 2) == 0 ? "" : "NAR")}");
					return obj;
				}
			}

			static string TransportError(int error_code) => error_code switch
			{
				404 => "Auth key not found",
				429 => "Transport flood",
				_ => ((HttpStatusCode)error_code).ToString(),
			};
		}

		private static async Task<int> FullReadAsync(Stream stream, byte[] buffer, int length, CancellationToken ct = default)
		{
			for (int offset = 0; offset < length;)
			{
				var read = await stream.ReadAsync(buffer, offset, length - offset, ct);
				if (read == 0) return offset;
				offset += read;
			}
			return length;
		}

		private async Task<long> SendAsync(ITLFunction func, bool isContent)
		{
			if (DCSession.AuthKeyID != 0 && isContent && CheckMsgsToAck() is MsgsAck msgsAck)
			{
				var ackMsg = _session.NewMsg(false);
				var mainMsg = _session.NewMsg(true);
				await SendAsync(MakeContainer((MakeFunction(msgsAck), ackMsg), (func, mainMsg)), false);
				return mainMsg.msgId;
			}
			(long msgId, int seqno) = _session.NewMsg(isContent && DCSession.AuthKeyID != 0);
			await _sendSemaphore.WaitAsync();
			try
			{
				using var memStream = new MemoryStream(1024);
				using var writer = new BinaryWriter(memStream, Encoding.UTF8);
				writer.Write(0);                // int32 payload_len (to be patched with payload length)

				if (DCSession.AuthKeyID == 0) // send unencrypted message
				{
					writer.Write(0L);						// int64 auth_key_id = 0 (Unencrypted)
					writer.Write(msgId);					// int64 message_id
					writer.Write(0);						// int32 message_data_length (to be patched)
					var typeName = func(writer);			// bytes message_data
					Helpers.Log(1, $"Sending   {typeName}...");
					BinaryPrimitives.WriteInt32LittleEndian(memStream.GetBuffer().AsSpan(20), (int)memStream.Length - 24);    // patch message_data_length
				}
				else
				{
					using var clearStream = new MemoryStream(1024);
					using var clearWriter = new BinaryWriter(clearStream, Encoding.UTF8);
	#if MTPROTO1
					const int prepend = 0;
	#else
					const int prepend = 32;
					clearWriter.Write(DCSession.AuthKey, 88, prepend);
	#endif
					clearWriter.Write(DCSession.Salt);		// int64 salt
					clearWriter.Write(_session.Id);			// int64 session_id
					clearWriter.Write(msgId);				// int64 message_id
					clearWriter.Write(seqno);				// int32 msg_seqno
					clearWriter.Write(0);					// int32 message_data_length (to be patched)
					var typeName = func(clearWriter);		// bytes message_data
					if ((seqno & 1) != 0)
						Helpers.Log(1, $"Sending   {typeName,-50} #{(short)msgId.GetHashCode():X4}");
					else
						Helpers.Log(1, $"Sending   {typeName,-50} {_session.MsgIdToStamp(msgId):u} (svc)");
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
					var msgKeyLarge = Sha1.ComputeHash(clearBuffer, 0, clearLength); // padding excluded from computation!
					const int msgKeyOffset = 4;	// msg_key = low 128-bits of SHA1(plaintext)
	#else
					var msgKeyLarge = Sha256.ComputeHash(clearBuffer, 0, prepend + clearLength + padding);
					const int msgKeyOffset = 8; // msg_key = middle 128-bits of SHA256(authkey_part+plaintext+padding)
	#endif
					byte[] encrypted_data = EncryptDecryptMessage(clearBuffer.AsSpan(prepend, clearLength + padding), true, DCSession.AuthKey, msgKeyLarge, msgKeyOffset);

					writer.Write(DCSession.AuthKeyID);				// int64 auth_key_id
					writer.Write(msgKeyLarge, msgKeyOffset, 16);	// int128 msg_key
					writer.Write(encrypted_data);					// bytes encrypted_data
				}
				var buffer = memStream.GetBuffer();
				int frameLength = (int)memStream.Length;
				BinaryPrimitives.WriteInt32LittleEndian(buffer, frameLength - 4); // patch payload_len with correct value
				//TODO: support Transport obfuscation?

				await _networkStream.WriteAsync(memStream.GetBuffer(), 0, frameLength);
				_lastSentMsg = func;
			}
			finally
			{
				_sendSemaphore.Release();
			}
			return msgId;
		}

		private static ITLFunction MakeFunction(ITLObject msg)
			=> writer =>
			{
				writer.WriteTLObject(msg);
				return msg.GetType().Name;
			};

		internal MsgContainer ReadMsgContainer(TL.BinaryReader reader)
		{
			int count = reader.ReadInt32();
			var array = new _Message[count];
			for (int i = 0; i < count; i++)
			{
				var msg = array[i] = new _Message
				{
					msg_id = reader.ReadInt64(),
					seqno = reader.ReadInt32(),
					bytes = reader.ReadInt32(),
				};
				if ((msg.seqno & 1) != 0) lock(_msgsToAck) _msgsToAck.Add(msg.msg_id);
				var pos = reader.BaseStream.Position;
				try
				{
					var ctorNb = reader.ReadUInt32();
					if (ctorNb == Layer.RpcResultCtor)
					{
						Helpers.Log(1, $"          → {"RpcResult",-48} {_session.MsgIdToStamp(msg.msg_id):u}");
						msg.body = ReadRpcResult(reader);
					}
					else
					{
						var obj = msg.body = reader.ReadTLObject(ctorNb);
						Helpers.Log(1, $"          → {obj.GetType().Name,-48} {_session.MsgIdToStamp(msg.msg_id):u} {((msg.seqno & 1) != 0 ? "" : "(svc)")} {((msg.msg_id & 2) == 0 ? "" : "NAR")}");
					}
				}
				catch (Exception ex)
				{
					Helpers.Log(4, "While deserializing vector<%Message>: " + ex.ToString());
				}
				reader.BaseStream.Position = pos + array[i].bytes;
			}
			return new MsgContainer { messages = array };
		}

		private RpcResult ReadRpcResult(TL.BinaryReader reader)
		{
			long msgId = reader.ReadInt64();
			var (type, tcs) = PullPendingRequest(msgId);
			object result;
			if (tcs != null)
			{
				result = reader.ReadTLValue(type);
				if (type.IsEnum) result = Enum.ToObject(type, result);
				Log(1, "");
				Task.Run(() => tcs.SetResult(result)); // in Task.Run to avoid deadlock, see https://blog.stephencleary.com/2012/12/dont-block-in-asynchronous-code.html
			}
			else
			{
				result = reader.ReadTLObject();
				if (_session.MsgIdToStamp(msgId) >= _session.SessionStart)
					Log(4, "for unknown msgId ");
				else
					Log(1, "for past msgId ");
			}
			return new RpcResult { req_msg_id = msgId, result = result };

			void Log(int level, string msgIdprefix)
			{
				if (result is RpcError rpcError)
					Helpers.Log(4, $"           → RpcError {rpcError.error_code,3} {rpcError.error_message,-34} {msgIdprefix}#{(short)msgId.GetHashCode():X4}");
				else
					Helpers.Log(level, $"           → {result?.GetType().Name,-47} {msgIdprefix}#{(short)msgId.GetHashCode():X4}");
			}
		}

		private (Type type, TaskCompletionSource<object> tcs) PullPendingRequest(long msgId)
		{
			(Type type, TaskCompletionSource<object> tcs) request;
			lock (_pendingRequests)
				if (_pendingRequests.TryGetValue(msgId, out request))
					_pendingRequests.Remove(msgId);
			return request;
		}

		internal async Task<X> CallBareAsync<X>(ITLFunction request)
		{
			if (_bareRequest != 0) throw new ApplicationException("A bare request is already undergoing");
			var msgId = await SendAsync(request, false);
			var tcs = new TaskCompletionSource<object>();
			lock (_pendingRequests)
				_pendingRequests[msgId] = (typeof(X), tcs);
			_bareRequest = msgId;
			return (X)await tcs.Task;
		}

		public async Task<X> CallAsync<X>(ITLFunction request)
		{
		retry:
			var msgId = await SendAsync(request, true);
			var tcs = new TaskCompletionSource<object>();
			lock (_pendingRequests)
				_pendingRequests[msgId] = (typeof(X), tcs);
			var result = await tcs.Task;
			switch (result)
			{
				case X resultX: return resultX;
				case RpcError rpcError:
					int number;
					if (rpcError.error_code == 303 && ((number = rpcError.error_message.IndexOf("_MIGRATE_")) > 0))
					{
						number = int.Parse(rpcError.error_message[(number + 9)..]);
						if (!rpcError.error_message.StartsWith("FILE_")) _session.MainDC = number;
						await MigrateDCAsync(number);
						goto retry;
					}
					else if (rpcError.error_code == 420 && ((number = rpcError.error_message.IndexOf("_WAIT_")) > 0))
					{
						number = int.Parse(rpcError.error_message[(number + 6)..]);
						if (number <= 60)
						{
							await Task.Delay(number * 1000);
							goto retry;
						}
					}
					else if (rpcError.error_code == 500 && rpcError.error_message == "AUTH_RESTART")
					{
						_session.User = null; // force a full login authorization flow, next time
						_session.Save();
					}
					throw new RpcException(rpcError.error_code, rpcError.error_message);
				default:
					throw new ApplicationException($"{request.GetType().Name} call got a result of type {result.GetType().Name} instead of {typeof(X).Name}");
			}
		}

		private MsgsAck CheckMsgsToAck()
		{
			lock (_msgsToAck)
			{
				if (_msgsToAck.Count == 0) return null;
				var msgsAck = new MsgsAck { msg_ids = _msgsToAck.ToArray() };
				_msgsToAck.Clear();
				return msgsAck;
			}
		}

		private ITLFunction MakeContainer(params (ITLFunction func, (long msgId, int seqno))[] msgs)
			=> writer =>
			{
				writer.Write(0x73F1F8DC);
				writer.Write(msgs.Length);
				foreach (var (func, (msgId, seqno)) in msgs)
				{
					writer.Write(msgId);
					writer.Write(seqno);
					var patchPos = writer.BaseStream.Position;
					writer.Write(0);
					var typeName = func(writer);
					if ((seqno & 1) != 0)
						Helpers.Log(1, $"Sending → {typeName,-50} #{(short)msgId.GetHashCode():X4}");
					else
						Helpers.Log(1, $"Sending → {typeName,-50} {_session.MsgIdToStamp(msgId):u} (svc)");
					writer.BaseStream.Position = patchPos;
					writer.Write((int)(writer.BaseStream.Length - patchPos - 4)); // patch bytes field
					writer.Seek(0, SeekOrigin.End);
				}
				return "as MsgContainer";
			};

		private async Task HandleMessageAsync(ITLObject obj)
		{
			switch (obj)
			{
				case MsgContainer container:
					foreach (var msg in container.messages)
						if (msg.body != null)
							await HandleMessageAsync(msg.body);
					break;
				case MsgCopy msgCopy:
					if (msgCopy?.orig_message?.body != null)
						await HandleMessageAsync(msgCopy.orig_message.body);
					break;
				case BadServerSalt badServerSalt:
					DCSession.Salt = badServerSalt.new_server_salt;
					if (badServerSalt.bad_msg_id == DCSession.LastSentMsgId)
					{
						var newMsgId = await SendAsync(_lastSentMsg, true);
						lock (_pendingRequests)
							if (_pendingRequests.TryGetValue(badServerSalt.bad_msg_id, out var t))
							{
								_pendingRequests.Remove(badServerSalt.bad_msg_id);
								_pendingRequests[newMsgId] = t;
							}
					}
					break;
				case Ping ping:
					_ = SendAsync(MakeFunction(new Pong { msg_id = _lastRecvMsgId, ping_id = ping.ping_id }), false);
					break;
				case Pong pong:
					SetResult(pong.msg_id, pong);
					break;
				case FutureSalts futureSalts:
					SetResult(futureSalts.req_msg_id, futureSalts);
					break;
				case RpcResult rpcResult:
					break; // SetResult was already done in ReadRpcResult
				case MsgsAck msgsAck:
					break; // we don't do anything with these, for now
				case BadMsgNotification badMsgNotification:
					{
						Helpers.Log(4, $"BadMsgNotification {badMsgNotification.error_code} for msg #{(short)badMsgNotification.bad_msg_id.GetHashCode():X4}");
						var (type, tcs) = PullPendingRequest(badMsgNotification.bad_msg_id);
						if (tcs != null)
						{
							if (_bareRequest == badMsgNotification.bad_msg_id) _bareRequest = 0;
							_ = Task.Run(() => tcs.SetException(new ApplicationException($"BadMsgNotification {badMsgNotification.error_code}")));
						}
						else
							OnUpdate(obj);
					}
					break;
				default:
					if (_bareRequest != 0)
					{
						var (type, tcs) = PullPendingRequest(_bareRequest);
						if (type?.IsAssignableFrom(obj.GetType()) == true)
						{
							_bareRequest = 0;
							_ = Task.Run(() => tcs.SetResult(obj));
							break;
						}
					}
					OnUpdate(obj);
					break;
			}

			void SetResult(long msgId, object result)
			{
				var (type, tcs) = PullPendingRequest(msgId);
				if (tcs != null)
					_ = Task.Run(() => tcs.SetResult(result));
				else
					OnUpdate(obj);
			}
		}

		private void OnUpdate(ITLObject obj)
		{
			try
			{
				Update?.Invoke(obj);
			}
			catch (Exception ex)
			{
				Helpers.Log(4, $"Update callback on {obj.GetType().Name} raised {ex}");
			}
		}

		/// <summary>
		/// Login as bot (if not already done).
		/// Config callback is queried for: bot_token
		/// </summary>
		/// <returns>Detail about the logged bot</returns>
		public async Task<User> LoginBotIfNeeded()
		{
			string botToken = Config("bot_token");
			if (_session.User != null)
			{ 
				try
				{
					var prevUser = _session.User;
					if (prevUser?.id == int.Parse(botToken.Split(':')[0]))
						return prevUser;
				}
				catch (Exception ex)
				{
					Helpers.Log(4, $"Error deserializing User! ({ex.Message}) Proceeding to login...");
				}
				await this.Auth_LogOut();
			}
			var authorization = await this.Auth_ImportBotAuthorization(0, _apiId, _apiHash, botToken);
			if (authorization is not Auth_Authorization { user: User user })
				throw new ApplicationException("Failed to get Authorization: " + authorization.GetType().Name);
			_session.User = user;
			_session.Save();
			return user;
		}

		/// <summary>
		/// Login as a user (if not already done).
		/// Config callback is queried for: phone_number, verification_code
		/// <br/>and eventually first_name, last_name (signup required), password (2FA auth), user_id (alt validation)
		/// </summary>
		/// <param name="settings"></param>
		/// <returns>Detail about the logged user</returns>
		public async Task<User> LoginUserIfNeeded(CodeSettings settings = null)
		{
			string phone_number = null;
			if (_session.User != null)
			{
				try
				{
					var prevUser = _session.User;
					var userId = _config("user_id"); // if config prefers to validate current user by its id, use it
					if (userId == null || !int.TryParse(userId, out int id) || id != -1 && prevUser.id != id)
					{
						phone_number = Config("phone_number"); // otherwise, validation is done by the phone number
						if (prevUser?.phone != string.Concat(phone_number.Where(char.IsDigit)))
							prevUser = null;
					}
					if (prevUser != null)
					{
						// TODO: implement a more complete Updates gaps handling system? https://core.telegram.org/api/updates
						var udpatesState = await this.Updates_GetState();
						OnUpdate(udpatesState);
						return prevUser;
					}
				}
				catch (Exception ex)
				{
					Helpers.Log(4, $"Error deserializing User! ({ex.Message}) Proceeding to login...");
				}
				await this.Auth_LogOut();
			}
			phone_number ??= Config("phone_number");
			var sentCode = await this.Auth_SendCode(phone_number, _apiId, _apiHash, settings ?? new());
			Helpers.Log(3, $"A verification code has been sent via {sentCode.type.GetType().Name[17..]}");
			var verification_code = Config("verification_code");
			Auth_AuthorizationBase authorization;
			try
			{
				authorization = await this.Auth_SignIn(phone_number, sentCode.phone_code_hash, verification_code);
			}
			catch (RpcException e) when (e.Code == 401 && e.Message == "SESSION_PASSWORD_NEEDED")
			{
				var accountPassword = await this.Account_GetPassword();
				Helpers.Log(3, $"This account has enabled 2FA. A password is needed. {accountPassword.hint}");
				var checkPasswordSRP = Check2FA(accountPassword, Config("password"));
				authorization = await this.Auth_CheckPassword(checkPasswordSRP);
			}
			if (authorization is Auth_AuthorizationSignUpRequired signUpRequired)
			{
				var waitUntil = DateTime.UtcNow.AddSeconds(3);
				if (signUpRequired.terms_of_service != null)
					OnUpdate(signUpRequired.terms_of_service); // give caller the possibility to read and accept TOS
				var first_name = Config("first_name");
				var last_name = Config("last_name");
				var wait = waitUntil - DateTime.UtcNow;
				if (wait > TimeSpan.Zero) await Task.Delay(wait); // we get a FLOOD_WAIT_3 if we SignUp too fast
				authorization = await this.Auth_SignUp(phone_number, sentCode.phone_code_hash, first_name, last_name);
			}
			if (authorization is not Auth_Authorization { user: User user })
				throw new ApplicationException("Failed to get Authorization: " + authorization.GetType().Name);
			//TODO: find better serialization for User not subject to TL changes?
			_session.User = user;
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
				int file_part = 0, read;
				const int ParallelSends = 10;
				var semaphore = new SemaphoreSlim(ParallelSends);
				var tasks = new Dictionary<int, Task>();
				bool abort = false;
				for (long bytesLeft = length; !abort && bytesLeft != 0; file_part++)
				{
					var bytes = new byte[Math.Min(partSize, bytesLeft)];
					read = await FullReadAsync(stream, bytes, bytes.Length);
					await semaphore.WaitAsync();
					var task = SavePart(file_part, bytes);
					lock (tasks) tasks[file_part] = task;
					if (!isBig)
						md5.TransformBlock(bytes, 0, read, null, 0);
					bytesLeft -= read;
					if (read < partSize && bytesLeft != 0) throw new ApplicationException($"Failed to fully read stream ({read},{bytesLeft})");

					async Task SavePart(int file_part, byte[] bytes)
					{
						try
						{
							if (isBig)
								await this.Upload_SaveBigFilePart(file_id, file_part, file_total_parts, bytes);
							else
								await this.Upload_SaveFilePart(file_id, file_part, bytes);
							lock (tasks) tasks.Remove(file_part);
						}
						catch (Exception)
						{
							abort = true;
						}
						finally
						{
							semaphore.Release();
						}
					}
				}
				for (int i = 0; i < ParallelSends; i++)
					await semaphore.WaitAsync(); // wait for all the remaining parts to be sent
				await Task.WhenAll(tasks.Values); // propagate any task exception (tasks should be empty on success)
				if (!isBig) md5.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
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
				return this.Messages_SendMessage(peer, text, Helpers.RandomLong(),
					no_webpage: disable_preview, reply_to_msg_id: reply_to_msg_id, entities: entities, schedule_date: schedule_date);
			else
				return this.Messages_SendMedia(peer, media, text, Helpers.RandomLong(),
					reply_to_msg_id: reply_to_msg_id, entities: entities, schedule_date: schedule_date);
		}

		/// <summary>Download given photo from Telegram into the outputStream</summary>
		/// <param name="outputStream">stream to write to. This method does not close/dispose the stream</param>
		/// <param name="photoSize">if unspecified, will download the largest version of the photo</param>
		public async Task<Storage_FileType> DownloadFileAsync(Photo photo, Stream outputStream, PhotoSizeBase photoSize = null)
		{
			var fileLocation = photo.ToFileLocation(photoSize ?? photo.LargestPhotoSize);
			await MigrateDCAsync(photo.dc_id);
			return await DownloadFileAsync(fileLocation, outputStream);
		}

		/// <summary>Download given photo from Telegram into the outputStream</summary>
		/// <param name="outputStream">stream to write to. This method does not close/dispose the stream</param>
		/// <param name="thumbSize">if specified, will download the given thumbnail instead of the full document</param>
		public async Task<Storage_FileType> DownloadFileAsync(Document document, Stream outputStream, PhotoSizeBase thumbSize = null)
		{
			var fileLocation = document.ToFileLocation(thumbSize);
			await MigrateDCAsync(document.dc_id);
			return await DownloadFileAsync(fileLocation, outputStream);
		}

		/// <summary>Download given file from Telegram into the outputStream</summary>
		/// <param name="fileLocation">Telegram file identifier, typically obtained with a .ToFileLocation() call</param>
		/// <param name="outputStream">stream to write to. This method does not close/dispose the stream</param>
		public async Task<Storage_FileType> DownloadFileAsync(InputFileLocationBase fileLocation, Stream outputStream)
		{
			const int ChunkSize = 128 * 1024;
			int fileSize = 0;
			Upload_File fileData;
			do
			{
				var fileBase = await this.Upload_GetFile(fileLocation, fileSize, ChunkSize);
				fileData = fileBase as Upload_File;
				if (fileData == null)
					throw new ApplicationException("Upload_GetFile returned unsupported " + fileBase.GetType().Name);
				await outputStream.WriteAsync(fileData.bytes, 0, fileData.bytes.Length);
				fileSize += fileData.bytes.Length;
				
			} while (fileData.bytes.Length == ChunkSize);
			await MigrateDCAsync(); // migrate back to main DC
			return fileData.type;
		}
		#endregion

		/// <summary>Enable the collection of id/access_hash pairs (experimental)</summary>
		public bool CollectAccessHash { get; set; }
		readonly Dictionary<Type, Dictionary<long, long>> _accessHashes = new();
		public IEnumerable<KeyValuePair<long, long>> AllAccessHashesFor<T>() where T : ITLObject
			=> _accessHashes.GetValueOrDefault(typeof(T));
		/// <summary>Retrieve the access_hash associated with this id (for a TL class)</summary>
		/// <typeparam name="T">a TL object class. For example User, Channel or Photo</typeparam>
		public long? GetAccessHashFor<T>(long id) where T : ITLObject
		{
			lock (_accessHashes)
				return _accessHashes.GetOrCreate(typeof(T)).TryGetValue(id, out var access_hash) ? access_hash : null;
		}
		public void SetAccessHashFor<T>(long id, long access_hash) where T : ITLObject
		{
			lock (_accessHashes)
				_accessHashes.GetOrCreate(typeof(T))[id] = access_hash;
		}
		internal void UpdateAccessHash(object obj, Type type, object access_hash)
		{
			if (!CollectAccessHash) return;
			if (access_hash is not long accessHash) return;
			if (type.GetField("id") is not FieldInfo idField) return;
			if (idField.GetValue(obj) is not long id)
				if (idField.GetValue(obj) is not int idInt) return;
				else id = idInt;
			lock (_accessHashes)
				_accessHashes.GetOrCreate(type)[id] = accessHash;
		}
	}
}
