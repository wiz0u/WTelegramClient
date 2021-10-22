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
		abstract internal IPeerInfo UserOrChat(Dictionary<long, UserBase> users, Dictionary<long, ChatBase> chats);
	}
	partial class PeerUser
	{
		public override string ToString() => "user " + user_id;
		public override long ID => user_id;
		internal override IPeerInfo UserOrChat(Dictionary<long, UserBase> users, Dictionary<long, ChatBase> chats) => users[user_id];
	}
	partial class PeerChat
	{
		public override string ToString() => "chat " + chat_id;
		public override long ID => chat_id;
		internal override IPeerInfo UserOrChat(Dictionary<long, UserBase> users, Dictionary<long, ChatBase> chats) => chats[chat_id];
	}
	partial class PeerChannel
	{
		public override string ToString() => "channel " + channel_id;
		public override long ID => channel_id;
		internal override IPeerInfo UserOrChat(Dictionary<long, UserBase> users, Dictionary<long, ChatBase> chats) => chats[channel_id];
	}

	partial class UserBase : IPeerInfo
	{
		public abstract long ID { get; }
		public abstract bool IsActive { get; }
		public abstract InputPeer ToInputPeer();
		protected abstract InputUserBase ToInputUser();
		public static implicit operator InputPeer(UserBase user) => user.ToInputPeer();
		public static implicit operator InputUserBase(UserBase user) => user.ToInputUser();
	}
	partial class UserEmpty
	{
		public override long ID => id;
		public override bool IsActive => false;
		public override string ToString() => null;
		public override InputPeer ToInputPeer() => null;
		protected override InputUserBase ToInputUser() => null;
	}
	partial class User
	{
		public override long ID => id;
		public override bool IsActive => (flags & Flags.deleted) == 0;
		public override string ToString() => username != null ? '@' + username : last_name == null ? first_name : $"{first_name} {last_name}";
		public override InputPeer ToInputPeer() => new InputPeerUser { user_id = id, access_hash = access_hash };
		protected override InputUserBase ToInputUser() => new InputUser { user_id = id, access_hash = access_hash };
	}

	partial class ChatBase : IPeerInfo
	{
		public abstract long ID { get; }
		public abstract string Title { get; }
		public abstract bool IsActive { get; }
		/// <summary>returns true if you're banned of any of these rights</summary>
		public abstract bool IsBanned(ChatBannedRights.Flags flags = 0);
		public abstract InputPeer ToInputPeer();
		public static implicit operator InputPeer(ChatBase chat) => chat.ToInputPeer();
	}
	partial class ChatEmpty
	{
		public override long ID => id;
		public override string Title => null;
		public override bool IsActive => false;
		public override bool IsBanned(ChatBannedRights.Flags flags = 0) => true;
		public override InputPeer ToInputPeer() => null;
		public override string ToString() => $"ChatEmpty {id}";
	}
	partial class Chat
	{
		public override long ID => id;
		public override string Title => title;
		public override bool IsActive => (flags & (Flags.kicked | Flags.left | Flags.deactivated)) == 0;
		public override bool IsBanned(ChatBannedRights.Flags flags = 0) => ((default_banned_rights?.flags ?? 0) & flags) != 0;
		public override InputPeer ToInputPeer() => new InputPeerChat { chat_id = id };
		public override string ToString() => $"Chat \"{title}\"";
	}
	partial class ChatForbidden
	{
		public override long ID => id;
		public override string Title => title;
		public override bool IsActive => false;
		public override bool IsBanned(ChatBannedRights.Flags flags = 0) => true;
		public override InputPeer ToInputPeer() => new InputPeerChat { chat_id = id };
		public override string ToString() => $"ChatForbidden {id} \"{title}\"";
	}
	partial class Channel
	{
		public override long ID => id;
		public override string Title => title;
		public override bool IsActive => (flags & Flags.left) == 0;
		public override bool IsBanned(ChatBannedRights.Flags flags = 0) => ((banned_rights?.flags ?? 0) & flags) != 0 || ((default_banned_rights?.flags ?? 0) & flags) != 0;
		public override InputPeer ToInputPeer() => new InputPeerChannel { channel_id = id, access_hash = access_hash };
		public static implicit operator InputChannel(Channel channel) => new() { channel_id = channel.id, access_hash = channel.access_hash };
		public override string ToString() =>
			(flags.HasFlag(Flags.broadcast) ? "Channel " : "Group ") + (username != null ? '@' + username : $"\"{title}\"");
	}
	partial class ChannelForbidden
	{
		public override long ID => id;
		public override string Title => title;
		public override bool IsActive => false;
		public override bool IsBanned(ChatBannedRights.Flags flags = 0) => true;
		public override InputPeer ToInputPeer() => new InputPeerChannel { channel_id = id, access_hash = access_hash };
		public override string ToString() => $"ChannelForbidden {id} \"{title}\"";
	}

	partial class ChatParticipantBase
	{
		public abstract long UserId { get; }
		public abstract bool IsAdmin { get; }
	}
	partial class ChatParticipant
	{
		public override long UserId => user_id;
		public override bool IsAdmin => false;
	}
	partial class ChatParticipantCreator
	{
		public override long UserId => user_id;
		public override bool IsAdmin => true;
	}
	partial class ChatParticipantAdmin
	{
		public override bool IsAdmin => true;
	}

	partial class MessageBase
	{
		public abstract int ID { get; }
		public abstract Peer Peer { get; }
		public abstract DateTime Date { get; }
	}
	partial class MessageEmpty
	{
		public override int ID => id;
		public override Peer Peer => peer_id;
		public override DateTime Date => default;
	}
	public partial class Message
	{
		public override int ID => id;
		public override Peer Peer => peer_id;
		public override DateTime Date => date;
	}
	public partial class MessageService
	{
		public override int ID => id;
		public override Peer Peer => peer_id;
		public override DateTime Date => date;
	}

	partial class DialogBase
	{
		public abstract Peer Peer { get; }
		public abstract int TopMessage { get; }
	}
	partial class Dialog
	{
		public override Peer Peer => peer;
		public override int TopMessage => top_message;
	}
	partial class DialogFolder
	{
		public override Peer Peer => peer;
		public override int TopMessage => top_message;
	}

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
		public abstract string Type { get; }
		public abstract int Width { get; }
		public abstract int Height { get; }
		public abstract int FileSize { get; }
	}
	partial class PhotoSizeEmpty
	{
		public override string Type => type;
		public override int Width => 0;
		public override int Height => 0;
		public override int FileSize => 0;
	}
	partial class PhotoSize
	{
		public override string Type => type;
		public override int Width => w;
		public override int Height => h;
		public override int FileSize => size;
	}
	partial class PhotoCachedSize
	{
		public override string Type => type;
		public override int Width => w;
		public override int Height => h;
		public override int FileSize => bytes.Length;
	}
	partial class PhotoStrippedSize
	{
		public override string Type => type;
		public override int Width => bytes[2];
		public override int Height => bytes[1];
		public override int FileSize => bytes.Length;
	}
	partial class PhotoSizeProgressive
	{
		public override string Type => type;
		public override int Width => w;
		public override int Height => h;
		public override int FileSize => sizes.Last();
	}
	partial class PhotoPathSize
	{
		public override string Type => type;
		public override int Width => -1;
		public override int Height => -1;
		public override int FileSize => bytes.Length;
	}
	namespace Layer23
	{
		partial class PhotoSize
		{
			public override string Type => type;
			public override int Width => w;
			public override int Height => h;
			public override int FileSize => size;
		}
		partial class PhotoCachedSize
		{
			public override string Type => type;
			public override int Width => w;
			public override int Height => h;
			public override int FileSize => bytes.Length;
		}
	}

	partial class Contacts_Blocked { public IPeerInfo UserOrChat(PeerBlocked peer) => peer.peer_id.UserOrChat(users, chats); }

	partial class Messages_Dialogs
	{
		/// <summary>Find the matching User/Chat object for a dialog</summary>
		/// <param name="dialog">The dialog which peer we want details on</param>
		/// <returns>a UserBase or ChatBase derived instance</returns>
		public IPeerInfo UserOrChat(DialogBase dialog) => dialog.Peer.UserOrChat(users, chats);
	}

	partial class Messages_MessagesBase
	{
		public abstract int Count { get; }
		public abstract MessageBase[] Messages { get; }
	}
	partial class Messages_Messages
	{
		public override int Count => messages.Length;
		public override MessageBase[] Messages => messages;
	}
	partial class Messages_MessagesSlice
	{
		public override int Count => count;
	}
	partial class Messages_ChannelMessages
	{
		public override int Count => count;
		public override MessageBase[] Messages => messages;
	}
	partial class Messages_MessagesNotModified
	{
		public override int Count => count;
		public override MessageBase[] Messages => null;
	}

	partial class Updates_DifferenceBase
	{
		public abstract MessageBase[] NewMessages { get; }
		public abstract EncryptedMessageBase[] NewEncryptedMessages { get; }
		public abstract Update[] OtherUpdates { get; }
		public abstract Updates_State State { get; }
	}
	partial class Updates_DifferenceEmpty
	{
		public override MessageBase[] NewMessages => Array.Empty<MessageBase>();
		public override EncryptedMessageBase[] NewEncryptedMessages => Array.Empty<EncryptedMessageBase>();
		public override Update[] OtherUpdates => Array.Empty<Update>();
		public override Updates_State State => null;
	}
	partial class Updates_Difference
	{
		public override MessageBase[] NewMessages => new_messages;
		public override EncryptedMessageBase[] NewEncryptedMessages => new_encrypted_messages;
		public override Update[] OtherUpdates => other_updates;
		public override Updates_State State => state;
	}
	partial class Updates_DifferenceSlice
	{
		public override MessageBase[] NewMessages => new_messages;
		public override EncryptedMessageBase[] NewEncryptedMessages => new_encrypted_messages;
		public override Update[] OtherUpdates => other_updates;
		public override Updates_State State => intermediate_state;
	}
	partial class Updates_DifferenceTooLong
	{
		public override MessageBase[] NewMessages => null;
		public override EncryptedMessageBase[] NewEncryptedMessages => null;
		public override Update[] OtherUpdates => null;
		public override Updates_State State => null;
	}

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
	}

	partial class SendMessageAction
	{
		public override string ToString()
		{
			var type = GetType().Name[11..^6];
			for (int i = 1; i < type.Length; i++)
				if (char.IsUpper(type[i]))
					return type.ToLowerInvariant().Insert(i, "ing ");
			return type.ToLowerInvariant();
		}
	}
	partial class SpeakingInGroupCallAction { public override string ToString() => "speaking in group call"; }
	partial class SendMessageTypingAction { public override string ToString() => "typing"; }
	partial class SendMessageCancelAction { public override string ToString() => "stopping"; }
	partial class SendMessageGeoLocationAction { public override string ToString() => "selecting a location"; }
	partial class SendMessageGamePlayAction { public override string ToString() => "playing a game"; }
	partial class SendMessageHistoryImportAction { public override string ToString() => "importing history"; }

	partial class StickerSet
	{
		public static implicit operator InputStickerSetID(StickerSet stickerSet) => new() { id = stickerSet.id, access_hash = stickerSet.access_hash };
	}

	partial class Contacts_ResolvedPeer
	{
		public static implicit operator InputPeer(Contacts_ResolvedPeer resolved) => resolved.UserOrChat.ToInputPeer();
		public UserBase User => peer is PeerUser pu ? users[pu.user_id] : null;
		public ChatBase Chat => peer is PeerChat or PeerChannel ? chats[peer.ID] : null;
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

	partial class Messages_PeerDialogs
	{
		public IPeerInfo UserOrChat(DialogBase dialog) => UserOrChat(dialog.Peer);
	}

	partial class SecureFile
	{
		public static implicit operator InputSecureFile(SecureFile file) => new() { id = file.id, access_hash = file.access_hash };
		public InputSecureFileLocation ToFileLocation() => new() { id = id, access_hash = access_hash };
	}

	partial class JsonObjectValue { public override string ToString() => $"{HttpUtility.JavaScriptStringEncode(key, true)}:{value}"; }
	partial class JsonNull { public override string ToString() => "null"; }
	partial class JsonBool { public override string ToString() => value ? "true" : "false"; }
	partial class JsonNumber { public override string ToString() => value.ToString(CultureInfo.InvariantCulture); }
	partial class JsonString { public override string ToString() => HttpUtility.JavaScriptStringEncode(value, true); }
	partial class JsonArray
	{
		public override string ToString()
		{
			var sb = new StringBuilder().Append('[');
			for (int i = 0; i < value.Length; i++)
				sb.Append(i == 0 ? "" : ",").Append(value[i]);
			return sb.Append(']').ToString();
		}
	}
	partial class JsonObject
	{
		public override string ToString()
		{
			var sb = new StringBuilder().Append('{');
			for (int i = 0; i < value.Length; i++)
				sb.Append(i == 0 ? "" : ",").Append(value[i]);
			return sb.Append('}').ToString();
		}
	}
}
