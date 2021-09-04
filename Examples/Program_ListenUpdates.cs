using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TL;

namespace WTelegramClientTest
{
	class Program_ListenUpdates
	{
		static string Config(string what)
		{
			// go to Project Properties > Debug > Environment variables and add at least these: api_id, api_hash, phone_number
			if (what == "verification_code") { Console.Write("Code: "); return Console.ReadLine(); }
			return Environment.GetEnvironmentVariable(what);
		}

		static async Task Main(string[] _)
		{
			Console.WriteLine("The program will display updates received for the logged-in user. Press any key to terminate");
			WTelegram.Helpers.Log += (l, s) => System.Diagnostics.Debug.WriteLine(s);
			using var client = new WTelegram.Client(Config);// { CollectAccessHash = true };
			client.Update += Client_Update;
			await client.ConnectAsync();
			var user = await client.LoginUserIfNeeded();
			// note that on logging, Telegram may sends a bunch of updates/messages that happened in the past and were not acknowledged
			Console.WriteLine($"We are logged-in as {user.username ?? user.first_name + " " + user.last_name} (id {user.id})");
			await client.Ping(42); // dummy API call.. this is used to force an acknowledge on past updates
			Console.ReadKey();
			await client.Ping(43); // dummy API call.. this is used to force an acknowledge on this session's updates
		}


		private static readonly Dictionary<int, UserBase> users = new();
		private static readonly Dictionary<int, ChatBase> chats = new();
		private static string AUser(int user_id) => users.TryGetValue(user_id, out var user) ? user.DisplayName : $"User {user_id}";
		private static string AChat(int chat_id) => chats.TryGetValue(chat_id, out var chat) ? chat.Title : $"Chat {chat_id}";
		private static string APeer(Peer peer) => peer is null ? null : peer is PeerUser user ? AUser(user.user_id)
			: peer is PeerChat chat ? AChat(chat.chat_id) : peer is PeerChannel channel ? AChat(channel.channel_id) : $"Peer {peer.ID}";

		private static void Client_Update(ITLObject arg)
		{
			switch (arg)
			{
				case UpdateShortMessage usm: Console.WriteLine($"{AUser(usm.user_id)}> {usm.message}"); break;
				case UpdateShortChatMessage uscm: Console.WriteLine($"{AUser(uscm.from_id)} in {AChat(uscm.chat_id)}> {uscm.message}"); break;
				case UpdateShortSentMessage: Console.WriteLine($"You sent a message"); break;
				case UpdateShort updateShort: DisplayUpdate(updateShort.update); break;
				case Updates u:
					foreach (var user in u.users) users[user.ID] = user;
					foreach (var chat in u.chats) chats[chat.ID] = chat;
					foreach (var update in u.updates) DisplayUpdate(update);
					break;
				case UpdatesCombined uc:
					foreach (var user in uc.users) users[user.ID] = user;
					foreach (var chat in uc.chats) chats[chat.ID] = chat;
					foreach (var update in uc.updates) DisplayUpdate(update);
					break;
				default: Console.WriteLine(arg.GetType().Name); break;
			}
		}

		private static void DisplayUpdate(Update update)
		{
			switch (update)
			{
				case UpdateNewMessage unm: DisplayMessage(unm.message); break;
				case UpdateEditMessage uem: Console.Write("(Edit): "); DisplayMessage(uem.message); break;
				case UpdateDeleteMessages udm: Console.WriteLine($"{udm.messages.Length} message(s) deleted"); break;
				case UpdateNewChannelMessage uncm: DisplayMessage(uncm.message); break;
				case UpdateEditChannelMessage uecm: Console.Write("(Edit): "); DisplayMessage(uecm.message); break;
				case UpdateDeleteChannelMessages udcm: Console.WriteLine($"{udcm.messages.Length} message(s) deleted in {AChat(udcm.channel_id)}"); break;
				case UpdateUserTyping uut: Console.WriteLine($"{AUser(uut.user_id)} is {uut.action.GetType().Name[11..^6]}"); break;
				case UpdateChatUserTyping ucut: Console.WriteLine($"{APeer(ucut.from_id)} is {ucut.action.GetType().Name[11..^6]} in {AChat(ucut.chat_id)}"); break;
				case UpdateChannelUserTyping ucut2: Console.WriteLine($"{APeer(ucut2.from_id)} is {ucut2.action.GetType().Name[11..^6]} in {AChat(ucut2.channel_id)}"); break;
				case UpdateChatParticipants { participants: ChatParticipants cp }: Console.WriteLine($"{cp.participants.Length} participants in {AChat(cp.chat_id)}"); break;
				case UpdateUserStatus uus: Console.WriteLine($"{AUser(uus.user_id)} is now {uus.status.GetType().Name[10..]}"); break;
				case UpdateUserName uun: Console.WriteLine($"{AUser(uun.user_id)} has changed profile name: @{uun.username} {uun.first_name} {uun.last_name}"); break;
				case UpdateUserPhoto uup: Console.WriteLine($"{AUser(uup.user_id)} has changed profile photo"); break;
				default: Console.WriteLine(update.GetType().Name); break;
			}
		}

		private static void DisplayMessage(MessageBase messageBase)
		{
			switch (messageBase)
			{
				case Message m: Console.WriteLine($"{APeer(m.from_id) ?? m.post_author} in {APeer(m.peer_id)}> {m.message}"); break;
				case MessageService ms: Console.WriteLine($"{APeer(ms.from_id)} in {APeer(ms.peer_id)} [{ms.action.GetType().Name[13..]}]"); break;
			}
		}
	}
}
