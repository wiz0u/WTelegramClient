[![NuGet version](https://img.shields.io/nuget/v/WTelegramClient)](https://www.nuget.org/packages/WTelegramClient/)
[![Build Status](https://img.shields.io/azure-devops/build/wiz0u/WTelegramClient/7)](https://dev.azure.com/wiz0u/WTelegramClient/_build?definitionId=7)
[![API Layer](https://img.shields.io/badge/API_Layer-148-blueviolet)](https://corefork.telegram.org/methods)
[![dev nuget](https://img.shields.io/badge/dynamic/json?color=ffc040&label=dev%20nuget&query=%24.versions%5B0%5D&url=https%3A%2F%2Fpkgs.dev.azure.com%2Fwiz0u%2F81bd92b7-0bb9-4701-b426-09090b27e037%2F_packaging%2F46ce0497-7803-4bd4-8c6c-030583e7c371%2Fnuget%2Fv3%2Fflat2%2Fwtelegramclient%2Findex.json)](https://dev.azure.com/wiz0u/WTelegramClient/_artifacts/feed/WTelegramClient/NuGet/WTelegramClient)
[![Support Chat](https://img.shields.io/badge/Chat_with_us-on_Telegram-0088cc)](https://t.me/WTelegramClient)
[![Donate](https://img.shields.io/badge/Help_this_project:-Donate-ff4444)](http://t.me/WTelegramBot?start=donate)

## _Telegram Client API library written 100% in C# and .NET Standard_

This library allows you to connect to Telegram and control a user programmatically (or a bot, but [Telegram.Bot](https://github.com/TelegramBots/Telegram.Bot) is much easier for that).
All the Telegram Client APIs (MTProto) are supported so you can do everything the user could do with a full Telegram GUI client.

This ReadMe is a **quick but important tutorial** to learn the fundamentals about this library. Please read it all.

>⚠️ This library relies on asynchronous C# programming (`async/await`) so make sure you are familiar with this advanced topic before proceeding.  
>If you are a beginner in C#, starting a project based on this library might not be a great idea.

# How to use

After installing WTelegramClient through [Nuget](https://www.nuget.org/packages/WTelegramClient/), your first Console program will be as simple as:
```csharp
static async Task Main(string[] _)
{
    using var client = new WTelegram.Client();
    var myself = await client.LoginUserIfNeeded();
    Console.WriteLine($"We are logged-in as {myself} (id {myself.id})");
}
```
When run, this will prompt you interactively for your App **api_hash** and **api_id** (that you obtain through Telegram's
[API development tools](https://my.telegram.org/apps) page) and try to connect to Telegram servers.
Those api hash/id represent your application and one can be used for handling many user accounts.

Then it will attempt to sign-in *(login)* as a user for which you must enter the **phone_number** and the **verification_code**
that will be sent to this user (for example through SMS, Email, or another Telegram client app the user is connected to).

If the verification succeeds but the phone number is unknown to Telegram, the user might be prompted to sign-up
*(register their account by accepting the Terms of Service)* and provide their **first_name** and **last_name**.  
If the account already exists and has enabled two-step verification (2FA) a **password** might be required.  
In some case, Telegram may request that you associate an **email** with your account for receiving login verification codes,
you may skip this step by leaving **email** empty, otherwise the email address will first receive an **email_verification_code**.  
All these login scenarios are handled automatically within the call to `LoginUserIfNeeded`.

After login, you now have access to the **[full range of Telegram Client APIs](https://corefork.telegram.org/methods)**. 
All those API methods require `using TL;` namespace and are called with an underscore instead of a dot in the method name, like this: `await client.Method_Name(...)`

# Saved session
If you run this program again, you will notice that only **api_hash** is requested, the other prompts are gone and you are automatically logged-on and ready to go.

This is because WTelegramClient saves (typically in the encrypted file **bin\WTelegram.session**) its state
and the authentication keys that were negotiated with Telegram so that you needn't sign-in again every time.

That file path is configurable (session_pathname), and under various circumstances (changing user or server address)
you may want to change it or simply delete the existing session file in order to restart the authentification process.

# Non-interactive configuration
Your next step will probably be to provide a configuration to the client so that the required elements are not prompted through the Console but answered by your program.

To do this, you need to write a method that will provide the answers, and pass it on the constructor:
```csharp
static string Config(string what)
{
    switch (what)
    {
        case "api_id": return "YOUR_API_ID";
        case "api_hash": return "YOUR_API_HASH";
        case "phone_number": return "+12025550156";
        case "verification_code": Console.Write("Code: "); return Console.ReadLine();
        case "first_name": return "John";      // if sign-up is required
        case "last_name": return "Doe";        // if sign-up is required
        case "password": return "secret!";     // if user has enabled 2FA
        default: return null;                  // let WTelegramClient decide the default config
    }
}
...
using var client = new WTelegram.Client(Config);
```
There are other configuration items that are queried to your method but returning `null` let WTelegramClient choose a default adequate value.
Those shown above are the only ones that have no default values and should be provided by your method.

Returning `null` for verification_code or password will show a prompt for console apps, or an error otherwise
*(see [FAQ #3](https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#GUI) for WinForms)*  
Returning `""` for verification_code requests the resending of the code through another system (SMS or Call).

Another simple approach is to pass `Environment.GetEnvironmentVariable` as the config callback and define the configuration items as environment variables
*(undefined variables get the default `null` behavior)*.

Finally, if you want to redirect the library logs to your logger instead of the Console, you can install a delegate in the `WTelegram.Helpers.Log` static property.
Its `int` argument is the log severity, compatible with the [LogLevel enum](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loglevel)

# Alternative simplified configuration & login
Since version 3.0.0, a new approach to login/configuration has been added. Some people might find it easier to deal with:

```csharp
WTelegram.Client client = new WTelegram.Client(YOUR_API_ID, "YOUR_API_HASH");
await DoLogin("+12025550156"); // user's phone_number

async Task DoLogin(string loginInfo) // (add this method to your code)
{
   while (client.User == null)
      switch (await client.Login(loginInfo)) // returns which config is needed to continue login
      {
         case "verification_code": Console.Write("Code: "); loginInfo = Console.ReadLine(); break;
         case "name": loginInfo = "John Doe"; break;    // if sign-up is required (first/last_name)
         case "password": loginInfo = "secret!"; break; // if user has enabled 2FA
         default: loginInfo = null; break;
      }
   Console.WriteLine($"We are logged-in as {client.User} (id {client.User.id})");
}
```

With this method, you can choose in some cases to interrupt the login loop via a `return` instead of `break`, and resume it later
by calling `DoLogin(requestedCode)` again once you've obtained the requested code/password/etc...
See [WinForms example](https://github.com/wiz0u/WTelegramClient/raw/master/Examples/WinForms_app.zip) and [ASP.NET example](https://github.com/wiz0u/WTelegramClient/raw/master/Examples/ASPnet_webapp.zip)

# Example of API call

>ℹ️ The Telegram API makes extensive usage of base and derived classes, so be ready to use the various C# syntaxes
to check/cast base classes into the more useful derived classes (`is`, `as`, `case DerivedType` )

All the Telegram API classes/methods are fully documented through Intellisense: Place your mouse over a class/method name,
or start typing the call arguments to see a tooltip displaying their description, the list of derived classes and a web link to the official API page.

The Telegram [API object classes](https://corefork.telegram.org/schema) are defined in the `TL` namespace,
and the [API functions](https://corefork.telegram.org/methods) are available as async methods of `Client`.

Below is an example of calling the [messages.getAllChats](https://corefork.telegram.org/method/messages.getAllChats) API function,
enumerating the various groups/channels the user is in, and then using `client.SendMessageAsync` helper function to easily send a message:
```csharp
using TL;
...
var chats = await client.Messages_GetAllChats();
Console.WriteLine("This user has joined the following:");
foreach (var (id, chat) in chats.chats)
    switch (chat) // example of downcasting to their real classes:
    {
        case Chat basicChat when basicChat.IsActive:
            Console.WriteLine($"{id}:  Basic chat: {basicChat.title}");
            break;
        case Channel group when group.IsGroup:
            Console.WriteLine($"{id}: Group {group.username}: {group.title}");
            break;
        case Channel channel:
            Console.WriteLine($"{id}: Channel {channel.username}: {channel.title}");
            break;
    }
Console.Write("Type a chat ID to send a message: ");
long chatId = long.Parse(Console.ReadLine());
var target = chats.chats[chatId];
Console.WriteLine($"Sending a message in chat {chatId}: {target.Title}");
await client.SendMessageAsync(target, "Hello, World");
```

➡️ You can find lots of useful code snippets in [EXAMPLES.md](https://github.com/wiz0u/WTelegramClient/blob/master/EXAMPLES.md)
and in the [Examples subdirectory](https://github.com/wiz0u/WTelegramClient/tree/master/Examples).  
➡️ Check [the FAQ](https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#compile) if example codes doesn't compile correctly on your machine, or other troubleshooting.

<a name="terminology"></a>
# Terminology in Telegram Client API

In the API, Telegram uses some terms/classnames that can be confusing as they differ from the terms shown to end-users:
- `Channel` : A (large or public) chat group *(sometimes called [supergroup](https://corefork.telegram.org/api/channel#supergroups))*
or a [broadcast channel](https://corefork.telegram.org/api/channel#channels) (the `broadcast` flag differentiate those)
- `Chat` : A private [basic chat group](https://corefork.telegram.org/api/channel#basic-groups) with less than 200 members
(it may be migrated to a supergroup `Channel` with a new ID when it gets bigger or public, in which case the old `Chat` will still exist but will be `deactivated`)  
**⚠️ Most chat groups you see are really of type `Channel`, not `Chat`!**
- chats : In plural or general meaning, it means either `Chat` or `Channel` *(therefore, no private user discussions)*
- `Peer` : Either a `Chat`, a `Channel` or a `User`
- Dialog : Status of chat with a `Peer` *(draft, last message, unread count, pinned...)*. It represents each line from your Telegram chat list.
- Access Hash : Telegram requires you to provide a specific `access_hash` for users, channels, and other resources before interacting with them.
See [FAQ #4](https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash) to learn more about it.
- DC (DataCenter) : There are a few datacenters depending on where in the world the user (or an uploaded media file) is from.
- Session or Authorization : Pairing between a device and a phone number. You can have several active sessions for the same phone number.

# Other things to know

The Client class also offers an `OnUpdate` event that is triggered when Telegram servers sends Updates (like new messages or status), independently of your API requests.
See [Examples/Program_ListenUpdates.cs](https://github.com/wiz0u/WTelegramClient/blob/master/Examples/Program_ListenUpdates.cs)

An invalid API request can result in a `RpcException` being raised, reflecting the [error code and status text](https://revgram.github.io/errors.html) of the problem.

The other configuration items that you can override include: **session_pathname, email, email_verification_code, session_key, server_address, device_model, system_version, app_version, system_lang_code, lang_pack, lang_code, user_id, bot_token**

Optional API parameters have a default value of `null` when unset. Passing `null` for a required string/array is the same as *empty* (0-length).
Required API parameters/fields can sometimes be set to 0 or `null` when unused (check API documentation or experiment).

I've added several useful converters, implicit cast or helper properties to various API objects so that they are more easy to manipulate.

Beyond the TL async methods, the Client class offers a few other methods to simplify the sending/receiving of files, medias or messages.

This library works best with **.NET 5.0+** (faster, no dependencies) and is also available for **.NET Standard 2.0** (.NET Framework 4.6.1+ & .NET Core 2.0+) and **Xamarin/Mono.Android**

# Library uses and limitations
This library can be used for any Telegram scenarios including:
- Sequential or parallel automated steps based on API requests/responses
- Real-time [monitoring](https://github.com/wiz0u/WTelegramClient/blob/master/EXAMPLES.md#updates) of incoming Updates/Messages
- Download/upload of files/media
- Exchange end-to-end encrypted messages/files in [Secret Chats](https://github.com/wiz0u/WTelegramClient/blob/master/EXAMPLES.md#e2e)
- Building a full-featured interactive client

It has been tested in a Console app, [in Windows Forms](https://github.com/wiz0u/WTelegramClient/raw/master/Examples/WinForms_app.zip),
[in ASP.NET webservice](https://github.com/wiz0u/WTelegramClient/raw/master/Examples/ASPnet_webapp.zip), and in Xamarin/Android.  

Please don't use this library for Spam or Scam. Respect Telegram [Terms of Service](https://telegram.org/tos)
as well as the [API Terms of Service](https://core.telegram.org/api/terms) or you might get banned from Telegram servers.

Developers feedback is welcome in the Telegram support group [@WTelegramClient](https://t.me/WTelegramClient)  
You can also check our [📖 Frequently Asked Questions](https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md) for more help and troubleshooting guide.

If you like this library, please [consider a donation](http://t.me/WTelegramBot?start=donate).❤ This will help the project keep going.
