using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using TL;
using static WTelegram.Encryption;

// necessary for .NET Standard 2.0 compilation:
#pragma warning disable CA1835 // Prefer the 'Memory'-based overloads for 'ReadAsync' and 'WriteAsync'

namespace WTelegram
{
	public class Client : IDisposable
	{
		/// <summary>This event will be called when an unsollicited update/message is sent by Telegram servers</summary>
		/// <remarks>See <see href="https://github.com/wiz0u/WTelegramClient/tree/master/Examples/Program_ListenUpdate.cs">Examples/Program_ListenUpdate.cs</see> for how to use this</remarks>
		public event Action<IObject> Update;
		/// <summary>Used to create a TcpClient connected to the given address/port, or throw an exception on failure</summary>
		public TcpFactory TcpHandler { get; set; } = DefaultTcpHandler;
		public delegate Task<TcpClient> TcpFactory(string host, int port);
		/// <summary>Url for using a MTProxy. https://t.me/proxy?server=... </summary>
		public string MTProxyUrl { get; set; }
		/// <summary>Telegram configuration, obtained at connection time</summary>
		public Config TLConfig { get; private set; }
		/// <summary>Number of automatic reconnections on connection/reactor failure</summary>
		public int MaxAutoReconnects { get; set; } = 5;
		/// <summary>Number of seconds under which an error 420 FLOOD_WAIT_X will not be raised and your request will instead be auto-retried after the delay</summary>
		public int FloodRetryThreshold { get; set; } = 60;
		/// <summary>Number of seconds between each keep-alive ping. Increase this if you have a slow connection or you're debugging your code</summary>
		public int PingInterval { get; set; } = 60;
		/// <summary>Size of chunks when uploading/downloading files. Reduce this if you don't have much memory</summary>
		public int FilePartSize { get; set; } = 512 * 1024;
		/// <summary>Is this Client instance the main or a secondary DC session</summary>
		public bool IsMainDC => (_dcSession?.DataCenter?.id ?? 0) == _session.MainDC;
		/// <summary>Has this Client established connection been disconnected?</summary>
		public bool Disconnected => _tcpClient != null && !(_tcpClient.Client?.Connected ?? false);
		/// <summary>ID of the current logged-in user or 0</summary>
		public long UserId => _session.UserId;

		/// <summary>Used to indicate progression of file download/upload</summary>
		/// <param name="totalSize">total size of file in bytes, or 0 if unknown</param>
		public delegate void ProgressCallback(long transmitted, long totalSize);

		private readonly Func<string, string> _config;
		private readonly Session _session;
		private string _apiHash;
		private Session.DCSession _dcSession;
		private TcpClient _tcpClient;
		private Stream _networkStream;
		private IObject _lastSentMsg;
		private long _lastRecvMsgId;
		private readonly List<long> _msgsToAck = new();
		private readonly Random _random = new();
		private int _saltChangeCounter;
		private Task _reactorTask;
		private Rpc _bareRpc;
		private readonly Dictionary<long, Rpc> _pendingRpcs = new();
		private SemaphoreSlim _sendSemaphore = new(0);
		private readonly SemaphoreSlim _semaphore = new(1);
		private Task _connecting;
		private CancellationTokenSource _cts;
		private int _reactorReconnects = 0;
		private const string ConnectionShutDown = "Could not read payload length : Connection shut down";
		private readonly SemaphoreSlim _parallelTransfers = new(10); // max parallel part uploads/downloads
		private readonly SHA256 _sha256 = SHA256.Create();
		private readonly SHA256 _sha256Recv = SHA256.Create();
#if OBFUSCATION
		private AesCtr _sendCtr, _recvCtr;
#endif
		private bool _paddedMode;

		/// <summary>Welcome to WTelegramClient! 🙂</summary>
		/// <param name="configProvider">Config callback, is queried for: <b>api_id</b>, <b>api_hash</b>, <b>session_pathname</b></param>
		/// <param name="sessionStore">if specified, must support initial Length &amp; Read() of a session, then calls to Write() the updated session. Other calls can be ignored</param>
		public Client(Func<string, string> configProvider = null, Stream sessionStore = null)
		{
			_config = configProvider ?? DefaultConfigOrAsk;
			sessionStore ??= new SessionStore(Config("session_pathname"));
			var session_key = _config("session_key") ?? (_apiHash = Config("api_hash"));
			_session = Session.LoadOrCreate(sessionStore, Convert.FromHexString(session_key));
			if (_session.ApiId == 0) _session.ApiId = int.Parse(Config("api_id"));
			if (_session.MainDC != 0) _session.DCSessions.TryGetValue(_session.MainDC, out _dcSession);
			_dcSession ??= new() { Id = Helpers.RandomLong() };
			_dcSession.Client = this;
			var version = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
			Helpers.Log(1, $"WTelegramClient {version[..version.IndexOf('+')]} running under {System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription}");
		}

		private Client(Client cloneOf, Session.DCSession dcSession)
		{
			_config = cloneOf._config;
			_session = cloneOf._session;
			TcpHandler = cloneOf.TcpHandler;
			MTProxyUrl = cloneOf.MTProxyUrl;
			PingInterval = cloneOf.PingInterval;
			_dcSession = dcSession;
		}

		internal Task<string> ConfigAsync(string what) => Task.Run(() => Config(what));
		internal string Config(string what)
			=> _config(what) ?? DefaultConfig(what) ?? throw new ApplicationException("You must provide a config value for " + what);

		/// <summary>Default config values, used if your Config callback returns <see langword="null"/></summary>
		public static string DefaultConfig(string what) => what switch
		{
			"session_pathname" => Path.Combine(
				Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory.TrimEnd(Path.DirectorySeparatorChar)))
				?? AppDomain.CurrentDomain.BaseDirectory, "WTelegram.session"),
#if DEBUG
			"server_address" => "149.154.167.40:443",	// Test DC 2
#else
			"server_address" => "149.154.167.50:443",	// DC 2
#endif
			"device_model" => Environment.Is64BitOperatingSystem ? "PC 64bit" : "PC 32bit",
			"system_version" => Helpers.GetSystemVersion(),
			"app_version" => Helpers.GetAppVersion(),
			"system_lang_code" => CultureInfo.InstalledUICulture.TwoLetterISOLanguageName,
			"lang_pack" => "",
			"lang_code" => CultureInfo.CurrentUICulture.TwoLetterISOLanguageName,
			"user_id" => "-1",
			"verification_code" or "password" => AskConfig(what),
			_ => null // api_id api_hash phone_number... it's up to you to reply to these correctly
		};

		internal static string DefaultConfigOrAsk(string config) => DefaultConfig(config) ?? AskConfig(config);

		private static string AskConfig(string config)
		{
			if (config == "session_key")
			{
				Console.WriteLine("Welcome! You can obtain your api_id/api_hash at https://my.telegram.org/apps");
				return null;
			}
			Console.Write($"Enter {config.Replace('_', ' ')}: ");
			return Console.ReadLine();
		}

		/// <summary>Load a specific Telegram server public key</summary>
		/// <param name="pem">A string starting with <c>-----BEGIN RSA PUBLIC KEY-----</c></param>
		public static void LoadPublicKey(string pem) => Encryption.LoadPublicKey(pem);

		/// <summary>Builds a structure that is used to validate a 2FA password</summary>
		/// <param name="accountPassword">Password validation configuration. You can obtain this though an Update event as part of the login process</param>
		/// <param name="password">The password to validate</param>
		public static Task<InputCheckPasswordSRP> InputCheckPassword(Account_Password accountPassword, string password)
			=> Check2FA(accountPassword, () => Task.FromResult(password));

		public void Dispose()
		{
			Helpers.Log(2, $"{_dcSession.DcID}>Disposing the client");
			Reset(false, IsMainDC);
			_networkStream = null;
			if (IsMainDC) _session.Dispose();
			GC.SuppressFinalize(this);
		}

		/// <summary>Disconnect from Telegram <i>(shouldn't be needed in normal usage)</i></summary>
		/// <param name="resetUser">Forget about logged-in user</param>
		/// <param name="resetSessions">Disconnect secondary sessions with other DCs</param>
		public void Reset(bool resetUser = true, bool resetSessions = true)
		{
			try
			{
				if (CheckMsgsToAck() is MsgsAck msgsAck)
					SendAsync(msgsAck, false).Wait(1000);
			}
			catch (Exception)
			{
			}
			_cts?.Cancel();
			_sendSemaphore = new(0);	// initially taken, first released during DoConnectAsync
			_reactorTask = null;
			_networkStream?.Close();
			_tcpClient?.Dispose();
#if OBFUSCATION
			_sendCtr?.Dispose();
			_recvCtr?.Dispose();
#endif
			_paddedMode = false;
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
				_session.UserId = 0;
		}

		/// <summary>Establish connection to Telegram servers</summary>
		/// <remarks>Config callback is queried for: <b>server_address</b></remarks>
		/// <returns>Most methods of this class are async (Task), so please use <see langword="await"/></returns>
		public async Task ConnectAsync()
		{
			lock (this)
				_connecting ??= DoConnectAsync();
			await _connecting;
		}

		static async Task<TcpClient> DefaultTcpHandler(string host, int port)
		{
			var tcpClient = new TcpClient();
			try
			{
				await tcpClient.ConnectAsync(host, port);
			}
			catch (Exception)
			{
				tcpClient.Dispose();
				throw;
			}
			return tcpClient;
		}

		private async Task DoConnectAsync()
		{
			_cts = new();
			IPEndPoint endpoint = null;
			byte[] preamble, secret = null;
			int dcId = _dcSession?.DcID ?? 0;
			if (dcId == 0) dcId = 2;
			if (MTProxyUrl != null)
			{
#if OBFUSCATION
				if (!IsMainDC) dcId = -dcId;
				var parms = HttpUtility.ParseQueryString(MTProxyUrl[MTProxyUrl.IndexOf('?')..]);
				var server = parms["server"];
				int port = int.Parse(parms["port"]);
				var str = parms["secret"]; // can be hex or base64
				var secretBytes = secret = str.All("0123456789ABCDEFabcdef".Contains) ? Convert.FromHexString(str) :
					System.Convert.FromBase64String(str.Replace('_', '/').Replace('-', '+') + new string('=', (2147483644 - str.Length) % 4));
				var tlsMode = secret.Length >= 21 && secret[0] == 0xEE;
				if (tlsMode || (secret.Length == 17 && secret[0] == 0xDD))
				{
					_paddedMode = true;
					secret = secret[1..17];
				}
				else if (secret.Length != 16) throw new ArgumentException("Invalid/unsupported secret", nameof(secret));
				Helpers.Log(2, $"Connecting to DC {dcId} via MTProxy {server}:{port}...");
				_tcpClient = await TcpHandler(server, port);
				_networkStream = _tcpClient.GetStream();
				if (tlsMode)
					_networkStream = await TlsStream.HandshakeAsync(_networkStream, secret, secretBytes[17..], _cts.Token);
#else
				throw new Exception("Library was not compiled with OBFUSCATION symbol");
#endif
			}
			else
			{
				endpoint = _dcSession?.EndPoint ?? Compat.IPEndPoint_Parse(Config("server_address"));
				Helpers.Log(2, $"Connecting to {endpoint}...");
				TcpClient tcpClient = null;
				try
				{
					try
					{
						tcpClient = await TcpHandler(endpoint.Address.ToString(), endpoint.Port);
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
									tcpClient = await TcpHandler(endpoint.Address.ToString(), endpoint.Port);
									_dcSession.DataCenter = dcOption;
									break;
								}
								catch (SocketException) { }
							}
						}
						if (tcpClient == null)
						{
							endpoint = Compat.IPEndPoint_Parse(Config("server_address")); // re-ask callback for an address
							if (!triedEndpoints.Add(endpoint)) throw;
							_dcSession.Client = null;
							// is it address for a known DCSession?
							_dcSession = _session.DCSessions.Values.FirstOrDefault(dcs => dcs.EndPoint.Equals(endpoint));
							_dcSession ??= new() { Id = Helpers.RandomLong() };
							_dcSession.Client = this;
							Helpers.Log(2, $"Connecting to {endpoint}...");
							tcpClient = await TcpHandler(endpoint.Address.ToString(), endpoint.Port);
						}
					}
				}
				catch (Exception)
				{
					tcpClient?.Dispose();
					throw;
				}
				_tcpClient = tcpClient;
				_networkStream = _tcpClient.GetStream();
			}

			byte protocolId = (byte)(_paddedMode ? 0xDD : 0xEE);
#if OBFUSCATION
			(_sendCtr, _recvCtr, preamble) = InitObfuscation(secret, protocolId, dcId);
#else
			preamble = new byte[] { protocolId, protocolId, protocolId, protocolId };
#endif
			await _networkStream.WriteAsync(preamble, 0, preamble.Length, _cts.Token);

			_saltChangeCounter = 0;
			_reactorTask = Reactor(_networkStream, _cts);
			_sendSemaphore.Release();

			try
			{
				if (_dcSession.AuthKeyID == 0)
					await CreateAuthorizationKey(this, _dcSession);

				var keepAliveTask = KeepAlive(_cts.Token);
				TLConfig = await this.InvokeWithLayer(Layer.Version,
					new TL.Methods.InitConnection<Config>
					{
						api_id = _session.ApiId,
						device_model = Config("device_model"),
						system_version = Config("system_version"),
						app_version = Config("app_version"),
						system_lang_code = Config("system_lang_code"),
						lang_pack = Config("lang_pack"),
						lang_code = Config("lang_code"),
						query = new TL.Methods.Help_GetConfig()
					});
				_session.DcOptions = TLConfig.dc_options;
				_saltChangeCounter = 0;
				if (_dcSession.DataCenter == null)
				{
					_dcSession.DataCenter = _session.DcOptions.Where(dc => dc.id == TLConfig.this_dc)
						.OrderByDescending(dc => dc.ip_address == endpoint?.Address.ToString())
						.ThenByDescending(dc => dc.port == endpoint?.Port)
						.ThenByDescending(dc => dc.flags == (endpoint?.AddressFamily == AddressFamily.InterNetworkV6 ? DcOption.Flags.ipv6 : 0))
						.First();
					_session.DCSessions[TLConfig.this_dc] = _dcSession;
				}
				if (_session.MainDC == 0) _session.MainDC = TLConfig.this_dc;
			}
			finally
			{
				lock (_session) _session.Save();
			}
			Helpers.Log(2, $"Connected to {(TLConfig.test_mode ? "Test DC" : "DC")} {TLConfig.this_dc}... {TLConfig.flags & (Config.Flags)~0xE00U}");
		}

		/// <summary>Obtain/create a Client for a secondary session on a specific Data Center</summary>
		/// <param name="dcId">ID of the Data Center</param>
		/// <param name="media_only">Session will be used only for transferring media</param>
		/// <param name="connect">Connect immediately</param>
		/// <returns></returns>
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
					if (_session.UserId != 0 && IsMainDC && altSession.UserId != _session.UserId)
						exported = await this.Auth_ExportAuthorization(dcId);
					await altSession.Client.ConnectAsync();
					if (exported != null)
					{
						var authorization = await altSession.Client.Auth_ImportAuthorization(exported.id, exported.bytes);
						if (authorization is not Auth_Authorization { user: User user })
							throw new ApplicationException("Failed to get Authorization: " + authorization.GetType().Name);
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
			if ((dcSession?.AuthKeyID ?? 0) == 0) // we will need to negociate an AuthKey => can't use media_only DC
				flags &= ~DcOption.Flags.media_only;
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
				await Task.Delay(Math.Abs(PingInterval) * 1000, ct);
				if (_saltChangeCounter > 0) --_saltChangeCounter;
				if (PingInterval <= 0)
					await this.Ping(ping_id++);
				else // see https://core.telegram.org/api/optimisation#grouping-updates
#if DEBUG
					await this.PingDelayDisconnect(ping_id++, PingInterval * 5);
#else
					await this.PingDelayDisconnect(ping_id++, PingInterval * 5 / 4);
#endif
			}
		}

		private async Task Reactor(Stream stream, CancellationTokenSource cts)
		{
			const int MinBufferSize = 1024;
			var data = new byte[MinBufferSize];
			while (!cts.IsCancellationRequested)
			{
				IObject obj = null;
				try
				{
					if (await stream.FullReadAsync(data, 4, cts.Token) != 4)
						throw new ApplicationException(ConnectionShutDown);
#if OBFUSCATION
					_recvCtr.EncryptDecrypt(data, 4);
#endif
					int payloadLen = BinaryPrimitives.ReadInt32LittleEndian(data);
					if (payloadLen <= 0)
						throw new ApplicationException("Could not read frame data : Invalid payload length");
					else if (payloadLen > data.Length)
						data = new byte[payloadLen];
					else if (Math.Max(payloadLen, MinBufferSize) < data.Length / 4)
						data = new byte[Math.Max(payloadLen, MinBufferSize)];
					if (await stream.FullReadAsync(data, payloadLen, cts.Token) != payloadLen)
						throw new ApplicationException("Could not read frame data : Connection shut down");
#if OBFUSCATION
					_recvCtr.EncryptDecrypt(data, payloadLen);
#endif
					obj = ReadFrame(data, payloadLen);
				}
				catch (Exception ex) // an exception in RecvAsync is always fatal
				{
					if (cts.IsCancellationRequested) return;
					Helpers.Log(5, $"{_dcSession.DcID}>An exception occured in the reactor: {ex}");
					var oldSemaphore = _sendSemaphore;
					await oldSemaphore.WaitAsync(cts.Token); // prevent any sending while we reconnect
					var reactorError = new ReactorError { Exception = ex };
					try
					{
						lock (_msgsToAck) _msgsToAck.Clear();
						Reset(false, false);
						_reactorReconnects = (_reactorReconnects + 1) % MaxAutoReconnects;
						if (!IsMainDC && _pendingRpcs.Count <= 1 && ex is ApplicationException { Message: ConnectionShutDown } or IOException { InnerException: SocketException })
							if (_pendingRpcs.Values.FirstOrDefault() is not Rpc rpc || rpc.type == typeof(Pong))
								_reactorReconnects = 0;
						if (_reactorReconnects != 0)
						{
							await Task.Delay(5000);
							if (_networkStream == null) return; // Dispose has been called in-between
							await ConnectAsync(); // start a new reactor after 5 secs
							lock (_pendingRpcs) // retry all pending requests
							{
								foreach (var rpc in _pendingRpcs.Values)
									rpc.tcs.SetResult(reactorError);
								_pendingRpcs.Clear();
								_bareRpc = null;
							}
							// TODO: implement an Updates gaps handling system? https://core.telegram.org/api/updates
							if (IsMainDC)
							{
								var udpatesState = await this.Updates_GetState(); // this call reenables incoming Updates
								OnUpdate(udpatesState);
							}
						}
						else
							throw;
					}
					catch
					{
						lock (_pendingRpcs) // abort all pending requests
						{
							foreach (var rpc in _pendingRpcs.Values)
								rpc.tcs.SetException(ex);
							_pendingRpcs.Clear();
							_bareRpc = null;
						}
						OnUpdate(reactorError);
					}
					finally
					{
						oldSemaphore.Release();
					}
				}
				if (obj != null)
					await HandleMessageAsync(obj);
			}
		}

		internal IObject ReadFrame(byte[] data, int dataLen)
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
				dataLen -= 20;
				if (length > dataLen || length < dataLen - (_paddedMode ? 15 : 0))
					throw new ApplicationException($"Unexpected unencrypted length {length} != {dataLen}");

				var obj = reader.ReadTLObject();
				Helpers.Log(1, $"{_dcSession.DcID}>Receiving {obj.GetType().Name,-40} {MsgIdToStamp(msgId):u} clear{((msgId & 2) == 0 ? "" : " NAR")}");
				return obj;
			}
			else
			{
				byte[] decrypted_data = EncryptDecryptMessage(data.AsSpan(24, (dataLen - 24) & ~0xF), false, _dcSession.AuthKey, data, 8, _sha256Recv);
				if (decrypted_data.Length < 36) // header below+ctorNb
					throw new ApplicationException($"Decrypted packet too small: {decrypted_data.Length}");
				using var reader = new TL.BinaryReader(new MemoryStream(decrypted_data), this);
				var serverSalt = reader.ReadInt64();    // int64 salt
				var sessionId = reader.ReadInt64();     // int64 session_id
				var msgId = reader.ReadInt64();         // int64 message_id
				var seqno = reader.ReadInt32();         // int32 msg_seqno
				var length = reader.ReadInt32();        // int32 message_data_length
				if (_lastRecvMsgId == 0) // resync ServerTicksOffset on first message
					_dcSession.ServerTicksOffset = (msgId >> 32) * 10000000 - DateTime.UtcNow.Ticks + 621355968000000000L;
				var msgStamp = MsgIdToStamp(_lastRecvMsgId = msgId);

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
				if (decrypted_data.Length - 32 - length is < 12 or > 1024) throw new ApplicationException($"Unexpected decrypted message_data_length {length} / {decrypted_data.Length - 32}");
				_sha256Recv.TransformBlock(_dcSession.AuthKey, 96, 32, null, 0);
				_sha256Recv.TransformFinalBlock(decrypted_data, 0, decrypted_data.Length);
				if (!data.AsSpan(8, 16).SequenceEqual(_sha256Recv.Hash.AsSpan(8, 16)))
					throw new ApplicationException($"Mismatch between MsgKey & decrypted SHA256");
				_sha256Recv.Initialize();

				var ctorNb = reader.ReadUInt32();
				if (ctorNb != Layer.BadMsgCtor && (msgStamp - DateTime.UtcNow).Ticks / TimeSpan.TicksPerSecond is > 30 or < -300)
				{	// msg_id values that belong over 30 seconds in the future or over 300 seconds in the past are to be ignored.
					Helpers.Log(1, $"{_dcSession.DcID}>Ignoring  0x{ctorNb:X8} because of wrong timestamp    {msgStamp:u} (svc)");
					return null;
				}
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
				_ => Enum.GetName(typeof(HttpStatusCode), error_code) ?? "Transport error"
			};
		}

		private async Task SendAsync(IObject msg, bool isContent, Rpc rpc = null)
		{
			isContent &= _dcSession.AuthKeyID != 0;
			(long msgId, int seqno) = NewMsgId(isContent);
			if (rpc != null)
				lock (_pendingRpcs)
					_pendingRpcs[rpc.msgId = msgId] = rpc;
			if (isContent && CheckMsgsToAck() is MsgsAck msgsAck)
			{
				var (ackId, ackSeqno) = NewMsgId(false);
				var container = new MsgContainer { messages = new _Message[] { new(msgId, seqno, msg), new(ackId, ackSeqno, msgsAck) } };
				await SendAsync(container, false);
				return;
			}
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
					Helpers.Log(1, $"{_dcSession.DcID}>Sending   {msg.GetType().Name.TrimEnd('_')}...");
					writer.WriteTLObject(msg);				// bytes message_data
					BinaryPrimitives.WriteInt32LittleEndian(memStream.GetBuffer().AsSpan(20), (int)memStream.Length - 24);    // patch message_data_length
				}
				else
				{
					using var clearStream = new MemoryStream(1024);
					using var clearWriter = new BinaryWriter(clearStream, Encoding.UTF8);
					clearWriter.Write(_dcSession.AuthKey, 88, 32);
					clearWriter.Write(_dcSession.Salt);		// int64 salt
					clearWriter.Write(_dcSession.Id);		// int64 session_id
					clearWriter.Write(msgId);				// int64 message_id
					clearWriter.Write(seqno);				// int32 msg_seqno
					clearWriter.Write(0);					// int32 message_data_length (to be patched)
					if ((seqno & 1) != 0)
						Helpers.Log(1, $"{_dcSession.DcID}>Sending   {msg.GetType().Name.TrimEnd('_'),-40} #{(short)msgId.GetHashCode():X4}");
					else
						Helpers.Log(1, $"{_dcSession.DcID}>Sending   {msg.GetType().Name.TrimEnd('_'),-40} {MsgIdToStamp(msgId):u} (svc)");
					clearWriter.WriteTLObject(msg);			// bytes message_data
					int clearLength = (int)clearStream.Length - 32;  // length before padding (= 32 + message_data_length)
					int padding = (0x7FFFFFF0 - clearLength) % 16;
					padding += _random.Next(1, 64) * 16;		// MTProto 2.0 padding must be between 12..1024 with total length divisible by 16
					clearStream.SetLength(32 + clearLength + padding);
					byte[] clearBuffer = clearStream.GetBuffer();
					BinaryPrimitives.WriteInt32LittleEndian(clearBuffer.AsSpan(60), clearLength - 32);    // patch message_data_length
					RNG.GetBytes(clearBuffer, 32 + clearLength, padding);
					var msgKeyLarge = _sha256.ComputeHash(clearBuffer, 0, 32 + clearLength + padding);
					const int msgKeyOffset = 8; // msg_key = middle 128-bits of SHA256(authkey_part+plaintext+padding)
					byte[] encrypted_data = EncryptDecryptMessage(clearBuffer.AsSpan(32, clearLength + padding), true, _dcSession.AuthKey, msgKeyLarge, msgKeyOffset, _sha256);

					writer.Write(_dcSession.AuthKeyID);				// int64 auth_key_id
					writer.Write(msgKeyLarge, msgKeyOffset, 16);	// int128 msg_key
					writer.Write(encrypted_data);					// bytes encrypted_data
				}
				if (_paddedMode) // Padded intermediate mode => append random padding
				{
					var padding = new byte[_random.Next(16)];
					RNG.GetBytes(padding);
					writer.Write(padding);
				}
				var buffer = memStream.GetBuffer();
				int frameLength = (int)memStream.Length;
				BinaryPrimitives.WriteInt32LittleEndian(buffer, frameLength - 4); // patch payload_len with correct value
#if OBFUSCATION
				_sendCtr.EncryptDecrypt(buffer, frameLength);
#endif
				await _networkStream.WriteAsync(buffer, 0, frameLength);
				_lastSentMsg = msg;
			}
			finally
			{
				_sendSemaphore.Release();
			}
		}

		internal MsgContainer ReadMsgContainer(TL.BinaryReader reader)
		{
			int count = reader.ReadInt32();
			var array = new _Message[count];
			for (int i = 0; i < count; i++)
			{
				var msg = array[i] = new _Message(reader.ReadInt64(), reader.ReadInt32(), null) { bytes = reader.ReadInt32() };
				if ((msg.seqno & 1) != 0) lock (_msgsToAck) _msgsToAck.Add(msg.msg_id);
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
			var rpc = PullPendingRequest(msgId);
			object result;
			if (rpc != null)
			{
				try
				{
					if (!rpc.type.IsArray)
						result = reader.ReadTLValue(rpc.type);
					else
					{
						var peek = reader.ReadUInt32();
						if (peek == Layer.RpcErrorCtor)
							result = reader.ReadTLObject(Layer.RpcErrorCtor);
						else if (peek == Layer.GZipedCtor)
							using (var gzipReader = new TL.BinaryReader(new GZipStream(new MemoryStream(reader.ReadTLBytes()), CompressionMode.Decompress), reader.Client))
								result = gzipReader.ReadTLValue(rpc.type);
						else
						{
							reader.BaseStream.Position -= 4;
							result = reader.ReadTLValue(rpc.type);
						}
					}
					if (rpc.type.IsEnum) result = Enum.ToObject(rpc.type, result);
					if (result is RpcError rpcError)
						Helpers.Log(4, $"             → RpcError {rpcError.error_code,3} {rpcError.error_message,-24} #{(short)msgId.GetHashCode():X4}");
					else
						Helpers.Log(1, $"             → {result?.GetType().Name,-37} #{(short)msgId.GetHashCode():X4}");
					rpc.tcs.SetResult(result);
				}
				catch (Exception ex)
				{
					rpc.tcs.SetException(ex);
					throw;
				}
			}
			else
			{
				var ctorNb = reader.ReadUInt32();
				if (ctorNb == Layer.VectorCtor)
				{
					reader.BaseStream.Position -= 4;
					result = reader.ReadTLVector(typeof(IObject[]));
				}
				else if (ctorNb == (uint)Bool.False) result = false;
				else if (ctorNb == (uint)Bool.True) result = true;
				else result = reader.ReadTLObject(ctorNb);
				var typeName = result?.GetType().Name;
				if (MsgIdToStamp(msgId) >= _session.SessionStart)
					Helpers.Log(4, $"             → {typeName,-37} for unknown msgId #{(short)msgId.GetHashCode():X4}");
				else
					Helpers.Log(1, $"             → {typeName,-37} for past msgId #{(short)msgId.GetHashCode():X4}");
			}
			return new RpcResult { req_msg_id = msgId, result = result };
		}

		class Rpc
		{
			public Type type;
			public TaskCompletionSource<object> tcs = new(TaskCreationOptions.RunContinuationsAsynchronously);
			public long msgId;
			public Task<object> Task => tcs.Task;
		}

		private Rpc PullPendingRequest(long msgId)
		{
			Rpc request;
			lock (_pendingRpcs)
				if (_pendingRpcs.TryGetValue(msgId, out request))
					_pendingRpcs.Remove(msgId);
			return request;
		}

		internal async Task<X> InvokeBare<X>(IMethod<X> request)
		{
			if (_bareRpc != null) throw new ApplicationException("A bare request is already undergoing");
			_bareRpc = new Rpc { type = typeof(X) };
			await SendAsync(request, false, _bareRpc);
			return (X)await _bareRpc.Task;
		}

		/// <summary>Call the given TL method <i>(You shouldn't need to use this method directly)</i></summary>
		/// <typeparam name="X">Expected type of the returned object</typeparam>
		/// <param name="query">TL method structure</param>
		/// <returns>Wait for the reply and return the resulting object, or throws an RpcException if an error was replied</returns>
		public async Task<X> Invoke<X>(IMethod<X> query)
		{
		retry:
			var rpc = new Rpc { type = typeof(X) };
			await SendAsync(query, true, rpc);
			bool got503 = false;
			var result = await rpc.Task;
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
						if (number <= FloodRetryThreshold)
						{
							await Task.Delay(number * 1000);
							goto retry;
						}
					}
					else if (rpcError.error_code == -503 && !got503)
					{
						got503 = true;
						goto retry;
					}
					else if (rpcError.error_code == 500 && rpcError.error_message == "AUTH_RESTART")
					{
						_session.UserId = 0; // force a full login authorization flow, next time
						lock (_session) _session.Save();
					}
					throw new RpcException(rpcError.error_code, rpcError.error_message);
				case ReactorError:
					goto retry;
				default:
					throw new ApplicationException($"{query.GetType().Name} call got a result of type {result.GetType().Name} instead of {typeof(X).Name}");
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

		private async Task HandleMessageAsync(IObject obj)
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
				case TL.Methods.Ping ping:
					_ = SendAsync(new Pong { msg_id = _lastRecvMsgId, ping_id = ping.ping_id }, false);
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
					await _sendSemaphore.WaitAsync();
					bool retryLast = badMsgNotification.bad_msg_id == _dcSession.LastSentMsgId;
					var lastSentMsg = _lastSentMsg;
					_sendSemaphore.Release();
					var logLevel = badMsgNotification.error_code == 48 ? 2 : 4;
					Helpers.Log(logLevel, $"BadMsgNotification {badMsgNotification.error_code} for msg #{(short)badMsgNotification.bad_msg_id.GetHashCode():X4}");
					switch (badMsgNotification.error_code)
					{
						case 16: // msg_id too low (most likely, client time is wrong; synchronize it using msg_id notifications and re-send the original message)
						case 17: // msg_id too high (similar to the previous case, the client time has to be synchronized, and the message re-sent with the correct msg_id)
							_dcSession.LastSentMsgId = 0;
							var localTime = DateTime.UtcNow;
							_dcSession.ServerTicksOffset = (_lastRecvMsgId >> 32) * 10000000 - localTime.Ticks + 621355968000000000L;
							Helpers.Log(1, $"Time offset: {_dcSession.ServerTicksOffset} | Server: {MsgIdToStamp(_lastRecvMsgId).AddTicks(_dcSession.ServerTicksOffset).TimeOfDay} UTC | Local: {localTime.TimeOfDay} UTC");
							break;
						case 32: // msg_seqno too low (the server has already received a message with a lower msg_id but with either a higher or an equal and odd seqno)
						case 33: // msg_seqno too high (similarly, there is a message with a higher msg_id but with either a lower or an equal and odd seqno)
							if (_dcSession.Seqno <= 1)
								retryLast = false;
							else
							{
								Reset(false, false);
								_dcSession.Renew();
								await ConnectAsync();
							}
							break;
						case 48: // incorrect server salt (in this case, the bad_server_salt response is received with the correct salt, and the message is to be re-sent with it)
							_dcSession.Salt = ((BadServerSalt)badMsgNotification).new_server_salt;
							break;
						default:
							retryLast = false;
							break;
					}
					if (retryLast)
					{
						Rpc prevRequest;
						lock (_pendingRpcs)
							_pendingRpcs.TryGetValue(badMsgNotification.bad_msg_id, out prevRequest);
						await SendAsync(lastSentMsg, true, prevRequest);
						lock (_pendingRpcs)
							_pendingRpcs.Remove(badMsgNotification.bad_msg_id);
					}
					else if (PullPendingRequest(badMsgNotification.bad_msg_id) is Rpc rpc)
					{
						if (_bareRpc.msgId == badMsgNotification.bad_msg_id) _bareRpc = null;
						rpc.tcs.SetException(new ApplicationException($"BadMsgNotification {badMsgNotification.error_code}"));
					}
					else
						OnUpdate(obj);
					break;
				default:
					if (_bareRpc != null)
					{
						var rpc = PullPendingRequest(_bareRpc.msgId);
						if (rpc?.type.IsAssignableFrom(obj.GetType()) == true)
						{
							_bareRpc = null;
							rpc.tcs.SetResult(obj);
							break;
						}
					}
					OnUpdate(obj);
					break;
			}

			void SetResult(long msgId, object result)
			{
				var rpc = PullPendingRequest(msgId);
				if (rpc != null)
					rpc.tcs.SetResult(result);
				else
					OnUpdate(obj);
			}
		}

		private void OnUpdate(IObject obj)
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

		/// <summary>Login as a bot (if not already logged-in).</summary>
		/// <remarks>Config callback is queried for: <b>bot_token</b>
		/// <br/>Bots can only call API methods marked with [bots: ✓] in their documentation. </remarks>
		/// <returns>Detail about the logged-in bot</returns>
		public async Task<User> LoginBotIfNeeded()
		{
			await ConnectAsync();
			string botToken = Config("bot_token");
			if (_session.UserId != 0) // a user is already logged-in
			{
				try
				{
					var users = await this.Users_GetUsers(new[] { InputUser.Self }); // this calls also reenable incoming Updates
					var self = users[0] as User;
					if (self.id == long.Parse(botToken.Split(':')[0]))
					{
						_session.UserId = _dcSession.UserId = self.id;
						return self;
					}
					Helpers.Log(3, $"Current logged user {self.id} mismatched bot_token. Logging out and in...");
				}
				catch (Exception ex)
				{
					Helpers.Log(4, $"Error while verifying current bot! ({ex.Message}) Proceeding to login...");
				}
				await this.Auth_LogOut();
				_session.UserId = _dcSession.UserId = 0;
			}
			var authorization = await this.Auth_ImportBotAuthorization(0, _session.ApiId, _apiHash ??= Config("api_hash"), botToken);
			return LoginAlreadyDone(authorization);
		}

		/// <summary>Login as a user (if not already logged-in).
		/// <br/><i>(this method calls ConnectAsync if necessary)</i></summary>
		/// <remarks>Config callback is queried for: <b>phone_number</b>, <b>verification_code</b> <br/>and eventually <b>first_name</b>, <b>last_name</b> (signup required), <b>password</b> (2FA auth), <b>user_id</b> (alt validation)</remarks>
		/// <param name="settings">(optional) Preference for verification_code sending</param>
		/// <returns>Detail about the logged-in user
		/// <br/>Most methods of this class are async (Task), so please use <see langword="await"/> to get the result</returns>
		public async Task<User> LoginUserIfNeeded(CodeSettings settings = null)
		{
			await ConnectAsync();
			string phone_number = null;
			if (_session.UserId != 0) // a user is already logged-in
			{
				try
				{
					var users = await this.Users_GetUsers(new[] { InputUser.Self }); // this calls also reenable incoming Updates
					var self = users[0] as User;
					// check user_id or phone_number match currently logged-in user
					if ((long.TryParse(_config("user_id"), out long id) && (id == -1 || self.id == id)) ||
						self.phone == string.Concat((phone_number = Config("phone_number")).Where(char.IsDigit)))
					{
						_session.UserId = _dcSession.UserId = self.id;
						return self;
					}
					Helpers.Log(3, $"Current logged user {self.id} mismatched user_id or phone_number. Logging out and in...");
				}
				catch (Exception ex)
				{
					Helpers.Log(4, $"Error while verifying current user! ({ex.Message}) Proceeding to login...");
				}
				await this.Auth_LogOut();
				_session.UserId = _dcSession.UserId = 0;
			}
			phone_number ??= Config("phone_number");
			Auth_SentCode sentCode;
			try
			{
				sentCode = await this.Auth_SendCode(phone_number, _session.ApiId, _apiHash ??= Config("api_hash"), settings ??= new());
			}
			catch (RpcException ex) when (ex.Code == 500 && ex.Message == "AUTH_RESTART")
			{
				sentCode = await this.Auth_SendCode(phone_number, _session.ApiId, _apiHash, settings);
			}
		resent:
			var timeout = DateTime.UtcNow + TimeSpan.FromSeconds(sentCode.timeout);
			OnUpdate(sentCode);
			Helpers.Log(3, $"A verification code has been sent via {sentCode.type.GetType().Name[17..]}");
			Auth_AuthorizationBase authorization = null;
			for (int retry = 1; authorization == null; retry++)
				try
				{
					var verification_code = await ConfigAsync("verification_code");
					if (verification_code == "" && sentCode.next_type != 0)
					{
						var mustWait = timeout - DateTime.UtcNow;
						if (mustWait.Ticks > 0)
						{
							Helpers.Log(3, $"You must wait {(int)(mustWait.TotalSeconds + 0.5)} more seconds before requesting the code to be sent via {sentCode.next_type}");
							continue;
						}
						sentCode = await this.Auth_ResendCode(phone_number, sentCode.phone_code_hash);
						goto resent;
					}
					authorization = await this.Auth_SignIn(phone_number, sentCode.phone_code_hash, verification_code);
				}
				catch (RpcException e) when (e.Code == 401 && e.Message == "SESSION_PASSWORD_NEEDED")
				{
					var accountPassword = await this.Account_GetPassword();
					OnUpdate(accountPassword);
					var checkPasswordSRP = await Check2FA(accountPassword, () => ConfigAsync("password"));
					authorization = await this.Auth_CheckPassword(checkPasswordSRP);
				}
				catch (RpcException e) when (e.Code == 400 && e.Message == "PHONE_CODE_INVALID" && retry != 3)
				{
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
			return LoginAlreadyDone(authorization);
		}

		/// <summary><b>[Not recommended]</b> You can use this if you have already obtained a login authorization manually</summary>
		/// <param name="authorization">if this was not a successful Auth_Authorization, an exception is thrown</param>
		/// <returns>the User that was authorized</returns>
		/// <remarks>This approach is not recommended because you likely didn't properly handle all aspects of the login process
		/// <br/>(transient failures, unnecessary login, 2FA, sign-up required, slowness to respond, verification code resending, encryption key safety, etc..)
		/// <br/>Methods <c>LoginUserIfNeeded</c> and <c>LoginBotIfNeeded</c> handle these automatically for you</remarks>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public User LoginAlreadyDone(Auth_AuthorizationBase authorization)
		{
			if (authorization is not Auth_Authorization { user: User user })
				throw new ApplicationException("Failed to get Authorization: " + authorization.GetType().Name);
			_session.UserId = _dcSession.UserId = user.id;
			lock (_session) _session.Save();
			return user;
		}

		/// <summary>Enable the collection of id/access_hash pairs (experimental)</summary>
		public bool CollectAccessHash { get; set; }
		readonly Dictionary<Type, Dictionary<long, long>> _accessHashes = new();
		public IEnumerable<KeyValuePair<long, long>> AllAccessHashesFor<T>() where T : IObject
			=> _accessHashes.GetValueOrDefault(typeof(T));
		/// <summary>Retrieve the access_hash associated with this id (for a TL class) if it was collected</summary>
		/// <remarks>This requires <see cref="CollectAccessHash"/> to be set to <see langword="true"/> first.
		/// <br/>See <see href="https://github.com/wiz0u/WTelegramClient/tree/master/Examples/Program_CollectAccessHash.cs">Examples/Program_CollectAccessHash.cs</see> for how to use this</remarks>
		/// <typeparam name="T">a TL object class. For example User, Channel or Photo</typeparam>
		public long GetAccessHashFor<T>(long id) where T : IObject
		{
			lock (_accessHashes)
				return _accessHashes.GetOrCreate(typeof(T)).TryGetValue(id, out var access_hash) ? access_hash : 0;
		}
		public void SetAccessHashFor<T>(long id, long access_hash) where T : IObject
		{
			lock (_accessHashes)
				_accessHashes.GetOrCreate(typeof(T))[id] = access_hash;
		}
		static readonly FieldInfo userFlagsField = typeof(User).GetField("flags");
		static readonly FieldInfo channelFlagsField = typeof(Channel).GetField("flags");
		internal void CollectField(FieldInfo fieldInfo, object obj, object access_hash)
		{
			if (fieldInfo.Name != "access_hash") return;
			if (access_hash is not long accessHash) return;
			var type = fieldInfo.ReflectedType;
			if ((type == typeof(User) && ((User.Flags)userFlagsField.GetValue(obj)).HasFlag(User.Flags.min)) ||
				(type == typeof(Channel) && ((Channel.Flags)channelFlagsField.GetValue(obj)).HasFlag(Channel.Flags.min)))
				return; // access_hash from Min constructors are mostly useless. see https://core.telegram.org/api/min
			if (type.GetField("id") is not FieldInfo idField) return;
			if (idField.GetValue(obj) is not long id)
				if (idField.GetValue(obj) is not int idInt) return;
				else id = idInt;
			lock (_accessHashes)
				_accessHashes.GetOrCreate(type)[id] = accessHash;
		}

		#region TL-Helpers
		/// <summary>Helper function to upload a file to Telegram</summary>
		/// <param name="pathname">Path to the file to upload</param>
		/// <param name="progress">(optional) Callback for tracking the progression of the transfer</param>
		/// <returns>an <see cref="InputFile"/> or <see cref="InputFileBig"/> than can be used in various requests</returns>
		public Task<InputFileBase> UploadFileAsync(string pathname, ProgressCallback progress = null)
			=> UploadFileAsync(File.OpenRead(pathname), Path.GetFileName(pathname), progress);

		/// <summary>Helper function to upload a file to Telegram</summary>
		/// <param name="stream">Content of the file to upload. This method close/dispose the stream</param>
		/// <param name="filename">Name of the file</param>
		/// <param name="progress">(optional) Callback for tracking the progression of the transfer</param>
		/// <returns>an <see cref="InputFile"/> or <see cref="InputFileBig"/> than can be used in various requests</returns>
		public async Task<InputFileBase> UploadFileAsync(Stream stream, string filename, ProgressCallback progress = null)
		{
			using var md5 = MD5.Create();
			using (stream)
			{
				long transmitted = 0, length = stream.Length;
				var isBig = length >= 10 * 1024 * 1024;
				int file_total_parts = (int)((length - 1) / FilePartSize) + 1;
				long file_id = Helpers.RandomLong();
				int file_part = 0, read;
				var tasks = new Dictionary<int, Task>();
				bool abort = false;
				for (long bytesLeft = length; !abort && bytesLeft != 0; file_part++)
				{
					var bytes = new byte[Math.Min(FilePartSize, bytesLeft)];
					read = await stream.FullReadAsync(bytes, bytes.Length, default);
					await _parallelTransfers.WaitAsync();
					bytesLeft -= read;
					var task = SavePart(file_part, bytes);
					lock (tasks) tasks[file_part] = task;
					if (!isBig)
						md5.TransformBlock(bytes, 0, read, null, 0);
					if (read < FilePartSize && bytesLeft != 0) throw new ApplicationException($"Failed to fully read stream ({read},{bytesLeft})");

					async Task SavePart(int file_part, byte[] bytes)
					{
						try
						{
							if (isBig)
								await this.Upload_SaveBigFilePart(file_id, file_part, file_total_parts, bytes);
							else
								await this.Upload_SaveFilePart(file_id, file_part, bytes);
							lock (tasks) { transmitted += bytes.Length; tasks.Remove(file_part); }
							progress?.Invoke(transmitted, length);
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

		/// <summary>Search messages with <see href="https://corefork.telegram.org/type/MessagesFilter">filter</see> and text		<para>See <a href="https://corefork.telegram.org/method/messages.search"/></para></summary>
		/// <typeparam name="T">See <see cref="MessagesFilter"/> for a list of possible filter types</typeparam>
		/// <param name="peer">User or chat, histories with which are searched, or <see langword="null"/> constructor for global search</param>
		/// <param name="text">Text search request</param>
		/// <param name="offset_id">Only return messages starting from the specified message ID</param>
		/// <param name="limit"><a href="https://corefork.telegram.org/api/offsets">Number of results to return</a></param>
		public Task<Messages_MessagesBase> Messages_Search<T>(InputPeer peer, string text = null, int offset_id = 0, int limit = int.MaxValue) where T : MessagesFilter, new()
			=> this.Messages_Search(peer, text, new T(), offset_id: offset_id, limit: limit);

		/// <summary>Helper function to send a media message more easily</summary>
		/// <param name="peer">Destination of message (chat group, channel, user chat, etc..) </param>
		/// <param name="caption">Caption for the media <i>(in plain text)</i> or <see langword="null"/></param>
		/// <param name="mediaFile">Media file already uploaded to TG <i>(see <see cref="UploadFileAsync">UploadFileAsync</see>)</i></param>
		/// <param name="mimeType"><see langword="null"/> for automatic detection, <c>"photo"</c> for an inline photo, or a MIME type to send as a document</param>
		/// <param name="reply_to_msg_id">Your message is a reply to an existing message with this ID, in the same chat</param>
		/// <param name="entities">Text formatting entities for the caption. You can use <see cref="Markdown.MarkdownToEntities">MarkdownToEntities</see> to create these</param>
		/// <param name="schedule_date">UTC timestamp when the message should be sent</param>
		/// <returns>The transmitted message confirmed by Telegram</returns>
		public Task<Message> SendMediaAsync(InputPeer peer, string caption, InputFileBase mediaFile, string mimeType = null, int reply_to_msg_id = 0, MessageEntity[] entities = null, DateTime schedule_date = default)
		{
			mimeType ??= Path.GetExtension(mediaFile.Name)?.ToLowerInvariant() switch
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
				return SendMessageAsync(peer, caption, new InputMediaUploadedPhoto { file = mediaFile }, reply_to_msg_id, entities, schedule_date);
			return SendMessageAsync(peer, caption, new InputMediaUploadedDocument(mediaFile, mimeType), reply_to_msg_id, entities, schedule_date);
		}

		/// <summary>Helper function to send a text or media message easily</summary>
		/// <param name="peer">Destination of message (chat group, channel, user chat, etc..) </param>
		/// <param name="text">The plain text of the message (or media caption)</param>
		/// <param name="media">An instance of <see cref="InputMedia">InputMedia</see>-derived class, or <see langword="null"/> if there is no associated media</param>
		/// <param name="reply_to_msg_id">Your message is a reply to an existing message with this ID, in the same chat</param>
		/// <param name="entities">Text formatting entities. You can use <see cref="Markdown.MarkdownToEntities">MarkdownToEntities</see> to create these</param>
		/// <param name="schedule_date">UTC timestamp when the message should be sent</param>
		/// <param name="disable_preview">Should website/media preview be shown or not, for URLs in your message</param>
		/// <returns>The transmitted message as confirmed by Telegram</returns>
		public async Task<Message> SendMessageAsync(InputPeer peer, string text, InputMedia media = null, int reply_to_msg_id = 0, MessageEntity[] entities = null, DateTime schedule_date = default, bool disable_preview = false)
		{
			UpdatesBase updates;
			long random_id = Helpers.RandomLong();
			if (media == null)
				updates = await this.Messages_SendMessage(peer, text, random_id, no_webpage: disable_preview, entities: entities,
					reply_to_msg_id: reply_to_msg_id == 0 ? null : reply_to_msg_id, schedule_date: schedule_date == default ? null : schedule_date);
			else
				updates = await this.Messages_SendMedia(peer, media, text, random_id, entities: entities,
					reply_to_msg_id: reply_to_msg_id == 0 ? null : reply_to_msg_id, schedule_date: schedule_date == default ? null : schedule_date);
			OnUpdate(updates);
			int msgId = -1;
			foreach (var update in updates.UpdateList)
			{
				switch (update)
				{
					case UpdateMessageID updMsgId when updMsgId.random_id == random_id: msgId = updMsgId.id; break;
					case UpdateNewMessage { message: Message message } when message.id == msgId: return message;
					case UpdateNewScheduledMessage { message: Message schedMsg } when schedMsg.id == msgId: return schedMsg;
				}
			}
			if (updates is UpdateShortSentMessage sent)
			{
				return new Message
				{
					flags = (Message.Flags)sent.flags | (reply_to_msg_id == 0 ? 0 : Message.Flags.has_reply_to) | (peer is InputPeerSelf ? 0 : Message.Flags.has_from_id),
					id = sent.id, date = sent.date, message = text, entities = sent.entities, media = sent.media, ttl_period = sent.ttl_period,
					reply_to = reply_to_msg_id == 0 ? null : new MessageReplyHeader { reply_to_msg_id = reply_to_msg_id },
					from_id = peer is InputPeerSelf ? null : new PeerUser { user_id = _session.UserId },
					peer_id = InputToPeer(peer)
				};
			}
			return null;
		}

		/// <summary>Helper function to send an album (media group) of photos or documents more easily</summary>
		/// <param name="peer">Destination of message (chat group, channel, user chat, etc..) </param>
		/// <param name="medias">An array of <see cref="InputMedia">InputMedia</see>-derived class</param>
		/// <param name="caption">Caption for the media <i>(in plain text)</i> or <see langword="null"/></param>
		/// <param name="reply_to_msg_id">Your message is a reply to an existing message with this ID, in the same chat</param>
		/// <param name="entities">Text formatting entities for the caption. You can use <see cref="Markdown.MarkdownToEntities">MarkdownToEntities</see> to create these</param>
		/// <param name="schedule_date">UTC timestamp when the message should be sent</param>
		/// <returns>The last of the media group messages, confirmed by Telegram</returns>
		/// <remarks>
		/// * The caption/entities are set on the last media<br/>
		/// * <see cref="InputMediaDocumentExternal"/> and <see cref="InputMediaPhotoExternal"/> are supported by downloading the file from the web via HttpClient and sending it to Telegram.
		///   WTelegramClient proxy settings don't apply to HttpClient<br/>
		/// * You may run into errors if you mix, in the same album, photos and file documents having no thumbnails/video attributes
		/// </remarks>
		public async Task<Message> SendAlbumAsync(InputPeer peer, InputMedia[] medias, string caption = null, int reply_to_msg_id = 0, MessageEntity[] entities = null, DateTime schedule_date = default)
		{
			System.Net.Http.HttpClient httpClient = null;
			var multiMedia = new InputSingleMedia[medias.Length];
			for (int i = 0; i < medias.Length; i++)
			{
				var ism = multiMedia[i] = new InputSingleMedia { random_id = Helpers.RandomLong(), media = medias[i] };
			retry:
				switch (ism.media)
				{
					case InputMediaUploadedPhoto imup:
						var mmp = (MessageMediaPhoto)await this.Messages_UploadMedia(peer, imup);
						ism.media = mmp.photo;
						break;
					case InputMediaUploadedDocument imud:
						var mmd = (MessageMediaDocument)await this.Messages_UploadMedia(peer, imud);
						ism.media = mmd.document;
						break;
					case InputMediaDocumentExternal imde:
						string mimeType = null;
						var inputFile = await UploadFromUrl(imde.url);
						ism.media = new InputMediaUploadedDocument(inputFile, mimeType);
						goto retry;
					case InputMediaPhotoExternal impe:
						inputFile = await UploadFromUrl(impe.url);
						ism.media = new InputMediaUploadedPhoto { file = inputFile };
						goto retry;

						async Task<InputFileBase> UploadFromUrl(string url)
						{
							var filename = Path.GetFileName(new Uri(url).LocalPath);
							httpClient ??= new();
							var response = await httpClient.GetAsync(url);
							using var stream = await response.Content.ReadAsStreamAsync();
							mimeType = response.Content.Headers.ContentType?.MediaType;
							if (response.Content.Headers.ContentLength is long length)
								return await UploadFileAsync(new Helpers.IndirectStream(stream) { ContentLength = length }, filename);
							else
							{
								using var ms = new MemoryStream();
								await stream.CopyToAsync(ms);
								ms.Position = 0;
								return await UploadFileAsync(ms, filename);
							}
						}
				}
			}
			var lastMedia = multiMedia[^1];
			lastMedia.message = caption;
			lastMedia.entities = entities;
			if (entities != null) lastMedia.flags = InputSingleMedia.Flags.has_entities;

			var updates = await this.Messages_SendMultiMedia(peer, multiMedia, reply_to_msg_id: reply_to_msg_id, schedule_date: schedule_date);
			OnUpdate(updates);
			int msgId = -1;
			foreach (var update in updates.UpdateList)
			{
				switch (update)
				{
					case UpdateMessageID updMsgId when updMsgId.random_id == lastMedia.random_id: msgId = updMsgId.id; break;
					case UpdateNewMessage { message: Message message } when message.id == msgId: return message;
					case UpdateNewScheduledMessage { message: Message schedMsg } when schedMsg.id == msgId: return schedMsg;
				}
			}
			return null;
		}

		private Peer InputToPeer(InputPeer peer) => peer switch
		{
			InputPeerSelf => new PeerUser { user_id = _session.UserId },
			InputPeerUser ipu => new PeerUser { user_id = ipu.user_id },
			InputPeerChat ipc => new PeerChat { chat_id = ipc.chat_id },
			InputPeerChannel ipch => new PeerChannel { channel_id = ipch.channel_id },
			InputPeerUserFromMessage ipufm => new PeerUser { user_id = ipufm.user_id },
			InputPeerChannelFromMessage ipcfm => new PeerChannel { channel_id = ipcfm.channel_id },
			_ => null,
		};

		/// <summary>Download a photo from Telegram into the outputStream</summary>
		/// <param name="photo">The photo to download</param>
		/// <param name="outputStream">Stream to write the file content to. This method does not close/dispose the stream</param>
		/// <param name="photoSize">A specific size/version of the photo, or <see langword="null"/> to download the largest version of the photo</param>
		/// <param name="progress">(optional) Callback for tracking the progression of the transfer</param>
		/// <returns>The file type of the photo</returns>
		public async Task<Storage_FileType> DownloadFileAsync(Photo photo, Stream outputStream, PhotoSizeBase photoSize = null, ProgressCallback progress = null)
		{
			if (photoSize is PhotoStrippedSize psp)
				return InflateStrippedThumb(outputStream, psp.bytes) ? Storage_FileType.jpeg : 0;
			photoSize ??= photo.LargestPhotoSize;
			var fileLocation = photo.ToFileLocation(photoSize);
			return await DownloadFileAsync(fileLocation, outputStream, photo.dc_id, photoSize.FileSize, progress);
		}

		/// <summary>Download a document from Telegram into the outputStream</summary>
		/// <param name="document">The document to download</param>
		/// <param name="outputStream">Stream to write the file content to. This method does not close/dispose the stream</param>
		/// <param name="thumbSize">A specific size/version of the document thumbnail to download, or <see langword="null"/> to download the document itself</param>
		/// <param name="progress">(optional) Callback for tracking the progression of the transfer</param>
		/// <returns>MIME type of the document/thumbnail</returns>
		public async Task<string> DownloadFileAsync(Document document, Stream outputStream, PhotoSizeBase thumbSize = null, ProgressCallback progress = null)
		{
			if (thumbSize is PhotoStrippedSize psp)
				return InflateStrippedThumb(outputStream, psp.bytes) ? "image/jpeg" : null;
			var fileLocation = document.ToFileLocation(thumbSize);
			var fileType = await DownloadFileAsync(fileLocation, outputStream, document.dc_id, thumbSize?.FileSize ?? document.size, progress);
			return thumbSize == null ? document.mime_type : "image/" + fileType;
		}

		/// <summary>Download a file from Telegram into the outputStream</summary>
		/// <param name="fileLocation">Telegram file identifier, typically obtained with a .ToFileLocation() call</param>
		/// <param name="outputStream">Stream to write file content to. This method does not close/dispose the stream</param>
		/// <param name="dc_id">(optional) DC on which the file is stored</param>
		/// <param name="fileSize">(optional) Expected file size</param>
		/// <param name="progress">(optional) Callback for tracking the progression of the transfer</param>
		/// <returns>The file type</returns>
		public async Task<Storage_FileType> DownloadFileAsync(InputFileLocationBase fileLocation, Stream outputStream, int dc_id = 0, int fileSize = 0, ProgressCallback progress = null)
		{
			Storage_FileType fileType = Storage_FileType.unknown;
			var client = dc_id == 0 ? this : await GetClientForDC(dc_id, true);
			using var writeSem = new SemaphoreSlim(1);
			long streamStartPos = outputStream.Position;
			int fileOffset = 0, maxOffsetSeen = 0;
			long transmitted = 0;
			var tasks = new Dictionary<int, Task>();
			progress?.Invoke(0, fileSize);
			bool abort = false;
			while (!abort)
			{
				await _parallelTransfers.WaitAsync();
				var task = LoadPart(fileOffset);
				lock (tasks) tasks[fileOffset] = task;
				if (dc_id == 0) { await task; dc_id = client._dcSession.DcID; }
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
						throw new ApplicationException("Upload_GetFile returned unsupported " + fileBase?.GetType().Name);
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
							transmitted += fileData.bytes.Length;
						}
						catch (Exception)
						{
							abort = true;
							throw;
						}
						finally
						{
							writeSem.Release();
							progress?.Invoke(transmitted, fileSize);
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

		/// <summary>Download the profile photo for a given peer into the outputStream</summary>
		/// <param name="peer">User, Chat or Channel</param>
		/// <param name="outputStream">Stream to write the file content to. This method does not close/dispose the stream</param>
		/// <param name="big">Whether to download the high-quality version of the picture</param>
		/// <param name="miniThumb">Whether to extract the embedded very low-res thumbnail (synchronous, no actual download needed)</param>
		/// <returns>The file type of the photo, or 0 if no photo available</returns>
		public async Task<Storage_FileType> DownloadProfilePhotoAsync(IPeerInfo peer, Stream outputStream, bool big = false, bool miniThumb = false)
		{
			int dc_id;
			long photo_id;
			byte[] stripped_thumb;
			switch (peer)
			{
				case User user:
					if (user.photo == null) return 0;
					dc_id = user.photo.dc_id;
					photo_id = user.photo.photo_id;
					stripped_thumb = user.photo.stripped_thumb;
					break;
				case ChatBase { Photo: var photo }:
					if (photo == null) return 0;
					dc_id = photo.dc_id;
					photo_id = photo.photo_id;
					stripped_thumb = photo.stripped_thumb;
					break;
				default:
					return 0;
			}
			if (miniThumb && !big)
				return InflateStrippedThumb(outputStream, stripped_thumb) ? Storage_FileType.jpeg : 0;
			var fileLocation = new InputPeerPhotoFileLocation { peer = peer.ToInputPeer(), photo_id = photo_id };
			if (big) fileLocation.flags |= InputPeerPhotoFileLocation.Flags.big;
			return await DownloadFileAsync(fileLocation, outputStream, dc_id);
		}

		private static bool InflateStrippedThumb(Stream outputStream, byte[] stripped_thumb)
		{
			if (stripped_thumb == null || stripped_thumb.Length <= 3 || stripped_thumb[0] != 1)
				return false;
			var header = Helpers.StrippedThumbJPG;
			outputStream.Write(header, 0, 164);
			outputStream.WriteByte(stripped_thumb[1]);
			outputStream.WriteByte(0);
			outputStream.WriteByte(stripped_thumb[2]);
			outputStream.Write(header, 167, header.Length - 167);
			outputStream.Write(stripped_thumb, 3, stripped_thumb.Length - 3);
			outputStream.WriteByte(0xff);
			outputStream.WriteByte(0xd9);
			return true;
		}

		/// <summary>Returns the current user dialog list.		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getDialogs#possible-errors">details</a>)</para></summary>
		/// <param name="folder_id"><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></param>
		/// <returns>See <a href="https://corefork.telegram.org/constructor/messages.dialogs"/></returns>
		public async Task<Messages_Dialogs> Messages_GetAllDialogs(int? folder_id = null)
		{
			var dialogs = await this.Messages_GetDialogs(folder_id: folder_id);
			switch (dialogs)
			{
				case Messages_DialogsSlice mds:
					var dialogList = new List<DialogBase>();
					var messageList = new List<MessageBase>();
					while (dialogs.Dialogs.Length != 0)
					{
						dialogList.AddRange(dialogs.Dialogs);
						messageList.AddRange(dialogs.Messages);
						var lastDialog = dialogs.Dialogs[^1];
						var lastMsg = dialogs.Messages.LastOrDefault(m => m.Peer.ID == lastDialog.Peer.ID && m.ID == lastDialog.TopMessage);
						var offsetPeer = dialogs.UserOrChat(lastDialog).ToInputPeer();
						dialogs = await this.Messages_GetDialogs(lastMsg?.Date ?? default, lastDialog.TopMessage, offsetPeer, folder_id: folder_id);
						if (dialogs is not Messages_Dialogs md) break;
						foreach (var (key, value) in md.chats) mds.chats[key] = value;
						foreach (var (key, value) in md.users) mds.users[key] = value;
					}
					mds.dialogs = dialogList.ToArray();
					mds.messages = messageList.ToArray();
					return mds;
				case Messages_Dialogs md: return md;
				default: throw new ApplicationException("Messages_GetDialogs returned unexpected " + dialogs?.GetType().Name);
			}
		}

		/// <summary>Helper method that tries to fetch all participants from a Channel (beyond Telegram server-side limitations)</summary>
		/// <param name="channel">The channel to query</param>
		/// <param name="includeKickBan">Also fetch the kicked/banned members?</param>
		/// <param name="alphabet1">first letters used to search for in participants names<br/>(default values crafted with ♥ to find most latin and cyrillic names)</param>
		/// <param name="alphabet2">second (and further) letters used to search for in participants names</param>
		/// <param name="cancellationToken">Can be used to abort the work of this method</param>
		/// <returns>Field count indicates the total count of members. Field participants contains those that were successfully fetched</returns>
		/// <remarks>⚠ This method can take a few minutes to complete on big broadcast channels. It likely won't be able to obtain the full total count of members</remarks>
		public async Task<Channels_ChannelParticipants> Channels_GetAllParticipants(InputChannelBase channel, bool includeKickBan = false, string alphabet1 = "АБCДЕЄЖФГHИІJКЛМНОПQРСТУВWХЦЧШЩЫЮЯЗ", string alphabet2 = "АCЕHИJЛМНОРСТУВWЫ", CancellationToken cancellationToken = default)
		{
			alphabet2 ??= alphabet1;
			var result = new Channels_ChannelParticipants { chats = new(), users = new() };
			var user_ids = new HashSet<long>();
			var participants = new List<ChannelParticipantBase>();

			var mcf = await this.Channels_GetFullChannel(channel);
			result.count = mcf.full_chat.ParticipantsCount;
			if (result.count > 2000 && ((Channel)mcf.chats[channel.ChannelId]).IsChannel)
				Helpers.Log(2, "Fetching all participants on a big channel can take several minutes...");
			await GetWithFilter(new ChannelParticipantsAdmins());
			await GetWithFilter(new ChannelParticipantsBots());
			await GetWithFilter(new ChannelParticipantsSearch { q = "" }, (f, c) => new ChannelParticipantsSearch { q = f.q + c }, alphabet1);
			if (includeKickBan)
			{
				await GetWithFilter(new ChannelParticipantsKicked { q = "" }, (f, c) => new ChannelParticipantsKicked { q = f.q + c }, alphabet1);
				await GetWithFilter(new ChannelParticipantsBanned { q = "" }, (f, c) => new ChannelParticipantsBanned { q = f.q + c }, alphabet1);
			}
			result.participants = participants.ToArray();
			return result;

			async Task GetWithFilter<T>(T filter, Func<T, char, T> recurse = null, string alphabet = null) where T : ChannelParticipantsFilter
			{
				Channels_ChannelParticipants ccp;
				int maxCount = 0;
				for (int offset = 0; ;)
				{
					cancellationToken.ThrowIfCancellationRequested();
					ccp = await this.Channels_GetParticipants(channel, filter, offset, 1024, 0);
					if (ccp.count > maxCount) maxCount = ccp.count;
					foreach (var kvp in ccp.chats) result.chats[kvp.Key] = kvp.Value;
					foreach (var kvp in ccp.users) result.users[kvp.Key] = kvp.Value;
					lock (participants)
						foreach (var participant in ccp.participants)
							if (user_ids.Add(participant.UserID))
								participants.Add(participant);
					offset += ccp.participants.Length;
					if (offset >= ccp.count || ccp.participants.Length == 0) break;
				}
				Helpers.Log(0, $"GetParticipants({(filter as ChannelParticipantsSearch)?.q}) returned {ccp.count}/{maxCount}.\tAccumulated count: {participants.Count}");
				if (recurse != null && (ccp.count < maxCount - 100 || ccp.count == 200 || ccp.count == 1000))
					foreach (var c in alphabet)
						await GetWithFilter(recurse(filter, c), recurse, c == 'А' ? alphabet : alphabet2);
			}
		}

		public Task<UpdatesBase> AddChatUser(InputPeer peer, InputUserBase user, int fwd_limit = int.MaxValue) => peer switch
		{
			InputPeerChat chat => this.Messages_AddChatUser(chat.chat_id, user, fwd_limit),
			InputPeerChannel channel => this.Channels_InviteToChannel(channel, new[] { user }),
			_ => throw new ArgumentException("This method works on Chat & Channel only"),
		};

		public Task<UpdatesBase> DeleteChatUser(InputPeer peer, InputUser user, bool revoke_history = true) => peer switch
		{
			InputPeerChat chat => this.Messages_DeleteChatUser(chat.chat_id, user, revoke_history),
			InputPeerChannel channel => this.Channels_EditBanned(channel, user, new ChatBannedRights { flags = ChatBannedRights.Flags.view_messages }),
			_ => throw new ArgumentException("This method works on Chat & Channel only"),
		};

		public Task<UpdatesBase> LeaveChat(InputPeer peer, bool revoke_history = true) => peer switch
		{
			InputPeerChat chat => this.Messages_DeleteChatUser(chat.chat_id, InputUser.Self, revoke_history),
			InputPeerChannel channel => this.Channels_LeaveChannel(channel),
			_ => throw new ArgumentException("This method works on Chat & Channel only"),
		};

		public async Task<UpdatesBase> EditChatAdmin(InputPeer peer, InputUserBase user, bool is_admin)
		{
			switch (peer)
			{
				case InputPeerChat chat:
					await this.Messages_EditChatAdmin(chat.chat_id, user, is_admin);
					return new Updates { date = DateTime.UtcNow, users = new(), updates = Array.Empty<Update>(),
						chats = (await this.Messages_GetChats(new[] { chat.chat_id })).chats };
				case InputPeerChannel channel:
					return await this.Channels_EditAdmin(channel, user,
						new ChatAdminRights { flags = is_admin ? (ChatAdminRights.Flags)0x8BF : 0 }, null);
				default:
					throw new ArgumentException("This method works on Chat & Channel only");
			}
		}

		public Task<UpdatesBase> EditChatPhoto(InputPeer peer, InputChatPhotoBase photo) => peer switch
		{
			InputPeerChat chat => this.Messages_EditChatPhoto(chat.chat_id, photo),
			InputPeerChannel channel => this.Channels_EditPhoto(channel, photo),
			_ => throw new ArgumentException("This method works on Chat & Channel only"),
		};

		public Task<UpdatesBase> EditChatTitle(InputPeer peer, string title) => peer switch
		{
			InputPeerChat chat => this.Messages_EditChatTitle(chat.chat_id, title),
			InputPeerChannel channel => this.Channels_EditTitle(channel, title),
			_ => throw new ArgumentException("This method works on Chat & Channel only"),
		};

		public Task<Messages_ChatFull> GetFullChat(InputPeer peer) => peer switch
		{
			InputPeerChat chat => this.Messages_GetFullChat(chat.chat_id),
			InputPeerChannel channel => this.Channels_GetFullChannel(channel),
			_ => throw new ArgumentException("This method works on Chat & Channel only"),
		};

		public async Task<UpdatesBase> DeleteChat(InputPeer peer)
		{
			switch (peer)
			{
				case InputPeerChat chat:
					await this.Messages_DeleteChat(chat.chat_id);
					return new Updates { date = DateTime.UtcNow, users = new(), updates = Array.Empty<Update>(),
						chats = (await this.Messages_GetChats(new[] { chat.chat_id })).chats };
				case InputPeerChannel channel:
					return await this.Channels_DeleteChannel(channel);
				default:
					throw new ArgumentException("This method works on Chat & Channel only");
			}
		}
		#endregion
	}
}
