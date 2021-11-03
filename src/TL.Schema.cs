// This file is generated automatically using the Generator class
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TL
{
	using BinaryWriter = System.IO.BinaryWriter;
	using Client = WTelegram.Client;

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
	public partial class True : ITLObject { }

	/// <summary>Error.		<para>See <a href="https://corefork.telegram.org/constructor/error"/></para></summary>
	[TLDef(0xC4B9F9BB)]
	public partial class Error : ITLObject
	{
		/// <summary>Error code</summary>
		public int code;
		/// <summary>Message</summary>
		public string text;
	}

	/// <summary>Corresponds to an arbitrary empty object.		<para>See <a href="https://corefork.telegram.org/constructor/null"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/null">null</a></remarks>
	[TLDef(0x56730BCC)]
	public partial class Null : ITLObject { }

	/// <summary>Peer		<para>Derived classes: <see cref="InputPeerSelf"/>, <see cref="InputPeerChat"/>, <see cref="InputPeerUser"/>, <see cref="InputPeerChannel"/>, <see cref="InputPeerUserFromMessage"/>, <see cref="InputPeerChannelFromMessage"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputPeer"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputPeerEmpty">inputPeerEmpty</a></remarks>
	public abstract partial class InputPeer : ITLObject { }
	/// <summary>Defines the current user.		<para>See <a href="https://corefork.telegram.org/constructor/inputPeerSelf"/></para></summary>
	[TLDef(0x7DA07EC9)]
	public partial class InputPeerSelf : InputPeer { }
	/// <summary>Defines a chat for further interaction.		<para>See <a href="https://corefork.telegram.org/constructor/inputPeerChat"/></para></summary>
	[TLDef(0x35A95CB9)]
	public partial class InputPeerChat : InputPeer
	{
		/// <summary>Chat idientifier</summary>
		public long chat_id;
	}
	/// <summary>Defines a user for further interaction.		<para>See <a href="https://corefork.telegram.org/constructor/inputPeerUser"/></para></summary>
	[TLDef(0xDDE8A54C)]
	public partial class InputPeerUser : InputPeer
	{
		/// <summary>User identifier</summary>
		public long user_id;
		/// <summary><strong>access_hash</strong> value from the <see cref="User"/> constructor</summary>
		public long access_hash;
	}
	/// <summary>Defines a channel for further interaction.		<para>See <a href="https://corefork.telegram.org/constructor/inputPeerChannel"/></para></summary>
	[TLDef(0x27BCBBFC)]
	public partial class InputPeerChannel : InputPeer
	{
		/// <summary>Channel identifier</summary>
		public long channel_id;
		/// <summary><strong>access_hash</strong> value from the <see cref="Channel"/> constructor</summary>
		public long access_hash;
	}
	/// <summary>Defines a <a href="https://corefork.telegram.org/api/min">min</a> user that was seen in a certain message of a certain chat.		<para>See <a href="https://corefork.telegram.org/constructor/inputPeerUserFromMessage"/></para></summary>
	[TLDef(0xA87B0A1C)]
	public partial class InputPeerUserFromMessage : InputPeer
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
	public partial class InputPeerChannelFromMessage : InputPeer
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
	public abstract partial class InputUserBase : ITLObject { }
	/// <summary>Defines the current user.		<para>See <a href="https://corefork.telegram.org/constructor/inputUserSelf"/></para></summary>
	[TLDef(0xF7C1B13F)]
	public partial class InputUserSelf : InputUserBase { }
	/// <summary>Defines a user for further interaction.		<para>See <a href="https://corefork.telegram.org/constructor/inputUser"/></para></summary>
	[TLDef(0xF21158C6)]
	public partial class InputUser : InputUserBase
	{
		/// <summary>User identifier</summary>
		public long user_id;
		/// <summary><strong>access_hash</strong> value from the <see cref="User"/> constructor</summary>
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

	/// <summary>Object defines a contact from the user's phonebook.		<para>Derived classes: <see cref="InputPhoneContact"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputContact"/></para></summary>
	public abstract partial class InputContact : ITLObject { }
	/// <summary>Phone contact. The <c>client_id</c> is just an arbitrary contact ID: it should be set, for example, to an incremental number when using <a href="https://corefork.telegram.org/method/contacts.importContacts">contacts.importContacts</a>, in order to retry importing only the contacts that weren't imported successfully.		<para>See <a href="https://corefork.telegram.org/constructor/inputPhoneContact"/></para></summary>
	[TLDef(0xF392B7F4)]
	public partial class InputPhoneContact : InputContact
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
	public abstract partial class InputFileBase : ITLObject
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
	/// <summary>Assigns a big file (over 10Mb in size), saved in part using the method <a href="https://corefork.telegram.org/method/upload.saveBigFilePart">upload.saveBigFilePart</a>.		<para>See <a href="https://corefork.telegram.org/constructor/inputFileBig"/></para></summary>
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
	public abstract partial class InputMedia : ITLObject { }
	/// <summary>Photo		<para>See <a href="https://corefork.telegram.org/constructor/inputMediaUploadedPhoto"/></para></summary>
	[TLDef(0x1E287D04)]
	public partial class InputMediaUploadedPhoto : InputMedia
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The <a href="https://corefork.telegram.org/api/files">uploaded file</a></summary>
		public InputFileBase file;
		/// <summary>Attached mask stickers</summary>
		[IfFlag(0)] public InputDocument[] stickers;
		/// <summary>Time to live in seconds of self-destructing photo</summary>
		[IfFlag(1)] public int ttl_seconds;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="stickers"/> has a value</summary>
			has_stickers = 0x1,
			/// <summary>Field <see cref="ttl_seconds"/> has a value</summary>
			has_ttl_seconds = 0x2,
		}
	}
	/// <summary>Forwarded photo		<para>See <a href="https://corefork.telegram.org/constructor/inputMediaPhoto"/></para></summary>
	[TLDef(0xB3BA0635)]
	public partial class InputMediaPhoto : InputMedia
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Photo to be forwarded</summary>
		public InputPhoto id;
		/// <summary>Time to live in seconds of self-destructing photo</summary>
		[IfFlag(0)] public int ttl_seconds;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="ttl_seconds"/> has a value</summary>
			has_ttl_seconds = 0x1,
		}
	}
	/// <summary>Map.		<para>See <a href="https://corefork.telegram.org/constructor/inputMediaGeoPoint"/></para></summary>
	[TLDef(0xF9C44144)]
	public partial class InputMediaGeoPoint : InputMedia
	{
		/// <summary>GeoPoint</summary>
		public InputGeoPoint geo_point;
	}
	/// <summary>Phonebook contact		<para>See <a href="https://corefork.telegram.org/constructor/inputMediaContact"/></para></summary>
	[TLDef(0xF8AB7DFB)]
	public partial class InputMediaContact : InputMedia
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

		[Flags] public enum Flags
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
	public partial class InputMediaDocument : InputMedia
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The document to be forwarded.</summary>
		public InputDocument id;
		/// <summary>Time to live of self-destructing document</summary>
		[IfFlag(0)] public int ttl_seconds;
		/// <summary>Text query or emoji that was used by the user to find this sticker or GIF: used to improve search result relevance.</summary>
		[IfFlag(1)] public string query;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="ttl_seconds"/> has a value</summary>
			has_ttl_seconds = 0x1,
			/// <summary>Field <see cref="query"/> has a value</summary>
			has_query = 0x2,
		}
	}
	/// <summary>Can be used to send a venue geolocation.		<para>See <a href="https://corefork.telegram.org/constructor/inputMediaVenue"/></para></summary>
	[TLDef(0xC13D1C11)]
	public partial class InputMediaVenue : InputMedia
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
	public partial class InputMediaPhotoExternal : InputMedia
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>URL of the photo</summary>
		public string url;
		/// <summary>Self-destruct time to live of photo</summary>
		[IfFlag(0)] public int ttl_seconds;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="ttl_seconds"/> has a value</summary>
			has_ttl_seconds = 0x1,
		}
	}
	/// <summary>Document that will be downloaded by the telegram servers		<para>See <a href="https://corefork.telegram.org/constructor/inputMediaDocumentExternal"/></para></summary>
	[TLDef(0xFB52DC99)]
	public partial class InputMediaDocumentExternal : InputMedia
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>URL of the document</summary>
		public string url;
		/// <summary>Self-destruct time to live of document</summary>
		[IfFlag(0)] public int ttl_seconds;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="ttl_seconds"/> has a value</summary>
			has_ttl_seconds = 0x1,
		}
	}
	/// <summary>A game		<para>See <a href="https://corefork.telegram.org/constructor/inputMediaGame"/></para></summary>
	[TLDef(0xD33F43F3)]
	public partial class InputMediaGame : InputMedia
	{
		/// <summary>The game to forward</summary>
		public InputGame id;
	}
	/// <summary>Generated invoice of a <a href="https://corefork.telegram.org/bots/payments">bot payment</a>		<para>See <a href="https://corefork.telegram.org/constructor/inputMediaInvoice"/></para></summary>
	[TLDef(0xD9799874)]
	public partial class InputMediaInvoice : InputMedia
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="photo"/> has a value</summary>
			has_photo = 0x1,
			/// <summary>Field <see cref="start_param"/> has a value</summary>
			has_start_param = 0x2,
		}
	}
	/// <summary><a href="https://corefork.telegram.org/api/live-location">Live geolocation</a>		<para>See <a href="https://corefork.telegram.org/constructor/inputMediaGeoLive"/></para></summary>
	[TLDef(0x971FA843)]
	public partial class InputMediaGeoLive : InputMedia
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

		[Flags] public enum Flags
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
	public partial class InputMediaPoll : InputMedia
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="correct_answers"/> has a value</summary>
			has_correct_answers = 0x1,
			/// <summary>Field <see cref="solution"/> has a value</summary>
			has_solution = 0x2,
		}
	}
	/// <summary>Send a <a href="https://corefork.telegram.org/api/dice">dice-based animated sticker</a>		<para>See <a href="https://corefork.telegram.org/constructor/inputMediaDice"/></para></summary>
	[TLDef(0xE66FBF7B)]
	public partial class InputMediaDice : InputMedia
	{
		/// <summary>The emoji, for now 🏀, 🎲 and 🎯 are supported</summary>
		public string emoticon;
	}

	/// <summary>Defines a new group profile photo.		<para>Derived classes: <see cref="InputChatUploadedPhoto"/>, <see cref="InputChatPhoto"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputChatPhoto"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputChatPhotoEmpty">inputChatPhotoEmpty</a></remarks>
	public abstract partial class InputChatPhotoBase : ITLObject { }
	/// <summary>New photo to be set as group profile photo.		<para>See <a href="https://corefork.telegram.org/constructor/inputChatUploadedPhoto"/></para></summary>
	[TLDef(0xC642724E)]
	public partial class InputChatUploadedPhoto : InputChatPhotoBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>File saved in parts using the method <a href="https://corefork.telegram.org/method/upload.saveFilePart">upload.saveFilePart</a></summary>
		[IfFlag(0)] public InputFileBase file;
		/// <summary>Square video for animated profile picture</summary>
		[IfFlag(1)] public InputFileBase video;
		/// <summary>Timestamp that should be shown as static preview to the user (seconds)</summary>
		[IfFlag(2)] public double video_start_ts;

		[Flags] public enum Flags
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
	public partial class InputChatPhoto : InputChatPhotoBase
	{
		/// <summary>Existing photo</summary>
		public InputPhoto id;
	}

	/// <summary>Defines a GeoPoint by its coordinates.		<para>See <a href="https://corefork.telegram.org/constructor/inputGeoPoint"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputGeoPointEmpty">inputGeoPointEmpty</a></remarks>
	[TLDef(0x48222FAF)]
	public partial class InputGeoPoint : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Latitide</summary>
		public double lat;
		/// <summary>Longtitude</summary>
		public double long_;
		/// <summary>The estimated horizontal accuracy of the location, in meters; as defined by the sender.</summary>
		[IfFlag(0)] public int accuracy_radius;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="accuracy_radius"/> has a value</summary>
			has_accuracy_radius = 0x1,
		}
	}

	/// <summary>Defines a photo for further interaction.		<para>See <a href="https://corefork.telegram.org/constructor/inputPhoto"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputPhotoEmpty">inputPhotoEmpty</a></remarks>
	[TLDef(0x3BB3B94A)]
	public partial class InputPhoto : ITLObject
	{
		/// <summary>Photo identifier</summary>
		public long id;
		/// <summary><strong>access_hash</strong> value from the <see cref="Photo"/> constructor</summary>
		public long access_hash;
		/// <summary><a href="https://corefork.telegram.org/api/file_reference">File reference</a></summary>
		public byte[] file_reference;
	}

	/// <summary>Defines the location of a file for download.		<para>Derived classes: <see cref="InputFileLocation"/>, <see cref="InputEncryptedFileLocation"/>, <see cref="InputDocumentFileLocation"/>, <see cref="InputSecureFileLocation"/>, <see cref="InputTakeoutFileLocation"/>, <see cref="InputPhotoFileLocation"/>, <see cref="InputPhotoLegacyFileLocation"/>, <see cref="InputPeerPhotoFileLocation"/>, <see cref="InputStickerSetThumb"/>, <see cref="InputGroupCallStream"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputFileLocation"/></para></summary>
	public abstract partial class InputFileLocationBase : ITLObject { }
	/// <summary>DEPRECATED location of a photo		<para>See <a href="https://corefork.telegram.org/constructor/inputFileLocation"/></para></summary>
	[TLDef(0xDFDAABE1)]
	public partial class InputFileLocation : InputFileLocationBase
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
	public partial class InputEncryptedFileLocation : InputFileLocationBase
	{
		/// <summary>File ID, <strong>id</strong> parameter value from <see cref="EncryptedFile"/></summary>
		public long id;
		/// <summary>Checksum, <strong>access_hash</strong> parameter value from <see cref="EncryptedFile"/></summary>
		public long access_hash;
	}
	/// <summary>Document location (video, voice, audio, basically every type except photo)		<para>See <a href="https://corefork.telegram.org/constructor/inputDocumentFileLocation"/></para></summary>
	[TLDef(0xBAD07584)]
	public partial class InputDocumentFileLocation : InputFileLocationBase
	{
		/// <summary>Document ID</summary>
		public long id;
		/// <summary><strong>access_hash</strong> parameter from the <see cref="Document"/> constructor</summary>
		public long access_hash;
		/// <summary><a href="https://corefork.telegram.org/api/file_reference">File reference</a></summary>
		public byte[] file_reference;
		/// <summary>Thumbnail size to download the thumbnail</summary>
		public string thumb_size;
	}
	/// <summary>Location of encrypted telegram <a href="https://corefork.telegram.org/passport">passport</a> file.		<para>See <a href="https://corefork.telegram.org/constructor/inputSecureFileLocation"/></para></summary>
	[TLDef(0xCBC7EE28)]
	public partial class InputSecureFileLocation : InputFileLocationBase
	{
		/// <summary>File ID, <strong>id</strong> parameter value from <see cref="SecureFile"/></summary>
		public long id;
		/// <summary>Checksum, <strong>access_hash</strong> parameter value from <see cref="SecureFile"/></summary>
		public long access_hash;
	}
	/// <summary>Empty constructor for takeout		<para>See <a href="https://corefork.telegram.org/constructor/inputTakeoutFileLocation"/></para></summary>
	[TLDef(0x29BE5899)]
	public partial class InputTakeoutFileLocation : InputFileLocationBase { }
	/// <summary>Use this object to download a photo with <a href="https://corefork.telegram.org/method/upload.getFile">upload.getFile</a> method		<para>See <a href="https://corefork.telegram.org/constructor/inputPhotoFileLocation"/></para></summary>
	[TLDef(0x40181FFE)]
	public partial class InputPhotoFileLocation : InputFileLocationBase
	{
		/// <summary>Photo ID, obtained from the <see cref="Photo"/> object</summary>
		public long id;
		/// <summary>Photo's access hash, obtained from the <see cref="Photo"/> object</summary>
		public long access_hash;
		/// <summary><a href="https://corefork.telegram.org/api/file_reference">File reference</a></summary>
		public byte[] file_reference;
		/// <summary>The <see cref="PhotoSizeBase"/> to download: must be set to the <c>type</c> field of the desired PhotoSize object of the <see cref="Photo"/></summary>
		public string thumb_size;
	}
	/// <summary>DEPRECATED legacy photo file location		<para>See <a href="https://corefork.telegram.org/constructor/inputPhotoLegacyFileLocation"/></para></summary>
	[TLDef(0xD83466F3)]
	public partial class InputPhotoLegacyFileLocation : InputFileLocationBase
	{
		/// <summary>Photo ID</summary>
		public long id;
		/// <summary>Access hash</summary>
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
	public partial class InputPeerPhotoFileLocation : InputFileLocationBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The peer whose profile picture should be downloaded</summary>
		public InputPeer peer;
		/// <summary>Photo ID</summary>
		public long photo_id;

		[Flags] public enum Flags
		{
			/// <summary>Whether to download the high-quality version of the picture</summary>
			big = 0x1,
		}
	}
	/// <summary>Location of stickerset thumbnail (see <a href="https://corefork.telegram.org/api/files">files</a>)		<para>See <a href="https://corefork.telegram.org/constructor/inputStickerSetThumb"/></para></summary>
	[TLDef(0x9D84F3DB)]
	public partial class InputStickerSetThumb : InputFileLocationBase
	{
		/// <summary>Sticker set</summary>
		public InputStickerSet stickerset;
		/// <summary>Thumbnail version</summary>
		public int thumb_version;
	}
	/// <summary>Chunk of a livestream		<para>See <a href="https://corefork.telegram.org/constructor/inputGroupCallStream"/></para></summary>
	[TLDef(0x0598A92A)]
	public partial class InputGroupCallStream : InputFileLocationBase
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="video_channel"/> has a value</summary>
			has_video_channel = 0x1,
		}
	}

	/// <summary>Chat partner or group.		<para>Derived classes: <see cref="PeerUser"/>, <see cref="PeerChat"/>, <see cref="PeerChannel"/></para>		<para>See <a href="https://corefork.telegram.org/type/Peer"/></para></summary>
	public abstract partial class Peer : ITLObject { }
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
	public abstract partial class UserBase : ITLObject { }
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

		[Flags] public enum Flags
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
		}
	}

	/// <summary>User profile photo.		<para>See <a href="https://corefork.telegram.org/constructor/userProfilePhoto"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/userProfilePhotoEmpty">userProfilePhotoEmpty</a></remarks>
	[TLDef(0x82D1F706)]
	public partial class UserProfilePhoto : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Identifier of the respective photo<br/>Parameter added in <a href="https://corefork.telegram.org/api/layers#layer-2">Layer 2</a></summary>
		public long photo_id;
		/// <summary><a href="https://corefork.telegram.org/api/files#stripped-thumbnails">Stripped thumbnail</a></summary>
		[IfFlag(1)] public byte[] stripped_thumb;
		/// <summary>DC ID where the photo is stored</summary>
		public int dc_id;

		[Flags] public enum Flags
		{
			/// <summary>Whether an <a href="https://corefork.telegram.org/api/files#animated-profile-pictures">animated profile picture</a> is available for this user</summary>
			has_video = 0x1,
			/// <summary>Field <see cref="stripped_thumb"/> has a value</summary>
			has_stripped_thumb = 0x2,
		}
	}

	/// <summary>User online status		<para>Derived classes: <see cref="UserStatusOnline"/>, <see cref="UserStatusOffline"/>, <see cref="UserStatusRecently"/>, <see cref="UserStatusLastWeek"/>, <see cref="UserStatusLastMonth"/></para>		<para>See <a href="https://corefork.telegram.org/type/UserStatus"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/userStatusEmpty">userStatusEmpty</a></remarks>
	public abstract partial class UserStatus : ITLObject { }
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
	public abstract partial class ChatBase : ITLObject
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

		[Flags] public enum Flags
		{
			/// <summary>Whether the current user is the creator of the group</summary>
			creator = 0x1,
			/// <summary>Whether the current user was kicked from the group</summary>
			kicked = 0x2,
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

		[Flags] public enum Flags
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

		[Flags] public enum Flags
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

	/// <summary>Object containing detailed group info		<para>Derived classes: <see cref="ChatFull"/>, <see cref="ChannelFull"/></para>		<para>See <a href="https://corefork.telegram.org/type/ChatFull"/></para></summary>
	public abstract partial class ChatFullBase : ITLObject
	{
		/// <summary>ID of the chat</summary>
		public abstract long ID { get; }
		/// <summary>About string for this chat</summary>
		public abstract string About { get; }
		/// <summary>Notification settings</summary>
		public abstract PeerNotifySettings NotifySettings { get; }
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		public abstract int Folder { get; }
	}
	/// <summary>Detailed chat info		<para>See <a href="https://corefork.telegram.org/constructor/chatFull"/></para></summary>
	[TLDef(0x46A6FFB4)]
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
		[IfFlag(17)] public int requests_pending;
		[IfFlag(17)] public long[] recent_requesters;

		[Flags] public enum Flags
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
		}

		/// <summary>ID of the chat</summary>
		public override long ID => id;
		/// <summary>About string for this chat</summary>
		public override string About => about;
		/// <summary>Notification settings</summary>
		public override PeerNotifySettings NotifySettings => notify_settings;
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		public override int Folder => folder_id;
	}
	/// <summary>Full info about a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>		<para>See <a href="https://corefork.telegram.org/constructor/channelFull"/></para></summary>
	[TLDef(0x59CFF963)]
	public partial class ChannelFull : ChatFullBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
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
		/// <summary>Info about bots in the channel/supergrup</summary>
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
		/// <summary>Indicates when the user will be allowed to send another message in the supergroup (unixdate)</summary>
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
		[IfFlag(28)] public int requests_pending;
		[IfFlag(28)] public long[] recent_requesters;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="participants_count"/> has a value</summary>
			has_participants_count = 0x1,
			/// <summary>Field <see cref="admins_count"/> has a value</summary>
			has_admins_count = 0x2,
			/// <summary>Field <see cref="kicked_count"/> has a value</summary>
			has_kicked_count = 0x4,
			/// <summary>Can we vew the participant list?</summary>
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
		}

		/// <summary>ID of the channel</summary>
		public override long ID => id;
		/// <summary>Info about the channel</summary>
		public override string About => about;
		/// <summary>Notification settings</summary>
		public override PeerNotifySettings NotifySettings => notify_settings;
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		public override int Folder => folder_id;
	}

	/// <summary>Details of a group member.		<para>Derived classes: <see cref="ChatParticipant"/>, <see cref="ChatParticipantCreator"/>, <see cref="ChatParticipantAdmin"/></para>		<para>See <a href="https://corefork.telegram.org/type/ChatParticipant"/></para></summary>
	public abstract partial class ChatParticipantBase : ITLObject
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
	public abstract partial class ChatParticipantsBase : ITLObject
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

		[Flags] public enum Flags
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
	public partial class ChatPhoto : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Photo ID</summary>
		public long photo_id;
		/// <summary><a href="https://corefork.telegram.org/api/files#stripped-thumbnails">Stripped thumbnail</a></summary>
		[IfFlag(1)] public byte[] stripped_thumb;
		/// <summary>DC where this photo is stored</summary>
		public int dc_id;

		[Flags] public enum Flags
		{
			/// <summary>Whether the user has an animated profile picture</summary>
			has_video = 0x1,
			/// <summary>Field <see cref="stripped_thumb"/> has a value</summary>
			has_stripped_thumb = 0x2,
		}
	}

	/// <summary>Object describing a message.		<para>Derived classes: <see cref="MessageEmpty"/>, <see cref="Message"/>, <see cref="MessageService"/></para>		<para>See <a href="https://corefork.telegram.org/type/Message"/></para></summary>
	public abstract partial class MessageBase : ITLObject
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
	public partial class MessageEmpty : MessageBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Message identifier</summary>
		public int id;
		/// <summary>Peer ID, the chat where this message was sent</summary>
		[IfFlag(0)] public Peer peer_id;

		[Flags] public enum Flags
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
	[TLDef(0x85D6CBE2)]
	public partial class Message : MessageBase
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
		/// <summary>Contains the reason why access to this message must be restricted.</summary>
		[IfFlag(22)] public RestrictionReason[] restriction_reason;
		/// <summary>Time To Live of the message, once message.date+message.ttl_period === time(), the message will be deleted on the server, and must be deleted locally as well.</summary>
		[IfFlag(25)] public int ttl_period;

		[Flags] public enum Flags
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
	public partial class MessageService : MessageBase
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

		[Flags] public enum Flags
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
	public abstract partial class MessageMedia : ITLObject { }
	/// <summary>Attached photo.		<para>See <a href="https://corefork.telegram.org/constructor/messageMediaPhoto"/></para></summary>
	[TLDef(0x695150D7)]
	public partial class MessageMediaPhoto : MessageMedia
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Photo</summary>
		[IfFlag(0)] public PhotoBase photo;
		/// <summary>Time to live in seconds of self-destructing photo</summary>
		[IfFlag(2)] public int ttl_seconds;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="photo"/> has a value</summary>
			has_photo = 0x1,
			/// <summary>Field <see cref="ttl_seconds"/> has a value</summary>
			has_ttl_seconds = 0x4,
		}
	}
	/// <summary>Attached map.		<para>See <a href="https://corefork.telegram.org/constructor/messageMediaGeo"/></para></summary>
	[TLDef(0x56E0D474)]
	public partial class MessageMediaGeo : MessageMedia
	{
		/// <summary>GeoPoint</summary>
		public GeoPoint geo;
	}
	/// <summary>Attached contact.		<para>See <a href="https://corefork.telegram.org/constructor/messageMediaContact"/></para></summary>
	[TLDef(0x70322949)]
	public partial class MessageMediaContact : MessageMedia
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
	public partial class MessageMediaUnsupported : MessageMedia { }
	/// <summary>Document (video, audio, voice, sticker, any media type except photo)		<para>See <a href="https://corefork.telegram.org/constructor/messageMediaDocument"/></para></summary>
	[TLDef(0x9CB070D7)]
	public partial class MessageMediaDocument : MessageMedia
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Attached document</summary>
		[IfFlag(0)] public DocumentBase document;
		/// <summary>Time to live of self-destructing document</summary>
		[IfFlag(2)] public int ttl_seconds;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="document"/> has a value</summary>
			has_document = 0x1,
			/// <summary>Field <see cref="ttl_seconds"/> has a value</summary>
			has_ttl_seconds = 0x4,
		}
	}
	/// <summary>Preview of webpage		<para>See <a href="https://corefork.telegram.org/constructor/messageMediaWebPage"/></para></summary>
	[TLDef(0xA32DD600)]
	public partial class MessageMediaWebPage : MessageMedia
	{
		/// <summary>Webpage preview</summary>
		public WebPageBase webpage;
	}
	/// <summary>Venue		<para>See <a href="https://corefork.telegram.org/constructor/messageMediaVenue"/></para></summary>
	[TLDef(0x2EC0533F)]
	public partial class MessageMediaVenue : MessageMedia
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
	public partial class MessageMediaGame : MessageMedia
	{
		/// <summary>Game</summary>
		public Game game;
	}
	/// <summary>Invoice		<para>See <a href="https://corefork.telegram.org/constructor/messageMediaInvoice"/></para></summary>
	[TLDef(0x84551347)]
	public partial class MessageMediaInvoice : MessageMedia
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

		[Flags] public enum Flags
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
	public partial class MessageMediaGeoLive : MessageMedia
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="heading"/> has a value</summary>
			has_heading = 0x1,
			/// <summary>Field <see cref="proximity_notification_radius"/> has a value</summary>
			has_proximity_notification_radius = 0x2,
		}
	}
	/// <summary>Poll		<para>See <a href="https://corefork.telegram.org/constructor/messageMediaPoll"/></para></summary>
	[TLDef(0x4BD6E798)]
	public partial class MessageMediaPoll : MessageMedia
	{
		/// <summary>The poll</summary>
		public Poll poll;
		/// <summary>The results of the poll</summary>
		public PollResults results;
	}
	/// <summary><a href="https://corefork.telegram.org/api/dice">Dice-based animated sticker</a>		<para>See <a href="https://corefork.telegram.org/constructor/messageMediaDice"/></para></summary>
	[TLDef(0x3F7EE58B)]
	public partial class MessageMediaDice : MessageMedia
	{
		/// <summary><a href="https://corefork.telegram.org/api/dice">Dice value</a></summary>
		public int value;
		/// <summary>The emoji, for now 🏀, 🎲 and 🎯 are supported</summary>
		public string emoticon;
	}

	/// <summary>Object describing actions connected to a service message.		<para>Derived classes: <see cref="MessageActionChatCreate"/>, <see cref="MessageActionChatEditTitle"/>, <see cref="MessageActionChatEditPhoto"/>, <see cref="MessageActionChatDeletePhoto"/>, <see cref="MessageActionChatAddUser"/>, <see cref="MessageActionChatDeleteUser"/>, <see cref="MessageActionChatJoinedByLink"/>, <see cref="MessageActionChannelCreate"/>, <see cref="MessageActionChatMigrateTo"/>, <see cref="MessageActionChannelMigrateFrom"/>, <see cref="MessageActionPinMessage"/>, <see cref="MessageActionHistoryClear"/>, <see cref="MessageActionGameScore"/>, <see cref="MessageActionPaymentSentMe"/>, <see cref="MessageActionPaymentSent"/>, <see cref="MessageActionPhoneCall"/>, <see cref="MessageActionScreenshotTaken"/>, <see cref="MessageActionCustomAction"/>, <see cref="MessageActionBotAllowed"/>, <see cref="MessageActionSecureValuesSentMe"/>, <see cref="MessageActionSecureValuesSent"/>, <see cref="MessageActionContactSignUp"/>, <see cref="MessageActionGeoProximityReached"/>, <see cref="MessageActionGroupCall"/>, <see cref="MessageActionInviteToGroupCall"/>, <see cref="MessageActionSetMessagesTTL"/>, <see cref="MessageActionGroupCallScheduled"/>, <see cref="MessageActionSetChatTheme"/></para>		<para>See <a href="https://corefork.telegram.org/type/MessageAction"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messageActionEmpty">messageActionEmpty</a></remarks>
	public abstract partial class MessageAction : ITLObject { }
	/// <summary>Group created		<para>See <a href="https://corefork.telegram.org/constructor/messageActionChatCreate"/></para></summary>
	[TLDef(0xBD47CBAD)]
	public partial class MessageActionChatCreate : MessageAction
	{
		/// <summary>Group name</summary>
		public string title;
		/// <summary>List of group members</summary>
		public long[] users;
	}
	/// <summary>Group name changed.		<para>See <a href="https://corefork.telegram.org/constructor/messageActionChatEditTitle"/></para></summary>
	[TLDef(0xB5A1CE5A)]
	public partial class MessageActionChatEditTitle : MessageAction
	{
		/// <summary>New group name</summary>
		public string title;
	}
	/// <summary>Group profile changed		<para>See <a href="https://corefork.telegram.org/constructor/messageActionChatEditPhoto"/></para></summary>
	[TLDef(0x7FCB13A8)]
	public partial class MessageActionChatEditPhoto : MessageAction
	{
		/// <summary>New group pofile photo</summary>
		public PhotoBase photo;
	}
	/// <summary>Group profile photo removed.		<para>See <a href="https://corefork.telegram.org/constructor/messageActionChatDeletePhoto"/></para></summary>
	[TLDef(0x95E3FBEF)]
	public partial class MessageActionChatDeletePhoto : MessageAction { }
	/// <summary>New member in the group		<para>See <a href="https://corefork.telegram.org/constructor/messageActionChatAddUser"/></para></summary>
	[TLDef(0x15CEFD00)]
	public partial class MessageActionChatAddUser : MessageAction
	{
		/// <summary>Users that were invited to the chat</summary>
		public long[] users;
	}
	/// <summary>User left the group.		<para>See <a href="https://corefork.telegram.org/constructor/messageActionChatDeleteUser"/></para></summary>
	[TLDef(0xA43F30CC)]
	public partial class MessageActionChatDeleteUser : MessageAction
	{
		/// <summary>Leaving user ID</summary>
		public long user_id;
	}
	/// <summary>A user joined the chat via an invite link		<para>See <a href="https://corefork.telegram.org/constructor/messageActionChatJoinedByLink"/></para></summary>
	[TLDef(0x031224C3)]
	public partial class MessageActionChatJoinedByLink : MessageAction
	{
		/// <summary>ID of the user that created the invite link</summary>
		public long inviter_id;
	}
	/// <summary>The channel was created		<para>See <a href="https://corefork.telegram.org/constructor/messageActionChannelCreate"/></para></summary>
	[TLDef(0x95D2AC92)]
	public partial class MessageActionChannelCreate : MessageAction
	{
		/// <summary>Original channel/supergroup title</summary>
		public string title;
	}
	/// <summary>Indicates the chat was <a href="https://corefork.telegram.org/api/channel">migrated</a> to the specified supergroup		<para>See <a href="https://corefork.telegram.org/constructor/messageActionChatMigrateTo"/></para></summary>
	[TLDef(0xE1037F92)]
	public partial class MessageActionChatMigrateTo : MessageAction
	{
		/// <summary>The supergroup it was migrated to</summary>
		public long channel_id;
	}
	/// <summary>Indicates the channel was <a href="https://corefork.telegram.org/api/channel">migrated</a> from the specified chat		<para>See <a href="https://corefork.telegram.org/constructor/messageActionChannelMigrateFrom"/></para></summary>
	[TLDef(0xEA3948E9)]
	public partial class MessageActionChannelMigrateFrom : MessageAction
	{
		/// <summary>The old chat tite</summary>
		public string title;
		/// <summary>The old chat ID</summary>
		public long chat_id;
	}
	/// <summary>A message was pinned		<para>See <a href="https://corefork.telegram.org/constructor/messageActionPinMessage"/></para></summary>
	[TLDef(0x94BD38ED)]
	public partial class MessageActionPinMessage : MessageAction { }
	/// <summary>Chat history was cleared		<para>See <a href="https://corefork.telegram.org/constructor/messageActionHistoryClear"/></para></summary>
	[TLDef(0x9FBAB604)]
	public partial class MessageActionHistoryClear : MessageAction { }
	/// <summary>Someone scored in a game		<para>See <a href="https://corefork.telegram.org/constructor/messageActionGameScore"/></para></summary>
	[TLDef(0x92A72876)]
	public partial class MessageActionGameScore : MessageAction
	{
		/// <summary>Game ID</summary>
		public long game_id;
		/// <summary>Score</summary>
		public int score;
	}
	/// <summary>A user just sent a payment to me (a bot)		<para>See <a href="https://corefork.telegram.org/constructor/messageActionPaymentSentMe"/></para></summary>
	[TLDef(0x8F31B327)]
	public partial class MessageActionPaymentSentMe : MessageAction
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="info"/> has a value</summary>
			has_info = 0x1,
			/// <summary>Field <see cref="shipping_option_id"/> has a value</summary>
			has_shipping_option_id = 0x2,
		}
	}
	/// <summary>A payment was sent		<para>See <a href="https://corefork.telegram.org/constructor/messageActionPaymentSent"/></para></summary>
	[TLDef(0x40699CD0)]
	public partial class MessageActionPaymentSent : MessageAction
	{
		/// <summary>Three-letter ISO 4217 <a href="https://corefork.telegram.org/bots/payments#supported-currencies">currency</a> code</summary>
		public string currency;
		/// <summary>Price of the product in the smallest units of the currency (integer, not float/double). For example, for a price of <c>US$ 1.45</c> pass <c>amount = 145</c>. See the exp parameter in <a href="https://corefork.telegram.org/bots/payments/currencies.json">currencies.json</a>, it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).</summary>
		public long total_amount;
	}
	/// <summary>A phone call		<para>See <a href="https://corefork.telegram.org/constructor/messageActionPhoneCall"/></para></summary>
	[TLDef(0x80E11A7F)]
	public partial class MessageActionPhoneCall : MessageAction
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Call ID</summary>
		public long call_id;
		/// <summary>If the call has ended, the reason why it ended</summary>
		[IfFlag(0)] public PhoneCallDiscardReason reason;
		/// <summary>Duration of the call in seconds</summary>
		[IfFlag(1)] public int duration;

		[Flags] public enum Flags
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
	public partial class MessageActionScreenshotTaken : MessageAction { }
	/// <summary>Custom action (most likely not supported by the current layer, an upgrade might be needed)		<para>See <a href="https://corefork.telegram.org/constructor/messageActionCustomAction"/></para></summary>
	[TLDef(0xFAE69F56)]
	public partial class MessageActionCustomAction : MessageAction
	{
		/// <summary>Action message</summary>
		public string message;
	}
	/// <summary>The domain name of the website on which the user has logged in. <a href="https://corefork.telegram.org/widgets/login">More about Telegram Login »</a>		<para>See <a href="https://corefork.telegram.org/constructor/messageActionBotAllowed"/></para></summary>
	[TLDef(0xABE9AFFE)]
	public partial class MessageActionBotAllowed : MessageAction
	{
		/// <summary>The domain name of the website on which the user has logged in.</summary>
		public string domain;
	}
	/// <summary>Secure <a href="https://corefork.telegram.org/passport">telegram passport</a> values were received		<para>See <a href="https://corefork.telegram.org/constructor/messageActionSecureValuesSentMe"/></para></summary>
	[TLDef(0x1B287353)]
	public partial class MessageActionSecureValuesSentMe : MessageAction
	{
		/// <summary>Vector with information about documents and other Telegram Passport elements that were shared with the bot</summary>
		public SecureValue[] values;
		/// <summary>Encrypted credentials required to decrypt the data</summary>
		public SecureCredentialsEncrypted credentials;
	}
	/// <summary>Request for secure <a href="https://corefork.telegram.org/passport">telegram passport</a> values was sent		<para>See <a href="https://corefork.telegram.org/constructor/messageActionSecureValuesSent"/></para></summary>
	[TLDef(0xD95C6154)]
	public partial class MessageActionSecureValuesSent : MessageAction
	{
		/// <summary>Secure value types</summary>
		public SecureValueType[] types;
	}
	/// <summary>A contact just signed up to telegram		<para>See <a href="https://corefork.telegram.org/constructor/messageActionContactSignUp"/></para></summary>
	[TLDef(0xF3F25F76)]
	public partial class MessageActionContactSignUp : MessageAction { }
	/// <summary>A user of the chat is now in proximity of another user		<para>See <a href="https://corefork.telegram.org/constructor/messageActionGeoProximityReached"/></para></summary>
	[TLDef(0x98E0D697)]
	public partial class MessageActionGeoProximityReached : MessageAction
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
	public partial class MessageActionGroupCall : MessageAction
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Group call</summary>
		public InputGroupCall call;
		/// <summary>Group call duration</summary>
		[IfFlag(0)] public int duration;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="duration"/> has a value</summary>
			has_duration = 0x1,
		}
	}
	/// <summary>A set of users was invited to the group call		<para>See <a href="https://corefork.telegram.org/constructor/messageActionInviteToGroupCall"/></para></summary>
	[TLDef(0x502F92F7)]
	public partial class MessageActionInviteToGroupCall : MessageAction
	{
		/// <summary>The group call</summary>
		public InputGroupCall call;
		/// <summary>The invited users</summary>
		public long[] users;
	}
	/// <summary>The Time-To-Live of messages in this chat was changed.		<para>See <a href="https://corefork.telegram.org/constructor/messageActionSetMessagesTTL"/></para></summary>
	[TLDef(0xAA1AFBFD)]
	public partial class MessageActionSetMessagesTTL : MessageAction
	{
		/// <summary>New Time-To-Live</summary>
		public int period;
	}
	/// <summary>A group call was scheduled		<para>See <a href="https://corefork.telegram.org/constructor/messageActionGroupCallScheduled"/></para></summary>
	[TLDef(0xB3A07661)]
	public partial class MessageActionGroupCallScheduled : MessageAction
	{
		/// <summary>The group call</summary>
		public InputGroupCall call;
		/// <summary>When is this group call scheduled to start</summary>
		public DateTime schedule_date;
	}
	/// <summary>The chat theme was changed		<para>See <a href="https://corefork.telegram.org/constructor/messageActionSetChatTheme"/></para></summary>
	[TLDef(0xAA786345)]
	public partial class MessageActionSetChatTheme : MessageAction
	{
		/// <summary>The emoji that identifies a chat theme</summary>
		public string emoticon;
	}
	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/messageActionChatJoinedByRequest"/></para></summary>
	[TLDef(0xEBBCA3CB)]
	public partial class MessageActionChatJoinedByRequest : MessageAction { }

	/// <summary>Chat info.		<para>Derived classes: <see cref="Dialog"/>, <see cref="DialogFolder"/></para>		<para>See <a href="https://corefork.telegram.org/type/Dialog"/></para></summary>
	public abstract partial class DialogBase : ITLObject
	{
		/// <summary>The chat</summary>
		public abstract Peer Peer { get; }
		/// <summary>The latest message ID</summary>
		public abstract int TopMessage { get; }
	}
	/// <summary>Chat		<para>See <a href="https://corefork.telegram.org/constructor/dialog"/></para></summary>
	[TLDef(0x2C171F72)]
	public partial class Dialog : DialogBase
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
		/// <summary>Notification settings</summary>
		public PeerNotifySettings notify_settings;
		/// <summary><a href="https://corefork.telegram.org/api/updates">PTS</a></summary>
		[IfFlag(0)] public int pts;
		/// <summary>Message draft</summary>
		[IfFlag(1)] public DraftMessageBase draft;
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		[IfFlag(4)] public int folder_id;

		[Flags] public enum Flags
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
	public partial class DialogFolder : DialogBase
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

		[Flags] public enum Flags
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
	public abstract partial class PhotoBase : ITLObject { }
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

		[Flags] public enum Flags
		{
			/// <summary>Whether the photo has mask stickers attached to it</summary>
			has_stickers = 0x1,
			/// <summary>Field <see cref="video_sizes"/> has a value</summary>
			has_video_sizes = 0x2,
		}
	}

	/// <summary>Location of a certain size of a picture		<para>Derived classes: <see cref="PhotoSizeEmpty"/>, <see cref="PhotoSize"/>, <see cref="PhotoCachedSize"/>, <see cref="PhotoStrippedSize"/>, <see cref="PhotoSizeProgressive"/>, <see cref="PhotoPathSize"/></para>		<para>See <a href="https://corefork.telegram.org/type/PhotoSize"/></para></summary>
	public abstract partial class PhotoSizeBase : ITLObject
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
	public partial class GeoPoint : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Longtitude</summary>
		public double long_;
		/// <summary>Latitude</summary>
		public double lat;
		/// <summary>Access hash</summary>
		public long access_hash;
		/// <summary>The estimated horizontal accuracy of the location, in meters; as defined by the sender.</summary>
		[IfFlag(0)] public int accuracy_radius;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="accuracy_radius"/> has a value</summary>
			has_accuracy_radius = 0x1,
		}
	}

	/// <summary>Contains info about a sent verification code.		<para>See <a href="https://corefork.telegram.org/constructor/auth.sentCode"/></para></summary>
	[TLDef(0x5E002502)]
	public partial class Auth_SentCode : ITLObject
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="next_type"/> has a value</summary>
			has_next_type = 0x2,
			/// <summary>Field <see cref="timeout"/> has a value</summary>
			has_timeout = 0x4,
		}
	}

	/// <summary>Oject contains info on user authorization.		<para>Derived classes: <see cref="Auth_Authorization"/>, <see cref="Auth_AuthorizationSignUpRequired"/></para>		<para>See <a href="https://corefork.telegram.org/type/auth.Authorization"/></para></summary>
	public abstract partial class Auth_AuthorizationBase : ITLObject { }
	/// <summary>Contains user authorization info.		<para>See <a href="https://corefork.telegram.org/constructor/auth.authorization"/></para></summary>
	[TLDef(0xCD050916)]
	public partial class Auth_Authorization : Auth_AuthorizationBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Temporary <a href="https://corefork.telegram.org/passport">passport</a> sessions</summary>
		[IfFlag(0)] public int tmp_sessions;
		/// <summary>Info on authorized user</summary>
		public UserBase user;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="tmp_sessions"/> has a value</summary>
			has_tmp_sessions = 0x1,
		}
	}
	/// <summary>An account with this phone number doesn't exist on telegram: the user has to <a href="https://corefork.telegram.org/api/auth">enter basic information and sign up</a>		<para>See <a href="https://corefork.telegram.org/constructor/auth.authorizationSignUpRequired"/></para></summary>
	[TLDef(0x44747E9A)]
	public partial class Auth_AuthorizationSignUpRequired : Auth_AuthorizationBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Telegram's terms of service: the user must read and accept the terms of service before signing up to telegram</summary>
		[IfFlag(0)] public Help_TermsOfService terms_of_service;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="terms_of_service"/> has a value</summary>
			has_terms_of_service = 0x1,
		}
	}

	/// <summary>Data for copying of authorization between data centres.		<para>See <a href="https://corefork.telegram.org/constructor/auth.exportedAuthorization"/></para></summary>
	[TLDef(0xB434E2B8)]
	public partial class Auth_ExportedAuthorization : ITLObject
	{
		/// <summary>current user identifier</summary>
		public long id;
		/// <summary>authorizes key</summary>
		public byte[] bytes;
	}

	/// <summary>Object defines the set of users and/or groups that generate notifications.		<para>Derived classes: <see cref="InputNotifyPeer"/>, <see cref="InputNotifyUsers"/>, <see cref="InputNotifyChats"/>, <see cref="InputNotifyBroadcasts"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputNotifyPeer"/></para></summary>
	public abstract partial class InputNotifyPeerBase : ITLObject { }
	/// <summary>Notifications generated by a certain user or group.		<para>See <a href="https://corefork.telegram.org/constructor/inputNotifyPeer"/></para></summary>
	[TLDef(0xB8BC5B0C)]
	public partial class InputNotifyPeer : InputNotifyPeerBase
	{
		/// <summary>User or group</summary>
		public InputPeer peer;
	}
	/// <summary>Notifications generated by all users.		<para>See <a href="https://corefork.telegram.org/constructor/inputNotifyUsers"/></para></summary>
	[TLDef(0x193B4417)]
	public partial class InputNotifyUsers : InputNotifyPeerBase { }
	/// <summary>Notifications generated by all groups.		<para>See <a href="https://corefork.telegram.org/constructor/inputNotifyChats"/></para></summary>
	[TLDef(0x4A95E84E)]
	public partial class InputNotifyChats : InputNotifyPeerBase { }
	/// <summary>All <a href="https://corefork.telegram.org/api/channel">channels</a>		<para>See <a href="https://corefork.telegram.org/constructor/inputNotifyBroadcasts"/></para></summary>
	[TLDef(0xB1DB7C7E)]
	public partial class InputNotifyBroadcasts : InputNotifyPeerBase { }

	/// <summary>Notification settings.		<para>See <a href="https://corefork.telegram.org/constructor/inputPeerNotifySettings"/></para></summary>
	[TLDef(0x9C3D198E)]
	public partial class InputPeerNotifySettings : ITLObject
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
		[IfFlag(3)] public string sound;

		[Flags] public enum Flags
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
	[TLDef(0xAF509D20)]
	public partial class PeerNotifySettings : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Display text in notifications</summary>
		[IfFlag(0)] public bool show_previews;
		/// <summary>Mute peer?</summary>
		[IfFlag(1)] public bool silent;
		/// <summary>Mute all notifications until this date</summary>
		[IfFlag(2)] public int mute_until;
		/// <summary>Audio file name for notifications</summary>
		[IfFlag(3)] public string sound;

		[Flags] public enum Flags
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

	/// <summary>Peer settings		<para>See <a href="https://corefork.telegram.org/constructor/peerSettings"/></para></summary>
	[TLDef(0x733F2961)]
	public partial class PeerSettings : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Distance in meters between us and this peer</summary>
		[IfFlag(6)] public int geo_distance;

		[Flags] public enum Flags
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
			/// <summary>Whether we can report a geogroup is irrelevant for this location</summary>
			report_geo = 0x20,
			/// <summary>Field <see cref="geo_distance"/> has a value</summary>
			has_geo_distance = 0x40,
			/// <summary>Whether this peer was automatically archived according to <see cref="GlobalPrivacySettings"/></summary>
			autoarchived = 0x80,
			/// <summary>Whether we can invite members to a <a href="https://corefork.telegram.org/api/channel">group or channel</a></summary>
			invite_members = 0x100,
		}
	}

	/// <summary>Object contains info on a wallpaper.		<para>Derived classes: <see cref="WallPaper"/>, <see cref="WallPaperNoFile"/></para>		<para>See <a href="https://corefork.telegram.org/type/WallPaper"/></para></summary>
	public abstract partial class WallPaperBase : ITLObject
	{
		/// <summary>Identifier</summary>
		public abstract long ID { get; }
		/// <summary>Wallpaper settings</summary>
		public abstract WallPaperSettings Settings { get; }
	}
	/// <summary>Wallpaper settings.		<para>See <a href="https://corefork.telegram.org/constructor/wallPaper"/></para></summary>
	[TLDef(0xA437C3ED)]
	public partial class WallPaper : WallPaperBase
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

		[Flags] public enum Flags
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
	public partial class WallPaperNoFile : WallPaperBase
	{
		/// <summary>Wallpaper ID</summary>
		public long id;
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Wallpaper settings</summary>
		[IfFlag(2)] public WallPaperSettings settings;

		[Flags] public enum Flags
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
	}

	/// <summary>Extended user info		<para>See <a href="https://corefork.telegram.org/constructor/userFull"/></para></summary>
	[TLDef(0xD697FF05)]
	public partial class UserFull : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Remaining user info</summary>
		public UserBase user;
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

		[Flags] public enum Flags
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
			/// <summary>Whether this user's privacy settings allow you to call him</summary>
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
		}
	}

	/// <summary>A contact of the current user that is registered in the system.		<para>See <a href="https://corefork.telegram.org/constructor/contact"/></para></summary>
	[TLDef(0x145ADE0B)]
	public partial class Contact : ITLObject
	{
		/// <summary>User identifier</summary>
		public long user_id;
		/// <summary>Current user is in the user's contact list</summary>
		public bool mutual;
	}

	/// <summary>Successfully imported contact.		<para>See <a href="https://corefork.telegram.org/constructor/importedContact"/></para></summary>
	[TLDef(0xC13E3C50)]
	public partial class ImportedContact : ITLObject
	{
		/// <summary>User identifier</summary>
		public long user_id;
		/// <summary>The contact's client identifier (passed to one of the <see cref="InputContact"/> constructors)</summary>
		public long client_id;
	}

	/// <summary>Contact status: online / offline.		<para>See <a href="https://corefork.telegram.org/constructor/contactStatus"/></para></summary>
	[TLDef(0x16D9703B)]
	public partial class ContactStatus : ITLObject
	{
		/// <summary>User identifier</summary>
		public long user_id;
		/// <summary>Online status</summary>
		public UserStatus status;
	}

	/// <summary>The current user's contact list and info on users.		<para>See <a href="https://corefork.telegram.org/constructor/contacts.contacts"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/contacts.contactsNotModified">contacts.contactsNotModified</a></remarks>
	[TLDef(0xEAE87E42)]
	public partial class Contacts_Contacts : ITLObject
	{
		/// <summary>Contact list</summary>
		public Contact[] contacts;
		/// <summary>Number of contacts that were saved successfully</summary>
		public int saved_count;
		/// <summary>User list</summary>
		public Dictionary<long, UserBase> users;
	}

	/// <summary>Info on succesfully imported contacts.		<para>See <a href="https://corefork.telegram.org/constructor/contacts.importedContacts"/></para></summary>
	[TLDef(0x77D01C3B)]
	public partial class Contacts_ImportedContacts : ITLObject
	{
		/// <summary>List of succesfully imported contacts</summary>
		public ImportedContact[] imported;
		/// <summary>Popular contacts</summary>
		public PopularContact[] popular_invites;
		/// <summary>List of contact ids that could not be imported due to system limitation and will need to be imported at a later date.<br/>Parameter added in <a href="https://corefork.telegram.org/api/layers#layer-13">Layer 13</a></summary>
		public long[] retry_contacts;
		/// <summary>List of users</summary>
		public Dictionary<long, UserBase> users;
	}

	/// <summary>Full list of blocked users.		<para>See <a href="https://corefork.telegram.org/constructor/contacts.blocked"/></para></summary>
	[TLDef(0x0ADE1591)]
	public partial class Contacts_Blocked : ITLObject
	{
		/// <summary>List of blocked users</summary>
		public PeerBlocked[] blocked;
		/// <summary>Blocked chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>List of users</summary>
		public Dictionary<long, UserBase> users;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}
	/// <summary>Incomplete list of blocked users.		<para>See <a href="https://corefork.telegram.org/constructor/contacts.blockedSlice"/></para></summary>
	[TLDef(0xE1664194, inheritAfter = true)]
	public partial class Contacts_BlockedSlice : Contacts_Blocked
	{
		/// <summary>Total number of elements in the list</summary>
		public int count;
	}

	/// <summary>Object contains a list of chats with messages and auxiliary data.		<para>Derived classes: <see cref="Messages_Dialogs"/>, <see cref="Messages_DialogsSlice"/>, <see cref="Messages_DialogsNotModified"/></para>		<para>See <a href="https://corefork.telegram.org/type/messages.Dialogs"/></para></summary>
	public abstract partial class Messages_DialogsBase : ITLObject
	{
		/// <summary>List of chats</summary>
		public abstract DialogBase[] Dialogs { get; }
		/// <summary>List of last messages from each chat</summary>
		public abstract MessageBase[] Messages { get; }
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public abstract IPeerInfo UserOrChat(Peer peer);
	}
	/// <summary>Full list of chats with messages and auxiliary data.		<para>See <a href="https://corefork.telegram.org/constructor/messages.dialogs"/></para></summary>
	[TLDef(0x15BA6C40)]
	public partial class Messages_Dialogs : Messages_DialogsBase
	{
		/// <summary>List of chats</summary>
		public DialogBase[] dialogs;
		/// <summary>List of last messages from each chat</summary>
		public MessageBase[] messages;
		/// <summary>List of groups mentioned in the chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>List of users mentioned in messages and groups</summary>
		public Dictionary<long, UserBase> users;

		/// <summary>List of chats</summary>
		public override DialogBase[] Dialogs => dialogs;
		/// <summary>List of last messages from each chat</summary>
		public override MessageBase[] Messages => messages;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}
	/// <summary>Incomplete list of dialogs with messages and auxiliary data.		<para>See <a href="https://corefork.telegram.org/constructor/messages.dialogsSlice"/></para></summary>
	[TLDef(0x71E094F3, inheritAfter = true)]
	public partial class Messages_DialogsSlice : Messages_Dialogs
	{
		/// <summary>Total number of dialogs</summary>
		public int count;
	}
	/// <summary>Dialogs haven't changed		<para>See <a href="https://corefork.telegram.org/constructor/messages.dialogsNotModified"/></para></summary>
	[TLDef(0xF0E3E596)]
	public partial class Messages_DialogsNotModified : Messages_DialogsBase
	{
		/// <summary>Number of dialogs found server-side by the query</summary>
		public int count;

		public override DialogBase[] Dialogs => default;
		public override MessageBase[] Messages => default;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => null;
	}

	/// <summary>Object contains infor on list of messages with auxiliary data.		<para>Derived classes: <see cref="Messages_Messages"/>, <see cref="Messages_MessagesSlice"/>, <see cref="Messages_ChannelMessages"/>, <see cref="Messages_MessagesNotModified"/></para>		<para>See <a href="https://corefork.telegram.org/type/messages.Messages"/></para></summary>
	public abstract partial class Messages_MessagesBase : ITLObject
	{
		/// <summary>List of messages</summary>
		public abstract MessageBase[] Messages { get; }
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public abstract IPeerInfo UserOrChat(Peer peer);
	}
	/// <summary>Full list of messages with auxilary data.		<para>See <a href="https://corefork.telegram.org/constructor/messages.messages"/></para></summary>
	[TLDef(0x8C718E87)]
	public partial class Messages_Messages : Messages_MessagesBase
	{
		/// <summary>List of messages</summary>
		public MessageBase[] messages;
		/// <summary>List of chats mentioned in dialogs</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>List of users mentioned in messages and chats</summary>
		public Dictionary<long, UserBase> users;

		/// <summary>List of messages</summary>
		public override MessageBase[] Messages => messages;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}
	/// <summary>Incomplete list of messages and auxiliary data.		<para>See <a href="https://corefork.telegram.org/constructor/messages.messagesSlice"/></para></summary>
	[TLDef(0x3A54685E, inheritAfter = true)]
	public partial class Messages_MessagesSlice : Messages_Messages
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Total number of messages in the list</summary>
		public int count;
		/// <summary>Rate to use in the <c>offset_rate</c> parameter in the next call to <a href="https://corefork.telegram.org/method/messages.searchGlobal">messages.searchGlobal</a></summary>
		[IfFlag(0)] public int next_rate;
		/// <summary>Indicates the absolute position of <c>messages[0]</c> within the total result set with count <c>count</c>. <br/>This is useful, for example, if the result was fetched using <c>offset_id</c>, and we need to display a <c>progress/total</c> counter (like <c>photo 134 of 200</c>, for all media in a chat, we could simply use <c>photo ${offset_id_offset} of ${count}</c>.</summary>
		[IfFlag(2)] public int offset_id_offset;

		[Flags] public enum Flags
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
	public partial class Messages_ChannelMessages : Messages_MessagesBase
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
		public Dictionary<long, UserBase> users;

		[Flags] public enum Flags
		{
			/// <summary>If set, returned results may be inexact</summary>
			inexact = 0x2,
			/// <summary>Field <see cref="offset_id_offset"/> has a value</summary>
			has_offset_id_offset = 0x4,
		}

		/// <summary>Found messages</summary>
		public override MessageBase[] Messages => messages;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}
	/// <summary>No new messages matching the query were found		<para>See <a href="https://corefork.telegram.org/constructor/messages.messagesNotModified"/></para></summary>
	[TLDef(0x74535F21)]
	public partial class Messages_MessagesNotModified : Messages_MessagesBase
	{
		/// <summary>Number of results found server-side by the given query</summary>
		public int count;

		public override MessageBase[] Messages => default;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => null;
	}

	/// <summary>List of chats with auxiliary data.		<para>See <a href="https://corefork.telegram.org/constructor/messages.chats"/></para></summary>
	[TLDef(0x64FF9FD5)]
	public partial class Messages_Chats : ITLObject
	{
		/// <summary>List of chats</summary>
		public Dictionary<long, ChatBase> chats;
	}
	/// <summary>Partial list of chats, more would have to be fetched with <a href="https://corefork.telegram.org/api/offsets">pagination</a>		<para>See <a href="https://corefork.telegram.org/constructor/messages.chatsSlice"/></para></summary>
	[TLDef(0x9CD81144, inheritAfter = true)]
	public partial class Messages_ChatsSlice : Messages_Chats
	{
		/// <summary>Total number of results that were found server-side (not all are included in <c>chats</c>)</summary>
		public int count;
	}

	/// <summary>Extended info on chat and auxiliary data.		<para>See <a href="https://corefork.telegram.org/constructor/messages.chatFull"/></para></summary>
	[TLDef(0xE5D7D19C)]
	public partial class Messages_ChatFull : ITLObject
	{
		/// <summary>Extended info on a chat</summary>
		public ChatFullBase full_chat;
		/// <summary>List containing basic info on chat</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>List of users mentioned above</summary>
		public Dictionary<long, UserBase> users;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	/// <summary>Affected part of communication history with the user or in a chat.		<para>See <a href="https://corefork.telegram.org/constructor/messages.affectedHistory"/></para></summary>
	[TLDef(0xB45C69D1)]
	public partial class Messages_AffectedHistory : ITLObject
	{
		/// <summary>Number of events occured in a text box</summary>
		public int pts;
		/// <summary>Number of affected events</summary>
		public int pts_count;
		/// <summary>If a parameter contains positive value, it is necessary to repeat the method call using the given value; during the proceeding of all the history the value itself shall gradually decrease</summary>
		public int offset;
	}

	/// <summary>Object describes message filter.		<para>Derived classes: <see cref="InputMessagesFilterPhotos"/>, <see cref="InputMessagesFilterVideo"/>, <see cref="InputMessagesFilterPhotoVideo"/>, <see cref="InputMessagesFilterDocument"/>, <see cref="InputMessagesFilterUrl"/>, <see cref="InputMessagesFilterGif"/>, <see cref="InputMessagesFilterVoice"/>, <see cref="InputMessagesFilterMusic"/>, <see cref="InputMessagesFilterChatPhotos"/>, <see cref="InputMessagesFilterPhoneCalls"/>, <see cref="InputMessagesFilterRoundVoice"/>, <see cref="InputMessagesFilterRoundVideo"/>, <see cref="InputMessagesFilterMyMentions"/>, <see cref="InputMessagesFilterGeo"/>, <see cref="InputMessagesFilterContacts"/>, <see cref="InputMessagesFilterPinned"/></para>		<para>See <a href="https://corefork.telegram.org/type/MessagesFilter"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputMessagesFilterEmpty">inputMessagesFilterEmpty</a></remarks>
	public abstract partial class MessagesFilter : ITLObject { }
	/// <summary>Filter for messages containing photos.		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterPhotos"/></para></summary>
	[TLDef(0x9609A51C)]
	public partial class InputMessagesFilterPhotos : MessagesFilter { }
	/// <summary>Filter for messages containing videos.		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterVideo"/></para></summary>
	[TLDef(0x9FC00E65)]
	public partial class InputMessagesFilterVideo : MessagesFilter { }
	/// <summary>Filter for messages containing photos or videos.		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterPhotoVideo"/></para></summary>
	[TLDef(0x56E9F0E4)]
	public partial class InputMessagesFilterPhotoVideo : MessagesFilter { }
	/// <summary>Filter for messages containing documents.		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterDocument"/></para></summary>
	[TLDef(0x9EDDF188)]
	public partial class InputMessagesFilterDocument : MessagesFilter { }
	/// <summary>Return only messages containing URLs		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterUrl"/></para></summary>
	[TLDef(0x7EF0DD87)]
	public partial class InputMessagesFilterUrl : MessagesFilter { }
	/// <summary>Return only messages containing gifs		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterGif"/></para></summary>
	[TLDef(0xFFC86587)]
	public partial class InputMessagesFilterGif : MessagesFilter { }
	/// <summary>Return only messages containing voice notes		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterVoice"/></para></summary>
	[TLDef(0x50F5C392)]
	public partial class InputMessagesFilterVoice : MessagesFilter { }
	/// <summary>Return only messages containing audio files		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterMusic"/></para></summary>
	[TLDef(0x3751B49E)]
	public partial class InputMessagesFilterMusic : MessagesFilter { }
	/// <summary>Return only chat photo changes		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterChatPhotos"/></para></summary>
	[TLDef(0x3A20ECB8)]
	public partial class InputMessagesFilterChatPhotos : MessagesFilter { }
	/// <summary>Return only phone calls		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterPhoneCalls"/></para></summary>
	[TLDef(0x80C99768)]
	public partial class InputMessagesFilterPhoneCalls : MessagesFilter
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;

		[Flags] public enum Flags
		{
			/// <summary>Return only missed phone calls</summary>
			missed = 0x1,
		}
	}
	/// <summary>Return only round videos and voice notes		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterRoundVoice"/></para></summary>
	[TLDef(0x7A7C17A4)]
	public partial class InputMessagesFilterRoundVoice : MessagesFilter { }
	/// <summary>Return only round videos		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterRoundVideo"/></para></summary>
	[TLDef(0xB549DA53)]
	public partial class InputMessagesFilterRoundVideo : MessagesFilter { }
	/// <summary>Return only messages where the current user was <a href="https://corefork.telegram.org/api/mentions">mentioned</a>.		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterMyMentions"/></para></summary>
	[TLDef(0xC1F8E69A)]
	public partial class InputMessagesFilterMyMentions : MessagesFilter { }
	/// <summary>Return only messages containing geolocations		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterGeo"/></para></summary>
	[TLDef(0xE7026D0D)]
	public partial class InputMessagesFilterGeo : MessagesFilter { }
	/// <summary>Return only messages containing contacts		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterContacts"/></para></summary>
	[TLDef(0xE062DB83)]
	public partial class InputMessagesFilterContacts : MessagesFilter { }
	/// <summary>Fetch only pinned messages		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterPinned"/></para></summary>
	[TLDef(0x1BB00451)]
	public partial class InputMessagesFilterPinned : MessagesFilter { }

	/// <summary>Object contains info on events occured.		<para>Derived classes: <see cref="UpdateNewMessage"/>, <see cref="UpdateMessageID"/>, <see cref="UpdateDeleteMessages"/>, <see cref="UpdateUserTyping"/>, <see cref="UpdateChatUserTyping"/>, <see cref="UpdateChatParticipants"/>, <see cref="UpdateUserStatus"/>, <see cref="UpdateUserName"/>, <see cref="UpdateUserPhoto"/>, <see cref="UpdateNewEncryptedMessage"/>, <see cref="UpdateEncryptedChatTyping"/>, <see cref="UpdateEncryption"/>, <see cref="UpdateEncryptedMessagesRead"/>, <see cref="UpdateChatParticipantAdd"/>, <see cref="UpdateChatParticipantDelete"/>, <see cref="UpdateDcOptions"/>, <see cref="UpdateNotifySettings"/>, <see cref="UpdateServiceNotification"/>, <see cref="UpdatePrivacy"/>, <see cref="UpdateUserPhone"/>, <see cref="UpdateReadHistoryInbox"/>, <see cref="UpdateReadHistoryOutbox"/>, <see cref="UpdateWebPage"/>, <see cref="UpdateReadMessagesContents"/>, <see cref="UpdateChannelTooLong"/>, <see cref="UpdateChannel"/>, <see cref="UpdateNewChannelMessage"/>, <see cref="UpdateReadChannelInbox"/>, <see cref="UpdateDeleteChannelMessages"/>, <see cref="UpdateChannelMessageViews"/>, <see cref="UpdateChatParticipantAdmin"/>, <see cref="UpdateNewStickerSet"/>, <see cref="UpdateStickerSetsOrder"/>, <see cref="UpdateStickerSets"/>, <see cref="UpdateSavedGifs"/>, <see cref="UpdateBotInlineQuery"/>, <see cref="UpdateBotInlineSend"/>, <see cref="UpdateEditChannelMessage"/>, <see cref="UpdateBotCallbackQuery"/>, <see cref="UpdateEditMessage"/>, <see cref="UpdateInlineBotCallbackQuery"/>, <see cref="UpdateReadChannelOutbox"/>, <see cref="UpdateDraftMessage"/>, <see cref="UpdateReadFeaturedStickers"/>, <see cref="UpdateRecentStickers"/>, <see cref="UpdateConfig"/>, <see cref="UpdatePtsChanged"/>, <see cref="UpdateChannelWebPage"/>, <see cref="UpdateDialogPinned"/>, <see cref="UpdatePinnedDialogs"/>, <see cref="UpdateBotWebhookJSON"/>, <see cref="UpdateBotWebhookJSONQuery"/>, <see cref="UpdateBotShippingQuery"/>, <see cref="UpdateBotPrecheckoutQuery"/>, <see cref="UpdatePhoneCall"/>, <see cref="UpdateLangPackTooLong"/>, <see cref="UpdateLangPack"/>, <see cref="UpdateFavedStickers"/>, <see cref="UpdateChannelReadMessagesContents"/>, <see cref="UpdateContactsReset"/>, <see cref="UpdateChannelAvailableMessages"/>, <see cref="UpdateDialogUnreadMark"/>, <see cref="UpdateMessagePoll"/>, <see cref="UpdateChatDefaultBannedRights"/>, <see cref="UpdateFolderPeers"/>, <see cref="UpdatePeerSettings"/>, <see cref="UpdatePeerLocated"/>, <see cref="UpdateNewScheduledMessage"/>, <see cref="UpdateDeleteScheduledMessages"/>, <see cref="UpdateTheme"/>, <see cref="UpdateGeoLiveViewed"/>, <see cref="UpdateLoginToken"/>, <see cref="UpdateMessagePollVote"/>, <see cref="UpdateDialogFilter"/>, <see cref="UpdateDialogFilterOrder"/>, <see cref="UpdateDialogFilters"/>, <see cref="UpdatePhoneCallSignalingData"/>, <see cref="UpdateChannelMessageForwards"/>, <see cref="UpdateReadChannelDiscussionInbox"/>, <see cref="UpdateReadChannelDiscussionOutbox"/>, <see cref="UpdatePeerBlocked"/>, <see cref="UpdateChannelUserTyping"/>, <see cref="UpdatePinnedMessages"/>, <see cref="UpdatePinnedChannelMessages"/>, <see cref="UpdateChat"/>, <see cref="UpdateGroupCallParticipants"/>, <see cref="UpdateGroupCall"/>, <see cref="UpdatePeerHistoryTTL"/>, <see cref="UpdateChatParticipant"/>, <see cref="UpdateChannelParticipant"/>, <see cref="UpdateBotStopped"/>, <see cref="UpdateGroupCallConnection"/>, <see cref="UpdateBotCommands"/></para>		<para>See <a href="https://corefork.telegram.org/type/Update"/></para></summary>
	public abstract partial class Update : ITLObject { }
	/// <summary>New message in a private chat or in a <a href="https://core.telegram.org/api/channel">legacy group</a>.		<para>See <a href="https://corefork.telegram.org/constructor/updateNewMessage"/></para></summary>
	[TLDef(0x1F2B0AFD)]
	public partial class UpdateNewMessage : Update
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
	public partial class UpdateMessageID : Update
	{
		/// <summary><strong>id</strong> identifier of a respective <see cref="MessageBase"/></summary>
		public int id;
		/// <summary>Previuosly transferred client <strong>random_id</strong> identifier</summary>
		public long random_id;
	}
	/// <summary>Messages were deleted.		<para>See <a href="https://corefork.telegram.org/constructor/updateDeleteMessages"/></para></summary>
	[TLDef(0xA20DB0E5)]
	public partial class UpdateDeleteMessages : Update
	{
		/// <summary>List of identifiers of deleted messages</summary>
		public int[] messages;
		/// <summary>New quality of actions in a message box</summary>
		public int pts;
		/// <summary>Number of generated <a href="https://corefork.telegram.org/api/updates">events</a></summary>
		public int pts_count;
	}
	/// <summary>The user is preparing a message; typing, recording, uploading, etc. This update is valid for 6 seconds. If no repeated update received after 6 seconds, it should be considered that the user stopped doing whatever he's been doing.		<para>See <a href="https://corefork.telegram.org/constructor/updateUserTyping"/></para></summary>
	[TLDef(0xC01E857F)]
	public partial class UpdateUserTyping : Update
	{
		/// <summary>User id</summary>
		public long user_id;
		/// <summary>Action type<br/>Param added in <a href="https://corefork.telegram.org/api/layers#layer-17">Layer 17</a>.</summary>
		public SendMessageAction action;
	}
	/// <summary>The user is preparing a message in a group; typing, recording, uploading, etc. This update is valid for 6 seconds. If no repeated update received after 6 seconds, it should be considered that the user stopped doing whatever he's been doing.		<para>See <a href="https://corefork.telegram.org/constructor/updateChatUserTyping"/></para></summary>
	[TLDef(0x83487AF0)]
	public partial class UpdateChatUserTyping : UpdateChat
	{
		/// <summary>Peer that started typing (can be the chat itself, in case of anonymous admins).</summary>
		public Peer from_id;
		/// <summary>Type of action<br/>Parameter added in <a href="https://corefork.telegram.org/api/layers#layer-17">Layer 17</a>.</summary>
		public SendMessageAction action;
	}
	/// <summary>Composition of chat participants changed.		<para>See <a href="https://corefork.telegram.org/constructor/updateChatParticipants"/></para></summary>
	[TLDef(0x07761198)]
	public partial class UpdateChatParticipants : Update
	{
		/// <summary>Updated chat participants</summary>
		public ChatParticipantsBase participants;
	}
	/// <summary>Contact status update.		<para>See <a href="https://corefork.telegram.org/constructor/updateUserStatus"/></para></summary>
	[TLDef(0xE5BDF8DE)]
	public partial class UpdateUserStatus : Update
	{
		/// <summary>User identifier</summary>
		public long user_id;
		/// <summary>New status</summary>
		public UserStatus status;
	}
	/// <summary>Changes the user's first name, last name and username.		<para>See <a href="https://corefork.telegram.org/constructor/updateUserName"/></para></summary>
	[TLDef(0xC3F202E0)]
	public partial class UpdateUserName : Update
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
	public partial class UpdateUserPhoto : Update
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
	public partial class UpdateNewEncryptedMessage : Update
	{
		/// <summary>Message</summary>
		public EncryptedMessageBase message;
		/// <summary>New <strong>qts</strong> value, see <a href="https://corefork.telegram.org/api/updates">updates »</a> for more info.</summary>
		public int qts;
	}
	/// <summary>Interlocutor is typing a message in an encrypted chat. Update period is 6 second. If upon this time there is no repeated update, it shall be considered that the interlocutor stopped typing.		<para>See <a href="https://corefork.telegram.org/constructor/updateEncryptedChatTyping"/></para></summary>
	[TLDef(0x1710F156)]
	public partial class UpdateEncryptedChatTyping : Update
	{
		/// <summary>Chat ID</summary>
		public int chat_id;
	}
	/// <summary>Change of state in an encrypted chat.		<para>See <a href="https://corefork.telegram.org/constructor/updateEncryption"/></para></summary>
	[TLDef(0xB4A2E88D)]
	public partial class UpdateEncryption : Update
	{
		/// <summary>Encrypted chat</summary>
		public EncryptedChatBase chat;
		/// <summary>Date of change</summary>
		public DateTime date;
	}
	/// <summary>Communication history in an encrypted chat was marked as read.		<para>See <a href="https://corefork.telegram.org/constructor/updateEncryptedMessagesRead"/></para></summary>
	[TLDef(0x38FE25B7)]
	public partial class UpdateEncryptedMessagesRead : Update
	{
		/// <summary>Chat ID</summary>
		public int chat_id;
		/// <summary>Maximum value of data for read messages</summary>
		public DateTime max_date;
		/// <summary>Time when messages were read</summary>
		public DateTime date;
	}
	/// <summary>New group member.		<para>See <a href="https://corefork.telegram.org/constructor/updateChatParticipantAdd"/></para></summary>
	[TLDef(0x3DDA5451)]
	public partial class UpdateChatParticipantAdd : UpdateChat
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
	[TLDef(0xE32F3D77)]
	public partial class UpdateChatParticipantDelete : UpdateChat
	{
		/// <summary>ID of the user</summary>
		public long user_id;
		/// <summary>Used in basic groups to reorder updates and make sure that all of them was received.</summary>
		public int version;
	}
	/// <summary>Changes in the data center configuration options.		<para>See <a href="https://corefork.telegram.org/constructor/updateDcOptions"/></para></summary>
	[TLDef(0x8E5E9873)]
	public partial class UpdateDcOptions : Update
	{
		/// <summary>New connection options</summary>
		public DcOption[] dc_options;
	}
	/// <summary>Changes in notification settings.		<para>See <a href="https://corefork.telegram.org/constructor/updateNotifySettings"/></para></summary>
	[TLDef(0xBEC268EF)]
	public partial class UpdateNotifySettings : Update
	{
		/// <summary>Nofication source</summary>
		public NotifyPeerBase peer;
		/// <summary>New notification settings</summary>
		public PeerNotifySettings notify_settings;
	}
	/// <summary>A service message for the user.		<para>See <a href="https://corefork.telegram.org/constructor/updateServiceNotification"/></para></summary>
	[TLDef(0xEBE46819)]
	public partial class UpdateServiceNotification : Update
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

		[Flags] public enum Flags
		{
			/// <summary>(boolTrue) if the message must be displayed in a popup.</summary>
			popup = 0x1,
			/// <summary>Field <see cref="inbox_date"/> has a value</summary>
			has_inbox_date = 0x2,
		}
	}
	/// <summary>Privacy rules were changed		<para>See <a href="https://corefork.telegram.org/constructor/updatePrivacy"/></para></summary>
	[TLDef(0xEE3B272A)]
	public partial class UpdatePrivacy : Update
	{
		/// <summary>Peers to which the privacy rules apply</summary>
		public PrivacyKey key;
		/// <summary>New privacy rules</summary>
		public PrivacyRule[] rules;
	}
	/// <summary>A user's phone number was changed		<para>See <a href="https://corefork.telegram.org/constructor/updateUserPhone"/></para></summary>
	[TLDef(0x05492A13)]
	public partial class UpdateUserPhone : Update
	{
		/// <summary>User ID</summary>
		public long user_id;
		/// <summary>New phone number</summary>
		public string phone;
	}
	/// <summary>Incoming messages were read		<para>See <a href="https://corefork.telegram.org/constructor/updateReadHistoryInbox"/></para></summary>
	[TLDef(0x9C974FDF)]
	public partial class UpdateReadHistoryInbox : Update
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="folder_id"/> has a value</summary>
			has_folder_id = 0x1,
		}
	}
	/// <summary>Outgoing messages were read		<para>See <a href="https://corefork.telegram.org/constructor/updateReadHistoryOutbox"/></para></summary>
	[TLDef(0x2F2F21BF)]
	public partial class UpdateReadHistoryOutbox : Update
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
	public partial class UpdateWebPage : Update
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
	public partial class UpdateReadMessagesContents : Update
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
	public partial class UpdateChannelTooLong : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The channel</summary>
		public long channel_id;
		/// <summary>The <a href="https://corefork.telegram.org/api/updates">PTS</a>.</summary>
		[IfFlag(0)] public int pts;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="pts"/> has a value</summary>
			has_pts = 0x1,
		}
	}
	/// <summary>A new channel is available		<para>See <a href="https://corefork.telegram.org/constructor/updateChannel"/></para></summary>
	[TLDef(0x635B4C09)]
	public partial class UpdateChannel : Update
	{
		/// <summary>Channel ID</summary>
		public long channel_id;
	}
	/// <summary>A new message was sent in a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>		<para>See <a href="https://corefork.telegram.org/constructor/updateNewChannelMessage"/></para></summary>
	[TLDef(0x62BA04D9)]
	public partial class UpdateNewChannelMessage : UpdateNewMessage { }
	/// <summary>Incoming messages in a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> were read		<para>See <a href="https://corefork.telegram.org/constructor/updateReadChannelInbox"/></para></summary>
	[TLDef(0x922E6E10)]
	public partial class UpdateReadChannelInbox : Update
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="folder_id"/> has a value</summary>
			has_folder_id = 0x1,
		}
	}
	/// <summary>Some messages in a <a href="https://corefork.telegram.org/api/channel">supergroup/channel</a> were deleted		<para>See <a href="https://corefork.telegram.org/constructor/updateDeleteChannelMessages"/></para></summary>
	[TLDef(0xC32D5B12, inheritAfter = true)]
	public partial class UpdateDeleteChannelMessages : UpdateDeleteMessages
	{
		/// <summary>Channel ID</summary>
		public long channel_id;
	}
	/// <summary>The view counter of a message in a channel has changed		<para>See <a href="https://corefork.telegram.org/constructor/updateChannelMessageViews"/></para></summary>
	[TLDef(0xF226AC08)]
	public partial class UpdateChannelMessageViews : UpdateChannel
	{
		/// <summary>ID of the message</summary>
		public int id;
		/// <summary>New view counter</summary>
		public int views;
	}
	/// <summary>Admin permissions of a user in a <a href="https://corefork.telegram.org/api/channel">legacy group</a> were changed		<para>See <a href="https://corefork.telegram.org/constructor/updateChatParticipantAdmin"/></para></summary>
	[TLDef(0xD7CA61A2)]
	public partial class UpdateChatParticipantAdmin : UpdateChat
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
	public partial class UpdateNewStickerSet : Update
	{
		/// <summary>The installed stickerset</summary>
		public Messages_StickerSet stickerset;
	}
	/// <summary>The order of stickersets was changed		<para>See <a href="https://corefork.telegram.org/constructor/updateStickerSetsOrder"/></para></summary>
	[TLDef(0x0BB2D201)]
	public partial class UpdateStickerSetsOrder : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>New sticker order by sticker ID</summary>
		public long[] order;

		[Flags] public enum Flags
		{
			/// <summary>Whether the updated stickers are mask stickers</summary>
			masks = 0x1,
		}
	}
	/// <summary>Installed stickersets have changed, the client should refetch them using <a href="https://core.telegram.org/method/messages.getAllStickers">messages.getAllStickers</a>		<para>See <a href="https://corefork.telegram.org/constructor/updateStickerSets"/></para></summary>
	[TLDef(0x43AE3DEC)]
	public partial class UpdateStickerSets : Update { }
	/// <summary>The saved gif list has changed, the client should refetch it using <a href="https://core.telegram.org/method/messages.getSavedGifs">messages.getSavedGifs</a>		<para>See <a href="https://corefork.telegram.org/constructor/updateSavedGifs"/></para></summary>
	[TLDef(0x9375341E)]
	public partial class UpdateSavedGifs : Update { }
	/// <summary>An incoming inline query		<para>See <a href="https://corefork.telegram.org/constructor/updateBotInlineQuery"/></para></summary>
	[TLDef(0x496F379C)]
	public partial class UpdateBotInlineQuery : Update
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="geo"/> has a value</summary>
			has_geo = 0x1,
			/// <summary>Field <see cref="peer_type"/> has a value</summary>
			has_peer_type = 0x2,
		}
	}
	/// <summary>The result of an inline query that was chosen by a user and sent to their chat partner. Please see our documentation on the <a href="https://core.telegram.org/bots/inline#collecting-feedback">feedback collecting</a> for details on how to enable these updates for your bot.		<para>See <a href="https://corefork.telegram.org/constructor/updateBotInlineSend"/></para></summary>
	[TLDef(0x12F12A07)]
	public partial class UpdateBotInlineSend : Update
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="geo"/> has a value</summary>
			has_geo = 0x1,
			/// <summary>Field <see cref="msg_id"/> has a value</summary>
			has_msg_id = 0x2,
		}
	}
	/// <summary>A message was edited in a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>		<para>See <a href="https://corefork.telegram.org/constructor/updateEditChannelMessage"/></para></summary>
	[TLDef(0x1B3F4DF7)]
	public partial class UpdateEditChannelMessage : UpdateEditMessage { }
	/// <summary>A callback button was pressed, and the button data was sent to the bot that created the button		<para>See <a href="https://corefork.telegram.org/constructor/updateBotCallbackQuery"/></para></summary>
	[TLDef(0xB9CFC48D)]
	public partial class UpdateBotCallbackQuery : Update
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="data"/> has a value</summary>
			has_data = 0x1,
			/// <summary>Field <see cref="game_short_name"/> has a value</summary>
			has_game_short_name = 0x2,
		}
	}
	/// <summary>A message was edited		<para>See <a href="https://corefork.telegram.org/constructor/updateEditMessage"/></para></summary>
	[TLDef(0xE40370A3)]
	public partial class UpdateEditMessage : Update
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
	public partial class UpdateInlineBotCallbackQuery : Update
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="data"/> has a value</summary>
			has_data = 0x1,
			/// <summary>Field <see cref="game_short_name"/> has a value</summary>
			has_game_short_name = 0x2,
		}
	}
	/// <summary>Outgoing messages in a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> were read		<para>See <a href="https://corefork.telegram.org/constructor/updateReadChannelOutbox"/></para></summary>
	[TLDef(0xB75F99A9)]
	public partial class UpdateReadChannelOutbox : Update
	{
		/// <summary>Channel/supergroup ID</summary>
		public long channel_id;
		/// <summary>Position up to which all outgoing messages are read.</summary>
		public int max_id;
	}
	/// <summary>Notifies a change of a message <a href="https://corefork.telegram.org/api/drafts">draft</a>.		<para>See <a href="https://corefork.telegram.org/constructor/updateDraftMessage"/></para></summary>
	[TLDef(0xEE2BB969)]
	public partial class UpdateDraftMessage : Update
	{
		/// <summary>The peer to which the draft is associated</summary>
		public Peer peer;
		/// <summary>The draft</summary>
		public DraftMessageBase draft;
	}
	/// <summary>Some featured stickers were marked as read		<para>See <a href="https://corefork.telegram.org/constructor/updateReadFeaturedStickers"/></para></summary>
	[TLDef(0x571D2742)]
	public partial class UpdateReadFeaturedStickers : Update { }
	/// <summary>The recent sticker list was updated		<para>See <a href="https://corefork.telegram.org/constructor/updateRecentStickers"/></para></summary>
	[TLDef(0x9A422C20)]
	public partial class UpdateRecentStickers : Update { }
	/// <summary>The server-side configuration has changed; the client should re-fetch the config using <a href="https://corefork.telegram.org/method/help.getConfig">help.getConfig</a>		<para>See <a href="https://corefork.telegram.org/constructor/updateConfig"/></para></summary>
	[TLDef(0xA229DD06)]
	public partial class UpdateConfig : Update { }
	/// <summary><a href="https://corefork.telegram.org/api/updates">Common message box sequence PTS</a> has changed, <a href="https://corefork.telegram.org/api/updates#fetching-state">state has to be refetched using updates.getState</a>		<para>See <a href="https://corefork.telegram.org/constructor/updatePtsChanged"/></para></summary>
	[TLDef(0x3354678F)]
	public partial class UpdatePtsChanged : Update { }
	/// <summary>A webpage preview of a link in a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> message was generated		<para>See <a href="https://corefork.telegram.org/constructor/updateChannelWebPage"/></para></summary>
	[TLDef(0x2F2BA99F, inheritAfter = true)]
	public partial class UpdateChannelWebPage : UpdateWebPage
	{
		/// <summary><a href="https://corefork.telegram.org/api/channel">Channel/supergroup</a> ID</summary>
		public long channel_id;
	}
	/// <summary>A dialog was pinned/unpinned		<para>See <a href="https://corefork.telegram.org/constructor/updateDialogPinned"/></para></summary>
	[TLDef(0x6E6FE51C)]
	public partial class UpdateDialogPinned : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		[IfFlag(1)] public int folder_id;
		/// <summary>The dialog</summary>
		public DialogPeerBase peer;

		[Flags] public enum Flags
		{
			/// <summary>Whether the dialog was pinned</summary>
			pinned = 0x1,
			/// <summary>Field <see cref="folder_id"/> has a value</summary>
			has_folder_id = 0x2,
		}
	}
	/// <summary>Pinned dialogs were updated		<para>See <a href="https://corefork.telegram.org/constructor/updatePinnedDialogs"/></para></summary>
	[TLDef(0xFA0F3CA2)]
	public partial class UpdatePinnedDialogs : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		[IfFlag(1)] public int folder_id;
		/// <summary>New order of pinned dialogs</summary>
		[IfFlag(0)] public DialogPeerBase[] order;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="order"/> has a value</summary>
			has_order = 0x1,
			/// <summary>Field <see cref="folder_id"/> has a value</summary>
			has_folder_id = 0x2,
		}
	}
	/// <summary>A new incoming event; for bots only		<para>See <a href="https://corefork.telegram.org/constructor/updateBotWebhookJSON"/></para></summary>
	[TLDef(0x8317C0C3)]
	public partial class UpdateBotWebhookJSON : Update
	{
		/// <summary>The event</summary>
		public DataJSON data;
	}
	/// <summary>A new incoming query; for bots only		<para>See <a href="https://corefork.telegram.org/constructor/updateBotWebhookJSONQuery"/></para></summary>
	[TLDef(0x9B9240A6)]
	public partial class UpdateBotWebhookJSONQuery : Update
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
	public partial class UpdateBotShippingQuery : Update
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
	public partial class UpdateBotPrecheckoutQuery : Update
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="info"/> has a value</summary>
			has_info = 0x1,
			/// <summary>Field <see cref="shipping_option_id"/> has a value</summary>
			has_shipping_option_id = 0x2,
		}
	}
	/// <summary>An incoming phone call		<para>See <a href="https://corefork.telegram.org/constructor/updatePhoneCall"/></para></summary>
	[TLDef(0xAB0F6B1E)]
	public partial class UpdatePhoneCall : Update
	{
		/// <summary>Phone call</summary>
		public PhoneCallBase phone_call;
	}
	/// <summary>A language pack has changed, the client should manually fetch the changed strings using <a href="https://corefork.telegram.org/method/langpack.getDifference">langpack.getDifference</a>		<para>See <a href="https://corefork.telegram.org/constructor/updateLangPackTooLong"/></para></summary>
	[TLDef(0x46560264)]
	public partial class UpdateLangPackTooLong : Update
	{
		/// <summary>Language code</summary>
		public string lang_code;
	}
	/// <summary>Language pack updated		<para>See <a href="https://corefork.telegram.org/constructor/updateLangPack"/></para></summary>
	[TLDef(0x56022F4D)]
	public partial class UpdateLangPack : Update
	{
		/// <summary>Changed strings</summary>
		public LangPackDifference difference;
	}
	/// <summary>The list of favorited stickers was changed, the client should call <a href="https://corefork.telegram.org/method/messages.getFavedStickers">messages.getFavedStickers</a> to refetch the new list		<para>See <a href="https://corefork.telegram.org/constructor/updateFavedStickers"/></para></summary>
	[TLDef(0xE511996D)]
	public partial class UpdateFavedStickers : Update { }
	/// <summary>The specified <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> messages were read		<para>See <a href="https://corefork.telegram.org/constructor/updateChannelReadMessagesContents"/></para></summary>
	[TLDef(0x44BDD535)]
	public partial class UpdateChannelReadMessagesContents : UpdateChannel
	{
		/// <summary>IDs of messages that were read</summary>
		public int[] messages;
	}
	/// <summary>All contacts were deleted		<para>See <a href="https://corefork.telegram.org/constructor/updateContactsReset"/></para></summary>
	[TLDef(0x7084A7BE)]
	public partial class UpdateContactsReset : Update { }
	/// <summary>The history of a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> was hidden.		<para>See <a href="https://corefork.telegram.org/constructor/updateChannelAvailableMessages"/></para></summary>
	[TLDef(0xB23FC698)]
	public partial class UpdateChannelAvailableMessages : UpdateChannel
	{
		/// <summary>Identifier of a maximum unavailable message in a channel due to hidden history.</summary>
		public int available_min_id;
	}
	/// <summary>The manual unread mark of a chat was changed		<para>See <a href="https://corefork.telegram.org/constructor/updateDialogUnreadMark"/></para></summary>
	[TLDef(0xE16459C3)]
	public partial class UpdateDialogUnreadMark : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The dialog</summary>
		public DialogPeerBase peer;

		[Flags] public enum Flags
		{
			/// <summary>Was the chat marked or unmarked as read</summary>
			unread = 0x1,
		}
	}
	/// <summary>The results of a poll have changed		<para>See <a href="https://corefork.telegram.org/constructor/updateMessagePoll"/></para></summary>
	[TLDef(0xACA1657B)]
	public partial class UpdateMessagePoll : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Poll ID</summary>
		public long poll_id;
		/// <summary>If the server knows the client hasn't cached this poll yet, the poll itself</summary>
		[IfFlag(0)] public Poll poll;
		/// <summary>New poll results</summary>
		public PollResults results;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="poll"/> has a value</summary>
			has_poll = 0x1,
		}
	}
	/// <summary>Default banned rights in a <a href="https://corefork.telegram.org/api/channel">normal chat</a> were updated		<para>See <a href="https://corefork.telegram.org/constructor/updateChatDefaultBannedRights"/></para></summary>
	[TLDef(0x54C01850)]
	public partial class UpdateChatDefaultBannedRights : Update
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
	public partial class UpdateFolderPeers : Update
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
	public partial class UpdatePeerSettings : Update
	{
		/// <summary>The peer</summary>
		public Peer peer;
		/// <summary>Associated peer settings</summary>
		public PeerSettings settings;
	}
	/// <summary>List of peers near you was updated		<para>See <a href="https://corefork.telegram.org/constructor/updatePeerLocated"/></para></summary>
	[TLDef(0xB4AFCFB0)]
	public partial class UpdatePeerLocated : Update
	{
		/// <summary>Geolocated peer list update</summary>
		public PeerLocatedBase[] peers;
	}
	/// <summary>A message was added to the <a href="https://corefork.telegram.org/api/scheduled-messages">schedule queue of a chat</a>		<para>See <a href="https://corefork.telegram.org/constructor/updateNewScheduledMessage"/></para></summary>
	[TLDef(0x39A51DFB)]
	public partial class UpdateNewScheduledMessage : Update
	{
		/// <summary>Message</summary>
		public MessageBase message;
	}
	/// <summary>Some <a href="https://corefork.telegram.org/api/scheduled-messages">scheduled messages</a> were deleted from the schedule queue of a chat		<para>See <a href="https://corefork.telegram.org/constructor/updateDeleteScheduledMessages"/></para></summary>
	[TLDef(0x90866CEE)]
	public partial class UpdateDeleteScheduledMessages : Update
	{
		/// <summary>Peer</summary>
		public Peer peer;
		/// <summary>Deleted scheduled messages</summary>
		public int[] messages;
	}
	/// <summary>A cloud theme was updated		<para>See <a href="https://corefork.telegram.org/constructor/updateTheme"/></para></summary>
	[TLDef(0x8216FBA3)]
	public partial class UpdateTheme : Update
	{
		/// <summary>Theme</summary>
		public Theme theme;
	}
	/// <summary>Live geoposition message was viewed		<para>See <a href="https://corefork.telegram.org/constructor/updateGeoLiveViewed"/></para></summary>
	[TLDef(0x871FB939)]
	public partial class UpdateGeoLiveViewed : Update
	{
		/// <summary>The user that viewed the live geoposition</summary>
		public Peer peer;
		/// <summary>Message ID of geoposition message</summary>
		public int msg_id;
	}
	/// <summary>A login token (for login via QR code) was accepted.		<para>See <a href="https://corefork.telegram.org/constructor/updateLoginToken"/></para></summary>
	[TLDef(0x564FE691)]
	public partial class UpdateLoginToken : Update { }
	/// <summary>A specific user has voted in a poll		<para>See <a href="https://corefork.telegram.org/constructor/updateMessagePollVote"/></para></summary>
	[TLDef(0x106395C9)]
	public partial class UpdateMessagePollVote : Update
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
	public partial class UpdateDialogFilter : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary><a href="https://corefork.telegram.org/api/folders">Folder</a> ID</summary>
		public int id;
		/// <summary><a href="https://corefork.telegram.org/api/folders">Folder</a> info</summary>
		[IfFlag(0)] public DialogFilter filter;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="filter"/> has a value</summary>
			has_filter = 0x1,
		}
	}
	/// <summary>New <a href="https://corefork.telegram.org/api/folders">folder</a> order		<para>See <a href="https://corefork.telegram.org/constructor/updateDialogFilterOrder"/></para></summary>
	[TLDef(0xA5D72105)]
	public partial class UpdateDialogFilterOrder : Update
	{
		/// <summary>Ordered <a href="https://corefork.telegram.org/api/folders">folder IDs</a></summary>
		public int[] order;
	}
	/// <summary>Clients should update <a href="https://corefork.telegram.org/api/folders">folder</a> info		<para>See <a href="https://corefork.telegram.org/constructor/updateDialogFilters"/></para></summary>
	[TLDef(0x3504914F)]
	public partial class UpdateDialogFilters : Update { }
	/// <summary>Incoming phone call signaling payload		<para>See <a href="https://corefork.telegram.org/constructor/updatePhoneCallSignalingData"/></para></summary>
	[TLDef(0x2661BF09)]
	public partial class UpdatePhoneCallSignalingData : Update
	{
		/// <summary>Phone call ID</summary>
		public long phone_call_id;
		/// <summary>Signaling payload</summary>
		public byte[] data;
	}
	/// <summary>The forward counter of a message in a channel has changed		<para>See <a href="https://corefork.telegram.org/constructor/updateChannelMessageForwards"/></para></summary>
	[TLDef(0xD29A27F4)]
	public partial class UpdateChannelMessageForwards : UpdateChannel
	{
		/// <summary>ID of the message</summary>
		public int id;
		/// <summary>New forward counter</summary>
		public int forwards;
	}
	/// <summary>Incoming comments in a <a href="https://corefork.telegram.org/api/threads">discussion thread</a> were marked as read		<para>See <a href="https://corefork.telegram.org/constructor/updateReadChannelDiscussionInbox"/></para></summary>
	[TLDef(0xD6B19546)]
	public partial class UpdateReadChannelDiscussionInbox : Update
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="broadcast_id"/> has a value</summary>
			has_broadcast_id = 0x1,
		}
	}
	/// <summary>Outgoing comments in a <a href="https://corefork.telegram.org/api/threads">discussion thread</a> were marked as read		<para>See <a href="https://corefork.telegram.org/constructor/updateReadChannelDiscussionOutbox"/></para></summary>
	[TLDef(0x695C9E7C)]
	public partial class UpdateReadChannelDiscussionOutbox : Update
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
	public partial class UpdatePeerBlocked : Update
	{
		/// <summary>The blocked peer</summary>
		public Peer peer_id;
		/// <summary>Whether the peer was blocked or unblocked</summary>
		public bool blocked;
	}
	/// <summary>A user is typing in a <a href="https://corefork.telegram.org/api/channel">supergroup, channel</a> or <a href="https://corefork.telegram.org/api/threads">message thread</a>		<para>See <a href="https://corefork.telegram.org/constructor/updateChannelUserTyping"/></para></summary>
	[TLDef(0x8C88C923)]
	public partial class UpdateChannelUserTyping : Update
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="top_msg_id"/> has a value</summary>
			has_top_msg_id = 0x1,
		}
	}
	/// <summary>Some messages were pinned in a chat		<para>See <a href="https://corefork.telegram.org/constructor/updatePinnedMessages"/></para></summary>
	[TLDef(0xED85EAB5)]
	public partial class UpdatePinnedMessages : Update
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

		[Flags] public enum Flags
		{
			/// <summary>Whether the messages were pinned or unpinned</summary>
			pinned = 0x1,
		}
	}
	/// <summary>Messages were pinned/unpinned in a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>		<para>See <a href="https://corefork.telegram.org/constructor/updatePinnedChannelMessages"/></para></summary>
	[TLDef(0x5BB98608)]
	public partial class UpdatePinnedChannelMessages : Update
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

		[Flags] public enum Flags
		{
			/// <summary>Whether the messages were pinned or unpinned</summary>
			pinned = 0x1,
		}
	}
	/// <summary>A new chat is available		<para>See <a href="https://corefork.telegram.org/constructor/updateChat"/></para></summary>
	[TLDef(0xF89A6A4E)]
	public partial class UpdateChat : Update
	{
		/// <summary>Chat ID</summary>
		public long chat_id;
	}
	/// <summary>The participant list of a certain group call has changed		<para>See <a href="https://corefork.telegram.org/constructor/updateGroupCallParticipants"/></para></summary>
	[TLDef(0xF2EBDB4E)]
	public partial class UpdateGroupCallParticipants : Update
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
	public partial class UpdateGroupCall : Update
	{
		/// <summary>The <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> where this group call or livestream takes place</summary>
		public long chat_id;
		/// <summary>Info about the group call or livestream</summary>
		public GroupCallBase call;
	}
	/// <summary>The Time-To-Live for messages sent by the current user in a specific chat has changed		<para>See <a href="https://corefork.telegram.org/constructor/updatePeerHistoryTTL"/></para></summary>
	[TLDef(0xBB9BB9A5)]
	public partial class UpdatePeerHistoryTTL : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The chat</summary>
		public Peer peer;
		/// <summary>The new Time-To-Live</summary>
		[IfFlag(0)] public int ttl_period;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="ttl_period"/> has a value</summary>
			has_ttl_period = 0x1,
		}
	}
	/// <summary>A user has joined or left a specific chat		<para>See <a href="https://corefork.telegram.org/constructor/updateChatParticipant"/></para></summary>
	[TLDef(0xD087663A)]
	public partial class UpdateChatParticipant : Update
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

		[Flags] public enum Flags
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
	public partial class UpdateChannelParticipant : Update
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

		[Flags] public enum Flags
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
	public partial class UpdateBotStopped : Update
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
	public partial class UpdateGroupCallConnection : Update
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>WebRTC parameters</summary>
		public DataJSON params_;

		[Flags] public enum Flags
		{
			/// <summary>Are these parameters related to the screen capture session currently in progress?</summary>
			presentation = 0x1,
		}
	}
	/// <summary>The <a href="https://corefork.telegram.org/bots/api#june-25-2021">command set</a> of a certain bot in a certain chat has changed.		<para>See <a href="https://corefork.telegram.org/constructor/updateBotCommands"/></para></summary>
	[TLDef(0x4D712F2E)]
	public partial class UpdateBotCommands : Update
	{
		/// <summary>The affected chat</summary>
		public Peer peer;
		/// <summary>ID of the bot that changed its command set</summary>
		public long bot_id;
		/// <summary>New bot commands</summary>
		public BotCommand[] commands;
	}
	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/updatePendingJoinRequests"/></para></summary>
	[TLDef(0x7063C3DB)]
	public partial class UpdatePendingJoinRequests : Update
	{
		public Peer peer;
		public int requests_pending;
		public long[] recent_requesters;
	}
	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/updateBotChatInviteRequester"/></para></summary>
	[TLDef(0x11DFA986)]
	public partial class UpdateBotChatInviteRequester : Update
	{
		public Peer peer;
		public DateTime date;
		public long user_id;
		public string about;
		public ExportedChatInvite invite;
		public int qts;
	}

	/// <summary>Updates state.		<para>See <a href="https://corefork.telegram.org/constructor/updates.state"/></para></summary>
	[TLDef(0xA56C2A3E)]
	public partial class Updates_State : ITLObject
	{
		/// <summary>Number of events occured in a text box</summary>
		public int pts;
		/// <summary>Position in a sequence of updates in secret chats. For further detailes refer to article <a href="https://corefork.telegram.org/api/end-to-end">secret chats</a><br/>Parameter was added in <a href="https://corefork.telegram.org/api/layers#layer-8">eigth layer</a>.</summary>
		public int qts;
		/// <summary>Date of condition</summary>
		public DateTime date;
		/// <summary>Number of sent updates</summary>
		public int seq;
		/// <summary>Number of unread messages</summary>
		public int unread_count;
	}

	/// <summary>Occurred changes.		<para>Derived classes: <see cref="Updates_DifferenceEmpty"/>, <see cref="Updates_Difference"/>, <see cref="Updates_DifferenceSlice"/>, <see cref="Updates_DifferenceTooLong"/></para>		<para>See <a href="https://corefork.telegram.org/type/updates.Difference"/></para></summary>
	public abstract partial class Updates_DifferenceBase : ITLObject
	{
		/// <summary>List of new messages</summary>
		public abstract MessageBase[] NewMessages { get; }
		/// <summary>List of new encrypted secret chat messages</summary>
		public abstract EncryptedMessageBase[] NewEncryptedMessages { get; }
		/// <summary>List of updates</summary>
		public abstract Update[] OtherUpdates { get; }
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public abstract IPeerInfo UserOrChat(Peer peer);
	}
	/// <summary>No events.		<para>See <a href="https://corefork.telegram.org/constructor/updates.differenceEmpty"/></para></summary>
	[TLDef(0x5D75A138)]
	public partial class Updates_DifferenceEmpty : Updates_DifferenceBase
	{
		/// <summary>Current date</summary>
		public DateTime date;
		/// <summary>Number of sent updates</summary>
		public int seq;

		public override MessageBase[] NewMessages => Array.Empty<MessageBase>();
		public override EncryptedMessageBase[] NewEncryptedMessages => Array.Empty<EncryptedMessageBase>();
		public override Update[] OtherUpdates => Array.Empty<Update>();
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => null;
	}
	/// <summary>Full list of occurred events.		<para>See <a href="https://corefork.telegram.org/constructor/updates.difference"/></para></summary>
	[TLDef(0x00F49CA0)]
	public partial class Updates_Difference : Updates_DifferenceBase
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
		public Dictionary<long, UserBase> users;
		/// <summary>Current state</summary>
		public Updates_State state;

		/// <summary>List of new messages</summary>
		public override MessageBase[] NewMessages => new_messages;
		/// <summary>List of new encrypted secret chat messages</summary>
		public override EncryptedMessageBase[] NewEncryptedMessages => new_encrypted_messages;
		/// <summary>List of updates</summary>
		public override Update[] OtherUpdates => other_updates;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}
	/// <summary>Incomplete list of occurred events.		<para>See <a href="https://corefork.telegram.org/constructor/updates.differenceSlice"/></para></summary>
	[TLDef(0xA8FB1981)]
	public partial class Updates_DifferenceSlice : Updates_DifferenceBase
	{
		/// <summary>List of new messgaes</summary>
		public MessageBase[] new_messages;
		/// <summary>New messages from the <a href="https://corefork.telegram.org/api/updates">encrypted event sequence</a></summary>
		public EncryptedMessageBase[] new_encrypted_messages;
		/// <summary>List of updates</summary>
		public Update[] other_updates;
		/// <summary>List of chats mentioned in events</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>List of users mentioned in events</summary>
		public Dictionary<long, UserBase> users;
		/// <summary>Intermediary state</summary>
		public Updates_State intermediate_state;

		/// <summary>List of new messgaes</summary>
		public override MessageBase[] NewMessages => new_messages;
		/// <summary>New messages from the <a href="https://corefork.telegram.org/api/updates">encrypted event sequence</a></summary>
		public override EncryptedMessageBase[] NewEncryptedMessages => new_encrypted_messages;
		/// <summary>List of updates</summary>
		public override Update[] OtherUpdates => other_updates;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}
	/// <summary>The difference is <a href="https://corefork.telegram.org/api/updates#recovering-gaps">too long</a>, and the specified state must be used to refetch updates.		<para>See <a href="https://corefork.telegram.org/constructor/updates.differenceTooLong"/></para></summary>
	[TLDef(0x4AFE8F6D)]
	public partial class Updates_DifferenceTooLong : Updates_DifferenceBase
	{
		/// <summary>The new state to use.</summary>
		public int pts;

		public override MessageBase[] NewMessages => default;
		public override EncryptedMessageBase[] NewEncryptedMessages => default;
		public override Update[] OtherUpdates => default;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => null;
	}

	/// <summary>Object which is perceived by the client without a call on its part when an event occurs.		<para>Derived classes: <see cref="UpdatesTooLong"/>, <see cref="UpdateShortMessage"/>, <see cref="UpdateShortChatMessage"/>, <see cref="UpdateShort"/>, <see cref="UpdatesCombined"/>, <see cref="Updates"/>, <see cref="UpdateShortSentMessage"/></para>		<para>See <a href="https://corefork.telegram.org/type/Updates"/></para></summary>
	public abstract partial class UpdatesBase : ITLObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/updates">date</a></summary>
		public abstract DateTime Date { get; }
	}
	/// <summary>Too many updates, it is necessary to execute <a href="https://corefork.telegram.org/method/updates.getDifference">updates.getDifference</a>.		<para>See <a href="https://corefork.telegram.org/constructor/updatesTooLong"/></para></summary>
	[TLDef(0xE317AF7E)]
	public partial class UpdatesTooLong : UpdatesBase
	{
		public override DateTime Date => default;
	}
	/// <summary>Info about a message sent to (received from) another user		<para>See <a href="https://corefork.telegram.org/constructor/updateShortMessage"/></para></summary>
	[TLDef(0x313BC7F8)]
	public partial class UpdateShortMessage : UpdatesBase
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

		[Flags] public enum Flags
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
	}
	/// <summary>Shortened constructor containing info on one new incoming text message from a chat		<para>See <a href="https://corefork.telegram.org/constructor/updateShortChatMessage"/></para></summary>
	[TLDef(0x4D6DEEA5)]
	public partial class UpdateShortChatMessage : UpdatesBase
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

		[Flags] public enum Flags
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
	}
	/// <summary>Shortened constructor containing info on one update not requiring auxiliary data		<para>See <a href="https://corefork.telegram.org/constructor/updateShort"/></para></summary>
	[TLDef(0x78D4DEC1)]
	public partial class UpdateShort : UpdatesBase
	{
		/// <summary>Update</summary>
		public Update update;
		/// <summary>Date of event</summary>
		public DateTime date;

		/// <summary>Date of event</summary>
		public override DateTime Date => date;
	}
	/// <summary>Constructor for a group of updates.		<para>See <a href="https://corefork.telegram.org/constructor/updatesCombined"/></para></summary>
	[TLDef(0x725B04C3)]
	public partial class UpdatesCombined : UpdatesBase
	{
		/// <summary>List of updates</summary>
		public Update[] updates;
		/// <summary>List of users mentioned in updates</summary>
		public Dictionary<long, UserBase> users;
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
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}
	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/updates"/></para></summary>
	[TLDef(0x74AE4240)]
	public partial class Updates : UpdatesBase
	{
		/// <summary>List of updates</summary>
		public Update[] updates;
		/// <summary>List of users mentioned in updates</summary>
		public Dictionary<long, UserBase> users;
		/// <summary>List of chats mentioned in updates</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Current date</summary>
		public DateTime date;
		/// <summary>Total number of sent updates</summary>
		public int seq;

		/// <summary>Current date</summary>
		public override DateTime Date => date;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}
	/// <summary>Shortened constructor containing info on one outgoing message to a contact (the destination chat has to be extracted from the method call that returned this object).		<para>See <a href="https://corefork.telegram.org/constructor/updateShortSentMessage"/></para></summary>
	[TLDef(0x9015E101)]
	public partial class UpdateShortSentMessage : UpdatesBase
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

		[Flags] public enum Flags
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
	}

	/// <summary>Full list of photos with auxiliary data.		<para>See <a href="https://corefork.telegram.org/constructor/photos.photos"/></para></summary>
	[TLDef(0x8DCA6AA5)]
	public partial class Photos_Photos : ITLObject
	{
		/// <summary>List of photos</summary>
		public PhotoBase[] photos;
		/// <summary>List of mentioned users</summary>
		public Dictionary<long, UserBase> users;
	}
	/// <summary>Incomplete list of photos with auxiliary data.		<para>See <a href="https://corefork.telegram.org/constructor/photos.photosSlice"/></para></summary>
	[TLDef(0x15051F54, inheritAfter = true)]
	public partial class Photos_PhotosSlice : Photos_Photos
	{
		/// <summary>Total number of photos</summary>
		public int count;
	}

	/// <summary>Photo with auxiliary data.		<para>See <a href="https://corefork.telegram.org/constructor/photos.photo"/></para></summary>
	[TLDef(0x20212CA8)]
	public partial class Photos_Photo : ITLObject
	{
		/// <summary>Photo</summary>
		public PhotoBase photo;
		/// <summary>Users</summary>
		public Dictionary<long, UserBase> users;
	}

	/// <summary>Contains info on file.		<para>Derived classes: <see cref="Upload_File"/>, <see cref="Upload_FileCdnRedirect"/></para>		<para>See <a href="https://corefork.telegram.org/type/upload.File"/></para></summary>
	public abstract partial class Upload_FileBase : ITLObject { }
	/// <summary>File content.		<para>See <a href="https://corefork.telegram.org/constructor/upload.file"/></para></summary>
	[TLDef(0x096A18D5)]
	public partial class Upload_File : Upload_FileBase
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
	public partial class Upload_FileCdnRedirect : Upload_FileBase
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

	/// <summary>Data centre		<para>See <a href="https://corefork.telegram.org/constructor/dcOption"/></para></summary>
	[TLDef(0x18B7A10D)]
	public partial class DcOption : ITLObject
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

		[Flags] public enum Flags
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
			/// <summary>Field <see cref="secret"/> has a value</summary>
			has_secret = 0x400,
		}
	}

	/// <summary>Current configuration		<para>See <a href="https://corefork.telegram.org/constructor/config"/></para></summary>
	[TLDef(0x330B4067)]
	public partial class Config : ITLObject
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

		[Flags] public enum Flags
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
		}
	}

	/// <summary>Nearest data centre, according to geo-ip.		<para>See <a href="https://corefork.telegram.org/constructor/nearestDc"/></para></summary>
	[TLDef(0x8E1A1775)]
	public partial class NearestDc : ITLObject
	{
		/// <summary>Country code determined by geo-ip</summary>
		public string country;
		/// <summary>Number of current data centre</summary>
		public int this_dc;
		/// <summary>Number of nearest data centre</summary>
		public int nearest_dc;
	}

	/// <summary>An update is available for the application.		<para>See <a href="https://corefork.telegram.org/constructor/help.appUpdate"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.noAppUpdate">help.noAppUpdate</a></remarks>
	[TLDef(0xCCBBCE30)]
	public partial class Help_AppUpdate : ITLObject
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

		[Flags] public enum Flags
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
	public partial class Help_InviteText : ITLObject
	{
		/// <summary>Text of the message</summary>
		public string message;
	}

	/// <summary>Object contains info on an encrypted chat.		<para>Derived classes: <see cref="EncryptedChatEmpty"/>, <see cref="EncryptedChatWaiting"/>, <see cref="EncryptedChatRequested"/>, <see cref="EncryptedChat"/>, <see cref="EncryptedChatDiscarded"/></para>		<para>See <a href="https://corefork.telegram.org/type/EncryptedChat"/></para></summary>
	public abstract partial class EncryptedChatBase : ITLObject
	{
		/// <summary>Chat ID</summary>
		public abstract int ID { get; }
	}
	/// <summary>Empty constructor.		<para>See <a href="https://corefork.telegram.org/constructor/encryptedChatEmpty"/></para></summary>
	[TLDef(0xAB7EC0A0)]
	public partial class EncryptedChatEmpty : EncryptedChatBase
	{
		/// <summary>Chat ID</summary>
		public int id;

		/// <summary>Chat ID</summary>
		public override int ID => id;
	}
	/// <summary>Chat waiting for approval of second participant.		<para>See <a href="https://corefork.telegram.org/constructor/encryptedChatWaiting"/></para></summary>
	[TLDef(0x66B25953)]
	public partial class EncryptedChatWaiting : EncryptedChatBase
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
	public partial class EncryptedChatRequested : EncryptedChatBase
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="folder_id"/> has a value</summary>
			has_folder_id = 0x1,
		}

		/// <summary>Chat ID</summary>
		public override int ID => id;
	}
	/// <summary>Encrypted chat		<para>See <a href="https://corefork.telegram.org/constructor/encryptedChat"/></para></summary>
	[TLDef(0x61F0D4C7)]
	public partial class EncryptedChat : EncryptedChatBase
	{
		/// <summary>Chat ID</summary>
		public int id;
		/// <summary>Check sum dependant on the user ID</summary>
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
	public partial class EncryptedChatDiscarded : EncryptedChatBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Chat ID</summary>
		public int id;

		[Flags] public enum Flags
		{
			/// <summary>Whether both users of this secret chat should also remove all of its messages</summary>
			history_deleted = 0x1,
		}

		/// <summary>Chat ID</summary>
		public override int ID => id;
	}

	/// <summary>Creates an encrypted chat.		<para>See <a href="https://corefork.telegram.org/constructor/inputEncryptedChat"/></para></summary>
	[TLDef(0xF141B5E1)]
	public partial class InputEncryptedChat : ITLObject
	{
		/// <summary>Chat ID</summary>
		public int chat_id;
		/// <summary>Checking sum from constructor <see cref="EncryptedChat"/>, <see cref="EncryptedChatWaiting"/> or <see cref="EncryptedChatRequested"/></summary>
		public long access_hash;
	}

	/// <summary>Encrypted file.		<para>See <a href="https://corefork.telegram.org/constructor/encryptedFile"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/encryptedFileEmpty">encryptedFileEmpty</a></remarks>
	[TLDef(0x4A70994C)]
	public partial class EncryptedFile : ITLObject
	{
		/// <summary>File ID</summary>
		public long id;
		/// <summary>Checking sum depending on user ID</summary>
		public long access_hash;
		/// <summary>File size in bytes</summary>
		public int size;
		/// <summary>Number of data centre</summary>
		public int dc_id;
		/// <summary>32-bit fingerprint of key used for file encryption</summary>
		public int key_fingerprint;
	}

	/// <summary>Object sets encrypted file for attachment		<para>Derived classes: <see cref="InputEncryptedFileUploaded"/>, <see cref="InputEncryptedFile"/>, <see cref="InputEncryptedFileBigUploaded"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputEncryptedFile"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputEncryptedFileEmpty">inputEncryptedFileEmpty</a></remarks>
	public abstract partial class InputEncryptedFileBase : ITLObject
	{
		/// <summary>Random file ID created by clien</summary>
		public abstract long ID { get; }
	}
	/// <summary>Sets new encrypted file saved by parts using upload.saveFilePart method.		<para>See <a href="https://corefork.telegram.org/constructor/inputEncryptedFileUploaded"/></para></summary>
	[TLDef(0x64BD0306)]
	public partial class InputEncryptedFileUploaded : InputEncryptedFileBase
	{
		/// <summary>Random file ID created by clien</summary>
		public long id;
		/// <summary>Number of saved parts</summary>
		public int parts;
		/// <summary>In case <a href="https://en.wikipedia.org/wiki/MD5">md5-HASH</a> of the (already encrypted) file was transmitted, file content will be checked prior to use</summary>
		public byte[] md5_checksum;
		/// <summary>32-bit fingerprint of the key used to encrypt a file</summary>
		public int key_fingerprint;

		/// <summary>Random file ID created by clien</summary>
		public override long ID => id;
	}
	/// <summary>Sets forwarded encrypted file for attachment.		<para>See <a href="https://corefork.telegram.org/constructor/inputEncryptedFile"/></para></summary>
	[TLDef(0x5A17B5E5)]
	public partial class InputEncryptedFile : InputEncryptedFileBase
	{
		/// <summary>File ID, value of <strong>id</strong> parameter from <see cref="EncryptedFile"/></summary>
		public long id;
		/// <summary>Checking sum, value of <strong>access_hash</strong> parameter from <see cref="EncryptedFile"/></summary>
		public long access_hash;

		/// <summary>File ID, value of <strong>id</strong> parameter from <see cref="EncryptedFile"/></summary>
		public override long ID => id;
	}
	/// <summary>Assigns a new big encrypted file (over 10Mb in size), saved in parts using the method <a href="https://corefork.telegram.org/method/upload.saveBigFilePart">upload.saveBigFilePart</a>.		<para>See <a href="https://corefork.telegram.org/constructor/inputEncryptedFileBigUploaded"/></para></summary>
	[TLDef(0x2DC173C8)]
	public partial class InputEncryptedFileBigUploaded : InputEncryptedFileBase
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
	public abstract partial class EncryptedMessageBase : ITLObject
	{
		/// <summary>Random message ID, assigned by the author of message</summary>
		public abstract long RandomId { get; }
		/// <summary>ID of encrypted chat</summary>
		public abstract int ChatId { get; }
		/// <summary>Date of sending</summary>
		public abstract DateTime Date { get; }
		/// <summary>TL-serialising of <see cref="DecryptedMessageBase"/> type, encrypted with the key creatied at stage of chat initialization</summary>
		public abstract byte[] Bytes { get; }
	}
	/// <summary>Encrypted message.		<para>See <a href="https://corefork.telegram.org/constructor/encryptedMessage"/></para></summary>
	[TLDef(0xED18C118)]
	public partial class EncryptedMessage : EncryptedMessageBase
	{
		/// <summary>Random message ID, assigned by the author of message</summary>
		public long random_id;
		/// <summary>ID of encrypted chat</summary>
		public int chat_id;
		/// <summary>Date of sending</summary>
		public DateTime date;
		/// <summary>TL-serialising of <see cref="DecryptedMessageBase"/> type, encrypted with the key creatied at stage of chat initialization</summary>
		public byte[] bytes;
		/// <summary>Attached encrypted file</summary>
		public EncryptedFile file;

		/// <summary>Random message ID, assigned by the author of message</summary>
		public override long RandomId => random_id;
		/// <summary>ID of encrypted chat</summary>
		public override int ChatId => chat_id;
		/// <summary>Date of sending</summary>
		public override DateTime Date => date;
		/// <summary>TL-serialising of <see cref="DecryptedMessageBase"/> type, encrypted with the key creatied at stage of chat initialization</summary>
		public override byte[] Bytes => bytes;
	}
	/// <summary>Encrypted service message		<para>See <a href="https://corefork.telegram.org/constructor/encryptedMessageService"/></para></summary>
	[TLDef(0x23734B06)]
	public partial class EncryptedMessageService : EncryptedMessageBase
	{
		/// <summary>Random message ID, assigned by the author of message</summary>
		public long random_id;
		/// <summary>ID of encrypted chat</summary>
		public int chat_id;
		/// <summary>Date of sending</summary>
		public DateTime date;
		/// <summary>TL-serialising of <see cref="DecryptedMessageBase"/> type, encrypted with the key creatied at stage of chat initialization</summary>
		public byte[] bytes;

		/// <summary>Random message ID, assigned by the author of message</summary>
		public override long RandomId => random_id;
		/// <summary>ID of encrypted chat</summary>
		public override int ChatId => chat_id;
		/// <summary>Date of sending</summary>
		public override DateTime Date => date;
		/// <summary>TL-serialising of <see cref="DecryptedMessageBase"/> type, encrypted with the key creatied at stage of chat initialization</summary>
		public override byte[] Bytes => bytes;
	}

	/// <summary><para>Derived classes: <see cref="Messages_DhConfigNotModified"/>, <see cref="Messages_DhConfig"/></para>		<para>See <a href="https://corefork.telegram.org/type/messages.DhConfig"/></para></summary>
	public abstract partial class Messages_DhConfigBase : ITLObject { }
	/// <summary>Configuring parameters did not change.		<para>See <a href="https://corefork.telegram.org/constructor/messages.dhConfigNotModified"/></para></summary>
	[TLDef(0xC0E24635)]
	public partial class Messages_DhConfigNotModified : Messages_DhConfigBase
	{
		/// <summary>Random sequence of bytes of assigned length</summary>
		public byte[] random;
	}
	/// <summary>New set of configuring parameters.		<para>See <a href="https://corefork.telegram.org/constructor/messages.dhConfig"/></para></summary>
	[TLDef(0x2C221EDD)]
	public partial class Messages_DhConfig : Messages_DhConfigBase
	{
		/// <summary>New value <strong>prime</strong>, see <a href="https://en.wikipedia.org/wiki/Diffie%E2%80%93Hellman_key_exchange">Wikipedia</a></summary>
		public int g;
		/// <summary>New value <strong>primitive root</strong>, see <a href="https://en.wikipedia.org/wiki/Diffie%E2%80%93Hellman_key_exchange">Wikipedia</a></summary>
		public byte[] p;
		/// <summary>Vestion of set of parameters</summary>
		public int version;
		/// <summary>Random sequence of bytes of assigned length</summary>
		public byte[] random;
	}

	/// <summary>Message without file attachemts sent to an encrypted file.		<para>See <a href="https://corefork.telegram.org/constructor/messages.sentEncryptedMessage"/></para></summary>
	[TLDef(0x560F8935)]
	public partial class Messages_SentEncryptedMessage : ITLObject
	{
		/// <summary>Date of sending</summary>
		public DateTime date;
	}
	/// <summary>Message with a file enclosure sent to a protected chat		<para>See <a href="https://corefork.telegram.org/constructor/messages.sentEncryptedFile"/></para></summary>
	[TLDef(0x9493FF32)]
	public partial class Messages_SentEncryptedFile : Messages_SentEncryptedMessage
	{
		/// <summary>Attached file</summary>
		public EncryptedFile file;
	}

	/// <summary>Defines a video for subsequent interaction.		<para>See <a href="https://corefork.telegram.org/constructor/inputDocument"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputDocumentEmpty">inputDocumentEmpty</a></remarks>
	[TLDef(0x1ABFB575)]
	public partial class InputDocument : ITLObject
	{
		/// <summary>Document ID</summary>
		public long id;
		/// <summary><strong>access_hash</strong> parameter from the <see cref="Document"/> constructor</summary>
		public long access_hash;
		/// <summary><a href="https://corefork.telegram.org/api/file_reference">File reference</a></summary>
		public byte[] file_reference;
	}

	/// <summary>A document.		<para>Derived classes: <see cref="DocumentEmpty"/>, <see cref="Document"/></para>		<para>See <a href="https://corefork.telegram.org/type/Document"/></para></summary>
	public abstract partial class DocumentBase : ITLObject { }
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
		/// <summary>Check sum, dependant on document ID</summary>
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="thumbs"/> has a value</summary>
			has_thumbs = 0x1,
			/// <summary>Field <see cref="video_thumbs"/> has a value</summary>
			has_video_thumbs = 0x2,
		}
	}

	/// <summary>Info on support user.		<para>See <a href="https://corefork.telegram.org/constructor/help.support"/></para></summary>
	[TLDef(0x17C6B5F6)]
	public partial class Help_Support : ITLObject
	{
		/// <summary>Phone number</summary>
		public string phone_number;
		/// <summary>User</summary>
		public UserBase user;
	}

	/// <summary>Object defines the set of users and/or groups that generate notifications.		<para>Derived classes: <see cref="NotifyPeer"/>, <see cref="NotifyUsers"/>, <see cref="NotifyChats"/>, <see cref="NotifyBroadcasts"/></para>		<para>See <a href="https://corefork.telegram.org/type/NotifyPeer"/></para></summary>
	public abstract partial class NotifyPeerBase : ITLObject { }
	/// <summary>Notifications generated by a certain user or group.		<para>See <a href="https://corefork.telegram.org/constructor/notifyPeer"/></para></summary>
	[TLDef(0x9FD40BD8)]
	public partial class NotifyPeer : NotifyPeerBase
	{
		/// <summary>user or group</summary>
		public Peer peer;
	}
	/// <summary>Notifications generated by all users.		<para>See <a href="https://corefork.telegram.org/constructor/notifyUsers"/></para></summary>
	[TLDef(0xB4C83B4C)]
	public partial class NotifyUsers : NotifyPeerBase { }
	/// <summary>Notifications generated by all groups.		<para>See <a href="https://corefork.telegram.org/constructor/notifyChats"/></para></summary>
	[TLDef(0xC007CEC3)]
	public partial class NotifyChats : NotifyPeerBase { }
	/// <summary>Channel notification settings		<para>See <a href="https://corefork.telegram.org/constructor/notifyBroadcasts"/></para></summary>
	[TLDef(0xD612E8EF)]
	public partial class NotifyBroadcasts : NotifyPeerBase { }

	/// <summary>User actions. Use this to provide users with detailed info about their chat partners' actions: typing or sending attachments of all kinds.		<para>Derived classes: <see cref="SendMessageTypingAction"/>, <see cref="SendMessageCancelAction"/>, <see cref="SendMessageRecordVideoAction"/>, <see cref="SendMessageUploadVideoAction"/>, <see cref="SendMessageRecordAudioAction"/>, <see cref="SendMessageUploadAudioAction"/>, <see cref="SendMessageUploadPhotoAction"/>, <see cref="SendMessageUploadDocumentAction"/>, <see cref="SendMessageGeoLocationAction"/>, <see cref="SendMessageChooseContactAction"/>, <see cref="SendMessageGamePlayAction"/>, <see cref="SendMessageRecordRoundAction"/>, <see cref="SendMessageUploadRoundAction"/>, <see cref="SpeakingInGroupCallAction"/>, <see cref="SendMessageHistoryImportAction"/>, <see cref="SendMessageChooseStickerAction"/>, <see cref="SendMessageEmojiInteraction"/>, <see cref="SendMessageEmojiInteractionSeen"/></para>		<para>See <a href="https://corefork.telegram.org/type/SendMessageAction"/></para></summary>
	public abstract partial class SendMessageAction : ITLObject { }
	/// <summary>User is typing.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageTypingAction"/></para></summary>
	[TLDef(0x16BF744E)]
	public partial class SendMessageTypingAction : SendMessageAction { }
	/// <summary>Invalidate all previous action updates. E.g. when user deletes entered text or aborts a video upload.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageCancelAction"/></para></summary>
	[TLDef(0xFD5EC8F5)]
	public partial class SendMessageCancelAction : SendMessageAction { }
	/// <summary>User is recording a video.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageRecordVideoAction"/></para></summary>
	[TLDef(0xA187D66F)]
	public partial class SendMessageRecordVideoAction : SendMessageAction { }
	/// <summary>User is uploading a video.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageUploadVideoAction"/></para></summary>
	[TLDef(0xE9763AEC)]
	public partial class SendMessageUploadVideoAction : SendMessageAction
	{
		/// <summary>Progress percentage</summary>
		public int progress;
	}
	/// <summary>User is recording a voice message.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageRecordAudioAction"/></para></summary>
	[TLDef(0xD52F73F7)]
	public partial class SendMessageRecordAudioAction : SendMessageAction { }
	/// <summary>User is uploading a voice message.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageUploadAudioAction"/></para></summary>
	[TLDef(0xF351D7AB)]
	public partial class SendMessageUploadAudioAction : SendMessageAction
	{
		/// <summary>Progress percentage</summary>
		public int progress;
	}
	/// <summary>User is uploading a photo.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageUploadPhotoAction"/></para></summary>
	[TLDef(0xD1D34A26)]
	public partial class SendMessageUploadPhotoAction : SendMessageAction
	{
		/// <summary>Progress percentage</summary>
		public int progress;
	}
	/// <summary>User is uploading a file.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageUploadDocumentAction"/></para></summary>
	[TLDef(0xAA0CD9E4)]
	public partial class SendMessageUploadDocumentAction : SendMessageAction
	{
		/// <summary>Progress percentage</summary>
		public int progress;
	}
	/// <summary>User is selecting a location to share.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageGeoLocationAction"/></para></summary>
	[TLDef(0x176F8BA1)]
	public partial class SendMessageGeoLocationAction : SendMessageAction { }
	/// <summary>User is selecting a contact to share.		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageChooseContactAction"/></para></summary>
	[TLDef(0x628CBC6F)]
	public partial class SendMessageChooseContactAction : SendMessageAction { }
	/// <summary>User is playing a game		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageGamePlayAction"/></para></summary>
	[TLDef(0xDD6A8F48)]
	public partial class SendMessageGamePlayAction : SendMessageAction { }
	/// <summary>User is recording a round video to share		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageRecordRoundAction"/></para></summary>
	[TLDef(0x88F27FBC)]
	public partial class SendMessageRecordRoundAction : SendMessageAction { }
	/// <summary>User is uploading a round video		<para>See <a href="https://corefork.telegram.org/constructor/sendMessageUploadRoundAction"/></para></summary>
	[TLDef(0x243E1C66)]
	public partial class SendMessageUploadRoundAction : SendMessageAction
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
	public partial class SendMessageChooseStickerAction : SendMessageAction { }
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
	public partial class Contacts_Found : ITLObject
	{
		/// <summary>Personalized results</summary>
		public Peer[] my_results;
		/// <summary>List of found user identifiers</summary>
		public Peer[] results;
		/// <summary>Found chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>List of users</summary>
		public Dictionary<long, UserBase> users;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
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
	public abstract partial class InputPrivacyRule : ITLObject { }
	/// <summary>Allow only contacts		<para>See <a href="https://corefork.telegram.org/constructor/inputPrivacyValueAllowContacts"/></para></summary>
	[TLDef(0x0D09E07B)]
	public partial class InputPrivacyValueAllowContacts : InputPrivacyRule { }
	/// <summary>Allow all users		<para>See <a href="https://corefork.telegram.org/constructor/inputPrivacyValueAllowAll"/></para></summary>
	[TLDef(0x184B35CE)]
	public partial class InputPrivacyValueAllowAll : InputPrivacyRule { }
	/// <summary>Allow only certain users		<para>See <a href="https://corefork.telegram.org/constructor/inputPrivacyValueAllowUsers"/></para></summary>
	[TLDef(0x131CC67F)]
	public partial class InputPrivacyValueAllowUsers : InputPrivacyRule
	{
		/// <summary>Allowed users</summary>
		public InputUserBase[] users;
	}
	/// <summary>Disallow only contacts		<para>See <a href="https://corefork.telegram.org/constructor/inputPrivacyValueDisallowContacts"/></para></summary>
	[TLDef(0x0BA52007)]
	public partial class InputPrivacyValueDisallowContacts : InputPrivacyRule { }
	/// <summary>Disallow all		<para>See <a href="https://corefork.telegram.org/constructor/inputPrivacyValueDisallowAll"/></para></summary>
	[TLDef(0xD66B66C9)]
	public partial class InputPrivacyValueDisallowAll : InputPrivacyRule { }
	/// <summary>Disallow only certain users		<para>See <a href="https://corefork.telegram.org/constructor/inputPrivacyValueDisallowUsers"/></para></summary>
	[TLDef(0x90110467)]
	public partial class InputPrivacyValueDisallowUsers : InputPrivacyRule
	{
		/// <summary>Users to disallow</summary>
		public InputUserBase[] users;
	}
	/// <summary>Allow only participants of certain chats		<para>See <a href="https://corefork.telegram.org/constructor/inputPrivacyValueAllowChatParticipants"/></para></summary>
	[TLDef(0x840649CF)]
	public partial class InputPrivacyValueAllowChatParticipants : InputPrivacyRule
	{
		/// <summary>Allowed chat IDs</summary>
		public long[] chats;
	}
	/// <summary>Disallow only participants of certain chats		<para>See <a href="https://corefork.telegram.org/constructor/inputPrivacyValueDisallowChatParticipants"/></para></summary>
	[TLDef(0xE94F0F86)]
	public partial class InputPrivacyValueDisallowChatParticipants : InputPrivacyRule
	{
		/// <summary>Disallowed chat IDs</summary>
		public long[] chats;
	}

	/// <summary>Privacy rule		<para>Derived classes: <see cref="PrivacyValueAllowContacts"/>, <see cref="PrivacyValueAllowAll"/>, <see cref="PrivacyValueAllowUsers"/>, <see cref="PrivacyValueDisallowContacts"/>, <see cref="PrivacyValueDisallowAll"/>, <see cref="PrivacyValueDisallowUsers"/>, <see cref="PrivacyValueAllowChatParticipants"/>, <see cref="PrivacyValueDisallowChatParticipants"/></para>		<para>See <a href="https://corefork.telegram.org/type/PrivacyRule"/></para></summary>
	public abstract partial class PrivacyRule : ITLObject { }
	/// <summary>Allow all contacts		<para>See <a href="https://corefork.telegram.org/constructor/privacyValueAllowContacts"/></para></summary>
	[TLDef(0xFFFE1BAC)]
	public partial class PrivacyValueAllowContacts : PrivacyRule { }
	/// <summary>Allow all users		<para>See <a href="https://corefork.telegram.org/constructor/privacyValueAllowAll"/></para></summary>
	[TLDef(0x65427B82)]
	public partial class PrivacyValueAllowAll : PrivacyRule { }
	/// <summary>Allow only certain users		<para>See <a href="https://corefork.telegram.org/constructor/privacyValueAllowUsers"/></para></summary>
	[TLDef(0xB8905FB2)]
	public partial class PrivacyValueAllowUsers : PrivacyRule
	{
		/// <summary>Allowed users</summary>
		public long[] users;
	}
	/// <summary>Disallow only contacts		<para>See <a href="https://corefork.telegram.org/constructor/privacyValueDisallowContacts"/></para></summary>
	[TLDef(0xF888FA1A)]
	public partial class PrivacyValueDisallowContacts : PrivacyRule { }
	/// <summary>Disallow all users		<para>See <a href="https://corefork.telegram.org/constructor/privacyValueDisallowAll"/></para></summary>
	[TLDef(0x8B73E763)]
	public partial class PrivacyValueDisallowAll : PrivacyRule { }
	/// <summary>Disallow only certain users		<para>See <a href="https://corefork.telegram.org/constructor/privacyValueDisallowUsers"/></para></summary>
	[TLDef(0xE4621141)]
	public partial class PrivacyValueDisallowUsers : PrivacyRule
	{
		/// <summary>Disallowed users</summary>
		public long[] users;
	}
	/// <summary>Allow all participants of certain chats		<para>See <a href="https://corefork.telegram.org/constructor/privacyValueAllowChatParticipants"/></para></summary>
	[TLDef(0x6B134E8E)]
	public partial class PrivacyValueAllowChatParticipants : PrivacyRule
	{
		/// <summary>Allowed chats</summary>
		public long[] chats;
	}
	/// <summary>Disallow only participants of certain chats		<para>See <a href="https://corefork.telegram.org/constructor/privacyValueDisallowChatParticipants"/></para></summary>
	[TLDef(0x41C87565)]
	public partial class PrivacyValueDisallowChatParticipants : PrivacyRule
	{
		/// <summary>Disallowed chats</summary>
		public long[] chats;
	}

	/// <summary>Privacy rules		<para>See <a href="https://corefork.telegram.org/constructor/account.privacyRules"/></para></summary>
	[TLDef(0x50A04E45)]
	public partial class Account_PrivacyRules : ITLObject
	{
		/// <summary>Privacy rules</summary>
		public PrivacyRule[] rules;
		/// <summary>Chats to which the rules apply</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users to which the rules apply</summary>
		public Dictionary<long, UserBase> users;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	/// <summary>Time to live in days of the current account		<para>See <a href="https://corefork.telegram.org/constructor/accountDaysTTL"/></para></summary>
	[TLDef(0xB8D0AFDF)]
	public partial class AccountDaysTTL : ITLObject
	{
		/// <summary>This account will self-destruct in the specified number of days</summary>
		public int days;
	}

	/// <summary>Various possible attributes of a document (used to define if it's a sticker, a GIF, a video, a mask sticker, an image, an audio, and so on)		<para>Derived classes: <see cref="DocumentAttributeImageSize"/>, <see cref="DocumentAttributeAnimated"/>, <see cref="DocumentAttributeSticker"/>, <see cref="DocumentAttributeVideo"/>, <see cref="DocumentAttributeAudio"/>, <see cref="DocumentAttributeFilename"/>, <see cref="DocumentAttributeHasStickers"/></para>		<para>See <a href="https://corefork.telegram.org/type/DocumentAttribute"/></para></summary>
	public abstract partial class DocumentAttribute : ITLObject { }
	/// <summary>Defines the width and height of an image uploaded as document		<para>See <a href="https://corefork.telegram.org/constructor/documentAttributeImageSize"/></para></summary>
	[TLDef(0x6C37C15C)]
	public partial class DocumentAttributeImageSize : DocumentAttribute
	{
		/// <summary>Width of image</summary>
		public int w;
		/// <summary>Height of image</summary>
		public int h;
	}
	/// <summary>Defines an animated GIF		<para>See <a href="https://corefork.telegram.org/constructor/documentAttributeAnimated"/></para></summary>
	[TLDef(0x11B58939)]
	public partial class DocumentAttributeAnimated : DocumentAttribute { }
	/// <summary>Defines a sticker		<para>See <a href="https://corefork.telegram.org/constructor/documentAttributeSticker"/></para></summary>
	[TLDef(0x6319D612)]
	public partial class DocumentAttributeSticker : DocumentAttribute
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Alternative emoji representation of sticker</summary>
		public string alt;
		/// <summary>Associated stickerset</summary>
		public InputStickerSet stickerset;
		/// <summary>Mask coordinates (if this is a mask sticker, attached to a photo)</summary>
		[IfFlag(0)] public MaskCoords mask_coords;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="mask_coords"/> has a value</summary>
			has_mask_coords = 0x1,
			/// <summary>Whether this is a mask sticker</summary>
			mask = 0x2,
		}
	}
	/// <summary>Defines a video		<para>See <a href="https://corefork.telegram.org/constructor/documentAttributeVideo"/></para></summary>
	[TLDef(0x0EF02CE6)]
	public partial class DocumentAttributeVideo : DocumentAttribute
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Duration in seconds</summary>
		public int duration;
		/// <summary>Video width</summary>
		public int w;
		/// <summary>Video height</summary>
		public int h;

		[Flags] public enum Flags
		{
			/// <summary>Whether this is a round video</summary>
			round_message = 0x1,
			/// <summary>Whether the video supports streaming</summary>
			supports_streaming = 0x2,
		}
	}
	/// <summary>Represents an audio file		<para>See <a href="https://corefork.telegram.org/constructor/documentAttributeAudio"/></para></summary>
	[TLDef(0x9852F9C6)]
	public partial class DocumentAttributeAudio : DocumentAttribute
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

		[Flags] public enum Flags
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
	public partial class DocumentAttributeFilename : DocumentAttribute
	{
		/// <summary>The file name</summary>
		public string file_name;
	}
	/// <summary>Whether the current document has stickers attached		<para>See <a href="https://corefork.telegram.org/constructor/documentAttributeHasStickers"/></para></summary>
	[TLDef(0x9801D2F7)]
	public partial class DocumentAttributeHasStickers : DocumentAttribute { }

	/// <summary>Found stickers		<para>See <a href="https://corefork.telegram.org/constructor/messages.stickers"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.stickersNotModified">messages.stickersNotModified</a></remarks>
	[TLDef(0x30A6EC7E)]
	public partial class Messages_Stickers : ITLObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></summary>
		public long hash;
		/// <summary>Stickers</summary>
		public DocumentBase[] stickers;
	}

	/// <summary>A stickerpack is a group of stickers associated to the same emoji.<br/>It is <strong>not</strong> a sticker pack the way it is usually intended, you may be looking for a <see cref="StickerSet"/>.		<para>See <a href="https://corefork.telegram.org/constructor/stickerPack"/></para></summary>
	[TLDef(0x12B299D4)]
	public partial class StickerPack : ITLObject
	{
		/// <summary>Emoji</summary>
		public string emoticon;
		/// <summary>Stickers</summary>
		public long[] documents;
	}

	/// <summary>Info about all installed stickers		<para>See <a href="https://corefork.telegram.org/constructor/messages.allStickers"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.allStickersNotModified">messages.allStickersNotModified</a></remarks>
	[TLDef(0xCDBBCEBB)]
	public partial class Messages_AllStickers : ITLObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></summary>
		public long hash;
		/// <summary>All stickersets</summary>
		public StickerSet[] sets;
	}

	/// <summary>Events affected by operation		<para>See <a href="https://corefork.telegram.org/constructor/messages.affectedMessages"/></para></summary>
	[TLDef(0x84D19185)]
	public partial class Messages_AffectedMessages : ITLObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/updates">Event count after generation</a></summary>
		public int pts;
		/// <summary><a href="https://corefork.telegram.org/api/updates">Number of events that were generated</a></summary>
		public int pts_count;
	}

	/// <summary><a href="https://instantview.telegram.org">Instant View</a> webpage preview		<para>Derived classes: <see cref="WebPageEmpty"/>, <see cref="WebPagePending"/>, <see cref="WebPage"/>, <see cref="WebPageNotModified"/></para>		<para>See <a href="https://corefork.telegram.org/type/WebPage"/></para></summary>
	public abstract partial class WebPageBase : ITLObject
	{
		/// <summary>Preview ID</summary>
		public abstract long ID { get; }
	}
	/// <summary>No preview is available for the webpage		<para>See <a href="https://corefork.telegram.org/constructor/webPageEmpty"/></para></summary>
	[TLDef(0xEB1477E8)]
	public partial class WebPageEmpty : WebPageBase
	{
		/// <summary>Preview ID</summary>
		public long id;

		/// <summary>Preview ID</summary>
		public override long ID => id;
	}
	/// <summary>A preview of the webpage is currently being generated		<para>See <a href="https://corefork.telegram.org/constructor/webPagePending"/></para></summary>
	[TLDef(0xC586DA1C)]
	public partial class WebPagePending : WebPageBase
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
	public partial class WebPage : WebPageBase
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

		[Flags] public enum Flags
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
	public partial class WebPageNotModified : WebPageBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Page view count</summary>
		[IfFlag(0)] public int cached_page_views;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="cached_page_views"/> has a value</summary>
			has_cached_page_views = 0x1,
		}

		public override long ID => default;
	}

	/// <summary>Logged-in session		<para>See <a href="https://corefork.telegram.org/constructor/authorization"/></para></summary>
	[TLDef(0xAD01D61D)]
	public partial class Authorization : ITLObject
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
		public int date_created;
		/// <summary>When was the session last active</summary>
		public int date_active;
		/// <summary>Last known IP</summary>
		public string ip;
		/// <summary>Country determined from IP</summary>
		public string country;
		/// <summary>Region determined from IP</summary>
		public string region;

		[Flags] public enum Flags
		{
			/// <summary>Whether this is the current session</summary>
			current = 0x1,
			/// <summary>Whether the session is from an official app</summary>
			official_app = 0x2,
			/// <summary>Whether the session is still waiting for a 2FA password</summary>
			password_pending = 0x4,
		}
	}

	/// <summary>Logged-in sessions		<para>See <a href="https://corefork.telegram.org/constructor/account.authorizations"/></para></summary>
	[TLDef(0x1250ABDE)]
	public partial class Account_Authorizations : ITLObject
	{
		/// <summary>Logged-in sessions</summary>
		public Authorization[] authorizations;
	}

	/// <summary>Configuration for two-factor authorization		<para>See <a href="https://corefork.telegram.org/constructor/account.password"/></para></summary>
	[TLDef(0x185B184F)]
	public partial class Account_Password : ITLObject
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

		[Flags] public enum Flags
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
	public partial class Account_PasswordSettings : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary><a href="https://corefork.telegram.org/api/srp#email-verification">2FA Recovery email</a></summary>
		[IfFlag(0)] public string email;
		/// <summary>Telegram <a href="https://corefork.telegram.org/passport">passport</a> settings</summary>
		[IfFlag(1)] public SecureSecretSettings secure_settings;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="email"/> has a value</summary>
			has_email = 0x1,
			/// <summary>Field <see cref="secure_settings"/> has a value</summary>
			has_secure_settings = 0x2,
		}
	}

	/// <summary>Settings for setting up a new password		<para>See <a href="https://corefork.telegram.org/constructor/account.passwordInputSettings"/></para></summary>
	[TLDef(0xC23727C9)]
	public partial class Account_PasswordInputSettings : ITLObject
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

		[Flags] public enum Flags
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
	public partial class Auth_PasswordRecovery : ITLObject
	{
		/// <summary>The email to which the recovery code was sent must match this <a href="https://corefork.telegram.org/api/pattern">pattern</a>.</summary>
		public string email_pattern;
	}

	/// <summary>Message ID, for which PUSH-notifications were cancelled.		<para>See <a href="https://corefork.telegram.org/constructor/receivedNotifyMessage"/></para></summary>
	[TLDef(0xA384B779)]
	public partial class ReceivedNotifyMessage : ITLObject
	{
		/// <summary>Message ID, for which PUSH-notifications were canceled</summary>
		public int id;
		/// <summary>Reserved for future use</summary>
		public int flags;
	}

	/// <summary>Exported chat invite		<para>Derived classes: <see cref="ChatInviteExported"/></para>		<para>See <a href="https://corefork.telegram.org/type/ExportedChatInvite"/></para></summary>
	public abstract partial class ExportedChatInvite : ITLObject { }
	/// <summary>Exported chat invite		<para>See <a href="https://corefork.telegram.org/constructor/chatInviteExported"/></para></summary>
	[TLDef(0x0AB4A819)]
	public partial class ChatInviteExported : ExportedChatInvite
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
		[IfFlag(7)] public int requested;
		[IfFlag(8)] public string title;

		[Flags] public enum Flags
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
			request_needed = 0x40,
			/// <summary>Field <see cref="requested"/> has a value</summary>
			has_requested = 0x80,
			/// <summary>Field <see cref="title"/> has a value</summary>
			has_title = 0x100,
		}
	}

	/// <summary>Chat invite		<para>Derived classes: <see cref="ChatInviteAlready"/>, <see cref="ChatInvite"/>, <see cref="ChatInvitePeek"/></para>		<para>See <a href="https://corefork.telegram.org/type/ChatInvite"/></para></summary>
	public abstract partial class ChatInviteBase : ITLObject { }
	/// <summary>The user has already joined this chat		<para>See <a href="https://corefork.telegram.org/constructor/chatInviteAlready"/></para></summary>
	[TLDef(0x5A686D7C)]
	public partial class ChatInviteAlready : ChatInviteBase
	{
		/// <summary>The chat connected to the invite</summary>
		public ChatBase chat;
	}
	/// <summary>Chat invite info		<para>See <a href="https://corefork.telegram.org/constructor/chatInvite"/></para></summary>
	[TLDef(0x300C44C1)]
	public partial class ChatInvite : ChatInviteBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Chat/supergroup/channel title</summary>
		public string title;
		[IfFlag(5)] public string about;
		/// <summary>Chat/supergroup/channel photo</summary>
		public PhotoBase photo;
		/// <summary>Participant count</summary>
		public int participants_count;
		/// <summary>A few of the participants that are in the group</summary>
		[IfFlag(4)] public UserBase[] participants;

		[Flags] public enum Flags
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
			request_needed = 0x40,
		}
	}
	/// <summary>A chat invitation that also allows peeking into the group to read messages without joining it.		<para>See <a href="https://corefork.telegram.org/constructor/chatInvitePeek"/></para></summary>
	[TLDef(0x61695CB0)]
	public partial class ChatInvitePeek : ChatInviteBase
	{
		/// <summary>Chat information</summary>
		public ChatBase chat;
		/// <summary>Read-only anonymous access to this group will be revoked at this date</summary>
		public DateTime expires;
	}

	/// <summary>Represents a stickerset		<para>Derived classes: <see cref="InputStickerSetID"/>, <see cref="InputStickerSetShortName"/>, <see cref="InputStickerSetAnimatedEmoji"/>, <see cref="InputStickerSetDice"/>, <see cref="InputStickerSetAnimatedEmojiAnimations"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputStickerSet"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputStickerSetEmpty">inputStickerSetEmpty</a></remarks>
	public abstract partial class InputStickerSet : ITLObject { }
	/// <summary>Stickerset by ID		<para>See <a href="https://corefork.telegram.org/constructor/inputStickerSetID"/></para></summary>
	[TLDef(0x9DE7A269)]
	public partial class InputStickerSetID : InputStickerSet
	{
		/// <summary>ID</summary>
		public long id;
		/// <summary>Access hash</summary>
		public long access_hash;
	}
	/// <summary>Stickerset by short name, from <c>tg://addstickers?set=short_name</c>		<para>See <a href="https://corefork.telegram.org/constructor/inputStickerSetShortName"/></para></summary>
	[TLDef(0x861CC8A0)]
	public partial class InputStickerSetShortName : InputStickerSet
	{
		/// <summary>From <c>tg://addstickers?set=short_name</c></summary>
		public string short_name;
	}
	/// <summary>Animated emojis stickerset		<para>See <a href="https://corefork.telegram.org/constructor/inputStickerSetAnimatedEmoji"/></para></summary>
	[TLDef(0x028703C8)]
	public partial class InputStickerSetAnimatedEmoji : InputStickerSet { }
	/// <summary>Used for fetching <a href="https://corefork.telegram.org/api/dice">animated dice stickers</a>		<para>See <a href="https://corefork.telegram.org/constructor/inputStickerSetDice"/></para></summary>
	[TLDef(0xE67F520E)]
	public partial class InputStickerSetDice : InputStickerSet
	{
		/// <summary>The emoji, for now 🏀, 🎲 and 🎯 are supported</summary>
		public string emoticon;
	}
	/// <summary>Animated emoji reaction stickerset (contains animations to play when a user clicks on a given animated emoji)		<para>See <a href="https://corefork.telegram.org/constructor/inputStickerSetAnimatedEmojiAnimations"/></para></summary>
	[TLDef(0x0CDE3739)]
	public partial class InputStickerSetAnimatedEmojiAnimations : InputStickerSet { }

	/// <summary>Represents a stickerset (stickerpack)		<para>See <a href="https://corefork.telegram.org/constructor/stickerSet"/></para></summary>
	[TLDef(0xD7DF217A)]
	public partial class StickerSet : ITLObject
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

		[Flags] public enum Flags
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
		}
	}

	/// <summary>Stickerset and stickers inside it		<para>See <a href="https://corefork.telegram.org/constructor/messages.stickerSet"/></para></summary>
	[TLDef(0xB60A24A6)]
	public partial class Messages_StickerSet : ITLObject
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
	public partial class BotCommand : ITLObject
	{
		/// <summary><c>/command</c> name</summary>
		public string command;
		/// <summary>Description of the command</summary>
		public string description;
	}

	/// <summary>Info about bots (available bot commands, etc)		<para>See <a href="https://corefork.telegram.org/constructor/botInfo"/></para></summary>
	[TLDef(0x1B74B335)]
	public partial class BotInfo : ITLObject
	{
		/// <summary>ID of the bot</summary>
		public long user_id;
		/// <summary>Description of the bot</summary>
		public string description;
		/// <summary>Bot commands that can be used in the chat</summary>
		public BotCommand[] commands;
	}

	/// <summary>Bot or inline keyboard buttons		<para>Derived classes: <see cref="KeyboardButton"/>, <see cref="KeyboardButtonUrl"/>, <see cref="KeyboardButtonCallback"/>, <see cref="KeyboardButtonRequestPhone"/>, <see cref="KeyboardButtonRequestGeoLocation"/>, <see cref="KeyboardButtonSwitchInline"/>, <see cref="KeyboardButtonGame"/>, <see cref="KeyboardButtonBuy"/>, <see cref="KeyboardButtonUrlAuth"/>, <see cref="InputKeyboardButtonUrlAuth"/>, <see cref="KeyboardButtonRequestPoll"/></para>		<para>See <a href="https://corefork.telegram.org/type/KeyboardButton"/></para></summary>
	public abstract partial class KeyboardButtonBase : ITLObject
	{
		/// <summary>Button text</summary>
		public abstract string Text { get; }
	}
	/// <summary>Bot keyboard button		<para>See <a href="https://corefork.telegram.org/constructor/keyboardButton"/></para></summary>
	[TLDef(0xA2FA4880)]
	public partial class KeyboardButton : KeyboardButtonBase
	{
		/// <summary>Button text</summary>
		public string text;

		/// <summary>Button text</summary>
		public override string Text => text;
	}
	/// <summary>URL button		<para>See <a href="https://corefork.telegram.org/constructor/keyboardButtonUrl"/></para></summary>
	[TLDef(0x258AFF05)]
	public partial class KeyboardButtonUrl : KeyboardButton
	{
		/// <summary>URL</summary>
		public string url;
	}
	/// <summary>Callback button		<para>See <a href="https://corefork.telegram.org/constructor/keyboardButtonCallback"/></para></summary>
	[TLDef(0x35BBDB6B)]
	public partial class KeyboardButtonCallback : KeyboardButtonBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Button text</summary>
		public string text;
		/// <summary>Callback data</summary>
		public byte[] data;

		[Flags] public enum Flags
		{
			/// <summary>Whether the user should verify his identity by entering his <a href="https://corefork.telegram.org/api/srp">2FA SRP parameters</a> to the <a href="https://corefork.telegram.org/method/messages.getBotCallbackAnswer">messages.getBotCallbackAnswer</a> method. NOTE: telegram and the bot WILL NOT have access to the plaintext password, thanks to <a href="https://corefork.telegram.org/api/srp">SRP</a>. This button is mainly used by the official <a href="https://t.me/botfather">@botfather</a> bot, for verifying the user's identity before transferring ownership of a bot to another user.</summary>
			requires_password = 0x1,
		}

		/// <summary>Button text</summary>
		public override string Text => text;
	}
	/// <summary>Button to request a user's phone number		<para>See <a href="https://corefork.telegram.org/constructor/keyboardButtonRequestPhone"/></para></summary>
	[TLDef(0xB16A6C29)]
	public partial class KeyboardButtonRequestPhone : KeyboardButton
	{
	}
	/// <summary>Button to request a user's geolocation		<para>See <a href="https://corefork.telegram.org/constructor/keyboardButtonRequestGeoLocation"/></para></summary>
	[TLDef(0xFC796B3F)]
	public partial class KeyboardButtonRequestGeoLocation : KeyboardButton
	{
	}
	/// <summary>Button to force a user to switch to inline mode Pressing the button will prompt the user to select one of their chats, open that chat and insert the bot‘s username and the specified inline query in the input field.		<para>See <a href="https://corefork.telegram.org/constructor/keyboardButtonSwitchInline"/></para></summary>
	[TLDef(0x0568A748)]
	public partial class KeyboardButtonSwitchInline : KeyboardButtonBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Button label</summary>
		public string text;
		/// <summary>The inline query to use</summary>
		public string query;

		[Flags] public enum Flags
		{
			/// <summary>If set, pressing the button will insert the bot‘s username and the specified inline <c>query</c> in the current chat's input field.</summary>
			same_peer = 0x1,
		}

		/// <summary>Button label</summary>
		public override string Text => text;
	}
	/// <summary>Button to start a game		<para>See <a href="https://corefork.telegram.org/constructor/keyboardButtonGame"/></para></summary>
	[TLDef(0x50F41CCF)]
	public partial class KeyboardButtonGame : KeyboardButton
	{
	}
	/// <summary>Button to buy a product		<para>See <a href="https://corefork.telegram.org/constructor/keyboardButtonBuy"/></para></summary>
	[TLDef(0xAFD93FBB)]
	public partial class KeyboardButtonBuy : KeyboardButton
	{
	}
	/// <summary>Button to request a user to authorize via URL using <a href="https://telegram.org/blog/privacy-discussions-web-bots#meet-seamless-web-bots">Seamless Telegram Login</a>. When the user clicks on such a button, <a href="https://corefork.telegram.org/method/messages.requestUrlAuth">messages.requestUrlAuth</a> should be called, providing the <c>button_id</c> and the ID of the container message. The returned <see cref="UrlAuthResultRequest"/> object will contain more details about the authorization request (<c>request_write_access</c> if the bot would like to send messages to the user along with the username of the bot which will be used for user authorization). Finally, the user can choose to call <a href="https://corefork.telegram.org/method/messages.acceptUrlAuth">messages.acceptUrlAuth</a> to get a <see cref="UrlAuthResultAccepted"/> with the URL to open instead of the <c>url</c> of this constructor, or a <see cref="UrlAuthResultDefault"/>, in which case the <c>url</c> of this constructor must be opened, instead. If the user refuses the authorization request but still wants to open the link, the <c>url</c> of this constructor must be used.		<para>See <a href="https://corefork.telegram.org/constructor/keyboardButtonUrlAuth"/></para></summary>
	[TLDef(0x10B78D29)]
	public partial class KeyboardButtonUrlAuth : KeyboardButtonBase
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="fwd_text"/> has a value</summary>
			has_fwd_text = 0x1,
		}

		/// <summary>Button label</summary>
		public override string Text => text;
	}
	/// <summary>Button to request a user to <a href="https://corefork.telegram.org/method/messages.acceptUrlAuth">authorize</a> via URL using <a href="https://telegram.org/blog/privacy-discussions-web-bots#meet-seamless-web-bots">Seamless Telegram Login</a>.		<para>See <a href="https://corefork.telegram.org/constructor/inputKeyboardButtonUrlAuth"/></para></summary>
	[TLDef(0xD02E7FD4)]
	public partial class InputKeyboardButtonUrlAuth : KeyboardButtonBase
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

		[Flags] public enum Flags
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
	[TLDef(0xBBC7515D, inheritAfter = true)]
	public partial class KeyboardButtonRequestPoll : KeyboardButton
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>If set, only quiz polls can be sent</summary>
		[IfFlag(0)] public bool quiz;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="quiz"/> has a value</summary>
			has_quiz = 0x1,
		}
	}

	/// <summary>Inline keyboard row		<para>See <a href="https://corefork.telegram.org/constructor/keyboardButtonRow"/></para></summary>
	[TLDef(0x77608B83)]
	public partial class KeyboardButtonRow : ITLObject
	{
		/// <summary>Bot or inline keyboard buttons</summary>
		public KeyboardButtonBase[] buttons;
	}

	/// <summary>Reply markup for bot and inline keyboards		<para>Derived classes: <see cref="ReplyKeyboardHide"/>, <see cref="ReplyKeyboardForceReply"/>, <see cref="ReplyKeyboardMarkup"/>, <see cref="ReplyInlineMarkup"/></para>		<para>See <a href="https://corefork.telegram.org/type/ReplyMarkup"/></para></summary>
	public abstract partial class ReplyMarkup : ITLObject { }
	/// <summary>Hide sent bot keyboard		<para>See <a href="https://corefork.telegram.org/constructor/replyKeyboardHide"/></para></summary>
	[TLDef(0xA03E5B85)]
	public partial class ReplyKeyboardHide : ReplyMarkup
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;

		[Flags] public enum Flags
		{
			/// <summary>Use this flag if you want to remove the keyboard for specific users only. Targets: 1) users that are @mentioned in the text of the Message object; 2) if the bot's message is a reply (has reply_to_message_id), sender of the original message.<br/><br/>Example: A user votes in a poll, bot returns confirmation message in reply to the vote and removes the keyboard for that user, while still showing the keyboard with poll options to users who haven't voted yet</summary>
			selective = 0x4,
		}
	}
	/// <summary>Force the user to send a reply		<para>See <a href="https://corefork.telegram.org/constructor/replyKeyboardForceReply"/></para></summary>
	[TLDef(0x86B40B08)]
	public partial class ReplyKeyboardForceReply : ReplyMarkup
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The placeholder to be shown in the input field when the keyboard is active; 1-64 characters.</summary>
		[IfFlag(3)] public string placeholder;

		[Flags] public enum Flags
		{
			/// <summary>Requests clients to hide the keyboard as soon as it's been used. The keyboard will still be available, but clients will automatically display the usual letter-keyboard in the chat – the user can press a special button in the input field to see the custom keyboard again.</summary>
			single_use = 0x2,
			/// <summary>Use this parameter if you want to show the keyboard to specific users only. Targets: 1) users that are @mentioned in the text of the Message object; 2) if the bot's message is a reply (has reply_to_message_id), sender of the original message. <br/>Example: A user requests to change the bot‘s language, bot replies to the request with a keyboard to select the new language. Other users in the group don’t see the keyboard.</summary>
			selective = 0x4,
			/// <summary>Field <see cref="placeholder"/> has a value</summary>
			has_placeholder = 0x8,
		}
	}
	/// <summary>Bot keyboard		<para>See <a href="https://corefork.telegram.org/constructor/replyKeyboardMarkup"/></para></summary>
	[TLDef(0x85DD99D1)]
	public partial class ReplyKeyboardMarkup : ReplyMarkup
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Button row</summary>
		public KeyboardButtonRow[] rows;
		/// <summary>The placeholder to be shown in the input field when the keyboard is active; 1-64 characters.</summary>
		[IfFlag(3)] public string placeholder;

		[Flags] public enum Flags
		{
			/// <summary>Requests clients to resize the keyboard vertically for optimal fit (e.g., make the keyboard smaller if there are just two rows of buttons). If not set, the custom keyboard is always of the same height as the app's standard keyboard.</summary>
			resize = 0x1,
			/// <summary>Requests clients to hide the keyboard as soon as it's been used. The keyboard will still be available, but clients will automatically display the usual letter-keyboard in the chat – the user can press a special button in the input field to see the custom keyboard again.</summary>
			single_use = 0x2,
			/// <summary>Use this parameter if you want to show the keyboard to specific users only. Targets: 1) users that are @mentioned in the text of the Message object; 2) if the bot's message is a reply (has reply_to_message_id), sender of the original message.<br/><br/>Example: A user requests to change the bot‘s language, bot replies to the request with a keyboard to select the new language. Other users in the group don’t see the keyboard.</summary>
			selective = 0x4,
			/// <summary>Field <see cref="placeholder"/> has a value</summary>
			has_placeholder = 0x8,
		}
	}
	/// <summary>Bot or inline keyboard		<para>See <a href="https://corefork.telegram.org/constructor/replyInlineMarkup"/></para></summary>
	[TLDef(0x48A30254)]
	public partial class ReplyInlineMarkup : ReplyMarkup
	{
		/// <summary>Bot or inline keyboard rows</summary>
		public KeyboardButtonRow[] rows;
	}

	/// <summary>Message entities, representing styled text in a message		<para>Derived classes: <see cref="MessageEntityUnknown"/>, <see cref="MessageEntityMention"/>, <see cref="MessageEntityHashtag"/>, <see cref="MessageEntityBotCommand"/>, <see cref="MessageEntityUrl"/>, <see cref="MessageEntityEmail"/>, <see cref="MessageEntityBold"/>, <see cref="MessageEntityItalic"/>, <see cref="MessageEntityCode"/>, <see cref="MessageEntityPre"/>, <see cref="MessageEntityTextUrl"/>, <see cref="MessageEntityMentionName"/>, <see cref="InputMessageEntityMentionName"/>, <see cref="MessageEntityPhone"/>, <see cref="MessageEntityCashtag"/>, <see cref="MessageEntityUnderline"/>, <see cref="MessageEntityStrike"/>, <see cref="MessageEntityBlockquote"/>, <see cref="MessageEntityBankCard"/></para>		<para>See <a href="https://corefork.telegram.org/type/MessageEntity"/></para></summary>
	public abstract partial class MessageEntity : ITLObject
	{
		/// <summary>Offset of message entity within message (in UTF-8 codepoints)</summary>
		public int offset;
		/// <summary>Length of message entity within message (in UTF-8 codepoints)</summary>
		public int length;
	}
	/// <summary>Unknown message entity		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityUnknown"/></para></summary>
	[TLDef(0xBB92BA95)]
	public partial class MessageEntityUnknown : MessageEntity { }
	/// <summary>Message entity <a href="https://corefork.telegram.org/api/mentions">mentioning</a> the current user		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityMention"/></para></summary>
	[TLDef(0xFA04579D)]
	public partial class MessageEntityMention : MessageEntity { }
	/// <summary><strong>#hashtag</strong> message entity		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityHashtag"/></para></summary>
	[TLDef(0x6F635B0D)]
	public partial class MessageEntityHashtag : MessageEntity { }
	/// <summary>Message entity representing a bot /command		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityBotCommand"/></para></summary>
	[TLDef(0x6CEF8AC7)]
	public partial class MessageEntityBotCommand : MessageEntity { }
	/// <summary>Message entity representing an in-text url: <a href="https://google.com">https://google.com</a>; for <a href="https://google.com">text urls</a>, use <see cref="MessageEntityTextUrl"/>.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityUrl"/></para></summary>
	[TLDef(0x6ED02538)]
	public partial class MessageEntityUrl : MessageEntity { }
	/// <summary>Message entity representing an <a href="mailto:email@example.com">email@example.com</a>.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityEmail"/></para></summary>
	[TLDef(0x64E475C2)]
	public partial class MessageEntityEmail : MessageEntity { }
	/// <summary>Message entity representing <strong>bold text</strong>.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityBold"/></para></summary>
	[TLDef(0xBD610BC9)]
	public partial class MessageEntityBold : MessageEntity { }
	/// <summary>Message entity representing <em>italic text</em>.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityItalic"/></para></summary>
	[TLDef(0x826F8B60)]
	public partial class MessageEntityItalic : MessageEntity { }
	/// <summary>Message entity representing a <c>codeblock</c>.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityCode"/></para></summary>
	[TLDef(0x28A20571)]
	public partial class MessageEntityCode : MessageEntity { }
	/// <summary>Message entity representing a preformatted <c>codeblock</c>, allowing the user to specify a programming language for the codeblock.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityPre"/></para></summary>
	[TLDef(0x73924BE0)]
	public partial class MessageEntityPre : MessageEntity
	{
		/// <summary>Programming language of the code</summary>
		public string language;
	}
	/// <summary>Message entity representing a <a href="https://google.com">text url</a>: for in-text urls like <a href="https://google.com">https://google.com</a> use <see cref="MessageEntityUrl"/>.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityTextUrl"/></para></summary>
	[TLDef(0x76A6D327)]
	public partial class MessageEntityTextUrl : MessageEntity
	{
		/// <summary>The actual URL</summary>
		public string url;
	}
	/// <summary>Message entity representing a <a href="https://corefork.telegram.org/api/mentions">user mention</a>: for <em>creating</em> a mention use <see cref="InputMessageEntityMentionName"/>.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityMentionName"/></para></summary>
	[TLDef(0xDC7B1140)]
	public partial class MessageEntityMentionName : MessageEntity
	{
		/// <summary>Identifier of the user that was mentioned</summary>
		public long user_id;
	}
	/// <summary>Message entity that can be used to create a user <a href="https://corefork.telegram.org/api/mentions">user mention</a>: received mentions use the <see cref="MessageEntityMentionName"/> constructor, instead.		<para>See <a href="https://corefork.telegram.org/constructor/inputMessageEntityMentionName"/></para></summary>
	[TLDef(0x208E68C9)]
	public partial class InputMessageEntityMentionName : MessageEntity
	{
		/// <summary>Identifier of the user that was mentioned</summary>
		public InputUserBase user_id;
	}
	/// <summary>Message entity representing a phone number.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityPhone"/></para></summary>
	[TLDef(0x9B69E34B)]
	public partial class MessageEntityPhone : MessageEntity { }
	/// <summary>Message entity representing a <strong>$cashtag</strong>.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityCashtag"/></para></summary>
	[TLDef(0x4C4E743F)]
	public partial class MessageEntityCashtag : MessageEntity { }
	/// <summary>Message entity representing underlined text.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityUnderline"/></para></summary>
	[TLDef(0x9C4E7E8B)]
	public partial class MessageEntityUnderline : MessageEntity { }
	/// <summary>Message entity representing <del>strikethrough</del> text.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityStrike"/></para></summary>
	[TLDef(0xBF0693D4)]
	public partial class MessageEntityStrike : MessageEntity { }
	/// <summary>Message entity representing a block quote.		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityBlockquote"/></para></summary>
	[TLDef(0x020DF5D0)]
	public partial class MessageEntityBlockquote : MessageEntity { }
	/// <summary>Indicates a credit card number		<para>See <a href="https://corefork.telegram.org/constructor/messageEntityBankCard"/></para></summary>
	[TLDef(0x761E6AF4)]
	public partial class MessageEntityBankCard : MessageEntity { }

	/// <summary>Represents a channel		<para>Derived classes: <see cref="InputChannel"/>, <see cref="InputChannelFromMessage"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputChannel"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputChannelEmpty">inputChannelEmpty</a></remarks>
	public abstract partial class InputChannelBase : ITLObject
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
		/// <summary>Access hash taken from the <see cref="Channel"/> constructor</summary>
		public long access_hash;

		/// <summary>Channel ID</summary>
		public override long ChannelId => channel_id;
	}
	/// <summary>Defines a <a href="https://corefork.telegram.org/api/min">min</a> channel that was seen in a certain message of a certain chat.		<para>See <a href="https://corefork.telegram.org/constructor/inputChannelFromMessage"/></para></summary>
	[TLDef(0x5B934F9D)]
	public partial class InputChannelFromMessage : InputChannelBase
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
	public partial class Contacts_ResolvedPeer : ITLObject
	{
		/// <summary>The peer</summary>
		public Peer peer;
		/// <summary>Chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users</summary>
		public Dictionary<long, UserBase> users;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the result</summary>
		public IPeerInfo UserOrChat => peer.UserOrChat(users, chats);
	}

	/// <summary>Indicates a range of chat messages		<para>See <a href="https://corefork.telegram.org/constructor/messageRange"/></para></summary>
	[TLDef(0x0AE30253)]
	public partial class MessageRange : ITLObject
	{
		/// <summary>Start of range (message ID)</summary>
		public int min_id;
		/// <summary>End of range (message ID)</summary>
		public int max_id;
	}

	/// <summary>Contains the difference (new messages) between our local channel state and the remote state		<para>Derived classes: <see cref="Updates_ChannelDifferenceEmpty"/>, <see cref="Updates_ChannelDifferenceTooLong"/>, <see cref="Updates_ChannelDifference"/></para>		<para>See <a href="https://corefork.telegram.org/type/updates.ChannelDifference"/></para></summary>
	public abstract partial class Updates_ChannelDifferenceBase : ITLObject
	{
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public abstract IPeerInfo UserOrChat(Peer peer);
	}
	/// <summary>There are no new updates		<para>See <a href="https://corefork.telegram.org/constructor/updates.channelDifferenceEmpty"/></para></summary>
	[TLDef(0x3E11AFFB)]
	public partial class Updates_ChannelDifferenceEmpty : Updates_ChannelDifferenceBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The latest <a href="https://corefork.telegram.org/api/updates">PTS</a></summary>
		public int pts;
		/// <summary>Clients are supposed to refetch the channel difference after timeout seconds have elapsed</summary>
		[IfFlag(1)] public int timeout;

		[Flags] public enum Flags
		{
			/// <summary>Whether there are more updates that must be fetched (always false)</summary>
			final = 0x1,
			/// <summary>Field <see cref="timeout"/> has a value</summary>
			has_timeout = 0x2,
		}
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => null;
	}
	/// <summary>The provided <c>pts + limit &lt; remote pts</c>. Simply, there are too many updates to be fetched (more than <c>limit</c>), the client has to resolve the update gap in one of the following ways:		<para>See <a href="https://corefork.telegram.org/constructor/updates.channelDifferenceTooLong"/></para></summary>
	[TLDef(0xA4BCC6FE)]
	public partial class Updates_ChannelDifferenceTooLong : Updates_ChannelDifferenceBase
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
		public Dictionary<long, UserBase> users;

		[Flags] public enum Flags
		{
			/// <summary>Whether there are more updates that must be fetched (always false)</summary>
			final = 0x1,
			/// <summary>Field <see cref="timeout"/> has a value</summary>
			has_timeout = 0x2,
		}
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}
	/// <summary>The new updates		<para>See <a href="https://corefork.telegram.org/constructor/updates.channelDifference"/></para></summary>
	[TLDef(0x2064674E)]
	public partial class Updates_ChannelDifference : Updates_ChannelDifferenceBase
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
		public Dictionary<long, UserBase> users;

		[Flags] public enum Flags
		{
			/// <summary>Whether there are more updates to be fetched using getDifference, starting from the provided <c>pts</c></summary>
			final = 0x1,
			/// <summary>Field <see cref="timeout"/> has a value</summary>
			has_timeout = 0x2,
		}
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public override IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	/// <summary>Filter for getting only certain types of channel messages		<para>See <a href="https://corefork.telegram.org/constructor/channelMessagesFilter"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/channelMessagesFilterEmpty">channelMessagesFilterEmpty</a></remarks>
	[TLDef(0xCD77D957)]
	public partial class ChannelMessagesFilter : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>A range of messages to fetch</summary>
		public MessageRange[] ranges;

		[Flags] public enum Flags
		{
			/// <summary>Whether to exclude new messages from the search</summary>
			exclude_new_messages = 0x2,
		}
	}

	/// <summary>Channel participant		<para>Derived classes: <see cref="ChannelParticipant"/>, <see cref="ChannelParticipantSelf"/>, <see cref="ChannelParticipantCreator"/>, <see cref="ChannelParticipantAdmin"/>, <see cref="ChannelParticipantBanned"/>, <see cref="ChannelParticipantLeft"/></para>		<para>See <a href="https://corefork.telegram.org/type/ChannelParticipant"/></para></summary>
	public abstract partial class ChannelParticipantBase : ITLObject { }
	/// <summary>Channel/supergroup participant		<para>See <a href="https://corefork.telegram.org/constructor/channelParticipant"/></para></summary>
	[TLDef(0xC00C07C0)]
	public partial class ChannelParticipant : ChannelParticipantBase
	{
		/// <summary>Pariticipant user ID</summary>
		public long user_id;
		/// <summary>Date joined</summary>
		public DateTime date;
	}
	/// <summary>Myself		<para>See <a href="https://corefork.telegram.org/constructor/channelParticipantSelf"/></para></summary>
	[TLDef(0x35A8BFA7)]
	public partial class ChannelParticipantSelf : ChannelParticipantBase
	{
		public Flags flags;
		/// <summary>User ID</summary>
		public long user_id;
		/// <summary>User that invited me to the channel/supergroup</summary>
		public long inviter_id;
		/// <summary>When did I join the channel/supergroup</summary>
		public DateTime date;

		[Flags] public enum Flags
		{
			via_invite = 0x1,
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

		[Flags] public enum Flags
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

		[Flags] public enum Flags
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

		[Flags] public enum Flags
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
	public abstract partial class ChannelParticipantsFilter : ITLObject { }
	/// <summary>Fetch only recent participants		<para>See <a href="https://corefork.telegram.org/constructor/channelParticipantsRecent"/></para></summary>
	[TLDef(0xDE3F3C79)]
	public partial class ChannelParticipantsRecent : ChannelParticipantsFilter { }
	/// <summary>Fetch only admin participants		<para>See <a href="https://corefork.telegram.org/constructor/channelParticipantsAdmins"/></para></summary>
	[TLDef(0xB4608969)]
	public partial class ChannelParticipantsAdmins : ChannelParticipantsFilter { }
	/// <summary>Fetch only kicked participants		<para>See <a href="https://corefork.telegram.org/constructor/channelParticipantsKicked"/></para></summary>
	[TLDef(0xA3B54985)]
	public partial class ChannelParticipantsKicked : ChannelParticipantsFilter
	{
		/// <summary>Optional filter for searching kicked participants by name (otherwise empty)</summary>
		public string q;
	}
	/// <summary>Fetch only bot participants		<para>See <a href="https://corefork.telegram.org/constructor/channelParticipantsBots"/></para></summary>
	[TLDef(0xB0D1865B)]
	public partial class ChannelParticipantsBots : ChannelParticipantsFilter { }
	/// <summary>Fetch only banned participants		<para>See <a href="https://corefork.telegram.org/constructor/channelParticipantsBanned"/></para></summary>
	[TLDef(0x1427A5E1)]
	public partial class ChannelParticipantsBanned : ChannelParticipantsFilter
	{
		/// <summary>Optional filter for searching banned participants by name (otherwise empty)</summary>
		public string q;
	}
	/// <summary>Query participants by name		<para>See <a href="https://corefork.telegram.org/constructor/channelParticipantsSearch"/></para></summary>
	[TLDef(0x0656AC4B)]
	public partial class ChannelParticipantsSearch : ChannelParticipantsFilter
	{
		/// <summary>Search query</summary>
		public string q;
	}
	/// <summary>Fetch only participants that are also contacts		<para>See <a href="https://corefork.telegram.org/constructor/channelParticipantsContacts"/></para></summary>
	[TLDef(0xBB6AE88D)]
	public partial class ChannelParticipantsContacts : ChannelParticipantsFilter
	{
		/// <summary>Optional search query for searching contact participants by name</summary>
		public string q;
	}
	/// <summary>This filter is used when looking for supergroup members to mention.<br/>This filter will automatically remove anonymous admins, and return even non-participant users that replied to a specific <a href="https://corefork.telegram.org/api/threads">thread</a> through the <a href="https://corefork.telegram.org/api/threads#channel-comments">comment section</a> of a channel.		<para>See <a href="https://corefork.telegram.org/constructor/channelParticipantsMentions"/></para></summary>
	[TLDef(0xE04B5CEB)]
	public partial class ChannelParticipantsMentions : ChannelParticipantsFilter
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Filter by user name or username</summary>
		[IfFlag(0)] public string q;
		/// <summary>Look only for users that posted in this <a href="https://corefork.telegram.org/api/threads">thread</a></summary>
		[IfFlag(1)] public int top_msg_id;

		[Flags] public enum Flags
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
	public partial class Channels_ChannelParticipants : ITLObject
	{
		/// <summary>Total number of participants that correspond to the given query</summary>
		public int count;
		/// <summary>Participants</summary>
		public ChannelParticipantBase[] participants;
		/// <summary>Mentioned chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users mentioned in participant info</summary>
		public Dictionary<long, UserBase> users;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	/// <summary>Represents a channel participant		<para>See <a href="https://corefork.telegram.org/constructor/channels.channelParticipant"/></para></summary>
	[TLDef(0xDFB80317)]
	public partial class Channels_ChannelParticipant : ITLObject
	{
		/// <summary>The channel participant</summary>
		public ChannelParticipantBase participant;
		/// <summary>Mentioned chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users</summary>
		public Dictionary<long, UserBase> users;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	/// <summary>Info about the latest telegram Terms Of Service		<para>See <a href="https://corefork.telegram.org/constructor/help.termsOfService"/></para></summary>
	[TLDef(0x780A0310)]
	public partial class Help_TermsOfService : ITLObject
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

		[Flags] public enum Flags
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
	public partial class Messages_SavedGifs : ITLObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></summary>
		public long hash;
		/// <summary>List of saved gifs</summary>
		public DocumentBase[] gifs;
	}

	/// <summary>Represents a sent inline message from the perspective of a bot		<para>Derived classes: <see cref="InputBotInlineMessageMediaAuto"/>, <see cref="InputBotInlineMessageText"/>, <see cref="InputBotInlineMessageMediaGeo"/>, <see cref="InputBotInlineMessageMediaVenue"/>, <see cref="InputBotInlineMessageMediaContact"/>, <see cref="InputBotInlineMessageGame"/>, <see cref="InputBotInlineMessageMediaInvoice"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputBotInlineMessage"/></para></summary>
	public abstract partial class InputBotInlineMessage : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public int flags;
	}
	/// <summary>A media		<para>See <a href="https://corefork.telegram.org/constructor/inputBotInlineMessageMediaAuto"/></para></summary>
	[TLDef(0x3380C786)]
	public partial class InputBotInlineMessageMediaAuto : InputBotInlineMessage
	{
		/// <summary>Caption</summary>
		public string message;
		/// <summary><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></summary>
		[IfFlag(1)] public MessageEntity[] entities;
		/// <summary>Inline keyboard</summary>
		[IfFlag(2)] public ReplyMarkup reply_markup;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="entities"/> has a value</summary>
			has_entities = 0x2,
			/// <summary>Field <see cref="reply_markup"/> has a value</summary>
			has_reply_markup = 0x4,
		}
	}
	/// <summary>Simple text message		<para>See <a href="https://corefork.telegram.org/constructor/inputBotInlineMessageText"/></para></summary>
	[TLDef(0x3DCD7A87)]
	public partial class InputBotInlineMessageText : InputBotInlineMessage
	{
		/// <summary>Message</summary>
		public string message;
		/// <summary><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></summary>
		[IfFlag(1)] public MessageEntity[] entities;
		/// <summary>Inline keyboard</summary>
		[IfFlag(2)] public ReplyMarkup reply_markup;

		[Flags] public enum Flags
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
	public partial class InputBotInlineMessageMediaGeo : InputBotInlineMessage
	{
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

		[Flags] public enum Flags
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
	public partial class InputBotInlineMessageMediaVenue : InputBotInlineMessage
	{
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="reply_markup"/> has a value</summary>
			has_reply_markup = 0x4,
		}
	}
	/// <summary>A contact		<para>See <a href="https://corefork.telegram.org/constructor/inputBotInlineMessageMediaContact"/></para></summary>
	[TLDef(0xA6EDBFFD)]
	public partial class InputBotInlineMessageMediaContact : InputBotInlineMessage
	{
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="reply_markup"/> has a value</summary>
			has_reply_markup = 0x4,
		}
	}
	/// <summary>A game		<para>See <a href="https://corefork.telegram.org/constructor/inputBotInlineMessageGame"/></para></summary>
	[TLDef(0x4B425864)]
	public partial class InputBotInlineMessageGame : InputBotInlineMessage
	{
		/// <summary>Inline keyboard</summary>
		[IfFlag(2)] public ReplyMarkup reply_markup;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="reply_markup"/> has a value</summary>
			has_reply_markup = 0x4,
		}
	}
	/// <summary>An invoice		<para>See <a href="https://corefork.telegram.org/constructor/inputBotInlineMessageMediaInvoice"/></para></summary>
	[TLDef(0xD7E78225)]
	public partial class InputBotInlineMessageMediaInvoice : InputBotInlineMessage
	{
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="photo"/> has a value</summary>
			has_photo = 0x1,
			/// <summary>Field <see cref="reply_markup"/> has a value</summary>
			has_reply_markup = 0x4,
		}
	}

	/// <summary>Inline bot result		<para>Derived classes: <see cref="InputBotInlineResult"/>, <see cref="InputBotInlineResultPhoto"/>, <see cref="InputBotInlineResultDocument"/>, <see cref="InputBotInlineResultGame"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputBotInlineResult"/></para></summary>
	public abstract partial class InputBotInlineResultBase : ITLObject
	{
		/// <summary>ID of result</summary>
		public abstract string ID { get; }
		/// <summary>Message to send when the result is selected</summary>
		public abstract InputBotInlineMessage SendMessage { get; }
	}
	/// <summary>An inline bot result		<para>See <a href="https://corefork.telegram.org/constructor/inputBotInlineResult"/></para></summary>
	[TLDef(0x88BF9319)]
	public partial class InputBotInlineResult : InputBotInlineResultBase
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

		[Flags] public enum Flags
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
	public partial class InputBotInlineResultPhoto : InputBotInlineResultBase
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
	public partial class InputBotInlineResultDocument : InputBotInlineResultBase
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

		[Flags] public enum Flags
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
	public partial class InputBotInlineResultGame : InputBotInlineResultBase
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
	public abstract partial class BotInlineMessage : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public int flags;
	}
	/// <summary>Send whatever media is attached to the <see cref="BotInlineMediaResult"/>		<para>See <a href="https://corefork.telegram.org/constructor/botInlineMessageMediaAuto"/></para></summary>
	[TLDef(0x764CF810)]
	public partial class BotInlineMessageMediaAuto : BotInlineMessage
	{
		/// <summary>Caption</summary>
		public string message;
		/// <summary><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></summary>
		[IfFlag(1)] public MessageEntity[] entities;
		/// <summary>Inline keyboard</summary>
		[IfFlag(2)] public ReplyMarkup reply_markup;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="entities"/> has a value</summary>
			has_entities = 0x2,
			/// <summary>Field <see cref="reply_markup"/> has a value</summary>
			has_reply_markup = 0x4,
		}
	}
	/// <summary>Send a simple text message		<para>See <a href="https://corefork.telegram.org/constructor/botInlineMessageText"/></para></summary>
	[TLDef(0x8C7F65E2)]
	public partial class BotInlineMessageText : BotInlineMessage
	{
		/// <summary>The message</summary>
		public string message;
		/// <summary><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></summary>
		[IfFlag(1)] public MessageEntity[] entities;
		/// <summary>Inline keyboard</summary>
		[IfFlag(2)] public ReplyMarkup reply_markup;

		[Flags] public enum Flags
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
	public partial class BotInlineMessageMediaGeo : BotInlineMessage
	{
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

		[Flags] public enum Flags
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
	public partial class BotInlineMessageMediaVenue : BotInlineMessage
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
		/// <summary>Inline keyboard</summary>
		[IfFlag(2)] public ReplyMarkup reply_markup;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="reply_markup"/> has a value</summary>
			has_reply_markup = 0x4,
		}
	}
	/// <summary>Send a contact		<para>See <a href="https://corefork.telegram.org/constructor/botInlineMessageMediaContact"/></para></summary>
	[TLDef(0x18D1CDC2)]
	public partial class BotInlineMessageMediaContact : BotInlineMessage
	{
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="reply_markup"/> has a value</summary>
			has_reply_markup = 0x4,
		}
	}
	/// <summary>Send an invoice		<para>See <a href="https://corefork.telegram.org/constructor/botInlineMessageMediaInvoice"/></para></summary>
	[TLDef(0x354A9B09)]
	public partial class BotInlineMessageMediaInvoice : BotInlineMessage
	{
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

		[Flags] public enum Flags
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
	public abstract partial class BotInlineResultBase : ITLObject
	{
		/// <summary>Result ID</summary>
		public abstract string ID { get; }
		/// <summary>Result type (see <a href="https://corefork.telegram.org/bots/api#inlinequeryresult">bot API docs</a>)</summary>
		public abstract string Type { get; }
		/// <summary>Message to send</summary>
		public abstract BotInlineMessage SendMessage { get; }
	}
	/// <summary>Generic result		<para>See <a href="https://corefork.telegram.org/constructor/botInlineResult"/></para></summary>
	[TLDef(0x11965F3A)]
	public partial class BotInlineResult : BotInlineResultBase
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

		[Flags] public enum Flags
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
		/// <summary>Message to send</summary>
		public override BotInlineMessage SendMessage => send_message;
	}
	/// <summary>Media result		<para>See <a href="https://corefork.telegram.org/constructor/botInlineMediaResult"/></para></summary>
	[TLDef(0x17DB940B)]
	public partial class BotInlineMediaResult : BotInlineResultBase
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

		[Flags] public enum Flags
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
		/// <summary>Depending on the <c>type</c> and on the <see cref="BotInlineMessage"/>, contains the caption of the media or the content of the message to be sent <strong>instead</strong> of the media</summary>
		public override BotInlineMessage SendMessage => send_message;
	}

	/// <summary>Result of a query to an inline bot		<para>See <a href="https://corefork.telegram.org/constructor/messages.botResults"/></para></summary>
	[TLDef(0x947CA848)]
	public partial class Messages_BotResults : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Query ID</summary>
		public long query_id;
		/// <summary>The next offset to use when navigating through results</summary>
		[IfFlag(1)] public string next_offset;
		/// <summary>Whether the bot requested the user to message him in private</summary>
		[IfFlag(2)] public InlineBotSwitchPM switch_pm;
		/// <summary>The results</summary>
		public BotInlineResultBase[] results;
		/// <summary>Caching validity of the results</summary>
		public DateTime cache_time;
		/// <summary>Users mentioned in the results</summary>
		public Dictionary<long, UserBase> users;

		[Flags] public enum Flags
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
	public partial class ExportedMessageLink : ITLObject
	{
		/// <summary>URL</summary>
		public string link;
		/// <summary>Embed code</summary>
		public string html;
	}

	/// <summary>Info about a forwarded message		<para>See <a href="https://corefork.telegram.org/constructor/messageFwdHeader"/></para></summary>
	[TLDef(0x5F777DCE)]
	public partial class MessageFwdHeader : ITLObject
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

		[Flags] public enum Flags
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
	}

	/// <summary>Type of the verification code that was sent		<para>Derived classes: <see cref="Auth_SentCodeTypeApp"/>, <see cref="Auth_SentCodeTypeSms"/>, <see cref="Auth_SentCodeTypeCall"/>, <see cref="Auth_SentCodeTypeFlashCall"/></para>		<para>See <a href="https://corefork.telegram.org/type/auth.SentCodeType"/></para></summary>
	public abstract partial class Auth_SentCodeType : ITLObject { }
	/// <summary>The code was sent through the telegram app		<para>See <a href="https://corefork.telegram.org/constructor/auth.sentCodeTypeApp"/></para></summary>
	[TLDef(0x3DBB5986)]
	public partial class Auth_SentCodeTypeApp : Auth_SentCodeType
	{
		/// <summary>Length of the code in bytes</summary>
		public int length;
	}
	/// <summary>The code was sent via SMS		<para>See <a href="https://corefork.telegram.org/constructor/auth.sentCodeTypeSms"/></para></summary>
	[TLDef(0xC000BBA2)]
	public partial class Auth_SentCodeTypeSms : Auth_SentCodeType
	{
		/// <summary>Length of the code in bytes</summary>
		public int length;
	}
	/// <summary>The code will be sent via a phone call: a synthesized voice will tell the user which verification code to input.		<para>See <a href="https://corefork.telegram.org/constructor/auth.sentCodeTypeCall"/></para></summary>
	[TLDef(0x5353E5A7)]
	public partial class Auth_SentCodeTypeCall : Auth_SentCodeType
	{
		/// <summary>Length of the verification code</summary>
		public int length;
	}
	/// <summary>The code will be sent via a flash phone call, that will be closed immediately. The phone code will then be the phone number itself, just make sure that the phone number matches the specified pattern.		<para>See <a href="https://corefork.telegram.org/constructor/auth.sentCodeTypeFlashCall"/></para></summary>
	[TLDef(0xAB03C6D9)]
	public partial class Auth_SentCodeTypeFlashCall : Auth_SentCodeType
	{
		/// <summary><a href="https://corefork.telegram.org/api/pattern">pattern</a> to match</summary>
		public string pattern;
	}

	/// <summary>Callback answer sent by the bot in response to a button press		<para>See <a href="https://corefork.telegram.org/constructor/messages.botCallbackAnswer"/></para></summary>
	[TLDef(0x36585EA4)]
	public partial class Messages_BotCallbackAnswer : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Alert to show</summary>
		[IfFlag(0)] public string message;
		/// <summary>URL to open</summary>
		[IfFlag(2)] public string url;
		/// <summary>For how long should this answer be cached</summary>
		public DateTime cache_time;

		[Flags] public enum Flags
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
	public partial class Messages_MessageEditData : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;

		[Flags] public enum Flags
		{
			/// <summary>Media caption, if the specified media's caption can be edited</summary>
			caption = 0x1,
		}
	}

	/// <summary>Represents a sent inline message from the perspective of a bot		<para>Derived classes: <see cref="InputBotInlineMessageID"/>, <see cref="InputBotInlineMessageID64"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputBotInlineMessageID"/></para></summary>
	public abstract partial class InputBotInlineMessageIDBase : ITLObject
	{
		/// <summary>DC ID to use when working with this inline message</summary>
		public abstract int DcId { get; }
		/// <summary>Access hash of message</summary>
		public abstract long AccessHash { get; }
	}
	/// <summary>Represents a sent inline message from the perspective of a bot (legacy constructor)		<para>See <a href="https://corefork.telegram.org/constructor/inputBotInlineMessageID"/></para></summary>
	[TLDef(0x890C3D89)]
	public partial class InputBotInlineMessageID : InputBotInlineMessageIDBase
	{
		/// <summary>DC ID to use when working with this inline message</summary>
		public int dc_id;
		/// <summary>ID of message, contains both the (32-bit, legacy) owner ID and the message ID, used only for Bot API backwards compatibility with 32-bit user ID.</summary>
		public long id;
		/// <summary>Access hash of message</summary>
		public long access_hash;

		/// <summary>DC ID to use when working with this inline message</summary>
		public override int DcId => dc_id;
		/// <summary>Access hash of message</summary>
		public override long AccessHash => access_hash;
	}
	/// <summary>Represents a sent inline message from the perspective of a bot		<para>See <a href="https://corefork.telegram.org/constructor/inputBotInlineMessageID64"/></para></summary>
	[TLDef(0xB6D915D7)]
	public partial class InputBotInlineMessageID64 : InputBotInlineMessageIDBase
	{
		/// <summary>DC ID to use when working with this inline message</summary>
		public int dc_id;
		/// <summary>ID of the owner of this message</summary>
		public long owner_id;
		/// <summary>ID of message</summary>
		public int id;
		/// <summary>Access hash of message</summary>
		public long access_hash;

		/// <summary>DC ID to use when working with this inline message</summary>
		public override int DcId => dc_id;
		/// <summary>Access hash of message</summary>
		public override long AccessHash => access_hash;
	}

	/// <summary>The bot requested the user to message him in private		<para>See <a href="https://corefork.telegram.org/constructor/inlineBotSwitchPM"/></para></summary>
	[TLDef(0x3C20629F)]
	public partial class InlineBotSwitchPM : ITLObject
	{
		/// <summary>Text for the button that switches the user to a private chat with the bot and sends the bot a start message with the parameter <c>start_parameter</c> (can be empty)</summary>
		public string text;
		/// <summary>The parameter for the <c>/start parameter</c></summary>
		public string start_param;
	}

	/// <summary>Dialog info of multiple peers		<para>See <a href="https://corefork.telegram.org/constructor/messages.peerDialogs"/></para></summary>
	[TLDef(0x3371C354)]
	public partial class Messages_PeerDialogs : ITLObject
	{
		/// <summary>Dialog info</summary>
		public DialogBase[] dialogs;
		/// <summary>Messages mentioned in dialog info</summary>
		public MessageBase[] messages;
		/// <summary>Chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users</summary>
		public Dictionary<long, UserBase> users;
		/// <summary>Current <a href="https://corefork.telegram.org/api/updates">update state of dialog</a></summary>
		public Updates_State state;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	/// <summary>Top peer		<para>See <a href="https://corefork.telegram.org/constructor/topPeer"/></para></summary>
	[TLDef(0xEDCDC05B)]
	public partial class TopPeer : ITLObject
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
	public partial class TopPeerCategoryPeers : ITLObject
	{
		/// <summary>Top peer category of peers</summary>
		public TopPeerCategory category;
		/// <summary>Count of peers</summary>
		public int count;
		/// <summary>Peers</summary>
		public TopPeer[] peers;
	}

	/// <summary><para>Derived classes: <see cref="Contacts_TopPeers"/>, <see cref="Contacts_TopPeersDisabled"/></para>		<para>See <a href="https://corefork.telegram.org/type/contacts.TopPeers"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/contacts.topPeersNotModified">contacts.topPeersNotModified</a></remarks>
	public abstract partial class Contacts_TopPeersBase : ITLObject { }
	/// <summary>Top peers		<para>See <a href="https://corefork.telegram.org/constructor/contacts.topPeers"/></para></summary>
	[TLDef(0x70B772A8)]
	public partial class Contacts_TopPeers : Contacts_TopPeersBase
	{
		/// <summary>Top peers by top peer category</summary>
		public TopPeerCategoryPeers[] categories;
		/// <summary>Chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users</summary>
		public Dictionary<long, UserBase> users;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}
	/// <summary>Top peers disabled		<para>See <a href="https://corefork.telegram.org/constructor/contacts.topPeersDisabled"/></para></summary>
	[TLDef(0xB52C939D)]
	public partial class Contacts_TopPeersDisabled : Contacts_TopPeersBase { }

	/// <summary>Represents a message <a href="https://corefork.telegram.org/api/drafts">draft</a>.		<para>Derived classes: <see cref="DraftMessageEmpty"/>, <see cref="DraftMessage"/></para>		<para>See <a href="https://corefork.telegram.org/type/DraftMessage"/></para></summary>
	public abstract partial class DraftMessageBase : ITLObject { }
	/// <summary>Empty draft		<para>See <a href="https://corefork.telegram.org/constructor/draftMessageEmpty"/></para></summary>
	[TLDef(0x1B0C841A)]
	public partial class DraftMessageEmpty : DraftMessageBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>When was the draft last updated</summary>
		[IfFlag(0)] public DateTime date;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="date"/> has a value</summary>
			has_date = 0x1,
		}
	}
	/// <summary>Represents a message <a href="https://corefork.telegram.org/api/drafts">draft</a>.		<para>See <a href="https://corefork.telegram.org/constructor/draftMessage"/></para></summary>
	[TLDef(0xFD8E711F)]
	public partial class DraftMessage : DraftMessageBase
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="reply_to_msg_id"/> has a value</summary>
			has_reply_to_msg_id = 0x1,
			/// <summary>Whether no webpage preview will be generated</summary>
			no_webpage = 0x2,
			/// <summary>Field <see cref="entities"/> has a value</summary>
			has_entities = 0x8,
		}
	}

	/// <summary><para>Derived classes: <see cref="Messages_FeaturedStickersNotModified"/>, <see cref="Messages_FeaturedStickers"/></para>		<para>See <a href="https://corefork.telegram.org/type/messages.FeaturedStickers"/></para></summary>
	public abstract partial class Messages_FeaturedStickersBase : ITLObject { }
	/// <summary>Featured stickers haven't changed		<para>See <a href="https://corefork.telegram.org/constructor/messages.featuredStickersNotModified"/></para></summary>
	[TLDef(0xC6DC0C66)]
	public partial class Messages_FeaturedStickersNotModified : Messages_FeaturedStickersBase
	{
		/// <summary>Total number of featured stickers</summary>
		public int count;
	}
	/// <summary>Featured stickersets		<para>See <a href="https://corefork.telegram.org/constructor/messages.featuredStickers"/></para></summary>
	[TLDef(0x84C02310)]
	public partial class Messages_FeaturedStickers : Messages_FeaturedStickersBase
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
	public partial class Messages_RecentStickers : ITLObject
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
	public partial class Messages_ArchivedStickers : ITLObject
	{
		/// <summary>Number of archived stickers</summary>
		public int count;
		/// <summary>Archived stickersets</summary>
		public StickerSetCoveredBase[] sets;
	}

	/// <summary><para>Derived classes: <see cref="Messages_StickerSetInstallResultSuccess"/>, <see cref="Messages_StickerSetInstallResultArchive"/></para>		<para>See <a href="https://corefork.telegram.org/type/messages.StickerSetInstallResult"/></para></summary>
	public abstract partial class Messages_StickerSetInstallResult : ITLObject { }
	/// <summary>The stickerset was installed successfully		<para>See <a href="https://corefork.telegram.org/constructor/messages.stickerSetInstallResultSuccess"/></para></summary>
	[TLDef(0x38641628)]
	public partial class Messages_StickerSetInstallResultSuccess : Messages_StickerSetInstallResult { }
	/// <summary>The stickerset was installed, but since there are too many stickersets some were archived		<para>See <a href="https://corefork.telegram.org/constructor/messages.stickerSetInstallResultArchive"/></para></summary>
	[TLDef(0x35E410A8)]
	public partial class Messages_StickerSetInstallResultArchive : Messages_StickerSetInstallResult
	{
		/// <summary>Archived stickersets</summary>
		public StickerSetCoveredBase[] sets;
	}

	/// <summary>Stickerset, with a specific sticker as preview		<para>Derived classes: <see cref="StickerSetCovered"/>, <see cref="StickerSetMultiCovered"/></para>		<para>See <a href="https://corefork.telegram.org/type/StickerSetCovered"/></para></summary>
	public abstract partial class StickerSetCoveredBase : ITLObject
	{
		/// <summary>Stickerset</summary>
		public abstract StickerSet Set { get; }
	}
	/// <summary>Stickerset, with a specific sticker as preview		<para>See <a href="https://corefork.telegram.org/constructor/stickerSetCovered"/></para></summary>
	[TLDef(0x6410A5D2)]
	public partial class StickerSetCovered : StickerSetCoveredBase
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
	public partial class StickerSetMultiCovered : StickerSetCoveredBase
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
	public partial class MaskCoords : ITLObject
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
	public abstract partial class InputStickeredMedia : ITLObject { }
	/// <summary>A photo with stickers attached		<para>See <a href="https://corefork.telegram.org/constructor/inputStickeredMediaPhoto"/></para></summary>
	[TLDef(0x4A992157)]
	public partial class InputStickeredMediaPhoto : InputStickeredMedia
	{
		/// <summary>The photo</summary>
		public InputPhoto id;
	}
	/// <summary>A document with stickers attached		<para>See <a href="https://corefork.telegram.org/constructor/inputStickeredMediaDocument"/></para></summary>
	[TLDef(0x0438865B)]
	public partial class InputStickeredMediaDocument : InputStickeredMedia
	{
		/// <summary>The document</summary>
		public InputDocument id;
	}

	/// <summary>Indicates an already sent game		<para>See <a href="https://corefork.telegram.org/constructor/game"/></para></summary>
	[TLDef(0xBDF9653B)]
	public partial class Game : ITLObject
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="document"/> has a value</summary>
			has_document = 0x1,
		}
	}

	/// <summary>A game to send		<para>Derived classes: <see cref="InputGameID"/>, <see cref="InputGameShortName"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputGame"/></para></summary>
	public abstract partial class InputGame : ITLObject { }
	/// <summary>Indicates an already sent game		<para>See <a href="https://corefork.telegram.org/constructor/inputGameID"/></para></summary>
	[TLDef(0x032C3E77)]
	public partial class InputGameID : InputGame
	{
		/// <summary>game ID from <see cref="Game"/> constructor</summary>
		public long id;
		/// <summary>access hash from <see cref="Game"/> constructor</summary>
		public long access_hash;
	}
	/// <summary>Game by short name		<para>See <a href="https://corefork.telegram.org/constructor/inputGameShortName"/></para></summary>
	[TLDef(0xC331E80A)]
	public partial class InputGameShortName : InputGame
	{
		/// <summary>The bot that provides the game</summary>
		public InputUserBase bot_id;
		/// <summary>The game's short name</summary>
		public string short_name;
	}

	/// <summary>Game highscore		<para>See <a href="https://corefork.telegram.org/constructor/highScore"/></para></summary>
	[TLDef(0x73A379EB)]
	public partial class HighScore : ITLObject
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
	public partial class Messages_HighScores : ITLObject
	{
		/// <summary>Highscores</summary>
		public HighScore[] scores;
		/// <summary>Users, associated to the highscores</summary>
		public Dictionary<long, UserBase> users;
	}

	/// <summary>Rich text		<para>Derived classes: <see cref="TextPlain"/>, <see cref="TextBold"/>, <see cref="TextItalic"/>, <see cref="TextUnderline"/>, <see cref="TextStrike"/>, <see cref="TextFixed"/>, <see cref="TextUrl"/>, <see cref="TextEmail"/>, <see cref="TextConcat"/>, <see cref="TextSubscript"/>, <see cref="TextSuperscript"/>, <see cref="TextMarked"/>, <see cref="TextPhone"/>, <see cref="TextImage"/>, <see cref="TextAnchor"/></para>		<para>See <a href="https://corefork.telegram.org/type/RichText"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/textEmpty">textEmpty</a></remarks>
	public abstract partial class RichText : ITLObject { }
	/// <summary>Plain text		<para>See <a href="https://corefork.telegram.org/constructor/textPlain"/></para></summary>
	[TLDef(0x744694E0)]
	public partial class TextPlain : RichText
	{
		/// <summary>Text</summary>
		public string text;
	}
	/// <summary><strong>Bold</strong> text		<para>See <a href="https://corefork.telegram.org/constructor/textBold"/></para></summary>
	[TLDef(0x6724ABC4)]
	public partial class TextBold : RichText
	{
		/// <summary>Text</summary>
		public RichText text;
	}
	/// <summary><em>Italic</em> text		<para>See <a href="https://corefork.telegram.org/constructor/textItalic"/></para></summary>
	[TLDef(0xD912A59C)]
	public partial class TextItalic : RichText
	{
		/// <summary>Text</summary>
		public RichText text;
	}
	/// <summary>Underlined text		<para>See <a href="https://corefork.telegram.org/constructor/textUnderline"/></para></summary>
	[TLDef(0xC12622C4)]
	public partial class TextUnderline : RichText
	{
		/// <summary>Text</summary>
		public RichText text;
	}
	/// <summary><del>Strikethrough</del> text		<para>See <a href="https://corefork.telegram.org/constructor/textStrike"/></para></summary>
	[TLDef(0x9BF8BB95)]
	public partial class TextStrike : RichText
	{
		/// <summary>Text</summary>
		public RichText text;
	}
	/// <summary><c>fixed-width</c> rich text		<para>See <a href="https://corefork.telegram.org/constructor/textFixed"/></para></summary>
	[TLDef(0x6C3F19B9)]
	public partial class TextFixed : RichText
	{
		/// <summary>Text</summary>
		public RichText text;
	}
	/// <summary>Link		<para>See <a href="https://corefork.telegram.org/constructor/textUrl"/></para></summary>
	[TLDef(0x3C2884C1)]
	public partial class TextUrl : RichText
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
	public partial class TextEmail : RichText
	{
		/// <summary>Link text</summary>
		public RichText text;
		/// <summary>Email address</summary>
		public string email;
	}
	/// <summary>Concatenation of rich texts		<para>See <a href="https://corefork.telegram.org/constructor/textConcat"/></para></summary>
	[TLDef(0x7E6260D7)]
	public partial class TextConcat : RichText
	{
		/// <summary>Concatenated rich texts</summary>
		public RichText[] texts;
	}
	/// <summary>Subscript text		<para>See <a href="https://corefork.telegram.org/constructor/textSubscript"/></para></summary>
	[TLDef(0xED6A8504)]
	public partial class TextSubscript : RichText
	{
		/// <summary>Text</summary>
		public RichText text;
	}
	/// <summary>Superscript text		<para>See <a href="https://corefork.telegram.org/constructor/textSuperscript"/></para></summary>
	[TLDef(0xC7FB5E01)]
	public partial class TextSuperscript : RichText
	{
		/// <summary>Text</summary>
		public RichText text;
	}
	/// <summary>Highlighted text		<para>See <a href="https://corefork.telegram.org/constructor/textMarked"/></para></summary>
	[TLDef(0x034B8621)]
	public partial class TextMarked : RichText
	{
		/// <summary>Text</summary>
		public RichText text;
	}
	/// <summary>Rich text linked to a phone number		<para>See <a href="https://corefork.telegram.org/constructor/textPhone"/></para></summary>
	[TLDef(0x1CCB966A)]
	public partial class TextPhone : RichText
	{
		/// <summary>Text</summary>
		public RichText text;
		/// <summary>Phone number</summary>
		public string phone;
	}
	/// <summary>Inline image		<para>See <a href="https://corefork.telegram.org/constructor/textImage"/></para></summary>
	[TLDef(0x081CCF4F)]
	public partial class TextImage : RichText
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
	public partial class TextAnchor : RichText
	{
		/// <summary>Text</summary>
		public RichText text;
		/// <summary>Section name</summary>
		public string name;
	}

	/// <summary>Represents an <a href="https://instantview.telegram.org">instant view page element</a>		<para>Derived classes: <see cref="PageBlockUnsupported"/>, <see cref="PageBlockTitle"/>, <see cref="PageBlockSubtitle"/>, <see cref="PageBlockAuthorDate"/>, <see cref="PageBlockHeader"/>, <see cref="PageBlockSubheader"/>, <see cref="PageBlockParagraph"/>, <see cref="PageBlockPreformatted"/>, <see cref="PageBlockFooter"/>, <see cref="PageBlockDivider"/>, <see cref="PageBlockAnchor"/>, <see cref="PageBlockList"/>, <see cref="PageBlockBlockquote"/>, <see cref="PageBlockPullquote"/>, <see cref="PageBlockPhoto"/>, <see cref="PageBlockVideo"/>, <see cref="PageBlockCover"/>, <see cref="PageBlockEmbed"/>, <see cref="PageBlockEmbedPost"/>, <see cref="PageBlockCollage"/>, <see cref="PageBlockSlideshow"/>, <see cref="PageBlockChannel"/>, <see cref="PageBlockAudio"/>, <see cref="PageBlockKicker"/>, <see cref="PageBlockTable"/>, <see cref="PageBlockOrderedList"/>, <see cref="PageBlockDetails"/>, <see cref="PageBlockRelatedArticles"/>, <see cref="PageBlockMap"/></para>		<para>See <a href="https://corefork.telegram.org/type/PageBlock"/></para></summary>
	public abstract partial class PageBlock : ITLObject { }
	/// <summary>Unsupported IV element		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockUnsupported"/></para></summary>
	[TLDef(0x13567E8A)]
	public partial class PageBlockUnsupported : PageBlock { }
	/// <summary>Title		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockTitle"/></para></summary>
	[TLDef(0x70ABC3FD)]
	public partial class PageBlockTitle : PageBlock
	{
		/// <summary>Title</summary>
		public RichText text;
	}
	/// <summary>Subtitle		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockSubtitle"/></para></summary>
	[TLDef(0x8FFA9A1F)]
	public partial class PageBlockSubtitle : PageBlock
	{
		/// <summary>Text</summary>
		public RichText text;
	}
	/// <summary>Author and date of creation of article		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockAuthorDate"/></para></summary>
	[TLDef(0xBAAFE5E0)]
	public partial class PageBlockAuthorDate : PageBlock
	{
		/// <summary>Author name</summary>
		public RichText author;
		/// <summary>Date of pubblication</summary>
		public DateTime published_date;
	}
	/// <summary>Page header		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockHeader"/></para></summary>
	[TLDef(0xBFD064EC)]
	public partial class PageBlockHeader : PageBlock
	{
		/// <summary>Contents</summary>
		public RichText text;
	}
	/// <summary>Subheader		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockSubheader"/></para></summary>
	[TLDef(0xF12BB6E1)]
	public partial class PageBlockSubheader : PageBlock
	{
		/// <summary>Subheader</summary>
		public RichText text;
	}
	/// <summary>A paragraph		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockParagraph"/></para></summary>
	[TLDef(0x467A0766)]
	public partial class PageBlockParagraph : PageBlock
	{
		/// <summary>Text</summary>
		public RichText text;
	}
	/// <summary>Preformatted (<c>&lt;pre&gt;</c> text)		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockPreformatted"/></para></summary>
	[TLDef(0xC070D93E)]
	public partial class PageBlockPreformatted : PageBlock
	{
		/// <summary>Text</summary>
		public RichText text;
		/// <summary>Programming language of preformatted text</summary>
		public string language;
	}
	/// <summary>Page footer		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockFooter"/></para></summary>
	[TLDef(0x48870999)]
	public partial class PageBlockFooter : PageBlock
	{
		/// <summary>Contents</summary>
		public RichText text;
	}
	/// <summary>An empty block separating a page		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockDivider"/></para></summary>
	[TLDef(0xDB20B188)]
	public partial class PageBlockDivider : PageBlock { }
	/// <summary>Link to section within the page itself (like <c>&lt;a href="#target"&gt;anchor&lt;/a&gt;</c>)		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockAnchor"/></para></summary>
	[TLDef(0xCE0D37B0)]
	public partial class PageBlockAnchor : PageBlock
	{
		/// <summary>Name of target section</summary>
		public string name;
	}
	/// <summary>Unordered list of IV blocks		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockList"/></para></summary>
	[TLDef(0xE4E88011)]
	public partial class PageBlockList : PageBlock
	{
		/// <summary>List of blocks in an IV page</summary>
		public PageListItem[] items;
	}
	/// <summary>Quote (equivalent to the HTML <c>&lt;blockquote&gt;</c>)		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockBlockquote"/></para></summary>
	[TLDef(0x263D7C26)]
	public partial class PageBlockBlockquote : PageBlock
	{
		/// <summary>Quote contents</summary>
		public RichText text;
		/// <summary>Caption</summary>
		public RichText caption;
	}
	/// <summary>Pullquote		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockPullquote"/></para></summary>
	[TLDef(0x4F4456D3)]
	public partial class PageBlockPullquote : PageBlock
	{
		/// <summary>Text</summary>
		public RichText text;
		/// <summary>Caption</summary>
		public RichText caption;
	}
	/// <summary>A photo		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockPhoto"/></para></summary>
	[TLDef(0x1759C560)]
	public partial class PageBlockPhoto : PageBlock
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="url"/> has a value</summary>
			has_url = 0x1,
		}
	}
	/// <summary>Video		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockVideo"/></para></summary>
	[TLDef(0x7C8FE7B6)]
	public partial class PageBlockVideo : PageBlock
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Video ID</summary>
		public long video_id;
		/// <summary>Caption</summary>
		public PageCaption caption;

		[Flags] public enum Flags
		{
			/// <summary>Whether the video is set to autoplay</summary>
			autoplay = 0x1,
			/// <summary>Whether the video is set to loop</summary>
			loop = 0x2,
		}
	}
	/// <summary>A page cover		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockCover"/></para></summary>
	[TLDef(0x39F23300)]
	public partial class PageBlockCover : PageBlock
	{
		/// <summary>Cover</summary>
		public PageBlock cover;
	}
	/// <summary>An embedded webpage		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockEmbed"/></para></summary>
	[TLDef(0xA8718DC5)]
	public partial class PageBlockEmbed : PageBlock
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

		[Flags] public enum Flags
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
	public partial class PageBlockEmbedPost : PageBlock
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
	public partial class PageBlockCollage : PageBlock
	{
		/// <summary>Media elements</summary>
		public PageBlock[] items;
		/// <summary>Caption</summary>
		public PageCaption caption;
	}
	/// <summary>Slideshow		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockSlideshow"/></para></summary>
	[TLDef(0x031F9590)]
	public partial class PageBlockSlideshow : PageBlock
	{
		/// <summary>Slideshow items</summary>
		public PageBlock[] items;
		/// <summary>Caption</summary>
		public PageCaption caption;
	}
	/// <summary>Reference to a telegram channel		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockChannel"/></para></summary>
	[TLDef(0xEF1751B5)]
	public partial class PageBlockChannel : PageBlock
	{
		/// <summary>The channel/supergroup/chat</summary>
		public ChatBase channel;
	}
	/// <summary>Audio		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockAudio"/></para></summary>
	[TLDef(0x804361EA)]
	public partial class PageBlockAudio : PageBlock
	{
		/// <summary>Audio ID (to be fetched from the container <see cref="Page"/> constructor</summary>
		public long audio_id;
		/// <summary>Audio caption</summary>
		public PageCaption caption;
	}
	/// <summary>Kicker		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockKicker"/></para></summary>
	[TLDef(0x1E148390)]
	public partial class PageBlockKicker : PageBlock
	{
		/// <summary>Contents</summary>
		public RichText text;
	}
	/// <summary>Table		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockTable"/></para></summary>
	[TLDef(0xBF4DEA82)]
	public partial class PageBlockTable : PageBlock
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Title</summary>
		public RichText title;
		/// <summary>Table rows</summary>
		public PageTableRow[] rows;

		[Flags] public enum Flags
		{
			/// <summary>Does the table have a visible border?</summary>
			bordered = 0x1,
			/// <summary>Is the table striped?</summary>
			striped = 0x2,
		}
	}
	/// <summary>Ordered list of IV blocks		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockOrderedList"/></para></summary>
	[TLDef(0x9A8AE1E1)]
	public partial class PageBlockOrderedList : PageBlock
	{
		/// <summary>List items</summary>
		public PageListOrderedItem[] items;
	}
	/// <summary>A collapsible details block		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockDetails"/></para></summary>
	[TLDef(0x76768BED)]
	public partial class PageBlockDetails : PageBlock
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Block contents</summary>
		public PageBlock[] blocks;
		/// <summary>Always visible heading for the block</summary>
		public RichText title;

		[Flags] public enum Flags
		{
			/// <summary>Whether the block is open by default</summary>
			open = 0x1,
		}
	}
	/// <summary>Related articles		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockRelatedArticles"/></para></summary>
	[TLDef(0x16115A96)]
	public partial class PageBlockRelatedArticles : PageBlock
	{
		/// <summary>Title</summary>
		public RichText title;
		/// <summary>Related articles</summary>
		public PageRelatedArticle[] articles;
	}
	/// <summary>A map		<para>See <a href="https://corefork.telegram.org/constructor/pageBlockMap"/></para></summary>
	[TLDef(0xA44F3EF6)]
	public partial class PageBlockMap : PageBlock
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
		///<summary>The phone call was discared because the user is busy in another call</summary>
		Busy = 0xFAF7E8C9,
	}

	/// <summary>Represents a json-encoded object		<para>See <a href="https://corefork.telegram.org/constructor/dataJSON"/></para></summary>
	[TLDef(0x7D748D04)]
	public partial class DataJSON : ITLObject
	{
		/// <summary>JSON-encoded object</summary>
		public string data;
	}

	/// <summary>This object represents a portion of the price for goods or services.		<para>See <a href="https://corefork.telegram.org/constructor/labeledPrice"/></para></summary>
	[TLDef(0xCB296BF8)]
	public partial class LabeledPrice : ITLObject
	{
		/// <summary>Portion label</summary>
		public string label;
		/// <summary>Price of the product in the smallest units of the currency (integer, not float/double). For example, for a price of <c>US$ 1.45</c> pass <c>amount = 145</c>. See the exp parameter in <a href="https://corefork.telegram.org/bots/payments/currencies.json">currencies.json</a>, it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).</summary>
		public long amount;
	}

	/// <summary>Invoice		<para>See <a href="https://corefork.telegram.org/constructor/invoice"/></para></summary>
	[TLDef(0x0CD886E0)]
	public partial class Invoice : ITLObject
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

		[Flags] public enum Flags
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
	public partial class PaymentCharge : ITLObject
	{
		/// <summary>Telegram payment identifier</summary>
		public string id;
		/// <summary>Provider payment identifier</summary>
		public string provider_charge_id;
	}

	/// <summary>Shipping address		<para>See <a href="https://corefork.telegram.org/constructor/postAddress"/></para></summary>
	[TLDef(0x1E8CAAEB)]
	public partial class PostAddress : ITLObject
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
	public partial class PaymentRequestedInfo : ITLObject
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

		[Flags] public enum Flags
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
	public abstract partial class PaymentSavedCredentials : ITLObject { }
	/// <summary>Saved credit card		<para>See <a href="https://corefork.telegram.org/constructor/paymentSavedCredentialsCard"/></para></summary>
	[TLDef(0xCDC27A1F)]
	public partial class PaymentSavedCredentialsCard : PaymentSavedCredentials
	{
		/// <summary>Card ID</summary>
		public string id;
		/// <summary>Title</summary>
		public string title;
	}

	/// <summary>Remote document		<para>Derived classes: <see cref="WebDocument"/>, <see cref="WebDocumentNoProxy"/></para>		<para>See <a href="https://corefork.telegram.org/type/WebDocument"/></para></summary>
	public abstract partial class WebDocumentBase : ITLObject
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
	public partial class WebDocumentNoProxy : WebDocumentBase
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
	public partial class InputWebDocument : ITLObject
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
	public abstract partial class InputWebFileLocationBase : ITLObject
	{
		/// <summary>Access hash</summary>
		public abstract long AccessHash { get; }
	}
	/// <summary>Location of a remote HTTP(s) file		<para>See <a href="https://corefork.telegram.org/constructor/inputWebFileLocation"/></para></summary>
	[TLDef(0xC239D686)]
	public partial class InputWebFileLocation : InputWebFileLocationBase
	{
		/// <summary>HTTP URL of file</summary>
		public string url;
		/// <summary>Access hash</summary>
		public long access_hash;

		/// <summary>Access hash</summary>
		public override long AccessHash => access_hash;
	}
	/// <summary>Geolocation		<para>See <a href="https://corefork.telegram.org/constructor/inputWebFileGeoPointLocation"/></para></summary>
	[TLDef(0x9F2221C9)]
	public partial class InputWebFileGeoPointLocation : InputWebFileLocationBase
	{
		/// <summary>Geolocation</summary>
		public InputGeoPoint geo_point;
		/// <summary>Access hash</summary>
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
	public partial class Upload_WebFile : ITLObject
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
	public partial class Payments_PaymentForm : ITLObject
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
		public Dictionary<long, UserBase> users;

		[Flags] public enum Flags
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

	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/payments.validatedRequestedInfo"/></para></summary>
	[TLDef(0xD1451883)]
	public partial class Payments_ValidatedRequestedInfo : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>ID</summary>
		[IfFlag(0)] public string id;
		/// <summary>Shipping options</summary>
		[IfFlag(1)] public ShippingOption[] shipping_options;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="id"/> has a value</summary>
			has_id = 0x1,
			/// <summary>Field <see cref="shipping_options"/> has a value</summary>
			has_shipping_options = 0x2,
		}
	}

	/// <summary><para>Derived classes: <see cref="Payments_PaymentResult"/>, <see cref="Payments_PaymentVerificationNeeded"/></para>		<para>See <a href="https://corefork.telegram.org/type/payments.PaymentResult"/></para></summary>
	public abstract partial class Payments_PaymentResultBase : ITLObject { }
	/// <summary>Payment result		<para>See <a href="https://corefork.telegram.org/constructor/payments.paymentResult"/></para></summary>
	[TLDef(0x4E5F810D)]
	public partial class Payments_PaymentResult : Payments_PaymentResultBase
	{
		/// <summary>Info about the payment</summary>
		public UpdatesBase updates;
	}
	/// <summary>Payment was not successful, additional verification is needed		<para>See <a href="https://corefork.telegram.org/constructor/payments.paymentVerificationNeeded"/></para></summary>
	[TLDef(0xD8411139)]
	public partial class Payments_PaymentVerificationNeeded : Payments_PaymentResultBase
	{
		/// <summary>URL for additional payment credentials verification</summary>
		public string url;
	}

	/// <summary>Receipt		<para>See <a href="https://corefork.telegram.org/constructor/payments.paymentReceipt"/></para></summary>
	[TLDef(0x70C4FE03)]
	public partial class Payments_PaymentReceipt : ITLObject
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
		public Dictionary<long, UserBase> users;

		[Flags] public enum Flags
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
	public partial class Payments_SavedInfo : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Saved server-side order information</summary>
		[IfFlag(0)] public PaymentRequestedInfo saved_info;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="saved_info"/> has a value</summary>
			has_saved_info = 0x1,
			/// <summary>Whether the user has some saved payment credentials</summary>
			has_saved_credentials = 0x2,
		}
	}

	/// <summary>Payment credentials		<para>Derived classes: <see cref="InputPaymentCredentialsSaved"/>, <see cref="InputPaymentCredentials"/>, <see cref="InputPaymentCredentialsApplePay"/>, <see cref="InputPaymentCredentialsGooglePay"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputPaymentCredentials"/></para></summary>
	public abstract partial class InputPaymentCredentialsBase : ITLObject { }
	/// <summary>Saved payment credentials		<para>See <a href="https://corefork.telegram.org/constructor/inputPaymentCredentialsSaved"/></para></summary>
	[TLDef(0xC10EB2CF)]
	public partial class InputPaymentCredentialsSaved : InputPaymentCredentialsBase
	{
		/// <summary>Credential ID</summary>
		public string id;
		/// <summary>Temporary password</summary>
		public byte[] tmp_password;
	}
	/// <summary>Payment credentials		<para>See <a href="https://corefork.telegram.org/constructor/inputPaymentCredentials"/></para></summary>
	[TLDef(0x3417D728)]
	public partial class InputPaymentCredentials : InputPaymentCredentialsBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Payment credentials</summary>
		public DataJSON data;

		[Flags] public enum Flags
		{
			/// <summary>Save payment credential for future use</summary>
			save = 0x1,
		}
	}
	/// <summary>Apple pay payment credentials		<para>See <a href="https://corefork.telegram.org/constructor/inputPaymentCredentialsApplePay"/></para></summary>
	[TLDef(0x0AA1C39F)]
	public partial class InputPaymentCredentialsApplePay : InputPaymentCredentialsBase
	{
		/// <summary>Payment data</summary>
		public DataJSON payment_data;
	}
	/// <summary>Google Pay payment credentials		<para>See <a href="https://corefork.telegram.org/constructor/inputPaymentCredentialsGooglePay"/></para></summary>
	[TLDef(0x8AC32801)]
	public partial class InputPaymentCredentialsGooglePay : InputPaymentCredentialsBase
	{
		/// <summary>Payment token</summary>
		public DataJSON payment_token;
	}

	/// <summary>Temporary payment password		<para>See <a href="https://corefork.telegram.org/constructor/account.tmpPassword"/></para></summary>
	[TLDef(0xDB64FD34)]
	public partial class Account_TmpPassword : ITLObject
	{
		/// <summary>Temporary password</summary>
		public byte[] tmp_password;
		/// <summary>Validity period</summary>
		public DateTime valid_until;
	}

	/// <summary>Shipping option		<para>See <a href="https://corefork.telegram.org/constructor/shippingOption"/></para></summary>
	[TLDef(0xB6213CDF)]
	public partial class ShippingOption : ITLObject
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
	public partial class InputStickerSetItem : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The sticker</summary>
		public InputDocument document;
		/// <summary>Associated emoji</summary>
		public string emoji;
		/// <summary>Coordinates for mask sticker</summary>
		[IfFlag(0)] public MaskCoords mask_coords;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="mask_coords"/> has a value</summary>
			has_mask_coords = 0x1,
		}
	}

	/// <summary>Phone call		<para>See <a href="https://corefork.telegram.org/constructor/inputPhoneCall"/></para></summary>
	[TLDef(0x1E36FDED)]
	public partial class InputPhoneCall : ITLObject
	{
		/// <summary>Call ID</summary>
		public long id;
		/// <summary>Access hash</summary>
		public long access_hash;
	}

	/// <summary>Phone call		<para>Derived classes: <see cref="PhoneCallEmpty"/>, <see cref="PhoneCallWaiting"/>, <see cref="PhoneCallRequested"/>, <see cref="PhoneCallAccepted"/>, <see cref="PhoneCall"/>, <see cref="PhoneCallDiscarded"/></para>		<para>See <a href="https://corefork.telegram.org/type/PhoneCall"/></para></summary>
	public abstract partial class PhoneCallBase : ITLObject
	{
		/// <summary>Call ID</summary>
		public abstract long ID { get; }
	}
	/// <summary>Empty constructor		<para>See <a href="https://corefork.telegram.org/constructor/phoneCallEmpty"/></para></summary>
	[TLDef(0x5366C915)]
	public partial class PhoneCallEmpty : PhoneCallBase
	{
		/// <summary>Call ID</summary>
		public long id;

		/// <summary>Call ID</summary>
		public override long ID => id;
	}
	/// <summary>Incoming phone call		<para>See <a href="https://corefork.telegram.org/constructor/phoneCallWaiting"/></para></summary>
	[TLDef(0xC5226F17)]
	public partial class PhoneCallWaiting : PhoneCallBase
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

		[Flags] public enum Flags
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
	public partial class PhoneCallRequested : PhoneCallBase
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

		[Flags] public enum Flags
		{
			/// <summary>Whether this is a video call</summary>
			video = 0x40,
		}

		/// <summary>Phone call ID</summary>
		public override long ID => id;
	}
	/// <summary>An accepted phone call		<para>See <a href="https://corefork.telegram.org/constructor/phoneCallAccepted"/></para></summary>
	[TLDef(0x3660C311)]
	public partial class PhoneCallAccepted : PhoneCallBase
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

		[Flags] public enum Flags
		{
			/// <summary>Whether this is a video call</summary>
			video = 0x40,
		}

		/// <summary>ID of accepted phone call</summary>
		public override long ID => id;
	}
	/// <summary>Phone call		<para>See <a href="https://corefork.telegram.org/constructor/phoneCall"/></para></summary>
	[TLDef(0x967F7C67)]
	public partial class PhoneCall : PhoneCallBase
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

		[Flags] public enum Flags
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
	public partial class PhoneCallDiscarded : PhoneCallBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Call ID</summary>
		public long id;
		/// <summary>Why was the phone call discarded</summary>
		[IfFlag(0)] public PhoneCallDiscardReason reason;
		/// <summary>Duration of the phone call in seconds</summary>
		[IfFlag(1)] public int duration;

		[Flags] public enum Flags
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
	public abstract partial class PhoneConnectionBase : ITLObject
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
	[TLDef(0x9D4C17C0)]
	public partial class PhoneConnection : PhoneConnectionBase
	{
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
	public partial class PhoneConnectionWebrtc : PhoneConnectionBase
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

		[Flags] public enum Flags
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
	public partial class PhoneCallProtocol : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Minimum layer for remote libtgvoip</summary>
		public int min_layer;
		/// <summary>Maximum layer for remote libtgvoip</summary>
		public int max_layer;
		/// <summary>When using <a href="https://corefork.telegram.org/method/phone.requestCall">phone.requestCall</a> and <a href="https://corefork.telegram.org/method/phone.acceptCall">phone.acceptCall</a>, specify all library versions supported by the client. <br/>The server will merge and choose the best library version supported by both peers, returning only the best value in the result of the callee's <a href="https://corefork.telegram.org/method/phone.acceptCall">phone.acceptCall</a> and in the <see cref="PhoneCallAccepted"/> update received by the caller.</summary>
		public string[] library_versions;

		[Flags] public enum Flags
		{
			/// <summary>Whether to allow P2P connection to the other participant</summary>
			udp_p2p = 0x1,
			/// <summary>Whether to allow connection to the other participants through the reflector servers</summary>
			udp_reflector = 0x2,
		}
	}

	/// <summary>A VoIP phone call		<para>See <a href="https://corefork.telegram.org/constructor/phone.phoneCall"/></para></summary>
	[TLDef(0xEC82E140)]
	public partial class Phone_PhoneCall : ITLObject
	{
		/// <summary>The VoIP phone call</summary>
		public PhoneCallBase phone_call;
		/// <summary>VoIP phone call participants</summary>
		public Dictionary<long, UserBase> users;
	}

	/// <summary>Represents the download status of a CDN file		<para>Derived classes: <see cref="Upload_CdnFileReuploadNeeded"/>, <see cref="Upload_CdnFile"/></para>		<para>See <a href="https://corefork.telegram.org/type/upload.CdnFile"/></para></summary>
	public abstract partial class Upload_CdnFileBase : ITLObject { }
	/// <summary>The file was cleared from the temporary RAM cache of the <a href="https://corefork.telegram.org/cdn">CDN</a> and has to be reuploaded.		<para>See <a href="https://corefork.telegram.org/constructor/upload.cdnFileReuploadNeeded"/></para></summary>
	[TLDef(0xEEA8E46E)]
	public partial class Upload_CdnFileReuploadNeeded : Upload_CdnFileBase
	{
		/// <summary>Request token (see <a href="https://corefork.telegram.org/cdn">CDN</a>)</summary>
		public byte[] request_token;
	}
	/// <summary>Represent a chunk of a <a href="https://corefork.telegram.org/cdn">CDN</a> file.		<para>See <a href="https://corefork.telegram.org/constructor/upload.cdnFile"/></para></summary>
	[TLDef(0xA99FCA4F)]
	public partial class Upload_CdnFile : Upload_CdnFileBase
	{
		/// <summary>The data</summary>
		public byte[] bytes;
	}

	/// <summary>Public key to use <strong>only</strong> during handshakes to <a href="https://corefork.telegram.org/cdn">CDN</a> DCs.		<para>See <a href="https://corefork.telegram.org/constructor/cdnPublicKey"/></para></summary>
	[TLDef(0xC982EABA)]
	public partial class CdnPublicKey : ITLObject
	{
		/// <summary><a href="https://corefork.telegram.org/cdn">CDN DC</a> ID</summary>
		public int dc_id;
		/// <summary>RSA public key</summary>
		public string public_key;
	}

	/// <summary>Configuration for <a href="https://corefork.telegram.org/cdn">CDN</a> file downloads.		<para>See <a href="https://corefork.telegram.org/constructor/cdnConfig"/></para></summary>
	[TLDef(0x5725E40A)]
	public partial class CdnConfig : ITLObject
	{
		/// <summary>Vector of public keys to use <strong>only</strong> during handshakes to <a href="https://corefork.telegram.org/cdn">CDN</a> DCs.</summary>
		public CdnPublicKey[] public_keys;
	}

	/// <summary>Language pack string		<para>Derived classes: <see cref="LangPackString"/>, <see cref="LangPackStringPluralized"/>, <see cref="LangPackStringDeleted"/></para>		<para>See <a href="https://corefork.telegram.org/type/LangPackString"/></para></summary>
	public abstract partial class LangPackStringBase : ITLObject
	{
		/// <summary>Language key</summary>
		public abstract string Key { get; }
	}
	/// <summary>Translated localization string		<para>See <a href="https://corefork.telegram.org/constructor/langPackString"/></para></summary>
	[TLDef(0xCAD181F6)]
	public partial class LangPackString : LangPackStringBase
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
	public partial class LangPackStringPluralized : LangPackStringBase
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

		[Flags] public enum Flags
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
	public partial class LangPackStringDeleted : LangPackStringBase
	{
		/// <summary>Localization key</summary>
		public string key;

		/// <summary>Localization key</summary>
		public override string Key => key;
	}

	/// <summary>Changes to the app's localization pack		<para>See <a href="https://corefork.telegram.org/constructor/langPackDifference"/></para></summary>
	[TLDef(0xF385C1F6)]
	public partial class LangPackDifference : ITLObject
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
	public partial class LangPackLanguage : ITLObject
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

		[Flags] public enum Flags
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

	/// <summary>Channel admin log event		<para>Derived classes: <see cref="ChannelAdminLogEventActionChangeTitle"/>, <see cref="ChannelAdminLogEventActionChangeAbout"/>, <see cref="ChannelAdminLogEventActionChangeUsername"/>, <see cref="ChannelAdminLogEventActionChangePhoto"/>, <see cref="ChannelAdminLogEventActionToggleInvites"/>, <see cref="ChannelAdminLogEventActionToggleSignatures"/>, <see cref="ChannelAdminLogEventActionUpdatePinned"/>, <see cref="ChannelAdminLogEventActionEditMessage"/>, <see cref="ChannelAdminLogEventActionDeleteMessage"/>, <see cref="ChannelAdminLogEventActionParticipantJoin"/>, <see cref="ChannelAdminLogEventActionParticipantLeave"/>, <see cref="ChannelAdminLogEventActionParticipantInvite"/>, <see cref="ChannelAdminLogEventActionParticipantToggleBan"/>, <see cref="ChannelAdminLogEventActionParticipantToggleAdmin"/>, <see cref="ChannelAdminLogEventActionChangeStickerSet"/>, <see cref="ChannelAdminLogEventActionTogglePreHistoryHidden"/>, <see cref="ChannelAdminLogEventActionDefaultBannedRights"/>, <see cref="ChannelAdminLogEventActionStopPoll"/>, <see cref="ChannelAdminLogEventActionChangeLinkedChat"/>, <see cref="ChannelAdminLogEventActionChangeLocation"/>, <see cref="ChannelAdminLogEventActionToggleSlowMode"/>, <see cref="ChannelAdminLogEventActionStartGroupCall"/>, <see cref="ChannelAdminLogEventActionDiscardGroupCall"/>, <see cref="ChannelAdminLogEventActionParticipantMute"/>, <see cref="ChannelAdminLogEventActionParticipantUnmute"/>, <see cref="ChannelAdminLogEventActionToggleGroupCallSetting"/>, <see cref="ChannelAdminLogEventActionParticipantJoinByInvite"/>, <see cref="ChannelAdminLogEventActionExportedInviteDelete"/>, <see cref="ChannelAdminLogEventActionExportedInviteRevoke"/>, <see cref="ChannelAdminLogEventActionExportedInviteEdit"/>, <see cref="ChannelAdminLogEventActionParticipantVolume"/>, <see cref="ChannelAdminLogEventActionChangeHistoryTTL"/></para>		<para>See <a href="https://corefork.telegram.org/type/ChannelAdminLogEventAction"/></para></summary>
	public abstract partial class ChannelAdminLogEventAction : ITLObject { }
	/// <summary>Channel/supergroup title was changed		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangeTitle"/></para></summary>
	[TLDef(0xE6DFB825)]
	public partial class ChannelAdminLogEventActionChangeTitle : ChannelAdminLogEventAction
	{
		/// <summary>Previous title</summary>
		public string prev_value;
		/// <summary>New title</summary>
		public string new_value;
	}
	/// <summary>The description was changed		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangeAbout"/></para></summary>
	[TLDef(0x55188A2E)]
	public partial class ChannelAdminLogEventActionChangeAbout : ChannelAdminLogEventAction
	{
		/// <summary>Previous description</summary>
		public string prev_value;
		/// <summary>New description</summary>
		public string new_value;
	}
	/// <summary>Channel/supergroup username was changed		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangeUsername"/></para></summary>
	[TLDef(0x6A4AFC38)]
	public partial class ChannelAdminLogEventActionChangeUsername : ChannelAdminLogEventAction
	{
		/// <summary>Old username</summary>
		public string prev_value;
		/// <summary>New username</summary>
		public string new_value;
	}
	/// <summary>The channel/supergroup's picture was changed		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangePhoto"/></para></summary>
	[TLDef(0x434BD2AF)]
	public partial class ChannelAdminLogEventActionChangePhoto : ChannelAdminLogEventAction
	{
		/// <summary>Previous picture</summary>
		public PhotoBase prev_photo;
		/// <summary>New picture</summary>
		public PhotoBase new_photo;
	}
	/// <summary>Invites were enabled/disabled		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionToggleInvites"/></para></summary>
	[TLDef(0x1B7907AE)]
	public partial class ChannelAdminLogEventActionToggleInvites : ChannelAdminLogEventAction
	{
		/// <summary>New value</summary>
		public bool new_value;
	}
	/// <summary>Channel signatures were enabled/disabled		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionToggleSignatures"/></para></summary>
	[TLDef(0x26AE0971)]
	public partial class ChannelAdminLogEventActionToggleSignatures : ChannelAdminLogEventAction
	{
		/// <summary>New value</summary>
		public bool new_value;
	}
	/// <summary>A message was pinned		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionUpdatePinned"/></para></summary>
	[TLDef(0xE9E82C18)]
	public partial class ChannelAdminLogEventActionUpdatePinned : ChannelAdminLogEventAction
	{
		/// <summary>The message that was pinned</summary>
		public MessageBase message;
	}
	/// <summary>A message was edited		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionEditMessage"/></para></summary>
	[TLDef(0x709B2405)]
	public partial class ChannelAdminLogEventActionEditMessage : ChannelAdminLogEventAction
	{
		/// <summary>Old message</summary>
		public MessageBase prev_message;
		/// <summary>New message</summary>
		public MessageBase new_message;
	}
	/// <summary>A message was deleted		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionDeleteMessage"/></para></summary>
	[TLDef(0x42E047BB)]
	public partial class ChannelAdminLogEventActionDeleteMessage : ChannelAdminLogEventAction
	{
		/// <summary>The message that was deleted</summary>
		public MessageBase message;
	}
	/// <summary>A user has joined the group (in the case of big groups, info of the user that has joined isn't shown)		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantJoin"/></para></summary>
	[TLDef(0x183040D3)]
	public partial class ChannelAdminLogEventActionParticipantJoin : ChannelAdminLogEventAction { }
	/// <summary>A user left the channel/supergroup (in the case of big groups, info of the user that has joined isn't shown)		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantLeave"/></para></summary>
	[TLDef(0xF89777F2)]
	public partial class ChannelAdminLogEventActionParticipantLeave : ChannelAdminLogEventAction { }
	/// <summary>A user was invited to the group		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantInvite"/></para></summary>
	[TLDef(0xE31C34D8)]
	public partial class ChannelAdminLogEventActionParticipantInvite : ChannelAdminLogEventAction
	{
		/// <summary>The user that was invited</summary>
		public ChannelParticipantBase participant;
	}
	/// <summary>The banned <a href="https://corefork.telegram.org/api/rights">rights</a> of a user were changed		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantToggleBan"/></para></summary>
	[TLDef(0xE6D83D7E)]
	public partial class ChannelAdminLogEventActionParticipantToggleBan : ChannelAdminLogEventAction
	{
		/// <summary>Old banned rights of user</summary>
		public ChannelParticipantBase prev_participant;
		/// <summary>New banned rights of user</summary>
		public ChannelParticipantBase new_participant;
	}
	/// <summary>The admin <a href="https://corefork.telegram.org/api/rights">rights</a> of a user were changed		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantToggleAdmin"/></para></summary>
	[TLDef(0xD5676710)]
	public partial class ChannelAdminLogEventActionParticipantToggleAdmin : ChannelAdminLogEventAction
	{
		/// <summary>Previous admin rights</summary>
		public ChannelParticipantBase prev_participant;
		/// <summary>New admin rights</summary>
		public ChannelParticipantBase new_participant;
	}
	/// <summary>The supergroup's stickerset was changed		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangeStickerSet"/></para></summary>
	[TLDef(0xB1C3CAA7)]
	public partial class ChannelAdminLogEventActionChangeStickerSet : ChannelAdminLogEventAction
	{
		/// <summary>Previous stickerset</summary>
		public InputStickerSet prev_stickerset;
		/// <summary>New stickerset</summary>
		public InputStickerSet new_stickerset;
	}
	/// <summary>The hidden prehistory setting was <a href="https://corefork.telegram.org/method/channels.togglePreHistoryHidden">changed</a>		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionTogglePreHistoryHidden"/></para></summary>
	[TLDef(0x5F5C95F1)]
	public partial class ChannelAdminLogEventActionTogglePreHistoryHidden : ChannelAdminLogEventAction
	{
		/// <summary>New value</summary>
		public bool new_value;
	}
	/// <summary>The default banned rights were modified		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionDefaultBannedRights"/></para></summary>
	[TLDef(0x2DF5FC0A)]
	public partial class ChannelAdminLogEventActionDefaultBannedRights : ChannelAdminLogEventAction
	{
		/// <summary>Previous global <a href="https://corefork.telegram.org/api/rights">banned rights</a></summary>
		public ChatBannedRights prev_banned_rights;
		/// <summary>New glboal <a href="https://corefork.telegram.org/api/rights">banned rights</a>.</summary>
		public ChatBannedRights new_banned_rights;
	}
	/// <summary>A poll was stopped		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionStopPoll"/></para></summary>
	[TLDef(0x8F079643)]
	public partial class ChannelAdminLogEventActionStopPoll : ChannelAdminLogEventAction
	{
		/// <summary>The poll that was stopped</summary>
		public MessageBase message;
	}
	/// <summary>The linked chat was changed		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangeLinkedChat"/></para></summary>
	[TLDef(0x050C7AC8)]
	public partial class ChannelAdminLogEventActionChangeLinkedChat : ChannelAdminLogEventAction
	{
		/// <summary>Previous linked chat</summary>
		public long prev_value;
		/// <summary>New linked chat</summary>
		public long new_value;
	}
	/// <summary>The geogroup location was changed		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangeLocation"/></para></summary>
	[TLDef(0x0E6B76AE)]
	public partial class ChannelAdminLogEventActionChangeLocation : ChannelAdminLogEventAction
	{
		/// <summary>Previous location</summary>
		public ChannelLocation prev_value;
		/// <summary>New location</summary>
		public ChannelLocation new_value;
	}
	/// <summary><a href="https://corefork.telegram.org/method/channels.toggleSlowMode">Slow mode setting for supergroups was changed</a>		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionToggleSlowMode"/></para></summary>
	[TLDef(0x53909779)]
	public partial class ChannelAdminLogEventActionToggleSlowMode : ChannelAdminLogEventAction
	{
		/// <summary>Previous slow mode value</summary>
		public int prev_value;
		/// <summary>New slow mode value</summary>
		public int new_value;
	}
	/// <summary>A group call was started		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionStartGroupCall"/></para></summary>
	[TLDef(0x23209745)]
	public partial class ChannelAdminLogEventActionStartGroupCall : ChannelAdminLogEventAction
	{
		/// <summary>Group call</summary>
		public InputGroupCall call;
	}
	/// <summary>A group call was terminated		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionDiscardGroupCall"/></para></summary>
	[TLDef(0xDB9F9140)]
	public partial class ChannelAdminLogEventActionDiscardGroupCall : ChannelAdminLogEventAction
	{
		/// <summary>The group call that was terminated</summary>
		public InputGroupCall call;
	}
	/// <summary>A group call participant was muted		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantMute"/></para></summary>
	[TLDef(0xF92424D2)]
	public partial class ChannelAdminLogEventActionParticipantMute : ChannelAdminLogEventAction
	{
		/// <summary>The participant that was muted</summary>
		public GroupCallParticipant participant;
	}
	/// <summary>A group call participant was unmuted		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantUnmute"/></para></summary>
	[TLDef(0xE64429C0)]
	public partial class ChannelAdminLogEventActionParticipantUnmute : ChannelAdminLogEventAction
	{
		/// <summary>The participant that was unmuted</summary>
		public GroupCallParticipant participant;
	}
	/// <summary>Group call settings were changed		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionToggleGroupCallSetting"/></para></summary>
	[TLDef(0x56D6A247)]
	public partial class ChannelAdminLogEventActionToggleGroupCallSetting : ChannelAdminLogEventAction
	{
		/// <summary>Whether all users are muted by default upon joining</summary>
		public bool join_muted;
	}
	/// <summary>A user joined the <a href="https://corefork.telegram.org/api/channel">supergroup/channel</a> using a specific invite link		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantJoinByInvite"/></para></summary>
	[TLDef(0x5CDADA77)]
	public partial class ChannelAdminLogEventActionParticipantJoinByInvite : ChannelAdminLogEventAction
	{
		/// <summary>The invite link used to join the <a href="https://corefork.telegram.org/api/channel">supergroup/channel</a></summary>
		public ExportedChatInvite invite;
	}
	/// <summary>A chat invite was deleted		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionExportedInviteDelete"/></para></summary>
	[TLDef(0x5A50FCA4)]
	public partial class ChannelAdminLogEventActionExportedInviteDelete : ChannelAdminLogEventAction
	{
		/// <summary>The deleted chat invite</summary>
		public ExportedChatInvite invite;
	}
	/// <summary>A specific invite link was revoked		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionExportedInviteRevoke"/></para></summary>
	[TLDef(0x410A134E)]
	public partial class ChannelAdminLogEventActionExportedInviteRevoke : ChannelAdminLogEventAction
	{
		/// <summary>The invite link that was revoked</summary>
		public ExportedChatInvite invite;
	}
	/// <summary>A chat invite was edited		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionExportedInviteEdit"/></para></summary>
	[TLDef(0xE90EBB59)]
	public partial class ChannelAdminLogEventActionExportedInviteEdit : ChannelAdminLogEventAction
	{
		/// <summary>Previous chat invite information</summary>
		public ExportedChatInvite prev_invite;
		/// <summary>New chat invite information</summary>
		public ExportedChatInvite new_invite;
	}
	/// <summary>channelAdminLogEvent.user_id has set the volume of participant.peer to participant.volume		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantVolume"/></para></summary>
	[TLDef(0x3E7F6847)]
	public partial class ChannelAdminLogEventActionParticipantVolume : ChannelAdminLogEventAction
	{
		/// <summary>The participant whose volume was changed</summary>
		public GroupCallParticipant participant;
	}
	/// <summary>The Time-To-Live of messages in this chat was changed		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangeHistoryTTL"/></para></summary>
	[TLDef(0x6E941A38)]
	public partial class ChannelAdminLogEventActionChangeHistoryTTL : ChannelAdminLogEventAction
	{
		/// <summary>Previous value</summary>
		public int prev_value;
		/// <summary>New value</summary>
		public int new_value;
	}
	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantJoinByRequest"/></para></summary>
	[TLDef(0xAFB6144A)]
	public partial class ChannelAdminLogEventActionParticipantJoinByRequest : ChannelAdminLogEventAction
	{
		public ExportedChatInvite invite;
		public long approved_by;
	}

	/// <summary>Admin log event		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEvent"/></para></summary>
	[TLDef(0x1FAD68CD)]
	public partial class ChannelAdminLogEvent : ITLObject
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
	public partial class Channels_AdminLogResults : ITLObject
	{
		/// <summary>Admin log events</summary>
		public ChannelAdminLogEvent[] events;
		/// <summary>Chats mentioned in events</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users mentioned in events</summary>
		public Dictionary<long, UserBase> users;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	/// <summary>Filter only certain admin log events		<para>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventsFilter"/></para></summary>
	[TLDef(0xEA107AE4)]
	public partial class ChannelAdminLogEventsFilter : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;

		[Flags] public enum Flags
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
		}
	}

	/// <summary>Popular contact		<para>See <a href="https://corefork.telegram.org/constructor/popularContact"/></para></summary>
	[TLDef(0x5CE14175)]
	public partial class PopularContact : ITLObject
	{
		/// <summary>Contact identifier</summary>
		public long client_id;
		/// <summary>How many people imported this contact</summary>
		public int importers;
	}

	/// <summary>Favorited stickers		<para>See <a href="https://corefork.telegram.org/constructor/messages.favedStickers"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.favedStickersNotModified">messages.favedStickersNotModified</a></remarks>
	[TLDef(0x2CB51097)]
	public partial class Messages_FavedStickers : ITLObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></summary>
		public long hash;
		/// <summary>Emojis associated to stickers</summary>
		public StickerPack[] packs;
		/// <summary>Favorited stickers</summary>
		public DocumentBase[] stickers;
	}

	/// <summary>Recent t.me urls		<para>Derived classes: <see cref="RecentMeUrlUnknown"/>, <see cref="RecentMeUrlUser"/>, <see cref="RecentMeUrlChat"/>, <see cref="RecentMeUrlChatInvite"/>, <see cref="RecentMeUrlStickerSet"/></para>		<para>See <a href="https://corefork.telegram.org/type/RecentMeUrl"/></para></summary>
	public abstract partial class RecentMeUrl : ITLObject
	{
		/// <summary>URL</summary>
		public string url;
	}
	/// <summary>Unknown t.me url		<para>See <a href="https://corefork.telegram.org/constructor/recentMeUrlUnknown"/></para></summary>
	[TLDef(0x46E1D13D)]
	public partial class RecentMeUrlUnknown : RecentMeUrl { }
	/// <summary>Recent t.me link to a user		<para>See <a href="https://corefork.telegram.org/constructor/recentMeUrlUser"/></para></summary>
	[TLDef(0xB92C09E2)]
	public partial class RecentMeUrlUser : RecentMeUrl
	{
		/// <summary>User ID</summary>
		public long user_id;
	}
	/// <summary>Recent t.me link to a chat		<para>See <a href="https://corefork.telegram.org/constructor/recentMeUrlChat"/></para></summary>
	[TLDef(0xB2DA71D2)]
	public partial class RecentMeUrlChat : RecentMeUrl
	{
		/// <summary>Chat ID</summary>
		public long chat_id;
	}
	/// <summary>Recent t.me invite link to a chat		<para>See <a href="https://corefork.telegram.org/constructor/recentMeUrlChatInvite"/></para></summary>
	[TLDef(0xEB49081D)]
	public partial class RecentMeUrlChatInvite : RecentMeUrl
	{
		/// <summary>Chat invitation</summary>
		public ChatInviteBase chat_invite;
	}
	/// <summary>Recent t.me stickerset installation URL		<para>See <a href="https://corefork.telegram.org/constructor/recentMeUrlStickerSet"/></para></summary>
	[TLDef(0xBC0A57DC)]
	public partial class RecentMeUrlStickerSet : RecentMeUrl
	{
		/// <summary>Stickerset</summary>
		public StickerSetCoveredBase set;
	}

	/// <summary>Recent t.me URLs		<para>See <a href="https://corefork.telegram.org/constructor/help.recentMeUrls"/></para></summary>
	[TLDef(0x0E0310D7)]
	public partial class Help_RecentMeUrls : ITLObject
	{
		/// <summary>URLs</summary>
		public RecentMeUrl[] urls;
		/// <summary>Chats</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users</summary>
		public Dictionary<long, UserBase> users;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	/// <summary>A single media in an <a href="https://corefork.telegram.org/api/files#albums-grouped-media">album or grouped media</a> sent with <a href="https://corefork.telegram.org/method/messages.sendMultiMedia">messages.sendMultiMedia</a>.		<para>See <a href="https://corefork.telegram.org/constructor/inputSingleMedia"/></para></summary>
	[TLDef(0x1CC6E91F)]
	public partial class InputSingleMedia : ITLObject
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="entities"/> has a value</summary>
			has_entities = 0x1,
		}
	}

	/// <summary>Represents a bot logged in using the <a href="https://corefork.telegram.org/widgets/login">Telegram login widget</a>		<para>See <a href="https://corefork.telegram.org/constructor/webAuthorization"/></para></summary>
	[TLDef(0xA6F8F452)]
	public partial class WebAuthorization : ITLObject
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
		public int date_created;
		/// <summary>When was the web session last active</summary>
		public int date_active;
		/// <summary>IP address</summary>
		public string ip;
		/// <summary>Region, determined from IP address</summary>
		public string region;
	}

	/// <summary>Web authorizations		<para>See <a href="https://corefork.telegram.org/constructor/account.webAuthorizations"/></para></summary>
	[TLDef(0xED56C9FC)]
	public partial class Account_WebAuthorizations : ITLObject
	{
		/// <summary>Web authorization list</summary>
		public WebAuthorization[] authorizations;
		/// <summary>Users</summary>
		public Dictionary<long, UserBase> users;
	}

	/// <summary>A message		<para>Derived classes: <see cref="InputMessageID"/>, <see cref="InputMessageReplyTo"/>, <see cref="InputMessagePinned"/>, <see cref="InputMessageCallbackQuery"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputMessage"/></para></summary>
	public abstract partial class InputMessage : ITLObject { }
	/// <summary>Message by ID		<para>See <a href="https://corefork.telegram.org/constructor/inputMessageID"/></para></summary>
	[TLDef(0xA676A322)]
	public partial class InputMessageID : InputMessage
	{
		/// <summary>Message ID</summary>
		public int id;
	}
	/// <summary>Message to which the specified message replies to		<para>See <a href="https://corefork.telegram.org/constructor/inputMessageReplyTo"/></para></summary>
	[TLDef(0xBAD88395)]
	public partial class InputMessageReplyTo : InputMessage
	{
		/// <summary>ID of the message that replies to the message we need</summary>
		public int id;
	}
	/// <summary>Pinned message		<para>See <a href="https://corefork.telegram.org/constructor/inputMessagePinned"/></para></summary>
	[TLDef(0x86872538)]
	public partial class InputMessagePinned : InputMessage { }
	/// <summary>Used by bots for fetching information about the message that originated a callback query		<para>See <a href="https://corefork.telegram.org/constructor/inputMessageCallbackQuery"/></para></summary>
	[TLDef(0xACFA1A7E)]
	public partial class InputMessageCallbackQuery : InputMessage
	{
		/// <summary>Message ID</summary>
		public int id;
		/// <summary>Callback query ID</summary>
		public long query_id;
	}

	/// <summary>Peer, or all peers in a certain folder		<para>Derived classes: <see cref="InputDialogPeer"/>, <see cref="InputDialogPeerFolder"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputDialogPeer"/></para></summary>
	public abstract partial class InputDialogPeerBase : ITLObject { }
	/// <summary>A peer		<para>See <a href="https://corefork.telegram.org/constructor/inputDialogPeer"/></para></summary>
	[TLDef(0xFCAAFEB7)]
	public partial class InputDialogPeer : InputDialogPeerBase
	{
		/// <summary>Peer</summary>
		public InputPeer peer;
	}
	/// <summary>All peers in a <a href="https://corefork.telegram.org/api/folders#peer-folders">peer folder</a>		<para>See <a href="https://corefork.telegram.org/constructor/inputDialogPeerFolder"/></para></summary>
	[TLDef(0x64600527)]
	public partial class InputDialogPeerFolder : InputDialogPeerBase
	{
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		public int folder_id;
	}

	/// <summary>Peer, or all peers in a folder		<para>Derived classes: <see cref="DialogPeer"/>, <see cref="DialogPeerFolder"/></para>		<para>See <a href="https://corefork.telegram.org/type/DialogPeer"/></para></summary>
	public abstract partial class DialogPeerBase : ITLObject { }
	/// <summary>Peer		<para>See <a href="https://corefork.telegram.org/constructor/dialogPeer"/></para></summary>
	[TLDef(0xE56DBF05)]
	public partial class DialogPeer : DialogPeerBase
	{
		/// <summary>Peer</summary>
		public Peer peer;
	}
	/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder</a>		<para>See <a href="https://corefork.telegram.org/constructor/dialogPeerFolder"/></para></summary>
	[TLDef(0x514519E2)]
	public partial class DialogPeerFolder : DialogPeerBase
	{
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		public int folder_id;
	}

	/// <summary>Found stickersets		<para>See <a href="https://corefork.telegram.org/constructor/messages.foundStickerSets"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.foundStickerSetsNotModified">messages.foundStickerSetsNotModified</a></remarks>
	[TLDef(0x8AF09DD2)]
	public partial class Messages_FoundStickerSets : ITLObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></summary>
		public long hash;
		/// <summary>Found stickersets</summary>
		public StickerSetCoveredBase[] sets;
	}

	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/fileHash"/></para></summary>
	[TLDef(0x6242C773)]
	public partial class FileHash : ITLObject
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
	public partial class InputClientProxy : ITLObject
	{
		/// <summary>Proxy address</summary>
		public string address;
		/// <summary>Proxy port</summary>
		public int port;
	}

	/// <summary><para>Derived classes: <see cref="Help_TermsOfServiceUpdateEmpty"/>, <see cref="Help_TermsOfServiceUpdate"/></para>		<para>See <a href="https://corefork.telegram.org/type/help.TermsOfServiceUpdate"/></para></summary>
	public abstract partial class Help_TermsOfServiceUpdateBase : ITLObject { }
	/// <summary>No changes were made to telegram's terms of service		<para>See <a href="https://corefork.telegram.org/constructor/help.termsOfServiceUpdateEmpty"/></para></summary>
	[TLDef(0xE3309F7F)]
	public partial class Help_TermsOfServiceUpdateEmpty : Help_TermsOfServiceUpdateBase
	{
		/// <summary>New TOS updates will have to be queried using <a href="https://corefork.telegram.org/method/help.getTermsOfServiceUpdate">help.getTermsOfServiceUpdate</a> in <c>expires</c> seconds</summary>
		public DateTime expires;
	}
	/// <summary>Info about an update of telegram's terms of service. If the terms of service are declined, then the <a href="https://corefork.telegram.org/method/account.deleteAccount">account.deleteAccount</a> method should be called with the reason "Decline ToS update"		<para>See <a href="https://corefork.telegram.org/constructor/help.termsOfServiceUpdate"/></para></summary>
	[TLDef(0x28ECF961)]
	public partial class Help_TermsOfServiceUpdate : Help_TermsOfServiceUpdateBase
	{
		/// <summary>New TOS updates will have to be queried using <a href="https://corefork.telegram.org/method/help.getTermsOfServiceUpdate">help.getTermsOfServiceUpdate</a> in <c>expires</c> seconds</summary>
		public DateTime expires;
		/// <summary>New terms of service</summary>
		public Help_TermsOfService terms_of_service;
	}

	/// <summary>Secure <a href="https://corefork.telegram.org/passport">passport</a> file, for more info <a href="https://corefork.telegram.org/passport/encryption#inputsecurefile">see the passport docs »</a>		<para>Derived classes: <see cref="InputSecureFileUploaded"/>, <see cref="InputSecureFile"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputSecureFile"/></para></summary>
	public abstract partial class InputSecureFileBase : ITLObject
	{
		/// <summary>Secure file ID</summary>
		public abstract long ID { get; }
	}
	/// <summary>Uploaded secure file, for more info <a href="https://corefork.telegram.org/passport/encryption#inputsecurefile">see the passport docs »</a>		<para>See <a href="https://corefork.telegram.org/constructor/inputSecureFileUploaded"/></para></summary>
	[TLDef(0x3334B0F0)]
	public partial class InputSecureFileUploaded : InputSecureFileBase
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
	/// <summary>Preuploaded <a href="https://corefork.telegram.org/passport">passport</a> file, for more info <a href="https://corefork.telegram.org/passport/encryption#inputsecurefile">see the passport docs »</a>		<para>See <a href="https://corefork.telegram.org/constructor/inputSecureFile"/></para></summary>
	[TLDef(0x5367E5BE)]
	public partial class InputSecureFile : InputSecureFileBase
	{
		/// <summary>Secure file ID</summary>
		public long id;
		/// <summary>Secure file access hash</summary>
		public long access_hash;

		/// <summary>Secure file ID</summary>
		public override long ID => id;
	}

	/// <summary>Secure <a href="https://corefork.telegram.org/passport">passport</a> file, for more info <a href="https://corefork.telegram.org/passport/encryption#inputsecurefile">see the passport docs »</a>		<para>See <a href="https://corefork.telegram.org/constructor/secureFile"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/secureFileEmpty">secureFileEmpty</a></remarks>
	[TLDef(0xE0277A62)]
	public partial class SecureFile : ITLObject
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
	public partial class SecureData : ITLObject
	{
		/// <summary>Data</summary>
		public byte[] data;
		/// <summary>Data hash</summary>
		public byte[] data_hash;
		/// <summary>Secret</summary>
		public byte[] secret;
	}

	/// <summary>Plaintext verified <a href="https://corefork.telegram.org/passport/encryption#secureplaindata">passport data</a>.		<para>Derived classes: <see cref="SecurePlainPhone"/>, <see cref="SecurePlainEmail"/></para>		<para>See <a href="https://corefork.telegram.org/type/SecurePlainData"/></para></summary>
	public abstract partial class SecurePlainData : ITLObject { }
	/// <summary>Phone number to use in <a href="https://corefork.telegram.org/passport">telegram passport</a>: <a href="https://corefork.telegram.org/passport/encryption#secureplaindata">it must be verified, first »</a>.		<para>See <a href="https://corefork.telegram.org/constructor/securePlainPhone"/></para></summary>
	[TLDef(0x7D6099DD)]
	public partial class SecurePlainPhone : SecurePlainData
	{
		/// <summary>Phone number</summary>
		public string phone;
	}
	/// <summary>Email address to use in <a href="https://corefork.telegram.org/passport">telegram passport</a>: <a href="https://corefork.telegram.org/passport/encryption#secureplaindata">it must be verified, first »</a>.		<para>See <a href="https://corefork.telegram.org/constructor/securePlainEmail"/></para></summary>
	[TLDef(0x21EC5A5F)]
	public partial class SecurePlainEmail : SecurePlainData
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
	public partial class SecureValue : ITLObject
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

		[Flags] public enum Flags
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
	public partial class InputSecureValue : ITLObject
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

		[Flags] public enum Flags
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
	public partial class SecureValueHash : ITLObject
	{
		/// <summary>Secure value type</summary>
		public SecureValueType type;
		/// <summary>Hash</summary>
		public byte[] hash;
	}

	/// <summary>Secure value error		<para>Derived classes: <see cref="SecureValueErrorData"/>, <see cref="SecureValueErrorFrontSide"/>, <see cref="SecureValueErrorReverseSide"/>, <see cref="SecureValueErrorSelfie"/>, <see cref="SecureValueErrorFile"/>, <see cref="SecureValueErrorFiles"/>, <see cref="SecureValueError"/>, <see cref="SecureValueErrorTranslationFile"/>, <see cref="SecureValueErrorTranslationFiles"/></para>		<para>See <a href="https://corefork.telegram.org/type/SecureValueError"/></para></summary>
	public abstract partial class SecureValueErrorBase : ITLObject
	{
		/// <summary>The section of the user's Telegram Passport which has the error, one of <see cref="SecureValueType.PersonalDetails"/>, <see cref="SecureValueType.Passport"/>, <see cref="SecureValueType.DriverLicense"/>, <see cref="SecureValueType.IdentityCard"/>, <see cref="SecureValueType.InternalPassport"/>, <see cref="SecureValueType.Address"/></summary>
		public abstract SecureValueType Type { get; }
		/// <summary>Error message</summary>
		public abstract string Text { get; }
	}
	/// <summary>Represents an issue in one of the data fields that was provided by the user. The error is considered resolved when the field's value changes.		<para>See <a href="https://corefork.telegram.org/constructor/secureValueErrorData"/></para></summary>
	[TLDef(0xE8A40BD9)]
	public partial class SecureValueErrorData : SecureValueErrorBase
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
	public partial class SecureValueErrorFrontSide : SecureValueErrorBase
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
	public partial class SecureValueErrorReverseSide : SecureValueErrorBase
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
	public partial class SecureValueErrorSelfie : SecureValueErrorBase
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
	public partial class SecureValueErrorFile : SecureValueErrorBase
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
	public partial class SecureValueErrorFiles : SecureValueErrorBase
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
	public partial class SecureValueError : SecureValueErrorBase
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
	public partial class SecureValueErrorTranslationFile : SecureValueErrorFile
	{
	}
	/// <summary>Represents an issue with the translated version of a document. The error is considered resolved when a file with the document translation changes.		<para>See <a href="https://corefork.telegram.org/constructor/secureValueErrorTranslationFiles"/></para></summary>
	[TLDef(0x34636DD8)]
	public partial class SecureValueErrorTranslationFiles : SecureValueErrorFiles
	{
	}

	/// <summary>Encrypted credentials required to decrypt <a href="https://corefork.telegram.org/passport">telegram passport</a> data.		<para>See <a href="https://corefork.telegram.org/constructor/secureCredentialsEncrypted"/></para></summary>
	[TLDef(0x33F0EA47)]
	public partial class SecureCredentialsEncrypted : ITLObject
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
	public partial class Account_AuthorizationForm : ITLObject
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
		public Dictionary<long, UserBase> users;
		/// <summary>URL of the service's privacy policy</summary>
		[IfFlag(0)] public string privacy_policy_url;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="privacy_policy_url"/> has a value</summary>
			has_privacy_policy_url = 0x1,
		}
	}

	/// <summary>The sent email code		<para>See <a href="https://corefork.telegram.org/constructor/account.sentEmailCode"/></para></summary>
	[TLDef(0x811F854F)]
	public partial class Account_SentEmailCode : ITLObject
	{
		/// <summary>The email (to which the code was sent) must match this <a href="https://corefork.telegram.org/api/pattern">pattern</a></summary>
		public string email_pattern;
		/// <summary>The length of the verification code</summary>
		public int length;
	}

	/// <summary>Deep linking info		<para>See <a href="https://corefork.telegram.org/constructor/help.deepLinkInfo"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.deepLinkInfoEmpty">help.deepLinkInfoEmpty</a></remarks>
	[TLDef(0x6A4EE832)]
	public partial class Help_DeepLinkInfo : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Message to show to the user</summary>
		public string message;
		/// <summary><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></summary>
		[IfFlag(1)] public MessageEntity[] entities;

		[Flags] public enum Flags
		{
			/// <summary>An update of the app is required to parse this link</summary>
			update_app = 0x1,
			/// <summary>Field <see cref="entities"/> has a value</summary>
			has_entities = 0x2,
		}
	}

	/// <summary>Saved contact		<para>Derived classes: <see cref="SavedPhoneContact"/></para>		<para>See <a href="https://corefork.telegram.org/type/SavedContact"/></para></summary>
	public abstract partial class SavedContact : ITLObject { }
	/// <summary>Saved contact		<para>See <a href="https://corefork.telegram.org/constructor/savedPhoneContact"/></para></summary>
	[TLDef(0x1142BD56)]
	public partial class SavedPhoneContact : SavedContact
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

	/// <summary>Takout info		<para>See <a href="https://corefork.telegram.org/constructor/account.takeout"/></para></summary>
	[TLDef(0x4DBA4501)]
	public partial class Account_Takeout : ITLObject
	{
		/// <summary>Takeout ID</summary>
		public long id;
	}

	/// <summary>Key derivation function to use when generating the <a href="https://corefork.telegram.org/api/srp">password hash for SRP two-factor authorization</a>		<para>Derived classes: <see cref="PasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow"/></para>		<para>See <a href="https://corefork.telegram.org/type/PasswordKdfAlgo"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/passwordKdfAlgoUnknown">passwordKdfAlgoUnknown</a></remarks>
	public abstract partial class PasswordKdfAlgo : ITLObject { }
	/// <summary>This key derivation algorithm defines that <a href="https://corefork.telegram.org/api/srp">SRP 2FA login</a> must be used		<para>See <a href="https://corefork.telegram.org/constructor/passwordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow"/></para></summary>
	[TLDef(0x3A912D4A)]
	public partial class PasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow : PasswordKdfAlgo
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
	public abstract partial class SecurePasswordKdfAlgo : ITLObject
	{
		/// <summary>Salt</summary>
		public byte[] salt;
	}
	/// <summary>PBKDF2 with SHA512 and 100000 iterations KDF algo		<para>See <a href="https://corefork.telegram.org/constructor/securePasswordKdfAlgoPBKDF2HMACSHA512iter100000"/></para></summary>
	[TLDef(0xBBF2DDA0)]
	public partial class SecurePasswordKdfAlgoPBKDF2HMACSHA512iter100000 : SecurePasswordKdfAlgo { }
	/// <summary>SHA512 KDF algo		<para>See <a href="https://corefork.telegram.org/constructor/securePasswordKdfAlgoSHA512"/></para></summary>
	[TLDef(0x86471D92)]
	public partial class SecurePasswordKdfAlgoSHA512 : SecurePasswordKdfAlgo { }

	/// <summary>Secure settings		<para>See <a href="https://corefork.telegram.org/constructor/secureSecretSettings"/></para></summary>
	[TLDef(0x1527BCAC)]
	public partial class SecureSecretSettings : ITLObject
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
	public partial class InputCheckPasswordSRP : ITLObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/srp">SRP ID</a></summary>
		public long srp_id;
		/// <summary><c>A</c> parameter (see <a href="https://corefork.telegram.org/api/srp">SRP</a>)</summary>
		public byte[] A;
		/// <summary><c>M1</c> parameter (see <a href="https://corefork.telegram.org/api/srp">SRP</a>)</summary>
		public byte[] M1;
	}

	/// <summary>Required secure file type		<para>Derived classes: <see cref="SecureRequiredType"/>, <see cref="SecureRequiredTypeOneOf"/></para>		<para>See <a href="https://corefork.telegram.org/type/SecureRequiredType"/></para></summary>
	public abstract partial class SecureRequiredTypeBase : ITLObject { }
	/// <summary>Required type		<para>See <a href="https://corefork.telegram.org/constructor/secureRequiredType"/></para></summary>
	[TLDef(0x829D99DA)]
	public partial class SecureRequiredType : SecureRequiredTypeBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Secure value type</summary>
		public SecureValueType type;

		[Flags] public enum Flags
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
	public partial class SecureRequiredTypeOneOf : SecureRequiredTypeBase
	{
		/// <summary>Secure required value types</summary>
		public SecureRequiredTypeBase[] types;
	}

	/// <summary>Telegram <a href="https://corefork.telegram.org/passport">passport</a> configuration		<para>See <a href="https://corefork.telegram.org/constructor/help.passportConfig"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.passportConfigNotModified">help.passportConfigNotModified</a></remarks>
	[TLDef(0xA098D6AF)]
	public partial class Help_PassportConfig : ITLObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></summary>
		public int hash;
		/// <summary>Localization</summary>
		public DataJSON countries_langs;
	}

	/// <summary>Event that occured in the application.		<para>See <a href="https://corefork.telegram.org/constructor/inputAppEvent"/></para></summary>
	[TLDef(0x1D1B1245)]
	public partial class InputAppEvent : ITLObject
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

	/// <summary>JSON key: value pair		<para>Derived classes: <see cref="JsonObjectValue"/></para>		<para>See <a href="https://corefork.telegram.org/type/JSONObjectValue"/></para></summary>
	public abstract partial class JSONObjectValue : ITLObject { }
	/// <summary>JSON key: value pair		<para>See <a href="https://corefork.telegram.org/constructor/jsonObjectValue"/></para></summary>
	[TLDef(0xC0DE1BD9)]
	public partial class JsonObjectValue : JSONObjectValue
	{
		/// <summary>Key</summary>
		public string key;
		/// <summary>Value</summary>
		public JSONValue value;
	}

	/// <summary>JSON value		<para>Derived classes: <see cref="JsonNull"/>, <see cref="JsonBool"/>, <see cref="JsonNumber"/>, <see cref="JsonString"/>, <see cref="JsonArray"/>, <see cref="JsonObject"/></para>		<para>See <a href="https://corefork.telegram.org/type/JSONValue"/></para></summary>
	public abstract partial class JSONValue : ITLObject { }
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
		public JSONObjectValue[] value;
	}

	/// <summary>Table cell		<para>See <a href="https://corefork.telegram.org/constructor/pageTableCell"/></para></summary>
	[TLDef(0x34566B6A)]
	public partial class PageTableCell : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Content</summary>
		[IfFlag(7)] public RichText text;
		/// <summary>For how many columns should this cell extend</summary>
		[IfFlag(1)] public int colspan;
		/// <summary>For how many rows should this cell extend</summary>
		[IfFlag(2)] public int rowspan;

		[Flags] public enum Flags
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
			/// <summary>Block vertically-alligned to the bottom</summary>
			valign_bottom = 0x40,
			/// <summary>Field <see cref="text"/> has a value</summary>
			has_text = 0x80,
		}
	}

	/// <summary>Table row		<para>See <a href="https://corefork.telegram.org/constructor/pageTableRow"/></para></summary>
	[TLDef(0xE0C0C5E5)]
	public partial class PageTableRow : ITLObject
	{
		/// <summary>Table cells</summary>
		public PageTableCell[] cells;
	}

	/// <summary>Page caption		<para>See <a href="https://corefork.telegram.org/constructor/pageCaption"/></para></summary>
	[TLDef(0x6F747657)]
	public partial class PageCaption : ITLObject
	{
		/// <summary>Caption</summary>
		public RichText text;
		/// <summary>Credits</summary>
		public RichText credit;
	}

	/// <summary>Item in block list		<para>Derived classes: <see cref="PageListItemText"/>, <see cref="PageListItemBlocks"/></para>		<para>See <a href="https://corefork.telegram.org/type/PageListItem"/></para></summary>
	public abstract partial class PageListItem : ITLObject { }
	/// <summary>List item		<para>See <a href="https://corefork.telegram.org/constructor/pageListItemText"/></para></summary>
	[TLDef(0xB92FB6CD)]
	public partial class PageListItemText : PageListItem
	{
		/// <summary>Text</summary>
		public RichText text;
	}
	/// <summary>List item		<para>See <a href="https://corefork.telegram.org/constructor/pageListItemBlocks"/></para></summary>
	[TLDef(0x25E073FC)]
	public partial class PageListItemBlocks : PageListItem
	{
		/// <summary>Blocks</summary>
		public PageBlock[] blocks;
	}

	/// <summary>Represents an <a href="https://instantview.telegram.org">instant view ordered list</a>		<para>Derived classes: <see cref="PageListOrderedItemText"/>, <see cref="PageListOrderedItemBlocks"/></para>		<para>See <a href="https://corefork.telegram.org/type/PageListOrderedItem"/></para></summary>
	public abstract partial class PageListOrderedItem : ITLObject
	{
		/// <summary>Number of element within ordered list</summary>
		public string num;
	}
	/// <summary>Ordered list of text items		<para>See <a href="https://corefork.telegram.org/constructor/pageListOrderedItemText"/></para></summary>
	[TLDef(0x5E068047)]
	public partial class PageListOrderedItemText : PageListOrderedItem
	{
		/// <summary>Text</summary>
		public RichText text;
	}
	/// <summary>Ordered list of <a href="https://instantview.telegram.org">IV</a> blocks		<para>See <a href="https://corefork.telegram.org/constructor/pageListOrderedItemBlocks"/></para></summary>
	[TLDef(0x98DD8936)]
	public partial class PageListOrderedItemBlocks : PageListOrderedItem
	{
		/// <summary>Item contents</summary>
		public PageBlock[] blocks;
	}

	/// <summary>Related article		<para>See <a href="https://corefork.telegram.org/constructor/pageRelatedArticle"/></para></summary>
	[TLDef(0xB390DC08)]
	public partial class PageRelatedArticle : ITLObject
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
		/// <summary>Date of pubblication</summary>
		[IfFlag(4)] public DateTime published_date;

		[Flags] public enum Flags
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
	public partial class Page : ITLObject
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
		/// <summary>Viewcount</summary>
		[IfFlag(3)] public int views;

		[Flags] public enum Flags
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
	public partial class Help_SupportName : ITLObject
	{
		/// <summary>Localized name</summary>
		public string name;
	}

	/// <summary>Internal use		<para>See <a href="https://corefork.telegram.org/constructor/help.userInfo"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.userInfoEmpty">help.userInfoEmpty</a></remarks>
	[TLDef(0x01EB3758)]
	public partial class Help_UserInfo : ITLObject
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
	public partial class PollAnswer : ITLObject
	{
		/// <summary>Textual representation of the answer</summary>
		public string text;
		/// <summary>The param that has to be passed to <a href="https://corefork.telegram.org/method/messages.sendVote">messages.sendVote</a>.</summary>
		public byte[] option;
	}

	/// <summary>Poll		<para>See <a href="https://corefork.telegram.org/constructor/poll"/></para></summary>
	[TLDef(0x86E18161)]
	public partial class Poll : ITLObject
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

		[Flags] public enum Flags
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
	public partial class PollAnswerVoters : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>The param that has to be passed to <a href="https://corefork.telegram.org/method/messages.sendVote">messages.sendVote</a>.</summary>
		public byte[] option;
		/// <summary>How many users voted for this option</summary>
		public int voters;

		[Flags] public enum Flags
		{
			/// <summary>Whether we have chosen this answer</summary>
			chosen = 0x1,
			/// <summary>For quizes, whether the option we have chosen is correct</summary>
			correct = 0x2,
		}
	}

	/// <summary>Results of poll		<para>See <a href="https://corefork.telegram.org/constructor/pollResults"/></para></summary>
	[TLDef(0xDCB82EA3)]
	public partial class PollResults : ITLObject
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

		[Flags] public enum Flags
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
	public partial class ChatOnlines : ITLObject
	{
		/// <summary>Number of online users</summary>
		public int onlines;
	}

	/// <summary>URL with chat statistics		<para>See <a href="https://corefork.telegram.org/constructor/statsURL"/></para></summary>
	[TLDef(0x47A971E0)]
	public partial class StatsURL : ITLObject
	{
		/// <summary>Chat statistics</summary>
		public string url;
	}

	/// <summary>Represents the rights of an admin in a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>.		<para>See <a href="https://corefork.telegram.org/constructor/chatAdminRights"/></para></summary>
	[TLDef(0x5FB224D5)]
	public partial class ChatAdminRights : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;

		[Flags] public enum Flags
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
			/// <summary>Set this flag if none of the other flags are set, but you stil want the user to be an admin.</summary>
			other = 0x1000,
		}
	}

	/// <summary>Represents the rights of a normal user in a <a href="https://corefork.telegram.org/api/channel">supergroup/channel/chat</a>. In this case, the flags are inverted: if set, a flag <strong>does not allow</strong> a user to do X.		<para>See <a href="https://corefork.telegram.org/constructor/chatBannedRights"/></para></summary>
	[TLDef(0x9F120418)]
	public partial class ChatBannedRights : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Validity of said permissions (it is considered forever any value less then 30 seconds or more then 366 days).</summary>
		public DateTime until_date;

		[Flags] public enum Flags
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
			/// <summary>If set, does not allow a user to send stickers in a <a href="https://corefork.telegram.org/api/channel">supergroup/chat</a></summary>
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
	public abstract partial class InputWallPaperBase : ITLObject { }
	/// <summary>Wallpaper		<para>See <a href="https://corefork.telegram.org/constructor/inputWallPaper"/></para></summary>
	[TLDef(0xE630B979)]
	public partial class InputWallPaper : InputWallPaperBase
	{
		/// <summary>Wallpaper ID</summary>
		public long id;
		/// <summary>Access hash</summary>
		public long access_hash;
	}
	/// <summary>Wallpaper by slug (a unique ID)		<para>See <a href="https://corefork.telegram.org/constructor/inputWallPaperSlug"/></para></summary>
	[TLDef(0x72091C80)]
	public partial class InputWallPaperSlug : InputWallPaperBase
	{
		/// <summary>Unique wallpaper ID</summary>
		public string slug;
	}
	/// <summary>Wallpaper with no file access hash, used for example when deleting (<c>unsave=true</c>) wallpapers using <a href="https://corefork.telegram.org/method/account.saveWallPaper">account.saveWallPaper</a>, specifying just the wallpaper ID.		<para>See <a href="https://corefork.telegram.org/constructor/inputWallPaperNoFile"/></para></summary>
	[TLDef(0x967A462E)]
	public partial class InputWallPaperNoFile : InputWallPaperBase
	{
		/// <summary>Wallpaper ID</summary>
		public long id;
	}

	/// <summary>Installed wallpapers		<para>See <a href="https://corefork.telegram.org/constructor/account.wallPapers"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/account.wallPapersNotModified">account.wallPapersNotModified</a></remarks>
	[TLDef(0xCDC3858C)]
	public partial class Account_WallPapers : ITLObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></summary>
		public long hash;
		/// <summary>Wallpapers</summary>
		public WallPaperBase[] wallpapers;
	}

	/// <summary>Settings used by telegram servers for sending the confirm code.		<para>See <a href="https://corefork.telegram.org/constructor/codeSettings"/></para></summary>
	[TLDef(0xDEBEBE83)]
	public partial class CodeSettings : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;

		[Flags] public enum Flags
		{
			/// <summary>Whether to allow phone verification via <a href="https://corefork.telegram.org/api/auth">phone calls</a>.</summary>
			allow_flashcall = 0x1,
			/// <summary>Pass true if the phone number is used on the current device. Ignored if allow_flashcall is not set.</summary>
			current_number = 0x2,
			/// <summary>If a token that will be included in eventually sent SMSs is required: required in newer versions of android, to use the <a href="https://developers.google.com/identity/sms-retriever/overview">android SMS receiver APIs</a></summary>
			allow_app_hash = 0x10,
		}
	}

	/// <summary>Wallpaper settings		<para>See <a href="https://corefork.telegram.org/constructor/wallPaperSettings"/></para></summary>
	[TLDef(0x1DC1BCA4)]
	public partial class WallPaperSettings : ITLObject
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

		[Flags] public enum Flags
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
	public partial class AutoDownloadSettings : ITLObject
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

		[Flags] public enum Flags
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
	public partial class Account_AutoDownloadSettings : ITLObject
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
	public partial class EmojiKeyword : ITLObject
	{
		/// <summary>Keyword</summary>
		public string keyword;
		/// <summary>Emojis associated to keyword</summary>
		public string[] emoticons;
	}
	/// <summary>Deleted emoji keyword		<para>See <a href="https://corefork.telegram.org/constructor/emojiKeywordDeleted"/></para></summary>
	[TLDef(0x236DF622)]
	public partial class EmojiKeywordDeleted : EmojiKeyword { }

	/// <summary>Changes to emoji keywords		<para>See <a href="https://corefork.telegram.org/constructor/emojiKeywordsDifference"/></para></summary>
	[TLDef(0x5CC761BD)]
	public partial class EmojiKeywordsDifference : ITLObject
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
	public partial class EmojiURL : ITLObject
	{
		/// <summary>An HTTP URL which can be used to automatically log in into translation platform and suggest new emoji replacements. The URL will be valid for 30 seconds after generation</summary>
		public string url;
	}

	/// <summary>Emoji language		<para>See <a href="https://corefork.telegram.org/constructor/emojiLanguage"/></para></summary>
	[TLDef(0xB3FB5361)]
	public partial class EmojiLanguage : ITLObject
	{
		/// <summary>Language code</summary>
		public string lang_code;
	}

	/// <summary>Folder		<para>See <a href="https://corefork.telegram.org/constructor/folder"/></para></summary>
	[TLDef(0xFF544E65)]
	public partial class Folder : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Folder ID</summary>
		public int id;
		/// <summary>Folder title</summary>
		public string title;
		/// <summary>Folder picture</summary>
		[IfFlag(3)] public ChatPhoto photo;

		[Flags] public enum Flags
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
	public partial class InputFolderPeer : ITLObject
	{
		/// <summary>Peer</summary>
		public InputPeer peer;
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		public int folder_id;
	}

	/// <summary>Peer in a folder		<para>See <a href="https://corefork.telegram.org/constructor/folderPeer"/></para></summary>
	[TLDef(0xE9BAA668)]
	public partial class FolderPeer : ITLObject
	{
		/// <summary>Folder peer info</summary>
		public Peer peer;
		/// <summary><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></summary>
		public int folder_id;
	}

	/// <summary>Indicates how many results would be found by a <a href="https://corefork.telegram.org/method/messages.search">messages.search</a> call with the same parameters		<para>See <a href="https://corefork.telegram.org/constructor/messages.searchCounter"/></para></summary>
	[TLDef(0xE844EBFF)]
	public partial class Messages_SearchCounter : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Provided message filter</summary>
		public MessagesFilter filter;
		/// <summary>Number of results that were found server-side</summary>
		public int count;

		[Flags] public enum Flags
		{
			/// <summary>If set, the results may be inexact</summary>
			inexact = 0x2,
		}
	}

	/// <summary>URL authorization result		<para>Derived classes: <see cref="UrlAuthResultRequest"/>, <see cref="UrlAuthResultAccepted"/>, <see cref="UrlAuthResultDefault"/></para>		<para>See <a href="https://corefork.telegram.org/type/UrlAuthResult"/></para></summary>
	public abstract partial class UrlAuthResult : ITLObject { }
	/// <summary>Details about the authorization request, for more info <a href="https://corefork.telegram.org/api/url-authorization">click here »</a>		<para>See <a href="https://corefork.telegram.org/constructor/urlAuthResultRequest"/></para></summary>
	[TLDef(0x92D33A0E)]
	public partial class UrlAuthResultRequest : UrlAuthResult
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Username of a bot, which will be used for user authorization. If not specified, the current bot's username will be assumed. The url's domain must be the same as the domain linked with the bot. See <a href="https://core.telegram.org/widgets/login#linking-your-domain-to-the-bot">Linking your domain to the bot</a> for more details.</summary>
		public UserBase bot;
		/// <summary>The domain name of the website on which the user will log in.</summary>
		public string domain;

		[Flags] public enum Flags
		{
			/// <summary>Whether the bot would like to send messages to the user</summary>
			request_write_access = 0x1,
		}
	}
	/// <summary>Details about an accepted authorization request, for more info <a href="https://corefork.telegram.org/api/url-authorization">click here »</a>		<para>See <a href="https://corefork.telegram.org/constructor/urlAuthResultAccepted"/></para></summary>
	[TLDef(0x8F8C0E4E)]
	public partial class UrlAuthResultAccepted : UrlAuthResult
	{
		/// <summary>The URL name of the website on which the user has logged in.</summary>
		public string url;
	}
	/// <summary>Details about an accepted authorization request, for more info <a href="https://corefork.telegram.org/api/url-authorization">click here »</a>		<para>See <a href="https://corefork.telegram.org/constructor/urlAuthResultDefault"/></para></summary>
	[TLDef(0xA9D6DB1F)]
	public partial class UrlAuthResultDefault : UrlAuthResult { }

	/// <summary>Geographical location of supergroup (geogroups)		<para>See <a href="https://corefork.telegram.org/constructor/channelLocation"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/channelLocationEmpty">channelLocationEmpty</a></remarks>
	[TLDef(0x209B82DB)]
	public partial class ChannelLocation : ITLObject
	{
		/// <summary>Geographical location of supergrup</summary>
		public GeoPoint geo_point;
		/// <summary>Textual description of the address</summary>
		public string address;
	}

	/// <summary>Geolocated peer		<para>Derived classes: <see cref="PeerLocated"/>, <see cref="PeerSelfLocated"/></para>		<para>See <a href="https://corefork.telegram.org/type/PeerLocated"/></para></summary>
	public abstract partial class PeerLocatedBase : ITLObject
	{
		/// <summary>Validity period of current data</summary>
		public abstract DateTime Expires { get; }
	}
	/// <summary>Peer geolocated nearby		<para>See <a href="https://corefork.telegram.org/constructor/peerLocated"/></para></summary>
	[TLDef(0xCA461B5D)]
	public partial class PeerLocated : PeerLocatedBase
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
	public partial class PeerSelfLocated : PeerLocatedBase
	{
		/// <summary>Expiry of geolocation info for current peer</summary>
		public DateTime expires;

		/// <summary>Expiry of geolocation info for current peer</summary>
		public override DateTime Expires => expires;
	}

	/// <summary>Restriction reason.		<para>See <a href="https://corefork.telegram.org/constructor/restrictionReason"/></para></summary>
	[TLDef(0xD072ACB4)]
	public partial class RestrictionReason : ITLObject
	{
		/// <summary>Platform identifier (ios, android, wp, all, etc.), can be concatenated with a dash as separator (<c>android-ios</c>, <c>ios-wp</c>, etc)</summary>
		public string platform;
		/// <summary>Restriction reason (<c>porno</c>, <c>terms</c>, etc.)</summary>
		public string reason;
		/// <summary>Error message to be shown to the user</summary>
		public string text;
	}

	/// <summary>Cloud theme		<para>Derived classes: <see cref="InputTheme"/>, <see cref="InputThemeSlug"/></para>		<para>See <a href="https://corefork.telegram.org/type/InputTheme"/></para></summary>
	public abstract partial class InputThemeBase : ITLObject { }
	/// <summary>Theme		<para>See <a href="https://corefork.telegram.org/constructor/inputTheme"/></para></summary>
	[TLDef(0x3C5693E9)]
	public partial class InputTheme : InputThemeBase
	{
		/// <summary>ID</summary>
		public long id;
		/// <summary>Access hash</summary>
		public long access_hash;
	}
	/// <summary>Theme by theme ID		<para>See <a href="https://corefork.telegram.org/constructor/inputThemeSlug"/></para></summary>
	[TLDef(0xF5890DF1)]
	public partial class InputThemeSlug : InputThemeBase
	{
		/// <summary>Unique theme ID</summary>
		public string slug;
	}

	/// <summary>Theme		<para>See <a href="https://corefork.telegram.org/constructor/theme"/></para></summary>
	[TLDef(0xA00E67D6)]
	public partial class Theme : ITLObject
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
		[IfFlag(6)] public string emoticon;
		/// <summary>Installation count</summary>
		[IfFlag(4)] public int installs_count;

		[Flags] public enum Flags
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
			/// <summary>Whether this theme is meant to be used as a <a href="https://corefork.telegram.org/blog/chat-themes-interactive-emoji-read-receipts">chat theme</a></summary>
			for_chat = 0x20,
			/// <summary>Field <see cref="emoticon"/> has a value</summary>
			has_emoticon = 0x40,
		}
	}

	/// <summary>Installed themes		<para>See <a href="https://corefork.telegram.org/constructor/account.themes"/></para></summary>
	/// <remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/account.themesNotModified">account.themesNotModified</a></remarks>
	[TLDef(0x9A3D8C6D)]
	public partial class Account_Themes : ITLObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></summary>
		public long hash;
		/// <summary>Themes</summary>
		public Theme[] themes;
	}

	/// <summary>Login token (for QR code login)		<para>Derived classes: <see cref="Auth_LoginToken"/>, <see cref="Auth_LoginTokenMigrateTo"/>, <see cref="Auth_LoginTokenSuccess"/></para>		<para>See <a href="https://corefork.telegram.org/type/auth.LoginToken"/></para></summary>
	public abstract partial class Auth_LoginTokenBase : ITLObject { }
	/// <summary>Login token (for <a href="https://corefork.telegram.org/api/qr-login">QR code login</a>)		<para>See <a href="https://corefork.telegram.org/constructor/auth.loginToken"/></para></summary>
	[TLDef(0x629F1980)]
	public partial class Auth_LoginToken : Auth_LoginTokenBase
	{
		/// <summary>Expiry date of QR code</summary>
		public DateTime expires;
		/// <summary>Token to render in QR code</summary>
		public byte[] token;
	}
	/// <summary>Repeat the query to the specified DC		<para>See <a href="https://corefork.telegram.org/constructor/auth.loginTokenMigrateTo"/></para></summary>
	[TLDef(0x068E9916)]
	public partial class Auth_LoginTokenMigrateTo : Auth_LoginTokenBase
	{
		/// <summary>DC ID</summary>
		public int dc_id;
		/// <summary>Token to use for login</summary>
		public byte[] token;
	}
	/// <summary>Login via token (QR code) succeded!		<para>See <a href="https://corefork.telegram.org/constructor/auth.loginTokenSuccess"/></para></summary>
	[TLDef(0x390D5C5E)]
	public partial class Auth_LoginTokenSuccess : Auth_LoginTokenBase
	{
		/// <summary>Authorization info</summary>
		public Auth_AuthorizationBase authorization;
	}

	/// <summary>Sensitive content settings		<para>See <a href="https://corefork.telegram.org/constructor/account.contentSettings"/></para></summary>
	[TLDef(0x57E28221)]
	public partial class Account_ContentSettings : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;

		[Flags] public enum Flags
		{
			/// <summary>Whether viewing of sensitive (NSFW) content is enabled</summary>
			sensitive_enabled = 0x1,
			/// <summary>Whether the current client can change the sensitive content settings to view NSFW content</summary>
			sensitive_can_change = 0x2,
		}
	}

	/// <summary>Inactive chat list		<para>See <a href="https://corefork.telegram.org/constructor/messages.inactiveChats"/></para></summary>
	[TLDef(0xA927FEC5)]
	public partial class Messages_InactiveChats : ITLObject
	{
		/// <summary>When was the chat last active</summary>
		public int[] dates;
		/// <summary>Chat list</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users mentioned in the chat list</summary>
		public Dictionary<long, UserBase> users;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
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
	public partial class InputThemeSettings : ITLObject
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

		[Flags] public enum Flags
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
	public partial class ThemeSettings : ITLObject
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

		[Flags] public enum Flags
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
	public abstract partial class WebPageAttribute : ITLObject { }
	/// <summary>Page theme		<para>See <a href="https://corefork.telegram.org/constructor/webPageAttributeTheme"/></para></summary>
	[TLDef(0x54B56617)]
	public partial class WebPageAttributeTheme : WebPageAttribute
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Theme files</summary>
		[IfFlag(0)] public DocumentBase[] documents;
		/// <summary>Theme settings</summary>
		[IfFlag(1)] public ThemeSettings settings;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="documents"/> has a value</summary>
			has_documents = 0x1,
			/// <summary>Field <see cref="settings"/> has a value</summary>
			has_settings = 0x2,
		}
	}

	/// <summary>How a user voted in a poll		<para>Derived classes: <see cref="MessageUserVote"/>, <see cref="MessageUserVoteInputOption"/>, <see cref="MessageUserVoteMultiple"/></para>		<para>See <a href="https://corefork.telegram.org/type/MessageUserVote"/></para></summary>
	public abstract partial class MessageUserVoteBase : ITLObject
	{
		/// <summary>User ID</summary>
		public abstract long UserId { get; }
		/// <summary>When did the user cast the vote</summary>
		public abstract DateTime Date { get; }
	}
	/// <summary>How a user voted in a poll		<para>See <a href="https://corefork.telegram.org/constructor/messageUserVote"/></para></summary>
	[TLDef(0x34D247B4)]
	public partial class MessageUserVote : MessageUserVoteBase
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
	public partial class MessageUserVoteInputOption : MessageUserVoteBase
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
	public partial class MessageUserVoteMultiple : MessageUserVoteBase
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
	public partial class Messages_VotesList : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Total number of votes for all options (or only for the chosen <c>option</c>, if provided to <a href="https://corefork.telegram.org/method/messages.getPollVotes">messages.getPollVotes</a>)</summary>
		public int count;
		/// <summary>Vote info for each user</summary>
		public MessageUserVoteBase[] votes;
		/// <summary>Info about users that voted in the poll</summary>
		public Dictionary<long, UserBase> users;
		/// <summary>Offset to use with the next <a href="https://corefork.telegram.org/method/messages.getPollVotes">messages.getPollVotes</a> request, empty string if no more results are available.</summary>
		[IfFlag(0)] public string next_offset;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="next_offset"/> has a value</summary>
			has_next_offset = 0x1,
		}
	}

	/// <summary>Credit card info URL provided by the bank		<para>See <a href="https://corefork.telegram.org/constructor/bankCardOpenUrl"/></para></summary>
	[TLDef(0xF568028A)]
	public partial class BankCardOpenUrl : ITLObject
	{
		/// <summary>Info URL</summary>
		public string url;
		/// <summary>Bank name</summary>
		public string name;
	}

	/// <summary>Credit card info, provided by the card's bank(s)		<para>See <a href="https://corefork.telegram.org/constructor/payments.bankCardData"/></para></summary>
	[TLDef(0x3E24E573)]
	public partial class Payments_BankCardData : ITLObject
	{
		/// <summary>Credit card title</summary>
		public string title;
		/// <summary>Info URL(s) provided by the card's bank(s)</summary>
		public BankCardOpenUrl[] open_urls;
	}

	/// <summary>Dialog filter AKA <a href="https://corefork.telegram.org/api/folders">folder</a>		<para>See <a href="https://corefork.telegram.org/constructor/dialogFilter"/></para></summary>
	[TLDef(0x7438F7E8)]
	public partial class DialogFilter : ITLObject
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

		[Flags] public enum Flags
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
	public partial class DialogFilterSuggested : ITLObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/folders">Folder info</a></summary>
		public DialogFilter filter;
		/// <summary><a href="https://corefork.telegram.org/api/folders">Folder</a> description</summary>
		public string description;
	}

	/// <summary><a href="https://corefork.telegram.org/api/stats">Channel statistics</a> date range		<para>See <a href="https://corefork.telegram.org/constructor/statsDateRangeDays"/></para></summary>
	[TLDef(0xB637EDAF)]
	public partial class StatsDateRangeDays : ITLObject
	{
		/// <summary>Initial date</summary>
		public DateTime min_date;
		/// <summary>Final date</summary>
		public DateTime max_date;
	}

	/// <summary>Statistics value couple; initial and final value for period of time currently in consideration		<para>See <a href="https://corefork.telegram.org/constructor/statsAbsValueAndPrev"/></para></summary>
	[TLDef(0xCB43ACDE)]
	public partial class StatsAbsValueAndPrev : ITLObject
	{
		/// <summary>Current value</summary>
		public double current;
		/// <summary>Previous value</summary>
		public double previous;
	}

	/// <summary><a href="https://corefork.telegram.org/api/stats">Channel statistics percentage</a>.<br/>Compute the percentage simply by doing <c>part * total / 100</c>		<para>See <a href="https://corefork.telegram.org/constructor/statsPercentValue"/></para></summary>
	[TLDef(0xCBCE2FE0)]
	public partial class StatsPercentValue : ITLObject
	{
		/// <summary>Partial value</summary>
		public double part;
		/// <summary>Total value</summary>
		public double total;
	}

	/// <summary>Channel statistics graph		<para>Derived classes: <see cref="StatsGraphAsync"/>, <see cref="StatsGraphError"/>, <see cref="StatsGraph"/></para>		<para>See <a href="https://corefork.telegram.org/type/StatsGraph"/></para></summary>
	public abstract partial class StatsGraphBase : ITLObject { }
	/// <summary>This <a href="https://corefork.telegram.org/api/stats">channel statistics graph</a> must be generated asynchronously using <a href="https://corefork.telegram.org/method/stats.loadAsyncGraph">stats.loadAsyncGraph</a> to reduce server load		<para>See <a href="https://corefork.telegram.org/constructor/statsGraphAsync"/></para></summary>
	[TLDef(0x4A27EB2D)]
	public partial class StatsGraphAsync : StatsGraphBase
	{
		/// <summary>Token to use for fetching the async graph</summary>
		public string token;
	}
	/// <summary>An error occurred while generating the <a href="https://corefork.telegram.org/api/stats">statistics graph</a>		<para>See <a href="https://corefork.telegram.org/constructor/statsGraphError"/></para></summary>
	[TLDef(0xBEDC9822)]
	public partial class StatsGraphError : StatsGraphBase
	{
		/// <summary>The error</summary>
		public string error;
	}
	/// <summary><a href="https://corefork.telegram.org/api/stats">Channel statistics graph</a>		<para>See <a href="https://corefork.telegram.org/constructor/statsGraph"/></para></summary>
	[TLDef(0x8EA464B6)]
	public partial class StatsGraph : StatsGraphBase
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Statistics data</summary>
		public DataJSON json;
		/// <summary>Zoom token</summary>
		[IfFlag(0)] public string zoom_token;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="zoom_token"/> has a value</summary>
			has_zoom_token = 0x1,
		}
	}

	/// <summary>Message interaction counters		<para>See <a href="https://corefork.telegram.org/constructor/messageInteractionCounters"/></para></summary>
	[TLDef(0xAD4FC9BD)]
	public partial class MessageInteractionCounters : ITLObject
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
	public partial class Stats_BroadcastStats : ITLObject
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
		/// <summary>Subscriber language graph (piechart)</summary>
		public StatsGraphBase languages_graph;
		/// <summary>Recent message interactions</summary>
		public MessageInteractionCounters[] recent_message_interactions;
	}

	/// <summary>Info about pinned MTProxy or Public Service Announcement peers.		<para>Derived classes: <see cref="Help_PromoDataEmpty"/>, <see cref="Help_PromoData"/></para>		<para>See <a href="https://corefork.telegram.org/type/help.PromoData"/></para></summary>
	public abstract partial class Help_PromoDataBase : ITLObject { }
	/// <summary>No PSA/MTProxy info is available		<para>See <a href="https://corefork.telegram.org/constructor/help.promoDataEmpty"/></para></summary>
	[TLDef(0x98F6AC75)]
	public partial class Help_PromoDataEmpty : Help_PromoDataBase
	{
		/// <summary>Re-fetch PSA/MTProxy info after the specified number of seconds</summary>
		public DateTime expires;
	}
	/// <summary>MTProxy/Public Service Announcement information		<para>See <a href="https://corefork.telegram.org/constructor/help.promoData"/></para></summary>
	[TLDef(0x8C39793F)]
	public partial class Help_PromoData : Help_PromoDataBase
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
		public Dictionary<long, UserBase> users;
		/// <summary>PSA type</summary>
		[IfFlag(1)] public string psa_type;
		/// <summary>PSA message</summary>
		[IfFlag(2)] public string psa_message;

		[Flags] public enum Flags
		{
			/// <summary>MTProxy-related channel</summary>
			proxy = 0x1,
			/// <summary>Field <see cref="psa_type"/> has a value</summary>
			has_psa_type = 0x2,
			/// <summary>Field <see cref="psa_message"/> has a value</summary>
			has_psa_message = 0x4,
		}
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	/// <summary><a href="https://corefork.telegram.org/api/files#animated-profile-pictures">Animated profile picture</a> in MPEG4 format		<para>See <a href="https://corefork.telegram.org/constructor/videoSize"/></para></summary>
	[TLDef(0xDE33B094)]
	public partial class VideoSize : ITLObject
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

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="video_start_ts"/> has a value</summary>
			has_video_start_ts = 0x1,
		}
	}

	/// <summary>Information about an active user in a supergroup		<para>See <a href="https://corefork.telegram.org/constructor/statsGroupTopPoster"/></para></summary>
	[TLDef(0x9D04AF9B)]
	public partial class StatsGroupTopPoster : ITLObject
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
	public partial class StatsGroupTopAdmin : ITLObject
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
	public partial class StatsGroupTopInviter : ITLObject
	{
		/// <summary>User ID</summary>
		public long user_id;
		/// <summary>Number of invitations for <a href="https://corefork.telegram.org/api/stats">statistics</a> period in consideration</summary>
		public int invitations;
	}

	/// <summary>Supergroup <a href="https://corefork.telegram.org/api/stats">statistics</a>		<para>See <a href="https://corefork.telegram.org/constructor/stats.megagroupStats"/></para></summary>
	[TLDef(0xEF7FF916)]
	public partial class Stats_MegagroupStats : ITLObject
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
		/// <summary>Subscriber language graph (piechart)</summary>
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
		public Dictionary<long, UserBase> users;
	}

	/// <summary>Global privacy settings		<para>See <a href="https://corefork.telegram.org/constructor/globalPrivacySettings"/></para></summary>
	[TLDef(0xBEA2F424)]
	public partial class GlobalPrivacySettings : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Whether to archive and mute new chats from non-contacts</summary>
		[IfFlag(0)] public bool archive_and_mute_new_noncontact_peers;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="archive_and_mute_new_noncontact_peers"/> has a value</summary>
			has_archive_and_mute_new_noncontact_peers = 0x1,
		}
	}

	/// <summary>Country code and phone number pattern of a specific country		<para>See <a href="https://corefork.telegram.org/constructor/help.countryCode"/></para></summary>
	[TLDef(0x4203C5EF)]
	public partial class Help_CountryCode : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>ISO country code</summary>
		public string country_code;
		/// <summary>Possible phone prefixes</summary>
		[IfFlag(0)] public string[] prefixes;
		/// <summary>Phone patterns: for example, <c>XXX XXX XXX</c></summary>
		[IfFlag(1)] public string[] patterns;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="prefixes"/> has a value</summary>
			has_prefixes = 0x1,
			/// <summary>Field <see cref="patterns"/> has a value</summary>
			has_patterns = 0x2,
		}
	}

	/// <summary>Name, ISO code, localized name and phone codes/patterns of a specific country		<para>See <a href="https://corefork.telegram.org/constructor/help.country"/></para></summary>
	[TLDef(0xC3878E23)]
	public partial class Help_Country : ITLObject
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

		[Flags] public enum Flags
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
	public partial class Help_CountriesList : ITLObject
	{
		/// <summary>Name, ISO code, localized name and phone codes/patterns of all available countries</summary>
		public Help_Country[] countries;
		/// <summary><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></summary>
		public int hash;
	}

	/// <summary>View, forward counter + info about replies of a specific message		<para>See <a href="https://corefork.telegram.org/constructor/messageViews"/></para></summary>
	[TLDef(0x455B853D)]
	public partial class MessageViews : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Viewcount of message</summary>
		[IfFlag(0)] public int views;
		/// <summary>Forward count of message</summary>
		[IfFlag(1)] public int forwards;
		/// <summary>Reply and <a href="https://corefork.telegram.org/api/threads">thread</a> information of message</summary>
		[IfFlag(2)] public MessageReplies replies;

		[Flags] public enum Flags
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
	public partial class Messages_MessageViews : ITLObject
	{
		/// <summary>View, forward counter + info about replies</summary>
		public MessageViews[] views;
		/// <summary>Chats mentioned in constructor</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users mentioned in constructor</summary>
		public Dictionary<long, UserBase> users;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	/// <summary>Information about a <a href="https://corefork.telegram.org/api/threads">message thread</a>		<para>See <a href="https://corefork.telegram.org/constructor/messages.discussionMessage"/></para></summary>
	[TLDef(0xA6341782)]
	public partial class Messages_DiscussionMessage : ITLObject
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
		public Dictionary<long, UserBase> users;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="max_id"/> has a value</summary>
			has_max_id = 0x1,
			/// <summary>Field <see cref="read_inbox_max_id"/> has a value</summary>
			has_read_inbox_max_id = 0x2,
			/// <summary>Field <see cref="read_outbox_max_id"/> has a value</summary>
			has_read_outbox_max_id = 0x4,
		}
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	/// <summary>Message replies and <a href="https://corefork.telegram.org/api/threads">thread</a> information		<para>See <a href="https://corefork.telegram.org/constructor/messageReplyHeader"/></para></summary>
	[TLDef(0xA6D57763)]
	public partial class MessageReplyHeader : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>ID of message to which this message is replying</summary>
		public int reply_to_msg_id;
		/// <summary>For replies sent in <a href="https://corefork.telegram.org/api/threads">channel discussion threads</a> of which the current user is not a member, the discussion group ID</summary>
		[IfFlag(0)] public Peer reply_to_peer_id;
		/// <summary>ID of the message that started this <a href="https://corefork.telegram.org/api/threads">message thread</a></summary>
		[IfFlag(1)] public int reply_to_top_id;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="reply_to_peer_id"/> has a value</summary>
			has_reply_to_peer_id = 0x1,
			/// <summary>Field <see cref="reply_to_top_id"/> has a value</summary>
			has_reply_to_top_id = 0x2,
		}
	}

	/// <summary>Info about <a href="https://corefork.telegram.org/api/threads">the comment section of a channel post, or a simple message thread</a>		<para>See <a href="https://corefork.telegram.org/constructor/messageReplies"/></para></summary>
	[TLDef(0x83D60FC2)]
	public partial class MessageReplies : ITLObject
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

		[Flags] public enum Flags
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
	public partial class PeerBlocked : ITLObject
	{
		/// <summary>Peer ID</summary>
		public Peer peer_id;
		/// <summary>When was the peer blocked</summary>
		public DateTime date;
	}

	/// <summary>Message statistics		<para>See <a href="https://corefork.telegram.org/constructor/stats.messageStats"/></para></summary>
	[TLDef(0x8999F295)]
	public partial class Stats_MessageStats : ITLObject
	{
		/// <summary>Message view graph</summary>
		public StatsGraphBase views_graph;
	}

	/// <summary>A group call		<para>Derived classes: <see cref="GroupCallDiscarded"/>, <see cref="GroupCall"/></para>		<para>See <a href="https://corefork.telegram.org/type/GroupCall"/></para></summary>
	public abstract partial class GroupCallBase : ITLObject
	{
		/// <summary>Group call ID</summary>
		public abstract long ID { get; }
		/// <summary>Group call access hash</summary>
		public abstract long AccessHash { get; }
	}
	/// <summary>An ended group call		<para>See <a href="https://corefork.telegram.org/constructor/groupCallDiscarded"/></para></summary>
	[TLDef(0x7780BCB4)]
	public partial class GroupCallDiscarded : GroupCallBase
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
	public partial class GroupCall : GroupCallBase
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

		[Flags] public enum Flags
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
		}

		/// <summary>Group call ID</summary>
		public override long ID => id;
		/// <summary>Group call access hash</summary>
		public override long AccessHash => access_hash;
	}

	/// <summary>Points to a specific group call		<para>See <a href="https://corefork.telegram.org/constructor/inputGroupCall"/></para></summary>
	[TLDef(0xD8AA840F)]
	public partial class InputGroupCall : ITLObject
	{
		/// <summary>Group call ID</summary>
		public long id;
		/// <summary>Group call access hash</summary>
		public long access_hash;
	}

	/// <summary>Info about a group call participant		<para>See <a href="https://corefork.telegram.org/constructor/groupCallParticipant"/></para></summary>
	[TLDef(0xEBA636FE)]
	public partial class GroupCallParticipant : ITLObject
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

		[Flags] public enum Flags
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
	public partial class Phone_GroupCall : ITLObject
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
		public Dictionary<long, UserBase> users;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	/// <summary>Info about the participants of a group call or livestream		<para>See <a href="https://corefork.telegram.org/constructor/phone.groupParticipants"/></para></summary>
	[TLDef(0xF47751B6)]
	public partial class Phone_GroupParticipants : ITLObject
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
		public Dictionary<long, UserBase> users;
		/// <summary>Version info</summary>
		public int version;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
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
	public partial class Messages_HistoryImport : ITLObject
	{
		/// <summary><a href="https://corefork.telegram.org/api/import">History import ID</a></summary>
		public long id;
	}

	/// <summary>Contains information about a chat export file <a href="https://corefork.telegram.org/api/import">generated by a foreign chat app, click here for more info</a>.<br/>If neither the <c>pm</c> or <c>group</c> flags are set, the specified chat export was generated from a chat of unknown type.		<para>See <a href="https://corefork.telegram.org/constructor/messages.historyImportParsed"/></para></summary>
	[TLDef(0x5E0FB7B9)]
	public partial class Messages_HistoryImportParsed : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Title of the chat.</summary>
		[IfFlag(2)] public string title;

		[Flags] public enum Flags
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
	public partial class Messages_AffectedFoundMessages : ITLObject
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
	public partial class ChatInviteImporter : ITLObject
	{
		public Flags flags;
		/// <summary>The user</summary>
		public long user_id;
		/// <summary>When did the user join</summary>
		public DateTime date;
		[IfFlag(2)] public string about;
		[IfFlag(1)] public long approved_by;

		[Flags] public enum Flags
		{
			requested = 0x1,
			/// <summary>Field <see cref="approved_by"/> has a value</summary>
			has_approved_by = 0x2,
			/// <summary>Field <see cref="about"/> has a value</summary>
			has_about = 0x4,
		}
	}

	/// <summary>Info about chat invites exported by a certain admin.		<para>See <a href="https://corefork.telegram.org/constructor/messages.exportedChatInvites"/></para></summary>
	[TLDef(0xBDC62DCC)]
	public partial class Messages_ExportedChatInvites : ITLObject
	{
		/// <summary>Number of invites exported by the admin</summary>
		public int count;
		/// <summary>Exported invites</summary>
		public ExportedChatInvite[] invites;
		/// <summary>Info about the admin</summary>
		public Dictionary<long, UserBase> users;
	}

	/// <summary>Contains info about a chat invite, and eventually a pointer to the newest chat invite.		<para>Derived classes: <see cref="Messages_ExportedChatInvite"/>, <see cref="Messages_ExportedChatInviteReplaced"/></para>		<para>See <a href="https://corefork.telegram.org/type/messages.ExportedChatInvite"/></para></summary>
	public abstract partial class Messages_ExportedChatInviteBase : ITLObject
	{
		/// <summary>Info about the chat invite</summary>
		public abstract ExportedChatInvite Invite { get; }
		/// <summary>Mentioned users</summary>
		public abstract Dictionary<long, UserBase> Users { get; }
	}
	/// <summary>Info about a chat invite		<para>See <a href="https://corefork.telegram.org/constructor/messages.exportedChatInvite"/></para></summary>
	[TLDef(0x1871BE50)]
	public partial class Messages_ExportedChatInvite : Messages_ExportedChatInviteBase
	{
		/// <summary>Info about the chat invite</summary>
		public ExportedChatInvite invite;
		/// <summary>Mentioned users</summary>
		public Dictionary<long, UserBase> users;

		/// <summary>Info about the chat invite</summary>
		public override ExportedChatInvite Invite => invite;
		/// <summary>Mentioned users</summary>
		public override Dictionary<long, UserBase> Users => users;
	}
	/// <summary>The specified chat invite was replaced with another one		<para>See <a href="https://corefork.telegram.org/constructor/messages.exportedChatInviteReplaced"/></para></summary>
	[TLDef(0x222600EF)]
	public partial class Messages_ExportedChatInviteReplaced : Messages_ExportedChatInviteBase
	{
		/// <summary>The replaced chat invite</summary>
		public ExportedChatInvite invite;
		/// <summary>The invite that replaces the previous invite</summary>
		public ExportedChatInvite new_invite;
		/// <summary>Mentioned users</summary>
		public Dictionary<long, UserBase> users;

		/// <summary>The replaced chat invite</summary>
		public override ExportedChatInvite Invite => invite;
		/// <summary>Mentioned users</summary>
		public override Dictionary<long, UserBase> Users => users;
	}

	/// <summary>Info about the users that joined the chat using a specific chat invite		<para>See <a href="https://corefork.telegram.org/constructor/messages.chatInviteImporters"/></para></summary>
	[TLDef(0x81B6B00A)]
	public partial class Messages_ChatInviteImporters : ITLObject
	{
		/// <summary>Number of users that joined</summary>
		public int count;
		/// <summary>The users that joined</summary>
		public ChatInviteImporter[] importers;
		/// <summary>The users that joined</summary>
		public Dictionary<long, UserBase> users;
	}

	/// <summary>Info about chat invites generated by admins.		<para>See <a href="https://corefork.telegram.org/constructor/chatAdminWithInvites"/></para></summary>
	[TLDef(0xF2ECEF23)]
	public partial class ChatAdminWithInvites : ITLObject
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
	public partial class Messages_ChatAdminsWithInvites : ITLObject
	{
		/// <summary>Info about chat invites generated by admins.</summary>
		public ChatAdminWithInvites[] admins;
		/// <summary>Mentioned users</summary>
		public Dictionary<long, UserBase> users;
	}

	/// <summary>Contains a confirmation text to be shown to the user, upon <a href="https://corefork.telegram.org/api/import">importing chat history, click here for more info »</a>.		<para>See <a href="https://corefork.telegram.org/constructor/messages.checkedHistoryImportPeer"/></para></summary>
	[TLDef(0xA24DE717)]
	public partial class Messages_CheckedHistoryImportPeer : ITLObject
	{
		/// <summary>A confirmation text to be shown to the user, upon <a href="https://corefork.telegram.org/api/import">importing chat history »</a>.</summary>
		public string confirm_text;
	}

	/// <summary>A list of peers that can be used to join a group call, presenting yourself as a specific user/channel.		<para>See <a href="https://corefork.telegram.org/constructor/phone.joinAsPeers"/></para></summary>
	[TLDef(0xAFE5623F)]
	public partial class Phone_JoinAsPeers : ITLObject
	{
		/// <summary>Peers</summary>
		public Peer[] peers;
		/// <summary>Chats mentioned in the peers vector</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users mentioned in the peers vector</summary>
		public Dictionary<long, UserBase> users;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	/// <summary>An invite to a group call or livestream		<para>See <a href="https://corefork.telegram.org/constructor/phone.exportedGroupCallInvite"/></para></summary>
	[TLDef(0x204BD158)]
	public partial class Phone_ExportedGroupCallInvite : ITLObject
	{
		/// <summary>Invite link</summary>
		public string link;
	}

	/// <summary>Describes a group of video synchronization source identifiers		<para>See <a href="https://corefork.telegram.org/constructor/groupCallParticipantVideoSourceGroup"/></para></summary>
	[TLDef(0xDCB118B7)]
	public partial class GroupCallParticipantVideoSourceGroup : ITLObject
	{
		/// <summary>SDP semantics</summary>
		public string semantics;
		/// <summary>Source IDs</summary>
		public int[] sources;
	}

	/// <summary>Info about a video stream		<para>See <a href="https://corefork.telegram.org/constructor/groupCallParticipantVideo"/></para></summary>
	[TLDef(0x67753AC8)]
	public partial class GroupCallParticipantVideo : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Endpoint</summary>
		public string endpoint;
		/// <summary>Source groups</summary>
		public GroupCallParticipantVideoSourceGroup[] source_groups;
		/// <summary>Audio source ID</summary>
		[IfFlag(1)] public int audio_source;

		[Flags] public enum Flags
		{
			/// <summary>Whether the stream is currently paused</summary>
			paused = 0x1,
			/// <summary>Field <see cref="audio_source"/> has a value</summary>
			has_audio_source = 0x2,
		}
	}

	/// <summary>A suggested short name for a stickerpack		<para>See <a href="https://corefork.telegram.org/constructor/stickers.suggestedShortName"/></para></summary>
	[TLDef(0x85FEA03F)]
	public partial class Stickers_SuggestedShortName : ITLObject
	{
		/// <summary>Suggested short name</summary>
		public string short_name;
	}

	/// <summary>Represents a scope where the bot commands, specified using <a href="https://corefork.telegram.org/method/bots.setBotCommands">bots.setBotCommands</a> will be valid.		<para>Derived classes: <see cref="BotCommandScopeDefault"/>, <see cref="BotCommandScopeUsers"/>, <see cref="BotCommandScopeChats"/>, <see cref="BotCommandScopeChatAdmins"/>, <see cref="BotCommandScopePeer"/>, <see cref="BotCommandScopePeerAdmins"/>, <see cref="BotCommandScopePeerUser"/></para>		<para>See <a href="https://corefork.telegram.org/type/BotCommandScope"/></para></summary>
	public abstract partial class BotCommandScope : ITLObject { }
	/// <summary>The commands will be valid in all dialogs		<para>See <a href="https://corefork.telegram.org/constructor/botCommandScopeDefault"/></para></summary>
	[TLDef(0x2F6CB2AB)]
	public partial class BotCommandScopeDefault : BotCommandScope { }
	/// <summary>The specified bot commands will only be valid in all private chats with users.		<para>See <a href="https://corefork.telegram.org/constructor/botCommandScopeUsers"/></para></summary>
	[TLDef(0x3C4F04D8)]
	public partial class BotCommandScopeUsers : BotCommandScope { }
	/// <summary>The specified bot commands will be valid in all <a href="https://corefork.telegram.org/api/channel">groups and supergroups</a>.		<para>See <a href="https://corefork.telegram.org/constructor/botCommandScopeChats"/></para></summary>
	[TLDef(0x6FE1A881)]
	public partial class BotCommandScopeChats : BotCommandScope { }
	/// <summary>The specified bot commands will be valid only for chat administrators, in all <a href="https://corefork.telegram.org/api/channel">groups and supergroups</a>.		<para>See <a href="https://corefork.telegram.org/constructor/botCommandScopeChatAdmins"/></para></summary>
	[TLDef(0xB9AA606A)]
	public partial class BotCommandScopeChatAdmins : BotCommandScope { }
	/// <summary>The specified bot commands will be valid only in a specific dialog.		<para>See <a href="https://corefork.telegram.org/constructor/botCommandScopePeer"/></para></summary>
	[TLDef(0xDB9D897D)]
	public partial class BotCommandScopePeer : BotCommandScope
	{
		/// <summary>The dialog</summary>
		public InputPeer peer;
	}
	/// <summary>The specified bot commands will be valid for all admins of the specified <a href="https://corefork.telegram.org/api/channel">group or supergroup</a>.		<para>See <a href="https://corefork.telegram.org/constructor/botCommandScopePeerAdmins"/></para></summary>
	[TLDef(0x3FD863D1)]
	public partial class BotCommandScopePeerAdmins : BotCommandScopePeer { }
	/// <summary>The specified bot commands will be valid only for a specific user in the specified <a href="https://corefork.telegram.org/api/channel">group or supergroup</a>.		<para>See <a href="https://corefork.telegram.org/constructor/botCommandScopePeerUser"/></para></summary>
	[TLDef(0x0A1321F3)]
	public partial class BotCommandScopePeerUser : BotCommandScopePeer
	{
		/// <summary>The user</summary>
		public InputUserBase user_id;
	}

	/// <summary>Result of an <a href="https://corefork.telegram.org/method/account.resetPassword">account.resetPassword</a> request.		<para>Derived classes: <see cref="Account_ResetPasswordFailedWait"/>, <see cref="Account_ResetPasswordRequestedWait"/>, <see cref="Account_ResetPasswordOk"/></para>		<para>See <a href="https://corefork.telegram.org/type/account.ResetPasswordResult"/></para></summary>
	public abstract partial class Account_ResetPasswordResult : ITLObject { }
	/// <summary>You recently requested a password reset that was canceled, please wait until the specified date before requesting another reset.		<para>See <a href="https://corefork.telegram.org/constructor/account.resetPasswordFailedWait"/></para></summary>
	[TLDef(0xE3779861)]
	public partial class Account_ResetPasswordFailedWait : Account_ResetPasswordResult
	{
		/// <summary>Wait until this date before requesting another reset.</summary>
		public DateTime retry_date;
	}
	/// <summary>You successfully requested a password reset, please wait until the specified date before finalizing the reset.		<para>See <a href="https://corefork.telegram.org/constructor/account.resetPasswordRequestedWait"/></para></summary>
	[TLDef(0xE9EFFC7D)]
	public partial class Account_ResetPasswordRequestedWait : Account_ResetPasswordResult
	{
		/// <summary>Wait until this date before finalizing the reset.</summary>
		public DateTime until_date;
	}
	/// <summary>The 2FA password was reset successfully.		<para>See <a href="https://corefork.telegram.org/constructor/account.resetPasswordOk"/></para></summary>
	[TLDef(0xE926D63E)]
	public partial class Account_ResetPasswordOk : Account_ResetPasswordResult { }

	/// <summary>A sponsored message		<para>See <a href="https://corefork.telegram.org/constructor/sponsoredMessage"/></para></summary>
	[TLDef(0xD151E19A)]
	public partial class SponsoredMessage : ITLObject
	{
		/// <summary>Flags, see <a href="https://corefork.telegram.org/mtproto/TL-combinators#conditional-fields">TL conditional fields</a></summary>
		public Flags flags;
		/// <summary>Message ID</summary>
		public byte[] random_id;
		/// <summary>ID of the sender of the message</summary>
		public Peer from_id;
		[IfFlag(2)] public int channel_post;
		/// <summary>Parameter for the bot start message if the sponsored chat is a chat with a bot.</summary>
		[IfFlag(0)] public string start_param;
		/// <summary>Sponsored message</summary>
		public string message;
		/// <summary><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></summary>
		[IfFlag(1)] public MessageEntity[] entities;

		[Flags] public enum Flags
		{
			/// <summary>Field <see cref="start_param"/> has a value</summary>
			has_start_param = 0x1,
			/// <summary>Field <see cref="entities"/> has a value</summary>
			has_entities = 0x2,
			/// <summary>Field <see cref="channel_post"/> has a value</summary>
			has_channel_post = 0x4,
		}
	}

	/// <summary>A set of sponsored messages associated to a channel		<para>See <a href="https://corefork.telegram.org/constructor/messages.sponsoredMessages"/></para></summary>
	[TLDef(0x65A4C7D5)]
	public partial class Messages_SponsoredMessages : ITLObject
	{
		/// <summary>Sponsored messages</summary>
		public SponsoredMessage[] messages;
		/// <summary>Chats mentioned in the sponsored messages</summary>
		public Dictionary<long, ChatBase> chats;
		/// <summary>Users mentioned in the sponsored messages</summary>
		public Dictionary<long, UserBase> users;
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/searchResultsCalendarPeriod"/></para></summary>
	[TLDef(0xC9B0539F)]
	public partial class SearchResultsCalendarPeriod : ITLObject
	{
		public DateTime date;
		public int min_msg_id;
		public int max_msg_id;
		public int count;
	}

	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/messages.searchResultsCalendar"/></para></summary>
	[TLDef(0x147EE23C)]
	public partial class Messages_SearchResultsCalendar : ITLObject
	{
		public Flags flags;
		public int count;
		public DateTime min_date;
		public int min_msg_id;
		[IfFlag(1)] public int offset_id_offset;
		public SearchResultsCalendarPeriod[] periods;
		public MessageBase[] messages;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;

		[Flags] public enum Flags
		{
			inexact = 0x1,
			/// <summary>Field <see cref="offset_id_offset"/> has a value</summary>
			has_offset_id_offset = 0x2,
		}
		/// <summary>returns a <see cref="UserBase"/> or <see cref="ChatBase"/> for the given Peer</summary>
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	/// <summary><para>See <a href="https://corefork.telegram.org/type/SearchResultsPosition"/></para></summary>
	public abstract partial class SearchResultsPosition : ITLObject { }
	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/searchResultPosition"/></para></summary>
	[TLDef(0x7F648B67)]
	public partial class SearchResultPosition : SearchResultsPosition
	{
		public int msg_id;
		public DateTime date;
		public int offset;
	}

	/// <summary><para>See <a href="https://corefork.telegram.org/constructor/messages.searchResultsPositions"/></para></summary>
	[TLDef(0x53B22BAF)]
	public partial class Messages_SearchResultsPositions : ITLObject
	{
		public int count;
		public SearchResultsPosition[] positions;
	}

	// ---functions---

	public static class Schema
	{
		/// <summary>Invokes a query after successfull completion of one of the previous queries.		<para>See <a href="https://corefork.telegram.org/method/invokeAfterMsg"/></para></summary>
		/// <param name="msg_id">Message identifier on which a current query depends</param>
		/// <param name="query">The query itself</param>
		public static Task<X> InvokeAfterMsg<X>(this Client client, long msg_id, ITLFunction query)
			=> client.CallAsync<X>(writer =>
			{
				writer.Write(0xCB9F372D);
				writer.Write(msg_id);
				query(writer);
				return "InvokeAfterMsg<X>";
			});

		/// <summary>Invokes a query after a successfull completion of previous queries		<para>See <a href="https://corefork.telegram.org/method/invokeAfterMsgs"/></para></summary>
		/// <param name="msg_ids">List of messages on which a current query depends</param>
		/// <param name="query">The query itself</param>
		public static Task<X> InvokeAfterMsgs<X>(this Client client, long[] msg_ids, ITLFunction query)
			=> client.CallAsync<X>(writer =>
			{
				writer.Write(0x3DC4B4F0);
				writer.WriteTLVector(msg_ids);
				query(writer);
				return "InvokeAfterMsgs<X>";
			});

		/// <summary>Initialize connection		<para>See <a href="https://corefork.telegram.org/method/initConnection"/></para></summary>
		/// <param name="api_id">Application identifier (see. <a href="https://corefork.telegram.org/myapp">App configuration</a>)</param>
		/// <param name="device_model">Device model</param>
		/// <param name="system_version">Operation system version</param>
		/// <param name="app_version">Application version</param>
		/// <param name="system_lang_code">Code for the language used on the device's OS, ISO 639-1 standard</param>
		/// <param name="lang_pack">Language pack to use</param>
		/// <param name="lang_code">Code for the language used on the client, ISO 639-1 standard</param>
		/// <param name="proxy">Info about an MTProto proxy</param>
		/// <param name="params_">Additional initConnection parameters. <br/>For now, only the <c>tz_offset</c> field is supported, for specifying timezone offset in seconds.</param>
		/// <param name="query">The query itself</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/initConnection#possible-errors">details</a>)</exception>
		public static ITLFunction InitConnection(int api_id, string device_model, string system_version, string app_version, string system_lang_code, string lang_pack, string lang_code, ITLFunction query, InputClientProxy proxy = null, JSONValue params_ = null)
			=> writer =>
			{
				writer.Write(0xC1CD5EA9);
				writer.Write((proxy != null ? 0x1 : 0) | (params_ != null ? 0x2 : 0));
				writer.Write(api_id);
				writer.WriteTLString(device_model);
				writer.WriteTLString(system_version);
				writer.WriteTLString(app_version);
				writer.WriteTLString(system_lang_code);
				writer.WriteTLString(lang_pack);
				writer.WriteTLString(lang_code);
				if (proxy != null)
					writer.WriteTLObject(proxy);
				if (params_ != null)
					writer.WriteTLObject(params_);
				query(writer);
				return "InitConnection";
			};

		/// <summary>Invoke the specified query using the specified API <a href="https://corefork.telegram.org/api/invoking#layers">layer</a>		<para>See <a href="https://corefork.telegram.org/method/invokeWithLayer"/></para></summary>
		/// <param name="layer">The layer to use</param>
		/// <param name="query">The query</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/invokeWithLayer#possible-errors">details</a>)</exception>
		public static Task<X> InvokeWithLayer<X>(this Client client, int layer, ITLFunction query)
			=> client.CallAsync<X>(writer =>
			{
				writer.Write(0xDA9B0D0D);
				writer.Write(layer);
				query(writer);
				return "InvokeWithLayer<X>";
			});

		/// <summary>Invoke a request without subscribing the used connection for <a href="https://corefork.telegram.org/api/updates">updates</a> (this is enabled by default for <a href="https://corefork.telegram.org/api/files">file queries</a>).		<para>See <a href="https://corefork.telegram.org/method/invokeWithoutUpdates"/></para></summary>
		/// <param name="query">The query</param>
		public static Task<X> InvokeWithoutUpdates<X>(this Client client, ITLFunction query)
			=> client.CallAsync<X>(writer =>
			{
				writer.Write(0xBF9459B7);
				query(writer);
				return "InvokeWithoutUpdates<X>";
			});

		/// <summary>Invoke with the given message range		<para>See <a href="https://corefork.telegram.org/method/invokeWithMessagesRange"/></para></summary>
		/// <param name="range">Message range</param>
		/// <param name="query">Query</param>
		public static Task<X> InvokeWithMessagesRange<X>(this Client client, MessageRange range, ITLFunction query)
			=> client.CallAsync<X>(writer =>
			{
				writer.Write(0x365275F2);
				writer.WriteTLObject(range);
				query(writer);
				return "InvokeWithMessagesRange<X>";
			});

		/// <summary>Invoke a method within a takeout session		<para>See <a href="https://corefork.telegram.org/method/invokeWithTakeout"/></para></summary>
		/// <param name="takeout_id">Takeout session ID</param>
		/// <param name="query">Query</param>
		public static Task<X> InvokeWithTakeout<X>(this Client client, long takeout_id, ITLFunction query)
			=> client.CallAsync<X>(writer =>
			{
				writer.Write(0xACA9FD2E);
				writer.Write(takeout_id);
				query(writer);
				return "InvokeWithTakeout<X>";
			});

		/// <summary>Send the verification code for login		<para>See <a href="https://corefork.telegram.org/method/auth.sendCode"/></para></summary>
		/// <param name="phone_number">Phone number in international format</param>
		/// <param name="api_id">Application identifier (see <a href="https://corefork.telegram.org/myapp">App configuration</a>)</param>
		/// <param name="api_hash">Application secret hash (see <a href="https://corefork.telegram.org/myapp">App configuration</a>)</param>
		/// <param name="settings">Settings for the code type to send</param>
		/// <exception cref="RpcException">Possible errors: 303,400,401,406 (<a href="https://corefork.telegram.org/method/auth.sendCode#possible-errors">details</a>)</exception>
		public static Task<Auth_SentCode> Auth_SendCode(this Client client, string phone_number, int api_id, string api_hash, CodeSettings settings)
			=> client.CallAsync<Auth_SentCode>(writer =>
			{
				writer.Write(0xA677244F);
				writer.WriteTLString(phone_number);
				writer.Write(api_id);
				writer.WriteTLString(api_hash);
				writer.WriteTLObject(settings);
				return "Auth_SendCode";
			});

		/// <summary>Registers a validated phone number in the system.		<para>See <a href="https://corefork.telegram.org/method/auth.signUp"/></para></summary>
		/// <param name="phone_number">Phone number in the international format</param>
		/// <param name="phone_code_hash">SMS-message ID</param>
		/// <param name="first_name">New user first name</param>
		/// <param name="last_name">New user last name</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/auth.signUp#possible-errors">details</a>)</exception>
		public static Task<Auth_AuthorizationBase> Auth_SignUp(this Client client, string phone_number, string phone_code_hash, string first_name, string last_name)
			=> client.CallAsync<Auth_AuthorizationBase>(writer =>
			{
				writer.Write(0x80EEE427);
				writer.WriteTLString(phone_number);
				writer.WriteTLString(phone_code_hash);
				writer.WriteTLString(first_name);
				writer.WriteTLString(last_name);
				return "Auth_SignUp";
			});

		/// <summary>Signs in a user with a validated phone number.		<para>See <a href="https://corefork.telegram.org/method/auth.signIn"/></para></summary>
		/// <param name="phone_number">Phone number in the international format</param>
		/// <param name="phone_code_hash">SMS-message ID, obtained from <a href="https://corefork.telegram.org/method/auth.sendCode">auth.sendCode</a></param>
		/// <param name="phone_code">Valid numerical code from the SMS-message</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/auth.signIn#possible-errors">details</a>)</exception>
		public static Task<Auth_AuthorizationBase> Auth_SignIn(this Client client, string phone_number, string phone_code_hash, string phone_code)
			=> client.CallAsync<Auth_AuthorizationBase>(writer =>
			{
				writer.Write(0xBCD51581);
				writer.WriteTLString(phone_number);
				writer.WriteTLString(phone_code_hash);
				writer.WriteTLString(phone_code);
				return "Auth_SignIn";
			});

		/// <summary>Logs out the user.		<para>See <a href="https://corefork.telegram.org/method/auth.logOut"/></para></summary>
		public static Task<bool> Auth_LogOut(this Client client)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x5717DA40);
				return "Auth_LogOut";
			});

		/// <summary>Terminates all user's authorized sessions except for the current one.		<para>See <a href="https://corefork.telegram.org/method/auth.resetAuthorizations"/></para></summary>
		/// <exception cref="RpcException">Possible errors: 406 (<a href="https://corefork.telegram.org/method/auth.resetAuthorizations#possible-errors">details</a>)</exception>
		public static Task<bool> Auth_ResetAuthorizations(this Client client)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x9FAB0D1A);
				return "Auth_ResetAuthorizations";
			});

		/// <summary>Returns data for copying authorization to another data-centre.		<para>See <a href="https://corefork.telegram.org/method/auth.exportAuthorization"/></para></summary>
		/// <param name="dc_id">Number of a target data-centre</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/auth.exportAuthorization#possible-errors">details</a>)</exception>
		public static Task<Auth_ExportedAuthorization> Auth_ExportAuthorization(this Client client, int dc_id)
			=> client.CallAsync<Auth_ExportedAuthorization>(writer =>
			{
				writer.Write(0xE5BFFFCD);
				writer.Write(dc_id);
				return "Auth_ExportAuthorization";
			});

		/// <summary>Logs in a user using a key transmitted from his native data-centre.		<para>See <a href="https://corefork.telegram.org/method/auth.importAuthorization"/></para></summary>
		/// <param name="id">User ID</param>
		/// <param name="bytes">Authorization key</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/auth.importAuthorization#possible-errors">details</a>)</exception>
		public static Task<Auth_AuthorizationBase> Auth_ImportAuthorization(this Client client, long id, byte[] bytes)
			=> client.CallAsync<Auth_AuthorizationBase>(writer =>
			{
				writer.Write(0xA57A7DAD);
				writer.Write(id);
				writer.WriteTLBytes(bytes);
				return "Auth_ImportAuthorization";
			});

		/// <summary>Binds a temporary authorization key <c>temp_auth_key_id</c> to the permanent authorization key <c>perm_auth_key_id</c>. Each permanent key may only be bound to one temporary key at a time, binding a new temporary key overwrites the previous one.		<para>See <a href="https://corefork.telegram.org/method/auth.bindTempAuthKey"/></para></summary>
		/// <param name="perm_auth_key_id">Permanent auth_key_id to bind to</param>
		/// <param name="nonce">Random long from <a href="#binding-message-contents">Binding message contents</a></param>
		/// <param name="expires_at">Unix timestamp to invalidate temporary key, see <a href="#binding-message-contents">Binding message contents</a></param>
		/// <param name="encrypted_message">See <a href="#generating-encrypted-message">Generating encrypted_message</a></param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/auth.bindTempAuthKey#possible-errors">details</a>)</exception>
		public static Task<bool> Auth_BindTempAuthKey(this Client client, long perm_auth_key_id, long nonce, DateTime expires_at, byte[] encrypted_message)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xCDD42A05);
				writer.Write(perm_auth_key_id);
				writer.Write(nonce);
				writer.WriteTLStamp(expires_at);
				writer.WriteTLBytes(encrypted_message);
				return "Auth_BindTempAuthKey";
			});

		/// <summary>Login as a bot		<para>See <a href="https://corefork.telegram.org/method/auth.importBotAuthorization"/></para></summary>
		/// <param name="api_id">Application identifier (see. <a href="https://corefork.telegram.org/myapp">App configuration</a>)</param>
		/// <param name="api_hash">Application identifier hash (see. <a href="https://corefork.telegram.org/myapp">App configuration</a>)</param>
		/// <param name="bot_auth_token">Bot token (see <a href="https://corefork.telegram.org/bots">bots</a>)</param>
		/// <exception cref="RpcException">Possible errors: 400,401 (<a href="https://corefork.telegram.org/method/auth.importBotAuthorization#possible-errors">details</a>)</exception>
		public static Task<Auth_AuthorizationBase> Auth_ImportBotAuthorization(this Client client, int flags, int api_id, string api_hash, string bot_auth_token)
			=> client.CallAsync<Auth_AuthorizationBase>(writer =>
			{
				writer.Write(0x67A3FF2C);
				writer.Write(flags);
				writer.Write(api_id);
				writer.WriteTLString(api_hash);
				writer.WriteTLString(bot_auth_token);
				return "Auth_ImportBotAuthorization";
			});

		/// <summary>Try logging to an account protected by a <a href="https://corefork.telegram.org/api/srp">2FA password</a>.		<para>See <a href="https://corefork.telegram.org/method/auth.checkPassword"/></para></summary>
		/// <param name="password">The account's password (see <a href="https://corefork.telegram.org/api/srp">SRP</a>)</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/auth.checkPassword#possible-errors">details</a>)</exception>
		public static Task<Auth_AuthorizationBase> Auth_CheckPassword(this Client client, InputCheckPasswordSRP password)
			=> client.CallAsync<Auth_AuthorizationBase>(writer =>
			{
				writer.Write(0xD18B4D16);
				writer.WriteTLObject(password);
				return "Auth_CheckPassword";
			});

		/// <summary>Request recovery code of a <a href="https://corefork.telegram.org/api/srp">2FA password</a>, only for accounts with a <a href="https://corefork.telegram.org/api/srp#email-verification">recovery email configured</a>.		<para>See <a href="https://corefork.telegram.org/method/auth.requestPasswordRecovery"/></para></summary>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/auth.requestPasswordRecovery#possible-errors">details</a>)</exception>
		public static Task<Auth_PasswordRecovery> Auth_RequestPasswordRecovery(this Client client)
			=> client.CallAsync<Auth_PasswordRecovery>(writer =>
			{
				writer.Write(0xD897BC66);
				return "Auth_RequestPasswordRecovery";
			});

		/// <summary>Reset the <a href="https://corefork.telegram.org/api/srp">2FA password</a> using the recovery code sent using <a href="https://corefork.telegram.org/method/auth.requestPasswordRecovery">auth.requestPasswordRecovery</a>.		<para>See <a href="https://corefork.telegram.org/method/auth.recoverPassword"/></para></summary>
		/// <param name="code">Code received via email</param>
		/// <param name="new_settings">New password</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/auth.recoverPassword#possible-errors">details</a>)</exception>
		public static Task<Auth_AuthorizationBase> Auth_RecoverPassword(this Client client, string code, Account_PasswordInputSettings new_settings = null)
			=> client.CallAsync<Auth_AuthorizationBase>(writer =>
			{
				writer.Write(0x37096C70);
				writer.Write(new_settings != null ? 0x1 : 0);
				writer.WriteTLString(code);
				if (new_settings != null)
					writer.WriteTLObject(new_settings);
				return "Auth_RecoverPassword";
			});

		/// <summary>Resend the login code via another medium, the phone code type is determined by the return value of the previous auth.sendCode/auth.resendCode: see <a href="https://corefork.telegram.org/api/auth">login</a> for more info.		<para>See <a href="https://corefork.telegram.org/method/auth.resendCode"/></para></summary>
		/// <param name="phone_number">The phone number</param>
		/// <param name="phone_code_hash">The phone code hash obtained from <a href="https://corefork.telegram.org/method/auth.sendCode">auth.sendCode</a></param>
		/// <exception cref="RpcException">Possible errors: 400,406 (<a href="https://corefork.telegram.org/method/auth.resendCode#possible-errors">details</a>)</exception>
		public static Task<Auth_SentCode> Auth_ResendCode(this Client client, string phone_number, string phone_code_hash)
			=> client.CallAsync<Auth_SentCode>(writer =>
			{
				writer.Write(0x3EF1A9BF);
				writer.WriteTLString(phone_number);
				writer.WriteTLString(phone_code_hash);
				return "Auth_ResendCode";
			});

		/// <summary>Cancel the login verification code		<para>See <a href="https://corefork.telegram.org/method/auth.cancelCode"/></para></summary>
		/// <param name="phone_number">Phone number</param>
		/// <param name="phone_code_hash">Phone code hash from <a href="https://corefork.telegram.org/method/auth.sendCode">auth.sendCode</a></param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/auth.cancelCode#possible-errors">details</a>)</exception>
		public static Task<bool> Auth_CancelCode(this Client client, string phone_number, string phone_code_hash)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x1F040578);
				writer.WriteTLString(phone_number);
				writer.WriteTLString(phone_code_hash);
				return "Auth_CancelCode";
			});

		/// <summary>Delete all temporary authorization keys <strong>except for</strong> the ones specified		<para>See <a href="https://corefork.telegram.org/method/auth.dropTempAuthKeys"/></para></summary>
		/// <param name="except_auth_keys">The auth keys that <strong>shouldn't</strong> be dropped.</param>
		public static Task<bool> Auth_DropTempAuthKeys(this Client client, long[] except_auth_keys)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x8E48A188);
				writer.WriteTLVector(except_auth_keys);
				return "Auth_DropTempAuthKeys";
			});

		/// <summary>Generate a login token, for <a href="https://corefork.telegram.org/api/qr-login">login via QR code</a>.<br/>The generated login token should be encoded using base64url, then shown as a <c>tg://login?token=base64encodedtoken</c> URL in the QR code.		<para>See <a href="https://corefork.telegram.org/method/auth.exportLoginToken"/></para></summary>
		/// <param name="api_id">Application identifier (see. <a href="https://corefork.telegram.org/myapp">App configuration</a>)</param>
		/// <param name="api_hash">Application identifier hash (see. <a href="https://corefork.telegram.org/myapp">App configuration</a>)</param>
		/// <param name="except_ids">List of already logged-in user IDs, to prevent logging in twice with the same user</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/auth.exportLoginToken#possible-errors">details</a>)</exception>
		public static Task<Auth_LoginTokenBase> Auth_ExportLoginToken(this Client client, int api_id, string api_hash, long[] except_ids)
			=> client.CallAsync<Auth_LoginTokenBase>(writer =>
			{
				writer.Write(0xB7E085FE);
				writer.Write(api_id);
				writer.WriteTLString(api_hash);
				writer.WriteTLVector(except_ids);
				return "Auth_ExportLoginToken";
			});

		/// <summary>Login using a redirected login token, generated in case of DC mismatch during <a href="https://corefork.telegram.org/api/qr-login">QR code login</a>.		<para>See <a href="https://corefork.telegram.org/method/auth.importLoginToken"/></para></summary>
		/// <param name="token">Login token</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/auth.importLoginToken#possible-errors">details</a>)</exception>
		public static Task<Auth_LoginTokenBase> Auth_ImportLoginToken(this Client client, byte[] token)
			=> client.CallAsync<Auth_LoginTokenBase>(writer =>
			{
				writer.Write(0x95AC5CE4);
				writer.WriteTLBytes(token);
				return "Auth_ImportLoginToken";
			});

		/// <summary>Accept QR code login token, logging in the app that generated it.		<para>See <a href="https://corefork.telegram.org/method/auth.acceptLoginToken"/></para></summary>
		/// <param name="token">Login token embedded in QR code, for more info, see <a href="https://corefork.telegram.org/api/qr-login">login via QR code</a>.</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/auth.acceptLoginToken#possible-errors">details</a>)</exception>
		public static Task<Authorization> Auth_AcceptLoginToken(this Client client, byte[] token)
			=> client.CallAsync<Authorization>(writer =>
			{
				writer.Write(0xE894AD4D);
				writer.WriteTLBytes(token);
				return "Auth_AcceptLoginToken";
			});

		/// <summary>Check if the <a href="https://corefork.telegram.org/api/srp">2FA recovery code</a> sent using <a href="https://corefork.telegram.org/method/auth.requestPasswordRecovery">auth.requestPasswordRecovery</a> is valid, before passing it to <a href="https://corefork.telegram.org/method/auth.recoverPassword">auth.recoverPassword</a>.		<para>See <a href="https://corefork.telegram.org/method/auth.checkRecoveryPassword"/></para></summary>
		/// <param name="code">Code received via email</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/auth.checkRecoveryPassword#possible-errors">details</a>)</exception>
		public static Task<bool> Auth_CheckRecoveryPassword(this Client client, string code)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x0D36BF79);
				writer.WriteTLString(code);
				return "Auth_CheckRecoveryPassword";
			});

		/// <summary>Register device to receive <a href="https://corefork.telegram.org/api/push-updates">PUSH notifications</a>		<para>See <a href="https://corefork.telegram.org/method/account.registerDevice"/></para></summary>
		/// <param name="no_muted">Avoid receiving (silent and invisible background) notifications. Useful to save battery.</param>
		/// <param name="token_type">Device token type.<br/><strong>Possible values</strong>:<br/><c>1</c> - APNS (device token for apple push)<br/><c>2</c> - FCM (firebase token for google firebase)<br/><c>3</c> - MPNS (channel URI for microsoft push)<br/><c>4</c> - Simple push (endpoint for firefox's simple push API)<br/><c>5</c> - Ubuntu phone (token for ubuntu push)<br/><c>6</c> - Blackberry (token for blackberry push)<br/><c>7</c> - Unused<br/><c>8</c> - WNS (windows push)<br/><c>9</c> - APNS VoIP (token for apple push VoIP)<br/><c>10</c> - Web push (web push, see below)<br/><c>11</c> - MPNS VoIP (token for microsoft push VoIP)<br/><c>12</c> - Tizen (token for tizen push)<br/><br/>For <c>10</c> web push, the token must be a JSON-encoded object containing the keys described in <a href="https://corefork.telegram.org/api/push-updates">PUSH updates</a></param>
		/// <param name="token">Device token</param>
		/// <param name="app_sandbox">If <see cref="Bool.True"/> is transmitted, a sandbox-certificate will be used during transmission.</param>
		/// <param name="secret">For FCM and APNS VoIP, optional encryption key used to encrypt push notifications</param>
		/// <param name="other_uids">List of user identifiers of other users currently using the client</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.registerDevice#possible-errors">details</a>)</exception>
		public static Task<bool> Account_RegisterDevice(this Client client, int token_type, string token, bool app_sandbox, byte[] secret, long[] other_uids, bool no_muted = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xEC86017A);
				writer.Write(no_muted ? 0x1 : 0);
				writer.Write(token_type);
				writer.WriteTLString(token);
				writer.Write(app_sandbox ? 0x997275B5 : 0xBC799737);
				writer.WriteTLBytes(secret);
				writer.WriteTLVector(other_uids);
				return "Account_RegisterDevice";
			});

		/// <summary>Deletes a device by its token, stops sending PUSH-notifications to it.		<para>See <a href="https://corefork.telegram.org/method/account.unregisterDevice"/></para></summary>
		/// <param name="token_type">Device token type.<br/><strong>Possible values</strong>:<br/><c>1</c> - APNS (device token for apple push)<br/><c>2</c> - FCM (firebase token for google firebase)<br/><c>3</c> - MPNS (channel URI for microsoft push)<br/><c>4</c> - Simple push (endpoint for firefox's simple push API)<br/><c>5</c> - Ubuntu phone (token for ubuntu push)<br/><c>6</c> - Blackberry (token for blackberry push)<br/><c>7</c> - Unused<br/><c>8</c> - WNS (windows push)<br/><c>9</c> - APNS VoIP (token for apple push VoIP)<br/><c>10</c> - Web push (web push, see below)<br/><c>11</c> - MPNS VoIP (token for microsoft push VoIP)<br/><c>12</c> - Tizen (token for tizen push)<br/><br/>For <c>10</c> web push, the token must be a JSON-encoded object containing the keys described in <a href="https://corefork.telegram.org/api/push-updates">PUSH updates</a></param>
		/// <param name="token">Device token</param>
		/// <param name="other_uids">List of user identifiers of other users currently using the client</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.unregisterDevice#possible-errors">details</a>)</exception>
		public static Task<bool> Account_UnregisterDevice(this Client client, int token_type, string token, long[] other_uids)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x6A0D3206);
				writer.Write(token_type);
				writer.WriteTLString(token);
				writer.WriteTLVector(other_uids);
				return "Account_UnregisterDevice";
			});

		/// <summary>Edits notification settings from a given user/group, from all users/all groups.		<para>See <a href="https://corefork.telegram.org/method/account.updateNotifySettings"/></para></summary>
		/// <param name="peer">Notification source</param>
		/// <param name="settings">Notification settings</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.updateNotifySettings#possible-errors">details</a>)</exception>
		public static Task<bool> Account_UpdateNotifySettings(this Client client, InputNotifyPeerBase peer, InputPeerNotifySettings settings)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x84BE5B93);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(settings);
				return "Account_UpdateNotifySettings";
			});

		/// <summary>Gets current notification settings for a given user/group, from all users/all groups.		<para>See <a href="https://corefork.telegram.org/method/account.getNotifySettings"/></para></summary>
		/// <param name="peer">Notification source</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.getNotifySettings#possible-errors">details</a>)</exception>
		public static Task<PeerNotifySettings> Account_GetNotifySettings(this Client client, InputNotifyPeerBase peer)
			=> client.CallAsync<PeerNotifySettings>(writer =>
			{
				writer.Write(0x12B3AD31);
				writer.WriteTLObject(peer);
				return "Account_GetNotifySettings";
			});

		/// <summary>Resets all notification settings from users and groups.		<para>See <a href="https://corefork.telegram.org/method/account.resetNotifySettings"/></para></summary>
		public static Task<bool> Account_ResetNotifySettings(this Client client)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xDB7E1747);
				return "Account_ResetNotifySettings";
			});

		/// <summary>Updates user profile.		<para>See <a href="https://corefork.telegram.org/method/account.updateProfile"/></para></summary>
		/// <param name="first_name">New user first name</param>
		/// <param name="last_name">New user last name</param>
		/// <param name="about">New bio</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.updateProfile#possible-errors">details</a>)</exception>
		public static Task<UserBase> Account_UpdateProfile(this Client client, string first_name = null, string last_name = null, string about = null)
			=> client.CallAsync<UserBase>(writer =>
			{
				writer.Write(0x78515775);
				writer.Write((first_name != null ? 0x1 : 0) | (last_name != null ? 0x2 : 0) | (about != null ? 0x4 : 0));
				if (first_name != null)
					writer.WriteTLString(first_name);
				if (last_name != null)
					writer.WriteTLString(last_name);
				if (about != null)
					writer.WriteTLString(about);
				return "Account_UpdateProfile";
			});

		/// <summary>Updates online user status.		<para>See <a href="https://corefork.telegram.org/method/account.updateStatus"/></para></summary>
		/// <param name="offline">If <see cref="Bool.True"/> is transmitted, user status will change to <see cref="UserStatusOffline"/>.</param>
		public static Task<bool> Account_UpdateStatus(this Client client, bool offline)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x6628562C);
				writer.Write(offline ? 0x997275B5 : 0xBC799737);
				return "Account_UpdateStatus";
			});

		/// <summary>Returns a list of available wallpapers.		<para>See <a href="https://corefork.telegram.org/method/account.getWallPapers"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/account.wallPapersNotModified">account.wallPapersNotModified</a></returns>
		public static Task<Account_WallPapers> Account_GetWallPapers(this Client client, long hash)
			=> client.CallAsync<Account_WallPapers>(writer =>
			{
				writer.Write(0x07967D36);
				writer.Write(hash);
				return "Account_GetWallPapers";
			});

		/// <summary>Report a peer for violation of telegram's Terms of Service		<para>See <a href="https://corefork.telegram.org/method/account.reportPeer"/></para></summary>
		/// <param name="peer">The peer to report</param>
		/// <param name="reason">The reason why this peer is being reported</param>
		/// <param name="message">Comment for report moderation</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.reportPeer#possible-errors">details</a>)</exception>
		public static Task<bool> Account_ReportPeer(this Client client, InputPeer peer, ReportReason reason, string message)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xC5BA3D86);
				writer.WriteTLObject(peer);
				writer.Write((uint)reason);
				writer.WriteTLString(message);
				return "Account_ReportPeer";
			});

		/// <summary>Validates a username and checks availability.		<para>See <a href="https://corefork.telegram.org/method/account.checkUsername"/></para></summary>
		/// <param name="username">username<br/>Accepted characters: A-z (case-insensitive), 0-9 and underscores.<br/>Length: 5-32 characters.</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.checkUsername#possible-errors">details</a>)</exception>
		public static Task<bool> Account_CheckUsername(this Client client, string username)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x2714D86C);
				writer.WriteTLString(username);
				return "Account_CheckUsername";
			});

		/// <summary>Changes username for the current user.		<para>See <a href="https://corefork.telegram.org/method/account.updateUsername"/></para></summary>
		/// <param name="username">username or empty string if username is to be removed<br/>Accepted characters: a-z (case-insensitive), 0-9 and underscores.<br/>Length: 5-32 characters.</param>
		/// <exception cref="RpcException">Possible errors: 400,401 (<a href="https://corefork.telegram.org/method/account.updateUsername#possible-errors">details</a>)</exception>
		public static Task<UserBase> Account_UpdateUsername(this Client client, string username)
			=> client.CallAsync<UserBase>(writer =>
			{
				writer.Write(0x3E0BDD7C);
				writer.WriteTLString(username);
				return "Account_UpdateUsername";
			});

		/// <summary>Get privacy settings of current account		<para>See <a href="https://corefork.telegram.org/method/account.getPrivacy"/></para></summary>
		/// <param name="key">Peer category whose privacy settings should be fetched</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.getPrivacy#possible-errors">details</a>)</exception>
		public static Task<Account_PrivacyRules> Account_GetPrivacy(this Client client, InputPrivacyKey key)
			=> client.CallAsync<Account_PrivacyRules>(writer =>
			{
				writer.Write(0xDADBC950);
				writer.Write((uint)key);
				return "Account_GetPrivacy";
			});

		/// <summary>Change privacy settings of current account		<para>See <a href="https://corefork.telegram.org/method/account.setPrivacy"/></para></summary>
		/// <param name="key">Peers to which the privacy rules apply</param>
		/// <param name="rules">New privacy rules</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.setPrivacy#possible-errors">details</a>)</exception>
		public static Task<Account_PrivacyRules> Account_SetPrivacy(this Client client, InputPrivacyKey key, InputPrivacyRule[] rules)
			=> client.CallAsync<Account_PrivacyRules>(writer =>
			{
				writer.Write(0xC9F81CE8);
				writer.Write((uint)key);
				writer.WriteTLVector(rules);
				return "Account_SetPrivacy";
			});

		/// <summary>Delete the user's account from the telegram servers. Can be used, for example, to delete the account of a user that provided the login code, but forgot the <a href="https://corefork.telegram.org/api/srp">2FA password and no recovery method is configured</a>.		<para>See <a href="https://corefork.telegram.org/method/account.deleteAccount"/></para></summary>
		/// <param name="reason">Why is the account being deleted, can be empty</param>
		/// <exception cref="RpcException">Possible errors: 420 (<a href="https://corefork.telegram.org/method/account.deleteAccount#possible-errors">details</a>)</exception>
		public static Task<bool> Account_DeleteAccount(this Client client, string reason)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x418D4E0B);
				writer.WriteTLString(reason);
				return "Account_DeleteAccount";
			});

		/// <summary>Get days to live of account		<para>See <a href="https://corefork.telegram.org/method/account.getAccountTTL"/></para></summary>
		public static Task<AccountDaysTTL> Account_GetAccountTTL(this Client client)
			=> client.CallAsync<AccountDaysTTL>(writer =>
			{
				writer.Write(0x08FC711D);
				return "Account_GetAccountTTL";
			});

		/// <summary>Set account self-destruction period		<para>See <a href="https://corefork.telegram.org/method/account.setAccountTTL"/></para></summary>
		/// <param name="ttl">Time to live in days</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.setAccountTTL#possible-errors">details</a>)</exception>
		public static Task<bool> Account_SetAccountTTL(this Client client, AccountDaysTTL ttl)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x2442485E);
				writer.WriteTLObject(ttl);
				return "Account_SetAccountTTL";
			});

		/// <summary>Verify a new phone number to associate to the current account		<para>See <a href="https://corefork.telegram.org/method/account.sendChangePhoneCode"/></para></summary>
		/// <param name="phone_number">New phone number</param>
		/// <param name="settings">Phone code settings</param>
		/// <exception cref="RpcException">Possible errors: 400,406 (<a href="https://corefork.telegram.org/method/account.sendChangePhoneCode#possible-errors">details</a>)</exception>
		public static Task<Auth_SentCode> Account_SendChangePhoneCode(this Client client, string phone_number, CodeSettings settings)
			=> client.CallAsync<Auth_SentCode>(writer =>
			{
				writer.Write(0x82574AE5);
				writer.WriteTLString(phone_number);
				writer.WriteTLObject(settings);
				return "Account_SendChangePhoneCode";
			});

		/// <summary>Change the phone number of the current account		<para>See <a href="https://corefork.telegram.org/method/account.changePhone"/></para></summary>
		/// <param name="phone_number">New phone number</param>
		/// <param name="phone_code_hash">Phone code hash received when calling <a href="https://corefork.telegram.org/method/account.sendChangePhoneCode">account.sendChangePhoneCode</a></param>
		/// <param name="phone_code">Phone code received when calling <a href="https://corefork.telegram.org/method/account.sendChangePhoneCode">account.sendChangePhoneCode</a></param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.changePhone#possible-errors">details</a>)</exception>
		public static Task<UserBase> Account_ChangePhone(this Client client, string phone_number, string phone_code_hash, string phone_code)
			=> client.CallAsync<UserBase>(writer =>
			{
				writer.Write(0x70C32EDB);
				writer.WriteTLString(phone_number);
				writer.WriteTLString(phone_code_hash);
				writer.WriteTLString(phone_code);
				return "Account_ChangePhone";
			});

		/// <summary>When client-side passcode lock feature is enabled, will not show message texts in incoming <a href="https://corefork.telegram.org/api/push-updates">PUSH notifications</a>.		<para>See <a href="https://corefork.telegram.org/method/account.updateDeviceLocked"/></para></summary>
		/// <param name="period">Inactivity period after which to start hiding message texts in <a href="https://corefork.telegram.org/api/push-updates">PUSH notifications</a>.</param>
		public static Task<bool> Account_UpdateDeviceLocked(this Client client, int period)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x38DF3532);
				writer.Write(period);
				return "Account_UpdateDeviceLocked";
			});

		/// <summary>Get logged-in sessions		<para>See <a href="https://corefork.telegram.org/method/account.getAuthorizations"/></para></summary>
		public static Task<Account_Authorizations> Account_GetAuthorizations(this Client client)
			=> client.CallAsync<Account_Authorizations>(writer =>
			{
				writer.Write(0xE320C158);
				return "Account_GetAuthorizations";
			});

		/// <summary>Log out an active <a href="https://corefork.telegram.org/api/auth">authorized session</a> by its hash		<para>See <a href="https://corefork.telegram.org/method/account.resetAuthorization"/></para></summary>
		/// <param name="hash">Session hash</param>
		/// <exception cref="RpcException">Possible errors: 400,406 (<a href="https://corefork.telegram.org/method/account.resetAuthorization#possible-errors">details</a>)</exception>
		public static Task<bool> Account_ResetAuthorization(this Client client, long hash)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xDF77F3BC);
				writer.Write(hash);
				return "Account_ResetAuthorization";
			});

		/// <summary>Obtain configuration for two-factor authorization with password		<para>See <a href="https://corefork.telegram.org/method/account.getPassword"/></para></summary>
		public static Task<Account_Password> Account_GetPassword(this Client client)
			=> client.CallAsync<Account_Password>(writer =>
			{
				writer.Write(0x548A30F5);
				return "Account_GetPassword";
			});

		/// <summary>Get private info associated to the password info (recovery email, telegram <a href="https://corefork.telegram.org/passport">passport</a> info &amp; so on)		<para>See <a href="https://corefork.telegram.org/method/account.getPasswordSettings"/></para></summary>
		/// <param name="password">The password (see <a href="https://corefork.telegram.org/api/srp">SRP</a>)</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.getPasswordSettings#possible-errors">details</a>)</exception>
		public static Task<Account_PasswordSettings> Account_GetPasswordSettings(this Client client, InputCheckPasswordSRP password)
			=> client.CallAsync<Account_PasswordSettings>(writer =>
			{
				writer.Write(0x9CD4EAF9);
				writer.WriteTLObject(password);
				return "Account_GetPasswordSettings";
			});

		/// <summary>Set a new 2FA password		<para>See <a href="https://corefork.telegram.org/method/account.updatePasswordSettings"/></para></summary>
		/// <param name="password">The old password (see <a href="https://corefork.telegram.org/api/srp">SRP</a>)</param>
		/// <param name="new_settings">The new password (see <a href="https://corefork.telegram.org/api/srp">SRP</a>)</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.updatePasswordSettings#possible-errors">details</a>)</exception>
		public static Task<bool> Account_UpdatePasswordSettings(this Client client, InputCheckPasswordSRP password, Account_PasswordInputSettings new_settings)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xA59B102F);
				writer.WriteTLObject(password);
				writer.WriteTLObject(new_settings);
				return "Account_UpdatePasswordSettings";
			});

		/// <summary>Send confirmation code to cancel account deletion, for more info <a href="https://corefork.telegram.org/api/account-deletion">click here »</a>		<para>See <a href="https://corefork.telegram.org/method/account.sendConfirmPhoneCode"/></para></summary>
		/// <param name="hash">The hash from the service notification, for more info <a href="https://corefork.telegram.org/api/account-deletion">click here »</a></param>
		/// <param name="settings">Phone code settings</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.sendConfirmPhoneCode#possible-errors">details</a>)</exception>
		public static Task<Auth_SentCode> Account_SendConfirmPhoneCode(this Client client, string hash, CodeSettings settings)
			=> client.CallAsync<Auth_SentCode>(writer =>
			{
				writer.Write(0x1B3FAA88);
				writer.WriteTLString(hash);
				writer.WriteTLObject(settings);
				return "Account_SendConfirmPhoneCode";
			});

		/// <summary>Confirm a phone number to cancel account deletion, for more info <a href="https://corefork.telegram.org/api/account-deletion">click here »</a>		<para>See <a href="https://corefork.telegram.org/method/account.confirmPhone"/></para></summary>
		/// <param name="phone_code_hash">Phone code hash, for more info <a href="https://corefork.telegram.org/api/account-deletion">click here »</a></param>
		/// <param name="phone_code">SMS code, for more info <a href="https://corefork.telegram.org/api/account-deletion">click here »</a></param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.confirmPhone#possible-errors">details</a>)</exception>
		public static Task<bool> Account_ConfirmPhone(this Client client, string phone_code_hash, string phone_code)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x5F2178C3);
				writer.WriteTLString(phone_code_hash);
				writer.WriteTLString(phone_code);
				return "Account_ConfirmPhone";
			});

		/// <summary>Get temporary payment password		<para>See <a href="https://corefork.telegram.org/method/account.getTmpPassword"/></para></summary>
		/// <param name="password">SRP password parameters</param>
		/// <param name="period">Time during which the temporary password will be valid, in seconds; should be between 60 and 86400</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.getTmpPassword#possible-errors">details</a>)</exception>
		public static Task<Account_TmpPassword> Account_GetTmpPassword(this Client client, InputCheckPasswordSRP password, int period)
			=> client.CallAsync<Account_TmpPassword>(writer =>
			{
				writer.Write(0x449E0B51);
				writer.WriteTLObject(password);
				writer.Write(period);
				return "Account_GetTmpPassword";
			});

		/// <summary>Get web <a href="https://corefork.telegram.org/widgets/login">login widget</a> authorizations		<para>See <a href="https://corefork.telegram.org/method/account.getWebAuthorizations"/></para></summary>
		public static Task<Account_WebAuthorizations> Account_GetWebAuthorizations(this Client client)
			=> client.CallAsync<Account_WebAuthorizations>(writer =>
			{
				writer.Write(0x182E6D6F);
				return "Account_GetWebAuthorizations";
			});

		/// <summary>Log out an active web <a href="https://corefork.telegram.org/widgets/login">telegram login</a> session		<para>See <a href="https://corefork.telegram.org/method/account.resetWebAuthorization"/></para></summary>
		/// <param name="hash"><see cref="WebAuthorization"/> hash</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.resetWebAuthorization#possible-errors">details</a>)</exception>
		public static Task<bool> Account_ResetWebAuthorization(this Client client, long hash)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x2D01B9EF);
				writer.Write(hash);
				return "Account_ResetWebAuthorization";
			});

		/// <summary>Reset all active web <a href="https://corefork.telegram.org/widgets/login">telegram login</a> sessions		<para>See <a href="https://corefork.telegram.org/method/account.resetWebAuthorizations"/></para></summary>
		public static Task<bool> Account_ResetWebAuthorizations(this Client client)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x682D2594);
				return "Account_ResetWebAuthorizations";
			});

		/// <summary>Get all saved <a href="https://corefork.telegram.org/passport">Telegram Passport</a> documents, <a href="https://corefork.telegram.org/passport/encryption#encryption">for more info see the passport docs »</a>		<para>See <a href="https://corefork.telegram.org/method/account.getAllSecureValues"/></para></summary>
		public static Task<SecureValue[]> Account_GetAllSecureValues(this Client client)
			=> client.CallAsync<SecureValue[]>(writer =>
			{
				writer.Write(0xB288BC7D);
				return "Account_GetAllSecureValues";
			});

		/// <summary>Get saved <a href="https://corefork.telegram.org/passport">Telegram Passport</a> document, <a href="https://corefork.telegram.org/passport/encryption#encryption">for more info see the passport docs »</a>		<para>See <a href="https://corefork.telegram.org/method/account.getSecureValue"/></para></summary>
		/// <param name="types">Requested value types</param>
		public static Task<SecureValue[]> Account_GetSecureValue(this Client client, SecureValueType[] types)
			=> client.CallAsync<SecureValue[]>(writer =>
			{
				writer.Write(0x73665BC2);
				writer.WriteTLVector(types);
				return "Account_GetSecureValue";
			});

		/// <summary>Securely save <a href="https://corefork.telegram.org/passport">Telegram Passport</a> document, <a href="https://corefork.telegram.org/passport/encryption#encryption">for more info see the passport docs »</a>		<para>See <a href="https://corefork.telegram.org/method/account.saveSecureValue"/></para></summary>
		/// <param name="value">Secure value, <a href="https://corefork.telegram.org/passport/encryption#encryption">for more info see the passport docs »</a></param>
		/// <param name="secure_secret_id">Passport secret hash, <a href="https://corefork.telegram.org/passport/encryption#encryption">for more info see the passport docs »</a></param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.saveSecureValue#possible-errors">details</a>)</exception>
		public static Task<SecureValue> Account_SaveSecureValue(this Client client, InputSecureValue value, long secure_secret_id)
			=> client.CallAsync<SecureValue>(writer =>
			{
				writer.Write(0x899FE31D);
				writer.WriteTLObject(value);
				writer.Write(secure_secret_id);
				return "Account_SaveSecureValue";
			});

		/// <summary>Delete stored <a href="https://corefork.telegram.org/passport">Telegram Passport</a> documents, <a href="https://corefork.telegram.org/passport/encryption#encryption">for more info see the passport docs »</a>		<para>See <a href="https://corefork.telegram.org/method/account.deleteSecureValue"/></para></summary>
		/// <param name="types">Document types to delete</param>
		public static Task<bool> Account_DeleteSecureValue(this Client client, SecureValueType[] types)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xB880BC4B);
				writer.WriteTLVector(types);
				return "Account_DeleteSecureValue";
			});

		/// <summary>Returns a Telegram Passport authorization form for sharing data with a service		<para>See <a href="https://corefork.telegram.org/method/account.getAuthorizationForm"/></para></summary>
		/// <param name="bot_id">User identifier of the service's bot</param>
		/// <param name="scope">Telegram Passport element types requested by the service</param>
		/// <param name="public_key">Service's public key</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.getAuthorizationForm#possible-errors">details</a>)</exception>
		public static Task<Account_AuthorizationForm> Account_GetAuthorizationForm(this Client client, long bot_id, string scope, string public_key)
			=> client.CallAsync<Account_AuthorizationForm>(writer =>
			{
				writer.Write(0xA929597A);
				writer.Write(bot_id);
				writer.WriteTLString(scope);
				writer.WriteTLString(public_key);
				return "Account_GetAuthorizationForm";
			});

		/// <summary>Sends a Telegram Passport authorization form, effectively sharing data with the service		<para>See <a href="https://corefork.telegram.org/method/account.acceptAuthorization"/></para></summary>
		/// <param name="bot_id">Bot ID</param>
		/// <param name="scope">Telegram Passport element types requested by the service</param>
		/// <param name="public_key">Service's public key</param>
		/// <param name="value_hashes">Types of values sent and their hashes</param>
		/// <param name="credentials">Encrypted values</param>
		public static Task<bool> Account_AcceptAuthorization(this Client client, long bot_id, string scope, string public_key, SecureValueHash[] value_hashes, SecureCredentialsEncrypted credentials)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xF3ED4C73);
				writer.Write(bot_id);
				writer.WriteTLString(scope);
				writer.WriteTLString(public_key);
				writer.WriteTLVector(value_hashes);
				writer.WriteTLObject(credentials);
				return "Account_AcceptAuthorization";
			});

		/// <summary>Send the verification phone code for telegram <a href="https://corefork.telegram.org/passport">passport</a>.		<para>See <a href="https://corefork.telegram.org/method/account.sendVerifyPhoneCode"/></para></summary>
		/// <param name="phone_number">The phone number to verify</param>
		/// <param name="settings">Phone code settings</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.sendVerifyPhoneCode#possible-errors">details</a>)</exception>
		public static Task<Auth_SentCode> Account_SendVerifyPhoneCode(this Client client, string phone_number, CodeSettings settings)
			=> client.CallAsync<Auth_SentCode>(writer =>
			{
				writer.Write(0xA5A356F9);
				writer.WriteTLString(phone_number);
				writer.WriteTLObject(settings);
				return "Account_SendVerifyPhoneCode";
			});

		/// <summary>Verify a phone number for telegram <a href="https://corefork.telegram.org/passport">passport</a>.		<para>See <a href="https://corefork.telegram.org/method/account.verifyPhone"/></para></summary>
		/// <param name="phone_number">Phone number</param>
		/// <param name="phone_code_hash">Phone code hash received from the call to <a href="https://corefork.telegram.org/method/account.sendVerifyPhoneCode">account.sendVerifyPhoneCode</a></param>
		/// <param name="phone_code">Code received after the call to <a href="https://corefork.telegram.org/method/account.sendVerifyPhoneCode">account.sendVerifyPhoneCode</a></param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.verifyPhone#possible-errors">details</a>)</exception>
		public static Task<bool> Account_VerifyPhone(this Client client, string phone_number, string phone_code_hash, string phone_code)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x4DD3A7F6);
				writer.WriteTLString(phone_number);
				writer.WriteTLString(phone_code_hash);
				writer.WriteTLString(phone_code);
				return "Account_VerifyPhone";
			});

		/// <summary>Send the verification email code for telegram <a href="https://corefork.telegram.org/passport">passport</a>.		<para>See <a href="https://corefork.telegram.org/method/account.sendVerifyEmailCode"/></para></summary>
		/// <param name="email">The email where to send the code</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.sendVerifyEmailCode#possible-errors">details</a>)</exception>
		public static Task<Account_SentEmailCode> Account_SendVerifyEmailCode(this Client client, string email)
			=> client.CallAsync<Account_SentEmailCode>(writer =>
			{
				writer.Write(0x7011509F);
				writer.WriteTLString(email);
				return "Account_SendVerifyEmailCode";
			});

		/// <summary>Verify an email address for telegram <a href="https://corefork.telegram.org/passport">passport</a>.		<para>See <a href="https://corefork.telegram.org/method/account.verifyEmail"/></para></summary>
		/// <param name="email">The email to verify</param>
		/// <param name="code">The verification code that was received</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.verifyEmail#possible-errors">details</a>)</exception>
		public static Task<bool> Account_VerifyEmail(this Client client, string email, string code)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xECBA39DB);
				writer.WriteTLString(email);
				writer.WriteTLString(code);
				return "Account_VerifyEmail";
			});

		/// <summary>Initialize account takeout session		<para>See <a href="https://corefork.telegram.org/method/account.initTakeoutSession"/></para></summary>
		/// <param name="contacts">Whether to export contacts</param>
		/// <param name="message_users">Whether to export messages in private chats</param>
		/// <param name="message_chats">Whether to export messages in <a href="https://corefork.telegram.org/api/channel">legacy groups</a></param>
		/// <param name="message_megagroups">Whether to export messages in <a href="https://corefork.telegram.org/api/channel">supergroups</a></param>
		/// <param name="message_channels">Whether to export messages in <a href="https://corefork.telegram.org/api/channel">channels</a></param>
		/// <param name="files">Whether to export files</param>
		/// <param name="file_max_size">Maximum size of files to export</param>
		/// <exception cref="RpcException">Possible errors: 420 (<a href="https://corefork.telegram.org/method/account.initTakeoutSession#possible-errors">details</a>)</exception>
		public static Task<Account_Takeout> Account_InitTakeoutSession(this Client client, bool contacts = false, bool message_users = false, bool message_chats = false, bool message_megagroups = false, bool message_channels = false, bool files = false, int? file_max_size = null)
			=> client.CallAsync<Account_Takeout>(writer =>
			{
				writer.Write(0xF05B4804);
				writer.Write((contacts ? 0x1 : 0) | (message_users ? 0x2 : 0) | (message_chats ? 0x4 : 0) | (message_megagroups ? 0x8 : 0) | (message_channels ? 0x10 : 0) | (files ? 0x20 : 0) | (file_max_size != null ? 0x20 : 0));
				if (file_max_size != null)
					writer.Write(file_max_size.Value);
				return "Account_InitTakeoutSession";
			});

		/// <summary>Finish account takeout session		<para>See <a href="https://corefork.telegram.org/method/account.finishTakeoutSession"/></para></summary>
		/// <param name="success">Data exported successfully</param>
		/// <exception cref="RpcException">Possible errors: 403 (<a href="https://corefork.telegram.org/method/account.finishTakeoutSession#possible-errors">details</a>)</exception>
		public static Task<bool> Account_FinishTakeoutSession(this Client client, bool success = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x1D2652EE);
				writer.Write(success ? 0x1 : 0);
				return "Account_FinishTakeoutSession";
			});

		/// <summary>Verify an email to use as <a href="https://corefork.telegram.org/api/srp">2FA recovery method</a>.		<para>See <a href="https://corefork.telegram.org/method/account.confirmPasswordEmail"/></para></summary>
		/// <param name="code">The phone code that was received after <a href="https://corefork.telegram.org/api/srp#email-verification">setting a recovery email</a></param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.confirmPasswordEmail#possible-errors">details</a>)</exception>
		public static Task<bool> Account_ConfirmPasswordEmail(this Client client, string code)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x8FDF1920);
				writer.WriteTLString(code);
				return "Account_ConfirmPasswordEmail";
			});

		/// <summary>Resend the code to verify an email to use as <a href="https://corefork.telegram.org/api/srp">2FA recovery method</a>.		<para>See <a href="https://corefork.telegram.org/method/account.resendPasswordEmail"/></para></summary>
		public static Task<bool> Account_ResendPasswordEmail(this Client client)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x7A7F2A15);
				return "Account_ResendPasswordEmail";
			});

		/// <summary>Cancel the code that was sent to verify an email to use as <a href="https://corefork.telegram.org/api/srp">2FA recovery method</a>.		<para>See <a href="https://corefork.telegram.org/method/account.cancelPasswordEmail"/></para></summary>
		public static Task<bool> Account_CancelPasswordEmail(this Client client)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xC1CBD5B6);
				return "Account_CancelPasswordEmail";
			});

		/// <summary>Whether the user will receive notifications when contacts sign up		<para>See <a href="https://corefork.telegram.org/method/account.getContactSignUpNotification"/></para></summary>
		public static Task<bool> Account_GetContactSignUpNotification(this Client client)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x9F07C728);
				return "Account_GetContactSignUpNotification";
			});

		/// <summary>Toggle contact sign up notifications		<para>See <a href="https://corefork.telegram.org/method/account.setContactSignUpNotification"/></para></summary>
		/// <param name="silent">Whether to disable contact sign up notifications</param>
		public static Task<bool> Account_SetContactSignUpNotification(this Client client, bool silent)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xCFF43F61);
				writer.Write(silent ? 0x997275B5 : 0xBC799737);
				return "Account_SetContactSignUpNotification";
			});

		/// <summary>Returns list of chats with non-default notification settings		<para>See <a href="https://corefork.telegram.org/method/account.getNotifyExceptions"/></para></summary>
		/// <param name="compare_sound">If true, chats with non-default sound will also be returned</param>
		/// <param name="peer">If specified, only chats of the specified category will be returned</param>
		public static Task<UpdatesBase> Account_GetNotifyExceptions(this Client client, bool compare_sound = false, InputNotifyPeerBase peer = null)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x53577479);
				writer.Write((compare_sound ? 0x2 : 0) | (peer != null ? 0x1 : 0));
				if (peer != null)
					writer.WriteTLObject(peer);
				return "Account_GetNotifyExceptions";
			});

		/// <summary>Get info about a certain wallpaper		<para>See <a href="https://corefork.telegram.org/method/account.getWallPaper"/></para></summary>
		/// <param name="wallpaper">The wallpaper to get info about</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.getWallPaper#possible-errors">details</a>)</exception>
		public static Task<WallPaperBase> Account_GetWallPaper(this Client client, InputWallPaperBase wallpaper)
			=> client.CallAsync<WallPaperBase>(writer =>
			{
				writer.Write(0xFC8DDBEA);
				writer.WriteTLObject(wallpaper);
				return "Account_GetWallPaper";
			});

		/// <summary>Create and upload a new wallpaper		<para>See <a href="https://corefork.telegram.org/method/account.uploadWallPaper"/></para></summary>
		/// <param name="file">The JPG/PNG wallpaper</param>
		/// <param name="mime_type">MIME type of uploaded wallpaper</param>
		/// <param name="settings">Wallpaper settings</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.uploadWallPaper#possible-errors">details</a>)</exception>
		public static Task<WallPaperBase> Account_UploadWallPaper(this Client client, InputFileBase file, string mime_type, WallPaperSettings settings)
			=> client.CallAsync<WallPaperBase>(writer =>
			{
				writer.Write(0xDD853661);
				writer.WriteTLObject(file);
				writer.WriteTLString(mime_type);
				writer.WriteTLObject(settings);
				return "Account_UploadWallPaper";
			});

		/// <summary>Install/uninstall wallpaper		<para>See <a href="https://corefork.telegram.org/method/account.saveWallPaper"/></para></summary>
		/// <param name="wallpaper">Wallpaper to save</param>
		/// <param name="unsave">Uninstall wallpaper?</param>
		/// <param name="settings">Wallpaper settings</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.saveWallPaper#possible-errors">details</a>)</exception>
		public static Task<bool> Account_SaveWallPaper(this Client client, InputWallPaperBase wallpaper, bool unsave, WallPaperSettings settings)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x6C5A5B37);
				writer.WriteTLObject(wallpaper);
				writer.Write(unsave ? 0x997275B5 : 0xBC799737);
				writer.WriteTLObject(settings);
				return "Account_SaveWallPaper";
			});

		/// <summary>Install wallpaper		<para>See <a href="https://corefork.telegram.org/method/account.installWallPaper"/></para></summary>
		/// <param name="wallpaper">Wallpaper to install</param>
		/// <param name="settings">Wallpaper settings</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.installWallPaper#possible-errors">details</a>)</exception>
		public static Task<bool> Account_InstallWallPaper(this Client client, InputWallPaperBase wallpaper, WallPaperSettings settings)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xFEED5769);
				writer.WriteTLObject(wallpaper);
				writer.WriteTLObject(settings);
				return "Account_InstallWallPaper";
			});

		/// <summary>Delete installed wallpapers		<para>See <a href="https://corefork.telegram.org/method/account.resetWallPapers"/></para></summary>
		public static Task<bool> Account_ResetWallPapers(this Client client)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xBB3B9804);
				return "Account_ResetWallPapers";
			});

		/// <summary>Get media autodownload settings		<para>See <a href="https://corefork.telegram.org/method/account.getAutoDownloadSettings"/></para></summary>
		public static Task<Account_AutoDownloadSettings> Account_GetAutoDownloadSettings(this Client client)
			=> client.CallAsync<Account_AutoDownloadSettings>(writer =>
			{
				writer.Write(0x56DA0B3F);
				return "Account_GetAutoDownloadSettings";
			});

		/// <summary>Change media autodownload settings		<para>See <a href="https://corefork.telegram.org/method/account.saveAutoDownloadSettings"/></para></summary>
		/// <param name="low">Whether to save settings in the low data usage preset</param>
		/// <param name="high">Whether to save settings in the high data usage preset</param>
		/// <param name="settings">Media autodownload settings</param>
		public static Task<bool> Account_SaveAutoDownloadSettings(this Client client, AutoDownloadSettings settings, bool low = false, bool high = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x76F36233);
				writer.Write((low ? 0x1 : 0) | (high ? 0x2 : 0));
				writer.WriteTLObject(settings);
				return "Account_SaveAutoDownloadSettings";
			});

		/// <summary>Upload theme		<para>See <a href="https://corefork.telegram.org/method/account.uploadTheme"/></para></summary>
		/// <param name="file">Theme file uploaded as described in <a href="https://corefork.telegram.org/api/files">files »</a></param>
		/// <param name="thumb">Thumbnail</param>
		/// <param name="file_name">File name</param>
		/// <param name="mime_type">MIME type, must be <c>application/x-tgtheme-{format}</c>, where <c>format</c> depends on the client</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.uploadTheme#possible-errors">details</a>)</exception>
		public static Task<DocumentBase> Account_UploadTheme(this Client client, InputFileBase file, string file_name, string mime_type, InputFileBase thumb = null)
			=> client.CallAsync<DocumentBase>(writer =>
			{
				writer.Write(0x1C3DB333);
				writer.Write(thumb != null ? 0x1 : 0);
				writer.WriteTLObject(file);
				if (thumb != null)
					writer.WriteTLObject(thumb);
				writer.WriteTLString(file_name);
				writer.WriteTLString(mime_type);
				return "Account_UploadTheme";
			});

		/// <summary>Create a theme		<para>See <a href="https://corefork.telegram.org/method/account.createTheme"/></para></summary>
		/// <param name="slug">Unique theme ID</param>
		/// <param name="title">Theme name</param>
		/// <param name="document">Theme file</param>
		/// <param name="settings">Theme settings</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.createTheme#possible-errors">details</a>)</exception>
		public static Task<Theme> Account_CreateTheme(this Client client, string slug, string title, InputDocument document = null, InputThemeSettings[] settings = null)
			=> client.CallAsync<Theme>(writer =>
			{
				writer.Write(0x652E4400);
				writer.Write((document != null ? 0x4 : 0) | (settings != null ? 0x8 : 0));
				writer.WriteTLString(slug);
				writer.WriteTLString(title);
				if (document != null)
					writer.WriteTLObject(document);
				if (settings != null)
					writer.WriteTLVector(settings);
				return "Account_CreateTheme";
			});

		/// <summary>Update theme		<para>See <a href="https://corefork.telegram.org/method/account.updateTheme"/></para></summary>
		/// <param name="format">Theme format, a string that identifies the theming engines supported by the client</param>
		/// <param name="theme">Theme to update</param>
		/// <param name="slug">Unique theme ID</param>
		/// <param name="title">Theme name</param>
		/// <param name="document">Theme file</param>
		/// <param name="settings">Theme settings</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.updateTheme#possible-errors">details</a>)</exception>
		public static Task<Theme> Account_UpdateTheme(this Client client, string format, InputThemeBase theme, string slug = null, string title = null, InputDocument document = null, InputThemeSettings[] settings = null)
			=> client.CallAsync<Theme>(writer =>
			{
				writer.Write(0x2BF40CCC);
				writer.Write((slug != null ? 0x1 : 0) | (title != null ? 0x2 : 0) | (document != null ? 0x4 : 0) | (settings != null ? 0x8 : 0));
				writer.WriteTLString(format);
				writer.WriteTLObject(theme);
				if (slug != null)
					writer.WriteTLString(slug);
				if (title != null)
					writer.WriteTLString(title);
				if (document != null)
					writer.WriteTLObject(document);
				if (settings != null)
					writer.WriteTLVector(settings);
				return "Account_UpdateTheme";
			});

		/// <summary>Save a theme		<para>See <a href="https://corefork.telegram.org/method/account.saveTheme"/></para></summary>
		/// <param name="theme">Theme to save</param>
		/// <param name="unsave">Unsave</param>
		public static Task<bool> Account_SaveTheme(this Client client, InputThemeBase theme, bool unsave)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xF257106C);
				writer.WriteTLObject(theme);
				writer.Write(unsave ? 0x997275B5 : 0xBC799737);
				return "Account_SaveTheme";
			});

		/// <summary>Install a theme		<para>See <a href="https://corefork.telegram.org/method/account.installTheme"/></para></summary>
		/// <param name="dark">Whether to install the dark version</param>
		/// <param name="format">Theme format, a string that identifies the theming engines supported by the client</param>
		/// <param name="theme">Theme to install</param>
		public static Task<bool> Account_InstallTheme(this Client client, bool dark = false, InputThemeBase theme = null, string format = null, BaseTheme base_theme = default)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xC727BB3B);
				writer.Write((dark ? 0x1 : 0) | (theme != null ? 0x2 : 0) | (format != null ? 0x4 : 0) | (base_theme != default ? 0x8 : 0));
				if (theme != null)
					writer.WriteTLObject(theme);
				if (format != null)
					writer.WriteTLString(format);
				if (base_theme != default)
					writer.Write((uint)base_theme);
				return "Account_InstallTheme";
			});

		/// <summary>Get theme information		<para>See <a href="https://corefork.telegram.org/method/account.getTheme"/></para></summary>
		/// <param name="format">Theme format, a string that identifies the theming engines supported by the client</param>
		/// <param name="theme">Theme</param>
		/// <param name="document_id">Document ID</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.getTheme#possible-errors">details</a>)</exception>
		public static Task<Theme> Account_GetTheme(this Client client, string format, InputThemeBase theme, long document_id)
			=> client.CallAsync<Theme>(writer =>
			{
				writer.Write(0x8D9D742B);
				writer.WriteTLString(format);
				writer.WriteTLObject(theme);
				writer.Write(document_id);
				return "Account_GetTheme";
			});

		/// <summary>Get installed themes		<para>See <a href="https://corefork.telegram.org/method/account.getThemes"/></para></summary>
		/// <param name="format">Theme format, a string that identifies the theming engines supported by the client</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/account.themesNotModified">account.themesNotModified</a></returns>
		public static Task<Account_Themes> Account_GetThemes(this Client client, string format, long hash)
			=> client.CallAsync<Account_Themes>(writer =>
			{
				writer.Write(0x7206E458);
				writer.WriteTLString(format);
				writer.Write(hash);
				return "Account_GetThemes";
			});

		/// <summary>Set sensitive content settings (for viewing or hiding NSFW content)		<para>See <a href="https://corefork.telegram.org/method/account.setContentSettings"/></para></summary>
		/// <param name="sensitive_enabled">Enable NSFW content</param>
		/// <exception cref="RpcException">Possible errors: 403 (<a href="https://corefork.telegram.org/method/account.setContentSettings#possible-errors">details</a>)</exception>
		public static Task<bool> Account_SetContentSettings(this Client client, bool sensitive_enabled = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xB574B16B);
				writer.Write(sensitive_enabled ? 0x1 : 0);
				return "Account_SetContentSettings";
			});

		/// <summary>Get sensitive content settings		<para>See <a href="https://corefork.telegram.org/method/account.getContentSettings"/></para></summary>
		public static Task<Account_ContentSettings> Account_GetContentSettings(this Client client)
			=> client.CallAsync<Account_ContentSettings>(writer =>
			{
				writer.Write(0x8B9B4DAE);
				return "Account_GetContentSettings";
			});

		/// <summary>Get info about multiple wallpapers		<para>See <a href="https://corefork.telegram.org/method/account.getMultiWallPapers"/></para></summary>
		/// <param name="wallpapers">Wallpapers to fetch info about</param>
		public static Task<WallPaperBase[]> Account_GetMultiWallPapers(this Client client, InputWallPaperBase[] wallpapers)
			=> client.CallAsync<WallPaperBase[]>(writer =>
			{
				writer.Write(0x65AD71DC);
				writer.WriteTLVector(wallpapers);
				return "Account_GetMultiWallPapers";
			});

		/// <summary>Get global privacy settings		<para>See <a href="https://corefork.telegram.org/method/account.getGlobalPrivacySettings"/></para></summary>
		public static Task<GlobalPrivacySettings> Account_GetGlobalPrivacySettings(this Client client)
			=> client.CallAsync<GlobalPrivacySettings>(writer =>
			{
				writer.Write(0xEB2B4CF6);
				return "Account_GetGlobalPrivacySettings";
			});

		/// <summary>Set global privacy settings		<para>See <a href="https://corefork.telegram.org/method/account.setGlobalPrivacySettings"/></para></summary>
		/// <param name="settings">Global privacy settings</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.setGlobalPrivacySettings#possible-errors">details</a>)</exception>
		public static Task<GlobalPrivacySettings> Account_SetGlobalPrivacySettings(this Client client, GlobalPrivacySettings settings)
			=> client.CallAsync<GlobalPrivacySettings>(writer =>
			{
				writer.Write(0x1EDAAAC2);
				writer.WriteTLObject(settings);
				return "Account_SetGlobalPrivacySettings";
			});

		/// <summary>Report a profile photo of a dialog		<para>See <a href="https://corefork.telegram.org/method/account.reportProfilePhoto"/></para></summary>
		/// <param name="peer">The dialog</param>
		/// <param name="photo_id">Dialog photo ID</param>
		/// <param name="reason">Report reason</param>
		/// <param name="message">Comment for report moderation</param>
		public static Task<bool> Account_ReportProfilePhoto(this Client client, InputPeer peer, InputPhoto photo_id, ReportReason reason, string message)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xFA8CC6F5);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(photo_id);
				writer.Write((uint)reason);
				writer.WriteTLString(message);
				return "Account_ReportProfilePhoto";
			});

		/// <summary>Initiate a 2FA password reset: can only be used if the user is already logged-in, <a href="https://corefork.telegram.org/api/srp#password-reset">see here for more info »</a>		<para>See <a href="https://corefork.telegram.org/method/account.resetPassword"/></para></summary>
		public static Task<Account_ResetPasswordResult> Account_ResetPassword(this Client client)
			=> client.CallAsync<Account_ResetPasswordResult>(writer =>
			{
				writer.Write(0x9308CE1B);
				return "Account_ResetPassword";
			});

		/// <summary>Abort a pending 2FA password reset, <a href="https://corefork.telegram.org/api/srp#password-reset">see here for more info »</a>		<para>See <a href="https://corefork.telegram.org/method/account.declinePasswordReset"/></para></summary>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/account.declinePasswordReset#possible-errors">details</a>)</exception>
		public static Task<bool> Account_DeclinePasswordReset(this Client client)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x4C9409F6);
				return "Account_DeclinePasswordReset";
			});

		/// <summary>Get all available chat themes		<para>See <a href="https://corefork.telegram.org/method/account.getChatThemes"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/account.themesNotModified">account.themesNotModified</a></returns>
		public static Task<Account_Themes> Account_GetChatThemes(this Client client, long hash)
			=> client.CallAsync<Account_Themes>(writer =>
			{
				writer.Write(0xD638DE89);
				writer.Write(hash);
				return "Account_GetChatThemes";
			});

		/// <summary>Returns basic user info according to their identifiers.		<para>See <a href="https://corefork.telegram.org/method/users.getUsers"/></para></summary>
		/// <param name="id">List of user identifiers</param>
		/// <exception cref="RpcException">Possible errors: 400,401 (<a href="https://corefork.telegram.org/method/users.getUsers#possible-errors">details</a>)</exception>
		public static Task<UserBase[]> Users_GetUsers(this Client client, InputUserBase[] id)
			=> client.CallAsync<UserBase[]>(writer =>
			{
				writer.Write(0x0D91A548);
				writer.WriteTLVector(id);
				return "Users_GetUsers";
			});

		/// <summary>Returns extended user info by ID.		<para>See <a href="https://corefork.telegram.org/method/users.getFullUser"/></para></summary>
		/// <param name="id">User ID</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/users.getFullUser#possible-errors">details</a>)</exception>
		public static Task<UserFull> Users_GetFullUser(this Client client, InputUserBase id)
			=> client.CallAsync<UserFull>(writer =>
			{
				writer.Write(0xCA30A5B1);
				writer.WriteTLObject(id);
				return "Users_GetFullUser";
			});

		/// <summary>Notify the user that the sent <a href="https://corefork.telegram.org/passport">passport</a> data contains some errors The user will not be able to re-submit their Passport data to you until the errors are fixed (the contents of the field for which you returned the error must change).		<para>See <a href="https://corefork.telegram.org/method/users.setSecureValueErrors"/></para></summary>
		/// <param name="id">The user</param>
		/// <param name="errors">Errors</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/users.setSecureValueErrors#possible-errors">details</a>)</exception>
		public static Task<bool> Users_SetSecureValueErrors(this Client client, InputUserBase id, SecureValueErrorBase[] errors)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x90C894B5);
				writer.WriteTLObject(id);
				writer.WriteTLVector(errors);
				return "Users_SetSecureValueErrors";
			});

		/// <summary>Get contact by telegram IDs		<para>See <a href="https://corefork.telegram.org/method/contacts.getContactIDs"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		public static Task<int[]> Contacts_GetContactIDs(this Client client, long hash)
			=> client.CallAsync<int[]>(writer =>
			{
				writer.Write(0x7ADC669D);
				writer.Write(hash);
				return "Contacts_GetContactIDs";
			});

		/// <summary>Returns the list of contact statuses.		<para>See <a href="https://corefork.telegram.org/method/contacts.getStatuses"/></para></summary>
		public static Task<ContactStatus[]> Contacts_GetStatuses(this Client client)
			=> client.CallAsync<ContactStatus[]>(writer =>
			{
				writer.Write(0xC4A353EE);
				return "Contacts_GetStatuses";
			});

		/// <summary>Returns the current user's contact list.		<para>See <a href="https://corefork.telegram.org/method/contacts.getContacts"/></para></summary>
		/// <param name="hash">If there already is a full contact list on the client, a <a href="https://corefork.telegram.org/api/offsets#hash-generation">hash</a> of a the list of contact IDs in ascending order may be passed in this parameter. If the contact set was not changed, <see langword="null"/> will be returned.</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/contacts.contactsNotModified">contacts.contactsNotModified</a></returns>
		public static Task<Contacts_Contacts> Contacts_GetContacts(this Client client, long hash)
			=> client.CallAsync<Contacts_Contacts>(writer =>
			{
				writer.Write(0x5DD69E12);
				writer.Write(hash);
				return "Contacts_GetContacts";
			});

		/// <summary>Imports contacts: saves a full list on the server, adds already registered contacts to the contact list, returns added contacts and their info.		<para>See <a href="https://corefork.telegram.org/method/contacts.importContacts"/></para></summary>
		/// <param name="contacts">List of contacts to import</param>
		public static Task<Contacts_ImportedContacts> Contacts_ImportContacts(this Client client, InputContact[] contacts)
			=> client.CallAsync<Contacts_ImportedContacts>(writer =>
			{
				writer.Write(0x2C800BE5);
				writer.WriteTLVector(contacts);
				return "Contacts_ImportContacts";
			});

		/// <summary>Deletes several contacts from the list.		<para>See <a href="https://corefork.telegram.org/method/contacts.deleteContacts"/></para></summary>
		/// <param name="id">User ID list</param>
		public static Task<UpdatesBase> Contacts_DeleteContacts(this Client client, InputUserBase[] id)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x096A0E00);
				writer.WriteTLVector(id);
				return "Contacts_DeleteContacts";
			});

		/// <summary>Delete contacts by phone number		<para>See <a href="https://corefork.telegram.org/method/contacts.deleteByPhones"/></para></summary>
		/// <param name="phones">Phone numbers</param>
		public static Task<bool> Contacts_DeleteByPhones(this Client client, string[] phones)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x1013FD9E);
				writer.WriteTLVector(phones);
				return "Contacts_DeleteByPhones";
			});

		/// <summary>Adds the user to the blacklist.		<para>See <a href="https://corefork.telegram.org/method/contacts.block"/></para></summary>
		/// <param name="id">User ID</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/contacts.block#possible-errors">details</a>)</exception>
		public static Task<bool> Contacts_Block(this Client client, InputPeer id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x68CC1411);
				writer.WriteTLObject(id);
				return "Contacts_Block";
			});

		/// <summary>Deletes the user from the blacklist.		<para>See <a href="https://corefork.telegram.org/method/contacts.unblock"/></para></summary>
		/// <param name="id">User ID</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/contacts.unblock#possible-errors">details</a>)</exception>
		public static Task<bool> Contacts_Unblock(this Client client, InputPeer id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xBEA65D50);
				writer.WriteTLObject(id);
				return "Contacts_Unblock";
			});

		/// <summary>Returns the list of blocked users.		<para>See <a href="https://corefork.telegram.org/method/contacts.getBlocked"/></para></summary>
		/// <param name="offset">The number of list elements to be skipped</param>
		/// <param name="limit">The number of list elements to be returned</param>
		public static Task<Contacts_Blocked> Contacts_GetBlocked(this Client client, int offset, int limit)
			=> client.CallAsync<Contacts_Blocked>(writer =>
			{
				writer.Write(0xF57C350F);
				writer.Write(offset);
				writer.Write(limit);
				return "Contacts_GetBlocked";
			});

		/// <summary>Returns users found by username substring.		<para>See <a href="https://corefork.telegram.org/method/contacts.search"/></para></summary>
		/// <param name="q">Target substring</param>
		/// <param name="limit">Maximum number of users to be returned</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/contacts.search#possible-errors">details</a>)</exception>
		public static Task<Contacts_Found> Contacts_Search(this Client client, string q, int limit)
			=> client.CallAsync<Contacts_Found>(writer =>
			{
				writer.Write(0x11F812D8);
				writer.WriteTLString(q);
				writer.Write(limit);
				return "Contacts_Search";
			});

		/// <summary>Resolve a @username to get peer info		<para>See <a href="https://corefork.telegram.org/method/contacts.resolveUsername"/></para></summary>
		/// <param name="username">@username to resolve</param>
		/// <exception cref="RpcException">Possible errors: 400,401 (<a href="https://corefork.telegram.org/method/contacts.resolveUsername#possible-errors">details</a>)</exception>
		public static Task<Contacts_ResolvedPeer> Contacts_ResolveUsername(this Client client, string username)
			=> client.CallAsync<Contacts_ResolvedPeer>(writer =>
			{
				writer.Write(0xF93CCBA3);
				writer.WriteTLString(username);
				return "Contacts_ResolveUsername";
			});

		/// <summary>Get most used peers		<para>See <a href="https://corefork.telegram.org/method/contacts.getTopPeers"/></para></summary>
		/// <param name="correspondents">Users we've chatted most frequently with</param>
		/// <param name="bots_pm">Most used bots</param>
		/// <param name="bots_inline">Most used inline bots</param>
		/// <param name="phone_calls">Most frequently called users</param>
		/// <param name="forward_users">Users to which the users often forwards messages to</param>
		/// <param name="forward_chats">Chats to which the users often forwards messages to</param>
		/// <param name="groups">Often-opened groups and supergroups</param>
		/// <param name="channels">Most frequently visited channels</param>
		/// <param name="offset">Offset for <a href="https://corefork.telegram.org/api/offsets">pagination</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/contacts.topPeersNotModified">contacts.topPeersNotModified</a></returns>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/contacts.getTopPeers#possible-errors">details</a>)</exception>
		public static Task<Contacts_TopPeersBase> Contacts_GetTopPeers(this Client client, int offset, int limit, long hash, bool correspondents = false, bool bots_pm = false, bool bots_inline = false, bool phone_calls = false, bool forward_users = false, bool forward_chats = false, bool groups = false, bool channels = false)
			=> client.CallAsync<Contacts_TopPeersBase>(writer =>
			{
				writer.Write(0x973478B6);
				writer.Write((correspondents ? 0x1 : 0) | (bots_pm ? 0x2 : 0) | (bots_inline ? 0x4 : 0) | (phone_calls ? 0x8 : 0) | (forward_users ? 0x10 : 0) | (forward_chats ? 0x20 : 0) | (groups ? 0x400 : 0) | (channels ? 0x8000 : 0));
				writer.Write(offset);
				writer.Write(limit);
				writer.Write(hash);
				return "Contacts_GetTopPeers";
			});

		/// <summary>Reset <a href="https://corefork.telegram.org/api/top-rating">rating</a> of top peer		<para>See <a href="https://corefork.telegram.org/method/contacts.resetTopPeerRating"/></para></summary>
		/// <param name="category">Top peer category</param>
		/// <param name="peer">Peer whose rating should be reset</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/contacts.resetTopPeerRating#possible-errors">details</a>)</exception>
		public static Task<bool> Contacts_ResetTopPeerRating(this Client client, TopPeerCategory category, InputPeer peer)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x1AE373AC);
				writer.Write((uint)category);
				writer.WriteTLObject(peer);
				return "Contacts_ResetTopPeerRating";
			});

		/// <summary>Delete saved contacts		<para>See <a href="https://corefork.telegram.org/method/contacts.resetSaved"/></para></summary>
		public static Task<bool> Contacts_ResetSaved(this Client client)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x879537F1);
				return "Contacts_ResetSaved";
			});

		/// <summary>Get all contacts		<para>See <a href="https://corefork.telegram.org/method/contacts.getSaved"/></para></summary>
		/// <exception cref="RpcException">Possible errors: 403 (<a href="https://corefork.telegram.org/method/contacts.getSaved#possible-errors">details</a>)</exception>
		public static Task<SavedContact[]> Contacts_GetSaved(this Client client)
			=> client.CallAsync<SavedContact[]>(writer =>
			{
				writer.Write(0x82F1E39F);
				return "Contacts_GetSaved";
			});

		/// <summary>Enable/disable <a href="https://corefork.telegram.org/api/top-rating">top peers</a>		<para>See <a href="https://corefork.telegram.org/method/contacts.toggleTopPeers"/></para></summary>
		/// <param name="enabled">Enable/disable</param>
		public static Task<bool> Contacts_ToggleTopPeers(this Client client, bool enabled)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x8514BDDA);
				writer.Write(enabled ? 0x997275B5 : 0xBC799737);
				return "Contacts_ToggleTopPeers";
			});

		/// <summary>Add an existing telegram user as contact.		<para>See <a href="https://corefork.telegram.org/method/contacts.addContact"/></para></summary>
		/// <param name="add_phone_privacy_exception">Allow the other user to see our phone number?</param>
		/// <param name="id">Telegram ID of the other user</param>
		/// <param name="first_name">First name</param>
		/// <param name="last_name">Last name</param>
		/// <param name="phone">User's phone number</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/contacts.addContact#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Contacts_AddContact(this Client client, InputUserBase id, string first_name, string last_name, string phone, bool add_phone_privacy_exception = false)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xE8F463D0);
				writer.Write(add_phone_privacy_exception ? 0x1 : 0);
				writer.WriteTLObject(id);
				writer.WriteTLString(first_name);
				writer.WriteTLString(last_name);
				writer.WriteTLString(phone);
				return "Contacts_AddContact";
			});

		/// <summary>If the <see cref="PeerSettings"/> of a new user allow us to add him as contact, add that user as contact		<para>See <a href="https://corefork.telegram.org/method/contacts.acceptContact"/></para></summary>
		/// <param name="id">The user to add as contact</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/contacts.acceptContact#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Contacts_AcceptContact(this Client client, InputUserBase id)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xF831A20F);
				writer.WriteTLObject(id);
				return "Contacts_AcceptContact";
			});

		/// <summary>Get contacts near you		<para>See <a href="https://corefork.telegram.org/method/contacts.getLocated"/></para></summary>
		/// <param name="background">While the geolocation of the current user is public, clients should update it in the background every half-an-hour or so, while setting this flag. <br/>Do this only if the new location is more than 1 KM away from the previous one, or if the previous location is unknown.</param>
		/// <param name="geo_point">Geolocation</param>
		/// <param name="self_expires">If set, the geolocation of the current user will be public for the specified number of seconds; pass 0x7fffffff to disable expiry, 0 to make the current geolocation private; if the flag isn't set, no changes will be applied.</param>
		/// <exception cref="RpcException">Possible errors: 400,406 (<a href="https://corefork.telegram.org/method/contacts.getLocated#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Contacts_GetLocated(this Client client, InputGeoPoint geo_point, bool background = false, int? self_expires = null)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xD348BC44);
				writer.Write((background ? 0x2 : 0) | (self_expires != null ? 0x1 : 0));
				writer.WriteTLObject(geo_point);
				if (self_expires != null)
					writer.Write(self_expires.Value);
				return "Contacts_GetLocated";
			});

		/// <summary>Stop getting notifications about <a href="https://corefork.telegram.org/api/threads">thread replies</a> of a certain user in <c>@replies</c>		<para>See <a href="https://corefork.telegram.org/method/contacts.blockFromReplies"/></para></summary>
		/// <param name="delete_message">Whether to delete the specified message as well</param>
		/// <param name="delete_history">Whether to delete all <c>@replies</c> messages from this user as well</param>
		/// <param name="report_spam">Whether to also report this user for spam</param>
		/// <param name="msg_id">ID of the message in the <a href="https://corefork.telegram.org/api/threads#replies">@replies</a> chat</param>
		public static Task<UpdatesBase> Contacts_BlockFromReplies(this Client client, int msg_id, bool delete_message = false, bool delete_history = false, bool report_spam = false)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x29A8962C);
				writer.Write((delete_message ? 0x1 : 0) | (delete_history ? 0x2 : 0) | (report_spam ? 0x4 : 0));
				writer.Write(msg_id);
				return "Contacts_BlockFromReplies";
			});

		/// <summary>Returns the list of messages by their IDs.		<para>See <a href="https://corefork.telegram.org/method/messages.getMessages"/></para></summary>
		/// <param name="id">Message ID list</param>
		public static Task<Messages_MessagesBase> Messages_GetMessages(this Client client, InputMessage[] id)
			=> client.CallAsync<Messages_MessagesBase>(writer =>
			{
				writer.Write(0x63C66506);
				writer.WriteTLVector(id);
				return "Messages_GetMessages";
			});

		/// <summary>Returns the current user dialog list.		<para>See <a href="https://corefork.telegram.org/method/messages.getDialogs"/></para></summary>
		/// <param name="exclude_pinned">Exclude pinned dialogs</param>
		/// <param name="folder_id"><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></param>
		/// <param name="offset_date"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="offset_peer"><a href="https://corefork.telegram.org/api/offsets">Offset peer for pagination</a></param>
		/// <param name="limit">Number of list elements to be returned</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.getDialogs#possible-errors">details</a>)</exception>
		public static Task<Messages_DialogsBase> Messages_GetDialogs(this Client client, DateTime offset_date, int offset_id, InputPeer offset_peer, int limit, long hash, bool exclude_pinned = false, int? folder_id = null)
			=> client.CallAsync<Messages_DialogsBase>(writer =>
			{
				writer.Write(0xA0F4CB4F);
				writer.Write((exclude_pinned ? 0x1 : 0) | (folder_id != null ? 0x2 : 0));
				if (folder_id != null)
					writer.Write(folder_id.Value);
				writer.WriteTLStamp(offset_date);
				writer.Write(offset_id);
				writer.WriteTLObject(offset_peer);
				writer.Write(limit);
				writer.Write(hash);
				return "Messages_GetDialogs";
			});

		/// <summary>Gets back the conversation history with one interlocutor / within a chat		<para>See <a href="https://corefork.telegram.org/method/messages.getHistory"/></para></summary>
		/// <param name="peer">Target peer</param>
		/// <param name="offset_id">Only return messages starting from the specified message ID</param>
		/// <param name="offset_date">Only return messages sent before the specified date</param>
		/// <param name="add_offset">Number of list elements to be skipped, negative values are also accepted.</param>
		/// <param name="limit">Number of results to return</param>
		/// <param name="max_id">If a positive value was transferred, the method will return only messages with IDs less than <strong>max_id</strong></param>
		/// <param name="min_id">If a positive value was transferred, the method will return only messages with IDs more than <strong>min_id</strong></param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets">Result hash</a></param>
		/// <exception cref="RpcException">Possible errors: 400,401 (<a href="https://corefork.telegram.org/method/messages.getHistory#possible-errors">details</a>)</exception>
		public static Task<Messages_MessagesBase> Messages_GetHistory(this Client client, InputPeer peer, int offset_id, DateTime offset_date, int add_offset, int limit, int max_id, int min_id, long hash)
			=> client.CallAsync<Messages_MessagesBase>(writer =>
			{
				writer.Write(0x4423E6C5);
				writer.WriteTLObject(peer);
				writer.Write(offset_id);
				writer.WriteTLStamp(offset_date);
				writer.Write(add_offset);
				writer.Write(limit);
				writer.Write(max_id);
				writer.Write(min_id);
				writer.Write(hash);
				return "Messages_GetHistory";
			});

		/// <summary>Gets back found messages		<para>See <a href="https://corefork.telegram.org/method/messages.search"/></para></summary>
		/// <param name="peer">User or chat, histories with which are searched, or <see langword="null"/> constructor for global search</param>
		/// <param name="q">Text search request</param>
		/// <param name="from_id">Only return messages sent by the specified user ID</param>
		/// <param name="top_msg_id"><a href="https://corefork.telegram.org/api/threads">Thread ID</a></param>
		/// <param name="filter">Filter to return only specified message types</param>
		/// <param name="min_date">If a positive value was transferred, only messages with a sending date bigger than the transferred one will be returned</param>
		/// <param name="max_date">If a positive value was transferred, only messages with a sending date smaller than the transferred one will be returned</param>
		/// <param name="offset_id">Only return messages starting from the specified message ID</param>
		/// <param name="add_offset"><a href="https://corefork.telegram.org/api/offsets">Additional offset</a></param>
		/// <param name="limit"><a href="https://corefork.telegram.org/api/offsets">Number of results to return</a></param>
		/// <param name="max_id"><a href="https://corefork.telegram.org/api/offsets">Maximum message ID to return</a></param>
		/// <param name="min_id"><a href="https://corefork.telegram.org/api/offsets">Minimum message ID to return</a></param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets">Hash</a></param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.search#possible-errors">details</a>)</exception>
		public static Task<Messages_MessagesBase> Messages_Search(this Client client, InputPeer peer, string q, MessagesFilter filter, DateTime min_date, DateTime max_date, int offset_id, int add_offset, int limit, int max_id, int min_id, long hash, InputPeer from_id = null, int? top_msg_id = null)
			=> client.CallAsync<Messages_MessagesBase>(writer =>
			{
				writer.Write(0xA0FDA762);
				writer.Write((from_id != null ? 0x1 : 0) | (top_msg_id != null ? 0x2 : 0));
				writer.WriteTLObject(peer);
				writer.WriteTLString(q);
				if (from_id != null)
					writer.WriteTLObject(from_id);
				if (top_msg_id != null)
					writer.Write(top_msg_id.Value);
				writer.WriteTLObject(filter);
				writer.WriteTLStamp(min_date);
				writer.WriteTLStamp(max_date);
				writer.Write(offset_id);
				writer.Write(add_offset);
				writer.Write(limit);
				writer.Write(max_id);
				writer.Write(min_id);
				writer.Write(hash);
				return "Messages_Search";
			});

		/// <summary>Marks message history as read.		<para>See <a href="https://corefork.telegram.org/method/messages.readHistory"/></para></summary>
		/// <param name="peer">Target user or group</param>
		/// <param name="max_id">If a positive value is passed, only messages with identifiers less or equal than the given one will be read</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.readHistory#possible-errors">details</a>)</exception>
		public static Task<Messages_AffectedMessages> Messages_ReadHistory(this Client client, InputPeer peer, int max_id)
			=> client.CallAsync<Messages_AffectedMessages>(writer =>
			{
				writer.Write(0x0E306D3A);
				writer.WriteTLObject(peer);
				writer.Write(max_id);
				return "Messages_ReadHistory";
			});

		/// <summary>Deletes communication history.		<para>See <a href="https://corefork.telegram.org/method/messages.deleteHistory"/></para></summary>
		/// <param name="just_clear">Just clear history for the current user, without actually removing messages for every chat user</param>
		/// <param name="revoke">Whether to delete the message history for all chat participants</param>
		/// <param name="peer">User or chat, communication history of which will be deleted</param>
		/// <param name="max_id">Maximum ID of message to delete</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.deleteHistory#possible-errors">details</a>)</exception>
		public static Task<Messages_AffectedHistory> Messages_DeleteHistory(this Client client, InputPeer peer, int max_id, bool just_clear = false, bool revoke = false, DateTime? min_date = null, DateTime? max_date = null)
			=> client.CallAsync<Messages_AffectedHistory>(writer =>
			{
				writer.Write(0xB08F922A);
				writer.Write((just_clear ? 0x1 : 0) | (revoke ? 0x2 : 0) | (min_date != null ? 0x4 : 0) | (max_date != null ? 0x8 : 0));
				writer.WriteTLObject(peer);
				writer.Write(max_id);
				if (min_date != null)
					writer.WriteTLStamp(min_date.Value);
				if (max_date != null)
					writer.WriteTLStamp(max_date.Value);
				return "Messages_DeleteHistory";
			});

		/// <summary>Deletes messages by their identifiers.		<para>See <a href="https://corefork.telegram.org/method/messages.deleteMessages"/></para></summary>
		/// <param name="revoke">Whether to delete messages for all participants of the chat</param>
		/// <param name="id">Message ID list</param>
		/// <exception cref="RpcException">Possible errors: 403 (<a href="https://corefork.telegram.org/method/messages.deleteMessages#possible-errors">details</a>)</exception>
		public static Task<Messages_AffectedMessages> Messages_DeleteMessages(this Client client, int[] id, bool revoke = false)
			=> client.CallAsync<Messages_AffectedMessages>(writer =>
			{
				writer.Write(0xE58E95D2);
				writer.Write(revoke ? 0x1 : 0);
				writer.WriteTLVector(id);
				return "Messages_DeleteMessages";
			});

		/// <summary>Confirms receipt of messages by a client, cancels PUSH-notification sending.		<para>See <a href="https://corefork.telegram.org/method/messages.receivedMessages"/></para></summary>
		/// <param name="max_id">Maximum message ID available in a client.</param>
		public static Task<ReceivedNotifyMessage[]> Messages_ReceivedMessages(this Client client, int max_id)
			=> client.CallAsync<ReceivedNotifyMessage[]>(writer =>
			{
				writer.Write(0x05A954C0);
				writer.Write(max_id);
				return "Messages_ReceivedMessages";
			});

		/// <summary>Sends a current user typing event (see <see cref="SendMessageAction"/> for all event types) to a conversation partner or group.		<para>See <a href="https://corefork.telegram.org/method/messages.setTyping"/></para></summary>
		/// <param name="peer">Target user or group</param>
		/// <param name="top_msg_id"><a href="https://corefork.telegram.org/api/threads">Thread ID</a></param>
		/// <param name="action">Type of action<br/>Parameter added in <a href="https://corefork.telegram.org/api/layers#layer-17">Layer 17</a>.</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/messages.setTyping#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_SetTyping(this Client client, InputPeer peer, SendMessageAction action, int? top_msg_id = null)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x58943EE2);
				writer.Write(top_msg_id != null ? 0x1 : 0);
				writer.WriteTLObject(peer);
				if (top_msg_id != null)
					writer.Write(top_msg_id.Value);
				writer.WriteTLObject(action);
				return "Messages_SetTyping";
			});

		/// <summary>Sends a message to a chat		<para>See <a href="https://corefork.telegram.org/method/messages.sendMessage"/></para></summary>
		/// <param name="no_webpage">Set this flag to disable generation of the webpage preview</param>
		/// <param name="silent">Send this message silently (no notifications for the receivers)</param>
		/// <param name="background">Send this message as background message</param>
		/// <param name="clear_draft">Clear the draft field</param>
		/// <param name="peer">The destination where the message will be sent</param>
		/// <param name="reply_to_msg_id">The message ID to which this message will reply to</param>
		/// <param name="message">The message</param>
		/// <param name="random_id">Unique client message ID required to prevent message resending</param>
		/// <param name="reply_markup">Reply markup for sending bot buttons</param>
		/// <param name="entities">Message <a href="https://corefork.telegram.org/api/entities">entities</a> for sending styled text</param>
		/// <param name="schedule_date">Scheduled message date for <a href="https://corefork.telegram.org/api/scheduled-messages">scheduled messages</a></param>
		/// <exception cref="RpcException">Possible errors: 400,401,403,420 (<a href="https://corefork.telegram.org/method/messages.sendMessage#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Messages_SendMessage(this Client client, InputPeer peer, string message, long random_id, bool no_webpage = false, bool silent = false, bool background = false, bool clear_draft = false, int? reply_to_msg_id = null, ReplyMarkup reply_markup = null, MessageEntity[] entities = null, DateTime? schedule_date = null)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x520C3870);
				writer.Write((no_webpage ? 0x2 : 0) | (silent ? 0x20 : 0) | (background ? 0x40 : 0) | (clear_draft ? 0x80 : 0) | (reply_to_msg_id != null ? 0x1 : 0) | (reply_markup != null ? 0x4 : 0) | (entities != null ? 0x8 : 0) | (schedule_date != null ? 0x400 : 0));
				writer.WriteTLObject(peer);
				if (reply_to_msg_id != null)
					writer.Write(reply_to_msg_id.Value);
				writer.WriteTLString(message);
				writer.Write(random_id);
				if (reply_markup != null)
					writer.WriteTLObject(reply_markup);
				if (entities != null)
					writer.WriteTLVector(entities);
				if (schedule_date != null)
					writer.WriteTLStamp(schedule_date.Value);
				return "Messages_SendMessage";
			});

		/// <summary>Send a media		<para>See <a href="https://corefork.telegram.org/method/messages.sendMedia"/></para></summary>
		/// <param name="silent">Send message silently (no notification should be triggered)</param>
		/// <param name="background">Send message in background</param>
		/// <param name="clear_draft">Clear the draft</param>
		/// <param name="peer">Destination</param>
		/// <param name="reply_to_msg_id">Message ID to which this message should reply to</param>
		/// <param name="media">Attached media</param>
		/// <param name="message">Caption</param>
		/// <param name="random_id">Random ID to avoid resending the same message</param>
		/// <param name="reply_markup">Reply markup for bot keyboards</param>
		/// <param name="entities">Message <a href="https://corefork.telegram.org/api/entities">entities</a> for styled text</param>
		/// <param name="schedule_date">Scheduled message date for <a href="https://corefork.telegram.org/api/scheduled-messages">scheduled messages</a></param>
		/// <exception cref="RpcException">Possible errors: 400,403,420 (<a href="https://corefork.telegram.org/method/messages.sendMedia#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Messages_SendMedia(this Client client, InputPeer peer, InputMedia media, string message, long random_id, bool silent = false, bool background = false, bool clear_draft = false, int? reply_to_msg_id = null, ReplyMarkup reply_markup = null, MessageEntity[] entities = null, DateTime? schedule_date = null)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x3491EBA9);
				writer.Write((silent ? 0x20 : 0) | (background ? 0x40 : 0) | (clear_draft ? 0x80 : 0) | (reply_to_msg_id != null ? 0x1 : 0) | (reply_markup != null ? 0x4 : 0) | (entities != null ? 0x8 : 0) | (schedule_date != null ? 0x400 : 0));
				writer.WriteTLObject(peer);
				if (reply_to_msg_id != null)
					writer.Write(reply_to_msg_id.Value);
				writer.WriteTLObject(media);
				writer.WriteTLString(message);
				writer.Write(random_id);
				if (reply_markup != null)
					writer.WriteTLObject(reply_markup);
				if (entities != null)
					writer.WriteTLVector(entities);
				if (schedule_date != null)
					writer.WriteTLStamp(schedule_date.Value);
				return "Messages_SendMedia";
			});

		/// <summary>Forwards messages by their IDs.		<para>See <a href="https://corefork.telegram.org/method/messages.forwardMessages"/></para></summary>
		/// <param name="silent">Whether to send messages silently (no notification will be triggered on the destination clients)</param>
		/// <param name="background">Whether to send the message in background</param>
		/// <param name="with_my_score">When forwarding games, whether to include your score in the game</param>
		/// <param name="drop_author">Whether to forward messages without quoting the original author</param>
		/// <param name="drop_media_captions">Whether to strip captions from media</param>
		/// <param name="from_peer">Source of messages</param>
		/// <param name="id">IDs of messages</param>
		/// <param name="random_id">Random ID to prevent resending of messages</param>
		/// <param name="to_peer">Destination peer</param>
		/// <param name="schedule_date">Scheduled message date for scheduled messages</param>
		/// <exception cref="RpcException">Possible errors: 400,403,420 (<a href="https://corefork.telegram.org/method/messages.forwardMessages#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Messages_ForwardMessages(this Client client, InputPeer from_peer, int[] id, long[] random_id, InputPeer to_peer, bool silent = false, bool background = false, bool with_my_score = false, bool drop_author = false, bool drop_media_captions = false, DateTime? schedule_date = null)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xD9FEE60E);
				writer.Write((silent ? 0x20 : 0) | (background ? 0x40 : 0) | (with_my_score ? 0x100 : 0) | (drop_author ? 0x800 : 0) | (drop_media_captions ? 0x1000 : 0) | (schedule_date != null ? 0x400 : 0));
				writer.WriteTLObject(from_peer);
				writer.WriteTLVector(id);
				writer.WriteTLVector(random_id);
				writer.WriteTLObject(to_peer);
				if (schedule_date != null)
					writer.WriteTLStamp(schedule_date.Value);
				return "Messages_ForwardMessages";
			});

		/// <summary>Report a new incoming chat for spam, if the <see cref="PeerSettings"/> of the chat allow us to do that		<para>See <a href="https://corefork.telegram.org/method/messages.reportSpam"/></para></summary>
		/// <param name="peer">Peer to report</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.reportSpam#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_ReportSpam(this Client client, InputPeer peer)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xCF1592DB);
				writer.WriteTLObject(peer);
				return "Messages_ReportSpam";
			});

		/// <summary>Get peer settings		<para>See <a href="https://corefork.telegram.org/method/messages.getPeerSettings"/></para></summary>
		/// <param name="peer">The peer</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.getPeerSettings#possible-errors">details</a>)</exception>
		public static Task<PeerSettings> Messages_GetPeerSettings(this Client client, InputPeer peer)
			=> client.CallAsync<PeerSettings>(writer =>
			{
				writer.Write(0x3672E09C);
				writer.WriteTLObject(peer);
				return "Messages_GetPeerSettings";
			});

		/// <summary>Report a message in a chat for violation of telegram's Terms of Service		<para>See <a href="https://corefork.telegram.org/method/messages.report"/></para></summary>
		/// <param name="peer">Peer</param>
		/// <param name="id">IDs of messages to report</param>
		/// <param name="reason">Why are these messages being reported</param>
		/// <param name="message">Comment for report moderation</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.report#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_Report(this Client client, InputPeer peer, int[] id, ReportReason reason, string message)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x8953AB4E);
				writer.WriteTLObject(peer);
				writer.WriteTLVector(id);
				writer.Write((uint)reason);
				writer.WriteTLString(message);
				return "Messages_Report";
			});

		/// <summary>Returns chat basic info on their IDs.		<para>See <a href="https://corefork.telegram.org/method/messages.getChats"/></para></summary>
		/// <param name="id">List of chat IDs</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.getChats#possible-errors">details</a>)</exception>
		public static Task<Messages_Chats> Messages_GetChats(this Client client, long[] id)
			=> client.CallAsync<Messages_Chats>(writer =>
			{
				writer.Write(0x49E9528F);
				writer.WriteTLVector(id);
				return "Messages_GetChats";
			});

		/// <summary>Returns full chat info according to its ID.		<para>See <a href="https://corefork.telegram.org/method/messages.getFullChat"/></para></summary>
		/// <param name="chat_id">Chat ID</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.getFullChat#possible-errors">details</a>)</exception>
		public static Task<Messages_ChatFull> Messages_GetFullChat(this Client client, long chat_id)
			=> client.CallAsync<Messages_ChatFull>(writer =>
			{
				writer.Write(0xAEB00B34);
				writer.Write(chat_id);
				return "Messages_GetFullChat";
			});

		/// <summary>Chanages chat name and sends a service message on it.		<para>See <a href="https://corefork.telegram.org/method/messages.editChatTitle"/></para></summary>
		/// <param name="chat_id">Chat ID</param>
		/// <param name="title">New chat name, different from the old one</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.editChatTitle#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Messages_EditChatTitle(this Client client, long chat_id, string title)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x73783FFD);
				writer.Write(chat_id);
				writer.WriteTLString(title);
				return "Messages_EditChatTitle";
			});

		/// <summary>Changes chat photo and sends a service message on it		<para>See <a href="https://corefork.telegram.org/method/messages.editChatPhoto"/></para></summary>
		/// <param name="chat_id">Chat ID</param>
		/// <param name="photo">Photo to be set</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.editChatPhoto#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Messages_EditChatPhoto(this Client client, long chat_id, InputChatPhotoBase photo)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x35DDD674);
				writer.Write(chat_id);
				writer.WriteTLObject(photo);
				return "Messages_EditChatPhoto";
			});

		/// <summary>Adds a user to a chat and sends a service message on it.		<para>See <a href="https://corefork.telegram.org/method/messages.addChatUser"/></para></summary>
		/// <param name="chat_id">Chat ID</param>
		/// <param name="user_id">User ID to be added</param>
		/// <param name="fwd_limit">Number of last messages to be forwarded</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/messages.addChatUser#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Messages_AddChatUser(this Client client, long chat_id, InputUserBase user_id, int fwd_limit)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xF24753E3);
				writer.Write(chat_id);
				writer.WriteTLObject(user_id);
				writer.Write(fwd_limit);
				return "Messages_AddChatUser";
			});

		/// <summary>Deletes a user from a chat and sends a service message on it.		<para>See <a href="https://corefork.telegram.org/method/messages.deleteChatUser"/></para></summary>
		/// <param name="revoke_history">Remove the entire chat history of the specified user in this chat.</param>
		/// <param name="chat_id">Chat ID</param>
		/// <param name="user_id">User ID to be deleted</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.deleteChatUser#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Messages_DeleteChatUser(this Client client, long chat_id, InputUserBase user_id, bool revoke_history = false)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xA2185CAB);
				writer.Write(revoke_history ? 0x1 : 0);
				writer.Write(chat_id);
				writer.WriteTLObject(user_id);
				return "Messages_DeleteChatUser";
			});

		/// <summary>Creates a new chat.		<para>See <a href="https://corefork.telegram.org/method/messages.createChat"/></para></summary>
		/// <param name="users">List of user IDs to be invited</param>
		/// <param name="title">Chat name</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/messages.createChat#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Messages_CreateChat(this Client client, InputUserBase[] users, string title)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x09CB126E);
				writer.WriteTLVector(users);
				writer.WriteTLString(title);
				return "Messages_CreateChat";
			});

		/// <summary>Returns configuration parameters for Diffie-Hellman key generation. Can also return a random sequence of bytes of required length.		<para>See <a href="https://corefork.telegram.org/method/messages.getDhConfig"/></para></summary>
		/// <param name="version">Value of the <strong>version</strong> parameter from <see cref="Messages_DhConfig"/>, avialable at the client</param>
		/// <param name="random_length">Length of the required random sequence</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.getDhConfig#possible-errors">details</a>)</exception>
		public static Task<Messages_DhConfigBase> Messages_GetDhConfig(this Client client, int version, int random_length)
			=> client.CallAsync<Messages_DhConfigBase>(writer =>
			{
				writer.Write(0x26CF8950);
				writer.Write(version);
				writer.Write(random_length);
				return "Messages_GetDhConfig";
			});

		/// <summary>Sends a request to start a secret chat to the user.		<para>See <a href="https://corefork.telegram.org/method/messages.requestEncryption"/></para></summary>
		/// <param name="user_id">User ID</param>
		/// <param name="random_id">Unique client request ID required to prevent resending. This also doubles as the chat ID.</param>
		/// <param name="g_a"><c>A = g ^ a mod p</c>, see <a href="https://en.wikipedia.org/wiki/Diffie%E2%80%93Hellman_key_exchange">Wikipedia</a></param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.requestEncryption#possible-errors">details</a>)</exception>
		public static Task<EncryptedChatBase> Messages_RequestEncryption(this Client client, InputUserBase user_id, int random_id, byte[] g_a)
			=> client.CallAsync<EncryptedChatBase>(writer =>
			{
				writer.Write(0xF64DAF43);
				writer.WriteTLObject(user_id);
				writer.Write(random_id);
				writer.WriteTLBytes(g_a);
				return "Messages_RequestEncryption";
			});

		/// <summary>Confirms creation of a secret chat		<para>See <a href="https://corefork.telegram.org/method/messages.acceptEncryption"/></para></summary>
		/// <param name="peer">Secret chat ID</param>
		/// <param name="g_b"><c>B = g ^ b mod p</c>, see <a href="https://en.wikipedia.org/wiki/Diffie%E2%80%93Hellman_key_exchange">Wikipedia</a></param>
		/// <param name="key_fingerprint">64-bit fingerprint of the received key</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.acceptEncryption#possible-errors">details</a>)</exception>
		public static Task<EncryptedChatBase> Messages_AcceptEncryption(this Client client, InputEncryptedChat peer, byte[] g_b, long key_fingerprint)
			=> client.CallAsync<EncryptedChatBase>(writer =>
			{
				writer.Write(0x3DBC0415);
				writer.WriteTLObject(peer);
				writer.WriteTLBytes(g_b);
				writer.Write(key_fingerprint);
				return "Messages_AcceptEncryption";
			});

		/// <summary>Cancels a request for creation and/or delete info on secret chat.		<para>See <a href="https://corefork.telegram.org/method/messages.discardEncryption"/></para></summary>
		/// <param name="delete_history">Whether to delete the entire chat history for the other user as well</param>
		/// <param name="chat_id">Secret chat ID</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.discardEncryption#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_DiscardEncryption(this Client client, int chat_id, bool delete_history = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xF393AEA0);
				writer.Write(delete_history ? 0x1 : 0);
				writer.Write(chat_id);
				return "Messages_DiscardEncryption";
			});

		/// <summary>Send typing event by the current user to a secret chat.		<para>See <a href="https://corefork.telegram.org/method/messages.setEncryptedTyping"/></para></summary>
		/// <param name="peer">Secret chat ID</param>
		/// <param name="typing">Typing.<br/><strong>Possible values</strong>:<br/><see cref="Bool.True"/>, if the user started typing and more than <strong>5 seconds</strong> have passed since the last request<br/><see cref="Bool.False"/>, if the user stopped typing</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.setEncryptedTyping#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_SetEncryptedTyping(this Client client, InputEncryptedChat peer, bool typing)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x791451ED);
				writer.WriteTLObject(peer);
				writer.Write(typing ? 0x997275B5 : 0xBC799737);
				return "Messages_SetEncryptedTyping";
			});

		/// <summary>Marks message history within a secret chat as read.		<para>See <a href="https://corefork.telegram.org/method/messages.readEncryptedHistory"/></para></summary>
		/// <param name="peer">Secret chat ID</param>
		/// <param name="max_date">Maximum date value for received messages in history</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.readEncryptedHistory#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_ReadEncryptedHistory(this Client client, InputEncryptedChat peer, DateTime max_date)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x7F4B690A);
				writer.WriteTLObject(peer);
				writer.WriteTLStamp(max_date);
				return "Messages_ReadEncryptedHistory";
			});

		/// <summary>Sends a text message to a secret chat.		<para>See <a href="https://corefork.telegram.org/method/messages.sendEncrypted"/></para></summary>
		/// <param name="silent">Send encrypted message without a notification</param>
		/// <param name="peer">Secret chat ID</param>
		/// <param name="random_id">Unique client message ID, necessary to avoid message resending</param>
		/// <param name="data">TL-serialization of <see cref="DecryptedMessageBase"/> type, encrypted with a key that was created during chat initialization</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/messages.sendEncrypted#possible-errors">details</a>)</exception>
		public static Task<Messages_SentEncryptedMessage> Messages_SendEncrypted(this Client client, InputEncryptedChat peer, long random_id, byte[] data, bool silent = false)
			=> client.CallAsync<Messages_SentEncryptedMessage>(writer =>
			{
				writer.Write(0x44FA7A15);
				writer.Write(silent ? 0x1 : 0);
				writer.WriteTLObject(peer);
				writer.Write(random_id);
				writer.WriteTLBytes(data);
				return "Messages_SendEncrypted";
			});

		/// <summary>Sends a message with a file attachment to a secret chat		<para>See <a href="https://corefork.telegram.org/method/messages.sendEncryptedFile"/></para></summary>
		/// <param name="silent">Whether to send the file without triggering a notification</param>
		/// <param name="peer">Secret chat ID</param>
		/// <param name="random_id">Unique client message ID necessary to prevent message resending</param>
		/// <param name="data">TL-serialization of <see cref="DecryptedMessageBase"/> type, encrypted with a key generated during chat initialization</param>
		/// <param name="file">File attachment for the secret chat</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.sendEncryptedFile#possible-errors">details</a>)</exception>
		public static Task<Messages_SentEncryptedMessage> Messages_SendEncryptedFile(this Client client, InputEncryptedChat peer, long random_id, byte[] data, InputEncryptedFileBase file, bool silent = false)
			=> client.CallAsync<Messages_SentEncryptedMessage>(writer =>
			{
				writer.Write(0x5559481D);
				writer.Write(silent ? 0x1 : 0);
				writer.WriteTLObject(peer);
				writer.Write(random_id);
				writer.WriteTLBytes(data);
				writer.WriteTLObject(file);
				return "Messages_SendEncryptedFile";
			});

		/// <summary>Sends a service message to a secret chat.		<para>See <a href="https://corefork.telegram.org/method/messages.sendEncryptedService"/></para></summary>
		/// <param name="peer">Secret chat ID</param>
		/// <param name="random_id">Unique client message ID required to prevent message resending</param>
		/// <param name="data">TL-serialization of  <see cref="DecryptedMessageBase"/> type, encrypted with a key generated during chat initialization</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/messages.sendEncryptedService#possible-errors">details</a>)</exception>
		public static Task<Messages_SentEncryptedMessage> Messages_SendEncryptedService(this Client client, InputEncryptedChat peer, long random_id, byte[] data)
			=> client.CallAsync<Messages_SentEncryptedMessage>(writer =>
			{
				writer.Write(0x32D439A4);
				writer.WriteTLObject(peer);
				writer.Write(random_id);
				writer.WriteTLBytes(data);
				return "Messages_SendEncryptedService";
			});

		/// <summary>Confirms receipt of messages in a secret chat by client, cancels push notifications.		<para>See <a href="https://corefork.telegram.org/method/messages.receivedQueue"/></para></summary>
		/// <param name="max_qts">Maximum qts value available at the client</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.receivedQueue#possible-errors">details</a>)</exception>
		public static Task<long[]> Messages_ReceivedQueue(this Client client, int max_qts)
			=> client.CallAsync<long[]>(writer =>
			{
				writer.Write(0x55A5BB66);
				writer.Write(max_qts);
				return "Messages_ReceivedQueue";
			});

		/// <summary>Report a secret chat for spam		<para>See <a href="https://corefork.telegram.org/method/messages.reportEncryptedSpam"/></para></summary>
		/// <param name="peer">The secret chat to report</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.reportEncryptedSpam#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_ReportEncryptedSpam(this Client client, InputEncryptedChat peer)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x4B0C8C0F);
				writer.WriteTLObject(peer);
				return "Messages_ReportEncryptedSpam";
			});

		/// <summary>Notifies the sender about the recipient having listened a voice message or watched a video.		<para>See <a href="https://corefork.telegram.org/method/messages.readMessageContents"/></para></summary>
		/// <param name="id">Message ID list</param>
		public static Task<Messages_AffectedMessages> Messages_ReadMessageContents(this Client client, int[] id)
			=> client.CallAsync<Messages_AffectedMessages>(writer =>
			{
				writer.Write(0x36A73F77);
				writer.WriteTLVector(id);
				return "Messages_ReadMessageContents";
			});

		/// <summary>Get stickers by emoji		<para>See <a href="https://corefork.telegram.org/method/messages.getStickers"/></para></summary>
		/// <param name="emoticon">The emoji</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.stickersNotModified">messages.stickersNotModified</a></returns>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.getStickers#possible-errors">details</a>)</exception>
		public static Task<Messages_Stickers> Messages_GetStickers(this Client client, string emoticon, long hash)
			=> client.CallAsync<Messages_Stickers>(writer =>
			{
				writer.Write(0xD5A5D3A1);
				writer.WriteTLString(emoticon);
				writer.Write(hash);
				return "Messages_GetStickers";
			});

		/// <summary>Get all installed stickers		<para>See <a href="https://corefork.telegram.org/method/messages.getAllStickers"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.allStickersNotModified">messages.allStickersNotModified</a></returns>
		public static Task<Messages_AllStickers> Messages_GetAllStickers(this Client client, long hash)
			=> client.CallAsync<Messages_AllStickers>(writer =>
			{
				writer.Write(0xB8A0A1A8);
				writer.Write(hash);
				return "Messages_GetAllStickers";
			});

		/// <summary>Get preview of webpage		<para>See <a href="https://corefork.telegram.org/method/messages.getWebPagePreview"/></para></summary>
		/// <param name="message">Message from which to extract the preview</param>
		/// <param name="entities"><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messageMediaEmpty">messageMediaEmpty</a></returns>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.getWebPagePreview#possible-errors">details</a>)</exception>
		public static Task<MessageMedia> Messages_GetWebPagePreview(this Client client, string message, MessageEntity[] entities = null)
			=> client.CallAsync<MessageMedia>(writer =>
			{
				writer.Write(0x8B68B0CC);
				writer.Write(entities != null ? 0x8 : 0);
				writer.WriteTLString(message);
				if (entities != null)
					writer.WriteTLVector(entities);
				return "Messages_GetWebPagePreview";
			});

		/// <summary>Export an invite link for a chat		<para>See <a href="https://corefork.telegram.org/method/messages.exportChatInvite"/></para></summary>
		/// <param name="legacy_revoke_permanent">Legacy flag, reproducing legacy behavior of this method: if set, revokes all previous links before creating a new one. Kept for bot API BC, should not be used by modern clients.</param>
		/// <param name="peer">Chat</param>
		/// <param name="expire_date">Expiration date</param>
		/// <param name="usage_limit">Maximum number of users that can join using this link</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/messages.exportChatInvite#possible-errors">details</a>)</exception>
		public static Task<ExportedChatInvite> Messages_ExportChatInvite(this Client client, InputPeer peer, bool legacy_revoke_permanent = false, bool request_needed = false, DateTime? expire_date = null, int? usage_limit = null, string title = null)
			=> client.CallAsync<ExportedChatInvite>(writer =>
			{
				writer.Write(0xA02CE5D5);
				writer.Write((legacy_revoke_permanent ? 0x4 : 0) | (request_needed ? 0x8 : 0) | (expire_date != null ? 0x1 : 0) | (usage_limit != null ? 0x2 : 0) | (title != null ? 0x10 : 0));
				writer.WriteTLObject(peer);
				if (expire_date != null)
					writer.WriteTLStamp(expire_date.Value);
				if (usage_limit != null)
					writer.Write(usage_limit.Value);
				if (title != null)
					writer.WriteTLString(title);
				return "Messages_ExportChatInvite";
			});

		/// <summary>Check the validity of a chat invite link and get basic info about it		<para>See <a href="https://corefork.telegram.org/method/messages.checkChatInvite"/></para></summary>
		/// <param name="hash">Invite hash in <c>t.me/joinchat/hash</c></param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.checkChatInvite#possible-errors">details</a>)</exception>
		public static Task<ChatInviteBase> Messages_CheckChatInvite(this Client client, string hash)
			=> client.CallAsync<ChatInviteBase>(writer =>
			{
				writer.Write(0x3EADB1BB);
				writer.WriteTLString(hash);
				return "Messages_CheckChatInvite";
			});

		/// <summary>Import a chat invite and join a private chat/supergroup/channel		<para>See <a href="https://corefork.telegram.org/method/messages.importChatInvite"/></para></summary>
		/// <param name="hash"><c>hash</c> from <c>t.me/joinchat/hash</c></param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.importChatInvite#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Messages_ImportChatInvite(this Client client, string hash)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x6C50051C);
				writer.WriteTLString(hash);
				return "Messages_ImportChatInvite";
			});

		/// <summary>Get info about a stickerset		<para>See <a href="https://corefork.telegram.org/method/messages.getStickerSet"/></para></summary>
		/// <param name="stickerset">Stickerset</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.getStickerSet#possible-errors">details</a>)</exception>
		public static Task<Messages_StickerSet> Messages_GetStickerSet(this Client client, InputStickerSet stickerset)
			=> client.CallAsync<Messages_StickerSet>(writer =>
			{
				writer.Write(0x2619A90E);
				writer.WriteTLObject(stickerset);
				return "Messages_GetStickerSet";
			});

		/// <summary>Install a stickerset		<para>See <a href="https://corefork.telegram.org/method/messages.installStickerSet"/></para></summary>
		/// <param name="stickerset">Stickerset to install</param>
		/// <param name="archived">Whether to archive stickerset</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.installStickerSet#possible-errors">details</a>)</exception>
		public static Task<Messages_StickerSetInstallResult> Messages_InstallStickerSet(this Client client, InputStickerSet stickerset, bool archived)
			=> client.CallAsync<Messages_StickerSetInstallResult>(writer =>
			{
				writer.Write(0xC78FE460);
				writer.WriteTLObject(stickerset);
				writer.Write(archived ? 0x997275B5 : 0xBC799737);
				return "Messages_InstallStickerSet";
			});

		/// <summary>Uninstall a stickerset		<para>See <a href="https://corefork.telegram.org/method/messages.uninstallStickerSet"/></para></summary>
		/// <param name="stickerset">The stickerset to uninstall</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.uninstallStickerSet#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_UninstallStickerSet(this Client client, InputStickerSet stickerset)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xF96E55DE);
				writer.WriteTLObject(stickerset);
				return "Messages_UninstallStickerSet";
			});

		/// <summary>Start a conversation with a bot using a <a href="https://corefork.telegram.org/bots#deep-linking">deep linking parameter</a>		<para>See <a href="https://corefork.telegram.org/method/messages.startBot"/></para></summary>
		/// <param name="bot">The bot</param>
		/// <param name="peer">The chat where to start the bot, can be the bot's private chat or a group</param>
		/// <param name="random_id">Random ID to avoid resending the same message</param>
		/// <param name="start_param"><a href="https://corefork.telegram.org/bots#deep-linking">Deep linking parameter</a></param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.startBot#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Messages_StartBot(this Client client, InputUserBase bot, InputPeer peer, long random_id, string start_param)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xE6DF7378);
				writer.WriteTLObject(bot);
				writer.WriteTLObject(peer);
				writer.Write(random_id);
				writer.WriteTLString(start_param);
				return "Messages_StartBot";
			});

		/// <summary>Get and increase the view counter of a message sent or forwarded from a <a href="https://corefork.telegram.org/api/channel">channel</a>		<para>See <a href="https://corefork.telegram.org/method/messages.getMessagesViews"/></para></summary>
		/// <param name="peer">Peer where the message was found</param>
		/// <param name="id">ID of message</param>
		/// <param name="increment">Whether to mark the message as viewed and increment the view counter</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.getMessagesViews#possible-errors">details</a>)</exception>
		public static Task<Messages_MessageViews> Messages_GetMessagesViews(this Client client, InputPeer peer, int[] id, bool increment)
			=> client.CallAsync<Messages_MessageViews>(writer =>
			{
				writer.Write(0x5784D3E1);
				writer.WriteTLObject(peer);
				writer.WriteTLVector(id);
				writer.Write(increment ? 0x997275B5 : 0xBC799737);
				return "Messages_GetMessagesViews";
			});

		/// <summary>Make a user admin in a <a href="https://corefork.telegram.org/api/channel">legacy group</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.editChatAdmin"/></para></summary>
		/// <param name="chat_id">The ID of the group</param>
		/// <param name="user_id">The user to make admin</param>
		/// <param name="is_admin">Whether to make him admin</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.editChatAdmin#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_EditChatAdmin(this Client client, long chat_id, InputUserBase user_id, bool is_admin)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xA85BD1C2);
				writer.Write(chat_id);
				writer.WriteTLObject(user_id);
				writer.Write(is_admin ? 0x997275B5 : 0xBC799737);
				return "Messages_EditChatAdmin";
			});

		/// <summary>Turn a <a href="https://corefork.telegram.org/api/channel">legacy group into a supergroup</a>		<para>See <a href="https://corefork.telegram.org/method/messages.migrateChat"/></para></summary>
		/// <param name="chat_id">Legacy group to migrate</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/messages.migrateChat#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Messages_MigrateChat(this Client client, long chat_id)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xA2875319);
				writer.Write(chat_id);
				return "Messages_MigrateChat";
			});

		/// <summary>Search for messages and peers globally		<para>See <a href="https://corefork.telegram.org/method/messages.searchGlobal"/></para></summary>
		/// <param name="folder_id"><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></param>
		/// <param name="q">Query</param>
		/// <param name="filter">Global search filter</param>
		/// <param name="min_date">If a positive value was specified, the method will return only messages with date bigger than min_date</param>
		/// <param name="max_date">If a positive value was transferred, the method will return only messages with date smaller than max_date</param>
		/// <param name="offset_rate">Initially 0, then set to the <see cref="Messages_MessagesSlice"/></param>
		/// <param name="offset_peer"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="limit"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.searchGlobal#possible-errors">details</a>)</exception>
		public static Task<Messages_MessagesBase> Messages_SearchGlobal(this Client client, string q, MessagesFilter filter, DateTime min_date, DateTime max_date, int offset_rate, InputPeer offset_peer, int offset_id, int limit, int? folder_id = null)
			=> client.CallAsync<Messages_MessagesBase>(writer =>
			{
				writer.Write(0x4BC6589A);
				writer.Write(folder_id != null ? 0x1 : 0);
				if (folder_id != null)
					writer.Write(folder_id.Value);
				writer.WriteTLString(q);
				writer.WriteTLObject(filter);
				writer.WriteTLStamp(min_date);
				writer.WriteTLStamp(max_date);
				writer.Write(offset_rate);
				writer.WriteTLObject(offset_peer);
				writer.Write(offset_id);
				writer.Write(limit);
				return "Messages_SearchGlobal";
			});

		/// <summary>Reorder installed stickersets		<para>See <a href="https://corefork.telegram.org/method/messages.reorderStickerSets"/></para></summary>
		/// <param name="masks">Reorder mask stickersets</param>
		/// <param name="order">New stickerset order by stickerset IDs</param>
		public static Task<bool> Messages_ReorderStickerSets(this Client client, long[] order, bool masks = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x78337739);
				writer.Write(masks ? 0x1 : 0);
				writer.WriteTLVector(order);
				return "Messages_ReorderStickerSets";
			});

		/// <summary>Get a document by its SHA256 hash, mainly used for gifs		<para>See <a href="https://corefork.telegram.org/method/messages.getDocumentByHash"/></para></summary>
		/// <param name="sha256">SHA256 of file</param>
		/// <param name="size">Size of the file in bytes</param>
		/// <param name="mime_type">Mime type</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.getDocumentByHash#possible-errors">details</a>)</exception>
		public static Task<DocumentBase> Messages_GetDocumentByHash(this Client client, byte[] sha256, int size, string mime_type)
			=> client.CallAsync<DocumentBase>(writer =>
			{
				writer.Write(0x338E2464);
				writer.WriteTLBytes(sha256);
				writer.Write(size);
				writer.WriteTLString(mime_type);
				return "Messages_GetDocumentByHash";
			});

		/// <summary>Get saved GIFs		<para>See <a href="https://corefork.telegram.org/method/messages.getSavedGifs"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.savedGifsNotModified">messages.savedGifsNotModified</a></returns>
		public static Task<Messages_SavedGifs> Messages_GetSavedGifs(this Client client, long hash)
			=> client.CallAsync<Messages_SavedGifs>(writer =>
			{
				writer.Write(0x5CF09635);
				writer.Write(hash);
				return "Messages_GetSavedGifs";
			});

		/// <summary>Add GIF to saved gifs list		<para>See <a href="https://corefork.telegram.org/method/messages.saveGif"/></para></summary>
		/// <param name="id">GIF to save</param>
		/// <param name="unsave">Whether to remove GIF from saved gifs list</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.saveGif#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_SaveGif(this Client client, InputDocument id, bool unsave)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x327A30CB);
				writer.WriteTLObject(id);
				writer.Write(unsave ? 0x997275B5 : 0xBC799737);
				return "Messages_SaveGif";
			});

		/// <summary>Query an inline bot		<para>See <a href="https://corefork.telegram.org/method/messages.getInlineBotResults"/></para></summary>
		/// <param name="bot">The bot to query</param>
		/// <param name="peer">The currently opened chat</param>
		/// <param name="geo_point">The geolocation, if requested</param>
		/// <param name="query">The query</param>
		/// <param name="offset">The offset within the results, will be passed directly as-is to the bot.</param>
		/// <exception cref="RpcException">Possible errors: -503,400 (<a href="https://corefork.telegram.org/method/messages.getInlineBotResults#possible-errors">details</a>)</exception>
		public static Task<Messages_BotResults> Messages_GetInlineBotResults(this Client client, InputUserBase bot, InputPeer peer, string query, string offset, InputGeoPoint geo_point = null)
			=> client.CallAsync<Messages_BotResults>(writer =>
			{
				writer.Write(0x514E999D);
				writer.Write(geo_point != null ? 0x1 : 0);
				writer.WriteTLObject(bot);
				writer.WriteTLObject(peer);
				if (geo_point != null)
					writer.WriteTLObject(geo_point);
				writer.WriteTLString(query);
				writer.WriteTLString(offset);
				return "Messages_GetInlineBotResults";
			});

		/// <summary>Answer an inline query, for bots only		<para>See <a href="https://corefork.telegram.org/method/messages.setInlineBotResults"/></para></summary>
		/// <param name="gallery">Set this flag if the results are composed of media files</param>
		/// <param name="private_">Set this flag if results may be cached on the server side only for the user that sent the query. By default, results may be returned to any user who sends the same query</param>
		/// <param name="query_id">Unique identifier for the answered query</param>
		/// <param name="results">Vector of results for the inline query</param>
		/// <param name="cache_time">The maximum amount of time in seconds that the result of the inline query may be cached on the server. Defaults to 300.</param>
		/// <param name="next_offset">Pass the offset that a client should send in the next query with the same text to receive more results. Pass an empty string if there are no more results or if you don‘t support pagination. Offset length can’t exceed 64 bytes.</param>
		/// <param name="switch_pm">If passed, clients will display a button with specified text that switches the user to a private chat with the bot and sends the bot a start message with a certain parameter.</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/messages.setInlineBotResults#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_SetInlineBotResults(this Client client, long query_id, InputBotInlineResultBase[] results, DateTime cache_time, bool gallery = false, bool private_ = false, string next_offset = null, InlineBotSwitchPM switch_pm = null)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xEB5EA206);
				writer.Write((gallery ? 0x1 : 0) | (private_ ? 0x2 : 0) | (next_offset != null ? 0x4 : 0) | (switch_pm != null ? 0x8 : 0));
				writer.Write(query_id);
				writer.WriteTLVector(results);
				writer.WriteTLStamp(cache_time);
				if (next_offset != null)
					writer.WriteTLString(next_offset);
				if (switch_pm != null)
					writer.WriteTLObject(switch_pm);
				return "Messages_SetInlineBotResults";
			});

		/// <summary>Send a result obtained using <a href="https://corefork.telegram.org/method/messages.getInlineBotResults">messages.getInlineBotResults</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.sendInlineBotResult"/></para></summary>
		/// <param name="silent">Whether to send the message silently (no notification will be triggered on the other client)</param>
		/// <param name="background">Whether to send the message in background</param>
		/// <param name="clear_draft">Whether to clear the <a href="https://corefork.telegram.org/api/drafts">draft</a></param>
		/// <param name="hide_via">Whether to hide the <c>via @botname</c> in the resulting message (only for bot usernames encountered in the <see cref="Config"/>)</param>
		/// <param name="peer">Destination</param>
		/// <param name="reply_to_msg_id">ID of the message this message should reply to</param>
		/// <param name="random_id">Random ID to avoid resending the same query</param>
		/// <param name="query_id">Query ID from <a href="https://corefork.telegram.org/method/messages.getInlineBotResults">messages.getInlineBotResults</a></param>
		/// <param name="id">Result ID from <a href="https://corefork.telegram.org/method/messages.getInlineBotResults">messages.getInlineBotResults</a></param>
		/// <param name="schedule_date">Scheduled message date for scheduled messages</param>
		/// <exception cref="RpcException">Possible errors: 400,403,420 (<a href="https://corefork.telegram.org/method/messages.sendInlineBotResult#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Messages_SendInlineBotResult(this Client client, InputPeer peer, long random_id, long query_id, string id, bool silent = false, bool background = false, bool clear_draft = false, bool hide_via = false, int? reply_to_msg_id = null, DateTime? schedule_date = null)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x220815B0);
				writer.Write((silent ? 0x20 : 0) | (background ? 0x40 : 0) | (clear_draft ? 0x80 : 0) | (hide_via ? 0x800 : 0) | (reply_to_msg_id != null ? 0x1 : 0) | (schedule_date != null ? 0x400 : 0));
				writer.WriteTLObject(peer);
				if (reply_to_msg_id != null)
					writer.Write(reply_to_msg_id.Value);
				writer.Write(random_id);
				writer.Write(query_id);
				writer.WriteTLString(id);
				if (schedule_date != null)
					writer.WriteTLStamp(schedule_date.Value);
				return "Messages_SendInlineBotResult";
			});

		/// <summary>Find out if a media message's caption can be edited		<para>See <a href="https://corefork.telegram.org/method/messages.getMessageEditData"/></para></summary>
		/// <param name="peer">Peer where the media was sent</param>
		/// <param name="id">ID of message</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/messages.getMessageEditData#possible-errors">details</a>)</exception>
		public static Task<Messages_MessageEditData> Messages_GetMessageEditData(this Client client, InputPeer peer, int id)
			=> client.CallAsync<Messages_MessageEditData>(writer =>
			{
				writer.Write(0xFDA68D36);
				writer.WriteTLObject(peer);
				writer.Write(id);
				return "Messages_GetMessageEditData";
			});

		/// <summary>Edit message		<para>See <a href="https://corefork.telegram.org/method/messages.editMessage"/></para></summary>
		/// <param name="no_webpage">Disable webpage preview</param>
		/// <param name="peer">Where was the message sent</param>
		/// <param name="id">ID of the message to edit</param>
		/// <param name="message">New message</param>
		/// <param name="media">New attached media</param>
		/// <param name="reply_markup">Reply markup for inline keyboards</param>
		/// <param name="entities"><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></param>
		/// <param name="schedule_date">Scheduled message date for <a href="https://corefork.telegram.org/api/scheduled-messages">scheduled messages</a></param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/messages.editMessage#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Messages_EditMessage(this Client client, InputPeer peer, int id, bool no_webpage = false, string message = null, InputMedia media = null, ReplyMarkup reply_markup = null, MessageEntity[] entities = null, DateTime? schedule_date = null)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x48F71778);
				writer.Write((no_webpage ? 0x2 : 0) | (message != null ? 0x800 : 0) | (media != null ? 0x4000 : 0) | (reply_markup != null ? 0x4 : 0) | (entities != null ? 0x8 : 0) | (schedule_date != null ? 0x8000 : 0));
				writer.WriteTLObject(peer);
				writer.Write(id);
				if (message != null)
					writer.WriteTLString(message);
				if (media != null)
					writer.WriteTLObject(media);
				if (reply_markup != null)
					writer.WriteTLObject(reply_markup);
				if (entities != null)
					writer.WriteTLVector(entities);
				if (schedule_date != null)
					writer.WriteTLStamp(schedule_date.Value);
				return "Messages_EditMessage";
			});

		/// <summary>Edit an inline bot message		<para>See <a href="https://corefork.telegram.org/method/messages.editInlineBotMessage"/></para></summary>
		/// <param name="no_webpage">Disable webpage preview</param>
		/// <param name="id">Sent inline message ID</param>
		/// <param name="message">Message</param>
		/// <param name="media">Media</param>
		/// <param name="reply_markup">Reply markup for inline keyboards</param>
		/// <param name="entities"><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.editInlineBotMessage#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_EditInlineBotMessage(this Client client, InputBotInlineMessageIDBase id, bool no_webpage = false, string message = null, InputMedia media = null, ReplyMarkup reply_markup = null, MessageEntity[] entities = null)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x83557DBA);
				writer.Write((no_webpage ? 0x2 : 0) | (message != null ? 0x800 : 0) | (media != null ? 0x4000 : 0) | (reply_markup != null ? 0x4 : 0) | (entities != null ? 0x8 : 0));
				writer.WriteTLObject(id);
				if (message != null)
					writer.WriteTLString(message);
				if (media != null)
					writer.WriteTLObject(media);
				if (reply_markup != null)
					writer.WriteTLObject(reply_markup);
				if (entities != null)
					writer.WriteTLVector(entities);
				return "Messages_EditInlineBotMessage";
			});

		/// <summary>Press an inline callback button and get a callback answer from the bot		<para>See <a href="https://corefork.telegram.org/method/messages.getBotCallbackAnswer"/></para></summary>
		/// <param name="game">Whether this is a "play game" button</param>
		/// <param name="peer">Where was the inline keyboard sent</param>
		/// <param name="msg_id">ID of the Message with the inline keyboard</param>
		/// <param name="data">Callback data</param>
		/// <param name="password">For buttons <see cref="KeyboardButtonCallback"/>, the SRP payload generated using <a href="https://corefork.telegram.org/api/srp">SRP</a>.</param>
		/// <exception cref="RpcException">Possible errors: -503,400 (<a href="https://corefork.telegram.org/method/messages.getBotCallbackAnswer#possible-errors">details</a>)</exception>
		public static Task<Messages_BotCallbackAnswer> Messages_GetBotCallbackAnswer(this Client client, InputPeer peer, int msg_id, bool game = false, byte[] data = null, InputCheckPasswordSRP password = null)
			=> client.CallAsync<Messages_BotCallbackAnswer>(writer =>
			{
				writer.Write(0x9342CA07);
				writer.Write((game ? 0x2 : 0) | (data != null ? 0x1 : 0) | (password != null ? 0x4 : 0));
				writer.WriteTLObject(peer);
				writer.Write(msg_id);
				if (data != null)
					writer.WriteTLBytes(data);
				if (password != null)
					writer.WriteTLObject(password);
				return "Messages_GetBotCallbackAnswer";
			});

		/// <summary>Set the callback answer to a user button press (bots only)		<para>See <a href="https://corefork.telegram.org/method/messages.setBotCallbackAnswer"/></para></summary>
		/// <param name="alert">Whether to show the message as a popup instead of a toast notification</param>
		/// <param name="query_id">Query ID</param>
		/// <param name="message">Popup to show</param>
		/// <param name="url">URL to open</param>
		/// <param name="cache_time">Cache validity</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.setBotCallbackAnswer#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_SetBotCallbackAnswer(this Client client, long query_id, DateTime cache_time, bool alert = false, string message = null, string url = null)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xD58F130A);
				writer.Write((alert ? 0x2 : 0) | (message != null ? 0x1 : 0) | (url != null ? 0x4 : 0));
				writer.Write(query_id);
				if (message != null)
					writer.WriteTLString(message);
				if (url != null)
					writer.WriteTLString(url);
				writer.WriteTLStamp(cache_time);
				return "Messages_SetBotCallbackAnswer";
			});

		/// <summary>Get dialog info of specified peers		<para>See <a href="https://corefork.telegram.org/method/messages.getPeerDialogs"/></para></summary>
		/// <param name="peers">Peers</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.getPeerDialogs#possible-errors">details</a>)</exception>
		public static Task<Messages_PeerDialogs> Messages_GetPeerDialogs(this Client client, InputDialogPeerBase[] peers)
			=> client.CallAsync<Messages_PeerDialogs>(writer =>
			{
				writer.Write(0xE470BCFD);
				writer.WriteTLVector(peers);
				return "Messages_GetPeerDialogs";
			});

		/// <summary>Save a message <a href="https://corefork.telegram.org/api/drafts">draft</a> associated to a chat.		<para>See <a href="https://corefork.telegram.org/method/messages.saveDraft"/></para></summary>
		/// <param name="no_webpage">Disable generation of the webpage preview</param>
		/// <param name="reply_to_msg_id">Message ID the message should reply to</param>
		/// <param name="peer">Destination of the message that should be sent</param>
		/// <param name="message">The draft</param>
		/// <param name="entities">Message <a href="https://corefork.telegram.org/api/entities">entities</a> for styled text</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.saveDraft#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_SaveDraft(this Client client, InputPeer peer, string message, bool no_webpage = false, int? reply_to_msg_id = null, MessageEntity[] entities = null)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xBC39E14B);
				writer.Write((no_webpage ? 0x2 : 0) | (reply_to_msg_id != null ? 0x1 : 0) | (entities != null ? 0x8 : 0));
				if (reply_to_msg_id != null)
					writer.Write(reply_to_msg_id.Value);
				writer.WriteTLObject(peer);
				writer.WriteTLString(message);
				if (entities != null)
					writer.WriteTLVector(entities);
				return "Messages_SaveDraft";
			});

		/// <summary>Save get all message <a href="https://corefork.telegram.org/api/drafts">drafts</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.getAllDrafts"/></para></summary>
		public static Task<UpdatesBase> Messages_GetAllDrafts(this Client client)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x6A3F8D65);
				return "Messages_GetAllDrafts";
			});

		/// <summary>Get featured stickers		<para>See <a href="https://corefork.telegram.org/method/messages.getFeaturedStickers"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		public static Task<Messages_FeaturedStickersBase> Messages_GetFeaturedStickers(this Client client, long hash)
			=> client.CallAsync<Messages_FeaturedStickersBase>(writer =>
			{
				writer.Write(0x64780B14);
				writer.Write(hash);
				return "Messages_GetFeaturedStickers";
			});

		/// <summary>Mark new featured stickers as read		<para>See <a href="https://corefork.telegram.org/method/messages.readFeaturedStickers"/></para></summary>
		/// <param name="id">IDs of stickersets to mark as read</param>
		public static Task<bool> Messages_ReadFeaturedStickers(this Client client, long[] id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x5B118126);
				writer.WriteTLVector(id);
				return "Messages_ReadFeaturedStickers";
			});

		/// <summary>Get recent stickers		<para>See <a href="https://corefork.telegram.org/method/messages.getRecentStickers"/></para></summary>
		/// <param name="attached">Get stickers recently attached to photo or video files</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.recentStickersNotModified">messages.recentStickersNotModified</a></returns>
		public static Task<Messages_RecentStickers> Messages_GetRecentStickers(this Client client, long hash, bool attached = false)
			=> client.CallAsync<Messages_RecentStickers>(writer =>
			{
				writer.Write(0x9DA9403B);
				writer.Write(attached ? 0x1 : 0);
				writer.Write(hash);
				return "Messages_GetRecentStickers";
			});

		/// <summary>Add/remove sticker from recent stickers list		<para>See <a href="https://corefork.telegram.org/method/messages.saveRecentSticker"/></para></summary>
		/// <param name="attached">Whether to add/remove stickers recently attached to photo or video files</param>
		/// <param name="id">Sticker</param>
		/// <param name="unsave">Whether to save or unsave the sticker</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.saveRecentSticker#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_SaveRecentSticker(this Client client, InputDocument id, bool unsave, bool attached = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x392718F8);
				writer.Write(attached ? 0x1 : 0);
				writer.WriteTLObject(id);
				writer.Write(unsave ? 0x997275B5 : 0xBC799737);
				return "Messages_SaveRecentSticker";
			});

		/// <summary>Clear recent stickers		<para>See <a href="https://corefork.telegram.org/method/messages.clearRecentStickers"/></para></summary>
		/// <param name="attached">Set this flag to clear the list of stickers recently attached to photo or video files</param>
		public static Task<bool> Messages_ClearRecentStickers(this Client client, bool attached = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x8999602D);
				writer.Write(attached ? 0x1 : 0);
				return "Messages_ClearRecentStickers";
			});

		/// <summary>Get all archived stickers		<para>See <a href="https://corefork.telegram.org/method/messages.getArchivedStickers"/></para></summary>
		/// <param name="masks">Get mask stickers</param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Messages_ArchivedStickers> Messages_GetArchivedStickers(this Client client, long offset_id, int limit, bool masks = false)
			=> client.CallAsync<Messages_ArchivedStickers>(writer =>
			{
				writer.Write(0x57F17692);
				writer.Write(masks ? 0x1 : 0);
				writer.Write(offset_id);
				writer.Write(limit);
				return "Messages_GetArchivedStickers";
			});

		/// <summary>Get installed mask stickers		<para>See <a href="https://corefork.telegram.org/method/messages.getMaskStickers"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.allStickersNotModified">messages.allStickersNotModified</a></returns>
		public static Task<Messages_AllStickers> Messages_GetMaskStickers(this Client client, long hash)
			=> client.CallAsync<Messages_AllStickers>(writer =>
			{
				writer.Write(0x640F82B8);
				writer.Write(hash);
				return "Messages_GetMaskStickers";
			});

		/// <summary>Get stickers attached to a photo or video		<para>See <a href="https://corefork.telegram.org/method/messages.getAttachedStickers"/></para></summary>
		/// <param name="media">Stickered media</param>
		public static Task<StickerSetCoveredBase[]> Messages_GetAttachedStickers(this Client client, InputStickeredMedia media)
			=> client.CallAsync<StickerSetCoveredBase[]>(writer =>
			{
				writer.Write(0xCC5B67CC);
				writer.WriteTLObject(media);
				return "Messages_GetAttachedStickers";
			});

		/// <summary>Use this method to set the score of the specified user in a game sent as a normal message (bots only).		<para>See <a href="https://corefork.telegram.org/method/messages.setGameScore"/></para></summary>
		/// <param name="edit_message">Set this flag if the game message should be automatically edited to include the current scoreboard</param>
		/// <param name="force">Set this flag if the high score is allowed to decrease. This can be useful when fixing mistakes or banning cheaters</param>
		/// <param name="peer">Unique identifier of target chat</param>
		/// <param name="id">Identifier of the sent message</param>
		/// <param name="user_id">User identifier</param>
		/// <param name="score">New score</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.setGameScore#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Messages_SetGameScore(this Client client, InputPeer peer, int id, InputUserBase user_id, int score, bool edit_message = false, bool force = false)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x8EF8ECC0);
				writer.Write((edit_message ? 0x1 : 0) | (force ? 0x2 : 0));
				writer.WriteTLObject(peer);
				writer.Write(id);
				writer.WriteTLObject(user_id);
				writer.Write(score);
				return "Messages_SetGameScore";
			});

		/// <summary>Use this method to set the score of the specified user in a game sent as an inline message (bots only).		<para>See <a href="https://corefork.telegram.org/method/messages.setInlineGameScore"/></para></summary>
		/// <param name="edit_message">Set this flag if the game message should be automatically edited to include the current scoreboard</param>
		/// <param name="force">Set this flag if the high score is allowed to decrease. This can be useful when fixing mistakes or banning cheaters</param>
		/// <param name="id">ID of the inline message</param>
		/// <param name="user_id">User identifier</param>
		/// <param name="score">New score</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.setInlineGameScore#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_SetInlineGameScore(this Client client, InputBotInlineMessageIDBase id, InputUserBase user_id, int score, bool edit_message = false, bool force = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x15AD9F64);
				writer.Write((edit_message ? 0x1 : 0) | (force ? 0x2 : 0));
				writer.WriteTLObject(id);
				writer.WriteTLObject(user_id);
				writer.Write(score);
				return "Messages_SetInlineGameScore";
			});

		/// <summary>Get highscores of a game		<para>See <a href="https://corefork.telegram.org/method/messages.getGameHighScores"/></para></summary>
		/// <param name="peer">Where was the game sent</param>
		/// <param name="id">ID of message with game media attachment</param>
		/// <param name="user_id">Get high scores made by a certain user</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.getGameHighScores#possible-errors">details</a>)</exception>
		public static Task<Messages_HighScores> Messages_GetGameHighScores(this Client client, InputPeer peer, int id, InputUserBase user_id)
			=> client.CallAsync<Messages_HighScores>(writer =>
			{
				writer.Write(0xE822649D);
				writer.WriteTLObject(peer);
				writer.Write(id);
				writer.WriteTLObject(user_id);
				return "Messages_GetGameHighScores";
			});

		/// <summary>Get highscores of a game sent using an inline bot		<para>See <a href="https://corefork.telegram.org/method/messages.getInlineGameHighScores"/></para></summary>
		/// <param name="id">ID of inline message</param>
		/// <param name="user_id">Get high scores of a certain user</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.getInlineGameHighScores#possible-errors">details</a>)</exception>
		public static Task<Messages_HighScores> Messages_GetInlineGameHighScores(this Client client, InputBotInlineMessageIDBase id, InputUserBase user_id)
			=> client.CallAsync<Messages_HighScores>(writer =>
			{
				writer.Write(0x0F635E1B);
				writer.WriteTLObject(id);
				writer.WriteTLObject(user_id);
				return "Messages_GetInlineGameHighScores";
			});

		/// <summary>Get chats in common with a user		<para>See <a href="https://corefork.telegram.org/method/messages.getCommonChats"/></para></summary>
		/// <param name="user_id">User ID</param>
		/// <param name="max_id">Maximum ID of chat to return (see <a href="https://corefork.telegram.org/api/offsets">pagination</a>)</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.getCommonChats#possible-errors">details</a>)</exception>
		public static Task<Messages_Chats> Messages_GetCommonChats(this Client client, InputUserBase user_id, long max_id, int limit)
			=> client.CallAsync<Messages_Chats>(writer =>
			{
				writer.Write(0xE40CA104);
				writer.WriteTLObject(user_id);
				writer.Write(max_id);
				writer.Write(limit);
				return "Messages_GetCommonChats";
			});

		/// <summary>Get all chats, channels and supergroups		<para>See <a href="https://corefork.telegram.org/method/messages.getAllChats"/></para></summary>
		/// <param name="except_ids">Except these chats/channels/supergroups</param>
		public static Task<Messages_Chats> Messages_GetAllChats(this Client client, long[] except_ids)
			=> client.CallAsync<Messages_Chats>(writer =>
			{
				writer.Write(0x875F74BE);
				writer.WriteTLVector(except_ids);
				return "Messages_GetAllChats";
			});

		/// <summary>Get <a href="https://instantview.telegram.org">instant view</a> page		<para>See <a href="https://corefork.telegram.org/method/messages.getWebPage"/></para></summary>
		/// <param name="url">URL of IV page to fetch</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.getWebPage#possible-errors">details</a>)</exception>
		public static Task<WebPageBase> Messages_GetWebPage(this Client client, string url, int hash)
			=> client.CallAsync<WebPageBase>(writer =>
			{
				writer.Write(0x32CA8F91);
				writer.WriteTLString(url);
				writer.Write(hash);
				return "Messages_GetWebPage";
			});

		/// <summary>Pin/unpin a dialog		<para>See <a href="https://corefork.telegram.org/method/messages.toggleDialogPin"/></para></summary>
		/// <param name="pinned">Whether to pin or unpin the dialog</param>
		/// <param name="peer">The dialog to pin</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.toggleDialogPin#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_ToggleDialogPin(this Client client, InputDialogPeerBase peer, bool pinned = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xA731E257);
				writer.Write(pinned ? 0x1 : 0);
				writer.WriteTLObject(peer);
				return "Messages_ToggleDialogPin";
			});

		/// <summary>Reorder pinned dialogs		<para>See <a href="https://corefork.telegram.org/method/messages.reorderPinnedDialogs"/></para></summary>
		/// <param name="force">If set, dialogs pinned server-side but not present in the <c>order</c> field will be unpinned.</param>
		/// <param name="folder_id"><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></param>
		/// <param name="order">New dialog order</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.reorderPinnedDialogs#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_ReorderPinnedDialogs(this Client client, int folder_id, InputDialogPeerBase[] order, bool force = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x3B1ADF37);
				writer.Write(force ? 0x1 : 0);
				writer.Write(folder_id);
				writer.WriteTLVector(order);
				return "Messages_ReorderPinnedDialogs";
			});

		/// <summary>Get pinned dialogs		<para>See <a href="https://corefork.telegram.org/method/messages.getPinnedDialogs"/></para></summary>
		/// <param name="folder_id"><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.getPinnedDialogs#possible-errors">details</a>)</exception>
		public static Task<Messages_PeerDialogs> Messages_GetPinnedDialogs(this Client client, int folder_id)
			=> client.CallAsync<Messages_PeerDialogs>(writer =>
			{
				writer.Write(0xD6B94DF2);
				writer.Write(folder_id);
				return "Messages_GetPinnedDialogs";
			});

		/// <summary>If you sent an invoice requesting a shipping address and the parameter is_flexible was specified, the bot will receive an <see cref="UpdateBotShippingQuery"/> update. Use this method to reply to shipping queries.		<para>See <a href="https://corefork.telegram.org/method/messages.setBotShippingResults"/></para></summary>
		/// <param name="query_id">Unique identifier for the query to be answered</param>
		/// <param name="error">Error message in human readable form that explains why it is impossible to complete the order (e.g. "Sorry, delivery to your desired address is unavailable'). Telegram will display this message to the user.</param>
		/// <param name="shipping_options">A vector of available shipping options.</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.setBotShippingResults#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_SetBotShippingResults(this Client client, long query_id, string error = null, ShippingOption[] shipping_options = null)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xE5F672FA);
				writer.Write((error != null ? 0x1 : 0) | (shipping_options != null ? 0x2 : 0));
				writer.Write(query_id);
				if (error != null)
					writer.WriteTLString(error);
				if (shipping_options != null)
					writer.WriteTLVector(shipping_options);
				return "Messages_SetBotShippingResults";
			});

		/// <summary>Once the user has confirmed their payment and shipping details, the bot receives an <see cref="UpdateBotPrecheckoutQuery"/> update.<br/>Use this method to respond to such pre-checkout queries.<br/><strong>Note</strong>: Telegram must receive an answer within 10 seconds after the pre-checkout query was sent.		<para>See <a href="https://corefork.telegram.org/method/messages.setBotPrecheckoutResults"/></para></summary>
		/// <param name="success">Set this flag if everything is alright (goods are available, etc.) and the bot is ready to proceed with the order, otherwise do not set it, and set the <c>error</c> field, instead</param>
		/// <param name="query_id">Unique identifier for the query to be answered</param>
		/// <param name="error">Required if the <c>success</c> isn't set. Error message in human readable form that explains the reason for failure to proceed with the checkout (e.g. "Sorry, somebody just bought the last of our amazing black T-shirts while you were busy filling out your payment details. Please choose a different color or garment!"). Telegram will display this message to the user.</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.setBotPrecheckoutResults#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_SetBotPrecheckoutResults(this Client client, long query_id, bool success = false, string error = null)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x09C2DD95);
				writer.Write((success ? 0x2 : 0) | (error != null ? 0x1 : 0));
				writer.Write(query_id);
				if (error != null)
					writer.WriteTLString(error);
				return "Messages_SetBotPrecheckoutResults";
			});

		/// <summary>Upload a file and associate it to a chat (without actually sending it to the chat)		<para>See <a href="https://corefork.telegram.org/method/messages.uploadMedia"/></para></summary>
		/// <param name="peer">The chat, can be an <see langword="null"/> for bots</param>
		/// <param name="media">File uploaded in chunks as described in <a href="https://corefork.telegram.org/api/files">files »</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messageMediaEmpty">messageMediaEmpty</a></returns>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/messages.uploadMedia#possible-errors">details</a>)</exception>
		public static Task<MessageMedia> Messages_UploadMedia(this Client client, InputPeer peer, InputMedia media)
			=> client.CallAsync<MessageMedia>(writer =>
			{
				writer.Write(0x519BC2B1);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(media);
				return "Messages_UploadMedia";
			});

		/// <summary>Notify the other user in a private chat that a screenshot of the chat was taken		<para>See <a href="https://corefork.telegram.org/method/messages.sendScreenshotNotification"/></para></summary>
		/// <param name="peer">Other user</param>
		/// <param name="reply_to_msg_id">ID of message that was screenshotted, can be 0</param>
		/// <param name="random_id">Random ID to avoid message resending</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.sendScreenshotNotification#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Messages_SendScreenshotNotification(this Client client, InputPeer peer, int reply_to_msg_id, long random_id)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xC97DF020);
				writer.WriteTLObject(peer);
				writer.Write(reply_to_msg_id);
				writer.Write(random_id);
				return "Messages_SendScreenshotNotification";
			});

		/// <summary>Get faved stickers		<para>See <a href="https://corefork.telegram.org/method/messages.getFavedStickers"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.favedStickersNotModified">messages.favedStickersNotModified</a></returns>
		public static Task<Messages_FavedStickers> Messages_GetFavedStickers(this Client client, long hash)
			=> client.CallAsync<Messages_FavedStickers>(writer =>
			{
				writer.Write(0x04F1AAA9);
				writer.Write(hash);
				return "Messages_GetFavedStickers";
			});

		/// <summary>Mark a sticker as favorite		<para>See <a href="https://corefork.telegram.org/method/messages.faveSticker"/></para></summary>
		/// <param name="id">Sticker to mark as favorite</param>
		/// <param name="unfave">Unfavorite</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.faveSticker#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_FaveSticker(this Client client, InputDocument id, bool unfave)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xB9FFC55B);
				writer.WriteTLObject(id);
				writer.Write(unfave ? 0x997275B5 : 0xBC799737);
				return "Messages_FaveSticker";
			});

		/// <summary>Get unread messages where we were mentioned		<para>See <a href="https://corefork.telegram.org/method/messages.getUnreadMentions"/></para></summary>
		/// <param name="peer">Peer where to look for mentions</param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="add_offset"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <param name="max_id">Maximum message ID to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <param name="min_id">Minimum message ID to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.getUnreadMentions#possible-errors">details</a>)</exception>
		public static Task<Messages_MessagesBase> Messages_GetUnreadMentions(this Client client, InputPeer peer, int offset_id, int add_offset, int limit, int max_id, int min_id)
			=> client.CallAsync<Messages_MessagesBase>(writer =>
			{
				writer.Write(0x46578472);
				writer.WriteTLObject(peer);
				writer.Write(offset_id);
				writer.Write(add_offset);
				writer.Write(limit);
				writer.Write(max_id);
				writer.Write(min_id);
				return "Messages_GetUnreadMentions";
			});

		/// <summary>Mark mentions as read		<para>See <a href="https://corefork.telegram.org/method/messages.readMentions"/></para></summary>
		/// <param name="peer">Dialog</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.readMentions#possible-errors">details</a>)</exception>
		public static Task<Messages_AffectedHistory> Messages_ReadMentions(this Client client, InputPeer peer)
			=> client.CallAsync<Messages_AffectedHistory>(writer =>
			{
				writer.Write(0x0F0189D3);
				writer.WriteTLObject(peer);
				return "Messages_ReadMentions";
			});

		/// <summary>Get live location history of a certain user		<para>See <a href="https://corefork.telegram.org/method/messages.getRecentLocations"/></para></summary>
		/// <param name="peer">User</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		public static Task<Messages_MessagesBase> Messages_GetRecentLocations(this Client client, InputPeer peer, int limit, long hash)
			=> client.CallAsync<Messages_MessagesBase>(writer =>
			{
				writer.Write(0x702A40E0);
				writer.WriteTLObject(peer);
				writer.Write(limit);
				writer.Write(hash);
				return "Messages_GetRecentLocations";
			});

		/// <summary>Send an <a href="https://corefork.telegram.org/api/files#albums-grouped-media">album or grouped media</a>		<para>See <a href="https://corefork.telegram.org/method/messages.sendMultiMedia"/></para></summary>
		/// <param name="silent">Whether to send the album silently (no notification triggered)</param>
		/// <param name="background">Send in background?</param>
		/// <param name="clear_draft">Whether to clear <a href="https://corefork.telegram.org/api/drafts">drafts</a></param>
		/// <param name="peer">The destination chat</param>
		/// <param name="reply_to_msg_id">The message to reply to</param>
		/// <param name="multi_media">The medias to send</param>
		/// <param name="schedule_date">Scheduled message date for scheduled messages</param>
		/// <exception cref="RpcException">Possible errors: 400,420 (<a href="https://corefork.telegram.org/method/messages.sendMultiMedia#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Messages_SendMultiMedia(this Client client, InputPeer peer, InputSingleMedia[] multi_media, bool silent = false, bool background = false, bool clear_draft = false, int? reply_to_msg_id = null, DateTime? schedule_date = null)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xCC0110CB);
				writer.Write((silent ? 0x20 : 0) | (background ? 0x40 : 0) | (clear_draft ? 0x80 : 0) | (reply_to_msg_id != null ? 0x1 : 0) | (schedule_date != null ? 0x400 : 0));
				writer.WriteTLObject(peer);
				if (reply_to_msg_id != null)
					writer.Write(reply_to_msg_id.Value);
				writer.WriteTLVector(multi_media);
				if (schedule_date != null)
					writer.WriteTLStamp(schedule_date.Value);
				return "Messages_SendMultiMedia";
			});

		/// <summary>Upload encrypted file and associate it to a secret chat		<para>See <a href="https://corefork.telegram.org/method/messages.uploadEncryptedFile"/></para></summary>
		/// <param name="peer">The secret chat to associate the file to</param>
		/// <param name="file">The file</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/encryptedFileEmpty">encryptedFileEmpty</a></returns>
		public static Task<EncryptedFile> Messages_UploadEncryptedFile(this Client client, InputEncryptedChat peer, InputEncryptedFileBase file)
			=> client.CallAsync<EncryptedFile>(writer =>
			{
				writer.Write(0x5057C497);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(file);
				return "Messages_UploadEncryptedFile";
			});

		/// <summary>Search for stickersets		<para>See <a href="https://corefork.telegram.org/method/messages.searchStickerSets"/></para></summary>
		/// <param name="exclude_featured">Exclude featured stickersets from results</param>
		/// <param name="q">Query string</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.foundStickerSetsNotModified">messages.foundStickerSetsNotModified</a></returns>
		public static Task<Messages_FoundStickerSets> Messages_SearchStickerSets(this Client client, string q, long hash, bool exclude_featured = false)
			=> client.CallAsync<Messages_FoundStickerSets>(writer =>
			{
				writer.Write(0x35705B8A);
				writer.Write(exclude_featured ? 0x1 : 0);
				writer.WriteTLString(q);
				writer.Write(hash);
				return "Messages_SearchStickerSets";
			});

		/// <summary>Get message ranges for saving the user's chat history		<para>See <a href="https://corefork.telegram.org/method/messages.getSplitRanges"/></para></summary>
		public static Task<MessageRange[]> Messages_GetSplitRanges(this Client client)
			=> client.CallAsync<MessageRange[]>(writer =>
			{
				writer.Write(0x1CFF7E08);
				return "Messages_GetSplitRanges";
			});

		/// <summary>Manually mark dialog as unread		<para>See <a href="https://corefork.telegram.org/method/messages.markDialogUnread"/></para></summary>
		/// <param name="unread">Mark as unread/read</param>
		/// <param name="peer">Dialog</param>
		public static Task<bool> Messages_MarkDialogUnread(this Client client, InputDialogPeerBase peer, bool unread = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xC286D98F);
				writer.Write(unread ? 0x1 : 0);
				writer.WriteTLObject(peer);
				return "Messages_MarkDialogUnread";
			});

		/// <summary>Get dialogs manually marked as unread		<para>See <a href="https://corefork.telegram.org/method/messages.getDialogUnreadMarks"/></para></summary>
		public static Task<DialogPeerBase[]> Messages_GetDialogUnreadMarks(this Client client)
			=> client.CallAsync<DialogPeerBase[]>(writer =>
			{
				writer.Write(0x22E24E22);
				return "Messages_GetDialogUnreadMarks";
			});

		/// <summary>Clear all <a href="https://corefork.telegram.org/api/drafts">drafts</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.clearAllDrafts"/></para></summary>
		public static Task<bool> Messages_ClearAllDrafts(this Client client)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x7E58EE9C);
				return "Messages_ClearAllDrafts";
			});

		/// <summary>Pin a message		<para>See <a href="https://corefork.telegram.org/method/messages.updatePinnedMessage"/></para></summary>
		/// <param name="silent">Pin the message silently, without triggering a notification</param>
		/// <param name="unpin">Whether the message should unpinned or pinned</param>
		/// <param name="pm_oneside">Whether the message should only be pinned on the local side of a one-to-one chat</param>
		/// <param name="peer">The peer where to pin the message</param>
		/// <param name="id">The message to pin or unpin</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/messages.updatePinnedMessage#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Messages_UpdatePinnedMessage(this Client client, InputPeer peer, int id, bool silent = false, bool unpin = false, bool pm_oneside = false)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xD2AAF7EC);
				writer.Write((silent ? 0x1 : 0) | (unpin ? 0x2 : 0) | (pm_oneside ? 0x4 : 0));
				writer.WriteTLObject(peer);
				writer.Write(id);
				return "Messages_UpdatePinnedMessage";
			});

		/// <summary>Vote in a <see cref="Poll"/>		<para>See <a href="https://corefork.telegram.org/method/messages.sendVote"/></para></summary>
		/// <param name="peer">The chat where the poll was sent</param>
		/// <param name="msg_id">The message ID of the poll</param>
		/// <param name="options">The options that were chosen</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.sendVote#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Messages_SendVote(this Client client, InputPeer peer, int msg_id, byte[][] options)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x10EA6184);
				writer.WriteTLObject(peer);
				writer.Write(msg_id);
				writer.WriteTLVector(options);
				return "Messages_SendVote";
			});

		/// <summary>Get poll results		<para>See <a href="https://corefork.telegram.org/method/messages.getPollResults"/></para></summary>
		/// <param name="peer">Peer where the poll was found</param>
		/// <param name="msg_id">Message ID of poll message</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.getPollResults#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Messages_GetPollResults(this Client client, InputPeer peer, int msg_id)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x73BB643B);
				writer.WriteTLObject(peer);
				writer.Write(msg_id);
				return "Messages_GetPollResults";
			});

		/// <summary>Get count of online users in a chat		<para>See <a href="https://corefork.telegram.org/method/messages.getOnlines"/></para></summary>
		/// <param name="peer">The chat</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.getOnlines#possible-errors">details</a>)</exception>
		public static Task<ChatOnlines> Messages_GetOnlines(this Client client, InputPeer peer)
			=> client.CallAsync<ChatOnlines>(writer =>
			{
				writer.Write(0x6E2BE050);
				writer.WriteTLObject(peer);
				return "Messages_GetOnlines";
			});

		/// <summary>Edit the description of a <a href="https://corefork.telegram.org/api/channel">group/supergroup/channel</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.editChatAbout"/></para></summary>
		/// <param name="peer">The <a href="https://corefork.telegram.org/api/channel">group/supergroup/channel</a>.</param>
		/// <param name="about">The new description</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/messages.editChatAbout#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_EditChatAbout(this Client client, InputPeer peer, string about)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xDEF60797);
				writer.WriteTLObject(peer);
				writer.WriteTLString(about);
				return "Messages_EditChatAbout";
			});

		/// <summary>Edit the default banned rights of a <a href="https://corefork.telegram.org/api/channel">channel/supergroup/group</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.editChatDefaultBannedRights"/></para></summary>
		/// <param name="peer">The peer</param>
		/// <param name="banned_rights">The new global rights</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/messages.editChatDefaultBannedRights#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Messages_EditChatDefaultBannedRights(this Client client, InputPeer peer, ChatBannedRights banned_rights)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xA5866B41);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(banned_rights);
				return "Messages_EditChatDefaultBannedRights";
			});

		/// <summary>Get localized emoji keywords		<para>See <a href="https://corefork.telegram.org/method/messages.getEmojiKeywords"/></para></summary>
		/// <param name="lang_code">Language code</param>
		public static Task<EmojiKeywordsDifference> Messages_GetEmojiKeywords(this Client client, string lang_code)
			=> client.CallAsync<EmojiKeywordsDifference>(writer =>
			{
				writer.Write(0x35A0E062);
				writer.WriteTLString(lang_code);
				return "Messages_GetEmojiKeywords";
			});

		/// <summary>Get changed emoji keywords		<para>See <a href="https://corefork.telegram.org/method/messages.getEmojiKeywordsDifference"/></para></summary>
		/// <param name="lang_code">Language code</param>
		/// <param name="from_version">Previous emoji keyword localization version</param>
		public static Task<EmojiKeywordsDifference> Messages_GetEmojiKeywordsDifference(this Client client, string lang_code, int from_version)
			=> client.CallAsync<EmojiKeywordsDifference>(writer =>
			{
				writer.Write(0x1508B6AF);
				writer.WriteTLString(lang_code);
				writer.Write(from_version);
				return "Messages_GetEmojiKeywordsDifference";
			});

		/// <summary>Get info about an emoji keyword localization		<para>See <a href="https://corefork.telegram.org/method/messages.getEmojiKeywordsLanguages"/></para></summary>
		/// <param name="lang_codes">Language codes</param>
		public static Task<EmojiLanguage[]> Messages_GetEmojiKeywordsLanguages(this Client client, string[] lang_codes)
			=> client.CallAsync<EmojiLanguage[]>(writer =>
			{
				writer.Write(0x4E9963B2);
				writer.WriteTLVector(lang_codes);
				return "Messages_GetEmojiKeywordsLanguages";
			});

		/// <summary>Returns an HTTP URL which can be used to automatically log in into translation platform and suggest new emoji replacements. The URL will be valid for 30 seconds after generation		<para>See <a href="https://corefork.telegram.org/method/messages.getEmojiURL"/></para></summary>
		/// <param name="lang_code">Language code for which the emoji replacements will be suggested</param>
		public static Task<EmojiURL> Messages_GetEmojiURL(this Client client, string lang_code)
			=> client.CallAsync<EmojiURL>(writer =>
			{
				writer.Write(0xD5B10C26);
				writer.WriteTLString(lang_code);
				return "Messages_GetEmojiURL";
			});

		/// <summary>Get the number of results that would be found by a <a href="https://corefork.telegram.org/method/messages.search">messages.search</a> call with the same parameters		<para>See <a href="https://corefork.telegram.org/method/messages.getSearchCounters"/></para></summary>
		/// <param name="peer">Peer where to search</param>
		/// <param name="filters">Search filters</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.getSearchCounters#possible-errors">details</a>)</exception>
		public static Task<Messages_SearchCounter[]> Messages_GetSearchCounters(this Client client, InputPeer peer, MessagesFilter[] filters)
			=> client.CallAsync<Messages_SearchCounter[]>(writer =>
			{
				writer.Write(0x732EEF00);
				writer.WriteTLObject(peer);
				writer.WriteTLVector(filters);
				return "Messages_GetSearchCounters";
			});

		/// <summary>Get more info about a Seamless Telegram Login authorization request, for more info <a href="https://corefork.telegram.org/api/url-authorization">click here »</a>		<para>See <a href="https://corefork.telegram.org/method/messages.requestUrlAuth"/></para></summary>
		/// <param name="peer">Peer where the message is located</param>
		/// <param name="msg_id">The message</param>
		/// <param name="button_id">The ID of the button with the authorization request</param>
		/// <param name="url">URL used for <a href="https://corefork.telegram.org/api/url-authorization#link-url-authorization">link URL authorization, click here for more info »</a></param>
		public static Task<UrlAuthResult> Messages_RequestUrlAuth(this Client client, InputPeer peer = null, int? msg_id = null, int? button_id = null, string url = null)
			=> client.CallAsync<UrlAuthResult>(writer =>
			{
				writer.Write(0x198FB446);
				writer.Write((peer != null ? 0x2 : 0) | (msg_id != null ? 0x2 : 0) | (button_id != null ? 0x2 : 0) | (url != null ? 0x4 : 0));
				if (peer != null)
					writer.WriteTLObject(peer);
				if (msg_id != null)
					writer.Write(msg_id.Value);
				if (button_id != null)
					writer.Write(button_id.Value);
				if (url != null)
					writer.WriteTLString(url);
				return "Messages_RequestUrlAuth";
			});

		/// <summary>Use this to accept a Seamless Telegram Login authorization request, for more info <a href="https://corefork.telegram.org/api/url-authorization">click here »</a>		<para>See <a href="https://corefork.telegram.org/method/messages.acceptUrlAuth"/></para></summary>
		/// <param name="write_allowed">Set this flag to allow the bot to send messages to you (if requested)</param>
		/// <param name="peer">The location of the message</param>
		/// <param name="msg_id">Message ID of the message with the login button</param>
		/// <param name="button_id">ID of the login button</param>
		/// <param name="url">URL used for <a href="https://corefork.telegram.org/api/url-authorization#link-url-authorization">link URL authorization, click here for more info »</a></param>
		public static Task<UrlAuthResult> Messages_AcceptUrlAuth(this Client client, bool write_allowed = false, InputPeer peer = null, int? msg_id = null, int? button_id = null, string url = null)
			=> client.CallAsync<UrlAuthResult>(writer =>
			{
				writer.Write(0xB12C7125);
				writer.Write((write_allowed ? 0x1 : 0) | (peer != null ? 0x2 : 0) | (msg_id != null ? 0x2 : 0) | (button_id != null ? 0x2 : 0) | (url != null ? 0x4 : 0));
				if (peer != null)
					writer.WriteTLObject(peer);
				if (msg_id != null)
					writer.Write(msg_id.Value);
				if (button_id != null)
					writer.Write(button_id.Value);
				if (url != null)
					writer.WriteTLString(url);
				return "Messages_AcceptUrlAuth";
			});

		/// <summary>Should be called after the user hides the report spam/add as contact bar of a new chat, effectively prevents the user from executing the actions specified in the <see cref="PeerSettings"/>.		<para>See <a href="https://corefork.telegram.org/method/messages.hidePeerSettingsBar"/></para></summary>
		/// <param name="peer">Peer</param>
		public static Task<bool> Messages_HidePeerSettingsBar(this Client client, InputPeer peer)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x4FACB138);
				writer.WriteTLObject(peer);
				return "Messages_HidePeerSettingsBar";
			});

		/// <summary>Get scheduled messages		<para>See <a href="https://corefork.telegram.org/method/messages.getScheduledHistory"/></para></summary>
		/// <param name="peer">Peer</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.getScheduledHistory#possible-errors">details</a>)</exception>
		public static Task<Messages_MessagesBase> Messages_GetScheduledHistory(this Client client, InputPeer peer, long hash)
			=> client.CallAsync<Messages_MessagesBase>(writer =>
			{
				writer.Write(0xF516760B);
				writer.WriteTLObject(peer);
				writer.Write(hash);
				return "Messages_GetScheduledHistory";
			});

		/// <summary>Get scheduled messages		<para>See <a href="https://corefork.telegram.org/method/messages.getScheduledMessages"/></para></summary>
		/// <param name="peer">Peer</param>
		/// <param name="id">IDs of scheduled messages</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.getScheduledMessages#possible-errors">details</a>)</exception>
		public static Task<Messages_MessagesBase> Messages_GetScheduledMessages(this Client client, InputPeer peer, int[] id)
			=> client.CallAsync<Messages_MessagesBase>(writer =>
			{
				writer.Write(0xBDBB0464);
				writer.WriteTLObject(peer);
				writer.WriteTLVector(id);
				return "Messages_GetScheduledMessages";
			});

		/// <summary>Send scheduled messages right away		<para>See <a href="https://corefork.telegram.org/method/messages.sendScheduledMessages"/></para></summary>
		/// <param name="peer">Peer</param>
		/// <param name="id">Scheduled message IDs</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.sendScheduledMessages#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Messages_SendScheduledMessages(this Client client, InputPeer peer, int[] id)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xBD38850A);
				writer.WriteTLObject(peer);
				writer.WriteTLVector(id);
				return "Messages_SendScheduledMessages";
			});

		/// <summary>Delete scheduled messages		<para>See <a href="https://corefork.telegram.org/method/messages.deleteScheduledMessages"/></para></summary>
		/// <param name="peer">Peer</param>
		/// <param name="id">Scheduled message IDs</param>
		public static Task<UpdatesBase> Messages_DeleteScheduledMessages(this Client client, InputPeer peer, int[] id)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x59AE2B16);
				writer.WriteTLObject(peer);
				writer.WriteTLVector(id);
				return "Messages_DeleteScheduledMessages";
			});

		/// <summary>Get poll results for non-anonymous polls		<para>See <a href="https://corefork.telegram.org/method/messages.getPollVotes"/></para></summary>
		/// <param name="peer">Chat where the poll was sent</param>
		/// <param name="id">Message ID</param>
		/// <param name="option">Get only results for the specified poll <c>option</c></param>
		/// <param name="offset">Offset for results, taken from the <c>next_offset</c> field of <see cref="Messages_VotesList"/>, initially an empty string. <br/>Note: if no more results are available, the method call will return an empty <c>next_offset</c>; thus, avoid providing the <c>next_offset</c> returned in <see cref="Messages_VotesList"/> if it is empty, to avoid an infinite loop.</param>
		/// <param name="limit">Number of results to return</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/messages.getPollVotes#possible-errors">details</a>)</exception>
		public static Task<Messages_VotesList> Messages_GetPollVotes(this Client client, InputPeer peer, int id, int limit, byte[] option = null, string offset = null)
			=> client.CallAsync<Messages_VotesList>(writer =>
			{
				writer.Write(0xB86E380E);
				writer.Write((option != null ? 0x1 : 0) | (offset != null ? 0x2 : 0));
				writer.WriteTLObject(peer);
				writer.Write(id);
				if (option != null)
					writer.WriteTLBytes(option);
				if (offset != null)
					writer.WriteTLString(offset);
				writer.Write(limit);
				return "Messages_GetPollVotes";
			});

		/// <summary>Apply changes to multiple stickersets		<para>See <a href="https://corefork.telegram.org/method/messages.toggleStickerSets"/></para></summary>
		/// <param name="uninstall">Uninstall the specified stickersets</param>
		/// <param name="archive">Archive the specified stickersets</param>
		/// <param name="unarchive">Unarchive the specified stickersets</param>
		/// <param name="stickersets">Stickersets to act upon</param>
		public static Task<bool> Messages_ToggleStickerSets(this Client client, InputStickerSet[] stickersets, bool uninstall = false, bool archive = false, bool unarchive = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xB5052FEA);
				writer.Write((uninstall ? 0x1 : 0) | (archive ? 0x2 : 0) | (unarchive ? 0x4 : 0));
				writer.WriteTLVector(stickersets);
				return "Messages_ToggleStickerSets";
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/folders">folders</a>		<para>See <a href="https://corefork.telegram.org/method/messages.getDialogFilters"/></para></summary>
		public static Task<DialogFilter[]> Messages_GetDialogFilters(this Client client)
			=> client.CallAsync<DialogFilter[]>(writer =>
			{
				writer.Write(0xF19ED96D);
				return "Messages_GetDialogFilters";
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/folders">suggested folders</a>		<para>See <a href="https://corefork.telegram.org/method/messages.getSuggestedDialogFilters"/></para></summary>
		public static Task<DialogFilterSuggested[]> Messages_GetSuggestedDialogFilters(this Client client)
			=> client.CallAsync<DialogFilterSuggested[]>(writer =>
			{
				writer.Write(0xA29CD42C);
				return "Messages_GetSuggestedDialogFilters";
			});

		/// <summary>Update <a href="https://corefork.telegram.org/api/folders">folder</a>		<para>See <a href="https://corefork.telegram.org/method/messages.updateDialogFilter"/></para></summary>
		/// <param name="id"><a href="https://corefork.telegram.org/api/folders">Folder</a> ID</param>
		/// <param name="filter"><a href="https://corefork.telegram.org/api/folders">Folder</a> info</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.updateDialogFilter#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_UpdateDialogFilter(this Client client, int id, DialogFilter filter = null)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x1AD4A04A);
				writer.Write(filter != null ? 0x1 : 0);
				writer.Write(id);
				if (filter != null)
					writer.WriteTLObject(filter);
				return "Messages_UpdateDialogFilter";
			});

		/// <summary>Reorder <a href="https://corefork.telegram.org/api/folders">folders</a>		<para>See <a href="https://corefork.telegram.org/method/messages.updateDialogFiltersOrder"/></para></summary>
		/// <param name="order">New <a href="https://corefork.telegram.org/api/folders">folder</a> order</param>
		public static Task<bool> Messages_UpdateDialogFiltersOrder(this Client client, int[] order)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xC563C1E4);
				writer.WriteTLVector(order);
				return "Messages_UpdateDialogFiltersOrder";
			});

		/// <summary>Method for fetching previously featured stickers		<para>See <a href="https://corefork.telegram.org/method/messages.getOldFeaturedStickers"/></para></summary>
		/// <param name="offset">Offset</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		public static Task<Messages_FeaturedStickersBase> Messages_GetOldFeaturedStickers(this Client client, int offset, int limit, long hash)
			=> client.CallAsync<Messages_FeaturedStickersBase>(writer =>
			{
				writer.Write(0x7ED094A1);
				writer.Write(offset);
				writer.Write(limit);
				writer.Write(hash);
				return "Messages_GetOldFeaturedStickers";
			});

		/// <summary>Get messages in a reply thread		<para>See <a href="https://corefork.telegram.org/method/messages.getReplies"/></para></summary>
		/// <param name="peer">Peer</param>
		/// <param name="msg_id">Message ID</param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="offset_date"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="add_offset"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <param name="max_id">If a positive value was transferred, the method will return only messages with ID smaller than max_id</param>
		/// <param name="min_id">If a positive value was transferred, the method will return only messages with ID bigger than min_id</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.getReplies#possible-errors">details</a>)</exception>
		public static Task<Messages_MessagesBase> Messages_GetReplies(this Client client, InputPeer peer, int msg_id, int offset_id, DateTime offset_date, int add_offset, int limit, int max_id, int min_id, long hash)
			=> client.CallAsync<Messages_MessagesBase>(writer =>
			{
				writer.Write(0x22DDD30C);
				writer.WriteTLObject(peer);
				writer.Write(msg_id);
				writer.Write(offset_id);
				writer.WriteTLStamp(offset_date);
				writer.Write(add_offset);
				writer.Write(limit);
				writer.Write(max_id);
				writer.Write(min_id);
				writer.Write(hash);
				return "Messages_GetReplies";
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/threads">discussion message</a> from the <a href="https://corefork.telegram.org/api/discussion">associated discussion group</a> of a channel to show it on top of the comment section, without actually joining the group		<para>See <a href="https://corefork.telegram.org/method/messages.getDiscussionMessage"/></para></summary>
		/// <param name="peer"><a href="https://corefork.telegram.org/api/channel">Channel ID</a></param>
		/// <param name="msg_id">Message ID</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.getDiscussionMessage#possible-errors">details</a>)</exception>
		public static Task<Messages_DiscussionMessage> Messages_GetDiscussionMessage(this Client client, InputPeer peer, int msg_id)
			=> client.CallAsync<Messages_DiscussionMessage>(writer =>
			{
				writer.Write(0x446972FD);
				writer.WriteTLObject(peer);
				writer.Write(msg_id);
				return "Messages_GetDiscussionMessage";
			});

		/// <summary>Mark a <a href="https://corefork.telegram.org/api/threads">thread</a> as read		<para>See <a href="https://corefork.telegram.org/method/messages.readDiscussion"/></para></summary>
		/// <param name="peer">Group ID</param>
		/// <param name="msg_id">ID of message that started the thread</param>
		/// <param name="read_max_id">ID up to which thread messages were read</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.readDiscussion#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_ReadDiscussion(this Client client, InputPeer peer, int msg_id, int read_max_id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xF731A9F4);
				writer.WriteTLObject(peer);
				writer.Write(msg_id);
				writer.Write(read_max_id);
				return "Messages_ReadDiscussion";
			});

		/// <summary><a href="https://corefork.telegram.org/api/pin">Unpin</a> all pinned messages		<para>See <a href="https://corefork.telegram.org/method/messages.unpinAllMessages"/></para></summary>
		/// <param name="peer">Chat where to unpin</param>
		public static Task<Messages_AffectedHistory> Messages_UnpinAllMessages(this Client client, InputPeer peer)
			=> client.CallAsync<Messages_AffectedHistory>(writer =>
			{
				writer.Write(0xF025BC8B);
				writer.WriteTLObject(peer);
				return "Messages_UnpinAllMessages";
			});

		/// <summary>Delete a <a href="https://corefork.telegram.org/api/channel">chat</a>		<para>See <a href="https://corefork.telegram.org/method/messages.deleteChat"/></para></summary>
		/// <param name="chat_id">Chat ID</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.deleteChat#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_DeleteChat(this Client client, long chat_id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x5BD0EE50);
				writer.Write(chat_id);
				return "Messages_DeleteChat";
			});

		/// <summary>Delete the entire phone call history.		<para>See <a href="https://corefork.telegram.org/method/messages.deletePhoneCallHistory"/></para></summary>
		/// <param name="revoke">Whether to remove phone call history for participants as well</param>
		public static Task<Messages_AffectedFoundMessages> Messages_DeletePhoneCallHistory(this Client client, bool revoke = false)
			=> client.CallAsync<Messages_AffectedFoundMessages>(writer =>
			{
				writer.Write(0xF9CBE409);
				writer.Write(revoke ? 0x1 : 0);
				return "Messages_DeletePhoneCallHistory";
			});

		/// <summary>Obtains information about a chat export file, generated by a foreign chat app, <a href="https://corefork.telegram.org/api/import">click here for more info about imported chats »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.checkHistoryImport"/></para></summary>
		/// <param name="import_head">Beginning of the message file; up to 100 lines.</param>
		public static Task<Messages_HistoryImportParsed> Messages_CheckHistoryImport(this Client client, string import_head)
			=> client.CallAsync<Messages_HistoryImportParsed>(writer =>
			{
				writer.Write(0x43FE19F3);
				writer.WriteTLString(import_head);
				return "Messages_CheckHistoryImport";
			});

		/// <summary>Import chat history from a foreign chat app into a specific Telegram chat, <a href="https://corefork.telegram.org/api/import">click here for more info about imported chats »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.initHistoryImport"/></para></summary>
		/// <param name="peer">The Telegram chat where the <a href="https://corefork.telegram.org/api/import">history should be imported</a>.</param>
		/// <param name="file">File with messages to import.</param>
		/// <param name="media_count">Number of media files associated with the chat that will be uploaded using <a href="https://corefork.telegram.org/method/messages.uploadImportedMedia">messages.uploadImportedMedia</a>.</param>
		/// <exception cref="RpcException">Possible errors: 400,406 (<a href="https://corefork.telegram.org/method/messages.initHistoryImport#possible-errors">details</a>)</exception>
		public static Task<Messages_HistoryImport> Messages_InitHistoryImport(this Client client, InputPeer peer, InputFileBase file, int media_count)
			=> client.CallAsync<Messages_HistoryImport>(writer =>
			{
				writer.Write(0x34090C3B);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(file);
				writer.Write(media_count);
				return "Messages_InitHistoryImport";
			});

		/// <summary>Upload a media file associated with an <a href="https://corefork.telegram.org/api/import">imported chat, click here for more info »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.uploadImportedMedia"/></para></summary>
		/// <param name="peer">The Telegram chat where the media will be imported</param>
		/// <param name="import_id">Identifier of a <a href="https://corefork.telegram.org/api/import">history import session</a>, returned by <a href="https://corefork.telegram.org/method/messages.initHistoryImport">messages.initHistoryImport</a></param>
		/// <param name="file_name">File name</param>
		/// <param name="media">Media metadata</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messageMediaEmpty">messageMediaEmpty</a></returns>
		public static Task<MessageMedia> Messages_UploadImportedMedia(this Client client, InputPeer peer, long import_id, string file_name, InputMedia media)
			=> client.CallAsync<MessageMedia>(writer =>
			{
				writer.Write(0x2A862092);
				writer.WriteTLObject(peer);
				writer.Write(import_id);
				writer.WriteTLString(file_name);
				writer.WriteTLObject(media);
				return "Messages_UploadImportedMedia";
			});

		/// <summary>Complete the <a href="https://corefork.telegram.org/api/import">history import process</a>, importing all messages into the chat.<br/>To be called only after initializing the import with <a href="https://corefork.telegram.org/method/messages.initHistoryImport">messages.initHistoryImport</a> and uploading all files using <a href="https://corefork.telegram.org/method/messages.uploadImportedMedia">messages.uploadImportedMedia</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.startHistoryImport"/></para></summary>
		/// <param name="peer">The Telegram chat where the messages should be <a href="https://corefork.telegram.org/api/import">imported, click here for more info »</a></param>
		/// <param name="import_id">Identifier of a history import session, returned by <a href="https://corefork.telegram.org/method/messages.initHistoryImport">messages.initHistoryImport</a>.</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.startHistoryImport#possible-errors">details</a>)</exception>
		public static Task<bool> Messages_StartHistoryImport(this Client client, InputPeer peer, long import_id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xB43DF344);
				writer.WriteTLObject(peer);
				writer.Write(import_id);
				return "Messages_StartHistoryImport";
			});

		/// <summary>Get info about the chat invites of a specific chat		<para>See <a href="https://corefork.telegram.org/method/messages.getExportedChatInvites"/></para></summary>
		/// <param name="revoked">Whether to fetch revoked chat invites</param>
		/// <param name="peer">Chat</param>
		/// <param name="admin_id">Whether to only fetch chat invites from this admin</param>
		/// <param name="offset_date"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="offset_link"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Messages_ExportedChatInvites> Messages_GetExportedChatInvites(this Client client, InputPeer peer, InputUserBase admin_id, int limit, bool revoked = false, DateTime? offset_date = null, string offset_link = null)
			=> client.CallAsync<Messages_ExportedChatInvites>(writer =>
			{
				writer.Write(0xA2B5A3F6);
				writer.Write((revoked ? 0x8 : 0) | (offset_date != null ? 0x4 : 0) | (offset_link != null ? 0x4 : 0));
				writer.WriteTLObject(peer);
				writer.WriteTLObject(admin_id);
				if (offset_date != null)
					writer.WriteTLStamp(offset_date.Value);
				if (offset_link != null)
					writer.WriteTLString(offset_link);
				writer.Write(limit);
				return "Messages_GetExportedChatInvites";
			});

		/// <summary>Get info about a chat invite		<para>See <a href="https://corefork.telegram.org/method/messages.getExportedChatInvite"/></para></summary>
		/// <param name="peer">Chat</param>
		/// <param name="link">Invite link</param>
		public static Task<Messages_ExportedChatInviteBase> Messages_GetExportedChatInvite(this Client client, InputPeer peer, string link)
			=> client.CallAsync<Messages_ExportedChatInviteBase>(writer =>
			{
				writer.Write(0x73746F5C);
				writer.WriteTLObject(peer);
				writer.WriteTLString(link);
				return "Messages_GetExportedChatInvite";
			});

		/// <summary>Edit an exported chat invite		<para>See <a href="https://corefork.telegram.org/method/messages.editExportedChatInvite"/></para></summary>
		/// <param name="revoked">Whether to revoke the chat invite</param>
		/// <param name="peer">Chat</param>
		/// <param name="link">Invite link</param>
		/// <param name="expire_date">New expiration date</param>
		/// <param name="usage_limit">Maximum number of users that can join using this link</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.editExportedChatInvite#possible-errors">details</a>)</exception>
		public static Task<Messages_ExportedChatInviteBase> Messages_EditExportedChatInvite(this Client client, InputPeer peer, string link, bool revoked = false, DateTime? expire_date = null, int? usage_limit = null, bool? request_needed = default, string title = null)
			=> client.CallAsync<Messages_ExportedChatInviteBase>(writer =>
			{
				writer.Write(0xBDCA2F75);
				writer.Write((revoked ? 0x4 : 0) | (expire_date != null ? 0x1 : 0) | (usage_limit != null ? 0x2 : 0) | (request_needed != default ? 0x8 : 0) | (title != null ? 0x10 : 0));
				writer.WriteTLObject(peer);
				writer.WriteTLString(link);
				if (expire_date != null)
					writer.WriteTLStamp(expire_date.Value);
				if (usage_limit != null)
					writer.Write(usage_limit.Value);
				if (request_needed != default)
					writer.Write(request_needed.Value ? 0x997275B5 : 0xBC799737);
				if (title != null)
					writer.WriteTLString(title);
				return "Messages_EditExportedChatInvite";
			});

		/// <summary>Delete all revoked chat invites		<para>See <a href="https://corefork.telegram.org/method/messages.deleteRevokedExportedChatInvites"/></para></summary>
		/// <param name="peer">Chat</param>
		/// <param name="admin_id">ID of the admin that originally generated the revoked chat invites</param>
		public static Task<bool> Messages_DeleteRevokedExportedChatInvites(this Client client, InputPeer peer, InputUserBase admin_id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x56987BD5);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(admin_id);
				return "Messages_DeleteRevokedExportedChatInvites";
			});

		/// <summary>Delete a chat invite		<para>See <a href="https://corefork.telegram.org/method/messages.deleteExportedChatInvite"/></para></summary>
		/// <param name="peer">Peer</param>
		/// <param name="link">Invite link</param>
		public static Task<bool> Messages_DeleteExportedChatInvite(this Client client, InputPeer peer, string link)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xD464A42B);
				writer.WriteTLObject(peer);
				writer.WriteTLString(link);
				return "Messages_DeleteExportedChatInvite";
			});

		/// <summary>Get info about chat invites generated by admins.		<para>See <a href="https://corefork.telegram.org/method/messages.getAdminsWithInvites"/></para></summary>
		/// <param name="peer">Chat</param>
		public static Task<Messages_ChatAdminsWithInvites> Messages_GetAdminsWithInvites(this Client client, InputPeer peer)
			=> client.CallAsync<Messages_ChatAdminsWithInvites>(writer =>
			{
				writer.Write(0x3920E6EF);
				writer.WriteTLObject(peer);
				return "Messages_GetAdminsWithInvites";
			});

		/// <summary>Get info about the users that joined the chat using a specific chat invite		<para>See <a href="https://corefork.telegram.org/method/messages.getChatInviteImporters"/></para></summary>
		/// <param name="peer">Chat</param>
		/// <param name="link">Invite link</param>
		/// <param name="offset_date"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="offset_user">User ID for <a href="https://corefork.telegram.org/api/offsets">pagination</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Messages_ChatInviteImporters> Messages_GetChatInviteImporters(this Client client, InputPeer peer, DateTime offset_date, InputUserBase offset_user, int limit, bool requested = false, string link = null, string q = null)
			=> client.CallAsync<Messages_ChatInviteImporters>(writer =>
			{
				writer.Write(0xDF04DD4E);
				writer.Write((requested ? 0x1 : 0) | (link != null ? 0x2 : 0) | (q != null ? 0x4 : 0));
				writer.WriteTLObject(peer);
				if (link != null)
					writer.WriteTLString(link);
				if (q != null)
					writer.WriteTLString(q);
				writer.WriteTLStamp(offset_date);
				writer.WriteTLObject(offset_user);
				writer.Write(limit);
				return "Messages_GetChatInviteImporters";
			});

		/// <summary>Set maximum Time-To-Live of all messages in the specified chat		<para>See <a href="https://corefork.telegram.org/method/messages.setHistoryTTL"/></para></summary>
		/// <param name="peer">The dialog</param>
		/// <param name="period">Automatically delete all messages sent in the chat after this many seconds</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.setHistoryTTL#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Messages_SetHistoryTTL(this Client client, InputPeer peer, int period)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xB80E5FE4);
				writer.WriteTLObject(peer);
				writer.Write(period);
				return "Messages_SetHistoryTTL";
			});

		/// <summary>Check whether chat history exported from another chat app can be <a href="https://corefork.telegram.org/api/import">imported into a specific Telegram chat, click here for more info »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.checkHistoryImportPeer"/></para></summary>
		/// <param name="peer">The chat where we want to <a href="https://corefork.telegram.org/api/import">import history »</a>.</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.checkHistoryImportPeer#possible-errors">details</a>)</exception>
		public static Task<Messages_CheckedHistoryImportPeer> Messages_CheckHistoryImportPeer(this Client client, InputPeer peer)
			=> client.CallAsync<Messages_CheckedHistoryImportPeer>(writer =>
			{
				writer.Write(0x5DC60F03);
				writer.WriteTLObject(peer);
				return "Messages_CheckHistoryImportPeer";
			});

		/// <summary>Change the chat theme of a certain chat		<para>See <a href="https://corefork.telegram.org/method/messages.setChatTheme"/></para></summary>
		/// <param name="peer">Private chat where to change theme</param>
		/// <param name="emoticon">Emoji, identifying a specific chat theme; a list of chat themes can be fetched using <a href="https://corefork.telegram.org/method/account.getChatThemes">account.getChatThemes</a></param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.setChatTheme#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Messages_SetChatTheme(this Client client, InputPeer peer, string emoticon)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xE63BE13F);
				writer.WriteTLObject(peer);
				writer.WriteTLString(emoticon);
				return "Messages_SetChatTheme";
			});

		/// <summary>Get which users read a specific message: only available for groups and supergroups with less than <c>chat_read_mark_size_threshold</c> members, read receipts will be stored for <c>chat_read_mark_expire_period</c> seconds after the message was sent, see <a href="https://corefork.telegram.org/api/config#client-configuration">client configuration for more info »</a>.		<para>See <a href="https://corefork.telegram.org/method/messages.getMessageReadParticipants"/></para></summary>
		/// <param name="peer">Dialog</param>
		/// <param name="msg_id">Message ID</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/messages.getMessageReadParticipants#possible-errors">details</a>)</exception>
		public static Task<long[]> Messages_GetMessageReadParticipants(this Client client, InputPeer peer, int msg_id)
			=> client.CallAsync<long[]>(writer =>
			{
				writer.Write(0x2C6F97B7);
				writer.WriteTLObject(peer);
				writer.Write(msg_id);
				return "Messages_GetMessageReadParticipants";
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/messages.getSearchResultsCalendar"/></para></summary>
		public static Task<Messages_SearchResultsCalendar> Messages_GetSearchResultsCalendar(this Client client, InputPeer peer, MessagesFilter filter, int offset_id, DateTime offset_date)
			=> client.CallAsync<Messages_SearchResultsCalendar>(writer =>
			{
				writer.Write(0x49F0BDE9);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(filter);
				writer.Write(offset_id);
				writer.WriteTLStamp(offset_date);
				return "Messages_GetSearchResultsCalendar";
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/messages.getSearchResultsPositions"/></para></summary>
		public static Task<Messages_SearchResultsPositions> Messages_GetSearchResultsPositions(this Client client, InputPeer peer, MessagesFilter filter, int offset_id, int limit)
			=> client.CallAsync<Messages_SearchResultsPositions>(writer =>
			{
				writer.Write(0x6E9583A3);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(filter);
				writer.Write(offset_id);
				writer.Write(limit);
				return "Messages_GetSearchResultsPositions";
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/messages.hideChatJoinRequest"/></para></summary>
		public static Task<UpdatesBase> Messages_HideChatJoinRequest(this Client client, InputPeer peer, InputUserBase user_id, bool approved = false)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x7FE7E815);
				writer.Write(approved ? 0x1 : 0);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(user_id);
				return "Messages_HideChatJoinRequest";
			});

		/// <summary>Returns a current state of updates.		<para>See <a href="https://corefork.telegram.org/method/updates.getState"/></para></summary>
		public static Task<Updates_State> Updates_GetState(this Client client)
			=> client.CallAsync<Updates_State>(writer =>
			{
				writer.Write(0xEDD4882A);
				return "Updates_GetState";
			});

		/// <summary>Get new <a href="https://corefork.telegram.org/api/updates">updates</a>.		<para>See <a href="https://corefork.telegram.org/method/updates.getDifference"/></para></summary>
		/// <param name="pts">PTS, see <a href="https://corefork.telegram.org/api/updates">updates</a>.</param>
		/// <param name="pts_total_limit">For fast updating: if provided and <c>pts + pts_total_limit &lt; remote pts</c>, <see cref="Updates_DifferenceTooLong"/> will be returned.<br/>Simply tells the server to not return the difference if it is bigger than <c>pts_total_limit</c><br/>If the remote pts is too big (&gt; ~4000000), this field will default to 1000000</param>
		/// <param name="date">date, see <a href="https://corefork.telegram.org/api/updates">updates</a>.</param>
		/// <param name="qts">QTS, see <a href="https://corefork.telegram.org/api/updates">updates</a>.</param>
		/// <exception cref="RpcException">Possible errors: 400,401,403 (<a href="https://corefork.telegram.org/method/updates.getDifference#possible-errors">details</a>)</exception>
		public static Task<Updates_DifferenceBase> Updates_GetDifference(this Client client, int pts, DateTime date, int qts, int? pts_total_limit = null)
			=> client.CallAsync<Updates_DifferenceBase>(writer =>
			{
				writer.Write(0x25939651);
				writer.Write(pts_total_limit != null ? 0x1 : 0);
				writer.Write(pts);
				if (pts_total_limit != null)
					writer.Write(pts_total_limit.Value);
				writer.WriteTLStamp(date);
				writer.Write(qts);
				return "Updates_GetDifference";
			});

		/// <summary>Returns the difference between the current state of updates of a certain channel and transmitted.		<para>See <a href="https://corefork.telegram.org/method/updates.getChannelDifference"/></para></summary>
		/// <param name="force">Set to true to skip some possibly unneeded updates and reduce server-side load</param>
		/// <param name="channel">The channel</param>
		/// <param name="filter">Messsage filter</param>
		/// <param name="pts">Persistent timestamp (see <a href="https://corefork.telegram.org/api/updates">updates</a>)</param>
		/// <param name="limit">How many updates to fetch, max <c>100000</c><br/>Ordinary (non-bot) users are supposed to pass <c>10-100</c></param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/updates.getChannelDifference#possible-errors">details</a>)</exception>
		public static Task<Updates_ChannelDifferenceBase> Updates_GetChannelDifference(this Client client, InputChannelBase channel, ChannelMessagesFilter filter, int pts, int limit, bool force = false)
			=> client.CallAsync<Updates_ChannelDifferenceBase>(writer =>
			{
				writer.Write(0x03173D78);
				writer.Write(force ? 0x1 : 0);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(filter);
				writer.Write(pts);
				writer.Write(limit);
				return "Updates_GetChannelDifference";
			});

		/// <summary>Installs a previously uploaded photo as a profile photo.		<para>See <a href="https://corefork.telegram.org/method/photos.updateProfilePhoto"/></para></summary>
		/// <param name="id">Input photo</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/photos.updateProfilePhoto#possible-errors">details</a>)</exception>
		public static Task<Photos_Photo> Photos_UpdateProfilePhoto(this Client client, InputPhoto id)
			=> client.CallAsync<Photos_Photo>(writer =>
			{
				writer.Write(0x72D4742C);
				writer.WriteTLObject(id);
				return "Photos_UpdateProfilePhoto";
			});

		/// <summary>Updates current user profile photo.		<para>See <a href="https://corefork.telegram.org/method/photos.uploadProfilePhoto"/></para></summary>
		/// <param name="file">File saved in parts by means of <a href="https://corefork.telegram.org/method/upload.saveFilePart">upload.saveFilePart</a> method</param>
		/// <param name="video"><a href="https://corefork.telegram.org/api/files#animated-profile-pictures">Animated profile picture</a> video</param>
		/// <param name="video_start_ts">Floating point UNIX timestamp in seconds, indicating the frame of the video that should be used as static preview.</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/photos.uploadProfilePhoto#possible-errors">details</a>)</exception>
		public static Task<Photos_Photo> Photos_UploadProfilePhoto(this Client client, InputFileBase file = null, InputFileBase video = null, double? video_start_ts = null)
			=> client.CallAsync<Photos_Photo>(writer =>
			{
				writer.Write(0x89F30F69);
				writer.Write((file != null ? 0x1 : 0) | (video != null ? 0x2 : 0) | (video_start_ts != null ? 0x4 : 0));
				if (file != null)
					writer.WriteTLObject(file);
				if (video != null)
					writer.WriteTLObject(video);
				if (video_start_ts != null)
					writer.Write(video_start_ts.Value);
				return "Photos_UploadProfilePhoto";
			});

		/// <summary>Deletes profile photos.		<para>See <a href="https://corefork.telegram.org/method/photos.deletePhotos"/></para></summary>
		/// <param name="id">Input photos to delete</param>
		public static Task<long[]> Photos_DeletePhotos(this Client client, InputPhoto[] id)
			=> client.CallAsync<long[]>(writer =>
			{
				writer.Write(0x87CF7F2F);
				writer.WriteTLVector(id);
				return "Photos_DeletePhotos";
			});

		/// <summary>Returns the list of user photos.		<para>See <a href="https://corefork.telegram.org/method/photos.getUserPhotos"/></para></summary>
		/// <param name="user_id">User ID</param>
		/// <param name="offset">Number of list elements to be skipped</param>
		/// <param name="max_id">If a positive value was transferred, the method will return only photos with IDs less than the set one</param>
		/// <param name="limit">Number of list elements to be returned</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/photos.getUserPhotos#possible-errors">details</a>)</exception>
		public static Task<Photos_Photos> Photos_GetUserPhotos(this Client client, InputUserBase user_id, int offset, long max_id, int limit)
			=> client.CallAsync<Photos_Photos>(writer =>
			{
				writer.Write(0x91CD32A8);
				writer.WriteTLObject(user_id);
				writer.Write(offset);
				writer.Write(max_id);
				writer.Write(limit);
				return "Photos_GetUserPhotos";
			});

		/// <summary>Saves a part of file for futher sending to one of the methods.		<para>See <a href="https://corefork.telegram.org/method/upload.saveFilePart"/></para></summary>
		/// <param name="file_id">Random file identifier created by the client</param>
		/// <param name="file_part">Numerical order of a part</param>
		/// <param name="bytes">Binary data, contend of a part</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/upload.saveFilePart#possible-errors">details</a>)</exception>
		public static Task<bool> Upload_SaveFilePart(this Client client, long file_id, int file_part, byte[] bytes)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xB304A621);
				writer.Write(file_id);
				writer.Write(file_part);
				writer.WriteTLBytes(bytes);
				return "Upload_SaveFilePart";
			});

		/// <summary>Returns content of a whole file or its part.		<para>See <a href="https://corefork.telegram.org/method/upload.getFile"/></para></summary>
		/// <param name="precise">Disable some checks on limit and offset values, useful for example to stream videos by keyframes</param>
		/// <param name="cdn_supported">Whether the current client supports <a href="https://corefork.telegram.org/cdn">CDN downloads</a></param>
		/// <param name="location">File location</param>
		/// <param name="offset">Number of bytes to be skipped</param>
		/// <param name="limit">Number of bytes to be returned</param>
		/// <exception cref="RpcException">Possible errors: 400,401,406 (<a href="https://corefork.telegram.org/method/upload.getFile#possible-errors">details</a>)</exception>
		public static Task<Upload_FileBase> Upload_GetFile(this Client client, InputFileLocationBase location, int offset, int limit, bool precise = false, bool cdn_supported = false)
			=> client.CallAsync<Upload_FileBase>(writer =>
			{
				writer.Write(0xB15A9AFC);
				writer.Write((precise ? 0x1 : 0) | (cdn_supported ? 0x2 : 0));
				writer.WriteTLObject(location);
				writer.Write(offset);
				writer.Write(limit);
				return "Upload_GetFile";
			});

		/// <summary>Saves a part of a large file (over 10Mb in size) to be later passed to one of the methods.		<para>See <a href="https://corefork.telegram.org/method/upload.saveBigFilePart"/></para></summary>
		/// <param name="file_id">Random file id, created by the client</param>
		/// <param name="file_part">Part sequence number</param>
		/// <param name="file_total_parts">Total number of parts</param>
		/// <param name="bytes">Binary data, part contents</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/upload.saveBigFilePart#possible-errors">details</a>)</exception>
		public static Task<bool> Upload_SaveBigFilePart(this Client client, long file_id, int file_part, int file_total_parts, byte[] bytes)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xDE7B673D);
				writer.Write(file_id);
				writer.Write(file_part);
				writer.Write(file_total_parts);
				writer.WriteTLBytes(bytes);
				return "Upload_SaveBigFilePart";
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/upload.getWebFile"/></para></summary>
		/// <param name="location">The file to download</param>
		/// <param name="offset">Number of bytes to be skipped</param>
		/// <param name="limit">Number of bytes to be returned</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/upload.getWebFile#possible-errors">details</a>)</exception>
		public static Task<Upload_WebFile> Upload_GetWebFile(this Client client, InputWebFileLocationBase location, int offset, int limit)
			=> client.CallAsync<Upload_WebFile>(writer =>
			{
				writer.Write(0x24E6818D);
				writer.WriteTLObject(location);
				writer.Write(offset);
				writer.Write(limit);
				return "Upload_GetWebFile";
			});

		/// <summary>Download a <a href="https://corefork.telegram.org/cdn">CDN</a> file.		<para>See <a href="https://corefork.telegram.org/method/upload.getCdnFile"/></para></summary>
		/// <param name="file_token">File token</param>
		/// <param name="offset">Offset of chunk to download</param>
		/// <param name="limit">Length of chunk to download</param>
		public static Task<Upload_CdnFileBase> Upload_GetCdnFile(this Client client, byte[] file_token, int offset, int limit)
			=> client.CallAsync<Upload_CdnFileBase>(writer =>
			{
				writer.Write(0x2000BCC3);
				writer.WriteTLBytes(file_token);
				writer.Write(offset);
				writer.Write(limit);
				return "Upload_GetCdnFile";
			});

		/// <summary>Request a reupload of a certain file to a <a href="https://corefork.telegram.org/cdn">CDN DC</a>.		<para>See <a href="https://corefork.telegram.org/method/upload.reuploadCdnFile"/></para></summary>
		/// <param name="file_token">File token</param>
		/// <param name="request_token">Request token</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/upload.reuploadCdnFile#possible-errors">details</a>)</exception>
		public static Task<FileHash[]> Upload_ReuploadCdnFile(this Client client, byte[] file_token, byte[] request_token)
			=> client.CallAsync<FileHash[]>(writer =>
			{
				writer.Write(0x9B2754A8);
				writer.WriteTLBytes(file_token);
				writer.WriteTLBytes(request_token);
				return "Upload_ReuploadCdnFile";
			});

		/// <summary>Get SHA256 hashes for verifying downloaded <a href="https://corefork.telegram.org/cdn">CDN</a> files		<para>See <a href="https://corefork.telegram.org/method/upload.getCdnFileHashes"/></para></summary>
		/// <param name="file_token">File</param>
		/// <param name="offset">Offset from which to start getting hashes</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/upload.getCdnFileHashes#possible-errors">details</a>)</exception>
		public static Task<FileHash[]> Upload_GetCdnFileHashes(this Client client, byte[] file_token, int offset)
			=> client.CallAsync<FileHash[]>(writer =>
			{
				writer.Write(0x4DA54231);
				writer.WriteTLBytes(file_token);
				writer.Write(offset);
				return "Upload_GetCdnFileHashes";
			});

		/// <summary>Get SHA256 hashes for verifying downloaded files		<para>See <a href="https://corefork.telegram.org/method/upload.getFileHashes"/></para></summary>
		/// <param name="location">File</param>
		/// <param name="offset">Offset from which to get file hashes</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/upload.getFileHashes#possible-errors">details</a>)</exception>
		public static Task<FileHash[]> Upload_GetFileHashes(this Client client, InputFileLocationBase location, int offset)
			=> client.CallAsync<FileHash[]>(writer =>
			{
				writer.Write(0xC7025931);
				writer.WriteTLObject(location);
				writer.Write(offset);
				return "Upload_GetFileHashes";
			});

		/// <summary>Returns current configuration, including data center configuration.		<para>See <a href="https://corefork.telegram.org/method/help.getConfig"/></para></summary>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/help.getConfig#possible-errors">details</a>)</exception>
		public static Task<Config> Help_GetConfig(this Client client) => client.CallAsync<Config>(Help_GetConfig);
		public static string Help_GetConfig(BinaryWriter writer)
		{
			writer.Write(0xC4F9186B);
			return "Help_GetConfig";
		}

		/// <summary>Returns info on data centre nearest to the user.		<para>See <a href="https://corefork.telegram.org/method/help.getNearestDc"/></para></summary>
		public static Task<NearestDc> Help_GetNearestDc(this Client client)
			=> client.CallAsync<NearestDc>(writer =>
			{
				writer.Write(0x1FB33026);
				return "Help_GetNearestDc";
			});

		/// <summary>Returns information on update availability for the current application.		<para>See <a href="https://corefork.telegram.org/method/help.getAppUpdate"/></para></summary>
		/// <param name="source">Source</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.noAppUpdate">help.noAppUpdate</a></returns>
		public static Task<Help_AppUpdate> Help_GetAppUpdate(this Client client, string source)
			=> client.CallAsync<Help_AppUpdate>(writer =>
			{
				writer.Write(0x522D5A7D);
				writer.WriteTLString(source);
				return "Help_GetAppUpdate";
			});

		/// <summary>Returns localized text of a text message with an invitation.		<para>See <a href="https://corefork.telegram.org/method/help.getInviteText"/></para></summary>
		public static Task<Help_InviteText> Help_GetInviteText(this Client client)
			=> client.CallAsync<Help_InviteText>(writer =>
			{
				writer.Write(0x4D392343);
				return "Help_GetInviteText";
			});

		/// <summary>Returns the support user for the 'ask a question' feature.		<para>See <a href="https://corefork.telegram.org/method/help.getSupport"/></para></summary>
		public static Task<Help_Support> Help_GetSupport(this Client client)
			=> client.CallAsync<Help_Support>(writer =>
			{
				writer.Write(0x9CDF08CD);
				return "Help_GetSupport";
			});

		/// <summary>Get changelog of current app.<br/>Typically, an <see cref="Updates"/> constructor will be returned, containing one or more <see cref="UpdateServiceNotification"/> updates with app-specific changelogs.		<para>See <a href="https://corefork.telegram.org/method/help.getAppChangelog"/></para></summary>
		/// <param name="prev_app_version">Previous app version</param>
		public static Task<UpdatesBase> Help_GetAppChangelog(this Client client, string prev_app_version)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x9010EF6F);
				writer.WriteTLString(prev_app_version);
				return "Help_GetAppChangelog";
			});

		/// <summary>Informs the server about the number of pending bot updates if they haven't been processed for a long time; for bots only		<para>See <a href="https://corefork.telegram.org/method/help.setBotUpdatesStatus"/></para></summary>
		/// <param name="pending_updates_count">Number of pending updates</param>
		/// <param name="message">Error message, if present</param>
		public static Task<bool> Help_SetBotUpdatesStatus(this Client client, int pending_updates_count, string message)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xEC22CFCD);
				writer.Write(pending_updates_count);
				writer.WriteTLString(message);
				return "Help_SetBotUpdatesStatus";
			});

		/// <summary>Get configuration for <a href="https://corefork.telegram.org/cdn">CDN</a> file downloads.		<para>See <a href="https://corefork.telegram.org/method/help.getCdnConfig"/></para></summary>
		/// <exception cref="RpcException">Possible errors: 401 (<a href="https://corefork.telegram.org/method/help.getCdnConfig#possible-errors">details</a>)</exception>
		public static Task<CdnConfig> Help_GetCdnConfig(this Client client)
			=> client.CallAsync<CdnConfig>(writer =>
			{
				writer.Write(0x52029342);
				return "Help_GetCdnConfig";
			});

		/// <summary>Get recently used <c>t.me</c> links		<para>See <a href="https://corefork.telegram.org/method/help.getRecentMeUrls"/></para></summary>
		/// <param name="referer">Referer</param>
		public static Task<Help_RecentMeUrls> Help_GetRecentMeUrls(this Client client, string referer)
			=> client.CallAsync<Help_RecentMeUrls>(writer =>
			{
				writer.Write(0x3DC0F114);
				writer.WriteTLString(referer);
				return "Help_GetRecentMeUrls";
			});

		/// <summary>Look for updates of telegram's terms of service		<para>See <a href="https://corefork.telegram.org/method/help.getTermsOfServiceUpdate"/></para></summary>
		public static Task<Help_TermsOfServiceUpdateBase> Help_GetTermsOfServiceUpdate(this Client client)
			=> client.CallAsync<Help_TermsOfServiceUpdateBase>(writer =>
			{
				writer.Write(0x2CA51FD1);
				return "Help_GetTermsOfServiceUpdate";
			});

		/// <summary>Accept the new terms of service		<para>See <a href="https://corefork.telegram.org/method/help.acceptTermsOfService"/></para></summary>
		/// <param name="id">ID of terms of service</param>
		public static Task<bool> Help_AcceptTermsOfService(this Client client, DataJSON id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xEE72F79A);
				writer.WriteTLObject(id);
				return "Help_AcceptTermsOfService";
			});

		/// <summary>Get info about a <c>t.me</c> link		<para>See <a href="https://corefork.telegram.org/method/help.getDeepLinkInfo"/></para></summary>
		/// <param name="path">Path in <c>t.me/path</c></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.deepLinkInfoEmpty">help.deepLinkInfoEmpty</a></returns>
		public static Task<Help_DeepLinkInfo> Help_GetDeepLinkInfo(this Client client, string path)
			=> client.CallAsync<Help_DeepLinkInfo>(writer =>
			{
				writer.Write(0x3FEDC75F);
				writer.WriteTLString(path);
				return "Help_GetDeepLinkInfo";
			});

		/// <summary>Get app-specific configuration, see <a href="https://corefork.telegram.org/api/config#client-configuration">client configuration</a> for more info on the result.		<para>See <a href="https://corefork.telegram.org/method/help.getAppConfig"/></para></summary>
		public static Task<JSONValue> Help_GetAppConfig(this Client client)
			=> client.CallAsync<JSONValue>(writer =>
			{
				writer.Write(0x98914110);
				return "Help_GetAppConfig";
			});

		/// <summary>Saves logs of application on the server.		<para>See <a href="https://corefork.telegram.org/method/help.saveAppLog"/></para></summary>
		/// <param name="events">List of input events</param>
		public static Task<bool> Help_SaveAppLog(this Client client, InputAppEvent[] events)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x6F02F748);
				writer.WriteTLVector(events);
				return "Help_SaveAppLog";
			});

		/// <summary>Get <a href="https://corefork.telegram.org/passport">passport</a> configuration		<para>See <a href="https://corefork.telegram.org/method/help.getPassportConfig"/></para></summary>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.passportConfigNotModified">help.passportConfigNotModified</a></returns>
		public static Task<Help_PassportConfig> Help_GetPassportConfig(this Client client, int hash)
			=> client.CallAsync<Help_PassportConfig>(writer =>
			{
				writer.Write(0xC661AD08);
				writer.Write(hash);
				return "Help_GetPassportConfig";
			});

		/// <summary>Get localized name of the telegram support user		<para>See <a href="https://corefork.telegram.org/method/help.getSupportName"/></para></summary>
		/// <exception cref="RpcException">Possible errors: 403 (<a href="https://corefork.telegram.org/method/help.getSupportName#possible-errors">details</a>)</exception>
		public static Task<Help_SupportName> Help_GetSupportName(this Client client)
			=> client.CallAsync<Help_SupportName>(writer =>
			{
				writer.Write(0xD360E72C);
				return "Help_GetSupportName";
			});

		/// <summary>Internal use		<para>See <a href="https://corefork.telegram.org/method/help.getUserInfo"/></para></summary>
		/// <param name="user_id">User ID</param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.userInfoEmpty">help.userInfoEmpty</a></returns>
		/// <exception cref="RpcException">Possible errors: 403 (<a href="https://corefork.telegram.org/method/help.getUserInfo#possible-errors">details</a>)</exception>
		public static Task<Help_UserInfo> Help_GetUserInfo(this Client client, InputUserBase user_id)
			=> client.CallAsync<Help_UserInfo>(writer =>
			{
				writer.Write(0x038A08D3);
				writer.WriteTLObject(user_id);
				return "Help_GetUserInfo";
			});

		/// <summary>Internal use		<para>See <a href="https://corefork.telegram.org/method/help.editUserInfo"/></para></summary>
		/// <param name="user_id">User</param>
		/// <param name="message">Message</param>
		/// <param name="entities"><a href="https://corefork.telegram.org/api/entities">Message entities for styled text</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.userInfoEmpty">help.userInfoEmpty</a></returns>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/help.editUserInfo#possible-errors">details</a>)</exception>
		public static Task<Help_UserInfo> Help_EditUserInfo(this Client client, InputUserBase user_id, string message, MessageEntity[] entities)
			=> client.CallAsync<Help_UserInfo>(writer =>
			{
				writer.Write(0x66B91B70);
				writer.WriteTLObject(user_id);
				writer.WriteTLString(message);
				writer.WriteTLVector(entities);
				return "Help_EditUserInfo";
			});

		/// <summary>Get MTProxy/Public Service Announcement information		<para>See <a href="https://corefork.telegram.org/method/help.getPromoData"/></para></summary>
		public static Task<Help_PromoDataBase> Help_GetPromoData(this Client client)
			=> client.CallAsync<Help_PromoDataBase>(writer =>
			{
				writer.Write(0xC0977421);
				return "Help_GetPromoData";
			});

		/// <summary>Hide MTProxy/Public Service Announcement information		<para>See <a href="https://corefork.telegram.org/method/help.hidePromoData"/></para></summary>
		/// <param name="peer">Peer to hide</param>
		public static Task<bool> Help_HidePromoData(this Client client, InputPeer peer)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x1E251C95);
				writer.WriteTLObject(peer);
				return "Help_HidePromoData";
			});

		/// <summary>Dismiss a <a href="https://corefork.telegram.org/api/config#suggestions">suggestion, see here for more info »</a>.		<para>See <a href="https://corefork.telegram.org/method/help.dismissSuggestion"/></para></summary>
		/// <param name="peer">In the case of pending suggestions in <see cref="ChannelFull"/>, the channel ID.</param>
		/// <param name="suggestion"><a href="https://corefork.telegram.org/api/config#suggestions">Suggestion, see here for more info »</a>.</param>
		public static Task<bool> Help_DismissSuggestion(this Client client, InputPeer peer, string suggestion)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xF50DBAA1);
				writer.WriteTLObject(peer);
				writer.WriteTLString(suggestion);
				return "Help_DismissSuggestion";
			});

		/// <summary>Get name, ISO code, localized name and phone codes/patterns of all available countries		<para>See <a href="https://corefork.telegram.org/method/help.getCountriesList"/></para></summary>
		/// <param name="lang_code">Language code of the current user</param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets#hash-generation">Hash for pagination, for more info click here</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.countriesListNotModified">help.countriesListNotModified</a></returns>
		public static Task<Help_CountriesList> Help_GetCountriesList(this Client client, string lang_code, int hash)
			=> client.CallAsync<Help_CountriesList>(writer =>
			{
				writer.Write(0x735787A8);
				writer.WriteTLString(lang_code);
				writer.Write(hash);
				return "Help_GetCountriesList";
			});

		/// <summary>Mark <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> history as read		<para>See <a href="https://corefork.telegram.org/method/channels.readHistory"/></para></summary>
		/// <param name="channel"><a href="https://corefork.telegram.org/api/channel">Channel/supergroup</a></param>
		/// <param name="max_id">ID of message up to which messages should be marked as read</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/channels.readHistory#possible-errors">details</a>)</exception>
		public static Task<bool> Channels_ReadHistory(this Client client, InputChannelBase channel, int max_id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xCC104937);
				writer.WriteTLObject(channel);
				writer.Write(max_id);
				return "Channels_ReadHistory";
			});

		/// <summary>Delete messages in a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>		<para>See <a href="https://corefork.telegram.org/method/channels.deleteMessages"/></para></summary>
		/// <param name="channel"><a href="https://corefork.telegram.org/api/channel">Channel/supergroup</a></param>
		/// <param name="id">IDs of messages to delete</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/channels.deleteMessages#possible-errors">details</a>)</exception>
		public static Task<Messages_AffectedMessages> Channels_DeleteMessages(this Client client, InputChannelBase channel, int[] id)
			=> client.CallAsync<Messages_AffectedMessages>(writer =>
			{
				writer.Write(0x84C1FD4E);
				writer.WriteTLObject(channel);
				writer.WriteTLVector(id);
				return "Channels_DeleteMessages";
			});

		/// <summary>Delete all messages sent by a certain user in a <a href="https://corefork.telegram.org/api/channel">supergroup</a>		<para>See <a href="https://corefork.telegram.org/method/channels.deleteUserHistory"/></para></summary>
		/// <param name="channel"><a href="https://corefork.telegram.org/api/channel">Supergroup</a></param>
		/// <param name="user_id">User whose messages should be deleted</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/channels.deleteUserHistory#possible-errors">details</a>)</exception>
		public static Task<Messages_AffectedHistory> Channels_DeleteUserHistory(this Client client, InputChannelBase channel, InputUserBase user_id)
			=> client.CallAsync<Messages_AffectedHistory>(writer =>
			{
				writer.Write(0xD10DD71B);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(user_id);
				return "Channels_DeleteUserHistory";
			});

		/// <summary>Reports some messages from a user in a supergroup as spam; requires administrator rights in the supergroup		<para>See <a href="https://corefork.telegram.org/method/channels.reportSpam"/></para></summary>
		/// <param name="channel">Supergroup</param>
		/// <param name="user_id">ID of the user that sent the spam messages</param>
		/// <param name="id">IDs of spam messages</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/channels.reportSpam#possible-errors">details</a>)</exception>
		public static Task<bool> Channels_ReportSpam(this Client client, InputChannelBase channel, InputUserBase user_id, int[] id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xFE087810);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(user_id);
				writer.WriteTLVector(id);
				return "Channels_ReportSpam";
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> messages		<para>See <a href="https://corefork.telegram.org/method/channels.getMessages"/></para></summary>
		/// <param name="channel">Channel/supergroup</param>
		/// <param name="id">IDs of messages to get</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/channels.getMessages#possible-errors">details</a>)</exception>
		public static Task<Messages_MessagesBase> Channels_GetMessages(this Client client, InputChannelBase channel, InputMessage[] id)
			=> client.CallAsync<Messages_MessagesBase>(writer =>
			{
				writer.Write(0xAD8C9A23);
				writer.WriteTLObject(channel);
				writer.WriteTLVector(id);
				return "Channels_GetMessages";
			});

		/// <summary>Get the participants of a <a href="https://corefork.telegram.org/api/channel">supergroup/channel</a>		<para>See <a href="https://corefork.telegram.org/method/channels.getParticipants"/></para></summary>
		/// <param name="channel">Channel</param>
		/// <param name="filter">Which participant types to fetch</param>
		/// <param name="offset"><a href="https://corefork.telegram.org/api/offsets">Offset</a></param>
		/// <param name="limit"><a href="https://corefork.telegram.org/api/offsets">Limit</a></param>
		/// <param name="hash"><a href="https://corefork.telegram.org/api/offsets">Hash</a></param>
		/// <returns>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/channels.channelParticipantsNotModified">channels.channelParticipantsNotModified</a></returns>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/channels.getParticipants#possible-errors">details</a>)</exception>
		public static Task<Channels_ChannelParticipants> Channels_GetParticipants(this Client client, InputChannelBase channel, ChannelParticipantsFilter filter, int offset, int limit, long hash)
			=> client.CallAsync<Channels_ChannelParticipants>(writer =>
			{
				writer.Write(0x77CED9D0);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(filter);
				writer.Write(offset);
				writer.Write(limit);
				writer.Write(hash);
				return "Channels_GetParticipants";
			});

		/// <summary>Get info about a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> participant		<para>See <a href="https://corefork.telegram.org/method/channels.getParticipant"/></para></summary>
		/// <param name="channel">Channel/supergroup</param>
		/// <param name="participant">Participant to get info about</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/channels.getParticipant#possible-errors">details</a>)</exception>
		public static Task<Channels_ChannelParticipant> Channels_GetParticipant(this Client client, InputChannelBase channel, InputPeer participant)
			=> client.CallAsync<Channels_ChannelParticipant>(writer =>
			{
				writer.Write(0xA0AB6CC6);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(participant);
				return "Channels_GetParticipant";
			});

		/// <summary>Get info about <a href="https://corefork.telegram.org/api/channel">channels/supergroups</a>		<para>See <a href="https://corefork.telegram.org/method/channels.getChannels"/></para></summary>
		/// <param name="id">IDs of channels/supergroups to get info about</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/channels.getChannels#possible-errors">details</a>)</exception>
		public static Task<Messages_Chats> Channels_GetChannels(this Client client, InputChannelBase[] id)
			=> client.CallAsync<Messages_Chats>(writer =>
			{
				writer.Write(0x0A7F6BBB);
				writer.WriteTLVector(id);
				return "Channels_GetChannels";
			});

		/// <summary>Get full info about a channel		<para>See <a href="https://corefork.telegram.org/method/channels.getFullChannel"/></para></summary>
		/// <param name="channel">The channel to get info about</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/channels.getFullChannel#possible-errors">details</a>)</exception>
		public static Task<Messages_ChatFull> Channels_GetFullChannel(this Client client, InputChannelBase channel)
			=> client.CallAsync<Messages_ChatFull>(writer =>
			{
				writer.Write(0x08736A09);
				writer.WriteTLObject(channel);
				return "Channels_GetFullChannel";
			});

		/// <summary>Create a <a href="https://corefork.telegram.org/api/channel">supergroup/channel</a>.		<para>See <a href="https://corefork.telegram.org/method/channels.createChannel"/></para></summary>
		/// <param name="broadcast">Whether to create a <a href="https://corefork.telegram.org/api/channel">channel</a></param>
		/// <param name="megagroup">Whether to create a <a href="https://corefork.telegram.org/api/channel">supergroup</a></param>
		/// <param name="for_import">Whether the supergroup is being created to import messages from a foreign chat service using <a href="https://corefork.telegram.org/method/messages.initHistoryImport">messages.initHistoryImport</a></param>
		/// <param name="title">Channel title</param>
		/// <param name="about">Channel description</param>
		/// <param name="geo_point">Geogroup location</param>
		/// <param name="address">Geogroup address</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/channels.createChannel#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Channels_CreateChannel(this Client client, string title, string about, bool broadcast = false, bool megagroup = false, bool for_import = false, InputGeoPoint geo_point = null, string address = null)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x3D5FB10F);
				writer.Write((broadcast ? 0x1 : 0) | (megagroup ? 0x2 : 0) | (for_import ? 0x8 : 0) | (geo_point != null ? 0x4 : 0) | (address != null ? 0x4 : 0));
				writer.WriteTLString(title);
				writer.WriteTLString(about);
				if (geo_point != null)
					writer.WriteTLObject(geo_point);
				if (address != null)
					writer.WriteTLString(address);
				return "Channels_CreateChannel";
			});

		/// <summary>Modify the admin rights of a user in a <a href="https://corefork.telegram.org/api/channel">supergroup/channel</a>.		<para>See <a href="https://corefork.telegram.org/method/channels.editAdmin"/></para></summary>
		/// <param name="channel">The <a href="https://corefork.telegram.org/api/channel">supergroup/channel</a>.</param>
		/// <param name="user_id">The ID of the user whose admin rights should be modified</param>
		/// <param name="admin_rights">The admin rights</param>
		/// <param name="rank">Indicates the role (rank) of the admin in the group: just an arbitrary string</param>
		/// <exception cref="RpcException">Possible errors: 400,403,406 (<a href="https://corefork.telegram.org/method/channels.editAdmin#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Channels_EditAdmin(this Client client, InputChannelBase channel, InputUserBase user_id, ChatAdminRights admin_rights, string rank)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xD33C8902);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(user_id);
				writer.WriteTLObject(admin_rights);
				writer.WriteTLString(rank);
				return "Channels_EditAdmin";
			});

		/// <summary>Edit the name of a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>		<para>See <a href="https://corefork.telegram.org/method/channels.editTitle"/></para></summary>
		/// <param name="channel">Channel/supergroup</param>
		/// <param name="title">New name</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/channels.editTitle#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Channels_EditTitle(this Client client, InputChannelBase channel, string title)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x566DECD0);
				writer.WriteTLObject(channel);
				writer.WriteTLString(title);
				return "Channels_EditTitle";
			});

		/// <summary>Change the photo of a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>		<para>See <a href="https://corefork.telegram.org/method/channels.editPhoto"/></para></summary>
		/// <param name="channel">Channel/supergroup whose photo should be edited</param>
		/// <param name="photo">New photo</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/channels.editPhoto#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Channels_EditPhoto(this Client client, InputChannelBase channel, InputChatPhotoBase photo)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xF12E57C9);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(photo);
				return "Channels_EditPhoto";
			});

		/// <summary>Check if a username is free and can be assigned to a channel/supergroup		<para>See <a href="https://corefork.telegram.org/method/channels.checkUsername"/></para></summary>
		/// <param name="channel">The <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> that will assigned the specified username</param>
		/// <param name="username">The username to check</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/channels.checkUsername#possible-errors">details</a>)</exception>
		public static Task<bool> Channels_CheckUsername(this Client client, InputChannelBase channel, string username)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x10E6BD2C);
				writer.WriteTLObject(channel);
				writer.WriteTLString(username);
				return "Channels_CheckUsername";
			});

		/// <summary>Change the username of a supergroup/channel		<para>See <a href="https://corefork.telegram.org/method/channels.updateUsername"/></para></summary>
		/// <param name="channel">Channel</param>
		/// <param name="username">New username</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/channels.updateUsername#possible-errors">details</a>)</exception>
		public static Task<bool> Channels_UpdateUsername(this Client client, InputChannelBase channel, string username)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x3514B3DE);
				writer.WriteTLObject(channel);
				writer.WriteTLString(username);
				return "Channels_UpdateUsername";
			});

		/// <summary>Join a channel/supergroup		<para>See <a href="https://corefork.telegram.org/method/channels.joinChannel"/></para></summary>
		/// <param name="channel">Channel/supergroup to join</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/channels.joinChannel#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Channels_JoinChannel(this Client client, InputChannelBase channel)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x24B524C5);
				writer.WriteTLObject(channel);
				return "Channels_JoinChannel";
			});

		/// <summary>Leave a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>		<para>See <a href="https://corefork.telegram.org/method/channels.leaveChannel"/></para></summary>
		/// <param name="channel"><a href="https://corefork.telegram.org/api/channel">Channel/supergroup</a> to leave</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/channels.leaveChannel#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Channels_LeaveChannel(this Client client, InputChannelBase channel)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xF836AA95);
				writer.WriteTLObject(channel);
				return "Channels_LeaveChannel";
			});

		/// <summary>Invite users to a channel/supergroup		<para>See <a href="https://corefork.telegram.org/method/channels.inviteToChannel"/></para></summary>
		/// <param name="channel">Channel/supergroup</param>
		/// <param name="users">Users to invite</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/channels.inviteToChannel#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Channels_InviteToChannel(this Client client, InputChannelBase channel, InputUserBase[] users)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x199F3A6C);
				writer.WriteTLObject(channel);
				writer.WriteTLVector(users);
				return "Channels_InviteToChannel";
			});

		/// <summary>Delete a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>		<para>See <a href="https://corefork.telegram.org/method/channels.deleteChannel"/></para></summary>
		/// <param name="channel"><a href="https://corefork.telegram.org/api/channel">Channel/supergroup</a> to delete</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/channels.deleteChannel#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Channels_DeleteChannel(this Client client, InputChannelBase channel)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xC0111FE3);
				writer.WriteTLObject(channel);
				return "Channels_DeleteChannel";
			});

		/// <summary>Get link and embed info of a message in a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>		<para>See <a href="https://corefork.telegram.org/method/channels.exportMessageLink"/></para></summary>
		/// <param name="grouped">Whether to include other grouped media (for albums)</param>
		/// <param name="thread">Whether to also include a thread ID, if available, inside of the link</param>
		/// <param name="channel">Channel</param>
		/// <param name="id">Message ID</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/channels.exportMessageLink#possible-errors">details</a>)</exception>
		public static Task<ExportedMessageLink> Channels_ExportMessageLink(this Client client, InputChannelBase channel, int id, bool grouped = false, bool thread = false)
			=> client.CallAsync<ExportedMessageLink>(writer =>
			{
				writer.Write(0xE63FADEB);
				writer.Write((grouped ? 0x1 : 0) | (thread ? 0x2 : 0));
				writer.WriteTLObject(channel);
				writer.Write(id);
				return "Channels_ExportMessageLink";
			});

		/// <summary>Enable/disable message signatures in channels		<para>See <a href="https://corefork.telegram.org/method/channels.toggleSignatures"/></para></summary>
		/// <param name="channel">Channel</param>
		/// <param name="enabled">Value</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/channels.toggleSignatures#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Channels_ToggleSignatures(this Client client, InputChannelBase channel, bool enabled)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x1F69B606);
				writer.WriteTLObject(channel);
				writer.Write(enabled ? 0x997275B5 : 0xBC799737);
				return "Channels_ToggleSignatures";
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/channel">channels/supergroups/geogroups</a> we're admin in. Usually called when the user exceeds the <see cref="Config"/> for owned public <a href="https://corefork.telegram.org/api/channel">channels/supergroups/geogroups</a>, and the user is given the choice to remove one of his channels/supergroups/geogroups.		<para>See <a href="https://corefork.telegram.org/method/channels.getAdminedPublicChannels"/></para></summary>
		/// <param name="by_location">Get geogroups</param>
		/// <param name="check_limit">If set and the user has reached the limit of owned public <a href="https://corefork.telegram.org/api/channel">channels/supergroups/geogroups</a>, instead of returning the channel list one of the specified <a href="#possible-errors">errors</a> will be returned.<br/>Useful to check if a new public channel can indeed be created, even before asking the user to enter a channel username to use in <a href="https://corefork.telegram.org/method/channels.checkUsername">channels.checkUsername</a>/<a href="https://corefork.telegram.org/method/channels.updateUsername">channels.updateUsername</a>.</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/channels.getAdminedPublicChannels#possible-errors">details</a>)</exception>
		public static Task<Messages_Chats> Channels_GetAdminedPublicChannels(this Client client, bool by_location = false, bool check_limit = false)
			=> client.CallAsync<Messages_Chats>(writer =>
			{
				writer.Write(0xF8B036AF);
				writer.Write((by_location ? 0x1 : 0) | (check_limit ? 0x2 : 0));
				return "Channels_GetAdminedPublicChannels";
			});

		/// <summary>Ban/unban/kick a user in a <a href="https://corefork.telegram.org/api/channel">supergroup/channel</a>.		<para>See <a href="https://corefork.telegram.org/method/channels.editBanned"/></para></summary>
		/// <param name="channel">The <a href="https://corefork.telegram.org/api/channel">supergroup/channel</a>.</param>
		/// <param name="participant">Participant to ban</param>
		/// <param name="banned_rights">The banned rights</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/channels.editBanned#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Channels_EditBanned(this Client client, InputChannelBase channel, InputPeer participant, ChatBannedRights banned_rights)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x96E6CD81);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(participant);
				writer.WriteTLObject(banned_rights);
				return "Channels_EditBanned";
			});

		/// <summary>Get the admin log of a <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a>		<para>See <a href="https://corefork.telegram.org/method/channels.getAdminLog"/></para></summary>
		/// <param name="channel">Channel</param>
		/// <param name="q">Search query, can be empty</param>
		/// <param name="events_filter">Event filter</param>
		/// <param name="admins">Only show events from these admins</param>
		/// <param name="max_id">Maximum ID of message to return (see <a href="https://corefork.telegram.org/api/offsets">pagination</a>)</param>
		/// <param name="min_id">Minimum ID of message to return (see <a href="https://corefork.telegram.org/api/offsets">pagination</a>)</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/channels.getAdminLog#possible-errors">details</a>)</exception>
		public static Task<Channels_AdminLogResults> Channels_GetAdminLog(this Client client, InputChannelBase channel, string q, long max_id, long min_id, int limit, ChannelAdminLogEventsFilter events_filter = null, InputUserBase[] admins = null)
			=> client.CallAsync<Channels_AdminLogResults>(writer =>
			{
				writer.Write(0x33DDF480);
				writer.Write((events_filter != null ? 0x1 : 0) | (admins != null ? 0x2 : 0));
				writer.WriteTLObject(channel);
				writer.WriteTLString(q);
				if (events_filter != null)
					writer.WriteTLObject(events_filter);
				if (admins != null)
					writer.WriteTLVector(admins);
				writer.Write(max_id);
				writer.Write(min_id);
				writer.Write(limit);
				return "Channels_GetAdminLog";
			});

		/// <summary>Associate a stickerset to the supergroup		<para>See <a href="https://corefork.telegram.org/method/channels.setStickers"/></para></summary>
		/// <param name="channel">Supergroup</param>
		/// <param name="stickerset">The stickerset to associate</param>
		/// <exception cref="RpcException">Possible errors: 400,406 (<a href="https://corefork.telegram.org/method/channels.setStickers#possible-errors">details</a>)</exception>
		public static Task<bool> Channels_SetStickers(this Client client, InputChannelBase channel, InputStickerSet stickerset)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xEA8CA4F9);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(stickerset);
				return "Channels_SetStickers";
			});

		/// <summary>Mark <a href="https://corefork.telegram.org/api/channel">channel/supergroup</a> message contents as read		<para>See <a href="https://corefork.telegram.org/method/channels.readMessageContents"/></para></summary>
		/// <param name="channel"><a href="https://corefork.telegram.org/api/channel">Channel/supergroup</a></param>
		/// <param name="id">IDs of messages whose contents should be marked as read</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/channels.readMessageContents#possible-errors">details</a>)</exception>
		public static Task<bool> Channels_ReadMessageContents(this Client client, InputChannelBase channel, int[] id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xEAB5DC38);
				writer.WriteTLObject(channel);
				writer.WriteTLVector(id);
				return "Channels_ReadMessageContents";
			});

		/// <summary>Delete the history of a <a href="https://corefork.telegram.org/api/channel">supergroup</a>		<para>See <a href="https://corefork.telegram.org/method/channels.deleteHistory"/></para></summary>
		/// <param name="channel"><a href="https://corefork.telegram.org/api/channel">Supergroup</a> whose history must be deleted</param>
		/// <param name="max_id">ID of message <strong>up to which</strong> the history must be deleted</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/channels.deleteHistory#possible-errors">details</a>)</exception>
		public static Task<bool> Channels_DeleteHistory(this Client client, InputChannelBase channel, int max_id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xAF369D42);
				writer.WriteTLObject(channel);
				writer.Write(max_id);
				return "Channels_DeleteHistory";
			});

		/// <summary>Hide/unhide message history for new channel/supergroup users		<para>See <a href="https://corefork.telegram.org/method/channels.togglePreHistoryHidden"/></para></summary>
		/// <param name="channel">Channel/supergroup</param>
		/// <param name="enabled">Hide/unhide</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/channels.togglePreHistoryHidden#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Channels_TogglePreHistoryHidden(this Client client, InputChannelBase channel, bool enabled)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xEABBB94C);
				writer.WriteTLObject(channel);
				writer.Write(enabled ? 0x997275B5 : 0xBC799737);
				return "Channels_TogglePreHistoryHidden";
			});

		/// <summary>Get a list of <a href="https://corefork.telegram.org/api/channel">channels/supergroups</a> we left		<para>See <a href="https://corefork.telegram.org/method/channels.getLeftChannels"/></para></summary>
		/// <param name="offset">Offset for <a href="https://corefork.telegram.org/api/offsets">pagination</a></param>
		/// <exception cref="RpcException">Possible errors: 403 (<a href="https://corefork.telegram.org/method/channels.getLeftChannels#possible-errors">details</a>)</exception>
		public static Task<Messages_Chats> Channels_GetLeftChannels(this Client client, int offset)
			=> client.CallAsync<Messages_Chats>(writer =>
			{
				writer.Write(0x8341ECC0);
				writer.Write(offset);
				return "Channels_GetLeftChannels";
			});

		/// <summary>Get all groups that can be used as <a href="https://corefork.telegram.org/api/discussion">discussion groups</a>.		<para>See <a href="https://corefork.telegram.org/method/channels.getGroupsForDiscussion"/></para></summary>
		public static Task<Messages_Chats> Channels_GetGroupsForDiscussion(this Client client)
			=> client.CallAsync<Messages_Chats>(writer =>
			{
				writer.Write(0xF5DAD378);
				return "Channels_GetGroupsForDiscussion";
			});

		/// <summary>Associate a group to a channel as <a href="https://corefork.telegram.org/api/discussion">discussion group</a> for that channel		<para>See <a href="https://corefork.telegram.org/method/channels.setDiscussionGroup"/></para></summary>
		/// <param name="broadcast">Channel</param>
		/// <param name="group"><a href="https://corefork.telegram.org/api/discussion">Discussion group</a> to associate to the channel</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/channels.setDiscussionGroup#possible-errors">details</a>)</exception>
		public static Task<bool> Channels_SetDiscussionGroup(this Client client, InputChannelBase broadcast, InputChannelBase group)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x40582BB2);
				writer.WriteTLObject(broadcast);
				writer.WriteTLObject(group);
				return "Channels_SetDiscussionGroup";
			});

		/// <summary>Transfer channel ownership		<para>See <a href="https://corefork.telegram.org/method/channels.editCreator"/></para></summary>
		/// <param name="channel">Channel</param>
		/// <param name="user_id">New channel owner</param>
		/// <param name="password"><a href="https://corefork.telegram.org/api/srp">2FA password</a> of account</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/channels.editCreator#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Channels_EditCreator(this Client client, InputChannelBase channel, InputUserBase user_id, InputCheckPasswordSRP password)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x8F38CD1F);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(user_id);
				writer.WriteTLObject(password);
				return "Channels_EditCreator";
			});

		/// <summary>Edit location of geogroup		<para>See <a href="https://corefork.telegram.org/method/channels.editLocation"/></para></summary>
		/// <param name="channel"><a href="https://corefork.telegram.org/api/channel">Geogroup</a></param>
		/// <param name="geo_point">New geolocation</param>
		/// <param name="address">Address string</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/channels.editLocation#possible-errors">details</a>)</exception>
		public static Task<bool> Channels_EditLocation(this Client client, InputChannelBase channel, InputGeoPoint geo_point, string address)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x58E63F6D);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(geo_point);
				writer.WriteTLString(address);
				return "Channels_EditLocation";
			});

		/// <summary>Toggle supergroup slow mode: if enabled, users will only be able to send one message every <c>seconds</c> seconds		<para>See <a href="https://corefork.telegram.org/method/channels.toggleSlowMode"/></para></summary>
		/// <param name="channel">The <a href="https://corefork.telegram.org/api/channel">supergroup</a></param>
		/// <param name="seconds">Users will only be able to send one message every <c>seconds</c> seconds, <c>0</c> to disable the limitation</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/channels.toggleSlowMode#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Channels_ToggleSlowMode(this Client client, InputChannelBase channel, int seconds)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xEDD49EF0);
				writer.WriteTLObject(channel);
				writer.Write(seconds);
				return "Channels_ToggleSlowMode";
			});

		/// <summary>Get inactive channels and supergroups		<para>See <a href="https://corefork.telegram.org/method/channels.getInactiveChannels"/></para></summary>
		public static Task<Messages_InactiveChats> Channels_GetInactiveChannels(this Client client)
			=> client.CallAsync<Messages_InactiveChats>(writer =>
			{
				writer.Write(0x11E831EE);
				return "Channels_GetInactiveChannels";
			});

		/// <summary><para>See <a href="https://corefork.telegram.org/method/channels.convertToGigagroup"/></para></summary>
		public static Task<UpdatesBase> Channels_ConvertToGigagroup(this Client client, InputChannelBase channel)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x0B290C69);
				writer.WriteTLObject(channel);
				return "Channels_ConvertToGigagroup";
			});

		/// <summary>Mark a specific sponsored message as read		<para>See <a href="https://corefork.telegram.org/method/channels.viewSponsoredMessage"/></para></summary>
		/// <param name="channel">Peer</param>
		/// <param name="random_id">Message ID</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/channels.viewSponsoredMessage#possible-errors">details</a>)</exception>
		public static Task<bool> Channels_ViewSponsoredMessage(this Client client, InputChannelBase channel, byte[] random_id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xBEAEDB94);
				writer.WriteTLObject(channel);
				writer.WriteTLBytes(random_id);
				return "Channels_ViewSponsoredMessage";
			});

		/// <summary>Get a list of sponsored messages		<para>See <a href="https://corefork.telegram.org/method/channels.getSponsoredMessages"/></para></summary>
		/// <param name="channel">Peer</param>
		public static Task<Messages_SponsoredMessages> Channels_GetSponsoredMessages(this Client client, InputChannelBase channel)
			=> client.CallAsync<Messages_SponsoredMessages>(writer =>
			{
				writer.Write(0xEC210FBF);
				writer.WriteTLObject(channel);
				return "Channels_GetSponsoredMessages";
			});

		/// <summary>Sends a custom request; for bots only		<para>See <a href="https://corefork.telegram.org/method/bots.sendCustomRequest"/></para></summary>
		/// <param name="custom_method">The method name</param>
		/// <param name="params_">JSON-serialized method parameters</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/bots.sendCustomRequest#possible-errors">details</a>)</exception>
		public static Task<DataJSON> Bots_SendCustomRequest(this Client client, string custom_method, DataJSON params_)
			=> client.CallAsync<DataJSON>(writer =>
			{
				writer.Write(0xAA2769ED);
				writer.WriteTLString(custom_method);
				writer.WriteTLObject(params_);
				return "Bots_SendCustomRequest";
			});

		/// <summary>Answers a custom query; for bots only		<para>See <a href="https://corefork.telegram.org/method/bots.answerWebhookJSONQuery"/></para></summary>
		/// <param name="query_id">Identifier of a custom query</param>
		/// <param name="data">JSON-serialized answer to the query</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/bots.answerWebhookJSONQuery#possible-errors">details</a>)</exception>
		public static Task<bool> Bots_AnswerWebhookJSONQuery(this Client client, long query_id, DataJSON data)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xE6213F4D);
				writer.Write(query_id);
				writer.WriteTLObject(data);
				return "Bots_AnswerWebhookJSONQuery";
			});

		/// <summary>Set bot command list		<para>See <a href="https://corefork.telegram.org/method/bots.setBotCommands"/></para></summary>
		/// <param name="scope">Command scope</param>
		/// <param name="lang_code">Language code</param>
		/// <param name="commands">Bot commands</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/bots.setBotCommands#possible-errors">details</a>)</exception>
		public static Task<bool> Bots_SetBotCommands(this Client client, BotCommandScope scope, string lang_code, BotCommand[] commands)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x0517165A);
				writer.WriteTLObject(scope);
				writer.WriteTLString(lang_code);
				writer.WriteTLVector(commands);
				return "Bots_SetBotCommands";
			});

		/// <summary>Clear bot commands for the specified bot scope and language code		<para>See <a href="https://corefork.telegram.org/method/bots.resetBotCommands"/></para></summary>
		/// <param name="scope">Command scope</param>
		/// <param name="lang_code">Language code</param>
		public static Task<bool> Bots_ResetBotCommands(this Client client, BotCommandScope scope, string lang_code)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x3D8DE0F9);
				writer.WriteTLObject(scope);
				writer.WriteTLString(lang_code);
				return "Bots_ResetBotCommands";
			});

		/// <summary>Obtain a list of bot commands for the specified bot scope and language code		<para>See <a href="https://corefork.telegram.org/method/bots.getBotCommands"/></para></summary>
		/// <param name="scope">Command scope</param>
		/// <param name="lang_code">Language code</param>
		public static Task<BotCommand[]> Bots_GetBotCommands(this Client client, BotCommandScope scope, string lang_code)
			=> client.CallAsync<BotCommand[]>(writer =>
			{
				writer.Write(0xE34C0DD6);
				writer.WriteTLObject(scope);
				writer.WriteTLString(lang_code);
				return "Bots_GetBotCommands";
			});

		/// <summary>Get a payment form		<para>See <a href="https://corefork.telegram.org/method/payments.getPaymentForm"/></para></summary>
		/// <param name="peer">The peer where the payment form was sent</param>
		/// <param name="msg_id">Message ID of payment form</param>
		/// <param name="theme_params">A JSON object with the following keys, containing color theme information (integers, RGB24) to pass to the payment provider, to apply in eventual verification pages: <br/><c>bg_color</c> - Background color <br/><c>text_color</c> - Text color <br/><c>hint_color</c> - Hint text color <br/><c>link_color</c> - Link color <br/><c>button_color</c> - Button color <br/><c>button_text_color</c> - Button text color</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/payments.getPaymentForm#possible-errors">details</a>)</exception>
		public static Task<Payments_PaymentForm> Payments_GetPaymentForm(this Client client, InputPeer peer, int msg_id, DataJSON theme_params = null)
			=> client.CallAsync<Payments_PaymentForm>(writer =>
			{
				writer.Write(0x8A333C8D);
				writer.Write(theme_params != null ? 0x1 : 0);
				writer.WriteTLObject(peer);
				writer.Write(msg_id);
				if (theme_params != null)
					writer.WriteTLObject(theme_params);
				return "Payments_GetPaymentForm";
			});

		/// <summary>Get payment receipt		<para>See <a href="https://corefork.telegram.org/method/payments.getPaymentReceipt"/></para></summary>
		/// <param name="peer">The peer where the payment receipt was sent</param>
		/// <param name="msg_id">Message ID of receipt</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/payments.getPaymentReceipt#possible-errors">details</a>)</exception>
		public static Task<Payments_PaymentReceipt> Payments_GetPaymentReceipt(this Client client, InputPeer peer, int msg_id)
			=> client.CallAsync<Payments_PaymentReceipt>(writer =>
			{
				writer.Write(0x2478D1CC);
				writer.WriteTLObject(peer);
				writer.Write(msg_id);
				return "Payments_GetPaymentReceipt";
			});

		/// <summary>Submit requested order information for validation		<para>See <a href="https://corefork.telegram.org/method/payments.validateRequestedInfo"/></para></summary>
		/// <param name="save">Save order information to re-use it for future orders</param>
		/// <param name="peer">Peer where the payment form was sent</param>
		/// <param name="msg_id">Message ID of payment form</param>
		/// <param name="info">Requested order information</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/payments.validateRequestedInfo#possible-errors">details</a>)</exception>
		public static Task<Payments_ValidatedRequestedInfo> Payments_ValidateRequestedInfo(this Client client, InputPeer peer, int msg_id, PaymentRequestedInfo info, bool save = false)
			=> client.CallAsync<Payments_ValidatedRequestedInfo>(writer =>
			{
				writer.Write(0xDB103170);
				writer.Write(save ? 0x1 : 0);
				writer.WriteTLObject(peer);
				writer.Write(msg_id);
				writer.WriteTLObject(info);
				return "Payments_ValidateRequestedInfo";
			});

		/// <summary>Send compiled payment form		<para>See <a href="https://corefork.telegram.org/method/payments.sendPaymentForm"/></para></summary>
		/// <param name="form_id">Form ID</param>
		/// <param name="peer">The peer where the payment form was sent</param>
		/// <param name="msg_id">Message ID of form</param>
		/// <param name="requested_info_id">ID of saved and validated <see cref="Payments_ValidatedRequestedInfo"/></param>
		/// <param name="shipping_option_id">Chosen shipping option ID</param>
		/// <param name="credentials">Payment credentials</param>
		/// <param name="tip_amount">Tip, in the smallest units of the currency (integer, not float/double). For example, for a price of <c>US$ 1.45</c> pass <c>amount = 145</c>. See the exp parameter in <a href="https://corefork.telegram.org/bots/payments/currencies.json">currencies.json</a>, it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/payments.sendPaymentForm#possible-errors">details</a>)</exception>
		public static Task<Payments_PaymentResultBase> Payments_SendPaymentForm(this Client client, long form_id, InputPeer peer, int msg_id, InputPaymentCredentialsBase credentials, string requested_info_id = null, string shipping_option_id = null, long? tip_amount = null)
			=> client.CallAsync<Payments_PaymentResultBase>(writer =>
			{
				writer.Write(0x30C3BC9D);
				writer.Write((requested_info_id != null ? 0x1 : 0) | (shipping_option_id != null ? 0x2 : 0) | (tip_amount != null ? 0x4 : 0));
				writer.Write(form_id);
				writer.WriteTLObject(peer);
				writer.Write(msg_id);
				if (requested_info_id != null)
					writer.WriteTLString(requested_info_id);
				if (shipping_option_id != null)
					writer.WriteTLString(shipping_option_id);
				writer.WriteTLObject(credentials);
				if (tip_amount != null)
					writer.Write(tip_amount.Value);
				return "Payments_SendPaymentForm";
			});

		/// <summary>Get saved payment information		<para>See <a href="https://corefork.telegram.org/method/payments.getSavedInfo"/></para></summary>
		public static Task<Payments_SavedInfo> Payments_GetSavedInfo(this Client client)
			=> client.CallAsync<Payments_SavedInfo>(writer =>
			{
				writer.Write(0x227D824B);
				return "Payments_GetSavedInfo";
			});

		/// <summary>Clear saved payment information		<para>See <a href="https://corefork.telegram.org/method/payments.clearSavedInfo"/></para></summary>
		/// <param name="credentials">Remove saved payment credentials</param>
		/// <param name="info">Clear the last order settings saved by the user</param>
		public static Task<bool> Payments_ClearSavedInfo(this Client client, bool credentials = false, bool info = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xD83D70C1);
				writer.Write((credentials ? 0x1 : 0) | (info ? 0x2 : 0));
				return "Payments_ClearSavedInfo";
			});

		/// <summary>Get info about a credit card		<para>See <a href="https://corefork.telegram.org/method/payments.getBankCardData"/></para></summary>
		/// <param name="number">Credit card number</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/payments.getBankCardData#possible-errors">details</a>)</exception>
		public static Task<Payments_BankCardData> Payments_GetBankCardData(this Client client, string number)
			=> client.CallAsync<Payments_BankCardData>(writer =>
			{
				writer.Write(0x2E79D779);
				writer.WriteTLString(number);
				return "Payments_GetBankCardData";
			});

		/// <summary>Create a stickerset, bots only.		<para>See <a href="https://corefork.telegram.org/method/stickers.createStickerSet"/></para></summary>
		/// <param name="masks">Whether this is a mask stickerset</param>
		/// <param name="animated">Whether this is an animated stickerset</param>
		/// <param name="user_id">Stickerset owner</param>
		/// <param name="title">Stickerset name, <c>1-64</c> chars</param>
		/// <param name="short_name">Sticker set name. Can contain only English letters, digits and underscores. Must end with <em>"</em>by<em><bot username="">"</bot></em> (<em><bot_username></bot_username></em> is case insensitive); 1-64 characters</param>
		/// <param name="thumb">Thumbnail</param>
		/// <param name="stickers">Stickers</param>
		/// <param name="software">Used when <a href="https://corefork.telegram.org/import-stickers">importing stickers using the sticker import SDKs</a>, specifies the name of the software that created the stickers</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/stickers.createStickerSet#possible-errors">details</a>)</exception>
		public static Task<Messages_StickerSet> Stickers_CreateStickerSet(this Client client, InputUserBase user_id, string title, string short_name, InputStickerSetItem[] stickers, bool masks = false, bool animated = false, InputDocument thumb = null, string software = null)
			=> client.CallAsync<Messages_StickerSet>(writer =>
			{
				writer.Write(0x9021AB67);
				writer.Write((masks ? 0x1 : 0) | (animated ? 0x2 : 0) | (thumb != null ? 0x4 : 0) | (software != null ? 0x8 : 0));
				writer.WriteTLObject(user_id);
				writer.WriteTLString(title);
				writer.WriteTLString(short_name);
				if (thumb != null)
					writer.WriteTLObject(thumb);
				writer.WriteTLVector(stickers);
				if (software != null)
					writer.WriteTLString(software);
				return "Stickers_CreateStickerSet";
			});

		/// <summary>Remove a sticker from the set where it belongs, bots only. The sticker set must have been created by the bot.		<para>See <a href="https://corefork.telegram.org/method/stickers.removeStickerFromSet"/></para></summary>
		/// <param name="sticker">The sticker to remove</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/stickers.removeStickerFromSet#possible-errors">details</a>)</exception>
		public static Task<Messages_StickerSet> Stickers_RemoveStickerFromSet(this Client client, InputDocument sticker)
			=> client.CallAsync<Messages_StickerSet>(writer =>
			{
				writer.Write(0xF7760F51);
				writer.WriteTLObject(sticker);
				return "Stickers_RemoveStickerFromSet";
			});

		/// <summary>Changes the absolute position of a sticker in the set to which it belongs; for bots only. The sticker set must have been created by the bot		<para>See <a href="https://corefork.telegram.org/method/stickers.changeStickerPosition"/></para></summary>
		/// <param name="sticker">The sticker</param>
		/// <param name="position">The new position of the sticker, zero-based</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/stickers.changeStickerPosition#possible-errors">details</a>)</exception>
		public static Task<Messages_StickerSet> Stickers_ChangeStickerPosition(this Client client, InputDocument sticker, int position)
			=> client.CallAsync<Messages_StickerSet>(writer =>
			{
				writer.Write(0xFFB6D4CA);
				writer.WriteTLObject(sticker);
				writer.Write(position);
				return "Stickers_ChangeStickerPosition";
			});

		/// <summary>Add a sticker to a stickerset, bots only. The sticker set must have been created by the bot.		<para>See <a href="https://corefork.telegram.org/method/stickers.addStickerToSet"/></para></summary>
		/// <param name="stickerset">The stickerset</param>
		/// <param name="sticker">The sticker</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/stickers.addStickerToSet#possible-errors">details</a>)</exception>
		public static Task<Messages_StickerSet> Stickers_AddStickerToSet(this Client client, InputStickerSet stickerset, InputStickerSetItem sticker)
			=> client.CallAsync<Messages_StickerSet>(writer =>
			{
				writer.Write(0x8653FEBE);
				writer.WriteTLObject(stickerset);
				writer.WriteTLObject(sticker);
				return "Stickers_AddStickerToSet";
			});

		/// <summary>Set stickerset thumbnail		<para>See <a href="https://corefork.telegram.org/method/stickers.setStickerSetThumb"/></para></summary>
		/// <param name="stickerset">Stickerset</param>
		/// <param name="thumb">Thumbnail</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/stickers.setStickerSetThumb#possible-errors">details</a>)</exception>
		public static Task<Messages_StickerSet> Stickers_SetStickerSetThumb(this Client client, InputStickerSet stickerset, InputDocument thumb)
			=> client.CallAsync<Messages_StickerSet>(writer =>
			{
				writer.Write(0x9A364E30);
				writer.WriteTLObject(stickerset);
				writer.WriteTLObject(thumb);
				return "Stickers_SetStickerSetThumb";
			});

		/// <summary>Check whether the given short name is available		<para>See <a href="https://corefork.telegram.org/method/stickers.checkShortName"/></para></summary>
		/// <param name="short_name">Short name</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/stickers.checkShortName#possible-errors">details</a>)</exception>
		public static Task<bool> Stickers_CheckShortName(this Client client, string short_name)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x284B3639);
				writer.WriteTLString(short_name);
				return "Stickers_CheckShortName";
			});

		/// <summary>Suggests a short name for a given stickerpack name		<para>See <a href="https://corefork.telegram.org/method/stickers.suggestShortName"/></para></summary>
		/// <param name="title">Sticker pack name</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/stickers.suggestShortName#possible-errors">details</a>)</exception>
		public static Task<Stickers_SuggestedShortName> Stickers_SuggestShortName(this Client client, string title)
			=> client.CallAsync<Stickers_SuggestedShortName>(writer =>
			{
				writer.Write(0x4DAFC503);
				writer.WriteTLString(title);
				return "Stickers_SuggestShortName";
			});

		/// <summary>Get phone call configuration to be passed to libtgvoip's shared config		<para>See <a href="https://corefork.telegram.org/method/phone.getCallConfig"/></para></summary>
		public static Task<DataJSON> Phone_GetCallConfig(this Client client)
			=> client.CallAsync<DataJSON>(writer =>
			{
				writer.Write(0x55451FA9);
				return "Phone_GetCallConfig";
			});

		/// <summary>Start a telegram phone call		<para>See <a href="https://corefork.telegram.org/method/phone.requestCall"/></para></summary>
		/// <param name="video">Whether to start a video call</param>
		/// <param name="user_id">Destination of the phone call</param>
		/// <param name="random_id">Random ID to avoid resending the same object</param>
		/// <param name="g_a_hash"><a href="https://corefork.telegram.org/api/end-to-end/voice-calls">Parameter for E2E encryption key exchange »</a></param>
		/// <param name="protocol">Phone call settings</param>
		/// <exception cref="RpcException">Possible errors: 400,403 (<a href="https://corefork.telegram.org/method/phone.requestCall#possible-errors">details</a>)</exception>
		public static Task<Phone_PhoneCall> Phone_RequestCall(this Client client, InputUserBase user_id, int random_id, byte[] g_a_hash, PhoneCallProtocol protocol, bool video = false)
			=> client.CallAsync<Phone_PhoneCall>(writer =>
			{
				writer.Write(0x42FF96ED);
				writer.Write(video ? 0x1 : 0);
				writer.WriteTLObject(user_id);
				writer.Write(random_id);
				writer.WriteTLBytes(g_a_hash);
				writer.WriteTLObject(protocol);
				return "Phone_RequestCall";
			});

		/// <summary>Accept incoming call		<para>See <a href="https://corefork.telegram.org/method/phone.acceptCall"/></para></summary>
		/// <param name="peer">The call to accept</param>
		/// <param name="g_b"><a href="https://corefork.telegram.org/api/end-to-end/voice-calls">Parameter for E2E encryption key exchange »</a></param>
		/// <param name="protocol">Phone call settings</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/phone.acceptCall#possible-errors">details</a>)</exception>
		public static Task<Phone_PhoneCall> Phone_AcceptCall(this Client client, InputPhoneCall peer, byte[] g_b, PhoneCallProtocol protocol)
			=> client.CallAsync<Phone_PhoneCall>(writer =>
			{
				writer.Write(0x3BD2B4A0);
				writer.WriteTLObject(peer);
				writer.WriteTLBytes(g_b);
				writer.WriteTLObject(protocol);
				return "Phone_AcceptCall";
			});

		/// <summary><a href="https://corefork.telegram.org/api/end-to-end/voice-calls">Complete phone call E2E encryption key exchange »</a>		<para>See <a href="https://corefork.telegram.org/method/phone.confirmCall"/></para></summary>
		/// <param name="peer">The phone call</param>
		/// <param name="g_a"><a href="https://corefork.telegram.org/api/end-to-end/voice-calls">Parameter for E2E encryption key exchange »</a></param>
		/// <param name="key_fingerprint">Key fingerprint</param>
		/// <param name="protocol">Phone call settings</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/phone.confirmCall#possible-errors">details</a>)</exception>
		public static Task<Phone_PhoneCall> Phone_ConfirmCall(this Client client, InputPhoneCall peer, byte[] g_a, long key_fingerprint, PhoneCallProtocol protocol)
			=> client.CallAsync<Phone_PhoneCall>(writer =>
			{
				writer.Write(0x2EFE1722);
				writer.WriteTLObject(peer);
				writer.WriteTLBytes(g_a);
				writer.Write(key_fingerprint);
				writer.WriteTLObject(protocol);
				return "Phone_ConfirmCall";
			});

		/// <summary>Optional: notify the server that the user is currently busy in a call: this will automatically refuse all incoming phone calls until the current phone call is ended.		<para>See <a href="https://corefork.telegram.org/method/phone.receivedCall"/></para></summary>
		/// <param name="peer">The phone call we're currently in</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/phone.receivedCall#possible-errors">details</a>)</exception>
		public static Task<bool> Phone_ReceivedCall(this Client client, InputPhoneCall peer)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x17D54F61);
				writer.WriteTLObject(peer);
				return "Phone_ReceivedCall";
			});

		/// <summary>Refuse or end running call		<para>See <a href="https://corefork.telegram.org/method/phone.discardCall"/></para></summary>
		/// <param name="video">Whether this is a video call</param>
		/// <param name="peer">The phone call</param>
		/// <param name="duration">Call duration</param>
		/// <param name="reason">Why was the call discarded</param>
		/// <param name="connection_id">Preferred libtgvoip relay ID</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/phone.discardCall#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Phone_DiscardCall(this Client client, InputPhoneCall peer, int duration, PhoneCallDiscardReason reason, long connection_id, bool video = false)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xB2CBC1C0);
				writer.Write(video ? 0x1 : 0);
				writer.WriteTLObject(peer);
				writer.Write(duration);
				writer.Write((uint)reason);
				writer.Write(connection_id);
				return "Phone_DiscardCall";
			});

		/// <summary>Rate a call		<para>See <a href="https://corefork.telegram.org/method/phone.setCallRating"/></para></summary>
		/// <param name="user_initiative">Whether the user decided on their own initiative to rate the call</param>
		/// <param name="peer">The call to rate</param>
		/// <param name="rating">Rating in <c>1-5</c> stars</param>
		/// <param name="comment">An additional comment</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/phone.setCallRating#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Phone_SetCallRating(this Client client, InputPhoneCall peer, int rating, string comment, bool user_initiative = false)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x59EAD627);
				writer.Write(user_initiative ? 0x1 : 0);
				writer.WriteTLObject(peer);
				writer.Write(rating);
				writer.WriteTLString(comment);
				return "Phone_SetCallRating";
			});

		/// <summary>Send phone call debug data to server		<para>See <a href="https://corefork.telegram.org/method/phone.saveCallDebug"/></para></summary>
		/// <param name="peer">Phone call</param>
		/// <param name="debug">Debug statistics obtained from libtgvoip</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/phone.saveCallDebug#possible-errors">details</a>)</exception>
		public static Task<bool> Phone_SaveCallDebug(this Client client, InputPhoneCall peer, DataJSON debug)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x277ADD7E);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(debug);
				return "Phone_SaveCallDebug";
			});

		/// <summary>Send VoIP signaling data		<para>See <a href="https://corefork.telegram.org/method/phone.sendSignalingData"/></para></summary>
		/// <param name="peer">Phone call</param>
		/// <param name="data">Signaling payload</param>
		public static Task<bool> Phone_SendSignalingData(this Client client, InputPhoneCall peer, byte[] data)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xFF7A9383);
				writer.WriteTLObject(peer);
				writer.WriteTLBytes(data);
				return "Phone_SendSignalingData";
			});

		/// <summary>Create a group call or livestream		<para>See <a href="https://corefork.telegram.org/method/phone.createGroupCall"/></para></summary>
		/// <param name="peer">Associate the group call or livestream to the provided <a href="https://corefork.telegram.org/api/channel">group/supergroup/channel</a></param>
		/// <param name="random_id">Unique client message ID required to prevent creation of duplicate group calls</param>
		/// <param name="title">Call title</param>
		/// <param name="schedule_date">For scheduled group call or livestreams, the absolute date when the group call will start</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/phone.createGroupCall#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Phone_CreateGroupCall(this Client client, InputPeer peer, int random_id, string title = null, DateTime? schedule_date = null)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x48CDC6D8);
				writer.Write((title != null ? 0x1 : 0) | (schedule_date != null ? 0x2 : 0));
				writer.WriteTLObject(peer);
				writer.Write(random_id);
				if (title != null)
					writer.WriteTLString(title);
				if (schedule_date != null)
					writer.WriteTLStamp(schedule_date.Value);
				return "Phone_CreateGroupCall";
			});

		/// <summary>Join a group call		<para>See <a href="https://corefork.telegram.org/method/phone.joinGroupCall"/></para></summary>
		/// <param name="muted">If set, the user will be muted by default upon joining.</param>
		/// <param name="video_stopped">If set, the user's video will be disabled by default upon joining.</param>
		/// <param name="call">The group call</param>
		/// <param name="join_as">Join the group call, presenting yourself as the specified user/channel</param>
		/// <param name="invite_hash">The invitation hash from the invite link: <c>https://t.me/username?voicechat=hash</c></param>
		/// <param name="params_">WebRTC parameters</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/phone.joinGroupCall#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Phone_JoinGroupCall(this Client client, InputGroupCall call, InputPeer join_as, DataJSON params_, bool muted = false, bool video_stopped = false, string invite_hash = null)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xB132FF7B);
				writer.Write((muted ? 0x1 : 0) | (video_stopped ? 0x4 : 0) | (invite_hash != null ? 0x2 : 0));
				writer.WriteTLObject(call);
				writer.WriteTLObject(join_as);
				if (invite_hash != null)
					writer.WriteTLString(invite_hash);
				writer.WriteTLObject(params_);
				return "Phone_JoinGroupCall";
			});

		/// <summary>Leave a group call		<para>See <a href="https://corefork.telegram.org/method/phone.leaveGroupCall"/></para></summary>
		/// <param name="call">The group call</param>
		/// <param name="source">Your source ID</param>
		public static Task<UpdatesBase> Phone_LeaveGroupCall(this Client client, InputGroupCall call, int source)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x500377F9);
				writer.WriteTLObject(call);
				writer.Write(source);
				return "Phone_LeaveGroupCall";
			});

		/// <summary>Invite a set of users to a group call.		<para>See <a href="https://corefork.telegram.org/method/phone.inviteToGroupCall"/></para></summary>
		/// <param name="call">The group call</param>
		/// <param name="users">The users to invite.</param>
		/// <exception cref="RpcException">Possible errors: 403 (<a href="https://corefork.telegram.org/method/phone.inviteToGroupCall#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Phone_InviteToGroupCall(this Client client, InputGroupCall call, InputUserBase[] users)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x7B393160);
				writer.WriteTLObject(call);
				writer.WriteTLVector(users);
				return "Phone_InviteToGroupCall";
			});

		/// <summary>Terminate a group call		<para>See <a href="https://corefork.telegram.org/method/phone.discardGroupCall"/></para></summary>
		/// <param name="call">The group call to terminate</param>
		public static Task<UpdatesBase> Phone_DiscardGroupCall(this Client client, InputGroupCall call)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x7A777135);
				writer.WriteTLObject(call);
				return "Phone_DiscardGroupCall";
			});

		/// <summary>Change group call settings		<para>See <a href="https://corefork.telegram.org/method/phone.toggleGroupCallSettings"/></para></summary>
		/// <param name="reset_invite_hash">Invalidate existing invite links</param>
		/// <param name="call">Group call</param>
		/// <param name="join_muted">Whether all users will bthat join this group calle muted by default upon joining the group call</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/phone.toggleGroupCallSettings#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Phone_ToggleGroupCallSettings(this Client client, InputGroupCall call, bool reset_invite_hash = false, bool? join_muted = default)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x74BBB43D);
				writer.Write((reset_invite_hash ? 0x2 : 0) | (join_muted != default ? 0x1 : 0));
				writer.WriteTLObject(call);
				if (join_muted != default)
					writer.Write(join_muted.Value ? 0x997275B5 : 0xBC799737);
				return "Phone_ToggleGroupCallSettings";
			});

		/// <summary>Get info about a group call		<para>See <a href="https://corefork.telegram.org/method/phone.getGroupCall"/></para></summary>
		/// <param name="call">The group call</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Phone_GroupCall> Phone_GetGroupCall(this Client client, InputGroupCall call, int limit)
			=> client.CallAsync<Phone_GroupCall>(writer =>
			{
				writer.Write(0x041845DB);
				writer.WriteTLObject(call);
				writer.Write(limit);
				return "Phone_GetGroupCall";
			});

		/// <summary>Get group call participants		<para>See <a href="https://corefork.telegram.org/method/phone.getGroupParticipants"/></para></summary>
		/// <param name="call">Group call</param>
		/// <param name="ids">If specified, will fetch group participant info about the specified peers</param>
		/// <param name="sources">If specified, will fetch group participant info about the specified WebRTC source IDs</param>
		/// <param name="offset">Offset for results, taken from the <c>next_offset</c> field of <see cref="Phone_GroupParticipants"/>, initially an empty string. <br/>Note: if no more results are available, the method call will return an empty <c>next_offset</c>; thus, avoid providing the <c>next_offset</c> returned in <see cref="Phone_GroupParticipants"/> if it is empty, to avoid an infinite loop.</param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		public static Task<Phone_GroupParticipants> Phone_GetGroupParticipants(this Client client, InputGroupCall call, InputPeer[] ids, int[] sources, string offset, int limit)
			=> client.CallAsync<Phone_GroupParticipants>(writer =>
			{
				writer.Write(0xC558D8AB);
				writer.WriteTLObject(call);
				writer.WriteTLVector(ids);
				writer.WriteTLVector(sources);
				writer.WriteTLString(offset);
				writer.Write(limit);
				return "Phone_GetGroupParticipants";
			});

		/// <summary>Check whether the group call Server Forwarding Unit is currently receiving the streams with the specified WebRTC source IDs		<para>See <a href="https://corefork.telegram.org/method/phone.checkGroupCall"/></para></summary>
		/// <param name="call">Group call</param>
		/// <param name="sources">Source IDs</param>
		public static Task<int[]> Phone_CheckGroupCall(this Client client, InputGroupCall call, int[] sources)
			=> client.CallAsync<int[]>(writer =>
			{
				writer.Write(0xB59CF977);
				writer.WriteTLObject(call);
				writer.WriteTLVector(sources);
				return "Phone_CheckGroupCall";
			});

		/// <summary>Start or stop recording a group call: the recorded audio and video streams will be automatically sent to <c>Saved messages</c> (the chat with ourselves).		<para>See <a href="https://corefork.telegram.org/method/phone.toggleGroupCallRecord"/></para></summary>
		/// <param name="start">Whether to start or stop recording</param>
		/// <param name="video">Whether to also record video streams</param>
		/// <param name="call">The group call or livestream</param>
		/// <param name="title">Recording title</param>
		/// <param name="video_portrait">If video stream recording is enabled, whether to record in portrait or landscape mode</param>
		public static Task<UpdatesBase> Phone_ToggleGroupCallRecord(this Client client, InputGroupCall call, bool start = false, bool video = false, string title = null, bool? video_portrait = default)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xF128C708);
				writer.Write((start ? 0x1 : 0) | (video ? 0x4 : 0) | (title != null ? 0x2 : 0) | (video_portrait != default ? 0x4 : 0));
				writer.WriteTLObject(call);
				if (title != null)
					writer.WriteTLString(title);
				if (video_portrait != default)
					writer.Write(video_portrait.Value ? 0x997275B5 : 0xBC799737);
				return "Phone_ToggleGroupCallRecord";
			});

		/// <summary>Edit information about a given group call participant		<para>See <a href="https://corefork.telegram.org/method/phone.editGroupCallParticipant"/></para></summary>
		/// <param name="call">The group call</param>
		/// <param name="participant">The group call participant (can also be the user itself)</param>
		/// <param name="muted">Whether to mute or unmute the specified participant</param>
		/// <param name="volume">New volume</param>
		/// <param name="raise_hand">Raise or lower hand</param>
		/// <param name="video_stopped">Start or stop the video stream</param>
		/// <param name="video_paused">Pause or resume the video stream</param>
		/// <param name="presentation_paused">Pause or resume the screen sharing stream</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/phone.editGroupCallParticipant#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Phone_EditGroupCallParticipant(this Client client, InputGroupCall call, InputPeer participant, bool? muted = default, int? volume = null, bool? raise_hand = default, bool? video_stopped = default, bool? video_paused = default, bool? presentation_paused = default)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xA5273ABF);
				writer.Write((muted != default ? 0x1 : 0) | (volume != null ? 0x2 : 0) | (raise_hand != default ? 0x4 : 0) | (video_stopped != default ? 0x8 : 0) | (video_paused != default ? 0x10 : 0) | (presentation_paused != default ? 0x20 : 0));
				writer.WriteTLObject(call);
				writer.WriteTLObject(participant);
				if (muted != default)
					writer.Write(muted.Value ? 0x997275B5 : 0xBC799737);
				if (volume != null)
					writer.Write(volume.Value);
				if (raise_hand != default)
					writer.Write(raise_hand.Value ? 0x997275B5 : 0xBC799737);
				if (video_stopped != default)
					writer.Write(video_stopped.Value ? 0x997275B5 : 0xBC799737);
				if (video_paused != default)
					writer.Write(video_paused.Value ? 0x997275B5 : 0xBC799737);
				if (presentation_paused != default)
					writer.Write(presentation_paused.Value ? 0x997275B5 : 0xBC799737);
				return "Phone_EditGroupCallParticipant";
			});

		/// <summary>Edit the title of a group call or livestream		<para>See <a href="https://corefork.telegram.org/method/phone.editGroupCallTitle"/></para></summary>
		/// <param name="call">Group call</param>
		/// <param name="title">New title</param>
		public static Task<UpdatesBase> Phone_EditGroupCallTitle(this Client client, InputGroupCall call, string title)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x1CA6AC0A);
				writer.WriteTLObject(call);
				writer.WriteTLString(title);
				return "Phone_EditGroupCallTitle";
			});

		/// <summary>Get a list of peers that can be used to join a group call, presenting yourself as a specific user/channel.		<para>See <a href="https://corefork.telegram.org/method/phone.getGroupCallJoinAs"/></para></summary>
		/// <param name="peer">The dialog whose group call or livestream we're trying to join</param>
		public static Task<Phone_JoinAsPeers> Phone_GetGroupCallJoinAs(this Client client, InputPeer peer)
			=> client.CallAsync<Phone_JoinAsPeers>(writer =>
			{
				writer.Write(0xEF7C213A);
				writer.WriteTLObject(peer);
				return "Phone_GetGroupCallJoinAs";
			});

		/// <summary>Get an invite link for a group call or livestream		<para>See <a href="https://corefork.telegram.org/method/phone.exportGroupCallInvite"/></para></summary>
		/// <param name="can_self_unmute">For livestreams, if set, users that join using this link will be able to speak without explicitly requesting permission by (for example by raising their hand).</param>
		/// <param name="call">The group call</param>
		public static Task<Phone_ExportedGroupCallInvite> Phone_ExportGroupCallInvite(this Client client, InputGroupCall call, bool can_self_unmute = false)
			=> client.CallAsync<Phone_ExportedGroupCallInvite>(writer =>
			{
				writer.Write(0xE6AA647F);
				writer.Write(can_self_unmute ? 0x1 : 0);
				writer.WriteTLObject(call);
				return "Phone_ExportGroupCallInvite";
			});

		/// <summary>Subscribe or unsubscribe to a scheduled group call		<para>See <a href="https://corefork.telegram.org/method/phone.toggleGroupCallStartSubscription"/></para></summary>
		/// <param name="call">Scheduled group call</param>
		/// <param name="subscribed">Enable or disable subscription</param>
		public static Task<UpdatesBase> Phone_ToggleGroupCallStartSubscription(this Client client, InputGroupCall call, bool subscribed)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x219C34E6);
				writer.WriteTLObject(call);
				writer.Write(subscribed ? 0x997275B5 : 0xBC799737);
				return "Phone_ToggleGroupCallStartSubscription";
			});

		/// <summary>Start a scheduled group call.		<para>See <a href="https://corefork.telegram.org/method/phone.startScheduledGroupCall"/></para></summary>
		/// <param name="call">The scheduled group call</param>
		public static Task<UpdatesBase> Phone_StartScheduledGroupCall(this Client client, InputGroupCall call)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x5680E342);
				writer.WriteTLObject(call);
				return "Phone_StartScheduledGroupCall";
			});

		/// <summary>Set the default peer that will be used to join a group call in a specific dialog.		<para>See <a href="https://corefork.telegram.org/method/phone.saveDefaultGroupCallJoinAs"/></para></summary>
		/// <param name="peer">The dialog</param>
		/// <param name="join_as">The default peer that will be used to join group calls in this dialog, presenting yourself as a specific user/channel.</param>
		public static Task<bool> Phone_SaveDefaultGroupCallJoinAs(this Client client, InputPeer peer, InputPeer join_as)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x575E1F8C);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(join_as);
				return "Phone_SaveDefaultGroupCallJoinAs";
			});

		/// <summary>Start screen sharing in a call		<para>See <a href="https://corefork.telegram.org/method/phone.joinGroupCallPresentation"/></para></summary>
		/// <param name="call">The group call</param>
		/// <param name="params_">WebRTC parameters</param>
		/// <exception cref="RpcException">Possible errors: 403 (<a href="https://corefork.telegram.org/method/phone.joinGroupCallPresentation#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Phone_JoinGroupCallPresentation(this Client client, InputGroupCall call, DataJSON params_)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xCBEA6BC4);
				writer.WriteTLObject(call);
				writer.WriteTLObject(params_);
				return "Phone_JoinGroupCallPresentation";
			});

		/// <summary>Stop screen sharing in a group call		<para>See <a href="https://corefork.telegram.org/method/phone.leaveGroupCallPresentation"/></para></summary>
		/// <param name="call">The group call</param>
		public static Task<UpdatesBase> Phone_LeaveGroupCallPresentation(this Client client, InputGroupCall call)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x1C50D144);
				writer.WriteTLObject(call);
				return "Phone_LeaveGroupCallPresentation";
			});

		/// <summary>Get localization pack strings		<para>See <a href="https://corefork.telegram.org/method/langpack.getLangPack"/></para></summary>
		/// <param name="lang_pack">Language pack name</param>
		/// <param name="lang_code">Language code</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/langpack.getLangPack#possible-errors">details</a>)</exception>
		public static Task<LangPackDifference> Langpack_GetLangPack(this Client client, string lang_pack, string lang_code)
			=> client.CallAsync<LangPackDifference>(writer =>
			{
				writer.Write(0xF2F2330A);
				writer.WriteTLString(lang_pack);
				writer.WriteTLString(lang_code);
				return "Langpack_GetLangPack";
			});

		/// <summary>Get strings from a language pack		<para>See <a href="https://corefork.telegram.org/method/langpack.getStrings"/></para></summary>
		/// <param name="lang_pack">Language pack name</param>
		/// <param name="lang_code">Language code</param>
		/// <param name="keys">Strings to get</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/langpack.getStrings#possible-errors">details</a>)</exception>
		public static Task<LangPackStringBase[]> Langpack_GetStrings(this Client client, string lang_pack, string lang_code, string[] keys)
			=> client.CallAsync<LangPackStringBase[]>(writer =>
			{
				writer.Write(0xEFEA3803);
				writer.WriteTLString(lang_pack);
				writer.WriteTLString(lang_code);
				writer.WriteTLVector(keys);
				return "Langpack_GetStrings";
			});

		/// <summary>Get new strings in languagepack		<para>See <a href="https://corefork.telegram.org/method/langpack.getDifference"/></para></summary>
		/// <param name="lang_pack">Language pack</param>
		/// <param name="lang_code">Language code</param>
		/// <param name="from_version">Previous localization pack version</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/langpack.getDifference#possible-errors">details</a>)</exception>
		public static Task<LangPackDifference> Langpack_GetDifference(this Client client, string lang_pack, string lang_code, int from_version)
			=> client.CallAsync<LangPackDifference>(writer =>
			{
				writer.Write(0xCD984AA5);
				writer.WriteTLString(lang_pack);
				writer.WriteTLString(lang_code);
				writer.Write(from_version);
				return "Langpack_GetDifference";
			});

		/// <summary>Get information about all languages in a localization pack		<para>See <a href="https://corefork.telegram.org/method/langpack.getLanguages"/></para></summary>
		/// <param name="lang_pack">Language pack</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/langpack.getLanguages#possible-errors">details</a>)</exception>
		public static Task<LangPackLanguage[]> Langpack_GetLanguages(this Client client, string lang_pack)
			=> client.CallAsync<LangPackLanguage[]>(writer =>
			{
				writer.Write(0x42C6978F);
				writer.WriteTLString(lang_pack);
				return "Langpack_GetLanguages";
			});

		/// <summary>Get information about a language in a localization pack		<para>See <a href="https://corefork.telegram.org/method/langpack.getLanguage"/></para></summary>
		/// <param name="lang_pack">Language pack name</param>
		/// <param name="lang_code">Language code</param>
		public static Task<LangPackLanguage> Langpack_GetLanguage(this Client client, string lang_pack, string lang_code)
			=> client.CallAsync<LangPackLanguage>(writer =>
			{
				writer.Write(0x6A596502);
				writer.WriteTLString(lang_pack);
				writer.WriteTLString(lang_code);
				return "Langpack_GetLanguage";
			});

		/// <summary>Edit peers in <a href="https://corefork.telegram.org/api/folders#peer-folders">peer folder</a>		<para>See <a href="https://corefork.telegram.org/method/folders.editPeerFolders"/></para></summary>
		/// <param name="folder_peers">New peer list</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/folders.editPeerFolders#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Folders_EditPeerFolders(this Client client, InputFolderPeer[] folder_peers)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x6847D0AB);
				writer.WriteTLVector(folder_peers);
				return "Folders_EditPeerFolders";
			});

		/// <summary>Delete a <a href="https://corefork.telegram.org/api/folders#peer-folders">peer folder</a>		<para>See <a href="https://corefork.telegram.org/method/folders.deleteFolder"/></para></summary>
		/// <param name="folder_id"><a href="https://corefork.telegram.org/api/folders#peer-folders">Peer folder ID, for more info click here</a></param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/folders.deleteFolder#possible-errors">details</a>)</exception>
		public static Task<UpdatesBase> Folders_DeleteFolder(this Client client, int folder_id)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x1C295881);
				writer.Write(folder_id);
				return "Folders_DeleteFolder";
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/stats">channel statistics</a>		<para>See <a href="https://corefork.telegram.org/method/stats.getBroadcastStats"/></para></summary>
		/// <param name="dark">Whether to enable dark theme for graph colors</param>
		/// <param name="channel">The channel</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/stats.getBroadcastStats#possible-errors">details</a>)</exception>
		public static Task<Stats_BroadcastStats> Stats_GetBroadcastStats(this Client client, InputChannelBase channel, bool dark = false)
			=> client.CallAsync<Stats_BroadcastStats>(writer =>
			{
				writer.Write(0xAB42441A);
				writer.Write(dark ? 0x1 : 0);
				writer.WriteTLObject(channel);
				return "Stats_GetBroadcastStats";
			});

		/// <summary>Load <a href="https://corefork.telegram.org/api/stats">channel statistics graph</a> asynchronously		<para>See <a href="https://corefork.telegram.org/method/stats.loadAsyncGraph"/></para></summary>
		/// <param name="token">Graph token from <see cref="StatsGraphAsync"/> constructor</param>
		/// <param name="x">Zoom value, if required</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/stats.loadAsyncGraph#possible-errors">details</a>)</exception>
		public static Task<StatsGraphBase> Stats_LoadAsyncGraph(this Client client, string token, long? x = null)
			=> client.CallAsync<StatsGraphBase>(writer =>
			{
				writer.Write(0x621D5FA0);
				writer.Write(x != null ? 0x1 : 0);
				writer.WriteTLString(token);
				if (x != null)
					writer.Write(x.Value);
				return "Stats_LoadAsyncGraph";
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/stats">supergroup statistics</a>		<para>See <a href="https://corefork.telegram.org/method/stats.getMegagroupStats"/></para></summary>
		/// <param name="dark">Whether to enable dark theme for graph colors</param>
		/// <param name="channel"><a href="https://corefork.telegram.org/api/channel">Supergroup ID</a></param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/stats.getMegagroupStats#possible-errors">details</a>)</exception>
		public static Task<Stats_MegagroupStats> Stats_GetMegagroupStats(this Client client, InputChannelBase channel, bool dark = false)
			=> client.CallAsync<Stats_MegagroupStats>(writer =>
			{
				writer.Write(0xDCDF8607);
				writer.Write(dark ? 0x1 : 0);
				writer.WriteTLObject(channel);
				return "Stats_GetMegagroupStats";
			});

		/// <summary>Obtains a list of messages, indicating to which other public channels was a channel message forwarded.<br/>Will return a list of <see cref="Message"/> with <c>peer_id</c> equal to the public channel to which this message was forwarded.		<para>See <a href="https://corefork.telegram.org/method/stats.getMessagePublicForwards"/></para></summary>
		/// <param name="channel">Source channel</param>
		/// <param name="msg_id">Source message ID</param>
		/// <param name="offset_rate">Initially 0, then set to the <c>next_rate</c> parameter of <see cref="Messages_MessagesSlice"/></param>
		/// <param name="offset_peer"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="offset_id"><a href="https://corefork.telegram.org/api/offsets">Offsets for pagination, for more info click here</a></param>
		/// <param name="limit">Maximum number of results to return, <a href="https://corefork.telegram.org/api/offsets">see pagination</a></param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/stats.getMessagePublicForwards#possible-errors">details</a>)</exception>
		public static Task<Messages_MessagesBase> Stats_GetMessagePublicForwards(this Client client, InputChannelBase channel, int msg_id, int offset_rate, InputPeer offset_peer, int offset_id, int limit)
			=> client.CallAsync<Messages_MessagesBase>(writer =>
			{
				writer.Write(0x5630281B);
				writer.WriteTLObject(channel);
				writer.Write(msg_id);
				writer.Write(offset_rate);
				writer.WriteTLObject(offset_peer);
				writer.Write(offset_id);
				writer.Write(limit);
				return "Stats_GetMessagePublicForwards";
			});

		/// <summary>Get <a href="https://corefork.telegram.org/api/stats">message statistics</a>		<para>See <a href="https://corefork.telegram.org/method/stats.getMessageStats"/></para></summary>
		/// <param name="dark">Whether to enable dark theme for graph colors</param>
		/// <param name="channel">Channel ID</param>
		/// <param name="msg_id">Message ID</param>
		/// <exception cref="RpcException">Possible errors: 400 (<a href="https://corefork.telegram.org/method/stats.getMessageStats#possible-errors">details</a>)</exception>
		public static Task<Stats_MessageStats> Stats_GetMessageStats(this Client client, InputChannelBase channel, int msg_id, bool dark = false)
			=> client.CallAsync<Stats_MessageStats>(writer =>
			{
				writer.Write(0xB6E0A3F5);
				writer.Write(dark ? 0x1 : 0);
				writer.WriteTLObject(channel);
				writer.Write(msg_id);
				return "Stats_GetMessageStats";
			});
	}
}
