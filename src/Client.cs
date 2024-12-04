using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using TL;
using static WTelegram.Encryption;

// necessary for .NET Standard 2.0 compilation:
#pragma warning disable CA1835 // Prefer the 'Memory'-based overloads for 'ReadAsync' and 'WriteAsync'

namespace WTelegram
{
	public partial class Client : IDisposable
#if NETCOREAPP2_1_OR_GREATER
		, IAsyncDisposable
#endif
	{
		/// <summary>This event will be called when unsollicited updates/messages are sent by Telegram servers</summary>
		/// <remarks>Make your handler <see langword="async"/>, or return <see cref="Task.CompletedTask"/> or <see langword="null"/><br/>See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/Examples/Program_ReactorError.cs?ts=4#L30">Examples/Program_ReactorError.cs</see> for how to use this<br/>or <see href="https://github.com/wiz0u/WTelegramClient/blob/master/Examples/Program_ListenUpdates.cs?ts=4#L21">Examples/Program_ListenUpdate.cs</see> using the UpdateManager class instead</remarks>
		public event Func<UpdatesBase, Task> OnUpdates;
		/// <summary>This event is called for other types of notifications (login states, reactor errors, ...)</summary>
		public event Func<IObject, Task> OnOther;
		/// <summary>Use this handler to intercept Updates that resulted from your own API calls</summary>
		public event Func<UpdatesBase, Task> OnOwnUpdates;
		/// <summary>Used to create a TcpClient connected to the given address/port, or throw an exception on failure</summary>
		public TcpFactory TcpHandler { get; set; } = DefaultTcpHandler;
		public delegate Task<TcpClient> TcpFactory(string host, int port);
		/// <summary>Url for using a MTProxy. https://t.me/proxy?server=... </summary>
		public string MTProxyUrl { get; set; }
		/// <summary>Telegram configuration, obtained at connection time</summary>
		public Config TLConfig { get; private set; }
		/// <summary>Number of automatic reconnections on connection/reactor failure</summary>
		public int MaxAutoReconnects { get; set; } = 5;
		/// <summary>Number of attempts in case of wrong verification_code or password</summary>
		public int MaxCodePwdAttempts { get; set; } = 3;
		/// <summary>Number of seconds under which an error 420 FLOOD_WAIT_X will not be raised and your request will instead be auto-retried after the delay</summary>
		public int FloodRetryThreshold { get; set; } = 60;
		/// <summary>Number of seconds between each keep-alive ping. Increase this if you have a slow connection or you're debugging your code</summary>
		public int PingInterval { get; set; } = 60;
		/// <summary>Size of chunks when uploading/downloading files. Reduce this if you don't have much memory</summary>
		public int FilePartSize { get; set; } = 512 * 1024;
		/// <summary>Is this Client instance the main or a secondary DC session</summary>
		public bool IsMainDC => _dcSession?.DataCenter?.flags.HasFlag(DcOption.Flags.media_only) != true
			&& (_dcSession?.DataCenter?.id - _session.MainDC) is null or 0;
		/// <summary>Has this Client established connection been disconnected?</summary>
		public bool Disconnected => _tcpClient != null && !(_tcpClient.Client?.Connected ?? false);
		/// <summary>ID of the current logged-in user or 0</summary>
		public long UserId => _session.UserId;
		/// <summary>Info about the current logged-in user. This is only filled after a successful (re)login, not updated later</summary>
		public User User { get; private set; }

		private Func<string, string> _config;
		private readonly Session _session;
		private string _apiHash;
		private Session.DCSession _dcSession;
		private TcpClient _tcpClient;
		private Stream _networkStream;
		private HttpClient _httpClient;
		private HttpWait _httpWait;
		private IObject _lastSentMsg;
		private long _lastRecvMsgId;
		private readonly List<long> _msgsToAck = [];
		private readonly Random _random = new();
		private int _saltChangeCounter;
		private Task _reactorTask;
		private Rpc _bareRpc;
		private readonly Dictionary<long, Rpc> _pendingRpcs = [];
		private SemaphoreSlim _sendSemaphore = new(0);
		private readonly SemaphoreSlim _semaphore = new(1);
		private Task _connecting;
		private CancellationTokenSource _cts;
		private int _reactorReconnects = 0;
		private const string ConnectionShutDown = "Could not read payload length : Connection shut down";
		private const long Ticks5Secs = 5 * TimeSpan.TicksPerSecond;
		private readonly SemaphoreSlim _parallelTransfers = new(10); // max parallel part uploads/downloads
		private readonly SHA256 _sha256 = SHA256.Create();
		private readonly SHA256 _sha256Recv = SHA256.Create();
#if OBFUSCATION
		private AesCtr _sendCtr, _recvCtr;
#endif
		private bool _paddedMode;

		public Client(int apiID, string apiHash, string sessionPathname = null)
			: this(what => what switch
			{
				"api_id" => apiID.ToString(),
				"api_hash" => apiHash,
				"session_pathname" => sessionPathname,
				_ => null
			})
		{ }

		public Client(Func<string, string> configProvider, byte[] startSession, Action<byte[]> saveSession)
			: this(configProvider, new ActionStore(startSession, saveSession)) { }

		/// <summary>Welcome to WTelegramClient! 🙂</summary>
		/// <param name="configProvider">Config callback, is queried for: <b>api_id</b>, <b>api_hash</b>, <b>session_pathname</b></param>
		/// <param name="sessionStore">if specified, must support initial Length &amp; Read() of a session, then calls to Write() the updated session. Other calls can be ignored</param>
		public Client(Func<string, string> configProvider = null, Stream sessionStore = null)
		{
			_config = configProvider ?? DefaultConfigOrAsk;
			var session_key = _config("session_key") ?? (_apiHash = Config("api_hash"));
			sessionStore ??= new SessionStore(Config("session_pathname"));
			_session = Session.LoadOrCreate(sessionStore, Convert.FromHexString(session_key));
			if (_session.ApiId == 0) _session.ApiId = int.Parse(Config("api_id"));
			if (_session.MainDC != 0) _session.DCSessions.TryGetValue(_session.MainDC, out _dcSession);
			_dcSession ??= new() { Id = Helpers.RandomLong() };
			_dcSession.Client = this;
			var version = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
			Helpers.Log(1, $"WTelegramClient {version} running under {System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription}");
		}

		private Client(Client cloneOf, Session.DCSession dcSession)
		{
			_config = cloneOf._config;
			_session = cloneOf._session;
			TcpHandler = cloneOf.TcpHandler;
			MTProxyUrl = cloneOf.MTProxyUrl;
			PingInterval = cloneOf.PingInterval;
			TLConfig = cloneOf.TLConfig;
			_dcSession = dcSession;
		}

		internal Task<string> ConfigAsync(string what) => Task.Run(() => Config(what));
		internal string Config(string what)
			=> _config(what) ?? DefaultConfig(what) ?? throw new WTException("You must provide a config value for " + what);

		/// <summary>Default config values, used if your Config callback returns <see langword="null"/></summary>
		public static string DefaultConfig(string what) => what switch
		{
			"session_pathname" => Path.Combine(
				Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory.TrimEnd(Path.DirectorySeparatorChar)))
				?? AppDomain.CurrentDomain.BaseDirectory, "WTelegram.session"),
#if DEBUG
			"server_address" => "2>149.154.167.40:443",	// Test DC 2
#else
			"server_address" => "2>149.154.167.50:443",	// DC 2
#endif
			"device_model" => Environment.Is64BitOperatingSystem ? "PC 64bit" : "PC 32bit",
			"system_version" => Helpers.GetSystemVersion(),
			"app_version" => Helpers.GetAppVersion(),
			"system_lang_code" => CultureInfo.InstalledUICulture.TwoLetterISOLanguageName,
			"lang_pack" => "",
			"lang_code" => CultureInfo.CurrentUICulture.TwoLetterISOLanguageName,
			"user_id" => "-1",
			"verification_code" or "email_verification_code" or "password" => AskConfig(what),
			"init_params" => "{}",
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
		/// <param name="accountPassword">Password validation configuration. You can obtain this via <c>Account_GetPassword</c> or through OnOther as part of the login process</param>
		/// <param name="password">The password to validate</param>
		public static Task<InputCheckPasswordSRP> InputCheckPassword(Account_Password accountPassword, string password)
			=> Check2FA(accountPassword, () => Task.FromResult(password));

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA1816")]
		public void Dispose() => DisposeAsync().AsTask().Wait();
		public async ValueTask DisposeAsync()
		{
			Helpers.Log(2, $"{_dcSession.DcID}>Disposing the client");
			await ResetAsync(false, IsMainDC).ConfigureAwait(false);
			var ex = new ObjectDisposedException("WTelegram.Client was disposed");
			lock (_pendingRpcs) // abort all pending requests
				foreach (var rpc in _pendingRpcs.Values)
					rpc.tcs.TrySetException(ex);
			_sendSemaphore.Dispose();
			_httpClient?.Dispose();
			_networkStream = null;
			if (IsMainDC) _session.Dispose();
			GC.SuppressFinalize(this);
		}

		public void DisableUpdates(bool disable = true) => _dcSession.DisableUpdates(disable);

		/// <summary>Enable connecting to Telegram via on-demand HTTP requests instead of permanent TCP connection</summary>
		/// <param name="httpClient">HttpClient to use. Leave <see langword="null"/> for a default one</param>
		/// <param name="defaultHttpWait">Default HttpWait parameters for requests.<para>⚠️ Telegram servers don't support this correctly at the moment.</para>So leave <see langword="null"/> for the default 25 seconds long poll</param>
		public void HttpMode(HttpClient httpClient = null, HttpWait defaultHttpWait = null)
		{
			if (_tcpClient != null) throw new InvalidOperationException("Cannot switch to HTTP after TCP connection");
			_httpClient = httpClient ?? new();
			_httpWait = defaultHttpWait;
			while (_parallelTransfers.CurrentCount > 1) _parallelTransfers.Wait();
		}

		/// <summary>Disconnect from Telegram <i>(shouldn't be needed in normal usage)</i></summary>
		/// <param name="resetUser">Forget about logged-in user</param>
		/// <param name="resetSessions">Disconnect secondary sessions with other DCs</param>
		public void Reset(bool resetUser = true, bool resetSessions = true) => ResetAsync(resetUser, resetSessions).Wait();

		/// <summary>Disconnect from Telegram <i>(shouldn't be needed in normal usage)</i></summary>
		/// <param name="resetUser">Forget about logged-in user</param>
		/// <param name="resetSessions">Disconnect secondary sessions with other DCs</param>
		public async Task ResetAsync(bool resetUser = true, bool resetSessions = true)
		{
			try
			{
				if (_httpClient == null && CheckMsgsToAck() is MsgsAck msgsAck)
					await SendAsync(msgsAck, false).WaitAsync(1000).ConfigureAwait(false);
			}
			catch { }
			_cts?.Cancel();
			_sendSemaphore = new(0);    // initially taken, first released during DoConnectAsync
			try
			{
				await _reactorTask.WaitAsync(1000).ConfigureAwait(false);
			}
			catch { }
			_reactorTask = resetSessions ? null : Task.CompletedTask;
			_networkStream?.Close();
			_tcpClient?.Dispose();
#if OBFUSCATION
			_sendCtr?.Dispose();
			_recvCtr?.Dispose();
#endif
			_paddedMode = false;
			_connecting = null;
			_bareRpc = null;
			if (resetSessions)
			{
				foreach (var altSession in _session.DCSessions.Values)
					if (altSession.Client != null && altSession.Client != this)
					{
						await altSession.Client.DisposeAsync();
						altSession.Client = null;
					}
			}
			if (resetUser)
			{
				_loginCfg = default;
				_session.UserId = 0;
				User = null;
			}
		}

		private Session.DCSession GetOrCreateDCSession(int dcId, DcOption.Flags flags)
		{
			if (_session.DCSessions.TryGetValue(dcId, out var dcSession) && dcSession.AuthKey != null)
				if (dcSession.Client != null || dcSession.DataCenter.flags == flags)
					return dcSession; // if we have already a session with this DC and we are connected or it is a perfect match, use it
			if (dcSession == null && _session.DCSessions.TryGetValue(-dcId, out dcSession) && dcSession.AuthKey != null)
			{
				// we have already negociated an AuthKey with this DC
				if (dcSession.DataCenter.flags == flags && _session.DCSessions.Remove(-dcId))
					return _session.DCSessions[dcId] = dcSession; // we found a misclassed DC, change its sign
				dcSession = new Session.DCSession { Id = Helpers.RandomLong(), // clone AuthKey for a session on the matching media_only DC
					AuthKeyID = dcSession.AuthKeyID, AuthKey = dcSession.AuthKey, UserId = dcSession.UserId };
			}
			// try to find the most appropriate DcOption for this DC
			if (dcSession?.AuthKey == null) // we'll need to negociate an AuthKey => can't use media_only DC
			{
				flags &= ~DcOption.Flags.media_only;
				dcId = Math.Abs(dcId);
			}
			var dcOptions = GetDcOptions(Math.Abs(dcId), flags);
			var dcOption = dcOptions.FirstOrDefault() ?? throw new WTException($"Could not find adequate dc_option for DC {dcId}");
			dcSession ??= new Session.DCSession { Id = Helpers.RandomLong() }; // create new session only if not already existing
			dcSession.DataCenter = dcOption;
			return _session.DCSessions[dcId] = dcSession;
		}

		/// <summary>Obtain/create a Client for a secondary session on a specific Data Center</summary>
		/// <param name="dcId">ID of the Data Center (use negative values for media_only)</param>
		/// <param name="connect">Connect immediately</param>
		/// <returns>Client connected to the selected DC</returns>
		public async Task<Client> GetClientForDC(int dcId, bool connect = true)
		{
			if (_dcSession.DataCenter?.id == dcId) return this;
			Session.DCSession altSession;
			lock (_session)
			{
				var flags = _dcSession.DataCenter.flags;
				if (dcId < 0) flags = (flags & DcOption.Flags.ipv6) | DcOption.Flags.media_only;
				altSession = GetOrCreateDCSession(dcId, flags);
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
						exported = await this.Auth_ExportAuthorization(Math.Abs(dcId));
					await altSession.Client.ConnectAsync();
					if (exported != null)
					{
						var authorization = await altSession.Client.Auth_ImportAuthorization(exported.id, exported.bytes);
						if (authorization is not Auth_Authorization { user: User user })
							throw new WTException("Failed to get Authorization: " + authorization.GetType().Name);
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
						throw new WTException(ConnectionShutDown);
#if OBFUSCATION
					_recvCtr.EncryptDecrypt(data, 4);
#endif
					int payloadLen = BinaryPrimitives.ReadInt32LittleEndian(data);
					if (payloadLen <= 0)
						throw new WTException("Could not read frame data : Invalid payload length");
					else if (payloadLen > data.Length)
						data = new byte[payloadLen];
					else if (Math.Max(payloadLen, MinBufferSize) < data.Length / 4)
						data = new byte[Math.Max(payloadLen, MinBufferSize)];
					if (await stream.FullReadAsync(data, payloadLen, cts.Token) != payloadLen)
						throw new WTException("Could not read frame data : Connection shut down");
#if OBFUSCATION
					_recvCtr.EncryptDecrypt(data, payloadLen);
#endif
					obj = ReadFrame(data, payloadLen);
				}
				catch (Exception ex) // an exception in RecvAsync is always fatal
				{
					if (cts.IsCancellationRequested) return;
					bool disconnectedAltDC = !IsMainDC && ex is WTException { Message: ConnectionShutDown } or IOException { InnerException: SocketException };
					if (disconnectedAltDC)
						Helpers.Log(3, $"{_dcSession.DcID}>Alt DC disconnected: {ex.Message}");
					else
						Helpers.Log(5, $"{_dcSession.DcID}>An exception occured in the reactor: {ex}");
					var oldSemaphore = _sendSemaphore;
					await oldSemaphore.WaitAsync(cts.Token); // prevent any sending while we reconnect
					var reactorError = new ReactorError { Exception = ex };
					try
					{
						lock (_msgsToAck) _msgsToAck.Clear();
						await ResetAsync(false, false);
						_reactorReconnects = (_reactorReconnects + 1) % MaxAutoReconnects;
						if (disconnectedAltDC && _pendingRpcs.Count <= 1)
							if (_pendingRpcs.Values.FirstOrDefault() is not Rpc rpc || rpc.type == typeof(Pong))
								_reactorReconnects = 0;
						if (_reactorReconnects == 0)
							throw;
						await Task.Delay(5000);
						if (_networkStream == null) return; // Dispose has been called in-between
						await ConnectAsync(); // start a new reactor after 5 secs
						lock (_pendingRpcs) // retry all pending requests
						{
							foreach (var rpc in _pendingRpcs.Values)
								rpc.tcs.TrySetResult(reactorError); // this leads to a retry (see Invoke<T> method)
							_pendingRpcs.Clear();
							_bareRpc = null;
						}
						if (IsMainDC)
						{
							var updatesState = await this.Updates_GetState(); // this call reenables incoming Updates
							RaiseUpdates(updatesState);
						}
					}
					catch (Exception e) when (e is not ObjectDisposedException)
					{
						if (IsMainDC)
							RaiseUpdates(reactorError);
						lock (_pendingRpcs) // abort all pending requests
						{
							foreach (var rpc in _pendingRpcs.Values)
								rpc.tcs.TrySetException(ex);
							_pendingRpcs.Clear();
							_bareRpc = null;
						}
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

		internal DateTime MsgIdToStamp(long serverMsgId)
			=> new((serverMsgId >> 32) * 10000000 - _dcSession.ServerTicksOffset + 621355968000000000L, DateTimeKind.Utc);

		internal IObject ReadFrame(byte[] data, int dataLen)
		{
			if (dataLen < 8 && data[3] == 0xFF)
			{
				int error_code = -BinaryPrimitives.ReadInt32LittleEndian(data);
				throw new RpcException(error_code, TransportError(error_code));
			}
			if (dataLen < 24) // authKeyId+msgId+length+ctorNb | authKeyId+msgKey
				throw new WTException($"Packet payload too small: {dataLen}");

			long authKeyId = BinaryPrimitives.ReadInt64LittleEndian(data);
			if (authKeyId != _dcSession.AuthKeyID)
				throw new WTException($"Received a packet encrypted with unexpected key {authKeyId:X}");
			if (authKeyId == 0) // Unencrypted message
			{
				using var reader = new BinaryReader(new MemoryStream(data, 8, dataLen - 8));
				long msgId = _lastRecvMsgId = reader.ReadInt64();
				if ((msgId & 1) == 0) throw new WTException($"Invalid server msgId {msgId}");
				int length = reader.ReadInt32();
				dataLen -= 20;
				if (length > dataLen || dataLen - length > (_paddedMode ? 256 : 0))
					throw new WTException($"Unexpected unencrypted/padding length {dataLen} - {length}");

				var obj = reader.ReadTLObject();
				Helpers.Log(1, $"{_dcSession.DcID}>Receiving {obj.GetType().Name,-40} {MsgIdToStamp(msgId):u} clear{((msgId & 2) == 0 ? "" : " NAR")}");
				if (_bareRpc == null) throw new WTException("Shouldn't receive unencrypted packet at this point");
				return obj;
			}
			else
			{
				byte[] decrypted_data = EncryptDecryptMessage(data.AsSpan(24, (dataLen - 24) & ~0xF), false, 8, _dcSession.AuthKey, data, 8, _sha256Recv);
				if (decrypted_data.Length < 36) // header below+ctorNb
					throw new WTException($"Decrypted packet too small: {decrypted_data.Length}");
				_sha256Recv.TransformBlock(_dcSession.AuthKey, 96, 32, null, 0);
				_sha256Recv.TransformFinalBlock(decrypted_data, 0, decrypted_data.Length);
				if (!data.AsSpan(8, 16).SequenceEqual(_sha256Recv.Hash.AsSpan(8, 16)))
					throw new WTException("Mismatch between MsgKey & decrypted SHA256");
				_sha256Recv.Initialize();
				using var reader = new BinaryReader(new MemoryStream(decrypted_data));
				var serverSalt = reader.ReadInt64();    // int64 salt
				var sessionId = reader.ReadInt64();     // int64 session_id
				var msgId = reader.ReadInt64();         // int64 message_id
				var seqno = reader.ReadInt32();         // int32 msg_seqno
				var length = reader.ReadInt32();        // int32 message_data_length

				if (length < 0 || length % 4 != 0) throw new WTException($"Invalid message_data_length: {length}");
				if (decrypted_data.Length - 32 - length is < 12 or > 1024) throw new WTException($"Invalid message padding length: {decrypted_data.Length - 32}-{length}");
				if (sessionId != _dcSession.Id) throw new WTException($"Unexpected session ID: {sessionId} != {_dcSession.Id}");
				if ((msgId & 1) == 0) throw new WTException($"msg_id is not odd: {msgId}");
				if (!_dcSession.CheckNewMsgId(msgId))
				{
					Helpers.Log(3, $"{_dcSession.DcID}>Ignoring duplicate or old msg_id {msgId}");
					return null;
				}
				var utcNow = DateTime.UtcNow;
				if (_lastRecvMsgId == 0) // resync ServerTicksOffset on first message
					_dcSession.ServerTicksOffset = (msgId >> 32) * 10000000 - utcNow.Ticks + 621355968000000000L;
				var msgStamp = MsgIdToStamp(_lastRecvMsgId = msgId);
				long deltaTicks = (msgStamp - utcNow).Ticks;
				if (deltaTicks is > 0)
					if (deltaTicks < Ticks5Secs) // resync if next message is less than 5 seconds in the future
						_dcSession.ServerTicksOffset += deltaTicks;
					else if (_dcSession.ServerTicksOffset < -Ticks5Secs && deltaTicks + _dcSession.ServerTicksOffset < 0)
						_dcSession.ServerTicksOffset += deltaTicks;
				if (serverSalt != _dcSession.Salt && serverSalt != _dcSession.OldSalt && serverSalt != _dcSession.Salts?.Values.ElementAtOrDefault(1))
				{
					Helpers.Log(3, $"{_dcSession.DcID}>Server salt has changed: {_dcSession.Salt:X} -> {serverSalt:X}");
					_dcSession.OldSalt = _dcSession.Salt;
					_dcSession.Salt = serverSalt;
					if (++_saltChangeCounter >= 10)
						throw new WTException("Server salt changed too often! Security issue?");
					CheckSalt();
				}
				if ((seqno & 1) != 0) lock (_msgsToAck) _msgsToAck.Add(msgId);

				var ctorNb = reader.ReadUInt32();
				if (ctorNb != Layer.BadMsgCtor && deltaTicks / TimeSpan.TicksPerSecond is > 30 or < -300)
				{   // msg_id values that belong over 30 seconds in the future or over 300 seconds in the past are to be ignored.
					Helpers.Log(1, $"{_dcSession.DcID}>Ignoring  0x{ctorNb:X8} because of wrong timestamp    {msgStamp:u} - {utcNow:u} Δ={new TimeSpan(_dcSession.ServerTicksOffset):c}");
					return null;
				}
				try
				{
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
				catch (Exception ex)
				{
					Helpers.Log(4, $"While deserializing frame #{ctorNb:x}: " + ex.ToString());
					return null;
				}
			}
		}

		static string TransportError(int error_code) => error_code switch
		{
			404 => "Auth key not found",
			429 => "Transport flood",
			444 => "Invalid DC",
			_ => Enum.GetName(typeof(HttpStatusCode), error_code) ?? "Transport error"
		};

		internal void CheckSalt()
		{
			lock (_session)
			{
				_dcSession.Salts ??= [];
				if (_dcSession.Salts.Count != 0)
				{
					var keys = _dcSession.Salts.Keys;
					if (keys[^1] == DateTime.MaxValue) return; // GetFutureSalts ongoing
					var now = DateTime.UtcNow.AddTicks(_dcSession.ServerTicksOffset);
					for (; keys.Count > 1 && keys[1] < now; _dcSession.OldSalt = _dcSession.Salt, _dcSession.Salt = _dcSession.Salts.Values[0])
						_dcSession.Salts.RemoveAt(0);
					if (_dcSession.Salts.Count > 48) return;
				}
				_dcSession.Salts[DateTime.MaxValue] = 0;
			}
			Task.Delay(5000).ContinueWith(_ => this.GetFutureSalts(128).ContinueWith(gfs =>
			{
				lock (_session)
				{
					_dcSession.Salts.Remove(DateTime.MaxValue);
					foreach (var entry in gfs.Result.salts)
						_dcSession.Salts[entry.valid_since] = entry.salt;
					_dcSession.OldSalt = _dcSession.Salt;
					_dcSession.Salt = _dcSession.Salts.Values[0];
					_session.Save();
				}
			}));
		}

		internal MsgContainer ReadMsgContainer(BinaryReader reader)
		{
			int count = reader.ReadInt32();
			var messages = new List<_Message>(count);
			for (int i = 0; i < count; i++)
			{
				var msg = new _Message(reader.ReadInt64(), reader.ReadInt32(), null) { bytes = reader.ReadInt32() };
				messages.Add(msg);
				if ((msg.seq_no & 1) != 0) lock (_msgsToAck) _msgsToAck.Add(msg.msg_id);
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
						Helpers.Log(1, $"            → {obj.GetType().Name,-38} {MsgIdToStamp(msg.msg_id):u} {((msg.seq_no & 1) != 0 ? "" : "(svc)")} {((msg.msg_id & 2) == 0 ? "" : "NAR")}");
					}
				}
				catch (Exception ex)
				{
					Helpers.Log(4, "While deserializing vector<%Message>: " + ex.ToString());
				}
				reader.BaseStream.Position = pos + msg.bytes;
			}
			return new MsgContainer { messages = messages };
		}

		private RpcResult ReadRpcResult(BinaryReader reader)
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
							result = reader.ReadTLGzipped(rpc.type);
						else
						{
							reader.BaseStream.Position -= 4;
							result = reader.ReadTLVector(rpc.type);
						}
					}
					if (rpc.type.IsEnum) result = Enum.ToObject(rpc.type, result);
					if (result is RpcError rpcError)
						Helpers.Log(4, $"             → RpcError {rpcError.error_code,3} {rpcError.error_message,-24} #{(short)msgId.GetHashCode():X4}");
					else
					{
						Helpers.Log(1, $"             → {result?.GetType().Name,-37} #{(short)msgId.GetHashCode():X4}");
						CheckRaiseOwnUpdates(result);
					}

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
				else
				{
					result = reader.ReadTLObject(ctorNb);
					CheckRaiseOwnUpdates(result);
				}

				var typeName = result?.GetType().Name;
				if (MsgIdToStamp(msgId) >= _session.SessionStart)
					Helpers.Log(4, $"             → {typeName,-37} for unknown msgId #{(short)msgId.GetHashCode():X4}");
				else
					Helpers.Log(1, $"             → {typeName,-37} for past msgId #{(short)msgId.GetHashCode():X4}");
			}
			return new RpcResult { req_msg_id = msgId, result = result };
		}

		private sealed class Rpc
		{
			internal Type type;
			internal TaskCompletionSource<object> tcs = new(TaskCreationOptions.RunContinuationsAsynchronously);
			internal long msgId;
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

		private async Task HandleMessageAsync(IObject obj)
		{
			if (_bareRpc != null)
			{
				var rpc = PullPendingRequest(_bareRpc.msgId);
				if ((rpc?.type.IsAssignableFrom(obj.GetType())) == true)
				{
					_bareRpc = null;
					rpc.tcs.SetResult(obj);
					return;
				}
				else if (_dcSession.AuthKeyID == 0)
					throw new WTException($"Received a {obj.GetType()} incompatible with expected bare {rpc?.type}");
				lock (_pendingRpcs)
					_pendingRpcs[_bareRpc.msgId] = _bareRpc;
			}
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
					RaiseUpdates(pong);
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
								await ResetAsync(false, false);
								_dcSession.Renew();
								await ConnectAsync();
							}
							break;
						case 48: // incorrect server salt (in this case, the bad_server_salt response is received with the correct salt, and the message is to be re-sent with it)
							_dcSession.OldSalt = _dcSession.Salt;
							_dcSession.Salt = ((BadServerSalt)badMsgNotification).new_server_salt;
							CheckSalt();
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
						await SendAsync(lastSentMsg, lastSentMsg is not MsgContainer, prevRequest);
						lock (_pendingRpcs)
							_pendingRpcs.Remove(badMsgNotification.bad_msg_id);
					}
					else if (PullPendingRequest(badMsgNotification.bad_msg_id) is Rpc rpc)
					{
						if (_bareRpc?.msgId == badMsgNotification.bad_msg_id) _bareRpc = null;
						rpc.tcs.SetException(new WTException($"BadMsgNotification {badMsgNotification.error_code}"));
					}
					else
						RaiseUpdates(badMsgNotification);
					break;
				default:
					RaiseUpdates(obj);
					break;
			}

			void SetResult(long msgId, object result)
			{
				var rpc = PullPendingRequest(msgId);
				if (rpc != null)
					rpc.tcs.SetResult(result);
				else
					RaiseUpdates(obj);
			}
		}

		private async void RaiseUpdates(IObject obj)
		{
			try
			{
				var task = obj is UpdatesBase updates ? OnUpdates?.Invoke(updates) : OnOther?.Invoke(obj);
				if (task != null) await task;
			}
			catch (Exception ex)
			{
				Helpers.Log(4, $"{nameof(OnUpdates)}({obj?.GetType().Name}) raised {ex}");
			}
		}

		private void CheckRaiseOwnUpdates(object result)
		{
			if (OnOwnUpdates == null) return;
			if (result is UpdatesBase updates)
				RaiseOwnUpdates(updates);
			else if (result is Payments_PaymentResult ppr)
				RaiseOwnUpdates(ppr.updates);
			else if (result is Messages_InvitedUsers miu)
				RaiseOwnUpdates(miu.updates);
		}

		private async void RaiseOwnUpdates(UpdatesBase updates)
		{
			try
			{
				await OnOwnUpdates?.Invoke(updates);
			}
			catch (Exception ex)
			{
				Helpers.Log(4, $"{nameof(OnOwnUpdates)}({updates.GetType().Name}) raised {ex}");
			}
		}

		static async Task<TcpClient> DefaultTcpHandler(string host, int port)
		{
			var tcpClient = new TcpClient();
			await tcpClient.ConnectAsync(host, port);
			return tcpClient;
		}

		private IPEndPoint GetDefaultEndpoint(out int dcId)
		{
			string addr = Config("server_address");
			dcId = addr.Length > 2 && addr[1] == '>' && addr[0] is > '0' and <= '9' ? addr[0] - '0' : 0;
			return Compat.IPEndPoint_Parse(dcId == 0 ? addr : addr[2..]);
		}

		/// <summary>Establish connection to Telegram servers without negociating a user session</summary>
		/// <param name="quickResume">Attempt to resume session immediately without issuing Layer/InitConnection/GetConfig <i>(not recommended by default)</i></param>
		/// <remarks>Usually you shouldn't need to call this method: Use <see cref="LoginUserIfNeeded">LoginUserIfNeeded</see> instead. <br/>Config callback is queried for: <b>server_address</b></remarks>
		/// <returns>Most methods of this class are async (Task), so please use <see langword="await"/></returns>
		public async Task ConnectAsync(bool quickResume = false)
		{
			lock (this)
				_connecting ??= DoConnectAsync(quickResume);
			await _connecting;
		}

		private IEnumerable<DcOption> GetDcOptions(int dcId, DcOption.Flags flags) => !flags.HasFlag(DcOption.Flags.media_only)
			? _session.DcOptions.Where(dc => dc.id == dcId && (dc.flags & (DcOption.Flags.cdn | DcOption.Flags.tcpo_only | DcOption.Flags.media_only)) == 0)
				.OrderBy(dc => dc.flags ^ flags)
			: _session.DcOptions.Where(dc => dc.id == dcId && (dc.flags & (DcOption.Flags.cdn | DcOption.Flags.tcpo_only)) == 0)
				.OrderBy(dc => ~dc.flags & DcOption.Flags.media_only).ThenBy(dc => dc.flags ^ flags)
				.Select(dc => dc.flags.HasFlag(DcOption.Flags.media_only) ? dc : new DcOption { id = dc.id, port = dc.port,
					ip_address = dc.ip_address, secret = dc.secret, flags = dc.flags | DcOption.Flags.media_only });

		private async Task DoConnectAsync(bool quickResume)
		{
			_cts = new();
			IPEndPoint endpoint = null;
			byte[] preamble, secret = null;
			int dcId = _dcSession?.DcID ?? 0;
			if (dcId == 0) dcId = 2;
			if (MTProxyUrl != null)
			{
#if OBFUSCATION
				if (TLConfig?.test_mode == true) dcId += 10000;
				if (_dcSession.DataCenter?.flags.HasFlag(DcOption.Flags.media_only) == true) dcId = -dcId;
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
				else if (secret.Length != 16) throw new ArgumentException("Invalid/unsupported secret");
				Helpers.Log(2, $"Connecting to DC {dcId} via MTProxy {server}:{port}...");
				_tcpClient = await TcpHandler(server, port);
				_networkStream = _tcpClient.GetStream();
				if (tlsMode)
					_networkStream = await TlsStream.HandshakeAsync(_networkStream, secret, secretBytes[17..], _cts.Token);
#else
				throw new Exception("Library was not compiled with OBFUSCATION symbol");
#endif
			}
			else if (_httpClient != null)
			{
				Helpers.Log(2, $"Using HTTP Mode");
				_reactorTask = Task.CompletedTask;
			}
			else
			{
				endpoint = _dcSession?.EndPoint ?? GetDefaultEndpoint(out int defaultDc);
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
							var altOptions = GetDcOptions(_dcSession.DataCenter.id, _dcSession.DataCenter.flags);
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
							endpoint = GetDefaultEndpoint(out defaultDc); // re-ask callback for an address
							if (!triedEndpoints.Add(endpoint)) throw;
							_dcSession.Client = null;
							// is it address for a known DCSession?
							_dcSession = _session.DCSessions.Values.FirstOrDefault(dcs => dcs.EndPoint.Equals(endpoint));
							if (defaultDc != 0) _dcSession ??= _session.DCSessions.GetValueOrDefault(defaultDc);
							_dcSession ??= new() { Id = Helpers.RandomLong() };
							_dcSession.Client = this;
							_dcSession.DataCenter = null;
							Helpers.Log(2, $"Connecting to {endpoint}...");
							tcpClient = await TcpHandler(endpoint.Address.ToString(), endpoint.Port);
						}
					}
				}
				catch
				{
					tcpClient?.Dispose();
					throw;
				}
				_tcpClient = tcpClient;
				_networkStream = _tcpClient.GetStream();
			}

			_dcSession.Salts?.Remove(DateTime.MaxValue);
			if (_networkStream != null)
			{
				byte protocolId = (byte)(_paddedMode ? 0xDD : 0xEE);
#if OBFUSCATION
				(_sendCtr, _recvCtr, preamble) = InitObfuscation(secret, protocolId, dcId);
#else
				preamble = new byte[] { protocolId, protocolId, protocolId, protocolId };
#endif
				await _networkStream.WriteAsync(preamble, 0, preamble.Length, _cts.Token);

				_reactorTask = Reactor(_networkStream, _cts);
			}
			_sendSemaphore.Release();

			try
			{
				if (_dcSession.AuthKeyID == 0)
					await CreateAuthorizationKey(this, _dcSession);

				if (_networkStream != null) _ = KeepAlive(_cts.Token);
				if (quickResume && _dcSession.Layer == Layer.Version && _dcSession.DataCenter != null && _session.MainDC != 0)
					TLConfig = new Config { this_dc = _session.MainDC, dc_options = _session.DcOptions };
				else
				{
					if (_dcSession.Layer != 0 && _dcSession.Layer != Layer.Version) _dcSession.Renew();
					var initParams = JSONValue.FromJsonElement(System.Text.Json.JsonDocument.Parse(Config("init_params")).RootElement);
					TLConfig = await this.InvokeWithLayer(Layer.Version,
						new TL.Methods.InitConnection<Config>
						{
							flags = TL.Methods.InitConnection<Config>.Flags.has_params,
							api_id = _session.ApiId,
							device_model = Config("device_model"),
							system_version = Config("system_version"),
							app_version = Config("app_version"),
							system_lang_code = Config("system_lang_code"),
							lang_pack = Config("lang_pack"),
							lang_code = Config("lang_code"),
							params_ = initParams,
							query = new TL.Methods.Help_GetConfig()
						});
					_dcSession.Layer = Layer.Version;
					_session.DcOptions = TLConfig.dc_options;
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
			}
			finally
			{
				if (_reactorTask != null) // client not disposed
					lock (_session) _session.Save();
			}
			Helpers.Log(2, $"Connected to {(TLConfig.test_mode ? "Test DC" : "DC")} {TLConfig.this_dc}... {TLConfig.flags & (Config.Flags)~0x18E00U}");
		}

		private async Task KeepAlive(CancellationToken ct)
		{
			int ping_id = _random.Next();
			while (!ct.IsCancellationRequested)
			{
				await Task.Delay(Math.Abs(PingInterval) * 1000, ct);
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

		/// <summary>Login as a user with given phone number (or resume previous session)<br/>Call this method again to provide additional requested login information</summary>
		/// <param name="loginInfo">First call should be with phone number<br/>Further calls should be with the requested configuration value</param>
		/// <returns>Configuration item requested to continue login, or <see langword="null"/> when login is successful<br/>
		/// Possible values: <b>verification_code</b>, <b>name</b> (signup), <b>password</b> (2FA), <b>email</b> &amp; <b>email_verification_code</b> (email registration)</returns>
		/// <exception cref="WTException"/><exception cref="RpcException"/>
		public async Task<string> Login(string loginInfo)
		{
			if (_loginCfg.request == default) RunLoginAsync(loginInfo);
			else
			{
				if (await _loginCfg.request.Task == null) return null;
				loginInfo ??= AskConfig(await _loginCfg.request.Task);
				_loginCfg.request = new();
				_loginCfg.response.SetResult(loginInfo);
			}
			return await _loginCfg.request.Task;
		}
		private (TaskCompletionSource<string> request, TaskCompletionSource<string> response) _loginCfg;
		private async void RunLoginAsync(string phone)
		{
			_loginCfg.request = new();
			var prevConfig = _config;
			_config = what =>
			{
				if (prevConfig(what) is string value) return value;
				switch (what)
				{
					case "phone_number": return phone;
					case "last_name": break;
					case "first_name": what = "name"; goto case "email";
					case "email": case "email_verification_code":
					case "password": case "verification_code": _loginCfg.response = new(); _loginCfg.request.SetResult(what); break;
					default: return null;
				};
				value = _loginCfg.response.Task.Result;
				if (what == "name" && value != null)
				{
					var lf = value.IndexOf('\n');
					if (lf < 0) lf = value.IndexOf(' ');
					_loginCfg.response = new();
					_loginCfg.response.SetResult(lf < 0 ? "" : value[(lf + 1)..]);
					value = lf < 0 ? value : value[0..lf];
					return value;
				}
				return value;
			};
			try
			{
				await ConnectAsync(); // start reactor on the current (UI?) context
				// Login logic is executed on TaskScheduler while request TCS are still received on current SynchronizationContext
				await Task.Run(() => LoginUserIfNeeded());
				_loginCfg.request.SetResult(null);
			}
			catch (Exception ex)
			{
				_loginCfg.request.SetException(ex);
			}
			finally
			{
				_config = prevConfig;
			}
		}

		/// <summary>Login as a bot (if not already logged-in).</summary>
		/// <param name="bot_token">bot token, or <see langword="null"/> if token is provided by Config callback</param>
		/// <remarks>Config callback may be queried for: <b>bot_token</b>
		/// <br/>Bots can only call API methods marked with [bots: ✓] in their documentation. </remarks>
		/// <returns>Detail about the logged-in bot</returns>
		public async Task<User> LoginBotIfNeeded(string bot_token = null)
		{
			await ConnectAsync();
			string botToken = bot_token ?? Config("bot_token");
			if (_session.UserId != 0) // a user is already logged-in
			{
				try
				{
					var users = await this.Users_GetUsers(InputUser.Self); // this calls also reenable incoming Updates
					var self = users[0] as User;
					if (self.id == long.Parse(botToken.Split(':')[0]))
					{
						_session.UserId = _dcSession.UserId = self.id;
						RaiseUpdates(self);
						return User = self;
					}
					Helpers.Log(3, $"Current logged user {self.id} mismatched bot_token. Logging out and in...");
				}
				catch (Exception ex)
				{
					Helpers.Log(4, $"Error while verifying current bot! ({ex.Message}) Proceeding to login...");
				}
				await this.Auth_LogOut();
				_session.UserId = _dcSession.UserId = 0;
				User = null;
			}
			var authorization = await this.Auth_ImportBotAuthorization(0, _session.ApiId, _apiHash ??= Config("api_hash"), botToken);
			return LoginAlreadyDone(authorization);
		}

		/// <summary>Login as a user (if not already logged-in).
		/// <br/><i>(this method calls <see cref="ConnectAsync">ConnectAsync</see> if necessary)</i></summary>
		/// <remarks>Config callback is queried for: <b>phone_number</b>, <b>verification_code</b> <br/>and eventually <b>first_name</b>, <b>last_name</b> (signup required), <b>password</b> (2FA auth), <b>email</b> &amp; <b>email_verification_code</b> (email registration), <b>user_id</b> (alt validation)</remarks>
		/// <param name="settings">(optional) Preference for verification_code sending</param>
		/// <param name="reloginOnFailedResume">Proceed to logout and login if active user session cannot be resumed successfully</param>
		/// <returns>Detail about the logged-in user
		/// <br/>Most methods of this class are async (Task), so please use <see langword="await"/> to get the result</returns>
		public async Task<User> LoginUserIfNeeded(CodeSettings settings = null, bool reloginOnFailedResume = true)
		{
			await ConnectAsync();
			string phone_number = null;
			if (_session.UserId != 0) // a user is already logged-in
			{
				try
				{
					var users = await this.Users_GetUsers(InputUser.Self); // this call also reenable incoming Updates
					var self = users[0] as User;
					// check user_id or phone_number match currently logged-in user
					if ((long.TryParse(_config("user_id"), out long id) && (id == -1 || self.id == id)) ||
						self.phone == string.Concat((phone_number = Config("phone_number")).Where(char.IsDigit)))
					{
						_session.UserId = _dcSession.UserId = self.id;
						RaiseUpdates(self);
						return User = self;
					}
					var mismatch = $"Current logged user {self.id} mismatched user_id or phone_number";
					Helpers.Log(3, mismatch);
					if (!reloginOnFailedResume) throw new WTException(mismatch);
				}
				catch (RpcException ex) when (reloginOnFailedResume)
				{
					Helpers.Log(4, $"Error while fetching current user! ({ex.Message})");
				}
				Helpers.Log(3, $"Proceeding to logout and login...");
				await this.Auth_LogOut();
				_session.UserId = _dcSession.UserId = 0;
				User = null;
			}
			phone_number ??= Config("phone_number");
			Auth_SentCodeBase sentCodeBase;
#pragma warning disable CS0618 // Auth_* methods are marked as obsolete
			try
			{
				sentCodeBase = await this.Auth_SendCode(phone_number, _session.ApiId, _apiHash ??= Config("api_hash"), settings ??= new());
			}
			catch (RpcException ex) when (ex.Code == 500 && ex.Message == "AUTH_RESTART")
			{
				sentCodeBase = await this.Auth_SendCode(phone_number, _session.ApiId, _apiHash, settings);
			}
			Auth_AuthorizationBase authorization = null;
			string phone_code_hash = null, email = null;
			try
			{
				if (sentCodeBase is Auth_SentCode { type: Auth_SentCodeTypeSetUpEmailRequired setupEmail } setupSentCode)
				{
					phone_code_hash = setupSentCode.phone_code_hash;
					Helpers.Log(3, "A login email is required");
					RaiseUpdates(sentCodeBase);
					email = _config("email");
					if (string.IsNullOrEmpty(email))
						sentCodeBase = await this.Auth_ResendCode(phone_number, phone_code_hash);
					else
					{
						var purpose = new EmailVerifyPurposeLoginSetup { phone_number = phone_number, phone_code_hash = phone_code_hash };
						if (email is not "Google" and not "Apple")
						{
							var sentEmail = await this.Account_SendVerifyEmailCode(purpose, email);
							Helpers.Log(3, "An email verification code has been sent to " + sentEmail.email_pattern);
							RaiseUpdates(sentEmail);
						}
						Account_EmailVerified verified = null;
						for (int retry = 1; verified == null; retry++)
							try
							{
								var code = await ConfigAsync("email_verification_code");
								verified = await this.Account_VerifyEmail(purpose, EmailVerification(email, code));
							}
							catch (RpcException e) when (e.Code == 400 && e.Message is "CODE_INVALID" or "EMAIL_TOKEN_INVALID")
							{
								Helpers.Log(4, "Wrong email verification code!");
								if (retry >= MaxCodePwdAttempts) throw;
							}
						if (verified is Account_EmailVerifiedLogin verifiedLogin) // (it should always be)
							sentCodeBase = verifiedLogin.sent_code;
					}
				}
			resent:
				if (sentCodeBase is Auth_SentCodeSuccess success)
					authorization = success.authorization;
				else if (sentCodeBase is Auth_SentCode sentCode)
				{
					phone_code_hash = sentCode.phone_code_hash;
					var timeout = DateTime.UtcNow + TimeSpan.FromSeconds(sentCode.timeout);
					Helpers.Log(3, $"A verification code has been sent via {sentCode.type.GetType().Name[17..]}");
					RaiseUpdates(sentCode);
					if (sentCode.type is Auth_SentCodeTypeFirebaseSms firebaseSms)
					{
						var token = await ConfigAsync("firebase");
						int index = token?.IndexOf(':') ?? -1;
						if (!(index > 0 && token[..index] switch
						{
							"safety_net_token" => await this.Auth_RequestFirebaseSms(phone_number, phone_code_hash, safety_net_token: token[(index + 1)..]),
							"ios_push_secret" => await this.Auth_RequestFirebaseSms(phone_number, phone_code_hash, ios_push_secret: token[(index + 1)..]),
							_ => false
						}))
						{
							sentCodeBase = await this.Auth_ResendCode(phone_number, phone_code_hash);
							goto resent;
						}
					}
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
								sentCodeBase = await this.Auth_ResendCode(phone_number, phone_code_hash);
								goto resent;
							}
							if (sentCode.type is Auth_SentCodeTypeEmailCode)
								authorization = await this.Auth_SignIn(phone_number, phone_code_hash, null, EmailVerification(email ??= _config("email"), verification_code));
							else
								authorization = await this.Auth_SignIn(phone_number, phone_code_hash, verification_code);
						}
						catch (RpcException e) when (e.Code == 400 && e.Message == "PHONE_CODE_INVALID")
						{
							Helpers.Log(4, "Wrong verification code!");
							if (retry >= MaxCodePwdAttempts) throw;
						}
						catch (RpcException e) when (e.Code == 401 && e.Message == "SESSION_PASSWORD_NEEDED")
						{
							authorization = await LoginPasswordNeeded();
						}
				}

				static EmailVerification EmailVerification(string email, string code) => email switch
				{
					"Google" => new EmailVerificationGoogle { token = code },
					"Apple" => new EmailVerificationApple { token = code },
					_ => new EmailVerificationCode { code = code }
				};
			}
			catch (Exception ex) when (ex is not RpcException { Message: "FLOOD_WAIT_X" })
			{
				try { await this.Auth_CancelCode(phone_number, phone_code_hash); } catch { }
				throw;
			}
			if (authorization is Auth_AuthorizationSignUpRequired signUpRequired)
			{
				var waitUntil = DateTime.UtcNow.AddSeconds(3);
				RaiseUpdates(signUpRequired); // give caller the possibility to read and accept TOS
				var first_name = Config("first_name");
				var last_name = Config("last_name");
				var wait = waitUntil - DateTime.UtcNow;
				if (wait > TimeSpan.Zero) await Task.Delay(wait); // we get a FLOOD_WAIT_3 if we SignUp too fast
				authorization = await this.Auth_SignUp(phone_number, phone_code_hash, first_name, last_name);
			}
#pragma warning restore CS0618
			LoginAlreadyDone(authorization);
			if (User.phone != string.Concat(phone_number.Where(char.IsDigit)))
				Helpers.Log(3, $"Mismatched phone_number (+{User.phone} != {phone_number}). Fix this to avoid verification code each time");
			return User;
		}

		/// <summary>Login via QR code</summary>
		/// <param name="qrDisplay">Callback to display the login url as QR code to the user (<a href="https://www.nuget.org/packages/QRCoder/">QRCoder library</a> can help you)</param>
		/// <param name="except_ids">(optional) To prevent logging as these user ids</param>
		/// <param name="logoutFirst">If session is already connected to a user, this method will first log out.<br/>You can also check property <see cref="UserId"/> before calling this method.</param>
		/// <param name="ct">If you need to abort the method before login is completed</param>
		/// <returns>Detail about the logged-in user</returns>
		public async Task<User> LoginWithQRCode(Action<string> qrDisplay, long[] except_ids = null, bool logoutFirst = true, CancellationToken ct = default)
		{
			await ConnectAsync();
			if (logoutFirst && _session.UserId != 0) // a user is already logged-in
			{
				await this.Auth_LogOut();
				_session.UserId = _dcSession.UserId = 0;
				User = null;
			}
			var tcs = new TaskCompletionSource<bool>();
			OnUpdates += CatchQRUpdate;
			try
			{
				while (!ct.IsCancellationRequested)
				{
					var ltb = await this.Auth_ExportLoginToken(_session.ApiId, _apiHash ??= Config("api_hash"), except_ids);
				retry:
					switch (ltb)
					{
						case Auth_LoginToken lt:
							var url = "tg://login?token=" + System.Convert.ToBase64String(lt.token).Replace('/', '_').Replace('+', '-');
							Helpers.Log(3, $"Waiting for this QR code login to be accepted: " + url);
							qrDisplay(url);
							if (lt.expires - DateTime.UtcNow is { Ticks: >= 0 } delay)
								await Task.WhenAny(Task.Delay(delay, ct), tcs.Task);
							break;
						case Auth_LoginTokenMigrateTo ltmt:
							await MigrateToDC(ltmt.dc_id);
							ltb = await this.Auth_ImportLoginToken(ltmt.token);
							goto retry;
						case Auth_LoginTokenSuccess lts:
							return LoginAlreadyDone(lts.authorization);
					}
				}
				ct.ThrowIfCancellationRequested();
				return null;
			}
			catch (RpcException e) when (e.Code == 401 && e.Message == "SESSION_PASSWORD_NEEDED")
			{
				return LoginAlreadyDone(await LoginPasswordNeeded());
			}
			finally
			{
				OnUpdates -= CatchQRUpdate;
			}

			Task CatchQRUpdate(UpdatesBase updates)
			{
				if (updates.UpdateList.OfType<UpdateLoginToken>().Any())
					tcs.TrySetResult(true);
				return Task.CompletedTask;
			}
		}

		private async Task<Auth_AuthorizationBase> LoginPasswordNeeded()
		{
			for (int pwdRetry = 1; ; pwdRetry++)
				try
				{
					var accountPassword = await this.Account_GetPassword();
					RaiseUpdates(accountPassword);
					var checkPasswordSRP = await Check2FA(accountPassword, () => ConfigAsync("password"));
					return await this.Auth_CheckPassword(checkPasswordSRP);
				}
				catch (RpcException pe) when (pe.Code == 400 && pe.Message == "PASSWORD_HASH_INVALID")
				{
					Helpers.Log(4, "Wrong password!");
					if (pwdRetry >= MaxCodePwdAttempts) throw;
				}
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
			if (authorization is not Auth_Authorization { user: User self })
				throw new WTException("Failed to get Authorization: " + authorization.GetType().Name);
			_session.UserId = _dcSession.UserId = self.id;
			lock (_session) _session.Save();
			RaiseUpdates(self);
			return User = self;
		}

		private MsgsAck CheckMsgsToAck()
		{
			lock (_msgsToAck)
			{
				if (_msgsToAck.Count == 0) return null;
				var msgsAck = new MsgsAck { msg_ids = [.. _msgsToAck] };
				_msgsToAck.Clear();
				return msgsAck;
			}
		}

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

		private async Task SendAsync(IObject msg, bool isContent, Rpc rpc = null)
		{
			if (_reactorTask == null) throw new WTException("You must connect to Telegram first");
			isContent &= _dcSession.AuthKeyID != 0;
			var (msgId, seqno) = NewMsgId(isContent);
			if (rpc != null)
				lock (_pendingRpcs)
					_pendingRpcs[rpc.msgId = msgId] = rpc;
			if (isContent)
			{
				List<_Message> messages = null;
				if (_httpWait != null && NewMsgId(false) is var (hwId, hwSeqno))
					(messages ??= []).Add(new(hwId, hwSeqno, _httpWait));
				if (CheckMsgsToAck() is MsgsAck msgsAck && NewMsgId(false) is var (ackId, ackSeqno))
					(messages ??= []).Add(new(ackId, ackSeqno, msgsAck));
				if (messages != null)
				{
					messages.Add(new(msgId, seqno, msg));
					await SendAsync(new MsgContainer { messages = messages }, false);
					return;
				}
			}
			Task receiveTask = null;
			var sem = _sendSemaphore;
			await sem.WaitAsync(_cts.Token);
			try
			{
				using var memStream = new MemoryStream(1024);
				using var writer = new BinaryWriter(memStream);
				writer.Write(0);                // int32 payload_len (to be patched with payload length)

				if (_dcSession.AuthKeyID == 0) // send unencrypted message
				{
					if (_bareRpc == null) throw new WTException($"Shouldn't send a {msg.GetType().Name} unencrypted");
					writer.Write(0L);                       // int64 auth_key_id = 0 (Unencrypted)
					writer.Write(msgId);                    // int64 message_id
					writer.Write(0);                        // int32 message_data_length (to be patched)
					Helpers.Log(1, $"{_dcSession.DcID}>Sending   {msg.GetType().Name.TrimEnd('_')}...");
					writer.WriteTLObject(msg);              // bytes message_data
					BinaryPrimitives.WriteInt32LittleEndian(memStream.GetBuffer().AsSpan(20), (int)memStream.Length - 24);    // patch message_data_length
				}
				else
				{
					CheckSalt();
					using var clearStream = new MemoryStream(1024);
					using var clearWriter = new BinaryWriter(clearStream);
					clearWriter.Write(_dcSession.AuthKey, 88, 32);
					clearWriter.Write(_dcSession.Salt);     // int64 salt
					clearWriter.Write(_dcSession.Id);       // int64 session_id
					clearWriter.Write(msgId);               // int64 message_id
					clearWriter.Write(seqno);               // int32 msg_seqno
					clearWriter.Write(0);                   // int32 message_data_length (to be patched)
					if ((seqno & 1) != 0)
						Helpers.Log(1, $"{_dcSession.DcID}>Sending   {msg.GetType().Name.TrimEnd('_'),-40} #{(short)msgId.GetHashCode():X4}");
					else
						Helpers.Log(1, $"{_dcSession.DcID}>Sending   {msg.GetType().Name.TrimEnd('_'),-40} {MsgIdToStamp(msgId):u} (svc)");
					clearWriter.WriteTLObject(msg);         // bytes message_data
					int clearLength = (int)clearStream.Length - 32;  // length before padding (= 32 + message_data_length)
					int padding = (0x7FFFFFF0 - clearLength) % 16;
					padding += _random.Next(2, 16) * 16;        // MTProto 2.0 padding must be between 12..1024 with total length divisible by 16
					clearStream.SetLength(32 + clearLength + padding);
					byte[] clearBuffer = clearStream.GetBuffer();
					BinaryPrimitives.WriteInt32LittleEndian(clearBuffer.AsSpan(60), clearLength - 32);    // patch message_data_length
					RNG.GetBytes(clearBuffer, 32 + clearLength, padding);
					var msgKeyLarge = _sha256.ComputeHash(clearBuffer, 0, 32 + clearLength + padding);
					const int msgKeyOffset = 8; // msg_key = middle 128-bits of SHA256(authkey_part+plaintext+padding)
					byte[] encrypted_data = EncryptDecryptMessage(clearBuffer.AsSpan(32, clearLength + padding), true, 0, _dcSession.AuthKey, msgKeyLarge, msgKeyOffset, _sha256);

					writer.Write(_dcSession.AuthKeyID);             // int64 auth_key_id
					writer.Write(msgKeyLarge, msgKeyOffset, 16);    // int128 msg_key
					writer.Write(encrypted_data);                   // bytes encrypted_data
				}
				if (_paddedMode) // Padded intermediate mode => append random padding
				{
					var padding = new byte[_random.Next(_dcSession.AuthKeyID == 0 ? 257 : 16)];
					RNG.GetBytes(padding);
					writer.Write(padding);
				}
				var buffer = memStream.GetBuffer();
				int frameLength = (int)memStream.Length;
				BinaryPrimitives.WriteInt32LittleEndian(buffer, frameLength - 4); // patch payload_len with correct value
#if OBFUSCATION
				_sendCtr?.EncryptDecrypt(buffer, frameLength);
#endif
				if (_networkStream != null)
					await _networkStream.WriteAsync(buffer, 0, frameLength);
				else
					receiveTask = SendReceiveHttp(buffer, frameLength);
				_lastSentMsg = msg;
			}
			finally
			{
				sem.Release();
			}
			if (receiveTask != null) await receiveTask;
		}

		private async Task SendReceiveHttp(byte[] buffer, int frameLength)
		{
			var endpoint = _dcSession?.EndPoint ?? GetDefaultEndpoint(out _);
			var content = new ByteArrayContent(buffer, 4, frameLength - 4);
			var response = await _httpClient.PostAsync($"http://{endpoint}/api", content, _cts.Token);
			if (response.StatusCode != HttpStatusCode.OK)
				throw new RpcException((int)response.StatusCode, TransportError((int)response.StatusCode));
			var data = await response.Content.ReadAsByteArrayAsync();
			var obj = ReadFrame(data, data.Length);
			if (obj != null)
				await HandleMessageAsync(obj);
		}

		/// <summary>Long poll on HTTP connections</summary>
		/// <param name="httpWait">Parameters for the long poll. Leave <see langword="null"/> for the default 25 seconds.</param>
		/// <remarks>⚠️ Telegram servers don't seem to support other parameter than <see langword="null"/> correctly</remarks>
		public async Task HttpWait(HttpWait httpWait = null)
		{
			if (_networkStream != null) throw new InvalidOperationException("Can't use HttpWait over TCP connection");
			var container = new MsgContainer { messages = [] };
			if (httpWait != null && NewMsgId(false) is var (hwId, hwSeqno))
				container.messages.Add(new(hwId, hwSeqno, httpWait));
			if (CheckMsgsToAck() is MsgsAck msgsAck && NewMsgId(false) is var (ackId, ackSeqno))
				container.messages.Add(new(ackId, ackSeqno, msgsAck));
			await SendAsync(container, false);
		}

		internal async Task<T> InvokeBare<T>(IMethod<T> request)
		{
			if (_bareRpc != null) throw new WTException("A bare request is already undergoing");
		retry:
			var bareRpc = _bareRpc = new Rpc { type = typeof(T) };
			await SendAsync(request, false, _bareRpc);
			var result = await bareRpc.Task;
			if (result is ReactorError) goto retry;
			return (T)result;
		}

		/// <summary>Call the given TL method <i>(You shouldn't need to use this method directly)</i></summary>
		/// <typeparam name="T">Expected type of the returned object</typeparam>
		/// <param name="query">TL method structure</param>
		/// <returns>Wait for the reply and return the resulting object, or throws an RpcException if an error was replied</returns>
		public async Task<T> Invoke<T>(IMethod<T> query)
		{
			if (_dcSession.WithoutUpdates && query is not IMethod<Pong> and not IMethod<FutureSalts>)
				query = new TL.Methods.InvokeWithoutUpdates<T> { query = query };
			bool got503 = false;
		retry:
			var rpc = new Rpc { type = typeof(T) };
			await SendAsync(query, true, rpc);
			while (_httpClient != null && !rpc.Task.IsCompleted)
				await HttpWait(_httpWait); // need to wait a bit more in some case

			var result = await rpc.Task;
			switch (result)
			{
				case null: return default;
				case T resultT: return resultT;
				case RpcError { error_code: var code, error_message: var message }:
					int x = -1;
					for (int index = message.Length - 1; index > 0 && (index = message.LastIndexOf('_', index - 1)) >= 0;)
						if (message[index + 1] is >= '0' and <= '9')
						{
							int end = ++index;
							do end++; while (end < message.Length && message[end] is >= '0' and <= '9');
							x = int.Parse(message[index..end]);
							message = $"{message[0..index]}X{message[end..]}";
							break;
						}

					if (code == 303 && message.EndsWith("_MIGRATE_X"))
					{
						if (message != "FILE_MIGRATE_X")
						{
							await MigrateToDC(x);
							goto retry;
						}
					}
					else if (code == 420 && (message.EndsWith("_WAIT_X") || message.EndsWith("_DELAY_X")))
					{
						if (x <= FloodRetryThreshold)
						{
							if (x == 0) x =1;
							await Task.Delay(x * 1000);
							goto retry;
						}
					}
					else if (code == -503 && !got503)
					{
						got503 = true;
						goto retry;
					}
					else if (code == 500 && message == "AUTH_RESTART")
					{
						_session.UserId = 0; // force a full login authorization flow, next time
						User = null;
						lock (_session) _session.Save();
					}
					throw new RpcException(code, message, x);
				case ReactorError:
					goto retry;
				default:
					throw new WTException($"{query.GetType().Name} call got a result of type {result.GetType().Name} instead of {typeof(T).Name}");
			}
		}

		private async Task MigrateToDC(int dcId)
		{
			// this is a hack to migrate _dcSession in-place (staying in same Client):
			Session.DCSession dcSession;
			lock (_session)
				dcSession = GetOrCreateDCSession(dcId, _dcSession.DataCenter.flags);
			await ResetAsync(false, false);
			_session.MainDC = dcId;
			_dcSession.Client = null;
			_dcSession = dcSession;
			_dcSession.Client = this;
			await ConnectAsync();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public async Task<T> InvokeAffected<T>(IMethod<T> query, long peerId) where T : Messages_AffectedMessages
		{
			var result = await Invoke(query);
			if (OnOwnUpdates != null)
				RaiseOwnUpdates(new UpdateShort
				{
					update = new UpdateAffectedMessages { mbox_id = peerId, pts = result.pts, pts_count = result.pts_count },
					date = MsgIdToStamp(_lastRecvMsgId)
				});
			return result;
		}
	}
}
