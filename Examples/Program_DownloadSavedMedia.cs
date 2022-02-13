using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TL;

namespace WTelegramClientTest
{
	static class Program_DownloadSavedMedia
	{
		// go to Project Properties > Debug > Environment variables and add at least these: api_id, api_hash, phone_number
		static async Task Main(string[] args)
		{
			Console.WriteLine("The program will download photos/medias from messages you send/forward to yourself (Saved Messages)");
			using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
			var user = await client.LoginUserIfNeeded();
			client.Update += Client_Update;
			Console.ReadKey();

			async void Client_Update(IObject arg)
			{
				if (arg is not Updates { updates: var updates } upd) return;
				foreach (var update in updates)
				{
					if (update is not UpdateNewMessage { message: Message message })
						continue; // if it's not about a new message, ignore the update
					if (message.peer_id.ID != user.ID)
						continue; // if it's not in the "Saved messages" chat, ignore it

					if (message.media is MessageMediaDocument { document: Document document })
					{
						int slash = document.mime_type.IndexOf('/'); // quick & dirty conversion from MIME type to file extension
						var filename = slash > 0 ? $"{document.id}.{document.mime_type[(slash + 1)..]}" : $"{document.id}.bin";
						Console.WriteLine("Downloading " + filename);
						using var fileStream = File.Create(filename);
						await client.DownloadFileAsync(document, fileStream);
						Console.WriteLine("Download finished");
					}
					else if (message.media is MessageMediaPhoto { photo: Photo photo })
					{
						var filename = $"{photo.id}.jpg";
						Console.WriteLine("Downloading " + filename);
						using var fileStream = File.Create(filename);
						var type = await client.DownloadFileAsync(photo, fileStream);
						fileStream.Close(); // necessary for the renaming
						Console.WriteLine("Download finished");
						if (type is not Storage_FileType.unknown and not Storage_FileType.partial)
							File.Move(filename, $"{photo.id}.{type}", true); // rename extension
					}
				}
			}
		}
	}
}
