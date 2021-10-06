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
		public bool IsMainDC => (_dcSession?.DataCenter?.id ?? 0) == _session.MainDC;
		public bool Disconnected => _tcpClient != null && !(_tcpClient.Client?.Connected ?? false);

		private readonly Func<string, string> _config;
		private readonly int _apiId;
		private readonly string _apiHash;
		private readonly Session _session;
		private Session.DCSession _dcSession;
		private static readonly byte[] IntermediateHeader = new byte[4] { 0xee, 0xee, 0xee, 0xee };
		private TcpClient _tcpClient;
		private NetworkStream _networkStream;
		private ITLFunction _lastSentMsg;
		private long _lastRecvMsgId;
		private readonly List<long> _msgsToAck = new();
		private readonly Random _random = new();
		private int _saltChangeCounter;
		private Task _reactorTask;
		private long _bareRequest;
		private readonly Dictionary<long, (Type type, TaskCompletionSource<object> tcs)> _pendingRequests = new();
		private SemaphoreSlim _sendSemaphore = new(0);
		private readonly SemaphoreSlim _semaphore = new(1);
		private Task _connecting;
		private CancellationTokenSource _cts;
		private int _reactorReconnects = 0;
		private const int FilePartSize = 512 * 1024;
		private readonly SemaphoreSlim _parallelTransfers = new(10); // max parallel part uploads/downloads
#if MTPROTO1
		private readonly SHA1 _sha1 = SHA1.Create();
		private readonly SHA1 _sha1Recv = SHA1.Create();
#else
		private readonly SHA256 _sha256 = SHA256.Create();
		private readonly SHA256 _sha256Recv = SHA256.Create();
#endif

		/// <summary>Welcome to WTelegramClient! 😀</summary>
		/// <param name="configProvider">Config callback, is queried for: api_id, api_hash, session_pathname</param>
		public Client(Func<string, string> configProvider = null)
		{
			_config = configProvider ?? DefaultConfigOrAsk;
			_apiId = int.Parse(Config("api_id"));
			_apiHash = Config("api_hash");
			_session = Session.LoadOrCreate(Config("session_pathname"), Convert.FromHexString(_apiHash));
			if (_session.MainDC != 0) _session.DCSessions.TryGetValue(_session.MainDC, out _dcSession);
			_dcSession ??= new() { Id = Helpers.RandomLong() };
			_dcSession.Client = this;
		}

		private Client(Client cloneOf, Session.DCSession dcSession)
		{
			_config = cloneOf._config;
			_apiId = cloneOf._apiId;
			_apiHash = cloneOf._apiHash;
			_session = cloneOf._session;
			_dcSession = dcSession;
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
			Helpers.Log(2, $"{_dcSession.DcID}>Disposing the client");
			Reset(false, IsMainDC);
		}

		// disconnect and eventually forget user and disconnect other sessions
		public void Reset(bool resetUser = true, bool resetSessions = true)
		{
			try
			{
				if (CheckMsgsToAck() is MsgsAck msgsAck)
					SendAsync(MakeFunction(msgsAck), false).Wait(1000);
			}
			catch (Exception)
			{
			}
			_cts?.Cancel();
			_sendSemaphore = new(0);
			_reactorTask = null;
			_tcpClient?.Dispose();
			_connecting = null;
			if (resetSessions)
			{
				foreach (var altSession in _session.DCSessions.Values)
					if (altSession.Client != null && altSession.Client != this)
					{
						altSession.Client.Dispose();
						altSession.Client = null;
					}
			}
			if (resetUser)
				_session.User = null;
		}

		/// <summary>Establish connection to Telegram servers. Config callback is queried for: server_address</summary>
		/// <returns>Most methods of this class are async Task, so please use <see langword="await"/></returns>
		public async Task ConnectAsync()
		{
			lock (this)
				_connecting ??= DoConnectAsync();
			await _connecting;
		}

		private async Task DoConnectAsync()
		{
			var endpoint = _dcSession?.EndPoint ?? Compat.IPEndPoint_Parse(Config("server_address"));
			Helpers.Log(2, $"Connecting to {endpoint}...");
			var tcpClient = new TcpClient(AddressFamily.InterNetworkV6) { Client = { DualMode = true } }; // this allows both IPv4 & IPv6
			try
			{
				try
				{
					await tcpClient.ConnectAsync(endpoint.Address, endpoint.Port);
				}
				catch (SocketException ex) // cannot connect to target endpoint, try to find an alternate
				{
					Helpers.Log(4, $"SocketException {ex.SocketErrorCode} ({ex.ErrorCode}): {ex.Message}");
					if (_dcSession?.DataCenter == null) throw;
					var triedEndpoints = new HashSet<IPEndPoint> { endpoint };
					if (_session.DcOptions != null)
					{
						var altOptions = _session.DcOptions.Where(dco => dco.id == _dcSession.DataCenter.id && dco.flags != _dcSession.DataCenter.flags
							&& (dco.flags & (DcOption.Flags.cdn | DcOption.Flags.tcpo_only | DcOption.Flags.media_only)) == 0)
							.OrderBy(dco => dco.flags);
						// try alternate addresses for this DC
						foreach (var dcOption in altOptions)
						{
							endpoint = new(IPAddress.Parse(dcOption.ip_address), dcOption.port);
							if (!triedEndpoints.Add(endpoint)) continue;
							Helpers.Log(2, $"Connecting to {endpoint}...");
							try
							{
								await tcpClient.ConnectAsync(endpoint.Address, endpoint.Port);
								_dcSession.DataCenter = dcOption;
								break;
							}
							catch (SocketException) { }
						}
					}
					if (!tcpClient.Connected)
					{
						endpoint = Compat.IPEndPoint_Parse(Config("server_address")); // re-ask callback for an address
						if (!triedEndpoints.Add(endpoint)) throw;
						_dcSession.Client = null;
						// is it address for a known DCSession?
						_dcSession = _session.DCSessions.Values.FirstOrDefault(dcs => dcs.EndPoint.Equals(endpoint));
						_dcSession ??= new() { Id = Helpers.RandomLong() };
						_dcSession.Client = this;
						Helpers.Log(2, $"Connecting to {endpoint}...");
						await tcpClient.ConnectAsync(endpoint.Address, endpoint.Port);
					}
				}
			}
			catch (Exception)
			{
				tcpClient.Dispose();
				throw;
			}
			_tcpClient = tcpClient;
			_networkStream = tcpClient.GetStream();
			await _networkStream.WriteAsync(IntermediateHeader, 0, 4);
			_cts = new();
			_saltChangeCounter = 0;
			_reactorTask = Reactor(_networkStream, _cts);
			_sendSemaphore.Release();

			try
			{
				if (_dcSession.AuthKeyID == 0)
					await CreateAuthorizationKey(this, _dcSession);

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
				_session.DcOptions = TLConfig.dc_options;
				_saltChangeCounter = 0;
				if (_dcSession.DataCenter == null)
				{
					_dcSession.DataCenter = _session.DcOptions.Where(dc => dc.id == TLConfig.this_dc)
						.OrderByDescending(dc => dc.ip_address == endpoint.Address.ToString())
						.ThenByDescending(dc => dc.port == endpoint.Port).First();
					_session.DCSessions[TLConfig.this_dc] = _dcSession;
				}
				if (_session.MainDC == 0) _session.MainDC = TLConfig.this_dc;
			}
			finally
			{
				_session.Save();
			}
			Helpers.Log(2, $"Connected to {(TLConfig.test_mode ? "Test DC" : "DC")} {TLConfig.this_dc}... {TLConfig.flags & (Config.Flags)~0xE00}");
		}

		public async Task<Client> GetClientForDC(int dcId, bool media_only = true, bool connect = true)
		{
			if (_dcSession.DataCenter?.id == dcId) return this;
			Session.DCSession altSession;
			lock (_session)
			{
				altSession = GetOrCreateDCSession(dcId, _dcSession.DataCenter.flags | (media_only ? DcOption.Flags.media_only : 0));
				if (altSession.Client?.Disconnected ?? false) { altSession.Client.Dispose(); altSession.Client = null; }
				altSession.Client ??= new Client(this, altSession);
			}
			Helpers.Log(2, $"Requested connection to DC {dcId}...");
			if (connect)
			{
				await _semaphore.WaitAsync();
				try
				{
					Auth_ExportedAuthorization exported = null;
					if (_session.User != null && IsMainDC && altSession.UserId != _session.User.id)
						exported = await this.Auth_ExportAuthorization(dcId);
					await altSession.Client.ConnectAsync();
					if (exported != null)
					{
						var authorization = await altSession.Client.Auth_ImportAuthorization(exported.id, exported.bytes);
						if (authorization is not Auth_Authorization { user: User user })
							throw new ApplicationException("Failed to get Authorization: " + authorization.GetType().Name);
						_session.User = user;
						altSession.UserId = user.id;
					}
				}
				finally
				{
					_semaphore.Release();
				}
			}
			return altSession.Client;
		}

		private Session.DCSession GetOrCreateDCSession(int dcId, DcOption.Flags flags)
		{
			if (_session.DCSessions.TryGetValue(dcId, out var dcSession))
				if (dcSession.Client != null || dcSession.DataCenter.flags == flags)
					return dcSession; // if we have already a session with this DC and we are connected or it is a perfect match, use it
			// try to find the most appropriate DcOption for this DC
			var dcOptions = _session.DcOptions.Where(dc => dc.id == dcId).OrderBy(dc => dc.flags ^ flags);
			var dcOption = dcOptions.FirstOrDefault() ?? throw new ApplicationException($"Could not find adequate dc_option for DC {dcId}");
			dcSession ??= new Session.DCSession { Id = Helpers.RandomLong() }; // create new session only if not already existing
			dcSession.DataCenter = dcOption;
			return _session.DCSessions[dcId] = dcSession;
		}

		internal DateTime MsgIdToStamp(long serverMsgId)
			=> new((serverMsgId >> 32) * 10000000 - _dcSession.ServerTicksOffset + 621355968000000000L, DateTimeKind.Utc);

		internal (long msgId, int seqno) NewMsgId(bool isContent)
		{
			int seqno;
			long msgId = DateTime.UtcNow.Ticks + _dcSession.ServerTicksOffset - 621355968000000000L;
			msgId = msgId * 428 + (msgId >> 24) * 25110956; // approximately unixtime*2^32 and divisible by 4
			lock (_session)
			{
				if (msgId <= _dcSession.LastSentMsgId) msgId = _dcSession.LastSentMsgId += 4; else _dcSession.LastSentMsgId = msgId;
				seqno = isContent ? _dcSession.Seqno++ * 2 + 1 : _dcSession.Seqno * 2;
				_session.Save();
			}
			return (msgId, seqno);
		}

		private async Task KeepAlive(CancellationToken ct)
		{
			int ping_id = _random.Next();
			while (!ct.IsCancellationRequested)
			{
				await Task.Delay(60000, ct);
				if (_saltChangeCounter > 0) --_saltChangeCounter;
#if DEBUG
				await this.PingDelayDisconnect(ping_id++, 300);
#else
				await this.PingDelayDisconnect(ping_id++, 75);
#endif
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
					var reactorError = new ReactorError { Exception = ex };
					try
					{
						_reactorReconnects = (_reactorReconnects + 1) % MaxAutoReconnects;
						if (_reactorReconnects != 0)
						{
							lock (_msgsToAck) _msgsToAck.Clear();
							Reset(false, false);
							await Task.Delay(5000);
							await ConnectAsync(); // start a new reactor after 5 secs
							lock (_pendingRequests) // retry all pending requests
							{
								foreach (var (_, tcs) in _pendingRequests.Values)
									tcs.SetResult(reactorError);
								_pendingRequests.Clear();
								_bareRequest = 0;
							}
						}
						else
							throw;
					}
					catch
					{
						lock (_pendingRequests) // abort all pending requests
						{
							foreach (var (_, tcs) in _pendingRequests.Values)
								tcs.SetException(ex);
							_pendingRequests.Clear();
							_bareRequest = 0;
						}
						OnUpdate(reactorError);
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
			if (authKeyId != _dcSession.AuthKeyID)
				throw new ApplicationException($"Received a packet encrypted with unexpected key {authKeyId:X}");
			if (authKeyId == 0) // Unencrypted message
			{
				using var reader = new TL.BinaryReader(new MemoryStream(data, 8, dataLen - 8), this);
				long msgId = _lastRecvMsgId = reader.ReadInt64();
				if ((msgId & 1) == 0) throw new ApplicationException($"Invalid server msgId {msgId}");
				int length = reader.ReadInt32();
				if (length != dataLen - 20) throw new ApplicationException($"Unexpected unencrypted length {length} != {dataLen - 20}");

				var obj = reader.ReadTLObject();
				Helpers.Log(1, $"{_dcSession.DcID}>Receiving {obj.GetType().Name,-40} {MsgIdToStamp(msgId):u} clear{((msgId & 2) == 0 ? "" : " NAR")}");
				return obj;
			}
			else
			{
#if MTPROTO1
				byte[] decrypted_data = EncryptDecryptMessage(data.AsSpan(24, dataLen - 24), false, _dcSession.AuthKey, data, 8, _sha1Recv);
#else
				byte[] decrypted_data = EncryptDecryptMessage(data.AsSpan(24, dataLen - 24), false, _dcSession.AuthKey, data, 8, _sha256Recv);
#endif
				if (decrypted_data.Length < 36) // header below+ctorNb
					throw new ApplicationException($"Decrypted packet too small: {decrypted_data.Length}");
				using var reader = new TL.BinaryReader(new MemoryStream(decrypted_data), this);
				var serverSalt = reader.ReadInt64();            // int64 salt
				var sessionId = reader.ReadInt64();             // int64 session_id
				var msgId = _lastRecvMsgId = reader.ReadInt64();// int64 message_id
				var seqno = reader.ReadInt32();                 // int32 msg_seqno
				var length = reader.ReadInt32();                // int32 message_data_length
				var msgStamp = MsgIdToStamp(msgId);

				if (serverSalt != _dcSession.Salt) // salt change happens every 30 min
				{
					Helpers.Log(2, $"{_dcSession.DcID}>Server salt has changed: {_dcSession.Salt:X} -> {serverSalt:X}");
					_dcSession.Salt = serverSalt;
					_saltChangeCounter += 20; // counter is decreased by KeepAlive every minute (we have margin of 10)
					if (_saltChangeCounter >= 30)
						throw new ApplicationException($"Server salt changed too often! Security issue?");
				}
				if (sessionId != _dcSession.Id) throw new ApplicationException($"Unexpected session ID {sessionId} != {_dcSession.Id}");
				if ((msgId & 1) == 0) throw new ApplicationException($"Invalid server msgId {msgId}");
				if ((seqno & 1) != 0) lock (_msgsToAck) _msgsToAck.Add(msgId);
				if ((msgStamp - DateTime.UtcNow).Ticks / TimeSpan.TicksPerSecond is > 30 or < -300)
					return null;
#if MTPROTO1
				if (decrypted_data.Length - 32 - length is < 0 or > 15) throw new ApplicationException($"Unexpected decrypted message_data_length {length} / {decrypted_data.Length - 32}");
				if (!data.AsSpan(8, 16).SequenceEqual(_sha1Recv.ComputeHash(decrypted_data, 0, 32 + length).AsSpan(4)))
					throw new ApplicationException($"Mismatch between MsgKey & decrypted SHA1");
#else
				if (decrypted_data.Length - 32 - length is < 12 or > 1024) throw new ApplicationException($"Unexpected decrypted message_data_length {length} / {decrypted_data.Length - 32}");
				_sha256Recv.Initialize();
				_sha256Recv.TransformBlock(_dcSession.AuthKey, 96, 32, null, 0);
				_sha256Recv.TransformFinalBlock(decrypted_data, 0, decrypted_data.Length);
				if (!data.AsSpan(8, 16).SequenceEqual(_sha256Recv.Hash.AsSpan(8, 16)))
					throw new ApplicationException($"Mismatch between MsgKey & decrypted SHA1");
#endif
				var ctorNb = reader.ReadUInt32();
				if (ctorNb == Layer.MsgContainerCtor)
				{
					Helpers.Log(1, $"{_dcSession.DcID}>Receiving {"MsgContainer",-40} {msgStamp:u} (svc)");
					return ReadMsgContainer(reader);
				}
				else if (ctorNb == Layer.RpcResultCtor)
				{
					Helpers.Log(1, $"{_dcSession.DcID}>Receiving {"RpcResult",-40} {msgStamp:u}");
					return ReadRpcResult(reader);
				}
				else
				{
					var obj = reader.ReadTLObject(ctorNb);
					Helpers.Log(1, $"{_dcSession.DcID}>Receiving {obj.GetType().Name,-40} {msgStamp:u} {((seqno & 1) != 0 ? "" : "(svc)")} {((msgId & 2) == 0 ? "" : "NAR")}");
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
			if (_dcSession.AuthKeyID != 0 && isContent && CheckMsgsToAck() is MsgsAck msgsAck)
			{
				var ackMsg = NewMsgId(false);
				var mainMsg = NewMsgId(true);
				await SendAsync(MakeContainer((MakeFunction(msgsAck), ackMsg), (func, mainMsg)), false);
				return mainMsg.msgId;
			}
			(long msgId, int seqno) = NewMsgId(isContent && _dcSession.AuthKeyID != 0);
			await _sendSemaphore.WaitAsync();
			try
			{
				using var memStream = new MemoryStream(1024);
				using var writer = new BinaryWriter(memStream, Encoding.UTF8);
				writer.Write(0);                // int32 payload_len (to be patched with payload length)

				if (_dcSession.AuthKeyID == 0) // send unencrypted message
				{
					writer.Write(0L);						// int64 auth_key_id = 0 (Unencrypted)
					writer.Write(msgId);					// int64 message_id
					writer.Write(0);						// int32 message_data_length (to be patched)
					var typeName = func(writer);			// bytes message_data
					Helpers.Log(1, $"{_dcSession.DcID}>Sending   {typeName}...");
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
					clearWriter.Write(_dcSession.AuthKey, 88, prepend);
#endif
					clearWriter.Write(_dcSession.Salt);		// int64 salt
					clearWriter.Write(_dcSession.Id);		// int64 session_id
					clearWriter.Write(msgId);				// int64 message_id
					clearWriter.Write(seqno);				// int32 msg_seqno
					clearWriter.Write(0);					// int32 message_data_length (to be patched)
					var typeName = func(clearWriter);		// bytes message_data
					if ((seqno & 1) != 0)
						Helpers.Log(1, $"{_dcSession.DcID}>Sending   {typeName,-40} #{(short)msgId.GetHashCode():X4}");
					else
						Helpers.Log(1, $"{_dcSession.DcID}>Sending   {typeName,-40} {MsgIdToStamp(msgId):u} (svc)");
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
					var msgKeyLarge = _sha1.ComputeHash(clearBuffer, 0, clearLength); // padding excluded from computation!
					const int msgKeyOffset = 4;	// msg_key = low 128-bits of SHA1(plaintext)
					byte[] encrypted_data = EncryptDecryptMessage(clearBuffer.AsSpan(prepend, clearLength + padding), true, _dcSession.AuthKey, msgKeyLarge, msgKeyOffset, _sha1);
#else
					var msgKeyLarge = _sha256.ComputeHash(clearBuffer, 0, prepend + clearLength + padding);
					const int msgKeyOffset = 8; // msg_key = middle 128-bits of SHA256(authkey_part+plaintext+padding)
					byte[] encrypted_data = EncryptDecryptMessage(clearBuffer.AsSpan(prepend, clearLength + padding), true, _dcSession.AuthKey, msgKeyLarge, msgKeyOffset, _sha256);
#endif

					writer.Write(_dcSession.AuthKeyID);				// int64 auth_key_id
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
						Helpers.Log(1, $"            → {"RpcResult",-38} {MsgIdToStamp(msg.msg_id):u}");
						msg.body = ReadRpcResult(reader);
					}
					else
					{
						var obj = msg.body = reader.ReadTLObject(ctorNb);
						Helpers.Log(1, $"            → {obj.GetType().Name,-38} {MsgIdToStamp(msg.msg_id):u} {((msg.seqno & 1) != 0 ? "" : "(svc)")} {((msg.msg_id & 2) == 0 ? "" : "NAR")}");
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
				if (!type.IsArray)
					result = reader.ReadTLValue(type);
				else if (reader.ReadUInt32() == Layer.RpcErrorCtor)
					result = reader.ReadTLObject(Layer.RpcErrorCtor);
				else
				{
					reader.BaseStream.Position -= 4;
					result = reader.ReadTLValue(type);
				}
				if (type.IsEnum) result = Enum.ToObject(type, result);
				Log(1, "");
				tcs.SetResult(result);
			}
			else
			{
				result = reader.ReadTLObject();
				if (MsgIdToStamp(msgId) >= _session.SessionStart)
					Log(4, "for unknown msgId ");
				else
					Log(1, "for past msgId ");
			}
			return new RpcResult { req_msg_id = msgId, result = result };

			void Log(int level, string msgIdprefix)
			{
				if (result is RpcError rpcError)
					Helpers.Log(4, $"             → RpcError {rpcError.error_code,3} {rpcError.error_message,-24} {msgIdprefix}#{(short)msgId.GetHashCode():X4}");
				else
					Helpers.Log(level, $"             → {result?.GetType().Name,-37} {msgIdprefix}#{(short)msgId.GetHashCode():X4}");
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
			var tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
			lock (_pendingRequests)
				_pendingRequests[msgId] = (typeof(X), tcs);
			_bareRequest = msgId;
			return (X)await tcs.Task;
		}

		public async Task<X> CallAsync<X>(ITLFunction request)
		{
		retry:
			var msgId = await SendAsync(request, true);
			var tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
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
						if (!rpcError.error_message.StartsWith("FILE_"))
						{
							number = int.Parse(rpcError.error_message[(number + 9)..]);
							// this is a hack to migrate _dcSession in-place (staying in same Client):
							Session.DCSession dcSession;
							lock (_session)
								dcSession = GetOrCreateDCSession(number, _dcSession.DataCenter.flags);
							Reset(false, false);
							_session.MainDC = number;
							_dcSession.Client = null;
							_dcSession = dcSession;
							_dcSession.Client = this;
							await ConnectAsync();
							goto retry;
						}
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
				case ReactorError:
					goto retry;
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
						Helpers.Log(1, $"  Sending → {typeName,-40} #{(short)msgId.GetHashCode():X4}");
					else
						Helpers.Log(1, $"  Sending → {typeName,-40} {MsgIdToStamp(msgId):u} (svc)");
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
					_dcSession.Salt = badServerSalt.new_server_salt;
					if (badServerSalt.bad_msg_id == _dcSession.LastSentMsgId)
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
						var tcs = PullPendingRequest(badMsgNotification.bad_msg_id).tcs;
						if (tcs != null)
						{
							if (_bareRequest == badMsgNotification.bad_msg_id) _bareRequest = 0;
							tcs.SetException(new ApplicationException($"BadMsgNotification {badMsgNotification.error_code}"));
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
							tcs.SetResult(obj);
							break;
						}
					}
					OnUpdate(obj);
					break;
			}

			void SetResult(long msgId, object result)
			{
				var tcs = PullPendingRequest(msgId).tcs;
				if (tcs != null)
					tcs.SetResult(result);
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
				_dcSession.UserId = 0;
			}
			var authorization = await this.Auth_ImportBotAuthorization(0, _apiId, _apiHash, botToken);
			if (authorization is not Auth_Authorization { user: User user })
				throw new ApplicationException("Failed to get Authorization: " + authorization.GetType().Name);
			_session.User = user;
			_dcSession.UserId = user.id;
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
				_dcSession.UserId = 0;
			}
			phone_number ??= Config("phone_number");
			Auth_SentCode sentCode;
			try
			{
				sentCode = await this.Auth_SendCode(phone_number, _apiId, _apiHash, settings ??= new());
			}
			catch (RpcException ex) when (ex.Code == 500 && ex.Message == "AUTH_RESTART")
			{
				sentCode = await this.Auth_SendCode(phone_number, _apiId, _apiHash, settings ??= new());
			}
			Helpers.Log(3, $"A verification code has been sent via {sentCode.type.GetType().Name[17..]}");
			Auth_AuthorizationBase authorization;
			for (int retry = 1; ; retry++)
				try
				{
					var verification_code = Config("verification_code");
					authorization = await this.Auth_SignIn(phone_number, sentCode.phone_code_hash, verification_code);
					break;
				}
				catch (RpcException e) when (e.Code == 401 && e.Message == "SESSION_PASSWORD_NEEDED")
				{
					var accountPassword = await this.Account_GetPassword();
					Helpers.Log(3, $"This account has enabled 2FA. A password is needed. {accountPassword.hint}");
					var checkPasswordSRP = Check2FA(accountPassword, Config("password"));
					authorization = await this.Auth_CheckPassword(checkPasswordSRP);
					break;
				}
				catch (RpcException e) when (e.Code == 400 && e.Message == "PHONE_CODE_INVALID" && retry != 3)
				{
					continue;
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
			_session.User = user;
			_dcSession.UserId = user.id;
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
				int file_total_parts = (int)((length - 1) / FilePartSize) + 1;
				long file_id = Helpers.RandomLong();
				int file_part = 0, read;
				var tasks = new Dictionary<int, Task>();
				bool abort = false;
				for (long bytesLeft = length; !abort && bytesLeft != 0; file_part++)
				{
					var bytes = new byte[Math.Min(FilePartSize, bytesLeft)];
					read = await FullReadAsync(stream, bytes, bytes.Length);
					await _parallelTransfers.WaitAsync();
					var task = SavePart(file_part, bytes);
					lock (tasks) tasks[file_part] = task;
					if (!isBig)
						md5.TransformBlock(bytes, 0, read, null, 0);
					bytesLeft -= read;
					if (read < FilePartSize && bytesLeft != 0) throw new ApplicationException($"Failed to fully read stream ({read},{bytesLeft})");

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
							throw;
						}
						finally
						{
							_parallelTransfers.Release();
						}
					}
				}
				Task[] remainingTasks;
				lock (tasks) remainingTasks = tasks.Values.ToArray();
				await Task.WhenAll(remainingTasks); // wait completion and eventually propagate any task exception
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
			photoSize ??= photo.LargestPhotoSize;
			var fileLocation = photo.ToFileLocation(photoSize);
			return await DownloadFileAsync(fileLocation, outputStream, photo.dc_id, photoSize.FileSize);
		}

		/// <summary>Download given document from Telegram into the outputStream</summary>
		/// <param name="outputStream">stream to write to. This method does not close/dispose the stream</param>
		/// <param name="thumbSize">if specified, will download the given thumbnail instead of the full document</param>
		/// <returns>MIME type of the document or thumbnail</returns>
		public async Task<string> DownloadFileAsync(Document document, Stream outputStream, PhotoSizeBase thumbSize = null)
		{
			var fileLocation = document.ToFileLocation(thumbSize);
			var fileType = await DownloadFileAsync(fileLocation, outputStream, document.dc_id, thumbSize?.FileSize ?? document.size);
			return thumbSize == null ? document.mime_type : "image/" + fileType;
		}

		/// <summary>Download given file from Telegram into the outputStream</summary>
		/// <param name="fileLocation">Telegram file identifier, typically obtained with a .ToFileLocation() call</param>
		/// <param name="outputStream">stream to write to. This method does not close/dispose the stream</param>
		/// <param name="fileDC">(optional) DC on which the file is stored</param>
		/// <param name="fileSize">(optional) expected file size</param>
		public async Task<Storage_FileType> DownloadFileAsync(InputFileLocationBase fileLocation, Stream outputStream, int fileDC = 0, int fileSize = 0)
		{
			Storage_FileType fileType = Storage_FileType.unknown;
			var client = fileDC == 0 ? this : await GetClientForDC(fileDC, true);
			using var writeSem = new SemaphoreSlim(1);
			long streamStartPos = outputStream.Position;
			int fileOffset = 0, maxOffsetSeen = 0;
			var tasks = new Dictionary<int, Task>();
			bool abort = false;
			while (!abort)
			{
				await _parallelTransfers.WaitAsync();
				var task = LoadPart(fileOffset);
				lock (tasks) tasks[fileOffset] = task;
				if (fileDC == 0) { await task; fileDC = client._dcSession.DcID; }
				fileOffset += FilePartSize;
				if (fileSize != 0 && fileOffset >= fileSize)
				{
					if (await task != ((fileSize - 1) % FilePartSize) + 1)
						throw new ApplicationException("Downloaded file size does not match expected file size");
					break;
				}

				async Task<int> LoadPart(int offset)
				{
					Upload_FileBase fileBase;
					try
					{
						fileBase = await client.Upload_GetFile(fileLocation, offset, FilePartSize);
					}
					catch (RpcException ex) when (ex.Code == 303 && ex.Message.StartsWith("FILE_MIGRATE_"))
					{
						var dcId = int.Parse(ex.Message[13..]);
						client = await GetClientForDC(dcId, true);
						fileBase = await client.Upload_GetFile(fileLocation, offset, FilePartSize);
					}
					catch (RpcException ex) when (ex.Code == 400 && ex.Message == "OFFSET_INVALID")
					{
						abort = true;
						return 0;
					}
					catch (Exception)
					{
						abort = true;
						throw;
					}
					finally
					{
						_parallelTransfers.Release();
					}
					if (fileBase is not Upload_File fileData)
						throw new ApplicationException("Upload_GetFile returned unsupported " + fileBase.GetType().Name);
					if (fileData.bytes.Length != FilePartSize) abort = true;
					if (fileData.bytes.Length != 0)
					{
						fileType = fileData.type;
						await writeSem.WaitAsync();
						try
						{
							if (streamStartPos + offset != outputStream.Position) // if we're about to write out of order
							{
								await outputStream.FlushAsync(); // async flush, otherwise Seek would do a sync flush
								outputStream.Seek(streamStartPos + offset, SeekOrigin.Begin);
							}
							await outputStream.WriteAsync(fileData.bytes, 0, fileData.bytes.Length);
							maxOffsetSeen = Math.Max(maxOffsetSeen, offset + fileData.bytes.Length);
						}
						catch (Exception)
						{
							abort = true;
							throw;
						}
						finally
						{
							writeSem.Release();
						}
					}
					lock (tasks) tasks.Remove(offset);
					return fileData.bytes.Length;
				}
			}
			Task[] remainingTasks;
			lock (tasks) remainingTasks = tasks.Values.ToArray();
			await Task.WhenAll(remainingTasks); // wait completion and eventually propagate any task exception
			await outputStream.FlushAsync();
			outputStream.Seek(streamStartPos + maxOffsetSeen, SeekOrigin.Begin);
			return fileType;
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
