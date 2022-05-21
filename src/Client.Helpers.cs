using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using TL;

// necessary for .NET Standard 2.0 compilation:
#pragma warning disable CA1835 // Prefer the 'Memory'-based overloads for 'ReadAsync' and 'WriteAsync'

namespace WTelegram
{
	partial class Client
	{
		#region Collect Access Hash system
		/// <summary>Enable the collection of id/access_hash pairs (experimental)</summary>
		public bool CollectAccessHash { get; set; }
		readonly Dictionary<Type, Dictionary<long, long>> _accessHashes = new();
		public IEnumerable<KeyValuePair<long, long>> AllAccessHashesFor<T>() where T : IObject
			=> _accessHashes.GetValueOrDefault(typeof(T));
		/// <summary>Retrieve the access_hash associated with this id (for a TL class) if it was collected</summary>
		/// <remarks>This requires <see cref="CollectAccessHash"/> to be set to <see langword="true"/> first.
		/// <br/>See <see href="https://github.com/wiz0u/WTelegramClient/tree/master/Examples/Program_CollectAccessHash.cs">Examples/Program_CollectAccessHash.cs</see> for how to use this</remarks>
		/// <typeparam name="T">a TL object class. For example User, Channel or Photo</typeparam>
		public long GetAccessHashFor<T>(long id) where T : IObject
		{
			lock (_accessHashes)
				return _accessHashes.GetOrCreate(typeof(T)).TryGetValue(id, out var access_hash) ? access_hash : 0;
		}
		public void SetAccessHashFor<T>(long id, long access_hash) where T : IObject
		{
			lock (_accessHashes)
				_accessHashes.GetOrCreate(typeof(T))[id] = access_hash;
		}
		static readonly FieldInfo userFlagsField = typeof(User).GetField("flags");
		static readonly FieldInfo channelFlagsField = typeof(Channel).GetField("flags");
		internal void CollectField(FieldInfo fieldInfo, object obj, object access_hash)
		{
			if (fieldInfo.Name != "access_hash") return;
			if (access_hash is not long accessHash) return;
			var type = fieldInfo.ReflectedType;
			if ((type == typeof(User) && ((User.Flags)userFlagsField.GetValue(obj)).HasFlag(User.Flags.min)) ||
				(type == typeof(Channel) && ((Channel.Flags)channelFlagsField.GetValue(obj)).HasFlag(Channel.Flags.min)))
				return; // access_hash from Min constructors are mostly useless. see https://core.telegram.org/api/min
			if (type.GetField("id") is not FieldInfo idField) return;
			if (idField.GetValue(obj) is not long id)
				if (idField.GetValue(obj) is not int idInt) return;
				else id = idInt;
			lock (_accessHashes)
				_accessHashes.GetOrCreate(type)[id] = accessHash;
		}
		#endregion

		#region Client TL Helpers
		/// <summary>Helper function to upload a file to Telegram</summary>
		/// <param name="pathname">Path to the file to upload</param>
		/// <param name="progress">(optional) Callback for tracking the progression of the transfer</param>
		/// <returns>an <see cref="InputFile"/> or <see cref="InputFileBig"/> than can be used in various requests</returns>
		public Task<InputFileBase> UploadFileAsync(string pathname, ProgressCallback progress = null)
			=> UploadFileAsync(File.OpenRead(pathname), Path.GetFileName(pathname), progress);

		/// <summary>Helper function to upload a file to Telegram</summary>
		/// <param name="stream">Content of the file to upload. This method close/dispose the stream</param>
		/// <param name="filename">Name of the file</param>
		/// <param name="progress">(optional) Callback for tracking the progression of the transfer</param>
		/// <returns>an <see cref="InputFile"/> or <see cref="InputFileBig"/> than can be used in various requests</returns>
		public async Task<InputFileBase> UploadFileAsync(Stream stream, string filename, ProgressCallback progress = null)
		{
			using var md5 = MD5.Create();
			using (stream)
			{
				long transmitted = 0, length = stream.Length;
				var isBig = length >= 10 * 1024 * 1024;
				int file_total_parts = (int)((length - 1) / FilePartSize) + 1;
				long file_id = Helpers.RandomLong();
				int file_part = 0, read;
				var tasks = new Dictionary<int, Task>();
				bool abort = false;
				for (long bytesLeft = length; !abort && bytesLeft != 0; file_part++)
				{
					var bytes = new byte[Math.Min(FilePartSize, bytesLeft)];
					read = await stream.FullReadAsync(bytes, bytes.Length, default);
					await _parallelTransfers.WaitAsync();
					bytesLeft -= read;
					var task = SavePart(file_part, bytes);
					lock (tasks) tasks[file_part] = task;
					if (!isBig)
						md5.TransformBlock(bytes, 0, read, null, 0);
					if (read < FilePartSize && bytesLeft != 0) throw new ApplicationException($"Failed to fully read stream ({read},{bytesLeft})");

					async Task SavePart(int file_part, byte[] bytes)
					{
						try
						{
							if (isBig)
								await this.Upload_SaveBigFilePart(file_id, file_part, file_total_parts, bytes);
							else
								await this.Upload_SaveFilePart(file_id, file_part, bytes);
							lock (tasks) { transmitted += bytes.Length; tasks.Remove(file_part); }
							progress?.Invoke(transmitted, length);
						}
						catch (Exception)
						{
							abort = true;
							throw;
						}
						finally
						{
							_parallelTransfers.Release();
						}
					}
				}
				Task[] remainingTasks;
				lock (tasks) remainingTasks = tasks.Values.ToArray();
				await Task.WhenAll(remainingTasks); // wait completion and eventually propagate any task exception
				if (!isBig) md5.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
				return isBig ? new InputFileBig { id = file_id, parts = file_total_parts, name = filename }
					: new InputFile { id = file_id, parts = file_total_parts, name = filename, md5_checksum = md5.Hash };
			}
		}

		/// <summary>Search messages with <see href="https://corefork.telegram.org/type/MessagesFilter">filter</see> and text		<para>See <a href="https://corefork.telegram.org/method/messages.search"/></para></summary>
		/// <typeparam name="T">See <see cref="MessagesFilter"/> for a list of possible filter types</typeparam>
		/// <param name="peer">User or chat, histories with which are searched, or <see langword="null"/> constructor for global search</param>
		/// <param name="text">Text search request</param>
		/// <param name="offset_id">Only return messages starting from the specified message ID</param>
		/// <param name="limit"><a href="https://corefork.telegram.org/api/offsets">Number of results to return</a></param>
		public Task<Messages_MessagesBase> Messages_Search<T>(InputPeer peer, string text = null, int offset_id = 0, int limit = int.MaxValue) where T : MessagesFilter, new()
			=> this.Messages_Search(peer, text, new T(), offset_id: offset_id, limit: limit);

		/// <summary>Helper function to send a media message more easily</summary>
		/// <param name="peer">Destination of message (chat group, channel, user chat, etc..) </param>
		/// <param name="caption">Caption for the media <i>(in plain text)</i> or <see langword="null"/></param>
		/// <param name="mediaFile">Media file already uploaded to TG <i>(see <see cref="UploadFileAsync">UploadFileAsync</see>)</i></param>
		/// <param name="mimeType"><see langword="null"/> for automatic detection, <c>"photo"</c> for an inline photo, or a MIME type to send as a document</param>
		/// <param name="reply_to_msg_id">Your message is a reply to an existing message with this ID, in the same chat</param>
		/// <param name="entities">Text formatting entities for the caption. You can use <see cref="Markdown.MarkdownToEntities">MarkdownToEntities</see> to create these</param>
		/// <param name="schedule_date">UTC timestamp when the message should be sent</param>
		/// <returns>The transmitted message confirmed by Telegram</returns>
		public Task<Message> SendMediaAsync(InputPeer peer, string caption, InputFileBase mediaFile, string mimeType = null, int reply_to_msg_id = 0, MessageEntity[] entities = null, DateTime schedule_date = default)
		{
			mimeType ??= Path.GetExtension(mediaFile.Name)?.ToLowerInvariant() switch
			{
				".jpg" or ".jpeg" or ".png" or ".bmp" => "photo",
				".gif" => "image/gif",
				".webp" => "image/webp",
				".mp4" => "video/mp4",
				".mp3" => "audio/mpeg",
				".wav" => "audio/x-wav",
				_ => "", // send as generic document with undefined MIME type
			};
			if (mimeType == "photo")
				return SendMessageAsync(peer, caption, new InputMediaUploadedPhoto { file = mediaFile }, reply_to_msg_id, entities, schedule_date);
			return SendMessageAsync(peer, caption, new InputMediaUploadedDocument(mediaFile, mimeType), reply_to_msg_id, entities, schedule_date);
		}

		/// <summary>Helper function to send a text or media message easily</summary>
		/// <param name="peer">Destination of message (chat group, channel, user chat, etc..) </param>
		/// <param name="text">The plain text of the message (or media caption)</param>
		/// <param name="media">An instance of <see cref="InputMedia">InputMedia</see>-derived class, or <see langword="null"/> if there is no associated media</param>
		/// <param name="reply_to_msg_id">Your message is a reply to an existing message with this ID, in the same chat</param>
		/// <param name="entities">Text formatting entities. You can use <see cref="Markdown.MarkdownToEntities">MarkdownToEntities</see> to create these</param>
		/// <param name="schedule_date">UTC timestamp when the message should be sent</param>
		/// <param name="disable_preview">Should website/media preview be shown or not, for URLs in your message</param>
		/// <returns>The transmitted message as confirmed by Telegram</returns>
		public async Task<Message> SendMessageAsync(InputPeer peer, string text, InputMedia media = null, int reply_to_msg_id = 0, MessageEntity[] entities = null, DateTime schedule_date = default, bool disable_preview = false)
		{
			UpdatesBase updates;
			long random_id = Helpers.RandomLong();
			if (media == null)
				updates = await this.Messages_SendMessage(peer, text, random_id, no_webpage: disable_preview, entities: entities,
					reply_to_msg_id: reply_to_msg_id == 0 ? null : reply_to_msg_id, schedule_date: schedule_date == default ? null : schedule_date);
			else
				updates = await this.Messages_SendMedia(peer, media, text, random_id, entities: entities,
					reply_to_msg_id: reply_to_msg_id == 0 ? null : reply_to_msg_id, schedule_date: schedule_date == default ? null : schedule_date);
			OnUpdate(updates);
			int msgId = -1;
			foreach (var update in updates.UpdateList)
			{
				switch (update)
				{
					case UpdateMessageID updMsgId when updMsgId.random_id == random_id: msgId = updMsgId.id; break;
					case UpdateNewMessage { message: Message message } when message.id == msgId: return message;
					case UpdateNewScheduledMessage { message: Message schedMsg } when schedMsg.id == msgId: return schedMsg;
				}
			}
			if (updates is UpdateShortSentMessage sent)
			{
				return new Message
				{
					flags = (Message.Flags)sent.flags | (reply_to_msg_id == 0 ? 0 : Message.Flags.has_reply_to) | (peer is InputPeerSelf ? 0 : Message.Flags.has_from_id),
					id = sent.id, date = sent.date, message = text, entities = sent.entities, media = sent.media, ttl_period = sent.ttl_period,
					reply_to = reply_to_msg_id == 0 ? null : new MessageReplyHeader { reply_to_msg_id = reply_to_msg_id },
					from_id = peer is InputPeerSelf ? null : new PeerUser { user_id = _session.UserId },
					peer_id = InputToPeer(peer)
				};
			}
			return null;
		}

		/// <summary>Helper function to send an album (media group) of photos or documents more easily</summary>
		/// <param name="peer">Destination of message (chat group, channel, user chat, etc..) </param>
		/// <param name="medias">An array of <see cref="InputMedia">InputMedia</see>-derived class</param>
		/// <param name="caption">Caption for the media <i>(in plain text)</i> or <see langword="null"/></param>
		/// <param name="reply_to_msg_id">Your message is a reply to an existing message with this ID, in the same chat</param>
		/// <param name="entities">Text formatting entities for the caption. You can use <see cref="Markdown.MarkdownToEntities">MarkdownToEntities</see> to create these</param>
		/// <param name="schedule_date">UTC timestamp when the message should be sent</param>
		/// <returns>The last of the media group messages, confirmed by Telegram</returns>
		/// <remarks>
		/// * The caption/entities are set on the last media<br/>
		/// * <see cref="InputMediaDocumentExternal"/> and <see cref="InputMediaPhotoExternal"/> are supported by downloading the file from the web via HttpClient and sending it to Telegram.
		///   WTelegramClient proxy settings don't apply to HttpClient<br/>
		/// * You may run into errors if you mix, in the same album, photos and file documents having no thumbnails/video attributes
		/// </remarks>
		public async Task<Message> SendAlbumAsync(InputPeer peer, InputMedia[] medias, string caption = null, int reply_to_msg_id = 0, MessageEntity[] entities = null, DateTime schedule_date = default)
		{
			System.Net.Http.HttpClient httpClient = null;
			var multiMedia = new InputSingleMedia[medias.Length];
			for (int i = 0; i < medias.Length; i++)
			{
				var ism = multiMedia[i] = new InputSingleMedia { random_id = Helpers.RandomLong(), media = medias[i] };
			retry:
				switch (ism.media)
				{
					case InputMediaUploadedPhoto imup:
						var mmp = (MessageMediaPhoto)await this.Messages_UploadMedia(peer, imup);
						ism.media = mmp.photo;
						break;
					case InputMediaUploadedDocument imud:
						var mmd = (MessageMediaDocument)await this.Messages_UploadMedia(peer, imud);
						ism.media = mmd.document;
						break;
					case InputMediaDocumentExternal imde:
						string mimeType = null;
						var inputFile = await UploadFromUrl(imde.url);
						ism.media = new InputMediaUploadedDocument(inputFile, mimeType);
						goto retry;
					case InputMediaPhotoExternal impe:
						inputFile = await UploadFromUrl(impe.url);
						ism.media = new InputMediaUploadedPhoto { file = inputFile };
						goto retry;

						async Task<InputFileBase> UploadFromUrl(string url)
						{
							var filename = Path.GetFileName(new Uri(url).LocalPath);
							httpClient ??= new();
							var response = await httpClient.GetAsync(url);
							using var stream = await response.Content.ReadAsStreamAsync();
							mimeType = response.Content.Headers.ContentType?.MediaType;
							if (response.Content.Headers.ContentLength is long length)
								return await UploadFileAsync(new Helpers.IndirectStream(stream) { ContentLength = length }, filename);
							else
							{
								using var ms = new MemoryStream();
								await stream.CopyToAsync(ms);
								ms.Position = 0;
								return await UploadFileAsync(ms, filename);
							}
						}
				}
			}
			var lastMedia = multiMedia[^1];
			lastMedia.message = caption;
			lastMedia.entities = entities;
			if (entities != null) lastMedia.flags = InputSingleMedia.Flags.has_entities;

			var updates = await this.Messages_SendMultiMedia(peer, multiMedia, reply_to_msg_id: reply_to_msg_id, schedule_date: schedule_date);
			OnUpdate(updates);
			int msgId = -1;
			foreach (var update in updates.UpdateList)
			{
				switch (update)
				{
					case UpdateMessageID updMsgId when updMsgId.random_id == lastMedia.random_id: msgId = updMsgId.id; break;
					case UpdateNewMessage { message: Message message } when message.id == msgId: return message;
					case UpdateNewScheduledMessage { message: Message schedMsg } when schedMsg.id == msgId: return schedMsg;
				}
			}
			return null;
		}

		private Peer InputToPeer(InputPeer peer) => peer switch
		{
			InputPeerSelf => new PeerUser { user_id = _session.UserId },
			InputPeerUser ipu => new PeerUser { user_id = ipu.user_id },
			InputPeerChat ipc => new PeerChat { chat_id = ipc.chat_id },
			InputPeerChannel ipch => new PeerChannel { channel_id = ipch.channel_id },
			InputPeerUserFromMessage ipufm => new PeerUser { user_id = ipufm.user_id },
			InputPeerChannelFromMessage ipcfm => new PeerChannel { channel_id = ipcfm.channel_id },
			_ => null,
		};

		/// <summary>Download a photo from Telegram into the outputStream</summary>
		/// <param name="photo">The photo to download</param>
		/// <param name="outputStream">Stream to write the file content to. This method does not close/dispose the stream</param>
		/// <param name="photoSize">A specific size/version of the photo, or <see langword="null"/> to download the largest version of the photo</param>
		/// <param name="progress">(optional) Callback for tracking the progression of the transfer</param>
		/// <returns>The file type of the photo</returns>
		public async Task<Storage_FileType> DownloadFileAsync(Photo photo, Stream outputStream, PhotoSizeBase photoSize = null, ProgressCallback progress = null)
		{
			if (photoSize is PhotoStrippedSize psp)
				return InflateStrippedThumb(outputStream, psp.bytes) ? Storage_FileType.jpeg : 0;
			photoSize ??= photo.LargestPhotoSize;
			var fileLocation = photo.ToFileLocation(photoSize);
			return await DownloadFileAsync(fileLocation, outputStream, photo.dc_id, photoSize.FileSize, progress);
		}

		/// <summary>Download a document from Telegram into the outputStream</summary>
		/// <param name="document">The document to download</param>
		/// <param name="outputStream">Stream to write the file content to. This method does not close/dispose the stream</param>
		/// <param name="thumbSize">A specific size/version of the document thumbnail to download, or <see langword="null"/> to download the document itself</param>
		/// <param name="progress">(optional) Callback for tracking the progression of the transfer</param>
		/// <returns>MIME type of the document/thumbnail</returns>
		public async Task<string> DownloadFileAsync(Document document, Stream outputStream, PhotoSizeBase thumbSize = null, ProgressCallback progress = null)
		{
			if (thumbSize is PhotoStrippedSize psp)
				return InflateStrippedThumb(outputStream, psp.bytes) ? "image/jpeg" : null;
			var fileLocation = document.ToFileLocation(thumbSize);
			var fileType = await DownloadFileAsync(fileLocation, outputStream, document.dc_id, thumbSize?.FileSize ?? document.size, progress);
			return thumbSize == null ? document.mime_type : "image/" + fileType;
		}

		/// <summary>Download a file from Telegram into the outputStream</summary>
		/// <param name="fileLocation">Telegram file identifier, typically obtained with a .ToFileLocation() call</param>
		/// <param name="outputStream">Stream to write file content to. This method does not close/dispose the stream</param>
		/// <param name="dc_id">(optional) DC on which the file is stored</param>
		/// <param name="fileSize">(optional) Expected file size</param>
		/// <param name="progress">(optional) Callback for tracking the progression of the transfer</param>
		/// <returns>The file type</returns>
		public async Task<Storage_FileType> DownloadFileAsync(InputFileLocationBase fileLocation, Stream outputStream, int dc_id = 0, int fileSize = 0, ProgressCallback progress = null)
		{
			Storage_FileType fileType = Storage_FileType.unknown;
			var client = dc_id == 0 ? this : await GetClientForDC(dc_id, true);
			using var writeSem = new SemaphoreSlim(1);
			long streamStartPos = outputStream.Position;
			int fileOffset = 0, maxOffsetSeen = 0;
			long transmitted = 0;
			var tasks = new Dictionary<int, Task>();
			progress?.Invoke(0, fileSize);
			bool abort = false;
			while (!abort)
			{
				await _parallelTransfers.WaitAsync();
				var task = LoadPart(fileOffset);
				lock (tasks) tasks[fileOffset] = task;
				if (dc_id == 0) { await task; dc_id = client._dcSession.DcID; }
				fileOffset += FilePartSize;
				if (fileSize != 0 && fileOffset >= fileSize)
				{
					if (await task != ((fileSize - 1) % FilePartSize) + 1)
						throw new ApplicationException("Downloaded file size does not match expected file size");
					break;
				}

				async Task<int> LoadPart(int offset)
				{
					Upload_FileBase fileBase;
					try
					{
						fileBase = await client.Upload_GetFile(fileLocation, offset, FilePartSize);
					}
					catch (RpcException ex) when (ex.Code == 303 && ex.Message == "FILE_MIGRATE_X")
					{
						client = await GetClientForDC(ex.X, true);
						fileBase = await client.Upload_GetFile(fileLocation, offset, FilePartSize);
					}
					catch (RpcException ex) when (ex.Code == 400 && ex.Message == "OFFSET_INVALID")
					{
						abort = true;
						return 0;
					}
					catch (Exception)
					{
						abort = true;
						throw;
					}
					finally
					{
						_parallelTransfers.Release();
					}
					if (fileBase is not Upload_File fileData)
						throw new ApplicationException("Upload_GetFile returned unsupported " + fileBase?.GetType().Name);
					if (fileData.bytes.Length != FilePartSize) abort = true;
					if (fileData.bytes.Length != 0)
					{
						fileType = fileData.type;
						await writeSem.WaitAsync();
						try
						{
							if (streamStartPos + offset != outputStream.Position) // if we're about to write out of order
							{
								await outputStream.FlushAsync(); // async flush, otherwise Seek would do a sync flush
								outputStream.Seek(streamStartPos + offset, SeekOrigin.Begin);
							}
							await outputStream.WriteAsync(fileData.bytes, 0, fileData.bytes.Length);
							maxOffsetSeen = Math.Max(maxOffsetSeen, offset + fileData.bytes.Length);
							transmitted += fileData.bytes.Length;
						}
						catch (Exception)
						{
							abort = true;
							throw;
						}
						finally
						{
							writeSem.Release();
							progress?.Invoke(transmitted, fileSize);
						}
					}
					lock (tasks) tasks.Remove(offset);
					return fileData.bytes.Length;
				}
			}
			Task[] remainingTasks;
			lock (tasks) remainingTasks = tasks.Values.ToArray();
			await Task.WhenAll(remainingTasks); // wait completion and eventually propagate any task exception
			await outputStream.FlushAsync();
			outputStream.Seek(streamStartPos + maxOffsetSeen, SeekOrigin.Begin);
			return fileType;
		}

		/// <summary>Download the profile photo for a given peer into the outputStream</summary>
		/// <param name="peer">User, Chat or Channel</param>
		/// <param name="outputStream">Stream to write the file content to. This method does not close/dispose the stream</param>
		/// <param name="big">Whether to download the high-quality version of the picture</param>
		/// <param name="miniThumb">Whether to extract the embedded very low-res thumbnail (synchronous, no actual download needed)</param>
		/// <returns>The file type of the photo, or 0 if no photo available</returns>
		public async Task<Storage_FileType> DownloadProfilePhotoAsync(IPeerInfo peer, Stream outputStream, bool big = false, bool miniThumb = false)
		{
			int dc_id;
			long photo_id;
			byte[] stripped_thumb;
			switch (peer)
			{
				case User user:
					if (user.photo == null) return 0;
					dc_id = user.photo.dc_id;
					photo_id = user.photo.photo_id;
					stripped_thumb = user.photo.stripped_thumb;
					break;
				case ChatBase { Photo: var photo }:
					if (photo == null) return 0;
					dc_id = photo.dc_id;
					photo_id = photo.photo_id;
					stripped_thumb = photo.stripped_thumb;
					break;
				default:
					return 0;
			}
			if (miniThumb && !big)
				return InflateStrippedThumb(outputStream, stripped_thumb) ? Storage_FileType.jpeg : 0;
			var fileLocation = new InputPeerPhotoFileLocation { peer = peer.ToInputPeer(), photo_id = photo_id };
			if (big) fileLocation.flags |= InputPeerPhotoFileLocation.Flags.big;
			return await DownloadFileAsync(fileLocation, outputStream, dc_id);
		}

		private static bool InflateStrippedThumb(Stream outputStream, byte[] stripped_thumb)
		{
			if (stripped_thumb == null || stripped_thumb.Length <= 3 || stripped_thumb[0] != 1)
				return false;
			var header = Helpers.StrippedThumbJPG;
			outputStream.Write(header, 0, 164);
			outputStream.WriteByte(stripped_thumb[1]);
			outputStream.WriteByte(0);
			outputStream.WriteByte(stripped_thumb[2]);
			outputStream.Write(header, 167, header.Length - 167);
			outputStream.Write(stripped_thumb, 3, stripped_thumb.Length - 3);
			outputStream.WriteByte(0xff);
			outputStream.WriteByte(0xd9);
			return true;
		}

		/// <summary>Returns the current user dialog list.		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/messages.getDialogs#possible-errors">details</a>)</para></summary>
		/// <param name="folder_id"><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></param>
		/// <returns>See <a href="https://corefork.telegram.org/constructor/messages.dialogs"/></returns>
		public async Task<Messages_Dialogs> Messages_GetAllDialogs(int? folder_id = null)
		{
			var dialogs = await this.Messages_GetDialogs(folder_id: folder_id);
			switch (dialogs)
			{
				case Messages_DialogsSlice mds:
					var dialogList = new List<DialogBase>();
					var messageList = new List<MessageBase>();
					while (dialogs.Dialogs.Length != 0)
					{
						dialogList.AddRange(dialogs.Dialogs);
						messageList.AddRange(dialogs.Messages);
						var lastDialog = dialogs.Dialogs[^1];
						var lastMsg = dialogs.Messages.LastOrDefault(m => m.Peer.ID == lastDialog.Peer.ID && m.ID == lastDialog.TopMessage);
						var offsetPeer = dialogs.UserOrChat(lastDialog).ToInputPeer();
						dialogs = await this.Messages_GetDialogs(lastMsg?.Date ?? default, lastDialog.TopMessage, offsetPeer, folder_id: folder_id);
						if (dialogs is not Messages_Dialogs md) break;
						foreach (var (key, value) in md.chats) mds.chats[key] = value;
						foreach (var (key, value) in md.users) mds.users[key] = value;
					}
					mds.dialogs = dialogList.ToArray();
					mds.messages = messageList.ToArray();
					return mds;
				case Messages_Dialogs md: return md;
				default: throw new ApplicationException("Messages_GetDialogs returned unexpected " + dialogs?.GetType().Name);
			}
		}

		/// <summary>Helper method that tries to fetch all participants from a Channel (beyond Telegram server-side limitations)</summary>
		/// <param name="channel">The channel to query</param>
		/// <param name="includeKickBan">Also fetch the kicked/banned members?</param>
		/// <param name="alphabet1">first letters used to search for in participants names<br/>(default values crafted with ♥ to find most latin and cyrillic names)</param>
		/// <param name="alphabet2">second (and further) letters used to search for in participants names</param>
		/// <param name="cancellationToken">Can be used to abort the work of this method</param>
		/// <returns>Field count indicates the total count of members. Field participants contains those that were successfully fetched</returns>
		/// <remarks>⚠ This method can take a few minutes to complete on big broadcast channels. It likely won't be able to obtain the full total count of members</remarks>
		public async Task<Channels_ChannelParticipants> Channels_GetAllParticipants(InputChannelBase channel, bool includeKickBan = false, string alphabet1 = "АБCДЕЄЖФГHИІJКЛМНОПQРСТУВWХЦЧШЩЫЮЯЗ", string alphabet2 = "АCЕHИJЛМНОРСТУВWЫ", CancellationToken cancellationToken = default)
		{
			alphabet2 ??= alphabet1;
			var result = new Channels_ChannelParticipants { chats = new(), users = new() };
			var user_ids = new HashSet<long>();
			var participants = new List<ChannelParticipantBase>();

			var mcf = await this.Channels_GetFullChannel(channel);
			result.count = mcf.full_chat.ParticipantsCount;
			if (result.count > 2000 && ((Channel)mcf.chats[channel.ChannelId]).IsChannel)
				Helpers.Log(2, "Fetching all participants on a big channel can take several minutes...");
			await GetWithFilter(new ChannelParticipantsAdmins());
			await GetWithFilter(new ChannelParticipantsBots());
			await GetWithFilter(new ChannelParticipantsSearch { q = "" }, (f, c) => new ChannelParticipantsSearch { q = f.q + c }, alphabet1);
			if (includeKickBan)
			{
				await GetWithFilter(new ChannelParticipantsKicked { q = "" }, (f, c) => new ChannelParticipantsKicked { q = f.q + c }, alphabet1);
				await GetWithFilter(new ChannelParticipantsBanned { q = "" }, (f, c) => new ChannelParticipantsBanned { q = f.q + c }, alphabet1);
			}
			result.participants = participants.ToArray();
			return result;

			async Task GetWithFilter<T>(T filter, Func<T, char, T> recurse = null, string alphabet = null) where T : ChannelParticipantsFilter
			{
				Channels_ChannelParticipants ccp;
				int maxCount = 0;
				for (int offset = 0; ;)
				{
					cancellationToken.ThrowIfCancellationRequested();
					ccp = await this.Channels_GetParticipants(channel, filter, offset, 1024, 0);
					if (ccp.count > maxCount) maxCount = ccp.count;
					foreach (var kvp in ccp.chats) result.chats[kvp.Key] = kvp.Value;
					foreach (var kvp in ccp.users) result.users[kvp.Key] = kvp.Value;
					lock (participants)
						foreach (var participant in ccp.participants)
							if (user_ids.Add(participant.UserID))
								participants.Add(participant);
					offset += ccp.participants.Length;
					if (offset >= ccp.count || ccp.participants.Length == 0) break;
				}
				Helpers.Log(0, $"GetParticipants({(filter as ChannelParticipantsSearch)?.q}) returned {ccp.count}/{maxCount}.\tAccumulated count: {participants.Count}");
				if (recurse != null && (ccp.count < maxCount - 100 || ccp.count == 200 || ccp.count == 1000))
					foreach (var c in alphabet)
						await GetWithFilter(recurse(filter, c), recurse, c == 'А' ? alphabet : alphabet2);
			}
		}

		public Task<UpdatesBase> AddChatUser(InputPeer peer, InputUserBase user, int fwd_limit = int.MaxValue) => peer switch
		{
			InputPeerChat chat => this.Messages_AddChatUser(chat.chat_id, user, fwd_limit),
			InputPeerChannel channel => this.Channels_InviteToChannel(channel, new[] { user }),
			_ => throw new ArgumentException("This method works on Chat & Channel only"),
		};

		public Task<UpdatesBase> DeleteChatUser(InputPeer peer, InputUser user, bool revoke_history = true) => peer switch
		{
			InputPeerChat chat => this.Messages_DeleteChatUser(chat.chat_id, user, revoke_history),
			InputPeerChannel channel => this.Channels_EditBanned(channel, user, new ChatBannedRights { flags = ChatBannedRights.Flags.view_messages }),
			_ => throw new ArgumentException("This method works on Chat & Channel only"),
		};

		public Task<UpdatesBase> LeaveChat(InputPeer peer, bool revoke_history = true) => peer switch
		{
			InputPeerChat chat => this.Messages_DeleteChatUser(chat.chat_id, InputUser.Self, revoke_history),
			InputPeerChannel channel => this.Channels_LeaveChannel(channel),
			_ => throw new ArgumentException("This method works on Chat & Channel only"),
		};

		public async Task<UpdatesBase> EditChatAdmin(InputPeer peer, InputUserBase user, bool is_admin)
		{
			switch (peer)
			{
				case InputPeerChat chat:
					await this.Messages_EditChatAdmin(chat.chat_id, user, is_admin);
					return new Updates { date = DateTime.UtcNow, users = new(), updates = Array.Empty<Update>(),
						chats = (await this.Messages_GetChats(new[] { chat.chat_id })).chats };
				case InputPeerChannel channel:
					return await this.Channels_EditAdmin(channel, user,
						new ChatAdminRights { flags = is_admin ? (ChatAdminRights.Flags)0x8BF : 0 }, null);
				default:
					throw new ArgumentException("This method works on Chat & Channel only");
			}
		}

		public Task<UpdatesBase> EditChatPhoto(InputPeer peer, InputChatPhotoBase photo) => peer switch
		{
			InputPeerChat chat => this.Messages_EditChatPhoto(chat.chat_id, photo),
			InputPeerChannel channel => this.Channels_EditPhoto(channel, photo),
			_ => throw new ArgumentException("This method works on Chat & Channel only"),
		};

		public Task<UpdatesBase> EditChatTitle(InputPeer peer, string title) => peer switch
		{
			InputPeerChat chat => this.Messages_EditChatTitle(chat.chat_id, title),
			InputPeerChannel channel => this.Channels_EditTitle(channel, title),
			_ => throw new ArgumentException("This method works on Chat & Channel only"),
		};

		public Task<Messages_ChatFull> GetFullChat(InputPeer peer) => peer switch
		{
			InputPeerChat chat => this.Messages_GetFullChat(chat.chat_id),
			InputPeerChannel channel => this.Channels_GetFullChannel(channel),
			_ => throw new ArgumentException("This method works on Chat & Channel only"),
		};

		public async Task<UpdatesBase> DeleteChat(InputPeer peer)
		{
			switch (peer)
			{
				case InputPeerChat chat:
					await this.Messages_DeleteChat(chat.chat_id);
					return new Updates { date = DateTime.UtcNow, users = new(), updates = Array.Empty<Update>(),
						chats = (await this.Messages_GetChats(new[] { chat.chat_id })).chats };
				case InputPeerChannel channel:
					return await this.Channels_DeleteChannel(channel);
				default:
					throw new ArgumentException("This method works on Chat & Channel only");
			}
		}

		public async Task<Messages_MessagesBase> GetMessages(InputPeer peer, params InputMessage[] id)
		{
			if (peer is InputPeerChannel channel)
				return await this.Channels_GetMessages(channel, id);
			else
				return await this.Messages_GetMessages(id);
		}

		public async Task<Messages_AffectedMessages> DeleteMessages(InputPeer peer, params int[] id)
		{
			if (peer is InputPeerChannel channel)
				return await this.Channels_DeleteMessages(channel, id);
			else
				return await this.Messages_DeleteMessages(id);
		}
		#endregion
	}
}
