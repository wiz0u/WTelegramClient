// This file is generated automatically using the Generator class
using System;
using System.Collections.Generic;

namespace TL
{
	using BinaryWriter = System.IO.BinaryWriter;
	using Client = WTelegram.Client;

	/// <summary><br/>See <a href="https://corefork.telegram.org/type/DecryptedMessage"/></summary>
	public abstract partial class DecryptedMessageBase : ITLObject
	{
		/// <summary>Random message ID, assigned by the author of message.<br/>Must be equal to the ID passed to sending method.</summary>
		public abstract long RandomId { get; }
	}

	/// <summary>Object describes media contents of an encrypted message.		<br/>See <a href="https://corefork.telegram.org/type/DecryptedMessageMedia"/></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaEmpty">decryptedMessageMediaEmpty</a></remarks>
	public abstract partial class DecryptedMessageMedia : ITLObject { }

	/// <summary>Object describes the action to which a service message is linked.		<br/>See <a href="https://corefork.telegram.org/type/DecryptedMessageAction"/></summary>
	public abstract partial class DecryptedMessageAction : ITLObject { }

	/// <summary><br/>See <a href="https://corefork.telegram.org/type/FileLocation"/></summary>
	public abstract partial class FileLocationBase : ITLObject
	{
		/// <summary>Server volume</summary>
		public abstract long VolumeId { get; }
		/// <summary>File ID</summary>
		public abstract int LocalId { get; }
		/// <summary>Checksum to access the file</summary>
		public abstract long Secret { get; }
	}

	namespace Layer8
	{
		/// <summary>Contents of an encrypted message.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessage"/></summary>
		[TLDef(0x1F814F1F)]
		public partial class DecryptedMessage : DecryptedMessageBase
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
		}
		/// <summary>Contents of an encrypted service message.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageService"/></summary>
		[TLDef(0xAA48327D)]
		public partial class DecryptedMessageService : DecryptedMessageBase
		{
			/// <summary>Random message ID, assigned by the message author.<br/>Must be equal to the ID passed to the sending method.</summary>
			public long random_id;
			public byte[] random_bytes;
			/// <summary>Action relevant to the service message</summary>
			public DecryptedMessageAction action;

			/// <summary>Random message ID, assigned by the message author.<br/>Must be equal to the ID passed to the sending method.</summary>
			public override long RandomId => random_id;
		}

		/// <summary>Photo attached to an encrypted message.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaPhoto"/></summary>
		[TLDef(0x32798A8C)]
		public partial class DecryptedMessageMediaPhoto : DecryptedMessageMedia
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
		}
		/// <summary>Video attached to an encrypted message.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaVideo"/></summary>
		[TLDef(0x4CEE6EF3)]
		public partial class DecryptedMessageMediaVideo : DecryptedMessageMedia
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
		}
		/// <summary>GeoPont attached to an encrypted message.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaGeoPoint"/></summary>
		[TLDef(0x35480A59)]
		public partial class DecryptedMessageMediaGeoPoint : DecryptedMessageMedia
		{
			/// <summary>Latitude of point</summary>
			public double lat;
			/// <summary>Longtitude of point</summary>
			public double long_;
		}
		/// <summary>Contact attached to an encrypted message.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaContact"/></summary>
		[TLDef(0x588A0A97)]
		public partial class DecryptedMessageMediaContact : DecryptedMessageMedia
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
		/// <summary>Document attached to a message in a secret chat.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaDocument"/></summary>
		[TLDef(0xB095434B)]
		public partial class DecryptedMessageMediaDocument : DecryptedMessageMedia
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
			/// <summary>Document size</summary>
			public int size;
			/// <summary>Key to decrypt the attached document file</summary>
			public byte[] key;
			/// <summary>Initialization</summary>
			public byte[] iv;
		}
		/// <summary>Audio file attached to a secret chat message.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaAudio"/></summary>
		[TLDef(0x6080758F)]
		public partial class DecryptedMessageMediaAudio : DecryptedMessageMedia
		{
			/// <summary>Audio duration in seconds</summary>
			public int duration;
			/// <summary>File size</summary>
			public int size;
			/// <summary>Key to decrypt the attached media file</summary>
			public byte[] key;
			/// <summary>Initialization vector</summary>
			public byte[] iv;
		}

		/// <summary>Setting of a message lifetime after reading.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionSetMessageTTL"/></summary>
		[TLDef(0xA1733AEC)]
		public partial class DecryptedMessageActionSetMessageTTL : DecryptedMessageAction
		{
			/// <summary>Lifetime in seconds</summary>
			public int ttl_seconds;
		}
		/// <summary>Messages marked as read.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionReadMessages"/></summary>
		[TLDef(0x0C4F40BE)]
		public partial class DecryptedMessageActionReadMessages : DecryptedMessageAction
		{
			/// <summary>List of message IDs</summary>
			public long[] random_ids;
		}
		/// <summary>Deleted messages.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionDeleteMessages"/></summary>
		[TLDef(0x65614304)]
		public partial class DecryptedMessageActionDeleteMessages : DecryptedMessageAction
		{
			/// <summary>List of deleted message IDs</summary>
			public long[] random_ids;
		}
		/// <summary>A screenshot was taken.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionScreenshotMessages"/></summary>
		[TLDef(0x8AC1F475)]
		public partial class DecryptedMessageActionScreenshotMessages : DecryptedMessageAction
		{
			/// <summary>List of affected message ids (that appeared on the screenshot)</summary>
			public long[] random_ids;
		}
		/// <summary>The entire message history has been deleted.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionFlushHistory"/></summary>
		[TLDef(0x6719E45C)]
		public partial class DecryptedMessageActionFlushHistory : DecryptedMessageAction { }
	}

	namespace Layer17
	{
		/// <summary>User is uploading a video.		<br/>See <a href="https://corefork.telegram.org/constructor/sendMessageUploadVideoAction"/></summary>
		[TLDef(0x92042FF7)]
		public partial class SendMessageUploadVideoAction : SendMessageAction { }
		/// <summary>User is uploading a voice message.		<br/>See <a href="https://corefork.telegram.org/constructor/sendMessageUploadAudioAction"/></summary>
		[TLDef(0xE6AC8A6F)]
		public partial class SendMessageUploadAudioAction : SendMessageAction { }
		/// <summary>User is uploading a photo.		<br/>See <a href="https://corefork.telegram.org/constructor/sendMessageUploadPhotoAction"/></summary>
		[TLDef(0x990A3C1A)]
		public partial class SendMessageUploadPhotoAction : SendMessageAction { }
		/// <summary>User is uploading a file.		<br/>See <a href="https://corefork.telegram.org/constructor/sendMessageUploadDocumentAction"/></summary>
		[TLDef(0x8FAEE98E)]
		public partial class SendMessageUploadDocumentAction : SendMessageAction { }

		/// <summary>Contents of an encrypted message.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessage"/></summary>
		[TLDef(0x204D3878)]
		public partial class DecryptedMessage : DecryptedMessageBase
		{
			/// <summary>Random message ID, assigned by the author of message.<br/>Must be equal to the ID passed to sending method.</summary>
			public long random_id;
			/// <summary>Message lifetime. Has higher priority than <see cref="Layer8.DecryptedMessageActionSetMessageTTL"/>.<br/>Parameter added in <a href="https://corefork.telegram.org/api/layers#layer-17">Layer 17</a>.</summary>
			public int ttl;
			/// <summary>Message text</summary>
			public string message;
			/// <summary>Media content</summary>
			public DecryptedMessageMedia media;

			/// <summary>Random message ID, assigned by the author of message.<br/>Must be equal to the ID passed to sending method.</summary>
			public override long RandomId => random_id;
		}
		/// <summary>Contents of an encrypted service message.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageService"/></summary>
		[TLDef(0x73164160)]
		public partial class DecryptedMessageService : DecryptedMessageBase
		{
			/// <summary>Random message ID, assigned by the message author.<br/>Must be equal to the ID passed to the sending method.</summary>
			public long random_id;
			/// <summary>Action relevant to the service message</summary>
			public DecryptedMessageAction action;

			/// <summary>Random message ID, assigned by the message author.<br/>Must be equal to the ID passed to the sending method.</summary>
			public override long RandomId => random_id;
		}

		/// <summary>Video attached to an encrypted message.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaVideo"/></summary>
		[TLDef(0x524A415D)]
		public partial class DecryptedMessageMediaVideo : DecryptedMessageMedia
		{
			/// <summary>Content of thumbnail file (JPEG file, quality 55, set in a square 90x90)</summary>
			public byte[] thumb;
			/// <summary>Thumbnail width</summary>
			public int thumb_w;
			/// <summary>Thumbnail height</summary>
			public int thumb_h;
			/// <summary>Duration of video in seconds</summary>
			public int duration;
			/// <summary>MIME-type of the video file<br/>Parameter added in <a href="https://corefork.telegram.org/api/layers#layer-17">Layer 17</a>.</summary>
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
		}
		/// <summary>Audio file attached to a secret chat message.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaAudio"/></summary>
		[TLDef(0x57E0A9CB)]
		public partial class DecryptedMessageMediaAudio : DecryptedMessageMedia
		{
			/// <summary>Audio duration in seconds</summary>
			public int duration;
			/// <summary>MIME-type of the audio file<br/>Parameter added in <a href="https://corefork.telegram.org/api/layers#layer-13">Layer 13</a>.</summary>
			public string mime_type;
			/// <summary>File size</summary>
			public int size;
			/// <summary>Key to decrypt the attached media file</summary>
			public byte[] key;
			/// <summary>Initialization vector</summary>
			public byte[] iv;
		}

		/// <summary>Request for the other party in a Secret Chat to automatically resend a contiguous range of previously sent messages, as explained in <a href="https://corefork.telegram.org/api/end-to-end/seq_no">Sequence number is Secret Chats</a>.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionResend"/></summary>
		[TLDef(0x511110B0)]
		public partial class DecryptedMessageActionResend : DecryptedMessageAction
		{
			/// <summary><c>out_seq_no</c> of the first message to be resent, with correct parity</summary>
			public int start_seq_no;
			/// <summary><c>out_seq_no</c> of the last message to be resent, with same parity.</summary>
			public int end_seq_no;
		}
		/// <summary>A notification stating the API layer that is used by the client. You should use your current layer and take notice of the layer used on the other side of a conversation when sending messages.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionNotifyLayer"/></summary>
		[TLDef(0xF3048883)]
		public partial class DecryptedMessageActionNotifyLayer : DecryptedMessageAction
		{
			/// <summary>Layer number, must be <strong>17</strong> or higher (this contructor was introduced in <a href="https://corefork.telegram.org/api/layers#layer-17">Layer 17</a>).</summary>
			public int layer;
		}
		/// <summary>User is preparing a message: typing, recording, uploading, etc.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionTyping"/></summary>
		[TLDef(0xCCB27641)]
		public partial class DecryptedMessageActionTyping : DecryptedMessageAction
		{
			/// <summary>Type of action</summary>
			public SendMessageAction action;
		}

		/// <summary>Sets the layer number for the contents of an encrypted message.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageLayer"/></summary>
		[TLDef(0x1BE31789)]
		public partial class DecryptedMessageLayer : ITLObject
		{
			/// <summary>Set of random bytes to prevent content recognition in short encrypted messages.<br/>Clients are required to check that there are at least 15 random bytes included in each message. Messages with less than 15 random bytes must be ignored.<br/>Parameter moved here from <see cref="DecryptedMessage"/> in <a href="https://corefork.telegram.org/api/layers#layer-17">Layer 17</a>.</summary>
			public byte[] random_bytes;
			/// <summary>Layer number. Mimimal value - <strong>17</strong> (the layer in which the constructor was added).</summary>
			public int layer;
			/// <summary>2x the number of messages in the sender's inbox (including deleted and service messages), incremented by 1 if current user was not the chat creator<br/>Parameter added in <a href="https://corefork.telegram.org/api/layers#layer-17">Layer 17</a>.</summary>
			public int in_seq_no;
			/// <summary>2x the number of messages in the recipient's inbox (including deleted and service messages), incremented by 1 if current user was the chat creator<br/>Parameter added in <a href="https://corefork.telegram.org/api/layers#layer-17">Layer 17</a>.</summary>
			public int out_seq_no;
			/// <summary>The content of message itself</summary>
			public DecryptedMessageBase message;
		}
	}

	namespace Layer45
	{
		/// <summary>Defines a sticker		<br/>See <a href="https://corefork.telegram.org/constructor/documentAttributeSticker"/></summary>
		[TLDef(0x3A556302)]
		public partial class DocumentAttributeSticker : DocumentAttribute
		{
			/// <summary>Alternative emoji representation of sticker</summary>
			public string alt;
			/// <summary>Associated stickerset</summary>
			public InputStickerSet stickerset;
		}
		/// <summary>Represents an audio file		<br/>See <a href="https://corefork.telegram.org/constructor/documentAttributeAudio"/></summary>
		[TLDef(0xDED218E0)]
		public partial class DocumentAttributeAudio : DocumentAttribute
		{
			/// <summary>Duration in seconds</summary>
			public int duration;
			/// <summary>Name of song</summary>
			public string title;
			/// <summary>Performer</summary>
			public string performer;
		}

		/// <summary>Contents of an encrypted message.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessage"/></summary>
		[TLDef(0x36B091DE)]
		public partial class DecryptedMessage : DecryptedMessageBase
		{
			/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a> (added in layer 45)</summary>
			public Flags flags;
			/// <summary>Random message ID, assigned by the author of message.<br/>Must be equal to the ID passed to sending method.</summary>
			public long random_id;
			/// <summary>Message lifetime. Has higher priority than <see cref="Layer8.DecryptedMessageActionSetMessageTTL"/>.<br/>Parameter added in <a href="https://corefork.telegram.org/api/layers#layer-17">Layer 17</a>.</summary>
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

			[Flags] public enum Flags
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

			/// <summary>Random message ID, assigned by the author of message.<br/>Must be equal to the ID passed to sending method.</summary>
			public override long RandomId => random_id;
		}

		/// <summary>Photo attached to an encrypted message.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaPhoto"/></summary>
		[TLDef(0xF1FA8D78)]
		public partial class DecryptedMessageMediaPhoto : DecryptedMessageMedia
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
		}
		/// <summary>Video attached to an encrypted message.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaVideo"/></summary>
		[TLDef(0x970C8C0E)]
		public partial class DecryptedMessageMediaVideo : DecryptedMessageMedia
		{
			/// <summary>Content of thumbnail file (JPEG file, quality 55, set in a square 90x90)</summary>
			public byte[] thumb;
			/// <summary>Thumbnail width</summary>
			public int thumb_w;
			/// <summary>Thumbnail height</summary>
			public int thumb_h;
			/// <summary>Duration of video in seconds</summary>
			public int duration;
			/// <summary>MIME-type of the video file<br/>Parameter added in <a href="https://corefork.telegram.org/api/layers#layer-17">Layer 17</a>.</summary>
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
		}
		/// <summary>Document attached to a message in a secret chat.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaDocument"/></summary>
		[TLDef(0x7AFE8AE2)]
		public partial class DecryptedMessageMediaDocument : DecryptedMessageMedia
		{
			/// <summary>Thumbnail-file contents (JPEG-file, quality 55, set in a 90x90 square)</summary>
			public byte[] thumb;
			/// <summary>Thumbnail width</summary>
			public int thumb_w;
			/// <summary>Thumbnail height</summary>
			public int thumb_h;
			/// <summary>File MIME-type</summary>
			public string mime_type;
			/// <summary>Document size</summary>
			public int size;
			/// <summary>Key to decrypt the attached document file</summary>
			public byte[] key;
			/// <summary>Initialization</summary>
			public byte[] iv;
			/// <summary>Document attributes for media types</summary>
			public DocumentAttribute[] attributes;
			/// <summary>Caption</summary>
			public string caption;
		}
		/// <summary>Venue		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaVenue"/></summary>
		[TLDef(0x8A0DF56F)]
		public partial class DecryptedMessageMediaVenue : DecryptedMessageMedia
		{
			/// <summary>Latitude of venue</summary>
			public double lat;
			/// <summary>Longitude of venue</summary>
			public double long_;
			/// <summary>Venue name</summary>
			public string title;
			/// <summary>Address</summary>
			public string address;
			/// <summary>Venue provider: currently only "foursquare" needs to be supported</summary>
			public string provider;
			/// <summary>Venue ID in the provider's database</summary>
			public string venue_id;
		}
		/// <summary>Webpage preview		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaWebPage"/></summary>
		[TLDef(0xE50511D8)]
		public partial class DecryptedMessageMediaWebPage : DecryptedMessageMedia
		{
			/// <summary>URL of webpage</summary>
			public string url;
		}
	}

	namespace Layer73
	{
		/// <summary>Contents of an encrypted message.		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessage"/></summary>
		[TLDef(0x91CC4674)]
		public partial class DecryptedMessage : DecryptedMessageBase
		{
			/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a> (added in layer 45)</summary>
			public Flags flags;
			/// <summary>Random message ID, assigned by the author of message.<br/>Must be equal to the ID passed to sending method.</summary>
			public long random_id;
			/// <summary>Message lifetime. Has higher priority than <see cref="Layer8.DecryptedMessageActionSetMessageTTL"/>.<br/>Parameter added in <a href="https://corefork.telegram.org/api/layers#layer-17">Layer 17</a>.</summary>
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

			[Flags] public enum Flags
			{
				/// <summary>Field <see cref="reply_to_random_id"/> has a value</summary>
				has_reply_to_random_id = 0x8,
				/// <summary>Field <see cref="entities"/> has a value</summary>
				has_entities = 0x80,
				/// <summary>Field <see cref="media"/> has a value</summary>
				has_media = 0x200,
				/// <summary>Field <see cref="via_bot_name"/> has a value</summary>
				has_via_bot_name = 0x800,
				/// <summary>Field <see cref="grouped_id"/> has a value</summary>
				has_grouped_id = 0x20000,
			}

			/// <summary>Random message ID, assigned by the author of message.<br/>Must be equal to the ID passed to sending method.</summary>
			public override long RandomId => random_id;
		}
	}

	namespace Layer20
	{
		/// <summary>Request rekeying, see <a href="https://corefork.telegram.org/api/end-to-end/pfs">rekeying process</a>		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionRequestKey"/></summary>
		[TLDef(0xF3C9611B)]
		public partial class DecryptedMessageActionRequestKey : DecryptedMessageAction
		{
			/// <summary>Exchange ID</summary>
			public long exchange_id;
			/// <summary>g_a, see <a href="https://corefork.telegram.org/api/end-to-end/pfs">rekeying process</a></summary>
			public byte[] g_a;
		}
		/// <summary>Accept new key		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionAcceptKey"/></summary>
		[TLDef(0x6FE1735B)]
		public partial class DecryptedMessageActionAcceptKey : DecryptedMessageAction
		{
			/// <summary>Exchange ID</summary>
			public long exchange_id;
			/// <summary>B parameter, see <a href="https://corefork.telegram.org/api/end-to-end/pfs">rekeying process</a></summary>
			public byte[] g_b;
			/// <summary>Key fingerprint, see <a href="https://corefork.telegram.org/api/end-to-end/pfs">rekeying process</a></summary>
			public long key_fingerprint;
		}
		/// <summary>Abort rekeying		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionAbortKey"/></summary>
		[TLDef(0xDD05EC6B)]
		public partial class DecryptedMessageActionAbortKey : DecryptedMessageAction
		{
			/// <summary>Exchange ID</summary>
			public long exchange_id;
		}
		/// <summary>Commit new key, see <a href="https://corefork.telegram.org/api/end-to-end/pfs">rekeying process</a>		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionCommitKey"/></summary>
		[TLDef(0xEC2E0B9B)]
		public partial class DecryptedMessageActionCommitKey : DecryptedMessageAction
		{
			/// <summary>Exchange ID, see <a href="https://corefork.telegram.org/api/end-to-end/pfs">rekeying process</a></summary>
			public long exchange_id;
			/// <summary>Key fingerprint, see <a href="https://corefork.telegram.org/api/end-to-end/pfs">rekeying process</a></summary>
			public long key_fingerprint;
		}
		/// <summary>NOOP action		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageActionNoop"/></summary>
		[TLDef(0xA82FDD63)]
		public partial class DecryptedMessageActionNoop : DecryptedMessageAction { }
	}

	namespace Layer23
	{
		/// <summary>Image description.		<br/>See <a href="https://corefork.telegram.org/constructor/photoSize"/></summary>
		[TLDef(0x77BFB61B)]
		public partial class PhotoSize : PhotoSizeBase
		{
			/// <summary>Thumbnail type</summary>
			public string type;
			public FileLocationBase location;
			/// <summary>Image width</summary>
			public int w;
			/// <summary>Image height</summary>
			public int h;
			/// <summary>File size</summary>
			public int size;

			/// <summary>Thumbnail type</summary>
			public override string Type => type;
		}
		/// <summary>Description of an image and its content.		<br/>See <a href="https://corefork.telegram.org/constructor/photoCachedSize"/></summary>
		[TLDef(0xE9A734FA)]
		public partial class PhotoCachedSize : PhotoSizeBase
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

		/// <summary>Defines a sticker		<br/>See <a href="https://corefork.telegram.org/constructor/documentAttributeSticker"/></summary>
		[TLDef(0xFB0A5727)]
		public partial class DocumentAttributeSticker : DocumentAttribute { }
		/// <summary>Defines a video		<br/>See <a href="https://corefork.telegram.org/constructor/documentAttributeVideo"/></summary>
		[TLDef(0x5910CCCB)]
		public partial class DocumentAttributeVideo : DocumentAttribute
		{
			/// <summary>Duration in seconds</summary>
			public int duration;
			/// <summary>Video width</summary>
			public int w;
			/// <summary>Video height</summary>
			public int h;
		}
		/// <summary>Represents an audio file		<br/>See <a href="https://corefork.telegram.org/constructor/documentAttributeAudio"/></summary>
		[TLDef(0x051448E5)]
		public partial class DocumentAttributeAudio : DocumentAttribute
		{
			/// <summary>Duration in seconds</summary>
			public int duration;
		}

		/// <summary>Non-e2e documented forwarded from non-secret chat		<br/>See <a href="https://corefork.telegram.org/constructor/decryptedMessageMediaExternalDocument"/></summary>
		[TLDef(0xFA95B0DD)]
		public partial class DecryptedMessageMediaExternalDocument : DecryptedMessageMedia
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
		}

		/// <summary>File is currently unavailable.		<br/>See <a href="https://corefork.telegram.org/constructor/fileLocationUnavailable"/></summary>
		[TLDef(0x7C596B46)]
		public partial class FileLocationUnavailable : FileLocationBase
		{
			/// <summary>Server volume</summary>
			public long volume_id;
			/// <summary>File ID</summary>
			public int local_id;
			/// <summary>Checksum to access the file</summary>
			public long secret;

			/// <summary>Server volume</summary>
			public override long VolumeId => volume_id;
			/// <summary>File ID</summary>
			public override int LocalId => local_id;
			/// <summary>Checksum to access the file</summary>
			public override long Secret => secret;
		}
		/// <summary>File location.		<br/>See <a href="https://corefork.telegram.org/constructor/fileLocation"/></summary>
		[TLDef(0x53D69076)]
		public partial class FileLocation : FileLocationBase
		{
			/// <summary>Number of the data center holding the file</summary>
			public int dc_id;
			/// <summary>Server volume</summary>
			public long volume_id;
			/// <summary>File ID</summary>
			public int local_id;
			/// <summary>Checksum to access the file</summary>
			public long secret;

			/// <summary>Server volume</summary>
			public override long VolumeId => volume_id;
			/// <summary>File ID</summary>
			public override int LocalId => local_id;
			/// <summary>Checksum to access the file</summary>
			public override long Secret => secret;
		}
	}

	namespace Layer66
	{
		/// <summary>User is uploading a round video		<br/>See <a href="https://corefork.telegram.org/constructor/sendMessageUploadRoundAction"/></summary>
		[TLDef(0xBB718624)]
		public partial class SendMessageUploadRoundAction : SendMessageAction { }
	}

	namespace Layer46
	{	}
}
