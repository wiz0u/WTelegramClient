using System;
using System.Collections.Generic;

namespace TL
{
	/// <summary>Boolean type.		<para>See <a href="https://corefork.telegram.org/type/Bool"/></para></summary>
	public enum Bool : uint
	{
		///<summary>Constructor may be interpreted as a <strong>boolean</strong><c>false</c> value.</summary>
		False = 0xBC799737,
		///<summary>The constructor can be interpreted as a <strong>boolean</strong><c>true</c> value.</summary>
		True = 0x997275B5,
	}

	/// <summary>See <a href="https://corefork.telegram.org/mtproto/TL-formal#predefined-identifiers">predefined identifiers</a>.		<para>See <a href="https://corefork.telegram.org/constructor/true"/></para></summary>
	[TLDef(0x3FEDD339)]
	public class True : IObject { }

	/// <summary>Error.		<para>See <a href="https://corefork.telegram.org/constructor/error"/></para></summary>
	[TLDef(0xC4B9F9BB)]
	public class Error : IObject
	{
		/// <summary>Error code</summary>
		public int code;
		/// <summary>Message</summary>
		public string text;
	}

	/// <summary>Corresponds to an arbitrary empty object.		<para>See <a href="https://corefork.telegram.org/constructor/null"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/null">null</a></remarks>
	[TLDef(0x56730BCC)]
	public class Null : IObject { }

	/// <summary>Peer		<para>Derived classes: <see cref="InputPeerSelf"/>, <see cref="InputPeerChat"/>, <see cref="InputPeerUser"/>, <see cref="InputPeerChannel"/>, <see cref="InputPeerUserFromMessage"/>, <see cref="InputPeerChannelFromMessage"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputPeer"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputPeerEmpty">inputPeerEmpty</a></remarks>
	public abstract partial class InputPeer : IObject { }
	/// <summary>Defines the current user.		<para>See <a href="https://corefork.telegram.org/constructor/inputPeerSelf"/></para></summary>
	[TLDef(0x7DA07EC9)]
	public class InputPeerSelf : InputPeer { }
	/// <summary>Defines a chat for further interaction.		<para>See <a href="https://corefork.telegram.org/constructor/inputPeerChat"/></para></summary>
	[TLDef(0x35A95CB9)]
	public partial class InputPeerChat : InputPeer
	{
		/// <summary>Chat identifier</summary>
		public long chat_id;
	}
	/// <summary>Defines a user for further interaction.		<para>See <a href="https://corefork.telegram.org/constructor/inputPeerUser"/></para></summary>
	[TLDef(0xDDE8A54C)]
	public partial class InputPeerUser : InputPeer
	{
		/// <summary>User identifier</summary>
		public long user_id;
		/// <summary>⚠ <b>REQUIRED FIELD</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash">how to obtain it</see><br/><strong>access_hash</strong> value from the <see cref="User"/> constructor</summary>
		public long access_hash;
	}
	/// <summary>Defines a channel for further interaction.		<para>See <a href="https://corefork.telegram.org/constructor/inputPeerChannel"/></para></summary>
	[TLDef(0x27BCBBFC)]
	public partial class InputPeerChannel : InputPeer
	{
		/// <summary>Channel identifier</summary>
		public long channel_id;
		/// <summary>⚠ <b>REQUIRED FIELD</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash">how to obtain it</see><br/><strong>access_hash</strong> value from the <see cref="Channel"/> constructor</summary>
		public long access_hash;
	}
	/// <summary>Defines a <a href="https://corefork.telegram.org/api/min">min</a> user that was seen in a certain message of a certain chat.		<para>See <a href="https://corefork.telegram.org/constructor/inputPeerUserFromMessage"/></para></summary>
	[TLDef(0xA87B0A1C)]
	public class InputPeerUserFromMessage : InputPeer
	{
		/// <summary>The chat where the user was seen</summary>
		public InputPeer peer;
		/// <summary>The message ID</summary>
		public int msg_id;
		/// <summary>The identifier of the user that was seen</summary>
		public long user_id;
	}
	/// <summary>Defines a <a href="https://corefork.telegram.org/api/min">min</a> channel that was seen in a certain message of a certain chat.		<para>See <a href="https://corefork.telegram.org/constructor/inputPeerChannelFromMessage"/></para></summary>
	[TLDef(0xBD2A0840)]
	public class InputPeerChannelFromMessage : InputPeer
	{
		/// <summary>The chat where the channel's message was seen</summary>
		public InputPeer peer;
		/// <summary>The message ID</summary>
		public int msg_id;
		/// <summary>The identifier of the channel that was seen</summary>
		public long channel_id;
	}

	/// <summary>Defines a user for subsequent interaction.		<para>Derived classes: <see cref="InputUserSelf"/>, <see cref="InputUser"/>, <see cref="InputUserFromMessage"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputUser"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputUserEmpty">inputUserEmpty</a></remarks>
	public abstract partial class InputUserBase : IObject { }
	/// <summary>Defines the current user.		<para>See <a href="https://corefork.telegram.org/constructor/inputUserSelf"/></para></summary>
	[TLDef(0xF7C1B13F)]
	public partial class InputUserSelf : InputUserBase { }
	/// <summary>Defines a user for further interaction.		<para>See <a href="https://corefork.telegram.org/constructor/inputUser"/></para></summary>
	[TLDef(0xF21158C6)]
	public partial class InputUser : InputUserBase
	{
		/// <summary>User identifier</summary>
		public long user_id;
		/// <summary>⚠ <b>REQUIRED FIELD</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash">how to obtain it</see><br/><strong>access_hash</strong> value from the <see cref="User"/> constructor</summary>
		public long access_hash;
	}
	/// <summary>Defines a <a href="https://corefork.telegram.org/api/min">min</a> user that was seen in a certain message of a certain chat.		<para>See <a href="https://corefork.telegram.org/constructor/inputUserFromMessage"/></para></summary>
	[TLDef(0x1DA448E2)]
	public partial class InputUserFromMessage : InputUserBase
	{
		/// <summary>The chat where the user was seen</summary>
		public InputPeer peer;
		/// <summary>The message ID</summary>
		public int msg_id;
		/// <summary>The identifier of the user that was seen</summary>
		public long user_id;
	}

	/// <summary>Object defines a contact from the user's phone book.		<para>Derived classes: <see cref="InputPhoneContact"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputContact"/></para></summary>
	public abstract class InputContact : IObject { }
	/// <summary>Phone contact. The <c>client_id</c> is just an arbitrary contact ID: it should be set, for example, to an incremental number when using <a href="https://corefork.telegram.org/method/contacts.importContacts">contacts.importContacts</a>, in order to retry importing only the contacts that weren't imported successfully.		<para>See <a href="https://corefork.telegram.org/constructor/inputPhoneContact"/></para></summary>
	[TLDef(0xF392B7F4)]
	public class InputPhoneContact : InputContact
	{
		/// <summary>User identifier on the client</summary>
		public long client_id;
		/// <summary>Phone number</summary>
		public string phone;
		/// <summary>Contact's first name</summary>
		public string first_name;
		/// <summary>Contact's last name</summary>
		public string last_name;
	}

	/// <summary>Defines a file uploaded by the client.		<para>Derived classes: <see cref="InputFile"/>, <see cref="InputFileBig"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputFile"/></para></summary>
	public abstract partial class InputFileBase : IObject
	{
		/// <summary>Random file identifier created by the client</summary>
		public abstract long ID { get; }
		/// <summary>Number of parts saved</summary>
		public abstract int Parts { get; }
		/// <summary>Full name of the file</summary>
		public abstract string Name { get; }
	}
	/// <summary>Defines a file saved in parts using the method <a href="https://corefork.telegram.org/method/upload.saveFilePart">upload.saveFilePart</a>.		<para>See <a href="https://corefork.telegram.org/constructor/inputFile"/></para></summary>
	[TLDef(0xF52FF27F)]
	public partial class InputFile : InputFileBase
	{
		/// <summary>Random file identifier created by the client</summary>
		public long id;
		/// <summary>Number of parts saved</summary>
		public int parts;
		/// <summary>Full name of the file</summary>
		public string name;
		/// <summary>In case the file's <a href="https://en.wikipedia.org/wiki/MD5#MD5_hashes">md5-hash</a> was passed, contents of the file will be checked prior to use</summary>
		public byte[] md5_checksum;

		/// <summary>Random file identifier created by the client</summary>
		public override long ID => id;
		/// <summary>Number of parts saved</summary>
		public override int Parts => parts;
		/// <summary>Full name of the file</summary>
		public override string Name => name;
	}
	/// <summary>Assigns a big file (over 10 MB in size), saved in part using the method <a href="https://corefork.telegram.org/method/upload.saveBigFilePart">upload.saveBigFilePart</a>.		<para>See <a href="https://corefork.telegram.org/constructor/inputFileBig"/></para></summary>
	[TLDef(0xFA4F0BB5)]
	public partial class InputFileBig : InputFileBase
	{
		/// <summary>Random file id, created by the client</summary>
		public long id;
		/// <summary>Number of parts saved</summary>
		public int parts;
		/// <summary>Full file name</summary>
		public string name;

		/// <summary>Random file id, created by the client</summary>
		public override long ID => id;
		/// <summary>Number of parts saved</summary>
		public override int Parts => parts;
		/// <summary>Full file name</summary>
		public override string Name => name;
	}

	/// <summary>Defines media content of a message.		<para>Derived classes: <see cref="InputMediaUploadedPhoto"/>, <see cref="InputMediaPhoto"/>, <see cref="InputMediaGeoPoint"/>, <see cref="InputMediaContact"/>, <see cref="InputMediaUploadedDocument"/>, <see cref="InputMediaDocument"/>, <see cref="InputMediaVenue"/>, <see cref="InputMediaPhotoExternal"/>, <see cref="InputMediaDocumentExternal"/>, <see cref="InputMediaGame"/>, <see cref="InputMediaInvoice"/>, <see cref="InputMediaGeoLive"/>, <see cref="InputMediaPoll"/>, <see cref="InputMediaDice"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputMedia"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputMediaEmpty">inputMediaEmpty</a></remarks>
	public abstract class InputMedia : IObject { }
	/// <summary>Photo		<para>See <a href="https://corefork.telegram.org/constructor/inputMediaUploadedPhoto"/></para></summary>
	[TLDef(0x1E287D04)]
	public class InputMediaUploadedPhoto : InputMedia
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The <a href="https://corefork.telegram.org/api/files">uploaded file</a></summary>
		public InputFileBase file;
		/// <summary>Attached mask stickers</summary>
		[IfFlag(0)] public InputDocument[] stickers;
		/// <summary>Time to live in seconds of self-destructing photo</summary>
		[IfFlag(1)] public int ttl_seconds;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="stickers"/> has a value</summary>
			has_stickers = 0x1,
			/// <summary>Field <see cref="ttl_seconds"/> has a value</summary>
			has_ttl_seconds = 0x2,
		}
	}
	/// <summary>Forwarded photo		<para>See <a href="https://corefork.telegram.org/constructor/inputMediaPhoto"/></para></summary>
	[TLDef(0xB3BA0635)]
	public class InputMediaPhoto : InputMedia
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Photo to be forwarded</summary>
		public InputPhoto id;
		/// <summary>Time to live in seconds of self-destructing photo</summary>
		[IfFlag(0)] public int ttl_seconds;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="ttl_seconds"/> has a value</summary>
			has_ttl_seconds = 0x1,
		}
	}
	/// <summary>Map.		<para>See <a href="https://corefork.telegram.org/constructor/inputMediaGeoPoint"/></para></summary>
	[TLDef(0xF9C44144)]
	public class InputMediaGeoPoint : InputMedia
	{
		/// <summary>GeoPoint</summary>
		public InputGeoPoint geo_point;
	}
	/// <summary>Phone book contact		<para>See <a href="https://corefork.telegram.org/constructor/inputMediaContact"/></para></summary>
	[TLDef(0xF8AB7DFB)]
	public class InputMediaContact : InputMedia
	{
		/// <summary>Phone number</summary>
		public string phone_number;
		/// <summary>Contact's first name</summary>
		public string first_name;
		/// <summary>Contact's last name</summary>
		public string last_name;
		/// <summary>Contact vcard</summary>
		public string vcard;
	}
	/// <summary>New document		<para>See <a href="https://corefork.telegram.org/constructor/inputMediaUploadedDocument"/></para></summary>
	[TLDef(0x5B38C6C1)]
	public partial class InputMediaUploadedDocument : InputMedia
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The <a href="https://corefork.telegram.org/api/files">uploaded file</a></summary>
		public InputFileBase file;
		/// <summary>Thumbnail of the document, uploaded as for the file</summary>
		[IfFlag(2)] public InputFileBase thumb;
		/// <summary>MIME type of document</summary>
		public string mime_type;
		/// <summary>Attributes that specify the type of the document (video, audio, voice, sticker, etc.)</summary>
		public DocumentAttribute[] attributes;
		/// <summary>Attached stickers</summary>
		[IfFlag(0)] public InputDocument[] stickers;
		/// <summary>Time to live in seconds of self-destructing document</summary>
		[IfFlag(1)] public int ttl_seconds;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="stickers"/> has a value</summary>
			has_stickers = 0x1,
			/// <summary>Field <see cref="ttl_seconds"/> has a value</summary>
			has_ttl_seconds = 0x2,
			/// <summary>Field <see cref="thumb"/> has a value</summary>
			has_thumb = 0x4,
			/// <summary>Whether the specified document is a video file with no audio tracks (a GIF animation (even as MPEG4), for example)</summary>
			nosound_video = 0x8,
			/// <summary>Force the media file to be uploaded as document</summary>
			force_file = 0x10,
		}
	}
	/// <summary>Forwarded document		<para>See <a href="https://corefork.telegram.org/constructor/inputMediaDocument"/></para></summary>
	[TLDef(0x33473058)]
	public class InputMediaDocument : InputMedia
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The document to be forwarded.</summary>
		public InputDocument id;
		/// <summary>Time to live of self-destructing document</summary>
		[IfFlag(0)] public int ttl_seconds;
		/// <summary>Text query or emoji that was used by the user to find this sticker or GIF: used to improve search result relevance.</summary>
		[IfFlag(1)] public string query;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="ttl_seconds"/> has a value</summary>
			has_ttl_seconds = 0x1,
			/// <summary>Field <see cref="query"/> has a value</summary>
			has_query = 0x2,
		}
	}
	/// <summary>Can be used to send a venue geolocation.		<para>See <a href="https://corefork.telegram.org/constructor/inputMediaVenue"/></para></summary>
	[TLDef(0xC13D1C11)]
	public class InputMediaVenue : InputMedia
	{
		/// <summary>Geolocation</summary>
		public InputGeoPoint geo_point;
		/// <summary>Venue name</summary>
		public string title;
		/// <summary>Physical address of the venue</summary>
		public string address;
		/// <summary>Venue provider: currently only "foursquare" needs to be supported</summary>
		public string provider;
		/// <summary>Venue ID in the provider's database</summary>
		public string venue_id;
		/// <summary>Venue type in the provider's database</summary>
		public string venue_type;
	}
	/// <summary>New photo that will be uploaded by the server using the specified URL		<para>See <a href="https://corefork.telegram.org/constructor/inputMediaPhotoExternal"/></para></summary>
	[TLDef(0xE5BBFE1A)]
	public class InputMediaPhotoExternal : InputMedia
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>URL of the photo</summary>
		public string url;
		/// <summary>Self-destruct time to live of photo</summary>
		[IfFlag(0)] public int ttl_seconds;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="ttl_seconds"/> has a value</summary>
			has_ttl_seconds = 0x1,
		}
	}
	/// <summary>Document that will be downloaded by the telegram servers		<para>See <a href="https://corefork.telegram.org/constructor/inputMediaDocumentExternal"/></para></summary>
	[TLDef(0xFB52DC99)]
	public class InputMediaDocumentExternal : InputMedia
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>URL of the document</summary>
		public string url;
		/// <summary>Self-destruct time to live of document</summary>
		[IfFlag(0)] public int ttl_seconds;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="ttl_seconds"/> has a value</summary>
			has_ttl_seconds = 0x1,
		}
	}
	/// <summary>A game		<para>See <a href="https://corefork.telegram.org/constructor/inputMediaGame"/></para></summary>
	[TLDef(0xD33F43F3)]
	public class InputMediaGame : InputMedia
	{
		/// <summary>The game to forward</summary>
		public InputGame id;
	}
	/// <summary>Generated invoice of a <a href="https://corefork.telegram.org/bots/payments">bot payment</a>		<para>See <a href="https://corefork.telegram.org/constructor/inputMediaInvoice"/></para></summary>
	[TLDef(0xD9799874)]
	public class InputMediaInvoice : InputMedia
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Product name, 1-32 characters</summary>
		public string title;
		/// <summary>Product description, 1-255 characters</summary>
		public string description;
		/// <summary>URL of the product photo for the invoice. Can be a photo of the goods or a marketing image for a service. People like it better when they see what they are paying for.</summary>
		[IfFlag(0)] public InputWebDocument photo;
		/// <summary>The actual invoice</summary>
		public Invoice invoice;
		/// <summary>Bot-defined invoice payload, 1-128 bytes. This will not be displayed to the user, use for your internal processes.</summary>
		public byte[] payload;
		/// <summary>Payments provider token, obtained via <a href="https://t.me/botfather">Botfather</a></summary>
		public string provider;
		/// <summary>JSON-encoded data about the invoice, which will be shared with the payment provider. A detailed description of required fields should be provided by the payment provider.</summary>
		public DataJSON provider_data;
		/// <summary>Start parameter</summary>
		[IfFlag(1)] public string start_param;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="photo"/> has a value</summary>
			has_photo = 0x1,
			/// <summary>Field <see cref="start_param"/> has a value</summary>
			has_start_param = 0x2,
		}
	}
	/// <summary><a href="https://corefork.telegram.org/api/live-location">Live geolocation</a>		<para>See <a href="https://corefork.telegram.org/constructor/inputMediaGeoLive"/></para></summary>
	[TLDef(0x971FA843)]
	public class InputMediaGeoLive : InputMedia
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Current geolocation</summary>
		public InputGeoPoint geo_point;
		/// <summary>For <a href="https://corefork.telegram.org/api/live-location">live locations</a>, a direction in which the location moves, in degrees; 1-360.</summary>
		[IfFlag(2)] public int heading;
		/// <summary>Validity period of the current location</summary>
		[IfFlag(1)] public int period;
		/// <summary>For <a href="https://corefork.telegram.org/api/live-location">live locations</a>, a maximum distance to another chat member for proximity alerts, in meters (0-100000)</summary>
		[IfFlag(3)] public int proximity_notification_radius;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether sending of the geolocation was stopped</summary>
			stopped = 0x1,
			/// <summary>Field <see cref="period"/> has a value</summary>
			has_period = 0x2,
			/// <summary>Field <see cref="heading"/> has a value</summary>
			has_heading = 0x4,
			/// <summary>Field <see cref="proximity_notification_radius"/> has a value</summary>
			has_proximity_notification_radius = 0x8,
		}
	}
	/// <summary>A poll		<para>See <a href="https://corefork.telegram.org/constructor/inputMediaPoll"/></para></summary>
	[TLDef(0x0F94E5F1)]
	public class InputMediaPoll : InputMedia
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The poll to send</summary>
		public Poll poll;
		/// <summary>Correct answer IDs (for quiz polls)</summary>
		[IfFlag(0)] public byte[][] correct_answers;
		/// <summary>Explanation of quiz solution</summary>
		[IfFlag(1)] public string solution;
		/// <summary><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></summary>
		[IfFlag(1)] public MessageEntity[] solution_entities;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="correct_answers"/> has a value</summary>
			has_correct_answers = 0x1,
			/// <summary>Field <see cref="solution"/> has a value</summary>
			has_solution = 0x2,
		}
	}
	/// <summary>Send a <a href="https://corefork.telegram.org/api/dice">dice-based animated sticker</a>		<para>See <a href="https://corefork.telegram.org/constructor/inputMediaDice"/></para></summary>
	[TLDef(0xE66FBF7B)]
	public class InputMediaDice : InputMedia
	{
		/// <summary>The emoji, for now 🏀, 🎲 and 🎯 are supported</summary>
		public string emoticon;
	}

	/// <summary>Defines a new group profile photo.		<para>Derived classes: <see cref="InputChatUploadedPhoto"/>, <see cref="InputChatPhoto"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputChatPhoto"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputChatPhotoEmpty">inputChatPhotoEmpty</a></remarks>
	public abstract class InputChatPhotoBase : IObject { }
	/// <summary>New photo to be set as group profile photo.		<para>See <a href="https://corefork.telegram.org/constructor/inputChatUploadedPhoto"/></para></summary>
	[TLDef(0xC642724E)]
	public class InputChatUploadedPhoto : InputChatPhotoBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>File saved in parts using the method <a href="https://corefork.telegram.org/method/upload.saveFilePart">upload.saveFilePart</a></summary>
		[IfFlag(0)] public InputFileBase file;
		/// <summary>Square video for animated profile picture</summary>
		[IfFlag(1)] public InputFileBase video;
		/// <summary>Timestamp that should be shown as static preview to the user (seconds)</summary>
		[IfFlag(2)] public double video_start_ts;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="file"/> has a value</summary>
			has_file = 0x1,
			/// <summary>Field <see cref="video"/> has a value</summary>
			has_video = 0x2,
			/// <summary>Field <see cref="video_start_ts"/> has a value</summary>
			has_video_start_ts = 0x4,
		}
	}
	/// <summary>Existing photo to be set as a chat profile photo.		<para>See <a href="https://corefork.telegram.org/constructor/inputChatPhoto"/></para></summary>
	[TLDef(0x8953AD37)]
	public class InputChatPhoto : InputChatPhotoBase
	{
		/// <summary>Existing photo</summary>
		public InputPhoto id;
	}

	/// <summary>Defines a GeoPoint by its coordinates.		<para>See <a href="https://corefork.telegram.org/constructor/inputGeoPoint"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputGeoPointEmpty">inputGeoPointEmpty</a></remarks>
	[TLDef(0x48222FAF)]
	public class InputGeoPoint : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Latitude</summary>
		public double lat;
		/// <summary>Longitude</summary>
		public double lon;
		/// <summary>The estimated horizontal accuracy of the location, in meters; as defined by the sender.</summary>
		[IfFlag(0)] public int accuracy_radius;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="accuracy_radius"/> has a value</summary>
			has_accuracy_radius = 0x1,
		}
	}

	/// <summary>Defines a photo for further interaction.		<para>See <a href="https://corefork.telegram.org/constructor/inputPhoto"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputPhotoEmpty">inputPhotoEmpty</a></remarks>
	[TLDef(0x3BB3B94A)]
	public partial class InputPhoto : IObject
	{
		/// <summary>Photo identifier</summary>
		public long id;
		/// <summary>⚠ <b>REQUIRED FIELD</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash">how to obtain it</see><br/><strong>access_hash</strong> value from the <see cref="Photo"/> constructor</summary>
		public long access_hash;
		/// <summary><a href="https://corefork.telegram.org/api/file_reference">File reference</a></summary>
		public byte[] file_reference;
	}

	/// <summary>Defines the location of a file for download.		<para>Derived classes: <see cref="InputFileLocation"/>, <see cref="InputEncryptedFileLocation"/>, <see cref="InputDocumentFileLocation"/>, <see cref="InputSecureFileLocation"/>, <see cref="InputTakeoutFileLocation"/>, <see cref="InputPhotoFileLocation"/>, <see cref="InputPhotoLegacyFileLocation"/>, <see cref="InputPeerPhotoFileLocation"/>, <see cref="InputStickerSetThumb"/>, <see cref="InputGroupCallStream"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputFileLocation"/></para></summary>
	public abstract class InputFileLocationBase : IObject { }
	/// <summary>DEPRECATED location of a photo		<para>See <a href="https://corefork.telegram.org/constructor/inputFileLocation"/></para></summary>
	[TLDef(0xDFDAABE1)]
	public class InputFileLocation : InputFileLocationBase
	{
		/// <summary>Server volume</summary>
		public long volume_id;
		/// <summary>File identifier</summary>
		public int local_id;
		/// <summary>Check sum to access the file</summary>
		public long secret;
		/// <summary><a href="https://corefork.telegram.org/api/file_reference">File reference</a></summary>
		public byte[] file_reference;
	}
	/// <summary>Location of encrypted secret chat file.		<para>See <a href="https://corefork.telegram.org/constructor/inputEncryptedFileLocation"/></para></summary>
	[TLDef(0xF5235D55)]
	public class InputEncryptedFileLocation : InputFileLocationBase
	{
		/// <summary>File ID, <strong>id</strong> parameter value from <see cref="EncryptedFile"/></summary>
		public long id;
		/// <summary>⚠ <b>REQUIRED FIELD</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash">how to obtain it</see><br/>Checksum, <strong>access_hash</strong> parameter value from <see cref="EncryptedFile"/></summary>
		public long access_hash;
	}
	/// <summary>Document location (video, voice, audio, basically every type except photo)		<para>See <a href="https://corefork.telegram.org/constructor/inputDocumentFileLocation"/></para></summary>
	[TLDef(0xBAD07584)]
	public class InputDocumentFileLocation : InputFileLocationBase
	{
		/// <summary>Document ID</summary>
		public long id;
		/// <summary>⚠ <b>REQUIRED FIELD</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash">how to obtain it</see><br/><strong>access_hash</strong> parameter from the <see cref="Document"/> constructor</summary>
		public long access_hash;
		/// <summary><a href="https://corefork.telegram.org/api/file_reference">File reference</a></summary>
		public byte[] file_reference;
		/// <summary>Thumbnail size to download the thumbnail</summary>
		public string thumb_size;
	}
	/// <summary>Location of encrypted telegram <a href="https://corefork.telegram.org/passport">passport</a> file.		<para>See <a href="https://corefork.telegram.org/constructor/inputSecureFileLocation"/></para></summary>
	[TLDef(0xCBC7EE28)]
	public class InputSecureFileLocation : InputFileLocationBase
	{
		/// <summary>File ID, <strong>id</strong> parameter value from <see cref="SecureFile"/></summary>
		public long id;
		/// <summary>⚠ <b>REQUIRED FIELD</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash">how to obtain it</see><br/>Checksum, <strong>access_hash</strong> parameter value from <see cref="SecureFile"/></summary>
		public long access_hash;
	}
	/// <summary>Empty constructor for takeout		<para>See <a href="https://corefork.telegram.org/constructor/inputTakeoutFileLocation"/></para></summary>
	[TLDef(0x29BE5899)]
	public class InputTakeoutFileLocation : InputFileLocationBase { }
	/// <summary>Use this object to download a photo with <a href="https://corefork.telegram.org/method/upload.getFile">upload.getFile</a> method		<para>See <a href="https://corefork.telegram.org/constructor/inputPhotoFileLocation"/></para></summary>
	[TLDef(0x40181FFE)]
	public class InputPhotoFileLocation : InputFileLocationBase
	{
		/// <summary>Photo ID, obtained from the <see cref="Photo"/> object</summary>
		public long id;
		/// <summary>⚠ <b>REQUIRED FIELD</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash">how to obtain it</see><br/>Photo's access hash, obtained from the <see cref="Photo"/> object</summary>
		public long access_hash;
		/// <summary><a href="https://corefork.telegram.org/api/file_reference">File reference</a></summary>
		public byte[] file_reference;
		/// <summary>The <see cref="PhotoSizeBase"/> to download: must be set to the <c>type</c> field of the desired PhotoSize object of the <see cref="Photo"/></summary>
		public string thumb_size;
	}
	/// <summary>DEPRECATED legacy photo file location		<para>See <a href="https://corefork.telegram.org/constructor/inputPhotoLegacyFileLocation"/></para></summary>
	[TLDef(0xD83466F3)]
	public class InputPhotoLegacyFileLocation : InputFileLocationBase
	{
		/// <summary>Photo ID</summary>
		public long id;
		/// <summary>⚠ <b>REQUIRED FIELD</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash">how to obtain it</see><br/>Access hash</summary>
		public long access_hash;
		/// <summary>File reference</summary>
		public byte[] file_reference;
		/// <summary>Volume ID</summary>
		public long volume_id;
		/// <summary>Local ID</summary>
		public int local_id;
		/// <summary>Secret</summary>
		public long secret;
	}
	/// <summary>Location of profile photo of channel/group/supergroup/user		<para>See <a href="https://corefork.telegram.org/constructor/inputPeerPhotoFileLocation"/></para></summary>
	[TLDef(0x37257E99)]
	public class InputPeerPhotoFileLocation : InputFileLocationBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The peer whose profile picture should be downloaded</summary>
		public InputPeer peer;
		/// <summary>Photo ID</summary>
		public long photo_id;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether to download the high-quality version of the picture</summary>
			big = 0x1,
		}
	}
	/// <summary>Location of stickerset thumbnail (see <a href="https://corefork.telegram.org/api/files">files</a>)		<para>See <a href="https://corefork.telegram.org/constructor/inputStickerSetThumb"/></para></summary>
	[TLDef(0x9D84F3DB)]
	public class InputStickerSetThumb : InputFileLocationBase
	{
		/// <summary>Sticker set</summary>
		public InputStickerSet stickerset;
		/// <summary>Thumbnail version</summary>
		public int thumb_version;
	}
	/// <summary>Chunk of a livestream		<para>See <a href="https://corefork.telegram.org/constructor/inputGroupCallStream"/></para></summary>
	[TLDef(0x0598A92A)]
	public class InputGroupCallStream : InputFileLocationBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Livestream info</summary>
		public InputGroupCall call;
		/// <summary>Timestamp in milliseconds</summary>
		public long time_ms;
		/// <summary>Specifies the duration of the video segment to fetch in milliseconds, by bitshifting <c>1000</c> to the right <c>scale</c> times: <c>duration_ms := 1000 &gt;&gt; scale</c></summary>
		public int scale;
		/// <summary>Selected video channel</summary>
		[IfFlag(0)] public int video_channel;
		/// <summary>Selected video quality (0 = lowest, 1 = medium, 2 = best)</summary>
		[IfFlag(0)] public int video_quality;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="video_channel"/> has a value</summary>
			has_video_channel = 0x1,
		}
	}

	/// <summary>Chat partner or group.		<para>Derived classes: <see cref="PeerUser"/>, <see cref="PeerChat"/>, <see cref="PeerChannel"/></para>		<para>See <a href="https://corefork.telegram.org/type/Peer"/></para></summary>
	public abstract partial class Peer : IObject { }
	/// <summary>Chat partner		<para>See <a href="https://corefork.telegram.org/constructor/peerUser"/></para></summary>
	[TLDef(0x59511722)]
	public partial class PeerUser : Peer
	{
		/// <summary>User identifier</summary>
		public long user_id;
	}
	/// <summary>Group.		<para>See <a href="https://corefork.telegram.org/constructor/peerChat"/></para></summary>
	[TLDef(0x36C6019A)]
	public partial class PeerChat : Peer
	{
		/// <summary>Group identifier</summary>
		public long chat_id;
	}
	/// <summary>Channel/supergroup		<para>See <a href="https://corefork.telegram.org/constructor/peerChannel"/></para></summary>
	[TLDef(0xA2A5371E)]
	public partial class PeerChannel : Peer
	{
		/// <summary>Channel ID</summary>
		public long channel_id;
	}

	/// <summary>Object describes the file type.		<para>See <a href="https://corefork.telegram.org/type/storage.FileType"/></para></summary>
	public enum Storage_FileType : uint
	{
		///<summary>Unknown type.</summary>
		unknown = 0xAA963B05,
		///<summary>Part of a bigger file.</summary>
		partial = 0x40BC6F52,
		///<summary>JPEG image. MIME type: <c>image/jpeg</c>.</summary>
		jpeg = 0x007EFE0E,
		///<summary>GIF image. MIME type: <c>image/gif</c>.</summary>
		gif = 0xCAE1AADF,
		///<summary>PNG image. MIME type: <c>image/png</c>.</summary>
		png = 0x0A4F63C0,
		///<summary>PDF document image. MIME type: <c>application/pdf</c>.</summary>
		pdf = 0xAE1E508D,
		///<summary>Mp3 audio. MIME type: <c>audio/mpeg</c>.</summary>
		mp3 = 0x528A0677,
		///<summary>Quicktime video. MIME type: <c>video/quicktime</c>.</summary>
		mov = 0x4B09EBBC,
		///<summary>MPEG-4 video. MIME type: <c>video/mp4</c>.</summary>
		mp4 = 0xB3CEA0E4,
		///<summary>WEBP image. MIME type: <c>image/webp</c>.</summary>
		webp = 0x1081464C,
	}

	/// <summary>Object defines a user.		<para>Derived classes: <see cref="UserEmpty"/>, <see cref="User"/></para>		<para>See <a href="https://corefork.telegram.org/type/User"/></para></summary>
	public abstract partial class UserBase : IObject { }
	/// <summary>Empty constructor, non-existent user.		<para>See <a href="https://corefork.telegram.org/constructor/userEmpty"/></para></summary>
	[TLDef(0xD3BC4B7A)]
	public partial class UserEmpty : UserBase
	{
		/// <summary>User identifier or <c>0</c></summary>
		public long id;
	}
	/// <summary>Indicates info about a certain user		<para>See <a href="https://corefork.telegram.org/constructor/user"/></para></summary>
	[TLDef(0x3FF6ECB0)]
	public partial class User : UserBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>ID of the user</summary>
		public long id;
		/// <summary>Access hash of the user</summary>
		[IfFlag(0)] public long access_hash;
		/// <summary>First name</summary>
		[IfFlag(1)] public string first_name;
		/// <summary>Last name</summary>
		[IfFlag(2)] public string last_name;
		/// <summary>Username</summary>
		[IfFlag(3)] public string username;
		/// <summary>Phone number</summary>
		[IfFlag(4)] public string phone;
		/// <summary>Profile picture of user</summary>
		[IfFlag(5)] public UserProfilePhoto photo;
		/// <summary>Online status of user</summary>
		[IfFlag(6)] public UserStatus status;
		/// <summary>Version of the <see cref="UserFull"/>, incremented every time it changes</summary>
		[IfFlag(14)] public int bot_info_version;
		/// <summary>Contains the reason why access to this user must be restricted.</summary>
		[IfFlag(18)] public RestrictionReason[] restriction_reason;
		/// <summary>Inline placeholder for this inline bot</summary>
		[IfFlag(19)] public string bot_inline_placeholder;
		/// <summary>Language code of the user</summary>
		[IfFlag(22)] public string lang_code;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="access_hash"/> has a value</summary>
			has_access_hash = 0x1,
			/// <summary>Field <see cref="first_name"/> has a value</summary>
			has_first_name = 0x2,
			/// <summary>Field <see cref="last_name"/> has a value</summary>
			has_last_name = 0x4,
			/// <summary>Field <see cref="username"/> has a value</summary>
			has_username = 0x8,
			/// <summary>Field <see cref="phone"/> has a value</summary>
			has_phone = 0x10,
			/// <summary>Field <see cref="photo"/> has a value</summary>
			has_photo = 0x20,
			/// <summary>Field <see cref="status"/> has a value</summary>
			has_status = 0x40,
			/// <summary>Whether this user indicates the currently logged in user</summary>
			self = 0x400,
			/// <summary>Whether this user is a contact</summary>
			contact = 0x800,
			/// <summary>Whether this user is a mutual contact</summary>
			mutual_contact = 0x1000,
			/// <summary>Whether the account of this user was deleted</summary>
			deleted = 0x2000,
			/// <summary>Is this user a bot?</summary>
			bot = 0x4000,
			/// <summary>Can the bot see all messages in groups?</summary>
			bot_chat_history = 0x8000,
			/// <summary>Can the bot be added to groups?</summary>
			bot_nochats = 0x10000,
			/// <summary>Whether this user is verified</summary>
			verified = 0x20000,
			/// <summary>Access to this user must be restricted for the reason specified in <c>restriction_reason</c></summary>
			restricted = 0x40000,
			/// <summary>Field <see cref="bot_inline_placeholder"/> has a value</summary>
			has_bot_inline_placeholder = 0x80000,
			/// <summary>See <a href="https://corefork.telegram.org/api/min">min</a></summary>
			min = 0x100000,
			/// <summary>Whether the bot can request our geolocation in inline mode</summary>
			bot_inline_geo = 0x200000,
			/// <summary>Field <see cref="lang_code"/> has a value</summary>
			has_lang_code = 0x400000,
			/// <summary>Whether this is an official support user</summary>
			support = 0x800000,
			/// <summary>This may be a scam user</summary>
			scam = 0x1000000,
			/// <summary>If set, the profile picture for this user should be refetched</summary>
			apply_min_photo = 0x2000000,
			/// <summary>If set, this user was reported by many users as a fake or scam user: be careful when interacting with them.</summary>
			fake = 0x4000000,
			bot_attach_menu = 0x8000000,
		}
	}

	/// <summary>User profile photo.		<para>See <a href="https://corefork.telegram.org/constructor/userProfilePhoto"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/userProfilePhotoEmpty">userProfilePhotoEmpty</a></remarks>
	[TLDef(0x82D1F706)]
	public class UserProfilePhoto : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Identifier of the respective photo<br/>Parameter added in <a href="https://corefork.telegram.org/api/layers#layer-2">Layer 2</a></summary>
		public long photo_id;
		/// <summary><a href="https://corefork.telegram.org/api/files#stripped-thumbnails">Stripped thumbnail</a></summary>
		[IfFlag(1)] public byte[] stripped_thumb;
		/// <summary>DC ID where the photo is stored</summary>
		public int dc_id;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether an <a href="https://corefork.telegram.org/api/files#animated-profile-pictures">animated profile picture</a> is available for this user</summary>
			has_video = 0x1,
			/// <summary>Field <see cref="stripped_thumb"/> has a value</summary>
			has_stripped_thumb = 0x2,
		}
	}

	/// <summary>User online status		<para>Derived classes: <see cref="UserStatusOnline"/>, <see cref="UserStatusOffline"/>, <see cref="UserStatusRecently"/>, <see cref="UserStatusLastWeek"/>, <see cref="UserStatusLastMonth"/></para>		<para>See <a href="https://corefork.telegram.org/type/UserStatus"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/userStatusEmpty">userStatusEmpty</a></remarks>
	public abstract partial class UserStatus : IObject { }
	/// <summary>Online status of the user.		<para>See <a href="https://corefork.telegram.org/constructor/userStatusOnline"/></para></summary>
	[TLDef(0xEDB93949)]
	public partial class UserStatusOnline : UserStatus
	{
		/// <summary>Time to expiration of the current online status</summary>
		public DateTime expires;
	}
	/// <summary>The user's offline status.		<para>See <a href="https://corefork.telegram.org/constructor/userStatusOffline"/></para></summary>
	[TLDef(0x008C703F)]
	public partial class UserStatusOffline : UserStatus
	{
		/// <summary>Time the user was last seen online</summary>
		public int was_online;
	}
	/// <summary>Online status: last seen recently		<para>See <a href="https://corefork.telegram.org/constructor/userStatusRecently"/></para></summary>
	[TLDef(0xE26F42F1)]
	public partial class UserStatusRecently : UserStatus { }
	/// <summary>Online status: last seen last week		<para>See <a href="https://corefork.telegram.org/constructor/userStatusLastWeek"/></para></summary>
	[TLDef(0x07BF09FC)]
	public partial class UserStatusLastWeek : UserStatus { }
	/// <summary>Online status: last seen last month		<para>See <a href="https://corefork.telegram.org/constructor/userStatusLastMonth"/></para></summary>
	[TLDef(0x77EBC742)]
	public partial class UserStatusLastMonth : UserStatus { }

	/// <summary>Object defines a group.		<para>Derived classes: <see cref="ChatEmpty"/>, <see cref="Chat"/>, <see cref="ChatForbidden"/>, <see cref="Channel"/>, <see cref="ChannelForbidden"/></para>		<para>See <a href="https://corefork.telegram.org/type/Chat"/></para></summary>
	public abstract partial class ChatBase : IObject
	{
		/// <summary>ID of the group</summary>
		public abstract long ID { get; }
		/// <summary>Title</summary>
		public abstract string Title { get; }
	}
	/// <summary>Empty constructor, group doesn't exist		<para>See <a href="https://corefork.telegram.org/constructor/chatEmpty"/></para></summary>
	[TLDef(0x29562865)]
	public partial class ChatEmpty : ChatBase
	{
		/// <summary>Group identifier</summary>
		public long id;

		/// <summary>Group identifier</summary>
		public override long ID => id;
		public override string Title => default;
	}
	/// <summary>Info about a group		<para>See <a href="https://corefork.telegram.org/constructor/chat"/></para></summary>
	[TLDef(0x41CBF256)]
	public partial class Chat : ChatBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>ID of the group</summary>
		public long id;
		/// <summary>Title</summary>
		public string title;
		/// <summary>Chat photo</summary>
		public ChatPhoto photo;
		/// <summary>Participant count</summary>
		public int participants_count;
		/// <summary>Date of creation of the group</summary>
		public DateTime date;
		/// <summary>Used in basic groups to reorder updates and make sure that all of them were received.</summary>
		public int version;
		/// <summary>Means this chat was <a href="https://corefork.telegram.org/api/channel">upgraded</a> to a supergroup</summary>
		[IfFlag(6)] public InputChannelBase migrated_to;
		/// <summary><a href="https://corefork.telegram.org/api/rights">Admin rights</a> of the user in the group</summary>
		[IfFlag(14)] public ChatAdminRights admin_rights;
		/// <summary><a href="https://corefork.telegram.org/api/rights">Default banned rights</a> of all users in the group</summary>
		[IfFlag(18)] public ChatBannedRights default_banned_rights;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the current user is the creator of the group</summary>
			creator = 0x1,
			/// <summary>Whether the current user has left the group</summary>
			left = 0x4,
			/// <summary>Whether the group was <a href="https://corefork.telegram.org/api/channel">migrated</a></summary>
			deactivated = 0x20,
			/// <summary>Field <see cref="migrated_to"/> has a value</summary>
			has_migrated_to = 0x40,
			/// <summary>Field <see cref="admin_rights"/> has a value</summary>
			has_admin_rights = 0x4000,
			/// <summary>Field <see cref="default_banned_rights"/> has a value</summary>
			has_default_banned_rights = 0x40000,
			/// <summary>Whether a group call is currently active</summary>
			call_active = 0x800000,
			/// <summary>Whether there's anyone in the group call</summary>
			call_not_empty = 0x1000000,
			/// <summary>Whether this group is <a href="https://telegram.org/blog/protected-content-delete-by-date-and-more">protected</a>, thus does not allow forwarding messages from it</summary>
			noforwards = 0x2000000,
		}

		/// <summary>ID of the group</summary>
		public override long ID => id;
		/// <summary>Title</summary>
		public override string Title => title;
	}
	/// <summary>A group to which the user has no access. E.g., because the user was kicked from the group.		<para>See <a href="https://corefork.telegram.org/constructor/chatForbidden"/></para></summary>
	[TLDef(0x6592A1A7)]
	public partial class ChatForbidden : ChatBase
	{
		/// <summary>User identifier</summary>
		public long id;
		/// <summary>Group name</summary>
		public string title;

		/// <summary>User identifier</summary>
		public override long ID => id;
		/// <summary>Group name</summary>
		public override string Title => title;
	}
	/// <summary>Channel/supergroup info		<para>See <a href="https://corefork.telegram.org/constructor/channel"/></para></summary>
	[TLDef(0x8261AC61)]
	public partial class Channel : ChatBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>ID of the channel</summary>
		public long id;
		/// <summary>Access hash</summary>
		[IfFlag(13)] public long access_hash;
		/// <summary>Title</summary>
		public string title;
		/// <summary>Username</summary>
		[IfFlag(6)] public string username;
		/// <summary>Profile photo</summary>
		public ChatPhoto photo;
		/// <summary>Date when the user joined the supergroup/channel, or if the user isn't a member, its creation date</summary>
		public DateTime date;
		/// <summary>Contains the reason why access to this channel must be restricted.</summary>
		[IfFlag(9)] public RestrictionReason[] restriction_reason;
		/// <summary>Admin rights of the user in this channel (see <a href="https://corefork.telegram.org/api/rights">rights</a>)</summary>
		[IfFlag(14)] public ChatAdminRights admin_rights;
		/// <summary>Banned rights of the user in this channel (see <a href="https://corefork.telegram.org/api/rights">rights</a>)</summary>
		[IfFlag(15)] public ChatBannedRights banned_rights;
		/// <summary>Default chat rights (see <a href="https://corefork.telegram.org/api/rights">rights</a>)</summary>
		[IfFlag(18)] public ChatBannedRights default_banned_rights;
		/// <summary>Participant count</summary>
		[IfFlag(17)] public int participants_count;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the current user is the creator of this channel</summary>
			creator = 0x1,
			/// <summary>Whether the current user has left this channel</summary>
			left = 0x4,
			/// <summary>Is this a channel?</summary>
			broadcast = 0x20,
			/// <summary>Field <see cref="username"/> has a value</summary>
			has_username = 0x40,
			/// <summary>Is this channel verified by telegram?</summary>
			verified = 0x80,
			/// <summary>Is this a supergroup?</summary>
			megagroup = 0x100,
			/// <summary>Whether viewing/writing in this channel for a reason (see <c>restriction_reason</c></summary>
			restricted = 0x200,
			/// <summary>Whether signatures are enabled (channels)</summary>
			signatures = 0x800,
			/// <summary>See <a href="https://corefork.telegram.org/api/min">min</a></summary>
			min = 0x1000,
			/// <summary>Field <see cref="access_hash"/> has a value</summary>
			has_access_hash = 0x2000,
			/// <summary>Field <see cref="admin_rights"/> has a value</summary>
			has_admin_rights = 0x4000,
			/// <summary>Field <see cref="banned_rights"/> has a value</summary>
			has_banned_rights = 0x8000,
			/// <summary>Field <see cref="participants_count"/> has a value</summary>
			has_participants_count = 0x20000,
			/// <summary>Field <see cref="default_banned_rights"/> has a value</summary>
			has_default_banned_rights = 0x40000,
			/// <summary>This channel/supergroup is probably a scam</summary>
			scam = 0x80000,
			/// <summary>Whether this channel has a private join link</summary>
			has_link = 0x100000,
			/// <summary>Whether this chanel has a geoposition</summary>
			has_geo = 0x200000,
			/// <summary>Whether slow mode is enabled for groups to prevent flood in chat</summary>
			slowmode_enabled = 0x400000,
			/// <summary>Whether a group call or livestream is currently active</summary>
			call_active = 0x800000,
			/// <summary>Whether there's anyone in the group call or livestream</summary>
			call_not_empty = 0x1000000,
			/// <summary>If set, this <a href="https://corefork.telegram.org/api/channel">supergroup/channel</a> was reported by many users as a fake or scam: be careful when interacting with it.</summary>
			fake = 0x2000000,
			/// <summary>Whether this <a href="https://corefork.telegram.org/api/channel">supergroup</a> is a gigagroup</summary>
			gigagroup = 0x4000000,
			/// <summary>Whether this channel or group is <a href="https://telegram.org/blog/protected-content-delete-by-date-and-more">protected</a>, thus does not allow forwarding messages from it</summary>
			noforwards = 0x8000000,
			join_to_send = 0x10000000,
			join_request = 0x20000000,
		}

		/// <summary>ID of the channel</summary>
		public override long ID => id;
		/// <summary>Title</summary>
		public override string Title => title;
	}
	/// <summary>Indicates a channel/supergroup we can't access because we were banned, or for some other reason.		<para>See <a href="https://corefork.telegram.org/constructor/channelForbidden"/></para></summary>
	[TLDef(0x17D493D5)]
	public partial class ChannelForbidden : ChatBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Channel ID</summary>
		public long id;
		/// <summary>Access hash</summary>
		public long access_hash;
		/// <summary>Title</summary>
		public string title;
		/// <summary>The ban is valid until the specified date</summary>
		[IfFlag(16)] public DateTime until_date;

		[Flags] public enum Flags : uint
		{
			/// <summary>Is this a channel</summary>
			broadcast = 0x20,
			/// <summary>Is this a supergroup</summary>
			megagroup = 0x100,
			/// <summary>Field <see cref="until_date"/> has a value</summary>
			has_until_date = 0x10000,
		}

		/// <summary>Channel ID</summary>
		public override long ID => id;
		/// <summary>Title</summary>
		public override string Title => title;
	}

	/// <summary>Full info about a <a href="https://corefork.telegram.org/api/channel#channels">channel</a>, <a href="https://corefork.telegram.org/api/channel#supergroups">supergroup</a>, <a href="https://corefork.telegram.org/api/channel#gigagroups">gigagroup</a> or <a href="https://corefork.telegram.org/api/channel#basic-groups">basic group</a>.		<para>Derived classes: <see cref="ChatFull"/>, <see cref="ChannelFull"/></para>		<para>See <a href="https://corefork.telegram.org/type/ChatFull"/></para></summary>
	public abstract partial class ChatFullBase : IObject
	{
		/// <summary>ID of the chat</summary>
		public abstract long ID { get; }
		/// <summary>About string for this chat</summary>
		public abstract string About { get; }
		/// <summary>Chat photo</summary>
		public abstract PhotoBase ChatPhoto { get; }
		/// <summary>Notification settings</summary>
		public abstract PeerNotifySettings NotifySettings { get; }
		/// <summary>Chat invite</summary>
		public abstract ExportedChatInvite ExportedInvite { get; }
		/// <summary>Info about bots that are in this chat</summary>
		public abstract BotInfo[] BotInfo { get; }
		/// <summary>Message ID of the last <a href="https://corefork.telegram.org/api/pin">pinned message</a></summary>
		public abstract int PinnedMsg { get; }
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		public abstract int Folder { get; }
		/// <summary>Group call information</summary>
		public abstract InputGroupCall Call { get; }
		/// <summary>Time-To-Live of messages sent by the current user to this chat</summary>
		public abstract int TtlPeriod { get; }
		/// <summary>When using <a href="https://corefork.telegram.org/method/phone.getGroupCallJoinAs">phone.getGroupCallJoinAs</a> to get a list of peers that can be used to join a group call, this field indicates the peer that should be selected by default.</summary>
		public abstract Peer GroupcallDefaultJoinAs { get; }
		/// <summary>Emoji representing a specific chat theme</summary>
		public abstract string ThemeEmoticon { get; }
		/// <summary>Pending <a href="https://corefork.telegram.org/api/invites#join-requests">join requests »</a></summary>
		public abstract int RequestsPending { get; }
		/// <summary>IDs of users who requested to join recently</summary>
		public abstract long[] RecentRequesters { get; }
		/// <summary>Allowed <a href="https://corefork.telegram.org/api/reactions">message reactions »</a></summary>
		public abstract string[] AvailableReactions { get; }
	}
	/// <summary>Full info about a <a href="https://corefork.telegram.org/api/channel#basic-groups">basic group</a>.		<para>See <a href="https://corefork.telegram.org/constructor/chatFull"/></para></summary>
	[TLDef(0xD18EE226)]
	public partial class ChatFull : ChatFullBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>ID of the chat</summary>
		public long id;
		/// <summary>About string for this chat</summary>
		public string about;
		/// <summary>Participant list</summary>
		public ChatParticipantsBase participants;
		/// <summary>Chat photo</summary>
		[IfFlag(2)] public PhotoBase chat_photo;
		/// <summary>Notification settings</summary>
		public PeerNotifySettings notify_settings;
		/// <summary>Chat invite</summary>
		[IfFlag(13)] public ExportedChatInvite exported_invite;
		/// <summary>Info about bots that are in this chat</summary>
		[IfFlag(3)] public BotInfo[] bot_info;
		/// <summary>Message ID of the last <a href="https://corefork.telegram.org/api/pin">pinned message</a></summary>
		[IfFlag(6)] public int pinned_msg_id;
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		[IfFlag(11)] public int folder_id;
		/// <summary>Group call information</summary>
		[IfFlag(12)] public InputGroupCall call;
		/// <summary>Time-To-Live of messages sent by the current user to this chat</summary>
		[IfFlag(14)] public int ttl_period;
		/// <summary>When using <a href="https://corefork.telegram.org/method/phone.getGroupCallJoinAs">phone.getGroupCallJoinAs</a> to get a list of peers that can be used to join a group call, this field indicates the peer that should be selected by default.</summary>
		[IfFlag(15)] public Peer groupcall_default_join_as;
		/// <summary>Emoji representing a specific chat theme</summary>
		[IfFlag(16)] public string theme_emoticon;
		/// <summary>Pending <a href="https://corefork.telegram.org/api/invites#join-requests">join requests »</a></summary>
		[IfFlag(17)] public int requests_pending;
		/// <summary>IDs of users who requested to join recently</summary>
		[IfFlag(17)] public long[] recent_requesters;
		/// <summary>Allowed <a href="https://corefork.telegram.org/api/reactions">message reactions »</a></summary>
		[IfFlag(18)] public string[] available_reactions;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="chat_photo"/> has a value</summary>
			has_chat_photo = 0x4,
			/// <summary>Field <see cref="bot_info"/> has a value</summary>
			has_bot_info = 0x8,
			/// <summary>Field <see cref="pinned_msg_id"/> has a value</summary>
			has_pinned_msg_id = 0x40,
			/// <summary>Can we change the username of this chat</summary>
			can_set_username = 0x80,
			/// <summary>Whether <a href="https://corefork.telegram.org/api/scheduled-messages">scheduled messages</a> are available</summary>
			has_scheduled = 0x100,
			/// <summary>Field <see cref="folder_id"/> has a value</summary>
			has_folder_id = 0x800,
			/// <summary>Field <see cref="call"/> has a value</summary>
			has_call = 0x1000,
			/// <summary>Field <see cref="exported_invite"/> has a value</summary>
			has_exported_invite = 0x2000,
			/// <summary>Field <see cref="ttl_period"/> has a value</summary>
			has_ttl_period = 0x4000,
			/// <summary>Field <see cref="groupcall_default_join_as"/> has a value</summary>
			has_groupcall_default_join_as = 0x8000,
			/// <summary>Field <see cref="theme_emoticon"/> has a value</summary>
			has_theme_emoticon = 0x10000,
			/// <summary>Field <see cref="requests_pending"/> has a value</summary>
			has_requests_pending = 0x20000,
			/// <summary>Field <see cref="available_reactions"/> has a value</summary>
			has_available_reactions = 0x40000,
		}

		/// <summary>ID of the chat</summary>
		public override long ID => id;
		/// <summary>About string for this chat</summary>
		public override string About => about;
		/// <summary>Chat photo</summary>
		public override PhotoBase ChatPhoto => chat_photo;
		/// <summary>Notification settings</summary>
		public override PeerNotifySettings NotifySettings => notify_settings;
		/// <summary>Chat invite</summary>
		public override ExportedChatInvite ExportedInvite => exported_invite;
		/// <summary>Info about bots that are in this chat</summary>
		public override BotInfo[] BotInfo => bot_info;
		/// <summary>Message ID of the last <a href="https://corefork.telegram.org/api/pin">pinned message</a></summary>
		public override int PinnedMsg => pinned_msg_id;
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		public override int Folder => folder_id;
		/// <summary>Group call information</summary>
		public override InputGroupCall Call => call;
		/// <summary>Time-To-Live of messages sent by the current user to this chat</summary>
		public override int TtlPeriod => ttl_period;
		/// <summary>When using <a href="https://corefork.telegram.org/method/phone.getGroupCallJoinAs">phone.getGroupCallJoinAs</a> to get a list of peers that can be used to join a group call, this field indicates the peer that should be selected by default.</summary>
		public override Peer GroupcallDefaultJoinAs => groupcall_default_join_as;
		/// <summary>Emoji representing a specific chat theme</summary>
		public override string ThemeEmoticon => theme_emoticon;
		/// <summary>Pending <a href="https://corefork.telegram.org/api/invites#join-requests">join requests »</a></summary>
		public override int RequestsPending => requests_pending;
		/// <summary>IDs of users who requested to join recently</summary>
		public override long[] RecentRequesters => recent_requesters;
		/// <summary>Allowed <a href="https://corefork.telegram.org/api/reactions">message reactions »</a></summary>
		public override string[] AvailableReactions => available_reactions;
	}
	/// <summary>Full info about a <a href="https://corefork.telegram.org/api/channel#channels">channel</a>, <a href="https://corefork.telegram.org/api/channel#supergroups">supergroup</a> or <a href="https://corefork.telegram.org/api/channel#gigagroups">gigagroup</a>.		<para>See <a href="https://corefork.telegram.org/constructor/channelFull"/></para></summary>
	[TLDef(0xEA68A619)]
	public partial class ChannelFull : ChatFullBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		public Flags2 flags2;
		/// <summary>ID of the channel</summary>
		public long id;
		/// <summary>Info about the channel</summary>
		public string about;
		/// <summary>Number of participants of the channel</summary>
		[IfFlag(0)] public int participants_count;
		/// <summary>Number of channel admins</summary>
		[IfFlag(1)] public int admins_count;
		/// <summary>Number of users <a href="https://corefork.telegram.org/api/rights">kicked</a> from the channel</summary>
		[IfFlag(2)] public int kicked_count;
		/// <summary>Number of users <a href="https://corefork.telegram.org/api/rights">banned</a> from the channel</summary>
		[IfFlag(2)] public int banned_count;
		/// <summary>Number of users currently online</summary>
		[IfFlag(13)] public int online_count;
		/// <summary>Position up to which all incoming messages are read.</summary>
		public int read_inbox_max_id;
		/// <summary>Position up to which all outgoing messages are read.</summary>
		public int read_outbox_max_id;
		/// <summary>Count of unread messages</summary>
		public int unread_count;
		/// <summary>Channel picture</summary>
		public PhotoBase chat_photo;
		/// <summary>Notification settings</summary>
		public PeerNotifySettings notify_settings;
		/// <summary>Invite link</summary>
		[IfFlag(23)] public ExportedChatInvite exported_invite;
		/// <summary>Info about bots in the channel/supergroup</summary>
		public BotInfo[] bot_info;
		/// <summary>The chat ID from which this group was <a href="https://corefork.telegram.org/api/channel">migrated</a></summary>
		[IfFlag(4)] public long migrated_from_chat_id;
		/// <summary>The message ID in the original chat at which this group was <a href="https://corefork.telegram.org/api/channel">migrated</a></summary>
		[IfFlag(4)] public int migrated_from_max_id;
		/// <summary>Message ID of the last <a href="https://corefork.telegram.org/api/pin">pinned message</a></summary>
		[IfFlag(5)] public int pinned_msg_id;
		/// <summary>Associated stickerset</summary>
		[IfFlag(8)] public StickerSet stickerset;
		/// <summary>Identifier of a maximum unavailable message in a channel due to hidden history.</summary>
		[IfFlag(9)] public int available_min_id;
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		[IfFlag(11)] public int folder_id;
		/// <summary>ID of the linked <a href="https://corefork.telegram.org/api/discussion">discussion chat</a> for channels</summary>
		[IfFlag(14)] public long linked_chat_id;
		/// <summary>Location of the geogroup</summary>
		[IfFlag(15)] public ChannelLocation location;
		/// <summary>If specified, users in supergroups will only be able to send one message every <c>slowmode_seconds</c> seconds</summary>
		[IfFlag(17)] public int slowmode_seconds;
		/// <summary>Indicates when the user will be allowed to send another message in the supergroup (unixtime)</summary>
		[IfFlag(18)] public DateTime slowmode_next_send_date;
		/// <summary>If set, specifies the DC to use for fetching channel statistics</summary>
		[IfFlag(12)] public int stats_dc;
		/// <summary>Latest <a href="https://corefork.telegram.org/api/updates">PTS</a> for this channel</summary>
		public int pts;
		/// <summary>Livestream or group call information</summary>
		[IfFlag(21)] public InputGroupCall call;
		/// <summary>Time-To-Live of messages in this channel or supergroup</summary>
		[IfFlag(24)] public int ttl_period;
		/// <summary>A list of <a href="https://corefork.telegram.org/api/config#suggestions">suggested actions</a> for the supergroup admin, <a href="https://corefork.telegram.org/api/config#suggestions">see here for more info »</a>.</summary>
		[IfFlag(25)] public string[] pending_suggestions;
		/// <summary>When using <a href="https://corefork.telegram.org/method/phone.getGroupCallJoinAs">phone.getGroupCallJoinAs</a> to get a list of peers that can be used to join a group call, this field indicates the peer that should be selected by default.</summary>
		[IfFlag(26)] public Peer groupcall_default_join_as;
		/// <summary>Emoji representing a specific chat theme</summary>
		[IfFlag(27)] public string theme_emoticon;
		/// <summary>Pending <a href="https://corefork.telegram.org/api/invites#join-requests">join requests »</a></summary>
		[IfFlag(28)] public int requests_pending;
		/// <summary>IDs of users who requested to join recently</summary>
		[IfFlag(28)] public long[] recent_requesters;
		/// <summary>Default peer used for sending messages to this channel</summary>
		[IfFlag(29)] public Peer default_send_as;
		/// <summary>Allowed <a href="https://corefork.telegram.org/api/reactions">message reactions »</a></summary>
		[IfFlag(30)] public string[] available_reactions;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="participants_count"/> has a value</summary>
			has_participants_count = 0x1,
			/// <summary>Field <see cref="admins_count"/> has a value</summary>
			has_admins_count = 0x2,
			/// <summary>Field <see cref="kicked_count"/> has a value</summary>
			has_kicked_count = 0x4,
			/// <summary>Can we view the participant list?</summary>
			can_view_participants = 0x8,
			/// <summary>Field <see cref="migrated_from_chat_id"/> has a value</summary>
			has_migrated_from_chat_id = 0x10,
			/// <summary>Field <see cref="pinned_msg_id"/> has a value</summary>
			has_pinned_msg_id = 0x20,
			/// <summary>Can we set the channel's username?</summary>
			can_set_username = 0x40,
			/// <summary>Can we <a href="https://corefork.telegram.org/method/channels.setStickers">associate</a> a stickerpack to the supergroup?</summary>
			can_set_stickers = 0x80,
			/// <summary>Field <see cref="stickerset"/> has a value</summary>
			has_stickerset = 0x100,
			/// <summary>Field <see cref="available_min_id"/> has a value</summary>
			has_available_min_id = 0x200,
			/// <summary>Is the history before we joined hidden to us?</summary>
			hidden_prehistory = 0x400,
			/// <summary>Field <see cref="folder_id"/> has a value</summary>
			has_folder_id = 0x800,
			/// <summary>Field <see cref="stats_dc"/> has a value</summary>
			has_stats_dc = 0x1000,
			/// <summary>Field <see cref="online_count"/> has a value</summary>
			has_online_count = 0x2000,
			/// <summary>Field <see cref="linked_chat_id"/> has a value</summary>
			has_linked_chat_id = 0x4000,
			/// <summary>Field <see cref="location"/> has a value</summary>
			has_location = 0x8000,
			/// <summary>Can we set the geolocation of this group (for geogroups)</summary>
			can_set_location = 0x10000,
			/// <summary>Field <see cref="slowmode_seconds"/> has a value</summary>
			has_slowmode_seconds = 0x20000,
			/// <summary>Field <see cref="slowmode_next_send_date"/> has a value</summary>
			has_slowmode_next_send_date = 0x40000,
			/// <summary>Whether scheduled messages are available</summary>
			has_scheduled = 0x80000,
			/// <summary>Can the user view <a href="https://corefork.telegram.org/api/stats">channel/supergroup statistics</a></summary>
			can_view_stats = 0x100000,
			/// <summary>Field <see cref="call"/> has a value</summary>
			has_call = 0x200000,
			/// <summary>Whether any anonymous admin of this supergroup was blocked: if set, you won't receive messages from anonymous group admins in <a href="https://corefork.telegram.org/api/discussion">discussion replies via @replies</a></summary>
			blocked = 0x400000,
			/// <summary>Field <see cref="exported_invite"/> has a value</summary>
			has_exported_invite = 0x800000,
			/// <summary>Field <see cref="ttl_period"/> has a value</summary>
			has_ttl_period = 0x1000000,
			/// <summary>Field <see cref="pending_suggestions"/> has a value</summary>
			has_pending_suggestions = 0x2000000,
			/// <summary>Field <see cref="groupcall_default_join_as"/> has a value</summary>
			has_groupcall_default_join_as = 0x4000000,
			/// <summary>Field <see cref="theme_emoticon"/> has a value</summary>
			has_theme_emoticon = 0x8000000,
			/// <summary>Field <see cref="requests_pending"/> has a value</summary>
			has_requests_pending = 0x10000000,
			/// <summary>Field <see cref="default_send_as"/> has a value</summary>
			has_default_send_as = 0x20000000,
			/// <summary>Field <see cref="available_reactions"/> has a value</summary>
			has_available_reactions = 0x40000000,
		}

		[Flags] public enum Flags2 : uint
		{
			can_delete_channel = 0x1,
		}

		/// <summary>ID of the channel</summary>
		public override long ID => id;
		/// <summary>Info about the channel</summary>
		public override string About => about;
		/// <summary>Channel picture</summary>
		public override PhotoBase ChatPhoto => chat_photo;
		/// <summary>Notification settings</summary>
		public override PeerNotifySettings NotifySettings => notify_settings;
		/// <summary>Invite link</summary>
		public override ExportedChatInvite ExportedInvite => exported_invite;
		/// <summary>Info about bots in the channel/supergroup</summary>
		public override BotInfo[] BotInfo => bot_info;
		/// <summary>Message ID of the last <a href="https://corefork.telegram.org/api/pin">pinned message</a></summary>
		public override int PinnedMsg => pinned_msg_id;
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		public override int Folder => folder_id;
		/// <summary>Livestream or group call information</summary>
		public override InputGroupCall Call => call;
		/// <summary>Time-To-Live of messages in this channel or supergroup</summary>
		public override int TtlPeriod => ttl_period;
		/// <summary>When using <a href="https://corefork.telegram.org/method/phone.getGroupCallJoinAs">phone.getGroupCallJoinAs</a> to get a list of peers that can be used to join a group call, this field indicates the peer that should be selected by default.</summary>
		public override Peer GroupcallDefaultJoinAs => groupcall_default_join_as;
		/// <summary>Emoji representing a specific chat theme</summary>
		public override string ThemeEmoticon => theme_emoticon;
		/// <summary>Pending <a href="https://corefork.telegram.org/api/invites#join-requests">join requests »</a></summary>
		public override int RequestsPending => requests_pending;
		/// <summary>IDs of users who requested to join recently</summary>
		public override long[] RecentRequesters => recent_requesters;
		/// <summary>Allowed <a href="https://corefork.telegram.org/api/reactions">message reactions »</a></summary>
		public override string[] AvailableReactions => available_reactions;
	}

	/// <summary>Details of a group member.		<para>Derived classes: <see cref="ChatParticipant"/>, <see cref="ChatParticipantCreator"/>, <see cref="ChatParticipantAdmin"/></para>		<para>See <a href="https://corefork.telegram.org/type/ChatParticipant"/></para></summary>
	public abstract partial class ChatParticipantBase : IObject
	{
		/// <summary>Member user ID</summary>
		public abstract long UserId { get; }
	}
	/// <summary>Group member.		<para>See <a href="https://corefork.telegram.org/constructor/chatParticipant"/></para></summary>
	[TLDef(0xC02D4007)]
	public partial class ChatParticipant : ChatParticipantBase
	{
		/// <summary>Member user ID</summary>
		public long user_id;
		/// <summary>ID of the user that added the member to the group</summary>
		public long inviter_id;
		/// <summary>Date added to the group</summary>
		public DateTime date;

		/// <summary>Member user ID</summary>
		public override long UserId => user_id;
	}
	/// <summary>Represents the creator of the group		<para>See <a href="https://corefork.telegram.org/constructor/chatParticipantCreator"/></para></summary>
	[TLDef(0xE46BCEE4)]
	public partial class ChatParticipantCreator : ChatParticipantBase
	{
		/// <summary>ID of the user that created the group</summary>
		public long user_id;

		/// <summary>ID of the user that created the group</summary>
		public override long UserId => user_id;
	}
	/// <summary>Chat admin		<para>See <a href="https://corefork.telegram.org/constructor/chatParticipantAdmin"/></para></summary>
	[TLDef(0xA0933F5B)]
	public partial class ChatParticipantAdmin : ChatParticipant
	{
	}

	/// <summary>Object contains info on group members.		<para>Derived classes: <see cref="ChatParticipantsForbidden"/>, <see cref="ChatParticipants"/></para>		<para>See <a href="https://corefork.telegram.org/type/ChatParticipants"/></para></summary>
	public abstract partial class ChatParticipantsBase : IObject
	{
		/// <summary>Group ID</summary>
		public abstract long ChatId { get; }
	}
	/// <summary>Info on members is unavailable		<para>See <a href="https://corefork.telegram.org/constructor/chatParticipantsForbidden"/></para></summary>
	[TLDef(0x8763D3E1)]
	public partial class ChatParticipantsForbidden : ChatParticipantsBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Group ID</summary>
		public long chat_id;
		/// <summary>Info about the group membership of the current user</summary>
		[IfFlag(0)] public ChatParticipantBase self_participant;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="self_participant"/> has a value</summary>
			has_self_participant = 0x1,
		}

		/// <summary>Group ID</summary>
		public override long ChatId => chat_id;
	}
	/// <summary>Group members.		<para>See <a href="https://corefork.telegram.org/constructor/chatParticipants"/></para></summary>
	[TLDef(0x3CBC93F8)]
	public partial class ChatParticipants : ChatParticipantsBase
	{
		/// <summary>Group identifier</summary>
		public long chat_id;
		/// <summary>List of group members</summary>
		public ChatParticipantBase[] participants;
		/// <summary>Group version number</summary>
		public int version;

		/// <summary>Group identifier</summary>
		public override long ChatId => chat_id;
	}

	/// <summary>Group profile photo.		<para>See <a href="https://corefork.telegram.org/constructor/chatPhoto"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/chatPhotoEmpty">chatPhotoEmpty</a></remarks>
	[TLDef(0x1C6E1C11)]
	public class ChatPhoto : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Photo ID</summary>
		public long photo_id;
		/// <summary><a href="https://corefork.telegram.org/api/files#stripped-thumbnails">Stripped thumbnail</a></summary>
		[IfFlag(1)] public byte[] stripped_thumb;
		/// <summary>DC where this photo is stored</summary>
		public int dc_id;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the user has an animated profile picture</summary>
			has_video = 0x1,
			/// <summary>Field <see cref="stripped_thumb"/> has a value</summary>
			has_stripped_thumb = 0x2,
		}
	}

	/// <summary>Object describing a message.		<para>Derived classes: <see cref="MessageEmpty"/>, <see cref="Message"/>, <see cref="MessageService"/></para>		<para>See <a href="https://corefork.telegram.org/type/Message"/></para></summary>
	public abstract class MessageBase : IObject
	{
		/// <summary>ID of the message</summary>
		public abstract int ID { get; }
		/// <summary>ID of the sender of the message</summary>
		public abstract Peer From { get; }
		/// <summary>Peer ID, the chat where this message was sent</summary>
		public abstract Peer Peer { get; }
		/// <summary>Reply information</summary>
		public abstract MessageReplyHeader ReplyTo { get; }
		/// <summary>Date of the message</summary>
		public abstract DateTime Date { get; }
		/// <summary>Time To Live of the message, once message.date+message.ttl_period === time(), the message will be deleted on the server, and must be deleted locally as well.</summary>
		public abstract int TtlPeriod { get; }
	}
	/// <summary>Empty constructor, non-existent message.		<para>See <a href="https://corefork.telegram.org/constructor/messageEmpty"/></para></summary>
	[TLDef(0x90A6CA84)]
	public class MessageEmpty : MessageBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Message identifier</summary>
		public int id;
		/// <summary>Peer ID, the chat where this message was sent</summary>
		[IfFlag(0)] public Peer peer_id;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="peer_id"/> has a value</summary>
			has_peer_id = 0x1,
		}

		/// <summary>Message identifier</summary>
		public override int ID => id;
		public override Peer From => default;
		/// <summary>Peer ID, the chat where this message was sent</summary>
		public override Peer Peer => peer_id;
		public override MessageReplyHeader ReplyTo => default;
		public override DateTime Date => default;
		public override int TtlPeriod => default;
	}
	/// <summary>A message		<para>See <a href="https://corefork.telegram.org/constructor/message"/></para></summary>
	[TLDef(0x38116EE0)]
	public class Message : MessageBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>ID of the message</summary>
		public int id;
		/// <summary>ID of the sender of the message</summary>
		[IfFlag(8)] public Peer from_id;
		/// <summary>Peer ID, the chat where this message was sent</summary>
		public Peer peer_id;
		/// <summary>Info about forwarded messages</summary>
		[IfFlag(2)] public MessageFwdHeader fwd_from;
		/// <summary>ID of the inline bot that generated the message</summary>
		[IfFlag(11)] public long via_bot_id;
		/// <summary>Reply information</summary>
		[IfFlag(3)] public MessageReplyHeader reply_to;
		/// <summary>Date of the message</summary>
		public DateTime date;
		/// <summary>The message</summary>
		public string message;
		/// <summary>Media attachment</summary>
		[IfFlag(9)] public MessageMedia media;
		/// <summary>Reply markup (bot/inline keyboards)</summary>
		[IfFlag(6)] public ReplyMarkup reply_markup;
		/// <summary>Message <a href="https://corefork.telegram.org/api/entities">entities</a> for styled text</summary>
		[IfFlag(7)] public MessageEntity[] entities;
		/// <summary>View count for channel posts</summary>
		[IfFlag(10)] public int views;
		/// <summary>Forward counter</summary>
		[IfFlag(10)] public int forwards;
		/// <summary>Info about <a href="https://corefork.telegram.org/api/threads">post comments (for channels) or message replies (for groups)</a></summary>
		[IfFlag(23)] public MessageReplies replies;
		/// <summary>Last edit date of this message</summary>
		[IfFlag(15)] public DateTime edit_date;
		/// <summary>Name of the author of this message for channel posts (with signatures enabled)</summary>
		[IfFlag(16)] public string post_author;
		/// <summary>Multiple media messages sent using <a href="https://corefork.telegram.org/method/messages.sendMultiMedia">messages.sendMultiMedia</a> with the same grouped ID indicate an <a href="https://corefork.telegram.org/api/files#albums-grouped-media">album or media group</a></summary>
		[IfFlag(17)] public long grouped_id;
		/// <summary>Reactions to this message</summary>
		[IfFlag(20)] public MessageReactions reactions;
		/// <summary>Contains the reason why access to this message must be restricted.</summary>
		[IfFlag(22)] public RestrictionReason[] restriction_reason;
		/// <summary>Time To Live of the message, once message.date+message.ttl_period === time(), the message will be deleted on the server, and must be deleted locally as well.</summary>
		[IfFlag(25)] public int ttl_period;

		[Flags] public enum Flags : uint
		{
			/// <summary>Is this an outgoing message</summary>
			out_ = 0x2,
			/// <summary>Field <see cref="fwd_from"/> has a value</summary>
			has_fwd_from = 0x4,
			/// <summary>Field <see cref="reply_to"/> has a value</summary>
			has_reply_to = 0x8,
			/// <summary>Whether we were <a href="https://corefork.telegram.org/api/mentions">mentioned</a> in this message</summary>
			mentioned = 0x10,
			/// <summary>Whether there are unread media attachments in this message</summary>
			media_unread = 0x20,
			/// <summary>Field <see cref="reply_markup"/> has a value</summary>
			has_reply_markup = 0x40,
			/// <summary>Field <see cref="entities"/> has a value</summary>
			has_entities = 0x80,
			/// <summary>Field <see cref="from_id"/> has a value</summary>
			has_from_id = 0x100,
			/// <summary>Field <see cref="media"/> has a value</summary>
			has_media = 0x200,
			/// <summary>Field <see cref="views"/> has a value</summary>
			has_views = 0x400,
			/// <summary>Field <see cref="via_bot_id"/> has a value</summary>
			has_via_bot_id = 0x800,
			/// <summary>Whether this is a silent message (no notification triggered)</summary>
			silent = 0x2000,
			/// <summary>Whether this is a channel post</summary>
			post = 0x4000,
			/// <summary>Field <see cref="edit_date"/> has a value</summary>
			has_edit_date = 0x8000,
			/// <summary>Field <see cref="post_author"/> has a value</summary>
			has_post_author = 0x10000,
			/// <summary>Field <see cref="grouped_id"/> has a value</summary>
			has_grouped_id = 0x20000,
			/// <summary>Whether this is a <a href="https://corefork.telegram.org/api/scheduled-messages">scheduled message</a></summary>
			from_scheduled = 0x40000,
			/// <summary>This is a legacy message: it has to be refetched with the new layer</summary>
			legacy = 0x80000,
			/// <summary>Field <see cref="reactions"/> has a value</summary>
			has_reactions = 0x100000,
			/// <summary>Whether the message should be shown as not modified to the user, even if an edit date is present</summary>
			edit_hide = 0x200000,
			/// <summary>Field <see cref="restriction_reason"/> has a value</summary>
			has_restriction_reason = 0x400000,
			/// <summary>Field <see cref="replies"/> has a value</summary>
			has_replies = 0x800000,
			/// <summary>Whether this message is <a href="https://corefork.telegram.org/api/pin">pinned</a></summary>
			pinned = 0x1000000,
			/// <summary>Field <see cref="ttl_period"/> has a value</summary>
			has_ttl_period = 0x2000000,
			/// <summary>Whether this message is <a href="https://telegram.org/blog/protected-content-delete-by-date-and-more">protected</a> and thus cannot be forwarded</summary>
			noforwards = 0x4000000,
		}

		/// <summary>ID of the message</summary>
		public override int ID => id;
		/// <summary>ID of the sender of the message</summary>
		public override Peer From => from_id;
		/// <summary>Peer ID, the chat where this message was sent</summary>
		public override Peer Peer => peer_id;
		/// <summary>Reply information</summary>
		public override MessageReplyHeader ReplyTo => reply_to;
		/// <summary>Date of the message</summary>
		public override DateTime Date => date;
		/// <summary>Time To Live of the message, once message.date+message.ttl_period === time(), the message will be deleted on the server, and must be deleted locally as well.</summary>
		public override int TtlPeriod => ttl_period;
	}
	/// <summary>Indicates a service message		<para>See <a href="https://corefork.telegram.org/constructor/messageService"/></para></summary>
	[TLDef(0x2B085862)]
	public class MessageService : MessageBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Message ID</summary>
		public int id;
		/// <summary>ID of the sender of this message</summary>
		[IfFlag(8)] public Peer from_id;
		/// <summary>Sender of service message</summary>
		public Peer peer_id;
		/// <summary>Reply (thread) information</summary>
		[IfFlag(3)] public MessageReplyHeader reply_to;
		/// <summary>Message date</summary>
		public DateTime date;
		/// <summary>Event connected with the service message</summary>
		public MessageAction action;
		/// <summary>Time To Live of the message, once message.date+message.ttl_period === time(), the message will be deleted on the server, and must be deleted locally as well.</summary>
		[IfFlag(25)] public int ttl_period;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the message is outgoing</summary>
			out_ = 0x2,
			/// <summary>Field <see cref="reply_to"/> has a value</summary>
			has_reply_to = 0x8,
			/// <summary>Whether we were mentioned in the message</summary>
			mentioned = 0x10,
			/// <summary>Whether the message contains unread media</summary>
			media_unread = 0x20,
			/// <summary>Field <see cref="from_id"/> has a value</summary>
			has_from_id = 0x100,
			/// <summary>Whether the message is silent</summary>
			silent = 0x2000,
			/// <summary>Whether it's a channel post</summary>
			post = 0x4000,
			/// <summary>This is a legacy message: it has to be refetched with the new layer</summary>
			legacy = 0x80000,
			/// <summary>Field <see cref="ttl_period"/> has a value</summary>
			has_ttl_period = 0x2000000,
		}

		/// <summary>Message ID</summary>
		public override int ID => id;
		/// <summary>ID of the sender of this message</summary>
		public override Peer From => from_id;
		/// <summary>Sender of service message</summary>
		public override Peer Peer => peer_id;
		/// <summary>Reply (thread) information</summary>
		public override MessageReplyHeader ReplyTo => reply_to;
		/// <summary>Message date</summary>
		public override DateTime Date => date;
		/// <summary>Time To Live of the message, once message.date+message.ttl_period === time(), the message will be deleted on the server, and must be deleted locally as well.</summary>
		public override int TtlPeriod => ttl_period;
	}

	/// <summary>Media		<para>Derived classes: <see cref="MessageMediaPhoto"/>, <see cref="MessageMediaGeo"/>, <see cref="MessageMediaContact"/>, <see cref="MessageMediaUnsupported"/>, <see cref="MessageMediaDocument"/>, <see cref="MessageMediaWebPage"/>, <see cref="MessageMediaVenue"/>, <see cref="MessageMediaGame"/>, <see cref="MessageMediaInvoice"/>, <see cref="MessageMediaGeoLive"/>, <see cref="MessageMediaPoll"/>, <see cref="MessageMediaDice"/></para>		<para>See <a href="https://corefork.telegram.org/type/MessageMedia"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messageMediaEmpty">messageMediaEmpty</a></remarks>
	public abstract class MessageMedia : IObject { }
	/// <summary>Attached photo.		<para>See <a href="https://corefork.telegram.org/constructor/messageMediaPhoto"/></para></summary>
	[TLDef(0x695150D7)]
	public class MessageMediaPhoto : MessageMedia
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Photo</summary>
		[IfFlag(0)] public PhotoBase photo;
		/// <summary>Time to live in seconds of self-destructing photo</summary>
		[IfFlag(2)] public int ttl_seconds;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="photo"/> has a value</summary>
			has_photo = 0x1,
			/// <summary>Field <see cref="ttl_seconds"/> has a value</summary>
			has_ttl_seconds = 0x4,
		}
	}
	/// <summary>Attached map.		<para>See <a href="https://corefork.telegram.org/constructor/messageMediaGeo"/></para></summary>
	[TLDef(0x56E0D474)]
	public class MessageMediaGeo : MessageMedia
	{
		/// <summary>GeoPoint</summary>
		public GeoPoint geo;
	}
	/// <summary>Attached contact.		<para>See <a href="https://corefork.telegram.org/constructor/messageMediaContact"/></para></summary>
	[TLDef(0x70322949)]
	public class MessageMediaContact : MessageMedia
	{
		/// <summary>Phone number</summary>
		public string phone_number;
		/// <summary>Contact's first name</summary>
		public string first_name;
		/// <summary>Contact's last name</summary>
		public string last_name;
		/// <summary>VCARD of contact</summary>
		public string vcard;
		/// <summary>User identifier or <c>0</c>, if the user with the given phone number is not registered</summary>
		public long user_id;
	}
	/// <summary>Current version of the client does not support this media type.		<para>See <a href="https://corefork.telegram.org/constructor/messageMediaUnsupported"/></para></summary>
	[TLDef(0x9F84F49E)]
	public class MessageMediaUnsupported : MessageMedia { }
	/// <summary>Document (video, audio, voice, sticker, any media type except photo)		<para>See <a href="https://corefork.telegram.org/constructor/messageMediaDocument"/></para></summary>
	[TLDef(0x9CB070D7)]
	public class MessageMediaDocument : MessageMedia
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Attached document</summary>
		[IfFlag(0)] public DocumentBase document;
		/// <summary>Time to live of self-destructing document</summary>
		[IfFlag(2)] public int ttl_seconds;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="document"/> has a value</summary>
			has_document = 0x1,
			/// <summary>Field <see cref="ttl_seconds"/> has a value</summary>
			has_ttl_seconds = 0x4,
		}
	}
	/// <summary>Preview of webpage		<para>See <a href="https://corefork.telegram.org/constructor/messageMediaWebPage"/></para></summary>
	[TLDef(0xA32DD600)]
	public class MessageMediaWebPage : MessageMedia
	{
		/// <summary>Webpage preview</summary>
		public WebPageBase webpage;
	}
	/// <summary>Venue		<para>See <a href="https://corefork.telegram.org/constructor/messageMediaVenue"/></para></summary>
	[TLDef(0x2EC0533F)]
	public class MessageMediaVenue : MessageMedia
	{
		/// <summary>Geolocation of venue</summary>
		public GeoPoint geo;
		/// <summary>Venue name</summary>
		public string title;
		/// <summary>Address</summary>
		public string address;
		/// <summary>Venue provider: currently only "foursquare" needs to be supported</summary>
		public string provider;
		/// <summary>Venue ID in the provider's database</summary>
		public string venue_id;
		/// <summary>Venue type in the provider's database</summary>
		public string venue_type;
	}
	/// <summary>Telegram game		<para>See <a href="https://corefork.telegram.org/constructor/messageMediaGame"/></para></summary>
	[TLDef(0xFDB19008)]
	public class MessageMediaGame : MessageMedia
	{
		/// <summary>Game</summary>
		public Game game;
	}
	/// <summary>Invoice		<para>See <a href="https://corefork.telegram.org/constructor/messageMediaInvoice"/></para></summary>
	[TLDef(0x84551347)]
	public class MessageMediaInvoice : MessageMedia
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Product name, 1-32 characters</summary>
		public string title;
		/// <summary>Product description, 1-255 characters</summary>
		public string description;
		/// <summary>URL of the product photo for the invoice. Can be a photo of the goods or a marketing image for a service. People like it better when they see what they are paying for.</summary>
		[IfFlag(0)] public WebDocumentBase photo;
		/// <summary>Message ID of receipt: if set, clients should change the text of the first <see cref="KeyboardButtonBuy"/> button always attached to the <see cref="Message"/> to a localized version of the word <c>Receipt</c></summary>
		[IfFlag(2)] public int receipt_msg_id;
		/// <summary>Three-letter ISO 4217 <a href="https://corefork.telegram.org/bots/payments#supported-currencies">currency</a> code</summary>
		public string currency;
		/// <summary>Total price in the smallest units of the currency (integer, not float/double). For example, for a price of <c>US$ 1.45</c> pass <c>amount = 145</c>. See the exp parameter in <a href="https://corefork.telegram.org/bots/payments/currencies.json">currencies.json</a>, it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).</summary>
		public long total_amount;
		/// <summary>Unique bot deep-linking parameter that can be used to generate this invoice</summary>
		public string start_param;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="photo"/> has a value</summary>
			has_photo = 0x1,
			/// <summary>Whether the shipping address was requested</summary>
			shipping_address_requested = 0x2,
			/// <summary>Field <see cref="receipt_msg_id"/> has a value</summary>
			has_receipt_msg_id = 0x4,
			/// <summary>Whether this is an example invoice</summary>
			test = 0x8,
		}
	}
	/// <summary>Indicates a <a href="https://corefork.telegram.org/api/live-location">live geolocation</a>		<para>See <a href="https://corefork.telegram.org/constructor/messageMediaGeoLive"/></para></summary>
	[TLDef(0xB940C666)]
	public class MessageMediaGeoLive : MessageMedia
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Geolocation</summary>
		public GeoPoint geo;
		/// <summary>For <a href="https://corefork.telegram.org/api/live-location">live locations</a>, a direction in which the location moves, in degrees; 1-360</summary>
		[IfFlag(0)] public int heading;
		/// <summary>Validity period of provided geolocation</summary>
		public int period;
		/// <summary>For <a href="https://corefork.telegram.org/api/live-location">live locations</a>, a maximum distance to another chat member for proximity alerts, in meters (0-100000).</summary>
		[IfFlag(1)] public int proximity_notification_radius;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="heading"/> has a value</summary>
			has_heading = 0x1,
			/// <summary>Field <see cref="proximity_notification_radius"/> has a value</summary>
			has_proximity_notification_radius = 0x2,
		}
	}
	/// <summary>Poll		<para>See <a href="https://corefork.telegram.org/constructor/messageMediaPoll"/></para></summary>
	[TLDef(0x4BD6E798)]
	public class MessageMediaPoll : MessageMedia
	{
		/// <summary>The poll</summary>
		public Poll poll;
		/// <summary>The results of the poll</summary>
		public PollResults results;
	}
	/// <summary><a href="https://corefork.telegram.org/api/dice">Dice-based animated sticker</a>		<para>See <a href="https://corefork.telegram.org/constructor/messageMediaDice"/></para></summary>
	[TLDef(0x3F7EE58B)]
	public class MessageMediaDice : MessageMedia
	{
		/// <summary><a href="https://corefork.telegram.org/api/dice">Dice value</a></summary>
		public int value;
		/// <summary>The emoji, for now 🏀, 🎲 and 🎯 are supported</summary>
		public string emoticon;
	}

	/// <summary>Object describing actions connected to a service message.		<para>Derived classes: <see cref="MessageActionChatCreate"/>, <see cref="MessageActionChatEditTitle"/>, <see cref="MessageActionChatEditPhoto"/>, <see cref="MessageActionChatDeletePhoto"/>, <see cref="MessageActionChatAddUser"/>, <see cref="MessageActionChatDeleteUser"/>, <see cref="MessageActionChatJoinedByLink"/>, <see cref="MessageActionChannelCreate"/>, <see cref="MessageActionChatMigrateTo"/>, <see cref="MessageActionChannelMigrateFrom"/>, <see cref="MessageActionPinMessage"/>, <see cref="MessageActionHistoryClear"/>, <see cref="MessageActionGameScore"/>, <see cref="MessageActionPaymentSentMe"/>, <see cref="MessageActionPaymentSent"/>, <see cref="MessageActionPhoneCall"/>, <see cref="MessageActionScreenshotTaken"/>, <see cref="MessageActionCustomAction"/>, <see cref="MessageActionBotAllowed"/>, <see cref="MessageActionSecureValuesSentMe"/>, <see cref="MessageActionSecureValuesSent"/>, <see cref="MessageActionContactSignUp"/>, <see cref="MessageActionGeoProximityReached"/>, <see cref="MessageActionGroupCall"/>, <see cref="MessageActionInviteToGroupCall"/>, <see cref="MessageActionSetMessagesTTL"/>, <see cref="MessageActionGroupCallScheduled"/>, <see cref="MessageActionSetChatTheme"/>, <see cref="MessageActionChatJoinedByRequest"/></para>		<para>See <a href="https://corefork.telegram.org/type/MessageAction"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messageActionEmpty">messageActionEmpty</a></remarks>
	public abstract class MessageAction : IObject { }
	/// <summary>Group created		<para>See <a href="https://corefork.telegram.org/constructor/messageActionChatCreate"/></para></summary>
	[TLDef(0xBD47CBAD)]
	public class MessageActionChatCreate : MessageAction
	{
		/// <summary>Group name</summary>
		public string title;
		/// <summary>List of group members</summary>
		public long[] users;
	}
	/// <summary>Group name changed.		<para>See <a href="https://corefork.telegram.org/constructor/messageActionChatEditTitle"/></para></summary>
	[TLDef(0xB5A1CE5A)]
	public class MessageActionChatEditTitle : MessageAction
	{
		/// <summary>New group name</summary>
		public string title;
	}
	/// <summary>Group profile changed		<para>See <a href="https://corefork.telegram.org/constructor/messageActionChatEditPhoto"/></para></summary>
	[TLDef(0x7FCB13A8)]
	public class MessageActionChatEditPhoto : MessageAction
	{
		/// <summary>New group profile photo</summary>
		public PhotoBase photo;
	}
	/// <summary>Group profile photo removed.		<para>See <a href="https://corefork.telegram.org/constructor/messageActionChatDeletePhoto"/></para></summary>
	[TLDef(0x95E3FBEF)]
	public class MessageActionChatDeletePhoto : MessageAction { }
	/// <summary>New member in the group		<para>See <a href="https://corefork.telegram.org/constructor/messageActionChatAddUser"/></para></summary>
	[TLDef(0x15CEFD00)]
	public class MessageActionChatAddUser : MessageAction
	{
		/// <summary>Users that were invited to the chat</summary>
		public long[] users;
	}
	/// <summary>User left the group.		<para>See <a href="https://corefork.telegram.org/constructor/messageActionChatDeleteUser"/></para></summary>
	[TLDef(0xA43F30CC)]
	public class MessageActionChatDeleteUser : MessageAction
	{
		/// <summary>Leaving user ID</summary>
		public long user_id;
	}
	/// <summary>A user joined the chat via an invite link		<para>See <a href="https://corefork.telegram.org/constructor/messageActionChatJoinedByLink"/></para></summary>
	[TLDef(0x031224C3)]
	public class MessageActionChatJoinedByLink : MessageAction
	{
		/// <summary>ID of the user that created the invite link</summary>
		public long inviter_id;
	}
	/// <summary>The channel was created		<para>See <a href="https://corefork.telegram.org/constructor/messageActionChannelCreate"/></para></summary>
	[TLDef(0x95D2AC92)]
	public class MessageActionChannelCreate : MessageAction
	{
		/// <summary>Original channel/supergroup title</summary>
		public string title;
	}
	/// <summary>Indicates the chat was <a href="https://corefork.telegram.org/api/channel">migrated</a> to the specified supergroup		<para>See <a href="https://corefork.telegram.org/constructor/messageActionChatMigrateTo"/></para></summary>
	[TLDef(0xE1037F92)]
	public class MessageActionChatMigrateTo : MessageAction
	{
		/// <summary>The supergroup it was migrated to</summary>
		public long channel_id;
	}
	/// <summary>Indicates the channel was <a href="https://corefork.telegram.org/api/channel">migrated</a> from the specified chat		<para>See <a href="https://corefork.telegram.org/constructor/messageActionChannelMigrateFrom"/></para></summary>
	[TLDef(0xEA3948E9)]
	public class MessageActionChannelMigrateFrom : MessageAction
	{
		/// <summary>The old chat title</summary>
		public string title;
		/// <summary>The old chat ID</summary>
		public long chat_id;
	}
	/// <summary>A message was pinned		<para>See <a href="https://corefork.telegram.org/constructor/messageActionPinMessage"/></para></summary>
	[TLDef(0x94BD38ED)]
	public class MessageActionPinMessage : MessageAction { }
	/// <summary>Chat history was cleared		<para>See <a href="https://corefork.telegram.org/constructor/messageActionHistoryClear"/></para></summary>
	[TLDef(0x9FBAB604)]
	public class MessageActionHistoryClear : MessageAction { }
	/// <summary>Someone scored in a game		<para>See <a href="https://corefork.telegram.org/constructor/messageActionGameScore"/></para></summary>
	[TLDef(0x92A72876)]
	public class MessageActionGameScore : MessageAction
	{
		/// <summary>Game ID</summary>
		public long game_id;
		/// <summary>Score</summary>
		public int score;
	}
	/// <summary>A user just sent a payment to me (a bot)		<para>See <a href="https://corefork.telegram.org/constructor/messageActionPaymentSentMe"/></para></summary>
	[TLDef(0x8F31B327)]
	public class MessageActionPaymentSentMe : MessageAction
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Three-letter ISO 4217 <a href="https://corefork.telegram.org/bots/payments#supported-currencies">currency</a> code</summary>
		public string currency;
		/// <summary>Price of the product in the smallest units of the currency (integer, not float/double). For example, for a price of <c>US$ 1.45</c> pass <c>amount = 145</c>. See the exp parameter in <a href="https://corefork.telegram.org/bots/payments/currencies.json">currencies.json</a>, it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).</summary>
		public long total_amount;
		/// <summary>Bot specified invoice payload</summary>
		public byte[] payload;
		/// <summary>Order info provided by the user</summary>
		[IfFlag(0)] public PaymentRequestedInfo info;
		/// <summary>Identifier of the shipping option chosen by the user</summary>
		[IfFlag(1)] public string shipping_option_id;
		/// <summary>Provider payment identifier</summary>
		public PaymentCharge charge;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="info"/> has a value</summary>
			has_info = 0x1,
			/// <summary>Field <see cref="shipping_option_id"/> has a value</summary>
			has_shipping_option_id = 0x2,
		}
	}
	/// <summary>A payment was sent		<para>See <a href="https://corefork.telegram.org/constructor/messageActionPaymentSent"/></para></summary>
	[TLDef(0x40699CD0)]
	public class MessageActionPaymentSent : MessageAction
	{
		/// <summary>Three-letter ISO 4217 <a href="https://corefork.telegram.org/bots/payments#supported-currencies">currency</a> code</summary>
		public string currency;
		/// <summary>Price of the product in the smallest units of the currency (integer, not float/double). For example, for a price of <c>US$ 1.45</c> pass <c>amount = 145</c>. See the exp parameter in <a href="https://corefork.telegram.org/bots/payments/currencies.json">currencies.json</a>, it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).</summary>
		public long total_amount;
	}
	/// <summary>A phone call		<para>See <a href="https://corefork.telegram.org/constructor/messageActionPhoneCall"/></para></summary>
	[TLDef(0x80E11A7F)]
	public class MessageActionPhoneCall : MessageAction
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Call ID</summary>
		public long call_id;
		/// <summary>If the call has ended, the reason why it ended</summary>
		[IfFlag(0)] public PhoneCallDiscardReason reason;
		/// <summary>Duration of the call in seconds</summary>
		[IfFlag(1)] public int duration;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="reason"/> has a value</summary>
			has_reason = 0x1,
			/// <summary>Field <see cref="duration"/> has a value</summary>
			has_duration = 0x2,
			/// <summary>Is this a video call?</summary>
			video = 0x4,
		}
	}
	/// <summary>A screenshot of the chat was taken		<para>See <a href="https://corefork.telegram.org/constructor/messageActionScreenshotTaken"/></para></summary>
	[TLDef(0x4792929B)]
	public class MessageActionScreenshotTaken : MessageAction { }
	/// <summary>Custom action (most likely not supported by the current layer, an upgrade might be needed)		<para>See <a href="https://corefork.telegram.org/constructor/messageActionCustomAction"/></para></summary>
	[TLDef(0xFAE69F56)]
	public class MessageActionCustomAction : MessageAction
	{
		/// <summary>Action message</summary>
		public string message;
	}
	/// <summary>The domain name of the website on which the user has logged in. <a href="https://corefork.telegram.org/widgets/login">More about Telegram Login »</a>		<para>See <a href="https://corefork.telegram.org/constructor/messageActionBotAllowed"/></para></summary>
	[TLDef(0xABE9AFFE)]
	public class MessageActionBotAllowed : MessageAction
	{
		/// <summary>The domain name of the website on which the user has logged in.</summary>
		public string domain;
	}
	/// <summary>Secure <a href="https://corefork.telegram.org/passport">telegram passport</a> values were received		<para>See <a href="https://corefork.telegram.org/constructor/messageActionSecureValuesSentMe"/></para></summary>
	[TLDef(0x1B287353)]
	public class MessageActionSecureValuesSentMe : MessageAction
	{
		/// <summary>Vector with information about documents and other Telegram Passport elements that were shared with the bot</summary>
		public SecureValue[] values;
		/// <summary>Encrypted credentials required to decrypt the data</summary>
		public SecureCredentialsEncrypted credentials;
	}
	/// <summary>Request for secure <a href="https://corefork.telegram.org/passport">telegram passport</a> values was sent		<para>See <a href="https://corefork.telegram.org/constructor/messageActionSecureValuesSent"/></para></summary>
	[TLDef(0xD95C6154)]
	public class MessageActionSecureValuesSent : MessageAction
	{
		/// <summary>Secure value types</summary>
		public SecureValueType[] types;
	}
	/// <summary>A contact just signed up to telegram		<para>See <a href="https://corefork.telegram.org/constructor/messageActionContactSignUp"/></para></summary>
	[TLDef(0xF3F25F76)]
	public class MessageActionContactSignUp : MessageAction { }
	/// <summary>A user of the chat is now in proximity of another user		<para>See <a href="https://corefork.telegram.org/constructor/messageActionGeoProximityReached"/></para></summary>
	[TLDef(0x98E0D697)]
	public class MessageActionGeoProximityReached : MessageAction
	{
		/// <summary>The user or chat that is now in proximity of <c>to_id</c></summary>
		public Peer from_id;
		/// <summary>The user or chat that subscribed to <a href="https://corefork.telegram.org/api/live-location#proximity-alert">live geolocation proximity alerts</a></summary>
		public Peer to_id;
		/// <summary>Distance, in meters (0-100000)</summary>
		public int distance;
	}
	/// <summary>The group call has ended		<para>See <a href="https://corefork.telegram.org/constructor/messageActionGroupCall"/></para></summary>
	[TLDef(0x7A0D7F42)]
	public class MessageActionGroupCall : MessageAction
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Group call</summary>
		public InputGroupCall call;
		/// <summary>Group call duration</summary>
		[IfFlag(0)] public int duration;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="duration"/> has a value</summary>
			has_duration = 0x1,
		}
	}
	/// <summary>A set of users was invited to the group call		<para>See <a href="https://corefork.telegram.org/constructor/messageActionInviteToGroupCall"/></para></summary>
	[TLDef(0x502F92F7)]
	public class MessageActionInviteToGroupCall : MessageAction
	{
		/// <summary>The group call</summary>
		public InputGroupCall call;
		/// <summary>The invited users</summary>
		public long[] users;
	}
	/// <summary>The Time-To-Live of messages in this chat was changed.		<para>See <a href="https://corefork.telegram.org/constructor/messageActionSetMessagesTTL"/></para></summary>
	[TLDef(0xAA1AFBFD)]
	public class MessageActionSetMessagesTTL : MessageAction
	{
		/// <summary>New Time-To-Live</summary>
		public int period;
	}
	/// <summary>A group call was scheduled		<para>See <a href="https://corefork.telegram.org/constructor/messageActionGroupCallScheduled"/></para></summary>
	[TLDef(0xB3A07661)]
	public class MessageActionGroupCallScheduled : MessageAction
	{
		/// <summary>The group call</summary>
		public InputGroupCall call;
		/// <summary>When is this group call scheduled to start</summary>
		public DateTime schedule_date;
	}
	/// <summary>The chat theme was changed		<para>See <a href="https://corefork.telegram.org/constructor/messageActionSetChatTheme"/></para></summary>
	[TLDef(0xAA786345)]
	public class MessageActionSetChatTheme : MessageAction
	{
		/// <summary>The emoji that identifies a chat theme</summary>
		public string emoticon;
	}
	/// <summary>A user was accepted into the group by an admin		<para>See <a href="https://corefork.telegram.org/constructor/messageActionChatJoinedByRequest"/></para></summary>
	[TLDef(0xEBBCA3CB)]
	public class MessageActionChatJoinedByRequest : MessageAction { }
	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/messageActionWebViewDataSentMe"/></para></summary>
	[TLDef(0x47DD8079, inheritBefore = true)]
	public class MessageActionWebViewDataSentMe : MessageActionWebViewDataSent
	{
		public string data;
	}
	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/messageActionWebViewDataSent"/></para></summary>
	[TLDef(0xB4C38CB5)]
	public class MessageActionWebViewDataSent : MessageAction
	{
		public string text;
	}

	/// <summary>Chat info.		<para>Derived classes: <see cref="Dialog"/>, <see cref="DialogFolder"/></para>		<para>See <a href="https://corefork.telegram.org/type/Dialog"/></para></summary>
	public abstract class DialogBase : IObject
	{
		/// <summary>The chat</summary>
		public abstract Peer Peer { get; }
		/// <summary>The latest message ID</summary>
		public abstract int TopMessage { get; }
	}
	/// <summary>Chat		<para>See <a href="https://corefork.telegram.org/constructor/dialog"/></para></summary>
	[TLDef(0xA8EDD0F5)]
	public class Dialog : DialogBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The chat</summary>
		public Peer peer;
		/// <summary>The latest message ID</summary>
		public int top_message;
		/// <summary>Position up to which all incoming messages are read.</summary>
		public int read_inbox_max_id;
		/// <summary>Position up to which all outgoing messages are read.</summary>
		public int read_outbox_max_id;
		/// <summary>Number of unread messages</summary>
		public int unread_count;
		/// <summary>Number of <a href="https://corefork.telegram.org/api/mentions">unread mentions</a></summary>
		public int unread_mentions_count;
		/// <summary>Number of unread reactions to messages you sent</summary>
		public int unread_reactions_count;
		/// <summary>Notification settings</summary>
		public PeerNotifySettings notify_settings;
		/// <summary><a href="https://corefork.telegram.org/api/updates">PTS</a></summary>
		[IfFlag(0)] public int pts;
		/// <summary>Message draft</summary>
		[IfFlag(1)] public DraftMessageBase draft;
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		[IfFlag(4)] public int folder_id;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="pts"/> has a value</summary>
			has_pts = 0x1,
			/// <summary>Field <see cref="draft"/> has a value</summary>
			has_draft = 0x2,
			/// <summary>Is the dialog pinned</summary>
			pinned = 0x4,
			/// <summary>Whether the chat was manually marked as unread</summary>
			unread_mark = 0x8,
			/// <summary>Field <see cref="folder_id"/> has a value</summary>
			has_folder_id = 0x10,
		}

		/// <summary>The chat</summary>
		public override Peer Peer => peer;
		/// <summary>The latest message ID</summary>
		public override int TopMessage => top_message;
	}
	/// <summary>Dialog in folder		<para>See <a href="https://corefork.telegram.org/constructor/dialogFolder"/></para></summary>
	[TLDef(0x71BD134C)]
	public class DialogFolder : DialogBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The folder</summary>
		public Folder folder;
		/// <summary>Peer in folder</summary>
		public Peer peer;
		/// <summary>Latest message ID of dialog</summary>
		public int top_message;
		/// <summary>Number of unread muted peers in folder</summary>
		public int unread_muted_peers_count;
		/// <summary>Number of unread unmuted peers in folder</summary>
		public int unread_unmuted_peers_count;
		/// <summary>Number of unread messages from muted peers in folder</summary>
		public int unread_muted_messages_count;
		/// <summary>Number of unread messages from unmuted peers in folder</summary>
		public int unread_unmuted_messages_count;

		[Flags] public enum Flags : uint
		{
			/// <summary>Is this folder pinned</summary>
			pinned = 0x4,
		}

		/// <summary>Peer in folder</summary>
		public override Peer Peer => peer;
		/// <summary>Latest message ID of dialog</summary>
		public override int TopMessage => top_message;
	}

	/// <summary>Object describes a photo.		<para>Derived classes: <see cref="PhotoEmpty"/>, <see cref="Photo"/></para>		<para>See <a href="https://corefork.telegram.org/type/Photo"/></para></summary>
	public abstract partial class PhotoBase : IObject { }
	/// <summary>Empty constructor, non-existent photo		<para>See <a href="https://corefork.telegram.org/constructor/photoEmpty"/></para></summary>
	[TLDef(0x2331B22D)]
	public partial class PhotoEmpty : PhotoBase
	{
		/// <summary>Photo identifier</summary>
		public long id;
	}
	/// <summary>Photo		<para>See <a href="https://corefork.telegram.org/constructor/photo"/></para></summary>
	[TLDef(0xFB197A65)]
	public partial class Photo : PhotoBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>ID</summary>
		public long id;
		/// <summary>Access hash</summary>
		public long access_hash;
		/// <summary><a href="https://corefork.telegram.org/api/file_reference">file reference</a></summary>
		public byte[] file_reference;
		/// <summary>Date of upload</summary>
		public DateTime date;
		/// <summary>Available sizes for download</summary>
		public PhotoSizeBase[] sizes;
		/// <summary><a href="https://corefork.telegram.org/api/files#animated-profile-pictures">For animated profiles</a>, the MPEG4 videos</summary>
		[IfFlag(1)] public VideoSize[] video_sizes;
		/// <summary>DC ID to use for download</summary>
		public int dc_id;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the photo has mask stickers attached to it</summary>
			has_stickers = 0x1,
			/// <summary>Field <see cref="video_sizes"/> has a value</summary>
			has_video_sizes = 0x2,
		}
	}

	/// <summary>Location of a certain size of a picture		<para>Derived classes: <see cref="PhotoSizeEmpty"/>, <see cref="PhotoSize"/>, <see cref="PhotoCachedSize"/>, <see cref="PhotoStrippedSize"/>, <see cref="PhotoSizeProgressive"/>, <see cref="PhotoPathSize"/></para>		<para>See <a href="https://corefork.telegram.org/type/PhotoSize"/></para></summary>
	public abstract partial class PhotoSizeBase : IObject
	{
		/// <summary>Thumbnail type (see. <see cref="PhotoSize"/>)</summary>
		public abstract string Type { get; }
	}
	/// <summary>Empty constructor. Image with this thumbnail is unavailable.		<para>See <a href="https://corefork.telegram.org/constructor/photoSizeEmpty"/></para></summary>
	[TLDef(0x0E17E23C)]
	public partial class PhotoSizeEmpty : PhotoSizeBase
	{
		/// <summary>Thumbnail type (see. <see cref="PhotoSize"/>)</summary>
		public string type;

		/// <summary>Thumbnail type (see. <see cref="PhotoSize"/>)</summary>
		public override string Type => type;
	}
	/// <summary>Image description.		<para>See <a href="https://corefork.telegram.org/constructor/photoSize"/></para></summary>
	[TLDef(0x75C78E60)]
	public partial class PhotoSize : PhotoSizeBase
	{
		/// <summary>Thumbnail type</summary>
		public string type;
		/// <summary>Image width</summary>
		public int w;
		/// <summary>Image height</summary>
		public int h;
		/// <summary>File size</summary>
		public int size;

		/// <summary>Thumbnail type</summary>
		public override string Type => type;
	}
	/// <summary>Description of an image and its content.		<para>See <a href="https://corefork.telegram.org/constructor/photoCachedSize"/></para></summary>
	[TLDef(0x021E1AD6)]
	public partial class PhotoCachedSize : PhotoSizeBase
	{
		/// <summary>Thumbnail type</summary>
		public string type;
		/// <summary>Image width</summary>
		public int w;
		/// <summary>Image height</summary>
		public int h;
		/// <summary>Binary data, file content</summary>
		public byte[] bytes;

		/// <summary>Thumbnail type</summary>
		public override string Type => type;
	}
	/// <summary>A low-resolution compressed JPG payload		<para>See <a href="https://corefork.telegram.org/constructor/photoStrippedSize"/></para></summary>
	[TLDef(0xE0B0BC2E)]
	public partial class PhotoStrippedSize : PhotoSizeBase
	{
		/// <summary>Thumbnail type</summary>
		public string type;
		/// <summary>Thumbnail data, see <a href="https://corefork.telegram.org/api/files#stripped-thumbnails">here for more info on decompression »</a></summary>
		public byte[] bytes;

		/// <summary>Thumbnail type</summary>
		public override string Type => type;
	}
	/// <summary>Progressively encoded photosize		<para>See <a href="https://corefork.telegram.org/constructor/photoSizeProgressive"/></para></summary>
	[TLDef(0xFA3EFB95)]
	public partial class PhotoSizeProgressive : PhotoSizeBase
	{
		/// <summary>Photosize type</summary>
		public string type;
		/// <summary>Photo width</summary>
		public int w;
		/// <summary>Photo height</summary>
		public int h;
		/// <summary>Sizes of progressive JPEG file prefixes, which can be used to preliminarily show the image.</summary>
		public int[] sizes;

		/// <summary>Photosize type</summary>
		public override string Type => type;
	}
	/// <summary>Messages with animated stickers can have a compressed svg (&lt; 300 bytes) to show the outline of the sticker before fetching the actual lottie animation.		<para>See <a href="https://corefork.telegram.org/constructor/photoPathSize"/></para></summary>
	[TLDef(0xD8214D41)]
	public partial class PhotoPathSize : PhotoSizeBase
	{
		/// <summary>Always <c>j</c></summary>
		public string type;
		/// <summary>Compressed SVG path payload, <a href="https://corefork.telegram.org/api/files#vector-thumbnails">see here for decompression instructions</a></summary>
		public byte[] bytes;

		/// <summary>Always <c>j</c></summary>
		public override string Type => type;
	}

	/// <summary>GeoPoint.		<para>See <a href="https://corefork.telegram.org/constructor/geoPoint"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/geoPointEmpty">geoPointEmpty</a></remarks>
	[TLDef(0xB2A2F663)]
	public class GeoPoint : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Longitude</summary>
		public double lon;
		/// <summary>Latitude</summary>
		public double lat;
		/// <summary>Access hash</summary>
		public long access_hash;
		/// <summary>The estimated horizontal accuracy of the location, in meters; as defined by the sender.</summary>
		[IfFlag(0)] public int accuracy_radius;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="accuracy_radius"/> has a value</summary>
			has_accuracy_radius = 0x1,
		}
	}

	/// <summary>Contains info about a sent verification code.		<para>See <a href="https://corefork.telegram.org/constructor/auth.sentCode"/></para></summary>
	[TLDef(0x5E002502)]
	public class Auth_SentCode : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Phone code type</summary>
		public Auth_SentCodeType type;
		/// <summary>Phone code hash, to be stored and later re-used with <a href="https://corefork.telegram.org/method/auth.signIn">auth.signIn</a></summary>
		public string phone_code_hash;
		/// <summary>Phone code type that will be sent next, if the phone code is not received within <c>timeout</c> seconds: to send it use <a href="https://corefork.telegram.org/method/auth.resendCode">auth.resendCode</a></summary>
		[IfFlag(1)] public Auth_CodeType next_type;
		/// <summary>Timeout for reception of the phone code</summary>
		[IfFlag(2)] public int timeout;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="next_type"/> has a value</summary>
			has_next_type = 0x2,
			/// <summary>Field <see cref="timeout"/> has a value</summary>
			has_timeout = 0x4,
		}
	}

	/// <summary>Object contains info on user authorization.		<para>Derived classes: <see cref="Auth_Authorization"/>, <see cref="Auth_AuthorizationSignUpRequired"/></para>		<para>See <a href="https://corefork.telegram.org/type/auth.Authorization"/></para></summary>
	public abstract class Auth_AuthorizationBase : IObject { }
	/// <summary>Contains user authorization info.		<para>See <a href="https://corefork.telegram.org/constructor/auth.authorization"/></para></summary>
	[TLDef(0x33FB7BB8)]
	public class Auth_Authorization : Auth_AuthorizationBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Iff setup_password_required is set and the user declines to set a 2-step verification password, they will be able to log into their account via SMS again only after this many days pass.</summary>
		[IfFlag(1)] public int otherwise_relogin_days;
		/// <summary>Temporary <a href="https://corefork.telegram.org/passport">passport</a> sessions</summary>
		[IfFlag(0)] public int tmp_sessions;
		/// <summary>Info on authorized user</summary>
		public UserBase user;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="tmp_sessions"/> has a value</summary>
			has_tmp_sessions = 0x1,
			/// <summary>Suggests the user to set up a 2-step verification password to be able to log in again</summary>
			setup_password_required = 0x2,
		}
	}
	/// <summary>An account with this phone number doesn't exist on telegram: the user has to <a href="https://corefork.telegram.org/api/auth">enter basic information and sign up</a>		<para>See <a href="https://corefork.telegram.org/constructor/auth.authorizationSignUpRequired"/></para></summary>
	[TLDef(0x44747E9A)]
	public class Auth_AuthorizationSignUpRequired : Auth_AuthorizationBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Telegram's terms of service: the user must read and accept the terms of service before signing up to telegram</summary>
		[IfFlag(0)] public Help_TermsOfService terms_of_service;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="terms_of_service"/> has a value</summary>
			has_terms_of_service = 0x1,
		}
	}

	/// <summary>Data for copying of authorization between data centers.		<para>See <a href="https://corefork.telegram.org/constructor/auth.exportedAuthorization"/></para></summary>
	[TLDef(0xB434E2B8)]
	public class Auth_ExportedAuthorization : IObject
	{
		/// <summary>current user identifier</summary>
		public long id;
		/// <summary>authorizes key</summary>
		public byte[] bytes;
	}

	/// <summary>Object defines the set of users and/or groups that generate notifications.		<para>Derived classes: <see cref="InputNotifyPeer"/>, <see cref="InputNotifyUsers"/>, <see cref="InputNotifyChats"/>, <see cref="InputNotifyBroadcasts"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputNotifyPeer"/></para></summary>
	public abstract class InputNotifyPeerBase : IObject { }
	/// <summary>Notifications generated by a certain user or group.		<para>See <a href="https://corefork.telegram.org/constructor/inputNotifyPeer"/></para></summary>
	[TLDef(0xB8BC5B0C)]
	public class InputNotifyPeer : InputNotifyPeerBase
	{
		/// <summary>User or group</summary>
		public InputPeer peer;
	}
	/// <summary>Notifications generated by all users.		<para>See <a href="https://corefork.telegram.org/constructor/inputNotifyUsers"/></para></summary>
	[TLDef(0x193B4417)]
	public class InputNotifyUsers : InputNotifyPeerBase { }
	/// <summary>Notifications generated by all groups.		<para>See <a href="https://corefork.telegram.org/constructor/inputNotifyChats"/></para></summary>
	[TLDef(0x4A95E84E)]
	public class InputNotifyChats : InputNotifyPeerBase { }
	/// <summary>All <a href="https://corefork.telegram.org/api/channel">channels</a>		<para>See <a href="https://corefork.telegram.org/constructor/inputNotifyBroadcasts"/></para></summary>
	[TLDef(0xB1DB7C7E)]
	public class InputNotifyBroadcasts : InputNotifyPeerBase { }

	/// <summary>Notification settings.		<para>See <a href="https://corefork.telegram.org/constructor/inputPeerNotifySettings"/></para></summary>
	[TLDef(0xDF1F002B)]
	public class InputPeerNotifySettings : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>If the text of the message shall be displayed in notification</summary>
		[IfFlag(0)] public bool show_previews;
		/// <summary>Peer was muted?</summary>
		[IfFlag(1)] public bool silent;
		/// <summary>Date until which all notifications shall be switched off</summary>
		[IfFlag(2)] public int mute_until;
		/// <summary>Name of an audio file for notification</summary>
		[IfFlag(3)] public NotificationSound sound;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="show_previews"/> has a value</summary>
			has_show_previews = 0x1,
			/// <summary>Field <see cref="silent"/> has a value</summary>
			has_silent = 0x2,
			/// <summary>Field <see cref="mute_until"/> has a value</summary>
			has_mute_until = 0x4,
			/// <summary>Field <see cref="sound"/> has a value</summary>
			has_sound = 0x8,
		}
	}

	/// <summary>Notification settings.		<para>See <a href="https://corefork.telegram.org/constructor/peerNotifySettings"/></para></summary>
	[TLDef(0xA83B0426)]
	public class PeerNotifySettings : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Display text in notifications</summary>
		[IfFlag(0)] public bool show_previews;
		/// <summary>Mute peer?</summary>
		[IfFlag(1)] public bool silent;
		/// <summary>Mute all notifications until this date</summary>
		[IfFlag(2)] public int mute_until;
		[IfFlag(3)] public NotificationSound ios_sound;
		[IfFlag(4)] public NotificationSound android_sound;
		[IfFlag(5)] public NotificationSound other_sound;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="show_previews"/> has a value</summary>
			has_show_previews = 0x1,
			/// <summary>Field <see cref="silent"/> has a value</summary>
			has_silent = 0x2,
			/// <summary>Field <see cref="mute_until"/> has a value</summary>
			has_mute_until = 0x4,
			/// <summary>Field <see cref="ios_sound"/> has a value</summary>
			has_ios_sound = 0x8,
			/// <summary>Field <see cref="android_sound"/> has a value</summary>
			has_android_sound = 0x10,
			/// <summary>Field <see cref="other_sound"/> has a value</summary>
			has_other_sound = 0x20,
		}
	}

	/// <summary>List of actions that are possible when interacting with this user, to be shown as suggested actions in the chat bar		<para>See <a href="https://corefork.telegram.org/constructor/peerSettings"/></para></summary>
	[TLDef(0xA518110D)]
	public class PeerSettings : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Distance in meters between us and this peer</summary>
		[IfFlag(6)] public int geo_distance;
		/// <summary>If set, this is a private chat with an administrator of a chat or channel to which the user sent a join request, and this field contains the chat/channel's title.</summary>
		[IfFlag(9)] public string request_chat_title;
		/// <summary>If set, this is a private chat with an administrator of a chat or channel to which the user sent a join request, and this field contains the timestamp when the <a href="https://corefork.telegram.org/api/invites#join-requests">join request »</a> was sent.</summary>
		[IfFlag(9)] public DateTime request_chat_date;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether we can still report the user for spam</summary>
			report_spam = 0x1,
			/// <summary>Whether we can add the user as contact</summary>
			add_contact = 0x2,
			/// <summary>Whether we can block the user</summary>
			block_contact = 0x4,
			/// <summary>Whether we can share the user's contact</summary>
			share_contact = 0x8,
			/// <summary>Whether a special exception for contacts is needed</summary>
			need_contacts_exception = 0x10,
			/// <summary>Whether we can report a geogroup as irrelevant for this location</summary>
			report_geo = 0x20,
			/// <summary>Field <see cref="geo_distance"/> has a value</summary>
			has_geo_distance = 0x40,
			/// <summary>Whether this peer was automatically archived according to <see cref="GlobalPrivacySettings"/> and can be unarchived</summary>
			autoarchived = 0x80,
			/// <summary>If set, this is a recently created group chat to which new members can be invited</summary>
			invite_members = 0x100,
			/// <summary>Field <see cref="request_chat_title"/> has a value</summary>
			has_request_chat_title = 0x200,
			/// <summary>This flag is set if <c>request_chat_title</c> and <c>request_chat_date</c> fields are set and the <a href="https://corefork.telegram.org/api/invites#join-requests">join request »</a> is related to a channel (otherwise if only the request fields are set, the <a href="https://corefork.telegram.org/api/invites#join-requests">join request »</a> is related to a chat).</summary>
			request_chat_broadcast = 0x400,
		}
	}

	/// <summary>Object contains info on a wallpaper.		<para>Derived classes: <see cref="WallPaper"/>, <see cref="WallPaperNoFile"/></para>		<para>See <a href="https://corefork.telegram.org/type/WallPaper"/></para></summary>
	public abstract class WallPaperBase : IObject
	{
		/// <summary>Identifier</summary>
		public abstract long ID { get; }
		/// <summary>Wallpaper settings</summary>
		public abstract WallPaperSettings Settings { get; }
	}
	/// <summary>Wallpaper settings.		<para>See <a href="https://corefork.telegram.org/constructor/wallPaper"/></para></summary>
	[TLDef(0xA437C3ED)]
	public class WallPaper : WallPaperBase
	{
		/// <summary>Identifier</summary>
		public long id;
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Access hash</summary>
		public long access_hash;
		/// <summary>Unique wallpaper ID</summary>
		public string slug;
		/// <summary>The actual wallpaper</summary>
		public DocumentBase document;
		/// <summary>Wallpaper settings</summary>
		[IfFlag(2)] public WallPaperSettings settings;

		[Flags] public enum Flags : uint
		{
			/// <summary>Creator of the wallpaper</summary>
			creator = 0x1,
			/// <summary>Whether this is the default wallpaper</summary>
			default_ = 0x2,
			/// <summary>Field <see cref="settings"/> has a value</summary>
			has_settings = 0x4,
			/// <summary>Pattern</summary>
			pattern = 0x8,
			/// <summary>Dark mode</summary>
			dark = 0x10,
		}

		/// <summary>Identifier</summary>
		public override long ID => id;
		/// <summary>Wallpaper settings</summary>
		public override WallPaperSettings Settings => settings;
	}
	/// <summary>Wallpaper with no file access hash, used for example when deleting (<c>unsave=true</c>) wallpapers using <a href="https://corefork.telegram.org/method/account.saveWallPaper">account.saveWallPaper</a>, specifying just the wallpaper ID.<br/>Also used for some default wallpapers which contain only colours.		<para>See <a href="https://corefork.telegram.org/constructor/wallPaperNoFile"/></para></summary>
	[TLDef(0xE0804116)]
	public class WallPaperNoFile : WallPaperBase
	{
		/// <summary>Wallpaper ID</summary>
		public long id;
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Wallpaper settings</summary>
		[IfFlag(2)] public WallPaperSettings settings;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether this is the default wallpaper</summary>
			default_ = 0x2,
			/// <summary>Field <see cref="settings"/> has a value</summary>
			has_settings = 0x4,
			/// <summary>Dark mode</summary>
			dark = 0x10,
		}

		/// <summary>Wallpaper ID</summary>
		public override long ID => id;
		/// <summary>Wallpaper settings</summary>
		public override WallPaperSettings Settings => settings;
	}

	/// <summary>Report reason		<para>See <a href="https://corefork.telegram.org/type/ReportReason"/></para></summary>
	public enum ReportReason : uint
	{
		///<summary>Report for spam</summary>
		Spam = 0x58DBCAB8,
		///<summary>Report for violence</summary>
		Violence = 0x1E22C78D,
		///<summary>Report for pornography</summary>
		Pornography = 0x2E59D922,
		///<summary>Report for child abuse</summary>
		ChildAbuse = 0xADF44EE3,
		///<summary>Other</summary>
		Other = 0xC1E4A2B1,
		///<summary>Report for copyrighted content</summary>
		Copyright = 0x9B89F93A,
		///<summary>Report an irrelevant geogroup</summary>
		GeoIrrelevant = 0xDBD4FEED,
		///<summary>Report for impersonation</summary>
		Fake = 0xF5DDD6E7,
		///<summary>Report for illegal drugs</summary>
		IllegalDrugs = 0x0A8EB2BE,
		///<summary>Report for divulgation of personal details</summary>
		PersonalDetails = 0x9EC7863D,
	}

	/// <summary>Extended user info		<para>See <a href="https://corefork.telegram.org/constructor/userFull"/></para></summary>
	[TLDef(0x8C72EA81)]
	public class UserFull : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>User ID</summary>
		public long id;
		/// <summary>Bio of the user</summary>
		[IfFlag(1)] public string about;
		/// <summary>Peer settings</summary>
		public PeerSettings settings;
		/// <summary>Profile photo</summary>
		[IfFlag(2)] public PhotoBase profile_photo;
		/// <summary>Notification settings</summary>
		public PeerNotifySettings notify_settings;
		/// <summary>For bots, info about the bot (bot commands, etc)</summary>
		[IfFlag(3)] public BotInfo bot_info;
		/// <summary>Message ID of the last <a href="https://corefork.telegram.org/api/pin">pinned message</a></summary>
		[IfFlag(6)] public int pinned_msg_id;
		/// <summary>Chats in common with this user</summary>
		public int common_chats_count;
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		[IfFlag(11)] public int folder_id;
		/// <summary>Time To Live of all messages in this chat; once a message is this many seconds old, it must be deleted.</summary>
		[IfFlag(14)] public int ttl_period;
		/// <summary>Emoji associated with chat theme</summary>
		[IfFlag(15)] public string theme_emoticon;
		/// <summary>Anonymized text to be shown instead of the the user's name on forwarded messages</summary>
		[IfFlag(16)] public string private_forward_name;
		[IfFlag(17)] public ChatAdminRights bot_group_admin_rights;
		[IfFlag(18)] public ChatAdminRights bot_broadcast_admin_rights;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether you have blocked this user</summary>
			blocked = 0x1,
			/// <summary>Field <see cref="about"/> has a value</summary>
			has_about = 0x2,
			/// <summary>Field <see cref="profile_photo"/> has a value</summary>
			has_profile_photo = 0x4,
			/// <summary>Field <see cref="bot_info"/> has a value</summary>
			has_bot_info = 0x8,
			/// <summary>Whether this user can make VoIP calls</summary>
			phone_calls_available = 0x10,
			/// <summary>Whether this user's privacy settings allow you to call them</summary>
			phone_calls_private = 0x20,
			/// <summary>Field <see cref="pinned_msg_id"/> has a value</summary>
			has_pinned_msg_id = 0x40,
			/// <summary>Whether you can pin messages in the chat with this user, you can do this only for a chat with yourself</summary>
			can_pin_message = 0x80,
			/// <summary>Field <see cref="folder_id"/> has a value</summary>
			has_folder_id = 0x800,
			/// <summary>Whether <a href="https://corefork.telegram.org/api/scheduled-messages">scheduled messages</a> are available</summary>
			has_scheduled = 0x1000,
			/// <summary>Whether the user can receive video calls</summary>
			video_calls_available = 0x2000,
			/// <summary>Field <see cref="ttl_period"/> has a value</summary>
			has_ttl_period = 0x4000,
			/// <summary>Field <see cref="theme_emoticon"/> has a value</summary>
			has_theme_emoticon = 0x8000,
			/// <summary>Field <see cref="private_forward_name"/> has a value</summary>
			has_private_forward_name = 0x10000,
			/// <summary>Field <see cref="bot_group_admin_rights"/> has a value</summary>
			has_bot_group_admin_rights = 0x20000,
			/// <summary>Field <see cref="bot_broadcast_admin_rights"/> has a value</summary>
			has_bot_broadcast_admin_rights = 0x40000,
		}
	}

	/// <summary>A contact of the current user that is registered in the system.		<para>See <a href="https://corefork.telegram.org/constructor/contact"/></para></summary>
	[TLDef(0x145ADE0B)]
	public class Contact : IObject
	{
		/// <summary>User identifier</summary>
		public long user_id;
		/// <summary>Current user is in the user's contact list</summary>
		public bool mutual;
	}

	/// <summary>Successfully imported contact.		<para>See <a href="https://corefork.telegram.org/constructor/importedContact"/></para></summary>
	[TLDef(0xC13E3C50)]
	public class ImportedContact : IObject
	{
		/// <summary>User identifier</summary>
		public long user_id;
		/// <summary>The contact's client identifier (passed to one of the <see cref="InputContact"/> constructors)</summary>
		public long client_id;
	}

	/// <summary>Contact status: online / offline.		<para>See <a href="https://corefork.telegram.org/constructor/contactStatus"/></para></summary>
	[TLDef(0x16D9703B)]
	public class ContactStatus : IObject
	{
		/// <summary>User identifier</summary>
		public long user_id;
		/// <summary>Online status</summary>
		public UserStatus status;
	}

	/// <summary>The current user's contact list and info on users.		<para>See <a href="https://corefork.telegram.org/constructor/contacts.contacts"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/contacts.contactsNotModified">contacts.contactsNotModified</a></remarks>
	[TLDef(0xEAE87E42)]
	public class Contacts_Contacts : IObject
	{
		/// <summary>Contact list</summary>
		public Contact[] contacts;
		/// <summary>Number of contacts that were saved successfully</summary>
		public int saved_count;
		/// <summary>User list</summary>
		public Dictionary<long, User> users;
	}

	/// <summary>Info on successfully imported contacts.		<para>See <a href="https://corefork.telegram.org/constructor/contacts.importedContacts"/></para></summary>
	[TLDef(0x77D01C3B)]
	public class Contacts_ImportedContacts : IObject
	{
		/// <summary>List of successfully imported contacts</summary>
		public ImportedContact[] imported;
		/// <summary>Popular contacts</summary>
		public PopularContact[] popular_invites;
		/// <summary>List of contact ids that could not be imported due to system limitation and will need to be imported at a later date.<br/>Parameter added in <a href="https://corefork.telegram.org/api/layers#layer-13">Layer 13</a></summary>
		public long[] retry_contacts;
		/// <summary>List of users</summary>
		public Dictionary<long, User> users;
	}

	/// <summary>Full list of blocked users.		<para>See <a href="https://corefork.telegram.org/constructor/contacts.blocked"/></para></summary>
	[TLDef(0x0ADE1591)]
	public partial class Contacts_Blocked : IObject, IPeerResolver
	{
		/// <summary>List of blocked users</summary>
		public PeerBlocked[] blocked;
		/// <summary>Blocked chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>List of users</summary>
		public Dictionary<long, User> users;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}
	/// <summary>Incomplete list of blocked users.		<para>See <a href="https://corefork.telegram.org/constructor/contacts.blockedSlice"/></para></summary>
	[TLDef(0xE1664194)]
	public class Contacts_BlockedSlice : Contacts_Blocked
	{
		/// <summary>Total number of elements in the list</summary>
		public int count;
	}

	/// <summary>Object contains a list of chats with messages and auxiliary data.		<para>Derived classes: <see cref="Messages_Dialogs"/>, <see cref="Messages_DialogsSlice"/>, <see cref="Messages_DialogsNotModified"/></para>		<para>See <a href="https://corefork.telegram.org/type/messages.Dialogs"/></para></summary>
	public abstract partial class Messages_DialogsBase : IObject, IPeerResolver
	{
		/// <summary>List of chats</summary>
		public abstract DialogBase[] Dialogs { get; }
		/// <summary>List of last messages from each chat</summary>
		public abstract MessageBase[] Messages { get; }
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public abstract IPeerInfo UserOrChat(Peer peer);
	}
	/// <summary>Full list of chats with messages and auxiliary data.		<para>See <a href="https://corefork.telegram.org/constructor/messages.dialogs"/></para></summary>
	[TLDef(0x15BA6C40)]
	public partial class Messages_Dialogs : Messages_DialogsBase, IPeerResolver
	{
		/// <summary>List of chats</summary>
		public DialogBase[] dialogs;
		/// <summary>List of last messages from each chat</summary>
		public MessageBase[] messages;
		/// <summary>List of groups mentioned in the chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>List of users mentioned in messages and groups</summary>
		public Dictionary<long, User> users;

		/// <summary>List of chats</summary>
		public override DialogBase[] Dialogs => dialogs;
		/// <summary>List of last messages from each chat</summary>
		public override MessageBase[] Messages => messages;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}
	/// <summary>Incomplete list of dialogs with messages and auxiliary data.		<para>See <a href="https://corefork.telegram.org/constructor/messages.dialogsSlice"/></para></summary>
	[TLDef(0x71E094F3)]
	public partial class Messages_DialogsSlice : Messages_Dialogs, IPeerResolver
	{
		/// <summary>Total number of dialogs</summary>
		public int count;
	}
	/// <summary>Dialogs haven't changed		<para>See <a href="https://corefork.telegram.org/constructor/messages.dialogsNotModified"/></para></summary>
	[TLDef(0xF0E3E596)]
	public partial class Messages_DialogsNotModified : Messages_DialogsBase, IPeerResolver
	{
		/// <summary>Number of dialogs found server-side by the query</summary>
		public int count;

		public override DialogBase[] Dialogs => default;
		public override MessageBase[] Messages => default;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => null;
	}

	/// <summary>Object contains information on list of messages with auxiliary data.		<para>Derived classes: <see cref="Messages_Messages"/>, <see cref="Messages_MessagesSlice"/>, <see cref="Messages_ChannelMessages"/>, <see cref="Messages_MessagesNotModified"/></para>		<para>See <a href="https://corefork.telegram.org/type/messages.Messages"/></para></summary>
	public abstract partial class Messages_MessagesBase : IObject, IPeerResolver
	{
		/// <summary>List of messages</summary>
		public abstract MessageBase[] Messages { get; }
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public abstract IPeerInfo UserOrChat(Peer peer);
	}
	/// <summary>Full list of messages with auxiliary data.		<para>See <a href="https://corefork.telegram.org/constructor/messages.messages"/></para></summary>
	[TLDef(0x8C718E87)]
	public partial class Messages_Messages : Messages_MessagesBase, IPeerResolver
	{
		/// <summary>List of messages</summary>
		public MessageBase[] messages;
		/// <summary>List of chats mentioned in dialogs</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>List of users mentioned in messages and chats</summary>
		public Dictionary<long, User> users;

		/// <summary>List of messages</summary>
		public override MessageBase[] Messages => messages;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}
	/// <summary>Incomplete list of messages and auxiliary data.		<para>See <a href="https://corefork.telegram.org/constructor/messages.messagesSlice"/></para></summary>
	[TLDef(0x3A54685E)]
	public partial class Messages_MessagesSlice : Messages_Messages, IPeerResolver
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Total number of messages in the list</summary>
		public int count;
		/// <summary>Rate to use in the <c>offset_rate</c> parameter in the next call to <a href="https://corefork.telegram.org/method/messages.searchGlobal">messages.searchGlobal</a></summary>
		[IfFlag(0)] public int next_rate;
		/// <summary>Indicates the absolute position of <c>messages[0]</c> within the total result set with count <c>count</c>. <br/>This is useful, for example, if the result was fetched using <c>offset_id</c>, and we need to display a <c>progress/total</c> counter (like <c>photo 134 of 200</c>, for all media in a chat, we could simply use <c>photo ${offset_id_offset} of ${count}</c>.</summary>
		[IfFlag(2)] public int offset_id_offset;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="next_rate"/> has a value</summary>
			has_next_rate = 0x1,
			/// <summary>If set, indicates that the results may be inexact</summary>
			inexact = 0x2,
			/// <summary>Field <see cref="offset_id_offset"/> has a value</summary>
			has_offset_id_offset = 0x4,
		}
	}
	/// <summary>Channel messages		<para>See <a href="https://corefork.telegram.org/constructor/messages.channelMessages"/></para></summary>
	[TLDef(0x64479808)]
	public partial class Messages_ChannelMessages : Messages_MessagesBase, IPeerResolver
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary><a href="https://corefork.telegram.org/api/updates">Event count after generation</a></summary>
		public int pts;
		/// <summary>Total number of results were found server-side (may not be all included here)</summary>
		public int count;
		/// <summary>Indicates the absolute position of <c>messages[0]</c> within the total result set with count <c>count</c>. <br/>This is useful, for example, if the result was fetched using <c>offset_id</c>, and we need to display a <c>progress/total</c> counter (like <c>photo 134 of 200</c>, for all media in a chat, we could simply use <c>photo ${offset_id_offset} of ${count}</c>.</summary>
		[IfFlag(2)] public int offset_id_offset;
		/// <summary>Found messages</summary>
		public MessageBase[] messages;
		/// <summary>Chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users</summary>
		public Dictionary<long, User> users;

		[Flags] public enum Flags : uint
		{
			/// <summary>If set, returned results may be inexact</summary>
			inexact = 0x2,
			/// <summary>Field <see cref="offset_id_offset"/> has a value</summary>
			has_offset_id_offset = 0x4,
		}

		/// <summary>Found messages</summary>
		public override MessageBase[] Messages => messages;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}
	/// <summary>No new messages matching the query were found		<para>See <a href="https://corefork.telegram.org/constructor/messages.messagesNotModified"/></para></summary>
	[TLDef(0x74535F21)]
	public partial class Messages_MessagesNotModified : Messages_MessagesBase, IPeerResolver
	{
		/// <summary>Number of results found server-side by the given query</summary>
		public int count;

		public override MessageBase[] Messages => default;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => null;
	}

	/// <summary>List of chats with auxiliary data.		<para>See <a href="https://corefork.telegram.org/constructor/messages.chats"/></para></summary>
	[TLDef(0x64FF9FD5)]
	public class Messages_Chats : IObject
	{
		/// <summary>List of chats</summary>
		public Dictionary<long, ChatBase> chats;
	}
	/// <summary>Partial list of chats, more would have to be fetched with <a href="https://corefork.telegram.org/api/offsets">pagination</a>		<para>See <a href="https://corefork.telegram.org/constructor/messages.chatsSlice"/></para></summary>
	[TLDef(0x9CD81144)]
	public class Messages_ChatsSlice : Messages_Chats
	{
		/// <summary>Total number of results that were found server-side (not all are included in <c>chats</c>)</summary>
		public int count;
	}

	/// <summary>Full info about a <a href="https://corefork.telegram.org/api/channel#channels">channel</a>, <a href="https://corefork.telegram.org/api/channel#supergroups">supergroup</a>, <a href="https://corefork.telegram.org/api/channel#gigagroups">gigagroup</a> or <a href="https://corefork.telegram.org/api/channel#basic-groups">basic group</a>.		<para>See <a href="https://corefork.telegram.org/constructor/messages.chatFull"/></para></summary>
	[TLDef(0xE5D7D19C)]
	public class Messages_ChatFull : IObject, IPeerResolver
	{
		/// <summary>Full info</summary>
		public ChatFullBase full_chat;
		/// <summary>Mentioned chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Mentioned users</summary>
		public Dictionary<long, User> users;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}

	/// <summary>Affected part of communication history with the user or in a chat.		<para>See <a href="https://corefork.telegram.org/constructor/messages.affectedHistory"/></para></summary>
	[TLDef(0xB45C69D1)]
	public class Messages_AffectedHistory : IObject
	{
		/// <summary>Number of events occurred in a text box</summary>
		public int pts;
		/// <summary>Number of affected events</summary>
		public int pts_count;
		/// <summary>If a parameter contains positive value, it is necessary to repeat the method call using the given value; during the proceeding of all the history the value itself shall gradually decrease</summary>
		public int offset;
	}

	/// <summary>Object describes message filter.		<para>Derived classes: <see cref="InputMessagesFilterPhotos"/>, <see cref="InputMessagesFilterVideo"/>, <see cref="InputMessagesFilterPhotoVideo"/>, <see cref="InputMessagesFilterDocument"/>, <see cref="InputMessagesFilterUrl"/>, <see cref="InputMessagesFilterGif"/>, <see cref="InputMessagesFilterVoice"/>, <see cref="InputMessagesFilterMusic"/>, <see cref="InputMessagesFilterChatPhotos"/>, <see cref="InputMessagesFilterPhoneCalls"/>, <see cref="InputMessagesFilterRoundVoice"/>, <see cref="InputMessagesFilterRoundVideo"/>, <see cref="InputMessagesFilterMyMentions"/>, <see cref="InputMessagesFilterGeo"/>, <see cref="InputMessagesFilterContacts"/>, <see cref="InputMessagesFilterPinned"/></para>		<para>See <a href="https://corefork.telegram.org/type/MessagesFilter"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputMessagesFilterEmpty">inputMessagesFilterEmpty</a></remarks>
	public abstract class MessagesFilter : IObject { }
	/// <summary>Filter for messages containing photos.		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterPhotos"/></para></summary>
	[TLDef(0x9609A51C)]
	public class InputMessagesFilterPhotos : MessagesFilter { }
	/// <summary>Filter for messages containing videos.		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterVideo"/></para></summary>
	[TLDef(0x9FC00E65)]
	public class InputMessagesFilterVideo : MessagesFilter { }
	/// <summary>Filter for messages containing photos or videos.		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterPhotoVideo"/></para></summary>
	[TLDef(0x56E9F0E4)]
	public class InputMessagesFilterPhotoVideo : MessagesFilter { }
	/// <summary>Filter for messages containing documents.		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterDocument"/></para></summary>
	[TLDef(0x9EDDF188)]
	public class InputMessagesFilterDocument : MessagesFilter { }
	/// <summary>Return only messages containing URLs		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterUrl"/></para></summary>
	[TLDef(0x7EF0DD87)]
	public class InputMessagesFilterUrl : MessagesFilter { }
	/// <summary>Return only messages containing gifs		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterGif"/></para></summary>
	[TLDef(0xFFC86587)]
	public class InputMessagesFilterGif : MessagesFilter { }
	/// <summary>Return only messages containing voice notes		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterVoice"/></para></summary>
	[TLDef(0x50F5C392)]
	public class InputMessagesFilterVoice : MessagesFilter { }
	/// <summary>Return only messages containing audio files		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterMusic"/></para></summary>
	[TLDef(0x3751B49E)]
	public class InputMessagesFilterMusic : MessagesFilter { }
	/// <summary>Return only chat photo changes		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterChatPhotos"/></para></summary>
	[TLDef(0x3A20ECB8)]
	public class InputMessagesFilterChatPhotos : MessagesFilter { }
	/// <summary>Return only phone calls		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterPhoneCalls"/></para></summary>
	[TLDef(0x80C99768)]
	public class InputMessagesFilterPhoneCalls : MessagesFilter
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;

		[Flags] public enum Flags : uint
		{
			/// <summary>Return only missed phone calls</summary>
			missed = 0x1,
		}
	}
	/// <summary>Return only round videos and voice notes		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterRoundVoice"/></para></summary>
	[TLDef(0x7A7C17A4)]
	public class InputMessagesFilterRoundVoice : MessagesFilter { }
	/// <summary>Return only round videos		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterRoundVideo"/></para></summary>
	[TLDef(0xB549DA53)]
	public class InputMessagesFilterRoundVideo : MessagesFilter { }
	/// <summary>Return only messages where the current user was <a href="https://corefork.telegram.org/api/mentions">mentioned</a>.		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterMyMentions"/></para></summary>
	[TLDef(0xC1F8E69A)]
	public class InputMessagesFilterMyMentions : MessagesFilter { }
	/// <summary>Return only messages containing geolocations		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterGeo"/></para></summary>
	[TLDef(0xE7026D0D)]
	public class InputMessagesFilterGeo : MessagesFilter { }
	/// <summary>Return only messages containing contacts		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterContacts"/></para></summary>
	[TLDef(0xE062DB83)]
	public class InputMessagesFilterContacts : MessagesFilter { }
	/// <summary>Fetch only pinned messages		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterPinned"/></para></summary>
	[TLDef(0x1BB00451)]
	public class InputMessagesFilterPinned : MessagesFilter { }

	/// <summary>Object contains info on events occurred.		<para>Derived classes: <see cref="UpdateNewMessage"/>, <see cref="UpdateMessageID"/>, <see cref="UpdateDeleteMessages"/>, <see cref="UpdateUserTyping"/>, <see cref="UpdateChatUserTyping"/>, <see cref="UpdateChatParticipants"/>, <see cref="UpdateUserStatus"/>, <see cref="UpdateUserName"/>, <see cref="UpdateUserPhoto"/>, <see cref="UpdateNewEncryptedMessage"/>, <see cref="UpdateEncryptedChatTyping"/>, <see cref="UpdateEncryption"/>, <see cref="UpdateEncryptedMessagesRead"/>, <see cref="UpdateChatParticipantAdd"/>, <see cref="UpdateChatParticipantDelete"/>, <see cref="UpdateDcOptions"/>, <see cref="UpdateNotifySettings"/>, <see cref="UpdateServiceNotification"/>, <see cref="UpdatePrivacy"/>, <see cref="UpdateUserPhone"/>, <see cref="UpdateReadHistoryInbox"/>, <see cref="UpdateReadHistoryOutbox"/>, <see cref="UpdateWebPage"/>, <see cref="UpdateReadMessagesContents"/>, <see cref="UpdateChannelTooLong"/>, <see cref="UpdateChannel"/>, <see cref="UpdateNewChannelMessage"/>, <see cref="UpdateReadChannelInbox"/>, <see cref="UpdateDeleteChannelMessages"/>, <see cref="UpdateChannelMessageViews"/>, <see cref="UpdateChatParticipantAdmin"/>, <see cref="UpdateNewStickerSet"/>, <see cref="UpdateStickerSetsOrder"/>, <see cref="UpdateStickerSets"/>, <see cref="UpdateSavedGifs"/>, <see cref="UpdateBotInlineQuery"/>, <see cref="UpdateBotInlineSend"/>, <see cref="UpdateEditChannelMessage"/>, <see cref="UpdateBotCallbackQuery"/>, <see cref="UpdateEditMessage"/>, <see cref="UpdateInlineBotCallbackQuery"/>, <see cref="UpdateReadChannelOutbox"/>, <see cref="UpdateDraftMessage"/>, <see cref="UpdateReadFeaturedStickers"/>, <see cref="UpdateRecentStickers"/>, <see cref="UpdateConfig"/>, <see cref="UpdatePtsChanged"/>, <see cref="UpdateChannelWebPage"/>, <see cref="UpdateDialogPinned"/>, <see cref="UpdatePinnedDialogs"/>, <see cref="UpdateBotWebhookJSON"/>, <see cref="UpdateBotWebhookJSONQuery"/>, <see cref="UpdateBotShippingQuery"/>, <see cref="UpdateBotPrecheckoutQuery"/>, <see cref="UpdatePhoneCall"/>, <see cref="UpdateLangPackTooLong"/>, <see cref="UpdateLangPack"/>, <see cref="UpdateFavedStickers"/>, <see cref="UpdateChannelReadMessagesContents"/>, <see cref="UpdateContactsReset"/>, <see cref="UpdateChannelAvailableMessages"/>, <see cref="UpdateDialogUnreadMark"/>, <see cref="UpdateMessagePoll"/>, <see cref="UpdateChatDefaultBannedRights"/>, <see cref="UpdateFolderPeers"/>, <see cref="UpdatePeerSettings"/>, <see cref="UpdatePeerLocated"/>, <see cref="UpdateNewScheduledMessage"/>, <see cref="UpdateDeleteScheduledMessages"/>, <see cref="UpdateTheme"/>, <see cref="UpdateGeoLiveViewed"/>, <see cref="UpdateLoginToken"/>, <see cref="UpdateMessagePollVote"/>, <see cref="UpdateDialogFilter"/>, <see cref="UpdateDialogFilterOrder"/>, <see cref="UpdateDialogFilters"/>, <see cref="UpdatePhoneCallSignalingData"/>, <see cref="UpdateChannelMessageForwards"/>, <see cref="UpdateReadChannelDiscussionInbox"/>, <see cref="UpdateReadChannelDiscussionOutbox"/>, <see cref="UpdatePeerBlocked"/>, <see cref="UpdateChannelUserTyping"/>, <see cref="UpdatePinnedMessages"/>, <see cref="UpdatePinnedChannelMessages"/>, <see cref="UpdateChat"/>, <see cref="UpdateGroupCallParticipants"/>, <see cref="UpdateGroupCall"/>, <see cref="UpdatePeerHistoryTTL"/>, <see cref="UpdateChatParticipant"/>, <see cref="UpdateChannelParticipant"/>, <see cref="UpdateBotStopped"/>, <see cref="UpdateGroupCallConnection"/>, <see cref="UpdateBotCommands"/>, <see cref="UpdatePendingJoinRequests"/>, <see cref="UpdateBotChatInviteRequester"/>, <see cref="UpdateMessageReactions"/></para>		<para>See <a href="https://corefork.telegram.org/type/Update"/></para></summary>
	public abstract class Update : IObject { }
	/// <summary>New message in a private chat or in a <a href="https://core.telegram.org/api/channel#basic-groups">basic group</a>.		<para>See <a href="https://corefork.telegram.org/constructor/updateNewMessage"/></para></summary>
	[TLDef(0x1F2B0AFD)]
	public class UpdateNewMessage : Update
	{
		/// <summary>Message</summary>
		public MessageBase message;
		/// <summary>New quantity of actions in a message box</summary>
		public int pts;
		/// <summary>Number of generated events</summary>
		public int pts_count;
	}
	/// <summary>Sent message with <strong>random_id</strong> client identifier was assigned an identifier.		<para>See <a href="https://corefork.telegram.org/constructor/updateMessageID"/></para></summary>
	[TLDef(0x4E90BFD6)]
	public class UpdateMessageID : Update
	{
		/// <summary><strong>id</strong> identifier of a respective <see cref="MessageBase"/></summary>
		public int id;
		/// <summary>Previously transferred client <strong>random_id</strong> identifier</summary>
		public long random_id;
	}
	/// <summary>Messages were deleted.		<para>See <a href="https://corefork.telegram.org/constructor/updateDeleteMessages"/></para></summary>
	[TLDef(0xA20DB0E5)]
	public class UpdateDeleteMessages : Update
	{
		/// <summary>List of identifiers of deleted messages</summary>
		public int[] messages;
		/// <summary>New quality of actions in a message box</summary>
		public int pts;
		/// <summary>Number of generated <a href="https://corefork.telegram.org/api/updates">events</a></summary>
		public int pts_count;
	}
	/// <summary>The user is preparing a message; typing, recording, uploading, etc. This update is valid for 6 seconds. If no further updates of this kind are received after 6 seconds, it should be considered that the user stopped doing whatever they were doing		<para>See <a href="https://corefork.telegram.org/constructor/updateUserTyping"/></para></summary>
	[TLDef(0xC01E857F)]
	public class UpdateUserTyping : Update
	{
		/// <summary>User id</summary>
		public long user_id;
		/// <summary>Action type<br/>Param added in <a href="https://corefork.telegram.org/api/layers#layer-17">Layer 17</a>.</summary>
		public SendMessageAction action;
	}
	/// <summary>The user is preparing a message in a group; typing, recording, uploading, etc. This update is valid for 6 seconds. If no further updates of this kind are received after 6 seconds, it should be considered that the user stopped doing whatever they were doing		<para>See <a href="https://corefork.telegram.org/constructor/updateChatUserTyping"/></para></summary>
	[TLDef(0x83487AF0, inheritBefore = true)]
	public class UpdateChatUserTyping : UpdateChat
	{
		/// <summary>Peer that started typing (can be the chat itself, in case of anonymous admins).</summary>
		public Peer from_id;
		/// <summary>Type of action<br/>Parameter added in <a href="https://corefork.telegram.org/api/layers#layer-17">Layer 17</a>.</summary>
		public SendMessageAction action;
	}
	/// <summary>Composition of chat participants changed.		<para>See <a href="https://corefork.telegram.org/constructor/updateChatParticipants"/></para></summary>
	[TLDef(0x07761198)]
	public class UpdateChatParticipants : Update
	{
		/// <summary>Updated chat participants</summary>
		public ChatParticipantsBase participants;
	}
	/// <summary>Contact status update.		<para>See <a href="https://corefork.telegram.org/constructor/updateUserStatus"/></para></summary>
	[TLDef(0xE5BDF8DE)]
	public class UpdateUserStatus : Update
	{
		/// <summary>User identifier</summary>
		public long user_id;
		/// <summary>New status</summary>
		public UserStatus status;
	}
	/// <summary>Changes the user's first name, last name and username.		<para>See <a href="https://corefork.telegram.org/constructor/updateUserName"/></para></summary>
	[TLDef(0xC3F202E0)]
	public class UpdateUserName : Update
	{
		/// <summary>User identifier</summary>
		public long user_id;
		/// <summary>New first name. Corresponds to the new value of <strong>real_first_name</strong> field of the <see cref="UserFull"/> constructor.</summary>
		public string first_name;
		/// <summary>New last name. Corresponds to the new value of <strong>real_last_name</strong> field of the <see cref="UserFull"/> constructor.</summary>
		public string last_name;
		/// <summary>New username.<br/>Parameter added in <a href="https://corefork.telegram.org/api/layers#layer-18">Layer 18</a>.</summary>
		public string username;
	}
	/// <summary>Change of contact's profile photo.		<para>See <a href="https://corefork.telegram.org/constructor/updateUserPhoto"/></para></summary>
	[TLDef(0xF227868C)]
	public class UpdateUserPhoto : Update
	{
		/// <summary>User identifier</summary>
		public long user_id;
		/// <summary>Date of photo update.</summary>
		public DateTime date;
		/// <summary>New profile photo</summary>
		public UserProfilePhoto photo;
		/// <summary>(<see cref="Bool.True"/>), if one of the previously used photos is set a profile photo.</summary>
		public bool previous;
	}
	/// <summary>New encrypted message.		<para>See <a href="https://corefork.telegram.org/constructor/updateNewEncryptedMessage"/></para></summary>
	[TLDef(0x12BCBD9A)]
	public class UpdateNewEncryptedMessage : Update
	{
		/// <summary>Message</summary>
		public EncryptedMessageBase message;
		/// <summary>New <strong>qts</strong> value, see <a href="https://corefork.telegram.org/api/updates">updates »</a> for more info.</summary>
		public int qts;
	}
	/// <summary>Interlocutor is typing a message in an encrypted chat. Update period is 6 second. If upon this time there is no repeated update, it shall be considered that the interlocutor stopped typing.		<para>See <a href="https://corefork.telegram.org/constructor/updateEncryptedChatTyping"/></para></summary>
	[TLDef(0x1710F156)]
	public class UpdateEncryptedChatTyping : Update
	{
		/// <summary>Chat ID</summary>
		public int chat_id;
	}
	/// <summary>Change of state in an encrypted chat.		<para>See <a href="https://corefork.telegram.org/constructor/updateEncryption"/></para></summary>
	[TLDef(0xB4A2E88D)]
	public class UpdateEncryption : Update
	{
		/// <summary>Encrypted chat</summary>
		public EncryptedChatBase chat;
		/// <summary>Date of change</summary>
		public DateTime date;
	}
	/// <summary>Communication history in an encrypted chat was marked as read.		<para>See <a href="https://corefork.telegram.org/constructor/updateEncryptedMessagesRead"/></para></summary>
	[TLDef(0x38FE25B7)]
	public class UpdateEncryptedMessagesRead : Update
	{
		/// <summary>Chat ID</summary>
		public int chat_id;
		/// <summary>Maximum value of data for read messages</summary>
		public DateTime max_date;
		/// <summary>Time when messages were read</summary>
		public DateTime date;
	}
	/// <summary>New group member.		<para>See <a href="https://corefork.telegram.org/constructor/updateChatParticipantAdd"/></para></summary>
	[TLDef(0x3DDA5451, inheritBefore = true)]
	public class UpdateChatParticipantAdd : UpdateChat
	{
		/// <summary>ID of the new member</summary>
		public long user_id;
		/// <summary>ID of the user, who added member to the group</summary>
		public long inviter_id;
		/// <summary>When was the participant added</summary>
		public DateTime date;
		/// <summary>Chat version number</summary>
		public int version;
	}
	/// <summary>A member has left the group.		<para>See <a href="https://corefork.telegram.org/constructor/updateChatParticipantDelete"/></para></summary>
	[TLDef(0xE32F3D77, inheritBefore = true)]
	public class UpdateChatParticipantDelete : UpdateChat
	{
		/// <summary>ID of the user</summary>
		public long user_id;
		/// <summary>Used in basic groups to reorder updates and make sure that all of them was received.</summary>
		public int version;
	}
	/// <summary>Changes in the data center configuration options.		<para>See <a href="https://corefork.telegram.org/constructor/updateDcOptions"/></para></summary>
	[TLDef(0x8E5E9873)]
	public class UpdateDcOptions : Update
	{
		/// <summary>New connection options</summary>
		public DcOption[] dc_options;
	}
	/// <summary>Changes in notification settings.		<para>See <a href="https://corefork.telegram.org/constructor/updateNotifySettings"/></para></summary>
	[TLDef(0xBEC268EF)]
	public class UpdateNotifySettings : Update
	{
		/// <summary>Notification source</summary>
		public NotifyPeerBase peer;
		/// <summary>New notification settings</summary>
		public PeerNotifySettings notify_settings;
	}
	/// <summary>A service message for the user.		<para>See <a href="https://corefork.telegram.org/constructor/updateServiceNotification"/></para></summary>
	[TLDef(0xEBE46819)]
	public class UpdateServiceNotification : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>When was the notification received<br/>The message must also be stored locally as part of the message history with the user id <c>777000</c> (Telegram Notifications).</summary>
		[IfFlag(1)] public DateTime inbox_date;
		/// <summary>String, identical in format and contents to the <a href="https://corefork.telegram.org/api/errors#error-type"><strong>type</strong></a> field in API errors. Describes type of service message. It is acceptable to ignore repeated messages of the same <strong>type</strong> within a short period of time (15 minutes).</summary>
		public string type;
		/// <summary>Message text</summary>
		public string message;
		/// <summary>Media content (optional)</summary>
		public MessageMedia media;
		/// <summary><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></summary>
		public MessageEntity[] entities;

		[Flags] public enum Flags : uint
		{
			/// <summary>(boolTrue) if the message must be displayed in a popup.</summary>
			popup = 0x1,
			/// <summary>Field <see cref="inbox_date"/> has a value</summary>
			has_inbox_date = 0x2,
		}
	}
	/// <summary>Privacy rules were changed		<para>See <a href="https://corefork.telegram.org/constructor/updatePrivacy"/></para></summary>
	[TLDef(0xEE3B272A)]
	public class UpdatePrivacy : Update
	{
		/// <summary>Peers to which the privacy rules apply</summary>
		public PrivacyKey key;
		/// <summary>New privacy rules</summary>
		public PrivacyRule[] rules;
	}
	/// <summary>A user's phone number was changed		<para>See <a href="https://corefork.telegram.org/constructor/updateUserPhone"/></para></summary>
	[TLDef(0x05492A13)]
	public class UpdateUserPhone : Update
	{
		/// <summary>User ID</summary>
		public long user_id;
		/// <summary>New phone number</summary>
		public string phone;
	}
	/// <summary>Incoming messages were read		<para>See <a href="https://corefork.telegram.org/constructor/updateReadHistoryInbox"/></para></summary>
	[TLDef(0x9C974FDF)]
	public class UpdateReadHistoryInbox : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		[IfFlag(0)] public int folder_id;
		/// <summary>Peer</summary>
		public Peer peer;
		/// <summary>Maximum ID of messages read</summary>
		public int max_id;
		/// <summary>Number of messages that are still unread</summary>
		public int still_unread_count;
		/// <summary><a href="https://corefork.telegram.org/api/updates">Event count after generation</a></summary>
		public int pts;
		/// <summary><a href="https://corefork.telegram.org/api/updates">Number of events that were generated</a></summary>
		public int pts_count;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="folder_id"/> has a value</summary>
			has_folder_id = 0x1,
		}
	}
	/// <summary>Outgoing messages were read		<para>See <a href="https://corefork.telegram.org/constructor/updateReadHistoryOutbox"/></para></summary>
	[TLDef(0x2F2F21BF)]
	public class UpdateReadHistoryOutbox : Update
	{
		/// <summary>Peer</summary>
		public Peer peer;
		/// <summary>Maximum ID of read outgoing messages</summary>
		public int max_id;
		/// <summary><a href="https://corefork.telegram.org/api/updates">Event count after generation</a></summary>
		public int pts;
		/// <summary><a href="https://corefork.telegram.org/api/updates">Number of events that were generated</a></summary>
		public int pts_count;
	}
	/// <summary>An <a href="https://instantview.telegram.org">instant view</a> webpage preview was generated		<para>See <a href="https://corefork.telegram.org/constructor/updateWebPage"/></para></summary>
	[TLDef(0x7F891213)]
	public class UpdateWebPage : Update
	{
		/// <summary>Webpage preview</summary>
		public WebPageBase webpage;
		/// <summary><a href="https://corefork.telegram.org/api/updates">Event count after generation</a></summary>
		public int pts;
		/// <summary><a href="https://corefork.telegram.org/api/updates">Number of events that were generated</a></summary>
		public int pts_count;
	}
	/// <summary>Contents of messages in the common <a href="https://corefork.telegram.org/api/updates">message box</a> were read		<para>See <a href="https://corefork.telegram.org/constructor/updateReadMessagesContents"/></para></summary>
	[TLDef(0x68C13933)]
	public class UpdateReadMessagesContents : Update
	{
		/// <summary>IDs of read messages</summary>
		public int[] messages;
		/// <summary><a href="https://corefork.telegram.org/api/updates">Event count after generation</a></summary>
		public int pts;
		/// <summary><a href="https://corefork.telegram.org/api/updates">Number of events that were generated</a></summary>
		public int pts_count;
	}
	/// <summary>There are new updates in the specified channel, the client must fetch them.<br/>If the difference is too long or if the channel isn't currently in the states, start fetching from the specified pts.		<para>See <a href="https://corefork.telegram.org/constructor/updateChannelTooLong"/></para></summary>
	[TLDef(0x108D941F)]
	public class UpdateChannelTooLong : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The channel</summary>
		public long channel_id;
		/// <summary>The <a href="https://corefork.telegram.org/api/updates">PTS</a>.</summary>
		[IfFlag(0)] public int pts;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="pts"/> has a value</summary>
			has_pts = 0x1,
		}
	}
	/// <summary>A new channel is available		<para>See <a href="https://corefork.telegram.org/constructor/updateChannel"/></para></summary>
	[TLDef(0x635B4C09)]
	public class UpdateChannel : Update
	{
		/// <summary>Channel ID</summary>
		public long channel_id;
	}
	/// <summary>A new message was sent in a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>		<para>See <a href="https://corefork.telegram.org/constructor/updateNewChannelMessage"/></para></summary>
	[TLDef(0x62BA04D9)]
	public class UpdateNewChannelMessage : UpdateNewMessage { }
	/// <summary>Incoming messages in a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> were read		<para>See <a href="https://corefork.telegram.org/constructor/updateReadChannelInbox"/></para></summary>
	[TLDef(0x922E6E10)]
	public class UpdateReadChannelInbox : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		[IfFlag(0)] public int folder_id;
		/// <summary>Channel/supergroup ID</summary>
		public long channel_id;
		/// <summary>Position up to which all incoming messages are read.</summary>
		public int max_id;
		/// <summary>Count of messages weren't read yet</summary>
		public int still_unread_count;
		/// <summary><a href="https://corefork.telegram.org/api/updates">Event count after generation</a></summary>
		public int pts;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="folder_id"/> has a value</summary>
			has_folder_id = 0x1,
		}
	}
	/// <summary>Some messages in a <a href="https://corefork.telegram.org/api/channel">supergroup/channel</a> were deleted		<para>See <a href="https://corefork.telegram.org/constructor/updateDeleteChannelMessages"/></para></summary>
	[TLDef(0xC32D5B12)]
	public class UpdateDeleteChannelMessages : UpdateDeleteMessages
	{
		/// <summary>Channel ID</summary>
		public long channel_id;
	}
	/// <summary>The view counter of a message in a channel has changed		<para>See <a href="https://corefork.telegram.org/constructor/updateChannelMessageViews"/></para></summary>
	[TLDef(0xF226AC08, inheritBefore = true)]
	public class UpdateChannelMessageViews : UpdateChannel
	{
		/// <summary>ID of the message</summary>
		public int id;
		/// <summary>New view counter</summary>
		public int views;
	}
	/// <summary>Admin permissions of a user in a <a href="https://corefork.telegram.org/api/channel#basic-groups">basic group</a> were changed		<para>See <a href="https://corefork.telegram.org/constructor/updateChatParticipantAdmin"/></para></summary>
	[TLDef(0xD7CA61A2, inheritBefore = true)]
	public class UpdateChatParticipantAdmin : UpdateChat
	{
		/// <summary>ID of the (de)admined user</summary>
		public long user_id;
		/// <summary>Whether the user was rendered admin</summary>
		public bool is_admin;
		/// <summary>Used in basic groups to reorder updates and make sure that all of them was received.</summary>
		public int version;
	}
	/// <summary>A new stickerset was installed		<para>See <a href="https://corefork.telegram.org/constructor/updateNewStickerSet"/></para></summary>
	[TLDef(0x688A30AA)]
	public class UpdateNewStickerSet : Update
	{
		/// <summary>The installed stickerset</summary>
		public Messages_StickerSet stickerset;
	}
	/// <summary>The order of stickersets was changed		<para>See <a href="https://corefork.telegram.org/constructor/updateStickerSetsOrder"/></para></summary>
	[TLDef(0x0BB2D201)]
	public class UpdateStickerSetsOrder : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>New sticker order by sticker ID</summary>
		public long[] order;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the updated stickers are mask stickers</summary>
			masks = 0x1,
		}
	}
	/// <summary>Installed stickersets have changed, the client should refetch them using <a href="https://core.telegram.org/method/messages.getAllStickers">messages.getAllStickers</a>		<para>See <a href="https://corefork.telegram.org/constructor/updateStickerSets"/></para></summary>
	[TLDef(0x43AE3DEC)]
	public class UpdateStickerSets : Update { }
	/// <summary>The saved gif list has changed, the client should refetch it using <a href="https://core.telegram.org/method/messages.getSavedGifs">messages.getSavedGifs</a>		<para>See <a href="https://corefork.telegram.org/constructor/updateSavedGifs"/></para></summary>
	[TLDef(0x9375341E)]
	public class UpdateSavedGifs : Update { }
	/// <summary>An incoming inline query		<para>See <a href="https://corefork.telegram.org/constructor/updateBotInlineQuery"/></para></summary>
	[TLDef(0x496F379C)]
	public class UpdateBotInlineQuery : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Query ID</summary>
		public long query_id;
		/// <summary>User that sent the query</summary>
		public long user_id;
		/// <summary>Text of query</summary>
		public string query;
		/// <summary>Attached geolocation</summary>
		[IfFlag(0)] public GeoPoint geo;
		/// <summary>Type of the chat from which the inline query was sent.</summary>
		[IfFlag(1)] public InlineQueryPeerType peer_type;
		/// <summary>Offset to navigate through results</summary>
		public string offset;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="geo"/> has a value</summary>
			has_geo = 0x1,
			/// <summary>Field <see cref="peer_type"/> has a value</summary>
			has_peer_type = 0x2,
		}
	}
	/// <summary>The result of an inline query that was chosen by a user and sent to their chat partner. Please see our documentation on the <a href="https://core.telegram.org/bots/inline#collecting-feedback">feedback collecting</a> for details on how to enable these updates for your bot.		<para>See <a href="https://corefork.telegram.org/constructor/updateBotInlineSend"/></para></summary>
	[TLDef(0x12F12A07)]
	public class UpdateBotInlineSend : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The user that chose the result</summary>
		public long user_id;
		/// <summary>The query that was used to obtain the result</summary>
		public string query;
		/// <summary>Optional. Sender location, only for bots that require user location</summary>
		[IfFlag(0)] public GeoPoint geo;
		/// <summary>The unique identifier for the result that was chosen</summary>
		public string id;
		/// <summary>Identifier of the sent inline message. Available only if there is an inline keyboard attached to the message. Will be also received in callback queries and can be used to edit the message.</summary>
		[IfFlag(1)] public InputBotInlineMessageIDBase msg_id;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="geo"/> has a value</summary>
			has_geo = 0x1,
			/// <summary>Field <see cref="msg_id"/> has a value</summary>
			has_msg_id = 0x2,
		}
	}
	/// <summary>A message was edited in a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>		<para>See <a href="https://corefork.telegram.org/constructor/updateEditChannelMessage"/></para></summary>
	[TLDef(0x1B3F4DF7)]
	public class UpdateEditChannelMessage : UpdateEditMessage { }
	/// <summary>A callback button was pressed, and the button data was sent to the bot that created the button		<para>See <a href="https://corefork.telegram.org/constructor/updateBotCallbackQuery"/></para></summary>
	[TLDef(0xB9CFC48D)]
	public class UpdateBotCallbackQuery : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Query ID</summary>
		public long query_id;
		/// <summary>ID of the user that pressed the button</summary>
		public long user_id;
		/// <summary>Chat where the inline keyboard was sent</summary>
		public Peer peer;
		/// <summary>Message ID</summary>
		public int msg_id;
		/// <summary>Global identifier, uniquely corresponding to the chat to which the message with the callback button was sent. Useful for high scores in games.</summary>
		public long chat_instance;
		/// <summary>Callback data</summary>
		[IfFlag(0)] public byte[] data;
		/// <summary>Short name of a Game to be returned, serves as the unique identifier for the game</summary>
		[IfFlag(1)] public string game_short_name;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="data"/> has a value</summary>
			has_data = 0x1,
			/// <summary>Field <see cref="game_short_name"/> has a value</summary>
			has_game_short_name = 0x2,
		}
	}
	/// <summary>A message was edited		<para>See <a href="https://corefork.telegram.org/constructor/updateEditMessage"/></para></summary>
	[TLDef(0xE40370A3)]
	public class UpdateEditMessage : Update
	{
		/// <summary>The new edited message</summary>
		public MessageBase message;
		/// <summary><a href="https://corefork.telegram.org/api/updates">PTS</a></summary>
		public int pts;
		/// <summary><a href="https://corefork.telegram.org/api/updates">PTS count</a></summary>
		public int pts_count;
	}
	/// <summary>This notification is received by bots when a button is pressed		<para>See <a href="https://corefork.telegram.org/constructor/updateInlineBotCallbackQuery"/></para></summary>
	[TLDef(0x691E9052)]
	public class UpdateInlineBotCallbackQuery : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Query ID</summary>
		public long query_id;
		/// <summary>ID of the user that pressed the button</summary>
		public long user_id;
		/// <summary>ID of the inline message with the button</summary>
		public InputBotInlineMessageIDBase msg_id;
		/// <summary>Global identifier, uniquely corresponding to the chat to which the message with the callback button was sent. Useful for high scores in games.</summary>
		public long chat_instance;
		/// <summary>Data associated with the callback button. Be aware that a bad client can send arbitrary data in this field.</summary>
		[IfFlag(0)] public byte[] data;
		/// <summary>Short name of a Game to be returned, serves as the unique identifier for the game</summary>
		[IfFlag(1)] public string game_short_name;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="data"/> has a value</summary>
			has_data = 0x1,
			/// <summary>Field <see cref="game_short_name"/> has a value</summary>
			has_game_short_name = 0x2,
		}
	}
	/// <summary>Outgoing messages in a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> were read		<para>See <a href="https://corefork.telegram.org/constructor/updateReadChannelOutbox"/></para></summary>
	[TLDef(0xB75F99A9)]
	public class UpdateReadChannelOutbox : Update
	{
		/// <summary>Channel/supergroup ID</summary>
		public long channel_id;
		/// <summary>Position up to which all outgoing messages are read.</summary>
		public int max_id;
	}
	/// <summary>Notifies a change of a message <a href="https://corefork.telegram.org/api/drafts">draft</a>.		<para>See <a href="https://corefork.telegram.org/constructor/updateDraftMessage"/></para></summary>
	[TLDef(0xEE2BB969)]
	public class UpdateDraftMessage : Update
	{
		/// <summary>The peer to which the draft is associated</summary>
		public Peer peer;
		/// <summary>The draft</summary>
		public DraftMessageBase draft;
	}
	/// <summary>Some featured stickers were marked as read		<para>See <a href="https://corefork.telegram.org/constructor/updateReadFeaturedStickers"/></para></summary>
	[TLDef(0x571D2742)]
	public class UpdateReadFeaturedStickers : Update { }
	/// <summary>The recent sticker list was updated		<para>See <a href="https://corefork.telegram.org/constructor/updateRecentStickers"/></para></summary>
	[TLDef(0x9A422C20)]
	public class UpdateRecentStickers : Update { }
	/// <summary>The server-side configuration has changed; the client should re-fetch the config using <a href="https://corefork.telegram.org/method/help.getConfig">help.getConfig</a>		<para>See <a href="https://corefork.telegram.org/constructor/updateConfig"/></para></summary>
	[TLDef(0xA229DD06)]
	public class UpdateConfig : Update { }
	/// <summary><a href="https://corefork.telegram.org/api/updates">Common message box sequence PTS</a> has changed, <a href="https://corefork.telegram.org/api/updates#fetching-state">state has to be refetched using updates.getState</a>		<para>See <a href="https://corefork.telegram.org/constructor/updatePtsChanged"/></para></summary>
	[TLDef(0x3354678F)]
	public class UpdatePtsChanged : Update { }
	/// <summary>A webpage preview of a link in a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> message was generated		<para>See <a href="https://corefork.telegram.org/constructor/updateChannelWebPage"/></para></summary>
	[TLDef(0x2F2BA99F)]
	public class UpdateChannelWebPage : UpdateWebPage
	{
		/// <summary><a href="https://corefork.telegram.org/api/channel">Channel/supergroup</a> ID</summary>
		public long channel_id;
	}
	/// <summary>A dialog was pinned/unpinned		<para>See <a href="https://corefork.telegram.org/constructor/updateDialogPinned"/></para></summary>
	[TLDef(0x6E6FE51C)]
	public class UpdateDialogPinned : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		[IfFlag(1)] public int folder_id;
		/// <summary>The dialog</summary>
		public DialogPeerBase peer;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the dialog was pinned</summary>
			pinned = 0x1,
			/// <summary>Field <see cref="folder_id"/> has a value</summary>
			has_folder_id = 0x2,
		}
	}
	/// <summary>Pinned dialogs were updated		<para>See <a href="https://corefork.telegram.org/constructor/updatePinnedDialogs"/></para></summary>
	[TLDef(0xFA0F3CA2)]
	public class UpdatePinnedDialogs : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		[IfFlag(1)] public int folder_id;
		/// <summary>New order of pinned dialogs</summary>
		[IfFlag(0)] public DialogPeerBase[] order;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="order"/> has a value</summary>
			has_order = 0x1,
			/// <summary>Field <see cref="folder_id"/> has a value</summary>
			has_folder_id = 0x2,
		}
	}
	/// <summary>A new incoming event; for bots only		<para>See <a href="https://corefork.telegram.org/constructor/updateBotWebhookJSON"/></para></summary>
	[TLDef(0x8317C0C3)]
	public class UpdateBotWebhookJSON : Update
	{
		/// <summary>The event</summary>
		public DataJSON data;
	}
	/// <summary>A new incoming query; for bots only		<para>See <a href="https://corefork.telegram.org/constructor/updateBotWebhookJSONQuery"/></para></summary>
	[TLDef(0x9B9240A6)]
	public class UpdateBotWebhookJSONQuery : Update
	{
		/// <summary>Query identifier</summary>
		public long query_id;
		/// <summary>Query data</summary>
		public DataJSON data;
		/// <summary>Query timeout</summary>
		public int timeout;
	}
	/// <summary>This object contains information about an incoming shipping query.		<para>See <a href="https://corefork.telegram.org/constructor/updateBotShippingQuery"/></para></summary>
	[TLDef(0xB5AEFD7D)]
	public class UpdateBotShippingQuery : Update
	{
		/// <summary>Unique query identifier</summary>
		public long query_id;
		/// <summary>User who sent the query</summary>
		public long user_id;
		/// <summary>Bot specified invoice payload</summary>
		public byte[] payload;
		/// <summary>User specified shipping address</summary>
		public PostAddress shipping_address;
	}
	/// <summary>This object contains information about an incoming pre-checkout query.		<para>See <a href="https://corefork.telegram.org/constructor/updateBotPrecheckoutQuery"/></para></summary>
	[TLDef(0x8CAA9A96)]
	public class UpdateBotPrecheckoutQuery : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Unique query identifier</summary>
		public long query_id;
		/// <summary>User who sent the query</summary>
		public long user_id;
		/// <summary>Bot specified invoice payload</summary>
		public byte[] payload;
		/// <summary>Order info provided by the user</summary>
		[IfFlag(0)] public PaymentRequestedInfo info;
		/// <summary>Identifier of the shipping option chosen by the user</summary>
		[IfFlag(1)] public string shipping_option_id;
		/// <summary>Three-letter ISO 4217 <a href="https://corefork.telegram.org/bots/payments#supported-currencies">currency</a> code</summary>
		public string currency;
		/// <summary>Total amount in the smallest units of the currency (integer, not float/double). For example, for a price of <c>US$ 1.45</c> pass <c>amount = 145</c>. See the exp parameter in <a href="https://corefork.telegram.org/bots/payments/currencies.json">currencies.json</a>, it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).</summary>
		public long total_amount;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="info"/> has a value</summary>
			has_info = 0x1,
			/// <summary>Field <see cref="shipping_option_id"/> has a value</summary>
			has_shipping_option_id = 0x2,
		}
	}
	/// <summary>An incoming phone call		<para>See <a href="https://corefork.telegram.org/constructor/updatePhoneCall"/></para></summary>
	[TLDef(0xAB0F6B1E)]
	public class UpdatePhoneCall : Update
	{
		/// <summary>Phone call</summary>
		public PhoneCallBase phone_call;
	}
	/// <summary>A language pack has changed, the client should manually fetch the changed strings using <a href="https://corefork.telegram.org/method/langpack.getDifference">langpack.getDifference</a>		<para>See <a href="https://corefork.telegram.org/constructor/updateLangPackTooLong"/></para></summary>
	[TLDef(0x46560264)]
	public class UpdateLangPackTooLong : Update
	{
		/// <summary>Language code</summary>
		public string lang_code;
	}
	/// <summary>Language pack updated		<para>See <a href="https://corefork.telegram.org/constructor/updateLangPack"/></para></summary>
	[TLDef(0x56022F4D)]
	public class UpdateLangPack : Update
	{
		/// <summary>Changed strings</summary>
		public LangPackDifference difference;
	}
	/// <summary>The list of favorited stickers was changed, the client should call <a href="https://corefork.telegram.org/method/messages.getFavedStickers">messages.getFavedStickers</a> to refetch the new list		<para>See <a href="https://corefork.telegram.org/constructor/updateFavedStickers"/></para></summary>
	[TLDef(0xE511996D)]
	public class UpdateFavedStickers : Update { }
	/// <summary>The specified <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> messages were read		<para>See <a href="https://corefork.telegram.org/constructor/updateChannelReadMessagesContents"/></para></summary>
	[TLDef(0x44BDD535, inheritBefore = true)]
	public class UpdateChannelReadMessagesContents : UpdateChannel
	{
		/// <summary>IDs of messages that were read</summary>
		public int[] messages;
	}
	/// <summary>All contacts were deleted		<para>See <a href="https://corefork.telegram.org/constructor/updateContactsReset"/></para></summary>
	[TLDef(0x7084A7BE)]
	public class UpdateContactsReset : Update { }
	/// <summary>The history of a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> was hidden.		<para>See <a href="https://corefork.telegram.org/constructor/updateChannelAvailableMessages"/></para></summary>
	[TLDef(0xB23FC698, inheritBefore = true)]
	public class UpdateChannelAvailableMessages : UpdateChannel
	{
		/// <summary>Identifier of a maximum unavailable message in a channel due to hidden history.</summary>
		public int available_min_id;
	}
	/// <summary>The manual unread mark of a chat was changed		<para>See <a href="https://corefork.telegram.org/constructor/updateDialogUnreadMark"/></para></summary>
	[TLDef(0xE16459C3)]
	public class UpdateDialogUnreadMark : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The dialog</summary>
		public DialogPeerBase peer;

		[Flags] public enum Flags : uint
		{
			/// <summary>Was the chat marked or unmarked as read</summary>
			unread = 0x1,
		}
	}
	/// <summary>The results of a poll have changed		<para>See <a href="https://corefork.telegram.org/constructor/updateMessagePoll"/></para></summary>
	[TLDef(0xACA1657B)]
	public class UpdateMessagePoll : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Poll ID</summary>
		public long poll_id;
		/// <summary>If the server knows the client hasn't cached this poll yet, the poll itself</summary>
		[IfFlag(0)] public Poll poll;
		/// <summary>New poll results</summary>
		public PollResults results;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="poll"/> has a value</summary>
			has_poll = 0x1,
		}
	}
	/// <summary>Default banned rights in a <a href="https://corefork.telegram.org/api/channel">normal chat</a> were updated		<para>See <a href="https://corefork.telegram.org/constructor/updateChatDefaultBannedRights"/></para></summary>
	[TLDef(0x54C01850)]
	public class UpdateChatDefaultBannedRights : Update
	{
		/// <summary>The chat</summary>
		public Peer peer;
		/// <summary>New default banned rights</summary>
		public ChatBannedRights default_banned_rights;
		/// <summary>Version</summary>
		public int version;
	}
	/// <summary>The peer list of a <a href="https://corefork.telegram.org/api/folders#peer-folders">peer folder</a> was updated		<para>See <a href="https://corefork.telegram.org/constructor/updateFolderPeers"/></para></summary>
	[TLDef(0x19360DC0)]
	public class UpdateFolderPeers : Update
	{
		/// <summary>New peer list</summary>
		public FolderPeer[] folder_peers;
		/// <summary><a href="https://corefork.telegram.org/api/updates">Event count after generation</a></summary>
		public int pts;
		/// <summary><a href="https://corefork.telegram.org/api/updates">Number of events that were generated</a></summary>
		public int pts_count;
	}
	/// <summary>Settings of a certain peer have changed		<para>See <a href="https://corefork.telegram.org/constructor/updatePeerSettings"/></para></summary>
	[TLDef(0x6A7E7366)]
	public class UpdatePeerSettings : Update
	{
		/// <summary>The peer</summary>
		public Peer peer;
		/// <summary>Associated peer settings</summary>
		public PeerSettings settings;
	}
	/// <summary>List of peers near you was updated		<para>See <a href="https://corefork.telegram.org/constructor/updatePeerLocated"/></para></summary>
	[TLDef(0xB4AFCFB0)]
	public class UpdatePeerLocated : Update
	{
		/// <summary>Geolocated peer list update</summary>
		public PeerLocatedBase[] peers;
	}
	/// <summary>A message was added to the <a href="https://corefork.telegram.org/api/scheduled-messages">schedule queue of a chat</a>		<para>See <a href="https://corefork.telegram.org/constructor/updateNewScheduledMessage"/></para></summary>
	[TLDef(0x39A51DFB)]
	public class UpdateNewScheduledMessage : Update
	{
		/// <summary>Message</summary>
		public MessageBase message;
	}
	/// <summary>Some <a href="https://corefork.telegram.org/api/scheduled-messages">scheduled messages</a> were deleted from the schedule queue of a chat		<para>See <a href="https://corefork.telegram.org/constructor/updateDeleteScheduledMessages"/></para></summary>
	[TLDef(0x90866CEE)]
	public class UpdateDeleteScheduledMessages : Update
	{
		/// <summary>Peer</summary>
		public Peer peer;
		/// <summary>Deleted scheduled messages</summary>
		public int[] messages;
	}
	/// <summary>A cloud theme was updated		<para>See <a href="https://corefork.telegram.org/constructor/updateTheme"/></para></summary>
	[TLDef(0x8216FBA3)]
	public class UpdateTheme : Update
	{
		/// <summary>Theme</summary>
		public Theme theme;
	}
	/// <summary>Live geoposition message was viewed		<para>See <a href="https://corefork.telegram.org/constructor/updateGeoLiveViewed"/></para></summary>
	[TLDef(0x871FB939)]
	public class UpdateGeoLiveViewed : Update
	{
		/// <summary>The user that viewed the live geoposition</summary>
		public Peer peer;
		/// <summary>Message ID of geoposition message</summary>
		public int msg_id;
	}
	/// <summary>A login token (for login via QR code) was accepted.		<para>See <a href="https://corefork.telegram.org/constructor/updateLoginToken"/></para></summary>
	[TLDef(0x564FE691)]
	public class UpdateLoginToken : Update { }
	/// <summary>A specific user has voted in a poll		<para>See <a href="https://corefork.telegram.org/constructor/updateMessagePollVote"/></para></summary>
	[TLDef(0x106395C9)]
	public class UpdateMessagePollVote : Update
	{
		/// <summary>Poll ID</summary>
		public long poll_id;
		/// <summary>User ID</summary>
		public long user_id;
		/// <summary>Chosen option(s)</summary>
		public byte[][] options;
		/// <summary>New <strong>qts</strong> value, see <a href="https://corefork.telegram.org/api/updates">updates »</a> for more info.</summary>
		public int qts;
	}
	/// <summary>A new <a href="https://corefork.telegram.org/api/folders">folder</a> was added		<para>See <a href="https://corefork.telegram.org/constructor/updateDialogFilter"/></para></summary>
	[TLDef(0x26FFDE7D)]
	public class UpdateDialogFilter : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary><a href="https://corefork.telegram.org/api/folders">Folder</a> ID</summary>
		public int id;
		/// <summary><a href="https://corefork.telegram.org/api/folders">Folder</a> info</summary>
		[IfFlag(0)] public DialogFilter filter;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="filter"/> has a value</summary>
			has_filter = 0x1,
		}
	}
	/// <summary>New <a href="https://corefork.telegram.org/api/folders">folder</a> order		<para>See <a href="https://corefork.telegram.org/constructor/updateDialogFilterOrder"/></para></summary>
	[TLDef(0xA5D72105)]
	public class UpdateDialogFilterOrder : Update
	{
		/// <summary>Ordered <a href="https://corefork.telegram.org/api/folders">folder IDs</a></summary>
		public int[] order;
	}
	/// <summary>Clients should update <a href="https://corefork.telegram.org/api/folders">folder</a> info		<para>See <a href="https://corefork.telegram.org/constructor/updateDialogFilters"/></para></summary>
	[TLDef(0x3504914F)]
	public class UpdateDialogFilters : Update { }
	/// <summary>Incoming phone call signaling payload		<para>See <a href="https://corefork.telegram.org/constructor/updatePhoneCallSignalingData"/></para></summary>
	[TLDef(0x2661BF09)]
	public class UpdatePhoneCallSignalingData : Update
	{
		/// <summary>Phone call ID</summary>
		public long phone_call_id;
		/// <summary>Signaling payload</summary>
		public byte[] data;
	}
	/// <summary>The forward counter of a message in a channel has changed		<para>See <a href="https://corefork.telegram.org/constructor/updateChannelMessageForwards"/></para></summary>
	[TLDef(0xD29A27F4, inheritBefore = true)]
	public class UpdateChannelMessageForwards : UpdateChannel
	{
		/// <summary>ID of the message</summary>
		public int id;
		/// <summary>New forward counter</summary>
		public int forwards;
	}
	/// <summary>Incoming comments in a <a href="https://corefork.telegram.org/api/threads">discussion thread</a> were marked as read		<para>See <a href="https://corefork.telegram.org/constructor/updateReadChannelDiscussionInbox"/></para></summary>
	[TLDef(0xD6B19546)]
	public class UpdateReadChannelDiscussionInbox : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary><a href="https://corefork.telegram.org/api/channel">Discussion group ID</a></summary>
		public long channel_id;
		/// <summary>ID of the group message that started the <a href="https://corefork.telegram.org/api/threads">thread</a> (message in linked discussion group)</summary>
		public int top_msg_id;
		/// <summary>Message ID of latest read incoming message for this <a href="https://corefork.telegram.org/api/threads">thread</a></summary>
		public int read_max_id;
		/// <summary>If set, contains the ID of the <a href="https://corefork.telegram.org/api/channel">channel</a> that contains the post that started the <a href="https://corefork.telegram.org/api/threads">comment thread</a> in the discussion group (<c>channel_id</c>)</summary>
		[IfFlag(0)] public long broadcast_id;
		/// <summary>If set, contains the ID of the channel post that started the the <a href="https://corefork.telegram.org/api/threads">comment thread</a></summary>
		[IfFlag(0)] public int broadcast_post;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="broadcast_id"/> has a value</summary>
			has_broadcast_id = 0x1,
		}
	}
	/// <summary>Outgoing comments in a <a href="https://corefork.telegram.org/api/threads">discussion thread</a> were marked as read		<para>See <a href="https://corefork.telegram.org/constructor/updateReadChannelDiscussionOutbox"/></para></summary>
	[TLDef(0x695C9E7C)]
	public class UpdateReadChannelDiscussionOutbox : Update
	{
		/// <summary><a href="https://corefork.telegram.org/api/channel">Supergroup ID</a></summary>
		public long channel_id;
		/// <summary>ID of the group message that started the <a href="https://corefork.telegram.org/api/threads">thread</a></summary>
		public int top_msg_id;
		/// <summary>Message ID of latest read outgoing message for this <a href="https://corefork.telegram.org/api/threads">thread</a></summary>
		public int read_max_id;
	}
	/// <summary>A peer was blocked		<para>See <a href="https://corefork.telegram.org/constructor/updatePeerBlocked"/></para></summary>
	[TLDef(0x246A4B22)]
	public class UpdatePeerBlocked : Update
	{
		/// <summary>The blocked peer</summary>
		public Peer peer_id;
		/// <summary>Whether the peer was blocked or unblocked</summary>
		public bool blocked;
	}
	/// <summary>A user is typing in a <a href="https://corefork.telegram.org/api/channel">supergroup, channel</a> or <a href="https://corefork.telegram.org/api/threads">message thread</a>		<para>See <a href="https://corefork.telegram.org/constructor/updateChannelUserTyping"/></para></summary>
	[TLDef(0x8C88C923)]
	public class UpdateChannelUserTyping : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Channel ID</summary>
		public long channel_id;
		/// <summary><a href="https://corefork.telegram.org/api/threads">Thread ID</a></summary>
		[IfFlag(0)] public int top_msg_id;
		/// <summary>The peer that is typing</summary>
		public Peer from_id;
		/// <summary>Whether the user is typing, sending a media or doing something else</summary>
		public SendMessageAction action;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="top_msg_id"/> has a value</summary>
			has_top_msg_id = 0x1,
		}
	}
	/// <summary>Some messages were pinned in a chat		<para>See <a href="https://corefork.telegram.org/constructor/updatePinnedMessages"/></para></summary>
	[TLDef(0xED85EAB5)]
	public class UpdatePinnedMessages : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Peer</summary>
		public Peer peer;
		/// <summary>Message IDs</summary>
		public int[] messages;
		/// <summary><a href="https://corefork.telegram.org/api/updates">Event count after generation</a></summary>
		public int pts;
		/// <summary><a href="https://corefork.telegram.org/api/updates">Number of events that were generated</a></summary>
		public int pts_count;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the messages were pinned or unpinned</summary>
			pinned = 0x1,
		}
	}
	/// <summary>Messages were pinned/unpinned in a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>		<para>See <a href="https://corefork.telegram.org/constructor/updatePinnedChannelMessages"/></para></summary>
	[TLDef(0x5BB98608)]
	public class UpdatePinnedChannelMessages : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Channel ID</summary>
		public long channel_id;
		/// <summary>Messages</summary>
		public int[] messages;
		/// <summary><a href="https://corefork.telegram.org/api/updates">Event count after generation</a></summary>
		public int pts;
		/// <summary><a href="https://corefork.telegram.org/api/updates">Number of events that were generated</a></summary>
		public int pts_count;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the messages were pinned or unpinned</summary>
			pinned = 0x1,
		}
	}
	/// <summary>A new chat is available		<para>See <a href="https://corefork.telegram.org/constructor/updateChat"/></para></summary>
	[TLDef(0xF89A6A4E)]
	public class UpdateChat : Update
	{
		/// <summary>Chat ID</summary>
		public long chat_id;
	}
	/// <summary>The participant list of a certain group call has changed		<para>See <a href="https://corefork.telegram.org/constructor/updateGroupCallParticipants"/></para></summary>
	[TLDef(0xF2EBDB4E)]
	public class UpdateGroupCallParticipants : Update
	{
		/// <summary>Group call</summary>
		public InputGroupCall call;
		/// <summary>New participant list</summary>
		public GroupCallParticipant[] participants;
		/// <summary>Version</summary>
		public int version;
	}
	/// <summary>A new groupcall was started		<para>See <a href="https://corefork.telegram.org/constructor/updateGroupCall"/></para></summary>
	[TLDef(0x14B24500)]
	public class UpdateGroupCall : Update
	{
		/// <summary>The <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> where this group call or livestream takes place</summary>
		public long chat_id;
		/// <summary>Info about the group call or livestream</summary>
		public GroupCallBase call;
	}
	/// <summary>The Time-To-Live for messages sent by the current user in a specific chat has changed		<para>See <a href="https://corefork.telegram.org/constructor/updatePeerHistoryTTL"/></para></summary>
	[TLDef(0xBB9BB9A5)]
	public class UpdatePeerHistoryTTL : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The chat</summary>
		public Peer peer;
		/// <summary>The new Time-To-Live</summary>
		[IfFlag(0)] public int ttl_period;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="ttl_period"/> has a value</summary>
			has_ttl_period = 0x1,
		}
	}
	/// <summary>A user has joined or left a specific chat		<para>See <a href="https://corefork.telegram.org/constructor/updateChatParticipant"/></para></summary>
	[TLDef(0xD087663A)]
	public class UpdateChatParticipant : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary><a href="https://corefork.telegram.org/api/channel">Chat</a> ID</summary>
		public long chat_id;
		/// <summary>When did this event occur</summary>
		public DateTime date;
		/// <summary>User that triggered the change (inviter, admin that kicked the user, or the even the <strong>user_id</strong> itself)</summary>
		public long actor_id;
		/// <summary>User that was affected by the change</summary>
		public long user_id;
		/// <summary>Previous participant info (empty if this participant just joined)</summary>
		[IfFlag(0)] public ChatParticipantBase prev_participant;
		/// <summary>New participant info (empty if this participant just left)</summary>
		[IfFlag(1)] public ChatParticipantBase new_participant;
		/// <summary>The invite that was used to join the group</summary>
		[IfFlag(2)] public ExportedChatInvite invite;
		/// <summary>New <strong>qts</strong> value, see <a href="https://corefork.telegram.org/api/updates">updates »</a> for more info.</summary>
		public int qts;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="prev_participant"/> has a value</summary>
			has_prev_participant = 0x1,
			/// <summary>Field <see cref="new_participant"/> has a value</summary>
			has_new_participant = 0x2,
			/// <summary>Field <see cref="invite"/> has a value</summary>
			has_invite = 0x4,
		}
	}
	/// <summary>A participant has left, joined, was banned or admined in a <a href="https://corefork.telegram.org/api/channel">channel or supergroup</a>.		<para>See <a href="https://corefork.telegram.org/constructor/updateChannelParticipant"/></para></summary>
	[TLDef(0x985D3ABB)]
	public class UpdateChannelParticipant : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Channel ID</summary>
		public long channel_id;
		/// <summary>Date of the event</summary>
		public DateTime date;
		/// <summary>User that triggered the change (inviter, admin that kicked the user, or the even the <strong>user_id</strong> itself)</summary>
		public long actor_id;
		/// <summary>User that was affected by the change</summary>
		public long user_id;
		/// <summary>Previous participant status</summary>
		[IfFlag(0)] public ChannelParticipantBase prev_participant;
		/// <summary>New participant status</summary>
		[IfFlag(1)] public ChannelParticipantBase new_participant;
		/// <summary>Chat invite used to join the <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a></summary>
		[IfFlag(2)] public ExportedChatInvite invite;
		/// <summary>New <strong>qts</strong> value, see <a href="https://corefork.telegram.org/api/updates">updates »</a> for more info.</summary>
		public int qts;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="prev_participant"/> has a value</summary>
			has_prev_participant = 0x1,
			/// <summary>Field <see cref="new_participant"/> has a value</summary>
			has_new_participant = 0x2,
			/// <summary>Field <see cref="invite"/> has a value</summary>
			has_invite = 0x4,
		}
	}
	/// <summary>A bot was stopped or re-started.		<para>See <a href="https://corefork.telegram.org/constructor/updateBotStopped"/></para></summary>
	[TLDef(0xC4870A49)]
	public class UpdateBotStopped : Update
	{
		/// <summary>The bot ID</summary>
		public long user_id;
		/// <summary>When did this action occur</summary>
		public DateTime date;
		/// <summary>Whether the bot was stopped or started</summary>
		public bool stopped;
		/// <summary>New <strong>qts</strong> value, see <a href="https://corefork.telegram.org/api/updates">updates »</a> for more info.</summary>
		public int qts;
	}
	/// <summary>New WebRTC parameters		<para>See <a href="https://corefork.telegram.org/constructor/updateGroupCallConnection"/></para></summary>
	[TLDef(0x0B783982)]
	public class UpdateGroupCallConnection : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>WebRTC parameters</summary>
		public DataJSON params_;

		[Flags] public enum Flags : uint
		{
			/// <summary>Are these parameters related to the screen capture session currently in progress?</summary>
			presentation = 0x1,
		}
	}
	/// <summary>The <a href="https://corefork.telegram.org/bots/api#june-25-2021">command set</a> of a certain bot in a certain chat has changed.		<para>See <a href="https://corefork.telegram.org/constructor/updateBotCommands"/></para></summary>
	[TLDef(0x4D712F2E)]
	public class UpdateBotCommands : Update
	{
		/// <summary>The affected chat</summary>
		public Peer peer;
		/// <summary>ID of the bot that changed its command set</summary>
		public long bot_id;
		/// <summary>New bot commands</summary>
		public BotCommand[] commands;
	}
	/// <summary>Someone has requested to join a chat or channel		<para>See <a href="https://corefork.telegram.org/constructor/updatePendingJoinRequests"/></para></summary>
	[TLDef(0x7063C3DB)]
	public class UpdatePendingJoinRequests : Update
	{
		/// <summary>Chat or channel</summary>
		public Peer peer;
		/// <summary>Number of pending <a href="https://corefork.telegram.org/api/invites#join-requests">join requests »</a> for the chat or channel</summary>
		public int requests_pending;
		/// <summary>IDs of users that have recently requested to join</summary>
		public long[] recent_requesters;
	}
	/// <summary>Someone has requested to join a chat or channel (bots only, users will receive an <see cref="UpdatePendingJoinRequests"/>, instead)		<para>See <a href="https://corefork.telegram.org/constructor/updateBotChatInviteRequester"/></para></summary>
	[TLDef(0x11DFA986)]
	public class UpdateBotChatInviteRequester : Update
	{
		/// <summary>The chat or channel in question</summary>
		public Peer peer;
		/// <summary>When was the <a href="https://corefork.telegram.org/api/invites#join-requests">join request »</a> made</summary>
		public DateTime date;
		/// <summary>The user ID that is asking to join the chat or channel</summary>
		public long user_id;
		/// <summary>Bio of the user</summary>
		public string about;
		/// <summary>Chat invite link that was used by the user to send the <a href="https://corefork.telegram.org/api/invites#join-requests">join request »</a></summary>
		public ExportedChatInvite invite;
		/// <summary><a href="https://corefork.telegram.org/api/updates">QTS</a> event sequence identifier</summary>
		public int qts;
	}
	/// <summary>New <a href="https://corefork.telegram.org/api/reactions">message reactions »</a> are available		<para>See <a href="https://corefork.telegram.org/constructor/updateMessageReactions"/></para></summary>
	[TLDef(0x154798C3)]
	public class UpdateMessageReactions : Update
	{
		/// <summary>Peer</summary>
		public Peer peer;
		/// <summary>Message ID</summary>
		public int msg_id;
		/// <summary>Reactions</summary>
		public MessageReactions reactions;
	}
	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/updateAttachMenuBots"/></para></summary>
	[TLDef(0x17B7A20B)]
	public class UpdateAttachMenuBots : Update { }
	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/updateWebViewResultSent"/></para></summary>
	[TLDef(0x1592B79D)]
	public class UpdateWebViewResultSent : Update
	{
		public long query_id;
	}
	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/updateBotMenuButton"/></para></summary>
	[TLDef(0x14B85813)]
	public class UpdateBotMenuButton : Update
	{
		public long bot_id;
		public BotMenuButtonBase button;
	}
	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/updateSavedRingtones"/></para></summary>
	[TLDef(0x74D8BE99)]
	public class UpdateSavedRingtones : Update { }

	/// <summary>Updates state.		<para>See <a href="https://corefork.telegram.org/constructor/updates.state"/></para></summary>
	[TLDef(0xA56C2A3E)]
	public class Updates_State : IObject
	{
		/// <summary>Number of events occurred in a text box</summary>
		public int pts;
		/// <summary>Position in a sequence of updates in secret chats. For further details refer to article <a href="https://corefork.telegram.org/api/end-to-end">secret chats</a></summary>
		public int qts;
		/// <summary>Date of condition</summary>
		public DateTime date;
		/// <summary>Number of sent updates</summary>
		public int seq;
		/// <summary>Number of unread messages</summary>
		public int unread_count;
	}

	/// <summary>Occurred changes.		<para>Derived classes: <see cref="Updates_DifferenceEmpty"/>, <see cref="Updates_Difference"/>, <see cref="Updates_DifferenceSlice"/>, <see cref="Updates_DifferenceTooLong"/></para>		<para>See <a href="https://corefork.telegram.org/type/updates.Difference"/></para></summary>
	public abstract partial class Updates_DifferenceBase : IObject, IPeerResolver
	{
		/// <summary>List of new messages</summary>
		public abstract MessageBase[] NewMessages { get; }
		/// <summary>List of new encrypted secret chat messages</summary>
		public abstract EncryptedMessageBase[] NewEncryptedMessages { get; }
		/// <summary>List of updates</summary>
		public abstract Update[] OtherUpdates { get; }
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public abstract IPeerInfo UserOrChat(Peer peer);
	}
	/// <summary>No events.		<para>See <a href="https://corefork.telegram.org/constructor/updates.differenceEmpty"/></para></summary>
	[TLDef(0x5D75A138)]
	public partial class Updates_DifferenceEmpty : Updates_DifferenceBase, IPeerResolver
	{
		/// <summary>Current date</summary>
		public DateTime date;
		/// <summary>Number of sent updates</summary>
		public int seq;

		public override MessageBase[] NewMessages => Array.Empty<MessageBase>();
		public override EncryptedMessageBase[] NewEncryptedMessages => Array.Empty<EncryptedMessageBase>();
		public override Update[] OtherUpdates => Array.Empty<Update>();
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => null;
	}
	/// <summary>Full list of occurred events.		<para>See <a href="https://corefork.telegram.org/constructor/updates.difference"/></para></summary>
	[TLDef(0x00F49CA0)]
	public partial class Updates_Difference : Updates_DifferenceBase, IPeerResolver
	{
		/// <summary>List of new messages</summary>
		public MessageBase[] new_messages;
		/// <summary>List of new encrypted secret chat messages</summary>
		public EncryptedMessageBase[] new_encrypted_messages;
		/// <summary>List of updates</summary>
		public Update[] other_updates;
		/// <summary>List of chats mentioned in events</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>List of users mentioned in events</summary>
		public Dictionary<long, User> users;
		/// <summary>Current state</summary>
		public Updates_State state;

		/// <summary>List of new messages</summary>
		public override MessageBase[] NewMessages => new_messages;
		/// <summary>List of new encrypted secret chat messages</summary>
		public override EncryptedMessageBase[] NewEncryptedMessages => new_encrypted_messages;
		/// <summary>List of updates</summary>
		public override Update[] OtherUpdates => other_updates;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}
	/// <summary>Incomplete list of occurred events.		<para>See <a href="https://corefork.telegram.org/constructor/updates.differenceSlice"/></para></summary>
	[TLDef(0xA8FB1981)]
	public partial class Updates_DifferenceSlice : Updates_DifferenceBase, IPeerResolver
	{
		/// <summary>List of new messages</summary>
		public MessageBase[] new_messages;
		/// <summary>New messages from the <a href="https://corefork.telegram.org/api/updates">encrypted event sequence</a></summary>
		public EncryptedMessageBase[] new_encrypted_messages;
		/// <summary>List of updates</summary>
		public Update[] other_updates;
		/// <summary>List of chats mentioned in events</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>List of users mentioned in events</summary>
		public Dictionary<long, User> users;
		/// <summary>Intermediary state</summary>
		public Updates_State intermediate_state;

		/// <summary>List of new messages</summary>
		public override MessageBase[] NewMessages => new_messages;
		/// <summary>New messages from the <a href="https://corefork.telegram.org/api/updates">encrypted event sequence</a></summary>
		public override EncryptedMessageBase[] NewEncryptedMessages => new_encrypted_messages;
		/// <summary>List of updates</summary>
		public override Update[] OtherUpdates => other_updates;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}
	/// <summary>The difference is <a href="https://corefork.telegram.org/api/updates#recovering-gaps">too long</a>, and the specified state must be used to refetch updates.		<para>See <a href="https://corefork.telegram.org/constructor/updates.differenceTooLong"/></para></summary>
	[TLDef(0x4AFE8F6D)]
	public partial class Updates_DifferenceTooLong : Updates_DifferenceBase, IPeerResolver
	{
		/// <summary>The new state to use.</summary>
		public int pts;

		public override MessageBase[] NewMessages => default;
		public override EncryptedMessageBase[] NewEncryptedMessages => default;
		public override Update[] OtherUpdates => default;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => null;
	}

	/// <summary>Object which is perceived by the client without a call on its part when an event occurs.		<para>Derived classes: <see cref="UpdatesTooLong"/>, <see cref="UpdateShortMessage"/>, <see cref="UpdateShortChatMessage"/>, <see cref="UpdateShort"/>, <see cref="UpdatesCombined"/>, <see cref="Updates"/>, <see cref="UpdateShortSentMessage"/></para>		<para>See <a href="https://corefork.telegram.org/type/Updates"/></para></summary>
	public abstract partial class UpdatesBase : IObject, IPeerResolver
	{
		/// <summary><a href="https://corefork.telegram.org/api/updates">date</a></summary>
		public abstract DateTime Date { get; }
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public abstract IPeerInfo UserOrChat(Peer peer);
	}
	/// <summary>Too many updates, it is necessary to execute <a href="https://corefork.telegram.org/method/updates.getDifference">updates.getDifference</a>.		<para>See <a href="https://corefork.telegram.org/constructor/updatesTooLong"/></para></summary>
	[TLDef(0xE317AF7E)]
	public partial class UpdatesTooLong : UpdatesBase, IPeerResolver
	{
		public override DateTime Date => default;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => null;
	}
	/// <summary>Info about a message sent to (received from) another user		<para>See <a href="https://corefork.telegram.org/constructor/updateShortMessage"/></para></summary>
	[TLDef(0x313BC7F8)]
	public partial class UpdateShortMessage : UpdatesBase, IPeerResolver
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The message ID</summary>
		public int id;
		/// <summary>The ID of the sender (if <c>outgoing</c> will be the ID of the destination) of the message</summary>
		public long user_id;
		/// <summary>The message</summary>
		public string message;
		/// <summary><a href="https://corefork.telegram.org/api/updates">PTS</a></summary>
		public int pts;
		/// <summary><a href="https://corefork.telegram.org/api/updates">PTS count</a></summary>
		public int pts_count;
		/// <summary><a href="https://corefork.telegram.org/api/updates">date</a></summary>
		public DateTime date;
		/// <summary>Info about a forwarded message</summary>
		[IfFlag(2)] public MessageFwdHeader fwd_from;
		/// <summary>Info about the inline bot used to generate this message</summary>
		[IfFlag(11)] public long via_bot_id;
		/// <summary>Reply and <a href="https://corefork.telegram.org/api/threads">thread</a> information</summary>
		[IfFlag(3)] public MessageReplyHeader reply_to;
		/// <summary><a href="https://corefork.telegram.org/api/entities">Entities</a> for styled text</summary>
		[IfFlag(7)] public MessageEntity[] entities;
		/// <summary>Time To Live of the message, once message.date+message.ttl_period === time(), the message will be deleted on the server, and must be deleted locally as well.</summary>
		[IfFlag(25)] public int ttl_period;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the message is outgoing</summary>
			out_ = 0x2,
			/// <summary>Field <see cref="fwd_from"/> has a value</summary>
			has_fwd_from = 0x4,
			/// <summary>Field <see cref="reply_to"/> has a value</summary>
			has_reply_to = 0x8,
			/// <summary>Whether we were mentioned in the message</summary>
			mentioned = 0x10,
			/// <summary>Whether there are some <strong>unread</strong> mentions in this message</summary>
			media_unread = 0x20,
			/// <summary>Field <see cref="entities"/> has a value</summary>
			has_entities = 0x80,
			/// <summary>Field <see cref="via_bot_id"/> has a value</summary>
			has_via_bot_id = 0x800,
			/// <summary>If true, the message is a silent message, no notifications should be triggered</summary>
			silent = 0x2000,
			/// <summary>Field <see cref="ttl_period"/> has a value</summary>
			has_ttl_period = 0x2000000,
		}

		/// <summary><a href="https://corefork.telegram.org/api/updates">date</a></summary>
		public override DateTime Date => date;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => null;
	}
	/// <summary>Shortened constructor containing info on one new incoming text message from a chat		<para>See <a href="https://corefork.telegram.org/constructor/updateShortChatMessage"/></para></summary>
	[TLDef(0x4D6DEEA5)]
	public partial class UpdateShortChatMessage : UpdatesBase, IPeerResolver
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>ID of the message</summary>
		public int id;
		/// <summary>ID of the sender of the message</summary>
		public long from_id;
		/// <summary>ID of the chat where the message was sent</summary>
		public long chat_id;
		/// <summary>Message</summary>
		public string message;
		/// <summary><a href="https://corefork.telegram.org/api/updates">PTS</a></summary>
		public int pts;
		/// <summary><a href="https://corefork.telegram.org/api/updates">PTS count</a></summary>
		public int pts_count;
		/// <summary><a href="https://corefork.telegram.org/api/updates">date</a></summary>
		public DateTime date;
		/// <summary>Info about a forwarded message</summary>
		[IfFlag(2)] public MessageFwdHeader fwd_from;
		/// <summary>Info about the inline bot used to generate this message</summary>
		[IfFlag(11)] public long via_bot_id;
		/// <summary>Reply (thread) information</summary>
		[IfFlag(3)] public MessageReplyHeader reply_to;
		/// <summary><a href="https://corefork.telegram.org/api/entities">Entities</a> for styled text</summary>
		[IfFlag(7)] public MessageEntity[] entities;
		/// <summary>Time To Live of the message, once updateShortChatMessage.date+updateShortChatMessage.ttl_period === time(), the message will be deleted on the server, and must be deleted locally as well.</summary>
		[IfFlag(25)] public int ttl_period;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the message is outgoing</summary>
			out_ = 0x2,
			/// <summary>Field <see cref="fwd_from"/> has a value</summary>
			has_fwd_from = 0x4,
			/// <summary>Field <see cref="reply_to"/> has a value</summary>
			has_reply_to = 0x8,
			/// <summary>Whether we were mentioned in this message</summary>
			mentioned = 0x10,
			/// <summary>Whether the message contains some <strong>unread</strong> mentions</summary>
			media_unread = 0x20,
			/// <summary>Field <see cref="entities"/> has a value</summary>
			has_entities = 0x80,
			/// <summary>Field <see cref="via_bot_id"/> has a value</summary>
			has_via_bot_id = 0x800,
			/// <summary>If true, the message is a silent message, no notifications should be triggered</summary>
			silent = 0x2000,
			/// <summary>Field <see cref="ttl_period"/> has a value</summary>
			has_ttl_period = 0x2000000,
		}

		/// <summary><a href="https://corefork.telegram.org/api/updates">date</a></summary>
		public override DateTime Date => date;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => null;
	}
	/// <summary>Shortened constructor containing info on one update not requiring auxiliary data		<para>See <a href="https://corefork.telegram.org/constructor/updateShort"/></para></summary>
	[TLDef(0x78D4DEC1)]
	public partial class UpdateShort : UpdatesBase, IPeerResolver
	{
		/// <summary>Update</summary>
		public Update update;
		/// <summary>Date of event</summary>
		public DateTime date;

		/// <summary>Date of event</summary>
		public override DateTime Date => date;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => null;
	}
	/// <summary>Constructor for a group of updates.		<para>See <a href="https://corefork.telegram.org/constructor/updatesCombined"/></para></summary>
	[TLDef(0x725B04C3)]
	public partial class UpdatesCombined : UpdatesBase, IPeerResolver
	{
		/// <summary>List of updates</summary>
		public Update[] updates;
		/// <summary>List of users mentioned in updates</summary>
		public Dictionary<long, User> users;
		/// <summary>List of chats mentioned in updates</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Current date</summary>
		public DateTime date;
		/// <summary>Value <strong>seq</strong> for the earliest update in a group</summary>
		public int seq_start;
		/// <summary>Value <strong>seq</strong> for the latest update in a group</summary>
		public int seq;

		/// <summary>Current date</summary>
		public override DateTime Date => date;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}
	/// <summary>Full constructor of updates		<para>See <a href="https://corefork.telegram.org/constructor/updates"/></para></summary>
	[TLDef(0x74AE4240)]
	public partial class Updates : UpdatesBase, IPeerResolver
	{
		/// <summary>List of updates</summary>
		public Update[] updates;
		/// <summary>List of users mentioned in updates</summary>
		public Dictionary<long, User> users;
		/// <summary>List of chats mentioned in updates</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Current date</summary>
		public DateTime date;
		/// <summary>Total number of sent updates</summary>
		public int seq;

		/// <summary>Current date</summary>
		public override DateTime Date => date;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}
	/// <summary>Shortened constructor containing info on one outgoing message to a contact (the destination chat has to be extracted from the method call that returned this object).		<para>See <a href="https://corefork.telegram.org/constructor/updateShortSentMessage"/></para></summary>
	[TLDef(0x9015E101)]
	public partial class UpdateShortSentMessage : UpdatesBase, IPeerResolver
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>ID of the sent message</summary>
		public int id;
		/// <summary><a href="https://corefork.telegram.org/api/updates">PTS</a></summary>
		public int pts;
		/// <summary><a href="https://corefork.telegram.org/api/updates">PTS count</a></summary>
		public int pts_count;
		/// <summary><a href="https://corefork.telegram.org/api/updates">date</a></summary>
		public DateTime date;
		/// <summary>Attached media</summary>
		[IfFlag(9)] public MessageMedia media;
		/// <summary><a href="https://corefork.telegram.org/api/entities">Entities</a> for styled text</summary>
		[IfFlag(7)] public MessageEntity[] entities;
		/// <summary>Time To Live of the message, once message.date+message.ttl_period === time(), the message will be deleted on the server, and must be deleted locally as well.</summary>
		[IfFlag(25)] public int ttl_period;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the message is outgoing</summary>
			out_ = 0x2,
			/// <summary>Field <see cref="entities"/> has a value</summary>
			has_entities = 0x80,
			/// <summary>Field <see cref="media"/> has a value</summary>
			has_media = 0x200,
			/// <summary>Field <see cref="ttl_period"/> has a value</summary>
			has_ttl_period = 0x2000000,
		}

		/// <summary><a href="https://corefork.telegram.org/api/updates">date</a></summary>
		public override DateTime Date => date;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => null;
	}

	/// <summary>Full list of photos with auxiliary data.		<para>See <a href="https://corefork.telegram.org/constructor/photos.photos"/></para></summary>
	[TLDef(0x8DCA6AA5)]
	public class Photos_Photos : IObject
	{
		/// <summary>List of photos</summary>
		public PhotoBase[] photos;
		/// <summary>List of mentioned users</summary>
		public Dictionary<long, User> users;
	}
	/// <summary>Incomplete list of photos with auxiliary data.		<para>See <a href="https://corefork.telegram.org/constructor/photos.photosSlice"/></para></summary>
	[TLDef(0x15051F54)]
	public class Photos_PhotosSlice : Photos_Photos
	{
		/// <summary>Total number of photos</summary>
		public int count;
	}

	/// <summary>Photo with auxiliary data.		<para>See <a href="https://corefork.telegram.org/constructor/photos.photo"/></para></summary>
	[TLDef(0x20212CA8)]
	public class Photos_Photo : IObject
	{
		/// <summary>Photo</summary>
		public PhotoBase photo;
		/// <summary>Users</summary>
		public Dictionary<long, User> users;
	}

	/// <summary>Contains info on file.		<para>Derived classes: <see cref="Upload_File"/>, <see cref="Upload_FileCdnRedirect"/></para>		<para>See <a href="https://corefork.telegram.org/type/upload.File"/></para></summary>
	public abstract class Upload_FileBase : IObject { }
	/// <summary>File content.		<para>See <a href="https://corefork.telegram.org/constructor/upload.file"/></para></summary>
	[TLDef(0x096A18D5)]
	public class Upload_File : Upload_FileBase
	{
		/// <summary>File type</summary>
		public Storage_FileType type;
		/// <summary>Modification type</summary>
		public int mtime;
		/// <summary>Binary data, file content</summary>
		public byte[] bytes;
	}
	/// <summary>The file must be downloaded from a <a href="https://corefork.telegram.org/cdn">CDN DC</a>.		<para>See <a href="https://corefork.telegram.org/constructor/upload.fileCdnRedirect"/></para></summary>
	[TLDef(0xF18CDA44)]
	public class Upload_FileCdnRedirect : Upload_FileBase
	{
		/// <summary><a href="https://corefork.telegram.org/cdn">CDN DC</a> ID</summary>
		public int dc_id;
		/// <summary>File token (see <a href="https://corefork.telegram.org/cdn">CDN files</a>)</summary>
		public byte[] file_token;
		/// <summary>Encryption key (see <a href="https://corefork.telegram.org/cdn">CDN files</a>)</summary>
		public byte[] encryption_key;
		/// <summary>Encryption IV (see <a href="https://corefork.telegram.org/cdn">CDN files</a>)</summary>
		public byte[] encryption_iv;
		/// <summary>File hashes (see <a href="https://corefork.telegram.org/cdn">CDN files</a>)</summary>
		public FileHash[] file_hashes;
	}

	/// <summary>Data center		<para>See <a href="https://corefork.telegram.org/constructor/dcOption"/></para></summary>
	[TLDef(0x18B7A10D)]
	public class DcOption : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>DC ID</summary>
		public int id;
		/// <summary>IP address of DC</summary>
		public string ip_address;
		/// <summary>Port</summary>
		public int port;
		/// <summary>If the <c>tcpo_only</c> flag is set, specifies the secret to use when connecting using <a href="https://corefork.telegram.org/mtproto/mtproto-transports#transport-obfuscation">transport obfuscation</a></summary>
		[IfFlag(10)] public byte[] secret;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the specified IP is an IPv6 address</summary>
			ipv6 = 0x1,
			/// <summary>Whether this DC should only be used to <a href="https://corefork.telegram.org/api/files">download or upload files</a></summary>
			media_only = 0x2,
			/// <summary>Whether this DC only supports connection with <a href="https://corefork.telegram.org/mtproto/mtproto-transports#transport-obfuscation">transport obfuscation</a></summary>
			tcpo_only = 0x4,
			/// <summary>Whether this is a <a href="https://corefork.telegram.org/cdn">CDN DC</a>.</summary>
			cdn = 0x8,
			/// <summary>If set, this IP should be used when connecting through a proxy</summary>
			static_ = 0x10,
			this_port_only = 0x20,
			/// <summary>Field <see cref="secret"/> has a value</summary>
			has_secret = 0x400,
		}
	}

	/// <summary>Current configuration		<para>See <a href="https://corefork.telegram.org/constructor/config"/></para></summary>
	[TLDef(0x330B4067)]
	public class Config : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Current date at the server</summary>
		public DateTime date;
		/// <summary>Expiration date of this config: when it expires it'll have to be refetched using <a href="https://corefork.telegram.org/method/help.getConfig">help.getConfig</a></summary>
		public DateTime expires;
		/// <summary>Whether we're connected to the test DCs</summary>
		public bool test_mode;
		/// <summary>ID of the DC that returned the reply</summary>
		public int this_dc;
		/// <summary>DC IP list</summary>
		public DcOption[] dc_options;
		/// <summary>Domain name for fetching encrypted DC list from DNS TXT record</summary>
		public string dc_txt_domain_name;
		/// <summary>Maximum member count for normal <a href="https://corefork.telegram.org/api/channel">groups</a></summary>
		public int chat_size_max;
		/// <summary>Maximum member count for <a href="https://corefork.telegram.org/api/channel">supergroups</a></summary>
		public int megagroup_size_max;
		/// <summary>Maximum number of messages that can be forwarded at once using <a href="https://corefork.telegram.org/method/messages.forwardMessages">messages.forwardMessages</a>.</summary>
		public int forwarded_count_max;
		/// <summary>The client should <a href="https://corefork.telegram.org/method/account.updateStatus">update its online status</a> every N milliseconds</summary>
		public int online_update_period_ms;
		/// <summary>Delay before offline status needs to be sent to the server</summary>
		public int offline_blur_timeout_ms;
		/// <summary>Time without any user activity after which it should be treated offline</summary>
		public int offline_idle_timeout_ms;
		/// <summary>If we are offline, but were online from some other client in last <c>online_cloud_timeout_ms</c> milliseconds after we had gone offline, then delay offline notification for <c>notify_cloud_delay_ms</c> milliseconds.</summary>
		public int online_cloud_timeout_ms;
		/// <summary>If we are offline, but online from some other client then delay sending the offline notification for <c>notify_cloud_delay_ms</c> milliseconds.</summary>
		public int notify_cloud_delay_ms;
		/// <summary>If some other client is online, then delay notification for <c>notification_default_delay_ms</c> milliseconds</summary>
		public int notify_default_delay_ms;
		/// <summary>Not for client use</summary>
		public int push_chat_period_ms;
		/// <summary>Not for client use</summary>
		public int push_chat_limit;
		/// <summary>Maximum count of saved gifs</summary>
		public int saved_gifs_limit;
		/// <summary>Only messages with age smaller than the one specified can be edited</summary>
		public int edit_time_limit;
		/// <summary>Only channel/supergroup messages with age smaller than the specified can be deleted</summary>
		public int revoke_time_limit;
		/// <summary>Only private messages with age smaller than the specified can be deleted</summary>
		public int revoke_pm_time_limit;
		/// <summary>Exponential decay rate for computing <a href="https://corefork.telegram.org/api/top-rating">top peer rating</a></summary>
		public int rating_e_decay;
		/// <summary>Maximum number of recent stickers</summary>
		public int stickers_recent_limit;
		/// <summary>Maximum number of faved stickers</summary>
		public int stickers_faved_limit;
		/// <summary>Indicates that round videos (video notes) and voice messages sent in channels and older than the specified period must be marked as read</summary>
		public int channels_read_media_period;
		/// <summary>Temporary <a href="https://corefork.telegram.org/passport">passport</a> sessions</summary>
		[IfFlag(0)] public int tmp_sessions;
		/// <summary>Maximum count of pinned dialogs</summary>
		public int pinned_dialogs_count_max;
		/// <summary>Maximum count of dialogs per folder</summary>
		public int pinned_infolder_count_max;
		/// <summary>Maximum allowed outgoing ring time in VoIP calls: if the user we're calling doesn't reply within the specified time (in milliseconds), we should hang up the call</summary>
		public int call_receive_timeout_ms;
		/// <summary>Maximum allowed incoming ring time in VoIP calls: if the current user doesn't reply within the specified time (in milliseconds), the call will be automatically refused</summary>
		public int call_ring_timeout_ms;
		/// <summary>VoIP connection timeout: if the instance of libtgvoip on the other side of the call doesn't connect to our instance of libtgvoip within the specified time (in milliseconds), the call must be aborted</summary>
		public int call_connect_timeout_ms;
		/// <summary>If during a VoIP call a packet isn't received for the specified period of time, the call must be aborted</summary>
		public int call_packet_timeout_ms;
		/// <summary>The domain to use to parse in-app links.<br/>For example t.me indicates that t.me/username links should parsed to @username, t.me/addsticker/name should be parsed to the appropriate stickerset and so on...</summary>
		public string me_url_prefix;
		/// <summary>URL to use to auto-update the current app</summary>
		[IfFlag(7)] public string autoupdate_url_prefix;
		/// <summary>Username of the bot to use to search for GIFs</summary>
		[IfFlag(9)] public string gif_search_username;
		/// <summary>Username of the bot to use to search for venues</summary>
		[IfFlag(10)] public string venue_search_username;
		/// <summary>Username of the bot to use for image search</summary>
		[IfFlag(11)] public string img_search_username;
		/// <summary>ID of the map provider to use for venues</summary>
		[IfFlag(12)] public string static_maps_provider;
		/// <summary>Maximum length of caption (length in utf8 codepoints)</summary>
		public int caption_length_max;
		/// <summary>Maximum length of messages (length in utf8 codepoints)</summary>
		public int message_length_max;
		/// <summary>DC ID to use to download <a href="https://corefork.telegram.org/api/files">webfiles</a></summary>
		public int webfile_dc_id;
		/// <summary>Suggested language code</summary>
		[IfFlag(2)] public string suggested_lang_code;
		/// <summary>Language pack version</summary>
		[IfFlag(2)] public int lang_pack_version;
		/// <summary>Basic language pack version</summary>
		[IfFlag(2)] public int base_lang_pack_version;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="tmp_sessions"/> has a value</summary>
			has_tmp_sessions = 0x1,
			/// <summary>Whether phone calls can be used</summary>
			phonecalls_enabled = 0x2,
			/// <summary>Field <see cref="suggested_lang_code"/> has a value</summary>
			has_suggested_lang_code = 0x4,
			/// <summary>Whether the client should use P2P by default for phone calls with contacts</summary>
			default_p2p_contacts = 0x8,
			/// <summary>Whether the client should preload featured stickers</summary>
			preload_featured_stickers = 0x10,
			/// <summary>Whether the client should ignore phone <a href="https://corefork.telegram.org/api/entities">entities</a></summary>
			ignore_phone_entities = 0x20,
			/// <summary>Whether incoming private messages can be deleted for both participants</summary>
			revoke_pm_inbox = 0x40,
			/// <summary>Field <see cref="autoupdate_url_prefix"/> has a value</summary>
			has_autoupdate_url_prefix = 0x80,
			/// <summary>Indicates that telegram is <em>probably</em> censored by governments/ISPs in the current region</summary>
			blocked_mode = 0x100,
			/// <summary>Field <see cref="gif_search_username"/> has a value</summary>
			has_gif_search_username = 0x200,
			/// <summary>Field <see cref="venue_search_username"/> has a value</summary>
			has_venue_search_username = 0x400,
			/// <summary>Field <see cref="img_search_username"/> has a value</summary>
			has_img_search_username = 0x800,
			/// <summary>Field <see cref="static_maps_provider"/> has a value</summary>
			has_static_maps_provider = 0x1000,
			/// <summary>Whether <a href="https://corefork.telegram.org/api/pfs">pfs</a> was used</summary>
			pfs_enabled = 0x2000,
			force_try_ipv6 = 0x4000,
		}
	}

	/// <summary>Nearest data center, according to geo-ip.		<para>See <a href="https://corefork.telegram.org/constructor/nearestDc"/></para></summary>
	[TLDef(0x8E1A1775)]
	public class NearestDc : IObject
	{
		/// <summary>Country code determined by geo-ip</summary>
		public string country;
		/// <summary>Number of current data center</summary>
		public int this_dc;
		/// <summary>Number of nearest data center</summary>
		public int nearest_dc;
	}

	/// <summary>An update is available for the application.		<para>See <a href="https://corefork.telegram.org/constructor/help.appUpdate"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.noAppUpdate">help.noAppUpdate</a></remarks>
	[TLDef(0xCCBBCE30)]
	public class Help_AppUpdate : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Update ID</summary>
		public int id;
		/// <summary>New version name</summary>
		public string version;
		/// <summary>Text description of the update</summary>
		public string text;
		/// <summary><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></summary>
		public MessageEntity[] entities;
		/// <summary>Application binary</summary>
		[IfFlag(1)] public DocumentBase document;
		/// <summary>Application download URL</summary>
		[IfFlag(2)] public string url;
		/// <summary>Associated sticker</summary>
		[IfFlag(3)] public DocumentBase sticker;

		[Flags] public enum Flags : uint
		{
			/// <summary>Unskippable, the new info must be shown to the user (with a popup or something else)</summary>
			can_not_skip = 0x1,
			/// <summary>Field <see cref="document"/> has a value</summary>
			has_document = 0x2,
			/// <summary>Field <see cref="url"/> has a value</summary>
			has_url = 0x4,
			/// <summary>Field <see cref="sticker"/> has a value</summary>
			has_sticker = 0x8,
		}
	}

	/// <summary>Text of a text message with an invitation to install Telegram.		<para>See <a href="https://corefork.telegram.org/constructor/help.inviteText"/></para></summary>
	[TLDef(0x18CB9F78)]
	public class Help_InviteText : IObject
	{
		/// <summary>Text of the message</summary>
		public string message;
	}

	/// <summary>Object contains info on an encrypted chat.		<para>Derived classes: <see cref="EncryptedChatEmpty"/>, <see cref="EncryptedChatWaiting"/>, <see cref="EncryptedChatRequested"/>, <see cref="EncryptedChat"/>, <see cref="EncryptedChatDiscarded"/></para>		<para>See <a href="https://corefork.telegram.org/type/EncryptedChat"/></para></summary>
	public abstract class EncryptedChatBase : IObject
	{
		/// <summary>Chat ID</summary>
		public abstract int ID { get; }
	}
	/// <summary>Empty constructor.		<para>See <a href="https://corefork.telegram.org/constructor/encryptedChatEmpty"/></para></summary>
	[TLDef(0xAB7EC0A0)]
	public class EncryptedChatEmpty : EncryptedChatBase
	{
		/// <summary>Chat ID</summary>
		public int id;

		/// <summary>Chat ID</summary>
		public override int ID => id;
	}
	/// <summary>Chat waiting for approval of second participant.		<para>See <a href="https://corefork.telegram.org/constructor/encryptedChatWaiting"/></para></summary>
	[TLDef(0x66B25953)]
	public class EncryptedChatWaiting : EncryptedChatBase
	{
		/// <summary>Chat ID</summary>
		public int id;
		/// <summary>Checking sum depending on user ID</summary>
		public long access_hash;
		/// <summary>Date of chat creation</summary>
		public DateTime date;
		/// <summary>Chat creator ID</summary>
		public long admin_id;
		/// <summary>ID of second chat participant</summary>
		public long participant_id;

		/// <summary>Chat ID</summary>
		public override int ID => id;
	}
	/// <summary>Request to create an encrypted chat.		<para>See <a href="https://corefork.telegram.org/constructor/encryptedChatRequested"/></para></summary>
	[TLDef(0x48F1D94C)]
	public class EncryptedChatRequested : EncryptedChatBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		[IfFlag(0)] public int folder_id;
		/// <summary>Chat ID</summary>
		public int id;
		/// <summary>Check sum depending on user ID</summary>
		public long access_hash;
		/// <summary>Chat creation date</summary>
		public DateTime date;
		/// <summary>Chat creator ID</summary>
		public long admin_id;
		/// <summary>ID of second chat participant</summary>
		public long participant_id;
		/// <summary><c>A = g ^ a mod p</c>, see <a href="https://en.wikipedia.org/wiki/Diffie%E2%80%93Hellman_key_exchange">Wikipedia</a></summary>
		public byte[] g_a;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="folder_id"/> has a value</summary>
			has_folder_id = 0x1,
		}

		/// <summary>Chat ID</summary>
		public override int ID => id;
	}
	/// <summary>Encrypted chat		<para>See <a href="https://corefork.telegram.org/constructor/encryptedChat"/></para></summary>
	[TLDef(0x61F0D4C7)]
	public class EncryptedChat : EncryptedChatBase
	{
		/// <summary>Chat ID</summary>
		public int id;
		/// <summary>Check sum dependent on the user ID</summary>
		public long access_hash;
		/// <summary>Date chat was created</summary>
		public DateTime date;
		/// <summary>Chat creator ID</summary>
		public long admin_id;
		/// <summary>ID of the second chat participant</summary>
		public long participant_id;
		/// <summary><c>B = g ^ b mod p</c>, if the currently authorized user is the chat's creator,<br/>or <c>A = g ^ a mod p</c> otherwise<br/>See <a href="https://en.wikipedia.org/wiki/Diffie%E2%80%93Hellman_key_exchange">Wikipedia</a> for more info</summary>
		public byte[] g_a_or_b;
		/// <summary>64-bit fingerprint of received key</summary>
		public long key_fingerprint;

		/// <summary>Chat ID</summary>
		public override int ID => id;
	}
	/// <summary>Discarded or deleted chat.		<para>See <a href="https://corefork.telegram.org/constructor/encryptedChatDiscarded"/></para></summary>
	[TLDef(0x1E1C7C45)]
	public class EncryptedChatDiscarded : EncryptedChatBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Chat ID</summary>
		public int id;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether both users of this secret chat should also remove all of its messages</summary>
			history_deleted = 0x1,
		}

		/// <summary>Chat ID</summary>
		public override int ID => id;
	}

	/// <summary>Creates an encrypted chat.		<para>See <a href="https://corefork.telegram.org/constructor/inputEncryptedChat"/></para></summary>
	[TLDef(0xF141B5E1)]
	public class InputEncryptedChat : IObject
	{
		/// <summary>Chat ID</summary>
		public int chat_id;
		/// <summary>⚠ <b>REQUIRED FIELD</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash">how to obtain it</see><br/>Checking sum from constructor <see cref="EncryptedChat"/>, <see cref="EncryptedChatWaiting"/> or <see cref="EncryptedChatRequested"/></summary>
		public long access_hash;
	}

	/// <summary>Encrypted file.		<para>See <a href="https://corefork.telegram.org/constructor/encryptedFile"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/encryptedFileEmpty">encryptedFileEmpty</a></remarks>
	[TLDef(0x4A70994C)]
	public partial class EncryptedFile : IObject
	{
		/// <summary>File ID</summary>
		public long id;
		/// <summary>Checking sum depending on user ID</summary>
		public long access_hash;
		/// <summary>File size in bytes</summary>
		public int size;
		/// <summary>Number of data center</summary>
		public int dc_id;
		/// <summary>32-bit fingerprint of key used for file encryption</summary>
		public int key_fingerprint;
	}

	/// <summary>Object sets encrypted file for attachment		<para>Derived classes: <see cref="InputEncryptedFileUploaded"/>, <see cref="InputEncryptedFile"/>, <see cref="InputEncryptedFileBigUploaded"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputEncryptedFile"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputEncryptedFileEmpty">inputEncryptedFileEmpty</a></remarks>
	public abstract class InputEncryptedFileBase : IObject
	{
		/// <summary>Random file ID created by client</summary>
		public abstract long ID { get; }
	}
	/// <summary>Sets new encrypted file saved by parts using upload.saveFilePart method.		<para>See <a href="https://corefork.telegram.org/constructor/inputEncryptedFileUploaded"/></para></summary>
	[TLDef(0x64BD0306)]
	public class InputEncryptedFileUploaded : InputEncryptedFileBase
	{
		/// <summary>Random file ID created by client</summary>
		public long id;
		/// <summary>Number of saved parts</summary>
		public int parts;
		/// <summary>In case <a href="https://en.wikipedia.org/wiki/MD5">md5-HASH</a> of the (already encrypted) file was transmitted, file content will be checked prior to use</summary>
		public byte[] md5_checksum;
		/// <summary>32-bit fingerprint of the key used to encrypt a file</summary>
		public int key_fingerprint;

		/// <summary>Random file ID created by client</summary>
		public override long ID => id;
	}
	/// <summary>Sets forwarded encrypted file for attachment.		<para>See <a href="https://corefork.telegram.org/constructor/inputEncryptedFile"/></para></summary>
	[TLDef(0x5A17B5E5)]
	public class InputEncryptedFile : InputEncryptedFileBase
	{
		/// <summary>File ID, value of <strong>id</strong> parameter from <see cref="EncryptedFile"/></summary>
		public long id;
		/// <summary>⚠ <b>REQUIRED FIELD</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash">how to obtain it</see><br/>Checking sum, value of <strong>access_hash</strong> parameter from <see cref="EncryptedFile"/></summary>
		public long access_hash;

		/// <summary>File ID, value of <strong>id</strong> parameter from <see cref="EncryptedFile"/></summary>
		public override long ID => id;
	}
	/// <summary>Assigns a new big encrypted file (over 10 MB in size), saved in parts using the method <a href="https://corefork.telegram.org/method/upload.saveBigFilePart">upload.saveBigFilePart</a>.		<para>See <a href="https://corefork.telegram.org/constructor/inputEncryptedFileBigUploaded"/></para></summary>
	[TLDef(0x2DC173C8)]
	public class InputEncryptedFileBigUploaded : InputEncryptedFileBase
	{
		/// <summary>Random file id, created by the client</summary>
		public long id;
		/// <summary>Number of saved parts</summary>
		public int parts;
		/// <summary>32-bit imprint of the key used to encrypt the file</summary>
		public int key_fingerprint;

		/// <summary>Random file id, created by the client</summary>
		public override long ID => id;
	}

	/// <summary>Object contains encrypted message.		<para>Derived classes: <see cref="EncryptedMessage"/>, <see cref="EncryptedMessageService"/></para>		<para>See <a href="https://corefork.telegram.org/type/EncryptedMessage"/></para></summary>
	public abstract class EncryptedMessageBase : IObject
	{
		/// <summary>Random message ID, assigned by the author of message</summary>
		public abstract long RandomId { get; }
		/// <summary>ID of encrypted chat</summary>
		public abstract int ChatId { get; }
		/// <summary>Date of sending</summary>
		public abstract DateTime Date { get; }
		/// <summary>TL-serialization of <see cref="DecryptedMessageBase"/> type, encrypted with the key created at chat initialization</summary>
		public abstract byte[] Bytes { get; }
	}
	/// <summary>Encrypted message.		<para>See <a href="https://corefork.telegram.org/constructor/encryptedMessage"/></para></summary>
	[TLDef(0xED18C118)]
	public class EncryptedMessage : EncryptedMessageBase
	{
		/// <summary>Random message ID, assigned by the author of message</summary>
		public long random_id;
		/// <summary>ID of encrypted chat</summary>
		public int chat_id;
		/// <summary>Date of sending</summary>
		public DateTime date;
		/// <summary>TL-serialization of <see cref="DecryptedMessageBase"/> type, encrypted with the key created at chat initialization</summary>
		public byte[] bytes;
		/// <summary>Attached encrypted file</summary>
		public EncryptedFile file;

		/// <summary>Random message ID, assigned by the author of message</summary>
		public override long RandomId => random_id;
		/// <summary>ID of encrypted chat</summary>
		public override int ChatId => chat_id;
		/// <summary>Date of sending</summary>
		public override DateTime Date => date;
		/// <summary>TL-serialization of <see cref="DecryptedMessageBase"/> type, encrypted with the key created at chat initialization</summary>
		public override byte[] Bytes => bytes;
	}
	/// <summary>Encrypted service message		<para>See <a href="https://corefork.telegram.org/constructor/encryptedMessageService"/></para></summary>
	[TLDef(0x23734B06)]
	public class EncryptedMessageService : EncryptedMessageBase
	{
		/// <summary>Random message ID, assigned by the author of message</summary>
		public long random_id;
		/// <summary>ID of encrypted chat</summary>
		public int chat_id;
		/// <summary>Date of sending</summary>
		public DateTime date;
		/// <summary>TL-serialization of the <see cref="DecryptedMessageBase"/> type, encrypted with the key created at chat initialization</summary>
		public byte[] bytes;

		/// <summary>Random message ID, assigned by the author of message</summary>
		public override long RandomId => random_id;
		/// <summary>ID of encrypted chat</summary>
		public override int ChatId => chat_id;
		/// <summary>Date of sending</summary>
		public override DateTime Date => date;
		/// <summary>TL-serialization of the <see cref="DecryptedMessageBase"/> type, encrypted with the key created at chat initialization</summary>
		public override byte[] Bytes => bytes;
	}

	/// <summary>Contains Diffie-Hellman key generation protocol parameters.		<para>Derived classes: <see cref="Messages_DhConfigNotModified"/>, <see cref="Messages_DhConfig"/></para>		<para>See <a href="https://corefork.telegram.org/type/messages.DhConfig"/></para></summary>
	public abstract class Messages_DhConfigBase : IObject { }
	/// <summary>Configuring parameters did not change.		<para>See <a href="https://corefork.telegram.org/constructor/messages.dhConfigNotModified"/></para></summary>
	[TLDef(0xC0E24635)]
	public class Messages_DhConfigNotModified : Messages_DhConfigBase
	{
		/// <summary>Random sequence of bytes of assigned length</summary>
		public byte[] random;
	}
	/// <summary>New set of configuring parameters.		<para>See <a href="https://corefork.telegram.org/constructor/messages.dhConfig"/></para></summary>
	[TLDef(0x2C221EDD)]
	public class Messages_DhConfig : Messages_DhConfigBase
	{
		/// <summary>New value <strong>prime</strong>, see <a href="https://en.wikipedia.org/wiki/Diffie%E2%80%93Hellman_key_exchange">Wikipedia</a></summary>
		public int g;
		/// <summary>New value <strong>primitive root</strong>, see <a href="https://en.wikipedia.org/wiki/Diffie%E2%80%93Hellman_key_exchange">Wikipedia</a></summary>
		public byte[] p;
		/// <summary>Version of set of parameters</summary>
		public int version;
		/// <summary>Random sequence of bytes of assigned length</summary>
		public byte[] random;
	}

	/// <summary>Message without file attachments sent to an encrypted file.		<para>See <a href="https://corefork.telegram.org/constructor/messages.sentEncryptedMessage"/></para></summary>
	[TLDef(0x560F8935)]
	public class Messages_SentEncryptedMessage : IObject
	{
		/// <summary>Date of sending</summary>
		public DateTime date;
	}
	/// <summary>Message with a file enclosure sent to a protected chat		<para>See <a href="https://corefork.telegram.org/constructor/messages.sentEncryptedFile"/></para></summary>
	[TLDef(0x9493FF32, inheritBefore = true)]
	public class Messages_SentEncryptedFile : Messages_SentEncryptedMessage
	{
		/// <summary>Attached file</summary>
		public EncryptedFile file;
	}

	/// <summary>Defines a video for subsequent interaction.		<para>See <a href="https://corefork.telegram.org/constructor/inputDocument"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputDocumentEmpty">inputDocumentEmpty</a></remarks>
	[TLDef(0x1ABFB575)]
	public partial class InputDocument : IObject
	{
		/// <summary>Document ID</summary>
		public long id;
		/// <summary>⚠ <b>REQUIRED FIELD</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash">how to obtain it</see><br/><strong>access_hash</strong> parameter from the <see cref="Document"/> constructor</summary>
		public long access_hash;
		/// <summary><a href="https://corefork.telegram.org/api/file_reference">File reference</a></summary>
		public byte[] file_reference;
	}

	/// <summary>A document.		<para>Derived classes: <see cref="DocumentEmpty"/>, <see cref="Document"/></para>		<para>See <a href="https://corefork.telegram.org/type/Document"/></para></summary>
	public abstract partial class DocumentBase : IObject { }
	/// <summary>Empty constructor, document doesn't exist.		<para>See <a href="https://corefork.telegram.org/constructor/documentEmpty"/></para></summary>
	[TLDef(0x36F8C871)]
	public partial class DocumentEmpty : DocumentBase
	{
		/// <summary>Document ID or <c>0</c></summary>
		public long id;
	}
	/// <summary>Document		<para>See <a href="https://corefork.telegram.org/constructor/document"/></para></summary>
	[TLDef(0x1E87342B)]
	public partial class Document : DocumentBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Document ID</summary>
		public long id;
		/// <summary>Check sum, dependent on document ID</summary>
		public long access_hash;
		/// <summary><a href="https://corefork.telegram.org/api/file_reference">File reference</a></summary>
		public byte[] file_reference;
		/// <summary>Creation date</summary>
		public DateTime date;
		/// <summary>MIME type</summary>
		public string mime_type;
		/// <summary>Size</summary>
		public int size;
		/// <summary>Thumbnails</summary>
		[IfFlag(0)] public PhotoSizeBase[] thumbs;
		/// <summary>Video thumbnails</summary>
		[IfFlag(1)] public VideoSize[] video_thumbs;
		/// <summary>DC ID</summary>
		public int dc_id;
		/// <summary>Attributes</summary>
		public DocumentAttribute[] attributes;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="thumbs"/> has a value</summary>
			has_thumbs = 0x1,
			/// <summary>Field <see cref="video_thumbs"/> has a value</summary>
			has_video_thumbs = 0x2,
		}
	}

	/// <summary>Info on support user.		<para>See <a href="https://corefork.telegram.org/constructor/help.support"/></para></summary>
	[TLDef(0x17C6B5F6)]
	public class Help_Support : IObject
	{
		/// <summary>Phone number</summary>
		public string phone_number;
		/// <summary>User</summary>
		public UserBase user;
	}

	/// <summary>Object defines the set of users and/or groups that generate notifications.		<para>Derived classes: <see cref="NotifyPeer"/>, <see cref="NotifyUsers"/>, <see cref="NotifyChats"/>, <see cref="NotifyBroadcasts"/></para>		<para>See <a href="https://corefork.telegram.org/type/NotifyPeer"/></para></summary>
	public abstract class NotifyPeerBase : IObject { }
	/// <summary>Notifications generated by a certain user or group.		<para>See <a href="https://corefork.telegram.org/constructor/notifyPeer"/></para></summary>
	[TLDef(0x9FD40BD8)]
	public class NotifyPeer : NotifyPeerBase
	{
		/// <summary>user or group</summary>
		public Peer peer;
	}
	/// <summary>Notifications generated by all users.		<para>See <a href="https://corefork.telegram.org/constructor/notifyUsers"/></para></summary>
	[TLDef(0xB4C83B4C)]
	public class NotifyUsers : NotifyPeerBase { }
	/// <summary>Notifications generated by all groups.		<para>See <a href="https://corefork.telegram.org/constructor/notifyChats"/></para></summary>
	[TLDef(0xC007CEC3)]
	public class NotifyChats : NotifyPeerBase { }
	/// <summary>Channel notification settings		<para>See <a href="https://corefork.telegram.org/constructor/notifyBroadcasts"/></para></summary>
	[TLDef(0xD612E8EF)]
	public class NotifyBroadcasts : NotifyPeerBase { }

	/// <summary>User actions. Use this to provide users with detailed info about their chat partner's actions: typing or sending attachments of all kinds.		<para>Derived classes: <see cref="SendMessageTypingAction"/>, <see cref="SendMessageCancelAction"/>, <see cref="SendMessageRecordVideoAction"/>, <see cref="SendMessageUploadVideoAction"/>, <see cref="SendMessageRecordAudioAction"/>, <see cref="SendMessageUploadAudioAction"/>, <see cref="SendMessageUploadPhotoAction"/>, <see cref="SendMessageUploadDocumentAction"/>, <see cref="SendMessageGeoLocationAction"/>, <see cref="SendMessageChooseContactAction"/>, <see cref="SendMessageGamePlayAction"/>, <see cref="SendMessageRecordRoundAction"/>, <see cref="SendMessageUploadRoundAction"/>, <see cref="SpeakingInGroupCallAction"/>, <see cref="SendMessageHistoryImportAction"/>, <see cref="SendMessageChooseStickerAction"/>, <see cref="SendMessageEmojiInteraction"/>, <see cref="SendMessageEmojiInteractionSeen"/></para>		<para>See <a href="https://corefork.telegram.org/type/SendMessageAction"/></para></summary>
	public abstract partial class SendMessageAction : IObject { }
	/// <summary>User is typing.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageTypingAction"/></para></summary>
	[TLDef(0x16BF744E)]
	public partial class SendMessageTypingAction : SendMessageAction { }
	/// <summary>Invalidate all previous action updates. E.g. when user deletes entered text or aborts a video upload.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageCancelAction"/></para></summary>
	[TLDef(0xFD5EC8F5)]
	public partial class SendMessageCancelAction : SendMessageAction { }
	/// <summary>User is recording a video.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageRecordVideoAction"/></para></summary>
	[TLDef(0xA187D66F)]
	public class SendMessageRecordVideoAction : SendMessageAction { }
	/// <summary>User is uploading a video.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageUploadVideoAction"/></para></summary>
	[TLDef(0xE9763AEC)]
	public class SendMessageUploadVideoAction : SendMessageAction
	{
		/// <summary>Progress percentage</summary>
		public int progress;
	}
	/// <summary>User is recording a voice message.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageRecordAudioAction"/></para></summary>
	[TLDef(0xD52F73F7)]
	public class SendMessageRecordAudioAction : SendMessageAction { }
	/// <summary>User is uploading a voice message.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageUploadAudioAction"/></para></summary>
	[TLDef(0xF351D7AB)]
	public class SendMessageUploadAudioAction : SendMessageAction
	{
		/// <summary>Progress percentage</summary>
		public int progress;
	}
	/// <summary>User is uploading a photo.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageUploadPhotoAction"/></para></summary>
	[TLDef(0xD1D34A26)]
	public class SendMessageUploadPhotoAction : SendMessageAction
	{
		/// <summary>Progress percentage</summary>
		public int progress;
	}
	/// <summary>User is uploading a file.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageUploadDocumentAction"/></para></summary>
	[TLDef(0xAA0CD9E4)]
	public class SendMessageUploadDocumentAction : SendMessageAction
	{
		/// <summary>Progress percentage</summary>
		public int progress;
	}
	/// <summary>User is selecting a location to share.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageGeoLocationAction"/></para></summary>
	[TLDef(0x176F8BA1)]
	public partial class SendMessageGeoLocationAction : SendMessageAction { }
	/// <summary>User is selecting a contact to share.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageChooseContactAction"/></para></summary>
	[TLDef(0x628CBC6F)]
	public class SendMessageChooseContactAction : SendMessageAction { }
	/// <summary>User is playing a game		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageGamePlayAction"/></para></summary>
	[TLDef(0xDD6A8F48)]
	public partial class SendMessageGamePlayAction : SendMessageAction { }
	/// <summary>User is recording a round video to share		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageRecordRoundAction"/></para></summary>
	[TLDef(0x88F27FBC)]
	public class SendMessageRecordRoundAction : SendMessageAction { }
	/// <summary>User is uploading a round video		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageUploadRoundAction"/></para></summary>
	[TLDef(0x243E1C66)]
	public class SendMessageUploadRoundAction : SendMessageAction
	{
		/// <summary>Progress percentage</summary>
		public int progress;
	}
	/// <summary>User is currently speaking in the group call		<para>See <a href="https://corefork.telegram.org/constructor/speakingInGroupCallAction"/></para></summary>
	[TLDef(0xD92C2285)]
	public partial class SpeakingInGroupCallAction : SendMessageAction { }
	/// <summary>Chat history is being imported		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageHistoryImportAction"/></para></summary>
	[TLDef(0xDBDA9246)]
	public partial class SendMessageHistoryImportAction : SendMessageAction
	{
		/// <summary>Progress percentage</summary>
		public int progress;
	}
	/// <summary>User is choosing a sticker		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageChooseStickerAction"/></para></summary>
	[TLDef(0xB05AC6B1)]
	public class SendMessageChooseStickerAction : SendMessageAction { }
	/// <summary>User has clicked on an animated emoji triggering a <a href="https://corefork.telegram.org/api/animated-emojis#emoji-reactions">reaction, click here for more info »</a>.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageEmojiInteraction"/></para></summary>
	[TLDef(0x25972BCB)]
	public partial class SendMessageEmojiInteraction : SendMessageAction
	{
		/// <summary>Emoji</summary>
		public string emoticon;
		/// <summary>Message ID of the animated emoji that was clicked</summary>
		public int msg_id;
		/// <summary>A JSON object with interaction info, <a href="https://corefork.telegram.org/api/animated-emojis#emoji-reactions">click here for more info »</a></summary>
		public DataJSON interaction;
	}
	/// <summary>User is watching an animated emoji reaction triggered by another user, <a href="https://corefork.telegram.org/api/animated-emojis#emoji-reactions">click here for more info »</a>.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageEmojiInteractionSeen"/></para></summary>
	[TLDef(0xB665902E)]
	public partial class SendMessageEmojiInteractionSeen : SendMessageAction
	{
		/// <summary>Emoji</summary>
		public string emoticon;
	}

	/// <summary>Users found by name substring and auxiliary data.		<para>See <a href="https://corefork.telegram.org/constructor/contacts.found"/></para></summary>
	[TLDef(0xB3134D9D)]
	public class Contacts_Found : IObject, IPeerResolver
	{
		/// <summary>Personalized results</summary>
		public Peer[] my_results;
		/// <summary>List of found user identifiers</summary>
		public Peer[] results;
		/// <summary>Found chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>List of users</summary>
		public Dictionary<long, User> users;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}

	/// <summary>Privacy key		<para>See <a href="https://corefork.telegram.org/type/InputPrivacyKey"/></para></summary>
	public enum InputPrivacyKey : uint
	{
		///<summary>Whether we can see the exact last online timestamp of the user</summary>
		StatusTimestamp = 0x4F96CB18,
		///<summary>Whether the user can be invited to chats</summary>
		ChatInvite = 0xBDFB0426,
		///<summary>Whether the user will accept phone calls</summary>
		PhoneCall = 0xFABADC5F,
		///<summary>Whether the user allows P2P communication during VoIP calls</summary>
		PhoneP2P = 0xDB9E70D2,
		///<summary>Whether messages forwarded from this user will be <a href="https://telegram.org/blog/unsend-privacy-emoji#anonymous-forwarding">anonymous</a></summary>
		Forwards = 0xA4DD4C08,
		///<summary>Whether people will be able to see the user's profile picture</summary>
		ProfilePhoto = 0x5719BACC,
		///<summary>Whether people will be able to see the user's phone number</summary>
		PhoneNumber = 0x0352DAFA,
		///<summary>Whether people can add you to their contact list by your phone number</summary>
		AddedByPhone = 0xD1219BDD,
	}

	/// <summary>Privacy key		<para>See <a href="https://corefork.telegram.org/type/PrivacyKey"/></para></summary>
	public enum PrivacyKey : uint
	{
		///<summary>Whether we can see the last online timestamp</summary>
		StatusTimestamp = 0xBC2EAB30,
		///<summary>Whether the user can be invited to chats</summary>
		ChatInvite = 0x500E6DFA,
		///<summary>Whether the user accepts phone calls</summary>
		PhoneCall = 0x3D662B7B,
		///<summary>Whether P2P connections in phone calls are allowed</summary>
		PhoneP2P = 0x39491CC8,
		///<summary>Whether messages forwarded from the user will be <a href="https://telegram.org/blog/unsend-privacy-emoji#anonymous-forwarding">anonymously forwarded</a></summary>
		Forwards = 0x69EC56A3,
		///<summary>Whether the profile picture of the user is visible</summary>
		ProfilePhoto = 0x96151FED,
		///<summary>Whether the user allows us to see his phone number</summary>
		PhoneNumber = 0xD19AE46D,
		///<summary>Whether people can add you to their contact list by your phone number</summary>
		AddedByPhone = 0x42FFD42B,
	}

	/// <summary>Privacy rule		<para>Derived classes: <see cref="InputPrivacyValueAllowContacts"/>, <see cref="InputPrivacyValueAllowAll"/>, <see cref="InputPrivacyValueAllowUsers"/>, <see cref="InputPrivacyValueDisallowContacts"/>, <see cref="InputPrivacyValueDisallowAll"/>, <see cref="InputPrivacyValueDisallowUsers"/>, <see cref="InputPrivacyValueAllowChatParticipants"/>, <see cref="InputPrivacyValueDisallowChatParticipants"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputPrivacyRule"/></para></summary>
	public abstract class InputPrivacyRule : IObject { }
	/// <summary>Allow only contacts		<para>See <a href="https://corefork.telegram.org/constructor/inputPrivacyValueAllowContacts"/></para></summary>
	[TLDef(0x0D09E07B)]
	public class InputPrivacyValueAllowContacts : InputPrivacyRule { }
	/// <summary>Allow all users		<para>See <a href="https://corefork.telegram.org/constructor/inputPrivacyValueAllowAll"/></para></summary>
	[TLDef(0x184B35CE)]
	public class InputPrivacyValueAllowAll : InputPrivacyRule { }
	/// <summary>Allow only certain users		<para>See <a href="https://corefork.telegram.org/constructor/inputPrivacyValueAllowUsers"/></para></summary>
	[TLDef(0x131CC67F)]
	public class InputPrivacyValueAllowUsers : InputPrivacyRule
	{
		/// <summary>Allowed users</summary>
		public InputUserBase[] users;
	}
	/// <summary>Disallow only contacts		<para>See <a href="https://corefork.telegram.org/constructor/inputPrivacyValueDisallowContacts"/></para></summary>
	[TLDef(0x0BA52007)]
	public class InputPrivacyValueDisallowContacts : InputPrivacyRule { }
	/// <summary>Disallow all		<para>See <a href="https://corefork.telegram.org/constructor/inputPrivacyValueDisallowAll"/></para></summary>
	[TLDef(0xD66B66C9)]
	public class InputPrivacyValueDisallowAll : InputPrivacyRule { }
	/// <summary>Disallow only certain users		<para>See <a href="https://corefork.telegram.org/constructor/inputPrivacyValueDisallowUsers"/></para></summary>
	[TLDef(0x90110467)]
	public class InputPrivacyValueDisallowUsers : InputPrivacyRule
	{
		/// <summary>Users to disallow</summary>
		public InputUserBase[] users;
	}
	/// <summary>Allow only participants of certain chats		<para>See <a href="https://corefork.telegram.org/constructor/inputPrivacyValueAllowChatParticipants"/></para></summary>
	[TLDef(0x840649CF)]
	public class InputPrivacyValueAllowChatParticipants : InputPrivacyRule
	{
		/// <summary>Allowed chat IDs</summary>
		public long[] chats;
	}
	/// <summary>Disallow only participants of certain chats		<para>See <a href="https://corefork.telegram.org/constructor/inputPrivacyValueDisallowChatParticipants"/></para></summary>
	[TLDef(0xE94F0F86)]
	public class InputPrivacyValueDisallowChatParticipants : InputPrivacyRule
	{
		/// <summary>Disallowed chat IDs</summary>
		public long[] chats;
	}

	/// <summary>Privacy rule		<para>Derived classes: <see cref="PrivacyValueAllowContacts"/>, <see cref="PrivacyValueAllowAll"/>, <see cref="PrivacyValueAllowUsers"/>, <see cref="PrivacyValueDisallowContacts"/>, <see cref="PrivacyValueDisallowAll"/>, <see cref="PrivacyValueDisallowUsers"/>, <see cref="PrivacyValueAllowChatParticipants"/>, <see cref="PrivacyValueDisallowChatParticipants"/></para>		<para>See <a href="https://corefork.telegram.org/type/PrivacyRule"/></para></summary>
	public abstract class PrivacyRule : IObject { }
	/// <summary>Allow all contacts		<para>See <a href="https://corefork.telegram.org/constructor/privacyValueAllowContacts"/></para></summary>
	[TLDef(0xFFFE1BAC)]
	public class PrivacyValueAllowContacts : PrivacyRule { }
	/// <summary>Allow all users		<para>See <a href="https://corefork.telegram.org/constructor/privacyValueAllowAll"/></para></summary>
	[TLDef(0x65427B82)]
	public class PrivacyValueAllowAll : PrivacyRule { }
	/// <summary>Allow only certain users		<para>See <a href="https://corefork.telegram.org/constructor/privacyValueAllowUsers"/></para></summary>
	[TLDef(0xB8905FB2)]
	public class PrivacyValueAllowUsers : PrivacyRule
	{
		/// <summary>Allowed users</summary>
		public long[] users;
	}
	/// <summary>Disallow only contacts		<para>See <a href="https://corefork.telegram.org/constructor/privacyValueDisallowContacts"/></para></summary>
	[TLDef(0xF888FA1A)]
	public class PrivacyValueDisallowContacts : PrivacyRule { }
	/// <summary>Disallow all users		<para>See <a href="https://corefork.telegram.org/constructor/privacyValueDisallowAll"/></para></summary>
	[TLDef(0x8B73E763)]
	public class PrivacyValueDisallowAll : PrivacyRule { }
	/// <summary>Disallow only certain users		<para>See <a href="https://corefork.telegram.org/constructor/privacyValueDisallowUsers"/></para></summary>
	[TLDef(0xE4621141)]
	public class PrivacyValueDisallowUsers : PrivacyRule
	{
		/// <summary>Disallowed users</summary>
		public long[] users;
	}
	/// <summary>Allow all participants of certain chats		<para>See <a href="https://corefork.telegram.org/constructor/privacyValueAllowChatParticipants"/></para></summary>
	[TLDef(0x6B134E8E)]
	public class PrivacyValueAllowChatParticipants : PrivacyRule
	{
		/// <summary>Allowed chats</summary>
		public long[] chats;
	}
	/// <summary>Disallow only participants of certain chats		<para>See <a href="https://corefork.telegram.org/constructor/privacyValueDisallowChatParticipants"/></para></summary>
	[TLDef(0x41C87565)]
	public class PrivacyValueDisallowChatParticipants : PrivacyRule
	{
		/// <summary>Disallowed chats</summary>
		public long[] chats;
	}

	/// <summary>Privacy rules		<para>See <a href="https://corefork.telegram.org/constructor/account.privacyRules"/></para></summary>
	[TLDef(0x50A04E45)]
	public class Account_PrivacyRules : IObject, IPeerResolver
	{
		/// <summary>Privacy rules</summary>
		public PrivacyRule[] rules;
		/// <summary>Chats to which the rules apply</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users to which the rules apply</summary>
		public Dictionary<long, User> users;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}

	/// <summary>Time to live in days of the current account		<para>See <a href="https://corefork.telegram.org/constructor/accountDaysTTL"/></para></summary>
	[TLDef(0xB8D0AFDF)]
	public class AccountDaysTTL : IObject
	{
		/// <summary>This account will self-destruct in the specified number of days</summary>
		public int days;
	}

	/// <summary>Various possible attributes of a document (used to define if it's a sticker, a GIF, a video, a mask sticker, an image, an audio, and so on)		<para>Derived classes: <see cref="DocumentAttributeImageSize"/>, <see cref="DocumentAttributeAnimated"/>, <see cref="DocumentAttributeSticker"/>, <see cref="DocumentAttributeVideo"/>, <see cref="DocumentAttributeAudio"/>, <see cref="DocumentAttributeFilename"/>, <see cref="DocumentAttributeHasStickers"/></para>		<para>See <a href="https://corefork.telegram.org/type/DocumentAttribute"/></para></summary>
	public abstract class DocumentAttribute : IObject { }
	/// <summary>Defines the width and height of an image uploaded as document		<para>See <a href="https://corefork.telegram.org/constructor/documentAttributeImageSize"/></para></summary>
	[TLDef(0x6C37C15C)]
	public class DocumentAttributeImageSize : DocumentAttribute
	{
		/// <summary>Width of image</summary>
		public int w;
		/// <summary>Height of image</summary>
		public int h;
	}
	/// <summary>Defines an animated GIF		<para>See <a href="https://corefork.telegram.org/constructor/documentAttributeAnimated"/></para></summary>
	[TLDef(0x11B58939)]
	public class DocumentAttributeAnimated : DocumentAttribute { }
	/// <summary>Defines a sticker		<para>See <a href="https://corefork.telegram.org/constructor/documentAttributeSticker"/></para></summary>
	[TLDef(0x6319D612)]
	public class DocumentAttributeSticker : DocumentAttribute
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Alternative emoji representation of sticker</summary>
		public string alt;
		/// <summary>Associated stickerset</summary>
		public InputStickerSet stickerset;
		/// <summary>Mask coordinates (if this is a mask sticker, attached to a photo)</summary>
		[IfFlag(0)] public MaskCoords mask_coords;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="mask_coords"/> has a value</summary>
			has_mask_coords = 0x1,
			/// <summary>Whether this is a mask sticker</summary>
			mask = 0x2,
		}
	}
	/// <summary>Defines a video		<para>See <a href="https://corefork.telegram.org/constructor/documentAttributeVideo"/></para></summary>
	[TLDef(0x0EF02CE6)]
	public class DocumentAttributeVideo : DocumentAttribute
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
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
			/// <summary>Whether the video supports streaming</summary>
			supports_streaming = 0x2,
		}
	}
	/// <summary>Represents an audio file		<para>See <a href="https://corefork.telegram.org/constructor/documentAttributeAudio"/></para></summary>
	[TLDef(0x9852F9C6)]
	public class DocumentAttributeAudio : DocumentAttribute
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Duration in seconds</summary>
		public int duration;
		/// <summary>Name of song</summary>
		[IfFlag(0)] public string title;
		/// <summary>Performer</summary>
		[IfFlag(1)] public string performer;
		/// <summary>Waveform</summary>
		[IfFlag(2)] public byte[] waveform;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="title"/> has a value</summary>
			has_title = 0x1,
			/// <summary>Field <see cref="performer"/> has a value</summary>
			has_performer = 0x2,
			/// <summary>Field <see cref="waveform"/> has a value</summary>
			has_waveform = 0x4,
			/// <summary>Whether this is a voice message</summary>
			voice = 0x400,
		}
	}
	/// <summary>A simple document with a file name		<para>See <a href="https://corefork.telegram.org/constructor/documentAttributeFilename"/></para></summary>
	[TLDef(0x15590068)]
	public class DocumentAttributeFilename : DocumentAttribute
	{
		/// <summary>The file name</summary>
		public string file_name;
	}
	/// <summary>Whether the current document has stickers attached		<para>See <a href="https://corefork.telegram.org/constructor/documentAttributeHasStickers"/></para></summary>
	[TLDef(0x9801D2F7)]
	public class DocumentAttributeHasStickers : DocumentAttribute { }

	/// <summary>Found stickers		<para>See <a href="https://corefork.telegram.org/constructor/messages.stickers"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.stickersNotModified">messages.stickersNotModified</a></remarks>
	[TLDef(0x30A6EC7E)]
	public class Messages_Stickers : IObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></summary>
		public long hash;
		/// <summary>Stickers</summary>
		public DocumentBase[] stickers;
	}

	/// <summary>A stickerpack is a group of stickers associated to the same emoji.<br/>It is <strong>not</strong> a sticker pack the way it is usually intended, you may be looking for a <see cref="StickerSet"/>.		<para>See <a href="https://corefork.telegram.org/constructor/stickerPack"/></para></summary>
	[TLDef(0x12B299D4)]
	public class StickerPack : IObject
	{
		/// <summary>Emoji</summary>
		public string emoticon;
		/// <summary>Stickers</summary>
		public long[] documents;
	}

	/// <summary>Info about all installed stickers		<para>See <a href="https://corefork.telegram.org/constructor/messages.allStickers"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.allStickersNotModified">messages.allStickersNotModified</a></remarks>
	[TLDef(0xCDBBCEBB)]
	public class Messages_AllStickers : IObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></summary>
		public long hash;
		/// <summary>All stickersets</summary>
		public StickerSet[] sets;
	}

	/// <summary>Events affected by operation		<para>See <a href="https://corefork.telegram.org/constructor/messages.affectedMessages"/></para></summary>
	[TLDef(0x84D19185)]
	public class Messages_AffectedMessages : IObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/updates">Event count after generation</a></summary>
		public int pts;
		/// <summary><a href="https://corefork.telegram.org/api/updates">Number of events that were generated</a></summary>
		public int pts_count;
	}

	/// <summary><a href="https://instantview.telegram.org">Instant View</a> webpage preview		<para>Derived classes: <see cref="WebPageEmpty"/>, <see cref="WebPagePending"/>, <see cref="WebPage"/>, <see cref="WebPageNotModified"/></para>		<para>See <a href="https://corefork.telegram.org/type/WebPage"/></para></summary>
	public abstract class WebPageBase : IObject
	{
		/// <summary>Preview ID</summary>
		public abstract long ID { get; }
	}
	/// <summary>No preview is available for the webpage		<para>See <a href="https://corefork.telegram.org/constructor/webPageEmpty"/></para></summary>
	[TLDef(0xEB1477E8)]
	public class WebPageEmpty : WebPageBase
	{
		/// <summary>Preview ID</summary>
		public long id;

		/// <summary>Preview ID</summary>
		public override long ID => id;
	}
	/// <summary>A preview of the webpage is currently being generated		<para>See <a href="https://corefork.telegram.org/constructor/webPagePending"/></para></summary>
	[TLDef(0xC586DA1C)]
	public class WebPagePending : WebPageBase
	{
		/// <summary>ID of preview</summary>
		public long id;
		/// <summary>When was the processing started</summary>
		public DateTime date;

		/// <summary>ID of preview</summary>
		public override long ID => id;
	}
	/// <summary>Webpage preview		<para>See <a href="https://corefork.telegram.org/constructor/webPage"/></para></summary>
	[TLDef(0xE89C45B2)]
	public class WebPage : WebPageBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Preview ID</summary>
		public long id;
		/// <summary>URL of previewed webpage</summary>
		public string url;
		/// <summary>Webpage URL to be displayed to the user</summary>
		public string display_url;
		/// <summary><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></summary>
		public int hash;
		/// <summary>Type of the web page. Can be: article, photo, audio, video, document, profile, app, or something else</summary>
		[IfFlag(0)] public string type;
		/// <summary>Short name of the site (e.g., Google Docs, App Store)</summary>
		[IfFlag(1)] public string site_name;
		/// <summary>Title of the content</summary>
		[IfFlag(2)] public string title;
		/// <summary>Content description</summary>
		[IfFlag(3)] public string description;
		/// <summary>Image representing the content</summary>
		[IfFlag(4)] public PhotoBase photo;
		/// <summary>URL to show in the embedded preview</summary>
		[IfFlag(5)] public string embed_url;
		/// <summary>MIME type of the embedded preview, (e.g., text/html or video/mp4)</summary>
		[IfFlag(5)] public string embed_type;
		/// <summary>Width of the embedded preview</summary>
		[IfFlag(6)] public int embed_width;
		/// <summary>Height of the embedded preview</summary>
		[IfFlag(6)] public int embed_height;
		/// <summary>Duration of the content, in seconds</summary>
		[IfFlag(7)] public int duration;
		/// <summary>Author of the content</summary>
		[IfFlag(8)] public string author;
		/// <summary>Preview of the content as a media file</summary>
		[IfFlag(9)] public DocumentBase document;
		/// <summary>Page contents in <a href="https://instantview.telegram.org">instant view</a> format</summary>
		[IfFlag(10)] public Page cached_page;
		/// <summary>Webpage attributes</summary>
		[IfFlag(12)] public WebPageAttribute[] attributes;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="type"/> has a value</summary>
			has_type = 0x1,
			/// <summary>Field <see cref="site_name"/> has a value</summary>
			has_site_name = 0x2,
			/// <summary>Field <see cref="title"/> has a value</summary>
			has_title = 0x4,
			/// <summary>Field <see cref="description"/> has a value</summary>
			has_description = 0x8,
			/// <summary>Field <see cref="photo"/> has a value</summary>
			has_photo = 0x10,
			/// <summary>Field <see cref="embed_url"/> has a value</summary>
			has_embed_url = 0x20,
			/// <summary>Field <see cref="embed_width"/> has a value</summary>
			has_embed_width = 0x40,
			/// <summary>Field <see cref="duration"/> has a value</summary>
			has_duration = 0x80,
			/// <summary>Field <see cref="author"/> has a value</summary>
			has_author = 0x100,
			/// <summary>Field <see cref="document"/> has a value</summary>
			has_document = 0x200,
			/// <summary>Field <see cref="cached_page"/> has a value</summary>
			has_cached_page = 0x400,
			/// <summary>Field <see cref="attributes"/> has a value</summary>
			has_attributes = 0x1000,
		}

		/// <summary>Preview ID</summary>
		public override long ID => id;
	}
	/// <summary>The preview of the webpage hasn't changed		<para>See <a href="https://corefork.telegram.org/constructor/webPageNotModified"/></para></summary>
	[TLDef(0x7311CA11)]
	public class WebPageNotModified : WebPageBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Page view count</summary>
		[IfFlag(0)] public int cached_page_views;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="cached_page_views"/> has a value</summary>
			has_cached_page_views = 0x1,
		}

		public override long ID => default;
	}

	/// <summary>Logged-in session		<para>See <a href="https://corefork.telegram.org/constructor/authorization"/></para></summary>
	[TLDef(0xAD01D61D)]
	public class Authorization : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Identifier</summary>
		public long hash;
		/// <summary>Device model</summary>
		public string device_model;
		/// <summary>Platform</summary>
		public string platform;
		/// <summary>System version</summary>
		public string system_version;
		/// <summary><a href="https://corefork.telegram.org/api/obtaining_api_id">API ID</a></summary>
		public int api_id;
		/// <summary>App name</summary>
		public string app_name;
		/// <summary>App version</summary>
		public string app_version;
		/// <summary>When was the session created</summary>
		public DateTime date_created;
		/// <summary>When was the session last active</summary>
		public DateTime date_active;
		/// <summary>Last known IP</summary>
		public string ip;
		/// <summary>Country determined from IP</summary>
		public string country;
		/// <summary>Region determined from IP</summary>
		public string region;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether this is the current session</summary>
			current = 0x1,
			/// <summary>Whether the session is from an official app</summary>
			official_app = 0x2,
			/// <summary>Whether the session is still waiting for a 2FA password</summary>
			password_pending = 0x4,
			/// <summary>Whether this session will accept encrypted chats</summary>
			encrypted_requests_disabled = 0x8,
			/// <summary>Whether this session will accept phone calls</summary>
			call_requests_disabled = 0x10,
		}
	}

	/// <summary>Logged-in sessions		<para>See <a href="https://corefork.telegram.org/constructor/account.authorizations"/></para></summary>
	[TLDef(0x4BFF8EA0)]
	public class Account_Authorizations : IObject
	{
		/// <summary>Time-to-live of session</summary>
		public int authorization_ttl_days;
		/// <summary>Logged-in sessions</summary>
		public Authorization[] authorizations;
	}

	/// <summary>Configuration for two-factor authorization		<para>See <a href="https://corefork.telegram.org/constructor/account.password"/></para></summary>
	[TLDef(0x185B184F)]
	public class Account_Password : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The <a href="https://corefork.telegram.org/api/srp">KDF algorithm for SRP two-factor authentication</a> of the current password</summary>
		[IfFlag(2)] public PasswordKdfAlgo current_algo;
		/// <summary>Srp B param for <a href="https://corefork.telegram.org/api/srp">SRP authorization</a></summary>
		[IfFlag(2)] public byte[] srp_B;
		/// <summary>Srp ID param for <a href="https://corefork.telegram.org/api/srp">SRP authorization</a></summary>
		[IfFlag(2)] public long srp_id;
		/// <summary>Text hint for the password</summary>
		[IfFlag(3)] public string hint;
		/// <summary>A <a href="https://corefork.telegram.org/api/srp#email-verification">password recovery email</a> with the specified <a href="https://corefork.telegram.org/api/pattern">pattern</a> is still awaiting verification</summary>
		[IfFlag(4)] public string email_unconfirmed_pattern;
		/// <summary>The <a href="https://corefork.telegram.org/api/srp">KDF algorithm for SRP two-factor authentication</a> to use when creating new passwords</summary>
		public PasswordKdfAlgo new_algo;
		/// <summary>The KDF algorithm for telegram <a href="https://corefork.telegram.org/passport">passport</a></summary>
		public SecurePasswordKdfAlgo new_secure_algo;
		/// <summary>Secure random string</summary>
		public byte[] secure_random;
		/// <summary>The 2FA password will be automatically removed at this date, unless the user cancels the operation</summary>
		[IfFlag(5)] public DateTime pending_reset_date;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the user has a recovery method configured</summary>
			has_recovery = 0x1,
			/// <summary>Whether telegram <a href="https://corefork.telegram.org/passport">passport</a> is enabled</summary>
			has_secure_values = 0x2,
			/// <summary>Whether the user has a password</summary>
			has_password = 0x4,
			/// <summary>Field <see cref="hint"/> has a value</summary>
			has_hint = 0x8,
			/// <summary>Field <see cref="email_unconfirmed_pattern"/> has a value</summary>
			has_email_unconfirmed_pattern = 0x10,
			/// <summary>Field <see cref="pending_reset_date"/> has a value</summary>
			has_pending_reset_date = 0x20,
		}
	}

	/// <summary>Private info associated to the password info (recovery email, telegram <a href="https://corefork.telegram.org/passport">passport</a> info &amp; so on)		<para>See <a href="https://corefork.telegram.org/constructor/account.passwordSettings"/></para></summary>
	[TLDef(0x9A5C33E5)]
	public class Account_PasswordSettings : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary><a href="https://corefork.telegram.org/api/srp#email-verification">2FA Recovery email</a></summary>
		[IfFlag(0)] public string email;
		/// <summary>Telegram <a href="https://corefork.telegram.org/passport">passport</a> settings</summary>
		[IfFlag(1)] public SecureSecretSettings secure_settings;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="email"/> has a value</summary>
			has_email = 0x1,
			/// <summary>Field <see cref="secure_settings"/> has a value</summary>
			has_secure_settings = 0x2,
		}
	}

	/// <summary>Settings for setting up a new password		<para>See <a href="https://corefork.telegram.org/constructor/account.passwordInputSettings"/></para></summary>
	[TLDef(0xC23727C9)]
	public class Account_PasswordInputSettings : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The <a href="https://corefork.telegram.org/api/srp">SRP algorithm</a> to use</summary>
		[IfFlag(0)] public PasswordKdfAlgo new_algo;
		/// <summary>The <a href="https://corefork.telegram.org/api/srp">computed password hash</a></summary>
		[IfFlag(0)] public byte[] new_password_hash;
		/// <summary>Text hint for the password</summary>
		[IfFlag(0)] public string hint;
		/// <summary>Password recovery email</summary>
		[IfFlag(1)] public string email;
		/// <summary>Telegram <a href="https://corefork.telegram.org/passport">passport</a> settings</summary>
		[IfFlag(2)] public SecureSecretSettings new_secure_settings;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="new_algo"/> has a value</summary>
			has_new_algo = 0x1,
			/// <summary>Field <see cref="email"/> has a value</summary>
			has_email = 0x2,
			/// <summary>Field <see cref="new_secure_settings"/> has a value</summary>
			has_new_secure_settings = 0x4,
		}
	}

	/// <summary>Recovery info of a <a href="https://corefork.telegram.org/api/srp">2FA password</a>, only for accounts with a <a href="https://corefork.telegram.org/api/srp#email-verification">recovery email configured</a>.		<para>See <a href="https://corefork.telegram.org/constructor/auth.passwordRecovery"/></para></summary>
	[TLDef(0x137948A5)]
	public class Auth_PasswordRecovery : IObject
	{
		/// <summary>The email to which the recovery code was sent must match this <a href="https://corefork.telegram.org/api/pattern">pattern</a>.</summary>
		public string email_pattern;
	}

	/// <summary>Message ID, for which PUSH-notifications were cancelled.		<para>See <a href="https://corefork.telegram.org/constructor/receivedNotifyMessage"/></para></summary>
	[TLDef(0xA384B779)]
	public class ReceivedNotifyMessage : IObject
	{
		/// <summary>Message ID, for which PUSH-notifications were canceled</summary>
		public int id;
		/// <summary>Reserved for future use</summary>
		public int flags;
	}

	/// <summary>Exported chat invite		<para>Derived classes: <see cref="ChatInviteExported"/></para>		<para>See <a href="https://corefork.telegram.org/type/ExportedChatInvite"/></para></summary>
	public abstract class ExportedChatInvite : IObject { }
	/// <summary>Exported chat invite		<para>See <a href="https://corefork.telegram.org/constructor/chatInviteExported"/></para></summary>
	[TLDef(0x0AB4A819)]
	public class ChatInviteExported : ExportedChatInvite
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Chat invitation link</summary>
		public string link;
		/// <summary>ID of the admin that created this chat invite</summary>
		public long admin_id;
		/// <summary>When was this chat invite created</summary>
		public DateTime date;
		/// <summary>When was this chat invite last modified</summary>
		[IfFlag(4)] public DateTime start_date;
		/// <summary>When does this chat invite expire</summary>
		[IfFlag(1)] public DateTime expire_date;
		/// <summary>Maximum number of users that can join using this link</summary>
		[IfFlag(2)] public int usage_limit;
		/// <summary>How many users joined using this link</summary>
		[IfFlag(3)] public int usage;
		/// <summary>Number of users that have already used this link to join</summary>
		[IfFlag(7)] public int requested;
		/// <summary>Custom description for the invite link, visible only to admins</summary>
		[IfFlag(8)] public string title;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether this chat invite was revoked</summary>
			revoked = 0x1,
			/// <summary>Field <see cref="expire_date"/> has a value</summary>
			has_expire_date = 0x2,
			/// <summary>Field <see cref="usage_limit"/> has a value</summary>
			has_usage_limit = 0x4,
			/// <summary>Field <see cref="usage"/> has a value</summary>
			has_usage = 0x8,
			/// <summary>Field <see cref="start_date"/> has a value</summary>
			has_start_date = 0x10,
			/// <summary>Whether this chat invite has no expiration</summary>
			permanent = 0x20,
			/// <summary>Whether users importing this invite link will have to be approved to join the channel or group</summary>
			request_needed = 0x40,
			/// <summary>Field <see cref="requested"/> has a value</summary>
			has_requested = 0x80,
			/// <summary>Field <see cref="title"/> has a value</summary>
			has_title = 0x100,
		}
	}

	/// <summary>Chat invite		<para>Derived classes: <see cref="ChatInviteAlready"/>, <see cref="ChatInvite"/>, <see cref="ChatInvitePeek"/></para>		<para>See <a href="https://corefork.telegram.org/type/ChatInvite"/></para></summary>
	public abstract class ChatInviteBase : IObject { }
	/// <summary>The user has already joined this chat		<para>See <a href="https://corefork.telegram.org/constructor/chatInviteAlready"/></para></summary>
	[TLDef(0x5A686D7C)]
	public class ChatInviteAlready : ChatInviteBase
	{
		/// <summary>The chat connected to the invite</summary>
		public ChatBase chat;
	}
	/// <summary>Chat invite info		<para>See <a href="https://corefork.telegram.org/constructor/chatInvite"/></para></summary>
	[TLDef(0x300C44C1)]
	public class ChatInvite : ChatInviteBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Chat/supergroup/channel title</summary>
		public string title;
		/// <summary>Description of the group of channel</summary>
		[IfFlag(5)] public string about;
		/// <summary>Chat/supergroup/channel photo</summary>
		public PhotoBase photo;
		/// <summary>Participant count</summary>
		public int participants_count;
		/// <summary>A few of the participants that are in the group</summary>
		[IfFlag(4)] public UserBase[] participants;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether this is a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> or a <a href="https://corefork.telegram.org/api/channel">normal group</a></summary>
			channel = 0x1,
			/// <summary>Whether this is a <a href="https://corefork.telegram.org/api/channel">channel</a></summary>
			broadcast = 0x2,
			/// <summary>Whether this is a public <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a></summary>
			public_ = 0x4,
			/// <summary>Whether this is a <a href="https://corefork.telegram.org/api/channel">supergroup</a></summary>
			megagroup = 0x8,
			/// <summary>Field <see cref="participants"/> has a value</summary>
			has_participants = 0x10,
			/// <summary>Field <see cref="about"/> has a value</summary>
			has_about = 0x20,
			/// <summary>Whether the <a href="https://corefork.telegram.org/api/invites#join-requests">join request »</a> must be first approved by an administrator</summary>
			request_needed = 0x40,
		}
	}
	/// <summary>A chat invitation that also allows peeking into the group to read messages without joining it.		<para>See <a href="https://corefork.telegram.org/constructor/chatInvitePeek"/></para></summary>
	[TLDef(0x61695CB0)]
	public class ChatInvitePeek : ChatInviteBase
	{
		/// <summary>Chat information</summary>
		public ChatBase chat;
		/// <summary>Read-only anonymous access to this group will be revoked at this date</summary>
		public DateTime expires;
	}

	/// <summary>Represents a stickerset		<para>Derived classes: <see cref="InputStickerSetID"/>, <see cref="InputStickerSetShortName"/>, <see cref="InputStickerSetAnimatedEmoji"/>, <see cref="InputStickerSetDice"/>, <see cref="InputStickerSetAnimatedEmojiAnimations"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputStickerSet"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputStickerSetEmpty">inputStickerSetEmpty</a></remarks>
	public abstract class InputStickerSet : IObject { }
	/// <summary>Stickerset by ID		<para>See <a href="https://corefork.telegram.org/constructor/inputStickerSetID"/></para></summary>
	[TLDef(0x9DE7A269)]
	public class InputStickerSetID : InputStickerSet
	{
		/// <summary>ID</summary>
		public long id;
		/// <summary>⚠ <b>REQUIRED FIELD</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash">how to obtain it</see><br/>Access hash</summary>
		public long access_hash;
	}
	/// <summary>Stickerset by short name, from <c>tg://addstickers?set=short_name</c>		<para>See <a href="https://corefork.telegram.org/constructor/inputStickerSetShortName"/></para></summary>
	[TLDef(0x861CC8A0)]
	public class InputStickerSetShortName : InputStickerSet
	{
		/// <summary>From <c>tg://addstickers?set=short_name</c></summary>
		public string short_name;
	}
	/// <summary>Animated emojis stickerset		<para>See <a href="https://corefork.telegram.org/constructor/inputStickerSetAnimatedEmoji"/></para></summary>
	[TLDef(0x028703C8)]
	public class InputStickerSetAnimatedEmoji : InputStickerSet { }
	/// <summary>Used for fetching <a href="https://corefork.telegram.org/api/dice">animated dice stickers</a>		<para>See <a href="https://corefork.telegram.org/constructor/inputStickerSetDice"/></para></summary>
	[TLDef(0xE67F520E)]
	public class InputStickerSetDice : InputStickerSet
	{
		/// <summary>The emoji, for now 🏀, 🎲 and 🎯 are supported</summary>
		public string emoticon;
	}
	/// <summary>Animated emoji reaction stickerset (contains animations to play when a user clicks on a given animated emoji)		<para>See <a href="https://corefork.telegram.org/constructor/inputStickerSetAnimatedEmojiAnimations"/></para></summary>
	[TLDef(0x0CDE3739)]
	public class InputStickerSetAnimatedEmojiAnimations : InputStickerSet { }

	/// <summary>Represents a stickerset (stickerpack)		<para>See <a href="https://corefork.telegram.org/constructor/stickerSet"/></para></summary>
	[TLDef(0xD7DF217A)]
	public partial class StickerSet : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>When was this stickerset installed</summary>
		[IfFlag(0)] public DateTime installed_date;
		/// <summary>ID of the stickerset</summary>
		public long id;
		/// <summary>Access hash of stickerset</summary>
		public long access_hash;
		/// <summary>Title of stickerset</summary>
		public string title;
		/// <summary>Short name of stickerset to use in <c>tg://addstickers?set=short_name</c></summary>
		public string short_name;
		/// <summary>Stickerset thumbnail</summary>
		[IfFlag(4)] public PhotoSizeBase[] thumbs;
		/// <summary>DC ID of thumbnail</summary>
		[IfFlag(4)] public int thumb_dc_id;
		/// <summary>Thumbnail version</summary>
		[IfFlag(4)] public int thumb_version;
		/// <summary>Number of stickers in pack</summary>
		public int count;
		/// <summary>Hash</summary>
		public int hash;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="installed_date"/> has a value</summary>
			has_installed_date = 0x1,
			/// <summary>Whether this stickerset was archived (due to too many saved stickers in the current account)</summary>
			archived = 0x2,
			/// <summary>Is this stickerset official</summary>
			official = 0x4,
			/// <summary>Is this a mask stickerset</summary>
			masks = 0x8,
			/// <summary>Field <see cref="thumbs"/> has a value</summary>
			has_thumbs = 0x10,
			/// <summary>Is this an animated stickerpack</summary>
			animated = 0x20,
			/// <summary>Is this a video stickerpack</summary>
			videos = 0x40,
		}
	}

	/// <summary>Stickerset and stickers inside it		<para>See <a href="https://corefork.telegram.org/constructor/messages.stickerSet"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.stickerSetNotModified">messages.stickerSetNotModified</a></remarks>
	[TLDef(0xB60A24A6)]
	public class Messages_StickerSet : IObject
	{
		/// <summary>The stickerset</summary>
		public StickerSet set;
		/// <summary>Emoji info for stickers</summary>
		public StickerPack[] packs;
		/// <summary>Stickers in stickerset</summary>
		public DocumentBase[] documents;
	}

	/// <summary>Describes a bot command that can be used in a chat		<para>See <a href="https://corefork.telegram.org/constructor/botCommand"/></para></summary>
	[TLDef(0xC27AC8C7)]
	public class BotCommand : IObject
	{
		/// <summary><c>/command</c> name</summary>
		public string command;
		/// <summary>Description of the command</summary>
		public string description;
	}

	/// <summary>Info about bots (available bot commands, etc)		<para>See <a href="https://corefork.telegram.org/constructor/botInfo"/></para></summary>
	[TLDef(0xE4169B5D)]
	public class BotInfo : IObject
	{
		/// <summary>ID of the bot</summary>
		public long user_id;
		/// <summary>Description of the bot</summary>
		public string description;
		/// <summary>Bot commands that can be used in the chat</summary>
		public BotCommand[] commands;
		public BotMenuButtonBase menu_button;
	}

	/// <summary>Bot or inline keyboard buttons		<para>Derived classes: <see cref="KeyboardButton"/>, <see cref="KeyboardButtonUrl"/>, <see cref="KeyboardButtonCallback"/>, <see cref="KeyboardButtonRequestPhone"/>, <see cref="KeyboardButtonRequestGeoLocation"/>, <see cref="KeyboardButtonSwitchInline"/>, <see cref="KeyboardButtonGame"/>, <see cref="KeyboardButtonBuy"/>, <see cref="KeyboardButtonUrlAuth"/>, <see cref="InputKeyboardButtonUrlAuth"/>, <see cref="KeyboardButtonRequestPoll"/>, <see cref="InputKeyboardButtonUserProfile"/>, <see cref="KeyboardButtonUserProfile"/></para>		<para>See <a href="https://corefork.telegram.org/type/KeyboardButton"/></para></summary>
	public abstract class KeyboardButtonBase : IObject
	{
		/// <summary>Button text</summary>
		public abstract string Text { get; }
	}
	/// <summary>Bot keyboard button		<para>See <a href="https://corefork.telegram.org/constructor/keyboardButton"/></para></summary>
	[TLDef(0xA2FA4880)]
	public class KeyboardButton : KeyboardButtonBase
	{
		/// <summary>Button text</summary>
		public string text;

		/// <summary>Button text</summary>
		public override string Text => text;
	}
	/// <summary>URL button		<para>See <a href="https://corefork.telegram.org/constructor/keyboardButtonUrl"/></para></summary>
	[TLDef(0x258AFF05, inheritBefore = true)]
	public class KeyboardButtonUrl : KeyboardButton
	{
		/// <summary>URL</summary>
		public string url;
	}
	/// <summary>Callback button		<para>See <a href="https://corefork.telegram.org/constructor/keyboardButtonCallback"/></para></summary>
	[TLDef(0x35BBDB6B)]
	public class KeyboardButtonCallback : KeyboardButtonBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Button text</summary>
		public string text;
		/// <summary>Callback data</summary>
		public byte[] data;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the user should verify his identity by entering his <a href="https://corefork.telegram.org/api/srp">2FA SRP parameters</a> to the <a href="https://corefork.telegram.org/method/messages.getBotCallbackAnswer">messages.getBotCallbackAnswer</a> method. NOTE: telegram and the bot WILL NOT have access to the plaintext password, thanks to <a href="https://corefork.telegram.org/api/srp">SRP</a>. This button is mainly used by the official <a href="https://t.me/botfather">@botfather</a> bot, for verifying the user's identity before transferring ownership of a bot to another user.</summary>
			requires_password = 0x1,
		}

		/// <summary>Button text</summary>
		public override string Text => text;
	}
	/// <summary>Button to request a user's phone number		<para>See <a href="https://corefork.telegram.org/constructor/keyboardButtonRequestPhone"/></para></summary>
	[TLDef(0xB16A6C29)]
	public class KeyboardButtonRequestPhone : KeyboardButton
	{
	}
	/// <summary>Button to request a user's geolocation		<para>See <a href="https://corefork.telegram.org/constructor/keyboardButtonRequestGeoLocation"/></para></summary>
	[TLDef(0xFC796B3F)]
	public class KeyboardButtonRequestGeoLocation : KeyboardButton
	{
	}
	/// <summary>Button to force a user to switch to inline mode Pressing the button will prompt the user to select one of their chats, open that chat and insert the bot's username and the specified inline query in the input field.		<para>See <a href="https://corefork.telegram.org/constructor/keyboardButtonSwitchInline"/></para></summary>
	[TLDef(0x0568A748)]
	public class KeyboardButtonSwitchInline : KeyboardButtonBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Button label</summary>
		public string text;
		/// <summary>The inline query to use</summary>
		public string query;

		[Flags] public enum Flags : uint
		{
			/// <summary>If set, pressing the button will insert the bot's username and the specified inline <c>query</c> in the current chat's input field.</summary>
			same_peer = 0x1,
		}

		/// <summary>Button label</summary>
		public override string Text => text;
	}
	/// <summary>Button to start a game		<para>See <a href="https://corefork.telegram.org/constructor/keyboardButtonGame"/></para></summary>
	[TLDef(0x50F41CCF)]
	public class KeyboardButtonGame : KeyboardButton
	{
	}
	/// <summary>Button to buy a product		<para>See <a href="https://corefork.telegram.org/constructor/keyboardButtonBuy"/></para></summary>
	[TLDef(0xAFD93FBB)]
	public class KeyboardButtonBuy : KeyboardButton
	{
	}
	/// <summary>Button to request a user to authorize via URL using <a href="https://telegram.org/blog/privacy-discussions-web-bots#meet-seamless-web-bots">Seamless Telegram Login</a>. When the user clicks on such a button, <a href="https://corefork.telegram.org/method/messages.requestUrlAuth">messages.requestUrlAuth</a> should be called, providing the <c>button_id</c> and the ID of the container message. The returned <see cref="UrlAuthResultRequest"/> object will contain more details about the authorization request (<c>request_write_access</c> if the bot would like to send messages to the user along with the username of the bot which will be used for user authorization). Finally, the user can choose to call <a href="https://corefork.telegram.org/method/messages.acceptUrlAuth">messages.acceptUrlAuth</a> to get a <see cref="UrlAuthResultAccepted"/> with the URL to open instead of the <c>url</c> of this constructor, or a <see cref="UrlAuthResultDefault"/>, in which case the <c>url</c> of this constructor must be opened, instead. If the user refuses the authorization request but still wants to open the link, the <c>url</c> of this constructor must be used.		<para>See <a href="https://corefork.telegram.org/constructor/keyboardButtonUrlAuth"/></para></summary>
	[TLDef(0x10B78D29)]
	public class KeyboardButtonUrlAuth : KeyboardButtonBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Button label</summary>
		public string text;
		/// <summary>New text of the button in forwarded messages.</summary>
		[IfFlag(0)] public string fwd_text;
		/// <summary>An HTTP URL to be opened with user authorization data added to the query string when the button is pressed. If the user refuses to provide authorization data, the original URL without information about the user will be opened. The data added is the same as described in <a href="https://corefork.telegram.org/widgets/login#receiving-authorization-data">Receiving authorization data</a>.<br/><br/><strong>NOTE</strong>: Services must <strong>always</strong> check the hash of the received data to verify the authentication and the integrity of the data as described in <a href="https://corefork.telegram.org/widgets/login#checking-authorization">Checking authorization</a>.</summary>
		public string url;
		/// <summary>ID of the button to pass to <a href="https://corefork.telegram.org/method/messages.requestUrlAuth">messages.requestUrlAuth</a></summary>
		public int button_id;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="fwd_text"/> has a value</summary>
			has_fwd_text = 0x1,
		}

		/// <summary>Button label</summary>
		public override string Text => text;
	}
	/// <summary>Button to request a user to <a href="https://corefork.telegram.org/method/messages.acceptUrlAuth">authorize</a> via URL using <a href="https://telegram.org/blog/privacy-discussions-web-bots#meet-seamless-web-bots">Seamless Telegram Login</a>.		<para>See <a href="https://corefork.telegram.org/constructor/inputKeyboardButtonUrlAuth"/></para></summary>
	[TLDef(0xD02E7FD4)]
	public class InputKeyboardButtonUrlAuth : KeyboardButtonBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Button text</summary>
		public string text;
		/// <summary>New text of the button in forwarded messages.</summary>
		[IfFlag(1)] public string fwd_text;
		/// <summary>An HTTP URL to be opened with user authorization data added to the query string when the button is pressed. If the user refuses to provide authorization data, the original URL without information about the user will be opened. The data added is the same as described in <a href="https://corefork.telegram.org/widgets/login#receiving-authorization-data">Receiving authorization data</a>.<br/>NOTE: You must always check the hash of the received data to verify the authentication and the integrity of the data as described in <a href="https://corefork.telegram.org/widgets/login#checking-authorization">Checking authorization</a>.</summary>
		public string url;
		/// <summary>Username of a bot, which will be used for user authorization. See <a href="https://corefork.telegram.org/widgets/login#setting-up-a-bot">Setting up a bot</a> for more details. If not specified, the current bot's username will be assumed. The url's domain must be the same as the domain linked with the bot. See <a href="https://corefork.telegram.org/widgets/login#linking-your-domain-to-the-bot">Linking your domain to the bot</a> for more details.</summary>
		public InputUserBase bot;

		[Flags] public enum Flags : uint
		{
			/// <summary>Set this flag to request the permission for your bot to send messages to the user.</summary>
			request_write_access = 0x1,
			/// <summary>Field <see cref="fwd_text"/> has a value</summary>
			has_fwd_text = 0x2,
		}

		/// <summary>Button text</summary>
		public override string Text => text;
	}
	/// <summary>A button that allows the user to create and send a poll when pressed; available only in private		<para>See <a href="https://corefork.telegram.org/constructor/keyboardButtonRequestPoll"/></para></summary>
	[TLDef(0xBBC7515D)]
	public class KeyboardButtonRequestPoll : KeyboardButton
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>If set, only quiz polls can be sent</summary>
		[IfFlag(0)] public bool quiz;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="quiz"/> has a value</summary>
			has_quiz = 0x1,
		}
	}
	/// <summary>Button that links directly to a user profile		<para>See <a href="https://corefork.telegram.org/constructor/inputKeyboardButtonUserProfile"/></para></summary>
	[TLDef(0xE988037B)]
	public class InputKeyboardButtonUserProfile : KeyboardButtonBase
	{
		/// <summary>Button text</summary>
		public string text;
		/// <summary>User ID</summary>
		public InputUserBase user_id;

		/// <summary>Button text</summary>
		public override string Text => text;
	}
	/// <summary>Button that links directly to a user profile		<para>See <a href="https://corefork.telegram.org/constructor/keyboardButtonUserProfile"/></para></summary>
	[TLDef(0x308660C1, inheritBefore = true)]
	public class KeyboardButtonUserProfile : KeyboardButton
	{
		/// <summary>User ID</summary>
		public long user_id;
	}
	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/keyboardButtonWebView"/></para></summary>
	[TLDef(0x13767230, inheritBefore = true)]
	public class KeyboardButtonWebView : KeyboardButton
	{
		public string url;
	}
	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/keyboardButtonSimpleWebView"/></para></summary>
	[TLDef(0xA0C0505C)]
	public class KeyboardButtonSimpleWebView : KeyboardButtonWebView
	{
	}

	/// <summary>Inline keyboard row		<para>See <a href="https://corefork.telegram.org/constructor/keyboardButtonRow"/></para></summary>
	[TLDef(0x77608B83)]
	public class KeyboardButtonRow : IObject
	{
		/// <summary>Bot or inline keyboard buttons</summary>
		public KeyboardButtonBase[] buttons;
	}

	/// <summary>Reply markup for bot and inline keyboards		<para>Derived classes: <see cref="ReplyKeyboardHide"/>, <see cref="ReplyKeyboardForceReply"/>, <see cref="ReplyKeyboardMarkup"/>, <see cref="ReplyInlineMarkup"/></para>		<para>See <a href="https://corefork.telegram.org/type/ReplyMarkup"/></para></summary>
	public abstract class ReplyMarkup : IObject { }
	/// <summary>Hide sent bot keyboard		<para>See <a href="https://corefork.telegram.org/constructor/replyKeyboardHide"/></para></summary>
	[TLDef(0xA03E5B85)]
	public class ReplyKeyboardHide : ReplyMarkup
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;

		[Flags] public enum Flags : uint
		{
			/// <summary>Use this flag if you want to remove the keyboard for specific users only. Targets: 1) users that are @mentioned in the text of the Message object; 2) if the bot's message is a reply (has reply_to_message_id), sender of the original message.<br/><br/>Example: A user votes in a poll, bot returns confirmation message in reply to the vote and removes the keyboard for that user, while still showing the keyboard with poll options to users who haven't voted yet</summary>
			selective = 0x4,
		}
	}
	/// <summary>Force the user to send a reply		<para>See <a href="https://corefork.telegram.org/constructor/replyKeyboardForceReply"/></para></summary>
	[TLDef(0x86B40B08)]
	public class ReplyKeyboardForceReply : ReplyMarkup
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The placeholder to be shown in the input field when the keyboard is active; 1-64 characters.</summary>
		[IfFlag(3)] public string placeholder;

		[Flags] public enum Flags : uint
		{
			/// <summary>Requests clients to hide the keyboard as soon as it's been used. The keyboard will still be available, but clients will automatically display the usual letter-keyboard in the chat – the user can press a special button in the input field to see the custom keyboard again.</summary>
			single_use = 0x2,
			/// <summary>Use this parameter if you want to show the keyboard to specific users only. Targets: 1) users that are @mentioned in the text of the Message object; 2) if the bot's message is a reply (has reply_to_message_id), sender of the original message. <br/>Example: A user requests to change the bot's language, bot replies to the request with a keyboard to select the new language. Other users in the group don't see the keyboard.</summary>
			selective = 0x4,
			/// <summary>Field <see cref="placeholder"/> has a value</summary>
			has_placeholder = 0x8,
		}
	}
	/// <summary>Bot keyboard		<para>See <a href="https://corefork.telegram.org/constructor/replyKeyboardMarkup"/></para></summary>
	[TLDef(0x85DD99D1)]
	public class ReplyKeyboardMarkup : ReplyMarkup
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Button row</summary>
		public KeyboardButtonRow[] rows;
		/// <summary>The placeholder to be shown in the input field when the keyboard is active; 1-64 characters.</summary>
		[IfFlag(3)] public string placeholder;

		[Flags] public enum Flags : uint
		{
			/// <summary>Requests clients to resize the keyboard vertically for optimal fit (e.g., make the keyboard smaller if there are just two rows of buttons). If not set, the custom keyboard is always of the same height as the app's standard keyboard.</summary>
			resize = 0x1,
			/// <summary>Requests clients to hide the keyboard as soon as it's been used. The keyboard will still be available, but clients will automatically display the usual letter-keyboard in the chat – the user can press a special button in the input field to see the custom keyboard again.</summary>
			single_use = 0x2,
			/// <summary>Use this parameter if you want to show the keyboard to specific users only. Targets: 1) users that are @mentioned in the text of the Message object; 2) if the bot's message is a reply (has reply_to_message_id), sender of the original message.<br/><br/>Example: A user requests to change the bot's language, bot replies to the request with a keyboard to select the new language. Other users in the group don't see the keyboard.</summary>
			selective = 0x4,
			/// <summary>Field <see cref="placeholder"/> has a value</summary>
			has_placeholder = 0x8,
		}
	}
	/// <summary>Bot or inline keyboard		<para>See <a href="https://corefork.telegram.org/constructor/replyInlineMarkup"/></para></summary>
	[TLDef(0x48A30254)]
	public class ReplyInlineMarkup : ReplyMarkup
	{
		/// <summary>Bot or inline keyboard rows</summary>
		public KeyboardButtonRow[] rows;
	}

	/// <summary>Message entities, representing styled text in a message		<para>Derived classes: <see cref="MessageEntityUnknown"/>, <see cref="MessageEntityMention"/>, <see cref="MessageEntityHashtag"/>, <see cref="MessageEntityBotCommand"/>, <see cref="MessageEntityUrl"/>, <see cref="MessageEntityEmail"/>, <see cref="MessageEntityBold"/>, <see cref="MessageEntityItalic"/>, <see cref="MessageEntityCode"/>, <see cref="MessageEntityPre"/>, <see cref="MessageEntityTextUrl"/>, <see cref="MessageEntityMentionName"/>, <see cref="InputMessageEntityMentionName"/>, <see cref="MessageEntityPhone"/>, <see cref="MessageEntityCashtag"/>, <see cref="MessageEntityUnderline"/>, <see cref="MessageEntityStrike"/>, <see cref="MessageEntityBlockquote"/>, <see cref="MessageEntityBankCard"/>, <see cref="MessageEntitySpoiler"/></para>		<para>See <a href="https://corefork.telegram.org/type/MessageEntity"/></para></summary>
	public abstract class MessageEntity : IObject
	{
		/// <summary>Offset of message entity within message (in UTF-8 codepoints)</summary>
		public int offset;
		/// <summary>Length of message entity within message (in UTF-8 codepoints)</summary>
		public int length;
	}
	/// <summary>Unknown message entity		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityUnknown"/></para></summary>
	[TLDef(0xBB92BA95)]
	public class MessageEntityUnknown : MessageEntity { }
	/// <summary>Message entity <a href="https://corefork.telegram.org/api/mentions">mentioning</a> the current user		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityMention"/></para></summary>
	[TLDef(0xFA04579D)]
	public class MessageEntityMention : MessageEntity { }
	/// <summary><strong>#hashtag</strong> message entity		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityHashtag"/></para></summary>
	[TLDef(0x6F635B0D)]
	public class MessageEntityHashtag : MessageEntity { }
	/// <summary>Message entity representing a bot /command		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityBotCommand"/></para></summary>
	[TLDef(0x6CEF8AC7)]
	public class MessageEntityBotCommand : MessageEntity { }
	/// <summary>Message entity representing an in-text url: <a href="https://google.com">https://google.com</a>; for <a href="https://google.com">text urls</a>, use <see cref="MessageEntityTextUrl"/>.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityUrl"/></para></summary>
	[TLDef(0x6ED02538)]
	public class MessageEntityUrl : MessageEntity { }
	/// <summary>Message entity representing an <a href="mailto:email@example.com">email@example.com</a>.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityEmail"/></para></summary>
	[TLDef(0x64E475C2)]
	public class MessageEntityEmail : MessageEntity { }
	/// <summary>Message entity representing <strong>bold text</strong>.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityBold"/></para></summary>
	[TLDef(0xBD610BC9)]
	public class MessageEntityBold : MessageEntity { }
	/// <summary>Message entity representing <em>italic text</em>.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityItalic"/></para></summary>
	[TLDef(0x826F8B60)]
	public class MessageEntityItalic : MessageEntity { }
	/// <summary>Message entity representing a <c>codeblock</c>.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityCode"/></para></summary>
	[TLDef(0x28A20571)]
	public class MessageEntityCode : MessageEntity { }
	/// <summary>Message entity representing a preformatted <c>codeblock</c>, allowing the user to specify a programming language for the codeblock.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityPre"/></para></summary>
	[TLDef(0x73924BE0, inheritBefore = true)]
	public class MessageEntityPre : MessageEntity
	{
		/// <summary>Programming language of the code</summary>
		public string language;
	}
	/// <summary>Message entity representing a <a href="https://google.com">text url</a>: for in-text urls like <a href="https://google.com">https://google.com</a> use <see cref="MessageEntityUrl"/>.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityTextUrl"/></para></summary>
	[TLDef(0x76A6D327, inheritBefore = true)]
	public class MessageEntityTextUrl : MessageEntity
	{
		/// <summary>The actual URL</summary>
		public string url;
	}
	/// <summary>Message entity representing a <a href="https://corefork.telegram.org/api/mentions">user mention</a>: for <em>creating</em> a mention use <see cref="InputMessageEntityMentionName"/>.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityMentionName"/></para></summary>
	[TLDef(0xDC7B1140, inheritBefore = true)]
	public class MessageEntityMentionName : MessageEntity
	{
		/// <summary>Identifier of the user that was mentioned</summary>
		public long user_id;
	}
	/// <summary>Message entity that can be used to create a user <a href="https://corefork.telegram.org/api/mentions">user mention</a>: received mentions use the <see cref="MessageEntityMentionName"/> constructor, instead.		<para>See <a href="https://corefork.telegram.org/constructor/inputMessageEntityMentionName"/></para></summary>
	[TLDef(0x208E68C9, inheritBefore = true)]
	public class InputMessageEntityMentionName : MessageEntity
	{
		/// <summary>Identifier of the user that was mentioned</summary>
		public InputUserBase user_id;
	}
	/// <summary>Message entity representing a phone number.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityPhone"/></para></summary>
	[TLDef(0x9B69E34B)]
	public class MessageEntityPhone : MessageEntity { }
	/// <summary>Message entity representing a <strong>$cashtag</strong>.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityCashtag"/></para></summary>
	[TLDef(0x4C4E743F)]
	public class MessageEntityCashtag : MessageEntity { }
	/// <summary>Message entity representing underlined text.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityUnderline"/></para></summary>
	[TLDef(0x9C4E7E8B)]
	public class MessageEntityUnderline : MessageEntity { }
	/// <summary>Message entity representing <del>strikethrough</del> text.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityStrike"/></para></summary>
	[TLDef(0xBF0693D4)]
	public class MessageEntityStrike : MessageEntity { }
	/// <summary>Message entity representing a block quote.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityBlockquote"/></para></summary>
	[TLDef(0x020DF5D0)]
	public class MessageEntityBlockquote : MessageEntity { }
	/// <summary>Indicates a credit card number		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityBankCard"/></para></summary>
	[TLDef(0x761E6AF4)]
	public class MessageEntityBankCard : MessageEntity { }
	/// <summary>Message entity representing a spoiler		<para>See <a href="https://corefork.telegram.org/constructor/messageEntitySpoiler"/></para></summary>
	[TLDef(0x32CA960F)]
	public class MessageEntitySpoiler : MessageEntity { }

	/// <summary>Represents a channel		<para>Derived classes: <see cref="InputChannel"/>, <see cref="InputChannelFromMessage"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputChannel"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputChannelEmpty">inputChannelEmpty</a></remarks>
	public abstract class InputChannelBase : IObject
	{
		/// <summary>Channel ID</summary>
		public abstract long ChannelId { get; }
	}
	/// <summary>Represents a channel		<para>See <a href="https://corefork.telegram.org/constructor/inputChannel"/></para></summary>
	[TLDef(0xF35AEC28)]
	public partial class InputChannel : InputChannelBase
	{
		/// <summary>Channel ID</summary>
		public long channel_id;
		/// <summary>⚠ <b>REQUIRED FIELD</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash">how to obtain it</see><br/>Access hash taken from the <see cref="Channel"/> constructor</summary>
		public long access_hash;

		/// <summary>Channel ID</summary>
		public override long ChannelId => channel_id;
	}
	/// <summary>Defines a <a href="https://corefork.telegram.org/api/min">min</a> channel that was seen in a certain message of a certain chat.		<para>See <a href="https://corefork.telegram.org/constructor/inputChannelFromMessage"/></para></summary>
	[TLDef(0x5B934F9D)]
	public class InputChannelFromMessage : InputChannelBase
	{
		/// <summary>The chat where the channel was seen</summary>
		public InputPeer peer;
		/// <summary>The message ID in the chat where the channel was seen</summary>
		public int msg_id;
		/// <summary>The channel ID</summary>
		public long channel_id;

		/// <summary>The channel ID</summary>
		public override long ChannelId => channel_id;
	}

	/// <summary>Resolved peer		<para>See <a href="https://corefork.telegram.org/constructor/contacts.resolvedPeer"/></para></summary>
	[TLDef(0x7F077AD9)]
	public partial class Contacts_ResolvedPeer : IObject
	{
		/// <summary>The peer</summary>
		public Peer peer;
		/// <summary>Chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users</summary>
		public Dictionary<long, User> users;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the result</summary>
		public IPeerInfo UserOrChat => peer?.UserOrChat(users, chats);
	}

	/// <summary>Indicates a range of chat messages		<para>See <a href="https://corefork.telegram.org/constructor/messageRange"/></para></summary>
	[TLDef(0x0AE30253)]
	public class MessageRange : IObject
	{
		/// <summary>Start of range (message ID)</summary>
		public int min_id;
		/// <summary>End of range (message ID)</summary>
		public int max_id;
	}

	/// <summary>Contains the difference (new messages) between our local channel state and the remote state		<para>Derived classes: <see cref="Updates_ChannelDifferenceEmpty"/>, <see cref="Updates_ChannelDifferenceTooLong"/>, <see cref="Updates_ChannelDifference"/></para>		<para>See <a href="https://corefork.telegram.org/type/updates.ChannelDifference"/></para></summary>
	public abstract partial class Updates_ChannelDifferenceBase : IObject, IPeerResolver
	{
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public abstract IPeerInfo UserOrChat(Peer peer);
	}
	/// <summary>There are no new updates		<para>See <a href="https://corefork.telegram.org/constructor/updates.channelDifferenceEmpty"/></para></summary>
	[TLDef(0x3E11AFFB)]
	public partial class Updates_ChannelDifferenceEmpty : Updates_ChannelDifferenceBase, IPeerResolver
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The latest <a href="https://corefork.telegram.org/api/updates">PTS</a></summary>
		public int pts;
		/// <summary>Clients are supposed to refetch the channel difference after timeout seconds have elapsed</summary>
		[IfFlag(1)] public int timeout;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether there are more updates that must be fetched (always false)</summary>
			final = 0x1,
			/// <summary>Field <see cref="timeout"/> has a value</summary>
			has_timeout = 0x2,
		}
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => null;
	}
	/// <summary>The provided <c>pts + limit &lt; remote pts</c>. Simply, there are too many updates to be fetched (more than <c>limit</c>), the client has to resolve the update gap in one of the following ways (assuming the existence of a persistent database to locally store messages):		<para>See <a href="https://corefork.telegram.org/constructor/updates.channelDifferenceTooLong"/></para></summary>
	[TLDef(0xA4BCC6FE)]
	public partial class Updates_ChannelDifferenceTooLong : Updates_ChannelDifferenceBase, IPeerResolver
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Clients are supposed to refetch the channel difference after timeout seconds have elapsed</summary>
		[IfFlag(1)] public int timeout;
		/// <summary>Dialog containing the latest <a href="https://corefork.telegram.org/api/updates">PTS</a> that can be used to reset the channel state</summary>
		public DialogBase dialog;
		/// <summary>The latest messages</summary>
		public MessageBase[] messages;
		/// <summary>Chats from messages</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users from messages</summary>
		public Dictionary<long, User> users;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether there are more updates that must be fetched (always false)</summary>
			final = 0x1,
			/// <summary>Field <see cref="timeout"/> has a value</summary>
			has_timeout = 0x2,
		}
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}
	/// <summary>The new updates		<para>See <a href="https://corefork.telegram.org/constructor/updates.channelDifference"/></para></summary>
	[TLDef(0x2064674E)]
	public partial class Updates_ChannelDifference : Updates_ChannelDifferenceBase, IPeerResolver
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The <a href="https://corefork.telegram.org/api/updates">PTS</a> from which to start getting updates the next time</summary>
		public int pts;
		/// <summary>Clients are supposed to refetch the channel difference after timeout seconds have elapsed</summary>
		[IfFlag(1)] public int timeout;
		/// <summary>New messages</summary>
		public MessageBase[] new_messages;
		/// <summary>Other updates</summary>
		public Update[] other_updates;
		/// <summary>Chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users</summary>
		public Dictionary<long, User> users;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether there are more updates to be fetched using getDifference, starting from the provided <c>pts</c></summary>
			final = 0x1,
			/// <summary>Field <see cref="timeout"/> has a value</summary>
			has_timeout = 0x2,
		}
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}

	/// <summary>Filter for getting only certain types of channel messages		<para>See <a href="https://corefork.telegram.org/constructor/channelMessagesFilter"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/channelMessagesFilterEmpty">channelMessagesFilterEmpty</a></remarks>
	[TLDef(0xCD77D957)]
	public class ChannelMessagesFilter : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>A range of messages to fetch</summary>
		public MessageRange[] ranges;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether to exclude new messages from the search</summary>
			exclude_new_messages = 0x2,
		}
	}

	/// <summary>Channel participant		<para>Derived classes: <see cref="ChannelParticipant"/>, <see cref="ChannelParticipantSelf"/>, <see cref="ChannelParticipantCreator"/>, <see cref="ChannelParticipantAdmin"/>, <see cref="ChannelParticipantBanned"/>, <see cref="ChannelParticipantLeft"/></para>		<para>See <a href="https://corefork.telegram.org/type/ChannelParticipant"/></para></summary>
	public abstract partial class ChannelParticipantBase : IObject { }
	/// <summary>Channel/supergroup participant		<para>See <a href="https://corefork.telegram.org/constructor/channelParticipant"/></para></summary>
	[TLDef(0xC00C07C0)]
	public partial class ChannelParticipant : ChannelParticipantBase
	{
		/// <summary>Participant user ID</summary>
		public long user_id;
		/// <summary>Date joined</summary>
		public DateTime date;
	}
	/// <summary>Myself		<para>See <a href="https://corefork.telegram.org/constructor/channelParticipantSelf"/></para></summary>
	[TLDef(0x35A8BFA7)]
	public partial class ChannelParticipantSelf : ChannelParticipantBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>User ID</summary>
		public long user_id;
		/// <summary>User that invited me to the channel/supergroup</summary>
		public long inviter_id;
		/// <summary>When did I join the channel/supergroup</summary>
		public DateTime date;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether I joined upon specific approval of an admin</summary>
			via_request = 0x1,
		}
	}
	/// <summary>Channel/supergroup creator		<para>See <a href="https://corefork.telegram.org/constructor/channelParticipantCreator"/></para></summary>
	[TLDef(0x2FE601D3)]
	public partial class ChannelParticipantCreator : ChannelParticipantBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>User ID</summary>
		public long user_id;
		/// <summary>Creator admin rights</summary>
		public ChatAdminRights admin_rights;
		/// <summary>The role (rank) of the group creator in the group: just an arbitrary string, <c>admin</c> by default</summary>
		[IfFlag(0)] public string rank;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="rank"/> has a value</summary>
			has_rank = 0x1,
		}
	}
	/// <summary>Admin		<para>See <a href="https://corefork.telegram.org/constructor/channelParticipantAdmin"/></para></summary>
	[TLDef(0x34C3BB53)]
	public partial class ChannelParticipantAdmin : ChannelParticipantBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Admin user ID</summary>
		public long user_id;
		/// <summary>User that invited the admin to the channel/group</summary>
		[IfFlag(1)] public long inviter_id;
		/// <summary>User that promoted the user to admin</summary>
		public long promoted_by;
		/// <summary>When did the user join</summary>
		public DateTime date;
		/// <summary>Admin <a href="https://corefork.telegram.org/api/rights">rights</a></summary>
		public ChatAdminRights admin_rights;
		/// <summary>The role (rank) of the admin in the group: just an arbitrary string, <c>admin</c> by default</summary>
		[IfFlag(2)] public string rank;

		[Flags] public enum Flags : uint
		{
			/// <summary>Can this admin promote other admins with the same permissions?</summary>
			can_edit = 0x1,
			/// <summary>Is this the current user</summary>
			self = 0x2,
			/// <summary>Field <see cref="rank"/> has a value</summary>
			has_rank = 0x4,
		}
	}
	/// <summary>Banned/kicked user		<para>See <a href="https://corefork.telegram.org/constructor/channelParticipantBanned"/></para></summary>
	[TLDef(0x6DF8014E)]
	public partial class ChannelParticipantBanned : ChannelParticipantBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The banned peer</summary>
		public Peer peer;
		/// <summary>User was kicked by the specified admin</summary>
		public long kicked_by;
		/// <summary>When did the user join the group</summary>
		public DateTime date;
		/// <summary>Banned <a href="https://corefork.telegram.org/api/rights">rights</a></summary>
		public ChatBannedRights banned_rights;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the user has left the group</summary>
			left = 0x1,
		}
	}
	/// <summary>A participant that left the channel/supergroup		<para>See <a href="https://corefork.telegram.org/constructor/channelParticipantLeft"/></para></summary>
	[TLDef(0x1B03F006)]
	public partial class ChannelParticipantLeft : ChannelParticipantBase
	{
		/// <summary>The peer that left</summary>
		public Peer peer;
	}

	/// <summary>Filter for fetching channel participants		<para>Derived classes: <see cref="ChannelParticipantsRecent"/>, <see cref="ChannelParticipantsAdmins"/>, <see cref="ChannelParticipantsKicked"/>, <see cref="ChannelParticipantsBots"/>, <see cref="ChannelParticipantsBanned"/>, <see cref="ChannelParticipantsSearch"/>, <see cref="ChannelParticipantsContacts"/>, <see cref="ChannelParticipantsMentions"/></para>		<para>See <a href="https://corefork.telegram.org/type/ChannelParticipantsFilter"/></para></summary>
	public abstract class ChannelParticipantsFilter : IObject { }
	/// <summary>Fetch only recent participants		<para>See <a href="https://corefork.telegram.org/constructor/channelParticipantsRecent"/></para></summary>
	[TLDef(0xDE3F3C79)]
	public class ChannelParticipantsRecent : ChannelParticipantsFilter { }
	/// <summary>Fetch only admin participants		<para>See <a href="https://corefork.telegram.org/constructor/channelParticipantsAdmins"/></para></summary>
	[TLDef(0xB4608969)]
	public class ChannelParticipantsAdmins : ChannelParticipantsFilter { }
	/// <summary>Fetch only kicked participants		<para>See <a href="https://corefork.telegram.org/constructor/channelParticipantsKicked"/></para></summary>
	[TLDef(0xA3B54985)]
	public class ChannelParticipantsKicked : ChannelParticipantsFilter
	{
		/// <summary>Optional filter for searching kicked participants by name (otherwise empty)</summary>
		public string q;
	}
	/// <summary>Fetch only bot participants		<para>See <a href="https://corefork.telegram.org/constructor/channelParticipantsBots"/></para></summary>
	[TLDef(0xB0D1865B)]
	public class ChannelParticipantsBots : ChannelParticipantsFilter { }
	/// <summary>Fetch only banned participants		<para>See <a href="https://corefork.telegram.org/constructor/channelParticipantsBanned"/></para></summary>
	[TLDef(0x1427A5E1)]
	public class ChannelParticipantsBanned : ChannelParticipantsFilter
	{
		/// <summary>Optional filter for searching banned participants by name (otherwise empty)</summary>
		public string q;
	}
	/// <summary>Query participants by name		<para>See <a href="https://corefork.telegram.org/constructor/channelParticipantsSearch"/></para></summary>
	[TLDef(0x0656AC4B)]
	public class ChannelParticipantsSearch : ChannelParticipantsFilter
	{
		/// <summary>Search query</summary>
		public string q;
	}
	/// <summary>Fetch only participants that are also contacts		<para>See <a href="https://corefork.telegram.org/constructor/channelParticipantsContacts"/></para></summary>
	[TLDef(0xBB6AE88D)]
	public class ChannelParticipantsContacts : ChannelParticipantsFilter
	{
		/// <summary>Optional search query for searching contact participants by name</summary>
		public string q;
	}
	/// <summary>This filter is used when looking for supergroup members to mention.<br/>This filter will automatically remove anonymous admins, and return even non-participant users that replied to a specific <a href="https://corefork.telegram.org/api/threads">thread</a> through the <a href="https://corefork.telegram.org/api/threads#channel-comments">comment section</a> of a channel.		<para>See <a href="https://corefork.telegram.org/constructor/channelParticipantsMentions"/></para></summary>
	[TLDef(0xE04B5CEB)]
	public class ChannelParticipantsMentions : ChannelParticipantsFilter
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Filter by user name or username</summary>
		[IfFlag(0)] public string q;
		/// <summary>Look only for users that posted in this <a href="https://corefork.telegram.org/api/threads">thread</a></summary>
		[IfFlag(1)] public int top_msg_id;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="q"/> has a value</summary>
			has_q = 0x1,
			/// <summary>Field <see cref="top_msg_id"/> has a value</summary>
			has_top_msg_id = 0x2,
		}
	}

	/// <summary>Represents multiple channel participants		<para>See <a href="https://corefork.telegram.org/constructor/channels.channelParticipants"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/channels.channelParticipantsNotModified">channels.channelParticipantsNotModified</a></remarks>
	[TLDef(0x9AB0FEAF)]
	public class Channels_ChannelParticipants : IObject, IPeerResolver
	{
		/// <summary>Total number of participants that correspond to the given query</summary>
		public int count;
		/// <summary>Participants</summary>
		public ChannelParticipantBase[] participants;
		/// <summary>Mentioned chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users mentioned in participant info</summary>
		public Dictionary<long, User> users;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}

	/// <summary>Represents a channel participant		<para>See <a href="https://corefork.telegram.org/constructor/channels.channelParticipant"/></para></summary>
	[TLDef(0xDFB80317)]
	public class Channels_ChannelParticipant : IObject, IPeerResolver
	{
		/// <summary>The channel participant</summary>
		public ChannelParticipantBase participant;
		/// <summary>Mentioned chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users</summary>
		public Dictionary<long, User> users;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}

	/// <summary>Info about the latest telegram Terms Of Service		<para>See <a href="https://corefork.telegram.org/constructor/help.termsOfService"/></para></summary>
	[TLDef(0x780A0310)]
	public class Help_TermsOfService : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>ID of the new terms</summary>
		public DataJSON id;
		/// <summary>Text of the new terms</summary>
		public string text;
		/// <summary><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></summary>
		public MessageEntity[] entities;
		/// <summary>Minimum age required to sign up to telegram, the user must confirm that they is older than the minimum age.</summary>
		[IfFlag(1)] public int min_age_confirm;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether a prompt must be showed to the user, in order to accept the new terms.</summary>
			popup = 0x1,
			/// <summary>Field <see cref="min_age_confirm"/> has a value</summary>
			has_min_age_confirm = 0x2,
		}
	}

	/// <summary>Saved gifs		<para>See <a href="https://corefork.telegram.org/constructor/messages.savedGifs"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.savedGifsNotModified">messages.savedGifsNotModified</a></remarks>
	[TLDef(0x84A02A0D)]
	public class Messages_SavedGifs : IObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></summary>
		public long hash;
		/// <summary>List of saved gifs</summary>
		public DocumentBase[] gifs;
	}

	/// <summary>Represents a sent inline message from the perspective of a bot		<para>Derived classes: <see cref="InputBotInlineMessageMediaAuto"/>, <see cref="InputBotInlineMessageText"/>, <see cref="InputBotInlineMessageMediaGeo"/>, <see cref="InputBotInlineMessageMediaVenue"/>, <see cref="InputBotInlineMessageMediaContact"/>, <see cref="InputBotInlineMessageGame"/>, <see cref="InputBotInlineMessageMediaInvoice"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputBotInlineMessage"/></para></summary>
	public abstract class InputBotInlineMessage : IObject { }
	/// <summary>A media		<para>See <a href="https://corefork.telegram.org/constructor/inputBotInlineMessageMediaAuto"/></para></summary>
	[TLDef(0x3380C786)]
	public class InputBotInlineMessageMediaAuto : InputBotInlineMessage
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Caption</summary>
		public string message;
		/// <summary><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></summary>
		[IfFlag(1)] public MessageEntity[] entities;
		/// <summary>Inline keyboard</summary>
		[IfFlag(2)] public ReplyMarkup reply_markup;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="entities"/> has a value</summary>
			has_entities = 0x2,
			/// <summary>Field <see cref="reply_markup"/> has a value</summary>
			has_reply_markup = 0x4,
		}
	}
	/// <summary>Simple text message		<para>See <a href="https://corefork.telegram.org/constructor/inputBotInlineMessageText"/></para></summary>
	[TLDef(0x3DCD7A87)]
	public class InputBotInlineMessageText : InputBotInlineMessage
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Message</summary>
		public string message;
		/// <summary><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></summary>
		[IfFlag(1)] public MessageEntity[] entities;
		/// <summary>Inline keyboard</summary>
		[IfFlag(2)] public ReplyMarkup reply_markup;

		[Flags] public enum Flags : uint
		{
			/// <summary>Disable webpage preview</summary>
			no_webpage = 0x1,
			/// <summary>Field <see cref="entities"/> has a value</summary>
			has_entities = 0x2,
			/// <summary>Field <see cref="reply_markup"/> has a value</summary>
			has_reply_markup = 0x4,
		}
	}
	/// <summary>Geolocation		<para>See <a href="https://corefork.telegram.org/constructor/inputBotInlineMessageMediaGeo"/></para></summary>
	[TLDef(0x96929A85)]
	public class InputBotInlineMessageMediaGeo : InputBotInlineMessage
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Geolocation</summary>
		public InputGeoPoint geo_point;
		/// <summary>For <a href="https://corefork.telegram.org/api/live-location">live locations</a>, a direction in which the location moves, in degrees; 1-360</summary>
		[IfFlag(0)] public int heading;
		/// <summary>Validity period</summary>
		[IfFlag(1)] public int period;
		/// <summary>For <a href="https://corefork.telegram.org/api/live-location">live locations</a>, a maximum distance to another chat member for proximity alerts, in meters (0-100000)</summary>
		[IfFlag(3)] public int proximity_notification_radius;
		/// <summary>Reply markup for bot/inline keyboards</summary>
		[IfFlag(2)] public ReplyMarkup reply_markup;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="heading"/> has a value</summary>
			has_heading = 0x1,
			/// <summary>Field <see cref="period"/> has a value</summary>
			has_period = 0x2,
			/// <summary>Field <see cref="reply_markup"/> has a value</summary>
			has_reply_markup = 0x4,
			/// <summary>Field <see cref="proximity_notification_radius"/> has a value</summary>
			has_proximity_notification_radius = 0x8,
		}
	}
	/// <summary>Venue		<para>See <a href="https://corefork.telegram.org/constructor/inputBotInlineMessageMediaVenue"/></para></summary>
	[TLDef(0x417BBF11)]
	public class InputBotInlineMessageMediaVenue : InputBotInlineMessage
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Geolocation</summary>
		public InputGeoPoint geo_point;
		/// <summary>Venue name</summary>
		public string title;
		/// <summary>Address</summary>
		public string address;
		/// <summary>Venue provider: currently only "foursquare" needs to be supported</summary>
		public string provider;
		/// <summary>Venue ID in the provider's database</summary>
		public string venue_id;
		/// <summary>Venue type in the provider's database</summary>
		public string venue_type;
		/// <summary>Inline keyboard</summary>
		[IfFlag(2)] public ReplyMarkup reply_markup;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="reply_markup"/> has a value</summary>
			has_reply_markup = 0x4,
		}
	}
	/// <summary>A contact		<para>See <a href="https://corefork.telegram.org/constructor/inputBotInlineMessageMediaContact"/></para></summary>
	[TLDef(0xA6EDBFFD)]
	public class InputBotInlineMessageMediaContact : InputBotInlineMessage
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Phone number</summary>
		public string phone_number;
		/// <summary>First name</summary>
		public string first_name;
		/// <summary>Last name</summary>
		public string last_name;
		/// <summary>VCard info</summary>
		public string vcard;
		/// <summary>Inline keyboard</summary>
		[IfFlag(2)] public ReplyMarkup reply_markup;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="reply_markup"/> has a value</summary>
			has_reply_markup = 0x4,
		}
	}
	/// <summary>A game		<para>See <a href="https://corefork.telegram.org/constructor/inputBotInlineMessageGame"/></para></summary>
	[TLDef(0x4B425864)]
	public class InputBotInlineMessageGame : InputBotInlineMessage
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Inline keyboard</summary>
		[IfFlag(2)] public ReplyMarkup reply_markup;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="reply_markup"/> has a value</summary>
			has_reply_markup = 0x4,
		}
	}
	/// <summary>An invoice		<para>See <a href="https://corefork.telegram.org/constructor/inputBotInlineMessageMediaInvoice"/></para></summary>
	[TLDef(0xD7E78225)]
	public class InputBotInlineMessageMediaInvoice : InputBotInlineMessage
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Product name, 1-32 characters</summary>
		public string title;
		/// <summary>Product description, 1-255 characters</summary>
		public string description;
		/// <summary>Invoice photo</summary>
		[IfFlag(0)] public InputWebDocument photo;
		/// <summary>The invoice</summary>
		public Invoice invoice;
		/// <summary>Bot-defined invoice payload, 1-128 bytes. This will not be displayed to the user, use for your internal processes.</summary>
		public byte[] payload;
		/// <summary>Payments provider token, obtained via <a href="https://t.me/botfather">Botfather</a></summary>
		public string provider;
		/// <summary>A JSON-serialized object for data about the invoice, which will be shared with the payment provider. A detailed description of the required fields should be provided by the payment provider.</summary>
		public DataJSON provider_data;
		/// <summary>Inline keyboard</summary>
		[IfFlag(2)] public ReplyMarkup reply_markup;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="photo"/> has a value</summary>
			has_photo = 0x1,
			/// <summary>Field <see cref="reply_markup"/> has a value</summary>
			has_reply_markup = 0x4,
		}
	}

	/// <summary>Inline bot result		<para>Derived classes: <see cref="InputBotInlineResult"/>, <see cref="InputBotInlineResultPhoto"/>, <see cref="InputBotInlineResultDocument"/>, <see cref="InputBotInlineResultGame"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputBotInlineResult"/></para></summary>
	public abstract class InputBotInlineResultBase : IObject
	{
		/// <summary>ID of result</summary>
		public abstract string ID { get; }
		/// <summary>Message to send when the result is selected</summary>
		public abstract InputBotInlineMessage SendMessage { get; }
	}
	/// <summary>An inline bot result		<para>See <a href="https://corefork.telegram.org/constructor/inputBotInlineResult"/></para></summary>
	[TLDef(0x88BF9319)]
	public class InputBotInlineResult : InputBotInlineResultBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>ID of result</summary>
		public string id;
		/// <summary>Result type (see <a href="https://corefork.telegram.org/bots/api#inlinequeryresult">bot API docs</a>)</summary>
		public string type;
		/// <summary>Result title</summary>
		[IfFlag(1)] public string title;
		/// <summary>Result description</summary>
		[IfFlag(2)] public string description;
		/// <summary>URL of result</summary>
		[IfFlag(3)] public string url;
		/// <summary>Thumbnail for result</summary>
		[IfFlag(4)] public InputWebDocument thumb;
		/// <summary>Result contents</summary>
		[IfFlag(5)] public InputWebDocument content;
		/// <summary>Message to send when the result is selected</summary>
		public InputBotInlineMessage send_message;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="title"/> has a value</summary>
			has_title = 0x2,
			/// <summary>Field <see cref="description"/> has a value</summary>
			has_description = 0x4,
			/// <summary>Field <see cref="url"/> has a value</summary>
			has_url = 0x8,
			/// <summary>Field <see cref="thumb"/> has a value</summary>
			has_thumb = 0x10,
			/// <summary>Field <see cref="content"/> has a value</summary>
			has_content = 0x20,
		}

		/// <summary>ID of result</summary>
		public override string ID => id;
		/// <summary>Message to send when the result is selected</summary>
		public override InputBotInlineMessage SendMessage => send_message;
	}
	/// <summary>Photo		<para>See <a href="https://corefork.telegram.org/constructor/inputBotInlineResultPhoto"/></para></summary>
	[TLDef(0xA8D864A7)]
	public class InputBotInlineResultPhoto : InputBotInlineResultBase
	{
		/// <summary>Result ID</summary>
		public string id;
		/// <summary>Result type (see <a href="https://corefork.telegram.org/bots/api#inlinequeryresult">bot API docs</a>)</summary>
		public string type;
		/// <summary>Photo to send</summary>
		public InputPhoto photo;
		/// <summary>Message to send when the result is selected</summary>
		public InputBotInlineMessage send_message;

		/// <summary>Result ID</summary>
		public override string ID => id;
		/// <summary>Message to send when the result is selected</summary>
		public override InputBotInlineMessage SendMessage => send_message;
	}
	/// <summary>Document (media of any type except for photos)		<para>See <a href="https://corefork.telegram.org/constructor/inputBotInlineResultDocument"/></para></summary>
	[TLDef(0xFFF8FDC4)]
	public class InputBotInlineResultDocument : InputBotInlineResultBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Result ID</summary>
		public string id;
		/// <summary>Result type (see <a href="https://corefork.telegram.org/bots/api#inlinequeryresult">bot API docs</a>)</summary>
		public string type;
		/// <summary>Result title</summary>
		[IfFlag(1)] public string title;
		/// <summary>Result description</summary>
		[IfFlag(2)] public string description;
		/// <summary>Document to send</summary>
		public InputDocument document;
		/// <summary>Message to send when the result is selected</summary>
		public InputBotInlineMessage send_message;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="title"/> has a value</summary>
			has_title = 0x2,
			/// <summary>Field <see cref="description"/> has a value</summary>
			has_description = 0x4,
		}

		/// <summary>Result ID</summary>
		public override string ID => id;
		/// <summary>Message to send when the result is selected</summary>
		public override InputBotInlineMessage SendMessage => send_message;
	}
	/// <summary>Game		<para>See <a href="https://corefork.telegram.org/constructor/inputBotInlineResultGame"/></para></summary>
	[TLDef(0x4FA417F2)]
	public class InputBotInlineResultGame : InputBotInlineResultBase
	{
		/// <summary>Result ID</summary>
		public string id;
		/// <summary>Game short name</summary>
		public string short_name;
		/// <summary>Message to send when the result is selected</summary>
		public InputBotInlineMessage send_message;

		/// <summary>Result ID</summary>
		public override string ID => id;
		/// <summary>Message to send when the result is selected</summary>
		public override InputBotInlineMessage SendMessage => send_message;
	}

	/// <summary>Inline message		<para>Derived classes: <see cref="BotInlineMessageMediaAuto"/>, <see cref="BotInlineMessageText"/>, <see cref="BotInlineMessageMediaGeo"/>, <see cref="BotInlineMessageMediaVenue"/>, <see cref="BotInlineMessageMediaContact"/>, <see cref="BotInlineMessageMediaInvoice"/></para>		<para>See <a href="https://corefork.telegram.org/type/BotInlineMessage"/></para></summary>
	public abstract class BotInlineMessage : IObject { }
	/// <summary>Send whatever media is attached to the <see cref="BotInlineMediaResult"/>		<para>See <a href="https://corefork.telegram.org/constructor/botInlineMessageMediaAuto"/></para></summary>
	[TLDef(0x764CF810)]
	public class BotInlineMessageMediaAuto : BotInlineMessage
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Caption</summary>
		public string message;
		/// <summary><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></summary>
		[IfFlag(1)] public MessageEntity[] entities;
		/// <summary>Inline keyboard</summary>
		[IfFlag(2)] public ReplyMarkup reply_markup;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="entities"/> has a value</summary>
			has_entities = 0x2,
			/// <summary>Field <see cref="reply_markup"/> has a value</summary>
			has_reply_markup = 0x4,
		}
	}
	/// <summary>Send a simple text message		<para>See <a href="https://corefork.telegram.org/constructor/botInlineMessageText"/></para></summary>
	[TLDef(0x8C7F65E2)]
	public class BotInlineMessageText : BotInlineMessage
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The message</summary>
		public string message;
		/// <summary><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></summary>
		[IfFlag(1)] public MessageEntity[] entities;
		/// <summary>Inline keyboard</summary>
		[IfFlag(2)] public ReplyMarkup reply_markup;

		[Flags] public enum Flags : uint
		{
			/// <summary>Disable webpage preview</summary>
			no_webpage = 0x1,
			/// <summary>Field <see cref="entities"/> has a value</summary>
			has_entities = 0x2,
			/// <summary>Field <see cref="reply_markup"/> has a value</summary>
			has_reply_markup = 0x4,
		}
	}
	/// <summary>Send a geolocation		<para>See <a href="https://corefork.telegram.org/constructor/botInlineMessageMediaGeo"/></para></summary>
	[TLDef(0x051846FD)]
	public class BotInlineMessageMediaGeo : BotInlineMessage
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Geolocation</summary>
		public GeoPoint geo;
		/// <summary>For <a href="https://corefork.telegram.org/api/live-location">live locations</a>, a direction in which the location moves, in degrees; 1-360.</summary>
		[IfFlag(0)] public int heading;
		/// <summary>Validity period</summary>
		[IfFlag(1)] public int period;
		/// <summary>For <a href="https://corefork.telegram.org/api/live-location">live locations</a>, a maximum distance to another chat member for proximity alerts, in meters (0-100000).</summary>
		[IfFlag(3)] public int proximity_notification_radius;
		/// <summary>Inline keyboard</summary>
		[IfFlag(2)] public ReplyMarkup reply_markup;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="heading"/> has a value</summary>
			has_heading = 0x1,
			/// <summary>Field <see cref="period"/> has a value</summary>
			has_period = 0x2,
			/// <summary>Field <see cref="reply_markup"/> has a value</summary>
			has_reply_markup = 0x4,
			/// <summary>Field <see cref="proximity_notification_radius"/> has a value</summary>
			has_proximity_notification_radius = 0x8,
		}
	}
	/// <summary>Send a venue		<para>See <a href="https://corefork.telegram.org/constructor/botInlineMessageMediaVenue"/></para></summary>
	[TLDef(0x8A86659C)]
	public class BotInlineMessageMediaVenue : BotInlineMessage
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Geolocation of venue</summary>
		public GeoPoint geo;
		/// <summary>Venue name</summary>
		public string title;
		/// <summary>Address</summary>
		public string address;
		/// <summary>Venue provider: currently only "foursquare" needs to be supported</summary>
		public string provider;
		/// <summary>Venue ID in the provider's database</summary>
		public string venue_id;
		/// <summary>Venue type in the provider's database</summary>
		public string venue_type;
		/// <summary>Inline keyboard</summary>
		[IfFlag(2)] public ReplyMarkup reply_markup;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="reply_markup"/> has a value</summary>
			has_reply_markup = 0x4,
		}
	}
	/// <summary>Send a contact		<para>See <a href="https://corefork.telegram.org/constructor/botInlineMessageMediaContact"/></para></summary>
	[TLDef(0x18D1CDC2)]
	public class BotInlineMessageMediaContact : BotInlineMessage
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Phone number</summary>
		public string phone_number;
		/// <summary>First name</summary>
		public string first_name;
		/// <summary>Last name</summary>
		public string last_name;
		/// <summary>VCard info</summary>
		public string vcard;
		/// <summary>Inline keyboard</summary>
		[IfFlag(2)] public ReplyMarkup reply_markup;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="reply_markup"/> has a value</summary>
			has_reply_markup = 0x4,
		}
	}
	/// <summary>Send an invoice		<para>See <a href="https://corefork.telegram.org/constructor/botInlineMessageMediaInvoice"/></para></summary>
	[TLDef(0x354A9B09)]
	public class BotInlineMessageMediaInvoice : BotInlineMessage
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Product name, 1-32 characters</summary>
		public string title;
		/// <summary>Product description, 1-255 characters</summary>
		public string description;
		/// <summary>Product photo</summary>
		[IfFlag(0)] public WebDocumentBase photo;
		/// <summary>Three-letter ISO 4217 <a href="https://corefork.telegram.org/bots/payments#supported-currencies">currency</a> code</summary>
		public string currency;
		/// <summary>Total price in the smallest units of the currency (integer, not float/double). For example, for a price of <c>US$ 1.45</c> pass <c>amount = 145</c>. See the exp parameter in <a href="https://corefork.telegram.org/bots/payments/currencies.json">currencies.json</a>, it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).</summary>
		public long total_amount;
		/// <summary>Inline keyboard</summary>
		[IfFlag(2)] public ReplyMarkup reply_markup;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="photo"/> has a value</summary>
			has_photo = 0x1,
			/// <summary>Set this flag if you require the user's shipping address to complete the order</summary>
			shipping_address_requested = 0x2,
			/// <summary>Field <see cref="reply_markup"/> has a value</summary>
			has_reply_markup = 0x4,
			/// <summary>Test invoice</summary>
			test = 0x8,
		}
	}

	/// <summary>Results of an inline query		<para>Derived classes: <see cref="BotInlineResult"/>, <see cref="BotInlineMediaResult"/></para>		<para>See <a href="https://corefork.telegram.org/type/BotInlineResult"/></para></summary>
	public abstract class BotInlineResultBase : IObject
	{
		/// <summary>Result ID</summary>
		public abstract string ID { get; }
		/// <summary>Result type (see <a href="https://corefork.telegram.org/bots/api#inlinequeryresult">bot API docs</a>)</summary>
		public abstract string Type { get; }
		/// <summary>Result title</summary>
		public abstract string Title { get; }
		/// <summary>Result description</summary>
		public abstract string Description { get; }
		/// <summary>Message to send</summary>
		public abstract BotInlineMessage SendMessage { get; }
	}
	/// <summary>Generic result		<para>See <a href="https://corefork.telegram.org/constructor/botInlineResult"/></para></summary>
	[TLDef(0x11965F3A)]
	public class BotInlineResult : BotInlineResultBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Result ID</summary>
		public string id;
		/// <summary>Result type (see <a href="https://corefork.telegram.org/bots/api#inlinequeryresult">bot API docs</a>)</summary>
		public string type;
		/// <summary>Result title</summary>
		[IfFlag(1)] public string title;
		/// <summary>Result description</summary>
		[IfFlag(2)] public string description;
		/// <summary>URL of article or webpage</summary>
		[IfFlag(3)] public string url;
		/// <summary>Thumbnail for the result</summary>
		[IfFlag(4)] public WebDocumentBase thumb;
		/// <summary>Content of the result</summary>
		[IfFlag(5)] public WebDocumentBase content;
		/// <summary>Message to send</summary>
		public BotInlineMessage send_message;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="title"/> has a value</summary>
			has_title = 0x2,
			/// <summary>Field <see cref="description"/> has a value</summary>
			has_description = 0x4,
			/// <summary>Field <see cref="url"/> has a value</summary>
			has_url = 0x8,
			/// <summary>Field <see cref="thumb"/> has a value</summary>
			has_thumb = 0x10,
			/// <summary>Field <see cref="content"/> has a value</summary>
			has_content = 0x20,
		}

		/// <summary>Result ID</summary>
		public override string ID => id;
		/// <summary>Result type (see <a href="https://corefork.telegram.org/bots/api#inlinequeryresult">bot API docs</a>)</summary>
		public override string Type => type;
		/// <summary>Result title</summary>
		public override string Title => title;
		/// <summary>Result description</summary>
		public override string Description => description;
		/// <summary>Message to send</summary>
		public override BotInlineMessage SendMessage => send_message;
	}
	/// <summary>Media result		<para>See <a href="https://corefork.telegram.org/constructor/botInlineMediaResult"/></para></summary>
	[TLDef(0x17DB940B)]
	public class BotInlineMediaResult : BotInlineResultBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Result ID</summary>
		public string id;
		/// <summary>Result type (see <a href="https://corefork.telegram.org/bots/api#inlinequeryresult">bot API docs</a>)</summary>
		public string type;
		/// <summary>If type is <c>photo</c>, the photo to send</summary>
		[IfFlag(0)] public PhotoBase photo;
		/// <summary>If type is <c>document</c>, the document to send</summary>
		[IfFlag(1)] public DocumentBase document;
		/// <summary>Result title</summary>
		[IfFlag(2)] public string title;
		/// <summary>Description</summary>
		[IfFlag(3)] public string description;
		/// <summary>Depending on the <c>type</c> and on the <see cref="BotInlineMessage"/>, contains the caption of the media or the content of the message to be sent <strong>instead</strong> of the media</summary>
		public BotInlineMessage send_message;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="photo"/> has a value</summary>
			has_photo = 0x1,
			/// <summary>Field <see cref="document"/> has a value</summary>
			has_document = 0x2,
			/// <summary>Field <see cref="title"/> has a value</summary>
			has_title = 0x4,
			/// <summary>Field <see cref="description"/> has a value</summary>
			has_description = 0x8,
		}

		/// <summary>Result ID</summary>
		public override string ID => id;
		/// <summary>Result type (see <a href="https://corefork.telegram.org/bots/api#inlinequeryresult">bot API docs</a>)</summary>
		public override string Type => type;
		/// <summary>Result title</summary>
		public override string Title => title;
		/// <summary>Description</summary>
		public override string Description => description;
		/// <summary>Depending on the <c>type</c> and on the <see cref="BotInlineMessage"/>, contains the caption of the media or the content of the message to be sent <strong>instead</strong> of the media</summary>
		public override BotInlineMessage SendMessage => send_message;
	}

	/// <summary>Result of a query to an inline bot		<para>See <a href="https://corefork.telegram.org/constructor/messages.botResults"/></para></summary>
	[TLDef(0x947CA848)]
	public class Messages_BotResults : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Query ID</summary>
		public long query_id;
		/// <summary>The next offset to use when navigating through results</summary>
		[IfFlag(1)] public string next_offset;
		/// <summary>Whether the bot requested the user to message them in private</summary>
		[IfFlag(2)] public InlineBotSwitchPM switch_pm;
		/// <summary>The results</summary>
		public BotInlineResultBase[] results;
		/// <summary>Caching validity of the results</summary>
		public DateTime cache_time;
		/// <summary>Users mentioned in the results</summary>
		public Dictionary<long, User> users;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the result is a picture gallery</summary>
			gallery = 0x1,
			/// <summary>Field <see cref="next_offset"/> has a value</summary>
			has_next_offset = 0x2,
			/// <summary>Field <see cref="switch_pm"/> has a value</summary>
			has_switch_pm = 0x4,
		}
	}

	/// <summary>Link to a message in a supergroup/channel		<para>See <a href="https://corefork.telegram.org/constructor/exportedMessageLink"/></para></summary>
	[TLDef(0x5DAB1AF4)]
	public class ExportedMessageLink : IObject
	{
		/// <summary>URL</summary>
		public string link;
		/// <summary>Embed code</summary>
		public string html;
	}

	/// <summary>Info about a forwarded message		<para>See <a href="https://corefork.telegram.org/constructor/messageFwdHeader"/></para></summary>
	[TLDef(0x5F777DCE)]
	public class MessageFwdHeader : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The ID of the user that originally sent the message</summary>
		[IfFlag(0)] public Peer from_id;
		/// <summary>The name of the user that originally sent the message</summary>
		[IfFlag(5)] public string from_name;
		/// <summary>When was the message originally sent</summary>
		public DateTime date;
		/// <summary>ID of the channel message that was forwarded</summary>
		[IfFlag(2)] public int channel_post;
		/// <summary>For channels and if signatures are enabled, author of the channel message</summary>
		[IfFlag(3)] public string post_author;
		/// <summary>Only for messages forwarded to the current user (inputPeerSelf), full info about the user/channel that originally sent the message</summary>
		[IfFlag(4)] public Peer saved_from_peer;
		/// <summary>Only for messages forwarded to the current user (inputPeerSelf), ID of the message that was forwarded from the original user/channel</summary>
		[IfFlag(4)] public int saved_from_msg_id;
		/// <summary>PSA type</summary>
		[IfFlag(6)] public string psa_type;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="from_id"/> has a value</summary>
			has_from_id = 0x1,
			/// <summary>Field <see cref="channel_post"/> has a value</summary>
			has_channel_post = 0x4,
			/// <summary>Field <see cref="post_author"/> has a value</summary>
			has_post_author = 0x8,
			/// <summary>Field <see cref="saved_from_peer"/> has a value</summary>
			has_saved_from_peer = 0x10,
			/// <summary>Field <see cref="from_name"/> has a value</summary>
			has_from_name = 0x20,
			/// <summary>Field <see cref="psa_type"/> has a value</summary>
			has_psa_type = 0x40,
			/// <summary>Whether this message was <a href="https://corefork.telegram.org/api/import">imported from a foreign chat service, click here for more info »</a></summary>
			imported = 0x80,
		}
	}

	/// <summary>Type of verification code that will be sent next if you call the resendCode method		<para>See <a href="https://corefork.telegram.org/type/auth.CodeType"/></para></summary>
	public enum Auth_CodeType : uint
	{
		///<summary>Type of verification code that will be sent next if you call the resendCode method: SMS code</summary>
		Sms = 0x72A3158C,
		///<summary>Type of verification code that will be sent next if you call the resendCode method: SMS code</summary>
		Call = 0x741CD3E3,
		///<summary>Type of verification code that will be sent next if you call the resendCode method: SMS code</summary>
		FlashCall = 0x226CCEFB,
		///<summary>The next time, the authentication code will be delivered via an immediately canceled incoming call, handled manually by the user.</summary>
		MissedCall = 0xD61AD6EE,
	}

	/// <summary>Type of the verification code that was sent		<para>Derived classes: <see cref="Auth_SentCodeTypeApp"/>, <see cref="Auth_SentCodeTypeSms"/>, <see cref="Auth_SentCodeTypeCall"/>, <see cref="Auth_SentCodeTypeFlashCall"/>, <see cref="Auth_SentCodeTypeMissedCall"/></para>		<para>See <a href="https://corefork.telegram.org/type/auth.SentCodeType"/></para></summary>
	public abstract class Auth_SentCodeType : IObject { }
	/// <summary>The code was sent through the telegram app		<para>See <a href="https://corefork.telegram.org/constructor/auth.sentCodeTypeApp"/></para></summary>
	[TLDef(0x3DBB5986)]
	public class Auth_SentCodeTypeApp : Auth_SentCodeType
	{
		/// <summary>Length of the code in bytes</summary>
		public int length;
	}
	/// <summary>The code was sent via SMS		<para>See <a href="https://corefork.telegram.org/constructor/auth.sentCodeTypeSms"/></para></summary>
	[TLDef(0xC000BBA2)]
	public class Auth_SentCodeTypeSms : Auth_SentCodeType
	{
		/// <summary>Length of the code in bytes</summary>
		public int length;
	}
	/// <summary>The code will be sent via a phone call: a synthesized voice will tell the user which verification code to input.		<para>See <a href="https://corefork.telegram.org/constructor/auth.sentCodeTypeCall"/></para></summary>
	[TLDef(0x5353E5A7)]
	public class Auth_SentCodeTypeCall : Auth_SentCodeType
	{
		/// <summary>Length of the verification code</summary>
		public int length;
	}
	/// <summary>The code will be sent via a flash phone call, that will be closed immediately. The phone code will then be the phone number itself, just make sure that the phone number matches the specified pattern.		<para>See <a href="https://corefork.telegram.org/constructor/auth.sentCodeTypeFlashCall"/></para></summary>
	[TLDef(0xAB03C6D9)]
	public class Auth_SentCodeTypeFlashCall : Auth_SentCodeType
	{
		/// <summary><a href="https://corefork.telegram.org/api/pattern">pattern</a> to match</summary>
		public string pattern;
	}
	/// <summary>The code will be sent via a flash phone call, that will be closed immediately. The last digits of the phone number that calls are the code that must be entered manually by the user.		<para>See <a href="https://corefork.telegram.org/constructor/auth.sentCodeTypeMissedCall"/></para></summary>
	[TLDef(0x82006484)]
	public class Auth_SentCodeTypeMissedCall : Auth_SentCodeTypeCall
	{
		/// <summary>Prefix of the phone number from which the call will be made</summary>
		public string prefix;
	}

	/// <summary>Callback answer sent by the bot in response to a button press		<para>See <a href="https://corefork.telegram.org/constructor/messages.botCallbackAnswer"/></para></summary>
	[TLDef(0x36585EA4)]
	public class Messages_BotCallbackAnswer : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Alert to show</summary>
		[IfFlag(0)] public string message;
		/// <summary>URL to open</summary>
		[IfFlag(2)] public string url;
		/// <summary>For how long should this answer be cached</summary>
		public DateTime cache_time;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="message"/> has a value</summary>
			has_message = 0x1,
			/// <summary>Whether an alert should be shown to the user instead of a toast notification</summary>
			alert = 0x2,
			/// <summary>Field <see cref="url"/> has a value</summary>
			has_url_field = 0x4,
			/// <summary>Whether an URL is present</summary>
			has_url = 0x8,
			/// <summary>Whether to show games in WebView or in native UI.</summary>
			native_ui = 0x10,
		}
	}

	/// <summary>Message edit data for media		<para>See <a href="https://corefork.telegram.org/constructor/messages.messageEditData"/></para></summary>
	[TLDef(0x26B5DDE6)]
	public class Messages_MessageEditData : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;

		[Flags] public enum Flags : uint
		{
			/// <summary>Media caption, if the specified media's caption can be edited</summary>
			caption = 0x1,
		}
	}

	/// <summary>Represents a sent inline message from the perspective of a bot		<para>Derived classes: <see cref="InputBotInlineMessageID"/>, <see cref="InputBotInlineMessageID64"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputBotInlineMessageID"/></para></summary>
	public abstract class InputBotInlineMessageIDBase : IObject
	{
		/// <summary>DC ID to use when working with this inline message</summary>
		public abstract int DcId { get; }
		/// <summary>Access hash of message</summary>
		public abstract long AccessHash { get; }
	}
	/// <summary>Represents a sent inline message from the perspective of a bot (legacy constructor)		<para>See <a href="https://corefork.telegram.org/constructor/inputBotInlineMessageID"/></para></summary>
	[TLDef(0x890C3D89)]
	public class InputBotInlineMessageID : InputBotInlineMessageIDBase
	{
		/// <summary>DC ID to use when working with this inline message</summary>
		public int dc_id;
		/// <summary>ID of message, contains both the (32-bit, legacy) owner ID and the message ID, used only for Bot API backwards compatibility with 32-bit user ID.</summary>
		public long id;
		/// <summary>⚠ <b>REQUIRED FIELD</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash">how to obtain it</see><br/>Access hash of message</summary>
		public long access_hash;

		/// <summary>DC ID to use when working with this inline message</summary>
		public override int DcId => dc_id;
		/// <summary>Access hash of message</summary>
		public override long AccessHash => access_hash;
	}
	/// <summary>Represents a sent inline message from the perspective of a bot		<para>See <a href="https://corefork.telegram.org/constructor/inputBotInlineMessageID64"/></para></summary>
	[TLDef(0xB6D915D7)]
	public class InputBotInlineMessageID64 : InputBotInlineMessageIDBase
	{
		/// <summary>DC ID to use when working with this inline message</summary>
		public int dc_id;
		/// <summary>ID of the owner of this message</summary>
		public long owner_id;
		/// <summary>ID of message</summary>
		public int id;
		/// <summary>⚠ <b>REQUIRED FIELD</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash">how to obtain it</see><br/>Access hash of message</summary>
		public long access_hash;

		/// <summary>DC ID to use when working with this inline message</summary>
		public override int DcId => dc_id;
		/// <summary>Access hash of message</summary>
		public override long AccessHash => access_hash;
	}

	/// <summary>The bot requested the user to message them in private		<para>See <a href="https://corefork.telegram.org/constructor/inlineBotSwitchPM"/></para></summary>
	[TLDef(0x3C20629F)]
	public class InlineBotSwitchPM : IObject
	{
		/// <summary>Text for the button that switches the user to a private chat with the bot and sends the bot a start message with the parameter <c>start_parameter</c> (can be empty)</summary>
		public string text;
		/// <summary>The parameter for the <c>/start parameter</c></summary>
		public string start_param;
	}

	/// <summary>Dialog info of multiple peers		<para>See <a href="https://corefork.telegram.org/constructor/messages.peerDialogs"/></para></summary>
	[TLDef(0x3371C354)]
	public partial class Messages_PeerDialogs : IObject, IPeerResolver
	{
		/// <summary>Dialog info</summary>
		public DialogBase[] dialogs;
		/// <summary>Messages mentioned in dialog info</summary>
		public MessageBase[] messages;
		/// <summary>Chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users</summary>
		public Dictionary<long, User> users;
		/// <summary>Current <a href="https://corefork.telegram.org/api/updates">update state of dialog</a></summary>
		public Updates_State state;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}

	/// <summary>Top peer		<para>See <a href="https://corefork.telegram.org/constructor/topPeer"/></para></summary>
	[TLDef(0xEDCDC05B)]
	public class TopPeer : IObject
	{
		/// <summary>Peer</summary>
		public Peer peer;
		/// <summary>Rating as computed in <a href="https://corefork.telegram.org/api/top-rating">top peer rating »</a></summary>
		public double rating;
	}

	/// <summary>Top peer category		<para>See <a href="https://corefork.telegram.org/type/TopPeerCategory"/></para></summary>
	public enum TopPeerCategory : uint
	{
		///<summary>Most used bots</summary>
		BotsPM = 0xAB661B5B,
		///<summary>Most used inline bots</summary>
		BotsInline = 0x148677E2,
		///<summary>Users we've chatted most frequently with</summary>
		Correspondents = 0x0637B7ED,
		///<summary>Often-opened groups and supergroups</summary>
		Groups = 0xBD17A14A,
		///<summary>Most frequently visited channels</summary>
		Channels = 0x161D9628,
		///<summary>Most frequently called users</summary>
		PhoneCalls = 0x1E76A78C,
		///<summary>Users to which the users often forwards messages to</summary>
		ForwardUsers = 0xA8406CA9,
		///<summary>Chats to which the users often forwards messages to</summary>
		ForwardChats = 0xFBEEC0F0,
	}

	/// <summary>Top peer category		<para>See <a href="https://corefork.telegram.org/constructor/topPeerCategoryPeers"/></para></summary>
	[TLDef(0xFB834291)]
	public class TopPeerCategoryPeers : IObject
	{
		/// <summary>Top peer category of peers</summary>
		public TopPeerCategory category;
		/// <summary>Count of peers</summary>
		public int count;
		/// <summary>Peers</summary>
		public TopPeer[] peers;
	}

	/// <summary>Top peers		<para>Derived classes: <see cref="Contacts_TopPeers"/>, <see cref="Contacts_TopPeersDisabled"/></para>		<para>See <a href="https://corefork.telegram.org/type/contacts.TopPeers"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/contacts.topPeersNotModified">contacts.topPeersNotModified</a></remarks>
	public abstract class Contacts_TopPeersBase : IObject { }
	/// <summary>Top peers		<para>See <a href="https://corefork.telegram.org/constructor/contacts.topPeers"/></para></summary>
	[TLDef(0x70B772A8)]
	public class Contacts_TopPeers : Contacts_TopPeersBase, IPeerResolver
	{
		/// <summary>Top peers by top peer category</summary>
		public TopPeerCategoryPeers[] categories;
		/// <summary>Chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users</summary>
		public Dictionary<long, User> users;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}
	/// <summary>Top peers disabled		<para>See <a href="https://corefork.telegram.org/constructor/contacts.topPeersDisabled"/></para></summary>
	[TLDef(0xB52C939D)]
	public class Contacts_TopPeersDisabled : Contacts_TopPeersBase { }

	/// <summary>Represents a message <a href="https://corefork.telegram.org/api/drafts">draft</a>.		<para>Derived classes: <see cref="DraftMessageEmpty"/>, <see cref="DraftMessage"/></para>		<para>See <a href="https://corefork.telegram.org/type/DraftMessage"/></para></summary>
	public abstract class DraftMessageBase : IObject { }
	/// <summary>Empty draft		<para>See <a href="https://corefork.telegram.org/constructor/draftMessageEmpty"/></para></summary>
	[TLDef(0x1B0C841A)]
	public class DraftMessageEmpty : DraftMessageBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>When was the draft last updated</summary>
		[IfFlag(0)] public DateTime date;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="date"/> has a value</summary>
			has_date = 0x1,
		}
	}
	/// <summary>Represents a message <a href="https://corefork.telegram.org/api/drafts">draft</a>.		<para>See <a href="https://corefork.telegram.org/constructor/draftMessage"/></para></summary>
	[TLDef(0xFD8E711F)]
	public class DraftMessage : DraftMessageBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The message this message will reply to</summary>
		[IfFlag(0)] public int reply_to_msg_id;
		/// <summary>The draft</summary>
		public string message;
		/// <summary>Message <a href="https://corefork.telegram.org/api/entities">entities</a> for styled text.</summary>
		[IfFlag(3)] public MessageEntity[] entities;
		/// <summary>Date of last update of the draft.</summary>
		public DateTime date;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="reply_to_msg_id"/> has a value</summary>
			has_reply_to_msg_id = 0x1,
			/// <summary>Whether no webpage preview will be generated</summary>
			no_webpage = 0x2,
			/// <summary>Field <see cref="entities"/> has a value</summary>
			has_entities = 0x8,
		}
	}

	/// <summary>Featured stickers		<para>Derived classes: <see cref="Messages_FeaturedStickersNotModified"/>, <see cref="Messages_FeaturedStickers"/></para>		<para>See <a href="https://corefork.telegram.org/type/messages.FeaturedStickers"/></para></summary>
	public abstract class Messages_FeaturedStickersBase : IObject { }
	/// <summary>Featured stickers haven't changed		<para>See <a href="https://corefork.telegram.org/constructor/messages.featuredStickersNotModified"/></para></summary>
	[TLDef(0xC6DC0C66)]
	public class Messages_FeaturedStickersNotModified : Messages_FeaturedStickersBase
	{
		/// <summary>Total number of featured stickers</summary>
		public int count;
	}
	/// <summary>Featured stickersets		<para>See <a href="https://corefork.telegram.org/constructor/messages.featuredStickers"/></para></summary>
	[TLDef(0x84C02310)]
	public class Messages_FeaturedStickers : Messages_FeaturedStickersBase
	{
		/// <summary><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></summary>
		public long hash;
		/// <summary>Total number of featured stickers</summary>
		public int count;
		/// <summary>Featured stickersets</summary>
		public StickerSetCoveredBase[] sets;
		/// <summary>IDs of new featured stickersets</summary>
		public long[] unread;
	}

	/// <summary>Recently used stickers		<para>See <a href="https://corefork.telegram.org/constructor/messages.recentStickers"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.recentStickersNotModified">messages.recentStickersNotModified</a></remarks>
	[TLDef(0x88D37C56)]
	public class Messages_RecentStickers : IObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></summary>
		public long hash;
		/// <summary>Emojis associated to stickers</summary>
		public StickerPack[] packs;
		/// <summary>Recent stickers</summary>
		public DocumentBase[] stickers;
		/// <summary>When was each sticker last used</summary>
		public int[] dates;
	}

	/// <summary>Archived stickersets		<para>See <a href="https://corefork.telegram.org/constructor/messages.archivedStickers"/></para></summary>
	[TLDef(0x4FCBA9C8)]
	public class Messages_ArchivedStickers : IObject
	{
		/// <summary>Number of archived stickers</summary>
		public int count;
		/// <summary>Archived stickersets</summary>
		public StickerSetCoveredBase[] sets;
	}

	/// <summary>Result of stickerset installation process		<para>Derived classes: <see cref="Messages_StickerSetInstallResultSuccess"/>, <see cref="Messages_StickerSetInstallResultArchive"/></para>		<para>See <a href="https://corefork.telegram.org/type/messages.StickerSetInstallResult"/></para></summary>
	public abstract class Messages_StickerSetInstallResult : IObject { }
	/// <summary>The stickerset was installed successfully		<para>See <a href="https://corefork.telegram.org/constructor/messages.stickerSetInstallResultSuccess"/></para></summary>
	[TLDef(0x38641628)]
	public class Messages_StickerSetInstallResultSuccess : Messages_StickerSetInstallResult { }
	/// <summary>The stickerset was installed, but since there are too many stickersets some were archived		<para>See <a href="https://corefork.telegram.org/constructor/messages.stickerSetInstallResultArchive"/></para></summary>
	[TLDef(0x35E410A8)]
	public class Messages_StickerSetInstallResultArchive : Messages_StickerSetInstallResult
	{
		/// <summary>Archived stickersets</summary>
		public StickerSetCoveredBase[] sets;
	}

	/// <summary>Stickerset, with a specific sticker as preview		<para>Derived classes: <see cref="StickerSetCovered"/>, <see cref="StickerSetMultiCovered"/></para>		<para>See <a href="https://corefork.telegram.org/type/StickerSetCovered"/></para></summary>
	public abstract class StickerSetCoveredBase : IObject
	{
		/// <summary>Stickerset</summary>
		public abstract StickerSet Set { get; }
	}
	/// <summary>Stickerset, with a specific sticker as preview		<para>See <a href="https://corefork.telegram.org/constructor/stickerSetCovered"/></para></summary>
	[TLDef(0x6410A5D2)]
	public class StickerSetCovered : StickerSetCoveredBase
	{
		/// <summary>Stickerset</summary>
		public StickerSet set;
		/// <summary>Preview</summary>
		public DocumentBase cover;

		/// <summary>Stickerset</summary>
		public override StickerSet Set => set;
	}
	/// <summary>Stickerset, with a specific stickers as preview		<para>See <a href="https://corefork.telegram.org/constructor/stickerSetMultiCovered"/></para></summary>
	[TLDef(0x3407E51B)]
	public class StickerSetMultiCovered : StickerSetCoveredBase
	{
		/// <summary>Stickerset</summary>
		public StickerSet set;
		/// <summary>Preview stickers</summary>
		public DocumentBase[] covers;

		/// <summary>Stickerset</summary>
		public override StickerSet Set => set;
	}

	/// <summary>Position on a photo where a mask should be placed		<para>See <a href="https://corefork.telegram.org/constructor/maskCoords"/></para></summary>
	[TLDef(0xAED6DBB2)]
	public class MaskCoords : IObject
	{
		/// <summary>Part of the face, relative to which the mask should be placed</summary>
		public int n;
		/// <summary>Shift by X-axis measured in widths of the mask scaled to the face size, from left to right. (For example, -1.0 will place the mask just to the left of the default mask position)</summary>
		public double x;
		/// <summary>Shift by Y-axis measured in widths of the mask scaled to the face size, from left to right. (For example, -1.0 will place the mask just to the left of the default mask position)</summary>
		public double y;
		/// <summary>Mask scaling coefficient. (For example, 2.0 means a doubled size)</summary>
		public double zoom;
	}

	/// <summary>Represents a media with attached stickers		<para>Derived classes: <see cref="InputStickeredMediaPhoto"/>, <see cref="InputStickeredMediaDocument"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputStickeredMedia"/></para></summary>
	public abstract class InputStickeredMedia : IObject { }
	/// <summary>A photo with stickers attached		<para>See <a href="https://corefork.telegram.org/constructor/inputStickeredMediaPhoto"/></para></summary>
	[TLDef(0x4A992157)]
	public class InputStickeredMediaPhoto : InputStickeredMedia
	{
		/// <summary>The photo</summary>
		public InputPhoto id;
	}
	/// <summary>A document with stickers attached		<para>See <a href="https://corefork.telegram.org/constructor/inputStickeredMediaDocument"/></para></summary>
	[TLDef(0x0438865B)]
	public class InputStickeredMediaDocument : InputStickeredMedia
	{
		/// <summary>The document</summary>
		public InputDocument id;
	}

	/// <summary>Indicates an already sent game		<para>See <a href="https://corefork.telegram.org/constructor/game"/></para></summary>
	[TLDef(0xBDF9653B)]
	public class Game : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>ID of the game</summary>
		public long id;
		/// <summary>Access hash of the game</summary>
		public long access_hash;
		/// <summary>Short name for the game</summary>
		public string short_name;
		/// <summary>Title of the game</summary>
		public string title;
		/// <summary>Game description</summary>
		public string description;
		/// <summary>Game preview</summary>
		public PhotoBase photo;
		/// <summary>Optional attached document</summary>
		[IfFlag(0)] public DocumentBase document;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="document"/> has a value</summary>
			has_document = 0x1,
		}
	}

	/// <summary>A game to send		<para>Derived classes: <see cref="InputGameID"/>, <see cref="InputGameShortName"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputGame"/></para></summary>
	public abstract class InputGame : IObject { }
	/// <summary>Indicates an already sent game		<para>See <a href="https://corefork.telegram.org/constructor/inputGameID"/></para></summary>
	[TLDef(0x032C3E77)]
	public class InputGameID : InputGame
	{
		/// <summary>game ID from <see cref="Game"/> constructor</summary>
		public long id;
		/// <summary>⚠ <b>REQUIRED FIELD</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash">how to obtain it</see><br/>access hash from <see cref="Game"/> constructor</summary>
		public long access_hash;
	}
	/// <summary>Game by short name		<para>See <a href="https://corefork.telegram.org/constructor/inputGameShortName"/></para></summary>
	[TLDef(0xC331E80A)]
	public class InputGameShortName : InputGame
	{
		/// <summary>The bot that provides the game</summary>
		public InputUserBase bot_id;
		/// <summary>The game's short name</summary>
		public string short_name;
	}

	/// <summary>Game highscore		<para>See <a href="https://corefork.telegram.org/constructor/highScore"/></para></summary>
	[TLDef(0x73A379EB)]
	public class HighScore : IObject
	{
		/// <summary>Position in highscore list</summary>
		public int pos;
		/// <summary>User ID</summary>
		public long user_id;
		/// <summary>Score</summary>
		public int score;
	}

	/// <summary>Highscores in a game		<para>See <a href="https://corefork.telegram.org/constructor/messages.highScores"/></para></summary>
	[TLDef(0x9A3BFD99)]
	public class Messages_HighScores : IObject
	{
		/// <summary>Highscores</summary>
		public HighScore[] scores;
		/// <summary>Users, associated to the highscores</summary>
		public Dictionary<long, User> users;
	}

	/// <summary>Rich text		<para>Derived classes: <see cref="TextPlain"/>, <see cref="TextBold"/>, <see cref="TextItalic"/>, <see cref="TextUnderline"/>, <see cref="TextStrike"/>, <see cref="TextFixed"/>, <see cref="TextUrl"/>, <see cref="TextEmail"/>, <see cref="TextConcat"/>, <see cref="TextSubscript"/>, <see cref="TextSuperscript"/>, <see cref="TextMarked"/>, <see cref="TextPhone"/>, <see cref="TextImage"/>, <see cref="TextAnchor"/></para>		<para>See <a href="https://corefork.telegram.org/type/RichText"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/textEmpty">textEmpty</a></remarks>
	public abstract class RichText : IObject { }
	/// <summary>Plain text		<para>See <a href="https://corefork.telegram.org/constructor/textPlain"/></para></summary>
	[TLDef(0x744694E0)]
	public class TextPlain : RichText
	{
		/// <summary>Text</summary>
		public string text;
	}
	/// <summary><strong>Bold</strong> text		<para>See <a href="https://corefork.telegram.org/constructor/textBold"/></para></summary>
	[TLDef(0x6724ABC4)]
	public class TextBold : RichText
	{
		/// <summary>Text</summary>
		public RichText text;
	}
	/// <summary><em>Italic</em> text		<para>See <a href="https://corefork.telegram.org/constructor/textItalic"/></para></summary>
	[TLDef(0xD912A59C)]
	public class TextItalic : RichText
	{
		/// <summary>Text</summary>
		public RichText text;
	}
	/// <summary>Underlined text		<para>See <a href="https://corefork.telegram.org/constructor/textUnderline"/></para></summary>
	[TLDef(0xC12622C4)]
	public class TextUnderline : RichText
	{
		/// <summary>Text</summary>
		public RichText text;
	}
	/// <summary><del>Strikethrough</del> text		<para>See <a href="https://corefork.telegram.org/constructor/textStrike"/></para></summary>
	[TLDef(0x9BF8BB95)]
	public class TextStrike : RichText
	{
		/// <summary>Text</summary>
		public RichText text;
	}
	/// <summary><c>fixed-width</c> rich text		<para>See <a href="https://corefork.telegram.org/constructor/textFixed"/></para></summary>
	[TLDef(0x6C3F19B9)]
	public class TextFixed : RichText
	{
		/// <summary>Text</summary>
		public RichText text;
	}
	/// <summary>Link		<para>See <a href="https://corefork.telegram.org/constructor/textUrl"/></para></summary>
	[TLDef(0x3C2884C1)]
	public class TextUrl : RichText
	{
		/// <summary>Text of link</summary>
		public RichText text;
		/// <summary>Webpage HTTP URL</summary>
		public string url;
		/// <summary>If a preview was already generated for the page, the page ID</summary>
		public long webpage_id;
	}
	/// <summary>Rich text email link		<para>See <a href="https://corefork.telegram.org/constructor/textEmail"/></para></summary>
	[TLDef(0xDE5A0DD6)]
	public class TextEmail : RichText
	{
		/// <summary>Link text</summary>
		public RichText text;
		/// <summary>Email address</summary>
		public string email;
	}
	/// <summary>Concatenation of rich texts		<para>See <a href="https://corefork.telegram.org/constructor/textConcat"/></para></summary>
	[TLDef(0x7E6260D7)]
	public class TextConcat : RichText
	{
		/// <summary>Concatenated rich texts</summary>
		public RichText[] texts;
	}
	/// <summary>Subscript text		<para>See <a href="https://corefork.telegram.org/constructor/textSubscript"/></para></summary>
	[TLDef(0xED6A8504)]
	public class TextSubscript : RichText
	{
		/// <summary>Text</summary>
		public RichText text;
	}
	/// <summary>Superscript text		<para>See <a href="https://corefork.telegram.org/constructor/textSuperscript"/></para></summary>
	[TLDef(0xC7FB5E01)]
	public class TextSuperscript : RichText
	{
		/// <summary>Text</summary>
		public RichText text;
	}
	/// <summary>Highlighted text		<para>See <a href="https://corefork.telegram.org/constructor/textMarked"/></para></summary>
	[TLDef(0x034B8621)]
	public class TextMarked : RichText
	{
		/// <summary>Text</summary>
		public RichText text;
	}
	/// <summary>Rich text linked to a phone number		<para>See <a href="https://corefork.telegram.org/constructor/textPhone"/></para></summary>
	[TLDef(0x1CCB966A)]
	public class TextPhone : RichText
	{
		/// <summary>Text</summary>
		public RichText text;
		/// <summary>Phone number</summary>
		public string phone;
	}
	/// <summary>Inline image		<para>See <a href="https://corefork.telegram.org/constructor/textImage"/></para></summary>
	[TLDef(0x081CCF4F)]
	public class TextImage : RichText
	{
		/// <summary>Document ID</summary>
		public long document_id;
		/// <summary>Width</summary>
		public int w;
		/// <summary>Height</summary>
		public int h;
	}
	/// <summary>Text linking to another section of the page		<para>See <a href="https://corefork.telegram.org/constructor/textAnchor"/></para></summary>
	[TLDef(0x35553762)]
	public class TextAnchor : RichText
	{
		/// <summary>Text</summary>
		public RichText text;
		/// <summary>Section name</summary>
		public string name;
	}

	/// <summary>Represents an <a href="https://instantview.telegram.org">instant view page element</a>		<para>Derived classes: <see cref="PageBlockUnsupported"/>, <see cref="PageBlockTitle"/>, <see cref="PageBlockSubtitle"/>, <see cref="PageBlockAuthorDate"/>, <see cref="PageBlockHeader"/>, <see cref="PageBlockSubheader"/>, <see cref="PageBlockParagraph"/>, <see cref="PageBlockPreformatted"/>, <see cref="PageBlockFooter"/>, <see cref="PageBlockDivider"/>, <see cref="PageBlockAnchor"/>, <see cref="PageBlockList"/>, <see cref="PageBlockBlockquote"/>, <see cref="PageBlockPullquote"/>, <see cref="PageBlockPhoto"/>, <see cref="PageBlockVideo"/>, <see cref="PageBlockCover"/>, <see cref="PageBlockEmbed"/>, <see cref="PageBlockEmbedPost"/>, <see cref="PageBlockCollage"/>, <see cref="PageBlockSlideshow"/>, <see cref="PageBlockChannel"/>, <see cref="PageBlockAudio"/>, <see cref="PageBlockKicker"/>, <see cref="PageBlockTable"/>, <see cref="PageBlockOrderedList"/>, <see cref="PageBlockDetails"/>, <see cref="PageBlockRelatedArticles"/>, <see cref="PageBlockMap"/></para>		<para>See <a href="https://corefork.telegram.org/type/PageBlock"/></para></summary>
	public abstract class PageBlock : IObject { }
	/// <summary>Unsupported IV element		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockUnsupported"/></para></summary>
	[TLDef(0x13567E8A)]
	public class PageBlockUnsupported : PageBlock { }
	/// <summary>Title		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockTitle"/></para></summary>
	[TLDef(0x70ABC3FD)]
	public class PageBlockTitle : PageBlock
	{
		/// <summary>Title</summary>
		public RichText text;
	}
	/// <summary>Subtitle		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockSubtitle"/></para></summary>
	[TLDef(0x8FFA9A1F)]
	public class PageBlockSubtitle : PageBlock
	{
		/// <summary>Text</summary>
		public RichText text;
	}
	/// <summary>Author and date of creation of article		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockAuthorDate"/></para></summary>
	[TLDef(0xBAAFE5E0)]
	public class PageBlockAuthorDate : PageBlock
	{
		/// <summary>Author name</summary>
		public RichText author;
		/// <summary>Date of publication</summary>
		public DateTime published_date;
	}
	/// <summary>Page header		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockHeader"/></para></summary>
	[TLDef(0xBFD064EC)]
	public class PageBlockHeader : PageBlock
	{
		/// <summary>Contents</summary>
		public RichText text;
	}
	/// <summary>Subheader		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockSubheader"/></para></summary>
	[TLDef(0xF12BB6E1)]
	public class PageBlockSubheader : PageBlock
	{
		/// <summary>Subheader</summary>
		public RichText text;
	}
	/// <summary>A paragraph		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockParagraph"/></para></summary>
	[TLDef(0x467A0766)]
	public class PageBlockParagraph : PageBlock
	{
		/// <summary>Text</summary>
		public RichText text;
	}
	/// <summary>Preformatted (<c>&lt;pre&gt;</c> text)		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockPreformatted"/></para></summary>
	[TLDef(0xC070D93E)]
	public class PageBlockPreformatted : PageBlock
	{
		/// <summary>Text</summary>
		public RichText text;
		/// <summary>Programming language of preformatted text</summary>
		public string language;
	}
	/// <summary>Page footer		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockFooter"/></para></summary>
	[TLDef(0x48870999)]
	public class PageBlockFooter : PageBlock
	{
		/// <summary>Contents</summary>
		public RichText text;
	}
	/// <summary>An empty block separating a page		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockDivider"/></para></summary>
	[TLDef(0xDB20B188)]
	public class PageBlockDivider : PageBlock { }
	/// <summary>Link to section within the page itself (like <c>&lt;a href="#target"&gt;anchor&lt;/a&gt;</c>)		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockAnchor"/></para></summary>
	[TLDef(0xCE0D37B0)]
	public class PageBlockAnchor : PageBlock
	{
		/// <summary>Name of target section</summary>
		public string name;
	}
	/// <summary>Unordered list of IV blocks		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockList"/></para></summary>
	[TLDef(0xE4E88011)]
	public class PageBlockList : PageBlock
	{
		/// <summary>List of blocks in an IV page</summary>
		public PageListItem[] items;
	}
	/// <summary>Quote (equivalent to the HTML <c>&lt;blockquote&gt;</c>)		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockBlockquote"/></para></summary>
	[TLDef(0x263D7C26)]
	public class PageBlockBlockquote : PageBlock
	{
		/// <summary>Quote contents</summary>
		public RichText text;
		/// <summary>Caption</summary>
		public RichText caption;
	}
	/// <summary>Pullquote		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockPullquote"/></para></summary>
	[TLDef(0x4F4456D3)]
	public class PageBlockPullquote : PageBlock
	{
		/// <summary>Text</summary>
		public RichText text;
		/// <summary>Caption</summary>
		public RichText caption;
	}
	/// <summary>A photo		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockPhoto"/></para></summary>
	[TLDef(0x1759C560)]
	public class PageBlockPhoto : PageBlock
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Photo ID</summary>
		public long photo_id;
		/// <summary>Caption</summary>
		public PageCaption caption;
		/// <summary>HTTP URL of page the photo leads to when clicked</summary>
		[IfFlag(0)] public string url;
		/// <summary>ID of preview of the page the photo leads to when clicked</summary>
		[IfFlag(0)] public long webpage_id;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="url"/> has a value</summary>
			has_url = 0x1,
		}
	}
	/// <summary>Video		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockVideo"/></para></summary>
	[TLDef(0x7C8FE7B6)]
	public class PageBlockVideo : PageBlock
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Video ID</summary>
		public long video_id;
		/// <summary>Caption</summary>
		public PageCaption caption;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the video is set to autoplay</summary>
			autoplay = 0x1,
			/// <summary>Whether the video is set to loop</summary>
			loop = 0x2,
		}
	}
	/// <summary>A page cover		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockCover"/></para></summary>
	[TLDef(0x39F23300)]
	public class PageBlockCover : PageBlock
	{
		/// <summary>Cover</summary>
		public PageBlock cover;
	}
	/// <summary>An embedded webpage		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockEmbed"/></para></summary>
	[TLDef(0xA8718DC5)]
	public class PageBlockEmbed : PageBlock
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Web page URL, if available</summary>
		[IfFlag(1)] public string url;
		/// <summary>HTML-markup of the embedded page</summary>
		[IfFlag(2)] public string html;
		/// <summary>Poster photo, if available</summary>
		[IfFlag(4)] public long poster_photo_id;
		/// <summary>Block width, if known</summary>
		[IfFlag(5)] public int w;
		/// <summary>Block height, if known</summary>
		[IfFlag(5)] public int h;
		/// <summary>Caption</summary>
		public PageCaption caption;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the block should be full width</summary>
			full_width = 0x1,
			/// <summary>Field <see cref="url"/> has a value</summary>
			has_url = 0x2,
			/// <summary>Field <see cref="html"/> has a value</summary>
			has_html = 0x4,
			/// <summary>Whether scrolling should be allowed</summary>
			allow_scrolling = 0x8,
			/// <summary>Field <see cref="poster_photo_id"/> has a value</summary>
			has_poster_photo_id = 0x10,
			/// <summary>Field <see cref="w"/> has a value</summary>
			has_w = 0x20,
		}
	}
	/// <summary>An embedded post		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockEmbedPost"/></para></summary>
	[TLDef(0xF259A80B)]
	public class PageBlockEmbedPost : PageBlock
	{
		/// <summary>Web page URL</summary>
		public string url;
		/// <summary>ID of generated webpage preview</summary>
		public long webpage_id;
		/// <summary>ID of the author's photo</summary>
		public long author_photo_id;
		/// <summary>Author name</summary>
		public string author;
		/// <summary>Creation date</summary>
		public DateTime date;
		/// <summary>Post contents</summary>
		public PageBlock[] blocks;
		/// <summary>Caption</summary>
		public PageCaption caption;
	}
	/// <summary>Collage of media		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockCollage"/></para></summary>
	[TLDef(0x65A0FA4D)]
	public class PageBlockCollage : PageBlock
	{
		/// <summary>Media elements</summary>
		public PageBlock[] items;
		/// <summary>Caption</summary>
		public PageCaption caption;
	}
	/// <summary>Slideshow		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockSlideshow"/></para></summary>
	[TLDef(0x031F9590)]
	public class PageBlockSlideshow : PageBlock
	{
		/// <summary>Slideshow items</summary>
		public PageBlock[] items;
		/// <summary>Caption</summary>
		public PageCaption caption;
	}
	/// <summary>Reference to a telegram channel		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockChannel"/></para></summary>
	[TLDef(0xEF1751B5)]
	public class PageBlockChannel : PageBlock
	{
		/// <summary>The channel/supergroup/chat</summary>
		public ChatBase channel;
	}
	/// <summary>Audio		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockAudio"/></para></summary>
	[TLDef(0x804361EA)]
	public class PageBlockAudio : PageBlock
	{
		/// <summary>Audio ID (to be fetched from the container <see cref="Page"/> constructor</summary>
		public long audio_id;
		/// <summary>Audio caption</summary>
		public PageCaption caption;
	}
	/// <summary>Kicker		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockKicker"/></para></summary>
	[TLDef(0x1E148390)]
	public class PageBlockKicker : PageBlock
	{
		/// <summary>Contents</summary>
		public RichText text;
	}
	/// <summary>Table		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockTable"/></para></summary>
	[TLDef(0xBF4DEA82)]
	public class PageBlockTable : PageBlock
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Title</summary>
		public RichText title;
		/// <summary>Table rows</summary>
		public PageTableRow[] rows;

		[Flags] public enum Flags : uint
		{
			/// <summary>Does the table have a visible border?</summary>
			bordered = 0x1,
			/// <summary>Is the table striped?</summary>
			striped = 0x2,
		}
	}
	/// <summary>Ordered list of IV blocks		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockOrderedList"/></para></summary>
	[TLDef(0x9A8AE1E1)]
	public class PageBlockOrderedList : PageBlock
	{
		/// <summary>List items</summary>
		public PageListOrderedItem[] items;
	}
	/// <summary>A collapsible details block		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockDetails"/></para></summary>
	[TLDef(0x76768BED)]
	public class PageBlockDetails : PageBlock
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Block contents</summary>
		public PageBlock[] blocks;
		/// <summary>Always visible heading for the block</summary>
		public RichText title;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the block is open by default</summary>
			open = 0x1,
		}
	}
	/// <summary>Related articles		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockRelatedArticles"/></para></summary>
	[TLDef(0x16115A96)]
	public class PageBlockRelatedArticles : PageBlock
	{
		/// <summary>Title</summary>
		public RichText title;
		/// <summary>Related articles</summary>
		public PageRelatedArticle[] articles;
	}
	/// <summary>A map		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockMap"/></para></summary>
	[TLDef(0xA44F3EF6)]
	public class PageBlockMap : PageBlock
	{
		/// <summary>Location of the map center</summary>
		public GeoPoint geo;
		/// <summary>Map zoom level; 13-20</summary>
		public int zoom;
		/// <summary>Map width in pixels before applying scale; 16-102</summary>
		public int w;
		/// <summary>Map height in pixels before applying scale; 16-1024</summary>
		public int h;
		/// <summary>Caption</summary>
		public PageCaption caption;
	}

	/// <summary>Why was the phone call discarded?		<para>See <a href="https://corefork.telegram.org/type/PhoneCallDiscardReason"/></para></summary>
	public enum PhoneCallDiscardReason : uint
	{
		///<summary>The phone call was missed</summary>
		Missed = 0x85E42301,
		///<summary>The phone call was disconnected</summary>
		Disconnect = 0xE095C1A0,
		///<summary>The phone call was ended normally</summary>
		Hangup = 0x57ADC690,
		///<summary>The phone call was discarded because the user is busy in another call</summary>
		Busy = 0xFAF7E8C9,
	}

	/// <summary>Represents a json-encoded object		<para>See <a href="https://corefork.telegram.org/constructor/dataJSON"/></para></summary>
	[TLDef(0x7D748D04)]
	public class DataJSON : IObject
	{
		/// <summary>JSON-encoded object</summary>
		public string data;
	}

	/// <summary>This object represents a portion of the price for goods or services.		<para>See <a href="https://corefork.telegram.org/constructor/labeledPrice"/></para></summary>
	[TLDef(0xCB296BF8)]
	public class LabeledPrice : IObject
	{
		/// <summary>Portion label</summary>
		public string label;
		/// <summary>Price of the product in the smallest units of the currency (integer, not float/double). For example, for a price of <c>US$ 1.45</c> pass <c>amount = 145</c>. See the exp parameter in <a href="https://corefork.telegram.org/bots/payments/currencies.json">currencies.json</a>, it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).</summary>
		public long amount;
	}

	/// <summary>Invoice		<para>See <a href="https://corefork.telegram.org/constructor/invoice"/></para></summary>
	[TLDef(0x0CD886E0)]
	public class Invoice : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Three-letter ISO 4217 <a href="https://corefork.telegram.org/bots/payments#supported-currencies">currency</a> code</summary>
		public string currency;
		/// <summary>Price breakdown, a list of components (e.g. product price, tax, discount, delivery cost, delivery tax, bonus, etc.)</summary>
		public LabeledPrice[] prices;
		/// <summary>The maximum accepted amount for tips in the smallest units of the currency (integer, not float/double). For example, for a price of <c>US$ 1.45</c> pass <c>amount = 145</c>. See the exp parameter in <a href="https://corefork.telegram.org/bots/payments/currencies.json">currencies.json</a>, it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).</summary>
		[IfFlag(8)] public long max_tip_amount;
		/// <summary>A vector of suggested amounts of tips in the <em>smallest units</em> of the currency (integer, not float/double). At most 4 suggested tip amounts can be specified. The suggested tip amounts must be positive, passed in a strictly increased order and must not exceed <c>max_tip_amount</c>.</summary>
		[IfFlag(8)] public long[] suggested_tip_amounts;

		[Flags] public enum Flags : uint
		{
			/// <summary>Test invoice</summary>
			test = 0x1,
			/// <summary>Set this flag if you require the user's full name to complete the order</summary>
			name_requested = 0x2,
			/// <summary>Set this flag if you require the user's phone number to complete the order</summary>
			phone_requested = 0x4,
			/// <summary>Set this flag if you require the user's email address to complete the order</summary>
			email_requested = 0x8,
			/// <summary>Set this flag if you require the user's shipping address to complete the order</summary>
			shipping_address_requested = 0x10,
			/// <summary>Set this flag if the final price depends on the shipping method</summary>
			flexible = 0x20,
			/// <summary>Set this flag if user's phone number should be sent to provider</summary>
			phone_to_provider = 0x40,
			/// <summary>Set this flag if user's email address should be sent to provider</summary>
			email_to_provider = 0x80,
			/// <summary>Field <see cref="max_tip_amount"/> has a value</summary>
			has_max_tip_amount = 0x100,
		}
	}

	/// <summary>Payment identifier		<para>See <a href="https://corefork.telegram.org/constructor/paymentCharge"/></para></summary>
	[TLDef(0xEA02C27E)]
	public class PaymentCharge : IObject
	{
		/// <summary>Telegram payment identifier</summary>
		public string id;
		/// <summary>Provider payment identifier</summary>
		public string provider_charge_id;
	}

	/// <summary>Shipping address		<para>See <a href="https://corefork.telegram.org/constructor/postAddress"/></para></summary>
	[TLDef(0x1E8CAAEB)]
	public class PostAddress : IObject
	{
		/// <summary>First line for the address</summary>
		public string street_line1;
		/// <summary>Second line for the address</summary>
		public string street_line2;
		/// <summary>City</summary>
		public string city;
		/// <summary>State, if applicable (empty otherwise)</summary>
		public string state;
		/// <summary>ISO 3166-1 alpha-2 country code</summary>
		public string country_iso2;
		/// <summary>Address post code</summary>
		public string post_code;
	}

	/// <summary>Order info provided by the user		<para>See <a href="https://corefork.telegram.org/constructor/paymentRequestedInfo"/></para></summary>
	[TLDef(0x909C3F94)]
	public class PaymentRequestedInfo : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>User's full name</summary>
		[IfFlag(0)] public string name;
		/// <summary>User's phone number</summary>
		[IfFlag(1)] public string phone;
		/// <summary>User's email address</summary>
		[IfFlag(2)] public string email;
		/// <summary>User's shipping address</summary>
		[IfFlag(3)] public PostAddress shipping_address;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="name"/> has a value</summary>
			has_name = 0x1,
			/// <summary>Field <see cref="phone"/> has a value</summary>
			has_phone = 0x2,
			/// <summary>Field <see cref="email"/> has a value</summary>
			has_email = 0x4,
			/// <summary>Field <see cref="shipping_address"/> has a value</summary>
			has_shipping_address = 0x8,
		}
	}

	/// <summary>Saved payment credentials		<para>Derived classes: <see cref="PaymentSavedCredentialsCard"/></para>		<para>See <a href="https://corefork.telegram.org/type/PaymentSavedCredentials"/></para></summary>
	public abstract class PaymentSavedCredentials : IObject { }
	/// <summary>Saved credit card		<para>See <a href="https://corefork.telegram.org/constructor/paymentSavedCredentialsCard"/></para></summary>
	[TLDef(0xCDC27A1F)]
	public class PaymentSavedCredentialsCard : PaymentSavedCredentials
	{
		/// <summary>Card ID</summary>
		public string id;
		/// <summary>Title</summary>
		public string title;
	}

	/// <summary>Remote document		<para>Derived classes: <see cref="WebDocument"/>, <see cref="WebDocumentNoProxy"/></para>		<para>See <a href="https://corefork.telegram.org/type/WebDocument"/></para></summary>
	public abstract class WebDocumentBase : IObject
	{
		/// <summary>Document URL</summary>
		public abstract string Url { get; }
		/// <summary>File size</summary>
		public abstract int Size { get; }
		/// <summary>MIME type</summary>
		public abstract string MimeType { get; }
		/// <summary>Attributes for media types</summary>
		public abstract DocumentAttribute[] Attributes { get; }
	}
	/// <summary>Remote document		<para>See <a href="https://corefork.telegram.org/constructor/webDocument"/></para></summary>
	[TLDef(0x1C570ED1)]
	public partial class WebDocument : WebDocumentBase
	{
		/// <summary>Document URL</summary>
		public string url;
		/// <summary>Access hash</summary>
		public long access_hash;
		/// <summary>File size</summary>
		public int size;
		/// <summary>MIME type</summary>
		public string mime_type;
		/// <summary>Attributes for media types</summary>
		public DocumentAttribute[] attributes;

		/// <summary>Document URL</summary>
		public override string Url => url;
		/// <summary>File size</summary>
		public override int Size => size;
		/// <summary>MIME type</summary>
		public override string MimeType => mime_type;
		/// <summary>Attributes for media types</summary>
		public override DocumentAttribute[] Attributes => attributes;
	}
	/// <summary>Remote document that can be downloaded without <a href="https://corefork.telegram.org/api/files">proxying through telegram</a>		<para>See <a href="https://corefork.telegram.org/constructor/webDocumentNoProxy"/></para></summary>
	[TLDef(0xF9C8BCC6)]
	public class WebDocumentNoProxy : WebDocumentBase
	{
		/// <summary>Document URL</summary>
		public string url;
		/// <summary>File size</summary>
		public int size;
		/// <summary>MIME type</summary>
		public string mime_type;
		/// <summary>Attributes for media types</summary>
		public DocumentAttribute[] attributes;

		/// <summary>Document URL</summary>
		public override string Url => url;
		/// <summary>File size</summary>
		public override int Size => size;
		/// <summary>MIME type</summary>
		public override string MimeType => mime_type;
		/// <summary>Attributes for media types</summary>
		public override DocumentAttribute[] Attributes => attributes;
	}

	/// <summary>The document		<para>See <a href="https://corefork.telegram.org/constructor/inputWebDocument"/></para></summary>
	[TLDef(0x9BED434D)]
	public class InputWebDocument : IObject
	{
		/// <summary>Remote document URL to be downloaded using the appropriate <a href="https://corefork.telegram.org/api/files">method</a></summary>
		public string url;
		/// <summary>Remote file size</summary>
		public int size;
		/// <summary>Mime type</summary>
		public string mime_type;
		/// <summary>Attributes for media types</summary>
		public DocumentAttribute[] attributes;
	}

	/// <summary>Location of remote file		<para>Derived classes: <see cref="InputWebFileLocation"/>, <see cref="InputWebFileGeoPointLocation"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputWebFileLocation"/></para></summary>
	public abstract class InputWebFileLocationBase : IObject
	{
		/// <summary>Access hash</summary>
		public abstract long AccessHash { get; }
	}
	/// <summary>Location of a remote HTTP(s) file		<para>See <a href="https://corefork.telegram.org/constructor/inputWebFileLocation"/></para></summary>
	[TLDef(0xC239D686)]
	public class InputWebFileLocation : InputWebFileLocationBase
	{
		/// <summary>HTTP URL of file</summary>
		public string url;
		/// <summary>⚠ <b>REQUIRED FIELD</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash">how to obtain it</see><br/>Access hash</summary>
		public long access_hash;

		/// <summary>Access hash</summary>
		public override long AccessHash => access_hash;
	}
	/// <summary>Geolocation		<para>See <a href="https://corefork.telegram.org/constructor/inputWebFileGeoPointLocation"/></para></summary>
	[TLDef(0x9F2221C9)]
	public class InputWebFileGeoPointLocation : InputWebFileLocationBase
	{
		/// <summary>Geolocation</summary>
		public InputGeoPoint geo_point;
		/// <summary>⚠ <b>REQUIRED FIELD</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash">how to obtain it</see><br/>Access hash</summary>
		public long access_hash;
		/// <summary>Map width in pixels before applying scale; 16-1024</summary>
		public int w;
		/// <summary>Map height in pixels before applying scale; 16-1024</summary>
		public int h;
		/// <summary>Map zoom level; 13-20</summary>
		public int zoom;
		/// <summary>Map scale; 1-3</summary>
		public int scale;

		/// <summary>Access hash</summary>
		public override long AccessHash => access_hash;
	}

	/// <summary>Represents a chunk of an <a href="https://corefork.telegram.org/api/files">HTTP webfile</a> downloaded through telegram's secure MTProto servers		<para>See <a href="https://corefork.telegram.org/constructor/upload.webFile"/></para></summary>
	[TLDef(0x21E753BC)]
	public class Upload_WebFile : IObject
	{
		/// <summary>File size</summary>
		public int size;
		/// <summary>Mime type</summary>
		public string mime_type;
		/// <summary>File type</summary>
		public Storage_FileType file_type;
		/// <summary>Modified time</summary>
		public int mtime;
		/// <summary>Data</summary>
		public byte[] bytes;
	}

	/// <summary>Payment form		<para>See <a href="https://corefork.telegram.org/constructor/payments.paymentForm"/></para></summary>
	[TLDef(0x1694761B)]
	public class Payments_PaymentForm : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Form ID</summary>
		public long form_id;
		/// <summary>Bot ID</summary>
		public long bot_id;
		/// <summary>Invoice</summary>
		public Invoice invoice;
		/// <summary>Payment provider ID.</summary>
		public long provider_id;
		/// <summary>Payment form URL</summary>
		public string url;
		/// <summary>Payment provider name.<br/>One of the following:<br/>- <c>stripe</c></summary>
		[IfFlag(4)] public string native_provider;
		/// <summary>Contains information about the payment provider, if available, to support it natively without the need for opening the URL.<br/>A JSON object that can contain the following fields:<br/><br/>- <c>apple_pay_merchant_id</c>: Apple Pay merchant ID<br/>- <c>google_pay_public_key</c>: Google Pay public key<br/>- <c>need_country</c>: True, if the user country must be provided,<br/>- <c>need_zip</c>: True, if the user ZIP/postal code must be provided,<br/>- <c>need_cardholder_name</c>: True, if the cardholder name must be provided<br/></summary>
		[IfFlag(4)] public DataJSON native_params;
		/// <summary>Saved server-side order information</summary>
		[IfFlag(0)] public PaymentRequestedInfo saved_info;
		/// <summary>Contains information about saved card credentials</summary>
		[IfFlag(1)] public PaymentSavedCredentials saved_credentials;
		/// <summary>Users</summary>
		public Dictionary<long, User> users;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="saved_info"/> has a value</summary>
			has_saved_info = 0x1,
			/// <summary>Field <see cref="saved_credentials"/> has a value</summary>
			has_saved_credentials = 0x2,
			/// <summary>Whether the user can choose to save credentials.</summary>
			can_save_credentials = 0x4,
			/// <summary>Indicates that the user can save payment credentials, but only after setting up a <a href="https://corefork.telegram.org/api/srp">2FA password</a> (currently the account doesn't have a <a href="https://corefork.telegram.org/api/srp">2FA password</a>)</summary>
			password_missing = 0x8,
			/// <summary>Field <see cref="native_provider"/> has a value</summary>
			has_native_provider = 0x10,
		}
	}

	/// <summary>Validated user-provided info		<para>See <a href="https://corefork.telegram.org/constructor/payments.validatedRequestedInfo"/></para></summary>
	[TLDef(0xD1451883)]
	public class Payments_ValidatedRequestedInfo : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>ID</summary>
		[IfFlag(0)] public string id;
		/// <summary>Shipping options</summary>
		[IfFlag(1)] public ShippingOption[] shipping_options;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="id"/> has a value</summary>
			has_id = 0x1,
			/// <summary>Field <see cref="shipping_options"/> has a value</summary>
			has_shipping_options = 0x2,
		}
	}

	/// <summary>Payment result		<para>Derived classes: <see cref="Payments_PaymentResult"/>, <see cref="Payments_PaymentVerificationNeeded"/></para>		<para>See <a href="https://corefork.telegram.org/type/payments.PaymentResult"/></para></summary>
	public abstract class Payments_PaymentResultBase : IObject { }
	/// <summary>Payment result		<para>See <a href="https://corefork.telegram.org/constructor/payments.paymentResult"/></para></summary>
	[TLDef(0x4E5F810D)]
	public class Payments_PaymentResult : Payments_PaymentResultBase
	{
		/// <summary>Info about the payment</summary>
		public UpdatesBase updates;
	}
	/// <summary>Payment was not successful, additional verification is needed		<para>See <a href="https://corefork.telegram.org/constructor/payments.paymentVerificationNeeded"/></para></summary>
	[TLDef(0xD8411139)]
	public class Payments_PaymentVerificationNeeded : Payments_PaymentResultBase
	{
		/// <summary>URL for additional payment credentials verification</summary>
		public string url;
	}

	/// <summary>Receipt		<para>See <a href="https://corefork.telegram.org/constructor/payments.paymentReceipt"/></para></summary>
	[TLDef(0x70C4FE03)]
	public class Payments_PaymentReceipt : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Date of generation</summary>
		public DateTime date;
		/// <summary>Bot ID</summary>
		public long bot_id;
		/// <summary>Provider ID</summary>
		public long provider_id;
		/// <summary>Title</summary>
		public string title;
		/// <summary>Description</summary>
		public string description;
		/// <summary>Photo</summary>
		[IfFlag(2)] public WebDocumentBase photo;
		/// <summary>Invoice</summary>
		public Invoice invoice;
		/// <summary>Info</summary>
		[IfFlag(0)] public PaymentRequestedInfo info;
		/// <summary>Selected shipping option</summary>
		[IfFlag(1)] public ShippingOption shipping;
		/// <summary>Tipped amount</summary>
		[IfFlag(3)] public long tip_amount;
		/// <summary>Three-letter ISO 4217 <a href="https://corefork.telegram.org/bots/payments#supported-currencies">currency</a> code</summary>
		public string currency;
		/// <summary>Total amount in the smallest units of the currency (integer, not float/double). For example, for a price of <c>US$ 1.45</c> pass <c>amount = 145</c>. See the exp parameter in <a href="https://corefork.telegram.org/bots/payments/currencies.json">currencies.json</a>, it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).</summary>
		public long total_amount;
		/// <summary>Payment credential name</summary>
		public string credentials_title;
		/// <summary>Users</summary>
		public Dictionary<long, User> users;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="info"/> has a value</summary>
			has_info = 0x1,
			/// <summary>Field <see cref="shipping"/> has a value</summary>
			has_shipping = 0x2,
			/// <summary>Field <see cref="photo"/> has a value</summary>
			has_photo = 0x4,
			/// <summary>Field <see cref="tip_amount"/> has a value</summary>
			has_tip_amount = 0x8,
		}
	}

	/// <summary>Saved server-side order information		<para>See <a href="https://corefork.telegram.org/constructor/payments.savedInfo"/></para></summary>
	[TLDef(0xFB8FE43C)]
	public class Payments_SavedInfo : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Saved server-side order information</summary>
		[IfFlag(0)] public PaymentRequestedInfo saved_info;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="saved_info"/> has a value</summary>
			has_saved_info = 0x1,
			/// <summary>Whether the user has some saved payment credentials</summary>
			has_saved_credentials = 0x2,
		}
	}

	/// <summary>Payment credentials		<para>Derived classes: <see cref="InputPaymentCredentialsSaved"/>, <see cref="InputPaymentCredentials"/>, <see cref="InputPaymentCredentialsApplePay"/>, <see cref="InputPaymentCredentialsGooglePay"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputPaymentCredentials"/></para></summary>
	public abstract class InputPaymentCredentialsBase : IObject { }
	/// <summary>Saved payment credentials		<para>See <a href="https://corefork.telegram.org/constructor/inputPaymentCredentialsSaved"/></para></summary>
	[TLDef(0xC10EB2CF)]
	public class InputPaymentCredentialsSaved : InputPaymentCredentialsBase
	{
		/// <summary>Credential ID</summary>
		public string id;
		/// <summary>Temporary password</summary>
		public byte[] tmp_password;
	}
	/// <summary>Payment credentials		<para>See <a href="https://corefork.telegram.org/constructor/inputPaymentCredentials"/></para></summary>
	[TLDef(0x3417D728)]
	public class InputPaymentCredentials : InputPaymentCredentialsBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Payment credentials</summary>
		public DataJSON data;

		[Flags] public enum Flags : uint
		{
			/// <summary>Save payment credential for future use</summary>
			save = 0x1,
		}
	}
	/// <summary>Apple pay payment credentials		<para>See <a href="https://corefork.telegram.org/constructor/inputPaymentCredentialsApplePay"/></para></summary>
	[TLDef(0x0AA1C39F)]
	public class InputPaymentCredentialsApplePay : InputPaymentCredentialsBase
	{
		/// <summary>Payment data</summary>
		public DataJSON payment_data;
	}
	/// <summary>Google Pay payment credentials		<para>See <a href="https://corefork.telegram.org/constructor/inputPaymentCredentialsGooglePay"/></para></summary>
	[TLDef(0x8AC32801)]
	public class InputPaymentCredentialsGooglePay : InputPaymentCredentialsBase
	{
		/// <summary>Payment token</summary>
		public DataJSON payment_token;
	}

	/// <summary>Temporary payment password		<para>See <a href="https://corefork.telegram.org/constructor/account.tmpPassword"/></para></summary>
	[TLDef(0xDB64FD34)]
	public class Account_TmpPassword : IObject
	{
		/// <summary>Temporary password</summary>
		public byte[] tmp_password;
		/// <summary>Validity period</summary>
		public DateTime valid_until;
	}

	/// <summary>Shipping option		<para>See <a href="https://corefork.telegram.org/constructor/shippingOption"/></para></summary>
	[TLDef(0xB6213CDF)]
	public class ShippingOption : IObject
	{
		/// <summary>Option ID</summary>
		public string id;
		/// <summary>Title</summary>
		public string title;
		/// <summary>List of price portions</summary>
		public LabeledPrice[] prices;
	}

	/// <summary>Sticker in a stickerset		<para>See <a href="https://corefork.telegram.org/constructor/inputStickerSetItem"/></para></summary>
	[TLDef(0xFFA0A496)]
	public class InputStickerSetItem : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The sticker</summary>
		public InputDocument document;
		/// <summary>Associated emoji</summary>
		public string emoji;
		/// <summary>Coordinates for mask sticker</summary>
		[IfFlag(0)] public MaskCoords mask_coords;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="mask_coords"/> has a value</summary>
			has_mask_coords = 0x1,
		}
	}

	/// <summary>Phone call		<para>See <a href="https://corefork.telegram.org/constructor/inputPhoneCall"/></para></summary>
	[TLDef(0x1E36FDED)]
	public class InputPhoneCall : IObject
	{
		/// <summary>Call ID</summary>
		public long id;
		/// <summary>⚠ <b>REQUIRED FIELD</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash">how to obtain it</see><br/>Access hash</summary>
		public long access_hash;
	}

	/// <summary>Phone call		<para>Derived classes: <see cref="PhoneCallEmpty"/>, <see cref="PhoneCallWaiting"/>, <see cref="PhoneCallRequested"/>, <see cref="PhoneCallAccepted"/>, <see cref="PhoneCall"/>, <see cref="PhoneCallDiscarded"/></para>		<para>See <a href="https://corefork.telegram.org/type/PhoneCall"/></para></summary>
	public abstract class PhoneCallBase : IObject
	{
		/// <summary>Call ID</summary>
		public abstract long ID { get; }
	}
	/// <summary>Empty constructor		<para>See <a href="https://corefork.telegram.org/constructor/phoneCallEmpty"/></para></summary>
	[TLDef(0x5366C915)]
	public class PhoneCallEmpty : PhoneCallBase
	{
		/// <summary>Call ID</summary>
		public long id;

		/// <summary>Call ID</summary>
		public override long ID => id;
	}
	/// <summary>Incoming phone call		<para>See <a href="https://corefork.telegram.org/constructor/phoneCallWaiting"/></para></summary>
	[TLDef(0xC5226F17)]
	public class PhoneCallWaiting : PhoneCallBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Call ID</summary>
		public long id;
		/// <summary>Access hash</summary>
		public long access_hash;
		/// <summary>Date</summary>
		public DateTime date;
		/// <summary>Admin ID</summary>
		public long admin_id;
		/// <summary>Participant ID</summary>
		public long participant_id;
		/// <summary>Phone call protocol info</summary>
		public PhoneCallProtocol protocol;
		/// <summary>When was the phone call received</summary>
		[IfFlag(0)] public DateTime receive_date;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="receive_date"/> has a value</summary>
			has_receive_date = 0x1,
			/// <summary>Is this a video call</summary>
			video = 0x40,
		}

		/// <summary>Call ID</summary>
		public override long ID => id;
	}
	/// <summary>Requested phone call		<para>See <a href="https://corefork.telegram.org/constructor/phoneCallRequested"/></para></summary>
	[TLDef(0x14B0ED0C)]
	public class PhoneCallRequested : PhoneCallBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Phone call ID</summary>
		public long id;
		/// <summary>Access hash</summary>
		public long access_hash;
		/// <summary>When was the phone call created</summary>
		public DateTime date;
		/// <summary>ID of the creator of the phone call</summary>
		public long admin_id;
		/// <summary>ID of the other participant of the phone call</summary>
		public long participant_id;
		/// <summary><a href="https://corefork.telegram.org/api/end-to-end/voice-calls">Parameter for key exchange</a></summary>
		public byte[] g_a_hash;
		/// <summary>Call protocol info to be passed to libtgvoip</summary>
		public PhoneCallProtocol protocol;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether this is a video call</summary>
			video = 0x40,
		}

		/// <summary>Phone call ID</summary>
		public override long ID => id;
	}
	/// <summary>An accepted phone call		<para>See <a href="https://corefork.telegram.org/constructor/phoneCallAccepted"/></para></summary>
	[TLDef(0x3660C311)]
	public class PhoneCallAccepted : PhoneCallBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>ID of accepted phone call</summary>
		public long id;
		/// <summary>Access hash of phone call</summary>
		public long access_hash;
		/// <summary>When was the call accepted</summary>
		public DateTime date;
		/// <summary>ID of the call creator</summary>
		public long admin_id;
		/// <summary>ID of the other user in the call</summary>
		public long participant_id;
		/// <summary>B parameter for <a href="https://corefork.telegram.org/api/end-to-end/voice-calls">secure E2E phone call key exchange</a></summary>
		public byte[] g_b;
		/// <summary>Protocol to use for phone call</summary>
		public PhoneCallProtocol protocol;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether this is a video call</summary>
			video = 0x40,
		}

		/// <summary>ID of accepted phone call</summary>
		public override long ID => id;
	}
	/// <summary>Phone call		<para>See <a href="https://corefork.telegram.org/constructor/phoneCall"/></para></summary>
	[TLDef(0x967F7C67)]
	public class PhoneCall : PhoneCallBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Call ID</summary>
		public long id;
		/// <summary>Access hash</summary>
		public long access_hash;
		/// <summary>Date of creation of the call</summary>
		public DateTime date;
		/// <summary>User ID of the creator of the call</summary>
		public long admin_id;
		/// <summary>User ID of the other participant in the call</summary>
		public long participant_id;
		/// <summary><a href="https://corefork.telegram.org/api/end-to-end/voice-calls">Parameter for key exchange</a></summary>
		public byte[] g_a_or_b;
		/// <summary><a href="https://corefork.telegram.org/api/end-to-end/voice-calls">Key fingerprint</a></summary>
		public long key_fingerprint;
		/// <summary>Call protocol info to be passed to libtgvoip</summary>
		public PhoneCallProtocol protocol;
		/// <summary>List of endpoints the user can connect to to exchange call data</summary>
		public PhoneConnectionBase[] connections;
		/// <summary>When was the call actually started</summary>
		public DateTime start_date;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether P2P connection to the other peer is allowed</summary>
			p2p_allowed = 0x20,
			/// <summary>Whether this is a video call</summary>
			video = 0x40,
		}

		/// <summary>Call ID</summary>
		public override long ID => id;
	}
	/// <summary>Indicates a discarded phone call		<para>See <a href="https://corefork.telegram.org/constructor/phoneCallDiscarded"/></para></summary>
	[TLDef(0x50CA4DE1)]
	public class PhoneCallDiscarded : PhoneCallBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Call ID</summary>
		public long id;
		/// <summary>Why was the phone call discarded</summary>
		[IfFlag(0)] public PhoneCallDiscardReason reason;
		/// <summary>Duration of the phone call in seconds</summary>
		[IfFlag(1)] public int duration;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="reason"/> has a value</summary>
			has_reason = 0x1,
			/// <summary>Field <see cref="duration"/> has a value</summary>
			has_duration = 0x2,
			/// <summary>Whether the server required the user to <a href="https://corefork.telegram.org/method/phone.setCallRating">rate</a> the call</summary>
			need_rating = 0x4,
			/// <summary>Whether the server required the client to <a href="https://corefork.telegram.org/method/phone.saveCallDebug">send</a> the libtgvoip call debug data</summary>
			need_debug = 0x8,
			/// <summary>Whether the call was a video call</summary>
			video = 0x40,
		}

		/// <summary>Call ID</summary>
		public override long ID => id;
	}

	/// <summary>Phone call connection		<para>Derived classes: <see cref="PhoneConnection"/>, <see cref="PhoneConnectionWebrtc"/></para>		<para>See <a href="https://corefork.telegram.org/type/PhoneConnection"/></para></summary>
	public abstract class PhoneConnectionBase : IObject
	{
		/// <summary>Endpoint ID</summary>
		public abstract long ID { get; }
		/// <summary>IP address of endpoint</summary>
		public abstract string Ip { get; }
		/// <summary>IPv6 address of endpoint</summary>
		public abstract string Ipv6 { get; }
		/// <summary>Port ID</summary>
		public abstract int Port { get; }
	}
	/// <summary>Identifies an endpoint that can be used to connect to the other user in a phone call		<para>See <a href="https://corefork.telegram.org/constructor/phoneConnection"/></para></summary>
	[TLDef(0x9CC123C7)]
	public class PhoneConnection : PhoneConnectionBase
	{
		public Flags flags;
		/// <summary>Endpoint ID</summary>
		public long id;
		/// <summary>IP address of endpoint</summary>
		public string ip;
		/// <summary>IPv6 address of endpoint</summary>
		public string ipv6;
		/// <summary>Port ID</summary>
		public int port;
		/// <summary>Our peer tag</summary>
		public byte[] peer_tag;

		[Flags] public enum Flags : uint
		{
			tcp = 0x1,
		}

		/// <summary>Endpoint ID</summary>
		public override long ID => id;
		/// <summary>IP address of endpoint</summary>
		public override string Ip => ip;
		/// <summary>IPv6 address of endpoint</summary>
		public override string Ipv6 => ipv6;
		/// <summary>Port ID</summary>
		public override int Port => port;
	}
	/// <summary>WebRTC connection parameters		<para>See <a href="https://corefork.telegram.org/constructor/phoneConnectionWebrtc"/></para></summary>
	[TLDef(0x635FE375)]
	public class PhoneConnectionWebrtc : PhoneConnectionBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Endpoint ID</summary>
		public long id;
		/// <summary>IP address</summary>
		public string ip;
		/// <summary>IPv6 address</summary>
		public string ipv6;
		/// <summary>Port</summary>
		public int port;
		/// <summary>Username</summary>
		public string username;
		/// <summary>Password</summary>
		public string password;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether this is a TURN endpoint</summary>
			turn = 0x1,
			/// <summary>Whether this is a STUN endpoint</summary>
			stun = 0x2,
		}

		/// <summary>Endpoint ID</summary>
		public override long ID => id;
		/// <summary>IP address</summary>
		public override string Ip => ip;
		/// <summary>IPv6 address</summary>
		public override string Ipv6 => ipv6;
		/// <summary>Port</summary>
		public override int Port => port;
	}

	/// <summary>Protocol info for libtgvoip		<para>See <a href="https://corefork.telegram.org/constructor/phoneCallProtocol"/></para></summary>
	[TLDef(0xFC878FC8)]
	public class PhoneCallProtocol : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Minimum layer for remote libtgvoip</summary>
		public int min_layer;
		/// <summary>Maximum layer for remote libtgvoip</summary>
		public int max_layer;
		/// <summary>When using <a href="https://corefork.telegram.org/method/phone.requestCall">phone.requestCall</a> and <a href="https://corefork.telegram.org/method/phone.acceptCall">phone.acceptCall</a>, specify all library versions supported by the client. <br/>The server will merge and choose the best library version supported by both peers, returning only the best value in the result of the callee's <a href="https://corefork.telegram.org/method/phone.acceptCall">phone.acceptCall</a> and in the <see cref="PhoneCallAccepted"/> update received by the caller.</summary>
		public string[] library_versions;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether to allow P2P connection to the other participant</summary>
			udp_p2p = 0x1,
			/// <summary>Whether to allow connection to the other participants through the reflector servers</summary>
			udp_reflector = 0x2,
		}
	}

	/// <summary>A VoIP phone call		<para>See <a href="https://corefork.telegram.org/constructor/phone.phoneCall"/></para></summary>
	[TLDef(0xEC82E140)]
	public class Phone_PhoneCall : IObject
	{
		/// <summary>The VoIP phone call</summary>
		public PhoneCallBase phone_call;
		/// <summary>VoIP phone call participants</summary>
		public Dictionary<long, User> users;
	}

	/// <summary>Represents the download status of a CDN file		<para>Derived classes: <see cref="Upload_CdnFileReuploadNeeded"/>, <see cref="Upload_CdnFile"/></para>		<para>See <a href="https://corefork.telegram.org/type/upload.CdnFile"/></para></summary>
	public abstract class Upload_CdnFileBase : IObject { }
	/// <summary>The file was cleared from the temporary RAM cache of the <a href="https://corefork.telegram.org/cdn">CDN</a> and has to be re-uploaded.		<para>See <a href="https://corefork.telegram.org/constructor/upload.cdnFileReuploadNeeded"/></para></summary>
	[TLDef(0xEEA8E46E)]
	public class Upload_CdnFileReuploadNeeded : Upload_CdnFileBase
	{
		/// <summary>Request token (see <a href="https://corefork.telegram.org/cdn">CDN</a>)</summary>
		public byte[] request_token;
	}
	/// <summary>Represent a chunk of a <a href="https://corefork.telegram.org/cdn">CDN</a> file.		<para>See <a href="https://corefork.telegram.org/constructor/upload.cdnFile"/></para></summary>
	[TLDef(0xA99FCA4F)]
	public class Upload_CdnFile : Upload_CdnFileBase
	{
		/// <summary>The data</summary>
		public byte[] bytes;
	}

	/// <summary>Public key to use <strong>only</strong> during handshakes to <a href="https://corefork.telegram.org/cdn">CDN</a> DCs.		<para>See <a href="https://corefork.telegram.org/constructor/cdnPublicKey"/></para></summary>
	[TLDef(0xC982EABA)]
	public class CdnPublicKey : IObject
	{
		/// <summary><a href="https://corefork.telegram.org/cdn">CDN DC</a> ID</summary>
		public int dc_id;
		/// <summary>RSA public key</summary>
		public string public_key;
	}

	/// <summary>Configuration for <a href="https://corefork.telegram.org/cdn">CDN</a> file downloads.		<para>See <a href="https://corefork.telegram.org/constructor/cdnConfig"/></para></summary>
	[TLDef(0x5725E40A)]
	public class CdnConfig : IObject
	{
		/// <summary>Vector of public keys to use <strong>only</strong> during handshakes to <a href="https://corefork.telegram.org/cdn">CDN</a> DCs.</summary>
		public CdnPublicKey[] public_keys;
	}

	/// <summary>Language pack string		<para>Derived classes: <see cref="LangPackString"/>, <see cref="LangPackStringPluralized"/>, <see cref="LangPackStringDeleted"/></para>		<para>See <a href="https://corefork.telegram.org/type/LangPackString"/></para></summary>
	public abstract class LangPackStringBase : IObject
	{
		/// <summary>Language key</summary>
		public abstract string Key { get; }
	}
	/// <summary>Translated localization string		<para>See <a href="https://corefork.telegram.org/constructor/langPackString"/></para></summary>
	[TLDef(0xCAD181F6)]
	public class LangPackString : LangPackStringBase
	{
		/// <summary>Language key</summary>
		public string key;
		/// <summary>Value</summary>
		public string value;

		/// <summary>Language key</summary>
		public override string Key => key;
	}
	/// <summary>A language pack string which has different forms based on the number of some object it mentions. See <a href="https://www.unicode.org/cldr/charts/latest/supplemental/language_plural_rules.html">https://www.unicode.org/cldr/charts/latest/supplemental/language_plural_rules.html</a> for more info		<para>See <a href="https://corefork.telegram.org/constructor/langPackStringPluralized"/></para></summary>
	[TLDef(0x6C47AC9F)]
	public class LangPackStringPluralized : LangPackStringBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Localization key</summary>
		public string key;
		/// <summary>Value for zero objects</summary>
		[IfFlag(0)] public string zero_value;
		/// <summary>Value for one object</summary>
		[IfFlag(1)] public string one_value;
		/// <summary>Value for two objects</summary>
		[IfFlag(2)] public string two_value;
		/// <summary>Value for a few objects</summary>
		[IfFlag(3)] public string few_value;
		/// <summary>Value for many objects</summary>
		[IfFlag(4)] public string many_value;
		/// <summary>Default value</summary>
		public string other_value;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="zero_value"/> has a value</summary>
			has_zero_value = 0x1,
			/// <summary>Field <see cref="one_value"/> has a value</summary>
			has_one_value = 0x2,
			/// <summary>Field <see cref="two_value"/> has a value</summary>
			has_two_value = 0x4,
			/// <summary>Field <see cref="few_value"/> has a value</summary>
			has_few_value = 0x8,
			/// <summary>Field <see cref="many_value"/> has a value</summary>
			has_many_value = 0x10,
		}

		/// <summary>Localization key</summary>
		public override string Key => key;
	}
	/// <summary>Deleted localization string		<para>See <a href="https://corefork.telegram.org/constructor/langPackStringDeleted"/></para></summary>
	[TLDef(0x2979EEB2)]
	public class LangPackStringDeleted : LangPackStringBase
	{
		/// <summary>Localization key</summary>
		public string key;

		/// <summary>Localization key</summary>
		public override string Key => key;
	}

	/// <summary>Changes to the app's localization pack		<para>See <a href="https://corefork.telegram.org/constructor/langPackDifference"/></para></summary>
	[TLDef(0xF385C1F6)]
	public class LangPackDifference : IObject
	{
		/// <summary>Language code</summary>
		public string lang_code;
		/// <summary>Previous version number</summary>
		public int from_version;
		/// <summary>New version number</summary>
		public int version;
		/// <summary>Localized strings</summary>
		public LangPackStringBase[] strings;
	}

	/// <summary>Identifies a localization pack		<para>See <a href="https://corefork.telegram.org/constructor/langPackLanguage"/></para></summary>
	[TLDef(0xEECA5CE3)]
	public class LangPackLanguage : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Language name</summary>
		public string name;
		/// <summary>Language name in the language itself</summary>
		public string native_name;
		/// <summary>Language code (pack identifier)</summary>
		public string lang_code;
		/// <summary>Identifier of a base language pack; may be empty. If a string is missed in the language pack, then it should be fetched from base language pack. Unsupported in custom language packs</summary>
		[IfFlag(1)] public string base_lang_code;
		/// <summary>A language code to be used to apply plural forms. See <a href="https://www.unicode.org/cldr/charts/latest/supplemental/language_plural_rules.html">https://www.unicode.org/cldr/charts/latest/supplemental/language_plural_rules.html</a> for more info</summary>
		public string plural_code;
		/// <summary>Total number of non-deleted strings from the language pack</summary>
		public int strings_count;
		/// <summary>Total number of translated strings from the language pack</summary>
		public int translated_count;
		/// <summary>Link to language translation interface; empty for custom local language packs</summary>
		public string translations_url;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the language pack is official</summary>
			official = 0x1,
			/// <summary>Field <see cref="base_lang_code"/> has a value</summary>
			has_base_lang_code = 0x2,
			/// <summary>Is this a localization pack for an RTL language</summary>
			rtl = 0x4,
			/// <summary>Is this a beta localization pack?</summary>
			beta = 0x8,
		}
	}

	/// <summary>Channel admin log event		<para>Derived classes: <see cref="ChannelAdminLogEventActionChangeTitle"/>, <see cref="ChannelAdminLogEventActionChangeAbout"/>, <see cref="ChannelAdminLogEventActionChangeUsername"/>, <see cref="ChannelAdminLogEventActionChangePhoto"/>, <see cref="ChannelAdminLogEventActionToggleInvites"/>, <see cref="ChannelAdminLogEventActionToggleSignatures"/>, <see cref="ChannelAdminLogEventActionUpdatePinned"/>, <see cref="ChannelAdminLogEventActionEditMessage"/>, <see cref="ChannelAdminLogEventActionDeleteMessage"/>, <see cref="ChannelAdminLogEventActionParticipantJoin"/>, <see cref="ChannelAdminLogEventActionParticipantLeave"/>, <see cref="ChannelAdminLogEventActionParticipantInvite"/>, <see cref="ChannelAdminLogEventActionParticipantToggleBan"/>, <see cref="ChannelAdminLogEventActionParticipantToggleAdmin"/>, <see cref="ChannelAdminLogEventActionChangeStickerSet"/>, <see cref="ChannelAdminLogEventActionTogglePreHistoryHidden"/>, <see cref="ChannelAdminLogEventActionDefaultBannedRights"/>, <see cref="ChannelAdminLogEventActionStopPoll"/>, <see cref="ChannelAdminLogEventActionChangeLinkedChat"/>, <see cref="ChannelAdminLogEventActionChangeLocation"/>, <see cref="ChannelAdminLogEventActionToggleSlowMode"/>, <see cref="ChannelAdminLogEventActionStartGroupCall"/>, <see cref="ChannelAdminLogEventActionDiscardGroupCall"/>, <see cref="ChannelAdminLogEventActionParticipantMute"/>, <see cref="ChannelAdminLogEventActionParticipantUnmute"/>, <see cref="ChannelAdminLogEventActionToggleGroupCallSetting"/>, <see cref="ChannelAdminLogEventActionParticipantJoinByInvite"/>, <see cref="ChannelAdminLogEventActionExportedInviteDelete"/>, <see cref="ChannelAdminLogEventActionExportedInviteRevoke"/>, <see cref="ChannelAdminLogEventActionExportedInviteEdit"/>, <see cref="ChannelAdminLogEventActionParticipantVolume"/>, <see cref="ChannelAdminLogEventActionChangeHistoryTTL"/>, <see cref="ChannelAdminLogEventActionParticipantJoinByRequest"/>, <see cref="ChannelAdminLogEventActionToggleNoForwards"/>, <see cref="ChannelAdminLogEventActionSendMessage"/>, <see cref="ChannelAdminLogEventActionChangeAvailableReactions"/></para>		<para>See <a href="https://corefork.telegram.org/type/ChannelAdminLogEventAction"/></para></summary>
	public abstract class ChannelAdminLogEventAction : IObject { }
	/// <summary>Channel/supergroup title was changed		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangeTitle"/></para></summary>
	[TLDef(0xE6DFB825)]
	public class ChannelAdminLogEventActionChangeTitle : ChannelAdminLogEventAction
	{
		/// <summary>Previous title</summary>
		public string prev_value;
		/// <summary>New title</summary>
		public string new_value;
	}
	/// <summary>The description was changed		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangeAbout"/></para></summary>
	[TLDef(0x55188A2E)]
	public class ChannelAdminLogEventActionChangeAbout : ChannelAdminLogEventAction
	{
		/// <summary>Previous description</summary>
		public string prev_value;
		/// <summary>New description</summary>
		public string new_value;
	}
	/// <summary>Channel/supergroup username was changed		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangeUsername"/></para></summary>
	[TLDef(0x6A4AFC38)]
	public class ChannelAdminLogEventActionChangeUsername : ChannelAdminLogEventAction
	{
		/// <summary>Old username</summary>
		public string prev_value;
		/// <summary>New username</summary>
		public string new_value;
	}
	/// <summary>The channel/supergroup's picture was changed		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangePhoto"/></para></summary>
	[TLDef(0x434BD2AF)]
	public class ChannelAdminLogEventActionChangePhoto : ChannelAdminLogEventAction
	{
		/// <summary>Previous picture</summary>
		public PhotoBase prev_photo;
		/// <summary>New picture</summary>
		public PhotoBase new_photo;
	}
	/// <summary>Invites were enabled/disabled		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionToggleInvites"/></para></summary>
	[TLDef(0x1B7907AE)]
	public class ChannelAdminLogEventActionToggleInvites : ChannelAdminLogEventAction
	{
		/// <summary>New value</summary>
		public bool new_value;
	}
	/// <summary>Channel signatures were enabled/disabled		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionToggleSignatures"/></para></summary>
	[TLDef(0x26AE0971)]
	public class ChannelAdminLogEventActionToggleSignatures : ChannelAdminLogEventAction
	{
		/// <summary>New value</summary>
		public bool new_value;
	}
	/// <summary>A message was pinned		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionUpdatePinned"/></para></summary>
	[TLDef(0xE9E82C18)]
	public class ChannelAdminLogEventActionUpdatePinned : ChannelAdminLogEventAction
	{
		/// <summary>The message that was pinned</summary>
		public MessageBase message;
	}
	/// <summary>A message was edited		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionEditMessage"/></para></summary>
	[TLDef(0x709B2405)]
	public class ChannelAdminLogEventActionEditMessage : ChannelAdminLogEventAction
	{
		/// <summary>Old message</summary>
		public MessageBase prev_message;
		/// <summary>New message</summary>
		public MessageBase new_message;
	}
	/// <summary>A message was deleted		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionDeleteMessage"/></para></summary>
	[TLDef(0x42E047BB)]
	public class ChannelAdminLogEventActionDeleteMessage : ChannelAdminLogEventAction
	{
		/// <summary>The message that was deleted</summary>
		public MessageBase message;
	}
	/// <summary>A user has joined the group (in the case of big groups, info of the user that has joined isn't shown)		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantJoin"/></para></summary>
	[TLDef(0x183040D3)]
	public class ChannelAdminLogEventActionParticipantJoin : ChannelAdminLogEventAction { }
	/// <summary>A user left the channel/supergroup (in the case of big groups, info of the user that has joined isn't shown)		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantLeave"/></para></summary>
	[TLDef(0xF89777F2)]
	public class ChannelAdminLogEventActionParticipantLeave : ChannelAdminLogEventAction { }
	/// <summary>A user was invited to the group		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantInvite"/></para></summary>
	[TLDef(0xE31C34D8)]
	public class ChannelAdminLogEventActionParticipantInvite : ChannelAdminLogEventAction
	{
		/// <summary>The user that was invited</summary>
		public ChannelParticipantBase participant;
	}
	/// <summary>The banned <a href="https://corefork.telegram.org/api/rights">rights</a> of a user were changed		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantToggleBan"/></para></summary>
	[TLDef(0xE6D83D7E)]
	public class ChannelAdminLogEventActionParticipantToggleBan : ChannelAdminLogEventAction
	{
		/// <summary>Old banned rights of user</summary>
		public ChannelParticipantBase prev_participant;
		/// <summary>New banned rights of user</summary>
		public ChannelParticipantBase new_participant;
	}
	/// <summary>The admin <a href="https://corefork.telegram.org/api/rights">rights</a> of a user were changed		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantToggleAdmin"/></para></summary>
	[TLDef(0xD5676710)]
	public class ChannelAdminLogEventActionParticipantToggleAdmin : ChannelAdminLogEventAction
	{
		/// <summary>Previous admin rights</summary>
		public ChannelParticipantBase prev_participant;
		/// <summary>New admin rights</summary>
		public ChannelParticipantBase new_participant;
	}
	/// <summary>The supergroup's stickerset was changed		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangeStickerSet"/></para></summary>
	[TLDef(0xB1C3CAA7)]
	public class ChannelAdminLogEventActionChangeStickerSet : ChannelAdminLogEventAction
	{
		/// <summary>Previous stickerset</summary>
		public InputStickerSet prev_stickerset;
		/// <summary>New stickerset</summary>
		public InputStickerSet new_stickerset;
	}
	/// <summary>The hidden prehistory setting was <a href="https://corefork.telegram.org/method/channels.togglePreHistoryHidden">changed</a>		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionTogglePreHistoryHidden"/></para></summary>
	[TLDef(0x5F5C95F1)]
	public class ChannelAdminLogEventActionTogglePreHistoryHidden : ChannelAdminLogEventAction
	{
		/// <summary>New value</summary>
		public bool new_value;
	}
	/// <summary>The default banned rights were modified		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionDefaultBannedRights"/></para></summary>
	[TLDef(0x2DF5FC0A)]
	public class ChannelAdminLogEventActionDefaultBannedRights : ChannelAdminLogEventAction
	{
		/// <summary>Previous global <a href="https://corefork.telegram.org/api/rights">banned rights</a></summary>
		public ChatBannedRights prev_banned_rights;
		/// <summary>New global <a href="https://corefork.telegram.org/api/rights">banned rights</a>.</summary>
		public ChatBannedRights new_banned_rights;
	}
	/// <summary>A poll was stopped		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionStopPoll"/></para></summary>
	[TLDef(0x8F079643)]
	public class ChannelAdminLogEventActionStopPoll : ChannelAdminLogEventAction
	{
		/// <summary>The poll that was stopped</summary>
		public MessageBase message;
	}
	/// <summary>The linked chat was changed		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangeLinkedChat"/></para></summary>
	[TLDef(0x050C7AC8)]
	public class ChannelAdminLogEventActionChangeLinkedChat : ChannelAdminLogEventAction
	{
		/// <summary>Previous linked chat</summary>
		public long prev_value;
		/// <summary>New linked chat</summary>
		public long new_value;
	}
	/// <summary>The geogroup location was changed		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangeLocation"/></para></summary>
	[TLDef(0x0E6B76AE)]
	public class ChannelAdminLogEventActionChangeLocation : ChannelAdminLogEventAction
	{
		/// <summary>Previous location</summary>
		public ChannelLocation prev_value;
		/// <summary>New location</summary>
		public ChannelLocation new_value;
	}
	/// <summary><a href="https://corefork.telegram.org/method/channels.toggleSlowMode">Slow mode setting for supergroups was changed</a>		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionToggleSlowMode"/></para></summary>
	[TLDef(0x53909779)]
	public class ChannelAdminLogEventActionToggleSlowMode : ChannelAdminLogEventAction
	{
		/// <summary>Previous slow mode value</summary>
		public int prev_value;
		/// <summary>New slow mode value</summary>
		public int new_value;
	}
	/// <summary>A group call was started		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionStartGroupCall"/></para></summary>
	[TLDef(0x23209745)]
	public class ChannelAdminLogEventActionStartGroupCall : ChannelAdminLogEventAction
	{
		/// <summary>Group call</summary>
		public InputGroupCall call;
	}
	/// <summary>A group call was terminated		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionDiscardGroupCall"/></para></summary>
	[TLDef(0xDB9F9140)]
	public class ChannelAdminLogEventActionDiscardGroupCall : ChannelAdminLogEventAction
	{
		/// <summary>The group call that was terminated</summary>
		public InputGroupCall call;
	}
	/// <summary>A group call participant was muted		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantMute"/></para></summary>
	[TLDef(0xF92424D2)]
	public class ChannelAdminLogEventActionParticipantMute : ChannelAdminLogEventAction
	{
		/// <summary>The participant that was muted</summary>
		public GroupCallParticipant participant;
	}
	/// <summary>A group call participant was unmuted		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantUnmute"/></para></summary>
	[TLDef(0xE64429C0)]
	public class ChannelAdminLogEventActionParticipantUnmute : ChannelAdminLogEventAction
	{
		/// <summary>The participant that was unmuted</summary>
		public GroupCallParticipant participant;
	}
	/// <summary>Group call settings were changed		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionToggleGroupCallSetting"/></para></summary>
	[TLDef(0x56D6A247)]
	public class ChannelAdminLogEventActionToggleGroupCallSetting : ChannelAdminLogEventAction
	{
		/// <summary>Whether all users are muted by default upon joining</summary>
		public bool join_muted;
	}
	/// <summary>A user joined the <a href="https://corefork.telegram.org/api/channel">supergroup/channel</a> using a specific invite link		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantJoinByInvite"/></para></summary>
	[TLDef(0x5CDADA77)]
	public class ChannelAdminLogEventActionParticipantJoinByInvite : ChannelAdminLogEventAction
	{
		/// <summary>The invite link used to join the <a href="https://corefork.telegram.org/api/channel">supergroup/channel</a></summary>
		public ExportedChatInvite invite;
	}
	/// <summary>A chat invite was deleted		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionExportedInviteDelete"/></para></summary>
	[TLDef(0x5A50FCA4)]
	public class ChannelAdminLogEventActionExportedInviteDelete : ChannelAdminLogEventAction
	{
		/// <summary>The deleted chat invite</summary>
		public ExportedChatInvite invite;
	}
	/// <summary>A specific invite link was revoked		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionExportedInviteRevoke"/></para></summary>
	[TLDef(0x410A134E)]
	public class ChannelAdminLogEventActionExportedInviteRevoke : ChannelAdminLogEventAction
	{
		/// <summary>The invite link that was revoked</summary>
		public ExportedChatInvite invite;
	}
	/// <summary>A chat invite was edited		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionExportedInviteEdit"/></para></summary>
	[TLDef(0xE90EBB59)]
	public class ChannelAdminLogEventActionExportedInviteEdit : ChannelAdminLogEventAction
	{
		/// <summary>Previous chat invite information</summary>
		public ExportedChatInvite prev_invite;
		/// <summary>New chat invite information</summary>
		public ExportedChatInvite new_invite;
	}
	/// <summary>channelAdminLogEvent.user_id has set the volume of participant.peer to participant.volume		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantVolume"/></para></summary>
	[TLDef(0x3E7F6847)]
	public class ChannelAdminLogEventActionParticipantVolume : ChannelAdminLogEventAction
	{
		/// <summary>The participant whose volume was changed</summary>
		public GroupCallParticipant participant;
	}
	/// <summary>The Time-To-Live of messages in this chat was changed		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangeHistoryTTL"/></para></summary>
	[TLDef(0x6E941A38)]
	public class ChannelAdminLogEventActionChangeHistoryTTL : ChannelAdminLogEventAction
	{
		/// <summary>Previous value</summary>
		public int prev_value;
		/// <summary>New value</summary>
		public int new_value;
	}
	/// <summary>A new member was accepted to the chat by an admin		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantJoinByRequest"/></para></summary>
	[TLDef(0xAFB6144A)]
	public class ChannelAdminLogEventActionParticipantJoinByRequest : ChannelAdminLogEventAction
	{
		/// <summary>The invite link that was used to join the chat</summary>
		public ExportedChatInvite invite;
		/// <summary>ID of the admin that approved the invite</summary>
		public long approved_by;
	}
	/// <summary>Forwards were enabled or disabled		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionToggleNoForwards"/></para></summary>
	[TLDef(0xCB2AC766)]
	public class ChannelAdminLogEventActionToggleNoForwards : ChannelAdminLogEventAction
	{
		/// <summary>Old value</summary>
		public bool new_value;
	}
	/// <summary>A message was posted in a channel		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionSendMessage"/></para></summary>
	[TLDef(0x278F2868)]
	public class ChannelAdminLogEventActionSendMessage : ChannelAdminLogEventAction
	{
		/// <summary>The message that was sent</summary>
		public MessageBase message;
	}
	/// <summary>The set of allowed <a href="https://corefork.telegram.org/api/reactions">message reactions »</a> for this channel has changed		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangeAvailableReactions"/></para></summary>
	[TLDef(0x9CF7F76A)]
	public class ChannelAdminLogEventActionChangeAvailableReactions : ChannelAdminLogEventAction
	{
		/// <summary>Previously allowed reaction emojis</summary>
		public string[] prev_value;
		/// <summary>New allowed reaction emojis</summary>
		public string[] new_value;
	}

	/// <summary>Admin log event		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEvent"/></para></summary>
	[TLDef(0x1FAD68CD)]
	public class ChannelAdminLogEvent : IObject
	{
		/// <summary>Event ID</summary>
		public long id;
		/// <summary>Date</summary>
		public DateTime date;
		/// <summary>User ID</summary>
		public long user_id;
		/// <summary>Action</summary>
		public ChannelAdminLogEventAction action;
	}

	/// <summary>Admin log events		<para>See <a href="https://corefork.telegram.org/constructor/channels.adminLogResults"/></para></summary>
	[TLDef(0xED8AF74D)]
	public class Channels_AdminLogResults : IObject, IPeerResolver
	{
		/// <summary>Admin log events</summary>
		public ChannelAdminLogEvent[] events;
		/// <summary>Chats mentioned in events</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users mentioned in events</summary>
		public Dictionary<long, User> users;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}

	/// <summary>Filter only certain admin log events		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventsFilter"/></para></summary>
	[TLDef(0xEA107AE4)]
	public class ChannelAdminLogEventsFilter : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;

		[Flags] public enum Flags : uint
		{
			/// <summary><see cref="ChannelAdminLogEventActionParticipantJoin"/></summary>
			join = 0x1,
			/// <summary><see cref="ChannelAdminLogEventActionParticipantLeave"/></summary>
			leave = 0x2,
			/// <summary><see cref="ChannelAdminLogEventActionParticipantInvite"/></summary>
			invite = 0x4,
			/// <summary><see cref="ChannelAdminLogEventActionParticipantToggleBan"/></summary>
			ban = 0x8,
			/// <summary><see cref="ChannelAdminLogEventActionParticipantToggleBan"/></summary>
			unban = 0x10,
			/// <summary><see cref="ChannelAdminLogEventActionParticipantToggleBan"/></summary>
			kick = 0x20,
			/// <summary><see cref="ChannelAdminLogEventActionParticipantToggleBan"/></summary>
			unkick = 0x40,
			/// <summary><see cref="ChannelAdminLogEventActionParticipantToggleAdmin"/></summary>
			promote = 0x80,
			/// <summary><see cref="ChannelAdminLogEventActionParticipantToggleAdmin"/></summary>
			demote = 0x100,
			/// <summary>Info change events (when <see cref="ChannelAdminLogEventActionChangeAbout"/>, <see cref="ChannelAdminLogEventActionChangeLinkedChat"/>, <see cref="ChannelAdminLogEventActionChangeLocation"/>, <see cref="ChannelAdminLogEventActionChangePhoto"/>, <see cref="ChannelAdminLogEventActionChangeStickerSet"/>, <see cref="ChannelAdminLogEventActionChangeTitle"/> or <see cref="ChannelAdminLogEventActionChangeUsername"/> data of a channel gets modified)</summary>
			info = 0x200,
			/// <summary>Settings change events (<see cref="ChannelAdminLogEventActionToggleInvites"/>, <see cref="ChannelAdminLogEventActionTogglePreHistoryHidden"/>, <see cref="ChannelAdminLogEventActionToggleSignatures"/>, <see cref="ChannelAdminLogEventActionDefaultBannedRights"/>)</summary>
			settings = 0x400,
			/// <summary><see cref="ChannelAdminLogEventActionUpdatePinned"/></summary>
			pinned = 0x800,
			/// <summary><see cref="ChannelAdminLogEventActionEditMessage"/></summary>
			edit = 0x1000,
			/// <summary><see cref="ChannelAdminLogEventActionDeleteMessage"/></summary>
			delete = 0x2000,
			/// <summary>Group call events</summary>
			group_call = 0x4000,
			/// <summary>Invite events</summary>
			invites = 0x8000,
			/// <summary>A message was posted in a channel</summary>
			send = 0x10000,
		}
	}

	/// <summary>Popular contact		<para>See <a href="https://corefork.telegram.org/constructor/popularContact"/></para></summary>
	[TLDef(0x5CE14175)]
	public class PopularContact : IObject
	{
		/// <summary>Contact identifier</summary>
		public long client_id;
		/// <summary>How many people imported this contact</summary>
		public int importers;
	}

	/// <summary>Favorited stickers		<para>See <a href="https://corefork.telegram.org/constructor/messages.favedStickers"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.favedStickersNotModified">messages.favedStickersNotModified</a></remarks>
	[TLDef(0x2CB51097)]
	public class Messages_FavedStickers : IObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></summary>
		public long hash;
		/// <summary>Emojis associated to stickers</summary>
		public StickerPack[] packs;
		/// <summary>Favorited stickers</summary>
		public DocumentBase[] stickers;
	}

	/// <summary>Recent t.me urls		<para>Derived classes: <see cref="RecentMeUrlUnknown"/>, <see cref="RecentMeUrlUser"/>, <see cref="RecentMeUrlChat"/>, <see cref="RecentMeUrlChatInvite"/>, <see cref="RecentMeUrlStickerSet"/></para>		<para>See <a href="https://corefork.telegram.org/type/RecentMeUrl"/></para></summary>
	public abstract class RecentMeUrl : IObject
	{
		/// <summary>URL</summary>
		public string url;
	}
	/// <summary>Unknown t.me url		<para>See <a href="https://corefork.telegram.org/constructor/recentMeUrlUnknown"/></para></summary>
	[TLDef(0x46E1D13D)]
	public class RecentMeUrlUnknown : RecentMeUrl { }
	/// <summary>Recent t.me link to a user		<para>See <a href="https://corefork.telegram.org/constructor/recentMeUrlUser"/></para></summary>
	[TLDef(0xB92C09E2, inheritBefore = true)]
	public class RecentMeUrlUser : RecentMeUrl
	{
		/// <summary>User ID</summary>
		public long user_id;
	}
	/// <summary>Recent t.me link to a chat		<para>See <a href="https://corefork.telegram.org/constructor/recentMeUrlChat"/></para></summary>
	[TLDef(0xB2DA71D2, inheritBefore = true)]
	public class RecentMeUrlChat : RecentMeUrl
	{
		/// <summary>Chat ID</summary>
		public long chat_id;
	}
	/// <summary>Recent t.me invite link to a chat		<para>See <a href="https://corefork.telegram.org/constructor/recentMeUrlChatInvite"/></para></summary>
	[TLDef(0xEB49081D, inheritBefore = true)]
	public class RecentMeUrlChatInvite : RecentMeUrl
	{
		/// <summary>Chat invitation</summary>
		public ChatInviteBase chat_invite;
	}
	/// <summary>Recent t.me stickerset installation URL		<para>See <a href="https://corefork.telegram.org/constructor/recentMeUrlStickerSet"/></para></summary>
	[TLDef(0xBC0A57DC, inheritBefore = true)]
	public class RecentMeUrlStickerSet : RecentMeUrl
	{
		/// <summary>Stickerset</summary>
		public StickerSetCoveredBase set;
	}

	/// <summary>Recent t.me URLs		<para>See <a href="https://corefork.telegram.org/constructor/help.recentMeUrls"/></para></summary>
	[TLDef(0x0E0310D7)]
	public class Help_RecentMeUrls : IObject, IPeerResolver
	{
		/// <summary>URLs</summary>
		public RecentMeUrl[] urls;
		/// <summary>Chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users</summary>
		public Dictionary<long, User> users;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}

	/// <summary>A single media in an <a href="https://corefork.telegram.org/api/files#albums-grouped-media">album or grouped media</a> sent with <a href="https://corefork.telegram.org/method/messages.sendMultiMedia">messages.sendMultiMedia</a>.		<para>See <a href="https://corefork.telegram.org/constructor/inputSingleMedia"/></para></summary>
	[TLDef(0x1CC6E91F)]
	public class InputSingleMedia : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The media</summary>
		public InputMedia media;
		/// <summary>Unique client media ID required to prevent message resending</summary>
		public long random_id;
		/// <summary>A caption for the media</summary>
		public string message;
		/// <summary>Message <a href="https://corefork.telegram.org/api/entities">entities</a> for styled text</summary>
		[IfFlag(0)] public MessageEntity[] entities;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="entities"/> has a value</summary>
			has_entities = 0x1,
		}
	}

	/// <summary>Represents a bot logged in using the <a href="https://corefork.telegram.org/widgets/login">Telegram login widget</a>		<para>See <a href="https://corefork.telegram.org/constructor/webAuthorization"/></para></summary>
	[TLDef(0xA6F8F452)]
	public class WebAuthorization : IObject
	{
		/// <summary>Authorization hash</summary>
		public long hash;
		/// <summary>Bot ID</summary>
		public long bot_id;
		/// <summary>The domain name of the website on which the user has logged in.</summary>
		public string domain;
		/// <summary>Browser user-agent</summary>
		public string browser;
		/// <summary>Platform</summary>
		public string platform;
		/// <summary>When was the web session created</summary>
		public DateTime date_created;
		/// <summary>When was the web session last active</summary>
		public DateTime date_active;
		/// <summary>IP address</summary>
		public string ip;
		/// <summary>Region, determined from IP address</summary>
		public string region;
	}

	/// <summary>Web authorizations		<para>See <a href="https://corefork.telegram.org/constructor/account.webAuthorizations"/></para></summary>
	[TLDef(0xED56C9FC)]
	public class Account_WebAuthorizations : IObject
	{
		/// <summary>Web authorization list</summary>
		public WebAuthorization[] authorizations;
		/// <summary>Users</summary>
		public Dictionary<long, User> users;
	}

	/// <summary>A message		<para>Derived classes: <see cref="InputMessageID"/>, <see cref="InputMessageReplyTo"/>, <see cref="InputMessagePinned"/>, <see cref="InputMessageCallbackQuery"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputMessage"/></para></summary>
	public abstract partial class InputMessage : IObject { }
	/// <summary>Message by ID		<para>See <a href="https://corefork.telegram.org/constructor/inputMessageID"/></para></summary>
	[TLDef(0xA676A322)]
	public class InputMessageID : InputMessage
	{
		/// <summary>Message ID</summary>
		public int id;
	}
	/// <summary>Message to which the specified message replies to		<para>See <a href="https://corefork.telegram.org/constructor/inputMessageReplyTo"/></para></summary>
	[TLDef(0xBAD88395)]
	public class InputMessageReplyTo : InputMessage
	{
		/// <summary>ID of the message that replies to the message we need</summary>
		public int id;
	}
	/// <summary>Pinned message		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagePinned"/></para></summary>
	[TLDef(0x86872538)]
	public class InputMessagePinned : InputMessage { }
	/// <summary>Used by bots for fetching information about the message that originated a callback query		<para>See <a href="https://corefork.telegram.org/constructor/inputMessageCallbackQuery"/></para></summary>
	[TLDef(0xACFA1A7E)]
	public class InputMessageCallbackQuery : InputMessage
	{
		/// <summary>Message ID</summary>
		public int id;
		/// <summary>Callback query ID</summary>
		public long query_id;
	}

	/// <summary>Peer, or all peers in a certain folder		<para>Derived classes: <see cref="InputDialogPeer"/>, <see cref="InputDialogPeerFolder"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputDialogPeer"/></para></summary>
	public abstract class InputDialogPeerBase : IObject { }
	/// <summary>A peer		<para>See <a href="https://corefork.telegram.org/constructor/inputDialogPeer"/></para></summary>
	[TLDef(0xFCAAFEB7)]
	public class InputDialogPeer : InputDialogPeerBase
	{
		/// <summary>Peer</summary>
		public InputPeer peer;
	}
	/// <summary>All peers in a <a href="https://corefork.telegram.org/api/folders#peer-folders">peer folder</a>		<para>See <a href="https://corefork.telegram.org/constructor/inputDialogPeerFolder"/></para></summary>
	[TLDef(0x64600527)]
	public class InputDialogPeerFolder : InputDialogPeerBase
	{
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		public int folder_id;
	}

	/// <summary>Peer, or all peers in a folder		<para>Derived classes: <see cref="DialogPeer"/>, <see cref="DialogPeerFolder"/></para>		<para>See <a href="https://corefork.telegram.org/type/DialogPeer"/></para></summary>
	public abstract class DialogPeerBase : IObject { }
	/// <summary>Peer		<para>See <a href="https://corefork.telegram.org/constructor/dialogPeer"/></para></summary>
	[TLDef(0xE56DBF05)]
	public class DialogPeer : DialogPeerBase
	{
		/// <summary>Peer</summary>
		public Peer peer;
	}
	/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder</a>		<para>See <a href="https://corefork.telegram.org/constructor/dialogPeerFolder"/></para></summary>
	[TLDef(0x514519E2)]
	public class DialogPeerFolder : DialogPeerBase
	{
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		public int folder_id;
	}

	/// <summary>Found stickersets		<para>See <a href="https://corefork.telegram.org/constructor/messages.foundStickerSets"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.foundStickerSetsNotModified">messages.foundStickerSetsNotModified</a></remarks>
	[TLDef(0x8AF09DD2)]
	public class Messages_FoundStickerSets : IObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></summary>
		public long hash;
		/// <summary>Found stickersets</summary>
		public StickerSetCoveredBase[] sets;
	}

	/// <summary>SHA256 Hash of an uploaded file, to be checked for validity after download		<para>See <a href="https://corefork.telegram.org/constructor/fileHash"/></para></summary>
	[TLDef(0x6242C773)]
	public class FileHash : IObject
	{
		/// <summary>Offset from where to start computing SHA-256 hash</summary>
		public int offset;
		/// <summary>Length</summary>
		public int limit;
		/// <summary>SHA-256 Hash of file chunk, to be checked for validity after download</summary>
		public byte[] hash;
	}

	/// <summary>Info about an <a href="https://corefork.telegram.org/mtproto/mtproto-transports#transport-obfuscation">MTProxy</a> used to connect.		<para>See <a href="https://corefork.telegram.org/constructor/inputClientProxy"/></para></summary>
	[TLDef(0x75588B3F)]
	public class InputClientProxy : IObject
	{
		/// <summary>Proxy address</summary>
		public string address;
		/// <summary>Proxy port</summary>
		public int port;
	}

	/// <summary>Update of Telegram's terms of service		<para>Derived classes: <see cref="Help_TermsOfServiceUpdateEmpty"/>, <see cref="Help_TermsOfServiceUpdate"/></para>		<para>See <a href="https://corefork.telegram.org/type/help.TermsOfServiceUpdate"/></para></summary>
	public abstract class Help_TermsOfServiceUpdateBase : IObject { }
	/// <summary>No changes were made to telegram's terms of service		<para>See <a href="https://corefork.telegram.org/constructor/help.termsOfServiceUpdateEmpty"/></para></summary>
	[TLDef(0xE3309F7F)]
	public class Help_TermsOfServiceUpdateEmpty : Help_TermsOfServiceUpdateBase
	{
		/// <summary>New TOS updates will have to be queried using <a href="https://corefork.telegram.org/method/help.getTermsOfServiceUpdate">help.getTermsOfServiceUpdate</a> in <c>expires</c> seconds</summary>
		public DateTime expires;
	}
	/// <summary>Info about an update of telegram's terms of service. If the terms of service are declined, then the <a href="https://corefork.telegram.org/method/account.deleteAccount">account.deleteAccount</a> method should be called with the reason "Decline ToS update"		<para>See <a href="https://corefork.telegram.org/constructor/help.termsOfServiceUpdate"/></para></summary>
	[TLDef(0x28ECF961)]
	public class Help_TermsOfServiceUpdate : Help_TermsOfServiceUpdateBase
	{
		/// <summary>New TOS updates will have to be queried using <a href="https://corefork.telegram.org/method/help.getTermsOfServiceUpdate">help.getTermsOfServiceUpdate</a> in <c>expires</c> seconds</summary>
		public DateTime expires;
		/// <summary>New terms of service</summary>
		public Help_TermsOfService terms_of_service;
	}

	/// <summary>Secure <a href="https://corefork.telegram.org/passport">passport</a> file, for more info <a href="https://corefork.telegram.org/passport/encryption#inputsecurefile">see the passport docs »</a>		<para>Derived classes: <see cref="InputSecureFileUploaded"/>, <see cref="InputSecureFile"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputSecureFile"/></para></summary>
	public abstract class InputSecureFileBase : IObject
	{
		/// <summary>Secure file ID</summary>
		public abstract long ID { get; }
	}
	/// <summary>Uploaded secure file, for more info <a href="https://corefork.telegram.org/passport/encryption#inputsecurefile">see the passport docs »</a>		<para>See <a href="https://corefork.telegram.org/constructor/inputSecureFileUploaded"/></para></summary>
	[TLDef(0x3334B0F0)]
	public class InputSecureFileUploaded : InputSecureFileBase
	{
		/// <summary>Secure file ID</summary>
		public long id;
		/// <summary>Secure file part count</summary>
		public int parts;
		/// <summary>MD5 hash of encrypted uploaded file, to be checked server-side</summary>
		public byte[] md5_checksum;
		/// <summary>File hash</summary>
		public byte[] file_hash;
		/// <summary>Secret</summary>
		public byte[] secret;

		/// <summary>Secure file ID</summary>
		public override long ID => id;
	}
	/// <summary>Pre-uploaded <a href="https://corefork.telegram.org/passport">passport</a> file, for more info <a href="https://corefork.telegram.org/passport/encryption#inputsecurefile">see the passport docs »</a>		<para>See <a href="https://corefork.telegram.org/constructor/inputSecureFile"/></para></summary>
	[TLDef(0x5367E5BE)]
	public class InputSecureFile : InputSecureFileBase
	{
		/// <summary>Secure file ID</summary>
		public long id;
		/// <summary>⚠ <b>REQUIRED FIELD</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash">how to obtain it</see><br/>Secure file access hash</summary>
		public long access_hash;

		/// <summary>Secure file ID</summary>
		public override long ID => id;
	}

	/// <summary>Secure <a href="https://corefork.telegram.org/passport">passport</a> file, for more info <a href="https://corefork.telegram.org/passport/encryption#inputsecurefile">see the passport docs »</a>		<para>See <a href="https://corefork.telegram.org/constructor/secureFile"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/secureFileEmpty">secureFileEmpty</a></remarks>
	[TLDef(0xE0277A62)]
	public partial class SecureFile : IObject
	{
		/// <summary>ID</summary>
		public long id;
		/// <summary>Access hash</summary>
		public long access_hash;
		/// <summary>File size</summary>
		public int size;
		/// <summary>DC ID</summary>
		public int dc_id;
		/// <summary>Date of upload</summary>
		public DateTime date;
		/// <summary>File hash</summary>
		public byte[] file_hash;
		/// <summary>Secret</summary>
		public byte[] secret;
	}

	/// <summary>Secure <a href="https://corefork.telegram.org/passport">passport</a> data, for more info <a href="https://corefork.telegram.org/passport/encryption#securedata">see the passport docs »</a>		<para>See <a href="https://corefork.telegram.org/constructor/secureData"/></para></summary>
	[TLDef(0x8AEABEC3)]
	public class SecureData : IObject
	{
		/// <summary>Data</summary>
		public byte[] data;
		/// <summary>Data hash</summary>
		public byte[] data_hash;
		/// <summary>Secret</summary>
		public byte[] secret;
	}

	/// <summary>Plaintext verified <a href="https://corefork.telegram.org/passport/encryption#secureplaindata">passport data</a>.		<para>Derived classes: <see cref="SecurePlainPhone"/>, <see cref="SecurePlainEmail"/></para>		<para>See <a href="https://corefork.telegram.org/type/SecurePlainData"/></para></summary>
	public abstract class SecurePlainData : IObject { }
	/// <summary>Phone number to use in <a href="https://corefork.telegram.org/passport">telegram passport</a>: <a href="https://corefork.telegram.org/passport/encryption#secureplaindata">it must be verified, first »</a>.		<para>See <a href="https://corefork.telegram.org/constructor/securePlainPhone"/></para></summary>
	[TLDef(0x7D6099DD)]
	public class SecurePlainPhone : SecurePlainData
	{
		/// <summary>Phone number</summary>
		public string phone;
	}
	/// <summary>Email address to use in <a href="https://corefork.telegram.org/passport">telegram passport</a>: <a href="https://corefork.telegram.org/passport/encryption#secureplaindata">it must be verified, first »</a>.		<para>See <a href="https://corefork.telegram.org/constructor/securePlainEmail"/></para></summary>
	[TLDef(0x21EC5A5F)]
	public class SecurePlainEmail : SecurePlainData
	{
		/// <summary>Email address</summary>
		public string email;
	}

	/// <summary>Secure value type		<para>See <a href="https://corefork.telegram.org/type/SecureValueType"/></para></summary>
	public enum SecureValueType : uint
	{
		///<summary>Personal details</summary>
		PersonalDetails = 0x9D2A81E3,
		///<summary>Passport</summary>
		Passport = 0x3DAC6A00,
		///<summary>Driver's license</summary>
		DriverLicense = 0x06E425C4,
		///<summary>Identity card</summary>
		IdentityCard = 0xA0D0744B,
		///<summary>Internal <a href="https://corefork.telegram.org/passport">passport</a></summary>
		InternalPassport = 0x99A48F23,
		///<summary>Address</summary>
		Address = 0xCBE31E26,
		///<summary>Utility bill</summary>
		UtilityBill = 0xFC36954E,
		///<summary>Bank statement</summary>
		BankStatement = 0x89137C0D,
		///<summary>Rental agreement</summary>
		RentalAgreement = 0x8B883488,
		///<summary>Internal registration <a href="https://corefork.telegram.org/passport">passport</a></summary>
		PassportRegistration = 0x99E3806A,
		///<summary>Temporary registration</summary>
		TemporaryRegistration = 0xEA02EC33,
		///<summary>Phone</summary>
		Phone = 0xB320AADB,
		///<summary>Email</summary>
		Email = 0x8E3CA7EE,
	}

	/// <summary>Secure value		<para>See <a href="https://corefork.telegram.org/constructor/secureValue"/></para></summary>
	[TLDef(0x187FA0CA)]
	public class SecureValue : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Secure <a href="https://corefork.telegram.org/passport">passport</a> value type</summary>
		public SecureValueType type;
		/// <summary>Encrypted <a href="https://corefork.telegram.org/passport">Telegram Passport</a> element data</summary>
		[IfFlag(0)] public SecureData data;
		/// <summary>Encrypted <a href="https://corefork.telegram.org/passport">passport</a> file with the front side of the document</summary>
		[IfFlag(1)] public SecureFile front_side;
		/// <summary>Encrypted <a href="https://corefork.telegram.org/passport">passport</a> file with the reverse side of the document</summary>
		[IfFlag(2)] public SecureFile reverse_side;
		/// <summary>Encrypted <a href="https://corefork.telegram.org/passport">passport</a> file with a selfie of the user holding the document</summary>
		[IfFlag(3)] public SecureFile selfie;
		/// <summary>Array of encrypted <a href="https://corefork.telegram.org/passport">passport</a> files with translated versions of the provided documents</summary>
		[IfFlag(6)] public SecureFile[] translation;
		/// <summary>Array of encrypted <a href="https://corefork.telegram.org/passport">passport</a> files with photos the of the documents</summary>
		[IfFlag(4)] public SecureFile[] files;
		/// <summary>Plaintext verified <a href="https://corefork.telegram.org/passport">passport</a> data</summary>
		[IfFlag(5)] public SecurePlainData plain_data;
		/// <summary>Data hash</summary>
		public byte[] hash;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="data"/> has a value</summary>
			has_data = 0x1,
			/// <summary>Field <see cref="front_side"/> has a value</summary>
			has_front_side = 0x2,
			/// <summary>Field <see cref="reverse_side"/> has a value</summary>
			has_reverse_side = 0x4,
			/// <summary>Field <see cref="selfie"/> has a value</summary>
			has_selfie = 0x8,
			/// <summary>Field <see cref="files"/> has a value</summary>
			has_files = 0x10,
			/// <summary>Field <see cref="plain_data"/> has a value</summary>
			has_plain_data = 0x20,
			/// <summary>Field <see cref="translation"/> has a value</summary>
			has_translation = 0x40,
		}
	}

	/// <summary>Secure value, <a href="https://corefork.telegram.org/passport/encryption#encryption">for more info see the passport docs »</a>		<para>See <a href="https://corefork.telegram.org/constructor/inputSecureValue"/></para></summary>
	[TLDef(0xDB21D0A7)]
	public class InputSecureValue : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Secure <a href="https://corefork.telegram.org/passport">passport</a> value type</summary>
		public SecureValueType type;
		/// <summary>Encrypted <a href="https://corefork.telegram.org/passport">Telegram Passport</a> element data</summary>
		[IfFlag(0)] public SecureData data;
		/// <summary>Encrypted <a href="https://corefork.telegram.org/passport">passport</a> file with the front side of the document</summary>
		[IfFlag(1)] public InputSecureFileBase front_side;
		/// <summary>Encrypted <a href="https://corefork.telegram.org/passport">passport</a> file with the reverse side of the document</summary>
		[IfFlag(2)] public InputSecureFileBase reverse_side;
		/// <summary>Encrypted <a href="https://corefork.telegram.org/passport">passport</a> file with a selfie of the user holding the document</summary>
		[IfFlag(3)] public InputSecureFileBase selfie;
		/// <summary>Array of encrypted <a href="https://corefork.telegram.org/passport">passport</a> files with translated versions of the provided documents</summary>
		[IfFlag(6)] public InputSecureFileBase[] translation;
		/// <summary>Array of encrypted <a href="https://corefork.telegram.org/passport">passport</a> files with photos the of the documents</summary>
		[IfFlag(4)] public InputSecureFileBase[] files;
		/// <summary>Plaintext verified <a href="https://corefork.telegram.org/passport">passport</a> data</summary>
		[IfFlag(5)] public SecurePlainData plain_data;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="data"/> has a value</summary>
			has_data = 0x1,
			/// <summary>Field <see cref="front_side"/> has a value</summary>
			has_front_side = 0x2,
			/// <summary>Field <see cref="reverse_side"/> has a value</summary>
			has_reverse_side = 0x4,
			/// <summary>Field <see cref="selfie"/> has a value</summary>
			has_selfie = 0x8,
			/// <summary>Field <see cref="files"/> has a value</summary>
			has_files = 0x10,
			/// <summary>Field <see cref="plain_data"/> has a value</summary>
			has_plain_data = 0x20,
			/// <summary>Field <see cref="translation"/> has a value</summary>
			has_translation = 0x40,
		}
	}

	/// <summary>Secure value hash		<para>See <a href="https://corefork.telegram.org/constructor/secureValueHash"/></para></summary>
	[TLDef(0xED1ECDB0)]
	public class SecureValueHash : IObject
	{
		/// <summary>Secure value type</summary>
		public SecureValueType type;
		/// <summary>Hash</summary>
		public byte[] hash;
	}

	/// <summary>Secure value error		<para>Derived classes: <see cref="SecureValueErrorData"/>, <see cref="SecureValueErrorFrontSide"/>, <see cref="SecureValueErrorReverseSide"/>, <see cref="SecureValueErrorSelfie"/>, <see cref="SecureValueErrorFile"/>, <see cref="SecureValueErrorFiles"/>, <see cref="SecureValueError"/>, <see cref="SecureValueErrorTranslationFile"/>, <see cref="SecureValueErrorTranslationFiles"/></para>		<para>See <a href="https://corefork.telegram.org/type/SecureValueError"/></para></summary>
	public abstract class SecureValueErrorBase : IObject
	{
		/// <summary>The section of the user's Telegram Passport which has the error, one of <see cref="SecureValueType.PersonalDetails"/>, <see cref="SecureValueType.Passport"/>, <see cref="SecureValueType.DriverLicense"/>, <see cref="SecureValueType.IdentityCard"/>, <see cref="SecureValueType.InternalPassport"/>, <see cref="SecureValueType.Address"/></summary>
		public abstract SecureValueType Type { get; }
		/// <summary>Error message</summary>
		public abstract string Text { get; }
	}
	/// <summary>Represents an issue in one of the data fields that was provided by the user. The error is considered resolved when the field's value changes.		<para>See <a href="https://corefork.telegram.org/constructor/secureValueErrorData"/></para></summary>
	[TLDef(0xE8A40BD9)]
	public class SecureValueErrorData : SecureValueErrorBase
	{
		/// <summary>The section of the user's Telegram Passport which has the error, one of <see cref="SecureValueType.PersonalDetails"/>, <see cref="SecureValueType.Passport"/>, <see cref="SecureValueType.DriverLicense"/>, <see cref="SecureValueType.IdentityCard"/>, <see cref="SecureValueType.InternalPassport"/>, <see cref="SecureValueType.Address"/></summary>
		public SecureValueType type;
		/// <summary>Data hash</summary>
		public byte[] data_hash;
		/// <summary>Name of the data field which has the error</summary>
		public string field;
		/// <summary>Error message</summary>
		public string text;

		/// <summary>The section of the user's Telegram Passport which has the error, one of <see cref="SecureValueType.PersonalDetails"/>, <see cref="SecureValueType.Passport"/>, <see cref="SecureValueType.DriverLicense"/>, <see cref="SecureValueType.IdentityCard"/>, <see cref="SecureValueType.InternalPassport"/>, <see cref="SecureValueType.Address"/></summary>
		public override SecureValueType Type => type;
		/// <summary>Error message</summary>
		public override string Text => text;
	}
	/// <summary>Represents an issue with the front side of a document. The error is considered resolved when the file with the front side of the document changes.		<para>See <a href="https://corefork.telegram.org/constructor/secureValueErrorFrontSide"/></para></summary>
	[TLDef(0x00BE3DFA)]
	public class SecureValueErrorFrontSide : SecureValueErrorBase
	{
		/// <summary>One of <see cref="SecureValueType.Passport"/>, <see cref="SecureValueType.DriverLicense"/>, <see cref="SecureValueType.IdentityCard"/>, <see cref="SecureValueType.InternalPassport"/></summary>
		public SecureValueType type;
		/// <summary>File hash</summary>
		public byte[] file_hash;
		/// <summary>Error message</summary>
		public string text;

		/// <summary>One of <see cref="SecureValueType.Passport"/>, <see cref="SecureValueType.DriverLicense"/>, <see cref="SecureValueType.IdentityCard"/>, <see cref="SecureValueType.InternalPassport"/></summary>
		public override SecureValueType Type => type;
		/// <summary>Error message</summary>
		public override string Text => text;
	}
	/// <summary>Represents an issue with the reverse side of a document. The error is considered resolved when the file with reverse side of the document changes.		<para>See <a href="https://corefork.telegram.org/constructor/secureValueErrorReverseSide"/></para></summary>
	[TLDef(0x868A2AA5)]
	public class SecureValueErrorReverseSide : SecureValueErrorBase
	{
		/// <summary>One of <see cref="SecureValueType.DriverLicense"/>, <see cref="SecureValueType.IdentityCard"/></summary>
		public SecureValueType type;
		/// <summary>File hash</summary>
		public byte[] file_hash;
		/// <summary>Error message</summary>
		public string text;

		/// <summary>One of <see cref="SecureValueType.DriverLicense"/>, <see cref="SecureValueType.IdentityCard"/></summary>
		public override SecureValueType Type => type;
		/// <summary>Error message</summary>
		public override string Text => text;
	}
	/// <summary>Represents an issue with the selfie with a document. The error is considered resolved when the file with the selfie changes.		<para>See <a href="https://corefork.telegram.org/constructor/secureValueErrorSelfie"/></para></summary>
	[TLDef(0xE537CED6)]
	public class SecureValueErrorSelfie : SecureValueErrorBase
	{
		/// <summary>One of <see cref="SecureValueType.Passport"/>, <see cref="SecureValueType.DriverLicense"/>, <see cref="SecureValueType.IdentityCard"/>, <see cref="SecureValueType.InternalPassport"/></summary>
		public SecureValueType type;
		/// <summary>File hash</summary>
		public byte[] file_hash;
		/// <summary>Error message</summary>
		public string text;

		/// <summary>One of <see cref="SecureValueType.Passport"/>, <see cref="SecureValueType.DriverLicense"/>, <see cref="SecureValueType.IdentityCard"/>, <see cref="SecureValueType.InternalPassport"/></summary>
		public override SecureValueType Type => type;
		/// <summary>Error message</summary>
		public override string Text => text;
	}
	/// <summary>Represents an issue with a document scan. The error is considered resolved when the file with the document scan changes.		<para>See <a href="https://corefork.telegram.org/constructor/secureValueErrorFile"/></para></summary>
	[TLDef(0x7A700873)]
	public class SecureValueErrorFile : SecureValueErrorBase
	{
		/// <summary>One of <see cref="SecureValueType.UtilityBill"/>, <see cref="SecureValueType.BankStatement"/>, <see cref="SecureValueType.RentalAgreement"/>, <see cref="SecureValueType.PassportRegistration"/>, <see cref="SecureValueType.TemporaryRegistration"/></summary>
		public SecureValueType type;
		/// <summary>File hash</summary>
		public byte[] file_hash;
		/// <summary>Error message</summary>
		public string text;

		/// <summary>One of <see cref="SecureValueType.UtilityBill"/>, <see cref="SecureValueType.BankStatement"/>, <see cref="SecureValueType.RentalAgreement"/>, <see cref="SecureValueType.PassportRegistration"/>, <see cref="SecureValueType.TemporaryRegistration"/></summary>
		public override SecureValueType Type => type;
		/// <summary>Error message</summary>
		public override string Text => text;
	}
	/// <summary>Represents an issue with a list of scans. The error is considered resolved when the list of files containing the scans changes.		<para>See <a href="https://corefork.telegram.org/constructor/secureValueErrorFiles"/></para></summary>
	[TLDef(0x666220E9)]
	public class SecureValueErrorFiles : SecureValueErrorBase
	{
		/// <summary>One of <see cref="SecureValueType.UtilityBill"/>, <see cref="SecureValueType.BankStatement"/>, <see cref="SecureValueType.RentalAgreement"/>, <see cref="SecureValueType.PassportRegistration"/>, <see cref="SecureValueType.TemporaryRegistration"/></summary>
		public SecureValueType type;
		/// <summary>File hash</summary>
		public byte[][] file_hash;
		/// <summary>Error message</summary>
		public string text;

		/// <summary>One of <see cref="SecureValueType.UtilityBill"/>, <see cref="SecureValueType.BankStatement"/>, <see cref="SecureValueType.RentalAgreement"/>, <see cref="SecureValueType.PassportRegistration"/>, <see cref="SecureValueType.TemporaryRegistration"/></summary>
		public override SecureValueType Type => type;
		/// <summary>Error message</summary>
		public override string Text => text;
	}
	/// <summary>Secure value error		<para>See <a href="https://corefork.telegram.org/constructor/secureValueError"/></para></summary>
	[TLDef(0x869D758F)]
	public class SecureValueError : SecureValueErrorBase
	{
		/// <summary>Type of element which has the issue</summary>
		public SecureValueType type;
		/// <summary>Hash</summary>
		public byte[] hash;
		/// <summary>Error message</summary>
		public string text;

		/// <summary>Type of element which has the issue</summary>
		public override SecureValueType Type => type;
		/// <summary>Error message</summary>
		public override string Text => text;
	}
	/// <summary>Represents an issue with one of the files that constitute the translation of a document. The error is considered resolved when the file changes.		<para>See <a href="https://corefork.telegram.org/constructor/secureValueErrorTranslationFile"/></para></summary>
	[TLDef(0xA1144770)]
	public class SecureValueErrorTranslationFile : SecureValueErrorFile
	{
	}
	/// <summary>Represents an issue with the translated version of a document. The error is considered resolved when a file with the document translation changes.		<para>See <a href="https://corefork.telegram.org/constructor/secureValueErrorTranslationFiles"/></para></summary>
	[TLDef(0x34636DD8)]
	public class SecureValueErrorTranslationFiles : SecureValueErrorFiles
	{
	}

	/// <summary>Encrypted credentials required to decrypt <a href="https://corefork.telegram.org/passport">telegram passport</a> data.		<para>See <a href="https://corefork.telegram.org/constructor/secureCredentialsEncrypted"/></para></summary>
	[TLDef(0x33F0EA47)]
	public class SecureCredentialsEncrypted : IObject
	{
		/// <summary>Encrypted JSON-serialized data with unique user's payload, data hashes and secrets required for EncryptedPassportElement decryption and authentication, as described in <a href="https://corefork.telegram.org/passport#decrypting-data">decrypting data »</a></summary>
		public byte[] data;
		/// <summary>Data hash for data authentication as described in <a href="https://corefork.telegram.org/passport#decrypting-data">decrypting data »</a></summary>
		public byte[] hash;
		/// <summary>Secret, encrypted with the bot's public RSA key, required for data decryption as described in <a href="https://corefork.telegram.org/passport#decrypting-data">decrypting data »</a></summary>
		public byte[] secret;
	}

	/// <summary><a href="https://corefork.telegram.org/passport">Telegram Passport</a> authorization form		<para>See <a href="https://corefork.telegram.org/constructor/account.authorizationForm"/></para></summary>
	[TLDef(0xAD2E1CD8)]
	public class Account_AuthorizationForm : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Required <a href="https://corefork.telegram.org/passport">Telegram Passport</a> documents</summary>
		public SecureRequiredTypeBase[] required_types;
		/// <summary>Already submitted <a href="https://corefork.telegram.org/passport">Telegram Passport</a> documents</summary>
		public SecureValue[] values;
		/// <summary><a href="https://corefork.telegram.org/passport">Telegram Passport</a> errors</summary>
		public SecureValueErrorBase[] errors;
		/// <summary>Info about the bot to which the form will be submitted</summary>
		public Dictionary<long, User> users;
		/// <summary>URL of the service's privacy policy</summary>
		[IfFlag(0)] public string privacy_policy_url;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="privacy_policy_url"/> has a value</summary>
			has_privacy_policy_url = 0x1,
		}
	}

	/// <summary>The sent email code		<para>See <a href="https://corefork.telegram.org/constructor/account.sentEmailCode"/></para></summary>
	[TLDef(0x811F854F)]
	public class Account_SentEmailCode : IObject
	{
		/// <summary>The email (to which the code was sent) must match this <a href="https://corefork.telegram.org/api/pattern">pattern</a></summary>
		public string email_pattern;
		/// <summary>The length of the verification code</summary>
		public int length;
	}

	/// <summary>Deep linking info		<para>See <a href="https://corefork.telegram.org/constructor/help.deepLinkInfo"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.deepLinkInfoEmpty">help.deepLinkInfoEmpty</a></remarks>
	[TLDef(0x6A4EE832)]
	public class Help_DeepLinkInfo : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Message to show to the user</summary>
		public string message;
		/// <summary><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></summary>
		[IfFlag(1)] public MessageEntity[] entities;

		[Flags] public enum Flags : uint
		{
			/// <summary>An update of the app is required to parse this link</summary>
			update_app = 0x1,
			/// <summary>Field <see cref="entities"/> has a value</summary>
			has_entities = 0x2,
		}
	}

	/// <summary>Saved contact		<para>Derived classes: <see cref="SavedPhoneContact"/></para>		<para>See <a href="https://corefork.telegram.org/type/SavedContact"/></para></summary>
	public abstract class SavedContact : IObject { }
	/// <summary>Saved contact		<para>See <a href="https://corefork.telegram.org/constructor/savedPhoneContact"/></para></summary>
	[TLDef(0x1142BD56)]
	public class SavedPhoneContact : SavedContact
	{
		/// <summary>Phone number</summary>
		public string phone;
		/// <summary>First name</summary>
		public string first_name;
		/// <summary>Last name</summary>
		public string last_name;
		/// <summary>Date added</summary>
		public DateTime date;
	}

	/// <summary>Takeout info		<para>See <a href="https://corefork.telegram.org/constructor/account.takeout"/></para></summary>
	[TLDef(0x4DBA4501)]
	public class Account_Takeout : IObject
	{
		/// <summary>Takeout ID</summary>
		public long id;
	}

	/// <summary>Key derivation function to use when generating the <a href="https://corefork.telegram.org/api/srp">password hash for SRP two-factor authorization</a>		<para>Derived classes: <see cref="PasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow"/></para>		<para>See <a href="https://corefork.telegram.org/type/PasswordKdfAlgo"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/passwordKdfAlgoUnknown">passwordKdfAlgoUnknown</a></remarks>
	public abstract class PasswordKdfAlgo : IObject { }
	/// <summary>This key derivation algorithm defines that <a href="https://corefork.telegram.org/api/srp">SRP 2FA login</a> must be used		<para>See <a href="https://corefork.telegram.org/constructor/passwordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow"/></para></summary>
	[TLDef(0x3A912D4A)]
	public class PasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow : PasswordKdfAlgo
	{
		/// <summary>One of two salts used by the derivation function (see <a href="https://corefork.telegram.org/api/srp">SRP 2FA login</a>)</summary>
		public byte[] salt1;
		/// <summary>One of two salts used by the derivation function (see <a href="https://corefork.telegram.org/api/srp">SRP 2FA login</a>)</summary>
		public byte[] salt2;
		/// <summary>Base (see <a href="https://corefork.telegram.org/api/srp">SRP 2FA login</a>)</summary>
		public int g;
		/// <summary>2048-bit modulus (see <a href="https://corefork.telegram.org/api/srp">SRP 2FA login</a>)</summary>
		public byte[] p;
	}

	/// <summary>KDF algorithm to use for computing telegram <a href="https://corefork.telegram.org/passport">passport</a> hash		<para>Derived classes: <see cref="SecurePasswordKdfAlgoPBKDF2HMACSHA512iter100000"/>, <see cref="SecurePasswordKdfAlgoSHA512"/></para>		<para>See <a href="https://corefork.telegram.org/type/SecurePasswordKdfAlgo"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/securePasswordKdfAlgoUnknown">securePasswordKdfAlgoUnknown</a></remarks>
	public abstract class SecurePasswordKdfAlgo : IObject
	{
		/// <summary>Salt</summary>
		public byte[] salt;
	}
	/// <summary>PBKDF2 with SHA512 and 100000 iterations KDF algo		<para>See <a href="https://corefork.telegram.org/constructor/securePasswordKdfAlgoPBKDF2HMACSHA512iter100000"/></para></summary>
	[TLDef(0xBBF2DDA0)]
	public class SecurePasswordKdfAlgoPBKDF2HMACSHA512iter100000 : SecurePasswordKdfAlgo { }
	/// <summary>SHA512 KDF algo		<para>See <a href="https://corefork.telegram.org/constructor/securePasswordKdfAlgoSHA512"/></para></summary>
	[TLDef(0x86471D92)]
	public class SecurePasswordKdfAlgoSHA512 : SecurePasswordKdfAlgo { }

	/// <summary>Secure settings		<para>See <a href="https://corefork.telegram.org/constructor/secureSecretSettings"/></para></summary>
	[TLDef(0x1527BCAC)]
	public class SecureSecretSettings : IObject
	{
		/// <summary>Secure KDF algo</summary>
		public SecurePasswordKdfAlgo secure_algo;
		/// <summary>Secure secret</summary>
		public byte[] secure_secret;
		/// <summary>Secret ID</summary>
		public long secure_secret_id;
	}

	/// <summary>Constructor for checking the validity of a 2FA SRP password (see <a href="https://corefork.telegram.org/api/srp">SRP</a>)		<para>See <a href="https://corefork.telegram.org/constructor/inputCheckPasswordSRP"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputCheckPasswordEmpty">inputCheckPasswordEmpty</a></remarks>
	[TLDef(0xD27FF082)]
	public class InputCheckPasswordSRP : IObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/srp">SRP ID</a></summary>
		public long srp_id;
		/// <summary><c>A</c> parameter (see <a href="https://corefork.telegram.org/api/srp">SRP</a>)</summary>
		public byte[] A;
		/// <summary><c>M1</c> parameter (see <a href="https://corefork.telegram.org/api/srp">SRP</a>)</summary>
		public byte[] M1;
	}

	/// <summary>Required secure file type		<para>Derived classes: <see cref="SecureRequiredType"/>, <see cref="SecureRequiredTypeOneOf"/></para>		<para>See <a href="https://corefork.telegram.org/type/SecureRequiredType"/></para></summary>
	public abstract class SecureRequiredTypeBase : IObject { }
	/// <summary>Required type		<para>See <a href="https://corefork.telegram.org/constructor/secureRequiredType"/></para></summary>
	[TLDef(0x829D99DA)]
	public class SecureRequiredType : SecureRequiredTypeBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Secure value type</summary>
		public SecureValueType type;

		[Flags] public enum Flags : uint
		{
			/// <summary>Native names</summary>
			native_names = 0x1,
			/// <summary>Is a selfie required</summary>
			selfie_required = 0x2,
			/// <summary>Is a translation required</summary>
			translation_required = 0x4,
		}
	}
	/// <summary>One of		<para>See <a href="https://corefork.telegram.org/constructor/secureRequiredTypeOneOf"/></para></summary>
	[TLDef(0x027477B4)]
	public class SecureRequiredTypeOneOf : SecureRequiredTypeBase
	{
		/// <summary>Secure required value types</summary>
		public SecureRequiredTypeBase[] types;
	}

	/// <summary>Telegram <a href="https://corefork.telegram.org/passport">passport</a> configuration		<para>See <a href="https://corefork.telegram.org/constructor/help.passportConfig"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.passportConfigNotModified">help.passportConfigNotModified</a></remarks>
	[TLDef(0xA098D6AF)]
	public class Help_PassportConfig : IObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></summary>
		public int hash;
		/// <summary>Localization</summary>
		public DataJSON countries_langs;
	}

	/// <summary>Event that occurred in the application.		<para>See <a href="https://corefork.telegram.org/constructor/inputAppEvent"/></para></summary>
	[TLDef(0x1D1B1245)]
	public class InputAppEvent : IObject
	{
		/// <summary>Client's exact timestamp for the event</summary>
		public double time;
		/// <summary>Type of event</summary>
		public string type;
		/// <summary>Arbitrary numeric value for more convenient selection of certain event types, or events referring to a certain object</summary>
		public long peer;
		/// <summary>Details of the event</summary>
		public JSONValue data;
	}

	/// <summary>JSON key: value pair		<para>See <a href="https://corefork.telegram.org/constructor/jsonObjectValue"/></para></summary>
	[TLDef(0xC0DE1BD9)]
	public partial class JsonObjectValue : IObject
	{
		/// <summary>Key</summary>
		public string key;
		/// <summary>Value</summary>
		public JSONValue value;
	}

	/// <summary>JSON value		<para>Derived classes: <see cref="JsonNull"/>, <see cref="JsonBool"/>, <see cref="JsonNumber"/>, <see cref="JsonString"/>, <see cref="JsonArray"/>, <see cref="JsonObject"/></para>		<para>See <a href="https://corefork.telegram.org/type/JSONValue"/></para></summary>
	public abstract partial class JSONValue : IObject { }
	/// <summary>null JSON value		<para>See <a href="https://corefork.telegram.org/constructor/jsonNull"/></para></summary>
	[TLDef(0x3F6D7B68)]
	public partial class JsonNull : JSONValue { }
	/// <summary>JSON boolean value		<para>See <a href="https://corefork.telegram.org/constructor/jsonBool"/></para></summary>
	[TLDef(0xC7345E6A)]
	public partial class JsonBool : JSONValue
	{
		/// <summary>Value</summary>
		public bool value;
	}
	/// <summary>JSON numeric value		<para>See <a href="https://corefork.telegram.org/constructor/jsonNumber"/></para></summary>
	[TLDef(0x2BE0DFA4)]
	public partial class JsonNumber : JSONValue
	{
		/// <summary>Value</summary>
		public double value;
	}
	/// <summary>JSON string		<para>See <a href="https://corefork.telegram.org/constructor/jsonString"/></para></summary>
	[TLDef(0xB71E767A)]
	public partial class JsonString : JSONValue
	{
		/// <summary>Value</summary>
		public string value;
	}
	/// <summary>JSON array		<para>See <a href="https://corefork.telegram.org/constructor/jsonArray"/></para></summary>
	[TLDef(0xF7444763)]
	public partial class JsonArray : JSONValue
	{
		/// <summary>JSON values</summary>
		public JSONValue[] value;
	}
	/// <summary>JSON object value		<para>See <a href="https://corefork.telegram.org/constructor/jsonObject"/></para></summary>
	[TLDef(0x99C1D49D)]
	public partial class JsonObject : JSONValue
	{
		/// <summary>Values</summary>
		public JsonObjectValue[] value;
	}

	/// <summary>Table cell		<para>See <a href="https://corefork.telegram.org/constructor/pageTableCell"/></para></summary>
	[TLDef(0x34566B6A)]
	public class PageTableCell : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Content</summary>
		[IfFlag(7)] public RichText text;
		/// <summary>For how many columns should this cell extend</summary>
		[IfFlag(1)] public int colspan;
		/// <summary>For how many rows should this cell extend</summary>
		[IfFlag(2)] public int rowspan;

		[Flags] public enum Flags : uint
		{
			/// <summary>Is this element part of the column header</summary>
			header = 0x1,
			/// <summary>Field <see cref="colspan"/> has a value</summary>
			has_colspan = 0x2,
			/// <summary>Field <see cref="rowspan"/> has a value</summary>
			has_rowspan = 0x4,
			/// <summary>Horizontally centered block</summary>
			align_center = 0x8,
			/// <summary>Right-aligned block</summary>
			align_right = 0x10,
			/// <summary>Vertically centered block</summary>
			valign_middle = 0x20,
			/// <summary>Block vertically-aligned to the bottom</summary>
			valign_bottom = 0x40,
			/// <summary>Field <see cref="text"/> has a value</summary>
			has_text = 0x80,
		}
	}

	/// <summary>Table row		<para>See <a href="https://corefork.telegram.org/constructor/pageTableRow"/></para></summary>
	[TLDef(0xE0C0C5E5)]
	public class PageTableRow : IObject
	{
		/// <summary>Table cells</summary>
		public PageTableCell[] cells;
	}

	/// <summary>Page caption		<para>See <a href="https://corefork.telegram.org/constructor/pageCaption"/></para></summary>
	[TLDef(0x6F747657)]
	public class PageCaption : IObject
	{
		/// <summary>Caption</summary>
		public RichText text;
		/// <summary>Credits</summary>
		public RichText credit;
	}

	/// <summary>Item in block list		<para>Derived classes: <see cref="PageListItemText"/>, <see cref="PageListItemBlocks"/></para>		<para>See <a href="https://corefork.telegram.org/type/PageListItem"/></para></summary>
	public abstract class PageListItem : IObject { }
	/// <summary>List item		<para>See <a href="https://corefork.telegram.org/constructor/pageListItemText"/></para></summary>
	[TLDef(0xB92FB6CD)]
	public class PageListItemText : PageListItem
	{
		/// <summary>Text</summary>
		public RichText text;
	}
	/// <summary>List item		<para>See <a href="https://corefork.telegram.org/constructor/pageListItemBlocks"/></para></summary>
	[TLDef(0x25E073FC)]
	public class PageListItemBlocks : PageListItem
	{
		/// <summary>Blocks</summary>
		public PageBlock[] blocks;
	}

	/// <summary>Represents an <a href="https://instantview.telegram.org">instant view ordered list</a>		<para>Derived classes: <see cref="PageListOrderedItemText"/>, <see cref="PageListOrderedItemBlocks"/></para>		<para>See <a href="https://corefork.telegram.org/type/PageListOrderedItem"/></para></summary>
	public abstract class PageListOrderedItem : IObject
	{
		/// <summary>Number of element within ordered list</summary>
		public string num;
	}
	/// <summary>Ordered list of text items		<para>See <a href="https://corefork.telegram.org/constructor/pageListOrderedItemText"/></para></summary>
	[TLDef(0x5E068047, inheritBefore = true)]
	public class PageListOrderedItemText : PageListOrderedItem
	{
		/// <summary>Text</summary>
		public RichText text;
	}
	/// <summary>Ordered list of <a href="https://instantview.telegram.org">IV</a> blocks		<para>See <a href="https://corefork.telegram.org/constructor/pageListOrderedItemBlocks"/></para></summary>
	[TLDef(0x98DD8936, inheritBefore = true)]
	public class PageListOrderedItemBlocks : PageListOrderedItem
	{
		/// <summary>Item contents</summary>
		public PageBlock[] blocks;
	}

	/// <summary>Related article		<para>See <a href="https://corefork.telegram.org/constructor/pageRelatedArticle"/></para></summary>
	[TLDef(0xB390DC08)]
	public class PageRelatedArticle : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>URL of article</summary>
		public string url;
		/// <summary>Webpage ID of generated IV preview</summary>
		public long webpage_id;
		/// <summary>Title</summary>
		[IfFlag(0)] public string title;
		/// <summary>Description</summary>
		[IfFlag(1)] public string description;
		/// <summary>ID of preview photo</summary>
		[IfFlag(2)] public long photo_id;
		/// <summary>Author name</summary>
		[IfFlag(3)] public string author;
		/// <summary>Date of publication</summary>
		[IfFlag(4)] public DateTime published_date;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="title"/> has a value</summary>
			has_title = 0x1,
			/// <summary>Field <see cref="description"/> has a value</summary>
			has_description = 0x2,
			/// <summary>Field <see cref="photo_id"/> has a value</summary>
			has_photo_id = 0x4,
			/// <summary>Field <see cref="author"/> has a value</summary>
			has_author = 0x8,
			/// <summary>Field <see cref="published_date"/> has a value</summary>
			has_published_date = 0x10,
		}
	}

	/// <summary><a href="https://instantview.telegram.org">Instant view</a> page		<para>See <a href="https://corefork.telegram.org/constructor/page"/></para></summary>
	[TLDef(0x98657F0D)]
	public class Page : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Original page HTTP URL</summary>
		public string url;
		/// <summary>Page elements (like with HTML elements, only as TL constructors)</summary>
		public PageBlock[] blocks;
		/// <summary>Photos in page</summary>
		public PhotoBase[] photos;
		/// <summary>Media in page</summary>
		public DocumentBase[] documents;
		/// <summary>View count</summary>
		[IfFlag(3)] public int views;

		[Flags] public enum Flags : uint
		{
			/// <summary>Indicates that not full page preview is available to the client and it will need to fetch full Instant View from the server using <a href="https://corefork.telegram.org/method/messages.getWebPagePreview">messages.getWebPagePreview</a>.</summary>
			part = 0x1,
			/// <summary>Whether the page contains RTL text</summary>
			rtl = 0x2,
			/// <summary>Whether this is an <a href="https://instantview.telegram.org/docs#what-39s-new-in-2-0">IV v2</a> page</summary>
			v2 = 0x4,
			/// <summary>Field <see cref="views"/> has a value</summary>
			has_views = 0x8,
		}
	}

	/// <summary>Localized name for telegram support		<para>See <a href="https://corefork.telegram.org/constructor/help.supportName"/></para></summary>
	[TLDef(0x8C05F1C9)]
	public class Help_SupportName : IObject
	{
		/// <summary>Localized name</summary>
		public string name;
	}

	/// <summary>Internal use		<para>See <a href="https://corefork.telegram.org/constructor/help.userInfo"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.userInfoEmpty">help.userInfoEmpty</a></remarks>
	[TLDef(0x01EB3758)]
	public class Help_UserInfo : IObject
	{
		/// <summary>Info</summary>
		public string message;
		/// <summary><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></summary>
		public MessageEntity[] entities;
		/// <summary>Author</summary>
		public string author;
		/// <summary>Date</summary>
		public DateTime date;
	}

	/// <summary>A possible answer of a poll		<para>See <a href="https://corefork.telegram.org/constructor/pollAnswer"/></para></summary>
	[TLDef(0x6CA9C2E9)]
	public class PollAnswer : IObject
	{
		/// <summary>Textual representation of the answer</summary>
		public string text;
		/// <summary>The param that has to be passed to <a href="https://corefork.telegram.org/method/messages.sendVote">messages.sendVote</a>.</summary>
		public byte[] option;
	}

	/// <summary>Poll		<para>See <a href="https://corefork.telegram.org/constructor/poll"/></para></summary>
	[TLDef(0x86E18161)]
	public class Poll : IObject
	{
		/// <summary>ID of the poll</summary>
		public long id;
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The question of the poll</summary>
		public string question;
		/// <summary>The possible answers, vote using <a href="https://corefork.telegram.org/method/messages.sendVote">messages.sendVote</a>.</summary>
		public PollAnswer[] answers;
		/// <summary>Amount of time in seconds the poll will be active after creation, 5-600. Can't be used together with close_date.</summary>
		[IfFlag(4)] public int close_period;
		/// <summary>Point in time (Unix timestamp) when the poll will be automatically closed. Must be at least 5 and no more than 600 seconds in the future; can't be used together with close_period.</summary>
		[IfFlag(5)] public DateTime close_date;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the poll is closed and doesn't accept any more answers</summary>
			closed = 0x1,
			/// <summary>Whether cast votes are publicly visible to all users (non-anonymous poll)</summary>
			public_voters = 0x2,
			/// <summary>Whether multiple options can be chosen as answer</summary>
			multiple_choice = 0x4,
			/// <summary>Whether this is a quiz (with wrong and correct answers, results shown in the return type)</summary>
			quiz = 0x8,
			/// <summary>Field <see cref="close_period"/> has a value</summary>
			has_close_period = 0x10,
			/// <summary>Field <see cref="close_date"/> has a value</summary>
			has_close_date = 0x20,
		}
	}

	/// <summary>A poll answer, and how users voted on it		<para>See <a href="https://corefork.telegram.org/constructor/pollAnswerVoters"/></para></summary>
	[TLDef(0x3B6DDAD2)]
	public class PollAnswerVoters : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The param that has to be passed to <a href="https://corefork.telegram.org/method/messages.sendVote">messages.sendVote</a>.</summary>
		public byte[] option;
		/// <summary>How many users voted for this option</summary>
		public int voters;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether we have chosen this answer</summary>
			chosen = 0x1,
			/// <summary>For quizzes, whether the option we have chosen is correct</summary>
			correct = 0x2,
		}
	}

	/// <summary>Results of poll		<para>See <a href="https://corefork.telegram.org/constructor/pollResults"/></para></summary>
	[TLDef(0xDCB82EA3)]
	public class PollResults : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Poll results</summary>
		[IfFlag(1)] public PollAnswerVoters[] results;
		/// <summary>Total number of people that voted in the poll</summary>
		[IfFlag(2)] public int total_voters;
		/// <summary>IDs of the last users that recently voted in the poll</summary>
		[IfFlag(3)] public long[] recent_voters;
		/// <summary>Explanation of quiz solution</summary>
		[IfFlag(4)] public string solution;
		/// <summary><a href="https://corefork.telegram.org/api/entities">Message entities for styled text in quiz solution</a></summary>
		[IfFlag(4)] public MessageEntity[] solution_entities;

		[Flags] public enum Flags : uint
		{
			/// <summary>Similar to <a href="https://corefork.telegram.org/api/min">min</a> objects, used for poll constructors that are the same for all users so they don't have option chosen by the current user (you can use <a href="https://corefork.telegram.org/method/messages.getPollResults">messages.getPollResults</a> to get the full poll results).</summary>
			min = 0x1,
			/// <summary>Field <see cref="results"/> has a value</summary>
			has_results = 0x2,
			/// <summary>Field <see cref="total_voters"/> has a value</summary>
			has_total_voters = 0x4,
			/// <summary>Field <see cref="recent_voters"/> has a value</summary>
			has_recent_voters = 0x8,
			/// <summary>Field <see cref="solution"/> has a value</summary>
			has_solution = 0x10,
		}
	}

	/// <summary>Number of online users in a chat		<para>See <a href="https://corefork.telegram.org/constructor/chatOnlines"/></para></summary>
	[TLDef(0xF041E250)]
	public class ChatOnlines : IObject
	{
		/// <summary>Number of online users</summary>
		public int onlines;
	}

	/// <summary>URL with chat statistics		<para>See <a href="https://corefork.telegram.org/constructor/statsURL"/></para></summary>
	[TLDef(0x47A971E0)]
	public class StatsURL : IObject
	{
		/// <summary>Chat statistics</summary>
		public string url;
	}

	/// <summary>Represents the rights of an admin in a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>.		<para>See <a href="https://corefork.telegram.org/constructor/chatAdminRights"/></para></summary>
	[TLDef(0x5FB224D5)]
	public class ChatAdminRights : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;

		[Flags] public enum Flags : uint
		{
			/// <summary>If set, allows the admin to modify the description of the <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a></summary>
			change_info = 0x1,
			/// <summary>If set, allows the admin to post messages in the <a href="https://corefork.telegram.org/api/channel">channel</a></summary>
			post_messages = 0x2,
			/// <summary>If set, allows the admin to also edit messages from other admins in the <a href="https://corefork.telegram.org/api/channel">channel</a></summary>
			edit_messages = 0x4,
			/// <summary>If set, allows the admin to also delete messages from other admins in the <a href="https://corefork.telegram.org/api/channel">channel</a></summary>
			delete_messages = 0x8,
			/// <summary>If set, allows the admin to ban users from the <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a></summary>
			ban_users = 0x10,
			/// <summary>If set, allows the admin to invite users in the <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a></summary>
			invite_users = 0x20,
			/// <summary>If set, allows the admin to pin messages in the <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a></summary>
			pin_messages = 0x80,
			/// <summary>If set, allows the admin to add other admins with the same (or more limited) permissions in the <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a></summary>
			add_admins = 0x200,
			/// <summary>Whether this admin is anonymous</summary>
			anonymous = 0x400,
			/// <summary>If set, allows the admin to change group call/livestream settings</summary>
			manage_call = 0x800,
			/// <summary>Set this flag if none of the other flags are set, but you still want the user to be an admin.</summary>
			other = 0x1000,
		}
	}

	/// <summary>Represents the rights of a normal user in a <a href="https://corefork.telegram.org/api/channel">supergroup/channel/chat</a>. In this case, the flags are inverted: if set, a flag <strong>does not allow</strong> a user to do X.		<para>See <a href="https://corefork.telegram.org/constructor/chatBannedRights"/></para></summary>
	[TLDef(0x9F120418)]
	public class ChatBannedRights : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Validity of said permissions (it is considered forever any value less then 30 seconds or more then 366 days).</summary>
		public DateTime until_date;

		[Flags] public enum Flags : uint
		{
			/// <summary>If set, does not allow a user to view messages in a <a href="https://corefork.telegram.org/api/channel">supergroup/channel/chat</a></summary>
			view_messages = 0x1,
			/// <summary>If set, does not allow a user to send messages in a <a href="https://corefork.telegram.org/api/channel">supergroup/chat</a></summary>
			send_messages = 0x2,
			/// <summary>If set, does not allow a user to send any media in a <a href="https://corefork.telegram.org/api/channel">supergroup/chat</a></summary>
			send_media = 0x4,
			/// <summary>If set, does not allow a user to send stickers in a <a href="https://corefork.telegram.org/api/channel">supergroup/chat</a></summary>
			send_stickers = 0x8,
			/// <summary>If set, does not allow a user to send gifs in a <a href="https://corefork.telegram.org/api/channel">supergroup/chat</a></summary>
			send_gifs = 0x10,
			/// <summary>If set, does not allow a user to send games in a <a href="https://corefork.telegram.org/api/channel">supergroup/chat</a></summary>
			send_games = 0x20,
			/// <summary>If set, does not allow a user to use inline bots in a <a href="https://corefork.telegram.org/api/channel">supergroup/chat</a></summary>
			send_inline = 0x40,
			/// <summary>If set, does not allow a user to embed links in the messages of a <a href="https://corefork.telegram.org/api/channel">supergroup/chat</a></summary>
			embed_links = 0x80,
			/// <summary>If set, does not allow a user to send polls in a <a href="https://corefork.telegram.org/api/channel">supergroup/chat</a></summary>
			send_polls = 0x100,
			/// <summary>If set, does not allow any user to change the description of a <a href="https://corefork.telegram.org/api/channel">supergroup/chat</a></summary>
			change_info = 0x400,
			/// <summary>If set, does not allow any user to invite users in a <a href="https://corefork.telegram.org/api/channel">supergroup/chat</a></summary>
			invite_users = 0x8000,
			/// <summary>If set, does not allow any user to pin messages in a <a href="https://corefork.telegram.org/api/channel">supergroup/chat</a></summary>
			pin_messages = 0x20000,
		}
	}

	/// <summary>Wallpaper		<para>Derived classes: <see cref="InputWallPaper"/>, <see cref="InputWallPaperSlug"/>, <see cref="InputWallPaperNoFile"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputWallPaper"/></para></summary>
	public abstract class InputWallPaperBase : IObject { }
	/// <summary>Wallpaper		<para>See <a href="https://corefork.telegram.org/constructor/inputWallPaper"/></para></summary>
	[TLDef(0xE630B979)]
	public class InputWallPaper : InputWallPaperBase
	{
		/// <summary>Wallpaper ID</summary>
		public long id;
		/// <summary>⚠ <b>REQUIRED FIELD</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash">how to obtain it</see><br/>Access hash</summary>
		public long access_hash;
	}
	/// <summary>Wallpaper by slug (a unique ID)		<para>See <a href="https://corefork.telegram.org/constructor/inputWallPaperSlug"/></para></summary>
	[TLDef(0x72091C80)]
	public class InputWallPaperSlug : InputWallPaperBase
	{
		/// <summary>Unique wallpaper ID</summary>
		public string slug;
	}
	/// <summary>Wallpaper with no file access hash, used for example when deleting (<c>unsave=true</c>) wallpapers using <a href="https://corefork.telegram.org/method/account.saveWallPaper">account.saveWallPaper</a>, specifying just the wallpaper ID.		<para>See <a href="https://corefork.telegram.org/constructor/inputWallPaperNoFile"/></para></summary>
	[TLDef(0x967A462E)]
	public class InputWallPaperNoFile : InputWallPaperBase
	{
		/// <summary>Wallpaper ID</summary>
		public long id;
	}

	/// <summary>Installed wallpapers		<para>See <a href="https://corefork.telegram.org/constructor/account.wallPapers"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/account.wallPapersNotModified">account.wallPapersNotModified</a></remarks>
	[TLDef(0xCDC3858C)]
	public class Account_WallPapers : IObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></summary>
		public long hash;
		/// <summary>Wallpapers</summary>
		public WallPaperBase[] wallpapers;
	}

	/// <summary>Settings used by telegram servers for sending the confirm code.		<para>See <a href="https://corefork.telegram.org/constructor/codeSettings"/></para></summary>
	[TLDef(0x8A6469C2)]
	public class CodeSettings : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Previously stored logout tokens, see <a href="https://corefork.telegram.org/api/auth#logout-tokens">the documentation for more info »</a></summary>
		[IfFlag(6)] public byte[][] logout_tokens;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether to allow phone verification via <a href="https://corefork.telegram.org/api/auth">phone calls</a>.</summary>
			allow_flashcall = 0x1,
			/// <summary>Pass true if the phone number is used on the current device. Ignored if allow_flashcall is not set.</summary>
			current_number = 0x2,
			/// <summary>If a token that will be included in eventually sent SMSs is required: required in newer versions of android, to use the <a href="https://developers.google.com/identity/sms-retriever/overview">android SMS receiver APIs</a></summary>
			allow_app_hash = 0x10,
			/// <summary>Whether this device supports receiving the code using the <see cref="Auth_CodeType.MissedCall"/> method</summary>
			allow_missed_call = 0x20,
			/// <summary>Field <see cref="logout_tokens"/> has a value</summary>
			has_logout_tokens = 0x40,
		}
	}

	/// <summary>Wallpaper settings		<para>See <a href="https://corefork.telegram.org/constructor/wallPaperSettings"/></para></summary>
	[TLDef(0x1DC1BCA4)]
	public class WallPaperSettings : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>If set, a PNG pattern is to be combined with the <c>color</c> chosen by the user: the main color of the background in RGB24 format</summary>
		[IfFlag(0)] public int background_color;
		/// <summary>If set, a PNG pattern is to be combined with the first and second background colors (RGB24 format) in a top-bottom gradient</summary>
		[IfFlag(4)] public int second_background_color;
		/// <summary>If set, a PNG pattern is to be combined with the first, second and third background colors (RGB24 format) in a freeform gradient</summary>
		[IfFlag(5)] public int third_background_color;
		/// <summary>If set, a PNG pattern is to be combined with the first, second, third and fourth background colors (RGB24 format) in a freeform gradient</summary>
		[IfFlag(6)] public int fourth_background_color;
		/// <summary>Intensity of the pattern when it is shown above the main background color, 0-100</summary>
		[IfFlag(3)] public int intensity;
		/// <summary>Clockwise rotation angle of the gradient, in degrees; 0-359. Should be always divisible by 45</summary>
		[IfFlag(4)] public int rotation;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="background_color"/> has a value</summary>
			has_background_color = 0x1,
			/// <summary>If set, the wallpaper must be downscaled to fit in 450x450 square and then box-blurred with radius 12</summary>
			blur = 0x2,
			/// <summary>If set, the background needs to be slightly moved when device is rotated</summary>
			motion = 0x4,
			/// <summary>Field <see cref="intensity"/> has a value</summary>
			has_intensity = 0x8,
			/// <summary>Field <see cref="second_background_color"/> has a value</summary>
			has_second_background_color = 0x10,
			/// <summary>Field <see cref="third_background_color"/> has a value</summary>
			has_third_background_color = 0x20,
			/// <summary>Field <see cref="fourth_background_color"/> has a value</summary>
			has_fourth_background_color = 0x40,
		}
	}

	/// <summary>Autodownload settings		<para>See <a href="https://corefork.telegram.org/constructor/autoDownloadSettings"/></para></summary>
	[TLDef(0xE04232F3)]
	public class AutoDownloadSettings : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Maximum size of photos to preload</summary>
		public int photo_size_max;
		/// <summary>Maximum size of videos to preload</summary>
		public int video_size_max;
		/// <summary>Maximum size of other files to preload</summary>
		public int file_size_max;
		/// <summary>Maximum suggested bitrate for <strong>uploading</strong> videos</summary>
		public int video_upload_maxbitrate;

		[Flags] public enum Flags : uint
		{
			/// <summary>Disable automatic media downloads?</summary>
			disabled = 0x1,
			/// <summary>Whether to preload the first seconds of videos larger than the specified limit</summary>
			video_preload_large = 0x2,
			/// <summary>Whether to preload the next audio track when you're listening to music</summary>
			audio_preload_next = 0x4,
			/// <summary>Whether to enable data saving mode in phone calls</summary>
			phonecalls_less_data = 0x8,
		}
	}

	/// <summary>Media autodownload settings		<para>See <a href="https://corefork.telegram.org/constructor/account.autoDownloadSettings"/></para></summary>
	[TLDef(0x63CACF26)]
	public class Account_AutoDownloadSettings : IObject
	{
		/// <summary>Low data usage preset</summary>
		public AutoDownloadSettings low;
		/// <summary>Medium data usage preset</summary>
		public AutoDownloadSettings medium;
		/// <summary>High data usage preset</summary>
		public AutoDownloadSettings high;
	}

	/// <summary>Emoji keyword		<para>See <a href="https://corefork.telegram.org/constructor/emojiKeyword"/></para></summary>
	[TLDef(0xD5B3B9F9)]
	public class EmojiKeyword : IObject
	{
		/// <summary>Keyword</summary>
		public string keyword;
		/// <summary>Emojis associated to keyword</summary>
		public string[] emoticons;
	}
	/// <summary>Deleted emoji keyword		<para>See <a href="https://corefork.telegram.org/constructor/emojiKeywordDeleted"/></para></summary>
	[TLDef(0x236DF622)]
	public class EmojiKeywordDeleted : EmojiKeyword { }

	/// <summary>Changes to emoji keywords		<para>See <a href="https://corefork.telegram.org/constructor/emojiKeywordsDifference"/></para></summary>
	[TLDef(0x5CC761BD)]
	public class EmojiKeywordsDifference : IObject
	{
		/// <summary>Language code for keywords</summary>
		public string lang_code;
		/// <summary>Previous emoji keyword list version</summary>
		public int from_version;
		/// <summary>Current version of emoji keyword list</summary>
		public int version;
		/// <summary>Emojis associated to keywords</summary>
		public EmojiKeyword[] keywords;
	}

	/// <summary>An HTTP URL which can be used to automatically log in into translation platform and suggest new emoji replacements. The URL will be valid for 30 seconds after generation		<para>See <a href="https://corefork.telegram.org/constructor/emojiURL"/></para></summary>
	[TLDef(0xA575739D)]
	public class EmojiURL : IObject
	{
		/// <summary>An HTTP URL which can be used to automatically log in into translation platform and suggest new emoji replacements. The URL will be valid for 30 seconds after generation</summary>
		public string url;
	}

	/// <summary>Emoji language		<para>See <a href="https://corefork.telegram.org/constructor/emojiLanguage"/></para></summary>
	[TLDef(0xB3FB5361)]
	public class EmojiLanguage : IObject
	{
		/// <summary>Language code</summary>
		public string lang_code;
	}

	/// <summary>Folder		<para>See <a href="https://corefork.telegram.org/constructor/folder"/></para></summary>
	[TLDef(0xFF544E65)]
	public class Folder : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Folder ID</summary>
		public int id;
		/// <summary>Folder title</summary>
		public string title;
		/// <summary>Folder picture</summary>
		[IfFlag(3)] public ChatPhoto photo;

		[Flags] public enum Flags : uint
		{
			/// <summary>Automatically add new channels to this folder</summary>
			autofill_new_broadcasts = 0x1,
			/// <summary>Automatically add joined new public supergroups to this folder</summary>
			autofill_public_groups = 0x2,
			/// <summary>Automatically add new private chats to this folder</summary>
			autofill_new_correspondents = 0x4,
			/// <summary>Field <see cref="photo"/> has a value</summary>
			has_photo = 0x8,
		}
	}

	/// <summary>Peer in a folder		<para>See <a href="https://corefork.telegram.org/constructor/inputFolderPeer"/></para></summary>
	[TLDef(0xFBD2C296)]
	public class InputFolderPeer : IObject
	{
		/// <summary>Peer</summary>
		public InputPeer peer;
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		public int folder_id;
	}

	/// <summary>Peer in a folder		<para>See <a href="https://corefork.telegram.org/constructor/folderPeer"/></para></summary>
	[TLDef(0xE9BAA668)]
	public class FolderPeer : IObject
	{
		/// <summary>Folder peer info</summary>
		public Peer peer;
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		public int folder_id;
	}

	/// <summary>Indicates how many results would be found by a <a href="https://corefork.telegram.org/method/messages.search">messages.search</a> call with the same parameters		<para>See <a href="https://corefork.telegram.org/constructor/messages.searchCounter"/></para></summary>
	[TLDef(0xE844EBFF)]
	public class Messages_SearchCounter : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Provided message filter</summary>
		public MessagesFilter filter;
		/// <summary>Number of results that were found server-side</summary>
		public int count;

		[Flags] public enum Flags : uint
		{
			/// <summary>If set, the results may be inexact</summary>
			inexact = 0x2,
		}
	}

	/// <summary>URL authorization result		<para>Derived classes: <see cref="UrlAuthResultRequest"/>, <see cref="UrlAuthResultAccepted"/>, <see cref="UrlAuthResultDefault"/></para>		<para>See <a href="https://corefork.telegram.org/type/UrlAuthResult"/></para></summary>
	public abstract class UrlAuthResult : IObject { }
	/// <summary>Details about the authorization request, for more info <a href="https://corefork.telegram.org/api/url-authorization">click here »</a>		<para>See <a href="https://corefork.telegram.org/constructor/urlAuthResultRequest"/></para></summary>
	[TLDef(0x92D33A0E)]
	public class UrlAuthResultRequest : UrlAuthResult
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Username of a bot, which will be used for user authorization. If not specified, the current bot's username will be assumed. The url's domain must be the same as the domain linked with the bot. See <a href="https://core.telegram.org/widgets/login#linking-your-domain-to-the-bot">Linking your domain to the bot</a> for more details.</summary>
		public UserBase bot;
		/// <summary>The domain name of the website on which the user will log in.</summary>
		public string domain;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the bot would like to send messages to the user</summary>
			request_write_access = 0x1,
		}
	}
	/// <summary>Details about an accepted authorization request, for more info <a href="https://corefork.telegram.org/api/url-authorization">click here »</a>		<para>See <a href="https://corefork.telegram.org/constructor/urlAuthResultAccepted"/></para></summary>
	[TLDef(0x8F8C0E4E)]
	public class UrlAuthResultAccepted : UrlAuthResult
	{
		/// <summary>The URL name of the website on which the user has logged in.</summary>
		public string url;
	}
	/// <summary>Details about an accepted authorization request, for more info <a href="https://corefork.telegram.org/api/url-authorization">click here »</a>		<para>See <a href="https://corefork.telegram.org/constructor/urlAuthResultDefault"/></para></summary>
	[TLDef(0xA9D6DB1F)]
	public class UrlAuthResultDefault : UrlAuthResult { }

	/// <summary>Geographical location of supergroup (geogroups)		<para>See <a href="https://corefork.telegram.org/constructor/channelLocation"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/channelLocationEmpty">channelLocationEmpty</a></remarks>
	[TLDef(0x209B82DB)]
	public class ChannelLocation : IObject
	{
		/// <summary>Geographical location of supergroup</summary>
		public GeoPoint geo_point;
		/// <summary>Textual description of the address</summary>
		public string address;
	}

	/// <summary>Geolocated peer		<para>Derived classes: <see cref="PeerLocated"/>, <see cref="PeerSelfLocated"/></para>		<para>See <a href="https://corefork.telegram.org/type/PeerLocated"/></para></summary>
	public abstract class PeerLocatedBase : IObject
	{
		/// <summary>Validity period of current data</summary>
		public abstract DateTime Expires { get; }
	}
	/// <summary>Peer geolocated nearby		<para>See <a href="https://corefork.telegram.org/constructor/peerLocated"/></para></summary>
	[TLDef(0xCA461B5D)]
	public class PeerLocated : PeerLocatedBase
	{
		/// <summary>Peer</summary>
		public Peer peer;
		/// <summary>Validity period of current data</summary>
		public DateTime expires;
		/// <summary>Distance from the peer in meters</summary>
		public int distance;

		/// <summary>Validity period of current data</summary>
		public override DateTime Expires => expires;
	}
	/// <summary>Current peer		<para>See <a href="https://corefork.telegram.org/constructor/peerSelfLocated"/></para></summary>
	[TLDef(0xF8EC284B)]
	public class PeerSelfLocated : PeerLocatedBase
	{
		/// <summary>Expiry of geolocation info for current peer</summary>
		public DateTime expires;

		/// <summary>Expiry of geolocation info for current peer</summary>
		public override DateTime Expires => expires;
	}

	/// <summary>Restriction reason.		<para>See <a href="https://corefork.telegram.org/constructor/restrictionReason"/></para></summary>
	[TLDef(0xD072ACB4)]
	public class RestrictionReason : IObject
	{
		/// <summary>Platform identifier (ios, android, wp, all, etc.), can be concatenated with a dash as separator (<c>android-ios</c>, <c>ios-wp</c>, etc)</summary>
		public string platform;
		/// <summary>Restriction reason (<c>porno</c>, <c>terms</c>, etc.)</summary>
		public string reason;
		/// <summary>Error message to be shown to the user</summary>
		public string text;
	}

	/// <summary>Cloud theme		<para>Derived classes: <see cref="InputTheme"/>, <see cref="InputThemeSlug"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputTheme"/></para></summary>
	public abstract class InputThemeBase : IObject { }
	/// <summary>Theme		<para>See <a href="https://corefork.telegram.org/constructor/inputTheme"/></para></summary>
	[TLDef(0x3C5693E9)]
	public class InputTheme : InputThemeBase
	{
		/// <summary>ID</summary>
		public long id;
		/// <summary>⚠ <b>REQUIRED FIELD</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash">how to obtain it</see><br/>Access hash</summary>
		public long access_hash;
	}
	/// <summary>Theme by theme ID		<para>See <a href="https://corefork.telegram.org/constructor/inputThemeSlug"/></para></summary>
	[TLDef(0xF5890DF1)]
	public class InputThemeSlug : InputThemeBase
	{
		/// <summary>Unique theme ID</summary>
		public string slug;
	}

	/// <summary>Theme		<para>See <a href="https://corefork.telegram.org/constructor/theme"/></para></summary>
	[TLDef(0xA00E67D6)]
	public class Theme : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Theme ID</summary>
		public long id;
		/// <summary>Theme access hash</summary>
		public long access_hash;
		/// <summary>Unique theme ID</summary>
		public string slug;
		/// <summary>Theme name</summary>
		public string title;
		/// <summary>Theme</summary>
		[IfFlag(2)] public DocumentBase document;
		/// <summary>Theme settings</summary>
		[IfFlag(3)] public ThemeSettings[] settings;
		/// <summary>Theme emoji</summary>
		[IfFlag(6)] public string emoticon;
		/// <summary>Installation count</summary>
		[IfFlag(4)] public int installs_count;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the current user is the creator of this theme</summary>
			creator = 0x1,
			/// <summary>Whether this is the default theme</summary>
			default_ = 0x2,
			/// <summary>Field <see cref="document"/> has a value</summary>
			has_document = 0x4,
			/// <summary>Field <see cref="settings"/> has a value</summary>
			has_settings = 0x8,
			/// <summary>Field <see cref="installs_count"/> has a value</summary>
			has_installs_count = 0x10,
			/// <summary>Whether this theme is meant to be used as a <a href="https://telegram.org/blog/chat-themes-interactive-emoji-read-receipts">chat theme</a></summary>
			for_chat = 0x20,
			/// <summary>Field <see cref="emoticon"/> has a value</summary>
			has_emoticon = 0x40,
		}
	}

	/// <summary>Installed themes		<para>See <a href="https://corefork.telegram.org/constructor/account.themes"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/account.themesNotModified">account.themesNotModified</a></remarks>
	[TLDef(0x9A3D8C6D)]
	public class Account_Themes : IObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></summary>
		public long hash;
		/// <summary>Themes</summary>
		public Theme[] themes;
	}

	/// <summary>Login token (for QR code login)		<para>Derived classes: <see cref="Auth_LoginToken"/>, <see cref="Auth_LoginTokenMigrateTo"/>, <see cref="Auth_LoginTokenSuccess"/></para>		<para>See <a href="https://corefork.telegram.org/type/auth.LoginToken"/></para></summary>
	public abstract class Auth_LoginTokenBase : IObject { }
	/// <summary>Login token (for <a href="https://corefork.telegram.org/api/qr-login">QR code login</a>)		<para>See <a href="https://corefork.telegram.org/constructor/auth.loginToken"/></para></summary>
	[TLDef(0x629F1980)]
	public class Auth_LoginToken : Auth_LoginTokenBase
	{
		/// <summary>Expiry date of QR code</summary>
		public DateTime expires;
		/// <summary>Token to render in QR code</summary>
		public byte[] token;
	}
	/// <summary>Repeat the query to the specified DC		<para>See <a href="https://corefork.telegram.org/constructor/auth.loginTokenMigrateTo"/></para></summary>
	[TLDef(0x068E9916)]
	public class Auth_LoginTokenMigrateTo : Auth_LoginTokenBase
	{
		/// <summary>DC ID</summary>
		public int dc_id;
		/// <summary>Token to use for login</summary>
		public byte[] token;
	}
	/// <summary>Login via token (QR code) succeeded!		<para>See <a href="https://corefork.telegram.org/constructor/auth.loginTokenSuccess"/></para></summary>
	[TLDef(0x390D5C5E)]
	public class Auth_LoginTokenSuccess : Auth_LoginTokenBase
	{
		/// <summary>Authorization info</summary>
		public Auth_AuthorizationBase authorization;
	}

	/// <summary>Sensitive content settings		<para>See <a href="https://corefork.telegram.org/constructor/account.contentSettings"/></para></summary>
	[TLDef(0x57E28221)]
	public class Account_ContentSettings : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether viewing of sensitive (NSFW) content is enabled</summary>
			sensitive_enabled = 0x1,
			/// <summary>Whether the current client can change the sensitive content settings to view NSFW content</summary>
			sensitive_can_change = 0x2,
		}
	}

	/// <summary>Inactive chat list		<para>See <a href="https://corefork.telegram.org/constructor/messages.inactiveChats"/></para></summary>
	[TLDef(0xA927FEC5)]
	public class Messages_InactiveChats : IObject, IPeerResolver
	{
		/// <summary>When was the chat last active</summary>
		public int[] dates;
		/// <summary>Chat list</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users mentioned in the chat list</summary>
		public Dictionary<long, User> users;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}

	/// <summary>Basic theme settings		<para>See <a href="https://corefork.telegram.org/type/BaseTheme"/></para></summary>
	public enum BaseTheme : uint
	{
		///<summary>Classic theme</summary>
		Classic = 0xC3A12462,
		///<summary>Day theme</summary>
		Day = 0xFBD81688,
		///<summary>Night theme</summary>
		Night = 0xB7B31EA8,
		///<summary>Tinted theme</summary>
		Tinted = 0x6D5F77EE,
		///<summary>Arctic theme</summary>
		Arctic = 0x5B11125A,
	}

	/// <summary>Theme settings		<para>See <a href="https://corefork.telegram.org/constructor/inputThemeSettings"/></para></summary>
	[TLDef(0x8FDE504F)]
	public class InputThemeSettings : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Default theme on which this theme is based</summary>
		public BaseTheme base_theme;
		/// <summary>Accent color, ARGB format</summary>
		public int accent_color;
		/// <summary>Accent color of outgoing messages in ARGB format</summary>
		[IfFlag(3)] public int outbox_accent_color;
		/// <summary>The fill to be used as a background for outgoing messages, in RGB24 format. <br/>If just one or two equal colors are provided, describes a solid fill of a background. <br/>If two different colors are provided, describes the top and bottom colors of a 0-degree gradient.<br/>If three or four colors are provided, describes a freeform gradient fill of a background.</summary>
		[IfFlag(0)] public int[] message_colors;
		/// <summary>Wallpaper</summary>
		[IfFlag(1)] public InputWallPaperBase wallpaper;
		/// <summary>Wallpaper settings</summary>
		[IfFlag(1)] public WallPaperSettings wallpaper_settings;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="message_colors"/> has a value</summary>
			has_message_colors = 0x1,
			/// <summary>Field <see cref="wallpaper"/> has a value</summary>
			has_wallpaper = 0x2,
			/// <summary>If set, the freeform gradient fill needs to be animated on every sent message</summary>
			message_colors_animated = 0x4,
			/// <summary>Field <see cref="outbox_accent_color"/> has a value</summary>
			has_outbox_accent_color = 0x8,
		}
	}

	/// <summary>Theme settings		<para>See <a href="https://corefork.telegram.org/constructor/themeSettings"/></para></summary>
	[TLDef(0xFA58B6D4)]
	public class ThemeSettings : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Base theme</summary>
		public BaseTheme base_theme;
		/// <summary>Accent color, ARGB format</summary>
		public int accent_color;
		/// <summary>Accent color of outgoing messages in ARGB format</summary>
		[IfFlag(3)] public int outbox_accent_color;
		/// <summary>The fill to be used as a background for outgoing messages, in RGB24 format. <br/>If just one or two equal colors are provided, describes a solid fill of a background. <br/>If two different colors are provided, describes the top and bottom colors of a 0-degree gradient.<br/>If three or four colors are provided, describes a freeform gradient fill of a background.</summary>
		[IfFlag(0)] public int[] message_colors;
		/// <summary>Wallpaper</summary>
		[IfFlag(1)] public WallPaperBase wallpaper;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="message_colors"/> has a value</summary>
			has_message_colors = 0x1,
			/// <summary>Field <see cref="wallpaper"/> has a value</summary>
			has_wallpaper = 0x2,
			/// <summary>If set, the freeform gradient fill needs to be animated on every sent message.</summary>
			message_colors_animated = 0x4,
			/// <summary>Field <see cref="outbox_accent_color"/> has a value</summary>
			has_outbox_accent_color = 0x8,
		}
	}

	/// <summary>Webpage attributes		<para>Derived classes: <see cref="WebPageAttributeTheme"/></para>		<para>See <a href="https://corefork.telegram.org/type/WebPageAttribute"/></para></summary>
	public abstract class WebPageAttribute : IObject { }
	/// <summary>Page theme		<para>See <a href="https://corefork.telegram.org/constructor/webPageAttributeTheme"/></para></summary>
	[TLDef(0x54B56617)]
	public class WebPageAttributeTheme : WebPageAttribute
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Theme files</summary>
		[IfFlag(0)] public DocumentBase[] documents;
		/// <summary>Theme settings</summary>
		[IfFlag(1)] public ThemeSettings settings;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="documents"/> has a value</summary>
			has_documents = 0x1,
			/// <summary>Field <see cref="settings"/> has a value</summary>
			has_settings = 0x2,
		}
	}

	/// <summary>How a user voted in a poll		<para>Derived classes: <see cref="MessageUserVote"/>, <see cref="MessageUserVoteInputOption"/>, <see cref="MessageUserVoteMultiple"/></para>		<para>See <a href="https://corefork.telegram.org/type/MessageUserVote"/></para></summary>
	public abstract class MessageUserVoteBase : IObject
	{
		/// <summary>User ID</summary>
		public abstract long UserId { get; }
		/// <summary>When did the user cast the vote</summary>
		public abstract DateTime Date { get; }
	}
	/// <summary>How a user voted in a poll		<para>See <a href="https://corefork.telegram.org/constructor/messageUserVote"/></para></summary>
	[TLDef(0x34D247B4)]
	public class MessageUserVote : MessageUserVoteBase
	{
		/// <summary>User ID</summary>
		public long user_id;
		/// <summary>The option chosen by the user</summary>
		public byte[] option;
		/// <summary>When did the user cast the vote</summary>
		public DateTime date;

		/// <summary>User ID</summary>
		public override long UserId => user_id;
		/// <summary>When did the user cast the vote</summary>
		public override DateTime Date => date;
	}
	/// <summary>How a user voted in a poll (reduced constructor, returned if an <c>option</c> was provided to <a href="https://corefork.telegram.org/method/messages.getPollVotes">messages.getPollVotes</a>)		<para>See <a href="https://corefork.telegram.org/constructor/messageUserVoteInputOption"/></para></summary>
	[TLDef(0x3CA5B0EC)]
	public class MessageUserVoteInputOption : MessageUserVoteBase
	{
		/// <summary>The user that voted for the queried <c>option</c></summary>
		public long user_id;
		/// <summary>When did the user cast the vote</summary>
		public DateTime date;

		/// <summary>The user that voted for the queried <c>option</c></summary>
		public override long UserId => user_id;
		/// <summary>When did the user cast the vote</summary>
		public override DateTime Date => date;
	}
	/// <summary>How a user voted in a multiple-choice poll		<para>See <a href="https://corefork.telegram.org/constructor/messageUserVoteMultiple"/></para></summary>
	[TLDef(0x8A65E557)]
	public class MessageUserVoteMultiple : MessageUserVoteBase
	{
		/// <summary>User ID</summary>
		public long user_id;
		/// <summary>Options chosen by the user</summary>
		public byte[][] options;
		/// <summary>When did the user cast their votes</summary>
		public DateTime date;

		/// <summary>User ID</summary>
		public override long UserId => user_id;
		/// <summary>When did the user cast their votes</summary>
		public override DateTime Date => date;
	}

	/// <summary>How users voted in a poll		<para>See <a href="https://corefork.telegram.org/constructor/messages.votesList"/></para></summary>
	[TLDef(0x0823F649)]
	public class Messages_VotesList : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Total number of votes for all options (or only for the chosen <c>option</c>, if provided to <a href="https://corefork.telegram.org/method/messages.getPollVotes">messages.getPollVotes</a>)</summary>
		public int count;
		/// <summary>Vote info for each user</summary>
		public MessageUserVoteBase[] votes;
		/// <summary>Info about users that voted in the poll</summary>
		public Dictionary<long, User> users;
		/// <summary>Offset to use with the next <a href="https://corefork.telegram.org/method/messages.getPollVotes">messages.getPollVotes</a> request, empty string if no more results are available.</summary>
		[IfFlag(0)] public string next_offset;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="next_offset"/> has a value</summary>
			has_next_offset = 0x1,
		}
	}

	/// <summary>Credit card info URL provided by the bank		<para>See <a href="https://corefork.telegram.org/constructor/bankCardOpenUrl"/></para></summary>
	[TLDef(0xF568028A)]
	public class BankCardOpenUrl : IObject
	{
		/// <summary>Info URL</summary>
		public string url;
		/// <summary>Bank name</summary>
		public string name;
	}

	/// <summary>Credit card info, provided by the card's bank(s)		<para>See <a href="https://corefork.telegram.org/constructor/payments.bankCardData"/></para></summary>
	[TLDef(0x3E24E573)]
	public class Payments_BankCardData : IObject
	{
		/// <summary>Credit card title</summary>
		public string title;
		/// <summary>Info URL(s) provided by the card's bank(s)</summary>
		public BankCardOpenUrl[] open_urls;
	}

	/// <summary>Dialog filter AKA <a href="https://corefork.telegram.org/api/folders">folder</a>		<para>See <a href="https://corefork.telegram.org/constructor/dialogFilter"/></para></summary>
	[TLDef(0x7438F7E8)]
	public class DialogFilter : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary><a href="https://corefork.telegram.org/api/folders">Folder</a> ID</summary>
		public int id;
		/// <summary><a href="https://corefork.telegram.org/api/folders">Folder</a> name</summary>
		public string title;
		/// <summary><a href="https://corefork.telegram.org/api/folders">Folder</a> emoticon</summary>
		[IfFlag(25)] public string emoticon;
		/// <summary>Pinned chats, <a href="https://corefork.telegram.org/api/folders">folders</a> can have unlimited pinned chats</summary>
		public InputPeer[] pinned_peers;
		/// <summary>Include the following chats in this <a href="https://corefork.telegram.org/api/folders">folder</a></summary>
		public InputPeer[] include_peers;
		/// <summary>Exclude the following chats from this <a href="https://corefork.telegram.org/api/folders">folder</a></summary>
		public InputPeer[] exclude_peers;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether to include all contacts in this <a href="https://corefork.telegram.org/api/folders">folder</a></summary>
			contacts = 0x1,
			/// <summary>Whether to include all non-contacts in this <a href="https://corefork.telegram.org/api/folders">folder</a></summary>
			non_contacts = 0x2,
			/// <summary>Whether to include all groups in this <a href="https://corefork.telegram.org/api/folders">folder</a></summary>
			groups = 0x4,
			/// <summary>Whether to include all channels in this <a href="https://corefork.telegram.org/api/folders">folder</a></summary>
			broadcasts = 0x8,
			/// <summary>Whether to include all bots in this <a href="https://corefork.telegram.org/api/folders">folder</a></summary>
			bots = 0x10,
			/// <summary>Whether to exclude muted chats from this <a href="https://corefork.telegram.org/api/folders">folder</a></summary>
			exclude_muted = 0x800,
			/// <summary>Whether to exclude read chats from this <a href="https://corefork.telegram.org/api/folders">folder</a></summary>
			exclude_read = 0x1000,
			/// <summary>Whether to exclude archived chats from this <a href="https://corefork.telegram.org/api/folders">folder</a></summary>
			exclude_archived = 0x2000,
			/// <summary>Field <see cref="emoticon"/> has a value</summary>
			has_emoticon = 0x2000000,
		}
	}

	/// <summary>Suggested <a href="https://corefork.telegram.org/api/folders">folders</a>		<para>See <a href="https://corefork.telegram.org/constructor/dialogFilterSuggested"/></para></summary>
	[TLDef(0x77744D4A)]
	public class DialogFilterSuggested : IObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/folders">Folder info</a></summary>
		public DialogFilter filter;
		/// <summary><a href="https://corefork.telegram.org/api/folders">Folder</a> description</summary>
		public string description;
	}

	/// <summary><a href="https://corefork.telegram.org/api/stats">Channel statistics</a> date range		<para>See <a href="https://corefork.telegram.org/constructor/statsDateRangeDays"/></para></summary>
	[TLDef(0xB637EDAF)]
	public class StatsDateRangeDays : IObject
	{
		/// <summary>Initial date</summary>
		public DateTime min_date;
		/// <summary>Final date</summary>
		public DateTime max_date;
	}

	/// <summary>Statistics value couple; initial and final value for period of time currently in consideration		<para>See <a href="https://corefork.telegram.org/constructor/statsAbsValueAndPrev"/></para></summary>
	[TLDef(0xCB43ACDE)]
	public class StatsAbsValueAndPrev : IObject
	{
		/// <summary>Current value</summary>
		public double current;
		/// <summary>Previous value</summary>
		public double previous;
	}

	/// <summary><a href="https://corefork.telegram.org/api/stats">Channel statistics percentage</a>.<br/>Compute the percentage simply by doing <c>part * total / 100</c>		<para>See <a href="https://corefork.telegram.org/constructor/statsPercentValue"/></para></summary>
	[TLDef(0xCBCE2FE0)]
	public class StatsPercentValue : IObject
	{
		/// <summary>Partial value</summary>
		public double part;
		/// <summary>Total value</summary>
		public double total;
	}

	/// <summary>Channel statistics graph		<para>Derived classes: <see cref="StatsGraphAsync"/>, <see cref="StatsGraphError"/>, <see cref="StatsGraph"/></para>		<para>See <a href="https://corefork.telegram.org/type/StatsGraph"/></para></summary>
	public abstract class StatsGraphBase : IObject { }
	/// <summary>This <a href="https://corefork.telegram.org/api/stats">channel statistics graph</a> must be generated asynchronously using <a href="https://corefork.telegram.org/method/stats.loadAsyncGraph">stats.loadAsyncGraph</a> to reduce server load		<para>See <a href="https://corefork.telegram.org/constructor/statsGraphAsync"/></para></summary>
	[TLDef(0x4A27EB2D)]
	public class StatsGraphAsync : StatsGraphBase
	{
		/// <summary>Token to use for fetching the async graph</summary>
		public string token;
	}
	/// <summary>An error occurred while generating the <a href="https://corefork.telegram.org/api/stats">statistics graph</a>		<para>See <a href="https://corefork.telegram.org/constructor/statsGraphError"/></para></summary>
	[TLDef(0xBEDC9822)]
	public class StatsGraphError : StatsGraphBase
	{
		/// <summary>The error</summary>
		public string error;
	}
	/// <summary><a href="https://corefork.telegram.org/api/stats">Channel statistics graph</a>		<para>See <a href="https://corefork.telegram.org/constructor/statsGraph"/></para></summary>
	[TLDef(0x8EA464B6)]
	public class StatsGraph : StatsGraphBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Statistics data</summary>
		public DataJSON json;
		/// <summary>Zoom token</summary>
		[IfFlag(0)] public string zoom_token;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="zoom_token"/> has a value</summary>
			has_zoom_token = 0x1,
		}
	}

	/// <summary>Message interaction counters		<para>See <a href="https://corefork.telegram.org/constructor/messageInteractionCounters"/></para></summary>
	[TLDef(0xAD4FC9BD)]
	public class MessageInteractionCounters : IObject
	{
		/// <summary>Message ID</summary>
		public int msg_id;
		/// <summary>Views</summary>
		public int views;
		/// <summary>Number of times this message was forwarded</summary>
		public int forwards;
	}

	/// <summary><a href="https://corefork.telegram.org/api/stats">Channel statistics</a>.		<para>See <a href="https://corefork.telegram.org/constructor/stats.broadcastStats"/></para></summary>
	[TLDef(0xBDF78394)]
	public class Stats_BroadcastStats : IObject
	{
		/// <summary>Period in consideration</summary>
		public StatsDateRangeDays period;
		/// <summary>Follower count change for period in consideration</summary>
		public StatsAbsValueAndPrev followers;
		/// <summary><c>total_viewcount/postcount</c>, for posts posted during the period in consideration (<c>views_per_post</c>). <br/>Note that in this case, <c>current</c> refers to the <c>period</c> in consideration (<c>min_date</c> till <c>max_date</c>), and <c>prev</c> refers to the previous period (<c>(min_date - (max_date - min_date))</c> till <c>min_date</c>).</summary>
		public StatsAbsValueAndPrev views_per_post;
		/// <summary><c>total_viewcount/postcount</c>, for posts posted during the period in consideration (<c>views_per_post</c>). <br/>Note that in this case, <c>current</c> refers to the <c>period</c> in consideration (<c>min_date</c> till <c>max_date</c>), and <c>prev</c> refers to the previous period (<c>(min_date - (max_date - min_date))</c> till <c>min_date</c>)</summary>
		public StatsAbsValueAndPrev shares_per_post;
		/// <summary>Percentage of subscribers with enabled notifications</summary>
		public StatsPercentValue enabled_notifications;
		/// <summary>Channel growth graph (absolute subscriber count)</summary>
		public StatsGraphBase growth_graph;
		/// <summary>Followers growth graph (relative subscriber count)</summary>
		public StatsGraphBase followers_graph;
		/// <summary>Muted users graph (relative)</summary>
		public StatsGraphBase mute_graph;
		/// <summary>Views per hour graph (absolute)</summary>
		public StatsGraphBase top_hours_graph;
		/// <summary>Interactions graph (absolute)</summary>
		public StatsGraphBase interactions_graph;
		/// <summary>IV interactions graph (absolute)</summary>
		public StatsGraphBase iv_interactions_graph;
		/// <summary>Views by source graph (absolute)</summary>
		public StatsGraphBase views_by_source_graph;
		/// <summary>New followers by source graph (absolute)</summary>
		public StatsGraphBase new_followers_by_source_graph;
		/// <summary>Subscriber language graph (pie chart)</summary>
		public StatsGraphBase languages_graph;
		/// <summary>Recent message interactions</summary>
		public MessageInteractionCounters[] recent_message_interactions;
	}

	/// <summary>Info about pinned MTProxy or Public Service Announcement peers.		<para>Derived classes: <see cref="Help_PromoDataEmpty"/>, <see cref="Help_PromoData"/></para>		<para>See <a href="https://corefork.telegram.org/type/help.PromoData"/></para></summary>
	public abstract class Help_PromoDataBase : IObject { }
	/// <summary>No PSA/MTProxy info is available		<para>See <a href="https://corefork.telegram.org/constructor/help.promoDataEmpty"/></para></summary>
	[TLDef(0x98F6AC75)]
	public class Help_PromoDataEmpty : Help_PromoDataBase
	{
		/// <summary>Re-fetch PSA/MTProxy info after the specified number of seconds</summary>
		public DateTime expires;
	}
	/// <summary>MTProxy/Public Service Announcement information		<para>See <a href="https://corefork.telegram.org/constructor/help.promoData"/></para></summary>
	[TLDef(0x8C39793F)]
	public class Help_PromoData : Help_PromoDataBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Expiry of PSA/MTProxy info</summary>
		public DateTime expires;
		/// <summary>MTProxy/PSA peer</summary>
		public Peer peer;
		/// <summary>Chat info</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>User info</summary>
		public Dictionary<long, User> users;
		/// <summary>PSA type</summary>
		[IfFlag(1)] public string psa_type;
		/// <summary>PSA message</summary>
		[IfFlag(2)] public string psa_message;

		[Flags] public enum Flags : uint
		{
			/// <summary>MTProxy-related channel</summary>
			proxy = 0x1,
			/// <summary>Field <see cref="psa_type"/> has a value</summary>
			has_psa_type = 0x2,
			/// <summary>Field <see cref="psa_message"/> has a value</summary>
			has_psa_message = 0x4,
		}
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the result</summary>
		public IPeerInfo UserOrChat => peer?.UserOrChat(users, chats);
	}

	/// <summary><a href="https://corefork.telegram.org/api/files#animated-profile-pictures">Animated profile picture</a> in MPEG4 format		<para>See <a href="https://corefork.telegram.org/constructor/videoSize"/></para></summary>
	[TLDef(0xDE33B094)]
	public class VideoSize : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary><c>u</c> for animated profile pictures, and <c>v</c> for trimmed and downscaled video previews</summary>
		public string type;
		/// <summary>Video width</summary>
		public int w;
		/// <summary>Video height</summary>
		public int h;
		/// <summary>File size</summary>
		public int size;
		/// <summary>Timestamp that should be shown as static preview to the user (seconds)</summary>
		[IfFlag(0)] public double video_start_ts;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="video_start_ts"/> has a value</summary>
			has_video_start_ts = 0x1,
		}
	}

	/// <summary>Information about an active user in a supergroup		<para>See <a href="https://corefork.telegram.org/constructor/statsGroupTopPoster"/></para></summary>
	[TLDef(0x9D04AF9B)]
	public class StatsGroupTopPoster : IObject
	{
		/// <summary>User ID</summary>
		public long user_id;
		/// <summary>Number of messages for <a href="https://corefork.telegram.org/api/stats">statistics</a> period in consideration</summary>
		public int messages;
		/// <summary>Average number of characters per message</summary>
		public int avg_chars;
	}

	/// <summary>Information about an active admin in a supergroup		<para>See <a href="https://corefork.telegram.org/constructor/statsGroupTopAdmin"/></para></summary>
	[TLDef(0xD7584C87)]
	public class StatsGroupTopAdmin : IObject
	{
		/// <summary>User ID</summary>
		public long user_id;
		/// <summary>Number of deleted messages for <a href="https://corefork.telegram.org/api/stats">statistics</a> period in consideration</summary>
		public int deleted;
		/// <summary>Number of kicked users for <a href="https://corefork.telegram.org/api/stats">statistics</a> period in consideration</summary>
		public int kicked;
		/// <summary>Number of banned users for <a href="https://corefork.telegram.org/api/stats">statistics</a> period in consideration</summary>
		public int banned;
	}

	/// <summary>Information about an active supergroup inviter		<para>See <a href="https://corefork.telegram.org/constructor/statsGroupTopInviter"/></para></summary>
	[TLDef(0x535F779D)]
	public class StatsGroupTopInviter : IObject
	{
		/// <summary>User ID</summary>
		public long user_id;
		/// <summary>Number of invitations for <a href="https://corefork.telegram.org/api/stats">statistics</a> period in consideration</summary>
		public int invitations;
	}

	/// <summary>Supergroup <a href="https://corefork.telegram.org/api/stats">statistics</a>		<para>See <a href="https://corefork.telegram.org/constructor/stats.megagroupStats"/></para></summary>
	[TLDef(0xEF7FF916)]
	public class Stats_MegagroupStats : IObject
	{
		/// <summary>Period in consideration</summary>
		public StatsDateRangeDays period;
		/// <summary>Member count change for period in consideration</summary>
		public StatsAbsValueAndPrev members;
		/// <summary>Message number change for period in consideration</summary>
		public StatsAbsValueAndPrev messages;
		/// <summary>Number of users that viewed messages, for range in consideration</summary>
		public StatsAbsValueAndPrev viewers;
		/// <summary>Number of users that posted messages, for range in consideration</summary>
		public StatsAbsValueAndPrev posters;
		/// <summary>Supergroup growth graph (absolute subscriber count)</summary>
		public StatsGraphBase growth_graph;
		/// <summary>Members growth (relative subscriber count)</summary>
		public StatsGraphBase members_graph;
		/// <summary>New members by source graph</summary>
		public StatsGraphBase new_members_by_source_graph;
		/// <summary>Subscriber language graph (pie chart)</summary>
		public StatsGraphBase languages_graph;
		/// <summary>Message activity graph (stacked bar graph, message type)</summary>
		public StatsGraphBase messages_graph;
		/// <summary>Group activity graph (deleted, modified messages, blocked users)</summary>
		public StatsGraphBase actions_graph;
		/// <summary>Activity per hour graph (absolute)</summary>
		public StatsGraphBase top_hours_graph;
		/// <summary>Activity per day of week graph (absolute)</summary>
		public StatsGraphBase weekdays_graph;
		/// <summary>Info about most active group members</summary>
		public StatsGroupTopPoster[] top_posters;
		/// <summary>Info about most active group admins</summary>
		public StatsGroupTopAdmin[] top_admins;
		/// <summary>Info about most active group inviters</summary>
		public StatsGroupTopInviter[] top_inviters;
		/// <summary>Info about users mentioned in statistics</summary>
		public Dictionary<long, User> users;
	}

	/// <summary>Global privacy settings		<para>See <a href="https://corefork.telegram.org/constructor/globalPrivacySettings"/></para></summary>
	[TLDef(0xBEA2F424)]
	public class GlobalPrivacySettings : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Whether to archive and mute new chats from non-contacts</summary>
		[IfFlag(0)] public bool archive_and_mute_new_noncontact_peers;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="archive_and_mute_new_noncontact_peers"/> has a value</summary>
			has_archive_and_mute_new_noncontact_peers = 0x1,
		}
	}

	/// <summary>Country code and phone number pattern of a specific country		<para>See <a href="https://corefork.telegram.org/constructor/help.countryCode"/></para></summary>
	[TLDef(0x4203C5EF)]
	public class Help_CountryCode : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>ISO country code</summary>
		public string country_code;
		/// <summary>Possible phone prefixes</summary>
		[IfFlag(0)] public string[] prefixes;
		/// <summary>Phone patterns: for example, <c>XXX XXX XXX</c></summary>
		[IfFlag(1)] public string[] patterns;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="prefixes"/> has a value</summary>
			has_prefixes = 0x1,
			/// <summary>Field <see cref="patterns"/> has a value</summary>
			has_patterns = 0x2,
		}
	}

	/// <summary>Name, ISO code, localized name and phone codes/patterns of a specific country		<para>See <a href="https://corefork.telegram.org/constructor/help.country"/></para></summary>
	[TLDef(0xC3878E23)]
	public class Help_Country : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>ISO code of country</summary>
		public string iso2;
		/// <summary>Name of the country in the country's language</summary>
		public string default_name;
		/// <summary>Name of the country in the user's language, if different from the original name</summary>
		[IfFlag(1)] public string name;
		/// <summary>Phone codes/patterns</summary>
		public Help_CountryCode[] country_codes;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether this country should not be shown in the list</summary>
			hidden = 0x1,
			/// <summary>Field <see cref="name"/> has a value</summary>
			has_name = 0x2,
		}
	}

	/// <summary>Name, ISO code, localized name and phone codes/patterns of all available countries		<para>See <a href="https://corefork.telegram.org/constructor/help.countriesList"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.countriesListNotModified">help.countriesListNotModified</a></remarks>
	[TLDef(0x87D0759E)]
	public class Help_CountriesList : IObject
	{
		/// <summary>Name, ISO code, localized name and phone codes/patterns of all available countries</summary>
		public Help_Country[] countries;
		/// <summary><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></summary>
		public int hash;
	}

	/// <summary>View, forward counter + info about replies of a specific message		<para>See <a href="https://corefork.telegram.org/constructor/messageViews"/></para></summary>
	[TLDef(0x455B853D)]
	public class MessageViews : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>View count of message</summary>
		[IfFlag(0)] public int views;
		/// <summary>Forward count of message</summary>
		[IfFlag(1)] public int forwards;
		/// <summary>Reply and <a href="https://corefork.telegram.org/api/threads">thread</a> information of message</summary>
		[IfFlag(2)] public MessageReplies replies;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="views"/> has a value</summary>
			has_views = 0x1,
			/// <summary>Field <see cref="forwards"/> has a value</summary>
			has_forwards = 0x2,
			/// <summary>Field <see cref="replies"/> has a value</summary>
			has_replies = 0x4,
		}
	}

	/// <summary>View, forward counter + info about replies		<para>See <a href="https://corefork.telegram.org/constructor/messages.messageViews"/></para></summary>
	[TLDef(0xB6C4F543)]
	public class Messages_MessageViews : IObject, IPeerResolver
	{
		/// <summary>View, forward counter + info about replies</summary>
		public MessageViews[] views;
		/// <summary>Chats mentioned in constructor</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users mentioned in constructor</summary>
		public Dictionary<long, User> users;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}

	/// <summary>Information about a <a href="https://corefork.telegram.org/api/threads">message thread</a>		<para>See <a href="https://corefork.telegram.org/constructor/messages.discussionMessage"/></para></summary>
	[TLDef(0xA6341782)]
	public class Messages_DiscussionMessage : IObject, IPeerResolver
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Discussion messages</summary>
		public MessageBase[] messages;
		/// <summary>Message ID of latest reply in this <a href="https://corefork.telegram.org/api/threads">thread</a></summary>
		[IfFlag(0)] public int max_id;
		/// <summary>Message ID of latest read incoming message in this <a href="https://corefork.telegram.org/api/threads">thread</a></summary>
		[IfFlag(1)] public int read_inbox_max_id;
		/// <summary>Message ID of latest read outgoing message in this <a href="https://corefork.telegram.org/api/threads">thread</a></summary>
		[IfFlag(2)] public int read_outbox_max_id;
		/// <summary>Number of unread messages</summary>
		public int unread_count;
		/// <summary>Chats mentioned in constructor</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users mentioned in constructor</summary>
		public Dictionary<long, User> users;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="max_id"/> has a value</summary>
			has_max_id = 0x1,
			/// <summary>Field <see cref="read_inbox_max_id"/> has a value</summary>
			has_read_inbox_max_id = 0x2,
			/// <summary>Field <see cref="read_outbox_max_id"/> has a value</summary>
			has_read_outbox_max_id = 0x4,
		}
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}

	/// <summary>Message replies and <a href="https://corefork.telegram.org/api/threads">thread</a> information		<para>See <a href="https://corefork.telegram.org/constructor/messageReplyHeader"/></para></summary>
	[TLDef(0xA6D57763)]
	public class MessageReplyHeader : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>ID of message to which this message is replying</summary>
		public int reply_to_msg_id;
		/// <summary>For replies sent in <a href="https://corefork.telegram.org/api/threads">channel discussion threads</a> of which the current user is not a member, the discussion group ID</summary>
		[IfFlag(0)] public Peer reply_to_peer_id;
		/// <summary>ID of the message that started this <a href="https://corefork.telegram.org/api/threads">message thread</a></summary>
		[IfFlag(1)] public int reply_to_top_id;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="reply_to_peer_id"/> has a value</summary>
			has_reply_to_peer_id = 0x1,
			/// <summary>Field <see cref="reply_to_top_id"/> has a value</summary>
			has_reply_to_top_id = 0x2,
			reply_to_scheduled = 0x4,
		}
	}

	/// <summary>Info about <a href="https://corefork.telegram.org/api/threads">the comment section of a channel post, or a simple message thread</a>		<para>See <a href="https://corefork.telegram.org/constructor/messageReplies"/></para></summary>
	[TLDef(0x83D60FC2)]
	public class MessageReplies : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Contains the total number of replies in this thread or comment section.</summary>
		public int replies;
		/// <summary><a href="https://corefork.telegram.org/api/updates">PTS</a> of the message that started this thread.</summary>
		public int replies_pts;
		/// <summary>For channel post comments, contains information about the last few comment posters for a specific thread, to show a small list of commenter profile pictures in client previews.</summary>
		[IfFlag(1)] public Peer[] recent_repliers;
		/// <summary>For channel post comments, contains the ID of the associated <a href="https://corefork.telegram.org/api/discussion">discussion supergroup</a></summary>
		[IfFlag(0)] public long channel_id;
		/// <summary>ID of the latest message in this thread or comment section.</summary>
		[IfFlag(2)] public int max_id;
		/// <summary>Contains the ID of the latest read message in this thread or comment section.</summary>
		[IfFlag(3)] public int read_max_id;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether this constructor contains information about the <a href="https://corefork.telegram.org/api/threads">comment section of a channel post, or a simple message thread</a></summary>
			comments = 0x1,
			/// <summary>Field <see cref="recent_repliers"/> has a value</summary>
			has_recent_repliers = 0x2,
			/// <summary>Field <see cref="max_id"/> has a value</summary>
			has_max_id = 0x4,
			/// <summary>Field <see cref="read_max_id"/> has a value</summary>
			has_read_max_id = 0x8,
		}
	}

	/// <summary>Information about a blocked peer		<para>See <a href="https://corefork.telegram.org/constructor/peerBlocked"/></para></summary>
	[TLDef(0xE8FD8014)]
	public class PeerBlocked : IObject
	{
		/// <summary>Peer ID</summary>
		public Peer peer_id;
		/// <summary>When was the peer blocked</summary>
		public DateTime date;
	}

	/// <summary>Message statistics		<para>See <a href="https://corefork.telegram.org/constructor/stats.messageStats"/></para></summary>
	[TLDef(0x8999F295)]
	public class Stats_MessageStats : IObject
	{
		/// <summary>Message view graph</summary>
		public StatsGraphBase views_graph;
	}

	/// <summary>A group call		<para>Derived classes: <see cref="GroupCallDiscarded"/>, <see cref="GroupCall"/></para>		<para>See <a href="https://corefork.telegram.org/type/GroupCall"/></para></summary>
	public abstract class GroupCallBase : IObject
	{
		/// <summary>Group call ID</summary>
		public abstract long ID { get; }
		/// <summary>Group call access hash</summary>
		public abstract long AccessHash { get; }
	}
	/// <summary>An ended group call		<para>See <a href="https://corefork.telegram.org/constructor/groupCallDiscarded"/></para></summary>
	[TLDef(0x7780BCB4)]
	public class GroupCallDiscarded : GroupCallBase
	{
		/// <summary>Group call ID</summary>
		public long id;
		/// <summary>Group call access hash</summary>
		public long access_hash;
		/// <summary>Group call duration</summary>
		public int duration;

		/// <summary>Group call ID</summary>
		public override long ID => id;
		/// <summary>Group call access hash</summary>
		public override long AccessHash => access_hash;
	}
	/// <summary>Info about a group call or livestream		<para>See <a href="https://corefork.telegram.org/constructor/groupCall"/></para></summary>
	[TLDef(0xD597650C)]
	public class GroupCall : GroupCallBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Group call ID</summary>
		public long id;
		/// <summary>Group call access hash</summary>
		public long access_hash;
		/// <summary>Participant count</summary>
		public int participants_count;
		/// <summary>Group call title</summary>
		[IfFlag(3)] public string title;
		/// <summary>DC ID to be used for livestream chunks</summary>
		[IfFlag(4)] public int stream_dc_id;
		/// <summary>When was the recording started</summary>
		[IfFlag(5)] public DateTime record_start_date;
		/// <summary>When is the call scheduled to start</summary>
		[IfFlag(7)] public DateTime schedule_date;
		/// <summary>Number of people currently streaming video into the call</summary>
		[IfFlag(10)] public int unmuted_video_count;
		/// <summary>Maximum number of people allowed to stream video into the call</summary>
		public int unmuted_video_limit;
		/// <summary>Version</summary>
		public int version;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the user should be muted upon joining the call</summary>
			join_muted = 0x2,
			/// <summary>Whether the current user can change the value of the <c>join_muted</c> flag using <a href="https://corefork.telegram.org/method/phone.toggleGroupCallSettings">phone.toggleGroupCallSettings</a></summary>
			can_change_join_muted = 0x4,
			/// <summary>Field <see cref="title"/> has a value</summary>
			has_title = 0x8,
			/// <summary>Field <see cref="stream_dc_id"/> has a value</summary>
			has_stream_dc_id = 0x10,
			/// <summary>Field <see cref="record_start_date"/> has a value</summary>
			has_record_start_date = 0x20,
			/// <summary>Specifies the ordering to use when locally sorting by date and displaying in the UI group call participants.</summary>
			join_date_asc = 0x40,
			/// <summary>Field <see cref="schedule_date"/> has a value</summary>
			has_schedule_date = 0x80,
			/// <summary>Whether we subscribed to the scheduled call</summary>
			schedule_start_subscribed = 0x100,
			/// <summary>Whether you can start streaming video into the call</summary>
			can_start_video = 0x200,
			/// <summary>Field <see cref="unmuted_video_count"/> has a value</summary>
			has_unmuted_video_count = 0x400,
			/// <summary>Whether the group call is currently being recorded</summary>
			record_video_active = 0x800,
			/// <summary>Whether RTMP streams are allowed</summary>
			rtmp_stream = 0x1000,
			/// <summary>Whether the listeners list is hidden and cannot be fetched using <a href="https://corefork.telegram.org/method/phone.getGroupParticipants">phone.getGroupParticipants</a>. The <c>phone.groupParticipants.count</c> and <c>groupCall.participants_count</c> counters will still include listeners.</summary>
			listeners_hidden = 0x2000,
		}

		/// <summary>Group call ID</summary>
		public override long ID => id;
		/// <summary>Group call access hash</summary>
		public override long AccessHash => access_hash;
	}

	/// <summary>Points to a specific group call		<para>See <a href="https://corefork.telegram.org/constructor/inputGroupCall"/></para></summary>
	[TLDef(0xD8AA840F)]
	public class InputGroupCall : IObject
	{
		/// <summary>Group call ID</summary>
		public long id;
		/// <summary>⚠ <b>REQUIRED FIELD</b>. See <see href="https://github.com/wiz0u/WTelegramClient/blob/master/FAQ.md#access-hash">how to obtain it</see><br/>Group call access hash</summary>
		public long access_hash;
	}

	/// <summary>Info about a group call participant		<para>See <a href="https://corefork.telegram.org/constructor/groupCallParticipant"/></para></summary>
	[TLDef(0xEBA636FE)]
	public class GroupCallParticipant : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Peer information</summary>
		public Peer peer;
		/// <summary>When did this participant join the group call</summary>
		public DateTime date;
		/// <summary>When was this participant last active in the group call</summary>
		[IfFlag(3)] public DateTime active_date;
		/// <summary>Source ID</summary>
		public int source;
		/// <summary>Volume, if not set the volume is set to 100%.</summary>
		[IfFlag(7)] public int volume;
		/// <summary>Info about this participant</summary>
		[IfFlag(11)] public string about;
		/// <summary>Specifies the UI visualization order of peers with raised hands: peers with a higher rating should be showed first in the list.</summary>
		[IfFlag(13)] public long raise_hand_rating;
		/// <summary>Info about the video stream the participant is currently broadcasting</summary>
		[IfFlag(6)] public GroupCallParticipantVideo video;
		/// <summary>Info about the screen sharing stream the participant is currently broadcasting</summary>
		[IfFlag(14)] public GroupCallParticipantVideo presentation;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the participant is muted</summary>
			muted = 0x1,
			/// <summary>Whether the participant has left</summary>
			left = 0x2,
			/// <summary>Whether the participant can unmute themselves</summary>
			can_self_unmute = 0x4,
			/// <summary>Field <see cref="active_date"/> has a value</summary>
			has_active_date = 0x8,
			/// <summary>Whether the participant has just joined</summary>
			just_joined = 0x10,
			/// <summary>If set, and <see cref="UpdateGroupCallParticipants"/>.version &lt; locally stored call.version, info about this participant should be ignored. If (...), and <see cref="UpdateGroupCallParticipants"/>.version &gt; call.version+1, the participant list should be refetched using <a href="https://corefork.telegram.org/method/phone.getGroupParticipants">phone.getGroupParticipants</a>.</summary>
			versioned = 0x20,
			/// <summary>Field <see cref="video"/> has a value</summary>
			has_video = 0x40,
			/// <summary>Field <see cref="volume"/> has a value</summary>
			has_volume = 0x80,
			/// <summary>If not set, the <c>volume</c> and <c>muted_by_you</c> fields can be safely used to overwrite locally cached information; otherwise, <c>volume</c> will contain valid information only if <c>volume_by_admin</c> is set both in the cache and in the received constructor.</summary>
			min = 0x100,
			/// <summary>Whether this participant was muted by the current user</summary>
			muted_by_you = 0x200,
			/// <summary>Whether our volume can only changed by an admin</summary>
			volume_by_admin = 0x400,
			/// <summary>Field <see cref="about"/> has a value</summary>
			has_about = 0x800,
			/// <summary>Whether this participant is the current user</summary>
			self = 0x1000,
			/// <summary>Field <see cref="raise_hand_rating"/> has a value</summary>
			has_raise_hand_rating = 0x2000,
			/// <summary>Field <see cref="presentation"/> has a value</summary>
			has_presentation = 0x4000,
			/// <summary>Whether this participant is currently broadcasting video</summary>
			video_joined = 0x8000,
		}
	}

	/// <summary>Contains info about a group call, and partial info about its participants.		<para>See <a href="https://corefork.telegram.org/constructor/phone.groupCall"/></para></summary>
	[TLDef(0x9E727AAD)]
	public class Phone_GroupCall : IObject, IPeerResolver
	{
		/// <summary>Info about the group call</summary>
		public GroupCallBase call;
		/// <summary>A partial list of participants.</summary>
		public GroupCallParticipant[] participants;
		/// <summary>Next offset to use when fetching the remaining participants using <a href="https://corefork.telegram.org/method/phone.getGroupParticipants">phone.getGroupParticipants</a></summary>
		public string participants_next_offset;
		/// <summary>Chats mentioned in the participants vector</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users mentioned in the participants vector</summary>
		public Dictionary<long, User> users;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}

	/// <summary>Info about the participants of a group call or livestream		<para>See <a href="https://corefork.telegram.org/constructor/phone.groupParticipants"/></para></summary>
	[TLDef(0xF47751B6)]
	public class Phone_GroupParticipants : IObject, IPeerResolver
	{
		/// <summary>Number of participants</summary>
		public int count;
		/// <summary>List of participants</summary>
		public GroupCallParticipant[] participants;
		/// <summary>If not empty, the specified list of participants is partial, and more participants can be fetched specifying this parameter as <c>offset</c> in <a href="https://corefork.telegram.org/method/phone.getGroupParticipants">phone.getGroupParticipants</a>.</summary>
		public string next_offset;
		/// <summary>Mentioned chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Mentioned users</summary>
		public Dictionary<long, User> users;
		/// <summary>Version info</summary>
		public int version;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}

	/// <summary>Type of the chat from which the inline query was sent.		<para>See <a href="https://corefork.telegram.org/type/InlineQueryPeerType"/></para></summary>
	public enum InlineQueryPeerType : uint
	{
		///<summary>The inline query was sent in a private chat with the bot itself</summary>
		SameBotPM = 0x3081ED9D,
		///<summary>The inline query was sent in a private chat</summary>
		PM = 0x833C0FAC,
		///<summary>The inline query was sent in a <a href="https://corefork.telegram.org/api/channel">chat</a></summary>
		Chat = 0xD766C50A,
		///<summary>The inline query was sent in a <a href="https://corefork.telegram.org/api/channel">supergroup</a></summary>
		Megagroup = 0x5EC4BE43,
		///<summary>The inline query was sent in a <a href="https://corefork.telegram.org/api/channel">channel</a></summary>
		Broadcast = 0x6334EE9A,
	}

	/// <summary>ID of a specific <a href="https://corefork.telegram.org/api/import">chat import session, click here for more info »</a>.		<para>See <a href="https://corefork.telegram.org/constructor/messages.historyImport"/></para></summary>
	[TLDef(0x1662AF0B)]
	public class Messages_HistoryImport : IObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/import">History import ID</a></summary>
		public long id;
	}

	/// <summary>Contains information about a chat export file <a href="https://corefork.telegram.org/api/import">generated by a foreign chat app, click here for more info</a>.<br/>If neither the <c>pm</c> or <c>group</c> flags are set, the specified chat export was generated from a chat of unknown type.		<para>See <a href="https://corefork.telegram.org/constructor/messages.historyImportParsed"/></para></summary>
	[TLDef(0x5E0FB7B9)]
	public class Messages_HistoryImportParsed : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Title of the chat.</summary>
		[IfFlag(2)] public string title;

		[Flags] public enum Flags : uint
		{
			/// <summary>The chat export file was generated from a private chat.</summary>
			pm = 0x1,
			/// <summary>The chat export file was generated from a group chat.</summary>
			group = 0x2,
			/// <summary>Field <see cref="title"/> has a value</summary>
			has_title = 0x4,
		}
	}

	/// <summary>Messages found and affected by changes		<para>See <a href="https://corefork.telegram.org/constructor/messages.affectedFoundMessages"/></para></summary>
	[TLDef(0xEF8D3E6C)]
	public class Messages_AffectedFoundMessages : IObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/updates">Event count after generation</a></summary>
		public int pts;
		/// <summary><a href="https://corefork.telegram.org/api/updates">Number of events that were generated</a></summary>
		public int pts_count;
		/// <summary>If bigger than zero, the request must be repeated to remove more messages</summary>
		public int offset;
		/// <summary>Affected message IDs</summary>
		public int[] messages;
	}

	/// <summary>When and which user joined the chat using a chat invite		<para>See <a href="https://corefork.telegram.org/constructor/chatInviteImporter"/></para></summary>
	[TLDef(0x8C5ADFD9)]
	public class ChatInviteImporter : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The user</summary>
		public long user_id;
		/// <summary>When did the user join</summary>
		public DateTime date;
		/// <summary>For users with pending requests, contains bio of the user that requested to join</summary>
		[IfFlag(2)] public string about;
		/// <summary>The administrator that approved the <a href="https://corefork.telegram.org/api/invites#join-requests">join request »</a> of the user</summary>
		[IfFlag(1)] public long approved_by;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether this user currently has a pending <a href="https://corefork.telegram.org/api/invites#join-requests">join request »</a></summary>
			requested = 0x1,
			/// <summary>Field <see cref="approved_by"/> has a value</summary>
			has_approved_by = 0x2,
			/// <summary>Field <see cref="about"/> has a value</summary>
			has_about = 0x4,
		}
	}

	/// <summary>Info about chat invites exported by a certain admin.		<para>See <a href="https://corefork.telegram.org/constructor/messages.exportedChatInvites"/></para></summary>
	[TLDef(0xBDC62DCC)]
	public class Messages_ExportedChatInvites : IObject
	{
		/// <summary>Number of invites exported by the admin</summary>
		public int count;
		/// <summary>Exported invites</summary>
		public ExportedChatInvite[] invites;
		/// <summary>Info about the admin</summary>
		public Dictionary<long, User> users;
	}

	/// <summary>Contains info about a chat invite, and eventually a pointer to the newest chat invite.		<para>Derived classes: <see cref="Messages_ExportedChatInvite"/>, <see cref="Messages_ExportedChatInviteReplaced"/></para>		<para>See <a href="https://corefork.telegram.org/type/messages.ExportedChatInvite"/></para></summary>
	public abstract class Messages_ExportedChatInviteBase : IObject
	{
		/// <summary>Info about the chat invite</summary>
		public abstract ExportedChatInvite Invite { get; }
		/// <summary>Mentioned users</summary>
		public abstract Dictionary<long, User> Users { get; }
	}
	/// <summary>Info about a chat invite		<para>See <a href="https://corefork.telegram.org/constructor/messages.exportedChatInvite"/></para></summary>
	[TLDef(0x1871BE50)]
	public class Messages_ExportedChatInvite : Messages_ExportedChatInviteBase
	{
		/// <summary>Info about the chat invite</summary>
		public ExportedChatInvite invite;
		/// <summary>Mentioned users</summary>
		public Dictionary<long, User> users;

		/// <summary>Info about the chat invite</summary>
		public override ExportedChatInvite Invite => invite;
		/// <summary>Mentioned users</summary>
		public override Dictionary<long, User> Users => users;
	}
	/// <summary>The specified chat invite was replaced with another one		<para>See <a href="https://corefork.telegram.org/constructor/messages.exportedChatInviteReplaced"/></para></summary>
	[TLDef(0x222600EF)]
	public class Messages_ExportedChatInviteReplaced : Messages_ExportedChatInviteBase
	{
		/// <summary>The replaced chat invite</summary>
		public ExportedChatInvite invite;
		/// <summary>The invite that replaces the previous invite</summary>
		public ExportedChatInvite new_invite;
		/// <summary>Mentioned users</summary>
		public Dictionary<long, User> users;

		/// <summary>The replaced chat invite</summary>
		public override ExportedChatInvite Invite => invite;
		/// <summary>Mentioned users</summary>
		public override Dictionary<long, User> Users => users;
	}

	/// <summary>Info about the users that joined the chat using a specific chat invite		<para>See <a href="https://corefork.telegram.org/constructor/messages.chatInviteImporters"/></para></summary>
	[TLDef(0x81B6B00A)]
	public class Messages_ChatInviteImporters : IObject
	{
		/// <summary>Number of users that joined</summary>
		public int count;
		/// <summary>The users that joined</summary>
		public ChatInviteImporter[] importers;
		/// <summary>The users that joined</summary>
		public Dictionary<long, User> users;
	}

	/// <summary>Info about chat invites generated by admins.		<para>See <a href="https://corefork.telegram.org/constructor/chatAdminWithInvites"/></para></summary>
	[TLDef(0xF2ECEF23)]
	public class ChatAdminWithInvites : IObject
	{
		/// <summary>The admin</summary>
		public long admin_id;
		/// <summary>Number of invites generated by the admin</summary>
		public int invites_count;
		/// <summary>Number of revoked invites</summary>
		public int revoked_invites_count;
	}

	/// <summary>Info about chat invites generated by admins.		<para>See <a href="https://corefork.telegram.org/constructor/messages.chatAdminsWithInvites"/></para></summary>
	[TLDef(0xB69B72D7)]
	public class Messages_ChatAdminsWithInvites : IObject
	{
		/// <summary>Info about chat invites generated by admins.</summary>
		public ChatAdminWithInvites[] admins;
		/// <summary>Mentioned users</summary>
		public Dictionary<long, User> users;
	}

	/// <summary>Contains a confirmation text to be shown to the user, upon <a href="https://corefork.telegram.org/api/import">importing chat history, click here for more info »</a>.		<para>See <a href="https://corefork.telegram.org/constructor/messages.checkedHistoryImportPeer"/></para></summary>
	[TLDef(0xA24DE717)]
	public class Messages_CheckedHistoryImportPeer : IObject
	{
		/// <summary>A confirmation text to be shown to the user, upon <a href="https://corefork.telegram.org/api/import">importing chat history »</a>.</summary>
		public string confirm_text;
	}

	/// <summary>A list of peers that can be used to join a group call, presenting yourself as a specific user/channel.		<para>See <a href="https://corefork.telegram.org/constructor/phone.joinAsPeers"/></para></summary>
	[TLDef(0xAFE5623F)]
	public class Phone_JoinAsPeers : IObject, IPeerResolver
	{
		/// <summary>Peers</summary>
		public Peer[] peers;
		/// <summary>Chats mentioned in the peers vector</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users mentioned in the peers vector</summary>
		public Dictionary<long, User> users;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}

	/// <summary>An invite to a group call or livestream		<para>See <a href="https://corefork.telegram.org/constructor/phone.exportedGroupCallInvite"/></para></summary>
	[TLDef(0x204BD158)]
	public class Phone_ExportedGroupCallInvite : IObject
	{
		/// <summary>Invite link</summary>
		public string link;
	}

	/// <summary>Describes a group of video synchronization source identifiers		<para>See <a href="https://corefork.telegram.org/constructor/groupCallParticipantVideoSourceGroup"/></para></summary>
	[TLDef(0xDCB118B7)]
	public class GroupCallParticipantVideoSourceGroup : IObject
	{
		/// <summary>SDP semantics</summary>
		public string semantics;
		/// <summary>Source IDs</summary>
		public int[] sources;
	}

	/// <summary>Info about a video stream		<para>See <a href="https://corefork.telegram.org/constructor/groupCallParticipantVideo"/></para></summary>
	[TLDef(0x67753AC8)]
	public class GroupCallParticipantVideo : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Endpoint</summary>
		public string endpoint;
		/// <summary>Source groups</summary>
		public GroupCallParticipantVideoSourceGroup[] source_groups;
		/// <summary>Audio source ID</summary>
		[IfFlag(1)] public int audio_source;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the stream is currently paused</summary>
			paused = 0x1,
			/// <summary>Field <see cref="audio_source"/> has a value</summary>
			has_audio_source = 0x2,
		}
	}

	/// <summary>A suggested short name for a stickerpack		<para>See <a href="https://corefork.telegram.org/constructor/stickers.suggestedShortName"/></para></summary>
	[TLDef(0x85FEA03F)]
	public class Stickers_SuggestedShortName : IObject
	{
		/// <summary>Suggested short name</summary>
		public string short_name;
	}

	/// <summary>Represents a scope where the bot commands, specified using <a href="https://corefork.telegram.org/method/bots.setBotCommands">bots.setBotCommands</a> will be valid.		<para>Derived classes: <see cref="BotCommandScopeDefault"/>, <see cref="BotCommandScopeUsers"/>, <see cref="BotCommandScopeChats"/>, <see cref="BotCommandScopeChatAdmins"/>, <see cref="BotCommandScopePeer"/>, <see cref="BotCommandScopePeerAdmins"/>, <see cref="BotCommandScopePeerUser"/></para>		<para>See <a href="https://corefork.telegram.org/type/BotCommandScope"/></para></summary>
	public abstract class BotCommandScope : IObject { }
	/// <summary>The commands will be valid in all dialogs		<para>See <a href="https://corefork.telegram.org/constructor/botCommandScopeDefault"/></para></summary>
	[TLDef(0x2F6CB2AB)]
	public class BotCommandScopeDefault : BotCommandScope { }
	/// <summary>The specified bot commands will only be valid in all private chats with users.		<para>See <a href="https://corefork.telegram.org/constructor/botCommandScopeUsers"/></para></summary>
	[TLDef(0x3C4F04D8)]
	public class BotCommandScopeUsers : BotCommandScope { }
	/// <summary>The specified bot commands will be valid in all <a href="https://corefork.telegram.org/api/channel">groups and supergroups</a>.		<para>See <a href="https://corefork.telegram.org/constructor/botCommandScopeChats"/></para></summary>
	[TLDef(0x6FE1A881)]
	public class BotCommandScopeChats : BotCommandScope { }
	/// <summary>The specified bot commands will be valid only for chat administrators, in all <a href="https://corefork.telegram.org/api/channel">groups and supergroups</a>.		<para>See <a href="https://corefork.telegram.org/constructor/botCommandScopeChatAdmins"/></para></summary>
	[TLDef(0xB9AA606A)]
	public class BotCommandScopeChatAdmins : BotCommandScope { }
	/// <summary>The specified bot commands will be valid only in a specific dialog.		<para>See <a href="https://corefork.telegram.org/constructor/botCommandScopePeer"/></para></summary>
	[TLDef(0xDB9D897D)]
	public class BotCommandScopePeer : BotCommandScope
	{
		/// <summary>The dialog</summary>
		public InputPeer peer;
	}
	/// <summary>The specified bot commands will be valid for all admins of the specified <a href="https://corefork.telegram.org/api/channel">group or supergroup</a>.		<para>See <a href="https://corefork.telegram.org/constructor/botCommandScopePeerAdmins"/></para></summary>
	[TLDef(0x3FD863D1)]
	public class BotCommandScopePeerAdmins : BotCommandScopePeer { }
	/// <summary>The specified bot commands will be valid only for a specific user in the specified <a href="https://corefork.telegram.org/api/channel">group or supergroup</a>.		<para>See <a href="https://corefork.telegram.org/constructor/botCommandScopePeerUser"/></para></summary>
	[TLDef(0x0A1321F3, inheritBefore = true)]
	public class BotCommandScopePeerUser : BotCommandScopePeer
	{
		/// <summary>The user</summary>
		public InputUserBase user_id;
	}

	/// <summary>Result of an <a href="https://corefork.telegram.org/method/account.resetPassword">account.resetPassword</a> request.		<para>Derived classes: <see cref="Account_ResetPasswordFailedWait"/>, <see cref="Account_ResetPasswordRequestedWait"/>, <see cref="Account_ResetPasswordOk"/></para>		<para>See <a href="https://corefork.telegram.org/type/account.ResetPasswordResult"/></para></summary>
	public abstract class Account_ResetPasswordResult : IObject { }
	/// <summary>You recently requested a password reset that was canceled, please wait until the specified date before requesting another reset.		<para>See <a href="https://corefork.telegram.org/constructor/account.resetPasswordFailedWait"/></para></summary>
	[TLDef(0xE3779861)]
	public class Account_ResetPasswordFailedWait : Account_ResetPasswordResult
	{
		/// <summary>Wait until this date before requesting another reset.</summary>
		public DateTime retry_date;
	}
	/// <summary>You successfully requested a password reset, please wait until the specified date before finalizing the reset.		<para>See <a href="https://corefork.telegram.org/constructor/account.resetPasswordRequestedWait"/></para></summary>
	[TLDef(0xE9EFFC7D)]
	public class Account_ResetPasswordRequestedWait : Account_ResetPasswordResult
	{
		/// <summary>Wait until this date before finalizing the reset.</summary>
		public DateTime until_date;
	}
	/// <summary>The 2FA password was reset successfully.		<para>See <a href="https://corefork.telegram.org/constructor/account.resetPasswordOk"/></para></summary>
	[TLDef(0xE926D63E)]
	public class Account_ResetPasswordOk : Account_ResetPasswordResult { }

	/// <summary>A <a href="https://core.telegram.org/api/sponsored-messages">sponsored message</a>.		<para>See <a href="https://corefork.telegram.org/constructor/sponsoredMessage"/></para></summary>
	[TLDef(0x3A836DF8)]
	public class SponsoredMessage : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Message ID</summary>
		public byte[] random_id;
		/// <summary>ID of the sender of the message</summary>
		[IfFlag(3)] public Peer from_id;
		/// <summary>Information about the chat invite hash specified in <c>chat_invite_hash</c></summary>
		[IfFlag(4)] public ChatInviteBase chat_invite;
		/// <summary>Chat invite</summary>
		[IfFlag(4)] public string chat_invite_hash;
		/// <summary>Optional link to a channel post if <c>from_id</c> points to a channel</summary>
		[IfFlag(2)] public int channel_post;
		/// <summary>Parameter for the bot start message if the sponsored chat is a chat with a bot.</summary>
		[IfFlag(0)] public string start_param;
		/// <summary>Sponsored message</summary>
		public string message;
		/// <summary><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></summary>
		[IfFlag(1)] public MessageEntity[] entities;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="start_param"/> has a value</summary>
			has_start_param = 0x1,
			/// <summary>Field <see cref="entities"/> has a value</summary>
			has_entities = 0x2,
			/// <summary>Field <see cref="channel_post"/> has a value</summary>
			has_channel_post = 0x4,
			/// <summary>Field <see cref="from_id"/> has a value</summary>
			has_from_id = 0x8,
			/// <summary>Field <see cref="chat_invite"/> has a value</summary>
			has_chat_invite = 0x10,
			recommended = 0x20,
		}
	}

	/// <summary>A set of sponsored messages associated to a channel		<para>See <a href="https://corefork.telegram.org/constructor/messages.sponsoredMessages"/></para></summary>
	[TLDef(0x65A4C7D5)]
	public class Messages_SponsoredMessages : IObject, IPeerResolver
	{
		/// <summary>Sponsored messages</summary>
		public SponsoredMessage[] messages;
		/// <summary>Chats mentioned in the sponsored messages</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users mentioned in the sponsored messages</summary>
		public Dictionary<long, User> users;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}

	/// <summary>Information about found messages sent on a specific day, used to split the <c>messages</c> in <see cref="Messages_SearchResultsCalendar"/> constructors by days.		<para>See <a href="https://corefork.telegram.org/constructor/searchResultsCalendarPeriod"/></para></summary>
	[TLDef(0xC9B0539F)]
	public class SearchResultsCalendarPeriod : IObject
	{
		/// <summary>The day this object is referring to.</summary>
		public DateTime date;
		/// <summary>First message ID that was sent on this day.</summary>
		public int min_msg_id;
		/// <summary>Last message ID that was sent on this day.</summary>
		public int max_msg_id;
		/// <summary>All messages that were sent on this day.</summary>
		public int count;
	}

	/// <summary>Information about found messages sent on a specific day		<para>See <a href="https://corefork.telegram.org/constructor/messages.searchResultsCalendar"/></para></summary>
	[TLDef(0x147EE23C)]
	public class Messages_SearchResultsCalendar : IObject, IPeerResolver
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Total number of results matching query</summary>
		public int count;
		/// <summary>Starting timestamp of attached messages</summary>
		public DateTime min_date;
		/// <summary>Ending timestamp of attached messages</summary>
		public int min_msg_id;
		/// <summary>Indicates the absolute position of <c>messages[0]</c> within the total result set with count <c>count</c>. <br/>This is useful, for example, if we need to display a <c>progress/total</c> counter (like <c>photo 134 of 200</c>, for all media in a chat, we could simply use <c>photo ${offset_id_offset} of ${count}</c>.</summary>
		[IfFlag(1)] public int offset_id_offset;
		/// <summary>Used to split the <c>messages</c> by days: multiple <see cref="SearchResultsCalendarPeriod"/> constructors are returned, each containing information about the first, last and total number of messages matching the filter that were sent on a specific day.  <br/>This information can be easily used to split the returned <c>messages</c> by day.</summary>
		public SearchResultsCalendarPeriod[] periods;
		/// <summary>Messages</summary>
		public MessageBase[] messages;
		/// <summary>Mentioned chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Mentioned users</summary>
		public Dictionary<long, User> users;

		[Flags] public enum Flags : uint
		{
			/// <summary>If set, indicates that the results may be inexact</summary>
			inexact = 0x1,
			/// <summary>Field <see cref="offset_id_offset"/> has a value</summary>
			has_offset_id_offset = 0x2,
		}
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}

	/// <summary>Information about a message in a specific position		<para>Derived classes: <see cref="SearchResultPosition"/></para>		<para>See <a href="https://corefork.telegram.org/type/SearchResultsPosition"/></para></summary>
	public abstract class SearchResultsPosition : IObject { }
	/// <summary>Information about a message in a specific position		<para>See <a href="https://corefork.telegram.org/constructor/searchResultPosition"/></para></summary>
	[TLDef(0x7F648B67)]
	public class SearchResultPosition : SearchResultsPosition
	{
		/// <summary>Message ID</summary>
		public int msg_id;
		/// <summary>When was the message sent</summary>
		public DateTime date;
		/// <summary>0-based message position in the full list of suitable messages</summary>
		public int offset;
	}

	/// <summary>Information about sparse positions of messages		<para>See <a href="https://corefork.telegram.org/constructor/messages.searchResultsPositions"/></para></summary>
	[TLDef(0x53B22BAF)]
	public class Messages_SearchResultsPositions : IObject
	{
		/// <summary>Total number of found messages</summary>
		public int count;
		/// <summary>List of message positions</summary>
		public SearchResultsPosition[] positions;
	}

	/// <summary>A list of peers that can be used to send messages in a specific group		<para>See <a href="https://corefork.telegram.org/constructor/channels.sendAsPeers"/></para></summary>
	[TLDef(0x8356CDA9)]
	public class Channels_SendAsPeers : IObject, IPeerResolver
	{
		/// <summary>Peers that can be used to send messages to the group</summary>
		public Peer[] peers;
		/// <summary>Mentioned chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Mentioned users</summary>
		public Dictionary<long, User> users;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}

	/// <summary>Full user information		<para>See <a href="https://corefork.telegram.org/constructor/users.userFull"/></para></summary>
	[TLDef(0x3B6D152E)]
	public class Users_UserFull : IObject, IPeerResolver
	{
		/// <summary>Full user information</summary>
		public UserFull full_user;
		/// <summary>Mentioned chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Mentioned users</summary>
		public Dictionary<long, User> users;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}

	/// <summary>Peer settings		<para>See <a href="https://corefork.telegram.org/constructor/messages.peerSettings"/></para></summary>
	[TLDef(0x6880B94D)]
	public class Messages_PeerSettings : IObject, IPeerResolver
	{
		/// <summary>Peer settings</summary>
		public PeerSettings settings;
		/// <summary>Mentioned chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Mentioned users</summary>
		public Dictionary<long, User> users;
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}

	/// <summary><a href="https://corefork.telegram.org/api/auth#logout-tokens">Logout token »</a> to be used on subsequent authorizations		<para>See <a href="https://corefork.telegram.org/constructor/auth.loggedOut"/></para></summary>
	[TLDef(0xC3A2835F)]
	public class Auth_LoggedOut : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary><a href="https://corefork.telegram.org/api/auth#logout-tokens">Logout token »</a> to be used on subsequent authorizations</summary>
		[IfFlag(0)] public byte[] future_auth_token;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="future_auth_token"/> has a value</summary>
			has_future_auth_token = 0x1,
		}
	}

	/// <summary>Reactions		<para>See <a href="https://corefork.telegram.org/constructor/reactionCount"/></para></summary>
	[TLDef(0x6FB250D1)]
	public class ReactionCount : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Reaction (a UTF8 emoji)</summary>
		public string reaction;
		/// <summary>NUmber of users that reacted with this emoji</summary>
		public int count;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the current user sent this reaction</summary>
			chosen = 0x1,
		}
	}

	/// <summary><a href="https://corefork.telegram.org/api/reactions">Message reactions »</a>		<para>See <a href="https://corefork.telegram.org/constructor/messageReactions"/></para></summary>
	[TLDef(0x4F2B9479)]
	public class MessageReactions : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Reactions</summary>
		public ReactionCount[] results;
		/// <summary>List of recent peers and their reactions</summary>
		[IfFlag(1)] public MessagePeerReaction[] recent_reactions;

		[Flags] public enum Flags : uint
		{
			/// <summary>Similar to <a href="https://corefork.telegram.org/api/min">min</a> objects, used for <a href="https://corefork.telegram.org/api/reactions">message reaction »</a> constructors that are the same for all users so they don't have the reactions sent by the current user (you can use <a href="https://corefork.telegram.org/method/messages.getMessagesReactions">messages.getMessagesReactions</a> to get the full reaction info).</summary>
			min = 0x1,
			/// <summary>Field <see cref="recent_reactions"/> has a value</summary>
			has_recent_reactions = 0x2,
			/// <summary>Whether <a href="https://corefork.telegram.org/method/messages.getMessageReactionsList">messages.getMessageReactionsList</a> can be used to see how each specific peer reacted to the message</summary>
			can_see_list = 0x4,
		}
	}

	/// <summary>List of peers that reacted to a specific message		<para>See <a href="https://corefork.telegram.org/constructor/messages.messageReactionsList"/></para></summary>
	[TLDef(0x31BD492D)]
	public class Messages_MessageReactionsList : IObject, IPeerResolver
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Total number of reactions matching query</summary>
		public int count;
		/// <summary>List of peers that reacted to a specific message</summary>
		public MessagePeerReaction[] reactions;
		/// <summary>Mentioned chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Mentioned users</summary>
		public Dictionary<long, User> users;
		/// <summary>If set, indicates the next offset to use to load more results by invoking <a href="https://corefork.telegram.org/method/messages.getMessageReactionsList">messages.getMessageReactionsList</a>.</summary>
		[IfFlag(0)] public string next_offset;

		[Flags] public enum Flags : uint
		{
			/// <summary>Field <see cref="next_offset"/> has a value</summary>
			has_next_offset = 0x1,
		}
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(users, chats);
	}

	/// <summary>Animations associated with a message reaction		<para>See <a href="https://corefork.telegram.org/constructor/availableReaction"/></para></summary>
	[TLDef(0xC077EC01)]
	public class AvailableReaction : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Reaction emoji</summary>
		public string reaction;
		/// <summary>Reaction description</summary>
		public string title;
		/// <summary>Static icon for the reaction</summary>
		public DocumentBase static_icon;
		/// <summary>The animated sticker to show when the user opens the reaction dropdown</summary>
		public DocumentBase appear_animation;
		/// <summary>The animated sticker to show when the user selects this reaction</summary>
		public DocumentBase select_animation;
		/// <summary>The animated sticker to show when the reaction is chosen and activated</summary>
		public DocumentBase activate_animation;
		/// <summary>The background effect (still an animated sticker) to play under the <c>activate_animation</c>, when the reaction is chosen and activated</summary>
		public DocumentBase effect_animation;
		/// <summary>The animation that plays around the button when you press an existing reaction (played together with <c>center_icon</c>).</summary>
		[IfFlag(1)] public DocumentBase around_animation;
		/// <summary>The animation of the emoji inside the button when you press an existing reaction (played together with <c>around_animation</c>).</summary>
		[IfFlag(1)] public DocumentBase center_icon;

		[Flags] public enum Flags : uint
		{
			/// <summary>If not set, the reaction can be added to new messages and enabled in chats.</summary>
			inactive = 0x1,
			/// <summary>Field <see cref="around_animation"/> has a value</summary>
			has_around_animation = 0x2,
		}
	}

	/// <summary>Animations and metadata associated with <a href="https://corefork.telegram.org/api/reactions">message reactions »</a>		<para>See <a href="https://corefork.telegram.org/constructor/messages.availableReactions"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.availableReactionsNotModified">messages.availableReactionsNotModified</a></remarks>
	[TLDef(0x768E3AAD)]
	public class Messages_AvailableReactions : IObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></summary>
		public int hash;
		/// <summary>Animations and metadata associated with <a href="https://corefork.telegram.org/api/reactions">message reactions »</a></summary>
		public AvailableReaction[] reactions;
	}

	/// <summary>Translated text, or no result		<para>Derived classes: <see cref="Messages_TranslateNoResult"/>, <see cref="Messages_TranslateResultText"/></para>		<para>See <a href="https://corefork.telegram.org/type/messages.TranslatedText"/></para></summary>
	public abstract class Messages_TranslatedText : IObject { }
	/// <summary>No translation is available		<para>See <a href="https://corefork.telegram.org/constructor/messages.translateNoResult"/></para></summary>
	[TLDef(0x67CA4737)]
	public class Messages_TranslateNoResult : Messages_TranslatedText { }
	/// <summary>Translated text		<para>See <a href="https://corefork.telegram.org/constructor/messages.translateResultText"/></para></summary>
	[TLDef(0xA214F7D0)]
	public class Messages_TranslateResultText : Messages_TranslatedText
	{
		/// <summary>Translated text</summary>
		public string text;
	}

	/// <summary>How a certain peer reacted to the message		<para>See <a href="https://corefork.telegram.org/constructor/messagePeerReaction"/></para></summary>
	[TLDef(0x51B67EFF)]
	public class MessagePeerReaction : IObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Peer that reacted to the message</summary>
		public Peer peer_id;
		/// <summary>Reaction emoji</summary>
		public string reaction;

		[Flags] public enum Flags : uint
		{
			/// <summary>Whether the specified <a href="https://corefork.telegram.org/api/reactions">message reaction »</a> should elicit a bigger and longer reaction</summary>
			big = 0x1,
			/// <summary>Whether the reaction wasn't yet marked as read by the current user</summary>
			unread = 0x2,
		}
	}

	/// <summary>Info about an RTMP stream in a group call or livestream		<para>See <a href="https://corefork.telegram.org/constructor/groupCallStreamChannel"/></para></summary>
	[TLDef(0x80EB48AF)]
	public class GroupCallStreamChannel : IObject
	{
		/// <summary>Channel ID</summary>
		public int channel;
		/// <summary>Specifies the duration of the video segment to fetch in milliseconds, by bitshifting <c>1000</c> to the right <c>scale</c> times: <c>duration_ms := 1000 &gt;&gt; scale</c>.</summary>
		public int scale;
		/// <summary>Last seen timestamp to easily start fetching livestream chunks using <see cref="InputGroupCallStream"/></summary>
		public long last_timestamp_ms;
	}

	/// <summary>Info about RTMP streams in a group call or livestream		<para>See <a href="https://corefork.telegram.org/constructor/phone.groupCallStreamChannels"/></para></summary>
	[TLDef(0xD0E482B2)]
	public class Phone_GroupCallStreamChannels : IObject
	{
		/// <summary>RTMP streams</summary>
		public GroupCallStreamChannel[] channels;
	}

	/// <summary>RTMP URL and stream key to be used in streaming software		<para>See <a href="https://corefork.telegram.org/constructor/phone.groupCallStreamRtmpUrl"/></para></summary>
	[TLDef(0x2DBF3432)]
	public class Phone_GroupCallStreamRtmpUrl : IObject
	{
		/// <summary>RTMP URL</summary>
		public string url;
		/// <summary>Stream key</summary>
		public string key;
	}

	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/attachMenuBotIconColor"/></para></summary>
	[TLDef(0x4576F3F0)]
	public class AttachMenuBotIconColor : IObject
	{
		public string name;
		public int color;
	}

	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/attachMenuBotIcon"/></para></summary>
	[TLDef(0xB2A7386B)]
	public class AttachMenuBotIcon : IObject
	{
		public Flags flags;
		public string name;
		public DocumentBase icon;
		[IfFlag(0)] public AttachMenuBotIconColor[] colors;

		[Flags] public enum Flags : uint
		{
			has_colors = 0x1,
		}
	}

	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/attachMenuBot"/></para></summary>
	[TLDef(0xE93CB772)]
	public class AttachMenuBot : IObject
	{
		public Flags flags;
		public long bot_id;
		public string short_name;
		public AttachMenuBotIcon[] icons;

		[Flags] public enum Flags : uint
		{
			inactive = 0x1,
		}
	}

	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/attachMenuBots"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/attachMenuBotsNotModified">attachMenuBotsNotModified</a></remarks>
	[TLDef(0x3C4301C0)]
	public class AttachMenuBots : IObject
	{
		public long hash;
		public AttachMenuBot[] bots;
		public Dictionary<long, User> users;
	}

	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/attachMenuBotsBot"/></para></summary>
	[TLDef(0x93BF667F)]
	public class AttachMenuBotsBot : IObject
	{
		public AttachMenuBot bot;
		public Dictionary<long, User> users;
	}

	/// <summary><para>See <a href="https://corefork.telegram.org/type/WebViewResult"/></para></summary>
	public abstract class WebViewResult : IObject { }
	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/webViewResultUrl"/></para></summary>
	[TLDef(0x0C14557C)]
	public class WebViewResultUrl : WebViewResult
	{
		public long query_id;
		public string url;
	}

	/// <summary><para>See <a href="https://corefork.telegram.org/type/SimpleWebViewResult"/></para></summary>
	public abstract class SimpleWebViewResult : IObject { }
	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/simpleWebViewResultUrl"/></para></summary>
	[TLDef(0x882F76BB)]
	public class SimpleWebViewResultUrl : SimpleWebViewResult
	{
		public string url;
	}

	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/webViewMessageSent"/></para></summary>
	[TLDef(0x0C94511C)]
	public class WebViewMessageSent : IObject
	{
		public Flags flags;
		[IfFlag(0)] public InputBotInlineMessageIDBase msg_id;

		[Flags] public enum Flags : uint
		{
			has_msg_id = 0x1,
		}
	}

	/// <summary><para>See <a href="https://corefork.telegram.org/type/BotMenuButton"/></para></summary>
	public abstract class BotMenuButtonBase : IObject { }
	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/botMenuButtonDefault"/></para></summary>
	[TLDef(0x7533A588)]
	public class BotMenuButtonDefault : BotMenuButtonBase { }
	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/botMenuButtonCommands"/></para></summary>
	[TLDef(0x4258C205)]
	public class BotMenuButtonCommands : BotMenuButtonBase { }
	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/botMenuButton"/></para></summary>
	[TLDef(0xC7B57CE6)]
	public class BotMenuButton : BotMenuButtonBase
	{
		public string text;
		public string url;
	}

	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/account.savedRingtones"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/account.savedRingtonesNotModified">account.savedRingtonesNotModified</a></remarks>
	[TLDef(0xC1E92CC5)]
	public class Account_SavedRingtones : IObject
	{
		public long hash;
		public DocumentBase[] ringtones;
	}

	/// <summary><para>See <a href="https://corefork.telegram.org/type/NotificationSound"/></para></summary>
	public abstract class NotificationSound : IObject { }
	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/notificationSoundDefault"/></para></summary>
	[TLDef(0x97E8BEBE)]
	public class NotificationSoundDefault : NotificationSound { }
	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/notificationSoundNone"/></para></summary>
	[TLDef(0x6F0C34DF)]
	public class NotificationSoundNone : NotificationSound { }
	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/notificationSoundLocal"/></para></summary>
	[TLDef(0x830B9AE4)]
	public class NotificationSoundLocal : NotificationSound
	{
		public string title;
		public string data;
	}
	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/notificationSoundRingtone"/></para></summary>
	[TLDef(0xFF6C8049)]
	public class NotificationSoundRingtone : NotificationSound
	{
		public long id;
	}

	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/account.savedRingtone"/></para></summary>
	[TLDef(0xB7263F6D)]
	public class Account_SavedRingtone : IObject { }
	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/account.savedRingtoneConverted"/></para></summary>
	[TLDef(0x1F307EB7)]
	public class Account_SavedRingtoneConverted : Account_SavedRingtone
	{
		public DocumentBase document;
	}
}
