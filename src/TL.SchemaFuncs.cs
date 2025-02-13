using System;
using System.Threading.Tasks;
using TL.Methods;
using Client = WTelegram.Client;

namespace TL
{
	public static class SchemaExtensions
	{
		/// <summary>Invokes a query after successful completion of one of the previous queries.		<para>See <a href="https://corefork.telegram.org/method/invokeAfterMsg"/></para></summary>
		/// <param name="msg_id">Message identifier on which a current query depends</param>
		/// <param name="query">The query itself</param>
		public static Task<X> InvokeAfterMsg<X>(this Client client, long msg_id, IMethod<X> query)
			=> client.Invoke(new InvokeAfterMsg<X>
			{
				msg_id = msg_id,
				query = query,
			});

		/// <summary>Invokes a query after a successful completion of previous queries		<para>See <a href="https://corefork.telegram.org/method/invokeAfterMsgs"/></para></summary>
		/// <param name="msg_ids">List of messages on which a current query depends</param>
		/// <param name="query">The query itself</param>
		public static Task<X> InvokeAfterMsgs<X>(this Client client, long[] msg_ids, IMethod<X> query)
			=> client.Invoke(new InvokeAfterMsgs<X>
			{
				msg_ids = msg_ids,
				query = query,
			});

		/// <summary>Initialize connection		<para>See <a href="https://corefork.telegram.org/method/initConnection"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/initConnection#possible-errors">details</a>)</para></summary>
		/// <param name="api_id">Application identifier (see. <a href="https://corefork.telegram.org/myapp">App configuration</a>)</param>
		/// <param name="device_model">Device model</param>
		/// <param name="system_version">Operation system version</param>
		/// <param name="app_version">Application version</param>
		/// <param name="system_lang_code">Code for the language used on the device's OS, ISO 639-1 standard</param>
		/// <param name="lang_pack">Platform identifier (i.e. <c>android</c>, <c>tdesktop</c>, etc).</param>
		/// <param name="lang_code">Either an ISO 639-1 language code or a language pack name obtained from a <a href="https://corefork.telegram.org/api/links#language-pack-links">language pack link</a>.</param>
		/// <param name="proxy">Info about an MTProto proxy</param>
		/// <param name="params_">Additional initConnection parameters. <br/>For now, only the <c>tz_offset</c> field is supported, for specifying the timezone offset in seconds.</param>
		/// <param name="query">The query itself</param>
		public static Task<X> InitConnection<X>(this Client client, int api_id, string device_model, string system_version, string app_version, string system_lang_code, string lang_pack, string lang_code, IMethod<X> query, InputClientProxy proxy = null, JSONValue params_ = null)
			=> client.Invoke(new InitConnection<X>
			{
				flags = (InitConnection<X>.Flags)((proxy != null ? 0x1 : 0) | (params_ != null ? 0x2 : 0)),
				api_id = api_id,
				device_model = device_model,
				system_version = system_version,
				app_version = app_version,
				system_lang_code = system_lang_code,
				lang_pack = lang_pack,
				lang_code = lang_code,
				proxy = proxy,
				params_ = params_,
				query = query,
			});

		/// <summary>Invoke the specified query using the specified API <a href="https://corefork.telegram.org/api/invoking#layers">layer</a>		<para>See <a href="https://corefork.telegram.org/method/invokeWithLayer"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403,406 (<a href="https://corefork.telegram.org/method/invokeWithLayer#possible-errors">details</a>)</para></summary>
		/// <param name="layer">The layer to use</param>
		/// <param name="query">The query</param>
		public static Task<X> InvokeWithLayer<X>(this Client client, int layer, IMethod<X> query)
			=> client.Invoke(new InvokeWithLayer<X>
			{
				layer = layer,
				query = query,
			});

		/// <summary>Invoke a request without subscribing the used connection for <a href="https://corefork.telegram.org/api/updates">updates</a> (this is enabled by default for <a href="https://corefork.telegram.org/api/files">file queries</a>).		<para>See <a href="https://corefork.telegram.org/method/invokeWithoutUpdates"/></para></summary>
		/// <param name="query">The query</param>
		public static Task<X> InvokeWithoutUpdates<X>(this Client client, IMethod<X> query)
			=> client.Invoke(new InvokeWithoutUpdates<X>
			{
				query = query,
			});

		/// <summary>Invoke with the given message range		<para>See <a href="https://corefork.telegram.org/method/invokeWithMessagesRange"/></para></summary>
		/// <param name="range">Message range</param>
		/// <param name="query">Query</param>
		public static Task<X> InvokeWithMessagesRange<X>(this Client client, MessageRange range, IMethod<X> query)
			=> client.Invoke(new InvokeWithMessagesRange<X>
			{
				range = range,
				query = query,
			});

		/// <summary>Invoke a method within a <a href="https://corefork.telegram.org/api/takeout">takeout session, see here » for more info</a>.		<para>See <a href="https://corefork.telegram.org/method/invokeWithTakeout"/></para></summary>
		/// <param name="takeout_id"><a href="https://corefork.telegram.org/api/takeout">Takeout session ID »</a></param>
		/// <param name="query">Query</param>
		public static Task<X> InvokeWithTakeout<X>(this Client client, long takeout_id, IMethod<X> query)
			=> client.Invoke(new InvokeWithTakeout<X>
			{
				takeout_id = takeout_id,
				query = query,
			});

		/// <summary>Invoke a method using a <a href="https://corefork.telegram.org/api/business#connected-bots">Telegram Business Bot connection, see here » for more info, including a list of the methods that can be wrapped in this constructor</a>.		<para>See <a href="https://corefork.telegram.org/method/invokeWithBusinessConnection"/></para></summary>
		/// <param name="connection_id">Business connection ID.</param>
		/// <param name="query">The actual query.</param>
		public static Task<X> InvokeWithBusinessConnection<X>(this Client client, string connection_id, IMethod<X> query)
			=> client.Invoke(new InvokeWithBusinessConnection<X>
			{
				connection_id = connection_id,
				query = query,
			});

		/// <summary>Official clients only, invoke with Google Play Integrity token.		<para>See <a href="https://corefork.telegram.org/method/invokeWithGooglePlayIntegrity"/></para></summary>
		/// <param name="nonce">Nonce.</param>
		/// <param name="token">Token.</param>
		/// <param name="query">Query.</param>
		public static Task<X> InvokeWithGooglePlayIntegrity<X>(this Client client, string nonce, string token, IMethod<X> query)
			=> client.Invoke(new InvokeWithGooglePlayIntegrity<X>
			{
				nonce = nonce,
				token = token,
				query = query,
			});

		/// <summary>Official clients only, invoke with Apple push verification.		<para>See <a href="https://corefork.telegram.org/method/invokeWithApnsSecret"/></para></summary>
		/// <param name="nonce">Nonce.</param>
		/// <param name="secret">Secret.</param>
		/// <param name="query">Query.</param>
		public static Task<X> InvokeWithApnsSecret<X>(this Client client, string nonce, string secret, IMethod<X> query)
			=> client.Invoke(new InvokeWithApnsSecret<X>
			{
				nonce = nonce,
				secret = secret,
				query = query,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/invokeWithReCaptcha"/></para></summary>
		public static Task<X> InvokeWithReCaptcha<X>(this Client client, string token, IMethod<X> query)
			=> client.Invoke(new InvokeWithReCaptcha<X>
			{
				token = token,
				query = query,
			});

		/// <summary>Send the verification code for login		<para>See <a href="https://corefork.telegram.org/method/auth.sendCode"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406,500 (<a href="https://corefork.telegram.org/method/auth.sendCode#possible-errors">details</a>)</para></summary>
		/// <param name="phone_number">Phone number in international format</param>
		/// <param name="api_id">Application identifier (see <a href="https://corefork.telegram.org/myapp">App configuration</a>)</param>
		/// <param name="api_hash">Application secret hash (see <a href="https://corefork.telegram.org/myapp">App configuration</a>)</param>
		/// <param name="settings">Settings for the code type to send</param>
		[Obsolete("Use LoginUserIfNeeded instead of this method. See https://wiz0u.github.io/WTelegramClient/FAQ#tlsharp")]
		public static Task<Auth_SentCodeBase> Auth_SendCode(this Client client, string phone_number, int api_id, string api_hash, CodeSettings settings)
			=> client.Invoke(new Auth_SendCode
			{
				phone_number = phone_number,
				api_id = api_id,
				api_hash = api_hash,
				settings = settings,
			});

		/// <summary>Registers a validated phone number in the system.		<para>See <a href="https://corefork.telegram.org/method/auth.signUp"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/auth.signUp#possible-errors">details</a>)</para></summary>
		/// <param name="no_joined_notifications">If set, users on Telegram that have already added <c>phone_number</c> to their contacts will <em>not</em> receive signup notifications about this user.</param>
		/// <param name="phone_number">Phone number in the international format</param>
		/// <param name="phone_code_hash">SMS-message ID</param>
		/// <param name="first_name">New user first name</param>
		/// <param name="last_name">New user last name</param>
		[Obsolete("Use LoginUserIfNeeded instead of this method. See https://wiz0u.github.io/WTelegramClient/FAQ#tlsharp")]
		public static Task<Auth_AuthorizationBase> Auth_SignUp(this Client client, string phone_number, string phone_code_hash, string first_name, string last_name, bool no_joined_notifications = false)
			=> client.Invoke(new Auth_SignUp
			{
				flags = (Auth_SignUp.Flags)(no_joined_notifications ? 0x1 : 0),
				phone_number = phone_number,
				phone_code_hash = phone_code_hash,
				first_name = first_name,
				last_name = last_name,
			});

		/// <summary>Signs in a user with a validated phone number.		<para>See <a href="https://corefork.telegram.org/method/auth.signIn"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406,500 (<a href="https://corefork.telegram.org/method/auth.signIn#possible-errors">details</a>)</para></summary>
		/// <param name="phone_number">Phone number in the international format</param>
		/// <param name="phone_code_hash">SMS-message ID, obtained from <see cref="Auth_SendCode">Auth_SendCode</see></param>
		/// <param name="phone_code">Valid numerical code from the SMS-message</param>
		/// <param name="email_verification">Email verification code or token</param>
		[Obsolete("Use LoginUserIfNeeded instead of this method. See https://wiz0u.github.io/WTelegramClient/FAQ#tlsharp")]
		public static Task<Auth_AuthorizationBase> Auth_SignIn(this Client client, string phone_number, string phone_code_hash, string phone_code = null, EmailVerification email_verification = null)
			=> client.Invoke(new Auth_SignIn
			{
				flags = (Auth_SignIn.Flags)((phone_code != null ? 0x1 : 0) | (email_verification != null ? 0x2 : 0)),
				phone_number = phone_number,
				phone_code_hash = phone_code_hash,
				phone_code = phone_code,
				email_verification = email_verification,
			});

		/// <summary>Logs out the user.		<para>See <a href="https://corefork.telegram.org/method/auth.logOut"/> [bots: ✓]</para></summary>
		public static Task<Auth_LoggedOut> Auth_LogOut(this Client client)
			=> client.Invoke(new Auth_LogOut
			{
			});

		/// <summary>Terminates all user's authorized sessions except for the current one.		<para>See <a href="https://corefork.telegram.org/method/auth.resetAuthorizations"/></para>		<para>Possible <see cref="RpcException"/> codes: 406 (<a href="https://corefork.telegram.org/method/auth.resetAuthorizations#possible-errors">details</a>)</para></summary>
		public static Task<bool> Auth_ResetAuthorizations(this Client client)
			=> client.Invoke(new Auth_ResetAuthorizations
			{
			});

		/// <summary>Returns data for copying authorization to another data-center.		<para>See <a href="https://corefork.telegram.org/method/auth.exportAuthorization"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/auth.exportAuthorization#possible-errors">details</a>)</para></summary>
		/// <param name="dc_id">Number of a target data-center</param>
		public static Task<Auth_ExportedAuthorization> Auth_ExportAuthorization(this Client client, int dc_id)
			=> client.Invoke(new Auth_ExportAuthorization
			{
				dc_id = dc_id,
			});

		/// <summary>Logs in a user using a key transmitted from his native data-center.		<para>See <a href="https://corefork.telegram.org/method/auth.importAuthorization"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/auth.importAuthorization#possible-errors">details</a>)</para></summary>
		/// <param name="id">User ID</param>
		/// <param name="bytes">Authorization key</param>
		public static Task<Auth_AuthorizationBase> Auth_ImportAuthorization(this Client client, long id, byte[] bytes)
			=> client.Invoke(new Auth_ImportAuthorization
			{
				id = id,
				bytes = bytes,
			});

		/// <summary>Binds a temporary authorization key <c>temp_auth_key_id</c> to the permanent authorization key <c>perm_auth_key_id</c>. Each permanent key may only be bound to one temporary key at a time, binding a new temporary key overwrites the previous one.		<para>See <a href="https://corefork.telegram.org/method/auth.bindTempAuthKey"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/auth.bindTempAuthKey#possible-errors">details</a>)</para></summary>
		/// <param name="perm_auth_key_id">Permanent auth_key_id to bind to</param>
		/// <param name="nonce">Random long from <a href="https://corefork.telegram.org/method/auth.bindTempAuthKey#binding-message-contents">Binding message contents</a></param>
		/// <param name="expires_at">Unix timestamp to invalidate temporary key, see <a href="https://corefork.telegram.org/method/auth.bindTempAuthKey#binding-message-contents">Binding message contents</a></param>
		/// <param name="encrypted_message">See <a href="https://corefork.telegram.org/method/auth.bindTempAuthKey#generating-encrypted-message">Generating encrypted_message</a></param>
		public static Task<bool> Auth_BindTempAuthKey(this Client client, long perm_auth_key_id, long nonce, DateTime expires_at, byte[] encrypted_message)
			=> client.Invoke(new Auth_BindTempAuthKey
			{
				perm_auth_key_id = perm_auth_key_id,
				nonce = nonce,
				expires_at = expires_at,
				encrypted_message = encrypted_message,
			});

		/// <summary>Login as a bot		<para>See <a href="https://corefork.telegram.org/method/auth.importBotAuthorization"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/auth.importBotAuthorization#possible-errors">details</a>)</para></summary>
		/// <param name="flags">Reserved for future use</param>
		/// <param name="api_id">Application identifier (see. <a href="https://corefork.telegram.org/myapp">App configuration</a>)</param>
		/// <param name="api_hash">Application identifier hash (see. <a href="https://corefork.telegram.org/myapp">App configuration</a>)</param>
		/// <param name="bot_auth_token">Bot token (see <a href="https://corefork.telegram.org/bots">bots</a>)</param>
		public static Task<Auth_AuthorizationBase> Auth_ImportBotAuthorization(this Client client, int flags, int api_id, string api_hash, string bot_auth_token)
			=> client.Invoke(new Auth_ImportBotAuthorization
			{
				flags = flags,
				api_id = api_id,
				api_hash = api_hash,
				bot_auth_token = bot_auth_token,
			});

		/// <summary>Try logging to an account protected by a <a href="https://corefork.telegram.org/api/srp">2FA password</a>.		<para>See <a href="https://corefork.telegram.org/method/auth.checkPassword"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,500 (<a href="https://corefork.telegram.org/method/auth.checkPassword#possible-errors">details</a>)</para></summary>
		/// <param name="password">The account's password (see <a href="https://corefork.telegram.org/api/srp">SRP</a>)</param>
		public static Task<Auth_AuthorizationBase> Auth_CheckPassword(this Client client, InputCheckPasswordSRP password)
			=> client.Invoke(new Auth_CheckPassword
			{
				password = password,
			});

		/// <summary>Request recovery code of a <a href="https://corefork.telegram.org/api/srp">2FA password</a>, only for accounts with a <a href="https://corefork.telegram.org/api/srp#email-verification">recovery email configured</a>.		<para>See <a href="https://corefork.telegram.org/method/auth.requestPasswordRecovery"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/auth.requestPasswordRecovery#possible-errors">details</a>)</para></summary>
		public static Task<Auth_PasswordRecovery> Auth_RequestPasswordRecovery(this Client client)
			=> client.Invoke(new Auth_RequestPasswordRecovery
			{
			});

		/// <summary>Reset the <a href="https://corefork.telegram.org/api/srp">2FA password</a> using the recovery code sent using <see cref="Auth_RequestPasswordRecovery">Auth_RequestPasswordRecovery</see>.		<para>See <a href="https://corefork.telegram.org/method/auth.recoverPassword"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/auth.recoverPassword#possible-errors">details</a>)</para></summary>
		/// <param name="code">Code received via email</param>
		/// <param name="new_settings">New password</param>
		public static Task<Auth_AuthorizationBase> Auth_RecoverPassword(this Client client, string code, Account_PasswordInputSettings new_settings = null)
			=> client.Invoke(new Auth_RecoverPassword
			{
				flags = (Auth_RecoverPassword.Flags)(new_settings != null ? 0x1 : 0),
				code = code,
				new_settings = new_settings,
			});

		/// <summary>Resend the login code via another medium, the phone code type is determined by the return value of the previous auth.sendCode/auth.resendCode: see <a href="https://corefork.telegram.org/api/auth">login</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/auth.resendCode"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/auth.resendCode#possible-errors">details</a>)</para></summary>
		/// <param name="phone_number">The phone number</param>
		/// <param name="phone_code_hash">The phone code hash obtained from <see cref="Auth_SendCode">Auth_SendCode</see></param>
		/// <param name="reason">Official clients only, used if the device integrity verification failed, and no secret could be obtained to invoke <see cref="Auth_RequestFirebaseSms">Auth_RequestFirebaseSms</see>: in this case, the device integrity verification failure reason must be passed here.</param>
		[Obsolete("Use LoginUserIfNeeded instead of this method. See https://wiz0u.github.io/WTelegramClient/FAQ#tlsharp")]
		public static Task<Auth_SentCodeBase> Auth_ResendCode(this Client client, string phone_number, string phone_code_hash, string reason = null)
			=> client.Invoke(new Auth_ResendCode
			{
				flags = (Auth_ResendCode.Flags)(reason != null ? 0x1 : 0),
				phone_number = phone_number,
				phone_code_hash = phone_code_hash,
				reason = reason,
			});

		/// <summary>Cancel the login verification code		<para>See <a href="https://corefork.telegram.org/method/auth.cancelCode"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/auth.cancelCode#possible-errors">details</a>)</para></summary>
		/// <param name="phone_number">Phone number</param>
		/// <param name="phone_code_hash">Phone code hash from <see cref="Auth_SendCode">Auth_SendCode</see></param>
		[Obsolete("Use LoginUserIfNeeded instead of this method. See https://wiz0u.github.io/WTelegramClient/FAQ#tlsharp")]
		public static Task<bool> Auth_CancelCode(this Client client, string phone_number, string phone_code_hash)
			=> client.Invoke(new Auth_CancelCode
			{
				phone_number = phone_number,
				phone_code_hash = phone_code_hash,
			});

		/// <summary>Delete all temporary authorization keys <strong>except for</strong> the ones specified		<para>See <a href="https://corefork.telegram.org/method/auth.dropTempAuthKeys"/> [bots: ✓]</para></summary>
		/// <param name="except_auth_keys">The auth keys that <strong>shouldn't</strong> be dropped.</param>
		public static Task<bool> Auth_DropTempAuthKeys(this Client client, long[] except_auth_keys = null)
			=> client.Invoke(new Auth_DropTempAuthKeys
			{
				except_auth_keys = except_auth_keys,
			});

		/// <summary>Generate a login token, for <a href="https://corefork.telegram.org/api/qr-login">login via QR code</a>.<br/>The generated login token should be encoded using base64url, then shown as a <c>tg://login?token=base64encodedtoken</c> <a href="https://corefork.telegram.org/api/links#qr-code-login-links">deep link »</a> in the QR code.		<para>See <a href="https://corefork.telegram.org/method/auth.exportLoginToken"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/auth.exportLoginToken#possible-errors">details</a>)</para></summary>
		/// <param name="api_id">Application identifier (see. <a href="https://corefork.telegram.org/myapp">App configuration</a>)</param>
		/// <param name="api_hash">Application identifier hash (see. <a href="https://corefork.telegram.org/myapp">App configuration</a>)</param>
		/// <param name="except_ids">List of already logged-in user IDs, to prevent logging in twice with the same user</param>
		public static Task<Auth_LoginTokenBase> Auth_ExportLoginToken(this Client client, int api_id, string api_hash, long[] except_ids = null)
			=> client.Invoke(new Auth_ExportLoginToken
			{
				api_id = api_id,
				api_hash = api_hash,
				except_ids = except_ids,
			});

		/// <summary>Login using a redirected login token, generated in case of DC mismatch during <a href="https://corefork.telegram.org/api/qr-login">QR code login</a>.		<para>See <a href="https://corefork.telegram.org/method/auth.importLoginToken"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/auth.importLoginToken#possible-errors">details</a>)</para></summary>
		/// <param name="token">Login token</param>
		public static Task<Auth_LoginTokenBase> Auth_ImportLoginToken(this Client client, byte[] token)
			=> client.Invoke(new Auth_ImportLoginToken
			{
				token = token,
			});

		/// <summary>Accept QR code login token, logging in the app that generated it.		<para>See <a href="https://corefork.telegram.org/method/auth.acceptLoginToken"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/auth.acceptLoginToken#possible-errors">details</a>)</para></summary>
		/// <param name="token">Login token embedded in QR code, for more info, see <a href="https://corefork.telegram.org/api/qr-login">login via QR code</a>.</param>
		public static Task<Authorization> Auth_AcceptLoginToken(this Client client, byte[] token)
			=> client.Invoke(new Auth_AcceptLoginToken
			{
				token = token,
			});

		/// <summary>Check if the <a href="https://corefork.telegram.org/api/srp">2FA recovery code</a> sent using <see cref="Auth_RequestPasswordRecovery">Auth_RequestPasswordRecovery</see> is valid, before passing it to <see cref="Auth_RecoverPassword">Auth_RecoverPassword</see>.		<para>See <a href="https://corefork.telegram.org/method/auth.checkRecoveryPassword"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/auth.checkRecoveryPassword#possible-errors">details</a>)</para></summary>
		/// <param name="code">Code received via email</param>
		public static Task<bool> Auth_CheckRecoveryPassword(this Client client, string code)
			=> client.Invoke(new Auth_CheckRecoveryPassword
			{
				code = code,
			});

		/// <summary>Login by importing an authorization token		<para>See <a href="https://corefork.telegram.org/method/auth.importWebTokenAuthorization"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/auth.importWebTokenAuthorization#possible-errors">details</a>)</para></summary>
		/// <param name="api_id"><a href="https://corefork.telegram.org/api/obtaining_api_id">API ID</a></param>
		/// <param name="api_hash"><a href="https://corefork.telegram.org/api/obtaining_api_id">API hash</a></param>
		/// <param name="web_auth_token">The authorization token</param>
		public static Task<Auth_AuthorizationBase> Auth_ImportWebTokenAuthorization(this Client client, int api_id, string api_hash, string web_auth_token)
			=> client.Invoke(new Auth_ImportWebTokenAuthorization
			{
				api_id = api_id,
				api_hash = api_hash,
				web_auth_token = web_auth_token,
			});

		/// <summary>Request an SMS code via Firebase.		<para>See <a href="https://corefork.telegram.org/method/auth.requestFirebaseSms"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/auth.requestFirebaseSms#possible-errors">details</a>)</para></summary>
		/// <param name="phone_number">Phone number</param>
		/// <param name="phone_code_hash">Phone code hash returned by <see cref="Auth_SendCode">Auth_SendCode</see></param>
		/// <param name="safety_net_token">On Android, a JWS object obtained as described in the <a href="https://corefork.telegram.org/api/auth">auth documentation »</a></param>
		/// <param name="play_integrity_token">On Android, an object obtained as described in the <a href="https://corefork.telegram.org/api/auth">auth documentation »</a></param>
		/// <param name="ios_push_secret">Secret token received via an apple push notification</param>
		public static Task<bool> Auth_RequestFirebaseSms(this Client client, string phone_number, string phone_code_hash, string safety_net_token = null, string ios_push_secret = null, string play_integrity_token = null)
			=> client.Invoke(new Auth_RequestFirebaseSms
			{
				flags = (Auth_RequestFirebaseSms.Flags)((safety_net_token != null ? 0x1 : 0) | (ios_push_secret != null ? 0x2 : 0) | (play_integrity_token != null ? 0x4 : 0)),
				phone_number = phone_number,
				phone_code_hash = phone_code_hash,
				safety_net_token = safety_net_token,
				play_integrity_token = play_integrity_token,
				ios_push_secret = ios_push_secret,
			});

		/// <summary>Reset the <a href="https://corefork.telegram.org/api/auth#email-verification">login email »</a>.		<para>See <a href="https://corefork.telegram.org/method/auth.resetLoginEmail"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/auth.resetLoginEmail#possible-errors">details</a>)</para></summary>
		/// <param name="phone_number">Phone number of the account</param>
		/// <param name="phone_code_hash">Phone code hash, obtained as described in the <a href="https://corefork.telegram.org/api/auth">documentation »</a></param>
		public static Task<Auth_SentCodeBase> Auth_ResetLoginEmail(this Client client, string phone_number, string phone_code_hash)
			=> client.Invoke(new Auth_ResetLoginEmail
			{
				phone_number = phone_number,
				phone_code_hash = phone_code_hash,
			});

		/// <summary>Official apps only, reports that the SMS authentication code wasn't delivered.		<para>See <a href="https://corefork.telegram.org/method/auth.reportMissingCode"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/auth.reportMissingCode#possible-errors">details</a>)</para></summary>
		/// <param name="phone_number">Phone number where we were supposed to receive the code</param>
		/// <param name="phone_code_hash">The phone code hash obtained from <see cref="Auth_SendCode">Auth_SendCode</see></param>
		/// <param name="mnc"><a href="https://en.wikipedia.org/wiki/Mobile_country_code">MNC</a> of the current network operator.</param>
		public static Task<bool> Auth_ReportMissingCode(this Client client, string phone_number, string phone_code_hash, string mnc)
			=> client.Invoke(new Auth_ReportMissingCode
			{
				phone_number = phone_number,
				phone_code_hash = phone_code_hash,
				mnc = mnc,
			});

		/// <summary>Register device to receive <a href="https://corefork.telegram.org/api/push-updates">PUSH notifications</a>		<para>See <a href="https://corefork.telegram.org/method/account.registerDevice"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.registerDevice#possible-errors">details</a>)</para></summary>
		/// <param name="no_muted">Avoid receiving (silent and invisible background) notifications. Useful to save battery.</param>
		/// <param name="token_type">Device token type, see <a href="https://corefork.telegram.org/api/push-updates#subscribing-to-notifications">PUSH updates</a> for the possible values.</param>
		/// <param name="token">Device token, see <a href="https://corefork.telegram.org/api/push-updates#subscribing-to-notifications">PUSH updates</a> for the possible values.</param>
		/// <param name="app_sandbox">If <see langword="true"/> is transmitted, a sandbox-certificate will be used during transmission.</param>
		/// <param name="secret">For FCM and APNS VoIP, optional encryption key used to encrypt push notifications</param>
		/// <param name="other_uids">List of user identifiers of other users currently using the client</param>
		public static Task<bool> Account_RegisterDevice(this Client client, int token_type, string token, bool app_sandbox, byte[] secret, long[] other_uids, bool no_muted = false)
			=> client.Invoke(new Account_RegisterDevice
			{
				flags = (Account_RegisterDevice.Flags)(no_muted ? 0x1 : 0),
				token_type = token_type,
				token = token,
				app_sandbox = app_sandbox,
				secret = secret,
				other_uids = other_uids,
			});

		/// <summary>Deletes a device by its token, stops sending PUSH-notifications to it.		<para>See <a href="https://corefork.telegram.org/method/account.unregisterDevice"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.unregisterDevice#possible-errors">details</a>)</para></summary>
		/// <param name="token_type">Device token type, see <a href="https://corefork.telegram.org/api/push-updates#subscribing-to-notifications">PUSH updates</a> for the possible values.</param>
		/// <param name="token">Device token, see <a href="https://corefork.telegram.org/api/push-updates#subscribing-to-notifications">PUSH updates</a> for the possible values.</param>
		/// <param name="other_uids">List of user identifiers of other users currently using the client</param>
		public static Task<bool> Account_UnregisterDevice(this Client client, int token_type, string token, params long[] other_uids)
			=> client.Invoke(new Account_UnregisterDevice
			{
				token_type = token_type,
				token = token,
				other_uids = other_uids,
			});

		/// <summary>Edits notification settings from a given user/group, from all users/all groups.		<para>See <a href="https://corefork.telegram.org/method/account.updateNotifySettings"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.updateNotifySettings#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Notification source</param>
		/// <param name="settings">Notification settings</param>
		public static Task<bool> Account_UpdateNotifySettings(this Client client, InputNotifyPeerBase peer, InputPeerNotifySettings settings)
			=> client.Invoke(new Account_UpdateNotifySettings
			{
				peer = peer,
				settings = settings,
			});

		/// <summary>Gets current notification settings for a given user/group, from all users/all groups.		<para>See <a href="https://corefork.telegram.org/method/account.getNotifySettings"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.getNotifySettings#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Notification source</param>
		public static Task<PeerNotifySettings> Account_GetNotifySettings(this Client client, InputNotifyPeerBase peer)
			=> client.Invoke(new Account_GetNotifySettings
			{
				peer = peer,
			});

		/// <summary>Resets all notification settings from users and groups.		<para>See <a href="https://corefork.telegram.org/method/account.resetNotifySettings"/></para></summary>
		public static Task<bool> Account_ResetNotifySettings(this Client client)
			=> client.Invoke(new Account_ResetNotifySettings
			{
			});

		/// <summary>Updates user profile.		<para>See <a href="https://corefork.telegram.org/method/account.updateProfile"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.updateProfile#possible-errors">details</a>)</para></summary>
		/// <param name="first_name">New user first name</param>
		/// <param name="last_name">New user last name</param>
		/// <param name="about">New bio</param>
		public static Task<UserBase> Account_UpdateProfile(this Client client, string first_name = null, string last_name = null, string about = null)
			=> client.Invoke(new Account_UpdateProfile
			{
				flags = (Account_UpdateProfile.Flags)((first_name != null ? 0x1 : 0) | (last_name != null ? 0x2 : 0) | (about != null ? 0x4 : 0)),
				first_name = first_name,
				last_name = last_name,
				about = about,
			});

		/// <summary>Updates online user status.		<para>See <a href="https://corefork.telegram.org/method/account.updateStatus"/></para></summary>
		/// <param name="offline">If <see langword="true"/> is transmitted, user status will change to <see cref="UserStatusOffline"/>.</param>
		public static Task<bool> Account_UpdateStatus(this Client client, bool offline)
			=> client.Invoke(new Account_UpdateStatus
			{
				offline = offline,
			});

		/// <summary>Returns a list of available <a href="https://corefork.telegram.org/api/wallpapers">wallpapers</a>.		<para>See <a href="https://corefork.telegram.org/method/account.getWallPapers"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/account.wallPapersNotModified">account.wallPapersNotModified</a></returns>
		public static Task<Account_WallPapers> Account_GetWallPapers(this Client client, long hash = default)
			=> client.Invoke(new Account_GetWallPapers
			{
				hash = hash,
			});

		/// <summary>Report a peer for violation of telegram's Terms of Service		<para>See <a href="https://corefork.telegram.org/method/account.reportPeer"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.reportPeer#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The peer to report</param>
		/// <param name="reason">The reason why this peer is being reported</param>
		/// <param name="message">Comment for report moderation</param>
		public static Task<bool> Account_ReportPeer(this Client client, InputPeer peer, ReportReason reason, string message)
			=> client.Invoke(new Account_ReportPeer
			{
				peer = peer,
				reason = reason,
				message = message,
			});

		/// <summary>Validates a username and checks availability.		<para>See <a href="https://corefork.telegram.org/method/account.checkUsername"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.checkUsername#possible-errors">details</a>)</para></summary>
		/// <param name="username">username<br/>Accepted characters: A-z (case-insensitive), 0-9 and underscores.<br/>Length: 5-32 characters.</param>
		public static Task<bool> Account_CheckUsername(this Client client, string username)
			=> client.Invoke(new Account_CheckUsername
			{
				username = username,
			});

		/// <summary>Changes username for the current user.		<para>See <a href="https://corefork.telegram.org/method/account.updateUsername"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.updateUsername#possible-errors">details</a>)</para></summary>
		/// <param name="username">username or empty string if username is to be removed<br/>Accepted characters: a-z (case-insensitive), 0-9 and underscores.<br/>Length: 5-32 characters.</param>
		public static Task<UserBase> Account_UpdateUsername(this Client client, string username)
			=> client.Invoke(new Account_UpdateUsername
			{
				username = username,
			});

		/// <summary>Get privacy settings of current account		<para>See <a href="https://corefork.telegram.org/method/account.getPrivacy"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.getPrivacy#possible-errors">details</a>)</para></summary>
		/// <param name="key">Peer category whose privacy settings should be fetched</param>
		public static Task<Account_PrivacyRules> Account_GetPrivacy(this Client client, InputPrivacyKey key)
			=> client.Invoke(new Account_GetPrivacy
			{
				key = key,
			});

		/// <summary>Change privacy settings of current account		<para>See <a href="https://corefork.telegram.org/method/account.setPrivacy"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.setPrivacy#possible-errors">details</a>)</para></summary>
		/// <param name="key">New privacy rule</param>
		/// <param name="rules">Peers to which the privacy rule will apply.</param>
		public static Task<Account_PrivacyRules> Account_SetPrivacy(this Client client, InputPrivacyKey key, params InputPrivacyRule[] rules)
			=> client.Invoke(new Account_SetPrivacy
			{
				key = key,
				rules = rules,
			});

		/// <summary>Delete the user's account from the telegram servers.		<para>See <a href="https://corefork.telegram.org/method/account.deleteAccount"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,420 (<a href="https://corefork.telegram.org/method/account.deleteAccount#possible-errors">details</a>)</para></summary>
		/// <param name="reason">Why is the account being deleted, can be empty</param>
		/// <param name="password"><a href="https://corefork.telegram.org/api/srp">2FA password</a>: this field can be omitted even for accounts with 2FA enabled: in this case account account deletion will be delayed by 7 days <a href="https://corefork.telegram.org/api/account-deletion">as specified in the docs »</a></param>
		public static Task<bool> Account_DeleteAccount(this Client client, string reason, InputCheckPasswordSRP password = null)
			=> client.Invoke(new Account_DeleteAccount
			{
				flags = (Account_DeleteAccount.Flags)(password != null ? 0x1 : 0),
				reason = reason,
				password = password,
			});

		/// <summary>Get days to live of account		<para>See <a href="https://corefork.telegram.org/method/account.getAccountTTL"/></para></summary>
		public static Task<AccountDaysTTL> Account_GetAccountTTL(this Client client)
			=> client.Invoke(new Account_GetAccountTTL
			{
			});

		/// <summary>Set account self-destruction period		<para>See <a href="https://corefork.telegram.org/method/account.setAccountTTL"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.setAccountTTL#possible-errors">details</a>)</para></summary>
		/// <param name="ttl">Time to live in days</param>
		public static Task<bool> Account_SetAccountTTL(this Client client, AccountDaysTTL ttl)
			=> client.Invoke(new Account_SetAccountTTL
			{
				ttl = ttl,
			});

		/// <summary>Verify a new phone number to associate to the current account		<para>See <a href="https://corefork.telegram.org/method/account.sendChangePhoneCode"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/account.sendChangePhoneCode#possible-errors">details</a>)</para></summary>
		/// <param name="phone_number">New phone number</param>
		/// <param name="settings">Phone code settings</param>
		public static Task<Auth_SentCodeBase> Account_SendChangePhoneCode(this Client client, string phone_number, CodeSettings settings)
			=> client.Invoke(new Account_SendChangePhoneCode
			{
				phone_number = phone_number,
				settings = settings,
			});

		/// <summary>Change the phone number of the current account		<para>See <a href="https://corefork.telegram.org/method/account.changePhone"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/account.changePhone#possible-errors">details</a>)</para></summary>
		/// <param name="phone_number">New phone number</param>
		/// <param name="phone_code_hash">Phone code hash received when calling <see cref="Account_SendChangePhoneCode">Account_SendChangePhoneCode</see></param>
		/// <param name="phone_code">Phone code received when calling <see cref="Account_SendChangePhoneCode">Account_SendChangePhoneCode</see></param>
		public static Task<UserBase> Account_ChangePhone(this Client client, string phone_number, string phone_code_hash, string phone_code)
			=> client.Invoke(new Account_ChangePhone
			{
				phone_number = phone_number,
				phone_code_hash = phone_code_hash,
				phone_code = phone_code,
			});

		/// <summary>When client-side passcode lock feature is enabled, will not show message texts in incoming <a href="https://corefork.telegram.org/api/push-updates">PUSH notifications</a>.		<para>See <a href="https://corefork.telegram.org/method/account.updateDeviceLocked"/></para></summary>
		/// <param name="period">Inactivity period after which to start hiding message texts in <a href="https://corefork.telegram.org/api/push-updates">PUSH notifications</a>.</param>
		public static Task<bool> Account_UpdateDeviceLocked(this Client client, int period)
			=> client.Invoke(new Account_UpdateDeviceLocked
			{
				period = period,
			});

		/// <summary>Get logged-in sessions		<para>See <a href="https://corefork.telegram.org/method/account.getAuthorizations"/></para></summary>
		public static Task<Account_Authorizations> Account_GetAuthorizations(this Client client)
			=> client.Invoke(new Account_GetAuthorizations
			{
			});

		/// <summary>Log out an active <a href="https://corefork.telegram.org/api/auth">authorized session</a> by its hash		<para>See <a href="https://corefork.telegram.org/method/account.resetAuthorization"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/account.resetAuthorization#possible-errors">details</a>)</para></summary>
		/// <param name="hash">Session hash</param>
		public static Task<bool> Account_ResetAuthorization(this Client client, long hash)
			=> client.Invoke(new Account_ResetAuthorization
			{
				hash = hash,
			});

		/// <summary>Obtain configuration for two-factor authorization with password		<para>See <a href="https://corefork.telegram.org/method/account.getPassword"/></para></summary>
		public static Task<Account_Password> Account_GetPassword(this Client client)
			=> client.Invoke(new Account_GetPassword
			{
			});

		/// <summary>Get private info associated to the password info (recovery email, telegram <a href="https://corefork.telegram.org/passport">passport</a> info &amp; so on)		<para>See <a href="https://corefork.telegram.org/method/account.getPasswordSettings"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.getPasswordSettings#possible-errors">details</a>)</para></summary>
		/// <param name="password">The password (see <a href="https://corefork.telegram.org/api/srp">SRP</a>)</param>
		public static Task<Account_PasswordSettings> Account_GetPasswordSettings(this Client client, InputCheckPasswordSRP password)
			=> client.Invoke(new Account_GetPasswordSettings
			{
				password = password,
			});

		/// <summary>Set a new 2FA password		<para>See <a href="https://corefork.telegram.org/method/account.updatePasswordSettings"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.updatePasswordSettings#possible-errors">details</a>)</para></summary>
		/// <param name="password">The old password (see <a href="https://corefork.telegram.org/api/srp">SRP</a>)</param>
		/// <param name="new_settings">The new password (see <a href="https://corefork.telegram.org/api/srp">SRP</a>)</param>
		public static Task<bool> Account_UpdatePasswordSettings(this Client client, InputCheckPasswordSRP password, Account_PasswordInputSettings new_settings)
			=> client.Invoke(new Account_UpdatePasswordSettings
			{
				password = password,
				new_settings = new_settings,
			});

		/// <summary>Send confirmation code to cancel account deletion, for more info <a href="https://corefork.telegram.org/api/account-deletion">click here »</a>		<para>See <a href="https://corefork.telegram.org/method/account.sendConfirmPhoneCode"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.sendConfirmPhoneCode#possible-errors">details</a>)</para></summary>
		/// <param name="hash">The hash from the service notification, for more info <a href="https://corefork.telegram.org/api/account-deletion">click here »</a></param>
		/// <param name="settings">Phone code settings</param>
		public static Task<Auth_SentCodeBase> Account_SendConfirmPhoneCode(this Client client, string hash, CodeSettings settings)
			=> client.Invoke(new Account_SendConfirmPhoneCode
			{
				hash = hash,
				settings = settings,
			});

		/// <summary>Confirm a phone number to cancel account deletion, for more info <a href="https://corefork.telegram.org/api/account-deletion">click here »</a>		<para>See <a href="https://corefork.telegram.org/method/account.confirmPhone"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.confirmPhone#possible-errors">details</a>)</para></summary>
		/// <param name="phone_code_hash">Phone code hash, for more info <a href="https://corefork.telegram.org/api/account-deletion">click here »</a></param>
		/// <param name="phone_code">SMS code, for more info <a href="https://corefork.telegram.org/api/account-deletion">click here »</a></param>
		public static Task<bool> Account_ConfirmPhone(this Client client, string phone_code_hash, string phone_code)
			=> client.Invoke(new Account_ConfirmPhone
			{
				phone_code_hash = phone_code_hash,
				phone_code = phone_code,
			});

		/// <summary>Get temporary payment password		<para>See <a href="https://corefork.telegram.org/method/account.getTmpPassword"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.getTmpPassword#possible-errors">details</a>)</para></summary>
		/// <param name="password">SRP password parameters</param>
		/// <param name="period">Time during which the temporary password will be valid, in seconds; should be between 60 and 86400</param>
		public static Task<Account_TmpPassword> Account_GetTmpPassword(this Client client, InputCheckPasswordSRP password, int period)
			=> client.Invoke(new Account_GetTmpPassword
			{
				password = password,
				period = period,
			});

		/// <summary>Get web <a href="https://corefork.telegram.org/widgets/login">login widget</a> authorizations		<para>See <a href="https://corefork.telegram.org/method/account.getWebAuthorizations"/></para></summary>
		public static Task<Account_WebAuthorizations> Account_GetWebAuthorizations(this Client client)
			=> client.Invoke(new Account_GetWebAuthorizations
			{
			});

		/// <summary>Log out an active web <a href="https://corefork.telegram.org/widgets/login">telegram login</a> session		<para>See <a href="https://corefork.telegram.org/method/account.resetWebAuthorization"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.resetWebAuthorization#possible-errors">details</a>)</para></summary>
		/// <param name="hash"><see cref="WebAuthorization">Session</see> hash</param>
		public static Task<bool> Account_ResetWebAuthorization(this Client client, long hash)
			=> client.Invoke(new Account_ResetWebAuthorization
			{
				hash = hash,
			});

		/// <summary>Reset all active web <a href="https://corefork.telegram.org/widgets/login">telegram login</a> sessions		<para>See <a href="https://corefork.telegram.org/method/account.resetWebAuthorizations"/></para></summary>
		public static Task<bool> Account_ResetWebAuthorizations(this Client client)
			=> client.Invoke(new Account_ResetWebAuthorizations
			{
			});

		/// <summary>Get all saved <a href="https://corefork.telegram.org/passport">Telegram Passport</a> documents, <a href="https://corefork.telegram.org/passport/encryption#encryption">for more info see the passport docs »</a>		<para>See <a href="https://corefork.telegram.org/method/account.getAllSecureValues"/></para></summary>
		public static Task<SecureValue[]> Account_GetAllSecureValues(this Client client)
			=> client.Invoke(new Account_GetAllSecureValues
			{
			});

		/// <summary>Get saved <a href="https://corefork.telegram.org/passport">Telegram Passport</a> document, <a href="https://corefork.telegram.org/passport/encryption#encryption">for more info see the passport docs »</a>		<para>See <a href="https://corefork.telegram.org/method/account.getSecureValue"/></para></summary>
		/// <param name="types">Requested value types</param>
		public static Task<SecureValue[]> Account_GetSecureValue(this Client client, params SecureValueType[] types)
			=> client.Invoke(new Account_GetSecureValue
			{
				types = types,
			});

		/// <summary>Securely save <a href="https://corefork.telegram.org/passport">Telegram Passport</a> document, <a href="https://corefork.telegram.org/passport/encryption#encryption">for more info see the passport docs »</a>		<para>See <a href="https://corefork.telegram.org/method/account.saveSecureValue"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.saveSecureValue#possible-errors">details</a>)</para></summary>
		/// <param name="value">Secure value, <a href="https://corefork.telegram.org/passport/encryption#encryption">for more info see the passport docs »</a></param>
		/// <param name="secure_secret_id">Passport secret hash, <a href="https://corefork.telegram.org/passport/encryption#encryption">for more info see the passport docs »</a></param>
		public static Task<SecureValue> Account_SaveSecureValue(this Client client, InputSecureValue value, long secure_secret_id)
			=> client.Invoke(new Account_SaveSecureValue
			{
				value = value,
				secure_secret_id = secure_secret_id,
			});

		/// <summary>Delete stored <a href="https://corefork.telegram.org/passport">Telegram Passport</a> documents, <a href="https://corefork.telegram.org/passport/encryption#encryption">for more info see the passport docs »</a>		<para>See <a href="https://corefork.telegram.org/method/account.deleteSecureValue"/></para></summary>
		/// <param name="types">Document types to delete</param>
		public static Task<bool> Account_DeleteSecureValue(this Client client, params SecureValueType[] types)
			=> client.Invoke(new Account_DeleteSecureValue
			{
				types = types,
			});

		/// <summary>Returns a Telegram Passport authorization form for sharing data with a service		<para>See <a href="https://corefork.telegram.org/method/account.getAuthorizationForm"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.getAuthorizationForm#possible-errors">details</a>)</para></summary>
		/// <param name="bot_id">User identifier of the service's bot</param>
		/// <param name="scope">Telegram Passport element types requested by the service</param>
		/// <param name="public_key">Service's public key</param>
		public static Task<Account_AuthorizationForm> Account_GetAuthorizationForm(this Client client, long bot_id, string scope, string public_key)
			=> client.Invoke(new Account_GetAuthorizationForm
			{
				bot_id = bot_id,
				scope = scope,
				public_key = public_key,
			});

		/// <summary>Sends a Telegram Passport authorization form, effectively sharing data with the service		<para>See <a href="https://corefork.telegram.org/method/account.acceptAuthorization"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.acceptAuthorization#possible-errors">details</a>)</para></summary>
		/// <param name="bot_id">Bot ID</param>
		/// <param name="scope">Telegram Passport element types requested by the service</param>
		/// <param name="public_key">Service's public key</param>
		/// <param name="value_hashes">Types of values sent and their hashes</param>
		/// <param name="credentials">Encrypted values</param>
		public static Task<bool> Account_AcceptAuthorization(this Client client, long bot_id, string scope, string public_key, SecureValueHash[] value_hashes, SecureCredentialsEncrypted credentials)
			=> client.Invoke(new Account_AcceptAuthorization
			{
				bot_id = bot_id,
				scope = scope,
				public_key = public_key,
				value_hashes = value_hashes,
				credentials = credentials,
			});

		/// <summary>Send the verification phone code for telegram <a href="https://corefork.telegram.org/passport">passport</a>.		<para>See <a href="https://corefork.telegram.org/method/account.sendVerifyPhoneCode"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.sendVerifyPhoneCode#possible-errors">details</a>)</para></summary>
		/// <param name="phone_number">The phone number to verify</param>
		/// <param name="settings">Phone code settings</param>
		public static Task<Auth_SentCodeBase> Account_SendVerifyPhoneCode(this Client client, string phone_number, CodeSettings settings)
			=> client.Invoke(new Account_SendVerifyPhoneCode
			{
				phone_number = phone_number,
				settings = settings,
			});

		/// <summary>Verify a phone number for telegram <a href="https://corefork.telegram.org/passport">passport</a>.		<para>See <a href="https://corefork.telegram.org/method/account.verifyPhone"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.verifyPhone#possible-errors">details</a>)</para></summary>
		/// <param name="phone_number">Phone number</param>
		/// <param name="phone_code_hash">Phone code hash received from the call to <see cref="Account_SendVerifyPhoneCode">Account_SendVerifyPhoneCode</see></param>
		/// <param name="phone_code">Code received after the call to <see cref="Account_SendVerifyPhoneCode">Account_SendVerifyPhoneCode</see></param>
		public static Task<bool> Account_VerifyPhone(this Client client, string phone_number, string phone_code_hash, string phone_code)
			=> client.Invoke(new Account_VerifyPhone
			{
				phone_number = phone_number,
				phone_code_hash = phone_code_hash,
				phone_code = phone_code,
			});

		/// <summary>Send an email verification code.		<para>See <a href="https://corefork.telegram.org/method/account.sendVerifyEmailCode"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.sendVerifyEmailCode#possible-errors">details</a>)</para></summary>
		/// <param name="purpose">Verification purpose.</param>
		/// <param name="email">The email where to send the code.</param>
		public static Task<Account_SentEmailCode> Account_SendVerifyEmailCode(this Client client, EmailVerifyPurpose purpose, string email)
			=> client.Invoke(new Account_SendVerifyEmailCode
			{
				purpose = purpose,
				email = email,
			});

		/// <summary>Verify an email address.		<para>See <a href="https://corefork.telegram.org/method/account.verifyEmail"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.verifyEmail#possible-errors">details</a>)</para></summary>
		/// <param name="purpose">Verification purpose</param>
		/// <param name="verification">Email verification code or token</param>
		public static Task<Account_EmailVerified> Account_VerifyEmail(this Client client, EmailVerifyPurpose purpose, EmailVerification verification)
			=> client.Invoke(new Account_VerifyEmail
			{
				purpose = purpose,
				verification = verification,
			});

		/// <summary>Initialize a <a href="https://corefork.telegram.org/api/takeout">takeout session, see here » for more info</a>.		<para>See <a href="https://corefork.telegram.org/method/account.initTakeoutSession"/></para>		<para>Possible <see cref="RpcException"/> codes: 420 (<a href="https://corefork.telegram.org/method/account.initTakeoutSession#possible-errors">details</a>)</para></summary>
		/// <param name="contacts">Whether to export contacts</param>
		/// <param name="message_users">Whether to export messages in private chats</param>
		/// <param name="message_chats">Whether to export messages in <a href="https://corefork.telegram.org/api/channel#basic-groups">basic groups</a></param>
		/// <param name="message_megagroups">Whether to export messages in <a href="https://corefork.telegram.org/api/channel#supergroups">supergroups</a></param>
		/// <param name="message_channels">Whether to export messages in <a href="https://corefork.telegram.org/api/channel#channels">channels</a></param>
		/// <param name="files">Whether to export files</param>
		/// <param name="file_max_size">Maximum size of files to export</param>
		public static Task<Account_Takeout> Account_InitTakeoutSession(this Client client, long? file_max_size = null, bool contacts = false, bool message_users = false, bool message_chats = false, bool message_megagroups = false, bool message_channels = false, bool files = false)
			=> client.Invoke(new Account_InitTakeoutSession
			{
				flags = (Account_InitTakeoutSession.Flags)((file_max_size != null ? 0x20 : 0) | (contacts ? 0x1 : 0) | (message_users ? 0x2 : 0) | (message_chats ? 0x4 : 0) | (message_megagroups ? 0x8 : 0) | (message_channels ? 0x10 : 0) | (files ? 0x20 : 0)),
				file_max_size = file_max_size ?? default,
			});

		/// <summary>Terminate a <a href="https://corefork.telegram.org/api/takeout">takeout session, see here » for more info</a>.		<para>See <a href="https://corefork.telegram.org/method/account.finishTakeoutSession"/></para>		<para>Possible <see cref="RpcException"/> codes: 403 (<a href="https://corefork.telegram.org/method/account.finishTakeoutSession#possible-errors">details</a>)</para></summary>
		/// <param name="success">Data exported successfully</param>
		public static Task<bool> Account_FinishTakeoutSession(this Client client, bool success = false)
			=> client.Invoke(new Account_FinishTakeoutSession
			{
				flags = (Account_FinishTakeoutSession.Flags)(success ? 0x1 : 0),
			});

		/// <summary>Verify an email to use as <a href="https://corefork.telegram.org/api/srp">2FA recovery method</a>.		<para>See <a href="https://corefork.telegram.org/method/account.confirmPasswordEmail"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.confirmPasswordEmail#possible-errors">details</a>)</para></summary>
		/// <param name="code">The phone code that was received after <a href="https://corefork.telegram.org/api/srp#email-verification">setting a recovery email</a></param>
		public static Task<bool> Account_ConfirmPasswordEmail(this Client client, string code)
			=> client.Invoke(new Account_ConfirmPasswordEmail
			{
				code = code,
			});

		/// <summary>Resend the code to verify an email to use as <a href="https://corefork.telegram.org/api/srp">2FA recovery method</a>.		<para>See <a href="https://corefork.telegram.org/method/account.resendPasswordEmail"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.resendPasswordEmail#possible-errors">details</a>)</para></summary>
		public static Task<bool> Account_ResendPasswordEmail(this Client client)
			=> client.Invoke(new Account_ResendPasswordEmail
			{
			});

		/// <summary>Cancel the code that was sent to verify an email to use as <a href="https://corefork.telegram.org/api/srp">2FA recovery method</a>.		<para>See <a href="https://corefork.telegram.org/method/account.cancelPasswordEmail"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.cancelPasswordEmail#possible-errors">details</a>)</para></summary>
		public static Task<bool> Account_CancelPasswordEmail(this Client client)
			=> client.Invoke(new Account_CancelPasswordEmail
			{
			});

		/// <summary>Whether the user will receive notifications when contacts sign up		<para>See <a href="https://corefork.telegram.org/method/account.getContactSignUpNotification"/></para></summary>
		public static Task<bool> Account_GetContactSignUpNotification(this Client client)
			=> client.Invoke(new Account_GetContactSignUpNotification
			{
			});

		/// <summary>Toggle contact sign up notifications		<para>See <a href="https://corefork.telegram.org/method/account.setContactSignUpNotification"/></para></summary>
		/// <param name="silent">Whether to disable contact sign up notifications</param>
		public static Task<bool> Account_SetContactSignUpNotification(this Client client, bool silent)
			=> client.Invoke(new Account_SetContactSignUpNotification
			{
				silent = silent,
			});

		/// <summary>Returns list of chats with non-default notification settings		<para>See <a href="https://corefork.telegram.org/method/account.getNotifyExceptions"/></para></summary>
		/// <param name="compare_sound">If set, chats with non-default sound will be returned</param>
		/// <param name="compare_stories">If set, chats with non-default notification settings for stories will be returned</param>
		/// <param name="peer">If specified, only chats of the specified category will be returned</param>
		public static Task<UpdatesBase> Account_GetNotifyExceptions(this Client client, InputNotifyPeerBase peer = null, bool compare_sound = false, bool compare_stories = false)
			=> client.Invoke(new Account_GetNotifyExceptions
			{
				flags = (Account_GetNotifyExceptions.Flags)((peer != null ? 0x1 : 0) | (compare_sound ? 0x2 : 0) | (compare_stories ? 0x4 : 0)),
				peer = peer,
			});

		/// <summary>Get info about a certain <a href="https://corefork.telegram.org/api/wallpapers">wallpaper</a>		<para>See <a href="https://corefork.telegram.org/method/account.getWallPaper"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.getWallPaper#possible-errors">details</a>)</para></summary>
		/// <param name="wallpaper">The <a href="https://corefork.telegram.org/api/wallpapers">wallpaper</a> to get info about</param>
		public static Task<WallPaperBase> Account_GetWallPaper(this Client client, InputWallPaperBase wallpaper)
			=> client.Invoke(new Account_GetWallPaper
			{
				wallpaper = wallpaper,
			});

		/// <summary>Create and upload a new <a href="https://corefork.telegram.org/api/wallpapers">wallpaper</a>		<para>See <a href="https://corefork.telegram.org/method/account.uploadWallPaper"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.uploadWallPaper#possible-errors">details</a>)</para></summary>
		/// <param name="for_chat">Set this flag when uploading wallpapers to be passed to <see cref="Messages_SetChatWallPaper">Messages_SetChatWallPaper</see>.</param>
		/// <param name="file">The JPG/PNG wallpaper</param>
		/// <param name="mime_type">MIME type of uploaded wallpaper</param>
		/// <param name="settings">Wallpaper settings</param>
		public static Task<WallPaperBase> Account_UploadWallPaper(this Client client, InputFileBase file, string mime_type, WallPaperSettings settings, bool for_chat = false)
			=> client.Invoke(new Account_UploadWallPaper
			{
				flags = (Account_UploadWallPaper.Flags)(for_chat ? 0x1 : 0),
				file = file,
				mime_type = mime_type,
				settings = settings,
			});

		/// <summary>Install/uninstall <a href="https://corefork.telegram.org/api/wallpapers">wallpaper</a>		<para>See <a href="https://corefork.telegram.org/method/account.saveWallPaper"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.saveWallPaper#possible-errors">details</a>)</para></summary>
		/// <param name="wallpaper"><a href="https://corefork.telegram.org/api/wallpapers">Wallpaper</a> to install or uninstall</param>
		/// <param name="unsave">Uninstall wallpaper?</param>
		/// <param name="settings">Wallpaper settings</param>
		public static Task<bool> Account_SaveWallPaper(this Client client, InputWallPaperBase wallpaper, bool unsave, WallPaperSettings settings)
			=> client.Invoke(new Account_SaveWallPaper
			{
				wallpaper = wallpaper,
				unsave = unsave,
				settings = settings,
			});

		/// <summary>Install <a href="https://corefork.telegram.org/api/wallpapers">wallpaper</a>		<para>See <a href="https://corefork.telegram.org/method/account.installWallPaper"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.installWallPaper#possible-errors">details</a>)</para></summary>
		/// <param name="wallpaper"><a href="https://corefork.telegram.org/api/wallpapers">Wallpaper</a> to install</param>
		/// <param name="settings"><a href="https://corefork.telegram.org/api/wallpapers">Wallpaper</a> settings</param>
		public static Task<bool> Account_InstallWallPaper(this Client client, InputWallPaperBase wallpaper, WallPaperSettings settings)
			=> client.Invoke(new Account_InstallWallPaper
			{
				wallpaper = wallpaper,
				settings = settings,
			});

		/// <summary>Delete all installed <a href="https://corefork.telegram.org/api/wallpapers">wallpapers</a>, reverting to the default wallpaper set.		<para>See <a href="https://corefork.telegram.org/method/account.resetWallPapers"/></para></summary>
		public static Task<bool> Account_ResetWallPapers(this Client client)
			=> client.Invoke(new Account_ResetWallPapers
			{
			});

		/// <summary>Get media autodownload settings		<para>See <a href="https://corefork.telegram.org/method/account.getAutoDownloadSettings"/></para></summary>
		public static Task<Account_AutoDownloadSettings> Account_GetAutoDownloadSettings(this Client client)
			=> client.Invoke(new Account_GetAutoDownloadSettings
			{
			});

		/// <summary>Change media autodownload settings		<para>See <a href="https://corefork.telegram.org/method/account.saveAutoDownloadSettings"/></para></summary>
		/// <param name="low">Whether to save media in the low data usage preset</param>
		/// <param name="high">Whether to save media in the high data usage preset</param>
		/// <param name="settings">Media autodownload settings</param>
		public static Task<bool> Account_SaveAutoDownloadSettings(this Client client, AutoDownloadSettings settings, bool low = false, bool high = false)
			=> client.Invoke(new Account_SaveAutoDownloadSettings
			{
				flags = (Account_SaveAutoDownloadSettings.Flags)((low ? 0x1 : 0) | (high ? 0x2 : 0)),
				settings = settings,
			});

		/// <summary>Upload theme		<para>See <a href="https://corefork.telegram.org/method/account.uploadTheme"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.uploadTheme#possible-errors">details</a>)</para></summary>
		/// <param name="file"><a href="https://corefork.telegram.org/api/themes#uploading-theme-files">Previously uploaded</a> theme file with platform-specific colors for UI components, can be left unset when creating themes that only modify the wallpaper or accent colors.</param>
		/// <param name="thumb">Thumbnail</param>
		/// <param name="file_name">File name</param>
		/// <param name="mime_type">MIME type, must be <c>application/x-tgtheme-{format}</c>, where <c>format</c> depends on the client</param>
		public static Task<DocumentBase> Account_UploadTheme(this Client client, InputFileBase file, string file_name, string mime_type, InputFileBase thumb = null)
			=> client.Invoke(new Account_UploadTheme
			{
				flags = (Account_UploadTheme.Flags)(thumb != null ? 0x1 : 0),
				file = file,
				thumb = thumb,
				file_name = file_name,
				mime_type = mime_type,
			});

		/// <summary>Create a theme		<para>See <a href="https://corefork.telegram.org/method/account.createTheme"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.createTheme#possible-errors">details</a>)</para></summary>
		/// <param name="slug">Unique theme ID used to generate <a href="https://corefork.telegram.org/api/links#theme-links">theme deep links</a>, can be empty to autogenerate a random ID.</param>
		/// <param name="title">Theme name</param>
		/// <param name="document">Theme file</param>
		/// <param name="settings">Theme settings, multiple values can be provided for the different base themes (day/night mode, etc).</param>
		public static Task<Theme> Account_CreateTheme(this Client client, string slug, string title, InputDocument document = null, InputThemeSettings[] settings = null)
			=> client.Invoke(new Account_CreateTheme
			{
				flags = (Account_CreateTheme.Flags)((document != null ? 0x4 : 0) | (settings != null ? 0x8 : 0)),
				slug = slug,
				title = title,
				document = document,
				settings = settings,
			});

		/// <summary>Update theme		<para>See <a href="https://corefork.telegram.org/method/account.updateTheme"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.updateTheme#possible-errors">details</a>)</para></summary>
		/// <param name="format">Theme format, a string that identifies the theming engines supported by the client</param>
		/// <param name="theme">Theme to update</param>
		/// <param name="slug">Unique theme ID</param>
		/// <param name="title">Theme name</param>
		/// <param name="document">Theme file</param>
		/// <param name="settings">Theme settings</param>
		public static Task<Theme> Account_UpdateTheme(this Client client, string format, InputThemeBase theme, string slug = null, string title = null, InputDocument document = null, InputThemeSettings[] settings = null)
			=> client.Invoke(new Account_UpdateTheme
			{
				flags = (Account_UpdateTheme.Flags)((slug != null ? 0x1 : 0) | (title != null ? 0x2 : 0) | (document != null ? 0x4 : 0) | (settings != null ? 0x8 : 0)),
				format = format,
				theme = theme,
				slug = slug,
				title = title,
				document = document,
				settings = settings,
			});

		/// <summary>Save a theme		<para>See <a href="https://corefork.telegram.org/method/account.saveTheme"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.saveTheme#possible-errors">details</a>)</para></summary>
		/// <param name="theme">Theme to save</param>
		/// <param name="unsave">Unsave</param>
		public static Task<bool> Account_SaveTheme(this Client client, InputThemeBase theme, bool unsave)
			=> client.Invoke(new Account_SaveTheme
			{
				theme = theme,
				unsave = unsave,
			});

		/// <summary>Install a theme		<para>See <a href="https://corefork.telegram.org/method/account.installTheme"/></para></summary>
		/// <param name="dark">Whether to install the dark version</param>
		/// <param name="theme">Theme to install</param>
		/// <param name="format">Theme format, a string that identifies the theming engines supported by the client</param>
		/// <param name="base_theme">Indicates a basic theme provided by all clients</param>
		public static Task<bool> Account_InstallTheme(this Client client, InputThemeBase theme = null, string format = null, BaseTheme base_theme = default, bool dark = false)
			=> client.Invoke(new Account_InstallTheme
			{
				flags = (Account_InstallTheme.Flags)((theme != null ? 0x2 : 0) | (format != null ? 0x4 : 0) | (base_theme != default ? 0x8 : 0) | (dark ? 0x1 : 0)),
				theme = theme,
				format = format,
				base_theme = base_theme,
			});

		/// <summary>Get theme information		<para>See <a href="https://corefork.telegram.org/method/account.getTheme"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.getTheme#possible-errors">details</a>)</para></summary>
		/// <param name="format">Theme format, a string that identifies the theming engines supported by the client</param>
		/// <param name="theme">Theme</param>
		public static Task<Theme> Account_GetTheme(this Client client, string format, InputThemeBase theme)
			=> client.Invoke(new Account_GetTheme
			{
				format = format,
				theme = theme,
			});

		/// <summary>Get installed themes		<para>See <a href="https://corefork.telegram.org/method/account.getThemes"/></para></summary>
		/// <param name="format">Theme format, a string that identifies the theming engines supported by the client</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/account.themesNotModified">account.themesNotModified</a></returns>
		public static Task<Account_Themes> Account_GetThemes(this Client client, string format, long hash = default)
			=> client.Invoke(new Account_GetThemes
			{
				format = format,
				hash = hash,
			});

		/// <summary>Set sensitive content settings (for viewing or hiding NSFW content)		<para>See <a href="https://corefork.telegram.org/method/account.setContentSettings"/></para>		<para>Possible <see cref="RpcException"/> codes: 403 (<a href="https://corefork.telegram.org/method/account.setContentSettings#possible-errors">details</a>)</para></summary>
		/// <param name="sensitive_enabled">Enable NSFW content</param>
		public static Task<bool> Account_SetContentSettings(this Client client, bool sensitive_enabled = false)
			=> client.Invoke(new Account_SetContentSettings
			{
				flags = (Account_SetContentSettings.Flags)(sensitive_enabled ? 0x1 : 0),
			});

		/// <summary>Get sensitive content settings		<para>See <a href="https://corefork.telegram.org/method/account.getContentSettings"/></para></summary>
		public static Task<Account_ContentSettings> Account_GetContentSettings(this Client client)
			=> client.Invoke(new Account_GetContentSettings
			{
			});

		/// <summary>Get info about multiple <a href="https://corefork.telegram.org/api/wallpapers">wallpapers</a>		<para>See <a href="https://corefork.telegram.org/method/account.getMultiWallPapers"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.getMultiWallPapers#possible-errors">details</a>)</para></summary>
		/// <param name="wallpapers"><a href="https://corefork.telegram.org/api/wallpapers">Wallpapers</a> to fetch info about</param>
		public static Task<WallPaperBase[]> Account_GetMultiWallPapers(this Client client, params InputWallPaperBase[] wallpapers)
			=> client.Invoke(new Account_GetMultiWallPapers
			{
				wallpapers = wallpapers,
			});

		/// <summary>Get global privacy settings		<para>See <a href="https://corefork.telegram.org/method/account.getGlobalPrivacySettings"/></para></summary>
		public static Task<GlobalPrivacySettings> Account_GetGlobalPrivacySettings(this Client client)
			=> client.Invoke(new Account_GetGlobalPrivacySettings
			{
			});

		/// <summary>Set global privacy settings		<para>See <a href="https://corefork.telegram.org/method/account.setGlobalPrivacySettings"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/account.setGlobalPrivacySettings#possible-errors">details</a>)</para></summary>
		/// <param name="settings">Global privacy settings</param>
		public static Task<GlobalPrivacySettings> Account_SetGlobalPrivacySettings(this Client client, GlobalPrivacySettings settings)
			=> client.Invoke(new Account_SetGlobalPrivacySettings
			{
				settings = settings,
			});

		/// <summary>Report a profile photo of a dialog		<para>See <a href="https://corefork.telegram.org/method/account.reportProfilePhoto"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.reportProfilePhoto#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The dialog</param>
		/// <param name="photo_id">Dialog photo ID</param>
		/// <param name="reason">Report reason</param>
		/// <param name="message">Comment for report moderation</param>
		public static Task<bool> Account_ReportProfilePhoto(this Client client, InputPeer peer, InputPhoto photo_id, ReportReason reason, string message)
			=> client.Invoke(new Account_ReportProfilePhoto
			{
				peer = peer,
				photo_id = photo_id,
				reason = reason,
				message = message,
			});

		/// <summary>Initiate a 2FA password reset: can only be used if the user is already logged-in, <a href="https://corefork.telegram.org/api/srp#password-reset">see here for more info »</a>		<para>See <a href="https://corefork.telegram.org/method/account.resetPassword"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.resetPassword#possible-errors">details</a>)</para></summary>
		public static Task<Account_ResetPasswordResult> Account_ResetPassword(this Client client)
			=> client.Invoke(new Account_ResetPassword
			{
			});

		/// <summary>Abort a pending 2FA password reset, <a href="https://corefork.telegram.org/api/srp#password-reset">see here for more info »</a>		<para>See <a href="https://corefork.telegram.org/method/account.declinePasswordReset"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.declinePasswordReset#possible-errors">details</a>)</para></summary>
		public static Task<bool> Account_DeclinePasswordReset(this Client client)
			=> client.Invoke(new Account_DeclinePasswordReset
			{
			});

		/// <summary>Get all available chat <a href="https://corefork.telegram.org/api/themes">themes »</a>.		<para>See <a href="https://corefork.telegram.org/method/account.getChatThemes"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/account.themesNotModified">account.themesNotModified</a></returns>
		public static Task<Account_Themes> Account_GetChatThemes(this Client client, long hash = default)
			=> client.Invoke(new Account_GetChatThemes
			{
				hash = hash,
			});

		/// <summary>Set time-to-live of current session		<para>See <a href="https://corefork.telegram.org/method/account.setAuthorizationTTL"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/account.setAuthorizationTTL#possible-errors">details</a>)</para></summary>
		/// <param name="authorization_ttl_days">Time-to-live of current session in days</param>
		public static Task<bool> Account_SetAuthorizationTTL(this Client client, int authorization_ttl_days)
			=> client.Invoke(new Account_SetAuthorizationTTL
			{
				authorization_ttl_days = authorization_ttl_days,
			});

		/// <summary>Change settings related to a session.		<para>See <a href="https://corefork.telegram.org/method/account.changeAuthorizationSettings"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.changeAuthorizationSettings#possible-errors">details</a>)</para></summary>
		/// <param name="confirmed">If set, <a href="https://corefork.telegram.org/api/auth#confirming-login">confirms a newly logged in session »</a>.</param>
		/// <param name="hash">Session ID from the <see cref="Authorization"/>, fetchable using <see cref="Account_GetAuthorizations">Account_GetAuthorizations</see></param>
		/// <param name="encrypted_requests_disabled">Whether to enable or disable receiving encrypted chats: if the flag is not set, the previous setting is not changed</param>
		/// <param name="call_requests_disabled">Whether to enable or disable receiving calls: if the flag is not set, the previous setting is not changed</param>
		public static Task<bool> Account_ChangeAuthorizationSettings(this Client client, long hash, bool? encrypted_requests_disabled = default, bool? call_requests_disabled = default, bool confirmed = false)
			=> client.Invoke(new Account_ChangeAuthorizationSettings
			{
				flags = (Account_ChangeAuthorizationSettings.Flags)((encrypted_requests_disabled != default ? 0x1 : 0) | (call_requests_disabled != default ? 0x2 : 0) | (confirmed ? 0x8 : 0)),
				hash = hash,
				encrypted_requests_disabled = encrypted_requests_disabled ?? default,
				call_requests_disabled = call_requests_disabled ?? default,
			});

		/// <summary>Fetch saved notification sounds		<para>See <a href="https://corefork.telegram.org/method/account.getSavedRingtones"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/account.savedRingtonesNotModified">account.savedRingtonesNotModified</a></returns>
		public static Task<Account_SavedRingtones> Account_GetSavedRingtones(this Client client, long hash = default)
			=> client.Invoke(new Account_GetSavedRingtones
			{
				hash = hash,
			});

		/// <summary>Save or remove saved notification sound.		<para>See <a href="https://corefork.telegram.org/method/account.saveRingtone"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.saveRingtone#possible-errors">details</a>)</para></summary>
		/// <param name="id">Notification sound uploaded using <see cref="Account_UploadRingtone">Account_UploadRingtone</see></param>
		/// <param name="unsave">Whether to add or delete the notification sound</param>
		public static Task<Account_SavedRingtone> Account_SaveRingtone(this Client client, InputDocument id, bool unsave)
			=> client.Invoke(new Account_SaveRingtone
			{
				id = id,
				unsave = unsave,
			});

		/// <summary>Upload notification sound, use <see cref="Account_SaveRingtone">Account_SaveRingtone</see> to convert it and add it to the list of saved notification sounds.		<para>See <a href="https://corefork.telegram.org/method/account.uploadRingtone"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.uploadRingtone#possible-errors">details</a>)</para></summary>
		/// <param name="file">Notification sound</param>
		/// <param name="file_name">File name</param>
		/// <param name="mime_type">MIME type of file</param>
		public static Task<DocumentBase> Account_UploadRingtone(this Client client, InputFileBase file, string file_name, string mime_type)
			=> client.Invoke(new Account_UploadRingtone
			{
				file = file,
				file_name = file_name,
				mime_type = mime_type,
			});

		/// <summary>Set an <a href="https://corefork.telegram.org/api/emoji-status">emoji status</a>		<para>See <a href="https://corefork.telegram.org/method/account.updateEmojiStatus"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.updateEmojiStatus#possible-errors">details</a>)</para></summary>
		/// <param name="emoji_status"><a href="https://corefork.telegram.org/api/emoji-status">Emoji status</a> to set</param>
		public static Task<bool> Account_UpdateEmojiStatus(this Client client, EmojiStatusBase emoji_status)
			=> client.Invoke(new Account_UpdateEmojiStatus
			{
				emoji_status = emoji_status,
			});

		/// <summary>Get a list of default suggested <a href="https://corefork.telegram.org/api/emoji-status">emoji statuses</a>		<para>See <a href="https://corefork.telegram.org/method/account.getDefaultEmojiStatuses"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/account.emojiStatusesNotModified">account.emojiStatusesNotModified</a></returns>
		public static Task<Account_EmojiStatuses> Account_GetDefaultEmojiStatuses(this Client client, long hash = default)
			=> client.Invoke(new Account_GetDefaultEmojiStatuses
			{
				hash = hash,
			});

		/// <summary>Get recently used <a href="https://corefork.telegram.org/api/emoji-status">emoji statuses</a>		<para>See <a href="https://corefork.telegram.org/method/account.getRecentEmojiStatuses"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/account.emojiStatusesNotModified">account.emojiStatusesNotModified</a></returns>
		public static Task<Account_EmojiStatuses> Account_GetRecentEmojiStatuses(this Client client, long hash = default)
			=> client.Invoke(new Account_GetRecentEmojiStatuses
			{
				hash = hash,
			});

		/// <summary>Clears list of recently used <a href="https://corefork.telegram.org/api/emoji-status">emoji statuses</a>		<para>See <a href="https://corefork.telegram.org/method/account.clearRecentEmojiStatuses"/></para></summary>
		public static Task<bool> Account_ClearRecentEmojiStatuses(this Client client)
			=> client.Invoke(new Account_ClearRecentEmojiStatuses
			{
			});

		/// <summary>Reorder usernames associated with the currently logged-in user.		<para>See <a href="https://corefork.telegram.org/method/account.reorderUsernames"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.reorderUsernames#possible-errors">details</a>)</para></summary>
		/// <param name="order">The new order for active usernames. All active usernames must be specified.</param>
		public static Task<bool> Account_ReorderUsernames(this Client client, params string[] order)
			=> client.Invoke(new Account_ReorderUsernames
			{
				order = order,
			});

		/// <summary>Activate or deactivate a purchased <a href="https://fragment.com">fragment.com</a> username associated to the currently logged-in user.		<para>See <a href="https://corefork.telegram.org/method/account.toggleUsername"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.toggleUsername#possible-errors">details</a>)</para></summary>
		/// <param name="username">Username</param>
		/// <param name="active">Whether to activate or deactivate it</param>
		public static Task<bool> Account_ToggleUsername(this Client client, string username, bool active)
			=> client.Invoke(new Account_ToggleUsername
			{
				username = username,
				active = active,
			});

		/// <summary>Get a set of suggested <a href="https://corefork.telegram.org/api/custom-emoji">custom emoji stickers</a> that can be <a href="https://corefork.telegram.org/api/files#sticker-profile-pictures">used as profile picture</a>		<para>See <a href="https://corefork.telegram.org/method/account.getDefaultProfilePhotoEmojis"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/emojiListNotModified">emojiListNotModified</a></returns>
		public static Task<EmojiList> Account_GetDefaultProfilePhotoEmojis(this Client client, long hash = default)
			=> client.Invoke(new Account_GetDefaultProfilePhotoEmojis
			{
				hash = hash,
			});

		/// <summary>Get a set of suggested <a href="https://corefork.telegram.org/api/custom-emoji">custom emoji stickers</a> that can be <a href="https://corefork.telegram.org/api/files#sticker-profile-pictures">used as group picture</a>		<para>See <a href="https://corefork.telegram.org/method/account.getDefaultGroupPhotoEmojis"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/emojiListNotModified">emojiListNotModified</a></returns>
		public static Task<EmojiList> Account_GetDefaultGroupPhotoEmojis(this Client client, long hash = default)
			=> client.Invoke(new Account_GetDefaultGroupPhotoEmojis
			{
				hash = hash,
			});

		/// <summary>Get autosave settings		<para>See <a href="https://corefork.telegram.org/method/account.getAutoSaveSettings"/></para></summary>
		public static Task<Account_AutoSaveSettings> Account_GetAutoSaveSettings(this Client client)
			=> client.Invoke(new Account_GetAutoSaveSettings
			{
			});

		/// <summary>Modify autosave settings		<para>See <a href="https://corefork.telegram.org/method/account.saveAutoSaveSettings"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.saveAutoSaveSettings#possible-errors">details</a>)</para></summary>
		/// <param name="users">Whether the new settings should affect all private chats</param>
		/// <param name="chats">Whether the new settings should affect all groups</param>
		/// <param name="broadcasts">Whether the new settings should affect all <a href="https://corefork.telegram.org/api/channel">channels</a></param>
		/// <param name="peer">Whether the new settings should affect a specific peer</param>
		/// <param name="settings">The new autosave settings</param>
		public static Task<bool> Account_SaveAutoSaveSettings(this Client client, AutoSaveSettings settings, InputPeer peer = null, bool users = false, bool chats = false, bool broadcasts = false)
			=> client.Invoke(new Account_SaveAutoSaveSettings
			{
				flags = (Account_SaveAutoSaveSettings.Flags)((peer != null ? 0x8 : 0) | (users ? 0x1 : 0) | (chats ? 0x2 : 0) | (broadcasts ? 0x4 : 0)),
				peer = peer,
				settings = settings,
			});

		/// <summary>Clear all peer-specific autosave settings.		<para>See <a href="https://corefork.telegram.org/method/account.deleteAutoSaveExceptions"/></para></summary>
		public static Task<bool> Account_DeleteAutoSaveExceptions(this Client client)
			=> client.Invoke(new Account_DeleteAutoSaveExceptions
			{
			});

		/// <summary>Invalidate the specified login codes, see <a href="https://corefork.telegram.org/api/auth#invalidating-login-codes">here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/account.invalidateSignInCodes"/></para></summary>
		/// <param name="codes">The login codes to invalidate.</param>
		public static Task<bool> Account_InvalidateSignInCodes(this Client client, params string[] codes)
			=> client.Invoke(new Account_InvalidateSignInCodes
			{
				codes = codes,
			});

		/// <summary>Update the <a href="https://corefork.telegram.org/api/colors">accent color and background custom emoji »</a> of the current account.		<para>See <a href="https://corefork.telegram.org/method/account.updateColor"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/account.updateColor#possible-errors">details</a>)</para></summary>
		/// <param name="for_profile">Whether to change the accent color emoji pattern of the profile page; otherwise, the accent color and emoji pattern of messages will be changed.</param>
		/// <param name="color"><a href="https://corefork.telegram.org/api/colors">ID of the accent color palette »</a> to use (not RGB24, see <a href="https://corefork.telegram.org/api/colors">here »</a> for more info).</param>
		/// <param name="background_emoji_id">Custom emoji ID used in the accent color pattern.</param>
		public static Task<bool> Account_UpdateColor(this Client client, long? background_emoji_id = null, int? color = null, bool for_profile = false)
			=> client.Invoke(new Account_UpdateColor
			{
				flags = (Account_UpdateColor.Flags)((background_emoji_id != null ? 0x1 : 0) | (color != null ? 0x4 : 0) | (for_profile ? 0x2 : 0)),
				color = color ?? default,
				background_emoji_id = background_emoji_id ?? default,
			});

		/// <summary>Get a set of suggested <a href="https://corefork.telegram.org/api/custom-emoji">custom emoji stickers</a> that can be used in an <a href="https://corefork.telegram.org/api/colors">accent color pattern</a>.		<para>See <a href="https://corefork.telegram.org/method/account.getDefaultBackgroundEmojis"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/emojiListNotModified">emojiListNotModified</a></returns>
		public static Task<EmojiList> Account_GetDefaultBackgroundEmojis(this Client client, long hash = default)
			=> client.Invoke(new Account_GetDefaultBackgroundEmojis
			{
				hash = hash,
			});

		/// <summary>Get a list of default suggested <a href="https://corefork.telegram.org/api/emoji-status">channel emoji statuses</a>.		<para>See <a href="https://corefork.telegram.org/method/account.getChannelDefaultEmojiStatuses"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/account.emojiStatusesNotModified">account.emojiStatusesNotModified</a></returns>
		public static Task<Account_EmojiStatuses> Account_GetChannelDefaultEmojiStatuses(this Client client, long hash = default)
			=> client.Invoke(new Account_GetChannelDefaultEmojiStatuses
			{
				hash = hash,
			});

		/// <summary>Returns fetch the full list of <a href="https://corefork.telegram.org/api/custom-emoji">custom emoji IDs »</a> that cannot be used in <a href="https://corefork.telegram.org/api/emoji-status">channel emoji statuses »</a>.		<para>See <a href="https://corefork.telegram.org/method/account.getChannelRestrictedStatusEmojis"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/emojiListNotModified">emojiListNotModified</a></returns>
		public static Task<EmojiList> Account_GetChannelRestrictedStatusEmojis(this Client client, long hash = default)
			=> client.Invoke(new Account_GetChannelRestrictedStatusEmojis
			{
				hash = hash,
			});

		/// <summary>Specify a set of <a href="https://corefork.telegram.org/api/business#opening-hours">Telegram Business opening hours</a>.<br/>This info will be contained in <see cref="UserFull"/>.<c>business_work_hours</c>.		<para>See <a href="https://corefork.telegram.org/method/account.updateBusinessWorkHours"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.updateBusinessWorkHours#possible-errors">details</a>)</para></summary>
		/// <param name="business_work_hours">Opening hours (optional, if not set removes all opening hours).</param>
		public static Task<bool> Account_UpdateBusinessWorkHours(this Client client, BusinessWorkHours business_work_hours = null)
			=> client.Invoke(new Account_UpdateBusinessWorkHours
			{
				flags = (Account_UpdateBusinessWorkHours.Flags)(business_work_hours != null ? 0x1 : 0),
				business_work_hours = business_work_hours,
			});

		/// <summary><a href="https://corefork.telegram.org/api/business#location">Businesses »</a> may advertise their location using this method, see <a href="https://corefork.telegram.org/api/business#location">here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/account.updateBusinessLocation"/></para></summary>
		/// <param name="geo_point">Optional, contains a set of geographical coordinates.</param>
		/// <param name="address">Mandatory when setting/updating the location, contains a textual description of the address (max 96 UTF-8 chars).</param>
		public static Task<bool> Account_UpdateBusinessLocation(this Client client, string address = null, InputGeoPoint geo_point = null)
			=> client.Invoke(new Account_UpdateBusinessLocation
			{
				flags = (Account_UpdateBusinessLocation.Flags)((address != null ? 0x1 : 0) | (geo_point != null ? 0x2 : 0)),
				geo_point = geo_point,
				address = address,
			});

		/// <summary>Set a list of <a href="https://corefork.telegram.org/api/business#greeting-messages">Telegram Business greeting messages</a>.		<para>See <a href="https://corefork.telegram.org/method/account.updateBusinessGreetingMessage"/></para></summary>
		/// <param name="message">Greeting message configuration and contents.</param>
		public static Task<bool> Account_UpdateBusinessGreetingMessage(this Client client, InputBusinessGreetingMessage message = null)
			=> client.Invoke(new Account_UpdateBusinessGreetingMessage
			{
				flags = (Account_UpdateBusinessGreetingMessage.Flags)(message != null ? 0x1 : 0),
				message = message,
			});

		/// <summary>Set a list of <a href="https://corefork.telegram.org/api/business#away-messages">Telegram Business away messages</a>.		<para>See <a href="https://corefork.telegram.org/method/account.updateBusinessAwayMessage"/></para></summary>
		/// <param name="message">Away message configuration and contents.</param>
		public static Task<bool> Account_UpdateBusinessAwayMessage(this Client client, InputBusinessAwayMessage message = null)
			=> client.Invoke(new Account_UpdateBusinessAwayMessage
			{
				flags = (Account_UpdateBusinessAwayMessage.Flags)(message != null ? 0x1 : 0),
				message = message,
			});

		/// <summary>Connect a <a href="https://corefork.telegram.org/api/business#connected-bots">business bot »</a> to the current account, or to change the current connection settings.		<para>See <a href="https://corefork.telegram.org/method/account.updateConnectedBot"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/account.updateConnectedBot#possible-errors">details</a>)</para></summary>
		/// <param name="can_reply">Whether the bot can reply to messages it receives from us, on behalf of us using the <a href="https://corefork.telegram.org/api/business#connected-bots">business connection</a>.</param>
		/// <param name="deleted">Whether to fully disconnect the bot from the current account.</param>
		/// <param name="bot">The bot to connect or disconnect</param>
		/// <param name="recipients">Configuration for the business connection</param>
		public static Task<UpdatesBase> Account_UpdateConnectedBot(this Client client, InputUserBase bot, InputBusinessBotRecipients recipients, bool can_reply = false, bool deleted = false)
			=> client.Invoke(new Account_UpdateConnectedBot
			{
				flags = (Account_UpdateConnectedBot.Flags)((can_reply ? 0x1 : 0) | (deleted ? 0x2 : 0)),
				bot = bot,
				recipients = recipients,
			});

		/// <summary>List all currently connected <a href="https://corefork.telegram.org/api/business#connected-bots">business bots »</a>		<para>See <a href="https://corefork.telegram.org/method/account.getConnectedBots"/></para></summary>
		public static Task<Account_ConnectedBots> Account_GetConnectedBots(this Client client)
			=> client.Invoke(new Account_GetConnectedBots
			{
			});

		/// <summary>Bots may invoke this method to re-fetch the <see cref="UpdateBotBusinessConnect"/> associated with a specific <a href="https://corefork.telegram.org/api/business#connected-bots">business <c>connection_id</c>, see here »</a> for more info on connected business bots.<br/>This is needed for example for freshly logged in bots that are receiving some <see cref="UpdateBotNewBusinessMessage"/>, etc. updates because some users have already connected to the bot before it could login.<br/>In this case, the bot is receiving messages from the business connection, but it hasn't cached the associated <see cref="UpdateBotBusinessConnect"/> with info about the connection (can it reply to messages? etc.) yet, and cannot receive the old ones because they were sent when the bot wasn't logged into the session yet.<br/>This method can be used to fetch info about a not-yet-cached business connection, and should not be invoked if the info is already cached or to fetch changes, as eventual changes will automatically be sent as new <see cref="UpdateBotBusinessConnect"/> updates to the bot using the usual <a href="https://corefork.telegram.org/api/updates">update delivery methods »</a>.		<para>See <a href="https://corefork.telegram.org/method/account.getBotBusinessConnection"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.getBotBusinessConnection#possible-errors">details</a>)</para></summary>
		/// <param name="connection_id"><a href="https://corefork.telegram.org/api/business#connected-bots">Business connection ID »</a>.</param>
		public static Task<UpdatesBase> Account_GetBotBusinessConnection(this Client client, string connection_id)
			=> client.Invoke(new Account_GetBotBusinessConnection
			{
				connection_id = connection_id,
			});

		/// <summary>Set or remove the <a href="https://corefork.telegram.org/api/business#business-introduction">Telegram Business introduction »</a>.		<para>See <a href="https://corefork.telegram.org/method/account.updateBusinessIntro"/></para></summary>
		/// <param name="intro">Telegram Business introduction, to remove it call the method without setting this flag.</param>
		public static Task<bool> Account_UpdateBusinessIntro(this Client client, InputBusinessIntro intro = null)
			=> client.Invoke(new Account_UpdateBusinessIntro
			{
				flags = (Account_UpdateBusinessIntro.Flags)(intro != null ? 0x1 : 0),
				intro = intro,
			});

		/// <summary>Pause or unpause a specific chat, temporarily disconnecting it from all <a href="https://corefork.telegram.org/api/business#connected-bots">business bots »</a>.		<para>See <a href="https://corefork.telegram.org/method/account.toggleConnectedBotPaused"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.toggleConnectedBotPaused#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The chat to pause</param>
		/// <param name="paused">Whether to pause or unpause the chat</param>
		public static Task<bool> Account_ToggleConnectedBotPaused(this Client client, InputPeer peer, bool paused)
			=> client.Invoke(new Account_ToggleConnectedBotPaused
			{
				peer = peer,
				paused = paused,
			});

		/// <summary>Permanently disconnect a specific chat from all <a href="https://corefork.telegram.org/api/business#connected-bots">business bots »</a> (equivalent to specifying it in <c>recipients.exclude_users</c> during initial configuration with <see cref="Account_UpdateConnectedBot">Account_UpdateConnectedBot</see>); to reconnect of a chat disconnected using this method the user must reconnect the entire bot by invoking <see cref="Account_UpdateConnectedBot">Account_UpdateConnectedBot</see>.		<para>See <a href="https://corefork.telegram.org/method/account.disablePeerConnectedBot"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.disablePeerConnectedBot#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The chat to disconnect</param>
		public static Task<bool> Account_DisablePeerConnectedBot(this Client client, InputPeer peer)
			=> client.Invoke(new Account_DisablePeerConnectedBot
			{
				peer = peer,
			});

		/// <summary>Update our <a href="https://corefork.telegram.org/api/profile#birthday">birthday, see here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/account.updateBirthday"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.updateBirthday#possible-errors">details</a>)</para></summary>
		/// <param name="birthday">Birthday.</param>
		public static Task<bool> Account_UpdateBirthday(this Client client, Birthday birthday = null)
			=> client.Invoke(new Account_UpdateBirthday
			{
				flags = (Account_UpdateBirthday.Flags)(birthday != null ? 0x1 : 0),
				birthday = birthday,
			});

		/// <summary>Create a <a href="https://corefork.telegram.org/api/business#business-chat-links">business chat deep link »</a>.		<para>See <a href="https://corefork.telegram.org/method/account.createBusinessChatLink"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/account.createBusinessChatLink#possible-errors">details</a>)</para></summary>
		/// <param name="link">Info about the link to create.</param>
		public static Task<BusinessChatLink> Account_CreateBusinessChatLink(this Client client, InputBusinessChatLink link)
			=> client.Invoke(new Account_CreateBusinessChatLink
			{
				link = link,
			});

		/// <summary>Edit a created <a href="https://corefork.telegram.org/api/business#business-chat-links">business chat deep link »</a>.		<para>See <a href="https://corefork.telegram.org/method/account.editBusinessChatLink"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/account.editBusinessChatLink#possible-errors">details</a>)</para></summary>
		/// <param name="slug">Slug of the link, obtained as specified <a href="https://corefork.telegram.org/api/links#business-chat-links">here »</a>.</param>
		/// <param name="link">New link information.</param>
		public static Task<BusinessChatLink> Account_EditBusinessChatLink(this Client client, string slug, InputBusinessChatLink link)
			=> client.Invoke(new Account_EditBusinessChatLink
			{
				slug = slug,
				link = link,
			});

		/// <summary>Delete a <a href="https://corefork.telegram.org/api/business#business-chat-links">business chat deep link »</a>.		<para>See <a href="https://corefork.telegram.org/method/account.deleteBusinessChatLink"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.deleteBusinessChatLink#possible-errors">details</a>)</para></summary>
		/// <param name="slug">Slug of the link, obtained as specified <a href="https://corefork.telegram.org/api/links#business-chat-links">here »</a>.</param>
		public static Task<bool> Account_DeleteBusinessChatLink(this Client client, string slug)
			=> client.Invoke(new Account_DeleteBusinessChatLink
			{
				slug = slug,
			});

		/// <summary>List all created <a href="https://corefork.telegram.org/api/business#business-chat-links">business chat deep links »</a>.		<para>See <a href="https://corefork.telegram.org/method/account.getBusinessChatLinks"/></para></summary>
		public static Task<Account_BusinessChatLinks> Account_GetBusinessChatLinks(this Client client)
			=> client.Invoke(new Account_GetBusinessChatLinks
			{
			});

		/// <summary>Resolve a <a href="https://corefork.telegram.org/api/business#business-chat-links">business chat deep link »</a>.		<para>See <a href="https://corefork.telegram.org/method/account.resolveBusinessChatLink"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.resolveBusinessChatLink#possible-errors">details</a>)</para></summary>
		/// <param name="slug">Slug of the link, obtained as specified <a href="https://corefork.telegram.org/api/links#business-chat-links">here »</a>.</param>
		public static Task<Account_ResolvedBusinessChatLinks> Account_ResolveBusinessChatLink(this Client client, string slug)
			=> client.Invoke(new Account_ResolveBusinessChatLink
			{
				slug = slug,
			});

		/// <summary>Associate (or remove) a personal <a href="https://corefork.telegram.org/api/channel">channel »</a>, that will be listed on our personal <a href="https://corefork.telegram.org/api/profile#personal-channel">profile page »</a>.		<para>See <a href="https://corefork.telegram.org/method/account.updatePersonalChannel"/></para></summary>
		/// <param name="channel">The channel, pass <see langword="null"/> to remove it.</param>
		public static Task<bool> Account_UpdatePersonalChannel(this Client client, InputChannelBase channel)
			=> client.Invoke(new Account_UpdatePersonalChannel
			{
				channel = channel,
			});

		/// <summary>Disable or re-enable Telegram ads for the current <a href="https://corefork.telegram.org/api/premium">Premium</a> account.		<para>See <a href="https://corefork.telegram.org/method/account.toggleSponsoredMessages"/></para></summary>
		/// <param name="enabled">Enable or disable ads.</param>
		public static Task<bool> Account_ToggleSponsoredMessages(this Client client, bool enabled)
			=> client.Invoke(new Account_ToggleSponsoredMessages
			{
				enabled = enabled,
			});

		/// <summary>Get the current <a href="https://corefork.telegram.org/api/reactions#notifications-about-reactions">reaction notification settings »</a>.		<para>See <a href="https://corefork.telegram.org/method/account.getReactionsNotifySettings"/></para></summary>
		public static Task<ReactionsNotifySettings> Account_GetReactionsNotifySettings(this Client client)
			=> client.Invoke(new Account_GetReactionsNotifySettings
			{
			});

		/// <summary>Change the <a href="https://corefork.telegram.org/api/reactions#notifications-about-reactions">reaction notification settings »</a>.		<para>See <a href="https://corefork.telegram.org/method/account.setReactionsNotifySettings"/></para></summary>
		/// <param name="settings">New reaction notification settings.</param>
		public static Task<ReactionsNotifySettings> Account_SetReactionsNotifySettings(this Client client, ReactionsNotifySettings settings)
			=> client.Invoke(new Account_SetReactionsNotifySettings
			{
				settings = settings,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/account.getCollectibleEmojiStatuses"/></para></summary>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/account.emojiStatusesNotModified">account.emojiStatusesNotModified</a></returns>
		public static Task<Account_EmojiStatuses> Account_GetCollectibleEmojiStatuses(this Client client, long hash = default)
			=> client.Invoke(new Account_GetCollectibleEmojiStatuses
			{
				hash = hash,
			});

		/// <summary>Returns basic user info according to their identifiers.		<para>See <a href="https://corefork.telegram.org/method/users.getUsers"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/users.getUsers#possible-errors">details</a>)</para></summary>
		/// <param name="id">List of user identifiers</param>
		public static Task<UserBase[]> Users_GetUsers(this Client client, params InputUserBase[] id)
			=> client.Invoke(new Users_GetUsers
			{
				id = id,
			});

		/// <summary>Returns extended user info by ID.		<para>See <a href="https://corefork.telegram.org/method/users.getFullUser"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/users.getFullUser#possible-errors">details</a>)</para></summary>
		/// <param name="id">User ID</param>
		public static Task<Users_UserFull> Users_GetFullUser(this Client client, InputUserBase id)
			=> client.Invoke(new Users_GetFullUser
			{
				id = id,
			});

		/// <summary>Notify the user that the sent <a href="https://corefork.telegram.org/passport">passport</a> data contains some errors The user will not be able to re-submit their Passport data to you until the errors are fixed (the contents of the field for which you returned the error must change).		<para>See <a href="https://corefork.telegram.org/method/users.setSecureValueErrors"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/users.setSecureValueErrors#possible-errors">details</a>)</para></summary>
		/// <param name="id">The user</param>
		/// <param name="errors">Errors</param>
		public static Task<bool> Users_SetSecureValueErrors(this Client client, InputUserBase id, params SecureValueErrorBase[] errors)
			=> client.Invoke(new Users_SetSecureValueErrors
			{
				id = id,
				errors = errors,
			});

		/// <summary>Check whether we can write to the specified user (this method can only be called by non-<a href="https://corefork.telegram.org/api/premium">Premium</a> users), see <a href="https://corefork.telegram.org/api/privacy#require-premium-for-new-non-contact-users">here »</a> for more info on the full flow.		<para>See <a href="https://corefork.telegram.org/method/users.getIsPremiumRequiredToContact"/></para></summary>
		/// <param name="id">Users to fetch info about.</param>
		public static Task<bool[]> Users_GetIsPremiumRequiredToContact(this Client client, params InputUserBase[] id)
			=> client.Invoke(new Users_GetIsPremiumRequiredToContact
			{
				id = id,
			});

		/// <summary>Get the telegram IDs of all contacts.<br/>Returns an array of Telegram user IDs for all contacts (0 if a contact does not have an associated Telegram account or have hidden their account using privacy settings).		<para>See <a href="https://corefork.telegram.org/method/contacts.getContactIDs"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a></param>
		public static Task<int[]> Contacts_GetContactIDs(this Client client, long hash = default)
			=> client.Invoke(new Contacts_GetContactIDs
			{
				hash = hash,
			});

		/// <summary>Use this method to obtain the online statuses of all contacts with an accessible Telegram account.		<para>See <a href="https://corefork.telegram.org/method/contacts.getStatuses"/></para></summary>
		public static Task<ContactStatus[]> Contacts_GetStatuses(this Client client)
			=> client.Invoke(new Contacts_GetStatuses
			{
			});

		/// <summary>Returns the current user's contact list.		<para>See <a href="https://corefork.telegram.org/method/contacts.getContacts"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.<br/>Note that the hash is computed <a href="https://corefork.telegram.org/api/offsets#hash-generation">using the usual algorithm</a>, passing to the algorithm first the previously returned <see cref="Contacts_Contacts"/>.<c>saved_count</c> field, then max <c>100000</c> sorted user IDs from the contact list, including the ID of the currently logged in user if it is saved as a contact. <br/>Example: <a href="https://github.com/tdlib/td/blob/63c7d0301825b78c30dc7307f1f1466be049eb79/td/telegram/UserManager.cpp#L5754">tdlib implementation</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/contacts.contactsNotModified">contacts.contactsNotModified</a></returns>
		public static Task<Contacts_Contacts> Contacts_GetContacts(this Client client, long hash = default)
			=> client.Invoke(new Contacts_GetContacts
			{
				hash = hash,
			});

		/// <summary>Imports contacts: saves a full list on the server, adds already registered contacts to the contact list, returns added contacts and their info.		<para>See <a href="https://corefork.telegram.org/method/contacts.importContacts"/></para></summary>
		/// <param name="contacts">List of contacts to import</param>
		public static Task<Contacts_ImportedContacts> Contacts_ImportContacts(this Client client, params InputContact[] contacts)
			=> client.Invoke(new Contacts_ImportContacts
			{
				contacts = contacts,
			});

		/// <summary>Deletes several contacts from the list.		<para>See <a href="https://corefork.telegram.org/method/contacts.deleteContacts"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/contacts.deleteContacts#possible-errors">details</a>)</para></summary>
		/// <param name="id">User ID list</param>
		public static Task<UpdatesBase> Contacts_DeleteContacts(this Client client, params InputUserBase[] id)
			=> client.Invoke(new Contacts_DeleteContacts
			{
				id = id,
			});

		/// <summary>Delete contacts by phone number		<para>See <a href="https://corefork.telegram.org/method/contacts.deleteByPhones"/></para></summary>
		/// <param name="phones">Phone numbers</param>
		public static Task<bool> Contacts_DeleteByPhones(this Client client, params string[] phones)
			=> client.Invoke(new Contacts_DeleteByPhones
			{
				phones = phones,
			});

		/// <summary>Adds a peer to a blocklist, see <a href="https://corefork.telegram.org/api/block">here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/contacts.block"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/contacts.block#possible-errors">details</a>)</para></summary>
		/// <param name="my_stories_from">Whether the peer should be added to the story blocklist; if not set, the peer will be added to the main blocklist, see <a href="https://corefork.telegram.org/api/block">here »</a> for more info.</param>
		/// <param name="id">Peer</param>
		public static Task<bool> Contacts_Block(this Client client, InputPeer id, bool my_stories_from = false)
			=> client.Invoke(new Contacts_Block
			{
				flags = (Contacts_Block.Flags)(my_stories_from ? 0x1 : 0),
				id = id,
			});

		/// <summary>Deletes a peer from a blocklist, see <a href="https://corefork.telegram.org/api/block">here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/contacts.unblock"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/contacts.unblock#possible-errors">details</a>)</para></summary>
		/// <param name="my_stories_from">Whether the peer should be removed from the story blocklist; if not set, the peer will be removed from the main blocklist, see <a href="https://corefork.telegram.org/api/block">here »</a> for more info.</param>
		/// <param name="id">Peer</param>
		public static Task<bool> Contacts_Unblock(this Client client, InputPeer id, bool my_stories_from = false)
			=> client.Invoke(new Contacts_Unblock
			{
				flags = (Contacts_Unblock.Flags)(my_stories_from ? 0x1 : 0),
				id = id,
			});

		/// <summary>Returns the list of blocked users.		<para>See <a href="https://corefork.telegram.org/method/contacts.getBlocked"/></para></summary>
		/// <param name="my_stories_from">Whether to fetch the story blocklist; if not set, will fetch the main blocklist. See <a href="https://corefork.telegram.org/api/block">here »</a> for differences between the two.</param>
		/// <param name="offset">The number of list elements to be skipped</param>
		/// <param name="limit">The number of list elements to be returned</param>
		public static Task<Contacts_Blocked> Contacts_GetBlocked(this Client client, int offset = default, int limit = int.MaxValue, bool my_stories_from = false)
			=> client.Invoke(new Contacts_GetBlocked
			{
				flags = (Contacts_GetBlocked.Flags)(my_stories_from ? 0x1 : 0),
				offset = offset,
				limit = limit,
			});

		/// <summary>Returns users found by username substring.		<para>See <a href="https://corefork.telegram.org/method/contacts.search"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/contacts.search#possible-errors">details</a>)</para></summary>
		/// <param name="q">Target substring</param>
		/// <param name="limit">Maximum number of users to be returned</param>
		public static Task<Contacts_Found> Contacts_Search(this Client client, string q, int limit = int.MaxValue)
			=> client.Invoke(new Contacts_Search
			{
				q = q,
				limit = limit,
			});

		/// <summary>Resolve a @username to get peer info		<para>See <a href="https://corefork.telegram.org/method/contacts.resolveUsername"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/contacts.resolveUsername#possible-errors">details</a>)</para></summary>
		/// <param name="username">@username to resolve</param>
		/// <param name="referer"><a href="https://corefork.telegram.org/api/links#referral-links">Referrer ID from referral links »</a>.</param>
		public static Task<Contacts_ResolvedPeer> Contacts_ResolveUsername(this Client client, string username, string referer = null)
			=> client.Invoke(new Contacts_ResolveUsername
			{
				flags = (Contacts_ResolveUsername.Flags)(referer != null ? 0x1 : 0),
				username = username,
				referer = referer,
			});

		/// <summary>Get most used peers		<para>See <a href="https://corefork.telegram.org/method/contacts.getTopPeers"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/contacts.getTopPeers#possible-errors">details</a>)</para></summary>
		/// <param name="correspondents">Users we've chatted most frequently with</param>
		/// <param name="bots_pm">Most used bots</param>
		/// <param name="bots_inline">Most used inline bots</param>
		/// <param name="phone_calls">Most frequently called users</param>
		/// <param name="forward_users">Users to which the users often forwards messages to</param>
		/// <param name="forward_chats">Chats to which the users often forwards messages to</param>
		/// <param name="groups">Often-opened groups and supergroups</param>
		/// <param name="channels">Most frequently visited channels</param>
		/// <param name="bots_app">Most frequently used <a href="https://corefork.telegram.org/api/bots/webapps#main-mini-apps">Main Mini Bot Apps</a>.</param>
		/// <param name="offset">Offset for <a href="https://corefork.telegram.org/api/offsets">pagination</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/contacts.topPeersNotModified">contacts.topPeersNotModified</a></returns>
		public static Task<Contacts_TopPeersBase> Contacts_GetTopPeers(this Client client, int offset = default, int limit = int.MaxValue, long hash = default, bool correspondents = false, bool bots_pm = false, bool bots_inline = false, bool phone_calls = false, bool forward_users = false, bool forward_chats = false, bool groups = false, bool channels = false, bool bots_app = false)
			=> client.Invoke(new Contacts_GetTopPeers
			{
				flags = (Contacts_GetTopPeers.Flags)((correspondents ? 0x1 : 0) | (bots_pm ? 0x2 : 0) | (bots_inline ? 0x4 : 0) | (phone_calls ? 0x8 : 0) | (forward_users ? 0x10 : 0) | (forward_chats ? 0x20 : 0) | (groups ? 0x400 : 0) | (channels ? 0x8000 : 0) | (bots_app ? 0x10000 : 0)),
				offset = offset,
				limit = limit,
				hash = hash,
			});

		/// <summary>Reset <a href="https://corefork.telegram.org/api/top-rating">rating</a> of top peer		<para>See <a href="https://corefork.telegram.org/method/contacts.resetTopPeerRating"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/contacts.resetTopPeerRating#possible-errors">details</a>)</para></summary>
		/// <param name="category">Top peer category</param>
		/// <param name="peer">Peer whose rating should be reset</param>
		public static Task<bool> Contacts_ResetTopPeerRating(this Client client, TopPeerCategory category, InputPeer peer)
			=> client.Invoke(new Contacts_ResetTopPeerRating
			{
				category = category,
				peer = peer,
			});

		/// <summary>Removes all contacts without an associated Telegram account.		<para>See <a href="https://corefork.telegram.org/method/contacts.resetSaved"/></para></summary>
		public static Task<bool> Contacts_ResetSaved(this Client client)
			=> client.Invoke(new Contacts_ResetSaved
			{
			});

		/// <summary>Get all contacts, requires a <a href="https://corefork.telegram.org/api/takeout">takeout session, see here » for more info</a>.		<para>See <a href="https://corefork.telegram.org/method/contacts.getSaved"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/contacts.getSaved#possible-errors">details</a>)</para></summary>
		public static Task<SavedContact[]> Contacts_GetSaved(this Client client)
			=> client.Invoke(new Contacts_GetSaved
			{
			});

		/// <summary>Enable/disable <a href="https://corefork.telegram.org/api/top-rating">top peers</a>		<para>See <a href="https://corefork.telegram.org/method/contacts.toggleTopPeers"/></para></summary>
		/// <param name="enabled">Enable/disable</param>
		public static Task<bool> Contacts_ToggleTopPeers(this Client client, bool enabled)
			=> client.Invoke(new Contacts_ToggleTopPeers
			{
				enabled = enabled,
			});

		/// <summary>Add an existing telegram user as contact.		<para>See <a href="https://corefork.telegram.org/method/contacts.addContact"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/contacts.addContact#possible-errors">details</a>)</para></summary>
		/// <param name="add_phone_privacy_exception">Allow the other user to see our phone number?</param>
		/// <param name="id">Telegram ID of the other user</param>
		/// <param name="first_name">First name</param>
		/// <param name="last_name">Last name</param>
		/// <param name="phone">User's phone number, may be omitted to simply add the user to the contact list, without a phone number.</param>
		public static Task<UpdatesBase> Contacts_AddContact(this Client client, InputUserBase id, string first_name, string last_name, string phone, bool add_phone_privacy_exception = false)
			=> client.Invoke(new Contacts_AddContact
			{
				flags = (Contacts_AddContact.Flags)(add_phone_privacy_exception ? 0x1 : 0),
				id = id,
				first_name = first_name,
				last_name = last_name,
				phone = phone,
			});

		/// <summary>If the <a href="https://corefork.telegram.org/api/action-bar#add-contact">add contact action bar is active</a>, add that user as contact		<para>See <a href="https://corefork.telegram.org/method/contacts.acceptContact"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/contacts.acceptContact#possible-errors">details</a>)</para></summary>
		/// <param name="id">The user to add as contact</param>
		public static Task<UpdatesBase> Contacts_AcceptContact(this Client client, InputUserBase id)
			=> client.Invoke(new Contacts_AcceptContact
			{
				id = id,
			});

		/// <summary>Get users and geochats near you, see <a href="https://corefork.telegram.org/api/nearby">here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/contacts.getLocated"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/contacts.getLocated#possible-errors">details</a>)</para></summary>
		/// <param name="background">While the geolocation of the current user is public, clients should update it in the background every half-an-hour or so, while setting this flag. <br/>Do this only if the new location is more than 1 KM away from the previous one, or if the previous location is unknown.</param>
		/// <param name="geo_point">Geolocation</param>
		/// <param name="self_expires">If set, the geolocation of the current user will be public for the specified number of seconds; pass 0x7fffffff to disable expiry, 0 to make the current geolocation private; if the flag isn't set, no changes will be applied.</param>
		public static Task<UpdatesBase> Contacts_GetLocated(this Client client, InputGeoPoint geo_point, int? self_expires = null, bool background = false)
			=> client.Invoke(new Contacts_GetLocated
			{
				flags = (Contacts_GetLocated.Flags)((self_expires != null ? 0x1 : 0) | (background ? 0x2 : 0)),
				geo_point = geo_point,
				self_expires = self_expires ?? default,
			});

		/// <summary>Stop getting notifications about <a href="https://corefork.telegram.org/api/discussion">discussion replies</a> of a certain user in <c>@replies</c>		<para>See <a href="https://corefork.telegram.org/method/contacts.blockFromReplies"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/contacts.blockFromReplies#possible-errors">details</a>)</para></summary>
		/// <param name="delete_message">Whether to delete the specified message as well</param>
		/// <param name="delete_history">Whether to delete all <c>@replies</c> messages from this user as well</param>
		/// <param name="report_spam">Whether to also report this user for spam</param>
		/// <param name="msg_id">ID of the message in the <a href="https://corefork.telegram.org/api/discussion#replies">@replies</a> chat</param>
		public static Task<UpdatesBase> Contacts_BlockFromReplies(this Client client, int msg_id, bool delete_message = false, bool delete_history = false, bool report_spam = false)
			=> client.Invoke(new Contacts_BlockFromReplies
			{
				flags = (Contacts_BlockFromReplies.Flags)((delete_message ? 0x1 : 0) | (delete_history ? 0x2 : 0) | (report_spam ? 0x4 : 0)),
				msg_id = msg_id,
			});

		/// <summary>Resolve a phone number to get user info, if their privacy settings allow it.		<para>See <a href="https://corefork.telegram.org/method/contacts.resolvePhone"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/contacts.resolvePhone#possible-errors">details</a>)</para></summary>
		/// <param name="phone">Phone number in international format, possibly obtained from a <a href="https://corefork.telegram.org/api/links#phone-number-links">phone number deep link</a>.</param>
		public static Task<Contacts_ResolvedPeer> Contacts_ResolvePhone(this Client client, string phone)
			=> client.Invoke(new Contacts_ResolvePhone
			{
				phone = phone,
			});

		/// <summary>Generates a <a href="https://corefork.telegram.org/api/links#temporary-profile-links">temporary profile link</a> for the currently logged-in user.		<para>See <a href="https://corefork.telegram.org/method/contacts.exportContactToken"/></para></summary>
		public static Task<ExportedContactToken> Contacts_ExportContactToken(this Client client)
			=> client.Invoke(new Contacts_ExportContactToken
			{
			});

		/// <summary>Obtain user info from a <a href="https://corefork.telegram.org/api/links#temporary-profile-links">temporary profile link</a>.		<para>See <a href="https://corefork.telegram.org/method/contacts.importContactToken"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/contacts.importContactToken#possible-errors">details</a>)</para></summary>
		/// <param name="token">The token extracted from the <a href="https://corefork.telegram.org/api/links#temporary-profile-links">temporary profile link</a>.</param>
		public static Task<UserBase> Contacts_ImportContactToken(this Client client, string token)
			=> client.Invoke(new Contacts_ImportContactToken
			{
				token = token,
			});

		/// <summary>Edit the <a href="https://corefork.telegram.org/api/privacy">close friends list, see here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/contacts.editCloseFriends"/></para></summary>
		/// <param name="id">Full list of user IDs of close friends, see <a href="https://corefork.telegram.org/api/privacy">here</a> for more info.</param>
		public static Task<bool> Contacts_EditCloseFriends(this Client client, params long[] id)
			=> client.Invoke(new Contacts_EditCloseFriends
			{
				id = id,
			});

		/// <summary>Replace the contents of an entire <a href="https://corefork.telegram.org/api/block">blocklist, see here for more info »</a>.		<para>See <a href="https://corefork.telegram.org/method/contacts.setBlocked"/></para></summary>
		/// <param name="my_stories_from">Whether to edit the story blocklist; if not set, will edit the main blocklist. See <a href="https://corefork.telegram.org/api/block">here »</a> for differences between the two.</param>
		/// <param name="id">Full content of the blocklist.</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<bool> Contacts_SetBlocked(this Client client, InputPeer[] id, int limit = int.MaxValue, bool my_stories_from = false)
			=> client.Invoke(new Contacts_SetBlocked
			{
				flags = (Contacts_SetBlocked.Flags)(my_stories_from ? 0x1 : 0),
				id = id,
				limit = limit,
			});

		/// <summary>Fetch all users with birthdays that fall within +1/-1 days, relative to the current day: this method should be invoked by clients every 6-8 hours, and if the result is non-empty, it should be used to appropriately update locally cached birthday information in <see cref="User"/>.<c>birthday</c>.		<para>See <a href="https://corefork.telegram.org/method/contacts.getBirthdays"/></para></summary>
		public static Task<Contacts_ContactBirthdays> Contacts_GetBirthdays(this Client client)
			=> client.Invoke(new Contacts_GetBirthdays
			{
			});

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://wiz0u.github.io/WTelegramClient/#terminology">Terminology</see> in the README to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Returns the list of messages by their IDs.		<para>See <a href="https://corefork.telegram.org/method/messages.getMessages"/> [bots: ✓]</para></summary>
		/// <param name="id">Message ID list</param>
		public static Task<Messages_MessagesBase> Messages_GetMessages(this Client client, params InputMessage[] id)
			=> client.Invoke(new Messages_GetMessages
			{
				id = id,
			});

		/// <summary>Returns the current user dialog list.		<para>See <a href="https://corefork.telegram.org/method/messages.getDialogs"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.getDialogs#possible-errors">details</a>)</para></summary>
		/// <param name="exclude_pinned">Exclude pinned dialogs</param>
		/// <param name="folder_id"><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></param>
		/// <param name="offset_date"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a> (<c>top_message</c> ID used for pagination)</param>
		/// <param name="offset_peer"><a href="https://corefork.telegram.org/api/offsets">Offset peer for pagination</a></param>
		/// <param name="limit">Number of list elements to be returned</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a></param>
		public static Task<Messages_DialogsBase> Messages_GetDialogs(this Client client, DateTime offset_date = default, int offset_id = default, InputPeer offset_peer = null, int limit = int.MaxValue, long hash = default, int? folder_id = null, bool exclude_pinned = false)
			=> client.Invoke(new Messages_GetDialogs
			{
				flags = (Messages_GetDialogs.Flags)((folder_id != null ? 0x2 : 0) | (exclude_pinned ? 0x1 : 0)),
				folder_id = folder_id ?? default,
				offset_date = offset_date,
				offset_id = offset_id,
				offset_peer = offset_peer,
				limit = limit,
				hash = hash,
			});

		/// <summary>Returns the conversation history with one interlocutor / within a chat		<para>See <a href="https://corefork.telegram.org/method/messages.getHistory"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/messages.getHistory#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Target peer</param>
		/// <param name="offset_id">Only return messages starting from the specified message ID</param>
		/// <param name="offset_date">Only return messages sent before the specified date</param>
		/// <param name="add_offset">Number of list elements to be skipped, negative values are also accepted.</param>
		/// <param name="limit">Number of results to return</param>
		/// <param name="max_id">If a positive value was transferred, the method will return only messages with IDs less than <strong>max_id</strong></param>
		/// <param name="min_id">If a positive value was transferred, the method will return only messages with IDs more than <strong>min_id</strong></param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets">Result hash</a></param>
		public static Task<Messages_MessagesBase> Messages_GetHistory(this Client client, InputPeer peer, int offset_id = default, DateTime offset_date = default, int add_offset = default, int limit = int.MaxValue, int max_id = default, int min_id = default, long hash = default)
			=> client.Invoke(new Messages_GetHistory
			{
				peer = peer,
				offset_id = offset_id,
				offset_date = offset_date,
				add_offset = add_offset,
				limit = limit,
				max_id = max_id,
				min_id = min_id,
				hash = hash,
			});

		/// <summary>Search for messages.		<para>See <a href="https://corefork.telegram.org/method/messages.search"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.search#possible-errors">details</a>)</para></summary>
		/// <param name="peer">User or chat, histories with which are searched, or <see langword="null"/> to search in all private chats and <a href="https://corefork.telegram.org/api/channel">normal groups (not channels) »</a>. Use <see cref="Messages_SearchGlobal">Messages_SearchGlobal</see> to search globally in all chats, groups, supergroups and channels.</param>
		/// <param name="q">Text search request</param>
		/// <param name="from_id">Only return messages sent by the specified user ID</param>
		/// <param name="saved_peer_id">Search within the <a href="https://corefork.telegram.org/api/saved-messages">saved message dialog »</a> with this ID.</param>
		/// <param name="saved_reaction">You may search for <a href="https://corefork.telegram.org/api/saved-messages#tags">saved messages tagged »</a> with one or more reactions using this flag.</param>
		/// <param name="top_msg_id"><a href="https://corefork.telegram.org/api/threads">Thread ID</a></param>
		/// <param name="filter">Filter to return only specified message types</param>
		/// <param name="min_date">If a positive value was transferred, only messages with a sending date bigger than the transferred one will be returned</param>
		/// <param name="max_date">If a positive value was transferred, only messages with a sending date smaller than the transferred one will be returned</param>
		/// <param name="offset_id">Only return messages starting from the specified message ID</param>
		/// <param name="add_offset"><a href="https://corefork.telegram.org/api/offsets">Additional offset</a></param>
		/// <param name="limit"><a href="https://corefork.telegram.org/api/offsets">Number of results to return</a>, can be 0 to only return the message counter.</param>
		/// <param name="max_id"><a href="https://corefork.telegram.org/api/offsets">Maximum message ID to return</a></param>
		/// <param name="min_id"><a href="https://corefork.telegram.org/api/offsets">Minimum message ID to return</a></param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets">Hash</a></param>
		public static Task<Messages_MessagesBase> Messages_Search(this Client client, InputPeer peer, string q, MessagesFilter filter = null, DateTime min_date = default, DateTime max_date = default, int offset_id = default, int add_offset = default, int limit = int.MaxValue, int max_id = default, int min_id = default, long hash = default, InputPeer from_id = null, int? top_msg_id = null, InputPeer saved_peer_id = null, Reaction[] saved_reaction = null)
			=> client.Invoke(new Messages_Search
			{
				flags = (Messages_Search.Flags)((from_id != null ? 0x1 : 0) | (top_msg_id != null ? 0x2 : 0) | (saved_peer_id != null ? 0x4 : 0) | (saved_reaction != null ? 0x8 : 0)),
				peer = peer,
				q = q,
				from_id = from_id,
				saved_peer_id = saved_peer_id,
				saved_reaction = saved_reaction,
				top_msg_id = top_msg_id ?? default,
				filter = filter,
				min_date = min_date,
				max_date = max_date,
				offset_id = offset_id,
				add_offset = add_offset,
				limit = limit,
				max_id = max_id,
				min_id = min_id,
				hash = hash,
			});

		/// <summary>Marks message history as read.		<para>See <a href="https://corefork.telegram.org/method/messages.readHistory"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.readHistory#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Target user or group</param>
		/// <param name="max_id">If a positive value is passed, only messages with identifiers less or equal than the given one will be read</param>
		public static Task<Messages_AffectedMessages> Messages_ReadHistory(this Client client, InputPeer peer, int max_id = default)
			=> client.InvokeAffected(new Messages_ReadHistory
			{
				peer = peer,
				max_id = max_id,
			}, peer is InputPeerChannel ipc ? ipc.channel_id : 0);

		/// <summary>Deletes communication history.		<para>See <a href="https://corefork.telegram.org/method/messages.deleteHistory"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.deleteHistory#possible-errors">details</a>)</para></summary>
		/// <param name="just_clear">Just clear history for the current user, without actually removing messages for every chat user</param>
		/// <param name="revoke">Whether to delete the message history for all chat participants</param>
		/// <param name="peer">User or chat, communication history of which will be deleted</param>
		/// <param name="max_id">Maximum ID of message to delete</param>
		/// <param name="min_date">Delete all messages newer than this UNIX timestamp</param>
		/// <param name="max_date">Delete all messages older than this UNIX timestamp</param>
		public static Task<Messages_AffectedHistory> Messages_DeleteHistory(this Client client, InputPeer peer, int max_id = default, DateTime? min_date = null, DateTime? max_date = null, bool just_clear = false, bool revoke = false)
			=> client.InvokeAffected(new Messages_DeleteHistory
			{
				flags = (Messages_DeleteHistory.Flags)((min_date != null ? 0x4 : 0) | (max_date != null ? 0x8 : 0) | (just_clear ? 0x1 : 0) | (revoke ? 0x2 : 0)),
				peer = peer,
				max_id = max_id,
				min_date = min_date ?? default,
				max_date = max_date ?? default,
			}, peer is InputPeerChannel ipc ? ipc.channel_id : 0);

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://wiz0u.github.io/WTelegramClient/#terminology">Terminology</see> in the README to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Deletes messages by their identifiers.		<para>See <a href="https://corefork.telegram.org/method/messages.deleteMessages"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.deleteMessages#possible-errors">details</a>)</para></summary>
		/// <param name="revoke">Whether to delete messages for all participants of the chat</param>
		/// <param name="id">Message ID list</param>
		public static Task<Messages_AffectedMessages> Messages_DeleteMessages(this Client client, int[] id, bool revoke = false)
			=> client.InvokeAffected(new Messages_DeleteMessages
			{
				flags = (Messages_DeleteMessages.Flags)(revoke ? 0x1 : 0),
				id = id,
			}, 0);

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://wiz0u.github.io/WTelegramClient/#terminology">Terminology</see> in the README to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Confirms receipt of messages by a client, cancels PUSH-notification sending.		<para>See <a href="https://corefork.telegram.org/method/messages.receivedMessages"/></para></summary>
		/// <param name="max_id">Maximum message ID available in a client.</param>
		public static Task<ReceivedNotifyMessage[]> Messages_ReceivedMessages(this Client client, int max_id = default)
			=> client.Invoke(new Messages_ReceivedMessages
			{
				max_id = max_id,
			});

		/// <summary>Sends a current user typing event (see <see cref="SendMessageAction"/> for all event types) to a conversation partner or group.		<para>See <a href="https://corefork.telegram.org/method/messages.setTyping"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403,406 (<a href="https://corefork.telegram.org/method/messages.setTyping#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Target user or group</param>
		/// <param name="top_msg_id"><a href="https://corefork.telegram.org/api/threads">Topic ID</a></param>
		/// <param name="action">Type of action</param>
		public static Task<bool> Messages_SetTyping(this Client client, InputPeer peer, SendMessageAction action, int? top_msg_id = null)
			=> client.Invoke(new Messages_SetTyping
			{
				flags = (Messages_SetTyping.Flags)(top_msg_id != null ? 0x1 : 0),
				peer = peer,
				top_msg_id = top_msg_id ?? default,
				action = action,
			});

		/// <summary>Sends a message to a chat		<para>See <a href="https://corefork.telegram.org/method/messages.sendMessage"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403,404,406,420,500 (<a href="https://corefork.telegram.org/method/messages.sendMessage#possible-errors">details</a>)</para></summary>
		/// <param name="no_webpage">Set this flag to disable generation of the webpage preview</param>
		/// <param name="silent">Send this message silently (no notifications for the receivers)</param>
		/// <param name="background">Send this message as background message</param>
		/// <param name="clear_draft">Clear the draft field</param>
		/// <param name="noforwards">Only for bots, disallows forwarding and saving of the messages, even if the destination chat doesn't have <a href="https://telegram.org/blog/protected-content-delete-by-date-and-more">content protection</a> enabled</param>
		/// <param name="update_stickersets_order">Whether to move used stickersets to top, <a href="https://corefork.telegram.org/api/stickers#recent-stickersets">see here for more info on this flag »</a></param>
		/// <param name="invert_media">If set, any eventual webpage preview will be shown on top of the message instead of at the bottom.</param>
		/// <param name="allow_paid_floodskip">Bots only: if set, allows sending up to 1000 messages per second, ignoring <a href="https://corefork.telegram.org/bots/faq#how-can-i-message-all-of-my-bot-39s-subscribers-at-once">broadcasting limits</a> for a fee of 0.1 Telegram Stars per message. The relevant Stars will be withdrawn from the bot's balance.</param>
		/// <param name="peer">The destination where the message will be sent</param>
		/// <param name="reply_to">If set, indicates that the message should be sent in reply to the specified message or story. <br/>Also used to quote other messages.</param>
		/// <param name="message">The message</param>
		/// <param name="random_id">Unique client message ID required to prevent message resending <para>You can use <see cref="WTelegram.Helpers.RandomLong"/></para></param>
		/// <param name="reply_markup">Reply markup for sending bot buttons</param>
		/// <param name="entities">Message <a href="https://corefork.telegram.org/api/entities">entities</a> for sending styled text</param>
		/// <param name="schedule_date">Scheduled message date for <a href="https://corefork.telegram.org/api/scheduled-messages">scheduled messages</a></param>
		/// <param name="send_as">Send this message as the specified peer</param>
		/// <param name="quick_reply_shortcut">Add the message to the specified <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">quick reply shortcut »</a>, instead.</param>
		/// <param name="effect">Specifies a <a href="https://corefork.telegram.org/api/effects">message effect »</a> to use for the message.</param>
		public static Task<UpdatesBase> Messages_SendMessage(this Client client, InputPeer peer, string message, long random_id, InputReplyTo reply_to = null, ReplyMarkup reply_markup = null, MessageEntity[] entities = null, DateTime? schedule_date = null, InputPeer send_as = null, InputQuickReplyShortcutBase quick_reply_shortcut = null, long? effect = null, bool no_webpage = false, bool silent = false, bool background = false, bool clear_draft = false, bool noforwards = false, bool update_stickersets_order = false, bool invert_media = false, bool allow_paid_floodskip = false)
			=> client.Invoke(new Messages_SendMessage
			{
				flags = (Messages_SendMessage.Flags)((reply_to != null ? 0x1 : 0) | (reply_markup != null ? 0x4 : 0) | (entities != null ? 0x8 : 0) | (schedule_date != null ? 0x400 : 0) | (send_as != null ? 0x2000 : 0) | (quick_reply_shortcut != null ? 0x20000 : 0) | (effect != null ? 0x40000 : 0) | (no_webpage ? 0x2 : 0) | (silent ? 0x20 : 0) | (background ? 0x40 : 0) | (clear_draft ? 0x80 : 0) | (noforwards ? 0x4000 : 0) | (update_stickersets_order ? 0x8000 : 0) | (invert_media ? 0x10000 : 0) | (allow_paid_floodskip ? 0x80000 : 0)),
				peer = peer,
				reply_to = reply_to,
				message = message,
				random_id = random_id,
				reply_markup = reply_markup,
				entities = entities,
				schedule_date = schedule_date ?? default,
				send_as = send_as,
				quick_reply_shortcut = quick_reply_shortcut,
				effect = effect ?? default,
			});

		/// <summary>Send a media		<para>See <a href="https://corefork.telegram.org/method/messages.sendMedia"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403,406,420,500 (<a href="https://corefork.telegram.org/method/messages.sendMedia#possible-errors">details</a>)</para></summary>
		/// <param name="silent">Send message silently (no notification should be triggered)</param>
		/// <param name="background">Send message in background</param>
		/// <param name="clear_draft">Clear the draft</param>
		/// <param name="noforwards">Only for bots, disallows forwarding and saving of the messages, even if the destination chat doesn't have <a href="https://telegram.org/blog/protected-content-delete-by-date-and-more">content protection</a> enabled</param>
		/// <param name="update_stickersets_order">Whether to move used stickersets to top, <a href="https://corefork.telegram.org/api/stickers#recent-stickersets">see here for more info on this flag »</a></param>
		/// <param name="invert_media">If set, any eventual webpage preview will be shown on top of the message instead of at the bottom.</param>
		/// <param name="allow_paid_floodskip">Bots only: if set, allows sending up to 1000 messages per second, ignoring <a href="https://corefork.telegram.org/bots/faq#how-can-i-message-all-of-my-bot-39s-subscribers-at-once">broadcasting limits</a> for a fee of 0.1 Telegram Stars per message. The relevant Stars will be withdrawn from the bot's balance.</param>
		/// <param name="peer">Destination</param>
		/// <param name="reply_to">If set, indicates that the message should be sent in reply to the specified message or story.</param>
		/// <param name="media">Attached media</param>
		/// <param name="message">Caption</param>
		/// <param name="random_id">Random ID to avoid resending the same message <para>You can use <see cref="WTelegram.Helpers.RandomLong"/></para></param>
		/// <param name="reply_markup">Reply markup for bot keyboards</param>
		/// <param name="entities">Message <a href="https://corefork.telegram.org/api/entities">entities</a> for styled text</param>
		/// <param name="schedule_date">Scheduled message date for <a href="https://corefork.telegram.org/api/scheduled-messages">scheduled messages</a></param>
		/// <param name="send_as">Send this message as the specified peer</param>
		/// <param name="quick_reply_shortcut">Add the message to the specified <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">quick reply shortcut »</a>, instead.</param>
		/// <param name="effect">Specifies a <a href="https://corefork.telegram.org/api/effects">message effect »</a> to use for the message.</param>
		public static Task<UpdatesBase> Messages_SendMedia(this Client client, InputPeer peer, InputMedia media, string message, long random_id, InputReplyTo reply_to = null, ReplyMarkup reply_markup = null, MessageEntity[] entities = null, DateTime? schedule_date = null, InputPeer send_as = null, InputQuickReplyShortcutBase quick_reply_shortcut = null, long? effect = null, bool silent = false, bool background = false, bool clear_draft = false, bool noforwards = false, bool update_stickersets_order = false, bool invert_media = false, bool allow_paid_floodskip = false)
			=> client.Invoke(new Messages_SendMedia
			{
				flags = (Messages_SendMedia.Flags)((reply_to != null ? 0x1 : 0) | (reply_markup != null ? 0x4 : 0) | (entities != null ? 0x8 : 0) | (schedule_date != null ? 0x400 : 0) | (send_as != null ? 0x2000 : 0) | (quick_reply_shortcut != null ? 0x20000 : 0) | (effect != null ? 0x40000 : 0) | (silent ? 0x20 : 0) | (background ? 0x40 : 0) | (clear_draft ? 0x80 : 0) | (noforwards ? 0x4000 : 0) | (update_stickersets_order ? 0x8000 : 0) | (invert_media ? 0x10000 : 0) | (allow_paid_floodskip ? 0x80000 : 0)),
				peer = peer,
				reply_to = reply_to,
				media = media,
				message = message,
				random_id = random_id,
				reply_markup = reply_markup,
				entities = entities,
				schedule_date = schedule_date ?? default,
				send_as = send_as,
				quick_reply_shortcut = quick_reply_shortcut,
				effect = effect ?? default,
			});

		/// <summary>Forwards messages by their IDs.		<para>See <a href="https://corefork.telegram.org/method/messages.forwardMessages"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403,406,420,500 (<a href="https://corefork.telegram.org/method/messages.forwardMessages#possible-errors">details</a>)</para></summary>
		/// <param name="silent">Whether to send messages silently (no notification will be triggered on the destination clients)</param>
		/// <param name="background">Whether to send the message in background</param>
		/// <param name="with_my_score">When forwarding games, whether to include your score in the game</param>
		/// <param name="drop_author">Whether to forward messages without quoting the original author</param>
		/// <param name="drop_media_captions">Whether to strip captions from media</param>
		/// <param name="noforwards">Only for bots, disallows further re-forwarding and saving of the messages, even if the destination chat doesn't have <a href="https://telegram.org/blog/protected-content-delete-by-date-and-more">content protection</a> enabled</param>
		/// <param name="allow_paid_floodskip">Bots only: if set, allows sending up to 1000 messages per second, ignoring <a href="https://corefork.telegram.org/bots/faq#how-can-i-message-all-of-my-bot-39s-subscribers-at-once">broadcasting limits</a> for a fee of 0.1 Telegram Stars per message. The relevant Stars will be withdrawn from the bot's balance.</param>
		/// <param name="from_peer">Source of messages</param>
		/// <param name="id">IDs of messages</param>
		/// <param name="random_id">Random ID to prevent resending of messages <para>You can use <see cref="WTelegram.Helpers.RandomLong"/></para></param>
		/// <param name="to_peer">Destination peer</param>
		/// <param name="top_msg_id">Destination <a href="https://corefork.telegram.org/api/forum#forum-topics">forum topic</a></param>
		/// <param name="schedule_date">Scheduled message date for scheduled messages</param>
		/// <param name="send_as">Forward the messages as the specified peer</param>
		/// <param name="quick_reply_shortcut">Add the messages to the specified <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">quick reply shortcut »</a>, instead.</param>
		public static Task<UpdatesBase> Messages_ForwardMessages(this Client client, InputPeer from_peer, int[] id, long[] random_id, InputPeer to_peer, int? top_msg_id = null, DateTime? schedule_date = null, InputPeer send_as = null, InputQuickReplyShortcutBase quick_reply_shortcut = null, int? video_timestamp = null, bool silent = false, bool background = false, bool with_my_score = false, bool drop_author = false, bool drop_media_captions = false, bool noforwards = false, bool allow_paid_floodskip = false)
			=> client.Invoke(new Messages_ForwardMessages
			{
				flags = (Messages_ForwardMessages.Flags)((top_msg_id != null ? 0x200 : 0) | (schedule_date != null ? 0x400 : 0) | (send_as != null ? 0x2000 : 0) | (quick_reply_shortcut != null ? 0x20000 : 0) | (video_timestamp != null ? 0x100000 : 0) | (silent ? 0x20 : 0) | (background ? 0x40 : 0) | (with_my_score ? 0x100 : 0) | (drop_author ? 0x800 : 0) | (drop_media_captions ? 0x1000 : 0) | (noforwards ? 0x4000 : 0) | (allow_paid_floodskip ? 0x80000 : 0)),
				from_peer = from_peer,
				id = id,
				random_id = random_id,
				to_peer = to_peer,
				top_msg_id = top_msg_id ?? default,
				schedule_date = schedule_date ?? default,
				send_as = send_as,
				quick_reply_shortcut = quick_reply_shortcut,
				video_timestamp = video_timestamp ?? default,
			});

		/// <summary>Report a new incoming chat for spam, if the <see cref="PeerSettings"/> of the chat allow us to do that		<para>See <a href="https://corefork.telegram.org/method/messages.reportSpam"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.reportSpam#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer to report</param>
		public static Task<bool> Messages_ReportSpam(this Client client, InputPeer peer)
			=> client.Invoke(new Messages_ReportSpam
			{
				peer = peer,
			});

		/// <summary>Get peer settings		<para>See <a href="https://corefork.telegram.org/method/messages.getPeerSettings"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getPeerSettings#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The peer</param>
		public static Task<Messages_PeerSettings> Messages_GetPeerSettings(this Client client, InputPeer peer)
			=> client.Invoke(new Messages_GetPeerSettings
			{
				peer = peer,
			});

		/// <summary>Report a message in a chat for violation of telegram's Terms of Service		<para>See <a href="https://corefork.telegram.org/method/messages.report"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.report#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer</param>
		/// <param name="id">IDs of messages to report</param>
		/// <param name="option">Menu option, intially empty</param>
		/// <param name="message">Comment for report moderation</param>
		public static Task<ReportResult> Messages_Report(this Client client, InputPeer peer, int[] id, byte[] option, string message)
			=> client.Invoke(new Messages_Report
			{
				peer = peer,
				id = id,
				option = option,
				message = message,
			});

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://wiz0u.github.io/WTelegramClient/#terminology">Terminology</see> in the README to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Returns chat basic info on their IDs.		<para>See <a href="https://corefork.telegram.org/method/messages.getChats"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getChats#possible-errors">details</a>)</para></summary>
		/// <param name="id">List of chat IDs</param>
		public static Task<Messages_Chats> Messages_GetChats(this Client client, params long[] id)
			=> client.Invoke(new Messages_GetChats
			{
				id = id,
			});

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://wiz0u.github.io/WTelegramClient/#terminology">Terminology</see> in the README to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Get full info about a <a href="https://corefork.telegram.org/api/channel#basic-groups">basic group</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.getFullChat"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getFullChat#possible-errors">details</a>)</para></summary>
		/// <param name="chat_id"><a href="https://corefork.telegram.org/api/channel#basic-groups">Basic group</a> ID.</param>
		public static Task<Messages_ChatFull> Messages_GetFullChat(this Client client, long chat_id)
			=> client.Invoke(new Messages_GetFullChat
			{
				chat_id = chat_id,
			});

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://wiz0u.github.io/WTelegramClient/#terminology">Terminology</see> in the README to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Changes chat name and sends a service message on it.		<para>See <a href="https://corefork.telegram.org/method/messages.editChatTitle"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.editChatTitle#possible-errors">details</a>)</para></summary>
		/// <param name="chat_id">Chat ID</param>
		/// <param name="title">New chat name, different from the old one</param>
		public static Task<UpdatesBase> Messages_EditChatTitle(this Client client, long chat_id, string title)
			=> client.Invoke(new Messages_EditChatTitle
			{
				chat_id = chat_id,
				title = title,
			});

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://wiz0u.github.io/WTelegramClient/#terminology">Terminology</see> in the README to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Changes chat photo and sends a service message on it		<para>See <a href="https://corefork.telegram.org/method/messages.editChatPhoto"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.editChatPhoto#possible-errors">details</a>)</para></summary>
		/// <param name="chat_id">Chat ID</param>
		/// <param name="photo">Photo to be set</param>
		public static Task<UpdatesBase> Messages_EditChatPhoto(this Client client, long chat_id, InputChatPhotoBase photo)
			=> client.Invoke(new Messages_EditChatPhoto
			{
				chat_id = chat_id,
				photo = photo,
			});

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://wiz0u.github.io/WTelegramClient/#terminology">Terminology</see> in the README to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Adds a user to a chat and sends a service message on it.		<para>See <a href="https://corefork.telegram.org/method/messages.addChatUser"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.addChatUser#possible-errors">details</a>)</para></summary>
		/// <param name="chat_id">Chat ID</param>
		/// <param name="user_id">User ID to be added</param>
		/// <param name="fwd_limit">Number of last messages to be forwarded</param>
		public static Task<Messages_InvitedUsers> Messages_AddChatUser(this Client client, long chat_id, InputUserBase user_id, int fwd_limit)
			=> client.Invoke(new Messages_AddChatUser
			{
				chat_id = chat_id,
				user_id = user_id,
				fwd_limit = fwd_limit,
			});

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://wiz0u.github.io/WTelegramClient/#terminology">Terminology</see> in the README to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Deletes a user from a chat and sends a service message on it.		<para>See <a href="https://corefork.telegram.org/method/messages.deleteChatUser"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.deleteChatUser#possible-errors">details</a>)</para></summary>
		/// <param name="revoke_history">Remove the entire chat history of the specified user in this chat.</param>
		/// <param name="chat_id">Chat ID</param>
		/// <param name="user_id">User ID to be deleted</param>
		public static Task<UpdatesBase> Messages_DeleteChatUser(this Client client, long chat_id, InputUserBase user_id, bool revoke_history = false)
			=> client.Invoke(new Messages_DeleteChatUser
			{
				flags = (Messages_DeleteChatUser.Flags)(revoke_history ? 0x1 : 0),
				chat_id = chat_id,
				user_id = user_id,
			});

		/// <summary>Creates a new chat.		<para>See <a href="https://corefork.telegram.org/method/messages.createChat"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406,500 (<a href="https://corefork.telegram.org/method/messages.createChat#possible-errors">details</a>)</para></summary>
		/// <param name="users">List of user IDs to be invited</param>
		/// <param name="title">Chat name</param>
		/// <param name="ttl_period">Time-to-live of all messages that will be sent in the chat: once message.date+message.ttl_period === time(), the message will be deleted on the server, and must be deleted locally as well. You can use <see cref="Messages_SetDefaultHistoryTTL">Messages_SetDefaultHistoryTTL</see> to edit this value later.</param>
		public static Task<Messages_InvitedUsers> Messages_CreateChat(this Client client, InputUserBase[] users, string title, int? ttl_period = null)
			=> client.Invoke(new Messages_CreateChat
			{
				flags = (Messages_CreateChat.Flags)(ttl_period != null ? 0x1 : 0),
				users = users,
				title = title,
				ttl_period = ttl_period ?? default,
			});

		/// <summary>Returns configuration parameters for Diffie-Hellman key generation. Can also return a random sequence of bytes of required length.		<para>See <a href="https://corefork.telegram.org/method/messages.getDhConfig"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getDhConfig#possible-errors">details</a>)</para></summary>
		/// <param name="version">Value of the <strong>version</strong> parameter from <see cref="Messages_DhConfig"/>, available at the client</param>
		/// <param name="random_length">Length of the required random sequence</param>
		public static Task<Messages_DhConfigBase> Messages_GetDhConfig(this Client client, int version, int random_length)
			=> client.Invoke(new Messages_GetDhConfig
			{
				version = version,
				random_length = random_length,
			});

		/// <summary>Sends a request to start a secret chat to the user.		<para>See <a href="https://corefork.telegram.org/method/messages.requestEncryption"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.requestEncryption#possible-errors">details</a>)</para></summary>
		/// <param name="user_id">User ID</param>
		/// <param name="random_id">Unique client request ID required to prevent resending. This also doubles as the chat ID.</param>
		/// <param name="g_a"><c>A = g ^ a mod p</c>, see <a href="https://en.wikipedia.org/wiki/Diffie%E2%80%93Hellman_key_exchange">Wikipedia</a></param>
		public static Task<EncryptedChatBase> Messages_RequestEncryption(this Client client, InputUserBase user_id, int random_id, byte[] g_a)
			=> client.Invoke(new Messages_RequestEncryption
			{
				user_id = user_id,
				random_id = random_id,
				g_a = g_a,
			});

		/// <summary>Confirms creation of a secret chat		<para>See <a href="https://corefork.telegram.org/method/messages.acceptEncryption"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.acceptEncryption#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Secret chat ID</param>
		/// <param name="g_b"><c>B = g ^ b mod p</c>, see <a href="https://en.wikipedia.org/wiki/Diffie%E2%80%93Hellman_key_exchange">Wikipedia</a></param>
		/// <param name="key_fingerprint">64-bit fingerprint of the received key</param>
		public static Task<EncryptedChatBase> Messages_AcceptEncryption(this Client client, InputEncryptedChat peer, byte[] g_b, long key_fingerprint)
			=> client.Invoke(new Messages_AcceptEncryption
			{
				peer = peer,
				g_b = g_b,
				key_fingerprint = key_fingerprint,
			});

		/// <summary>Cancels a request for creation and/or delete info on secret chat.		<para>See <a href="https://corefork.telegram.org/method/messages.discardEncryption"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.discardEncryption#possible-errors">details</a>)</para></summary>
		/// <param name="delete_history">Whether to delete the entire chat history for the other user as well</param>
		/// <param name="chat_id">Secret chat ID</param>
		public static Task<bool> Messages_DiscardEncryption(this Client client, int chat_id, bool delete_history = false)
			=> client.Invoke(new Messages_DiscardEncryption
			{
				flags = (Messages_DiscardEncryption.Flags)(delete_history ? 0x1 : 0),
				chat_id = chat_id,
			});

		/// <summary>Send typing event by the current user to a secret chat.		<para>See <a href="https://corefork.telegram.org/method/messages.setEncryptedTyping"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.setEncryptedTyping#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Secret chat ID</param>
		/// <param name="typing">Typing.<br/><strong>Possible values</strong>:<br/><see langword="true"/>, if the user started typing and more than <strong>5 seconds</strong> have passed since the last request<br/><see langword="false"/>, if the user stopped typing</param>
		public static Task<bool> Messages_SetEncryptedTyping(this Client client, InputEncryptedChat peer, bool typing)
			=> client.Invoke(new Messages_SetEncryptedTyping
			{
				peer = peer,
				typing = typing,
			});

		/// <summary>Marks message history within a secret chat as read.		<para>See <a href="https://corefork.telegram.org/method/messages.readEncryptedHistory"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.readEncryptedHistory#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Secret chat ID</param>
		/// <param name="max_date">Maximum date value for received messages in history</param>
		public static Task<bool> Messages_ReadEncryptedHistory(this Client client, InputEncryptedChat peer, DateTime max_date = default)
			=> client.Invoke(new Messages_ReadEncryptedHistory
			{
				peer = peer,
				max_date = max_date,
			});

		/// <summary>Sends a text message to a secret chat.		<para>See <a href="https://corefork.telegram.org/method/messages.sendEncrypted"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403,500 (<a href="https://corefork.telegram.org/method/messages.sendEncrypted#possible-errors">details</a>)</para></summary>
		/// <param name="silent">Send encrypted message without a notification</param>
		/// <param name="peer">Secret chat ID</param>
		/// <param name="random_id">Unique client message ID, necessary to avoid message resending <para>You can use <see cref="WTelegram.Helpers.RandomLong"/></para></param>
		/// <param name="data">TL-serialization of <see cref="DecryptedMessageBase"/> type, encrypted with a key that was created during chat initialization</param>
		public static Task<Messages_SentEncryptedMessage> Messages_SendEncrypted(this Client client, InputEncryptedChat peer, long random_id, byte[] data, bool silent = false)
			=> client.Invoke(new Messages_SendEncrypted
			{
				flags = (Messages_SendEncrypted.Flags)(silent ? 0x1 : 0),
				peer = peer,
				random_id = random_id,
				data = data,
			});

		/// <summary>Sends a message with a file attachment to a secret chat		<para>See <a href="https://corefork.telegram.org/method/messages.sendEncryptedFile"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.sendEncryptedFile#possible-errors">details</a>)</para></summary>
		/// <param name="silent">Whether to send the file without triggering a notification</param>
		/// <param name="peer">Secret chat ID</param>
		/// <param name="random_id">Unique client message ID necessary to prevent message resending <para>You can use <see cref="WTelegram.Helpers.RandomLong"/></para></param>
		/// <param name="data">TL-serialization of <see cref="DecryptedMessageBase"/> type, encrypted with a key generated during chat initialization</param>
		/// <param name="file">File attachment for the secret chat</param>
		public static Task<Messages_SentEncryptedMessage> Messages_SendEncryptedFile(this Client client, InputEncryptedChat peer, long random_id, byte[] data, InputEncryptedFileBase file, bool silent = false)
			=> client.Invoke(new Messages_SendEncryptedFile
			{
				flags = (Messages_SendEncryptedFile.Flags)(silent ? 0x1 : 0),
				peer = peer,
				random_id = random_id,
				data = data,
				file = file,
			});

		/// <summary>Sends a service message to a secret chat.		<para>See <a href="https://corefork.telegram.org/method/messages.sendEncryptedService"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403,500 (<a href="https://corefork.telegram.org/method/messages.sendEncryptedService#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Secret chat ID</param>
		/// <param name="random_id">Unique client message ID required to prevent message resending <para>You can use <see cref="WTelegram.Helpers.RandomLong"/></para></param>
		/// <param name="data">TL-serialization of  <see cref="DecryptedMessageBase"/> type, encrypted with a key generated during chat initialization</param>
		public static Task<Messages_SentEncryptedMessage> Messages_SendEncryptedService(this Client client, InputEncryptedChat peer, long random_id, byte[] data)
			=> client.Invoke(new Messages_SendEncryptedService
			{
				peer = peer,
				random_id = random_id,
				data = data,
			});

		/// <summary>Confirms receipt of messages in a secret chat by client, cancels push notifications.<br/>The method returns a list of <strong>random_id</strong>s of messages for which push notifications were cancelled.		<para>See <a href="https://corefork.telegram.org/method/messages.receivedQueue"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,500 (<a href="https://corefork.telegram.org/method/messages.receivedQueue#possible-errors">details</a>)</para></summary>
		/// <param name="max_qts">Maximum qts value available at the client</param>
		public static Task<long[]> Messages_ReceivedQueue(this Client client, int max_qts)
			=> client.Invoke(new Messages_ReceivedQueue
			{
				max_qts = max_qts,
			});

		/// <summary>Report a secret chat for spam		<para>See <a href="https://corefork.telegram.org/method/messages.reportEncryptedSpam"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.reportEncryptedSpam#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The secret chat to report</param>
		public static Task<bool> Messages_ReportEncryptedSpam(this Client client, InputEncryptedChat peer)
			=> client.Invoke(new Messages_ReportEncryptedSpam
			{
				peer = peer,
			});

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://wiz0u.github.io/WTelegramClient/#terminology">Terminology</see> in the README to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Notifies the sender about the recipient having listened a voice message or watched a video.		<para>See <a href="https://corefork.telegram.org/method/messages.readMessageContents"/></para></summary>
		/// <param name="id">Message ID list</param>
		public static Task<Messages_AffectedMessages> Messages_ReadMessageContents(this Client client, params int[] id)
			=> client.InvokeAffected(new Messages_ReadMessageContents
			{
				id = id,
			}, 0);

		/// <summary>Get stickers by emoji		<para>See <a href="https://corefork.telegram.org/method/messages.getStickers"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getStickers#possible-errors">details</a>)</para></summary>
		/// <param name="emoticon">The emoji</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.stickersNotModified">messages.stickersNotModified</a></returns>
		public static Task<Messages_Stickers> Messages_GetStickers(this Client client, string emoticon, long hash = default)
			=> client.Invoke(new Messages_GetStickers
			{
				emoticon = emoticon,
				hash = hash,
			});

		/// <summary>Get all installed stickers		<para>See <a href="https://corefork.telegram.org/method/messages.getAllStickers"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.allStickersNotModified">messages.allStickersNotModified</a></returns>
		public static Task<Messages_AllStickers> Messages_GetAllStickers(this Client client, long hash = default)
			=> client.Invoke(new Messages_GetAllStickers
			{
				hash = hash,
			});

		/// <summary>Get preview of webpage		<para>See <a href="https://corefork.telegram.org/method/messages.getWebPagePreview"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getWebPagePreview#possible-errors">details</a>)</para></summary>
		/// <param name="message">Message from which to extract the preview</param>
		/// <param name="entities"><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></param>
		public static Task<Messages_WebPagePreview> Messages_GetWebPagePreview(this Client client, string message, MessageEntity[] entities = null)
			=> client.Invoke(new Messages_GetWebPagePreview
			{
				flags = (Messages_GetWebPagePreview.Flags)(entities != null ? 0x8 : 0),
				message = message,
				entities = entities,
			});

		/// <summary>Export an invite link for a chat		<para>See <a href="https://corefork.telegram.org/method/messages.exportChatInvite"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.exportChatInvite#possible-errors">details</a>)</para></summary>
		/// <param name="legacy_revoke_permanent">Legacy flag, reproducing legacy behavior of this method: if set, revokes all previous links before creating a new one. Kept for bot API BC, should not be used by modern clients.</param>
		/// <param name="request_needed">Whether admin confirmation is required before admitting each separate user into the chat</param>
		/// <param name="peer">Chat</param>
		/// <param name="expire_date">Expiration date</param>
		/// <param name="usage_limit">Maximum number of users that can join using this link</param>
		/// <param name="title">Description of the invite link, visible only to administrators</param>
		/// <param name="subscription_pricing">For <a href="https://corefork.telegram.org/api/stars#star-subscriptions">Telegram Star subscriptions »</a>, contains the pricing of the subscription the user must activate to join the private channel.</param>
		public static Task<ExportedChatInvite> Messages_ExportChatInvite(this Client client, InputPeer peer, DateTime? expire_date = null, int? usage_limit = null, string title = null, StarsSubscriptionPricing subscription_pricing = null, bool legacy_revoke_permanent = false, bool request_needed = false)
			=> client.Invoke(new Messages_ExportChatInvite
			{
				flags = (Messages_ExportChatInvite.Flags)((expire_date != null ? 0x1 : 0) | (usage_limit != null ? 0x2 : 0) | (title != null ? 0x10 : 0) | (subscription_pricing != null ? 0x20 : 0) | (legacy_revoke_permanent ? 0x4 : 0) | (request_needed ? 0x8 : 0)),
				peer = peer,
				expire_date = expire_date ?? default,
				usage_limit = usage_limit ?? default,
				title = title,
				subscription_pricing = subscription_pricing,
			});

		/// <summary>Check the validity of a chat invite link and get basic info about it		<para>See <a href="https://corefork.telegram.org/method/messages.checkChatInvite"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/messages.checkChatInvite#possible-errors">details</a>)</para></summary>
		/// <param name="hash">Invite hash from <a href="https://corefork.telegram.org/api/links#chat-invite-links">chat invite deep link »</a>.</param>
		public static Task<ChatInviteBase> Messages_CheckChatInvite(this Client client, string hash)
			=> client.Invoke(new Messages_CheckChatInvite
			{
				hash = hash,
			});

		/// <summary>Import a chat invite and join a private chat/supergroup/channel		<para>See <a href="https://corefork.telegram.org/method/messages.importChatInvite"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/messages.importChatInvite#possible-errors">details</a>)</para></summary>
		/// <param name="hash"><c>hash</c> from a <a href="https://corefork.telegram.org/api/links#chat-invite-links">chat invite deep link</a></param>
		public static Task<UpdatesBase> Messages_ImportChatInvite(this Client client, string hash)
			=> client.Invoke(new Messages_ImportChatInvite
			{
				hash = hash,
			});

		/// <summary>Get info about a stickerset		<para>See <a href="https://corefork.telegram.org/method/messages.getStickerSet"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/messages.getStickerSet#possible-errors">details</a>)</para></summary>
		/// <param name="stickerset">Stickerset</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.stickerSetNotModified">messages.stickerSetNotModified</a></returns>
		public static Task<Messages_StickerSet> Messages_GetStickerSet(this Client client, InputStickerSet stickerset, int hash = default)
			=> client.Invoke(new Messages_GetStickerSet
			{
				stickerset = stickerset,
				hash = hash,
			});

		/// <summary>Install a stickerset		<para>See <a href="https://corefork.telegram.org/method/messages.installStickerSet"/></para>		<para>Possible <see cref="RpcException"/> codes: 406 (<a href="https://corefork.telegram.org/method/messages.installStickerSet#possible-errors">details</a>)</para></summary>
		/// <param name="stickerset">Stickerset to install</param>
		/// <param name="archived">Whether to archive stickerset</param>
		public static Task<Messages_StickerSetInstallResult> Messages_InstallStickerSet(this Client client, InputStickerSet stickerset, bool archived)
			=> client.Invoke(new Messages_InstallStickerSet
			{
				stickerset = stickerset,
				archived = archived,
			});

		/// <summary>Uninstall a stickerset		<para>See <a href="https://corefork.telegram.org/method/messages.uninstallStickerSet"/></para>		<para>Possible <see cref="RpcException"/> codes: 406 (<a href="https://corefork.telegram.org/method/messages.uninstallStickerSet#possible-errors">details</a>)</para></summary>
		/// <param name="stickerset">The stickerset to uninstall</param>
		public static Task<bool> Messages_UninstallStickerSet(this Client client, InputStickerSet stickerset)
			=> client.Invoke(new Messages_UninstallStickerSet
			{
				stickerset = stickerset,
			});

		/// <summary>Start a conversation with a bot using a <a href="https://corefork.telegram.org/api/links#bot-links">deep linking parameter</a>		<para>See <a href="https://corefork.telegram.org/method/messages.startBot"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403,500 (<a href="https://corefork.telegram.org/method/messages.startBot#possible-errors">details</a>)</para></summary>
		/// <param name="bot">The bot</param>
		/// <param name="peer">The chat where to start the bot, can be the bot's private chat or a group</param>
		/// <param name="random_id">Random ID to avoid resending the same message <para>You can use <see cref="WTelegram.Helpers.RandomLong"/></para></param>
		/// <param name="start_param"><a href="https://corefork.telegram.org/api/links#bot-links">Deep linking parameter</a></param>
		public static Task<UpdatesBase> Messages_StartBot(this Client client, InputUserBase bot, InputPeer peer, long random_id, string start_param)
			=> client.Invoke(new Messages_StartBot
			{
				bot = bot,
				peer = peer,
				random_id = random_id,
				start_param = start_param,
			});

		/// <summary>Get and increase the view counter of a message sent or forwarded from a <a href="https://corefork.telegram.org/api/channel">channel</a>		<para>See <a href="https://corefork.telegram.org/method/messages.getMessagesViews"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/messages.getMessagesViews#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer where the message was found</param>
		/// <param name="id">ID of message</param>
		/// <param name="increment">Whether to mark the message as viewed and increment the view counter</param>
		public static Task<Messages_MessageViews> Messages_GetMessagesViews(this Client client, InputPeer peer, int[] id, bool increment)
			=> client.Invoke(new Messages_GetMessagesViews
			{
				peer = peer,
				id = id,
				increment = increment,
			});

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://wiz0u.github.io/WTelegramClient/#terminology">Terminology</see> in the README to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Make a user admin in a <a href="https://corefork.telegram.org/api/channel#basic-groups">basic group</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.editChatAdmin"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.editChatAdmin#possible-errors">details</a>)</para></summary>
		/// <param name="chat_id">The ID of the group</param>
		/// <param name="user_id">The user to make admin</param>
		/// <param name="is_admin">Whether to make them admin</param>
		public static Task<bool> Messages_EditChatAdmin(this Client client, long chat_id, InputUserBase user_id, bool is_admin)
			=> client.Invoke(new Messages_EditChatAdmin
			{
				chat_id = chat_id,
				user_id = user_id,
				is_admin = is_admin,
			});

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://wiz0u.github.io/WTelegramClient/#terminology">Terminology</see> in the README to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Turn a <a href="https://corefork.telegram.org/api/channel#migration">basic group into a supergroup</a>		<para>See <a href="https://corefork.telegram.org/method/messages.migrateChat"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403,500 (<a href="https://corefork.telegram.org/method/messages.migrateChat#possible-errors">details</a>)</para></summary>
		/// <param name="chat_id"><a href="https://corefork.telegram.org/api/channel#basic-groups">Basic group</a> to migrate</param>
		public static Task<UpdatesBase> Messages_MigrateChat(this Client client, long chat_id)
			=> client.Invoke(new Messages_MigrateChat
			{
				chat_id = chat_id,
			});

		/// <summary>Search for messages and peers globally		<para>See <a href="https://corefork.telegram.org/method/messages.searchGlobal"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.searchGlobal#possible-errors">details</a>)</para></summary>
		/// <param name="broadcasts_only">If set, only returns results from channels (used in the <a href="https://corefork.telegram.org/api/search#global-search">global channel search tab »</a>).</param>
		/// <param name="groups_only">Whether to search only in groups</param>
		/// <param name="users_only">Whether to search only in private chats</param>
		/// <param name="folder_id"><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></param>
		/// <param name="q">Query</param>
		/// <param name="filter">Global search filter</param>
		/// <param name="min_date">If a positive value was specified, the method will return only messages with date bigger than min_date</param>
		/// <param name="max_date">If a positive value was transferred, the method will return only messages with date smaller than max_date</param>
		/// <param name="offset_rate">Initially 0, then set to the <see cref="Messages_MessagesSlice"><c>next_rate</c> parameter of messages.messagesSlice</see></param>
		/// <param name="offset_peer"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="limit"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		public static Task<Messages_MessagesBase> Messages_SearchGlobal(this Client client, string q, MessagesFilter filter = null, DateTime min_date = default, DateTime max_date = default, int offset_rate = default, InputPeer offset_peer = null, int offset_id = default, int limit = int.MaxValue, int? folder_id = null, bool broadcasts_only = false, bool groups_only = false, bool users_only = false)
			=> client.Invoke(new Messages_SearchGlobal
			{
				flags = (Messages_SearchGlobal.Flags)((folder_id != null ? 0x1 : 0) | (broadcasts_only ? 0x2 : 0) | (groups_only ? 0x4 : 0) | (users_only ? 0x8 : 0)),
				folder_id = folder_id ?? default,
				q = q,
				filter = filter,
				min_date = min_date,
				max_date = max_date,
				offset_rate = offset_rate,
				offset_peer = offset_peer,
				offset_id = offset_id,
				limit = limit,
			});

		/// <summary>Reorder installed stickersets		<para>See <a href="https://corefork.telegram.org/method/messages.reorderStickerSets"/></para></summary>
		/// <param name="masks">Reorder mask stickersets</param>
		/// <param name="emojis">Reorder <a href="https://corefork.telegram.org/api/custom-emoji">custom emoji stickersets</a></param>
		/// <param name="order">New stickerset order by stickerset IDs</param>
		public static Task<bool> Messages_ReorderStickerSets(this Client client, long[] order, bool masks = false, bool emojis = false)
			=> client.Invoke(new Messages_ReorderStickerSets
			{
				flags = (Messages_ReorderStickerSets.Flags)((masks ? 0x1 : 0) | (emojis ? 0x2 : 0)),
				order = order,
			});

		/// <summary>Get a document by its SHA256 hash, mainly used for gifs		<para>See <a href="https://corefork.telegram.org/method/messages.getDocumentByHash"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getDocumentByHash#possible-errors">details</a>)</para></summary>
		/// <param name="sha256">SHA256 of file</param>
		/// <param name="size">Size of the file in bytes</param>
		/// <param name="mime_type">Mime type</param>
		public static Task<DocumentBase> Messages_GetDocumentByHash(this Client client, byte[] sha256, long size, string mime_type)
			=> client.Invoke(new Messages_GetDocumentByHash
			{
				sha256 = sha256,
				size = size,
				mime_type = mime_type,
			});

		/// <summary>Get saved GIFs.		<para>See <a href="https://corefork.telegram.org/method/messages.getSavedGifs"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.savedGifsNotModified">messages.savedGifsNotModified</a></returns>
		public static Task<Messages_SavedGifs> Messages_GetSavedGifs(this Client client, long hash = default)
			=> client.Invoke(new Messages_GetSavedGifs
			{
				hash = hash,
			});

		/// <summary>Add GIF to saved gifs list		<para>See <a href="https://corefork.telegram.org/method/messages.saveGif"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.saveGif#possible-errors">details</a>)</para></summary>
		/// <param name="id">GIF to save</param>
		/// <param name="unsave">Whether to remove GIF from saved gifs list</param>
		public static Task<bool> Messages_SaveGif(this Client client, InputDocument id, bool unsave)
			=> client.Invoke(new Messages_SaveGif
			{
				id = id,
				unsave = unsave,
			});

		/// <summary>Query an inline bot		<para>See <a href="https://corefork.telegram.org/method/messages.getInlineBotResults"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406,-503 (<a href="https://corefork.telegram.org/method/messages.getInlineBotResults#possible-errors">details</a>)</para></summary>
		/// <param name="bot">The bot to query</param>
		/// <param name="peer">The currently opened chat</param>
		/// <param name="geo_point">The geolocation, if requested</param>
		/// <param name="query">The query</param>
		/// <param name="offset">The offset within the results, will be passed directly as-is to the bot.</param>
		public static Task<Messages_BotResults> Messages_GetInlineBotResults(this Client client, InputUserBase bot, InputPeer peer, string query, string offset, InputGeoPoint geo_point = null)
			=> client.Invoke(new Messages_GetInlineBotResults
			{
				flags = (Messages_GetInlineBotResults.Flags)(geo_point != null ? 0x1 : 0),
				bot = bot,
				peer = peer,
				geo_point = geo_point,
				query = query,
				offset = offset,
			});

		/// <summary>Answer an inline query, for bots only		<para>See <a href="https://corefork.telegram.org/method/messages.setInlineBotResults"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.setInlineBotResults#possible-errors">details</a>)</para></summary>
		/// <param name="gallery">Set this flag if the results are composed of media files</param>
		/// <param name="private_">Set this flag if results may be cached on the server side only for the user that sent the query. By default, results may be returned to any user who sends the same query</param>
		/// <param name="query_id">Unique identifier for the answered query</param>
		/// <param name="results">Vector of results for the inline query</param>
		/// <param name="cache_time">The maximum amount of time in seconds that the result of the inline query may be cached on the server. Defaults to 300.</param>
		/// <param name="next_offset">Pass the offset that a client should send in the next query with the same text to receive more results. Pass an empty string if there are no more results or if you don't support pagination. Offset length can't exceed 64 bytes.</param>
		/// <param name="switch_pm">If passed, clients will display a button on top of the remaining inline result list with the specified text, that switches the user to a private chat with the bot and sends the bot a start message with a certain parameter.</param>
		/// <param name="switch_webview">If passed, clients will display a button on top of the remaining inline result list with the specified text, that switches the user to the specified <a href="https://corefork.telegram.org/api/bots/webapps#inline-mode-mini-apps">inline mode mini app</a>.</param>
		public static Task<bool> Messages_SetInlineBotResults(this Client client, long query_id, InputBotInlineResultBase[] results, int cache_time, string next_offset = null, InlineBotSwitchPM switch_pm = null, InlineBotWebView switch_webview = null, bool gallery = false, bool private_ = false)
			=> client.Invoke(new Messages_SetInlineBotResults
			{
				flags = (Messages_SetInlineBotResults.Flags)((next_offset != null ? 0x4 : 0) | (switch_pm != null ? 0x8 : 0) | (switch_webview != null ? 0x10 : 0) | (gallery ? 0x1 : 0) | (private_ ? 0x2 : 0)),
				query_id = query_id,
				results = results,
				cache_time = cache_time,
				next_offset = next_offset,
				switch_pm = switch_pm,
				switch_webview = switch_webview,
			});

		/// <summary>Send a result obtained using <see cref="Messages_GetInlineBotResults">Messages_GetInlineBotResults</see>.		<para>See <a href="https://corefork.telegram.org/method/messages.sendInlineBotResult"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403,420,500 (<a href="https://corefork.telegram.org/method/messages.sendInlineBotResult#possible-errors">details</a>)</para></summary>
		/// <param name="silent">Whether to send the message silently (no notification will be triggered on the other client)</param>
		/// <param name="background">Whether to send the message in background</param>
		/// <param name="clear_draft">Whether to clear the <a href="https://corefork.telegram.org/api/drafts">draft</a></param>
		/// <param name="hide_via">Whether to hide the <c>via @botname</c> in the resulting message (only for bot usernames encountered in the <see cref="Config"/>)</param>
		/// <param name="peer">Destination</param>
		/// <param name="reply_to">If set, indicates that the message should be sent in reply to the specified message or story.</param>
		/// <param name="random_id">Random ID to avoid resending the same query <para>You can use <see cref="WTelegram.Helpers.RandomLong"/></para></param>
		/// <param name="query_id">Query ID from <see cref="Messages_GetInlineBotResults">Messages_GetInlineBotResults</see></param>
		/// <param name="id">Result ID from <see cref="Messages_GetInlineBotResults">Messages_GetInlineBotResults</see></param>
		/// <param name="schedule_date">Scheduled message date for scheduled messages</param>
		/// <param name="send_as">Send this message as the specified peer</param>
		/// <param name="quick_reply_shortcut">Add the message to the specified <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">quick reply shortcut »</a>, instead.</param>
		public static Task<UpdatesBase> Messages_SendInlineBotResult(this Client client, InputPeer peer, long random_id, long query_id, string id, InputReplyTo reply_to = null, DateTime? schedule_date = null, InputPeer send_as = null, InputQuickReplyShortcutBase quick_reply_shortcut = null, bool silent = false, bool background = false, bool clear_draft = false, bool hide_via = false)
			=> client.Invoke(new Messages_SendInlineBotResult
			{
				flags = (Messages_SendInlineBotResult.Flags)((reply_to != null ? 0x1 : 0) | (schedule_date != null ? 0x400 : 0) | (send_as != null ? 0x2000 : 0) | (quick_reply_shortcut != null ? 0x20000 : 0) | (silent ? 0x20 : 0) | (background ? 0x40 : 0) | (clear_draft ? 0x80 : 0) | (hide_via ? 0x800 : 0)),
				peer = peer,
				reply_to = reply_to,
				random_id = random_id,
				query_id = query_id,
				id = id,
				schedule_date = schedule_date ?? default,
				send_as = send_as,
				quick_reply_shortcut = quick_reply_shortcut,
			});

		/// <summary>Find out if a media message's caption can be edited		<para>See <a href="https://corefork.telegram.org/method/messages.getMessageEditData"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.getMessageEditData#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer where the media was sent</param>
		/// <param name="id">ID of message</param>
		public static Task<Messages_MessageEditData> Messages_GetMessageEditData(this Client client, InputPeer peer, int id)
			=> client.Invoke(new Messages_GetMessageEditData
			{
				peer = peer,
				id = id,
			});

		/// <summary>Edit message		<para>See <a href="https://corefork.telegram.org/method/messages.editMessage"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403,406,500 (<a href="https://corefork.telegram.org/method/messages.editMessage#possible-errors">details</a>)</para></summary>
		/// <param name="no_webpage">Disable webpage preview</param>
		/// <param name="invert_media">If set, any eventual webpage preview will be shown on top of the message instead of at the bottom.</param>
		/// <param name="peer">Where was the message sent</param>
		/// <param name="id">ID of the message to edit</param>
		/// <param name="message">New message</param>
		/// <param name="media">New attached media</param>
		/// <param name="reply_markup">Reply markup for inline keyboards</param>
		/// <param name="entities"><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></param>
		/// <param name="schedule_date">Scheduled message date for <a href="https://corefork.telegram.org/api/scheduled-messages">scheduled messages</a></param>
		/// <param name="quick_reply_shortcut_id">If specified, edits a <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">quick reply shortcut message, instead »</a>.</param>
		public static Task<UpdatesBase> Messages_EditMessage(this Client client, InputPeer peer, int id, string message = null, InputMedia media = null, ReplyMarkup reply_markup = null, MessageEntity[] entities = null, DateTime? schedule_date = null, int? quick_reply_shortcut_id = null, bool no_webpage = false, bool invert_media = false)
			=> client.Invoke(new Messages_EditMessage
			{
				flags = (Messages_EditMessage.Flags)((message != null ? 0x800 : 0) | (media != null ? 0x4000 : 0) | (reply_markup != null ? 0x4 : 0) | (entities != null ? 0x8 : 0) | (schedule_date != null ? 0x8000 : 0) | (quick_reply_shortcut_id != null ? 0x20000 : 0) | (no_webpage ? 0x2 : 0) | (invert_media ? 0x10000 : 0)),
				peer = peer,
				id = id,
				message = message,
				media = media,
				reply_markup = reply_markup,
				entities = entities,
				schedule_date = schedule_date ?? default,
				quick_reply_shortcut_id = quick_reply_shortcut_id ?? default,
			});

		/// <summary>Edit an inline bot message		<para>See <a href="https://corefork.telegram.org/method/messages.editInlineBotMessage"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.editInlineBotMessage#possible-errors">details</a>)</para></summary>
		/// <param name="no_webpage">Disable webpage preview</param>
		/// <param name="invert_media">If set, any eventual webpage preview will be shown on top of the message instead of at the bottom.</param>
		/// <param name="id">Sent inline message ID</param>
		/// <param name="message">Message</param>
		/// <param name="media">Media</param>
		/// <param name="reply_markup">Reply markup for inline keyboards</param>
		/// <param name="entities"><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></param>
		public static Task<bool> Messages_EditInlineBotMessage(this Client client, InputBotInlineMessageIDBase id, string message = null, InputMedia media = null, ReplyMarkup reply_markup = null, MessageEntity[] entities = null, bool no_webpage = false, bool invert_media = false)
			=> client.Invoke(new Messages_EditInlineBotMessage
			{
				flags = (Messages_EditInlineBotMessage.Flags)((message != null ? 0x800 : 0) | (media != null ? 0x4000 : 0) | (reply_markup != null ? 0x4 : 0) | (entities != null ? 0x8 : 0) | (no_webpage ? 0x2 : 0) | (invert_media ? 0x10000 : 0)),
				id = id,
				message = message,
				media = media,
				reply_markup = reply_markup,
				entities = entities,
			});

		/// <summary>Press an inline callback button and get a callback answer from the bot		<para>See <a href="https://corefork.telegram.org/method/messages.getBotCallbackAnswer"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,-503 (<a href="https://corefork.telegram.org/method/messages.getBotCallbackAnswer#possible-errors">details</a>)</para></summary>
		/// <param name="game">Whether this is a "play game" button</param>
		/// <param name="peer">Where was the inline keyboard sent</param>
		/// <param name="msg_id">ID of the Message with the inline keyboard</param>
		/// <param name="data">Callback data</param>
		/// <param name="password">For buttons <see cref="KeyboardButtonCallback">requiring you to verify your identity with your 2FA password</see>, the SRP payload generated using <a href="https://corefork.telegram.org/api/srp">SRP</a>.</param>
		public static Task<Messages_BotCallbackAnswer> Messages_GetBotCallbackAnswer(this Client client, InputPeer peer, int msg_id, byte[] data = null, InputCheckPasswordSRP password = null, bool game = false)
			=> client.Invoke(new Messages_GetBotCallbackAnswer
			{
				flags = (Messages_GetBotCallbackAnswer.Flags)((data != null ? 0x1 : 0) | (password != null ? 0x4 : 0) | (game ? 0x2 : 0)),
				peer = peer,
				msg_id = msg_id,
				data = data,
				password = password,
			});

		/// <summary>Set the callback answer to a user button press (bots only)		<para>See <a href="https://corefork.telegram.org/method/messages.setBotCallbackAnswer"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.setBotCallbackAnswer#possible-errors">details</a>)</para></summary>
		/// <param name="alert">Whether to show the message as a popup instead of a toast notification</param>
		/// <param name="query_id">Query ID</param>
		/// <param name="message">Popup to show</param>
		/// <param name="url">URL to open</param>
		/// <param name="cache_time">Cache validity</param>
		public static Task<bool> Messages_SetBotCallbackAnswer(this Client client, long query_id, int cache_time, string message = null, string url = null, bool alert = false)
			=> client.Invoke(new Messages_SetBotCallbackAnswer
			{
				flags = (Messages_SetBotCallbackAnswer.Flags)((message != null ? 0x1 : 0) | (url != null ? 0x4 : 0) | (alert ? 0x2 : 0)),
				query_id = query_id,
				message = message,
				url = url,
				cache_time = cache_time,
			});

		/// <summary>Get dialog info of specified peers		<para>See <a href="https://corefork.telegram.org/method/messages.getPeerDialogs"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/messages.getPeerDialogs#possible-errors">details</a>)</para></summary>
		/// <param name="peers">Peers</param>
		public static Task<Messages_PeerDialogs> Messages_GetPeerDialogs(this Client client, params InputDialogPeerBase[] peers)
			=> client.Invoke(new Messages_GetPeerDialogs
			{
				peers = peers,
			});

		/// <summary>Save a message <a href="https://corefork.telegram.org/api/drafts">draft</a> associated to a chat.		<para>See <a href="https://corefork.telegram.org/method/messages.saveDraft"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.saveDraft#possible-errors">details</a>)</para></summary>
		/// <param name="no_webpage">Disable generation of the webpage preview</param>
		/// <param name="invert_media">If set, any eventual webpage preview will be shown on top of the message instead of at the bottom.</param>
		/// <param name="reply_to">If set, indicates that the message should be sent in reply to the specified message or story.</param>
		/// <param name="peer">Destination of the message that should be sent</param>
		/// <param name="message">The draft</param>
		/// <param name="entities">Message <a href="https://corefork.telegram.org/api/entities">entities</a> for styled text</param>
		/// <param name="media">Attached media</param>
		/// <param name="effect">Specifies a <a href="https://corefork.telegram.org/api/effects">message effect »</a> to use for the message.</param>
		public static Task<bool> Messages_SaveDraft(this Client client, InputPeer peer, string message, MessageEntity[] entities = null, InputReplyTo reply_to = null, InputMedia media = null, long? effect = null, bool no_webpage = false, bool invert_media = false)
			=> client.Invoke(new Messages_SaveDraft
			{
				flags = (Messages_SaveDraft.Flags)((entities != null ? 0x8 : 0) | (reply_to != null ? 0x10 : 0) | (media != null ? 0x20 : 0) | (effect != null ? 0x80 : 0) | (no_webpage ? 0x2 : 0) | (invert_media ? 0x40 : 0)),
				reply_to = reply_to,
				peer = peer,
				message = message,
				entities = entities,
				media = media,
				effect = effect ?? default,
			});

		/// <summary>Return all message <a href="https://corefork.telegram.org/api/drafts">drafts</a>.<br/>Returns all the latest <see cref="UpdateDraftMessage"/> updates related to all chats with drafts.		<para>See <a href="https://corefork.telegram.org/method/messages.getAllDrafts"/></para></summary>
		public static Task<UpdatesBase> Messages_GetAllDrafts(this Client client)
			=> client.Invoke(new Messages_GetAllDrafts
			{
			});

		/// <summary>Get featured stickers		<para>See <a href="https://corefork.telegram.org/method/messages.getFeaturedStickers"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		public static Task<Messages_FeaturedStickersBase> Messages_GetFeaturedStickers(this Client client, long hash = default)
			=> client.Invoke(new Messages_GetFeaturedStickers
			{
				hash = hash,
			});

		/// <summary>Mark new featured stickers as read		<para>See <a href="https://corefork.telegram.org/method/messages.readFeaturedStickers"/></para></summary>
		/// <param name="id">IDs of stickersets to mark as read</param>
		public static Task<bool> Messages_ReadFeaturedStickers(this Client client, params long[] id)
			=> client.Invoke(new Messages_ReadFeaturedStickers
			{
				id = id,
			});

		/// <summary>Get recent stickers		<para>See <a href="https://corefork.telegram.org/method/messages.getRecentStickers"/></para></summary>
		/// <param name="attached">Get stickers recently attached to photo or video files</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.recentStickersNotModified">messages.recentStickersNotModified</a></returns>
		public static Task<Messages_RecentStickers> Messages_GetRecentStickers(this Client client, long hash = default, bool attached = false)
			=> client.Invoke(new Messages_GetRecentStickers
			{
				flags = (Messages_GetRecentStickers.Flags)(attached ? 0x1 : 0),
				hash = hash,
			});

		/// <summary>Add/remove sticker from recent stickers list		<para>See <a href="https://corefork.telegram.org/method/messages.saveRecentSticker"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.saveRecentSticker#possible-errors">details</a>)</para></summary>
		/// <param name="attached">Whether to add/remove stickers recently attached to photo or video files</param>
		/// <param name="id">Sticker</param>
		/// <param name="unsave">Whether to save or unsave the sticker</param>
		public static Task<bool> Messages_SaveRecentSticker(this Client client, InputDocument id, bool unsave, bool attached = false)
			=> client.Invoke(new Messages_SaveRecentSticker
			{
				flags = (Messages_SaveRecentSticker.Flags)(attached ? 0x1 : 0),
				id = id,
				unsave = unsave,
			});

		/// <summary>Clear recent stickers		<para>See <a href="https://corefork.telegram.org/method/messages.clearRecentStickers"/></para></summary>
		/// <param name="attached">Set this flag to clear the list of stickers recently attached to photo or video files</param>
		public static Task<bool> Messages_ClearRecentStickers(this Client client, bool attached = false)
			=> client.Invoke(new Messages_ClearRecentStickers
			{
				flags = (Messages_ClearRecentStickers.Flags)(attached ? 0x1 : 0),
			});

		/// <summary>Get all archived stickers		<para>See <a href="https://corefork.telegram.org/method/messages.getArchivedStickers"/></para></summary>
		/// <param name="masks">Get <a href="https://corefork.telegram.org/api/stickers#mask-stickers">mask stickers</a></param>
		/// <param name="emojis">Get <a href="https://corefork.telegram.org/api/custom-emoji">custom emoji stickers</a></param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Messages_ArchivedStickers> Messages_GetArchivedStickers(this Client client, long offset_id = default, int limit = int.MaxValue, bool masks = false, bool emojis = false)
			=> client.Invoke(new Messages_GetArchivedStickers
			{
				flags = (Messages_GetArchivedStickers.Flags)((masks ? 0x1 : 0) | (emojis ? 0x2 : 0)),
				offset_id = offset_id,
				limit = limit,
			});

		/// <summary>Get installed mask stickers		<para>See <a href="https://corefork.telegram.org/method/messages.getMaskStickers"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.allStickersNotModified">messages.allStickersNotModified</a></returns>
		public static Task<Messages_AllStickers> Messages_GetMaskStickers(this Client client, long hash = default)
			=> client.Invoke(new Messages_GetMaskStickers
			{
				hash = hash,
			});

		/// <summary>Get stickers attached to a photo or video		<para>See <a href="https://corefork.telegram.org/method/messages.getAttachedStickers"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getAttachedStickers#possible-errors">details</a>)</para></summary>
		/// <param name="media">Stickered media</param>
		public static Task<StickerSetCoveredBase[]> Messages_GetAttachedStickers(this Client client, InputStickeredMedia media)
			=> client.Invoke(new Messages_GetAttachedStickers
			{
				media = media,
			});

		/// <summary>Use this method to set the score of the specified user in a game sent as a normal message (bots only).		<para>See <a href="https://corefork.telegram.org/method/messages.setGameScore"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.setGameScore#possible-errors">details</a>)</para></summary>
		/// <param name="edit_message">Set this flag if the game message should be automatically edited to include the current scoreboard</param>
		/// <param name="force">Set this flag if the high score is allowed to decrease. This can be useful when fixing mistakes or banning cheaters</param>
		/// <param name="peer">Unique identifier of target chat</param>
		/// <param name="id">Identifier of the sent message</param>
		/// <param name="user_id">User identifier</param>
		/// <param name="score">New score</param>
		public static Task<UpdatesBase> Messages_SetGameScore(this Client client, InputPeer peer, int id, InputUserBase user_id, int score, bool edit_message = false, bool force = false)
			=> client.Invoke(new Messages_SetGameScore
			{
				flags = (Messages_SetGameScore.Flags)((edit_message ? 0x1 : 0) | (force ? 0x2 : 0)),
				peer = peer,
				id = id,
				user_id = user_id,
				score = score,
			});

		/// <summary>Use this method to set the score of the specified user in a game sent as an inline message (bots only).		<para>See <a href="https://corefork.telegram.org/method/messages.setInlineGameScore"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.setInlineGameScore#possible-errors">details</a>)</para></summary>
		/// <param name="edit_message">Set this flag if the game message should be automatically edited to include the current scoreboard</param>
		/// <param name="force">Set this flag if the high score is allowed to decrease. This can be useful when fixing mistakes or banning cheaters</param>
		/// <param name="id">ID of the inline message</param>
		/// <param name="user_id">User identifier</param>
		/// <param name="score">New score</param>
		public static Task<bool> Messages_SetInlineGameScore(this Client client, InputBotInlineMessageIDBase id, InputUserBase user_id, int score, bool edit_message = false, bool force = false)
			=> client.Invoke(new Messages_SetInlineGameScore
			{
				flags = (Messages_SetInlineGameScore.Flags)((edit_message ? 0x1 : 0) | (force ? 0x2 : 0)),
				id = id,
				user_id = user_id,
				score = score,
			});

		/// <summary>Get highscores of a game		<para>See <a href="https://corefork.telegram.org/method/messages.getGameHighScores"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getGameHighScores#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Where was the game sent</param>
		/// <param name="id">ID of message with game media attachment</param>
		/// <param name="user_id">Get high scores made by a certain user</param>
		public static Task<Messages_HighScores> Messages_GetGameHighScores(this Client client, InputPeer peer, int id, InputUserBase user_id)
			=> client.Invoke(new Messages_GetGameHighScores
			{
				peer = peer,
				id = id,
				user_id = user_id,
			});

		/// <summary>Get highscores of a game sent using an inline bot		<para>See <a href="https://corefork.telegram.org/method/messages.getInlineGameHighScores"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getInlineGameHighScores#possible-errors">details</a>)</para></summary>
		/// <param name="id">ID of inline message</param>
		/// <param name="user_id">Get high scores of a certain user</param>
		public static Task<Messages_HighScores> Messages_GetInlineGameHighScores(this Client client, InputBotInlineMessageIDBase id, InputUserBase user_id)
			=> client.Invoke(new Messages_GetInlineGameHighScores
			{
				id = id,
				user_id = user_id,
			});

		/// <summary>Get chats in common with a user		<para>See <a href="https://corefork.telegram.org/method/messages.getCommonChats"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getCommonChats#possible-errors">details</a>)</para></summary>
		/// <param name="user_id">User ID</param>
		/// <param name="max_id">Maximum ID of chat to return (see <a href="https://corefork.telegram.org/api/offsets">pagination</a>)</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Messages_Chats> Messages_GetCommonChats(this Client client, InputUserBase user_id, long max_id = default, int limit = int.MaxValue)
			=> client.Invoke(new Messages_GetCommonChats
			{
				user_id = user_id,
				max_id = max_id,
				limit = limit,
			});

		/// <summary>Get <a href="https://instantview.telegram.org">instant view</a> page		<para>See <a href="https://corefork.telegram.org/method/messages.getWebPage"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getWebPage#possible-errors">details</a>)</para></summary>
		/// <param name="url">URL of IV page to fetch</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>. <br/><strong>Note</strong>: the usual hash generation algorithm cannot be used in this case, please re-use the <see cref="WebPage"/>.<c>hash</c> field returned by a previous call to the method, or pass 0 if this is the first call or if the previous call did not return a <see cref="WebPage"/>.</param>
		public static Task<Messages_WebPage> Messages_GetWebPage(this Client client, string url, int hash = default)
			=> client.Invoke(new Messages_GetWebPage
			{
				url = url,
				hash = hash,
			});

		/// <summary>Pin/unpin a dialog		<para>See <a href="https://corefork.telegram.org/method/messages.toggleDialogPin"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.toggleDialogPin#possible-errors">details</a>)</para></summary>
		/// <param name="pinned">Whether to pin or unpin the dialog</param>
		/// <param name="peer">The dialog to pin</param>
		public static Task<bool> Messages_ToggleDialogPin(this Client client, InputDialogPeerBase peer, bool pinned = false)
			=> client.Invoke(new Messages_ToggleDialogPin
			{
				flags = (Messages_ToggleDialogPin.Flags)(pinned ? 0x1 : 0),
				peer = peer,
			});

		/// <summary>Reorder pinned dialogs		<para>See <a href="https://corefork.telegram.org/method/messages.reorderPinnedDialogs"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.reorderPinnedDialogs#possible-errors">details</a>)</para></summary>
		/// <param name="force">If set, dialogs pinned server-side but not present in the <c>order</c> field will be unpinned.</param>
		/// <param name="folder_id"><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></param>
		/// <param name="order">New dialog order</param>
		public static Task<bool> Messages_ReorderPinnedDialogs(this Client client, int folder_id, InputDialogPeerBase[] order, bool force = false)
			=> client.Invoke(new Messages_ReorderPinnedDialogs
			{
				flags = (Messages_ReorderPinnedDialogs.Flags)(force ? 0x1 : 0),
				folder_id = folder_id,
				order = order,
			});

		/// <summary>Get pinned dialogs		<para>See <a href="https://corefork.telegram.org/method/messages.getPinnedDialogs"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getPinnedDialogs#possible-errors">details</a>)</para></summary>
		/// <param name="folder_id"><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></param>
		public static Task<Messages_PeerDialogs> Messages_GetPinnedDialogs(this Client client, int folder_id)
			=> client.Invoke(new Messages_GetPinnedDialogs
			{
				folder_id = folder_id,
			});

		/// <summary>If you sent an invoice requesting a shipping address and the parameter is_flexible was specified, the bot will receive an <see cref="UpdateBotShippingQuery"/> update. Use this method to reply to shipping queries.		<para>See <a href="https://corefork.telegram.org/method/messages.setBotShippingResults"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.setBotShippingResults#possible-errors">details</a>)</para></summary>
		/// <param name="query_id">Unique identifier for the query to be answered</param>
		/// <param name="error">Error message in human readable form that explains why it is impossible to complete the order (e.g. "Sorry, delivery to your desired address is unavailable"). Telegram will display this message to the user.</param>
		/// <param name="shipping_options">A vector of available shipping options.</param>
		public static Task<bool> Messages_SetBotShippingResults(this Client client, long query_id, string error = null, ShippingOption[] shipping_options = null)
			=> client.Invoke(new Messages_SetBotShippingResults
			{
				flags = (Messages_SetBotShippingResults.Flags)((error != null ? 0x1 : 0) | (shipping_options != null ? 0x2 : 0)),
				query_id = query_id,
				error = error,
				shipping_options = shipping_options,
			});

		/// <summary>Once the user has confirmed their payment and shipping details, the bot receives an <see cref="UpdateBotPrecheckoutQuery"/> update.<br/>Use this method to respond to such pre-checkout queries.<br/><strong>Note</strong>: Telegram must receive an answer within 10 seconds after the pre-checkout query was sent.		<para>See <a href="https://corefork.telegram.org/method/messages.setBotPrecheckoutResults"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.setBotPrecheckoutResults#possible-errors">details</a>)</para></summary>
		/// <param name="success">Set this flag if everything is alright (goods are available, etc.) and the bot is ready to proceed with the order, otherwise do not set it, and set the <c>error</c> field, instead</param>
		/// <param name="query_id">Unique identifier for the query to be answered</param>
		/// <param name="error">Required if the <c>success</c> isn't set. Error message in human readable form that explains the reason for failure to proceed with the checkout (e.g. "Sorry, somebody just bought the last of our amazing black T-shirts while you were busy filling out your payment details. Please choose a different color or garment!"). Telegram will display this message to the user.</param>
		public static Task<bool> Messages_SetBotPrecheckoutResults(this Client client, long query_id, string error = null, bool success = false)
			=> client.Invoke(new Messages_SetBotPrecheckoutResults
			{
				flags = (Messages_SetBotPrecheckoutResults.Flags)((error != null ? 0x1 : 0) | (success ? 0x2 : 0)),
				query_id = query_id,
				error = error,
			});

		/// <summary>Upload a file and associate it to a chat (without actually sending it to the chat)		<para>See <a href="https://corefork.telegram.org/method/messages.uploadMedia"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.uploadMedia#possible-errors">details</a>)</para></summary>
		/// <param name="business_connection_id">Whether the media will be used only in the specified <a href="https://corefork.telegram.org/api/business#connected-bots">business connection »</a>, and not directly by the bot.</param>
		/// <param name="peer">The chat, can be <see langword="null"/> for bots and <see cref="InputPeerSelf"/> for users.</param>
		/// <param name="media">File uploaded in chunks as described in <a href="https://corefork.telegram.org/api/files">files »</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messageMediaEmpty">messageMediaEmpty</a></returns>
		public static Task<MessageMedia> Messages_UploadMedia(this Client client, InputPeer peer, InputMedia media, string business_connection_id = null)
			=> client.Invoke(new Messages_UploadMedia
			{
				flags = (Messages_UploadMedia.Flags)(business_connection_id != null ? 0x1 : 0),
				business_connection_id = business_connection_id,
				peer = peer,
				media = media,
			});

		/// <summary>Notify the other user in a private chat that a screenshot of the chat was taken		<para>See <a href="https://corefork.telegram.org/method/messages.sendScreenshotNotification"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.sendScreenshotNotification#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Other user</param>
		/// <param name="reply_to">Indicates the message that was screenshotted (the specified message ID can also be <c>0</c> to avoid indicating any specific message).</param>
		/// <param name="random_id">Random ID to avoid message resending <para>You can use <see cref="WTelegram.Helpers.RandomLong"/></para></param>
		public static Task<UpdatesBase> Messages_SendScreenshotNotification(this Client client, InputPeer peer, InputReplyTo reply_to, long random_id)
			=> client.Invoke(new Messages_SendScreenshotNotification
			{
				peer = peer,
				reply_to = reply_to,
				random_id = random_id,
			});

		/// <summary>Get faved stickers		<para>See <a href="https://corefork.telegram.org/method/messages.getFavedStickers"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.favedStickersNotModified">messages.favedStickersNotModified</a></returns>
		public static Task<Messages_FavedStickers> Messages_GetFavedStickers(this Client client, long hash = default)
			=> client.Invoke(new Messages_GetFavedStickers
			{
				hash = hash,
			});

		/// <summary>Mark or unmark a sticker as favorite		<para>See <a href="https://corefork.telegram.org/method/messages.faveSticker"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.faveSticker#possible-errors">details</a>)</para></summary>
		/// <param name="id">Sticker in question</param>
		/// <param name="unfave">Whether to add or remove a sticker from favorites</param>
		public static Task<bool> Messages_FaveSticker(this Client client, InputDocument id, bool unfave)
			=> client.Invoke(new Messages_FaveSticker
			{
				id = id,
				unfave = unfave,
			});

		/// <summary>Get unread messages where we were mentioned		<para>See <a href="https://corefork.telegram.org/method/messages.getUnreadMentions"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getUnreadMentions#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer where to look for mentions</param>
		/// <param name="top_msg_id">If set, considers only messages within the specified <a href="https://corefork.telegram.org/api/forum#forum-topics">forum topic</a></param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="add_offset"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <param name="max_id">Maximum message ID to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <param name="min_id">Minimum message ID to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Messages_MessagesBase> Messages_GetUnreadMentions(this Client client, InputPeer peer, int offset_id = default, int add_offset = default, int limit = int.MaxValue, int max_id = default, int min_id = default, int? top_msg_id = null)
			=> client.Invoke(new Messages_GetUnreadMentions
			{
				flags = (Messages_GetUnreadMentions.Flags)(top_msg_id != null ? 0x1 : 0),
				peer = peer,
				top_msg_id = top_msg_id ?? default,
				offset_id = offset_id,
				add_offset = add_offset,
				limit = limit,
				max_id = max_id,
				min_id = min_id,
			});

		/// <summary>Mark mentions as read		<para>See <a href="https://corefork.telegram.org/method/messages.readMentions"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.readMentions#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Dialog</param>
		/// <param name="top_msg_id">Mark as read only mentions within the specified <a href="https://corefork.telegram.org/api/forum#forum-topics">forum topic</a></param>
		public static Task<Messages_AffectedHistory> Messages_ReadMentions(this Client client, InputPeer peer, int? top_msg_id = null)
			=> client.InvokeAffected(new Messages_ReadMentions
			{
				flags = (Messages_ReadMentions.Flags)(top_msg_id != null ? 0x1 : 0),
				peer = peer,
				top_msg_id = top_msg_id ?? default,
			}, peer is InputPeerChannel ipc ? ipc.channel_id : 0);

		/// <summary>Get live location history of a certain user		<para>See <a href="https://corefork.telegram.org/method/messages.getRecentLocations"/></para></summary>
		/// <param name="peer">User</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a></param>
		public static Task<Messages_MessagesBase> Messages_GetRecentLocations(this Client client, InputPeer peer, int limit = int.MaxValue, long hash = default)
			=> client.Invoke(new Messages_GetRecentLocations
			{
				peer = peer,
				limit = limit,
				hash = hash,
			});

		/// <summary>Send an <a href="https://corefork.telegram.org/api/files#albums-grouped-media">album or grouped media</a>		<para>See <a href="https://corefork.telegram.org/method/messages.sendMultiMedia"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403,420,500 (<a href="https://corefork.telegram.org/method/messages.sendMultiMedia#possible-errors">details</a>)</para></summary>
		/// <param name="silent">Whether to send the album silently (no notification triggered)</param>
		/// <param name="background">Send in background?</param>
		/// <param name="clear_draft">Whether to clear <a href="https://corefork.telegram.org/api/drafts">drafts</a></param>
		/// <param name="noforwards">Only for bots, disallows forwarding and saving of the messages, even if the destination chat doesn't have <a href="https://telegram.org/blog/protected-content-delete-by-date-and-more">content protection</a> enabled</param>
		/// <param name="update_stickersets_order">Whether to move used stickersets to top, <a href="https://corefork.telegram.org/api/stickers#recent-stickersets">see here for more info on this flag »</a></param>
		/// <param name="invert_media">If set, any eventual webpage preview will be shown on top of the message instead of at the bottom.</param>
		/// <param name="allow_paid_floodskip">Bots only: if set, allows sending up to 1000 messages per second, ignoring <a href="https://corefork.telegram.org/bots/faq#how-can-i-message-all-of-my-bot-39s-subscribers-at-once">broadcasting limits</a> for a fee of 0.1 Telegram Stars per message. The relevant Stars will be withdrawn from the bot's balance.</param>
		/// <param name="peer">The destination chat</param>
		/// <param name="reply_to">If set, indicates that the message should be sent in reply to the specified message or story.</param>
		/// <param name="multi_media">The medias to send: note that they must be separately uploaded using <see cref="Messages_UploadMedia">Messages_UploadMedia</see> first, using raw <c>inputMediaUploaded*</c> constructors is not supported.</param>
		/// <param name="schedule_date">Scheduled message date for scheduled messages</param>
		/// <param name="send_as">Send this message as the specified peer</param>
		/// <param name="quick_reply_shortcut">Add the message to the specified <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">quick reply shortcut »</a>, instead.</param>
		/// <param name="effect">Specifies a <a href="https://corefork.telegram.org/api/effects">message effect »</a> to use for the message.</param>
		public static Task<UpdatesBase> Messages_SendMultiMedia(this Client client, InputPeer peer, InputSingleMedia[] multi_media, InputReplyTo reply_to = null, DateTime? schedule_date = null, InputPeer send_as = null, InputQuickReplyShortcutBase quick_reply_shortcut = null, long? effect = null, bool silent = false, bool background = false, bool clear_draft = false, bool noforwards = false, bool update_stickersets_order = false, bool invert_media = false, bool allow_paid_floodskip = false)
			=> client.Invoke(new Messages_SendMultiMedia
			{
				flags = (Messages_SendMultiMedia.Flags)((reply_to != null ? 0x1 : 0) | (schedule_date != null ? 0x400 : 0) | (send_as != null ? 0x2000 : 0) | (quick_reply_shortcut != null ? 0x20000 : 0) | (effect != null ? 0x40000 : 0) | (silent ? 0x20 : 0) | (background ? 0x40 : 0) | (clear_draft ? 0x80 : 0) | (noforwards ? 0x4000 : 0) | (update_stickersets_order ? 0x8000 : 0) | (invert_media ? 0x10000 : 0) | (allow_paid_floodskip ? 0x80000 : 0)),
				peer = peer,
				reply_to = reply_to,
				multi_media = multi_media,
				schedule_date = schedule_date ?? default,
				send_as = send_as,
				quick_reply_shortcut = quick_reply_shortcut,
				effect = effect ?? default,
			});

		/// <summary>Upload encrypted file and associate it to a secret chat		<para>See <a href="https://corefork.telegram.org/method/messages.uploadEncryptedFile"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.uploadEncryptedFile#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The secret chat to associate the file to</param>
		/// <param name="file">The file</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/encryptedFileEmpty">encryptedFileEmpty</a></returns>
		public static Task<EncryptedFile> Messages_UploadEncryptedFile(this Client client, InputEncryptedChat peer, InputEncryptedFileBase file)
			=> client.Invoke(new Messages_UploadEncryptedFile
			{
				peer = peer,
				file = file,
			});

		/// <summary>Search for stickersets		<para>See <a href="https://corefork.telegram.org/method/messages.searchStickerSets"/></para></summary>
		/// <param name="exclude_featured">Exclude featured stickersets from results</param>
		/// <param name="q">Query string</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.foundStickerSetsNotModified">messages.foundStickerSetsNotModified</a></returns>
		public static Task<Messages_FoundStickerSets> Messages_SearchStickerSets(this Client client, string q, long hash = default, bool exclude_featured = false)
			=> client.Invoke(new Messages_SearchStickerSets
			{
				flags = (Messages_SearchStickerSets.Flags)(exclude_featured ? 0x1 : 0),
				q = q,
				hash = hash,
			});

		/// <summary>Get message ranges for saving the user's chat history		<para>See <a href="https://corefork.telegram.org/method/messages.getSplitRanges"/></para></summary>
		public static Task<MessageRange[]> Messages_GetSplitRanges(this Client client)
			=> client.Invoke(new Messages_GetSplitRanges
			{
			});

		/// <summary>Manually mark dialog as unread		<para>See <a href="https://corefork.telegram.org/method/messages.markDialogUnread"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.markDialogUnread#possible-errors">details</a>)</para></summary>
		/// <param name="unread">Mark as unread/read</param>
		/// <param name="peer">Dialog</param>
		public static Task<bool> Messages_MarkDialogUnread(this Client client, InputDialogPeerBase peer, bool unread = false)
			=> client.Invoke(new Messages_MarkDialogUnread
			{
				flags = (Messages_MarkDialogUnread.Flags)(unread ? 0x1 : 0),
				peer = peer,
			});

		/// <summary>Get dialogs manually marked as unread		<para>See <a href="https://corefork.telegram.org/method/messages.getDialogUnreadMarks"/></para></summary>
		public static Task<DialogPeerBase[]> Messages_GetDialogUnreadMarks(this Client client)
			=> client.Invoke(new Messages_GetDialogUnreadMarks
			{
			});

		/// <summary>Clear all <a href="https://corefork.telegram.org/api/drafts">drafts</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.clearAllDrafts"/></para></summary>
		public static Task<bool> Messages_ClearAllDrafts(this Client client)
			=> client.Invoke(new Messages_ClearAllDrafts
			{
			});

		/// <summary>Pin a message		<para>See <a href="https://corefork.telegram.org/method/messages.updatePinnedMessage"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.updatePinnedMessage#possible-errors">details</a>)</para></summary>
		/// <param name="silent">Pin the message silently, without triggering a notification</param>
		/// <param name="unpin">Whether the message should unpinned or pinned</param>
		/// <param name="pm_oneside">Whether the message should only be pinned on the local side of a one-to-one chat</param>
		/// <param name="peer">The peer where to pin the message</param>
		/// <param name="id">The message to pin or unpin</param>
		public static Task<UpdatesBase> Messages_UpdatePinnedMessage(this Client client, InputPeer peer, int id, bool silent = false, bool unpin = false, bool pm_oneside = false)
			=> client.Invoke(new Messages_UpdatePinnedMessage
			{
				flags = (Messages_UpdatePinnedMessage.Flags)((silent ? 0x1 : 0) | (unpin ? 0x2 : 0) | (pm_oneside ? 0x4 : 0)),
				peer = peer,
				id = id,
			});

		/// <summary>Vote in a <see cref="Poll"/>		<para>See <a href="https://corefork.telegram.org/method/messages.sendVote"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.sendVote#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The chat where the poll was sent</param>
		/// <param name="msg_id">The message ID of the poll</param>
		/// <param name="options">The options that were chosen</param>
		public static Task<UpdatesBase> Messages_SendVote(this Client client, InputPeer peer, int msg_id, params byte[][] options)
			=> client.Invoke(new Messages_SendVote
			{
				peer = peer,
				msg_id = msg_id,
				options = options,
			});

		/// <summary>Get poll results		<para>See <a href="https://corefork.telegram.org/method/messages.getPollResults"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getPollResults#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer where the poll was found</param>
		/// <param name="msg_id">Message ID of poll message</param>
		public static Task<UpdatesBase> Messages_GetPollResults(this Client client, InputPeer peer, int msg_id)
			=> client.Invoke(new Messages_GetPollResults
			{
				peer = peer,
				msg_id = msg_id,
			});

		/// <summary>Get count of online users in a chat		<para>See <a href="https://corefork.telegram.org/method/messages.getOnlines"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getOnlines#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The chat</param>
		public static Task<ChatOnlines> Messages_GetOnlines(this Client client, InputPeer peer)
			=> client.Invoke(new Messages_GetOnlines
			{
				peer = peer,
			});

		/// <summary>Edit the description of a <a href="https://corefork.telegram.org/api/channel">group/supergroup/channel</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.editChatAbout"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.editChatAbout#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The <a href="https://corefork.telegram.org/api/channel">group/supergroup/channel</a>.</param>
		/// <param name="about">The new description</param>
		public static Task<bool> Messages_EditChatAbout(this Client client, InputPeer peer, string about)
			=> client.Invoke(new Messages_EditChatAbout
			{
				peer = peer,
				about = about,
			});

		/// <summary>Edit the default banned rights of a <a href="https://corefork.telegram.org/api/channel">channel/supergroup/group</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.editChatDefaultBannedRights"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.editChatDefaultBannedRights#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The peer</param>
		/// <param name="banned_rights">The new global rights</param>
		public static Task<UpdatesBase> Messages_EditChatDefaultBannedRights(this Client client, InputPeer peer, ChatBannedRights banned_rights)
			=> client.Invoke(new Messages_EditChatDefaultBannedRights
			{
				peer = peer,
				banned_rights = banned_rights,
			});

		/// <summary>Get localized <a href="https://corefork.telegram.org/api/custom-emoji#emoji-keywords">emoji keywords »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.getEmojiKeywords"/></para></summary>
		/// <param name="lang_code">Language code</param>
		public static Task<EmojiKeywordsDifference> Messages_GetEmojiKeywords(this Client client, string lang_code)
			=> client.Invoke(new Messages_GetEmojiKeywords
			{
				lang_code = lang_code,
			});

		/// <summary>Get changed <a href="https://corefork.telegram.org/api/custom-emoji#emoji-keywords">emoji keywords »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.getEmojiKeywordsDifference"/></para></summary>
		/// <param name="lang_code">Language code</param>
		/// <param name="from_version">Previous stored emoji keyword list <c>version</c></param>
		public static Task<EmojiKeywordsDifference> Messages_GetEmojiKeywordsDifference(this Client client, string lang_code, int from_version)
			=> client.Invoke(new Messages_GetEmojiKeywordsDifference
			{
				lang_code = lang_code,
				from_version = from_version,
			});

		/// <summary>Obtain a list of related languages that must be used when fetching <a href="https://corefork.telegram.org/api/custom-emoji#emoji-keywords">emoji keyword lists »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.getEmojiKeywordsLanguages"/></para></summary>
		/// <param name="lang_codes">The user's language codes</param>
		public static Task<EmojiLanguage[]> Messages_GetEmojiKeywordsLanguages(this Client client, params string[] lang_codes)
			=> client.Invoke(new Messages_GetEmojiKeywordsLanguages
			{
				lang_codes = lang_codes,
			});

		/// <summary>Returns an HTTP URL which can be used to automatically log in into translation platform and suggest new <a href="https://corefork.telegram.org/api/custom-emoji#emoji-keywords">emoji keywords »</a>. The URL will be valid for 30 seconds after generation.		<para>See <a href="https://corefork.telegram.org/method/messages.getEmojiURL"/></para></summary>
		/// <param name="lang_code">Language code for which the emoji keywords will be suggested</param>
		public static Task<EmojiURL> Messages_GetEmojiURL(this Client client, string lang_code)
			=> client.Invoke(new Messages_GetEmojiURL
			{
				lang_code = lang_code,
			});

		/// <summary>Get the number of results that would be found by a <see cref="Messages_Search">Messages_Search</see> call with the same parameters		<para>See <a href="https://corefork.telegram.org/method/messages.getSearchCounters"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getSearchCounters#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer where to search</param>
		/// <param name="saved_peer_id">Search within the <a href="https://corefork.telegram.org/api/saved-messages">saved message dialog »</a> with this ID.</param>
		/// <param name="top_msg_id">If set, consider only messages within the specified <a href="https://corefork.telegram.org/api/forum#forum-topics">forum topic</a></param>
		/// <param name="filters">Search filters</param>
		public static Task<Messages_SearchCounter[]> Messages_GetSearchCounters(this Client client, InputPeer peer, MessagesFilter[] filters, int? top_msg_id = null, InputPeer saved_peer_id = null)
			=> client.Invoke(new Messages_GetSearchCounters
			{
				flags = (Messages_GetSearchCounters.Flags)((top_msg_id != null ? 0x1 : 0) | (saved_peer_id != null ? 0x4 : 0)),
				peer = peer,
				saved_peer_id = saved_peer_id,
				top_msg_id = top_msg_id ?? default,
				filters = filters,
			});

		/// <summary>Get more info about a Seamless Telegram Login authorization request, for more info <a href="https://corefork.telegram.org/api/url-authorization">click here »</a>		<para>See <a href="https://corefork.telegram.org/method/messages.requestUrlAuth"/></para></summary>
		/// <param name="peer">Peer where the message is located</param>
		/// <param name="msg_id">The message</param>
		/// <param name="button_id">The ID of the button with the authorization request</param>
		/// <param name="url">URL used for <a href="https://corefork.telegram.org/api/url-authorization#link-url-authorization">link URL authorization, click here for more info »</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/urlAuthResultDefault">urlAuthResultDefault</a></returns>
		public static Task<UrlAuthResult> Messages_RequestUrlAuth(this Client client, InputPeer peer = null, int? msg_id = null, int? button_id = null, string url = null)
			=> client.Invoke(new Messages_RequestUrlAuth
			{
				flags = (Messages_RequestUrlAuth.Flags)((peer != null ? 0x2 : 0) | (msg_id != null ? 0x2 : 0) | (button_id != null ? 0x2 : 0) | (url != null ? 0x4 : 0)),
				peer = peer,
				msg_id = msg_id ?? default,
				button_id = button_id ?? default,
				url = url,
			});

		/// <summary>Use this to accept a Seamless Telegram Login authorization request, for more info <a href="https://corefork.telegram.org/api/url-authorization">click here »</a>		<para>See <a href="https://corefork.telegram.org/method/messages.acceptUrlAuth"/></para></summary>
		/// <param name="write_allowed">Set this flag to allow the bot to send messages to you (if requested)</param>
		/// <param name="peer">The location of the message</param>
		/// <param name="msg_id">Message ID of the message with the login button</param>
		/// <param name="button_id">ID of the login button</param>
		/// <param name="url">URL used for <a href="https://corefork.telegram.org/api/url-authorization#link-url-authorization">link URL authorization, click here for more info »</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/urlAuthResultDefault">urlAuthResultDefault</a></returns>
		public static Task<UrlAuthResult> Messages_AcceptUrlAuth(this Client client, InputPeer peer = null, int? msg_id = null, int? button_id = null, string url = null, bool write_allowed = false)
			=> client.Invoke(new Messages_AcceptUrlAuth
			{
				flags = (Messages_AcceptUrlAuth.Flags)((peer != null ? 0x2 : 0) | (msg_id != null ? 0x2 : 0) | (button_id != null ? 0x2 : 0) | (url != null ? 0x4 : 0) | (write_allowed ? 0x1 : 0)),
				peer = peer,
				msg_id = msg_id ?? default,
				button_id = button_id ?? default,
				url = url,
			});

		/// <summary>Should be called after the user hides the <a href="https://corefork.telegram.org/api/action-bar">report spam/add as contact bar</a> of a new chat, effectively prevents the user from executing the actions specified in the <a href="https://corefork.telegram.org/api/action-bar">action bar »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.hidePeerSettingsBar"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.hidePeerSettingsBar#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer</param>
		public static Task<bool> Messages_HidePeerSettingsBar(this Client client, InputPeer peer)
			=> client.Invoke(new Messages_HidePeerSettingsBar
			{
				peer = peer,
			});

		/// <summary>Get scheduled messages		<para>See <a href="https://corefork.telegram.org/method/messages.getScheduledHistory"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getScheduledHistory#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>. <br/>To generate the hash, populate the <c>ids</c> array with the <c>id</c>, <c>date</c> and <c>edit_date</c> (in this order) of the previously returned messages (in order, i.e. <c>ids = [id1, date1, edit_date1, id2, date2, edit_date2, ...]</c>).</param>
		public static Task<Messages_MessagesBase> Messages_GetScheduledHistory(this Client client, InputPeer peer, long hash = default)
			=> client.Invoke(new Messages_GetScheduledHistory
			{
				peer = peer,
				hash = hash,
			});

		/// <summary>Get scheduled messages		<para>See <a href="https://corefork.telegram.org/method/messages.getScheduledMessages"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getScheduledMessages#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer</param>
		/// <param name="id">IDs of scheduled messages</param>
		public static Task<Messages_MessagesBase> Messages_GetScheduledMessages(this Client client, InputPeer peer, params int[] id)
			=> client.Invoke(new Messages_GetScheduledMessages
			{
				peer = peer,
				id = id,
			});

		/// <summary>Send scheduled messages right away		<para>See <a href="https://corefork.telegram.org/method/messages.sendScheduledMessages"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,500 (<a href="https://corefork.telegram.org/method/messages.sendScheduledMessages#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer</param>
		/// <param name="id">Scheduled message IDs</param>
		public static Task<UpdatesBase> Messages_SendScheduledMessages(this Client client, InputPeer peer, params int[] id)
			=> client.Invoke(new Messages_SendScheduledMessages
			{
				peer = peer,
				id = id,
			});

		/// <summary>Delete scheduled messages		<para>See <a href="https://corefork.telegram.org/method/messages.deleteScheduledMessages"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.deleteScheduledMessages#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer</param>
		/// <param name="id">Scheduled message IDs</param>
		public static Task<UpdatesBase> Messages_DeleteScheduledMessages(this Client client, InputPeer peer, params int[] id)
			=> client.Invoke(new Messages_DeleteScheduledMessages
			{
				peer = peer,
				id = id,
			});

		/// <summary>Get poll results for non-anonymous polls		<para>See <a href="https://corefork.telegram.org/method/messages.getPollVotes"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.getPollVotes#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Chat where the poll was sent</param>
		/// <param name="id">Message ID</param>
		/// <param name="option">Get only results for the specified poll <c>option</c></param>
		/// <param name="offset">Offset for results, taken from the <c>next_offset</c> field of <see cref="Messages_VotesList"/>, initially an empty string. <br/>Note: if no more results are available, the method call will return an empty <c>next_offset</c>; thus, avoid providing the <c>next_offset</c> returned in <see cref="Messages_VotesList"/> if it is empty, to avoid an infinite loop.</param>
		/// <param name="limit">Number of results to return</param>
		public static Task<Messages_VotesList> Messages_GetPollVotes(this Client client, InputPeer peer, int id, int limit = int.MaxValue, byte[] option = null, string offset = null)
			=> client.Invoke(new Messages_GetPollVotes
			{
				flags = (Messages_GetPollVotes.Flags)((option != null ? 0x1 : 0) | (offset != null ? 0x2 : 0)),
				peer = peer,
				id = id,
				option = option,
				offset = offset,
				limit = limit,
			});

		/// <summary>Apply changes to multiple stickersets		<para>See <a href="https://corefork.telegram.org/method/messages.toggleStickerSets"/></para></summary>
		/// <param name="uninstall">Uninstall the specified stickersets</param>
		/// <param name="archive">Archive the specified stickersets</param>
		/// <param name="unarchive">Unarchive the specified stickersets</param>
		/// <param name="stickersets">Stickersets to act upon</param>
		public static Task<bool> Messages_ToggleStickerSets(this Client client, InputStickerSet[] stickersets, bool uninstall = false, bool archive = false, bool unarchive = false)
			=> client.Invoke(new Messages_ToggleStickerSets
			{
				flags = (Messages_ToggleStickerSets.Flags)((uninstall ? 0x1 : 0) | (archive ? 0x2 : 0) | (unarchive ? 0x4 : 0)),
				stickersets = stickersets,
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/folders">folders</a>		<para>See <a href="https://corefork.telegram.org/method/messages.getDialogFilters"/></para></summary>
		public static Task<Messages_DialogFilters> Messages_GetDialogFilters(this Client client)
			=> client.Invoke(new Messages_GetDialogFilters
			{
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/folders">suggested folders</a>		<para>See <a href="https://corefork.telegram.org/method/messages.getSuggestedDialogFilters"/></para></summary>
		public static Task<DialogFilterSuggested[]> Messages_GetSuggestedDialogFilters(this Client client)
			=> client.Invoke(new Messages_GetSuggestedDialogFilters
			{
			});

		/// <summary>Update <a href="https://corefork.telegram.org/api/folders">folder</a>		<para>See <a href="https://corefork.telegram.org/method/messages.updateDialogFilter"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.updateDialogFilter#possible-errors">details</a>)</para></summary>
		/// <param name="id"><a href="https://corefork.telegram.org/api/folders">Folder</a> ID</param>
		/// <param name="filter"><a href="https://corefork.telegram.org/api/folders">Folder</a> info</param>
		public static Task<bool> Messages_UpdateDialogFilter(this Client client, int id, DialogFilterBase filter = null)
			=> client.Invoke(new Messages_UpdateDialogFilter
			{
				flags = (Messages_UpdateDialogFilter.Flags)(filter != null ? 0x1 : 0),
				id = id,
				filter = filter,
			});

		/// <summary>Reorder <a href="https://corefork.telegram.org/api/folders">folders</a>		<para>See <a href="https://corefork.telegram.org/method/messages.updateDialogFiltersOrder"/></para></summary>
		/// <param name="order">New <a href="https://corefork.telegram.org/api/folders">folder</a> order</param>
		public static Task<bool> Messages_UpdateDialogFiltersOrder(this Client client, params int[] order)
			=> client.Invoke(new Messages_UpdateDialogFiltersOrder
			{
				order = order,
			});

		/// <summary>Method for fetching previously featured stickers		<para>See <a href="https://corefork.telegram.org/method/messages.getOldFeaturedStickers"/></para></summary>
		/// <param name="offset">Offset</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		public static Task<Messages_FeaturedStickersBase> Messages_GetOldFeaturedStickers(this Client client, int offset = default, int limit = int.MaxValue, long hash = default)
			=> client.Invoke(new Messages_GetOldFeaturedStickers
			{
				offset = offset,
				limit = limit,
				hash = hash,
			});

		/// <summary>Get messages in a reply thread		<para>See <a href="https://corefork.telegram.org/method/messages.getReplies"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getReplies#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer</param>
		/// <param name="msg_id">Message ID</param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="offset_date"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="add_offset"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <param name="max_id">If a positive value was transferred, the method will return only messages with ID smaller than max_id</param>
		/// <param name="min_id">If a positive value was transferred, the method will return only messages with ID bigger than min_id</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a></param>
		public static Task<Messages_MessagesBase> Messages_GetReplies(this Client client, InputPeer peer, int msg_id, int offset_id = default, DateTime offset_date = default, int add_offset = default, int limit = int.MaxValue, int max_id = default, int min_id = default, long hash = default)
			=> client.Invoke(new Messages_GetReplies
			{
				peer = peer,
				msg_id = msg_id,
				offset_id = offset_id,
				offset_date = offset_date,
				add_offset = add_offset,
				limit = limit,
				max_id = max_id,
				min_id = min_id,
				hash = hash,
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/threads">discussion message</a> from the <a href="https://corefork.telegram.org/api/discussion">associated discussion group</a> of a channel to show it on top of the comment section, without actually joining the group		<para>See <a href="https://corefork.telegram.org/method/messages.getDiscussionMessage"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getDiscussionMessage#possible-errors">details</a>)</para></summary>
		/// <param name="peer"><a href="https://corefork.telegram.org/api/channel">Channel ID</a></param>
		/// <param name="msg_id">Message ID</param>
		public static Task<Messages_DiscussionMessage> Messages_GetDiscussionMessage(this Client client, InputPeer peer, int msg_id)
			=> client.Invoke(new Messages_GetDiscussionMessage
			{
				peer = peer,
				msg_id = msg_id,
			});

		/// <summary>Mark a <a href="https://corefork.telegram.org/api/threads">thread</a> as read		<para>See <a href="https://corefork.telegram.org/method/messages.readDiscussion"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.readDiscussion#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Group ID</param>
		/// <param name="msg_id">ID of message that started the thread</param>
		/// <param name="read_max_id">ID up to which thread messages were read</param>
		public static Task<bool> Messages_ReadDiscussion(this Client client, InputPeer peer, int msg_id, int read_max_id)
			=> client.Invoke(new Messages_ReadDiscussion
			{
				peer = peer,
				msg_id = msg_id,
				read_max_id = read_max_id,
			});

		/// <summary><a href="https://corefork.telegram.org/api/pin">Unpin</a> all pinned messages		<para>See <a href="https://corefork.telegram.org/method/messages.unpinAllMessages"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.unpinAllMessages#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Chat where to unpin</param>
		/// <param name="top_msg_id"><a href="https://corefork.telegram.org/api/forum#forum-topics">Forum topic</a> where to unpin</param>
		public static Task<Messages_AffectedHistory> Messages_UnpinAllMessages(this Client client, InputPeer peer, int? top_msg_id = null)
			=> client.InvokeAffected(new Messages_UnpinAllMessages
			{
				flags = (Messages_UnpinAllMessages.Flags)(top_msg_id != null ? 0x1 : 0),
				peer = peer,
				top_msg_id = top_msg_id ?? default,
			}, peer is InputPeerChannel ipc ? ipc.channel_id : 0);

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://wiz0u.github.io/WTelegramClient/#terminology">Terminology</see> in the README to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Delete a <a href="https://corefork.telegram.org/api/channel">chat</a>		<para>See <a href="https://corefork.telegram.org/method/messages.deleteChat"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.deleteChat#possible-errors">details</a>)</para></summary>
		/// <param name="chat_id">Chat ID</param>
		public static Task<bool> Messages_DeleteChat(this Client client, long chat_id)
			=> client.Invoke(new Messages_DeleteChat
			{
				chat_id = chat_id,
			});

		/// <summary>Delete the entire phone call history.		<para>See <a href="https://corefork.telegram.org/method/messages.deletePhoneCallHistory"/></para></summary>
		/// <param name="revoke">Whether to remove phone call history for participants as well</param>
		public static Task<Messages_AffectedFoundMessages> Messages_DeletePhoneCallHistory(this Client client, bool revoke = false)
			=> client.InvokeAffected(new Messages_DeletePhoneCallHistory
			{
				flags = (Messages_DeletePhoneCallHistory.Flags)(revoke ? 0x1 : 0),
			}, 0);

		/// <summary>Obtains information about a chat export file, generated by a foreign chat app, <a href="https://corefork.telegram.org/api/import">click here for more info about imported chats »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.checkHistoryImport"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.checkHistoryImport#possible-errors">details</a>)</para></summary>
		/// <param name="import_head">Beginning of the message file; up to 100 lines.</param>
		public static Task<Messages_HistoryImportParsed> Messages_CheckHistoryImport(this Client client, string import_head)
			=> client.Invoke(new Messages_CheckHistoryImport
			{
				import_head = import_head,
			});

		/// <summary>Import chat history from a foreign chat app into a specific Telegram chat, <a href="https://corefork.telegram.org/api/import">click here for more info about imported chats »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.initHistoryImport"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/messages.initHistoryImport#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The Telegram chat where the <a href="https://corefork.telegram.org/api/import">history should be imported</a>.</param>
		/// <param name="file">File with messages to import.</param>
		/// <param name="media_count">Number of media files associated with the chat that will be uploaded using <see cref="Messages_UploadImportedMedia">Messages_UploadImportedMedia</see>.</param>
		public static Task<Messages_HistoryImport> Messages_InitHistoryImport(this Client client, InputPeer peer, InputFileBase file, int media_count)
			=> client.Invoke(new Messages_InitHistoryImport
			{
				peer = peer,
				file = file,
				media_count = media_count,
			});

		/// <summary>Upload a media file associated with an <a href="https://corefork.telegram.org/api/import">imported chat, click here for more info »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.uploadImportedMedia"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.uploadImportedMedia#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The Telegram chat where the media will be imported</param>
		/// <param name="import_id">Identifier of a <a href="https://corefork.telegram.org/api/import">history import session</a>, returned by <see cref="Messages_InitHistoryImport">Messages_InitHistoryImport</see></param>
		/// <param name="file_name">File name</param>
		/// <param name="media">Media metadata</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messageMediaEmpty">messageMediaEmpty</a></returns>
		public static Task<MessageMedia> Messages_UploadImportedMedia(this Client client, InputPeer peer, long import_id, string file_name, InputMedia media)
			=> client.Invoke(new Messages_UploadImportedMedia
			{
				peer = peer,
				import_id = import_id,
				file_name = file_name,
				media = media,
			});

		/// <summary>Complete the <a href="https://corefork.telegram.org/api/import">history import process</a>, importing all messages into the chat.<br/>To be called only after initializing the import with <see cref="Messages_InitHistoryImport">Messages_InitHistoryImport</see> and uploading all files using <see cref="Messages_UploadImportedMedia">Messages_UploadImportedMedia</see>.		<para>See <a href="https://corefork.telegram.org/method/messages.startHistoryImport"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.startHistoryImport#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The Telegram chat where the messages should be <a href="https://corefork.telegram.org/api/import">imported, click here for more info »</a></param>
		/// <param name="import_id">Identifier of a history import session, returned by <see cref="Messages_InitHistoryImport">Messages_InitHistoryImport</see>.</param>
		public static Task<bool> Messages_StartHistoryImport(this Client client, InputPeer peer, long import_id)
			=> client.Invoke(new Messages_StartHistoryImport
			{
				peer = peer,
				import_id = import_id,
			});

		/// <summary>Get info about the chat invites of a specific chat		<para>See <a href="https://corefork.telegram.org/method/messages.getExportedChatInvites"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.getExportedChatInvites#possible-errors">details</a>)</para></summary>
		/// <param name="revoked">Whether to fetch revoked chat invites</param>
		/// <param name="peer">Chat</param>
		/// <param name="admin_id">Whether to only fetch chat invites from this admin</param>
		/// <param name="offset_date"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="offset_link"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Messages_ExportedChatInvites> Messages_GetExportedChatInvites(this Client client, InputPeer peer, InputUserBase admin_id, int limit = int.MaxValue, DateTime? offset_date = null, string offset_link = null, bool revoked = false)
			=> client.Invoke(new Messages_GetExportedChatInvites
			{
				flags = (Messages_GetExportedChatInvites.Flags)((offset_date != null ? 0x4 : 0) | (offset_link != null ? 0x4 : 0) | (revoked ? 0x8 : 0)),
				peer = peer,
				admin_id = admin_id,
				offset_date = offset_date ?? default,
				offset_link = offset_link,
				limit = limit,
			});

		/// <summary>Get info about a chat invite		<para>See <a href="https://corefork.telegram.org/method/messages.getExportedChatInvite"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.getExportedChatInvite#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Chat</param>
		/// <param name="link">Invite link</param>
		public static Task<Messages_ExportedChatInviteBase> Messages_GetExportedChatInvite(this Client client, InputPeer peer, string link)
			=> client.Invoke(new Messages_GetExportedChatInvite
			{
				peer = peer,
				link = link,
			});

		/// <summary>Edit an exported chat invite		<para>See <a href="https://corefork.telegram.org/method/messages.editExportedChatInvite"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.editExportedChatInvite#possible-errors">details</a>)</para></summary>
		/// <param name="revoked">Whether to revoke the chat invite</param>
		/// <param name="peer">Chat</param>
		/// <param name="link">Invite link</param>
		/// <param name="expire_date">New expiration date</param>
		/// <param name="usage_limit">Maximum number of users that can join using this link</param>
		/// <param name="request_needed">Whether admin confirmation is required before admitting each separate user into the chat</param>
		/// <param name="title">Description of the invite link, visible only to administrators</param>
		public static Task<Messages_ExportedChatInviteBase> Messages_EditExportedChatInvite(this Client client, InputPeer peer, string link, DateTime? expire_date = null, int? usage_limit = null, bool? request_needed = default, string title = null, bool revoked = false)
			=> client.Invoke(new Messages_EditExportedChatInvite
			{
				flags = (Messages_EditExportedChatInvite.Flags)((expire_date != null ? 0x1 : 0) | (usage_limit != null ? 0x2 : 0) | (request_needed != default ? 0x8 : 0) | (title != null ? 0x10 : 0) | (revoked ? 0x4 : 0)),
				peer = peer,
				link = link,
				expire_date = expire_date ?? default,
				usage_limit = usage_limit ?? default,
				request_needed = request_needed ?? default,
				title = title,
			});

		/// <summary>Delete all revoked chat invites		<para>See <a href="https://corefork.telegram.org/method/messages.deleteRevokedExportedChatInvites"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.deleteRevokedExportedChatInvites#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Chat</param>
		/// <param name="admin_id">ID of the admin that originally generated the revoked chat invites</param>
		public static Task<bool> Messages_DeleteRevokedExportedChatInvites(this Client client, InputPeer peer, InputUserBase admin_id)
			=> client.Invoke(new Messages_DeleteRevokedExportedChatInvites
			{
				peer = peer,
				admin_id = admin_id,
			});

		/// <summary>Delete a chat invite		<para>See <a href="https://corefork.telegram.org/method/messages.deleteExportedChatInvite"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.deleteExportedChatInvite#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer</param>
		/// <param name="link">Invite link</param>
		public static Task<bool> Messages_DeleteExportedChatInvite(this Client client, InputPeer peer, string link)
			=> client.Invoke(new Messages_DeleteExportedChatInvite
			{
				peer = peer,
				link = link,
			});

		/// <summary>Get info about chat invites generated by admins.		<para>See <a href="https://corefork.telegram.org/method/messages.getAdminsWithInvites"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.getAdminsWithInvites#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Chat</param>
		public static Task<Messages_ChatAdminsWithInvites> Messages_GetAdminsWithInvites(this Client client, InputPeer peer)
			=> client.Invoke(new Messages_GetAdminsWithInvites
			{
				peer = peer,
			});

		/// <summary>Get info about the users that joined the chat using a specific chat invite		<para>See <a href="https://corefork.telegram.org/method/messages.getChatInviteImporters"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.getChatInviteImporters#possible-errors">details</a>)</para></summary>
		/// <param name="requested">If set, only returns info about users with pending <a href="https://corefork.telegram.org/api/invites#join-requests">join requests »</a></param>
		/// <param name="subscription_expired">Set this flag if the link is a <a href="https://corefork.telegram.org/api/stars#star-subscriptions">Telegram Star subscription link »</a> and only members with already expired subscription must be returned.</param>
		/// <param name="peer">Chat</param>
		/// <param name="link">Invite link</param>
		/// <param name="q">Search for a user in the pending <a href="https://corefork.telegram.org/api/invites#join-requests">join requests »</a> list: only available when the <c>requested</c> flag is set, cannot be used together with a specific <c>link</c>.</param>
		/// <param name="offset_date"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="offset_user">User ID for <a href="https://corefork.telegram.org/api/offsets">pagination</a>: if set, <c>offset_date</c> must also be set.</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Messages_ChatInviteImporters> Messages_GetChatInviteImporters(this Client client, InputPeer peer, DateTime offset_date = default, InputUserBase offset_user = null, int limit = int.MaxValue, string link = null, string q = null, bool requested = false, bool subscription_expired = false)
			=> client.Invoke(new Messages_GetChatInviteImporters
			{
				flags = (Messages_GetChatInviteImporters.Flags)((link != null ? 0x2 : 0) | (q != null ? 0x4 : 0) | (requested ? 0x1 : 0) | (subscription_expired ? 0x8 : 0)),
				peer = peer,
				link = link,
				q = q,
				offset_date = offset_date,
				offset_user = offset_user,
				limit = limit,
			});

		/// <summary>Set maximum Time-To-Live of all messages in the specified chat		<para>See <a href="https://corefork.telegram.org/method/messages.setHistoryTTL"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.setHistoryTTL#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The dialog</param>
		/// <param name="period">Automatically delete all messages sent in the chat after this many seconds</param>
		public static Task<UpdatesBase> Messages_SetHistoryTTL(this Client client, InputPeer peer, int period)
			=> client.Invoke(new Messages_SetHistoryTTL
			{
				peer = peer,
				period = period,
			});

		/// <summary>Check whether chat history exported from another chat app can be <a href="https://corefork.telegram.org/api/import">imported into a specific Telegram chat, click here for more info »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.checkHistoryImportPeer"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.checkHistoryImportPeer#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The chat where we want to <a href="https://corefork.telegram.org/api/import">import history »</a>.</param>
		public static Task<Messages_CheckedHistoryImportPeer> Messages_CheckHistoryImportPeer(this Client client, InputPeer peer)
			=> client.Invoke(new Messages_CheckHistoryImportPeer
			{
				peer = peer,
			});

		/// <summary>Change the chat theme of a certain chat		<para>See <a href="https://corefork.telegram.org/method/messages.setChatTheme"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.setChatTheme#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Private chat where to change theme</param>
		/// <param name="emoticon">Emoji, identifying a specific chat theme; a list of chat themes can be fetched using <see cref="Account_GetChatThemes">Account_GetChatThemes</see></param>
		public static Task<UpdatesBase> Messages_SetChatTheme(this Client client, InputPeer peer, string emoticon)
			=> client.Invoke(new Messages_SetChatTheme
			{
				peer = peer,
				emoticon = emoticon,
			});

		/// <summary>Get which users read a specific message: only available for groups and supergroups with less than <a href="https://corefork.telegram.org/api/config#chat-read-mark-size-threshold"><c>chat_read_mark_size_threshold</c> members</a>, read receipts will be stored for <a href="https://corefork.telegram.org/api/config#chat-read-mark-expire-period"><c>chat_read_mark_expire_period</c> seconds after the message was sent</a>, see <a href="https://corefork.telegram.org/api/config#client-configuration">client configuration for more info »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.getMessageReadParticipants"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getMessageReadParticipants#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Dialog</param>
		/// <param name="msg_id">Message ID</param>
		public static Task<ReadParticipantDate[]> Messages_GetMessageReadParticipants(this Client client, InputPeer peer, int msg_id)
			=> client.Invoke(new Messages_GetMessageReadParticipants
			{
				peer = peer,
				msg_id = msg_id,
			});

		/// <summary>Returns information about the next messages of the specified type in the chat split by days.		<para>See <a href="https://corefork.telegram.org/method/messages.getSearchResultsCalendar"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getSearchResultsCalendar#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer where to search</param>
		/// <param name="saved_peer_id">Search within the <a href="https://corefork.telegram.org/api/saved-messages">saved message dialog »</a> with this ID.</param>
		/// <param name="filter">Message filter, <see langword="null"/>, <see cref="InputMessagesFilterMyMentions"/> filters are not supported by this method.</param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="offset_date"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		public static Task<Messages_SearchResultsCalendar> Messages_GetSearchResultsCalendar(this Client client, InputPeer peer, MessagesFilter filter = null, int offset_id = default, DateTime offset_date = default, InputPeer saved_peer_id = null)
			=> client.Invoke(new Messages_GetSearchResultsCalendar
			{
				flags = (Messages_GetSearchResultsCalendar.Flags)(saved_peer_id != null ? 0x4 : 0),
				peer = peer,
				saved_peer_id = saved_peer_id,
				filter = filter,
				offset_id = offset_id,
				offset_date = offset_date,
			});

		/// <summary>Returns sparse positions of messages of the specified type in the chat to be used for shared media scroll implementation.		<para>See <a href="https://corefork.telegram.org/method/messages.getSearchResultsPositions"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getSearchResultsPositions#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer where to search</param>
		/// <param name="saved_peer_id">Search within the <a href="https://corefork.telegram.org/api/saved-messages">saved message dialog »</a> with this ID.</param>
		/// <param name="filter">Message filter, <see langword="null"/>, <see cref="InputMessagesFilterMyMentions"/> filters are not supported by this method.</param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Messages_SearchResultsPositions> Messages_GetSearchResultsPositions(this Client client, InputPeer peer, MessagesFilter filter = null, int offset_id = default, int limit = int.MaxValue, InputPeer saved_peer_id = null)
			=> client.Invoke(new Messages_GetSearchResultsPositions
			{
				flags = (Messages_GetSearchResultsPositions.Flags)(saved_peer_id != null ? 0x4 : 0),
				peer = peer,
				saved_peer_id = saved_peer_id,
				filter = filter,
				offset_id = offset_id,
				limit = limit,
			});

		/// <summary>Dismiss or approve a chat <a href="https://corefork.telegram.org/api/invites#join-requests">join request</a> related to a specific chat or channel.		<para>See <a href="https://corefork.telegram.org/method/messages.hideChatJoinRequest"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.hideChatJoinRequest#possible-errors">details</a>)</para></summary>
		/// <param name="approved">Whether to dismiss or approve the chat <a href="https://corefork.telegram.org/api/invites#join-requests">join request »</a></param>
		/// <param name="peer">The chat or channel</param>
		/// <param name="user_id">The user whose <a href="https://corefork.telegram.org/api/invites#join-requests">join request »</a> should be dismissed or approved</param>
		public static Task<UpdatesBase> Messages_HideChatJoinRequest(this Client client, InputPeer peer, InputUserBase user_id, bool approved = false)
			=> client.Invoke(new Messages_HideChatJoinRequest
			{
				flags = (Messages_HideChatJoinRequest.Flags)(approved ? 0x1 : 0),
				peer = peer,
				user_id = user_id,
			});

		/// <summary>Dismiss or approve all <a href="https://corefork.telegram.org/api/invites#join-requests">join requests</a> related to a specific chat or channel.		<para>See <a href="https://corefork.telegram.org/method/messages.hideAllChatJoinRequests"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.hideAllChatJoinRequests#possible-errors">details</a>)</para></summary>
		/// <param name="approved">Whether to dismiss or approve all chat <a href="https://corefork.telegram.org/api/invites#join-requests">join requests »</a></param>
		/// <param name="peer">The chat or channel</param>
		/// <param name="link">Only dismiss or approve <a href="https://corefork.telegram.org/api/invites#join-requests">join requests »</a> initiated using this invite link</param>
		public static Task<UpdatesBase> Messages_HideAllChatJoinRequests(this Client client, InputPeer peer, string link = null, bool approved = false)
			=> client.Invoke(new Messages_HideAllChatJoinRequests
			{
				flags = (Messages_HideAllChatJoinRequests.Flags)((link != null ? 0x2 : 0) | (approved ? 0x1 : 0)),
				peer = peer,
				link = link,
			});

		/// <summary>Enable or disable <a href="https://telegram.org/blog/protected-content-delete-by-date-and-more">content protection</a> on a channel or chat		<para>See <a href="https://corefork.telegram.org/method/messages.toggleNoForwards"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.toggleNoForwards#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The chat or channel</param>
		/// <param name="enabled">Enable or disable content protection</param>
		public static Task<UpdatesBase> Messages_ToggleNoForwards(this Client client, InputPeer peer, bool enabled)
			=> client.Invoke(new Messages_ToggleNoForwards
			{
				peer = peer,
				enabled = enabled,
			});

		/// <summary>Change the default peer that should be used when sending messages, reactions, poll votes to a specific group		<para>See <a href="https://corefork.telegram.org/method/messages.saveDefaultSendAs"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.saveDefaultSendAs#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Group</param>
		/// <param name="send_as">The default peer that should be used when sending messages to the group</param>
		public static Task<bool> Messages_SaveDefaultSendAs(this Client client, InputPeer peer, InputPeer send_as)
			=> client.Invoke(new Messages_SaveDefaultSendAs
			{
				peer = peer,
				send_as = send_as,
			});

		/// <summary>React to message.		<para>See <a href="https://corefork.telegram.org/method/messages.sendReaction"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.sendReaction#possible-errors">details</a>)</para></summary>
		/// <param name="big">Whether a bigger and longer reaction should be shown</param>
		/// <param name="add_to_recent">Whether to add this reaction to the <a href="https://corefork.telegram.org/api/reactions#recent-reactions">recent reactions list »</a>.</param>
		/// <param name="peer">Peer</param>
		/// <param name="msg_id">Message ID to react to</param>
		/// <param name="reaction">A list of reactions</param>
		public static Task<UpdatesBase> Messages_SendReaction(this Client client, InputPeer peer, int msg_id, Reaction[] reaction = null, bool big = false, bool add_to_recent = false)
			=> client.Invoke(new Messages_SendReaction
			{
				flags = (Messages_SendReaction.Flags)((reaction != null ? 0x1 : 0) | (big ? 0x2 : 0) | (add_to_recent ? 0x4 : 0)),
				peer = peer,
				msg_id = msg_id,
				reaction = reaction,
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/reactions">message reactions »</a>		<para>See <a href="https://corefork.telegram.org/method/messages.getMessagesReactions"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getMessagesReactions#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer</param>
		/// <param name="id">Message IDs</param>
		public static Task<UpdatesBase> Messages_GetMessagesReactions(this Client client, InputPeer peer, params int[] id)
			=> client.Invoke(new Messages_GetMessagesReactions
			{
				peer = peer,
				id = id,
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/reactions">message reaction</a> list, along with the sender of each reaction.		<para>See <a href="https://corefork.telegram.org/method/messages.getMessageReactionsList"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.getMessageReactionsList#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer</param>
		/// <param name="id">Message ID</param>
		/// <param name="reaction">Get only reactions of this type</param>
		/// <param name="offset">Offset for pagination (taken from the <c>next_offset</c> field of the returned <see cref="Messages_MessageReactionsList"/>); empty in the first request.</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Messages_MessageReactionsList> Messages_GetMessageReactionsList(this Client client, InputPeer peer, int id, int limit = int.MaxValue, Reaction reaction = null, string offset = null)
			=> client.Invoke(new Messages_GetMessageReactionsList
			{
				flags = (Messages_GetMessageReactionsList.Flags)((reaction != null ? 0x1 : 0) | (offset != null ? 0x2 : 0)),
				peer = peer,
				id = id,
				reaction = reaction,
				offset = offset,
				limit = limit,
			});

		/// <summary>Change the set of <a href="https://corefork.telegram.org/api/reactions">message reactions »</a> that can be used in a certain group, supergroup or channel		<para>See <a href="https://corefork.telegram.org/method/messages.setChatAvailableReactions"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.setChatAvailableReactions#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Group where to apply changes</param>
		/// <param name="available_reactions">Allowed reaction emojis</param>
		/// <param name="reactions_limit">This flag may be used to impose a custom limit of unique reactions (i.e. a customizable version of <a href="https://corefork.telegram.org/api/config#reactions-uniq-max">appConfig.reactions_uniq_max</a>); this field and the other info set by the method will then be available to users in <see cref="ChannelFull"/> and <see cref="ChatFull"/>. <br/>If this flag is not set, the previously configured <c>reactions_limit</c> will not be altered.</param>
		/// <param name="paid_enabled">If this flag is set and a <see cref="bool"/> is passed, the method will enable or disable <a href="https://corefork.telegram.org/api/reactions#paid-reactions">paid message reactions »</a>. If this flag is not set, the previously stored setting will not be changed.</param>
		public static Task<UpdatesBase> Messages_SetChatAvailableReactions(this Client client, InputPeer peer, ChatReactions available_reactions, int? reactions_limit = null, bool? paid_enabled = default)
			=> client.Invoke(new Messages_SetChatAvailableReactions
			{
				flags = (Messages_SetChatAvailableReactions.Flags)((reactions_limit != null ? 0x1 : 0) | (paid_enabled != default ? 0x2 : 0)),
				peer = peer,
				available_reactions = available_reactions,
				reactions_limit = reactions_limit ?? default,
				paid_enabled = paid_enabled ?? default,
			});

		/// <summary>Obtain available <a href="https://corefork.telegram.org/api/reactions">message reactions »</a>		<para>See <a href="https://corefork.telegram.org/method/messages.getAvailableReactions"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.availableReactionsNotModified">messages.availableReactionsNotModified</a></returns>
		public static Task<Messages_AvailableReactions> Messages_GetAvailableReactions(this Client client, int hash = default)
			=> client.Invoke(new Messages_GetAvailableReactions
			{
				hash = hash,
			});

		/// <summary>Change default emoji reaction to use in the quick reaction menu: the value is synced across devices and can be fetched using <see cref="Help_GetConfig">Help_GetConfig</see>.		<para>See <a href="https://corefork.telegram.org/method/messages.setDefaultReaction"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.setDefaultReaction#possible-errors">details</a>)</para></summary>
		/// <param name="reaction">New emoji reaction</param>
		public static Task<bool> Messages_SetDefaultReaction(this Client client, Reaction reaction)
			=> client.Invoke(new Messages_SetDefaultReaction
			{
				reaction = reaction,
			});

		/// <summary>Translate a given text.		<para>See <a href="https://corefork.telegram.org/method/messages.translateText"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,500 (<a href="https://corefork.telegram.org/method/messages.translateText#possible-errors">details</a>)</para></summary>
		/// <param name="peer">If the text is a chat message, the peer ID</param>
		/// <param name="id">A list of message IDs to translate</param>
		/// <param name="text">A list of styled messages to translate</param>
		/// <param name="to_lang">Two-letter ISO 639-1 language code of the language to which the message is translated</param>
		public static Task<Messages_TranslatedText> Messages_TranslateText(this Client client, string to_lang, InputPeer peer = null, int[] id = null, TextWithEntities[] text = null)
			=> client.Invoke(new Messages_TranslateText
			{
				flags = (Messages_TranslateText.Flags)((peer != null ? 0x1 : 0) | (id != null ? 0x1 : 0) | (text != null ? 0x2 : 0)),
				peer = peer,
				id = id,
				text = text,
				to_lang = to_lang,
			});

		/// <summary>Get unread reactions to messages you sent		<para>See <a href="https://corefork.telegram.org/method/messages.getUnreadReactions"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getUnreadReactions#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer</param>
		/// <param name="top_msg_id">If set, considers only reactions to messages within the specified <a href="https://corefork.telegram.org/api/forum#forum-topics">forum topic</a></param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="add_offset"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <param name="max_id">Only return reactions for messages up until this message ID</param>
		/// <param name="min_id">Only return reactions for messages starting from this message ID</param>
		public static Task<Messages_MessagesBase> Messages_GetUnreadReactions(this Client client, InputPeer peer, int offset_id = default, int add_offset = default, int limit = int.MaxValue, int max_id = default, int min_id = default, int? top_msg_id = null)
			=> client.Invoke(new Messages_GetUnreadReactions
			{
				flags = (Messages_GetUnreadReactions.Flags)(top_msg_id != null ? 0x1 : 0),
				peer = peer,
				top_msg_id = top_msg_id ?? default,
				offset_id = offset_id,
				add_offset = add_offset,
				limit = limit,
				max_id = max_id,
				min_id = min_id,
			});

		/// <summary>Mark <a href="https://corefork.telegram.org/api/reactions">message reactions »</a> as read		<para>See <a href="https://corefork.telegram.org/method/messages.readReactions"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.readReactions#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer</param>
		/// <param name="top_msg_id">Mark as read only reactions to messages within the specified <a href="https://corefork.telegram.org/api/forum#forum-topics">forum topic</a></param>
		public static Task<Messages_AffectedHistory> Messages_ReadReactions(this Client client, InputPeer peer, int? top_msg_id = null)
			=> client.InvokeAffected(new Messages_ReadReactions
			{
				flags = (Messages_ReadReactions.Flags)(top_msg_id != null ? 0x1 : 0),
				peer = peer,
				top_msg_id = top_msg_id ?? default,
			}, peer is InputPeerChannel ipc ? ipc.channel_id : 0);

		/// <summary>View and search recently sent media.<br/>This method does not support pagination.		<para>See <a href="https://corefork.telegram.org/method/messages.searchSentMedia"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.searchSentMedia#possible-errors">details</a>)</para></summary>
		/// <param name="q">Optional search query</param>
		/// <param name="filter">Message filter</param>
		/// <param name="limit">Maximum number of results to return (max 100).</param>
		public static Task<Messages_MessagesBase> Messages_SearchSentMedia(this Client client, string q, MessagesFilter filter = null, int limit = int.MaxValue)
			=> client.Invoke(new Messages_SearchSentMedia
			{
				q = q,
				filter = filter,
				limit = limit,
			});

		/// <summary>Returns installed attachment menu <a href="https://corefork.telegram.org/api/bots/attach">bot mini apps »</a>		<para>See <a href="https://corefork.telegram.org/method/messages.getAttachMenuBots"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/attachMenuBotsNotModified">attachMenuBotsNotModified</a></returns>
		public static Task<AttachMenuBots> Messages_GetAttachMenuBots(this Client client, long hash = default)
			=> client.Invoke(new Messages_GetAttachMenuBots
			{
				hash = hash,
			});

		/// <summary>Returns attachment menu entry for a <a href="https://corefork.telegram.org/api/bots/attach">bot mini app that can be launched from the attachment menu »</a>		<para>See <a href="https://corefork.telegram.org/method/messages.getAttachMenuBot"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getAttachMenuBot#possible-errors">details</a>)</para></summary>
		/// <param name="bot">Bot ID</param>
		public static Task<AttachMenuBotsBot> Messages_GetAttachMenuBot(this Client client, InputUserBase bot)
			=> client.Invoke(new Messages_GetAttachMenuBot
			{
				bot = bot,
			});

		/// <summary>Enable or disable <a href="https://corefork.telegram.org/api/bots/attach">web bot attachment menu »</a>		<para>See <a href="https://corefork.telegram.org/method/messages.toggleBotInAttachMenu"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.toggleBotInAttachMenu#possible-errors">details</a>)</para></summary>
		/// <param name="write_allowed">Whether the user authorizes the bot to write messages to them, if requested by <see cref="AttachMenuBot"/>.<c>request_write_access</c></param>
		/// <param name="bot">Bot ID</param>
		/// <param name="enabled">Toggle</param>
		public static Task<bool> Messages_ToggleBotInAttachMenu(this Client client, InputUserBase bot, bool enabled, bool write_allowed = false)
			=> client.Invoke(new Messages_ToggleBotInAttachMenu
			{
				flags = (Messages_ToggleBotInAttachMenu.Flags)(write_allowed ? 0x1 : 0),
				bot = bot,
				enabled = enabled,
			});

		/// <summary>Open a <a href="https://corefork.telegram.org/bots/webapps">bot mini app</a>, sending over user information after user confirmation.		<para>See <a href="https://corefork.telegram.org/method/messages.requestWebView"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.requestWebView#possible-errors">details</a>)</para></summary>
		/// <param name="from_bot_menu">Whether the webview was opened by clicking on the bot's <a href="https://corefork.telegram.org/api/bots/menu">menu button »</a>.</param>
		/// <param name="silent">Whether the inline message that will be sent by the bot on behalf of the user once the web app interaction is <see cref="Messages_SendWebViewResultMessage">Messages_SendWebViewResultMessage</see> should be sent silently (no notifications for the receivers).</param>
		/// <param name="compact">If set, requests to open the mini app in compact mode (as opposed to normal or fullscreen mode). Must be set if the <c>mode</c> parameter of the <a href="https://corefork.telegram.org/api/links#bot-attachment-or-side-menu-links">attachment menu deep link</a> is equal to <c>compact</c>.</param>
		/// <param name="fullscreen">If set, requests to open the mini app in fullscreen mode (as opposed to normal or compact mode). Must be set if the <c>mode</c> parameter of the <a href="https://corefork.telegram.org/api/links#bot-attachment-or-side-menu-links">attachment menu deep link</a> is equal to <c>fullscreen</c>.</param>
		/// <param name="peer">Dialog where the web app is being opened, and where the resulting message will be sent (see the <a href="https://corefork.telegram.org/api/bots/webapps">docs for more info »</a>).</param>
		/// <param name="bot">Bot that owns the <a href="https://corefork.telegram.org/api/bots/webapps">web app</a></param>
		/// <param name="url"><a href="https://corefork.telegram.org/api/bots/webapps">Web app URL</a></param>
		/// <param name="start_param">If the web app was opened from the attachment menu using a <a href="https://corefork.telegram.org/api/links#bot-attachment-or-side-menu-links">attachment menu deep link</a>, <c>start_param</c> should contain the <c>data</c> from the <c>startattach</c> parameter.</param>
		/// <param name="theme_params"><a href="https://corefork.telegram.org/api/bots/webapps#theme-parameters">Theme parameters »</a></param>
		/// <param name="platform">Short name of the application; 0-64 English letters, digits, and underscores</param>
		/// <param name="reply_to">If set, indicates that the inline message that will be sent by the bot on behalf of the user once the web app interaction is <see cref="Messages_SendWebViewResultMessage">Messages_SendWebViewResultMessage</see> should be sent in reply to the specified message or story.</param>
		/// <param name="send_as">Open the web app as the specified peer, sending the resulting the message as the specified peer.</param>
		public static Task<WebViewResult> Messages_RequestWebView(this Client client, InputPeer peer, InputUserBase bot, string platform, InputReplyTo reply_to = null, string url = null, DataJSON theme_params = null, string start_param = null, InputPeer send_as = null, bool from_bot_menu = false, bool silent = false, bool compact = false, bool fullscreen = false)
			=> client.Invoke(new Messages_RequestWebView
			{
				flags = (Messages_RequestWebView.Flags)((reply_to != null ? 0x1 : 0) | (url != null ? 0x2 : 0) | (theme_params != null ? 0x4 : 0) | (start_param != null ? 0x8 : 0) | (send_as != null ? 0x2000 : 0) | (from_bot_menu ? 0x10 : 0) | (silent ? 0x20 : 0) | (compact ? 0x80 : 0) | (fullscreen ? 0x100 : 0)),
				peer = peer,
				bot = bot,
				url = url,
				start_param = start_param,
				theme_params = theme_params,
				platform = platform,
				reply_to = reply_to,
				send_as = send_as,
			});

		/// <summary>Indicate to the server (from the user side) that the user is still using a web app.		<para>See <a href="https://corefork.telegram.org/method/messages.prolongWebView"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.prolongWebView#possible-errors">details</a>)</para></summary>
		/// <param name="silent">Whether the inline message that will be sent by the bot on behalf of the user once the web app interaction is <see cref="Messages_SendWebViewResultMessage">Messages_SendWebViewResultMessage</see> should be sent silently (no notifications for the receivers).</param>
		/// <param name="peer">Dialog where the web app was opened.</param>
		/// <param name="bot">Bot that owns the <a href="https://corefork.telegram.org/api/bots/webapps">web app</a></param>
		/// <param name="query_id">Web app interaction ID obtained from <see cref="Messages_RequestWebView">Messages_RequestWebView</see></param>
		/// <param name="reply_to">If set, indicates that the inline message that will be sent by the bot on behalf of the user once the web app interaction is <see cref="Messages_SendWebViewResultMessage">Messages_SendWebViewResultMessage</see> should be sent in reply to the specified message or story.</param>
		/// <param name="send_as">Open the web app as the specified peer</param>
		public static Task<bool> Messages_ProlongWebView(this Client client, InputPeer peer, InputUserBase bot, long query_id, InputReplyTo reply_to = null, InputPeer send_as = null, bool silent = false)
			=> client.Invoke(new Messages_ProlongWebView
			{
				flags = (Messages_ProlongWebView.Flags)((reply_to != null ? 0x1 : 0) | (send_as != null ? 0x2000 : 0) | (silent ? 0x20 : 0)),
				peer = peer,
				bot = bot,
				query_id = query_id,
				reply_to = reply_to,
				send_as = send_as,
			});

		/// <summary>Open a <a href="https://corefork.telegram.org/api/bots/webapps">bot mini app</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.requestSimpleWebView"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.requestSimpleWebView#possible-errors">details</a>)</para></summary>
		/// <param name="from_switch_webview">Whether the webapp was opened by clicking on the <c>switch_webview</c> button shown on top of the inline results list returned by <see cref="Messages_GetInlineBotResults">Messages_GetInlineBotResults</see>.</param>
		/// <param name="from_side_menu">Set this flag if opening the Mini App from the installed <a href="https://corefork.telegram.org/api/bots/attach">side menu entry »</a>.</param>
		/// <param name="compact">Deprecated.</param>
		/// <param name="fullscreen">Requests to open the app in fullscreen mode.</param>
		/// <param name="bot">Bot that owns the mini app</param>
		/// <param name="url">Web app URL, if opening from a keyboard button or inline result</param>
		/// <param name="start_param">Deprecated.</param>
		/// <param name="theme_params"><a href="https://corefork.telegram.org/api/bots/webapps#theme-parameters">Theme parameters »</a></param>
		/// <param name="platform">Short name of the application; 0-64 English letters, digits, and underscores</param>
		public static Task<WebViewResult> Messages_RequestSimpleWebView(this Client client, InputUserBase bot, string platform, DataJSON theme_params = null, string url = null, string start_param = null, bool from_switch_webview = false, bool from_side_menu = false, bool compact = false, bool fullscreen = false)
			=> client.Invoke(new Messages_RequestSimpleWebView
			{
				flags = (Messages_RequestSimpleWebView.Flags)((theme_params != null ? 0x1 : 0) | (url != null ? 0x8 : 0) | (start_param != null ? 0x10 : 0) | (from_switch_webview ? 0x2 : 0) | (from_side_menu ? 0x4 : 0) | (compact ? 0x80 : 0) | (fullscreen ? 0x100 : 0)),
				bot = bot,
				url = url,
				start_param = start_param,
				theme_params = theme_params,
				platform = platform,
			});

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://wiz0u.github.io/WTelegramClient/#terminology">Terminology</see> in the README to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Terminate webview interaction started with <see cref="Messages_RequestWebView">Messages_RequestWebView</see>, sending the specified message to the chat on behalf of the user.		<para>See <a href="https://corefork.telegram.org/method/messages.sendWebViewResultMessage"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.sendWebViewResultMessage#possible-errors">details</a>)</para></summary>
		/// <param name="bot_query_id">Webview interaction ID obtained from <see cref="Messages_RequestWebView">Messages_RequestWebView</see></param>
		/// <param name="result">Message to send</param>
		public static Task<WebViewMessageSent> Messages_SendWebViewResultMessage(this Client client, string bot_query_id, InputBotInlineResultBase result)
			=> client.Invoke(new Messages_SendWebViewResultMessage
			{
				bot_query_id = bot_query_id,
				result = result,
			});

		/// <summary>Used by the user to relay data from an opened <a href="https://corefork.telegram.org/api/bots/webapps">reply keyboard bot mini app</a> to the bot that owns it.		<para>See <a href="https://corefork.telegram.org/method/messages.sendWebViewData"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.sendWebViewData#possible-errors">details</a>)</para></summary>
		/// <param name="bot">Bot that owns the web app</param>
		/// <param name="random_id">Unique client message ID to prevent duplicate sending of the same event <para>You can use <see cref="WTelegram.Helpers.RandomLong"/></para></param>
		/// <param name="button_text">Text of the <see cref="KeyboardButtonSimpleWebView"/> that was pressed to open the web app.</param>
		/// <param name="data">Data to relay to the bot, obtained from a <a href="https://corefork.telegram.org/api/web-events#web-app-data-send"><c>web_app_data_send</c> JS event</a>.</param>
		public static Task<UpdatesBase> Messages_SendWebViewData(this Client client, InputUserBase bot, long random_id, string button_text, string data)
			=> client.Invoke(new Messages_SendWebViewData
			{
				bot = bot,
				random_id = random_id,
				button_text = button_text,
				data = data,
			});

		/// <summary><a href="https://corefork.telegram.org/api/transcribe">Transcribe voice message</a>		<para>See <a href="https://corefork.telegram.org/method/messages.transcribeAudio"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.transcribeAudio#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer ID where the voice message was sent</param>
		/// <param name="msg_id">Voice message ID</param>
		public static Task<Messages_TranscribedAudio> Messages_TranscribeAudio(this Client client, InputPeer peer, int msg_id)
			=> client.Invoke(new Messages_TranscribeAudio
			{
				peer = peer,
				msg_id = msg_id,
			});

		/// <summary>Rate <a href="https://corefork.telegram.org/api/transcribe">transcribed voice message</a>		<para>See <a href="https://corefork.telegram.org/method/messages.rateTranscribedAudio"/></para></summary>
		/// <param name="peer">Peer where the voice message was sent</param>
		/// <param name="msg_id">Message ID</param>
		/// <param name="transcription_id">Transcription ID</param>
		/// <param name="good">Whether the transcription was correct</param>
		public static Task<bool> Messages_RateTranscribedAudio(this Client client, InputPeer peer, int msg_id, long transcription_id, bool good)
			=> client.Invoke(new Messages_RateTranscribedAudio
			{
				peer = peer,
				msg_id = msg_id,
				transcription_id = transcription_id,
				good = good,
			});

		/// <summary>Fetch <a href="https://corefork.telegram.org/api/custom-emoji">custom emoji stickers »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.getCustomEmojiDocuments"/> [bots: ✓]</para></summary>
		/// <param name="document_id"><a href="https://corefork.telegram.org/api/custom-emoji">Custom emoji</a> IDs from a <see cref="MessageEntityCustomEmoji"/>.</param>
		public static Task<DocumentBase[]> Messages_GetCustomEmojiDocuments(this Client client, params long[] document_id)
			=> client.Invoke(new Messages_GetCustomEmojiDocuments
			{
				document_id = document_id,
			});

		/// <summary>Gets the list of currently installed <a href="https://corefork.telegram.org/api/custom-emoji">custom emoji stickersets</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.getEmojiStickers"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.allStickersNotModified">messages.allStickersNotModified</a></returns>
		public static Task<Messages_AllStickers> Messages_GetEmojiStickers(this Client client, long hash = default)
			=> client.Invoke(new Messages_GetEmojiStickers
			{
				hash = hash,
			});

		/// <summary>Gets featured custom emoji stickersets.		<para>See <a href="https://corefork.telegram.org/method/messages.getFeaturedEmojiStickers"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		public static Task<Messages_FeaturedStickersBase> Messages_GetFeaturedEmojiStickers(this Client client, long hash = default)
			=> client.Invoke(new Messages_GetFeaturedEmojiStickers
			{
				hash = hash,
			});

		/// <summary>Report a <a href="https://corefork.telegram.org/api/reactions">message reaction</a>		<para>See <a href="https://corefork.telegram.org/method/messages.reportReaction"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.reportReaction#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer where the message was sent</param>
		/// <param name="id">Message ID</param>
		/// <param name="reaction_peer">Peer that sent the reaction</param>
		public static Task<bool> Messages_ReportReaction(this Client client, InputPeer peer, int id, InputPeer reaction_peer)
			=> client.Invoke(new Messages_ReportReaction
			{
				peer = peer,
				id = id,
				reaction_peer = reaction_peer,
			});

		/// <summary>Got popular <a href="https://corefork.telegram.org/api/reactions">message reactions</a>		<para>See <a href="https://corefork.telegram.org/method/messages.getTopReactions"/></para></summary>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.reactionsNotModified">messages.reactionsNotModified</a></returns>
		public static Task<Messages_Reactions> Messages_GetTopReactions(this Client client, int limit = int.MaxValue, long hash = default)
			=> client.Invoke(new Messages_GetTopReactions
			{
				limit = limit,
				hash = hash,
			});

		/// <summary>Get recently used <a href="https://corefork.telegram.org/api/reactions">message reactions</a>		<para>See <a href="https://corefork.telegram.org/method/messages.getRecentReactions"/></para></summary>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.reactionsNotModified">messages.reactionsNotModified</a></returns>
		public static Task<Messages_Reactions> Messages_GetRecentReactions(this Client client, int limit = int.MaxValue, long hash = default)
			=> client.Invoke(new Messages_GetRecentReactions
			{
				limit = limit,
				hash = hash,
			});

		/// <summary>Clear recently used <a href="https://corefork.telegram.org/api/reactions">message reactions</a>		<para>See <a href="https://corefork.telegram.org/method/messages.clearRecentReactions"/></para></summary>
		public static Task<bool> Messages_ClearRecentReactions(this Client client)
			=> client.Invoke(new Messages_ClearRecentReactions
			{
			});

		/// <summary>Fetch updated information about <a href="https://corefork.telegram.org/api/paid-media">paid media, see here »</a> for the full flow.		<para>See <a href="https://corefork.telegram.org/method/messages.getExtendedMedia"/></para></summary>
		/// <param name="peer">Peer with visible paid media messages.</param>
		/// <param name="id">IDs of currently visible messages containing paid media.</param>
		public static Task<UpdatesBase> Messages_GetExtendedMedia(this Client client, InputPeer peer, params int[] id)
			=> client.Invoke(new Messages_GetExtendedMedia
			{
				peer = peer,
				id = id,
			});

		/// <summary>Changes the default value of the Time-To-Live setting, applied to all new chats.		<para>See <a href="https://corefork.telegram.org/method/messages.setDefaultHistoryTTL"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.setDefaultHistoryTTL#possible-errors">details</a>)</para></summary>
		/// <param name="period">The new default Time-To-Live of all messages sent in new chats, in seconds.</param>
		public static Task<bool> Messages_SetDefaultHistoryTTL(this Client client, int period)
			=> client.Invoke(new Messages_SetDefaultHistoryTTL
			{
				period = period,
			});

		/// <summary>Gets the default value of the Time-To-Live setting, applied to all new chats.		<para>See <a href="https://corefork.telegram.org/method/messages.getDefaultHistoryTTL"/></para></summary>
		public static Task<DefaultHistoryTTL> Messages_GetDefaultHistoryTTL(this Client client)
			=> client.Invoke(new Messages_GetDefaultHistoryTTL
			{
			});

		/// <summary>Send one or more chosen peers, as requested by a <see cref="KeyboardButtonRequestPeer"/> button.		<para>See <a href="https://corefork.telegram.org/method/messages.sendBotRequestedPeer"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.sendBotRequestedPeer#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The bot that sent the <see cref="KeyboardButtonRequestPeer"/> button.</param>
		/// <param name="msg_id">ID of the message that contained the reply keyboard with the <see cref="KeyboardButtonRequestPeer"/> button.</param>
		/// <param name="button_id">The <c>button_id</c> field from the <see cref="KeyboardButtonRequestPeer"/>.</param>
		/// <param name="requested_peers">The chosen peers.</param>
		public static Task<UpdatesBase> Messages_SendBotRequestedPeer(this Client client, InputPeer peer, int msg_id, int button_id, params InputPeer[] requested_peers)
			=> client.Invoke(new Messages_SendBotRequestedPeer
			{
				peer = peer,
				msg_id = msg_id,
				button_id = button_id,
				requested_peers = requested_peers,
			});

		/// <summary>Represents a list of <a href="https://corefork.telegram.org/api/emoji-categories">emoji categories</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.getEmojiGroups"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.emojiGroupsNotModified">messages.emojiGroupsNotModified</a></returns>
		public static Task<Messages_EmojiGroups> Messages_GetEmojiGroups(this Client client, int hash = default)
			=> client.Invoke(new Messages_GetEmojiGroups
			{
				hash = hash,
			});

		/// <summary>Represents a list of <a href="https://corefork.telegram.org/api/emoji-categories">emoji categories</a>, to be used when selecting custom emojis to set as <a href="https://corefork.telegram.org/api">custom emoji status</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.getEmojiStatusGroups"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.emojiGroupsNotModified">messages.emojiGroupsNotModified</a></returns>
		public static Task<Messages_EmojiGroups> Messages_GetEmojiStatusGroups(this Client client, int hash = default)
			=> client.Invoke(new Messages_GetEmojiStatusGroups
			{
				hash = hash,
			});

		/// <summary>Represents a list of <a href="https://corefork.telegram.org/api/emoji-categories">emoji categories</a>, to be used when selecting custom emojis to set as <a href="https://corefork.telegram.org/api/files#sticker-profile-pictures">profile picture</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.getEmojiProfilePhotoGroups"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.emojiGroupsNotModified">messages.emojiGroupsNotModified</a></returns>
		public static Task<Messages_EmojiGroups> Messages_GetEmojiProfilePhotoGroups(this Client client, int hash = default)
			=> client.Invoke(new Messages_GetEmojiProfilePhotoGroups
			{
				hash = hash,
			});

		/// <summary>Look for <a href="https://corefork.telegram.org/api/custom-emoji">custom emojis</a> associated to a UTF8 emoji		<para>See <a href="https://corefork.telegram.org/method/messages.searchCustomEmoji"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.searchCustomEmoji#possible-errors">details</a>)</para></summary>
		/// <param name="emoticon">The emoji</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/emojiListNotModified">emojiListNotModified</a></returns>
		public static Task<EmojiList> Messages_SearchCustomEmoji(this Client client, string emoticon, long hash = default)
			=> client.Invoke(new Messages_SearchCustomEmoji
			{
				emoticon = emoticon,
				hash = hash,
			});

		/// <summary>Show or hide the <a href="https://corefork.telegram.org/api/translation">real-time chat translation popup</a> for a certain chat		<para>See <a href="https://corefork.telegram.org/method/messages.togglePeerTranslations"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.togglePeerTranslations#possible-errors">details</a>)</para></summary>
		/// <param name="disabled">Whether to disable or enable the real-time chat translation popup</param>
		/// <param name="peer">The peer</param>
		public static Task<bool> Messages_TogglePeerTranslations(this Client client, InputPeer peer, bool disabled = false)
			=> client.Invoke(new Messages_TogglePeerTranslations
			{
				flags = (Messages_TogglePeerTranslations.Flags)(disabled ? 0x1 : 0),
				peer = peer,
			});

		/// <summary>Obtain information about a <a href="https://corefork.telegram.org/api/bots/webapps#direct-link-mini-apps">direct link Mini App</a>		<para>See <a href="https://corefork.telegram.org/method/messages.getBotApp"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getBotApp#possible-errors">details</a>)</para></summary>
		/// <param name="app">Bot app information obtained from a <a href="https://corefork.telegram.org/api/links#direct-mini-app-links">Direct Mini App deep link »</a>.</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a></param>
		public static Task<Messages_BotApp> Messages_GetBotApp(this Client client, InputBotApp app, long hash = default)
			=> client.Invoke(new Messages_GetBotApp
			{
				app = app,
				hash = hash,
			});

		/// <summary>Open a <a href="https://corefork.telegram.org/bots/webapps">bot mini app</a> from a <a href="https://corefork.telegram.org/api/links#direct-mini-app-links">direct Mini App deep link</a>, sending over user information after user confirmation.		<para>See <a href="https://corefork.telegram.org/method/messages.requestAppWebView"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.requestAppWebView#possible-errors">details</a>)</para></summary>
		/// <param name="write_allowed">Set this flag if the bot is asking permission to send messages to the user as specified in the <a href="https://corefork.telegram.org/api/links#direct-mini-app-links">direct Mini App deep link</a> docs, and the user agreed.</param>
		/// <param name="compact">If set, requests to open the mini app in compact mode (as opposed to normal or fullscreen mode). Must be set if the <c>mode</c> parameter of the <a href="https://corefork.telegram.org/api/links#direct-mini-app-links">direct Mini App deep link</a> is equal to <c>compact</c>.</param>
		/// <param name="fullscreen">If set, requests to open the mini app in fullscreen mode (as opposed to compact or normal mode). Must be set if the <c>mode</c> parameter of the <a href="https://corefork.telegram.org/api/links#direct-mini-app-links">direct Mini App deep link</a> is equal to <c>fullscreen</c>.</param>
		/// <param name="peer">If the client has clicked on the link in a Telegram chat, pass the chat's peer information; otherwise pass the bot's peer information, instead.</param>
		/// <param name="app">The app obtained by invoking <see cref="Messages_GetBotApp">Messages_GetBotApp</see> as specified in the <a href="https://corefork.telegram.org/api/links#direct-mini-app-links">direct Mini App deep link</a> docs.</param>
		/// <param name="start_param">If the <c>startapp</c> query string parameter is present in the <a href="https://corefork.telegram.org/api/links#direct-mini-app-links">direct Mini App deep link</a>, pass it to <c>start_param</c>.</param>
		/// <param name="theme_params"><a href="https://corefork.telegram.org/api/bots/webapps#theme-parameters">Theme parameters »</a></param>
		/// <param name="platform">Short name of the application; 0-64 English letters, digits, and underscores</param>
		public static Task<WebViewResult> Messages_RequestAppWebView(this Client client, InputPeer peer, InputBotApp app, string platform, string start_param = null, DataJSON theme_params = null, bool write_allowed = false, bool compact = false, bool fullscreen = false)
			=> client.Invoke(new Messages_RequestAppWebView
			{
				flags = (Messages_RequestAppWebView.Flags)((start_param != null ? 0x2 : 0) | (theme_params != null ? 0x4 : 0) | (write_allowed ? 0x1 : 0) | (compact ? 0x80 : 0) | (fullscreen ? 0x100 : 0)),
				peer = peer,
				app = app,
				start_param = start_param,
				theme_params = theme_params,
				platform = platform,
			});

		/// <summary>Set a custom <a href="https://corefork.telegram.org/api/wallpapers">wallpaper »</a> in a specific private chat with another user.		<para>See <a href="https://corefork.telegram.org/method/messages.setChatWallPaper"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.setChatWallPaper#possible-errors">details</a>)</para></summary>
		/// <param name="for_both">Only for <a href="https://corefork.telegram.org/api/premium">Premium</a> users, sets the specified wallpaper for both users of the chat, without requiring confirmation from the other user.</param>
		/// <param name="revert">If we don't like the new wallpaper the other user of the chat has chosen for us using the <c>for_both</c> flag, we can re-set our previous wallpaper just on our side using this flag.</param>
		/// <param name="peer">The private chat where the wallpaper will be set</param>
		/// <param name="wallpaper">The <a href="https://corefork.telegram.org/api/wallpapers">wallpaper »</a>, obtained as described in the <a href="https://corefork.telegram.org/api/wallpapers#uploading-wallpapers">wallpaper documentation »</a>; must <strong>not</strong> be provided when installing a wallpaper obtained from a <see cref="MessageActionSetChatWallPaper"/> service message (<c>id</c> must be provided, instead).</param>
		/// <param name="settings">Wallpaper settings, obtained as described in the <a href="https://corefork.telegram.org/api/wallpapers#uploading-wallpapers">wallpaper documentation »</a> or from <see cref="MessageActionSetChatWallPaper"/>.<c>wallpaper</c>.<c>settings</c>.</param>
		/// <param name="id">If the wallpaper was obtained from a <see cref="MessageActionSetChatWallPaper"/> service message, must contain the ID of that message.</param>
		public static Task<UpdatesBase> Messages_SetChatWallPaper(this Client client, InputPeer peer, InputWallPaperBase wallpaper = null, int? id = null, WallPaperSettings settings = null, bool for_both = false, bool revert = false)
			=> client.Invoke(new Messages_SetChatWallPaper
			{
				flags = (Messages_SetChatWallPaper.Flags)((wallpaper != null ? 0x1 : 0) | (id != null ? 0x2 : 0) | (settings != null ? 0x4 : 0) | (for_both ? 0x8 : 0) | (revert ? 0x10 : 0)),
				peer = peer,
				wallpaper = wallpaper,
				settings = settings,
				id = id ?? default,
			});

		/// <summary>Search for <a href="https://corefork.telegram.org/api/custom-emoji">custom emoji stickersets »</a>		<para>See <a href="https://corefork.telegram.org/method/messages.searchEmojiStickerSets"/></para></summary>
		/// <param name="exclude_featured">Exclude featured stickersets from results</param>
		/// <param name="q">Query string</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.foundStickerSetsNotModified">messages.foundStickerSetsNotModified</a></returns>
		public static Task<Messages_FoundStickerSets> Messages_SearchEmojiStickerSets(this Client client, string q, long hash = default, bool exclude_featured = false)
			=> client.Invoke(new Messages_SearchEmojiStickerSets
			{
				flags = (Messages_SearchEmojiStickerSets.Flags)(exclude_featured ? 0x1 : 0),
				q = q,
				hash = hash,
			});

		/// <summary>Returns the current saved dialog list, see <a href="https://corefork.telegram.org/api/saved-messages">here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/messages.getSavedDialogs"/></para></summary>
		/// <param name="exclude_pinned">Exclude pinned dialogs</param>
		/// <param name="offset_date"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a> (<c>top_message</c> ID used for pagination)</param>
		/// <param name="offset_peer"><a href="https://corefork.telegram.org/api/offsets">Offset peer for pagination</a></param>
		/// <param name="limit">Number of list elements to be returned</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a></param>
		public static Task<Messages_SavedDialogsBase> Messages_GetSavedDialogs(this Client client, DateTime offset_date = default, int offset_id = default, InputPeer offset_peer = null, int limit = int.MaxValue, long hash = default, bool exclude_pinned = false)
			=> client.Invoke(new Messages_GetSavedDialogs
			{
				flags = (Messages_GetSavedDialogs.Flags)(exclude_pinned ? 0x1 : 0),
				offset_date = offset_date,
				offset_id = offset_id,
				offset_peer = offset_peer,
				limit = limit,
				hash = hash,
			});

		/// <summary>Returns <a href="https://corefork.telegram.org/api/saved-messages">saved messages »</a> forwarded from a specific peer		<para>See <a href="https://corefork.telegram.org/method/messages.getSavedHistory"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getSavedHistory#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Target peer</param>
		/// <param name="offset_id">Only return messages starting from the specified message ID</param>
		/// <param name="offset_date">Only return messages sent before the specified date</param>
		/// <param name="add_offset">Number of list elements to be skipped, negative values are also accepted.</param>
		/// <param name="limit">Number of results to return</param>
		/// <param name="max_id">If a positive value was transferred, the method will return only messages with IDs less than <strong>max_id</strong></param>
		/// <param name="min_id">If a positive value was transferred, the method will return only messages with IDs more than <strong>min_id</strong></param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets">Result hash</a></param>
		public static Task<Messages_MessagesBase> Messages_GetSavedHistory(this Client client, InputPeer peer, int offset_id = default, DateTime offset_date = default, int add_offset = default, int limit = int.MaxValue, int max_id = default, int min_id = default, long hash = default)
			=> client.Invoke(new Messages_GetSavedHistory
			{
				peer = peer,
				offset_id = offset_id,
				offset_date = offset_date,
				add_offset = add_offset,
				limit = limit,
				max_id = max_id,
				min_id = min_id,
				hash = hash,
			});

		/// <summary>Deletes messages forwarded from a specific peer to <a href="https://corefork.telegram.org/api/saved-messages">saved messages »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.deleteSavedHistory"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.deleteSavedHistory#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer, whose messages will be deleted from <a href="https://corefork.telegram.org/api/saved-messages">saved messages »</a></param>
		/// <param name="max_id">Maximum ID of message to delete</param>
		/// <param name="min_date">Delete all messages newer than this UNIX timestamp</param>
		/// <param name="max_date">Delete all messages older than this UNIX timestamp</param>
		public static Task<Messages_AffectedHistory> Messages_DeleteSavedHistory(this Client client, InputPeer peer, int max_id = default, DateTime? min_date = null, DateTime? max_date = null)
			=> client.InvokeAffected(new Messages_DeleteSavedHistory
			{
				flags = (Messages_DeleteSavedHistory.Flags)((min_date != null ? 0x4 : 0) | (max_date != null ? 0x8 : 0)),
				peer = peer,
				max_id = max_id,
				min_date = min_date ?? default,
				max_date = max_date ?? default,
			}, peer is InputPeerChannel ipc ? ipc.channel_id : 0);

		/// <summary>Get pinned <a href="https://corefork.telegram.org/api/saved-messages">saved dialogs, see here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/messages.getPinnedSavedDialogs"/></para></summary>
		public static Task<Messages_SavedDialogsBase> Messages_GetPinnedSavedDialogs(this Client client)
			=> client.Invoke(new Messages_GetPinnedSavedDialogs
			{
			});

		/// <summary>Pin or unpin a <a href="https://corefork.telegram.org/api/saved-messages">saved message dialog »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.toggleSavedDialogPin"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.toggleSavedDialogPin#possible-errors">details</a>)</para></summary>
		/// <param name="pinned">Whether to pin or unpin the dialog</param>
		/// <param name="peer">The dialog to pin</param>
		public static Task<bool> Messages_ToggleSavedDialogPin(this Client client, InputDialogPeerBase peer, bool pinned = false)
			=> client.Invoke(new Messages_ToggleSavedDialogPin
			{
				flags = (Messages_ToggleSavedDialogPin.Flags)(pinned ? 0x1 : 0),
				peer = peer,
			});

		/// <summary>Reorder pinned <a href="https://corefork.telegram.org/api/saved-messages">saved message dialogs »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.reorderPinnedSavedDialogs"/></para></summary>
		/// <param name="force">If set, dialogs pinned server-side but not present in the <c>order</c> field will be unpinned.</param>
		/// <param name="order">New dialog order</param>
		public static Task<bool> Messages_ReorderPinnedSavedDialogs(this Client client, InputDialogPeerBase[] order, bool force = false)
			=> client.Invoke(new Messages_ReorderPinnedSavedDialogs
			{
				flags = (Messages_ReorderPinnedSavedDialogs.Flags)(force ? 0x1 : 0),
				order = order,
			});

		/// <summary>Fetch the full list of <a href="https://corefork.telegram.org/api/saved-messages#tags">saved message tags</a> created by the user.		<para>See <a href="https://corefork.telegram.org/method/messages.getSavedReactionTags"/></para></summary>
		/// <param name="peer">If set, returns tags only used in the specified <a href="https://corefork.telegram.org/api/saved-messages#saved-message-dialogs">saved message dialog</a>.</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.savedReactionTagsNotModified">messages.savedReactionTagsNotModified</a></returns>
		public static Task<Messages_SavedReactionTags> Messages_GetSavedReactionTags(this Client client, long hash = default, InputPeer peer = null)
			=> client.Invoke(new Messages_GetSavedReactionTags
			{
				flags = (Messages_GetSavedReactionTags.Flags)(peer != null ? 0x1 : 0),
				peer = peer,
				hash = hash,
			});

		/// <summary>Update the <a href="https://corefork.telegram.org/api/saved-messages#tags">description of a saved message tag »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.updateSavedReactionTag"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.updateSavedReactionTag#possible-errors">details</a>)</para></summary>
		/// <param name="reaction"><a href="https://corefork.telegram.org/api/reactions">Reaction</a> associated to the tag</param>
		/// <param name="title">Tag description, max 12 UTF-8 characters; to remove the description call the method without setting this flag.</param>
		public static Task<bool> Messages_UpdateSavedReactionTag(this Client client, Reaction reaction, string title = null)
			=> client.Invoke(new Messages_UpdateSavedReactionTag
			{
				flags = (Messages_UpdateSavedReactionTag.Flags)(title != null ? 0x1 : 0),
				reaction = reaction,
				title = title,
			});

		/// <summary>Fetch a default recommended list of <a href="https://corefork.telegram.org/api/saved-messages#tags">saved message tag reactions</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.getDefaultTagReactions"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.reactionsNotModified">messages.reactionsNotModified</a></returns>
		public static Task<Messages_Reactions> Messages_GetDefaultTagReactions(this Client client, long hash = default)
			=> client.Invoke(new Messages_GetDefaultTagReactions
			{
				hash = hash,
			});

		/// <summary>Get the exact read date of one of our messages, sent to a private chat with another user.		<para>See <a href="https://corefork.telegram.org/method/messages.getOutboxReadDate"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.getOutboxReadDate#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The user to whom we sent the message.</param>
		/// <param name="msg_id">The message ID.</param>
		public static Task<OutboxReadDate> Messages_GetOutboxReadDate(this Client client, InputPeer peer, int msg_id)
			=> client.Invoke(new Messages_GetOutboxReadDate
			{
				peer = peer,
				msg_id = msg_id,
			});

		/// <summary>Fetch basic info about all existing <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">quick reply shortcuts</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.getQuickReplies"/></para></summary>
		/// <param name="hash">Hash for pagination, generated as specified <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">here »</a> (not the usual algorithm used for hash generation.)</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.quickRepliesNotModified">messages.quickRepliesNotModified</a></returns>
		public static Task<Messages_QuickReplies> Messages_GetQuickReplies(this Client client, long hash = default)
			=> client.Invoke(new Messages_GetQuickReplies
			{
				hash = hash,
			});

		/// <summary>Reorder <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">quick reply shortcuts</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.reorderQuickReplies"/></para>		<para>Possible <see cref="RpcException"/> codes: 403 (<a href="https://corefork.telegram.org/method/messages.reorderQuickReplies#possible-errors">details</a>)</para></summary>
		/// <param name="order">IDs of all created <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">quick reply shortcuts</a>, in the desired order.</param>
		public static Task<bool> Messages_ReorderQuickReplies(this Client client, params int[] order)
			=> client.Invoke(new Messages_ReorderQuickReplies
			{
				order = order,
			});

		/// <summary>Before offering the user the choice to add a message to a <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">quick reply shortcut</a>, to make sure that none of the limits specified <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">here »</a> were reached.		<para>See <a href="https://corefork.telegram.org/method/messages.checkQuickReplyShortcut"/></para>		<para>Possible <see cref="RpcException"/> codes: 403 (<a href="https://corefork.telegram.org/method/messages.checkQuickReplyShortcut#possible-errors">details</a>)</para></summary>
		/// <param name="shortcut">Shorcut name (not ID!).</param>
		public static Task<bool> Messages_CheckQuickReplyShortcut(this Client client, string shortcut)
			=> client.Invoke(new Messages_CheckQuickReplyShortcut
			{
				shortcut = shortcut,
			});

		/// <summary>Rename a <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">quick reply shortcut</a>.<br/>This will emit an <see cref="UpdateQuickReplies"/> update to other logged-in sessions.		<para>See <a href="https://corefork.telegram.org/method/messages.editQuickReplyShortcut"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.editQuickReplyShortcut#possible-errors">details</a>)</para></summary>
		/// <param name="shortcut_id"><a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">Shortcut ID</a>.</param>
		/// <param name="shortcut">New shortcut name.</param>
		public static Task<bool> Messages_EditQuickReplyShortcut(this Client client, int shortcut_id, string shortcut)
			=> client.Invoke(new Messages_EditQuickReplyShortcut
			{
				shortcut_id = shortcut_id,
				shortcut = shortcut,
			});

		/// <summary>Completely delete a <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">quick reply shortcut</a>.<br/>This will also emit an <see cref="UpdateDeleteQuickReply"/> update to other logged-in sessions (and <em>no</em> <see cref="UpdateDeleteQuickReplyMessages"/> updates, even if all the messages in the shortcuts are also deleted by this method).		<para>See <a href="https://corefork.telegram.org/method/messages.deleteQuickReplyShortcut"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.deleteQuickReplyShortcut#possible-errors">details</a>)</para></summary>
		/// <param name="shortcut_id"><a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">Shortcut ID</a></param>
		public static Task<bool> Messages_DeleteQuickReplyShortcut(this Client client, int shortcut_id)
			=> client.Invoke(new Messages_DeleteQuickReplyShortcut
			{
				shortcut_id = shortcut_id,
			});

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://wiz0u.github.io/WTelegramClient/#terminology">Terminology</see> in the README to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Fetch (a subset or all) messages in a <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">quick reply shortcut »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.getQuickReplyMessages"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getQuickReplyMessages#possible-errors">details</a>)</para></summary>
		/// <param name="shortcut_id">Quick reply shortcut ID.</param>
		/// <param name="id">IDs of the messages to fetch, if empty fetches all of them.</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a></param>
		public static Task<Messages_MessagesBase> Messages_GetQuickReplyMessages(this Client client, int shortcut_id, long hash = default, int[] id = null)
			=> client.Invoke(new Messages_GetQuickReplyMessages
			{
				flags = (Messages_GetQuickReplyMessages.Flags)(id != null ? 0x1 : 0),
				shortcut_id = shortcut_id,
				id = id,
				hash = hash,
			});

		/// <summary>Send a <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">quick reply shortcut »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.sendQuickReplyMessages"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.sendQuickReplyMessages#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The peer where to send the shortcut (users only, for now).</param>
		/// <param name="shortcut_id">The ID of the quick reply shortcut to send.</param>
		/// <param name="id">Specify a subset of messages from the shortcut to send; if empty, defaults to all of them.</param>
		/// <param name="random_id">Unique client IDs required to prevent message resending, one for each message we're sending, may be empty (but not recommended). <para>You can use <see cref="WTelegram.Helpers.RandomLong"/></para></param>
		public static Task<UpdatesBase> Messages_SendQuickReplyMessages(this Client client, InputPeer peer, int shortcut_id, int[] id, params long[] random_id)
			=> client.Invoke(new Messages_SendQuickReplyMessages
			{
				peer = peer,
				shortcut_id = shortcut_id,
				id = id,
				random_id = random_id,
			});

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://wiz0u.github.io/WTelegramClient/#terminology">Terminology</see> in the README to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Delete one or more messages from a <a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">quick reply shortcut</a>. This will also emit an <see cref="UpdateDeleteQuickReplyMessages"/> update.		<para>See <a href="https://corefork.telegram.org/method/messages.deleteQuickReplyMessages"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.deleteQuickReplyMessages#possible-errors">details</a>)</para></summary>
		/// <param name="shortcut_id"><a href="https://corefork.telegram.org/api/business#quick-reply-shortcuts">Shortcut ID</a>.</param>
		/// <param name="id">IDs of shortcut messages to delete.</param>
		public static Task<UpdatesBase> Messages_DeleteQuickReplyMessages(this Client client, int shortcut_id, params int[] id)
			=> client.Invoke(new Messages_DeleteQuickReplyMessages
			{
				shortcut_id = shortcut_id,
				id = id,
			});

		/// <summary>Enable or disable <a href="https://corefork.telegram.org/api/folders#folder-tags">folder tags »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.toggleDialogFilterTags"/></para>		<para>Possible <see cref="RpcException"/> codes: 403 (<a href="https://corefork.telegram.org/method/messages.toggleDialogFilterTags#possible-errors">details</a>)</para></summary>
		/// <param name="enabled">Enable or disable folder tags.</param>
		public static Task<bool> Messages_ToggleDialogFilterTags(this Client client, bool enabled)
			=> client.Invoke(new Messages_ToggleDialogFilterTags
			{
				enabled = enabled,
			});

		/// <summary>Fetch all <a href="https://corefork.telegram.org/api/stickers">stickersets »</a> owned by the current user.		<para>See <a href="https://corefork.telegram.org/method/messages.getMyStickers"/></para></summary>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Messages_MyStickers> Messages_GetMyStickers(this Client client, long offset_id = default, int limit = int.MaxValue)
			=> client.Invoke(new Messages_GetMyStickers
			{
				offset_id = offset_id,
				limit = limit,
			});

		/// <summary>Represents a list of <a href="https://corefork.telegram.org/api/emoji-categories">emoji categories</a>, to be used when choosing a sticker.		<para>See <a href="https://corefork.telegram.org/method/messages.getEmojiStickerGroups"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.emojiGroupsNotModified">messages.emojiGroupsNotModified</a></returns>
		public static Task<Messages_EmojiGroups> Messages_GetEmojiStickerGroups(this Client client, int hash = default)
			=> client.Invoke(new Messages_GetEmojiStickerGroups
			{
				hash = hash,
			});

		/// <summary>Fetch the full list of usable <a href="https://corefork.telegram.org/api/effects">animated message effects »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.getAvailableEffects"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.availableEffectsNotModified">messages.availableEffectsNotModified</a></returns>
		public static Task<Messages_AvailableEffects> Messages_GetAvailableEffects(this Client client, int hash = default)
			=> client.Invoke(new Messages_GetAvailableEffects
			{
				hash = hash,
			});

		/// <summary>Edit/create a <a href="https://corefork.telegram.org/api/factcheck">fact-check</a> on a message.		<para>See <a href="https://corefork.telegram.org/method/messages.editFactCheck"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.editFactCheck#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer where the message was sent</param>
		/// <param name="msg_id">Message ID</param>
		/// <param name="text">Fact-check (maximum UTF-8 length specified in <a href="https://corefork.telegram.org/api/config#factcheck-length-limit">appConfig.factcheck_length_limit</a>).</param>
		public static Task<UpdatesBase> Messages_EditFactCheck(this Client client, InputPeer peer, int msg_id, TextWithEntities text)
			=> client.Invoke(new Messages_EditFactCheck
			{
				peer = peer,
				msg_id = msg_id,
				text = text,
			});

		/// <summary>Delete a <a href="https://corefork.telegram.org/api/factcheck">fact-check</a> from a message.		<para>See <a href="https://corefork.telegram.org/method/messages.deleteFactCheck"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.deleteFactCheck#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer where the message was sent.</param>
		/// <param name="msg_id">Message ID</param>
		public static Task<UpdatesBase> Messages_DeleteFactCheck(this Client client, InputPeer peer, int msg_id)
			=> client.Invoke(new Messages_DeleteFactCheck
			{
				peer = peer,
				msg_id = msg_id,
			});

		/// <summary>Fetch one or more <a href="https://corefork.telegram.org/api/factcheck">factchecks, see here »</a> for the full flow.		<para>See <a href="https://corefork.telegram.org/method/messages.getFactCheck"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getFactCheck#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer where the messages were sent.</param>
		/// <param name="msg_id">Messages that have associated <see cref="FactCheck"/>s with the <c>need_check</c> flag set.</param>
		public static Task<FactCheck[]> Messages_GetFactCheck(this Client client, InputPeer peer, params int[] msg_id)
			=> client.Invoke(new Messages_GetFactCheck
			{
				peer = peer,
				msg_id = msg_id,
			});

		/// <summary>Open a <a href="https://corefork.telegram.org/api/bots/webapps#main-mini-apps">Main Mini App</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.requestMainWebView"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.requestMainWebView#possible-errors">details</a>)</para></summary>
		/// <param name="compact">If set, requests to open the mini app in compact mode (as opposed to normal or fullscreen mode). Must be set if the <c>mode</c> parameter of the <a href="https://corefork.telegram.org/api/links#main-mini-app-links">Main Mini App link</a> is equal to <c>compact</c>.</param>
		/// <param name="fullscreen">If set, requests to open the mini app in fullscreen mode (as opposed to compact or normal mode). Must be set if the <c>mode</c> parameter of the <a href="https://corefork.telegram.org/api/links#main-mini-app-links">Main Mini App link</a> is equal to <c>fullscreen</c>.</param>
		/// <param name="peer">Currently open chat, may be <see langword="null"/> if no chat is currently open.</param>
		/// <param name="bot">Bot that owns the main mini app.</param>
		/// <param name="start_param">Start parameter, if opening from a <a href="https://corefork.telegram.org/api/links#main-mini-app-links">Main Mini App link »</a>.</param>
		/// <param name="theme_params"><a href="https://corefork.telegram.org/api/bots/webapps#theme-parameters">Theme parameters »</a></param>
		/// <param name="platform">Short name of the application; 0-64 English letters, digits, and underscores</param>
		public static Task<WebViewResult> Messages_RequestMainWebView(this Client client, InputPeer peer, InputUserBase bot, string platform, DataJSON theme_params = null, string start_param = null, bool compact = false, bool fullscreen = false)
			=> client.Invoke(new Messages_RequestMainWebView
			{
				flags = (Messages_RequestMainWebView.Flags)((theme_params != null ? 0x1 : 0) | (start_param != null ? 0x2 : 0) | (compact ? 0x80 : 0) | (fullscreen ? 0x100 : 0)),
				peer = peer,
				bot = bot,
				start_param = start_param,
				theme_params = theme_params,
				platform = platform,
			});

		/// <summary>Sends one or more <a href="https://corefork.telegram.org/api/reactions#paid-reactions">paid Telegram Star reactions »</a>, transferring <a href="https://corefork.telegram.org/api/stars">Telegram Stars »</a> to a channel&#39;s balance.		<para>See <a href="https://corefork.telegram.org/method/messages.sendPaidReaction"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.sendPaidReaction#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The channel</param>
		/// <param name="msg_id">The message to react to</param>
		/// <param name="count">The number of <a href="https://corefork.telegram.org/api/stars">stars</a> to send (each will increment the reaction counter by one).</param>
		/// <param name="random_id">Unique client message ID required to prevent message resending <para>You can use <see cref="WTelegram.Helpers.RandomLong"/></para></param>
		/// <param name="private_">Each post with star reactions has a leaderboard with the top senders, but users can opt out of appearing there if they prefer more privacy.<br/>If the user explicitly chose to make their paid reaction(s) private, pass <see langword="true"/> to <see cref="Messages_SendPaidReaction">Messages_SendPaidReaction</see>.<c>private</c>.<br/>If the user explicitly chose to make their paid reaction(s) not private, pass <see langword="true"/> to <see cref="Messages_SendPaidReaction">Messages_SendPaidReaction</see>.<c>private</c>.<br/>If the user did not make any explicit choice about the privacy of their paid reaction(s) (i.e. when reacting by clicking on an existing star reaction on a message), do not populate the <see cref="Messages_SendPaidReaction">Messages_SendPaidReaction</see>.<c>private</c> flag.</param>
		public static Task<UpdatesBase> Messages_SendPaidReaction(this Client client, InputPeer peer, int msg_id, int count, long random_id, PaidReactionPrivacy private_ = null)
			=> client.Invoke(new Messages_SendPaidReaction
			{
				flags = (Messages_SendPaidReaction.Flags)(private_ != null ? 0x1 : 0),
				peer = peer,
				msg_id = msg_id,
				count = count,
				random_id = random_id,
				private_ = private_,
			});

		/// <summary>Changes the privacy of already sent <a href="https://corefork.telegram.org/api/reactions#paid-reactions">paid reactions</a> on a specific message.		<para>See <a href="https://corefork.telegram.org/method/messages.togglePaidReactionPrivacy"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.togglePaidReactionPrivacy#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The channel</param>
		/// <param name="msg_id">The ID of the message to which we sent the paid reactions</param>
		/// <param name="private_">If true, makes the current anonymous in the top sender leaderboard for this message; otherwise, does the opposite.</param>
		public static Task<bool> Messages_TogglePaidReactionPrivacy(this Client client, InputPeer peer, int msg_id, PaidReactionPrivacy private_)
			=> client.Invoke(new Messages_TogglePaidReactionPrivacy
			{
				peer = peer,
				msg_id = msg_id,
				private_ = private_,
			});

		/// <summary>Fetches an <see cref="UpdatePaidReactionPrivacy"/> update with the current <a href="https://corefork.telegram.org/api/reactions#paid-reactions">default paid reaction privacy, see here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/messages.getPaidReactionPrivacy"/></para></summary>
		public static Task<UpdatesBase> Messages_GetPaidReactionPrivacy(this Client client)
			=> client.Invoke(new Messages_GetPaidReactionPrivacy
			{
			});

		/// <summary>Mark a specific <a href="https://corefork.telegram.org/api/sponsored-messages">sponsored message »</a> as read		<para>See <a href="https://corefork.telegram.org/method/messages.viewSponsoredMessage"/></para></summary>
		/// <param name="peer">The channel/bot where the ad is located</param>
		/// <param name="random_id">The ad's unique ID.</param>
		public static Task<bool> Messages_ViewSponsoredMessage(this Client client, InputPeer peer, byte[] random_id)
			=> client.Invoke(new Messages_ViewSponsoredMessage
			{
				peer = peer,
				random_id = random_id,
			});

		/// <summary>Informs the server that the user has interacted with a sponsored message in <a href="https://corefork.telegram.org/api/sponsored-messages#clicking-on-sponsored-messages">one of the ways listed here »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.clickSponsoredMessage"/></para></summary>
		/// <param name="media">The user clicked on the media</param>
		/// <param name="fullscreen">The user expanded the video to full screen, and then clicked on it.</param>
		/// <param name="peer">The channel/bot where the ad is located</param>
		/// <param name="random_id">The ad's unique ID.</param>
		public static Task<bool> Messages_ClickSponsoredMessage(this Client client, InputPeer peer, byte[] random_id, bool media = false, bool fullscreen = false)
			=> client.Invoke(new Messages_ClickSponsoredMessage
			{
				flags = (Messages_ClickSponsoredMessage.Flags)((media ? 0x1 : 0) | (fullscreen ? 0x2 : 0)),
				peer = peer,
				random_id = random_id,
			});

		/// <summary>Report a <a href="https://corefork.telegram.org/api/sponsored-messages">sponsored message »</a>, see <a href="https://corefork.telegram.org/api/sponsored-messages#reporting-sponsored-messages">here »</a> for more info on the full flow.		<para>See <a href="https://corefork.telegram.org/method/messages.reportSponsoredMessage"/></para></summary>
		/// <param name="peer">The channel/bot where the ad is located</param>
		/// <param name="random_id">The ad's unique ID.</param>
		/// <param name="option">Chosen report option, initially an empty string, see <a href="https://corefork.telegram.org/api/sponsored-messages#reporting-sponsored-messages">here »</a> for more info on the full flow.</param>
		public static Task<Channels_SponsoredMessageReportResult> Messages_ReportSponsoredMessage(this Client client, InputPeer peer, byte[] random_id, byte[] option)
			=> client.Invoke(new Messages_ReportSponsoredMessage
			{
				peer = peer,
				random_id = random_id,
				option = option,
			});

		/// <summary>Get a list of <a href="https://corefork.telegram.org/api/sponsored-messages">sponsored messages for a peer, see here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/messages.getSponsoredMessages"/></para></summary>
		/// <param name="peer">The currently open channel/bot.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.sponsoredMessagesEmpty">messages.sponsoredMessagesEmpty</a></returns>
		public static Task<Messages_SponsoredMessages> Messages_GetSponsoredMessages(this Client client, InputPeer peer)
			=> client.Invoke(new Messages_GetSponsoredMessages
			{
				peer = peer,
			});

		/// <summary>Save a <a href="https://corefork.telegram.org/api/bots/inline#21-using-a-prepared-inline-message">prepared inline message</a>, to be shared by the user of the mini app using a <a href="https://corefork.telegram.org/api/web-events#web-app-send-prepared-message">web_app_send_prepared_message event</a>		<para>See <a href="https://corefork.telegram.org/method/messages.savePreparedInlineMessage"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.savePreparedInlineMessage#possible-errors">details</a>)</para></summary>
		/// <param name="result">The message</param>
		/// <param name="user_id">The user to whom the <a href="https://corefork.telegram.org/api/web-events#web-app-send-prepared-message">web_app_send_prepared_message event</a> event will be sent</param>
		/// <param name="peer_types">Types of chats where this message can be sent</param>
		public static Task<Messages_BotPreparedInlineMessage> Messages_SavePreparedInlineMessage(this Client client, InputBotInlineResultBase result, InputUserBase user_id, InlineQueryPeerType[] peer_types = null)
			=> client.Invoke(new Messages_SavePreparedInlineMessage
			{
				flags = (Messages_SavePreparedInlineMessage.Flags)(peer_types != null ? 0x1 : 0),
				result = result,
				user_id = user_id,
				peer_types = peer_types,
			});

		/// <summary>Obtain a <a href="https://corefork.telegram.org/api/bots/inline#21-using-a-prepared-inline-message">prepared inline message</a> generated by a <a href="https://corefork.telegram.org/api/bots/webapps">mini app</a>: invoked when handling <a href="https://corefork.telegram.org/api/web-events#web-app-send-prepared-message">web_app_send_prepared_message events</a>		<para>See <a href="https://corefork.telegram.org/method/messages.getPreparedInlineMessage"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getPreparedInlineMessage#possible-errors">details</a>)</para></summary>
		/// <param name="bot">The bot that owns the mini app that emitted the <a href="https://corefork.telegram.org/api/web-events#web-app-send-prepared-message">web_app_send_prepared_message event</a></param>
		/// <param name="id">The <c>id</c> from the <a href="https://corefork.telegram.org/api/web-events#web-app-send-prepared-message">web_app_send_prepared_message event</a></param>
		public static Task<Messages_PreparedInlineMessage> Messages_GetPreparedInlineMessage(this Client client, InputUserBase bot, string id)
			=> client.Invoke(new Messages_GetPreparedInlineMessage
			{
				bot = bot,
				id = id,
			});

		/// <summary>Search for stickers using AI-powered keyword search		<para>See <a href="https://corefork.telegram.org/method/messages.searchStickers"/></para></summary>
		/// <param name="emojis">If set, returns <a href="https://corefork.telegram.org/api/custom-emoji">custom emoji stickers</a></param>
		/// <param name="q">The search term</param>
		/// <param name="emoticon">Space-separated list of emojis to search for</param>
		/// <param name="lang_code">List of possible IETF language tags of the user's input language; may be empty if unknown</param>
		/// <param name="offset"><a href="https://corefork.telegram.org/api/offsets">Offset for pagination</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>. <br/>The hash may be generated locally by using the <c>id</c>s of the returned or stored sticker <see cref="Document"/>s.</param>
		public static Task<Messages_FoundStickersBase> Messages_SearchStickers(this Client client, string q, string emoticon, string[] lang_code, int offset = default, int limit = int.MaxValue, long hash = default, bool emojis = false)
			=> client.Invoke(new Messages_SearchStickers
			{
				flags = (Messages_SearchStickers.Flags)(emojis ? 0x1 : 0),
				q = q,
				emoticon = emoticon,
				lang_code = lang_code,
				offset = offset,
				limit = limit,
				hash = hash,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/messages.reportMessagesDelivery"/></para></summary>
		public static Task<bool> Messages_ReportMessagesDelivery(this Client client, InputPeer peer, int[] id, bool push = false)
			=> client.Invoke(new Messages_ReportMessagesDelivery
			{
				flags = (Messages_ReportMessagesDelivery.Flags)(push ? 0x1 : 0),
				peer = peer,
				id = id,
			});

		/// <summary>Returns a current state of updates.		<para>See <a href="https://corefork.telegram.org/method/updates.getState"/> [bots: ✓]</para></summary>
		public static Task<Updates_State> Updates_GetState(this Client client)
			=> client.Invoke(new Updates_GetState
			{
			});

		/// <summary>Get new <a href="https://corefork.telegram.org/api/updates">updates</a>.		<para>See <a href="https://corefork.telegram.org/method/updates.getDifference"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403,500 (<a href="https://corefork.telegram.org/method/updates.getDifference#possible-errors">details</a>)</para></summary>
		/// <param name="pts">PTS, see <a href="https://corefork.telegram.org/api/updates">updates</a>.</param>
		/// <param name="pts_limit">PTS limit</param>
		/// <param name="pts_total_limit">For fast updating: if provided and <c>pts + pts_total_limit &lt; remote pts</c>, <see cref="Updates_DifferenceTooLong"/> will be returned.<br/>Simply tells the server to not return the difference if it is bigger than <c>pts_total_limit</c><br/>If the remote pts is too big (&gt; ~4000000), this field will default to 1000000</param>
		/// <param name="date">date, see <a href="https://corefork.telegram.org/api/updates">updates</a>.</param>
		/// <param name="qts">QTS, see <a href="https://corefork.telegram.org/api/updates">updates</a>.</param>
		/// <param name="qts_limit">QTS limit</param>
		public static Task<Updates_DifferenceBase> Updates_GetDifference(this Client client, int pts, DateTime date, int qts, int? pts_total_limit = null, int? pts_limit = null, int? qts_limit = null)
			=> client.Invoke(new Updates_GetDifference
			{
				flags = (Updates_GetDifference.Flags)((pts_total_limit != null ? 0x1 : 0) | (pts_limit != null ? 0x2 : 0) | (qts_limit != null ? 0x4 : 0)),
				pts = pts,
				pts_limit = pts_limit ?? default,
				pts_total_limit = pts_total_limit ?? default,
				date = date,
				qts = qts,
				qts_limit = qts_limit ?? default,
			});

		/// <summary>Returns the difference between the current state of updates of a certain channel and transmitted.		<para>See <a href="https://corefork.telegram.org/method/updates.getChannelDifference"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403,406,500 (<a href="https://corefork.telegram.org/method/updates.getChannelDifference#possible-errors">details</a>)</para></summary>
		/// <param name="force">Set to true to skip some possibly unneeded updates and reduce server-side load</param>
		/// <param name="channel">The channel</param>
		/// <param name="filter">Messsage filter</param>
		/// <param name="pts">Persistent timestamp (see <a href="https://corefork.telegram.org/api/updates">updates</a>)</param>
		/// <param name="limit">How many updates to fetch, max <c>100000</c><br/>Ordinary (non-bot) users are supposed to pass <c>10-100</c></param>
		public static Task<Updates_ChannelDifferenceBase> Updates_GetChannelDifference(this Client client, InputChannelBase channel, ChannelMessagesFilter filter, int pts, int limit = int.MaxValue, bool force = false)
			=> client.Invoke(new Updates_GetChannelDifference
			{
				flags = (Updates_GetChannelDifference.Flags)(force ? 0x1 : 0),
				channel = channel,
				filter = filter,
				pts = pts,
				limit = limit,
			});

		/// <summary>Installs a previously uploaded photo as a profile photo.		<para>See <a href="https://corefork.telegram.org/method/photos.updateProfilePhoto"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/photos.updateProfilePhoto#possible-errors">details</a>)</para></summary>
		/// <param name="fallback">If set, the chosen profile photo will be shown to users that can't display your main profile photo due to your privacy settings.</param>
		/// <param name="bot">Can contain info of a bot we own, to change the profile photo of that bot, instead of the current user.</param>
		/// <param name="id">Input photo</param>
		public static Task<Photos_Photo> Photos_UpdateProfilePhoto(this Client client, InputPhoto id, InputUserBase bot = null, bool fallback = false)
			=> client.Invoke(new Photos_UpdateProfilePhoto
			{
				flags = (Photos_UpdateProfilePhoto.Flags)((bot != null ? 0x2 : 0) | (fallback ? 0x1 : 0)),
				bot = bot,
				id = id,
			});

		/// <summary>Updates current user profile photo.		<para>See <a href="https://corefork.telegram.org/method/photos.uploadProfilePhoto"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/photos.uploadProfilePhoto#possible-errors">details</a>)</para></summary>
		/// <param name="fallback">If set, the chosen profile photo will be shown to users that can't display your main profile photo due to your privacy settings.</param>
		/// <param name="bot">Can contain info of a bot we own, to change the profile photo of that bot, instead of the current user.</param>
		/// <param name="file">Profile photo</param>
		/// <param name="video"><a href="https://corefork.telegram.org/api/files#animated-profile-pictures">Animated profile picture</a> video</param>
		/// <param name="video_start_ts">Floating point UNIX timestamp in seconds, indicating the frame of the video/sticker that should be used as static preview; can only be used if <c>video</c> or <c>video_emoji_markup</c> is set.</param>
		/// <param name="video_emoji_markup">Animated sticker profile picture, must contain either a <see cref="VideoSizeEmojiMarkup"/> or a <see cref="VideoSizeStickerMarkup"/>.</param>
		public static Task<Photos_Photo> Photos_UploadProfilePhoto(this Client client, InputFileBase file = null, InputFileBase video = null, double? video_start_ts = null, VideoSizeBase video_emoji_markup = null, InputUserBase bot = null, bool fallback = false)
			=> client.Invoke(new Photos_UploadProfilePhoto
			{
				flags = (Photos_UploadProfilePhoto.Flags)((file != null ? 0x1 : 0) | (video != null ? 0x2 : 0) | (video_start_ts != null ? 0x4 : 0) | (video_emoji_markup != null ? 0x10 : 0) | (bot != null ? 0x20 : 0) | (fallback ? 0x8 : 0)),
				bot = bot,
				file = file,
				video = video,
				video_start_ts = video_start_ts ?? default,
				video_emoji_markup = video_emoji_markup,
			});

		/// <summary>Deletes profile photos. The method returns a list of successfully deleted photo IDs.		<para>See <a href="https://corefork.telegram.org/method/photos.deletePhotos"/></para></summary>
		/// <param name="id">Input photos to delete</param>
		public static Task<long[]> Photos_DeletePhotos(this Client client, params InputPhoto[] id)
			=> client.Invoke(new Photos_DeletePhotos
			{
				id = id,
			});

		/// <summary>Returns the list of user photos.		<para>See <a href="https://corefork.telegram.org/method/photos.getUserPhotos"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/photos.getUserPhotos#possible-errors">details</a>)</para></summary>
		/// <param name="user_id">User ID</param>
		/// <param name="offset">Number of list elements to be skipped</param>
		/// <param name="max_id">If a positive value was transferred, the method will return only photos with IDs less than the set one. This parameter is often useful when <a href="https://corefork.telegram.org/api/file_reference">refetching file references »</a>, as in conjuction with <c>limit=1</c> and <c>offset=-1</c> the <see cref="Photo"/> object with the <c>id</c> specified in <c>max_id</c> can be fetched.</param>
		/// <param name="limit">Number of list elements to be returned</param>
		public static Task<Photos_Photos> Photos_GetUserPhotos(this Client client, InputUserBase user_id, int offset = default, long max_id = default, int limit = int.MaxValue)
			=> client.Invoke(new Photos_GetUserPhotos
			{
				user_id = user_id,
				offset = offset,
				max_id = max_id,
				limit = limit,
			});

		/// <summary>Upload a custom profile picture for a contact, or suggest a new profile picture to a contact.		<para>See <a href="https://corefork.telegram.org/method/photos.uploadContactProfilePhoto"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/photos.uploadContactProfilePhoto#possible-errors">details</a>)</para></summary>
		/// <param name="suggest">If set, will send a <see cref="MessageActionSuggestProfilePhoto"/> service message to <c>user_id</c>, suggesting them to use the specified profile picture; otherwise, will set a personal profile picture for the user (only visible to the current user).</param>
		/// <param name="save">If set, removes a previously set personal profile picture (does not affect suggested profile pictures, to remove them simply deleted the <see cref="MessageActionSuggestProfilePhoto"/> service message with <see cref="Messages_DeleteMessages">Messages_DeleteMessages</see>).</param>
		/// <param name="user_id">The contact</param>
		/// <param name="file">Profile photo</param>
		/// <param name="video"><a href="https://corefork.telegram.org/api/files#animated-profile-pictures">Animated profile picture</a> video</param>
		/// <param name="video_start_ts">Floating point UNIX timestamp in seconds, indicating the frame of the video/sticker that should be used as static preview; can only be used if <c>video</c> or <c>video_emoji_markup</c> is set.</param>
		/// <param name="video_emoji_markup">Animated sticker profile picture, must contain either a <see cref="VideoSizeEmojiMarkup"/> or a <see cref="VideoSizeStickerMarkup"/>.</param>
		public static Task<Photos_Photo> Photos_UploadContactProfilePhoto(this Client client, InputUserBase user_id, InputFileBase file = null, InputFileBase video = null, double? video_start_ts = null, VideoSizeBase video_emoji_markup = null, bool suggest = false, bool save = false)
			=> client.Invoke(new Photos_UploadContactProfilePhoto
			{
				flags = (Photos_UploadContactProfilePhoto.Flags)((file != null ? 0x1 : 0) | (video != null ? 0x2 : 0) | (video_start_ts != null ? 0x4 : 0) | (video_emoji_markup != null ? 0x20 : 0) | (suggest ? 0x8 : 0) | (save ? 0x10 : 0)),
				user_id = user_id,
				file = file,
				video = video,
				video_start_ts = video_start_ts ?? default,
				video_emoji_markup = video_emoji_markup,
			});

		/// <summary>Saves a part of file for further sending to one of the methods.		<para>See <a href="https://corefork.telegram.org/method/upload.saveFilePart"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/upload.saveFilePart#possible-errors">details</a>)</para></summary>
		/// <param name="file_id">Random file identifier created by the client</param>
		/// <param name="file_part">Numerical order of a part</param>
		/// <param name="bytes">Binary data, content of a part</param>
		public static Task<bool> Upload_SaveFilePart(this Client client, long file_id, int file_part, byte[] bytes)
			=> client.Invoke(new Upload_SaveFilePart
			{
				file_id = file_id,
				file_part = file_part,
				bytes = bytes,
			});

		/// <summary>Returns content of a whole file or its part.		<para>See <a href="https://corefork.telegram.org/method/upload.getFile"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,406,420 (<a href="https://corefork.telegram.org/method/upload.getFile#possible-errors">details</a>)</para></summary>
		/// <param name="precise">Disable some checks on limit and offset values, useful for example to stream videos by keyframes</param>
		/// <param name="cdn_supported">Whether the current client supports <a href="https://corefork.telegram.org/cdn">CDN downloads</a></param>
		/// <param name="location">File location</param>
		/// <param name="offset">Number of bytes to be skipped</param>
		/// <param name="limit">Number of bytes to be returned</param>
		public static Task<Upload_FileBase> Upload_GetFile(this Client client, InputFileLocationBase location, long offset = default, int limit = int.MaxValue, bool precise = false, bool cdn_supported = false)
			=> client.Invoke(new Upload_GetFile
			{
				flags = (Upload_GetFile.Flags)((precise ? 0x1 : 0) | (cdn_supported ? 0x2 : 0)),
				location = location,
				offset = offset,
				limit = limit,
			});

		/// <summary>Saves a part of a large file (over 10 MB in size) to be later passed to one of the methods.		<para>See <a href="https://corefork.telegram.org/method/upload.saveBigFilePart"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/upload.saveBigFilePart#possible-errors">details</a>)</para></summary>
		/// <param name="file_id">Random file id, created by the client</param>
		/// <param name="file_part">Part sequence number</param>
		/// <param name="file_total_parts">Total number of parts</param>
		/// <param name="bytes">Binary data, part contents</param>
		public static Task<bool> Upload_SaveBigFilePart(this Client client, long file_id, int file_part, int file_total_parts, byte[] bytes)
			=> client.Invoke(new Upload_SaveBigFilePart
			{
				file_id = file_id,
				file_part = file_part,
				file_total_parts = file_total_parts,
				bytes = bytes,
			});

		/// <summary>Returns content of a web file, by proxying the request through telegram, see the <a href="https://corefork.telegram.org/api/files#downloading-webfiles">webfile docs for more info</a>.		<para>See <a href="https://corefork.telegram.org/method/upload.getWebFile"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/upload.getWebFile#possible-errors">details</a>)</para></summary>
		/// <param name="location">The file to download</param>
		/// <param name="offset">Number of bytes to be skipped</param>
		/// <param name="limit">Number of bytes to be returned</param>
		public static Task<Upload_WebFile> Upload_GetWebFile(this Client client, InputWebFileLocationBase location, int offset = default, int limit = int.MaxValue)
			=> client.Invoke(new Upload_GetWebFile
			{
				location = location,
				offset = offset,
				limit = limit,
			});

		/// <summary>Download a <a href="https://corefork.telegram.org/cdn">CDN</a> file.		<para>See <a href="https://corefork.telegram.org/method/upload.getCdnFile"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/upload.getCdnFile#possible-errors">details</a>)</para></summary>
		/// <param name="file_token">File token</param>
		/// <param name="offset">Offset of chunk to download</param>
		/// <param name="limit">Length of chunk to download</param>
		public static Task<Upload_CdnFileBase> Upload_GetCdnFile(this Client client, byte[] file_token, long offset = default, int limit = int.MaxValue)
			=> client.Invoke(new Upload_GetCdnFile
			{
				file_token = file_token,
				offset = offset,
				limit = limit,
			});

		/// <summary>Request a reupload of a certain file to a <a href="https://corefork.telegram.org/cdn">CDN DC</a>.		<para>See <a href="https://corefork.telegram.org/method/upload.reuploadCdnFile"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,500 (<a href="https://corefork.telegram.org/method/upload.reuploadCdnFile#possible-errors">details</a>)</para></summary>
		/// <param name="file_token">File token</param>
		/// <param name="request_token">Request token</param>
		public static Task<FileHash[]> Upload_ReuploadCdnFile(this Client client, byte[] file_token, byte[] request_token)
			=> client.Invoke(new Upload_ReuploadCdnFile
			{
				file_token = file_token,
				request_token = request_token,
			});

		/// <summary>Get SHA256 hashes for verifying downloaded <a href="https://corefork.telegram.org/cdn">CDN</a> files		<para>See <a href="https://corefork.telegram.org/method/upload.getCdnFileHashes"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/upload.getCdnFileHashes#possible-errors">details</a>)</para></summary>
		/// <param name="file_token">File</param>
		/// <param name="offset">Offset from which to start getting hashes</param>
		public static Task<FileHash[]> Upload_GetCdnFileHashes(this Client client, byte[] file_token, long offset = default)
			=> client.Invoke(new Upload_GetCdnFileHashes
			{
				file_token = file_token,
				offset = offset,
			});

		/// <summary>Get SHA256 hashes for verifying downloaded files		<para>See <a href="https://corefork.telegram.org/method/upload.getFileHashes"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/upload.getFileHashes#possible-errors">details</a>)</para></summary>
		/// <param name="location">File</param>
		/// <param name="offset">Offset from which to get file hashes</param>
		public static Task<FileHash[]> Upload_GetFileHashes(this Client client, InputFileLocationBase location, long offset = default)
			=> client.Invoke(new Upload_GetFileHashes
			{
				location = location,
				offset = offset,
			});

		/// <summary>Returns current configuration, including data center configuration.		<para>See <a href="https://corefork.telegram.org/method/help.getConfig"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/help.getConfig#possible-errors">details</a>)</para></summary>
		public static Task<Config> Help_GetConfig(this Client client)
			=> client.Invoke(new Help_GetConfig
			{
			});

		/// <summary>Returns info on data center nearest to the user.		<para>See <a href="https://corefork.telegram.org/method/help.getNearestDc"/></para></summary>
		public static Task<NearestDc> Help_GetNearestDc(this Client client)
			=> client.Invoke(new Help_GetNearestDc
			{
			});

		/// <summary>Returns information on update availability for the current application.		<para>See <a href="https://corefork.telegram.org/method/help.getAppUpdate"/></para></summary>
		/// <param name="source">Source</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.noAppUpdate">help.noAppUpdate</a></returns>
		public static Task<Help_AppUpdate> Help_GetAppUpdate(this Client client, string source)
			=> client.Invoke(new Help_GetAppUpdate
			{
				source = source,
			});

		/// <summary>Returns localized text of a text message with an invitation.		<para>See <a href="https://corefork.telegram.org/method/help.getInviteText"/></para></summary>
		public static Task<Help_InviteText> Help_GetInviteText(this Client client)
			=> client.Invoke(new Help_GetInviteText
			{
			});

		/// <summary>Returns the support user for the "ask a question" feature.		<para>See <a href="https://corefork.telegram.org/method/help.getSupport"/></para></summary>
		public static Task<Help_Support> Help_GetSupport(this Client client)
			=> client.Invoke(new Help_GetSupport
			{
			});

		/// <summary>Informs the server about the number of pending bot updates if they haven't been processed for a long time; for bots only		<para>See <a href="https://corefork.telegram.org/method/help.setBotUpdatesStatus"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/help.setBotUpdatesStatus#possible-errors">details</a>)</para></summary>
		/// <param name="pending_updates_count">Number of pending updates</param>
		/// <param name="message">Error message, if present</param>
		public static Task<bool> Help_SetBotUpdatesStatus(this Client client, int pending_updates_count, string message)
			=> client.Invoke(new Help_SetBotUpdatesStatus
			{
				pending_updates_count = pending_updates_count,
				message = message,
			});

		/// <summary>Get configuration for <a href="https://corefork.telegram.org/cdn">CDN</a> file downloads.		<para>See <a href="https://corefork.telegram.org/method/help.getCdnConfig"/> [bots: ✓]</para></summary>
		public static Task<CdnConfig> Help_GetCdnConfig(this Client client)
			=> client.Invoke(new Help_GetCdnConfig
			{
			});

		/// <summary>Get recently used <c>t.me</c> links.		<para>See <a href="https://corefork.telegram.org/method/help.getRecentMeUrls"/></para></summary>
		/// <param name="referer">Referrer</param>
		public static Task<Help_RecentMeUrls> Help_GetRecentMeUrls(this Client client, string referer)
			=> client.Invoke(new Help_GetRecentMeUrls
			{
				referer = referer,
			});

		/// <summary>Look for updates of telegram's terms of service		<para>See <a href="https://corefork.telegram.org/method/help.getTermsOfServiceUpdate"/></para></summary>
		public static Task<Help_TermsOfServiceUpdateBase> Help_GetTermsOfServiceUpdate(this Client client)
			=> client.Invoke(new Help_GetTermsOfServiceUpdate
			{
			});

		/// <summary>Accept the new terms of service		<para>See <a href="https://corefork.telegram.org/method/help.acceptTermsOfService"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/help.acceptTermsOfService#possible-errors">details</a>)</para></summary>
		/// <param name="id">ID of terms of service</param>
		public static Task<bool> Help_AcceptTermsOfService(this Client client, DataJSON id)
			=> client.Invoke(new Help_AcceptTermsOfService
			{
				id = id,
			});

		/// <summary>Get info about an unsupported deep link, see <a href="https://corefork.telegram.org/api/links#unsupported-links">here for more info »</a>.		<para>See <a href="https://corefork.telegram.org/method/help.getDeepLinkInfo"/></para></summary>
		/// <param name="path">Path component of a <c>tg:</c> link</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.deepLinkInfoEmpty">help.deepLinkInfoEmpty</a></returns>
		public static Task<Help_DeepLinkInfo> Help_GetDeepLinkInfo(this Client client, string path)
			=> client.Invoke(new Help_GetDeepLinkInfo
			{
				path = path,
			});

		/// <summary>Get app-specific configuration, see <a href="https://corefork.telegram.org/api/config#client-configuration">client configuration</a> for more info on the result.		<para>See <a href="https://corefork.telegram.org/method/help.getAppConfig"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.appConfigNotModified">help.appConfigNotModified</a></returns>
		public static Task<Help_AppConfig> Help_GetAppConfig(this Client client, int hash = default)
			=> client.Invoke(new Help_GetAppConfig
			{
				hash = hash,
			});

		/// <summary>Saves logs of application on the server.		<para>See <a href="https://corefork.telegram.org/method/help.saveAppLog"/></para></summary>
		/// <param name="events">List of input events</param>
		public static Task<bool> Help_SaveAppLog(this Client client, params InputAppEvent[] events)
			=> client.Invoke(new Help_SaveAppLog
			{
				events = events,
			});

		/// <summary>Get <a href="https://corefork.telegram.org/passport">passport</a> configuration		<para>See <a href="https://corefork.telegram.org/method/help.getPassportConfig"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.passportConfigNotModified">help.passportConfigNotModified</a></returns>
		public static Task<Help_PassportConfig> Help_GetPassportConfig(this Client client, int hash = default)
			=> client.Invoke(new Help_GetPassportConfig
			{
				hash = hash,
			});

		/// <summary>Get localized name of the telegram support user		<para>See <a href="https://corefork.telegram.org/method/help.getSupportName"/></para>		<para>Possible <see cref="RpcException"/> codes: 403 (<a href="https://corefork.telegram.org/method/help.getSupportName#possible-errors">details</a>)</para></summary>
		public static Task<Help_SupportName> Help_GetSupportName(this Client client)
			=> client.Invoke(new Help_GetSupportName
			{
			});

		/// <summary>Can only be used by TSF members to obtain internal information.		<para>See <a href="https://corefork.telegram.org/method/help.getUserInfo"/></para>		<para>Possible <see cref="RpcException"/> codes: 403 (<a href="https://corefork.telegram.org/method/help.getUserInfo#possible-errors">details</a>)</para></summary>
		/// <param name="user_id">User ID</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.userInfoEmpty">help.userInfoEmpty</a></returns>
		public static Task<Help_UserInfo> Help_GetUserInfo(this Client client, InputUserBase user_id)
			=> client.Invoke(new Help_GetUserInfo
			{
				user_id = user_id,
			});

		/// <summary>Internal use		<para>See <a href="https://corefork.telegram.org/method/help.editUserInfo"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/help.editUserInfo#possible-errors">details</a>)</para></summary>
		/// <param name="user_id">User</param>
		/// <param name="message">Message</param>
		/// <param name="entities"><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.userInfoEmpty">help.userInfoEmpty</a></returns>
		public static Task<Help_UserInfo> Help_EditUserInfo(this Client client, InputUserBase user_id, string message, params MessageEntity[] entities)
			=> client.Invoke(new Help_EditUserInfo
			{
				user_id = user_id,
				message = message,
				entities = entities,
			});

		/// <summary>Get MTProxy/Public Service Announcement information		<para>See <a href="https://corefork.telegram.org/method/help.getPromoData"/></para></summary>
		public static Task<Help_PromoDataBase> Help_GetPromoData(this Client client)
			=> client.Invoke(new Help_GetPromoData
			{
			});

		/// <summary>Hide MTProxy/Public Service Announcement information		<para>See <a href="https://corefork.telegram.org/method/help.hidePromoData"/></para></summary>
		/// <param name="peer">Peer to hide</param>
		public static Task<bool> Help_HidePromoData(this Client client, InputPeer peer)
			=> client.Invoke(new Help_HidePromoData
			{
				peer = peer,
			});

		/// <summary>Dismiss a <a href="https://corefork.telegram.org/api/config#suggestions">suggestion, see here for more info »</a>.		<para>See <a href="https://corefork.telegram.org/method/help.dismissSuggestion"/></para></summary>
		/// <param name="peer">In the case of pending suggestions in <see cref="ChannelFull">channels</see>, the channel ID.</param>
		/// <param name="suggestion"><a href="https://corefork.telegram.org/api/config#suggestions">Suggestion, see here for more info »</a>.</param>
		public static Task<bool> Help_DismissSuggestion(this Client client, InputPeer peer, string suggestion)
			=> client.Invoke(new Help_DismissSuggestion
			{
				peer = peer,
				suggestion = suggestion,
			});

		/// <summary>Get name, ISO code, localized name and phone codes/patterns of all available countries		<para>See <a href="https://corefork.telegram.org/method/help.getCountriesList"/></para></summary>
		/// <param name="lang_code">Language code of the current user</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.countriesListNotModified">help.countriesListNotModified</a></returns>
		public static Task<Help_CountriesList> Help_GetCountriesList(this Client client, string lang_code, int hash = default)
			=> client.Invoke(new Help_GetCountriesList
			{
				lang_code = lang_code,
				hash = hash,
			});

		/// <summary>Get Telegram Premium promotion information		<para>See <a href="https://corefork.telegram.org/method/help.getPremiumPromo"/></para></summary>
		public static Task<Help_PremiumPromo> Help_GetPremiumPromo(this Client client)
			=> client.Invoke(new Help_GetPremiumPromo
			{
			});

		/// <summary>Get the set of <a href="https://corefork.telegram.org/api/colors">accent color palettes »</a> that can be used for message accents.		<para>See <a href="https://corefork.telegram.org/method/help.getPeerColors"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.peerColorsNotModified">help.peerColorsNotModified</a></returns>
		public static Task<Help_PeerColors> Help_GetPeerColors(this Client client, int hash = default)
			=> client.Invoke(new Help_GetPeerColors
			{
				hash = hash,
			});

		/// <summary>Get the set of <a href="https://corefork.telegram.org/api/colors">accent color palettes »</a> that can be used in profile page backgrounds.		<para>See <a href="https://corefork.telegram.org/method/help.getPeerProfileColors"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.peerColorsNotModified">help.peerColorsNotModified</a></returns>
		public static Task<Help_PeerColors> Help_GetPeerProfileColors(this Client client, int hash = default)
			=> client.Invoke(new Help_GetPeerProfileColors
			{
				hash = hash,
			});

		/// <summary>Returns timezone information that may be used elsewhere in the API, such as to set <a href="https://corefork.telegram.org/api/business#opening-hours">Telegram Business opening hours »</a>.		<para>See <a href="https://corefork.telegram.org/method/help.getTimezonesList"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.timezonesListNotModified">help.timezonesListNotModified</a></returns>
		public static Task<Help_TimezonesList> Help_GetTimezonesList(this Client client, int hash = default)
			=> client.Invoke(new Help_GetTimezonesList
			{
				hash = hash,
			});

		/// <summary>Mark <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> history as read		<para>See <a href="https://corefork.telegram.org/method/channels.readHistory"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/channels.readHistory#possible-errors">details</a>)</para></summary>
		/// <param name="channel"><a href="https://corefork.telegram.org/api/channel">Channel/supergroup</a></param>
		/// <param name="max_id">ID of message up to which messages should be marked as read</param>
		public static Task<bool> Channels_ReadHistory(this Client client, InputChannelBase channel, int max_id = default)
			=> client.Invoke(new Channels_ReadHistory
			{
				channel = channel,
				max_id = max_id,
			});

		/// <summary>Delete messages in a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>		<para>See <a href="https://corefork.telegram.org/method/channels.deleteMessages"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403,406 (<a href="https://corefork.telegram.org/method/channels.deleteMessages#possible-errors">details</a>)</para></summary>
		/// <param name="channel"><a href="https://corefork.telegram.org/api/channel">Channel/supergroup</a></param>
		/// <param name="id">IDs of messages to delete</param>
		public static Task<Messages_AffectedMessages> Channels_DeleteMessages(this Client client, InputChannelBase channel, params int[] id)
			=> client.InvokeAffected(new Channels_DeleteMessages
			{
				channel = channel,
				id = id,
			}, channel.ChannelId);

		/// <summary>Reports some messages from a user in a supergroup as spam; requires administrator rights in the supergroup		<para>See <a href="https://corefork.telegram.org/method/channels.reportSpam"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.reportSpam#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Supergroup</param>
		/// <param name="participant">Participant whose messages should be reported</param>
		/// <param name="id">IDs of spam messages</param>
		public static Task<bool> Channels_ReportSpam(this Client client, InputChannelBase channel, InputPeer participant, params int[] id)
			=> client.Invoke(new Channels_ReportSpam
			{
				channel = channel,
				participant = participant,
				id = id,
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> messages		<para>See <a href="https://corefork.telegram.org/method/channels.getMessages"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/channels.getMessages#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Channel/supergroup</param>
		/// <param name="id">IDs of messages to get</param>
		public static Task<Messages_MessagesBase> Channels_GetMessages(this Client client, InputChannelBase channel, params InputMessage[] id)
			=> client.Invoke(new Channels_GetMessages
			{
				channel = channel,
				id = id,
			});

		/// <summary>Get the participants of a <a href="https://corefork.telegram.org/api/channel">supergroup/channel</a>		<para>See <a href="https://corefork.telegram.org/method/channels.getParticipants"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403,406 (<a href="https://corefork.telegram.org/method/channels.getParticipants#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Channel</param>
		/// <param name="filter">Which participant types to fetch</param>
		/// <param name="offset"><a href="https://corefork.telegram.org/api/offsets">Offset</a></param>
		/// <param name="limit"><a href="https://corefork.telegram.org/api/offsets">Limit</a></param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets">Hash</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/channels.channelParticipantsNotModified">channels.channelParticipantsNotModified</a></returns>
		public static Task<Channels_ChannelParticipants> Channels_GetParticipants(this Client client, InputChannelBase channel, ChannelParticipantsFilter filter, int offset = default, int limit = int.MaxValue, long hash = default)
			=> client.Invoke(new Channels_GetParticipants
			{
				channel = channel,
				filter = filter,
				offset = offset,
				limit = limit,
				hash = hash,
			});

		/// <summary>Get info about a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> participant		<para>See <a href="https://corefork.telegram.org/method/channels.getParticipant"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403,406 (<a href="https://corefork.telegram.org/method/channels.getParticipant#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Channel/supergroup</param>
		/// <param name="participant">Participant to get info about</param>
		public static Task<Channels_ChannelParticipant> Channels_GetParticipant(this Client client, InputChannelBase channel, InputPeer participant)
			=> client.Invoke(new Channels_GetParticipant
			{
				channel = channel,
				participant = participant,
			});

		/// <summary>Get info about <a href="https://corefork.telegram.org/api/channel">channels/supergroups</a>		<para>See <a href="https://corefork.telegram.org/method/channels.getChannels"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/channels.getChannels#possible-errors">details</a>)</para></summary>
		/// <param name="id">IDs of channels/supergroups to get info about</param>
		public static Task<Messages_Chats> Channels_GetChannels(this Client client, params InputChannelBase[] id)
			=> client.Invoke(new Channels_GetChannels
			{
				id = id,
			});

		/// <summary>Get full info about a <a href="https://corefork.telegram.org/api/channel#supergroups">supergroup</a>, <a href="https://corefork.telegram.org/api/channel#gigagroups">gigagroup</a> or <a href="https://corefork.telegram.org/api/channel#channels">channel</a>		<para>See <a href="https://corefork.telegram.org/method/channels.getFullChannel"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403,406 (<a href="https://corefork.telegram.org/method/channels.getFullChannel#possible-errors">details</a>)</para></summary>
		/// <param name="channel">The <a href="https://corefork.telegram.org/api/channel#channels">channel</a>, <a href="https://corefork.telegram.org/api/channel#supergroups">supergroup</a> or <a href="https://corefork.telegram.org/api/channel#gigagroups">gigagroup</a> to get info about</param>
		public static Task<Messages_ChatFull> Channels_GetFullChannel(this Client client, InputChannelBase channel)
			=> client.Invoke(new Channels_GetFullChannel
			{
				channel = channel,
			});

		/// <summary>Create a <a href="https://corefork.telegram.org/api/channel">supergroup/channel</a>.		<para>See <a href="https://corefork.telegram.org/method/channels.createChannel"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406,500 (<a href="https://corefork.telegram.org/method/channels.createChannel#possible-errors">details</a>)</para></summary>
		/// <param name="broadcast">Whether to create a <a href="https://corefork.telegram.org/api/channel">channel</a></param>
		/// <param name="megagroup">Whether to create a <a href="https://corefork.telegram.org/api/channel">supergroup</a></param>
		/// <param name="for_import">Whether the supergroup is being created to import messages from a foreign chat service using <see cref="Messages_InitHistoryImport">Messages_InitHistoryImport</see></param>
		/// <param name="forum">Whether to create a <a href="https://corefork.telegram.org/api/forum">forum</a></param>
		/// <param name="title">Channel title</param>
		/// <param name="about">Channel description</param>
		/// <param name="geo_point">Geogroup location, see <a href="https://corefork.telegram.org/api/nearby">here »</a> for more info on geogroups.</param>
		/// <param name="address">Geogroup address, see <a href="https://corefork.telegram.org/api/nearby">here »</a> for more info on geogroups.</param>
		/// <param name="ttl_period">Time-to-live of all messages that will be sent in the supergroup: once message.date+message.ttl_period === time(), the message will be deleted on the server, and must be deleted locally as well. You can use <see cref="Messages_SetDefaultHistoryTTL">Messages_SetDefaultHistoryTTL</see> to edit this value later.</param>
		public static Task<UpdatesBase> Channels_CreateChannel(this Client client, string title, string about, InputGeoPoint geo_point = null, string address = null, int? ttl_period = null, bool broadcast = false, bool megagroup = false, bool for_import = false, bool forum = false)
			=> client.Invoke(new Channels_CreateChannel
			{
				flags = (Channels_CreateChannel.Flags)((geo_point != null ? 0x4 : 0) | (address != null ? 0x4 : 0) | (ttl_period != null ? 0x10 : 0) | (broadcast ? 0x1 : 0) | (megagroup ? 0x2 : 0) | (for_import ? 0x8 : 0) | (forum ? 0x20 : 0)),
				title = title,
				about = about,
				geo_point = geo_point,
				address = address,
				ttl_period = ttl_period ?? default,
			});

		/// <summary>Modify the admin rights of a user in a <a href="https://corefork.telegram.org/api/channel">supergroup/channel</a>.		<para>See <a href="https://corefork.telegram.org/method/channels.editAdmin"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403,406 (<a href="https://corefork.telegram.org/method/channels.editAdmin#possible-errors">details</a>)</para></summary>
		/// <param name="channel">The <a href="https://corefork.telegram.org/api/channel">supergroup/channel</a>.</param>
		/// <param name="user_id">The ID of the user whose admin rights should be modified</param>
		/// <param name="admin_rights">The admin rights</param>
		/// <param name="rank">Indicates the role (rank) of the admin in the group: just an arbitrary string</param>
		public static Task<UpdatesBase> Channels_EditAdmin(this Client client, InputChannelBase channel, InputUserBase user_id, ChatAdminRights admin_rights, string rank)
			=> client.Invoke(new Channels_EditAdmin
			{
				channel = channel,
				user_id = user_id,
				admin_rights = admin_rights,
				rank = rank,
			});

		/// <summary>Edit the name of a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>		<para>See <a href="https://corefork.telegram.org/method/channels.editTitle"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/channels.editTitle#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Channel/supergroup</param>
		/// <param name="title">New name</param>
		public static Task<UpdatesBase> Channels_EditTitle(this Client client, InputChannelBase channel, string title)
			=> client.Invoke(new Channels_EditTitle
			{
				channel = channel,
				title = title,
			});

		/// <summary>Change the photo of a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>		<para>See <a href="https://corefork.telegram.org/method/channels.editPhoto"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/channels.editPhoto#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Channel/supergroup whose photo should be edited</param>
		/// <param name="photo">New photo</param>
		public static Task<UpdatesBase> Channels_EditPhoto(this Client client, InputChannelBase channel, InputChatPhotoBase photo)
			=> client.Invoke(new Channels_EditPhoto
			{
				channel = channel,
				photo = photo,
			});

		/// <summary>Check if a username is free and can be assigned to a channel/supergroup		<para>See <a href="https://corefork.telegram.org/method/channels.checkUsername"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.checkUsername#possible-errors">details</a>)</para></summary>
		/// <param name="channel">The <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> that will assigned the specified username</param>
		/// <param name="username">The username to check</param>
		public static Task<bool> Channels_CheckUsername(this Client client, InputChannelBase channel, string username)
			=> client.Invoke(new Channels_CheckUsername
			{
				channel = channel,
				username = username,
			});

		/// <summary>Change or remove the username of a supergroup/channel		<para>See <a href="https://corefork.telegram.org/method/channels.updateUsername"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/channels.updateUsername#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Channel</param>
		/// <param name="username">New username, pass an empty string to remove the username</param>
		public static Task<bool> Channels_UpdateUsername(this Client client, InputChannelBase channel, string username)
			=> client.Invoke(new Channels_UpdateUsername
			{
				channel = channel,
				username = username,
			});

		/// <summary>Join a channel/supergroup		<para>See <a href="https://corefork.telegram.org/method/channels.joinChannel"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/channels.joinChannel#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Channel/supergroup to join</param>
		public static Task<UpdatesBase> Channels_JoinChannel(this Client client, InputChannelBase channel)
			=> client.Invoke(new Channels_JoinChannel
			{
				channel = channel,
			});

		/// <summary>Leave a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>		<para>See <a href="https://corefork.telegram.org/method/channels.leaveChannel"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403,406 (<a href="https://corefork.telegram.org/method/channels.leaveChannel#possible-errors">details</a>)</para></summary>
		/// <param name="channel"><a href="https://corefork.telegram.org/api/channel">Channel/supergroup</a> to leave</param>
		public static Task<UpdatesBase> Channels_LeaveChannel(this Client client, InputChannelBase channel)
			=> client.Invoke(new Channels_LeaveChannel
			{
				channel = channel,
			});

		/// <summary>Invite users to a channel/supergroup		<para>See <a href="https://corefork.telegram.org/method/channels.inviteToChannel"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403,406 (<a href="https://corefork.telegram.org/method/channels.inviteToChannel#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Channel/supergroup</param>
		/// <param name="users">Users to invite</param>
		public static Task<Messages_InvitedUsers> Channels_InviteToChannel(this Client client, InputChannelBase channel, params InputUserBase[] users)
			=> client.Invoke(new Channels_InviteToChannel
			{
				channel = channel,
				users = users,
			});

		/// <summary>Delete a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>		<para>See <a href="https://corefork.telegram.org/method/channels.deleteChannel"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403,406 (<a href="https://corefork.telegram.org/method/channels.deleteChannel#possible-errors">details</a>)</para></summary>
		/// <param name="channel"><a href="https://corefork.telegram.org/api/channel">Channel/supergroup</a> to delete</param>
		public static Task<UpdatesBase> Channels_DeleteChannel(this Client client, InputChannelBase channel)
			=> client.Invoke(new Channels_DeleteChannel
			{
				channel = channel,
			});

		/// <summary>Get link and embed info of a message in a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>		<para>See <a href="https://corefork.telegram.org/method/channels.exportMessageLink"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.exportMessageLink#possible-errors">details</a>)</para></summary>
		/// <param name="grouped">Whether to include other grouped media (for albums)</param>
		/// <param name="thread">Whether to also include a thread ID, if available, inside of the link</param>
		/// <param name="channel">Channel</param>
		/// <param name="id">Message ID</param>
		public static Task<ExportedMessageLink> Channels_ExportMessageLink(this Client client, InputChannelBase channel, int id, bool grouped = false, bool thread = false)
			=> client.Invoke(new Channels_ExportMessageLink
			{
				flags = (Channels_ExportMessageLink.Flags)((grouped ? 0x1 : 0) | (thread ? 0x2 : 0)),
				channel = channel,
				id = id,
			});

		/// <summary>Enable/disable message signatures in channels		<para>See <a href="https://corefork.telegram.org/method/channels.toggleSignatures"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.toggleSignatures#possible-errors">details</a>)</para></summary>
		/// <param name="signatures_enabled">If set, enables message signatures.</param>
		/// <param name="profiles_enabled">If set, messages from channel admins will link to their profiles, just like for group messages: can only be set if the <c>signatures_enabled</c> flag is set.</param>
		/// <param name="channel">Channel</param>
		public static Task<UpdatesBase> Channels_ToggleSignatures(this Client client, InputChannelBase channel, bool signatures_enabled = false, bool profiles_enabled = false)
			=> client.Invoke(new Channels_ToggleSignatures
			{
				flags = (Channels_ToggleSignatures.Flags)((signatures_enabled ? 0x1 : 0) | (profiles_enabled ? 0x2 : 0)),
				channel = channel,
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/channel">channels/supergroups/geogroups</a> we're admin in. Usually called when the user exceeds the <see cref="Config">limit</see> for owned public <a href="https://corefork.telegram.org/api/channel">channels/supergroups/geogroups</a>, and the user is given the choice to remove one of his channels/supergroups/geogroups.		<para>See <a href="https://corefork.telegram.org/method/channels.getAdminedPublicChannels"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.getAdminedPublicChannels#possible-errors">details</a>)</para></summary>
		/// <param name="by_location">Get geogroups</param>
		/// <param name="check_limit">If set and the user has reached the limit of owned public <a href="https://corefork.telegram.org/api/channel">channels/supergroups/geogroups</a>, instead of returning the channel list one of the specified <a href="https://corefork.telegram.org/method/channels.getAdminedPublicChannels#possible-errors">errors</a> will be returned.<br/>Useful to check if a new public channel can indeed be created, even before asking the user to enter a channel username to use in <see cref="Channels_CheckUsername">Channels_CheckUsername</see>/<see cref="Channels_UpdateUsername">Channels_UpdateUsername</see>.</param>
		/// <param name="for_personal">Set this flag to only fetch the full list of channels that may be passed to <see cref="Account_UpdatePersonalChannel">Account_UpdatePersonalChannel</see> to <a href="https://corefork.telegram.org/api/profile#personal-channel">display them on our profile page</a>.</param>
		public static Task<Messages_Chats> Channels_GetAdminedPublicChannels(this Client client, bool by_location = false, bool check_limit = false, bool for_personal = false)
			=> client.Invoke(new Channels_GetAdminedPublicChannels
			{
				flags = (Channels_GetAdminedPublicChannels.Flags)((by_location ? 0x1 : 0) | (check_limit ? 0x2 : 0) | (for_personal ? 0x4 : 0)),
			});

		/// <summary>Ban/unban/kick a user in a <a href="https://corefork.telegram.org/api/channel">supergroup/channel</a>.		<para>See <a href="https://corefork.telegram.org/method/channels.editBanned"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403,406 (<a href="https://corefork.telegram.org/method/channels.editBanned#possible-errors">details</a>)</para></summary>
		/// <param name="channel">The <a href="https://corefork.telegram.org/api/channel">supergroup/channel</a>.</param>
		/// <param name="participant">Participant to ban</param>
		/// <param name="banned_rights">The banned rights</param>
		public static Task<UpdatesBase> Channels_EditBanned(this Client client, InputChannelBase channel, InputPeer participant, ChatBannedRights banned_rights)
			=> client.Invoke(new Channels_EditBanned
			{
				channel = channel,
				participant = participant,
				banned_rights = banned_rights,
			});

		/// <summary>Get the admin log of a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>		<para>See <a href="https://corefork.telegram.org/method/channels.getAdminLog"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403,406 (<a href="https://corefork.telegram.org/method/channels.getAdminLog#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Channel</param>
		/// <param name="q">Search query, can be empty</param>
		/// <param name="events_filter">Event filter</param>
		/// <param name="admins">Only show events from these admins</param>
		/// <param name="max_id">Maximum ID of message to return (see <a href="https://corefork.telegram.org/api/offsets">pagination</a>)</param>
		/// <param name="min_id">Minimum ID of message to return (see <a href="https://corefork.telegram.org/api/offsets">pagination</a>)</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Channels_AdminLogResults> Channels_GetAdminLog(this Client client, InputChannelBase channel, string q, long max_id = default, long min_id = default, int limit = int.MaxValue, ChannelAdminLogEventsFilter events_filter = null, InputUserBase[] admins = null)
			=> client.Invoke(new Channels_GetAdminLog
			{
				flags = (Channels_GetAdminLog.Flags)((events_filter != null ? 0x1 : 0) | (admins != null ? 0x2 : 0)),
				channel = channel,
				q = q,
				events_filter = events_filter,
				admins = admins,
				max_id = max_id,
				min_id = min_id,
				limit = limit,
			});

		/// <summary>Associate a stickerset to the supergroup		<para>See <a href="https://corefork.telegram.org/method/channels.setStickers"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/channels.setStickers#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Supergroup</param>
		/// <param name="stickerset">The stickerset to associate</param>
		public static Task<bool> Channels_SetStickers(this Client client, InputChannelBase channel, InputStickerSet stickerset)
			=> client.Invoke(new Channels_SetStickers
			{
				channel = channel,
				stickerset = stickerset,
			});

		/// <summary>Mark <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> message contents as read		<para>See <a href="https://corefork.telegram.org/method/channels.readMessageContents"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/channels.readMessageContents#possible-errors">details</a>)</para></summary>
		/// <param name="channel"><a href="https://corefork.telegram.org/api/channel">Channel/supergroup</a></param>
		/// <param name="id">IDs of messages whose contents should be marked as read</param>
		public static Task<bool> Channels_ReadMessageContents(this Client client, InputChannelBase channel, params int[] id)
			=> client.Invoke(new Channels_ReadMessageContents
			{
				channel = channel,
				id = id,
			});

		/// <summary>Delete the history of a <a href="https://corefork.telegram.org/api/channel">supergroup</a>		<para>See <a href="https://corefork.telegram.org/method/channels.deleteHistory"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.deleteHistory#possible-errors">details</a>)</para></summary>
		/// <param name="for_everyone">Whether the history should be deleted for everyone</param>
		/// <param name="channel"><a href="https://corefork.telegram.org/api/channel">Supergroup</a> whose history must be deleted</param>
		/// <param name="max_id">ID of message <strong>up to which</strong> the history must be deleted</param>
		public static Task<UpdatesBase> Channels_DeleteHistory(this Client client, InputChannelBase channel, int max_id = default, bool for_everyone = false)
			=> client.Invoke(new Channels_DeleteHistory
			{
				flags = (Channels_DeleteHistory.Flags)(for_everyone ? 0x1 : 0),
				channel = channel,
				max_id = max_id,
			});

		/// <summary>Hide/unhide message history for new channel/supergroup users		<para>See <a href="https://corefork.telegram.org/method/channels.togglePreHistoryHidden"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.togglePreHistoryHidden#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Channel/supergroup</param>
		/// <param name="enabled">Hide/unhide</param>
		public static Task<UpdatesBase> Channels_TogglePreHistoryHidden(this Client client, InputChannelBase channel, bool enabled)
			=> client.Invoke(new Channels_TogglePreHistoryHidden
			{
				channel = channel,
				enabled = enabled,
			});

		/// <summary>Get a list of <a href="https://corefork.telegram.org/api/channel">channels/supergroups</a> we left, requires a <a href="https://corefork.telegram.org/api/takeout">takeout session, see here » for more info</a>.		<para>See <a href="https://corefork.telegram.org/method/channels.getLeftChannels"/></para>		<para>Possible <see cref="RpcException"/> codes: 403 (<a href="https://corefork.telegram.org/method/channels.getLeftChannels#possible-errors">details</a>)</para></summary>
		/// <param name="offset">Offset for <a href="https://corefork.telegram.org/api/offsets">pagination</a></param>
		public static Task<Messages_Chats> Channels_GetLeftChannels(this Client client, int offset = default)
			=> client.Invoke(new Channels_GetLeftChannels
			{
				offset = offset,
			});

		/// <summary>Get all groups that can be used as <a href="https://corefork.telegram.org/api/discussion">discussion groups</a>.		<para>See <a href="https://corefork.telegram.org/method/channels.getGroupsForDiscussion"/></para></summary>
		public static Task<Messages_Chats> Channels_GetGroupsForDiscussion(this Client client)
			=> client.Invoke(new Channels_GetGroupsForDiscussion
			{
			});

		/// <summary>Associate a group to a channel as <a href="https://corefork.telegram.org/api/discussion">discussion group</a> for that channel		<para>See <a href="https://corefork.telegram.org/method/channels.setDiscussionGroup"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/channels.setDiscussionGroup#possible-errors">details</a>)</para></summary>
		/// <param name="broadcast">Channel</param>
		/// <param name="group"><a href="https://corefork.telegram.org/api/discussion">Discussion group</a> to associate to the channel</param>
		public static Task<bool> Channels_SetDiscussionGroup(this Client client, InputChannelBase broadcast, InputChannelBase group)
			=> client.Invoke(new Channels_SetDiscussionGroup
			{
				broadcast = broadcast,
				group = group,
			});

		/// <summary>Transfer channel ownership		<para>See <a href="https://corefork.telegram.org/method/channels.editCreator"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/channels.editCreator#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Channel</param>
		/// <param name="user_id">New channel owner</param>
		/// <param name="password"><a href="https://corefork.telegram.org/api/srp">2FA password</a> of account</param>
		public static Task<UpdatesBase> Channels_EditCreator(this Client client, InputChannelBase channel, InputUserBase user_id, InputCheckPasswordSRP password)
			=> client.Invoke(new Channels_EditCreator
			{
				channel = channel,
				user_id = user_id,
				password = password,
			});

		/// <summary>Edit location of geogroup, see <a href="https://corefork.telegram.org/api/nearby">here »</a> for more info on geogroups.		<para>See <a href="https://corefork.telegram.org/method/channels.editLocation"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.editLocation#possible-errors">details</a>)</para></summary>
		/// <param name="channel"><a href="https://corefork.telegram.org/api/channel">Geogroup</a></param>
		/// <param name="geo_point">New geolocation</param>
		/// <param name="address">Address string</param>
		public static Task<bool> Channels_EditLocation(this Client client, InputChannelBase channel, InputGeoPoint geo_point, string address)
			=> client.Invoke(new Channels_EditLocation
			{
				channel = channel,
				geo_point = geo_point,
				address = address,
			});

		/// <summary>Toggle supergroup slow mode: if enabled, users will only be able to send one message every <c>seconds</c> seconds		<para>See <a href="https://corefork.telegram.org/method/channels.toggleSlowMode"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.toggleSlowMode#possible-errors">details</a>)</para></summary>
		/// <param name="channel">The <a href="https://corefork.telegram.org/api/channel">supergroup</a></param>
		/// <param name="seconds">Users will only be able to send one message every <c>seconds</c> seconds, <c>0</c> to disable the limitation</param>
		public static Task<UpdatesBase> Channels_ToggleSlowMode(this Client client, InputChannelBase channel, int seconds)
			=> client.Invoke(new Channels_ToggleSlowMode
			{
				channel = channel,
				seconds = seconds,
			});

		/// <summary>Get inactive channels and supergroups		<para>See <a href="https://corefork.telegram.org/method/channels.getInactiveChannels"/></para></summary>
		public static Task<Messages_InactiveChats> Channels_GetInactiveChannels(this Client client)
			=> client.Invoke(new Channels_GetInactiveChannels
			{
			});

		/// <summary>Convert a <a href="https://corefork.telegram.org/api/channel">supergroup</a> to a <a href="https://corefork.telegram.org/api/channel">gigagroup</a>, when requested by <a href="https://corefork.telegram.org/api/config#channel-suggestions">channel suggestions</a>.		<para>See <a href="https://corefork.telegram.org/method/channels.convertToGigagroup"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/channels.convertToGigagroup#possible-errors">details</a>)</para></summary>
		/// <param name="channel">The <a href="https://corefork.telegram.org/api/channel">supergroup</a> to convert</param>
		public static Task<UpdatesBase> Channels_ConvertToGigagroup(this Client client, InputChannelBase channel)
			=> client.Invoke(new Channels_ConvertToGigagroup
			{
				channel = channel,
			});

		/// <summary>Obtains a list of peers that can be used to send messages in a specific group		<para>See <a href="https://corefork.telegram.org/method/channels.getSendAs"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.getSendAs#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The group where we intend to send messages</param>
		public static Task<Channels_SendAsPeers> Channels_GetSendAs(this Client client, InputPeer peer, bool for_paid_reactions = false)
			=> client.Invoke(new Channels_GetSendAs
			{
				flags = (Channels_GetSendAs.Flags)(for_paid_reactions ? 0x1 : 0),
				peer = peer,
			});

		/// <summary>Delete all messages sent by a specific participant of a given supergroup		<para>See <a href="https://corefork.telegram.org/method/channels.deleteParticipantHistory"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/channels.deleteParticipantHistory#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Supergroup</param>
		/// <param name="participant">The participant whose messages should be deleted</param>
		public static Task<Messages_AffectedHistory> Channels_DeleteParticipantHistory(this Client client, InputChannelBase channel, InputPeer participant)
			=> client.InvokeAffected(new Channels_DeleteParticipantHistory
			{
				channel = channel,
				participant = participant,
			}, channel.ChannelId);

		/// <summary>Set whether all users <a href="https://corefork.telegram.org/api/discussion#requiring-users-to-join-the-group">should join a discussion group in order to comment on a post »</a>		<para>See <a href="https://corefork.telegram.org/method/channels.toggleJoinToSend"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.toggleJoinToSend#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Discussion group</param>
		/// <param name="enabled">Toggle</param>
		public static Task<UpdatesBase> Channels_ToggleJoinToSend(this Client client, InputChannelBase channel, bool enabled)
			=> client.Invoke(new Channels_ToggleJoinToSend
			{
				channel = channel,
				enabled = enabled,
			});

		/// <summary>Set whether all users should <a href="https://corefork.telegram.org/api/invites#join-requests">request admin approval to join the group »</a>.		<para>See <a href="https://corefork.telegram.org/method/channels.toggleJoinRequest"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.toggleJoinRequest#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Group</param>
		/// <param name="enabled">Toggle</param>
		public static Task<UpdatesBase> Channels_ToggleJoinRequest(this Client client, InputChannelBase channel, bool enabled)
			=> client.Invoke(new Channels_ToggleJoinRequest
			{
				channel = channel,
				enabled = enabled,
			});

		/// <summary>Reorder active usernames		<para>See <a href="https://corefork.telegram.org/method/channels.reorderUsernames"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.reorderUsernames#possible-errors">details</a>)</para></summary>
		/// <param name="channel">The supergroup or channel</param>
		/// <param name="order">The new order for active usernames. All active usernames must be specified.</param>
		public static Task<bool> Channels_ReorderUsernames(this Client client, InputChannelBase channel, params string[] order)
			=> client.Invoke(new Channels_ReorderUsernames
			{
				channel = channel,
				order = order,
			});

		/// <summary>Activate or deactivate a purchased <a href="https://fragment.com">fragment.com</a> username associated to a <a href="https://corefork.telegram.org/api/channel">supergroup or channel</a> we own.		<para>See <a href="https://corefork.telegram.org/method/channels.toggleUsername"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.toggleUsername#possible-errors">details</a>)</para></summary>
		/// <param name="channel"><a href="https://corefork.telegram.org/api/channel">Supergroup or channel</a></param>
		/// <param name="username">Username</param>
		/// <param name="active">Whether to activate or deactivate the username</param>
		public static Task<bool> Channels_ToggleUsername(this Client client, InputChannelBase channel, string username, bool active)
			=> client.Invoke(new Channels_ToggleUsername
			{
				channel = channel,
				username = username,
				active = active,
			});

		/// <summary>Disable all purchased usernames of a supergroup or channel		<para>See <a href="https://corefork.telegram.org/method/channels.deactivateAllUsernames"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.deactivateAllUsernames#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Supergroup or channel</param>
		public static Task<bool> Channels_DeactivateAllUsernames(this Client client, InputChannelBase channel)
			=> client.Invoke(new Channels_DeactivateAllUsernames
			{
				channel = channel,
			});

		/// <summary>Enable or disable <a href="https://corefork.telegram.org/api/forum">forum functionality</a> in a supergroup.		<para>See <a href="https://corefork.telegram.org/method/channels.toggleForum"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.toggleForum#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Supergroup ID</param>
		/// <param name="enabled">Enable or disable forum functionality</param>
		public static Task<UpdatesBase> Channels_ToggleForum(this Client client, InputChannelBase channel, bool enabled)
			=> client.Invoke(new Channels_ToggleForum
			{
				channel = channel,
				enabled = enabled,
			});

		/// <summary>Create a <a href="https://corefork.telegram.org/api/forum">forum topic</a>; requires <a href="https://corefork.telegram.org/api/rights"><c>manage_topics</c> rights</a>.		<para>See <a href="https://corefork.telegram.org/method/channels.createForumTopic"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/channels.createForumTopic#possible-errors">details</a>)</para></summary>
		/// <param name="channel"><a href="https://corefork.telegram.org/api/forum">The forum</a></param>
		/// <param name="title">Topic title (maximum UTF-8 length: 128)</param>
		/// <param name="icon_color">If no custom emoji icon is specified, specifies the color of the fallback topic icon (RGB), one of <c>0x6FB9F0</c>, <c>0xFFD67E</c>, <c>0xCB86DB</c>, <c>0x8EEE98</c>, <c>0xFF93B2</c>, or <c>0xFB6F5F</c>.</param>
		/// <param name="icon_emoji_id">ID of the <a href="https://corefork.telegram.org/api/custom-emoji">custom emoji</a> used as topic icon. <a href="https://corefork.telegram.org/api/premium">Telegram Premium</a> users can use any custom emoji, other users can only use the custom emojis contained in the <see cref="InputStickerSetEmojiDefaultTopicIcons"/> emoji pack.</param>
		/// <param name="random_id">Unique client message ID to prevent duplicate sending of the same event <para>You can use <see cref="WTelegram.Helpers.RandomLong"/></para></param>
		/// <param name="send_as">Create the topic as the specified peer</param>
		public static Task<UpdatesBase> Channels_CreateForumTopic(this Client client, InputChannelBase channel, string title, long random_id, int? icon_color = null, InputPeer send_as = null, long? icon_emoji_id = null)
			=> client.Invoke(new Channels_CreateForumTopic
			{
				flags = (Channels_CreateForumTopic.Flags)((icon_color != null ? 0x1 : 0) | (send_as != null ? 0x4 : 0) | (icon_emoji_id != null ? 0x8 : 0)),
				channel = channel,
				title = title,
				icon_color = icon_color ?? default,
				icon_emoji_id = icon_emoji_id ?? default,
				random_id = random_id,
				send_as = send_as,
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/forum">topics of a forum</a>		<para>See <a href="https://corefork.telegram.org/method/channels.getForumTopics"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.getForumTopics#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Supergroup</param>
		/// <param name="q">Search query</param>
		/// <param name="offset_date"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a>, date of the last message of the last found topic. Use 0 or any date in the future to get results from the last topic.</param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a>, ID of the last message of the last found topic (or initially <c>0</c>).</param>
		/// <param name="offset_topic"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a>, ID of the last found topic (or initially <c>0</c>).</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a>. For optimal performance, the number of returned topics is chosen by the server and can be smaller than the specified limit.</param>
		public static Task<Messages_ForumTopics> Channels_GetForumTopics(this Client client, InputChannelBase channel, DateTime offset_date = default, int offset_id = default, int offset_topic = default, int limit = int.MaxValue, string q = null)
			=> client.Invoke(new Channels_GetForumTopics
			{
				flags = (Channels_GetForumTopics.Flags)(q != null ? 0x1 : 0),
				channel = channel,
				q = q,
				offset_date = offset_date,
				offset_id = offset_id,
				offset_topic = offset_topic,
				limit = limit,
			});

		/// <summary>Get forum topics by their ID		<para>See <a href="https://corefork.telegram.org/method/channels.getForumTopicsByID"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.getForumTopicsByID#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Forum</param>
		/// <param name="topics">Topic IDs</param>
		public static Task<Messages_ForumTopics> Channels_GetForumTopicsByID(this Client client, InputChannelBase channel, params int[] topics)
			=> client.Invoke(new Channels_GetForumTopicsByID
			{
				channel = channel,
				topics = topics,
			});

		/// <summary>Edit <a href="https://corefork.telegram.org/api/forum">forum topic</a>; requires <a href="https://corefork.telegram.org/api/rights"><c>manage_topics</c> rights</a>.		<para>See <a href="https://corefork.telegram.org/method/channels.editForumTopic"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/channels.editForumTopic#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Supergroup</param>
		/// <param name="topic_id">Topic ID</param>
		/// <param name="title">If present, will update the topic title (maximum UTF-8 length: 128).</param>
		/// <param name="icon_emoji_id">If present, updates the <a href="https://corefork.telegram.org/api/custom-emoji">custom emoji</a> used as topic icon. <a href="https://corefork.telegram.org/api/premium">Telegram Premium</a> users can use any custom emoji, other users can only use the custom emojis contained in the <see cref="InputStickerSetEmojiDefaultTopicIcons"/> emoji pack. Pass 0 to switch to the fallback topic icon.</param>
		/// <param name="closed">If present, will update the open/closed status of the topic.</param>
		/// <param name="hidden">If present, will hide/unhide the topic (only valid for the "General" topic, <c>id=1</c>).</param>
		public static Task<UpdatesBase> Channels_EditForumTopic(this Client client, InputChannelBase channel, int topic_id, string title = null, long? icon_emoji_id = null, bool? closed = default, bool? hidden = default)
			=> client.Invoke(new Channels_EditForumTopic
			{
				flags = (Channels_EditForumTopic.Flags)((title != null ? 0x1 : 0) | (icon_emoji_id != null ? 0x2 : 0) | (closed != default ? 0x4 : 0) | (hidden != default ? 0x8 : 0)),
				channel = channel,
				topic_id = topic_id,
				title = title,
				icon_emoji_id = icon_emoji_id ?? default,
				closed = closed ?? default,
				hidden = hidden ?? default,
			});

		/// <summary>Pin or unpin <a href="https://corefork.telegram.org/api/forum">forum topics</a>		<para>See <a href="https://corefork.telegram.org/method/channels.updatePinnedForumTopic"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.updatePinnedForumTopic#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Supergroup ID</param>
		/// <param name="topic_id"><a href="https://corefork.telegram.org/api/forum">Forum topic ID</a></param>
		/// <param name="pinned">Whether to pin or unpin the topic</param>
		public static Task<UpdatesBase> Channels_UpdatePinnedForumTopic(this Client client, InputChannelBase channel, int topic_id, bool pinned)
			=> client.Invoke(new Channels_UpdatePinnedForumTopic
			{
				channel = channel,
				topic_id = topic_id,
				pinned = pinned,
			});

		/// <summary>Delete message history of a <a href="https://corefork.telegram.org/api/forum">forum topic</a>		<para>See <a href="https://corefork.telegram.org/method/channels.deleteTopicHistory"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.deleteTopicHistory#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Forum</param>
		/// <param name="top_msg_id">Topic ID</param>
		public static Task<Messages_AffectedHistory> Channels_DeleteTopicHistory(this Client client, InputChannelBase channel, int top_msg_id)
			=> client.InvokeAffected(new Channels_DeleteTopicHistory
			{
				channel = channel,
				top_msg_id = top_msg_id,
			}, channel.ChannelId);

		/// <summary>Reorder pinned forum topics		<para>See <a href="https://corefork.telegram.org/method/channels.reorderPinnedForumTopics"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.reorderPinnedForumTopics#possible-errors">details</a>)</para></summary>
		/// <param name="force">If not set, the order of only the topics present both server-side and in <c>order</c> will be changed (i.e. mentioning topics not pinned server-side in <c>order</c> will not pin them, and not mentioning topics pinned server-side will not unpin them).  <br/>If set, the entire server-side pinned topic list will be replaced with <c>order</c> (i.e. mentioning topics not pinned server-side in <c>order</c> will pin them, and not mentioning topics pinned server-side will unpin them)</param>
		/// <param name="channel">Supergroup ID</param>
		/// <param name="order"><a href="https://corefork.telegram.org/api/forum">Topic IDs »</a></param>
		public static Task<UpdatesBase> Channels_ReorderPinnedForumTopics(this Client client, InputChannelBase channel, int[] order, bool force = false)
			=> client.Invoke(new Channels_ReorderPinnedForumTopics
			{
				flags = (Channels_ReorderPinnedForumTopics.Flags)(force ? 0x1 : 0),
				channel = channel,
				order = order,
			});

		/// <summary>Enable or disable the <a href="https://corefork.telegram.org/api/antispam">native antispam system</a>.		<para>See <a href="https://corefork.telegram.org/method/channels.toggleAntiSpam"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.toggleAntiSpam#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Supergroup ID. The specified supergroup must have at least <c>telegram_antispam_group_size_min</c> members to enable antispam functionality, as specified by the <a href="https://corefork.telegram.org/api/config#client-configuration">client configuration parameters</a>.</param>
		/// <param name="enabled">Enable or disable the native antispam system.</param>
		public static Task<UpdatesBase> Channels_ToggleAntiSpam(this Client client, InputChannelBase channel, bool enabled)
			=> client.Invoke(new Channels_ToggleAntiSpam
			{
				channel = channel,
				enabled = enabled,
			});

		/// <summary>Report a <a href="https://corefork.telegram.org/api/antispam">native antispam</a> false positive		<para>See <a href="https://corefork.telegram.org/method/channels.reportAntiSpamFalsePositive"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.reportAntiSpamFalsePositive#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Supergroup ID</param>
		/// <param name="msg_id">Message ID that was mistakenly deleted by the <a href="https://corefork.telegram.org/api/antispam">native antispam</a> system, taken from the <a href="https://corefork.telegram.org/api/recent-actions">admin log</a></param>
		public static Task<bool> Channels_ReportAntiSpamFalsePositive(this Client client, InputChannelBase channel, int msg_id)
			=> client.Invoke(new Channels_ReportAntiSpamFalsePositive
			{
				channel = channel,
				msg_id = msg_id,
			});

		/// <summary>Hide or display the participants list in a <a href="https://corefork.telegram.org/api/channel">supergroup</a>.		<para>See <a href="https://corefork.telegram.org/method/channels.toggleParticipantsHidden"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.toggleParticipantsHidden#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Supergroup ID</param>
		/// <param name="enabled">If true, will hide the participants list; otherwise will unhide it.</param>
		public static Task<UpdatesBase> Channels_ToggleParticipantsHidden(this Client client, InputChannelBase channel, bool enabled)
			=> client.Invoke(new Channels_ToggleParticipantsHidden
			{
				channel = channel,
				enabled = enabled,
			});

		/// <summary>Update the <a href="https://corefork.telegram.org/api/colors">accent color and background custom emoji »</a> of a channel.		<para>See <a href="https://corefork.telegram.org/method/channels.updateColor"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.updateColor#possible-errors">details</a>)</para></summary>
		/// <param name="for_profile">Whether to change the accent color emoji pattern of the profile page; otherwise, the accent color and emoji pattern of messages will be changed. <br/>Channels can change both message and profile palettes; supergroups can only change the profile palette, of course after reaching the <a href="https://corefork.telegram.org/api/colors">appropriate boost level</a>.</param>
		/// <param name="channel">Channel whose accent color should be changed.</param>
		/// <param name="color"><a href="https://corefork.telegram.org/api/colors">ID of the accent color palette »</a> to use (not RGB24, see <a href="https://corefork.telegram.org/api/colors">here »</a> for more info); if not set, the default palette is used.</param>
		/// <param name="background_emoji_id">Custom emoji ID used in the accent color pattern.</param>
		public static Task<UpdatesBase> Channels_UpdateColor(this Client client, InputChannelBase channel, long? background_emoji_id = null, int? color = null, bool for_profile = false)
			=> client.Invoke(new Channels_UpdateColor
			{
				flags = (Channels_UpdateColor.Flags)((background_emoji_id != null ? 0x1 : 0) | (color != null ? 0x4 : 0) | (for_profile ? 0x2 : 0)),
				channel = channel,
				color = color ?? default,
				background_emoji_id = background_emoji_id ?? default,
			});

		/// <summary>Users may also choose to display messages from all topics of a <a href="https://corefork.telegram.org/api/forum">forum</a> as if they were sent to a normal group, using a "View as messages" setting in the local client: this setting only affects the current account, and is synced to other logged in sessions using this method.		<para>See <a href="https://corefork.telegram.org/method/channels.toggleViewForumAsMessages"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.toggleViewForumAsMessages#possible-errors">details</a>)</para></summary>
		/// <param name="channel">The forum</param>
		/// <param name="enabled">The new value of the <c>view_forum_as_messages</c> flag.</param>
		public static Task<UpdatesBase> Channels_ToggleViewForumAsMessages(this Client client, InputChannelBase channel, bool enabled)
			=> client.Invoke(new Channels_ToggleViewForumAsMessages
			{
				channel = channel,
				enabled = enabled,
			});

		/// <summary>Obtain a list of similarly themed public channels, selected based on similarities in their <strong>subscriber bases</strong>.		<para>See <a href="https://corefork.telegram.org/method/channels.getChannelRecommendations"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.getChannelRecommendations#possible-errors">details</a>)</para></summary>
		/// <param name="channel">The method will return channels related to the passed <c>channel</c>. If not set, the method will returns channels related to channels the user has joined.</param>
		public static Task<Messages_Chats> Channels_GetChannelRecommendations(this Client client, InputChannelBase channel = null)
			=> client.Invoke(new Channels_GetChannelRecommendations
			{
				flags = (Channels_GetChannelRecommendations.Flags)(channel != null ? 0x1 : 0),
				channel = channel,
			});

		/// <summary>Set an <a href="https://corefork.telegram.org/api/emoji-status">emoji status</a> for a channel or supergroup.		<para>See <a href="https://corefork.telegram.org/method/channels.updateEmojiStatus"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.updateEmojiStatus#possible-errors">details</a>)</para></summary>
		/// <param name="channel">The channel/supergroup, must have at least <a href="https://corefork.telegram.org/api/config#channel-emoji-status-level-min">channel_emoji_status_level_min</a>/<a href="https://corefork.telegram.org/api/config#group-emoji-status-level-min">group_emoji_status_level_min</a> boosts.</param>
		/// <param name="emoji_status"><a href="https://corefork.telegram.org/api/emoji-status">Emoji status</a> to set</param>
		public static Task<UpdatesBase> Channels_UpdateEmojiStatus(this Client client, InputChannelBase channel, EmojiStatusBase emoji_status)
			=> client.Invoke(new Channels_UpdateEmojiStatus
			{
				channel = channel,
				emoji_status = emoji_status,
			});

		/// <summary>Admins with <see cref="ChatAdminRights">ban_users admin rights »</see> may allow users that apply a certain number of <a href="https://corefork.telegram.org/api/boost">booosts »</a> to the group to bypass <see cref="Channels_ToggleSlowMode">Channels_ToggleSlowMode</see> and <a href="https://corefork.telegram.org/api/rights#default-rights">other »</a> supergroup restrictions, see <a href="https://corefork.telegram.org/api/boost#bypass-slowmode-and-chat-restrictions">here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/channels.setBoostsToUnblockRestrictions"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.setBoostsToUnblockRestrictions#possible-errors">details</a>)</para></summary>
		/// <param name="channel">The supergroup.</param>
		/// <param name="boosts">The number of required boosts (1-8, 0 to disable).</param>
		public static Task<UpdatesBase> Channels_SetBoostsToUnblockRestrictions(this Client client, InputChannelBase channel, int boosts)
			=> client.Invoke(new Channels_SetBoostsToUnblockRestrictions
			{
				channel = channel,
				boosts = boosts,
			});

		/// <summary>Set a <a href="https://corefork.telegram.org/api/custom-emoji">custom emoji stickerset</a> for supergroups. Only usable after reaching at least the <a href="https://corefork.telegram.org/api/boost">boost level »</a> specified in the <a href="https://corefork.telegram.org/api/config#group-emoji-stickers-level-min"><c>group_emoji_stickers_level_min</c> »</a> config parameter.		<para>See <a href="https://corefork.telegram.org/method/channels.setEmojiStickers"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.setEmojiStickers#possible-errors">details</a>)</para></summary>
		/// <param name="channel">The supergroup</param>
		/// <param name="stickerset">The custom emoji stickerset to associate to the supergroup</param>
		public static Task<bool> Channels_SetEmojiStickers(this Client client, InputChannelBase channel, InputStickerSet stickerset)
			=> client.Invoke(new Channels_SetEmojiStickers
			{
				channel = channel,
				stickerset = stickerset,
			});

		/// <summary>Disable ads on the specified channel, for all users.		<para>See <a href="https://corefork.telegram.org/method/channels.restrictSponsoredMessages"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.restrictSponsoredMessages#possible-errors">details</a>)</para></summary>
		/// <param name="channel">The channel.</param>
		/// <param name="restricted">Whether to disable or re-enable ads.</param>
		public static Task<UpdatesBase> Channels_RestrictSponsoredMessages(this Client client, InputChannelBase channel, bool restricted)
			=> client.Invoke(new Channels_RestrictSponsoredMessages
			{
				channel = channel,
				restricted = restricted,
			});

		/// <summary>Globally search for posts from public <a href="https://corefork.telegram.org/api/channel">channels »</a> (<em>including</em> those we aren't a member of) containing a specific hashtag.		<para>See <a href="https://corefork.telegram.org/method/channels.searchPosts"/></para></summary>
		/// <param name="hashtag">The hashtag to search, without the <c>#</c> character.</param>
		/// <param name="offset_rate">Initially 0, then set to the <see cref="Messages_MessagesSlice"><c>next_rate</c> parameter of messages.messagesSlice</see></param>
		/// <param name="offset_peer"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Messages_MessagesBase> Channels_SearchPosts(this Client client, string hashtag, int offset_rate = default, InputPeer offset_peer = null, int offset_id = default, int limit = int.MaxValue)
			=> client.Invoke(new Channels_SearchPosts
			{
				hashtag = hashtag,
				offset_rate = offset_rate,
				offset_peer = offset_peer,
				offset_id = offset_id,
				limit = limit,
			});

		/// <summary>Sends a custom request; for bots only		<para>See <a href="https://corefork.telegram.org/method/bots.sendCustomRequest"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/bots.sendCustomRequest#possible-errors">details</a>)</para></summary>
		/// <param name="custom_method">The method name</param>
		/// <param name="params_">JSON-serialized method parameters</param>
		public static Task<DataJSON> Bots_SendCustomRequest(this Client client, string custom_method, DataJSON params_)
			=> client.Invoke(new Bots_SendCustomRequest
			{
				custom_method = custom_method,
				params_ = params_,
			});

		/// <summary>Answers a custom query; for bots only		<para>See <a href="https://corefork.telegram.org/method/bots.answerWebhookJSONQuery"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/bots.answerWebhookJSONQuery#possible-errors">details</a>)</para></summary>
		/// <param name="query_id">Identifier of a custom query</param>
		/// <param name="data">JSON-serialized answer to the query</param>
		public static Task<bool> Bots_AnswerWebhookJSONQuery(this Client client, long query_id, DataJSON data)
			=> client.Invoke(new Bots_AnswerWebhookJSONQuery
			{
				query_id = query_id,
				data = data,
			});

		/// <summary>Set bot command list		<para>See <a href="https://corefork.telegram.org/method/bots.setBotCommands"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/bots.setBotCommands#possible-errors">details</a>)</para></summary>
		/// <param name="scope">Command scope</param>
		/// <param name="lang_code">Language code</param>
		/// <param name="commands">Bot commands</param>
		public static Task<bool> Bots_SetBotCommands(this Client client, BotCommandScope scope, string lang_code, params BotCommand[] commands)
			=> client.Invoke(new Bots_SetBotCommands
			{
				scope = scope,
				lang_code = lang_code,
				commands = commands,
			});

		/// <summary>Clear bot commands for the specified bot scope and language code		<para>See <a href="https://corefork.telegram.org/method/bots.resetBotCommands"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/bots.resetBotCommands#possible-errors">details</a>)</para></summary>
		/// <param name="scope">Command scope</param>
		/// <param name="lang_code">Language code</param>
		public static Task<bool> Bots_ResetBotCommands(this Client client, BotCommandScope scope, string lang_code)
			=> client.Invoke(new Bots_ResetBotCommands
			{
				scope = scope,
				lang_code = lang_code,
			});

		/// <summary>Obtain a list of bot commands for the specified bot scope and language code		<para>See <a href="https://corefork.telegram.org/method/bots.getBotCommands"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/bots.getBotCommands#possible-errors">details</a>)</para></summary>
		/// <param name="scope">Command scope</param>
		/// <param name="lang_code">Language code</param>
		public static Task<BotCommand[]> Bots_GetBotCommands(this Client client, BotCommandScope scope, string lang_code)
			=> client.Invoke(new Bots_GetBotCommands
			{
				scope = scope,
				lang_code = lang_code,
			});

		/// <summary>Sets the <a href="https://corefork.telegram.org/api/bots/menu">menu button action »</a> for a given user or for all users		<para>See <a href="https://corefork.telegram.org/method/bots.setBotMenuButton"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/bots.setBotMenuButton#possible-errors">details</a>)</para></summary>
		/// <param name="user_id">User ID</param>
		/// <param name="button">Bot menu button action</param>
		public static Task<bool> Bots_SetBotMenuButton(this Client client, InputUserBase user_id, BotMenuButtonBase button)
			=> client.Invoke(new Bots_SetBotMenuButton
			{
				user_id = user_id,
				button = button,
			});

		/// <summary>Gets the menu button action for a given user or for all users, previously set using <see cref="Bots_SetBotMenuButton">Bots_SetBotMenuButton</see>; users can see this information in the <see cref="BotInfo"/>.		<para>See <a href="https://corefork.telegram.org/method/bots.getBotMenuButton"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/bots.getBotMenuButton#possible-errors">details</a>)</para></summary>
		/// <param name="user_id">User ID or empty for the default menu button.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/botMenuButtonDefault">botMenuButtonDefault</a></returns>
		public static Task<BotMenuButtonBase> Bots_GetBotMenuButton(this Client client, InputUserBase user_id)
			=> client.Invoke(new Bots_GetBotMenuButton
			{
				user_id = user_id,
			});

		/// <summary>Set the default <a href="https://corefork.telegram.org/api/rights#suggested-bot-rights">suggested admin rights</a> for bots being added as admins to channels, see <a href="https://corefork.telegram.org/api/rights#suggested-bot-rights">here for more info on how to handle them »</a>.		<para>See <a href="https://corefork.telegram.org/method/bots.setBotBroadcastDefaultAdminRights"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/bots.setBotBroadcastDefaultAdminRights#possible-errors">details</a>)</para></summary>
		/// <param name="admin_rights">Admin rights</param>
		public static Task<bool> Bots_SetBotBroadcastDefaultAdminRights(this Client client, ChatAdminRights admin_rights)
			=> client.Invoke(new Bots_SetBotBroadcastDefaultAdminRights
			{
				admin_rights = admin_rights,
			});

		/// <summary>Set the default <a href="https://corefork.telegram.org/api/rights#suggested-bot-rights">suggested admin rights</a> for bots being added as admins to groups, see <a href="https://corefork.telegram.org/api/rights#suggested-bot-rights">here for more info on how to handle them »</a>.		<para>See <a href="https://corefork.telegram.org/method/bots.setBotGroupDefaultAdminRights"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/bots.setBotGroupDefaultAdminRights#possible-errors">details</a>)</para></summary>
		/// <param name="admin_rights">Admin rights</param>
		public static Task<bool> Bots_SetBotGroupDefaultAdminRights(this Client client, ChatAdminRights admin_rights)
			=> client.Invoke(new Bots_SetBotGroupDefaultAdminRights
			{
				admin_rights = admin_rights,
			});

		/// <summary>Set localized name, about text and description of a bot (or of the current account, if called by a bot).		<para>See <a href="https://corefork.telegram.org/method/bots.setBotInfo"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/bots.setBotInfo#possible-errors">details</a>)</para></summary>
		/// <param name="bot">If called by a user, <strong>must</strong> contain the peer of a bot we own.</param>
		/// <param name="lang_code">Language code, if left empty update the fallback about text and description</param>
		/// <param name="name">New bot name</param>
		/// <param name="about">New about text</param>
		/// <param name="description">New description</param>
		public static Task<bool> Bots_SetBotInfo(this Client client, string lang_code, string about = null, string description = null, InputUserBase bot = null, string name = null)
			=> client.Invoke(new Bots_SetBotInfo
			{
				flags = (Bots_SetBotInfo.Flags)((about != null ? 0x1 : 0) | (description != null ? 0x2 : 0) | (bot != null ? 0x4 : 0) | (name != null ? 0x8 : 0)),
				bot = bot,
				lang_code = lang_code,
				name = name,
				about = about,
				description = description,
			});

		/// <summary>Get localized name, about text and description of a bot (or of the current account, if called by a bot).		<para>See <a href="https://corefork.telegram.org/method/bots.getBotInfo"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/bots.getBotInfo#possible-errors">details</a>)</para></summary>
		/// <param name="bot">If called by a user, <strong>must</strong> contain the peer of a bot we own.</param>
		/// <param name="lang_code">Language code, if left empty this method will return the fallback about text and description.</param>
		public static Task<Bots_BotInfo> Bots_GetBotInfo(this Client client, string lang_code, InputUserBase bot = null)
			=> client.Invoke(new Bots_GetBotInfo
			{
				flags = (Bots_GetBotInfo.Flags)(bot != null ? 0x1 : 0),
				bot = bot,
				lang_code = lang_code,
			});

		/// <summary>Reorder usernames associated to a bot we own.		<para>See <a href="https://corefork.telegram.org/method/bots.reorderUsernames"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/bots.reorderUsernames#possible-errors">details</a>)</para></summary>
		/// <param name="bot">The bot</param>
		/// <param name="order">The new order for active usernames. All active usernames must be specified.</param>
		public static Task<bool> Bots_ReorderUsernames(this Client client, InputUserBase bot, params string[] order)
			=> client.Invoke(new Bots_ReorderUsernames
			{
				bot = bot,
				order = order,
			});

		/// <summary>Activate or deactivate a purchased <a href="https://fragment.com">fragment.com</a> username associated to a bot we own.		<para>See <a href="https://corefork.telegram.org/method/bots.toggleUsername"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/bots.toggleUsername#possible-errors">details</a>)</para></summary>
		/// <param name="bot">The bot</param>
		/// <param name="username">Username</param>
		/// <param name="active">Whether to activate or deactivate it</param>
		public static Task<bool> Bots_ToggleUsername(this Client client, InputUserBase bot, string username, bool active)
			=> client.Invoke(new Bots_ToggleUsername
			{
				bot = bot,
				username = username,
				active = active,
			});

		/// <summary>Check whether the specified bot can send us messages		<para>See <a href="https://corefork.telegram.org/method/bots.canSendMessage"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/bots.canSendMessage#possible-errors">details</a>)</para></summary>
		/// <param name="bot">The bot</param>
		public static Task<bool> Bots_CanSendMessage(this Client client, InputUserBase bot)
			=> client.Invoke(new Bots_CanSendMessage
			{
				bot = bot,
			});

		/// <summary>Allow the specified bot to send us messages		<para>See <a href="https://corefork.telegram.org/method/bots.allowSendMessage"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/bots.allowSendMessage#possible-errors">details</a>)</para></summary>
		/// <param name="bot">The bot</param>
		public static Task<UpdatesBase> Bots_AllowSendMessage(this Client client, InputUserBase bot)
			=> client.Invoke(new Bots_AllowSendMessage
			{
				bot = bot,
			});

		/// <summary>Send a custom request from a <a href="https://corefork.telegram.org/api/bots/webapps">mini bot app</a>, triggered by a <a href="https://corefork.telegram.org/api/web-events#web-app-invoke-custom-method">web_app_invoke_custom_method event »</a>.		<para>See <a href="https://corefork.telegram.org/method/bots.invokeWebViewCustomMethod"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/bots.invokeWebViewCustomMethod#possible-errors">details</a>)</para></summary>
		/// <param name="bot">Identifier of the bot associated to the <a href="https://corefork.telegram.org/api/bots/webapps">mini bot app</a></param>
		/// <param name="custom_method">Identifier of the custom method to invoke</param>
		/// <param name="params_">Method parameters</param>
		public static Task<DataJSON> Bots_InvokeWebViewCustomMethod(this Client client, InputUserBase bot, string custom_method, DataJSON params_)
			=> client.Invoke(new Bots_InvokeWebViewCustomMethod
			{
				bot = bot,
				custom_method = custom_method,
				params_ = params_,
			});

		/// <summary>Fetch popular <a href="https://corefork.telegram.org/api/bots/webapps#main-mini-apps">Main Mini Apps</a>, to be used in the <a href="https://corefork.telegram.org/api/search#apps-tab">apps tab of global search »</a>.		<para>See <a href="https://corefork.telegram.org/method/bots.getPopularAppBots"/></para></summary>
		/// <param name="offset">Offset for <a href="https://corefork.telegram.org/api/offsets">pagination</a>, initially an empty string, then re-use the <c>next_offset</c> returned by the previous query.</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Bots_PopularAppBots> Bots_GetPopularAppBots(this Client client, string offset, int limit = int.MaxValue)
			=> client.Invoke(new Bots_GetPopularAppBots
			{
				offset = offset,
				limit = limit,
			});

		/// <summary>Add a <a href="https://corefork.telegram.org/api/bots/webapps#main-mini-app-previews">main mini app preview, see here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/bots.addPreviewMedia"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/bots.addPreviewMedia#possible-errors">details</a>)</para></summary>
		/// <param name="bot">The bot that owns the Main Mini App.</param>
		/// <param name="lang_code">ISO 639-1 language code, indicating the localization of the preview to add.</param>
		/// <param name="media">The photo/video preview, uploaded using <see cref="Messages_UploadMedia">Messages_UploadMedia</see>.</param>
		public static Task<BotPreviewMedia> Bots_AddPreviewMedia(this Client client, InputUserBase bot, string lang_code, InputMedia media)
			=> client.Invoke(new Bots_AddPreviewMedia
			{
				bot = bot,
				lang_code = lang_code,
				media = media,
			});

		/// <summary>Edit a <a href="https://corefork.telegram.org/api/bots/webapps#main-mini-app-previews">main mini app preview, see here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/bots.editPreviewMedia"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/bots.editPreviewMedia#possible-errors">details</a>)</para></summary>
		/// <param name="bot">The bot that owns the Main Mini App.</param>
		/// <param name="lang_code">ISO 639-1 language code, indicating the localization of the preview to edit.</param>
		/// <param name="media">The photo/video preview to replace, previously fetched as specified <a href="https://corefork.telegram.org/api/bots/webapps#main-mini-app-previews">here »</a>.</param>
		/// <param name="new_media">The new photo/video preview, uploaded using <see cref="Messages_UploadMedia">Messages_UploadMedia</see>.</param>
		public static Task<BotPreviewMedia> Bots_EditPreviewMedia(this Client client, InputUserBase bot, string lang_code, InputMedia media, InputMedia new_media)
			=> client.Invoke(new Bots_EditPreviewMedia
			{
				bot = bot,
				lang_code = lang_code,
				media = media,
				new_media = new_media,
			});

		/// <summary>Delete a <a href="https://corefork.telegram.org/api/bots/webapps#main-mini-app-previews">main mini app preview, see here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/bots.deletePreviewMedia"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/bots.deletePreviewMedia#possible-errors">details</a>)</para></summary>
		/// <param name="bot">The bot that owns the Main Mini App.</param>
		/// <param name="lang_code">ISO 639-1 language code, indicating the localization of the preview to delete.</param>
		/// <param name="media">The photo/video preview to delete, previously fetched as specified <a href="https://corefork.telegram.org/api/bots/webapps#main-mini-app-previews">here »</a>.</param>
		public static Task<bool> Bots_DeletePreviewMedia(this Client client, InputUserBase bot, string lang_code, params InputMedia[] media)
			=> client.Invoke(new Bots_DeletePreviewMedia
			{
				bot = bot,
				lang_code = lang_code,
				media = media,
			});

		/// <summary>Reorder a <a href="https://corefork.telegram.org/api/bots/webapps#main-mini-app-previews">main mini app previews, see here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/bots.reorderPreviewMedias"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/bots.reorderPreviewMedias#possible-errors">details</a>)</para></summary>
		/// <param name="bot">The bot that owns the Main Mini App.</param>
		/// <param name="lang_code">ISO 639-1 language code, indicating the localization of the previews to reorder.</param>
		/// <param name="order">New order of the previews.</param>
		public static Task<bool> Bots_ReorderPreviewMedias(this Client client, InputUserBase bot, string lang_code, params InputMedia[] order)
			=> client.Invoke(new Bots_ReorderPreviewMedias
			{
				bot = bot,
				lang_code = lang_code,
				order = order,
			});

		/// <summary>Bot owners only, fetch <a href="https://corefork.telegram.org/api/bots/webapps#main-mini-app-previews">main mini app preview information, see here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/bots.getPreviewInfo"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/bots.getPreviewInfo#possible-errors">details</a>)</para></summary>
		/// <param name="bot">The bot that owns the Main Mini App.</param>
		/// <param name="lang_code">Fetch previews for the specified ISO 639-1 language code.</param>
		public static Task<Bots_PreviewInfo> Bots_GetPreviewInfo(this Client client, InputUserBase bot, string lang_code)
			=> client.Invoke(new Bots_GetPreviewInfo
			{
				bot = bot,
				lang_code = lang_code,
			});

		/// <summary>Fetch <a href="https://corefork.telegram.org/api/bots/webapps#main-mini-app-previews">main mini app previews, see here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/bots.getPreviewMedias"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/bots.getPreviewMedias#possible-errors">details</a>)</para></summary>
		/// <param name="bot">The bot that owns the Main Mini App.</param>
		public static Task<BotPreviewMedia[]> Bots_GetPreviewMedias(this Client client, InputUserBase bot)
			=> client.Invoke(new Bots_GetPreviewMedias
			{
				bot = bot,
			});

		/// <summary>Change the emoji status of a user (invoked by bots, see <a href="https://corefork.telegram.org/api/emoji-status#setting-an-emoji-status-from-a-bot">here »</a> for more info on the full flow)		<para>See <a href="https://corefork.telegram.org/method/bots.updateUserEmojiStatus"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/bots.updateUserEmojiStatus#possible-errors">details</a>)</para></summary>
		/// <param name="user_id">The user whose emoji status should be changed</param>
		/// <param name="emoji_status">The emoji status</param>
		public static Task<bool> Bots_UpdateUserEmojiStatus(this Client client, InputUserBase user_id, EmojiStatusBase emoji_status)
			=> client.Invoke(new Bots_UpdateUserEmojiStatus
			{
				user_id = user_id,
				emoji_status = emoji_status,
			});

		/// <summary>Allow or prevent a bot from <a href="https://corefork.telegram.org/api/emoji-status#setting-an-emoji-status-from-a-bot">changing our emoji status »</a>		<para>See <a href="https://corefork.telegram.org/method/bots.toggleUserEmojiStatusPermission"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/bots.toggleUserEmojiStatusPermission#possible-errors">details</a>)</para></summary>
		/// <param name="bot">The bot</param>
		/// <param name="enabled">Whether to allow or prevent the bot from changing our emoji status</param>
		public static Task<bool> Bots_ToggleUserEmojiStatusPermission(this Client client, InputUserBase bot, bool enabled)
			=> client.Invoke(new Bots_ToggleUserEmojiStatusPermission
			{
				bot = bot,
				enabled = enabled,
			});

		/// <summary>Check if a <a href="https://corefork.telegram.org/api/bots/webapps">mini app</a> can request the download of a specific file: called when handling <a href="https://corefork.telegram.org/api/web-events#web-app-request-file-download">web_app_request_file_download events »</a>		<para>See <a href="https://corefork.telegram.org/method/bots.checkDownloadFileParams"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/bots.checkDownloadFileParams#possible-errors">details</a>)</para></summary>
		/// <param name="bot">The bot that owns the <a href="https://corefork.telegram.org/api/bots/webapps">mini app</a> that requested the download</param>
		/// <param name="file_name">The <c>filename</c> from the <a href="https://corefork.telegram.org/api/web-events#web-app-request-file-download">web_app_request_file_download event »</a></param>
		/// <param name="url">The <c>url</c> from the <a href="https://corefork.telegram.org/api/web-events#web-app-request-file-download">web_app_request_file_download event »</a></param>
		public static Task<bool> Bots_CheckDownloadFileParams(this Client client, InputUserBase bot, string file_name, string url)
			=> client.Invoke(new Bots_CheckDownloadFileParams
			{
				bot = bot,
				file_name = file_name,
				url = url,
			});

		/// <summary>Get a list of bots owned by the current user		<para>See <a href="https://corefork.telegram.org/method/bots.getAdminedBots"/></para></summary>
		public static Task<UserBase[]> Bots_GetAdminedBots(this Client client)
			=> client.Invoke(new Bots_GetAdminedBots
			{
			});

		/// <summary>Create, edit or delete the <a href="https://corefork.telegram.org/api/bots/referrals">affiliate program</a> of a bot we own		<para>See <a href="https://corefork.telegram.org/method/bots.updateStarRefProgram"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/bots.updateStarRefProgram#possible-errors">details</a>)</para></summary>
		/// <param name="bot">The bot</param>
		/// <param name="commission_permille">The permille commission rate: it indicates the share of Telegram Stars received by affiliates for every transaction made by users they referred inside of the bot.  <br/>  The minimum and maximum values for this parameter are contained in the <a href="https://corefork.telegram.org/api/config#starref-min-commission-permille">starref_min_commission_permille</a> and <a href="https://corefork.telegram.org/api/config#starref-max-commission-permille">starref_max_commission_permille</a> client configuration parameters. <br/>  Can be <c>0</c> to terminate the affiliate program.<br/>  Both the duration and the commission may only be raised after creation of the program: to lower them, the program must first be terminated and a new one created.</param>
		/// <param name="duration_months">Indicates the duration of the affiliate program; if not set, there is no expiration date.</param>
		public static Task<StarRefProgram> Bots_UpdateStarRefProgram(this Client client, InputUserBase bot, int commission_permille, int? duration_months = null)
			=> client.Invoke(new Bots_UpdateStarRefProgram
			{
				flags = (Bots_UpdateStarRefProgram.Flags)(duration_months != null ? 0x1 : 0),
				bot = bot,
				commission_permille = commission_permille,
				duration_months = duration_months ?? default,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/bots.setCustomVerification"/></para></summary>
		public static Task<bool> Bots_SetCustomVerification(this Client client, InputPeer peer, InputUserBase bot = null, string custom_description = null, bool enabled = false)
			=> client.Invoke(new Bots_SetCustomVerification
			{
				flags = (Bots_SetCustomVerification.Flags)((bot != null ? 0x1 : 0) | (custom_description != null ? 0x4 : 0) | (enabled ? 0x2 : 0)),
				bot = bot,
				peer = peer,
				custom_description = custom_description,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/bots.getBotRecommendations"/></para></summary>
		public static Task<Users_Users> Bots_GetBotRecommendations(this Client client, InputUserBase bot)
			=> client.Invoke(new Bots_GetBotRecommendations
			{
				bot = bot,
			});

		/// <summary>Get a payment form		<para>See <a href="https://corefork.telegram.org/method/payments.getPaymentForm"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.getPaymentForm#possible-errors">details</a>)</para></summary>
		/// <param name="invoice">Invoice</param>
		/// <param name="theme_params"><a href="https://corefork.telegram.org/api/bots/webapps#theme-parameters">Theme parameters »</a></param>
		public static Task<Payments_PaymentFormBase> Payments_GetPaymentForm(this Client client, InputInvoice invoice, DataJSON theme_params = null)
			=> client.Invoke(new Payments_GetPaymentForm
			{
				flags = (Payments_GetPaymentForm.Flags)(theme_params != null ? 0x1 : 0),
				invoice = invoice,
				theme_params = theme_params,
			});

		/// <summary>Get payment receipt		<para>See <a href="https://corefork.telegram.org/method/payments.getPaymentReceipt"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.getPaymentReceipt#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The peer where the payment receipt was sent</param>
		/// <param name="msg_id">Message ID of receipt</param>
		public static Task<Payments_PaymentReceiptBase> Payments_GetPaymentReceipt(this Client client, InputPeer peer, int msg_id)
			=> client.Invoke(new Payments_GetPaymentReceipt
			{
				peer = peer,
				msg_id = msg_id,
			});

		/// <summary>Submit requested order information for validation		<para>See <a href="https://corefork.telegram.org/method/payments.validateRequestedInfo"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.validateRequestedInfo#possible-errors">details</a>)</para></summary>
		/// <param name="save">Save order information to re-use it for future orders</param>
		/// <param name="invoice">Invoice</param>
		/// <param name="info">Requested order information</param>
		public static Task<Payments_ValidatedRequestedInfo> Payments_ValidateRequestedInfo(this Client client, InputInvoice invoice, PaymentRequestedInfo info, bool save = false)
			=> client.Invoke(new Payments_ValidateRequestedInfo
			{
				flags = (Payments_ValidateRequestedInfo.Flags)(save ? 0x1 : 0),
				invoice = invoice,
				info = info,
			});

		/// <summary>Send compiled payment form		<para>See <a href="https://corefork.telegram.org/method/payments.sendPaymentForm"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.sendPaymentForm#possible-errors">details</a>)</para></summary>
		/// <param name="form_id">Form ID</param>
		/// <param name="invoice">Invoice</param>
		/// <param name="requested_info_id">ID of saved and validated <see cref="Payments_ValidatedRequestedInfo">order info</see></param>
		/// <param name="shipping_option_id">Chosen shipping option ID</param>
		/// <param name="credentials">Payment credentials</param>
		/// <param name="tip_amount">Tip, in the smallest units of the currency (integer, not float/double). For example, for a price of <c>US$ 1.45</c> pass <c>amount = 145</c>. See the exp parameter in <a href="https://corefork.telegram.org/bots/payments/currencies.json">currencies.json</a>, it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).</param>
		public static Task<Payments_PaymentResultBase> Payments_SendPaymentForm(this Client client, long form_id, InputInvoice invoice, InputPaymentCredentialsBase credentials, string requested_info_id = null, string shipping_option_id = null, long? tip_amount = null)
			=> client.Invoke(new Payments_SendPaymentForm
			{
				flags = (Payments_SendPaymentForm.Flags)((requested_info_id != null ? 0x1 : 0) | (shipping_option_id != null ? 0x2 : 0) | (tip_amount != null ? 0x4 : 0)),
				form_id = form_id,
				invoice = invoice,
				requested_info_id = requested_info_id,
				shipping_option_id = shipping_option_id,
				credentials = credentials,
				tip_amount = tip_amount ?? default,
			});

		/// <summary>Get saved payment information		<para>See <a href="https://corefork.telegram.org/method/payments.getSavedInfo"/></para></summary>
		public static Task<Payments_SavedInfo> Payments_GetSavedInfo(this Client client)
			=> client.Invoke(new Payments_GetSavedInfo
			{
			});

		/// <summary>Clear saved payment information		<para>See <a href="https://corefork.telegram.org/method/payments.clearSavedInfo"/></para></summary>
		/// <param name="credentials">Remove saved payment credentials</param>
		/// <param name="info">Clear the last order settings saved by the user</param>
		public static Task<bool> Payments_ClearSavedInfo(this Client client, bool credentials = false, bool info = false)
			=> client.Invoke(new Payments_ClearSavedInfo
			{
				flags = (Payments_ClearSavedInfo.Flags)((credentials ? 0x1 : 0) | (info ? 0x2 : 0)),
			});

		/// <summary>Get info about a credit card		<para>See <a href="https://corefork.telegram.org/method/payments.getBankCardData"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.getBankCardData#possible-errors">details</a>)</para></summary>
		/// <param name="number">Credit card number</param>
		public static Task<Payments_BankCardData> Payments_GetBankCardData(this Client client, string number)
			=> client.Invoke(new Payments_GetBankCardData
			{
				number = number,
			});

		/// <summary>Generate an <a href="https://corefork.telegram.org/api/links#invoice-links">invoice deep link</a>		<para>See <a href="https://corefork.telegram.org/method/payments.exportInvoice"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.exportInvoice#possible-errors">details</a>)</para></summary>
		/// <param name="invoice_media">Invoice</param>
		public static Task<Payments_ExportedInvoice> Payments_ExportInvoice(this Client client, InputMedia invoice_media)
			=> client.Invoke(new Payments_ExportInvoice
			{
				invoice_media = invoice_media,
			});

		/// <summary>Informs server about a purchase made through the App Store: for official applications only.		<para>See <a href="https://corefork.telegram.org/method/payments.assignAppStoreTransaction"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.assignAppStoreTransaction#possible-errors">details</a>)</para></summary>
		/// <param name="receipt">Receipt</param>
		/// <param name="purpose">Payment purpose</param>
		public static Task<UpdatesBase> Payments_AssignAppStoreTransaction(this Client client, byte[] receipt, InputStorePaymentPurpose purpose)
			=> client.Invoke(new Payments_AssignAppStoreTransaction
			{
				receipt = receipt,
				purpose = purpose,
			});

		/// <summary>Informs server about a purchase made through the Play Store: for official applications only.		<para>See <a href="https://corefork.telegram.org/method/payments.assignPlayMarketTransaction"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.assignPlayMarketTransaction#possible-errors">details</a>)</para></summary>
		/// <param name="receipt">Receipt</param>
		/// <param name="purpose">Payment purpose</param>
		public static Task<UpdatesBase> Payments_AssignPlayMarketTransaction(this Client client, DataJSON receipt, InputStorePaymentPurpose purpose)
			=> client.Invoke(new Payments_AssignPlayMarketTransaction
			{
				receipt = receipt,
				purpose = purpose,
			});

		/// <summary>Checks whether Telegram Premium purchase is possible. Must be called before in-store Premium purchase, official apps only.		<para>See <a href="https://corefork.telegram.org/method/payments.canPurchasePremium"/></para>		<para>Possible <see cref="RpcException"/> codes: 406 (<a href="https://corefork.telegram.org/method/payments.canPurchasePremium#possible-errors">details</a>)</para></summary>
		/// <param name="purpose">Payment purpose</param>
		public static Task<bool> Payments_CanPurchasePremium(this Client client, InputStorePaymentPurpose purpose)
			=> client.Invoke(new Payments_CanPurchasePremium
			{
				purpose = purpose,
			});

		/// <summary>Obtain a list of Telegram Premium <a href="https://corefork.telegram.org/api/giveaways">giveaway/gift code »</a> options.		<para>See <a href="https://corefork.telegram.org/method/payments.getPremiumGiftCodeOptions"/></para></summary>
		/// <param name="boost_peer">The channel that will start the giveaway</param>
		public static Task<PremiumGiftCodeOption[]> Payments_GetPremiumGiftCodeOptions(this Client client, InputPeer boost_peer = null)
			=> client.Invoke(new Payments_GetPremiumGiftCodeOptions
			{
				flags = (Payments_GetPremiumGiftCodeOptions.Flags)(boost_peer != null ? 0x1 : 0),
				boost_peer = boost_peer,
			});

		/// <summary>Obtain information about a <a href="https://corefork.telegram.org/api/giveaways">Telegram Premium giftcode »</a>		<para>See <a href="https://corefork.telegram.org/method/payments.checkGiftCode"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.checkGiftCode#possible-errors">details</a>)</para></summary>
		/// <param name="slug">The giftcode to check</param>
		public static Task<Payments_CheckedGiftCode> Payments_CheckGiftCode(this Client client, string slug)
			=> client.Invoke(new Payments_CheckGiftCode
			{
				slug = slug,
			});

		/// <summary>Apply a <a href="https://corefork.telegram.org/api/giveaways">Telegram Premium giftcode »</a>		<para>See <a href="https://corefork.telegram.org/method/payments.applyGiftCode"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,420 (<a href="https://corefork.telegram.org/method/payments.applyGiftCode#possible-errors">details</a>)</para></summary>
		/// <param name="slug">The code to apply</param>
		public static Task<UpdatesBase> Payments_ApplyGiftCode(this Client client, string slug)
			=> client.Invoke(new Payments_ApplyGiftCode
			{
				slug = slug,
			});

		/// <summary>Obtain information about a <a href="https://corefork.telegram.org/api/giveaways">Telegram Premium giveaway »</a>.		<para>See <a href="https://corefork.telegram.org/method/payments.getGiveawayInfo"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.getGiveawayInfo#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The peer where the giveaway was posted.</param>
		/// <param name="msg_id">Message ID of the <see cref="MessageActionGiveawayLaunch"/> service message</param>
		public static Task<Payments_GiveawayInfoBase> Payments_GetGiveawayInfo(this Client client, InputPeer peer, int msg_id)
			=> client.Invoke(new Payments_GetGiveawayInfo
			{
				peer = peer,
				msg_id = msg_id,
			});

		/// <summary>Launch a <a href="https://corefork.telegram.org/api/giveaways">prepaid giveaway »</a>.		<para>See <a href="https://corefork.telegram.org/method/payments.launchPrepaidGiveaway"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.launchPrepaidGiveaway#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The peer where to launch the giveaway.</param>
		/// <param name="giveaway_id">The prepaid giveaway ID.</param>
		/// <param name="purpose">Giveway parameters</param>
		public static Task<UpdatesBase> Payments_LaunchPrepaidGiveaway(this Client client, InputPeer peer, long giveaway_id, InputStorePaymentPurpose purpose)
			=> client.Invoke(new Payments_LaunchPrepaidGiveaway
			{
				peer = peer,
				giveaway_id = giveaway_id,
				purpose = purpose,
			});

		/// <summary>Obtain a list of <a href="https://corefork.telegram.org/api/stars#buying-or-gifting-stars">Telegram Stars topup options »</a> as <see cref="StarsTopupOption"/>s.		<para>See <a href="https://corefork.telegram.org/method/payments.getStarsTopupOptions"/></para></summary>
		public static Task<StarsTopupOption[]> Payments_GetStarsTopupOptions(this Client client)
			=> client.Invoke(new Payments_GetStarsTopupOptions
			{
			});

		/// <summary>Get the current <a href="https://corefork.telegram.org/api/stars">Telegram Stars balance</a> of the current account (with peer=<see cref="InputPeerSelf"/>), or the stars balance of the bot specified in <c>peer</c>.		<para>See <a href="https://corefork.telegram.org/method/payments.getStarsStatus"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.getStarsStatus#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer of which to get the balance.</param>
		public static Task<Payments_StarsStatus> Payments_GetStarsStatus(this Client client, InputPeer peer)
			=> client.Invoke(new Payments_GetStarsStatus
			{
				peer = peer,
			});

		/// <summary>Fetch <a href="https://corefork.telegram.org/api/stars#balance-and-transaction-history">Telegram Stars transactions</a>.		<para>See <a href="https://corefork.telegram.org/method/payments.getStarsTransactions"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.getStarsTransactions#possible-errors">details</a>)</para></summary>
		/// <param name="inbound">If set, fetches only incoming transactions.</param>
		/// <param name="outbound">If set, fetches only outgoing transactions.</param>
		/// <param name="ascending">Return transactions in ascending order by date (instead of descending order by date).</param>
		/// <param name="subscription_id">If set, fetches only transactions for the specified <a href="https://corefork.telegram.org/api/stars#star-subscriptions">Telegram Star subscription »</a>.</param>
		/// <param name="peer">Fetch the transaction history of the peer (<see cref="InputPeerSelf"/> or a bot we own).</param>
		/// <param name="offset"><a href="https://corefork.telegram.org/api/offsets">Offset for pagination, obtained from the returned <c>next_offset</c>, initially an empty string »</a>.</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Payments_StarsStatus> Payments_GetStarsTransactions(this Client client, InputPeer peer, string offset, int limit = int.MaxValue, string subscription_id = null, bool inbound = false, bool outbound = false, bool ascending = false)
			=> client.Invoke(new Payments_GetStarsTransactions
			{
				flags = (Payments_GetStarsTransactions.Flags)((subscription_id != null ? 0x8 : 0) | (inbound ? 0x1 : 0) | (outbound ? 0x2 : 0) | (ascending ? 0x4 : 0)),
				subscription_id = subscription_id,
				peer = peer,
				offset = offset,
				limit = limit,
			});

		/// <summary>Make a payment using <a href="https://corefork.telegram.org/api/stars#using-stars">Telegram Stars, see here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/payments.sendStarsForm"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.sendStarsForm#possible-errors">details</a>)</para></summary>
		/// <param name="form_id">Payment form ID</param>
		/// <param name="invoice">Invoice</param>
		public static Task<Payments_PaymentResultBase> Payments_SendStarsForm(this Client client, long form_id, InputInvoice invoice)
			=> client.Invoke(new Payments_SendStarsForm
			{
				form_id = form_id,
				invoice = invoice,
			});

		/// <summary>Refund a <a href="https://corefork.telegram.org/api/stars">Telegram Stars</a> transaction, see <a href="https://corefork.telegram.org/api/payments#6-refunds">here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/payments.refundStarsCharge"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.refundStarsCharge#possible-errors">details</a>)</para></summary>
		/// <param name="user_id">User to refund.</param>
		/// <param name="charge_id">Transaction ID.</param>
		public static Task<UpdatesBase> Payments_RefundStarsCharge(this Client client, InputUserBase user_id, string charge_id)
			=> client.Invoke(new Payments_RefundStarsCharge
			{
				user_id = user_id,
				charge_id = charge_id,
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/stars">Telegram Star revenue statistics »</a>.		<para>See <a href="https://corefork.telegram.org/method/payments.getStarsRevenueStats"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.getStarsRevenueStats#possible-errors">details</a>)</para></summary>
		/// <param name="dark">Whether to enable dark theme for graph colors</param>
		/// <param name="peer">Get statistics for the specified bot, channel or ourselves (<see cref="InputPeerSelf"/>).</param>
		public static Task<Payments_StarsRevenueStats> Payments_GetStarsRevenueStats(this Client client, InputPeer peer, bool dark = false)
			=> client.Invoke(new Payments_GetStarsRevenueStats
			{
				flags = (Payments_GetStarsRevenueStats.Flags)(dark ? 0x1 : 0),
				peer = peer,
			});

		/// <summary>Withdraw funds from a channel or bot's <a href="https://corefork.telegram.org/api/stars#withdrawing-stars">star balance »</a>.		<para>See <a href="https://corefork.telegram.org/method/payments.getStarsRevenueWithdrawalUrl"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.getStarsRevenueWithdrawalUrl#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Channel or bot from which to withdraw funds.</param>
		/// <param name="stars">Amount of stars to withdraw.</param>
		/// <param name="password">2FA password, see <a href="https://corefork.telegram.org/api/srp#using-the-2fa-password">here »</a> for more info.</param>
		public static Task<Payments_StarsRevenueWithdrawalUrl> Payments_GetStarsRevenueWithdrawalUrl(this Client client, InputPeer peer, long stars, InputCheckPasswordSRP password)
			=> client.Invoke(new Payments_GetStarsRevenueWithdrawalUrl
			{
				peer = peer,
				stars = stars,
				password = password,
			});

		/// <summary>Returns a URL for a Telegram Ad platform account that can be used to set up advertisements for channel/bot in <c>peer</c>, paid using the Telegram Stars owned by the specified <c>peer</c>, see <a href="https://corefork.telegram.org/api/stars#paying-for-ads">here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/payments.getStarsRevenueAdsAccountUrl"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/payments.getStarsRevenueAdsAccountUrl#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Channel or bot that owns the stars.</param>
		public static Task<Payments_StarsRevenueAdsAccountUrl> Payments_GetStarsRevenueAdsAccountUrl(this Client client, InputPeer peer)
			=> client.Invoke(new Payments_GetStarsRevenueAdsAccountUrl
			{
				peer = peer,
			});

		/// <summary>Obtain info about <a href="https://corefork.telegram.org/api/stars#balance-and-transaction-history">Telegram Star transactions »</a> using specific transaction IDs.		<para>See <a href="https://corefork.telegram.org/method/payments.getStarsTransactionsByID"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.getStarsTransactionsByID#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Channel or bot.</param>
		/// <param name="id">Transaction IDs.</param>
		public static Task<Payments_StarsStatus> Payments_GetStarsTransactionsByID(this Client client, InputPeer peer, params InputStarsTransaction[] id)
			=> client.Invoke(new Payments_GetStarsTransactionsByID
			{
				peer = peer,
				id = id,
			});

		/// <summary>Obtain a list of <a href="https://corefork.telegram.org/api/stars#buying-or-gifting-stars">Telegram Stars gift options »</a> as <see cref="StarsGiftOption"/>s.		<para>See <a href="https://corefork.telegram.org/method/payments.getStarsGiftOptions"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.getStarsGiftOptions#possible-errors">details</a>)</para></summary>
		/// <param name="user_id">Receiver of the gift (optional).</param>
		public static Task<StarsGiftOption[]> Payments_GetStarsGiftOptions(this Client client, InputUserBase user_id = null)
			=> client.Invoke(new Payments_GetStarsGiftOptions
			{
				flags = (Payments_GetStarsGiftOptions.Flags)(user_id != null ? 0x1 : 0),
				user_id = user_id,
			});

		/// <summary>Obtain a list of active, expired or cancelled <a href="https://corefork.telegram.org/api/invites#paid-invite-links">Telegram Star subscriptions »</a>.		<para>See <a href="https://corefork.telegram.org/method/payments.getStarsSubscriptions"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.getStarsSubscriptions#possible-errors">details</a>)</para></summary>
		/// <param name="missing_balance">Whether to return only subscriptions expired due to an excessively low Telegram Star balance.</param>
		/// <param name="peer">Always pass <see cref="InputPeerSelf"/>.</param>
		/// <param name="offset">Offset for pagination, taken from <see cref="Payments_StarsStatus"/>.<c>subscriptions_next_offset</c>.</param>
		public static Task<Payments_StarsStatus> Payments_GetStarsSubscriptions(this Client client, InputPeer peer, string offset, bool missing_balance = false)
			=> client.Invoke(new Payments_GetStarsSubscriptions
			{
				flags = (Payments_GetStarsSubscriptions.Flags)(missing_balance ? 0x1 : 0),
				peer = peer,
				offset = offset,
			});

		/// <summary>Activate or deactivate a <a href="https://corefork.telegram.org/api/invites#paid-invite-links">Telegram Star subscription »</a>.		<para>See <a href="https://corefork.telegram.org/method/payments.changeStarsSubscription"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.changeStarsSubscription#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Always pass <see cref="InputPeerSelf"/>.</param>
		/// <param name="subscription_id">ID of the subscription.</param>
		/// <param name="canceled">Whether to cancel or reactivate the subscription.</param>
		public static Task<bool> Payments_ChangeStarsSubscription(this Client client, InputPeer peer, string subscription_id, bool? canceled = default)
			=> client.Invoke(new Payments_ChangeStarsSubscription
			{
				flags = (Payments_ChangeStarsSubscription.Flags)(canceled != default ? 0x1 : 0),
				peer = peer,
				subscription_id = subscription_id,
				canceled = canceled ?? default,
			});

		/// <summary>Re-join a private channel associated to an active <a href="https://corefork.telegram.org/api/invites#paid-invite-links">Telegram Star subscription »</a>.		<para>See <a href="https://corefork.telegram.org/method/payments.fulfillStarsSubscription"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.fulfillStarsSubscription#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Always pass <see cref="InputPeerSelf"/>.</param>
		/// <param name="subscription_id">ID of the subscription.</param>
		public static Task<bool> Payments_FulfillStarsSubscription(this Client client, InputPeer peer, string subscription_id)
			=> client.Invoke(new Payments_FulfillStarsSubscription
			{
				peer = peer,
				subscription_id = subscription_id,
			});

		/// <summary>Fetch a list of <a href="https://corefork.telegram.org/api/giveaways#star-giveaways">star giveaway options »</a>.		<para>See <a href="https://corefork.telegram.org/method/payments.getStarsGiveawayOptions"/></para></summary>
		public static Task<StarsGiveawayOption[]> Payments_GetStarsGiveawayOptions(this Client client)
			=> client.Invoke(new Payments_GetStarsGiveawayOptions
			{
			});

		/// <summary>Get a list of available <a href="https://corefork.telegram.org/api/gifts">gifts, see here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/payments.getStarGifts"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash used for caching, for more info click here</a>.<br/>The hash may be generated locally by using the <c>id</c>s of the returned or stored sticker <see cref="StarGift"/>s.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/payments.starGiftsNotModified">payments.starGiftsNotModified</a></returns>
		public static Task<Payments_StarGifts> Payments_GetStarGifts(this Client client, int hash = default)
			=> client.Invoke(new Payments_GetStarGifts
			{
				hash = hash,
			});

		/// <summary>Display or remove a <a href="https://corefork.telegram.org/api/gifts">received gift »</a> from our profile.		<para>See <a href="https://corefork.telegram.org/method/payments.saveStarGift"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.saveStarGift#possible-errors">details</a>)</para></summary>
		/// <param name="unsave">If set, hides the gift from our profile.</param>
		public static Task<bool> Payments_SaveStarGift(this Client client, InputSavedStarGift stargift, bool unsave = false)
			=> client.Invoke(new Payments_SaveStarGift
			{
				flags = (Payments_SaveStarGift.Flags)(unsave ? 0x1 : 0),
				stargift = stargift,
			});

		/// <summary>Convert a <a href="https://corefork.telegram.org/api/gifts">received gift »</a> into Telegram Stars: this will permanently destroy the gift, converting it into <see cref="StarGift"/>.<c>convert_stars</c> <a href="https://corefork.telegram.org/api/stars">Telegram Stars</a>, added to the user's balance.		<para>See <a href="https://corefork.telegram.org/method/payments.convertStarGift"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.convertStarGift#possible-errors">details</a>)</para></summary>
		public static Task<bool> Payments_ConvertStarGift(this Client client, InputSavedStarGift stargift)
			=> client.Invoke(new Payments_ConvertStarGift
			{
				stargift = stargift,
			});

		/// <summary>Cancel a <a href="https://corefork.telegram.org/api/subscriptions#bot-subscriptions">bot subscription</a>		<para>See <a href="https://corefork.telegram.org/method/payments.botCancelStarsSubscription"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.botCancelStarsSubscription#possible-errors">details</a>)</para></summary>
		/// <param name="restore">If <strong>not</strong> set, disables autorenewal of the subscriptions, and prevents the user from reactivating the subscription once the current period expires: a subscription cancelled by the bot will have the <see cref="StarsSubscription"/>.<c>bot_canceled</c> flag set.  <br/>The bot can can partially undo this operation by setting this flag: this will allow the user to reactivate the subscription.</param>
		/// <param name="user_id">The ID of the user whose subscription should be (un)cancelled</param>
		/// <param name="charge_id">The <c>provider_charge_id</c> from the <see cref="MessageActionPaymentSentMe"/> service message sent to the bot for the first subscription payment.</param>
		public static Task<bool> Payments_BotCancelStarsSubscription(this Client client, InputUserBase user_id, string charge_id, bool restore = false)
			=> client.Invoke(new Payments_BotCancelStarsSubscription
			{
				flags = (Payments_BotCancelStarsSubscription.Flags)(restore ? 0x1 : 0),
				user_id = user_id,
				charge_id = charge_id,
			});

		/// <summary>Fetch all affiliations we have created for a certain peer		<para>See <a href="https://corefork.telegram.org/method/payments.getConnectedStarRefBots"/></para></summary>
		/// <param name="peer">The affiliated peer</param>
		/// <param name="offset_date">If set, returns only results older than the specified unixtime</param>
		/// <param name="offset_link">Offset for <a href="https://corefork.telegram.org/api/offsets">pagination</a>, taken from the last returned <see cref="ConnectedBotStarRef"/>.<c>url</c> (initially empty)</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Payments_ConnectedStarRefBots> Payments_GetConnectedStarRefBots(this Client client, InputPeer peer, int limit = int.MaxValue, DateTime? offset_date = null, string offset_link = null)
			=> client.Invoke(new Payments_GetConnectedStarRefBots
			{
				flags = (Payments_GetConnectedStarRefBots.Flags)((offset_date != null ? 0x4 : 0) | (offset_link != null ? 0x4 : 0)),
				peer = peer,
				offset_date = offset_date ?? default,
				offset_link = offset_link,
				limit = limit,
			});

		/// <summary>Fetch info about a specific <a href="https://corefork.telegram.org/api/bots/referrals">bot affiliation »</a>		<para>See <a href="https://corefork.telegram.org/method/payments.getConnectedStarRefBot"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.getConnectedStarRefBot#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The affiliated peer</param>
		/// <param name="bot">The bot that offers the affiliate program</param>
		public static Task<Payments_ConnectedStarRefBots> Payments_GetConnectedStarRefBot(this Client client, InputPeer peer, InputUserBase bot)
			=> client.Invoke(new Payments_GetConnectedStarRefBot
			{
				peer = peer,
				bot = bot,
			});

		/// <summary>Obtain a list of suggested <a href="https://corefork.telegram.org/api/bots/webapps">mini apps</a> with available <a href="https://corefork.telegram.org/api/bots/referrals">affiliate programs</a>		<para>See <a href="https://corefork.telegram.org/method/payments.getSuggestedStarRefBots"/></para>		<para>Possible <see cref="RpcException"/> codes: 403 (<a href="https://corefork.telegram.org/method/payments.getSuggestedStarRefBots#possible-errors">details</a>)</para></summary>
		/// <param name="order_by_revenue">If set, orders results by the expected revenue</param>
		/// <param name="order_by_date">If set, orders results by the creation date of the affiliate program</param>
		/// <param name="peer">The peer that will become the affiliate: star commissions will be transferred to this peer's star balance.</param>
		/// <param name="offset">Offset for pagination, taken from <see cref="Payments_SuggestedStarRefBots"/>.<c>next_offset</c>, initially empty.</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Payments_SuggestedStarRefBots> Payments_GetSuggestedStarRefBots(this Client client, InputPeer peer, string offset, int limit = int.MaxValue, bool order_by_revenue = false, bool order_by_date = false)
			=> client.Invoke(new Payments_GetSuggestedStarRefBots
			{
				flags = (Payments_GetSuggestedStarRefBots.Flags)((order_by_revenue ? 0x1 : 0) | (order_by_date ? 0x2 : 0)),
				peer = peer,
				offset = offset,
				limit = limit,
			});

		/// <summary>Join a bot's <a href="https://corefork.telegram.org/api/bots/referrals#becoming-an-affiliate">affiliate program, becoming an affiliate »</a>		<para>See <a href="https://corefork.telegram.org/method/payments.connectStarRefBot"/></para></summary>
		/// <param name="peer">The peer that will become the affiliate: star commissions will be transferred to this peer's star balance.</param>
		/// <param name="bot">The bot that offers the affiliate program</param>
		public static Task<Payments_ConnectedStarRefBots> Payments_ConnectStarRefBot(this Client client, InputPeer peer, InputUserBase bot)
			=> client.Invoke(new Payments_ConnectStarRefBot
			{
				peer = peer,
				bot = bot,
			});

		/// <summary>Leave a bot's <a href="https://corefork.telegram.org/api/bots/referrals#becoming-an-affiliate">affiliate program »</a>		<para>See <a href="https://corefork.telegram.org/method/payments.editConnectedStarRefBot"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.editConnectedStarRefBot#possible-errors">details</a>)</para></summary>
		/// <param name="revoked">If set, leaves the bot's affiliate program</param>
		/// <param name="peer">The peer that was affiliated</param>
		/// <param name="link">The affiliate link to revoke</param>
		public static Task<Payments_ConnectedStarRefBots> Payments_EditConnectedStarRefBot(this Client client, InputPeer peer, string link, bool revoked = false)
			=> client.Invoke(new Payments_EditConnectedStarRefBot
			{
				flags = (Payments_EditConnectedStarRefBot.Flags)(revoked ? 0x1 : 0),
				peer = peer,
				link = link,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/payments.getStarGiftUpgradePreview"/></para></summary>
		public static Task<Payments_StarGiftUpgradePreview> Payments_GetStarGiftUpgradePreview(this Client client, long gift_id)
			=> client.Invoke(new Payments_GetStarGiftUpgradePreview
			{
				gift_id = gift_id,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/payments.upgradeStarGift"/></para></summary>
		public static Task<UpdatesBase> Payments_UpgradeStarGift(this Client client, InputSavedStarGift stargift, bool keep_original_details = false)
			=> client.Invoke(new Payments_UpgradeStarGift
			{
				flags = (Payments_UpgradeStarGift.Flags)(keep_original_details ? 0x1 : 0),
				stargift = stargift,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/payments.transferStarGift"/></para></summary>
		public static Task<UpdatesBase> Payments_TransferStarGift(this Client client, InputSavedStarGift stargift, InputPeer to_id)
			=> client.Invoke(new Payments_TransferStarGift
			{
				stargift = stargift,
				to_id = to_id,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/payments.getUniqueStarGift"/></para></summary>
		public static Task<Payments_UniqueStarGift> Payments_GetUniqueStarGift(this Client client, string slug)
			=> client.Invoke(new Payments_GetUniqueStarGift
			{
				slug = slug,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/payments.getSavedStarGifts"/></para></summary>
		public static Task<Payments_SavedStarGifts> Payments_GetSavedStarGifts(this Client client, InputPeer peer, string offset, int limit = int.MaxValue, bool exclude_unsaved = false, bool exclude_saved = false, bool exclude_unlimited = false, bool exclude_limited = false, bool exclude_unique = false, bool sort_by_value = false)
			=> client.Invoke(new Payments_GetSavedStarGifts
			{
				flags = (Payments_GetSavedStarGifts.Flags)((exclude_unsaved ? 0x1 : 0) | (exclude_saved ? 0x2 : 0) | (exclude_unlimited ? 0x4 : 0) | (exclude_limited ? 0x8 : 0) | (exclude_unique ? 0x10 : 0) | (sort_by_value ? 0x20 : 0)),
				peer = peer,
				offset = offset,
				limit = limit,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/payments.getSavedStarGift"/></para></summary>
		public static Task<Payments_SavedStarGifts> Payments_GetSavedStarGift(this Client client, params InputSavedStarGift[] stargift)
			=> client.Invoke(new Payments_GetSavedStarGift
			{
				stargift = stargift,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/payments.getStarGiftWithdrawalUrl"/></para></summary>
		public static Task<Payments_StarGiftWithdrawalUrl> Payments_GetStarGiftWithdrawalUrl(this Client client, InputSavedStarGift stargift, InputCheckPasswordSRP password)
			=> client.Invoke(new Payments_GetStarGiftWithdrawalUrl
			{
				stargift = stargift,
				password = password,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/payments.toggleChatStarGiftNotifications"/></para></summary>
		public static Task<bool> Payments_ToggleChatStarGiftNotifications(this Client client, InputPeer peer, bool enabled = false)
			=> client.Invoke(new Payments_ToggleChatStarGiftNotifications
			{
				flags = (Payments_ToggleChatStarGiftNotifications.Flags)(enabled ? 0x1 : 0),
				peer = peer,
			});

		/// <summary>Create a stickerset.		<para>See <a href="https://corefork.telegram.org/method/stickers.createStickerSet"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stickers.createStickerSet#possible-errors">details</a>)</para></summary>
		/// <param name="masks">Whether this is a mask stickerset</param>
		/// <param name="emojis">Whether this is a <a href="https://corefork.telegram.org/api/custom-emoji">custom emoji</a> stickerset.</param>
		/// <param name="text_color">Whether the color of TGS custom emojis contained in this set should be changed to the text color when used in messages, the accent color if used as emoji status, white on chat photos, or another appropriate color based on context. For custom emoji stickersets only.</param>
		/// <param name="user_id">Stickerset owner</param>
		/// <param name="title">Stickerset name, <c>1-64</c> chars</param>
		/// <param name="short_name">Short name of sticker set, to be used in <a href="https://corefork.telegram.org/api/links#stickerset-links">sticker deep links »</a>. Can contain only english letters, digits and underscores. Must begin with a letter, can't contain consecutive underscores and, <strong>if called by a bot</strong>, must end in <c>"_by_&lt;bot_username&gt;"</c>. <c>&lt;bot_username&gt;</c> is case insensitive. 1-64 characters.</param>
		/// <param name="thumb">Thumbnail</param>
		/// <param name="stickers">Stickers</param>
		/// <param name="software">Used when <a href="https://corefork.telegram.org/import-stickers">importing stickers using the sticker import SDKs</a>, specifies the name of the software that created the stickers</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.stickerSetNotModified">messages.stickerSetNotModified</a></returns>
		public static Task<Messages_StickerSet> Stickers_CreateStickerSet(this Client client, InputUserBase user_id, string title, string short_name, InputStickerSetItem[] stickers, InputDocument thumb = null, string software = null, bool masks = false, bool emojis = false, bool text_color = false)
			=> client.Invoke(new Stickers_CreateStickerSet
			{
				flags = (Stickers_CreateStickerSet.Flags)((thumb != null ? 0x4 : 0) | (software != null ? 0x8 : 0) | (masks ? 0x1 : 0) | (emojis ? 0x20 : 0) | (text_color ? 0x40 : 0)),
				user_id = user_id,
				title = title,
				short_name = short_name,
				thumb = thumb,
				stickers = stickers,
				software = software,
			});

		/// <summary>Remove a sticker from the set where it belongs. The sticker set must have been created by the current user/bot.		<para>See <a href="https://corefork.telegram.org/method/stickers.removeStickerFromSet"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stickers.removeStickerFromSet#possible-errors">details</a>)</para></summary>
		/// <param name="sticker">The sticker to remove</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.stickerSetNotModified">messages.stickerSetNotModified</a></returns>
		public static Task<Messages_StickerSet> Stickers_RemoveStickerFromSet(this Client client, InputDocument sticker)
			=> client.Invoke(new Stickers_RemoveStickerFromSet
			{
				sticker = sticker,
			});

		/// <summary>Changes the absolute position of a sticker in the set to which it belongs. The sticker set must have been created by the current user/bot.		<para>See <a href="https://corefork.telegram.org/method/stickers.changeStickerPosition"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stickers.changeStickerPosition#possible-errors">details</a>)</para></summary>
		/// <param name="sticker">The sticker</param>
		/// <param name="position">The new position of the sticker, zero-based</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.stickerSetNotModified">messages.stickerSetNotModified</a></returns>
		public static Task<Messages_StickerSet> Stickers_ChangeStickerPosition(this Client client, InputDocument sticker, int position)
			=> client.Invoke(new Stickers_ChangeStickerPosition
			{
				sticker = sticker,
				position = position,
			});

		/// <summary>Add a sticker to a stickerset. The sticker set must have been created by the current user/bot.		<para>See <a href="https://corefork.telegram.org/method/stickers.addStickerToSet"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/stickers.addStickerToSet#possible-errors">details</a>)</para></summary>
		/// <param name="stickerset">The stickerset</param>
		/// <param name="sticker">The sticker</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.stickerSetNotModified">messages.stickerSetNotModified</a></returns>
		public static Task<Messages_StickerSet> Stickers_AddStickerToSet(this Client client, InputStickerSet stickerset, InputStickerSetItem sticker)
			=> client.Invoke(new Stickers_AddStickerToSet
			{
				stickerset = stickerset,
				sticker = sticker,
			});

		/// <summary>Set stickerset thumbnail		<para>See <a href="https://corefork.telegram.org/method/stickers.setStickerSetThumb"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stickers.setStickerSetThumb#possible-errors">details</a>)</para></summary>
		/// <param name="stickerset">Stickerset</param>
		/// <param name="thumb">Thumbnail (only for normal stickersets, not custom emoji stickersets).</param>
		/// <param name="thumb_document_id">Only for <a href="https://corefork.telegram.org/api/custom-emoji">custom emoji stickersets</a>, ID of a custom emoji present in the set to use as thumbnail; pass 0 to fallback to the first custom emoji of the set.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.stickerSetNotModified">messages.stickerSetNotModified</a></returns>
		public static Task<Messages_StickerSet> Stickers_SetStickerSetThumb(this Client client, InputStickerSet stickerset, InputDocument thumb = null, long? thumb_document_id = null)
			=> client.Invoke(new Stickers_SetStickerSetThumb
			{
				flags = (Stickers_SetStickerSetThumb.Flags)((thumb != null ? 0x1 : 0) | (thumb_document_id != null ? 0x2 : 0)),
				stickerset = stickerset,
				thumb = thumb,
				thumb_document_id = thumb_document_id ?? default,
			});

		/// <summary>Check whether the given short name is available		<para>See <a href="https://corefork.telegram.org/method/stickers.checkShortName"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stickers.checkShortName#possible-errors">details</a>)</para></summary>
		/// <param name="short_name">Short name</param>
		public static Task<bool> Stickers_CheckShortName(this Client client, string short_name)
			=> client.Invoke(new Stickers_CheckShortName
			{
				short_name = short_name,
			});

		/// <summary>Suggests a short name for a given stickerpack name		<para>See <a href="https://corefork.telegram.org/method/stickers.suggestShortName"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stickers.suggestShortName#possible-errors">details</a>)</para></summary>
		/// <param name="title">Sticker pack name</param>
		public static Task<Stickers_SuggestedShortName> Stickers_SuggestShortName(this Client client, string title)
			=> client.Invoke(new Stickers_SuggestShortName
			{
				title = title,
			});

		/// <summary>Update the keywords, emojis or <a href="https://corefork.telegram.org/api/stickers#mask-stickers">mask coordinates</a> of a sticker.		<para>See <a href="https://corefork.telegram.org/method/stickers.changeSticker"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stickers.changeSticker#possible-errors">details</a>)</para></summary>
		/// <param name="sticker">The sticker</param>
		/// <param name="emoji">If set, updates the emoji list associated to the sticker</param>
		/// <param name="mask_coords">If set, updates the <a href="https://corefork.telegram.org/api/stickers#mask-stickers">mask coordinates</a></param>
		/// <param name="keywords">If set, updates the sticker keywords (separated by commas). Can't be provided for mask stickers.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.stickerSetNotModified">messages.stickerSetNotModified</a></returns>
		public static Task<Messages_StickerSet> Stickers_ChangeSticker(this Client client, InputDocument sticker, string emoji = null, MaskCoords mask_coords = null, string keywords = null)
			=> client.Invoke(new Stickers_ChangeSticker
			{
				flags = (Stickers_ChangeSticker.Flags)((emoji != null ? 0x1 : 0) | (mask_coords != null ? 0x2 : 0) | (keywords != null ? 0x4 : 0)),
				sticker = sticker,
				emoji = emoji,
				mask_coords = mask_coords,
				keywords = keywords,
			});

		/// <summary>Renames a stickerset.		<para>See <a href="https://corefork.telegram.org/method/stickers.renameStickerSet"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stickers.renameStickerSet#possible-errors">details</a>)</para></summary>
		/// <param name="stickerset">Stickerset to rename</param>
		/// <param name="title">New stickerset title</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.stickerSetNotModified">messages.stickerSetNotModified</a></returns>
		public static Task<Messages_StickerSet> Stickers_RenameStickerSet(this Client client, InputStickerSet stickerset, string title)
			=> client.Invoke(new Stickers_RenameStickerSet
			{
				stickerset = stickerset,
				title = title,
			});

		/// <summary>Deletes a stickerset we created.		<para>See <a href="https://corefork.telegram.org/method/stickers.deleteStickerSet"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stickers.deleteStickerSet#possible-errors">details</a>)</para></summary>
		/// <param name="stickerset">Stickerset to delete</param>
		public static Task<bool> Stickers_DeleteStickerSet(this Client client, InputStickerSet stickerset)
			=> client.Invoke(new Stickers_DeleteStickerSet
			{
				stickerset = stickerset,
			});

		/// <summary>Replace a sticker in a <a href="https://corefork.telegram.org/api/stickers">stickerset »</a>.		<para>See <a href="https://corefork.telegram.org/method/stickers.replaceSticker"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stickers.replaceSticker#possible-errors">details</a>)</para></summary>
		/// <param name="sticker">Old sticker document.</param>
		/// <param name="new_sticker">New sticker.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.stickerSetNotModified">messages.stickerSetNotModified</a></returns>
		public static Task<Messages_StickerSet> Stickers_ReplaceSticker(this Client client, InputDocument sticker, InputStickerSetItem new_sticker)
			=> client.Invoke(new Stickers_ReplaceSticker
			{
				sticker = sticker,
				new_sticker = new_sticker,
			});

		/// <summary>Get phone call configuration to be passed to libtgvoip's shared config		<para>See <a href="https://corefork.telegram.org/method/phone.getCallConfig"/></para></summary>
		public static Task<DataJSON> Phone_GetCallConfig(this Client client)
			=> client.Invoke(new Phone_GetCallConfig
			{
			});

		/// <summary>Start a telegram phone call		<para>See <a href="https://corefork.telegram.org/method/phone.requestCall"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/phone.requestCall#possible-errors">details</a>)</para></summary>
		/// <param name="video">Whether to start a video call</param>
		/// <param name="user_id">Destination of the phone call</param>
		/// <param name="random_id">Random ID to avoid resending the same object</param>
		/// <param name="g_a_hash"><a href="https://corefork.telegram.org/api/end-to-end/voice-calls">Parameter for E2E encryption key exchange »</a></param>
		/// <param name="protocol">Phone call settings</param>
		public static Task<Phone_PhoneCall> Phone_RequestCall(this Client client, InputUserBase user_id, int random_id, byte[] g_a_hash, PhoneCallProtocol protocol, InputGroupCall conference_call = null, bool video = false)
			=> client.Invoke(new Phone_RequestCall
			{
				flags = (Phone_RequestCall.Flags)((conference_call != null ? 0x2 : 0) | (video ? 0x1 : 0)),
				user_id = user_id,
				conference_call = conference_call,
				random_id = random_id,
				g_a_hash = g_a_hash,
				protocol = protocol,
			});

		/// <summary>Accept incoming call		<para>See <a href="https://corefork.telegram.org/method/phone.acceptCall"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406,500 (<a href="https://corefork.telegram.org/method/phone.acceptCall#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The call to accept</param>
		/// <param name="g_b"><a href="https://corefork.telegram.org/api/end-to-end/voice-calls">Parameter for E2E encryption key exchange »</a></param>
		/// <param name="protocol">Phone call settings</param>
		public static Task<Phone_PhoneCall> Phone_AcceptCall(this Client client, InputPhoneCall peer, byte[] g_b, PhoneCallProtocol protocol)
			=> client.Invoke(new Phone_AcceptCall
			{
				peer = peer,
				g_b = g_b,
				protocol = protocol,
			});

		/// <summary><a href="https://corefork.telegram.org/api/end-to-end/voice-calls">Complete phone call E2E encryption key exchange »</a>		<para>See <a href="https://corefork.telegram.org/method/phone.confirmCall"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/phone.confirmCall#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The phone call</param>
		/// <param name="g_a"><a href="https://corefork.telegram.org/api/end-to-end/voice-calls">Parameter for E2E encryption key exchange »</a></param>
		/// <param name="key_fingerprint">Key fingerprint</param>
		/// <param name="protocol">Phone call settings</param>
		public static Task<Phone_PhoneCall> Phone_ConfirmCall(this Client client, InputPhoneCall peer, byte[] g_a, long key_fingerprint, PhoneCallProtocol protocol)
			=> client.Invoke(new Phone_ConfirmCall
			{
				peer = peer,
				g_a = g_a,
				key_fingerprint = key_fingerprint,
				protocol = protocol,
			});

		/// <summary>Optional: notify the server that the user is currently busy in a call: this will automatically refuse all incoming phone calls until the current phone call is ended.		<para>See <a href="https://corefork.telegram.org/method/phone.receivedCall"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/phone.receivedCall#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The phone call we're currently in</param>
		public static Task<bool> Phone_ReceivedCall(this Client client, InputPhoneCall peer)
			=> client.Invoke(new Phone_ReceivedCall
			{
				peer = peer,
			});

		/// <summary>Refuse or end running call		<para>See <a href="https://corefork.telegram.org/method/phone.discardCall"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,500 (<a href="https://corefork.telegram.org/method/phone.discardCall#possible-errors">details</a>)</para></summary>
		/// <param name="video">Whether this is a video call</param>
		/// <param name="peer">The phone call</param>
		/// <param name="duration">Call duration</param>
		/// <param name="reason">Why was the call discarded</param>
		/// <param name="connection_id">Preferred libtgvoip relay ID</param>
		public static Task<UpdatesBase> Phone_DiscardCall(this Client client, InputPhoneCall peer, int duration, PhoneCallDiscardReason reason, long connection_id, bool video = false)
			=> client.Invoke(new Phone_DiscardCall
			{
				flags = (Phone_DiscardCall.Flags)(video ? 0x1 : 0),
				peer = peer,
				duration = duration,
				reason = reason,
				connection_id = connection_id,
			});

		/// <summary>Rate a call, returns info about the rating message sent to the official VoIP bot.		<para>See <a href="https://corefork.telegram.org/method/phone.setCallRating"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/phone.setCallRating#possible-errors">details</a>)</para></summary>
		/// <param name="user_initiative">Whether the user decided on their own initiative to rate the call</param>
		/// <param name="peer">The call to rate</param>
		/// <param name="rating">Rating in <c>1-5</c> stars</param>
		/// <param name="comment">An additional comment</param>
		public static Task<UpdatesBase> Phone_SetCallRating(this Client client, InputPhoneCall peer, int rating, string comment, bool user_initiative = false)
			=> client.Invoke(new Phone_SetCallRating
			{
				flags = (Phone_SetCallRating.Flags)(user_initiative ? 0x1 : 0),
				peer = peer,
				rating = rating,
				comment = comment,
			});

		/// <summary>Send phone call debug data to server		<para>See <a href="https://corefork.telegram.org/method/phone.saveCallDebug"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/phone.saveCallDebug#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Phone call</param>
		/// <param name="debug">Debug statistics obtained from libtgvoip</param>
		public static Task<bool> Phone_SaveCallDebug(this Client client, InputPhoneCall peer, DataJSON debug)
			=> client.Invoke(new Phone_SaveCallDebug
			{
				peer = peer,
				debug = debug,
			});

		/// <summary>Send VoIP signaling data		<para>See <a href="https://corefork.telegram.org/method/phone.sendSignalingData"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/phone.sendSignalingData#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Phone call</param>
		/// <param name="data">Signaling payload</param>
		public static Task<bool> Phone_SendSignalingData(this Client client, InputPhoneCall peer, byte[] data)
			=> client.Invoke(new Phone_SendSignalingData
			{
				peer = peer,
				data = data,
			});

		/// <summary>Create a group call or livestream		<para>See <a href="https://corefork.telegram.org/method/phone.createGroupCall"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/phone.createGroupCall#possible-errors">details</a>)</para></summary>
		/// <param name="rtmp_stream">Whether RTMP stream support should be enabled: only the <a href="https://corefork.telegram.org/api/channel">group/supergroup/channel</a> owner can use this flag.</param>
		/// <param name="peer">Associate the group call or livestream to the provided <a href="https://corefork.telegram.org/api/channel">group/supergroup/channel</a></param>
		/// <param name="random_id">Unique client message ID required to prevent creation of duplicate group calls</param>
		/// <param name="title">Call title</param>
		/// <param name="schedule_date">For scheduled group call or livestreams, the absolute date when the group call will start</param>
		public static Task<UpdatesBase> Phone_CreateGroupCall(this Client client, InputPeer peer, int random_id, string title = null, DateTime? schedule_date = null, bool rtmp_stream = false)
			=> client.Invoke(new Phone_CreateGroupCall
			{
				flags = (Phone_CreateGroupCall.Flags)((title != null ? 0x1 : 0) | (schedule_date != null ? 0x2 : 0) | (rtmp_stream ? 0x4 : 0)),
				peer = peer,
				random_id = random_id,
				title = title,
				schedule_date = schedule_date ?? default,
			});

		/// <summary>Join a group call		<para>See <a href="https://corefork.telegram.org/method/phone.joinGroupCall"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/phone.joinGroupCall#possible-errors">details</a>)</para></summary>
		/// <param name="muted">If set, the user will be muted by default upon joining.</param>
		/// <param name="video_stopped">If set, the user's video will be disabled by default upon joining.</param>
		/// <param name="call">The group call</param>
		/// <param name="join_as">Join the group call, presenting yourself as the specified user/channel</param>
		/// <param name="invite_hash">The invitation hash from the <a href="https://corefork.telegram.org/api/links#video-chat-livestream-links">invite link »</a>, if provided allows speaking in a livestream or muted group chat.</param>
		/// <param name="params_">WebRTC parameters</param>
		public static Task<UpdatesBase> Phone_JoinGroupCall(this Client client, InputGroupCall call, InputPeer join_as, DataJSON params_, string invite_hash = null, long? key_fingerprint = null, bool muted = false, bool video_stopped = false)
			=> client.Invoke(new Phone_JoinGroupCall
			{
				flags = (Phone_JoinGroupCall.Flags)((invite_hash != null ? 0x2 : 0) | (key_fingerprint != null ? 0x8 : 0) | (muted ? 0x1 : 0) | (video_stopped ? 0x4 : 0)),
				call = call,
				join_as = join_as,
				invite_hash = invite_hash,
				key_fingerprint = key_fingerprint ?? default,
				params_ = params_,
			});

		/// <summary>Leave a group call		<para>See <a href="https://corefork.telegram.org/method/phone.leaveGroupCall"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/phone.leaveGroupCall#possible-errors">details</a>)</para></summary>
		/// <param name="call">The group call</param>
		/// <param name="source">Your source ID</param>
		public static Task<UpdatesBase> Phone_LeaveGroupCall(this Client client, InputGroupCall call, int source)
			=> client.Invoke(new Phone_LeaveGroupCall
			{
				call = call,
				source = source,
			});

		/// <summary>Invite a set of users to a group call.		<para>See <a href="https://corefork.telegram.org/method/phone.inviteToGroupCall"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/phone.inviteToGroupCall#possible-errors">details</a>)</para></summary>
		/// <param name="call">The group call</param>
		/// <param name="users">The users to invite.</param>
		public static Task<UpdatesBase> Phone_InviteToGroupCall(this Client client, InputGroupCall call, params InputUserBase[] users)
			=> client.Invoke(new Phone_InviteToGroupCall
			{
				call = call,
				users = users,
			});

		/// <summary>Terminate a group call		<para>See <a href="https://corefork.telegram.org/method/phone.discardGroupCall"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/phone.discardGroupCall#possible-errors">details</a>)</para></summary>
		/// <param name="call">The group call to terminate</param>
		public static Task<UpdatesBase> Phone_DiscardGroupCall(this Client client, InputGroupCall call)
			=> client.Invoke(new Phone_DiscardGroupCall
			{
				call = call,
			});

		/// <summary>Change group call settings		<para>See <a href="https://corefork.telegram.org/method/phone.toggleGroupCallSettings"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/phone.toggleGroupCallSettings#possible-errors">details</a>)</para></summary>
		/// <param name="reset_invite_hash">Invalidate existing invite links</param>
		/// <param name="call">Group call</param>
		/// <param name="join_muted">Whether all users will that join this group call are muted by default upon joining the group call</param>
		public static Task<UpdatesBase> Phone_ToggleGroupCallSettings(this Client client, InputGroupCall call, bool? join_muted = default, bool reset_invite_hash = false)
			=> client.Invoke(new Phone_ToggleGroupCallSettings
			{
				flags = (Phone_ToggleGroupCallSettings.Flags)((join_muted != default ? 0x1 : 0) | (reset_invite_hash ? 0x2 : 0)),
				call = call,
				join_muted = join_muted ?? default,
			});

		/// <summary>Get info about a group call		<para>See <a href="https://corefork.telegram.org/method/phone.getGroupCall"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/phone.getGroupCall#possible-errors">details</a>)</para></summary>
		/// <param name="call">The group call</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Phone_GroupCall> Phone_GetGroupCall(this Client client, InputGroupCall call, int limit = int.MaxValue)
			=> client.Invoke(new Phone_GetGroupCall
			{
				call = call,
				limit = limit,
			});

		/// <summary>Get group call participants		<para>See <a href="https://corefork.telegram.org/method/phone.getGroupParticipants"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/phone.getGroupParticipants#possible-errors">details</a>)</para></summary>
		/// <param name="call">Group call</param>
		/// <param name="ids">If specified, will fetch group participant info about the specified peers</param>
		/// <param name="sources">If specified, will fetch group participant info about the specified WebRTC source IDs</param>
		/// <param name="offset">Offset for results, taken from the <c>next_offset</c> field of <see cref="Phone_GroupParticipants"/>, initially an empty string. <br/>Note: if no more results are available, the method call will return an empty <c>next_offset</c>; thus, avoid providing the <c>next_offset</c> returned in <see cref="Phone_GroupParticipants"/> if it is empty, to avoid an infinite loop.</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Phone_GroupParticipants> Phone_GetGroupParticipants(this Client client, InputGroupCall call, InputPeer[] ids, int[] sources, string offset, int limit = int.MaxValue)
			=> client.Invoke(new Phone_GetGroupParticipants
			{
				call = call,
				ids = ids,
				sources = sources,
				offset = offset,
				limit = limit,
			});

		/// <summary>Check whether the group call Server Forwarding Unit is currently receiving the streams with the specified WebRTC source IDs.<br/>Returns an intersection of the source IDs specified in <c>sources</c>, and the source IDs currently being forwarded by the SFU.		<para>See <a href="https://corefork.telegram.org/method/phone.checkGroupCall"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/phone.checkGroupCall#possible-errors">details</a>)</para></summary>
		/// <param name="call">Group call</param>
		/// <param name="sources">Source IDs</param>
		public static Task<int[]> Phone_CheckGroupCall(this Client client, InputGroupCall call, params int[] sources)
			=> client.Invoke(new Phone_CheckGroupCall
			{
				call = call,
				sources = sources,
			});

		/// <summary>Start or stop recording a group call: the recorded audio and video streams will be automatically sent to <c>Saved messages</c> (the chat with ourselves).		<para>See <a href="https://corefork.telegram.org/method/phone.toggleGroupCallRecord"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/phone.toggleGroupCallRecord#possible-errors">details</a>)</para></summary>
		/// <param name="start">Whether to start or stop recording</param>
		/// <param name="video">Whether to also record video streams</param>
		/// <param name="call">The group call or livestream</param>
		/// <param name="title">Recording title</param>
		/// <param name="video_portrait">If video stream recording is enabled, whether to record in portrait or landscape mode</param>
		public static Task<UpdatesBase> Phone_ToggleGroupCallRecord(this Client client, InputGroupCall call, string title = null, bool? video_portrait = default, bool start = false, bool video = false)
			=> client.Invoke(new Phone_ToggleGroupCallRecord
			{
				flags = (Phone_ToggleGroupCallRecord.Flags)((title != null ? 0x2 : 0) | (video_portrait != default ? 0x4 : 0) | (start ? 0x1 : 0) | (video ? 0x4 : 0)),
				call = call,
				title = title,
				video_portrait = video_portrait ?? default,
			});

		/// <summary>Edit information about a given group call participant		<para>See <a href="https://corefork.telegram.org/method/phone.editGroupCallParticipant"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/phone.editGroupCallParticipant#possible-errors">details</a>)</para></summary>
		/// <param name="call">The group call</param>
		/// <param name="participant">The group call participant (can also be the user itself)</param>
		/// <param name="muted">Whether to mute or unmute the specified participant</param>
		/// <param name="volume">New volume</param>
		/// <param name="raise_hand">Raise or lower hand</param>
		/// <param name="video_stopped">Start or stop the video stream</param>
		/// <param name="video_paused">Pause or resume the video stream</param>
		/// <param name="presentation_paused">Pause or resume the screen sharing stream</param>
		public static Task<UpdatesBase> Phone_EditGroupCallParticipant(this Client client, InputGroupCall call, InputPeer participant, bool? muted = default, int? volume = null, bool? raise_hand = default, bool? video_stopped = default, bool? video_paused = default, bool? presentation_paused = default)
			=> client.Invoke(new Phone_EditGroupCallParticipant
			{
				flags = (Phone_EditGroupCallParticipant.Flags)((muted != default ? 0x1 : 0) | (volume != null ? 0x2 : 0) | (raise_hand != default ? 0x4 : 0) | (video_stopped != default ? 0x8 : 0) | (video_paused != default ? 0x10 : 0) | (presentation_paused != default ? 0x20 : 0)),
				call = call,
				participant = participant,
				muted = muted ?? default,
				volume = volume ?? default,
				raise_hand = raise_hand ?? default,
				video_stopped = video_stopped ?? default,
				video_paused = video_paused ?? default,
				presentation_paused = presentation_paused ?? default,
			});

		/// <summary>Edit the title of a group call or livestream		<para>See <a href="https://corefork.telegram.org/method/phone.editGroupCallTitle"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/phone.editGroupCallTitle#possible-errors">details</a>)</para></summary>
		/// <param name="call">Group call</param>
		/// <param name="title">New title</param>
		public static Task<UpdatesBase> Phone_EditGroupCallTitle(this Client client, InputGroupCall call, string title)
			=> client.Invoke(new Phone_EditGroupCallTitle
			{
				call = call,
				title = title,
			});

		/// <summary>Get a list of peers that can be used to join a group call, presenting yourself as a specific user/channel.		<para>See <a href="https://corefork.telegram.org/method/phone.getGroupCallJoinAs"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/phone.getGroupCallJoinAs#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The dialog whose group call or livestream we're trying to join</param>
		public static Task<Phone_JoinAsPeers> Phone_GetGroupCallJoinAs(this Client client, InputPeer peer)
			=> client.Invoke(new Phone_GetGroupCallJoinAs
			{
				peer = peer,
			});

		/// <summary>Get an <a href="https://corefork.telegram.org/api/links#video-chat-livestream-links">invite link</a> for a group call or livestream		<para>See <a href="https://corefork.telegram.org/method/phone.exportGroupCallInvite"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/phone.exportGroupCallInvite#possible-errors">details</a>)</para></summary>
		/// <param name="can_self_unmute">For livestreams or muted group chats, if set, users that join using this link will be able to speak without explicitly requesting permission by (for example by raising their hand).</param>
		/// <param name="call">The group call</param>
		public static Task<Phone_ExportedGroupCallInvite> Phone_ExportGroupCallInvite(this Client client, InputGroupCall call, bool can_self_unmute = false)
			=> client.Invoke(new Phone_ExportGroupCallInvite
			{
				flags = (Phone_ExportGroupCallInvite.Flags)(can_self_unmute ? 0x1 : 0),
				call = call,
			});

		/// <summary>Subscribe or unsubscribe to a scheduled group call		<para>See <a href="https://corefork.telegram.org/method/phone.toggleGroupCallStartSubscription"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/phone.toggleGroupCallStartSubscription#possible-errors">details</a>)</para></summary>
		/// <param name="call">Scheduled group call</param>
		/// <param name="subscribed">Enable or disable subscription</param>
		public static Task<UpdatesBase> Phone_ToggleGroupCallStartSubscription(this Client client, InputGroupCall call, bool subscribed)
			=> client.Invoke(new Phone_ToggleGroupCallStartSubscription
			{
				call = call,
				subscribed = subscribed,
			});

		/// <summary>Start a scheduled group call.		<para>See <a href="https://corefork.telegram.org/method/phone.startScheduledGroupCall"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/phone.startScheduledGroupCall#possible-errors">details</a>)</para></summary>
		/// <param name="call">The scheduled group call</param>
		public static Task<UpdatesBase> Phone_StartScheduledGroupCall(this Client client, InputGroupCall call)
			=> client.Invoke(new Phone_StartScheduledGroupCall
			{
				call = call,
			});

		/// <summary>Set the default peer that will be used to join a group call in a specific dialog.		<para>See <a href="https://corefork.telegram.org/method/phone.saveDefaultGroupCallJoinAs"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/phone.saveDefaultGroupCallJoinAs#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The dialog</param>
		/// <param name="join_as">The default peer that will be used to join group calls in this dialog, presenting yourself as a specific user/channel.</param>
		public static Task<bool> Phone_SaveDefaultGroupCallJoinAs(this Client client, InputPeer peer, InputPeer join_as)
			=> client.Invoke(new Phone_SaveDefaultGroupCallJoinAs
			{
				peer = peer,
				join_as = join_as,
			});

		/// <summary>Start screen sharing in a call		<para>See <a href="https://corefork.telegram.org/method/phone.joinGroupCallPresentation"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/phone.joinGroupCallPresentation#possible-errors">details</a>)</para></summary>
		/// <param name="call">The group call</param>
		/// <param name="params_">WebRTC parameters</param>
		public static Task<UpdatesBase> Phone_JoinGroupCallPresentation(this Client client, InputGroupCall call, DataJSON params_)
			=> client.Invoke(new Phone_JoinGroupCallPresentation
			{
				call = call,
				params_ = params_,
			});

		/// <summary>Stop screen sharing in a group call		<para>See <a href="https://corefork.telegram.org/method/phone.leaveGroupCallPresentation"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/phone.leaveGroupCallPresentation#possible-errors">details</a>)</para></summary>
		/// <param name="call">The group call</param>
		public static Task<UpdatesBase> Phone_LeaveGroupCallPresentation(this Client client, InputGroupCall call)
			=> client.Invoke(new Phone_LeaveGroupCallPresentation
			{
				call = call,
			});

		/// <summary>Get info about RTMP streams in a group call or livestream.<br/>This method should be invoked to the same group/channel-related DC used for <a href="https://corefork.telegram.org/api/files#downloading-files">downloading livestream chunks</a>.<br/>As usual, the media DC is preferred, if available.		<para>See <a href="https://corefork.telegram.org/method/phone.getGroupCallStreamChannels"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/phone.getGroupCallStreamChannels#possible-errors">details</a>)</para></summary>
		/// <param name="call">Group call or livestream</param>
		public static Task<Phone_GroupCallStreamChannels> Phone_GetGroupCallStreamChannels(this Client client, InputGroupCall call)
			=> client.Invoke(new Phone_GetGroupCallStreamChannels
			{
				call = call,
			});

		/// <summary>Get RTMP URL and stream key for RTMP livestreams. Can be used even before creating the actual RTMP livestream with <see cref="Phone_CreateGroupCall">Phone_CreateGroupCall</see> (the <c>rtmp_stream</c> flag must be set).		<para>See <a href="https://corefork.telegram.org/method/phone.getGroupCallStreamRtmpUrl"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/phone.getGroupCallStreamRtmpUrl#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer to livestream into</param>
		/// <param name="revoke">Whether to revoke the previous stream key or simply return the existing one</param>
		public static Task<Phone_GroupCallStreamRtmpUrl> Phone_GetGroupCallStreamRtmpUrl(this Client client, InputPeer peer, bool revoke)
			=> client.Invoke(new Phone_GetGroupCallStreamRtmpUrl
			{
				peer = peer,
				revoke = revoke,
			});

		/// <summary>Save phone call debug information		<para>See <a href="https://corefork.telegram.org/method/phone.saveCallLog"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/phone.saveCallLog#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Phone call</param>
		/// <param name="file">Logs</param>
		public static Task<bool> Phone_SaveCallLog(this Client client, InputPhoneCall peer, InputFileBase file)
			=> client.Invoke(new Phone_SaveCallLog
			{
				peer = peer,
				file = file,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/phone.createConferenceCall"/></para></summary>
		public static Task<Phone_PhoneCall> Phone_CreateConferenceCall(this Client client, InputPhoneCall peer, long key_fingerprint)
			=> client.Invoke(new Phone_CreateConferenceCall
			{
				peer = peer,
				key_fingerprint = key_fingerprint,
			});

		/// <summary>Get localization pack strings		<para>See <a href="https://corefork.telegram.org/method/langpack.getLangPack"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/langpack.getLangPack#possible-errors">details</a>)</para></summary>
		/// <param name="lang_pack">Platform identifier (i.e. <c>android</c>, <c>tdesktop</c>, etc).</param>
		/// <param name="lang_code">Either an ISO 639-1 language code or a language pack name obtained from a <a href="https://corefork.telegram.org/api/links#language-pack-links">language pack link</a>.</param>
		public static Task<LangPackDifference> Langpack_GetLangPack(this Client client, string lang_pack, string lang_code)
			=> client.Invoke(new Langpack_GetLangPack
			{
				lang_pack = lang_pack,
				lang_code = lang_code,
			});

		/// <summary>Get strings from a language pack		<para>See <a href="https://corefork.telegram.org/method/langpack.getStrings"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/langpack.getStrings#possible-errors">details</a>)</para></summary>
		/// <param name="lang_pack">Platform identifier (i.e. <c>android</c>, <c>tdesktop</c>, etc).</param>
		/// <param name="lang_code">Either an ISO 639-1 language code or a language pack name obtained from a <a href="https://corefork.telegram.org/api/links#language-pack-links">language pack link</a>.</param>
		/// <param name="keys">Strings to get</param>
		public static Task<LangPackStringBase[]> Langpack_GetStrings(this Client client, string lang_pack, string lang_code, params string[] keys)
			=> client.Invoke(new Langpack_GetStrings
			{
				lang_pack = lang_pack,
				lang_code = lang_code,
				keys = keys,
			});

		/// <summary>Get new strings in language pack		<para>See <a href="https://corefork.telegram.org/method/langpack.getDifference"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/langpack.getDifference#possible-errors">details</a>)</para></summary>
		/// <param name="lang_pack">Platform identifier (i.e. <c>android</c>, <c>tdesktop</c>, etc).</param>
		/// <param name="lang_code">Either an ISO 639-1 language code or a language pack name obtained from a <a href="https://corefork.telegram.org/api/links#language-pack-links">language pack link</a>.</param>
		/// <param name="from_version">Previous localization pack version</param>
		public static Task<LangPackDifference> Langpack_GetDifference(this Client client, string lang_pack, string lang_code, int from_version)
			=> client.Invoke(new Langpack_GetDifference
			{
				lang_pack = lang_pack,
				lang_code = lang_code,
				from_version = from_version,
			});

		/// <summary>Get information about all languages in a localization pack		<para>See <a href="https://corefork.telegram.org/method/langpack.getLanguages"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/langpack.getLanguages#possible-errors">details</a>)</para></summary>
		/// <param name="lang_pack">Platform identifier (i.e. <c>android</c>, <c>tdesktop</c>, etc).</param>
		public static Task<LangPackLanguage[]> Langpack_GetLanguages(this Client client, string lang_pack)
			=> client.Invoke(new Langpack_GetLanguages
			{
				lang_pack = lang_pack,
			});

		/// <summary>Get information about a language in a localization pack		<para>See <a href="https://corefork.telegram.org/method/langpack.getLanguage"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/langpack.getLanguage#possible-errors">details</a>)</para></summary>
		/// <param name="lang_pack">Platform identifier (i.e. <c>android</c>, <c>tdesktop</c>, etc).</param>
		/// <param name="lang_code">Either an ISO 639-1 language code or a language pack name obtained from a <a href="https://corefork.telegram.org/api/links#language-pack-links">language pack link</a>.</param>
		public static Task<LangPackLanguage> Langpack_GetLanguage(this Client client, string lang_pack, string lang_code)
			=> client.Invoke(new Langpack_GetLanguage
			{
				lang_pack = lang_pack,
				lang_code = lang_code,
			});

		/// <summary>Edit peers in <a href="https://corefork.telegram.org/api/folders#peer-folders">peer folder</a>		<para>See <a href="https://corefork.telegram.org/method/folders.editPeerFolders"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/folders.editPeerFolders#possible-errors">details</a>)</para></summary>
		/// <param name="folder_peers">New peer list</param>
		public static Task<UpdatesBase> Folders_EditPeerFolders(this Client client, params InputFolderPeer[] folder_peers)
			=> client.Invoke(new Folders_EditPeerFolders
			{
				folder_peers = folder_peers,
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/stats">channel statistics</a>		<para>See <a href="https://corefork.telegram.org/method/stats.getBroadcastStats"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/stats.getBroadcastStats#possible-errors">details</a>)</para></summary>
		/// <param name="dark">Whether to enable dark theme for graph colors</param>
		/// <param name="channel">The channel</param>
		public static Task<Stats_BroadcastStats> Stats_GetBroadcastStats(this Client client, InputChannelBase channel, bool dark = false)
			=> client.Invoke(new Stats_GetBroadcastStats
			{
				flags = (Stats_GetBroadcastStats.Flags)(dark ? 0x1 : 0),
				channel = channel,
			});

		/// <summary>Load <a href="https://corefork.telegram.org/api/stats">channel statistics graph</a> asynchronously		<para>See <a href="https://corefork.telegram.org/method/stats.loadAsyncGraph"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stats.loadAsyncGraph#possible-errors">details</a>)</para></summary>
		/// <param name="token">Graph token from <see cref="StatsGraphAsync"/></param>
		/// <param name="x">Zoom value, if required</param>
		public static Task<StatsGraphBase> Stats_LoadAsyncGraph(this Client client, string token, long? x = null)
			=> client.Invoke(new Stats_LoadAsyncGraph
			{
				flags = (Stats_LoadAsyncGraph.Flags)(x != null ? 0x1 : 0),
				token = token,
				x = x ?? default,
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/stats">supergroup statistics</a>		<para>See <a href="https://corefork.telegram.org/method/stats.getMegagroupStats"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/stats.getMegagroupStats#possible-errors">details</a>)</para></summary>
		/// <param name="dark">Whether to enable dark theme for graph colors</param>
		/// <param name="channel"><a href="https://corefork.telegram.org/api/channel">Supergroup ID</a></param>
		public static Task<Stats_MegagroupStats> Stats_GetMegagroupStats(this Client client, InputChannelBase channel, bool dark = false)
			=> client.Invoke(new Stats_GetMegagroupStats
			{
				flags = (Stats_GetMegagroupStats.Flags)(dark ? 0x1 : 0),
				channel = channel,
			});

		/// <summary>Obtains a list of messages, indicating to which other public channels was a channel message forwarded.<br/>Will return a list of <see cref="Message">messages</see> with <c>peer_id</c> equal to the public channel to which this message was forwarded.		<para>See <a href="https://corefork.telegram.org/method/stats.getMessagePublicForwards"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stats.getMessagePublicForwards#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Source channel</param>
		/// <param name="msg_id">Source message ID</param>
		/// <param name="offset">Offset for <a href="https://corefork.telegram.org/api/offsets">pagination</a>, empty string on first call, then use the <c>next_offset</c> field of the returned constructor (if present, otherwise no more results are available).</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Stats_PublicForwards> Stats_GetMessagePublicForwards(this Client client, InputChannelBase channel, int msg_id, string offset, int limit = int.MaxValue)
			=> client.Invoke(new Stats_GetMessagePublicForwards
			{
				channel = channel,
				msg_id = msg_id,
				offset = offset,
				limit = limit,
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/stats">message statistics</a>		<para>See <a href="https://corefork.telegram.org/method/stats.getMessageStats"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stats.getMessageStats#possible-errors">details</a>)</para></summary>
		/// <param name="dark">Whether to enable dark theme for graph colors</param>
		/// <param name="channel">Channel ID</param>
		/// <param name="msg_id">Message ID</param>
		public static Task<Stats_MessageStats> Stats_GetMessageStats(this Client client, InputChannelBase channel, int msg_id, bool dark = false)
			=> client.Invoke(new Stats_GetMessageStats
			{
				flags = (Stats_GetMessageStats.Flags)(dark ? 0x1 : 0),
				channel = channel,
				msg_id = msg_id,
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/stats">statistics</a> for a certain <a href="https://corefork.telegram.org/api/stories">story</a>.		<para>See <a href="https://corefork.telegram.org/method/stats.getStoryStats"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stats.getStoryStats#possible-errors">details</a>)</para></summary>
		/// <param name="dark">Whether to enable the dark theme for graph colors</param>
		/// <param name="peer">The peer that posted the story</param>
		/// <param name="id">Story ID</param>
		public static Task<Stats_StoryStats> Stats_GetStoryStats(this Client client, InputPeer peer, int id, bool dark = false)
			=> client.Invoke(new Stats_GetStoryStats
			{
				flags = (Stats_GetStoryStats.Flags)(dark ? 0x1 : 0),
				peer = peer,
				id = id,
			});

		/// <summary>Obtain forwards of a <a href="https://corefork.telegram.org/api/stories">story</a> as a message to public chats and reposts by public channels.		<para>See <a href="https://corefork.telegram.org/method/stats.getStoryPublicForwards"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stats.getStoryPublicForwards#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer where the story was originally posted</param>
		/// <param name="id"><a href="https://corefork.telegram.org/api/stories">Story</a> ID</param>
		/// <param name="offset">Offset for pagination, from <see cref="Stats_PublicForwards"/>.<c>next_offset</c>.</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Stats_PublicForwards> Stats_GetStoryPublicForwards(this Client client, InputPeer peer, int id, string offset, int limit = int.MaxValue)
			=> client.Invoke(new Stats_GetStoryPublicForwards
			{
				peer = peer,
				id = id,
				offset = offset,
				limit = limit,
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/revenue">channel ad revenue statistics »</a>.		<para>See <a href="https://corefork.telegram.org/method/stats.getBroadcastRevenueStats"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stats.getBroadcastRevenueStats#possible-errors">details</a>)</para></summary>
		/// <param name="dark">Whether to enable dark theme for graph colors</param>
		/// <param name="peer">Get ad revenue stats for the specified channel or bot</param>
		public static Task<Stats_BroadcastRevenueStats> Stats_GetBroadcastRevenueStats(this Client client, InputPeer peer, bool dark = false)
			=> client.Invoke(new Stats_GetBroadcastRevenueStats
			{
				flags = (Stats_GetBroadcastRevenueStats.Flags)(dark ? 0x1 : 0),
				peer = peer,
			});

		/// <summary>Withdraw funds from a channel's <a href="https://corefork.telegram.org/api/revenue">ad revenue balance »</a>.		<para>See <a href="https://corefork.telegram.org/method/stats.getBroadcastRevenueWithdrawalUrl"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stats.getBroadcastRevenueWithdrawalUrl#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Get ad revenue withdrawal URL for the specified channel or bot</param>
		/// <param name="password">2FA password, see <a href="https://corefork.telegram.org/api/srp#using-the-2fa-password">here »</a> for more info.</param>
		public static Task<Stats_BroadcastRevenueWithdrawalUrl> Stats_GetBroadcastRevenueWithdrawalUrl(this Client client, InputPeer peer, InputCheckPasswordSRP password)
			=> client.Invoke(new Stats_GetBroadcastRevenueWithdrawalUrl
			{
				peer = peer,
				password = password,
			});

		/// <summary>Fetch <a href="https://corefork.telegram.org/api/revenue">channel ad revenue transaction history »</a>.		<para>See <a href="https://corefork.telegram.org/method/stats.getBroadcastRevenueTransactions"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stats.getBroadcastRevenueTransactions#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Get ad revenue transactions for the specified channel or bot</param>
		/// <param name="offset"><a href="https://corefork.telegram.org/api/offsets">Offset for pagination</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Stats_BroadcastRevenueTransactions> Stats_GetBroadcastRevenueTransactions(this Client client, InputPeer peer, int offset = default, int limit = int.MaxValue)
			=> client.Invoke(new Stats_GetBroadcastRevenueTransactions
			{
				peer = peer,
				offset = offset,
				limit = limit,
			});

		/// <summary>Export a <a href="https://corefork.telegram.org/api/folders">folder »</a>, creating a <a href="https://corefork.telegram.org/api/links#chat-folder-links">chat folder deep link »</a>.		<para>See <a href="https://corefork.telegram.org/method/chatlists.exportChatlistInvite"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/chatlists.exportChatlistInvite#possible-errors">details</a>)</para></summary>
		/// <param name="chatlist">The folder to export</param>
		/// <param name="title">An optional name for the link</param>
		/// <param name="peers">The list of channels, group and supergroups to share with the link. Basic groups will automatically be <a href="https://corefork.telegram.org/api/channel#migration">converted to supergroups</a> when invoking the method.</param>
		public static Task<Chatlists_ExportedChatlistInvite> Chatlists_ExportChatlistInvite(this Client client, InputChatlist chatlist, string title, params InputPeer[] peers)
			=> client.Invoke(new Chatlists_ExportChatlistInvite
			{
				chatlist = chatlist,
				title = title,
				peers = peers,
			});

		/// <summary>Delete a previously created <a href="https://corefork.telegram.org/api/links#chat-folder-links">chat folder deep link »</a>.		<para>See <a href="https://corefork.telegram.org/method/chatlists.deleteExportedInvite"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/chatlists.deleteExportedInvite#possible-errors">details</a>)</para></summary>
		/// <param name="chatlist">The related folder</param>
		/// <param name="slug"><c>slug</c> obtained from the <a href="https://corefork.telegram.org/api/links#chat-folder-links">chat folder deep link »</a>.</param>
		public static Task<bool> Chatlists_DeleteExportedInvite(this Client client, InputChatlist chatlist, string slug)
			=> client.Invoke(new Chatlists_DeleteExportedInvite
			{
				chatlist = chatlist,
				slug = slug,
			});

		/// <summary>Edit a <a href="https://corefork.telegram.org/api/links#chat-folder-links">chat folder deep link »</a>.		<para>See <a href="https://corefork.telegram.org/method/chatlists.editExportedInvite"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/chatlists.editExportedInvite#possible-errors">details</a>)</para></summary>
		/// <param name="chatlist">Folder ID</param>
		/// <param name="slug"><c>slug</c> obtained from the <a href="https://corefork.telegram.org/api/links#chat-folder-links">chat folder deep link »</a>.</param>
		/// <param name="title">If set, sets a new name for the link</param>
		/// <param name="peers">If set, changes the list of peers shared with the link</param>
		public static Task<ExportedChatlistInvite> Chatlists_EditExportedInvite(this Client client, InputChatlist chatlist, string slug, string title = null, InputPeer[] peers = null)
			=> client.Invoke(new Chatlists_EditExportedInvite
			{
				flags = (Chatlists_EditExportedInvite.Flags)((title != null ? 0x2 : 0) | (peers != null ? 0x4 : 0)),
				chatlist = chatlist,
				slug = slug,
				title = title,
				peers = peers,
			});

		/// <summary>List all <a href="https://corefork.telegram.org/api/links#chat-folder-links">chat folder deep links »</a> associated to a folder		<para>See <a href="https://corefork.telegram.org/method/chatlists.getExportedInvites"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/chatlists.getExportedInvites#possible-errors">details</a>)</para></summary>
		/// <param name="chatlist">The folder</param>
		public static Task<Chatlists_ExportedInvites> Chatlists_GetExportedInvites(this Client client, InputChatlist chatlist)
			=> client.Invoke(new Chatlists_GetExportedInvites
			{
				chatlist = chatlist,
			});

		/// <summary>Obtain information about a <a href="https://corefork.telegram.org/api/links#chat-folder-links">chat folder deep link »</a>.		<para>See <a href="https://corefork.telegram.org/method/chatlists.checkChatlistInvite"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/chatlists.checkChatlistInvite#possible-errors">details</a>)</para></summary>
		/// <param name="slug"><c>slug</c> obtained from the <a href="https://corefork.telegram.org/api/links#chat-folder-links">chat folder deep link »</a></param>
		public static Task<Chatlists_ChatlistInviteBase> Chatlists_CheckChatlistInvite(this Client client, string slug)
			=> client.Invoke(new Chatlists_CheckChatlistInvite
			{
				slug = slug,
			});

		/// <summary>Import a <a href="https://corefork.telegram.org/api/links#chat-folder-links">chat folder deep link »</a>, joining some or all the chats in the folder.		<para>See <a href="https://corefork.telegram.org/method/chatlists.joinChatlistInvite"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/chatlists.joinChatlistInvite#possible-errors">details</a>)</para></summary>
		/// <param name="slug"><c>slug</c> obtained from a <a href="https://corefork.telegram.org/api/links#chat-folder-links">chat folder deep link »</a>.</param>
		/// <param name="peers">List of new chats to join, fetched using <see cref="Chatlists_CheckChatlistInvite">Chatlists_CheckChatlistInvite</see> and filtered as specified in the <a href="https://corefork.telegram.org/api/folders#shared-folders">documentation »</a>.</param>
		public static Task<UpdatesBase> Chatlists_JoinChatlistInvite(this Client client, string slug, params InputPeer[] peers)
			=> client.Invoke(new Chatlists_JoinChatlistInvite
			{
				slug = slug,
				peers = peers,
			});

		/// <summary>Fetch new chats associated with an imported <a href="https://corefork.telegram.org/api/links#chat-folder-links">chat folder deep link »</a>. Must be invoked at most every <c>chatlist_update_period</c> seconds (as per the related <a href="https://corefork.telegram.org/api/config#chatlist-update-period">client configuration parameter »</a>).		<para>See <a href="https://corefork.telegram.org/method/chatlists.getChatlistUpdates"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/chatlists.getChatlistUpdates#possible-errors">details</a>)</para></summary>
		/// <param name="chatlist">The folder</param>
		public static Task<Chatlists_ChatlistUpdates> Chatlists_GetChatlistUpdates(this Client client, InputChatlist chatlist)
			=> client.Invoke(new Chatlists_GetChatlistUpdates
			{
				chatlist = chatlist,
			});

		/// <summary>Join channels and supergroups recently added to a <a href="https://corefork.telegram.org/api/links#chat-folder-links">chat folder deep link »</a>.		<para>See <a href="https://corefork.telegram.org/method/chatlists.joinChatlistUpdates"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/chatlists.joinChatlistUpdates#possible-errors">details</a>)</para></summary>
		/// <param name="chatlist">The folder</param>
		/// <param name="peers">List of new chats to join, fetched using <see cref="Chatlists_GetChatlistUpdates">Chatlists_GetChatlistUpdates</see> and filtered as specified in the <a href="https://corefork.telegram.org/api/folders#shared-folders">documentation »</a>.</param>
		public static Task<UpdatesBase> Chatlists_JoinChatlistUpdates(this Client client, InputChatlist chatlist, params InputPeer[] peers)
			=> client.Invoke(new Chatlists_JoinChatlistUpdates
			{
				chatlist = chatlist,
				peers = peers,
			});

		/// <summary>Dismiss new pending peers recently added to a <a href="https://corefork.telegram.org/api/links#chat-folder-links">chat folder deep link »</a>.		<para>See <a href="https://corefork.telegram.org/method/chatlists.hideChatlistUpdates"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/chatlists.hideChatlistUpdates#possible-errors">details</a>)</para></summary>
		/// <param name="chatlist">The folder</param>
		public static Task<bool> Chatlists_HideChatlistUpdates(this Client client, InputChatlist chatlist)
			=> client.Invoke(new Chatlists_HideChatlistUpdates
			{
				chatlist = chatlist,
			});

		/// <summary>Returns identifiers of pinned or always included chats from a chat folder imported using a <a href="https://corefork.telegram.org/api/links#chat-folder-links">chat folder deep link »</a>, which are suggested to be left when the chat folder is deleted.		<para>See <a href="https://corefork.telegram.org/method/chatlists.getLeaveChatlistSuggestions"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/chatlists.getLeaveChatlistSuggestions#possible-errors">details</a>)</para></summary>
		/// <param name="chatlist">Folder ID</param>
		public static Task<Peer[]> Chatlists_GetLeaveChatlistSuggestions(this Client client, InputChatlist chatlist)
			=> client.Invoke(new Chatlists_GetLeaveChatlistSuggestions
			{
				chatlist = chatlist,
			});

		/// <summary>Delete a folder imported using a <a href="https://corefork.telegram.org/api/links#chat-folder-links">chat folder deep link »</a>		<para>See <a href="https://corefork.telegram.org/method/chatlists.leaveChatlist"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/chatlists.leaveChatlist#possible-errors">details</a>)</para></summary>
		/// <param name="chatlist">Folder ID</param>
		/// <param name="peers">Also leave the specified channels and groups</param>
		public static Task<UpdatesBase> Chatlists_LeaveChatlist(this Client client, InputChatlist chatlist, params InputPeer[] peers)
			=> client.Invoke(new Chatlists_LeaveChatlist
			{
				chatlist = chatlist,
				peers = peers,
			});

		/// <summary>Check whether we can post stories as the specified peer.		<para>See <a href="https://corefork.telegram.org/method/stories.canSendStory"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stories.canSendStory#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The peer from which we wish to post stories.</param>
		public static Task<bool> Stories_CanSendStory(this Client client, InputPeer peer)
			=> client.Invoke(new Stories_CanSendStory
			{
				peer = peer,
			});

		/// <summary>Uploads a <a href="https://corefork.telegram.org/api/stories">Telegram Story</a>.		<para>See <a href="https://corefork.telegram.org/method/stories.sendStory"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stories.sendStory#possible-errors">details</a>)</para></summary>
		/// <param name="pinned">Whether to add the story to the profile automatically upon expiration. If not set, the story will only be added to the archive, see <a href="https://corefork.telegram.org/api/stories">here »</a> for more info.</param>
		/// <param name="noforwards">If set, disables forwards, screenshots, and downloads.</param>
		/// <param name="fwd_modified">Set this flag when reposting stories with <c>fwd_from_id</c>+<c>fwd_from_id</c>, if the <c>media</c> was modified before reposting.</param>
		/// <param name="peer">The peer to send the story as.</param>
		/// <param name="media">The story media.</param>
		/// <param name="media_areas"><a href="https://corefork.telegram.org/api/stories#media-areas">Media areas</a> associated to the story, see <a href="https://corefork.telegram.org/api/stories#media-areas">here »</a> for more info.</param>
		/// <param name="caption">Story caption.</param>
		/// <param name="entities"><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a>, if allowed by the <a href="https://corefork.telegram.org/api/config#stories-entities"><c>stories_entities</c> client configuration parameter »</a>.</param>
		/// <param name="privacy_rules"><a href="https://corefork.telegram.org/api/privacy">Privacy rules</a> for the story, indicating who can or can't view the story.</param>
		/// <param name="random_id">Unique client message ID required to prevent message resending. <para>You can use <see cref="WTelegram.Helpers.RandomLong"/></para></param>
		/// <param name="period">Period after which the story is moved to archive (and to the profile if <c>pinned</c> is set), in seconds; must be one of <c>6 * 3600</c>, <c>12 * 3600</c>, <c>86400</c>, or <c>2 * 86400</c> for Telegram Premium users, and <c>86400</c> otherwise.</param>
		/// <param name="fwd_from_id">If set, indicates that this story is a repost of story with ID <c>fwd_from_story</c> posted by the peer in <c>fwd_from_id</c>.</param>
		/// <param name="fwd_from_story">If set, indicates that this story is a repost of story with ID <c>fwd_from_story</c> posted by the peer in <c>fwd_from_id</c>.</param>
		public static Task<UpdatesBase> Stories_SendStory(this Client client, InputPeer peer, InputMedia media, InputPrivacyRule[] privacy_rules, long random_id, string caption = null, MessageEntity[] entities = null, int? period = null, MediaArea[] media_areas = null, InputPeer fwd_from_id = null, int? fwd_from_story = null, bool pinned = false, bool noforwards = false, bool fwd_modified = false)
			=> client.Invoke(new Stories_SendStory
			{
				flags = (Stories_SendStory.Flags)((caption != null ? 0x1 : 0) | (entities != null ? 0x2 : 0) | (period != null ? 0x8 : 0) | (media_areas != null ? 0x20 : 0) | (fwd_from_id != null ? 0x40 : 0) | (fwd_from_story != null ? 0x40 : 0) | (pinned ? 0x4 : 0) | (noforwards ? 0x10 : 0) | (fwd_modified ? 0x80 : 0)),
				peer = peer,
				media = media,
				media_areas = media_areas,
				caption = caption,
				entities = entities,
				privacy_rules = privacy_rules,
				random_id = random_id,
				period = period ?? default,
				fwd_from_id = fwd_from_id,
				fwd_from_story = fwd_from_story ?? default,
			});

		/// <summary>Edit an uploaded <a href="https://corefork.telegram.org/api/stories">story</a>		<para>See <a href="https://corefork.telegram.org/method/stories.editStory"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stories.editStory#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer where the story was posted.</param>
		/// <param name="id">ID of story to edit.</param>
		/// <param name="media">If specified, replaces the story media.</param>
		/// <param name="media_areas"><a href="https://corefork.telegram.org/api/stories#media-areas">Media areas</a> associated to the story, see <a href="https://corefork.telegram.org/api/stories#media-areas">here »</a> for more info.</param>
		/// <param name="caption">If specified, replaces the story caption.</param>
		/// <param name="entities"><a href="https://corefork.telegram.org/api/entities">Message entities for styled text in the caption</a>, if allowed by the <a href="https://corefork.telegram.org/api/config#stories-entities"><c>stories_entities</c> client configuration parameter »</a>.</param>
		/// <param name="privacy_rules">If specified, alters the <a href="https://corefork.telegram.org/api/privacy">privacy settings »</a> of the story, changing who can or can't view the story.</param>
		public static Task<UpdatesBase> Stories_EditStory(this Client client, InputPeer peer, int id, InputMedia media = null, string caption = null, MessageEntity[] entities = null, InputPrivacyRule[] privacy_rules = null, MediaArea[] media_areas = null)
			=> client.Invoke(new Stories_EditStory
			{
				flags = (Stories_EditStory.Flags)((media != null ? 0x1 : 0) | (caption != null ? 0x2 : 0) | (entities != null ? 0x2 : 0) | (privacy_rules != null ? 0x4 : 0) | (media_areas != null ? 0x8 : 0)),
				peer = peer,
				id = id,
				media = media,
				media_areas = media_areas,
				caption = caption,
				entities = entities,
				privacy_rules = privacy_rules,
			});

		/// <summary>Deletes some posted <a href="https://corefork.telegram.org/api/stories">stories</a>.		<para>See <a href="https://corefork.telegram.org/method/stories.deleteStories"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stories.deleteStories#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Channel/user from where to delete stories.</param>
		/// <param name="id">IDs of stories to delete.</param>
		public static Task<int[]> Stories_DeleteStories(this Client client, InputPeer peer, params int[] id)
			=> client.Invoke(new Stories_DeleteStories
			{
				peer = peer,
				id = id,
			});

		/// <summary>Pin or unpin one or more stories		<para>See <a href="https://corefork.telegram.org/method/stories.togglePinned"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stories.togglePinned#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer where to pin or unpin stories</param>
		/// <param name="id">IDs of stories to pin or unpin</param>
		/// <param name="pinned">Whether to pin or unpin the stories</param>
		public static Task<int[]> Stories_TogglePinned(this Client client, InputPeer peer, int[] id, bool pinned)
			=> client.Invoke(new Stories_TogglePinned
			{
				peer = peer,
				id = id,
				pinned = pinned,
			});

		/// <summary>Fetch the List of active (or active and hidden) stories, see <a href="https://corefork.telegram.org/api/stories#watching-stories">here »</a> for more info on watching stories.		<para>See <a href="https://corefork.telegram.org/method/stories.getAllStories"/></para></summary>
		/// <param name="next">If <c>next</c> and <c>state</c> are both set, uses the passed <c>state</c> to paginate to the next results; if neither <c>state</c> nor <c>next</c> are set, fetches the initial page; if <c>state</c> is set and <c>next</c> is not set, check for changes in the active/hidden peerset, see <a href="https://corefork.telegram.org/api/stories#watching-stories">here »</a> for more info on the full flow.</param>
		/// <param name="hidden">If set, fetches the hidden active story list, otherwise fetches the active story list, see <a href="https://corefork.telegram.org/api/stories#watching-stories">here »</a> for more info on the full flow.</param>
		/// <param name="state">If <c>next</c> and <c>state</c> are both set, uses the passed <c>state</c> to paginate to the next results; if neither <c>state</c> nor <c>next</c> are set, fetches the initial page; if <c>state</c> is set and <c>next</c> is not set, check for changes in the active/hidden peerset, see <a href="https://corefork.telegram.org/api/stories#watching-stories">here »</a> for more info on the full flow.</param>
		public static Task<Stories_AllStoriesBase> Stories_GetAllStories(this Client client, string state = null, bool next = false, bool hidden = false)
			=> client.Invoke(new Stories_GetAllStories
			{
				flags = (Stories_GetAllStories.Flags)((state != null ? 0x1 : 0) | (next ? 0x2 : 0) | (hidden ? 0x4 : 0)),
				state = state,
			});

		/// <summary>Fetch the <a href="https://corefork.telegram.org/api/stories#pinned-or-archived-stories">stories</a> pinned on a peer's profile.		<para>See <a href="https://corefork.telegram.org/method/stories.getPinnedStories"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stories.getPinnedStories#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer whose pinned stories should be fetched</param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Stories_Stories> Stories_GetPinnedStories(this Client client, InputPeer peer, int offset_id = default, int limit = int.MaxValue)
			=> client.Invoke(new Stories_GetPinnedStories
			{
				peer = peer,
				offset_id = offset_id,
				limit = limit,
			});

		/// <summary>Fetch the <a href="https://corefork.telegram.org/api/stories#pinned-or-archived-stories">story archive »</a> of a peer we control.		<para>See <a href="https://corefork.telegram.org/method/stories.getStoriesArchive"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stories.getStoriesArchive#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer whose archived stories should be fetched</param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Stories_Stories> Stories_GetStoriesArchive(this Client client, InputPeer peer, int offset_id = default, int limit = int.MaxValue)
			=> client.Invoke(new Stories_GetStoriesArchive
			{
				peer = peer,
				offset_id = offset_id,
				limit = limit,
			});

		/// <summary>Obtain full info about a set of <a href="https://corefork.telegram.org/api/stories">stories</a> by their IDs.		<para>See <a href="https://corefork.telegram.org/method/stories.getStoriesByID"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stories.getStoriesByID#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer where the stories were posted</param>
		/// <param name="id">Story IDs</param>
		public static Task<Stories_Stories> Stories_GetStoriesByID(this Client client, InputPeer peer, params int[] id)
			=> client.Invoke(new Stories_GetStoriesByID
			{
				peer = peer,
				id = id,
			});

		/// <summary>Hide the active stories of a specific peer, preventing them from being displayed on the action bar on the homescreen.		<para>See <a href="https://corefork.telegram.org/method/stories.toggleAllStoriesHidden"/></para></summary>
		/// <param name="hidden">Whether to hide or unhide all active stories of the peer</param>
		public static Task<bool> Stories_ToggleAllStoriesHidden(this Client client, bool hidden)
			=> client.Invoke(new Stories_ToggleAllStoriesHidden
			{
				hidden = hidden,
			});

		/// <summary>Mark all stories up to a certain ID as read, for a given peer; will emit an <see cref="UpdateReadStories"/> update to all logged-in sessions.		<para>See <a href="https://corefork.telegram.org/method/stories.readStories"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stories.readStories#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The peer whose stories should be marked as read.</param>
		/// <param name="max_id">Mark all stories up to and including this ID as read</param>
		public static Task<int[]> Stories_ReadStories(this Client client, InputPeer peer, int max_id = default)
			=> client.Invoke(new Stories_ReadStories
			{
				peer = peer,
				max_id = max_id,
			});

		/// <summary>Increment the view counter of one or more stories.		<para>See <a href="https://corefork.telegram.org/method/stories.incrementStoryViews"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stories.incrementStoryViews#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer where the stories were posted.</param>
		/// <param name="id">IDs of the stories (maximum 200 at a time).</param>
		public static Task<bool> Stories_IncrementStoryViews(this Client client, InputPeer peer, params int[] id)
			=> client.Invoke(new Stories_IncrementStoryViews
			{
				peer = peer,
				id = id,
			});

		/// <summary>Obtain the list of users that have viewed a specific <a href="https://corefork.telegram.org/api/stories">story we posted</a>		<para>See <a href="https://corefork.telegram.org/method/stories.getStoryViewsList"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stories.getStoryViewsList#possible-errors">details</a>)</para></summary>
		/// <param name="just_contacts">Whether to only fetch view reaction/views made by our <a href="https://corefork.telegram.org/api/contacts">contacts</a></param>
		/// <param name="reactions_first">Whether to return <see cref="StoryView"/> info about users that reacted to the story (i.e. if set, the server will first sort results by view date as usual, and then also additionally sort the list by putting <see cref="StoryView"/>s with an associated reaction first in the list). Ignored if <c>forwards_first</c> is set.</param>
		/// <param name="forwards_first">If set, returns forwards and reposts first, then reactions, then other views; otherwise returns interactions sorted just by interaction date.</param>
		/// <param name="peer">Peer where the story was posted</param>
		/// <param name="q">Search for specific peers</param>
		/// <param name="id">Story ID</param>
		/// <param name="offset">Offset for pagination, obtained from <see cref="Stories_StoryViewsList"/>.<c>next_offset</c></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Stories_StoryViewsList> Stories_GetStoryViewsList(this Client client, InputPeer peer, int id, string offset, int limit = int.MaxValue, string q = null, bool just_contacts = false, bool reactions_first = false, bool forwards_first = false)
			=> client.Invoke(new Stories_GetStoryViewsList
			{
				flags = (Stories_GetStoryViewsList.Flags)((q != null ? 0x2 : 0) | (just_contacts ? 0x1 : 0) | (reactions_first ? 0x4 : 0) | (forwards_first ? 0x8 : 0)),
				peer = peer,
				q = q,
				id = id,
				offset = offset,
				limit = limit,
			});

		/// <summary>Obtain info about the view count, forward count, reactions and recent viewers of one or more <a href="https://corefork.telegram.org/api/stories">stories</a>.		<para>See <a href="https://corefork.telegram.org/method/stories.getStoriesViews"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stories.getStoriesViews#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer whose stories should be fetched</param>
		/// <param name="id">Story IDs</param>
		public static Task<Stories_StoryViews> Stories_GetStoriesViews(this Client client, InputPeer peer, params int[] id)
			=> client.Invoke(new Stories_GetStoriesViews
			{
				peer = peer,
				id = id,
			});

		/// <summary>Generate a <a href="https://corefork.telegram.org/api/links#story-links">story deep link</a> for a specific story		<para>See <a href="https://corefork.telegram.org/method/stories.exportStoryLink"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stories.exportStoryLink#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer where the story was posted</param>
		/// <param name="id">Story ID</param>
		public static Task<ExportedStoryLink> Stories_ExportStoryLink(this Client client, InputPeer peer, int id)
			=> client.Invoke(new Stories_ExportStoryLink
			{
				peer = peer,
				id = id,
			});

		/// <summary>Report a story.		<para>See <a href="https://corefork.telegram.org/method/stories.report"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stories.report#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The peer that uploaded the story.</param>
		/// <param name="id">IDs of the stories to report.</param>
		/// <param name="option">Menu option, intially empty</param>
		/// <param name="message">Comment for report moderation</param>
		public static Task<ReportResult> Stories_Report(this Client client, InputPeer peer, int[] id, byte[] option, string message)
			=> client.Invoke(new Stories_Report
			{
				peer = peer,
				id = id,
				option = option,
				message = message,
			});

		/// <summary>Activates <a href="https://corefork.telegram.org/api/stories#stealth-mode">stories stealth mode</a>, see <a href="https://corefork.telegram.org/api/stories#stealth-mode">here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/stories.activateStealthMode"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stories.activateStealthMode#possible-errors">details</a>)</para></summary>
		/// <param name="past">Whether to erase views from any stories opened in the past <a href="https://corefork.telegram.org/api/config#stories-stealth-past-period"><c>stories_stealth_past_period</c> seconds »</a>, as specified by the <a href="https://corefork.telegram.org/api/config#client-configuration">client configuration</a>.</param>
		/// <param name="future">Whether to hide future story views for the next <a href="https://corefork.telegram.org/api/config#stories-stealth-future-period"><c>stories_stealth_future_period</c> seconds »</a>, as specified by the <a href="https://corefork.telegram.org/api/config#client-configuration">client configuration</a>.</param>
		public static Task<UpdatesBase> Stories_ActivateStealthMode(this Client client, bool past = false, bool future = false)
			=> client.Invoke(new Stories_ActivateStealthMode
			{
				flags = (Stories_ActivateStealthMode.Flags)((past ? 0x1 : 0) | (future ? 0x2 : 0)),
			});

		/// <summary>React to a story.		<para>See <a href="https://corefork.telegram.org/method/stories.sendReaction"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stories.sendReaction#possible-errors">details</a>)</para></summary>
		/// <param name="add_to_recent">Whether to add this reaction to the <a href="https://corefork.telegram.org/api/reactions#recent-reactions">recent reactions list »</a>.</param>
		/// <param name="peer">The peer that sent the story</param>
		/// <param name="story_id">ID of the story to react to</param>
		/// <param name="reaction">Reaction</param>
		public static Task<UpdatesBase> Stories_SendReaction(this Client client, InputPeer peer, int story_id, Reaction reaction, bool add_to_recent = false)
			=> client.Invoke(new Stories_SendReaction
			{
				flags = (Stories_SendReaction.Flags)(add_to_recent ? 0x1 : 0),
				peer = peer,
				story_id = story_id,
				reaction = reaction,
			});

		/// <summary>Fetch the full active <a href="https://corefork.telegram.org/api/stories#watching-stories">story list</a> of a specific peer.		<para>See <a href="https://corefork.telegram.org/method/stories.getPeerStories"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stories.getPeerStories#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer whose stories should be fetched</param>
		public static Task<Stories_PeerStories> Stories_GetPeerStories(this Client client, InputPeer peer)
			=> client.Invoke(new Stories_GetPeerStories
			{
				peer = peer,
			});

		/// <summary>Obtain the latest read story ID for all peers when first logging in, returned as a list of <see cref="UpdateReadStories"/> updates, see <a href="https://corefork.telegram.org/api/stories#watching-stories">here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/stories.getAllReadPeerStories"/></para></summary>
		public static Task<UpdatesBase> Stories_GetAllReadPeerStories(this Client client)
			=> client.Invoke(new Stories_GetAllReadPeerStories
			{
			});

		/// <summary>Get the IDs of the maximum read stories for a set of peers.		<para>See <a href="https://corefork.telegram.org/method/stories.getPeerMaxIDs"/></para></summary>
		/// <param name="id">Peers</param>
		public static Task<int[]> Stories_GetPeerMaxIDs(this Client client, params InputPeer[] id)
			=> client.Invoke(new Stories_GetPeerMaxIDs
			{
				id = id,
			});

		/// <summary>Obtain a list of channels where the user can post <a href="https://corefork.telegram.org/api/stories">stories</a>		<para>See <a href="https://corefork.telegram.org/method/stories.getChatsToSend"/></para></summary>
		public static Task<Messages_Chats> Stories_GetChatsToSend(this Client client)
			=> client.Invoke(new Stories_GetChatsToSend
			{
			});

		/// <summary>Hide the active stories of a user, preventing them from being displayed on the action bar on the homescreen, see <a href="https://corefork.telegram.org/api/stories#hiding-stories-of-other-users">here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/stories.togglePeerStoriesHidden"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stories.togglePeerStoriesHidden#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer whose stories should be (un)hidden.</param>
		/// <param name="hidden">Whether to hide or unhide stories.</param>
		public static Task<bool> Stories_TogglePeerStoriesHidden(this Client client, InputPeer peer, bool hidden)
			=> client.Invoke(new Stories_TogglePeerStoriesHidden
			{
				peer = peer,
				hidden = hidden,
			});

		/// <summary>Get the <a href="https://corefork.telegram.org/api/reactions">reaction</a> and interaction list of a <a href="https://corefork.telegram.org/api/stories">story</a> posted to a channel, along with the sender of each reaction.		<para>See <a href="https://corefork.telegram.org/method/stories.getStoryReactionsList"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stories.getStoryReactionsList#possible-errors">details</a>)</para></summary>
		/// <param name="forwards_first">If set, returns forwards and reposts first, then reactions, then other views; otherwise returns interactions sorted just by interaction date.</param>
		/// <param name="peer">Channel</param>
		/// <param name="id"><a href="https://corefork.telegram.org/api/stories">Story</a> ID</param>
		/// <param name="reaction">Get only reactions of this type</param>
		/// <param name="offset">Offset for pagination (taken from the <c>next_offset</c> field of the returned <see cref="Stories_StoryReactionsList"/>); empty in the first request.</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Stories_StoryReactionsList> Stories_GetStoryReactionsList(this Client client, InputPeer peer, int id, int limit = int.MaxValue, Reaction reaction = null, string offset = null, bool forwards_first = false)
			=> client.Invoke(new Stories_GetStoryReactionsList
			{
				flags = (Stories_GetStoryReactionsList.Flags)((reaction != null ? 0x1 : 0) | (offset != null ? 0x2 : 0) | (forwards_first ? 0x4 : 0)),
				peer = peer,
				id = id,
				reaction = reaction,
				offset = offset,
				limit = limit,
			});

		/// <summary>Pin some stories to the top of the profile, see <a href="https://corefork.telegram.org/api/stories#pinned-or-archived-stories">here »</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/stories.togglePinnedToTop"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stories.togglePinnedToTop#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer where to pin stories.</param>
		/// <param name="id">IDs of the stories to pin (max <a href="https://corefork.telegram.org/api/config#stories-pinned-to-top-count-max">stories_pinned_to_top_count_max</a>).</param>
		public static Task<bool> Stories_TogglePinnedToTop(this Client client, InputPeer peer, params int[] id)
			=> client.Invoke(new Stories_TogglePinnedToTop
			{
				peer = peer,
				id = id,
			});

		/// <summary>Globally search for <a href="https://corefork.telegram.org/api/stories">stories</a> using a hashtag or a <a href="https://corefork.telegram.org/api/stories#location-tags">location media area</a>, see <a href="https://corefork.telegram.org/api/stories#searching-stories">here »</a> for more info on the full flow.		<para>See <a href="https://corefork.telegram.org/method/stories.searchPosts"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stories.searchPosts#possible-errors">details</a>)</para></summary>
		/// <param name="hashtag">Hashtag (without the <c>#</c>)</param>
		/// <param name="area">A <see cref="MediaAreaGeoPoint"/> or a <see cref="MediaAreaVenue"/>.  <br/>Note <see cref="MediaAreaGeoPoint"/> areas may be searched only if they have an associated <c>address</c>.</param>
		/// <param name="peer">If set, returns only stories posted by this peer.</param>
		/// <param name="offset">Offset for <a href="https://corefork.telegram.org/api/offsets">pagination</a>: initially an empty string, then the <c>next_offset</c> from the previously returned <see cref="Stories_FoundStories"/>.</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Stories_FoundStories> Stories_SearchPosts(this Client client, string offset, int limit = int.MaxValue, string hashtag = null, MediaArea area = null, InputPeer peer = null)
			=> client.Invoke(new Stories_SearchPosts
			{
				flags = (Stories_SearchPosts.Flags)((hashtag != null ? 0x1 : 0) | (area != null ? 0x2 : 0) | (peer != null ? 0x4 : 0)),
				hashtag = hashtag,
				area = area,
				peer = peer,
				offset = offset,
				limit = limit,
			});

		/// <summary>Obtains info about the boosts that were applied to a certain channel or supergroup (admins only)		<para>See <a href="https://corefork.telegram.org/method/premium.getBoostsList"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/premium.getBoostsList#possible-errors">details</a>)</para></summary>
		/// <param name="gifts">Whether to return only info about boosts received from <a href="https://corefork.telegram.org/api/giveaways">gift codes and giveaways created by the channel/supergroup »</a></param>
		/// <param name="peer">The channel/supergroup</param>
		/// <param name="offset">Offset for pagination, obtained from <see cref="Premium_BoostsList"/>.<c>next_offset</c></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Premium_BoostsList> Premium_GetBoostsList(this Client client, InputPeer peer, string offset, int limit = int.MaxValue, bool gifts = false)
			=> client.Invoke(new Premium_GetBoostsList
			{
				flags = (Premium_GetBoostsList.Flags)(gifts ? 0x1 : 0),
				peer = peer,
				offset = offset,
				limit = limit,
			});

		/// <summary>Obtain which peers are we currently <a href="https://corefork.telegram.org/api/boost">boosting</a>, and how many <a href="https://corefork.telegram.org/api/boost">boost slots</a> we have left.		<para>See <a href="https://corefork.telegram.org/method/premium.getMyBoosts"/></para></summary>
		public static Task<Premium_MyBoosts> Premium_GetMyBoosts(this Client client)
			=> client.Invoke(new Premium_GetMyBoosts
			{
			});

		/// <summary>Apply one or more <a href="https://corefork.telegram.org/api/boost">boosts »</a> to a peer.		<para>See <a href="https://corefork.telegram.org/method/premium.applyBoost"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/premium.applyBoost#possible-errors">details</a>)</para></summary>
		/// <param name="slots">Which <a href="https://corefork.telegram.org/api/boost">boost slots</a> to assign to this peer.</param>
		/// <param name="peer">The peer to boost.</param>
		public static Task<Premium_MyBoosts> Premium_ApplyBoost(this Client client, InputPeer peer, int[] slots = null)
			=> client.Invoke(new Premium_ApplyBoost
			{
				flags = (Premium_ApplyBoost.Flags)(slots != null ? 0x1 : 0),
				slots = slots,
				peer = peer,
			});

		/// <summary>Gets the current <a href="https://corefork.telegram.org/api/boost">number of boosts</a> of a channel/supergroup.		<para>See <a href="https://corefork.telegram.org/method/premium.getBoostsStatus"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/premium.getBoostsStatus#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The peer.</param>
		public static Task<Premium_BoostsStatus> Premium_GetBoostsStatus(this Client client, InputPeer peer)
			=> client.Invoke(new Premium_GetBoostsStatus
			{
				peer = peer,
			});

		/// <summary>Returns the lists of boost that were applied to a channel/supergroup by a specific user (admins only)		<para>See <a href="https://corefork.telegram.org/method/premium.getUserBoosts"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/premium.getUserBoosts#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The channel/supergroup</param>
		/// <param name="user_id">The user</param>
		public static Task<Premium_BoostsList> Premium_GetUserBoosts(this Client client, InputPeer peer, InputUserBase user_id)
			=> client.Invoke(new Premium_GetUserBoosts
			{
				peer = peer,
				user_id = user_id,
			});

		/// <summary>Check if we can process SMS jobs (official clients only).		<para>See <a href="https://corefork.telegram.org/method/smsjobs.isEligibleToJoin"/></para>		<para>Possible <see cref="RpcException"/> codes: 403 (<a href="https://corefork.telegram.org/method/smsjobs.isEligibleToJoin#possible-errors">details</a>)</para></summary>
		public static Task<Smsjobs_EligibilityToJoin> Smsjobs_IsEligibleToJoin(this Client client)
			=> client.Invoke(new Smsjobs_IsEligibleToJoin
			{
			});

		/// <summary>Enable SMS jobs (official clients only).		<para>See <a href="https://corefork.telegram.org/method/smsjobs.join"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/smsjobs.join#possible-errors">details</a>)</para></summary>
		public static Task<bool> Smsjobs_Join(this Client client)
			=> client.Invoke(new Smsjobs_Join
			{
			});

		/// <summary>Disable SMS jobs (official clients only).		<para>See <a href="https://corefork.telegram.org/method/smsjobs.leave"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/smsjobs.leave#possible-errors">details</a>)</para></summary>
		public static Task<bool> Smsjobs_Leave(this Client client)
			=> client.Invoke(new Smsjobs_Leave
			{
			});

		/// <summary>Update SMS job settings (official clients only).		<para>See <a href="https://corefork.telegram.org/method/smsjobs.updateSettings"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/smsjobs.updateSettings#possible-errors">details</a>)</para></summary>
		/// <param name="allow_international">Allow international numbers?</param>
		public static Task<bool> Smsjobs_UpdateSettings(this Client client, bool allow_international = false)
			=> client.Invoke(new Smsjobs_UpdateSettings
			{
				flags = (Smsjobs_UpdateSettings.Flags)(allow_international ? 0x1 : 0),
			});

		/// <summary>Get SMS jobs status (official clients only).		<para>See <a href="https://corefork.telegram.org/method/smsjobs.getStatus"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/smsjobs.getStatus#possible-errors">details</a>)</para></summary>
		public static Task<Smsjobs_Status> Smsjobs_GetStatus(this Client client)
			=> client.Invoke(new Smsjobs_GetStatus
			{
			});

		/// <summary>Get info about an SMS job (official clients only).		<para>See <a href="https://corefork.telegram.org/method/smsjobs.getSmsJob"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/smsjobs.getSmsJob#possible-errors">details</a>)</para></summary>
		/// <param name="job_id">Job ID</param>
		public static Task<SmsJob> Smsjobs_GetSmsJob(this Client client, string job_id)
			=> client.Invoke(new Smsjobs_GetSmsJob
			{
				job_id = job_id,
			});

		/// <summary>Finish an SMS job (official clients only).		<para>See <a href="https://corefork.telegram.org/method/smsjobs.finishJob"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/smsjobs.finishJob#possible-errors">details</a>)</para></summary>
		/// <param name="job_id">Job ID.</param>
		/// <param name="error">If failed, the error.</param>
		public static Task<bool> Smsjobs_FinishJob(this Client client, string job_id, string error = null)
			=> client.Invoke(new Smsjobs_FinishJob
			{
				flags = (Smsjobs_FinishJob.Flags)(error != null ? 0x1 : 0),
				job_id = job_id,
				error = error,
			});

		/// <summary>Fetch information about a <a href="https://corefork.telegram.org/api/fragment#fetching-info-about-fragment-collectibles">fragment collectible, see here »</a> for more info on the full flow.		<para>See <a href="https://corefork.telegram.org/method/fragment.getCollectibleInfo"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/fragment.getCollectibleInfo#possible-errors">details</a>)</para></summary>
		/// <param name="collectible">Collectible to fetch info about.</param>
		public static Task<Fragment_CollectibleInfo> Fragment_GetCollectibleInfo(this Client client, InputCollectible collectible)
			=> client.Invoke(new Fragment_GetCollectibleInfo
			{
				collectible = collectible,
			});
	}
}

namespace TL.Methods
{
	#pragma warning disable IDE1006
	[TLDef(0xCB9F372D)]
	public sealed partial class InvokeAfterMsg<X> : IMethod<X>
	{
		public long msg_id;
		public IMethod<X> query;
	}

	[TLDef(0x3DC4B4F0)]
	public sealed partial class InvokeAfterMsgs<X> : IMethod<X>
	{
		public long[] msg_ids;
		public IMethod<X> query;
	}

	[TLDef(0xC1CD5EA9)]
	public sealed partial class InitConnection<X> : IMethod<X>
	{
		public Flags flags;
		public int api_id;
		public string device_model;
		public string system_version;
		public string app_version;
		public string system_lang_code;
		public string lang_pack;
		public string lang_code;
		[IfFlag(0)] public InputClientProxy proxy;
		[IfFlag(1)] public JSONValue params_;
		public IMethod<X> query;

		[Flags] public enum Flags : uint
		{
			has_proxy = 0x1,
			has_params = 0x2,
		}
	}

	[TLDef(0xDA9B0D0D)]
	public sealed partial class InvokeWithLayer<X> : IMethod<X>
	{
		public int layer;
		public IMethod<X> query;
	}

	[TLDef(0xBF9459B7)]
	public sealed partial class InvokeWithoutUpdates<X> : IMethod<X>
	{
		public IMethod<X> query;
	}

	[TLDef(0x365275F2)]
	public sealed partial class InvokeWithMessagesRange<X> : IMethod<X>
	{
		public MessageRange range;
		public IMethod<X> query;
	}

	[TLDef(0xACA9FD2E)]
	public sealed partial class InvokeWithTakeout<X> : IMethod<X>
	{
		public long takeout_id;
		public IMethod<X> query;
	}

	[TLDef(0xDD289F8E)]
	public sealed partial class InvokeWithBusinessConnection<X> : IMethod<X>
	{
		public string connection_id;
		public IMethod<X> query;
	}

	[TLDef(0x1DF92984)]
	public sealed partial class InvokeWithGooglePlayIntegrity<X> : IMethod<X>
	{
		public string nonce;
		public string token;
		public IMethod<X> query;
	}

	[TLDef(0x0DAE54F8)]
	public sealed partial class InvokeWithApnsSecret<X> : IMethod<X>
	{
		public string nonce;
		public string secret;
		public IMethod<X> query;
	}

	[TLDef(0xADBB0F94)]
	public sealed partial class InvokeWithReCaptcha<X> : IMethod<X>
	{
		public string token;
		public IMethod<X> query;
	}

	[TLDef(0xA677244F)]
	public sealed partial class Auth_SendCode : IMethod<Auth_SentCodeBase>
	{
		public string phone_number;
		public int api_id;
		public string api_hash;
		public CodeSettings settings;
	}

	[TLDef(0xAAC7B717)]
	public sealed partial class Auth_SignUp : IMethod<Auth_AuthorizationBase>
	{
		public Flags flags;
		public string phone_number;
		public string phone_code_hash;
		public string first_name;
		public string last_name;

		[Flags] public enum Flags : uint
		{
			no_joined_notifications = 0x1,
		}
	}

	[TLDef(0x8D52A951)]
	public sealed partial class Auth_SignIn : IMethod<Auth_AuthorizationBase>
	{
		public Flags flags;
		public string phone_number;
		public string phone_code_hash;
		[IfFlag(0)] public string phone_code;
		[IfFlag(1)] public EmailVerification email_verification;

		[Flags] public enum Flags : uint
		{
			has_phone_code = 0x1,
			has_email_verification = 0x2,
		}
	}

	[TLDef(0x3E72BA19)]
	public sealed partial class Auth_LogOut : IMethod<Auth_LoggedOut> { }

	[TLDef(0x9FAB0D1A)]
	public sealed partial class Auth_ResetAuthorizations : IMethod<bool> { }

	[TLDef(0xE5BFFFCD)]
	public sealed partial class Auth_ExportAuthorization : IMethod<Auth_ExportedAuthorization>
	{
		public int dc_id;
	}

	[TLDef(0xA57A7DAD)]
	public sealed partial class Auth_ImportAuthorization : IMethod<Auth_AuthorizationBase>
	{
		public long id;
		public byte[] bytes;
	}

	[TLDef(0xCDD42A05)]
	public sealed partial class Auth_BindTempAuthKey : IMethod<bool>
	{
		public long perm_auth_key_id;
		public long nonce;
		public DateTime expires_at;
		public byte[] encrypted_message;
	}

	[TLDef(0x67A3FF2C)]
	public sealed partial class Auth_ImportBotAuthorization : IMethod<Auth_AuthorizationBase>
	{
		public int flags;
		public int api_id;
		public string api_hash;
		public string bot_auth_token;
	}

	[TLDef(0xD18B4D16)]
	public sealed partial class Auth_CheckPassword : IMethod<Auth_AuthorizationBase>
	{
		public InputCheckPasswordSRP password;
	}

	[TLDef(0xD897BC66)]
	public sealed partial class Auth_RequestPasswordRecovery : IMethod<Auth_PasswordRecovery> { }

	[TLDef(0x37096C70)]
	public sealed partial class Auth_RecoverPassword : IMethod<Auth_AuthorizationBase>
	{
		public Flags flags;
		public string code;
		[IfFlag(0)] public Account_PasswordInputSettings new_settings;

		[Flags] public enum Flags : uint
		{
			has_new_settings = 0x1,
		}
	}

	[TLDef(0xCAE47523)]
	public sealed partial class Auth_ResendCode : IMethod<Auth_SentCodeBase>
	{
		public Flags flags;
		public string phone_number;
		public string phone_code_hash;
		[IfFlag(0)] public string reason;

		[Flags] public enum Flags : uint
		{
			has_reason = 0x1,
		}
	}

	[TLDef(0x1F040578)]
	public sealed partial class Auth_CancelCode : IMethod<bool>
	{
		public string phone_number;
		public string phone_code_hash;
	}

	[TLDef(0x8E48A188)]
	public sealed partial class Auth_DropTempAuthKeys : IMethod<bool>
	{
		public long[] except_auth_keys;
	}

	[TLDef(0xB7E085FE)]
	public sealed partial class Auth_ExportLoginToken : IMethod<Auth_LoginTokenBase>
	{
		public int api_id;
		public string api_hash;
		public long[] except_ids;
	}

	[TLDef(0x95AC5CE4)]
	public sealed partial class Auth_ImportLoginToken : IMethod<Auth_LoginTokenBase>
	{
		public byte[] token;
	}

	[TLDef(0xE894AD4D)]
	public sealed partial class Auth_AcceptLoginToken : IMethod<Authorization>
	{
		public byte[] token;
	}

	[TLDef(0x0D36BF79)]
	public sealed partial class Auth_CheckRecoveryPassword : IMethod<bool>
	{
		public string code;
	}

	[TLDef(0x2DB873A9)]
	public sealed partial class Auth_ImportWebTokenAuthorization : IMethod<Auth_AuthorizationBase>
	{
		public int api_id;
		public string api_hash;
		public string web_auth_token;
	}

	[TLDef(0x8E39261E)]
	public sealed partial class Auth_RequestFirebaseSms : IMethod<bool>
	{
		public Flags flags;
		public string phone_number;
		public string phone_code_hash;
		[IfFlag(0)] public string safety_net_token;
		[IfFlag(2)] public string play_integrity_token;
		[IfFlag(1)] public string ios_push_secret;

		[Flags] public enum Flags : uint
		{
			has_safety_net_token = 0x1,
			has_ios_push_secret = 0x2,
			has_play_integrity_token = 0x4,
		}
	}

	[TLDef(0x7E960193)]
	public sealed partial class Auth_ResetLoginEmail : IMethod<Auth_SentCodeBase>
	{
		public string phone_number;
		public string phone_code_hash;
	}

	[TLDef(0xCB9DEFF6)]
	public sealed partial class Auth_ReportMissingCode : IMethod<bool>
	{
		public string phone_number;
		public string phone_code_hash;
		public string mnc;
	}

	[TLDef(0xEC86017A)]
	public sealed partial class Account_RegisterDevice : IMethod<bool>
	{
		public Flags flags;
		public int token_type;
		public string token;
		public bool app_sandbox;
		public byte[] secret;
		public long[] other_uids;

		[Flags] public enum Flags : uint
		{
			no_muted = 0x1,
		}
	}

	[TLDef(0x6A0D3206)]
	public sealed partial class Account_UnregisterDevice : IMethod<bool>
	{
		public int token_type;
		public string token;
		public long[] other_uids;
	}

	[TLDef(0x84BE5B93)]
	public sealed partial class Account_UpdateNotifySettings : IMethod<bool>
	{
		public InputNotifyPeerBase peer;
		public InputPeerNotifySettings settings;
	}

	[TLDef(0x12B3AD31)]
	public sealed partial class Account_GetNotifySettings : IMethod<PeerNotifySettings>
	{
		public InputNotifyPeerBase peer;
	}

	[TLDef(0xDB7E1747)]
	public sealed partial class Account_ResetNotifySettings : IMethod<bool> { }

	[TLDef(0x78515775)]
	public sealed partial class Account_UpdateProfile : IMethod<UserBase>
	{
		public Flags flags;
		[IfFlag(0)] public string first_name;
		[IfFlag(1)] public string last_name;
		[IfFlag(2)] public string about;

		[Flags] public enum Flags : uint
		{
			has_first_name = 0x1,
			has_last_name = 0x2,
			has_about = 0x4,
		}
	}

	[TLDef(0x6628562C)]
	public sealed partial class Account_UpdateStatus : IMethod<bool>
	{
		public bool offline;
	}

	[TLDef(0x07967D36)]
	public sealed partial class Account_GetWallPapers : IMethod<Account_WallPapers>
	{
		public long hash;
	}

	[TLDef(0xC5BA3D86)]
	public sealed partial class Account_ReportPeer : IMethod<bool>
	{
		public InputPeer peer;
		public ReportReason reason;
		public string message;
	}

	[TLDef(0x2714D86C)]
	public sealed partial class Account_CheckUsername : IMethod<bool>
	{
		public string username;
	}

	[TLDef(0x3E0BDD7C)]
	public sealed partial class Account_UpdateUsername : IMethod<UserBase>
	{
		public string username;
	}

	[TLDef(0xDADBC950)]
	public sealed partial class Account_GetPrivacy : IMethod<Account_PrivacyRules>
	{
		public InputPrivacyKey key;
	}

	[TLDef(0xC9F81CE8)]
	public sealed partial class Account_SetPrivacy : IMethod<Account_PrivacyRules>
	{
		public InputPrivacyKey key;
		public InputPrivacyRule[] rules;
	}

	[TLDef(0xA2C0CF74)]
	public sealed partial class Account_DeleteAccount : IMethod<bool>
	{
		public Flags flags;
		public string reason;
		[IfFlag(0)] public InputCheckPasswordSRP password;

		[Flags] public enum Flags : uint
		{
			has_password = 0x1,
		}
	}

	[TLDef(0x08FC711D)]
	public sealed partial class Account_GetAccountTTL : IMethod<AccountDaysTTL> { }

	[TLDef(0x2442485E)]
	public sealed partial class Account_SetAccountTTL : IMethod<bool>
	{
		public AccountDaysTTL ttl;
	}

	[TLDef(0x82574AE5)]
	public sealed partial class Account_SendChangePhoneCode : IMethod<Auth_SentCodeBase>
	{
		public string phone_number;
		public CodeSettings settings;
	}

	[TLDef(0x70C32EDB)]
	public sealed partial class Account_ChangePhone : IMethod<UserBase>
	{
		public string phone_number;
		public string phone_code_hash;
		public string phone_code;
	}

	[TLDef(0x38DF3532)]
	public sealed partial class Account_UpdateDeviceLocked : IMethod<bool>
	{
		public int period;
	}

	[TLDef(0xE320C158)]
	public sealed partial class Account_GetAuthorizations : IMethod<Account_Authorizations> { }

	[TLDef(0xDF77F3BC)]
	public sealed partial class Account_ResetAuthorization : IMethod<bool>
	{
		public long hash;
	}

	[TLDef(0x548A30F5)]
	public sealed partial class Account_GetPassword : IMethod<Account_Password> { }

	[TLDef(0x9CD4EAF9)]
	public sealed partial class Account_GetPasswordSettings : IMethod<Account_PasswordSettings>
	{
		public InputCheckPasswordSRP password;
	}

	[TLDef(0xA59B102F)]
	public sealed partial class Account_UpdatePasswordSettings : IMethod<bool>
	{
		public InputCheckPasswordSRP password;
		public Account_PasswordInputSettings new_settings;
	}

	[TLDef(0x1B3FAA88)]
	public sealed partial class Account_SendConfirmPhoneCode : IMethod<Auth_SentCodeBase>
	{
		public string hash;
		public CodeSettings settings;
	}

	[TLDef(0x5F2178C3)]
	public sealed partial class Account_ConfirmPhone : IMethod<bool>
	{
		public string phone_code_hash;
		public string phone_code;
	}

	[TLDef(0x449E0B51)]
	public sealed partial class Account_GetTmpPassword : IMethod<Account_TmpPassword>
	{
		public InputCheckPasswordSRP password;
		public int period;
	}

	[TLDef(0x182E6D6F)]
	public sealed partial class Account_GetWebAuthorizations : IMethod<Account_WebAuthorizations> { }

	[TLDef(0x2D01B9EF)]
	public sealed partial class Account_ResetWebAuthorization : IMethod<bool>
	{
		public long hash;
	}

	[TLDef(0x682D2594)]
	public sealed partial class Account_ResetWebAuthorizations : IMethod<bool> { }

	[TLDef(0xB288BC7D)]
	public sealed partial class Account_GetAllSecureValues : IMethod<SecureValue[]> { }

	[TLDef(0x73665BC2)]
	public sealed partial class Account_GetSecureValue : IMethod<SecureValue[]>
	{
		public SecureValueType[] types;
	}

	[TLDef(0x899FE31D)]
	public sealed partial class Account_SaveSecureValue : IMethod<SecureValue>
	{
		public InputSecureValue value;
		public long secure_secret_id;
	}

	[TLDef(0xB880BC4B)]
	public sealed partial class Account_DeleteSecureValue : IMethod<bool>
	{
		public SecureValueType[] types;
	}

	[TLDef(0xA929597A)]
	public sealed partial class Account_GetAuthorizationForm : IMethod<Account_AuthorizationForm>
	{
		public long bot_id;
		public string scope;
		public string public_key;
	}

	[TLDef(0xF3ED4C73)]
	public sealed partial class Account_AcceptAuthorization : IMethod<bool>
	{
		public long bot_id;
		public string scope;
		public string public_key;
		public SecureValueHash[] value_hashes;
		public SecureCredentialsEncrypted credentials;
	}

	[TLDef(0xA5A356F9)]
	public sealed partial class Account_SendVerifyPhoneCode : IMethod<Auth_SentCodeBase>
	{
		public string phone_number;
		public CodeSettings settings;
	}

	[TLDef(0x4DD3A7F6)]
	public sealed partial class Account_VerifyPhone : IMethod<bool>
	{
		public string phone_number;
		public string phone_code_hash;
		public string phone_code;
	}

	[TLDef(0x98E037BB)]
	public sealed partial class Account_SendVerifyEmailCode : IMethod<Account_SentEmailCode>
	{
		public EmailVerifyPurpose purpose;
		public string email;
	}

	[TLDef(0x032DA4CF)]
	public sealed partial class Account_VerifyEmail : IMethod<Account_EmailVerified>
	{
		public EmailVerifyPurpose purpose;
		public EmailVerification verification;
	}

	[TLDef(0x8EF3EAB0)]
	public sealed partial class Account_InitTakeoutSession : IMethod<Account_Takeout>
	{
		public Flags flags;
		[IfFlag(5)] public long file_max_size;

		[Flags] public enum Flags : uint
		{
			contacts = 0x1,
			message_users = 0x2,
			message_chats = 0x4,
			message_megagroups = 0x8,
			message_channels = 0x10,
			files = 0x20,
		}
	}

	[TLDef(0x1D2652EE)]
	public sealed partial class Account_FinishTakeoutSession : IMethod<bool>
	{
		public Flags flags;

		[Flags] public enum Flags : uint
		{
			success = 0x1,
		}
	}

	[TLDef(0x8FDF1920)]
	public sealed partial class Account_ConfirmPasswordEmail : IMethod<bool>
	{
		public string code;
	}

	[TLDef(0x7A7F2A15)]
	public sealed partial class Account_ResendPasswordEmail : IMethod<bool> { }

	[TLDef(0xC1CBD5B6)]
	public sealed partial class Account_CancelPasswordEmail : IMethod<bool> { }

	[TLDef(0x9F07C728)]
	public sealed partial class Account_GetContactSignUpNotification : IMethod<bool> { }

	[TLDef(0xCFF43F61)]
	public sealed partial class Account_SetContactSignUpNotification : IMethod<bool>
	{
		public bool silent;
	}

	[TLDef(0x53577479)]
	public sealed partial class Account_GetNotifyExceptions : IMethod<UpdatesBase>
	{
		public Flags flags;
		[IfFlag(0)] public InputNotifyPeerBase peer;

		[Flags] public enum Flags : uint
		{
			has_peer = 0x1,
			compare_sound = 0x2,
			compare_stories = 0x4,
		}
	}

	[TLDef(0xFC8DDBEA)]
	public sealed partial class Account_GetWallPaper : IMethod<WallPaperBase>
	{
		public InputWallPaperBase wallpaper;
	}

	[TLDef(0xE39A8F03)]
	public sealed partial class Account_UploadWallPaper : IMethod<WallPaperBase>
	{
		public Flags flags;
		public InputFileBase file;
		public string mime_type;
		public WallPaperSettings settings;

		[Flags] public enum Flags : uint
		{
			for_chat = 0x1,
		}
	}

	[TLDef(0x6C5A5B37)]
	public sealed partial class Account_SaveWallPaper : IMethod<bool>
	{
		public InputWallPaperBase wallpaper;
		public bool unsave;
		public WallPaperSettings settings;
	}

	[TLDef(0xFEED5769)]
	public sealed partial class Account_InstallWallPaper : IMethod<bool>
	{
		public InputWallPaperBase wallpaper;
		public WallPaperSettings settings;
	}

	[TLDef(0xBB3B9804)]
	public sealed partial class Account_ResetWallPapers : IMethod<bool> { }

	[TLDef(0x56DA0B3F)]
	public sealed partial class Account_GetAutoDownloadSettings : IMethod<Account_AutoDownloadSettings> { }

	[TLDef(0x76F36233)]
	public sealed partial class Account_SaveAutoDownloadSettings : IMethod<bool>
	{
		public Flags flags;
		public AutoDownloadSettings settings;

		[Flags] public enum Flags : uint
		{
			low = 0x1,
			high = 0x2,
		}
	}

	[TLDef(0x1C3DB333)]
	public sealed partial class Account_UploadTheme : IMethod<DocumentBase>
	{
		public Flags flags;
		public InputFileBase file;
		[IfFlag(0)] public InputFileBase thumb;
		public string file_name;
		public string mime_type;

		[Flags] public enum Flags : uint
		{
			has_thumb = 0x1,
		}
	}

	[TLDef(0x652E4400)]
	public sealed partial class Account_CreateTheme : IMethod<Theme>
	{
		public Flags flags;
		public string slug;
		public string title;
		[IfFlag(2)] public InputDocument document;
		[IfFlag(3)] public InputThemeSettings[] settings;

		[Flags] public enum Flags : uint
		{
			has_document = 0x4,
			has_settings = 0x8,
		}
	}

	[TLDef(0x2BF40CCC)]
	public sealed partial class Account_UpdateTheme : IMethod<Theme>
	{
		public Flags flags;
		public string format;
		public InputThemeBase theme;
		[IfFlag(0)] public string slug;
		[IfFlag(1)] public string title;
		[IfFlag(2)] public InputDocument document;
		[IfFlag(3)] public InputThemeSettings[] settings;

		[Flags] public enum Flags : uint
		{
			has_slug = 0x1,
			has_title = 0x2,
			has_document = 0x4,
			has_settings = 0x8,
		}
	}

	[TLDef(0xF257106C)]
	public sealed partial class Account_SaveTheme : IMethod<bool>
	{
		public InputThemeBase theme;
		public bool unsave;
	}

	[TLDef(0xC727BB3B)]
	public sealed partial class Account_InstallTheme : IMethod<bool>
	{
		public Flags flags;
		[IfFlag(1)] public InputThemeBase theme;
		[IfFlag(2)] public string format;
		[IfFlag(3)] public BaseTheme base_theme;

		[Flags] public enum Flags : uint
		{
			dark = 0x1,
			has_theme = 0x2,
			has_format = 0x4,
			has_base_theme = 0x8,
		}
	}

	[TLDef(0x3A5869EC)]
	public sealed partial class Account_GetTheme : IMethod<Theme>
	{
		public string format;
		public InputThemeBase theme;
	}

	[TLDef(0x7206E458)]
	public sealed partial class Account_GetThemes : IMethod<Account_Themes>
	{
		public string format;
		public long hash;
	}

	[TLDef(0xB574B16B)]
	public sealed partial class Account_SetContentSettings : IMethod<bool>
	{
		public Flags flags;

		[Flags] public enum Flags : uint
		{
			sensitive_enabled = 0x1,
		}
	}

	[TLDef(0x8B9B4DAE)]
	public sealed partial class Account_GetContentSettings : IMethod<Account_ContentSettings> { }

	[TLDef(0x65AD71DC)]
	public sealed partial class Account_GetMultiWallPapers : IMethod<WallPaperBase[]>
	{
		public InputWallPaperBase[] wallpapers;
	}

	[TLDef(0xEB2B4CF6)]
	public sealed partial class Account_GetGlobalPrivacySettings : IMethod<GlobalPrivacySettings> { }

	[TLDef(0x1EDAAAC2)]
	public sealed partial class Account_SetGlobalPrivacySettings : IMethod<GlobalPrivacySettings>
	{
		public GlobalPrivacySettings settings;
	}

	[TLDef(0xFA8CC6F5)]
	public sealed partial class Account_ReportProfilePhoto : IMethod<bool>
	{
		public InputPeer peer;
		public InputPhoto photo_id;
		public ReportReason reason;
		public string message;
	}

	[TLDef(0x9308CE1B)]
	public sealed partial class Account_ResetPassword : IMethod<Account_ResetPasswordResult> { }

	[TLDef(0x4C9409F6)]
	public sealed partial class Account_DeclinePasswordReset : IMethod<bool> { }

	[TLDef(0xD638DE89)]
	public sealed partial class Account_GetChatThemes : IMethod<Account_Themes>
	{
		public long hash;
	}

	[TLDef(0xBF899AA0)]
	public sealed partial class Account_SetAuthorizationTTL : IMethod<bool>
	{
		public int authorization_ttl_days;
	}

	[TLDef(0x40F48462)]
	public sealed partial class Account_ChangeAuthorizationSettings : IMethod<bool>
	{
		public Flags flags;
		public long hash;
		[IfFlag(0)] public bool encrypted_requests_disabled;
		[IfFlag(1)] public bool call_requests_disabled;

		[Flags] public enum Flags : uint
		{
			has_encrypted_requests_disabled = 0x1,
			has_call_requests_disabled = 0x2,
			confirmed = 0x8,
		}
	}

	[TLDef(0xE1902288)]
	public sealed partial class Account_GetSavedRingtones : IMethod<Account_SavedRingtones>
	{
		public long hash;
	}

	[TLDef(0x3DEA5B03)]
	public sealed partial class Account_SaveRingtone : IMethod<Account_SavedRingtone>
	{
		public InputDocument id;
		public bool unsave;
	}

	[TLDef(0x831A83A2)]
	public sealed partial class Account_UploadRingtone : IMethod<DocumentBase>
	{
		public InputFileBase file;
		public string file_name;
		public string mime_type;
	}

	[TLDef(0xFBD3DE6B)]
	public sealed partial class Account_UpdateEmojiStatus : IMethod<bool>
	{
		public EmojiStatusBase emoji_status;
	}

	[TLDef(0xD6753386)]
	public sealed partial class Account_GetDefaultEmojiStatuses : IMethod<Account_EmojiStatuses>
	{
		public long hash;
	}

	[TLDef(0x0F578105)]
	public sealed partial class Account_GetRecentEmojiStatuses : IMethod<Account_EmojiStatuses>
	{
		public long hash;
	}

	[TLDef(0x18201AAE)]
	public sealed partial class Account_ClearRecentEmojiStatuses : IMethod<bool> { }

	[TLDef(0xEF500EAB)]
	public sealed partial class Account_ReorderUsernames : IMethod<bool>
	{
		public string[] order;
	}

	[TLDef(0x58D6B376)]
	public sealed partial class Account_ToggleUsername : IMethod<bool>
	{
		public string username;
		public bool active;
	}

	[TLDef(0xE2750328)]
	public sealed partial class Account_GetDefaultProfilePhotoEmojis : IMethod<EmojiList>
	{
		public long hash;
	}

	[TLDef(0x915860AE)]
	public sealed partial class Account_GetDefaultGroupPhotoEmojis : IMethod<EmojiList>
	{
		public long hash;
	}

	[TLDef(0xADCBBCDA)]
	public sealed partial class Account_GetAutoSaveSettings : IMethod<Account_AutoSaveSettings> { }

	[TLDef(0xD69B8361)]
	public sealed partial class Account_SaveAutoSaveSettings : IMethod<bool>
	{
		public Flags flags;
		[IfFlag(3)] public InputPeer peer;
		public AutoSaveSettings settings;

		[Flags] public enum Flags : uint
		{
			users = 0x1,
			chats = 0x2,
			broadcasts = 0x4,
			has_peer = 0x8,
		}
	}

	[TLDef(0x53BC0020)]
	public sealed partial class Account_DeleteAutoSaveExceptions : IMethod<bool> { }

	[TLDef(0xCA8AE8BA)]
	public sealed partial class Account_InvalidateSignInCodes : IMethod<bool>
	{
		public string[] codes;
	}

	[TLDef(0x7CEFA15D)]
	public sealed partial class Account_UpdateColor : IMethod<bool>
	{
		public Flags flags;
		[IfFlag(2)] public int color;
		[IfFlag(0)] public long background_emoji_id;

		[Flags] public enum Flags : uint
		{
			has_background_emoji_id = 0x1,
			for_profile = 0x2,
			has_color = 0x4,
		}
	}

	[TLDef(0xA60AB9CE)]
	public sealed partial class Account_GetDefaultBackgroundEmojis : IMethod<EmojiList>
	{
		public long hash;
	}

	[TLDef(0x7727A7D5)]
	public sealed partial class Account_GetChannelDefaultEmojiStatuses : IMethod<Account_EmojiStatuses>
	{
		public long hash;
	}

	[TLDef(0x35A9E0D5)]
	public sealed partial class Account_GetChannelRestrictedStatusEmojis : IMethod<EmojiList>
	{
		public long hash;
	}

	[TLDef(0x4B00E066)]
	public sealed partial class Account_UpdateBusinessWorkHours : IMethod<bool>
	{
		public Flags flags;
		[IfFlag(0)] public BusinessWorkHours business_work_hours;

		[Flags] public enum Flags : uint
		{
			has_business_work_hours = 0x1,
		}
	}

	[TLDef(0x9E6B131A)]
	public sealed partial class Account_UpdateBusinessLocation : IMethod<bool>
	{
		public Flags flags;
		[IfFlag(1)] public InputGeoPoint geo_point;
		[IfFlag(0)] public string address;

		[Flags] public enum Flags : uint
		{
			has_address = 0x1,
			has_geo_point = 0x2,
		}
	}

	[TLDef(0x66CDAFC4)]
	public sealed partial class Account_UpdateBusinessGreetingMessage : IMethod<bool>
	{
		public Flags flags;
		[IfFlag(0)] public InputBusinessGreetingMessage message;

		[Flags] public enum Flags : uint
		{
			has_message = 0x1,
		}
	}

	[TLDef(0xA26A7FA5)]
	public sealed partial class Account_UpdateBusinessAwayMessage : IMethod<bool>
	{
		public Flags flags;
		[IfFlag(0)] public InputBusinessAwayMessage message;

		[Flags] public enum Flags : uint
		{
			has_message = 0x1,
		}
	}

	[TLDef(0x43D8521D)]
	public sealed partial class Account_UpdateConnectedBot : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputUserBase bot;
		public InputBusinessBotRecipients recipients;

		[Flags] public enum Flags : uint
		{
			can_reply = 0x1,
			deleted = 0x2,
		}
	}

	[TLDef(0x4EA4C80F)]
	public sealed partial class Account_GetConnectedBots : IMethod<Account_ConnectedBots> { }

	[TLDef(0x76A86270)]
	public sealed partial class Account_GetBotBusinessConnection : IMethod<UpdatesBase>
	{
		public string connection_id;
	}

	[TLDef(0xA614D034)]
	public sealed partial class Account_UpdateBusinessIntro : IMethod<bool>
	{
		public Flags flags;
		[IfFlag(0)] public InputBusinessIntro intro;

		[Flags] public enum Flags : uint
		{
			has_intro = 0x1,
		}
	}

	[TLDef(0x646E1097)]
	public sealed partial class Account_ToggleConnectedBotPaused : IMethod<bool>
	{
		public InputPeer peer;
		public bool paused;
	}

	[TLDef(0x5E437ED9)]
	public sealed partial class Account_DisablePeerConnectedBot : IMethod<bool>
	{
		public InputPeer peer;
	}

	[TLDef(0xCC6E0C11)]
	public sealed partial class Account_UpdateBirthday : IMethod<bool>
	{
		public Flags flags;
		[IfFlag(0)] public Birthday birthday;

		[Flags] public enum Flags : uint
		{
			has_birthday = 0x1,
		}
	}

	[TLDef(0x8851E68E)]
	public sealed partial class Account_CreateBusinessChatLink : IMethod<BusinessChatLink>
	{
		public InputBusinessChatLink link;
	}

	[TLDef(0x8C3410AF)]
	public sealed partial class Account_EditBusinessChatLink : IMethod<BusinessChatLink>
	{
		public string slug;
		public InputBusinessChatLink link;
	}

	[TLDef(0x60073674)]
	public sealed partial class Account_DeleteBusinessChatLink : IMethod<bool>
	{
		public string slug;
	}

	[TLDef(0x6F70DDE1)]
	public sealed partial class Account_GetBusinessChatLinks : IMethod<Account_BusinessChatLinks> { }

	[TLDef(0x5492E5EE)]
	public sealed partial class Account_ResolveBusinessChatLink : IMethod<Account_ResolvedBusinessChatLinks>
	{
		public string slug;
	}

	[TLDef(0xD94305E0)]
	public sealed partial class Account_UpdatePersonalChannel : IMethod<bool>
	{
		public InputChannelBase channel;
	}

	[TLDef(0xB9D9A38D)]
	public sealed partial class Account_ToggleSponsoredMessages : IMethod<bool>
	{
		public bool enabled;
	}

	[TLDef(0x06DD654C)]
	public sealed partial class Account_GetReactionsNotifySettings : IMethod<ReactionsNotifySettings> { }

	[TLDef(0x316CE548)]
	public sealed partial class Account_SetReactionsNotifySettings : IMethod<ReactionsNotifySettings>
	{
		public ReactionsNotifySettings settings;
	}

	[TLDef(0x2E7B4543)]
	public sealed partial class Account_GetCollectibleEmojiStatuses : IMethod<Account_EmojiStatuses>
	{
		public long hash;
	}

	[TLDef(0x0D91A548)]
	public sealed partial class Users_GetUsers : IMethod<UserBase[]>
	{
		public InputUserBase[] id;
	}

	[TLDef(0xB60F5918)]
	public sealed partial class Users_GetFullUser : IMethod<Users_UserFull>
	{
		public InputUserBase id;
	}

	[TLDef(0x90C894B5)]
	public sealed partial class Users_SetSecureValueErrors : IMethod<bool>
	{
		public InputUserBase id;
		public SecureValueErrorBase[] errors;
	}

	[TLDef(0xA622AA10)]
	public sealed partial class Users_GetIsPremiumRequiredToContact : IMethod<bool[]>
	{
		public InputUserBase[] id;
	}

	[TLDef(0x7ADC669D)]
	public sealed partial class Contacts_GetContactIDs : IMethod<int[]>
	{
		public long hash;
	}

	[TLDef(0xC4A353EE)]
	public sealed partial class Contacts_GetStatuses : IMethod<ContactStatus[]> { }

	[TLDef(0x5DD69E12)]
	public sealed partial class Contacts_GetContacts : IMethod<Contacts_Contacts>
	{
		public long hash;
	}

	[TLDef(0x2C800BE5)]
	public sealed partial class Contacts_ImportContacts : IMethod<Contacts_ImportedContacts>
	{
		public InputContact[] contacts;
	}

	[TLDef(0x096A0E00)]
	public sealed partial class Contacts_DeleteContacts : IMethod<UpdatesBase>
	{
		public InputUserBase[] id;
	}

	[TLDef(0x1013FD9E)]
	public sealed partial class Contacts_DeleteByPhones : IMethod<bool>
	{
		public string[] phones;
	}

	[TLDef(0x2E2E8734)]
	public sealed partial class Contacts_Block : IMethod<bool>
	{
		public Flags flags;
		public InputPeer id;

		[Flags] public enum Flags : uint
		{
			my_stories_from = 0x1,
		}
	}

	[TLDef(0xB550D328)]
	public sealed partial class Contacts_Unblock : IMethod<bool>
	{
		public Flags flags;
		public InputPeer id;

		[Flags] public enum Flags : uint
		{
			my_stories_from = 0x1,
		}
	}

	[TLDef(0x9A868F80)]
	public sealed partial class Contacts_GetBlocked : IMethod<Contacts_Blocked>
	{
		public Flags flags;
		public int offset;
		public int limit;

		[Flags] public enum Flags : uint
		{
			my_stories_from = 0x1,
		}
	}

	[TLDef(0x11F812D8)]
	public sealed partial class Contacts_Search : IMethod<Contacts_Found>
	{
		public string q;
		public int limit;
	}

	[TLDef(0x725AFBBC)]
	public sealed partial class Contacts_ResolveUsername : IMethod<Contacts_ResolvedPeer>
	{
		public Flags flags;
		public string username;
		[IfFlag(0)] public string referer;

		[Flags] public enum Flags : uint
		{
			has_referer = 0x1,
		}
	}

	[TLDef(0x973478B6)]
	public sealed partial class Contacts_GetTopPeers : IMethod<Contacts_TopPeersBase>
	{
		public Flags flags;
		public int offset;
		public int limit;
		public long hash;

		[Flags] public enum Flags : uint
		{
			correspondents = 0x1,
			bots_pm = 0x2,
			bots_inline = 0x4,
			phone_calls = 0x8,
			forward_users = 0x10,
			forward_chats = 0x20,
			groups = 0x400,
			channels = 0x8000,
			bots_app = 0x10000,
		}
	}

	[TLDef(0x1AE373AC)]
	public sealed partial class Contacts_ResetTopPeerRating : IMethod<bool>
	{
		public TopPeerCategory category;
		public InputPeer peer;
	}

	[TLDef(0x879537F1)]
	public sealed partial class Contacts_ResetSaved : IMethod<bool> { }

	[TLDef(0x82F1E39F)]
	public sealed partial class Contacts_GetSaved : IMethod<SavedContact[]> { }

	[TLDef(0x8514BDDA)]
	public sealed partial class Contacts_ToggleTopPeers : IMethod<bool>
	{
		public bool enabled;
	}

	[TLDef(0xE8F463D0)]
	public sealed partial class Contacts_AddContact : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputUserBase id;
		public string first_name;
		public string last_name;
		public string phone;

		[Flags] public enum Flags : uint
		{
			add_phone_privacy_exception = 0x1,
		}
	}

	[TLDef(0xF831A20F)]
	public sealed partial class Contacts_AcceptContact : IMethod<UpdatesBase>
	{
		public InputUserBase id;
	}

	[TLDef(0xD348BC44)]
	public sealed partial class Contacts_GetLocated : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputGeoPoint geo_point;
		[IfFlag(0)] public int self_expires;

		[Flags] public enum Flags : uint
		{
			has_self_expires = 0x1,
			background = 0x2,
		}
	}

	[TLDef(0x29A8962C)]
	public sealed partial class Contacts_BlockFromReplies : IMethod<UpdatesBase>
	{
		public Flags flags;
		public int msg_id;

		[Flags] public enum Flags : uint
		{
			delete_message = 0x1,
			delete_history = 0x2,
			report_spam = 0x4,
		}
	}

	[TLDef(0x8AF94344)]
	public sealed partial class Contacts_ResolvePhone : IMethod<Contacts_ResolvedPeer>
	{
		public string phone;
	}

	[TLDef(0xF8654027)]
	public sealed partial class Contacts_ExportContactToken : IMethod<ExportedContactToken> { }

	[TLDef(0x13005788)]
	public sealed partial class Contacts_ImportContactToken : IMethod<UserBase>
	{
		public string token;
	}

	[TLDef(0xBA6705F0)]
	public sealed partial class Contacts_EditCloseFriends : IMethod<bool>
	{
		public long[] id;
	}

	[TLDef(0x94C65C76)]
	public sealed partial class Contacts_SetBlocked : IMethod<bool>
	{
		public Flags flags;
		public InputPeer[] id;
		public int limit;

		[Flags] public enum Flags : uint
		{
			my_stories_from = 0x1,
		}
	}

	[TLDef(0xDAEDA864)]
	public sealed partial class Contacts_GetBirthdays : IMethod<Contacts_ContactBirthdays> { }

	[TLDef(0x63C66506)]
	public sealed partial class Messages_GetMessages : IMethod<Messages_MessagesBase>
	{
		public InputMessage[] id;
	}

	[TLDef(0xA0F4CB4F)]
	public sealed partial class Messages_GetDialogs : IMethod<Messages_DialogsBase>
	{
		public Flags flags;
		[IfFlag(1)] public int folder_id;
		public DateTime offset_date;
		public int offset_id;
		public InputPeer offset_peer;
		public int limit;
		public long hash;

		[Flags] public enum Flags : uint
		{
			exclude_pinned = 0x1,
			has_folder_id = 0x2,
		}
	}

	[TLDef(0x4423E6C5)]
	public sealed partial class Messages_GetHistory : IMethod<Messages_MessagesBase>
	{
		public InputPeer peer;
		public int offset_id;
		public DateTime offset_date;
		public int add_offset;
		public int limit;
		public int max_id;
		public int min_id;
		public long hash;
	}

	[TLDef(0x29EE847A)]
	public sealed partial class Messages_Search : IMethod<Messages_MessagesBase>
	{
		public Flags flags;
		public InputPeer peer;
		public string q;
		[IfFlag(0)] public InputPeer from_id;
		[IfFlag(2)] public InputPeer saved_peer_id;
		[IfFlag(3)] public Reaction[] saved_reaction;
		[IfFlag(1)] public int top_msg_id;
		public MessagesFilter filter;
		public DateTime min_date;
		public DateTime max_date;
		public int offset_id;
		public int add_offset;
		public int limit;
		public int max_id;
		public int min_id;
		public long hash;

		[Flags] public enum Flags : uint
		{
			has_from_id = 0x1,
			has_top_msg_id = 0x2,
			has_saved_peer_id = 0x4,
			has_saved_reaction = 0x8,
		}
	}

	[TLDef(0x0E306D3A)]
	public sealed partial class Messages_ReadHistory : IMethod<Messages_AffectedMessages>
	{
		public InputPeer peer;
		public int max_id;
	}

	[TLDef(0xB08F922A)]
	public sealed partial class Messages_DeleteHistory : IMethod<Messages_AffectedHistory>
	{
		public Flags flags;
		public InputPeer peer;
		public int max_id;
		[IfFlag(2)] public DateTime min_date;
		[IfFlag(3)] public DateTime max_date;

		[Flags] public enum Flags : uint
		{
			just_clear = 0x1,
			revoke = 0x2,
			has_min_date = 0x4,
			has_max_date = 0x8,
		}
	}

	[TLDef(0xE58E95D2)]
	public sealed partial class Messages_DeleteMessages : IMethod<Messages_AffectedMessages>
	{
		public Flags flags;
		public int[] id;

		[Flags] public enum Flags : uint
		{
			revoke = 0x1,
		}
	}

	[TLDef(0x05A954C0)]
	public sealed partial class Messages_ReceivedMessages : IMethod<ReceivedNotifyMessage[]>
	{
		public int max_id;
	}

	[TLDef(0x58943EE2)]
	public sealed partial class Messages_SetTyping : IMethod<bool>
	{
		public Flags flags;
		public InputPeer peer;
		[IfFlag(0)] public int top_msg_id;
		public SendMessageAction action;

		[Flags] public enum Flags : uint
		{
			has_top_msg_id = 0x1,
		}
	}

	[TLDef(0x983F9745)]
	public sealed partial class Messages_SendMessage : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPeer peer;
		[IfFlag(0)] public InputReplyTo reply_to;
		public string message;
		public long random_id;
		[IfFlag(2)] public ReplyMarkup reply_markup;
		[IfFlag(3)] public MessageEntity[] entities;
		[IfFlag(10)] public DateTime schedule_date;
		[IfFlag(13)] public InputPeer send_as;
		[IfFlag(17)] public InputQuickReplyShortcutBase quick_reply_shortcut;
		[IfFlag(18)] public long effect;

		[Flags] public enum Flags : uint
		{
			has_reply_to = 0x1,
			no_webpage = 0x2,
			has_reply_markup = 0x4,
			has_entities = 0x8,
			silent = 0x20,
			background = 0x40,
			clear_draft = 0x80,
			has_schedule_date = 0x400,
			has_send_as = 0x2000,
			noforwards = 0x4000,
			update_stickersets_order = 0x8000,
			invert_media = 0x10000,
			has_quick_reply_shortcut = 0x20000,
			has_effect = 0x40000,
			allow_paid_floodskip = 0x80000,
		}
	}

	[TLDef(0x7852834E)]
	public sealed partial class Messages_SendMedia : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPeer peer;
		[IfFlag(0)] public InputReplyTo reply_to;
		public InputMedia media;
		public string message;
		public long random_id;
		[IfFlag(2)] public ReplyMarkup reply_markup;
		[IfFlag(3)] public MessageEntity[] entities;
		[IfFlag(10)] public DateTime schedule_date;
		[IfFlag(13)] public InputPeer send_as;
		[IfFlag(17)] public InputQuickReplyShortcutBase quick_reply_shortcut;
		[IfFlag(18)] public long effect;

		[Flags] public enum Flags : uint
		{
			has_reply_to = 0x1,
			has_reply_markup = 0x4,
			has_entities = 0x8,
			silent = 0x20,
			background = 0x40,
			clear_draft = 0x80,
			has_schedule_date = 0x400,
			has_send_as = 0x2000,
			noforwards = 0x4000,
			update_stickersets_order = 0x8000,
			invert_media = 0x10000,
			has_quick_reply_shortcut = 0x20000,
			has_effect = 0x40000,
			allow_paid_floodskip = 0x80000,
		}
	}

	[TLDef(0x6D74DA08)]
	public sealed partial class Messages_ForwardMessages : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPeer from_peer;
		public int[] id;
		public long[] random_id;
		public InputPeer to_peer;
		[IfFlag(9)] public int top_msg_id;
		[IfFlag(10)] public DateTime schedule_date;
		[IfFlag(13)] public InputPeer send_as;
		[IfFlag(17)] public InputQuickReplyShortcutBase quick_reply_shortcut;
		[IfFlag(20)] public int video_timestamp;

		[Flags] public enum Flags : uint
		{
			silent = 0x20,
			background = 0x40,
			with_my_score = 0x100,
			has_top_msg_id = 0x200,
			has_schedule_date = 0x400,
			drop_author = 0x800,
			drop_media_captions = 0x1000,
			has_send_as = 0x2000,
			noforwards = 0x4000,
			has_quick_reply_shortcut = 0x20000,
			allow_paid_floodskip = 0x80000,
			has_video_timestamp = 0x100000,
		}
	}

	[TLDef(0xCF1592DB)]
	public sealed partial class Messages_ReportSpam : IMethod<bool>
	{
		public InputPeer peer;
	}

	[TLDef(0xEFD9A6A2)]
	public sealed partial class Messages_GetPeerSettings : IMethod<Messages_PeerSettings>
	{
		public InputPeer peer;
	}

	[TLDef(0xFC78AF9B)]
	public sealed partial class Messages_Report : IMethod<ReportResult>
	{
		public InputPeer peer;
		public int[] id;
		public byte[] option;
		public string message;
	}

	[TLDef(0x49E9528F)]
	public sealed partial class Messages_GetChats : IMethod<Messages_Chats>
	{
		public long[] id;
	}

	[TLDef(0xAEB00B34)]
	public sealed partial class Messages_GetFullChat : IMethod<Messages_ChatFull>
	{
		public long chat_id;
	}

	[TLDef(0x73783FFD)]
	public sealed partial class Messages_EditChatTitle : IMethod<UpdatesBase>
	{
		public long chat_id;
		public string title;
	}

	[TLDef(0x35DDD674)]
	public sealed partial class Messages_EditChatPhoto : IMethod<UpdatesBase>
	{
		public long chat_id;
		public InputChatPhotoBase photo;
	}

	[TLDef(0xCBC6D107)]
	public sealed partial class Messages_AddChatUser : IMethod<Messages_InvitedUsers>
	{
		public long chat_id;
		public InputUserBase user_id;
		public int fwd_limit;
	}

	[TLDef(0xA2185CAB)]
	public sealed partial class Messages_DeleteChatUser : IMethod<UpdatesBase>
	{
		public Flags flags;
		public long chat_id;
		public InputUserBase user_id;

		[Flags] public enum Flags : uint
		{
			revoke_history = 0x1,
		}
	}

	[TLDef(0x92CEDDD4)]
	public sealed partial class Messages_CreateChat : IMethod<Messages_InvitedUsers>
	{
		public Flags flags;
		public InputUserBase[] users;
		public string title;
		[IfFlag(0)] public int ttl_period;

		[Flags] public enum Flags : uint
		{
			has_ttl_period = 0x1,
		}
	}

	[TLDef(0x26CF8950)]
	public sealed partial class Messages_GetDhConfig : IMethod<Messages_DhConfigBase>
	{
		public int version;
		public int random_length;
	}

	[TLDef(0xF64DAF43)]
	public sealed partial class Messages_RequestEncryption : IMethod<EncryptedChatBase>
	{
		public InputUserBase user_id;
		public int random_id;
		public byte[] g_a;
	}

	[TLDef(0x3DBC0415)]
	public sealed partial class Messages_AcceptEncryption : IMethod<EncryptedChatBase>
	{
		public InputEncryptedChat peer;
		public byte[] g_b;
		public long key_fingerprint;
	}

	[TLDef(0xF393AEA0)]
	public sealed partial class Messages_DiscardEncryption : IMethod<bool>
	{
		public Flags flags;
		public int chat_id;

		[Flags] public enum Flags : uint
		{
			delete_history = 0x1,
		}
	}

	[TLDef(0x791451ED)]
	public sealed partial class Messages_SetEncryptedTyping : IMethod<bool>
	{
		public InputEncryptedChat peer;
		public bool typing;
	}

	[TLDef(0x7F4B690A)]
	public sealed partial class Messages_ReadEncryptedHistory : IMethod<bool>
	{
		public InputEncryptedChat peer;
		public DateTime max_date;
	}

	[TLDef(0x44FA7A15)]
	public sealed partial class Messages_SendEncrypted : IMethod<Messages_SentEncryptedMessage>
	{
		public Flags flags;
		public InputEncryptedChat peer;
		public long random_id;
		public byte[] data;

		[Flags] public enum Flags : uint
		{
			silent = 0x1,
		}
	}

	[TLDef(0x5559481D)]
	public sealed partial class Messages_SendEncryptedFile : IMethod<Messages_SentEncryptedMessage>
	{
		public Flags flags;
		public InputEncryptedChat peer;
		public long random_id;
		public byte[] data;
		public InputEncryptedFileBase file;

		[Flags] public enum Flags : uint
		{
			silent = 0x1,
		}
	}

	[TLDef(0x32D439A4)]
	public sealed partial class Messages_SendEncryptedService : IMethod<Messages_SentEncryptedMessage>
	{
		public InputEncryptedChat peer;
		public long random_id;
		public byte[] data;
	}

	[TLDef(0x55A5BB66)]
	public sealed partial class Messages_ReceivedQueue : IMethod<long[]>
	{
		public int max_qts;
	}

	[TLDef(0x4B0C8C0F)]
	public sealed partial class Messages_ReportEncryptedSpam : IMethod<bool>
	{
		public InputEncryptedChat peer;
	}

	[TLDef(0x36A73F77)]
	public sealed partial class Messages_ReadMessageContents : IMethod<Messages_AffectedMessages>
	{
		public int[] id;
	}

	[TLDef(0xD5A5D3A1)]
	public sealed partial class Messages_GetStickers : IMethod<Messages_Stickers>
	{
		public string emoticon;
		public long hash;
	}

	[TLDef(0xB8A0A1A8)]
	public sealed partial class Messages_GetAllStickers : IMethod<Messages_AllStickers>
	{
		public long hash;
	}

	[TLDef(0x570D6F6F)]
	public sealed partial class Messages_GetWebPagePreview : IMethod<Messages_WebPagePreview>
	{
		public Flags flags;
		public string message;
		[IfFlag(3)] public MessageEntity[] entities;

		[Flags] public enum Flags : uint
		{
			has_entities = 0x8,
		}
	}

	[TLDef(0xA455DE90)]
	public sealed partial class Messages_ExportChatInvite : IMethod<ExportedChatInvite>
	{
		public Flags flags;
		public InputPeer peer;
		[IfFlag(0)] public DateTime expire_date;
		[IfFlag(1)] public int usage_limit;
		[IfFlag(4)] public string title;
		[IfFlag(5)] public StarsSubscriptionPricing subscription_pricing;

		[Flags] public enum Flags : uint
		{
			has_expire_date = 0x1,
			has_usage_limit = 0x2,
			legacy_revoke_permanent = 0x4,
			request_needed = 0x8,
			has_title = 0x10,
			has_subscription_pricing = 0x20,
		}
	}

	[TLDef(0x3EADB1BB)]
	public sealed partial class Messages_CheckChatInvite : IMethod<ChatInviteBase>
	{
		public string hash;
	}

	[TLDef(0x6C50051C)]
	public sealed partial class Messages_ImportChatInvite : IMethod<UpdatesBase>
	{
		public string hash;
	}

	[TLDef(0xC8A0EC74)]
	public sealed partial class Messages_GetStickerSet : IMethod<Messages_StickerSet>
	{
		public InputStickerSet stickerset;
		public int hash;
	}

	[TLDef(0xC78FE460)]
	public sealed partial class Messages_InstallStickerSet : IMethod<Messages_StickerSetInstallResult>
	{
		public InputStickerSet stickerset;
		public bool archived;
	}

	[TLDef(0xF96E55DE)]
	public sealed partial class Messages_UninstallStickerSet : IMethod<bool>
	{
		public InputStickerSet stickerset;
	}

	[TLDef(0xE6DF7378)]
	public sealed partial class Messages_StartBot : IMethod<UpdatesBase>
	{
		public InputUserBase bot;
		public InputPeer peer;
		public long random_id;
		public string start_param;
	}

	[TLDef(0x5784D3E1)]
	public sealed partial class Messages_GetMessagesViews : IMethod<Messages_MessageViews>
	{
		public InputPeer peer;
		public int[] id;
		public bool increment;
	}

	[TLDef(0xA85BD1C2)]
	public sealed partial class Messages_EditChatAdmin : IMethod<bool>
	{
		public long chat_id;
		public InputUserBase user_id;
		public bool is_admin;
	}

	[TLDef(0xA2875319)]
	public sealed partial class Messages_MigrateChat : IMethod<UpdatesBase>
	{
		public long chat_id;
	}

	[TLDef(0x4BC6589A)]
	public sealed partial class Messages_SearchGlobal : IMethod<Messages_MessagesBase>
	{
		public Flags flags;
		[IfFlag(0)] public int folder_id;
		public string q;
		public MessagesFilter filter;
		public DateTime min_date;
		public DateTime max_date;
		public int offset_rate;
		public InputPeer offset_peer;
		public int offset_id;
		public int limit;

		[Flags] public enum Flags : uint
		{
			has_folder_id = 0x1,
			broadcasts_only = 0x2,
			groups_only = 0x4,
			users_only = 0x8,
		}
	}

	[TLDef(0x78337739)]
	public sealed partial class Messages_ReorderStickerSets : IMethod<bool>
	{
		public Flags flags;
		public long[] order;

		[Flags] public enum Flags : uint
		{
			masks = 0x1,
			emojis = 0x2,
		}
	}

	[TLDef(0xB1F2061F)]
	public sealed partial class Messages_GetDocumentByHash : IMethod<DocumentBase>
	{
		public byte[] sha256;
		public long size;
		public string mime_type;
	}

	[TLDef(0x5CF09635)]
	public sealed partial class Messages_GetSavedGifs : IMethod<Messages_SavedGifs>
	{
		public long hash;
	}

	[TLDef(0x327A30CB)]
	public sealed partial class Messages_SaveGif : IMethod<bool>
	{
		public InputDocument id;
		public bool unsave;
	}

	[TLDef(0x514E999D)]
	public sealed partial class Messages_GetInlineBotResults : IMethod<Messages_BotResults>
	{
		public Flags flags;
		public InputUserBase bot;
		public InputPeer peer;
		[IfFlag(0)] public InputGeoPoint geo_point;
		public string query;
		public string offset;

		[Flags] public enum Flags : uint
		{
			has_geo_point = 0x1,
		}
	}

	[TLDef(0xBB12A419)]
	public sealed partial class Messages_SetInlineBotResults : IMethod<bool>
	{
		public Flags flags;
		public long query_id;
		public InputBotInlineResultBase[] results;
		public int cache_time;
		[IfFlag(2)] public string next_offset;
		[IfFlag(3)] public InlineBotSwitchPM switch_pm;
		[IfFlag(4)] public InlineBotWebView switch_webview;

		[Flags] public enum Flags : uint
		{
			gallery = 0x1,
			private_ = 0x2,
			has_next_offset = 0x4,
			has_switch_pm = 0x8,
			has_switch_webview = 0x10,
		}
	}

	[TLDef(0x3EBEE86A)]
	public sealed partial class Messages_SendInlineBotResult : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPeer peer;
		[IfFlag(0)] public InputReplyTo reply_to;
		public long random_id;
		public long query_id;
		public string id;
		[IfFlag(10)] public DateTime schedule_date;
		[IfFlag(13)] public InputPeer send_as;
		[IfFlag(17)] public InputQuickReplyShortcutBase quick_reply_shortcut;

		[Flags] public enum Flags : uint
		{
			has_reply_to = 0x1,
			silent = 0x20,
			background = 0x40,
			clear_draft = 0x80,
			has_schedule_date = 0x400,
			hide_via = 0x800,
			has_send_as = 0x2000,
			has_quick_reply_shortcut = 0x20000,
		}
	}

	[TLDef(0xFDA68D36)]
	public sealed partial class Messages_GetMessageEditData : IMethod<Messages_MessageEditData>
	{
		public InputPeer peer;
		public int id;
	}

	[TLDef(0xDFD14005)]
	public sealed partial class Messages_EditMessage : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPeer peer;
		public int id;
		[IfFlag(11)] public string message;
		[IfFlag(14)] public InputMedia media;
		[IfFlag(2)] public ReplyMarkup reply_markup;
		[IfFlag(3)] public MessageEntity[] entities;
		[IfFlag(15)] public DateTime schedule_date;
		[IfFlag(17)] public int quick_reply_shortcut_id;

		[Flags] public enum Flags : uint
		{
			no_webpage = 0x2,
			has_reply_markup = 0x4,
			has_entities = 0x8,
			has_message = 0x800,
			has_media = 0x4000,
			has_schedule_date = 0x8000,
			invert_media = 0x10000,
			has_quick_reply_shortcut_id = 0x20000,
		}
	}

	[TLDef(0x83557DBA)]
	public sealed partial class Messages_EditInlineBotMessage : IMethod<bool>
	{
		public Flags flags;
		public InputBotInlineMessageIDBase id;
		[IfFlag(11)] public string message;
		[IfFlag(14)] public InputMedia media;
		[IfFlag(2)] public ReplyMarkup reply_markup;
		[IfFlag(3)] public MessageEntity[] entities;

		[Flags] public enum Flags : uint
		{
			no_webpage = 0x2,
			has_reply_markup = 0x4,
			has_entities = 0x8,
			has_message = 0x800,
			has_media = 0x4000,
			invert_media = 0x10000,
		}
	}

	[TLDef(0x9342CA07)]
	public sealed partial class Messages_GetBotCallbackAnswer : IMethod<Messages_BotCallbackAnswer>
	{
		public Flags flags;
		public InputPeer peer;
		public int msg_id;
		[IfFlag(0)] public byte[] data;
		[IfFlag(2)] public InputCheckPasswordSRP password;

		[Flags] public enum Flags : uint
		{
			has_data = 0x1,
			game = 0x2,
			has_password = 0x4,
		}
	}

	[TLDef(0xD58F130A)]
	public sealed partial class Messages_SetBotCallbackAnswer : IMethod<bool>
	{
		public Flags flags;
		public long query_id;
		[IfFlag(0)] public string message;
		[IfFlag(2)] public string url;
		public int cache_time;

		[Flags] public enum Flags : uint
		{
			has_message = 0x1,
			alert = 0x2,
			has_url = 0x4,
		}
	}

	[TLDef(0xE470BCFD)]
	public sealed partial class Messages_GetPeerDialogs : IMethod<Messages_PeerDialogs>
	{
		public InputDialogPeerBase[] peers;
	}

	[TLDef(0xD372C5CE)]
	public sealed partial class Messages_SaveDraft : IMethod<bool>
	{
		public Flags flags;
		[IfFlag(4)] public InputReplyTo reply_to;
		public InputPeer peer;
		public string message;
		[IfFlag(3)] public MessageEntity[] entities;
		[IfFlag(5)] public InputMedia media;
		[IfFlag(7)] public long effect;

		[Flags] public enum Flags : uint
		{
			no_webpage = 0x2,
			has_entities = 0x8,
			has_reply_to = 0x10,
			has_media = 0x20,
			invert_media = 0x40,
			has_effect = 0x80,
		}
	}

	[TLDef(0x6A3F8D65)]
	public sealed partial class Messages_GetAllDrafts : IMethod<UpdatesBase> { }

	[TLDef(0x64780B14)]
	public sealed partial class Messages_GetFeaturedStickers : IMethod<Messages_FeaturedStickersBase>
	{
		public long hash;
	}

	[TLDef(0x5B118126)]
	public sealed partial class Messages_ReadFeaturedStickers : IMethod<bool>
	{
		public long[] id;
	}

	[TLDef(0x9DA9403B)]
	public sealed partial class Messages_GetRecentStickers : IMethod<Messages_RecentStickers>
	{
		public Flags flags;
		public long hash;

		[Flags] public enum Flags : uint
		{
			attached = 0x1,
		}
	}

	[TLDef(0x392718F8)]
	public sealed partial class Messages_SaveRecentSticker : IMethod<bool>
	{
		public Flags flags;
		public InputDocument id;
		public bool unsave;

		[Flags] public enum Flags : uint
		{
			attached = 0x1,
		}
	}

	[TLDef(0x8999602D)]
	public sealed partial class Messages_ClearRecentStickers : IMethod<bool>
	{
		public Flags flags;

		[Flags] public enum Flags : uint
		{
			attached = 0x1,
		}
	}

	[TLDef(0x57F17692)]
	public sealed partial class Messages_GetArchivedStickers : IMethod<Messages_ArchivedStickers>
	{
		public Flags flags;
		public long offset_id;
		public int limit;

		[Flags] public enum Flags : uint
		{
			masks = 0x1,
			emojis = 0x2,
		}
	}

	[TLDef(0x640F82B8)]
	public sealed partial class Messages_GetMaskStickers : IMethod<Messages_AllStickers>
	{
		public long hash;
	}

	[TLDef(0xCC5B67CC)]
	public sealed partial class Messages_GetAttachedStickers : IMethod<StickerSetCoveredBase[]>
	{
		public InputStickeredMedia media;
	}

	[TLDef(0x8EF8ECC0)]
	public sealed partial class Messages_SetGameScore : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPeer peer;
		public int id;
		public InputUserBase user_id;
		public int score;

		[Flags] public enum Flags : uint
		{
			edit_message = 0x1,
			force = 0x2,
		}
	}

	[TLDef(0x15AD9F64)]
	public sealed partial class Messages_SetInlineGameScore : IMethod<bool>
	{
		public Flags flags;
		public InputBotInlineMessageIDBase id;
		public InputUserBase user_id;
		public int score;

		[Flags] public enum Flags : uint
		{
			edit_message = 0x1,
			force = 0x2,
		}
	}

	[TLDef(0xE822649D)]
	public sealed partial class Messages_GetGameHighScores : IMethod<Messages_HighScores>
	{
		public InputPeer peer;
		public int id;
		public InputUserBase user_id;
	}

	[TLDef(0x0F635E1B)]
	public sealed partial class Messages_GetInlineGameHighScores : IMethod<Messages_HighScores>
	{
		public InputBotInlineMessageIDBase id;
		public InputUserBase user_id;
	}

	[TLDef(0xE40CA104)]
	public sealed partial class Messages_GetCommonChats : IMethod<Messages_Chats>
	{
		public InputUserBase user_id;
		public long max_id;
		public int limit;
	}

	[TLDef(0x8D9692A3)]
	public sealed partial class Messages_GetWebPage : IMethod<Messages_WebPage>
	{
		public string url;
		public int hash;
	}

	[TLDef(0xA731E257)]
	public sealed partial class Messages_ToggleDialogPin : IMethod<bool>
	{
		public Flags flags;
		public InputDialogPeerBase peer;

		[Flags] public enum Flags : uint
		{
			pinned = 0x1,
		}
	}

	[TLDef(0x3B1ADF37)]
	public sealed partial class Messages_ReorderPinnedDialogs : IMethod<bool>
	{
		public Flags flags;
		public int folder_id;
		public InputDialogPeerBase[] order;

		[Flags] public enum Flags : uint
		{
			force = 0x1,
		}
	}

	[TLDef(0xD6B94DF2)]
	public sealed partial class Messages_GetPinnedDialogs : IMethod<Messages_PeerDialogs>
	{
		public int folder_id;
	}

	[TLDef(0xE5F672FA)]
	public sealed partial class Messages_SetBotShippingResults : IMethod<bool>
	{
		public Flags flags;
		public long query_id;
		[IfFlag(0)] public string error;
		[IfFlag(1)] public ShippingOption[] shipping_options;

		[Flags] public enum Flags : uint
		{
			has_error = 0x1,
			has_shipping_options = 0x2,
		}
	}

	[TLDef(0x09C2DD95)]
	public sealed partial class Messages_SetBotPrecheckoutResults : IMethod<bool>
	{
		public Flags flags;
		public long query_id;
		[IfFlag(0)] public string error;

		[Flags] public enum Flags : uint
		{
			has_error = 0x1,
			success = 0x2,
		}
	}

	[TLDef(0x14967978)]
	public sealed partial class Messages_UploadMedia : IMethod<MessageMedia>
	{
		public Flags flags;
		[IfFlag(0)] public string business_connection_id;
		public InputPeer peer;
		public InputMedia media;

		[Flags] public enum Flags : uint
		{
			has_business_connection_id = 0x1,
		}
	}

	[TLDef(0xA1405817)]
	public sealed partial class Messages_SendScreenshotNotification : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public InputReplyTo reply_to;
		public long random_id;
	}

	[TLDef(0x04F1AAA9)]
	public sealed partial class Messages_GetFavedStickers : IMethod<Messages_FavedStickers>
	{
		public long hash;
	}

	[TLDef(0xB9FFC55B)]
	public sealed partial class Messages_FaveSticker : IMethod<bool>
	{
		public InputDocument id;
		public bool unfave;
	}

	[TLDef(0xF107E790)]
	public sealed partial class Messages_GetUnreadMentions : IMethod<Messages_MessagesBase>
	{
		public Flags flags;
		public InputPeer peer;
		[IfFlag(0)] public int top_msg_id;
		public int offset_id;
		public int add_offset;
		public int limit;
		public int max_id;
		public int min_id;

		[Flags] public enum Flags : uint
		{
			has_top_msg_id = 0x1,
		}
	}

	[TLDef(0x36E5BF4D)]
	public sealed partial class Messages_ReadMentions : IMethod<Messages_AffectedHistory>
	{
		public Flags flags;
		public InputPeer peer;
		[IfFlag(0)] public int top_msg_id;

		[Flags] public enum Flags : uint
		{
			has_top_msg_id = 0x1,
		}
	}

	[TLDef(0x702A40E0)]
	public sealed partial class Messages_GetRecentLocations : IMethod<Messages_MessagesBase>
	{
		public InputPeer peer;
		public int limit;
		public long hash;
	}

	[TLDef(0x37B74355)]
	public sealed partial class Messages_SendMultiMedia : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPeer peer;
		[IfFlag(0)] public InputReplyTo reply_to;
		public InputSingleMedia[] multi_media;
		[IfFlag(10)] public DateTime schedule_date;
		[IfFlag(13)] public InputPeer send_as;
		[IfFlag(17)] public InputQuickReplyShortcutBase quick_reply_shortcut;
		[IfFlag(18)] public long effect;

		[Flags] public enum Flags : uint
		{
			has_reply_to = 0x1,
			silent = 0x20,
			background = 0x40,
			clear_draft = 0x80,
			has_schedule_date = 0x400,
			has_send_as = 0x2000,
			noforwards = 0x4000,
			update_stickersets_order = 0x8000,
			invert_media = 0x10000,
			has_quick_reply_shortcut = 0x20000,
			has_effect = 0x40000,
			allow_paid_floodskip = 0x80000,
		}
	}

	[TLDef(0x5057C497)]
	public sealed partial class Messages_UploadEncryptedFile : IMethod<EncryptedFile>
	{
		public InputEncryptedChat peer;
		public InputEncryptedFileBase file;
	}

	[TLDef(0x35705B8A)]
	public sealed partial class Messages_SearchStickerSets : IMethod<Messages_FoundStickerSets>
	{
		public Flags flags;
		public string q;
		public long hash;

		[Flags] public enum Flags : uint
		{
			exclude_featured = 0x1,
		}
	}

	[TLDef(0x1CFF7E08)]
	public sealed partial class Messages_GetSplitRanges : IMethod<MessageRange[]> { }

	[TLDef(0xC286D98F)]
	public sealed partial class Messages_MarkDialogUnread : IMethod<bool>
	{
		public Flags flags;
		public InputDialogPeerBase peer;

		[Flags] public enum Flags : uint
		{
			unread = 0x1,
		}
	}

	[TLDef(0x22E24E22)]
	public sealed partial class Messages_GetDialogUnreadMarks : IMethod<DialogPeerBase[]> { }

	[TLDef(0x7E58EE9C)]
	public sealed partial class Messages_ClearAllDrafts : IMethod<bool> { }

	[TLDef(0xD2AAF7EC)]
	public sealed partial class Messages_UpdatePinnedMessage : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPeer peer;
		public int id;

		[Flags] public enum Flags : uint
		{
			silent = 0x1,
			unpin = 0x2,
			pm_oneside = 0x4,
		}
	}

	[TLDef(0x10EA6184)]
	public sealed partial class Messages_SendVote : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public int msg_id;
		public byte[][] options;
	}

	[TLDef(0x73BB643B)]
	public sealed partial class Messages_GetPollResults : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public int msg_id;
	}

	[TLDef(0x6E2BE050)]
	public sealed partial class Messages_GetOnlines : IMethod<ChatOnlines>
	{
		public InputPeer peer;
	}

	[TLDef(0xDEF60797)]
	public sealed partial class Messages_EditChatAbout : IMethod<bool>
	{
		public InputPeer peer;
		public string about;
	}

	[TLDef(0xA5866B41)]
	public sealed partial class Messages_EditChatDefaultBannedRights : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public ChatBannedRights banned_rights;
	}

	[TLDef(0x35A0E062)]
	public sealed partial class Messages_GetEmojiKeywords : IMethod<EmojiKeywordsDifference>
	{
		public string lang_code;
	}

	[TLDef(0x1508B6AF)]
	public sealed partial class Messages_GetEmojiKeywordsDifference : IMethod<EmojiKeywordsDifference>
	{
		public string lang_code;
		public int from_version;
	}

	[TLDef(0x4E9963B2)]
	public sealed partial class Messages_GetEmojiKeywordsLanguages : IMethod<EmojiLanguage[]>
	{
		public string[] lang_codes;
	}

	[TLDef(0xD5B10C26)]
	public sealed partial class Messages_GetEmojiURL : IMethod<EmojiURL>
	{
		public string lang_code;
	}

	[TLDef(0x1BBCF300)]
	public sealed partial class Messages_GetSearchCounters : IMethod<Messages_SearchCounter[]>
	{
		public Flags flags;
		public InputPeer peer;
		[IfFlag(2)] public InputPeer saved_peer_id;
		[IfFlag(0)] public int top_msg_id;
		public MessagesFilter[] filters;

		[Flags] public enum Flags : uint
		{
			has_top_msg_id = 0x1,
			has_saved_peer_id = 0x4,
		}
	}

	[TLDef(0x198FB446)]
	public sealed partial class Messages_RequestUrlAuth : IMethod<UrlAuthResult>
	{
		public Flags flags;
		[IfFlag(1)] public InputPeer peer;
		[IfFlag(1)] public int msg_id;
		[IfFlag(1)] public int button_id;
		[IfFlag(2)] public string url;

		[Flags] public enum Flags : uint
		{
			has_peer = 0x2,
			has_url = 0x4,
		}
	}

	[TLDef(0xB12C7125)]
	public sealed partial class Messages_AcceptUrlAuth : IMethod<UrlAuthResult>
	{
		public Flags flags;
		[IfFlag(1)] public InputPeer peer;
		[IfFlag(1)] public int msg_id;
		[IfFlag(1)] public int button_id;
		[IfFlag(2)] public string url;

		[Flags] public enum Flags : uint
		{
			write_allowed = 0x1,
			has_peer = 0x2,
			has_url = 0x4,
		}
	}

	[TLDef(0x4FACB138)]
	public sealed partial class Messages_HidePeerSettingsBar : IMethod<bool>
	{
		public InputPeer peer;
	}

	[TLDef(0xF516760B)]
	public sealed partial class Messages_GetScheduledHistory : IMethod<Messages_MessagesBase>
	{
		public InputPeer peer;
		public long hash;
	}

	[TLDef(0xBDBB0464)]
	public sealed partial class Messages_GetScheduledMessages : IMethod<Messages_MessagesBase>
	{
		public InputPeer peer;
		public int[] id;
	}

	[TLDef(0xBD38850A)]
	public sealed partial class Messages_SendScheduledMessages : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public int[] id;
	}

	[TLDef(0x59AE2B16)]
	public sealed partial class Messages_DeleteScheduledMessages : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public int[] id;
	}

	[TLDef(0xB86E380E)]
	public sealed partial class Messages_GetPollVotes : IMethod<Messages_VotesList>
	{
		public Flags flags;
		public InputPeer peer;
		public int id;
		[IfFlag(0)] public byte[] option;
		[IfFlag(1)] public string offset;
		public int limit;

		[Flags] public enum Flags : uint
		{
			has_option = 0x1,
			has_offset = 0x2,
		}
	}

	[TLDef(0xB5052FEA)]
	public sealed partial class Messages_ToggleStickerSets : IMethod<bool>
	{
		public Flags flags;
		public InputStickerSet[] stickersets;

		[Flags] public enum Flags : uint
		{
			uninstall = 0x1,
			archive = 0x2,
			unarchive = 0x4,
		}
	}

	[TLDef(0xEFD48C89)]
	public sealed partial class Messages_GetDialogFilters : IMethod<Messages_DialogFilters> { }

	[TLDef(0xA29CD42C)]
	public sealed partial class Messages_GetSuggestedDialogFilters : IMethod<DialogFilterSuggested[]> { }

	[TLDef(0x1AD4A04A)]
	public sealed partial class Messages_UpdateDialogFilter : IMethod<bool>
	{
		public Flags flags;
		public int id;
		[IfFlag(0)] public DialogFilterBase filter;

		[Flags] public enum Flags : uint
		{
			has_filter = 0x1,
		}
	}

	[TLDef(0xC563C1E4)]
	public sealed partial class Messages_UpdateDialogFiltersOrder : IMethod<bool>
	{
		public int[] order;
	}

	[TLDef(0x7ED094A1)]
	public sealed partial class Messages_GetOldFeaturedStickers : IMethod<Messages_FeaturedStickersBase>
	{
		public int offset;
		public int limit;
		public long hash;
	}

	[TLDef(0x22DDD30C)]
	public sealed partial class Messages_GetReplies : IMethod<Messages_MessagesBase>
	{
		public InputPeer peer;
		public int msg_id;
		public int offset_id;
		public DateTime offset_date;
		public int add_offset;
		public int limit;
		public int max_id;
		public int min_id;
		public long hash;
	}

	[TLDef(0x446972FD)]
	public sealed partial class Messages_GetDiscussionMessage : IMethod<Messages_DiscussionMessage>
	{
		public InputPeer peer;
		public int msg_id;
	}

	[TLDef(0xF731A9F4)]
	public sealed partial class Messages_ReadDiscussion : IMethod<bool>
	{
		public InputPeer peer;
		public int msg_id;
		public int read_max_id;
	}

	[TLDef(0xEE22B9A8)]
	public sealed partial class Messages_UnpinAllMessages : IMethod<Messages_AffectedHistory>
	{
		public Flags flags;
		public InputPeer peer;
		[IfFlag(0)] public int top_msg_id;

		[Flags] public enum Flags : uint
		{
			has_top_msg_id = 0x1,
		}
	}

	[TLDef(0x5BD0EE50)]
	public sealed partial class Messages_DeleteChat : IMethod<bool>
	{
		public long chat_id;
	}

	[TLDef(0xF9CBE409)]
	public sealed partial class Messages_DeletePhoneCallHistory : IMethod<Messages_AffectedFoundMessages>
	{
		public Flags flags;

		[Flags] public enum Flags : uint
		{
			revoke = 0x1,
		}
	}

	[TLDef(0x43FE19F3)]
	public sealed partial class Messages_CheckHistoryImport : IMethod<Messages_HistoryImportParsed>
	{
		public string import_head;
	}

	[TLDef(0x34090C3B)]
	public sealed partial class Messages_InitHistoryImport : IMethod<Messages_HistoryImport>
	{
		public InputPeer peer;
		public InputFileBase file;
		public int media_count;
	}

	[TLDef(0x2A862092)]
	public sealed partial class Messages_UploadImportedMedia : IMethod<MessageMedia>
	{
		public InputPeer peer;
		public long import_id;
		public string file_name;
		public InputMedia media;
	}

	[TLDef(0xB43DF344)]
	public sealed partial class Messages_StartHistoryImport : IMethod<bool>
	{
		public InputPeer peer;
		public long import_id;
	}

	[TLDef(0xA2B5A3F6)]
	public sealed partial class Messages_GetExportedChatInvites : IMethod<Messages_ExportedChatInvites>
	{
		public Flags flags;
		public InputPeer peer;
		public InputUserBase admin_id;
		[IfFlag(2)] public DateTime offset_date;
		[IfFlag(2)] public string offset_link;
		public int limit;

		[Flags] public enum Flags : uint
		{
			has_offset_date = 0x4,
			revoked = 0x8,
		}
	}

	[TLDef(0x73746F5C)]
	public sealed partial class Messages_GetExportedChatInvite : IMethod<Messages_ExportedChatInviteBase>
	{
		public InputPeer peer;
		public string link;
	}

	[TLDef(0xBDCA2F75)]
	public sealed partial class Messages_EditExportedChatInvite : IMethod<Messages_ExportedChatInviteBase>
	{
		public Flags flags;
		public InputPeer peer;
		public string link;
		[IfFlag(0)] public DateTime expire_date;
		[IfFlag(1)] public int usage_limit;
		[IfFlag(3)] public bool request_needed;
		[IfFlag(4)] public string title;

		[Flags] public enum Flags : uint
		{
			has_expire_date = 0x1,
			has_usage_limit = 0x2,
			revoked = 0x4,
			has_request_needed = 0x8,
			has_title = 0x10,
		}
	}

	[TLDef(0x56987BD5)]
	public sealed partial class Messages_DeleteRevokedExportedChatInvites : IMethod<bool>
	{
		public InputPeer peer;
		public InputUserBase admin_id;
	}

	[TLDef(0xD464A42B)]
	public sealed partial class Messages_DeleteExportedChatInvite : IMethod<bool>
	{
		public InputPeer peer;
		public string link;
	}

	[TLDef(0x3920E6EF)]
	public sealed partial class Messages_GetAdminsWithInvites : IMethod<Messages_ChatAdminsWithInvites>
	{
		public InputPeer peer;
	}

	[TLDef(0xDF04DD4E)]
	public sealed partial class Messages_GetChatInviteImporters : IMethod<Messages_ChatInviteImporters>
	{
		public Flags flags;
		public InputPeer peer;
		[IfFlag(1)] public string link;
		[IfFlag(2)] public string q;
		public DateTime offset_date;
		public InputUserBase offset_user;
		public int limit;

		[Flags] public enum Flags : uint
		{
			requested = 0x1,
			has_link = 0x2,
			has_q = 0x4,
			subscription_expired = 0x8,
		}
	}

	[TLDef(0xB80E5FE4)]
	public sealed partial class Messages_SetHistoryTTL : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public int period;
	}

	[TLDef(0x5DC60F03)]
	public sealed partial class Messages_CheckHistoryImportPeer : IMethod<Messages_CheckedHistoryImportPeer>
	{
		public InputPeer peer;
	}

	[TLDef(0xE63BE13F)]
	public sealed partial class Messages_SetChatTheme : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public string emoticon;
	}

	[TLDef(0x31C1C44F)]
	public sealed partial class Messages_GetMessageReadParticipants : IMethod<ReadParticipantDate[]>
	{
		public InputPeer peer;
		public int msg_id;
	}

	[TLDef(0x6AA3F6BD)]
	public sealed partial class Messages_GetSearchResultsCalendar : IMethod<Messages_SearchResultsCalendar>
	{
		public Flags flags;
		public InputPeer peer;
		[IfFlag(2)] public InputPeer saved_peer_id;
		public MessagesFilter filter;
		public int offset_id;
		public DateTime offset_date;

		[Flags] public enum Flags : uint
		{
			has_saved_peer_id = 0x4,
		}
	}

	[TLDef(0x9C7F2F10)]
	public sealed partial class Messages_GetSearchResultsPositions : IMethod<Messages_SearchResultsPositions>
	{
		public Flags flags;
		public InputPeer peer;
		[IfFlag(2)] public InputPeer saved_peer_id;
		public MessagesFilter filter;
		public int offset_id;
		public int limit;

		[Flags] public enum Flags : uint
		{
			has_saved_peer_id = 0x4,
		}
	}

	[TLDef(0x7FE7E815)]
	public sealed partial class Messages_HideChatJoinRequest : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPeer peer;
		public InputUserBase user_id;

		[Flags] public enum Flags : uint
		{
			approved = 0x1,
		}
	}

	[TLDef(0xE085F4EA)]
	public sealed partial class Messages_HideAllChatJoinRequests : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPeer peer;
		[IfFlag(1)] public string link;

		[Flags] public enum Flags : uint
		{
			approved = 0x1,
			has_link = 0x2,
		}
	}

	[TLDef(0xB11EAFA2)]
	public sealed partial class Messages_ToggleNoForwards : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public bool enabled;
	}

	[TLDef(0xCCFDDF96)]
	public sealed partial class Messages_SaveDefaultSendAs : IMethod<bool>
	{
		public InputPeer peer;
		public InputPeer send_as;
	}

	[TLDef(0xD30D78D4)]
	public sealed partial class Messages_SendReaction : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPeer peer;
		public int msg_id;
		[IfFlag(0)] public Reaction[] reaction;

		[Flags] public enum Flags : uint
		{
			has_reaction = 0x1,
			big = 0x2,
			add_to_recent = 0x4,
		}
	}

	[TLDef(0x8BBA90E6)]
	public sealed partial class Messages_GetMessagesReactions : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public int[] id;
	}

	[TLDef(0x461B3F48)]
	public sealed partial class Messages_GetMessageReactionsList : IMethod<Messages_MessageReactionsList>
	{
		public Flags flags;
		public InputPeer peer;
		public int id;
		[IfFlag(0)] public Reaction reaction;
		[IfFlag(1)] public string offset;
		public int limit;

		[Flags] public enum Flags : uint
		{
			has_reaction = 0x1,
			has_offset = 0x2,
		}
	}

	[TLDef(0x864B2581)]
	public sealed partial class Messages_SetChatAvailableReactions : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPeer peer;
		public ChatReactions available_reactions;
		[IfFlag(0)] public int reactions_limit;
		[IfFlag(1)] public bool paid_enabled;

		[Flags] public enum Flags : uint
		{
			has_reactions_limit = 0x1,
			has_paid_enabled = 0x2,
		}
	}

	[TLDef(0x18DEA0AC)]
	public sealed partial class Messages_GetAvailableReactions : IMethod<Messages_AvailableReactions>
	{
		public int hash;
	}

	[TLDef(0x4F47A016)]
	public sealed partial class Messages_SetDefaultReaction : IMethod<bool>
	{
		public Reaction reaction;
	}

	[TLDef(0x63183030)]
	public sealed partial class Messages_TranslateText : IMethod<Messages_TranslatedText>
	{
		public Flags flags;
		[IfFlag(0)] public InputPeer peer;
		[IfFlag(0)] public int[] id;
		[IfFlag(1)] public TextWithEntities[] text;
		public string to_lang;

		[Flags] public enum Flags : uint
		{
			has_peer = 0x1,
			has_text = 0x2,
		}
	}

	[TLDef(0x3223495B)]
	public sealed partial class Messages_GetUnreadReactions : IMethod<Messages_MessagesBase>
	{
		public Flags flags;
		public InputPeer peer;
		[IfFlag(0)] public int top_msg_id;
		public int offset_id;
		public int add_offset;
		public int limit;
		public int max_id;
		public int min_id;

		[Flags] public enum Flags : uint
		{
			has_top_msg_id = 0x1,
		}
	}

	[TLDef(0x54AA7F8E)]
	public sealed partial class Messages_ReadReactions : IMethod<Messages_AffectedHistory>
	{
		public Flags flags;
		public InputPeer peer;
		[IfFlag(0)] public int top_msg_id;

		[Flags] public enum Flags : uint
		{
			has_top_msg_id = 0x1,
		}
	}

	[TLDef(0x107E31A0)]
	public sealed partial class Messages_SearchSentMedia : IMethod<Messages_MessagesBase>
	{
		public string q;
		public MessagesFilter filter;
		public int limit;
	}

	[TLDef(0x16FCC2CB)]
	public sealed partial class Messages_GetAttachMenuBots : IMethod<AttachMenuBots>
	{
		public long hash;
	}

	[TLDef(0x77216192)]
	public sealed partial class Messages_GetAttachMenuBot : IMethod<AttachMenuBotsBot>
	{
		public InputUserBase bot;
	}

	[TLDef(0x69F59D69)]
	public sealed partial class Messages_ToggleBotInAttachMenu : IMethod<bool>
	{
		public Flags flags;
		public InputUserBase bot;
		public bool enabled;

		[Flags] public enum Flags : uint
		{
			write_allowed = 0x1,
		}
	}

	[TLDef(0x269DC2C1)]
	public sealed partial class Messages_RequestWebView : IMethod<WebViewResult>
	{
		public Flags flags;
		public InputPeer peer;
		public InputUserBase bot;
		[IfFlag(1)] public string url;
		[IfFlag(3)] public string start_param;
		[IfFlag(2)] public DataJSON theme_params;
		public string platform;
		[IfFlag(0)] public InputReplyTo reply_to;
		[IfFlag(13)] public InputPeer send_as;

		[Flags] public enum Flags : uint
		{
			has_reply_to = 0x1,
			has_url = 0x2,
			has_theme_params = 0x4,
			has_start_param = 0x8,
			from_bot_menu = 0x10,
			silent = 0x20,
			compact = 0x80,
			fullscreen = 0x100,
			has_send_as = 0x2000,
		}
	}

	[TLDef(0xB0D81A83)]
	public sealed partial class Messages_ProlongWebView : IMethod<bool>
	{
		public Flags flags;
		public InputPeer peer;
		public InputUserBase bot;
		public long query_id;
		[IfFlag(0)] public InputReplyTo reply_to;
		[IfFlag(13)] public InputPeer send_as;

		[Flags] public enum Flags : uint
		{
			has_reply_to = 0x1,
			silent = 0x20,
			has_send_as = 0x2000,
		}
	}

	[TLDef(0x413A3E73)]
	public sealed partial class Messages_RequestSimpleWebView : IMethod<WebViewResult>
	{
		public Flags flags;
		public InputUserBase bot;
		[IfFlag(3)] public string url;
		[IfFlag(4)] public string start_param;
		[IfFlag(0)] public DataJSON theme_params;
		public string platform;

		[Flags] public enum Flags : uint
		{
			has_theme_params = 0x1,
			from_switch_webview = 0x2,
			from_side_menu = 0x4,
			has_url = 0x8,
			has_start_param = 0x10,
			compact = 0x80,
			fullscreen = 0x100,
		}
	}

	[TLDef(0x0A4314F5)]
	public sealed partial class Messages_SendWebViewResultMessage : IMethod<WebViewMessageSent>
	{
		public string bot_query_id;
		public InputBotInlineResultBase result;
	}

	[TLDef(0xDC0242C8)]
	public sealed partial class Messages_SendWebViewData : IMethod<UpdatesBase>
	{
		public InputUserBase bot;
		public long random_id;
		public string button_text;
		public string data;
	}

	[TLDef(0x269E9A49)]
	public sealed partial class Messages_TranscribeAudio : IMethod<Messages_TranscribedAudio>
	{
		public InputPeer peer;
		public int msg_id;
	}

	[TLDef(0x7F1D072F)]
	public sealed partial class Messages_RateTranscribedAudio : IMethod<bool>
	{
		public InputPeer peer;
		public int msg_id;
		public long transcription_id;
		public bool good;
	}

	[TLDef(0xD9AB0F54)]
	public sealed partial class Messages_GetCustomEmojiDocuments : IMethod<DocumentBase[]>
	{
		public long[] document_id;
	}

	[TLDef(0xFBFCA18F)]
	public sealed partial class Messages_GetEmojiStickers : IMethod<Messages_AllStickers>
	{
		public long hash;
	}

	[TLDef(0x0ECF6736)]
	public sealed partial class Messages_GetFeaturedEmojiStickers : IMethod<Messages_FeaturedStickersBase>
	{
		public long hash;
	}

	[TLDef(0x3F64C076)]
	public sealed partial class Messages_ReportReaction : IMethod<bool>
	{
		public InputPeer peer;
		public int id;
		public InputPeer reaction_peer;
	}

	[TLDef(0xBB8125BA)]
	public sealed partial class Messages_GetTopReactions : IMethod<Messages_Reactions>
	{
		public int limit;
		public long hash;
	}

	[TLDef(0x39461DB2)]
	public sealed partial class Messages_GetRecentReactions : IMethod<Messages_Reactions>
	{
		public int limit;
		public long hash;
	}

	[TLDef(0x9DFEEFB4)]
	public sealed partial class Messages_ClearRecentReactions : IMethod<bool> { }

	[TLDef(0x84F80814)]
	public sealed partial class Messages_GetExtendedMedia : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public int[] id;
	}

	[TLDef(0x9EB51445)]
	public sealed partial class Messages_SetDefaultHistoryTTL : IMethod<bool>
	{
		public int period;
	}

	[TLDef(0x658B7188)]
	public sealed partial class Messages_GetDefaultHistoryTTL : IMethod<DefaultHistoryTTL> { }

	[TLDef(0x91B2D060)]
	public sealed partial class Messages_SendBotRequestedPeer : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public int msg_id;
		public int button_id;
		public InputPeer[] requested_peers;
	}

	[TLDef(0x7488CE5B)]
	public sealed partial class Messages_GetEmojiGroups : IMethod<Messages_EmojiGroups>
	{
		public int hash;
	}

	[TLDef(0x2ECD56CD)]
	public sealed partial class Messages_GetEmojiStatusGroups : IMethod<Messages_EmojiGroups>
	{
		public int hash;
	}

	[TLDef(0x21A548F3)]
	public sealed partial class Messages_GetEmojiProfilePhotoGroups : IMethod<Messages_EmojiGroups>
	{
		public int hash;
	}

	[TLDef(0x2C11C0D7)]
	public sealed partial class Messages_SearchCustomEmoji : IMethod<EmojiList>
	{
		public string emoticon;
		public long hash;
	}

	[TLDef(0xE47CB579)]
	public sealed partial class Messages_TogglePeerTranslations : IMethod<bool>
	{
		public Flags flags;
		public InputPeer peer;

		[Flags] public enum Flags : uint
		{
			disabled = 0x1,
		}
	}

	[TLDef(0x34FDC5C3)]
	public sealed partial class Messages_GetBotApp : IMethod<Messages_BotApp>
	{
		public InputBotApp app;
		public long hash;
	}

	[TLDef(0x53618BCE)]
	public sealed partial class Messages_RequestAppWebView : IMethod<WebViewResult>
	{
		public Flags flags;
		public InputPeer peer;
		public InputBotApp app;
		[IfFlag(1)] public string start_param;
		[IfFlag(2)] public DataJSON theme_params;
		public string platform;

		[Flags] public enum Flags : uint
		{
			write_allowed = 0x1,
			has_start_param = 0x2,
			has_theme_params = 0x4,
			compact = 0x80,
			fullscreen = 0x100,
		}
	}

	[TLDef(0x8FFACAE1)]
	public sealed partial class Messages_SetChatWallPaper : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPeer peer;
		[IfFlag(0)] public InputWallPaperBase wallpaper;
		[IfFlag(2)] public WallPaperSettings settings;
		[IfFlag(1)] public int id;

		[Flags] public enum Flags : uint
		{
			has_wallpaper = 0x1,
			has_id = 0x2,
			has_settings = 0x4,
			for_both = 0x8,
			revert = 0x10,
		}
	}

	[TLDef(0x92B4494C)]
	public sealed partial class Messages_SearchEmojiStickerSets : IMethod<Messages_FoundStickerSets>
	{
		public Flags flags;
		public string q;
		public long hash;

		[Flags] public enum Flags : uint
		{
			exclude_featured = 0x1,
		}
	}

	[TLDef(0x5381D21A)]
	public sealed partial class Messages_GetSavedDialogs : IMethod<Messages_SavedDialogsBase>
	{
		public Flags flags;
		public DateTime offset_date;
		public int offset_id;
		public InputPeer offset_peer;
		public int limit;
		public long hash;

		[Flags] public enum Flags : uint
		{
			exclude_pinned = 0x1,
		}
	}

	[TLDef(0x3D9A414D)]
	public sealed partial class Messages_GetSavedHistory : IMethod<Messages_MessagesBase>
	{
		public InputPeer peer;
		public int offset_id;
		public DateTime offset_date;
		public int add_offset;
		public int limit;
		public int max_id;
		public int min_id;
		public long hash;
	}

	[TLDef(0x6E98102B)]
	public sealed partial class Messages_DeleteSavedHistory : IMethod<Messages_AffectedHistory>
	{
		public Flags flags;
		public InputPeer peer;
		public int max_id;
		[IfFlag(2)] public DateTime min_date;
		[IfFlag(3)] public DateTime max_date;

		[Flags] public enum Flags : uint
		{
			has_min_date = 0x4,
			has_max_date = 0x8,
		}
	}

	[TLDef(0xD63D94E0)]
	public sealed partial class Messages_GetPinnedSavedDialogs : IMethod<Messages_SavedDialogsBase> { }

	[TLDef(0xAC81BBDE)]
	public sealed partial class Messages_ToggleSavedDialogPin : IMethod<bool>
	{
		public Flags flags;
		public InputDialogPeerBase peer;

		[Flags] public enum Flags : uint
		{
			pinned = 0x1,
		}
	}

	[TLDef(0x8B716587)]
	public sealed partial class Messages_ReorderPinnedSavedDialogs : IMethod<bool>
	{
		public Flags flags;
		public InputDialogPeerBase[] order;

		[Flags] public enum Flags : uint
		{
			force = 0x1,
		}
	}

	[TLDef(0x3637E05B)]
	public sealed partial class Messages_GetSavedReactionTags : IMethod<Messages_SavedReactionTags>
	{
		public Flags flags;
		[IfFlag(0)] public InputPeer peer;
		public long hash;

		[Flags] public enum Flags : uint
		{
			has_peer = 0x1,
		}
	}

	[TLDef(0x60297DEC)]
	public sealed partial class Messages_UpdateSavedReactionTag : IMethod<bool>
	{
		public Flags flags;
		public Reaction reaction;
		[IfFlag(0)] public string title;

		[Flags] public enum Flags : uint
		{
			has_title = 0x1,
		}
	}

	[TLDef(0xBDF93428)]
	public sealed partial class Messages_GetDefaultTagReactions : IMethod<Messages_Reactions>
	{
		public long hash;
	}

	[TLDef(0x8C4BFE5D)]
	public sealed partial class Messages_GetOutboxReadDate : IMethod<OutboxReadDate>
	{
		public InputPeer peer;
		public int msg_id;
	}

	[TLDef(0xD483F2A8)]
	public sealed partial class Messages_GetQuickReplies : IMethod<Messages_QuickReplies>
	{
		public long hash;
	}

	[TLDef(0x60331907)]
	public sealed partial class Messages_ReorderQuickReplies : IMethod<bool>
	{
		public int[] order;
	}

	[TLDef(0xF1D0FBD3)]
	public sealed partial class Messages_CheckQuickReplyShortcut : IMethod<bool>
	{
		public string shortcut;
	}

	[TLDef(0x5C003CEF)]
	public sealed partial class Messages_EditQuickReplyShortcut : IMethod<bool>
	{
		public int shortcut_id;
		public string shortcut;
	}

	[TLDef(0x3CC04740)]
	public sealed partial class Messages_DeleteQuickReplyShortcut : IMethod<bool>
	{
		public int shortcut_id;
	}

	[TLDef(0x94A495C3)]
	public sealed partial class Messages_GetQuickReplyMessages : IMethod<Messages_MessagesBase>
	{
		public Flags flags;
		public int shortcut_id;
		[IfFlag(0)] public int[] id;
		public long hash;

		[Flags] public enum Flags : uint
		{
			has_id = 0x1,
		}
	}

	[TLDef(0x6C750DE1)]
	public sealed partial class Messages_SendQuickReplyMessages : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public int shortcut_id;
		public int[] id;
		public long[] random_id;
	}

	[TLDef(0xE105E910)]
	public sealed partial class Messages_DeleteQuickReplyMessages : IMethod<UpdatesBase>
	{
		public int shortcut_id;
		public int[] id;
	}

	[TLDef(0xFD2DDA49)]
	public sealed partial class Messages_ToggleDialogFilterTags : IMethod<bool>
	{
		public bool enabled;
	}

	[TLDef(0xD0B5E1FC)]
	public sealed partial class Messages_GetMyStickers : IMethod<Messages_MyStickers>
	{
		public long offset_id;
		public int limit;
	}

	[TLDef(0x1DD840F5)]
	public sealed partial class Messages_GetEmojiStickerGroups : IMethod<Messages_EmojiGroups>
	{
		public int hash;
	}

	[TLDef(0xDEA20A39)]
	public sealed partial class Messages_GetAvailableEffects : IMethod<Messages_AvailableEffects>
	{
		public int hash;
	}

	[TLDef(0x0589EE75)]
	public sealed partial class Messages_EditFactCheck : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public int msg_id;
		public TextWithEntities text;
	}

	[TLDef(0xD1DA940C)]
	public sealed partial class Messages_DeleteFactCheck : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public int msg_id;
	}

	[TLDef(0xB9CDC5EE)]
	public sealed partial class Messages_GetFactCheck : IMethod<FactCheck[]>
	{
		public InputPeer peer;
		public int[] msg_id;
	}

	[TLDef(0xC9E01E7B)]
	public sealed partial class Messages_RequestMainWebView : IMethod<WebViewResult>
	{
		public Flags flags;
		public InputPeer peer;
		public InputUserBase bot;
		[IfFlag(1)] public string start_param;
		[IfFlag(0)] public DataJSON theme_params;
		public string platform;

		[Flags] public enum Flags : uint
		{
			has_theme_params = 0x1,
			has_start_param = 0x2,
			compact = 0x80,
			fullscreen = 0x100,
		}
	}

	[TLDef(0x58BBCB50)]
	public sealed partial class Messages_SendPaidReaction : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPeer peer;
		public int msg_id;
		public int count;
		public long random_id;
		[IfFlag(0)] public PaidReactionPrivacy private_;

		[Flags] public enum Flags : uint
		{
			has_private = 0x1,
		}
	}

	[TLDef(0x435885B5)]
	public sealed partial class Messages_TogglePaidReactionPrivacy : IMethod<bool>
	{
		public InputPeer peer;
		public int msg_id;
		public PaidReactionPrivacy private_;
	}

	[TLDef(0x472455AA)]
	public sealed partial class Messages_GetPaidReactionPrivacy : IMethod<UpdatesBase> { }

	[TLDef(0x673AD8F1)]
	public sealed partial class Messages_ViewSponsoredMessage : IMethod<bool>
	{
		public InputPeer peer;
		public byte[] random_id;
	}

	[TLDef(0x0F093465)]
	public sealed partial class Messages_ClickSponsoredMessage : IMethod<bool>
	{
		public Flags flags;
		public InputPeer peer;
		public byte[] random_id;

		[Flags] public enum Flags : uint
		{
			media = 0x1,
			fullscreen = 0x2,
		}
	}

	[TLDef(0x1AF3DBB8)]
	public sealed partial class Messages_ReportSponsoredMessage : IMethod<Channels_SponsoredMessageReportResult>
	{
		public InputPeer peer;
		public byte[] random_id;
		public byte[] option;
	}

	[TLDef(0x9BD2F439)]
	public sealed partial class Messages_GetSponsoredMessages : IMethod<Messages_SponsoredMessages>
	{
		public InputPeer peer;
	}

	[TLDef(0xF21F7F2F)]
	public sealed partial class Messages_SavePreparedInlineMessage : IMethod<Messages_BotPreparedInlineMessage>
	{
		public Flags flags;
		public InputBotInlineResultBase result;
		public InputUserBase user_id;
		[IfFlag(0)] public InlineQueryPeerType[] peer_types;

		[Flags] public enum Flags : uint
		{
			has_peer_types = 0x1,
		}
	}

	[TLDef(0x857EBDB8)]
	public sealed partial class Messages_GetPreparedInlineMessage : IMethod<Messages_PreparedInlineMessage>
	{
		public InputUserBase bot;
		public string id;
	}

	[TLDef(0x29B1C66A)]
	public sealed partial class Messages_SearchStickers : IMethod<Messages_FoundStickersBase>
	{
		public Flags flags;
		public string q;
		public string emoticon;
		public string[] lang_code;
		public int offset;
		public int limit;
		public long hash;

		[Flags] public enum Flags : uint
		{
			emojis = 0x1,
		}
	}

	[TLDef(0x5A6D7395)]
	public sealed partial class Messages_ReportMessagesDelivery : IMethod<bool>
	{
		public Flags flags;
		public InputPeer peer;
		public int[] id;

		[Flags] public enum Flags : uint
		{
			push = 0x1,
		}
	}

	[TLDef(0xEDD4882A)]
	public sealed partial class Updates_GetState : IMethod<Updates_State> { }

	[TLDef(0x19C2F763)]
	public sealed partial class Updates_GetDifference : IMethod<Updates_DifferenceBase>
	{
		public Flags flags;
		public int pts;
		[IfFlag(1)] public int pts_limit;
		[IfFlag(0)] public int pts_total_limit;
		public DateTime date;
		public int qts;
		[IfFlag(2)] public int qts_limit;

		[Flags] public enum Flags : uint
		{
			has_pts_total_limit = 0x1,
			has_pts_limit = 0x2,
			has_qts_limit = 0x4,
		}
	}

	[TLDef(0x03173D78)]
	public sealed partial class Updates_GetChannelDifference : IMethod<Updates_ChannelDifferenceBase>
	{
		public Flags flags;
		public InputChannelBase channel;
		public ChannelMessagesFilter filter;
		public int pts;
		public int limit;

		[Flags] public enum Flags : uint
		{
			force = 0x1,
		}
	}

	[TLDef(0x09E82039)]
	public sealed partial class Photos_UpdateProfilePhoto : IMethod<Photos_Photo>
	{
		public Flags flags;
		[IfFlag(1)] public InputUserBase bot;
		public InputPhoto id;

		[Flags] public enum Flags : uint
		{
			fallback = 0x1,
			has_bot = 0x2,
		}
	}

	[TLDef(0x0388A3B5)]
	public sealed partial class Photos_UploadProfilePhoto : IMethod<Photos_Photo>
	{
		public Flags flags;
		[IfFlag(5)] public InputUserBase bot;
		[IfFlag(0)] public InputFileBase file;
		[IfFlag(1)] public InputFileBase video;
		[IfFlag(2)] public double video_start_ts;
		[IfFlag(4)] public VideoSizeBase video_emoji_markup;

		[Flags] public enum Flags : uint
		{
			has_file = 0x1,
			has_video = 0x2,
			has_video_start_ts = 0x4,
			fallback = 0x8,
			has_video_emoji_markup = 0x10,
			has_bot = 0x20,
		}
	}

	[TLDef(0x87CF7F2F)]
	public sealed partial class Photos_DeletePhotos : IMethod<long[]>
	{
		public InputPhoto[] id;
	}

	[TLDef(0x91CD32A8)]
	public sealed partial class Photos_GetUserPhotos : IMethod<Photos_Photos>
	{
		public InputUserBase user_id;
		public int offset;
		public long max_id;
		public int limit;
	}

	[TLDef(0xE14C4A71)]
	public sealed partial class Photos_UploadContactProfilePhoto : IMethod<Photos_Photo>
	{
		public Flags flags;
		public InputUserBase user_id;
		[IfFlag(0)] public InputFileBase file;
		[IfFlag(1)] public InputFileBase video;
		[IfFlag(2)] public double video_start_ts;
		[IfFlag(5)] public VideoSizeBase video_emoji_markup;

		[Flags] public enum Flags : uint
		{
			has_file = 0x1,
			has_video = 0x2,
			has_video_start_ts = 0x4,
			suggest = 0x8,
			save = 0x10,
			has_video_emoji_markup = 0x20,
		}
	}

	[TLDef(0xB304A621)]
	public sealed partial class Upload_SaveFilePart : IMethod<bool>
	{
		public long file_id;
		public int file_part;
		public byte[] bytes;
	}

	[TLDef(0xBE5335BE)]
	public sealed partial class Upload_GetFile : IMethod<Upload_FileBase>
	{
		public Flags flags;
		public InputFileLocationBase location;
		public long offset;
		public int limit;

		[Flags] public enum Flags : uint
		{
			precise = 0x1,
			cdn_supported = 0x2,
		}
	}

	[TLDef(0xDE7B673D)]
	public sealed partial class Upload_SaveBigFilePart : IMethod<bool>
	{
		public long file_id;
		public int file_part;
		public int file_total_parts;
		public byte[] bytes;
	}

	[TLDef(0x24E6818D)]
	public sealed partial class Upload_GetWebFile : IMethod<Upload_WebFile>
	{
		public InputWebFileLocationBase location;
		public int offset;
		public int limit;
	}

	[TLDef(0x395F69DA)]
	public sealed partial class Upload_GetCdnFile : IMethod<Upload_CdnFileBase>
	{
		public byte[] file_token;
		public long offset;
		public int limit;
	}

	[TLDef(0x9B2754A8)]
	public sealed partial class Upload_ReuploadCdnFile : IMethod<FileHash[]>
	{
		public byte[] file_token;
		public byte[] request_token;
	}

	[TLDef(0x91DC3F31)]
	public sealed partial class Upload_GetCdnFileHashes : IMethod<FileHash[]>
	{
		public byte[] file_token;
		public long offset;
	}

	[TLDef(0x9156982A)]
	public sealed partial class Upload_GetFileHashes : IMethod<FileHash[]>
	{
		public InputFileLocationBase location;
		public long offset;
	}

	[TLDef(0xC4F9186B)]
	public sealed partial class Help_GetConfig : IMethod<Config> { }

	[TLDef(0x1FB33026)]
	public sealed partial class Help_GetNearestDc : IMethod<NearestDc> { }

	[TLDef(0x522D5A7D)]
	public sealed partial class Help_GetAppUpdate : IMethod<Help_AppUpdate>
	{
		public string source;
	}

	[TLDef(0x4D392343)]
	public sealed partial class Help_GetInviteText : IMethod<Help_InviteText> { }

	[TLDef(0x9CDF08CD)]
	public sealed partial class Help_GetSupport : IMethod<Help_Support> { }

	[TLDef(0xEC22CFCD)]
	public sealed partial class Help_SetBotUpdatesStatus : IMethod<bool>
	{
		public int pending_updates_count;
		public string message;
	}

	[TLDef(0x52029342)]
	public sealed partial class Help_GetCdnConfig : IMethod<CdnConfig> { }

	[TLDef(0x3DC0F114)]
	public sealed partial class Help_GetRecentMeUrls : IMethod<Help_RecentMeUrls>
	{
		public string referer;
	}

	[TLDef(0x2CA51FD1)]
	public sealed partial class Help_GetTermsOfServiceUpdate : IMethod<Help_TermsOfServiceUpdateBase> { }

	[TLDef(0xEE72F79A)]
	public sealed partial class Help_AcceptTermsOfService : IMethod<bool>
	{
		public DataJSON id;
	}

	[TLDef(0x3FEDC75F)]
	public sealed partial class Help_GetDeepLinkInfo : IMethod<Help_DeepLinkInfo>
	{
		public string path;
	}

	[TLDef(0x61E3F854)]
	public sealed partial class Help_GetAppConfig : IMethod<Help_AppConfig>
	{
		public int hash;
	}

	[TLDef(0x6F02F748)]
	public sealed partial class Help_SaveAppLog : IMethod<bool>
	{
		public InputAppEvent[] events;
	}

	[TLDef(0xC661AD08)]
	public sealed partial class Help_GetPassportConfig : IMethod<Help_PassportConfig>
	{
		public int hash;
	}

	[TLDef(0xD360E72C)]
	public sealed partial class Help_GetSupportName : IMethod<Help_SupportName> { }

	[TLDef(0x038A08D3)]
	public sealed partial class Help_GetUserInfo : IMethod<Help_UserInfo>
	{
		public InputUserBase user_id;
	}

	[TLDef(0x66B91B70)]
	public sealed partial class Help_EditUserInfo : IMethod<Help_UserInfo>
	{
		public InputUserBase user_id;
		public string message;
		public MessageEntity[] entities;
	}

	[TLDef(0xC0977421)]
	public sealed partial class Help_GetPromoData : IMethod<Help_PromoDataBase> { }

	[TLDef(0x1E251C95)]
	public sealed partial class Help_HidePromoData : IMethod<bool>
	{
		public InputPeer peer;
	}

	[TLDef(0xF50DBAA1)]
	public sealed partial class Help_DismissSuggestion : IMethod<bool>
	{
		public InputPeer peer;
		public string suggestion;
	}

	[TLDef(0x735787A8)]
	public sealed partial class Help_GetCountriesList : IMethod<Help_CountriesList>
	{
		public string lang_code;
		public int hash;
	}

	[TLDef(0xB81B93D4)]
	public sealed partial class Help_GetPremiumPromo : IMethod<Help_PremiumPromo> { }

	[TLDef(0xDA80F42F)]
	public sealed partial class Help_GetPeerColors : IMethod<Help_PeerColors>
	{
		public int hash;
	}

	[TLDef(0xABCFA9FD)]
	public sealed partial class Help_GetPeerProfileColors : IMethod<Help_PeerColors>
	{
		public int hash;
	}

	[TLDef(0x49B30240)]
	public sealed partial class Help_GetTimezonesList : IMethod<Help_TimezonesList>
	{
		public int hash;
	}

	[TLDef(0xCC104937)]
	public sealed partial class Channels_ReadHistory : IMethod<bool>
	{
		public InputChannelBase channel;
		public int max_id;
	}

	[TLDef(0x84C1FD4E)]
	public sealed partial class Channels_DeleteMessages : IMethod<Messages_AffectedMessages>
	{
		public InputChannelBase channel;
		public int[] id;
	}

	[TLDef(0xF44A8315)]
	public sealed partial class Channels_ReportSpam : IMethod<bool>
	{
		public InputChannelBase channel;
		public InputPeer participant;
		public int[] id;
	}

	[TLDef(0xAD8C9A23)]
	public sealed partial class Channels_GetMessages : IMethod<Messages_MessagesBase>
	{
		public InputChannelBase channel;
		public InputMessage[] id;
	}

	[TLDef(0x77CED9D0)]
	public sealed partial class Channels_GetParticipants : IMethod<Channels_ChannelParticipants>
	{
		public InputChannelBase channel;
		public ChannelParticipantsFilter filter;
		public int offset;
		public int limit;
		public long hash;
	}

	[TLDef(0xA0AB6CC6)]
	public sealed partial class Channels_GetParticipant : IMethod<Channels_ChannelParticipant>
	{
		public InputChannelBase channel;
		public InputPeer participant;
	}

	[TLDef(0x0A7F6BBB)]
	public sealed partial class Channels_GetChannels : IMethod<Messages_Chats>
	{
		public InputChannelBase[] id;
	}

	[TLDef(0x08736A09)]
	public sealed partial class Channels_GetFullChannel : IMethod<Messages_ChatFull>
	{
		public InputChannelBase channel;
	}

	[TLDef(0x91006707)]
	public sealed partial class Channels_CreateChannel : IMethod<UpdatesBase>
	{
		public Flags flags;
		public string title;
		public string about;
		[IfFlag(2)] public InputGeoPoint geo_point;
		[IfFlag(2)] public string address;
		[IfFlag(4)] public int ttl_period;

		[Flags] public enum Flags : uint
		{
			broadcast = 0x1,
			megagroup = 0x2,
			has_geo_point = 0x4,
			for_import = 0x8,
			has_ttl_period = 0x10,
			forum = 0x20,
		}
	}

	[TLDef(0xD33C8902)]
	public sealed partial class Channels_EditAdmin : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public InputUserBase user_id;
		public ChatAdminRights admin_rights;
		public string rank;
	}

	[TLDef(0x566DECD0)]
	public sealed partial class Channels_EditTitle : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public string title;
	}

	[TLDef(0xF12E57C9)]
	public sealed partial class Channels_EditPhoto : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public InputChatPhotoBase photo;
	}

	[TLDef(0x10E6BD2C)]
	public sealed partial class Channels_CheckUsername : IMethod<bool>
	{
		public InputChannelBase channel;
		public string username;
	}

	[TLDef(0x3514B3DE)]
	public sealed partial class Channels_UpdateUsername : IMethod<bool>
	{
		public InputChannelBase channel;
		public string username;
	}

	[TLDef(0x24B524C5)]
	public sealed partial class Channels_JoinChannel : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
	}

	[TLDef(0xF836AA95)]
	public sealed partial class Channels_LeaveChannel : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
	}

	[TLDef(0xC9E33D54)]
	public sealed partial class Channels_InviteToChannel : IMethod<Messages_InvitedUsers>
	{
		public InputChannelBase channel;
		public InputUserBase[] users;
	}

	[TLDef(0xC0111FE3)]
	public sealed partial class Channels_DeleteChannel : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
	}

	[TLDef(0xE63FADEB)]
	public sealed partial class Channels_ExportMessageLink : IMethod<ExportedMessageLink>
	{
		public Flags flags;
		public InputChannelBase channel;
		public int id;

		[Flags] public enum Flags : uint
		{
			grouped = 0x1,
			thread = 0x2,
		}
	}

	[TLDef(0x418D549C)]
	public sealed partial class Channels_ToggleSignatures : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputChannelBase channel;

		[Flags] public enum Flags : uint
		{
			signatures_enabled = 0x1,
			profiles_enabled = 0x2,
		}
	}

	[TLDef(0xF8B036AF)]
	public sealed partial class Channels_GetAdminedPublicChannels : IMethod<Messages_Chats>
	{
		public Flags flags;

		[Flags] public enum Flags : uint
		{
			by_location = 0x1,
			check_limit = 0x2,
			for_personal = 0x4,
		}
	}

	[TLDef(0x96E6CD81)]
	public sealed partial class Channels_EditBanned : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public InputPeer participant;
		public ChatBannedRights banned_rights;
	}

	[TLDef(0x33DDF480)]
	public sealed partial class Channels_GetAdminLog : IMethod<Channels_AdminLogResults>
	{
		public Flags flags;
		public InputChannelBase channel;
		public string q;
		[IfFlag(0)] public ChannelAdminLogEventsFilter events_filter;
		[IfFlag(1)] public InputUserBase[] admins;
		public long max_id;
		public long min_id;
		public int limit;

		[Flags] public enum Flags : uint
		{
			has_events_filter = 0x1,
			has_admins = 0x2,
		}
	}

	[TLDef(0xEA8CA4F9)]
	public sealed partial class Channels_SetStickers : IMethod<bool>
	{
		public InputChannelBase channel;
		public InputStickerSet stickerset;
	}

	[TLDef(0xEAB5DC38)]
	public sealed partial class Channels_ReadMessageContents : IMethod<bool>
	{
		public InputChannelBase channel;
		public int[] id;
	}

	[TLDef(0x9BAA9647)]
	public sealed partial class Channels_DeleteHistory : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputChannelBase channel;
		public int max_id;

		[Flags] public enum Flags : uint
		{
			for_everyone = 0x1,
		}
	}

	[TLDef(0xEABBB94C)]
	public sealed partial class Channels_TogglePreHistoryHidden : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public bool enabled;
	}

	[TLDef(0x8341ECC0)]
	public sealed partial class Channels_GetLeftChannels : IMethod<Messages_Chats>
	{
		public int offset;
	}

	[TLDef(0xF5DAD378)]
	public sealed partial class Channels_GetGroupsForDiscussion : IMethod<Messages_Chats> { }

	[TLDef(0x40582BB2)]
	public sealed partial class Channels_SetDiscussionGroup : IMethod<bool>
	{
		public InputChannelBase broadcast;
		public InputChannelBase group;
	}

	[TLDef(0x8F38CD1F)]
	public sealed partial class Channels_EditCreator : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public InputUserBase user_id;
		public InputCheckPasswordSRP password;
	}

	[TLDef(0x58E63F6D)]
	public sealed partial class Channels_EditLocation : IMethod<bool>
	{
		public InputChannelBase channel;
		public InputGeoPoint geo_point;
		public string address;
	}

	[TLDef(0xEDD49EF0)]
	public sealed partial class Channels_ToggleSlowMode : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public int seconds;
	}

	[TLDef(0x11E831EE)]
	public sealed partial class Channels_GetInactiveChannels : IMethod<Messages_InactiveChats> { }

	[TLDef(0x0B290C69)]
	public sealed partial class Channels_ConvertToGigagroup : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
	}

	[TLDef(0xE785A43F)]
	public sealed partial class Channels_GetSendAs : IMethod<Channels_SendAsPeers>
	{
		public Flags flags;
		public InputPeer peer;

		[Flags] public enum Flags : uint
		{
			for_paid_reactions = 0x1,
		}
	}

	[TLDef(0x367544DB)]
	public sealed partial class Channels_DeleteParticipantHistory : IMethod<Messages_AffectedHistory>
	{
		public InputChannelBase channel;
		public InputPeer participant;
	}

	[TLDef(0xE4CB9580)]
	public sealed partial class Channels_ToggleJoinToSend : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public bool enabled;
	}

	[TLDef(0x4C2985B6)]
	public sealed partial class Channels_ToggleJoinRequest : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public bool enabled;
	}

	[TLDef(0xB45CED1D)]
	public sealed partial class Channels_ReorderUsernames : IMethod<bool>
	{
		public InputChannelBase channel;
		public string[] order;
	}

	[TLDef(0x50F24105)]
	public sealed partial class Channels_ToggleUsername : IMethod<bool>
	{
		public InputChannelBase channel;
		public string username;
		public bool active;
	}

	[TLDef(0x0A245DD3)]
	public sealed partial class Channels_DeactivateAllUsernames : IMethod<bool>
	{
		public InputChannelBase channel;
	}

	[TLDef(0xA4298B29)]
	public sealed partial class Channels_ToggleForum : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public bool enabled;
	}

	[TLDef(0xF40C0224)]
	public sealed partial class Channels_CreateForumTopic : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputChannelBase channel;
		public string title;
		[IfFlag(0)] public int icon_color;
		[IfFlag(3)] public long icon_emoji_id;
		public long random_id;
		[IfFlag(2)] public InputPeer send_as;

		[Flags] public enum Flags : uint
		{
			has_icon_color = 0x1,
			has_send_as = 0x4,
			has_icon_emoji_id = 0x8,
		}
	}

	[TLDef(0x0DE560D1)]
	public sealed partial class Channels_GetForumTopics : IMethod<Messages_ForumTopics>
	{
		public Flags flags;
		public InputChannelBase channel;
		[IfFlag(0)] public string q;
		public DateTime offset_date;
		public int offset_id;
		public int offset_topic;
		public int limit;

		[Flags] public enum Flags : uint
		{
			has_q = 0x1,
		}
	}

	[TLDef(0xB0831EB9)]
	public sealed partial class Channels_GetForumTopicsByID : IMethod<Messages_ForumTopics>
	{
		public InputChannelBase channel;
		public int[] topics;
	}

	[TLDef(0xF4DFA185)]
	public sealed partial class Channels_EditForumTopic : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputChannelBase channel;
		public int topic_id;
		[IfFlag(0)] public string title;
		[IfFlag(1)] public long icon_emoji_id;
		[IfFlag(2)] public bool closed;
		[IfFlag(3)] public bool hidden;

		[Flags] public enum Flags : uint
		{
			has_title = 0x1,
			has_icon_emoji_id = 0x2,
			has_closed = 0x4,
			has_hidden = 0x8,
		}
	}

	[TLDef(0x6C2D9026)]
	public sealed partial class Channels_UpdatePinnedForumTopic : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public int topic_id;
		public bool pinned;
	}

	[TLDef(0x34435F2D)]
	public sealed partial class Channels_DeleteTopicHistory : IMethod<Messages_AffectedHistory>
	{
		public InputChannelBase channel;
		public int top_msg_id;
	}

	[TLDef(0x2950A18F)]
	public sealed partial class Channels_ReorderPinnedForumTopics : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputChannelBase channel;
		public int[] order;

		[Flags] public enum Flags : uint
		{
			force = 0x1,
		}
	}

	[TLDef(0x68F3E4EB)]
	public sealed partial class Channels_ToggleAntiSpam : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public bool enabled;
	}

	[TLDef(0xA850A693)]
	public sealed partial class Channels_ReportAntiSpamFalsePositive : IMethod<bool>
	{
		public InputChannelBase channel;
		public int msg_id;
	}

	[TLDef(0x6A6E7854)]
	public sealed partial class Channels_ToggleParticipantsHidden : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public bool enabled;
	}

	[TLDef(0xD8AA3671)]
	public sealed partial class Channels_UpdateColor : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputChannelBase channel;
		[IfFlag(2)] public int color;
		[IfFlag(0)] public long background_emoji_id;

		[Flags] public enum Flags : uint
		{
			has_background_emoji_id = 0x1,
			for_profile = 0x2,
			has_color = 0x4,
		}
	}

	[TLDef(0x9738BB15)]
	public sealed partial class Channels_ToggleViewForumAsMessages : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public bool enabled;
	}

	[TLDef(0x25A71742)]
	public sealed partial class Channels_GetChannelRecommendations : IMethod<Messages_Chats>
	{
		public Flags flags;
		[IfFlag(0)] public InputChannelBase channel;

		[Flags] public enum Flags : uint
		{
			has_channel = 0x1,
		}
	}

	[TLDef(0xF0D3E6A8)]
	public sealed partial class Channels_UpdateEmojiStatus : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public EmojiStatusBase emoji_status;
	}

	[TLDef(0xAD399CEE)]
	public sealed partial class Channels_SetBoostsToUnblockRestrictions : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public int boosts;
	}

	[TLDef(0x3CD930B7)]
	public sealed partial class Channels_SetEmojiStickers : IMethod<bool>
	{
		public InputChannelBase channel;
		public InputStickerSet stickerset;
	}

	[TLDef(0x9AE91519)]
	public sealed partial class Channels_RestrictSponsoredMessages : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public bool restricted;
	}

	[TLDef(0xD19F987B)]
	public sealed partial class Channels_SearchPosts : IMethod<Messages_MessagesBase>
	{
		public string hashtag;
		public int offset_rate;
		public InputPeer offset_peer;
		public int offset_id;
		public int limit;
	}

	[TLDef(0xAA2769ED)]
	public sealed partial class Bots_SendCustomRequest : IMethod<DataJSON>
	{
		public string custom_method;
		public DataJSON params_;
	}

	[TLDef(0xE6213F4D)]
	public sealed partial class Bots_AnswerWebhookJSONQuery : IMethod<bool>
	{
		public long query_id;
		public DataJSON data;
	}

	[TLDef(0x0517165A)]
	public sealed partial class Bots_SetBotCommands : IMethod<bool>
	{
		public BotCommandScope scope;
		public string lang_code;
		public BotCommand[] commands;
	}

	[TLDef(0x3D8DE0F9)]
	public sealed partial class Bots_ResetBotCommands : IMethod<bool>
	{
		public BotCommandScope scope;
		public string lang_code;
	}

	[TLDef(0xE34C0DD6)]
	public sealed partial class Bots_GetBotCommands : IMethod<BotCommand[]>
	{
		public BotCommandScope scope;
		public string lang_code;
	}

	[TLDef(0x4504D54F)]
	public sealed partial class Bots_SetBotMenuButton : IMethod<bool>
	{
		public InputUserBase user_id;
		public BotMenuButtonBase button;
	}

	[TLDef(0x9C60EB28)]
	public sealed partial class Bots_GetBotMenuButton : IMethod<BotMenuButtonBase>
	{
		public InputUserBase user_id;
	}

	[TLDef(0x788464E1)]
	public sealed partial class Bots_SetBotBroadcastDefaultAdminRights : IMethod<bool>
	{
		public ChatAdminRights admin_rights;
	}

	[TLDef(0x925EC9EA)]
	public sealed partial class Bots_SetBotGroupDefaultAdminRights : IMethod<bool>
	{
		public ChatAdminRights admin_rights;
	}

	[TLDef(0x10CF3123)]
	public sealed partial class Bots_SetBotInfo : IMethod<bool>
	{
		public Flags flags;
		[IfFlag(2)] public InputUserBase bot;
		public string lang_code;
		[IfFlag(3)] public string name;
		[IfFlag(0)] public string about;
		[IfFlag(1)] public string description;

		[Flags] public enum Flags : uint
		{
			has_about = 0x1,
			has_description = 0x2,
			has_bot = 0x4,
			has_name = 0x8,
		}
	}

	[TLDef(0xDCD914FD)]
	public sealed partial class Bots_GetBotInfo : IMethod<Bots_BotInfo>
	{
		public Flags flags;
		[IfFlag(0)] public InputUserBase bot;
		public string lang_code;

		[Flags] public enum Flags : uint
		{
			has_bot = 0x1,
		}
	}

	[TLDef(0x9709B1C2)]
	public sealed partial class Bots_ReorderUsernames : IMethod<bool>
	{
		public InputUserBase bot;
		public string[] order;
	}

	[TLDef(0x053CA973)]
	public sealed partial class Bots_ToggleUsername : IMethod<bool>
	{
		public InputUserBase bot;
		public string username;
		public bool active;
	}

	[TLDef(0x1359F4E6)]
	public sealed partial class Bots_CanSendMessage : IMethod<bool>
	{
		public InputUserBase bot;
	}

	[TLDef(0xF132E3EF)]
	public sealed partial class Bots_AllowSendMessage : IMethod<UpdatesBase>
	{
		public InputUserBase bot;
	}

	[TLDef(0x087FC5E7)]
	public sealed partial class Bots_InvokeWebViewCustomMethod : IMethod<DataJSON>
	{
		public InputUserBase bot;
		public string custom_method;
		public DataJSON params_;
	}

	[TLDef(0xC2510192)]
	public sealed partial class Bots_GetPopularAppBots : IMethod<Bots_PopularAppBots>
	{
		public string offset;
		public int limit;
	}

	[TLDef(0x17AEB75A)]
	public sealed partial class Bots_AddPreviewMedia : IMethod<BotPreviewMedia>
	{
		public InputUserBase bot;
		public string lang_code;
		public InputMedia media;
	}

	[TLDef(0x8525606F)]
	public sealed partial class Bots_EditPreviewMedia : IMethod<BotPreviewMedia>
	{
		public InputUserBase bot;
		public string lang_code;
		public InputMedia media;
		public InputMedia new_media;
	}

	[TLDef(0x2D0135B3)]
	public sealed partial class Bots_DeletePreviewMedia : IMethod<bool>
	{
		public InputUserBase bot;
		public string lang_code;
		public InputMedia[] media;
	}

	[TLDef(0xB627F3AA)]
	public sealed partial class Bots_ReorderPreviewMedias : IMethod<bool>
	{
		public InputUserBase bot;
		public string lang_code;
		public InputMedia[] order;
	}

	[TLDef(0x423AB3AD)]
	public sealed partial class Bots_GetPreviewInfo : IMethod<Bots_PreviewInfo>
	{
		public InputUserBase bot;
		public string lang_code;
	}

	[TLDef(0xA2A5594D)]
	public sealed partial class Bots_GetPreviewMedias : IMethod<BotPreviewMedia[]>
	{
		public InputUserBase bot;
	}

	[TLDef(0xED9F30C5)]
	public sealed partial class Bots_UpdateUserEmojiStatus : IMethod<bool>
	{
		public InputUserBase user_id;
		public EmojiStatusBase emoji_status;
	}

	[TLDef(0x06DE6392)]
	public sealed partial class Bots_ToggleUserEmojiStatusPermission : IMethod<bool>
	{
		public InputUserBase bot;
		public bool enabled;
	}

	[TLDef(0x50077589)]
	public sealed partial class Bots_CheckDownloadFileParams : IMethod<bool>
	{
		public InputUserBase bot;
		public string file_name;
		public string url;
	}

	[TLDef(0xB0711D83)]
	public sealed partial class Bots_GetAdminedBots : IMethod<UserBase[]> { }

	[TLDef(0x778B5AB3)]
	public sealed partial class Bots_UpdateStarRefProgram : IMethod<StarRefProgram>
	{
		public Flags flags;
		public InputUserBase bot;
		public int commission_permille;
		[IfFlag(0)] public int duration_months;

		[Flags] public enum Flags : uint
		{
			has_duration_months = 0x1,
		}
	}

	[TLDef(0x8B89DFBD)]
	public sealed partial class Bots_SetCustomVerification : IMethod<bool>
	{
		public Flags flags;
		[IfFlag(0)] public InputUserBase bot;
		public InputPeer peer;
		[IfFlag(2)] public string custom_description;

		[Flags] public enum Flags : uint
		{
			has_bot = 0x1,
			enabled = 0x2,
			has_custom_description = 0x4,
		}
	}

	[TLDef(0xA1B70815)]
	public sealed partial class Bots_GetBotRecommendations : IMethod<Users_Users>
	{
		public InputUserBase bot;
	}

	[TLDef(0x37148DBB)]
	public sealed partial class Payments_GetPaymentForm : IMethod<Payments_PaymentFormBase>
	{
		public Flags flags;
		public InputInvoice invoice;
		[IfFlag(0)] public DataJSON theme_params;

		[Flags] public enum Flags : uint
		{
			has_theme_params = 0x1,
		}
	}

	[TLDef(0x2478D1CC)]
	public sealed partial class Payments_GetPaymentReceipt : IMethod<Payments_PaymentReceiptBase>
	{
		public InputPeer peer;
		public int msg_id;
	}

	[TLDef(0xB6C8F12B)]
	public sealed partial class Payments_ValidateRequestedInfo : IMethod<Payments_ValidatedRequestedInfo>
	{
		public Flags flags;
		public InputInvoice invoice;
		public PaymentRequestedInfo info;

		[Flags] public enum Flags : uint
		{
			save = 0x1,
		}
	}

	[TLDef(0x2D03522F)]
	public sealed partial class Payments_SendPaymentForm : IMethod<Payments_PaymentResultBase>
	{
		public Flags flags;
		public long form_id;
		public InputInvoice invoice;
		[IfFlag(0)] public string requested_info_id;
		[IfFlag(1)] public string shipping_option_id;
		public InputPaymentCredentialsBase credentials;
		[IfFlag(2)] public long tip_amount;

		[Flags] public enum Flags : uint
		{
			has_requested_info_id = 0x1,
			has_shipping_option_id = 0x2,
			has_tip_amount = 0x4,
		}
	}

	[TLDef(0x227D824B)]
	public sealed partial class Payments_GetSavedInfo : IMethod<Payments_SavedInfo> { }

	[TLDef(0xD83D70C1)]
	public sealed partial class Payments_ClearSavedInfo : IMethod<bool>
	{
		public Flags flags;

		[Flags] public enum Flags : uint
		{
			credentials = 0x1,
			info = 0x2,
		}
	}

	[TLDef(0x2E79D779)]
	public sealed partial class Payments_GetBankCardData : IMethod<Payments_BankCardData>
	{
		public string number;
	}

	[TLDef(0x0F91B065)]
	public sealed partial class Payments_ExportInvoice : IMethod<Payments_ExportedInvoice>
	{
		public InputMedia invoice_media;
	}

	[TLDef(0x80ED747D)]
	public sealed partial class Payments_AssignAppStoreTransaction : IMethod<UpdatesBase>
	{
		public byte[] receipt;
		public InputStorePaymentPurpose purpose;
	}

	[TLDef(0xDFFD50D3)]
	public sealed partial class Payments_AssignPlayMarketTransaction : IMethod<UpdatesBase>
	{
		public DataJSON receipt;
		public InputStorePaymentPurpose purpose;
	}

	[TLDef(0x9FC19EB6)]
	public sealed partial class Payments_CanPurchasePremium : IMethod<bool>
	{
		public InputStorePaymentPurpose purpose;
	}

	[TLDef(0x2757BA54)]
	public sealed partial class Payments_GetPremiumGiftCodeOptions : IMethod<PremiumGiftCodeOption[]>
	{
		public Flags flags;
		[IfFlag(0)] public InputPeer boost_peer;

		[Flags] public enum Flags : uint
		{
			has_boost_peer = 0x1,
		}
	}

	[TLDef(0x8E51B4C1)]
	public sealed partial class Payments_CheckGiftCode : IMethod<Payments_CheckedGiftCode>
	{
		public string slug;
	}

	[TLDef(0xF6E26854)]
	public sealed partial class Payments_ApplyGiftCode : IMethod<UpdatesBase>
	{
		public string slug;
	}

	[TLDef(0xF4239425)]
	public sealed partial class Payments_GetGiveawayInfo : IMethod<Payments_GiveawayInfoBase>
	{
		public InputPeer peer;
		public int msg_id;
	}

	[TLDef(0x5FF58F20)]
	public sealed partial class Payments_LaunchPrepaidGiveaway : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public long giveaway_id;
		public InputStorePaymentPurpose purpose;
	}

	[TLDef(0xC00EC7D3)]
	public sealed partial class Payments_GetStarsTopupOptions : IMethod<StarsTopupOption[]> { }

	[TLDef(0x104FCFA7)]
	public sealed partial class Payments_GetStarsStatus : IMethod<Payments_StarsStatus>
	{
		public InputPeer peer;
	}

	[TLDef(0x69DA4557)]
	public sealed partial class Payments_GetStarsTransactions : IMethod<Payments_StarsStatus>
	{
		public Flags flags;
		[IfFlag(3)] public string subscription_id;
		public InputPeer peer;
		public string offset;
		public int limit;

		[Flags] public enum Flags : uint
		{
			inbound = 0x1,
			outbound = 0x2,
			ascending = 0x4,
			has_subscription_id = 0x8,
		}
	}

	[TLDef(0x7998C914)]
	public sealed partial class Payments_SendStarsForm : IMethod<Payments_PaymentResultBase>
	{
		public long form_id;
		public InputInvoice invoice;
	}

	[TLDef(0x25AE8F4A)]
	public sealed partial class Payments_RefundStarsCharge : IMethod<UpdatesBase>
	{
		public InputUserBase user_id;
		public string charge_id;
	}

	[TLDef(0xD91FFAD6)]
	public sealed partial class Payments_GetStarsRevenueStats : IMethod<Payments_StarsRevenueStats>
	{
		public Flags flags;
		public InputPeer peer;

		[Flags] public enum Flags : uint
		{
			dark = 0x1,
		}
	}

	[TLDef(0x13BBE8B3)]
	public sealed partial class Payments_GetStarsRevenueWithdrawalUrl : IMethod<Payments_StarsRevenueWithdrawalUrl>
	{
		public InputPeer peer;
		public long stars;
		public InputCheckPasswordSRP password;
	}

	[TLDef(0xD1D7EFC5)]
	public sealed partial class Payments_GetStarsRevenueAdsAccountUrl : IMethod<Payments_StarsRevenueAdsAccountUrl>
	{
		public InputPeer peer;
	}

	[TLDef(0x27842D2E)]
	public sealed partial class Payments_GetStarsTransactionsByID : IMethod<Payments_StarsStatus>
	{
		public InputPeer peer;
		public InputStarsTransaction[] id;
	}

	[TLDef(0xD3C96BC8)]
	public sealed partial class Payments_GetStarsGiftOptions : IMethod<StarsGiftOption[]>
	{
		public Flags flags;
		[IfFlag(0)] public InputUserBase user_id;

		[Flags] public enum Flags : uint
		{
			has_user_id = 0x1,
		}
	}

	[TLDef(0x032512C5)]
	public sealed partial class Payments_GetStarsSubscriptions : IMethod<Payments_StarsStatus>
	{
		public Flags flags;
		public InputPeer peer;
		public string offset;

		[Flags] public enum Flags : uint
		{
			missing_balance = 0x1,
		}
	}

	[TLDef(0xC7770878)]
	public sealed partial class Payments_ChangeStarsSubscription : IMethod<bool>
	{
		public Flags flags;
		public InputPeer peer;
		public string subscription_id;
		[IfFlag(0)] public bool canceled;

		[Flags] public enum Flags : uint
		{
			has_canceled = 0x1,
		}
	}

	[TLDef(0xCC5BEBB3)]
	public sealed partial class Payments_FulfillStarsSubscription : IMethod<bool>
	{
		public InputPeer peer;
		public string subscription_id;
	}

	[TLDef(0xBD1EFD3E)]
	public sealed partial class Payments_GetStarsGiveawayOptions : IMethod<StarsGiveawayOption[]> { }

	[TLDef(0xC4563590)]
	public sealed partial class Payments_GetStarGifts : IMethod<Payments_StarGifts>
	{
		public int hash;
	}

	[TLDef(0x2A2A697C)]
	public sealed partial class Payments_SaveStarGift : IMethod<bool>
	{
		public Flags flags;
		public InputSavedStarGift stargift;

		[Flags] public enum Flags : uint
		{
			unsave = 0x1,
		}
	}

	[TLDef(0x74BF076B)]
	public sealed partial class Payments_ConvertStarGift : IMethod<bool>
	{
		public InputSavedStarGift stargift;
	}

	[TLDef(0x6DFA0622)]
	public sealed partial class Payments_BotCancelStarsSubscription : IMethod<bool>
	{
		public Flags flags;
		public InputUserBase user_id;
		public string charge_id;

		[Flags] public enum Flags : uint
		{
			restore = 0x1,
		}
	}

	[TLDef(0x5869A553)]
	public sealed partial class Payments_GetConnectedStarRefBots : IMethod<Payments_ConnectedStarRefBots>
	{
		public Flags flags;
		public InputPeer peer;
		[IfFlag(2)] public DateTime offset_date;
		[IfFlag(2)] public string offset_link;
		public int limit;

		[Flags] public enum Flags : uint
		{
			has_offset_date = 0x4,
		}
	}

	[TLDef(0xB7D998F0)]
	public sealed partial class Payments_GetConnectedStarRefBot : IMethod<Payments_ConnectedStarRefBots>
	{
		public InputPeer peer;
		public InputUserBase bot;
	}

	[TLDef(0x0D6B48F7)]
	public sealed partial class Payments_GetSuggestedStarRefBots : IMethod<Payments_SuggestedStarRefBots>
	{
		public Flags flags;
		public InputPeer peer;
		public string offset;
		public int limit;

		[Flags] public enum Flags : uint
		{
			order_by_revenue = 0x1,
			order_by_date = 0x2,
		}
	}

	[TLDef(0x7ED5348A)]
	public sealed partial class Payments_ConnectStarRefBot : IMethod<Payments_ConnectedStarRefBots>
	{
		public InputPeer peer;
		public InputUserBase bot;
	}

	[TLDef(0xE4FCA4A3)]
	public sealed partial class Payments_EditConnectedStarRefBot : IMethod<Payments_ConnectedStarRefBots>
	{
		public Flags flags;
		public InputPeer peer;
		public string link;

		[Flags] public enum Flags : uint
		{
			revoked = 0x1,
		}
	}

	[TLDef(0x9C9ABCB1)]
	public sealed partial class Payments_GetStarGiftUpgradePreview : IMethod<Payments_StarGiftUpgradePreview>
	{
		public long gift_id;
	}

	[TLDef(0xAED6E4F5)]
	public sealed partial class Payments_UpgradeStarGift : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputSavedStarGift stargift;

		[Flags] public enum Flags : uint
		{
			keep_original_details = 0x1,
		}
	}

	[TLDef(0x7F18176A)]
	public sealed partial class Payments_TransferStarGift : IMethod<UpdatesBase>
	{
		public InputSavedStarGift stargift;
		public InputPeer to_id;
	}

	[TLDef(0xA1974D72)]
	public sealed partial class Payments_GetUniqueStarGift : IMethod<Payments_UniqueStarGift>
	{
		public string slug;
	}

	[TLDef(0x23830DE9)]
	public sealed partial class Payments_GetSavedStarGifts : IMethod<Payments_SavedStarGifts>
	{
		public Flags flags;
		public InputPeer peer;
		public string offset;
		public int limit;

		[Flags] public enum Flags : uint
		{
			exclude_unsaved = 0x1,
			exclude_saved = 0x2,
			exclude_unlimited = 0x4,
			exclude_limited = 0x8,
			exclude_unique = 0x10,
			sort_by_value = 0x20,
		}
	}

	[TLDef(0xB455A106)]
	public sealed partial class Payments_GetSavedStarGift : IMethod<Payments_SavedStarGifts>
	{
		public InputSavedStarGift[] stargift;
	}

	[TLDef(0xD06E93A8)]
	public sealed partial class Payments_GetStarGiftWithdrawalUrl : IMethod<Payments_StarGiftWithdrawalUrl>
	{
		public InputSavedStarGift stargift;
		public InputCheckPasswordSRP password;
	}

	[TLDef(0x60EAEFA1)]
	public sealed partial class Payments_ToggleChatStarGiftNotifications : IMethod<bool>
	{
		public Flags flags;
		public InputPeer peer;

		[Flags] public enum Flags : uint
		{
			enabled = 0x1,
		}
	}

	[TLDef(0x9021AB67)]
	public sealed partial class Stickers_CreateStickerSet : IMethod<Messages_StickerSet>
	{
		public Flags flags;
		public InputUserBase user_id;
		public string title;
		public string short_name;
		[IfFlag(2)] public InputDocument thumb;
		public InputStickerSetItem[] stickers;
		[IfFlag(3)] public string software;

		[Flags] public enum Flags : uint
		{
			masks = 0x1,
			has_thumb = 0x4,
			has_software = 0x8,
			emojis = 0x20,
			text_color = 0x40,
		}
	}

	[TLDef(0xF7760F51)]
	public sealed partial class Stickers_RemoveStickerFromSet : IMethod<Messages_StickerSet>
	{
		public InputDocument sticker;
	}

	[TLDef(0xFFB6D4CA)]
	public sealed partial class Stickers_ChangeStickerPosition : IMethod<Messages_StickerSet>
	{
		public InputDocument sticker;
		public int position;
	}

	[TLDef(0x8653FEBE)]
	public sealed partial class Stickers_AddStickerToSet : IMethod<Messages_StickerSet>
	{
		public InputStickerSet stickerset;
		public InputStickerSetItem sticker;
	}

	[TLDef(0xA76A5392)]
	public sealed partial class Stickers_SetStickerSetThumb : IMethod<Messages_StickerSet>
	{
		public Flags flags;
		public InputStickerSet stickerset;
		[IfFlag(0)] public InputDocument thumb;
		[IfFlag(1)] public long thumb_document_id;

		[Flags] public enum Flags : uint
		{
			has_thumb = 0x1,
			has_thumb_document_id = 0x2,
		}
	}

	[TLDef(0x284B3639)]
	public sealed partial class Stickers_CheckShortName : IMethod<bool>
	{
		public string short_name;
	}

	[TLDef(0x4DAFC503)]
	public sealed partial class Stickers_SuggestShortName : IMethod<Stickers_SuggestedShortName>
	{
		public string title;
	}

	[TLDef(0xF5537EBC)]
	public sealed partial class Stickers_ChangeSticker : IMethod<Messages_StickerSet>
	{
		public Flags flags;
		public InputDocument sticker;
		[IfFlag(0)] public string emoji;
		[IfFlag(1)] public MaskCoords mask_coords;
		[IfFlag(2)] public string keywords;

		[Flags] public enum Flags : uint
		{
			has_emoji = 0x1,
			has_mask_coords = 0x2,
			has_keywords = 0x4,
		}
	}

	[TLDef(0x124B1C00)]
	public sealed partial class Stickers_RenameStickerSet : IMethod<Messages_StickerSet>
	{
		public InputStickerSet stickerset;
		public string title;
	}

	[TLDef(0x87704394)]
	public sealed partial class Stickers_DeleteStickerSet : IMethod<bool>
	{
		public InputStickerSet stickerset;
	}

	[TLDef(0x4696459A)]
	public sealed partial class Stickers_ReplaceSticker : IMethod<Messages_StickerSet>
	{
		public InputDocument sticker;
		public InputStickerSetItem new_sticker;
	}

	[TLDef(0x55451FA9)]
	public sealed partial class Phone_GetCallConfig : IMethod<DataJSON> { }

	[TLDef(0xA6C4600C)]
	public sealed partial class Phone_RequestCall : IMethod<Phone_PhoneCall>
	{
		public Flags flags;
		public InputUserBase user_id;
		[IfFlag(1)] public InputGroupCall conference_call;
		public int random_id;
		public byte[] g_a_hash;
		public PhoneCallProtocol protocol;

		[Flags] public enum Flags : uint
		{
			video = 0x1,
			has_conference_call = 0x2,
		}
	}

	[TLDef(0x3BD2B4A0)]
	public sealed partial class Phone_AcceptCall : IMethod<Phone_PhoneCall>
	{
		public InputPhoneCall peer;
		public byte[] g_b;
		public PhoneCallProtocol protocol;
	}

	[TLDef(0x2EFE1722)]
	public sealed partial class Phone_ConfirmCall : IMethod<Phone_PhoneCall>
	{
		public InputPhoneCall peer;
		public byte[] g_a;
		public long key_fingerprint;
		public PhoneCallProtocol protocol;
	}

	[TLDef(0x17D54F61)]
	public sealed partial class Phone_ReceivedCall : IMethod<bool>
	{
		public InputPhoneCall peer;
	}

	[TLDef(0xB2CBC1C0)]
	public sealed partial class Phone_DiscardCall : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPhoneCall peer;
		public int duration;
		public PhoneCallDiscardReason reason;
		public long connection_id;

		[Flags] public enum Flags : uint
		{
			video = 0x1,
		}
	}

	[TLDef(0x59EAD627)]
	public sealed partial class Phone_SetCallRating : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPhoneCall peer;
		public int rating;
		public string comment;

		[Flags] public enum Flags : uint
		{
			user_initiative = 0x1,
		}
	}

	[TLDef(0x277ADD7E)]
	public sealed partial class Phone_SaveCallDebug : IMethod<bool>
	{
		public InputPhoneCall peer;
		public DataJSON debug;
	}

	[TLDef(0xFF7A9383)]
	public sealed partial class Phone_SendSignalingData : IMethod<bool>
	{
		public InputPhoneCall peer;
		public byte[] data;
	}

	[TLDef(0x48CDC6D8)]
	public sealed partial class Phone_CreateGroupCall : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPeer peer;
		public int random_id;
		[IfFlag(0)] public string title;
		[IfFlag(1)] public DateTime schedule_date;

		[Flags] public enum Flags : uint
		{
			has_title = 0x1,
			has_schedule_date = 0x2,
			rtmp_stream = 0x4,
		}
	}

	[TLDef(0xD61E1DF3)]
	public sealed partial class Phone_JoinGroupCall : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputGroupCall call;
		public InputPeer join_as;
		[IfFlag(1)] public string invite_hash;
		[IfFlag(3)] public long key_fingerprint;
		public DataJSON params_;

		[Flags] public enum Flags : uint
		{
			muted = 0x1,
			has_invite_hash = 0x2,
			video_stopped = 0x4,
			has_key_fingerprint = 0x8,
		}
	}

	[TLDef(0x500377F9)]
	public sealed partial class Phone_LeaveGroupCall : IMethod<UpdatesBase>
	{
		public InputGroupCall call;
		public int source;
	}

	[TLDef(0x7B393160)]
	public sealed partial class Phone_InviteToGroupCall : IMethod<UpdatesBase>
	{
		public InputGroupCall call;
		public InputUserBase[] users;
	}

	[TLDef(0x7A777135)]
	public sealed partial class Phone_DiscardGroupCall : IMethod<UpdatesBase>
	{
		public InputGroupCall call;
	}

	[TLDef(0x74BBB43D)]
	public sealed partial class Phone_ToggleGroupCallSettings : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputGroupCall call;
		[IfFlag(0)] public bool join_muted;

		[Flags] public enum Flags : uint
		{
			has_join_muted = 0x1,
			reset_invite_hash = 0x2,
		}
	}

	[TLDef(0x041845DB)]
	public sealed partial class Phone_GetGroupCall : IMethod<Phone_GroupCall>
	{
		public InputGroupCall call;
		public int limit;
	}

	[TLDef(0xC558D8AB)]
	public sealed partial class Phone_GetGroupParticipants : IMethod<Phone_GroupParticipants>
	{
		public InputGroupCall call;
		public InputPeer[] ids;
		public int[] sources;
		public string offset;
		public int limit;
	}

	[TLDef(0xB59CF977)]
	public sealed partial class Phone_CheckGroupCall : IMethod<int[]>
	{
		public InputGroupCall call;
		public int[] sources;
	}

	[TLDef(0xF128C708)]
	public sealed partial class Phone_ToggleGroupCallRecord : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputGroupCall call;
		[IfFlag(1)] public string title;
		[IfFlag(2)] public bool video_portrait;

		[Flags] public enum Flags : uint
		{
			start = 0x1,
			has_title = 0x2,
			video = 0x4,
		}
	}

	[TLDef(0xA5273ABF)]
	public sealed partial class Phone_EditGroupCallParticipant : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputGroupCall call;
		public InputPeer participant;
		[IfFlag(0)] public bool muted;
		[IfFlag(1)] public int volume;
		[IfFlag(2)] public bool raise_hand;
		[IfFlag(3)] public bool video_stopped;
		[IfFlag(4)] public bool video_paused;
		[IfFlag(5)] public bool presentation_paused;

		[Flags] public enum Flags : uint
		{
			has_muted = 0x1,
			has_volume = 0x2,
			has_raise_hand = 0x4,
			has_video_stopped = 0x8,
			has_video_paused = 0x10,
			has_presentation_paused = 0x20,
		}
	}

	[TLDef(0x1CA6AC0A)]
	public sealed partial class Phone_EditGroupCallTitle : IMethod<UpdatesBase>
	{
		public InputGroupCall call;
		public string title;
	}

	[TLDef(0xEF7C213A)]
	public sealed partial class Phone_GetGroupCallJoinAs : IMethod<Phone_JoinAsPeers>
	{
		public InputPeer peer;
	}

	[TLDef(0xE6AA647F)]
	public sealed partial class Phone_ExportGroupCallInvite : IMethod<Phone_ExportedGroupCallInvite>
	{
		public Flags flags;
		public InputGroupCall call;

		[Flags] public enum Flags : uint
		{
			can_self_unmute = 0x1,
		}
	}

	[TLDef(0x219C34E6)]
	public sealed partial class Phone_ToggleGroupCallStartSubscription : IMethod<UpdatesBase>
	{
		public InputGroupCall call;
		public bool subscribed;
	}

	[TLDef(0x5680E342)]
	public sealed partial class Phone_StartScheduledGroupCall : IMethod<UpdatesBase>
	{
		public InputGroupCall call;
	}

	[TLDef(0x575E1F8C)]
	public sealed partial class Phone_SaveDefaultGroupCallJoinAs : IMethod<bool>
	{
		public InputPeer peer;
		public InputPeer join_as;
	}

	[TLDef(0xCBEA6BC4)]
	public sealed partial class Phone_JoinGroupCallPresentation : IMethod<UpdatesBase>
	{
		public InputGroupCall call;
		public DataJSON params_;
	}

	[TLDef(0x1C50D144)]
	public sealed partial class Phone_LeaveGroupCallPresentation : IMethod<UpdatesBase>
	{
		public InputGroupCall call;
	}

	[TLDef(0x1AB21940)]
	public sealed partial class Phone_GetGroupCallStreamChannels : IMethod<Phone_GroupCallStreamChannels>
	{
		public InputGroupCall call;
	}

	[TLDef(0xDEB3ABBF)]
	public sealed partial class Phone_GetGroupCallStreamRtmpUrl : IMethod<Phone_GroupCallStreamRtmpUrl>
	{
		public InputPeer peer;
		public bool revoke;
	}

	[TLDef(0x41248786)]
	public sealed partial class Phone_SaveCallLog : IMethod<bool>
	{
		public InputPhoneCall peer;
		public InputFileBase file;
	}

	[TLDef(0xDFC909AB)]
	public sealed partial class Phone_CreateConferenceCall : IMethod<Phone_PhoneCall>
	{
		public InputPhoneCall peer;
		public long key_fingerprint;
	}

	[TLDef(0xF2F2330A)]
	public sealed partial class Langpack_GetLangPack : IMethod<LangPackDifference>
	{
		public string lang_pack;
		public string lang_code;
	}

	[TLDef(0xEFEA3803)]
	public sealed partial class Langpack_GetStrings : IMethod<LangPackStringBase[]>
	{
		public string lang_pack;
		public string lang_code;
		public string[] keys;
	}

	[TLDef(0xCD984AA5)]
	public sealed partial class Langpack_GetDifference : IMethod<LangPackDifference>
	{
		public string lang_pack;
		public string lang_code;
		public int from_version;
	}

	[TLDef(0x42C6978F)]
	public sealed partial class Langpack_GetLanguages : IMethod<LangPackLanguage[]>
	{
		public string lang_pack;
	}

	[TLDef(0x6A596502)]
	public sealed partial class Langpack_GetLanguage : IMethod<LangPackLanguage>
	{
		public string lang_pack;
		public string lang_code;
	}

	[TLDef(0x6847D0AB)]
	public sealed partial class Folders_EditPeerFolders : IMethod<UpdatesBase>
	{
		public InputFolderPeer[] folder_peers;
	}

	[TLDef(0xAB42441A)]
	public sealed partial class Stats_GetBroadcastStats : IMethod<Stats_BroadcastStats>
	{
		public Flags flags;
		public InputChannelBase channel;

		[Flags] public enum Flags : uint
		{
			dark = 0x1,
		}
	}

	[TLDef(0x621D5FA0)]
	public sealed partial class Stats_LoadAsyncGraph : IMethod<StatsGraphBase>
	{
		public Flags flags;
		public string token;
		[IfFlag(0)] public long x;

		[Flags] public enum Flags : uint
		{
			has_x = 0x1,
		}
	}

	[TLDef(0xDCDF8607)]
	public sealed partial class Stats_GetMegagroupStats : IMethod<Stats_MegagroupStats>
	{
		public Flags flags;
		public InputChannelBase channel;

		[Flags] public enum Flags : uint
		{
			dark = 0x1,
		}
	}

	[TLDef(0x5F150144)]
	public sealed partial class Stats_GetMessagePublicForwards : IMethod<Stats_PublicForwards>
	{
		public InputChannelBase channel;
		public int msg_id;
		public string offset;
		public int limit;
	}

	[TLDef(0xB6E0A3F5)]
	public sealed partial class Stats_GetMessageStats : IMethod<Stats_MessageStats>
	{
		public Flags flags;
		public InputChannelBase channel;
		public int msg_id;

		[Flags] public enum Flags : uint
		{
			dark = 0x1,
		}
	}

	[TLDef(0x374FEF40)]
	public sealed partial class Stats_GetStoryStats : IMethod<Stats_StoryStats>
	{
		public Flags flags;
		public InputPeer peer;
		public int id;

		[Flags] public enum Flags : uint
		{
			dark = 0x1,
		}
	}

	[TLDef(0xA6437EF6)]
	public sealed partial class Stats_GetStoryPublicForwards : IMethod<Stats_PublicForwards>
	{
		public InputPeer peer;
		public int id;
		public string offset;
		public int limit;
	}

	[TLDef(0xF788EE19)]
	public sealed partial class Stats_GetBroadcastRevenueStats : IMethod<Stats_BroadcastRevenueStats>
	{
		public Flags flags;
		public InputPeer peer;

		[Flags] public enum Flags : uint
		{
			dark = 0x1,
		}
	}

	[TLDef(0x9DF4FAAD)]
	public sealed partial class Stats_GetBroadcastRevenueWithdrawalUrl : IMethod<Stats_BroadcastRevenueWithdrawalUrl>
	{
		public InputPeer peer;
		public InputCheckPasswordSRP password;
	}

	[TLDef(0x70990B6D)]
	public sealed partial class Stats_GetBroadcastRevenueTransactions : IMethod<Stats_BroadcastRevenueTransactions>
	{
		public InputPeer peer;
		public int offset;
		public int limit;
	}

	[TLDef(0x8472478E)]
	public sealed partial class Chatlists_ExportChatlistInvite : IMethod<Chatlists_ExportedChatlistInvite>
	{
		public InputChatlist chatlist;
		public string title;
		public InputPeer[] peers;
	}

	[TLDef(0x719C5C5E)]
	public sealed partial class Chatlists_DeleteExportedInvite : IMethod<bool>
	{
		public InputChatlist chatlist;
		public string slug;
	}

	[TLDef(0x653DB63D)]
	public sealed partial class Chatlists_EditExportedInvite : IMethod<ExportedChatlistInvite>
	{
		public Flags flags;
		public InputChatlist chatlist;
		public string slug;
		[IfFlag(1)] public string title;
		[IfFlag(2)] public InputPeer[] peers;

		[Flags] public enum Flags : uint
		{
			has_title = 0x2,
			has_peers = 0x4,
		}
	}

	[TLDef(0xCE03DA83)]
	public sealed partial class Chatlists_GetExportedInvites : IMethod<Chatlists_ExportedInvites>
	{
		public InputChatlist chatlist;
	}

	[TLDef(0x41C10FFF)]
	public sealed partial class Chatlists_CheckChatlistInvite : IMethod<Chatlists_ChatlistInviteBase>
	{
		public string slug;
	}

	[TLDef(0xA6B1E39A)]
	public sealed partial class Chatlists_JoinChatlistInvite : IMethod<UpdatesBase>
	{
		public string slug;
		public InputPeer[] peers;
	}

	[TLDef(0x89419521)]
	public sealed partial class Chatlists_GetChatlistUpdates : IMethod<Chatlists_ChatlistUpdates>
	{
		public InputChatlist chatlist;
	}

	[TLDef(0xE089F8F5)]
	public sealed partial class Chatlists_JoinChatlistUpdates : IMethod<UpdatesBase>
	{
		public InputChatlist chatlist;
		public InputPeer[] peers;
	}

	[TLDef(0x66E486FB)]
	public sealed partial class Chatlists_HideChatlistUpdates : IMethod<bool>
	{
		public InputChatlist chatlist;
	}

	[TLDef(0xFDBCD714)]
	public sealed partial class Chatlists_GetLeaveChatlistSuggestions : IMethod<Peer[]>
	{
		public InputChatlist chatlist;
	}

	[TLDef(0x74FAE13A)]
	public sealed partial class Chatlists_LeaveChatlist : IMethod<UpdatesBase>
	{
		public InputChatlist chatlist;
		public InputPeer[] peers;
	}

	[TLDef(0xC7DFDFDD)]
	public sealed partial class Stories_CanSendStory : IMethod<bool>
	{
		public InputPeer peer;
	}

	[TLDef(0xE4E6694B)]
	public sealed partial class Stories_SendStory : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPeer peer;
		public InputMedia media;
		[IfFlag(5)] public MediaArea[] media_areas;
		[IfFlag(0)] public string caption;
		[IfFlag(1)] public MessageEntity[] entities;
		public InputPrivacyRule[] privacy_rules;
		public long random_id;
		[IfFlag(3)] public int period;
		[IfFlag(6)] public InputPeer fwd_from_id;
		[IfFlag(6)] public int fwd_from_story;

		[Flags] public enum Flags : uint
		{
			has_caption = 0x1,
			has_entities = 0x2,
			pinned = 0x4,
			has_period = 0x8,
			noforwards = 0x10,
			has_media_areas = 0x20,
			has_fwd_from_id = 0x40,
			fwd_modified = 0x80,
		}
	}

	[TLDef(0xB583BA46)]
	public sealed partial class Stories_EditStory : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPeer peer;
		public int id;
		[IfFlag(0)] public InputMedia media;
		[IfFlag(3)] public MediaArea[] media_areas;
		[IfFlag(1)] public string caption;
		[IfFlag(1)] public MessageEntity[] entities;
		[IfFlag(2)] public InputPrivacyRule[] privacy_rules;

		[Flags] public enum Flags : uint
		{
			has_media = 0x1,
			has_caption = 0x2,
			has_privacy_rules = 0x4,
			has_media_areas = 0x8,
		}
	}

	[TLDef(0xAE59DB5F)]
	public sealed partial class Stories_DeleteStories : IMethod<int[]>
	{
		public InputPeer peer;
		public int[] id;
	}

	[TLDef(0x9A75A1EF)]
	public sealed partial class Stories_TogglePinned : IMethod<int[]>
	{
		public InputPeer peer;
		public int[] id;
		public bool pinned;
	}

	[TLDef(0xEEB0D625)]
	public sealed partial class Stories_GetAllStories : IMethod<Stories_AllStoriesBase>
	{
		public Flags flags;
		[IfFlag(0)] public string state;

		[Flags] public enum Flags : uint
		{
			has_state = 0x1,
			next = 0x2,
			hidden = 0x4,
		}
	}

	[TLDef(0x5821A5DC)]
	public sealed partial class Stories_GetPinnedStories : IMethod<Stories_Stories>
	{
		public InputPeer peer;
		public int offset_id;
		public int limit;
	}

	[TLDef(0xB4352016)]
	public sealed partial class Stories_GetStoriesArchive : IMethod<Stories_Stories>
	{
		public InputPeer peer;
		public int offset_id;
		public int limit;
	}

	[TLDef(0x5774CA74)]
	public sealed partial class Stories_GetStoriesByID : IMethod<Stories_Stories>
	{
		public InputPeer peer;
		public int[] id;
	}

	[TLDef(0x7C2557C4)]
	public sealed partial class Stories_ToggleAllStoriesHidden : IMethod<bool>
	{
		public bool hidden;
	}

	[TLDef(0xA556DAC8)]
	public sealed partial class Stories_ReadStories : IMethod<int[]>
	{
		public InputPeer peer;
		public int max_id;
	}

	[TLDef(0xB2028AFB)]
	public sealed partial class Stories_IncrementStoryViews : IMethod<bool>
	{
		public InputPeer peer;
		public int[] id;
	}

	[TLDef(0x7ED23C57)]
	public sealed partial class Stories_GetStoryViewsList : IMethod<Stories_StoryViewsList>
	{
		public Flags flags;
		public InputPeer peer;
		[IfFlag(1)] public string q;
		public int id;
		public string offset;
		public int limit;

		[Flags] public enum Flags : uint
		{
			just_contacts = 0x1,
			has_q = 0x2,
			reactions_first = 0x4,
			forwards_first = 0x8,
		}
	}

	[TLDef(0x28E16CC8)]
	public sealed partial class Stories_GetStoriesViews : IMethod<Stories_StoryViews>
	{
		public InputPeer peer;
		public int[] id;
	}

	[TLDef(0x7B8DEF20)]
	public sealed partial class Stories_ExportStoryLink : IMethod<ExportedStoryLink>
	{
		public InputPeer peer;
		public int id;
	}

	[TLDef(0x19D8EB45)]
	public sealed partial class Stories_Report : IMethod<ReportResult>
	{
		public InputPeer peer;
		public int[] id;
		public byte[] option;
		public string message;
	}

	[TLDef(0x57BBD166)]
	public sealed partial class Stories_ActivateStealthMode : IMethod<UpdatesBase>
	{
		public Flags flags;

		[Flags] public enum Flags : uint
		{
			past = 0x1,
			future = 0x2,
		}
	}

	[TLDef(0x7FD736B2)]
	public sealed partial class Stories_SendReaction : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPeer peer;
		public int story_id;
		public Reaction reaction;

		[Flags] public enum Flags : uint
		{
			add_to_recent = 0x1,
		}
	}

	[TLDef(0x2C4ADA50)]
	public sealed partial class Stories_GetPeerStories : IMethod<Stories_PeerStories>
	{
		public InputPeer peer;
	}

	[TLDef(0x9B5AE7F9)]
	public sealed partial class Stories_GetAllReadPeerStories : IMethod<UpdatesBase> { }

	[TLDef(0x535983C3)]
	public sealed partial class Stories_GetPeerMaxIDs : IMethod<int[]>
	{
		public InputPeer[] id;
	}

	[TLDef(0xA56A8B60)]
	public sealed partial class Stories_GetChatsToSend : IMethod<Messages_Chats> { }

	[TLDef(0xBD0415C4)]
	public sealed partial class Stories_TogglePeerStoriesHidden : IMethod<bool>
	{
		public InputPeer peer;
		public bool hidden;
	}

	[TLDef(0xB9B2881F)]
	public sealed partial class Stories_GetStoryReactionsList : IMethod<Stories_StoryReactionsList>
	{
		public Flags flags;
		public InputPeer peer;
		public int id;
		[IfFlag(0)] public Reaction reaction;
		[IfFlag(1)] public string offset;
		public int limit;

		[Flags] public enum Flags : uint
		{
			has_reaction = 0x1,
			has_offset = 0x2,
			forwards_first = 0x4,
		}
	}

	[TLDef(0x0B297E9B)]
	public sealed partial class Stories_TogglePinnedToTop : IMethod<bool>
	{
		public InputPeer peer;
		public int[] id;
	}

	[TLDef(0xD1810907)]
	public sealed partial class Stories_SearchPosts : IMethod<Stories_FoundStories>
	{
		public Flags flags;
		[IfFlag(0)] public string hashtag;
		[IfFlag(1)] public MediaArea area;
		[IfFlag(2)] public InputPeer peer;
		public string offset;
		public int limit;

		[Flags] public enum Flags : uint
		{
			has_hashtag = 0x1,
			has_area = 0x2,
			has_peer = 0x4,
		}
	}

	[TLDef(0x60F67660)]
	public sealed partial class Premium_GetBoostsList : IMethod<Premium_BoostsList>
	{
		public Flags flags;
		public InputPeer peer;
		public string offset;
		public int limit;

		[Flags] public enum Flags : uint
		{
			gifts = 0x1,
		}
	}

	[TLDef(0x0BE77B4A)]
	public sealed partial class Premium_GetMyBoosts : IMethod<Premium_MyBoosts> { }

	[TLDef(0x6B7DA746)]
	public sealed partial class Premium_ApplyBoost : IMethod<Premium_MyBoosts>
	{
		public Flags flags;
		[IfFlag(0)] public int[] slots;
		public InputPeer peer;

		[Flags] public enum Flags : uint
		{
			has_slots = 0x1,
		}
	}

	[TLDef(0x042F1F61)]
	public sealed partial class Premium_GetBoostsStatus : IMethod<Premium_BoostsStatus>
	{
		public InputPeer peer;
	}

	[TLDef(0x39854D1F)]
	public sealed partial class Premium_GetUserBoosts : IMethod<Premium_BoostsList>
	{
		public InputPeer peer;
		public InputUserBase user_id;
	}

	[TLDef(0x0EDC39D0)]
	public sealed partial class Smsjobs_IsEligibleToJoin : IMethod<Smsjobs_EligibilityToJoin> { }

	[TLDef(0xA74ECE2D)]
	public sealed partial class Smsjobs_Join : IMethod<bool> { }

	[TLDef(0x9898AD73)]
	public sealed partial class Smsjobs_Leave : IMethod<bool> { }

	[TLDef(0x093FA0BF)]
	public sealed partial class Smsjobs_UpdateSettings : IMethod<bool>
	{
		public Flags flags;

		[Flags] public enum Flags : uint
		{
			allow_international = 0x1,
		}
	}

	[TLDef(0x10A698E8)]
	public sealed partial class Smsjobs_GetStatus : IMethod<Smsjobs_Status> { }

	[TLDef(0x778D902F)]
	public sealed partial class Smsjobs_GetSmsJob : IMethod<SmsJob>
	{
		public string job_id;
	}

	[TLDef(0x4F1EBF24)]
	public sealed partial class Smsjobs_FinishJob : IMethod<bool>
	{
		public Flags flags;
		public string job_id;
		[IfFlag(0)] public string error;

		[Flags] public enum Flags : uint
		{
			has_error = 0x1,
		}
	}

	[TLDef(0xBE1E85BA)]
	public sealed partial class Fragment_GetCollectibleInfo : IMethod<Fragment_CollectibleInfo>
	{
		public InputCollectible collectible;
	}
}
