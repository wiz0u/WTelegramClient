﻿## Example programs using WTelegramClient

The following codes can be saved into a Program.cs file with the only addition of some `using` on top of file, like
```csharp
using System;
using System.Linq;
using TL;
```

Those examples use environment variables for configuration so make sure to go to your **Project Properties > Debug > Environment variables** and add at least these variables with adequate value: **api_id, api_hash, phone_number**

Remember that these are just simple example codes that you should adjust to your needs. In real production code, you're supposed to properly test the success of each operation.

### Send a message to someone by @username
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
await client.LoginUserIfNeeded();
var resolved = await client.Contacts_ResolveUsername("USERNAME");
await resolved.SendMessageAsync(result.users[0], "Hello!");
```
### Send a message to someone by phone number
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
await client.LoginUserIfNeeded();
var imported = await client.Contacts_ImportContacts(new[] { new InputPhoneContact { phone = "+PHONENUMBER" } });
await client.SendMessageAsync(imported.users[0], "Hello!");
```
### Get the list of all chats (groups/channels) the user is in and send a message to one

See [Examples/Program_GetAllChats.cs](Examples/Program_GetAllChats.cs)

Note: the list returned by Messages_GetAllChats contains the `access_hash` for those chats.

### Schedule a message to be sent to a chat
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
await client.LoginUserIfNeeded();
var chats = await client.Messages_GetAllChats(null);
InputPeer peer = chats.chats.First(chat => chat.ID == 1234567890); // the chat we want
DateTime when = DateTime.UtcNow.AddMinutes(3);
await client.SendMessageAsync(peer, "This will be posted in 3 minutes", schedule_date: when);
```
### Upload a media file and post it with caption to a chat
```csharp
const int TargetChatId = 1234567890; // the chat we want
const string Filepath = @"C:\...\photo.jpg";

using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
await client.LoginUserIfNeeded();
var chats = await client.Messages_GetAllChats(null);
InputPeer peer = chats.chats.First(chat => chat.ID == TargetChatId);
var inputFile = await client.UploadFileAsync(Filepath);
await client.SendMediaAsync(peer, "Here is the photo", inputFile);
```
### List all dialogs (chats/groups/channels/user chat) the user is in
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
await client.LoginUserIfNeeded();
var dialogsBase = await client.Messages_GetDialogs(default, 0, null, 0, 0); // dialogs = groups/channels/users
if (dialogsBase is Messages_Dialogs dialogs)
    while (dialogs.dialogs.Length != 0)
    {
        foreach (var dialog in dialogs.dialogs)
            if (dialog is Dialog { peer: var peer } || (dialog is DialogFolder dialogFolder && (peer = dialogFolder.peer) != null))
                switch (peer)
                {
                    case PeerUser: Console.WriteLine("User " + dialogs.users.First(u => u.ID == peer.ID)); break;
                    case PeerChannel or PeerChat: Console.WriteLine(dialogs.chats.First(c => c.ID == peer.ID)); break;
                }
        var lastDialog = (Dialog)dialogs.dialogs[^1];
        var lastMsg = dialogs.messages.LastOrDefault(m => m.Peer.ID == lastDialog.peer.ID && m.ID == lastDialog.top_message);
        InputPeer offsetPeer = lastDialog.peer is PeerUser pu ? dialogs.users.First(u => u.ID == pu.ID)
            : dialogs.chats.First(u => u.ID == lastDialog.peer.ID);
        dialogs = (Messages_Dialogs)await client.Messages_GetDialogs(lastMsg?.Date ?? default, lastDialog.top_message, offsetPeer, 500, 0);
    }
```

Note: the lists returned by Messages_GetDialogs contains the `access_hash` for those chats and users.

See also the `Main` method in [Examples/Program_ListenUpdates.cs](Examples/Program_ListenUpdates.cs).

### Get all members from a chat
For a simple Chat: (see Terminology in [ReadMe](README.md#Terminology-in-Telegram-Client-API))
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
await client.LoginUserIfNeeded();
var chatFull = await client.Messages_GetFullChat(1234567890); // the chat we want
foreach (var user in chatFull.users)
    Console.WriteLine(user);
```

For a Channel/Group:
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
await client.LoginUserIfNeeded();
var chats = await client.Messages_GetAllChats(null);
var channel = (Channel)chats.chats.First(chat => chat.ID == 1234567890); // the channel we want
for (int offset = 0; ;)
{
    var participants = await client.Channels_GetParticipants(channel, null, offset, 1000, 0);
    foreach (var user in participants.users)
        Console.WriteLine(user);
    offset += participants.participants.Length;
    if (offset >= participants.count) break;
}
```

### Get all messages (history) from a chat
```csharp
using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
await client.LoginUserIfNeeded();
var chats = await client.Messages_GetAllChats(null);
InputPeer peer = chats.chats.First(chat => chat.ID == 1234567890); // the chat we want
for (int offset = 0; ;)
{
    var messagesBase = await client.Messages_GetHistory(peer, 0, default, offset, 1000, 0, 0, 0);
    if (messagesBase is not Messages_ChannelMessages channelMessages) break;
    foreach (var msgBase in channelMessages.messages)
        if (msgBase is Message msg)
        {
            // process the message
        }
    offset += channelMessages.messages.Length;
    if (offset >= channelMessages.count) break;
}
```
### Monitor all Telegram events happening for the user

This is done through the `client.Update` callback event.
See [Examples/Program_ListenUpdates.cs](Examples/Program_ListenUpdates.cs).

### Monitor new messages being posted in chats

You have to catch Update events containing an `UpdateNewMessage`.

See the `DisplayMessage` method in [Examples/Program_ListenUpdates.cs](Examples/Program_ListenUpdates.cs).

You can filter specific chats the message are posted in, by looking at the `Message.peer_id` field.

### Download media files you save/forward to yourself

See [Examples/Program_DownloadSavedMedia.cs](Examples/Program_DownloadSavedMedia.cs).

### Collect Access Hash and save them for later use

You can automate the collection of `access_hash` for the various resources obtained in response to API calls or Update events, so that you don't have to remember them by yourself or ask the API about them each time.

This is done by activating the experimental `client.CollectAccessHash` system.
See [Examples/Program_CollectAccessHash.cs](Examples/Program_CollectAccessHash.cs) for how to enable it, and save/restore them for later use.