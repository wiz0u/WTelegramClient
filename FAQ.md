# FAQ

Before asking questions, make sure to **[read through the ReadMe first](README.md)**,
take a look at the [example programs](EXAMPLES.md) or [StackOverflow questions](https://stackoverflow.com/questions/tagged/wtelegramclient),
and refer to the [API method list](https://corefork.telegram.org/methods) for the full range of Telegram services available in this library.

➡️ Use Ctrl-F to search this page for the information you seek

<a name="remove-logs"></a>
## 1. How to remove the Console logs?

Writing the library logs to the Console is the default behavior of the `WTelegram.Helpers.Log` delegate.  
You can change the delegate with the `+=` operator to **also** write them somewhere else, or with the `=` operator to prevent them from being printed to screen and instead write them somewhere (file, logger, ...).
In any case, it is not recommended to totally ignore those logs because you wouldn't be able to diagnose a problem after it happens.  

Read the [example about logging settings](EXAMPLES.md#logging) for how to write logs to a file.

<a name="multiple-users"></a>
## 2. How to handle multiple user accounts

The WTelegram.session file contains the authentication keys negociated for the current user.

You could switch the current user via an `Auth_Logout` followed by a `LoginUserIfNeeded` but that would require the user to sign in with a verification_code each time.

Instead, if you want to deal with multiple users from the same machine, the recommended solution is to have a different session file for each user.
This can be done by having your Config callback reply with a different filename (or folder) for "**session_pathname**" for each user.
This way, you can keep separate session files (each with their authentication keys) for each user.

If you need to manage these user accounts in parallel, you can create multiple instances of WTelegram.Client,
and give them a Config callback that will select a different session file ;
for example: `new WTelegram.Client(what => Config(what, "session42"))`

Also please note that the session files are encrypted with your api_hash (or session_key), so if you change it, the existing session files can't be read anymore.
Your api_id/api_hash represents your application, and shouldn't change with each user account the application will manage.

<a name="GUI"></a>
<a name="ASPNET"></a>
## 3. How to use the library in a WinForms, WPF or ASP.NET application

The library should work without a problem in such applications.
The difficulty might be in your Config callback when the user must enter the verification code or password, as you can't use `Console.ReadLine` here.

For GUI apps, an easy solution is to call `Interaction.InputBox("Enter verification code")` instead.  
This might require adding a reference *(and `using`)* to the Microsoft.VisualBasic assembly.

A more complex solution requires the use of a `ManualResetEventSlim` that you will wait for in Config callback,
and when the user has provided the verification_code through your app, you "set" the event to release your Config callback so it can return the code.  

Another solution is to use the [alternative login method](README.md#alternative-simplified-configuration--login),
calling `client.Login(...)` as the user provides the requested configuration elements.
You can download such full example apps [for WinForms](Examples/WinForms_app.zip) and [for ASP.NET](Examples/ASPnet_webapp.zip)

<a name="access-hash"></a>
## 4. How to use IDs and access_hash? Why the error `CHANNEL_INVALID` or `USER_ID_INVALID`?

⚠️ In Telegram Client API *(contrary to Bot API)*, you **cannot** interact with channels/users/etc. with only their IDs.

You also need to obtain their `access_hash` which is specific to the resource you want to access AND to the currently logged-in user.  
This serves as a proof that the logged-in user is entitled to access that channel/user/photo/document/...
(otherwise, anybody with the ID could access it)

> A small private `Chat` don't need an access_hash and can be queried using their `chat_id` only.
However most common chat groups are not `Chat` but a `Channel` supergroup (without the `broadcast` flag). See [Terminology in ReadMe](README.md#terminology).  
Some TL methods only applies to private `Chat`, some only applies to `Channel` and some to both.

The `access_hash` must usually be provided within the `Input...` structure you pass in argument to an API method (`InputPeer`, `InputChannel`, `InputUser`, etc...).  

You obtain the `access_hash` through TL **description structures** like `Channel`, `User`, `Photo`, `Document` that you receive through updates
or when you query them through API methods like `Messages_GetAllChats`, `Messages_GetAllDialogs`, `Contacts_ResolveUsername`, etc...  

You can use the [`UserOrChat` and `CollectUsersChats` methods](EXAMPLES.md#collect-users-chats) to help you in obtaining/collecting
the description structures you receive via API calls or updates.

Once you obtained the description structure, there are 2 methods for building your `Input...` request structure:
* **Recommended:** Just pass that description structure you already have, in place of the `Input...` argument, it will work!  
*The implicit conversion operators on base classes like `ChatBase/UserBase` will create the `Input...` structure for you automatically.*
* Alternatively, you can manually create the `Input...` structure yourself by extracting the `access_hash` from the description structure

*Note: An `access_hash` obtained from a User/Channel structure with flag `min` may not be usable for most requests. See [Min constructors](https://core.telegram.org/api/min).*

<a name="dev-versions"></a>
## 5. I need to test a feature that has been recently developed but seems not available in my program

The developmental versions of the library are now available as **pre-release** on Nuget (with `-dev` in the version number)

So make sure you tick the checkbox "Include prerelease" in Nuget manager and/or navigate to the Versions list then select the highest `x.x.x-dev.x` version to install in your program.

<a name="wrong-server"></a>
## 6. Telegram asks me to signup (firstname, lastname) even for an existing account
This happens when you connect to Telegram Test servers instead of Production servers.
On these separate test servers, all created accounts and chats are periodically deleted, so you shouldn't use them under normal circumstances.

You can verify this is your issue by looking at [WTelegram logs](EXAMPLES.md#logging) on the line `Connected to (Test) DC x...`

This wrong-server problem typically happens when you use WTelegramClient Github source project in your application in DEBUG builds.  
It is **not recommended** to use WTelegramClient in source code form.
Instead, you should use the Nuget manager to **install package WTelegramClient** into your application.
*And remember to delete the WTelegram.session file to force a new login on the correct server.*

If you use the Github source project in an old .NET Framework 4.x or .NET Core x.x application, you may also experience the following error
> System.TypeInitializationException (FileNotFoundException for "System.Text.Json Version=5.0.0.0 ...")

To fix this, you should also switch to using the [WTelegramClient Nuget package](https://www.nuget.org/packages/WTelegramClient) as it will install the required dependencies for it to work.

<a name="abuse"></a>
## 7. I get errors FLOOD_WAIT_X or PEER_FLOOD, PHONE_NUMBER_BANNED, USER_DEACTIVATED_BAN. I can't import phone numbers.

You can get these kind of problems if you abuse Telegram [Terms of Service](https://telegram.org/tos), or the [API Terms of Service](https://core.telegram.org/api/terms), or make excessive requests.

You can try to wait more between the requests, wait for a day or two to see if the requests become possible again.  
>ℹ️ For FLOOD_WAIT_X with X < 60 seconds (see `client.FloodRetryThreshold`), WTelegramClient will automatically wait the specified delay and retry the request for you.
For longer delays, you can catch the thrown `RpcException` and check the value of property X.

An account that was restricted due to reported spam might receive PEER_FLOOD errors. Read [Telegram Spam FAQ](https://telegram.org/faq_spam) to learn more.

If you think your phone number was banned from Telegram for a wrong reason, you may try to contact [recover@telegram.org](mailto:recover@telegram.org), explaining what you were doing.

In any case, WTelegramClient is not responsible for the bad usage of the library and we are not affiliated to Telegram teams, so there is nothing we can do.

<a name="prevent-ban"></a>
## 8. How to NOT get banned from Telegram?

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

Some additional advices from me:

5. Avoid repetitive polling or repetitive sequence of actions/requests: Save the initial results of your queries, and update those results when you're informed of a change through `OnUpdate` events.
6. Don't buy fake user accounts/sessions and don't extract api_id/hash/authkey/sessions from official clients, this is [specifically forbidden by API TOS](https://core.telegram.org/api/terms#2-transparency). You must use your own api_id and create your own sessions associated with it.
7. If a phone number is brand new, it will be closely monitored by Telegram for abuse, and it can even already be considered a bad user due to bad behavior from the previous owner of that phone number (which may happen often with VoIP or other easy-to-buy-online numbers, so expect fast ban)
8. You may want to use your new phone number account with an official Telegram client and act like a normal user for some time (some weeks/months), before using it for automation with WTelegramClient.
9. When creating a new API ID/Hash, I recommend you use your own phone number with long history of normal Telegram usage, rather than a brand new phone number with short history.
In particular, DON'T create an API ID/Hash for every phone numbers you will control. One API ID/Hash represents your application, which can be used to control several user accounts.
10. If you actually do use the library to spam, scam, or other stuff annoying to everybody, GTFO and don't cry that you got banned using WTelegramClient. Some people don't seem to realize by themselves that what they plan to do with the library is actually negative for the community and are surprised that they got caught.
We don't support such use of the library, and will not help people asking for support if we suspect them of mass-user manipulation.
11. If your client displays Telegram channels to your users, you have to support and display [official sponsored messages](https://core.telegram.org/api/sponsored-messages).

<a name="chat-id"></a>
## 9. Why the error `CHAT_ID_INVALID`?

Most chat groups you see are likely of type `Channel`, not `Chat`.  
This difference is important to understand. Please [read about the Terminology in ReadMe](README.md#terminology).  

You typically get the error `CHAT_ID_INVALID` when you try to call API methods designed specifically for a `Chat`, with the ID of a `Channel`.  
All API methods taking a `long chat_id` as a direct method parameter are for Chats and cannot be used with Channels.

There is probably another method achieving the same result but specifically designed for Channels, and it will have a similar name, but beginning with `Channels_` ...

However, note that those Channel-compatible methods will require an `InputChannel` or `InputPeerChannel` object as argument instead of a simple channel ID.
That object must be created with both fields `channel_id` and `access_hash` correctly filled. You can read more about this in [FAQ #4](#access-hash).

<a name="chats-chats"></a>
<a name="chat-not-found"></a>
## 10. `chats.chats[id]` fails. My chats list is empty or does not contain the chat I'm looking for.

There can be several reasons why `chats.chats` doesn't contain the chat you expect:
- You're searching for a user instead of a chat ID.  
Private messages with a user are not called "chats". See [Terminology in ReadMe](README.md#terminology).  
To obtain the list of users (as well as chats and channels) the logged-in user is currenly engaged in a discussion with, you should [use the API method `Messages_GetAllDialogs`](EXAMPLES.md#list-dialogs)
- The currently logged-in user account has not joined this particular chat.  
API method [`Messages_GetAllChats`](https://corefork.telegram.org/method/messages.getAllChats) will only return those chat groups/channels the user is in, not all Telegram chat groups.  
If you're looking for other Telegram groups/channels/users, try API methods [`Contacts_ResolveUsername`](EXAMPLES.md#msg-by-name) or `Contacts_Search`
- You're trying to use a Bot API (or TDLib) numerical ID, like -1001234567890  
Telegram Client API don't use these kind of IDs for chats. Remove the -100 prefix and try again with the rest (1234567890).
- the `chats.chats` dictionary is empty.  
This is the case if you are logged-in as a brand new user account (that hasn't join any chat groups/channels)
or if you are connected to a Test DC (a Telegram datacenter server for tests) instead of Production DC
([read FAQ #6](#wrong-server) for more)

To help determine if `chats.chats` is empty or does not contain a certain chat, you should [dump the chat list to the screen](EXAMPLES.md#list-chats)
or simply use a debugger: Place a breakpoint after the `Messages_GetAllChats` call, run the program up to there, and use a Watch pane to display the content of the chats.chats dictionary.

<a name="shutdown"></a>
## 11. I get "Connection shut down" errors in my logs

There are various reasons why you may get this error. Here are the explanation and how to solve it:

1) On secondary DCs *(DC used to download files)*, a Connection shut down is considered "normal"  
Your main DC is the one WTelegramClient connects to during login. Secondary DC connections are established and maintained when you download files.
The DC number for an operation or error is indicated with a prefix like "2>" on the log line.
If Telegram servers decide to shutdown this secondary connection, it's not an issue, WTelegramClient will re-establish the connection later if necessary.

2) Occasional connection shutdowns on the main DC should be caught by WTelegramClient and the reactor should automatically reconnect to the DC
*(up to `MaxAutoReconnects` times)*.  
This should be transparent and pending API calls should automatically be resent upon reconnection.
You can choose to increase `MaxAutoReconnects` if it happens too often because your Internet connection is unstable.

3) If you reach `MaxAutoReconnects` disconnections or a reconnection fails, then the **OnOther** event handler will receive a `ReactorError` object to notify you of the problem,
and pending API calls throw the network IOException.  
In this case, the recommended action would be to dispose the client and recreate one (see example [Program_ReactorError.cs](https://github.com/wiz0u/WTelegramClient/blob/master/Examples/Program_ReactorError.cs))

4) In case of slow Internet connection or if you break in the debugger for some time,
you might also get Connection shutdown because your client couldn't send Pings to Telegram in the allotted time.  
In this case, you can use the `PingInterval` property to increase the delay between pings *(for example 300 seconds instead of 60)*.

5) If you're using an [MTProxy](EXAMPLES.md#proxy), some of them are known to be quite unstable. You may want to try switching to another MTProxy that is more stable.

<a name="TLSharp"></a>
## 12. How to migrate from TLSharp? How to sign-in/sign-up/register account properly?

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
* Email registration procedure required (your Config needs to provide "email", "email_verification_code")
* Account registration/sign-up required (your Config needs to provide "first_name", "last_name")
* Request to resend the verification code through alternate ways like SMS (if your Config answer an empty "verification_code" initially)
* Transient failures, slowness to respond, wrong code/password, checks for encryption key safety, etc..

Contrary to TLSharp, WTelegramClient supports MTProto v2.0 (more secured), transport obfuscation, protocol security checks, MTProto [Proxy](EXAMPLES.md#proxy), real-time updates, multiple DC connections, API documentation in Intellisense...

<a name="heroku"></a><a name="vps"></a><a name="host"></a>
## 13. How to host my userbot online?

If you need your userbot to run 24/7, you would typically design your userbot as a Console program, compiled for Linux or Windows,
and hosted online on any [VPS Hosting](https://www.google.com/search?q=vps+hosting) (Virtual Private Server).  
Pure WebApp hosts might not be adequate as they will recycle (stop) your app if there is no incoming HTTP requests.

There are many cheap VPS Hosting offers available, for example Heroku:  
See [Examples/Program_Heroku.cs](https://github.com/wiz0u/WTelegramClient/blob/master/Examples/Program_Heroku.cs?ts=4#L9) for such an implementation and the steps to host/deploy it.

<a name="secrets"></a>
## 14. Secret Chats implementation details

The following choices were made while implementing Secret Chats in WTelegramClient:
- It may not support remote antique Telegram clients *(prior to 2018, still using insecure MTProto 1.0)*
- It doesn't store outgoing messages *(so if remote client was offline for a week and ask us to resend old messages, we will send void data)*
- It doesn't store incoming messages on disk *(it's up to you if you want to store them)*
- If you pass `DecryptMessage` parameter `fillGaps: true` *(default)*, incoming messages are ensured to be delivered to you in correct order.  
If for some reason, we received them in incorrect order, messages are kept in memory until the requested missing messages are obtained.  
If those missing messages are never obtained during the session, incoming messages might get stuck and lost.
- SecretChats file data is only valid for the current user, so make sure to pick the right file *(or a new file name)* if you change logged-in user.
- If you want to accept incoming Secret Chats request only from specific user, you must check it in OnUpdate before:  
`await Secrets.HandleUpdate(ue, ue.chat is EncryptedChatRequested ecr && ecr.admin_id == EXPECTED_USER_ID);`
- As recommended, new encryption keys are negotiated every 100 sent/received messages or after one week.  
If remote client doesn't complete this negotiation before reaching 200 messages, the Secret Chat is aborted.

<a name="compile"></a>
## 15. The example codes don't compile on my machine

The snippets of example codes found in the [ReadMe](README.md) or [Examples](EXAMPLES.md) pages were written for .NET 5 / C# 9 minimum.  
If you're having compiler problem on code constructs such as `using`, `foreach`, `[^1]` or about "Deconstruct",
that typically means you're still using an obsolete version of .NET (Framework 4.x or Core)

Here are the recommended actions to fix your problem:
- Create a new project for .NET 6+ (in Visual Studio 2019 or more recent):
  - Select File > New > Project
  - Search for "C# Console"
  - Select the **Console App**, but NOT Console App (.NET Framework) !  
  - On the framework selection page, choose .NET 6.0 or more recent
  - Now you can start developing for WTelegramClient 🙂
- If you don't want to target a recent version of .NET, you can upgrade your existing project to use the latest version of the C# language:  
  - Close Visual Studio
  - Edit your *.csproj file **with Notepad**
  - Within the first `<PropertyGroup>`, add the following line:  
    `<LangVersion>latest</LangVersion>`
  - Save, close Notepad and reopen your project in Visual Studio
  - If you still have issues on some `foreach` constructs, add this class somewhere in your project:
    ```csharp
    static class Extensions
    {
        public static void Deconstruct<T1, T2>(this KeyValuePair<T1, T2> tuple, out T1 key, out T2 value)
        {
            key = tuple.Key;
            value = tuple.Value;
        }
    }
    ```

Also, remember to add a `using TL;` at the top of your files to have access to all the Telegram API methods.

<a name="troubleshoot"></a>
# Troubleshooting guide

Here is a list of common issues and how to fix them so that your program work correctly:

1) Are you using the Nuget package or the library source code?  
It is not recommended to copy/compile the source code of the library for a normal usage.
When built in DEBUG mode, the source code connects to Telegram test servers (see also [FAQ #6](#wrong-server)).  
So you can either:
    - **Recommended:** Use the [official Nuget package](https://www.nuget.org/packages/WTelegramClient)
    - Build your code in RELEASE mode
    - Modify your config callback to reply to "server_address" with the IP address of Telegram production servers (as found on your API development tools)

2) Did you call `Login` or `LoginUserIfNeeded` succesfully?  
If you don't complete authentication as a user (or bot), you have access to a very limited subset of Telegram APIs.  
Make sure your calls succeed and don't throw an exception.

3) Did you use `await` with every Client methods?  
This library is completely Task-based. You should learn, understand and use the [asynchronous model of C# programming](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/) before proceeding further.  
Using `.Result` or `.Wait()` can lead to deadlocks.

4) Is your program ending immediately instead of waiting for Updates?  
Your program must be running/waiting continuously in order for the background Task to receive and process the Updates.
So make sure your main program doesn't end immediately or dispose the client too soon (via `using`?).
For a console program, this is typical done by waiting for a key or some close event.

5) Is every Telegram API call rejected? (typically with an exception message like `AUTH_RESTART`)  
The user authentification might have failed at some point (or the user revoked the authorization).
It is therefore necessary to go through the authentification again. This can be done by deleting the WTelegram.session file, or at runtime by calling `client.Reset()`
