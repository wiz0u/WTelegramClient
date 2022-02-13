using System;
using System.Linq;
using System.Threading.Tasks;
using TL;

namespace WTelegramClientTest
{
	static class Program_GetAllChats
	{
		// This code is similar to what you should have obtained if you followed the README introduction
		// I've just added a few comments to explain further what's going on

		// go to Project Properties > Debug > Environment variables and add at least these: api_id, api_hash, phone_number
		static string Config(string what)
		{
			if (what == "api_id") return Environment.GetEnvironmentVariable("api_id");
			if (what == "api_hash") return Environment.GetEnvironmentVariable("api_hash");
			if (what == "phone_number") return Environment.GetEnvironmentVariable("phone_number");
			if (what == "verification_code") return null; // let WTelegramClient ask the user with a console prompt 
			if (what == "first_name") return "John";      // if sign-up is required
			if (what == "last_name") return "Doe";        // if sign-up is required
			if (what == "password") return "secret!";     // if user has enabled 2FA
			return null;
		}

		static async Task Main(string[] _)
		{
			using var client = new WTelegram.Client(Config);
			var user = await client.LoginUserIfNeeded();
			Console.WriteLine($"We are logged-in as {user.username ?? user.first_name + " " + user.last_name} (id {user.id})");

			var chats = await client.Messages_GetAllChats(); // chats = groups/channels (does not include users dialogs)
			Console.WriteLine("This user has joined the following:");
			foreach (var (id, chat) in chats.chats)
				switch (chat)
				{
					case Chat smallgroup when (smallgroup.flags & Chat.Flags.deactivated) == 0:
						Console.WriteLine($"{id}:  Small group: {smallgroup.title} with {smallgroup.participants_count} members");
						break;
					case Channel channel when (channel.flags & Channel.Flags.broadcast) != 0:
						Console.WriteLine($"{id}: Channel {channel.username}: {channel.title}");
						//Console.WriteLine($"              → access_hash = {channel.access_hash:X}");
						break;
					case Channel group: // no broadcast flag => it's a big group, also called supergroup or megagroup
						Console.WriteLine($"{id}: Group {group.username}: {group.title}");
						//Console.WriteLine($"              → access_hash = {group.access_hash:X}");
						break;
				}

			Console.Write("Type a chat ID to send a message: ");
			long chatId = long.Parse(Console.ReadLine());
			var target = chats.chats[chatId];
			Console.WriteLine($"Sending a message in chat {chatId}: {target.Title}");
			// Next line implicitely creates an adequate InputPeer from ChatBase: (with the access_hash if these is one)
			InputPeer peer = target;
			await client.SendMessageAsync(peer, "Hello, World");
		}
	}
}
