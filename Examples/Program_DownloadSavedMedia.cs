using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TL;

namespace WTelegramClientTest
{
	static class Program_DownloadSavedMedia
	{
		// go to Project Properties > Debug > Launch Profiles > Environment variables and add at least these: api_id, api_hash, phone_number
		static async Task Main(string[] _)
		{
			Console.WriteLine("The program will download photos/medias from messages you send/forward to yourself (Saved Messages)");
			var cts = new CancellationTokenSource();
			await using var client = new WTelegram.Client(Environment.GetEnvironmentVariable);
			var user = await client.LoginUserIfNeeded();
			client.OnUpdates += Client_OnUpdates;
			Console.ReadKey();
			cts.Cancel();

			async Task Client_OnUpdates(UpdatesBase updates)
			{
				foreach (var update in updates.UpdateList)
				{
					if (update is not UpdateNewMessage { message: Message message })
						continue; // if it's not about a new message, ignore the update
					if (message.peer_id.ID != user.ID)
						continue; // if it's not in the "Saved messages" chat, ignore it

					if (message.media is MessageMediaDocument { document: Document document })
					{
						var filename = document.Filename; // use document original filename, or build a name from document ID & MIME type:
						filename ??= $"{document.id}.{document.mime_type[(document.mime_type.IndexOf('/') + 1)..]}";
						Console.WriteLine("Downloading " + filename);
						using var fileStream = File.Create(filename);
						await client.DownloadFileAsync(document, fileStream, progress: (p, t) => cts.Token.ThrowIfCancellationRequested());
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
