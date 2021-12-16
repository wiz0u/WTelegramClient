## Example programs using WTelegramClient

The following codes can be saved into a Program.cs file with the only addition of some `using` on top of file, like
```csharp
using System;
using System.Linq;
using TL;
```

Those examples use environment variables for configuration so make sure to
go to your **Project Properties > Debug > Environment variables**
and add at least these variables with adequate value: **api_id, api_hash, phone_number**

Remember that these are just simple example codes that you should adjust to your needs.
In real production code, you might want to properly test the success of each operation or handle exceptions.

<a name="join-channel"></a>
### Join a channel/group by @channelname
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
await client.LoginUserIfNeeded();
var resolved = await client.Contacts_ResolveUsername("channelname"); // without the @
if (resolved.UserOrChat is Channel channel)
    await client.Channels_JoinChannel(channel);
```

<a name="msg-by-name"></a>
### Send a message to someone by @username
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
await client.LoginUserIfNeeded();
var resolved = await client.Contacts_ResolveUsername("username"); // without the @
await client.SendMessageAsync(resolved, "Hello!");
```
*Note: This also works if the @username points to a channel/group, but you must already have joined that channel before posting there.
If the username is invalid/unused, the API call raises an exception.*

<a name="msg-by-phone"></a>
### Send a message to someone by phone number
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
await client.LoginUserIfNeeded();
var contacts = await client.Contacts_ImportContacts(new[] { new InputPhoneContact { phone = "+PHONENUMBER" } });
if (contacts.imported.Length > 0)
    await client.SendMessageAsync(contacts.users[contacts.imported[0].user_id], "Hello!");
```
*Note: To prevent spam, Telegram may restrict your ability to add new phone numbers.*

<a name="markdown"></a>
### Send a Markdown message to ourself (Saved Messages)
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
var user = await client.LoginUserIfNeeded();
var text = $"Hello __dear *{Markdown.Escape(user.first_name)}*__\nEnjoy this `userbot` written with [WTelegramClient](https://github.com/wiz0u/WTelegramClient)";
var entities = client.MarkdownToEntities(ref text);
await client.SendMessageAsync(InputPeer.Self, text, entities: entities);
```
See [MarkdownV2 formatting style](https://core.telegram.org/bots/api/#markdownv2-style) for details.  
*Note: For the `tg://user?id=` notation to work, that user's access hash must have been collected first ([see below](#collect-access-hash))*

<a name="dice"></a>
### Send a random dice (or other "game of chance" animated emoji)
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
var user = await client.LoginUserIfNeeded();
var appConfig = await client.Help_GetAppConfig();
if (appConfig["emojies_send_dice"] is string[] emojies_send_dice) // get list of animated "dice" emojies
{
    var which = new Random().Next(emojies_send_dice.Length); // choose one of the available emojies
    await client.SendMessageAsync(InputPeer.Self, null, new InputMediaDice { emoticon = emojies_send_dice[which] });
}
```

<a name="list-chats"></a>
### List all chats (groups/channels) the user is in and send a message to one
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
await client.LoginUserIfNeeded();
var chats = await client.Messages_GetAllChats(null);
foreach (var (id, chat) in chats.chats)
    if (chat.IsActive)
        Console.WriteLine($"{id} : {chat}");
Console.Write("Choose a chat ID to send a message to: ");
long chatId = long.Parse(Console.ReadLine());
await client.SendMessageAsync(chats.chats[chatId], "Hello, World");
```
*Note: the list returned by Messages_GetAllChats contains the `access_hash` for those chats.*  
See a longer version of this example in [Examples/Program_GetAllChats.cs](Examples/Program_GetAllChats.cs)

<a name="schedule-msg"></a>
### Schedule a message to be sent to a chat
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
await client.LoginUserIfNeeded();
var chats = await client.Messages_GetAllChats(null);
InputPeer peer = chats.chats[1234567890]; // the chat we want
DateTime when = DateTime.UtcNow.AddMinutes(3);
await client.SendMessageAsync(peer, "This will be posted in 3 minutes", schedule_date: when);
```

<a name="upload"></a>
### Upload a media file and post it with caption to a chat
```csharp
const int TargetChatId = 1234567890; // the chat we want
const string Filepath = @"C:\...\photo.jpg";

using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
await client.LoginUserIfNeeded();
var chats = await client.Messages_GetAllChats(null);
InputPeer peer = chats.chats[TargetChatId];
var inputFile = await client.UploadFileAsync(Filepath);
await client.SendMediaAsync(peer, "Here is the photo", inputFile);
```

<a name="list-dialog"></a>
### List all dialogs (chats/groups/channels/user chat) the user is in
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
await client.LoginUserIfNeeded();
var dialogs = await client.Messages_GetDialogs(default, 0, null, 0, 0);
while (dialogs.Dialogs.Length != 0)
{
    foreach (var dialog in dialogs.Dialogs)
        switch (dialogs.UserOrChat(dialog))
        {
            case UserBase user when user.IsActive: Console.WriteLine("User " + user); break;
            case ChatBase chat when chat.IsActive: Console.WriteLine(chat); break;
        }
    var lastDialog = dialogs.Dialogs[^1];
    var lastMsg = dialogs.Messages.LastOrDefault(m => m.Peer.ID == lastDialog.Peer.ID && m.ID == lastDialog.TopMessage);
    var offsetPeer = dialogs.UserOrChat(lastDialog).ToInputPeer();
    dialogs = await client.Messages_GetDialogs(lastMsg?.Date ?? default, lastDialog.TopMessage, offsetPeer, 500, 0);
}
```

*Note: the lists returned by Messages_GetDialogs contains the `access_hash` for those chats and users.*  
See also the `Main` method in [Examples/Program_ListenUpdates.cs](Examples/Program_ListenUpdates.cs).

<a name="list-members"></a>
### Get all members from a chat
For a simple Chat: (see Terminology in [ReadMe](README.md#terminology))
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
await client.LoginUserIfNeeded();
var chatFull = await client.Messages_GetFullChat(1234567890); // the chat we want
foreach (var (id, user) in chatFull.users)
    Console.WriteLine(user);
```

For a Channel/Group:
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
await client.LoginUserIfNeeded();
var chats = await client.Messages_GetAllChats(null);
var channel = (Channel)chats.chats[1234567890]; // the channel we want
for (int offset = 0; ;)
{
    var participants = await client.Channels_GetParticipants(channel, null, offset, 1000, 0);
    foreach (var (id, user) in participants.users)
        Console.WriteLine(user);
    offset += participants.participants.Length;
    if (offset >= participants.count) break;
}
```

For big Channel/Group, Telegram servers might limit the number of members you can obtain with the normal above method.  
In this case, you can use this helper method, but it can take several minutes to complete:
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
await client.LoginUserIfNeeded();
var chats = await client.Messages_GetAllChats(null);
var channel = (Channel)chats.chats[1234567890]; // the channel we want
var participants = await client.Channels_GetAllParticipants(channel);
```

<a name="history"></a>
### Get all messages (history) from a chat
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
await client.LoginUserIfNeeded();
var chats = await client.Messages_GetAllChats(null);
InputPeer peer = chats.chats[1234567890]; // the chat we want
for (int offset = 0; ;)
{
    var messages = await client.Messages_GetHistory(peer, 0, default, offset, 1000, 0, 0, 0);
    foreach (var msgBase in messages.Messages)
        if (msgBase is Message msg)
            Console.WriteLine(msg.message);
    offset += messages.Messages.Length;
    if (offset >= messages.Count) break;
}
```

<a name="contacts"></a>
### Retrieve the current user's contacts list
There are two different methods. Here is the simpler one:
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
await client.LoginUserIfNeeded();
var contacts = await client.Contacts_GetContacts(0);
foreach (User contact in contacts.users.Values)
    Console.WriteLine($"{contact} {contact.phone}");
```
<a name="takeout"></a>
The second method uses the more complex GDPR export, **takeout session** system.
Here is an example on how to implement it:
```csharp
using TL.Methods; // methods as structures, for Invoke* calls

using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
await client.LoginUserIfNeeded();
var takeout = await client.Account_InitTakeoutSession(contacts: true);
var finishTakeout = new Account_FinishTakeoutSession();
try
{
    var savedContacts = await client.InvokeWithTakeout(takeout.id, new Contacts_GetSaved());
    foreach (SavedPhoneContact contact in savedContacts)
        Console.WriteLine($"{contact.first_name} {contact.last_name} {contact.phone}, added on {contact.date}");
    finishTakeout.flags = Account_FinishTakeoutSession.Flags.success;
}
finally
{
    await client.InvokeWithTakeout(takeout.id, finishTakeout);
}
```

<a name="updates"></a>
### Monitor all Telegram events happening for the user

This is done through the `client.Update` callback event.

See [Examples/Program_ListenUpdates.cs](Examples/Program_ListenUpdates.cs).

<a name="monitor-msg"></a>
### Monitor new messages being posted in chats

You have to handle `client.Update` events containing an `UpdateNewMessage`.

See the `DisplayMessage` method in [Examples/Program_ListenUpdates.cs](Examples/Program_ListenUpdates.cs).

You can filter specific chats the message are posted in, by looking at the `Message.peer_id` field.

<a name="download"></a>
### Download media files you forward to yourself (Saved Messages)

This is done using the helper method `client.DownloadFileAsync(file, outputStream)`
that simplify the download of a photo/document/file once you get a reference to its location.

See [Examples/Program_DownloadSavedMedia.cs](Examples/Program_DownloadSavedMedia.cs).

<a name="collect-access-hash"></a>
### Collect Access Hash and save them for later use

You can automate the collection of `access_hash` for the various resources obtained in response to API calls or Update events,
so that you don't have to remember them by yourself or ask the API about them each time.

This is done by activating the experimental `client.CollectAccessHash` system.  
See [Examples/Program_CollectAccessHash.cs](Examples/Program_CollectAccessHash.cs) for how to enable it, and save/restore them for later use.

<a name="proxy"></a>
### Use a proxy to connect to Telegram
This can be done using the `client.TcpHandler` delegate and a proxy library like [StarkSoftProxy](https://www.nuget.org/packages/StarkSoftProxy/):
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
client.TcpHandler = async (address, port) =>
{
    var proxy = new Socks5ProxyClient(ProxyHost, ProxyPort, ProxyUsername, ProxyPassword);
    return proxy.CreateConnection(address, port);
};
var user = await client.LoginUserIfNeeded();
Console.WriteLine($"We are logged-in as {user.username ?? user.first_name + " " + user.last_name}");
```
or with [xNetStandard](https://www.nuget.org/packages/xNetStandard/):
```csharp
client.TcpHandler = async (address, port) =>
{
    var proxy = xNet.Socks5ProxyClient.Parse("host:port:username:password");
    return proxy.CreateConnection(address, port);
};
```

<a name="logging"></a>
### Change logging settings
Log to VS Output debugging pane in addition to default Console screen logging:
```csharp
WTelegram.Helpers.Log += (lvl, str) => System.Diagnostics.Debug.WriteLine(str);
```
Log to file in replacement of default Console screen logging:
```csharp
WTelegram.Helpers.Log = (lvl, str) => File.AppendAllText("WTelegram.log", str + Environment.NewLine);
```
More efficient example with a static variable and detailed logging to file:
```csharp
static StreamWriter WTelegramLogs = new StreamWriter("WTelegram.log", true, Encoding.UTF8) { AutoFlush = true };
...
WTelegram.Helpers.Log = (lvl, str) => WTelegramLogs.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{"TDIWE!"[lvl]}] {str}");
