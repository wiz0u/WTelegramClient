namespace TL
{
	partial class InputChannel { public static InputPeerChannel Empty => new(); }
	partial class InputDocument { public static InputDocumentEmpty Empty => new(); }
	partial class InputPeer { public static InputPeerEmpty Empty => new(); }
	partial class InputPhoto { public static InputPhotoEmpty Empty => new(); }
	partial class InputEncryptedFile { public static InputEncryptedFileEmpty Empty => new(); }
	partial class InputStickerSet { public static InputStickerSetEmpty Empty => new(); }
	partial class InputUser { public static InputUserEmpty Empty => new(); }
	partial class InputUser { public static InputUserSelf Self => new(); }

	partial class ChatBase
	{
		public abstract int ID { get; }
		public abstract string Title { get; }
		/// <summary>returns true if you're banned of any of these rights</summary>
		public abstract bool IsBanned(ChatBannedRights.Flags flags = 0);
		protected abstract InputPeer ToInputPeer();
		public static implicit operator InputPeer(ChatBase chat) => chat.ToInputPeer();
	}
	partial class ChatEmpty
	{
		public override int ID => id;
		public override string Title => null;
		public override bool IsBanned(ChatBannedRights.Flags flags = 0) => true;
		protected override InputPeer ToInputPeer() => InputPeer.Empty;
	}
	partial class Chat
	{
		public override int ID => id;
		public override string Title => title;
		public override bool IsBanned(ChatBannedRights.Flags flags = 0) => ((default_banned_rights?.flags ?? 0) & flags) != 0;
		protected override InputPeer ToInputPeer() => new InputPeerChat { chat_id = id };
	}
	partial class ChatForbidden
	{
		public override int ID => id;
		public override string Title => title;
		public override bool IsBanned(ChatBannedRights.Flags flags = 0) => true;
		protected override InputPeer ToInputPeer() => new InputPeerChat { chat_id = id };
	}
	partial class Channel
	{
		public override int ID => id;
		public override string Title => title;
		public override bool IsBanned(ChatBannedRights.Flags flags = 0) => ((banned_rights?.flags ?? 0) & flags) != 0 || ((default_banned_rights?.flags ?? 0) & flags) != 0;
		protected override InputPeer ToInputPeer() => new InputPeerChannel { channel_id = id, access_hash = access_hash };
		public static implicit operator InputChannel(Channel channel) => new() { channel_id = channel.id, access_hash = channel.access_hash };
	}
	partial class ChannelForbidden
	{
		public override int ID => id;
		public override string Title => title;
		public override bool IsBanned(ChatBannedRights.Flags flags = 0) => true;
		protected override InputPeer ToInputPeer() => new InputPeerChannel { channel_id = id, access_hash = access_hash };
	}

	partial class UserBase
	{
		public abstract int ID { get; }
		public abstract string DisplayName { get; }
		protected abstract InputPeer ToInputPeer();
		protected abstract InputUserBase ToInputUser();
		public static implicit operator InputPeer(UserBase user) => user.ToInputPeer();
		public static implicit operator InputUserBase(UserBase user) => user.ToInputUser();
	}
	partial class UserEmpty
	{
		public override int ID => id;
		public override string DisplayName => null;
		protected override InputPeer ToInputPeer() => InputPeer.Empty;
		protected override InputUserBase ToInputUser() => InputUser.Empty;
	}
	partial class User
	{
		public override int ID => id;
		public override string DisplayName => username != null ? '@' + username : last_name == null ? first_name : $"{first_name} {last_name}";
		protected override InputPeer ToInputPeer() => new InputPeerUser { user_id = id, access_hash = access_hash };
		protected override InputUserBase ToInputUser() => new InputUser { user_id = id, access_hash = access_hash };
	}

	partial class PhotoBase
	{
		public abstract long ID { get; }
		protected abstract InputPhotoBase ToInputPhoto();
		public static implicit operator InputPhotoBase(PhotoBase photo) => photo.ToInputPhoto();
	}
	partial class PhotoEmpty
	{
		public override long ID => id;
		protected override InputPhotoBase ToInputPhoto() => InputPhoto.Empty;
	}
	partial class Photo
	{
		public override long ID => id;
		protected override InputPhotoBase ToInputPhoto() => new InputPhoto() { id = id, access_hash = access_hash, file_reference = file_reference };
		public InputPhotoFileLocation ToFileLocation(PhotoSizeBase photoSize) => new() { id = id, access_hash = access_hash, file_reference = file_reference, thumb_size = photoSize.Type };
	}

	partial class PhotoSizeBase { public abstract string Type { get; } }
	partial class PhotoSizeEmpty { public override string Type => type; }
	partial class PhotoSize { public override string Type => type; }
	partial class PhotoCachedSize { public override string Type => type; }
	partial class PhotoStrippedSize { public override string Type => type; }
	partial class PhotoSizeProgressive { public override string Type => type; }
	partial class PhotoPathSize { public override string Type => type; }

	partial class DocumentBase
	{
		public abstract long ID { get; }
		protected abstract InputDocumentBase ToInputDocument();
		public static implicit operator InputDocumentBase(DocumentBase document) => document.ToInputDocument();
	}
	partial class DocumentEmpty
	{
		public override long ID => id;
		protected override InputDocumentBase ToInputDocument() => InputDocument.Empty;
	}
	partial class Document
	{
		public override long ID => id;
		protected override InputDocumentBase ToInputDocument() => new InputDocument() { id = id, access_hash = access_hash, file_reference = file_reference };
		public InputDocumentFileLocation ToFileLocation(PhotoSizeBase photoSize) => new() { id = id, access_hash = access_hash, file_reference = file_reference, thumb_size = photoSize.Type };
	}

	partial class EncryptedFileBase
	{
		protected abstract InputEncryptedFileBase ToInputEncryptedFile();
		public static implicit operator InputEncryptedFileBase(EncryptedFileBase file) => file.ToInputEncryptedFile();
	}
	partial class EncryptedFileEmpty
	{
		protected override InputEncryptedFileBase ToInputEncryptedFile() => InputEncryptedFile.Empty;
	}
	partial class EncryptedFile
	{
		protected override InputEncryptedFileBase ToInputEncryptedFile() => new InputEncryptedFile { id = id, access_hash = access_hash };
		public InputEncryptedFileLocation ToFileLocation() => new() { id = id, access_hash = access_hash };
	}

	partial class SecureFile
	{
		public static implicit operator InputSecureFile(SecureFile file) => new() { id = file.id, access_hash = file.access_hash };
		public InputSecureFileLocation ToFileLocation() => new() { id = id, access_hash = access_hash };
	}

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

	partial class StickerSet
	{
		public static implicit operator InputStickerSetID(StickerSet stickerSet) => new() { id = stickerSet.id, access_hash = stickerSet.access_hash };
	}

	partial class Peer { public abstract int ID { get; }  }
	partial class PeerUser { public override int ID => user_id; }
	partial class PeerChat { public override int ID => chat_id; }
	partial class PeerChannel { public override int ID => channel_id; }
}
