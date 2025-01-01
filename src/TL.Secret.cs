using System;

namespace TL
{
	#pragma warning disable IDE1006, CS1574
	/// <summary>Object describes the contents of an encrypted message.		<para>See <a href="https://corefork.telegram.org/type/DecryptedMessage"/></para></summary>
	public abstract partial class DecryptedMessageBase : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a> (added in layer 45)</summary>
		public virtual uint FFlags => default;
		/// <summary>Random message ID, assigned by the author of message.<br/>Must be equal to the ID passed to sending method.</summary>
		public virtual long RandomId => default;
		/// <summary>Message lifetime. Has higher priority than <see cref="Layer8.DecryptedMessageActionSetMessageTTL"/>.<br/>Parameter added in Layer 17.</summary>
		public virtual int Ttl => default;
		/// <summary>Message text</summary>
		public virtual string Message => default;
		/// <summary>Media content</summary>
		public virtual DecryptedMessageMedia Media => default;
		/// <summary>Message <a href="https://corefork.telegram.org/api/entities">entities</a> for styled text (parameter added in layer 45)</summary>
		public virtual MessageEntity[] Entities => default;
		/// <summary>Specifies the ID of the inline bot that generated the message (parameter added in layer 45)</summary>
		public virtual string ViaBotName => default;
		/// <summary>Random message ID of the message this message replies to (parameter added in layer 45)</summary>
		public virtual long ReplyToRandom => default;
		/// <summary>Random group ID, assigned by the author of message.<br/>Multiple encrypted messages with a photo attached and with the same group ID indicate an <a href="https://corefork.telegram.org/api/files#albums-grouped-media">album or grouped media</a> (parameter added in layer 45)</summary>
		public virtual long Grouped => default;
		public virtual byte[] RandomBytes => default;
		public virtual DecryptedMessageAction Action => default;
	}

	/// <summary>Object describes media contents of an encrypted message.		<para>See <a href="https://corefork.telegram.org/type/DecryptedMessageMedia"/></para></summary>
	/// <remarks>a <see langword="null"/> value means <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaEmpty">decryptedMessageMediaEmpty</a></remarks>
	public abstract partial class DecryptedMessageMedia : IObject
	{
		public virtual string MimeType => default;
		internal virtual (long size, byte[] key, byte[] iv) SizeKeyIV { get => default; set => throw new WTelegram.WTException("Incompatible DecryptedMessageMedia"); }
	}

	/// <summary>Object describes the action to which a service message is linked.		<para>See <a href="https://corefork.telegram.org/type/DecryptedMessageAction"/></para></summary>
	public abstract partial class DecryptedMessageAction : IObject { }

	/// <summary>Indicates the location of a photo, will be deprecated soon		<para>See <a href="https://corefork.telegram.org/type/FileLocation"/></para></summary>
	public abstract partial class FileLocationBase : IObject
	{
		public virtual long VolumeId => default;
		public virtual int LocalId => default;
		public virtual long Secret => default;
	}

	namespace Layer8
	{
		/// <summary>Contents of an encrypted message.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessage"/></para></summary>
		[TLDef(0x1F814F1F)]
		public sealed partial class DecryptedMessage : DecryptedMessageBase
		{
			/// <summary>Random message ID, assigned by the author of message.<br/>Must be equal to the ID passed to sending method.</summary>
			public long random_id;
			public byte[] random_bytes;
			/// <summary>Message text</summary>
			public string message;
			/// <summary>Media content</summary>
			public DecryptedMessageMedia media;

			/// <summary>Random message ID, assigned by the author of message.<br/>Must be equal to the ID passed to sending method.</summary>
			public override long RandomId => random_id;
			/// <summary>Message text</summary>
			public override string Message => message;
			/// <summary>Media content</summary>
			public override DecryptedMessageMedia Media => media;
			public override byte[] RandomBytes => random_bytes;
		}
		/// <summary>Contents of an encrypted service message.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageService"/></para></summary>
		[TLDef(0xAA48327D)]
		public sealed partial class DecryptedMessageService : DecryptedMessageBase
		{
			/// <summary>Random message ID, assigned by the message author.<br/>Must be equal to the ID passed to the sending method.</summary>
			public long random_id;
			public byte[] random_bytes;
			/// <summary>Action relevant to the service message</summary>
			public DecryptedMessageAction action;

			/// <summary>Random message ID, assigned by the message author.<br/>Must be equal to the ID passed to the sending method.</summary>
			public override long RandomId => random_id;
			public override byte[] RandomBytes => random_bytes;
			/// <summary>Action relevant to the service message</summary>
			public override DecryptedMessageAction Action => action;
		}

		/// <summary>Photo attached to an encrypted message.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaPhoto"/></para></summary>
		[TLDef(0x32798A8C)]
		public sealed partial class DecryptedMessageMediaPhoto : DecryptedMessageMedia
		{
			/// <summary>Content of thumbnail file (JPEGfile, quality 55, set in a square 90x90)</summary>
			public byte[] thumb;
			/// <summary>Thumbnail width</summary>
			public int thumb_w;
			/// <summary>Thumbnail height</summary>
			public int thumb_h;
			/// <summary>Photo width</summary>
			public int w;
			/// <summary>Photo height</summary>
			public int h;
			/// <summary>Size of the photo in bytes</summary>
			public int size;
			/// <summary>Key to decrypt an attached file with a full version</summary>
			public byte[] key;
			/// <summary>Initialization vector</summary>
			public byte[] iv;

			public override string MimeType => "image/jpeg";
			internal override (long size, byte[] key, byte[] iv) SizeKeyIV { get => (size, key, iv); set => (size, key, iv) = (checked((int)value.size), value.key, value.iv); }
		}
		/// <summary>Video attached to an encrypted message.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaVideo"/></para></summary>
		[TLDef(0x4CEE6EF3)]
		public sealed partial class DecryptedMessageMediaVideo : DecryptedMessageMedia
		{
			/// <summary>Content of thumbnail file (JPEG file, quality 55, set in a square 90x90)</summary>
			public byte[] thumb;
			/// <summary>Thumbnail width</summary>
			public int thumb_w;
			/// <summary>Thumbnail height</summary>
			public int thumb_h;
			/// <summary>Duration of video in seconds</summary>
			public int duration;
			/// <summary>Image width</summary>
			public int w;
			/// <summary>Image height</summary>
			public int h;
			/// <summary>File size</summary>
			public int size;
			/// <summary>Key to decrypt the attached video file</summary>
			public byte[] key;
			/// <summary>Initialization vector</summary>
			public byte[] iv;

			internal override (long size, byte[] key, byte[] iv) SizeKeyIV { get => (size, key, iv); set => (size, key, iv) = (checked((int)value.size), value.key, value.iv); }
		}
		/// <summary>GeoPoint attached to an encrypted message.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaGeoPoint"/></para></summary>
		[TLDef(0x35480A59)]
		public sealed partial class DecryptedMessageMediaGeoPoint : DecryptedMessageMedia
		{
			/// <summary>Latitude of point</summary>
			public double lat;
			/// <summary>Longitude of point</summary>
			public double lon;
		}
		/// <summary>Contact attached to an encrypted message.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaContact"/></para></summary>
		[TLDef(0x588A0A97)]
		public sealed partial class DecryptedMessageMediaContact : DecryptedMessageMedia
		{
			/// <summary>Phone number</summary>
			public string phone_number;
			/// <summary>Contact's first name</summary>
			public string first_name;
			/// <summary>Contact's last name</summary>
			public string last_name;
			/// <summary>Telegram User ID of signed-up contact</summary>
			public int user_id;
		}
		/// <summary>Document attached to a message in a secret chat.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaDocument"/></para></summary>
		[TLDef(0xB095434B)]
		public sealed partial class DecryptedMessageMediaDocument : DecryptedMessageMedia
		{
			/// <summary>Thumbnail-file contents (JPEG-file, quality 55, set in a 90x90 square)</summary>
			public byte[] thumb;
			/// <summary>Thumbnail width</summary>
			public int thumb_w;
			/// <summary>Thumbnail height</summary>
			public int thumb_h;
			public string file_name;
			/// <summary>File MIME-type</summary>
			public string mime_type;
			/// <summary>Document size (<see cref="int"/> on layer &lt;143, <see cref="long"/> on layer &gt;=143)</summary>
			public int size;
			/// <summary>Key to decrypt the attached document file</summary>
			public byte[] key;
			/// <summary>Initialization</summary>
			public byte[] iv;

			/// <summary>File MIME-type</summary>
			public override string MimeType => mime_type;

			internal override (long size, byte[] key, byte[] iv) SizeKeyIV { get => (size, key, iv); set => (size, key, iv) = (checked((int)value.size), value.key, value.iv); }
		}
		/// <summary>Audio file attached to a secret chat message.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaAudio"/></para></summary>
		[TLDef(0x6080758F)]
		public sealed partial class DecryptedMessageMediaAudio : DecryptedMessageMedia
		{
			/// <summary>Audio duration in seconds</summary>
			public int duration;
			/// <summary>File size</summary>
			public int size;
			/// <summary>Key to decrypt the attached media file</summary>
			public byte[] key;
			/// <summary>Initialization vector</summary>
			public byte[] iv;

			internal override (long size, byte[] key, byte[] iv) SizeKeyIV { get => (size, key, iv); set => (size, key, iv) = (checked((int)value.size), value.key, value.iv); }
		}

		/// <summary>Setting of a message lifetime after reading.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionSetMessageTTL"/></para></summary>
		[TLDef(0xA1733AEC)]
		public sealed partial class DecryptedMessageActionSetMessageTTL : DecryptedMessageAction
		{
			/// <summary>Lifetime in seconds</summary>
			public int ttl_seconds;
		}
		/// <summary>Messages marked as read.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionReadMessages"/></para></summary>
		[TLDef(0x0C4F40BE)]
		public sealed partial class DecryptedMessageActionReadMessages : DecryptedMessageAction
		{
			/// <summary>List of message IDs</summary>
			public long[] random_ids;
		}
		/// <summary>Deleted messages.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionDeleteMessages"/></para></summary>
		[TLDef(0x65614304)]
		public sealed partial class DecryptedMessageActionDeleteMessages : DecryptedMessageAction
		{
			/// <summary>List of deleted message IDs</summary>
			public long[] random_ids;
		}
		/// <summary>A screenshot was taken.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionScreenshotMessages"/></para></summary>
		[TLDef(0x8AC1F475)]
		public sealed partial class DecryptedMessageActionScreenshotMessages : DecryptedMessageAction
		{
			/// <summary>List of affected message ids (that appeared on the screenshot)</summary>
			public long[] random_ids;
		}
		/// <summary>The entire message history has been deleted.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionFlushHistory"/></para></summary>
		[TLDef(0x6719E45C)]
		public sealed partial class DecryptedMessageActionFlushHistory : DecryptedMessageAction { }
	}

	namespace Layer23
	{
		/// <summary>Image description.		<para>See <a href="https://corefork.telegram.org/constructor/photoSize"/></para></summary>
		[TLDef(0x77BFB61B)]
		public sealed partial class PhotoSize : PhotoSizeBase
		{
			/// <summary><a href="https://corefork.telegram.org/api/files#image-thumbnail-types">Thumbnail type »</a></summary>
			public string type;
			public FileLocationBase location;
			/// <summary>Image width</summary>
			public int w;
			/// <summary>Image height</summary>
			public int h;
			/// <summary>File size</summary>
			public int size;

			/// <summary><a href="https://corefork.telegram.org/api/files#image-thumbnail-types">Thumbnail type »</a></summary>
			public override string Type => type;
		}
		/// <summary>Description of an image and its content.		<para>See <a href="https://corefork.telegram.org/constructor/photoCachedSize"/></para></summary>
		[TLDef(0xE9A734FA)]
		public sealed partial class PhotoCachedSize : PhotoSizeBase
		{
			/// <summary>Thumbnail type</summary>
			public string type;
			public FileLocationBase location;
			/// <summary>Image width</summary>
			public int w;
			/// <summary>Image height</summary>
			public int h;
			/// <summary>Binary data, file content</summary>
			public byte[] bytes;

			/// <summary>Thumbnail type</summary>
			public override string Type => type;
		}

		/// <summary>User is uploading a video.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageUploadVideoAction"/></para></summary>
		[TLDef(0x92042FF7)]
		public sealed partial class SendMessageUploadVideoAction : SendMessageAction { }
		/// <summary>User is uploading a voice message.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageUploadAudioAction"/></para></summary>
		[TLDef(0xE6AC8A6F)]
		public sealed partial class SendMessageUploadAudioAction : SendMessageAction { }
		/// <summary>User is uploading a photo.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageUploadPhotoAction"/></para></summary>
		[TLDef(0x990A3C1A)]
		public sealed partial class SendMessageUploadPhotoAction : SendMessageAction { }
		/// <summary>User is uploading a file.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageUploadDocumentAction"/></para></summary>
		[TLDef(0x8FAEE98E)]
		public sealed partial class SendMessageUploadDocumentAction : SendMessageAction { }

		/// <summary>Defines a sticker		<para>See <a href="https://corefork.telegram.org/constructor/documentAttributeSticker"/></para></summary>
		[TLDef(0xFB0A5727)]
		public sealed partial class DocumentAttributeSticker : DocumentAttribute { }
		/// <summary>Defines a video		<para>See <a href="https://corefork.telegram.org/constructor/documentAttributeVideo"/></para></summary>
		[TLDef(0x5910CCCB)]
		public sealed partial class DocumentAttributeVideo : DocumentAttribute
		{
			/// <summary>Duration in seconds</summary>
			public int duration;
			/// <summary>Video width</summary>
			public int w;
			/// <summary>Video height</summary>
			public int h;
		}
		/// <summary>Represents an audio file		<para>See <a href="https://corefork.telegram.org/constructor/documentAttributeAudio"/></para></summary>
		[TLDef(0x051448E5)]
		public sealed partial class DocumentAttributeAudio : DocumentAttribute
		{
			/// <summary>Duration in seconds</summary>
			public int duration;
		}

		/// <summary>Contents of an encrypted message.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessage"/></para></summary>
		[TLDef(0x204D3878)]
		public sealed partial class DecryptedMessage : DecryptedMessageBase
		{
			/// <summary>Random message ID, assigned by the author of message.<br/>Must be equal to the ID passed to sending method.</summary>
			public long random_id;
			/// <summary>Message lifetime. Has higher priority than <see cref="Layer8.DecryptedMessageActionSetMessageTTL"/>.<br/>Parameter added in Layer 17.</summary>
			public int ttl;
			/// <summary>Message text</summary>
			public string message;
			/// <summary>Media content</summary>
			public DecryptedMessageMedia media;

			/// <summary>Random message ID, assigned by the author of message.<br/>Must be equal to the ID passed to sending method.</summary>
			public override long RandomId => random_id;
			/// <summary>Message lifetime. Has higher priority than <see cref="Layer8.DecryptedMessageActionSetMessageTTL"/>.<br/>Parameter added in Layer 17.</summary>
			public override int Ttl => ttl;
			/// <summary>Message text</summary>
			public override string Message => message;
			/// <summary>Media content</summary>
			public override DecryptedMessageMedia Media => media;
		}
		/// <summary>Contents of an encrypted service message.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageService"/></para></summary>
		[TLDef(0x73164160)]
		public sealed partial class DecryptedMessageService : DecryptedMessageBase
		{
			/// <summary>Random message ID, assigned by the message author.<br/>Must be equal to the ID passed to the sending method.</summary>
			public long random_id;
			/// <summary>Action relevant to the service message</summary>
			public DecryptedMessageAction action;

			/// <summary>Random message ID, assigned by the message author.<br/>Must be equal to the ID passed to the sending method.</summary>
			public override long RandomId => random_id;
			/// <summary>Action relevant to the service message</summary>
			public override DecryptedMessageAction Action => action;
		}

		/// <summary>Video attached to an encrypted message.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaVideo"/></para></summary>
		[TLDef(0x524A415D)]
		public sealed partial class DecryptedMessageMediaVideo : DecryptedMessageMedia
		{
			/// <summary>Content of thumbnail file (JPEG file, quality 55, set in a square 90x90)</summary>
			public byte[] thumb;
			/// <summary>Thumbnail width</summary>
			public int thumb_w;
			/// <summary>Thumbnail height</summary>
			public int thumb_h;
			/// <summary>Duration of video in seconds</summary>
			public int duration;
			/// <summary>MIME-type of the video file<br/>Parameter added in Layer 17.</summary>
			public string mime_type;
			/// <summary>Image width</summary>
			public int w;
			/// <summary>Image height</summary>
			public int h;
			/// <summary>File size</summary>
			public int size;
			/// <summary>Key to decrypt the attached video file</summary>
			public byte[] key;
			/// <summary>Initialization vector</summary>
			public byte[] iv;

			/// <summary>MIME-type of the video file<br/>Parameter added in Layer 17.</summary>
			public override string MimeType => mime_type;

			internal override (long size, byte[] key, byte[] iv) SizeKeyIV { get => (size, key, iv); set => (size, key, iv) = (checked((int)value.size), value.key, value.iv); }
		}
		/// <summary>Audio file attached to a secret chat message.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaAudio"/></para></summary>
		[TLDef(0x57E0A9CB)]
		public sealed partial class DecryptedMessageMediaAudio : DecryptedMessageMedia
		{
			/// <summary>Audio duration in seconds</summary>
			public int duration;
			/// <summary>MIME-type of the audio file<br/>Parameter added in Layer 13.</summary>
			public string mime_type;
			/// <summary>File size</summary>
			public int size;
			/// <summary>Key to decrypt the attached media file</summary>
			public byte[] key;
			/// <summary>Initialization vector</summary>
			public byte[] iv;

			/// <summary>MIME-type of the audio file<br/>Parameter added in Layer 13.</summary>
			public override string MimeType => mime_type;

			internal override (long size, byte[] key, byte[] iv) SizeKeyIV { get => (size, key, iv); set => (size, key, iv) = (checked((int)value.size), value.key, value.iv); }
		}
		/// <summary>Non-e2e documented forwarded from non-secret chat		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaExternalDocument"/></para></summary>
		[TLDef(0xFA95B0DD)]
		public sealed partial class DecryptedMessageMediaExternalDocument : DecryptedMessageMedia
		{
			/// <summary>Document ID</summary>
			public long id;
			/// <summary>access hash</summary>
			public long access_hash;
			/// <summary>Date</summary>
			public DateTime date;
			/// <summary>Mime type</summary>
			public string mime_type;
			/// <summary>Size</summary>
			public int size;
			/// <summary>Thumbnail</summary>
			public PhotoSizeBase thumb;
			/// <summary>DC ID</summary>
			public int dc_id;
			/// <summary>Attributes for media types</summary>
			public DocumentAttribute[] attributes;

			/// <summary>Mime type</summary>
			public override string MimeType => mime_type;
		}

		/// <summary>Request for the other party in a Secret Chat to automatically resend a contiguous range of previously sent messages, as explained in <a href="https://corefork.telegram.org/api/end-to-end/seq_no">Sequence number is Secret Chats</a>.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionResend"/></para></summary>
		[TLDef(0x511110B0)]
		public sealed partial class DecryptedMessageActionResend : DecryptedMessageAction
		{
			/// <summary><c>out_seq_no</c> of the first message to be resent, with correct parity</summary>
			public int start_seq_no;
			/// <summary><c>out_seq_no</c> of the last message to be resent, with same parity.</summary>
			public int end_seq_no;
		}
		/// <summary>A notification stating the API layer that is used by the client. You should use your current layer and take notice of the layer used on the other side of a conversation when sending messages.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionNotifyLayer"/></para></summary>
		[TLDef(0xF3048883)]
		public sealed partial class DecryptedMessageActionNotifyLayer : DecryptedMessageAction
		{
			/// <summary>Layer number, must be <strong>17</strong> or higher (this constructor was introduced in Layer 17.</summary>
			public int layer;
		}
		/// <summary>User is preparing a message: typing, recording, uploading, etc.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionTyping"/></para></summary>
		[TLDef(0xCCB27641)]
		public sealed partial class DecryptedMessageActionTyping : DecryptedMessageAction
		{
			/// <summary>Type of action</summary>
			public SendMessageAction action;
		}
		/// <summary>Request rekeying, see <a href="https://corefork.telegram.org/api/end-to-end/pfs">rekeying process</a>		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionRequestKey"/></para></summary>
		[TLDef(0xF3C9611B)]
		public sealed partial class DecryptedMessageActionRequestKey : DecryptedMessageAction
		{
			/// <summary>Exchange ID</summary>
			public long exchange_id;
			/// <summary>g_a, see <a href="https://corefork.telegram.org/api/end-to-end/pfs">rekeying process</a></summary>
			public byte[] g_a;
		}
		/// <summary>Accept new key		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionAcceptKey"/></para></summary>
		[TLDef(0x6FE1735B)]
		public sealed partial class DecryptedMessageActionAcceptKey : DecryptedMessageAction
		{
			/// <summary>Exchange ID</summary>
			public long exchange_id;
			/// <summary>B parameter, see <a href="https://corefork.telegram.org/api/end-to-end/pfs">rekeying process</a></summary>
			public byte[] g_b;
			/// <summary>Key fingerprint, see <a href="https://corefork.telegram.org/api/end-to-end/pfs">rekeying process</a></summary>
			public long key_fingerprint;
		}
		/// <summary>Abort rekeying		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionAbortKey"/></para></summary>
		[TLDef(0xDD05EC6B)]
		public sealed partial class DecryptedMessageActionAbortKey : DecryptedMessageAction
		{
			/// <summary>Exchange ID</summary>
			public long exchange_id;
		}
		/// <summary>Commit new key, see <a href="https://corefork.telegram.org/api/end-to-end/pfs">rekeying process</a>		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionCommitKey"/></para></summary>
		[TLDef(0xEC2E0B9B)]
		public sealed partial class DecryptedMessageActionCommitKey : DecryptedMessageAction
		{
			/// <summary>Exchange ID, see <a href="https://corefork.telegram.org/api/end-to-end/pfs">rekeying process</a></summary>
			public long exchange_id;
			/// <summary>Key fingerprint, see <a href="https://corefork.telegram.org/api/end-to-end/pfs">rekeying process</a></summary>
			public long key_fingerprint;
		}
		/// <summary>NOOP action		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionNoop"/></para></summary>
		[TLDef(0xA82FDD63)]
		public sealed partial class DecryptedMessageActionNoop : DecryptedMessageAction { }

		/// <summary>Sets the layer number for the contents of an encrypted message.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageLayer"/></para></summary>
		[TLDef(0x1BE31789)]
		public sealed partial class DecryptedMessageLayer : IObject
		{
			/// <summary>Set of random bytes to prevent content recognition in short encrypted messages.<br/>Clients are required to check that there are at least 15 random bytes included in each message. Messages with less than 15 random bytes must be ignored.<br/>Parameter moved here from <see cref="DecryptedMessage"/> in Layer 17.</summary>
			public byte[] random_bytes;
			/// <summary>Layer number. Mimimal value - <strong>17</strong> (the layer in which the constructor was added).</summary>
			public int layer;
			/// <summary>2x the number of messages in the sender's inbox (including deleted and service messages), incremented by 1 if current user was not the chat creator<br/>Parameter added in Layer 17.</summary>
			public int in_seq_no;
			/// <summary>2x the number of messages in the recipient's inbox (including deleted and service messages), incremented by 1 if current user was the chat creator<br/>Parameter added in Layer 17.</summary>
			public int out_seq_no;
			/// <summary>The content of message itself</summary>
			public DecryptedMessageBase message;
		}

		/// <summary>File is currently unavailable.		<para>See <a href="https://corefork.telegram.org/constructor/fileLocationUnavailable"/></para></summary>
		[TLDef(0x7C596B46)]
		public sealed partial class FileLocationUnavailable : FileLocationBase
		{
			public long volume_id;
			public int local_id;
			public long secret;

			public override long VolumeId => volume_id;
			public override int LocalId => local_id;
			public override long Secret => secret;
		}
		/// <summary>File location.		<para>See <a href="https://corefork.telegram.org/constructor/fileLocation"/></para></summary>
		[TLDef(0x53D69076)]
		public sealed partial class FileLocation : FileLocationBase
		{
			public int dc_id;
			public long volume_id;
			public int local_id;
			public long secret;

			public override long VolumeId => volume_id;
			public override int LocalId => local_id;
			public override long Secret => secret;
		}
	}

	namespace Layer45
	{
		/// <summary>Represents an audio file		<para>See <a href="https://corefork.telegram.org/constructor/documentAttributeAudio"/></para></summary>
		[TLDef(0xDED218E0)]
		public sealed partial class DocumentAttributeAudio : DocumentAttribute
		{
			/// <summary>Duration in seconds</summary>
			public int duration;
			/// <summary>Name of song</summary>
			public string title;
			/// <summary>Performer</summary>
			public string performer;
		}
	}

	namespace Layer46
	{
		/// <summary>Defines a sticker		<para>See <a href="https://corefork.telegram.org/constructor/documentAttributeSticker"/></para></summary>
		[TLDef(0x3A556302)]
		public sealed partial class DocumentAttributeSticker : DocumentAttribute
		{
			/// <summary>Alternative emoji representation of sticker</summary>
			public string alt;
			/// <summary>Associated stickerset</summary>
			public InputStickerSet stickerset;
		}

		/// <summary>Message entity representing a <a href="https://corefork.telegram.org/api/mentions">user mention</a>: for <em>creating</em> a mention use <see cref="InputMessageEntityMentionName"/>.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityMentionName"/></para></summary>
		[TLDef(0x352DCA58, inheritBefore = true)]
		public sealed partial class MessageEntityMentionName : MessageEntity
		{
			/// <summary>Identifier of the user that was mentioned</summary>
			public int user_id;
		}

		/// <summary>Contents of an encrypted message.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessage"/></para></summary>
		[TLDef(0x36B091DE)]
		public sealed partial class DecryptedMessage : DecryptedMessageBase
		{
			/// <summary>Extra bits of information, use <c>flags.HasFlag(...)</c> to test for those</summary>
			public Flags flags;
			/// <summary>Random message ID, assigned by the author of message.<br/>Must be equal to the ID passed to sending method.</summary>
			public long random_id;
			/// <summary>Message lifetime. Has higher priority than <see cref="Layer8.DecryptedMessageActionSetMessageTTL"/>.<br/>Parameter added in Layer 17.</summary>
			public int ttl;
			/// <summary>Message text</summary>
			public string message;
			/// <summary>Media content</summary>
			[IfFlag(9)] public DecryptedMessageMedia media;
			/// <summary>Message <a href="https://corefork.telegram.org/api/entities">entities</a> for styled text (parameter added in layer 45)</summary>
			[IfFlag(7)] public MessageEntity[] entities;
			/// <summary>Specifies the ID of the inline bot that generated the message (parameter added in layer 45)</summary>
			[IfFlag(11)] public string via_bot_name;
			/// <summary>Random message ID of the message this message replies to (parameter added in layer 45)</summary>
			[IfFlag(3)] public long reply_to_random_id;

			[Flags] public enum Flags : uint
			{
				/// <summary>Field <see cref="reply_to_random_id"/> has a value</summary>
				has_reply_to_random_id = 0x8,
				/// <summary>Field <see cref="entities"/> has a value</summary>
				has_entities = 0x80,
				/// <summary>Field <see cref="media"/> has a value</summary>
				has_media = 0x200,
				/// <summary>Field <see cref="via_bot_name"/> has a value</summary>
				has_via_bot_name = 0x800,
			}

			/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a> (added in layer 45)</summary>
			public override uint FFlags => (uint)flags;
			/// <summary>Random message ID, assigned by the author of message.<br/>Must be equal to the ID passed to sending method.</summary>
			public override long RandomId => random_id;
			/// <summary>Message lifetime. Has higher priority than <see cref="Layer8.DecryptedMessageActionSetMessageTTL"/>.<br/>Parameter added in Layer 17.</summary>
			public override int Ttl => ttl;
			/// <summary>Message text</summary>
			public override string Message => message;
			/// <summary>Media content</summary>
			public override DecryptedMessageMedia Media => media;
			/// <summary>Message <a href="https://corefork.telegram.org/api/entities">entities</a> for styled text (parameter added in layer 45)</summary>
			public override MessageEntity[] Entities => entities;
			/// <summary>Specifies the ID of the inline bot that generated the message (parameter added in layer 45)</summary>
			public override string ViaBotName => via_bot_name;
			/// <summary>Random message ID of the message this message replies to (parameter added in layer 45)</summary>
			public override long ReplyToRandom => reply_to_random_id;
		}

		/// <summary>Photo attached to an encrypted message.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaPhoto"/></para></summary>
		[TLDef(0xF1FA8D78)]
		public sealed partial class DecryptedMessageMediaPhoto : DecryptedMessageMedia
		{
			/// <summary>Content of thumbnail file (JPEGfile, quality 55, set in a square 90x90)</summary>
			public byte[] thumb;
			/// <summary>Thumbnail width</summary>
			public int thumb_w;
			/// <summary>Thumbnail height</summary>
			public int thumb_h;
			/// <summary>Photo width</summary>
			public int w;
			/// <summary>Photo height</summary>
			public int h;
			/// <summary>Size of the photo in bytes</summary>
			public int size;
			/// <summary>Key to decrypt an attached file with a full version</summary>
			public byte[] key;
			/// <summary>Initialization vector</summary>
			public byte[] iv;
			/// <summary>Caption</summary>
			public string caption;

			public override string MimeType => "image/jpeg";
			internal override (long size, byte[] key, byte[] iv) SizeKeyIV { get => (size, key, iv); set => (size, key, iv) = (checked((int)value.size), value.key, value.iv); }
		}
		/// <summary>Video attached to an encrypted message.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaVideo"/></para></summary>
		[TLDef(0x970C8C0E)]
		public sealed partial class DecryptedMessageMediaVideo : DecryptedMessageMedia
		{
			/// <summary>Content of thumbnail file (JPEG file, quality 55, set in a square 90x90)</summary>
			public byte[] thumb;
			/// <summary>Thumbnail width</summary>
			public int thumb_w;
			/// <summary>Thumbnail height</summary>
			public int thumb_h;
			/// <summary>Duration of video in seconds</summary>
			public int duration;
			/// <summary>MIME-type of the video file<br/>Parameter added in Layer 17.</summary>
			public string mime_type;
			/// <summary>Image width</summary>
			public int w;
			/// <summary>Image height</summary>
			public int h;
			/// <summary>File size</summary>
			public int size;
			/// <summary>Key to decrypt the attached video file</summary>
			public byte[] key;
			/// <summary>Initialization vector</summary>
			public byte[] iv;
			/// <summary>Caption</summary>
			public string caption;

			/// <summary>MIME-type of the video file<br/>Parameter added in Layer 17.</summary>
			public override string MimeType => mime_type;

			internal override (long size, byte[] key, byte[] iv) SizeKeyIV { get => (size, key, iv); set => (size, key, iv) = (checked((int)value.size), value.key, value.iv); }
		}
		/// <summary>Document attached to a message in a secret chat.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaDocument"/></para></summary>
		[TLDef(0x7AFE8AE2)]
		public sealed partial class DecryptedMessageMediaDocument : DecryptedMessageMedia
		{
			/// <summary>Thumbnail-file contents (JPEG-file, quality 55, set in a 90x90 square)</summary>
			public byte[] thumb;
			/// <summary>Thumbnail width</summary>
			public int thumb_w;
			/// <summary>Thumbnail height</summary>
			public int thumb_h;
			/// <summary>File MIME-type</summary>
			public string mime_type;
			/// <summary>Document size (<see cref="int"/> on layer &lt;143, <see cref="long"/> on layer &gt;=143)</summary>
			public int size;
			/// <summary>Key to decrypt the attached document file</summary>
			public byte[] key;
			/// <summary>Initialization</summary>
			public byte[] iv;
			/// <summary>Document attributes for media types</summary>
			public DocumentAttribute[] attributes;
			/// <summary>Caption</summary>
			public string caption;

			/// <summary>File MIME-type</summary>
			public override string MimeType => mime_type;

			internal override (long size, byte[] key, byte[] iv) SizeKeyIV { get => (size, key, iv); set => (size, key, iv) = (checked((int)value.size), value.key, value.iv); }
		}
		/// <summary>Venue		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaVenue"/></para></summary>
		[TLDef(0x8A0DF56F)]
		public sealed partial class DecryptedMessageMediaVenue : DecryptedMessageMedia
		{
			/// <summary>Latitude of venue</summary>
			public double lat;
			/// <summary>Longitude of venue</summary>
			public double lon;
			/// <summary>Venue name</summary>
			public string title;
			/// <summary>Address</summary>
			public string address;
			/// <summary>Venue provider: currently only "foursquare" and "gplaces" (Google Places) need to be supported</summary>
			public string provider;
			/// <summary>Venue ID in the provider's database</summary>
			public string venue_id;
		}
		/// <summary>Webpage preview		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaWebPage"/></para></summary>
		[TLDef(0xE50511D8)]
		public sealed partial class DecryptedMessageMediaWebPage : DecryptedMessageMedia
		{
			/// <summary>URL of webpage</summary>
			public string url;
		}
	}

	namespace Layer66
	{
		/// <summary>User is uploading a round video		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageUploadRoundAction"/></para></summary>
		[TLDef(0xBB718624)]
		public sealed partial class SendMessageUploadRoundAction : SendMessageAction { }

		/// <summary>Defines a video		<para>See <a href="https://corefork.telegram.org/constructor/documentAttributeVideo"/></para></summary>
		[TLDef(0x0EF02CE6)]
		public sealed partial class DocumentAttributeVideo : DocumentAttribute
		{
			/// <summary>Extra bits of information, use <c>flags.HasFlag(...)</c> to test for those</summary>
			public Flags flags;
			/// <summary>Duration in seconds</summary>
			public int duration;
			/// <summary>Video width</summary>
			public int w;
			/// <summary>Video height</summary>
			public int h;

			[Flags] public enum Flags : uint
			{
				/// <summary>Whether this is a round video</summary>
				round_message = 0x1,
			}
		}
	}

	namespace Layer73
	{
		/// <summary>Contents of an encrypted message.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessage"/></para></summary>
		[TLDef(0x91CC4674)]
		public sealed partial class DecryptedMessage : DecryptedMessageBase
		{
			/// <summary>Extra bits of information, use <c>flags.HasFlag(...)</c> to test for those</summary>
			public Flags flags;
			/// <summary>Random message ID, assigned by the author of message.<br/>Must be equal to the ID passed to sending method.</summary>
			public long random_id;
			/// <summary>Message lifetime. Has higher priority than <see cref="Layer8.DecryptedMessageActionSetMessageTTL"/>.<br/>Parameter added in Layer 17.</summary>
			public int ttl;
			/// <summary>Message text</summary>
			public string message;
			/// <summary>Media content</summary>
			[IfFlag(9)] public DecryptedMessageMedia media;
			/// <summary>Message <a href="https://corefork.telegram.org/api/entities">entities</a> for styled text (parameter added in layer 45)</summary>
			[IfFlag(7)] public MessageEntity[] entities;
			/// <summary>Specifies the ID of the inline bot that generated the message (parameter added in layer 45)</summary>
			[IfFlag(11)] public string via_bot_name;
			/// <summary>Random message ID of the message this message replies to (parameter added in layer 45)</summary>
			[IfFlag(3)] public long reply_to_random_id;
			/// <summary>Random group ID, assigned by the author of message.<br/>Multiple encrypted messages with a photo attached and with the same group ID indicate an <a href="https://corefork.telegram.org/api/files#albums-grouped-media">album or grouped media</a> (parameter added in layer 45)</summary>
			[IfFlag(17)] public long grouped_id;

			[Flags] public enum Flags : uint
			{
				/// <summary>Field <see cref="reply_to_random_id"/> has a value</summary>
				has_reply_to_random_id = 0x8,
				/// <summary>Whether this is a silent message (no notification triggered)</summary>
				silent = 0x20,
				/// <summary>Field <see cref="entities"/> has a value</summary>
				has_entities = 0x80,
				/// <summary>Field <see cref="media"/> has a value</summary>
				has_media = 0x200,
				/// <summary>Field <see cref="via_bot_name"/> has a value</summary>
				has_via_bot_name = 0x800,
				/// <summary>Field <see cref="grouped_id"/> has a value</summary>
				has_grouped_id = 0x20000,
			}

			/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a> (added in layer 45)</summary>
			public override uint FFlags => (uint)flags;
			/// <summary>Random message ID, assigned by the author of message.<br/>Must be equal to the ID passed to sending method.</summary>
			public override long RandomId => random_id;
			/// <summary>Message lifetime. Has higher priority than <see cref="Layer8.DecryptedMessageActionSetMessageTTL"/>.<br/>Parameter added in Layer 17.</summary>
			public override int Ttl => ttl;
			/// <summary>Message text</summary>
			public override string Message => message;
			/// <summary>Media content</summary>
			public override DecryptedMessageMedia Media => media;
			/// <summary>Message <a href="https://corefork.telegram.org/api/entities">entities</a> for styled text (parameter added in layer 45)</summary>
			public override MessageEntity[] Entities => entities;
			/// <summary>Specifies the ID of the inline bot that generated the message (parameter added in layer 45)</summary>
			public override string ViaBotName => via_bot_name;
			/// <summary>Random message ID of the message this message replies to (parameter added in layer 45)</summary>
			public override long ReplyToRandom => reply_to_random_id;
			/// <summary>Random group ID, assigned by the author of message.<br/>Multiple encrypted messages with a photo attached and with the same group ID indicate an <a href="https://corefork.telegram.org/api/files#albums-grouped-media">album or grouped media</a> (parameter added in layer 45)</summary>
			public override long Grouped => grouped_id;
		}
	}

	namespace Layer101
	{
		/// <summary>Message entity representing a block quote.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityBlockquote"/></para></summary>
		[TLDef(0x020DF5D0)]
		public sealed partial class MessageEntityBlockquote : MessageEntity { }
	}

	namespace Layer143
	{
		/// <summary>Document attached to a message in a secret chat.		<para>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaDocument"/></para></summary>
		[TLDef(0x6ABD9782)]
		public sealed partial class DecryptedMessageMediaDocument : DecryptedMessageMedia
		{
			/// <summary>Thumbnail-file contents (JPEG-file, quality 55, set in a 90x90 square)</summary>
			public byte[] thumb;
			/// <summary>Thumbnail width</summary>
			public int thumb_w;
			/// <summary>Thumbnail height</summary>
			public int thumb_h;
			/// <summary>File MIME-type</summary>
			public string mime_type;
			/// <summary>Document size (<see cref="int"/> on layer &lt;143, <see cref="long"/> on layer &gt;=143)</summary>
			public long size;
			/// <summary>Key to decrypt the attached document file</summary>
			public byte[] key;
			/// <summary>Initialization</summary>
			public byte[] iv;
			/// <summary>Document attributes for media types</summary>
			public DocumentAttribute[] attributes;
			/// <summary>Caption</summary>
			public string caption;

			/// <summary>File MIME-type</summary>
			public override string MimeType => mime_type;

			internal override (long size, byte[] key, byte[] iv) SizeKeyIV { get => (size, key, iv); set => (size, key, iv) = value; }
		}
	}

	namespace Layer144
	{	}
}
