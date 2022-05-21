## Example programs using WTelegramClient

For these examples to work as a fully-functional Program.cs, be sure to start with these lines:
```csharp
using System;
using System.Linq;
using TL;

using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
var myself = await client.LoginUserIfNeeded();
```

In this case, environment variables are used for configuration so make sure to
go to your **Project Properties > Debug > Environment variables**
and add at least these variables with adequate value: **api_id, api_hash, phone_number**

Remember that these are just simple example codes that you should adjust to your needs.
In real production code, you might want to properly test the success of each operation or handle exceptions.

ℹ️ WTelegramClient covers 100% of Telegram Client API, much more than the examples below: check the [full API methods list](https://corefork.telegram.org/methods)!  
More examples can also be found in the [Examples folder](Examples) and in answers to [StackOverflow questions](https://stackoverflow.com/questions/tagged/wtelegramclient).

<a name="msg-by-name"></a>
### Send a message to someone by @username
```csharp
var resolved = await client.Contacts_ResolveUsername("MyEch0_Bot"); // username without the @
await client.SendMessageAsync(resolved, "/start");
```
*Note: This also works if the @username points to a channel/group, but you must already have joined that channel before posting there.
If the username is invalid/unused, the API call raises an exception.*

<a name="msg-by-phone"></a>
### Send a message to someone by phone number
```csharp
var contacts = await client.Contacts_ImportContacts(new[] { new InputPhoneContact { phone = "+PHONENUMBER" } });
if (contacts.imported.Length > 0)
    await client.SendMessageAsync(contacts.users[contacts.imported[0].user_id], "Hello!");
```
*Note: To prevent spam, Telegram may restrict your ability to add new phone numbers.*

<a name="markdown"></a>
<a name="html"></a>
### Send an HTML/Markdown formatted message to ourself (Saved Messages)
```csharp
// HTML-formatted text:
var text = $"Hello <u>dear <b>{HtmlText.Escape(myself.first_name)}</b></u>\n" +
            "Enjoy this <code>userbot</code> written with <a href=\"https://github.com/wiz0u/WTelegramClient\">WTelegramClient</a>";
var entities = client.HtmlToEntities(ref text);
var sent = await client.SendMessageAsync(InputPeer.Self, text, entities: entities);
// if you need to convert a Message to HTML: (for easier storage)
text = client.EntitiesToHtml(sent.message, sent.entities);

// Markdown-style text:
var text2 = $"Hello __dear *{Markdown.Escape(myself.first_name)}*__\n" +
            "Enjoy this `userbot` written with [WTelegramClient](https://github.com/wiz0u/WTelegramClient)";
var entities2 = client.MarkdownToEntities(ref text2);
var sent2 = await client.SendMessageAsync(InputPeer.Self, text2, entities: entities2);
// if you need to convert a Message to Markdown: (for easier storage)
text2 = client.EntitiesToMarkdown(sent2.message, sent2.entities);
```
See [MarkdownV2 formatting style](https://core.telegram.org/bots/api/#markdownv2-style) and [HTML formatting style](https://core.telegram.org/bots/api/#html-style) for details.  
*Note: For the `tg://user?id=` notation to work, that user's access hash must have been collected first ([see below](#collect-access-hash))*

<a name="fun"></a>
### Fun with stickers, GIFs, dice, and animated emojies
```csharp
// • List all stickerSets the user has added to his account
var allStickers = await client.Messages_GetAllStickers();
foreach (var stickerSet in allStickers.sets)
    Console.WriteLine($"Pack {stickerSet.short_name} contains {stickerSet.count} stickers");
//if you need details on each: var sticketSetDetails = await client.Messages_GetStickerSet(stickerSet);

// • Send a random sticker from the user's favorites stickers
var favedStickers = await client.Messages_GetFavedStickers();
var stickerDoc = favedStickers.stickers[new Random().Next(favedStickers.stickers.Length)];
await client.SendMessageAsync(InputPeer.Self, null, new InputMediaDocument { id = stickerDoc });

// • Send a specific sticker given the stickerset shortname and emoticon
var friendlyPanda = await client.Messages_GetStickerSet(new InputStickerSetShortName { short_name = "Friendly_Panda" });
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
var dice_emoji = emojies_send_dice[new Random().Next(emojies_send_dice.Length)];
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
var chats = await client.Messages_GetAllChats();
foreach (var (id, chat) in chats.chats)
    if (chat.IsActive)
        Console.WriteLine($"{id} : {chat}");
Console.Write("Choose a chat ID to send a message to: ");
long chatId = long.Parse(Console.ReadLine());
await client.SendMessageAsync(chats.chats[chatId], "Hello, World");
```
Notes:
- This list does not include discussions with other users. For this, you need to use [Messages_GetAllDialogs](#list-dialogs).
- The list returned by Messages_GetAllChats contains the `access_hash` for those chats. Read [FAQ #4](FAQ.MD#access-hash) about this.
- If a basic chat group has been migrated to a supergroup, you may find both the old `Chat` and a `Channel` with different IDs in the `chats.chats` result,
but the old `Chat` will be marked with flag [deactivated] and should not be used anymore. See [Terminology in ReadMe](README.md#terminology).
- You can find a longer version of this method call in [Examples/Program_GetAllChats.cs](Examples/Program_GetAllChats.cs)

<a name="schedule-msg"></a>
### Schedule a message to be sent to a chat
```csharp
var chats = await client.Messages_GetAllChats();
InputPeer peer = chats.chats[1234567890]; // the chat we want
DateTime when = DateTime.UtcNow.AddMinutes(3);
await client.SendMessageAsync(peer, "This will be posted in 3 minutes", schedule_date: when);
```

<a name="upload"></a>
### Upload a media file and post it with caption to a chat
```csharp
const int ChatId = 1234567890; // the chat we want
const string Filepath = @"C:\...\photo.jpg";

var chats = await client.Messages_GetAllChats();
InputPeer peer = chats.chats[ChatId];
var inputFile = await client.UploadFileAsync(Filepath);
await client.SendMediaAsync(peer, "Here is the photo", inputFile);
```

<a name="album"></a>
### Send a grouped media album using photos from various sources
```csharp
// Photo 1 already on Telegram: latest photo found in the user's Saved Messages
var history = await client.Messages_GetHistory(InputPeer.Self);
PhotoBase photoFromTelegram = history.Messages.OfType<Message>().Select(m => m.media).OfType<MessageMediaPhoto>().First().photo;
// Photo 2 uploaded now from our computer:
var uploadedFile = await client.UploadFileAsync(@"C:\Pictures\flower.jpg");
// Photo 3 specified by external url:
const string photoUrl = "https://picsum.photos/310/200.jpg";

var inputMedias = new InputMedia[]
{
    photoFromTelegram, // PhotoBase has implicit conversion to InputMediaPhoto
    new InputMediaUploadedPhoto { file = uploadedFile },
    new InputMediaPhotoExternal() { url = photoUrl },
};
await client.SendAlbumAsync(InputPeer.Self, inputMedias, "My first album");
```
*Note: Don't mix Photos and file Documents in your album, it doesn't work well*

<a name="list-dialogs"></a>
### List all dialogs (chats/groups/channels/user chat) the user is in
```csharp
var dialogs = await client.Messages_GetAllDialogs();
foreach (var dialog in dialogs.dialogs)
    switch (dialogs.UserOrChat(dialog))
    {
        case User     user when user.IsActive: Console.WriteLine("User " + user); break;
        case ChatBase chat when chat.IsActive: Console.WriteLine(chat); break;
    }
```

*Note: the lists returned by Messages_GetAllDialogs contains the `access_hash` for those chats and users.*  
See also the `Main` method in [Examples/Program_ListenUpdates.cs](Examples/Program_ListenUpdates.cs).

<a name="list-members"></a>
### Get all members from a chat
For a basic Chat: *(see Terminology in [ReadMe](README.md#terminology))*
```csharp
var chatFull = await client.Messages_GetFullChat(1234567890); // the chat we want
foreach (var (id, user) in chatFull.users)
    Console.WriteLine(user);
```

For a Channel/Group:
```csharp
var chats = await client.Messages_GetAllChats();
var channel = (Channel)chats.chats[1234567890]; // the channel we want
for (int offset = 0; ;)
{
    var participants = await client.Channels_GetParticipants(channel, null, offset);
    foreach (var (id, user) in participants.users)
        Console.WriteLine(user);
    offset += participants.participants.Length;
    if (offset >= participants.count) break;
}
```

For big Channel/Group, Telegram servers might limit the number of members you can obtain with the normal above method.  
In this case, you can use this helper method, but it can take several minutes to complete:
```csharp
var chats = await client.Messages_GetAllChats();
var channel = (Channel)chats.chats[1234567890]; // the channel we want
var participants = await client.Channels_GetAllParticipants(channel);
```

<a name="join-channel"></a>
### Join a channel/group by @channelname
```csharp
var resolved = await client.Contacts_ResolveUsername("channelname"); // without the @
if (resolved.Chat is Channel channel)
    await client.Channels_JoinChannel(channel);
```

<a name="add-members"></a>
### Add/Invite/Remove someone in a chat
```csharp
var chats = await client.Messages_GetAllChats();
var chat = chats.chats[1234567890]; // the target chat
```
After the above code, once you [have obtained](https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash) an `InputUser` or `User`, you can:
```csharp
// • Directly add the user to a Chat/Channel/group:
await client.AddChatUser(chat, user);
// You may get exception USER_PRIVACY_RESTRICTED if the user has denied the right to be added to a chat
//          or exception USER_NOT_MUTUAL_CONTACT if the user left the chat previously and you want to add him again

// • Obtain the main invite link for the chat, and send it to the user:
var mcf = await client.GetFullChat(chat);
var invite = (ChatInviteExported)mcf.full_chat.ExportedInvite;
await client.SendMessageAsync(user, "Join our group with this link: " + invite.link);

// • Create a new invite link for the chat/channel, and send it to the user
var invite = (ChatInviteExported)await client.Messages_ExportChatInvite(chat, title: "MyLink");
await client.SendMessageAsync(user, "Join our group with this link: " + invite.link);
// • Revoke then delete that invite link (when you no longer need it)
await client.Messages_EditExportedChatInvite(chat, invite.link, revoked: true);
await client.Messages_DeleteExportedChatInvite(chat, invite.link);

// • Remove the user from a Chat/Channel/Group:
await client.DeleteChatUser(chat, user);
```

<a name="history"></a>
### Get all messages (history) from a chat
```csharp
var chats = await client.Messages_GetAllChats();
InputPeer peer = chats.chats[1234567890]; // the chat we want
for (int offset_id = 0; ;)
{
    var messages = await client.Messages_GetHistory(peer, offset_id);
    if (messages.Messages.Length == 0) break;
    foreach (var msgBase in messages.Messages)
        if (msgBase is Message msg)
            Console.WriteLine(msg.message);
    offset_id = messages.Messages[^1].ID;
}
```

<a name="contacts"></a>
### Retrieve the current user's contacts list
There are two different methods. Here is the simpler one:
```csharp
var contacts = await client.Contacts_GetContacts();
foreach (User contact in contacts.users.Values)
    Console.WriteLine($"{contact} {contact.phone}");
```
<a name="takeout"></a>
The second method uses the more complex GDPR export, **takeout session** system.
Here is an example on how to implement it:
```csharp
using TL.Methods; // methods as structures, for Invoke* calls

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
### Downloading photos, medias, files

This is done using the helper method `client.DownloadFileAsync(file, outputStream)`
that simplify the download of a photo/document/file once you get a reference to its location *(through updates or API calls)*.

See [Examples/Program_DownloadSavedMedia.cs](Examples/Program_DownloadSavedMedia.cs) that download all media files you forward to yourself (Saved Messages)

<a name="collect-access-hash"></a>
### Collect Access Hash and save them for later use

You can automate the collection of `access_hash` for the various resources obtained in response to API calls or Update events,
so that you don't have to remember them by yourself or ask the API about them each time.

This is done by activating the experimental `client.CollectAccessHash` system.  
See [Examples/Program_CollectAccessHash.cs](Examples/Program_CollectAccessHash.cs) for how to enable it, and save/restore them for later use.

<a name="proxy"></a>
### Use a proxy to connect to Telegram
SOCKS/HTTP proxies can be used through the `client.TcpHandler` delegate and a proxy library like [StarkSoftProxy](https://www.nuget.org/packages/StarkSoftProxy/):
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
client.TcpHandler = async (address, port) =>
{
    var proxy = new Socks5ProxyClient(ProxyHost, ProxyPort, ProxyUsername, ProxyPassword);
    return proxy.CreateConnection(address, port);
};
var myself = await client.LoginUserIfNeeded();
```
or with [xNetStandard](https://www.nuget.org/packages/xNetStandard/):
```csharp
client.TcpHandler = async (address, port) =>
{
    var proxy = xNet.Socks5ProxyClient.Parse("host:port:username:password");
    return proxy.CreateConnection(address, port);
};
```
<a name="mtproxy"></a>
MTProxy (MTProto proxy) can be used to prevent ISP blocking Telegram servers, through the `client.MTProxyUrl` property:
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
client.MTProxyUrl = "http://t.me/proxy?server=...&port=...&secret=...";
var myself = await client.LoginUserIfNeeded();
```
You can find a list of working MTProxies in channels like [@ProxyMTProto](https://t.me/ProxyMTProto) or [@MTProxyT](https://t.me/MTProxyT) *(right-click the "Connect" buttons)*  
If your Telegram client is already connected to such MTPROTO proxy, you can also export its URL by clicking on the shield button ![🛡](https://raw.githubusercontent.com/telegramdesktop/tdesktop/dev/Telegram/Resources/icons/proxy_on.png) and then **⋮** > **Share**

*Note: WTelegramClient always uses transport obfuscation when connecting to Telegram servers, even without MTProxy*

<a name="logging"></a>
### Change logging settings
By default, WTelegramClient logs are displayed on the Console screen.  
If you are not in a Console app or don't want the logs on screen, you can redirect them as you prefer:

```csharp
// • Log to VS Output debugging pane in addition (+=) to default Console screen logging:
WTelegram.Helpers.Log += (lvl, str) => System.Diagnostics.Debug.WriteLine(str);

// • Log to file in replacement of default Console screen logging, using this static variable:
static StreamWriter WTelegramLogs = new StreamWriter("WTelegram.log", true, Encoding.UTF8) { AutoFlush = true };
...
WTelegram.Helpers.Log = (lvl, str) => WTelegramLogs.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{"TDIWE!"[lvl]}] {str}");

// • In an ASP.NET service, you will typically send logs to an ILogger:
WTelegram.Helpers.Log = (lvl, str) => _logger.Log((LogLevel)lvl, str);
```

<a name="2FA"></a>
### Change 2FA password
```csharp
const string old_password = "password";     // current password if any (unused otherwise)
const string new_password = "new_password"; // or null to disable 2FA
var accountPassword = await client.Account_GetPassword();
var password = accountPassword.current_algo == null ? null : await WTelegram.Client.InputCheckPassword(accountPassword, old_password);
accountPassword.current_algo = null; // makes InputCheckPassword generate a new password
var new_password_hash = new_password == null ? null : await WTelegram.Client.InputCheckPassword(accountPassword, new_password);
await client.Account_UpdatePasswordSettings(password, new Account_PasswordInputSettings
{
    flags = Account_PasswordInputSettings.Flags.has_new_algo,
    new_password_hash = new_password_hash?.A,
    new_algo = accountPassword.new_algo,
    hint = "new password hint",
});
```

<a name="reaction"></a>
<a name="pinned"></a>
### Send a message reaction on pinned messages
This code fetches the available reactions in a given chat, and sends the first reaction emoji (usually 👍) on the last 2 pinned messages:
```csharp
var chats = await client.Messages_GetAllChats();
var chat = chats.chats[1234567890]; // the chat we want
var full = await client.GetFullChat(chat);
var reaction = full.full_chat.AvailableReactions[0]; // choose the first available reaction emoji
var messages = await client.Messages_Search<InputMessagesFilterPinned>(chat, limit: 2);
foreach (var msg in messages.Messages)
    await client.Messages_SendReaction(chat, msg.ID, reaction);
```

<a name="database"></a><a name="sessionStore"></a><a name="customStore"></a>
### Store session data to database or elsewhere, instead of files

If you don't want to store session data into files *(for example if your VPS Hosting doesn't allow that)*, or just for easier management,
you can choose to store the session data somewhere else, like in a database.

The WTelegram.Client constructor takes an optional `sessionStore` parameter to allow storing sessions in an alternate manner.  
Use it to pass a custom Stream-derived class that will **read** (first initial call to Length & Read) and **store** (subsequent Writes) session data to database.

You can find an example for such custom session store in [Examples/Program_Heroku.cs](https://github.com/wiz0u/WTelegramClient/blob/master/Examples/Program_Heroku.cs#L61)
