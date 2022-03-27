using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TL;

namespace WTelegramClientTest
{
	static class Program_CollectAccessHash
	{
		private const string StateFilename = "SavedState.json";
		private const long DurovID = 1006503122; // known ID for Durov's Channel
		private static SavedState savedState = new();

		// go to Project Properties > Debug > Environment variables and add at least these: api_id, api_hash, phone_number
		static async Task Main(string[] _)
		{
			Console.WriteLine("The program demonstrate how to load/save/use collected access hash.");
			WTelegram.Helpers.Log = (l, s) => System.Diagnostics.Debug.WriteLine(s);
			using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
			client.CollectAccessHash = true;

			if (File.Exists(StateFilename))
			{
				Console.WriteLine("Loading previously saved access hashes from disk...");
				using (var stateStream = File.OpenRead(StateFilename))
					savedState = await JsonSerializer.DeserializeAsync<SavedState>(stateStream);
				foreach (var id_hash in savedState.Channels) client.SetAccessHashFor<Channel>(id_hash.Key, id_hash.Value);
				foreach (var id_hash in savedState.Users) client.SetAccessHashFor<User>(id_hash.Key, id_hash.Value);
			}

			Console.WriteLine("Connecting to Telegram...");
			await client.LoginUserIfNeeded();

			var durovAccessHash = client.GetAccessHashFor<Channel>(DurovID);
			if (durovAccessHash != 0)
			{
				// we already know the access hash for Durov's Channel, so we can directly use it
				Console.WriteLine($"Channel @durov has ID {DurovID} and access hash was already collected: {durovAccessHash:X}");
			}
			else
			{
				// Zero means the access hash for Durov's Channel was not collected yet.
				// So we need to obtain it through Client API calls whose results contains the access_hash field, such as:
				// - Messages_GetAllChats   (see Program_GetAllChats.cs   for an example on how to use it)
				// - Messages_GetAllDialogs (see Program_ListenUpdates.cs for an example on how to use it)
				// - Contacts_ResolveUsername                (see below for an example on how to use it)
				// and many more API methods...
				// The access_hash fields can be found inside instance of User, Channel, Photo, Document, etc..
				// usually listed through their base class UserBase, ChatBase, PhotoBase, DocumentBase, etc...
				Console.WriteLine("Resolving channel @durov to get its ID, access hash and other infos...");
				var durovResolved = await client.Contacts_ResolveUsername("durov"); // @durov = Durov's Channel 
				if (durovResolved.peer.ID != DurovID)
					throw new Exception("@durov has changed channel ID ?!");
				durovAccessHash = client.GetAccessHashFor<Channel>(DurovID); // should have been collected from the previous API result
				if (durovAccessHash == 0)
					throw new Exception("No access hash was automatically collected !? (shouldn't happen)");
				Console.WriteLine($"Channel @durov has ID {DurovID} and access hash was automatically collected: {durovAccessHash:X}");
			}

			Console.WriteLine("With the access hash, we can now join the channel for example.");
			await client.Channels_JoinChannel(new InputChannel(DurovID, durovAccessHash));

			Console.WriteLine("Channel joined. Press any key to save and exit");
			Console.ReadKey(true);

			Console.WriteLine("Saving all collected access hashes to disk for next run...");
			savedState.Channels = client.AllAccessHashesFor<Channel>().ToList();
			savedState.Users = client.AllAccessHashesFor<User>().ToList();
			using (var stateStream = File.Create(StateFilename))
				await JsonSerializer.SerializeAsync(stateStream, savedState);
		}

		class SavedState
		{
			public List<KeyValuePair<long, long>> Channels { get; set; } = new();
			public List<KeyValuePair<long, long>> Users { get; set; } = new();
		}
	}
}
