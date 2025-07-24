# Example programs using WTelegramClient

For these examples to work as a fully-functional Program.cs, be sure to start with these lines:
```csharp
using System;
using System.Linq;
using TL;

using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
await client.LoginUserIfNeeded();
```

In this case, environment variables are used for configuration so make sure to
go to your **Project Properties > Debug > Launch Profiles > Environment variables**
and add at least these variables with adequate values: **api_id, api_hash, phone_number**

Remember that these are just simple example codes that you should adjust to your needs.
In real production code, you might want to properly test the success of each operation or handle exceptions,
and avoid calling the same methods (like `Messages_GetAllChats`) repetitively.

➡️ Use Ctrl-F to search this page for the example matching your needs  
WTelegramClient covers 100% of Telegram Client API, much more than the examples below: check the [full API methods list](https://corefork.telegram.org/methods)!  
More examples can also be found in the [Examples folder](https://github.com/wiz0u/WTelegramClient/tree/master/Examples) and in answers to [StackOverflow questions](https://stackoverflow.com/questions/tagged/wtelegramclient).

<a name="logging"></a>
## Change logging settings
By default, WTelegramClient logs are displayed on the Console screen.  
If you are not in a Console app or don't want the logs on screen, you can redirect them as you prefer:

```csharp
// • Log to file in replacement of default Console screen logging, using this static variable:
static StreamWriter WTelegramLogs = new StreamWriter("WTelegram.log", true, Encoding.UTF8) { AutoFlush = true };
...
WTelegram.Helpers.Log = (lvl, str) => WTelegramLogs.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{"TDIWE!"[lvl]}] {str}");

// • Log to VS Output debugging pane in addition (+=) to the default Console screen logging:
WTelegram.Helpers.Log += (lvl, str) => System.Diagnostics.Debug.WriteLine(str);

// • In ASP.NET service, you will typically send logs to an ILogger:
WTelegram.Helpers.Log = (lvl, str) => _logger.Log((LogLevel)lvl, str);

// • Disable logging (⛔️𝗗𝗢𝗡'𝗧 𝗗𝗢 𝗧𝗛𝗜𝗦 as you won't be able to diagnose any upcoming problem):
WTelegram.Helpers.Log = (lvl, str) => { };
```

The `lvl` argument correspond to standard [LogLevel values](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loglevel#fields)

<a name="msg-by-name"></a>
## Send a message to someone by @username
```csharp
var resolved = await client.Contacts_ResolveUsername("JsonDumpBot"); // username without the @
await client.SendMessageAsync(resolved, "/start");
```
*Note: This also works if the @username points to a channel/group, but you must already have joined that channel before sending a message to it.
If the username is invalid/unused, the API call raises an RpcException.*

<a name="markdown"></a>
<a name="html"></a>
## Convert message to/from HTML or Markdown, and send it to ourself (Saved Messages)
```csharp
// HTML-formatted text:
var text = $"Hello <u>dear <b>{HtmlText.Escape(client.User.first_name)}</b></u>\n" +
           "Enjoy this <code>userbot</code> written with <a href=\"https://github.com/wiz0u/WTelegramClient\">WTelegramClient</a>";
var entities = client.HtmlToEntities(ref text);
var sent = await client.SendMessageAsync(InputPeer.Self, text, entities: entities);
// if you need to convert a sent/received Message to HTML: (easier to store)
text = client.EntitiesToHtml(sent.message, sent.entities);
```
```csharp
// Markdown-style text:
var text2 = $"Hello __dear *{Markdown.Escape(client.User.first_name)}*__\n" +
            "Enjoy this `userbot` written with [WTelegramClient](https://github.com/wiz0u/WTelegramClient)";
var entities2 = client.MarkdownToEntities(ref text2);
var sent2 = await client.SendMessageAsync(InputPeer.Self, text2, entities: entities2);
// if you need to convert a sent/received Message to Markdown: (easier to store)
text2 = client.EntitiesToMarkdown(sent2.message, sent2.entities);
```
See [HTML formatting style](https://core.telegram.org/bots/api/#html-style) and [MarkdownV2 formatting style](https://core.telegram.org/bots/api/#markdownv2-style) for details.  
*Note: For the `tg://user?id=` notation to work, you need to pass the _users dictionary in arguments ([see below](#collect-users-chats))*

<a name="list-dialogs"></a>
## List all dialogs (chats/groups/channels/user chat) we are currently in
```csharp
var dialogs = await client.Messages_GetAllDialogs();
foreach (Dialog dialog in dialogs.dialogs)
{
    switch (dialogs.UserOrChat(dialog))
    {
        case User     user when user.IsActive: Console.WriteLine("User " + user); break;
        case ChatBase chat when chat.IsActive: Console.WriteLine(chat); break;
    }
    //var latestMsg = dialogs.messages.FirstOrDefault(m => m.Peer.ID == dialog.Peer.ID && m.ID == dialog.TopMessage);
}
```

Notes:
- The lists returned by Messages_GetAllDialogs contains the `access_hash` for those chats and users.
- See also the `Main` method in [Examples/Program_ListenUpdates.cs](https://github.com/wiz0u/WTelegramClient/blob/master/Examples/Program_ListenUpdates.cs?ts=4#L18).  
- To retrieve the dialog information about a specific [peer](README.md#terminology), use `client.Messages_GetPeerDialogs(inputPeer)`

<a name="list-chats"></a>
## List all chats (groups/channels NOT users) that we joined and send a message to one
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
- The list returned by Messages_GetAllChats contains the `access_hash` for those chats. Read [FAQ #4](FAQ.md#access-hash) about this.
- If a basic chat group has been migrated to a supergroup, you may find both the old `Chat` and a `Channel` with different IDs in the `chats.chats` result,
but the old `Chat` will be marked with flag [deactivated] and should not be used anymore. See [Terminology in ReadMe](README.md#terminology).
- You can find a longer version of this method call in [Examples/Program_GetAllChats.cs](https://github.com/wiz0u/WTelegramClient/blob/master/Examples/Program_GetAllChats.cs?ts=4#L31)

<a name="list-members"></a>
## List the members from a chat
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
    if (offset >= participants.count || participants.participants.Length == 0) break;
}
```

For big Channel/Group, Telegram servers might limit the number of members you can obtain with the normal above method.  
In this case, you can use the following helper method, but it can take several minutes to complete:
```csharp
var chats = await client.Messages_GetAllChats();
var channel = (Channel)chats.chats[1234567890]; // the channel we want
var participants = await client.Channels_GetAllParticipants(channel);
```

You can use specific filters, for example to list only the channel owner/admins:
```csharp
var participants = await client.Channels_GetParticipants(channel, filter: new ChannelParticipantsAdmins());
foreach (var participant in participants.participants) // This is the better way to enumerate the result
{
    var user = participants.users[participant.UserID];
    if (participant is ChannelParticipantCreator cpc) Console.WriteLine($"{user} is the owner '{cpc.rank}'");
    else if (participant is ChannelParticipantAdmin cpa) Console.WriteLine($"{user} is admin '{cpa.rank}'");
}
```
*Note: It is not possible to list only the Deleted Accounts. Those will be automatically removed by Telegram from your group after a while*

<a name="history"></a>
## Fetch all messages (history) from a chat/user
```csharp
var chats = await client.Messages_GetAllChats();
InputPeer peer = chats.chats[1234567890]; // the chat (or User) we want
for (int offset_id = 0; ;)
{
    var messages = await client.Messages_GetHistory(peer, offset_id);
    if (messages.Messages.Length == 0) break;
    foreach (var msgBase in messages.Messages)
    {
        var from = messages.UserOrChat(msgBase.From ?? msgBase.Peer); // from can be User/Chat/Channel
        if (msgBase is Message msg)
            Console.WriteLine($"{from}> {msg.message} {msg.media}");
        else if (msgBase is MessageService ms)
            Console.WriteLine($"{from} [{ms.action.GetType().Name[13..]}]");
    }
    offset_id = messages.Messages[^1].ID;
}
```
Notes:
- `peer` can also be a User, obtained through methods like [`Messages_GetAllDialogs`](#list-dialogs)
- To stop at a specific msg ID, use Messages_GetHistory `min_id` argument. For example, `min_id: dialog.read_inbox_max_id`
- To mark the message history as read, use: `await client.ReadHistory(peer);`

<a name="updates"></a>
## Monitor all Telegram events happening for the user

This is done through the `client.OnUpdates` callback event, or via the [UpdateManager class](FAQ.md#manager) that simplifies the handling of updates.

See [Examples/Program_ListenUpdates.cs](https://github.com/wiz0u/WTelegramClient/blob/master/Examples/Program_ListenUpdates.cs?ts=4#L21).

<a name="monitor-msg"></a>
## Monitor new messages being posted in chats in real-time

You have to handle update events containing an `UpdateNewMessage`.
This can be done through the `client.OnUpdates` callback event, or via the [UpdateManager class](FAQ.md#manager) that simplifies the handling of updates.

See the `HandleMessage` method in [Examples/Program_ListenUpdates.cs](https://github.com/wiz0u/WTelegramClient/blob/master/Examples/Program_ListenUpdates.cs?ts=4#L21).

You can filter specific chats the message are posted in, by looking at the `Message.peer_id` field.  
See also [explanation below](#message-user) to extract user/chat info from messages.

<a name="download"></a>
## Downloading photos, medias, files

This is done using the helper method `client.DownloadFileAsync(file, outputStream)`
that simplifies the download of a photo/document/file once you get a reference to its location *(through updates or API calls)*.

See [Examples/Program_DownloadSavedMedia.cs](https://github.com/wiz0u/WTelegramClient/blob/master/Examples/Program_DownloadSavedMedia.cs?ts=4#L28) that download all media files you forward to yourself (Saved Messages)

_Note: To abort an ongoing download, you can throw an exception via the `progress` callback argument. Example: `(t,s) => ct.ThrowIfCancellationRequested()`_

<a name="upload"></a>
## Upload a media file and post it with caption to a chat
```csharp
const int ChatId = 1234567890; // the chat we want
const string Filepath = @"C:\...\photo.jpg";

var chats = await client.Messages_GetAllChats();
InputPeer peer = chats.chats[ChatId];
var inputFile = await client.UploadFileAsync(Filepath);
await client.SendMediaAsync(peer, "Here is the photo", inputFile);
```

<a name="upload-video"></a>
## Upload a streamable video with optional custom thumbnail
```csharp
var chats = await client.Messages_GetAllChats();
InputPeer peer = chats.chats[1234567890]; // the chat we want
const string videoPath = @"C:\...\video.mp4";
const string thumbnailPath = @"C:\...\thumbnail.jpg";

// Extract video information using FFMpegCore or similar library
var mediaInfo = await FFmpeg.GetMediaInfo(videoPath);
var videoStream = mediaInfo.VideoStreams.FirstOrDefault();
int width = videoStream?.Width ?? 0;
int height = videoStream?.Height ?? 0;
int duration = (int)mediaInfo.Duration.TotalSeconds;

// Upload video file
var inputFile = await Client.UploadFileAsync(videoPath);

// Prepare InputMedia structure with video attributes
var media = new InputMediaUploadedDocument(inputFile, "video/mp4",
    new DocumentAttributeVideo { w = width, h = height, duration = duration, 
        flags = DocumentAttributeVideo.Flags.supports_streaming });
if (thumbnailPath != null)
{
	// upload custom thumbnail and complete InputMedia structure
    var inputThumb = await client.UploadFileAsync(thumbnailPath);
    media.thumb = inputThumb;
    media.flags |= InputMediaUploadedDocument.Flags.has_thumb;
}

// Send the media message
await client.SendMessageAsync(peer, "caption", media);
```
*Note: This example requires FFMpegCore NuGet package for video metadata extraction. You can also manually set width, height, and duration if you know the video properties.*

<a name="album"></a>
## Send a grouped media album using photos from various sources
```csharp
// Photo 1 already on Telegram: latest photo found in the user's Saved Messages
var history = await client.Messages_GetHistory(InputPeer.Self);
PhotoBase photoFromTelegram = history.Messages.OfType<Message>().Select(m => m.media).OfType<MessageMediaPhoto>().First().photo;
// Photo 2 uploaded now from our computer:
var uploadedFile = await client.UploadFileAsync(@"C:\Pictures\flower.jpg");
// Photo 3 specified by external url:
const string photoUrl = "https://picsum.photos/310/200.jpg";

var inputMedias = new List<InputMedia>
{
    photoFromTelegram, // PhotoBase has implicit conversion to InputMediaPhoto
    new InputMediaUploadedPhoto { file = uploadedFile },
    new InputMediaPhotoExternal { url = photoUrl },
    //or Document, InputMediaDocument, InputMediaUploadedDocument, InputMediaDocumentExternal...
};
await client.SendAlbumAsync(InputPeer.Self, inputMedias, "My first album");
```
*Note: Don't mix Photos and file Documents in your album, it doesn't work well*

<a name="forward"></a><a name="copy"></a>
## Forward or copy a message to another chat
```csharp
// Determine which chats and message to forward/copy
var chats = await client.Messages_GetAllChats();
var from_chat = chats.chats[1234567890];  // source chat
var to_chat = chats.chats[1234567891];    // destination chat
var history = await client.Messages_GetHistory(from_chat, limit: 1);
var msg = history.Messages[0] as Message; // last message of source chat

// • Forward the message (only the source message id is necessary)
await client.ForwardMessagesAsync(from_chat, [msg.ID], to_chat);

// • Copy the message without the "Forwarded" header (only the source message id is necessary)
await client.ForwardMessagesAsync(from_chat, [msg.ID], to_chat, drop_author: true);

// • Alternative solution to copy the message (the full message is needed)
await client.SendMessageAsync(to_chat, msg.message, msg.media?.ToInputMedia(), entities: msg.entities);
```

<a name="schedule-msg"></a>
## Schedule a message to be sent to a chat
```csharp
var chats = await client.Messages_GetAllChats();
InputPeer peer = chats.chats[1234567890]; // the chat we want
DateTime when = DateTime.UtcNow.AddMinutes(3);
await client.SendMessageAsync(peer, "This will be posted in 3 minutes", schedule_date: when);
```
*Note: Make sure your computer clock is synchronized with Internet time*

<a name="fun"></a>
## Fun with stickers, GIFs, dice, and animated emojies
```csharp
// • List all stickerSets the user has added to his account
var allStickers = await client.Messages_GetAllStickers();
foreach (var stickerSet in allStickers.sets)
    Console.WriteLine($"Pack {stickerSet.short_name} contains {stickerSet.count} stickers");
//if you need details on each: var sticketSetDetails = await client.Messages_GetStickerSet(stickerSet);

// • Send a random sticker from the user's favorites stickers
var favedStickers = await client.Messages_GetFavedStickers();
var stickerDoc = favedStickers.stickers[new Random().Next(favedStickers.stickers.Length)];
await client.SendMessageAsync(InputPeer.Self, null, stickerDoc);

// • Send a specific sticker given the stickerset shortname and emoticon
var friendlyPanda = await client.Messages_GetStickerSet("Friendly_Panda");
var laughId = friendlyPanda.packs.First(p => p.emoticon == "😂").documents[0];
var laughDoc = friendlyPanda.documents.First(d => d.ID == laughId);
await client.SendMessageAsync(InputPeer.Self, null, laughDoc);

// • Send a GIF from an internet URL
await client.SendMessageAsync(InputPeer.Self, null, new InputMediaDocumentExternal
        { url = "https://upload.wikimedia.org/wikipedia/commons/2/2c/Rotating_earth_%28large%29.gif" });

// • Send a GIF stored on the computer (you can save inputFile for later reuse)
var inputFile = await client.UploadFileAsync(@"C:\Pictures\Rotating_earth_(large).gif");
await client.SendMediaAsync(InputPeer.Self, null, inputFile);

// • Send a random dice/game-of-chance effect from the list of available "dices", see https://core.telegram.org/api/dice
var appConfig = await client.Help_GetAppConfig();
var emojies_send_dice = appConfig.config["emojies_send_dice"] as string[];
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

<a name="reaction"></a><a name="pinned"></a><a name="custom_emoji"></a>
## Fun with custom emojies and reactions on pinned messages
```csharp
// • Sending a message with custom emojies in Markdown to ourself:
var text = "Vicksy says Hi! ![👋](tg://emoji?id=5190875290439525089)";
var entities = client.MarkdownToEntities(ref text, premium: true);
await client.SendMessageAsync(InputPeer.Self, text, entities: entities);
// also available in HTML: <tg-emoji emoji-id="5190875290439525089">👋</tg-emoji>

// • Fetch all available standard emoji reactions
var all_emoji = await client.Messages_GetAvailableReactions();

var chats = await client.Messages_GetAllChats();
var chat = chats.chats[1234567890]; // the chat we want

// • Check reactions available in this chat
var full = await client.GetFullChat(chat);
Reaction reaction = full.full_chat.AvailableReactions switch
{
    ChatReactionsSome some => some.reactions[0], // only some reactions are allowed => pick the first
    ChatReactionsAll all =>                      // all reactions are allowed in this chat
        all.flags.HasFlag(ChatReactionsAll.Flags.allow_custom) && client.User.flags.HasFlag(TL.User.Flags.premium)
        ? new ReactionCustomEmoji { document_id = 5190875290439525089 }     // we can use custom emoji reactions here
        : new ReactionEmoji { emoticon = all_emoji.reactions[0].reaction }, // else, pick the first standard emoji reaction
    _ => null                                    // reactions are not allowed in this chat
};
if (reaction == null) return;

// • Send the selected reaction on the last 2 pinned messages
var messages = await client.Messages_Search<InputMessagesFilterPinned>(chat, limit: 2);
foreach (var msg in messages.Messages)
    await client.Messages_SendReaction(chat, msg.ID, reaction: new[] { reaction });
```
*Note: you can find custom emoji document IDs via API methods like [Messages_GetFeaturedEmojiStickers](https://corefork.telegram.org/methods#working-with-custom-animated-emojis) or inspecting messages entities. Access hash is not required*


<a name="join-channel"></a>
## Join a channel/group by their public name or invite link
* For a public channel/group `@channelname`  
If you have a link of the form `https://t.me/channelname`, you need to extract the `channelname` from the URL.  
You can resolve the channel/group username and join it like this:
```csharp
var resolved = await client.Contacts_ResolveUsername("channelname"); // without the @
if (resolved.Chat is Channel channel)
    await client.Channels_JoinChannel(channel);
```
* For a private channel/group/chat, you need to have an invite link  
Telegram invite links can typically have two forms: `https://t․me/joinchat/HASH` or `https://t․me/+HASH` *(note the '+' prefix here)*  
To use them, you need to extract the `HASH` part from the URL and then you can use those two methods:  
```csharp
var chatInvite = await client.Messages_CheckChatInvite("HASH"); // optional: get information before joining  
await client.Messages_ImportChatInvite("HASH"); // join the channel/group  
// Note: This works also with HASH invite links from public channel/group
```
`CheckChatInvite` can return [3 different types of invitation object](https://corefork.telegram.org/type/ChatInvite)

You can also use helper methods `AnalyzeInviteLink` and `GetMessageByLink` to more easily fetch information from links.
<a name="add-members"></a>
## Add/Invite/Remove someone in a chat
```csharp
var chats = await client.Messages_GetAllChats();
var chat = chats.chats[1234567890]; // the target chat
```
After the above code, once you [have obtained](FAQ.md#access-hash) an `InputUser` or `User`, you can:
```csharp
// • Directly add the user to a Chat/Channel/group:
var miu = await client.AddChatUser(chat, user);
// You may get exception USER_NOT_MUTUAL_CONTACT if the user left the chat previously and you want to add him again
//      or a result with miu.missing_invitees listing users that denied the right to be added to a chat

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

<a name="msg-by-phone"></a>
## Send a message to someone by phone number
```csharp
var contacts = await client.Contacts_ImportContacts(new[] { new InputPhoneContact { phone = "+PHONENUMBER" } });
if (contacts.imported.Length > 0)
    await client.SendMessageAsync(contacts.users[contacts.imported[0].user_id], "Hello!");
```
*Note: Don't use this method too much. To prevent spam, Telegram may restrict your ability to add new phone numbers or ban your account.*

<a name="contacts"></a>
## Retrieve the current user's contacts list
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

<a name="collect-access-hash"></a>
<a name="collect-users-chats"></a>
<a name="user-or-chat"></a>
## Collect Users/Chats description structures and access hash

Many API calls return a structure with a `users` and a `chats` field at the root of the structure.
This is also the case for updates passed to `client.OnUpdates`.

These two dictionaries give details *(including access hash)* about the various users/chats that will be typically referenced in subobjects deeper in the structure,
typically in the form of a `Peer` object or a `user_id`/`chat_id` field.

In such case, the root structure inherits the `IPeerResolver` interface, and you can use the `UserOrChat(peer)` method to resolve a `Peer`
into either a `User` or `ChatBase` (`Chat`,`Channel`...) description structure *(depending on the kind of peer it was describing)*

You can also use the `CollectUsersChats` helper method to collect these 2 fields into 2 aggregate dictionaries to remember details
*(including access hashes)* about all the users/chats you've encountered so far.
This method also helps dealing with [incomplete `min` structures](https://core.telegram.org/api/min).

Example of usage:
```csharp
private Dictionary<long, User> _users = new();
private Dictionary<long, ChatBase> _chats = new();
...
var dialogs = await client.Messages_GetAllDialogs();
dialogs.CollectUsersChats(_users, _chats);

private async Task OnUpdates(UpdatesBase updates)
{
    updates.CollectUsersChats(_users, _chats);
    ...
}

// example of UserOrChat usage:
var firstPeer = dialogs.UserOrChat(dialogs.dialogs[0].Peer);
if (firstPeer is User firstUser) Console.WriteLine($"First dialog is with user {firstUser}");
else if (firstPeer is ChatBase firstChat) Console.WriteLine($"First dialog is {firstChat}");
```

*Note: If you need to save/restore those dictionaries between runs of your program, it's up to you to serialize their content to disk*

<a name="message-user"></a>
## Get chat and user info from a message
First, you should read the above [section about collecting users/chats](#collect-users-chats), and the [FAQ about dealing with IDs](FAQ.md#access-hash).

A message contains those two fields/properties:
- `peer_id`/`Peer` that identify WHERE the message was posted
- `from_id`/`From` that identify WHO posted the message (it can be `null` in some case of anonymous posting)

These two fields derive from class `Peer` and can be of type `PeerChat`, `PeerChannel` or `PeerUser` depending on the nature of WHERE & WHO
(private chat with a user? message posted BY a channel IN a chat? ...)

> ✳️ It is recommended that you use the [UpdateManager class](FAQ.md#manager), as it handles automatically all of the details below, and you just need to use `Manager.UserOrChat(peer)` or Manager.Users/Chats dictionaries

The root structure where you obtained the message (typically `UpdatesBase` or `Messages_MessagesBase`) inherits from `IPeerResolver`.
This allows you to call `.UserOrChat(peer)` on the root structure, in order to resolve those fields into a `User` class, or a `ChatBase`-derived class
(typically `Chat` or `Channel`) which will give you details about the peer, instead of just the ID, and can be implicitly converted to `InputPeer`.

However, in some case _(typically when dealing with updates)_, Telegram might choose to not include details about a peer
because it expects you to already know about it (`UserOrChat` returns `null`).
That's why you should collect users/chats details each time you're dealing with Updates or other API results inheriting from `IPeerResolver`,
and use the collected dictionaries to find details about users/chats
([see previous section](#collect-users-chats) and [Program_ListenUpdates.cs](https://github.com/wiz0u/WTelegramClient/blob/master/Examples/Program_ListenUpdates.cs?ts=4#L21) example)

And finally, it may happen that you receive updates of type `UpdateShortMessage` or `UpdateShortChatMessage` with totally unknown peers (even in your collected dictionaries).
In this case, [Telegram recommends](https://core.telegram.org/api/updates#recovering-gaps) that you use the [`Updates_GetDifference`](https://corefork.telegram.org/method/updates.getDifference) method to retrieve the full information associated with the short message.
Here is an example showing how to deal with `UpdateShortMessage`: (same for `UpdateShortChatMessage`)
```csharp
if (updates is UpdateShortMessage usm && !_users.ContainsKey(usm.user_id))
{
    var fullDiff = await client.Updates_GetDifference(usm.pts - usm.pts_count, usm.date, 0)
    fullDiff.CollectUsersChats(_users, _chats);
}
```


<a name="proxy"></a>
## Use a proxy or MTProxy to connect to Telegram
SOCKS/HTTPS proxies can be used through the `client.TcpHandler` delegate and a proxy library like [StarkSoftProxy](https://www.nuget.org/packages/StarkSoftProxy/) or [xNetStandard](https://www.nuget.org/packages/xNetStandard/):
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
client.TcpHandler = async (address, port) =>
{
    var proxy = new Socks5ProxyClient(ProxyHost, ProxyPort, ProxyUsername, ProxyPassword);
    //var proxy = xNet.Socks5ProxyClient.Parse("host:port:username:password");
    return proxy.CreateConnection(address, port);
};
await client.LoginUserIfNeeded();
```
<a name="mtproxy"></a>
MTProxy (MTProto proxy) can be used to prevent ISP blocking Telegram servers, through the `client.MTProxyUrl` property:
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
client.MTProxyUrl = "https://t.me/proxy?server=...&port=...&secret=...";
await client.LoginUserIfNeeded();
```
You can find a list of working MTProxies in channels like [@ProxyMTProto](https://t.me/s/ProxyMTProto) or [@MTProxyT](https://t.me/s/MTProxyT) *(right-click the "Connect" buttons)*  
If your Telegram client is already connected to such MTPROTO proxy, you can also export its URL by clicking on the shield button ![🛡](https://raw.githubusercontent.com/telegramdesktop/tdesktop/dev/Telegram/Resources/icons/proxy_on.png) and then **⋮** > **Share**

*Note: WTelegramClient always uses transport obfuscation when connecting to Telegram servers, even without MTProxy*

<a name="2FA"></a>
## Change 2FA password
```csharp
const string old_password = "password";     // current password if any (unused otherwise)
const string new_password = "new_password"; // or null to disable 2FA
var accountPwd = await client.Account_GetPassword();
var password = accountPwd.current_algo == null ? null : await WTelegram.Client.InputCheckPassword(accountPwd, old_password);
accountPwd.current_algo = null; // makes InputCheckPassword generate a new password
var new_password_hash = new_password == null ? null : await WTelegram.Client.InputCheckPassword(accountPwd, new_password);
await client.Account_UpdatePasswordSettings(password, new Account_PasswordInputSettings
{
    flags = Account_PasswordInputSettings.Flags.has_new_algo,
    new_password_hash = new_password_hash?.A,
    new_algo = accountPwd.new_algo,
    hint = "new password hint",
});
```

<a name="database"></a><a name="sessionStore"></a><a name="customStore"></a>
## Store session data to database or elsewhere, instead of files

If you don't want to store session data into files *(for example if your VPS Hosting doesn't allow that)*, or just for easier management,
you can choose to store the session data somewhere else, like in a database.

The WTelegram.Client constructor takes an optional `sessionStore` parameter to allow storing sessions in an alternate manner.  
Use it to pass a custom Stream-derived class that will **read** (first initial call to Length & Read) and **store** (subsequent Writes) session data to database.

You can find an example for such custom session store in [Examples/Program_Heroku.cs](https://github.com/wiz0u/WTelegramClient/blob/master/Examples/Program_Heroku.cs?ts=4#L61)

<a name="e2e"></a><a name="secrets"></a>
## Send/receive end-to-end encrypted messages & files in Secret Chats

This can be done easily using the helper class `WTelegram.SecretChats` offering methods to manage/encrypt/decrypt secret chats & encrypted messages/files.

You can view a full working example at [Examples/Program_SecretChats.cs](https://github.com/wiz0u/WTelegramClient/blob/master/Examples/Program_SecretChats.cs?ts=4#L11).

Secret Chats have been tested successfully with Telegram Android & iOS official clients.  
You can also check our [FAQ for more implementation details](FAQ.md#14-secret-chats-implementation-details).
