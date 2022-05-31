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
		/// <param name="lang_pack">Language pack to use</param>
		/// <param name="lang_code">Code for the language used on the client, ISO 639-1 standard</param>
		/// <param name="proxy">Info about an MTProto proxy</param>
		/// <param name="params_">Additional initConnection parameters. <br/>For now, only the <c>tz_offset</c> field is supported, for specifying timezone offset in seconds.</param>
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

		/// <summary>Invoke the specified query using the specified API <a href="https://corefork.telegram.org/api/invoking#layers">layer</a>		<para>See <a href="https://corefork.telegram.org/method/invokeWithLayer"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/invokeWithLayer#possible-errors">details</a>)</para></summary>
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

		/// <summary>Invoke a method within a takeout session		<para>See <a href="https://corefork.telegram.org/method/invokeWithTakeout"/></para></summary>
		/// <param name="takeout_id">Takeout session ID</param>
		/// <param name="query">Query</param>
		public static Task<X> InvokeWithTakeout<X>(this Client client, long takeout_id, IMethod<X> query)
			=> client.Invoke(new InvokeWithTakeout<X>
			{
				takeout_id = takeout_id,
				query = query,
			});

		/// <summary>Send the verification code for login		<para>See <a href="https://corefork.telegram.org/method/auth.sendCode"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406,500 (<a href="https://corefork.telegram.org/method/auth.sendCode#possible-errors">details</a>)</para></summary>
		/// <param name="phone_number">Phone number in international format</param>
		/// <param name="api_id">Application identifier (see <a href="https://corefork.telegram.org/myapp">App configuration</a>)</param>
		/// <param name="api_hash">Application secret hash (see <a href="https://corefork.telegram.org/myapp">App configuration</a>)</param>
		/// <param name="settings">Settings for the code type to send</param>
		[Obsolete("Use LoginUserIfNeeded instead of this method. See https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#tlsharp")]
		public static Task<Auth_SentCode> Auth_SendCode(this Client client, string phone_number, int api_id, string api_hash, CodeSettings settings)
			=> client.Invoke(new Auth_SendCode
			{
				phone_number = phone_number,
				api_id = api_id,
				api_hash = api_hash,
				settings = settings,
			});

		/// <summary>Registers a validated phone number in the system.		<para>See <a href="https://corefork.telegram.org/method/auth.signUp"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/auth.signUp#possible-errors">details</a>)</para></summary>
		/// <param name="phone_number">Phone number in the international format</param>
		/// <param name="phone_code_hash">SMS-message ID</param>
		/// <param name="first_name">New user first name</param>
		/// <param name="last_name">New user last name</param>
		[Obsolete("Use LoginUserIfNeeded instead of this method. See https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#tlsharp")]
		public static Task<Auth_AuthorizationBase> Auth_SignUp(this Client client, string phone_number, string phone_code_hash, string first_name, string last_name)
			=> client.Invoke(new Auth_SignUp
			{
				phone_number = phone_number,
				phone_code_hash = phone_code_hash,
				first_name = first_name,
				last_name = last_name,
			});

		/// <summary>Signs in a user with a validated phone number.		<para>See <a href="https://corefork.telegram.org/method/auth.signIn"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406,500 (<a href="https://corefork.telegram.org/method/auth.signIn#possible-errors">details</a>)</para></summary>
		/// <param name="phone_number">Phone number in the international format</param>
		/// <param name="phone_code_hash">SMS-message ID, obtained from <a href="https://corefork.telegram.org/method/auth.sendCode">auth.sendCode</a></param>
		/// <param name="phone_code">Valid numerical code from the SMS-message</param>
		[Obsolete("Use LoginUserIfNeeded instead of this method. See https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#tlsharp")]
		public static Task<Auth_AuthorizationBase> Auth_SignIn(this Client client, string phone_number, string phone_code_hash, string phone_code)
			=> client.Invoke(new Auth_SignIn
			{
				phone_number = phone_number,
				phone_code_hash = phone_code_hash,
				phone_code = phone_code,
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
		/// <param name="nonce">Random long from <a href="#binding-message-contents">Binding message contents</a></param>
		/// <param name="expires_at">Unix timestamp to invalidate temporary key, see <a href="#binding-message-contents">Binding message contents</a></param>
		/// <param name="encrypted_message">See <a href="#generating-encrypted-message">Generating encrypted_message</a></param>
		public static Task<bool> Auth_BindTempAuthKey(this Client client, long perm_auth_key_id, long nonce, DateTime expires_at, byte[] encrypted_message)
			=> client.Invoke(new Auth_BindTempAuthKey
			{
				perm_auth_key_id = perm_auth_key_id,
				nonce = nonce,
				expires_at = expires_at,
				encrypted_message = encrypted_message,
			});

		/// <summary>Login as a bot		<para>See <a href="https://corefork.telegram.org/method/auth.importBotAuthorization"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/auth.importBotAuthorization#possible-errors">details</a>)</para></summary>
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

		/// <summary>Try logging to an account protected by a <a href="https://corefork.telegram.org/api/srp">2FA password</a>.		<para>See <a href="https://corefork.telegram.org/method/auth.checkPassword"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/auth.checkPassword#possible-errors">details</a>)</para></summary>
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

		/// <summary>Reset the <a href="https://corefork.telegram.org/api/srp">2FA password</a> using the recovery code sent using <a href="https://corefork.telegram.org/method/auth.requestPasswordRecovery">auth.requestPasswordRecovery</a>.		<para>See <a href="https://corefork.telegram.org/method/auth.recoverPassword"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/auth.recoverPassword#possible-errors">details</a>)</para></summary>
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
		/// <param name="phone_code_hash">The phone code hash obtained from <a href="https://corefork.telegram.org/method/auth.sendCode">auth.sendCode</a></param>
		[Obsolete("Use LoginUserIfNeeded instead of this method. See https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#tlsharp")]
		public static Task<Auth_SentCode> Auth_ResendCode(this Client client, string phone_number, string phone_code_hash)
			=> client.Invoke(new Auth_ResendCode
			{
				phone_number = phone_number,
				phone_code_hash = phone_code_hash,
			});

		/// <summary>Cancel the login verification code		<para>See <a href="https://corefork.telegram.org/method/auth.cancelCode"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/auth.cancelCode#possible-errors">details</a>)</para></summary>
		/// <param name="phone_number">Phone number</param>
		/// <param name="phone_code_hash">Phone code hash from <a href="https://corefork.telegram.org/method/auth.sendCode">auth.sendCode</a></param>
		[Obsolete("Use LoginUserIfNeeded instead of this method. See https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#tlsharp")]
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

		/// <summary>Generate a login token, for <a href="https://corefork.telegram.org/api/qr-login">login via QR code</a>.<br/>The generated login token should be encoded using base64url, then shown as a <c>tg://login?token=base64encodedtoken</c> URL in the QR code.		<para>See <a href="https://corefork.telegram.org/method/auth.exportLoginToken"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/auth.exportLoginToken#possible-errors">details</a>)</para></summary>
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

		/// <summary>Check if the <a href="https://corefork.telegram.org/api/srp">2FA recovery code</a> sent using <a href="https://corefork.telegram.org/method/auth.requestPasswordRecovery">auth.requestPasswordRecovery</a> is valid, before passing it to <a href="https://corefork.telegram.org/method/auth.recoverPassword">auth.recoverPassword</a>.		<para>See <a href="https://corefork.telegram.org/method/auth.checkRecoveryPassword"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/auth.checkRecoveryPassword#possible-errors">details</a>)</para></summary>
		/// <param name="code">Code received via email</param>
		public static Task<bool> Auth_CheckRecoveryPassword(this Client client, string code)
			=> client.Invoke(new Auth_CheckRecoveryPassword
			{
				code = code,
			});

		/// <summary>Register device to receive <a href="https://corefork.telegram.org/api/push-updates">PUSH notifications</a>		<para>See <a href="https://corefork.telegram.org/method/account.registerDevice"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.registerDevice#possible-errors">details</a>)</para></summary>
		/// <param name="no_muted">Avoid receiving (silent and invisible background) notifications. Useful to save battery.</param>
		/// <param name="token_type">Device token type.<br/><strong>Possible values</strong>:<br/><c>1</c> - APNS (device token for apple push)<br/><c>2</c> - FCM (firebase token for google firebase)<br/><c>3</c> - MPNS (channel URI for microsoft push)<br/><c>4</c> - Simple push (endpoint for firefox's simple push API)<br/><c>5</c> - Ubuntu phone (token for ubuntu push)<br/><c>6</c> - Blackberry (token for blackberry push)<br/><c>7</c> - Unused<br/><c>8</c> - WNS (windows push)<br/><c>9</c> - APNS VoIP (token for apple push VoIP)<br/><c>10</c> - Web push (web push, see below)<br/><c>11</c> - MPNS VoIP (token for microsoft push VoIP)<br/><c>12</c> - Tizen (token for tizen push)<br/><br/>For <c>10</c> web push, the token must be a JSON-encoded object containing the keys described in <a href="https://corefork.telegram.org/api/push-updates">PUSH updates</a></param>
		/// <param name="token">Device token</param>
		/// <param name="app_sandbox">If <see cref="Bool.True"/> is transmitted, a sandbox-certificate will be used during transmission.</param>
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
		/// <param name="token_type">Device token type.<br/><strong>Possible values</strong>:<br/><c>1</c> - APNS (device token for apple push)<br/><c>2</c> - FCM (firebase token for google firebase)<br/><c>3</c> - MPNS (channel URI for microsoft push)<br/><c>4</c> - Simple push (endpoint for firefox's simple push API)<br/><c>5</c> - Ubuntu phone (token for ubuntu push)<br/><c>6</c> - Blackberry (token for blackberry push)<br/><c>7</c> - Unused<br/><c>8</c> - WNS (windows push)<br/><c>9</c> - APNS VoIP (token for apple push VoIP)<br/><c>10</c> - Web push (web push, see below)<br/><c>11</c> - MPNS VoIP (token for microsoft push VoIP)<br/><c>12</c> - Tizen (token for tizen push)<br/><br/>For <c>10</c> web push, the token must be a JSON-encoded object containing the keys described in <a href="https://corefork.telegram.org/api/push-updates">PUSH updates</a></param>
		/// <param name="token">Device token</param>
		/// <param name="other_uids">List of user identifiers of other users currently using the client</param>
		public static Task<bool> Account_UnregisterDevice(this Client client, int token_type, string token, long[] other_uids)
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
		/// <param name="offline">If <see cref="Bool.True"/> is transmitted, user status will change to <see cref="UserStatusOffline"/>.</param>
		public static Task<bool> Account_UpdateStatus(this Client client, bool offline)
			=> client.Invoke(new Account_UpdateStatus
			{
				offline = offline,
			});

		/// <summary>Returns a list of available wallpapers.		<para>See <a href="https://corefork.telegram.org/method/account.getWallPapers"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
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
		/// <param name="key">Peers to which the privacy rules apply</param>
		/// <param name="rules">New privacy rules</param>
		public static Task<Account_PrivacyRules> Account_SetPrivacy(this Client client, InputPrivacyKey key, params InputPrivacyRule[] rules)
			=> client.Invoke(new Account_SetPrivacy
			{
				key = key,
				rules = rules,
			});

		/// <summary>Delete the user's account from the telegram servers. Can be used, for example, to delete the account of a user that provided the login code, but forgot the <a href="https://corefork.telegram.org/api/srp">2FA password and no recovery method is configured</a>.		<para>See <a href="https://corefork.telegram.org/method/account.deleteAccount"/></para>		<para>Possible <see cref="RpcException"/> codes: 420 (<a href="https://corefork.telegram.org/method/account.deleteAccount#possible-errors">details</a>)</para></summary>
		/// <param name="reason">Why is the account being deleted, can be empty</param>
		public static Task<bool> Account_DeleteAccount(this Client client, string reason)
			=> client.Invoke(new Account_DeleteAccount
			{
				reason = reason,
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
		public static Task<Auth_SentCode> Account_SendChangePhoneCode(this Client client, string phone_number, CodeSettings settings)
			=> client.Invoke(new Account_SendChangePhoneCode
			{
				phone_number = phone_number,
				settings = settings,
			});

		/// <summary>Change the phone number of the current account		<para>See <a href="https://corefork.telegram.org/method/account.changePhone"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/account.changePhone#possible-errors">details</a>)</para></summary>
		/// <param name="phone_number">New phone number</param>
		/// <param name="phone_code_hash">Phone code hash received when calling <a href="https://corefork.telegram.org/method/account.sendChangePhoneCode">account.sendChangePhoneCode</a></param>
		/// <param name="phone_code">Phone code received when calling <a href="https://corefork.telegram.org/method/account.sendChangePhoneCode">account.sendChangePhoneCode</a></param>
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
		public static Task<Auth_SentCode> Account_SendConfirmPhoneCode(this Client client, string hash, CodeSettings settings)
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
		/// <param name="hash"><see cref="WebAuthorization"/> hash</param>
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

		/// <summary>Sends a Telegram Passport authorization form, effectively sharing data with the service		<para>See <a href="https://corefork.telegram.org/method/account.acceptAuthorization"/></para></summary>
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
		public static Task<Auth_SentCode> Account_SendVerifyPhoneCode(this Client client, string phone_number, CodeSettings settings)
			=> client.Invoke(new Account_SendVerifyPhoneCode
			{
				phone_number = phone_number,
				settings = settings,
			});

		/// <summary>Verify a phone number for telegram <a href="https://corefork.telegram.org/passport">passport</a>.		<para>See <a href="https://corefork.telegram.org/method/account.verifyPhone"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.verifyPhone#possible-errors">details</a>)</para></summary>
		/// <param name="phone_number">Phone number</param>
		/// <param name="phone_code_hash">Phone code hash received from the call to <a href="https://corefork.telegram.org/method/account.sendVerifyPhoneCode">account.sendVerifyPhoneCode</a></param>
		/// <param name="phone_code">Code received after the call to <a href="https://corefork.telegram.org/method/account.sendVerifyPhoneCode">account.sendVerifyPhoneCode</a></param>
		public static Task<bool> Account_VerifyPhone(this Client client, string phone_number, string phone_code_hash, string phone_code)
			=> client.Invoke(new Account_VerifyPhone
			{
				phone_number = phone_number,
				phone_code_hash = phone_code_hash,
				phone_code = phone_code,
			});

		/// <summary>Send the verification email code for telegram <a href="https://corefork.telegram.org/passport">passport</a>.		<para>See <a href="https://corefork.telegram.org/method/account.sendVerifyEmailCode"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.sendVerifyEmailCode#possible-errors">details</a>)</para></summary>
		/// <param name="email">The email where to send the code</param>
		public static Task<Account_SentEmailCode> Account_SendVerifyEmailCode(this Client client, string email)
			=> client.Invoke(new Account_SendVerifyEmailCode
			{
				email = email,
			});

		/// <summary>Verify an email address for telegram <a href="https://corefork.telegram.org/passport">passport</a>.		<para>See <a href="https://corefork.telegram.org/method/account.verifyEmail"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.verifyEmail#possible-errors">details</a>)</para></summary>
		/// <param name="email">The email to verify</param>
		/// <param name="code">The verification code that was received</param>
		public static Task<bool> Account_VerifyEmail(this Client client, string email, string code)
			=> client.Invoke(new Account_VerifyEmail
			{
				email = email,
				code = code,
			});

		/// <summary>Initialize account takeout session		<para>See <a href="https://corefork.telegram.org/method/account.initTakeoutSession"/></para>		<para>Possible <see cref="RpcException"/> codes: 420 (<a href="https://corefork.telegram.org/method/account.initTakeoutSession#possible-errors">details</a>)</para></summary>
		/// <param name="contacts">Whether to export contacts</param>
		/// <param name="message_users">Whether to export messages in private chats</param>
		/// <param name="message_chats">Whether to export messages in <a href="https://corefork.telegram.org/api/channel#basic-groups">basic groups</a></param>
		/// <param name="message_megagroups">Whether to export messages in <a href="https://corefork.telegram.org/api/channel#supergroups">supergroups</a></param>
		/// <param name="message_channels">Whether to export messages in <a href="https://corefork.telegram.org/api/channel#channels">channels</a></param>
		/// <param name="files">Whether to export files</param>
		/// <param name="file_max_size">Maximum size of files to export</param>
		public static Task<Account_Takeout> Account_InitTakeoutSession(this Client client, bool contacts = false, bool message_users = false, bool message_chats = false, bool message_megagroups = false, bool message_channels = false, bool files = false, int? file_max_size = null)
			=> client.Invoke(new Account_InitTakeoutSession
			{
				flags = (Account_InitTakeoutSession.Flags)((contacts ? 0x1 : 0) | (message_users ? 0x2 : 0) | (message_chats ? 0x4 : 0) | (message_megagroups ? 0x8 : 0) | (message_channels ? 0x10 : 0) | (files ? 0x20 : 0) | (file_max_size != null ? 0x20 : 0)),
				file_max_size = file_max_size.GetValueOrDefault(),
			});

		/// <summary>Finish account takeout session		<para>See <a href="https://corefork.telegram.org/method/account.finishTakeoutSession"/></para>		<para>Possible <see cref="RpcException"/> codes: 403 (<a href="https://corefork.telegram.org/method/account.finishTakeoutSession#possible-errors">details</a>)</para></summary>
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

		/// <summary>Resend the code to verify an email to use as <a href="https://corefork.telegram.org/api/srp">2FA recovery method</a>.		<para>See <a href="https://corefork.telegram.org/method/account.resendPasswordEmail"/></para></summary>
		public static Task<bool> Account_ResendPasswordEmail(this Client client)
			=> client.Invoke(new Account_ResendPasswordEmail
			{
			});

		/// <summary>Cancel the code that was sent to verify an email to use as <a href="https://corefork.telegram.org/api/srp">2FA recovery method</a>.		<para>See <a href="https://corefork.telegram.org/method/account.cancelPasswordEmail"/></para></summary>
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
		/// <param name="compare_sound">If true, chats with non-default sound will also be returned</param>
		/// <param name="peer">If specified, only chats of the specified category will be returned</param>
		public static Task<UpdatesBase> Account_GetNotifyExceptions(this Client client, bool compare_sound = false, InputNotifyPeerBase peer = null)
			=> client.Invoke(new Account_GetNotifyExceptions
			{
				flags = (Account_GetNotifyExceptions.Flags)((compare_sound ? 0x2 : 0) | (peer != null ? 0x1 : 0)),
				peer = peer,
			});

		/// <summary>Get info about a certain wallpaper		<para>See <a href="https://corefork.telegram.org/method/account.getWallPaper"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.getWallPaper#possible-errors">details</a>)</para></summary>
		/// <param name="wallpaper">The wallpaper to get info about</param>
		public static Task<WallPaperBase> Account_GetWallPaper(this Client client, InputWallPaperBase wallpaper)
			=> client.Invoke(new Account_GetWallPaper
			{
				wallpaper = wallpaper,
			});

		/// <summary>Create and upload a new wallpaper		<para>See <a href="https://corefork.telegram.org/method/account.uploadWallPaper"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.uploadWallPaper#possible-errors">details</a>)</para></summary>
		/// <param name="file">The JPG/PNG wallpaper</param>
		/// <param name="mime_type">MIME type of uploaded wallpaper</param>
		/// <param name="settings">Wallpaper settings</param>
		public static Task<WallPaperBase> Account_UploadWallPaper(this Client client, InputFileBase file, string mime_type, WallPaperSettings settings)
			=> client.Invoke(new Account_UploadWallPaper
			{
				file = file,
				mime_type = mime_type,
				settings = settings,
			});

		/// <summary>Install/uninstall wallpaper		<para>See <a href="https://corefork.telegram.org/method/account.saveWallPaper"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.saveWallPaper#possible-errors">details</a>)</para></summary>
		/// <param name="wallpaper">Wallpaper to save</param>
		/// <param name="unsave">Uninstall wallpaper?</param>
		/// <param name="settings">Wallpaper settings</param>
		public static Task<bool> Account_SaveWallPaper(this Client client, InputWallPaperBase wallpaper, bool unsave, WallPaperSettings settings)
			=> client.Invoke(new Account_SaveWallPaper
			{
				wallpaper = wallpaper,
				unsave = unsave,
				settings = settings,
			});

		/// <summary>Install wallpaper		<para>See <a href="https://corefork.telegram.org/method/account.installWallPaper"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.installWallPaper#possible-errors">details</a>)</para></summary>
		/// <param name="wallpaper">Wallpaper to install</param>
		/// <param name="settings">Wallpaper settings</param>
		public static Task<bool> Account_InstallWallPaper(this Client client, InputWallPaperBase wallpaper, WallPaperSettings settings)
			=> client.Invoke(new Account_InstallWallPaper
			{
				wallpaper = wallpaper,
				settings = settings,
			});

		/// <summary>Delete installed wallpapers		<para>See <a href="https://corefork.telegram.org/method/account.resetWallPapers"/></para></summary>
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
		/// <param name="file">Theme file uploaded as described in <a href="https://corefork.telegram.org/api/files">files »</a></param>
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
		/// <param name="slug">Unique theme ID</param>
		/// <param name="title">Theme name</param>
		/// <param name="document">Theme file</param>
		/// <param name="settings">Theme settings</param>
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

		/// <summary>Save a theme		<para>See <a href="https://corefork.telegram.org/method/account.saveTheme"/></para></summary>
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
		public static Task<bool> Account_InstallTheme(this Client client, bool dark = false, InputThemeBase theme = null, string format = null, BaseTheme base_theme = default)
			=> client.Invoke(new Account_InstallTheme
			{
				flags = (Account_InstallTheme.Flags)((dark ? 0x1 : 0) | (theme != null ? 0x2 : 0) | (format != null ? 0x4 : 0) | (base_theme != default ? 0x8 : 0)),
				theme = theme,
				format = format,
				base_theme = base_theme,
			});

		/// <summary>Get theme information		<para>See <a href="https://corefork.telegram.org/method/account.getTheme"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.getTheme#possible-errors">details</a>)</para></summary>
		/// <param name="format">Theme format, a string that identifies the theming engines supported by the client</param>
		/// <param name="theme">Theme</param>
		/// <param name="document_id">Document ID</param>
		public static Task<Theme> Account_GetTheme(this Client client, string format, InputThemeBase theme, long document_id)
			=> client.Invoke(new Account_GetTheme
			{
				format = format,
				theme = theme,
				document_id = document_id,
			});

		/// <summary>Get installed themes		<para>See <a href="https://corefork.telegram.org/method/account.getThemes"/></para></summary>
		/// <param name="format">Theme format, a string that identifies the theming engines supported by the client</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
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

		/// <summary>Get info about multiple wallpapers		<para>See <a href="https://corefork.telegram.org/method/account.getMultiWallPapers"/></para></summary>
		/// <param name="wallpapers">Wallpapers to fetch info about</param>
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

		/// <summary>Set global privacy settings		<para>See <a href="https://corefork.telegram.org/method/account.setGlobalPrivacySettings"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.setGlobalPrivacySettings#possible-errors">details</a>)</para></summary>
		/// <param name="settings">Global privacy settings</param>
		public static Task<GlobalPrivacySettings> Account_SetGlobalPrivacySettings(this Client client, GlobalPrivacySettings settings)
			=> client.Invoke(new Account_SetGlobalPrivacySettings
			{
				settings = settings,
			});

		/// <summary>Report a profile photo of a dialog		<para>See <a href="https://corefork.telegram.org/method/account.reportProfilePhoto"/></para></summary>
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

		/// <summary>Initiate a 2FA password reset: can only be used if the user is already logged-in, <a href="https://corefork.telegram.org/api/srp#password-reset">see here for more info »</a>		<para>See <a href="https://corefork.telegram.org/method/account.resetPassword"/></para></summary>
		public static Task<Account_ResetPasswordResult> Account_ResetPassword(this Client client)
			=> client.Invoke(new Account_ResetPassword
			{
			});

		/// <summary>Abort a pending 2FA password reset, <a href="https://corefork.telegram.org/api/srp#password-reset">see here for more info »</a>		<para>See <a href="https://corefork.telegram.org/method/account.declinePasswordReset"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.declinePasswordReset#possible-errors">details</a>)</para></summary>
		public static Task<bool> Account_DeclinePasswordReset(this Client client)
			=> client.Invoke(new Account_DeclinePasswordReset
			{
			});

		/// <summary>Get all available chat themes		<para>See <a href="https://corefork.telegram.org/method/account.getChatThemes"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/account.themesNotModified">account.themesNotModified</a></returns>
		public static Task<Account_Themes> Account_GetChatThemes(this Client client, long hash = default)
			=> client.Invoke(new Account_GetChatThemes
			{
				hash = hash,
			});

		/// <summary>Set time-to-live of current session		<para>See <a href="https://corefork.telegram.org/method/account.setAuthorizationTTL"/></para>		<para>Possible <see cref="RpcException"/> codes: 406 (<a href="https://corefork.telegram.org/method/account.setAuthorizationTTL#possible-errors">details</a>)</para></summary>
		/// <param name="authorization_ttl_days">Time-to-live of current session in days</param>
		public static Task<bool> Account_SetAuthorizationTTL(this Client client, int authorization_ttl_days)
			=> client.Invoke(new Account_SetAuthorizationTTL
			{
				authorization_ttl_days = authorization_ttl_days,
			});

		/// <summary>Change authorization settings		<para>See <a href="https://corefork.telegram.org/method/account.changeAuthorizationSettings"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/account.changeAuthorizationSettings#possible-errors">details</a>)</para></summary>
		/// <param name="hash">Session ID from the <see cref="Authorization"/> constructor, fetchable using <a href="https://corefork.telegram.org/method/account.getAuthorizations">account.getAuthorizations</a></param>
		/// <param name="encrypted_requests_disabled">Whether to enable or disable receiving encrypted chats: if the flag is not set, the previous setting is not changed</param>
		/// <param name="call_requests_disabled">Whether to enable or disable receiving calls: if the flag is not set, the previous setting is not changed</param>
		public static Task<bool> Account_ChangeAuthorizationSettings(this Client client, long hash, bool? encrypted_requests_disabled = default, bool? call_requests_disabled = default)
			=> client.Invoke(new Account_ChangeAuthorizationSettings
			{
				flags = (Account_ChangeAuthorizationSettings.Flags)((encrypted_requests_disabled != default ? 0x1 : 0) | (call_requests_disabled != default ? 0x2 : 0)),
				hash = hash,
				encrypted_requests_disabled = encrypted_requests_disabled.GetValueOrDefault(),
				call_requests_disabled = call_requests_disabled.GetValueOrDefault(),
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/account.getSavedRingtones"/></para></summary>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/account.savedRingtonesNotModified">account.savedRingtonesNotModified</a></returns>
		public static Task<Account_SavedRingtones> Account_GetSavedRingtones(this Client client, long hash = default)
			=> client.Invoke(new Account_GetSavedRingtones
			{
				hash = hash,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/account.saveRingtone"/></para></summary>
		public static Task<Account_SavedRingtone> Account_SaveRingtone(this Client client, InputDocument id, bool unsave)
			=> client.Invoke(new Account_SaveRingtone
			{
				id = id,
				unsave = unsave,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/account.uploadRingtone"/></para></summary>
		public static Task<DocumentBase> Account_UploadRingtone(this Client client, InputFileBase file, string file_name, string mime_type)
			=> client.Invoke(new Account_UploadRingtone
			{
				file = file,
				file_name = file_name,
				mime_type = mime_type,
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

		/// <summary>Notify the user that the sent <a href="https://corefork.telegram.org/passport">passport</a> data contains some errors The user will not be able to re-submit their Passport data to you until the errors are fixed (the contents of the field for which you returned the error must change).		<para>See <a href="https://corefork.telegram.org/method/users.setSecureValueErrors"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/users.setSecureValueErrors#possible-errors">details</a>)</para></summary>
		/// <param name="id">The user</param>
		/// <param name="errors">Errors</param>
		public static Task<bool> Users_SetSecureValueErrors(this Client client, InputUserBase id, params SecureValueErrorBase[] errors)
			=> client.Invoke(new Users_SetSecureValueErrors
			{
				id = id,
				errors = errors,
			});

		/// <summary>Get contact by telegram IDs		<para>See <a href="https://corefork.telegram.org/method/contacts.getContactIDs"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		public static Task<int[]> Contacts_GetContactIDs(this Client client, long hash = default)
			=> client.Invoke(new Contacts_GetContactIDs
			{
				hash = hash,
			});

		/// <summary>Returns the list of contact statuses.		<para>See <a href="https://corefork.telegram.org/method/contacts.getStatuses"/></para></summary>
		public static Task<ContactStatus[]> Contacts_GetStatuses(this Client client)
			=> client.Invoke(new Contacts_GetStatuses
			{
			});

		/// <summary>Returns the current user's contact list.		<para>See <a href="https://corefork.telegram.org/method/contacts.getContacts"/></para></summary>
		/// <param name="hash">If there already is a full contact list on the client, a <a href="https://corefork.telegram.org/api/offsets#hash-generation">hash</a> of a the list of contact IDs in ascending order may be passed in this parameter. If the contact set was not changed, <see langword="null"/> will be returned.</param>
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

		/// <summary>Deletes several contacts from the list.		<para>See <a href="https://corefork.telegram.org/method/contacts.deleteContacts"/></para></summary>
		/// <param name="id">User ID list</param>
		public static Task<UpdatesBase> Contacts_DeleteContacts(this Client client, params InputUserBase[] id)
			=> client.Invoke(new Contacts_DeleteContacts
			{
				id = id,
			});

		/// <summary>Delete contacts by phone number		<para>See <a href="https://corefork.telegram.org/method/contacts.deleteByPhones"/></para></summary>
		/// <param name="phones">Phone numbers</param>
		public static Task<bool> Contacts_DeleteByPhones(this Client client, string[] phones)
			=> client.Invoke(new Contacts_DeleteByPhones
			{
				phones = phones,
			});

		/// <summary>Adds the user to the blacklist.		<para>See <a href="https://corefork.telegram.org/method/contacts.block"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/contacts.block#possible-errors">details</a>)</para></summary>
		/// <param name="id">User ID</param>
		public static Task<bool> Contacts_Block(this Client client, InputPeer id)
			=> client.Invoke(new Contacts_Block
			{
				id = id,
			});

		/// <summary>Deletes the user from the blacklist.		<para>See <a href="https://corefork.telegram.org/method/contacts.unblock"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/contacts.unblock#possible-errors">details</a>)</para></summary>
		/// <param name="id">User ID</param>
		public static Task<bool> Contacts_Unblock(this Client client, InputPeer id)
			=> client.Invoke(new Contacts_Unblock
			{
				id = id,
			});

		/// <summary>Returns the list of blocked users.		<para>See <a href="https://corefork.telegram.org/method/contacts.getBlocked"/></para></summary>
		/// <param name="offset">The number of list elements to be skipped</param>
		/// <param name="limit">The number of list elements to be returned</param>
		public static Task<Contacts_Blocked> Contacts_GetBlocked(this Client client, int offset = default, int limit = int.MaxValue)
			=> client.Invoke(new Contacts_GetBlocked
			{
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
		public static Task<Contacts_ResolvedPeer> Contacts_ResolveUsername(this Client client, string username)
			=> client.Invoke(new Contacts_ResolveUsername
			{
				username = username,
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
		/// <param name="offset">Offset for <a href="https://corefork.telegram.org/api/offsets">pagination</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/contacts.topPeersNotModified">contacts.topPeersNotModified</a></returns>
		public static Task<Contacts_TopPeersBase> Contacts_GetTopPeers(this Client client, int offset = default, int limit = int.MaxValue, long hash = default, bool correspondents = false, bool bots_pm = false, bool bots_inline = false, bool phone_calls = false, bool forward_users = false, bool forward_chats = false, bool groups = false, bool channels = false)
			=> client.Invoke(new Contacts_GetTopPeers
			{
				flags = (Contacts_GetTopPeers.Flags)((correspondents ? 0x1 : 0) | (bots_pm ? 0x2 : 0) | (bots_inline ? 0x4 : 0) | (phone_calls ? 0x8 : 0) | (forward_users ? 0x10 : 0) | (forward_chats ? 0x20 : 0) | (groups ? 0x400 : 0) | (channels ? 0x8000 : 0)),
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

		/// <summary>Delete saved contacts		<para>See <a href="https://corefork.telegram.org/method/contacts.resetSaved"/></para></summary>
		public static Task<bool> Contacts_ResetSaved(this Client client)
			=> client.Invoke(new Contacts_ResetSaved
			{
			});

		/// <summary>Get all contacts		<para>See <a href="https://corefork.telegram.org/method/contacts.getSaved"/></para>		<para>Possible <see cref="RpcException"/> codes: 403 (<a href="https://corefork.telegram.org/method/contacts.getSaved#possible-errors">details</a>)</para></summary>
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
		/// <param name="phone">User's phone number</param>
		public static Task<UpdatesBase> Contacts_AddContact(this Client client, InputUserBase id, string first_name, string last_name, string phone, bool add_phone_privacy_exception = false)
			=> client.Invoke(new Contacts_AddContact
			{
				flags = (Contacts_AddContact.Flags)(add_phone_privacy_exception ? 0x1 : 0),
				id = id,
				first_name = first_name,
				last_name = last_name,
				phone = phone,
			});

		/// <summary>If the <see cref="PeerSettings"/> of a new user allow us to add them as contact, add that user as contact		<para>See <a href="https://corefork.telegram.org/method/contacts.acceptContact"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/contacts.acceptContact#possible-errors">details</a>)</para></summary>
		/// <param name="id">The user to add as contact</param>
		public static Task<UpdatesBase> Contacts_AcceptContact(this Client client, InputUserBase id)
			=> client.Invoke(new Contacts_AcceptContact
			{
				id = id,
			});

		/// <summary>Get contacts near you		<para>See <a href="https://corefork.telegram.org/method/contacts.getLocated"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/contacts.getLocated#possible-errors">details</a>)</para></summary>
		/// <param name="background">While the geolocation of the current user is public, clients should update it in the background every half-an-hour or so, while setting this flag. <br/>Do this only if the new location is more than 1 KM away from the previous one, or if the previous location is unknown.</param>
		/// <param name="geo_point">Geolocation</param>
		/// <param name="self_expires">If set, the geolocation of the current user will be public for the specified number of seconds; pass 0x7fffffff to disable expiry, 0 to make the current geolocation private; if the flag isn't set, no changes will be applied.</param>
		public static Task<UpdatesBase> Contacts_GetLocated(this Client client, InputGeoPoint geo_point, bool background = false, int? self_expires = null)
			=> client.Invoke(new Contacts_GetLocated
			{
				flags = (Contacts_GetLocated.Flags)((background ? 0x2 : 0) | (self_expires != null ? 0x1 : 0)),
				geo_point = geo_point,
				self_expires = self_expires.GetValueOrDefault(),
			});

		/// <summary>Stop getting notifications about <a href="https://corefork.telegram.org/api/threads">thread replies</a> of a certain user in <c>@replies</c>		<para>See <a href="https://corefork.telegram.org/method/contacts.blockFromReplies"/></para></summary>
		/// <param name="delete_message">Whether to delete the specified message as well</param>
		/// <param name="delete_history">Whether to delete all <c>@replies</c> messages from this user as well</param>
		/// <param name="report_spam">Whether to also report this user for spam</param>
		/// <param name="msg_id">ID of the message in the <a href="https://corefork.telegram.org/api/threads#replies">@replies</a> chat</param>
		public static Task<UpdatesBase> Contacts_BlockFromReplies(this Client client, int msg_id, bool delete_message = false, bool delete_history = false, bool report_spam = false)
			=> client.Invoke(new Contacts_BlockFromReplies
			{
				flags = (Contacts_BlockFromReplies.Flags)((delete_message ? 0x1 : 0) | (delete_history ? 0x2 : 0) | (report_spam ? 0x4 : 0)),
				msg_id = msg_id,
			});

		/// <summary>Resolve a phone number to get user info, if their privacy settings allow it.		<para>See <a href="https://corefork.telegram.org/method/contacts.resolvePhone"/></para></summary>
		/// <param name="phone">Phone number in international format, possibly obtained from a <c>t.me/+number</c> or <c>tg://resolve?phone=number</c> URI.</param>
		public static Task<Contacts_ResolvedPeer> Contacts_ResolvePhone(this Client client, string phone)
			=> client.Invoke(new Contacts_ResolvePhone
			{
				phone = phone,
			});

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/README.md#terminology">Terminology</see> to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Returns the list of messages by their IDs.		<para>See <a href="https://corefork.telegram.org/method/messages.getMessages"/> [bots: ✓]</para></summary>
		/// <param name="id">Message ID list</param>
		public static Task<Messages_MessagesBase> Messages_GetMessages(this Client client, params InputMessage[] id)
			=> client.Invoke(new Messages_GetMessages
			{
				id = id,
			});

		/// <summary>Returns the current user dialog list.		<para>See <a href="https://corefork.telegram.org/method/messages.getDialogs"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getDialogs#possible-errors">details</a>)</para></summary>
		/// <param name="exclude_pinned">Exclude pinned dialogs</param>
		/// <param name="folder_id"><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></param>
		/// <param name="offset_date"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="offset_peer"><a href="https://corefork.telegram.org/api/offsets">Offset peer for pagination</a></param>
		/// <param name="limit">Number of list elements to be returned</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		public static Task<Messages_DialogsBase> Messages_GetDialogs(this Client client, DateTime offset_date = default, int offset_id = default, InputPeer offset_peer = null, int limit = int.MaxValue, long hash = default, bool exclude_pinned = false, int? folder_id = null)
			=> client.Invoke(new Messages_GetDialogs
			{
				flags = (Messages_GetDialogs.Flags)((exclude_pinned ? 0x1 : 0) | (folder_id != null ? 0x2 : 0)),
				folder_id = folder_id.GetValueOrDefault(),
				offset_date = offset_date,
				offset_id = offset_id,
				offset_peer = offset_peer,
				limit = limit,
				hash = hash,
			});

		/// <summary>Gets back the conversation history with one interlocutor / within a chat		<para>See <a href="https://corefork.telegram.org/method/messages.getHistory"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getHistory#possible-errors">details</a>)</para></summary>
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

		/// <summary>Gets back found messages		<para>See <a href="https://corefork.telegram.org/method/messages.search"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.search#possible-errors">details</a>)</para></summary>
		/// <param name="peer">User or chat, histories with which are searched, or <see langword="null"/> constructor for global search</param>
		/// <param name="q">Text search request</param>
		/// <param name="from_id">Only return messages sent by the specified user ID</param>
		/// <param name="top_msg_id"><a href="https://corefork.telegram.org/api/threads">Thread ID</a></param>
		/// <param name="filter">Filter to return only specified message types</param>
		/// <param name="min_date">If a positive value was transferred, only messages with a sending date bigger than the transferred one will be returned</param>
		/// <param name="max_date">If a positive value was transferred, only messages with a sending date smaller than the transferred one will be returned</param>
		/// <param name="offset_id">Only return messages starting from the specified message ID</param>
		/// <param name="add_offset"><a href="https://corefork.telegram.org/api/offsets">Additional offset</a></param>
		/// <param name="limit"><a href="https://corefork.telegram.org/api/offsets">Number of results to return</a></param>
		/// <param name="max_id"><a href="https://corefork.telegram.org/api/offsets">Maximum message ID to return</a></param>
		/// <param name="min_id"><a href="https://corefork.telegram.org/api/offsets">Minimum message ID to return</a></param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets">Hash</a></param>
		public static Task<Messages_MessagesBase> Messages_Search(this Client client, InputPeer peer, string q, MessagesFilter filter, DateTime min_date = default, DateTime max_date = default, int offset_id = default, int add_offset = default, int limit = int.MaxValue, int max_id = default, int min_id = default, long hash = default, InputPeer from_id = null, int? top_msg_id = null)
			=> client.Invoke(new Messages_Search
			{
				flags = (Messages_Search.Flags)((from_id != null ? 0x1 : 0) | (top_msg_id != null ? 0x2 : 0)),
				peer = peer,
				q = q,
				from_id = from_id,
				top_msg_id = top_msg_id.GetValueOrDefault(),
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
			=> client.Invoke(new Messages_ReadHistory
			{
				peer = peer,
				max_id = max_id,
			});

		/// <summary>Deletes communication history.		<para>See <a href="https://corefork.telegram.org/method/messages.deleteHistory"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.deleteHistory#possible-errors">details</a>)</para></summary>
		/// <param name="just_clear">Just clear history for the current user, without actually removing messages for every chat user</param>
		/// <param name="revoke">Whether to delete the message history for all chat participants</param>
		/// <param name="peer">User or chat, communication history of which will be deleted</param>
		/// <param name="max_id">Maximum ID of message to delete</param>
		/// <param name="min_date">Delete all messages newer than this UNIX timestamp</param>
		/// <param name="max_date">Delete all messages older than this UNIX timestamp</param>
		public static Task<Messages_AffectedHistory> Messages_DeleteHistory(this Client client, InputPeer peer, int max_id = default, bool just_clear = false, bool revoke = false, DateTime? min_date = null, DateTime? max_date = null)
			=> client.Invoke(new Messages_DeleteHistory
			{
				flags = (Messages_DeleteHistory.Flags)((just_clear ? 0x1 : 0) | (revoke ? 0x2 : 0) | (min_date != null ? 0x4 : 0) | (max_date != null ? 0x8 : 0)),
				peer = peer,
				max_id = max_id,
				min_date = min_date.GetValueOrDefault(),
				max_date = max_date.GetValueOrDefault(),
			});

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/README.md#terminology">Terminology</see> to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Deletes messages by their identifiers.		<para>See <a href="https://corefork.telegram.org/method/messages.deleteMessages"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.deleteMessages#possible-errors">details</a>)</para></summary>
		/// <param name="revoke">Whether to delete messages for all participants of the chat</param>
		/// <param name="id">Message ID list</param>
		public static Task<Messages_AffectedMessages> Messages_DeleteMessages(this Client client, int[] id, bool revoke = false)
			=> client.Invoke(new Messages_DeleteMessages
			{
				flags = (Messages_DeleteMessages.Flags)(revoke ? 0x1 : 0),
				id = id,
			});

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/README.md#terminology">Terminology</see> to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Confirms receipt of messages by a client, cancels PUSH-notification sending.		<para>See <a href="https://corefork.telegram.org/method/messages.receivedMessages"/></para></summary>
		/// <param name="max_id">Maximum message ID available in a client.</param>
		public static Task<ReceivedNotifyMessage[]> Messages_ReceivedMessages(this Client client, int max_id = default)
			=> client.Invoke(new Messages_ReceivedMessages
			{
				max_id = max_id,
			});

		/// <summary>Sends a current user typing event (see <see cref="SendMessageAction"/> for all event types) to a conversation partner or group.		<para>See <a href="https://corefork.telegram.org/method/messages.setTyping"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.setTyping#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Target user or group</param>
		/// <param name="top_msg_id"><a href="https://corefork.telegram.org/api/threads">Thread ID</a></param>
		/// <param name="action">Type of action<br/>Parameter added in <a href="https://corefork.telegram.org/api/layers#layer-17">Layer 17</a>.</param>
		public static Task<bool> Messages_SetTyping(this Client client, InputPeer peer, SendMessageAction action, int? top_msg_id = null)
			=> client.Invoke(new Messages_SetTyping
			{
				flags = (Messages_SetTyping.Flags)(top_msg_id != null ? 0x1 : 0),
				peer = peer,
				top_msg_id = top_msg_id.GetValueOrDefault(),
				action = action,
			});

		/// <summary>Sends a message to a chat		<para>See <a href="https://corefork.telegram.org/method/messages.sendMessage"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403,420,500 (<a href="https://corefork.telegram.org/method/messages.sendMessage#possible-errors">details</a>)</para></summary>
		/// <param name="no_webpage">Set this flag to disable generation of the webpage preview</param>
		/// <param name="silent">Send this message silently (no notifications for the receivers)</param>
		/// <param name="background">Send this message as background message</param>
		/// <param name="clear_draft">Clear the draft field</param>
		/// <param name="noforwards">Only for bots, disallows forwarding and saving of the messages, even if the destination chat doesn't have <a href="https://telegram.org/blog/protected-content-delete-by-date-and-more">content protection</a> enabled</param>
		/// <param name="peer">The destination where the message will be sent</param>
		/// <param name="reply_to_msg_id">The message ID to which this message will reply to</param>
		/// <param name="message">The message</param>
		/// <param name="random_id">Unique client message ID required to prevent message resending</param>
		/// <param name="reply_markup">Reply markup for sending bot buttons</param>
		/// <param name="entities">Message <a href="https://corefork.telegram.org/api/entities">entities</a> for sending styled text</param>
		/// <param name="schedule_date">Scheduled message date for <a href="https://corefork.telegram.org/api/scheduled-messages">scheduled messages</a></param>
		/// <param name="send_as">Send this message as the specified peer</param>
		public static Task<UpdatesBase> Messages_SendMessage(this Client client, InputPeer peer, string message, long random_id, bool no_webpage = false, bool silent = false, bool background = false, bool clear_draft = false, bool noforwards = false, int? reply_to_msg_id = null, ReplyMarkup reply_markup = null, MessageEntity[] entities = null, DateTime? schedule_date = null, InputPeer send_as = null)
			=> client.Invoke(new Messages_SendMessage
			{
				flags = (Messages_SendMessage.Flags)((no_webpage ? 0x2 : 0) | (silent ? 0x20 : 0) | (background ? 0x40 : 0) | (clear_draft ? 0x80 : 0) | (noforwards ? 0x4000 : 0) | (reply_to_msg_id != null ? 0x1 : 0) | (reply_markup != null ? 0x4 : 0) | (entities != null ? 0x8 : 0) | (schedule_date != null ? 0x400 : 0) | (send_as != null ? 0x2000 : 0)),
				peer = peer,
				reply_to_msg_id = reply_to_msg_id.GetValueOrDefault(),
				message = message,
				random_id = random_id,
				reply_markup = reply_markup,
				entities = entities,
				schedule_date = schedule_date.GetValueOrDefault(),
				send_as = send_as,
			});

		/// <summary>Send a media		<para>See <a href="https://corefork.telegram.org/method/messages.sendMedia"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403,420,500 (<a href="https://corefork.telegram.org/method/messages.sendMedia#possible-errors">details</a>)</para></summary>
		/// <param name="silent">Send message silently (no notification should be triggered)</param>
		/// <param name="background">Send message in background</param>
		/// <param name="clear_draft">Clear the draft</param>
		/// <param name="noforwards">Only for bots, disallows forwarding and saving of the messages, even if the destination chat doesn't have <a href="https://telegram.org/blog/protected-content-delete-by-date-and-more">content protection</a> enabled</param>
		/// <param name="peer">Destination</param>
		/// <param name="reply_to_msg_id">Message ID to which this message should reply to</param>
		/// <param name="media">Attached media</param>
		/// <param name="message">Caption</param>
		/// <param name="random_id">Random ID to avoid resending the same message</param>
		/// <param name="reply_markup">Reply markup for bot keyboards</param>
		/// <param name="entities">Message <a href="https://corefork.telegram.org/api/entities">entities</a> for styled text</param>
		/// <param name="schedule_date">Scheduled message date for <a href="https://corefork.telegram.org/api/scheduled-messages">scheduled messages</a></param>
		/// <param name="send_as">Send this message as the specified peer</param>
		public static Task<UpdatesBase> Messages_SendMedia(this Client client, InputPeer peer, InputMedia media, string message, long random_id, bool silent = false, bool background = false, bool clear_draft = false, bool noforwards = false, int? reply_to_msg_id = null, ReplyMarkup reply_markup = null, MessageEntity[] entities = null, DateTime? schedule_date = null, InputPeer send_as = null)
			=> client.Invoke(new Messages_SendMedia
			{
				flags = (Messages_SendMedia.Flags)((silent ? 0x20 : 0) | (background ? 0x40 : 0) | (clear_draft ? 0x80 : 0) | (noforwards ? 0x4000 : 0) | (reply_to_msg_id != null ? 0x1 : 0) | (reply_markup != null ? 0x4 : 0) | (entities != null ? 0x8 : 0) | (schedule_date != null ? 0x400 : 0) | (send_as != null ? 0x2000 : 0)),
				peer = peer,
				reply_to_msg_id = reply_to_msg_id.GetValueOrDefault(),
				media = media,
				message = message,
				random_id = random_id,
				reply_markup = reply_markup,
				entities = entities,
				schedule_date = schedule_date.GetValueOrDefault(),
				send_as = send_as,
			});

		/// <summary>Forwards messages by their IDs.		<para>See <a href="https://corefork.telegram.org/method/messages.forwardMessages"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403,406,420,500 (<a href="https://corefork.telegram.org/method/messages.forwardMessages#possible-errors">details</a>)</para></summary>
		/// <param name="silent">Whether to send messages silently (no notification will be triggered on the destination clients)</param>
		/// <param name="background">Whether to send the message in background</param>
		/// <param name="with_my_score">When forwarding games, whether to include your score in the game</param>
		/// <param name="drop_author">Whether to forward messages without quoting the original author</param>
		/// <param name="drop_media_captions">Whether to strip captions from media</param>
		/// <param name="noforwards">Only for bots, disallows further re-forwarding and saving of the messages, even if the destination chat doesn't have <a href="https://telegram.org/blog/protected-content-delete-by-date-and-more">content protection</a> enabled</param>
		/// <param name="from_peer">Source of messages</param>
		/// <param name="id">IDs of messages</param>
		/// <param name="random_id">Random ID to prevent resending of messages</param>
		/// <param name="to_peer">Destination peer</param>
		/// <param name="schedule_date">Scheduled message date for scheduled messages</param>
		/// <param name="send_as">Forward the messages as the specified peer</param>
		public static Task<UpdatesBase> Messages_ForwardMessages(this Client client, InputPeer from_peer, int[] id, long[] random_id, InputPeer to_peer, bool silent = false, bool background = false, bool with_my_score = false, bool drop_author = false, bool drop_media_captions = false, bool noforwards = false, DateTime? schedule_date = null, InputPeer send_as = null)
			=> client.Invoke(new Messages_ForwardMessages
			{
				flags = (Messages_ForwardMessages.Flags)((silent ? 0x20 : 0) | (background ? 0x40 : 0) | (with_my_score ? 0x100 : 0) | (drop_author ? 0x800 : 0) | (drop_media_captions ? 0x1000 : 0) | (noforwards ? 0x4000 : 0) | (schedule_date != null ? 0x400 : 0) | (send_as != null ? 0x2000 : 0)),
				from_peer = from_peer,
				id = id,
				random_id = random_id,
				to_peer = to_peer,
				schedule_date = schedule_date.GetValueOrDefault(),
				send_as = send_as,
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
		/// <param name="reason">Why are these messages being reported</param>
		/// <param name="message">Comment for report moderation</param>
		public static Task<bool> Messages_Report(this Client client, InputPeer peer, int[] id, ReportReason reason, string message)
			=> client.Invoke(new Messages_Report
			{
				peer = peer,
				id = id,
				reason = reason,
				message = message,
			});

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/README.md#terminology">Terminology</see> to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Returns chat basic info on their IDs.		<para>See <a href="https://corefork.telegram.org/method/messages.getChats"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getChats#possible-errors">details</a>)</para></summary>
		/// <param name="id">List of chat IDs</param>
		public static Task<Messages_Chats> Messages_GetChats(this Client client, long[] id)
			=> client.Invoke(new Messages_GetChats
			{
				id = id,
			});

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/README.md#terminology">Terminology</see> to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Get full info about a <a href="https://corefork.telegram.org/api/channel#basic-groups">basic group</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.getFullChat"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getFullChat#possible-errors">details</a>)</para></summary>
		/// <param name="chat_id"><a href="https://corefork.telegram.org/api/channel#basic-groups">Basic group</a> ID.</param>
		public static Task<Messages_ChatFull> Messages_GetFullChat(this Client client, long chat_id)
			=> client.Invoke(new Messages_GetFullChat
			{
				chat_id = chat_id,
			});

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/README.md#terminology">Terminology</see> to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Changes chat name and sends a service message on it.		<para>See <a href="https://corefork.telegram.org/method/messages.editChatTitle"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.editChatTitle#possible-errors">details</a>)</para></summary>
		/// <param name="chat_id">Chat ID</param>
		/// <param name="title">New chat name, different from the old one</param>
		public static Task<UpdatesBase> Messages_EditChatTitle(this Client client, long chat_id, string title)
			=> client.Invoke(new Messages_EditChatTitle
			{
				chat_id = chat_id,
				title = title,
			});

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/README.md#terminology">Terminology</see> to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Changes chat photo and sends a service message on it		<para>See <a href="https://corefork.telegram.org/method/messages.editChatPhoto"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.editChatPhoto#possible-errors">details</a>)</para></summary>
		/// <param name="chat_id">Chat ID</param>
		/// <param name="photo">Photo to be set</param>
		public static Task<UpdatesBase> Messages_EditChatPhoto(this Client client, long chat_id, InputChatPhotoBase photo)
			=> client.Invoke(new Messages_EditChatPhoto
			{
				chat_id = chat_id,
				photo = photo,
			});

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/README.md#terminology">Terminology</see> to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Adds a user to a chat and sends a service message on it.		<para>See <a href="https://corefork.telegram.org/method/messages.addChatUser"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.addChatUser#possible-errors">details</a>)</para></summary>
		/// <param name="chat_id">Chat ID</param>
		/// <param name="user_id">User ID to be added</param>
		/// <param name="fwd_limit">Number of last messages to be forwarded</param>
		public static Task<UpdatesBase> Messages_AddChatUser(this Client client, long chat_id, InputUserBase user_id, int fwd_limit)
			=> client.Invoke(new Messages_AddChatUser
			{
				chat_id = chat_id,
				user_id = user_id,
				fwd_limit = fwd_limit,
			});

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/README.md#terminology">Terminology</see> to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Deletes a user from a chat and sends a service message on it.		<para>See <a href="https://corefork.telegram.org/method/messages.deleteChatUser"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.deleteChatUser#possible-errors">details</a>)</para></summary>
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

		/// <summary>Creates a new chat.		<para>See <a href="https://corefork.telegram.org/method/messages.createChat"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403,500 (<a href="https://corefork.telegram.org/method/messages.createChat#possible-errors">details</a>)</para></summary>
		/// <param name="users">List of user IDs to be invited</param>
		/// <param name="title">Chat name</param>
		public static Task<UpdatesBase> Messages_CreateChat(this Client client, InputUserBase[] users, string title)
			=> client.Invoke(new Messages_CreateChat
			{
				users = users,
				title = title,
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
		/// <param name="typing">Typing.<br/><strong>Possible values</strong>:<br/><see cref="Bool.True"/>, if the user started typing and more than <strong>5 seconds</strong> have passed since the last request<br/><see cref="Bool.False"/>, if the user stopped typing</param>
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

		/// <summary>Sends a text message to a secret chat.		<para>See <a href="https://corefork.telegram.org/method/messages.sendEncrypted"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.sendEncrypted#possible-errors">details</a>)</para></summary>
		/// <param name="silent">Send encrypted message without a notification</param>
		/// <param name="peer">Secret chat ID</param>
		/// <param name="random_id">Unique client message ID, necessary to avoid message resending</param>
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
		/// <param name="random_id">Unique client message ID necessary to prevent message resending</param>
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

		/// <summary>Sends a service message to a secret chat.		<para>See <a href="https://corefork.telegram.org/method/messages.sendEncryptedService"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.sendEncryptedService#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Secret chat ID</param>
		/// <param name="random_id">Unique client message ID required to prevent message resending</param>
		/// <param name="data">TL-serialization of  <see cref="DecryptedMessageBase"/> type, encrypted with a key generated during chat initialization</param>
		public static Task<Messages_SentEncryptedMessage> Messages_SendEncryptedService(this Client client, InputEncryptedChat peer, long random_id, byte[] data)
			=> client.Invoke(new Messages_SendEncryptedService
			{
				peer = peer,
				random_id = random_id,
				data = data,
			});

		/// <summary>Confirms receipt of messages in a secret chat by client, cancels push notifications.		<para>See <a href="https://corefork.telegram.org/method/messages.receivedQueue"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.receivedQueue#possible-errors">details</a>)</para></summary>
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

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/README.md#terminology">Terminology</see> to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Notifies the sender about the recipient having listened a voice message or watched a video.		<para>See <a href="https://corefork.telegram.org/method/messages.readMessageContents"/></para></summary>
		/// <param name="id">Message ID list</param>
		public static Task<Messages_AffectedMessages> Messages_ReadMessageContents(this Client client, int[] id)
			=> client.Invoke(new Messages_ReadMessageContents
			{
				id = id,
			});

		/// <summary>Get stickers by emoji		<para>See <a href="https://corefork.telegram.org/method/messages.getStickers"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getStickers#possible-errors">details</a>)</para></summary>
		/// <param name="emoticon">The emoji</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.stickersNotModified">messages.stickersNotModified</a></returns>
		public static Task<Messages_Stickers> Messages_GetStickers(this Client client, string emoticon, long hash = default)
			=> client.Invoke(new Messages_GetStickers
			{
				emoticon = emoticon,
				hash = hash,
			});

		/// <summary>Get all installed stickers		<para>See <a href="https://corefork.telegram.org/method/messages.getAllStickers"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.allStickersNotModified">messages.allStickersNotModified</a></returns>
		public static Task<Messages_AllStickers> Messages_GetAllStickers(this Client client, long hash = default)
			=> client.Invoke(new Messages_GetAllStickers
			{
				hash = hash,
			});

		/// <summary>Get preview of webpage		<para>See <a href="https://corefork.telegram.org/method/messages.getWebPagePreview"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getWebPagePreview#possible-errors">details</a>)</para></summary>
		/// <param name="message">Message from which to extract the preview</param>
		/// <param name="entities"><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messageMediaEmpty">messageMediaEmpty</a></returns>
		public static Task<MessageMedia> Messages_GetWebPagePreview(this Client client, string message, MessageEntity[] entities = null)
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
		public static Task<ExportedChatInvite> Messages_ExportChatInvite(this Client client, InputPeer peer, bool legacy_revoke_permanent = false, bool request_needed = false, DateTime? expire_date = null, int? usage_limit = null, string title = null)
			=> client.Invoke(new Messages_ExportChatInvite
			{
				flags = (Messages_ExportChatInvite.Flags)((legacy_revoke_permanent ? 0x4 : 0) | (request_needed ? 0x8 : 0) | (expire_date != null ? 0x1 : 0) | (usage_limit != null ? 0x2 : 0) | (title != null ? 0x10 : 0)),
				peer = peer,
				expire_date = expire_date.GetValueOrDefault(),
				usage_limit = usage_limit.GetValueOrDefault(),
				title = title,
			});

		/// <summary>Check the validity of a chat invite link and get basic info about it		<para>See <a href="https://corefork.telegram.org/method/messages.checkChatInvite"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/messages.checkChatInvite#possible-errors">details</a>)</para></summary>
		/// <param name="hash">Invite hash in <c>t.me/joinchat/hash</c> or <c>t.me/+hash</c></param>
		public static Task<ChatInviteBase> Messages_CheckChatInvite(this Client client, string hash)
			=> client.Invoke(new Messages_CheckChatInvite
			{
				hash = hash,
			});

		/// <summary>Import a chat invite and join a private chat/supergroup/channel		<para>See <a href="https://corefork.telegram.org/method/messages.importChatInvite"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/messages.importChatInvite#possible-errors">details</a>)</para></summary>
		/// <param name="hash"><c>hash</c> from <c>t.me/joinchat/hash</c></param>
		public static Task<UpdatesBase> Messages_ImportChatInvite(this Client client, string hash)
			=> client.Invoke(new Messages_ImportChatInvite
			{
				hash = hash,
			});

		/// <summary>Get info about a stickerset		<para>See <a href="https://corefork.telegram.org/method/messages.getStickerSet"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 406 (<a href="https://corefork.telegram.org/method/messages.getStickerSet#possible-errors">details</a>)</para></summary>
		/// <param name="stickerset">Stickerset</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.stickerSetNotModified">messages.stickerSetNotModified</a></returns>
		public static Task<Messages_StickerSet> Messages_GetStickerSet(this Client client, InputStickerSet stickerset, int hash = default)
			=> client.Invoke(new Messages_GetStickerSet
			{
				stickerset = stickerset,
				hash = hash,
			});

		/// <summary>Install a stickerset		<para>See <a href="https://corefork.telegram.org/method/messages.installStickerSet"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.installStickerSet#possible-errors">details</a>)</para></summary>
		/// <param name="stickerset">Stickerset to install</param>
		/// <param name="archived">Whether to archive stickerset</param>
		public static Task<Messages_StickerSetInstallResult> Messages_InstallStickerSet(this Client client, InputStickerSet stickerset, bool archived)
			=> client.Invoke(new Messages_InstallStickerSet
			{
				stickerset = stickerset,
				archived = archived,
			});

		/// <summary>Uninstall a stickerset		<para>See <a href="https://corefork.telegram.org/method/messages.uninstallStickerSet"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.uninstallStickerSet#possible-errors">details</a>)</para></summary>
		/// <param name="stickerset">The stickerset to uninstall</param>
		public static Task<bool> Messages_UninstallStickerSet(this Client client, InputStickerSet stickerset)
			=> client.Invoke(new Messages_UninstallStickerSet
			{
				stickerset = stickerset,
			});

		/// <summary>Start a conversation with a bot using a <a href="https://corefork.telegram.org/bots#deep-linking">deep linking parameter</a>		<para>See <a href="https://corefork.telegram.org/method/messages.startBot"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,500 (<a href="https://corefork.telegram.org/method/messages.startBot#possible-errors">details</a>)</para></summary>
		/// <param name="bot">The bot</param>
		/// <param name="peer">The chat where to start the bot, can be the bot's private chat or a group</param>
		/// <param name="random_id">Random ID to avoid resending the same message</param>
		/// <param name="start_param"><a href="https://corefork.telegram.org/bots#deep-linking">Deep linking parameter</a></param>
		public static Task<UpdatesBase> Messages_StartBot(this Client client, InputUserBase bot, InputPeer peer, long random_id, string start_param)
			=> client.Invoke(new Messages_StartBot
			{
				bot = bot,
				peer = peer,
				random_id = random_id,
				start_param = start_param,
			});

		/// <summary>Get and increase the view counter of a message sent or forwarded from a <a href="https://corefork.telegram.org/api/channel">channel</a>		<para>See <a href="https://corefork.telegram.org/method/messages.getMessagesViews"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getMessagesViews#possible-errors">details</a>)</para></summary>
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

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/README.md#terminology">Terminology</see> to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Make a user admin in a <a href="https://corefork.telegram.org/api/channel#basic-groups">basic group</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.editChatAdmin"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.editChatAdmin#possible-errors">details</a>)</para></summary>
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

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/README.md#terminology">Terminology</see> to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Turn a <a href="https://corefork.telegram.org/api/channel#migration">basic group into a supergroup</a>		<para>See <a href="https://corefork.telegram.org/method/messages.migrateChat"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.migrateChat#possible-errors">details</a>)</para></summary>
		/// <param name="chat_id"><a href="https://corefork.telegram.org/api/channel#basic-groups">Basic group</a> to migrate</param>
		public static Task<UpdatesBase> Messages_MigrateChat(this Client client, long chat_id)
			=> client.Invoke(new Messages_MigrateChat
			{
				chat_id = chat_id,
			});

		/// <summary>Search for messages and peers globally		<para>See <a href="https://corefork.telegram.org/method/messages.searchGlobal"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.searchGlobal#possible-errors">details</a>)</para></summary>
		/// <param name="folder_id"><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></param>
		/// <param name="q">Query</param>
		/// <param name="filter">Global search filter</param>
		/// <param name="min_date">If a positive value was specified, the method will return only messages with date bigger than min_date</param>
		/// <param name="max_date">If a positive value was transferred, the method will return only messages with date smaller than max_date</param>
		/// <param name="offset_rate">Initially 0, then set to the <see cref="Messages_MessagesSlice"/></param>
		/// <param name="offset_peer"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="limit"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		public static Task<Messages_MessagesBase> Messages_SearchGlobal(this Client client, string q, MessagesFilter filter, DateTime min_date = default, DateTime max_date = default, int offset_rate = default, InputPeer offset_peer = null, int offset_id = default, int limit = int.MaxValue, int? folder_id = null)
			=> client.Invoke(new Messages_SearchGlobal
			{
				flags = (Messages_SearchGlobal.Flags)(folder_id != null ? 0x1 : 0),
				folder_id = folder_id.GetValueOrDefault(),
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
		/// <param name="order">New stickerset order by stickerset IDs</param>
		public static Task<bool> Messages_ReorderStickerSets(this Client client, long[] order, bool masks = false)
			=> client.Invoke(new Messages_ReorderStickerSets
			{
				flags = (Messages_ReorderStickerSets.Flags)(masks ? 0x1 : 0),
				order = order,
			});

		/// <summary>Get a document by its SHA256 hash, mainly used for gifs		<para>See <a href="https://corefork.telegram.org/method/messages.getDocumentByHash"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getDocumentByHash#possible-errors">details</a>)</para></summary>
		/// <param name="sha256">SHA256 of file</param>
		/// <param name="size">Size of the file in bytes</param>
		/// <param name="mime_type">Mime type</param>
		public static Task<DocumentBase> Messages_GetDocumentByHash(this Client client, byte[] sha256, int size, string mime_type)
			=> client.Invoke(new Messages_GetDocumentByHash
			{
				sha256 = sha256,
				size = size,
				mime_type = mime_type,
			});

		/// <summary>Get saved GIFs		<para>See <a href="https://corefork.telegram.org/method/messages.getSavedGifs"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
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

		/// <summary>Query an inline bot		<para>See <a href="https://corefork.telegram.org/method/messages.getInlineBotResults"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,-503 (<a href="https://corefork.telegram.org/method/messages.getInlineBotResults#possible-errors">details</a>)</para></summary>
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
		/// <param name="switch_pm">If passed, clients will display a button with specified text that switches the user to a private chat with the bot and sends the bot a start message with a certain parameter.</param>
		public static Task<bool> Messages_SetInlineBotResults(this Client client, long query_id, InputBotInlineResultBase[] results, DateTime cache_time, bool gallery = false, bool private_ = false, string next_offset = null, InlineBotSwitchPM switch_pm = null)
			=> client.Invoke(new Messages_SetInlineBotResults
			{
				flags = (Messages_SetInlineBotResults.Flags)((gallery ? 0x1 : 0) | (private_ ? 0x2 : 0) | (next_offset != null ? 0x4 : 0) | (switch_pm != null ? 0x8 : 0)),
				query_id = query_id,
				results = results,
				cache_time = cache_time,
				next_offset = next_offset,
				switch_pm = switch_pm,
			});

		/// <summary>Send a result obtained using <a href="https://corefork.telegram.org/method/messages.getInlineBotResults">messages.getInlineBotResults</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.sendInlineBotResult"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403,420,500 (<a href="https://corefork.telegram.org/method/messages.sendInlineBotResult#possible-errors">details</a>)</para></summary>
		/// <param name="silent">Whether to send the message silently (no notification will be triggered on the other client)</param>
		/// <param name="background">Whether to send the message in background</param>
		/// <param name="clear_draft">Whether to clear the <a href="https://corefork.telegram.org/api/drafts">draft</a></param>
		/// <param name="hide_via">Whether to hide the <c>via @botname</c> in the resulting message (only for bot usernames encountered in the <see cref="Config"/>)</param>
		/// <param name="peer">Destination</param>
		/// <param name="reply_to_msg_id">ID of the message this message should reply to</param>
		/// <param name="random_id">Random ID to avoid resending the same query</param>
		/// <param name="query_id">Query ID from <a href="https://corefork.telegram.org/method/messages.getInlineBotResults">messages.getInlineBotResults</a></param>
		/// <param name="id">Result ID from <a href="https://corefork.telegram.org/method/messages.getInlineBotResults">messages.getInlineBotResults</a></param>
		/// <param name="schedule_date">Scheduled message date for scheduled messages</param>
		/// <param name="send_as">Send this message as the specified peer</param>
		public static Task<UpdatesBase> Messages_SendInlineBotResult(this Client client, InputPeer peer, long random_id, long query_id, string id, bool silent = false, bool background = false, bool clear_draft = false, bool hide_via = false, int? reply_to_msg_id = null, DateTime? schedule_date = null, InputPeer send_as = null)
			=> client.Invoke(new Messages_SendInlineBotResult
			{
				flags = (Messages_SendInlineBotResult.Flags)((silent ? 0x20 : 0) | (background ? 0x40 : 0) | (clear_draft ? 0x80 : 0) | (hide_via ? 0x800 : 0) | (reply_to_msg_id != null ? 0x1 : 0) | (schedule_date != null ? 0x400 : 0) | (send_as != null ? 0x2000 : 0)),
				peer = peer,
				reply_to_msg_id = reply_to_msg_id.GetValueOrDefault(),
				random_id = random_id,
				query_id = query_id,
				id = id,
				schedule_date = schedule_date.GetValueOrDefault(),
				send_as = send_as,
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

		/// <summary>Edit message		<para>See <a href="https://corefork.telegram.org/method/messages.editMessage"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.editMessage#possible-errors">details</a>)</para></summary>
		/// <param name="no_webpage">Disable webpage preview</param>
		/// <param name="peer">Where was the message sent</param>
		/// <param name="id">ID of the message to edit</param>
		/// <param name="message">New message</param>
		/// <param name="media">New attached media</param>
		/// <param name="reply_markup">Reply markup for inline keyboards</param>
		/// <param name="entities"><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></param>
		/// <param name="schedule_date">Scheduled message date for <a href="https://corefork.telegram.org/api/scheduled-messages">scheduled messages</a></param>
		public static Task<UpdatesBase> Messages_EditMessage(this Client client, InputPeer peer, int id, bool no_webpage = false, string message = null, InputMedia media = null, ReplyMarkup reply_markup = null, MessageEntity[] entities = null, DateTime? schedule_date = null)
			=> client.Invoke(new Messages_EditMessage
			{
				flags = (Messages_EditMessage.Flags)((no_webpage ? 0x2 : 0) | (message != null ? 0x800 : 0) | (media != null ? 0x4000 : 0) | (reply_markup != null ? 0x4 : 0) | (entities != null ? 0x8 : 0) | (schedule_date != null ? 0x8000 : 0)),
				peer = peer,
				id = id,
				message = message,
				media = media,
				reply_markup = reply_markup,
				entities = entities,
				schedule_date = schedule_date.GetValueOrDefault(),
			});

		/// <summary>Edit an inline bot message		<para>See <a href="https://corefork.telegram.org/method/messages.editInlineBotMessage"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.editInlineBotMessage#possible-errors">details</a>)</para></summary>
		/// <param name="no_webpage">Disable webpage preview</param>
		/// <param name="id">Sent inline message ID</param>
		/// <param name="message">Message</param>
		/// <param name="media">Media</param>
		/// <param name="reply_markup">Reply markup for inline keyboards</param>
		/// <param name="entities"><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></param>
		public static Task<bool> Messages_EditInlineBotMessage(this Client client, InputBotInlineMessageIDBase id, bool no_webpage = false, string message = null, InputMedia media = null, ReplyMarkup reply_markup = null, MessageEntity[] entities = null)
			=> client.Invoke(new Messages_EditInlineBotMessage
			{
				flags = (Messages_EditInlineBotMessage.Flags)((no_webpage ? 0x2 : 0) | (message != null ? 0x800 : 0) | (media != null ? 0x4000 : 0) | (reply_markup != null ? 0x4 : 0) | (entities != null ? 0x8 : 0)),
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
		/// <param name="password">For buttons <see cref="KeyboardButtonCallback"/>, the SRP payload generated using <a href="https://corefork.telegram.org/api/srp">SRP</a>.</param>
		public static Task<Messages_BotCallbackAnswer> Messages_GetBotCallbackAnswer(this Client client, InputPeer peer, int msg_id, bool game = false, byte[] data = null, InputCheckPasswordSRP password = null)
			=> client.Invoke(new Messages_GetBotCallbackAnswer
			{
				flags = (Messages_GetBotCallbackAnswer.Flags)((game ? 0x2 : 0) | (data != null ? 0x1 : 0) | (password != null ? 0x4 : 0)),
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
		public static Task<bool> Messages_SetBotCallbackAnswer(this Client client, long query_id, DateTime cache_time, bool alert = false, string message = null, string url = null)
			=> client.Invoke(new Messages_SetBotCallbackAnswer
			{
				flags = (Messages_SetBotCallbackAnswer.Flags)((alert ? 0x2 : 0) | (message != null ? 0x1 : 0) | (url != null ? 0x4 : 0)),
				query_id = query_id,
				message = message,
				url = url,
				cache_time = cache_time,
			});

		/// <summary>Get dialog info of specified peers		<para>See <a href="https://corefork.telegram.org/method/messages.getPeerDialogs"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getPeerDialogs#possible-errors">details</a>)</para></summary>
		/// <param name="peers">Peers</param>
		public static Task<Messages_PeerDialogs> Messages_GetPeerDialogs(this Client client, params InputDialogPeerBase[] peers)
			=> client.Invoke(new Messages_GetPeerDialogs
			{
				peers = peers,
			});

		/// <summary>Save a message <a href="https://corefork.telegram.org/api/drafts">draft</a> associated to a chat.		<para>See <a href="https://corefork.telegram.org/method/messages.saveDraft"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.saveDraft#possible-errors">details</a>)</para></summary>
		/// <param name="no_webpage">Disable generation of the webpage preview</param>
		/// <param name="reply_to_msg_id">Message ID the message should reply to</param>
		/// <param name="peer">Destination of the message that should be sent</param>
		/// <param name="message">The draft</param>
		/// <param name="entities">Message <a href="https://corefork.telegram.org/api/entities">entities</a> for styled text</param>
		public static Task<bool> Messages_SaveDraft(this Client client, InputPeer peer, string message, bool no_webpage = false, int? reply_to_msg_id = null, MessageEntity[] entities = null)
			=> client.Invoke(new Messages_SaveDraft
			{
				flags = (Messages_SaveDraft.Flags)((no_webpage ? 0x2 : 0) | (reply_to_msg_id != null ? 0x1 : 0) | (entities != null ? 0x8 : 0)),
				reply_to_msg_id = reply_to_msg_id.GetValueOrDefault(),
				peer = peer,
				message = message,
				entities = entities,
			});

		/// <summary>Save get all message <a href="https://corefork.telegram.org/api/drafts">drafts</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.getAllDrafts"/></para></summary>
		public static Task<UpdatesBase> Messages_GetAllDrafts(this Client client)
			=> client.Invoke(new Messages_GetAllDrafts
			{
			});

		/// <summary>Get featured stickers		<para>See <a href="https://corefork.telegram.org/method/messages.getFeaturedStickers"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		public static Task<Messages_FeaturedStickersBase> Messages_GetFeaturedStickers(this Client client, long hash = default)
			=> client.Invoke(new Messages_GetFeaturedStickers
			{
				hash = hash,
			});

		/// <summary>Mark new featured stickers as read		<para>See <a href="https://corefork.telegram.org/method/messages.readFeaturedStickers"/></para></summary>
		/// <param name="id">IDs of stickersets to mark as read</param>
		public static Task<bool> Messages_ReadFeaturedStickers(this Client client, long[] id)
			=> client.Invoke(new Messages_ReadFeaturedStickers
			{
				id = id,
			});

		/// <summary>Get recent stickers		<para>See <a href="https://corefork.telegram.org/method/messages.getRecentStickers"/></para></summary>
		/// <param name="attached">Get stickers recently attached to photo or video files</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
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
		/// <param name="masks">Get mask stickers</param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Messages_ArchivedStickers> Messages_GetArchivedStickers(this Client client, long offset_id = default, int limit = int.MaxValue, bool masks = false)
			=> client.Invoke(new Messages_GetArchivedStickers
			{
				flags = (Messages_GetArchivedStickers.Flags)(masks ? 0x1 : 0),
				offset_id = offset_id,
				limit = limit,
			});

		/// <summary>Get installed mask stickers		<para>See <a href="https://corefork.telegram.org/method/messages.getMaskStickers"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.allStickersNotModified">messages.allStickersNotModified</a></returns>
		public static Task<Messages_AllStickers> Messages_GetMaskStickers(this Client client, long hash = default)
			=> client.Invoke(new Messages_GetMaskStickers
			{
				hash = hash,
			});

		/// <summary>Get stickers attached to a photo or video		<para>See <a href="https://corefork.telegram.org/method/messages.getAttachedStickers"/></para></summary>
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

		/// <summary>Get all chats, channels and supergroups		<para>See <a href="https://corefork.telegram.org/method/messages.getAllChats"/></para></summary>
		/// <param name="except_ids">Except these chats/channels/supergroups</param>
		public static Task<Messages_Chats> Messages_GetAllChats(this Client client, long[] except_ids = null)
			=> client.Invoke(new Messages_GetAllChats
			{
				except_ids = except_ids,
			});

		/// <summary>Get <a href="https://instantview.telegram.org">instant view</a> page		<para>See <a href="https://corefork.telegram.org/method/messages.getWebPage"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getWebPage#possible-errors">details</a>)</para></summary>
		/// <param name="url">URL of IV page to fetch</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		public static Task<WebPageBase> Messages_GetWebPage(this Client client, string url, int hash = default)
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
		public static Task<bool> Messages_SetBotPrecheckoutResults(this Client client, long query_id, bool success = false, string error = null)
			=> client.Invoke(new Messages_SetBotPrecheckoutResults
			{
				flags = (Messages_SetBotPrecheckoutResults.Flags)((success ? 0x2 : 0) | (error != null ? 0x1 : 0)),
				query_id = query_id,
				error = error,
			});

		/// <summary>Upload a file and associate it to a chat (without actually sending it to the chat)		<para>See <a href="https://corefork.telegram.org/method/messages.uploadMedia"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/messages.uploadMedia#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The chat, can be an <see langword="null"/> for bots</param>
		/// <param name="media">File uploaded in chunks as described in <a href="https://corefork.telegram.org/api/files">files »</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messageMediaEmpty">messageMediaEmpty</a></returns>
		public static Task<MessageMedia> Messages_UploadMedia(this Client client, InputPeer peer, InputMedia media)
			=> client.Invoke(new Messages_UploadMedia
			{
				peer = peer,
				media = media,
			});

		/// <summary>Notify the other user in a private chat that a screenshot of the chat was taken		<para>See <a href="https://corefork.telegram.org/method/messages.sendScreenshotNotification"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.sendScreenshotNotification#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Other user</param>
		/// <param name="reply_to_msg_id">ID of message that was screenshotted, can be 0</param>
		/// <param name="random_id">Random ID to avoid message resending</param>
		public static Task<UpdatesBase> Messages_SendScreenshotNotification(this Client client, InputPeer peer, int reply_to_msg_id, long random_id)
			=> client.Invoke(new Messages_SendScreenshotNotification
			{
				peer = peer,
				reply_to_msg_id = reply_to_msg_id,
				random_id = random_id,
			});

		/// <summary>Get faved stickers		<para>See <a href="https://corefork.telegram.org/method/messages.getFavedStickers"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
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
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="add_offset"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <param name="max_id">Maximum message ID to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <param name="min_id">Minimum message ID to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Messages_MessagesBase> Messages_GetUnreadMentions(this Client client, InputPeer peer, int offset_id = default, int add_offset = default, int limit = int.MaxValue, int max_id = default, int min_id = default)
			=> client.Invoke(new Messages_GetUnreadMentions
			{
				peer = peer,
				offset_id = offset_id,
				add_offset = add_offset,
				limit = limit,
				max_id = max_id,
				min_id = min_id,
			});

		/// <summary>Mark mentions as read		<para>See <a href="https://corefork.telegram.org/method/messages.readMentions"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.readMentions#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Dialog</param>
		public static Task<Messages_AffectedHistory> Messages_ReadMentions(this Client client, InputPeer peer)
			=> client.Invoke(new Messages_ReadMentions
			{
				peer = peer,
			});

		/// <summary>Get live location history of a certain user		<para>See <a href="https://corefork.telegram.org/method/messages.getRecentLocations"/></para></summary>
		/// <param name="peer">User</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
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
		/// <param name="peer">The destination chat</param>
		/// <param name="reply_to_msg_id">The message to reply to</param>
		/// <param name="multi_media">The medias to send</param>
		/// <param name="schedule_date">Scheduled message date for scheduled messages</param>
		/// <param name="send_as">Send this message as the specified peer</param>
		public static Task<UpdatesBase> Messages_SendMultiMedia(this Client client, InputPeer peer, InputSingleMedia[] multi_media, bool silent = false, bool background = false, bool clear_draft = false, bool noforwards = false, int? reply_to_msg_id = null, DateTime? schedule_date = null, InputPeer send_as = null)
			=> client.Invoke(new Messages_SendMultiMedia
			{
				flags = (Messages_SendMultiMedia.Flags)((silent ? 0x20 : 0) | (background ? 0x40 : 0) | (clear_draft ? 0x80 : 0) | (noforwards ? 0x4000 : 0) | (reply_to_msg_id != null ? 0x1 : 0) | (schedule_date != null ? 0x400 : 0) | (send_as != null ? 0x2000 : 0)),
				peer = peer,
				reply_to_msg_id = reply_to_msg_id.GetValueOrDefault(),
				multi_media = multi_media,
				schedule_date = schedule_date.GetValueOrDefault(),
				send_as = send_as,
			});

		/// <summary>Upload encrypted file and associate it to a secret chat		<para>See <a href="https://corefork.telegram.org/method/messages.uploadEncryptedFile"/></para></summary>
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
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
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
		public static Task<UpdatesBase> Messages_SendVote(this Client client, InputPeer peer, int msg_id, byte[][] options)
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

		/// <summary>Get localized emoji keywords		<para>See <a href="https://corefork.telegram.org/method/messages.getEmojiKeywords"/></para></summary>
		/// <param name="lang_code">Language code</param>
		public static Task<EmojiKeywordsDifference> Messages_GetEmojiKeywords(this Client client, string lang_code)
			=> client.Invoke(new Messages_GetEmojiKeywords
			{
				lang_code = lang_code,
			});

		/// <summary>Get changed emoji keywords		<para>See <a href="https://corefork.telegram.org/method/messages.getEmojiKeywordsDifference"/></para></summary>
		/// <param name="lang_code">Language code</param>
		/// <param name="from_version">Previous emoji keyword localization version</param>
		public static Task<EmojiKeywordsDifference> Messages_GetEmojiKeywordsDifference(this Client client, string lang_code, int from_version)
			=> client.Invoke(new Messages_GetEmojiKeywordsDifference
			{
				lang_code = lang_code,
				from_version = from_version,
			});

		/// <summary>Get info about an emoji keyword localization		<para>See <a href="https://corefork.telegram.org/method/messages.getEmojiKeywordsLanguages"/></para></summary>
		/// <param name="lang_codes">Language codes</param>
		public static Task<EmojiLanguage[]> Messages_GetEmojiKeywordsLanguages(this Client client, string[] lang_codes)
			=> client.Invoke(new Messages_GetEmojiKeywordsLanguages
			{
				lang_codes = lang_codes,
			});

		/// <summary>Returns an HTTP URL which can be used to automatically log in into translation platform and suggest new emoji replacements. The URL will be valid for 30 seconds after generation		<para>See <a href="https://corefork.telegram.org/method/messages.getEmojiURL"/></para></summary>
		/// <param name="lang_code">Language code for which the emoji replacements will be suggested</param>
		public static Task<EmojiURL> Messages_GetEmojiURL(this Client client, string lang_code)
			=> client.Invoke(new Messages_GetEmojiURL
			{
				lang_code = lang_code,
			});

		/// <summary>Get the number of results that would be found by a <a href="https://corefork.telegram.org/method/messages.search">messages.search</a> call with the same parameters		<para>See <a href="https://corefork.telegram.org/method/messages.getSearchCounters"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getSearchCounters#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer where to search</param>
		/// <param name="filters">Search filters</param>
		public static Task<Messages_SearchCounter[]> Messages_GetSearchCounters(this Client client, InputPeer peer, params MessagesFilter[] filters)
			=> client.Invoke(new Messages_GetSearchCounters
			{
				peer = peer,
				filters = filters,
			});

		/// <summary>Get more info about a Seamless Telegram Login authorization request, for more info <a href="https://corefork.telegram.org/api/url-authorization">click here »</a>		<para>See <a href="https://corefork.telegram.org/method/messages.requestUrlAuth"/></para></summary>
		/// <param name="peer">Peer where the message is located</param>
		/// <param name="msg_id">The message</param>
		/// <param name="button_id">The ID of the button with the authorization request</param>
		/// <param name="url">URL used for <a href="https://corefork.telegram.org/api/url-authorization#link-url-authorization">link URL authorization, click here for more info »</a></param>
		public static Task<UrlAuthResult> Messages_RequestUrlAuth(this Client client, InputPeer peer = null, int? msg_id = null, int? button_id = null, string url = null)
			=> client.Invoke(new Messages_RequestUrlAuth
			{
				flags = (Messages_RequestUrlAuth.Flags)((peer != null ? 0x2 : 0) | (msg_id != null ? 0x2 : 0) | (button_id != null ? 0x2 : 0) | (url != null ? 0x4 : 0)),
				peer = peer,
				msg_id = msg_id.GetValueOrDefault(),
				button_id = button_id.GetValueOrDefault(),
				url = url,
			});

		/// <summary>Use this to accept a Seamless Telegram Login authorization request, for more info <a href="https://corefork.telegram.org/api/url-authorization">click here »</a>		<para>See <a href="https://corefork.telegram.org/method/messages.acceptUrlAuth"/></para></summary>
		/// <param name="write_allowed">Set this flag to allow the bot to send messages to you (if requested)</param>
		/// <param name="peer">The location of the message</param>
		/// <param name="msg_id">Message ID of the message with the login button</param>
		/// <param name="button_id">ID of the login button</param>
		/// <param name="url">URL used for <a href="https://corefork.telegram.org/api/url-authorization#link-url-authorization">link URL authorization, click here for more info »</a></param>
		public static Task<UrlAuthResult> Messages_AcceptUrlAuth(this Client client, bool write_allowed = false, InputPeer peer = null, int? msg_id = null, int? button_id = null, string url = null)
			=> client.Invoke(new Messages_AcceptUrlAuth
			{
				flags = (Messages_AcceptUrlAuth.Flags)((write_allowed ? 0x1 : 0) | (peer != null ? 0x2 : 0) | (msg_id != null ? 0x2 : 0) | (button_id != null ? 0x2 : 0) | (url != null ? 0x4 : 0)),
				peer = peer,
				msg_id = msg_id.GetValueOrDefault(),
				button_id = button_id.GetValueOrDefault(),
				url = url,
			});

		/// <summary>Should be called after the user hides the report spam/add as contact bar of a new chat, effectively prevents the user from executing the actions specified in the <see cref="PeerSettings"/>.		<para>See <a href="https://corefork.telegram.org/method/messages.hidePeerSettingsBar"/></para></summary>
		/// <param name="peer">Peer</param>
		public static Task<bool> Messages_HidePeerSettingsBar(this Client client, InputPeer peer)
			=> client.Invoke(new Messages_HidePeerSettingsBar
			{
				peer = peer,
			});

		/// <summary>Get scheduled messages		<para>See <a href="https://corefork.telegram.org/method/messages.getScheduledHistory"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getScheduledHistory#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		public static Task<Messages_MessagesBase> Messages_GetScheduledHistory(this Client client, InputPeer peer, long hash = default)
			=> client.Invoke(new Messages_GetScheduledHistory
			{
				peer = peer,
				hash = hash,
			});

		/// <summary>Get scheduled messages		<para>See <a href="https://corefork.telegram.org/method/messages.getScheduledMessages"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getScheduledMessages#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer</param>
		/// <param name="id">IDs of scheduled messages</param>
		public static Task<Messages_MessagesBase> Messages_GetScheduledMessages(this Client client, InputPeer peer, int[] id)
			=> client.Invoke(new Messages_GetScheduledMessages
			{
				peer = peer,
				id = id,
			});

		/// <summary>Send scheduled messages right away		<para>See <a href="https://corefork.telegram.org/method/messages.sendScheduledMessages"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.sendScheduledMessages#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer</param>
		/// <param name="id">Scheduled message IDs</param>
		public static Task<UpdatesBase> Messages_SendScheduledMessages(this Client client, InputPeer peer, int[] id)
			=> client.Invoke(new Messages_SendScheduledMessages
			{
				peer = peer,
				id = id,
			});

		/// <summary>Delete scheduled messages		<para>See <a href="https://corefork.telegram.org/method/messages.deleteScheduledMessages"/></para></summary>
		/// <param name="peer">Peer</param>
		/// <param name="id">Scheduled message IDs</param>
		public static Task<UpdatesBase> Messages_DeleteScheduledMessages(this Client client, InputPeer peer, int[] id)
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
		public static Task<DialogFilter[]> Messages_GetDialogFilters(this Client client)
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
		public static Task<bool> Messages_UpdateDialogFilter(this Client client, int id, DialogFilter filter = null)
			=> client.Invoke(new Messages_UpdateDialogFilter
			{
				flags = (Messages_UpdateDialogFilter.Flags)(filter != null ? 0x1 : 0),
				id = id,
				filter = filter,
			});

		/// <summary>Reorder <a href="https://corefork.telegram.org/api/folders">folders</a>		<para>See <a href="https://corefork.telegram.org/method/messages.updateDialogFiltersOrder"/></para></summary>
		/// <param name="order">New <a href="https://corefork.telegram.org/api/folders">folder</a> order</param>
		public static Task<bool> Messages_UpdateDialogFiltersOrder(this Client client, int[] order)
			=> client.Invoke(new Messages_UpdateDialogFiltersOrder
			{
				order = order,
			});

		/// <summary>Method for fetching previously featured stickers		<para>See <a href="https://corefork.telegram.org/method/messages.getOldFeaturedStickers"/></para></summary>
		/// <param name="offset">Offset</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
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
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
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

		/// <summary><a href="https://corefork.telegram.org/api/pin">Unpin</a> all pinned messages		<para>See <a href="https://corefork.telegram.org/method/messages.unpinAllMessages"/> [bots: ✓]</para></summary>
		/// <param name="peer">Chat where to unpin</param>
		public static Task<Messages_AffectedHistory> Messages_UnpinAllMessages(this Client client, InputPeer peer)
			=> client.Invoke(new Messages_UnpinAllMessages
			{
				peer = peer,
			});

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/README.md#terminology">Terminology</see> to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		Delete a <a href="https://corefork.telegram.org/api/channel">chat</a>		<para>See <a href="https://corefork.telegram.org/method/messages.deleteChat"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.deleteChat#possible-errors">details</a>)</para></summary>
		/// <param name="chat_id">Chat ID</param>
		public static Task<bool> Messages_DeleteChat(this Client client, long chat_id)
			=> client.Invoke(new Messages_DeleteChat
			{
				chat_id = chat_id,
			});

		/// <summary>Delete the entire phone call history.		<para>See <a href="https://corefork.telegram.org/method/messages.deletePhoneCallHistory"/></para></summary>
		/// <param name="revoke">Whether to remove phone call history for participants as well</param>
		public static Task<Messages_AffectedFoundMessages> Messages_DeletePhoneCallHistory(this Client client, bool revoke = false)
			=> client.Invoke(new Messages_DeletePhoneCallHistory
			{
				flags = (Messages_DeletePhoneCallHistory.Flags)(revoke ? 0x1 : 0),
			});

		/// <summary>Obtains information about a chat export file, generated by a foreign chat app, <a href="https://corefork.telegram.org/api/import">click here for more info about imported chats »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.checkHistoryImport"/></para></summary>
		/// <param name="import_head">Beginning of the message file; up to 100 lines.</param>
		public static Task<Messages_HistoryImportParsed> Messages_CheckHistoryImport(this Client client, string import_head)
			=> client.Invoke(new Messages_CheckHistoryImport
			{
				import_head = import_head,
			});

		/// <summary>Import chat history from a foreign chat app into a specific Telegram chat, <a href="https://corefork.telegram.org/api/import">click here for more info about imported chats »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.initHistoryImport"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/messages.initHistoryImport#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The Telegram chat where the <a href="https://corefork.telegram.org/api/import">history should be imported</a>.</param>
		/// <param name="file">File with messages to import.</param>
		/// <param name="media_count">Number of media files associated with the chat that will be uploaded using <a href="https://corefork.telegram.org/method/messages.uploadImportedMedia">messages.uploadImportedMedia</a>.</param>
		public static Task<Messages_HistoryImport> Messages_InitHistoryImport(this Client client, InputPeer peer, InputFileBase file, int media_count)
			=> client.Invoke(new Messages_InitHistoryImport
			{
				peer = peer,
				file = file,
				media_count = media_count,
			});

		/// <summary>Upload a media file associated with an <a href="https://corefork.telegram.org/api/import">imported chat, click here for more info »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.uploadImportedMedia"/></para></summary>
		/// <param name="peer">The Telegram chat where the media will be imported</param>
		/// <param name="import_id">Identifier of a <a href="https://corefork.telegram.org/api/import">history import session</a>, returned by <a href="https://corefork.telegram.org/method/messages.initHistoryImport">messages.initHistoryImport</a></param>
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

		/// <summary>Complete the <a href="https://corefork.telegram.org/api/import">history import process</a>, importing all messages into the chat.<br/>To be called only after initializing the import with <a href="https://corefork.telegram.org/method/messages.initHistoryImport">messages.initHistoryImport</a> and uploading all files using <a href="https://corefork.telegram.org/method/messages.uploadImportedMedia">messages.uploadImportedMedia</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.startHistoryImport"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.startHistoryImport#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The Telegram chat where the messages should be <a href="https://corefork.telegram.org/api/import">imported, click here for more info »</a></param>
		/// <param name="import_id">Identifier of a history import session, returned by <a href="https://corefork.telegram.org/method/messages.initHistoryImport">messages.initHistoryImport</a>.</param>
		public static Task<bool> Messages_StartHistoryImport(this Client client, InputPeer peer, long import_id)
			=> client.Invoke(new Messages_StartHistoryImport
			{
				peer = peer,
				import_id = import_id,
			});

		/// <summary>Get info about the chat invites of a specific chat		<para>See <a href="https://corefork.telegram.org/method/messages.getExportedChatInvites"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getExportedChatInvites#possible-errors">details</a>)</para></summary>
		/// <param name="revoked">Whether to fetch revoked chat invites</param>
		/// <param name="peer">Chat</param>
		/// <param name="admin_id">Whether to only fetch chat invites from this admin</param>
		/// <param name="offset_date"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="offset_link"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Messages_ExportedChatInvites> Messages_GetExportedChatInvites(this Client client, InputPeer peer, InputUserBase admin_id, int limit = int.MaxValue, bool revoked = false, DateTime? offset_date = null, string offset_link = null)
			=> client.Invoke(new Messages_GetExportedChatInvites
			{
				flags = (Messages_GetExportedChatInvites.Flags)((revoked ? 0x8 : 0) | (offset_date != null ? 0x4 : 0) | (offset_link != null ? 0x4 : 0)),
				peer = peer,
				admin_id = admin_id,
				offset_date = offset_date.GetValueOrDefault(),
				offset_link = offset_link,
				limit = limit,
			});

		/// <summary>Get info about a chat invite		<para>See <a href="https://corefork.telegram.org/method/messages.getExportedChatInvite"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getExportedChatInvite#possible-errors">details</a>)</para></summary>
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
		public static Task<Messages_ExportedChatInviteBase> Messages_EditExportedChatInvite(this Client client, InputPeer peer, string link, bool revoked = false, DateTime? expire_date = null, int? usage_limit = null, bool? request_needed = default, string title = null)
			=> client.Invoke(new Messages_EditExportedChatInvite
			{
				flags = (Messages_EditExportedChatInvite.Flags)((revoked ? 0x4 : 0) | (expire_date != null ? 0x1 : 0) | (usage_limit != null ? 0x2 : 0) | (request_needed != default ? 0x8 : 0) | (title != null ? 0x10 : 0)),
				peer = peer,
				link = link,
				expire_date = expire_date.GetValueOrDefault(),
				usage_limit = usage_limit.GetValueOrDefault(),
				request_needed = request_needed.GetValueOrDefault(),
				title = title,
			});

		/// <summary>Delete all revoked chat invites		<para>See <a href="https://corefork.telegram.org/method/messages.deleteRevokedExportedChatInvites"/></para></summary>
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

		/// <summary>Get info about the users that joined the chat using a specific chat invite		<para>See <a href="https://corefork.telegram.org/method/messages.getChatInviteImporters"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getChatInviteImporters#possible-errors">details</a>)</para></summary>
		/// <param name="requested">If set, only returns info about users with pending <a href="https://corefork.telegram.org/api/invites#join-requests">join requests »</a></param>
		/// <param name="peer">Chat</param>
		/// <param name="link">Invite link</param>
		/// <param name="q">Search for a user in the pending <a href="https://corefork.telegram.org/api/invites#join-requests">join requests »</a> list: only available when the <c>requested</c> flag is set, cannot be used together with a specific <c>link</c>.</param>
		/// <param name="offset_date"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="offset_user">User ID for <a href="https://corefork.telegram.org/api/offsets">pagination</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Messages_ChatInviteImporters> Messages_GetChatInviteImporters(this Client client, InputPeer peer, DateTime offset_date = default, InputUserBase offset_user = null, int limit = int.MaxValue, bool requested = false, string link = null, string q = null)
			=> client.Invoke(new Messages_GetChatInviteImporters
			{
				flags = (Messages_GetChatInviteImporters.Flags)((requested ? 0x1 : 0) | (link != null ? 0x2 : 0) | (q != null ? 0x4 : 0)),
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
		/// <param name="emoticon">Emoji, identifying a specific chat theme; a list of chat themes can be fetched using <a href="https://corefork.telegram.org/method/account.getChatThemes">account.getChatThemes</a></param>
		public static Task<UpdatesBase> Messages_SetChatTheme(this Client client, InputPeer peer, string emoticon)
			=> client.Invoke(new Messages_SetChatTheme
			{
				peer = peer,
				emoticon = emoticon,
			});

		/// <summary>Get which users read a specific message: only available for groups and supergroups with less than <c>chat_read_mark_size_threshold</c> members, read receipts will be stored for <c>chat_read_mark_expire_period</c> seconds after the message was sent, see <a href="https://corefork.telegram.org/api/config#client-configuration">client configuration for more info »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.getMessageReadParticipants"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getMessageReadParticipants#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Dialog</param>
		/// <param name="msg_id">Message ID</param>
		public static Task<long[]> Messages_GetMessageReadParticipants(this Client client, InputPeer peer, int msg_id)
			=> client.Invoke(new Messages_GetMessageReadParticipants
			{
				peer = peer,
				msg_id = msg_id,
			});

		/// <summary>Returns information about the next messages of the specified type in the chat split by days.		<para>See <a href="https://corefork.telegram.org/method/messages.getSearchResultsCalendar"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getSearchResultsCalendar#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Peer where to search</param>
		/// <param name="filter">Message filter, <see langword="null"/>, <see cref="InputMessagesFilterMyMentions"/> filters are not supported by this method.</param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="offset_date"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		public static Task<Messages_SearchResultsCalendar> Messages_GetSearchResultsCalendar(this Client client, InputPeer peer, MessagesFilter filter, int offset_id = default, DateTime offset_date = default)
			=> client.Invoke(new Messages_GetSearchResultsCalendar
			{
				peer = peer,
				filter = filter,
				offset_id = offset_id,
				offset_date = offset_date,
			});

		/// <summary>Returns sparse positions of messages of the specified type in the chat to be used for shared media scroll implementation.		<para>See <a href="https://corefork.telegram.org/method/messages.getSearchResultsPositions"/></para></summary>
		/// <param name="peer">Peer where to search</param>
		/// <param name="filter">Message filter, <see langword="null"/>, <see cref="InputMessagesFilterMyMentions"/> filters are not supported by this method.</param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Messages_SearchResultsPositions> Messages_GetSearchResultsPositions(this Client client, InputPeer peer, MessagesFilter filter, int offset_id = default, int limit = int.MaxValue)
			=> client.Invoke(new Messages_GetSearchResultsPositions
			{
				peer = peer,
				filter = filter,
				offset_id = offset_id,
				limit = limit,
			});

		/// <summary>Dismiss or approve a chat <a href="https://corefork.telegram.org/api/invites#join-requests">join request</a> related to a specific chat or channel.		<para>See <a href="https://corefork.telegram.org/method/messages.hideChatJoinRequest"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.hideChatJoinRequest#possible-errors">details</a>)</para></summary>
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

		/// <summary>Dismiss or approve all <a href="https://corefork.telegram.org/api/invites#join-requests">join requests</a> related to a specific chat or channel.		<para>See <a href="https://corefork.telegram.org/method/messages.hideAllChatJoinRequests"/></para></summary>
		/// <param name="approved">Whether to dismiss or approve all chat <a href="https://corefork.telegram.org/api/invites#join-requests">join requests »</a></param>
		/// <param name="peer">The chat or channel</param>
		/// <param name="link">Only dismiss or approve <a href="https://corefork.telegram.org/api/invites#join-requests">join requests »</a> initiated using this invite link</param>
		public static Task<UpdatesBase> Messages_HideAllChatJoinRequests(this Client client, InputPeer peer, bool approved = false, string link = null)
			=> client.Invoke(new Messages_HideAllChatJoinRequests
			{
				flags = (Messages_HideAllChatJoinRequests.Flags)((approved ? 0x1 : 0) | (link != null ? 0x2 : 0)),
				peer = peer,
				link = link,
			});

		/// <summary>Enable or disable <a href="https://telegram.org/blog/protected-content-delete-by-date-and-more">content protection</a> on a channel or chat		<para>See <a href="https://corefork.telegram.org/method/messages.toggleNoForwards"/></para></summary>
		/// <param name="peer">The chat or channel</param>
		/// <param name="enabled">Enable or disable content protection</param>
		public static Task<UpdatesBase> Messages_ToggleNoForwards(this Client client, InputPeer peer, bool enabled)
			=> client.Invoke(new Messages_ToggleNoForwards
			{
				peer = peer,
				enabled = enabled,
			});

		/// <summary>Change the default peer that should be used when sending messages to a specific group		<para>See <a href="https://corefork.telegram.org/method/messages.saveDefaultSendAs"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.saveDefaultSendAs#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Group</param>
		/// <param name="send_as">The default peer that should be used when sending messages to the group</param>
		public static Task<bool> Messages_SaveDefaultSendAs(this Client client, InputPeer peer, InputPeer send_as)
			=> client.Invoke(new Messages_SaveDefaultSendAs
			{
				peer = peer,
				send_as = send_as,
			});

		/// <summary>React to message		<para>See <a href="https://corefork.telegram.org/method/messages.sendReaction"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.sendReaction#possible-errors">details</a>)</para></summary>
		/// <param name="big">Whether a bigger and longer reaction should be shown</param>
		/// <param name="peer">Peer</param>
		/// <param name="msg_id">Message ID to react to</param>
		/// <param name="reaction">Reaction (a UTF8 emoji)</param>
		public static Task<UpdatesBase> Messages_SendReaction(this Client client, InputPeer peer, int msg_id, bool big = false, string reaction = null)
			=> client.Invoke(new Messages_SendReaction
			{
				flags = (Messages_SendReaction.Flags)((big ? 0x2 : 0) | (reaction != null ? 0x1 : 0)),
				peer = peer,
				msg_id = msg_id,
				reaction = reaction,
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/reactions">message reactions »</a>		<para>See <a href="https://corefork.telegram.org/method/messages.getMessagesReactions"/> [bots: ✓]</para></summary>
		/// <param name="peer">Peer</param>
		/// <param name="id">Message IDs</param>
		public static Task<UpdatesBase> Messages_GetMessagesReactions(this Client client, InputPeer peer, int[] id)
			=> client.Invoke(new Messages_GetMessagesReactions
			{
				peer = peer,
				id = id,
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/reactions">message reaction</a> list, along with the sender of each reaction.		<para>See <a href="https://corefork.telegram.org/method/messages.getMessageReactionsList"/></para></summary>
		/// <param name="peer">Peer</param>
		/// <param name="id">Message ID</param>
		/// <param name="reaction">Get only reactions of this type (UTF8 emoji)</param>
		/// <param name="offset">Offset (typically taken from the <c>next_offset</c> field of the returned <see cref="Messages_MessageReactionsList"/>)</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Messages_MessageReactionsList> Messages_GetMessageReactionsList(this Client client, InputPeer peer, int id, int limit = int.MaxValue, string reaction = null, string offset = null)
			=> client.Invoke(new Messages_GetMessageReactionsList
			{
				flags = (Messages_GetMessageReactionsList.Flags)((reaction != null ? 0x1 : 0) | (offset != null ? 0x2 : 0)),
				peer = peer,
				id = id,
				reaction = reaction,
				offset = offset,
				limit = limit,
			});

		/// <summary>Change the set of <a href="https://corefork.telegram.org/api/reactions">message reactions »</a> that can be used in a certain group, supergroup or channel		<para>See <a href="https://corefork.telegram.org/method/messages.setChatAvailableReactions"/></para></summary>
		/// <param name="peer">Group where to apply changes</param>
		/// <param name="available_reactions">Allowed reaction emojis</param>
		public static Task<UpdatesBase> Messages_SetChatAvailableReactions(this Client client, InputPeer peer, string[] available_reactions)
			=> client.Invoke(new Messages_SetChatAvailableReactions
			{
				peer = peer,
				available_reactions = available_reactions,
			});

		/// <summary>Obtain available <a href="https://corefork.telegram.org/api/reactions">message reactions »</a>		<para>See <a href="https://corefork.telegram.org/method/messages.getAvailableReactions"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.availableReactionsNotModified">messages.availableReactionsNotModified</a></returns>
		public static Task<Messages_AvailableReactions> Messages_GetAvailableReactions(this Client client, int hash = default)
			=> client.Invoke(new Messages_GetAvailableReactions
			{
				hash = hash,
			});

		/// <summary>Change default emoji reaction to use in the quick reaction menu: the value is synced across devices and can be fetched using <a href="https://corefork.telegram.org/api/config#client-configuration">help.getAppConfig, <c>reactions_default</c> field</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.setDefaultReaction"/></para></summary>
		/// <param name="reaction">New emoji reaction</param>
		public static Task<bool> Messages_SetDefaultReaction(this Client client, string reaction)
			=> client.Invoke(new Messages_SetDefaultReaction
			{
				reaction = reaction,
			});

		/// <summary>Translate a given text		<para>See <a href="https://corefork.telegram.org/method/messages.translateText"/> [bots: ✓]</para></summary>
		/// <param name="peer">If the text is a chat message, the peer ID</param>
		/// <param name="msg_id">If the text is a chat message, the message ID</param>
		/// <param name="text">The text to translate</param>
		/// <param name="from_lang">Two-letter ISO 639-1 language code of the language from which the message is translated, if not set will be autodetected</param>
		/// <param name="to_lang">Two-letter ISO 639-1 language code of the language to which the message is translated</param>
		public static Task<Messages_TranslatedText> Messages_TranslateText(this Client client, string to_lang, InputPeer peer = null, int? msg_id = null, string text = null, string from_lang = null)
			=> client.Invoke(new Messages_TranslateText
			{
				flags = (Messages_TranslateText.Flags)((peer != null ? 0x1 : 0) | (msg_id != null ? 0x1 : 0) | (text != null ? 0x2 : 0) | (from_lang != null ? 0x4 : 0)),
				peer = peer,
				msg_id = msg_id.GetValueOrDefault(),
				text = text,
				from_lang = from_lang,
				to_lang = to_lang,
			});

		/// <summary>Get unread reactions to messages you sent		<para>See <a href="https://corefork.telegram.org/method/messages.getUnreadReactions"/> [bots: ✓]</para></summary>
		/// <param name="peer">Peer</param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="add_offset"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <param name="max_id">Only return reactions for messages up until this message ID</param>
		/// <param name="min_id">Only return reactions for messages starting from this message ID</param>
		public static Task<Messages_MessagesBase> Messages_GetUnreadReactions(this Client client, InputPeer peer, int offset_id = default, int add_offset = default, int limit = int.MaxValue, int max_id = default, int min_id = default)
			=> client.Invoke(new Messages_GetUnreadReactions
			{
				peer = peer,
				offset_id = offset_id,
				add_offset = add_offset,
				limit = limit,
				max_id = max_id,
				min_id = min_id,
			});

		/// <summary>Mark <a href="https://corefork.telegram.org/api/reactions">message reactions »</a> as read		<para>See <a href="https://corefork.telegram.org/method/messages.readReactions"/> [bots: ✓]</para></summary>
		/// <param name="peer">Peer</param>
		public static Task<Messages_AffectedHistory> Messages_ReadReactions(this Client client, InputPeer peer)
			=> client.Invoke(new Messages_ReadReactions
			{
				peer = peer,
			});

		/// <summary>View and search recently sent media.<br/>This method does not support pagination.		<para>See <a href="https://corefork.telegram.org/method/messages.searchSentMedia"/></para></summary>
		/// <param name="q">Optional search query</param>
		/// <param name="filter">Message filter</param>
		/// <param name="limit">Maximum number of results to return (max 100).</param>
		public static Task<Messages_MessagesBase> Messages_SearchSentMedia(this Client client, string q, MessagesFilter filter, int limit = int.MaxValue)
			=> client.Invoke(new Messages_SearchSentMedia
			{
				q = q,
				filter = filter,
				limit = limit,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/messages.getAttachMenuBots"/></para></summary>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/attachMenuBotsNotModified">attachMenuBotsNotModified</a></returns>
		public static Task<AttachMenuBots> Messages_GetAttachMenuBots(this Client client, long hash = default)
			=> client.Invoke(new Messages_GetAttachMenuBots
			{
				hash = hash,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/messages.getAttachMenuBot"/></para></summary>
		public static Task<AttachMenuBotsBot> Messages_GetAttachMenuBot(this Client client, InputUserBase bot)
			=> client.Invoke(new Messages_GetAttachMenuBot
			{
				bot = bot,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/messages.toggleBotInAttachMenu"/></para></summary>
		public static Task<bool> Messages_ToggleBotInAttachMenu(this Client client, InputUserBase bot, bool enabled)
			=> client.Invoke(new Messages_ToggleBotInAttachMenu
			{
				bot = bot,
				enabled = enabled,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/messages.requestWebView"/></para></summary>
		public static Task<WebViewResult> Messages_RequestWebView(this Client client, InputPeer peer, InputUserBase bot, bool from_bot_menu = false, bool silent = false, string url = null, string start_param = null, DataJSON theme_params = null, int? reply_to_msg_id = null)
			=> client.Invoke(new Messages_RequestWebView
			{
				flags = (Messages_RequestWebView.Flags)((from_bot_menu ? 0x10 : 0) | (silent ? 0x20 : 0) | (url != null ? 0x2 : 0) | (start_param != null ? 0x8 : 0) | (theme_params != null ? 0x4 : 0) | (reply_to_msg_id != null ? 0x1 : 0)),
				peer = peer,
				bot = bot,
				url = url,
				start_param = start_param,
				theme_params = theme_params,
				reply_to_msg_id = reply_to_msg_id.GetValueOrDefault(),
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/messages.prolongWebView"/></para></summary>
		public static Task<bool> Messages_ProlongWebView(this Client client, InputPeer peer, InputUserBase bot, long query_id, bool silent = false, int? reply_to_msg_id = null)
			=> client.Invoke(new Messages_ProlongWebView
			{
				flags = (Messages_ProlongWebView.Flags)((silent ? 0x20 : 0) | (reply_to_msg_id != null ? 0x1 : 0)),
				peer = peer,
				bot = bot,
				query_id = query_id,
				reply_to_msg_id = reply_to_msg_id.GetValueOrDefault(),
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/messages.requestSimpleWebView"/></para></summary>
		public static Task<SimpleWebViewResult> Messages_RequestSimpleWebView(this Client client, InputUserBase bot, string url, DataJSON theme_params = null)
			=> client.Invoke(new Messages_RequestSimpleWebView
			{
				flags = (Messages_RequestSimpleWebView.Flags)(theme_params != null ? 0x1 : 0),
				bot = bot,
				url = url,
				theme_params = theme_params,
			});

		/// <summary><para>⚠ <b>This method is only for basic Chat</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/README.md#terminology">Terminology</see> to understand what this means<br/>Search for a similar method name starting with <c>Channels_</c> if you're dealing with a <see cref="Channel"/></para>		<para>See <a href="https://corefork.telegram.org/method/messages.sendWebViewResultMessage"/></para></summary>
		public static Task<WebViewMessageSent> Messages_SendWebViewResultMessage(this Client client, string bot_query_id, InputBotInlineResultBase result)
			=> client.Invoke(new Messages_SendWebViewResultMessage
			{
				bot_query_id = bot_query_id,
				result = result,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/messages.sendWebViewData"/></para></summary>
		public static Task<UpdatesBase> Messages_SendWebViewData(this Client client, InputUserBase bot, long random_id, string button_text, string data)
			=> client.Invoke(new Messages_SendWebViewData
			{
				bot = bot,
				random_id = random_id,
				button_text = button_text,
				data = data,
			});

		/// <summary>Returns a current state of updates.		<para>See <a href="https://corefork.telegram.org/method/updates.getState"/> [bots: ✓]</para></summary>
		public static Task<Updates_State> Updates_GetState(this Client client)
			=> client.Invoke(new Updates_GetState
			{
			});

		/// <summary>Get new <a href="https://corefork.telegram.org/api/updates">updates</a>.		<para>See <a href="https://corefork.telegram.org/method/updates.getDifference"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/updates.getDifference#possible-errors">details</a>)</para></summary>
		/// <param name="pts">PTS, see <a href="https://corefork.telegram.org/api/updates">updates</a>.</param>
		/// <param name="pts_total_limit">For fast updating: if provided and <c>pts + pts_total_limit &lt; remote pts</c>, <see cref="Updates_DifferenceTooLong"/> will be returned.<br/>Simply tells the server to not return the difference if it is bigger than <c>pts_total_limit</c><br/>If the remote pts is too big (&gt; ~4000000), this field will default to 1000000</param>
		/// <param name="date">date, see <a href="https://corefork.telegram.org/api/updates">updates</a>.</param>
		/// <param name="qts">QTS, see <a href="https://corefork.telegram.org/api/updates">updates</a>.</param>
		public static Task<Updates_DifferenceBase> Updates_GetDifference(this Client client, int pts, DateTime date, int qts, int? pts_total_limit = null)
			=> client.Invoke(new Updates_GetDifference
			{
				flags = (Updates_GetDifference.Flags)(pts_total_limit != null ? 0x1 : 0),
				pts = pts,
				pts_total_limit = pts_total_limit.GetValueOrDefault(),
				date = date,
				qts = qts,
			});

		/// <summary>Returns the difference between the current state of updates of a certain channel and transmitted.		<para>See <a href="https://corefork.telegram.org/method/updates.getChannelDifference"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403,500 (<a href="https://corefork.telegram.org/method/updates.getChannelDifference#possible-errors">details</a>)</para></summary>
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

		/// <summary>Installs a previously uploaded photo as a profile photo.		<para>See <a href="https://corefork.telegram.org/method/photos.updateProfilePhoto"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/photos.updateProfilePhoto#possible-errors">details</a>)</para></summary>
		/// <param name="id">Input photo</param>
		public static Task<Photos_Photo> Photos_UpdateProfilePhoto(this Client client, InputPhoto id)
			=> client.Invoke(new Photos_UpdateProfilePhoto
			{
				id = id,
			});

		/// <summary>Updates current user profile photo.		<para>See <a href="https://corefork.telegram.org/method/photos.uploadProfilePhoto"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/photos.uploadProfilePhoto#possible-errors">details</a>)</para></summary>
		/// <param name="file">File saved in parts by means of <a href="https://corefork.telegram.org/method/upload.saveFilePart">upload.saveFilePart</a> method</param>
		/// <param name="video"><a href="https://corefork.telegram.org/api/files#animated-profile-pictures">Animated profile picture</a> video</param>
		/// <param name="video_start_ts">Floating point UNIX timestamp in seconds, indicating the frame of the video that should be used as static preview.</param>
		public static Task<Photos_Photo> Photos_UploadProfilePhoto(this Client client, InputFileBase file = null, InputFileBase video = null, double? video_start_ts = null)
			=> client.Invoke(new Photos_UploadProfilePhoto
			{
				flags = (Photos_UploadProfilePhoto.Flags)((file != null ? 0x1 : 0) | (video != null ? 0x2 : 0) | (video_start_ts != null ? 0x4 : 0)),
				file = file,
				video = video,
				video_start_ts = video_start_ts.GetValueOrDefault(),
			});

		/// <summary>Deletes profile photos.		<para>See <a href="https://corefork.telegram.org/method/photos.deletePhotos"/></para></summary>
		/// <param name="id">Input photos to delete</param>
		public static Task<long[]> Photos_DeletePhotos(this Client client, params InputPhoto[] id)
			=> client.Invoke(new Photos_DeletePhotos
			{
				id = id,
			});

		/// <summary>Returns the list of user photos.		<para>See <a href="https://corefork.telegram.org/method/photos.getUserPhotos"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/photos.getUserPhotos#possible-errors">details</a>)</para></summary>
		/// <param name="user_id">User ID</param>
		/// <param name="offset">Number of list elements to be skipped</param>
		/// <param name="max_id">If a positive value was transferred, the method will return only photos with IDs less than the set one</param>
		/// <param name="limit">Number of list elements to be returned</param>
		public static Task<Photos_Photos> Photos_GetUserPhotos(this Client client, InputUserBase user_id, int offset = default, long max_id = default, int limit = int.MaxValue)
			=> client.Invoke(new Photos_GetUserPhotos
			{
				user_id = user_id,
				offset = offset,
				max_id = max_id,
				limit = limit,
			});

		/// <summary>Saves a part of file for further sending to one of the methods.		<para>See <a href="https://corefork.telegram.org/method/upload.saveFilePart"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/upload.saveFilePart#possible-errors">details</a>)</para></summary>
		/// <param name="file_id">Random file identifier created by the client</param>
		/// <param name="file_part">Numerical order of a part</param>
		/// <param name="bytes">Binary data, contend of a part</param>
		public static Task<bool> Upload_SaveFilePart(this Client client, long file_id, int file_part, byte[] bytes)
			=> client.Invoke(new Upload_SaveFilePart
			{
				file_id = file_id,
				file_part = file_part,
				bytes = bytes,
			});

		/// <summary>Returns content of a whole file or its part.		<para>See <a href="https://corefork.telegram.org/method/upload.getFile"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/upload.getFile#possible-errors">details</a>)</para></summary>
		/// <param name="precise">Disable some checks on limit and offset values, useful for example to stream videos by keyframes</param>
		/// <param name="cdn_supported">Whether the current client supports <a href="https://corefork.telegram.org/cdn">CDN downloads</a></param>
		/// <param name="location">File location</param>
		/// <param name="offset">Number of bytes to be skipped</param>
		/// <param name="limit">Number of bytes to be returned</param>
		public static Task<Upload_FileBase> Upload_GetFile(this Client client, InputFileLocationBase location, int offset = default, int limit = int.MaxValue, bool precise = false, bool cdn_supported = false)
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

		/// <summary>Returns content of an HTTP file or a part, by proxying the request through telegram.		<para>See <a href="https://corefork.telegram.org/method/upload.getWebFile"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/upload.getWebFile#possible-errors">details</a>)</para></summary>
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

		/// <summary>Download a <a href="https://corefork.telegram.org/cdn">CDN</a> file.		<para>See <a href="https://corefork.telegram.org/method/upload.getCdnFile"/></para></summary>
		/// <param name="file_token">File token</param>
		/// <param name="offset">Offset of chunk to download</param>
		/// <param name="limit">Length of chunk to download</param>
		public static Task<Upload_CdnFileBase> Upload_GetCdnFile(this Client client, byte[] file_token, int offset = default, int limit = int.MaxValue)
			=> client.Invoke(new Upload_GetCdnFile
			{
				file_token = file_token,
				offset = offset,
				limit = limit,
			});

		/// <summary>Request a reupload of a certain file to a <a href="https://corefork.telegram.org/cdn">CDN DC</a>.		<para>See <a href="https://corefork.telegram.org/method/upload.reuploadCdnFile"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/upload.reuploadCdnFile#possible-errors">details</a>)</para></summary>
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
		public static Task<FileHash[]> Upload_GetCdnFileHashes(this Client client, byte[] file_token, int offset = default)
			=> client.Invoke(new Upload_GetCdnFileHashes
			{
				file_token = file_token,
				offset = offset,
			});

		/// <summary>Get SHA256 hashes for verifying downloaded files		<para>See <a href="https://corefork.telegram.org/method/upload.getFileHashes"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/upload.getFileHashes#possible-errors">details</a>)</para></summary>
		/// <param name="location">File</param>
		/// <param name="offset">Offset from which to get file hashes</param>
		public static Task<FileHash[]> Upload_GetFileHashes(this Client client, InputFileLocationBase location, int offset = default)
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

		/// <summary>Get changelog of current app.<br/>Typically, an <see cref="Updates"/> constructor will be returned, containing one or more <see cref="UpdateServiceNotification"/> updates with app-specific changelogs.		<para>See <a href="https://corefork.telegram.org/method/help.getAppChangelog"/></para></summary>
		/// <param name="prev_app_version">Previous app version</param>
		public static Task<UpdatesBase> Help_GetAppChangelog(this Client client, string prev_app_version)
			=> client.Invoke(new Help_GetAppChangelog
			{
				prev_app_version = prev_app_version,
			});

		/// <summary>Informs the server about the number of pending bot updates if they haven't been processed for a long time; for bots only		<para>See <a href="https://corefork.telegram.org/method/help.setBotUpdatesStatus"/> [bots: ✓]</para></summary>
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

		/// <summary>Get recently used <c>t.me</c> links		<para>See <a href="https://corefork.telegram.org/method/help.getRecentMeUrls"/></para></summary>
		/// <param name="referer">Referer</param>
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

		/// <summary>Accept the new terms of service		<para>See <a href="https://corefork.telegram.org/method/help.acceptTermsOfService"/></para></summary>
		/// <param name="id">ID of terms of service</param>
		public static Task<bool> Help_AcceptTermsOfService(this Client client, DataJSON id)
			=> client.Invoke(new Help_AcceptTermsOfService
			{
				id = id,
			});

		/// <summary>Get info about a <c>t.me</c> link		<para>See <a href="https://corefork.telegram.org/method/help.getDeepLinkInfo"/></para></summary>
		/// <param name="path">Path in <c>t.me/path</c></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.deepLinkInfoEmpty">help.deepLinkInfoEmpty</a></returns>
		public static Task<Help_DeepLinkInfo> Help_GetDeepLinkInfo(this Client client, string path)
			=> client.Invoke(new Help_GetDeepLinkInfo
			{
				path = path,
			});

		/// <summary>Get app-specific configuration, see <a href="https://corefork.telegram.org/api/config#client-configuration">client configuration</a> for more info on the result.		<para>See <a href="https://corefork.telegram.org/method/help.getAppConfig"/></para></summary>
		public static Task<JsonObject> Help_GetAppConfig(this Client client)
			=> client.Invoke(new Help_GetAppConfig
			{
			});

		/// <summary>Saves logs of application on the server.		<para>See <a href="https://corefork.telegram.org/method/help.saveAppLog"/></para></summary>
		/// <param name="events">List of input events</param>
		public static Task<bool> Help_SaveAppLog(this Client client, params InputAppEvent[] events)
			=> client.Invoke(new Help_SaveAppLog
			{
				events = events,
			});

		/// <summary>Get <a href="https://corefork.telegram.org/passport">passport</a> configuration		<para>See <a href="https://corefork.telegram.org/method/help.getPassportConfig"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
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

		/// <summary>Internal use		<para>See <a href="https://corefork.telegram.org/method/help.getUserInfo"/></para>		<para>Possible <see cref="RpcException"/> codes: 403 (<a href="https://corefork.telegram.org/method/help.getUserInfo#possible-errors">details</a>)</para></summary>
		/// <param name="user_id">User ID</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.userInfoEmpty">help.userInfoEmpty</a></returns>
		public static Task<Help_UserInfo> Help_GetUserInfo(this Client client, InputUserBase user_id)
			=> client.Invoke(new Help_GetUserInfo
			{
				user_id = user_id,
			});

		/// <summary>Internal use		<para>See <a href="https://corefork.telegram.org/method/help.editUserInfo"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/help.editUserInfo#possible-errors">details</a>)</para></summary>
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
		/// <param name="peer">In the case of pending suggestions in <see cref="ChannelFull"/>, the channel ID.</param>
		/// <param name="suggestion"><a href="https://corefork.telegram.org/api/config#suggestions">Suggestion, see here for more info »</a>.</param>
		public static Task<bool> Help_DismissSuggestion(this Client client, InputPeer peer, string suggestion)
			=> client.Invoke(new Help_DismissSuggestion
			{
				peer = peer,
				suggestion = suggestion,
			});

		/// <summary>Get name, ISO code, localized name and phone codes/patterns of all available countries		<para>See <a href="https://corefork.telegram.org/method/help.getCountriesList"/></para></summary>
		/// <param name="lang_code">Language code of the current user</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.countriesListNotModified">help.countriesListNotModified</a></returns>
		public static Task<Help_CountriesList> Help_GetCountriesList(this Client client, string lang_code, int hash = default)
			=> client.Invoke(new Help_GetCountriesList
			{
				lang_code = lang_code,
				hash = hash,
			});

		/// <summary>Mark <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> history as read		<para>See <a href="https://corefork.telegram.org/method/channels.readHistory"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.readHistory#possible-errors">details</a>)</para></summary>
		/// <param name="channel"><a href="https://corefork.telegram.org/api/channel">Channel/supergroup</a></param>
		/// <param name="max_id">ID of message up to which messages should be marked as read</param>
		public static Task<bool> Channels_ReadHistory(this Client client, InputChannelBase channel, int max_id = default)
			=> client.Invoke(new Channels_ReadHistory
			{
				channel = channel,
				max_id = max_id,
			});

		/// <summary>Delete messages in a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>		<para>See <a href="https://corefork.telegram.org/method/channels.deleteMessages"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/channels.deleteMessages#possible-errors">details</a>)</para></summary>
		/// <param name="channel"><a href="https://corefork.telegram.org/api/channel">Channel/supergroup</a></param>
		/// <param name="id">IDs of messages to delete</param>
		public static Task<Messages_AffectedMessages> Channels_DeleteMessages(this Client client, InputChannelBase channel, int[] id)
			=> client.Invoke(new Channels_DeleteMessages
			{
				channel = channel,
				id = id,
			});

		/// <summary>Reports some messages from a user in a supergroup as spam; requires administrator rights in the supergroup		<para>See <a href="https://corefork.telegram.org/method/channels.reportSpam"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.reportSpam#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Supergroup</param>
		/// <param name="participant">Participant whose messages should be reported</param>
		/// <param name="id">IDs of spam messages</param>
		public static Task<bool> Channels_ReportSpam(this Client client, InputChannelBase channel, InputPeer participant, int[] id)
			=> client.Invoke(new Channels_ReportSpam
			{
				channel = channel,
				participant = participant,
				id = id,
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> messages		<para>See <a href="https://corefork.telegram.org/method/channels.getMessages"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.getMessages#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Channel/supergroup</param>
		/// <param name="id">IDs of messages to get</param>
		public static Task<Messages_MessagesBase> Channels_GetMessages(this Client client, InputChannelBase channel, params InputMessage[] id)
			=> client.Invoke(new Channels_GetMessages
			{
				channel = channel,
				id = id,
			});

		/// <summary>Get the participants of a <a href="https://corefork.telegram.org/api/channel">supergroup/channel</a>		<para>See <a href="https://corefork.telegram.org/method/channels.getParticipants"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.getParticipants#possible-errors">details</a>)</para></summary>
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

		/// <summary>Get info about a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> participant		<para>See <a href="https://corefork.telegram.org/method/channels.getParticipant"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.getParticipant#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Channel/supergroup</param>
		/// <param name="participant">Participant to get info about</param>
		public static Task<Channels_ChannelParticipant> Channels_GetParticipant(this Client client, InputChannelBase channel, InputPeer participant)
			=> client.Invoke(new Channels_GetParticipant
			{
				channel = channel,
				participant = participant,
			});

		/// <summary>Get info about <a href="https://corefork.telegram.org/api/channel">channels/supergroups</a>		<para>See <a href="https://corefork.telegram.org/method/channels.getChannels"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.getChannels#possible-errors">details</a>)</para></summary>
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

		/// <summary>Create a <a href="https://corefork.telegram.org/api/channel">supergroup/channel</a>.		<para>See <a href="https://corefork.telegram.org/method/channels.createChannel"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,406 (<a href="https://corefork.telegram.org/method/channels.createChannel#possible-errors">details</a>)</para></summary>
		/// <param name="broadcast">Whether to create a <a href="https://corefork.telegram.org/api/channel">channel</a></param>
		/// <param name="megagroup">Whether to create a <a href="https://corefork.telegram.org/api/channel">supergroup</a></param>
		/// <param name="for_import">Whether the supergroup is being created to import messages from a foreign chat service using <a href="https://corefork.telegram.org/method/messages.initHistoryImport">messages.initHistoryImport</a></param>
		/// <param name="title">Channel title</param>
		/// <param name="about">Channel description</param>
		/// <param name="geo_point">Geogroup location</param>
		/// <param name="address">Geogroup address</param>
		public static Task<UpdatesBase> Channels_CreateChannel(this Client client, string title, string about, bool broadcast = false, bool megagroup = false, bool for_import = false, InputGeoPoint geo_point = null, string address = null)
			=> client.Invoke(new Channels_CreateChannel
			{
				flags = (Channels_CreateChannel.Flags)((broadcast ? 0x1 : 0) | (megagroup ? 0x2 : 0) | (for_import ? 0x8 : 0) | (geo_point != null ? 0x4 : 0) | (address != null ? 0x4 : 0)),
				title = title,
				about = about,
				geo_point = geo_point,
				address = address,
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

		/// <summary>Change the username of a supergroup/channel		<para>See <a href="https://corefork.telegram.org/method/channels.updateUsername"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/channels.updateUsername#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Channel</param>
		/// <param name="username">New username</param>
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

		/// <summary>Leave a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>		<para>See <a href="https://corefork.telegram.org/method/channels.leaveChannel"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/channels.leaveChannel#possible-errors">details</a>)</para></summary>
		/// <param name="channel"><a href="https://corefork.telegram.org/api/channel">Channel/supergroup</a> to leave</param>
		public static Task<UpdatesBase> Channels_LeaveChannel(this Client client, InputChannelBase channel)
			=> client.Invoke(new Channels_LeaveChannel
			{
				channel = channel,
			});

		/// <summary>Invite users to a channel/supergroup		<para>See <a href="https://corefork.telegram.org/method/channels.inviteToChannel"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/channels.inviteToChannel#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Channel/supergroup</param>
		/// <param name="users">Users to invite</param>
		public static Task<UpdatesBase> Channels_InviteToChannel(this Client client, InputChannelBase channel, params InputUserBase[] users)
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
		/// <param name="channel">Channel</param>
		/// <param name="enabled">Value</param>
		public static Task<UpdatesBase> Channels_ToggleSignatures(this Client client, InputChannelBase channel, bool enabled)
			=> client.Invoke(new Channels_ToggleSignatures
			{
				channel = channel,
				enabled = enabled,
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/channel">channels/supergroups/geogroups</a> we're admin in. Usually called when the user exceeds the <see cref="Config"/> for owned public <a href="https://corefork.telegram.org/api/channel">channels/supergroups/geogroups</a>, and the user is given the choice to remove one of his channels/supergroups/geogroups.		<para>See <a href="https://corefork.telegram.org/method/channels.getAdminedPublicChannels"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.getAdminedPublicChannels#possible-errors">details</a>)</para></summary>
		/// <param name="by_location">Get geogroups</param>
		/// <param name="check_limit">If set and the user has reached the limit of owned public <a href="https://corefork.telegram.org/api/channel">channels/supergroups/geogroups</a>, instead of returning the channel list one of the specified <a href="#possible-errors">errors</a> will be returned.<br/>Useful to check if a new public channel can indeed be created, even before asking the user to enter a channel username to use in <a href="https://corefork.telegram.org/method/channels.checkUsername">channels.checkUsername</a>/<a href="https://corefork.telegram.org/method/channels.updateUsername">channels.updateUsername</a>.</param>
		public static Task<Messages_Chats> Channels_GetAdminedPublicChannels(this Client client, bool by_location = false, bool check_limit = false)
			=> client.Invoke(new Channels_GetAdminedPublicChannels
			{
				flags = (Channels_GetAdminedPublicChannels.Flags)((by_location ? 0x1 : 0) | (check_limit ? 0x2 : 0)),
			});

		/// <summary>Ban/unban/kick a user in a <a href="https://corefork.telegram.org/api/channel">supergroup/channel</a>.		<para>See <a href="https://corefork.telegram.org/method/channels.editBanned"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/channels.editBanned#possible-errors">details</a>)</para></summary>
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

		/// <summary>Get the admin log of a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>		<para>See <a href="https://corefork.telegram.org/method/channels.getAdminLog"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/channels.getAdminLog#possible-errors">details</a>)</para></summary>
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

		/// <summary>Mark <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> message contents as read		<para>See <a href="https://corefork.telegram.org/method/channels.readMessageContents"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.readMessageContents#possible-errors">details</a>)</para></summary>
		/// <param name="channel"><a href="https://corefork.telegram.org/api/channel">Channel/supergroup</a></param>
		/// <param name="id">IDs of messages whose contents should be marked as read</param>
		public static Task<bool> Channels_ReadMessageContents(this Client client, InputChannelBase channel, int[] id)
			=> client.Invoke(new Channels_ReadMessageContents
			{
				channel = channel,
				id = id,
			});

		/// <summary>Delete the history of a <a href="https://corefork.telegram.org/api/channel">supergroup</a>		<para>See <a href="https://corefork.telegram.org/method/channels.deleteHistory"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.deleteHistory#possible-errors">details</a>)</para></summary>
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

		/// <summary>Get a list of <a href="https://corefork.telegram.org/api/channel">channels/supergroups</a> we left		<para>See <a href="https://corefork.telegram.org/method/channels.getLeftChannels"/></para>		<para>Possible <see cref="RpcException"/> codes: 403 (<a href="https://corefork.telegram.org/method/channels.getLeftChannels#possible-errors">details</a>)</para></summary>
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

		/// <summary>Associate a group to a channel as <a href="https://corefork.telegram.org/api/discussion">discussion group</a> for that channel		<para>See <a href="https://corefork.telegram.org/method/channels.setDiscussionGroup"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.setDiscussionGroup#possible-errors">details</a>)</para></summary>
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

		/// <summary>Edit location of geogroup		<para>See <a href="https://corefork.telegram.org/method/channels.editLocation"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.editLocation#possible-errors">details</a>)</para></summary>
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

		/// <summary>Convert a <a href="https://corefork.telegram.org/api/channel">supergroup</a> to a <a href="https://corefork.telegram.org/api/channel">gigagroup</a>, when requested by <a href="https://corefork.telegram.org/api/config#channel-suggestions">channel suggestions</a>.		<para>See <a href="https://corefork.telegram.org/method/channels.convertToGigagroup"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.convertToGigagroup#possible-errors">details</a>)</para></summary>
		/// <param name="channel">The <a href="https://corefork.telegram.org/api/channel">supergroup</a> to convert</param>
		public static Task<UpdatesBase> Channels_ConvertToGigagroup(this Client client, InputChannelBase channel)
			=> client.Invoke(new Channels_ConvertToGigagroup
			{
				channel = channel,
			});

		/// <summary>Mark a specific sponsored message as read		<para>See <a href="https://corefork.telegram.org/method/channels.viewSponsoredMessage"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.viewSponsoredMessage#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Peer</param>
		/// <param name="random_id">Message ID</param>
		public static Task<bool> Channels_ViewSponsoredMessage(this Client client, InputChannelBase channel, byte[] random_id)
			=> client.Invoke(new Channels_ViewSponsoredMessage
			{
				channel = channel,
				random_id = random_id,
			});

		/// <summary>Get a list of sponsored messages		<para>See <a href="https://corefork.telegram.org/method/channels.getSponsoredMessages"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.getSponsoredMessages#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Peer</param>
		public static Task<Messages_SponsoredMessages> Channels_GetSponsoredMessages(this Client client, InputChannelBase channel)
			=> client.Invoke(new Channels_GetSponsoredMessages
			{
				channel = channel,
			});

		/// <summary>Obtains a list of peers that can be used to send messages in a specific group		<para>See <a href="https://corefork.telegram.org/method/channels.getSendAs"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.getSendAs#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The group where we intend to send messages</param>
		public static Task<Channels_SendAsPeers> Channels_GetSendAs(this Client client, InputPeer peer)
			=> client.Invoke(new Channels_GetSendAs
			{
				peer = peer,
			});

		/// <summary>Delete all messages sent by a specific participant of a given supergroup		<para>See <a href="https://corefork.telegram.org/method/channels.deleteParticipantHistory"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.deleteParticipantHistory#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Supergroup</param>
		/// <param name="participant">The participant whose messages should be deleted</param>
		public static Task<Messages_AffectedHistory> Channels_DeleteParticipantHistory(this Client client, InputChannelBase channel, InputPeer participant)
			=> client.Invoke(new Channels_DeleteParticipantHistory
			{
				channel = channel,
				participant = participant,
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

		/// <summary>Clear bot commands for the specified bot scope and language code		<para>See <a href="https://corefork.telegram.org/method/bots.resetBotCommands"/> [bots: ✓]</para></summary>
		/// <param name="scope">Command scope</param>
		/// <param name="lang_code">Language code</param>
		public static Task<bool> Bots_ResetBotCommands(this Client client, BotCommandScope scope, string lang_code)
			=> client.Invoke(new Bots_ResetBotCommands
			{
				scope = scope,
				lang_code = lang_code,
			});

		/// <summary>Obtain a list of bot commands for the specified bot scope and language code		<para>See <a href="https://corefork.telegram.org/method/bots.getBotCommands"/> [bots: ✓]</para></summary>
		/// <param name="scope">Command scope</param>
		/// <param name="lang_code">Language code</param>
		public static Task<BotCommand[]> Bots_GetBotCommands(this Client client, BotCommandScope scope, string lang_code)
			=> client.Invoke(new Bots_GetBotCommands
			{
				scope = scope,
				lang_code = lang_code,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/bots.setBotMenuButton"/></para></summary>
		public static Task<bool> Bots_SetBotMenuButton(this Client client, InputUserBase user_id, BotMenuButtonBase button)
			=> client.Invoke(new Bots_SetBotMenuButton
			{
				user_id = user_id,
				button = button,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/bots.getBotMenuButton"/></para></summary>
		public static Task<BotMenuButtonBase> Bots_GetBotMenuButton(this Client client, InputUserBase user_id)
			=> client.Invoke(new Bots_GetBotMenuButton
			{
				user_id = user_id,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/bots.setBotBroadcastDefaultAdminRights"/></para></summary>
		public static Task<bool> Bots_SetBotBroadcastDefaultAdminRights(this Client client, ChatAdminRights admin_rights)
			=> client.Invoke(new Bots_SetBotBroadcastDefaultAdminRights
			{
				admin_rights = admin_rights,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/bots.setBotGroupDefaultAdminRights"/></para></summary>
		public static Task<bool> Bots_SetBotGroupDefaultAdminRights(this Client client, ChatAdminRights admin_rights)
			=> client.Invoke(new Bots_SetBotGroupDefaultAdminRights
			{
				admin_rights = admin_rights,
			});

		/// <summary>Get a payment form		<para>See <a href="https://corefork.telegram.org/method/payments.getPaymentForm"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.getPaymentForm#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The peer where the payment form was sent</param>
		/// <param name="msg_id">Message ID of payment form</param>
		/// <param name="theme_params">A JSON object with the following keys, containing color theme information (integers, RGB24) to pass to the payment provider, to apply in eventual verification pages: <br/><c>bg_color</c> - Background color <br/><c>text_color</c> - Text color <br/><c>hint_color</c> - Hint text color <br/><c>link_color</c> - Link color <br/><c>button_color</c> - Button color <br/><c>button_text_color</c> - Button text color</param>
		public static Task<Payments_PaymentForm> Payments_GetPaymentForm(this Client client, InputPeer peer, int msg_id, DataJSON theme_params = null)
			=> client.Invoke(new Payments_GetPaymentForm
			{
				flags = (Payments_GetPaymentForm.Flags)(theme_params != null ? 0x1 : 0),
				peer = peer,
				msg_id = msg_id,
				theme_params = theme_params,
			});

		/// <summary>Get payment receipt		<para>See <a href="https://corefork.telegram.org/method/payments.getPaymentReceipt"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.getPaymentReceipt#possible-errors">details</a>)</para></summary>
		/// <param name="peer">The peer where the payment receipt was sent</param>
		/// <param name="msg_id">Message ID of receipt</param>
		public static Task<Payments_PaymentReceipt> Payments_GetPaymentReceipt(this Client client, InputPeer peer, int msg_id)
			=> client.Invoke(new Payments_GetPaymentReceipt
			{
				peer = peer,
				msg_id = msg_id,
			});

		/// <summary>Submit requested order information for validation		<para>See <a href="https://corefork.telegram.org/method/payments.validateRequestedInfo"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.validateRequestedInfo#possible-errors">details</a>)</para></summary>
		/// <param name="save">Save order information to re-use it for future orders</param>
		/// <param name="peer">Peer where the payment form was sent</param>
		/// <param name="msg_id">Message ID of payment form</param>
		/// <param name="info">Requested order information</param>
		public static Task<Payments_ValidatedRequestedInfo> Payments_ValidateRequestedInfo(this Client client, InputPeer peer, int msg_id, PaymentRequestedInfo info, bool save = false)
			=> client.Invoke(new Payments_ValidateRequestedInfo
			{
				flags = (Payments_ValidateRequestedInfo.Flags)(save ? 0x1 : 0),
				peer = peer,
				msg_id = msg_id,
				info = info,
			});

		/// <summary>Send compiled payment form		<para>See <a href="https://corefork.telegram.org/method/payments.sendPaymentForm"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/payments.sendPaymentForm#possible-errors">details</a>)</para></summary>
		/// <param name="form_id">Form ID</param>
		/// <param name="peer">The peer where the payment form was sent</param>
		/// <param name="msg_id">Message ID of form</param>
		/// <param name="requested_info_id">ID of saved and validated <see cref="Payments_ValidatedRequestedInfo"/></param>
		/// <param name="shipping_option_id">Chosen shipping option ID</param>
		/// <param name="credentials">Payment credentials</param>
		/// <param name="tip_amount">Tip, in the smallest units of the currency (integer, not float/double). For example, for a price of <c>US$ 1.45</c> pass <c>amount = 145</c>. See the exp parameter in <a href="https://corefork.telegram.org/bots/payments/currencies.json">currencies.json</a>, it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).</param>
		public static Task<Payments_PaymentResultBase> Payments_SendPaymentForm(this Client client, long form_id, InputPeer peer, int msg_id, InputPaymentCredentialsBase credentials, string requested_info_id = null, string shipping_option_id = null, long? tip_amount = null)
			=> client.Invoke(new Payments_SendPaymentForm
			{
				flags = (Payments_SendPaymentForm.Flags)((requested_info_id != null ? 0x1 : 0) | (shipping_option_id != null ? 0x2 : 0) | (tip_amount != null ? 0x4 : 0)),
				form_id = form_id,
				peer = peer,
				msg_id = msg_id,
				requested_info_id = requested_info_id,
				shipping_option_id = shipping_option_id,
				credentials = credentials,
				tip_amount = tip_amount.GetValueOrDefault(),
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

		/// <summary>Create a stickerset, bots only.		<para>See <a href="https://corefork.telegram.org/method/stickers.createStickerSet"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stickers.createStickerSet#possible-errors">details</a>)</para></summary>
		/// <param name="masks">Whether this is a mask stickerset</param>
		/// <param name="animated">Whether this is an animated stickerset</param>
		/// <param name="videos">Whether this is a video stickerset</param>
		/// <param name="user_id">Stickerset owner</param>
		/// <param name="title">Stickerset name, <c>1-64</c> chars</param>
		/// <param name="short_name">Sticker set name. Can contain only English letters, digits and underscores. Must end with <em>"</em>by<em><bot username="">"</bot></em> (<em><bot_username></bot_username></em> is case insensitive); 1-64 characters</param>
		/// <param name="thumb">Thumbnail</param>
		/// <param name="stickers">Stickers</param>
		/// <param name="software">Used when <a href="https://corefork.telegram.org/import-stickers">importing stickers using the sticker import SDKs</a>, specifies the name of the software that created the stickers</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.stickerSetNotModified">messages.stickerSetNotModified</a></returns>
		public static Task<Messages_StickerSet> Stickers_CreateStickerSet(this Client client, InputUserBase user_id, string title, string short_name, InputStickerSetItem[] stickers, bool masks = false, bool animated = false, bool videos = false, InputDocument thumb = null, string software = null)
			=> client.Invoke(new Stickers_CreateStickerSet
			{
				flags = (Stickers_CreateStickerSet.Flags)((masks ? 0x1 : 0) | (animated ? 0x2 : 0) | (videos ? 0x10 : 0) | (thumb != null ? 0x4 : 0) | (software != null ? 0x8 : 0)),
				user_id = user_id,
				title = title,
				short_name = short_name,
				thumb = thumb,
				stickers = stickers,
				software = software,
			});

		/// <summary>Remove a sticker from the set where it belongs, bots only. The sticker set must have been created by the bot.		<para>See <a href="https://corefork.telegram.org/method/stickers.removeStickerFromSet"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stickers.removeStickerFromSet#possible-errors">details</a>)</para></summary>
		/// <param name="sticker">The sticker to remove</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.stickerSetNotModified">messages.stickerSetNotModified</a></returns>
		public static Task<Messages_StickerSet> Stickers_RemoveStickerFromSet(this Client client, InputDocument sticker)
			=> client.Invoke(new Stickers_RemoveStickerFromSet
			{
				sticker = sticker,
			});

		/// <summary>Changes the absolute position of a sticker in the set to which it belongs; for bots only. The sticker set must have been created by the bot		<para>See <a href="https://corefork.telegram.org/method/stickers.changeStickerPosition"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stickers.changeStickerPosition#possible-errors">details</a>)</para></summary>
		/// <param name="sticker">The sticker</param>
		/// <param name="position">The new position of the sticker, zero-based</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.stickerSetNotModified">messages.stickerSetNotModified</a></returns>
		public static Task<Messages_StickerSet> Stickers_ChangeStickerPosition(this Client client, InputDocument sticker, int position)
			=> client.Invoke(new Stickers_ChangeStickerPosition
			{
				sticker = sticker,
				position = position,
			});

		/// <summary>Add a sticker to a stickerset, bots only. The sticker set must have been created by the bot.		<para>See <a href="https://corefork.telegram.org/method/stickers.addStickerToSet"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stickers.addStickerToSet#possible-errors">details</a>)</para></summary>
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
		/// <param name="thumb">Thumbnail</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.stickerSetNotModified">messages.stickerSetNotModified</a></returns>
		public static Task<Messages_StickerSet> Stickers_SetStickerSetThumb(this Client client, InputStickerSet stickerset, InputDocument thumb)
			=> client.Invoke(new Stickers_SetStickerSetThumb
			{
				stickerset = stickerset,
				thumb = thumb,
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

		/// <summary>Get phone call configuration to be passed to libtgvoip's shared config		<para>See <a href="https://corefork.telegram.org/method/phone.getCallConfig"/></para></summary>
		public static Task<DataJSON> Phone_GetCallConfig(this Client client)
			=> client.Invoke(new Phone_GetCallConfig
			{
			});

		/// <summary>Start a telegram phone call		<para>See <a href="https://corefork.telegram.org/method/phone.requestCall"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403,500 (<a href="https://corefork.telegram.org/method/phone.requestCall#possible-errors">details</a>)</para></summary>
		/// <param name="video">Whether to start a video call</param>
		/// <param name="user_id">Destination of the phone call</param>
		/// <param name="random_id">Random ID to avoid resending the same object</param>
		/// <param name="g_a_hash"><a href="https://corefork.telegram.org/api/end-to-end/voice-calls">Parameter for E2E encryption key exchange »</a></param>
		/// <param name="protocol">Phone call settings</param>
		public static Task<Phone_PhoneCall> Phone_RequestCall(this Client client, InputUserBase user_id, int random_id, byte[] g_a_hash, PhoneCallProtocol protocol, bool video = false)
			=> client.Invoke(new Phone_RequestCall
			{
				flags = (Phone_RequestCall.Flags)(video ? 0x1 : 0),
				user_id = user_id,
				random_id = random_id,
				g_a_hash = g_a_hash,
				protocol = protocol,
			});

		/// <summary>Accept incoming call		<para>See <a href="https://corefork.telegram.org/method/phone.acceptCall"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,500 (<a href="https://corefork.telegram.org/method/phone.acceptCall#possible-errors">details</a>)</para></summary>
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

		/// <summary>Refuse or end running call		<para>See <a href="https://corefork.telegram.org/method/phone.discardCall"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/phone.discardCall#possible-errors">details</a>)</para></summary>
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

		/// <summary>Rate a call		<para>See <a href="https://corefork.telegram.org/method/phone.setCallRating"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/phone.setCallRating#possible-errors">details</a>)</para></summary>
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

		/// <summary>Send VoIP signaling data		<para>See <a href="https://corefork.telegram.org/method/phone.sendSignalingData"/></para></summary>
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
		public static Task<UpdatesBase> Phone_CreateGroupCall(this Client client, InputPeer peer, int random_id, bool rtmp_stream = false, string title = null, DateTime? schedule_date = null)
			=> client.Invoke(new Phone_CreateGroupCall
			{
				flags = (Phone_CreateGroupCall.Flags)((rtmp_stream ? 0x4 : 0) | (title != null ? 0x1 : 0) | (schedule_date != null ? 0x2 : 0)),
				peer = peer,
				random_id = random_id,
				title = title,
				schedule_date = schedule_date.GetValueOrDefault(),
			});

		/// <summary>Join a group call		<para>See <a href="https://corefork.telegram.org/method/phone.joinGroupCall"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/phone.joinGroupCall#possible-errors">details</a>)</para></summary>
		/// <param name="muted">If set, the user will be muted by default upon joining.</param>
		/// <param name="video_stopped">If set, the user's video will be disabled by default upon joining.</param>
		/// <param name="call">The group call</param>
		/// <param name="join_as">Join the group call, presenting yourself as the specified user/channel</param>
		/// <param name="invite_hash">The invitation hash from the invite link: <c>https://t.me/username?voicechat=hash</c></param>
		/// <param name="params_">WebRTC parameters</param>
		public static Task<UpdatesBase> Phone_JoinGroupCall(this Client client, InputGroupCall call, InputPeer join_as, DataJSON params_, bool muted = false, bool video_stopped = false, string invite_hash = null)
			=> client.Invoke(new Phone_JoinGroupCall
			{
				flags = (Phone_JoinGroupCall.Flags)((muted ? 0x1 : 0) | (video_stopped ? 0x4 : 0) | (invite_hash != null ? 0x2 : 0)),
				call = call,
				join_as = join_as,
				invite_hash = invite_hash,
				params_ = params_,
			});

		/// <summary>Leave a group call		<para>See <a href="https://corefork.telegram.org/method/phone.leaveGroupCall"/></para></summary>
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

		/// <summary>Terminate a group call		<para>See <a href="https://corefork.telegram.org/method/phone.discardGroupCall"/></para></summary>
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
		public static Task<UpdatesBase> Phone_ToggleGroupCallSettings(this Client client, InputGroupCall call, bool reset_invite_hash = false, bool? join_muted = default)
			=> client.Invoke(new Phone_ToggleGroupCallSettings
			{
				flags = (Phone_ToggleGroupCallSettings.Flags)((reset_invite_hash ? 0x2 : 0) | (join_muted != default ? 0x1 : 0)),
				call = call,
				join_muted = join_muted.GetValueOrDefault(),
			});

		/// <summary>Get info about a group call		<para>See <a href="https://corefork.telegram.org/method/phone.getGroupCall"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/phone.getGroupCall#possible-errors">details</a>)</para></summary>
		/// <param name="call">The group call</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Phone_GroupCall> Phone_GetGroupCall(this Client client, InputGroupCall call, int limit = int.MaxValue)
			=> client.Invoke(new Phone_GetGroupCall
			{
				call = call,
				limit = limit,
			});

		/// <summary>Get group call participants		<para>See <a href="https://corefork.telegram.org/method/phone.getGroupParticipants"/></para></summary>
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

		/// <summary>Check whether the group call Server Forwarding Unit is currently receiving the streams with the specified WebRTC source IDs		<para>See <a href="https://corefork.telegram.org/method/phone.checkGroupCall"/></para></summary>
		/// <param name="call">Group call</param>
		/// <param name="sources">Source IDs</param>
		public static Task<int[]> Phone_CheckGroupCall(this Client client, InputGroupCall call, int[] sources)
			=> client.Invoke(new Phone_CheckGroupCall
			{
				call = call,
				sources = sources,
			});

		/// <summary>Start or stop recording a group call: the recorded audio and video streams will be automatically sent to <c>Saved messages</c> (the chat with ourselves).		<para>See <a href="https://corefork.telegram.org/method/phone.toggleGroupCallRecord"/></para></summary>
		/// <param name="start">Whether to start or stop recording</param>
		/// <param name="video">Whether to also record video streams</param>
		/// <param name="call">The group call or livestream</param>
		/// <param name="title">Recording title</param>
		/// <param name="video_portrait">If video stream recording is enabled, whether to record in portrait or landscape mode</param>
		public static Task<UpdatesBase> Phone_ToggleGroupCallRecord(this Client client, InputGroupCall call, bool start = false, bool video = false, string title = null, bool? video_portrait = default)
			=> client.Invoke(new Phone_ToggleGroupCallRecord
			{
				flags = (Phone_ToggleGroupCallRecord.Flags)((start ? 0x1 : 0) | (video ? 0x4 : 0) | (title != null ? 0x2 : 0) | (video_portrait != default ? 0x4 : 0)),
				call = call,
				title = title,
				video_portrait = video_portrait.GetValueOrDefault(),
			});

		/// <summary>Edit information about a given group call participant		<para>See <a href="https://corefork.telegram.org/method/phone.editGroupCallParticipant"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/phone.editGroupCallParticipant#possible-errors">details</a>)</para></summary>
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
				muted = muted.GetValueOrDefault(),
				volume = volume.GetValueOrDefault(),
				raise_hand = raise_hand.GetValueOrDefault(),
				video_stopped = video_stopped.GetValueOrDefault(),
				video_paused = video_paused.GetValueOrDefault(),
				presentation_paused = presentation_paused.GetValueOrDefault(),
			});

		/// <summary>Edit the title of a group call or livestream		<para>See <a href="https://corefork.telegram.org/method/phone.editGroupCallTitle"/></para></summary>
		/// <param name="call">Group call</param>
		/// <param name="title">New title</param>
		public static Task<UpdatesBase> Phone_EditGroupCallTitle(this Client client, InputGroupCall call, string title)
			=> client.Invoke(new Phone_EditGroupCallTitle
			{
				call = call,
				title = title,
			});

		/// <summary>Get a list of peers that can be used to join a group call, presenting yourself as a specific user/channel.		<para>See <a href="https://corefork.telegram.org/method/phone.getGroupCallJoinAs"/></para></summary>
		/// <param name="peer">The dialog whose group call or livestream we're trying to join</param>
		public static Task<Phone_JoinAsPeers> Phone_GetGroupCallJoinAs(this Client client, InputPeer peer)
			=> client.Invoke(new Phone_GetGroupCallJoinAs
			{
				peer = peer,
			});

		/// <summary>Get an invite link for a group call or livestream		<para>See <a href="https://corefork.telegram.org/method/phone.exportGroupCallInvite"/></para></summary>
		/// <param name="can_self_unmute">For livestreams, if set, users that join using this link will be able to speak without explicitly requesting permission by (for example by raising their hand).</param>
		/// <param name="call">The group call</param>
		public static Task<Phone_ExportedGroupCallInvite> Phone_ExportGroupCallInvite(this Client client, InputGroupCall call, bool can_self_unmute = false)
			=> client.Invoke(new Phone_ExportGroupCallInvite
			{
				flags = (Phone_ExportGroupCallInvite.Flags)(can_self_unmute ? 0x1 : 0),
				call = call,
			});

		/// <summary>Subscribe or unsubscribe to a scheduled group call		<para>See <a href="https://corefork.telegram.org/method/phone.toggleGroupCallStartSubscription"/></para></summary>
		/// <param name="call">Scheduled group call</param>
		/// <param name="subscribed">Enable or disable subscription</param>
		public static Task<UpdatesBase> Phone_ToggleGroupCallStartSubscription(this Client client, InputGroupCall call, bool subscribed)
			=> client.Invoke(new Phone_ToggleGroupCallStartSubscription
			{
				call = call,
				subscribed = subscribed,
			});

		/// <summary>Start a scheduled group call.		<para>See <a href="https://corefork.telegram.org/method/phone.startScheduledGroupCall"/></para></summary>
		/// <param name="call">The scheduled group call</param>
		public static Task<UpdatesBase> Phone_StartScheduledGroupCall(this Client client, InputGroupCall call)
			=> client.Invoke(new Phone_StartScheduledGroupCall
			{
				call = call,
			});

		/// <summary>Set the default peer that will be used to join a group call in a specific dialog.		<para>See <a href="https://corefork.telegram.org/method/phone.saveDefaultGroupCallJoinAs"/></para></summary>
		/// <param name="peer">The dialog</param>
		/// <param name="join_as">The default peer that will be used to join group calls in this dialog, presenting yourself as a specific user/channel.</param>
		public static Task<bool> Phone_SaveDefaultGroupCallJoinAs(this Client client, InputPeer peer, InputPeer join_as)
			=> client.Invoke(new Phone_SaveDefaultGroupCallJoinAs
			{
				peer = peer,
				join_as = join_as,
			});

		/// <summary>Start screen sharing in a call		<para>See <a href="https://corefork.telegram.org/method/phone.joinGroupCallPresentation"/></para>		<para>Possible <see cref="RpcException"/> codes: 403 (<a href="https://corefork.telegram.org/method/phone.joinGroupCallPresentation#possible-errors">details</a>)</para></summary>
		/// <param name="call">The group call</param>
		/// <param name="params_">WebRTC parameters</param>
		public static Task<UpdatesBase> Phone_JoinGroupCallPresentation(this Client client, InputGroupCall call, DataJSON params_)
			=> client.Invoke(new Phone_JoinGroupCallPresentation
			{
				call = call,
				params_ = params_,
			});

		/// <summary>Stop screen sharing in a group call		<para>See <a href="https://corefork.telegram.org/method/phone.leaveGroupCallPresentation"/></para></summary>
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

		/// <summary>Get RTMP URL and stream key for RTMP livestreams. Can be used even before creating the actual RTMP livestream with <a href="https://corefork.telegram.org/method/phone.createGroupCall">phone.createGroupCall</a> (the <c>rtmp_stream</c> flag must be set).		<para>See <a href="https://corefork.telegram.org/method/phone.getGroupCallStreamRtmpUrl"/></para></summary>
		/// <param name="peer">Peer to livestream into</param>
		/// <param name="revoke">Whether to revoke the previous stream key or simply return the existing one</param>
		public static Task<Phone_GroupCallStreamRtmpUrl> Phone_GetGroupCallStreamRtmpUrl(this Client client, InputPeer peer, bool revoke)
			=> client.Invoke(new Phone_GetGroupCallStreamRtmpUrl
			{
				peer = peer,
				revoke = revoke,
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/phone.saveCallLog"/></para></summary>
		public static Task<bool> Phone_SaveCallLog(this Client client, InputPhoneCall peer, InputFileBase file)
			=> client.Invoke(new Phone_SaveCallLog
			{
				peer = peer,
				file = file,
			});

		/// <summary>Get localization pack strings		<para>See <a href="https://corefork.telegram.org/method/langpack.getLangPack"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/langpack.getLangPack#possible-errors">details</a>)</para></summary>
		/// <param name="lang_pack">Language pack name</param>
		/// <param name="lang_code">Language code</param>
		public static Task<LangPackDifference> Langpack_GetLangPack(this Client client, string lang_pack, string lang_code)
			=> client.Invoke(new Langpack_GetLangPack
			{
				lang_pack = lang_pack,
				lang_code = lang_code,
			});

		/// <summary>Get strings from a language pack		<para>See <a href="https://corefork.telegram.org/method/langpack.getStrings"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/langpack.getStrings#possible-errors">details</a>)</para></summary>
		/// <param name="lang_pack">Language pack name</param>
		/// <param name="lang_code">Language code</param>
		/// <param name="keys">Strings to get</param>
		public static Task<LangPackStringBase[]> Langpack_GetStrings(this Client client, string lang_pack, string lang_code, string[] keys)
			=> client.Invoke(new Langpack_GetStrings
			{
				lang_pack = lang_pack,
				lang_code = lang_code,
				keys = keys,
			});

		/// <summary>Get new strings in language pack		<para>See <a href="https://corefork.telegram.org/method/langpack.getDifference"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/langpack.getDifference#possible-errors">details</a>)</para></summary>
		/// <param name="lang_pack">Language pack</param>
		/// <param name="lang_code">Language code</param>
		/// <param name="from_version">Previous localization pack version</param>
		public static Task<LangPackDifference> Langpack_GetDifference(this Client client, string lang_pack, string lang_code, int from_version)
			=> client.Invoke(new Langpack_GetDifference
			{
				lang_pack = lang_pack,
				lang_code = lang_code,
				from_version = from_version,
			});

		/// <summary>Get information about all languages in a localization pack		<para>See <a href="https://corefork.telegram.org/method/langpack.getLanguages"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/langpack.getLanguages#possible-errors">details</a>)</para></summary>
		/// <param name="lang_pack">Language pack</param>
		public static Task<LangPackLanguage[]> Langpack_GetLanguages(this Client client, string lang_pack)
			=> client.Invoke(new Langpack_GetLanguages
			{
				lang_pack = lang_pack,
			});

		/// <summary>Get information about a language in a localization pack		<para>See <a href="https://corefork.telegram.org/method/langpack.getLanguage"/></para></summary>
		/// <param name="lang_pack">Language pack name</param>
		/// <param name="lang_code">Language code</param>
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

		/// <summary>Delete a <a href="https://corefork.telegram.org/api/folders#peer-folders">peer folder</a>		<para>See <a href="https://corefork.telegram.org/method/folders.deleteFolder"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/folders.deleteFolder#possible-errors">details</a>)</para></summary>
		/// <param name="folder_id"><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></param>
		public static Task<UpdatesBase> Folders_DeleteFolder(this Client client, int folder_id)
			=> client.Invoke(new Folders_DeleteFolder
			{
				folder_id = folder_id,
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/stats">channel statistics</a>		<para>See <a href="https://corefork.telegram.org/method/stats.getBroadcastStats"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stats.getBroadcastStats#possible-errors">details</a>)</para></summary>
		/// <param name="dark">Whether to enable dark theme for graph colors</param>
		/// <param name="channel">The channel</param>
		public static Task<Stats_BroadcastStats> Stats_GetBroadcastStats(this Client client, InputChannelBase channel, bool dark = false)
			=> client.Invoke(new Stats_GetBroadcastStats
			{
				flags = (Stats_GetBroadcastStats.Flags)(dark ? 0x1 : 0),
				channel = channel,
			});

		/// <summary>Load <a href="https://corefork.telegram.org/api/stats">channel statistics graph</a> asynchronously		<para>See <a href="https://corefork.telegram.org/method/stats.loadAsyncGraph"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stats.loadAsyncGraph#possible-errors">details</a>)</para></summary>
		/// <param name="token">Graph token from <see cref="StatsGraphAsync"/> constructor</param>
		/// <param name="x">Zoom value, if required</param>
		public static Task<StatsGraphBase> Stats_LoadAsyncGraph(this Client client, string token, long? x = null)
			=> client.Invoke(new Stats_LoadAsyncGraph
			{
				flags = (Stats_LoadAsyncGraph.Flags)(x != null ? 0x1 : 0),
				token = token,
				x = x.GetValueOrDefault(),
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/stats">supergroup statistics</a>		<para>See <a href="https://corefork.telegram.org/method/stats.getMegagroupStats"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stats.getMegagroupStats#possible-errors">details</a>)</para></summary>
		/// <param name="dark">Whether to enable dark theme for graph colors</param>
		/// <param name="channel"><a href="https://corefork.telegram.org/api/channel">Supergroup ID</a></param>
		public static Task<Stats_MegagroupStats> Stats_GetMegagroupStats(this Client client, InputChannelBase channel, bool dark = false)
			=> client.Invoke(new Stats_GetMegagroupStats
			{
				flags = (Stats_GetMegagroupStats.Flags)(dark ? 0x1 : 0),
				channel = channel,
			});

		/// <summary>Obtains a list of messages, indicating to which other public channels was a channel message forwarded.<br/>Will return a list of <see cref="Message"/> with <c>peer_id</c> equal to the public channel to which this message was forwarded.		<para>See <a href="https://corefork.telegram.org/method/stats.getMessagePublicForwards"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/stats.getMessagePublicForwards#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Source channel</param>
		/// <param name="msg_id">Source message ID</param>
		/// <param name="offset_rate">Initially 0, then set to the <c>next_rate</c> parameter of <see cref="Messages_MessagesSlice"/></param>
		/// <param name="offset_peer"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Messages_MessagesBase> Stats_GetMessagePublicForwards(this Client client, InputChannelBase channel, int msg_id, int offset_rate = default, InputPeer offset_peer = null, int offset_id = default, int limit = int.MaxValue)
			=> client.Invoke(new Stats_GetMessagePublicForwards
			{
				channel = channel,
				msg_id = msg_id,
				offset_rate = offset_rate,
				offset_peer = offset_peer,
				offset_id = offset_id,
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
	}
}

namespace TL.Methods
{
	[TLDef(0xCB9F372D)]
	public class InvokeAfterMsg<X> : IMethod<X>
	{
		public long msg_id;
		public IMethod<X> query;
	}

	[TLDef(0x3DC4B4F0)]
	public class InvokeAfterMsgs<X> : IMethod<X>
	{
		public long[] msg_ids;
		public IMethod<X> query;
	}

	[TLDef(0xC1CD5EA9)]
	public class InitConnection<X> : IMethod<X>
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
	public class InvokeWithLayer<X> : IMethod<X>
	{
		public int layer;
		public IMethod<X> query;
	}

	[TLDef(0xBF9459B7)]
	public class InvokeWithoutUpdates<X> : IMethod<X>
	{
		public IMethod<X> query;
	}

	[TLDef(0x365275F2)]
	public class InvokeWithMessagesRange<X> : IMethod<X>
	{
		public MessageRange range;
		public IMethod<X> query;
	}

	[TLDef(0xACA9FD2E)]
	public class InvokeWithTakeout<X> : IMethod<X>
	{
		public long takeout_id;
		public IMethod<X> query;
	}

	[TLDef(0xA677244F)]
	public class Auth_SendCode : IMethod<Auth_SentCode>
	{
		public string phone_number;
		public int api_id;
		public string api_hash;
		public CodeSettings settings;
	}

	[TLDef(0x80EEE427)]
	public class Auth_SignUp : IMethod<Auth_AuthorizationBase>
	{
		public string phone_number;
		public string phone_code_hash;
		public string first_name;
		public string last_name;
	}

	[TLDef(0xBCD51581)]
	public class Auth_SignIn : IMethod<Auth_AuthorizationBase>
	{
		public string phone_number;
		public string phone_code_hash;
		public string phone_code;
	}

	[TLDef(0x3E72BA19)]
	public class Auth_LogOut : IMethod<Auth_LoggedOut> { }

	[TLDef(0x9FAB0D1A)]
	public class Auth_ResetAuthorizations : IMethod<bool> { }

	[TLDef(0xE5BFFFCD)]
	public class Auth_ExportAuthorization : IMethod<Auth_ExportedAuthorization>
	{
		public int dc_id;
	}

	[TLDef(0xA57A7DAD)]
	public class Auth_ImportAuthorization : IMethod<Auth_AuthorizationBase>
	{
		public long id;
		public byte[] bytes;
	}

	[TLDef(0xCDD42A05)]
	public class Auth_BindTempAuthKey : IMethod<bool>
	{
		public long perm_auth_key_id;
		public long nonce;
		public DateTime expires_at;
		public byte[] encrypted_message;
	}

	[TLDef(0x67A3FF2C)]
	public class Auth_ImportBotAuthorization : IMethod<Auth_AuthorizationBase>
	{
		public int flags;
		public int api_id;
		public string api_hash;
		public string bot_auth_token;
	}

	[TLDef(0xD18B4D16)]
	public class Auth_CheckPassword : IMethod<Auth_AuthorizationBase>
	{
		public InputCheckPasswordSRP password;
	}

	[TLDef(0xD897BC66)]
	public class Auth_RequestPasswordRecovery : IMethod<Auth_PasswordRecovery> { }

	[TLDef(0x37096C70)]
	public class Auth_RecoverPassword : IMethod<Auth_AuthorizationBase>
	{
		public Flags flags;
		public string code;
		[IfFlag(0)] public Account_PasswordInputSettings new_settings;

		[Flags] public enum Flags : uint
		{
			has_new_settings = 0x1,
		}
	}

	[TLDef(0x3EF1A9BF)]
	public class Auth_ResendCode : IMethod<Auth_SentCode>
	{
		public string phone_number;
		public string phone_code_hash;
	}

	[TLDef(0x1F040578)]
	public class Auth_CancelCode : IMethod<bool>
	{
		public string phone_number;
		public string phone_code_hash;
	}

	[TLDef(0x8E48A188)]
	public class Auth_DropTempAuthKeys : IMethod<bool>
	{
		public long[] except_auth_keys;
	}

	[TLDef(0xB7E085FE)]
	public class Auth_ExportLoginToken : IMethod<Auth_LoginTokenBase>
	{
		public int api_id;
		public string api_hash;
		public long[] except_ids;
	}

	[TLDef(0x95AC5CE4)]
	public class Auth_ImportLoginToken : IMethod<Auth_LoginTokenBase>
	{
		public byte[] token;
	}

	[TLDef(0xE894AD4D)]
	public class Auth_AcceptLoginToken : IMethod<Authorization>
	{
		public byte[] token;
	}

	[TLDef(0x0D36BF79)]
	public class Auth_CheckRecoveryPassword : IMethod<bool>
	{
		public string code;
	}

	[TLDef(0xEC86017A)]
	public class Account_RegisterDevice : IMethod<bool>
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
	public class Account_UnregisterDevice : IMethod<bool>
	{
		public int token_type;
		public string token;
		public long[] other_uids;
	}

	[TLDef(0x84BE5B93)]
	public class Account_UpdateNotifySettings : IMethod<bool>
	{
		public InputNotifyPeerBase peer;
		public InputPeerNotifySettings settings;
	}

	[TLDef(0x12B3AD31)]
	public class Account_GetNotifySettings : IMethod<PeerNotifySettings>
	{
		public InputNotifyPeerBase peer;
	}

	[TLDef(0xDB7E1747)]
	public class Account_ResetNotifySettings : IMethod<bool> { }

	[TLDef(0x78515775)]
	public class Account_UpdateProfile : IMethod<UserBase>
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
	public class Account_UpdateStatus : IMethod<bool>
	{
		public bool offline;
	}

	[TLDef(0x07967D36)]
	public class Account_GetWallPapers : IMethod<Account_WallPapers>
	{
		public long hash;
	}

	[TLDef(0xC5BA3D86)]
	public class Account_ReportPeer : IMethod<bool>
	{
		public InputPeer peer;
		public ReportReason reason;
		public string message;
	}

	[TLDef(0x2714D86C)]
	public class Account_CheckUsername : IMethod<bool>
	{
		public string username;
	}

	[TLDef(0x3E0BDD7C)]
	public class Account_UpdateUsername : IMethod<UserBase>
	{
		public string username;
	}

	[TLDef(0xDADBC950)]
	public class Account_GetPrivacy : IMethod<Account_PrivacyRules>
	{
		public InputPrivacyKey key;
	}

	[TLDef(0xC9F81CE8)]
	public class Account_SetPrivacy : IMethod<Account_PrivacyRules>
	{
		public InputPrivacyKey key;
		public InputPrivacyRule[] rules;
	}

	[TLDef(0x418D4E0B)]
	public class Account_DeleteAccount : IMethod<bool>
	{
		public string reason;
	}

	[TLDef(0x08FC711D)]
	public class Account_GetAccountTTL : IMethod<AccountDaysTTL> { }

	[TLDef(0x2442485E)]
	public class Account_SetAccountTTL : IMethod<bool>
	{
		public AccountDaysTTL ttl;
	}

	[TLDef(0x82574AE5)]
	public class Account_SendChangePhoneCode : IMethod<Auth_SentCode>
	{
		public string phone_number;
		public CodeSettings settings;
	}

	[TLDef(0x70C32EDB)]
	public class Account_ChangePhone : IMethod<UserBase>
	{
		public string phone_number;
		public string phone_code_hash;
		public string phone_code;
	}

	[TLDef(0x38DF3532)]
	public class Account_UpdateDeviceLocked : IMethod<bool>
	{
		public int period;
	}

	[TLDef(0xE320C158)]
	public class Account_GetAuthorizations : IMethod<Account_Authorizations> { }

	[TLDef(0xDF77F3BC)]
	public class Account_ResetAuthorization : IMethod<bool>
	{
		public long hash;
	}

	[TLDef(0x548A30F5)]
	public class Account_GetPassword : IMethod<Account_Password> { }

	[TLDef(0x9CD4EAF9)]
	public class Account_GetPasswordSettings : IMethod<Account_PasswordSettings>
	{
		public InputCheckPasswordSRP password;
	}

	[TLDef(0xA59B102F)]
	public class Account_UpdatePasswordSettings : IMethod<bool>
	{
		public InputCheckPasswordSRP password;
		public Account_PasswordInputSettings new_settings;
	}

	[TLDef(0x1B3FAA88)]
	public class Account_SendConfirmPhoneCode : IMethod<Auth_SentCode>
	{
		public string hash;
		public CodeSettings settings;
	}

	[TLDef(0x5F2178C3)]
	public class Account_ConfirmPhone : IMethod<bool>
	{
		public string phone_code_hash;
		public string phone_code;
	}

	[TLDef(0x449E0B51)]
	public class Account_GetTmpPassword : IMethod<Account_TmpPassword>
	{
		public InputCheckPasswordSRP password;
		public int period;
	}

	[TLDef(0x182E6D6F)]
	public class Account_GetWebAuthorizations : IMethod<Account_WebAuthorizations> { }

	[TLDef(0x2D01B9EF)]
	public class Account_ResetWebAuthorization : IMethod<bool>
	{
		public long hash;
	}

	[TLDef(0x682D2594)]
	public class Account_ResetWebAuthorizations : IMethod<bool> { }

	[TLDef(0xB288BC7D)]
	public class Account_GetAllSecureValues : IMethod<SecureValue[]> { }

	[TLDef(0x73665BC2)]
	public class Account_GetSecureValue : IMethod<SecureValue[]>
	{
		public SecureValueType[] types;
	}

	[TLDef(0x899FE31D)]
	public class Account_SaveSecureValue : IMethod<SecureValue>
	{
		public InputSecureValue value;
		public long secure_secret_id;
	}

	[TLDef(0xB880BC4B)]
	public class Account_DeleteSecureValue : IMethod<bool>
	{
		public SecureValueType[] types;
	}

	[TLDef(0xA929597A)]
	public class Account_GetAuthorizationForm : IMethod<Account_AuthorizationForm>
	{
		public long bot_id;
		public string scope;
		public string public_key;
	}

	[TLDef(0xF3ED4C73)]
	public class Account_AcceptAuthorization : IMethod<bool>
	{
		public long bot_id;
		public string scope;
		public string public_key;
		public SecureValueHash[] value_hashes;
		public SecureCredentialsEncrypted credentials;
	}

	[TLDef(0xA5A356F9)]
	public class Account_SendVerifyPhoneCode : IMethod<Auth_SentCode>
	{
		public string phone_number;
		public CodeSettings settings;
	}

	[TLDef(0x4DD3A7F6)]
	public class Account_VerifyPhone : IMethod<bool>
	{
		public string phone_number;
		public string phone_code_hash;
		public string phone_code;
	}

	[TLDef(0x7011509F)]
	public class Account_SendVerifyEmailCode : IMethod<Account_SentEmailCode>
	{
		public string email;
	}

	[TLDef(0xECBA39DB)]
	public class Account_VerifyEmail : IMethod<bool>
	{
		public string email;
		public string code;
	}

	[TLDef(0xF05B4804)]
	public class Account_InitTakeoutSession : IMethod<Account_Takeout>
	{
		public Flags flags;
		[IfFlag(5)] public int file_max_size;

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
	public class Account_FinishTakeoutSession : IMethod<bool>
	{
		public Flags flags;

		[Flags] public enum Flags : uint
		{
			success = 0x1,
		}
	}

	[TLDef(0x8FDF1920)]
	public class Account_ConfirmPasswordEmail : IMethod<bool>
	{
		public string code;
	}

	[TLDef(0x7A7F2A15)]
	public class Account_ResendPasswordEmail : IMethod<bool> { }

	[TLDef(0xC1CBD5B6)]
	public class Account_CancelPasswordEmail : IMethod<bool> { }

	[TLDef(0x9F07C728)]
	public class Account_GetContactSignUpNotification : IMethod<bool> { }

	[TLDef(0xCFF43F61)]
	public class Account_SetContactSignUpNotification : IMethod<bool>
	{
		public bool silent;
	}

	[TLDef(0x53577479)]
	public class Account_GetNotifyExceptions : IMethod<UpdatesBase>
	{
		public Flags flags;
		[IfFlag(0)] public InputNotifyPeerBase peer;

		[Flags] public enum Flags : uint
		{
			has_peer = 0x1,
			compare_sound = 0x2,
		}
	}

	[TLDef(0xFC8DDBEA)]
	public class Account_GetWallPaper : IMethod<WallPaperBase>
	{
		public InputWallPaperBase wallpaper;
	}

	[TLDef(0xDD853661)]
	public class Account_UploadWallPaper : IMethod<WallPaperBase>
	{
		public InputFileBase file;
		public string mime_type;
		public WallPaperSettings settings;
	}

	[TLDef(0x6C5A5B37)]
	public class Account_SaveWallPaper : IMethod<bool>
	{
		public InputWallPaperBase wallpaper;
		public bool unsave;
		public WallPaperSettings settings;
	}

	[TLDef(0xFEED5769)]
	public class Account_InstallWallPaper : IMethod<bool>
	{
		public InputWallPaperBase wallpaper;
		public WallPaperSettings settings;
	}

	[TLDef(0xBB3B9804)]
	public class Account_ResetWallPapers : IMethod<bool> { }

	[TLDef(0x56DA0B3F)]
	public class Account_GetAutoDownloadSettings : IMethod<Account_AutoDownloadSettings> { }

	[TLDef(0x76F36233)]
	public class Account_SaveAutoDownloadSettings : IMethod<bool>
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
	public class Account_UploadTheme : IMethod<DocumentBase>
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
	public class Account_CreateTheme : IMethod<Theme>
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
	public class Account_UpdateTheme : IMethod<Theme>
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
	public class Account_SaveTheme : IMethod<bool>
	{
		public InputThemeBase theme;
		public bool unsave;
	}

	[TLDef(0xC727BB3B)]
	public class Account_InstallTheme : IMethod<bool>
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

	[TLDef(0x8D9D742B)]
	public class Account_GetTheme : IMethod<Theme>
	{
		public string format;
		public InputThemeBase theme;
		public long document_id;
	}

	[TLDef(0x7206E458)]
	public class Account_GetThemes : IMethod<Account_Themes>
	{
		public string format;
		public long hash;
	}

	[TLDef(0xB574B16B)]
	public class Account_SetContentSettings : IMethod<bool>
	{
		public Flags flags;

		[Flags] public enum Flags : uint
		{
			sensitive_enabled = 0x1,
		}
	}

	[TLDef(0x8B9B4DAE)]
	public class Account_GetContentSettings : IMethod<Account_ContentSettings> { }

	[TLDef(0x65AD71DC)]
	public class Account_GetMultiWallPapers : IMethod<WallPaperBase[]>
	{
		public InputWallPaperBase[] wallpapers;
	}

	[TLDef(0xEB2B4CF6)]
	public class Account_GetGlobalPrivacySettings : IMethod<GlobalPrivacySettings> { }

	[TLDef(0x1EDAAAC2)]
	public class Account_SetGlobalPrivacySettings : IMethod<GlobalPrivacySettings>
	{
		public GlobalPrivacySettings settings;
	}

	[TLDef(0xFA8CC6F5)]
	public class Account_ReportProfilePhoto : IMethod<bool>
	{
		public InputPeer peer;
		public InputPhoto photo_id;
		public ReportReason reason;
		public string message;
	}

	[TLDef(0x9308CE1B)]
	public class Account_ResetPassword : IMethod<Account_ResetPasswordResult> { }

	[TLDef(0x4C9409F6)]
	public class Account_DeclinePasswordReset : IMethod<bool> { }

	[TLDef(0xD638DE89)]
	public class Account_GetChatThemes : IMethod<Account_Themes>
	{
		public long hash;
	}

	[TLDef(0xBF899AA0)]
	public class Account_SetAuthorizationTTL : IMethod<bool>
	{
		public int authorization_ttl_days;
	}

	[TLDef(0x40F48462)]
	public class Account_ChangeAuthorizationSettings : IMethod<bool>
	{
		public Flags flags;
		public long hash;
		[IfFlag(0)] public bool encrypted_requests_disabled;
		[IfFlag(1)] public bool call_requests_disabled;

		[Flags] public enum Flags : uint
		{
			has_encrypted_requests_disabled = 0x1,
			has_call_requests_disabled = 0x2,
		}
	}

	[TLDef(0xE1902288)]
	public class Account_GetSavedRingtones : IMethod<Account_SavedRingtones>
	{
		public long hash;
	}

	[TLDef(0x3DEA5B03)]
	public class Account_SaveRingtone : IMethod<Account_SavedRingtone>
	{
		public InputDocument id;
		public bool unsave;
	}

	[TLDef(0x831A83A2)]
	public class Account_UploadRingtone : IMethod<DocumentBase>
	{
		public InputFileBase file;
		public string file_name;
		public string mime_type;
	}

	[TLDef(0x0D91A548)]
	public class Users_GetUsers : IMethod<UserBase[]>
	{
		public InputUserBase[] id;
	}

	[TLDef(0xB60F5918)]
	public class Users_GetFullUser : IMethod<Users_UserFull>
	{
		public InputUserBase id;
	}

	[TLDef(0x90C894B5)]
	public class Users_SetSecureValueErrors : IMethod<bool>
	{
		public InputUserBase id;
		public SecureValueErrorBase[] errors;
	}

	[TLDef(0x7ADC669D)]
	public class Contacts_GetContactIDs : IMethod<int[]>
	{
		public long hash;
	}

	[TLDef(0xC4A353EE)]
	public class Contacts_GetStatuses : IMethod<ContactStatus[]> { }

	[TLDef(0x5DD69E12)]
	public class Contacts_GetContacts : IMethod<Contacts_Contacts>
	{
		public long hash;
	}

	[TLDef(0x2C800BE5)]
	public class Contacts_ImportContacts : IMethod<Contacts_ImportedContacts>
	{
		public InputContact[] contacts;
	}

	[TLDef(0x096A0E00)]
	public class Contacts_DeleteContacts : IMethod<UpdatesBase>
	{
		public InputUserBase[] id;
	}

	[TLDef(0x1013FD9E)]
	public class Contacts_DeleteByPhones : IMethod<bool>
	{
		public string[] phones;
	}

	[TLDef(0x68CC1411)]
	public class Contacts_Block : IMethod<bool>
	{
		public InputPeer id;
	}

	[TLDef(0xBEA65D50)]
	public class Contacts_Unblock : IMethod<bool>
	{
		public InputPeer id;
	}

	[TLDef(0xF57C350F)]
	public class Contacts_GetBlocked : IMethod<Contacts_Blocked>
	{
		public int offset;
		public int limit;
	}

	[TLDef(0x11F812D8)]
	public class Contacts_Search : IMethod<Contacts_Found>
	{
		public string q;
		public int limit;
	}

	[TLDef(0xF93CCBA3)]
	public class Contacts_ResolveUsername : IMethod<Contacts_ResolvedPeer>
	{
		public string username;
	}

	[TLDef(0x973478B6)]
	public class Contacts_GetTopPeers : IMethod<Contacts_TopPeersBase>
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
		}
	}

	[TLDef(0x1AE373AC)]
	public class Contacts_ResetTopPeerRating : IMethod<bool>
	{
		public TopPeerCategory category;
		public InputPeer peer;
	}

	[TLDef(0x879537F1)]
	public class Contacts_ResetSaved : IMethod<bool> { }

	[TLDef(0x82F1E39F)]
	public class Contacts_GetSaved : IMethod<SavedContact[]> { }

	[TLDef(0x8514BDDA)]
	public class Contacts_ToggleTopPeers : IMethod<bool>
	{
		public bool enabled;
	}

	[TLDef(0xE8F463D0)]
	public class Contacts_AddContact : IMethod<UpdatesBase>
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
	public class Contacts_AcceptContact : IMethod<UpdatesBase>
	{
		public InputUserBase id;
	}

	[TLDef(0xD348BC44)]
	public class Contacts_GetLocated : IMethod<UpdatesBase>
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
	public class Contacts_BlockFromReplies : IMethod<UpdatesBase>
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
	public class Contacts_ResolvePhone : IMethod<Contacts_ResolvedPeer>
	{
		public string phone;
	}

	[TLDef(0x63C66506)]
	public class Messages_GetMessages : IMethod<Messages_MessagesBase>
	{
		public InputMessage[] id;
	}

	[TLDef(0xA0F4CB4F)]
	public class Messages_GetDialogs : IMethod<Messages_DialogsBase>
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
	public class Messages_GetHistory : IMethod<Messages_MessagesBase>
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

	[TLDef(0xA0FDA762)]
	public class Messages_Search : IMethod<Messages_MessagesBase>
	{
		public Flags flags;
		public InputPeer peer;
		public string q;
		[IfFlag(0)] public InputPeer from_id;
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
		}
	}

	[TLDef(0x0E306D3A)]
	public class Messages_ReadHistory : IMethod<Messages_AffectedMessages>
	{
		public InputPeer peer;
		public int max_id;
	}

	[TLDef(0xB08F922A)]
	public class Messages_DeleteHistory : IMethod<Messages_AffectedHistory>
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
	public class Messages_DeleteMessages : IMethod<Messages_AffectedMessages>
	{
		public Flags flags;
		public int[] id;

		[Flags] public enum Flags : uint
		{
			revoke = 0x1,
		}
	}

	[TLDef(0x05A954C0)]
	public class Messages_ReceivedMessages : IMethod<ReceivedNotifyMessage[]>
	{
		public int max_id;
	}

	[TLDef(0x58943EE2)]
	public class Messages_SetTyping : IMethod<bool>
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

	[TLDef(0x0D9D75A4)]
	public class Messages_SendMessage : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPeer peer;
		[IfFlag(0)] public int reply_to_msg_id;
		public string message;
		public long random_id;
		[IfFlag(2)] public ReplyMarkup reply_markup;
		[IfFlag(3)] public MessageEntity[] entities;
		[IfFlag(10)] public DateTime schedule_date;
		[IfFlag(13)] public InputPeer send_as;

		[Flags] public enum Flags : uint
		{
			has_reply_to_msg_id = 0x1,
			no_webpage = 0x2,
			has_reply_markup = 0x4,
			has_entities = 0x8,
			silent = 0x20,
			background = 0x40,
			clear_draft = 0x80,
			has_schedule_date = 0x400,
			has_send_as = 0x2000,
			noforwards = 0x4000,
		}
	}

	[TLDef(0xE25FF8E0)]
	public class Messages_SendMedia : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPeer peer;
		[IfFlag(0)] public int reply_to_msg_id;
		public InputMedia media;
		public string message;
		public long random_id;
		[IfFlag(2)] public ReplyMarkup reply_markup;
		[IfFlag(3)] public MessageEntity[] entities;
		[IfFlag(10)] public DateTime schedule_date;
		[IfFlag(13)] public InputPeer send_as;

		[Flags] public enum Flags : uint
		{
			has_reply_to_msg_id = 0x1,
			has_reply_markup = 0x4,
			has_entities = 0x8,
			silent = 0x20,
			background = 0x40,
			clear_draft = 0x80,
			has_schedule_date = 0x400,
			has_send_as = 0x2000,
			noforwards = 0x4000,
		}
	}

	[TLDef(0xCC30290B)]
	public class Messages_ForwardMessages : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPeer from_peer;
		public int[] id;
		public long[] random_id;
		public InputPeer to_peer;
		[IfFlag(10)] public DateTime schedule_date;
		[IfFlag(13)] public InputPeer send_as;

		[Flags] public enum Flags : uint
		{
			silent = 0x20,
			background = 0x40,
			with_my_score = 0x100,
			has_schedule_date = 0x400,
			drop_author = 0x800,
			drop_media_captions = 0x1000,
			has_send_as = 0x2000,
			noforwards = 0x4000,
		}
	}

	[TLDef(0xCF1592DB)]
	public class Messages_ReportSpam : IMethod<bool>
	{
		public InputPeer peer;
	}

	[TLDef(0xEFD9A6A2)]
	public class Messages_GetPeerSettings : IMethod<Messages_PeerSettings>
	{
		public InputPeer peer;
	}

	[TLDef(0x8953AB4E)]
	public class Messages_Report : IMethod<bool>
	{
		public InputPeer peer;
		public int[] id;
		public ReportReason reason;
		public string message;
	}

	[TLDef(0x49E9528F)]
	public class Messages_GetChats : IMethod<Messages_Chats>
	{
		public long[] id;
	}

	[TLDef(0xAEB00B34)]
	public class Messages_GetFullChat : IMethod<Messages_ChatFull>
	{
		public long chat_id;
	}

	[TLDef(0x73783FFD)]
	public class Messages_EditChatTitle : IMethod<UpdatesBase>
	{
		public long chat_id;
		public string title;
	}

	[TLDef(0x35DDD674)]
	public class Messages_EditChatPhoto : IMethod<UpdatesBase>
	{
		public long chat_id;
		public InputChatPhotoBase photo;
	}

	[TLDef(0xF24753E3)]
	public class Messages_AddChatUser : IMethod<UpdatesBase>
	{
		public long chat_id;
		public InputUserBase user_id;
		public int fwd_limit;
	}

	[TLDef(0xA2185CAB)]
	public class Messages_DeleteChatUser : IMethod<UpdatesBase>
	{
		public Flags flags;
		public long chat_id;
		public InputUserBase user_id;

		[Flags] public enum Flags : uint
		{
			revoke_history = 0x1,
		}
	}

	[TLDef(0x09CB126E)]
	public class Messages_CreateChat : IMethod<UpdatesBase>
	{
		public InputUserBase[] users;
		public string title;
	}

	[TLDef(0x26CF8950)]
	public class Messages_GetDhConfig : IMethod<Messages_DhConfigBase>
	{
		public int version;
		public int random_length;
	}

	[TLDef(0xF64DAF43)]
	public class Messages_RequestEncryption : IMethod<EncryptedChatBase>
	{
		public InputUserBase user_id;
		public int random_id;
		public byte[] g_a;
	}

	[TLDef(0x3DBC0415)]
	public class Messages_AcceptEncryption : IMethod<EncryptedChatBase>
	{
		public InputEncryptedChat peer;
		public byte[] g_b;
		public long key_fingerprint;
	}

	[TLDef(0xF393AEA0)]
	public class Messages_DiscardEncryption : IMethod<bool>
	{
		public Flags flags;
		public int chat_id;

		[Flags] public enum Flags : uint
		{
			delete_history = 0x1,
		}
	}

	[TLDef(0x791451ED)]
	public class Messages_SetEncryptedTyping : IMethod<bool>
	{
		public InputEncryptedChat peer;
		public bool typing;
	}

	[TLDef(0x7F4B690A)]
	public class Messages_ReadEncryptedHistory : IMethod<bool>
	{
		public InputEncryptedChat peer;
		public DateTime max_date;
	}

	[TLDef(0x44FA7A15)]
	public class Messages_SendEncrypted : IMethod<Messages_SentEncryptedMessage>
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
	public class Messages_SendEncryptedFile : IMethod<Messages_SentEncryptedMessage>
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
	public class Messages_SendEncryptedService : IMethod<Messages_SentEncryptedMessage>
	{
		public InputEncryptedChat peer;
		public long random_id;
		public byte[] data;
	}

	[TLDef(0x55A5BB66)]
	public class Messages_ReceivedQueue : IMethod<long[]>
	{
		public int max_qts;
	}

	[TLDef(0x4B0C8C0F)]
	public class Messages_ReportEncryptedSpam : IMethod<bool>
	{
		public InputEncryptedChat peer;
	}

	[TLDef(0x36A73F77)]
	public class Messages_ReadMessageContents : IMethod<Messages_AffectedMessages>
	{
		public int[] id;
	}

	[TLDef(0xD5A5D3A1)]
	public class Messages_GetStickers : IMethod<Messages_Stickers>
	{
		public string emoticon;
		public long hash;
	}

	[TLDef(0xB8A0A1A8)]
	public class Messages_GetAllStickers : IMethod<Messages_AllStickers>
	{
		public long hash;
	}

	[TLDef(0x8B68B0CC)]
	public class Messages_GetWebPagePreview : IMethod<MessageMedia>
	{
		public Flags flags;
		public string message;
		[IfFlag(3)] public MessageEntity[] entities;

		[Flags] public enum Flags : uint
		{
			has_entities = 0x8,
		}
	}

	[TLDef(0xA02CE5D5)]
	public class Messages_ExportChatInvite : IMethod<ExportedChatInvite>
	{
		public Flags flags;
		public InputPeer peer;
		[IfFlag(0)] public DateTime expire_date;
		[IfFlag(1)] public int usage_limit;
		[IfFlag(4)] public string title;

		[Flags] public enum Flags : uint
		{
			has_expire_date = 0x1,
			has_usage_limit = 0x2,
			legacy_revoke_permanent = 0x4,
			request_needed = 0x8,
			has_title = 0x10,
		}
	}

	[TLDef(0x3EADB1BB)]
	public class Messages_CheckChatInvite : IMethod<ChatInviteBase>
	{
		public string hash;
	}

	[TLDef(0x6C50051C)]
	public class Messages_ImportChatInvite : IMethod<UpdatesBase>
	{
		public string hash;
	}

	[TLDef(0xC8A0EC74)]
	public class Messages_GetStickerSet : IMethod<Messages_StickerSet>
	{
		public InputStickerSet stickerset;
		public int hash;
	}

	[TLDef(0xC78FE460)]
	public class Messages_InstallStickerSet : IMethod<Messages_StickerSetInstallResult>
	{
		public InputStickerSet stickerset;
		public bool archived;
	}

	[TLDef(0xF96E55DE)]
	public class Messages_UninstallStickerSet : IMethod<bool>
	{
		public InputStickerSet stickerset;
	}

	[TLDef(0xE6DF7378)]
	public class Messages_StartBot : IMethod<UpdatesBase>
	{
		public InputUserBase bot;
		public InputPeer peer;
		public long random_id;
		public string start_param;
	}

	[TLDef(0x5784D3E1)]
	public class Messages_GetMessagesViews : IMethod<Messages_MessageViews>
	{
		public InputPeer peer;
		public int[] id;
		public bool increment;
	}

	[TLDef(0xA85BD1C2)]
	public class Messages_EditChatAdmin : IMethod<bool>
	{
		public long chat_id;
		public InputUserBase user_id;
		public bool is_admin;
	}

	[TLDef(0xA2875319)]
	public class Messages_MigrateChat : IMethod<UpdatesBase>
	{
		public long chat_id;
	}

	[TLDef(0x4BC6589A)]
	public class Messages_SearchGlobal : IMethod<Messages_MessagesBase>
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
		}
	}

	[TLDef(0x78337739)]
	public class Messages_ReorderStickerSets : IMethod<bool>
	{
		public Flags flags;
		public long[] order;

		[Flags] public enum Flags : uint
		{
			masks = 0x1,
		}
	}

	[TLDef(0x338E2464)]
	public class Messages_GetDocumentByHash : IMethod<DocumentBase>
	{
		public byte[] sha256;
		public int size;
		public string mime_type;
	}

	[TLDef(0x5CF09635)]
	public class Messages_GetSavedGifs : IMethod<Messages_SavedGifs>
	{
		public long hash;
	}

	[TLDef(0x327A30CB)]
	public class Messages_SaveGif : IMethod<bool>
	{
		public InputDocument id;
		public bool unsave;
	}

	[TLDef(0x514E999D)]
	public class Messages_GetInlineBotResults : IMethod<Messages_BotResults>
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

	[TLDef(0xEB5EA206)]
	public class Messages_SetInlineBotResults : IMethod<bool>
	{
		public Flags flags;
		public long query_id;
		public InputBotInlineResultBase[] results;
		public DateTime cache_time;
		[IfFlag(2)] public string next_offset;
		[IfFlag(3)] public InlineBotSwitchPM switch_pm;

		[Flags] public enum Flags : uint
		{
			gallery = 0x1,
			private_ = 0x2,
			has_next_offset = 0x4,
			has_switch_pm = 0x8,
		}
	}

	[TLDef(0x7AA11297)]
	public class Messages_SendInlineBotResult : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPeer peer;
		[IfFlag(0)] public int reply_to_msg_id;
		public long random_id;
		public long query_id;
		public string id;
		[IfFlag(10)] public DateTime schedule_date;
		[IfFlag(13)] public InputPeer send_as;

		[Flags] public enum Flags : uint
		{
			has_reply_to_msg_id = 0x1,
			silent = 0x20,
			background = 0x40,
			clear_draft = 0x80,
			has_schedule_date = 0x400,
			hide_via = 0x800,
			has_send_as = 0x2000,
		}
	}

	[TLDef(0xFDA68D36)]
	public class Messages_GetMessageEditData : IMethod<Messages_MessageEditData>
	{
		public InputPeer peer;
		public int id;
	}

	[TLDef(0x48F71778)]
	public class Messages_EditMessage : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPeer peer;
		public int id;
		[IfFlag(11)] public string message;
		[IfFlag(14)] public InputMedia media;
		[IfFlag(2)] public ReplyMarkup reply_markup;
		[IfFlag(3)] public MessageEntity[] entities;
		[IfFlag(15)] public DateTime schedule_date;

		[Flags] public enum Flags : uint
		{
			no_webpage = 0x2,
			has_reply_markup = 0x4,
			has_entities = 0x8,
			has_message = 0x800,
			has_media = 0x4000,
			has_schedule_date = 0x8000,
		}
	}

	[TLDef(0x83557DBA)]
	public class Messages_EditInlineBotMessage : IMethod<bool>
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
		}
	}

	[TLDef(0x9342CA07)]
	public class Messages_GetBotCallbackAnswer : IMethod<Messages_BotCallbackAnswer>
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
	public class Messages_SetBotCallbackAnswer : IMethod<bool>
	{
		public Flags flags;
		public long query_id;
		[IfFlag(0)] public string message;
		[IfFlag(2)] public string url;
		public DateTime cache_time;

		[Flags] public enum Flags : uint
		{
			has_message = 0x1,
			alert = 0x2,
			has_url = 0x4,
		}
	}

	[TLDef(0xE470BCFD)]
	public class Messages_GetPeerDialogs : IMethod<Messages_PeerDialogs>
	{
		public InputDialogPeerBase[] peers;
	}

	[TLDef(0xBC39E14B)]
	public class Messages_SaveDraft : IMethod<bool>
	{
		public Flags flags;
		[IfFlag(0)] public int reply_to_msg_id;
		public InputPeer peer;
		public string message;
		[IfFlag(3)] public MessageEntity[] entities;

		[Flags] public enum Flags : uint
		{
			has_reply_to_msg_id = 0x1,
			no_webpage = 0x2,
			has_entities = 0x8,
		}
	}

	[TLDef(0x6A3F8D65)]
	public class Messages_GetAllDrafts : IMethod<UpdatesBase> { }

	[TLDef(0x64780B14)]
	public class Messages_GetFeaturedStickers : IMethod<Messages_FeaturedStickersBase>
	{
		public long hash;
	}

	[TLDef(0x5B118126)]
	public class Messages_ReadFeaturedStickers : IMethod<bool>
	{
		public long[] id;
	}

	[TLDef(0x9DA9403B)]
	public class Messages_GetRecentStickers : IMethod<Messages_RecentStickers>
	{
		public Flags flags;
		public long hash;

		[Flags] public enum Flags : uint
		{
			attached = 0x1,
		}
	}

	[TLDef(0x392718F8)]
	public class Messages_SaveRecentSticker : IMethod<bool>
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
	public class Messages_ClearRecentStickers : IMethod<bool>
	{
		public Flags flags;

		[Flags] public enum Flags : uint
		{
			attached = 0x1,
		}
	}

	[TLDef(0x57F17692)]
	public class Messages_GetArchivedStickers : IMethod<Messages_ArchivedStickers>
	{
		public Flags flags;
		public long offset_id;
		public int limit;

		[Flags] public enum Flags : uint
		{
			masks = 0x1,
		}
	}

	[TLDef(0x640F82B8)]
	public class Messages_GetMaskStickers : IMethod<Messages_AllStickers>
	{
		public long hash;
	}

	[TLDef(0xCC5B67CC)]
	public class Messages_GetAttachedStickers : IMethod<StickerSetCoveredBase[]>
	{
		public InputStickeredMedia media;
	}

	[TLDef(0x8EF8ECC0)]
	public class Messages_SetGameScore : IMethod<UpdatesBase>
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
	public class Messages_SetInlineGameScore : IMethod<bool>
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
	public class Messages_GetGameHighScores : IMethod<Messages_HighScores>
	{
		public InputPeer peer;
		public int id;
		public InputUserBase user_id;
	}

	[TLDef(0x0F635E1B)]
	public class Messages_GetInlineGameHighScores : IMethod<Messages_HighScores>
	{
		public InputBotInlineMessageIDBase id;
		public InputUserBase user_id;
	}

	[TLDef(0xE40CA104)]
	public class Messages_GetCommonChats : IMethod<Messages_Chats>
	{
		public InputUserBase user_id;
		public long max_id;
		public int limit;
	}

	[TLDef(0x875F74BE)]
	public class Messages_GetAllChats : IMethod<Messages_Chats>
	{
		public long[] except_ids;
	}

	[TLDef(0x32CA8F91)]
	public class Messages_GetWebPage : IMethod<WebPageBase>
	{
		public string url;
		public int hash;
	}

	[TLDef(0xA731E257)]
	public class Messages_ToggleDialogPin : IMethod<bool>
	{
		public Flags flags;
		public InputDialogPeerBase peer;

		[Flags] public enum Flags : uint
		{
			pinned = 0x1,
		}
	}

	[TLDef(0x3B1ADF37)]
	public class Messages_ReorderPinnedDialogs : IMethod<bool>
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
	public class Messages_GetPinnedDialogs : IMethod<Messages_PeerDialogs>
	{
		public int folder_id;
	}

	[TLDef(0xE5F672FA)]
	public class Messages_SetBotShippingResults : IMethod<bool>
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
	public class Messages_SetBotPrecheckoutResults : IMethod<bool>
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

	[TLDef(0x519BC2B1)]
	public class Messages_UploadMedia : IMethod<MessageMedia>
	{
		public InputPeer peer;
		public InputMedia media;
	}

	[TLDef(0xC97DF020)]
	public class Messages_SendScreenshotNotification : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public int reply_to_msg_id;
		public long random_id;
	}

	[TLDef(0x04F1AAA9)]
	public class Messages_GetFavedStickers : IMethod<Messages_FavedStickers>
	{
		public long hash;
	}

	[TLDef(0xB9FFC55B)]
	public class Messages_FaveSticker : IMethod<bool>
	{
		public InputDocument id;
		public bool unfave;
	}

	[TLDef(0x46578472)]
	public class Messages_GetUnreadMentions : IMethod<Messages_MessagesBase>
	{
		public InputPeer peer;
		public int offset_id;
		public int add_offset;
		public int limit;
		public int max_id;
		public int min_id;
	}

	[TLDef(0x0F0189D3)]
	public class Messages_ReadMentions : IMethod<Messages_AffectedHistory>
	{
		public InputPeer peer;
	}

	[TLDef(0x702A40E0)]
	public class Messages_GetRecentLocations : IMethod<Messages_MessagesBase>
	{
		public InputPeer peer;
		public int limit;
		public long hash;
	}

	[TLDef(0xF803138F)]
	public class Messages_SendMultiMedia : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPeer peer;
		[IfFlag(0)] public int reply_to_msg_id;
		public InputSingleMedia[] multi_media;
		[IfFlag(10)] public DateTime schedule_date;
		[IfFlag(13)] public InputPeer send_as;

		[Flags] public enum Flags : uint
		{
			has_reply_to_msg_id = 0x1,
			silent = 0x20,
			background = 0x40,
			clear_draft = 0x80,
			has_schedule_date = 0x400,
			has_send_as = 0x2000,
			noforwards = 0x4000,
		}
	}

	[TLDef(0x5057C497)]
	public class Messages_UploadEncryptedFile : IMethod<EncryptedFile>
	{
		public InputEncryptedChat peer;
		public InputEncryptedFileBase file;
	}

	[TLDef(0x35705B8A)]
	public class Messages_SearchStickerSets : IMethod<Messages_FoundStickerSets>
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
	public class Messages_GetSplitRanges : IMethod<MessageRange[]> { }

	[TLDef(0xC286D98F)]
	public class Messages_MarkDialogUnread : IMethod<bool>
	{
		public Flags flags;
		public InputDialogPeerBase peer;

		[Flags] public enum Flags : uint
		{
			unread = 0x1,
		}
	}

	[TLDef(0x22E24E22)]
	public class Messages_GetDialogUnreadMarks : IMethod<DialogPeerBase[]> { }

	[TLDef(0x7E58EE9C)]
	public class Messages_ClearAllDrafts : IMethod<bool> { }

	[TLDef(0xD2AAF7EC)]
	public class Messages_UpdatePinnedMessage : IMethod<UpdatesBase>
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
	public class Messages_SendVote : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public int msg_id;
		public byte[][] options;
	}

	[TLDef(0x73BB643B)]
	public class Messages_GetPollResults : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public int msg_id;
	}

	[TLDef(0x6E2BE050)]
	public class Messages_GetOnlines : IMethod<ChatOnlines>
	{
		public InputPeer peer;
	}

	[TLDef(0xDEF60797)]
	public class Messages_EditChatAbout : IMethod<bool>
	{
		public InputPeer peer;
		public string about;
	}

	[TLDef(0xA5866B41)]
	public class Messages_EditChatDefaultBannedRights : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public ChatBannedRights banned_rights;
	}

	[TLDef(0x35A0E062)]
	public class Messages_GetEmojiKeywords : IMethod<EmojiKeywordsDifference>
	{
		public string lang_code;
	}

	[TLDef(0x1508B6AF)]
	public class Messages_GetEmojiKeywordsDifference : IMethod<EmojiKeywordsDifference>
	{
		public string lang_code;
		public int from_version;
	}

	[TLDef(0x4E9963B2)]
	public class Messages_GetEmojiKeywordsLanguages : IMethod<EmojiLanguage[]>
	{
		public string[] lang_codes;
	}

	[TLDef(0xD5B10C26)]
	public class Messages_GetEmojiURL : IMethod<EmojiURL>
	{
		public string lang_code;
	}

	[TLDef(0x732EEF00)]
	public class Messages_GetSearchCounters : IMethod<Messages_SearchCounter[]>
	{
		public InputPeer peer;
		public MessagesFilter[] filters;
	}

	[TLDef(0x198FB446)]
	public class Messages_RequestUrlAuth : IMethod<UrlAuthResult>
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
	public class Messages_AcceptUrlAuth : IMethod<UrlAuthResult>
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
	public class Messages_HidePeerSettingsBar : IMethod<bool>
	{
		public InputPeer peer;
	}

	[TLDef(0xF516760B)]
	public class Messages_GetScheduledHistory : IMethod<Messages_MessagesBase>
	{
		public InputPeer peer;
		public long hash;
	}

	[TLDef(0xBDBB0464)]
	public class Messages_GetScheduledMessages : IMethod<Messages_MessagesBase>
	{
		public InputPeer peer;
		public int[] id;
	}

	[TLDef(0xBD38850A)]
	public class Messages_SendScheduledMessages : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public int[] id;
	}

	[TLDef(0x59AE2B16)]
	public class Messages_DeleteScheduledMessages : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public int[] id;
	}

	[TLDef(0xB86E380E)]
	public class Messages_GetPollVotes : IMethod<Messages_VotesList>
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
	public class Messages_ToggleStickerSets : IMethod<bool>
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

	[TLDef(0xF19ED96D)]
	public class Messages_GetDialogFilters : IMethod<DialogFilter[]> { }

	[TLDef(0xA29CD42C)]
	public class Messages_GetSuggestedDialogFilters : IMethod<DialogFilterSuggested[]> { }

	[TLDef(0x1AD4A04A)]
	public class Messages_UpdateDialogFilter : IMethod<bool>
	{
		public Flags flags;
		public int id;
		[IfFlag(0)] public DialogFilter filter;

		[Flags] public enum Flags : uint
		{
			has_filter = 0x1,
		}
	}

	[TLDef(0xC563C1E4)]
	public class Messages_UpdateDialogFiltersOrder : IMethod<bool>
	{
		public int[] order;
	}

	[TLDef(0x7ED094A1)]
	public class Messages_GetOldFeaturedStickers : IMethod<Messages_FeaturedStickersBase>
	{
		public int offset;
		public int limit;
		public long hash;
	}

	[TLDef(0x22DDD30C)]
	public class Messages_GetReplies : IMethod<Messages_MessagesBase>
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
	public class Messages_GetDiscussionMessage : IMethod<Messages_DiscussionMessage>
	{
		public InputPeer peer;
		public int msg_id;
	}

	[TLDef(0xF731A9F4)]
	public class Messages_ReadDiscussion : IMethod<bool>
	{
		public InputPeer peer;
		public int msg_id;
		public int read_max_id;
	}

	[TLDef(0xF025BC8B)]
	public class Messages_UnpinAllMessages : IMethod<Messages_AffectedHistory>
	{
		public InputPeer peer;
	}

	[TLDef(0x5BD0EE50)]
	public class Messages_DeleteChat : IMethod<bool>
	{
		public long chat_id;
	}

	[TLDef(0xF9CBE409)]
	public class Messages_DeletePhoneCallHistory : IMethod<Messages_AffectedFoundMessages>
	{
		public Flags flags;

		[Flags] public enum Flags : uint
		{
			revoke = 0x1,
		}
	}

	[TLDef(0x43FE19F3)]
	public class Messages_CheckHistoryImport : IMethod<Messages_HistoryImportParsed>
	{
		public string import_head;
	}

	[TLDef(0x34090C3B)]
	public class Messages_InitHistoryImport : IMethod<Messages_HistoryImport>
	{
		public InputPeer peer;
		public InputFileBase file;
		public int media_count;
	}

	[TLDef(0x2A862092)]
	public class Messages_UploadImportedMedia : IMethod<MessageMedia>
	{
		public InputPeer peer;
		public long import_id;
		public string file_name;
		public InputMedia media;
	}

	[TLDef(0xB43DF344)]
	public class Messages_StartHistoryImport : IMethod<bool>
	{
		public InputPeer peer;
		public long import_id;
	}

	[TLDef(0xA2B5A3F6)]
	public class Messages_GetExportedChatInvites : IMethod<Messages_ExportedChatInvites>
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
	public class Messages_GetExportedChatInvite : IMethod<Messages_ExportedChatInviteBase>
	{
		public InputPeer peer;
		public string link;
	}

	[TLDef(0xBDCA2F75)]
	public class Messages_EditExportedChatInvite : IMethod<Messages_ExportedChatInviteBase>
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
	public class Messages_DeleteRevokedExportedChatInvites : IMethod<bool>
	{
		public InputPeer peer;
		public InputUserBase admin_id;
	}

	[TLDef(0xD464A42B)]
	public class Messages_DeleteExportedChatInvite : IMethod<bool>
	{
		public InputPeer peer;
		public string link;
	}

	[TLDef(0x3920E6EF)]
	public class Messages_GetAdminsWithInvites : IMethod<Messages_ChatAdminsWithInvites>
	{
		public InputPeer peer;
	}

	[TLDef(0xDF04DD4E)]
	public class Messages_GetChatInviteImporters : IMethod<Messages_ChatInviteImporters>
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
		}
	}

	[TLDef(0xB80E5FE4)]
	public class Messages_SetHistoryTTL : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public int period;
	}

	[TLDef(0x5DC60F03)]
	public class Messages_CheckHistoryImportPeer : IMethod<Messages_CheckedHistoryImportPeer>
	{
		public InputPeer peer;
	}

	[TLDef(0xE63BE13F)]
	public class Messages_SetChatTheme : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public string emoticon;
	}

	[TLDef(0x2C6F97B7)]
	public class Messages_GetMessageReadParticipants : IMethod<long[]>
	{
		public InputPeer peer;
		public int msg_id;
	}

	[TLDef(0x49F0BDE9)]
	public class Messages_GetSearchResultsCalendar : IMethod<Messages_SearchResultsCalendar>
	{
		public InputPeer peer;
		public MessagesFilter filter;
		public int offset_id;
		public DateTime offset_date;
	}

	[TLDef(0x6E9583A3)]
	public class Messages_GetSearchResultsPositions : IMethod<Messages_SearchResultsPositions>
	{
		public InputPeer peer;
		public MessagesFilter filter;
		public int offset_id;
		public int limit;
	}

	[TLDef(0x7FE7E815)]
	public class Messages_HideChatJoinRequest : IMethod<UpdatesBase>
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
	public class Messages_HideAllChatJoinRequests : IMethod<UpdatesBase>
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
	public class Messages_ToggleNoForwards : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public bool enabled;
	}

	[TLDef(0xCCFDDF96)]
	public class Messages_SaveDefaultSendAs : IMethod<bool>
	{
		public InputPeer peer;
		public InputPeer send_as;
	}

	[TLDef(0x25690CE4)]
	public class Messages_SendReaction : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputPeer peer;
		public int msg_id;
		[IfFlag(0)] public string reaction;

		[Flags] public enum Flags : uint
		{
			has_reaction = 0x1,
			big = 0x2,
		}
	}

	[TLDef(0x8BBA90E6)]
	public class Messages_GetMessagesReactions : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public int[] id;
	}

	[TLDef(0xE0EE6B77)]
	public class Messages_GetMessageReactionsList : IMethod<Messages_MessageReactionsList>
	{
		public Flags flags;
		public InputPeer peer;
		public int id;
		[IfFlag(0)] public string reaction;
		[IfFlag(1)] public string offset;
		public int limit;

		[Flags] public enum Flags : uint
		{
			has_reaction = 0x1,
			has_offset = 0x2,
		}
	}

	[TLDef(0x14050EA6)]
	public class Messages_SetChatAvailableReactions : IMethod<UpdatesBase>
	{
		public InputPeer peer;
		public string[] available_reactions;
	}

	[TLDef(0x18DEA0AC)]
	public class Messages_GetAvailableReactions : IMethod<Messages_AvailableReactions>
	{
		public int hash;
	}

	[TLDef(0xD960C4D4)]
	public class Messages_SetDefaultReaction : IMethod<bool>
	{
		public string reaction;
	}

	[TLDef(0x24CE6DEE)]
	public class Messages_TranslateText : IMethod<Messages_TranslatedText>
	{
		public Flags flags;
		[IfFlag(0)] public InputPeer peer;
		[IfFlag(0)] public int msg_id;
		[IfFlag(1)] public string text;
		[IfFlag(2)] public string from_lang;
		public string to_lang;

		[Flags] public enum Flags : uint
		{
			has_peer = 0x1,
			has_text = 0x2,
			has_from_lang = 0x4,
		}
	}

	[TLDef(0xE85BAE1A)]
	public class Messages_GetUnreadReactions : IMethod<Messages_MessagesBase>
	{
		public InputPeer peer;
		public int offset_id;
		public int add_offset;
		public int limit;
		public int max_id;
		public int min_id;
	}

	[TLDef(0x82E251D7)]
	public class Messages_ReadReactions : IMethod<Messages_AffectedHistory>
	{
		public InputPeer peer;
	}

	[TLDef(0x107E31A0)]
	public class Messages_SearchSentMedia : IMethod<Messages_MessagesBase>
	{
		public string q;
		public MessagesFilter filter;
		public int limit;
	}

	[TLDef(0x16FCC2CB)]
	public class Messages_GetAttachMenuBots : IMethod<AttachMenuBots>
	{
		public long hash;
	}

	[TLDef(0x77216192)]
	public class Messages_GetAttachMenuBot : IMethod<AttachMenuBotsBot>
	{
		public InputUserBase bot;
	}

	[TLDef(0x1AEE33AF)]
	public class Messages_ToggleBotInAttachMenu : IMethod<bool>
	{
		public InputUserBase bot;
		public bool enabled;
	}

	[TLDef(0x0FA04DFF)]
	public class Messages_RequestWebView : IMethod<WebViewResult>
	{
		public Flags flags;
		public InputPeer peer;
		public InputUserBase bot;
		[IfFlag(1)] public string url;
		[IfFlag(3)] public string start_param;
		[IfFlag(2)] public DataJSON theme_params;
		[IfFlag(0)] public int reply_to_msg_id;

		[Flags] public enum Flags : uint
		{
			has_reply_to_msg_id = 0x1,
			has_url = 0x2,
			has_theme_params = 0x4,
			has_start_param = 0x8,
			from_bot_menu = 0x10,
			silent = 0x20,
		}
	}

	[TLDef(0xD22AD148)]
	public class Messages_ProlongWebView : IMethod<bool>
	{
		public Flags flags;
		public InputPeer peer;
		public InputUserBase bot;
		public long query_id;
		[IfFlag(0)] public int reply_to_msg_id;

		[Flags] public enum Flags : uint
		{
			has_reply_to_msg_id = 0x1,
			silent = 0x20,
		}
	}

	[TLDef(0x6ABB2F73)]
	public class Messages_RequestSimpleWebView : IMethod<SimpleWebViewResult>
	{
		public Flags flags;
		public InputUserBase bot;
		public string url;
		[IfFlag(0)] public DataJSON theme_params;

		[Flags] public enum Flags : uint
		{
			has_theme_params = 0x1,
		}
	}

	[TLDef(0x0A4314F5)]
	public class Messages_SendWebViewResultMessage : IMethod<WebViewMessageSent>
	{
		public string bot_query_id;
		public InputBotInlineResultBase result;
	}

	[TLDef(0xDC0242C8)]
	public class Messages_SendWebViewData : IMethod<UpdatesBase>
	{
		public InputUserBase bot;
		public long random_id;
		public string button_text;
		public string data;
	}

	[TLDef(0xEDD4882A)]
	public class Updates_GetState : IMethod<Updates_State> { }

	[TLDef(0x25939651)]
	public class Updates_GetDifference : IMethod<Updates_DifferenceBase>
	{
		public Flags flags;
		public int pts;
		[IfFlag(0)] public int pts_total_limit;
		public DateTime date;
		public int qts;

		[Flags] public enum Flags : uint
		{
			has_pts_total_limit = 0x1,
		}
	}

	[TLDef(0x03173D78)]
	public class Updates_GetChannelDifference : IMethod<Updates_ChannelDifferenceBase>
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

	[TLDef(0x72D4742C)]
	public class Photos_UpdateProfilePhoto : IMethod<Photos_Photo>
	{
		public InputPhoto id;
	}

	[TLDef(0x89F30F69)]
	public class Photos_UploadProfilePhoto : IMethod<Photos_Photo>
	{
		public Flags flags;
		[IfFlag(0)] public InputFileBase file;
		[IfFlag(1)] public InputFileBase video;
		[IfFlag(2)] public double video_start_ts;

		[Flags] public enum Flags : uint
		{
			has_file = 0x1,
			has_video = 0x2,
			has_video_start_ts = 0x4,
		}
	}

	[TLDef(0x87CF7F2F)]
	public class Photos_DeletePhotos : IMethod<long[]>
	{
		public InputPhoto[] id;
	}

	[TLDef(0x91CD32A8)]
	public class Photos_GetUserPhotos : IMethod<Photos_Photos>
	{
		public InputUserBase user_id;
		public int offset;
		public long max_id;
		public int limit;
	}

	[TLDef(0xB304A621)]
	public class Upload_SaveFilePart : IMethod<bool>
	{
		public long file_id;
		public int file_part;
		public byte[] bytes;
	}

	[TLDef(0xB15A9AFC)]
	public class Upload_GetFile : IMethod<Upload_FileBase>
	{
		public Flags flags;
		public InputFileLocationBase location;
		public int offset;
		public int limit;

		[Flags] public enum Flags : uint
		{
			precise = 0x1,
			cdn_supported = 0x2,
		}
	}

	[TLDef(0xDE7B673D)]
	public class Upload_SaveBigFilePart : IMethod<bool>
	{
		public long file_id;
		public int file_part;
		public int file_total_parts;
		public byte[] bytes;
	}

	[TLDef(0x24E6818D)]
	public class Upload_GetWebFile : IMethod<Upload_WebFile>
	{
		public InputWebFileLocationBase location;
		public int offset;
		public int limit;
	}

	[TLDef(0x2000BCC3)]
	public class Upload_GetCdnFile : IMethod<Upload_CdnFileBase>
	{
		public byte[] file_token;
		public int offset;
		public int limit;
	}

	[TLDef(0x9B2754A8)]
	public class Upload_ReuploadCdnFile : IMethod<FileHash[]>
	{
		public byte[] file_token;
		public byte[] request_token;
	}

	[TLDef(0x4DA54231)]
	public class Upload_GetCdnFileHashes : IMethod<FileHash[]>
	{
		public byte[] file_token;
		public int offset;
	}

	[TLDef(0xC7025931)]
	public class Upload_GetFileHashes : IMethod<FileHash[]>
	{
		public InputFileLocationBase location;
		public int offset;
	}

	[TLDef(0xC4F9186B)]
	public class Help_GetConfig : IMethod<Config> { }

	[TLDef(0x1FB33026)]
	public class Help_GetNearestDc : IMethod<NearestDc> { }

	[TLDef(0x522D5A7D)]
	public class Help_GetAppUpdate : IMethod<Help_AppUpdate>
	{
		public string source;
	}

	[TLDef(0x4D392343)]
	public class Help_GetInviteText : IMethod<Help_InviteText> { }

	[TLDef(0x9CDF08CD)]
	public class Help_GetSupport : IMethod<Help_Support> { }

	[TLDef(0x9010EF6F)]
	public class Help_GetAppChangelog : IMethod<UpdatesBase>
	{
		public string prev_app_version;
	}

	[TLDef(0xEC22CFCD)]
	public class Help_SetBotUpdatesStatus : IMethod<bool>
	{
		public int pending_updates_count;
		public string message;
	}

	[TLDef(0x52029342)]
	public class Help_GetCdnConfig : IMethod<CdnConfig> { }

	[TLDef(0x3DC0F114)]
	public class Help_GetRecentMeUrls : IMethod<Help_RecentMeUrls>
	{
		public string referer;
	}

	[TLDef(0x2CA51FD1)]
	public class Help_GetTermsOfServiceUpdate : IMethod<Help_TermsOfServiceUpdateBase> { }

	[TLDef(0xEE72F79A)]
	public class Help_AcceptTermsOfService : IMethod<bool>
	{
		public DataJSON id;
	}

	[TLDef(0x3FEDC75F)]
	public class Help_GetDeepLinkInfo : IMethod<Help_DeepLinkInfo>
	{
		public string path;
	}

	[TLDef(0x98914110)]
	public class Help_GetAppConfig : IMethod<JsonObject> { }

	[TLDef(0x6F02F748)]
	public class Help_SaveAppLog : IMethod<bool>
	{
		public InputAppEvent[] events;
	}

	[TLDef(0xC661AD08)]
	public class Help_GetPassportConfig : IMethod<Help_PassportConfig>
	{
		public int hash;
	}

	[TLDef(0xD360E72C)]
	public class Help_GetSupportName : IMethod<Help_SupportName> { }

	[TLDef(0x038A08D3)]
	public class Help_GetUserInfo : IMethod<Help_UserInfo>
	{
		public InputUserBase user_id;
	}

	[TLDef(0x66B91B70)]
	public class Help_EditUserInfo : IMethod<Help_UserInfo>
	{
		public InputUserBase user_id;
		public string message;
		public MessageEntity[] entities;
	}

	[TLDef(0xC0977421)]
	public class Help_GetPromoData : IMethod<Help_PromoDataBase> { }

	[TLDef(0x1E251C95)]
	public class Help_HidePromoData : IMethod<bool>
	{
		public InputPeer peer;
	}

	[TLDef(0xF50DBAA1)]
	public class Help_DismissSuggestion : IMethod<bool>
	{
		public InputPeer peer;
		public string suggestion;
	}

	[TLDef(0x735787A8)]
	public class Help_GetCountriesList : IMethod<Help_CountriesList>
	{
		public string lang_code;
		public int hash;
	}

	[TLDef(0xCC104937)]
	public class Channels_ReadHistory : IMethod<bool>
	{
		public InputChannelBase channel;
		public int max_id;
	}

	[TLDef(0x84C1FD4E)]
	public class Channels_DeleteMessages : IMethod<Messages_AffectedMessages>
	{
		public InputChannelBase channel;
		public int[] id;
	}

	[TLDef(0xF44A8315)]
	public class Channels_ReportSpam : IMethod<bool>
	{
		public InputChannelBase channel;
		public InputPeer participant;
		public int[] id;
	}

	[TLDef(0xAD8C9A23)]
	public class Channels_GetMessages : IMethod<Messages_MessagesBase>
	{
		public InputChannelBase channel;
		public InputMessage[] id;
	}

	[TLDef(0x77CED9D0)]
	public class Channels_GetParticipants : IMethod<Channels_ChannelParticipants>
	{
		public InputChannelBase channel;
		public ChannelParticipantsFilter filter;
		public int offset;
		public int limit;
		public long hash;
	}

	[TLDef(0xA0AB6CC6)]
	public class Channels_GetParticipant : IMethod<Channels_ChannelParticipant>
	{
		public InputChannelBase channel;
		public InputPeer participant;
	}

	[TLDef(0x0A7F6BBB)]
	public class Channels_GetChannels : IMethod<Messages_Chats>
	{
		public InputChannelBase[] id;
	}

	[TLDef(0x08736A09)]
	public class Channels_GetFullChannel : IMethod<Messages_ChatFull>
	{
		public InputChannelBase channel;
	}

	[TLDef(0x3D5FB10F)]
	public class Channels_CreateChannel : IMethod<UpdatesBase>
	{
		public Flags flags;
		public string title;
		public string about;
		[IfFlag(2)] public InputGeoPoint geo_point;
		[IfFlag(2)] public string address;

		[Flags] public enum Flags : uint
		{
			broadcast = 0x1,
			megagroup = 0x2,
			has_geo_point = 0x4,
			for_import = 0x8,
		}
	}

	[TLDef(0xD33C8902)]
	public class Channels_EditAdmin : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public InputUserBase user_id;
		public ChatAdminRights admin_rights;
		public string rank;
	}

	[TLDef(0x566DECD0)]
	public class Channels_EditTitle : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public string title;
	}

	[TLDef(0xF12E57C9)]
	public class Channels_EditPhoto : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public InputChatPhotoBase photo;
	}

	[TLDef(0x10E6BD2C)]
	public class Channels_CheckUsername : IMethod<bool>
	{
		public InputChannelBase channel;
		public string username;
	}

	[TLDef(0x3514B3DE)]
	public class Channels_UpdateUsername : IMethod<bool>
	{
		public InputChannelBase channel;
		public string username;
	}

	[TLDef(0x24B524C5)]
	public class Channels_JoinChannel : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
	}

	[TLDef(0xF836AA95)]
	public class Channels_LeaveChannel : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
	}

	[TLDef(0x199F3A6C)]
	public class Channels_InviteToChannel : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public InputUserBase[] users;
	}

	[TLDef(0xC0111FE3)]
	public class Channels_DeleteChannel : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
	}

	[TLDef(0xE63FADEB)]
	public class Channels_ExportMessageLink : IMethod<ExportedMessageLink>
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

	[TLDef(0x1F69B606)]
	public class Channels_ToggleSignatures : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public bool enabled;
	}

	[TLDef(0xF8B036AF)]
	public class Channels_GetAdminedPublicChannels : IMethod<Messages_Chats>
	{
		public Flags flags;

		[Flags] public enum Flags : uint
		{
			by_location = 0x1,
			check_limit = 0x2,
		}
	}

	[TLDef(0x96E6CD81)]
	public class Channels_EditBanned : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public InputPeer participant;
		public ChatBannedRights banned_rights;
	}

	[TLDef(0x33DDF480)]
	public class Channels_GetAdminLog : IMethod<Channels_AdminLogResults>
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
	public class Channels_SetStickers : IMethod<bool>
	{
		public InputChannelBase channel;
		public InputStickerSet stickerset;
	}

	[TLDef(0xEAB5DC38)]
	public class Channels_ReadMessageContents : IMethod<bool>
	{
		public InputChannelBase channel;
		public int[] id;
	}

	[TLDef(0x9BAA9647)]
	public class Channels_DeleteHistory : IMethod<UpdatesBase>
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
	public class Channels_TogglePreHistoryHidden : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public bool enabled;
	}

	[TLDef(0x8341ECC0)]
	public class Channels_GetLeftChannels : IMethod<Messages_Chats>
	{
		public int offset;
	}

	[TLDef(0xF5DAD378)]
	public class Channels_GetGroupsForDiscussion : IMethod<Messages_Chats> { }

	[TLDef(0x40582BB2)]
	public class Channels_SetDiscussionGroup : IMethod<bool>
	{
		public InputChannelBase broadcast;
		public InputChannelBase group;
	}

	[TLDef(0x8F38CD1F)]
	public class Channels_EditCreator : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public InputUserBase user_id;
		public InputCheckPasswordSRP password;
	}

	[TLDef(0x58E63F6D)]
	public class Channels_EditLocation : IMethod<bool>
	{
		public InputChannelBase channel;
		public InputGeoPoint geo_point;
		public string address;
	}

	[TLDef(0xEDD49EF0)]
	public class Channels_ToggleSlowMode : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
		public int seconds;
	}

	[TLDef(0x11E831EE)]
	public class Channels_GetInactiveChannels : IMethod<Messages_InactiveChats> { }

	[TLDef(0x0B290C69)]
	public class Channels_ConvertToGigagroup : IMethod<UpdatesBase>
	{
		public InputChannelBase channel;
	}

	[TLDef(0xBEAEDB94)]
	public class Channels_ViewSponsoredMessage : IMethod<bool>
	{
		public InputChannelBase channel;
		public byte[] random_id;
	}

	[TLDef(0xEC210FBF)]
	public class Channels_GetSponsoredMessages : IMethod<Messages_SponsoredMessages>
	{
		public InputChannelBase channel;
	}

	[TLDef(0x0DC770EE)]
	public class Channels_GetSendAs : IMethod<Channels_SendAsPeers>
	{
		public InputPeer peer;
	}

	[TLDef(0x367544DB)]
	public class Channels_DeleteParticipantHistory : IMethod<Messages_AffectedHistory>
	{
		public InputChannelBase channel;
		public InputPeer participant;
	}

	[TLDef(0xAA2769ED)]
	public class Bots_SendCustomRequest : IMethod<DataJSON>
	{
		public string custom_method;
		public DataJSON params_;
	}

	[TLDef(0xE6213F4D)]
	public class Bots_AnswerWebhookJSONQuery : IMethod<bool>
	{
		public long query_id;
		public DataJSON data;
	}

	[TLDef(0x0517165A)]
	public class Bots_SetBotCommands : IMethod<bool>
	{
		public BotCommandScope scope;
		public string lang_code;
		public BotCommand[] commands;
	}

	[TLDef(0x3D8DE0F9)]
	public class Bots_ResetBotCommands : IMethod<bool>
	{
		public BotCommandScope scope;
		public string lang_code;
	}

	[TLDef(0xE34C0DD6)]
	public class Bots_GetBotCommands : IMethod<BotCommand[]>
	{
		public BotCommandScope scope;
		public string lang_code;
	}

	[TLDef(0x4504D54F)]
	public class Bots_SetBotMenuButton : IMethod<bool>
	{
		public InputUserBase user_id;
		public BotMenuButtonBase button;
	}

	[TLDef(0x9C60EB28)]
	public class Bots_GetBotMenuButton : IMethod<BotMenuButtonBase>
	{
		public InputUserBase user_id;
	}

	[TLDef(0x788464E1)]
	public class Bots_SetBotBroadcastDefaultAdminRights : IMethod<bool>
	{
		public ChatAdminRights admin_rights;
	}

	[TLDef(0x925EC9EA)]
	public class Bots_SetBotGroupDefaultAdminRights : IMethod<bool>
	{
		public ChatAdminRights admin_rights;
	}

	[TLDef(0x8A333C8D)]
	public class Payments_GetPaymentForm : IMethod<Payments_PaymentForm>
	{
		public Flags flags;
		public InputPeer peer;
		public int msg_id;
		[IfFlag(0)] public DataJSON theme_params;

		[Flags] public enum Flags : uint
		{
			has_theme_params = 0x1,
		}
	}

	[TLDef(0x2478D1CC)]
	public class Payments_GetPaymentReceipt : IMethod<Payments_PaymentReceipt>
	{
		public InputPeer peer;
		public int msg_id;
	}

	[TLDef(0xDB103170)]
	public class Payments_ValidateRequestedInfo : IMethod<Payments_ValidatedRequestedInfo>
	{
		public Flags flags;
		public InputPeer peer;
		public int msg_id;
		public PaymentRequestedInfo info;

		[Flags] public enum Flags : uint
		{
			save = 0x1,
		}
	}

	[TLDef(0x30C3BC9D)]
	public class Payments_SendPaymentForm : IMethod<Payments_PaymentResultBase>
	{
		public Flags flags;
		public long form_id;
		public InputPeer peer;
		public int msg_id;
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
	public class Payments_GetSavedInfo : IMethod<Payments_SavedInfo> { }

	[TLDef(0xD83D70C1)]
	public class Payments_ClearSavedInfo : IMethod<bool>
	{
		public Flags flags;

		[Flags] public enum Flags : uint
		{
			credentials = 0x1,
			info = 0x2,
		}
	}

	[TLDef(0x2E79D779)]
	public class Payments_GetBankCardData : IMethod<Payments_BankCardData>
	{
		public string number;
	}

	[TLDef(0x9021AB67)]
	public class Stickers_CreateStickerSet : IMethod<Messages_StickerSet>
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
			animated = 0x2,
			has_thumb = 0x4,
			has_software = 0x8,
			videos = 0x10,
		}
	}

	[TLDef(0xF7760F51)]
	public class Stickers_RemoveStickerFromSet : IMethod<Messages_StickerSet>
	{
		public InputDocument sticker;
	}

	[TLDef(0xFFB6D4CA)]
	public class Stickers_ChangeStickerPosition : IMethod<Messages_StickerSet>
	{
		public InputDocument sticker;
		public int position;
	}

	[TLDef(0x8653FEBE)]
	public class Stickers_AddStickerToSet : IMethod<Messages_StickerSet>
	{
		public InputStickerSet stickerset;
		public InputStickerSetItem sticker;
	}

	[TLDef(0x9A364E30)]
	public class Stickers_SetStickerSetThumb : IMethod<Messages_StickerSet>
	{
		public InputStickerSet stickerset;
		public InputDocument thumb;
	}

	[TLDef(0x284B3639)]
	public class Stickers_CheckShortName : IMethod<bool>
	{
		public string short_name;
	}

	[TLDef(0x4DAFC503)]
	public class Stickers_SuggestShortName : IMethod<Stickers_SuggestedShortName>
	{
		public string title;
	}

	[TLDef(0x55451FA9)]
	public class Phone_GetCallConfig : IMethod<DataJSON> { }

	[TLDef(0x42FF96ED)]
	public class Phone_RequestCall : IMethod<Phone_PhoneCall>
	{
		public Flags flags;
		public InputUserBase user_id;
		public int random_id;
		public byte[] g_a_hash;
		public PhoneCallProtocol protocol;

		[Flags] public enum Flags : uint
		{
			video = 0x1,
		}
	}

	[TLDef(0x3BD2B4A0)]
	public class Phone_AcceptCall : IMethod<Phone_PhoneCall>
	{
		public InputPhoneCall peer;
		public byte[] g_b;
		public PhoneCallProtocol protocol;
	}

	[TLDef(0x2EFE1722)]
	public class Phone_ConfirmCall : IMethod<Phone_PhoneCall>
	{
		public InputPhoneCall peer;
		public byte[] g_a;
		public long key_fingerprint;
		public PhoneCallProtocol protocol;
	}

	[TLDef(0x17D54F61)]
	public class Phone_ReceivedCall : IMethod<bool>
	{
		public InputPhoneCall peer;
	}

	[TLDef(0xB2CBC1C0)]
	public class Phone_DiscardCall : IMethod<UpdatesBase>
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
	public class Phone_SetCallRating : IMethod<UpdatesBase>
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
	public class Phone_SaveCallDebug : IMethod<bool>
	{
		public InputPhoneCall peer;
		public DataJSON debug;
	}

	[TLDef(0xFF7A9383)]
	public class Phone_SendSignalingData : IMethod<bool>
	{
		public InputPhoneCall peer;
		public byte[] data;
	}

	[TLDef(0x48CDC6D8)]
	public class Phone_CreateGroupCall : IMethod<UpdatesBase>
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

	[TLDef(0xB132FF7B)]
	public class Phone_JoinGroupCall : IMethod<UpdatesBase>
	{
		public Flags flags;
		public InputGroupCall call;
		public InputPeer join_as;
		[IfFlag(1)] public string invite_hash;
		public DataJSON params_;

		[Flags] public enum Flags : uint
		{
			muted = 0x1,
			has_invite_hash = 0x2,
			video_stopped = 0x4,
		}
	}

	[TLDef(0x500377F9)]
	public class Phone_LeaveGroupCall : IMethod<UpdatesBase>
	{
		public InputGroupCall call;
		public int source;
	}

	[TLDef(0x7B393160)]
	public class Phone_InviteToGroupCall : IMethod<UpdatesBase>
	{
		public InputGroupCall call;
		public InputUserBase[] users;
	}

	[TLDef(0x7A777135)]
	public class Phone_DiscardGroupCall : IMethod<UpdatesBase>
	{
		public InputGroupCall call;
	}

	[TLDef(0x74BBB43D)]
	public class Phone_ToggleGroupCallSettings : IMethod<UpdatesBase>
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
	public class Phone_GetGroupCall : IMethod<Phone_GroupCall>
	{
		public InputGroupCall call;
		public int limit;
	}

	[TLDef(0xC558D8AB)]
	public class Phone_GetGroupParticipants : IMethod<Phone_GroupParticipants>
	{
		public InputGroupCall call;
		public InputPeer[] ids;
		public int[] sources;
		public string offset;
		public int limit;
	}

	[TLDef(0xB59CF977)]
	public class Phone_CheckGroupCall : IMethod<int[]>
	{
		public InputGroupCall call;
		public int[] sources;
	}

	[TLDef(0xF128C708)]
	public class Phone_ToggleGroupCallRecord : IMethod<UpdatesBase>
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
	public class Phone_EditGroupCallParticipant : IMethod<UpdatesBase>
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
	public class Phone_EditGroupCallTitle : IMethod<UpdatesBase>
	{
		public InputGroupCall call;
		public string title;
	}

	[TLDef(0xEF7C213A)]
	public class Phone_GetGroupCallJoinAs : IMethod<Phone_JoinAsPeers>
	{
		public InputPeer peer;
	}

	[TLDef(0xE6AA647F)]
	public class Phone_ExportGroupCallInvite : IMethod<Phone_ExportedGroupCallInvite>
	{
		public Flags flags;
		public InputGroupCall call;

		[Flags] public enum Flags : uint
		{
			can_self_unmute = 0x1,
		}
	}

	[TLDef(0x219C34E6)]
	public class Phone_ToggleGroupCallStartSubscription : IMethod<UpdatesBase>
	{
		public InputGroupCall call;
		public bool subscribed;
	}

	[TLDef(0x5680E342)]
	public class Phone_StartScheduledGroupCall : IMethod<UpdatesBase>
	{
		public InputGroupCall call;
	}

	[TLDef(0x575E1F8C)]
	public class Phone_SaveDefaultGroupCallJoinAs : IMethod<bool>
	{
		public InputPeer peer;
		public InputPeer join_as;
	}

	[TLDef(0xCBEA6BC4)]
	public class Phone_JoinGroupCallPresentation : IMethod<UpdatesBase>
	{
		public InputGroupCall call;
		public DataJSON params_;
	}

	[TLDef(0x1C50D144)]
	public class Phone_LeaveGroupCallPresentation : IMethod<UpdatesBase>
	{
		public InputGroupCall call;
	}

	[TLDef(0x1AB21940)]
	public class Phone_GetGroupCallStreamChannels : IMethod<Phone_GroupCallStreamChannels>
	{
		public InputGroupCall call;
	}

	[TLDef(0xDEB3ABBF)]
	public class Phone_GetGroupCallStreamRtmpUrl : IMethod<Phone_GroupCallStreamRtmpUrl>
	{
		public InputPeer peer;
		public bool revoke;
	}

	[TLDef(0x41248786)]
	public class Phone_SaveCallLog : IMethod<bool>
	{
		public InputPhoneCall peer;
		public InputFileBase file;
	}

	[TLDef(0xF2F2330A)]
	public class Langpack_GetLangPack : IMethod<LangPackDifference>
	{
		public string lang_pack;
		public string lang_code;
	}

	[TLDef(0xEFEA3803)]
	public class Langpack_GetStrings : IMethod<LangPackStringBase[]>
	{
		public string lang_pack;
		public string lang_code;
		public string[] keys;
	}

	[TLDef(0xCD984AA5)]
	public class Langpack_GetDifference : IMethod<LangPackDifference>
	{
		public string lang_pack;
		public string lang_code;
		public int from_version;
	}

	[TLDef(0x42C6978F)]
	public class Langpack_GetLanguages : IMethod<LangPackLanguage[]>
	{
		public string lang_pack;
	}

	[TLDef(0x6A596502)]
	public class Langpack_GetLanguage : IMethod<LangPackLanguage>
	{
		public string lang_pack;
		public string lang_code;
	}

	[TLDef(0x6847D0AB)]
	public class Folders_EditPeerFolders : IMethod<UpdatesBase>
	{
		public InputFolderPeer[] folder_peers;
	}

	[TLDef(0x1C295881)]
	public class Folders_DeleteFolder : IMethod<UpdatesBase>
	{
		public int folder_id;
	}

	[TLDef(0xAB42441A)]
	public class Stats_GetBroadcastStats : IMethod<Stats_BroadcastStats>
	{
		public Flags flags;
		public InputChannelBase channel;

		[Flags] public enum Flags : uint
		{
			dark = 0x1,
		}
	}

	[TLDef(0x621D5FA0)]
	public class Stats_LoadAsyncGraph : IMethod<StatsGraphBase>
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
	public class Stats_GetMegagroupStats : IMethod<Stats_MegagroupStats>
	{
		public Flags flags;
		public InputChannelBase channel;

		[Flags] public enum Flags : uint
		{
			dark = 0x1,
		}
	}

	[TLDef(0x5630281B)]
	public class Stats_GetMessagePublicForwards : IMethod<Messages_MessagesBase>
	{
		public InputChannelBase channel;
		public int msg_id;
		public int offset_rate;
		public InputPeer offset_peer;
		public int offset_id;
		public int limit;
	}

	[TLDef(0xB6E0A3F5)]
	public class Stats_GetMessageStats : IMethod<Stats_MessageStats>
	{
		public Flags flags;
		public InputChannelBase channel;
		public int msg_id;

		[Flags] public enum Flags : uint
		{
			dark = 0x1,
		}
	}
}
