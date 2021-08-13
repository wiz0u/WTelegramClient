[![NuGet version](https://img.shields.io/nuget/v/WTelegramClient)](https://www.nuget.org/packages/WTelegramClient/)
[![Dev nuget](https://img.shields.io/badge/dynamic/json?color=ffc040&label=Dev%20nuget&query=%24.versions%5B0%5D&url=https%3A%2F%2Fpkgs.dev.azure.com%2Fwiz0u%2F81bd92b7-0bb9-4701-b426-09090b27e037%2F_packaging%2F46ce0497-7803-4bd4-8c6c-030583e7c371%2Fnuget%2Fv3%2Fflat2%2Fwtelegramclient%2Findex.json)](https://dev.azure.com/wiz0u/WTelegramClient/_packaging?_a=package&feed=WTelegramClient&package=WTelegramClient&protocolType=NuGet)
[![Build Status](https://img.shields.io/azure-devops/build/wiz0u/WTelegramClient/7)](https://dev.azure.com/wiz0u/WTelegramClient/_build?definitionId=7)
[![API Layer](https://img.shields.io/badge/API_Layer-121-blueviolet)](https://core.telegram.org/api/layers)
[![Support Chat](https://img.shields.io/badge/Chat_with_us-on_Telegram-0088cc)](https://t.me/WTelegramClient)

# WTelegramClient
### _Telegram client library written 100% in C# and .NET Core_

## How to use

:warning: This library relies on asynchronous C# programming (`async/await`) so make sure you are familiar with this before proceeding.

After installing WTelegramClient through Nuget, your first Console program will be as simple as:
```csharp
static Task Main(string[] _)
{
    using var client = new WTelegram.Client();
    await client.ConnectAsync();
    var user = await client.UserAuthIfNeeded();
    Console.WriteLine($"We are logged-in as {user.username ?? user.first_name + " " + user.last_name} (id {user.id})");
}
```
When run, this will prompt you interactively for your App **api_id** and **api_hash** (that you obtain through Telegram's [API development tools](https://my.telegram.org/apps) page) and try to connect to Telegram servers.

Then it will attempt to sign-in as a user for which you must enter the **phone_number** and the **verification_code** that will be sent to this user (for example through SMS or another Telegram client app the user is connected to).

If the verification succeeds but the phone number is unknown to Telegram, the user might be prompted to sign-up (accepting the Terms of Service) and enter their **first_name** and **last_name**.

And that's it, you now have access to the full range of Telegram services, mainly through calls to `await client.Some_TL_Method(...)`

# Saved session
If you run this program again, you will notice that the previous prompts are gone and you are automatically logged-on and ready to go.

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
There are other configuration items that are queried to your method but returning `null` let WTelegramClient choose a default adequate value.

The configuration items shown above are the only ones that have no default values and are required to be provided by your method.

The constructor also takes another optional delegate parameter that will be called for any other Update or other information/status/service messages that Telegram sends unsollicited, independently of your API requests.

Finally, if you want to redirect the library logs to your logger instead of the Console, you can install a delegate in the `WTelegram.Helpers.Log` static property.
Its `int` argument is the log severity, compatible with the classic [LogLevel enum](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loglevel)

# Example of API call

:information_source: The Telegram API makes extensive usage of base and derived classes, so be ready to use the various syntaxes C# offer to check/cast base classes into the more useful derived classes (`is`, `as`, `case DerivedType` )

To find which derived classes are available for a given base class, the fastest is to check our [TL.Schema.cs](src/TL.Schema.cs) source file as they are listed in groups.

The Telegram [API object classes](https://core.telegram.org/schema) are defined in the `TL` namespace, and the [API functions](https://core.telegram.org/methods) are available as async methods of `Client`.

Below is an example of calling the [messages.getAllChats](https://core.telegram.org/method/messages.getAllChats) API function and enumerating the various groups/channels the user is in, and then using `client.SendMessageAsync` helper function to easily send a message:
```csharp
using TL;
...
var chatsBase = await client.Messages_GetAllChats(null);
if (chatsBase is not Messages_Chats { chats: var chats }) throw new Exception("hu?");
Console.WriteLine("This user has joined the following:");
foreach (var chat in chats)
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
var id = int.Parse(Console.ReadLine());
var target = chats.First(chat => chat.ID == id);
await client.SendMessageAsync(target, "Hello, World");
```

# Other things to know

An invalid API request can result in a RpcException being raised, reflecting the [error code and status text](https://core.telegram.org/api/errors) of the problem.

Beyond the TL async methods, the Client class offers a few other methods to simplify the sending of files, medias or messages.

The other configuration items that you can override include: **session_pathname, server_address, device_model, system_version, app_version, system_lang_code, lang_pack, lang_code**

For the moment, this library requires .NET 5.0 minimum.

# Development status
The library is already well usable for many scenarios involving automated steps based on API requests/responses.

Here are the main expected developments:
- [x] Encrypt session file
- [x] Support SignUp of unregistered users
- [x] Improve code Generator (import of TL-schema JSONs)
- [x] Nuget deployment & public CI feed
- [x] Convert API functions classes to real methods and serialize structures without using Reflection
- [x] Separate background task for reading/handling update messages independently
- [x] Support MTProto 2.0
- [x] Support users with 2FA enabled
- [ ] Support secret chats end-to-end encryption & PFS
- [ ] Support all service messages
