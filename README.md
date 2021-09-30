[![NuGet version](https://img.shields.io/nuget/v/WTelegramClient)](https://www.nuget.org/packages/WTelegramClient/)
[![Dev nuget](https://img.shields.io/badge/dynamic/json?color=ffc040&label=Dev%20nuget&query=%24.versions%5B0%5D&url=https%3A%2F%2Fpkgs.dev.azure.com%2Fwiz0u%2F81bd92b7-0bb9-4701-b426-09090b27e037%2F_packaging%2F46ce0497-7803-4bd4-8c6c-030583e7c371%2Fnuget%2Fv3%2Fflat2%2Fwtelegramclient%2Findex.json)](https://dev.azure.com/wiz0u/WTelegramClient/_packaging?_a=package&feed=WTelegramClient&package=WTelegramClient&protocolType=NuGet)
[![Build Status](https://img.shields.io/azure-devops/build/wiz0u/WTelegramClient/7)](https://dev.azure.com/wiz0u/WTelegramClient/_build?definitionId=7)
[![API Layer](https://img.shields.io/badge/API_Layer-133-blueviolet)](https://schema.horner.tj)
[![Support Chat](https://img.shields.io/badge/Chat_with_us-on_Telegram-0088cc)](https://t.me/WTelegramClient)

# <img src="logo.png" width="32"/> WTelegramClient
### _Telegram client library written 100% in C# and .NET Standard_

## How to use

⚠️ This library relies on asynchronous C# programming (`async/await`) so make sure you are familiar with this before proceeding.

After installing WTelegramClient through Nuget, your first Console program will be as simple as:
```csharp
static async Task Main(string[] _)
{
    using var client = new WTelegram.Client();
    await client.ConnectAsync();
    var user = await client.LoginUserIfNeeded();
    Console.WriteLine($"We are logged-in as {user.username ?? user.first_name + " " + user.last_name} (id {user.id})");
}
```
When run, this will prompt you interactively for your App **api_id** and **api_hash** (that you obtain through Telegram's [API development tools](https://my.telegram.org/apps) page) and try to connect to Telegram servers.

Then it will attempt to sign-in as a user for which you must enter the **phone_number** and the **verification_code** that will be sent to this user (for example through SMS or another Telegram client app the user is connected to).

If the verification succeeds but the phone number is unknown to Telegram, the user might be prompted to sign-up (accepting the Terms of Service) and enter their **first_name** and **last_name**.

And that's it, you now have access to the [full range of Telegram services](https://core.telegram.org/methods), mainly through calls to `await client.Some_TL_Method(...)`

# Saved session
If you run this program again, you will notice that only **api_id** and **api_hash** are requested, the other prompts are gone and you are automatically logged-on and ready to go.

This is because WTelegramClient saves (typically in the encrypted file **bin\WTelegram.session**) its state and the authentication keys that were negociated with Telegram so that you needn't sign-in again every time.

That file path is configurable, and under various circumstances (changing user or server address) you may want to change it or simply delete the existing session file in order to restart the authentification process.

# Non-interactive configuration
Your next step will probably be to provide a configuration to the client so that the required elements (in bold above) are not prompted through the Console but answered by your program.

To do this, you need to write a method that will provide the answers, and pass it on the constructor:
```csharp
static string Config(string what)
{
    if (what == "api_id") return "YOUR_API_ID";
    if (what == "api_hash") return "YOUR_API_HASH";
    if (what == "phone_number") return "+12025550156";
    if (what == "verification_code") { Console.Write("Code: "); return Console.ReadLine(); }
    if (what == "first_name") return "John";   // if sign-up is required
    if (what == "last_name") return "Doe";     // if sign-up is required
    if (what == "password") return "secret!";  // if user has enabled 2FA
    return null;
}
...
using var client = new WTelegram.Client(Config);
```
There are other configuration items that are queried to your method but returning `null` let WTelegramClient choose a default adequate value. Those shown above are the only ones that have no default values and are required to be provided by your method.

Finally, if you want to redirect the library logs to your logger instead of the Console, you can install a delegate in the `WTelegram.Helpers.Log` static property.
Its `int` argument is the log severity, compatible with the classic [LogLevel enum](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loglevel)

# Example of API call

ℹ️ The Telegram API makes extensive usage of base and derived classes, so be ready to use the various syntaxes C# offer to check/cast base classes into the more useful derived classes (`is`, `as`, `case DerivedType` )

To find which derived classes are available for a given base class, the fastest is to check our [TL.Schema.cs](src/TL.Schema.cs) source file as they are listed in groups.
Intellisense tooltips on API structures/methods will also display a web link to the adequate Telegram documentation page.

The Telegram [API object classes](https://core.telegram.org/schema) are defined in the `TL` namespace, and the [API functions](https://core.telegram.org/methods) are available as async methods of `Client`.

Below is an example of calling the [messages.getAllChats](https://core.telegram.org/method/messages.getAllChats) API function and enumerating the various groups/channels the user is in, and then using `client.SendMessageAsync` helper function to easily send a message:
```csharp
using TL;
...
var chats = await client.Messages_GetAllChats(null);
Console.WriteLine("This user has joined the following:");
foreach (var chat in chats.chats)
    switch (chat)
    {
        case Chat smallgroup when (smallgroup.flags & Chat.Flags.deactivated) == 0:
            Console.WriteLine($"{smallgroup.id}:  Small group: {smallgroup.title} with {smallgroup.participants_count} members");
            break;
        case Channel channel when (channel.flags & Channel.Flags.broadcast) != 0:
            Console.WriteLine($"{channel.id}: Channel {channel.username}: {channel.title}");
            break;
        case Channel group:
            Console.WriteLine($"{group.id}: Group {group.username}: {group.title}");
            break;
    }
Console.Write("Type a chat ID to send a message: ");
long id = long.Parse(Console.ReadLine());
var target = chats.First(chat => chat.ID == id);
await client.SendMessageAsync(target, "Hello, World");
```

# Other things to know

The Client class also offers an `Update` event that is triggered when Telegram servers sends unsollicited Updates or notifications/information/status/service messages, independently of your API requests.

An invalid API request can result in a `RpcException` being raised, reflecting the [error code and status text](https://core.telegram.org/api/errors) of the problem.

The other configuration items that you can override include: **session_pathname, server_address, device_model, system_version, app_version, system_lang_code, lang_pack, lang_code, user_id**

Optional API parameters have a default value of `null` when unset. Passing `null` for a required string/array is the same as *empty* (0-length). Required API parameters/fields can sometimes be set to 0 or `null` when unused (check API documentation).

I've added several useful converters or implicit cast to various API object so that they are more easy to manipulate.

Beyond the TL async methods, the Client class offers a few other methods to simplify the sending of files, medias or messages.

This library works best with **.NET 5.0+** and is also available for **.NET Standard 2.0** (.NET Framework 4.6.1+ & .NET Core 2.0+)

# Troubleshooting guide

Here is a list of common issues and how to fix them so that your program work correctly:
1) Are you using the Nuget package instead of the library source code?
<br/>It is not recommended to copy/compile the source code of the library for a normal usage.
<br/>When built in DEBUG mode, the source code connects to Telegram test servers. So you can either:
    - **Recommended:** Use the [official Nuget package](https://www.nuget.org/packages/WTelegramClient) or the [private nuget feed of development builds](https://dev.azure.com/wiz0u/WTelegramClient/_packaging?_a=package&feed=WTelegramClient&package=WTelegramClient&protocolType=NuGet)
    - Build your code in RELEASE mode
    - Modify your config callback to reply to "server_address" with the IP address of Telegram production servers (as found on your API development tools)

2) After `ConnectAsync()`, are you calling `LoginUserIfNeeded()`?
<br/>If you don't authenticate as a user (or bot), you have access to a very limited subset of Telegram APIs

3) Did you use `await` with every Client methods?
<br/>This library is completely Task-based and you should learn, understand and use the [asynchronous model of C# programming](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/) before proceeding further.

4) Are you keeping a live reference to the Client instance and dispose it only at the end of your program?
<br/>If you create the instance in a submethod and don't store it somewhere permanent, it might be destroyed by the garbage collector at some point. So as long as the client must be running, make sure the reference is stored in a (static) field or somewhere appropriate.
<br/>Also, as the Client class inherits `IDisposable`, remember to call `client.Dispose()` when your program ends (or exit a `using` scope).

5) Is your program ending immediately instead of waiting for Updates?
<br/>Your program must be running/waiting continuously in order for the background Task to receive and process the Updates. So make sure your main program doesn't end immediately. For a console program, this is typical done by waiting for a key or some close event.

6) Is every Telegram API call rejected? (typically with an exception message like `AUTH_RESTART`)
<br/>The user authentification might have failed at some point (or the user revoked the authorization). It is therefore necessary to go through the authentification again. This can be done by deleting the WTelegram.session file, or at runtime by calling `client.Reset()`

# Library uses and limitations
This library can be used for any Telegram scenarios including:
- Sequential or parallel automated steps based on API requests/responses
- Real-time monitoring of incoming Updates/Messages
- Download/upload of files/media
- etc...

Secret chats (end-to-end encryption, PFS) and connection to CDN DCs have not been tested yet.

Developers feedbacks are welcome in the Telegram channel [@WTelegramClient](https://t.me/WTelegramClient)
