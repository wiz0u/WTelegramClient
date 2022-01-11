using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;

namespace TL
{
	public interface IPeerInfo
	{
		long ID { get; }
		bool IsActive { get; }
		InputPeer ToInputPeer();
	}

	partial class InputPeer { public static InputPeerSelf Self => new(); }
	partial class InputUser { public static InputUserSelf Self => new(); }
	partial class InputPeerChannel	{ public static implicit operator InputChannel(InputPeerChannel channel) => new() { channel_id = channel.channel_id, access_hash = channel.access_hash }; }
	partial class InputPeerUser		{ public static implicit operator InputUser(InputPeerUser user) => new() { user_id = user.user_id, access_hash = user.access_hash }; }
	partial class InputUser			{ public static implicit operator InputPeerUser(InputUser user) => new() { user_id = user.user_id, access_hash = user.access_hash }; }

	partial class InputFileBase
	{
		public abstract InputEncryptedFileBase ToInputEncryptedFile(int key_fingerprint);
		public abstract InputSecureFileBase ToInputSecureFile(byte[] file_hash, byte[] secret);
	}
	partial class InputFile
	{
		public override InputEncryptedFileBase ToInputEncryptedFile(int key_fingerprint) => new InputEncryptedFileUploaded { id = id, parts = parts, md5_checksum = md5_checksum, key_fingerprint = key_fingerprint };
		public override InputSecureFileBase ToInputSecureFile(byte[] file_hash, byte[] secret) => new InputSecureFileUploaded { id = id, parts = parts, md5_checksum = md5_checksum, file_hash = file_hash, secret = secret };
	}
	partial class InputFileBig
	{
		public override InputEncryptedFileBase ToInputEncryptedFile(int key_fingerprint) => new InputEncryptedFileBigUploaded { id = id, parts = parts, key_fingerprint = key_fingerprint };
		public override InputSecureFileBase ToInputSecureFile(byte[] file_hash, byte[] secret) => new InputSecureFileUploaded { id = id, parts = parts, file_hash = file_hash, secret = secret };
	}

	partial class Peer
	{
		public abstract long ID { get; }
		abstract internal IPeerInfo UserOrChat(Dictionary<long, User> users, Dictionary<long, ChatBase> chats);
	}
	partial class PeerUser
	{
		public override string ToString() => "user " + user_id;
		public override long ID => user_id;
		internal override IPeerInfo UserOrChat(Dictionary<long, User> users, Dictionary<long, ChatBase> chats) => users[user_id];
	}
	partial class PeerChat
	{
		public override string ToString() => "chat " + chat_id;
		public override long ID => chat_id;
		internal override IPeerInfo UserOrChat(Dictionary<long, User> users, Dictionary<long, ChatBase> chats) => chats[chat_id];
	}
	partial class PeerChannel
	{
		public override string ToString() => "channel " + channel_id;
		public override long ID => channel_id;
		internal override IPeerInfo UserOrChat(Dictionary<long, User> users, Dictionary<long, ChatBase> chats) => chats[channel_id];
	}

	partial class UserBase : IPeerInfo
	{
		public abstract long ID { get; }
		public abstract bool IsActive { get; }
		public abstract InputPeer ToInputPeer();
		protected abstract InputUser ToInputUser();
		public static implicit operator InputPeer(UserBase user) => user?.ToInputPeer();
		public static implicit operator InputUser(UserBase user) => user?.ToInputUser();
	}
	partial class UserEmpty
	{
		public override long ID => id;
		public override bool IsActive => false;
		public override string ToString() => null;
		public override InputPeer ToInputPeer() => null;
		protected override InputUser ToInputUser() => null;
	}
	partial class User
	{
		public override long ID => id;
		public override bool IsActive => (flags & Flags.deleted) == 0;
		public override string ToString() => username != null ? '@' + username : last_name == null ? first_name : $"{first_name} {last_name}";
		public override InputPeer ToInputPeer() => new InputPeerUser { user_id = id, access_hash = access_hash };
		protected override InputUser ToInputUser() => new() { user_id = id, access_hash = access_hash };
		/// <summary>An estimation of the number of days ago the user was last seen (Online=0, Recently=1, LastWeek=5, LastMonth=20, LongTimeAgo=150)</summary>
		public TimeSpan LastSeenAgo => status?.LastSeenAgo ?? TimeSpan.FromDays(150);
	}


	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/userStatusEmpty">userStatusEmpty</a> = last seen a long time ago, more than a month (this is also always shown to blocked users)</remarks>
	partial class UserStatus			{ /// <summary>An estimation of the number of days ago the user was last seen (online=0, recently=1, lastWeek=5, lastMonth=20)<br/><see cref="UserStatus"/> = <c>null</c> means a long time ago, more than a month (this is also always shown to blocked users)</summary>
										  public abstract TimeSpan LastSeenAgo { get; } }
	partial class UserStatusOnline		{ public override TimeSpan LastSeenAgo => TimeSpan.Zero; }
	partial class UserStatusOffline		{ public override TimeSpan LastSeenAgo => DateTime.UtcNow - new DateTime((was_online + 62135596800L) * 10000000, DateTimeKind.Utc); }
	/// <remarks>covers anything between 1 second and 2-3 days</remarks>
	partial class UserStatusRecently	{ public override TimeSpan LastSeenAgo => TimeSpan.FromDays(1); }
	/// <remarks>between 2-3 and seven days</remarks>
	partial class UserStatusLastWeek	{ public override TimeSpan LastSeenAgo => TimeSpan.FromDays(5); }
	/// <remarks>between 6-7 days and a month</remarks>
	partial class UserStatusLastMonth	{ public override TimeSpan LastSeenAgo => TimeSpan.FromDays(20); }

	partial class ChatBase : IPeerInfo
	{
		public abstract bool IsActive { get; }
		public abstract ChatPhoto Photo { get; }
		/// <summary>returns true if you're banned of any of these rights</summary>
		public abstract bool IsBanned(ChatBannedRights.Flags flags = 0);
		public abstract InputPeer ToInputPeer();
		public static implicit operator InputPeer(ChatBase chat) => chat.ToInputPeer();
	}
	partial class ChatEmpty
	{
		public override bool IsActive => false;
		public override ChatPhoto Photo => null;
		public override bool IsBanned(ChatBannedRights.Flags flags = 0) => true;
		public override InputPeer ToInputPeer() => null;
		public override string ToString() => $"ChatEmpty {id}";
	}
	partial class Chat
	{
		public override bool IsActive => (flags & (Flags.kicked | Flags.left | Flags.deactivated)) == 0;
		public override ChatPhoto Photo => photo;
		public override bool IsBanned(ChatBannedRights.Flags flags = 0) => ((default_banned_rights?.flags ?? 0) & flags) != 0;
		public override InputPeer ToInputPeer() => new InputPeerChat { chat_id = id };
		public override string ToString() => $"Chat \"{title}\"" + (flags.HasFlag(Flags.deactivated) ? " [deactivated]" : null);
	}
	partial class ChatForbidden
	{
		public override bool IsActive => false;
		public override ChatPhoto Photo => null;
		public override bool IsBanned(ChatBannedRights.Flags flags = 0) => true;
		public override InputPeer ToInputPeer() => new InputPeerChat { chat_id = id };
		public override string ToString() => $"ChatForbidden {id} \"{title}\"";
	}
	partial class Channel
	{
		public override bool IsActive => (flags & Flags.left) == 0;
		public override ChatPhoto Photo => photo;
		public override bool IsBanned(ChatBannedRights.Flags flags = 0) => ((banned_rights?.flags ?? 0) & flags) != 0 || ((default_banned_rights?.flags ?? 0) & flags) != 0;
		public override InputPeer ToInputPeer() => new InputPeerChannel { channel_id = id, access_hash = access_hash };
		public static implicit operator InputChannel(Channel channel) => new() { channel_id = channel.id, access_hash = channel.access_hash };
		public override string ToString() =>
			(flags.HasFlag(Flags.broadcast) ? "Channel " : "Group ") + (username != null ? '@' + username : $"\"{title}\"");
		public bool IsChannel => (flags & Flags.broadcast) != 0;
		public bool IsGroup => (flags & Flags.broadcast) == 0;
	}
	partial class ChannelForbidden
	{
		public override bool IsActive => false;
		public override ChatPhoto Photo => null;
		public override bool IsBanned(ChatBannedRights.Flags flags = 0) => true;
		public override InputPeer ToInputPeer() => new InputPeerChannel { channel_id = id, access_hash = access_hash };
		public override string ToString() => $"ChannelForbidden {id} \"{title}\"";
	}

	partial class ChatParticipantBase		{ public abstract bool IsAdmin { get; } }
	partial class ChatParticipant			{ public override bool IsAdmin => false; }
	partial class ChatParticipantCreator	{ public override bool IsAdmin => true; }
	partial class ChatParticipantAdmin		{ public override bool IsAdmin => true; }

	partial class PhotoBase
	{
		public abstract long ID { get; }
		protected abstract InputPhoto ToInputPhoto();
		public static implicit operator InputPhoto(PhotoBase photo) => photo.ToInputPhoto();
	}
	partial class PhotoEmpty
	{
		public override long ID => id;
		protected override InputPhoto ToInputPhoto() => null;
	}
	partial class Photo
	{
		public override long ID => id;
		protected override InputPhoto ToInputPhoto() => new() { id = id, access_hash = access_hash, file_reference = file_reference };
		public InputPhotoFileLocation ToFileLocation() => ToFileLocation(LargestPhotoSize);
		public InputPhotoFileLocation ToFileLocation(PhotoSizeBase photoSize) => new() { id = id, access_hash = access_hash, file_reference = file_reference, thumb_size = photoSize.Type };
		public PhotoSizeBase LargestPhotoSize => sizes.Aggregate((agg, next) => (long)next.Width * next.Height > (long)agg.Width * agg.Height ? next : agg);
	}

	partial class PhotoSizeBase
	{
		public abstract int Width { get; }
		public abstract int Height { get; }
		public abstract int FileSize { get; }
	}
	partial class PhotoSizeEmpty
	{
		public override int Width => 0;
		public override int Height => 0;
		public override int FileSize => 0;
	}
	partial class PhotoSize
	{
		public override int Width => w;
		public override int Height => h;
		public override int FileSize => size;
	}
	partial class PhotoCachedSize
	{
		public override int Width => w;
		public override int Height => h;
		public override int FileSize => bytes.Length;
	}
	partial class PhotoStrippedSize
	{
		public override int Width => bytes[2];
		public override int Height => bytes[1];
		public override int FileSize => bytes.Length;
	}
	partial class PhotoSizeProgressive
	{
		public override int Width => w;
		public override int Height => h;
		public override int FileSize => sizes.Last();
	}
	partial class PhotoPathSize
	{
		public override int Width => -1;
		public override int Height => -1;
		public override int FileSize => bytes.Length;
	}
	namespace Layer23
	{
		partial class PhotoSize
		{
			public override int Width => w;
			public override int Height => h;
			public override int FileSize => size;
		}
		partial class PhotoCachedSize
		{
			public override int Width => w;
			public override int Height => h;
			public override int FileSize => bytes.Length;
		}
	}

	partial class Contacts_Blocked { public IPeerInfo UserOrChat(PeerBlocked peer) => peer.peer_id.UserOrChat(users, chats); }
	partial class Messages_DialogsBase			{ public IPeerInfo UserOrChat(DialogBase dialog) => UserOrChat(dialog.Peer);
												  public abstract int TotalCount { get; } }
	partial class Messages_Dialogs				{ public override int TotalCount => dialogs.Length; }
	partial class Messages_DialogsSlice			{ public override int TotalCount => count; }
	partial class Messages_DialogsNotModified	{ public override int TotalCount => count; }

	partial class Messages_MessagesBase			{ public abstract int Count { get; } }
	partial class Messages_Messages				{ public override int Count => messages.Length; }
	partial class Messages_MessagesSlice		{ public override int Count => count; }
	partial class Messages_ChannelMessages		{ public override int Count => count; }
	partial class Messages_MessagesNotModified	{ public override int Count => count; }

	partial class Updates_DifferenceBase		{ public abstract Updates_State State { get; } }
	partial class Updates_DifferenceEmpty		{ public override Updates_State State => null; }
	partial class Updates_Difference			{ public override Updates_State State => state; }
	partial class Updates_DifferenceSlice		{ public override Updates_State State => intermediate_state; }
	partial class Updates_DifferenceTooLong		{ public override Updates_State State => null; }

	partial class UpdatesBase
	{
		public abstract Update[] UpdateList { get; }
		public virtual Dictionary<long, User> Users => NoUsers;
		public virtual Dictionary<long, ChatBase> Chats => NoChats;
		private static readonly Dictionary<long, User> NoUsers = new();
		private static readonly Dictionary<long, ChatBase> NoChats = new();
	}
	partial class UpdatesCombined
	{
		public override Update[] UpdateList => updates;
		public override Dictionary<long, User> Users => users;
		public override Dictionary<long, ChatBase> Chats => chats;
	}
	partial class Updates
	{
		public override Update[] UpdateList => updates;
		public override Dictionary<long, User> Users => users;
		public override Dictionary<long, ChatBase> Chats => chats;
	}
	partial class UpdatesTooLong			{ public override Update[] UpdateList => Array.Empty<Update>(); }
	partial class UpdateShort				{ public override Update[] UpdateList => new[] { update }; }
	partial class UpdateShortSentMessage	{ public override Update[] UpdateList => Array.Empty<Update>(); }
	partial class UpdateShortMessage		{ public override Update[] UpdateList => new[] { new UpdateNewMessage
	{
		message = new Message
		{
			flags = (Message.Flags)flags | Message.Flags.has_from_id, id = id, date = date,
			message = message, entities = entities, reply_to = reply_to,
			from_id = new PeerUser { user_id = user_id },
			peer_id = new PeerUser { user_id = user_id },
			fwd_from = fwd_from, via_bot_id = via_bot_id, ttl_period = ttl_period
		}, pts = pts, pts_count = pts_count
	} }; }
	partial class UpdateShortChatMessage { public override Update[] UpdateList => new[] { new UpdateNewMessage
	{
		message = new Message
		{
			flags = (Message.Flags)flags | Message.Flags.has_from_id, id = id, date = date,
			message = message, entities = entities, reply_to = reply_to,
			from_id = new PeerUser { user_id = from_id },
			peer_id = new PeerChat { chat_id = chat_id },
			fwd_from = fwd_from, via_bot_id = via_bot_id, ttl_period = ttl_period
		}, pts = pts, pts_count = pts_count
	} }; }

	partial class EncryptedFile
	{
		public static implicit operator InputEncryptedFile(EncryptedFile file) => file == null ? null : new InputEncryptedFile { id = file.id, access_hash = file.access_hash };
		public InputEncryptedFileLocation ToFileLocation() => new() { id = id, access_hash = access_hash };
	}

	partial class DocumentBase
	{
		public abstract long ID { get; }
		protected abstract InputDocument ToInputDocument();
		public static implicit operator InputDocument(DocumentBase document) => document.ToInputDocument();
	}
	partial class DocumentEmpty
	{
		public override long ID => id;
		protected override InputDocument ToInputDocument() => null;
	}
	partial class Document
	{
		public override long ID => id;
		protected override InputDocument ToInputDocument() => new() { id = id, access_hash = access_hash, file_reference = file_reference };
		public InputDocumentFileLocation ToFileLocation(PhotoSizeBase thumbSize = null) => new() { id = id, access_hash = access_hash, file_reference = file_reference, thumb_size = thumbSize?.Type };
		public PhotoSizeBase LargestThumbSize => thumbs.Aggregate((agg, next) => (long)next.Width * next.Height > (long)agg.Width * agg.Height ? next : agg);
	}

	partial class SendMessageAction
	{
		public override string ToString()
		{
			var type = GetType().Name[11..^6];
			for (int i = 1; i < type.Length; i++)
				if (char.IsUpper(type[i]))
					return type.ToLowerInvariant().Insert(i, "ing ").Remove(i - 1, type[i - 1] == 'e' ? 1 : 0);
			return type.ToLowerInvariant();
		}
	}
	partial class SpeakingInGroupCallAction			{ public override string ToString() => "speaking in group call"; }
	partial class SendMessageTypingAction			{ public override string ToString() => "typing"; }
	partial class SendMessageCancelAction			{ public override string ToString() => "stopping"; }
	partial class SendMessageGeoLocationAction		{ public override string ToString() => "selecting a location"; }
	partial class SendMessageGamePlayAction			{ public override string ToString() => "playing a game"; }
	partial class SendMessageHistoryImportAction	{ public override string ToString() => "importing history"; }
	partial class SendMessageEmojiInteraction		{ public override string ToString() => "clicking on emoji"; }
	partial class SendMessageEmojiInteractionSeen	{ public override string ToString() => "watching emoji reaction"; }

	partial class StickerSet
	{
		public static implicit operator InputStickerSetID(StickerSet stickerSet) => new() { id = stickerSet.id, access_hash = stickerSet.access_hash };
	}

	partial class InputChannel { public static implicit operator InputPeerChannel(InputChannel channel) => new() { channel_id = channel.channel_id, access_hash = channel.access_hash }; }

	partial class Contacts_ResolvedPeer
	{
		public static implicit operator InputPeer(Contacts_ResolvedPeer resolved) => resolved.UserOrChat.ToInputPeer();
		/// <returns>A <see cref="TL.User"/>, or <see langword="null"/> if the username was for a channel</returns>
		public User User => peer is PeerUser pu ? users[pu.user_id] : null;
		/// <returns>A <see cref="Channel"/> or <see cref="ChannelForbidden"/>, or <see langword="null"/> if the username was for a user</returns>
		public ChatBase Chat => peer is PeerChannel or PeerChat ? chats[peer.ID] : null;
	}

	partial class Updates_ChannelDifferenceBase
	{
		public abstract MessageBase[] NewMessages { get; }
		public abstract Update[] OtherUpdates { get; }
		public abstract bool Final { get; }
		public abstract int Timeout { get; }
	}
	partial class Updates_ChannelDifferenceEmpty
	{
		public override MessageBase[] NewMessages => Array.Empty<MessageBase>();
		public override Update[] OtherUpdates => Array.Empty<Update>();
		public override bool Final => flags.HasFlag(Flags.final);
		public override int Timeout => timeout;
	}
	partial class Updates_ChannelDifference
	{
		public override MessageBase[] NewMessages => new_messages;
		public override Update[] OtherUpdates => other_updates;
		public override bool Final => flags.HasFlag(Flags.final);
		public override int Timeout => timeout;
	}
	partial class Updates_ChannelDifferenceTooLong
	{
		public override MessageBase[] NewMessages => messages;
		public override Update[] OtherUpdates => null;
		public override bool Final => flags.HasFlag(Flags.final);
		public override int Timeout => timeout;
	}

	partial class ChannelParticipantBase
	{
		public virtual bool IsAdmin => false;
		public abstract long UserID { get; }
	}
	partial class ChannelParticipantCreator
	{
		public override bool IsAdmin => true;
		public override long UserID => user_id;
	}
	partial class ChannelParticipantAdmin
	{
		public override bool IsAdmin => true;
		public override long UserID => user_id;
	}
	partial class ChannelParticipant		{ public override long UserID => user_id; }
	partial class ChannelParticipantSelf	{ public override long UserID => user_id; }
	partial class ChannelParticipantBanned	{ public override long UserID => peer is PeerUser pu ? pu.user_id : 0; }
	partial class ChannelParticipantLeft	{ public override long UserID => peer is PeerUser pu ? pu.user_id : 0; }

	partial class Messages_PeerDialogs { public IPeerInfo UserOrChat(DialogBase dialog) => dialog.Peer.UserOrChat(users, chats); }

	partial class WebDocument { public static implicit operator InputWebFileLocation(WebDocument doc) => new() { url = doc.url, access_hash = doc.access_hash }; }

	partial class SecureFile
	{
		public static implicit operator InputSecureFile(SecureFile file) => new() { id = file.id, access_hash = file.access_hash };
		public InputSecureFileLocation ToFileLocation() => new() { id = id, access_hash = access_hash };
	}

	partial class JsonObjectValue { public override string ToString() => $"{HttpUtility.JavaScriptStringEncode(key, true)}:{value}"; }
	partial class JSONValue  { public abstract object ToNative(); }
	partial class JsonNull   { public override object ToNative() => null;  public override string ToString() => "null"; }
	partial class JsonBool   { public override object ToNative() => value; public override string ToString() => value ? "true" : "false"; }
	partial class JsonNumber { public override object ToNative() => value; public override string ToString() => value.ToString(CultureInfo.InvariantCulture); }
	partial class JsonString { public override object ToNative() => value; public override string ToString() => HttpUtility.JavaScriptStringEncode(value, true); }
	partial class JsonArray
	{
		public override string ToString()
		{
			var sb = new StringBuilder().Append('[');
			for (int i = 0; i < value.Length; i++)
				sb.Append(i == 0 ? "" : ",").Append(value[i]);
			return sb.Append(']').ToString();
		}
		public object[] ToNativeArray() => value.Select(v => v.ToNative()).ToArray();
		public override object ToNative()
		{
			if (value.Length == 0) return Array.Empty<object>();
			var first = value[0].ToNative();
			var T = first.GetType();
			var array = Array.CreateInstance(T, value.Length); // create an array T[] of the native type
			array.SetValue(first, 0);
			for (int i = 1; i < value.Length; i++)
			{
				var elem = value[i].ToNative();
				if (elem.GetType() != T) return ToNativeArray(); // incompatible => return an object[] instead
				array.SetValue(elem, i);
			}
			return array;
		}
	}
	partial class JsonObject
	{
		/// <summary>Returns a JSON serialization string for this object</summary>
		public override string ToString()
		{
			var sb = new StringBuilder().Append('{');
			for (int i = 0; i < value.Length; i++)
				sb.Append(i == 0 ? "" : ",").Append(value[i]);
			return sb.Append('}').ToString();
		}
		/// <summary>Returns the given entry in native form (<see langword="bool"/>, <see langword="double"/>, <see langword="string"/>, <see cref="Dictionary{TKey, TValue}">Dictionary</see> or <see cref="Array"/>), or <see langword="null"/> if the key is not found</summary>
		public object this[string key] => value.FirstOrDefault(v => v.key == key)?.value.ToNative();
		/// <summary>Converts the entries to a Dictionary with keys and values in native form (<see langword="bool"/>, <see langword="double"/>, <see langword="string"/>, <see cref="Dictionary{TKey, TValue}">Dictionary</see> or <see cref="Array"/>)</summary>
		public Dictionary<string, object> ToDictionary() => value.ToDictionary(v => v.key, v => v.value.ToNative());
		public override object ToNative()
		{
			if (value.Length == 0) return new Dictionary<string, object>();
			var first = value[0].value.ToNative();
			var T = first.GetType(); // create a Dictionary<string, T> of the native type T:
			var dic = Activator.CreateInstance(typeof(Dictionary<,>).MakeGenericType(typeof(string), T)) as System.Collections.IDictionary;
			dic.Add(value[0].key, first);
			for (int i = 1; i < value.Length; i++)
			{
				var elem = value[i].value.ToNative();
				if (elem.GetType() != T) return ToDictionary();  // incompatible => return a Dictionary<string, object> instead
				dic.Add(value[i].key, elem);
			}
			return dic;
		}
	}

	public static class Markdown
	{
		/// <summary>Converts a Markdown text into the (Entities + plain text) format used by Telegram messages</summary>
		/// <param name="client">Client, used for getting access_hash for <c>tg://user?id=</c> URLs</param>
		/// <param name="text">[in] The Markdown text<br/>[out] The same (plain) text, stripped of all Markdown notation</param>
		/// <returns>The array of formatting entities that you can pass (along with the plain text) to <see cref="WTelegram.Client.SendMessageAsync">SendMessageAsync</see> or  <see cref="WTelegram.Client.SendMediaAsync">SendMediaAsync</see></returns>
		public static MessageEntity[] MarkdownToEntities(this WTelegram.Client client, ref string text)
		{
			var entities = new List<MessageEntity>();
			var sb = new StringBuilder(text);
			for (int offset = 0; offset < sb.Length;)
			{
				switch (sb[offset])
				{
					case '\\': sb.Remove(offset++, 1); break;
					case '*': ProcessEntity<MessageEntityBold>(); break;
					case '~': ProcessEntity<MessageEntityStrike>(); break;
					case '_':
						if (offset + 1 < sb.Length && sb[offset + 1] == '_')
						{
							sb.Remove(offset, 1);
							ProcessEntity<MessageEntityUnderline>();
						}
						else
							ProcessEntity<MessageEntityItalic>();
						break;
					case '|':
						if (offset + 1 < sb.Length && sb[offset + 1] == '|')
						{
							sb.Remove(offset, 1);
							ProcessEntity<MessageEntitySpoiler>();
						}
						else
							offset++;
						break;
					case '`':
						if (offset + 2 < sb.Length && sb[offset + 1] == '`' && sb[offset + 2] == '`')
						{
							int len = 3;
							if (entities.FindLast(e => e.length == -1) is MessageEntityPre pre)
								pre.length = offset - pre.offset;
							else
							{
								while (offset + len < sb.Length && !char.IsWhiteSpace(sb[offset + len]))
									len++;
								entities.Add(new MessageEntityPre { offset = offset, length = -1, language = sb.ToString(offset + 3, len - 3) });
							}
							sb.Remove(offset, len);
						}
						else
							ProcessEntity<MessageEntityCode>();
						break;
					case '[':
						entities.Add(new MessageEntityTextUrl { offset = offset, length = -1 });
						sb.Remove(offset, 1);
						break;
					case ']':
						if (offset + 2 < sb.Length && sb[offset + 1] == '(')
						{
							var lastIndex = entities.FindLastIndex(e => e.length == -1);
							if (lastIndex >= 0 && entities[lastIndex] is MessageEntityTextUrl textUrl)
							{
								textUrl.length = offset - textUrl.offset;
								int offset2 = offset + 2;
								while (offset2 < sb.Length)
								{
									char c = sb[offset2++];
									if (c == '\\') sb.Remove(offset2 - 1, 1);
									else if (c == ')') break;
								}
								textUrl.url = sb.ToString(offset + 2, offset2 - offset - 3);
								if (textUrl.url.StartsWith("tg://user?id=") && long.TryParse(textUrl.url[13..], out var user_id) && client.GetAccessHashFor<User>(user_id) is long hash)
									entities[lastIndex] = new InputMessageEntityMentionName { offset = textUrl.offset, length = textUrl.length, user_id = new InputUser { user_id = user_id, access_hash = hash } };
								sb.Remove(offset, offset2 - offset);
								break;
							}
						}
						offset++;
						break;
					default: offset++; break;
				}

				void ProcessEntity<T>() where T : MessageEntity, new()
				{
					if (entities.LastOrDefault(e => e.length == -1) is T prevEntity)
						prevEntity.length = offset - prevEntity.offset;
					else
						entities.Add(new T { offset = offset, length = -1 });
					sb.Remove(offset, 1);
				}
			}
			text = sb.ToString();
			return entities.Count == 0 ? null : entities.ToArray();
		}

		/// <summary>Insert backslashes in front of Markdown reserved characters</summary>
		/// <param name="text">The text to escape</param>
		/// <returns>The escaped text, ready to be used in <see cref="MarkdownToEntities">MarkdownToEntities</see> without problems</returns>
		public static string Escape(string text)
		{
			StringBuilder sb = null;
			for (int index = 0, added = 0; index < text.Length; index++)
			{
				switch (text[index])
				{
					case '_': case '*': case '~': case '`': case '#': case '+': case '-': case '=': case '.': case '!':
					case '[': case ']': case '(': case ')': case '{': case '}': case '>': case '|': case '\\':
						sb ??= new StringBuilder(text, text.Length + 32);
						sb.Insert(index + added++, '\\');
						break;
				}
			}
			return sb?.ToString() ?? text;
		}
	}
}
