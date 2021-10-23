// This file is generated automatically using the Generator class
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TL
{
	using BinaryWriter = System.IO.BinaryWriter;
	using Client = WTelegram.Client;

	///<summary>See <a href="https://corefork.telegram.org/type/Bool"/></summary>
	public enum Bool : uint
	{
		///<summary>See <a href="https://corefork.telegram.org/constructor/boolFalse"/></summary>
		False = 0xBC799737,
		///<summary>See <a href="https://corefork.telegram.org/constructor/boolTrue"/></summary>
		True = 0x997275B5,
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/true"/></summary>
	[TLDef(0x3FEDD339)]
	public partial class True : ITLObject { }

	///<summary>See <a href="https://corefork.telegram.org/constructor/error"/></summary>
	[TLDef(0xC4B9F9BB)]
	public partial class Error : ITLObject
	{
		public int code;
		public string text;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/null"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/null">null</a></remarks>
	[TLDef(0x56730BCC)]
	public partial class Null : ITLObject { }

	///<summary>See <a href="https://corefork.telegram.org/type/InputPeer"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputPeerEmpty">inputPeerEmpty</a></remarks>
	public abstract partial class InputPeer : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputPeerSelf"/></summary>
	[TLDef(0x7DA07EC9)]
	public partial class InputPeerSelf : InputPeer { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputPeerChat"/></summary>
	[TLDef(0x35A95CB9)]
	public partial class InputPeerChat : InputPeer { public long chat_id; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputPeerUser"/></summary>
	[TLDef(0xDDE8A54C)]
	public partial class InputPeerUser : InputPeer
	{
		public long user_id;
		public long access_hash;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputPeerChannel"/></summary>
	[TLDef(0x27BCBBFC)]
	public partial class InputPeerChannel : InputPeer
	{
		public long channel_id;
		public long access_hash;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputPeerUserFromMessage"/></summary>
	[TLDef(0xA87B0A1C)]
	public partial class InputPeerUserFromMessage : InputPeer
	{
		public InputPeer peer;
		public int msg_id;
		public long user_id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputPeerChannelFromMessage"/></summary>
	[TLDef(0xBD2A0840)]
	public partial class InputPeerChannelFromMessage : InputPeer
	{
		public InputPeer peer;
		public int msg_id;
		public long channel_id;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/InputUser"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputUserEmpty">inputUserEmpty</a></remarks>
	public abstract partial class InputUserBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputUserSelf"/></summary>
	[TLDef(0xF7C1B13F)]
	public partial class InputUserSelf : InputUserBase { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputUser"/></summary>
	[TLDef(0xF21158C6)]
	public partial class InputUser : InputUserBase
	{
		public long user_id;
		public long access_hash;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputUserFromMessage"/></summary>
	[TLDef(0x1DA448E2)]
	public partial class InputUserFromMessage : InputUserBase
	{
		public InputPeer peer;
		public int msg_id;
		public long user_id;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/InputContact"/></summary>
	public abstract partial class InputContact : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputPhoneContact"/></summary>
	[TLDef(0xF392B7F4)]
	public partial class InputPhoneContact : InputContact
	{
		public long client_id;
		public string phone;
		public string first_name;
		public string last_name;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/InputFile"/></summary>
	public abstract partial class InputFileBase : ITLObject
	{
		public abstract long ID { get; }
		public abstract int Parts { get; }
		public abstract string Name { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputFile"/></summary>
	[TLDef(0xF52FF27F)]
	public partial class InputFile : InputFileBase
	{
		public long id;
		public int parts;
		public string name;
		public byte[] md5_checksum;

		public override long ID => id;
		public override int Parts => parts;
		public override string Name => name;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputFileBig"/></summary>
	[TLDef(0xFA4F0BB5)]
	public partial class InputFileBig : InputFileBase
	{
		public long id;
		public int parts;
		public string name;

		public override long ID => id;
		public override int Parts => parts;
		public override string Name => name;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/InputMedia"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputMediaEmpty">inputMediaEmpty</a></remarks>
	public abstract partial class InputMedia : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMediaUploadedPhoto"/></summary>
	[TLDef(0x1E287D04)]
	public partial class InputMediaUploadedPhoto : InputMedia
	{
		[Flags] public enum Flags { has_stickers = 0x1, has_ttl_seconds = 0x2 }
		public Flags flags;
		public InputFileBase file;
		[IfFlag(0)] public InputDocument[] stickers;
		[IfFlag(1)] public int ttl_seconds;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMediaPhoto"/></summary>
	[TLDef(0xB3BA0635)]
	public partial class InputMediaPhoto : InputMedia
	{
		[Flags] public enum Flags { has_ttl_seconds = 0x1 }
		public Flags flags;
		public InputPhoto id;
		[IfFlag(0)] public int ttl_seconds;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMediaGeoPoint"/></summary>
	[TLDef(0xF9C44144)]
	public partial class InputMediaGeoPoint : InputMedia { public InputGeoPoint geo_point; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMediaContact"/></summary>
	[TLDef(0xF8AB7DFB)]
	public partial class InputMediaContact : InputMedia
	{
		public string phone_number;
		public string first_name;
		public string last_name;
		public string vcard;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMediaUploadedDocument"/></summary>
	[TLDef(0x5B38C6C1)]
	public partial class InputMediaUploadedDocument : InputMedia
	{
		[Flags] public enum Flags { has_stickers = 0x1, has_ttl_seconds = 0x2, has_thumb = 0x4, nosound_video = 0x8, force_file = 0x10 }
		public Flags flags;
		public InputFileBase file;
		[IfFlag(2)] public InputFileBase thumb;
		public string mime_type;
		public DocumentAttribute[] attributes;
		[IfFlag(0)] public InputDocument[] stickers;
		[IfFlag(1)] public int ttl_seconds;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMediaDocument"/></summary>
	[TLDef(0x33473058)]
	public partial class InputMediaDocument : InputMedia
	{
		[Flags] public enum Flags { has_ttl_seconds = 0x1, has_query = 0x2 }
		public Flags flags;
		public InputDocument id;
		[IfFlag(0)] public int ttl_seconds;
		[IfFlag(1)] public string query;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMediaVenue"/></summary>
	[TLDef(0xC13D1C11)]
	public partial class InputMediaVenue : InputMedia
	{
		public InputGeoPoint geo_point;
		public string title;
		public string address;
		public string provider;
		public string venue_id;
		public string venue_type;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMediaPhotoExternal"/></summary>
	[TLDef(0xE5BBFE1A)]
	public partial class InputMediaPhotoExternal : InputMedia
	{
		[Flags] public enum Flags { has_ttl_seconds = 0x1 }
		public Flags flags;
		public string url;
		[IfFlag(0)] public int ttl_seconds;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMediaDocumentExternal"/></summary>
	[TLDef(0xFB52DC99)]
	public partial class InputMediaDocumentExternal : InputMedia
	{
		[Flags] public enum Flags { has_ttl_seconds = 0x1 }
		public Flags flags;
		public string url;
		[IfFlag(0)] public int ttl_seconds;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMediaGame"/></summary>
	[TLDef(0xD33F43F3)]
	public partial class InputMediaGame : InputMedia { public InputGame id; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMediaInvoice"/></summary>
	[TLDef(0xD9799874)]
	public partial class InputMediaInvoice : InputMedia
	{
		[Flags] public enum Flags { has_photo = 0x1, has_start_param = 0x2 }
		public Flags flags;
		public string title;
		public string description;
		[IfFlag(0)] public InputWebDocument photo;
		public Invoice invoice;
		public byte[] payload;
		public string provider;
		public DataJSON provider_data;
		[IfFlag(1)] public string start_param;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMediaGeoLive"/></summary>
	[TLDef(0x971FA843)]
	public partial class InputMediaGeoLive : InputMedia
	{
		[Flags] public enum Flags { stopped = 0x1, has_period = 0x2, has_heading = 0x4, has_proximity_notification_radius = 0x8 }
		public Flags flags;
		public InputGeoPoint geo_point;
		[IfFlag(2)] public int heading;
		[IfFlag(1)] public int period;
		[IfFlag(3)] public int proximity_notification_radius;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMediaPoll"/></summary>
	[TLDef(0x0F94E5F1)]
	public partial class InputMediaPoll : InputMedia
	{
		[Flags] public enum Flags { has_correct_answers = 0x1, has_solution = 0x2 }
		public Flags flags;
		public Poll poll;
		[IfFlag(0)] public byte[][] correct_answers;
		[IfFlag(1)] public string solution;
		[IfFlag(1)] public MessageEntity[] solution_entities;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMediaDice"/></summary>
	[TLDef(0xE66FBF7B)]
	public partial class InputMediaDice : InputMedia { public string emoticon; }

	///<summary>See <a href="https://corefork.telegram.org/type/InputChatPhoto"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputChatPhotoEmpty">inputChatPhotoEmpty</a></remarks>
	public abstract partial class InputChatPhotoBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputChatUploadedPhoto"/></summary>
	[TLDef(0xC642724E)]
	public partial class InputChatUploadedPhoto : InputChatPhotoBase
	{
		[Flags] public enum Flags { has_file = 0x1, has_video = 0x2, has_video_start_ts = 0x4 }
		public Flags flags;
		[IfFlag(0)] public InputFileBase file;
		[IfFlag(1)] public InputFileBase video;
		[IfFlag(2)] public double video_start_ts;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputChatPhoto"/></summary>
	[TLDef(0x8953AD37)]
	public partial class InputChatPhoto : InputChatPhotoBase { public InputPhoto id; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/inputGeoPoint"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputGeoPointEmpty">inputGeoPointEmpty</a></remarks>
	[TLDef(0x48222FAF)]
	public partial class InputGeoPoint : ITLObject
	{
		[Flags] public enum Flags { has_accuracy_radius = 0x1 }
		public Flags flags;
		public double lat;
		public double long_;
		[IfFlag(0)] public int accuracy_radius;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/inputPhoto"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputPhotoEmpty">inputPhotoEmpty</a></remarks>
	[TLDef(0x3BB3B94A)]
	public partial class InputPhoto : ITLObject
	{
		public long id;
		public long access_hash;
		public byte[] file_reference;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/InputFileLocation"/></summary>
	public abstract partial class InputFileLocationBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputFileLocation"/></summary>
	[TLDef(0xDFDAABE1)]
	public partial class InputFileLocation : InputFileLocationBase
	{
		public long volume_id;
		public int local_id;
		public long secret;
		public byte[] file_reference;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputEncryptedFileLocation"/></summary>
	[TLDef(0xF5235D55)]
	public partial class InputEncryptedFileLocation : InputFileLocationBase
	{
		public long id;
		public long access_hash;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputDocumentFileLocation"/></summary>
	[TLDef(0xBAD07584)]
	public partial class InputDocumentFileLocation : InputFileLocationBase
	{
		public long id;
		public long access_hash;
		public byte[] file_reference;
		public string thumb_size;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputSecureFileLocation"/></summary>
	[TLDef(0xCBC7EE28)]
	public partial class InputSecureFileLocation : InputFileLocationBase
	{
		public long id;
		public long access_hash;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputTakeoutFileLocation"/></summary>
	[TLDef(0x29BE5899)]
	public partial class InputTakeoutFileLocation : InputFileLocationBase { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputPhotoFileLocation"/></summary>
	[TLDef(0x40181FFE)]
	public partial class InputPhotoFileLocation : InputFileLocationBase
	{
		public long id;
		public long access_hash;
		public byte[] file_reference;
		public string thumb_size;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputPhotoLegacyFileLocation"/></summary>
	[TLDef(0xD83466F3)]
	public partial class InputPhotoLegacyFileLocation : InputFileLocationBase
	{
		public long id;
		public long access_hash;
		public byte[] file_reference;
		public long volume_id;
		public int local_id;
		public long secret;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputPeerPhotoFileLocation"/></summary>
	[TLDef(0x37257E99)]
	public partial class InputPeerPhotoFileLocation : InputFileLocationBase
	{
		[Flags] public enum Flags { big = 0x1 }
		public Flags flags;
		public InputPeer peer;
		public long photo_id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputStickerSetThumb"/></summary>
	[TLDef(0x9D84F3DB)]
	public partial class InputStickerSetThumb : InputFileLocationBase
	{
		public InputStickerSet stickerset;
		public int thumb_version;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputGroupCallStream"/></summary>
	[TLDef(0x0598A92A)]
	public partial class InputGroupCallStream : InputFileLocationBase
	{
		[Flags] public enum Flags { has_video_channel = 0x1 }
		public Flags flags;
		public InputGroupCall call;
		public long time_ms;
		public int scale;
		[IfFlag(0)] public int video_channel;
		[IfFlag(0)] public int video_quality;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/Peer"/></summary>
	public abstract partial class Peer : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/peerUser"/></summary>
	[TLDef(0x59511722)]
	public partial class PeerUser : Peer { public long user_id; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/peerChat"/></summary>
	[TLDef(0x36C6019A)]
	public partial class PeerChat : Peer { public long chat_id; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/peerChannel"/></summary>
	[TLDef(0xA2A5371E)]
	public partial class PeerChannel : Peer { public long channel_id; }

	///<summary>See <a href="https://corefork.telegram.org/type/storage.FileType"/></summary>
	public enum Storage_FileType : uint
	{
		///<summary>See <a href="https://corefork.telegram.org/constructor/storage.fileUnknown"/></summary>
		unknown = 0xAA963B05,
		///<summary>See <a href="https://corefork.telegram.org/constructor/storage.filePartial"/></summary>
		partial = 0x40BC6F52,
		///<summary>See <a href="https://corefork.telegram.org/constructor/storage.fileJpeg"/></summary>
		jpeg = 0x007EFE0E,
		///<summary>See <a href="https://corefork.telegram.org/constructor/storage.fileGif"/></summary>
		gif = 0xCAE1AADF,
		///<summary>See <a href="https://corefork.telegram.org/constructor/storage.filePng"/></summary>
		png = 0x0A4F63C0,
		///<summary>See <a href="https://corefork.telegram.org/constructor/storage.filePdf"/></summary>
		pdf = 0xAE1E508D,
		///<summary>See <a href="https://corefork.telegram.org/constructor/storage.fileMp3"/></summary>
		mp3 = 0x528A0677,
		///<summary>See <a href="https://corefork.telegram.org/constructor/storage.fileMov"/></summary>
		mov = 0x4B09EBBC,
		///<summary>See <a href="https://corefork.telegram.org/constructor/storage.fileMp4"/></summary>
		mp4 = 0xB3CEA0E4,
		///<summary>See <a href="https://corefork.telegram.org/constructor/storage.fileWebp"/></summary>
		webp = 0x1081464C,
	}

	///<summary>See <a href="https://corefork.telegram.org/type/User"/></summary>
	public abstract partial class UserBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/userEmpty"/></summary>
	[TLDef(0xD3BC4B7A)]
	public partial class UserEmpty : UserBase { public long id; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/user"/></summary>
	[TLDef(0x3FF6ECB0)]
	public partial class User : UserBase
	{
		[Flags] public enum Flags { has_access_hash = 0x1, has_first_name = 0x2, has_last_name = 0x4, has_username = 0x8, 
			has_phone = 0x10, has_photo = 0x20, has_status = 0x40, self = 0x400, contact = 0x800, mutual_contact = 0x1000, 
			deleted = 0x2000, bot = 0x4000, bot_chat_history = 0x8000, bot_nochats = 0x10000, verified = 0x20000, restricted = 0x40000, 
			has_bot_inline_placeholder = 0x80000, min = 0x100000, bot_inline_geo = 0x200000, has_lang_code = 0x400000, support = 0x800000, 
			scam = 0x1000000, apply_min_photo = 0x2000000, fake = 0x4000000 }
		public Flags flags;
		public long id;
		[IfFlag(0)] public long access_hash;
		[IfFlag(1)] public string first_name;
		[IfFlag(2)] public string last_name;
		[IfFlag(3)] public string username;
		[IfFlag(4)] public string phone;
		[IfFlag(5)] public UserProfilePhoto photo;
		[IfFlag(6)] public UserStatus status;
		[IfFlag(14)] public int bot_info_version;
		[IfFlag(18)] public RestrictionReason[] restriction_reason;
		[IfFlag(19)] public string bot_inline_placeholder;
		[IfFlag(22)] public string lang_code;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/userProfilePhoto"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/userProfilePhotoEmpty">userProfilePhotoEmpty</a></remarks>
	[TLDef(0x82D1F706)]
	public partial class UserProfilePhoto : ITLObject
	{
		[Flags] public enum Flags { has_video = 0x1, has_stripped_thumb = 0x2 }
		public Flags flags;
		public long photo_id;
		[IfFlag(1)] public byte[] stripped_thumb;
		public int dc_id;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/UserStatus"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/userStatusEmpty">userStatusEmpty</a></remarks>
	public abstract partial class UserStatus : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/userStatusOnline"/></summary>
	[TLDef(0xEDB93949)]
	public partial class UserStatusOnline : UserStatus { public DateTime expires; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/userStatusOffline"/></summary>
	[TLDef(0x008C703F)]
	public partial class UserStatusOffline : UserStatus { public int was_online; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/userStatusRecently"/></summary>
	[TLDef(0xE26F42F1)]
	public partial class UserStatusRecently : UserStatus { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/userStatusLastWeek"/></summary>
	[TLDef(0x07BF09FC)]
	public partial class UserStatusLastWeek : UserStatus { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/userStatusLastMonth"/></summary>
	[TLDef(0x77EBC742)]
	public partial class UserStatusLastMonth : UserStatus { }

	///<summary>See <a href="https://corefork.telegram.org/type/Chat"/></summary>
	public abstract partial class ChatBase : ITLObject
	{
		public abstract long ID { get; }
		public abstract string Title { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/chatEmpty"/></summary>
	[TLDef(0x29562865)]
	public partial class ChatEmpty : ChatBase
	{
		public long id;

		public override long ID => id;
		public override string Title => default;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/chat"/></summary>
	[TLDef(0x41CBF256)]
	public partial class Chat : ChatBase
	{
		[Flags] public enum Flags { creator = 0x1, kicked = 0x2, left = 0x4, deactivated = 0x20, has_migrated_to = 0x40, 
			has_admin_rights = 0x4000, has_default_banned_rights = 0x40000, call_active = 0x800000, call_not_empty = 0x1000000 }
		public Flags flags;
		public long id;
		public string title;
		public ChatPhoto photo;
		public int participants_count;
		public DateTime date;
		public int version;
		[IfFlag(6)] public InputChannelBase migrated_to;
		[IfFlag(14)] public ChatAdminRights admin_rights;
		[IfFlag(18)] public ChatBannedRights default_banned_rights;

		public override long ID => id;
		public override string Title => title;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/chatForbidden"/></summary>
	[TLDef(0x6592A1A7)]
	public partial class ChatForbidden : ChatBase
	{
		public long id;
		public string title;

		public override long ID => id;
		public override string Title => title;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/channel"/></summary>
	[TLDef(0x8261AC61)]
	public partial class Channel : ChatBase
	{
		[Flags] public enum Flags { creator = 0x1, left = 0x4, broadcast = 0x20, has_username = 0x40, verified = 0x80, 
			megagroup = 0x100, restricted = 0x200, signatures = 0x800, min = 0x1000, has_access_hash = 0x2000, has_admin_rights = 0x4000, 
			has_banned_rights = 0x8000, has_participants_count = 0x20000, has_default_banned_rights = 0x40000, scam = 0x80000, 
			has_link = 0x100000, has_geo = 0x200000, slowmode_enabled = 0x400000, call_active = 0x800000, call_not_empty = 0x1000000, 
			fake = 0x2000000, gigagroup = 0x4000000 }
		public Flags flags;
		public long id;
		[IfFlag(13)] public long access_hash;
		public string title;
		[IfFlag(6)] public string username;
		public ChatPhoto photo;
		public DateTime date;
		[IfFlag(9)] public RestrictionReason[] restriction_reason;
		[IfFlag(14)] public ChatAdminRights admin_rights;
		[IfFlag(15)] public ChatBannedRights banned_rights;
		[IfFlag(18)] public ChatBannedRights default_banned_rights;
		[IfFlag(17)] public int participants_count;

		public override long ID => id;
		public override string Title => title;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelForbidden"/></summary>
	[TLDef(0x17D493D5)]
	public partial class ChannelForbidden : ChatBase
	{
		[Flags] public enum Flags { broadcast = 0x20, megagroup = 0x100, has_until_date = 0x10000 }
		public Flags flags;
		public long id;
		public long access_hash;
		public string title;
		[IfFlag(16)] public DateTime until_date;

		public override long ID => id;
		public override string Title => title;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/ChatFull"/></summary>
	public abstract partial class ChatFullBase : ITLObject
	{
		public abstract long ID { get; }
		public abstract string About { get; }
		public abstract PeerNotifySettings NotifySettings { get; }
		public abstract int Folder { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/chatFull"/></summary>
	[TLDef(0x4DBDC099)]
	public partial class ChatFull : ChatFullBase
	{
		[Flags] public enum Flags { has_chat_photo = 0x4, has_bot_info = 0x8, has_pinned_msg_id = 0x40, can_set_username = 0x80, 
			has_scheduled = 0x100, has_folder_id = 0x800, has_call = 0x1000, has_exported_invite = 0x2000, has_ttl_period = 0x4000, 
			has_groupcall_default_join_as = 0x8000, has_theme_emoticon = 0x10000 }
		public Flags flags;
		public long id;
		public string about;
		public ChatParticipantsBase participants;
		[IfFlag(2)] public PhotoBase chat_photo;
		public PeerNotifySettings notify_settings;
		[IfFlag(13)] public ExportedChatInvite exported_invite;
		[IfFlag(3)] public BotInfo[] bot_info;
		[IfFlag(6)] public int pinned_msg_id;
		[IfFlag(11)] public int folder_id;
		[IfFlag(12)] public InputGroupCall call;
		[IfFlag(14)] public int ttl_period;
		[IfFlag(15)] public Peer groupcall_default_join_as;
		[IfFlag(16)] public string theme_emoticon;

		public override long ID => id;
		public override string About => about;
		public override PeerNotifySettings NotifySettings => notify_settings;
		public override int Folder => folder_id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelFull"/></summary>
	[TLDef(0xE9B27A17)]
	public partial class ChannelFull : ChatFullBase
	{
		[Flags] public enum Flags { has_participants_count = 0x1, has_admins_count = 0x2, has_kicked_count = 0x4, 
			can_view_participants = 0x8, has_migrated_from_chat_id = 0x10, has_pinned_msg_id = 0x20, can_set_username = 0x40, 
			can_set_stickers = 0x80, has_stickerset = 0x100, has_available_min_id = 0x200, hidden_prehistory = 0x400, 
			has_folder_id = 0x800, has_stats_dc = 0x1000, has_online_count = 0x2000, has_linked_chat_id = 0x4000, has_location = 0x8000, 
			can_set_location = 0x10000, has_slowmode_seconds = 0x20000, has_slowmode_next_send_date = 0x40000, has_scheduled = 0x80000, 
			can_view_stats = 0x100000, has_call = 0x200000, blocked = 0x400000, has_exported_invite = 0x800000, 
			has_ttl_period = 0x1000000, has_pending_suggestions = 0x2000000, has_groupcall_default_join_as = 0x4000000, 
			has_theme_emoticon = 0x8000000 }
		public Flags flags;
		public long id;
		public string about;
		[IfFlag(0)] public int participants_count;
		[IfFlag(1)] public int admins_count;
		[IfFlag(2)] public int kicked_count;
		[IfFlag(2)] public int banned_count;
		[IfFlag(13)] public int online_count;
		public int read_inbox_max_id;
		public int read_outbox_max_id;
		public int unread_count;
		public PhotoBase chat_photo;
		public PeerNotifySettings notify_settings;
		[IfFlag(23)] public ExportedChatInvite exported_invite;
		public BotInfo[] bot_info;
		[IfFlag(4)] public long migrated_from_chat_id;
		[IfFlag(4)] public int migrated_from_max_id;
		[IfFlag(5)] public int pinned_msg_id;
		[IfFlag(8)] public StickerSet stickerset;
		[IfFlag(9)] public int available_min_id;
		[IfFlag(11)] public int folder_id;
		[IfFlag(14)] public long linked_chat_id;
		[IfFlag(15)] public ChannelLocation location;
		[IfFlag(17)] public int slowmode_seconds;
		[IfFlag(18)] public DateTime slowmode_next_send_date;
		[IfFlag(12)] public int stats_dc;
		public int pts;
		[IfFlag(21)] public InputGroupCall call;
		[IfFlag(24)] public int ttl_period;
		[IfFlag(25)] public string[] pending_suggestions;
		[IfFlag(26)] public Peer groupcall_default_join_as;
		[IfFlag(27)] public string theme_emoticon;

		public override long ID => id;
		public override string About => about;
		public override PeerNotifySettings NotifySettings => notify_settings;
		public override int Folder => folder_id;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/ChatParticipant"/></summary>
	public abstract partial class ChatParticipantBase : ITLObject
	{
		public abstract long UserId { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/chatParticipant"/></summary>
	[TLDef(0xC02D4007)]
	public partial class ChatParticipant : ChatParticipantBase
	{
		public long user_id;
		public long inviter_id;
		public DateTime date;

		public override long UserId => user_id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/chatParticipantCreator"/></summary>
	[TLDef(0xE46BCEE4)]
	public partial class ChatParticipantCreator : ChatParticipantBase
	{
		public long user_id;

		public override long UserId => user_id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/chatParticipantAdmin"/></summary>
	[TLDef(0xA0933F5B)]
	public partial class ChatParticipantAdmin : ChatParticipant
	{
	}

	///<summary>See <a href="https://corefork.telegram.org/type/ChatParticipants"/></summary>
	public abstract partial class ChatParticipantsBase : ITLObject
	{
		public abstract long ChatId { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/chatParticipantsForbidden"/></summary>
	[TLDef(0x8763D3E1)]
	public partial class ChatParticipantsForbidden : ChatParticipantsBase
	{
		[Flags] public enum Flags { has_self_participant = 0x1 }
		public Flags flags;
		public long chat_id;
		[IfFlag(0)] public ChatParticipantBase self_participant;

		public override long ChatId => chat_id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/chatParticipants"/></summary>
	[TLDef(0x3CBC93F8)]
	public partial class ChatParticipants : ChatParticipantsBase
	{
		public long chat_id;
		public ChatParticipantBase[] participants;
		public int version;

		public override long ChatId => chat_id;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/chatPhoto"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/chatPhotoEmpty">chatPhotoEmpty</a></remarks>
	[TLDef(0x1C6E1C11)]
	public partial class ChatPhoto : ITLObject
	{
		[Flags] public enum Flags { has_video = 0x1, has_stripped_thumb = 0x2 }
		public Flags flags;
		public long photo_id;
		[IfFlag(1)] public byte[] stripped_thumb;
		public int dc_id;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/Message"/></summary>
	public abstract partial class MessageBase : ITLObject
	{
		public abstract int ID { get; }
		public abstract Peer From { get; }
		public abstract Peer Peer { get; }
		public abstract MessageReplyHeader ReplyTo { get; }
		public abstract DateTime Date { get; }
		public abstract int TtlPeriod { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageEmpty"/></summary>
	[TLDef(0x90A6CA84)]
	public partial class MessageEmpty : MessageBase
	{
		[Flags] public enum Flags { has_peer_id = 0x1 }
		public Flags flags;
		public int id;
		[IfFlag(0)] public Peer peer_id;

		public override int ID => id;
		public override Peer From => default;
		public override Peer Peer => peer_id;
		public override MessageReplyHeader ReplyTo => default;
		public override DateTime Date => default;
		public override int TtlPeriod => default;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/message"/></summary>
	[TLDef(0x85D6CBE2)]
	public partial class Message : MessageBase
	{
		[Flags] public enum Flags { out_ = 0x2, has_fwd_from = 0x4, has_reply_to = 0x8, mentioned = 0x10, media_unread = 0x20, 
			has_reply_markup = 0x40, has_entities = 0x80, has_from_id = 0x100, has_media = 0x200, has_views = 0x400, 
			has_via_bot_id = 0x800, silent = 0x2000, post = 0x4000, has_edit_date = 0x8000, has_post_author = 0x10000, 
			has_grouped_id = 0x20000, from_scheduled = 0x40000, legacy = 0x80000, edit_hide = 0x200000, has_restriction_reason = 0x400000, 
			has_replies = 0x800000, pinned = 0x1000000, has_ttl_period = 0x2000000 }
		public Flags flags;
		public int id;
		[IfFlag(8)] public Peer from_id;
		public Peer peer_id;
		[IfFlag(2)] public MessageFwdHeader fwd_from;
		[IfFlag(11)] public long via_bot_id;
		[IfFlag(3)] public MessageReplyHeader reply_to;
		public DateTime date;
		public string message;
		[IfFlag(9)] public MessageMedia media;
		[IfFlag(6)] public ReplyMarkup reply_markup;
		[IfFlag(7)] public MessageEntity[] entities;
		[IfFlag(10)] public int views;
		[IfFlag(10)] public int forwards;
		[IfFlag(23)] public MessageReplies replies;
		[IfFlag(15)] public DateTime edit_date;
		[IfFlag(16)] public string post_author;
		[IfFlag(17)] public long grouped_id;
		[IfFlag(22)] public RestrictionReason[] restriction_reason;
		[IfFlag(25)] public int ttl_period;

		public override int ID => id;
		public override Peer From => from_id;
		public override Peer Peer => peer_id;
		public override MessageReplyHeader ReplyTo => reply_to;
		public override DateTime Date => date;
		public override int TtlPeriod => ttl_period;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageService"/></summary>
	[TLDef(0x2B085862)]
	public partial class MessageService : MessageBase
	{
		[Flags] public enum Flags { out_ = 0x2, has_reply_to = 0x8, mentioned = 0x10, media_unread = 0x20, has_from_id = 0x100, 
			silent = 0x2000, post = 0x4000, legacy = 0x80000, has_ttl_period = 0x2000000 }
		public Flags flags;
		public int id;
		[IfFlag(8)] public Peer from_id;
		public Peer peer_id;
		[IfFlag(3)] public MessageReplyHeader reply_to;
		public DateTime date;
		public MessageAction action;
		[IfFlag(25)] public int ttl_period;

		public override int ID => id;
		public override Peer From => from_id;
		public override Peer Peer => peer_id;
		public override MessageReplyHeader ReplyTo => reply_to;
		public override DateTime Date => date;
		public override int TtlPeriod => ttl_period;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/MessageMedia"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messageMediaEmpty">messageMediaEmpty</a></remarks>
	public abstract partial class MessageMedia : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageMediaPhoto"/></summary>
	[TLDef(0x695150D7)]
	public partial class MessageMediaPhoto : MessageMedia
	{
		[Flags] public enum Flags { has_photo = 0x1, has_ttl_seconds = 0x4 }
		public Flags flags;
		[IfFlag(0)] public PhotoBase photo;
		[IfFlag(2)] public int ttl_seconds;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageMediaGeo"/></summary>
	[TLDef(0x56E0D474)]
	public partial class MessageMediaGeo : MessageMedia { public GeoPoint geo; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageMediaContact"/></summary>
	[TLDef(0x70322949)]
	public partial class MessageMediaContact : MessageMedia
	{
		public string phone_number;
		public string first_name;
		public string last_name;
		public string vcard;
		public long user_id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageMediaUnsupported"/></summary>
	[TLDef(0x9F84F49E)]
	public partial class MessageMediaUnsupported : MessageMedia { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageMediaDocument"/></summary>
	[TLDef(0x9CB070D7)]
	public partial class MessageMediaDocument : MessageMedia
	{
		[Flags] public enum Flags { has_document = 0x1, has_ttl_seconds = 0x4 }
		public Flags flags;
		[IfFlag(0)] public DocumentBase document;
		[IfFlag(2)] public int ttl_seconds;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageMediaWebPage"/></summary>
	[TLDef(0xA32DD600)]
	public partial class MessageMediaWebPage : MessageMedia { public WebPageBase webpage; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageMediaVenue"/></summary>
	[TLDef(0x2EC0533F)]
	public partial class MessageMediaVenue : MessageMedia
	{
		public GeoPoint geo;
		public string title;
		public string address;
		public string provider;
		public string venue_id;
		public string venue_type;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageMediaGame"/></summary>
	[TLDef(0xFDB19008)]
	public partial class MessageMediaGame : MessageMedia { public Game game; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageMediaInvoice"/></summary>
	[TLDef(0x84551347)]
	public partial class MessageMediaInvoice : MessageMedia
	{
		[Flags] public enum Flags { has_photo = 0x1, shipping_address_requested = 0x2, has_receipt_msg_id = 0x4, test = 0x8 }
		public Flags flags;
		public string title;
		public string description;
		[IfFlag(0)] public WebDocumentBase photo;
		[IfFlag(2)] public int receipt_msg_id;
		public string currency;
		public long total_amount;
		public string start_param;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageMediaGeoLive"/></summary>
	[TLDef(0xB940C666)]
	public partial class MessageMediaGeoLive : MessageMedia
	{
		[Flags] public enum Flags { has_heading = 0x1, has_proximity_notification_radius = 0x2 }
		public Flags flags;
		public GeoPoint geo;
		[IfFlag(0)] public int heading;
		public int period;
		[IfFlag(1)] public int proximity_notification_radius;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageMediaPoll"/></summary>
	[TLDef(0x4BD6E798)]
	public partial class MessageMediaPoll : MessageMedia
	{
		public Poll poll;
		public PollResults results;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageMediaDice"/></summary>
	[TLDef(0x3F7EE58B)]
	public partial class MessageMediaDice : MessageMedia
	{
		public int value;
		public string emoticon;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/MessageAction"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messageActionEmpty">messageActionEmpty</a></remarks>
	public abstract partial class MessageAction : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionChatCreate"/></summary>
	[TLDef(0xBD47CBAD)]
	public partial class MessageActionChatCreate : MessageAction
	{
		public string title;
		public long[] users;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionChatEditTitle"/></summary>
	[TLDef(0xB5A1CE5A)]
	public partial class MessageActionChatEditTitle : MessageAction { public string title; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionChatEditPhoto"/></summary>
	[TLDef(0x7FCB13A8)]
	public partial class MessageActionChatEditPhoto : MessageAction { public PhotoBase photo; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionChatDeletePhoto"/></summary>
	[TLDef(0x95E3FBEF)]
	public partial class MessageActionChatDeletePhoto : MessageAction { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionChatAddUser"/></summary>
	[TLDef(0x15CEFD00)]
	public partial class MessageActionChatAddUser : MessageAction { public long[] users; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionChatDeleteUser"/></summary>
	[TLDef(0xA43F30CC)]
	public partial class MessageActionChatDeleteUser : MessageAction { public long user_id; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionChatJoinedByLink"/></summary>
	[TLDef(0x031224C3)]
	public partial class MessageActionChatJoinedByLink : MessageAction { public long inviter_id; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionChannelCreate"/></summary>
	[TLDef(0x95D2AC92)]
	public partial class MessageActionChannelCreate : MessageAction { public string title; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionChatMigrateTo"/></summary>
	[TLDef(0xE1037F92)]
	public partial class MessageActionChatMigrateTo : MessageAction { public long channel_id; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionChannelMigrateFrom"/></summary>
	[TLDef(0xEA3948E9)]
	public partial class MessageActionChannelMigrateFrom : MessageAction
	{
		public string title;
		public long chat_id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionPinMessage"/></summary>
	[TLDef(0x94BD38ED)]
	public partial class MessageActionPinMessage : MessageAction { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionHistoryClear"/></summary>
	[TLDef(0x9FBAB604)]
	public partial class MessageActionHistoryClear : MessageAction { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionGameScore"/></summary>
	[TLDef(0x92A72876)]
	public partial class MessageActionGameScore : MessageAction
	{
		public long game_id;
		public int score;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionPaymentSentMe"/></summary>
	[TLDef(0x8F31B327)]
	public partial class MessageActionPaymentSentMe : MessageAction
	{
		[Flags] public enum Flags { has_info = 0x1, has_shipping_option_id = 0x2 }
		public Flags flags;
		public string currency;
		public long total_amount;
		public byte[] payload;
		[IfFlag(0)] public PaymentRequestedInfo info;
		[IfFlag(1)] public string shipping_option_id;
		public PaymentCharge charge;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionPaymentSent"/></summary>
	[TLDef(0x40699CD0)]
	public partial class MessageActionPaymentSent : MessageAction
	{
		public string currency;
		public long total_amount;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionPhoneCall"/></summary>
	[TLDef(0x80E11A7F)]
	public partial class MessageActionPhoneCall : MessageAction
	{
		[Flags] public enum Flags { has_reason = 0x1, has_duration = 0x2, video = 0x4 }
		public Flags flags;
		public long call_id;
		[IfFlag(0)] public PhoneCallDiscardReason reason;
		[IfFlag(1)] public int duration;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionScreenshotTaken"/></summary>
	[TLDef(0x4792929B)]
	public partial class MessageActionScreenshotTaken : MessageAction { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionCustomAction"/></summary>
	[TLDef(0xFAE69F56)]
	public partial class MessageActionCustomAction : MessageAction { public string message; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionBotAllowed"/></summary>
	[TLDef(0xABE9AFFE)]
	public partial class MessageActionBotAllowed : MessageAction { public string domain; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionSecureValuesSentMe"/></summary>
	[TLDef(0x1B287353)]
	public partial class MessageActionSecureValuesSentMe : MessageAction
	{
		public SecureValue[] values;
		public SecureCredentialsEncrypted credentials;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionSecureValuesSent"/></summary>
	[TLDef(0xD95C6154)]
	public partial class MessageActionSecureValuesSent : MessageAction { public SecureValueType[] types; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionContactSignUp"/></summary>
	[TLDef(0xF3F25F76)]
	public partial class MessageActionContactSignUp : MessageAction { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionGeoProximityReached"/></summary>
	[TLDef(0x98E0D697)]
	public partial class MessageActionGeoProximityReached : MessageAction
	{
		public Peer from_id;
		public Peer to_id;
		public int distance;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionGroupCall"/></summary>
	[TLDef(0x7A0D7F42)]
	public partial class MessageActionGroupCall : MessageAction
	{
		[Flags] public enum Flags { has_duration = 0x1 }
		public Flags flags;
		public InputGroupCall call;
		[IfFlag(0)] public int duration;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionInviteToGroupCall"/></summary>
	[TLDef(0x502F92F7)]
	public partial class MessageActionInviteToGroupCall : MessageAction
	{
		public InputGroupCall call;
		public long[] users;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionSetMessagesTTL"/></summary>
	[TLDef(0xAA1AFBFD)]
	public partial class MessageActionSetMessagesTTL : MessageAction { public int period; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionGroupCallScheduled"/></summary>
	[TLDef(0xB3A07661)]
	public partial class MessageActionGroupCallScheduled : MessageAction
	{
		public InputGroupCall call;
		public DateTime schedule_date;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageActionSetChatTheme"/></summary>
	[TLDef(0xAA786345)]
	public partial class MessageActionSetChatTheme : MessageAction { public string emoticon; }

	///<summary>See <a href="https://corefork.telegram.org/type/Dialog"/></summary>
	public abstract partial class DialogBase : ITLObject
	{
		public abstract Peer Peer { get; }
		public abstract int TopMessage { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/dialog"/></summary>
	[TLDef(0x2C171F72)]
	public partial class Dialog : DialogBase
	{
		[Flags] public enum Flags { has_pts = 0x1, has_draft = 0x2, pinned = 0x4, unread_mark = 0x8, has_folder_id = 0x10 }
		public Flags flags;
		public Peer peer;
		public int top_message;
		public int read_inbox_max_id;
		public int read_outbox_max_id;
		public int unread_count;
		public int unread_mentions_count;
		public PeerNotifySettings notify_settings;
		[IfFlag(0)] public int pts;
		[IfFlag(1)] public DraftMessageBase draft;
		[IfFlag(4)] public int folder_id;

		public override Peer Peer => peer;
		public override int TopMessage => top_message;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/dialogFolder"/></summary>
	[TLDef(0x71BD134C)]
	public partial class DialogFolder : DialogBase
	{
		[Flags] public enum Flags { pinned = 0x4 }
		public Flags flags;
		public Folder folder;
		public Peer peer;
		public int top_message;
		public int unread_muted_peers_count;
		public int unread_unmuted_peers_count;
		public int unread_muted_messages_count;
		public int unread_unmuted_messages_count;

		public override Peer Peer => peer;
		public override int TopMessage => top_message;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/Photo"/></summary>
	public abstract partial class PhotoBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/photoEmpty"/></summary>
	[TLDef(0x2331B22D)]
	public partial class PhotoEmpty : PhotoBase { public long id; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/photo"/></summary>
	[TLDef(0xFB197A65)]
	public partial class Photo : PhotoBase
	{
		[Flags] public enum Flags { has_stickers = 0x1, has_video_sizes = 0x2 }
		public Flags flags;
		public long id;
		public long access_hash;
		public byte[] file_reference;
		public DateTime date;
		public PhotoSizeBase[] sizes;
		[IfFlag(1)] public VideoSize[] video_sizes;
		public int dc_id;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/PhotoSize"/></summary>
	public abstract partial class PhotoSizeBase : ITLObject
	{
		public abstract string Type { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/photoSizeEmpty"/></summary>
	[TLDef(0x0E17E23C)]
	public partial class PhotoSizeEmpty : PhotoSizeBase
	{
		public string type;

		public override string Type => type;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/photoSize"/></summary>
	[TLDef(0x75C78E60)]
	public partial class PhotoSize : PhotoSizeBase
	{
		public string type;
		public int w;
		public int h;
		public int size;

		public override string Type => type;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/photoCachedSize"/></summary>
	[TLDef(0x021E1AD6)]
	public partial class PhotoCachedSize : PhotoSizeBase
	{
		public string type;
		public int w;
		public int h;
		public byte[] bytes;

		public override string Type => type;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/photoStrippedSize"/></summary>
	[TLDef(0xE0B0BC2E)]
	public partial class PhotoStrippedSize : PhotoSizeBase
	{
		public string type;
		public byte[] bytes;

		public override string Type => type;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/photoSizeProgressive"/></summary>
	[TLDef(0xFA3EFB95)]
	public partial class PhotoSizeProgressive : PhotoSizeBase
	{
		public string type;
		public int w;
		public int h;
		public int[] sizes;

		public override string Type => type;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/photoPathSize"/></summary>
	[TLDef(0xD8214D41)]
	public partial class PhotoPathSize : PhotoSizeBase
	{
		public string type;
		public byte[] bytes;

		public override string Type => type;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/geoPoint"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/geoPointEmpty">geoPointEmpty</a></remarks>
	[TLDef(0xB2A2F663)]
	public partial class GeoPoint : ITLObject
	{
		[Flags] public enum Flags { has_accuracy_radius = 0x1 }
		public Flags flags;
		public double long_;
		public double lat;
		public long access_hash;
		[IfFlag(0)] public int accuracy_radius;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/auth.sentCode"/></summary>
	[TLDef(0x5E002502)]
	public partial class Auth_SentCode : ITLObject
	{
		[Flags] public enum Flags { has_next_type = 0x2, has_timeout = 0x4 }
		public Flags flags;
		public Auth_SentCodeType type;
		public string phone_code_hash;
		[IfFlag(1)] public Auth_CodeType next_type;
		[IfFlag(2)] public int timeout;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/auth.Authorization"/></summary>
	public abstract partial class Auth_AuthorizationBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/auth.authorization"/></summary>
	[TLDef(0xCD050916)]
	public partial class Auth_Authorization : Auth_AuthorizationBase
	{
		[Flags] public enum Flags { has_tmp_sessions = 0x1 }
		public Flags flags;
		[IfFlag(0)] public int tmp_sessions;
		public UserBase user;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/auth.authorizationSignUpRequired"/></summary>
	[TLDef(0x44747E9A)]
	public partial class Auth_AuthorizationSignUpRequired : Auth_AuthorizationBase
	{
		[Flags] public enum Flags { has_terms_of_service = 0x1 }
		public Flags flags;
		[IfFlag(0)] public Help_TermsOfService terms_of_service;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/auth.exportedAuthorization"/></summary>
	[TLDef(0xB434E2B8)]
	public partial class Auth_ExportedAuthorization : ITLObject
	{
		public long id;
		public byte[] bytes;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/InputNotifyPeer"/></summary>
	public abstract partial class InputNotifyPeerBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputNotifyPeer"/></summary>
	[TLDef(0xB8BC5B0C)]
	public partial class InputNotifyPeer : InputNotifyPeerBase { public InputPeer peer; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputNotifyUsers"/></summary>
	[TLDef(0x193B4417)]
	public partial class InputNotifyUsers : InputNotifyPeerBase { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputNotifyChats"/></summary>
	[TLDef(0x4A95E84E)]
	public partial class InputNotifyChats : InputNotifyPeerBase { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputNotifyBroadcasts"/></summary>
	[TLDef(0xB1DB7C7E)]
	public partial class InputNotifyBroadcasts : InputNotifyPeerBase { }

	///<summary>See <a href="https://corefork.telegram.org/constructor/inputPeerNotifySettings"/></summary>
	[TLDef(0x9C3D198E)]
	public partial class InputPeerNotifySettings : ITLObject
	{
		[Flags] public enum Flags { has_show_previews = 0x1, has_silent = 0x2, has_mute_until = 0x4, has_sound = 0x8 }
		public Flags flags;
		[IfFlag(0)] public bool show_previews;
		[IfFlag(1)] public bool silent;
		[IfFlag(2)] public int mute_until;
		[IfFlag(3)] public string sound;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/peerNotifySettings"/></summary>
	[TLDef(0xAF509D20)]
	public partial class PeerNotifySettings : ITLObject
	{
		[Flags] public enum Flags { has_show_previews = 0x1, has_silent = 0x2, has_mute_until = 0x4, has_sound = 0x8 }
		public Flags flags;
		[IfFlag(0)] public bool show_previews;
		[IfFlag(1)] public bool silent;
		[IfFlag(2)] public int mute_until;
		[IfFlag(3)] public string sound;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/peerSettings"/></summary>
	[TLDef(0x733F2961)]
	public partial class PeerSettings : ITLObject
	{
		[Flags] public enum Flags { report_spam = 0x1, add_contact = 0x2, block_contact = 0x4, share_contact = 0x8, 
			need_contacts_exception = 0x10, report_geo = 0x20, has_geo_distance = 0x40, autoarchived = 0x80, invite_members = 0x100 }
		public Flags flags;
		[IfFlag(6)] public int geo_distance;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/WallPaper"/></summary>
	public abstract partial class WallPaperBase : ITLObject
	{
		public abstract long ID { get; }
		public abstract WallPaperSettings Settings { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/wallPaper"/></summary>
	[TLDef(0xA437C3ED)]
	public partial class WallPaper : WallPaperBase
	{
		[Flags] public enum Flags { creator = 0x1, default_ = 0x2, has_settings = 0x4, pattern = 0x8, dark = 0x10 }
		public long id;
		public Flags flags;
		public long access_hash;
		public string slug;
		public DocumentBase document;
		[IfFlag(2)] public WallPaperSettings settings;

		public override long ID => id;
		public override WallPaperSettings Settings => settings;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/wallPaperNoFile"/></summary>
	[TLDef(0xE0804116)]
	public partial class WallPaperNoFile : WallPaperBase
	{
		[Flags] public enum Flags { default_ = 0x2, has_settings = 0x4, dark = 0x10 }
		public long id;
		public Flags flags;
		[IfFlag(2)] public WallPaperSettings settings;

		public override long ID => id;
		public override WallPaperSettings Settings => settings;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/ReportReason"/></summary>
	public enum ReportReason : uint
	{
		///<summary>See <a href="https://corefork.telegram.org/constructor/inputReportReasonSpam"/></summary>
		Spam = 0x58DBCAB8,
		///<summary>See <a href="https://corefork.telegram.org/constructor/inputReportReasonViolence"/></summary>
		Violence = 0x1E22C78D,
		///<summary>See <a href="https://corefork.telegram.org/constructor/inputReportReasonPornography"/></summary>
		Pornography = 0x2E59D922,
		///<summary>See <a href="https://corefork.telegram.org/constructor/inputReportReasonChildAbuse"/></summary>
		ChildAbuse = 0xADF44EE3,
		///<summary>See <a href="https://corefork.telegram.org/constructor/inputReportReasonOther"/></summary>
		Other = 0xC1E4A2B1,
		///<summary>See <a href="https://corefork.telegram.org/constructor/inputReportReasonCopyright"/></summary>
		Copyright = 0x9B89F93A,
		///<summary>See <a href="https://corefork.telegram.org/constructor/inputReportReasonGeoIrrelevant"/></summary>
		GeoIrrelevant = 0xDBD4FEED,
		///<summary>See <a href="https://corefork.telegram.org/constructor/inputReportReasonFake"/></summary>
		Fake = 0xF5DDD6E7,
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/userFull"/></summary>
	[TLDef(0xD697FF05)]
	public partial class UserFull : ITLObject
	{
		[Flags] public enum Flags { blocked = 0x1, has_about = 0x2, has_profile_photo = 0x4, has_bot_info = 0x8, 
			phone_calls_available = 0x10, phone_calls_private = 0x20, has_pinned_msg_id = 0x40, can_pin_message = 0x80, 
			has_folder_id = 0x800, has_scheduled = 0x1000, video_calls_available = 0x2000, has_ttl_period = 0x4000, 
			has_theme_emoticon = 0x8000 }
		public Flags flags;
		public UserBase user;
		[IfFlag(1)] public string about;
		public PeerSettings settings;
		[IfFlag(2)] public PhotoBase profile_photo;
		public PeerNotifySettings notify_settings;
		[IfFlag(3)] public BotInfo bot_info;
		[IfFlag(6)] public int pinned_msg_id;
		public int common_chats_count;
		[IfFlag(11)] public int folder_id;
		[IfFlag(14)] public int ttl_period;
		[IfFlag(15)] public string theme_emoticon;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/contact"/></summary>
	[TLDef(0x145ADE0B)]
	public partial class Contact : ITLObject
	{
		public long user_id;
		public bool mutual;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/importedContact"/></summary>
	[TLDef(0xC13E3C50)]
	public partial class ImportedContact : ITLObject
	{
		public long user_id;
		public long client_id;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/contactStatus"/></summary>
	[TLDef(0x16D9703B)]
	public partial class ContactStatus : ITLObject
	{
		public long user_id;
		public UserStatus status;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/contacts.contacts"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/contacts.contactsNotModified">contacts.contactsNotModified</a></remarks>
	[TLDef(0xEAE87E42)]
	public partial class Contacts_Contacts : ITLObject
	{
		public Contact[] contacts;
		public int saved_count;
		public Dictionary<long, UserBase> users;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/contacts.importedContacts"/></summary>
	[TLDef(0x77D01C3B)]
	public partial class Contacts_ImportedContacts : ITLObject
	{
		public ImportedContact[] imported;
		public PopularContact[] popular_invites;
		public long[] retry_contacts;
		public Dictionary<long, UserBase> users;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/contacts.blocked"/></summary>
	[TLDef(0x0ADE1591)]
	public partial class Contacts_Blocked : ITLObject
	{
		public PeerBlocked[] blocked;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/contacts.blockedSlice"/></summary>
	[TLDef(0xE1664194, inheritAfter = true)]
	public partial class Contacts_BlockedSlice : Contacts_Blocked { public int count; }

	///<summary>See <a href="https://corefork.telegram.org/type/messages.Dialogs"/></summary>
	public abstract partial class Messages_DialogsBase : ITLObject
	{
		public abstract DialogBase[] Dialogs { get; }
		public abstract MessageBase[] Messages { get; }
		public abstract IPeerInfo UserOrChat(Peer peer);
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.dialogs"/></summary>
	[TLDef(0x15BA6C40)]
	public partial class Messages_Dialogs : Messages_DialogsBase
	{
		public DialogBase[] dialogs;
		public MessageBase[] messages;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;

		public override DialogBase[] Dialogs => dialogs;
		public override MessageBase[] Messages => messages;
		public override IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.dialogsSlice"/></summary>
	[TLDef(0x71E094F3, inheritAfter = true)]
	public partial class Messages_DialogsSlice : Messages_Dialogs
	{
		public int count;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.dialogsNotModified"/></summary>
	[TLDef(0xF0E3E596)]
	public partial class Messages_DialogsNotModified : Messages_DialogsBase
	{
		public int count;

		public override DialogBase[] Dialogs => default;
		public override MessageBase[] Messages => default;
		public override IPeerInfo UserOrChat(Peer peer) => null;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/messages.Messages"/></summary>
	public abstract partial class Messages_MessagesBase : ITLObject
	{
		public abstract MessageBase[] Messages { get; }
		public abstract IPeerInfo UserOrChat(Peer peer);
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.messages"/></summary>
	[TLDef(0x8C718E87)]
	public partial class Messages_Messages : Messages_MessagesBase
	{
		public MessageBase[] messages;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;

		public override MessageBase[] Messages => messages;
		public override IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.messagesSlice"/></summary>
	[TLDef(0x3A54685E, inheritAfter = true)]
	public partial class Messages_MessagesSlice : Messages_Messages
	{
		[Flags] public enum Flags { has_next_rate = 0x1, inexact = 0x2, has_offset_id_offset = 0x4 }
		public Flags flags;
		public int count;
		[IfFlag(0)] public int next_rate;
		[IfFlag(2)] public int offset_id_offset;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.channelMessages"/></summary>
	[TLDef(0x64479808)]
	public partial class Messages_ChannelMessages : Messages_MessagesBase
	{
		[Flags] public enum Flags { inexact = 0x2, has_offset_id_offset = 0x4 }
		public Flags flags;
		public int pts;
		public int count;
		[IfFlag(2)] public int offset_id_offset;
		public MessageBase[] messages;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;

		public override MessageBase[] Messages => messages;
		public override IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.messagesNotModified"/></summary>
	[TLDef(0x74535F21)]
	public partial class Messages_MessagesNotModified : Messages_MessagesBase
	{
		public int count;

		public override MessageBase[] Messages => default;
		public override IPeerInfo UserOrChat(Peer peer) => null;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.chats"/></summary>
	[TLDef(0x64FF9FD5)]
	public partial class Messages_Chats : ITLObject { public Dictionary<long, ChatBase> chats; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.chatsSlice"/></summary>
	[TLDef(0x9CD81144, inheritAfter = true)]
	public partial class Messages_ChatsSlice : Messages_Chats { public int count; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.chatFull"/></summary>
	[TLDef(0xE5D7D19C)]
	public partial class Messages_ChatFull : ITLObject
	{
		public ChatFullBase full_chat;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.affectedHistory"/></summary>
	[TLDef(0xB45C69D1)]
	public partial class Messages_AffectedHistory : ITLObject
	{
		public int pts;
		public int pts_count;
		public int offset;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/MessagesFilter"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputMessagesFilterEmpty">inputMessagesFilterEmpty</a></remarks>
	public abstract partial class MessagesFilter : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterPhotos"/></summary>
	[TLDef(0x9609A51C)]
	public partial class InputMessagesFilterPhotos : MessagesFilter { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterVideo"/></summary>
	[TLDef(0x9FC00E65)]
	public partial class InputMessagesFilterVideo : MessagesFilter { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterPhotoVideo"/></summary>
	[TLDef(0x56E9F0E4)]
	public partial class InputMessagesFilterPhotoVideo : MessagesFilter { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterDocument"/></summary>
	[TLDef(0x9EDDF188)]
	public partial class InputMessagesFilterDocument : MessagesFilter { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterUrl"/></summary>
	[TLDef(0x7EF0DD87)]
	public partial class InputMessagesFilterUrl : MessagesFilter { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterGif"/></summary>
	[TLDef(0xFFC86587)]
	public partial class InputMessagesFilterGif : MessagesFilter { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterVoice"/></summary>
	[TLDef(0x50F5C392)]
	public partial class InputMessagesFilterVoice : MessagesFilter { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterMusic"/></summary>
	[TLDef(0x3751B49E)]
	public partial class InputMessagesFilterMusic : MessagesFilter { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterChatPhotos"/></summary>
	[TLDef(0x3A20ECB8)]
	public partial class InputMessagesFilterChatPhotos : MessagesFilter { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterPhoneCalls"/></summary>
	[TLDef(0x80C99768)]
	public partial class InputMessagesFilterPhoneCalls : MessagesFilter
	{
		[Flags] public enum Flags { missed = 0x1 }
		public Flags flags;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterRoundVoice"/></summary>
	[TLDef(0x7A7C17A4)]
	public partial class InputMessagesFilterRoundVoice : MessagesFilter { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterRoundVideo"/></summary>
	[TLDef(0xB549DA53)]
	public partial class InputMessagesFilterRoundVideo : MessagesFilter { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterMyMentions"/></summary>
	[TLDef(0xC1F8E69A)]
	public partial class InputMessagesFilterMyMentions : MessagesFilter { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterGeo"/></summary>
	[TLDef(0xE7026D0D)]
	public partial class InputMessagesFilterGeo : MessagesFilter { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterContacts"/></summary>
	[TLDef(0xE062DB83)]
	public partial class InputMessagesFilterContacts : MessagesFilter { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMessagesFilterPinned"/></summary>
	[TLDef(0x1BB00451)]
	public partial class InputMessagesFilterPinned : MessagesFilter { }

	///<summary>See <a href="https://corefork.telegram.org/type/Update"/></summary>
	public abstract partial class Update : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateNewMessage"/></summary>
	[TLDef(0x1F2B0AFD)]
	public partial class UpdateNewMessage : Update
	{
		public MessageBase message;
		public int pts;
		public int pts_count;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateMessageID"/></summary>
	[TLDef(0x4E90BFD6)]
	public partial class UpdateMessageID : Update
	{
		public int id;
		public long random_id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateDeleteMessages"/></summary>
	[TLDef(0xA20DB0E5)]
	public partial class UpdateDeleteMessages : Update
	{
		public int[] messages;
		public int pts;
		public int pts_count;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateUserTyping"/></summary>
	[TLDef(0xC01E857F)]
	public partial class UpdateUserTyping : Update
	{
		public long user_id;
		public SendMessageAction action;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateChatUserTyping"/></summary>
	[TLDef(0x83487AF0)]
	public partial class UpdateChatUserTyping : UpdateChat
	{
		public Peer from_id;
		public SendMessageAction action;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateChatParticipants"/></summary>
	[TLDef(0x07761198)]
	public partial class UpdateChatParticipants : Update { public ChatParticipantsBase participants; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateUserStatus"/></summary>
	[TLDef(0xE5BDF8DE)]
	public partial class UpdateUserStatus : Update
	{
		public long user_id;
		public UserStatus status;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateUserName"/></summary>
	[TLDef(0xC3F202E0)]
	public partial class UpdateUserName : Update
	{
		public long user_id;
		public string first_name;
		public string last_name;
		public string username;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateUserPhoto"/></summary>
	[TLDef(0xF227868C)]
	public partial class UpdateUserPhoto : Update
	{
		public long user_id;
		public DateTime date;
		public UserProfilePhoto photo;
		public bool previous;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateNewEncryptedMessage"/></summary>
	[TLDef(0x12BCBD9A)]
	public partial class UpdateNewEncryptedMessage : Update
	{
		public EncryptedMessageBase message;
		public int qts;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateEncryptedChatTyping"/></summary>
	[TLDef(0x1710F156)]
	public partial class UpdateEncryptedChatTyping : Update { public int chat_id; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateEncryption"/></summary>
	[TLDef(0xB4A2E88D)]
	public partial class UpdateEncryption : Update
	{
		public EncryptedChatBase chat;
		public DateTime date;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateEncryptedMessagesRead"/></summary>
	[TLDef(0x38FE25B7)]
	public partial class UpdateEncryptedMessagesRead : Update
	{
		public int chat_id;
		public DateTime max_date;
		public DateTime date;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateChatParticipantAdd"/></summary>
	[TLDef(0x3DDA5451)]
	public partial class UpdateChatParticipantAdd : UpdateChat
	{
		public long user_id;
		public long inviter_id;
		public DateTime date;
		public int version;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateChatParticipantDelete"/></summary>
	[TLDef(0xE32F3D77)]
	public partial class UpdateChatParticipantDelete : UpdateChat
	{
		public long user_id;
		public int version;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateDcOptions"/></summary>
	[TLDef(0x8E5E9873)]
	public partial class UpdateDcOptions : Update { public DcOption[] dc_options; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateNotifySettings"/></summary>
	[TLDef(0xBEC268EF)]
	public partial class UpdateNotifySettings : Update
	{
		public NotifyPeerBase peer;
		public PeerNotifySettings notify_settings;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateServiceNotification"/></summary>
	[TLDef(0xEBE46819)]
	public partial class UpdateServiceNotification : Update
	{
		[Flags] public enum Flags { popup = 0x1, has_inbox_date = 0x2 }
		public Flags flags;
		[IfFlag(1)] public DateTime inbox_date;
		public string type;
		public string message;
		public MessageMedia media;
		public MessageEntity[] entities;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updatePrivacy"/></summary>
	[TLDef(0xEE3B272A)]
	public partial class UpdatePrivacy : Update
	{
		public PrivacyKey key;
		public PrivacyRule[] rules;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateUserPhone"/></summary>
	[TLDef(0x05492A13)]
	public partial class UpdateUserPhone : Update
	{
		public long user_id;
		public string phone;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateReadHistoryInbox"/></summary>
	[TLDef(0x9C974FDF)]
	public partial class UpdateReadHistoryInbox : Update
	{
		[Flags] public enum Flags { has_folder_id = 0x1 }
		public Flags flags;
		[IfFlag(0)] public int folder_id;
		public Peer peer;
		public int max_id;
		public int still_unread_count;
		public int pts;
		public int pts_count;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateReadHistoryOutbox"/></summary>
	[TLDef(0x2F2F21BF)]
	public partial class UpdateReadHistoryOutbox : Update
	{
		public Peer peer;
		public int max_id;
		public int pts;
		public int pts_count;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateWebPage"/></summary>
	[TLDef(0x7F891213)]
	public partial class UpdateWebPage : Update
	{
		public WebPageBase webpage;
		public int pts;
		public int pts_count;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateReadMessagesContents"/></summary>
	[TLDef(0x68C13933)]
	public partial class UpdateReadMessagesContents : Update
	{
		public int[] messages;
		public int pts;
		public int pts_count;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateChannelTooLong"/></summary>
	[TLDef(0x108D941F)]
	public partial class UpdateChannelTooLong : Update
	{
		[Flags] public enum Flags { has_pts = 0x1 }
		public Flags flags;
		public long channel_id;
		[IfFlag(0)] public int pts;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateChannel"/></summary>
	[TLDef(0x635B4C09)]
	public partial class UpdateChannel : Update { public long channel_id; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateNewChannelMessage"/></summary>
	[TLDef(0x62BA04D9)]
	public partial class UpdateNewChannelMessage : UpdateNewMessage { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateReadChannelInbox"/></summary>
	[TLDef(0x922E6E10)]
	public partial class UpdateReadChannelInbox : Update
	{
		[Flags] public enum Flags { has_folder_id = 0x1 }
		public Flags flags;
		[IfFlag(0)] public int folder_id;
		public long channel_id;
		public int max_id;
		public int still_unread_count;
		public int pts;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateDeleteChannelMessages"/></summary>
	[TLDef(0xC32D5B12, inheritAfter = true)]
	public partial class UpdateDeleteChannelMessages : UpdateDeleteMessages { public long channel_id; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateChannelMessageViews"/></summary>
	[TLDef(0xF226AC08)]
	public partial class UpdateChannelMessageViews : UpdateChannel
	{
		public int id;
		public int views;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateChatParticipantAdmin"/></summary>
	[TLDef(0xD7CA61A2)]
	public partial class UpdateChatParticipantAdmin : UpdateChat
	{
		public long user_id;
		public bool is_admin;
		public int version;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateNewStickerSet"/></summary>
	[TLDef(0x688A30AA)]
	public partial class UpdateNewStickerSet : Update { public Messages_StickerSet stickerset; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateStickerSetsOrder"/></summary>
	[TLDef(0x0BB2D201)]
	public partial class UpdateStickerSetsOrder : Update
	{
		[Flags] public enum Flags { masks = 0x1 }
		public Flags flags;
		public long[] order;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateStickerSets"/></summary>
	[TLDef(0x43AE3DEC)]
	public partial class UpdateStickerSets : Update { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateSavedGifs"/></summary>
	[TLDef(0x9375341E)]
	public partial class UpdateSavedGifs : Update { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateBotInlineQuery"/></summary>
	[TLDef(0x496F379C)]
	public partial class UpdateBotInlineQuery : Update
	{
		[Flags] public enum Flags { has_geo = 0x1, has_peer_type = 0x2 }
		public Flags flags;
		public long query_id;
		public long user_id;
		public string query;
		[IfFlag(0)] public GeoPoint geo;
		[IfFlag(1)] public InlineQueryPeerType peer_type;
		public string offset;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateBotInlineSend"/></summary>
	[TLDef(0x12F12A07)]
	public partial class UpdateBotInlineSend : Update
	{
		[Flags] public enum Flags { has_geo = 0x1, has_msg_id = 0x2 }
		public Flags flags;
		public long user_id;
		public string query;
		[IfFlag(0)] public GeoPoint geo;
		public string id;
		[IfFlag(1)] public InputBotInlineMessageIDBase msg_id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateEditChannelMessage"/></summary>
	[TLDef(0x1B3F4DF7)]
	public partial class UpdateEditChannelMessage : UpdateEditMessage { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateBotCallbackQuery"/></summary>
	[TLDef(0xB9CFC48D)]
	public partial class UpdateBotCallbackQuery : Update
	{
		[Flags] public enum Flags { has_data = 0x1, has_game_short_name = 0x2 }
		public Flags flags;
		public long query_id;
		public long user_id;
		public Peer peer;
		public int msg_id;
		public long chat_instance;
		[IfFlag(0)] public byte[] data;
		[IfFlag(1)] public string game_short_name;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateEditMessage"/></summary>
	[TLDef(0xE40370A3)]
	public partial class UpdateEditMessage : Update
	{
		public MessageBase message;
		public int pts;
		public int pts_count;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateInlineBotCallbackQuery"/></summary>
	[TLDef(0x691E9052)]
	public partial class UpdateInlineBotCallbackQuery : Update
	{
		[Flags] public enum Flags { has_data = 0x1, has_game_short_name = 0x2 }
		public Flags flags;
		public long query_id;
		public long user_id;
		public InputBotInlineMessageIDBase msg_id;
		public long chat_instance;
		[IfFlag(0)] public byte[] data;
		[IfFlag(1)] public string game_short_name;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateReadChannelOutbox"/></summary>
	[TLDef(0xB75F99A9)]
	public partial class UpdateReadChannelOutbox : Update
	{
		public long channel_id;
		public int max_id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateDraftMessage"/></summary>
	[TLDef(0xEE2BB969)]
	public partial class UpdateDraftMessage : Update
	{
		public Peer peer;
		public DraftMessageBase draft;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateReadFeaturedStickers"/></summary>
	[TLDef(0x571D2742)]
	public partial class UpdateReadFeaturedStickers : Update { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateRecentStickers"/></summary>
	[TLDef(0x9A422C20)]
	public partial class UpdateRecentStickers : Update { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateConfig"/></summary>
	[TLDef(0xA229DD06)]
	public partial class UpdateConfig : Update { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updatePtsChanged"/></summary>
	[TLDef(0x3354678F)]
	public partial class UpdatePtsChanged : Update { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateChannelWebPage"/></summary>
	[TLDef(0x2F2BA99F, inheritAfter = true)]
	public partial class UpdateChannelWebPage : UpdateWebPage { public long channel_id; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateDialogPinned"/></summary>
	[TLDef(0x6E6FE51C)]
	public partial class UpdateDialogPinned : Update
	{
		[Flags] public enum Flags { pinned = 0x1, has_folder_id = 0x2 }
		public Flags flags;
		[IfFlag(1)] public int folder_id;
		public DialogPeerBase peer;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updatePinnedDialogs"/></summary>
	[TLDef(0xFA0F3CA2)]
	public partial class UpdatePinnedDialogs : Update
	{
		[Flags] public enum Flags { has_order = 0x1, has_folder_id = 0x2 }
		public Flags flags;
		[IfFlag(1)] public int folder_id;
		[IfFlag(0)] public DialogPeerBase[] order;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateBotWebhookJSON"/></summary>
	[TLDef(0x8317C0C3)]
	public partial class UpdateBotWebhookJSON : Update { public DataJSON data; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateBotWebhookJSONQuery"/></summary>
	[TLDef(0x9B9240A6)]
	public partial class UpdateBotWebhookJSONQuery : Update
	{
		public long query_id;
		public DataJSON data;
		public int timeout;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateBotShippingQuery"/></summary>
	[TLDef(0xB5AEFD7D)]
	public partial class UpdateBotShippingQuery : Update
	{
		public long query_id;
		public long user_id;
		public byte[] payload;
		public PostAddress shipping_address;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateBotPrecheckoutQuery"/></summary>
	[TLDef(0x8CAA9A96)]
	public partial class UpdateBotPrecheckoutQuery : Update
	{
		[Flags] public enum Flags { has_info = 0x1, has_shipping_option_id = 0x2 }
		public Flags flags;
		public long query_id;
		public long user_id;
		public byte[] payload;
		[IfFlag(0)] public PaymentRequestedInfo info;
		[IfFlag(1)] public string shipping_option_id;
		public string currency;
		public long total_amount;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updatePhoneCall"/></summary>
	[TLDef(0xAB0F6B1E)]
	public partial class UpdatePhoneCall : Update { public PhoneCallBase phone_call; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateLangPackTooLong"/></summary>
	[TLDef(0x46560264)]
	public partial class UpdateLangPackTooLong : Update { public string lang_code; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateLangPack"/></summary>
	[TLDef(0x56022F4D)]
	public partial class UpdateLangPack : Update { public LangPackDifference difference; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateFavedStickers"/></summary>
	[TLDef(0xE511996D)]
	public partial class UpdateFavedStickers : Update { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateChannelReadMessagesContents"/></summary>
	[TLDef(0x44BDD535)]
	public partial class UpdateChannelReadMessagesContents : UpdateChannel { public int[] messages; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateContactsReset"/></summary>
	[TLDef(0x7084A7BE)]
	public partial class UpdateContactsReset : Update { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateChannelAvailableMessages"/></summary>
	[TLDef(0xB23FC698)]
	public partial class UpdateChannelAvailableMessages : UpdateChannel { public int available_min_id; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateDialogUnreadMark"/></summary>
	[TLDef(0xE16459C3)]
	public partial class UpdateDialogUnreadMark : Update
	{
		[Flags] public enum Flags { unread = 0x1 }
		public Flags flags;
		public DialogPeerBase peer;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateMessagePoll"/></summary>
	[TLDef(0xACA1657B)]
	public partial class UpdateMessagePoll : Update
	{
		[Flags] public enum Flags { has_poll = 0x1 }
		public Flags flags;
		public long poll_id;
		[IfFlag(0)] public Poll poll;
		public PollResults results;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateChatDefaultBannedRights"/></summary>
	[TLDef(0x54C01850)]
	public partial class UpdateChatDefaultBannedRights : Update
	{
		public Peer peer;
		public ChatBannedRights default_banned_rights;
		public int version;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateFolderPeers"/></summary>
	[TLDef(0x19360DC0)]
	public partial class UpdateFolderPeers : Update
	{
		public FolderPeer[] folder_peers;
		public int pts;
		public int pts_count;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updatePeerSettings"/></summary>
	[TLDef(0x6A7E7366)]
	public partial class UpdatePeerSettings : Update
	{
		public Peer peer;
		public PeerSettings settings;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updatePeerLocated"/></summary>
	[TLDef(0xB4AFCFB0)]
	public partial class UpdatePeerLocated : Update { public PeerLocatedBase[] peers; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateNewScheduledMessage"/></summary>
	[TLDef(0x39A51DFB)]
	public partial class UpdateNewScheduledMessage : Update { public MessageBase message; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateDeleteScheduledMessages"/></summary>
	[TLDef(0x90866CEE)]
	public partial class UpdateDeleteScheduledMessages : Update
	{
		public Peer peer;
		public int[] messages;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateTheme"/></summary>
	[TLDef(0x8216FBA3)]
	public partial class UpdateTheme : Update { public Theme theme; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateGeoLiveViewed"/></summary>
	[TLDef(0x871FB939)]
	public partial class UpdateGeoLiveViewed : Update
	{
		public Peer peer;
		public int msg_id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateLoginToken"/></summary>
	[TLDef(0x564FE691)]
	public partial class UpdateLoginToken : Update { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateMessagePollVote"/></summary>
	[TLDef(0x106395C9)]
	public partial class UpdateMessagePollVote : Update
	{
		public long poll_id;
		public long user_id;
		public byte[][] options;
		public int qts;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateDialogFilter"/></summary>
	[TLDef(0x26FFDE7D)]
	public partial class UpdateDialogFilter : Update
	{
		[Flags] public enum Flags { has_filter = 0x1 }
		public Flags flags;
		public int id;
		[IfFlag(0)] public DialogFilter filter;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateDialogFilterOrder"/></summary>
	[TLDef(0xA5D72105)]
	public partial class UpdateDialogFilterOrder : Update { public int[] order; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateDialogFilters"/></summary>
	[TLDef(0x3504914F)]
	public partial class UpdateDialogFilters : Update { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updatePhoneCallSignalingData"/></summary>
	[TLDef(0x2661BF09)]
	public partial class UpdatePhoneCallSignalingData : Update
	{
		public long phone_call_id;
		public byte[] data;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateChannelMessageForwards"/></summary>
	[TLDef(0xD29A27F4)]
	public partial class UpdateChannelMessageForwards : UpdateChannel
	{
		public int id;
		public int forwards;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateReadChannelDiscussionInbox"/></summary>
	[TLDef(0xD6B19546)]
	public partial class UpdateReadChannelDiscussionInbox : Update
	{
		[Flags] public enum Flags { has_broadcast_id = 0x1 }
		public Flags flags;
		public long channel_id;
		public int top_msg_id;
		public int read_max_id;
		[IfFlag(0)] public long broadcast_id;
		[IfFlag(0)] public int broadcast_post;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateReadChannelDiscussionOutbox"/></summary>
	[TLDef(0x695C9E7C)]
	public partial class UpdateReadChannelDiscussionOutbox : Update
	{
		public long channel_id;
		public int top_msg_id;
		public int read_max_id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updatePeerBlocked"/></summary>
	[TLDef(0x246A4B22)]
	public partial class UpdatePeerBlocked : Update
	{
		public Peer peer_id;
		public bool blocked;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateChannelUserTyping"/></summary>
	[TLDef(0x8C88C923)]
	public partial class UpdateChannelUserTyping : Update
	{
		[Flags] public enum Flags { has_top_msg_id = 0x1 }
		public Flags flags;
		public long channel_id;
		[IfFlag(0)] public int top_msg_id;
		public Peer from_id;
		public SendMessageAction action;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updatePinnedMessages"/></summary>
	[TLDef(0xED85EAB5)]
	public partial class UpdatePinnedMessages : Update
	{
		[Flags] public enum Flags { pinned = 0x1 }
		public Flags flags;
		public Peer peer;
		public int[] messages;
		public int pts;
		public int pts_count;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updatePinnedChannelMessages"/></summary>
	[TLDef(0x5BB98608)]
	public partial class UpdatePinnedChannelMessages : Update
	{
		[Flags] public enum Flags { pinned = 0x1 }
		public Flags flags;
		public long channel_id;
		public int[] messages;
		public int pts;
		public int pts_count;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateChat"/></summary>
	[TLDef(0xF89A6A4E)]
	public partial class UpdateChat : Update { public long chat_id; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateGroupCallParticipants"/></summary>
	[TLDef(0xF2EBDB4E)]
	public partial class UpdateGroupCallParticipants : Update
	{
		public InputGroupCall call;
		public GroupCallParticipant[] participants;
		public int version;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateGroupCall"/></summary>
	[TLDef(0x14B24500)]
	public partial class UpdateGroupCall : Update
	{
		public long chat_id;
		public GroupCallBase call;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updatePeerHistoryTTL"/></summary>
	[TLDef(0xBB9BB9A5)]
	public partial class UpdatePeerHistoryTTL : Update
	{
		[Flags] public enum Flags { has_ttl_period = 0x1 }
		public Flags flags;
		public Peer peer;
		[IfFlag(0)] public int ttl_period;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateChatParticipant"/></summary>
	[TLDef(0xD087663A)]
	public partial class UpdateChatParticipant : Update
	{
		[Flags] public enum Flags { has_prev_participant = 0x1, has_new_participant = 0x2, has_invite = 0x4 }
		public Flags flags;
		public long chat_id;
		public DateTime date;
		public long actor_id;
		public long user_id;
		[IfFlag(0)] public ChatParticipantBase prev_participant;
		[IfFlag(1)] public ChatParticipantBase new_participant;
		[IfFlag(2)] public ExportedChatInvite invite;
		public int qts;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateChannelParticipant"/></summary>
	[TLDef(0x985D3ABB)]
	public partial class UpdateChannelParticipant : Update
	{
		[Flags] public enum Flags { has_prev_participant = 0x1, has_new_participant = 0x2, has_invite = 0x4 }
		public Flags flags;
		public long channel_id;
		public DateTime date;
		public long actor_id;
		public long user_id;
		[IfFlag(0)] public ChannelParticipantBase prev_participant;
		[IfFlag(1)] public ChannelParticipantBase new_participant;
		[IfFlag(2)] public ExportedChatInvite invite;
		public int qts;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateBotStopped"/></summary>
	[TLDef(0xC4870A49)]
	public partial class UpdateBotStopped : Update
	{
		public long user_id;
		public DateTime date;
		public bool stopped;
		public int qts;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateGroupCallConnection"/></summary>
	[TLDef(0x0B783982)]
	public partial class UpdateGroupCallConnection : Update
	{
		[Flags] public enum Flags { presentation = 0x1 }
		public Flags flags;
		public DataJSON params_;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateBotCommands"/></summary>
	[TLDef(0x4D712F2E)]
	public partial class UpdateBotCommands : Update
	{
		public Peer peer;
		public long bot_id;
		public BotCommand[] commands;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/updates.state"/></summary>
	[TLDef(0xA56C2A3E)]
	public partial class Updates_State : ITLObject
	{
		public int pts;
		public int qts;
		public DateTime date;
		public int seq;
		public int unread_count;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/updates.Difference"/></summary>
	public abstract partial class Updates_DifferenceBase : ITLObject
	{
		public abstract MessageBase[] NewMessages { get; }
		public abstract EncryptedMessageBase[] NewEncryptedMessages { get; }
		public abstract Update[] OtherUpdates { get; }
		public abstract IPeerInfo UserOrChat(Peer peer);
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updates.differenceEmpty"/></summary>
	[TLDef(0x5D75A138)]
	public partial class Updates_DifferenceEmpty : Updates_DifferenceBase
	{
		public DateTime date;
		public int seq;

		public override MessageBase[] NewMessages => Array.Empty<MessageBase>();
		public override EncryptedMessageBase[] NewEncryptedMessages => Array.Empty<EncryptedMessageBase>();
		public override Update[] OtherUpdates => Array.Empty<Update>();
		public override IPeerInfo UserOrChat(Peer peer) => null;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updates.difference"/></summary>
	[TLDef(0x00F49CA0)]
	public partial class Updates_Difference : Updates_DifferenceBase
	{
		public MessageBase[] new_messages;
		public EncryptedMessageBase[] new_encrypted_messages;
		public Update[] other_updates;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;
		public Updates_State state;

		public override MessageBase[] NewMessages => new_messages;
		public override EncryptedMessageBase[] NewEncryptedMessages => new_encrypted_messages;
		public override Update[] OtherUpdates => other_updates;
		public override IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updates.differenceSlice"/></summary>
	[TLDef(0xA8FB1981)]
	public partial class Updates_DifferenceSlice : Updates_DifferenceBase
	{
		public MessageBase[] new_messages;
		public EncryptedMessageBase[] new_encrypted_messages;
		public Update[] other_updates;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;
		public Updates_State intermediate_state;

		public override MessageBase[] NewMessages => new_messages;
		public override EncryptedMessageBase[] NewEncryptedMessages => new_encrypted_messages;
		public override Update[] OtherUpdates => other_updates;
		public override IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updates.differenceTooLong"/></summary>
	[TLDef(0x4AFE8F6D)]
	public partial class Updates_DifferenceTooLong : Updates_DifferenceBase
	{
		public int pts;

		public override MessageBase[] NewMessages => default;
		public override EncryptedMessageBase[] NewEncryptedMessages => default;
		public override Update[] OtherUpdates => default;
		public override IPeerInfo UserOrChat(Peer peer) => null;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/Updates"/></summary>
	public abstract partial class UpdatesBase : ITLObject
	{
		public abstract DateTime Date { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updatesTooLong"/></summary>
	[TLDef(0xE317AF7E)]
	public partial class UpdatesTooLong : UpdatesBase
	{
		public override DateTime Date => default;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateShortMessage"/></summary>
	[TLDef(0x313BC7F8)]
	public partial class UpdateShortMessage : UpdatesBase
	{
		[Flags] public enum Flags { out_ = 0x2, has_fwd_from = 0x4, has_reply_to = 0x8, mentioned = 0x10, media_unread = 0x20, 
			has_entities = 0x80, has_via_bot_id = 0x800, silent = 0x2000, has_ttl_period = 0x2000000 }
		public Flags flags;
		public int id;
		public long user_id;
		public string message;
		public int pts;
		public int pts_count;
		public DateTime date;
		[IfFlag(2)] public MessageFwdHeader fwd_from;
		[IfFlag(11)] public long via_bot_id;
		[IfFlag(3)] public MessageReplyHeader reply_to;
		[IfFlag(7)] public MessageEntity[] entities;
		[IfFlag(25)] public int ttl_period;

		public override DateTime Date => date;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateShortChatMessage"/></summary>
	[TLDef(0x4D6DEEA5)]
	public partial class UpdateShortChatMessage : UpdatesBase
	{
		[Flags] public enum Flags { out_ = 0x2, has_fwd_from = 0x4, has_reply_to = 0x8, mentioned = 0x10, media_unread = 0x20, 
			has_entities = 0x80, has_via_bot_id = 0x800, silent = 0x2000, has_ttl_period = 0x2000000 }
		public Flags flags;
		public int id;
		public long from_id;
		public long chat_id;
		public string message;
		public int pts;
		public int pts_count;
		public DateTime date;
		[IfFlag(2)] public MessageFwdHeader fwd_from;
		[IfFlag(11)] public long via_bot_id;
		[IfFlag(3)] public MessageReplyHeader reply_to;
		[IfFlag(7)] public MessageEntity[] entities;
		[IfFlag(25)] public int ttl_period;

		public override DateTime Date => date;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateShort"/></summary>
	[TLDef(0x78D4DEC1)]
	public partial class UpdateShort : UpdatesBase
	{
		public Update update;
		public DateTime date;

		public override DateTime Date => date;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updatesCombined"/></summary>
	[TLDef(0x725B04C3)]
	public partial class UpdatesCombined : UpdatesBase
	{
		public Update[] updates;
		public Dictionary<long, UserBase> users;
		public Dictionary<long, ChatBase> chats;
		public DateTime date;
		public int seq_start;
		public int seq;

		public override DateTime Date => date;
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updates"/></summary>
	[TLDef(0x74AE4240)]
	public partial class Updates : UpdatesBase
	{
		public Update[] updates;
		public Dictionary<long, UserBase> users;
		public Dictionary<long, ChatBase> chats;
		public DateTime date;
		public int seq;

		public override DateTime Date => date;
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updateShortSentMessage"/></summary>
	[TLDef(0x9015E101)]
	public partial class UpdateShortSentMessage : UpdatesBase
	{
		[Flags] public enum Flags { out_ = 0x2, has_entities = 0x80, has_media = 0x200, has_ttl_period = 0x2000000 }
		public Flags flags;
		public int id;
		public int pts;
		public int pts_count;
		public DateTime date;
		[IfFlag(9)] public MessageMedia media;
		[IfFlag(7)] public MessageEntity[] entities;
		[IfFlag(25)] public int ttl_period;

		public override DateTime Date => date;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/photos.photos"/></summary>
	[TLDef(0x8DCA6AA5)]
	public partial class Photos_Photos : ITLObject
	{
		public PhotoBase[] photos;
		public Dictionary<long, UserBase> users;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/photos.photosSlice"/></summary>
	[TLDef(0x15051F54, inheritAfter = true)]
	public partial class Photos_PhotosSlice : Photos_Photos { public int count; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/photos.photo"/></summary>
	[TLDef(0x20212CA8)]
	public partial class Photos_Photo : ITLObject
	{
		public PhotoBase photo;
		public Dictionary<long, UserBase> users;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/upload.File"/></summary>
	public abstract partial class Upload_FileBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/upload.file"/></summary>
	[TLDef(0x096A18D5)]
	public partial class Upload_File : Upload_FileBase
	{
		public Storage_FileType type;
		public int mtime;
		public byte[] bytes;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/upload.fileCdnRedirect"/></summary>
	[TLDef(0xF18CDA44)]
	public partial class Upload_FileCdnRedirect : Upload_FileBase
	{
		public int dc_id;
		public byte[] file_token;
		public byte[] encryption_key;
		public byte[] encryption_iv;
		public FileHash[] file_hashes;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/dcOption"/></summary>
	[TLDef(0x18B7A10D)]
	public partial class DcOption : ITLObject
	{
		[Flags] public enum Flags { ipv6 = 0x1, media_only = 0x2, tcpo_only = 0x4, cdn = 0x8, static_ = 0x10, has_secret = 0x400 }
		public Flags flags;
		public int id;
		public string ip_address;
		public int port;
		[IfFlag(10)] public byte[] secret;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/config"/></summary>
	[TLDef(0x330B4067)]
	public partial class Config : ITLObject
	{
		[Flags] public enum Flags { has_tmp_sessions = 0x1, phonecalls_enabled = 0x2, has_suggested_lang_code = 0x4, 
			default_p2p_contacts = 0x8, preload_featured_stickers = 0x10, ignore_phone_entities = 0x20, revoke_pm_inbox = 0x40, 
			has_autoupdate_url_prefix = 0x80, blocked_mode = 0x100, has_gif_search_username = 0x200, has_venue_search_username = 0x400, 
			has_img_search_username = 0x800, has_static_maps_provider = 0x1000, pfs_enabled = 0x2000 }
		public Flags flags;
		public DateTime date;
		public DateTime expires;
		public bool test_mode;
		public int this_dc;
		public DcOption[] dc_options;
		public string dc_txt_domain_name;
		public int chat_size_max;
		public int megagroup_size_max;
		public int forwarded_count_max;
		public int online_update_period_ms;
		public int offline_blur_timeout_ms;
		public int offline_idle_timeout_ms;
		public int online_cloud_timeout_ms;
		public int notify_cloud_delay_ms;
		public int notify_default_delay_ms;
		public int push_chat_period_ms;
		public int push_chat_limit;
		public int saved_gifs_limit;
		public int edit_time_limit;
		public int revoke_time_limit;
		public int revoke_pm_time_limit;
		public int rating_e_decay;
		public int stickers_recent_limit;
		public int stickers_faved_limit;
		public int channels_read_media_period;
		[IfFlag(0)] public int tmp_sessions;
		public int pinned_dialogs_count_max;
		public int pinned_infolder_count_max;
		public int call_receive_timeout_ms;
		public int call_ring_timeout_ms;
		public int call_connect_timeout_ms;
		public int call_packet_timeout_ms;
		public string me_url_prefix;
		[IfFlag(7)] public string autoupdate_url_prefix;
		[IfFlag(9)] public string gif_search_username;
		[IfFlag(10)] public string venue_search_username;
		[IfFlag(11)] public string img_search_username;
		[IfFlag(12)] public string static_maps_provider;
		public int caption_length_max;
		public int message_length_max;
		public int webfile_dc_id;
		[IfFlag(2)] public string suggested_lang_code;
		[IfFlag(2)] public int lang_pack_version;
		[IfFlag(2)] public int base_lang_pack_version;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/nearestDc"/></summary>
	[TLDef(0x8E1A1775)]
	public partial class NearestDc : ITLObject
	{
		public string country;
		public int this_dc;
		public int nearest_dc;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/help.appUpdate"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.noAppUpdate">help.noAppUpdate</a></remarks>
	[TLDef(0xCCBBCE30)]
	public partial class Help_AppUpdate : ITLObject
	{
		[Flags] public enum Flags { can_not_skip = 0x1, has_document = 0x2, has_url = 0x4, has_sticker = 0x8 }
		public Flags flags;
		public int id;
		public string version;
		public string text;
		public MessageEntity[] entities;
		[IfFlag(1)] public DocumentBase document;
		[IfFlag(2)] public string url;
		[IfFlag(3)] public DocumentBase sticker;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/help.inviteText"/></summary>
	[TLDef(0x18CB9F78)]
	public partial class Help_InviteText : ITLObject { public string message; }

	///<summary>See <a href="https://corefork.telegram.org/type/EncryptedChat"/></summary>
	public abstract partial class EncryptedChatBase : ITLObject
	{
		public abstract int ID { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/encryptedChatEmpty"/></summary>
	[TLDef(0xAB7EC0A0)]
	public partial class EncryptedChatEmpty : EncryptedChatBase
	{
		public int id;

		public override int ID => id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/encryptedChatWaiting"/></summary>
	[TLDef(0x66B25953)]
	public partial class EncryptedChatWaiting : EncryptedChatBase
	{
		public int id;
		public long access_hash;
		public DateTime date;
		public long admin_id;
		public long participant_id;

		public override int ID => id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/encryptedChatRequested"/></summary>
	[TLDef(0x48F1D94C)]
	public partial class EncryptedChatRequested : EncryptedChatBase
	{
		[Flags] public enum Flags { has_folder_id = 0x1 }
		public Flags flags;
		[IfFlag(0)] public int folder_id;
		public int id;
		public long access_hash;
		public DateTime date;
		public long admin_id;
		public long participant_id;
		public byte[] g_a;

		public override int ID => id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/encryptedChat"/></summary>
	[TLDef(0x61F0D4C7)]
	public partial class EncryptedChat : EncryptedChatBase
	{
		public int id;
		public long access_hash;
		public DateTime date;
		public long admin_id;
		public long participant_id;
		public byte[] g_a_or_b;
		public long key_fingerprint;

		public override int ID => id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/encryptedChatDiscarded"/></summary>
	[TLDef(0x1E1C7C45)]
	public partial class EncryptedChatDiscarded : EncryptedChatBase
	{
		[Flags] public enum Flags { history_deleted = 0x1 }
		public Flags flags;
		public int id;

		public override int ID => id;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/inputEncryptedChat"/></summary>
	[TLDef(0xF141B5E1)]
	public partial class InputEncryptedChat : ITLObject
	{
		public int chat_id;
		public long access_hash;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/encryptedFile"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/encryptedFileEmpty">encryptedFileEmpty</a></remarks>
	[TLDef(0x4A70994C)]
	public partial class EncryptedFile : ITLObject
	{
		public long id;
		public long access_hash;
		public int size;
		public int dc_id;
		public int key_fingerprint;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/InputEncryptedFile"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputEncryptedFileEmpty">inputEncryptedFileEmpty</a></remarks>
	public abstract partial class InputEncryptedFileBase : ITLObject
	{
		public abstract long ID { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputEncryptedFileUploaded"/></summary>
	[TLDef(0x64BD0306)]
	public partial class InputEncryptedFileUploaded : InputEncryptedFileBase
	{
		public long id;
		public int parts;
		public byte[] md5_checksum;
		public int key_fingerprint;

		public override long ID => id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputEncryptedFile"/></summary>
	[TLDef(0x5A17B5E5)]
	public partial class InputEncryptedFile : InputEncryptedFileBase
	{
		public long id;
		public long access_hash;

		public override long ID => id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputEncryptedFileBigUploaded"/></summary>
	[TLDef(0x2DC173C8)]
	public partial class InputEncryptedFileBigUploaded : InputEncryptedFileBase
	{
		public long id;
		public int parts;
		public int key_fingerprint;

		public override long ID => id;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/EncryptedMessage"/></summary>
	public abstract partial class EncryptedMessageBase : ITLObject
	{
		public abstract long RandomId { get; }
		public abstract int ChatId { get; }
		public abstract DateTime Date { get; }
		public abstract byte[] Bytes { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/encryptedMessage"/></summary>
	[TLDef(0xED18C118)]
	public partial class EncryptedMessage : EncryptedMessageBase
	{
		public long random_id;
		public int chat_id;
		public DateTime date;
		public byte[] bytes;
		public EncryptedFile file;

		public override long RandomId => random_id;
		public override int ChatId => chat_id;
		public override DateTime Date => date;
		public override byte[] Bytes => bytes;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/encryptedMessageService"/></summary>
	[TLDef(0x23734B06)]
	public partial class EncryptedMessageService : EncryptedMessageBase
	{
		public long random_id;
		public int chat_id;
		public DateTime date;
		public byte[] bytes;

		public override long RandomId => random_id;
		public override int ChatId => chat_id;
		public override DateTime Date => date;
		public override byte[] Bytes => bytes;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/messages.DhConfig"/></summary>
	public abstract partial class Messages_DhConfigBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.dhConfigNotModified"/></summary>
	[TLDef(0xC0E24635)]
	public partial class Messages_DhConfigNotModified : Messages_DhConfigBase { public byte[] random; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.dhConfig"/></summary>
	[TLDef(0x2C221EDD)]
	public partial class Messages_DhConfig : Messages_DhConfigBase
	{
		public int g;
		public byte[] p;
		public int version;
		public byte[] random;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.sentEncryptedMessage"/></summary>
	[TLDef(0x560F8935)]
	public partial class Messages_SentEncryptedMessage : ITLObject { public DateTime date; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.sentEncryptedFile"/></summary>
	[TLDef(0x9493FF32)]
	public partial class Messages_SentEncryptedFile : Messages_SentEncryptedMessage { public EncryptedFile file; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/inputDocument"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputDocumentEmpty">inputDocumentEmpty</a></remarks>
	[TLDef(0x1ABFB575)]
	public partial class InputDocument : ITLObject
	{
		public long id;
		public long access_hash;
		public byte[] file_reference;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/Document"/></summary>
	public abstract partial class DocumentBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/documentEmpty"/></summary>
	[TLDef(0x36F8C871)]
	public partial class DocumentEmpty : DocumentBase { public long id; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/document"/></summary>
	[TLDef(0x1E87342B)]
	public partial class Document : DocumentBase
	{
		[Flags] public enum Flags { has_thumbs = 0x1, has_video_thumbs = 0x2 }
		public Flags flags;
		public long id;
		public long access_hash;
		public byte[] file_reference;
		public DateTime date;
		public string mime_type;
		public int size;
		[IfFlag(0)] public PhotoSizeBase[] thumbs;
		[IfFlag(1)] public VideoSize[] video_thumbs;
		public int dc_id;
		public DocumentAttribute[] attributes;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/help.support"/></summary>
	[TLDef(0x17C6B5F6)]
	public partial class Help_Support : ITLObject
	{
		public string phone_number;
		public UserBase user;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/NotifyPeer"/></summary>
	public abstract partial class NotifyPeerBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/notifyPeer"/></summary>
	[TLDef(0x9FD40BD8)]
	public partial class NotifyPeer : NotifyPeerBase { public Peer peer; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/notifyUsers"/></summary>
	[TLDef(0xB4C83B4C)]
	public partial class NotifyUsers : NotifyPeerBase { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/notifyChats"/></summary>
	[TLDef(0xC007CEC3)]
	public partial class NotifyChats : NotifyPeerBase { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/notifyBroadcasts"/></summary>
	[TLDef(0xD612E8EF)]
	public partial class NotifyBroadcasts : NotifyPeerBase { }

	///<summary>See <a href="https://corefork.telegram.org/type/SendMessageAction"/></summary>
	public abstract partial class SendMessageAction : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/sendMessageTypingAction"/></summary>
	[TLDef(0x16BF744E)]
	public partial class SendMessageTypingAction : SendMessageAction { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/sendMessageCancelAction"/></summary>
	[TLDef(0xFD5EC8F5)]
	public partial class SendMessageCancelAction : SendMessageAction { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/sendMessageRecordVideoAction"/></summary>
	[TLDef(0xA187D66F)]
	public partial class SendMessageRecordVideoAction : SendMessageAction { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/sendMessageUploadVideoAction"/></summary>
	[TLDef(0xE9763AEC)]
	public partial class SendMessageUploadVideoAction : SendMessageAction { public int progress; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/sendMessageRecordAudioAction"/></summary>
	[TLDef(0xD52F73F7)]
	public partial class SendMessageRecordAudioAction : SendMessageAction { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/sendMessageUploadAudioAction"/></summary>
	[TLDef(0xF351D7AB)]
	public partial class SendMessageUploadAudioAction : SendMessageAction { public int progress; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/sendMessageUploadPhotoAction"/></summary>
	[TLDef(0xD1D34A26)]
	public partial class SendMessageUploadPhotoAction : SendMessageAction { public int progress; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/sendMessageUploadDocumentAction"/></summary>
	[TLDef(0xAA0CD9E4)]
	public partial class SendMessageUploadDocumentAction : SendMessageAction { public int progress; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/sendMessageGeoLocationAction"/></summary>
	[TLDef(0x176F8BA1)]
	public partial class SendMessageGeoLocationAction : SendMessageAction { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/sendMessageChooseContactAction"/></summary>
	[TLDef(0x628CBC6F)]
	public partial class SendMessageChooseContactAction : SendMessageAction { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/sendMessageGamePlayAction"/></summary>
	[TLDef(0xDD6A8F48)]
	public partial class SendMessageGamePlayAction : SendMessageAction { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/sendMessageRecordRoundAction"/></summary>
	[TLDef(0x88F27FBC)]
	public partial class SendMessageRecordRoundAction : SendMessageAction { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/sendMessageUploadRoundAction"/></summary>
	[TLDef(0x243E1C66)]
	public partial class SendMessageUploadRoundAction : SendMessageAction { public int progress; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/speakingInGroupCallAction"/></summary>
	[TLDef(0xD92C2285)]
	public partial class SpeakingInGroupCallAction : SendMessageAction { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/sendMessageHistoryImportAction"/></summary>
	[TLDef(0xDBDA9246)]
	public partial class SendMessageHistoryImportAction : SendMessageAction { public int progress; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/sendMessageChooseStickerAction"/></summary>
	[TLDef(0xB05AC6B1)]
	public partial class SendMessageChooseStickerAction : SendMessageAction { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/sendMessageEmojiInteraction"/></summary>
	[TLDef(0x6A3233B6)]
	public partial class SendMessageEmojiInteraction : SendMessageAction
	{
		public string emoticon;
		public DataJSON interaction;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/sendMessageEmojiInteractionSeen"/></summary>
	[TLDef(0xB665902E)]
	public partial class SendMessageEmojiInteractionSeen : SendMessageAction { public string emoticon; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/contacts.found"/></summary>
	[TLDef(0xB3134D9D)]
	public partial class Contacts_Found : ITLObject
	{
		public Peer[] my_results;
		public Peer[] results;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	///<summary>See <a href="https://corefork.telegram.org/type/InputPrivacyKey"/></summary>
	public enum InputPrivacyKey : uint
	{
		///<summary>See <a href="https://corefork.telegram.org/constructor/inputPrivacyKeyStatusTimestamp"/></summary>
		StatusTimestamp = 0x4F96CB18,
		///<summary>See <a href="https://corefork.telegram.org/constructor/inputPrivacyKeyChatInvite"/></summary>
		ChatInvite = 0xBDFB0426,
		///<summary>See <a href="https://corefork.telegram.org/constructor/inputPrivacyKeyPhoneCall"/></summary>
		PhoneCall = 0xFABADC5F,
		///<summary>See <a href="https://corefork.telegram.org/constructor/inputPrivacyKeyPhoneP2P"/></summary>
		PhoneP2P = 0xDB9E70D2,
		///<summary>See <a href="https://corefork.telegram.org/constructor/inputPrivacyKeyForwards"/></summary>
		Forwards = 0xA4DD4C08,
		///<summary>See <a href="https://corefork.telegram.org/constructor/inputPrivacyKeyProfilePhoto"/></summary>
		ProfilePhoto = 0x5719BACC,
		///<summary>See <a href="https://corefork.telegram.org/constructor/inputPrivacyKeyPhoneNumber"/></summary>
		PhoneNumber = 0x0352DAFA,
		///<summary>See <a href="https://corefork.telegram.org/constructor/inputPrivacyKeyAddedByPhone"/></summary>
		AddedByPhone = 0xD1219BDD,
	}

	///<summary>See <a href="https://corefork.telegram.org/type/PrivacyKey"/></summary>
	public enum PrivacyKey : uint
	{
		///<summary>See <a href="https://corefork.telegram.org/constructor/privacyKeyStatusTimestamp"/></summary>
		StatusTimestamp = 0xBC2EAB30,
		///<summary>See <a href="https://corefork.telegram.org/constructor/privacyKeyChatInvite"/></summary>
		ChatInvite = 0x500E6DFA,
		///<summary>See <a href="https://corefork.telegram.org/constructor/privacyKeyPhoneCall"/></summary>
		PhoneCall = 0x3D662B7B,
		///<summary>See <a href="https://corefork.telegram.org/constructor/privacyKeyPhoneP2P"/></summary>
		PhoneP2P = 0x39491CC8,
		///<summary>See <a href="https://corefork.telegram.org/constructor/privacyKeyForwards"/></summary>
		Forwards = 0x69EC56A3,
		///<summary>See <a href="https://corefork.telegram.org/constructor/privacyKeyProfilePhoto"/></summary>
		ProfilePhoto = 0x96151FED,
		///<summary>See <a href="https://corefork.telegram.org/constructor/privacyKeyPhoneNumber"/></summary>
		PhoneNumber = 0xD19AE46D,
		///<summary>See <a href="https://corefork.telegram.org/constructor/privacyKeyAddedByPhone"/></summary>
		AddedByPhone = 0x42FFD42B,
	}

	///<summary>See <a href="https://corefork.telegram.org/type/InputPrivacyRule"/></summary>
	public abstract partial class InputPrivacyRule : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputPrivacyValueAllowContacts"/></summary>
	[TLDef(0x0D09E07B)]
	public partial class InputPrivacyValueAllowContacts : InputPrivacyRule { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputPrivacyValueAllowAll"/></summary>
	[TLDef(0x184B35CE)]
	public partial class InputPrivacyValueAllowAll : InputPrivacyRule { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputPrivacyValueAllowUsers"/></summary>
	[TLDef(0x131CC67F)]
	public partial class InputPrivacyValueAllowUsers : InputPrivacyRule { public InputUserBase[] users; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputPrivacyValueDisallowContacts"/></summary>
	[TLDef(0x0BA52007)]
	public partial class InputPrivacyValueDisallowContacts : InputPrivacyRule { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputPrivacyValueDisallowAll"/></summary>
	[TLDef(0xD66B66C9)]
	public partial class InputPrivacyValueDisallowAll : InputPrivacyRule { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputPrivacyValueDisallowUsers"/></summary>
	[TLDef(0x90110467)]
	public partial class InputPrivacyValueDisallowUsers : InputPrivacyRule { public InputUserBase[] users; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputPrivacyValueAllowChatParticipants"/></summary>
	[TLDef(0x840649CF)]
	public partial class InputPrivacyValueAllowChatParticipants : InputPrivacyRule { public long[] chats; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputPrivacyValueDisallowChatParticipants"/></summary>
	[TLDef(0xE94F0F86)]
	public partial class InputPrivacyValueDisallowChatParticipants : InputPrivacyRule { public long[] chats; }

	///<summary>See <a href="https://corefork.telegram.org/type/PrivacyRule"/></summary>
	public abstract partial class PrivacyRule : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/privacyValueAllowContacts"/></summary>
	[TLDef(0xFFFE1BAC)]
	public partial class PrivacyValueAllowContacts : PrivacyRule { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/privacyValueAllowAll"/></summary>
	[TLDef(0x65427B82)]
	public partial class PrivacyValueAllowAll : PrivacyRule { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/privacyValueAllowUsers"/></summary>
	[TLDef(0xB8905FB2)]
	public partial class PrivacyValueAllowUsers : PrivacyRule { public long[] users; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/privacyValueDisallowContacts"/></summary>
	[TLDef(0xF888FA1A)]
	public partial class PrivacyValueDisallowContacts : PrivacyRule { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/privacyValueDisallowAll"/></summary>
	[TLDef(0x8B73E763)]
	public partial class PrivacyValueDisallowAll : PrivacyRule { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/privacyValueDisallowUsers"/></summary>
	[TLDef(0xE4621141)]
	public partial class PrivacyValueDisallowUsers : PrivacyRule { public long[] users; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/privacyValueAllowChatParticipants"/></summary>
	[TLDef(0x6B134E8E)]
	public partial class PrivacyValueAllowChatParticipants : PrivacyRule { public long[] chats; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/privacyValueDisallowChatParticipants"/></summary>
	[TLDef(0x41C87565)]
	public partial class PrivacyValueDisallowChatParticipants : PrivacyRule { public long[] chats; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/account.privacyRules"/></summary>
	[TLDef(0x50A04E45)]
	public partial class Account_PrivacyRules : ITLObject
	{
		public PrivacyRule[] rules;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/accountDaysTTL"/></summary>
	[TLDef(0xB8D0AFDF)]
	public partial class AccountDaysTTL : ITLObject { public int days; }

	///<summary>See <a href="https://corefork.telegram.org/type/DocumentAttribute"/></summary>
	public abstract partial class DocumentAttribute : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/documentAttributeImageSize"/></summary>
	[TLDef(0x6C37C15C)]
	public partial class DocumentAttributeImageSize : DocumentAttribute
	{
		public int w;
		public int h;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/documentAttributeAnimated"/></summary>
	[TLDef(0x11B58939)]
	public partial class DocumentAttributeAnimated : DocumentAttribute { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/documentAttributeSticker"/></summary>
	[TLDef(0x6319D612)]
	public partial class DocumentAttributeSticker : DocumentAttribute
	{
		[Flags] public enum Flags { has_mask_coords = 0x1, mask = 0x2 }
		public Flags flags;
		public string alt;
		public InputStickerSet stickerset;
		[IfFlag(0)] public MaskCoords mask_coords;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/documentAttributeVideo"/></summary>
	[TLDef(0x0EF02CE6)]
	public partial class DocumentAttributeVideo : DocumentAttribute
	{
		[Flags] public enum Flags { round_message = 0x1, supports_streaming = 0x2 }
		public Flags flags;
		public int duration;
		public int w;
		public int h;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/documentAttributeAudio"/></summary>
	[TLDef(0x9852F9C6)]
	public partial class DocumentAttributeAudio : DocumentAttribute
	{
		[Flags] public enum Flags { has_title = 0x1, has_performer = 0x2, has_waveform = 0x4, voice = 0x400 }
		public Flags flags;
		public int duration;
		[IfFlag(0)] public string title;
		[IfFlag(1)] public string performer;
		[IfFlag(2)] public byte[] waveform;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/documentAttributeFilename"/></summary>
	[TLDef(0x15590068)]
	public partial class DocumentAttributeFilename : DocumentAttribute { public string file_name; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/documentAttributeHasStickers"/></summary>
	[TLDef(0x9801D2F7)]
	public partial class DocumentAttributeHasStickers : DocumentAttribute { }

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.stickers"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.stickersNotModified">messages.stickersNotModified</a></remarks>
	[TLDef(0x30A6EC7E)]
	public partial class Messages_Stickers : ITLObject
	{
		public long hash;
		public DocumentBase[] stickers;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/stickerPack"/></summary>
	[TLDef(0x12B299D4)]
	public partial class StickerPack : ITLObject
	{
		public string emoticon;
		public long[] documents;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.allStickers"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.allStickersNotModified">messages.allStickersNotModified</a></remarks>
	[TLDef(0xCDBBCEBB)]
	public partial class Messages_AllStickers : ITLObject
	{
		public long hash;
		public StickerSet[] sets;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.affectedMessages"/></summary>
	[TLDef(0x84D19185)]
	public partial class Messages_AffectedMessages : ITLObject
	{
		public int pts;
		public int pts_count;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/WebPage"/></summary>
	public abstract partial class WebPageBase : ITLObject
	{
		public abstract long ID { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/webPageEmpty"/></summary>
	[TLDef(0xEB1477E8)]
	public partial class WebPageEmpty : WebPageBase
	{
		public long id;

		public override long ID => id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/webPagePending"/></summary>
	[TLDef(0xC586DA1C)]
	public partial class WebPagePending : WebPageBase
	{
		public long id;
		public DateTime date;

		public override long ID => id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/webPage"/></summary>
	[TLDef(0xE89C45B2)]
	public partial class WebPage : WebPageBase
	{
		[Flags] public enum Flags { has_type = 0x1, has_site_name = 0x2, has_title = 0x4, has_description = 0x8, has_photo = 0x10, 
			has_embed_url = 0x20, has_embed_width = 0x40, has_duration = 0x80, has_author = 0x100, has_document = 0x200, 
			has_cached_page = 0x400, has_attributes = 0x1000 }
		public Flags flags;
		public long id;
		public string url;
		public string display_url;
		public int hash;
		[IfFlag(0)] public string type;
		[IfFlag(1)] public string site_name;
		[IfFlag(2)] public string title;
		[IfFlag(3)] public string description;
		[IfFlag(4)] public PhotoBase photo;
		[IfFlag(5)] public string embed_url;
		[IfFlag(5)] public string embed_type;
		[IfFlag(6)] public int embed_width;
		[IfFlag(6)] public int embed_height;
		[IfFlag(7)] public int duration;
		[IfFlag(8)] public string author;
		[IfFlag(9)] public DocumentBase document;
		[IfFlag(10)] public Page cached_page;
		[IfFlag(12)] public WebPageAttribute[] attributes;

		public override long ID => id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/webPageNotModified"/></summary>
	[TLDef(0x7311CA11)]
	public partial class WebPageNotModified : WebPageBase
	{
		[Flags] public enum Flags { has_cached_page_views = 0x1 }
		public Flags flags;
		[IfFlag(0)] public int cached_page_views;

		public override long ID => default;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/authorization"/></summary>
	[TLDef(0xAD01D61D)]
	public partial class Authorization : ITLObject
	{
		[Flags] public enum Flags { current = 0x1, official_app = 0x2, password_pending = 0x4 }
		public Flags flags;
		public long hash;
		public string device_model;
		public string platform;
		public string system_version;
		public int api_id;
		public string app_name;
		public string app_version;
		public int date_created;
		public int date_active;
		public string ip;
		public string country;
		public string region;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/account.authorizations"/></summary>
	[TLDef(0x1250ABDE)]
	public partial class Account_Authorizations : ITLObject { public Authorization[] authorizations; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/account.password"/></summary>
	[TLDef(0x185B184F)]
	public partial class Account_Password : ITLObject
	{
		[Flags] public enum Flags { has_recovery = 0x1, has_secure_values = 0x2, has_password = 0x4, has_hint = 0x8, 
			has_email_unconfirmed_pattern = 0x10, has_pending_reset_date = 0x20 }
		public Flags flags;
		[IfFlag(2)] public PasswordKdfAlgo current_algo;
		[IfFlag(2)] public byte[] srp_B;
		[IfFlag(2)] public long srp_id;
		[IfFlag(3)] public string hint;
		[IfFlag(4)] public string email_unconfirmed_pattern;
		public PasswordKdfAlgo new_algo;
		public SecurePasswordKdfAlgo new_secure_algo;
		public byte[] secure_random;
		[IfFlag(5)] public DateTime pending_reset_date;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/account.passwordSettings"/></summary>
	[TLDef(0x9A5C33E5)]
	public partial class Account_PasswordSettings : ITLObject
	{
		[Flags] public enum Flags { has_email = 0x1, has_secure_settings = 0x2 }
		public Flags flags;
		[IfFlag(0)] public string email;
		[IfFlag(1)] public SecureSecretSettings secure_settings;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/account.passwordInputSettings"/></summary>
	[TLDef(0xC23727C9)]
	public partial class Account_PasswordInputSettings : ITLObject
	{
		[Flags] public enum Flags { has_new_algo = 0x1, has_email = 0x2, has_new_secure_settings = 0x4 }
		public Flags flags;
		[IfFlag(0)] public PasswordKdfAlgo new_algo;
		[IfFlag(0)] public byte[] new_password_hash;
		[IfFlag(0)] public string hint;
		[IfFlag(1)] public string email;
		[IfFlag(2)] public SecureSecretSettings new_secure_settings;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/auth.passwordRecovery"/></summary>
	[TLDef(0x137948A5)]
	public partial class Auth_PasswordRecovery : ITLObject { public string email_pattern; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/receivedNotifyMessage"/></summary>
	[TLDef(0xA384B779)]
	public partial class ReceivedNotifyMessage : ITLObject
	{
		public int id;
		public int flags;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/ExportedChatInvite"/></summary>
	public abstract partial class ExportedChatInvite : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/chatInviteExported"/></summary>
	[TLDef(0xB18105E8)]
	public partial class ChatInviteExported : ExportedChatInvite
	{
		[Flags] public enum Flags { revoked = 0x1, has_expire_date = 0x2, has_usage_limit = 0x4, has_usage = 0x8, 
			has_start_date = 0x10, permanent = 0x20 }
		public Flags flags;
		public string link;
		public long admin_id;
		public DateTime date;
		[IfFlag(4)] public DateTime start_date;
		[IfFlag(1)] public DateTime expire_date;
		[IfFlag(2)] public int usage_limit;
		[IfFlag(3)] public int usage;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/ChatInvite"/></summary>
	public abstract partial class ChatInviteBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/chatInviteAlready"/></summary>
	[TLDef(0x5A686D7C)]
	public partial class ChatInviteAlready : ChatInviteBase { public ChatBase chat; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/chatInvite"/></summary>
	[TLDef(0xDFC2F58E)]
	public partial class ChatInvite : ChatInviteBase
	{
		[Flags] public enum Flags { channel = 0x1, broadcast = 0x2, public_ = 0x4, megagroup = 0x8, has_participants = 0x10 }
		public Flags flags;
		public string title;
		public PhotoBase photo;
		public int participants_count;
		[IfFlag(4)] public UserBase[] participants;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/chatInvitePeek"/></summary>
	[TLDef(0x61695CB0)]
	public partial class ChatInvitePeek : ChatInviteBase
	{
		public ChatBase chat;
		public DateTime expires;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/InputStickerSet"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputStickerSetEmpty">inputStickerSetEmpty</a></remarks>
	public abstract partial class InputStickerSet : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputStickerSetID"/></summary>
	[TLDef(0x9DE7A269)]
	public partial class InputStickerSetID : InputStickerSet
	{
		public long id;
		public long access_hash;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputStickerSetShortName"/></summary>
	[TLDef(0x861CC8A0)]
	public partial class InputStickerSetShortName : InputStickerSet { public string short_name; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputStickerSetAnimatedEmoji"/></summary>
	[TLDef(0x028703C8)]
	public partial class InputStickerSetAnimatedEmoji : InputStickerSet { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputStickerSetDice"/></summary>
	[TLDef(0xE67F520E)]
	public partial class InputStickerSetDice : InputStickerSet { public string emoticon; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/stickerSet"/></summary>
	[TLDef(0xD7DF217A)]
	public partial class StickerSet : ITLObject
	{
		[Flags] public enum Flags { has_installed_date = 0x1, archived = 0x2, official = 0x4, masks = 0x8, has_thumbs = 0x10, 
			animated = 0x20 }
		public Flags flags;
		[IfFlag(0)] public DateTime installed_date;
		public long id;
		public long access_hash;
		public string title;
		public string short_name;
		[IfFlag(4)] public PhotoSizeBase[] thumbs;
		[IfFlag(4)] public int thumb_dc_id;
		[IfFlag(4)] public int thumb_version;
		public int count;
		public int hash;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.stickerSet"/></summary>
	[TLDef(0xB60A24A6)]
	public partial class Messages_StickerSet : ITLObject
	{
		public StickerSet set;
		public StickerPack[] packs;
		public DocumentBase[] documents;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/botCommand"/></summary>
	[TLDef(0xC27AC8C7)]
	public partial class BotCommand : ITLObject
	{
		public string command;
		public string description;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/botInfo"/></summary>
	[TLDef(0x1B74B335)]
	public partial class BotInfo : ITLObject
	{
		public long user_id;
		public string description;
		public BotCommand[] commands;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/KeyboardButton"/></summary>
	public abstract partial class KeyboardButtonBase : ITLObject
	{
		public abstract string Text { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/keyboardButton"/></summary>
	[TLDef(0xA2FA4880)]
	public partial class KeyboardButton : KeyboardButtonBase
	{
		public string text;

		public override string Text => text;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/keyboardButtonUrl"/></summary>
	[TLDef(0x258AFF05)]
	public partial class KeyboardButtonUrl : KeyboardButton
	{
		public string url;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/keyboardButtonCallback"/></summary>
	[TLDef(0x35BBDB6B)]
	public partial class KeyboardButtonCallback : KeyboardButtonBase
	{
		[Flags] public enum Flags { requires_password = 0x1 }
		public Flags flags;
		public string text;
		public byte[] data;

		public override string Text => text;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/keyboardButtonRequestPhone"/></summary>
	[TLDef(0xB16A6C29)]
	public partial class KeyboardButtonRequestPhone : KeyboardButton
	{
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/keyboardButtonRequestGeoLocation"/></summary>
	[TLDef(0xFC796B3F)]
	public partial class KeyboardButtonRequestGeoLocation : KeyboardButton
	{
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/keyboardButtonSwitchInline"/></summary>
	[TLDef(0x0568A748)]
	public partial class KeyboardButtonSwitchInline : KeyboardButtonBase
	{
		[Flags] public enum Flags { same_peer = 0x1 }
		public Flags flags;
		public string text;
		public string query;

		public override string Text => text;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/keyboardButtonGame"/></summary>
	[TLDef(0x50F41CCF)]
	public partial class KeyboardButtonGame : KeyboardButton
	{
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/keyboardButtonBuy"/></summary>
	[TLDef(0xAFD93FBB)]
	public partial class KeyboardButtonBuy : KeyboardButton
	{
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/keyboardButtonUrlAuth"/></summary>
	[TLDef(0x10B78D29)]
	public partial class KeyboardButtonUrlAuth : KeyboardButtonBase
	{
		[Flags] public enum Flags { has_fwd_text = 0x1 }
		public Flags flags;
		public string text;
		[IfFlag(0)] public string fwd_text;
		public string url;
		public int button_id;

		public override string Text => text;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputKeyboardButtonUrlAuth"/></summary>
	[TLDef(0xD02E7FD4)]
	public partial class InputKeyboardButtonUrlAuth : KeyboardButtonBase
	{
		[Flags] public enum Flags { request_write_access = 0x1, has_fwd_text = 0x2 }
		public Flags flags;
		public string text;
		[IfFlag(1)] public string fwd_text;
		public string url;
		public InputUserBase bot;

		public override string Text => text;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/keyboardButtonRequestPoll"/></summary>
	[TLDef(0xBBC7515D, inheritAfter = true)]
	public partial class KeyboardButtonRequestPoll : KeyboardButton
	{
		[Flags] public enum Flags { has_quiz = 0x1 }
		public Flags flags;
		[IfFlag(0)] public bool quiz;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/keyboardButtonRow"/></summary>
	[TLDef(0x77608B83)]
	public partial class KeyboardButtonRow : ITLObject { public KeyboardButtonBase[] buttons; }

	///<summary>See <a href="https://corefork.telegram.org/type/ReplyMarkup"/></summary>
	public abstract partial class ReplyMarkup : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/replyKeyboardHide"/></summary>
	[TLDef(0xA03E5B85)]
	public partial class ReplyKeyboardHide : ReplyMarkup
	{
		[Flags] public enum Flags { selective = 0x4 }
		public Flags flags;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/replyKeyboardForceReply"/></summary>
	[TLDef(0x86B40B08)]
	public partial class ReplyKeyboardForceReply : ReplyMarkup
	{
		[Flags] public enum Flags { single_use = 0x2, selective = 0x4, has_placeholder = 0x8 }
		public Flags flags;
		[IfFlag(3)] public string placeholder;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/replyKeyboardMarkup"/></summary>
	[TLDef(0x85DD99D1)]
	public partial class ReplyKeyboardMarkup : ReplyMarkup
	{
		[Flags] public enum Flags { resize = 0x1, single_use = 0x2, selective = 0x4, has_placeholder = 0x8 }
		public Flags flags;
		public KeyboardButtonRow[] rows;
		[IfFlag(3)] public string placeholder;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/replyInlineMarkup"/></summary>
	[TLDef(0x48A30254)]
	public partial class ReplyInlineMarkup : ReplyMarkup { public KeyboardButtonRow[] rows; }

	///<summary>See <a href="https://corefork.telegram.org/type/MessageEntity"/></summary>
	public abstract partial class MessageEntity : ITLObject
	{
		public int offset;
		public int length;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageEntityUnknown"/></summary>
	[TLDef(0xBB92BA95)]
	public partial class MessageEntityUnknown : MessageEntity { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageEntityMention"/></summary>
	[TLDef(0xFA04579D)]
	public partial class MessageEntityMention : MessageEntity { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageEntityHashtag"/></summary>
	[TLDef(0x6F635B0D)]
	public partial class MessageEntityHashtag : MessageEntity { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageEntityBotCommand"/></summary>
	[TLDef(0x6CEF8AC7)]
	public partial class MessageEntityBotCommand : MessageEntity { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageEntityUrl"/></summary>
	[TLDef(0x6ED02538)]
	public partial class MessageEntityUrl : MessageEntity { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageEntityEmail"/></summary>
	[TLDef(0x64E475C2)]
	public partial class MessageEntityEmail : MessageEntity { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageEntityBold"/></summary>
	[TLDef(0xBD610BC9)]
	public partial class MessageEntityBold : MessageEntity { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageEntityItalic"/></summary>
	[TLDef(0x826F8B60)]
	public partial class MessageEntityItalic : MessageEntity { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageEntityCode"/></summary>
	[TLDef(0x28A20571)]
	public partial class MessageEntityCode : MessageEntity { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageEntityPre"/></summary>
	[TLDef(0x73924BE0)]
	public partial class MessageEntityPre : MessageEntity { public string language; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageEntityTextUrl"/></summary>
	[TLDef(0x76A6D327)]
	public partial class MessageEntityTextUrl : MessageEntity { public string url; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageEntityMentionName"/></summary>
	[TLDef(0xDC7B1140)]
	public partial class MessageEntityMentionName : MessageEntity { public long user_id; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMessageEntityMentionName"/></summary>
	[TLDef(0x208E68C9)]
	public partial class InputMessageEntityMentionName : MessageEntity { public InputUserBase user_id; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageEntityPhone"/></summary>
	[TLDef(0x9B69E34B)]
	public partial class MessageEntityPhone : MessageEntity { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageEntityCashtag"/></summary>
	[TLDef(0x4C4E743F)]
	public partial class MessageEntityCashtag : MessageEntity { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageEntityUnderline"/></summary>
	[TLDef(0x9C4E7E8B)]
	public partial class MessageEntityUnderline : MessageEntity { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageEntityStrike"/></summary>
	[TLDef(0xBF0693D4)]
	public partial class MessageEntityStrike : MessageEntity { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageEntityBlockquote"/></summary>
	[TLDef(0x020DF5D0)]
	public partial class MessageEntityBlockquote : MessageEntity { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageEntityBankCard"/></summary>
	[TLDef(0x761E6AF4)]
	public partial class MessageEntityBankCard : MessageEntity { }

	///<summary>See <a href="https://corefork.telegram.org/type/InputChannel"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputChannelEmpty">inputChannelEmpty</a></remarks>
	public abstract partial class InputChannelBase : ITLObject
	{
		public abstract long ChannelId { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputChannel"/></summary>
	[TLDef(0xF35AEC28)]
	public partial class InputChannel : InputChannelBase
	{
		public long channel_id;
		public long access_hash;

		public override long ChannelId => channel_id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputChannelFromMessage"/></summary>
	[TLDef(0x5B934F9D)]
	public partial class InputChannelFromMessage : InputChannelBase
	{
		public InputPeer peer;
		public int msg_id;
		public long channel_id;

		public override long ChannelId => channel_id;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/contacts.resolvedPeer"/></summary>
	[TLDef(0x7F077AD9)]
	public partial class Contacts_ResolvedPeer : ITLObject
	{
		public Peer peer;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;
		public IPeerInfo UserOrChat => peer.UserOrChat(users, chats);
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messageRange"/></summary>
	[TLDef(0x0AE30253)]
	public partial class MessageRange : ITLObject
	{
		public int min_id;
		public int max_id;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/updates.ChannelDifference"/></summary>
	public abstract partial class Updates_ChannelDifferenceBase : ITLObject
	{
		public abstract IPeerInfo UserOrChat(Peer peer);
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updates.channelDifferenceEmpty"/></summary>
	[TLDef(0x3E11AFFB)]
	public partial class Updates_ChannelDifferenceEmpty : Updates_ChannelDifferenceBase
	{
		[Flags] public enum Flags { final = 0x1, has_timeout = 0x2 }
		public Flags flags;
		public int pts;
		[IfFlag(1)] public int timeout;
		public override IPeerInfo UserOrChat(Peer peer) => null;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updates.channelDifferenceTooLong"/></summary>
	[TLDef(0xA4BCC6FE)]
	public partial class Updates_ChannelDifferenceTooLong : Updates_ChannelDifferenceBase
	{
		[Flags] public enum Flags { final = 0x1, has_timeout = 0x2 }
		public Flags flags;
		[IfFlag(1)] public int timeout;
		public DialogBase dialog;
		public MessageBase[] messages;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;
		public override IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/updates.channelDifference"/></summary>
	[TLDef(0x2064674E)]
	public partial class Updates_ChannelDifference : Updates_ChannelDifferenceBase
	{
		[Flags] public enum Flags { final = 0x1, has_timeout = 0x2 }
		public Flags flags;
		public int pts;
		[IfFlag(1)] public int timeout;
		public MessageBase[] new_messages;
		public Update[] other_updates;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;
		public override IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/channelMessagesFilter"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/channelMessagesFilterEmpty">channelMessagesFilterEmpty</a></remarks>
	[TLDef(0xCD77D957)]
	public partial class ChannelMessagesFilter : ITLObject
	{
		[Flags] public enum Flags { exclude_new_messages = 0x2 }
		public Flags flags;
		public MessageRange[] ranges;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/ChannelParticipant"/></summary>
	public abstract partial class ChannelParticipantBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelParticipant"/></summary>
	[TLDef(0xC00C07C0)]
	public partial class ChannelParticipant : ChannelParticipantBase
	{
		public long user_id;
		public DateTime date;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelParticipantSelf"/></summary>
	[TLDef(0x28A8BC67)]
	public partial class ChannelParticipantSelf : ChannelParticipantBase
	{
		public long user_id;
		public long inviter_id;
		public DateTime date;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelParticipantCreator"/></summary>
	[TLDef(0x2FE601D3)]
	public partial class ChannelParticipantCreator : ChannelParticipantBase
	{
		[Flags] public enum Flags { has_rank = 0x1 }
		public Flags flags;
		public long user_id;
		public ChatAdminRights admin_rights;
		[IfFlag(0)] public string rank;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelParticipantAdmin"/></summary>
	[TLDef(0x34C3BB53)]
	public partial class ChannelParticipantAdmin : ChannelParticipantBase
	{
		[Flags] public enum Flags { can_edit = 0x1, self = 0x2, has_rank = 0x4 }
		public Flags flags;
		public long user_id;
		[IfFlag(1)] public long inviter_id;
		public long promoted_by;
		public DateTime date;
		public ChatAdminRights admin_rights;
		[IfFlag(2)] public string rank;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelParticipantBanned"/></summary>
	[TLDef(0x6DF8014E)]
	public partial class ChannelParticipantBanned : ChannelParticipantBase
	{
		[Flags] public enum Flags { left = 0x1 }
		public Flags flags;
		public Peer peer;
		public long kicked_by;
		public DateTime date;
		public ChatBannedRights banned_rights;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelParticipantLeft"/></summary>
	[TLDef(0x1B03F006)]
	public partial class ChannelParticipantLeft : ChannelParticipantBase { public Peer peer; }

	///<summary>See <a href="https://corefork.telegram.org/type/ChannelParticipantsFilter"/></summary>
	public abstract partial class ChannelParticipantsFilter : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelParticipantsRecent"/></summary>
	[TLDef(0xDE3F3C79)]
	public partial class ChannelParticipantsRecent : ChannelParticipantsFilter { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelParticipantsAdmins"/></summary>
	[TLDef(0xB4608969)]
	public partial class ChannelParticipantsAdmins : ChannelParticipantsFilter { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelParticipantsKicked"/></summary>
	[TLDef(0xA3B54985)]
	public partial class ChannelParticipantsKicked : ChannelParticipantsFilter { public string q; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelParticipantsBots"/></summary>
	[TLDef(0xB0D1865B)]
	public partial class ChannelParticipantsBots : ChannelParticipantsFilter { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelParticipantsBanned"/></summary>
	[TLDef(0x1427A5E1)]
	public partial class ChannelParticipantsBanned : ChannelParticipantsFilter { public string q; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelParticipantsSearch"/></summary>
	[TLDef(0x0656AC4B)]
	public partial class ChannelParticipantsSearch : ChannelParticipantsFilter { public string q; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelParticipantsContacts"/></summary>
	[TLDef(0xBB6AE88D)]
	public partial class ChannelParticipantsContacts : ChannelParticipantsFilter { public string q; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelParticipantsMentions"/></summary>
	[TLDef(0xE04B5CEB)]
	public partial class ChannelParticipantsMentions : ChannelParticipantsFilter
	{
		[Flags] public enum Flags { has_q = 0x1, has_top_msg_id = 0x2 }
		public Flags flags;
		[IfFlag(0)] public string q;
		[IfFlag(1)] public int top_msg_id;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/channels.channelParticipants"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/channels.channelParticipantsNotModified">channels.channelParticipantsNotModified</a></remarks>
	[TLDef(0x9AB0FEAF)]
	public partial class Channels_ChannelParticipants : ITLObject
	{
		public int count;
		public ChannelParticipantBase[] participants;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/channels.channelParticipant"/></summary>
	[TLDef(0xDFB80317)]
	public partial class Channels_ChannelParticipant : ITLObject
	{
		public ChannelParticipantBase participant;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/help.termsOfService"/></summary>
	[TLDef(0x780A0310)]
	public partial class Help_TermsOfService : ITLObject
	{
		[Flags] public enum Flags { popup = 0x1, has_min_age_confirm = 0x2 }
		public Flags flags;
		public DataJSON id;
		public string text;
		public MessageEntity[] entities;
		[IfFlag(1)] public int min_age_confirm;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.savedGifs"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.savedGifsNotModified">messages.savedGifsNotModified</a></remarks>
	[TLDef(0x84A02A0D)]
	public partial class Messages_SavedGifs : ITLObject
	{
		public long hash;
		public DocumentBase[] gifs;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/InputBotInlineMessage"/></summary>
	public abstract partial class InputBotInlineMessage : ITLObject { public int flags; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputBotInlineMessageMediaAuto"/></summary>
	[TLDef(0x3380C786)]
	public partial class InputBotInlineMessageMediaAuto : InputBotInlineMessage
	{
		[Flags] public enum Flags { has_entities = 0x2, has_reply_markup = 0x4 }
		public string message;
		[IfFlag(1)] public MessageEntity[] entities;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputBotInlineMessageText"/></summary>
	[TLDef(0x3DCD7A87)]
	public partial class InputBotInlineMessageText : InputBotInlineMessage
	{
		[Flags] public enum Flags { no_webpage = 0x1, has_entities = 0x2, has_reply_markup = 0x4 }
		public string message;
		[IfFlag(1)] public MessageEntity[] entities;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputBotInlineMessageMediaGeo"/></summary>
	[TLDef(0x96929A85)]
	public partial class InputBotInlineMessageMediaGeo : InputBotInlineMessage
	{
		[Flags] public enum Flags { has_heading = 0x1, has_period = 0x2, has_reply_markup = 0x4, 
			has_proximity_notification_radius = 0x8 }
		public InputGeoPoint geo_point;
		[IfFlag(0)] public int heading;
		[IfFlag(1)] public int period;
		[IfFlag(3)] public int proximity_notification_radius;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputBotInlineMessageMediaVenue"/></summary>
	[TLDef(0x417BBF11)]
	public partial class InputBotInlineMessageMediaVenue : InputBotInlineMessage
	{
		[Flags] public enum Flags { has_reply_markup = 0x4 }
		public InputGeoPoint geo_point;
		public string title;
		public string address;
		public string provider;
		public string venue_id;
		public string venue_type;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputBotInlineMessageMediaContact"/></summary>
	[TLDef(0xA6EDBFFD)]
	public partial class InputBotInlineMessageMediaContact : InputBotInlineMessage
	{
		[Flags] public enum Flags { has_reply_markup = 0x4 }
		public string phone_number;
		public string first_name;
		public string last_name;
		public string vcard;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputBotInlineMessageGame"/></summary>
	[TLDef(0x4B425864)]
	public partial class InputBotInlineMessageGame : InputBotInlineMessage
	{
		[Flags] public enum Flags { has_reply_markup = 0x4 }
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputBotInlineMessageMediaInvoice"/></summary>
	[TLDef(0xD7E78225)]
	public partial class InputBotInlineMessageMediaInvoice : InputBotInlineMessage
	{
		[Flags] public enum Flags { has_photo = 0x1, has_reply_markup = 0x4 }
		public string title;
		public string description;
		[IfFlag(0)] public InputWebDocument photo;
		public Invoice invoice;
		public byte[] payload;
		public string provider;
		public DataJSON provider_data;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/InputBotInlineResult"/></summary>
	public abstract partial class InputBotInlineResultBase : ITLObject
	{
		public abstract string ID { get; }
		public abstract InputBotInlineMessage SendMessage { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputBotInlineResult"/></summary>
	[TLDef(0x88BF9319)]
	public partial class InputBotInlineResult : InputBotInlineResultBase
	{
		[Flags] public enum Flags { has_title = 0x2, has_description = 0x4, has_url = 0x8, has_thumb = 0x10, has_content = 0x20 }
		public Flags flags;
		public string id;
		public string type;
		[IfFlag(1)] public string title;
		[IfFlag(2)] public string description;
		[IfFlag(3)] public string url;
		[IfFlag(4)] public InputWebDocument thumb;
		[IfFlag(5)] public InputWebDocument content;
		public InputBotInlineMessage send_message;

		public override string ID => id;
		public override InputBotInlineMessage SendMessage => send_message;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputBotInlineResultPhoto"/></summary>
	[TLDef(0xA8D864A7)]
	public partial class InputBotInlineResultPhoto : InputBotInlineResultBase
	{
		public string id;
		public string type;
		public InputPhoto photo;
		public InputBotInlineMessage send_message;

		public override string ID => id;
		public override InputBotInlineMessage SendMessage => send_message;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputBotInlineResultDocument"/></summary>
	[TLDef(0xFFF8FDC4)]
	public partial class InputBotInlineResultDocument : InputBotInlineResultBase
	{
		[Flags] public enum Flags { has_title = 0x2, has_description = 0x4 }
		public Flags flags;
		public string id;
		public string type;
		[IfFlag(1)] public string title;
		[IfFlag(2)] public string description;
		public InputDocument document;
		public InputBotInlineMessage send_message;

		public override string ID => id;
		public override InputBotInlineMessage SendMessage => send_message;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputBotInlineResultGame"/></summary>
	[TLDef(0x4FA417F2)]
	public partial class InputBotInlineResultGame : InputBotInlineResultBase
	{
		public string id;
		public string short_name;
		public InputBotInlineMessage send_message;

		public override string ID => id;
		public override InputBotInlineMessage SendMessage => send_message;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/BotInlineMessage"/></summary>
	public abstract partial class BotInlineMessage : ITLObject { public int flags; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/botInlineMessageMediaAuto"/></summary>
	[TLDef(0x764CF810)]
	public partial class BotInlineMessageMediaAuto : BotInlineMessage
	{
		[Flags] public enum Flags { has_entities = 0x2, has_reply_markup = 0x4 }
		public string message;
		[IfFlag(1)] public MessageEntity[] entities;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/botInlineMessageText"/></summary>
	[TLDef(0x8C7F65E2)]
	public partial class BotInlineMessageText : BotInlineMessage
	{
		[Flags] public enum Flags { no_webpage = 0x1, has_entities = 0x2, has_reply_markup = 0x4 }
		public string message;
		[IfFlag(1)] public MessageEntity[] entities;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/botInlineMessageMediaGeo"/></summary>
	[TLDef(0x051846FD)]
	public partial class BotInlineMessageMediaGeo : BotInlineMessage
	{
		[Flags] public enum Flags { has_heading = 0x1, has_period = 0x2, has_reply_markup = 0x4, 
			has_proximity_notification_radius = 0x8 }
		public GeoPoint geo;
		[IfFlag(0)] public int heading;
		[IfFlag(1)] public int period;
		[IfFlag(3)] public int proximity_notification_radius;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/botInlineMessageMediaVenue"/></summary>
	[TLDef(0x8A86659C)]
	public partial class BotInlineMessageMediaVenue : BotInlineMessage
	{
		[Flags] public enum Flags { has_reply_markup = 0x4 }
		public GeoPoint geo;
		public string title;
		public string address;
		public string provider;
		public string venue_id;
		public string venue_type;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/botInlineMessageMediaContact"/></summary>
	[TLDef(0x18D1CDC2)]
	public partial class BotInlineMessageMediaContact : BotInlineMessage
	{
		[Flags] public enum Flags { has_reply_markup = 0x4 }
		public string phone_number;
		public string first_name;
		public string last_name;
		public string vcard;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/botInlineMessageMediaInvoice"/></summary>
	[TLDef(0x354A9B09)]
	public partial class BotInlineMessageMediaInvoice : BotInlineMessage
	{
		[Flags] public enum Flags { has_photo = 0x1, shipping_address_requested = 0x2, has_reply_markup = 0x4, test = 0x8 }
		public string title;
		public string description;
		[IfFlag(0)] public WebDocumentBase photo;
		public string currency;
		public long total_amount;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/BotInlineResult"/></summary>
	public abstract partial class BotInlineResultBase : ITLObject
	{
		public abstract string ID { get; }
		public abstract string Type { get; }
		public abstract BotInlineMessage SendMessage { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/botInlineResult"/></summary>
	[TLDef(0x11965F3A)]
	public partial class BotInlineResult : BotInlineResultBase
	{
		[Flags] public enum Flags { has_title = 0x2, has_description = 0x4, has_url = 0x8, has_thumb = 0x10, has_content = 0x20 }
		public Flags flags;
		public string id;
		public string type;
		[IfFlag(1)] public string title;
		[IfFlag(2)] public string description;
		[IfFlag(3)] public string url;
		[IfFlag(4)] public WebDocumentBase thumb;
		[IfFlag(5)] public WebDocumentBase content;
		public BotInlineMessage send_message;

		public override string ID => id;
		public override string Type => type;
		public override BotInlineMessage SendMessage => send_message;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/botInlineMediaResult"/></summary>
	[TLDef(0x17DB940B)]
	public partial class BotInlineMediaResult : BotInlineResultBase
	{
		[Flags] public enum Flags { has_photo = 0x1, has_document = 0x2, has_title = 0x4, has_description = 0x8 }
		public Flags flags;
		public string id;
		public string type;
		[IfFlag(0)] public PhotoBase photo;
		[IfFlag(1)] public DocumentBase document;
		[IfFlag(2)] public string title;
		[IfFlag(3)] public string description;
		public BotInlineMessage send_message;

		public override string ID => id;
		public override string Type => type;
		public override BotInlineMessage SendMessage => send_message;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.botResults"/></summary>
	[TLDef(0x947CA848)]
	public partial class Messages_BotResults : ITLObject
	{
		[Flags] public enum Flags { gallery = 0x1, has_next_offset = 0x2, has_switch_pm = 0x4 }
		public Flags flags;
		public long query_id;
		[IfFlag(1)] public string next_offset;
		[IfFlag(2)] public InlineBotSwitchPM switch_pm;
		public BotInlineResultBase[] results;
		public DateTime cache_time;
		public Dictionary<long, UserBase> users;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/exportedMessageLink"/></summary>
	[TLDef(0x5DAB1AF4)]
	public partial class ExportedMessageLink : ITLObject
	{
		public string link;
		public string html;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messageFwdHeader"/></summary>
	[TLDef(0x5F777DCE)]
	public partial class MessageFwdHeader : ITLObject
	{
		[Flags] public enum Flags { has_from_id = 0x1, has_channel_post = 0x4, has_post_author = 0x8, has_saved_from_peer = 0x10, 
			has_from_name = 0x20, has_psa_type = 0x40, imported = 0x80 }
		public Flags flags;
		[IfFlag(0)] public Peer from_id;
		[IfFlag(5)] public string from_name;
		public DateTime date;
		[IfFlag(2)] public int channel_post;
		[IfFlag(3)] public string post_author;
		[IfFlag(4)] public Peer saved_from_peer;
		[IfFlag(4)] public int saved_from_msg_id;
		[IfFlag(6)] public string psa_type;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/auth.CodeType"/></summary>
	public enum Auth_CodeType : uint
	{
		///<summary>See <a href="https://corefork.telegram.org/constructor/auth.codeTypeSms"/></summary>
		Sms = 0x72A3158C,
		///<summary>See <a href="https://corefork.telegram.org/constructor/auth.codeTypeCall"/></summary>
		Call = 0x741CD3E3,
		///<summary>See <a href="https://corefork.telegram.org/constructor/auth.codeTypeFlashCall"/></summary>
		FlashCall = 0x226CCEFB,
	}

	///<summary>See <a href="https://corefork.telegram.org/type/auth.SentCodeType"/></summary>
	public abstract partial class Auth_SentCodeType : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/auth.sentCodeTypeApp"/></summary>
	[TLDef(0x3DBB5986)]
	public partial class Auth_SentCodeTypeApp : Auth_SentCodeType { public int length; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/auth.sentCodeTypeSms"/></summary>
	[TLDef(0xC000BBA2)]
	public partial class Auth_SentCodeTypeSms : Auth_SentCodeType { public int length; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/auth.sentCodeTypeCall"/></summary>
	[TLDef(0x5353E5A7)]
	public partial class Auth_SentCodeTypeCall : Auth_SentCodeType { public int length; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/auth.sentCodeTypeFlashCall"/></summary>
	[TLDef(0xAB03C6D9)]
	public partial class Auth_SentCodeTypeFlashCall : Auth_SentCodeType { public string pattern; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.botCallbackAnswer"/></summary>
	[TLDef(0x36585EA4)]
	public partial class Messages_BotCallbackAnswer : ITLObject
	{
		[Flags] public enum Flags { has_message = 0x1, alert = 0x2, has_url_field = 0x4, has_url = 0x8, native_ui = 0x10 }
		public Flags flags;
		[IfFlag(0)] public string message;
		[IfFlag(2)] public string url;
		public DateTime cache_time;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.messageEditData"/></summary>
	[TLDef(0x26B5DDE6)]
	public partial class Messages_MessageEditData : ITLObject
	{
		[Flags] public enum Flags { caption = 0x1 }
		public Flags flags;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/InputBotInlineMessageID"/></summary>
	public abstract partial class InputBotInlineMessageIDBase : ITLObject
	{
		public abstract int DcId { get; }
		public abstract long AccessHash { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputBotInlineMessageID"/></summary>
	[TLDef(0x890C3D89)]
	public partial class InputBotInlineMessageID : InputBotInlineMessageIDBase
	{
		public int dc_id;
		public long id;
		public long access_hash;

		public override int DcId => dc_id;
		public override long AccessHash => access_hash;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputBotInlineMessageID64"/></summary>
	[TLDef(0xB6D915D7)]
	public partial class InputBotInlineMessageID64 : InputBotInlineMessageIDBase
	{
		public int dc_id;
		public long owner_id;
		public int id;
		public long access_hash;

		public override int DcId => dc_id;
		public override long AccessHash => access_hash;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/inlineBotSwitchPM"/></summary>
	[TLDef(0x3C20629F)]
	public partial class InlineBotSwitchPM : ITLObject
	{
		public string text;
		public string start_param;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.peerDialogs"/></summary>
	[TLDef(0x3371C354)]
	public partial class Messages_PeerDialogs : ITLObject
	{
		public DialogBase[] dialogs;
		public MessageBase[] messages;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;
		public Updates_State state;
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/topPeer"/></summary>
	[TLDef(0xEDCDC05B)]
	public partial class TopPeer : ITLObject
	{
		public Peer peer;
		public double rating;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/TopPeerCategory"/></summary>
	public enum TopPeerCategory : uint
	{
		///<summary>See <a href="https://corefork.telegram.org/constructor/topPeerCategoryBotsPM"/></summary>
		BotsPM = 0xAB661B5B,
		///<summary>See <a href="https://corefork.telegram.org/constructor/topPeerCategoryBotsInline"/></summary>
		BotsInline = 0x148677E2,
		///<summary>See <a href="https://corefork.telegram.org/constructor/topPeerCategoryCorrespondents"/></summary>
		Correspondents = 0x0637B7ED,
		///<summary>See <a href="https://corefork.telegram.org/constructor/topPeerCategoryGroups"/></summary>
		Groups = 0xBD17A14A,
		///<summary>See <a href="https://corefork.telegram.org/constructor/topPeerCategoryChannels"/></summary>
		Channels = 0x161D9628,
		///<summary>See <a href="https://corefork.telegram.org/constructor/topPeerCategoryPhoneCalls"/></summary>
		PhoneCalls = 0x1E76A78C,
		///<summary>See <a href="https://corefork.telegram.org/constructor/topPeerCategoryForwardUsers"/></summary>
		ForwardUsers = 0xA8406CA9,
		///<summary>See <a href="https://corefork.telegram.org/constructor/topPeerCategoryForwardChats"/></summary>
		ForwardChats = 0xFBEEC0F0,
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/topPeerCategoryPeers"/></summary>
	[TLDef(0xFB834291)]
	public partial class TopPeerCategoryPeers : ITLObject
	{
		public TopPeerCategory category;
		public int count;
		public TopPeer[] peers;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/contacts.TopPeers"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/contacts.topPeersNotModified">contacts.topPeersNotModified</a></remarks>
	public abstract partial class Contacts_TopPeersBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/contacts.topPeers"/></summary>
	[TLDef(0x70B772A8)]
	public partial class Contacts_TopPeers : Contacts_TopPeersBase
	{
		public TopPeerCategoryPeers[] categories;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/contacts.topPeersDisabled"/></summary>
	[TLDef(0xB52C939D)]
	public partial class Contacts_TopPeersDisabled : Contacts_TopPeersBase { }

	///<summary>See <a href="https://corefork.telegram.org/type/DraftMessage"/></summary>
	public abstract partial class DraftMessageBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/draftMessageEmpty"/></summary>
	[TLDef(0x1B0C841A)]
	public partial class DraftMessageEmpty : DraftMessageBase
	{
		[Flags] public enum Flags { has_date = 0x1 }
		public Flags flags;
		[IfFlag(0)] public DateTime date;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/draftMessage"/></summary>
	[TLDef(0xFD8E711F)]
	public partial class DraftMessage : DraftMessageBase
	{
		[Flags] public enum Flags { has_reply_to_msg_id = 0x1, no_webpage = 0x2, has_entities = 0x8 }
		public Flags flags;
		[IfFlag(0)] public int reply_to_msg_id;
		public string message;
		[IfFlag(3)] public MessageEntity[] entities;
		public DateTime date;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/messages.FeaturedStickers"/></summary>
	public abstract partial class Messages_FeaturedStickersBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.featuredStickersNotModified"/></summary>
	[TLDef(0xC6DC0C66)]
	public partial class Messages_FeaturedStickersNotModified : Messages_FeaturedStickersBase { public int count; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.featuredStickers"/></summary>
	[TLDef(0x84C02310)]
	public partial class Messages_FeaturedStickers : Messages_FeaturedStickersBase
	{
		public long hash;
		public int count;
		public StickerSetCoveredBase[] sets;
		public long[] unread;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.recentStickers"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.recentStickersNotModified">messages.recentStickersNotModified</a></remarks>
	[TLDef(0x88D37C56)]
	public partial class Messages_RecentStickers : ITLObject
	{
		public long hash;
		public StickerPack[] packs;
		public DocumentBase[] stickers;
		public int[] dates;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.archivedStickers"/></summary>
	[TLDef(0x4FCBA9C8)]
	public partial class Messages_ArchivedStickers : ITLObject
	{
		public int count;
		public StickerSetCoveredBase[] sets;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/messages.StickerSetInstallResult"/></summary>
	public abstract partial class Messages_StickerSetInstallResult : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.stickerSetInstallResultSuccess"/></summary>
	[TLDef(0x38641628)]
	public partial class Messages_StickerSetInstallResultSuccess : Messages_StickerSetInstallResult { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.stickerSetInstallResultArchive"/></summary>
	[TLDef(0x35E410A8)]
	public partial class Messages_StickerSetInstallResultArchive : Messages_StickerSetInstallResult { public StickerSetCoveredBase[] sets; }

	///<summary>See <a href="https://corefork.telegram.org/type/StickerSetCovered"/></summary>
	public abstract partial class StickerSetCoveredBase : ITLObject
	{
		public abstract StickerSet Set { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/stickerSetCovered"/></summary>
	[TLDef(0x6410A5D2)]
	public partial class StickerSetCovered : StickerSetCoveredBase
	{
		public StickerSet set;
		public DocumentBase cover;

		public override StickerSet Set => set;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/stickerSetMultiCovered"/></summary>
	[TLDef(0x3407E51B)]
	public partial class StickerSetMultiCovered : StickerSetCoveredBase
	{
		public StickerSet set;
		public DocumentBase[] covers;

		public override StickerSet Set => set;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/maskCoords"/></summary>
	[TLDef(0xAED6DBB2)]
	public partial class MaskCoords : ITLObject
	{
		public int n;
		public double x;
		public double y;
		public double zoom;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/InputStickeredMedia"/></summary>
	public abstract partial class InputStickeredMedia : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputStickeredMediaPhoto"/></summary>
	[TLDef(0x4A992157)]
	public partial class InputStickeredMediaPhoto : InputStickeredMedia { public InputPhoto id; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputStickeredMediaDocument"/></summary>
	[TLDef(0x0438865B)]
	public partial class InputStickeredMediaDocument : InputStickeredMedia { public InputDocument id; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/game"/></summary>
	[TLDef(0xBDF9653B)]
	public partial class Game : ITLObject
	{
		[Flags] public enum Flags { has_document = 0x1 }
		public Flags flags;
		public long id;
		public long access_hash;
		public string short_name;
		public string title;
		public string description;
		public PhotoBase photo;
		[IfFlag(0)] public DocumentBase document;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/InputGame"/></summary>
	public abstract partial class InputGame : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputGameID"/></summary>
	[TLDef(0x032C3E77)]
	public partial class InputGameID : InputGame
	{
		public long id;
		public long access_hash;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputGameShortName"/></summary>
	[TLDef(0xC331E80A)]
	public partial class InputGameShortName : InputGame
	{
		public InputUserBase bot_id;
		public string short_name;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/highScore"/></summary>
	[TLDef(0x73A379EB)]
	public partial class HighScore : ITLObject
	{
		public int pos;
		public long user_id;
		public int score;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.highScores"/></summary>
	[TLDef(0x9A3BFD99)]
	public partial class Messages_HighScores : ITLObject
	{
		public HighScore[] scores;
		public Dictionary<long, UserBase> users;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/RichText"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/textEmpty">textEmpty</a></remarks>
	public abstract partial class RichText : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/textPlain"/></summary>
	[TLDef(0x744694E0)]
	public partial class TextPlain : RichText { public string text; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/textBold"/></summary>
	[TLDef(0x6724ABC4)]
	public partial class TextBold : RichText { public RichText text; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/textItalic"/></summary>
	[TLDef(0xD912A59C)]
	public partial class TextItalic : RichText { public RichText text; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/textUnderline"/></summary>
	[TLDef(0xC12622C4)]
	public partial class TextUnderline : RichText { public RichText text; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/textStrike"/></summary>
	[TLDef(0x9BF8BB95)]
	public partial class TextStrike : RichText { public RichText text; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/textFixed"/></summary>
	[TLDef(0x6C3F19B9)]
	public partial class TextFixed : RichText { public RichText text; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/textUrl"/></summary>
	[TLDef(0x3C2884C1)]
	public partial class TextUrl : RichText
	{
		public RichText text;
		public string url;
		public long webpage_id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/textEmail"/></summary>
	[TLDef(0xDE5A0DD6)]
	public partial class TextEmail : RichText
	{
		public RichText text;
		public string email;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/textConcat"/></summary>
	[TLDef(0x7E6260D7)]
	public partial class TextConcat : RichText { public RichText[] texts; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/textSubscript"/></summary>
	[TLDef(0xED6A8504)]
	public partial class TextSubscript : RichText { public RichText text; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/textSuperscript"/></summary>
	[TLDef(0xC7FB5E01)]
	public partial class TextSuperscript : RichText { public RichText text; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/textMarked"/></summary>
	[TLDef(0x034B8621)]
	public partial class TextMarked : RichText { public RichText text; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/textPhone"/></summary>
	[TLDef(0x1CCB966A)]
	public partial class TextPhone : RichText
	{
		public RichText text;
		public string phone;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/textImage"/></summary>
	[TLDef(0x081CCF4F)]
	public partial class TextImage : RichText
	{
		public long document_id;
		public int w;
		public int h;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/textAnchor"/></summary>
	[TLDef(0x35553762)]
	public partial class TextAnchor : RichText
	{
		public RichText text;
		public string name;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/PageBlock"/></summary>
	public abstract partial class PageBlock : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockUnsupported"/></summary>
	[TLDef(0x13567E8A)]
	public partial class PageBlockUnsupported : PageBlock { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockTitle"/></summary>
	[TLDef(0x70ABC3FD)]
	public partial class PageBlockTitle : PageBlock { public RichText text; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockSubtitle"/></summary>
	[TLDef(0x8FFA9A1F)]
	public partial class PageBlockSubtitle : PageBlock { public RichText text; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockAuthorDate"/></summary>
	[TLDef(0xBAAFE5E0)]
	public partial class PageBlockAuthorDate : PageBlock
	{
		public RichText author;
		public DateTime published_date;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockHeader"/></summary>
	[TLDef(0xBFD064EC)]
	public partial class PageBlockHeader : PageBlock { public RichText text; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockSubheader"/></summary>
	[TLDef(0xF12BB6E1)]
	public partial class PageBlockSubheader : PageBlock { public RichText text; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockParagraph"/></summary>
	[TLDef(0x467A0766)]
	public partial class PageBlockParagraph : PageBlock { public RichText text; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockPreformatted"/></summary>
	[TLDef(0xC070D93E)]
	public partial class PageBlockPreformatted : PageBlock
	{
		public RichText text;
		public string language;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockFooter"/></summary>
	[TLDef(0x48870999)]
	public partial class PageBlockFooter : PageBlock { public RichText text; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockDivider"/></summary>
	[TLDef(0xDB20B188)]
	public partial class PageBlockDivider : PageBlock { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockAnchor"/></summary>
	[TLDef(0xCE0D37B0)]
	public partial class PageBlockAnchor : PageBlock { public string name; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockList"/></summary>
	[TLDef(0xE4E88011)]
	public partial class PageBlockList : PageBlock { public PageListItem[] items; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockBlockquote"/></summary>
	[TLDef(0x263D7C26)]
	public partial class PageBlockBlockquote : PageBlock
	{
		public RichText text;
		public RichText caption;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockPullquote"/></summary>
	[TLDef(0x4F4456D3)]
	public partial class PageBlockPullquote : PageBlock
	{
		public RichText text;
		public RichText caption;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockPhoto"/></summary>
	[TLDef(0x1759C560)]
	public partial class PageBlockPhoto : PageBlock
	{
		[Flags] public enum Flags { has_url = 0x1 }
		public Flags flags;
		public long photo_id;
		public PageCaption caption;
		[IfFlag(0)] public string url;
		[IfFlag(0)] public long webpage_id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockVideo"/></summary>
	[TLDef(0x7C8FE7B6)]
	public partial class PageBlockVideo : PageBlock
	{
		[Flags] public enum Flags { autoplay = 0x1, loop = 0x2 }
		public Flags flags;
		public long video_id;
		public PageCaption caption;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockCover"/></summary>
	[TLDef(0x39F23300)]
	public partial class PageBlockCover : PageBlock { public PageBlock cover; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockEmbed"/></summary>
	[TLDef(0xA8718DC5)]
	public partial class PageBlockEmbed : PageBlock
	{
		[Flags] public enum Flags { full_width = 0x1, has_url = 0x2, has_html = 0x4, allow_scrolling = 0x8, has_poster_photo_id = 0x10, 
			has_w = 0x20 }
		public Flags flags;
		[IfFlag(1)] public string url;
		[IfFlag(2)] public string html;
		[IfFlag(4)] public long poster_photo_id;
		[IfFlag(5)] public int w;
		[IfFlag(5)] public int h;
		public PageCaption caption;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockEmbedPost"/></summary>
	[TLDef(0xF259A80B)]
	public partial class PageBlockEmbedPost : PageBlock
	{
		public string url;
		public long webpage_id;
		public long author_photo_id;
		public string author;
		public DateTime date;
		public PageBlock[] blocks;
		public PageCaption caption;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockCollage"/></summary>
	[TLDef(0x65A0FA4D)]
	public partial class PageBlockCollage : PageBlock
	{
		public PageBlock[] items;
		public PageCaption caption;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockSlideshow"/></summary>
	[TLDef(0x031F9590)]
	public partial class PageBlockSlideshow : PageBlock
	{
		public PageBlock[] items;
		public PageCaption caption;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockChannel"/></summary>
	[TLDef(0xEF1751B5)]
	public partial class PageBlockChannel : PageBlock { public ChatBase channel; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockAudio"/></summary>
	[TLDef(0x804361EA)]
	public partial class PageBlockAudio : PageBlock
	{
		public long audio_id;
		public PageCaption caption;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockKicker"/></summary>
	[TLDef(0x1E148390)]
	public partial class PageBlockKicker : PageBlock { public RichText text; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockTable"/></summary>
	[TLDef(0xBF4DEA82)]
	public partial class PageBlockTable : PageBlock
	{
		[Flags] public enum Flags { bordered = 0x1, striped = 0x2 }
		public Flags flags;
		public RichText title;
		public PageTableRow[] rows;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockOrderedList"/></summary>
	[TLDef(0x9A8AE1E1)]
	public partial class PageBlockOrderedList : PageBlock { public PageListOrderedItem[] items; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockDetails"/></summary>
	[TLDef(0x76768BED)]
	public partial class PageBlockDetails : PageBlock
	{
		[Flags] public enum Flags { open = 0x1 }
		public Flags flags;
		public PageBlock[] blocks;
		public RichText title;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockRelatedArticles"/></summary>
	[TLDef(0x16115A96)]
	public partial class PageBlockRelatedArticles : PageBlock
	{
		public RichText title;
		public PageRelatedArticle[] articles;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageBlockMap"/></summary>
	[TLDef(0xA44F3EF6)]
	public partial class PageBlockMap : PageBlock
	{
		public GeoPoint geo;
		public int zoom;
		public int w;
		public int h;
		public PageCaption caption;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/PhoneCallDiscardReason"/></summary>
	public enum PhoneCallDiscardReason : uint
	{
		///<summary>See <a href="https://corefork.telegram.org/constructor/phoneCallDiscardReasonMissed"/></summary>
		Missed = 0x85E42301,
		///<summary>See <a href="https://corefork.telegram.org/constructor/phoneCallDiscardReasonDisconnect"/></summary>
		Disconnect = 0xE095C1A0,
		///<summary>See <a href="https://corefork.telegram.org/constructor/phoneCallDiscardReasonHangup"/></summary>
		Hangup = 0x57ADC690,
		///<summary>See <a href="https://corefork.telegram.org/constructor/phoneCallDiscardReasonBusy"/></summary>
		Busy = 0xFAF7E8C9,
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/dataJSON"/></summary>
	[TLDef(0x7D748D04)]
	public partial class DataJSON : ITLObject { public string data; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/labeledPrice"/></summary>
	[TLDef(0xCB296BF8)]
	public partial class LabeledPrice : ITLObject
	{
		public string label;
		public long amount;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/invoice"/></summary>
	[TLDef(0x0CD886E0)]
	public partial class Invoice : ITLObject
	{
		[Flags] public enum Flags { test = 0x1, name_requested = 0x2, phone_requested = 0x4, email_requested = 0x8, 
			shipping_address_requested = 0x10, flexible = 0x20, phone_to_provider = 0x40, email_to_provider = 0x80, 
			has_max_tip_amount = 0x100 }
		public Flags flags;
		public string currency;
		public LabeledPrice[] prices;
		[IfFlag(8)] public long max_tip_amount;
		[IfFlag(8)] public long[] suggested_tip_amounts;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/paymentCharge"/></summary>
	[TLDef(0xEA02C27E)]
	public partial class PaymentCharge : ITLObject
	{
		public string id;
		public string provider_charge_id;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/postAddress"/></summary>
	[TLDef(0x1E8CAAEB)]
	public partial class PostAddress : ITLObject
	{
		public string street_line1;
		public string street_line2;
		public string city;
		public string state;
		public string country_iso2;
		public string post_code;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/paymentRequestedInfo"/></summary>
	[TLDef(0x909C3F94)]
	public partial class PaymentRequestedInfo : ITLObject
	{
		[Flags] public enum Flags { has_name = 0x1, has_phone = 0x2, has_email = 0x4, has_shipping_address = 0x8 }
		public Flags flags;
		[IfFlag(0)] public string name;
		[IfFlag(1)] public string phone;
		[IfFlag(2)] public string email;
		[IfFlag(3)] public PostAddress shipping_address;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/PaymentSavedCredentials"/></summary>
	public abstract partial class PaymentSavedCredentials : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/paymentSavedCredentialsCard"/></summary>
	[TLDef(0xCDC27A1F)]
	public partial class PaymentSavedCredentialsCard : PaymentSavedCredentials
	{
		public string id;
		public string title;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/WebDocument"/></summary>
	public abstract partial class WebDocumentBase : ITLObject
	{
		public abstract string Url { get; }
		public abstract int Size { get; }
		public abstract string MimeType { get; }
		public abstract DocumentAttribute[] Attributes { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/webDocument"/></summary>
	[TLDef(0x1C570ED1)]
	public partial class WebDocument : WebDocumentBase
	{
		public string url;
		public long access_hash;
		public int size;
		public string mime_type;
		public DocumentAttribute[] attributes;

		public override string Url => url;
		public override int Size => size;
		public override string MimeType => mime_type;
		public override DocumentAttribute[] Attributes => attributes;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/webDocumentNoProxy"/></summary>
	[TLDef(0xF9C8BCC6)]
	public partial class WebDocumentNoProxy : WebDocumentBase
	{
		public string url;
		public int size;
		public string mime_type;
		public DocumentAttribute[] attributes;

		public override string Url => url;
		public override int Size => size;
		public override string MimeType => mime_type;
		public override DocumentAttribute[] Attributes => attributes;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/inputWebDocument"/></summary>
	[TLDef(0x9BED434D)]
	public partial class InputWebDocument : ITLObject
	{
		public string url;
		public int size;
		public string mime_type;
		public DocumentAttribute[] attributes;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/InputWebFileLocation"/></summary>
	public abstract partial class InputWebFileLocationBase : ITLObject
	{
		public abstract long AccessHash { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputWebFileLocation"/></summary>
	[TLDef(0xC239D686)]
	public partial class InputWebFileLocation : InputWebFileLocationBase
	{
		public string url;
		public long access_hash;

		public override long AccessHash => access_hash;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputWebFileGeoPointLocation"/></summary>
	[TLDef(0x9F2221C9)]
	public partial class InputWebFileGeoPointLocation : InputWebFileLocationBase
	{
		public InputGeoPoint geo_point;
		public long access_hash;
		public int w;
		public int h;
		public int zoom;
		public int scale;

		public override long AccessHash => access_hash;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/upload.webFile"/></summary>
	[TLDef(0x21E753BC)]
	public partial class Upload_WebFile : ITLObject
	{
		public int size;
		public string mime_type;
		public Storage_FileType file_type;
		public int mtime;
		public byte[] bytes;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/payments.paymentForm"/></summary>
	[TLDef(0x1694761B)]
	public partial class Payments_PaymentForm : ITLObject
	{
		[Flags] public enum Flags { has_saved_info = 0x1, has_saved_credentials = 0x2, can_save_credentials = 0x4, 
			password_missing = 0x8, has_native_provider = 0x10 }
		public Flags flags;
		public long form_id;
		public long bot_id;
		public Invoice invoice;
		public long provider_id;
		public string url;
		[IfFlag(4)] public string native_provider;
		[IfFlag(4)] public DataJSON native_params;
		[IfFlag(0)] public PaymentRequestedInfo saved_info;
		[IfFlag(1)] public PaymentSavedCredentials saved_credentials;
		public Dictionary<long, UserBase> users;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/payments.validatedRequestedInfo"/></summary>
	[TLDef(0xD1451883)]
	public partial class Payments_ValidatedRequestedInfo : ITLObject
	{
		[Flags] public enum Flags { has_id = 0x1, has_shipping_options = 0x2 }
		public Flags flags;
		[IfFlag(0)] public string id;
		[IfFlag(1)] public ShippingOption[] shipping_options;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/payments.PaymentResult"/></summary>
	public abstract partial class Payments_PaymentResultBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/payments.paymentResult"/></summary>
	[TLDef(0x4E5F810D)]
	public partial class Payments_PaymentResult : Payments_PaymentResultBase { public UpdatesBase updates; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/payments.paymentVerificationNeeded"/></summary>
	[TLDef(0xD8411139)]
	public partial class Payments_PaymentVerificationNeeded : Payments_PaymentResultBase { public string url; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/payments.paymentReceipt"/></summary>
	[TLDef(0x70C4FE03)]
	public partial class Payments_PaymentReceipt : ITLObject
	{
		[Flags] public enum Flags { has_info = 0x1, has_shipping = 0x2, has_photo = 0x4, has_tip_amount = 0x8 }
		public Flags flags;
		public DateTime date;
		public long bot_id;
		public long provider_id;
		public string title;
		public string description;
		[IfFlag(2)] public WebDocumentBase photo;
		public Invoice invoice;
		[IfFlag(0)] public PaymentRequestedInfo info;
		[IfFlag(1)] public ShippingOption shipping;
		[IfFlag(3)] public long tip_amount;
		public string currency;
		public long total_amount;
		public string credentials_title;
		public Dictionary<long, UserBase> users;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/payments.savedInfo"/></summary>
	[TLDef(0xFB8FE43C)]
	public partial class Payments_SavedInfo : ITLObject
	{
		[Flags] public enum Flags { has_saved_info = 0x1, has_saved_credentials = 0x2 }
		public Flags flags;
		[IfFlag(0)] public PaymentRequestedInfo saved_info;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/InputPaymentCredentials"/></summary>
	public abstract partial class InputPaymentCredentialsBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputPaymentCredentialsSaved"/></summary>
	[TLDef(0xC10EB2CF)]
	public partial class InputPaymentCredentialsSaved : InputPaymentCredentialsBase
	{
		public string id;
		public byte[] tmp_password;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputPaymentCredentials"/></summary>
	[TLDef(0x3417D728)]
	public partial class InputPaymentCredentials : InputPaymentCredentialsBase
	{
		[Flags] public enum Flags { save = 0x1 }
		public Flags flags;
		public DataJSON data;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputPaymentCredentialsApplePay"/></summary>
	[TLDef(0x0AA1C39F)]
	public partial class InputPaymentCredentialsApplePay : InputPaymentCredentialsBase { public DataJSON payment_data; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputPaymentCredentialsGooglePay"/></summary>
	[TLDef(0x8AC32801)]
	public partial class InputPaymentCredentialsGooglePay : InputPaymentCredentialsBase { public DataJSON payment_token; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/account.tmpPassword"/></summary>
	[TLDef(0xDB64FD34)]
	public partial class Account_TmpPassword : ITLObject
	{
		public byte[] tmp_password;
		public DateTime valid_until;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/shippingOption"/></summary>
	[TLDef(0xB6213CDF)]
	public partial class ShippingOption : ITLObject
	{
		public string id;
		public string title;
		public LabeledPrice[] prices;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/inputStickerSetItem"/></summary>
	[TLDef(0xFFA0A496)]
	public partial class InputStickerSetItem : ITLObject
	{
		[Flags] public enum Flags { has_mask_coords = 0x1 }
		public Flags flags;
		public InputDocument document;
		public string emoji;
		[IfFlag(0)] public MaskCoords mask_coords;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/inputPhoneCall"/></summary>
	[TLDef(0x1E36FDED)]
	public partial class InputPhoneCall : ITLObject
	{
		public long id;
		public long access_hash;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/PhoneCall"/></summary>
	public abstract partial class PhoneCallBase : ITLObject
	{
		public abstract long ID { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/phoneCallEmpty"/></summary>
	[TLDef(0x5366C915)]
	public partial class PhoneCallEmpty : PhoneCallBase
	{
		public long id;

		public override long ID => id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/phoneCallWaiting"/></summary>
	[TLDef(0xC5226F17)]
	public partial class PhoneCallWaiting : PhoneCallBase
	{
		[Flags] public enum Flags { has_receive_date = 0x1, video = 0x40 }
		public Flags flags;
		public long id;
		public long access_hash;
		public DateTime date;
		public long admin_id;
		public long participant_id;
		public PhoneCallProtocol protocol;
		[IfFlag(0)] public DateTime receive_date;

		public override long ID => id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/phoneCallRequested"/></summary>
	[TLDef(0x14B0ED0C)]
	public partial class PhoneCallRequested : PhoneCallBase
	{
		[Flags] public enum Flags { video = 0x40 }
		public Flags flags;
		public long id;
		public long access_hash;
		public DateTime date;
		public long admin_id;
		public long participant_id;
		public byte[] g_a_hash;
		public PhoneCallProtocol protocol;

		public override long ID => id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/phoneCallAccepted"/></summary>
	[TLDef(0x3660C311)]
	public partial class PhoneCallAccepted : PhoneCallBase
	{
		[Flags] public enum Flags { video = 0x40 }
		public Flags flags;
		public long id;
		public long access_hash;
		public DateTime date;
		public long admin_id;
		public long participant_id;
		public byte[] g_b;
		public PhoneCallProtocol protocol;

		public override long ID => id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/phoneCall"/></summary>
	[TLDef(0x967F7C67)]
	public partial class PhoneCall : PhoneCallBase
	{
		[Flags] public enum Flags { p2p_allowed = 0x20, video = 0x40 }
		public Flags flags;
		public long id;
		public long access_hash;
		public DateTime date;
		public long admin_id;
		public long participant_id;
		public byte[] g_a_or_b;
		public long key_fingerprint;
		public PhoneCallProtocol protocol;
		public PhoneConnectionBase[] connections;
		public DateTime start_date;

		public override long ID => id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/phoneCallDiscarded"/></summary>
	[TLDef(0x50CA4DE1)]
	public partial class PhoneCallDiscarded : PhoneCallBase
	{
		[Flags] public enum Flags { has_reason = 0x1, has_duration = 0x2, need_rating = 0x4, need_debug = 0x8, video = 0x40 }
		public Flags flags;
		public long id;
		[IfFlag(0)] public PhoneCallDiscardReason reason;
		[IfFlag(1)] public int duration;

		public override long ID => id;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/PhoneConnection"/></summary>
	public abstract partial class PhoneConnectionBase : ITLObject
	{
		public abstract long ID { get; }
		public abstract string Ip { get; }
		public abstract string Ipv6 { get; }
		public abstract int Port { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/phoneConnection"/></summary>
	[TLDef(0x9D4C17C0)]
	public partial class PhoneConnection : PhoneConnectionBase
	{
		public long id;
		public string ip;
		public string ipv6;
		public int port;
		public byte[] peer_tag;

		public override long ID => id;
		public override string Ip => ip;
		public override string Ipv6 => ipv6;
		public override int Port => port;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/phoneConnectionWebrtc"/></summary>
	[TLDef(0x635FE375)]
	public partial class PhoneConnectionWebrtc : PhoneConnectionBase
	{
		[Flags] public enum Flags { turn = 0x1, stun = 0x2 }
		public Flags flags;
		public long id;
		public string ip;
		public string ipv6;
		public int port;
		public string username;
		public string password;

		public override long ID => id;
		public override string Ip => ip;
		public override string Ipv6 => ipv6;
		public override int Port => port;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/phoneCallProtocol"/></summary>
	[TLDef(0xFC878FC8)]
	public partial class PhoneCallProtocol : ITLObject
	{
		[Flags] public enum Flags { udp_p2p = 0x1, udp_reflector = 0x2 }
		public Flags flags;
		public int min_layer;
		public int max_layer;
		public string[] library_versions;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/phone.phoneCall"/></summary>
	[TLDef(0xEC82E140)]
	public partial class Phone_PhoneCall : ITLObject
	{
		public PhoneCallBase phone_call;
		public Dictionary<long, UserBase> users;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/upload.CdnFile"/></summary>
	public abstract partial class Upload_CdnFileBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/upload.cdnFileReuploadNeeded"/></summary>
	[TLDef(0xEEA8E46E)]
	public partial class Upload_CdnFileReuploadNeeded : Upload_CdnFileBase { public byte[] request_token; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/upload.cdnFile"/></summary>
	[TLDef(0xA99FCA4F)]
	public partial class Upload_CdnFile : Upload_CdnFileBase { public byte[] bytes; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/cdnPublicKey"/></summary>
	[TLDef(0xC982EABA)]
	public partial class CdnPublicKey : ITLObject
	{
		public int dc_id;
		public string public_key;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/cdnConfig"/></summary>
	[TLDef(0x5725E40A)]
	public partial class CdnConfig : ITLObject { public CdnPublicKey[] public_keys; }

	///<summary>See <a href="https://corefork.telegram.org/type/LangPackString"/></summary>
	public abstract partial class LangPackStringBase : ITLObject
	{
		public abstract string Key { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/langPackString"/></summary>
	[TLDef(0xCAD181F6)]
	public partial class LangPackString : LangPackStringBase
	{
		public string key;
		public string value;

		public override string Key => key;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/langPackStringPluralized"/></summary>
	[TLDef(0x6C47AC9F)]
	public partial class LangPackStringPluralized : LangPackStringBase
	{
		[Flags] public enum Flags { has_zero_value = 0x1, has_one_value = 0x2, has_two_value = 0x4, has_few_value = 0x8, 
			has_many_value = 0x10 }
		public Flags flags;
		public string key;
		[IfFlag(0)] public string zero_value;
		[IfFlag(1)] public string one_value;
		[IfFlag(2)] public string two_value;
		[IfFlag(3)] public string few_value;
		[IfFlag(4)] public string many_value;
		public string other_value;

		public override string Key => key;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/langPackStringDeleted"/></summary>
	[TLDef(0x2979EEB2)]
	public partial class LangPackStringDeleted : LangPackStringBase
	{
		public string key;

		public override string Key => key;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/langPackDifference"/></summary>
	[TLDef(0xF385C1F6)]
	public partial class LangPackDifference : ITLObject
	{
		public string lang_code;
		public int from_version;
		public int version;
		public LangPackStringBase[] strings;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/langPackLanguage"/></summary>
	[TLDef(0xEECA5CE3)]
	public partial class LangPackLanguage : ITLObject
	{
		[Flags] public enum Flags { official = 0x1, has_base_lang_code = 0x2, rtl = 0x4, beta = 0x8 }
		public Flags flags;
		public string name;
		public string native_name;
		public string lang_code;
		[IfFlag(1)] public string base_lang_code;
		public string plural_code;
		public int strings_count;
		public int translated_count;
		public string translations_url;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/ChannelAdminLogEventAction"/></summary>
	public abstract partial class ChannelAdminLogEventAction : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangeTitle"/></summary>
	[TLDef(0xE6DFB825)]
	public partial class ChannelAdminLogEventActionChangeTitle : ChannelAdminLogEventAction
	{
		public string prev_value;
		public string new_value;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangeAbout"/></summary>
	[TLDef(0x55188A2E)]
	public partial class ChannelAdminLogEventActionChangeAbout : ChannelAdminLogEventAction
	{
		public string prev_value;
		public string new_value;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangeUsername"/></summary>
	[TLDef(0x6A4AFC38)]
	public partial class ChannelAdminLogEventActionChangeUsername : ChannelAdminLogEventAction
	{
		public string prev_value;
		public string new_value;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangePhoto"/></summary>
	[TLDef(0x434BD2AF)]
	public partial class ChannelAdminLogEventActionChangePhoto : ChannelAdminLogEventAction
	{
		public PhotoBase prev_photo;
		public PhotoBase new_photo;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionToggleInvites"/></summary>
	[TLDef(0x1B7907AE)]
	public partial class ChannelAdminLogEventActionToggleInvites : ChannelAdminLogEventAction { public bool new_value; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionToggleSignatures"/></summary>
	[TLDef(0x26AE0971)]
	public partial class ChannelAdminLogEventActionToggleSignatures : ChannelAdminLogEventAction { public bool new_value; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionUpdatePinned"/></summary>
	[TLDef(0xE9E82C18)]
	public partial class ChannelAdminLogEventActionUpdatePinned : ChannelAdminLogEventAction { public MessageBase message; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionEditMessage"/></summary>
	[TLDef(0x709B2405)]
	public partial class ChannelAdminLogEventActionEditMessage : ChannelAdminLogEventAction
	{
		public MessageBase prev_message;
		public MessageBase new_message;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionDeleteMessage"/></summary>
	[TLDef(0x42E047BB)]
	public partial class ChannelAdminLogEventActionDeleteMessage : ChannelAdminLogEventAction { public MessageBase message; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantJoin"/></summary>
	[TLDef(0x183040D3)]
	public partial class ChannelAdminLogEventActionParticipantJoin : ChannelAdminLogEventAction { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantLeave"/></summary>
	[TLDef(0xF89777F2)]
	public partial class ChannelAdminLogEventActionParticipantLeave : ChannelAdminLogEventAction { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantInvite"/></summary>
	[TLDef(0xE31C34D8)]
	public partial class ChannelAdminLogEventActionParticipantInvite : ChannelAdminLogEventAction { public ChannelParticipantBase participant; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantToggleBan"/></summary>
	[TLDef(0xE6D83D7E)]
	public partial class ChannelAdminLogEventActionParticipantToggleBan : ChannelAdminLogEventAction
	{
		public ChannelParticipantBase prev_participant;
		public ChannelParticipantBase new_participant;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantToggleAdmin"/></summary>
	[TLDef(0xD5676710)]
	public partial class ChannelAdminLogEventActionParticipantToggleAdmin : ChannelAdminLogEventAction
	{
		public ChannelParticipantBase prev_participant;
		public ChannelParticipantBase new_participant;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangeStickerSet"/></summary>
	[TLDef(0xB1C3CAA7)]
	public partial class ChannelAdminLogEventActionChangeStickerSet : ChannelAdminLogEventAction
	{
		public InputStickerSet prev_stickerset;
		public InputStickerSet new_stickerset;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionTogglePreHistoryHidden"/></summary>
	[TLDef(0x5F5C95F1)]
	public partial class ChannelAdminLogEventActionTogglePreHistoryHidden : ChannelAdminLogEventAction { public bool new_value; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionDefaultBannedRights"/></summary>
	[TLDef(0x2DF5FC0A)]
	public partial class ChannelAdminLogEventActionDefaultBannedRights : ChannelAdminLogEventAction
	{
		public ChatBannedRights prev_banned_rights;
		public ChatBannedRights new_banned_rights;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionStopPoll"/></summary>
	[TLDef(0x8F079643)]
	public partial class ChannelAdminLogEventActionStopPoll : ChannelAdminLogEventAction { public MessageBase message; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangeLinkedChat"/></summary>
	[TLDef(0x050C7AC8)]
	public partial class ChannelAdminLogEventActionChangeLinkedChat : ChannelAdminLogEventAction
	{
		public long prev_value;
		public long new_value;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangeLocation"/></summary>
	[TLDef(0x0E6B76AE)]
	public partial class ChannelAdminLogEventActionChangeLocation : ChannelAdminLogEventAction
	{
		public ChannelLocation prev_value;
		public ChannelLocation new_value;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionToggleSlowMode"/></summary>
	[TLDef(0x53909779)]
	public partial class ChannelAdminLogEventActionToggleSlowMode : ChannelAdminLogEventAction
	{
		public int prev_value;
		public int new_value;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionStartGroupCall"/></summary>
	[TLDef(0x23209745)]
	public partial class ChannelAdminLogEventActionStartGroupCall : ChannelAdminLogEventAction { public InputGroupCall call; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionDiscardGroupCall"/></summary>
	[TLDef(0xDB9F9140)]
	public partial class ChannelAdminLogEventActionDiscardGroupCall : ChannelAdminLogEventAction { public InputGroupCall call; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantMute"/></summary>
	[TLDef(0xF92424D2)]
	public partial class ChannelAdminLogEventActionParticipantMute : ChannelAdminLogEventAction { public GroupCallParticipant participant; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantUnmute"/></summary>
	[TLDef(0xE64429C0)]
	public partial class ChannelAdminLogEventActionParticipantUnmute : ChannelAdminLogEventAction { public GroupCallParticipant participant; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionToggleGroupCallSetting"/></summary>
	[TLDef(0x56D6A247)]
	public partial class ChannelAdminLogEventActionToggleGroupCallSetting : ChannelAdminLogEventAction { public bool join_muted; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantJoinByInvite"/></summary>
	[TLDef(0x5CDADA77)]
	public partial class ChannelAdminLogEventActionParticipantJoinByInvite : ChannelAdminLogEventAction { public ExportedChatInvite invite; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionExportedInviteDelete"/></summary>
	[TLDef(0x5A50FCA4)]
	public partial class ChannelAdminLogEventActionExportedInviteDelete : ChannelAdminLogEventAction { public ExportedChatInvite invite; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionExportedInviteRevoke"/></summary>
	[TLDef(0x410A134E)]
	public partial class ChannelAdminLogEventActionExportedInviteRevoke : ChannelAdminLogEventAction { public ExportedChatInvite invite; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionExportedInviteEdit"/></summary>
	[TLDef(0xE90EBB59)]
	public partial class ChannelAdminLogEventActionExportedInviteEdit : ChannelAdminLogEventAction
	{
		public ExportedChatInvite prev_invite;
		public ExportedChatInvite new_invite;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionParticipantVolume"/></summary>
	[TLDef(0x3E7F6847)]
	public partial class ChannelAdminLogEventActionParticipantVolume : ChannelAdminLogEventAction { public GroupCallParticipant participant; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangeHistoryTTL"/></summary>
	[TLDef(0x6E941A38)]
	public partial class ChannelAdminLogEventActionChangeHistoryTTL : ChannelAdminLogEventAction
	{
		public int prev_value;
		public int new_value;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventActionChangeTheme"/></summary>
	[TLDef(0xFE69018D)]
	public partial class ChannelAdminLogEventActionChangeTheme : ChannelAdminLogEventAction
	{
		public string prev_value;
		public string new_value;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEvent"/></summary>
	[TLDef(0x1FAD68CD)]
	public partial class ChannelAdminLogEvent : ITLObject
	{
		public long id;
		public DateTime date;
		public long user_id;
		public ChannelAdminLogEventAction action;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/channels.adminLogResults"/></summary>
	[TLDef(0xED8AF74D)]
	public partial class Channels_AdminLogResults : ITLObject
	{
		public ChannelAdminLogEvent[] events;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/channelAdminLogEventsFilter"/></summary>
	[TLDef(0xEA107AE4)]
	public partial class ChannelAdminLogEventsFilter : ITLObject
	{
		[Flags] public enum Flags { join = 0x1, leave = 0x2, invite = 0x4, ban = 0x8, unban = 0x10, kick = 0x20, unkick = 0x40, 
			promote = 0x80, demote = 0x100, info = 0x200, settings = 0x400, pinned = 0x800, edit = 0x1000, delete = 0x2000, 
			group_call = 0x4000, invites = 0x8000 }
		public Flags flags;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/popularContact"/></summary>
	[TLDef(0x5CE14175)]
	public partial class PopularContact : ITLObject
	{
		public long client_id;
		public int importers;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.favedStickers"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.favedStickersNotModified">messages.favedStickersNotModified</a></remarks>
	[TLDef(0x2CB51097)]
	public partial class Messages_FavedStickers : ITLObject
	{
		public long hash;
		public StickerPack[] packs;
		public DocumentBase[] stickers;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/RecentMeUrl"/></summary>
	public abstract partial class RecentMeUrl : ITLObject { public string url; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/recentMeUrlUnknown"/></summary>
	[TLDef(0x46E1D13D)]
	public partial class RecentMeUrlUnknown : RecentMeUrl { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/recentMeUrlUser"/></summary>
	[TLDef(0xB92C09E2)]
	public partial class RecentMeUrlUser : RecentMeUrl { public long user_id; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/recentMeUrlChat"/></summary>
	[TLDef(0xB2DA71D2)]
	public partial class RecentMeUrlChat : RecentMeUrl { public long chat_id; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/recentMeUrlChatInvite"/></summary>
	[TLDef(0xEB49081D)]
	public partial class RecentMeUrlChatInvite : RecentMeUrl { public ChatInviteBase chat_invite; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/recentMeUrlStickerSet"/></summary>
	[TLDef(0xBC0A57DC)]
	public partial class RecentMeUrlStickerSet : RecentMeUrl { public StickerSetCoveredBase set; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/help.recentMeUrls"/></summary>
	[TLDef(0x0E0310D7)]
	public partial class Help_RecentMeUrls : ITLObject
	{
		public RecentMeUrl[] urls;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/inputSingleMedia"/></summary>
	[TLDef(0x1CC6E91F)]
	public partial class InputSingleMedia : ITLObject
	{
		[Flags] public enum Flags { has_entities = 0x1 }
		public Flags flags;
		public InputMedia media;
		public long random_id;
		public string message;
		[IfFlag(0)] public MessageEntity[] entities;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/webAuthorization"/></summary>
	[TLDef(0xA6F8F452)]
	public partial class WebAuthorization : ITLObject
	{
		public long hash;
		public long bot_id;
		public string domain;
		public string browser;
		public string platform;
		public int date_created;
		public int date_active;
		public string ip;
		public string region;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/account.webAuthorizations"/></summary>
	[TLDef(0xED56C9FC)]
	public partial class Account_WebAuthorizations : ITLObject
	{
		public WebAuthorization[] authorizations;
		public Dictionary<long, UserBase> users;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/InputMessage"/></summary>
	public abstract partial class InputMessage : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMessageID"/></summary>
	[TLDef(0xA676A322)]
	public partial class InputMessageID : InputMessage { public int id; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMessageReplyTo"/></summary>
	[TLDef(0xBAD88395)]
	public partial class InputMessageReplyTo : InputMessage { public int id; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMessagePinned"/></summary>
	[TLDef(0x86872538)]
	public partial class InputMessagePinned : InputMessage { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputMessageCallbackQuery"/></summary>
	[TLDef(0xACFA1A7E)]
	public partial class InputMessageCallbackQuery : InputMessage
	{
		public int id;
		public long query_id;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/InputDialogPeer"/></summary>
	public abstract partial class InputDialogPeerBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputDialogPeer"/></summary>
	[TLDef(0xFCAAFEB7)]
	public partial class InputDialogPeer : InputDialogPeerBase { public InputPeer peer; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputDialogPeerFolder"/></summary>
	[TLDef(0x64600527)]
	public partial class InputDialogPeerFolder : InputDialogPeerBase { public int folder_id; }

	///<summary>See <a href="https://corefork.telegram.org/type/DialogPeer"/></summary>
	public abstract partial class DialogPeerBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/dialogPeer"/></summary>
	[TLDef(0xE56DBF05)]
	public partial class DialogPeer : DialogPeerBase { public Peer peer; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/dialogPeerFolder"/></summary>
	[TLDef(0x514519E2)]
	public partial class DialogPeerFolder : DialogPeerBase { public int folder_id; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.foundStickerSets"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/messages.foundStickerSetsNotModified">messages.foundStickerSetsNotModified</a></remarks>
	[TLDef(0x8AF09DD2)]
	public partial class Messages_FoundStickerSets : ITLObject
	{
		public long hash;
		public StickerSetCoveredBase[] sets;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/fileHash"/></summary>
	[TLDef(0x6242C773)]
	public partial class FileHash : ITLObject
	{
		public int offset;
		public int limit;
		public byte[] hash;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/inputClientProxy"/></summary>
	[TLDef(0x75588B3F)]
	public partial class InputClientProxy : ITLObject
	{
		public string address;
		public int port;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/help.TermsOfServiceUpdate"/></summary>
	public abstract partial class Help_TermsOfServiceUpdateBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/help.termsOfServiceUpdateEmpty"/></summary>
	[TLDef(0xE3309F7F)]
	public partial class Help_TermsOfServiceUpdateEmpty : Help_TermsOfServiceUpdateBase { public DateTime expires; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/help.termsOfServiceUpdate"/></summary>
	[TLDef(0x28ECF961)]
	public partial class Help_TermsOfServiceUpdate : Help_TermsOfServiceUpdateBase
	{
		public DateTime expires;
		public Help_TermsOfService terms_of_service;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/InputSecureFile"/></summary>
	public abstract partial class InputSecureFileBase : ITLObject
	{
		public abstract long ID { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputSecureFileUploaded"/></summary>
	[TLDef(0x3334B0F0)]
	public partial class InputSecureFileUploaded : InputSecureFileBase
	{
		public long id;
		public int parts;
		public byte[] md5_checksum;
		public byte[] file_hash;
		public byte[] secret;

		public override long ID => id;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputSecureFile"/></summary>
	[TLDef(0x5367E5BE)]
	public partial class InputSecureFile : InputSecureFileBase
	{
		public long id;
		public long access_hash;

		public override long ID => id;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/secureFile"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/secureFileEmpty">secureFileEmpty</a></remarks>
	[TLDef(0xE0277A62)]
	public partial class SecureFile : ITLObject
	{
		public long id;
		public long access_hash;
		public int size;
		public int dc_id;
		public DateTime date;
		public byte[] file_hash;
		public byte[] secret;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/secureData"/></summary>
	[TLDef(0x8AEABEC3)]
	public partial class SecureData : ITLObject
	{
		public byte[] data;
		public byte[] data_hash;
		public byte[] secret;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/SecurePlainData"/></summary>
	public abstract partial class SecurePlainData : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/securePlainPhone"/></summary>
	[TLDef(0x7D6099DD)]
	public partial class SecurePlainPhone : SecurePlainData { public string phone; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/securePlainEmail"/></summary>
	[TLDef(0x21EC5A5F)]
	public partial class SecurePlainEmail : SecurePlainData { public string email; }

	///<summary>See <a href="https://corefork.telegram.org/type/SecureValueType"/></summary>
	public enum SecureValueType : uint
	{
		///<summary>See <a href="https://corefork.telegram.org/constructor/secureValueTypePersonalDetails"/></summary>
		PersonalDetails = 0x9D2A81E3,
		///<summary>See <a href="https://corefork.telegram.org/constructor/secureValueTypePassport"/></summary>
		Passport = 0x3DAC6A00,
		///<summary>See <a href="https://corefork.telegram.org/constructor/secureValueTypeDriverLicense"/></summary>
		DriverLicense = 0x06E425C4,
		///<summary>See <a href="https://corefork.telegram.org/constructor/secureValueTypeIdentityCard"/></summary>
		IdentityCard = 0xA0D0744B,
		///<summary>See <a href="https://corefork.telegram.org/constructor/secureValueTypeInternalPassport"/></summary>
		InternalPassport = 0x99A48F23,
		///<summary>See <a href="https://corefork.telegram.org/constructor/secureValueTypeAddress"/></summary>
		Address = 0xCBE31E26,
		///<summary>See <a href="https://corefork.telegram.org/constructor/secureValueTypeUtilityBill"/></summary>
		UtilityBill = 0xFC36954E,
		///<summary>See <a href="https://corefork.telegram.org/constructor/secureValueTypeBankStatement"/></summary>
		BankStatement = 0x89137C0D,
		///<summary>See <a href="https://corefork.telegram.org/constructor/secureValueTypeRentalAgreement"/></summary>
		RentalAgreement = 0x8B883488,
		///<summary>See <a href="https://corefork.telegram.org/constructor/secureValueTypePassportRegistration"/></summary>
		PassportRegistration = 0x99E3806A,
		///<summary>See <a href="https://corefork.telegram.org/constructor/secureValueTypeTemporaryRegistration"/></summary>
		TemporaryRegistration = 0xEA02EC33,
		///<summary>See <a href="https://corefork.telegram.org/constructor/secureValueTypePhone"/></summary>
		Phone = 0xB320AADB,
		///<summary>See <a href="https://corefork.telegram.org/constructor/secureValueTypeEmail"/></summary>
		Email = 0x8E3CA7EE,
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/secureValue"/></summary>
	[TLDef(0x187FA0CA)]
	public partial class SecureValue : ITLObject
	{
		[Flags] public enum Flags { has_data = 0x1, has_front_side = 0x2, has_reverse_side = 0x4, has_selfie = 0x8, has_files = 0x10, 
			has_plain_data = 0x20, has_translation = 0x40 }
		public Flags flags;
		public SecureValueType type;
		[IfFlag(0)] public SecureData data;
		[IfFlag(1)] public SecureFile front_side;
		[IfFlag(2)] public SecureFile reverse_side;
		[IfFlag(3)] public SecureFile selfie;
		[IfFlag(6)] public SecureFile[] translation;
		[IfFlag(4)] public SecureFile[] files;
		[IfFlag(5)] public SecurePlainData plain_data;
		public byte[] hash;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/inputSecureValue"/></summary>
	[TLDef(0xDB21D0A7)]
	public partial class InputSecureValue : ITLObject
	{
		[Flags] public enum Flags { has_data = 0x1, has_front_side = 0x2, has_reverse_side = 0x4, has_selfie = 0x8, has_files = 0x10, 
			has_plain_data = 0x20, has_translation = 0x40 }
		public Flags flags;
		public SecureValueType type;
		[IfFlag(0)] public SecureData data;
		[IfFlag(1)] public InputSecureFileBase front_side;
		[IfFlag(2)] public InputSecureFileBase reverse_side;
		[IfFlag(3)] public InputSecureFileBase selfie;
		[IfFlag(6)] public InputSecureFileBase[] translation;
		[IfFlag(4)] public InputSecureFileBase[] files;
		[IfFlag(5)] public SecurePlainData plain_data;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/secureValueHash"/></summary>
	[TLDef(0xED1ECDB0)]
	public partial class SecureValueHash : ITLObject
	{
		public SecureValueType type;
		public byte[] hash;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/SecureValueError"/></summary>
	public abstract partial class SecureValueErrorBase : ITLObject
	{
		public abstract SecureValueType Type { get; }
		public abstract string Text { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/secureValueErrorData"/></summary>
	[TLDef(0xE8A40BD9)]
	public partial class SecureValueErrorData : SecureValueErrorBase
	{
		public SecureValueType type;
		public byte[] data_hash;
		public string field;
		public string text;

		public override SecureValueType Type => type;
		public override string Text => text;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/secureValueErrorFrontSide"/></summary>
	[TLDef(0x00BE3DFA)]
	public partial class SecureValueErrorFrontSide : SecureValueErrorBase
	{
		public SecureValueType type;
		public byte[] file_hash;
		public string text;

		public override SecureValueType Type => type;
		public override string Text => text;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/secureValueErrorReverseSide"/></summary>
	[TLDef(0x868A2AA5)]
	public partial class SecureValueErrorReverseSide : SecureValueErrorBase
	{
		public SecureValueType type;
		public byte[] file_hash;
		public string text;

		public override SecureValueType Type => type;
		public override string Text => text;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/secureValueErrorSelfie"/></summary>
	[TLDef(0xE537CED6)]
	public partial class SecureValueErrorSelfie : SecureValueErrorBase
	{
		public SecureValueType type;
		public byte[] file_hash;
		public string text;

		public override SecureValueType Type => type;
		public override string Text => text;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/secureValueErrorFile"/></summary>
	[TLDef(0x7A700873)]
	public partial class SecureValueErrorFile : SecureValueErrorBase
	{
		public SecureValueType type;
		public byte[] file_hash;
		public string text;

		public override SecureValueType Type => type;
		public override string Text => text;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/secureValueErrorFiles"/></summary>
	[TLDef(0x666220E9)]
	public partial class SecureValueErrorFiles : SecureValueErrorBase
	{
		public SecureValueType type;
		public byte[][] file_hash;
		public string text;

		public override SecureValueType Type => type;
		public override string Text => text;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/secureValueError"/></summary>
	[TLDef(0x869D758F)]
	public partial class SecureValueError : SecureValueErrorBase
	{
		public SecureValueType type;
		public byte[] hash;
		public string text;

		public override SecureValueType Type => type;
		public override string Text => text;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/secureValueErrorTranslationFile"/></summary>
	[TLDef(0xA1144770)]
	public partial class SecureValueErrorTranslationFile : SecureValueErrorFile
	{
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/secureValueErrorTranslationFiles"/></summary>
	[TLDef(0x34636DD8)]
	public partial class SecureValueErrorTranslationFiles : SecureValueErrorFiles
	{
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/secureCredentialsEncrypted"/></summary>
	[TLDef(0x33F0EA47)]
	public partial class SecureCredentialsEncrypted : ITLObject
	{
		public byte[] data;
		public byte[] hash;
		public byte[] secret;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/account.authorizationForm"/></summary>
	[TLDef(0xAD2E1CD8)]
	public partial class Account_AuthorizationForm : ITLObject
	{
		[Flags] public enum Flags { has_privacy_policy_url = 0x1 }
		public Flags flags;
		public SecureRequiredTypeBase[] required_types;
		public SecureValue[] values;
		public SecureValueErrorBase[] errors;
		public Dictionary<long, UserBase> users;
		[IfFlag(0)] public string privacy_policy_url;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/account.sentEmailCode"/></summary>
	[TLDef(0x811F854F)]
	public partial class Account_SentEmailCode : ITLObject
	{
		public string email_pattern;
		public int length;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/help.deepLinkInfo"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.deepLinkInfoEmpty">help.deepLinkInfoEmpty</a></remarks>
	[TLDef(0x6A4EE832)]
	public partial class Help_DeepLinkInfo : ITLObject
	{
		[Flags] public enum Flags { update_app = 0x1, has_entities = 0x2 }
		public Flags flags;
		public string message;
		[IfFlag(1)] public MessageEntity[] entities;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/SavedContact"/></summary>
	public abstract partial class SavedContact : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/savedPhoneContact"/></summary>
	[TLDef(0x1142BD56)]
	public partial class SavedPhoneContact : SavedContact
	{
		public string phone;
		public string first_name;
		public string last_name;
		public DateTime date;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/account.takeout"/></summary>
	[TLDef(0x4DBA4501)]
	public partial class Account_Takeout : ITLObject { public long id; }

	///<summary>See <a href="https://corefork.telegram.org/type/PasswordKdfAlgo"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/passwordKdfAlgoUnknown">passwordKdfAlgoUnknown</a></remarks>
	public abstract partial class PasswordKdfAlgo : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/passwordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow"/></summary>
	[TLDef(0x3A912D4A)]
	public partial class PasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow : PasswordKdfAlgo
	{
		public byte[] salt1;
		public byte[] salt2;
		public int g;
		public byte[] p;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/SecurePasswordKdfAlgo"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/securePasswordKdfAlgoUnknown">securePasswordKdfAlgoUnknown</a></remarks>
	public abstract partial class SecurePasswordKdfAlgo : ITLObject { public byte[] salt; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/securePasswordKdfAlgoPBKDF2HMACSHA512iter100000"/></summary>
	[TLDef(0xBBF2DDA0)]
	public partial class SecurePasswordKdfAlgoPBKDF2HMACSHA512iter100000 : SecurePasswordKdfAlgo { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/securePasswordKdfAlgoSHA512"/></summary>
	[TLDef(0x86471D92)]
	public partial class SecurePasswordKdfAlgoSHA512 : SecurePasswordKdfAlgo { }

	///<summary>See <a href="https://corefork.telegram.org/constructor/secureSecretSettings"/></summary>
	[TLDef(0x1527BCAC)]
	public partial class SecureSecretSettings : ITLObject
	{
		public SecurePasswordKdfAlgo secure_algo;
		public byte[] secure_secret;
		public long secure_secret_id;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/inputCheckPasswordSRP"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/inputCheckPasswordEmpty">inputCheckPasswordEmpty</a></remarks>
	[TLDef(0xD27FF082)]
	public partial class InputCheckPasswordSRP : ITLObject
	{
		public long srp_id;
		public byte[] A;
		public byte[] M1;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/SecureRequiredType"/></summary>
	public abstract partial class SecureRequiredTypeBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/secureRequiredType"/></summary>
	[TLDef(0x829D99DA)]
	public partial class SecureRequiredType : SecureRequiredTypeBase
	{
		[Flags] public enum Flags { native_names = 0x1, selfie_required = 0x2, translation_required = 0x4 }
		public Flags flags;
		public SecureValueType type;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/secureRequiredTypeOneOf"/></summary>
	[TLDef(0x027477B4)]
	public partial class SecureRequiredTypeOneOf : SecureRequiredTypeBase { public SecureRequiredTypeBase[] types; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/help.passportConfig"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.passportConfigNotModified">help.passportConfigNotModified</a></remarks>
	[TLDef(0xA098D6AF)]
	public partial class Help_PassportConfig : ITLObject
	{
		public int hash;
		public DataJSON countries_langs;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/inputAppEvent"/></summary>
	[TLDef(0x1D1B1245)]
	public partial class InputAppEvent : ITLObject
	{
		public double time;
		public string type;
		public long peer;
		public JSONValue data;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/JSONObjectValue"/></summary>
	public abstract partial class JSONObjectValue : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/jsonObjectValue"/></summary>
	[TLDef(0xC0DE1BD9)]
	public partial class JsonObjectValue : JSONObjectValue
	{
		public string key;
		public JSONValue value;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/JSONValue"/></summary>
	public abstract partial class JSONValue : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/jsonNull"/></summary>
	[TLDef(0x3F6D7B68)]
	public partial class JsonNull : JSONValue { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/jsonBool"/></summary>
	[TLDef(0xC7345E6A)]
	public partial class JsonBool : JSONValue { public bool value; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/jsonNumber"/></summary>
	[TLDef(0x2BE0DFA4)]
	public partial class JsonNumber : JSONValue { public double value; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/jsonString"/></summary>
	[TLDef(0xB71E767A)]
	public partial class JsonString : JSONValue { public string value; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/jsonArray"/></summary>
	[TLDef(0xF7444763)]
	public partial class JsonArray : JSONValue { public JSONValue[] value; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/jsonObject"/></summary>
	[TLDef(0x99C1D49D)]
	public partial class JsonObject : JSONValue { public JSONObjectValue[] value; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/pageTableCell"/></summary>
	[TLDef(0x34566B6A)]
	public partial class PageTableCell : ITLObject
	{
		[Flags] public enum Flags { header = 0x1, has_colspan = 0x2, has_rowspan = 0x4, align_center = 0x8, align_right = 0x10, 
			valign_middle = 0x20, valign_bottom = 0x40, has_text = 0x80 }
		public Flags flags;
		[IfFlag(7)] public RichText text;
		[IfFlag(1)] public int colspan;
		[IfFlag(2)] public int rowspan;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/pageTableRow"/></summary>
	[TLDef(0xE0C0C5E5)]
	public partial class PageTableRow : ITLObject { public PageTableCell[] cells; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/pageCaption"/></summary>
	[TLDef(0x6F747657)]
	public partial class PageCaption : ITLObject
	{
		public RichText text;
		public RichText credit;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/PageListItem"/></summary>
	public abstract partial class PageListItem : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageListItemText"/></summary>
	[TLDef(0xB92FB6CD)]
	public partial class PageListItemText : PageListItem { public RichText text; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageListItemBlocks"/></summary>
	[TLDef(0x25E073FC)]
	public partial class PageListItemBlocks : PageListItem { public PageBlock[] blocks; }

	///<summary>See <a href="https://corefork.telegram.org/type/PageListOrderedItem"/></summary>
	public abstract partial class PageListOrderedItem : ITLObject { public string num; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageListOrderedItemText"/></summary>
	[TLDef(0x5E068047)]
	public partial class PageListOrderedItemText : PageListOrderedItem { public RichText text; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/pageListOrderedItemBlocks"/></summary>
	[TLDef(0x98DD8936)]
	public partial class PageListOrderedItemBlocks : PageListOrderedItem { public PageBlock[] blocks; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/pageRelatedArticle"/></summary>
	[TLDef(0xB390DC08)]
	public partial class PageRelatedArticle : ITLObject
	{
		[Flags] public enum Flags { has_title = 0x1, has_description = 0x2, has_photo_id = 0x4, has_author = 0x8, 
			has_published_date = 0x10 }
		public Flags flags;
		public string url;
		public long webpage_id;
		[IfFlag(0)] public string title;
		[IfFlag(1)] public string description;
		[IfFlag(2)] public long photo_id;
		[IfFlag(3)] public string author;
		[IfFlag(4)] public DateTime published_date;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/page"/></summary>
	[TLDef(0x98657F0D)]
	public partial class Page : ITLObject
	{
		[Flags] public enum Flags { part = 0x1, rtl = 0x2, v2 = 0x4, has_views = 0x8 }
		public Flags flags;
		public string url;
		public PageBlock[] blocks;
		public PhotoBase[] photos;
		public DocumentBase[] documents;
		[IfFlag(3)] public int views;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/help.supportName"/></summary>
	[TLDef(0x8C05F1C9)]
	public partial class Help_SupportName : ITLObject { public string name; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/help.userInfo"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.userInfoEmpty">help.userInfoEmpty</a></remarks>
	[TLDef(0x01EB3758)]
	public partial class Help_UserInfo : ITLObject
	{
		public string message;
		public MessageEntity[] entities;
		public string author;
		public DateTime date;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/pollAnswer"/></summary>
	[TLDef(0x6CA9C2E9)]
	public partial class PollAnswer : ITLObject
	{
		public string text;
		public byte[] option;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/poll"/></summary>
	[TLDef(0x86E18161)]
	public partial class Poll : ITLObject
	{
		[Flags] public enum Flags { closed = 0x1, public_voters = 0x2, multiple_choice = 0x4, quiz = 0x8, has_close_period = 0x10, 
			has_close_date = 0x20 }
		public long id;
		public Flags flags;
		public string question;
		public PollAnswer[] answers;
		[IfFlag(4)] public int close_period;
		[IfFlag(5)] public DateTime close_date;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/pollAnswerVoters"/></summary>
	[TLDef(0x3B6DDAD2)]
	public partial class PollAnswerVoters : ITLObject
	{
		[Flags] public enum Flags { chosen = 0x1, correct = 0x2 }
		public Flags flags;
		public byte[] option;
		public int voters;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/pollResults"/></summary>
	[TLDef(0xDCB82EA3)]
	public partial class PollResults : ITLObject
	{
		[Flags] public enum Flags { min = 0x1, has_results = 0x2, has_total_voters = 0x4, has_recent_voters = 0x8, has_solution = 0x10 }
		public Flags flags;
		[IfFlag(1)] public PollAnswerVoters[] results;
		[IfFlag(2)] public int total_voters;
		[IfFlag(3)] public long[] recent_voters;
		[IfFlag(4)] public string solution;
		[IfFlag(4)] public MessageEntity[] solution_entities;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/chatOnlines"/></summary>
	[TLDef(0xF041E250)]
	public partial class ChatOnlines : ITLObject { public int onlines; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/statsURL"/></summary>
	[TLDef(0x47A971E0)]
	public partial class StatsURL : ITLObject { public string url; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/chatAdminRights"/></summary>
	[TLDef(0x5FB224D5)]
	public partial class ChatAdminRights : ITLObject
	{
		[Flags] public enum Flags { change_info = 0x1, post_messages = 0x2, edit_messages = 0x4, delete_messages = 0x8, 
			ban_users = 0x10, invite_users = 0x20, pin_messages = 0x80, add_admins = 0x200, anonymous = 0x400, manage_call = 0x800, 
			other = 0x1000 }
		public Flags flags;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/chatBannedRights"/></summary>
	[TLDef(0x9F120418)]
	public partial class ChatBannedRights : ITLObject
	{
		[Flags] public enum Flags { view_messages = 0x1, send_messages = 0x2, send_media = 0x4, send_stickers = 0x8, send_gifs = 0x10, 
			send_games = 0x20, send_inline = 0x40, embed_links = 0x80, send_polls = 0x100, change_info = 0x400, invite_users = 0x8000, 
			pin_messages = 0x20000 }
		public Flags flags;
		public DateTime until_date;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/InputWallPaper"/></summary>
	public abstract partial class InputWallPaperBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputWallPaper"/></summary>
	[TLDef(0xE630B979)]
	public partial class InputWallPaper : InputWallPaperBase
	{
		public long id;
		public long access_hash;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputWallPaperSlug"/></summary>
	[TLDef(0x72091C80)]
	public partial class InputWallPaperSlug : InputWallPaperBase { public string slug; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputWallPaperNoFile"/></summary>
	[TLDef(0x967A462E)]
	public partial class InputWallPaperNoFile : InputWallPaperBase { public long id; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/account.wallPapers"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/account.wallPapersNotModified">account.wallPapersNotModified</a></remarks>
	[TLDef(0xCDC3858C)]
	public partial class Account_WallPapers : ITLObject
	{
		public long hash;
		public WallPaperBase[] wallpapers;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/codeSettings"/></summary>
	[TLDef(0xDEBEBE83)]
	public partial class CodeSettings : ITLObject
	{
		[Flags] public enum Flags { allow_flashcall = 0x1, current_number = 0x2, allow_app_hash = 0x10 }
		public Flags flags;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/wallPaperSettings"/></summary>
	[TLDef(0x1DC1BCA4)]
	public partial class WallPaperSettings : ITLObject
	{
		[Flags] public enum Flags { has_background_color = 0x1, blur = 0x2, motion = 0x4, has_intensity = 0x8, 
			has_second_background_color = 0x10, has_third_background_color = 0x20, has_fourth_background_color = 0x40 }
		public Flags flags;
		[IfFlag(0)] public int background_color;
		[IfFlag(4)] public int second_background_color;
		[IfFlag(5)] public int third_background_color;
		[IfFlag(6)] public int fourth_background_color;
		[IfFlag(3)] public int intensity;
		[IfFlag(4)] public int rotation;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/autoDownloadSettings"/></summary>
	[TLDef(0xE04232F3)]
	public partial class AutoDownloadSettings : ITLObject
	{
		[Flags] public enum Flags { disabled = 0x1, video_preload_large = 0x2, audio_preload_next = 0x4, phonecalls_less_data = 0x8 }
		public Flags flags;
		public int photo_size_max;
		public int video_size_max;
		public int file_size_max;
		public int video_upload_maxbitrate;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/account.autoDownloadSettings"/></summary>
	[TLDef(0x63CACF26)]
	public partial class Account_AutoDownloadSettings : ITLObject
	{
		public AutoDownloadSettings low;
		public AutoDownloadSettings medium;
		public AutoDownloadSettings high;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/emojiKeyword"/></summary>
	[TLDef(0xD5B3B9F9)]
	public partial class EmojiKeyword : ITLObject
	{
		public string keyword;
		public string[] emoticons;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/emojiKeywordDeleted"/></summary>
	[TLDef(0x236DF622)]
	public partial class EmojiKeywordDeleted : EmojiKeyword { }

	///<summary>See <a href="https://corefork.telegram.org/constructor/emojiKeywordsDifference"/></summary>
	[TLDef(0x5CC761BD)]
	public partial class EmojiKeywordsDifference : ITLObject
	{
		public string lang_code;
		public int from_version;
		public int version;
		public EmojiKeyword[] keywords;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/emojiURL"/></summary>
	[TLDef(0xA575739D)]
	public partial class EmojiURL : ITLObject { public string url; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/emojiLanguage"/></summary>
	[TLDef(0xB3FB5361)]
	public partial class EmojiLanguage : ITLObject { public string lang_code; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/folder"/></summary>
	[TLDef(0xFF544E65)]
	public partial class Folder : ITLObject
	{
		[Flags] public enum Flags { autofill_new_broadcasts = 0x1, autofill_public_groups = 0x2, autofill_new_correspondents = 0x4, 
			has_photo = 0x8 }
		public Flags flags;
		public int id;
		public string title;
		[IfFlag(3)] public ChatPhoto photo;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/inputFolderPeer"/></summary>
	[TLDef(0xFBD2C296)]
	public partial class InputFolderPeer : ITLObject
	{
		public InputPeer peer;
		public int folder_id;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/folderPeer"/></summary>
	[TLDef(0xE9BAA668)]
	public partial class FolderPeer : ITLObject
	{
		public Peer peer;
		public int folder_id;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.searchCounter"/></summary>
	[TLDef(0xE844EBFF)]
	public partial class Messages_SearchCounter : ITLObject
	{
		[Flags] public enum Flags { inexact = 0x2 }
		public Flags flags;
		public MessagesFilter filter;
		public int count;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/UrlAuthResult"/></summary>
	public abstract partial class UrlAuthResult : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/urlAuthResultRequest"/></summary>
	[TLDef(0x92D33A0E)]
	public partial class UrlAuthResultRequest : UrlAuthResult
	{
		[Flags] public enum Flags { request_write_access = 0x1 }
		public Flags flags;
		public UserBase bot;
		public string domain;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/urlAuthResultAccepted"/></summary>
	[TLDef(0x8F8C0E4E)]
	public partial class UrlAuthResultAccepted : UrlAuthResult { public string url; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/urlAuthResultDefault"/></summary>
	[TLDef(0xA9D6DB1F)]
	public partial class UrlAuthResultDefault : UrlAuthResult { }

	///<summary>See <a href="https://corefork.telegram.org/constructor/channelLocation"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/channelLocationEmpty">channelLocationEmpty</a></remarks>
	[TLDef(0x209B82DB)]
	public partial class ChannelLocation : ITLObject
	{
		public GeoPoint geo_point;
		public string address;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/PeerLocated"/></summary>
	public abstract partial class PeerLocatedBase : ITLObject
	{
		public abstract DateTime Expires { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/peerLocated"/></summary>
	[TLDef(0xCA461B5D)]
	public partial class PeerLocated : PeerLocatedBase
	{
		public Peer peer;
		public DateTime expires;
		public int distance;

		public override DateTime Expires => expires;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/peerSelfLocated"/></summary>
	[TLDef(0xF8EC284B)]
	public partial class PeerSelfLocated : PeerLocatedBase
	{
		public DateTime expires;

		public override DateTime Expires => expires;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/restrictionReason"/></summary>
	[TLDef(0xD072ACB4)]
	public partial class RestrictionReason : ITLObject
	{
		public string platform;
		public string reason;
		public string text;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/InputTheme"/></summary>
	public abstract partial class InputThemeBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputTheme"/></summary>
	[TLDef(0x3C5693E9)]
	public partial class InputTheme : InputThemeBase
	{
		public long id;
		public long access_hash;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/inputThemeSlug"/></summary>
	[TLDef(0xF5890DF1)]
	public partial class InputThemeSlug : InputThemeBase { public string slug; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/theme"/></summary>
	[TLDef(0xE802B8DC)]
	public partial class Theme : ITLObject
	{
		[Flags] public enum Flags { creator = 0x1, default_ = 0x2, has_document = 0x4, has_settings = 0x8, has_installs_count = 0x10, 
			for_chat = 0x20 }
		public Flags flags;
		public long id;
		public long access_hash;
		public string slug;
		public string title;
		[IfFlag(2)] public DocumentBase document;
		[IfFlag(3)] public ThemeSettings settings;
		[IfFlag(4)] public int installs_count;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/account.themes"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/account.themesNotModified">account.themesNotModified</a></remarks>
	[TLDef(0x9A3D8C6D)]
	public partial class Account_Themes : ITLObject
	{
		public long hash;
		public Theme[] themes;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/auth.LoginToken"/></summary>
	public abstract partial class Auth_LoginTokenBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/auth.loginToken"/></summary>
	[TLDef(0x629F1980)]
	public partial class Auth_LoginToken : Auth_LoginTokenBase
	{
		public DateTime expires;
		public byte[] token;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/auth.loginTokenMigrateTo"/></summary>
	[TLDef(0x068E9916)]
	public partial class Auth_LoginTokenMigrateTo : Auth_LoginTokenBase
	{
		public int dc_id;
		public byte[] token;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/auth.loginTokenSuccess"/></summary>
	[TLDef(0x390D5C5E)]
	public partial class Auth_LoginTokenSuccess : Auth_LoginTokenBase { public Auth_AuthorizationBase authorization; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/account.contentSettings"/></summary>
	[TLDef(0x57E28221)]
	public partial class Account_ContentSettings : ITLObject
	{
		[Flags] public enum Flags { sensitive_enabled = 0x1, sensitive_can_change = 0x2 }
		public Flags flags;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.inactiveChats"/></summary>
	[TLDef(0xA927FEC5)]
	public partial class Messages_InactiveChats : ITLObject
	{
		public int[] dates;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	///<summary>See <a href="https://corefork.telegram.org/type/BaseTheme"/></summary>
	public enum BaseTheme : uint
	{
		///<summary>See <a href="https://corefork.telegram.org/constructor/baseThemeClassic"/></summary>
		Classic = 0xC3A12462,
		///<summary>See <a href="https://corefork.telegram.org/constructor/baseThemeDay"/></summary>
		Day = 0xFBD81688,
		///<summary>See <a href="https://corefork.telegram.org/constructor/baseThemeNight"/></summary>
		Night = 0xB7B31EA8,
		///<summary>See <a href="https://corefork.telegram.org/constructor/baseThemeTinted"/></summary>
		Tinted = 0x6D5F77EE,
		///<summary>See <a href="https://corefork.telegram.org/constructor/baseThemeArctic"/></summary>
		Arctic = 0x5B11125A,
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/inputThemeSettings"/></summary>
	[TLDef(0x8FDE504F)]
	public partial class InputThemeSettings : ITLObject
	{
		[Flags] public enum Flags { has_message_colors = 0x1, has_wallpaper = 0x2, message_colors_animated = 0x4, 
			has_outbox_accent_color = 0x8 }
		public Flags flags;
		public BaseTheme base_theme;
		public int accent_color;
		[IfFlag(3)] public int outbox_accent_color;
		[IfFlag(0)] public int[] message_colors;
		[IfFlag(1)] public InputWallPaperBase wallpaper;
		[IfFlag(1)] public WallPaperSettings wallpaper_settings;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/themeSettings"/></summary>
	[TLDef(0xFA58B6D4)]
	public partial class ThemeSettings : ITLObject
	{
		[Flags] public enum Flags { has_message_colors = 0x1, has_wallpaper = 0x2, message_colors_animated = 0x4, 
			has_outbox_accent_color = 0x8 }
		public Flags flags;
		public BaseTheme base_theme;
		public int accent_color;
		[IfFlag(3)] public int outbox_accent_color;
		[IfFlag(0)] public int[] message_colors;
		[IfFlag(1)] public WallPaperBase wallpaper;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/WebPageAttribute"/></summary>
	public abstract partial class WebPageAttribute : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/webPageAttributeTheme"/></summary>
	[TLDef(0x54B56617)]
	public partial class WebPageAttributeTheme : WebPageAttribute
	{
		[Flags] public enum Flags { has_documents = 0x1, has_settings = 0x2 }
		public Flags flags;
		[IfFlag(0)] public DocumentBase[] documents;
		[IfFlag(1)] public ThemeSettings settings;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/MessageUserVote"/></summary>
	public abstract partial class MessageUserVoteBase : ITLObject
	{
		public abstract long UserId { get; }
		public abstract DateTime Date { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageUserVote"/></summary>
	[TLDef(0x34D247B4)]
	public partial class MessageUserVote : MessageUserVoteBase
	{
		public long user_id;
		public byte[] option;
		public DateTime date;

		public override long UserId => user_id;
		public override DateTime Date => date;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageUserVoteInputOption"/></summary>
	[TLDef(0x3CA5B0EC)]
	public partial class MessageUserVoteInputOption : MessageUserVoteBase
	{
		public long user_id;
		public DateTime date;

		public override long UserId => user_id;
		public override DateTime Date => date;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messageUserVoteMultiple"/></summary>
	[TLDef(0x8A65E557)]
	public partial class MessageUserVoteMultiple : MessageUserVoteBase
	{
		public long user_id;
		public byte[][] options;
		public DateTime date;

		public override long UserId => user_id;
		public override DateTime Date => date;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.votesList"/></summary>
	[TLDef(0x0823F649)]
	public partial class Messages_VotesList : ITLObject
	{
		[Flags] public enum Flags { has_next_offset = 0x1 }
		public Flags flags;
		public int count;
		public MessageUserVoteBase[] votes;
		public Dictionary<long, UserBase> users;
		[IfFlag(0)] public string next_offset;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/bankCardOpenUrl"/></summary>
	[TLDef(0xF568028A)]
	public partial class BankCardOpenUrl : ITLObject
	{
		public string url;
		public string name;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/payments.bankCardData"/></summary>
	[TLDef(0x3E24E573)]
	public partial class Payments_BankCardData : ITLObject
	{
		public string title;
		public BankCardOpenUrl[] open_urls;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/dialogFilter"/></summary>
	[TLDef(0x7438F7E8)]
	public partial class DialogFilter : ITLObject
	{
		[Flags] public enum Flags { contacts = 0x1, non_contacts = 0x2, groups = 0x4, broadcasts = 0x8, bots = 0x10, 
			exclude_muted = 0x800, exclude_read = 0x1000, exclude_archived = 0x2000, has_emoticon = 0x2000000 }
		public Flags flags;
		public int id;
		public string title;
		[IfFlag(25)] public string emoticon;
		public InputPeer[] pinned_peers;
		public InputPeer[] include_peers;
		public InputPeer[] exclude_peers;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/dialogFilterSuggested"/></summary>
	[TLDef(0x77744D4A)]
	public partial class DialogFilterSuggested : ITLObject
	{
		public DialogFilter filter;
		public string description;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/statsDateRangeDays"/></summary>
	[TLDef(0xB637EDAF)]
	public partial class StatsDateRangeDays : ITLObject
	{
		public DateTime min_date;
		public DateTime max_date;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/statsAbsValueAndPrev"/></summary>
	[TLDef(0xCB43ACDE)]
	public partial class StatsAbsValueAndPrev : ITLObject
	{
		public double current;
		public double previous;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/statsPercentValue"/></summary>
	[TLDef(0xCBCE2FE0)]
	public partial class StatsPercentValue : ITLObject
	{
		public double part;
		public double total;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/StatsGraph"/></summary>
	public abstract partial class StatsGraphBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/statsGraphAsync"/></summary>
	[TLDef(0x4A27EB2D)]
	public partial class StatsGraphAsync : StatsGraphBase { public string token; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/statsGraphError"/></summary>
	[TLDef(0xBEDC9822)]
	public partial class StatsGraphError : StatsGraphBase { public string error; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/statsGraph"/></summary>
	[TLDef(0x8EA464B6)]
	public partial class StatsGraph : StatsGraphBase
	{
		[Flags] public enum Flags { has_zoom_token = 0x1 }
		public Flags flags;
		public DataJSON json;
		[IfFlag(0)] public string zoom_token;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messageInteractionCounters"/></summary>
	[TLDef(0xAD4FC9BD)]
	public partial class MessageInteractionCounters : ITLObject
	{
		public int msg_id;
		public int views;
		public int forwards;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/stats.broadcastStats"/></summary>
	[TLDef(0xBDF78394)]
	public partial class Stats_BroadcastStats : ITLObject
	{
		public StatsDateRangeDays period;
		public StatsAbsValueAndPrev followers;
		public StatsAbsValueAndPrev views_per_post;
		public StatsAbsValueAndPrev shares_per_post;
		public StatsPercentValue enabled_notifications;
		public StatsGraphBase growth_graph;
		public StatsGraphBase followers_graph;
		public StatsGraphBase mute_graph;
		public StatsGraphBase top_hours_graph;
		public StatsGraphBase interactions_graph;
		public StatsGraphBase iv_interactions_graph;
		public StatsGraphBase views_by_source_graph;
		public StatsGraphBase new_followers_by_source_graph;
		public StatsGraphBase languages_graph;
		public MessageInteractionCounters[] recent_message_interactions;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/help.PromoData"/></summary>
	public abstract partial class Help_PromoDataBase : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/help.promoDataEmpty"/></summary>
	[TLDef(0x98F6AC75)]
	public partial class Help_PromoDataEmpty : Help_PromoDataBase { public DateTime expires; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/help.promoData"/></summary>
	[TLDef(0x8C39793F)]
	public partial class Help_PromoData : Help_PromoDataBase
	{
		[Flags] public enum Flags { proxy = 0x1, has_psa_type = 0x2, has_psa_message = 0x4 }
		public Flags flags;
		public DateTime expires;
		public Peer peer;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;
		[IfFlag(1)] public string psa_type;
		[IfFlag(2)] public string psa_message;
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/videoSize"/></summary>
	[TLDef(0xDE33B094)]
	public partial class VideoSize : ITLObject
	{
		[Flags] public enum Flags { has_video_start_ts = 0x1 }
		public Flags flags;
		public string type;
		public int w;
		public int h;
		public int size;
		[IfFlag(0)] public double video_start_ts;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/statsGroupTopPoster"/></summary>
	[TLDef(0x9D04AF9B)]
	public partial class StatsGroupTopPoster : ITLObject
	{
		public long user_id;
		public int messages;
		public int avg_chars;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/statsGroupTopAdmin"/></summary>
	[TLDef(0xD7584C87)]
	public partial class StatsGroupTopAdmin : ITLObject
	{
		public long user_id;
		public int deleted;
		public int kicked;
		public int banned;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/statsGroupTopInviter"/></summary>
	[TLDef(0x535F779D)]
	public partial class StatsGroupTopInviter : ITLObject
	{
		public long user_id;
		public int invitations;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/stats.megagroupStats"/></summary>
	[TLDef(0xEF7FF916)]
	public partial class Stats_MegagroupStats : ITLObject
	{
		public StatsDateRangeDays period;
		public StatsAbsValueAndPrev members;
		public StatsAbsValueAndPrev messages;
		public StatsAbsValueAndPrev viewers;
		public StatsAbsValueAndPrev posters;
		public StatsGraphBase growth_graph;
		public StatsGraphBase members_graph;
		public StatsGraphBase new_members_by_source_graph;
		public StatsGraphBase languages_graph;
		public StatsGraphBase messages_graph;
		public StatsGraphBase actions_graph;
		public StatsGraphBase top_hours_graph;
		public StatsGraphBase weekdays_graph;
		public StatsGroupTopPoster[] top_posters;
		public StatsGroupTopAdmin[] top_admins;
		public StatsGroupTopInviter[] top_inviters;
		public Dictionary<long, UserBase> users;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/globalPrivacySettings"/></summary>
	[TLDef(0xBEA2F424)]
	public partial class GlobalPrivacySettings : ITLObject
	{
		[Flags] public enum Flags { has_archive_and_mute_new_noncontact_peers = 0x1 }
		public Flags flags;
		[IfFlag(0)] public bool archive_and_mute_new_noncontact_peers;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/help.countryCode"/></summary>
	[TLDef(0x4203C5EF)]
	public partial class Help_CountryCode : ITLObject
	{
		[Flags] public enum Flags { has_prefixes = 0x1, has_patterns = 0x2 }
		public Flags flags;
		public string country_code;
		[IfFlag(0)] public string[] prefixes;
		[IfFlag(1)] public string[] patterns;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/help.country"/></summary>
	[TLDef(0xC3878E23)]
	public partial class Help_Country : ITLObject
	{
		[Flags] public enum Flags { hidden = 0x1, has_name = 0x2 }
		public Flags flags;
		public string iso2;
		public string default_name;
		[IfFlag(1)] public string name;
		public Help_CountryCode[] country_codes;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/help.countriesList"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/help.countriesListNotModified">help.countriesListNotModified</a></remarks>
	[TLDef(0x87D0759E)]
	public partial class Help_CountriesList : ITLObject
	{
		public Help_Country[] countries;
		public int hash;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messageViews"/></summary>
	[TLDef(0x455B853D)]
	public partial class MessageViews : ITLObject
	{
		[Flags] public enum Flags { has_views = 0x1, has_forwards = 0x2, has_replies = 0x4 }
		public Flags flags;
		[IfFlag(0)] public int views;
		[IfFlag(1)] public int forwards;
		[IfFlag(2)] public MessageReplies replies;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.messageViews"/></summary>
	[TLDef(0xB6C4F543)]
	public partial class Messages_MessageViews : ITLObject
	{
		public MessageViews[] views;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.discussionMessage"/></summary>
	[TLDef(0xA6341782)]
	public partial class Messages_DiscussionMessage : ITLObject
	{
		[Flags] public enum Flags { has_max_id = 0x1, has_read_inbox_max_id = 0x2, has_read_outbox_max_id = 0x4 }
		public Flags flags;
		public MessageBase[] messages;
		[IfFlag(0)] public int max_id;
		[IfFlag(1)] public int read_inbox_max_id;
		[IfFlag(2)] public int read_outbox_max_id;
		public int unread_count;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messageReplyHeader"/></summary>
	[TLDef(0xA6D57763)]
	public partial class MessageReplyHeader : ITLObject
	{
		[Flags] public enum Flags { has_reply_to_peer_id = 0x1, has_reply_to_top_id = 0x2 }
		public Flags flags;
		public int reply_to_msg_id;
		[IfFlag(0)] public Peer reply_to_peer_id;
		[IfFlag(1)] public int reply_to_top_id;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messageReplies"/></summary>
	[TLDef(0x83D60FC2)]
	public partial class MessageReplies : ITLObject
	{
		[Flags] public enum Flags { comments = 0x1, has_recent_repliers = 0x2, has_max_id = 0x4, has_read_max_id = 0x8 }
		public Flags flags;
		public int replies;
		public int replies_pts;
		[IfFlag(1)] public Peer[] recent_repliers;
		[IfFlag(0)] public long channel_id;
		[IfFlag(2)] public int max_id;
		[IfFlag(3)] public int read_max_id;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/peerBlocked"/></summary>
	[TLDef(0xE8FD8014)]
	public partial class PeerBlocked : ITLObject
	{
		public Peer peer_id;
		public DateTime date;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/stats.messageStats"/></summary>
	[TLDef(0x8999F295)]
	public partial class Stats_MessageStats : ITLObject { public StatsGraphBase views_graph; }

	///<summary>See <a href="https://corefork.telegram.org/type/GroupCall"/></summary>
	public abstract partial class GroupCallBase : ITLObject
	{
		public abstract long ID { get; }
		public abstract long AccessHash { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/groupCallDiscarded"/></summary>
	[TLDef(0x7780BCB4)]
	public partial class GroupCallDiscarded : GroupCallBase
	{
		public long id;
		public long access_hash;
		public int duration;

		public override long ID => id;
		public override long AccessHash => access_hash;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/groupCall"/></summary>
	[TLDef(0xD597650C)]
	public partial class GroupCall : GroupCallBase
	{
		[Flags] public enum Flags { join_muted = 0x2, can_change_join_muted = 0x4, has_title = 0x8, has_stream_dc_id = 0x10, 
			has_record_start_date = 0x20, join_date_asc = 0x40, has_schedule_date = 0x80, schedule_start_subscribed = 0x100, 
			can_start_video = 0x200, has_unmuted_video_count = 0x400, record_video_active = 0x800 }
		public Flags flags;
		public long id;
		public long access_hash;
		public int participants_count;
		[IfFlag(3)] public string title;
		[IfFlag(4)] public int stream_dc_id;
		[IfFlag(5)] public DateTime record_start_date;
		[IfFlag(7)] public DateTime schedule_date;
		[IfFlag(10)] public int unmuted_video_count;
		public int unmuted_video_limit;
		public int version;

		public override long ID => id;
		public override long AccessHash => access_hash;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/inputGroupCall"/></summary>
	[TLDef(0xD8AA840F)]
	public partial class InputGroupCall : ITLObject
	{
		public long id;
		public long access_hash;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/groupCallParticipant"/></summary>
	[TLDef(0xEBA636FE)]
	public partial class GroupCallParticipant : ITLObject
	{
		[Flags] public enum Flags { muted = 0x1, left = 0x2, can_self_unmute = 0x4, has_active_date = 0x8, just_joined = 0x10, 
			versioned = 0x20, has_video = 0x40, has_volume = 0x80, min = 0x100, muted_by_you = 0x200, volume_by_admin = 0x400, 
			has_about = 0x800, self = 0x1000, has_raise_hand_rating = 0x2000, has_presentation = 0x4000, video_joined = 0x8000 }
		public Flags flags;
		public Peer peer;
		public DateTime date;
		[IfFlag(3)] public DateTime active_date;
		public int source;
		[IfFlag(7)] public int volume;
		[IfFlag(11)] public string about;
		[IfFlag(13)] public long raise_hand_rating;
		[IfFlag(6)] public GroupCallParticipantVideo video;
		[IfFlag(14)] public GroupCallParticipantVideo presentation;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/phone.groupCall"/></summary>
	[TLDef(0x9E727AAD)]
	public partial class Phone_GroupCall : ITLObject
	{
		public GroupCallBase call;
		public GroupCallParticipant[] participants;
		public string participants_next_offset;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/phone.groupParticipants"/></summary>
	[TLDef(0xF47751B6)]
	public partial class Phone_GroupParticipants : ITLObject
	{
		public int count;
		public GroupCallParticipant[] participants;
		public string next_offset;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;
		public int version;
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	///<summary>See <a href="https://corefork.telegram.org/type/InlineQueryPeerType"/></summary>
	public enum InlineQueryPeerType : uint
	{
		///<summary>See <a href="https://corefork.telegram.org/constructor/inlineQueryPeerTypeSameBotPM"/></summary>
		SameBotPM = 0x3081ED9D,
		///<summary>See <a href="https://corefork.telegram.org/constructor/inlineQueryPeerTypePM"/></summary>
		PM = 0x833C0FAC,
		///<summary>See <a href="https://corefork.telegram.org/constructor/inlineQueryPeerTypeChat"/></summary>
		Chat = 0xD766C50A,
		///<summary>See <a href="https://corefork.telegram.org/constructor/inlineQueryPeerTypeMegagroup"/></summary>
		Megagroup = 0x5EC4BE43,
		///<summary>See <a href="https://corefork.telegram.org/constructor/inlineQueryPeerTypeBroadcast"/></summary>
		Broadcast = 0x6334EE9A,
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.historyImport"/></summary>
	[TLDef(0x1662AF0B)]
	public partial class Messages_HistoryImport : ITLObject { public long id; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.historyImportParsed"/></summary>
	[TLDef(0x5E0FB7B9)]
	public partial class Messages_HistoryImportParsed : ITLObject
	{
		[Flags] public enum Flags { pm = 0x1, group = 0x2, has_title = 0x4 }
		public Flags flags;
		[IfFlag(2)] public string title;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.affectedFoundMessages"/></summary>
	[TLDef(0xEF8D3E6C)]
	public partial class Messages_AffectedFoundMessages : ITLObject
	{
		public int pts;
		public int pts_count;
		public int offset;
		public int[] messages;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/chatInviteImporter"/></summary>
	[TLDef(0x0B5CD5F4)]
	public partial class ChatInviteImporter : ITLObject
	{
		public long user_id;
		public DateTime date;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.exportedChatInvites"/></summary>
	[TLDef(0xBDC62DCC)]
	public partial class Messages_ExportedChatInvites : ITLObject
	{
		public int count;
		public ExportedChatInvite[] invites;
		public Dictionary<long, UserBase> users;
	}

	///<summary>See <a href="https://corefork.telegram.org/type/messages.ExportedChatInvite"/></summary>
	public abstract partial class Messages_ExportedChatInviteBase : ITLObject
	{
		public abstract ExportedChatInvite Invite { get; }
		public abstract Dictionary<long, UserBase> Users { get; }
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.exportedChatInvite"/></summary>
	[TLDef(0x1871BE50)]
	public partial class Messages_ExportedChatInvite : Messages_ExportedChatInviteBase
	{
		public ExportedChatInvite invite;
		public Dictionary<long, UserBase> users;

		public override ExportedChatInvite Invite => invite;
		public override Dictionary<long, UserBase> Users => users;
	}
	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.exportedChatInviteReplaced"/></summary>
	[TLDef(0x222600EF)]
	public partial class Messages_ExportedChatInviteReplaced : Messages_ExportedChatInviteBase
	{
		public ExportedChatInvite invite;
		public ExportedChatInvite new_invite;
		public Dictionary<long, UserBase> users;

		public override ExportedChatInvite Invite => invite;
		public override Dictionary<long, UserBase> Users => users;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.chatInviteImporters"/></summary>
	[TLDef(0x81B6B00A)]
	public partial class Messages_ChatInviteImporters : ITLObject
	{
		public int count;
		public ChatInviteImporter[] importers;
		public Dictionary<long, UserBase> users;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/chatAdminWithInvites"/></summary>
	[TLDef(0xF2ECEF23)]
	public partial class ChatAdminWithInvites : ITLObject
	{
		public long admin_id;
		public int invites_count;
		public int revoked_invites_count;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.chatAdminsWithInvites"/></summary>
	[TLDef(0xB69B72D7)]
	public partial class Messages_ChatAdminsWithInvites : ITLObject
	{
		public ChatAdminWithInvites[] admins;
		public Dictionary<long, UserBase> users;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.checkedHistoryImportPeer"/></summary>
	[TLDef(0xA24DE717)]
	public partial class Messages_CheckedHistoryImportPeer : ITLObject { public string confirm_text; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/phone.joinAsPeers"/></summary>
	[TLDef(0xAFE5623F)]
	public partial class Phone_JoinAsPeers : ITLObject
	{
		public Peer[] peers;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/phone.exportedGroupCallInvite"/></summary>
	[TLDef(0x204BD158)]
	public partial class Phone_ExportedGroupCallInvite : ITLObject { public string link; }

	///<summary>See <a href="https://corefork.telegram.org/constructor/groupCallParticipantVideoSourceGroup"/></summary>
	[TLDef(0xDCB118B7)]
	public partial class GroupCallParticipantVideoSourceGroup : ITLObject
	{
		public string semantics;
		public int[] sources;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/groupCallParticipantVideo"/></summary>
	[TLDef(0x67753AC8)]
	public partial class GroupCallParticipantVideo : ITLObject
	{
		[Flags] public enum Flags { paused = 0x1, has_audio_source = 0x2 }
		public Flags flags;
		public string endpoint;
		public GroupCallParticipantVideoSourceGroup[] source_groups;
		[IfFlag(1)] public int audio_source;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/stickers.suggestedShortName"/></summary>
	[TLDef(0x85FEA03F)]
	public partial class Stickers_SuggestedShortName : ITLObject { public string short_name; }

	///<summary>See <a href="https://corefork.telegram.org/type/BotCommandScope"/></summary>
	public abstract partial class BotCommandScope : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/botCommandScopeDefault"/></summary>
	[TLDef(0x2F6CB2AB)]
	public partial class BotCommandScopeDefault : BotCommandScope { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/botCommandScopeUsers"/></summary>
	[TLDef(0x3C4F04D8)]
	public partial class BotCommandScopeUsers : BotCommandScope { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/botCommandScopeChats"/></summary>
	[TLDef(0x6FE1A881)]
	public partial class BotCommandScopeChats : BotCommandScope { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/botCommandScopeChatAdmins"/></summary>
	[TLDef(0xB9AA606A)]
	public partial class BotCommandScopeChatAdmins : BotCommandScope { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/botCommandScopePeer"/></summary>
	[TLDef(0xDB9D897D)]
	public partial class BotCommandScopePeer : BotCommandScope { public InputPeer peer; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/botCommandScopePeerAdmins"/></summary>
	[TLDef(0x3FD863D1)]
	public partial class BotCommandScopePeerAdmins : BotCommandScopePeer { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/botCommandScopePeerUser"/></summary>
	[TLDef(0x0A1321F3)]
	public partial class BotCommandScopePeerUser : BotCommandScopePeer { public InputUserBase user_id; }

	///<summary>See <a href="https://corefork.telegram.org/type/account.ResetPasswordResult"/></summary>
	public abstract partial class Account_ResetPasswordResult : ITLObject { }
	///<summary>See <a href="https://corefork.telegram.org/constructor/account.resetPasswordFailedWait"/></summary>
	[TLDef(0xE3779861)]
	public partial class Account_ResetPasswordFailedWait : Account_ResetPasswordResult { public DateTime retry_date; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/account.resetPasswordRequestedWait"/></summary>
	[TLDef(0xE9EFFC7D)]
	public partial class Account_ResetPasswordRequestedWait : Account_ResetPasswordResult { public DateTime until_date; }
	///<summary>See <a href="https://corefork.telegram.org/constructor/account.resetPasswordOk"/></summary>
	[TLDef(0xE926D63E)]
	public partial class Account_ResetPasswordOk : Account_ResetPasswordResult { }

	///<summary>See <a href="https://corefork.telegram.org/constructor/chatTheme"/></summary>
	[TLDef(0xED0B5C33)]
	public partial class ChatTheme : ITLObject
	{
		public string emoticon;
		public Theme theme;
		public Theme dark_theme;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/account.chatThemes"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://corefork.telegram.org/constructor/account.chatThemesNotModified">account.chatThemesNotModified</a></remarks>
	[TLDef(0xFE4CBEBD)]
	public partial class Account_ChatThemes : ITLObject
	{
		public int hash;
		public ChatTheme[] themes;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/sponsoredMessage"/></summary>
	[TLDef(0x2A3C381F)]
	public partial class SponsoredMessage : ITLObject
	{
		[Flags] public enum Flags { has_start_param = 0x1, has_entities = 0x2 }
		public Flags flags;
		public byte[] random_id;
		public Peer from_id;
		[IfFlag(0)] public string start_param;
		public string message;
		[IfFlag(1)] public MessageEntity[] entities;
	}

	///<summary>See <a href="https://corefork.telegram.org/constructor/messages.sponsoredMessages"/></summary>
	[TLDef(0x65A4C7D5)]
	public partial class Messages_SponsoredMessages : ITLObject
	{
		public SponsoredMessage[] messages;
		public Dictionary<long, ChatBase> chats;
		public Dictionary<long, UserBase> users;
		public IPeerInfo UserOrChat(Peer peer) => peer.UserOrChat(users, chats);
	}

	// ---functions---

	public static class Schema
	{
		///<summary>See <a href="https://corefork.telegram.org/method/invokeAfterMsg"/></summary>
		public static Task<X> InvokeAfterMsg<X>(this Client client, long msg_id, ITLFunction query)
			=> client.CallAsync<X>(writer =>
			{
				writer.Write(0xCB9F372D);
				writer.Write(msg_id);
				query(writer);
				return "InvokeAfterMsg<X>";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/invokeAfterMsgs"/></summary>
		public static Task<X> InvokeAfterMsgs<X>(this Client client, long[] msg_ids, ITLFunction query)
			=> client.CallAsync<X>(writer =>
			{
				writer.Write(0x3DC4B4F0);
				writer.WriteTLVector(msg_ids);
				query(writer);
				return "InvokeAfterMsgs<X>";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/initConnection"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/invokeWithLayer"/></summary>
		public static Task<X> InvokeWithLayer<X>(this Client client, int layer, ITLFunction query)
			=> client.CallAsync<X>(writer =>
			{
				writer.Write(0xDA9B0D0D);
				writer.Write(layer);
				query(writer);
				return "InvokeWithLayer<X>";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/invokeWithoutUpdates"/></summary>
		public static Task<X> InvokeWithoutUpdates<X>(this Client client, ITLFunction query)
			=> client.CallAsync<X>(writer =>
			{
				writer.Write(0xBF9459B7);
				query(writer);
				return "InvokeWithoutUpdates<X>";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/invokeWithMessagesRange"/></summary>
		public static Task<X> InvokeWithMessagesRange<X>(this Client client, MessageRange range, ITLFunction query)
			=> client.CallAsync<X>(writer =>
			{
				writer.Write(0x365275F2);
				writer.WriteTLObject(range);
				query(writer);
				return "InvokeWithMessagesRange<X>";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/invokeWithTakeout"/></summary>
		public static Task<X> InvokeWithTakeout<X>(this Client client, long takeout_id, ITLFunction query)
			=> client.CallAsync<X>(writer =>
			{
				writer.Write(0xACA9FD2E);
				writer.Write(takeout_id);
				query(writer);
				return "InvokeWithTakeout<X>";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/auth.sendCode"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/auth.signUp"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/auth.signIn"/></summary>
		public static Task<Auth_AuthorizationBase> Auth_SignIn(this Client client, string phone_number, string phone_code_hash, string phone_code)
			=> client.CallAsync<Auth_AuthorizationBase>(writer =>
			{
				writer.Write(0xBCD51581);
				writer.WriteTLString(phone_number);
				writer.WriteTLString(phone_code_hash);
				writer.WriteTLString(phone_code);
				return "Auth_SignIn";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/auth.logOut"/></summary>
		public static Task<bool> Auth_LogOut(this Client client)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x5717DA40);
				return "Auth_LogOut";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/auth.resetAuthorizations"/></summary>
		public static Task<bool> Auth_ResetAuthorizations(this Client client)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x9FAB0D1A);
				return "Auth_ResetAuthorizations";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/auth.exportAuthorization"/></summary>
		public static Task<Auth_ExportedAuthorization> Auth_ExportAuthorization(this Client client, int dc_id)
			=> client.CallAsync<Auth_ExportedAuthorization>(writer =>
			{
				writer.Write(0xE5BFFFCD);
				writer.Write(dc_id);
				return "Auth_ExportAuthorization";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/auth.importAuthorization"/></summary>
		public static Task<Auth_AuthorizationBase> Auth_ImportAuthorization(this Client client, long id, byte[] bytes)
			=> client.CallAsync<Auth_AuthorizationBase>(writer =>
			{
				writer.Write(0xA57A7DAD);
				writer.Write(id);
				writer.WriteTLBytes(bytes);
				return "Auth_ImportAuthorization";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/auth.bindTempAuthKey"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/auth.importBotAuthorization"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/auth.checkPassword"/></summary>
		public static Task<Auth_AuthorizationBase> Auth_CheckPassword(this Client client, InputCheckPasswordSRP password)
			=> client.CallAsync<Auth_AuthorizationBase>(writer =>
			{
				writer.Write(0xD18B4D16);
				writer.WriteTLObject(password);
				return "Auth_CheckPassword";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/auth.requestPasswordRecovery"/></summary>
		public static Task<Auth_PasswordRecovery> Auth_RequestPasswordRecovery(this Client client)
			=> client.CallAsync<Auth_PasswordRecovery>(writer =>
			{
				writer.Write(0xD897BC66);
				return "Auth_RequestPasswordRecovery";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/auth.recoverPassword"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/auth.resendCode"/></summary>
		public static Task<Auth_SentCode> Auth_ResendCode(this Client client, string phone_number, string phone_code_hash)
			=> client.CallAsync<Auth_SentCode>(writer =>
			{
				writer.Write(0x3EF1A9BF);
				writer.WriteTLString(phone_number);
				writer.WriteTLString(phone_code_hash);
				return "Auth_ResendCode";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/auth.cancelCode"/></summary>
		public static Task<bool> Auth_CancelCode(this Client client, string phone_number, string phone_code_hash)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x1F040578);
				writer.WriteTLString(phone_number);
				writer.WriteTLString(phone_code_hash);
				return "Auth_CancelCode";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/auth.dropTempAuthKeys"/></summary>
		public static Task<bool> Auth_DropTempAuthKeys(this Client client, long[] except_auth_keys)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x8E48A188);
				writer.WriteTLVector(except_auth_keys);
				return "Auth_DropTempAuthKeys";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/auth.exportLoginToken"/></summary>
		public static Task<Auth_LoginTokenBase> Auth_ExportLoginToken(this Client client, int api_id, string api_hash, long[] except_ids)
			=> client.CallAsync<Auth_LoginTokenBase>(writer =>
			{
				writer.Write(0xB7E085FE);
				writer.Write(api_id);
				writer.WriteTLString(api_hash);
				writer.WriteTLVector(except_ids);
				return "Auth_ExportLoginToken";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/auth.importLoginToken"/></summary>
		public static Task<Auth_LoginTokenBase> Auth_ImportLoginToken(this Client client, byte[] token)
			=> client.CallAsync<Auth_LoginTokenBase>(writer =>
			{
				writer.Write(0x95AC5CE4);
				writer.WriteTLBytes(token);
				return "Auth_ImportLoginToken";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/auth.acceptLoginToken"/></summary>
		public static Task<Authorization> Auth_AcceptLoginToken(this Client client, byte[] token)
			=> client.CallAsync<Authorization>(writer =>
			{
				writer.Write(0xE894AD4D);
				writer.WriteTLBytes(token);
				return "Auth_AcceptLoginToken";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/auth.checkRecoveryPassword"/></summary>
		public static Task<bool> Auth_CheckRecoveryPassword(this Client client, string code)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x0D36BF79);
				writer.WriteTLString(code);
				return "Auth_CheckRecoveryPassword";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.registerDevice"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/account.unregisterDevice"/></summary>
		public static Task<bool> Account_UnregisterDevice(this Client client, int token_type, string token, long[] other_uids)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x6A0D3206);
				writer.Write(token_type);
				writer.WriteTLString(token);
				writer.WriteTLVector(other_uids);
				return "Account_UnregisterDevice";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.updateNotifySettings"/></summary>
		public static Task<bool> Account_UpdateNotifySettings(this Client client, InputNotifyPeerBase peer, InputPeerNotifySettings settings)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x84BE5B93);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(settings);
				return "Account_UpdateNotifySettings";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.getNotifySettings"/></summary>
		public static Task<PeerNotifySettings> Account_GetNotifySettings(this Client client, InputNotifyPeerBase peer)
			=> client.CallAsync<PeerNotifySettings>(writer =>
			{
				writer.Write(0x12B3AD31);
				writer.WriteTLObject(peer);
				return "Account_GetNotifySettings";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.resetNotifySettings"/></summary>
		public static Task<bool> Account_ResetNotifySettings(this Client client)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xDB7E1747);
				return "Account_ResetNotifySettings";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.updateProfile"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/account.updateStatus"/></summary>
		public static Task<bool> Account_UpdateStatus(this Client client, bool offline)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x6628562C);
				writer.Write(offline ? 0x997275B5 : 0xBC799737);
				return "Account_UpdateStatus";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.getWallPapers"/></summary>
		public static Task<Account_WallPapers> Account_GetWallPapers(this Client client, long hash)
			=> client.CallAsync<Account_WallPapers>(writer =>
			{
				writer.Write(0x07967D36);
				writer.Write(hash);
				return "Account_GetWallPapers";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.reportPeer"/></summary>
		public static Task<bool> Account_ReportPeer(this Client client, InputPeer peer, ReportReason reason, string message)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xC5BA3D86);
				writer.WriteTLObject(peer);
				writer.Write((uint)reason);
				writer.WriteTLString(message);
				return "Account_ReportPeer";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.checkUsername"/></summary>
		public static Task<bool> Account_CheckUsername(this Client client, string username)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x2714D86C);
				writer.WriteTLString(username);
				return "Account_CheckUsername";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.updateUsername"/></summary>
		public static Task<UserBase> Account_UpdateUsername(this Client client, string username)
			=> client.CallAsync<UserBase>(writer =>
			{
				writer.Write(0x3E0BDD7C);
				writer.WriteTLString(username);
				return "Account_UpdateUsername";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.getPrivacy"/></summary>
		public static Task<Account_PrivacyRules> Account_GetPrivacy(this Client client, InputPrivacyKey key)
			=> client.CallAsync<Account_PrivacyRules>(writer =>
			{
				writer.Write(0xDADBC950);
				writer.Write((uint)key);
				return "Account_GetPrivacy";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.setPrivacy"/></summary>
		public static Task<Account_PrivacyRules> Account_SetPrivacy(this Client client, InputPrivacyKey key, InputPrivacyRule[] rules)
			=> client.CallAsync<Account_PrivacyRules>(writer =>
			{
				writer.Write(0xC9F81CE8);
				writer.Write((uint)key);
				writer.WriteTLVector(rules);
				return "Account_SetPrivacy";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.deleteAccount"/></summary>
		public static Task<bool> Account_DeleteAccount(this Client client, string reason)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x418D4E0B);
				writer.WriteTLString(reason);
				return "Account_DeleteAccount";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.getAccountTTL"/></summary>
		public static Task<AccountDaysTTL> Account_GetAccountTTL(this Client client)
			=> client.CallAsync<AccountDaysTTL>(writer =>
			{
				writer.Write(0x08FC711D);
				return "Account_GetAccountTTL";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.setAccountTTL"/></summary>
		public static Task<bool> Account_SetAccountTTL(this Client client, AccountDaysTTL ttl)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x2442485E);
				writer.WriteTLObject(ttl);
				return "Account_SetAccountTTL";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.sendChangePhoneCode"/></summary>
		public static Task<Auth_SentCode> Account_SendChangePhoneCode(this Client client, string phone_number, CodeSettings settings)
			=> client.CallAsync<Auth_SentCode>(writer =>
			{
				writer.Write(0x82574AE5);
				writer.WriteTLString(phone_number);
				writer.WriteTLObject(settings);
				return "Account_SendChangePhoneCode";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.changePhone"/></summary>
		public static Task<UserBase> Account_ChangePhone(this Client client, string phone_number, string phone_code_hash, string phone_code)
			=> client.CallAsync<UserBase>(writer =>
			{
				writer.Write(0x70C32EDB);
				writer.WriteTLString(phone_number);
				writer.WriteTLString(phone_code_hash);
				writer.WriteTLString(phone_code);
				return "Account_ChangePhone";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.updateDeviceLocked"/></summary>
		public static Task<bool> Account_UpdateDeviceLocked(this Client client, int period)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x38DF3532);
				writer.Write(period);
				return "Account_UpdateDeviceLocked";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.getAuthorizations"/></summary>
		public static Task<Account_Authorizations> Account_GetAuthorizations(this Client client)
			=> client.CallAsync<Account_Authorizations>(writer =>
			{
				writer.Write(0xE320C158);
				return "Account_GetAuthorizations";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.resetAuthorization"/></summary>
		public static Task<bool> Account_ResetAuthorization(this Client client, long hash)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xDF77F3BC);
				writer.Write(hash);
				return "Account_ResetAuthorization";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.getPassword"/></summary>
		public static Task<Account_Password> Account_GetPassword(this Client client)
			=> client.CallAsync<Account_Password>(writer =>
			{
				writer.Write(0x548A30F5);
				return "Account_GetPassword";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.getPasswordSettings"/></summary>
		public static Task<Account_PasswordSettings> Account_GetPasswordSettings(this Client client, InputCheckPasswordSRP password)
			=> client.CallAsync<Account_PasswordSettings>(writer =>
			{
				writer.Write(0x9CD4EAF9);
				writer.WriteTLObject(password);
				return "Account_GetPasswordSettings";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.updatePasswordSettings"/></summary>
		public static Task<bool> Account_UpdatePasswordSettings(this Client client, InputCheckPasswordSRP password, Account_PasswordInputSettings new_settings)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xA59B102F);
				writer.WriteTLObject(password);
				writer.WriteTLObject(new_settings);
				return "Account_UpdatePasswordSettings";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.sendConfirmPhoneCode"/></summary>
		public static Task<Auth_SentCode> Account_SendConfirmPhoneCode(this Client client, string hash, CodeSettings settings)
			=> client.CallAsync<Auth_SentCode>(writer =>
			{
				writer.Write(0x1B3FAA88);
				writer.WriteTLString(hash);
				writer.WriteTLObject(settings);
				return "Account_SendConfirmPhoneCode";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.confirmPhone"/></summary>
		public static Task<bool> Account_ConfirmPhone(this Client client, string phone_code_hash, string phone_code)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x5F2178C3);
				writer.WriteTLString(phone_code_hash);
				writer.WriteTLString(phone_code);
				return "Account_ConfirmPhone";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.getTmpPassword"/></summary>
		public static Task<Account_TmpPassword> Account_GetTmpPassword(this Client client, InputCheckPasswordSRP password, int period)
			=> client.CallAsync<Account_TmpPassword>(writer =>
			{
				writer.Write(0x449E0B51);
				writer.WriteTLObject(password);
				writer.Write(period);
				return "Account_GetTmpPassword";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.getWebAuthorizations"/></summary>
		public static Task<Account_WebAuthorizations> Account_GetWebAuthorizations(this Client client)
			=> client.CallAsync<Account_WebAuthorizations>(writer =>
			{
				writer.Write(0x182E6D6F);
				return "Account_GetWebAuthorizations";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.resetWebAuthorization"/></summary>
		public static Task<bool> Account_ResetWebAuthorization(this Client client, long hash)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x2D01B9EF);
				writer.Write(hash);
				return "Account_ResetWebAuthorization";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.resetWebAuthorizations"/></summary>
		public static Task<bool> Account_ResetWebAuthorizations(this Client client)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x682D2594);
				return "Account_ResetWebAuthorizations";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.getAllSecureValues"/></summary>
		public static Task<SecureValue[]> Account_GetAllSecureValues(this Client client)
			=> client.CallAsync<SecureValue[]>(writer =>
			{
				writer.Write(0xB288BC7D);
				return "Account_GetAllSecureValues";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.getSecureValue"/></summary>
		public static Task<SecureValue[]> Account_GetSecureValue(this Client client, SecureValueType[] types)
			=> client.CallAsync<SecureValue[]>(writer =>
			{
				writer.Write(0x73665BC2);
				writer.WriteTLVector(types);
				return "Account_GetSecureValue";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.saveSecureValue"/></summary>
		public static Task<SecureValue> Account_SaveSecureValue(this Client client, InputSecureValue value, long secure_secret_id)
			=> client.CallAsync<SecureValue>(writer =>
			{
				writer.Write(0x899FE31D);
				writer.WriteTLObject(value);
				writer.Write(secure_secret_id);
				return "Account_SaveSecureValue";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.deleteSecureValue"/></summary>
		public static Task<bool> Account_DeleteSecureValue(this Client client, SecureValueType[] types)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xB880BC4B);
				writer.WriteTLVector(types);
				return "Account_DeleteSecureValue";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.getAuthorizationForm"/></summary>
		public static Task<Account_AuthorizationForm> Account_GetAuthorizationForm(this Client client, long bot_id, string scope, string public_key)
			=> client.CallAsync<Account_AuthorizationForm>(writer =>
			{
				writer.Write(0xA929597A);
				writer.Write(bot_id);
				writer.WriteTLString(scope);
				writer.WriteTLString(public_key);
				return "Account_GetAuthorizationForm";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.acceptAuthorization"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/account.sendVerifyPhoneCode"/></summary>
		public static Task<Auth_SentCode> Account_SendVerifyPhoneCode(this Client client, string phone_number, CodeSettings settings)
			=> client.CallAsync<Auth_SentCode>(writer =>
			{
				writer.Write(0xA5A356F9);
				writer.WriteTLString(phone_number);
				writer.WriteTLObject(settings);
				return "Account_SendVerifyPhoneCode";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.verifyPhone"/></summary>
		public static Task<bool> Account_VerifyPhone(this Client client, string phone_number, string phone_code_hash, string phone_code)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x4DD3A7F6);
				writer.WriteTLString(phone_number);
				writer.WriteTLString(phone_code_hash);
				writer.WriteTLString(phone_code);
				return "Account_VerifyPhone";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.sendVerifyEmailCode"/></summary>
		public static Task<Account_SentEmailCode> Account_SendVerifyEmailCode(this Client client, string email)
			=> client.CallAsync<Account_SentEmailCode>(writer =>
			{
				writer.Write(0x7011509F);
				writer.WriteTLString(email);
				return "Account_SendVerifyEmailCode";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.verifyEmail"/></summary>
		public static Task<bool> Account_VerifyEmail(this Client client, string email, string code)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xECBA39DB);
				writer.WriteTLString(email);
				writer.WriteTLString(code);
				return "Account_VerifyEmail";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.initTakeoutSession"/></summary>
		public static Task<Account_Takeout> Account_InitTakeoutSession(this Client client, bool contacts = false, bool message_users = false, bool message_chats = false, bool message_megagroups = false, bool message_channels = false, bool files = false, int? file_max_size = null)
			=> client.CallAsync<Account_Takeout>(writer =>
			{
				writer.Write(0xF05B4804);
				writer.Write((contacts ? 0x1 : 0) | (message_users ? 0x2 : 0) | (message_chats ? 0x4 : 0) | (message_megagroups ? 0x8 : 0) | (message_channels ? 0x10 : 0) | (files ? 0x20 : 0) | (file_max_size != null ? 0x20 : 0));
				if (file_max_size != null)
					writer.Write(file_max_size.Value);
				return "Account_InitTakeoutSession";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.finishTakeoutSession"/></summary>
		public static Task<bool> Account_FinishTakeoutSession(this Client client, bool success = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x1D2652EE);
				writer.Write(success ? 0x1 : 0);
				return "Account_FinishTakeoutSession";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.confirmPasswordEmail"/></summary>
		public static Task<bool> Account_ConfirmPasswordEmail(this Client client, string code)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x8FDF1920);
				writer.WriteTLString(code);
				return "Account_ConfirmPasswordEmail";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.resendPasswordEmail"/></summary>
		public static Task<bool> Account_ResendPasswordEmail(this Client client)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x7A7F2A15);
				return "Account_ResendPasswordEmail";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.cancelPasswordEmail"/></summary>
		public static Task<bool> Account_CancelPasswordEmail(this Client client)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xC1CBD5B6);
				return "Account_CancelPasswordEmail";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.getContactSignUpNotification"/></summary>
		public static Task<bool> Account_GetContactSignUpNotification(this Client client)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x9F07C728);
				return "Account_GetContactSignUpNotification";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.setContactSignUpNotification"/></summary>
		public static Task<bool> Account_SetContactSignUpNotification(this Client client, bool silent)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xCFF43F61);
				writer.Write(silent ? 0x997275B5 : 0xBC799737);
				return "Account_SetContactSignUpNotification";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.getNotifyExceptions"/></summary>
		public static Task<UpdatesBase> Account_GetNotifyExceptions(this Client client, bool compare_sound = false, InputNotifyPeerBase peer = null)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x53577479);
				writer.Write((compare_sound ? 0x2 : 0) | (peer != null ? 0x1 : 0));
				if (peer != null)
					writer.WriteTLObject(peer);
				return "Account_GetNotifyExceptions";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.getWallPaper"/></summary>
		public static Task<WallPaperBase> Account_GetWallPaper(this Client client, InputWallPaperBase wallpaper)
			=> client.CallAsync<WallPaperBase>(writer =>
			{
				writer.Write(0xFC8DDBEA);
				writer.WriteTLObject(wallpaper);
				return "Account_GetWallPaper";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.uploadWallPaper"/></summary>
		public static Task<WallPaperBase> Account_UploadWallPaper(this Client client, InputFileBase file, string mime_type, WallPaperSettings settings)
			=> client.CallAsync<WallPaperBase>(writer =>
			{
				writer.Write(0xDD853661);
				writer.WriteTLObject(file);
				writer.WriteTLString(mime_type);
				writer.WriteTLObject(settings);
				return "Account_UploadWallPaper";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.saveWallPaper"/></summary>
		public static Task<bool> Account_SaveWallPaper(this Client client, InputWallPaperBase wallpaper, bool unsave, WallPaperSettings settings)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x6C5A5B37);
				writer.WriteTLObject(wallpaper);
				writer.Write(unsave ? 0x997275B5 : 0xBC799737);
				writer.WriteTLObject(settings);
				return "Account_SaveWallPaper";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.installWallPaper"/></summary>
		public static Task<bool> Account_InstallWallPaper(this Client client, InputWallPaperBase wallpaper, WallPaperSettings settings)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xFEED5769);
				writer.WriteTLObject(wallpaper);
				writer.WriteTLObject(settings);
				return "Account_InstallWallPaper";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.resetWallPapers"/></summary>
		public static Task<bool> Account_ResetWallPapers(this Client client)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xBB3B9804);
				return "Account_ResetWallPapers";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.getAutoDownloadSettings"/></summary>
		public static Task<Account_AutoDownloadSettings> Account_GetAutoDownloadSettings(this Client client)
			=> client.CallAsync<Account_AutoDownloadSettings>(writer =>
			{
				writer.Write(0x56DA0B3F);
				return "Account_GetAutoDownloadSettings";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.saveAutoDownloadSettings"/></summary>
		public static Task<bool> Account_SaveAutoDownloadSettings(this Client client, AutoDownloadSettings settings, bool low = false, bool high = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x76F36233);
				writer.Write((low ? 0x1 : 0) | (high ? 0x2 : 0));
				writer.WriteTLObject(settings);
				return "Account_SaveAutoDownloadSettings";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.uploadTheme"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/account.createTheme"/></summary>
		public static Task<Theme> Account_CreateTheme(this Client client, string slug, string title, InputDocument document = null, InputThemeSettings settings = null)
			=> client.CallAsync<Theme>(writer =>
			{
				writer.Write(0x8432C21F);
				writer.Write((document != null ? 0x4 : 0) | (settings != null ? 0x8 : 0));
				writer.WriteTLString(slug);
				writer.WriteTLString(title);
				if (document != null)
					writer.WriteTLObject(document);
				if (settings != null)
					writer.WriteTLObject(settings);
				return "Account_CreateTheme";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.updateTheme"/></summary>
		public static Task<Theme> Account_UpdateTheme(this Client client, string format, InputThemeBase theme, string slug = null, string title = null, InputDocument document = null, InputThemeSettings settings = null)
			=> client.CallAsync<Theme>(writer =>
			{
				writer.Write(0x5CB367D5);
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
					writer.WriteTLObject(settings);
				return "Account_UpdateTheme";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.saveTheme"/></summary>
		public static Task<bool> Account_SaveTheme(this Client client, InputThemeBase theme, bool unsave)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xF257106C);
				writer.WriteTLObject(theme);
				writer.Write(unsave ? 0x997275B5 : 0xBC799737);
				return "Account_SaveTheme";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.installTheme"/></summary>
		public static Task<bool> Account_InstallTheme(this Client client, bool dark = false, string format = null, InputThemeBase theme = null)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x7AE43737);
				writer.Write((dark ? 0x1 : 0) | (format != null ? 0x2 : 0) | (theme != null ? 0x2 : 0));
				if (format != null)
					writer.WriteTLString(format);
				if (theme != null)
					writer.WriteTLObject(theme);
				return "Account_InstallTheme";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.getTheme"/></summary>
		public static Task<Theme> Account_GetTheme(this Client client, string format, InputThemeBase theme, long document_id)
			=> client.CallAsync<Theme>(writer =>
			{
				writer.Write(0x8D9D742B);
				writer.WriteTLString(format);
				writer.WriteTLObject(theme);
				writer.Write(document_id);
				return "Account_GetTheme";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.getThemes"/></summary>
		public static Task<Account_Themes> Account_GetThemes(this Client client, string format, long hash)
			=> client.CallAsync<Account_Themes>(writer =>
			{
				writer.Write(0x7206E458);
				writer.WriteTLString(format);
				writer.Write(hash);
				return "Account_GetThemes";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.setContentSettings"/></summary>
		public static Task<bool> Account_SetContentSettings(this Client client, bool sensitive_enabled = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xB574B16B);
				writer.Write(sensitive_enabled ? 0x1 : 0);
				return "Account_SetContentSettings";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.getContentSettings"/></summary>
		public static Task<Account_ContentSettings> Account_GetContentSettings(this Client client)
			=> client.CallAsync<Account_ContentSettings>(writer =>
			{
				writer.Write(0x8B9B4DAE);
				return "Account_GetContentSettings";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.getMultiWallPapers"/></summary>
		public static Task<WallPaperBase[]> Account_GetMultiWallPapers(this Client client, InputWallPaperBase[] wallpapers)
			=> client.CallAsync<WallPaperBase[]>(writer =>
			{
				writer.Write(0x65AD71DC);
				writer.WriteTLVector(wallpapers);
				return "Account_GetMultiWallPapers";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.getGlobalPrivacySettings"/></summary>
		public static Task<GlobalPrivacySettings> Account_GetGlobalPrivacySettings(this Client client)
			=> client.CallAsync<GlobalPrivacySettings>(writer =>
			{
				writer.Write(0xEB2B4CF6);
				return "Account_GetGlobalPrivacySettings";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.setGlobalPrivacySettings"/></summary>
		public static Task<GlobalPrivacySettings> Account_SetGlobalPrivacySettings(this Client client, GlobalPrivacySettings settings)
			=> client.CallAsync<GlobalPrivacySettings>(writer =>
			{
				writer.Write(0x1EDAAAC2);
				writer.WriteTLObject(settings);
				return "Account_SetGlobalPrivacySettings";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.reportProfilePhoto"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/account.resetPassword"/></summary>
		public static Task<Account_ResetPasswordResult> Account_ResetPassword(this Client client)
			=> client.CallAsync<Account_ResetPasswordResult>(writer =>
			{
				writer.Write(0x9308CE1B);
				return "Account_ResetPassword";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.declinePasswordReset"/></summary>
		public static Task<bool> Account_DeclinePasswordReset(this Client client)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x4C9409F6);
				return "Account_DeclinePasswordReset";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/account.getChatThemes"/></summary>
		public static Task<Account_ChatThemes> Account_GetChatThemes(this Client client, int hash)
			=> client.CallAsync<Account_ChatThemes>(writer =>
			{
				writer.Write(0xD6D71D7B);
				writer.Write(hash);
				return "Account_GetChatThemes";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/users.getUsers"/></summary>
		public static Task<UserBase[]> Users_GetUsers(this Client client, InputUserBase[] id)
			=> client.CallAsync<UserBase[]>(writer =>
			{
				writer.Write(0x0D91A548);
				writer.WriteTLVector(id);
				return "Users_GetUsers";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/users.getFullUser"/></summary>
		public static Task<UserFull> Users_GetFullUser(this Client client, InputUserBase id)
			=> client.CallAsync<UserFull>(writer =>
			{
				writer.Write(0xCA30A5B1);
				writer.WriteTLObject(id);
				return "Users_GetFullUser";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/users.setSecureValueErrors"/></summary>
		public static Task<bool> Users_SetSecureValueErrors(this Client client, InputUserBase id, SecureValueErrorBase[] errors)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x90C894B5);
				writer.WriteTLObject(id);
				writer.WriteTLVector(errors);
				return "Users_SetSecureValueErrors";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/contacts.getContactIDs"/></summary>
		public static Task<int[]> Contacts_GetContactIDs(this Client client, long hash)
			=> client.CallAsync<int[]>(writer =>
			{
				writer.Write(0x7ADC669D);
				writer.Write(hash);
				return "Contacts_GetContactIDs";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/contacts.getStatuses"/></summary>
		public static Task<ContactStatus[]> Contacts_GetStatuses(this Client client)
			=> client.CallAsync<ContactStatus[]>(writer =>
			{
				writer.Write(0xC4A353EE);
				return "Contacts_GetStatuses";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/contacts.getContacts"/></summary>
		public static Task<Contacts_Contacts> Contacts_GetContacts(this Client client, long hash)
			=> client.CallAsync<Contacts_Contacts>(writer =>
			{
				writer.Write(0x5DD69E12);
				writer.Write(hash);
				return "Contacts_GetContacts";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/contacts.importContacts"/></summary>
		public static Task<Contacts_ImportedContacts> Contacts_ImportContacts(this Client client, InputContact[] contacts)
			=> client.CallAsync<Contacts_ImportedContacts>(writer =>
			{
				writer.Write(0x2C800BE5);
				writer.WriteTLVector(contacts);
				return "Contacts_ImportContacts";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/contacts.deleteContacts"/></summary>
		public static Task<UpdatesBase> Contacts_DeleteContacts(this Client client, InputUserBase[] id)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x096A0E00);
				writer.WriteTLVector(id);
				return "Contacts_DeleteContacts";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/contacts.deleteByPhones"/></summary>
		public static Task<bool> Contacts_DeleteByPhones(this Client client, string[] phones)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x1013FD9E);
				writer.WriteTLVector(phones);
				return "Contacts_DeleteByPhones";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/contacts.block"/></summary>
		public static Task<bool> Contacts_Block(this Client client, InputPeer id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x68CC1411);
				writer.WriteTLObject(id);
				return "Contacts_Block";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/contacts.unblock"/></summary>
		public static Task<bool> Contacts_Unblock(this Client client, InputPeer id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xBEA65D50);
				writer.WriteTLObject(id);
				return "Contacts_Unblock";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/contacts.getBlocked"/></summary>
		public static Task<Contacts_Blocked> Contacts_GetBlocked(this Client client, int offset, int limit)
			=> client.CallAsync<Contacts_Blocked>(writer =>
			{
				writer.Write(0xF57C350F);
				writer.Write(offset);
				writer.Write(limit);
				return "Contacts_GetBlocked";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/contacts.search"/></summary>
		public static Task<Contacts_Found> Contacts_Search(this Client client, string q, int limit)
			=> client.CallAsync<Contacts_Found>(writer =>
			{
				writer.Write(0x11F812D8);
				writer.WriteTLString(q);
				writer.Write(limit);
				return "Contacts_Search";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/contacts.resolveUsername"/></summary>
		public static Task<Contacts_ResolvedPeer> Contacts_ResolveUsername(this Client client, string username)
			=> client.CallAsync<Contacts_ResolvedPeer>(writer =>
			{
				writer.Write(0xF93CCBA3);
				writer.WriteTLString(username);
				return "Contacts_ResolveUsername";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/contacts.getTopPeers"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/contacts.resetTopPeerRating"/></summary>
		public static Task<bool> Contacts_ResetTopPeerRating(this Client client, TopPeerCategory category, InputPeer peer)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x1AE373AC);
				writer.Write((uint)category);
				writer.WriteTLObject(peer);
				return "Contacts_ResetTopPeerRating";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/contacts.resetSaved"/></summary>
		public static Task<bool> Contacts_ResetSaved(this Client client)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x879537F1);
				return "Contacts_ResetSaved";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/contacts.getSaved"/></summary>
		public static Task<SavedContact[]> Contacts_GetSaved(this Client client)
			=> client.CallAsync<SavedContact[]>(writer =>
			{
				writer.Write(0x82F1E39F);
				return "Contacts_GetSaved";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/contacts.toggleTopPeers"/></summary>
		public static Task<bool> Contacts_ToggleTopPeers(this Client client, bool enabled)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x8514BDDA);
				writer.Write(enabled ? 0x997275B5 : 0xBC799737);
				return "Contacts_ToggleTopPeers";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/contacts.addContact"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/contacts.acceptContact"/></summary>
		public static Task<UpdatesBase> Contacts_AcceptContact(this Client client, InputUserBase id)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xF831A20F);
				writer.WriteTLObject(id);
				return "Contacts_AcceptContact";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/contacts.getLocated"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/contacts.blockFromReplies"/></summary>
		public static Task<UpdatesBase> Contacts_BlockFromReplies(this Client client, int msg_id, bool delete_message = false, bool delete_history = false, bool report_spam = false)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x29A8962C);
				writer.Write((delete_message ? 0x1 : 0) | (delete_history ? 0x2 : 0) | (report_spam ? 0x4 : 0));
				writer.Write(msg_id);
				return "Contacts_BlockFromReplies";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getMessages"/></summary>
		public static Task<Messages_MessagesBase> Messages_GetMessages(this Client client, InputMessage[] id)
			=> client.CallAsync<Messages_MessagesBase>(writer =>
			{
				writer.Write(0x63C66506);
				writer.WriteTLVector(id);
				return "Messages_GetMessages";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getDialogs"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getHistory"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.search"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.readHistory"/></summary>
		public static Task<Messages_AffectedMessages> Messages_ReadHistory(this Client client, InputPeer peer, int max_id)
			=> client.CallAsync<Messages_AffectedMessages>(writer =>
			{
				writer.Write(0x0E306D3A);
				writer.WriteTLObject(peer);
				writer.Write(max_id);
				return "Messages_ReadHistory";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.deleteHistory"/></summary>
		public static Task<Messages_AffectedHistory> Messages_DeleteHistory(this Client client, InputPeer peer, int max_id, bool just_clear = false, bool revoke = false)
			=> client.CallAsync<Messages_AffectedHistory>(writer =>
			{
				writer.Write(0x1C015B09);
				writer.Write((just_clear ? 0x1 : 0) | (revoke ? 0x2 : 0));
				writer.WriteTLObject(peer);
				writer.Write(max_id);
				return "Messages_DeleteHistory";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.deleteMessages"/></summary>
		public static Task<Messages_AffectedMessages> Messages_DeleteMessages(this Client client, int[] id, bool revoke = false)
			=> client.CallAsync<Messages_AffectedMessages>(writer =>
			{
				writer.Write(0xE58E95D2);
				writer.Write(revoke ? 0x1 : 0);
				writer.WriteTLVector(id);
				return "Messages_DeleteMessages";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.receivedMessages"/></summary>
		public static Task<ReceivedNotifyMessage[]> Messages_ReceivedMessages(this Client client, int max_id)
			=> client.CallAsync<ReceivedNotifyMessage[]>(writer =>
			{
				writer.Write(0x05A954C0);
				writer.Write(max_id);
				return "Messages_ReceivedMessages";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.setTyping"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.sendMessage"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.sendMedia"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.forwardMessages"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.reportSpam"/></summary>
		public static Task<bool> Messages_ReportSpam(this Client client, InputPeer peer)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xCF1592DB);
				writer.WriteTLObject(peer);
				return "Messages_ReportSpam";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getPeerSettings"/></summary>
		public static Task<PeerSettings> Messages_GetPeerSettings(this Client client, InputPeer peer)
			=> client.CallAsync<PeerSettings>(writer =>
			{
				writer.Write(0x3672E09C);
				writer.WriteTLObject(peer);
				return "Messages_GetPeerSettings";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.report"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getChats"/></summary>
		public static Task<Messages_Chats> Messages_GetChats(this Client client, long[] id)
			=> client.CallAsync<Messages_Chats>(writer =>
			{
				writer.Write(0x49E9528F);
				writer.WriteTLVector(id);
				return "Messages_GetChats";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getFullChat"/></summary>
		public static Task<Messages_ChatFull> Messages_GetFullChat(this Client client, long chat_id)
			=> client.CallAsync<Messages_ChatFull>(writer =>
			{
				writer.Write(0xAEB00B34);
				writer.Write(chat_id);
				return "Messages_GetFullChat";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.editChatTitle"/></summary>
		public static Task<UpdatesBase> Messages_EditChatTitle(this Client client, long chat_id, string title)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x73783FFD);
				writer.Write(chat_id);
				writer.WriteTLString(title);
				return "Messages_EditChatTitle";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.editChatPhoto"/></summary>
		public static Task<UpdatesBase> Messages_EditChatPhoto(this Client client, long chat_id, InputChatPhotoBase photo)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x35DDD674);
				writer.Write(chat_id);
				writer.WriteTLObject(photo);
				return "Messages_EditChatPhoto";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.addChatUser"/></summary>
		public static Task<UpdatesBase> Messages_AddChatUser(this Client client, long chat_id, InputUserBase user_id, int fwd_limit)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xF24753E3);
				writer.Write(chat_id);
				writer.WriteTLObject(user_id);
				writer.Write(fwd_limit);
				return "Messages_AddChatUser";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.deleteChatUser"/></summary>
		public static Task<UpdatesBase> Messages_DeleteChatUser(this Client client, long chat_id, InputUserBase user_id, bool revoke_history = false)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xA2185CAB);
				writer.Write(revoke_history ? 0x1 : 0);
				writer.Write(chat_id);
				writer.WriteTLObject(user_id);
				return "Messages_DeleteChatUser";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.createChat"/></summary>
		public static Task<UpdatesBase> Messages_CreateChat(this Client client, InputUserBase[] users, string title)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x09CB126E);
				writer.WriteTLVector(users);
				writer.WriteTLString(title);
				return "Messages_CreateChat";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getDhConfig"/></summary>
		public static Task<Messages_DhConfigBase> Messages_GetDhConfig(this Client client, int version, int random_length)
			=> client.CallAsync<Messages_DhConfigBase>(writer =>
			{
				writer.Write(0x26CF8950);
				writer.Write(version);
				writer.Write(random_length);
				return "Messages_GetDhConfig";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.requestEncryption"/></summary>
		public static Task<EncryptedChatBase> Messages_RequestEncryption(this Client client, InputUserBase user_id, int random_id, byte[] g_a)
			=> client.CallAsync<EncryptedChatBase>(writer =>
			{
				writer.Write(0xF64DAF43);
				writer.WriteTLObject(user_id);
				writer.Write(random_id);
				writer.WriteTLBytes(g_a);
				return "Messages_RequestEncryption";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.acceptEncryption"/></summary>
		public static Task<EncryptedChatBase> Messages_AcceptEncryption(this Client client, InputEncryptedChat peer, byte[] g_b, long key_fingerprint)
			=> client.CallAsync<EncryptedChatBase>(writer =>
			{
				writer.Write(0x3DBC0415);
				writer.WriteTLObject(peer);
				writer.WriteTLBytes(g_b);
				writer.Write(key_fingerprint);
				return "Messages_AcceptEncryption";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.discardEncryption"/></summary>
		public static Task<bool> Messages_DiscardEncryption(this Client client, int chat_id, bool delete_history = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xF393AEA0);
				writer.Write(delete_history ? 0x1 : 0);
				writer.Write(chat_id);
				return "Messages_DiscardEncryption";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.setEncryptedTyping"/></summary>
		public static Task<bool> Messages_SetEncryptedTyping(this Client client, InputEncryptedChat peer, bool typing)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x791451ED);
				writer.WriteTLObject(peer);
				writer.Write(typing ? 0x997275B5 : 0xBC799737);
				return "Messages_SetEncryptedTyping";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.readEncryptedHistory"/></summary>
		public static Task<bool> Messages_ReadEncryptedHistory(this Client client, InputEncryptedChat peer, DateTime max_date)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x7F4B690A);
				writer.WriteTLObject(peer);
				writer.WriteTLStamp(max_date);
				return "Messages_ReadEncryptedHistory";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.sendEncrypted"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.sendEncryptedFile"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.sendEncryptedService"/></summary>
		public static Task<Messages_SentEncryptedMessage> Messages_SendEncryptedService(this Client client, InputEncryptedChat peer, long random_id, byte[] data)
			=> client.CallAsync<Messages_SentEncryptedMessage>(writer =>
			{
				writer.Write(0x32D439A4);
				writer.WriteTLObject(peer);
				writer.Write(random_id);
				writer.WriteTLBytes(data);
				return "Messages_SendEncryptedService";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.receivedQueue"/></summary>
		public static Task<long[]> Messages_ReceivedQueue(this Client client, int max_qts)
			=> client.CallAsync<long[]>(writer =>
			{
				writer.Write(0x55A5BB66);
				writer.Write(max_qts);
				return "Messages_ReceivedQueue";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.reportEncryptedSpam"/></summary>
		public static Task<bool> Messages_ReportEncryptedSpam(this Client client, InputEncryptedChat peer)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x4B0C8C0F);
				writer.WriteTLObject(peer);
				return "Messages_ReportEncryptedSpam";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.readMessageContents"/></summary>
		public static Task<Messages_AffectedMessages> Messages_ReadMessageContents(this Client client, int[] id)
			=> client.CallAsync<Messages_AffectedMessages>(writer =>
			{
				writer.Write(0x36A73F77);
				writer.WriteTLVector(id);
				return "Messages_ReadMessageContents";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getStickers"/></summary>
		public static Task<Messages_Stickers> Messages_GetStickers(this Client client, string emoticon, long hash)
			=> client.CallAsync<Messages_Stickers>(writer =>
			{
				writer.Write(0xD5A5D3A1);
				writer.WriteTLString(emoticon);
				writer.Write(hash);
				return "Messages_GetStickers";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getAllStickers"/></summary>
		public static Task<Messages_AllStickers> Messages_GetAllStickers(this Client client, long hash)
			=> client.CallAsync<Messages_AllStickers>(writer =>
			{
				writer.Write(0xB8A0A1A8);
				writer.Write(hash);
				return "Messages_GetAllStickers";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getWebPagePreview"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.exportChatInvite"/></summary>
		public static Task<ExportedChatInvite> Messages_ExportChatInvite(this Client client, InputPeer peer, bool legacy_revoke_permanent = false, DateTime? expire_date = null, int? usage_limit = null)
			=> client.CallAsync<ExportedChatInvite>(writer =>
			{
				writer.Write(0x14B9BCD7);
				writer.Write((legacy_revoke_permanent ? 0x4 : 0) | (expire_date != null ? 0x1 : 0) | (usage_limit != null ? 0x2 : 0));
				writer.WriteTLObject(peer);
				if (expire_date != null)
					writer.WriteTLStamp(expire_date.Value);
				if (usage_limit != null)
					writer.Write(usage_limit.Value);
				return "Messages_ExportChatInvite";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.checkChatInvite"/></summary>
		public static Task<ChatInviteBase> Messages_CheckChatInvite(this Client client, string hash)
			=> client.CallAsync<ChatInviteBase>(writer =>
			{
				writer.Write(0x3EADB1BB);
				writer.WriteTLString(hash);
				return "Messages_CheckChatInvite";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.importChatInvite"/></summary>
		public static Task<UpdatesBase> Messages_ImportChatInvite(this Client client, string hash)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x6C50051C);
				writer.WriteTLString(hash);
				return "Messages_ImportChatInvite";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getStickerSet"/></summary>
		public static Task<Messages_StickerSet> Messages_GetStickerSet(this Client client, InputStickerSet stickerset)
			=> client.CallAsync<Messages_StickerSet>(writer =>
			{
				writer.Write(0x2619A90E);
				writer.WriteTLObject(stickerset);
				return "Messages_GetStickerSet";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.installStickerSet"/></summary>
		public static Task<Messages_StickerSetInstallResult> Messages_InstallStickerSet(this Client client, InputStickerSet stickerset, bool archived)
			=> client.CallAsync<Messages_StickerSetInstallResult>(writer =>
			{
				writer.Write(0xC78FE460);
				writer.WriteTLObject(stickerset);
				writer.Write(archived ? 0x997275B5 : 0xBC799737);
				return "Messages_InstallStickerSet";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.uninstallStickerSet"/></summary>
		public static Task<bool> Messages_UninstallStickerSet(this Client client, InputStickerSet stickerset)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xF96E55DE);
				writer.WriteTLObject(stickerset);
				return "Messages_UninstallStickerSet";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.startBot"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getMessagesViews"/></summary>
		public static Task<Messages_MessageViews> Messages_GetMessagesViews(this Client client, InputPeer peer, int[] id, bool increment)
			=> client.CallAsync<Messages_MessageViews>(writer =>
			{
				writer.Write(0x5784D3E1);
				writer.WriteTLObject(peer);
				writer.WriteTLVector(id);
				writer.Write(increment ? 0x997275B5 : 0xBC799737);
				return "Messages_GetMessagesViews";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.editChatAdmin"/></summary>
		public static Task<bool> Messages_EditChatAdmin(this Client client, long chat_id, InputUserBase user_id, bool is_admin)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xA85BD1C2);
				writer.Write(chat_id);
				writer.WriteTLObject(user_id);
				writer.Write(is_admin ? 0x997275B5 : 0xBC799737);
				return "Messages_EditChatAdmin";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.migrateChat"/></summary>
		public static Task<UpdatesBase> Messages_MigrateChat(this Client client, long chat_id)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xA2875319);
				writer.Write(chat_id);
				return "Messages_MigrateChat";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.searchGlobal"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.reorderStickerSets"/></summary>
		public static Task<bool> Messages_ReorderStickerSets(this Client client, long[] order, bool masks = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x78337739);
				writer.Write(masks ? 0x1 : 0);
				writer.WriteTLVector(order);
				return "Messages_ReorderStickerSets";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getDocumentByHash"/></summary>
		public static Task<DocumentBase> Messages_GetDocumentByHash(this Client client, byte[] sha256, int size, string mime_type)
			=> client.CallAsync<DocumentBase>(writer =>
			{
				writer.Write(0x338E2464);
				writer.WriteTLBytes(sha256);
				writer.Write(size);
				writer.WriteTLString(mime_type);
				return "Messages_GetDocumentByHash";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getSavedGifs"/></summary>
		public static Task<Messages_SavedGifs> Messages_GetSavedGifs(this Client client, long hash)
			=> client.CallAsync<Messages_SavedGifs>(writer =>
			{
				writer.Write(0x5CF09635);
				writer.Write(hash);
				return "Messages_GetSavedGifs";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.saveGif"/></summary>
		public static Task<bool> Messages_SaveGif(this Client client, InputDocument id, bool unsave)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x327A30CB);
				writer.WriteTLObject(id);
				writer.Write(unsave ? 0x997275B5 : 0xBC799737);
				return "Messages_SaveGif";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getInlineBotResults"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.setInlineBotResults"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.sendInlineBotResult"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getMessageEditData"/></summary>
		public static Task<Messages_MessageEditData> Messages_GetMessageEditData(this Client client, InputPeer peer, int id)
			=> client.CallAsync<Messages_MessageEditData>(writer =>
			{
				writer.Write(0xFDA68D36);
				writer.WriteTLObject(peer);
				writer.Write(id);
				return "Messages_GetMessageEditData";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.editMessage"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.editInlineBotMessage"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getBotCallbackAnswer"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.setBotCallbackAnswer"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getPeerDialogs"/></summary>
		public static Task<Messages_PeerDialogs> Messages_GetPeerDialogs(this Client client, InputDialogPeerBase[] peers)
			=> client.CallAsync<Messages_PeerDialogs>(writer =>
			{
				writer.Write(0xE470BCFD);
				writer.WriteTLVector(peers);
				return "Messages_GetPeerDialogs";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.saveDraft"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getAllDrafts"/></summary>
		public static Task<UpdatesBase> Messages_GetAllDrafts(this Client client)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x6A3F8D65);
				return "Messages_GetAllDrafts";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getFeaturedStickers"/></summary>
		public static Task<Messages_FeaturedStickersBase> Messages_GetFeaturedStickers(this Client client, long hash)
			=> client.CallAsync<Messages_FeaturedStickersBase>(writer =>
			{
				writer.Write(0x64780B14);
				writer.Write(hash);
				return "Messages_GetFeaturedStickers";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.readFeaturedStickers"/></summary>
		public static Task<bool> Messages_ReadFeaturedStickers(this Client client, long[] id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x5B118126);
				writer.WriteTLVector(id);
				return "Messages_ReadFeaturedStickers";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getRecentStickers"/></summary>
		public static Task<Messages_RecentStickers> Messages_GetRecentStickers(this Client client, long hash, bool attached = false)
			=> client.CallAsync<Messages_RecentStickers>(writer =>
			{
				writer.Write(0x9DA9403B);
				writer.Write(attached ? 0x1 : 0);
				writer.Write(hash);
				return "Messages_GetRecentStickers";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.saveRecentSticker"/></summary>
		public static Task<bool> Messages_SaveRecentSticker(this Client client, InputDocument id, bool unsave, bool attached = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x392718F8);
				writer.Write(attached ? 0x1 : 0);
				writer.WriteTLObject(id);
				writer.Write(unsave ? 0x997275B5 : 0xBC799737);
				return "Messages_SaveRecentSticker";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.clearRecentStickers"/></summary>
		public static Task<bool> Messages_ClearRecentStickers(this Client client, bool attached = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x8999602D);
				writer.Write(attached ? 0x1 : 0);
				return "Messages_ClearRecentStickers";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getArchivedStickers"/></summary>
		public static Task<Messages_ArchivedStickers> Messages_GetArchivedStickers(this Client client, long offset_id, int limit, bool masks = false)
			=> client.CallAsync<Messages_ArchivedStickers>(writer =>
			{
				writer.Write(0x57F17692);
				writer.Write(masks ? 0x1 : 0);
				writer.Write(offset_id);
				writer.Write(limit);
				return "Messages_GetArchivedStickers";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getMaskStickers"/></summary>
		public static Task<Messages_AllStickers> Messages_GetMaskStickers(this Client client, long hash)
			=> client.CallAsync<Messages_AllStickers>(writer =>
			{
				writer.Write(0x640F82B8);
				writer.Write(hash);
				return "Messages_GetMaskStickers";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getAttachedStickers"/></summary>
		public static Task<StickerSetCoveredBase[]> Messages_GetAttachedStickers(this Client client, InputStickeredMedia media)
			=> client.CallAsync<StickerSetCoveredBase[]>(writer =>
			{
				writer.Write(0xCC5B67CC);
				writer.WriteTLObject(media);
				return "Messages_GetAttachedStickers";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.setGameScore"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.setInlineGameScore"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getGameHighScores"/></summary>
		public static Task<Messages_HighScores> Messages_GetGameHighScores(this Client client, InputPeer peer, int id, InputUserBase user_id)
			=> client.CallAsync<Messages_HighScores>(writer =>
			{
				writer.Write(0xE822649D);
				writer.WriteTLObject(peer);
				writer.Write(id);
				writer.WriteTLObject(user_id);
				return "Messages_GetGameHighScores";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getInlineGameHighScores"/></summary>
		public static Task<Messages_HighScores> Messages_GetInlineGameHighScores(this Client client, InputBotInlineMessageIDBase id, InputUserBase user_id)
			=> client.CallAsync<Messages_HighScores>(writer =>
			{
				writer.Write(0x0F635E1B);
				writer.WriteTLObject(id);
				writer.WriteTLObject(user_id);
				return "Messages_GetInlineGameHighScores";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getCommonChats"/></summary>
		public static Task<Messages_Chats> Messages_GetCommonChats(this Client client, InputUserBase user_id, long max_id, int limit)
			=> client.CallAsync<Messages_Chats>(writer =>
			{
				writer.Write(0xE40CA104);
				writer.WriteTLObject(user_id);
				writer.Write(max_id);
				writer.Write(limit);
				return "Messages_GetCommonChats";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getAllChats"/></summary>
		public static Task<Messages_Chats> Messages_GetAllChats(this Client client, long[] except_ids)
			=> client.CallAsync<Messages_Chats>(writer =>
			{
				writer.Write(0x875F74BE);
				writer.WriteTLVector(except_ids);
				return "Messages_GetAllChats";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getWebPage"/></summary>
		public static Task<WebPageBase> Messages_GetWebPage(this Client client, string url, int hash)
			=> client.CallAsync<WebPageBase>(writer =>
			{
				writer.Write(0x32CA8F91);
				writer.WriteTLString(url);
				writer.Write(hash);
				return "Messages_GetWebPage";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.toggleDialogPin"/></summary>
		public static Task<bool> Messages_ToggleDialogPin(this Client client, InputDialogPeerBase peer, bool pinned = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xA731E257);
				writer.Write(pinned ? 0x1 : 0);
				writer.WriteTLObject(peer);
				return "Messages_ToggleDialogPin";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.reorderPinnedDialogs"/></summary>
		public static Task<bool> Messages_ReorderPinnedDialogs(this Client client, int folder_id, InputDialogPeerBase[] order, bool force = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x3B1ADF37);
				writer.Write(force ? 0x1 : 0);
				writer.Write(folder_id);
				writer.WriteTLVector(order);
				return "Messages_ReorderPinnedDialogs";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getPinnedDialogs"/></summary>
		public static Task<Messages_PeerDialogs> Messages_GetPinnedDialogs(this Client client, int folder_id)
			=> client.CallAsync<Messages_PeerDialogs>(writer =>
			{
				writer.Write(0xD6B94DF2);
				writer.Write(folder_id);
				return "Messages_GetPinnedDialogs";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.setBotShippingResults"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.setBotPrecheckoutResults"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.uploadMedia"/></summary>
		public static Task<MessageMedia> Messages_UploadMedia(this Client client, InputPeer peer, InputMedia media)
			=> client.CallAsync<MessageMedia>(writer =>
			{
				writer.Write(0x519BC2B1);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(media);
				return "Messages_UploadMedia";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.sendScreenshotNotification"/></summary>
		public static Task<UpdatesBase> Messages_SendScreenshotNotification(this Client client, InputPeer peer, int reply_to_msg_id, long random_id)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xC97DF020);
				writer.WriteTLObject(peer);
				writer.Write(reply_to_msg_id);
				writer.Write(random_id);
				return "Messages_SendScreenshotNotification";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getFavedStickers"/></summary>
		public static Task<Messages_FavedStickers> Messages_GetFavedStickers(this Client client, long hash)
			=> client.CallAsync<Messages_FavedStickers>(writer =>
			{
				writer.Write(0x04F1AAA9);
				writer.Write(hash);
				return "Messages_GetFavedStickers";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.faveSticker"/></summary>
		public static Task<bool> Messages_FaveSticker(this Client client, InputDocument id, bool unfave)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xB9FFC55B);
				writer.WriteTLObject(id);
				writer.Write(unfave ? 0x997275B5 : 0xBC799737);
				return "Messages_FaveSticker";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getUnreadMentions"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.readMentions"/></summary>
		public static Task<Messages_AffectedHistory> Messages_ReadMentions(this Client client, InputPeer peer)
			=> client.CallAsync<Messages_AffectedHistory>(writer =>
			{
				writer.Write(0x0F0189D3);
				writer.WriteTLObject(peer);
				return "Messages_ReadMentions";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getRecentLocations"/></summary>
		public static Task<Messages_MessagesBase> Messages_GetRecentLocations(this Client client, InputPeer peer, int limit, long hash)
			=> client.CallAsync<Messages_MessagesBase>(writer =>
			{
				writer.Write(0x702A40E0);
				writer.WriteTLObject(peer);
				writer.Write(limit);
				writer.Write(hash);
				return "Messages_GetRecentLocations";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.sendMultiMedia"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.uploadEncryptedFile"/></summary>
		public static Task<EncryptedFile> Messages_UploadEncryptedFile(this Client client, InputEncryptedChat peer, InputEncryptedFileBase file)
			=> client.CallAsync<EncryptedFile>(writer =>
			{
				writer.Write(0x5057C497);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(file);
				return "Messages_UploadEncryptedFile";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.searchStickerSets"/></summary>
		public static Task<Messages_FoundStickerSets> Messages_SearchStickerSets(this Client client, string q, long hash, bool exclude_featured = false)
			=> client.CallAsync<Messages_FoundStickerSets>(writer =>
			{
				writer.Write(0x35705B8A);
				writer.Write(exclude_featured ? 0x1 : 0);
				writer.WriteTLString(q);
				writer.Write(hash);
				return "Messages_SearchStickerSets";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getSplitRanges"/></summary>
		public static Task<MessageRange[]> Messages_GetSplitRanges(this Client client)
			=> client.CallAsync<MessageRange[]>(writer =>
			{
				writer.Write(0x1CFF7E08);
				return "Messages_GetSplitRanges";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.markDialogUnread"/></summary>
		public static Task<bool> Messages_MarkDialogUnread(this Client client, InputDialogPeerBase peer, bool unread = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xC286D98F);
				writer.Write(unread ? 0x1 : 0);
				writer.WriteTLObject(peer);
				return "Messages_MarkDialogUnread";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getDialogUnreadMarks"/></summary>
		public static Task<DialogPeerBase[]> Messages_GetDialogUnreadMarks(this Client client)
			=> client.CallAsync<DialogPeerBase[]>(writer =>
			{
				writer.Write(0x22E24E22);
				return "Messages_GetDialogUnreadMarks";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.clearAllDrafts"/></summary>
		public static Task<bool> Messages_ClearAllDrafts(this Client client)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x7E58EE9C);
				return "Messages_ClearAllDrafts";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.updatePinnedMessage"/></summary>
		public static Task<UpdatesBase> Messages_UpdatePinnedMessage(this Client client, InputPeer peer, int id, bool silent = false, bool unpin = false, bool pm_oneside = false)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xD2AAF7EC);
				writer.Write((silent ? 0x1 : 0) | (unpin ? 0x2 : 0) | (pm_oneside ? 0x4 : 0));
				writer.WriteTLObject(peer);
				writer.Write(id);
				return "Messages_UpdatePinnedMessage";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.sendVote"/></summary>
		public static Task<UpdatesBase> Messages_SendVote(this Client client, InputPeer peer, int msg_id, byte[][] options)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x10EA6184);
				writer.WriteTLObject(peer);
				writer.Write(msg_id);
				writer.WriteTLVector(options);
				return "Messages_SendVote";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getPollResults"/></summary>
		public static Task<UpdatesBase> Messages_GetPollResults(this Client client, InputPeer peer, int msg_id)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x73BB643B);
				writer.WriteTLObject(peer);
				writer.Write(msg_id);
				return "Messages_GetPollResults";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getOnlines"/></summary>
		public static Task<ChatOnlines> Messages_GetOnlines(this Client client, InputPeer peer)
			=> client.CallAsync<ChatOnlines>(writer =>
			{
				writer.Write(0x6E2BE050);
				writer.WriteTLObject(peer);
				return "Messages_GetOnlines";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getStatsURL"/></summary>
		public static Task<StatsURL> Messages_GetStatsURL(this Client client, InputPeer peer, string params_, bool dark = false)
			=> client.CallAsync<StatsURL>(writer =>
			{
				writer.Write(0x812C2AE6);
				writer.Write(dark ? 0x1 : 0);
				writer.WriteTLObject(peer);
				writer.WriteTLString(params_);
				return "Messages_GetStatsURL";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.editChatAbout"/></summary>
		public static Task<bool> Messages_EditChatAbout(this Client client, InputPeer peer, string about)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xDEF60797);
				writer.WriteTLObject(peer);
				writer.WriteTLString(about);
				return "Messages_EditChatAbout";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.editChatDefaultBannedRights"/></summary>
		public static Task<UpdatesBase> Messages_EditChatDefaultBannedRights(this Client client, InputPeer peer, ChatBannedRights banned_rights)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xA5866B41);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(banned_rights);
				return "Messages_EditChatDefaultBannedRights";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getEmojiKeywords"/></summary>
		public static Task<EmojiKeywordsDifference> Messages_GetEmojiKeywords(this Client client, string lang_code)
			=> client.CallAsync<EmojiKeywordsDifference>(writer =>
			{
				writer.Write(0x35A0E062);
				writer.WriteTLString(lang_code);
				return "Messages_GetEmojiKeywords";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getEmojiKeywordsDifference"/></summary>
		public static Task<EmojiKeywordsDifference> Messages_GetEmojiKeywordsDifference(this Client client, string lang_code, int from_version)
			=> client.CallAsync<EmojiKeywordsDifference>(writer =>
			{
				writer.Write(0x1508B6AF);
				writer.WriteTLString(lang_code);
				writer.Write(from_version);
				return "Messages_GetEmojiKeywordsDifference";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getEmojiKeywordsLanguages"/></summary>
		public static Task<EmojiLanguage[]> Messages_GetEmojiKeywordsLanguages(this Client client, string[] lang_codes)
			=> client.CallAsync<EmojiLanguage[]>(writer =>
			{
				writer.Write(0x4E9963B2);
				writer.WriteTLVector(lang_codes);
				return "Messages_GetEmojiKeywordsLanguages";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getEmojiURL"/></summary>
		public static Task<EmojiURL> Messages_GetEmojiURL(this Client client, string lang_code)
			=> client.CallAsync<EmojiURL>(writer =>
			{
				writer.Write(0xD5B10C26);
				writer.WriteTLString(lang_code);
				return "Messages_GetEmojiURL";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getSearchCounters"/></summary>
		public static Task<Messages_SearchCounter[]> Messages_GetSearchCounters(this Client client, InputPeer peer, MessagesFilter[] filters)
			=> client.CallAsync<Messages_SearchCounter[]>(writer =>
			{
				writer.Write(0x732EEF00);
				writer.WriteTLObject(peer);
				writer.WriteTLVector(filters);
				return "Messages_GetSearchCounters";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.requestUrlAuth"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.acceptUrlAuth"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.hidePeerSettingsBar"/></summary>
		public static Task<bool> Messages_HidePeerSettingsBar(this Client client, InputPeer peer)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x4FACB138);
				writer.WriteTLObject(peer);
				return "Messages_HidePeerSettingsBar";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getScheduledHistory"/></summary>
		public static Task<Messages_MessagesBase> Messages_GetScheduledHistory(this Client client, InputPeer peer, long hash)
			=> client.CallAsync<Messages_MessagesBase>(writer =>
			{
				writer.Write(0xF516760B);
				writer.WriteTLObject(peer);
				writer.Write(hash);
				return "Messages_GetScheduledHistory";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getScheduledMessages"/></summary>
		public static Task<Messages_MessagesBase> Messages_GetScheduledMessages(this Client client, InputPeer peer, int[] id)
			=> client.CallAsync<Messages_MessagesBase>(writer =>
			{
				writer.Write(0xBDBB0464);
				writer.WriteTLObject(peer);
				writer.WriteTLVector(id);
				return "Messages_GetScheduledMessages";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.sendScheduledMessages"/></summary>
		public static Task<UpdatesBase> Messages_SendScheduledMessages(this Client client, InputPeer peer, int[] id)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xBD38850A);
				writer.WriteTLObject(peer);
				writer.WriteTLVector(id);
				return "Messages_SendScheduledMessages";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.deleteScheduledMessages"/></summary>
		public static Task<UpdatesBase> Messages_DeleteScheduledMessages(this Client client, InputPeer peer, int[] id)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x59AE2B16);
				writer.WriteTLObject(peer);
				writer.WriteTLVector(id);
				return "Messages_DeleteScheduledMessages";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getPollVotes"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.toggleStickerSets"/></summary>
		public static Task<bool> Messages_ToggleStickerSets(this Client client, InputStickerSet[] stickersets, bool uninstall = false, bool archive = false, bool unarchive = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xB5052FEA);
				writer.Write((uninstall ? 0x1 : 0) | (archive ? 0x2 : 0) | (unarchive ? 0x4 : 0));
				writer.WriteTLVector(stickersets);
				return "Messages_ToggleStickerSets";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getDialogFilters"/></summary>
		public static Task<DialogFilter[]> Messages_GetDialogFilters(this Client client)
			=> client.CallAsync<DialogFilter[]>(writer =>
			{
				writer.Write(0xF19ED96D);
				return "Messages_GetDialogFilters";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getSuggestedDialogFilters"/></summary>
		public static Task<DialogFilterSuggested[]> Messages_GetSuggestedDialogFilters(this Client client)
			=> client.CallAsync<DialogFilterSuggested[]>(writer =>
			{
				writer.Write(0xA29CD42C);
				return "Messages_GetSuggestedDialogFilters";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.updateDialogFilter"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.updateDialogFiltersOrder"/></summary>
		public static Task<bool> Messages_UpdateDialogFiltersOrder(this Client client, int[] order)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xC563C1E4);
				writer.WriteTLVector(order);
				return "Messages_UpdateDialogFiltersOrder";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getOldFeaturedStickers"/></summary>
		public static Task<Messages_FeaturedStickersBase> Messages_GetOldFeaturedStickers(this Client client, int offset, int limit, long hash)
			=> client.CallAsync<Messages_FeaturedStickersBase>(writer =>
			{
				writer.Write(0x7ED094A1);
				writer.Write(offset);
				writer.Write(limit);
				writer.Write(hash);
				return "Messages_GetOldFeaturedStickers";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getReplies"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getDiscussionMessage"/></summary>
		public static Task<Messages_DiscussionMessage> Messages_GetDiscussionMessage(this Client client, InputPeer peer, int msg_id)
			=> client.CallAsync<Messages_DiscussionMessage>(writer =>
			{
				writer.Write(0x446972FD);
				writer.WriteTLObject(peer);
				writer.Write(msg_id);
				return "Messages_GetDiscussionMessage";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.readDiscussion"/></summary>
		public static Task<bool> Messages_ReadDiscussion(this Client client, InputPeer peer, int msg_id, int read_max_id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xF731A9F4);
				writer.WriteTLObject(peer);
				writer.Write(msg_id);
				writer.Write(read_max_id);
				return "Messages_ReadDiscussion";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.unpinAllMessages"/></summary>
		public static Task<Messages_AffectedHistory> Messages_UnpinAllMessages(this Client client, InputPeer peer)
			=> client.CallAsync<Messages_AffectedHistory>(writer =>
			{
				writer.Write(0xF025BC8B);
				writer.WriteTLObject(peer);
				return "Messages_UnpinAllMessages";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.deleteChat"/></summary>
		public static Task<bool> Messages_DeleteChat(this Client client, long chat_id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x5BD0EE50);
				writer.Write(chat_id);
				return "Messages_DeleteChat";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.deletePhoneCallHistory"/></summary>
		public static Task<Messages_AffectedFoundMessages> Messages_DeletePhoneCallHistory(this Client client, bool revoke = false)
			=> client.CallAsync<Messages_AffectedFoundMessages>(writer =>
			{
				writer.Write(0xF9CBE409);
				writer.Write(revoke ? 0x1 : 0);
				return "Messages_DeletePhoneCallHistory";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.checkHistoryImport"/></summary>
		public static Task<Messages_HistoryImportParsed> Messages_CheckHistoryImport(this Client client, string import_head)
			=> client.CallAsync<Messages_HistoryImportParsed>(writer =>
			{
				writer.Write(0x43FE19F3);
				writer.WriteTLString(import_head);
				return "Messages_CheckHistoryImport";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.initHistoryImport"/></summary>
		public static Task<Messages_HistoryImport> Messages_InitHistoryImport(this Client client, InputPeer peer, InputFileBase file, int media_count)
			=> client.CallAsync<Messages_HistoryImport>(writer =>
			{
				writer.Write(0x34090C3B);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(file);
				writer.Write(media_count);
				return "Messages_InitHistoryImport";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.uploadImportedMedia"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.startHistoryImport"/></summary>
		public static Task<bool> Messages_StartHistoryImport(this Client client, InputPeer peer, long import_id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xB43DF344);
				writer.WriteTLObject(peer);
				writer.Write(import_id);
				return "Messages_StartHistoryImport";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getExportedChatInvites"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getExportedChatInvite"/></summary>
		public static Task<Messages_ExportedChatInviteBase> Messages_GetExportedChatInvite(this Client client, InputPeer peer, string link)
			=> client.CallAsync<Messages_ExportedChatInviteBase>(writer =>
			{
				writer.Write(0x73746F5C);
				writer.WriteTLObject(peer);
				writer.WriteTLString(link);
				return "Messages_GetExportedChatInvite";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.editExportedChatInvite"/></summary>
		public static Task<Messages_ExportedChatInviteBase> Messages_EditExportedChatInvite(this Client client, InputPeer peer, string link, bool revoked = false, DateTime? expire_date = null, int? usage_limit = null)
			=> client.CallAsync<Messages_ExportedChatInviteBase>(writer =>
			{
				writer.Write(0x02E4FFBE);
				writer.Write((revoked ? 0x4 : 0) | (expire_date != null ? 0x1 : 0) | (usage_limit != null ? 0x2 : 0));
				writer.WriteTLObject(peer);
				writer.WriteTLString(link);
				if (expire_date != null)
					writer.WriteTLStamp(expire_date.Value);
				if (usage_limit != null)
					writer.Write(usage_limit.Value);
				return "Messages_EditExportedChatInvite";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.deleteRevokedExportedChatInvites"/></summary>
		public static Task<bool> Messages_DeleteRevokedExportedChatInvites(this Client client, InputPeer peer, InputUserBase admin_id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x56987BD5);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(admin_id);
				return "Messages_DeleteRevokedExportedChatInvites";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.deleteExportedChatInvite"/></summary>
		public static Task<bool> Messages_DeleteExportedChatInvite(this Client client, InputPeer peer, string link)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xD464A42B);
				writer.WriteTLObject(peer);
				writer.WriteTLString(link);
				return "Messages_DeleteExportedChatInvite";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getAdminsWithInvites"/></summary>
		public static Task<Messages_ChatAdminsWithInvites> Messages_GetAdminsWithInvites(this Client client, InputPeer peer)
			=> client.CallAsync<Messages_ChatAdminsWithInvites>(writer =>
			{
				writer.Write(0x3920E6EF);
				writer.WriteTLObject(peer);
				return "Messages_GetAdminsWithInvites";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getChatInviteImporters"/></summary>
		public static Task<Messages_ChatInviteImporters> Messages_GetChatInviteImporters(this Client client, InputPeer peer, string link, DateTime offset_date, InputUserBase offset_user, int limit)
			=> client.CallAsync<Messages_ChatInviteImporters>(writer =>
			{
				writer.Write(0x26FB7289);
				writer.WriteTLObject(peer);
				writer.WriteTLString(link);
				writer.WriteTLStamp(offset_date);
				writer.WriteTLObject(offset_user);
				writer.Write(limit);
				return "Messages_GetChatInviteImporters";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.setHistoryTTL"/></summary>
		public static Task<UpdatesBase> Messages_SetHistoryTTL(this Client client, InputPeer peer, int period)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xB80E5FE4);
				writer.WriteTLObject(peer);
				writer.Write(period);
				return "Messages_SetHistoryTTL";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.checkHistoryImportPeer"/></summary>
		public static Task<Messages_CheckedHistoryImportPeer> Messages_CheckHistoryImportPeer(this Client client, InputPeer peer)
			=> client.CallAsync<Messages_CheckedHistoryImportPeer>(writer =>
			{
				writer.Write(0x5DC60F03);
				writer.WriteTLObject(peer);
				return "Messages_CheckHistoryImportPeer";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.setChatTheme"/></summary>
		public static Task<UpdatesBase> Messages_SetChatTheme(this Client client, InputPeer peer, string emoticon)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xE63BE13F);
				writer.WriteTLObject(peer);
				writer.WriteTLString(emoticon);
				return "Messages_SetChatTheme";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/messages.getMessageReadParticipants"/></summary>
		public static Task<long[]> Messages_GetMessageReadParticipants(this Client client, InputPeer peer, int msg_id)
			=> client.CallAsync<long[]>(writer =>
			{
				writer.Write(0x2C6F97B7);
				writer.WriteTLObject(peer);
				writer.Write(msg_id);
				return "Messages_GetMessageReadParticipants";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/updates.getState"/></summary>
		public static Task<Updates_State> Updates_GetState(this Client client)
			=> client.CallAsync<Updates_State>(writer =>
			{
				writer.Write(0xEDD4882A);
				return "Updates_GetState";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/updates.getDifference"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/updates.getChannelDifference"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/photos.updateProfilePhoto"/></summary>
		public static Task<Photos_Photo> Photos_UpdateProfilePhoto(this Client client, InputPhoto id)
			=> client.CallAsync<Photos_Photo>(writer =>
			{
				writer.Write(0x72D4742C);
				writer.WriteTLObject(id);
				return "Photos_UpdateProfilePhoto";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/photos.uploadProfilePhoto"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/photos.deletePhotos"/></summary>
		public static Task<long[]> Photos_DeletePhotos(this Client client, InputPhoto[] id)
			=> client.CallAsync<long[]>(writer =>
			{
				writer.Write(0x87CF7F2F);
				writer.WriteTLVector(id);
				return "Photos_DeletePhotos";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/photos.getUserPhotos"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/upload.saveFilePart"/></summary>
		public static Task<bool> Upload_SaveFilePart(this Client client, long file_id, int file_part, byte[] bytes)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xB304A621);
				writer.Write(file_id);
				writer.Write(file_part);
				writer.WriteTLBytes(bytes);
				return "Upload_SaveFilePart";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/upload.getFile"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/upload.saveBigFilePart"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/upload.getWebFile"/></summary>
		public static Task<Upload_WebFile> Upload_GetWebFile(this Client client, InputWebFileLocationBase location, int offset, int limit)
			=> client.CallAsync<Upload_WebFile>(writer =>
			{
				writer.Write(0x24E6818D);
				writer.WriteTLObject(location);
				writer.Write(offset);
				writer.Write(limit);
				return "Upload_GetWebFile";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/upload.getCdnFile"/></summary>
		public static Task<Upload_CdnFileBase> Upload_GetCdnFile(this Client client, byte[] file_token, int offset, int limit)
			=> client.CallAsync<Upload_CdnFileBase>(writer =>
			{
				writer.Write(0x2000BCC3);
				writer.WriteTLBytes(file_token);
				writer.Write(offset);
				writer.Write(limit);
				return "Upload_GetCdnFile";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/upload.reuploadCdnFile"/></summary>
		public static Task<FileHash[]> Upload_ReuploadCdnFile(this Client client, byte[] file_token, byte[] request_token)
			=> client.CallAsync<FileHash[]>(writer =>
			{
				writer.Write(0x9B2754A8);
				writer.WriteTLBytes(file_token);
				writer.WriteTLBytes(request_token);
				return "Upload_ReuploadCdnFile";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/upload.getCdnFileHashes"/></summary>
		public static Task<FileHash[]> Upload_GetCdnFileHashes(this Client client, byte[] file_token, int offset)
			=> client.CallAsync<FileHash[]>(writer =>
			{
				writer.Write(0x4DA54231);
				writer.WriteTLBytes(file_token);
				writer.Write(offset);
				return "Upload_GetCdnFileHashes";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/upload.getFileHashes"/></summary>
		public static Task<FileHash[]> Upload_GetFileHashes(this Client client, InputFileLocationBase location, int offset)
			=> client.CallAsync<FileHash[]>(writer =>
			{
				writer.Write(0xC7025931);
				writer.WriteTLObject(location);
				writer.Write(offset);
				return "Upload_GetFileHashes";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/help.getConfig"/></summary>
		public static Task<Config> Help_GetConfig(this Client client) => client.CallAsync<Config>(Help_GetConfig);
		public static string Help_GetConfig(BinaryWriter writer)
		{
			writer.Write(0xC4F9186B);
			return "Help_GetConfig";
		}

		///<summary>See <a href="https://corefork.telegram.org/method/help.getNearestDc"/></summary>
		public static Task<NearestDc> Help_GetNearestDc(this Client client)
			=> client.CallAsync<NearestDc>(writer =>
			{
				writer.Write(0x1FB33026);
				return "Help_GetNearestDc";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/help.getAppUpdate"/></summary>
		public static Task<Help_AppUpdate> Help_GetAppUpdate(this Client client, string source)
			=> client.CallAsync<Help_AppUpdate>(writer =>
			{
				writer.Write(0x522D5A7D);
				writer.WriteTLString(source);
				return "Help_GetAppUpdate";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/help.getInviteText"/></summary>
		public static Task<Help_InviteText> Help_GetInviteText(this Client client)
			=> client.CallAsync<Help_InviteText>(writer =>
			{
				writer.Write(0x4D392343);
				return "Help_GetInviteText";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/help.getSupport"/></summary>
		public static Task<Help_Support> Help_GetSupport(this Client client)
			=> client.CallAsync<Help_Support>(writer =>
			{
				writer.Write(0x9CDF08CD);
				return "Help_GetSupport";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/help.getAppChangelog"/></summary>
		public static Task<UpdatesBase> Help_GetAppChangelog(this Client client, string prev_app_version)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x9010EF6F);
				writer.WriteTLString(prev_app_version);
				return "Help_GetAppChangelog";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/help.setBotUpdatesStatus"/></summary>
		public static Task<bool> Help_SetBotUpdatesStatus(this Client client, int pending_updates_count, string message)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xEC22CFCD);
				writer.Write(pending_updates_count);
				writer.WriteTLString(message);
				return "Help_SetBotUpdatesStatus";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/help.getCdnConfig"/></summary>
		public static Task<CdnConfig> Help_GetCdnConfig(this Client client)
			=> client.CallAsync<CdnConfig>(writer =>
			{
				writer.Write(0x52029342);
				return "Help_GetCdnConfig";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/help.getRecentMeUrls"/></summary>
		public static Task<Help_RecentMeUrls> Help_GetRecentMeUrls(this Client client, string referer)
			=> client.CallAsync<Help_RecentMeUrls>(writer =>
			{
				writer.Write(0x3DC0F114);
				writer.WriteTLString(referer);
				return "Help_GetRecentMeUrls";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/help.getTermsOfServiceUpdate"/></summary>
		public static Task<Help_TermsOfServiceUpdateBase> Help_GetTermsOfServiceUpdate(this Client client)
			=> client.CallAsync<Help_TermsOfServiceUpdateBase>(writer =>
			{
				writer.Write(0x2CA51FD1);
				return "Help_GetTermsOfServiceUpdate";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/help.acceptTermsOfService"/></summary>
		public static Task<bool> Help_AcceptTermsOfService(this Client client, DataJSON id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xEE72F79A);
				writer.WriteTLObject(id);
				return "Help_AcceptTermsOfService";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/help.getDeepLinkInfo"/></summary>
		public static Task<Help_DeepLinkInfo> Help_GetDeepLinkInfo(this Client client, string path)
			=> client.CallAsync<Help_DeepLinkInfo>(writer =>
			{
				writer.Write(0x3FEDC75F);
				writer.WriteTLString(path);
				return "Help_GetDeepLinkInfo";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/help.getAppConfig"/></summary>
		public static Task<JSONValue> Help_GetAppConfig(this Client client)
			=> client.CallAsync<JSONValue>(writer =>
			{
				writer.Write(0x98914110);
				return "Help_GetAppConfig";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/help.saveAppLog"/></summary>
		public static Task<bool> Help_SaveAppLog(this Client client, InputAppEvent[] events)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x6F02F748);
				writer.WriteTLVector(events);
				return "Help_SaveAppLog";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/help.getPassportConfig"/></summary>
		public static Task<Help_PassportConfig> Help_GetPassportConfig(this Client client, int hash)
			=> client.CallAsync<Help_PassportConfig>(writer =>
			{
				writer.Write(0xC661AD08);
				writer.Write(hash);
				return "Help_GetPassportConfig";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/help.getSupportName"/></summary>
		public static Task<Help_SupportName> Help_GetSupportName(this Client client)
			=> client.CallAsync<Help_SupportName>(writer =>
			{
				writer.Write(0xD360E72C);
				return "Help_GetSupportName";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/help.getUserInfo"/></summary>
		public static Task<Help_UserInfo> Help_GetUserInfo(this Client client, InputUserBase user_id)
			=> client.CallAsync<Help_UserInfo>(writer =>
			{
				writer.Write(0x038A08D3);
				writer.WriteTLObject(user_id);
				return "Help_GetUserInfo";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/help.editUserInfo"/></summary>
		public static Task<Help_UserInfo> Help_EditUserInfo(this Client client, InputUserBase user_id, string message, MessageEntity[] entities)
			=> client.CallAsync<Help_UserInfo>(writer =>
			{
				writer.Write(0x66B91B70);
				writer.WriteTLObject(user_id);
				writer.WriteTLString(message);
				writer.WriteTLVector(entities);
				return "Help_EditUserInfo";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/help.getPromoData"/></summary>
		public static Task<Help_PromoDataBase> Help_GetPromoData(this Client client)
			=> client.CallAsync<Help_PromoDataBase>(writer =>
			{
				writer.Write(0xC0977421);
				return "Help_GetPromoData";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/help.hidePromoData"/></summary>
		public static Task<bool> Help_HidePromoData(this Client client, InputPeer peer)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x1E251C95);
				writer.WriteTLObject(peer);
				return "Help_HidePromoData";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/help.dismissSuggestion"/></summary>
		public static Task<bool> Help_DismissSuggestion(this Client client, InputPeer peer, string suggestion)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xF50DBAA1);
				writer.WriteTLObject(peer);
				writer.WriteTLString(suggestion);
				return "Help_DismissSuggestion";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/help.getCountriesList"/></summary>
		public static Task<Help_CountriesList> Help_GetCountriesList(this Client client, string lang_code, int hash)
			=> client.CallAsync<Help_CountriesList>(writer =>
			{
				writer.Write(0x735787A8);
				writer.WriteTLString(lang_code);
				writer.Write(hash);
				return "Help_GetCountriesList";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.readHistory"/></summary>
		public static Task<bool> Channels_ReadHistory(this Client client, InputChannelBase channel, int max_id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xCC104937);
				writer.WriteTLObject(channel);
				writer.Write(max_id);
				return "Channels_ReadHistory";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.deleteMessages"/></summary>
		public static Task<Messages_AffectedMessages> Channels_DeleteMessages(this Client client, InputChannelBase channel, int[] id)
			=> client.CallAsync<Messages_AffectedMessages>(writer =>
			{
				writer.Write(0x84C1FD4E);
				writer.WriteTLObject(channel);
				writer.WriteTLVector(id);
				return "Channels_DeleteMessages";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.deleteUserHistory"/></summary>
		public static Task<Messages_AffectedHistory> Channels_DeleteUserHistory(this Client client, InputChannelBase channel, InputUserBase user_id)
			=> client.CallAsync<Messages_AffectedHistory>(writer =>
			{
				writer.Write(0xD10DD71B);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(user_id);
				return "Channels_DeleteUserHistory";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.reportSpam"/></summary>
		public static Task<bool> Channels_ReportSpam(this Client client, InputChannelBase channel, InputUserBase user_id, int[] id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xFE087810);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(user_id);
				writer.WriteTLVector(id);
				return "Channels_ReportSpam";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.getMessages"/></summary>
		public static Task<Messages_MessagesBase> Channels_GetMessages(this Client client, InputChannelBase channel, InputMessage[] id)
			=> client.CallAsync<Messages_MessagesBase>(writer =>
			{
				writer.Write(0xAD8C9A23);
				writer.WriteTLObject(channel);
				writer.WriteTLVector(id);
				return "Channels_GetMessages";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.getParticipants"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/channels.getParticipant"/></summary>
		public static Task<Channels_ChannelParticipant> Channels_GetParticipant(this Client client, InputChannelBase channel, InputPeer participant)
			=> client.CallAsync<Channels_ChannelParticipant>(writer =>
			{
				writer.Write(0xA0AB6CC6);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(participant);
				return "Channels_GetParticipant";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.getChannels"/></summary>
		public static Task<Messages_Chats> Channels_GetChannels(this Client client, InputChannelBase[] id)
			=> client.CallAsync<Messages_Chats>(writer =>
			{
				writer.Write(0x0A7F6BBB);
				writer.WriteTLVector(id);
				return "Channels_GetChannels";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.getFullChannel"/></summary>
		public static Task<Messages_ChatFull> Channels_GetFullChannel(this Client client, InputChannelBase channel)
			=> client.CallAsync<Messages_ChatFull>(writer =>
			{
				writer.Write(0x08736A09);
				writer.WriteTLObject(channel);
				return "Channels_GetFullChannel";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.createChannel"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/channels.editAdmin"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/channels.editTitle"/></summary>
		public static Task<UpdatesBase> Channels_EditTitle(this Client client, InputChannelBase channel, string title)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x566DECD0);
				writer.WriteTLObject(channel);
				writer.WriteTLString(title);
				return "Channels_EditTitle";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.editPhoto"/></summary>
		public static Task<UpdatesBase> Channels_EditPhoto(this Client client, InputChannelBase channel, InputChatPhotoBase photo)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xF12E57C9);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(photo);
				return "Channels_EditPhoto";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.checkUsername"/></summary>
		public static Task<bool> Channels_CheckUsername(this Client client, InputChannelBase channel, string username)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x10E6BD2C);
				writer.WriteTLObject(channel);
				writer.WriteTLString(username);
				return "Channels_CheckUsername";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.updateUsername"/></summary>
		public static Task<bool> Channels_UpdateUsername(this Client client, InputChannelBase channel, string username)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x3514B3DE);
				writer.WriteTLObject(channel);
				writer.WriteTLString(username);
				return "Channels_UpdateUsername";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.joinChannel"/></summary>
		public static Task<UpdatesBase> Channels_JoinChannel(this Client client, InputChannelBase channel)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x24B524C5);
				writer.WriteTLObject(channel);
				return "Channels_JoinChannel";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.leaveChannel"/></summary>
		public static Task<UpdatesBase> Channels_LeaveChannel(this Client client, InputChannelBase channel)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xF836AA95);
				writer.WriteTLObject(channel);
				return "Channels_LeaveChannel";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.inviteToChannel"/></summary>
		public static Task<UpdatesBase> Channels_InviteToChannel(this Client client, InputChannelBase channel, InputUserBase[] users)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x199F3A6C);
				writer.WriteTLObject(channel);
				writer.WriteTLVector(users);
				return "Channels_InviteToChannel";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.deleteChannel"/></summary>
		public static Task<UpdatesBase> Channels_DeleteChannel(this Client client, InputChannelBase channel)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xC0111FE3);
				writer.WriteTLObject(channel);
				return "Channels_DeleteChannel";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.exportMessageLink"/></summary>
		public static Task<ExportedMessageLink> Channels_ExportMessageLink(this Client client, InputChannelBase channel, int id, bool grouped = false, bool thread = false)
			=> client.CallAsync<ExportedMessageLink>(writer =>
			{
				writer.Write(0xE63FADEB);
				writer.Write((grouped ? 0x1 : 0) | (thread ? 0x2 : 0));
				writer.WriteTLObject(channel);
				writer.Write(id);
				return "Channels_ExportMessageLink";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.toggleSignatures"/></summary>
		public static Task<UpdatesBase> Channels_ToggleSignatures(this Client client, InputChannelBase channel, bool enabled)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x1F69B606);
				writer.WriteTLObject(channel);
				writer.Write(enabled ? 0x997275B5 : 0xBC799737);
				return "Channels_ToggleSignatures";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.getAdminedPublicChannels"/></summary>
		public static Task<Messages_Chats> Channels_GetAdminedPublicChannels(this Client client, bool by_location = false, bool check_limit = false)
			=> client.CallAsync<Messages_Chats>(writer =>
			{
				writer.Write(0xF8B036AF);
				writer.Write((by_location ? 0x1 : 0) | (check_limit ? 0x2 : 0));
				return "Channels_GetAdminedPublicChannels";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.editBanned"/></summary>
		public static Task<UpdatesBase> Channels_EditBanned(this Client client, InputChannelBase channel, InputPeer participant, ChatBannedRights banned_rights)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x96E6CD81);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(participant);
				writer.WriteTLObject(banned_rights);
				return "Channels_EditBanned";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.getAdminLog"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/channels.setStickers"/></summary>
		public static Task<bool> Channels_SetStickers(this Client client, InputChannelBase channel, InputStickerSet stickerset)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xEA8CA4F9);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(stickerset);
				return "Channels_SetStickers";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.readMessageContents"/></summary>
		public static Task<bool> Channels_ReadMessageContents(this Client client, InputChannelBase channel, int[] id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xEAB5DC38);
				writer.WriteTLObject(channel);
				writer.WriteTLVector(id);
				return "Channels_ReadMessageContents";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.deleteHistory"/></summary>
		public static Task<bool> Channels_DeleteHistory(this Client client, InputChannelBase channel, int max_id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xAF369D42);
				writer.WriteTLObject(channel);
				writer.Write(max_id);
				return "Channels_DeleteHistory";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.togglePreHistoryHidden"/></summary>
		public static Task<UpdatesBase> Channels_TogglePreHistoryHidden(this Client client, InputChannelBase channel, bool enabled)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xEABBB94C);
				writer.WriteTLObject(channel);
				writer.Write(enabled ? 0x997275B5 : 0xBC799737);
				return "Channels_TogglePreHistoryHidden";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.getLeftChannels"/></summary>
		public static Task<Messages_Chats> Channels_GetLeftChannels(this Client client, int offset)
			=> client.CallAsync<Messages_Chats>(writer =>
			{
				writer.Write(0x8341ECC0);
				writer.Write(offset);
				return "Channels_GetLeftChannels";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.getGroupsForDiscussion"/></summary>
		public static Task<Messages_Chats> Channels_GetGroupsForDiscussion(this Client client)
			=> client.CallAsync<Messages_Chats>(writer =>
			{
				writer.Write(0xF5DAD378);
				return "Channels_GetGroupsForDiscussion";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.setDiscussionGroup"/></summary>
		public static Task<bool> Channels_SetDiscussionGroup(this Client client, InputChannelBase broadcast, InputChannelBase group)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x40582BB2);
				writer.WriteTLObject(broadcast);
				writer.WriteTLObject(group);
				return "Channels_SetDiscussionGroup";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.editCreator"/></summary>
		public static Task<UpdatesBase> Channels_EditCreator(this Client client, InputChannelBase channel, InputUserBase user_id, InputCheckPasswordSRP password)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x8F38CD1F);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(user_id);
				writer.WriteTLObject(password);
				return "Channels_EditCreator";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.editLocation"/></summary>
		public static Task<bool> Channels_EditLocation(this Client client, InputChannelBase channel, InputGeoPoint geo_point, string address)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x58E63F6D);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(geo_point);
				writer.WriteTLString(address);
				return "Channels_EditLocation";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.toggleSlowMode"/></summary>
		public static Task<UpdatesBase> Channels_ToggleSlowMode(this Client client, InputChannelBase channel, int seconds)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xEDD49EF0);
				writer.WriteTLObject(channel);
				writer.Write(seconds);
				return "Channels_ToggleSlowMode";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.getInactiveChannels"/></summary>
		public static Task<Messages_InactiveChats> Channels_GetInactiveChannels(this Client client)
			=> client.CallAsync<Messages_InactiveChats>(writer =>
			{
				writer.Write(0x11E831EE);
				return "Channels_GetInactiveChannels";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.convertToGigagroup"/></summary>
		public static Task<UpdatesBase> Channels_ConvertToGigagroup(this Client client, InputChannelBase channel)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x0B290C69);
				writer.WriteTLObject(channel);
				return "Channels_ConvertToGigagroup";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.viewSponsoredMessage"/></summary>
		public static Task<bool> Channels_ViewSponsoredMessage(this Client client, InputChannelBase channel, byte[] random_id)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xBEAEDB94);
				writer.WriteTLObject(channel);
				writer.WriteTLBytes(random_id);
				return "Channels_ViewSponsoredMessage";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/channels.getSponsoredMessages"/></summary>
		public static Task<Messages_SponsoredMessages> Channels_GetSponsoredMessages(this Client client, InputChannelBase channel)
			=> client.CallAsync<Messages_SponsoredMessages>(writer =>
			{
				writer.Write(0xEC210FBF);
				writer.WriteTLObject(channel);
				return "Channels_GetSponsoredMessages";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/bots.sendCustomRequest"/></summary>
		public static Task<DataJSON> Bots_SendCustomRequest(this Client client, string custom_method, DataJSON params_)
			=> client.CallAsync<DataJSON>(writer =>
			{
				writer.Write(0xAA2769ED);
				writer.WriteTLString(custom_method);
				writer.WriteTLObject(params_);
				return "Bots_SendCustomRequest";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/bots.answerWebhookJSONQuery"/></summary>
		public static Task<bool> Bots_AnswerWebhookJSONQuery(this Client client, long query_id, DataJSON data)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xE6213F4D);
				writer.Write(query_id);
				writer.WriteTLObject(data);
				return "Bots_AnswerWebhookJSONQuery";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/bots.setBotCommands"/></summary>
		public static Task<bool> Bots_SetBotCommands(this Client client, BotCommandScope scope, string lang_code, BotCommand[] commands)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x0517165A);
				writer.WriteTLObject(scope);
				writer.WriteTLString(lang_code);
				writer.WriteTLVector(commands);
				return "Bots_SetBotCommands";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/bots.resetBotCommands"/></summary>
		public static Task<bool> Bots_ResetBotCommands(this Client client, BotCommandScope scope, string lang_code)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x3D8DE0F9);
				writer.WriteTLObject(scope);
				writer.WriteTLString(lang_code);
				return "Bots_ResetBotCommands";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/bots.getBotCommands"/></summary>
		public static Task<BotCommand[]> Bots_GetBotCommands(this Client client, BotCommandScope scope, string lang_code)
			=> client.CallAsync<BotCommand[]>(writer =>
			{
				writer.Write(0xE34C0DD6);
				writer.WriteTLObject(scope);
				writer.WriteTLString(lang_code);
				return "Bots_GetBotCommands";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/payments.getPaymentForm"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/payments.getPaymentReceipt"/></summary>
		public static Task<Payments_PaymentReceipt> Payments_GetPaymentReceipt(this Client client, InputPeer peer, int msg_id)
			=> client.CallAsync<Payments_PaymentReceipt>(writer =>
			{
				writer.Write(0x2478D1CC);
				writer.WriteTLObject(peer);
				writer.Write(msg_id);
				return "Payments_GetPaymentReceipt";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/payments.validateRequestedInfo"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/payments.sendPaymentForm"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/payments.getSavedInfo"/></summary>
		public static Task<Payments_SavedInfo> Payments_GetSavedInfo(this Client client)
			=> client.CallAsync<Payments_SavedInfo>(writer =>
			{
				writer.Write(0x227D824B);
				return "Payments_GetSavedInfo";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/payments.clearSavedInfo"/></summary>
		public static Task<bool> Payments_ClearSavedInfo(this Client client, bool credentials = false, bool info = false)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xD83D70C1);
				writer.Write((credentials ? 0x1 : 0) | (info ? 0x2 : 0));
				return "Payments_ClearSavedInfo";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/payments.getBankCardData"/></summary>
		public static Task<Payments_BankCardData> Payments_GetBankCardData(this Client client, string number)
			=> client.CallAsync<Payments_BankCardData>(writer =>
			{
				writer.Write(0x2E79D779);
				writer.WriteTLString(number);
				return "Payments_GetBankCardData";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/stickers.createStickerSet"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/stickers.removeStickerFromSet"/></summary>
		public static Task<Messages_StickerSet> Stickers_RemoveStickerFromSet(this Client client, InputDocument sticker)
			=> client.CallAsync<Messages_StickerSet>(writer =>
			{
				writer.Write(0xF7760F51);
				writer.WriteTLObject(sticker);
				return "Stickers_RemoveStickerFromSet";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/stickers.changeStickerPosition"/></summary>
		public static Task<Messages_StickerSet> Stickers_ChangeStickerPosition(this Client client, InputDocument sticker, int position)
			=> client.CallAsync<Messages_StickerSet>(writer =>
			{
				writer.Write(0xFFB6D4CA);
				writer.WriteTLObject(sticker);
				writer.Write(position);
				return "Stickers_ChangeStickerPosition";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/stickers.addStickerToSet"/></summary>
		public static Task<Messages_StickerSet> Stickers_AddStickerToSet(this Client client, InputStickerSet stickerset, InputStickerSetItem sticker)
			=> client.CallAsync<Messages_StickerSet>(writer =>
			{
				writer.Write(0x8653FEBE);
				writer.WriteTLObject(stickerset);
				writer.WriteTLObject(sticker);
				return "Stickers_AddStickerToSet";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/stickers.setStickerSetThumb"/></summary>
		public static Task<Messages_StickerSet> Stickers_SetStickerSetThumb(this Client client, InputStickerSet stickerset, InputDocument thumb)
			=> client.CallAsync<Messages_StickerSet>(writer =>
			{
				writer.Write(0x9A364E30);
				writer.WriteTLObject(stickerset);
				writer.WriteTLObject(thumb);
				return "Stickers_SetStickerSetThumb";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/stickers.checkShortName"/></summary>
		public static Task<bool> Stickers_CheckShortName(this Client client, string short_name)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x284B3639);
				writer.WriteTLString(short_name);
				return "Stickers_CheckShortName";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/stickers.suggestShortName"/></summary>
		public static Task<Stickers_SuggestedShortName> Stickers_SuggestShortName(this Client client, string title)
			=> client.CallAsync<Stickers_SuggestedShortName>(writer =>
			{
				writer.Write(0x4DAFC503);
				writer.WriteTLString(title);
				return "Stickers_SuggestShortName";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/phone.getCallConfig"/></summary>
		public static Task<DataJSON> Phone_GetCallConfig(this Client client)
			=> client.CallAsync<DataJSON>(writer =>
			{
				writer.Write(0x55451FA9);
				return "Phone_GetCallConfig";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/phone.requestCall"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/phone.acceptCall"/></summary>
		public static Task<Phone_PhoneCall> Phone_AcceptCall(this Client client, InputPhoneCall peer, byte[] g_b, PhoneCallProtocol protocol)
			=> client.CallAsync<Phone_PhoneCall>(writer =>
			{
				writer.Write(0x3BD2B4A0);
				writer.WriteTLObject(peer);
				writer.WriteTLBytes(g_b);
				writer.WriteTLObject(protocol);
				return "Phone_AcceptCall";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/phone.confirmCall"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/phone.receivedCall"/></summary>
		public static Task<bool> Phone_ReceivedCall(this Client client, InputPhoneCall peer)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x17D54F61);
				writer.WriteTLObject(peer);
				return "Phone_ReceivedCall";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/phone.discardCall"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/phone.setCallRating"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/phone.saveCallDebug"/></summary>
		public static Task<bool> Phone_SaveCallDebug(this Client client, InputPhoneCall peer, DataJSON debug)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x277ADD7E);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(debug);
				return "Phone_SaveCallDebug";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/phone.sendSignalingData"/></summary>
		public static Task<bool> Phone_SendSignalingData(this Client client, InputPhoneCall peer, byte[] data)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0xFF7A9383);
				writer.WriteTLObject(peer);
				writer.WriteTLBytes(data);
				return "Phone_SendSignalingData";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/phone.createGroupCall"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/phone.joinGroupCall"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/phone.leaveGroupCall"/></summary>
		public static Task<UpdatesBase> Phone_LeaveGroupCall(this Client client, InputGroupCall call, int source)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x500377F9);
				writer.WriteTLObject(call);
				writer.Write(source);
				return "Phone_LeaveGroupCall";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/phone.inviteToGroupCall"/></summary>
		public static Task<UpdatesBase> Phone_InviteToGroupCall(this Client client, InputGroupCall call, InputUserBase[] users)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x7B393160);
				writer.WriteTLObject(call);
				writer.WriteTLVector(users);
				return "Phone_InviteToGroupCall";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/phone.discardGroupCall"/></summary>
		public static Task<UpdatesBase> Phone_DiscardGroupCall(this Client client, InputGroupCall call)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x7A777135);
				writer.WriteTLObject(call);
				return "Phone_DiscardGroupCall";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/phone.toggleGroupCallSettings"/></summary>
		public static Task<UpdatesBase> Phone_ToggleGroupCallSettings(this Client client, InputGroupCall call, bool reset_invite_hash = false, bool? join_muted = null)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x74BBB43D);
				writer.Write((reset_invite_hash ? 0x2 : 0) | (join_muted != null ? 0x1 : 0));
				writer.WriteTLObject(call);
				if (join_muted != null)
					writer.Write(join_muted.Value ? 0x997275B5 : 0xBC799737);
				return "Phone_ToggleGroupCallSettings";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/phone.getGroupCall"/></summary>
		public static Task<Phone_GroupCall> Phone_GetGroupCall(this Client client, InputGroupCall call, int limit)
			=> client.CallAsync<Phone_GroupCall>(writer =>
			{
				writer.Write(0x041845DB);
				writer.WriteTLObject(call);
				writer.Write(limit);
				return "Phone_GetGroupCall";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/phone.getGroupParticipants"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/phone.checkGroupCall"/></summary>
		public static Task<int[]> Phone_CheckGroupCall(this Client client, InputGroupCall call, int[] sources)
			=> client.CallAsync<int[]>(writer =>
			{
				writer.Write(0xB59CF977);
				writer.WriteTLObject(call);
				writer.WriteTLVector(sources);
				return "Phone_CheckGroupCall";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/phone.toggleGroupCallRecord"/></summary>
		public static Task<UpdatesBase> Phone_ToggleGroupCallRecord(this Client client, InputGroupCall call, bool start = false, bool video = false, string title = null, bool? video_portrait = null)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xF128C708);
				writer.Write((start ? 0x1 : 0) | (video ? 0x4 : 0) | (title != null ? 0x2 : 0) | (video_portrait != null ? 0x4 : 0));
				writer.WriteTLObject(call);
				if (title != null)
					writer.WriteTLString(title);
				if (video_portrait != null)
					writer.Write(video_portrait.Value ? 0x997275B5 : 0xBC799737);
				return "Phone_ToggleGroupCallRecord";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/phone.editGroupCallParticipant"/></summary>
		public static Task<UpdatesBase> Phone_EditGroupCallParticipant(this Client client, InputGroupCall call, InputPeer participant, bool? muted = null, int? volume = null, bool? raise_hand = null, bool? video_stopped = null, bool? video_paused = null, bool? presentation_paused = null)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xA5273ABF);
				writer.Write((muted != null ? 0x1 : 0) | (volume != null ? 0x2 : 0) | (raise_hand != null ? 0x4 : 0) | (video_stopped != null ? 0x8 : 0) | (video_paused != null ? 0x10 : 0) | (presentation_paused != null ? 0x20 : 0));
				writer.WriteTLObject(call);
				writer.WriteTLObject(participant);
				if (muted != null)
					writer.Write(muted.Value ? 0x997275B5 : 0xBC799737);
				if (volume != null)
					writer.Write(volume.Value);
				if (raise_hand != null)
					writer.Write(raise_hand.Value ? 0x997275B5 : 0xBC799737);
				if (video_stopped != null)
					writer.Write(video_stopped.Value ? 0x997275B5 : 0xBC799737);
				if (video_paused != null)
					writer.Write(video_paused.Value ? 0x997275B5 : 0xBC799737);
				if (presentation_paused != null)
					writer.Write(presentation_paused.Value ? 0x997275B5 : 0xBC799737);
				return "Phone_EditGroupCallParticipant";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/phone.editGroupCallTitle"/></summary>
		public static Task<UpdatesBase> Phone_EditGroupCallTitle(this Client client, InputGroupCall call, string title)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x1CA6AC0A);
				writer.WriteTLObject(call);
				writer.WriteTLString(title);
				return "Phone_EditGroupCallTitle";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/phone.getGroupCallJoinAs"/></summary>
		public static Task<Phone_JoinAsPeers> Phone_GetGroupCallJoinAs(this Client client, InputPeer peer)
			=> client.CallAsync<Phone_JoinAsPeers>(writer =>
			{
				writer.Write(0xEF7C213A);
				writer.WriteTLObject(peer);
				return "Phone_GetGroupCallJoinAs";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/phone.exportGroupCallInvite"/></summary>
		public static Task<Phone_ExportedGroupCallInvite> Phone_ExportGroupCallInvite(this Client client, InputGroupCall call, bool can_self_unmute = false)
			=> client.CallAsync<Phone_ExportedGroupCallInvite>(writer =>
			{
				writer.Write(0xE6AA647F);
				writer.Write(can_self_unmute ? 0x1 : 0);
				writer.WriteTLObject(call);
				return "Phone_ExportGroupCallInvite";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/phone.toggleGroupCallStartSubscription"/></summary>
		public static Task<UpdatesBase> Phone_ToggleGroupCallStartSubscription(this Client client, InputGroupCall call, bool subscribed)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x219C34E6);
				writer.WriteTLObject(call);
				writer.Write(subscribed ? 0x997275B5 : 0xBC799737);
				return "Phone_ToggleGroupCallStartSubscription";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/phone.startScheduledGroupCall"/></summary>
		public static Task<UpdatesBase> Phone_StartScheduledGroupCall(this Client client, InputGroupCall call)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x5680E342);
				writer.WriteTLObject(call);
				return "Phone_StartScheduledGroupCall";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/phone.saveDefaultGroupCallJoinAs"/></summary>
		public static Task<bool> Phone_SaveDefaultGroupCallJoinAs(this Client client, InputPeer peer, InputPeer join_as)
			=> client.CallAsync<bool>(writer =>
			{
				writer.Write(0x575E1F8C);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(join_as);
				return "Phone_SaveDefaultGroupCallJoinAs";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/phone.joinGroupCallPresentation"/></summary>
		public static Task<UpdatesBase> Phone_JoinGroupCallPresentation(this Client client, InputGroupCall call, DataJSON params_)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xCBEA6BC4);
				writer.WriteTLObject(call);
				writer.WriteTLObject(params_);
				return "Phone_JoinGroupCallPresentation";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/phone.leaveGroupCallPresentation"/></summary>
		public static Task<UpdatesBase> Phone_LeaveGroupCallPresentation(this Client client, InputGroupCall call)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x1C50D144);
				writer.WriteTLObject(call);
				return "Phone_LeaveGroupCallPresentation";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/langpack.getLangPack"/></summary>
		public static Task<LangPackDifference> Langpack_GetLangPack(this Client client, string lang_pack, string lang_code)
			=> client.CallAsync<LangPackDifference>(writer =>
			{
				writer.Write(0xF2F2330A);
				writer.WriteTLString(lang_pack);
				writer.WriteTLString(lang_code);
				return "Langpack_GetLangPack";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/langpack.getStrings"/></summary>
		public static Task<LangPackStringBase[]> Langpack_GetStrings(this Client client, string lang_pack, string lang_code, string[] keys)
			=> client.CallAsync<LangPackStringBase[]>(writer =>
			{
				writer.Write(0xEFEA3803);
				writer.WriteTLString(lang_pack);
				writer.WriteTLString(lang_code);
				writer.WriteTLVector(keys);
				return "Langpack_GetStrings";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/langpack.getDifference"/></summary>
		public static Task<LangPackDifference> Langpack_GetDifference(this Client client, string lang_pack, string lang_code, int from_version)
			=> client.CallAsync<LangPackDifference>(writer =>
			{
				writer.Write(0xCD984AA5);
				writer.WriteTLString(lang_pack);
				writer.WriteTLString(lang_code);
				writer.Write(from_version);
				return "Langpack_GetDifference";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/langpack.getLanguages"/></summary>
		public static Task<LangPackLanguage[]> Langpack_GetLanguages(this Client client, string lang_pack)
			=> client.CallAsync<LangPackLanguage[]>(writer =>
			{
				writer.Write(0x42C6978F);
				writer.WriteTLString(lang_pack);
				return "Langpack_GetLanguages";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/langpack.getLanguage"/></summary>
		public static Task<LangPackLanguage> Langpack_GetLanguage(this Client client, string lang_pack, string lang_code)
			=> client.CallAsync<LangPackLanguage>(writer =>
			{
				writer.Write(0x6A596502);
				writer.WriteTLString(lang_pack);
				writer.WriteTLString(lang_code);
				return "Langpack_GetLanguage";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/folders.editPeerFolders"/></summary>
		public static Task<UpdatesBase> Folders_EditPeerFolders(this Client client, InputFolderPeer[] folder_peers)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x6847D0AB);
				writer.WriteTLVector(folder_peers);
				return "Folders_EditPeerFolders";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/folders.deleteFolder"/></summary>
		public static Task<UpdatesBase> Folders_DeleteFolder(this Client client, int folder_id)
			=> client.CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x1C295881);
				writer.Write(folder_id);
				return "Folders_DeleteFolder";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/stats.getBroadcastStats"/></summary>
		public static Task<Stats_BroadcastStats> Stats_GetBroadcastStats(this Client client, InputChannelBase channel, bool dark = false)
			=> client.CallAsync<Stats_BroadcastStats>(writer =>
			{
				writer.Write(0xAB42441A);
				writer.Write(dark ? 0x1 : 0);
				writer.WriteTLObject(channel);
				return "Stats_GetBroadcastStats";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/stats.loadAsyncGraph"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/stats.getMegagroupStats"/></summary>
		public static Task<Stats_MegagroupStats> Stats_GetMegagroupStats(this Client client, InputChannelBase channel, bool dark = false)
			=> client.CallAsync<Stats_MegagroupStats>(writer =>
			{
				writer.Write(0xDCDF8607);
				writer.Write(dark ? 0x1 : 0);
				writer.WriteTLObject(channel);
				return "Stats_GetMegagroupStats";
			});

		///<summary>See <a href="https://corefork.telegram.org/method/stats.getMessagePublicForwards"/></summary>
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

		///<summary>See <a href="https://corefork.telegram.org/method/stats.getMessageStats"/></summary>
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
