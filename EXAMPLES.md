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
if (resolved.Chat is Channel channel)
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
var text = $"Hello __dear *{Markdown.Escape(user.first_name)}*__\n" +
            "Enjoy this `userbot` written with [WTelegramClient](https://github.com/wiz0u/WTelegramClient)";
var entities = client.MarkdownToEntities(ref text);
await client.SendMessageAsync(InputPeer.Self, text, entities: entities);
```
See [MarkdownV2 formatting style](https://core.telegram.org/bots/api/#markdownv2-style) for details.  
*Note: For the `tg://user?id=` notation to work, that user's access hash must have been collected first ([see below](#collect-access-hash))*

<a name="fun"></a>
### Fun with stickers, GIFs, dice, and animated emojies
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
var user = await client.LoginUserIfNeeded();
var random = new Random();

// • List all stickerSets the user has added to his account
var allStickers = await client.Messages_GetAllStickers(0);
foreach (var stickerSet in allStickers.sets)
    Console.WriteLine($"Pack {stickerSet.short_name} contains {stickerSet.count} stickers");
//if you need details on each: var sticketSetDetails = await client.Messages_GetStickerSet(stickerSet, 0);

// • Send a random sticker from the user's favorites stickers
var favedStickers = await client.Messages_GetFavedStickers(0);
var stickerDoc = favedStickers.stickers[random.Next(favedStickers.stickers.Length)];
await client.SendMessageAsync(InputPeer.Self, null, new InputMediaDocument { id = stickerDoc });

// • Send a specific sticker given the stickerset shortname and emoticon
var friendlyPanda = await client.Messages_GetStickerSet(new InputStickerSetShortName { short_name = "Friendly_Panda" }, 0);
var laughId = friendlyPanda.packs.First(p => p.emoticon == "😂").documents[0];
var laughDoc = friendlyPanda.documents.First(d => d.ID == laughId);
await client.SendMessageAsync(InputPeer.Self, null, new InputMediaDocument { id = laughDoc });

// • Send a GIF from an internet URL
await client.SendMessageAsync(InputPeer.Self, null, new InputMediaDocumentExternal
        { url = "https://upload.wikimedia.org/wikipedia/commons/2/2c/Rotating_earth_%28large%29.gif" });

// • Send a GIF stored on the computer (you can save inputFile for later reuse)
var inputFile = await client.UploadFileAsync(@"C:\Pictures\Rotating_earth_(large).gif");
await client.SendMediaAsync(InputPeer.Self, null, inputFile);

// • Send a random dice/game-of-chance effect from the list of available "dices", see https://core.telegram.org/api/dice
var appConfig = await client.Help_GetAppConfig();
var emojies_send_dice = appConfig["emojies_send_dice"] as string[];
var dice_emoji = emojies_send_dice[random.Next(emojies_send_dice.Length)];
var diceMsg = await client.SendMessageAsync(InputPeer.Self, null, new InputMediaDice { emoticon = dice_emoji });
Console.WriteLine("Dice result:" + ((MessageMediaDice)diceMsg.media).value);

// • Send an animated emoji with full-screen animation, see https://core.telegram.org/api/animated-emojis#emoji-reactions
// Please note that on Telegram Desktop, you won't view the effect from the sender user's point of view
// You can view the effect if you're on Telegram Android, or if you're the receiving user (instead of Self)
var msg = await client.SendMessageAsync(InputPeer.Self, "🎉");
await Task.Delay(5000); // wait for classic animation to finish
await client.SendMessageAsync(InputPeer.Self, "and now, full-screen animation on the above emoji");
// trigger the full-screen animation, 
var typing = await client.Messages_SetTyping(InputPeer.Self, new SendMessageEmojiInteraction {
    emoticon = "🎉", msg_id = msg.id,
    interaction = new DataJSON { data = @"{""v"":1,""a"":[{""t"":0.0,""i"":1}]}" }
});
await Task.Delay(5000);
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
            case User     user when user.IsActive: Console.WriteLine("User " + user); break;
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

<a name="add-members"></a>
### Add/Invite/Remove someone in a chat
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
await client.LoginUserIfNeeded();
var chats = await client.Messages_GetAllChats(null);
const long chatId = 1234567890; // the target chat
var chat = chats.chats[chatId];
```
After the above code, once you [have obtained](https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash) an `InputUser` or `User`, you can:
```csharp
// • Directly add the user to a simple Chat:
await client.Messages_AddChatUser(1234567890, user, int.MaxValue);
// • Directly add the user to a Channel/group:
await client.Channels_InviteToChannel((Channel)chat, new[] { user });
// You may get exception USER_PRIVACY_RESTRICTED if the user has denied the right to be added to a chat
//          or exception USER_NOT_MUTUAL_CONTACT if the user left the chat previously and you want to add him again

// • Obtain the main invite link for a simple Chat:
var mcf = await client.Messages_GetFullChat(1234567890);
// • Obtain the main invite link for a Channel/group:
var mcf = await client.Channels_GetFullChannel((Channel)chat);
// extract the invite link and send it to the user:
var invite = (ChatInviteExported)mcf.full_chat.ExportedInvite;
await client.SendMessageAsync(user, "Join our group with this link: " + invite.link);

// • Create a new invite link for the chat/channel, and send it to the user
var invite = (ChatInviteExported)await client.Messages_ExportChatInvite(chat, title: "MyLink");
await client.SendMessageAsync(user, "Join our group with this link: " + invite.link);
// • Revoke then delete that invite link (when you no longer need it)
await client.Messages_EditExportedChatInvite(chat, invite.link, revoked: true);
await client.Messages_DeleteExportedChatInvite(chat, invite.link);

// • Remove the user from a simple Chat:
await client.Messages_DeleteChatUser(1234567890, user);
// • Remove the user from a Channel/group:
await client.Channels_EditBanned((Channel)chat, user, new ChatBannedRights { flags = ChatBannedRights.Flags.view_messages });
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
