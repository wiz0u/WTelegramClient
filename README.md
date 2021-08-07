# WTelegramClient
## _Telegram client library written 100% in C# and .NET Core_

## How to use

:warning: This library makes heavy use of asynchronous C# programming (`async/await`) so make sure you are familiar with this before attempting to use it.

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

And that's it, you have now access to the full range of Telegram services, mainly through calls to `await client.CallAsync(...)`

# Saved session
If you run this program again, you will notice that the previous prompts are gone and you are automatically logged-on and ready to go.

This is because WTelegramClient saves (typically in the encrypted file **bin\WTelegram.session**) its state and the authentication keys that were negociated with Telegram so that you needn't sign-in again every time before using the Telegram API.

That file path is configurable, and under various circumstances (changing user or server address) you may want to change it or simply delete the existing session file in order to restart the authentification process.

# Non-interactive configuration
Your next step will probably be to provide a configuration to the client so that the required elements (in bold above) are not prompted through the Console but answered by your program.

For that you need to write a method that will provide the answer, and pass it on the constructor:
```csharp
static string Config(string what)
{
    if (what == "api_id") return "YOUR_API_ID";
    if (what == "api_hash") return "YOUR_API_HASH";
    if (what == "phone_number") return "+12025550156";
    if (what == "verification_code") { Console.Write("Code: "); return Console.ReadLine(); }
    if (what == "first_name") return "John"; // if sign-up is required
    if (what == "last_name") return "Doe";   // if sign-up is required
    return null;
}
...
using var client = new WTelegram.Client(Config);
```
There are other configuration items that are queried to your method but returning `null` let WTelegramClient choose a default adequate value.

The configuration items shown above are the only one that have no default values and are required to be provided by your method.

The constructor also takes another delegate parameter that will be called for any other Update and other information/status messages that Telegram sends unsollicited, independently of your API requests.

Finally, if you want to redirect the library logs to your logger instead of the Console, you can install a delegate in the `WTelegram.Helpers.Log` static property.
The first `int` parameter is the log severity, compatible with the classic [LogLevel enum](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loglevel)

# Example of API call

:information_source: The Telegram API makes extensive usage of base and derived classes, so be ready to use the various syntax C# offers to check/cast base classes into the more useful derived classes (`is`, `as`, `case DerivedType` )

To find which derived classes are available for a given base class, the fastest is to check our [TL.Schema.cs](src/TL.Schema.cs) source file as they appear in groups.

Below is an example of calling the [messages.getAllChats](https://core.telegram.org/method/messages.getAllChats) API and enumerating the various groups/channels the users is into:
```csharp
var chatsBase = await client.CallAsync(new Fn.Messages_GetAllChats { });
if (chatsBase is not Messages_Chats { chats: var chats }) return;
Console.WriteLine("This person has joined the following:");
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
```

[![Build Status](https://dev.azure.com/wiz0u/WTelegramClient/_apis/build/status/wiz0u.WTelegramClient?branchName=master)](https://dev.azure.com/wiz0u/WTelegramClient/_build/latest?definitionId=7&branchName=master)
