using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TL;

// necessary for .NET Standard 2.0 compilation:
#pragma warning disable CA1835 // Prefer the 'Memory'-based overloads for 'ReadAsync' and 'WriteAsync'

namespace WTelegram
{
	partial class Client
	{
		/// <summary>Used to indicate progression of file download/upload</summary>
		/// <param name="transmitted">transmitted bytes</param>
		/// <param name="totalSize">total size of file in bytes, or 0 if unknown</param>
		public delegate void ProgressCallback(long transmitted, long totalSize);

		/// <summary>Helper method to upload a file to Telegram</summary>
		/// <param name="pathname">Path to the file to upload</param>
		/// <param name="progress">(optional) Callback for tracking the progression of the transfer</param>
		/// <returns>an <see cref="InputFile"/> or <see cref="InputFileBig"/> than can be used in various requests</returns>
		public Task<InputFileBase> UploadFileAsync(string pathname, ProgressCallback progress = null)
			=> UploadFileAsync(File.OpenRead(pathname), Path.GetFileName(pathname), progress);

		/// <summary>Helper method to upload a file to Telegram</summary>
		/// <param name="stream">Content of the file to upload. This method close/dispose the stream</param>
		/// <param name="filename">Name of the file</param>
		/// <param name="progress">(optional) Callback for tracking the progression of the transfer</param>
		/// <returns>an <see cref="InputFile"/> or <see cref="InputFileBig"/> than can be used in various requests</returns>
		public async Task<InputFileBase> UploadFileAsync(Stream stream, string filename, ProgressCallback progress = null)
		{
			var client = await GetClientForDC(-_dcSession.DcID, true);
			using (stream)
			{
				const long SMALL_FILE_MAX_SIZE = 10 << 20;
				bool hasLength = stream.CanSeek;
				long transmitted = 0, length = hasLength ? stream.Length : -1;
				bool isBig = !hasLength || length > SMALL_FILE_MAX_SIZE;
				int file_total_parts = hasLength ? (int)((length - 1) / FilePartSize) + 1 : -1;
				long file_id = Helpers.RandomLong();
				int file_part = 0, read;
				var tasks = new Dictionary<int, Task>();
				bool abort = false;
				for (long bytesLeft = hasLength ? length : long.MaxValue; !abort && bytesLeft != 0; file_part++)
				{
					var bytes = new byte[Math.Min(FilePartSize, bytesLeft)];
					read = await stream.FullReadAsync(bytes, bytes.Length, default);
					await _parallelTransfers.WaitAsync();
					bytesLeft -= read;
					if (!hasLength && read < bytes.Length)
					{
						file_total_parts = file_part;
						if (read == 0) break; else file_total_parts++;
						bytes = bytes[..read]; 
						bytesLeft = 0; 
					}
					var task = SavePart(file_part, bytes);
					lock (tasks) tasks[file_part] = task;
					if (read < FilePartSize && bytesLeft != 0) throw new WTException($"Failed to fully read stream ({read},{bytesLeft})");

					async Task SavePart(int file_part, byte[] bytes)
					{
						try
						{
							if (isBig)
								await client.Upload_SaveBigFilePart(file_id, file_part, file_total_parts, bytes);
							else
								await client.Upload_SaveFilePart(file_id, file_part, bytes);
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
				lock (tasks) remainingTasks = [.. tasks.Values];
				await Task.WhenAll(remainingTasks); // wait completion and eventually propagate any task exception
				return isBig ? new InputFileBig { id = file_id, parts = file_total_parts, name = filename }
					: new InputFile { id = file_id, parts = file_total_parts, name = filename };
			}
		}

		/// <summary>Search messages in chat with <see href="https://corefork.telegram.org/type/MessagesFilter">filter</see> and text		<para>See <a href="https://corefork.telegram.org/method/messages.search"/></para></summary>
		/// <typeparam name="T">See <see cref="MessagesFilter"/> for a list of possible filter types</typeparam>
		/// <param name="peer">User or chat, histories with which are searched, or <see langword="null"/> constructor for global search</param>
		/// <param name="q">Text search request</param>
		/// <param name="offset_id">Only return messages starting from the specified message ID</param>
		/// <param name="limit"><a href="https://corefork.telegram.org/api/offsets">Number of results to return</a></param>
		public Task<Messages_MessagesBase> Messages_Search<T>(InputPeer peer, string q = null, int offset_id = 0, int limit = int.MaxValue) where T : MessagesFilter, new()
			=> this.Messages_Search(peer, q, new T(), offset_id: offset_id, limit: limit);

		/// <summary>Search messages globally with <see href="https://corefork.telegram.org/type/MessagesFilter">filter</see> and text		<para>See <a href="https://corefork.telegram.org/method/messages.searchGlobal"/></para></summary>
		/// <typeparam name="T">See <see cref="MessagesFilter"/> for a list of possible filter types</typeparam>
		/// <param name="q">Query</param>
		/// <param name="offset_id">Only return messages starting from the specified message ID</param>
		/// <param name="limit"><a href="https://corefork.telegram.org/api/offsets">Number of results to return</a></param>
		public Task<Messages_MessagesBase> Messages_SearchGlobal<T>(string q = null, int offset_id = 0, int limit = int.MaxValue) where T : MessagesFilter, new()
			=> this.Messages_SearchGlobal(q, new T(), offset_id: offset_id, limit: limit);

		/// <summary>Helper method to send a media message more easily</summary>
		/// <param name="peer">Destination of message (chat group, channel, user chat, etc..) </param>
		/// <param name="caption">Caption for the media <i>(in plain text)</i> or <see langword="null"/></param>
		/// <param name="uploadedFile">Media file already uploaded to TG <i>(see <see cref="UploadFileAsync">UploadFileAsync</see>)</i></param>
		/// <param name="mimeType"><see langword="null"/> for automatic detection, <c>"photo"</c> for an inline photo, <c>"video"</c> for a streamable MP4 video, or a MIME type to send as a document</param>
		/// <param name="reply_to_msg_id">Your message is a reply to an existing message with this ID, in the same chat</param>
		/// <param name="entities">Text formatting entities for the caption. You can use <see cref="Markdown.MarkdownToEntities">MarkdownToEntities</see> to create these</param>
		/// <param name="schedule_date">UTC timestamp when the message should be sent</param>
		/// <returns>The transmitted message confirmed by Telegram</returns>
		public Task<Message> SendMediaAsync(InputPeer peer, string caption, InputFileBase uploadedFile, string mimeType = null, int reply_to_msg_id = 0, MessageEntity[] entities = null, DateTime schedule_date = default)
		{
			mimeType ??= Path.GetExtension(uploadedFile.Name)?.ToLowerInvariant() switch
			{
				".jpg" or ".jpeg" or ".png" or ".bmp" => "photo",
				".mp4" => "video",
				".gif" => "image/gif",
				".webp" => "image/webp",
				".mp3" => "audio/mpeg",
				".wav" => "audio/x-wav",
				_ => "", // send as generic document with undefined MIME type
			};
			if (mimeType == "photo")
				return SendMessageAsync(peer, caption, new InputMediaUploadedPhoto { file = uploadedFile }, reply_to_msg_id, entities, schedule_date);
			else if (mimeType == "video")
				return SendMessageAsync(peer, caption, new InputMediaUploadedDocument(uploadedFile, "video/mp4", new DocumentAttributeVideo { flags = DocumentAttributeVideo.Flags.supports_streaming }), reply_to_msg_id, entities, schedule_date);
			else
				return SendMessageAsync(peer, caption, new InputMediaUploadedDocument(uploadedFile, mimeType), reply_to_msg_id, entities, schedule_date);
		}

		public enum LinkPreview { Disabled = 0, BelowText = 1, AboveText = 2 };
		/// <summary>Helper method to send a text or media message easily</summary>
		/// <param name="peer">Destination of message (chat group, channel, user chat, etc..) </param>
		/// <param name="text">The plain text of the message (or media caption)</param>
		/// <param name="media">An instance of <see cref="InputMedia">InputMedia</see>-derived class, or <see langword="null"/> if there is no associated media</param>
		/// <param name="reply_to_msg_id">Your message is a reply to an existing message with this ID, in the same chat</param>
		/// <param name="entities">Text formatting entities. You can use <see cref="HtmlText.HtmlToEntities">HtmlToEntities</see> or <see cref="Markdown.MarkdownToEntities">MarkdownToEntities</see> to create these</param>
		/// <param name="schedule_date">UTC timestamp when the message should be sent</param>
		/// <param name="preview">Should website/media preview be shown below, above or not, for URL links in your message</param>
		/// <returns>The transmitted message as confirmed by Telegram</returns>
		public async Task<Message> SendMessageAsync(InputPeer peer, string text, InputMedia media = null, int reply_to_msg_id = 0, MessageEntity[] entities = null, DateTime schedule_date = default, LinkPreview preview = LinkPreview.BelowText)
		{
			UpdatesBase updates;
			long random_id = Helpers.RandomLong();
			if (media == null)
				updates = await this.Messages_SendMessage(peer, text, random_id, entities: entities,
					no_webpage: preview == LinkPreview.Disabled, invert_media: preview == LinkPreview.AboveText,
					reply_to: reply_to_msg_id == 0 ? null : new InputReplyToMessage { reply_to_msg_id = reply_to_msg_id }, schedule_date: schedule_date == default ? null : schedule_date);
			else
				updates = await this.Messages_SendMedia(peer, media, text, random_id, entities: entities,
					reply_to: reply_to_msg_id == 0 ? null : new InputReplyToMessage { reply_to_msg_id = reply_to_msg_id }, schedule_date: schedule_date == default ? null : schedule_date);
			if (updates is UpdateShortSentMessage sent)
				return new Message
				{
					flags = (Message.Flags)sent.flags | (reply_to_msg_id == 0 ? 0 : Message.Flags.has_reply_to) | (peer is InputPeerSelf ? 0 : Message.Flags.has_from_id),
					id = sent.id, date = sent.date, message = text, entities = sent.entities, media = sent.media, ttl_period = sent.ttl_period,
					reply_to = reply_to_msg_id == 0 ? null : new MessageReplyHeader { reply_to_msg_id = reply_to_msg_id, flags = MessageReplyHeader.Flags.has_reply_to_msg_id },
					from_id = peer is InputPeerSelf ? null : new PeerUser { user_id = _session.UserId },
					peer_id = InputToPeer(peer)
				};
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
			return null;
		}

		/// <summary>Helper method to send an album (media group) of photos or documents more easily</summary>
		/// <param name="peer">Destination of message (chat group, channel, user chat, etc..) </param>
		/// <param name="medias">An array or List of <see cref="InputMedia">InputMedia</see>-derived class</param>
		/// <param name="caption">Caption for the media <i>(in plain text)</i> or <see langword="null"/></param>
		/// <param name="reply_to_msg_id">Your message is a reply to an existing message with this ID, in the same chat</param>
		/// <param name="entities">Text formatting entities for the caption. You can use <see cref="Markdown.MarkdownToEntities">MarkdownToEntities</see> to create these</param>
		/// <param name="schedule_date">UTC timestamp when the message should be sent</param>
		/// <param name="videoUrlAsFile">Any <see cref="InputMediaDocumentExternal"/> URL pointing to a video should be considered as non-streamable</param>
		/// <returns>The media group messages, as received by Telegram</returns>
		/// <remarks>
		/// * The caption/entities are set on the first media<br/>
		/// * <see cref="InputMediaDocumentExternal"/> and <see cref="InputMediaPhotoExternal"/> are supported natively for bot accounts, and for user accounts by downloading the file from the web via HttpClient and sending it to Telegram.
		///   WTelegramClient proxy settings don't apply to HttpClient<br/>
		/// * You may run into errors if you mix, in the same album, photos and file documents having no thumbnails/video attributes
		/// </remarks>
		public async Task<Message[]> SendAlbumAsync(InputPeer peer, ICollection<InputMedia> medias, string caption = null, int reply_to_msg_id = 0, MessageEntity[] entities = null, DateTime schedule_date = default, bool videoUrlAsFile = false)
		{
			System.Net.Http.HttpClient httpClient = null;
			int i = 0, length = medias.Count;
			var multiMedia = new InputSingleMedia[length];
			var random_id = Helpers.RandomLong();
			foreach (var media in medias)
			{
				var ism = multiMedia[i] = new InputSingleMedia { random_id = random_id + i, media = media };
				i++;
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
					case InputMediaPhotoExternal impe:
						if (User.IsBot)
							try
							{
								mmp = (MessageMediaPhoto)await this.Messages_UploadMedia(peer, impe);
								ism.media = mmp.photo;
								break;
							}
							catch (RpcException) { }
						var inputFile = await UploadFromUrl(impe.url);
						ism.media = new InputMediaUploadedPhoto { file = inputFile };
						goto retry;
					case InputMediaDocumentExternal imde:
						if (!videoUrlAsFile && User.IsBot)
							try
							{
								mmd = (MessageMediaDocument)await this.Messages_UploadMedia(peer, imde);
								ism.media = mmd.document;
								break;
							}
							catch (RpcException) { }
						string mimeType = null;
						inputFile = await UploadFromUrl(imde.url);
						if (videoUrlAsFile || mimeType?.StartsWith("video/") != true)
							ism.media = new InputMediaUploadedDocument(inputFile, mimeType);
						else
							ism.media = new InputMediaUploadedDocument(inputFile, mimeType, new DocumentAttributeVideo { flags = DocumentAttributeVideo.Flags.supports_streaming });
						goto retry;

						async Task<InputFileBase> UploadFromUrl(string url)
						{
							var filename = Path.GetFileName(new Uri(url).LocalPath);
							httpClient ??= new();
							using var response = await httpClient.GetAsync(url, System.Net.Http.HttpCompletionOption.ResponseHeadersRead);
							response.EnsureSuccessStatusCode();
							using var stream = await response.Content.ReadAsStreamAsync();
							mimeType = response.Content.Headers.ContentType?.MediaType;
							if (response.Content.Headers.ContentLength is long length)
								return await UploadFileAsync(new Helpers.IndirectStream(stream) { ContentLength = length }, filename);
							else
								return await UploadFileAsync(stream, filename);
						}
				}
			}
			var firstMedia = multiMedia[0];
			firstMedia.message = caption;
			firstMedia.entities = entities;
			if (entities != null) firstMedia.flags = InputSingleMedia.Flags.has_entities;

			var updates = await this.Messages_SendMultiMedia(peer, multiMedia, reply_to: reply_to_msg_id == 0 ? null : new InputReplyToMessage { reply_to_msg_id = reply_to_msg_id }, schedule_date: schedule_date);
			var msgIds = new int[length];
			var result = new Message[length];
			foreach (var update in updates.UpdateList)
			{
				switch (update)
				{
					case UpdateMessageID updMsgId: msgIds[updMsgId.random_id - random_id] = updMsgId.id; break;
					case UpdateNewMessage { message: Message message }: result[Array.IndexOf(msgIds, message.id)] = message; break;
					case UpdateNewScheduledMessage { message: Message schedMsg }: result[Array.IndexOf(msgIds, schedMsg.id)] = schedMsg; break;
				}
			}
			return result;
		}

		/// <summary>Helper method to forwards messages more easily by their IDs.</summary>
		/// <param name="drop_author">Whether to forward messages without quoting the original author</param>
		/// <param name="drop_media_captions">Whether to strip captions from media</param>
		/// <param name="from_peer">Source of messages</param>
		/// <param name="msg_ids">IDs of messages</param>
		/// <param name="to_peer">Destination peer</param>
		/// <param name="top_msg_id">Destination <a href="https://corefork.telegram.org/api/forum#forum-topics">forum topic</a></param>
		/// <returns>The resulting forwarded messages, as received by Telegram <para>Some of them might be <see langword="null"/> if they could not all be forwarded</para></returns>
		public async Task<Message[]> ForwardMessagesAsync(InputPeer from_peer, int[] msg_ids, InputPeer to_peer, int top_msg_id = 0, bool drop_author = false, bool drop_media_captions = false)
		{
			int msgCount = msg_ids.Length;
			var random_id = Helpers.RandomLong();
			var random_ids = Enumerable.Range(0, msgCount).Select(i => random_id + i).ToArray();
			var updates = await this.Messages_ForwardMessages(from_peer, msg_ids, random_ids, to_peer, top_msg_id == 0 ? null : top_msg_id, drop_author: drop_author, drop_media_captions: drop_media_captions);
			var msgIds = new int[msgCount];
			var result = new Message[msgCount];
			foreach (var update in updates.UpdateList)
			{
				switch (update)
				{
					case UpdateMessageID updMsgId: msgIds[updMsgId.random_id - random_id] = updMsgId.id; break;
					case UpdateNewMessage { message: Message message }: result[Array.IndexOf(msgIds, message.id)] = message; break;
					case UpdateNewScheduledMessage { message: Message schedMsg }: result[Array.IndexOf(msgIds, schedMsg.id)] = schedMsg; break;
				}
			}
			return result;
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

		/// <summary>Download an animated photo from Telegram into the outputStream</summary>
		/// <param name="photo">The photo to download</param>
		/// <param name="outputStream">Stream to write the file content to. This method does not close/dispose the stream</param>
		/// <param name="videoSize">A specific size/version of the animated photo. Use <c>photo.LargestVideoSize</c> to download the largest version of the animated photo</param>
		/// <param name="progress">(optional) Callback for tracking the progression of the transfer</param>
		/// <returns>The file type of the photo</returns>
		public async Task<Storage_FileType> DownloadFileAsync(Photo photo, Stream outputStream, VideoSize videoSize, ProgressCallback progress = null)
		{
			var fileLocation = photo.ToFileLocation(videoSize);
			return await DownloadFileAsync(fileLocation, outputStream, photo.dc_id, videoSize.size, progress);
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

		/// <summary>Download a document from Telegram into the outputStream</summary>
		/// <param name="document">The document to download</param>
		/// <param name="outputStream">Stream to write the file content to. This method does not close/dispose the stream</param>
		/// <param name="videoSize">A specific size/version of the animated photo. Use <c>photo.LargestVideoSize</c> to download the largest version of the animated photo</param>
		/// <param name="progress">(optional) Callback for tracking the progression of the transfer</param>
		/// <returns>MIME type of the document/thumbnail</returns>
		public async Task<Storage_FileType> DownloadFileAsync(Document document, Stream outputStream, VideoSize videoSize, ProgressCallback progress = null)
		{
			var fileLocation = document.ToFileLocation(videoSize);
			return await DownloadFileAsync(fileLocation, outputStream, document.dc_id, videoSize.size, progress);
		}

		/// <summary>Download a file from Telegram into the outputStream</summary>
		/// <param name="fileLocation">Telegram file identifier, typically obtained with a .ToFileLocation() call</param>
		/// <param name="outputStream">Stream to write file content to. This method does not close/dispose the stream</param>
		/// <param name="dc_id">(optional) DC on which the file is stored</param>
		/// <param name="fileSize">(optional) Expected file size</param>
		/// <param name="progress">(optional) Callback for tracking the progression of the transfer</param>
		/// <returns>The file type</returns>
		public async Task<Storage_FileType> DownloadFileAsync(InputFileLocationBase fileLocation, Stream outputStream, int dc_id = 0, long fileSize = 0, ProgressCallback progress = null)
		{
			Storage_FileType fileType = Storage_FileType.unknown;
			var client = dc_id == 0 ? this : await GetClientForDC(-dc_id, true);
			using var writeSem = new SemaphoreSlim(1);
			bool canSeek = outputStream.CanSeek;
			long streamStartPos = canSeek ? outputStream.Position : 0;
			long fileOffset = 0, maxOffsetSeen = 0;
			long transmitted = 0;
			var tasks = new Dictionary<long, Task>();
			progress?.Invoke(0, fileSize);
			bool abort = false;
			while (!abort)
			{
				await _parallelTransfers.WaitAsync();
				var task = LoadPart(fileOffset);
				lock (tasks) tasks[fileOffset] = task;
				if (dc_id == 0) { await task; dc_id = client._dcSession.DcID; }
				if (!canSeek) await task;
				fileOffset += FilePartSize;
				if (fileSize != 0 && fileOffset >= fileSize)
				{
					if (await task != ((fileSize - 1) % FilePartSize) + 1)
						throw new WTException("Downloaded file size does not match expected file size");
					break;
				}

				async Task<int> LoadPart(long offset)
				{
					Upload_FileBase fileBase;
					try
					{
						fileBase = await client.Upload_GetFile(fileLocation, offset, FilePartSize);
					}
					catch (RpcException ex) when (ex.Code == 303 && ex.Message == "FILE_MIGRATE_X")
					{
						client = await GetClientForDC(-ex.X, true);
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
						throw new WTException("Upload_GetFile returned unsupported " + fileBase?.GetType().Name);
					if (fileData.bytes.Length != FilePartSize) abort = true;
					if (fileData.bytes.Length != 0)
					{
						fileType = fileData.type;
						await writeSem.WaitAsync();
						try
						{
							if (canSeek && streamStartPos + offset != outputStream.Position) // if we're about to write out of order
							{
								await outputStream.FlushAsync(); // async flush, otherwise Seek would do a sync flush
								outputStream.Seek(streamStartPos + offset, SeekOrigin.Begin);
							}
							await outputStream.WriteAsync(fileData.bytes, 0, fileData.bytes.Length);
							maxOffsetSeen = Math.Max(maxOffsetSeen, offset + fileData.bytes.Length);
							transmitted += fileData.bytes.Length;
							progress?.Invoke(transmitted, fileSize);
						}
						catch (Exception)
						{
							abort = true;
							throw;
						}
						finally
						{
							writeSem.Release();
						}
					}
					lock (tasks) tasks.Remove(offset);
					return fileData.bytes.Length;
				}
			}
			Task[] remainingTasks;
			lock (tasks) remainingTasks = [.. tasks.Values];
			await Task.WhenAll(remainingTasks); // wait completion and eventually propagate any task exception
			await outputStream.FlushAsync();
			if (canSeek) outputStream.Seek(streamStartPos + maxOffsetSeen, SeekOrigin.Begin);
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

		/// <summary>Get all chats, channels and supergroups</summary>
		public async Task<Messages_Chats> Messages_GetAllChats()
		{
			var dialogs = await Messages_GetAllDialogs();
			var result = new Messages_Chats { chats = [] };
			foreach (var dialog in dialogs.dialogs)
				if (dialog.Peer is (PeerChat or PeerChannel) and { ID: var id })
					result.chats[id] = dialogs.chats[id];
			return result;
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
					int skip = 0;
					while (dialogs.Dialogs.Length > skip)
					{
						dialogList.AddRange(skip == 0 ? dialogs.Dialogs : dialogs.Dialogs[skip..]);
						messageList.AddRange(dialogs.Messages);
						skip = 0;
						int last = dialogs.Dialogs.Length - 1;
						var lastDialog = dialogs.Dialogs[last];
					retryDate:
						var lastPeer = dialogs.UserOrChat(lastDialog).ToInputPeer();
						var lastMsgId = lastDialog.TopMessage;
						var lastDate = dialogs.Messages.LastOrDefault(m => m.Peer.ID == lastDialog.Peer.ID && m.ID == lastDialog.TopMessage)?.Date ?? default;
						if (lastDate == default)
							if (--last < 0) break; else { ++skip; lastDialog = dialogs.Dialogs[last]; goto retryDate; }
						dialogs = await this.Messages_GetDialogs(lastDate, lastMsgId, lastPeer, folder_id: folder_id);
						if (dialogs is not Messages_Dialogs md) break;
						foreach (var (key, value) in md.chats) mds.chats[key] = value;
						foreach (var (key, value) in md.users) mds.users[key] = value;
					}
					mds.dialogs = [.. dialogList];
					mds.messages = [.. messageList];
					return mds;
				case Messages_Dialogs md: return md;
				default: throw new WTException("Messages_GetDialogs returned unexpected " + dialogs?.GetType().Name);
			}
		}

		/// <summary>Helper method that tries to fetch all participants from a Channel (beyond Telegram server-side limitations)</summary>
		/// <param name="channel">The channel to query</param>
		/// <param name="includeKickBan">Also fetch the kicked/banned members?</param>
		/// <param name="alphabet1">first letters used to search for in participants names<br/>(default values crafted with ♥ to find most latin and cyrillic names)</param>
		/// <param name="alphabet2">second (and further) letters used to search for in participants names</param>
		/// <param name="cancellationToken">Can be used to abort the work of this method</param>
		/// <returns>Field <c>count</c> indicates the total count of members. Field <c>participants</c> contains those that were successfully fetched</returns>
		/// <remarks>⚠ This method can take a few minutes to complete on big broadcast channels. It likely won't be able to obtain the full total count of members</remarks>
		public async Task<Channels_ChannelParticipants> Channels_GetAllParticipants(InputChannelBase channel, bool includeKickBan = false, string alphabet1 = "АБCДЕЄЖФГHИІJКЛМНОПQРСТУВWХЦЧШЩЫЮЯЗ", string alphabet2 = "АCЕHИJЛМНОРСТУВWЫ", CancellationToken cancellationToken = default)
		{
			alphabet2 ??= alphabet1;
			var result = new Channels_ChannelParticipants { chats = [], users = [] };
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
			result.participants = [.. participants];
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
							if (user_ids.Add(participant.UserId))
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

		/// <summary>Helper simplified method: Get the admin log of a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>		<para>See <a href="https://corefork.telegram.org/method/channels.getAdminLog"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403 (<a href="https://corefork.telegram.org/method/channels.getAdminLog#possible-errors">details</a>)</para></summary>
		/// <param name="channel">Channel</param>
		/// <param name="q">Search query, can be empty</param>
		/// <param name="events_filter">Event filter</param>
		/// <param name="admin">Only show events from this admin</param>
		public async Task<Channels_AdminLogResults> Channels_GetAdminLog(InputChannelBase channel, ChannelAdminLogEventsFilter.Flags events_filter = 0, string q = null, InputUserBase admin = null)
		{
			var admins = admin == null ? null : new[] { admin };
			var result = await this.Channels_GetAdminLog(channel, q, events_filter: events_filter, admins: admins);
			var resultFull = result;
			var events = new List<ChannelAdminLogEvent>(result.events);
			while (result.events.Length > 0)
			{
				result = await this.Channels_GetAdminLog(channel, q, max_id: result.events[^1].id, events_filter: events_filter, admins: admins);
				events.AddRange(result.events);
				foreach (var kvp in result.chats) resultFull.chats[kvp.Key] = kvp.Value;
				foreach (var kvp in result.users) resultFull.users[kvp.Key] = kvp.Value;
			}
			resultFull.events = [.. events];
			return resultFull;
		}

		/// <summary>Helper simplified method: Get all <a href="https://corefork.telegram.org/api/forum">topics of a forum</a>		<para>See <a href="https://corefork.telegram.org/method/channels.getForumTopics"/></para>		<para>Possible <see cref="RpcException"/> codes: 400 (<a href="https://corefork.telegram.org/method/channels.getForumTopics#possible-errors">details</a>)</para></summary>
		/// <param name="peer">Supergroup or Bot peer</param>
		/// <param name="q">Search query</param>
		public async Task<Messages_ForumTopics> Channels_GetAllForumTopics(InputPeer peer, string q = null)
		{
			var result = await this.Messages_GetForumTopics(peer, offset_date: DateTime.MaxValue, q: q);
			if (result.topics.Length < result.count)
			{
				var topics = result.topics.ToList();
				var messages = result.messages.ToList();
				while (true)
				{
					var more_topics = await this.Messages_GetForumTopics(peer, messages[^1].Date, messages[^1].ID, topics[^1].ID);
					if (more_topics.topics.Length == 0) break;
					topics.AddRange(more_topics.topics);
					messages.AddRange(more_topics.messages);
					foreach (var kvp in more_topics.chats) result.chats[kvp.Key] = kvp.Value;
					foreach (var kvp in more_topics.users) result.users[kvp.Key] = kvp.Value;
					if (topics.Count >= more_topics.count) break;
				}
				result.topics = [.. topics];
				result.messages = [.. messages];
			}
			return result;
		}

		private const string OnlyChatChannel = "This method works on Chat & Channel only";
		/// <summary>Generic helper: Adds a single user to a Chat or Channel		<para>See <a href="https://corefork.telegram.org/method/messages.addChatUser"/><br/> and <a href="https://corefork.telegram.org/method/channels.inviteToChannel"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403</para></summary>
		/// <param name="peer">Chat/Channel</param>
		/// <param name="user">User to be added</param>
		public Task<Messages_InvitedUsers> AddChatUser(InputPeer peer, InputUserBase user) => peer switch
		{
			InputPeerChat chat => this.Messages_AddChatUser(chat.chat_id, user, int.MaxValue),
			InputPeerChannel channel => this.Channels_InviteToChannel(channel, user),
			_ => throw new ArgumentException(OnlyChatChannel),
		};

		/// <summary>Generic helper: Kick a user from a Chat or Channel [bots: ✓]		<para>See <a href="https://corefork.telegram.org/method/channels.editBanned"/><br/> and <a href="https://corefork.telegram.org/method/messages.deleteChatUser"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403</para></summary>
		/// <param name="peer">Chat/Channel</param>
		/// <param name="user">User to be removed</param>
		public Task<UpdatesBase> DeleteChatUser(InputPeer peer, InputUser user) => peer switch
		{
			InputPeerChat chat => this.Messages_DeleteChatUser(chat.chat_id, user, true),
			InputPeerChannel channel => this.Channels_EditBanned(channel, user, new ChatBannedRights { flags = ChatBannedRights.Flags.view_messages }),
			_ => throw new ArgumentException(OnlyChatChannel),
		};

		/// <summary>Generic helper: Leave a Chat or Channel [bots: ✓]		<para>See <a href="https://corefork.telegram.org/method/messages.deleteChatUser"/><br/> and <a href="https://corefork.telegram.org/method/channels.leaveChannel"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403</para></summary>
		/// <param name="peer">Chat/Channel to leave</param>
		public Task<UpdatesBase> LeaveChat(InputPeer peer) => peer switch
		{
			InputPeerChat chat => this.Messages_DeleteChatUser(chat.chat_id, InputUser.Self, true),
			InputPeerChannel channel => this.Channels_LeaveChannel(channel),
			_ => throw new ArgumentException(OnlyChatChannel),
		};

		/// <summary>Generic helper: Make a user admin in a Chat or Channel		<para>See <a href="https://corefork.telegram.org/method/messages.editChatAdmin"/><br/> and <a href="https://corefork.telegram.org/method/channels.editAdmin"/> [bots: ✓]</para>		<para>Possible <see cref="RpcException"/> codes: 400,403,406</para></summary>
		/// <param name="peer">Chat/Channel</param>
		/// <param name="user">The user to make admin</param>
		/// <param name="is_admin">Whether to make them admin</param>
		public async Task<UpdatesBase> EditChatAdmin(InputPeer peer, InputUserBase user, bool is_admin)
		{
			switch (peer)
			{
				case InputPeerChat chat:
					await this.Messages_EditChatAdmin(chat.chat_id, user, is_admin);
					return new Updates { date = DateTime.UtcNow, users = [], updates = [],
						chats = (await this.Messages_GetChats(chat.chat_id)).chats };
				case InputPeerChannel channel:
					return await this.Channels_EditAdmin(channel, user,
						new ChatAdminRights { flags = is_admin ? (ChatAdminRights.Flags)0x1E8BF : 0 }, null);
				default:
					throw new ArgumentException(OnlyChatChannel);
			}
		}

		/// <summary>Generic helper: Change the photo of a Chat or Channel [bots: ✓]		<para>See <a href="https://corefork.telegram.org/method/messages.editChatPhoto"/><br/> and <a href="https://corefork.telegram.org/method/channels.editPhoto"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403</para></summary>
		/// <param name="peer">Chat/Channel</param>
		/// <param name="photo">New photo</param>
		public Task<UpdatesBase> EditChatPhoto(InputPeer peer, InputChatPhotoBase photo) => peer switch
		{
			InputPeerChat chat => this.Messages_EditChatPhoto(chat.chat_id, photo),
			InputPeerChannel channel => this.Channels_EditPhoto(channel, photo),
			_ => throw new ArgumentException(OnlyChatChannel),
		};

		/// <summary>Generic helper: Edit the name of a Chat or Channel [bots: ✓]		<para>See <a href="https://corefork.telegram.org/method/messages.editChatTitle"/><br/> and <a href="https://corefork.telegram.org/method/channels.editTitle"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403</para></summary>
		/// <param name="peer">Chat/Channel</param>
		/// <param name="title">New name</param>
		public Task<UpdatesBase> EditChatTitle(InputPeer peer, string title) => peer switch
		{
			InputPeerChat chat => this.Messages_EditChatTitle(chat.chat_id, title),
			InputPeerChannel channel => this.Channels_EditTitle(channel, title),
			_ => throw new ArgumentException(OnlyChatChannel),
		};

		/// <summary>Get full info about a Chat or Channel [bots: ✓]		<para>See <a href="https://corefork.telegram.org/method/messages.getFullChat"/><br/> and <a href="https://corefork.telegram.org/method/channels.getFullChannel"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403,406</para></summary>
		/// <param name="peer">Chat/Channel</param>
		public Task<Messages_ChatFull> GetFullChat(InputPeer peer) => peer switch
		{
			InputPeerChat chat => this.Messages_GetFullChat(chat.chat_id),
			InputPeerChannel channel => this.Channels_GetFullChannel(channel),
			_ => throw new ArgumentException(OnlyChatChannel),
		};

		/// <summary>Generic helper: Delete a Chat or Channel		<para>See <a href="https://corefork.telegram.org/method/messages.deleteChat"/><br/> and <a href="https://corefork.telegram.org/method/channels.deleteChannel"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403,406</para></summary>
		/// <param name="peer">Chat/Channel to delete</param>
		public async Task<UpdatesBase> DeleteChat(InputPeer peer)
		{
			switch (peer)
			{
				case InputPeerChat chat:
					await this.Messages_DeleteChat(chat.chat_id);
					return new Updates { date = DateTime.UtcNow, users = [], updates = [],
						chats = (await this.Messages_GetChats(chat.chat_id)).chats };
				case InputPeerChannel channel:
					return await this.Channels_DeleteChannel(channel);
				default:
					throw new ArgumentException(OnlyChatChannel);
			}
		}

		/// <summary>If you want to get all messages from a chat, use method Messages_GetHistory</summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822")]
		public Task<Messages_MessagesBase> GetMessages(InputPeer peer)
			=> throw new WTException("If you want to get all messages from a chat, use method Messages_GetHistory");

		/// <summary>Generic helper: Get individual messages by IDs [bots: ✓]		<para>See <a href="https://corefork.telegram.org/method/messages.getMessages"/><br/> and <a href="https://corefork.telegram.org/method/channels.getMessages"/></para>		<para>Possible <see cref="RpcException"/> codes: 400</para></summary>
		/// <param name="peer">User/Chat/Channel</param>
		/// <param name="id">IDs of messages to get</param>
		public Task<Messages_MessagesBase> GetMessages(InputPeer peer, params InputMessage[] id)
			=> peer is InputPeerChannel channel ? this.Channels_GetMessages(channel, id) : this.Messages_GetMessages(id);

		/// <summary>Generic helper: Delete messages by IDs [bots: ✓]<br/>Messages are deleted for all participants		<para>See <a href="https://corefork.telegram.org/method/messages.deleteMessages"/><br/> and <a href="https://corefork.telegram.org/method/channels.deleteMessages"/></para>		<para>Possible <see cref="RpcException"/> codes: 400,403</para></summary>
		/// <param name="peer">User/Chat/Channel</param>
		/// <param name="id">IDs of messages to delete</param>
		public Task<Messages_AffectedMessages> DeleteMessages(InputPeer peer, params int[] id)
			=> peer is InputPeerChannel channel ? this.Channels_DeleteMessages(channel, id) : this.Messages_DeleteMessages(id, true);

		/// <summary>Generic helper: Marks message history as read.		<para>See <a href="https://corefork.telegram.org/method/messages.readHistory"/><br/> and <a href="https://corefork.telegram.org/method/channels.readHistory"/></para>		<para>Possible <see cref="RpcException"/> codes: 400</para></summary>
		/// <param name="peer">User/Chat/Channel</param>
		/// <param name="max_id">If a positive value is passed, only messages with identifiers less or equal than the given one will be marked read</param>
		public async Task<bool> ReadHistory(InputPeer peer, int max_id = default)
			=> peer is InputPeerChannel channel ? await this.Channels_ReadHistory(channel, max_id) : (await this.Messages_ReadHistory(peer, max_id)) != null;

		private static readonly char[] UrlSeparator = ['?', '#', '/'];

		/// <summary>Return information about a chat/channel based on Invite Link or Public Link</summary>
		/// <param name="url">Public link or Invite link, like https://t.me/+InviteHash, https://t.me/joinchat/InviteHash or https://t.me/channelname<br/>Works also without https:// prefix</param>
		/// <param name="join"><see langword="true"/> to also join the chat/channel</param>
		/// <param name="chats">previously collected chats, to prevent unnecessary ResolveUsername</param>
		/// <returns>a Chat or Channel, possibly partial Channel information only (with flag <see cref="Channel.Flags.min"/>)</returns>
		public async Task<ChatBase> AnalyzeInviteLink(string url, bool join = false, IDictionary<long, ChatBase> chats = null)
		{
			int start = url.IndexOf("//");
			start = url.IndexOf('/', start + 2) + 1;
			int end = url.IndexOfAny(UrlSeparator, start);
			if (end == -1) end = url.Length;
			if (start == 0 || end == start) throw new ArgumentException("Invalid URL");
			string hash;
			if (url[start] == '+')
				hash = url[(start + 1)..end];
			else if (string.Compare(url, start, "joinchat/", 0, 9, StringComparison.OrdinalIgnoreCase) == 0)
				hash = url[(end + 1)..];
			else
			{
				var chat = await CachedOrResolveUsername(url[start..end], chats);
				if (join && chat is Channel channel)
					try
					{
						var res = await this.Channels_JoinChannel(channel);
						chat = res.Chats[channel.id];
					}
					catch (RpcException ex) when (ex.Code == 400 && ex.Message == "INVITE_REQUEST_SENT") { }
				return chat;
			}
			var chatInvite = await this.Messages_CheckChatInvite(hash);
			if (join)
				try
				{
					var res = await this.Messages_ImportChatInvite(hash);
					if (res.Chats.Values.FirstOrDefault() is ChatBase chat) return chat;
				}
				catch (RpcException ex) when (ex.Code == 400 && ex.Message == "INVITE_REQUEST_SENT") { }
			switch (chatInvite)
			{
				case ChatInviteAlready cia: return cia.chat;
				case ChatInvitePeek cip: return cip.chat;
				case ChatInvite ci:
					ChatPhoto chatPhoto = null;
					if (ci.photo is Photo photo)
					{
						var stripped_thumb = photo.sizes.OfType<PhotoStrippedSize>().FirstOrDefault()?.bytes;
						chatPhoto = new ChatPhoto
						{
							dc_id = photo.dc_id,
							photo_id = photo.id,
							stripped_thumb = stripped_thumb,
							flags = (stripped_thumb != null ? ChatPhoto.Flags.has_stripped_thumb : 0) |
									(photo.flags.HasFlag(Photo.Flags.has_video_sizes) ? ChatPhoto.Flags.has_video : 0),
						};
					}
					var rrAbout = ci.about == null ? null : new RestrictionReason[] { new() { text = ci.about } };
					return !ci.flags.HasFlag(ChatInvite.Flags.channel)
						? new Chat { title = ci.title, photo = chatPhoto, participants_count = ci.participants_count,
							flags = ci.flags.HasFlag(ChatInvite.Flags.request_needed) ? (Chat.Flags)Channel.Flags.join_request : 0 }
						: new Channel { title = ci.title, photo = chatPhoto, participants_count = ci.participants_count,
							restriction_reason = rrAbout, flags = Channel.Flags.min |
								(ci.flags.HasFlag(ChatInvite.Flags.broadcast) ? Channel.Flags.broadcast : 0) |
								(ci.flags.HasFlag(ChatInvite.Flags.public_) ? Channel.Flags.has_username : 0) |
								(ci.flags.HasFlag(ChatInvite.Flags.megagroup) ? Channel.Flags.megagroup : 0) |
								(ci.flags.HasFlag(ChatInvite.Flags.verified) ? Channel.Flags.verified : 0) |
								(ci.flags.HasFlag(ChatInvite.Flags.scam) ? Channel.Flags.scam : 0) |
								(ci.flags.HasFlag(ChatInvite.Flags.fake) ? Channel.Flags.fake : 0) |
								(ci.flags.HasFlag(ChatInvite.Flags.request_needed) ? Channel.Flags.join_request : 0) };
			}
			return null;
		}

		/// <summary>Return chat and message details based on a Message Link (URL)</summary>
		/// <param name="url">Message Link, like https://t.me/c/1234567890/1234 or t.me/channelname/1234</param>
		/// <param name="chats">previously collected chats, to prevent unnecessary ResolveUsername</param>
		/// <returns>Structure containing the message, chat and user details</returns>
		/// <remarks>If link is for private group (<c>t.me/c/..</c>), user must have joined that group</remarks>
		public async Task<Messages_ChannelMessages> GetMessageByLink(string url, IDictionary<long, ChatBase> chats = null)
		{
			int start = url.IndexOf("//");
			start = url.IndexOf('/', start + 2) + 1;
			int slash = url.IndexOf('/', start + 2);
			int msgStart = slash + 1;
			int end = url.IndexOfAny(UrlSeparator, msgStart);
			if (end == -1) end = url.Length;
			else if (url[end] == '/' && char.IsDigit(url[msgStart]) && url.Length > end + 1 && char.IsDigit(url[end + 1]))
			{
				end = url.IndexOfAny(UrlSeparator, msgStart = end + 1);
				if (end == -1) end = url.Length;
			}
			if (start == 0 || slash == -1 || end <= slash + 1 || !char.IsDigit(url[msgStart])) throw new ArgumentException("Invalid URL");
			int msgId = int.Parse(url[msgStart..end]);
			ChatBase chat;
			if (url[start] is 'c' or 'C' && url[start + 1] == '/')
			{
				long chatId = long.Parse(url[(start + 2)..slash]);
				if (chats?.TryGetValue(chatId, out chat) != true)
				{
					var mc = await this.Channels_GetChannels(new InputChannel(chatId, 0));
					if (!mc.chats.TryGetValue(chatId, out chat))
						throw new WTException($"Channel {chatId} not found");
					else
						chats?[chatId] = chat;
				}
			}
			else
				chat = await CachedOrResolveUsername(url[start..slash], chats);
			if (chat is not Channel channel) throw new WTException($"URL does not identify a valid Channel");
			return await this.Channels_GetMessages(channel, msgId) as Messages_ChannelMessages;
		}

		private async Task<ChatBase> CachedOrResolveUsername(string username, IDictionary<long, ChatBase> chats = null)
		{
			if (chats == null)
				return (await this.Contacts_ResolveUsername(username)).Chat;
			ChatBase chat;
			lock (chats)
				chat = chats.Values.OfType<Channel>().FirstOrDefault(ch => ch.ActiveUsernames.Contains(username, StringComparer.OrdinalIgnoreCase));
			if (chat == null)
			{
				chat = (await this.Contacts_ResolveUsername(username)).Chat;
				if (chat != null) lock (chats) chats[chat.ID] = chat;
			}
			return chat;
		}

		/// <summary>Receive updates for a given group/channel until cancellation is requested.</summary>
		/// <param name="channel">Group/channel to monitor without joining</param>
		/// <param name="ct">Cancel token to stop the monitoring</param>
		/// <remarks>After cancelling, you may still receive updates for a few more seconds</remarks>
		public async void OpenChat(InputChannel channel, CancellationToken ct)
		{
			var cts = CancellationTokenSource.CreateLinkedTokenSource(_cts.Token, ct);
			try
			{
				while (!cts.IsCancellationRequested)
				{
					var diff = await this.Updates_GetChannelDifference(channel, null, 1, 1, true);
					var timeout = diff.Timeout * 1000;
					await Task.Delay(timeout != 0 ? timeout : 30000, cts.Token);
				}
			}
			catch (Exception ex)
			{
				if (!cts.IsCancellationRequested)
					Console.WriteLine($"An exception occured for OpenChat {channel.channel_id}: {ex.Message}");
			}
		}
	}
}
