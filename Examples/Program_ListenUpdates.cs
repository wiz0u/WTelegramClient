using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TL;

namespace WTelegramClientTest
{
	static class Program_ListenUpdates
	{
		static WTelegram.Client Client;
		static User My;
		static readonly Dictionary<long, User> Users = new();
		static readonly Dictionary<long, ChatBase> Chats = new();

		// go to Project Properties > Debug > Environment variables and add at least these: api_id, api_hash, phone_number
		static async Task Main(string[] _)
		{
			Console.WriteLine("The program will display updates received for the logged-in user. Press any key to terminate");
			WTelegram.Helpers.Log = (l, s) => System.Diagnostics.Debug.WriteLine(s);
			Client = new WTelegram.Client(Environment.GetEnvironmentVariable);
			using (Client)
			{
				Client.Update += Client_Update;
				My = await Client.LoginUserIfNeeded();
				Users[My.id] = My;
				// Note that on login Telegram may sends a bunch of updates/messages that happened in the past and were not acknowledged
				Console.WriteLine($"We are logged-in as {My.username ?? My.first_name + " " + My.last_name} (id {My.id})");
				// We collect all infos about the users/chats so that updates can be printed with their names
				var dialogs = await Client.Messages_GetAllDialogs(); // dialogs = groups/channels/users
				dialogs.CollectUsersChats(Users, Chats);
				Console.ReadKey();
			}
		}

		private static void Client_Update(IObject arg)
		{
			if (arg is not UpdatesBase updates) return;
			updates.CollectUsersChats(Users, Chats);
			foreach (var update in updates.UpdateList)
				switch (update)
				{
					case UpdateNewMessage unm: DisplayMessage(unm.message); break;
					case UpdateEditMessage uem: DisplayMessage(uem.message, true); break;
					case UpdateDeleteChannelMessages udcm: Console.WriteLine($"{udcm.messages.Length} message(s) deleted in {Chat(udcm.channel_id)}"); break;
					case UpdateDeleteMessages udm: Console.WriteLine($"{udm.messages.Length} message(s) deleted"); break;
					case UpdateUserTyping uut: Console.WriteLine($"{User(uut.user_id)} is {uut.action}"); break;
					case UpdateChatUserTyping ucut: Console.WriteLine($"{Peer(ucut.from_id)} is {ucut.action} in {Chat(ucut.chat_id)}"); break;
					case UpdateChannelUserTyping ucut2: Console.WriteLine($"{Peer(ucut2.from_id)} is {ucut2.action} in {Chat(ucut2.channel_id)}"); break;
					case UpdateChatParticipants { participants: ChatParticipants cp }: Console.WriteLine($"{cp.participants.Length} participants in {Chat(cp.chat_id)}"); break;
					case UpdateUserStatus uus: Console.WriteLine($"{User(uus.user_id)} is now {uus.status.GetType().Name[10..]}"); break;
					case UpdateUserName uun: Console.WriteLine($"{User(uun.user_id)} has changed profile name: @{uun.username} {uun.first_name} {uun.last_name}"); break;
					case UpdateUserPhoto uup: Console.WriteLine($"{User(uup.user_id)} has changed profile photo"); break;
					default: Console.WriteLine(update.GetType().Name); break; // there are much more update types than the above cases
				}
		}

		private static void DisplayMessage(MessageBase messageBase, bool edit = false)
		{
			if (edit) Console.Write("(Edit): ");
			switch (messageBase)
			{
				case Message m: Console.WriteLine($"{Peer(m.from_id) ?? m.post_author} in {Peer(m.peer_id)}> {m.message}"); break;
				case MessageService ms: Console.WriteLine($"{Peer(ms.from_id)} in {Peer(ms.peer_id)} [{ms.action.GetType().Name[13..]}]"); break;
			}
		}

		private static string User(long id) => Users.TryGetValue(id, out var user) ? user.ToString() : $"User {id}";
		private static string Chat(long id) => Chats.TryGetValue(id, out var chat) ? chat.ToString() : $"Chat {id}";
		private static string Peer(Peer peer) => peer is null ? null : peer is PeerUser user ? User(user.user_id)
			: peer is PeerChat or PeerChannel ? Chat(peer.ID) : $"Peer {peer.ID}";
	}
}
