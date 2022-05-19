## FAQ

Before asking questions, make sure to **[read through the ReadMe first](README.md)**,
take a look at the [example programs](EXAMPLES.md) or [StackOverflow questions](https://stackoverflow.com/questions/tagged/wtelegramclient),
and refer to the [API method list](https://corefork.telegram.org/methods) for the full range of Telegram services available in this library.

<a name="remove-logs"></a>
#### 1. How to remove the Console logs?

Writing the library logs to the Console is the default behavior of the `WTelegram.Helpers.Log` delegate.  
You can change the delegate with the `+=` operator to **also** write them somewhere else, or with the `=` operator to prevent them from being printed to screen and instead write them somewhere (file, logger, ...).
In any case, it is not recommended to totally ignore those logs because you wouldn't be able to diagnose a problem after it happens.  

Read the [example about logging settings](EXAMPLES.md#logging) for how to write logs to a file.

<a name="multiple-users"></a>
#### 2. How to handle multiple user accounts

The WTelegram.session file contains the authentication keys negociated for the current user.

You could switch the current user via an `Auth_Logout` followed by a `LoginUserIfNeeded` but that would require the user to sign in with a verification_code each time.

Instead, if you want to deal with multiple users from the same machine, the recommended solution is to have a different session file for each user. This can be done by having your Config callback reply with a different filename (or folder) for "**session_pathname**" for each user.
This way, you can keep separate session files (each with their authentication keys) for each user.

If you need to manage these user accounts in parallel, you can create multiple instances of WTelegram.Client,
and give them a Config callback that will select a different session file ;
for example: `new WTelegram.Client(what => Config(what, "session42"))`

Also please note that the session files are encrypted with your api_hash (or session_key), so if you change it, the existing session files can't be read anymore.
Your api_id/api_hash represents your application, and shouldn't change with each user account the application will manage.

<a name="GUI"></a>
<a name="ASPNET"></a>
#### 3. How to use the library in a WinForms, WPF or ASP.NET application

The library should work without a problem in such applications.
The difficulty might be in your Config callback when the user must enter the verification code or password, as you can't use `Console.ReadLine` here.

For GUI apps, an easy solution is to call `Interaction.InputBox("Enter verification code")` instead.  
This might require adding a reference *(and `using`)* to the Microsoft.VisualBasic assembly.

A more complex solution requires the use of a `ManualResetEventSlim` that you will wait for in Config callback,
and when the user has provided the verification_code through your app, you "set" the event to release your Config callback so it can return the code.  
You can download such full example apps [for WinForms](https://github.com/wiz0u/WTelegramClient/raw/master/Examples/WinForms_app.zip) and [for ASP.NET](https://github.com/wiz0u/WTelegramClient/raw/master/Examples/ASPnet_webapp.zip)

<a name="access-hash"></a>
#### 4. Where to get the access_hash? Why the error `CHANNEL_INVALID` or `USER_ID_INVALID`?

An `access_hash` is required by Telegram when dealing with a channel, user, photo, document, etc...  
This serves as a proof that the logged-in user is entitled to access it (otherwise, anybody with the ID could access it)

> A small private `Chat` don't need an access_hash and can be queried using their `chat_id` only.
However most common chat groups are not `Chat` but a `Channel` supergroup (without the `broadcast` flag). See [Terminology in ReadMe](README.md#terminology).  
Some TL methods only applies to private `Chat`, some only applies to `Channel` and some to both.

The `access_hash` must usually be provided within the `Input...` structure you pass in argument to an API method (`InputPeer`, `InputChannel`, `InputUser`, etc...).  
You obtain the `access_hash` through **description structures** like `Channel`, `User`, `Photo`, `Document` that you receive through updates or when you query them through API methods like `Messages_GetAllChats`, `Messages_GetAllDialogs`, `Contacts_ResolveUsername`, etc...  
*(if you have a `Peer` object, you can convert it to a `User`/`Channel`/`Chat` via the `UserOrChat` helper from the root class that contained the peer)*

Once you obtained the description structure, there are 3 methods for building your `Input...` structure:
* **Recommended:** If you take a look at the **description structure** class or base class `ChatBase/UserBase`, 
you will see that they have conversion implicit operators or methods that can create the `Input...` structure for you automatically.  
So you can just pass that structure you already have, in place of the `Input...` argument, it will work!
* Alternatively, you can manually create the `Input...` structure yourself by extracting the `access_hash` from the **description structure**
* If you have enabled the [CollectAccessHash system](EXAMPLES.md#collect-access-hash) at the start of your session, it will have collected the `access_hash` automatically when you obtained the description structure.
You can then retrieve it with `client.GetAccessHashFor<User/Channel/Photo/Document>(id)`

⚠️ *An `access_hash` obtained from a User/Channel structure with flag `min` may not be used for most requests. See [Min constructors](https://core.telegram.org/api/min).*

<a name="dev-versions"></a>
#### 5. I need to test a feature that has been developed but not yet released in WTelegramClient nuget

The developmental versions of the library are available through Azure DevOps as part of the Continuous Integration builds after each Github commit.

You can access these versions for testing in your program by going to our [private nuget feeds](https://dev.azure.com/wiz0u/WTelegramClient/_artifacts/feed/WTelegramClient/NuGet/WTelegramClient),
click on button "Connect to feed" and follow the steps to setup your dev environment.
After that, you should be able to see/install the pre-release versions in your Nuget package manager and install them in your application. *(make sure you enable the **pre-release** checkbox)*

<a name="wrong-server"></a>
#### 6. Telegram asks me to signup (firstname, lastname) even for an existing account
This happens when you connect to Telegram Test servers instead of Production servers.
On these separate test servers, all created accounts and chats are periodically deleted, so you shouldn't use them under normal circumstances.

You can verify this is your issue by looking at [WTelegram logs](EXAMPLES.MD#logging) on the line `Connected to (Test) DC x...`

This wrong-server problem typically happens when you use WTelegramClient Github source project in your application in DEBUG builds.  
It is **not recommended** to use WTelegramClient in source code form.
Instead, you should use the Nuget manager to **install package WTelegramClient** into your application.

If you use the Github source project in an old .NET Framework 4.x or .NET Core x.x application, you may also experience the following error
> System.TypeInitializationException (FileNotFoundException for "System.Text.Json Version=5.0.0.0 ...")

To fix this, you should also switch to using the [WTelegramClient Nuget package](https://www.nuget.org/packages/WTelegramClient) as it will install the required dependencies for it to work.

<a name="abuse"></a>
#### 7. I get errors FLOOD_WAIT_X or PEER_FLOOD, PHONE_NUMBER_BANNED, USER_DEACTIVATED_BAN. I can't import phone numbers.

You can get these kind of problems if you abuse Telegram [Terms of Service](https://telegram.org/tos), or the [API Terms of Service](https://core.telegram.org/api/terms), or make excessive requests.

You can try to wait more between the requests, wait for a day or two to see if the requests become possible again.  
>ℹ️ For FLOOD_WAIT_X with X < 60 seconds (see `client.FloodRetryThreshold`), WTelegramClient will automatically wait the specified delay and retry the request for you.

An account that was restricted due to reported spam might receive PEER_FLOOD errors. Read [Telegram Spam FAQ](https://telegram.org/faq_spam) to learn more.

If you think your phone number was banned from Telegram for a wrong reason, you may try to contact [recover@telegram.org](mailto:recover@telegram.org), explaining what you were doing.

In any case, WTelegramClient is not responsible for the bad usage of the library and we are not affiliated to Telegram teams, so there is nothing we can do.

<a name="prevent-ban"></a>
#### 8. How to NOT get banned from Telegram?

**Do not share publicly your app's ID and hash!** They cannot be regenerated and are bound to your Telegram account.

From the [official documentation](https://core.telegram.org/api/obtaining_api_id):

> Note that all API client libraries are strictly monitored to prevent abuse.  
> If you use the Telegram API for flooding, spamming, faking subscriber and view counters of channels, you **will be banned forever**.  
> Due to excessive abuse of the Telegram API, **all accounts that sign up or log in using unofficial Telegram clients are automatically
> put under observation** to avoid violations of the [Terms of Service](https://core.telegram.org/api/terms).

Here are some advices from [another similar library](https://github.com/gotd/td/blob/main/.github/SUPPORT.md#how-to-not-get-banned):

1. This client is unofficial, Telegram treats such clients suspiciously, especially fresh ones.
2. Use regular bots instead of userbots whenever possible.
3. If you still want to automate things with a user, use it passively (i.e. receive more than sending).
4. When using it with a user:
   * Do not use QR code login, this will result in permaban.
   * Do it with extreme care.
   * Do not use VoIP numbers.
   * Do not abuse, spam or use it for other suspicious activities.
   * Implement a rate limiting system.

If your client displays Telegram channels to the user, you have to support and display [official sponsored messages](https://core.telegram.org/api/sponsored-messages).

<a name="chat-id"></a>
#### 9. Why the error `CHAT_ID_INVALID`?

Most chat groups you see are likely of type `Channel`, not `Chat`.  
This difference is important to understand. Please [read about the Terminology in ReadMe](README.md#terminology).  

You typically get the error `CHAT_ID_INVALID` when you try to call API methods designed specifically for a `Chat`, with the ID of a `Channel`.  
All API methods taking a `long api_id` as a direct method parameter are for Chats and cannot be used with Channels.

There is probably another method achieving the same result but specifically designed for Channels, and it will have a similar name, but beginning with `Channels_` ...

However, note that those Channel-compatible methods will require an `InputChannel` or `InputPeerChannel` object as argument instead of a simple channel ID.
That object must be created with both fields `channel_id` and `access_hash` correctly filled. You can read more about this in [FAQ #4](#access-hash).

<a name="chats-chats"></a>
#### 10. `chats.chats[id]` fails. My chats list is empty or does not contain the chat id.

There can be several reasons why `chats.chats[id]` raise an error:
- The user account you're currently logged-in as has not joined this particular chat.  
API method [Messages_GetAllChats](https://corefork.telegram.org/method/messages.getAllChats) will only return those chat groups/channels the user is in, not all Telegram chat groups.
- You're trying to use a Telegram.Bot (or TDLib) numerical ID, like -1001234567890  
Telegram Client API don't use these kind of IDs for chats. Remove the -100 prefix and try again with the rest (1234567890).
- You're trying to use a user ID instead of a chat ID.  
Private messages with a user are not called "chats". See [Terminology in ReadMe](README.md#terminology).  
To obtain the list of users (as well as chats and channels) the logged-in user is currenly engaged in a discussion with, you should [use the API method Messages_GetAllDialogs](EXAMPLES.md#list-dialogs)
- the `chats.chats` dictionary is empty.  
This is the case if you are logged-in as a brand new user account (that hasn't join any chat groups/channels)
or if you are connected to a Test DC (a Telegram datacenter server for tests) instead of Production DC
([read FAQ #6](#wrong-server) for more)

To help determine if `chats.chats` is empty or does not contain a certain chat, you should [dump the chat list to the screen](EXAMPLES.md#list-chats)
or simply use a debugger: Place a breakpoint after the Messages_GetAllChats call, run the program up to there, and use a Watch pane to display the content of the chats.chats dictionary.

<a name="shutdown"></a>
#### 10. I get "Connection shut down" errors in my logs

There are various reasons why you may get this error. Here are the explanation and how to solve it:

1) On secondary DCs *(DC used to download files)*, a Connection shut down is considered "normal"  
Your main DC is the one WTelegramClient connects to during login. Secondary DC connections are established and maintained when you download files.
The DC number for an operation or error is indicated with a prefix like "2>" on the log line.
If Telegram servers decide to shutdown this secondary connection, it's not an issue, WTelegramClient will re-establish the connection later if necessary.

2) Occasional connection shutdowns on the main DC should be caught by WTelegramClient and the reactor should automatically reconnect to the DC
*(up to `MaxAutoReconnects` times)*.  
This should be transparent and pending API calls should automatically be resent upon reconnection.
You can choose to increase `MaxAutoReconnects` if it happens too often because your Internet connection is unstable.

3) If you reach `MaxAutoReconnects` disconnections, then the **Update** event handler will receive a `ReactorError` object to notify you of the problem.  
In this case, the recommended action would be to dispose the client and recreate one

4) In case of slow Internet connection or if you break in the debugger for some time,
you might also get Connection shutdown because your client couldn't send Pings to Telegram in the allotted time.  
In this case, you can use the `PingInterval` property to increase the delay between pings *(for example 300 seconds instead of 60)*.

<a name="TLSharp"></a>
#### 11. How to migrate from TLSharp? How to sign-in/sign-up/register account properly?

First, make sure you read the [ReadMe documentation](README.md) completely, it contains essential information and a quick tutorial to easily understand how to correctly use the library.

WTelegramClient approach is much more simpler and secure than TLSharp.

All client APIs have dedicated async methods that you can call like this: `await client.Method_Name(param1, param2, ...)`  
See the [full method list](https://core.telegram.org/methods) (just replace the dot with an underscore in the names)

A session file is created or resumed automatically on startup, and maintained up-to-date automatically throughout the session.  
That session file is incompatible with TLSharp so you cannot reuse a TLSharp .dat file. You'll need to create a new session.  
To fight against the reselling of fake user accounts, we don't support the import/export of session files from external sources.

**DON'T** call methods Auth_SendCode/SignIn/SignUp/... because all the login phase is handled automatically by calling `await client.LoginUserIfNeeded()` after creating the client.
Your Config callback just need to provide the various login answers if they are needed (see [ReadMe](README.md) and [FAQ #4](#GUI)).  
In particular, it will detect and handle automatically and properly the various login cases/particularity like:
* Login not necessary (when a session is resumed with an already logged-in user)
* Logout required (if you want to change the logged-in user)
* 2FA password required (your Config needs to provide "password")
* Account registration/sign-up required (your Config needs to provide "first_name", "last_name")
* Request to resend the verification code through alternate ways like SMS (if your Config answer an empty "verification_code" initially)
* Transient failures, slowness to respond, checks for encryption key safety, etc..

Contrary to TLSharp, WTelegramClient supports MTProto v2.0 (more secured), transport obfuscation, protocol security checks, MTProto Proxy, real-time updates, multiple DC connections, API documentation in Intellisense...

<a name="heroku"></a><a name="vps"></a><a name="host"></a>
#### 12. How to host my userbot online?

If you need your userbot to run 24/7, you would typically design your userbot as a Console program, compiled for Linux or Windows,
and hosted online on any [VPS Hosting](https://www.google.com/search?q=vps+hosting) (Virtual Private Server).  
Pure WebApp hosts might not be adequate as they will recycle (stop) your app if there is no incoming HTTP requests.

There are many cheap VPS Hosting offers available, and some even have free tier, like Heroku:  
See [Examples/Program_Heroku.cs](Examples/Program_Heroku.cs) for such an implementation and the steps to host/deploy it.

<a name="troubleshoot"></a>
## Troubleshooting guide

Here is a list of common issues and how to fix them so that your program work correctly:
1) Are you using the Nuget package or the library source code?  
It is not recommended to copy/compile the source code of the library for a normal usage.
When built in DEBUG mode, the source code connects to Telegram test servers (see also [FAQ #6](#wrong-server)).  
So you can either:
    - **Recommended:** Use the [official Nuget package](https://www.nuget.org/packages/WTelegramClient) or the [private nuget feed of development builds](https://dev.azure.com/wiz0u/WTelegramClient/_artifacts/feed/WTelegramClient/NuGet/WTelegramClient)
    - Build your code in RELEASE mode
    - Modify your config callback to reply to "server_address" with the IP address of Telegram production servers (as found on your API development tools)

2) Did you call `LoginUserIfNeeded()`?  
If you don't authenticate as a user (or bot), you have access to a very limited subset of Telegram APIs

3) Did you use `await` with every Client methods?  
This library is completely Task-based. You should learn, understand and use the [asynchronous model of C# programming](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/) before proceeding further.

4) Is your program ending immediately instead of waiting for Updates?  
Your program must be running/waiting continuously in order for the background Task to receive and process the Updates. So make sure your main program doesn't end immediately. For a console program, this is typical done by waiting for a key or some close event.

5) Is every Telegram API call rejected? (typically with an exception message like `AUTH_RESTART`)  
The user authentification might have failed at some point (or the user revoked the authorization). It is therefore necessary to go through the authentification again. This can be done by deleting the WTelegram.session file, or at runtime by calling `client.Reset()`
