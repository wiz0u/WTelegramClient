// This file is (mainly) generated automatically using the Generator class
using System;
using System.Threading.Tasks;

namespace TL
{
	///<summary>See <a href="https://core.telegram.org/type/Bool"/></summary>
	public abstract partial class Bool : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/boolFalse"/></summary>
	[TLDef(0xBC799737)]
	public partial class BoolFalse : Bool { }
	///<summary>See <a href="https://core.telegram.org/constructor/boolTrue"/></summary>
	[TLDef(0x997275B5)]
	public partial class BoolTrue : Bool { }

	///<summary>See <a href="https://core.telegram.org/constructor/true"/></summary>
	[TLDef(0x3FEDD339)]
	public partial class True : ITLObject { }

	///<summary>See <a href="https://core.telegram.org/constructor/error"/></summary>
	[TLDef(0xC4B9F9BB)]
	public partial class Error : ITLObject
	{
		public int code;
		public string text;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/null"/></summary>
	[TLDef(0x56730BCC)]
	public partial class Null : ITLObject { }

	///<summary>See <a href="https://core.telegram.org/type/InputPeer"/></summary>
	public abstract partial class InputPeer : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPeerEmpty"/></summary>
	[TLDef(0x7F3B18EA)]
	public partial class InputPeerEmpty : InputPeer { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPeerSelf"/></summary>
	[TLDef(0x7DA07EC9)]
	public partial class InputPeerSelf : InputPeer { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPeerChat"/></summary>
	[TLDef(0x35A95CB9)]
	public partial class InputPeerChat : InputPeer { public long chat_id; }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPeerUser"/></summary>
	[TLDef(0xDDE8A54C)]
	public partial class InputPeerUser : InputPeer
	{
		public long user_id;
		public long access_hash;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputPeerChannel"/></summary>
	[TLDef(0x27BCBBFC)]
	public partial class InputPeerChannel : InputPeer
	{
		public long channel_id;
		public long access_hash;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputPeerUserFromMessage"/></summary>
	[TLDef(0xA87B0A1C)]
	public partial class InputPeerUserFromMessage : InputPeer
	{
		public InputPeer peer;
		public int msg_id;
		public long user_id;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputPeerChannelFromMessage"/></summary>
	[TLDef(0xBD2A0840)]
	public partial class InputPeerChannelFromMessage : InputPeer
	{
		public InputPeer peer;
		public int msg_id;
		public long channel_id;
	}

	///<summary>See <a href="https://core.telegram.org/type/InputUser"/></summary>
	public abstract partial class InputUserBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputUserEmpty"/></summary>
	[TLDef(0xB98886CF)]
	public partial class InputUserEmpty : InputUserBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputUserSelf"/></summary>
	[TLDef(0xF7C1B13F)]
	public partial class InputUserSelf : InputUserBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputUser"/></summary>
	[TLDef(0xF21158C6)]
	public partial class InputUser : InputUserBase
	{
		public long user_id;
		public long access_hash;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputUserFromMessage"/></summary>
	[TLDef(0x1DA448E2)]
	public partial class InputUserFromMessage : InputUserBase
	{
		public InputPeer peer;
		public int msg_id;
		public long user_id;
	}

	///<summary>See <a href="https://core.telegram.org/type/InputContact"/></summary>
	public abstract partial class InputContact : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPhoneContact"/></summary>
	[TLDef(0xF392B7F4)]
	public partial class InputPhoneContact : InputContact
	{
		public long client_id;
		public string phone;
		public string first_name;
		public string last_name;
	}

	///<summary>See <a href="https://core.telegram.org/type/InputFile"/></summary>
	public abstract partial class InputFileBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputFile"/></summary>
	[TLDef(0xF52FF27F)]
	public partial class InputFile : InputFileBase
	{
		public long id;
		public int parts;
		public string name;
		public byte[] md5_checksum;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputFileBig"/></summary>
	[TLDef(0xFA4F0BB5)]
	public partial class InputFileBig : InputFileBase
	{
		public long id;
		public int parts;
		public string name;
	}

	///<summary>See <a href="https://core.telegram.org/type/InputMedia"/></summary>
	public abstract partial class InputMedia : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputMediaEmpty"/></summary>
	[TLDef(0x9664F57F)]
	public partial class InputMediaEmpty : InputMedia { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputMediaUploadedPhoto"/></summary>
	[TLDef(0x1E287D04)]
	public partial class InputMediaUploadedPhoto : InputMedia
	{
		[Flags] public enum Flags { has_stickers = 0x1, has_ttl_seconds = 0x2 }
		public Flags flags;
		public InputFileBase file;
		[IfFlag(0)] public InputDocumentBase[] stickers;
		[IfFlag(1)] public int ttl_seconds;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputMediaPhoto"/></summary>
	[TLDef(0xB3BA0635)]
	public partial class InputMediaPhoto : InputMedia
	{
		[Flags] public enum Flags { has_ttl_seconds = 0x1 }
		public Flags flags;
		public InputPhotoBase id;
		[IfFlag(0)] public int ttl_seconds;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputMediaGeoPoint"/></summary>
	[TLDef(0xF9C44144)]
	public partial class InputMediaGeoPoint : InputMedia { public InputGeoPointBase geo_point; }
	///<summary>See <a href="https://core.telegram.org/constructor/inputMediaContact"/></summary>
	[TLDef(0xF8AB7DFB)]
	public partial class InputMediaContact : InputMedia
	{
		public string phone_number;
		public string first_name;
		public string last_name;
		public string vcard;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputMediaUploadedDocument"/></summary>
	[TLDef(0x5B38C6C1)]
	public partial class InputMediaUploadedDocument : InputMedia
	{
		[Flags] public enum Flags { has_stickers = 0x1, has_ttl_seconds = 0x2, has_thumb = 0x4, nosound_video = 0x8, force_file = 0x10 }
		public Flags flags;
		public InputFileBase file;
		[IfFlag(2)] public InputFileBase thumb;
		public string mime_type;
		public DocumentAttribute[] attributes;
		[IfFlag(0)] public InputDocumentBase[] stickers;
		[IfFlag(1)] public int ttl_seconds;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputMediaDocument"/></summary>
	[TLDef(0x33473058)]
	public partial class InputMediaDocument : InputMedia
	{
		[Flags] public enum Flags { has_ttl_seconds = 0x1, has_query = 0x2 }
		public Flags flags;
		public InputDocumentBase id;
		[IfFlag(0)] public int ttl_seconds;
		[IfFlag(1)] public string query;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputMediaVenue"/></summary>
	[TLDef(0xC13D1C11)]
	public partial class InputMediaVenue : InputMedia
	{
		public InputGeoPointBase geo_point;
		public string title;
		public string address;
		public string provider;
		public string venue_id;
		public string venue_type;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputMediaPhotoExternal"/></summary>
	[TLDef(0xE5BBFE1A)]
	public partial class InputMediaPhotoExternal : InputMedia
	{
		[Flags] public enum Flags { has_ttl_seconds = 0x1 }
		public Flags flags;
		public string url;
		[IfFlag(0)] public int ttl_seconds;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputMediaDocumentExternal"/></summary>
	[TLDef(0xFB52DC99)]
	public partial class InputMediaDocumentExternal : InputMedia
	{
		[Flags] public enum Flags { has_ttl_seconds = 0x1 }
		public Flags flags;
		public string url;
		[IfFlag(0)] public int ttl_seconds;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputMediaGame"/></summary>
	[TLDef(0xD33F43F3)]
	public partial class InputMediaGame : InputMedia { public InputGame id; }
	///<summary>See <a href="https://core.telegram.org/constructor/inputMediaInvoice"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/inputMediaGeoLive"/></summary>
	[TLDef(0x971FA843)]
	public partial class InputMediaGeoLive : InputMedia
	{
		[Flags] public enum Flags { stopped = 0x1, has_period = 0x2, has_heading = 0x4, has_proximity_notification_radius = 0x8 }
		public Flags flags;
		public InputGeoPointBase geo_point;
		[IfFlag(2)] public int heading;
		[IfFlag(1)] public int period;
		[IfFlag(3)] public int proximity_notification_radius;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputMediaPoll"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/inputMediaDice"/></summary>
	[TLDef(0xE66FBF7B)]
	public partial class InputMediaDice : InputMedia { public string emoticon; }

	///<summary>See <a href="https://core.telegram.org/type/InputChatPhoto"/></summary>
	public abstract partial class InputChatPhotoBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputChatPhotoEmpty"/></summary>
	[TLDef(0x1CA48F57)]
	public partial class InputChatPhotoEmpty : InputChatPhotoBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputChatUploadedPhoto"/></summary>
	[TLDef(0xC642724E)]
	public partial class InputChatUploadedPhoto : InputChatPhotoBase
	{
		[Flags] public enum Flags { has_file = 0x1, has_video = 0x2, has_video_start_ts = 0x4 }
		public Flags flags;
		[IfFlag(0)] public InputFileBase file;
		[IfFlag(1)] public InputFileBase video;
		[IfFlag(2)] public double video_start_ts;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputChatPhoto"/></summary>
	[TLDef(0x8953AD37)]
	public partial class InputChatPhoto : InputChatPhotoBase { public InputPhotoBase id; }

	///<summary>See <a href="https://core.telegram.org/type/InputGeoPoint"/></summary>
	public abstract partial class InputGeoPointBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputGeoPointEmpty"/></summary>
	[TLDef(0xE4C123D6)]
	public partial class InputGeoPointEmpty : InputGeoPointBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputGeoPoint"/></summary>
	[TLDef(0x48222FAF)]
	public partial class InputGeoPoint : InputGeoPointBase
	{
		[Flags] public enum Flags { has_accuracy_radius = 0x1 }
		public Flags flags;
		public double lat;
		public double long_;
		[IfFlag(0)] public int accuracy_radius;
	}

	///<summary>See <a href="https://core.telegram.org/type/InputPhoto"/></summary>
	public abstract partial class InputPhotoBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPhotoEmpty"/></summary>
	[TLDef(0x1CD7BF0D)]
	public partial class InputPhotoEmpty : InputPhotoBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPhoto"/></summary>
	[TLDef(0x3BB3B94A)]
	public partial class InputPhoto : InputPhotoBase
	{
		public long id;
		public long access_hash;
		public byte[] file_reference;
	}

	///<summary>See <a href="https://core.telegram.org/type/InputFileLocation"/></summary>
	public abstract partial class InputFileLocationBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputFileLocation"/></summary>
	[TLDef(0xDFDAABE1)]
	public partial class InputFileLocation : InputFileLocationBase
	{
		public long volume_id;
		public int local_id;
		public long secret;
		public byte[] file_reference;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputEncryptedFileLocation"/></summary>
	[TLDef(0xF5235D55)]
	public partial class InputEncryptedFileLocation : InputFileLocationBase
	{
		public long id;
		public long access_hash;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputDocumentFileLocation"/></summary>
	[TLDef(0xBAD07584)]
	public partial class InputDocumentFileLocation : InputFileLocationBase
	{
		public long id;
		public long access_hash;
		public byte[] file_reference;
		public string thumb_size;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputSecureFileLocation"/></summary>
	[TLDef(0xCBC7EE28)]
	public partial class InputSecureFileLocation : InputFileLocationBase
	{
		public long id;
		public long access_hash;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputTakeoutFileLocation"/></summary>
	[TLDef(0x29BE5899)]
	public partial class InputTakeoutFileLocation : InputFileLocationBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPhotoFileLocation"/></summary>
	[TLDef(0x40181FFE)]
	public partial class InputPhotoFileLocation : InputFileLocationBase
	{
		public long id;
		public long access_hash;
		public byte[] file_reference;
		public string thumb_size;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputPhotoLegacyFileLocation"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/inputPeerPhotoFileLocation"/></summary>
	[TLDef(0x37257E99)]
	public partial class InputPeerPhotoFileLocation : InputFileLocationBase
	{
		[Flags] public enum Flags { big = 0x1 }
		public Flags flags;
		public InputPeer peer;
		public long photo_id;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputStickerSetThumb"/></summary>
	[TLDef(0x9D84F3DB)]
	public partial class InputStickerSetThumb : InputFileLocationBase
	{
		public InputStickerSet stickerset;
		public int thumb_version;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputGroupCallStream"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/type/Peer"/></summary>
	public abstract partial class Peer : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/peerUser"/></summary>
	[TLDef(0x59511722)]
	public partial class PeerUser : Peer { public long user_id; }
	///<summary>See <a href="https://core.telegram.org/constructor/peerChat"/></summary>
	[TLDef(0x36C6019A)]
	public partial class PeerChat : Peer { public long chat_id; }
	///<summary>See <a href="https://core.telegram.org/constructor/peerChannel"/></summary>
	[TLDef(0xA2A5371E)]
	public partial class PeerChannel : Peer { public long channel_id; }

	///<summary>See <a href="https://core.telegram.org/type/storage.FileType"/></summary>
	public abstract partial class Storage_FileType : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/storage.fileUnknown"/></summary>
	[TLDef(0xAA963B05)]
	public partial class Storage_FileUnknown : Storage_FileType { }
	///<summary>See <a href="https://core.telegram.org/constructor/storage.filePartial"/></summary>
	[TLDef(0x40BC6F52)]
	public partial class Storage_FilePartial : Storage_FileType { }
	///<summary>See <a href="https://core.telegram.org/constructor/storage.fileJpeg"/></summary>
	[TLDef(0x007EFE0E)]
	public partial class Storage_FileJpeg : Storage_FileType { }
	///<summary>See <a href="https://core.telegram.org/constructor/storage.fileGif"/></summary>
	[TLDef(0xCAE1AADF)]
	public partial class Storage_FileGif : Storage_FileType { }
	///<summary>See <a href="https://core.telegram.org/constructor/storage.filePng"/></summary>
	[TLDef(0x0A4F63C0)]
	public partial class Storage_FilePng : Storage_FileType { }
	///<summary>See <a href="https://core.telegram.org/constructor/storage.filePdf"/></summary>
	[TLDef(0xAE1E508D)]
	public partial class Storage_FilePdf : Storage_FileType { }
	///<summary>See <a href="https://core.telegram.org/constructor/storage.fileMp3"/></summary>
	[TLDef(0x528A0677)]
	public partial class Storage_FileMp3 : Storage_FileType { }
	///<summary>See <a href="https://core.telegram.org/constructor/storage.fileMov"/></summary>
	[TLDef(0x4B09EBBC)]
	public partial class Storage_FileMov : Storage_FileType { }
	///<summary>See <a href="https://core.telegram.org/constructor/storage.fileMp4"/></summary>
	[TLDef(0xB3CEA0E4)]
	public partial class Storage_FileMp4 : Storage_FileType { }
	///<summary>See <a href="https://core.telegram.org/constructor/storage.fileWebp"/></summary>
	[TLDef(0x1081464C)]
	public partial class Storage_FileWebp : Storage_FileType { }

	///<summary>See <a href="https://core.telegram.org/type/User"/></summary>
	public abstract partial class UserBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/userEmpty"/></summary>
	[TLDef(0xD3BC4B7A)]
	public partial class UserEmpty : UserBase { public long id; }
	///<summary>See <a href="https://core.telegram.org/constructor/user"/></summary>
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
		[IfFlag(5)] public UserProfilePhotoBase photo;
		[IfFlag(6)] public UserStatus status;
		[IfFlag(14)] public int bot_info_version;
		[IfFlag(18)] public RestrictionReason[] restriction_reason;
		[IfFlag(19)] public string bot_inline_placeholder;
		[IfFlag(22)] public string lang_code;
	}

	///<summary>See <a href="https://core.telegram.org/type/UserProfilePhoto"/></summary>
	public abstract partial class UserProfilePhotoBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/userProfilePhotoEmpty"/></summary>
	[TLDef(0x4F11BAE1)]
	public partial class UserProfilePhotoEmpty : UserProfilePhotoBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/userProfilePhoto"/></summary>
	[TLDef(0x82D1F706)]
	public partial class UserProfilePhoto : UserProfilePhotoBase
	{
		[Flags] public enum Flags { has_video = 0x1, has_stripped_thumb = 0x2 }
		public Flags flags;
		public long photo_id;
		[IfFlag(1)] public byte[] stripped_thumb;
		public int dc_id;
	}

	///<summary>See <a href="https://core.telegram.org/type/UserStatus"/></summary>
	public abstract partial class UserStatus : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/userStatusEmpty"/></summary>
	[TLDef(0x09D05049)]
	public partial class UserStatusEmpty : UserStatus { }
	///<summary>See <a href="https://core.telegram.org/constructor/userStatusOnline"/></summary>
	[TLDef(0xEDB93949)]
	public partial class UserStatusOnline : UserStatus { public DateTime expires; }
	///<summary>See <a href="https://core.telegram.org/constructor/userStatusOffline"/></summary>
	[TLDef(0x008C703F)]
	public partial class UserStatusOffline : UserStatus { public int was_online; }
	///<summary>See <a href="https://core.telegram.org/constructor/userStatusRecently"/></summary>
	[TLDef(0xE26F42F1)]
	public partial class UserStatusRecently : UserStatus { }
	///<summary>See <a href="https://core.telegram.org/constructor/userStatusLastWeek"/></summary>
	[TLDef(0x07BF09FC)]
	public partial class UserStatusLastWeek : UserStatus { }
	///<summary>See <a href="https://core.telegram.org/constructor/userStatusLastMonth"/></summary>
	[TLDef(0x77EBC742)]
	public partial class UserStatusLastMonth : UserStatus { }

	///<summary>See <a href="https://core.telegram.org/type/Chat"/></summary>
	public abstract partial class ChatBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/chatEmpty"/></summary>
	[TLDef(0x29562865)]
	public partial class ChatEmpty : ChatBase { public long id; }
	///<summary>See <a href="https://core.telegram.org/constructor/chat"/></summary>
	[TLDef(0x41CBF256)]
	public partial class Chat : ChatBase
	{
		[Flags] public enum Flags { creator = 0x1, kicked = 0x2, left = 0x4, deactivated = 0x20, has_migrated_to = 0x40, 
			has_admin_rights = 0x4000, has_default_banned_rights = 0x40000, call_active = 0x800000, call_not_empty = 0x1000000 }
		public Flags flags;
		public long id;
		public string title;
		public ChatPhotoBase photo;
		public int participants_count;
		public DateTime date;
		public int version;
		[IfFlag(6)] public InputChannelBase migrated_to;
		[IfFlag(14)] public ChatAdminRights admin_rights;
		[IfFlag(18)] public ChatBannedRights default_banned_rights;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/chatForbidden"/></summary>
	[TLDef(0x6592A1A7)]
	public partial class ChatForbidden : ChatBase
	{
		public long id;
		public string title;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/channel"/></summary>
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
		public ChatPhotoBase photo;
		public DateTime date;
		[IfFlag(9)] public RestrictionReason[] restriction_reason;
		[IfFlag(14)] public ChatAdminRights admin_rights;
		[IfFlag(15)] public ChatBannedRights banned_rights;
		[IfFlag(18)] public ChatBannedRights default_banned_rights;
		[IfFlag(17)] public int participants_count;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/channelForbidden"/></summary>
	[TLDef(0x17D493D5)]
	public partial class ChannelForbidden : ChatBase
	{
		[Flags] public enum Flags { broadcast = 0x20, megagroup = 0x100, has_until_date = 0x10000 }
		public Flags flags;
		public long id;
		public long access_hash;
		public string title;
		[IfFlag(16)] public DateTime until_date;
	}

	///<summary>See <a href="https://core.telegram.org/type/ChatFull"/></summary>
	public abstract partial class ChatFullBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/chatFull"/></summary>
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
	}
	///<summary>See <a href="https://core.telegram.org/constructor/channelFull"/></summary>
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
		[IfFlag(15)] public ChannelLocationBase location;
		[IfFlag(17)] public int slowmode_seconds;
		[IfFlag(18)] public DateTime slowmode_next_send_date;
		[IfFlag(12)] public int stats_dc;
		public int pts;
		[IfFlag(21)] public InputGroupCall call;
		[IfFlag(24)] public int ttl_period;
		[IfFlag(25)] public string[] pending_suggestions;
		[IfFlag(26)] public Peer groupcall_default_join_as;
		[IfFlag(27)] public string theme_emoticon;
	}

	///<summary>See <a href="https://core.telegram.org/type/ChatParticipant"/></summary>
	public abstract partial class ChatParticipantBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/chatParticipant"/></summary>
	[TLDef(0xC02D4007)]
	public partial class ChatParticipant : ChatParticipantBase
	{
		public long user_id;
		public long inviter_id;
		public DateTime date;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/chatParticipantCreator"/></summary>
	[TLDef(0xE46BCEE4)]
	public partial class ChatParticipantCreator : ChatParticipantBase { public long user_id; }
	///<summary>See <a href="https://core.telegram.org/constructor/chatParticipantAdmin"/></summary>
	[TLDef(0xA0933F5B)]
	public partial class ChatParticipantAdmin : ChatParticipantBase
	{
		public long user_id;
		public long inviter_id;
		public DateTime date;
	}

	///<summary>See <a href="https://core.telegram.org/type/ChatParticipants"/></summary>
	public abstract partial class ChatParticipantsBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/chatParticipantsForbidden"/></summary>
	[TLDef(0x8763D3E1)]
	public partial class ChatParticipantsForbidden : ChatParticipantsBase
	{
		[Flags] public enum Flags { has_self_participant = 0x1 }
		public Flags flags;
		public long chat_id;
		[IfFlag(0)] public ChatParticipantBase self_participant;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/chatParticipants"/></summary>
	[TLDef(0x3CBC93F8)]
	public partial class ChatParticipants : ChatParticipantsBase
	{
		public long chat_id;
		public ChatParticipantBase[] participants;
		public int version;
	}

	///<summary>See <a href="https://core.telegram.org/type/ChatPhoto"/></summary>
	public abstract partial class ChatPhotoBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/chatPhotoEmpty"/></summary>
	[TLDef(0x37C1011C)]
	public partial class ChatPhotoEmpty : ChatPhotoBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/chatPhoto"/></summary>
	[TLDef(0x1C6E1C11)]
	public partial class ChatPhoto : ChatPhotoBase
	{
		[Flags] public enum Flags { has_video = 0x1, has_stripped_thumb = 0x2 }
		public Flags flags;
		public long photo_id;
		[IfFlag(1)] public byte[] stripped_thumb;
		public int dc_id;
	}

	///<summary>See <a href="https://core.telegram.org/type/Message"/></summary>
	public abstract partial class MessageBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageEmpty"/></summary>
	[TLDef(0x90A6CA84)]
	public partial class MessageEmpty : MessageBase
	{
		[Flags] public enum Flags { has_peer_id = 0x1 }
		public Flags flags;
		public int id;
		[IfFlag(0)] public Peer peer_id;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/message"/></summary>
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
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messageService"/></summary>
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
	}

	///<summary>See <a href="https://core.telegram.org/type/MessageMedia"/></summary>
	public abstract partial class MessageMedia : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageMediaEmpty"/></summary>
	[TLDef(0x3DED6320)]
	public partial class MessageMediaEmpty : MessageMedia { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageMediaPhoto"/></summary>
	[TLDef(0x695150D7)]
	public partial class MessageMediaPhoto : MessageMedia
	{
		[Flags] public enum Flags { has_photo = 0x1, has_ttl_seconds = 0x4 }
		public Flags flags;
		[IfFlag(0)] public PhotoBase photo;
		[IfFlag(2)] public int ttl_seconds;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messageMediaGeo"/></summary>
	[TLDef(0x56E0D474)]
	public partial class MessageMediaGeo : MessageMedia { public GeoPointBase geo; }
	///<summary>See <a href="https://core.telegram.org/constructor/messageMediaContact"/></summary>
	[TLDef(0x70322949)]
	public partial class MessageMediaContact : MessageMedia
	{
		public string phone_number;
		public string first_name;
		public string last_name;
		public string vcard;
		public long user_id;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messageMediaUnsupported"/></summary>
	[TLDef(0x9F84F49E)]
	public partial class MessageMediaUnsupported : MessageMedia { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageMediaDocument"/></summary>
	[TLDef(0x9CB070D7)]
	public partial class MessageMediaDocument : MessageMedia
	{
		[Flags] public enum Flags { has_document = 0x1, has_ttl_seconds = 0x4 }
		public Flags flags;
		[IfFlag(0)] public DocumentBase document;
		[IfFlag(2)] public int ttl_seconds;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messageMediaWebPage"/></summary>
	[TLDef(0xA32DD600)]
	public partial class MessageMediaWebPage : MessageMedia { public WebPageBase webpage; }
	///<summary>See <a href="https://core.telegram.org/constructor/messageMediaVenue"/></summary>
	[TLDef(0x2EC0533F)]
	public partial class MessageMediaVenue : MessageMedia
	{
		public GeoPointBase geo;
		public string title;
		public string address;
		public string provider;
		public string venue_id;
		public string venue_type;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messageMediaGame"/></summary>
	[TLDef(0xFDB19008)]
	public partial class MessageMediaGame : MessageMedia { public Game game; }
	///<summary>See <a href="https://core.telegram.org/constructor/messageMediaInvoice"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/messageMediaGeoLive"/></summary>
	[TLDef(0xB940C666)]
	public partial class MessageMediaGeoLive : MessageMedia
	{
		[Flags] public enum Flags { has_heading = 0x1, has_proximity_notification_radius = 0x2 }
		public Flags flags;
		public GeoPointBase geo;
		[IfFlag(0)] public int heading;
		public int period;
		[IfFlag(1)] public int proximity_notification_radius;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messageMediaPoll"/></summary>
	[TLDef(0x4BD6E798)]
	public partial class MessageMediaPoll : MessageMedia
	{
		public Poll poll;
		public PollResults results;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messageMediaDice"/></summary>
	[TLDef(0x3F7EE58B)]
	public partial class MessageMediaDice : MessageMedia
	{
		public int value;
		public string emoticon;
	}

	///<summary>See <a href="https://core.telegram.org/type/MessageAction"/></summary>
	public abstract partial class MessageAction : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionEmpty"/></summary>
	[TLDef(0xB6AEF7B0)]
	public partial class MessageActionEmpty : MessageAction { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionChatCreate"/></summary>
	[TLDef(0xBD47CBAD)]
	public partial class MessageActionChatCreate : MessageAction
	{
		public string title;
		public long[] users;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionChatEditTitle"/></summary>
	[TLDef(0xB5A1CE5A)]
	public partial class MessageActionChatEditTitle : MessageAction { public string title; }
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionChatEditPhoto"/></summary>
	[TLDef(0x7FCB13A8)]
	public partial class MessageActionChatEditPhoto : MessageAction { public PhotoBase photo; }
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionChatDeletePhoto"/></summary>
	[TLDef(0x95E3FBEF)]
	public partial class MessageActionChatDeletePhoto : MessageAction { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionChatAddUser"/></summary>
	[TLDef(0x15CEFD00)]
	public partial class MessageActionChatAddUser : MessageAction { public long[] users; }
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionChatDeleteUser"/></summary>
	[TLDef(0xA43F30CC)]
	public partial class MessageActionChatDeleteUser : MessageAction { public long user_id; }
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionChatJoinedByLink"/></summary>
	[TLDef(0x031224C3)]
	public partial class MessageActionChatJoinedByLink : MessageAction { public long inviter_id; }
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionChannelCreate"/></summary>
	[TLDef(0x95D2AC92)]
	public partial class MessageActionChannelCreate : MessageAction { public string title; }
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionChatMigrateTo"/></summary>
	[TLDef(0xE1037F92)]
	public partial class MessageActionChatMigrateTo : MessageAction { public long channel_id; }
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionChannelMigrateFrom"/></summary>
	[TLDef(0xEA3948E9)]
	public partial class MessageActionChannelMigrateFrom : MessageAction
	{
		public string title;
		public long chat_id;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionPinMessage"/></summary>
	[TLDef(0x94BD38ED)]
	public partial class MessageActionPinMessage : MessageAction { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionHistoryClear"/></summary>
	[TLDef(0x9FBAB604)]
	public partial class MessageActionHistoryClear : MessageAction { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionGameScore"/></summary>
	[TLDef(0x92A72876)]
	public partial class MessageActionGameScore : MessageAction
	{
		public long game_id;
		public int score;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionPaymentSentMe"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionPaymentSent"/></summary>
	[TLDef(0x40699CD0)]
	public partial class MessageActionPaymentSent : MessageAction
	{
		public string currency;
		public long total_amount;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionPhoneCall"/></summary>
	[TLDef(0x80E11A7F)]
	public partial class MessageActionPhoneCall : MessageAction
	{
		[Flags] public enum Flags { has_reason = 0x1, has_duration = 0x2, video = 0x4 }
		public Flags flags;
		public long call_id;
		[IfFlag(0)] public PhoneCallDiscardReason reason;
		[IfFlag(1)] public int duration;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionScreenshotTaken"/></summary>
	[TLDef(0x4792929B)]
	public partial class MessageActionScreenshotTaken : MessageAction { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionCustomAction"/></summary>
	[TLDef(0xFAE69F56)]
	public partial class MessageActionCustomAction : MessageAction { public string message; }
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionBotAllowed"/></summary>
	[TLDef(0xABE9AFFE)]
	public partial class MessageActionBotAllowed : MessageAction { public string domain; }
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionSecureValuesSentMe"/></summary>
	[TLDef(0x1B287353)]
	public partial class MessageActionSecureValuesSentMe : MessageAction
	{
		public SecureValue[] values;
		public SecureCredentialsEncrypted credentials;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionSecureValuesSent"/></summary>
	[TLDef(0xD95C6154)]
	public partial class MessageActionSecureValuesSent : MessageAction { public SecureValueType[] types; }
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionContactSignUp"/></summary>
	[TLDef(0xF3F25F76)]
	public partial class MessageActionContactSignUp : MessageAction { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionGeoProximityReached"/></summary>
	[TLDef(0x98E0D697)]
	public partial class MessageActionGeoProximityReached : MessageAction
	{
		public Peer from_id;
		public Peer to_id;
		public int distance;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionGroupCall"/></summary>
	[TLDef(0x7A0D7F42)]
	public partial class MessageActionGroupCall : MessageAction
	{
		[Flags] public enum Flags { has_duration = 0x1 }
		public Flags flags;
		public InputGroupCall call;
		[IfFlag(0)] public int duration;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionInviteToGroupCall"/></summary>
	[TLDef(0x502F92F7)]
	public partial class MessageActionInviteToGroupCall : MessageAction
	{
		public InputGroupCall call;
		public long[] users;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionSetMessagesTTL"/></summary>
	[TLDef(0xAA1AFBFD)]
	public partial class MessageActionSetMessagesTTL : MessageAction { public int period; }
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionGroupCallScheduled"/></summary>
	[TLDef(0xB3A07661)]
	public partial class MessageActionGroupCallScheduled : MessageAction
	{
		public InputGroupCall call;
		public DateTime schedule_date;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messageActionSetChatTheme"/></summary>
	[TLDef(0xAA786345)]
	public partial class MessageActionSetChatTheme : MessageAction { public string emoticon; }

	///<summary>See <a href="https://core.telegram.org/type/Dialog"/></summary>
	public abstract partial class DialogBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/dialog"/></summary>
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
	}
	///<summary>See <a href="https://core.telegram.org/constructor/dialogFolder"/></summary>
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
	}

	///<summary>See <a href="https://core.telegram.org/type/Photo"/></summary>
	public abstract partial class PhotoBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/photoEmpty"/></summary>
	[TLDef(0x2331B22D)]
	public partial class PhotoEmpty : PhotoBase { public long id; }
	///<summary>See <a href="https://core.telegram.org/constructor/photo"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/type/PhotoSize"/></summary>
	public abstract partial class PhotoSizeBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/photoSizeEmpty"/></summary>
	[TLDef(0x0E17E23C)]
	public partial class PhotoSizeEmpty : PhotoSizeBase { public string type; }
	///<summary>See <a href="https://core.telegram.org/constructor/photoSize"/></summary>
	[TLDef(0x75C78E60)]
	public partial class PhotoSize : PhotoSizeBase
	{
		public string type;
		public int w;
		public int h;
		public int size;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/photoCachedSize"/></summary>
	[TLDef(0x021E1AD6)]
	public partial class PhotoCachedSize : PhotoSizeBase
	{
		public string type;
		public int w;
		public int h;
		public byte[] bytes;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/photoStrippedSize"/></summary>
	[TLDef(0xE0B0BC2E)]
	public partial class PhotoStrippedSize : PhotoSizeBase
	{
		public string type;
		public byte[] bytes;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/photoSizeProgressive"/></summary>
	[TLDef(0xFA3EFB95)]
	public partial class PhotoSizeProgressive : PhotoSizeBase
	{
		public string type;
		public int w;
		public int h;
		public int[] sizes;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/photoPathSize"/></summary>
	[TLDef(0xD8214D41)]
	public partial class PhotoPathSize : PhotoSizeBase
	{
		public string type;
		public byte[] bytes;
	}

	///<summary>See <a href="https://core.telegram.org/type/GeoPoint"/></summary>
	public abstract partial class GeoPointBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/geoPointEmpty"/></summary>
	[TLDef(0x1117DD5F)]
	public partial class GeoPointEmpty : GeoPointBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/geoPoint"/></summary>
	[TLDef(0xB2A2F663)]
	public partial class GeoPoint : GeoPointBase
	{
		[Flags] public enum Flags { has_accuracy_radius = 0x1 }
		public Flags flags;
		public double long_;
		public double lat;
		public long access_hash;
		[IfFlag(0)] public int accuracy_radius;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/auth.sentCode"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/type/auth.Authorization"/></summary>
	public abstract partial class Auth_AuthorizationBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/auth.authorization"/></summary>
	[TLDef(0xCD050916)]
	public partial class Auth_Authorization : Auth_AuthorizationBase
	{
		[Flags] public enum Flags { has_tmp_sessions = 0x1 }
		public Flags flags;
		[IfFlag(0)] public int tmp_sessions;
		public UserBase user;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/auth.authorizationSignUpRequired"/></summary>
	[TLDef(0x44747E9A)]
	public partial class Auth_AuthorizationSignUpRequired : Auth_AuthorizationBase
	{
		[Flags] public enum Flags { has_terms_of_service = 0x1 }
		public Flags flags;
		[IfFlag(0)] public Help_TermsOfService terms_of_service;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/auth.exportedAuthorization"/></summary>
	[TLDef(0xB434E2B8)]
	public partial class Auth_ExportedAuthorization : ITLObject
	{
		public long id;
		public byte[] bytes;
	}

	///<summary>See <a href="https://core.telegram.org/type/InputNotifyPeer"/></summary>
	public abstract partial class InputNotifyPeerBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputNotifyPeer"/></summary>
	[TLDef(0xB8BC5B0C)]
	public partial class InputNotifyPeer : InputNotifyPeerBase { public InputPeer peer; }
	///<summary>See <a href="https://core.telegram.org/constructor/inputNotifyUsers"/></summary>
	[TLDef(0x193B4417)]
	public partial class InputNotifyUsers : InputNotifyPeerBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputNotifyChats"/></summary>
	[TLDef(0x4A95E84E)]
	public partial class InputNotifyChats : InputNotifyPeerBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputNotifyBroadcasts"/></summary>
	[TLDef(0xB1DB7C7E)]
	public partial class InputNotifyBroadcasts : InputNotifyPeerBase { }

	///<summary>See <a href="https://core.telegram.org/constructor/inputPeerNotifySettings"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/peerNotifySettings"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/peerSettings"/></summary>
	[TLDef(0x733F2961)]
	public partial class PeerSettings : ITLObject
	{
		[Flags] public enum Flags { report_spam = 0x1, add_contact = 0x2, block_contact = 0x4, share_contact = 0x8, 
			need_contacts_exception = 0x10, report_geo = 0x20, has_geo_distance = 0x40, autoarchived = 0x80, invite_members = 0x100 }
		public Flags flags;
		[IfFlag(6)] public int geo_distance;
	}

	///<summary>See <a href="https://core.telegram.org/type/WallPaper"/></summary>
	public abstract partial class WallPaperBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/wallPaper"/></summary>
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
	}
	///<summary>See <a href="https://core.telegram.org/constructor/wallPaperNoFile"/></summary>
	[TLDef(0xE0804116)]
	public partial class WallPaperNoFile : WallPaperBase
	{
		[Flags] public enum Flags { default_ = 0x2, has_settings = 0x4, dark = 0x10 }
		public long id;
		public Flags flags;
		[IfFlag(2)] public WallPaperSettings settings;
	}

	///<summary>See <a href="https://core.telegram.org/type/ReportReason"/></summary>
	public abstract partial class ReportReason : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputReportReasonSpam"/></summary>
	[TLDef(0x58DBCAB8)]
	public partial class InputReportReasonSpam : ReportReason { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputReportReasonViolence"/></summary>
	[TLDef(0x1E22C78D)]
	public partial class InputReportReasonViolence : ReportReason { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputReportReasonPornography"/></summary>
	[TLDef(0x2E59D922)]
	public partial class InputReportReasonPornography : ReportReason { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputReportReasonChildAbuse"/></summary>
	[TLDef(0xADF44EE3)]
	public partial class InputReportReasonChildAbuse : ReportReason { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputReportReasonOther"/></summary>
	[TLDef(0xC1E4A2B1)]
	public partial class InputReportReasonOther : ReportReason { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputReportReasonCopyright"/></summary>
	[TLDef(0x9B89F93A)]
	public partial class InputReportReasonCopyright : ReportReason { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputReportReasonGeoIrrelevant"/></summary>
	[TLDef(0xDBD4FEED)]
	public partial class InputReportReasonGeoIrrelevant : ReportReason { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputReportReasonFake"/></summary>
	[TLDef(0xF5DDD6E7)]
	public partial class InputReportReasonFake : ReportReason { }

	///<summary>See <a href="https://core.telegram.org/constructor/userFull"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/contact"/></summary>
	[TLDef(0x145ADE0B)]
	public partial class Contact : ITLObject
	{
		public long user_id;
		public bool mutual;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/importedContact"/></summary>
	[TLDef(0xC13E3C50)]
	public partial class ImportedContact : ITLObject
	{
		public long user_id;
		public long client_id;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/contactStatus"/></summary>
	[TLDef(0x16D9703B)]
	public partial class ContactStatus : ITLObject
	{
		public long user_id;
		public UserStatus status;
	}

	///<summary>See <a href="https://core.telegram.org/type/contacts.Contacts"/></summary>
	public abstract partial class Contacts_ContactsBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/contacts.contactsNotModified"/></summary>
	[TLDef(0xB74BA9D2)]
	public partial class Contacts_ContactsNotModified : Contacts_ContactsBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/contacts.contacts"/></summary>
	[TLDef(0xEAE87E42)]
	public partial class Contacts_Contacts : Contacts_ContactsBase
	{
		public Contact[] contacts;
		public int saved_count;
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/contacts.importedContacts"/></summary>
	[TLDef(0x77D01C3B)]
	public partial class Contacts_ImportedContacts : ITLObject
	{
		public ImportedContact[] imported;
		public PopularContact[] popular_invites;
		public long[] retry_contacts;
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/type/contacts.Blocked"/></summary>
	public abstract partial class Contacts_BlockedBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/contacts.blocked"/></summary>
	[TLDef(0x0ADE1591)]
	public partial class Contacts_Blocked : Contacts_BlockedBase
	{
		public PeerBlocked[] blocked;
		public ChatBase[] chats;
		public UserBase[] users;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/contacts.blockedSlice"/></summary>
	[TLDef(0xE1664194)]
	public partial class Contacts_BlockedSlice : Contacts_BlockedBase
	{
		public int count;
		public PeerBlocked[] blocked;
		public ChatBase[] chats;
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/type/messages.Dialogs"/></summary>
	public abstract partial class Messages_DialogsBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/messages.dialogs"/></summary>
	[TLDef(0x15BA6C40)]
	public partial class Messages_Dialogs : Messages_DialogsBase
	{
		public DialogBase[] dialogs;
		public MessageBase[] messages;
		public ChatBase[] chats;
		public UserBase[] users;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messages.dialogsSlice"/></summary>
	[TLDef(0x71E094F3)]
	public partial class Messages_DialogsSlice : Messages_DialogsBase
	{
		public int count;
		public DialogBase[] dialogs;
		public MessageBase[] messages;
		public ChatBase[] chats;
		public UserBase[] users;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messages.dialogsNotModified"/></summary>
	[TLDef(0xF0E3E596)]
	public partial class Messages_DialogsNotModified : Messages_DialogsBase { public int count; }

	///<summary>See <a href="https://core.telegram.org/type/messages.Messages"/></summary>
	public abstract partial class Messages_MessagesBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/messages.messages"/></summary>
	[TLDef(0x8C718E87)]
	public partial class Messages_Messages : Messages_MessagesBase
	{
		public MessageBase[] messages;
		public ChatBase[] chats;
		public UserBase[] users;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messages.messagesSlice"/></summary>
	[TLDef(0x3A54685E)]
	public partial class Messages_MessagesSlice : Messages_MessagesBase
	{
		[Flags] public enum Flags { has_next_rate = 0x1, inexact = 0x2, has_offset_id_offset = 0x4 }
		public Flags flags;
		public int count;
		[IfFlag(0)] public int next_rate;
		[IfFlag(2)] public int offset_id_offset;
		public MessageBase[] messages;
		public ChatBase[] chats;
		public UserBase[] users;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messages.channelMessages"/></summary>
	[TLDef(0x64479808)]
	public partial class Messages_ChannelMessages : Messages_MessagesBase
	{
		[Flags] public enum Flags { inexact = 0x2, has_offset_id_offset = 0x4 }
		public Flags flags;
		public int pts;
		public int count;
		[IfFlag(2)] public int offset_id_offset;
		public MessageBase[] messages;
		public ChatBase[] chats;
		public UserBase[] users;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messages.messagesNotModified"/></summary>
	[TLDef(0x74535F21)]
	public partial class Messages_MessagesNotModified : Messages_MessagesBase { public int count; }

	///<summary>See <a href="https://core.telegram.org/type/messages.Chats"/></summary>
	public abstract partial class Messages_ChatsBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/messages.chats"/></summary>
	[TLDef(0x64FF9FD5)]
	public partial class Messages_Chats : Messages_ChatsBase { public ChatBase[] chats; }
	///<summary>See <a href="https://core.telegram.org/constructor/messages.chatsSlice"/></summary>
	[TLDef(0x9CD81144)]
	public partial class Messages_ChatsSlice : Messages_ChatsBase
	{
		public int count;
		public ChatBase[] chats;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/messages.chatFull"/></summary>
	[TLDef(0xE5D7D19C)]
	public partial class Messages_ChatFull : ITLObject
	{
		public ChatFullBase full_chat;
		public ChatBase[] chats;
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/messages.affectedHistory"/></summary>
	[TLDef(0xB45C69D1)]
	public partial class Messages_AffectedHistory : ITLObject
	{
		public int pts;
		public int pts_count;
		public int offset;
	}

	///<summary>See <a href="https://core.telegram.org/type/MessagesFilter"/></summary>
	public abstract partial class MessagesFilter : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputMessagesFilterEmpty"/></summary>
	[TLDef(0x57E2F66C)]
	public partial class InputMessagesFilterEmpty : MessagesFilter { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputMessagesFilterPhotos"/></summary>
	[TLDef(0x9609A51C)]
	public partial class InputMessagesFilterPhotos : MessagesFilter { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputMessagesFilterVideo"/></summary>
	[TLDef(0x9FC00E65)]
	public partial class InputMessagesFilterVideo : MessagesFilter { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputMessagesFilterPhotoVideo"/></summary>
	[TLDef(0x56E9F0E4)]
	public partial class InputMessagesFilterPhotoVideo : MessagesFilter { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputMessagesFilterDocument"/></summary>
	[TLDef(0x9EDDF188)]
	public partial class InputMessagesFilterDocument : MessagesFilter { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputMessagesFilterUrl"/></summary>
	[TLDef(0x7EF0DD87)]
	public partial class InputMessagesFilterUrl : MessagesFilter { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputMessagesFilterGif"/></summary>
	[TLDef(0xFFC86587)]
	public partial class InputMessagesFilterGif : MessagesFilter { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputMessagesFilterVoice"/></summary>
	[TLDef(0x50F5C392)]
	public partial class InputMessagesFilterVoice : MessagesFilter { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputMessagesFilterMusic"/></summary>
	[TLDef(0x3751B49E)]
	public partial class InputMessagesFilterMusic : MessagesFilter { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputMessagesFilterChatPhotos"/></summary>
	[TLDef(0x3A20ECB8)]
	public partial class InputMessagesFilterChatPhotos : MessagesFilter { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputMessagesFilterPhoneCalls"/></summary>
	[TLDef(0x80C99768)]
	public partial class InputMessagesFilterPhoneCalls : MessagesFilter
	{
		[Flags] public enum Flags { missed = 0x1 }
		public Flags flags;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputMessagesFilterRoundVoice"/></summary>
	[TLDef(0x7A7C17A4)]
	public partial class InputMessagesFilterRoundVoice : MessagesFilter { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputMessagesFilterRoundVideo"/></summary>
	[TLDef(0xB549DA53)]
	public partial class InputMessagesFilterRoundVideo : MessagesFilter { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputMessagesFilterMyMentions"/></summary>
	[TLDef(0xC1F8E69A)]
	public partial class InputMessagesFilterMyMentions : MessagesFilter { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputMessagesFilterGeo"/></summary>
	[TLDef(0xE7026D0D)]
	public partial class InputMessagesFilterGeo : MessagesFilter { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputMessagesFilterContacts"/></summary>
	[TLDef(0xE062DB83)]
	public partial class InputMessagesFilterContacts : MessagesFilter { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputMessagesFilterPinned"/></summary>
	[TLDef(0x1BB00451)]
	public partial class InputMessagesFilterPinned : MessagesFilter { }

	///<summary>See <a href="https://core.telegram.org/type/Update"/></summary>
	public abstract partial class Update : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/updateNewMessage"/></summary>
	[TLDef(0x1F2B0AFD)]
	public partial class UpdateNewMessage : Update
	{
		public MessageBase message;
		public int pts;
		public int pts_count;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateMessageID"/></summary>
	[TLDef(0x4E90BFD6)]
	public partial class UpdateMessageID : Update
	{
		public int id;
		public long random_id;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateDeleteMessages"/></summary>
	[TLDef(0xA20DB0E5)]
	public partial class UpdateDeleteMessages : Update
	{
		public int[] messages;
		public int pts;
		public int pts_count;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateUserTyping"/></summary>
	[TLDef(0xC01E857F)]
	public partial class UpdateUserTyping : Update
	{
		public long user_id;
		public SendMessageAction action;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateChatUserTyping"/></summary>
	[TLDef(0x83487AF0)]
	public partial class UpdateChatUserTyping : Update
	{
		public long chat_id;
		public Peer from_id;
		public SendMessageAction action;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateChatParticipants"/></summary>
	[TLDef(0x07761198)]
	public partial class UpdateChatParticipants : Update { public ChatParticipantsBase participants; }
	///<summary>See <a href="https://core.telegram.org/constructor/updateUserStatus"/></summary>
	[TLDef(0xE5BDF8DE)]
	public partial class UpdateUserStatus : Update
	{
		public long user_id;
		public UserStatus status;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateUserName"/></summary>
	[TLDef(0xC3F202E0)]
	public partial class UpdateUserName : Update
	{
		public long user_id;
		public string first_name;
		public string last_name;
		public string username;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateUserPhoto"/></summary>
	[TLDef(0xF227868C)]
	public partial class UpdateUserPhoto : Update
	{
		public long user_id;
		public DateTime date;
		public UserProfilePhotoBase photo;
		public bool previous;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateNewEncryptedMessage"/></summary>
	[TLDef(0x12BCBD9A)]
	public partial class UpdateNewEncryptedMessage : Update
	{
		public EncryptedMessageBase message;
		public int qts;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateEncryptedChatTyping"/></summary>
	[TLDef(0x1710F156)]
	public partial class UpdateEncryptedChatTyping : Update { public int chat_id; }
	///<summary>See <a href="https://core.telegram.org/constructor/updateEncryption"/></summary>
	[TLDef(0xB4A2E88D)]
	public partial class UpdateEncryption : Update
	{
		public EncryptedChatBase chat;
		public DateTime date;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateEncryptedMessagesRead"/></summary>
	[TLDef(0x38FE25B7)]
	public partial class UpdateEncryptedMessagesRead : Update
	{
		public int chat_id;
		public DateTime max_date;
		public DateTime date;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateChatParticipantAdd"/></summary>
	[TLDef(0x3DDA5451)]
	public partial class UpdateChatParticipantAdd : Update
	{
		public long chat_id;
		public long user_id;
		public long inviter_id;
		public DateTime date;
		public int version;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateChatParticipantDelete"/></summary>
	[TLDef(0xE32F3D77)]
	public partial class UpdateChatParticipantDelete : Update
	{
		public long chat_id;
		public long user_id;
		public int version;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateDcOptions"/></summary>
	[TLDef(0x8E5E9873)]
	public partial class UpdateDcOptions : Update { public DcOption[] dc_options; }
	///<summary>See <a href="https://core.telegram.org/constructor/updateNotifySettings"/></summary>
	[TLDef(0xBEC268EF)]
	public partial class UpdateNotifySettings : Update
	{
		public NotifyPeerBase peer;
		public PeerNotifySettings notify_settings;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateServiceNotification"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/updatePrivacy"/></summary>
	[TLDef(0xEE3B272A)]
	public partial class UpdatePrivacy : Update
	{
		public PrivacyKey key;
		public PrivacyRule[] rules;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateUserPhone"/></summary>
	[TLDef(0x05492A13)]
	public partial class UpdateUserPhone : Update
	{
		public long user_id;
		public string phone;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateReadHistoryInbox"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/updateReadHistoryOutbox"/></summary>
	[TLDef(0x2F2F21BF)]
	public partial class UpdateReadHistoryOutbox : Update
	{
		public Peer peer;
		public int max_id;
		public int pts;
		public int pts_count;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateWebPage"/></summary>
	[TLDef(0x7F891213)]
	public partial class UpdateWebPage : Update
	{
		public WebPageBase webpage;
		public int pts;
		public int pts_count;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateReadMessagesContents"/></summary>
	[TLDef(0x68C13933)]
	public partial class UpdateReadMessagesContents : Update
	{
		public int[] messages;
		public int pts;
		public int pts_count;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateChannelTooLong"/></summary>
	[TLDef(0x108D941F)]
	public partial class UpdateChannelTooLong : Update
	{
		[Flags] public enum Flags { has_pts = 0x1 }
		public Flags flags;
		public long channel_id;
		[IfFlag(0)] public int pts;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateChannel"/></summary>
	[TLDef(0x635B4C09)]
	public partial class UpdateChannel : Update { public long channel_id; }
	///<summary>See <a href="https://core.telegram.org/constructor/updateNewChannelMessage"/></summary>
	[TLDef(0x62BA04D9)]
	public partial class UpdateNewChannelMessage : Update
	{
		public MessageBase message;
		public int pts;
		public int pts_count;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateReadChannelInbox"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/updateDeleteChannelMessages"/></summary>
	[TLDef(0xC32D5B12)]
	public partial class UpdateDeleteChannelMessages : Update
	{
		public long channel_id;
		public int[] messages;
		public int pts;
		public int pts_count;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateChannelMessageViews"/></summary>
	[TLDef(0xF226AC08)]
	public partial class UpdateChannelMessageViews : Update
	{
		public long channel_id;
		public int id;
		public int views;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateChatParticipantAdmin"/></summary>
	[TLDef(0xD7CA61A2)]
	public partial class UpdateChatParticipantAdmin : Update
	{
		public long chat_id;
		public long user_id;
		public bool is_admin;
		public int version;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateNewStickerSet"/></summary>
	[TLDef(0x688A30AA)]
	public partial class UpdateNewStickerSet : Update { public Messages_StickerSet stickerset; }
	///<summary>See <a href="https://core.telegram.org/constructor/updateStickerSetsOrder"/></summary>
	[TLDef(0x0BB2D201)]
	public partial class UpdateStickerSetsOrder : Update
	{
		[Flags] public enum Flags { masks = 0x1 }
		public Flags flags;
		public long[] order;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateStickerSets"/></summary>
	[TLDef(0x43AE3DEC)]
	public partial class UpdateStickerSets : Update { }
	///<summary>See <a href="https://core.telegram.org/constructor/updateSavedGifs"/></summary>
	[TLDef(0x9375341E)]
	public partial class UpdateSavedGifs : Update { }
	///<summary>See <a href="https://core.telegram.org/constructor/updateBotInlineQuery"/></summary>
	[TLDef(0x496F379C)]
	public partial class UpdateBotInlineQuery : Update
	{
		[Flags] public enum Flags { has_geo = 0x1, has_peer_type = 0x2 }
		public Flags flags;
		public long query_id;
		public long user_id;
		public string query;
		[IfFlag(0)] public GeoPointBase geo;
		[IfFlag(1)] public InlineQueryPeerType peer_type;
		public string offset;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateBotInlineSend"/></summary>
	[TLDef(0x12F12A07)]
	public partial class UpdateBotInlineSend : Update
	{
		[Flags] public enum Flags { has_geo = 0x1, has_msg_id = 0x2 }
		public Flags flags;
		public long user_id;
		public string query;
		[IfFlag(0)] public GeoPointBase geo;
		public string id;
		[IfFlag(1)] public InputBotInlineMessageIDBase msg_id;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateEditChannelMessage"/></summary>
	[TLDef(0x1B3F4DF7)]
	public partial class UpdateEditChannelMessage : Update
	{
		public MessageBase message;
		public int pts;
		public int pts_count;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateBotCallbackQuery"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/updateEditMessage"/></summary>
	[TLDef(0xE40370A3)]
	public partial class UpdateEditMessage : Update
	{
		public MessageBase message;
		public int pts;
		public int pts_count;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateInlineBotCallbackQuery"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/updateReadChannelOutbox"/></summary>
	[TLDef(0xB75F99A9)]
	public partial class UpdateReadChannelOutbox : Update
	{
		public long channel_id;
		public int max_id;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateDraftMessage"/></summary>
	[TLDef(0xEE2BB969)]
	public partial class UpdateDraftMessage : Update
	{
		public Peer peer;
		public DraftMessageBase draft;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateReadFeaturedStickers"/></summary>
	[TLDef(0x571D2742)]
	public partial class UpdateReadFeaturedStickers : Update { }
	///<summary>See <a href="https://core.telegram.org/constructor/updateRecentStickers"/></summary>
	[TLDef(0x9A422C20)]
	public partial class UpdateRecentStickers : Update { }
	///<summary>See <a href="https://core.telegram.org/constructor/updateConfig"/></summary>
	[TLDef(0xA229DD06)]
	public partial class UpdateConfig : Update { }
	///<summary>See <a href="https://core.telegram.org/constructor/updatePtsChanged"/></summary>
	[TLDef(0x3354678F)]
	public partial class UpdatePtsChanged : Update { }
	///<summary>See <a href="https://core.telegram.org/constructor/updateChannelWebPage"/></summary>
	[TLDef(0x2F2BA99F)]
	public partial class UpdateChannelWebPage : Update
	{
		public long channel_id;
		public WebPageBase webpage;
		public int pts;
		public int pts_count;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateDialogPinned"/></summary>
	[TLDef(0x6E6FE51C)]
	public partial class UpdateDialogPinned : Update
	{
		[Flags] public enum Flags { pinned = 0x1, has_folder_id = 0x2 }
		public Flags flags;
		[IfFlag(1)] public int folder_id;
		public DialogPeerBase peer;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updatePinnedDialogs"/></summary>
	[TLDef(0xFA0F3CA2)]
	public partial class UpdatePinnedDialogs : Update
	{
		[Flags] public enum Flags { has_order = 0x1, has_folder_id = 0x2 }
		public Flags flags;
		[IfFlag(1)] public int folder_id;
		[IfFlag(0)] public DialogPeerBase[] order;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateBotWebhookJSON"/></summary>
	[TLDef(0x8317C0C3)]
	public partial class UpdateBotWebhookJSON : Update { public DataJSON data; }
	///<summary>See <a href="https://core.telegram.org/constructor/updateBotWebhookJSONQuery"/></summary>
	[TLDef(0x9B9240A6)]
	public partial class UpdateBotWebhookJSONQuery : Update
	{
		public long query_id;
		public DataJSON data;
		public int timeout;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateBotShippingQuery"/></summary>
	[TLDef(0xB5AEFD7D)]
	public partial class UpdateBotShippingQuery : Update
	{
		public long query_id;
		public long user_id;
		public byte[] payload;
		public PostAddress shipping_address;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateBotPrecheckoutQuery"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/updatePhoneCall"/></summary>
	[TLDef(0xAB0F6B1E)]
	public partial class UpdatePhoneCall : Update { public PhoneCallBase phone_call; }
	///<summary>See <a href="https://core.telegram.org/constructor/updateLangPackTooLong"/></summary>
	[TLDef(0x46560264)]
	public partial class UpdateLangPackTooLong : Update { public string lang_code; }
	///<summary>See <a href="https://core.telegram.org/constructor/updateLangPack"/></summary>
	[TLDef(0x56022F4D)]
	public partial class UpdateLangPack : Update { public LangPackDifference difference; }
	///<summary>See <a href="https://core.telegram.org/constructor/updateFavedStickers"/></summary>
	[TLDef(0xE511996D)]
	public partial class UpdateFavedStickers : Update { }
	///<summary>See <a href="https://core.telegram.org/constructor/updateChannelReadMessagesContents"/></summary>
	[TLDef(0x44BDD535)]
	public partial class UpdateChannelReadMessagesContents : Update
	{
		public long channel_id;
		public int[] messages;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateContactsReset"/></summary>
	[TLDef(0x7084A7BE)]
	public partial class UpdateContactsReset : Update { }
	///<summary>See <a href="https://core.telegram.org/constructor/updateChannelAvailableMessages"/></summary>
	[TLDef(0xB23FC698)]
	public partial class UpdateChannelAvailableMessages : Update
	{
		public long channel_id;
		public int available_min_id;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateDialogUnreadMark"/></summary>
	[TLDef(0xE16459C3)]
	public partial class UpdateDialogUnreadMark : Update
	{
		[Flags] public enum Flags { unread = 0x1 }
		public Flags flags;
		public DialogPeerBase peer;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateMessagePoll"/></summary>
	[TLDef(0xACA1657B)]
	public partial class UpdateMessagePoll : Update
	{
		[Flags] public enum Flags { has_poll = 0x1 }
		public Flags flags;
		public long poll_id;
		[IfFlag(0)] public Poll poll;
		public PollResults results;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateChatDefaultBannedRights"/></summary>
	[TLDef(0x54C01850)]
	public partial class UpdateChatDefaultBannedRights : Update
	{
		public Peer peer;
		public ChatBannedRights default_banned_rights;
		public int version;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateFolderPeers"/></summary>
	[TLDef(0x19360DC0)]
	public partial class UpdateFolderPeers : Update
	{
		public FolderPeer[] folder_peers;
		public int pts;
		public int pts_count;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updatePeerSettings"/></summary>
	[TLDef(0x6A7E7366)]
	public partial class UpdatePeerSettings : Update
	{
		public Peer peer;
		public PeerSettings settings;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updatePeerLocated"/></summary>
	[TLDef(0xB4AFCFB0)]
	public partial class UpdatePeerLocated : Update { public PeerLocatedBase[] peers; }
	///<summary>See <a href="https://core.telegram.org/constructor/updateNewScheduledMessage"/></summary>
	[TLDef(0x39A51DFB)]
	public partial class UpdateNewScheduledMessage : Update { public MessageBase message; }
	///<summary>See <a href="https://core.telegram.org/constructor/updateDeleteScheduledMessages"/></summary>
	[TLDef(0x90866CEE)]
	public partial class UpdateDeleteScheduledMessages : Update
	{
		public Peer peer;
		public int[] messages;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateTheme"/></summary>
	[TLDef(0x8216FBA3)]
	public partial class UpdateTheme : Update { public Theme theme; }
	///<summary>See <a href="https://core.telegram.org/constructor/updateGeoLiveViewed"/></summary>
	[TLDef(0x871FB939)]
	public partial class UpdateGeoLiveViewed : Update
	{
		public Peer peer;
		public int msg_id;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateLoginToken"/></summary>
	[TLDef(0x564FE691)]
	public partial class UpdateLoginToken : Update { }
	///<summary>See <a href="https://core.telegram.org/constructor/updateMessagePollVote"/></summary>
	[TLDef(0x106395C9)]
	public partial class UpdateMessagePollVote : Update
	{
		public long poll_id;
		public long user_id;
		public byte[][] options;
		public int qts;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateDialogFilter"/></summary>
	[TLDef(0x26FFDE7D)]
	public partial class UpdateDialogFilter : Update
	{
		[Flags] public enum Flags { has_filter = 0x1 }
		public Flags flags;
		public int id;
		[IfFlag(0)] public DialogFilter filter;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateDialogFilterOrder"/></summary>
	[TLDef(0xA5D72105)]
	public partial class UpdateDialogFilterOrder : Update { public int[] order; }
	///<summary>See <a href="https://core.telegram.org/constructor/updateDialogFilters"/></summary>
	[TLDef(0x3504914F)]
	public partial class UpdateDialogFilters : Update { }
	///<summary>See <a href="https://core.telegram.org/constructor/updatePhoneCallSignalingData"/></summary>
	[TLDef(0x2661BF09)]
	public partial class UpdatePhoneCallSignalingData : Update
	{
		public long phone_call_id;
		public byte[] data;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateChannelMessageForwards"/></summary>
	[TLDef(0xD29A27F4)]
	public partial class UpdateChannelMessageForwards : Update
	{
		public long channel_id;
		public int id;
		public int forwards;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateReadChannelDiscussionInbox"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/updateReadChannelDiscussionOutbox"/></summary>
	[TLDef(0x695C9E7C)]
	public partial class UpdateReadChannelDiscussionOutbox : Update
	{
		public long channel_id;
		public int top_msg_id;
		public int read_max_id;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updatePeerBlocked"/></summary>
	[TLDef(0x246A4B22)]
	public partial class UpdatePeerBlocked : Update
	{
		public Peer peer_id;
		public bool blocked;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateChannelUserTyping"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/updatePinnedMessages"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/updatePinnedChannelMessages"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/updateChat"/></summary>
	[TLDef(0xF89A6A4E)]
	public partial class UpdateChat : Update { public long chat_id; }
	///<summary>See <a href="https://core.telegram.org/constructor/updateGroupCallParticipants"/></summary>
	[TLDef(0xF2EBDB4E)]
	public partial class UpdateGroupCallParticipants : Update
	{
		public InputGroupCall call;
		public GroupCallParticipant[] participants;
		public int version;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateGroupCall"/></summary>
	[TLDef(0x14B24500)]
	public partial class UpdateGroupCall : Update
	{
		public long chat_id;
		public GroupCallBase call;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updatePeerHistoryTTL"/></summary>
	[TLDef(0xBB9BB9A5)]
	public partial class UpdatePeerHistoryTTL : Update
	{
		[Flags] public enum Flags { has_ttl_period = 0x1 }
		public Flags flags;
		public Peer peer;
		[IfFlag(0)] public int ttl_period;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateChatParticipant"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/updateChannelParticipant"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/updateBotStopped"/></summary>
	[TLDef(0xC4870A49)]
	public partial class UpdateBotStopped : Update
	{
		public long user_id;
		public DateTime date;
		public bool stopped;
		public int qts;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateGroupCallConnection"/></summary>
	[TLDef(0x0B783982)]
	public partial class UpdateGroupCallConnection : Update
	{
		[Flags] public enum Flags { presentation = 0x1 }
		public Flags flags;
		public DataJSON params_;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateBotCommands"/></summary>
	[TLDef(0x4D712F2E)]
	public partial class UpdateBotCommands : Update
	{
		public Peer peer;
		public long bot_id;
		public BotCommand[] commands;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/updates.state"/></summary>
	[TLDef(0xA56C2A3E)]
	public partial class Updates_State : ITLObject
	{
		public int pts;
		public int qts;
		public DateTime date;
		public int seq;
		public int unread_count;
	}

	///<summary>See <a href="https://core.telegram.org/type/updates.Difference"/></summary>
	public abstract partial class Updates_DifferenceBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/updates.differenceEmpty"/></summary>
	[TLDef(0x5D75A138)]
	public partial class Updates_DifferenceEmpty : Updates_DifferenceBase
	{
		public DateTime date;
		public int seq;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updates.difference"/></summary>
	[TLDef(0x00F49CA0)]
	public partial class Updates_Difference : Updates_DifferenceBase
	{
		public MessageBase[] new_messages;
		public EncryptedMessageBase[] new_encrypted_messages;
		public Update[] other_updates;
		public ChatBase[] chats;
		public UserBase[] users;
		public Updates_State state;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updates.differenceSlice"/></summary>
	[TLDef(0xA8FB1981)]
	public partial class Updates_DifferenceSlice : Updates_DifferenceBase
	{
		public MessageBase[] new_messages;
		public EncryptedMessageBase[] new_encrypted_messages;
		public Update[] other_updates;
		public ChatBase[] chats;
		public UserBase[] users;
		public Updates_State intermediate_state;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updates.differenceTooLong"/></summary>
	[TLDef(0x4AFE8F6D)]
	public partial class Updates_DifferenceTooLong : Updates_DifferenceBase { public int pts; }

	///<summary>See <a href="https://core.telegram.org/type/Updates"/></summary>
	public abstract partial class UpdatesBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/updatesTooLong"/></summary>
	[TLDef(0xE317AF7E)]
	public partial class UpdatesTooLong : UpdatesBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/updateShortMessage"/></summary>
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
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateShortChatMessage"/></summary>
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
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateShort"/></summary>
	[TLDef(0x78D4DEC1)]
	public partial class UpdateShort : UpdatesBase
	{
		public Update update;
		public DateTime date;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updatesCombined"/></summary>
	[TLDef(0x725B04C3)]
	public partial class UpdatesCombined : UpdatesBase
	{
		public Update[] updates;
		public UserBase[] users;
		public ChatBase[] chats;
		public DateTime date;
		public int seq_start;
		public int seq;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updates"/></summary>
	[TLDef(0x74AE4240)]
	public partial class Updates : UpdatesBase
	{
		public Update[] updates;
		public UserBase[] users;
		public ChatBase[] chats;
		public DateTime date;
		public int seq;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updateShortSentMessage"/></summary>
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
	}

	///<summary>See <a href="https://core.telegram.org/type/photos.Photos"/></summary>
	public abstract partial class Photos_PhotosBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/photos.photos"/></summary>
	[TLDef(0x8DCA6AA5)]
	public partial class Photos_Photos : Photos_PhotosBase
	{
		public PhotoBase[] photos;
		public UserBase[] users;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/photos.photosSlice"/></summary>
	[TLDef(0x15051F54)]
	public partial class Photos_PhotosSlice : Photos_PhotosBase
	{
		public int count;
		public PhotoBase[] photos;
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/photos.photo"/></summary>
	[TLDef(0x20212CA8)]
	public partial class Photos_Photo : ITLObject
	{
		public PhotoBase photo;
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/type/upload.File"/></summary>
	public abstract partial class Upload_FileBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/upload.file"/></summary>
	[TLDef(0x096A18D5)]
	public partial class Upload_File : Upload_FileBase
	{
		public Storage_FileType type;
		public int mtime;
		public byte[] bytes;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/upload.fileCdnRedirect"/></summary>
	[TLDef(0xF18CDA44)]
	public partial class Upload_FileCdnRedirect : Upload_FileBase
	{
		public int dc_id;
		public byte[] file_token;
		public byte[] encryption_key;
		public byte[] encryption_iv;
		public FileHash[] file_hashes;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/dcOption"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/config"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/nearestDc"/></summary>
	[TLDef(0x8E1A1775)]
	public partial class NearestDc : ITLObject
	{
		public string country;
		public int this_dc;
		public int nearest_dc;
	}

	///<summary>See <a href="https://core.telegram.org/type/help.AppUpdate"/></summary>
	public abstract partial class Help_AppUpdateBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/help.appUpdate"/></summary>
	[TLDef(0xCCBBCE30)]
	public partial class Help_AppUpdate : Help_AppUpdateBase
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
	///<summary>See <a href="https://core.telegram.org/constructor/help.noAppUpdate"/></summary>
	[TLDef(0xC45A6536)]
	public partial class Help_NoAppUpdate : Help_AppUpdateBase { }

	///<summary>See <a href="https://core.telegram.org/constructor/help.inviteText"/></summary>
	[TLDef(0x18CB9F78)]
	public partial class Help_InviteText : ITLObject { public string message; }

	///<summary>See <a href="https://core.telegram.org/type/EncryptedChat"/></summary>
	public abstract partial class EncryptedChatBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/encryptedChatEmpty"/></summary>
	[TLDef(0xAB7EC0A0)]
	public partial class EncryptedChatEmpty : EncryptedChatBase { public int id; }
	///<summary>See <a href="https://core.telegram.org/constructor/encryptedChatWaiting"/></summary>
	[TLDef(0x66B25953)]
	public partial class EncryptedChatWaiting : EncryptedChatBase
	{
		public int id;
		public long access_hash;
		public DateTime date;
		public long admin_id;
		public long participant_id;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/encryptedChatRequested"/></summary>
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
	}
	///<summary>See <a href="https://core.telegram.org/constructor/encryptedChat"/></summary>
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
	}
	///<summary>See <a href="https://core.telegram.org/constructor/encryptedChatDiscarded"/></summary>
	[TLDef(0x1E1C7C45)]
	public partial class EncryptedChatDiscarded : EncryptedChatBase
	{
		[Flags] public enum Flags { history_deleted = 0x1 }
		public Flags flags;
		public int id;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/inputEncryptedChat"/></summary>
	[TLDef(0xF141B5E1)]
	public partial class InputEncryptedChat : ITLObject
	{
		public int chat_id;
		public long access_hash;
	}

	///<summary>See <a href="https://core.telegram.org/type/EncryptedFile"/></summary>
	public abstract partial class EncryptedFileBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/encryptedFileEmpty"/></summary>
	[TLDef(0xC21F497E)]
	public partial class EncryptedFileEmpty : EncryptedFileBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/encryptedFile"/></summary>
	[TLDef(0x4A70994C)]
	public partial class EncryptedFile : EncryptedFileBase
	{
		public long id;
		public long access_hash;
		public int size;
		public int dc_id;
		public int key_fingerprint;
	}

	///<summary>See <a href="https://core.telegram.org/type/InputEncryptedFile"/></summary>
	public abstract partial class InputEncryptedFileBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputEncryptedFileEmpty"/></summary>
	[TLDef(0x1837C364)]
	public partial class InputEncryptedFileEmpty : InputEncryptedFileBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputEncryptedFileUploaded"/></summary>
	[TLDef(0x64BD0306)]
	public partial class InputEncryptedFileUploaded : InputEncryptedFileBase
	{
		public long id;
		public int parts;
		public byte[] md5_checksum;
		public int key_fingerprint;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputEncryptedFile"/></summary>
	[TLDef(0x5A17B5E5)]
	public partial class InputEncryptedFile : InputEncryptedFileBase
	{
		public long id;
		public long access_hash;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputEncryptedFileBigUploaded"/></summary>
	[TLDef(0x2DC173C8)]
	public partial class InputEncryptedFileBigUploaded : InputEncryptedFileBase
	{
		public long id;
		public int parts;
		public int key_fingerprint;
	}

	///<summary>See <a href="https://core.telegram.org/type/EncryptedMessage"/></summary>
	public abstract partial class EncryptedMessageBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/encryptedMessage"/></summary>
	[TLDef(0xED18C118)]
	public partial class EncryptedMessage : EncryptedMessageBase
	{
		public long random_id;
		public int chat_id;
		public DateTime date;
		public byte[] bytes;
		public EncryptedFileBase file;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/encryptedMessageService"/></summary>
	[TLDef(0x23734B06)]
	public partial class EncryptedMessageService : EncryptedMessageBase
	{
		public long random_id;
		public int chat_id;
		public DateTime date;
		public byte[] bytes;
	}

	///<summary>See <a href="https://core.telegram.org/type/messages.DhConfig"/></summary>
	public abstract partial class Messages_DhConfigBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/messages.dhConfigNotModified"/></summary>
	[TLDef(0xC0E24635)]
	public partial class Messages_DhConfigNotModified : Messages_DhConfigBase { public byte[] random; }
	///<summary>See <a href="https://core.telegram.org/constructor/messages.dhConfig"/></summary>
	[TLDef(0x2C221EDD)]
	public partial class Messages_DhConfig : Messages_DhConfigBase
	{
		public int g;
		public byte[] p;
		public int version;
		public byte[] random;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/messages.sentEncryptedMessage"/></summary>
	[TLDef(0x560F8935)]
	public partial class Messages_SentEncryptedMessage : ITLObject { public DateTime date; }
	///<summary>See <a href="https://core.telegram.org/constructor/messages.sentEncryptedFile"/></summary>
	[TLDef(0x9493FF32)]
	public partial class Messages_SentEncryptedFile : Messages_SentEncryptedMessage { public EncryptedFileBase file; }

	///<summary>See <a href="https://core.telegram.org/type/InputDocument"/></summary>
	public abstract partial class InputDocumentBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputDocumentEmpty"/></summary>
	[TLDef(0x72F0EAAE)]
	public partial class InputDocumentEmpty : InputDocumentBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputDocument"/></summary>
	[TLDef(0x1ABFB575)]
	public partial class InputDocument : InputDocumentBase
	{
		public long id;
		public long access_hash;
		public byte[] file_reference;
	}

	///<summary>See <a href="https://core.telegram.org/type/Document"/></summary>
	public abstract partial class DocumentBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/documentEmpty"/></summary>
	[TLDef(0x36F8C871)]
	public partial class DocumentEmpty : DocumentBase { public long id; }
	///<summary>See <a href="https://core.telegram.org/constructor/document"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/help.support"/></summary>
	[TLDef(0x17C6B5F6)]
	public partial class Help_Support : ITLObject
	{
		public string phone_number;
		public UserBase user;
	}

	///<summary>See <a href="https://core.telegram.org/type/NotifyPeer"/></summary>
	public abstract partial class NotifyPeerBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/notifyPeer"/></summary>
	[TLDef(0x9FD40BD8)]
	public partial class NotifyPeer : NotifyPeerBase { public Peer peer; }
	///<summary>See <a href="https://core.telegram.org/constructor/notifyUsers"/></summary>
	[TLDef(0xB4C83B4C)]
	public partial class NotifyUsers : NotifyPeerBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/notifyChats"/></summary>
	[TLDef(0xC007CEC3)]
	public partial class NotifyChats : NotifyPeerBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/notifyBroadcasts"/></summary>
	[TLDef(0xD612E8EF)]
	public partial class NotifyBroadcasts : NotifyPeerBase { }

	///<summary>See <a href="https://core.telegram.org/type/SendMessageAction"/></summary>
	public abstract partial class SendMessageAction : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/sendMessageTypingAction"/></summary>
	[TLDef(0x16BF744E)]
	public partial class SendMessageTypingAction : SendMessageAction { }
	///<summary>See <a href="https://core.telegram.org/constructor/sendMessageCancelAction"/></summary>
	[TLDef(0xFD5EC8F5)]
	public partial class SendMessageCancelAction : SendMessageAction { }
	///<summary>See <a href="https://core.telegram.org/constructor/sendMessageRecordVideoAction"/></summary>
	[TLDef(0xA187D66F)]
	public partial class SendMessageRecordVideoAction : SendMessageAction { }
	///<summary>See <a href="https://core.telegram.org/constructor/sendMessageUploadVideoAction"/></summary>
	[TLDef(0xE9763AEC)]
	public partial class SendMessageUploadVideoAction : SendMessageAction { public int progress; }
	///<summary>See <a href="https://core.telegram.org/constructor/sendMessageRecordAudioAction"/></summary>
	[TLDef(0xD52F73F7)]
	public partial class SendMessageRecordAudioAction : SendMessageAction { }
	///<summary>See <a href="https://core.telegram.org/constructor/sendMessageUploadAudioAction"/></summary>
	[TLDef(0xF351D7AB)]
	public partial class SendMessageUploadAudioAction : SendMessageAction { public int progress; }
	///<summary>See <a href="https://core.telegram.org/constructor/sendMessageUploadPhotoAction"/></summary>
	[TLDef(0xD1D34A26)]
	public partial class SendMessageUploadPhotoAction : SendMessageAction { public int progress; }
	///<summary>See <a href="https://core.telegram.org/constructor/sendMessageUploadDocumentAction"/></summary>
	[TLDef(0xAA0CD9E4)]
	public partial class SendMessageUploadDocumentAction : SendMessageAction { public int progress; }
	///<summary>See <a href="https://core.telegram.org/constructor/sendMessageGeoLocationAction"/></summary>
	[TLDef(0x176F8BA1)]
	public partial class SendMessageGeoLocationAction : SendMessageAction { }
	///<summary>See <a href="https://core.telegram.org/constructor/sendMessageChooseContactAction"/></summary>
	[TLDef(0x628CBC6F)]
	public partial class SendMessageChooseContactAction : SendMessageAction { }
	///<summary>See <a href="https://core.telegram.org/constructor/sendMessageGamePlayAction"/></summary>
	[TLDef(0xDD6A8F48)]
	public partial class SendMessageGamePlayAction : SendMessageAction { }
	///<summary>See <a href="https://core.telegram.org/constructor/sendMessageRecordRoundAction"/></summary>
	[TLDef(0x88F27FBC)]
	public partial class SendMessageRecordRoundAction : SendMessageAction { }
	///<summary>See <a href="https://core.telegram.org/constructor/sendMessageUploadRoundAction"/></summary>
	[TLDef(0x243E1C66)]
	public partial class SendMessageUploadRoundAction : SendMessageAction { public int progress; }
	///<summary>See <a href="https://core.telegram.org/constructor/speakingInGroupCallAction"/></summary>
	[TLDef(0xD92C2285)]
	public partial class SpeakingInGroupCallAction : SendMessageAction { }
	///<summary>See <a href="https://core.telegram.org/constructor/sendMessageHistoryImportAction"/></summary>
	[TLDef(0xDBDA9246)]
	public partial class SendMessageHistoryImportAction : SendMessageAction { public int progress; }
	///<summary>See <a href="https://core.telegram.org/constructor/sendMessageChooseStickerAction"/></summary>
	[TLDef(0xB05AC6B1)]
	public partial class SendMessageChooseStickerAction : SendMessageAction { }
	///<summary>See <a href="https://core.telegram.org/constructor/sendMessageEmojiInteraction"/></summary>
	[TLDef(0x6A3233B6)]
	public partial class SendMessageEmojiInteraction : SendMessageAction
	{
		public string emoticon;
		public DataJSON interaction;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/sendMessageEmojiInteractionSeen"/></summary>
	[TLDef(0xB665902E)]
	public partial class SendMessageEmojiInteractionSeen : SendMessageAction { public string emoticon; }

	///<summary>See <a href="https://core.telegram.org/constructor/contacts.found"/></summary>
	[TLDef(0xB3134D9D)]
	public partial class Contacts_Found : ITLObject
	{
		public Peer[] my_results;
		public Peer[] results;
		public ChatBase[] chats;
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/type/InputPrivacyKey"/></summary>
	public abstract partial class InputPrivacyKey : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPrivacyKeyStatusTimestamp"/></summary>
	[TLDef(0x4F96CB18)]
	public partial class InputPrivacyKeyStatusTimestamp : InputPrivacyKey { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPrivacyKeyChatInvite"/></summary>
	[TLDef(0xBDFB0426)]
	public partial class InputPrivacyKeyChatInvite : InputPrivacyKey { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPrivacyKeyPhoneCall"/></summary>
	[TLDef(0xFABADC5F)]
	public partial class InputPrivacyKeyPhoneCall : InputPrivacyKey { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPrivacyKeyPhoneP2P"/></summary>
	[TLDef(0xDB9E70D2)]
	public partial class InputPrivacyKeyPhoneP2P : InputPrivacyKey { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPrivacyKeyForwards"/></summary>
	[TLDef(0xA4DD4C08)]
	public partial class InputPrivacyKeyForwards : InputPrivacyKey { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPrivacyKeyProfilePhoto"/></summary>
	[TLDef(0x5719BACC)]
	public partial class InputPrivacyKeyProfilePhoto : InputPrivacyKey { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPrivacyKeyPhoneNumber"/></summary>
	[TLDef(0x0352DAFA)]
	public partial class InputPrivacyKeyPhoneNumber : InputPrivacyKey { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPrivacyKeyAddedByPhone"/></summary>
	[TLDef(0xD1219BDD)]
	public partial class InputPrivacyKeyAddedByPhone : InputPrivacyKey { }

	///<summary>See <a href="https://core.telegram.org/type/PrivacyKey"/></summary>
	public abstract partial class PrivacyKey : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/privacyKeyStatusTimestamp"/></summary>
	[TLDef(0xBC2EAB30)]
	public partial class PrivacyKeyStatusTimestamp : PrivacyKey { }
	///<summary>See <a href="https://core.telegram.org/constructor/privacyKeyChatInvite"/></summary>
	[TLDef(0x500E6DFA)]
	public partial class PrivacyKeyChatInvite : PrivacyKey { }
	///<summary>See <a href="https://core.telegram.org/constructor/privacyKeyPhoneCall"/></summary>
	[TLDef(0x3D662B7B)]
	public partial class PrivacyKeyPhoneCall : PrivacyKey { }
	///<summary>See <a href="https://core.telegram.org/constructor/privacyKeyPhoneP2P"/></summary>
	[TLDef(0x39491CC8)]
	public partial class PrivacyKeyPhoneP2P : PrivacyKey { }
	///<summary>See <a href="https://core.telegram.org/constructor/privacyKeyForwards"/></summary>
	[TLDef(0x69EC56A3)]
	public partial class PrivacyKeyForwards : PrivacyKey { }
	///<summary>See <a href="https://core.telegram.org/constructor/privacyKeyProfilePhoto"/></summary>
	[TLDef(0x96151FED)]
	public partial class PrivacyKeyProfilePhoto : PrivacyKey { }
	///<summary>See <a href="https://core.telegram.org/constructor/privacyKeyPhoneNumber"/></summary>
	[TLDef(0xD19AE46D)]
	public partial class PrivacyKeyPhoneNumber : PrivacyKey { }
	///<summary>See <a href="https://core.telegram.org/constructor/privacyKeyAddedByPhone"/></summary>
	[TLDef(0x42FFD42B)]
	public partial class PrivacyKeyAddedByPhone : PrivacyKey { }

	///<summary>See <a href="https://core.telegram.org/type/InputPrivacyRule"/></summary>
	public abstract partial class InputPrivacyRule : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPrivacyValueAllowContacts"/></summary>
	[TLDef(0x0D09E07B)]
	public partial class InputPrivacyValueAllowContacts : InputPrivacyRule { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPrivacyValueAllowAll"/></summary>
	[TLDef(0x184B35CE)]
	public partial class InputPrivacyValueAllowAll : InputPrivacyRule { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPrivacyValueAllowUsers"/></summary>
	[TLDef(0x131CC67F)]
	public partial class InputPrivacyValueAllowUsers : InputPrivacyRule { public InputUserBase[] users; }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPrivacyValueDisallowContacts"/></summary>
	[TLDef(0x0BA52007)]
	public partial class InputPrivacyValueDisallowContacts : InputPrivacyRule { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPrivacyValueDisallowAll"/></summary>
	[TLDef(0xD66B66C9)]
	public partial class InputPrivacyValueDisallowAll : InputPrivacyRule { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPrivacyValueDisallowUsers"/></summary>
	[TLDef(0x90110467)]
	public partial class InputPrivacyValueDisallowUsers : InputPrivacyRule { public InputUserBase[] users; }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPrivacyValueAllowChatParticipants"/></summary>
	[TLDef(0x840649CF)]
	public partial class InputPrivacyValueAllowChatParticipants : InputPrivacyRule { public long[] chats; }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPrivacyValueDisallowChatParticipants"/></summary>
	[TLDef(0xE94F0F86)]
	public partial class InputPrivacyValueDisallowChatParticipants : InputPrivacyRule { public long[] chats; }

	///<summary>See <a href="https://core.telegram.org/type/PrivacyRule"/></summary>
	public abstract partial class PrivacyRule : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/privacyValueAllowContacts"/></summary>
	[TLDef(0xFFFE1BAC)]
	public partial class PrivacyValueAllowContacts : PrivacyRule { }
	///<summary>See <a href="https://core.telegram.org/constructor/privacyValueAllowAll"/></summary>
	[TLDef(0x65427B82)]
	public partial class PrivacyValueAllowAll : PrivacyRule { }
	///<summary>See <a href="https://core.telegram.org/constructor/privacyValueAllowUsers"/></summary>
	[TLDef(0xB8905FB2)]
	public partial class PrivacyValueAllowUsers : PrivacyRule { public long[] users; }
	///<summary>See <a href="https://core.telegram.org/constructor/privacyValueDisallowContacts"/></summary>
	[TLDef(0xF888FA1A)]
	public partial class PrivacyValueDisallowContacts : PrivacyRule { }
	///<summary>See <a href="https://core.telegram.org/constructor/privacyValueDisallowAll"/></summary>
	[TLDef(0x8B73E763)]
	public partial class PrivacyValueDisallowAll : PrivacyRule { }
	///<summary>See <a href="https://core.telegram.org/constructor/privacyValueDisallowUsers"/></summary>
	[TLDef(0xE4621141)]
	public partial class PrivacyValueDisallowUsers : PrivacyRule { public long[] users; }
	///<summary>See <a href="https://core.telegram.org/constructor/privacyValueAllowChatParticipants"/></summary>
	[TLDef(0x6B134E8E)]
	public partial class PrivacyValueAllowChatParticipants : PrivacyRule { public long[] chats; }
	///<summary>See <a href="https://core.telegram.org/constructor/privacyValueDisallowChatParticipants"/></summary>
	[TLDef(0x41C87565)]
	public partial class PrivacyValueDisallowChatParticipants : PrivacyRule { public long[] chats; }

	///<summary>See <a href="https://core.telegram.org/constructor/account.privacyRules"/></summary>
	[TLDef(0x50A04E45)]
	public partial class Account_PrivacyRules : ITLObject
	{
		public PrivacyRule[] rules;
		public ChatBase[] chats;
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/accountDaysTTL"/></summary>
	[TLDef(0xB8D0AFDF)]
	public partial class AccountDaysTTL : ITLObject { public int days; }

	///<summary>See <a href="https://core.telegram.org/type/DocumentAttribute"/></summary>
	public abstract partial class DocumentAttribute : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/documentAttributeImageSize"/></summary>
	[TLDef(0x6C37C15C)]
	public partial class DocumentAttributeImageSize : DocumentAttribute
	{
		public int w;
		public int h;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/documentAttributeAnimated"/></summary>
	[TLDef(0x11B58939)]
	public partial class DocumentAttributeAnimated : DocumentAttribute { }
	///<summary>See <a href="https://core.telegram.org/constructor/documentAttributeSticker"/></summary>
	[TLDef(0x6319D612)]
	public partial class DocumentAttributeSticker : DocumentAttribute
	{
		[Flags] public enum Flags { has_mask_coords = 0x1, mask = 0x2 }
		public Flags flags;
		public string alt;
		public InputStickerSet stickerset;
		[IfFlag(0)] public MaskCoords mask_coords;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/documentAttributeVideo"/></summary>
	[TLDef(0x0EF02CE6)]
	public partial class DocumentAttributeVideo : DocumentAttribute
	{
		[Flags] public enum Flags { round_message = 0x1, supports_streaming = 0x2 }
		public Flags flags;
		public int duration;
		public int w;
		public int h;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/documentAttributeAudio"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/documentAttributeFilename"/></summary>
	[TLDef(0x15590068)]
	public partial class DocumentAttributeFilename : DocumentAttribute { public string file_name; }
	///<summary>See <a href="https://core.telegram.org/constructor/documentAttributeHasStickers"/></summary>
	[TLDef(0x9801D2F7)]
	public partial class DocumentAttributeHasStickers : DocumentAttribute { }

	///<summary>See <a href="https://core.telegram.org/type/messages.Stickers"/></summary>
	public abstract partial class Messages_StickersBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/messages.stickersNotModified"/></summary>
	[TLDef(0xF1749A22)]
	public partial class Messages_StickersNotModified : Messages_StickersBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/messages.stickers"/></summary>
	[TLDef(0x30A6EC7E)]
	public partial class Messages_Stickers : Messages_StickersBase
	{
		public long hash;
		public DocumentBase[] stickers;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/stickerPack"/></summary>
	[TLDef(0x12B299D4)]
	public partial class StickerPack : ITLObject
	{
		public string emoticon;
		public long[] documents;
	}

	///<summary>See <a href="https://core.telegram.org/type/messages.AllStickers"/></summary>
	public abstract partial class Messages_AllStickersBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/messages.allStickersNotModified"/></summary>
	[TLDef(0xE86602C3)]
	public partial class Messages_AllStickersNotModified : Messages_AllStickersBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/messages.allStickers"/></summary>
	[TLDef(0xCDBBCEBB)]
	public partial class Messages_AllStickers : Messages_AllStickersBase
	{
		public long hash;
		public StickerSet[] sets;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/messages.affectedMessages"/></summary>
	[TLDef(0x84D19185)]
	public partial class Messages_AffectedMessages : ITLObject
	{
		public int pts;
		public int pts_count;
	}

	///<summary>See <a href="https://core.telegram.org/type/WebPage"/></summary>
	public abstract partial class WebPageBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/webPageEmpty"/></summary>
	[TLDef(0xEB1477E8)]
	public partial class WebPageEmpty : WebPageBase { public long id; }
	///<summary>See <a href="https://core.telegram.org/constructor/webPagePending"/></summary>
	[TLDef(0xC586DA1C)]
	public partial class WebPagePending : WebPageBase
	{
		public long id;
		public DateTime date;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/webPage"/></summary>
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
	}
	///<summary>See <a href="https://core.telegram.org/constructor/webPageNotModified"/></summary>
	[TLDef(0x7311CA11)]
	public partial class WebPageNotModified : WebPageBase
	{
		[Flags] public enum Flags { has_cached_page_views = 0x1 }
		public Flags flags;
		[IfFlag(0)] public int cached_page_views;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/authorization"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/account.authorizations"/></summary>
	[TLDef(0x1250ABDE)]
	public partial class Account_Authorizations : ITLObject { public Authorization[] authorizations; }

	///<summary>See <a href="https://core.telegram.org/constructor/account.password"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/account.passwordSettings"/></summary>
	[TLDef(0x9A5C33E5)]
	public partial class Account_PasswordSettings : ITLObject
	{
		[Flags] public enum Flags { has_email = 0x1, has_secure_settings = 0x2 }
		public Flags flags;
		[IfFlag(0)] public string email;
		[IfFlag(1)] public SecureSecretSettings secure_settings;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/account.passwordInputSettings"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/auth.passwordRecovery"/></summary>
	[TLDef(0x137948A5)]
	public partial class Auth_PasswordRecovery : ITLObject { public string email_pattern; }

	///<summary>See <a href="https://core.telegram.org/constructor/receivedNotifyMessage"/></summary>
	[TLDef(0xA384B779)]
	public partial class ReceivedNotifyMessage : ITLObject
	{
		public int id;
		public int flags;
	}

	///<summary>See <a href="https://core.telegram.org/type/ExportedChatInvite"/></summary>
	public abstract partial class ExportedChatInvite : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/chatInviteExported"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/type/ChatInvite"/></summary>
	public abstract partial class ChatInviteBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/chatInviteAlready"/></summary>
	[TLDef(0x5A686D7C)]
	public partial class ChatInviteAlready : ChatInviteBase { public ChatBase chat; }
	///<summary>See <a href="https://core.telegram.org/constructor/chatInvite"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/chatInvitePeek"/></summary>
	[TLDef(0x61695CB0)]
	public partial class ChatInvitePeek : ChatInviteBase
	{
		public ChatBase chat;
		public DateTime expires;
	}

	///<summary>See <a href="https://core.telegram.org/type/InputStickerSet"/></summary>
	public abstract partial class InputStickerSet : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputStickerSetEmpty"/></summary>
	[TLDef(0xFFB62B95)]
	public partial class InputStickerSetEmpty : InputStickerSet { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputStickerSetID"/></summary>
	[TLDef(0x9DE7A269)]
	public partial class InputStickerSetID : InputStickerSet
	{
		public long id;
		public long access_hash;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputStickerSetShortName"/></summary>
	[TLDef(0x861CC8A0)]
	public partial class InputStickerSetShortName : InputStickerSet { public string short_name; }
	///<summary>See <a href="https://core.telegram.org/constructor/inputStickerSetAnimatedEmoji"/></summary>
	[TLDef(0x028703C8)]
	public partial class InputStickerSetAnimatedEmoji : InputStickerSet { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputStickerSetDice"/></summary>
	[TLDef(0xE67F520E)]
	public partial class InputStickerSetDice : InputStickerSet { public string emoticon; }

	///<summary>See <a href="https://core.telegram.org/constructor/stickerSet"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/messages.stickerSet"/></summary>
	[TLDef(0xB60A24A6)]
	public partial class Messages_StickerSet : ITLObject
	{
		public StickerSet set;
		public StickerPack[] packs;
		public DocumentBase[] documents;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/botCommand"/></summary>
	[TLDef(0xC27AC8C7)]
	public partial class BotCommand : ITLObject
	{
		public string command;
		public string description;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/botInfo"/></summary>
	[TLDef(0x1B74B335)]
	public partial class BotInfo : ITLObject
	{
		public long user_id;
		public string description;
		public BotCommand[] commands;
	}

	///<summary>See <a href="https://core.telegram.org/type/KeyboardButton"/></summary>
	public abstract partial class KeyboardButtonBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/keyboardButton"/></summary>
	[TLDef(0xA2FA4880)]
	public partial class KeyboardButton : KeyboardButtonBase { public string text; }
	///<summary>See <a href="https://core.telegram.org/constructor/keyboardButtonUrl"/></summary>
	[TLDef(0x258AFF05)]
	public partial class KeyboardButtonUrl : KeyboardButtonBase
	{
		public string text;
		public string url;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/keyboardButtonCallback"/></summary>
	[TLDef(0x35BBDB6B)]
	public partial class KeyboardButtonCallback : KeyboardButtonBase
	{
		[Flags] public enum Flags { requires_password = 0x1 }
		public Flags flags;
		public string text;
		public byte[] data;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/keyboardButtonRequestPhone"/></summary>
	[TLDef(0xB16A6C29)]
	public partial class KeyboardButtonRequestPhone : KeyboardButtonBase { public string text; }
	///<summary>See <a href="https://core.telegram.org/constructor/keyboardButtonRequestGeoLocation"/></summary>
	[TLDef(0xFC796B3F)]
	public partial class KeyboardButtonRequestGeoLocation : KeyboardButtonBase { public string text; }
	///<summary>See <a href="https://core.telegram.org/constructor/keyboardButtonSwitchInline"/></summary>
	[TLDef(0x0568A748)]
	public partial class KeyboardButtonSwitchInline : KeyboardButtonBase
	{
		[Flags] public enum Flags { same_peer = 0x1 }
		public Flags flags;
		public string text;
		public string query;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/keyboardButtonGame"/></summary>
	[TLDef(0x50F41CCF)]
	public partial class KeyboardButtonGame : KeyboardButtonBase { public string text; }
	///<summary>See <a href="https://core.telegram.org/constructor/keyboardButtonBuy"/></summary>
	[TLDef(0xAFD93FBB)]
	public partial class KeyboardButtonBuy : KeyboardButtonBase { public string text; }
	///<summary>See <a href="https://core.telegram.org/constructor/keyboardButtonUrlAuth"/></summary>
	[TLDef(0x10B78D29)]
	public partial class KeyboardButtonUrlAuth : KeyboardButtonBase
	{
		[Flags] public enum Flags { has_fwd_text = 0x1 }
		public Flags flags;
		public string text;
		[IfFlag(0)] public string fwd_text;
		public string url;
		public int button_id;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputKeyboardButtonUrlAuth"/></summary>
	[TLDef(0xD02E7FD4)]
	public partial class InputKeyboardButtonUrlAuth : KeyboardButtonBase
	{
		[Flags] public enum Flags { request_write_access = 0x1, has_fwd_text = 0x2 }
		public Flags flags;
		public string text;
		[IfFlag(1)] public string fwd_text;
		public string url;
		public InputUserBase bot;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/keyboardButtonRequestPoll"/></summary>
	[TLDef(0xBBC7515D)]
	public partial class KeyboardButtonRequestPoll : KeyboardButtonBase
	{
		[Flags] public enum Flags { has_quiz = 0x1 }
		public Flags flags;
		[IfFlag(0)] public bool quiz;
		public string text;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/keyboardButtonRow"/></summary>
	[TLDef(0x77608B83)]
	public partial class KeyboardButtonRow : ITLObject { public KeyboardButtonBase[] buttons; }

	///<summary>See <a href="https://core.telegram.org/type/ReplyMarkup"/></summary>
	public abstract partial class ReplyMarkup : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/replyKeyboardHide"/></summary>
	[TLDef(0xA03E5B85)]
	public partial class ReplyKeyboardHide : ReplyMarkup
	{
		[Flags] public enum Flags { selective = 0x4 }
		public Flags flags;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/replyKeyboardForceReply"/></summary>
	[TLDef(0x86B40B08)]
	public partial class ReplyKeyboardForceReply : ReplyMarkup
	{
		[Flags] public enum Flags { single_use = 0x2, selective = 0x4, has_placeholder = 0x8 }
		public Flags flags;
		[IfFlag(3)] public string placeholder;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/replyKeyboardMarkup"/></summary>
	[TLDef(0x85DD99D1)]
	public partial class ReplyKeyboardMarkup : ReplyMarkup
	{
		[Flags] public enum Flags { resize = 0x1, single_use = 0x2, selective = 0x4, has_placeholder = 0x8 }
		public Flags flags;
		public KeyboardButtonRow[] rows;
		[IfFlag(3)] public string placeholder;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/replyInlineMarkup"/></summary>
	[TLDef(0x48A30254)]
	public partial class ReplyInlineMarkup : ReplyMarkup { public KeyboardButtonRow[] rows; }

	///<summary>See <a href="https://core.telegram.org/type/MessageEntity"/></summary>
	public abstract partial class MessageEntity : ITLObject
	{
		public int offset;
		public int length;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messageEntityUnknown"/></summary>
	[TLDef(0xBB92BA95)]
	public partial class MessageEntityUnknown : MessageEntity { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageEntityMention"/></summary>
	[TLDef(0xFA04579D)]
	public partial class MessageEntityMention : MessageEntity { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageEntityHashtag"/></summary>
	[TLDef(0x6F635B0D)]
	public partial class MessageEntityHashtag : MessageEntity { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageEntityBotCommand"/></summary>
	[TLDef(0x6CEF8AC7)]
	public partial class MessageEntityBotCommand : MessageEntity { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageEntityUrl"/></summary>
	[TLDef(0x6ED02538)]
	public partial class MessageEntityUrl : MessageEntity { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageEntityEmail"/></summary>
	[TLDef(0x64E475C2)]
	public partial class MessageEntityEmail : MessageEntity { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageEntityBold"/></summary>
	[TLDef(0xBD610BC9)]
	public partial class MessageEntityBold : MessageEntity { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageEntityItalic"/></summary>
	[TLDef(0x826F8B60)]
	public partial class MessageEntityItalic : MessageEntity { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageEntityCode"/></summary>
	[TLDef(0x28A20571)]
	public partial class MessageEntityCode : MessageEntity { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageEntityPre"/></summary>
	[TLDef(0x73924BE0)]
	public partial class MessageEntityPre : MessageEntity { public string language; }
	///<summary>See <a href="https://core.telegram.org/constructor/messageEntityTextUrl"/></summary>
	[TLDef(0x76A6D327)]
	public partial class MessageEntityTextUrl : MessageEntity { public string url; }
	///<summary>See <a href="https://core.telegram.org/constructor/messageEntityMentionName"/></summary>
	[TLDef(0xDC7B1140)]
	public partial class MessageEntityMentionName : MessageEntity { public long user_id; }
	///<summary>See <a href="https://core.telegram.org/constructor/inputMessageEntityMentionName"/></summary>
	[TLDef(0x208E68C9)]
	public partial class InputMessageEntityMentionName : MessageEntity { public InputUserBase user_id; }
	///<summary>See <a href="https://core.telegram.org/constructor/messageEntityPhone"/></summary>
	[TLDef(0x9B69E34B)]
	public partial class MessageEntityPhone : MessageEntity { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageEntityCashtag"/></summary>
	[TLDef(0x4C4E743F)]
	public partial class MessageEntityCashtag : MessageEntity { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageEntityUnderline"/></summary>
	[TLDef(0x9C4E7E8B)]
	public partial class MessageEntityUnderline : MessageEntity { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageEntityStrike"/></summary>
	[TLDef(0xBF0693D4)]
	public partial class MessageEntityStrike : MessageEntity { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageEntityBlockquote"/></summary>
	[TLDef(0x020DF5D0)]
	public partial class MessageEntityBlockquote : MessageEntity { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageEntityBankCard"/></summary>
	[TLDef(0x761E6AF4)]
	public partial class MessageEntityBankCard : MessageEntity { }

	///<summary>See <a href="https://core.telegram.org/type/InputChannel"/></summary>
	public abstract partial class InputChannelBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputChannelEmpty"/></summary>
	[TLDef(0xEE8C1E86)]
	public partial class InputChannelEmpty : InputChannelBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputChannel"/></summary>
	[TLDef(0xF35AEC28)]
	public partial class InputChannel : InputChannelBase
	{
		public long channel_id;
		public long access_hash;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputChannelFromMessage"/></summary>
	[TLDef(0x5B934F9D)]
	public partial class InputChannelFromMessage : InputChannelBase
	{
		public InputPeer peer;
		public int msg_id;
		public long channel_id;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/contacts.resolvedPeer"/></summary>
	[TLDef(0x7F077AD9)]
	public partial class Contacts_ResolvedPeer : ITLObject
	{
		public Peer peer;
		public ChatBase[] chats;
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/messageRange"/></summary>
	[TLDef(0x0AE30253)]
	public partial class MessageRange : ITLObject
	{
		public int min_id;
		public int max_id;
	}

	///<summary>See <a href="https://core.telegram.org/type/updates.ChannelDifference"/></summary>
	public abstract partial class Updates_ChannelDifferenceBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/updates.channelDifferenceEmpty"/></summary>
	[TLDef(0x3E11AFFB)]
	public partial class Updates_ChannelDifferenceEmpty : Updates_ChannelDifferenceBase
	{
		[Flags] public enum Flags { final = 0x1, has_timeout = 0x2 }
		public Flags flags;
		public int pts;
		[IfFlag(1)] public int timeout;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updates.channelDifferenceTooLong"/></summary>
	[TLDef(0xA4BCC6FE)]
	public partial class Updates_ChannelDifferenceTooLong : Updates_ChannelDifferenceBase
	{
		[Flags] public enum Flags { final = 0x1, has_timeout = 0x2 }
		public Flags flags;
		[IfFlag(1)] public int timeout;
		public DialogBase dialog;
		public MessageBase[] messages;
		public ChatBase[] chats;
		public UserBase[] users;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/updates.channelDifference"/></summary>
	[TLDef(0x2064674E)]
	public partial class Updates_ChannelDifference : Updates_ChannelDifferenceBase
	{
		[Flags] public enum Flags { final = 0x1, has_timeout = 0x2 }
		public Flags flags;
		public int pts;
		[IfFlag(1)] public int timeout;
		public MessageBase[] new_messages;
		public Update[] other_updates;
		public ChatBase[] chats;
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/type/ChannelMessagesFilter"/></summary>
	public abstract partial class ChannelMessagesFilterBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/channelMessagesFilterEmpty"/></summary>
	[TLDef(0x94D42EE7)]
	public partial class ChannelMessagesFilterEmpty : ChannelMessagesFilterBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/channelMessagesFilter"/></summary>
	[TLDef(0xCD77D957)]
	public partial class ChannelMessagesFilter : ChannelMessagesFilterBase
	{
		[Flags] public enum Flags { exclude_new_messages = 0x2 }
		public Flags flags;
		public MessageRange[] ranges;
	}

	///<summary>See <a href="https://core.telegram.org/type/ChannelParticipant"/></summary>
	public abstract partial class ChannelParticipantBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/channelParticipant"/></summary>
	[TLDef(0xC00C07C0)]
	public partial class ChannelParticipant : ChannelParticipantBase
	{
		public long user_id;
		public DateTime date;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/channelParticipantSelf"/></summary>
	[TLDef(0x28A8BC67)]
	public partial class ChannelParticipantSelf : ChannelParticipantBase
	{
		public long user_id;
		public long inviter_id;
		public DateTime date;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/channelParticipantCreator"/></summary>
	[TLDef(0x2FE601D3)]
	public partial class ChannelParticipantCreator : ChannelParticipantBase
	{
		[Flags] public enum Flags { has_rank = 0x1 }
		public Flags flags;
		public long user_id;
		public ChatAdminRights admin_rights;
		[IfFlag(0)] public string rank;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/channelParticipantAdmin"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/channelParticipantBanned"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/channelParticipantLeft"/></summary>
	[TLDef(0x1B03F006)]
	public partial class ChannelParticipantLeft : ChannelParticipantBase { public Peer peer; }

	///<summary>See <a href="https://core.telegram.org/type/ChannelParticipantsFilter"/></summary>
	public abstract partial class ChannelParticipantsFilter : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/channelParticipantsRecent"/></summary>
	[TLDef(0xDE3F3C79)]
	public partial class ChannelParticipantsRecent : ChannelParticipantsFilter { }
	///<summary>See <a href="https://core.telegram.org/constructor/channelParticipantsAdmins"/></summary>
	[TLDef(0xB4608969)]
	public partial class ChannelParticipantsAdmins : ChannelParticipantsFilter { }
	///<summary>See <a href="https://core.telegram.org/constructor/channelParticipantsKicked"/></summary>
	[TLDef(0xA3B54985)]
	public partial class ChannelParticipantsKicked : ChannelParticipantsFilter { public string q; }
	///<summary>See <a href="https://core.telegram.org/constructor/channelParticipantsBots"/></summary>
	[TLDef(0xB0D1865B)]
	public partial class ChannelParticipantsBots : ChannelParticipantsFilter { }
	///<summary>See <a href="https://core.telegram.org/constructor/channelParticipantsBanned"/></summary>
	[TLDef(0x1427A5E1)]
	public partial class ChannelParticipantsBanned : ChannelParticipantsFilter { public string q; }
	///<summary>See <a href="https://core.telegram.org/constructor/channelParticipantsSearch"/></summary>
	[TLDef(0x0656AC4B)]
	public partial class ChannelParticipantsSearch : ChannelParticipantsFilter { public string q; }
	///<summary>See <a href="https://core.telegram.org/constructor/channelParticipantsContacts"/></summary>
	[TLDef(0xBB6AE88D)]
	public partial class ChannelParticipantsContacts : ChannelParticipantsFilter { public string q; }
	///<summary>See <a href="https://core.telegram.org/constructor/channelParticipantsMentions"/></summary>
	[TLDef(0xE04B5CEB)]
	public partial class ChannelParticipantsMentions : ChannelParticipantsFilter
	{
		[Flags] public enum Flags { has_q = 0x1, has_top_msg_id = 0x2 }
		public Flags flags;
		[IfFlag(0)] public string q;
		[IfFlag(1)] public int top_msg_id;
	}

	///<summary>See <a href="https://core.telegram.org/type/channels.ChannelParticipants"/></summary>
	public abstract partial class Channels_ChannelParticipantsBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/channels.channelParticipants"/></summary>
	[TLDef(0x9AB0FEAF)]
	public partial class Channels_ChannelParticipants : Channels_ChannelParticipantsBase
	{
		public int count;
		public ChannelParticipantBase[] participants;
		public ChatBase[] chats;
		public UserBase[] users;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/channels.channelParticipantsNotModified"/></summary>
	[TLDef(0xF0173FE9)]
	public partial class Channels_ChannelParticipantsNotModified : Channels_ChannelParticipantsBase { }

	///<summary>See <a href="https://core.telegram.org/constructor/channels.channelParticipant"/></summary>
	[TLDef(0xDFB80317)]
	public partial class Channels_ChannelParticipant : ITLObject
	{
		public ChannelParticipantBase participant;
		public ChatBase[] chats;
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/help.termsOfService"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/type/messages.SavedGifs"/></summary>
	public abstract partial class Messages_SavedGifsBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/messages.savedGifsNotModified"/></summary>
	[TLDef(0xE8025CA2)]
	public partial class Messages_SavedGifsNotModified : Messages_SavedGifsBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/messages.savedGifs"/></summary>
	[TLDef(0x84A02A0D)]
	public partial class Messages_SavedGifs : Messages_SavedGifsBase
	{
		public long hash;
		public DocumentBase[] gifs;
	}

	///<summary>See <a href="https://core.telegram.org/type/InputBotInlineMessage"/></summary>
	public abstract partial class InputBotInlineMessage : ITLObject { public int flags; }
	///<summary>See <a href="https://core.telegram.org/constructor/inputBotInlineMessageMediaAuto"/></summary>
	[TLDef(0x3380C786)]
	public partial class InputBotInlineMessageMediaAuto : InputBotInlineMessage
	{
		[Flags] public enum Flags { has_entities = 0x2, has_reply_markup = 0x4 }
		public string message;
		[IfFlag(1)] public MessageEntity[] entities;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputBotInlineMessageText"/></summary>
	[TLDef(0x3DCD7A87)]
	public partial class InputBotInlineMessageText : InputBotInlineMessage
	{
		[Flags] public enum Flags { no_webpage = 0x1, has_entities = 0x2, has_reply_markup = 0x4 }
		public string message;
		[IfFlag(1)] public MessageEntity[] entities;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputBotInlineMessageMediaGeo"/></summary>
	[TLDef(0x96929A85)]
	public partial class InputBotInlineMessageMediaGeo : InputBotInlineMessage
	{
		[Flags] public enum Flags { has_heading = 0x1, has_period = 0x2, has_reply_markup = 0x4, 
			has_proximity_notification_radius = 0x8 }
		public InputGeoPointBase geo_point;
		[IfFlag(0)] public int heading;
		[IfFlag(1)] public int period;
		[IfFlag(3)] public int proximity_notification_radius;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputBotInlineMessageMediaVenue"/></summary>
	[TLDef(0x417BBF11)]
	public partial class InputBotInlineMessageMediaVenue : InputBotInlineMessage
	{
		[Flags] public enum Flags { has_reply_markup = 0x4 }
		public InputGeoPointBase geo_point;
		public string title;
		public string address;
		public string provider;
		public string venue_id;
		public string venue_type;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputBotInlineMessageMediaContact"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/inputBotInlineMessageGame"/></summary>
	[TLDef(0x4B425864)]
	public partial class InputBotInlineMessageGame : InputBotInlineMessage
	{
		[Flags] public enum Flags { has_reply_markup = 0x4 }
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputBotInlineMessageMediaInvoice"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/type/InputBotInlineResult"/></summary>
	public abstract partial class InputBotInlineResultBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputBotInlineResult"/></summary>
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
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputBotInlineResultPhoto"/></summary>
	[TLDef(0xA8D864A7)]
	public partial class InputBotInlineResultPhoto : InputBotInlineResultBase
	{
		public string id;
		public string type;
		public InputPhotoBase photo;
		public InputBotInlineMessage send_message;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputBotInlineResultDocument"/></summary>
	[TLDef(0xFFF8FDC4)]
	public partial class InputBotInlineResultDocument : InputBotInlineResultBase
	{
		[Flags] public enum Flags { has_title = 0x2, has_description = 0x4 }
		public Flags flags;
		public string id;
		public string type;
		[IfFlag(1)] public string title;
		[IfFlag(2)] public string description;
		public InputDocumentBase document;
		public InputBotInlineMessage send_message;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputBotInlineResultGame"/></summary>
	[TLDef(0x4FA417F2)]
	public partial class InputBotInlineResultGame : InputBotInlineResultBase
	{
		public string id;
		public string short_name;
		public InputBotInlineMessage send_message;
	}

	///<summary>See <a href="https://core.telegram.org/type/BotInlineMessage"/></summary>
	public abstract partial class BotInlineMessage : ITLObject { public int flags; }
	///<summary>See <a href="https://core.telegram.org/constructor/botInlineMessageMediaAuto"/></summary>
	[TLDef(0x764CF810)]
	public partial class BotInlineMessageMediaAuto : BotInlineMessage
	{
		[Flags] public enum Flags { has_entities = 0x2, has_reply_markup = 0x4 }
		public string message;
		[IfFlag(1)] public MessageEntity[] entities;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/botInlineMessageText"/></summary>
	[TLDef(0x8C7F65E2)]
	public partial class BotInlineMessageText : BotInlineMessage
	{
		[Flags] public enum Flags { no_webpage = 0x1, has_entities = 0x2, has_reply_markup = 0x4 }
		public string message;
		[IfFlag(1)] public MessageEntity[] entities;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/botInlineMessageMediaGeo"/></summary>
	[TLDef(0x051846FD)]
	public partial class BotInlineMessageMediaGeo : BotInlineMessage
	{
		[Flags] public enum Flags { has_heading = 0x1, has_period = 0x2, has_reply_markup = 0x4, 
			has_proximity_notification_radius = 0x8 }
		public GeoPointBase geo;
		[IfFlag(0)] public int heading;
		[IfFlag(1)] public int period;
		[IfFlag(3)] public int proximity_notification_radius;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/botInlineMessageMediaVenue"/></summary>
	[TLDef(0x8A86659C)]
	public partial class BotInlineMessageMediaVenue : BotInlineMessage
	{
		[Flags] public enum Flags { has_reply_markup = 0x4 }
		public GeoPointBase geo;
		public string title;
		public string address;
		public string provider;
		public string venue_id;
		public string venue_type;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/botInlineMessageMediaContact"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/botInlineMessageMediaInvoice"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/type/BotInlineResult"/></summary>
	public abstract partial class BotInlineResultBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/botInlineResult"/></summary>
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
	}
	///<summary>See <a href="https://core.telegram.org/constructor/botInlineMediaResult"/></summary>
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
	}

	///<summary>See <a href="https://core.telegram.org/constructor/messages.botResults"/></summary>
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
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/exportedMessageLink"/></summary>
	[TLDef(0x5DAB1AF4)]
	public partial class ExportedMessageLink : ITLObject
	{
		public string link;
		public string html;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/messageFwdHeader"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/type/auth.CodeType"/></summary>
	public abstract partial class Auth_CodeType : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/auth.codeTypeSms"/></summary>
	[TLDef(0x72A3158C)]
	public partial class Auth_CodeTypeSms : Auth_CodeType { }
	///<summary>See <a href="https://core.telegram.org/constructor/auth.codeTypeCall"/></summary>
	[TLDef(0x741CD3E3)]
	public partial class Auth_CodeTypeCall : Auth_CodeType { }
	///<summary>See <a href="https://core.telegram.org/constructor/auth.codeTypeFlashCall"/></summary>
	[TLDef(0x226CCEFB)]
	public partial class Auth_CodeTypeFlashCall : Auth_CodeType { }

	///<summary>See <a href="https://core.telegram.org/type/auth.SentCodeType"/></summary>
	public abstract partial class Auth_SentCodeType : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/auth.sentCodeTypeApp"/></summary>
	[TLDef(0x3DBB5986)]
	public partial class Auth_SentCodeTypeApp : Auth_SentCodeType { public int length; }
	///<summary>See <a href="https://core.telegram.org/constructor/auth.sentCodeTypeSms"/></summary>
	[TLDef(0xC000BBA2)]
	public partial class Auth_SentCodeTypeSms : Auth_SentCodeType { public int length; }
	///<summary>See <a href="https://core.telegram.org/constructor/auth.sentCodeTypeCall"/></summary>
	[TLDef(0x5353E5A7)]
	public partial class Auth_SentCodeTypeCall : Auth_SentCodeType { public int length; }
	///<summary>See <a href="https://core.telegram.org/constructor/auth.sentCodeTypeFlashCall"/></summary>
	[TLDef(0xAB03C6D9)]
	public partial class Auth_SentCodeTypeFlashCall : Auth_SentCodeType { public string pattern; }

	///<summary>See <a href="https://core.telegram.org/constructor/messages.botCallbackAnswer"/></summary>
	[TLDef(0x36585EA4)]
	public partial class Messages_BotCallbackAnswer : ITLObject
	{
		[Flags] public enum Flags { has_message = 0x1, alert = 0x2, has_url_field = 0x4, has_url = 0x8, native_ui = 0x10 }
		public Flags flags;
		[IfFlag(0)] public string message;
		[IfFlag(2)] public string url;
		public DateTime cache_time;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/messages.messageEditData"/></summary>
	[TLDef(0x26B5DDE6)]
	public partial class Messages_MessageEditData : ITLObject
	{
		[Flags] public enum Flags { caption = 0x1 }
		public Flags flags;
	}

	///<summary>See <a href="https://core.telegram.org/type/InputBotInlineMessageID"/></summary>
	public abstract partial class InputBotInlineMessageIDBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputBotInlineMessageID"/></summary>
	[TLDef(0x890C3D89)]
	public partial class InputBotInlineMessageID : InputBotInlineMessageIDBase
	{
		public int dc_id;
		public long id;
		public long access_hash;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputBotInlineMessageID64"/></summary>
	[TLDef(0xB6D915D7)]
	public partial class InputBotInlineMessageID64 : InputBotInlineMessageIDBase
	{
		public int dc_id;
		public long owner_id;
		public int id;
		public long access_hash;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/inlineBotSwitchPM"/></summary>
	[TLDef(0x3C20629F)]
	public partial class InlineBotSwitchPM : ITLObject
	{
		public string text;
		public string start_param;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/messages.peerDialogs"/></summary>
	[TLDef(0x3371C354)]
	public partial class Messages_PeerDialogs : ITLObject
	{
		public DialogBase[] dialogs;
		public MessageBase[] messages;
		public ChatBase[] chats;
		public UserBase[] users;
		public Updates_State state;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/topPeer"/></summary>
	[TLDef(0xEDCDC05B)]
	public partial class TopPeer : ITLObject
	{
		public Peer peer;
		public double rating;
	}

	///<summary>See <a href="https://core.telegram.org/type/TopPeerCategory"/></summary>
	public abstract partial class TopPeerCategory : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/topPeerCategoryBotsPM"/></summary>
	[TLDef(0xAB661B5B)]
	public partial class TopPeerCategoryBotsPM : TopPeerCategory { }
	///<summary>See <a href="https://core.telegram.org/constructor/topPeerCategoryBotsInline"/></summary>
	[TLDef(0x148677E2)]
	public partial class TopPeerCategoryBotsInline : TopPeerCategory { }
	///<summary>See <a href="https://core.telegram.org/constructor/topPeerCategoryCorrespondents"/></summary>
	[TLDef(0x0637B7ED)]
	public partial class TopPeerCategoryCorrespondents : TopPeerCategory { }
	///<summary>See <a href="https://core.telegram.org/constructor/topPeerCategoryGroups"/></summary>
	[TLDef(0xBD17A14A)]
	public partial class TopPeerCategoryGroups : TopPeerCategory { }
	///<summary>See <a href="https://core.telegram.org/constructor/topPeerCategoryChannels"/></summary>
	[TLDef(0x161D9628)]
	public partial class TopPeerCategoryChannels : TopPeerCategory { }
	///<summary>See <a href="https://core.telegram.org/constructor/topPeerCategoryPhoneCalls"/></summary>
	[TLDef(0x1E76A78C)]
	public partial class TopPeerCategoryPhoneCalls : TopPeerCategory { }
	///<summary>See <a href="https://core.telegram.org/constructor/topPeerCategoryForwardUsers"/></summary>
	[TLDef(0xA8406CA9)]
	public partial class TopPeerCategoryForwardUsers : TopPeerCategory { }
	///<summary>See <a href="https://core.telegram.org/constructor/topPeerCategoryForwardChats"/></summary>
	[TLDef(0xFBEEC0F0)]
	public partial class TopPeerCategoryForwardChats : TopPeerCategory { }

	///<summary>See <a href="https://core.telegram.org/constructor/topPeerCategoryPeers"/></summary>
	[TLDef(0xFB834291)]
	public partial class TopPeerCategoryPeers : ITLObject
	{
		public TopPeerCategory category;
		public int count;
		public TopPeer[] peers;
	}

	///<summary>See <a href="https://core.telegram.org/type/contacts.TopPeers"/></summary>
	public abstract partial class Contacts_TopPeersBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/contacts.topPeersNotModified"/></summary>
	[TLDef(0xDE266EF5)]
	public partial class Contacts_TopPeersNotModified : Contacts_TopPeersBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/contacts.topPeers"/></summary>
	[TLDef(0x70B772A8)]
	public partial class Contacts_TopPeers : Contacts_TopPeersBase
	{
		public TopPeerCategoryPeers[] categories;
		public ChatBase[] chats;
		public UserBase[] users;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/contacts.topPeersDisabled"/></summary>
	[TLDef(0xB52C939D)]
	public partial class Contacts_TopPeersDisabled : Contacts_TopPeersBase { }

	///<summary>See <a href="https://core.telegram.org/type/DraftMessage"/></summary>
	public abstract partial class DraftMessageBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/draftMessageEmpty"/></summary>
	[TLDef(0x1B0C841A)]
	public partial class DraftMessageEmpty : DraftMessageBase
	{
		[Flags] public enum Flags { has_date = 0x1 }
		public Flags flags;
		[IfFlag(0)] public DateTime date;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/draftMessage"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/type/messages.FeaturedStickers"/></summary>
	public abstract partial class Messages_FeaturedStickersBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/messages.featuredStickersNotModified"/></summary>
	[TLDef(0xC6DC0C66)]
	public partial class Messages_FeaturedStickersNotModified : Messages_FeaturedStickersBase { public int count; }
	///<summary>See <a href="https://core.telegram.org/constructor/messages.featuredStickers"/></summary>
	[TLDef(0x84C02310)]
	public partial class Messages_FeaturedStickers : Messages_FeaturedStickersBase
	{
		public long hash;
		public int count;
		public StickerSetCoveredBase[] sets;
		public long[] unread;
	}

	///<summary>See <a href="https://core.telegram.org/type/messages.RecentStickers"/></summary>
	public abstract partial class Messages_RecentStickersBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/messages.recentStickersNotModified"/></summary>
	[TLDef(0x0B17F890)]
	public partial class Messages_RecentStickersNotModified : Messages_RecentStickersBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/messages.recentStickers"/></summary>
	[TLDef(0x88D37C56)]
	public partial class Messages_RecentStickers : Messages_RecentStickersBase
	{
		public long hash;
		public StickerPack[] packs;
		public DocumentBase[] stickers;
		public int[] dates;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/messages.archivedStickers"/></summary>
	[TLDef(0x4FCBA9C8)]
	public partial class Messages_ArchivedStickers : ITLObject
	{
		public int count;
		public StickerSetCoveredBase[] sets;
	}

	///<summary>See <a href="https://core.telegram.org/type/messages.StickerSetInstallResult"/></summary>
	public abstract partial class Messages_StickerSetInstallResult : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/messages.stickerSetInstallResultSuccess"/></summary>
	[TLDef(0x38641628)]
	public partial class Messages_StickerSetInstallResultSuccess : Messages_StickerSetInstallResult { }
	///<summary>See <a href="https://core.telegram.org/constructor/messages.stickerSetInstallResultArchive"/></summary>
	[TLDef(0x35E410A8)]
	public partial class Messages_StickerSetInstallResultArchive : Messages_StickerSetInstallResult { public StickerSetCoveredBase[] sets; }

	///<summary>See <a href="https://core.telegram.org/type/StickerSetCovered"/></summary>
	public abstract partial class StickerSetCoveredBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/stickerSetCovered"/></summary>
	[TLDef(0x6410A5D2)]
	public partial class StickerSetCovered : StickerSetCoveredBase
	{
		public StickerSet set;
		public DocumentBase cover;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/stickerSetMultiCovered"/></summary>
	[TLDef(0x3407E51B)]
	public partial class StickerSetMultiCovered : StickerSetCoveredBase
	{
		public StickerSet set;
		public DocumentBase[] covers;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/maskCoords"/></summary>
	[TLDef(0xAED6DBB2)]
	public partial class MaskCoords : ITLObject
	{
		public int n;
		public double x;
		public double y;
		public double zoom;
	}

	///<summary>See <a href="https://core.telegram.org/type/InputStickeredMedia"/></summary>
	public abstract partial class InputStickeredMedia : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputStickeredMediaPhoto"/></summary>
	[TLDef(0x4A992157)]
	public partial class InputStickeredMediaPhoto : InputStickeredMedia { public InputPhotoBase id; }
	///<summary>See <a href="https://core.telegram.org/constructor/inputStickeredMediaDocument"/></summary>
	[TLDef(0x0438865B)]
	public partial class InputStickeredMediaDocument : InputStickeredMedia { public InputDocumentBase id; }

	///<summary>See <a href="https://core.telegram.org/constructor/game"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/type/InputGame"/></summary>
	public abstract partial class InputGame : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputGameID"/></summary>
	[TLDef(0x032C3E77)]
	public partial class InputGameID : InputGame
	{
		public long id;
		public long access_hash;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputGameShortName"/></summary>
	[TLDef(0xC331E80A)]
	public partial class InputGameShortName : InputGame
	{
		public InputUserBase bot_id;
		public string short_name;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/highScore"/></summary>
	[TLDef(0x73A379EB)]
	public partial class HighScore : ITLObject
	{
		public int pos;
		public long user_id;
		public int score;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/messages.highScores"/></summary>
	[TLDef(0x9A3BFD99)]
	public partial class Messages_HighScores : ITLObject
	{
		public HighScore[] scores;
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/type/RichText"/></summary>
	public abstract partial class RichText : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/textEmpty"/></summary>
	[TLDef(0xDC3D824F)]
	public partial class TextEmpty : RichText { }
	///<summary>See <a href="https://core.telegram.org/constructor/textPlain"/></summary>
	[TLDef(0x744694E0)]
	public partial class TextPlain : RichText { public string text; }
	///<summary>See <a href="https://core.telegram.org/constructor/textBold"/></summary>
	[TLDef(0x6724ABC4)]
	public partial class TextBold : RichText { public RichText text; }
	///<summary>See <a href="https://core.telegram.org/constructor/textItalic"/></summary>
	[TLDef(0xD912A59C)]
	public partial class TextItalic : RichText { public RichText text; }
	///<summary>See <a href="https://core.telegram.org/constructor/textUnderline"/></summary>
	[TLDef(0xC12622C4)]
	public partial class TextUnderline : RichText { public RichText text; }
	///<summary>See <a href="https://core.telegram.org/constructor/textStrike"/></summary>
	[TLDef(0x9BF8BB95)]
	public partial class TextStrike : RichText { public RichText text; }
	///<summary>See <a href="https://core.telegram.org/constructor/textFixed"/></summary>
	[TLDef(0x6C3F19B9)]
	public partial class TextFixed : RichText { public RichText text; }
	///<summary>See <a href="https://core.telegram.org/constructor/textUrl"/></summary>
	[TLDef(0x3C2884C1)]
	public partial class TextUrl : RichText
	{
		public RichText text;
		public string url;
		public long webpage_id;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/textEmail"/></summary>
	[TLDef(0xDE5A0DD6)]
	public partial class TextEmail : RichText
	{
		public RichText text;
		public string email;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/textConcat"/></summary>
	[TLDef(0x7E6260D7)]
	public partial class TextConcat : RichText { public RichText[] texts; }
	///<summary>See <a href="https://core.telegram.org/constructor/textSubscript"/></summary>
	[TLDef(0xED6A8504)]
	public partial class TextSubscript : RichText { public RichText text; }
	///<summary>See <a href="https://core.telegram.org/constructor/textSuperscript"/></summary>
	[TLDef(0xC7FB5E01)]
	public partial class TextSuperscript : RichText { public RichText text; }
	///<summary>See <a href="https://core.telegram.org/constructor/textMarked"/></summary>
	[TLDef(0x034B8621)]
	public partial class TextMarked : RichText { public RichText text; }
	///<summary>See <a href="https://core.telegram.org/constructor/textPhone"/></summary>
	[TLDef(0x1CCB966A)]
	public partial class TextPhone : RichText
	{
		public RichText text;
		public string phone;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/textImage"/></summary>
	[TLDef(0x081CCF4F)]
	public partial class TextImage : RichText
	{
		public long document_id;
		public int w;
		public int h;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/textAnchor"/></summary>
	[TLDef(0x35553762)]
	public partial class TextAnchor : RichText
	{
		public RichText text;
		public string name;
	}

	///<summary>See <a href="https://core.telegram.org/type/PageBlock"/></summary>
	public abstract partial class PageBlock : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockUnsupported"/></summary>
	[TLDef(0x13567E8A)]
	public partial class PageBlockUnsupported : PageBlock { }
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockTitle"/></summary>
	[TLDef(0x70ABC3FD)]
	public partial class PageBlockTitle : PageBlock { public RichText text; }
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockSubtitle"/></summary>
	[TLDef(0x8FFA9A1F)]
	public partial class PageBlockSubtitle : PageBlock { public RichText text; }
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockAuthorDate"/></summary>
	[TLDef(0xBAAFE5E0)]
	public partial class PageBlockAuthorDate : PageBlock
	{
		public RichText author;
		public DateTime published_date;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockHeader"/></summary>
	[TLDef(0xBFD064EC)]
	public partial class PageBlockHeader : PageBlock { public RichText text; }
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockSubheader"/></summary>
	[TLDef(0xF12BB6E1)]
	public partial class PageBlockSubheader : PageBlock { public RichText text; }
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockParagraph"/></summary>
	[TLDef(0x467A0766)]
	public partial class PageBlockParagraph : PageBlock { public RichText text; }
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockPreformatted"/></summary>
	[TLDef(0xC070D93E)]
	public partial class PageBlockPreformatted : PageBlock
	{
		public RichText text;
		public string language;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockFooter"/></summary>
	[TLDef(0x48870999)]
	public partial class PageBlockFooter : PageBlock { public RichText text; }
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockDivider"/></summary>
	[TLDef(0xDB20B188)]
	public partial class PageBlockDivider : PageBlock { }
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockAnchor"/></summary>
	[TLDef(0xCE0D37B0)]
	public partial class PageBlockAnchor : PageBlock { public string name; }
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockList"/></summary>
	[TLDef(0xE4E88011)]
	public partial class PageBlockList : PageBlock { public PageListItem[] items; }
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockBlockquote"/></summary>
	[TLDef(0x263D7C26)]
	public partial class PageBlockBlockquote : PageBlock
	{
		public RichText text;
		public RichText caption;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockPullquote"/></summary>
	[TLDef(0x4F4456D3)]
	public partial class PageBlockPullquote : PageBlock
	{
		public RichText text;
		public RichText caption;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockPhoto"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockVideo"/></summary>
	[TLDef(0x7C8FE7B6)]
	public partial class PageBlockVideo : PageBlock
	{
		[Flags] public enum Flags { autoplay = 0x1, loop = 0x2 }
		public Flags flags;
		public long video_id;
		public PageCaption caption;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockCover"/></summary>
	[TLDef(0x39F23300)]
	public partial class PageBlockCover : PageBlock { public PageBlock cover; }
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockEmbed"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockEmbedPost"/></summary>
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
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockCollage"/></summary>
	[TLDef(0x65A0FA4D)]
	public partial class PageBlockCollage : PageBlock
	{
		public PageBlock[] items;
		public PageCaption caption;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockSlideshow"/></summary>
	[TLDef(0x031F9590)]
	public partial class PageBlockSlideshow : PageBlock
	{
		public PageBlock[] items;
		public PageCaption caption;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockChannel"/></summary>
	[TLDef(0xEF1751B5)]
	public partial class PageBlockChannel : PageBlock { public ChatBase channel; }
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockAudio"/></summary>
	[TLDef(0x804361EA)]
	public partial class PageBlockAudio : PageBlock
	{
		public long audio_id;
		public PageCaption caption;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockKicker"/></summary>
	[TLDef(0x1E148390)]
	public partial class PageBlockKicker : PageBlock { public RichText text; }
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockTable"/></summary>
	[TLDef(0xBF4DEA82)]
	public partial class PageBlockTable : PageBlock
	{
		[Flags] public enum Flags { bordered = 0x1, striped = 0x2 }
		public Flags flags;
		public RichText title;
		public PageTableRow[] rows;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockOrderedList"/></summary>
	[TLDef(0x9A8AE1E1)]
	public partial class PageBlockOrderedList : PageBlock { public PageListOrderedItem[] items; }
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockDetails"/></summary>
	[TLDef(0x76768BED)]
	public partial class PageBlockDetails : PageBlock
	{
		[Flags] public enum Flags { open = 0x1 }
		public Flags flags;
		public PageBlock[] blocks;
		public RichText title;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockRelatedArticles"/></summary>
	[TLDef(0x16115A96)]
	public partial class PageBlockRelatedArticles : PageBlock
	{
		public RichText title;
		public PageRelatedArticle[] articles;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/pageBlockMap"/></summary>
	[TLDef(0xA44F3EF6)]
	public partial class PageBlockMap : PageBlock
	{
		public GeoPointBase geo;
		public int zoom;
		public int w;
		public int h;
		public PageCaption caption;
	}

	///<summary>See <a href="https://core.telegram.org/type/PhoneCallDiscardReason"/></summary>
	public abstract partial class PhoneCallDiscardReason : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/phoneCallDiscardReasonMissed"/></summary>
	[TLDef(0x85E42301)]
	public partial class PhoneCallDiscardReasonMissed : PhoneCallDiscardReason { }
	///<summary>See <a href="https://core.telegram.org/constructor/phoneCallDiscardReasonDisconnect"/></summary>
	[TLDef(0xE095C1A0)]
	public partial class PhoneCallDiscardReasonDisconnect : PhoneCallDiscardReason { }
	///<summary>See <a href="https://core.telegram.org/constructor/phoneCallDiscardReasonHangup"/></summary>
	[TLDef(0x57ADC690)]
	public partial class PhoneCallDiscardReasonHangup : PhoneCallDiscardReason { }
	///<summary>See <a href="https://core.telegram.org/constructor/phoneCallDiscardReasonBusy"/></summary>
	[TLDef(0xFAF7E8C9)]
	public partial class PhoneCallDiscardReasonBusy : PhoneCallDiscardReason { }

	///<summary>See <a href="https://core.telegram.org/constructor/dataJSON"/></summary>
	[TLDef(0x7D748D04)]
	public partial class DataJSON : ITLObject { public string data; }

	///<summary>See <a href="https://core.telegram.org/constructor/labeledPrice"/></summary>
	[TLDef(0xCB296BF8)]
	public partial class LabeledPrice : ITLObject
	{
		public string label;
		public long amount;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/invoice"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/paymentCharge"/></summary>
	[TLDef(0xEA02C27E)]
	public partial class PaymentCharge : ITLObject
	{
		public string id;
		public string provider_charge_id;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/postAddress"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/paymentRequestedInfo"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/type/PaymentSavedCredentials"/></summary>
	public abstract partial class PaymentSavedCredentials : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/paymentSavedCredentialsCard"/></summary>
	[TLDef(0xCDC27A1F)]
	public partial class PaymentSavedCredentialsCard : PaymentSavedCredentials
	{
		public string id;
		public string title;
	}

	///<summary>See <a href="https://core.telegram.org/type/WebDocument"/></summary>
	public abstract partial class WebDocumentBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/webDocument"/></summary>
	[TLDef(0x1C570ED1)]
	public partial class WebDocument : WebDocumentBase
	{
		public string url;
		public long access_hash;
		public int size;
		public string mime_type;
		public DocumentAttribute[] attributes;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/webDocumentNoProxy"/></summary>
	[TLDef(0xF9C8BCC6)]
	public partial class WebDocumentNoProxy : WebDocumentBase
	{
		public string url;
		public int size;
		public string mime_type;
		public DocumentAttribute[] attributes;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/inputWebDocument"/></summary>
	[TLDef(0x9BED434D)]
	public partial class InputWebDocument : ITLObject
	{
		public string url;
		public int size;
		public string mime_type;
		public DocumentAttribute[] attributes;
	}

	///<summary>See <a href="https://core.telegram.org/type/InputWebFileLocation"/></summary>
	public abstract partial class InputWebFileLocationBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputWebFileLocation"/></summary>
	[TLDef(0xC239D686)]
	public partial class InputWebFileLocation : InputWebFileLocationBase
	{
		public string url;
		public long access_hash;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputWebFileGeoPointLocation"/></summary>
	[TLDef(0x9F2221C9)]
	public partial class InputWebFileGeoPointLocation : InputWebFileLocationBase
	{
		public InputGeoPointBase geo_point;
		public long access_hash;
		public int w;
		public int h;
		public int zoom;
		public int scale;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/upload.webFile"/></summary>
	[TLDef(0x21E753BC)]
	public partial class Upload_WebFile : ITLObject
	{
		public int size;
		public string mime_type;
		public Storage_FileType file_type;
		public int mtime;
		public byte[] bytes;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/payments.paymentForm"/></summary>
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
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/payments.validatedRequestedInfo"/></summary>
	[TLDef(0xD1451883)]
	public partial class Payments_ValidatedRequestedInfo : ITLObject
	{
		[Flags] public enum Flags { has_id = 0x1, has_shipping_options = 0x2 }
		public Flags flags;
		[IfFlag(0)] public string id;
		[IfFlag(1)] public ShippingOption[] shipping_options;
	}

	///<summary>See <a href="https://core.telegram.org/type/payments.PaymentResult"/></summary>
	public abstract partial class Payments_PaymentResultBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/payments.paymentResult"/></summary>
	[TLDef(0x4E5F810D)]
	public partial class Payments_PaymentResult : Payments_PaymentResultBase { public UpdatesBase updates; }
	///<summary>See <a href="https://core.telegram.org/constructor/payments.paymentVerificationNeeded"/></summary>
	[TLDef(0xD8411139)]
	public partial class Payments_PaymentVerificationNeeded : Payments_PaymentResultBase { public string url; }

	///<summary>See <a href="https://core.telegram.org/constructor/payments.paymentReceipt"/></summary>
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
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/payments.savedInfo"/></summary>
	[TLDef(0xFB8FE43C)]
	public partial class Payments_SavedInfo : ITLObject
	{
		[Flags] public enum Flags { has_saved_info = 0x1, has_saved_credentials = 0x2 }
		public Flags flags;
		[IfFlag(0)] public PaymentRequestedInfo saved_info;
	}

	///<summary>See <a href="https://core.telegram.org/type/InputPaymentCredentials"/></summary>
	public abstract partial class InputPaymentCredentialsBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPaymentCredentialsSaved"/></summary>
	[TLDef(0xC10EB2CF)]
	public partial class InputPaymentCredentialsSaved : InputPaymentCredentialsBase
	{
		public string id;
		public byte[] tmp_password;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputPaymentCredentials"/></summary>
	[TLDef(0x3417D728)]
	public partial class InputPaymentCredentials : InputPaymentCredentialsBase
	{
		[Flags] public enum Flags { save = 0x1 }
		public Flags flags;
		public DataJSON data;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputPaymentCredentialsApplePay"/></summary>
	[TLDef(0x0AA1C39F)]
	public partial class InputPaymentCredentialsApplePay : InputPaymentCredentialsBase { public DataJSON payment_data; }
	///<summary>See <a href="https://core.telegram.org/constructor/inputPaymentCredentialsGooglePay"/></summary>
	[TLDef(0x8AC32801)]
	public partial class InputPaymentCredentialsGooglePay : InputPaymentCredentialsBase { public DataJSON payment_token; }

	///<summary>See <a href="https://core.telegram.org/constructor/account.tmpPassword"/></summary>
	[TLDef(0xDB64FD34)]
	public partial class Account_TmpPassword : ITLObject
	{
		public byte[] tmp_password;
		public DateTime valid_until;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/shippingOption"/></summary>
	[TLDef(0xB6213CDF)]
	public partial class ShippingOption : ITLObject
	{
		public string id;
		public string title;
		public LabeledPrice[] prices;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/inputStickerSetItem"/></summary>
	[TLDef(0xFFA0A496)]
	public partial class InputStickerSetItem : ITLObject
	{
		[Flags] public enum Flags { has_mask_coords = 0x1 }
		public Flags flags;
		public InputDocumentBase document;
		public string emoji;
		[IfFlag(0)] public MaskCoords mask_coords;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/inputPhoneCall"/></summary>
	[TLDef(0x1E36FDED)]
	public partial class InputPhoneCall : ITLObject
	{
		public long id;
		public long access_hash;
	}

	///<summary>See <a href="https://core.telegram.org/type/PhoneCall"/></summary>
	public abstract partial class PhoneCallBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/phoneCallEmpty"/></summary>
	[TLDef(0x5366C915)]
	public partial class PhoneCallEmpty : PhoneCallBase { public long id; }
	///<summary>See <a href="https://core.telegram.org/constructor/phoneCallWaiting"/></summary>
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
	}
	///<summary>See <a href="https://core.telegram.org/constructor/phoneCallRequested"/></summary>
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
	}
	///<summary>See <a href="https://core.telegram.org/constructor/phoneCallAccepted"/></summary>
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
	}
	///<summary>See <a href="https://core.telegram.org/constructor/phoneCall"/></summary>
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
	}
	///<summary>See <a href="https://core.telegram.org/constructor/phoneCallDiscarded"/></summary>
	[TLDef(0x50CA4DE1)]
	public partial class PhoneCallDiscarded : PhoneCallBase
	{
		[Flags] public enum Flags { has_reason = 0x1, has_duration = 0x2, need_rating = 0x4, need_debug = 0x8, video = 0x40 }
		public Flags flags;
		public long id;
		[IfFlag(0)] public PhoneCallDiscardReason reason;
		[IfFlag(1)] public int duration;
	}

	///<summary>See <a href="https://core.telegram.org/type/PhoneConnection"/></summary>
	public abstract partial class PhoneConnectionBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/phoneConnection"/></summary>
	[TLDef(0x9D4C17C0)]
	public partial class PhoneConnection : PhoneConnectionBase
	{
		public long id;
		public string ip;
		public string ipv6;
		public int port;
		public byte[] peer_tag;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/phoneConnectionWebrtc"/></summary>
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
	}

	///<summary>See <a href="https://core.telegram.org/constructor/phoneCallProtocol"/></summary>
	[TLDef(0xFC878FC8)]
	public partial class PhoneCallProtocol : ITLObject
	{
		[Flags] public enum Flags { udp_p2p = 0x1, udp_reflector = 0x2 }
		public Flags flags;
		public int min_layer;
		public int max_layer;
		public string[] library_versions;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/phone.phoneCall"/></summary>
	[TLDef(0xEC82E140)]
	public partial class Phone_PhoneCall : ITLObject
	{
		public PhoneCallBase phone_call;
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/type/upload.CdnFile"/></summary>
	public abstract partial class Upload_CdnFileBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/upload.cdnFileReuploadNeeded"/></summary>
	[TLDef(0xEEA8E46E)]
	public partial class Upload_CdnFileReuploadNeeded : Upload_CdnFileBase { public byte[] request_token; }
	///<summary>See <a href="https://core.telegram.org/constructor/upload.cdnFile"/></summary>
	[TLDef(0xA99FCA4F)]
	public partial class Upload_CdnFile : Upload_CdnFileBase { public byte[] bytes; }

	///<summary>See <a href="https://core.telegram.org/constructor/cdnPublicKey"/></summary>
	[TLDef(0xC982EABA)]
	public partial class CdnPublicKey : ITLObject
	{
		public int dc_id;
		public string public_key;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/cdnConfig"/></summary>
	[TLDef(0x5725E40A)]
	public partial class CdnConfig : ITLObject { public CdnPublicKey[] public_keys; }

	///<summary>See <a href="https://core.telegram.org/type/LangPackString"/></summary>
	public abstract partial class LangPackStringBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/langPackString"/></summary>
	[TLDef(0xCAD181F6)]
	public partial class LangPackString : LangPackStringBase
	{
		public string key;
		public string value;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/langPackStringPluralized"/></summary>
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
	}
	///<summary>See <a href="https://core.telegram.org/constructor/langPackStringDeleted"/></summary>
	[TLDef(0x2979EEB2)]
	public partial class LangPackStringDeleted : LangPackStringBase { public string key; }

	///<summary>See <a href="https://core.telegram.org/constructor/langPackDifference"/></summary>
	[TLDef(0xF385C1F6)]
	public partial class LangPackDifference : ITLObject
	{
		public string lang_code;
		public int from_version;
		public int version;
		public LangPackStringBase[] strings;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/langPackLanguage"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/type/ChannelAdminLogEventAction"/></summary>
	public abstract partial class ChannelAdminLogEventAction : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionChangeTitle"/></summary>
	[TLDef(0xE6DFB825)]
	public partial class ChannelAdminLogEventActionChangeTitle : ChannelAdminLogEventAction
	{
		public string prev_value;
		public string new_value;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionChangeAbout"/></summary>
	[TLDef(0x55188A2E)]
	public partial class ChannelAdminLogEventActionChangeAbout : ChannelAdminLogEventAction
	{
		public string prev_value;
		public string new_value;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionChangeUsername"/></summary>
	[TLDef(0x6A4AFC38)]
	public partial class ChannelAdminLogEventActionChangeUsername : ChannelAdminLogEventAction
	{
		public string prev_value;
		public string new_value;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionChangePhoto"/></summary>
	[TLDef(0x434BD2AF)]
	public partial class ChannelAdminLogEventActionChangePhoto : ChannelAdminLogEventAction
	{
		public PhotoBase prev_photo;
		public PhotoBase new_photo;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionToggleInvites"/></summary>
	[TLDef(0x1B7907AE)]
	public partial class ChannelAdminLogEventActionToggleInvites : ChannelAdminLogEventAction { public bool new_value; }
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionToggleSignatures"/></summary>
	[TLDef(0x26AE0971)]
	public partial class ChannelAdminLogEventActionToggleSignatures : ChannelAdminLogEventAction { public bool new_value; }
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionUpdatePinned"/></summary>
	[TLDef(0xE9E82C18)]
	public partial class ChannelAdminLogEventActionUpdatePinned : ChannelAdminLogEventAction { public MessageBase message; }
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionEditMessage"/></summary>
	[TLDef(0x709B2405)]
	public partial class ChannelAdminLogEventActionEditMessage : ChannelAdminLogEventAction
	{
		public MessageBase prev_message;
		public MessageBase new_message;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionDeleteMessage"/></summary>
	[TLDef(0x42E047BB)]
	public partial class ChannelAdminLogEventActionDeleteMessage : ChannelAdminLogEventAction { public MessageBase message; }
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionParticipantJoin"/></summary>
	[TLDef(0x183040D3)]
	public partial class ChannelAdminLogEventActionParticipantJoin : ChannelAdminLogEventAction { }
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionParticipantLeave"/></summary>
	[TLDef(0xF89777F2)]
	public partial class ChannelAdminLogEventActionParticipantLeave : ChannelAdminLogEventAction { }
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionParticipantInvite"/></summary>
	[TLDef(0xE31C34D8)]
	public partial class ChannelAdminLogEventActionParticipantInvite : ChannelAdminLogEventAction { public ChannelParticipantBase participant; }
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionParticipantToggleBan"/></summary>
	[TLDef(0xE6D83D7E)]
	public partial class ChannelAdminLogEventActionParticipantToggleBan : ChannelAdminLogEventAction
	{
		public ChannelParticipantBase prev_participant;
		public ChannelParticipantBase new_participant;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionParticipantToggleAdmin"/></summary>
	[TLDef(0xD5676710)]
	public partial class ChannelAdminLogEventActionParticipantToggleAdmin : ChannelAdminLogEventAction
	{
		public ChannelParticipantBase prev_participant;
		public ChannelParticipantBase new_participant;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionChangeStickerSet"/></summary>
	[TLDef(0xB1C3CAA7)]
	public partial class ChannelAdminLogEventActionChangeStickerSet : ChannelAdminLogEventAction
	{
		public InputStickerSet prev_stickerset;
		public InputStickerSet new_stickerset;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionTogglePreHistoryHidden"/></summary>
	[TLDef(0x5F5C95F1)]
	public partial class ChannelAdminLogEventActionTogglePreHistoryHidden : ChannelAdminLogEventAction { public bool new_value; }
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionDefaultBannedRights"/></summary>
	[TLDef(0x2DF5FC0A)]
	public partial class ChannelAdminLogEventActionDefaultBannedRights : ChannelAdminLogEventAction
	{
		public ChatBannedRights prev_banned_rights;
		public ChatBannedRights new_banned_rights;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionStopPoll"/></summary>
	[TLDef(0x8F079643)]
	public partial class ChannelAdminLogEventActionStopPoll : ChannelAdminLogEventAction { public MessageBase message; }
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionChangeLinkedChat"/></summary>
	[TLDef(0x050C7AC8)]
	public partial class ChannelAdminLogEventActionChangeLinkedChat : ChannelAdminLogEventAction
	{
		public long prev_value;
		public long new_value;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionChangeLocation"/></summary>
	[TLDef(0x0E6B76AE)]
	public partial class ChannelAdminLogEventActionChangeLocation : ChannelAdminLogEventAction
	{
		public ChannelLocationBase prev_value;
		public ChannelLocationBase new_value;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionToggleSlowMode"/></summary>
	[TLDef(0x53909779)]
	public partial class ChannelAdminLogEventActionToggleSlowMode : ChannelAdminLogEventAction
	{
		public int prev_value;
		public int new_value;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionStartGroupCall"/></summary>
	[TLDef(0x23209745)]
	public partial class ChannelAdminLogEventActionStartGroupCall : ChannelAdminLogEventAction { public InputGroupCall call; }
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionDiscardGroupCall"/></summary>
	[TLDef(0xDB9F9140)]
	public partial class ChannelAdminLogEventActionDiscardGroupCall : ChannelAdminLogEventAction { public InputGroupCall call; }
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionParticipantMute"/></summary>
	[TLDef(0xF92424D2)]
	public partial class ChannelAdminLogEventActionParticipantMute : ChannelAdminLogEventAction { public GroupCallParticipant participant; }
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionParticipantUnmute"/></summary>
	[TLDef(0xE64429C0)]
	public partial class ChannelAdminLogEventActionParticipantUnmute : ChannelAdminLogEventAction { public GroupCallParticipant participant; }
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionToggleGroupCallSetting"/></summary>
	[TLDef(0x56D6A247)]
	public partial class ChannelAdminLogEventActionToggleGroupCallSetting : ChannelAdminLogEventAction { public bool join_muted; }
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionParticipantJoinByInvite"/></summary>
	[TLDef(0x5CDADA77)]
	public partial class ChannelAdminLogEventActionParticipantJoinByInvite : ChannelAdminLogEventAction { public ExportedChatInvite invite; }
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionExportedInviteDelete"/></summary>
	[TLDef(0x5A50FCA4)]
	public partial class ChannelAdminLogEventActionExportedInviteDelete : ChannelAdminLogEventAction { public ExportedChatInvite invite; }
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionExportedInviteRevoke"/></summary>
	[TLDef(0x410A134E)]
	public partial class ChannelAdminLogEventActionExportedInviteRevoke : ChannelAdminLogEventAction { public ExportedChatInvite invite; }
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionExportedInviteEdit"/></summary>
	[TLDef(0xE90EBB59)]
	public partial class ChannelAdminLogEventActionExportedInviteEdit : ChannelAdminLogEventAction
	{
		public ExportedChatInvite prev_invite;
		public ExportedChatInvite new_invite;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionParticipantVolume"/></summary>
	[TLDef(0x3E7F6847)]
	public partial class ChannelAdminLogEventActionParticipantVolume : ChannelAdminLogEventAction { public GroupCallParticipant participant; }
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionChangeHistoryTTL"/></summary>
	[TLDef(0x6E941A38)]
	public partial class ChannelAdminLogEventActionChangeHistoryTTL : ChannelAdminLogEventAction
	{
		public int prev_value;
		public int new_value;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventActionChangeTheme"/></summary>
	[TLDef(0xFE69018D)]
	public partial class ChannelAdminLogEventActionChangeTheme : ChannelAdminLogEventAction
	{
		public string prev_value;
		public string new_value;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEvent"/></summary>
	[TLDef(0x1FAD68CD)]
	public partial class ChannelAdminLogEvent : ITLObject
	{
		public long id;
		public DateTime date;
		public long user_id;
		public ChannelAdminLogEventAction action;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/channels.adminLogResults"/></summary>
	[TLDef(0xED8AF74D)]
	public partial class Channels_AdminLogResults : ITLObject
	{
		public ChannelAdminLogEvent[] events;
		public ChatBase[] chats;
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/channelAdminLogEventsFilter"/></summary>
	[TLDef(0xEA107AE4)]
	public partial class ChannelAdminLogEventsFilter : ITLObject
	{
		[Flags] public enum Flags { join = 0x1, leave = 0x2, invite = 0x4, ban = 0x8, unban = 0x10, kick = 0x20, unkick = 0x40, 
			promote = 0x80, demote = 0x100, info = 0x200, settings = 0x400, pinned = 0x800, edit = 0x1000, delete = 0x2000, 
			group_call = 0x4000, invites = 0x8000 }
		public Flags flags;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/popularContact"/></summary>
	[TLDef(0x5CE14175)]
	public partial class PopularContact : ITLObject
	{
		public long client_id;
		public int importers;
	}

	///<summary>See <a href="https://core.telegram.org/type/messages.FavedStickers"/></summary>
	public abstract partial class Messages_FavedStickersBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/messages.favedStickersNotModified"/></summary>
	[TLDef(0x9E8FA6D3)]
	public partial class Messages_FavedStickersNotModified : Messages_FavedStickersBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/messages.favedStickers"/></summary>
	[TLDef(0x2CB51097)]
	public partial class Messages_FavedStickers : Messages_FavedStickersBase
	{
		public long hash;
		public StickerPack[] packs;
		public DocumentBase[] stickers;
	}

	///<summary>See <a href="https://core.telegram.org/type/RecentMeUrl"/></summary>
	public abstract partial class RecentMeUrl : ITLObject { public string url; }
	///<summary>See <a href="https://core.telegram.org/constructor/recentMeUrlUnknown"/></summary>
	[TLDef(0x46E1D13D)]
	public partial class RecentMeUrlUnknown : RecentMeUrl { }
	///<summary>See <a href="https://core.telegram.org/constructor/recentMeUrlUser"/></summary>
	[TLDef(0xB92C09E2)]
	public partial class RecentMeUrlUser : RecentMeUrl { public long user_id; }
	///<summary>See <a href="https://core.telegram.org/constructor/recentMeUrlChat"/></summary>
	[TLDef(0xB2DA71D2)]
	public partial class RecentMeUrlChat : RecentMeUrl { public long chat_id; }
	///<summary>See <a href="https://core.telegram.org/constructor/recentMeUrlChatInvite"/></summary>
	[TLDef(0xEB49081D)]
	public partial class RecentMeUrlChatInvite : RecentMeUrl { public ChatInviteBase chat_invite; }
	///<summary>See <a href="https://core.telegram.org/constructor/recentMeUrlStickerSet"/></summary>
	[TLDef(0xBC0A57DC)]
	public partial class RecentMeUrlStickerSet : RecentMeUrl { public StickerSetCoveredBase set; }

	///<summary>See <a href="https://core.telegram.org/constructor/help.recentMeUrls"/></summary>
	[TLDef(0x0E0310D7)]
	public partial class Help_RecentMeUrls : ITLObject
	{
		public RecentMeUrl[] urls;
		public ChatBase[] chats;
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/inputSingleMedia"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/webAuthorization"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/account.webAuthorizations"/></summary>
	[TLDef(0xED56C9FC)]
	public partial class Account_WebAuthorizations : ITLObject
	{
		public WebAuthorization[] authorizations;
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/type/InputMessage"/></summary>
	public abstract partial class InputMessage : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputMessageID"/></summary>
	[TLDef(0xA676A322)]
	public partial class InputMessageID : InputMessage { public int id; }
	///<summary>See <a href="https://core.telegram.org/constructor/inputMessageReplyTo"/></summary>
	[TLDef(0xBAD88395)]
	public partial class InputMessageReplyTo : InputMessage { public int id; }
	///<summary>See <a href="https://core.telegram.org/constructor/inputMessagePinned"/></summary>
	[TLDef(0x86872538)]
	public partial class InputMessagePinned : InputMessage { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputMessageCallbackQuery"/></summary>
	[TLDef(0xACFA1A7E)]
	public partial class InputMessageCallbackQuery : InputMessage
	{
		public int id;
		public long query_id;
	}

	///<summary>See <a href="https://core.telegram.org/type/InputDialogPeer"/></summary>
	public abstract partial class InputDialogPeerBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputDialogPeer"/></summary>
	[TLDef(0xFCAAFEB7)]
	public partial class InputDialogPeer : InputDialogPeerBase { public InputPeer peer; }
	///<summary>See <a href="https://core.telegram.org/constructor/inputDialogPeerFolder"/></summary>
	[TLDef(0x64600527)]
	public partial class InputDialogPeerFolder : InputDialogPeerBase { public int folder_id; }

	///<summary>See <a href="https://core.telegram.org/type/DialogPeer"/></summary>
	public abstract partial class DialogPeerBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/dialogPeer"/></summary>
	[TLDef(0xE56DBF05)]
	public partial class DialogPeer : DialogPeerBase { public Peer peer; }
	///<summary>See <a href="https://core.telegram.org/constructor/dialogPeerFolder"/></summary>
	[TLDef(0x514519E2)]
	public partial class DialogPeerFolder : DialogPeerBase { public int folder_id; }

	///<summary>See <a href="https://core.telegram.org/type/messages.FoundStickerSets"/></summary>
	public abstract partial class Messages_FoundStickerSetsBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/messages.foundStickerSetsNotModified"/></summary>
	[TLDef(0x0D54B65D)]
	public partial class Messages_FoundStickerSetsNotModified : Messages_FoundStickerSetsBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/messages.foundStickerSets"/></summary>
	[TLDef(0x8AF09DD2)]
	public partial class Messages_FoundStickerSets : Messages_FoundStickerSetsBase
	{
		public long hash;
		public StickerSetCoveredBase[] sets;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/fileHash"/></summary>
	[TLDef(0x6242C773)]
	public partial class FileHash : ITLObject
	{
		public int offset;
		public int limit;
		public byte[] hash;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/inputClientProxy"/></summary>
	[TLDef(0x75588B3F)]
	public partial class InputClientProxy : ITLObject
	{
		public string address;
		public int port;
	}

	///<summary>See <a href="https://core.telegram.org/type/help.TermsOfServiceUpdate"/></summary>
	public abstract partial class Help_TermsOfServiceUpdateBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/help.termsOfServiceUpdateEmpty"/></summary>
	[TLDef(0xE3309F7F)]
	public partial class Help_TermsOfServiceUpdateEmpty : Help_TermsOfServiceUpdateBase { public DateTime expires; }
	///<summary>See <a href="https://core.telegram.org/constructor/help.termsOfServiceUpdate"/></summary>
	[TLDef(0x28ECF961)]
	public partial class Help_TermsOfServiceUpdate : Help_TermsOfServiceUpdateBase
	{
		public DateTime expires;
		public Help_TermsOfService terms_of_service;
	}

	///<summary>See <a href="https://core.telegram.org/type/InputSecureFile"/></summary>
	public abstract partial class InputSecureFileBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputSecureFileUploaded"/></summary>
	[TLDef(0x3334B0F0)]
	public partial class InputSecureFileUploaded : InputSecureFileBase
	{
		public long id;
		public int parts;
		public byte[] md5_checksum;
		public byte[] file_hash;
		public byte[] secret;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputSecureFile"/></summary>
	[TLDef(0x5367E5BE)]
	public partial class InputSecureFile : InputSecureFileBase
	{
		public long id;
		public long access_hash;
	}

	///<summary>See <a href="https://core.telegram.org/type/SecureFile"/></summary>
	public abstract partial class SecureFileBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/secureFileEmpty"/></summary>
	[TLDef(0x64199744)]
	public partial class SecureFileEmpty : SecureFileBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/secureFile"/></summary>
	[TLDef(0xE0277A62)]
	public partial class SecureFile : SecureFileBase
	{
		public long id;
		public long access_hash;
		public int size;
		public int dc_id;
		public DateTime date;
		public byte[] file_hash;
		public byte[] secret;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/secureData"/></summary>
	[TLDef(0x8AEABEC3)]
	public partial class SecureData : ITLObject
	{
		public byte[] data;
		public byte[] data_hash;
		public byte[] secret;
	}

	///<summary>See <a href="https://core.telegram.org/type/SecurePlainData"/></summary>
	public abstract partial class SecurePlainData : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/securePlainPhone"/></summary>
	[TLDef(0x7D6099DD)]
	public partial class SecurePlainPhone : SecurePlainData { public string phone; }
	///<summary>See <a href="https://core.telegram.org/constructor/securePlainEmail"/></summary>
	[TLDef(0x21EC5A5F)]
	public partial class SecurePlainEmail : SecurePlainData { public string email; }

	///<summary>See <a href="https://core.telegram.org/type/SecureValueType"/></summary>
	public abstract partial class SecureValueType : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/secureValueTypePersonalDetails"/></summary>
	[TLDef(0x9D2A81E3)]
	public partial class SecureValueTypePersonalDetails : SecureValueType { }
	///<summary>See <a href="https://core.telegram.org/constructor/secureValueTypePassport"/></summary>
	[TLDef(0x3DAC6A00)]
	public partial class SecureValueTypePassport : SecureValueType { }
	///<summary>See <a href="https://core.telegram.org/constructor/secureValueTypeDriverLicense"/></summary>
	[TLDef(0x06E425C4)]
	public partial class SecureValueTypeDriverLicense : SecureValueType { }
	///<summary>See <a href="https://core.telegram.org/constructor/secureValueTypeIdentityCard"/></summary>
	[TLDef(0xA0D0744B)]
	public partial class SecureValueTypeIdentityCard : SecureValueType { }
	///<summary>See <a href="https://core.telegram.org/constructor/secureValueTypeInternalPassport"/></summary>
	[TLDef(0x99A48F23)]
	public partial class SecureValueTypeInternalPassport : SecureValueType { }
	///<summary>See <a href="https://core.telegram.org/constructor/secureValueTypeAddress"/></summary>
	[TLDef(0xCBE31E26)]
	public partial class SecureValueTypeAddress : SecureValueType { }
	///<summary>See <a href="https://core.telegram.org/constructor/secureValueTypeUtilityBill"/></summary>
	[TLDef(0xFC36954E)]
	public partial class SecureValueTypeUtilityBill : SecureValueType { }
	///<summary>See <a href="https://core.telegram.org/constructor/secureValueTypeBankStatement"/></summary>
	[TLDef(0x89137C0D)]
	public partial class SecureValueTypeBankStatement : SecureValueType { }
	///<summary>See <a href="https://core.telegram.org/constructor/secureValueTypeRentalAgreement"/></summary>
	[TLDef(0x8B883488)]
	public partial class SecureValueTypeRentalAgreement : SecureValueType { }
	///<summary>See <a href="https://core.telegram.org/constructor/secureValueTypePassportRegistration"/></summary>
	[TLDef(0x99E3806A)]
	public partial class SecureValueTypePassportRegistration : SecureValueType { }
	///<summary>See <a href="https://core.telegram.org/constructor/secureValueTypeTemporaryRegistration"/></summary>
	[TLDef(0xEA02EC33)]
	public partial class SecureValueTypeTemporaryRegistration : SecureValueType { }
	///<summary>See <a href="https://core.telegram.org/constructor/secureValueTypePhone"/></summary>
	[TLDef(0xB320AADB)]
	public partial class SecureValueTypePhone : SecureValueType { }
	///<summary>See <a href="https://core.telegram.org/constructor/secureValueTypeEmail"/></summary>
	[TLDef(0x8E3CA7EE)]
	public partial class SecureValueTypeEmail : SecureValueType { }

	///<summary>See <a href="https://core.telegram.org/constructor/secureValue"/></summary>
	[TLDef(0x187FA0CA)]
	public partial class SecureValue : ITLObject
	{
		[Flags] public enum Flags { has_data = 0x1, has_front_side = 0x2, has_reverse_side = 0x4, has_selfie = 0x8, has_files = 0x10, 
			has_plain_data = 0x20, has_translation = 0x40 }
		public Flags flags;
		public SecureValueType type;
		[IfFlag(0)] public SecureData data;
		[IfFlag(1)] public SecureFileBase front_side;
		[IfFlag(2)] public SecureFileBase reverse_side;
		[IfFlag(3)] public SecureFileBase selfie;
		[IfFlag(6)] public SecureFileBase[] translation;
		[IfFlag(4)] public SecureFileBase[] files;
		[IfFlag(5)] public SecurePlainData plain_data;
		public byte[] hash;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/inputSecureValue"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/secureValueHash"/></summary>
	[TLDef(0xED1ECDB0)]
	public partial class SecureValueHash : ITLObject
	{
		public SecureValueType type;
		public byte[] hash;
	}

	///<summary>See <a href="https://core.telegram.org/type/SecureValueError"/></summary>
	public abstract partial class SecureValueErrorBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/secureValueErrorData"/></summary>
	[TLDef(0xE8A40BD9)]
	public partial class SecureValueErrorData : SecureValueErrorBase
	{
		public SecureValueType type;
		public byte[] data_hash;
		public string field;
		public string text;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/secureValueErrorFrontSide"/></summary>
	[TLDef(0x00BE3DFA)]
	public partial class SecureValueErrorFrontSide : SecureValueErrorBase
	{
		public SecureValueType type;
		public byte[] file_hash;
		public string text;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/secureValueErrorReverseSide"/></summary>
	[TLDef(0x868A2AA5)]
	public partial class SecureValueErrorReverseSide : SecureValueErrorBase
	{
		public SecureValueType type;
		public byte[] file_hash;
		public string text;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/secureValueErrorSelfie"/></summary>
	[TLDef(0xE537CED6)]
	public partial class SecureValueErrorSelfie : SecureValueErrorBase
	{
		public SecureValueType type;
		public byte[] file_hash;
		public string text;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/secureValueErrorFile"/></summary>
	[TLDef(0x7A700873)]
	public partial class SecureValueErrorFile : SecureValueErrorBase
	{
		public SecureValueType type;
		public byte[] file_hash;
		public string text;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/secureValueErrorFiles"/></summary>
	[TLDef(0x666220E9)]
	public partial class SecureValueErrorFiles : SecureValueErrorBase
	{
		public SecureValueType type;
		public byte[][] file_hash;
		public string text;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/secureValueError"/></summary>
	[TLDef(0x869D758F)]
	public partial class SecureValueError : SecureValueErrorBase
	{
		public SecureValueType type;
		public byte[] hash;
		public string text;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/secureValueErrorTranslationFile"/></summary>
	[TLDef(0xA1144770)]
	public partial class SecureValueErrorTranslationFile : SecureValueErrorBase
	{
		public SecureValueType type;
		public byte[] file_hash;
		public string text;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/secureValueErrorTranslationFiles"/></summary>
	[TLDef(0x34636DD8)]
	public partial class SecureValueErrorTranslationFiles : SecureValueErrorBase
	{
		public SecureValueType type;
		public byte[][] file_hash;
		public string text;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/secureCredentialsEncrypted"/></summary>
	[TLDef(0x33F0EA47)]
	public partial class SecureCredentialsEncrypted : ITLObject
	{
		public byte[] data;
		public byte[] hash;
		public byte[] secret;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/account.authorizationForm"/></summary>
	[TLDef(0xAD2E1CD8)]
	public partial class Account_AuthorizationForm : ITLObject
	{
		[Flags] public enum Flags { has_privacy_policy_url = 0x1 }
		public Flags flags;
		public SecureRequiredTypeBase[] required_types;
		public SecureValue[] values;
		public SecureValueErrorBase[] errors;
		public UserBase[] users;
		[IfFlag(0)] public string privacy_policy_url;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/account.sentEmailCode"/></summary>
	[TLDef(0x811F854F)]
	public partial class Account_SentEmailCode : ITLObject
	{
		public string email_pattern;
		public int length;
	}

	///<summary>See <a href="https://core.telegram.org/type/help.DeepLinkInfo"/></summary>
	public abstract partial class Help_DeepLinkInfoBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/help.deepLinkInfoEmpty"/></summary>
	[TLDef(0x66AFA166)]
	public partial class Help_DeepLinkInfoEmpty : Help_DeepLinkInfoBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/help.deepLinkInfo"/></summary>
	[TLDef(0x6A4EE832)]
	public partial class Help_DeepLinkInfo : Help_DeepLinkInfoBase
	{
		[Flags] public enum Flags { update_app = 0x1, has_entities = 0x2 }
		public Flags flags;
		public string message;
		[IfFlag(1)] public MessageEntity[] entities;
	}

	///<summary>See <a href="https://core.telegram.org/type/SavedContact"/></summary>
	public abstract partial class SavedContact : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/savedPhoneContact"/></summary>
	[TLDef(0x1142BD56)]
	public partial class SavedPhoneContact : SavedContact
	{
		public string phone;
		public string first_name;
		public string last_name;
		public DateTime date;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/account.takeout"/></summary>
	[TLDef(0x4DBA4501)]
	public partial class Account_Takeout : ITLObject { public long id; }

	///<summary>See <a href="https://core.telegram.org/type/PasswordKdfAlgo"/></summary>
	public abstract partial class PasswordKdfAlgo : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/passwordKdfAlgoUnknown"/></summary>
	[TLDef(0xD45AB096)]
	public partial class PasswordKdfAlgoUnknown : PasswordKdfAlgo { }
	///<summary>See <a href="https://core.telegram.org/constructor/passwordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow"/></summary>
	[TLDef(0x3A912D4A)]
	public partial class PasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow : PasswordKdfAlgo
	{
		public byte[] salt1;
		public byte[] salt2;
		public int g;
		public byte[] p;
	}

	///<summary>See <a href="https://core.telegram.org/type/SecurePasswordKdfAlgo"/></summary>
	public abstract partial class SecurePasswordKdfAlgo : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/securePasswordKdfAlgoUnknown"/></summary>
	[TLDef(0x004A8537)]
	public partial class SecurePasswordKdfAlgoUnknown : SecurePasswordKdfAlgo { }
	///<summary>See <a href="https://core.telegram.org/constructor/securePasswordKdfAlgoPBKDF2HMACSHA512iter100000"/></summary>
	[TLDef(0xBBF2DDA0)]
	public partial class SecurePasswordKdfAlgoPBKDF2HMACSHA512iter100000 : SecurePasswordKdfAlgo { public byte[] salt; }
	///<summary>See <a href="https://core.telegram.org/constructor/securePasswordKdfAlgoSHA512"/></summary>
	[TLDef(0x86471D92)]
	public partial class SecurePasswordKdfAlgoSHA512 : SecurePasswordKdfAlgo { public byte[] salt; }

	///<summary>See <a href="https://core.telegram.org/constructor/secureSecretSettings"/></summary>
	[TLDef(0x1527BCAC)]
	public partial class SecureSecretSettings : ITLObject
	{
		public SecurePasswordKdfAlgo secure_algo;
		public byte[] secure_secret;
		public long secure_secret_id;
	}

	///<summary>See <a href="https://core.telegram.org/type/InputCheckPasswordSRP"/></summary>
	public abstract partial class InputCheckPasswordSRPBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputCheckPasswordEmpty"/></summary>
	[TLDef(0x9880F658)]
	public partial class InputCheckPasswordEmpty : InputCheckPasswordSRPBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputCheckPasswordSRP"/></summary>
	[TLDef(0xD27FF082)]
	public partial class InputCheckPasswordSRP : InputCheckPasswordSRPBase
	{
		public long srp_id;
		public byte[] A;
		public byte[] M1;
	}

	///<summary>See <a href="https://core.telegram.org/type/SecureRequiredType"/></summary>
	public abstract partial class SecureRequiredTypeBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/secureRequiredType"/></summary>
	[TLDef(0x829D99DA)]
	public partial class SecureRequiredType : SecureRequiredTypeBase
	{
		[Flags] public enum Flags { native_names = 0x1, selfie_required = 0x2, translation_required = 0x4 }
		public Flags flags;
		public SecureValueType type;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/secureRequiredTypeOneOf"/></summary>
	[TLDef(0x027477B4)]
	public partial class SecureRequiredTypeOneOf : SecureRequiredTypeBase { public SecureRequiredTypeBase[] types; }

	///<summary>See <a href="https://core.telegram.org/type/help.PassportConfig"/></summary>
	public abstract partial class Help_PassportConfigBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/help.passportConfigNotModified"/></summary>
	[TLDef(0xBFB9F457)]
	public partial class Help_PassportConfigNotModified : Help_PassportConfigBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/help.passportConfig"/></summary>
	[TLDef(0xA098D6AF)]
	public partial class Help_PassportConfig : Help_PassportConfigBase
	{
		public int hash;
		public DataJSON countries_langs;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/inputAppEvent"/></summary>
	[TLDef(0x1D1B1245)]
	public partial class InputAppEvent : ITLObject
	{
		public double time;
		public string type;
		public long peer;
		public JSONValue data;
	}

	///<summary>See <a href="https://core.telegram.org/type/JSONObjectValue"/></summary>
	public abstract partial class JSONObjectValue : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/jsonObjectValue"/></summary>
	[TLDef(0xC0DE1BD9)]
	public partial class JsonObjectValue : JSONObjectValue
	{
		public string key;
		public JSONValue value;
	}

	///<summary>See <a href="https://core.telegram.org/type/JSONValue"/></summary>
	public abstract partial class JSONValue : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/jsonNull"/></summary>
	[TLDef(0x3F6D7B68)]
	public partial class JsonNull : JSONValue { }
	///<summary>See <a href="https://core.telegram.org/constructor/jsonBool"/></summary>
	[TLDef(0xC7345E6A)]
	public partial class JsonBool : JSONValue { public bool value; }
	///<summary>See <a href="https://core.telegram.org/constructor/jsonNumber"/></summary>
	[TLDef(0x2BE0DFA4)]
	public partial class JsonNumber : JSONValue { public double value; }
	///<summary>See <a href="https://core.telegram.org/constructor/jsonString"/></summary>
	[TLDef(0xB71E767A)]
	public partial class JsonString : JSONValue { public string value; }
	///<summary>See <a href="https://core.telegram.org/constructor/jsonArray"/></summary>
	[TLDef(0xF7444763)]
	public partial class JsonArray : JSONValue { public JSONValue[] value; }
	///<summary>See <a href="https://core.telegram.org/constructor/jsonObject"/></summary>
	[TLDef(0x99C1D49D)]
	public partial class JsonObject : JSONValue { public JSONObjectValue[] value; }

	///<summary>See <a href="https://core.telegram.org/constructor/pageTableCell"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/pageTableRow"/></summary>
	[TLDef(0xE0C0C5E5)]
	public partial class PageTableRow : ITLObject { public PageTableCell[] cells; }

	///<summary>See <a href="https://core.telegram.org/constructor/pageCaption"/></summary>
	[TLDef(0x6F747657)]
	public partial class PageCaption : ITLObject
	{
		public RichText text;
		public RichText credit;
	}

	///<summary>See <a href="https://core.telegram.org/type/PageListItem"/></summary>
	public abstract partial class PageListItem : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/pageListItemText"/></summary>
	[TLDef(0xB92FB6CD)]
	public partial class PageListItemText : PageListItem { public RichText text; }
	///<summary>See <a href="https://core.telegram.org/constructor/pageListItemBlocks"/></summary>
	[TLDef(0x25E073FC)]
	public partial class PageListItemBlocks : PageListItem { public PageBlock[] blocks; }

	///<summary>See <a href="https://core.telegram.org/type/PageListOrderedItem"/></summary>
	public abstract partial class PageListOrderedItem : ITLObject { public string num; }
	///<summary>See <a href="https://core.telegram.org/constructor/pageListOrderedItemText"/></summary>
	[TLDef(0x5E068047)]
	public partial class PageListOrderedItemText : PageListOrderedItem { public RichText text; }
	///<summary>See <a href="https://core.telegram.org/constructor/pageListOrderedItemBlocks"/></summary>
	[TLDef(0x98DD8936)]
	public partial class PageListOrderedItemBlocks : PageListOrderedItem { public PageBlock[] blocks; }

	///<summary>See <a href="https://core.telegram.org/constructor/pageRelatedArticle"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/page"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/help.supportName"/></summary>
	[TLDef(0x8C05F1C9)]
	public partial class Help_SupportName : ITLObject { public string name; }

	///<summary>See <a href="https://core.telegram.org/type/help.UserInfo"/></summary>
	public abstract partial class Help_UserInfoBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/help.userInfoEmpty"/></summary>
	[TLDef(0xF3AE2EED)]
	public partial class Help_UserInfoEmpty : Help_UserInfoBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/help.userInfo"/></summary>
	[TLDef(0x01EB3758)]
	public partial class Help_UserInfo : Help_UserInfoBase
	{
		public string message;
		public MessageEntity[] entities;
		public string author;
		public DateTime date;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/pollAnswer"/></summary>
	[TLDef(0x6CA9C2E9)]
	public partial class PollAnswer : ITLObject
	{
		public string text;
		public byte[] option;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/poll"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/pollAnswerVoters"/></summary>
	[TLDef(0x3B6DDAD2)]
	public partial class PollAnswerVoters : ITLObject
	{
		[Flags] public enum Flags { chosen = 0x1, correct = 0x2 }
		public Flags flags;
		public byte[] option;
		public int voters;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/pollResults"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/chatOnlines"/></summary>
	[TLDef(0xF041E250)]
	public partial class ChatOnlines : ITLObject { public int onlines; }

	///<summary>See <a href="https://core.telegram.org/constructor/statsURL"/></summary>
	[TLDef(0x47A971E0)]
	public partial class StatsURL : ITLObject { public string url; }

	///<summary>See <a href="https://core.telegram.org/constructor/chatAdminRights"/></summary>
	[TLDef(0x5FB224D5)]
	public partial class ChatAdminRights : ITLObject
	{
		[Flags] public enum Flags { change_info = 0x1, post_messages = 0x2, edit_messages = 0x4, delete_messages = 0x8, 
			ban_users = 0x10, invite_users = 0x20, pin_messages = 0x80, add_admins = 0x200, anonymous = 0x400, manage_call = 0x800, 
			other = 0x1000 }
		public Flags flags;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/chatBannedRights"/></summary>
	[TLDef(0x9F120418)]
	public partial class ChatBannedRights : ITLObject
	{
		[Flags] public enum Flags { view_messages = 0x1, send_messages = 0x2, send_media = 0x4, send_stickers = 0x8, send_gifs = 0x10, 
			send_games = 0x20, send_inline = 0x40, embed_links = 0x80, send_polls = 0x100, change_info = 0x400, invite_users = 0x8000, 
			pin_messages = 0x20000 }
		public Flags flags;
		public DateTime until_date;
	}

	///<summary>See <a href="https://core.telegram.org/type/InputWallPaper"/></summary>
	public abstract partial class InputWallPaperBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputWallPaper"/></summary>
	[TLDef(0xE630B979)]
	public partial class InputWallPaper : InputWallPaperBase
	{
		public long id;
		public long access_hash;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputWallPaperSlug"/></summary>
	[TLDef(0x72091C80)]
	public partial class InputWallPaperSlug : InputWallPaperBase { public string slug; }
	///<summary>See <a href="https://core.telegram.org/constructor/inputWallPaperNoFile"/></summary>
	[TLDef(0x967A462E)]
	public partial class InputWallPaperNoFile : InputWallPaperBase { public long id; }

	///<summary>See <a href="https://core.telegram.org/type/account.WallPapers"/></summary>
	public abstract partial class Account_WallPapersBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/account.wallPapersNotModified"/></summary>
	[TLDef(0x1C199183)]
	public partial class Account_WallPapersNotModified : Account_WallPapersBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/account.wallPapers"/></summary>
	[TLDef(0xCDC3858C)]
	public partial class Account_WallPapers : Account_WallPapersBase
	{
		public long hash;
		public WallPaperBase[] wallpapers;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/codeSettings"/></summary>
	[TLDef(0xDEBEBE83)]
	public partial class CodeSettings : ITLObject
	{
		[Flags] public enum Flags { allow_flashcall = 0x1, current_number = 0x2, allow_app_hash = 0x10 }
		public Flags flags;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/wallPaperSettings"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/autoDownloadSettings"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/account.autoDownloadSettings"/></summary>
	[TLDef(0x63CACF26)]
	public partial class Account_AutoDownloadSettings : ITLObject
	{
		public AutoDownloadSettings low;
		public AutoDownloadSettings medium;
		public AutoDownloadSettings high;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/emojiKeyword"/></summary>
	[TLDef(0xD5B3B9F9)]
	public partial class EmojiKeyword : ITLObject
	{
		public string keyword;
		public string[] emoticons;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/emojiKeywordDeleted"/></summary>
	[TLDef(0x236DF622)]
	public partial class EmojiKeywordDeleted : EmojiKeyword { }

	///<summary>See <a href="https://core.telegram.org/constructor/emojiKeywordsDifference"/></summary>
	[TLDef(0x5CC761BD)]
	public partial class EmojiKeywordsDifference : ITLObject
	{
		public string lang_code;
		public int from_version;
		public int version;
		public EmojiKeyword[] keywords;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/emojiURL"/></summary>
	[TLDef(0xA575739D)]
	public partial class EmojiURL : ITLObject { public string url; }

	///<summary>See <a href="https://core.telegram.org/constructor/emojiLanguage"/></summary>
	[TLDef(0xB3FB5361)]
	public partial class EmojiLanguage : ITLObject { public string lang_code; }

	///<summary>See <a href="https://core.telegram.org/constructor/folder"/></summary>
	[TLDef(0xFF544E65)]
	public partial class Folder : ITLObject
	{
		[Flags] public enum Flags { autofill_new_broadcasts = 0x1, autofill_public_groups = 0x2, autofill_new_correspondents = 0x4, 
			has_photo = 0x8 }
		public Flags flags;
		public int id;
		public string title;
		[IfFlag(3)] public ChatPhotoBase photo;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/inputFolderPeer"/></summary>
	[TLDef(0xFBD2C296)]
	public partial class InputFolderPeer : ITLObject
	{
		public InputPeer peer;
		public int folder_id;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/folderPeer"/></summary>
	[TLDef(0xE9BAA668)]
	public partial class FolderPeer : ITLObject
	{
		public Peer peer;
		public int folder_id;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/messages.searchCounter"/></summary>
	[TLDef(0xE844EBFF)]
	public partial class Messages_SearchCounter : ITLObject
	{
		[Flags] public enum Flags { inexact = 0x2 }
		public Flags flags;
		public MessagesFilter filter;
		public int count;
	}

	///<summary>See <a href="https://core.telegram.org/type/UrlAuthResult"/></summary>
	public abstract partial class UrlAuthResult : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/urlAuthResultRequest"/></summary>
	[TLDef(0x92D33A0E)]
	public partial class UrlAuthResultRequest : UrlAuthResult
	{
		[Flags] public enum Flags { request_write_access = 0x1 }
		public Flags flags;
		public UserBase bot;
		public string domain;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/urlAuthResultAccepted"/></summary>
	[TLDef(0x8F8C0E4E)]
	public partial class UrlAuthResultAccepted : UrlAuthResult { public string url; }
	///<summary>See <a href="https://core.telegram.org/constructor/urlAuthResultDefault"/></summary>
	[TLDef(0xA9D6DB1F)]
	public partial class UrlAuthResultDefault : UrlAuthResult { }

	///<summary>See <a href="https://core.telegram.org/type/ChannelLocation"/></summary>
	public abstract partial class ChannelLocationBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/channelLocationEmpty"/></summary>
	[TLDef(0xBFB5AD8B)]
	public partial class ChannelLocationEmpty : ChannelLocationBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/channelLocation"/></summary>
	[TLDef(0x209B82DB)]
	public partial class ChannelLocation : ChannelLocationBase
	{
		public GeoPointBase geo_point;
		public string address;
	}

	///<summary>See <a href="https://core.telegram.org/type/PeerLocated"/></summary>
	public abstract partial class PeerLocatedBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/peerLocated"/></summary>
	[TLDef(0xCA461B5D)]
	public partial class PeerLocated : PeerLocatedBase
	{
		public Peer peer;
		public DateTime expires;
		public int distance;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/peerSelfLocated"/></summary>
	[TLDef(0xF8EC284B)]
	public partial class PeerSelfLocated : PeerLocatedBase { public DateTime expires; }

	///<summary>See <a href="https://core.telegram.org/constructor/restrictionReason"/></summary>
	[TLDef(0xD072ACB4)]
	public partial class RestrictionReason : ITLObject
	{
		public string platform;
		public string reason;
		public string text;
	}

	///<summary>See <a href="https://core.telegram.org/type/InputTheme"/></summary>
	public abstract partial class InputThemeBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inputTheme"/></summary>
	[TLDef(0x3C5693E9)]
	public partial class InputTheme : InputThemeBase
	{
		public long id;
		public long access_hash;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/inputThemeSlug"/></summary>
	[TLDef(0xF5890DF1)]
	public partial class InputThemeSlug : InputThemeBase { public string slug; }

	///<summary>See <a href="https://core.telegram.org/constructor/theme"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/type/account.Themes"/></summary>
	public abstract partial class Account_ThemesBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/account.themesNotModified"/></summary>
	[TLDef(0xF41EB622)]
	public partial class Account_ThemesNotModified : Account_ThemesBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/account.themes"/></summary>
	[TLDef(0x9A3D8C6D)]
	public partial class Account_Themes : Account_ThemesBase
	{
		public long hash;
		public Theme[] themes;
	}

	///<summary>See <a href="https://core.telegram.org/type/auth.LoginToken"/></summary>
	public abstract partial class Auth_LoginTokenBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/auth.loginToken"/></summary>
	[TLDef(0x629F1980)]
	public partial class Auth_LoginToken : Auth_LoginTokenBase
	{
		public DateTime expires;
		public byte[] token;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/auth.loginTokenMigrateTo"/></summary>
	[TLDef(0x068E9916)]
	public partial class Auth_LoginTokenMigrateTo : Auth_LoginTokenBase
	{
		public int dc_id;
		public byte[] token;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/auth.loginTokenSuccess"/></summary>
	[TLDef(0x390D5C5E)]
	public partial class Auth_LoginTokenSuccess : Auth_LoginTokenBase { public Auth_AuthorizationBase authorization; }

	///<summary>See <a href="https://core.telegram.org/constructor/account.contentSettings"/></summary>
	[TLDef(0x57E28221)]
	public partial class Account_ContentSettings : ITLObject
	{
		[Flags] public enum Flags { sensitive_enabled = 0x1, sensitive_can_change = 0x2 }
		public Flags flags;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/messages.inactiveChats"/></summary>
	[TLDef(0xA927FEC5)]
	public partial class Messages_InactiveChats : ITLObject
	{
		public int[] dates;
		public ChatBase[] chats;
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/type/BaseTheme"/></summary>
	public abstract partial class BaseTheme : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/baseThemeClassic"/></summary>
	[TLDef(0xC3A12462)]
	public partial class BaseThemeClassic : BaseTheme { }
	///<summary>See <a href="https://core.telegram.org/constructor/baseThemeDay"/></summary>
	[TLDef(0xFBD81688)]
	public partial class BaseThemeDay : BaseTheme { }
	///<summary>See <a href="https://core.telegram.org/constructor/baseThemeNight"/></summary>
	[TLDef(0xB7B31EA8)]
	public partial class BaseThemeNight : BaseTheme { }
	///<summary>See <a href="https://core.telegram.org/constructor/baseThemeTinted"/></summary>
	[TLDef(0x6D5F77EE)]
	public partial class BaseThemeTinted : BaseTheme { }
	///<summary>See <a href="https://core.telegram.org/constructor/baseThemeArctic"/></summary>
	[TLDef(0x5B11125A)]
	public partial class BaseThemeArctic : BaseTheme { }

	///<summary>See <a href="https://core.telegram.org/constructor/inputThemeSettings"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/themeSettings"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/type/WebPageAttribute"/></summary>
	public abstract partial class WebPageAttribute : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/webPageAttributeTheme"/></summary>
	[TLDef(0x54B56617)]
	public partial class WebPageAttributeTheme : WebPageAttribute
	{
		[Flags] public enum Flags { has_documents = 0x1, has_settings = 0x2 }
		public Flags flags;
		[IfFlag(0)] public DocumentBase[] documents;
		[IfFlag(1)] public ThemeSettings settings;
	}

	///<summary>See <a href="https://core.telegram.org/type/MessageUserVote"/></summary>
	public abstract partial class MessageUserVoteBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/messageUserVote"/></summary>
	[TLDef(0x34D247B4)]
	public partial class MessageUserVote : MessageUserVoteBase
	{
		public long user_id;
		public byte[] option;
		public DateTime date;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messageUserVoteInputOption"/></summary>
	[TLDef(0x3CA5B0EC)]
	public partial class MessageUserVoteInputOption : MessageUserVoteBase
	{
		public long user_id;
		public DateTime date;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messageUserVoteMultiple"/></summary>
	[TLDef(0x8A65E557)]
	public partial class MessageUserVoteMultiple : MessageUserVoteBase
	{
		public long user_id;
		public byte[][] options;
		public DateTime date;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/messages.votesList"/></summary>
	[TLDef(0x0823F649)]
	public partial class Messages_VotesList : ITLObject
	{
		[Flags] public enum Flags { has_next_offset = 0x1 }
		public Flags flags;
		public int count;
		public MessageUserVoteBase[] votes;
		public UserBase[] users;
		[IfFlag(0)] public string next_offset;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/bankCardOpenUrl"/></summary>
	[TLDef(0xF568028A)]
	public partial class BankCardOpenUrl : ITLObject
	{
		public string url;
		public string name;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/payments.bankCardData"/></summary>
	[TLDef(0x3E24E573)]
	public partial class Payments_BankCardData : ITLObject
	{
		public string title;
		public BankCardOpenUrl[] open_urls;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/dialogFilter"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/dialogFilterSuggested"/></summary>
	[TLDef(0x77744D4A)]
	public partial class DialogFilterSuggested : ITLObject
	{
		public DialogFilter filter;
		public string description;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/statsDateRangeDays"/></summary>
	[TLDef(0xB637EDAF)]
	public partial class StatsDateRangeDays : ITLObject
	{
		public DateTime min_date;
		public DateTime max_date;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/statsAbsValueAndPrev"/></summary>
	[TLDef(0xCB43ACDE)]
	public partial class StatsAbsValueAndPrev : ITLObject
	{
		public double current;
		public double previous;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/statsPercentValue"/></summary>
	[TLDef(0xCBCE2FE0)]
	public partial class StatsPercentValue : ITLObject
	{
		public double part;
		public double total;
	}

	///<summary>See <a href="https://core.telegram.org/type/StatsGraph"/></summary>
	public abstract partial class StatsGraphBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/statsGraphAsync"/></summary>
	[TLDef(0x4A27EB2D)]
	public partial class StatsGraphAsync : StatsGraphBase { public string token; }
	///<summary>See <a href="https://core.telegram.org/constructor/statsGraphError"/></summary>
	[TLDef(0xBEDC9822)]
	public partial class StatsGraphError : StatsGraphBase { public string error; }
	///<summary>See <a href="https://core.telegram.org/constructor/statsGraph"/></summary>
	[TLDef(0x8EA464B6)]
	public partial class StatsGraph : StatsGraphBase
	{
		[Flags] public enum Flags { has_zoom_token = 0x1 }
		public Flags flags;
		public DataJSON json;
		[IfFlag(0)] public string zoom_token;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/messageInteractionCounters"/></summary>
	[TLDef(0xAD4FC9BD)]
	public partial class MessageInteractionCounters : ITLObject
	{
		public int msg_id;
		public int views;
		public int forwards;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/stats.broadcastStats"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/type/help.PromoData"/></summary>
	public abstract partial class Help_PromoDataBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/help.promoDataEmpty"/></summary>
	[TLDef(0x98F6AC75)]
	public partial class Help_PromoDataEmpty : Help_PromoDataBase { public DateTime expires; }
	///<summary>See <a href="https://core.telegram.org/constructor/help.promoData"/></summary>
	[TLDef(0x8C39793F)]
	public partial class Help_PromoData : Help_PromoDataBase
	{
		[Flags] public enum Flags { proxy = 0x1, has_psa_type = 0x2, has_psa_message = 0x4 }
		public Flags flags;
		public DateTime expires;
		public Peer peer;
		public ChatBase[] chats;
		public UserBase[] users;
		[IfFlag(1)] public string psa_type;
		[IfFlag(2)] public string psa_message;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/videoSize"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/statsGroupTopPoster"/></summary>
	[TLDef(0x9D04AF9B)]
	public partial class StatsGroupTopPoster : ITLObject
	{
		public long user_id;
		public int messages;
		public int avg_chars;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/statsGroupTopAdmin"/></summary>
	[TLDef(0xD7584C87)]
	public partial class StatsGroupTopAdmin : ITLObject
	{
		public long user_id;
		public int deleted;
		public int kicked;
		public int banned;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/statsGroupTopInviter"/></summary>
	[TLDef(0x535F779D)]
	public partial class StatsGroupTopInviter : ITLObject
	{
		public long user_id;
		public int invitations;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/stats.megagroupStats"/></summary>
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
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/globalPrivacySettings"/></summary>
	[TLDef(0xBEA2F424)]
	public partial class GlobalPrivacySettings : ITLObject
	{
		[Flags] public enum Flags { has_archive_and_mute_new_noncontact_peers = 0x1 }
		public Flags flags;
		[IfFlag(0)] public bool archive_and_mute_new_noncontact_peers;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/help.countryCode"/></summary>
	[TLDef(0x4203C5EF)]
	public partial class Help_CountryCode : ITLObject
	{
		[Flags] public enum Flags { has_prefixes = 0x1, has_patterns = 0x2 }
		public Flags flags;
		public string country_code;
		[IfFlag(0)] public string[] prefixes;
		[IfFlag(1)] public string[] patterns;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/help.country"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/type/help.CountriesList"/></summary>
	public abstract partial class Help_CountriesListBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/help.countriesListNotModified"/></summary>
	[TLDef(0x93CC1F32)]
	public partial class Help_CountriesListNotModified : Help_CountriesListBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/help.countriesList"/></summary>
	[TLDef(0x87D0759E)]
	public partial class Help_CountriesList : Help_CountriesListBase
	{
		public Help_Country[] countries;
		public int hash;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/messageViews"/></summary>
	[TLDef(0x455B853D)]
	public partial class MessageViews : ITLObject
	{
		[Flags] public enum Flags { has_views = 0x1, has_forwards = 0x2, has_replies = 0x4 }
		public Flags flags;
		[IfFlag(0)] public int views;
		[IfFlag(1)] public int forwards;
		[IfFlag(2)] public MessageReplies replies;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/messages.messageViews"/></summary>
	[TLDef(0xB6C4F543)]
	public partial class Messages_MessageViews : ITLObject
	{
		public MessageViews[] views;
		public ChatBase[] chats;
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/messages.discussionMessage"/></summary>
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
		public ChatBase[] chats;
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/messageReplyHeader"/></summary>
	[TLDef(0xA6D57763)]
	public partial class MessageReplyHeader : ITLObject
	{
		[Flags] public enum Flags { has_reply_to_peer_id = 0x1, has_reply_to_top_id = 0x2 }
		public Flags flags;
		public int reply_to_msg_id;
		[IfFlag(0)] public Peer reply_to_peer_id;
		[IfFlag(1)] public int reply_to_top_id;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/messageReplies"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/peerBlocked"/></summary>
	[TLDef(0xE8FD8014)]
	public partial class PeerBlocked : ITLObject
	{
		public Peer peer_id;
		public DateTime date;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/stats.messageStats"/></summary>
	[TLDef(0x8999F295)]
	public partial class Stats_MessageStats : ITLObject { public StatsGraphBase views_graph; }

	///<summary>See <a href="https://core.telegram.org/type/GroupCall"/></summary>
	public abstract partial class GroupCallBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/groupCallDiscarded"/></summary>
	[TLDef(0x7780BCB4)]
	public partial class GroupCallDiscarded : GroupCallBase
	{
		public long id;
		public long access_hash;
		public int duration;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/groupCall"/></summary>
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
	}

	///<summary>See <a href="https://core.telegram.org/constructor/inputGroupCall"/></summary>
	[TLDef(0xD8AA840F)]
	public partial class InputGroupCall : ITLObject
	{
		public long id;
		public long access_hash;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/groupCallParticipant"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/phone.groupCall"/></summary>
	[TLDef(0x9E727AAD)]
	public partial class Phone_GroupCall : ITLObject
	{
		public GroupCallBase call;
		public GroupCallParticipant[] participants;
		public string participants_next_offset;
		public ChatBase[] chats;
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/phone.groupParticipants"/></summary>
	[TLDef(0xF47751B6)]
	public partial class Phone_GroupParticipants : ITLObject
	{
		public int count;
		public GroupCallParticipant[] participants;
		public string next_offset;
		public ChatBase[] chats;
		public UserBase[] users;
		public int version;
	}

	///<summary>See <a href="https://core.telegram.org/type/InlineQueryPeerType"/></summary>
	public abstract partial class InlineQueryPeerType : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/inlineQueryPeerTypeSameBotPM"/></summary>
	[TLDef(0x3081ED9D)]
	public partial class InlineQueryPeerTypeSameBotPM : InlineQueryPeerType { }
	///<summary>See <a href="https://core.telegram.org/constructor/inlineQueryPeerTypePM"/></summary>
	[TLDef(0x833C0FAC)]
	public partial class InlineQueryPeerTypePM : InlineQueryPeerType { }
	///<summary>See <a href="https://core.telegram.org/constructor/inlineQueryPeerTypeChat"/></summary>
	[TLDef(0xD766C50A)]
	public partial class InlineQueryPeerTypeChat : InlineQueryPeerType { }
	///<summary>See <a href="https://core.telegram.org/constructor/inlineQueryPeerTypeMegagroup"/></summary>
	[TLDef(0x5EC4BE43)]
	public partial class InlineQueryPeerTypeMegagroup : InlineQueryPeerType { }
	///<summary>See <a href="https://core.telegram.org/constructor/inlineQueryPeerTypeBroadcast"/></summary>
	[TLDef(0x6334EE9A)]
	public partial class InlineQueryPeerTypeBroadcast : InlineQueryPeerType { }

	///<summary>See <a href="https://core.telegram.org/constructor/messages.historyImport"/></summary>
	[TLDef(0x1662AF0B)]
	public partial class Messages_HistoryImport : ITLObject { public long id; }

	///<summary>See <a href="https://core.telegram.org/constructor/messages.historyImportParsed"/></summary>
	[TLDef(0x5E0FB7B9)]
	public partial class Messages_HistoryImportParsed : ITLObject
	{
		[Flags] public enum Flags { pm = 0x1, group = 0x2, has_title = 0x4 }
		public Flags flags;
		[IfFlag(2)] public string title;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/messages.affectedFoundMessages"/></summary>
	[TLDef(0xEF8D3E6C)]
	public partial class Messages_AffectedFoundMessages : ITLObject
	{
		public int pts;
		public int pts_count;
		public int offset;
		public int[] messages;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/chatInviteImporter"/></summary>
	[TLDef(0x0B5CD5F4)]
	public partial class ChatInviteImporter : ITLObject
	{
		public long user_id;
		public DateTime date;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/messages.exportedChatInvites"/></summary>
	[TLDef(0xBDC62DCC)]
	public partial class Messages_ExportedChatInvites : ITLObject
	{
		public int count;
		public ExportedChatInvite[] invites;
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/type/messages.ExportedChatInvite"/></summary>
	public abstract partial class Messages_ExportedChatInviteBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/messages.exportedChatInvite"/></summary>
	[TLDef(0x1871BE50)]
	public partial class Messages_ExportedChatInvite : Messages_ExportedChatInviteBase
	{
		public ExportedChatInvite invite;
		public UserBase[] users;
	}
	///<summary>See <a href="https://core.telegram.org/constructor/messages.exportedChatInviteReplaced"/></summary>
	[TLDef(0x222600EF)]
	public partial class Messages_ExportedChatInviteReplaced : Messages_ExportedChatInviteBase
	{
		public ExportedChatInvite invite;
		public ExportedChatInvite new_invite;
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/messages.chatInviteImporters"/></summary>
	[TLDef(0x81B6B00A)]
	public partial class Messages_ChatInviteImporters : ITLObject
	{
		public int count;
		public ChatInviteImporter[] importers;
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/chatAdminWithInvites"/></summary>
	[TLDef(0xF2ECEF23)]
	public partial class ChatAdminWithInvites : ITLObject
	{
		public long admin_id;
		public int invites_count;
		public int revoked_invites_count;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/messages.chatAdminsWithInvites"/></summary>
	[TLDef(0xB69B72D7)]
	public partial class Messages_ChatAdminsWithInvites : ITLObject
	{
		public ChatAdminWithInvites[] admins;
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/messages.checkedHistoryImportPeer"/></summary>
	[TLDef(0xA24DE717)]
	public partial class Messages_CheckedHistoryImportPeer : ITLObject { public string confirm_text; }

	///<summary>See <a href="https://core.telegram.org/constructor/phone.joinAsPeers"/></summary>
	[TLDef(0xAFE5623F)]
	public partial class Phone_JoinAsPeers : ITLObject
	{
		public Peer[] peers;
		public ChatBase[] chats;
		public UserBase[] users;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/phone.exportedGroupCallInvite"/></summary>
	[TLDef(0x204BD158)]
	public partial class Phone_ExportedGroupCallInvite : ITLObject { public string link; }

	///<summary>See <a href="https://core.telegram.org/constructor/groupCallParticipantVideoSourceGroup"/></summary>
	[TLDef(0xDCB118B7)]
	public partial class GroupCallParticipantVideoSourceGroup : ITLObject
	{
		public string semantics;
		public int[] sources;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/groupCallParticipantVideo"/></summary>
	[TLDef(0x67753AC8)]
	public partial class GroupCallParticipantVideo : ITLObject
	{
		[Flags] public enum Flags { paused = 0x1, has_audio_source = 0x2 }
		public Flags flags;
		public string endpoint;
		public GroupCallParticipantVideoSourceGroup[] source_groups;
		[IfFlag(1)] public int audio_source;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/stickers.suggestedShortName"/></summary>
	[TLDef(0x85FEA03F)]
	public partial class Stickers_SuggestedShortName : ITLObject { public string short_name; }

	///<summary>See <a href="https://core.telegram.org/type/BotCommandScope"/></summary>
	public abstract partial class BotCommandScope : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/botCommandScopeDefault"/></summary>
	[TLDef(0x2F6CB2AB)]
	public partial class BotCommandScopeDefault : BotCommandScope { }
	///<summary>See <a href="https://core.telegram.org/constructor/botCommandScopeUsers"/></summary>
	[TLDef(0x3C4F04D8)]
	public partial class BotCommandScopeUsers : BotCommandScope { }
	///<summary>See <a href="https://core.telegram.org/constructor/botCommandScopeChats"/></summary>
	[TLDef(0x6FE1A881)]
	public partial class BotCommandScopeChats : BotCommandScope { }
	///<summary>See <a href="https://core.telegram.org/constructor/botCommandScopeChatAdmins"/></summary>
	[TLDef(0xB9AA606A)]
	public partial class BotCommandScopeChatAdmins : BotCommandScope { }
	///<summary>See <a href="https://core.telegram.org/constructor/botCommandScopePeer"/></summary>
	[TLDef(0xDB9D897D)]
	public partial class BotCommandScopePeer : BotCommandScope { public InputPeer peer; }
	///<summary>See <a href="https://core.telegram.org/constructor/botCommandScopePeerAdmins"/></summary>
	[TLDef(0x3FD863D1)]
	public partial class BotCommandScopePeerAdmins : BotCommandScope { public InputPeer peer; }
	///<summary>See <a href="https://core.telegram.org/constructor/botCommandScopePeerUser"/></summary>
	[TLDef(0x0A1321F3)]
	public partial class BotCommandScopePeerUser : BotCommandScope
	{
		public InputPeer peer;
		public InputUserBase user_id;
	}

	///<summary>See <a href="https://core.telegram.org/type/account.ResetPasswordResult"/></summary>
	public abstract partial class Account_ResetPasswordResult : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/account.resetPasswordFailedWait"/></summary>
	[TLDef(0xE3779861)]
	public partial class Account_ResetPasswordFailedWait : Account_ResetPasswordResult { public DateTime retry_date; }
	///<summary>See <a href="https://core.telegram.org/constructor/account.resetPasswordRequestedWait"/></summary>
	[TLDef(0xE9EFFC7D)]
	public partial class Account_ResetPasswordRequestedWait : Account_ResetPasswordResult { public DateTime until_date; }
	///<summary>See <a href="https://core.telegram.org/constructor/account.resetPasswordOk"/></summary>
	[TLDef(0xE926D63E)]
	public partial class Account_ResetPasswordOk : Account_ResetPasswordResult { }

	///<summary>See <a href="https://core.telegram.org/constructor/chatTheme"/></summary>
	[TLDef(0xED0B5C33)]
	public partial class ChatTheme : ITLObject
	{
		public string emoticon;
		public Theme theme;
		public Theme dark_theme;
	}

	///<summary>See <a href="https://core.telegram.org/type/account.ChatThemes"/></summary>
	public abstract partial class Account_ChatThemesBase : ITLObject { }
	///<summary>See <a href="https://core.telegram.org/constructor/account.chatThemesNotModified"/></summary>
	[TLDef(0xE011E1C4)]
	public partial class Account_ChatThemesNotModified : Account_ChatThemesBase { }
	///<summary>See <a href="https://core.telegram.org/constructor/account.chatThemes"/></summary>
	[TLDef(0xFE4CBEBD)]
	public partial class Account_ChatThemes : Account_ChatThemesBase
	{
		public int hash;
		public ChatTheme[] themes;
	}

	///<summary>See <a href="https://core.telegram.org/constructor/sponsoredMessage"/></summary>
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

	///<summary>See <a href="https://core.telegram.org/constructor/messages.sponsoredMessages"/></summary>
	[TLDef(0x65A4C7D5)]
	public partial class Messages_SponsoredMessages : ITLObject
	{
		public SponsoredMessage[] messages;
		public ChatBase[] chats;
		public UserBase[] users;
	}
}

namespace WTelegram		// ---functions---
{
	using System.IO;
	using TL;

	public partial class Client
	{
		///<summary>See <a href="https://core.telegram.org/method/invokeAfterMsg"/></summary>
		public Task<X> InvokeAfterMsg<X>(long msg_id, ITLFunction query)
			=> CallAsync<X>(writer =>
			{
				writer.Write(0xCB9F372D);
				writer.Write(msg_id);
				query(writer);
				return "InvokeAfterMsg<X>";
			});

		///<summary>See <a href="https://core.telegram.org/method/invokeAfterMsgs"/></summary>
		public Task<X> InvokeAfterMsgs<X>(long[] msg_ids, ITLFunction query)
			=> CallAsync<X>(writer =>
			{
				writer.Write(0x3DC4B4F0);
				writer.WriteTLVector(msg_ids);
				query(writer);
				return "InvokeAfterMsgs<X>";
			});

		///<summary>See <a href="https://core.telegram.org/method/initConnection"/></summary>
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

		///<summary>See <a href="https://core.telegram.org/method/invokeWithLayer"/></summary>
		public Task<X> InvokeWithLayer<X>(int layer, ITLFunction query)
			=> CallAsync<X>(writer =>
			{
				writer.Write(0xDA9B0D0D);
				writer.Write(layer);
				query(writer);
				return "InvokeWithLayer<X>";
			});

		///<summary>See <a href="https://core.telegram.org/method/invokeWithoutUpdates"/></summary>
		public Task<X> InvokeWithoutUpdates<X>(ITLFunction query)
			=> CallAsync<X>(writer =>
			{
				writer.Write(0xBF9459B7);
				query(writer);
				return "InvokeWithoutUpdates<X>";
			});

		///<summary>See <a href="https://core.telegram.org/method/invokeWithMessagesRange"/></summary>
		public Task<X> InvokeWithMessagesRange<X>(MessageRange range, ITLFunction query)
			=> CallAsync<X>(writer =>
			{
				writer.Write(0x365275F2);
				writer.WriteTLObject(range);
				query(writer);
				return "InvokeWithMessagesRange<X>";
			});

		///<summary>See <a href="https://core.telegram.org/method/invokeWithTakeout"/></summary>
		public Task<X> InvokeWithTakeout<X>(long takeout_id, ITLFunction query)
			=> CallAsync<X>(writer =>
			{
				writer.Write(0xACA9FD2E);
				writer.Write(takeout_id);
				query(writer);
				return "InvokeWithTakeout<X>";
			});

		///<summary>See <a href="https://core.telegram.org/method/auth.sendCode"/></summary>
		public Task<Auth_SentCode> Auth_SendCode(string phone_number, int api_id, string api_hash, CodeSettings settings)
			=> CallAsync<Auth_SentCode>(writer =>
			{
				writer.Write(0xA677244F);
				writer.WriteTLString(phone_number);
				writer.Write(api_id);
				writer.WriteTLString(api_hash);
				writer.WriteTLObject(settings);
				return "Auth_SendCode";
			});

		///<summary>See <a href="https://core.telegram.org/method/auth.signUp"/></summary>
		public Task<Auth_AuthorizationBase> Auth_SignUp(string phone_number, string phone_code_hash, string first_name, string last_name)
			=> CallAsync<Auth_AuthorizationBase>(writer =>
			{
				writer.Write(0x80EEE427);
				writer.WriteTLString(phone_number);
				writer.WriteTLString(phone_code_hash);
				writer.WriteTLString(first_name);
				writer.WriteTLString(last_name);
				return "Auth_SignUp";
			});

		///<summary>See <a href="https://core.telegram.org/method/auth.signIn"/></summary>
		public Task<Auth_AuthorizationBase> Auth_SignIn(string phone_number, string phone_code_hash, string phone_code)
			=> CallAsync<Auth_AuthorizationBase>(writer =>
			{
				writer.Write(0xBCD51581);
				writer.WriteTLString(phone_number);
				writer.WriteTLString(phone_code_hash);
				writer.WriteTLString(phone_code);
				return "Auth_SignIn";
			});

		///<summary>See <a href="https://core.telegram.org/method/auth.logOut"/></summary>
		public Task<bool> Auth_LogOut()
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x5717DA40);
				return "Auth_LogOut";
			});

		///<summary>See <a href="https://core.telegram.org/method/auth.resetAuthorizations"/></summary>
		public Task<bool> Auth_ResetAuthorizations()
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x9FAB0D1A);
				return "Auth_ResetAuthorizations";
			});

		///<summary>See <a href="https://core.telegram.org/method/auth.exportAuthorization"/></summary>
		public Task<Auth_ExportedAuthorization> Auth_ExportAuthorization(int dc_id)
			=> CallAsync<Auth_ExportedAuthorization>(writer =>
			{
				writer.Write(0xE5BFFFCD);
				writer.Write(dc_id);
				return "Auth_ExportAuthorization";
			});

		///<summary>See <a href="https://core.telegram.org/method/auth.importAuthorization"/></summary>
		public Task<Auth_AuthorizationBase> Auth_ImportAuthorization(long id, byte[] bytes)
			=> CallAsync<Auth_AuthorizationBase>(writer =>
			{
				writer.Write(0xA57A7DAD);
				writer.Write(id);
				writer.WriteTLBytes(bytes);
				return "Auth_ImportAuthorization";
			});

		///<summary>See <a href="https://core.telegram.org/method/auth.bindTempAuthKey"/></summary>
		public Task<bool> Auth_BindTempAuthKey(long perm_auth_key_id, long nonce, DateTime expires_at, byte[] encrypted_message)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xCDD42A05);
				writer.Write(perm_auth_key_id);
				writer.Write(nonce);
				writer.WriteTLStamp(expires_at);
				writer.WriteTLBytes(encrypted_message);
				return "Auth_BindTempAuthKey";
			});

		///<summary>See <a href="https://core.telegram.org/method/auth.importBotAuthorization"/></summary>
		public Task<Auth_AuthorizationBase> Auth_ImportBotAuthorization(int flags, int api_id, string api_hash, string bot_auth_token)
			=> CallAsync<Auth_AuthorizationBase>(writer =>
			{
				writer.Write(0x67A3FF2C);
				writer.Write(flags);
				writer.Write(api_id);
				writer.WriteTLString(api_hash);
				writer.WriteTLString(bot_auth_token);
				return "Auth_ImportBotAuthorization";
			});

		///<summary>See <a href="https://core.telegram.org/method/auth.checkPassword"/></summary>
		public Task<Auth_AuthorizationBase> Auth_CheckPassword(InputCheckPasswordSRPBase password)
			=> CallAsync<Auth_AuthorizationBase>(writer =>
			{
				writer.Write(0xD18B4D16);
				writer.WriteTLObject(password);
				return "Auth_CheckPassword";
			});

		///<summary>See <a href="https://core.telegram.org/method/auth.requestPasswordRecovery"/></summary>
		public Task<Auth_PasswordRecovery> Auth_RequestPasswordRecovery()
			=> CallAsync<Auth_PasswordRecovery>(writer =>
			{
				writer.Write(0xD897BC66);
				return "Auth_RequestPasswordRecovery";
			});

		///<summary>See <a href="https://core.telegram.org/method/auth.recoverPassword"/></summary>
		public Task<Auth_AuthorizationBase> Auth_RecoverPassword(string code, Account_PasswordInputSettings new_settings = null)
			=> CallAsync<Auth_AuthorizationBase>(writer =>
			{
				writer.Write(0x37096C70);
				writer.Write(new_settings != null ? 0x1 : 0);
				writer.WriteTLString(code);
				if (new_settings != null)
					writer.WriteTLObject(new_settings);
				return "Auth_RecoverPassword";
			});

		///<summary>See <a href="https://core.telegram.org/method/auth.resendCode"/></summary>
		public Task<Auth_SentCode> Auth_ResendCode(string phone_number, string phone_code_hash)
			=> CallAsync<Auth_SentCode>(writer =>
			{
				writer.Write(0x3EF1A9BF);
				writer.WriteTLString(phone_number);
				writer.WriteTLString(phone_code_hash);
				return "Auth_ResendCode";
			});

		///<summary>See <a href="https://core.telegram.org/method/auth.cancelCode"/></summary>
		public Task<bool> Auth_CancelCode(string phone_number, string phone_code_hash)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x1F040578);
				writer.WriteTLString(phone_number);
				writer.WriteTLString(phone_code_hash);
				return "Auth_CancelCode";
			});

		///<summary>See <a href="https://core.telegram.org/method/auth.dropTempAuthKeys"/></summary>
		public Task<bool> Auth_DropTempAuthKeys(long[] except_auth_keys)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x8E48A188);
				writer.WriteTLVector(except_auth_keys);
				return "Auth_DropTempAuthKeys";
			});

		///<summary>See <a href="https://core.telegram.org/method/auth.exportLoginToken"/></summary>
		public Task<Auth_LoginTokenBase> Auth_ExportLoginToken(int api_id, string api_hash, long[] except_ids)
			=> CallAsync<Auth_LoginTokenBase>(writer =>
			{
				writer.Write(0xB7E085FE);
				writer.Write(api_id);
				writer.WriteTLString(api_hash);
				writer.WriteTLVector(except_ids);
				return "Auth_ExportLoginToken";
			});

		///<summary>See <a href="https://core.telegram.org/method/auth.importLoginToken"/></summary>
		public Task<Auth_LoginTokenBase> Auth_ImportLoginToken(byte[] token)
			=> CallAsync<Auth_LoginTokenBase>(writer =>
			{
				writer.Write(0x95AC5CE4);
				writer.WriteTLBytes(token);
				return "Auth_ImportLoginToken";
			});

		///<summary>See <a href="https://core.telegram.org/method/auth.acceptLoginToken"/></summary>
		public Task<Authorization> Auth_AcceptLoginToken(byte[] token)
			=> CallAsync<Authorization>(writer =>
			{
				writer.Write(0xE894AD4D);
				writer.WriteTLBytes(token);
				return "Auth_AcceptLoginToken";
			});

		///<summary>See <a href="https://core.telegram.org/method/auth.checkRecoveryPassword"/></summary>
		public Task<bool> Auth_CheckRecoveryPassword(string code)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x0D36BF79);
				writer.WriteTLString(code);
				return "Auth_CheckRecoveryPassword";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.registerDevice"/></summary>
		public Task<bool> Account_RegisterDevice(int token_type, string token, bool app_sandbox, byte[] secret, long[] other_uids, bool no_muted = false)
			=> CallAsync<bool>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/account.unregisterDevice"/></summary>
		public Task<bool> Account_UnregisterDevice(int token_type, string token, long[] other_uids)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x6A0D3206);
				writer.Write(token_type);
				writer.WriteTLString(token);
				writer.WriteTLVector(other_uids);
				return "Account_UnregisterDevice";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.updateNotifySettings"/></summary>
		public Task<bool> Account_UpdateNotifySettings(InputNotifyPeerBase peer, InputPeerNotifySettings settings)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x84BE5B93);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(settings);
				return "Account_UpdateNotifySettings";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.getNotifySettings"/></summary>
		public Task<PeerNotifySettings> Account_GetNotifySettings(InputNotifyPeerBase peer)
			=> CallAsync<PeerNotifySettings>(writer =>
			{
				writer.Write(0x12B3AD31);
				writer.WriteTLObject(peer);
				return "Account_GetNotifySettings";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.resetNotifySettings"/></summary>
		public Task<bool> Account_ResetNotifySettings()
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xDB7E1747);
				return "Account_ResetNotifySettings";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.updateProfile"/></summary>
		public Task<UserBase> Account_UpdateProfile(string first_name = null, string last_name = null, string about = null)
			=> CallAsync<UserBase>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/account.updateStatus"/></summary>
		public Task<bool> Account_UpdateStatus(bool offline)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x6628562C);
				writer.Write(offline ? 0x997275B5 : 0xBC799737);
				return "Account_UpdateStatus";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.getWallPapers"/></summary>
		public Task<Account_WallPapersBase> Account_GetWallPapers(long hash)
			=> CallAsync<Account_WallPapersBase>(writer =>
			{
				writer.Write(0x07967D36);
				writer.Write(hash);
				return "Account_GetWallPapers";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.reportPeer"/></summary>
		public Task<bool> Account_ReportPeer(InputPeer peer, ReportReason reason, string message)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xC5BA3D86);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(reason);
				writer.WriteTLString(message);
				return "Account_ReportPeer";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.checkUsername"/></summary>
		public Task<bool> Account_CheckUsername(string username)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x2714D86C);
				writer.WriteTLString(username);
				return "Account_CheckUsername";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.updateUsername"/></summary>
		public Task<UserBase> Account_UpdateUsername(string username)
			=> CallAsync<UserBase>(writer =>
			{
				writer.Write(0x3E0BDD7C);
				writer.WriteTLString(username);
				return "Account_UpdateUsername";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.getPrivacy"/></summary>
		public Task<Account_PrivacyRules> Account_GetPrivacy(InputPrivacyKey key)
			=> CallAsync<Account_PrivacyRules>(writer =>
			{
				writer.Write(0xDADBC950);
				writer.WriteTLObject(key);
				return "Account_GetPrivacy";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.setPrivacy"/></summary>
		public Task<Account_PrivacyRules> Account_SetPrivacy(InputPrivacyKey key, InputPrivacyRule[] rules)
			=> CallAsync<Account_PrivacyRules>(writer =>
			{
				writer.Write(0xC9F81CE8);
				writer.WriteTLObject(key);
				writer.WriteTLVector(rules);
				return "Account_SetPrivacy";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.deleteAccount"/></summary>
		public Task<bool> Account_DeleteAccount(string reason)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x418D4E0B);
				writer.WriteTLString(reason);
				return "Account_DeleteAccount";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.getAccountTTL"/></summary>
		public Task<AccountDaysTTL> Account_GetAccountTTL()
			=> CallAsync<AccountDaysTTL>(writer =>
			{
				writer.Write(0x08FC711D);
				return "Account_GetAccountTTL";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.setAccountTTL"/></summary>
		public Task<bool> Account_SetAccountTTL(AccountDaysTTL ttl)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x2442485E);
				writer.WriteTLObject(ttl);
				return "Account_SetAccountTTL";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.sendChangePhoneCode"/></summary>
		public Task<Auth_SentCode> Account_SendChangePhoneCode(string phone_number, CodeSettings settings)
			=> CallAsync<Auth_SentCode>(writer =>
			{
				writer.Write(0x82574AE5);
				writer.WriteTLString(phone_number);
				writer.WriteTLObject(settings);
				return "Account_SendChangePhoneCode";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.changePhone"/></summary>
		public Task<UserBase> Account_ChangePhone(string phone_number, string phone_code_hash, string phone_code)
			=> CallAsync<UserBase>(writer =>
			{
				writer.Write(0x70C32EDB);
				writer.WriteTLString(phone_number);
				writer.WriteTLString(phone_code_hash);
				writer.WriteTLString(phone_code);
				return "Account_ChangePhone";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.updateDeviceLocked"/></summary>
		public Task<bool> Account_UpdateDeviceLocked(int period)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x38DF3532);
				writer.Write(period);
				return "Account_UpdateDeviceLocked";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.getAuthorizations"/></summary>
		public Task<Account_Authorizations> Account_GetAuthorizations()
			=> CallAsync<Account_Authorizations>(writer =>
			{
				writer.Write(0xE320C158);
				return "Account_GetAuthorizations";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.resetAuthorization"/></summary>
		public Task<bool> Account_ResetAuthorization(long hash)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xDF77F3BC);
				writer.Write(hash);
				return "Account_ResetAuthorization";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.getPassword"/></summary>
		public Task<Account_Password> Account_GetPassword()
			=> CallAsync<Account_Password>(writer =>
			{
				writer.Write(0x548A30F5);
				return "Account_GetPassword";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.getPasswordSettings"/></summary>
		public Task<Account_PasswordSettings> Account_GetPasswordSettings(InputCheckPasswordSRPBase password)
			=> CallAsync<Account_PasswordSettings>(writer =>
			{
				writer.Write(0x9CD4EAF9);
				writer.WriteTLObject(password);
				return "Account_GetPasswordSettings";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.updatePasswordSettings"/></summary>
		public Task<bool> Account_UpdatePasswordSettings(InputCheckPasswordSRPBase password, Account_PasswordInputSettings new_settings)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xA59B102F);
				writer.WriteTLObject(password);
				writer.WriteTLObject(new_settings);
				return "Account_UpdatePasswordSettings";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.sendConfirmPhoneCode"/></summary>
		public Task<Auth_SentCode> Account_SendConfirmPhoneCode(string hash, CodeSettings settings)
			=> CallAsync<Auth_SentCode>(writer =>
			{
				writer.Write(0x1B3FAA88);
				writer.WriteTLString(hash);
				writer.WriteTLObject(settings);
				return "Account_SendConfirmPhoneCode";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.confirmPhone"/></summary>
		public Task<bool> Account_ConfirmPhone(string phone_code_hash, string phone_code)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x5F2178C3);
				writer.WriteTLString(phone_code_hash);
				writer.WriteTLString(phone_code);
				return "Account_ConfirmPhone";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.getTmpPassword"/></summary>
		public Task<Account_TmpPassword> Account_GetTmpPassword(InputCheckPasswordSRPBase password, int period)
			=> CallAsync<Account_TmpPassword>(writer =>
			{
				writer.Write(0x449E0B51);
				writer.WriteTLObject(password);
				writer.Write(period);
				return "Account_GetTmpPassword";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.getWebAuthorizations"/></summary>
		public Task<Account_WebAuthorizations> Account_GetWebAuthorizations()
			=> CallAsync<Account_WebAuthorizations>(writer =>
			{
				writer.Write(0x182E6D6F);
				return "Account_GetWebAuthorizations";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.resetWebAuthorization"/></summary>
		public Task<bool> Account_ResetWebAuthorization(long hash)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x2D01B9EF);
				writer.Write(hash);
				return "Account_ResetWebAuthorization";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.resetWebAuthorizations"/></summary>
		public Task<bool> Account_ResetWebAuthorizations()
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x682D2594);
				return "Account_ResetWebAuthorizations";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.getAllSecureValues"/></summary>
		public Task<SecureValue[]> Account_GetAllSecureValues()
			=> CallAsync<SecureValue[]>(writer =>
			{
				writer.Write(0xB288BC7D);
				return "Account_GetAllSecureValues";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.getSecureValue"/></summary>
		public Task<SecureValue[]> Account_GetSecureValue(SecureValueType[] types)
			=> CallAsync<SecureValue[]>(writer =>
			{
				writer.Write(0x73665BC2);
				writer.WriteTLVector(types);
				return "Account_GetSecureValue";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.saveSecureValue"/></summary>
		public Task<SecureValue> Account_SaveSecureValue(InputSecureValue value, long secure_secret_id)
			=> CallAsync<SecureValue>(writer =>
			{
				writer.Write(0x899FE31D);
				writer.WriteTLObject(value);
				writer.Write(secure_secret_id);
				return "Account_SaveSecureValue";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.deleteSecureValue"/></summary>
		public Task<bool> Account_DeleteSecureValue(SecureValueType[] types)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xB880BC4B);
				writer.WriteTLVector(types);
				return "Account_DeleteSecureValue";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.getAuthorizationForm"/></summary>
		public Task<Account_AuthorizationForm> Account_GetAuthorizationForm(long bot_id, string scope, string public_key)
			=> CallAsync<Account_AuthorizationForm>(writer =>
			{
				writer.Write(0xA929597A);
				writer.Write(bot_id);
				writer.WriteTLString(scope);
				writer.WriteTLString(public_key);
				return "Account_GetAuthorizationForm";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.acceptAuthorization"/></summary>
		public Task<bool> Account_AcceptAuthorization(long bot_id, string scope, string public_key, SecureValueHash[] value_hashes, SecureCredentialsEncrypted credentials)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xF3ED4C73);
				writer.Write(bot_id);
				writer.WriteTLString(scope);
				writer.WriteTLString(public_key);
				writer.WriteTLVector(value_hashes);
				writer.WriteTLObject(credentials);
				return "Account_AcceptAuthorization";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.sendVerifyPhoneCode"/></summary>
		public Task<Auth_SentCode> Account_SendVerifyPhoneCode(string phone_number, CodeSettings settings)
			=> CallAsync<Auth_SentCode>(writer =>
			{
				writer.Write(0xA5A356F9);
				writer.WriteTLString(phone_number);
				writer.WriteTLObject(settings);
				return "Account_SendVerifyPhoneCode";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.verifyPhone"/></summary>
		public Task<bool> Account_VerifyPhone(string phone_number, string phone_code_hash, string phone_code)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x4DD3A7F6);
				writer.WriteTLString(phone_number);
				writer.WriteTLString(phone_code_hash);
				writer.WriteTLString(phone_code);
				return "Account_VerifyPhone";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.sendVerifyEmailCode"/></summary>
		public Task<Account_SentEmailCode> Account_SendVerifyEmailCode(string email)
			=> CallAsync<Account_SentEmailCode>(writer =>
			{
				writer.Write(0x7011509F);
				writer.WriteTLString(email);
				return "Account_SendVerifyEmailCode";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.verifyEmail"/></summary>
		public Task<bool> Account_VerifyEmail(string email, string code)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xECBA39DB);
				writer.WriteTLString(email);
				writer.WriteTLString(code);
				return "Account_VerifyEmail";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.initTakeoutSession"/></summary>
		public Task<Account_Takeout> Account_InitTakeoutSession(bool contacts = false, bool message_users = false, bool message_chats = false, bool message_megagroups = false, bool message_channels = false, bool files = false, int? file_max_size = null)
			=> CallAsync<Account_Takeout>(writer =>
			{
				writer.Write(0xF05B4804);
				writer.Write((contacts ? 0x1 : 0) | (message_users ? 0x2 : 0) | (message_chats ? 0x4 : 0) | (message_megagroups ? 0x8 : 0) | (message_channels ? 0x10 : 0) | (files ? 0x20 : 0) | (file_max_size != null ? 0x20 : 0));
				if (file_max_size != null)
					writer.Write(file_max_size.Value);
				return "Account_InitTakeoutSession";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.finishTakeoutSession"/></summary>
		public Task<bool> Account_FinishTakeoutSession(bool success = false)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x1D2652EE);
				writer.Write(success ? 0x1 : 0);
				return "Account_FinishTakeoutSession";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.confirmPasswordEmail"/></summary>
		public Task<bool> Account_ConfirmPasswordEmail(string code)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x8FDF1920);
				writer.WriteTLString(code);
				return "Account_ConfirmPasswordEmail";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.resendPasswordEmail"/></summary>
		public Task<bool> Account_ResendPasswordEmail()
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x7A7F2A15);
				return "Account_ResendPasswordEmail";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.cancelPasswordEmail"/></summary>
		public Task<bool> Account_CancelPasswordEmail()
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xC1CBD5B6);
				return "Account_CancelPasswordEmail";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.getContactSignUpNotification"/></summary>
		public Task<bool> Account_GetContactSignUpNotification()
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x9F07C728);
				return "Account_GetContactSignUpNotification";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.setContactSignUpNotification"/></summary>
		public Task<bool> Account_SetContactSignUpNotification(bool silent)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xCFF43F61);
				writer.Write(silent ? 0x997275B5 : 0xBC799737);
				return "Account_SetContactSignUpNotification";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.getNotifyExceptions"/></summary>
		public Task<UpdatesBase> Account_GetNotifyExceptions(bool compare_sound = false, InputNotifyPeerBase peer = null)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x53577479);
				writer.Write((compare_sound ? 0x2 : 0) | (peer != null ? 0x1 : 0));
				if (peer != null)
					writer.WriteTLObject(peer);
				return "Account_GetNotifyExceptions";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.getWallPaper"/></summary>
		public Task<WallPaperBase> Account_GetWallPaper(InputWallPaperBase wallpaper)
			=> CallAsync<WallPaperBase>(writer =>
			{
				writer.Write(0xFC8DDBEA);
				writer.WriteTLObject(wallpaper);
				return "Account_GetWallPaper";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.uploadWallPaper"/></summary>
		public Task<WallPaperBase> Account_UploadWallPaper(InputFileBase file, string mime_type, WallPaperSettings settings)
			=> CallAsync<WallPaperBase>(writer =>
			{
				writer.Write(0xDD853661);
				writer.WriteTLObject(file);
				writer.WriteTLString(mime_type);
				writer.WriteTLObject(settings);
				return "Account_UploadWallPaper";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.saveWallPaper"/></summary>
		public Task<bool> Account_SaveWallPaper(InputWallPaperBase wallpaper, bool unsave, WallPaperSettings settings)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x6C5A5B37);
				writer.WriteTLObject(wallpaper);
				writer.Write(unsave ? 0x997275B5 : 0xBC799737);
				writer.WriteTLObject(settings);
				return "Account_SaveWallPaper";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.installWallPaper"/></summary>
		public Task<bool> Account_InstallWallPaper(InputWallPaperBase wallpaper, WallPaperSettings settings)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xFEED5769);
				writer.WriteTLObject(wallpaper);
				writer.WriteTLObject(settings);
				return "Account_InstallWallPaper";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.resetWallPapers"/></summary>
		public Task<bool> Account_ResetWallPapers()
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xBB3B9804);
				return "Account_ResetWallPapers";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.getAutoDownloadSettings"/></summary>
		public Task<Account_AutoDownloadSettings> Account_GetAutoDownloadSettings()
			=> CallAsync<Account_AutoDownloadSettings>(writer =>
			{
				writer.Write(0x56DA0B3F);
				return "Account_GetAutoDownloadSettings";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.saveAutoDownloadSettings"/></summary>
		public Task<bool> Account_SaveAutoDownloadSettings(AutoDownloadSettings settings, bool low = false, bool high = false)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x76F36233);
				writer.Write((low ? 0x1 : 0) | (high ? 0x2 : 0));
				writer.WriteTLObject(settings);
				return "Account_SaveAutoDownloadSettings";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.uploadTheme"/></summary>
		public Task<DocumentBase> Account_UploadTheme(InputFileBase file, string file_name, string mime_type, InputFileBase thumb = null)
			=> CallAsync<DocumentBase>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/account.createTheme"/></summary>
		public Task<Theme> Account_CreateTheme(string slug, string title, InputDocumentBase document = null, InputThemeSettings settings = null)
			=> CallAsync<Theme>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/account.updateTheme"/></summary>
		public Task<Theme> Account_UpdateTheme(string format, InputThemeBase theme, string slug = null, string title = null, InputDocumentBase document = null, InputThemeSettings settings = null)
			=> CallAsync<Theme>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/account.saveTheme"/></summary>
		public Task<bool> Account_SaveTheme(InputThemeBase theme, bool unsave)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xF257106C);
				writer.WriteTLObject(theme);
				writer.Write(unsave ? 0x997275B5 : 0xBC799737);
				return "Account_SaveTheme";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.installTheme"/></summary>
		public Task<bool> Account_InstallTheme(bool dark = false, string format = null, InputThemeBase theme = null)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x7AE43737);
				writer.Write((dark ? 0x1 : 0) | (format != null ? 0x2 : 0) | (theme != null ? 0x2 : 0));
				if (format != null)
					writer.WriteTLString(format);
				if (theme != null)
					writer.WriteTLObject(theme);
				return "Account_InstallTheme";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.getTheme"/></summary>
		public Task<Theme> Account_GetTheme(string format, InputThemeBase theme, long document_id)
			=> CallAsync<Theme>(writer =>
			{
				writer.Write(0x8D9D742B);
				writer.WriteTLString(format);
				writer.WriteTLObject(theme);
				writer.Write(document_id);
				return "Account_GetTheme";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.getThemes"/></summary>
		public Task<Account_ThemesBase> Account_GetThemes(string format, long hash)
			=> CallAsync<Account_ThemesBase>(writer =>
			{
				writer.Write(0x7206E458);
				writer.WriteTLString(format);
				writer.Write(hash);
				return "Account_GetThemes";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.setContentSettings"/></summary>
		public Task<bool> Account_SetContentSettings(bool sensitive_enabled = false)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xB574B16B);
				writer.Write(sensitive_enabled ? 0x1 : 0);
				return "Account_SetContentSettings";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.getContentSettings"/></summary>
		public Task<Account_ContentSettings> Account_GetContentSettings()
			=> CallAsync<Account_ContentSettings>(writer =>
			{
				writer.Write(0x8B9B4DAE);
				return "Account_GetContentSettings";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.getMultiWallPapers"/></summary>
		public Task<WallPaperBase[]> Account_GetMultiWallPapers(InputWallPaperBase[] wallpapers)
			=> CallAsync<WallPaperBase[]>(writer =>
			{
				writer.Write(0x65AD71DC);
				writer.WriteTLVector(wallpapers);
				return "Account_GetMultiWallPapers";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.getGlobalPrivacySettings"/></summary>
		public Task<GlobalPrivacySettings> Account_GetGlobalPrivacySettings()
			=> CallAsync<GlobalPrivacySettings>(writer =>
			{
				writer.Write(0xEB2B4CF6);
				return "Account_GetGlobalPrivacySettings";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.setGlobalPrivacySettings"/></summary>
		public Task<GlobalPrivacySettings> Account_SetGlobalPrivacySettings(GlobalPrivacySettings settings)
			=> CallAsync<GlobalPrivacySettings>(writer =>
			{
				writer.Write(0x1EDAAAC2);
				writer.WriteTLObject(settings);
				return "Account_SetGlobalPrivacySettings";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.reportProfilePhoto"/></summary>
		public Task<bool> Account_ReportProfilePhoto(InputPeer peer, InputPhotoBase photo_id, ReportReason reason, string message)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xFA8CC6F5);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(photo_id);
				writer.WriteTLObject(reason);
				writer.WriteTLString(message);
				return "Account_ReportProfilePhoto";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.resetPassword"/></summary>
		public Task<Account_ResetPasswordResult> Account_ResetPassword()
			=> CallAsync<Account_ResetPasswordResult>(writer =>
			{
				writer.Write(0x9308CE1B);
				return "Account_ResetPassword";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.declinePasswordReset"/></summary>
		public Task<bool> Account_DeclinePasswordReset()
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x4C9409F6);
				return "Account_DeclinePasswordReset";
			});

		///<summary>See <a href="https://core.telegram.org/method/account.getChatThemes"/></summary>
		public Task<Account_ChatThemesBase> Account_GetChatThemes(int hash)
			=> CallAsync<Account_ChatThemesBase>(writer =>
			{
				writer.Write(0xD6D71D7B);
				writer.Write(hash);
				return "Account_GetChatThemes";
			});

		///<summary>See <a href="https://core.telegram.org/method/users.getUsers"/></summary>
		public Task<UserBase[]> Users_GetUsers(InputUserBase[] id)
			=> CallAsync<UserBase[]>(writer =>
			{
				writer.Write(0x0D91A548);
				writer.WriteTLVector(id);
				return "Users_GetUsers";
			});

		///<summary>See <a href="https://core.telegram.org/method/users.getFullUser"/></summary>
		public Task<UserFull> Users_GetFullUser(InputUserBase id)
			=> CallAsync<UserFull>(writer =>
			{
				writer.Write(0xCA30A5B1);
				writer.WriteTLObject(id);
				return "Users_GetFullUser";
			});

		///<summary>See <a href="https://core.telegram.org/method/users.setSecureValueErrors"/></summary>
		public Task<bool> Users_SetSecureValueErrors(InputUserBase id, SecureValueErrorBase[] errors)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x90C894B5);
				writer.WriteTLObject(id);
				writer.WriteTLVector(errors);
				return "Users_SetSecureValueErrors";
			});

		///<summary>See <a href="https://core.telegram.org/method/contacts.getContactIDs"/></summary>
		public Task<int[]> Contacts_GetContactIDs(long hash)
			=> CallAsync<int[]>(writer =>
			{
				writer.Write(0x7ADC669D);
				writer.Write(hash);
				return "Contacts_GetContactIDs";
			});

		///<summary>See <a href="https://core.telegram.org/method/contacts.getStatuses"/></summary>
		public Task<ContactStatus[]> Contacts_GetStatuses()
			=> CallAsync<ContactStatus[]>(writer =>
			{
				writer.Write(0xC4A353EE);
				return "Contacts_GetStatuses";
			});

		///<summary>See <a href="https://core.telegram.org/method/contacts.getContacts"/></summary>
		public Task<Contacts_ContactsBase> Contacts_GetContacts(long hash)
			=> CallAsync<Contacts_ContactsBase>(writer =>
			{
				writer.Write(0x5DD69E12);
				writer.Write(hash);
				return "Contacts_GetContacts";
			});

		///<summary>See <a href="https://core.telegram.org/method/contacts.importContacts"/></summary>
		public Task<Contacts_ImportedContacts> Contacts_ImportContacts(InputContact[] contacts)
			=> CallAsync<Contacts_ImportedContacts>(writer =>
			{
				writer.Write(0x2C800BE5);
				writer.WriteTLVector(contacts);
				return "Contacts_ImportContacts";
			});

		///<summary>See <a href="https://core.telegram.org/method/contacts.deleteContacts"/></summary>
		public Task<UpdatesBase> Contacts_DeleteContacts(InputUserBase[] id)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x096A0E00);
				writer.WriteTLVector(id);
				return "Contacts_DeleteContacts";
			});

		///<summary>See <a href="https://core.telegram.org/method/contacts.deleteByPhones"/></summary>
		public Task<bool> Contacts_DeleteByPhones(string[] phones)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x1013FD9E);
				writer.WriteTLVector(phones);
				return "Contacts_DeleteByPhones";
			});

		///<summary>See <a href="https://core.telegram.org/method/contacts.block"/></summary>
		public Task<bool> Contacts_Block(InputPeer id)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x68CC1411);
				writer.WriteTLObject(id);
				return "Contacts_Block";
			});

		///<summary>See <a href="https://core.telegram.org/method/contacts.unblock"/></summary>
		public Task<bool> Contacts_Unblock(InputPeer id)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xBEA65D50);
				writer.WriteTLObject(id);
				return "Contacts_Unblock";
			});

		///<summary>See <a href="https://core.telegram.org/method/contacts.getBlocked"/></summary>
		public Task<Contacts_BlockedBase> Contacts_GetBlocked(int offset, int limit)
			=> CallAsync<Contacts_BlockedBase>(writer =>
			{
				writer.Write(0xF57C350F);
				writer.Write(offset);
				writer.Write(limit);
				return "Contacts_GetBlocked";
			});

		///<summary>See <a href="https://core.telegram.org/method/contacts.search"/></summary>
		public Task<Contacts_Found> Contacts_Search(string q, int limit)
			=> CallAsync<Contacts_Found>(writer =>
			{
				writer.Write(0x11F812D8);
				writer.WriteTLString(q);
				writer.Write(limit);
				return "Contacts_Search";
			});

		///<summary>See <a href="https://core.telegram.org/method/contacts.resolveUsername"/></summary>
		public Task<Contacts_ResolvedPeer> Contacts_ResolveUsername(string username)
			=> CallAsync<Contacts_ResolvedPeer>(writer =>
			{
				writer.Write(0xF93CCBA3);
				writer.WriteTLString(username);
				return "Contacts_ResolveUsername";
			});

		///<summary>See <a href="https://core.telegram.org/method/contacts.getTopPeers"/></summary>
		public Task<Contacts_TopPeersBase> Contacts_GetTopPeers(int offset, int limit, long hash, bool correspondents = false, bool bots_pm = false, bool bots_inline = false, bool phone_calls = false, bool forward_users = false, bool forward_chats = false, bool groups = false, bool channels = false)
			=> CallAsync<Contacts_TopPeersBase>(writer =>
			{
				writer.Write(0x973478B6);
				writer.Write((correspondents ? 0x1 : 0) | (bots_pm ? 0x2 : 0) | (bots_inline ? 0x4 : 0) | (phone_calls ? 0x8 : 0) | (forward_users ? 0x10 : 0) | (forward_chats ? 0x20 : 0) | (groups ? 0x400 : 0) | (channels ? 0x8000 : 0));
				writer.Write(offset);
				writer.Write(limit);
				writer.Write(hash);
				return "Contacts_GetTopPeers";
			});

		///<summary>See <a href="https://core.telegram.org/method/contacts.resetTopPeerRating"/></summary>
		public Task<bool> Contacts_ResetTopPeerRating(TopPeerCategory category, InputPeer peer)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x1AE373AC);
				writer.WriteTLObject(category);
				writer.WriteTLObject(peer);
				return "Contacts_ResetTopPeerRating";
			});

		///<summary>See <a href="https://core.telegram.org/method/contacts.resetSaved"/></summary>
		public Task<bool> Contacts_ResetSaved()
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x879537F1);
				return "Contacts_ResetSaved";
			});

		///<summary>See <a href="https://core.telegram.org/method/contacts.getSaved"/></summary>
		public Task<SavedContact[]> Contacts_GetSaved()
			=> CallAsync<SavedContact[]>(writer =>
			{
				writer.Write(0x82F1E39F);
				return "Contacts_GetSaved";
			});

		///<summary>See <a href="https://core.telegram.org/method/contacts.toggleTopPeers"/></summary>
		public Task<bool> Contacts_ToggleTopPeers(bool enabled)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x8514BDDA);
				writer.Write(enabled ? 0x997275B5 : 0xBC799737);
				return "Contacts_ToggleTopPeers";
			});

		///<summary>See <a href="https://core.telegram.org/method/contacts.addContact"/></summary>
		public Task<UpdatesBase> Contacts_AddContact(InputUserBase id, string first_name, string last_name, string phone, bool add_phone_privacy_exception = false)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xE8F463D0);
				writer.Write(add_phone_privacy_exception ? 0x1 : 0);
				writer.WriteTLObject(id);
				writer.WriteTLString(first_name);
				writer.WriteTLString(last_name);
				writer.WriteTLString(phone);
				return "Contacts_AddContact";
			});

		///<summary>See <a href="https://core.telegram.org/method/contacts.acceptContact"/></summary>
		public Task<UpdatesBase> Contacts_AcceptContact(InputUserBase id)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xF831A20F);
				writer.WriteTLObject(id);
				return "Contacts_AcceptContact";
			});

		///<summary>See <a href="https://core.telegram.org/method/contacts.getLocated"/></summary>
		public Task<UpdatesBase> Contacts_GetLocated(InputGeoPointBase geo_point, bool background = false, int? self_expires = null)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xD348BC44);
				writer.Write((background ? 0x2 : 0) | (self_expires != null ? 0x1 : 0));
				writer.WriteTLObject(geo_point);
				if (self_expires != null)
					writer.Write(self_expires.Value);
				return "Contacts_GetLocated";
			});

		///<summary>See <a href="https://core.telegram.org/method/contacts.blockFromReplies"/></summary>
		public Task<UpdatesBase> Contacts_BlockFromReplies(int msg_id, bool delete_message = false, bool delete_history = false, bool report_spam = false)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x29A8962C);
				writer.Write((delete_message ? 0x1 : 0) | (delete_history ? 0x2 : 0) | (report_spam ? 0x4 : 0));
				writer.Write(msg_id);
				return "Contacts_BlockFromReplies";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getMessages"/></summary>
		public Task<Messages_MessagesBase> Messages_GetMessages(InputMessage[] id)
			=> CallAsync<Messages_MessagesBase>(writer =>
			{
				writer.Write(0x63C66506);
				writer.WriteTLVector(id);
				return "Messages_GetMessages";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getDialogs"/></summary>
		public Task<Messages_DialogsBase> Messages_GetDialogs(DateTime offset_date, int offset_id, InputPeer offset_peer, int limit, long hash, bool exclude_pinned = false, int? folder_id = null)
			=> CallAsync<Messages_DialogsBase>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/messages.getHistory"/></summary>
		public Task<Messages_MessagesBase> Messages_GetHistory(InputPeer peer, int offset_id, DateTime offset_date, int add_offset, int limit, int max_id, int min_id, long hash)
			=> CallAsync<Messages_MessagesBase>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/messages.search"/></summary>
		public Task<Messages_MessagesBase> Messages_Search(InputPeer peer, string q, MessagesFilter filter, DateTime min_date, DateTime max_date, int offset_id, int add_offset, int limit, int max_id, int min_id, long hash, InputPeer from_id = null, int? top_msg_id = null)
			=> CallAsync<Messages_MessagesBase>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/messages.readHistory"/></summary>
		public Task<Messages_AffectedMessages> Messages_ReadHistory(InputPeer peer, int max_id)
			=> CallAsync<Messages_AffectedMessages>(writer =>
			{
				writer.Write(0x0E306D3A);
				writer.WriteTLObject(peer);
				writer.Write(max_id);
				return "Messages_ReadHistory";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.deleteHistory"/></summary>
		public Task<Messages_AffectedHistory> Messages_DeleteHistory(InputPeer peer, int max_id, bool just_clear = false, bool revoke = false)
			=> CallAsync<Messages_AffectedHistory>(writer =>
			{
				writer.Write(0x1C015B09);
				writer.Write((just_clear ? 0x1 : 0) | (revoke ? 0x2 : 0));
				writer.WriteTLObject(peer);
				writer.Write(max_id);
				return "Messages_DeleteHistory";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.deleteMessages"/></summary>
		public Task<Messages_AffectedMessages> Messages_DeleteMessages(int[] id, bool revoke = false)
			=> CallAsync<Messages_AffectedMessages>(writer =>
			{
				writer.Write(0xE58E95D2);
				writer.Write(revoke ? 0x1 : 0);
				writer.WriteTLVector(id);
				return "Messages_DeleteMessages";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.receivedMessages"/></summary>
		public Task<ReceivedNotifyMessage[]> Messages_ReceivedMessages(int max_id)
			=> CallAsync<ReceivedNotifyMessage[]>(writer =>
			{
				writer.Write(0x05A954C0);
				writer.Write(max_id);
				return "Messages_ReceivedMessages";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.setTyping"/></summary>
		public Task<bool> Messages_SetTyping(InputPeer peer, SendMessageAction action, int? top_msg_id = null)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x58943EE2);
				writer.Write(top_msg_id != null ? 0x1 : 0);
				writer.WriteTLObject(peer);
				if (top_msg_id != null)
					writer.Write(top_msg_id.Value);
				writer.WriteTLObject(action);
				return "Messages_SetTyping";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.sendMessage"/></summary>
		public Task<UpdatesBase> Messages_SendMessage(InputPeer peer, string message, long random_id, bool no_webpage = false, bool silent = false, bool background = false, bool clear_draft = false, int? reply_to_msg_id = null, ReplyMarkup reply_markup = null, MessageEntity[] entities = null, DateTime? schedule_date = null)
			=> CallAsync<UpdatesBase>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/messages.sendMedia"/></summary>
		public Task<UpdatesBase> Messages_SendMedia(InputPeer peer, InputMedia media, string message, long random_id, bool silent = false, bool background = false, bool clear_draft = false, int? reply_to_msg_id = null, ReplyMarkup reply_markup = null, MessageEntity[] entities = null, DateTime? schedule_date = null)
			=> CallAsync<UpdatesBase>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/messages.forwardMessages"/></summary>
		public Task<UpdatesBase> Messages_ForwardMessages(InputPeer from_peer, int[] id, long[] random_id, InputPeer to_peer, bool silent = false, bool background = false, bool with_my_score = false, bool drop_author = false, bool drop_media_captions = false, DateTime? schedule_date = null)
			=> CallAsync<UpdatesBase>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/messages.reportSpam"/></summary>
		public Task<bool> Messages_ReportSpam(InputPeer peer)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xCF1592DB);
				writer.WriteTLObject(peer);
				return "Messages_ReportSpam";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getPeerSettings"/></summary>
		public Task<PeerSettings> Messages_GetPeerSettings(InputPeer peer)
			=> CallAsync<PeerSettings>(writer =>
			{
				writer.Write(0x3672E09C);
				writer.WriteTLObject(peer);
				return "Messages_GetPeerSettings";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.report"/></summary>
		public Task<bool> Messages_Report(InputPeer peer, int[] id, ReportReason reason, string message)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x8953AB4E);
				writer.WriteTLObject(peer);
				writer.WriteTLVector(id);
				writer.WriteTLObject(reason);
				writer.WriteTLString(message);
				return "Messages_Report";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getChats"/></summary>
		public Task<Messages_ChatsBase> Messages_GetChats(long[] id)
			=> CallAsync<Messages_ChatsBase>(writer =>
			{
				writer.Write(0x49E9528F);
				writer.WriteTLVector(id);
				return "Messages_GetChats";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getFullChat"/></summary>
		public Task<Messages_ChatFull> Messages_GetFullChat(long chat_id)
			=> CallAsync<Messages_ChatFull>(writer =>
			{
				writer.Write(0xAEB00B34);
				writer.Write(chat_id);
				return "Messages_GetFullChat";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.editChatTitle"/></summary>
		public Task<UpdatesBase> Messages_EditChatTitle(long chat_id, string title)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x73783FFD);
				writer.Write(chat_id);
				writer.WriteTLString(title);
				return "Messages_EditChatTitle";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.editChatPhoto"/></summary>
		public Task<UpdatesBase> Messages_EditChatPhoto(long chat_id, InputChatPhotoBase photo)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x35DDD674);
				writer.Write(chat_id);
				writer.WriteTLObject(photo);
				return "Messages_EditChatPhoto";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.addChatUser"/></summary>
		public Task<UpdatesBase> Messages_AddChatUser(long chat_id, InputUserBase user_id, int fwd_limit)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xF24753E3);
				writer.Write(chat_id);
				writer.WriteTLObject(user_id);
				writer.Write(fwd_limit);
				return "Messages_AddChatUser";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.deleteChatUser"/></summary>
		public Task<UpdatesBase> Messages_DeleteChatUser(long chat_id, InputUserBase user_id, bool revoke_history = false)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xA2185CAB);
				writer.Write(revoke_history ? 0x1 : 0);
				writer.Write(chat_id);
				writer.WriteTLObject(user_id);
				return "Messages_DeleteChatUser";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.createChat"/></summary>
		public Task<UpdatesBase> Messages_CreateChat(InputUserBase[] users, string title)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x09CB126E);
				writer.WriteTLVector(users);
				writer.WriteTLString(title);
				return "Messages_CreateChat";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getDhConfig"/></summary>
		public Task<Messages_DhConfigBase> Messages_GetDhConfig(int version, int random_length)
			=> CallAsync<Messages_DhConfigBase>(writer =>
			{
				writer.Write(0x26CF8950);
				writer.Write(version);
				writer.Write(random_length);
				return "Messages_GetDhConfig";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.requestEncryption"/></summary>
		public Task<EncryptedChatBase> Messages_RequestEncryption(InputUserBase user_id, int random_id, byte[] g_a)
			=> CallAsync<EncryptedChatBase>(writer =>
			{
				writer.Write(0xF64DAF43);
				writer.WriteTLObject(user_id);
				writer.Write(random_id);
				writer.WriteTLBytes(g_a);
				return "Messages_RequestEncryption";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.acceptEncryption"/></summary>
		public Task<EncryptedChatBase> Messages_AcceptEncryption(InputEncryptedChat peer, byte[] g_b, long key_fingerprint)
			=> CallAsync<EncryptedChatBase>(writer =>
			{
				writer.Write(0x3DBC0415);
				writer.WriteTLObject(peer);
				writer.WriteTLBytes(g_b);
				writer.Write(key_fingerprint);
				return "Messages_AcceptEncryption";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.discardEncryption"/></summary>
		public Task<bool> Messages_DiscardEncryption(int chat_id, bool delete_history = false)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xF393AEA0);
				writer.Write(delete_history ? 0x1 : 0);
				writer.Write(chat_id);
				return "Messages_DiscardEncryption";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.setEncryptedTyping"/></summary>
		public Task<bool> Messages_SetEncryptedTyping(InputEncryptedChat peer, bool typing)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x791451ED);
				writer.WriteTLObject(peer);
				writer.Write(typing ? 0x997275B5 : 0xBC799737);
				return "Messages_SetEncryptedTyping";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.readEncryptedHistory"/></summary>
		public Task<bool> Messages_ReadEncryptedHistory(InputEncryptedChat peer, DateTime max_date)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x7F4B690A);
				writer.WriteTLObject(peer);
				writer.WriteTLStamp(max_date);
				return "Messages_ReadEncryptedHistory";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.sendEncrypted"/></summary>
		public Task<Messages_SentEncryptedMessage> Messages_SendEncrypted(InputEncryptedChat peer, long random_id, byte[] data, bool silent = false)
			=> CallAsync<Messages_SentEncryptedMessage>(writer =>
			{
				writer.Write(0x44FA7A15);
				writer.Write(silent ? 0x1 : 0);
				writer.WriteTLObject(peer);
				writer.Write(random_id);
				writer.WriteTLBytes(data);
				return "Messages_SendEncrypted";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.sendEncryptedFile"/></summary>
		public Task<Messages_SentEncryptedMessage> Messages_SendEncryptedFile(InputEncryptedChat peer, long random_id, byte[] data, InputEncryptedFileBase file, bool silent = false)
			=> CallAsync<Messages_SentEncryptedMessage>(writer =>
			{
				writer.Write(0x5559481D);
				writer.Write(silent ? 0x1 : 0);
				writer.WriteTLObject(peer);
				writer.Write(random_id);
				writer.WriteTLBytes(data);
				writer.WriteTLObject(file);
				return "Messages_SendEncryptedFile";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.sendEncryptedService"/></summary>
		public Task<Messages_SentEncryptedMessage> Messages_SendEncryptedService(InputEncryptedChat peer, long random_id, byte[] data)
			=> CallAsync<Messages_SentEncryptedMessage>(writer =>
			{
				writer.Write(0x32D439A4);
				writer.WriteTLObject(peer);
				writer.Write(random_id);
				writer.WriteTLBytes(data);
				return "Messages_SendEncryptedService";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.receivedQueue"/></summary>
		public Task<long[]> Messages_ReceivedQueue(int max_qts)
			=> CallAsync<long[]>(writer =>
			{
				writer.Write(0x55A5BB66);
				writer.Write(max_qts);
				return "Messages_ReceivedQueue";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.reportEncryptedSpam"/></summary>
		public Task<bool> Messages_ReportEncryptedSpam(InputEncryptedChat peer)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x4B0C8C0F);
				writer.WriteTLObject(peer);
				return "Messages_ReportEncryptedSpam";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.readMessageContents"/></summary>
		public Task<Messages_AffectedMessages> Messages_ReadMessageContents(int[] id)
			=> CallAsync<Messages_AffectedMessages>(writer =>
			{
				writer.Write(0x36A73F77);
				writer.WriteTLVector(id);
				return "Messages_ReadMessageContents";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getStickers"/></summary>
		public Task<Messages_StickersBase> Messages_GetStickers(string emoticon, long hash)
			=> CallAsync<Messages_StickersBase>(writer =>
			{
				writer.Write(0xD5A5D3A1);
				writer.WriteTLString(emoticon);
				writer.Write(hash);
				return "Messages_GetStickers";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getAllStickers"/></summary>
		public Task<Messages_AllStickersBase> Messages_GetAllStickers(long hash)
			=> CallAsync<Messages_AllStickersBase>(writer =>
			{
				writer.Write(0xB8A0A1A8);
				writer.Write(hash);
				return "Messages_GetAllStickers";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getWebPagePreview"/></summary>
		public Task<MessageMedia> Messages_GetWebPagePreview(string message, MessageEntity[] entities = null)
			=> CallAsync<MessageMedia>(writer =>
			{
				writer.Write(0x8B68B0CC);
				writer.Write(entities != null ? 0x8 : 0);
				writer.WriteTLString(message);
				if (entities != null)
					writer.WriteTLVector(entities);
				return "Messages_GetWebPagePreview";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.exportChatInvite"/></summary>
		public Task<ExportedChatInvite> Messages_ExportChatInvite(InputPeer peer, bool legacy_revoke_permanent = false, DateTime? expire_date = null, int? usage_limit = null)
			=> CallAsync<ExportedChatInvite>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/messages.checkChatInvite"/></summary>
		public Task<ChatInviteBase> Messages_CheckChatInvite(string hash)
			=> CallAsync<ChatInviteBase>(writer =>
			{
				writer.Write(0x3EADB1BB);
				writer.WriteTLString(hash);
				return "Messages_CheckChatInvite";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.importChatInvite"/></summary>
		public Task<UpdatesBase> Messages_ImportChatInvite(string hash)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x6C50051C);
				writer.WriteTLString(hash);
				return "Messages_ImportChatInvite";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getStickerSet"/></summary>
		public Task<Messages_StickerSet> Messages_GetStickerSet(InputStickerSet stickerset)
			=> CallAsync<Messages_StickerSet>(writer =>
			{
				writer.Write(0x2619A90E);
				writer.WriteTLObject(stickerset);
				return "Messages_GetStickerSet";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.installStickerSet"/></summary>
		public Task<Messages_StickerSetInstallResult> Messages_InstallStickerSet(InputStickerSet stickerset, bool archived)
			=> CallAsync<Messages_StickerSetInstallResult>(writer =>
			{
				writer.Write(0xC78FE460);
				writer.WriteTLObject(stickerset);
				writer.Write(archived ? 0x997275B5 : 0xBC799737);
				return "Messages_InstallStickerSet";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.uninstallStickerSet"/></summary>
		public Task<bool> Messages_UninstallStickerSet(InputStickerSet stickerset)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xF96E55DE);
				writer.WriteTLObject(stickerset);
				return "Messages_UninstallStickerSet";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.startBot"/></summary>
		public Task<UpdatesBase> Messages_StartBot(InputUserBase bot, InputPeer peer, long random_id, string start_param)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xE6DF7378);
				writer.WriteTLObject(bot);
				writer.WriteTLObject(peer);
				writer.Write(random_id);
				writer.WriteTLString(start_param);
				return "Messages_StartBot";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getMessagesViews"/></summary>
		public Task<Messages_MessageViews> Messages_GetMessagesViews(InputPeer peer, int[] id, bool increment)
			=> CallAsync<Messages_MessageViews>(writer =>
			{
				writer.Write(0x5784D3E1);
				writer.WriteTLObject(peer);
				writer.WriteTLVector(id);
				writer.Write(increment ? 0x997275B5 : 0xBC799737);
				return "Messages_GetMessagesViews";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.editChatAdmin"/></summary>
		public Task<bool> Messages_EditChatAdmin(long chat_id, InputUserBase user_id, bool is_admin)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xA85BD1C2);
				writer.Write(chat_id);
				writer.WriteTLObject(user_id);
				writer.Write(is_admin ? 0x997275B5 : 0xBC799737);
				return "Messages_EditChatAdmin";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.migrateChat"/></summary>
		public Task<UpdatesBase> Messages_MigrateChat(long chat_id)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xA2875319);
				writer.Write(chat_id);
				return "Messages_MigrateChat";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.searchGlobal"/></summary>
		public Task<Messages_MessagesBase> Messages_SearchGlobal(string q, MessagesFilter filter, DateTime min_date, DateTime max_date, int offset_rate, InputPeer offset_peer, int offset_id, int limit, int? folder_id = null)
			=> CallAsync<Messages_MessagesBase>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/messages.reorderStickerSets"/></summary>
		public Task<bool> Messages_ReorderStickerSets(long[] order, bool masks = false)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x78337739);
				writer.Write(masks ? 0x1 : 0);
				writer.WriteTLVector(order);
				return "Messages_ReorderStickerSets";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getDocumentByHash"/></summary>
		public Task<DocumentBase> Messages_GetDocumentByHash(byte[] sha256, int size, string mime_type)
			=> CallAsync<DocumentBase>(writer =>
			{
				writer.Write(0x338E2464);
				writer.WriteTLBytes(sha256);
				writer.Write(size);
				writer.WriteTLString(mime_type);
				return "Messages_GetDocumentByHash";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getSavedGifs"/></summary>
		public Task<Messages_SavedGifsBase> Messages_GetSavedGifs(long hash)
			=> CallAsync<Messages_SavedGifsBase>(writer =>
			{
				writer.Write(0x5CF09635);
				writer.Write(hash);
				return "Messages_GetSavedGifs";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.saveGif"/></summary>
		public Task<bool> Messages_SaveGif(InputDocumentBase id, bool unsave)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x327A30CB);
				writer.WriteTLObject(id);
				writer.Write(unsave ? 0x997275B5 : 0xBC799737);
				return "Messages_SaveGif";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getInlineBotResults"/></summary>
		public Task<Messages_BotResults> Messages_GetInlineBotResults(InputUserBase bot, InputPeer peer, string query, string offset, InputGeoPointBase geo_point = null)
			=> CallAsync<Messages_BotResults>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/messages.setInlineBotResults"/></summary>
		public Task<bool> Messages_SetInlineBotResults(long query_id, InputBotInlineResultBase[] results, DateTime cache_time, bool gallery = false, bool private_ = false, string next_offset = null, InlineBotSwitchPM switch_pm = null)
			=> CallAsync<bool>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/messages.sendInlineBotResult"/></summary>
		public Task<UpdatesBase> Messages_SendInlineBotResult(InputPeer peer, long random_id, long query_id, string id, bool silent = false, bool background = false, bool clear_draft = false, bool hide_via = false, int? reply_to_msg_id = null, DateTime? schedule_date = null)
			=> CallAsync<UpdatesBase>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/messages.getMessageEditData"/></summary>
		public Task<Messages_MessageEditData> Messages_GetMessageEditData(InputPeer peer, int id)
			=> CallAsync<Messages_MessageEditData>(writer =>
			{
				writer.Write(0xFDA68D36);
				writer.WriteTLObject(peer);
				writer.Write(id);
				return "Messages_GetMessageEditData";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.editMessage"/></summary>
		public Task<UpdatesBase> Messages_EditMessage(InputPeer peer, int id, bool no_webpage = false, string message = null, InputMedia media = null, ReplyMarkup reply_markup = null, MessageEntity[] entities = null, DateTime? schedule_date = null)
			=> CallAsync<UpdatesBase>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/messages.editInlineBotMessage"/></summary>
		public Task<bool> Messages_EditInlineBotMessage(InputBotInlineMessageIDBase id, bool no_webpage = false, string message = null, InputMedia media = null, ReplyMarkup reply_markup = null, MessageEntity[] entities = null)
			=> CallAsync<bool>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/messages.getBotCallbackAnswer"/></summary>
		public Task<Messages_BotCallbackAnswer> Messages_GetBotCallbackAnswer(InputPeer peer, int msg_id, bool game = false, byte[] data = null, InputCheckPasswordSRPBase password = null)
			=> CallAsync<Messages_BotCallbackAnswer>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/messages.setBotCallbackAnswer"/></summary>
		public Task<bool> Messages_SetBotCallbackAnswer(long query_id, DateTime cache_time, bool alert = false, string message = null, string url = null)
			=> CallAsync<bool>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/messages.getPeerDialogs"/></summary>
		public Task<Messages_PeerDialogs> Messages_GetPeerDialogs(InputDialogPeerBase[] peers)
			=> CallAsync<Messages_PeerDialogs>(writer =>
			{
				writer.Write(0xE470BCFD);
				writer.WriteTLVector(peers);
				return "Messages_GetPeerDialogs";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.saveDraft"/></summary>
		public Task<bool> Messages_SaveDraft(InputPeer peer, string message, bool no_webpage = false, int? reply_to_msg_id = null, MessageEntity[] entities = null)
			=> CallAsync<bool>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/messages.getAllDrafts"/></summary>
		public Task<UpdatesBase> Messages_GetAllDrafts()
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x6A3F8D65);
				return "Messages_GetAllDrafts";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getFeaturedStickers"/></summary>
		public Task<Messages_FeaturedStickersBase> Messages_GetFeaturedStickers(long hash)
			=> CallAsync<Messages_FeaturedStickersBase>(writer =>
			{
				writer.Write(0x64780B14);
				writer.Write(hash);
				return "Messages_GetFeaturedStickers";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.readFeaturedStickers"/></summary>
		public Task<bool> Messages_ReadFeaturedStickers(long[] id)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x5B118126);
				writer.WriteTLVector(id);
				return "Messages_ReadFeaturedStickers";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getRecentStickers"/></summary>
		public Task<Messages_RecentStickersBase> Messages_GetRecentStickers(long hash, bool attached = false)
			=> CallAsync<Messages_RecentStickersBase>(writer =>
			{
				writer.Write(0x9DA9403B);
				writer.Write(attached ? 0x1 : 0);
				writer.Write(hash);
				return "Messages_GetRecentStickers";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.saveRecentSticker"/></summary>
		public Task<bool> Messages_SaveRecentSticker(InputDocumentBase id, bool unsave, bool attached = false)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x392718F8);
				writer.Write(attached ? 0x1 : 0);
				writer.WriteTLObject(id);
				writer.Write(unsave ? 0x997275B5 : 0xBC799737);
				return "Messages_SaveRecentSticker";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.clearRecentStickers"/></summary>
		public Task<bool> Messages_ClearRecentStickers(bool attached = false)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x8999602D);
				writer.Write(attached ? 0x1 : 0);
				return "Messages_ClearRecentStickers";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getArchivedStickers"/></summary>
		public Task<Messages_ArchivedStickers> Messages_GetArchivedStickers(long offset_id, int limit, bool masks = false)
			=> CallAsync<Messages_ArchivedStickers>(writer =>
			{
				writer.Write(0x57F17692);
				writer.Write(masks ? 0x1 : 0);
				writer.Write(offset_id);
				writer.Write(limit);
				return "Messages_GetArchivedStickers";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getMaskStickers"/></summary>
		public Task<Messages_AllStickersBase> Messages_GetMaskStickers(long hash)
			=> CallAsync<Messages_AllStickersBase>(writer =>
			{
				writer.Write(0x640F82B8);
				writer.Write(hash);
				return "Messages_GetMaskStickers";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getAttachedStickers"/></summary>
		public Task<StickerSetCoveredBase[]> Messages_GetAttachedStickers(InputStickeredMedia media)
			=> CallAsync<StickerSetCoveredBase[]>(writer =>
			{
				writer.Write(0xCC5B67CC);
				writer.WriteTLObject(media);
				return "Messages_GetAttachedStickers";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.setGameScore"/></summary>
		public Task<UpdatesBase> Messages_SetGameScore(InputPeer peer, int id, InputUserBase user_id, int score, bool edit_message = false, bool force = false)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x8EF8ECC0);
				writer.Write((edit_message ? 0x1 : 0) | (force ? 0x2 : 0));
				writer.WriteTLObject(peer);
				writer.Write(id);
				writer.WriteTLObject(user_id);
				writer.Write(score);
				return "Messages_SetGameScore";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.setInlineGameScore"/></summary>
		public Task<bool> Messages_SetInlineGameScore(InputBotInlineMessageIDBase id, InputUserBase user_id, int score, bool edit_message = false, bool force = false)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x15AD9F64);
				writer.Write((edit_message ? 0x1 : 0) | (force ? 0x2 : 0));
				writer.WriteTLObject(id);
				writer.WriteTLObject(user_id);
				writer.Write(score);
				return "Messages_SetInlineGameScore";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getGameHighScores"/></summary>
		public Task<Messages_HighScores> Messages_GetGameHighScores(InputPeer peer, int id, InputUserBase user_id)
			=> CallAsync<Messages_HighScores>(writer =>
			{
				writer.Write(0xE822649D);
				writer.WriteTLObject(peer);
				writer.Write(id);
				writer.WriteTLObject(user_id);
				return "Messages_GetGameHighScores";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getInlineGameHighScores"/></summary>
		public Task<Messages_HighScores> Messages_GetInlineGameHighScores(InputBotInlineMessageIDBase id, InputUserBase user_id)
			=> CallAsync<Messages_HighScores>(writer =>
			{
				writer.Write(0x0F635E1B);
				writer.WriteTLObject(id);
				writer.WriteTLObject(user_id);
				return "Messages_GetInlineGameHighScores";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getCommonChats"/></summary>
		public Task<Messages_ChatsBase> Messages_GetCommonChats(InputUserBase user_id, long max_id, int limit)
			=> CallAsync<Messages_ChatsBase>(writer =>
			{
				writer.Write(0xE40CA104);
				writer.WriteTLObject(user_id);
				writer.Write(max_id);
				writer.Write(limit);
				return "Messages_GetCommonChats";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getAllChats"/></summary>
		public Task<Messages_ChatsBase> Messages_GetAllChats(long[] except_ids)
			=> CallAsync<Messages_ChatsBase>(writer =>
			{
				writer.Write(0x875F74BE);
				writer.WriteTLVector(except_ids);
				return "Messages_GetAllChats";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getWebPage"/></summary>
		public Task<WebPageBase> Messages_GetWebPage(string url, int hash)
			=> CallAsync<WebPageBase>(writer =>
			{
				writer.Write(0x32CA8F91);
				writer.WriteTLString(url);
				writer.Write(hash);
				return "Messages_GetWebPage";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.toggleDialogPin"/></summary>
		public Task<bool> Messages_ToggleDialogPin(InputDialogPeerBase peer, bool pinned = false)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xA731E257);
				writer.Write(pinned ? 0x1 : 0);
				writer.WriteTLObject(peer);
				return "Messages_ToggleDialogPin";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.reorderPinnedDialogs"/></summary>
		public Task<bool> Messages_ReorderPinnedDialogs(int folder_id, InputDialogPeerBase[] order, bool force = false)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x3B1ADF37);
				writer.Write(force ? 0x1 : 0);
				writer.Write(folder_id);
				writer.WriteTLVector(order);
				return "Messages_ReorderPinnedDialogs";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getPinnedDialogs"/></summary>
		public Task<Messages_PeerDialogs> Messages_GetPinnedDialogs(int folder_id)
			=> CallAsync<Messages_PeerDialogs>(writer =>
			{
				writer.Write(0xD6B94DF2);
				writer.Write(folder_id);
				return "Messages_GetPinnedDialogs";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.setBotShippingResults"/></summary>
		public Task<bool> Messages_SetBotShippingResults(long query_id, string error = null, ShippingOption[] shipping_options = null)
			=> CallAsync<bool>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/messages.setBotPrecheckoutResults"/></summary>
		public Task<bool> Messages_SetBotPrecheckoutResults(long query_id, bool success = false, string error = null)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x09C2DD95);
				writer.Write((success ? 0x2 : 0) | (error != null ? 0x1 : 0));
				writer.Write(query_id);
				if (error != null)
					writer.WriteTLString(error);
				return "Messages_SetBotPrecheckoutResults";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.uploadMedia"/></summary>
		public Task<MessageMedia> Messages_UploadMedia(InputPeer peer, InputMedia media)
			=> CallAsync<MessageMedia>(writer =>
			{
				writer.Write(0x519BC2B1);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(media);
				return "Messages_UploadMedia";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.sendScreenshotNotification"/></summary>
		public Task<UpdatesBase> Messages_SendScreenshotNotification(InputPeer peer, int reply_to_msg_id, long random_id)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xC97DF020);
				writer.WriteTLObject(peer);
				writer.Write(reply_to_msg_id);
				writer.Write(random_id);
				return "Messages_SendScreenshotNotification";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getFavedStickers"/></summary>
		public Task<Messages_FavedStickersBase> Messages_GetFavedStickers(long hash)
			=> CallAsync<Messages_FavedStickersBase>(writer =>
			{
				writer.Write(0x04F1AAA9);
				writer.Write(hash);
				return "Messages_GetFavedStickers";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.faveSticker"/></summary>
		public Task<bool> Messages_FaveSticker(InputDocumentBase id, bool unfave)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xB9FFC55B);
				writer.WriteTLObject(id);
				writer.Write(unfave ? 0x997275B5 : 0xBC799737);
				return "Messages_FaveSticker";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getUnreadMentions"/></summary>
		public Task<Messages_MessagesBase> Messages_GetUnreadMentions(InputPeer peer, int offset_id, int add_offset, int limit, int max_id, int min_id)
			=> CallAsync<Messages_MessagesBase>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/messages.readMentions"/></summary>
		public Task<Messages_AffectedHistory> Messages_ReadMentions(InputPeer peer)
			=> CallAsync<Messages_AffectedHistory>(writer =>
			{
				writer.Write(0x0F0189D3);
				writer.WriteTLObject(peer);
				return "Messages_ReadMentions";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getRecentLocations"/></summary>
		public Task<Messages_MessagesBase> Messages_GetRecentLocations(InputPeer peer, int limit, long hash)
			=> CallAsync<Messages_MessagesBase>(writer =>
			{
				writer.Write(0x702A40E0);
				writer.WriteTLObject(peer);
				writer.Write(limit);
				writer.Write(hash);
				return "Messages_GetRecentLocations";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.sendMultiMedia"/></summary>
		public Task<UpdatesBase> Messages_SendMultiMedia(InputPeer peer, InputSingleMedia[] multi_media, bool silent = false, bool background = false, bool clear_draft = false, int? reply_to_msg_id = null, DateTime? schedule_date = null)
			=> CallAsync<UpdatesBase>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/messages.uploadEncryptedFile"/></summary>
		public Task<EncryptedFileBase> Messages_UploadEncryptedFile(InputEncryptedChat peer, InputEncryptedFileBase file)
			=> CallAsync<EncryptedFileBase>(writer =>
			{
				writer.Write(0x5057C497);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(file);
				return "Messages_UploadEncryptedFile";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.searchStickerSets"/></summary>
		public Task<Messages_FoundStickerSetsBase> Messages_SearchStickerSets(string q, long hash, bool exclude_featured = false)
			=> CallAsync<Messages_FoundStickerSetsBase>(writer =>
			{
				writer.Write(0x35705B8A);
				writer.Write(exclude_featured ? 0x1 : 0);
				writer.WriteTLString(q);
				writer.Write(hash);
				return "Messages_SearchStickerSets";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getSplitRanges"/></summary>
		public Task<MessageRange[]> Messages_GetSplitRanges()
			=> CallAsync<MessageRange[]>(writer =>
			{
				writer.Write(0x1CFF7E08);
				return "Messages_GetSplitRanges";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.markDialogUnread"/></summary>
		public Task<bool> Messages_MarkDialogUnread(InputDialogPeerBase peer, bool unread = false)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xC286D98F);
				writer.Write(unread ? 0x1 : 0);
				writer.WriteTLObject(peer);
				return "Messages_MarkDialogUnread";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getDialogUnreadMarks"/></summary>
		public Task<DialogPeerBase[]> Messages_GetDialogUnreadMarks()
			=> CallAsync<DialogPeerBase[]>(writer =>
			{
				writer.Write(0x22E24E22);
				return "Messages_GetDialogUnreadMarks";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.clearAllDrafts"/></summary>
		public Task<bool> Messages_ClearAllDrafts()
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x7E58EE9C);
				return "Messages_ClearAllDrafts";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.updatePinnedMessage"/></summary>
		public Task<UpdatesBase> Messages_UpdatePinnedMessage(InputPeer peer, int id, bool silent = false, bool unpin = false, bool pm_oneside = false)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xD2AAF7EC);
				writer.Write((silent ? 0x1 : 0) | (unpin ? 0x2 : 0) | (pm_oneside ? 0x4 : 0));
				writer.WriteTLObject(peer);
				writer.Write(id);
				return "Messages_UpdatePinnedMessage";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.sendVote"/></summary>
		public Task<UpdatesBase> Messages_SendVote(InputPeer peer, int msg_id, byte[][] options)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x10EA6184);
				writer.WriteTLObject(peer);
				writer.Write(msg_id);
				writer.WriteTLVector(options);
				return "Messages_SendVote";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getPollResults"/></summary>
		public Task<UpdatesBase> Messages_GetPollResults(InputPeer peer, int msg_id)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x73BB643B);
				writer.WriteTLObject(peer);
				writer.Write(msg_id);
				return "Messages_GetPollResults";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getOnlines"/></summary>
		public Task<ChatOnlines> Messages_GetOnlines(InputPeer peer)
			=> CallAsync<ChatOnlines>(writer =>
			{
				writer.Write(0x6E2BE050);
				writer.WriteTLObject(peer);
				return "Messages_GetOnlines";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getStatsURL"/></summary>
		public Task<StatsURL> Messages_GetStatsURL(InputPeer peer, string params_, bool dark = false)
			=> CallAsync<StatsURL>(writer =>
			{
				writer.Write(0x812C2AE6);
				writer.Write(dark ? 0x1 : 0);
				writer.WriteTLObject(peer);
				writer.WriteTLString(params_);
				return "Messages_GetStatsURL";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.editChatAbout"/></summary>
		public Task<bool> Messages_EditChatAbout(InputPeer peer, string about)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xDEF60797);
				writer.WriteTLObject(peer);
				writer.WriteTLString(about);
				return "Messages_EditChatAbout";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.editChatDefaultBannedRights"/></summary>
		public Task<UpdatesBase> Messages_EditChatDefaultBannedRights(InputPeer peer, ChatBannedRights banned_rights)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xA5866B41);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(banned_rights);
				return "Messages_EditChatDefaultBannedRights";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getEmojiKeywords"/></summary>
		public Task<EmojiKeywordsDifference> Messages_GetEmojiKeywords(string lang_code)
			=> CallAsync<EmojiKeywordsDifference>(writer =>
			{
				writer.Write(0x35A0E062);
				writer.WriteTLString(lang_code);
				return "Messages_GetEmojiKeywords";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getEmojiKeywordsDifference"/></summary>
		public Task<EmojiKeywordsDifference> Messages_GetEmojiKeywordsDifference(string lang_code, int from_version)
			=> CallAsync<EmojiKeywordsDifference>(writer =>
			{
				writer.Write(0x1508B6AF);
				writer.WriteTLString(lang_code);
				writer.Write(from_version);
				return "Messages_GetEmojiKeywordsDifference";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getEmojiKeywordsLanguages"/></summary>
		public Task<EmojiLanguage[]> Messages_GetEmojiKeywordsLanguages(string[] lang_codes)
			=> CallAsync<EmojiLanguage[]>(writer =>
			{
				writer.Write(0x4E9963B2);
				writer.WriteTLVector(lang_codes);
				return "Messages_GetEmojiKeywordsLanguages";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getEmojiURL"/></summary>
		public Task<EmojiURL> Messages_GetEmojiURL(string lang_code)
			=> CallAsync<EmojiURL>(writer =>
			{
				writer.Write(0xD5B10C26);
				writer.WriteTLString(lang_code);
				return "Messages_GetEmojiURL";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getSearchCounters"/></summary>
		public Task<Messages_SearchCounter[]> Messages_GetSearchCounters(InputPeer peer, MessagesFilter[] filters)
			=> CallAsync<Messages_SearchCounter[]>(writer =>
			{
				writer.Write(0x732EEF00);
				writer.WriteTLObject(peer);
				writer.WriteTLVector(filters);
				return "Messages_GetSearchCounters";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.requestUrlAuth"/></summary>
		public Task<UrlAuthResult> Messages_RequestUrlAuth(InputPeer peer = null, int? msg_id = null, int? button_id = null, string url = null)
			=> CallAsync<UrlAuthResult>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/messages.acceptUrlAuth"/></summary>
		public Task<UrlAuthResult> Messages_AcceptUrlAuth(bool write_allowed = false, InputPeer peer = null, int? msg_id = null, int? button_id = null, string url = null)
			=> CallAsync<UrlAuthResult>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/messages.hidePeerSettingsBar"/></summary>
		public Task<bool> Messages_HidePeerSettingsBar(InputPeer peer)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x4FACB138);
				writer.WriteTLObject(peer);
				return "Messages_HidePeerSettingsBar";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getScheduledHistory"/></summary>
		public Task<Messages_MessagesBase> Messages_GetScheduledHistory(InputPeer peer, long hash)
			=> CallAsync<Messages_MessagesBase>(writer =>
			{
				writer.Write(0xF516760B);
				writer.WriteTLObject(peer);
				writer.Write(hash);
				return "Messages_GetScheduledHistory";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getScheduledMessages"/></summary>
		public Task<Messages_MessagesBase> Messages_GetScheduledMessages(InputPeer peer, int[] id)
			=> CallAsync<Messages_MessagesBase>(writer =>
			{
				writer.Write(0xBDBB0464);
				writer.WriteTLObject(peer);
				writer.WriteTLVector(id);
				return "Messages_GetScheduledMessages";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.sendScheduledMessages"/></summary>
		public Task<UpdatesBase> Messages_SendScheduledMessages(InputPeer peer, int[] id)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xBD38850A);
				writer.WriteTLObject(peer);
				writer.WriteTLVector(id);
				return "Messages_SendScheduledMessages";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.deleteScheduledMessages"/></summary>
		public Task<UpdatesBase> Messages_DeleteScheduledMessages(InputPeer peer, int[] id)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x59AE2B16);
				writer.WriteTLObject(peer);
				writer.WriteTLVector(id);
				return "Messages_DeleteScheduledMessages";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getPollVotes"/></summary>
		public Task<Messages_VotesList> Messages_GetPollVotes(InputPeer peer, int id, int limit, byte[] option = null, string offset = null)
			=> CallAsync<Messages_VotesList>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/messages.toggleStickerSets"/></summary>
		public Task<bool> Messages_ToggleStickerSets(InputStickerSet[] stickersets, bool uninstall = false, bool archive = false, bool unarchive = false)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xB5052FEA);
				writer.Write((uninstall ? 0x1 : 0) | (archive ? 0x2 : 0) | (unarchive ? 0x4 : 0));
				writer.WriteTLVector(stickersets);
				return "Messages_ToggleStickerSets";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getDialogFilters"/></summary>
		public Task<DialogFilter[]> Messages_GetDialogFilters()
			=> CallAsync<DialogFilter[]>(writer =>
			{
				writer.Write(0xF19ED96D);
				return "Messages_GetDialogFilters";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getSuggestedDialogFilters"/></summary>
		public Task<DialogFilterSuggested[]> Messages_GetSuggestedDialogFilters()
			=> CallAsync<DialogFilterSuggested[]>(writer =>
			{
				writer.Write(0xA29CD42C);
				return "Messages_GetSuggestedDialogFilters";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.updateDialogFilter"/></summary>
		public Task<bool> Messages_UpdateDialogFilter(int id, DialogFilter filter = null)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x1AD4A04A);
				writer.Write(filter != null ? 0x1 : 0);
				writer.Write(id);
				if (filter != null)
					writer.WriteTLObject(filter);
				return "Messages_UpdateDialogFilter";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.updateDialogFiltersOrder"/></summary>
		public Task<bool> Messages_UpdateDialogFiltersOrder(int[] order)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xC563C1E4);
				writer.WriteTLVector(order);
				return "Messages_UpdateDialogFiltersOrder";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getOldFeaturedStickers"/></summary>
		public Task<Messages_FeaturedStickersBase> Messages_GetOldFeaturedStickers(int offset, int limit, long hash)
			=> CallAsync<Messages_FeaturedStickersBase>(writer =>
			{
				writer.Write(0x7ED094A1);
				writer.Write(offset);
				writer.Write(limit);
				writer.Write(hash);
				return "Messages_GetOldFeaturedStickers";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getReplies"/></summary>
		public Task<Messages_MessagesBase> Messages_GetReplies(InputPeer peer, int msg_id, int offset_id, DateTime offset_date, int add_offset, int limit, int max_id, int min_id, long hash)
			=> CallAsync<Messages_MessagesBase>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/messages.getDiscussionMessage"/></summary>
		public Task<Messages_DiscussionMessage> Messages_GetDiscussionMessage(InputPeer peer, int msg_id)
			=> CallAsync<Messages_DiscussionMessage>(writer =>
			{
				writer.Write(0x446972FD);
				writer.WriteTLObject(peer);
				writer.Write(msg_id);
				return "Messages_GetDiscussionMessage";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.readDiscussion"/></summary>
		public Task<bool> Messages_ReadDiscussion(InputPeer peer, int msg_id, int read_max_id)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xF731A9F4);
				writer.WriteTLObject(peer);
				writer.Write(msg_id);
				writer.Write(read_max_id);
				return "Messages_ReadDiscussion";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.unpinAllMessages"/></summary>
		public Task<Messages_AffectedHistory> Messages_UnpinAllMessages(InputPeer peer)
			=> CallAsync<Messages_AffectedHistory>(writer =>
			{
				writer.Write(0xF025BC8B);
				writer.WriteTLObject(peer);
				return "Messages_UnpinAllMessages";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.deleteChat"/></summary>
		public Task<bool> Messages_DeleteChat(long chat_id)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x5BD0EE50);
				writer.Write(chat_id);
				return "Messages_DeleteChat";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.deletePhoneCallHistory"/></summary>
		public Task<Messages_AffectedFoundMessages> Messages_DeletePhoneCallHistory(bool revoke = false)
			=> CallAsync<Messages_AffectedFoundMessages>(writer =>
			{
				writer.Write(0xF9CBE409);
				writer.Write(revoke ? 0x1 : 0);
				return "Messages_DeletePhoneCallHistory";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.checkHistoryImport"/></summary>
		public Task<Messages_HistoryImportParsed> Messages_CheckHistoryImport(string import_head)
			=> CallAsync<Messages_HistoryImportParsed>(writer =>
			{
				writer.Write(0x43FE19F3);
				writer.WriteTLString(import_head);
				return "Messages_CheckHistoryImport";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.initHistoryImport"/></summary>
		public Task<Messages_HistoryImport> Messages_InitHistoryImport(InputPeer peer, InputFileBase file, int media_count)
			=> CallAsync<Messages_HistoryImport>(writer =>
			{
				writer.Write(0x34090C3B);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(file);
				writer.Write(media_count);
				return "Messages_InitHistoryImport";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.uploadImportedMedia"/></summary>
		public Task<MessageMedia> Messages_UploadImportedMedia(InputPeer peer, long import_id, string file_name, InputMedia media)
			=> CallAsync<MessageMedia>(writer =>
			{
				writer.Write(0x2A862092);
				writer.WriteTLObject(peer);
				writer.Write(import_id);
				writer.WriteTLString(file_name);
				writer.WriteTLObject(media);
				return "Messages_UploadImportedMedia";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.startHistoryImport"/></summary>
		public Task<bool> Messages_StartHistoryImport(InputPeer peer, long import_id)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xB43DF344);
				writer.WriteTLObject(peer);
				writer.Write(import_id);
				return "Messages_StartHistoryImport";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getExportedChatInvites"/></summary>
		public Task<Messages_ExportedChatInvites> Messages_GetExportedChatInvites(InputPeer peer, InputUserBase admin_id, int limit, bool revoked = false, DateTime? offset_date = null, string offset_link = null)
			=> CallAsync<Messages_ExportedChatInvites>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/messages.getExportedChatInvite"/></summary>
		public Task<Messages_ExportedChatInviteBase> Messages_GetExportedChatInvite(InputPeer peer, string link)
			=> CallAsync<Messages_ExportedChatInviteBase>(writer =>
			{
				writer.Write(0x73746F5C);
				writer.WriteTLObject(peer);
				writer.WriteTLString(link);
				return "Messages_GetExportedChatInvite";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.editExportedChatInvite"/></summary>
		public Task<Messages_ExportedChatInviteBase> Messages_EditExportedChatInvite(InputPeer peer, string link, bool revoked = false, DateTime? expire_date = null, int? usage_limit = null)
			=> CallAsync<Messages_ExportedChatInviteBase>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/messages.deleteRevokedExportedChatInvites"/></summary>
		public Task<bool> Messages_DeleteRevokedExportedChatInvites(InputPeer peer, InputUserBase admin_id)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x56987BD5);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(admin_id);
				return "Messages_DeleteRevokedExportedChatInvites";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.deleteExportedChatInvite"/></summary>
		public Task<bool> Messages_DeleteExportedChatInvite(InputPeer peer, string link)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xD464A42B);
				writer.WriteTLObject(peer);
				writer.WriteTLString(link);
				return "Messages_DeleteExportedChatInvite";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getAdminsWithInvites"/></summary>
		public Task<Messages_ChatAdminsWithInvites> Messages_GetAdminsWithInvites(InputPeer peer)
			=> CallAsync<Messages_ChatAdminsWithInvites>(writer =>
			{
				writer.Write(0x3920E6EF);
				writer.WriteTLObject(peer);
				return "Messages_GetAdminsWithInvites";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getChatInviteImporters"/></summary>
		public Task<Messages_ChatInviteImporters> Messages_GetChatInviteImporters(InputPeer peer, string link, DateTime offset_date, InputUserBase offset_user, int limit)
			=> CallAsync<Messages_ChatInviteImporters>(writer =>
			{
				writer.Write(0x26FB7289);
				writer.WriteTLObject(peer);
				writer.WriteTLString(link);
				writer.WriteTLStamp(offset_date);
				writer.WriteTLObject(offset_user);
				writer.Write(limit);
				return "Messages_GetChatInviteImporters";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.setHistoryTTL"/></summary>
		public Task<UpdatesBase> Messages_SetHistoryTTL(InputPeer peer, int period)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xB80E5FE4);
				writer.WriteTLObject(peer);
				writer.Write(period);
				return "Messages_SetHistoryTTL";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.checkHistoryImportPeer"/></summary>
		public Task<Messages_CheckedHistoryImportPeer> Messages_CheckHistoryImportPeer(InputPeer peer)
			=> CallAsync<Messages_CheckedHistoryImportPeer>(writer =>
			{
				writer.Write(0x5DC60F03);
				writer.WriteTLObject(peer);
				return "Messages_CheckHistoryImportPeer";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.setChatTheme"/></summary>
		public Task<UpdatesBase> Messages_SetChatTheme(InputPeer peer, string emoticon)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xE63BE13F);
				writer.WriteTLObject(peer);
				writer.WriteTLString(emoticon);
				return "Messages_SetChatTheme";
			});

		///<summary>See <a href="https://core.telegram.org/method/messages.getMessageReadParticipants"/></summary>
		public Task<long[]> Messages_GetMessageReadParticipants(InputPeer peer, int msg_id)
			=> CallAsync<long[]>(writer =>
			{
				writer.Write(0x2C6F97B7);
				writer.WriteTLObject(peer);
				writer.Write(msg_id);
				return "Messages_GetMessageReadParticipants";
			});

		///<summary>See <a href="https://core.telegram.org/method/updates.getState"/></summary>
		public Task<Updates_State> Updates_GetState()
			=> CallAsync<Updates_State>(writer =>
			{
				writer.Write(0xEDD4882A);
				return "Updates_GetState";
			});

		///<summary>See <a href="https://core.telegram.org/method/updates.getDifference"/></summary>
		public Task<Updates_DifferenceBase> Updates_GetDifference(int pts, DateTime date, int qts, int? pts_total_limit = null)
			=> CallAsync<Updates_DifferenceBase>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/updates.getChannelDifference"/></summary>
		public Task<Updates_ChannelDifferenceBase> Updates_GetChannelDifference(InputChannelBase channel, ChannelMessagesFilterBase filter, int pts, int limit, bool force = false)
			=> CallAsync<Updates_ChannelDifferenceBase>(writer =>
			{
				writer.Write(0x03173D78);
				writer.Write(force ? 0x1 : 0);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(filter);
				writer.Write(pts);
				writer.Write(limit);
				return "Updates_GetChannelDifference";
			});

		///<summary>See <a href="https://core.telegram.org/method/photos.updateProfilePhoto"/></summary>
		public Task<Photos_Photo> Photos_UpdateProfilePhoto(InputPhotoBase id)
			=> CallAsync<Photos_Photo>(writer =>
			{
				writer.Write(0x72D4742C);
				writer.WriteTLObject(id);
				return "Photos_UpdateProfilePhoto";
			});

		///<summary>See <a href="https://core.telegram.org/method/photos.uploadProfilePhoto"/></summary>
		public Task<Photos_Photo> Photos_UploadProfilePhoto(InputFileBase file = null, InputFileBase video = null, double? video_start_ts = null)
			=> CallAsync<Photos_Photo>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/photos.deletePhotos"/></summary>
		public Task<long[]> Photos_DeletePhotos(InputPhotoBase[] id)
			=> CallAsync<long[]>(writer =>
			{
				writer.Write(0x87CF7F2F);
				writer.WriteTLVector(id);
				return "Photos_DeletePhotos";
			});

		///<summary>See <a href="https://core.telegram.org/method/photos.getUserPhotos"/></summary>
		public Task<Photos_PhotosBase> Photos_GetUserPhotos(InputUserBase user_id, int offset, long max_id, int limit)
			=> CallAsync<Photos_PhotosBase>(writer =>
			{
				writer.Write(0x91CD32A8);
				writer.WriteTLObject(user_id);
				writer.Write(offset);
				writer.Write(max_id);
				writer.Write(limit);
				return "Photos_GetUserPhotos";
			});

		///<summary>See <a href="https://core.telegram.org/method/upload.saveFilePart"/></summary>
		public Task<bool> Upload_SaveFilePart(long file_id, int file_part, byte[] bytes)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xB304A621);
				writer.Write(file_id);
				writer.Write(file_part);
				writer.WriteTLBytes(bytes);
				return "Upload_SaveFilePart";
			});

		///<summary>See <a href="https://core.telegram.org/method/upload.getFile"/></summary>
		public Task<Upload_FileBase> Upload_GetFile(InputFileLocationBase location, int offset, int limit, bool precise = false, bool cdn_supported = false)
			=> CallAsync<Upload_FileBase>(writer =>
			{
				writer.Write(0xB15A9AFC);
				writer.Write((precise ? 0x1 : 0) | (cdn_supported ? 0x2 : 0));
				writer.WriteTLObject(location);
				writer.Write(offset);
				writer.Write(limit);
				return "Upload_GetFile";
			});

		///<summary>See <a href="https://core.telegram.org/method/upload.saveBigFilePart"/></summary>
		public Task<bool> Upload_SaveBigFilePart(long file_id, int file_part, int file_total_parts, byte[] bytes)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xDE7B673D);
				writer.Write(file_id);
				writer.Write(file_part);
				writer.Write(file_total_parts);
				writer.WriteTLBytes(bytes);
				return "Upload_SaveBigFilePart";
			});

		///<summary>See <a href="https://core.telegram.org/method/upload.getWebFile"/></summary>
		public Task<Upload_WebFile> Upload_GetWebFile(InputWebFileLocationBase location, int offset, int limit)
			=> CallAsync<Upload_WebFile>(writer =>
			{
				writer.Write(0x24E6818D);
				writer.WriteTLObject(location);
				writer.Write(offset);
				writer.Write(limit);
				return "Upload_GetWebFile";
			});

		///<summary>See <a href="https://core.telegram.org/method/upload.getCdnFile"/></summary>
		public Task<Upload_CdnFileBase> Upload_GetCdnFile(byte[] file_token, int offset, int limit)
			=> CallAsync<Upload_CdnFileBase>(writer =>
			{
				writer.Write(0x2000BCC3);
				writer.WriteTLBytes(file_token);
				writer.Write(offset);
				writer.Write(limit);
				return "Upload_GetCdnFile";
			});

		///<summary>See <a href="https://core.telegram.org/method/upload.reuploadCdnFile"/></summary>
		public Task<FileHash[]> Upload_ReuploadCdnFile(byte[] file_token, byte[] request_token)
			=> CallAsync<FileHash[]>(writer =>
			{
				writer.Write(0x9B2754A8);
				writer.WriteTLBytes(file_token);
				writer.WriteTLBytes(request_token);
				return "Upload_ReuploadCdnFile";
			});

		///<summary>See <a href="https://core.telegram.org/method/upload.getCdnFileHashes"/></summary>
		public Task<FileHash[]> Upload_GetCdnFileHashes(byte[] file_token, int offset)
			=> CallAsync<FileHash[]>(writer =>
			{
				writer.Write(0x4DA54231);
				writer.WriteTLBytes(file_token);
				writer.Write(offset);
				return "Upload_GetCdnFileHashes";
			});

		///<summary>See <a href="https://core.telegram.org/method/upload.getFileHashes"/></summary>
		public Task<FileHash[]> Upload_GetFileHashes(InputFileLocationBase location, int offset)
			=> CallAsync<FileHash[]>(writer =>
			{
				writer.Write(0xC7025931);
				writer.WriteTLObject(location);
				writer.Write(offset);
				return "Upload_GetFileHashes";
			});

		///<summary>See <a href="https://core.telegram.org/method/help.getConfig"/></summary>
		public Task<Config> Help_GetConfig() => CallAsync<Config>(Help_GetConfig);
		public static string Help_GetConfig(BinaryWriter writer)
		{
			writer.Write(0xC4F9186B);
			return "Help_GetConfig";
		}

		///<summary>See <a href="https://core.telegram.org/method/help.getNearestDc"/></summary>
		public Task<NearestDc> Help_GetNearestDc()
			=> CallAsync<NearestDc>(writer =>
			{
				writer.Write(0x1FB33026);
				return "Help_GetNearestDc";
			});

		///<summary>See <a href="https://core.telegram.org/method/help.getAppUpdate"/></summary>
		public Task<Help_AppUpdateBase> Help_GetAppUpdate(string source)
			=> CallAsync<Help_AppUpdateBase>(writer =>
			{
				writer.Write(0x522D5A7D);
				writer.WriteTLString(source);
				return "Help_GetAppUpdate";
			});

		///<summary>See <a href="https://core.telegram.org/method/help.getInviteText"/></summary>
		public Task<Help_InviteText> Help_GetInviteText()
			=> CallAsync<Help_InviteText>(writer =>
			{
				writer.Write(0x4D392343);
				return "Help_GetInviteText";
			});

		///<summary>See <a href="https://core.telegram.org/method/help.getSupport"/></summary>
		public Task<Help_Support> Help_GetSupport()
			=> CallAsync<Help_Support>(writer =>
			{
				writer.Write(0x9CDF08CD);
				return "Help_GetSupport";
			});

		///<summary>See <a href="https://core.telegram.org/method/help.getAppChangelog"/></summary>
		public Task<UpdatesBase> Help_GetAppChangelog(string prev_app_version)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x9010EF6F);
				writer.WriteTLString(prev_app_version);
				return "Help_GetAppChangelog";
			});

		///<summary>See <a href="https://core.telegram.org/method/help.setBotUpdatesStatus"/></summary>
		public Task<bool> Help_SetBotUpdatesStatus(int pending_updates_count, string message)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xEC22CFCD);
				writer.Write(pending_updates_count);
				writer.WriteTLString(message);
				return "Help_SetBotUpdatesStatus";
			});

		///<summary>See <a href="https://core.telegram.org/method/help.getCdnConfig"/></summary>
		public Task<CdnConfig> Help_GetCdnConfig()
			=> CallAsync<CdnConfig>(writer =>
			{
				writer.Write(0x52029342);
				return "Help_GetCdnConfig";
			});

		///<summary>See <a href="https://core.telegram.org/method/help.getRecentMeUrls"/></summary>
		public Task<Help_RecentMeUrls> Help_GetRecentMeUrls(string referer)
			=> CallAsync<Help_RecentMeUrls>(writer =>
			{
				writer.Write(0x3DC0F114);
				writer.WriteTLString(referer);
				return "Help_GetRecentMeUrls";
			});

		///<summary>See <a href="https://core.telegram.org/method/help.getTermsOfServiceUpdate"/></summary>
		public Task<Help_TermsOfServiceUpdateBase> Help_GetTermsOfServiceUpdate()
			=> CallAsync<Help_TermsOfServiceUpdateBase>(writer =>
			{
				writer.Write(0x2CA51FD1);
				return "Help_GetTermsOfServiceUpdate";
			});

		///<summary>See <a href="https://core.telegram.org/method/help.acceptTermsOfService"/></summary>
		public Task<bool> Help_AcceptTermsOfService(DataJSON id)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xEE72F79A);
				writer.WriteTLObject(id);
				return "Help_AcceptTermsOfService";
			});

		///<summary>See <a href="https://core.telegram.org/method/help.getDeepLinkInfo"/></summary>
		public Task<Help_DeepLinkInfoBase> Help_GetDeepLinkInfo(string path)
			=> CallAsync<Help_DeepLinkInfoBase>(writer =>
			{
				writer.Write(0x3FEDC75F);
				writer.WriteTLString(path);
				return "Help_GetDeepLinkInfo";
			});

		///<summary>See <a href="https://core.telegram.org/method/help.getAppConfig"/></summary>
		public Task<JSONValue> Help_GetAppConfig()
			=> CallAsync<JSONValue>(writer =>
			{
				writer.Write(0x98914110);
				return "Help_GetAppConfig";
			});

		///<summary>See <a href="https://core.telegram.org/method/help.saveAppLog"/></summary>
		public Task<bool> Help_SaveAppLog(InputAppEvent[] events)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x6F02F748);
				writer.WriteTLVector(events);
				return "Help_SaveAppLog";
			});

		///<summary>See <a href="https://core.telegram.org/method/help.getPassportConfig"/></summary>
		public Task<Help_PassportConfigBase> Help_GetPassportConfig(int hash)
			=> CallAsync<Help_PassportConfigBase>(writer =>
			{
				writer.Write(0xC661AD08);
				writer.Write(hash);
				return "Help_GetPassportConfig";
			});

		///<summary>See <a href="https://core.telegram.org/method/help.getSupportName"/></summary>
		public Task<Help_SupportName> Help_GetSupportName()
			=> CallAsync<Help_SupportName>(writer =>
			{
				writer.Write(0xD360E72C);
				return "Help_GetSupportName";
			});

		///<summary>See <a href="https://core.telegram.org/method/help.getUserInfo"/></summary>
		public Task<Help_UserInfoBase> Help_GetUserInfo(InputUserBase user_id)
			=> CallAsync<Help_UserInfoBase>(writer =>
			{
				writer.Write(0x038A08D3);
				writer.WriteTLObject(user_id);
				return "Help_GetUserInfo";
			});

		///<summary>See <a href="https://core.telegram.org/method/help.editUserInfo"/></summary>
		public Task<Help_UserInfoBase> Help_EditUserInfo(InputUserBase user_id, string message, MessageEntity[] entities)
			=> CallAsync<Help_UserInfoBase>(writer =>
			{
				writer.Write(0x66B91B70);
				writer.WriteTLObject(user_id);
				writer.WriteTLString(message);
				writer.WriteTLVector(entities);
				return "Help_EditUserInfo";
			});

		///<summary>See <a href="https://core.telegram.org/method/help.getPromoData"/></summary>
		public Task<Help_PromoDataBase> Help_GetPromoData()
			=> CallAsync<Help_PromoDataBase>(writer =>
			{
				writer.Write(0xC0977421);
				return "Help_GetPromoData";
			});

		///<summary>See <a href="https://core.telegram.org/method/help.hidePromoData"/></summary>
		public Task<bool> Help_HidePromoData(InputPeer peer)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x1E251C95);
				writer.WriteTLObject(peer);
				return "Help_HidePromoData";
			});

		///<summary>See <a href="https://core.telegram.org/method/help.dismissSuggestion"/></summary>
		public Task<bool> Help_DismissSuggestion(InputPeer peer, string suggestion)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xF50DBAA1);
				writer.WriteTLObject(peer);
				writer.WriteTLString(suggestion);
				return "Help_DismissSuggestion";
			});

		///<summary>See <a href="https://core.telegram.org/method/help.getCountriesList"/></summary>
		public Task<Help_CountriesListBase> Help_GetCountriesList(string lang_code, int hash)
			=> CallAsync<Help_CountriesListBase>(writer =>
			{
				writer.Write(0x735787A8);
				writer.WriteTLString(lang_code);
				writer.Write(hash);
				return "Help_GetCountriesList";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.readHistory"/></summary>
		public Task<bool> Channels_ReadHistory(InputChannelBase channel, int max_id)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xCC104937);
				writer.WriteTLObject(channel);
				writer.Write(max_id);
				return "Channels_ReadHistory";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.deleteMessages"/></summary>
		public Task<Messages_AffectedMessages> Channels_DeleteMessages(InputChannelBase channel, int[] id)
			=> CallAsync<Messages_AffectedMessages>(writer =>
			{
				writer.Write(0x84C1FD4E);
				writer.WriteTLObject(channel);
				writer.WriteTLVector(id);
				return "Channels_DeleteMessages";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.deleteUserHistory"/></summary>
		public Task<Messages_AffectedHistory> Channels_DeleteUserHistory(InputChannelBase channel, InputUserBase user_id)
			=> CallAsync<Messages_AffectedHistory>(writer =>
			{
				writer.Write(0xD10DD71B);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(user_id);
				return "Channels_DeleteUserHistory";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.reportSpam"/></summary>
		public Task<bool> Channels_ReportSpam(InputChannelBase channel, InputUserBase user_id, int[] id)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xFE087810);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(user_id);
				writer.WriteTLVector(id);
				return "Channels_ReportSpam";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.getMessages"/></summary>
		public Task<Messages_MessagesBase> Channels_GetMessages(InputChannelBase channel, InputMessage[] id)
			=> CallAsync<Messages_MessagesBase>(writer =>
			{
				writer.Write(0xAD8C9A23);
				writer.WriteTLObject(channel);
				writer.WriteTLVector(id);
				return "Channels_GetMessages";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.getParticipants"/></summary>
		public Task<Channels_ChannelParticipantsBase> Channels_GetParticipants(InputChannelBase channel, ChannelParticipantsFilter filter, int offset, int limit, long hash)
			=> CallAsync<Channels_ChannelParticipantsBase>(writer =>
			{
				writer.Write(0x77CED9D0);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(filter);
				writer.Write(offset);
				writer.Write(limit);
				writer.Write(hash);
				return "Channels_GetParticipants";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.getParticipant"/></summary>
		public Task<Channels_ChannelParticipant> Channels_GetParticipant(InputChannelBase channel, InputPeer participant)
			=> CallAsync<Channels_ChannelParticipant>(writer =>
			{
				writer.Write(0xA0AB6CC6);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(participant);
				return "Channels_GetParticipant";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.getChannels"/></summary>
		public Task<Messages_ChatsBase> Channels_GetChannels(InputChannelBase[] id)
			=> CallAsync<Messages_ChatsBase>(writer =>
			{
				writer.Write(0x0A7F6BBB);
				writer.WriteTLVector(id);
				return "Channels_GetChannels";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.getFullChannel"/></summary>
		public Task<Messages_ChatFull> Channels_GetFullChannel(InputChannelBase channel)
			=> CallAsync<Messages_ChatFull>(writer =>
			{
				writer.Write(0x08736A09);
				writer.WriteTLObject(channel);
				return "Channels_GetFullChannel";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.createChannel"/></summary>
		public Task<UpdatesBase> Channels_CreateChannel(string title, string about, bool broadcast = false, bool megagroup = false, bool for_import = false, InputGeoPointBase geo_point = null, string address = null)
			=> CallAsync<UpdatesBase>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/channels.editAdmin"/></summary>
		public Task<UpdatesBase> Channels_EditAdmin(InputChannelBase channel, InputUserBase user_id, ChatAdminRights admin_rights, string rank)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xD33C8902);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(user_id);
				writer.WriteTLObject(admin_rights);
				writer.WriteTLString(rank);
				return "Channels_EditAdmin";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.editTitle"/></summary>
		public Task<UpdatesBase> Channels_EditTitle(InputChannelBase channel, string title)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x566DECD0);
				writer.WriteTLObject(channel);
				writer.WriteTLString(title);
				return "Channels_EditTitle";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.editPhoto"/></summary>
		public Task<UpdatesBase> Channels_EditPhoto(InputChannelBase channel, InputChatPhotoBase photo)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xF12E57C9);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(photo);
				return "Channels_EditPhoto";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.checkUsername"/></summary>
		public Task<bool> Channels_CheckUsername(InputChannelBase channel, string username)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x10E6BD2C);
				writer.WriteTLObject(channel);
				writer.WriteTLString(username);
				return "Channels_CheckUsername";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.updateUsername"/></summary>
		public Task<bool> Channels_UpdateUsername(InputChannelBase channel, string username)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x3514B3DE);
				writer.WriteTLObject(channel);
				writer.WriteTLString(username);
				return "Channels_UpdateUsername";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.joinChannel"/></summary>
		public Task<UpdatesBase> Channels_JoinChannel(InputChannelBase channel)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x24B524C5);
				writer.WriteTLObject(channel);
				return "Channels_JoinChannel";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.leaveChannel"/></summary>
		public Task<UpdatesBase> Channels_LeaveChannel(InputChannelBase channel)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xF836AA95);
				writer.WriteTLObject(channel);
				return "Channels_LeaveChannel";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.inviteToChannel"/></summary>
		public Task<UpdatesBase> Channels_InviteToChannel(InputChannelBase channel, InputUserBase[] users)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x199F3A6C);
				writer.WriteTLObject(channel);
				writer.WriteTLVector(users);
				return "Channels_InviteToChannel";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.deleteChannel"/></summary>
		public Task<UpdatesBase> Channels_DeleteChannel(InputChannelBase channel)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xC0111FE3);
				writer.WriteTLObject(channel);
				return "Channels_DeleteChannel";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.exportMessageLink"/></summary>
		public Task<ExportedMessageLink> Channels_ExportMessageLink(InputChannelBase channel, int id, bool grouped = false, bool thread = false)
			=> CallAsync<ExportedMessageLink>(writer =>
			{
				writer.Write(0xE63FADEB);
				writer.Write((grouped ? 0x1 : 0) | (thread ? 0x2 : 0));
				writer.WriteTLObject(channel);
				writer.Write(id);
				return "Channels_ExportMessageLink";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.toggleSignatures"/></summary>
		public Task<UpdatesBase> Channels_ToggleSignatures(InputChannelBase channel, bool enabled)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x1F69B606);
				writer.WriteTLObject(channel);
				writer.Write(enabled ? 0x997275B5 : 0xBC799737);
				return "Channels_ToggleSignatures";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.getAdminedPublicChannels"/></summary>
		public Task<Messages_ChatsBase> Channels_GetAdminedPublicChannels(bool by_location = false, bool check_limit = false)
			=> CallAsync<Messages_ChatsBase>(writer =>
			{
				writer.Write(0xF8B036AF);
				writer.Write((by_location ? 0x1 : 0) | (check_limit ? 0x2 : 0));
				return "Channels_GetAdminedPublicChannels";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.editBanned"/></summary>
		public Task<UpdatesBase> Channels_EditBanned(InputChannelBase channel, InputPeer participant, ChatBannedRights banned_rights)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x96E6CD81);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(participant);
				writer.WriteTLObject(banned_rights);
				return "Channels_EditBanned";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.getAdminLog"/></summary>
		public Task<Channels_AdminLogResults> Channels_GetAdminLog(InputChannelBase channel, string q, long max_id, long min_id, int limit, ChannelAdminLogEventsFilter events_filter = null, InputUserBase[] admins = null)
			=> CallAsync<Channels_AdminLogResults>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/channels.setStickers"/></summary>
		public Task<bool> Channels_SetStickers(InputChannelBase channel, InputStickerSet stickerset)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xEA8CA4F9);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(stickerset);
				return "Channels_SetStickers";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.readMessageContents"/></summary>
		public Task<bool> Channels_ReadMessageContents(InputChannelBase channel, int[] id)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xEAB5DC38);
				writer.WriteTLObject(channel);
				writer.WriteTLVector(id);
				return "Channels_ReadMessageContents";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.deleteHistory"/></summary>
		public Task<bool> Channels_DeleteHistory(InputChannelBase channel, int max_id)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xAF369D42);
				writer.WriteTLObject(channel);
				writer.Write(max_id);
				return "Channels_DeleteHistory";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.togglePreHistoryHidden"/></summary>
		public Task<UpdatesBase> Channels_TogglePreHistoryHidden(InputChannelBase channel, bool enabled)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xEABBB94C);
				writer.WriteTLObject(channel);
				writer.Write(enabled ? 0x997275B5 : 0xBC799737);
				return "Channels_TogglePreHistoryHidden";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.getLeftChannels"/></summary>
		public Task<Messages_ChatsBase> Channels_GetLeftChannels(int offset)
			=> CallAsync<Messages_ChatsBase>(writer =>
			{
				writer.Write(0x8341ECC0);
				writer.Write(offset);
				return "Channels_GetLeftChannels";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.getGroupsForDiscussion"/></summary>
		public Task<Messages_ChatsBase> Channels_GetGroupsForDiscussion()
			=> CallAsync<Messages_ChatsBase>(writer =>
			{
				writer.Write(0xF5DAD378);
				return "Channels_GetGroupsForDiscussion";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.setDiscussionGroup"/></summary>
		public Task<bool> Channels_SetDiscussionGroup(InputChannelBase broadcast, InputChannelBase group)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x40582BB2);
				writer.WriteTLObject(broadcast);
				writer.WriteTLObject(group);
				return "Channels_SetDiscussionGroup";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.editCreator"/></summary>
		public Task<UpdatesBase> Channels_EditCreator(InputChannelBase channel, InputUserBase user_id, InputCheckPasswordSRPBase password)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x8F38CD1F);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(user_id);
				writer.WriteTLObject(password);
				return "Channels_EditCreator";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.editLocation"/></summary>
		public Task<bool> Channels_EditLocation(InputChannelBase channel, InputGeoPointBase geo_point, string address)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x58E63F6D);
				writer.WriteTLObject(channel);
				writer.WriteTLObject(geo_point);
				writer.WriteTLString(address);
				return "Channels_EditLocation";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.toggleSlowMode"/></summary>
		public Task<UpdatesBase> Channels_ToggleSlowMode(InputChannelBase channel, int seconds)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xEDD49EF0);
				writer.WriteTLObject(channel);
				writer.Write(seconds);
				return "Channels_ToggleSlowMode";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.getInactiveChannels"/></summary>
		public Task<Messages_InactiveChats> Channels_GetInactiveChannels()
			=> CallAsync<Messages_InactiveChats>(writer =>
			{
				writer.Write(0x11E831EE);
				return "Channels_GetInactiveChannels";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.convertToGigagroup"/></summary>
		public Task<UpdatesBase> Channels_ConvertToGigagroup(InputChannelBase channel)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x0B290C69);
				writer.WriteTLObject(channel);
				return "Channels_ConvertToGigagroup";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.viewSponsoredMessage"/></summary>
		public Task<bool> Channels_ViewSponsoredMessage(InputChannelBase channel, byte[] random_id)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xBEAEDB94);
				writer.WriteTLObject(channel);
				writer.WriteTLBytes(random_id);
				return "Channels_ViewSponsoredMessage";
			});

		///<summary>See <a href="https://core.telegram.org/method/channels.getSponsoredMessages"/></summary>
		public Task<Messages_SponsoredMessages> Channels_GetSponsoredMessages(InputChannelBase channel)
			=> CallAsync<Messages_SponsoredMessages>(writer =>
			{
				writer.Write(0xEC210FBF);
				writer.WriteTLObject(channel);
				return "Channels_GetSponsoredMessages";
			});

		///<summary>See <a href="https://core.telegram.org/method/bots.sendCustomRequest"/></summary>
		public Task<DataJSON> Bots_SendCustomRequest(string custom_method, DataJSON params_)
			=> CallAsync<DataJSON>(writer =>
			{
				writer.Write(0xAA2769ED);
				writer.WriteTLString(custom_method);
				writer.WriteTLObject(params_);
				return "Bots_SendCustomRequest";
			});

		///<summary>See <a href="https://core.telegram.org/method/bots.answerWebhookJSONQuery"/></summary>
		public Task<bool> Bots_AnswerWebhookJSONQuery(long query_id, DataJSON data)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xE6213F4D);
				writer.Write(query_id);
				writer.WriteTLObject(data);
				return "Bots_AnswerWebhookJSONQuery";
			});

		///<summary>See <a href="https://core.telegram.org/method/bots.setBotCommands"/></summary>
		public Task<bool> Bots_SetBotCommands(BotCommandScope scope, string lang_code, BotCommand[] commands)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x0517165A);
				writer.WriteTLObject(scope);
				writer.WriteTLString(lang_code);
				writer.WriteTLVector(commands);
				return "Bots_SetBotCommands";
			});

		///<summary>See <a href="https://core.telegram.org/method/bots.resetBotCommands"/></summary>
		public Task<bool> Bots_ResetBotCommands(BotCommandScope scope, string lang_code)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x3D8DE0F9);
				writer.WriteTLObject(scope);
				writer.WriteTLString(lang_code);
				return "Bots_ResetBotCommands";
			});

		///<summary>See <a href="https://core.telegram.org/method/bots.getBotCommands"/></summary>
		public Task<BotCommand[]> Bots_GetBotCommands(BotCommandScope scope, string lang_code)
			=> CallAsync<BotCommand[]>(writer =>
			{
				writer.Write(0xE34C0DD6);
				writer.WriteTLObject(scope);
				writer.WriteTLString(lang_code);
				return "Bots_GetBotCommands";
			});

		///<summary>See <a href="https://core.telegram.org/method/payments.getPaymentForm"/></summary>
		public Task<Payments_PaymentForm> Payments_GetPaymentForm(InputPeer peer, int msg_id, DataJSON theme_params = null)
			=> CallAsync<Payments_PaymentForm>(writer =>
			{
				writer.Write(0x8A333C8D);
				writer.Write(theme_params != null ? 0x1 : 0);
				writer.WriteTLObject(peer);
				writer.Write(msg_id);
				if (theme_params != null)
					writer.WriteTLObject(theme_params);
				return "Payments_GetPaymentForm";
			});

		///<summary>See <a href="https://core.telegram.org/method/payments.getPaymentReceipt"/></summary>
		public Task<Payments_PaymentReceipt> Payments_GetPaymentReceipt(InputPeer peer, int msg_id)
			=> CallAsync<Payments_PaymentReceipt>(writer =>
			{
				writer.Write(0x2478D1CC);
				writer.WriteTLObject(peer);
				writer.Write(msg_id);
				return "Payments_GetPaymentReceipt";
			});

		///<summary>See <a href="https://core.telegram.org/method/payments.validateRequestedInfo"/></summary>
		public Task<Payments_ValidatedRequestedInfo> Payments_ValidateRequestedInfo(InputPeer peer, int msg_id, PaymentRequestedInfo info, bool save = false)
			=> CallAsync<Payments_ValidatedRequestedInfo>(writer =>
			{
				writer.Write(0xDB103170);
				writer.Write(save ? 0x1 : 0);
				writer.WriteTLObject(peer);
				writer.Write(msg_id);
				writer.WriteTLObject(info);
				return "Payments_ValidateRequestedInfo";
			});

		///<summary>See <a href="https://core.telegram.org/method/payments.sendPaymentForm"/></summary>
		public Task<Payments_PaymentResultBase> Payments_SendPaymentForm(long form_id, InputPeer peer, int msg_id, InputPaymentCredentialsBase credentials, string requested_info_id = null, string shipping_option_id = null, long? tip_amount = null)
			=> CallAsync<Payments_PaymentResultBase>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/payments.getSavedInfo"/></summary>
		public Task<Payments_SavedInfo> Payments_GetSavedInfo()
			=> CallAsync<Payments_SavedInfo>(writer =>
			{
				writer.Write(0x227D824B);
				return "Payments_GetSavedInfo";
			});

		///<summary>See <a href="https://core.telegram.org/method/payments.clearSavedInfo"/></summary>
		public Task<bool> Payments_ClearSavedInfo(bool credentials = false, bool info = false)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xD83D70C1);
				writer.Write((credentials ? 0x1 : 0) | (info ? 0x2 : 0));
				return "Payments_ClearSavedInfo";
			});

		///<summary>See <a href="https://core.telegram.org/method/payments.getBankCardData"/></summary>
		public Task<Payments_BankCardData> Payments_GetBankCardData(string number)
			=> CallAsync<Payments_BankCardData>(writer =>
			{
				writer.Write(0x2E79D779);
				writer.WriteTLString(number);
				return "Payments_GetBankCardData";
			});

		///<summary>See <a href="https://core.telegram.org/method/stickers.createStickerSet"/></summary>
		public Task<Messages_StickerSet> Stickers_CreateStickerSet(InputUserBase user_id, string title, string short_name, InputStickerSetItem[] stickers, bool masks = false, bool animated = false, InputDocumentBase thumb = null, string software = null)
			=> CallAsync<Messages_StickerSet>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/stickers.removeStickerFromSet"/></summary>
		public Task<Messages_StickerSet> Stickers_RemoveStickerFromSet(InputDocumentBase sticker)
			=> CallAsync<Messages_StickerSet>(writer =>
			{
				writer.Write(0xF7760F51);
				writer.WriteTLObject(sticker);
				return "Stickers_RemoveStickerFromSet";
			});

		///<summary>See <a href="https://core.telegram.org/method/stickers.changeStickerPosition"/></summary>
		public Task<Messages_StickerSet> Stickers_ChangeStickerPosition(InputDocumentBase sticker, int position)
			=> CallAsync<Messages_StickerSet>(writer =>
			{
				writer.Write(0xFFB6D4CA);
				writer.WriteTLObject(sticker);
				writer.Write(position);
				return "Stickers_ChangeStickerPosition";
			});

		///<summary>See <a href="https://core.telegram.org/method/stickers.addStickerToSet"/></summary>
		public Task<Messages_StickerSet> Stickers_AddStickerToSet(InputStickerSet stickerset, InputStickerSetItem sticker)
			=> CallAsync<Messages_StickerSet>(writer =>
			{
				writer.Write(0x8653FEBE);
				writer.WriteTLObject(stickerset);
				writer.WriteTLObject(sticker);
				return "Stickers_AddStickerToSet";
			});

		///<summary>See <a href="https://core.telegram.org/method/stickers.setStickerSetThumb"/></summary>
		public Task<Messages_StickerSet> Stickers_SetStickerSetThumb(InputStickerSet stickerset, InputDocumentBase thumb)
			=> CallAsync<Messages_StickerSet>(writer =>
			{
				writer.Write(0x9A364E30);
				writer.WriteTLObject(stickerset);
				writer.WriteTLObject(thumb);
				return "Stickers_SetStickerSetThumb";
			});

		///<summary>See <a href="https://core.telegram.org/method/stickers.checkShortName"/></summary>
		public Task<bool> Stickers_CheckShortName(string short_name)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x284B3639);
				writer.WriteTLString(short_name);
				return "Stickers_CheckShortName";
			});

		///<summary>See <a href="https://core.telegram.org/method/stickers.suggestShortName"/></summary>
		public Task<Stickers_SuggestedShortName> Stickers_SuggestShortName(string title)
			=> CallAsync<Stickers_SuggestedShortName>(writer =>
			{
				writer.Write(0x4DAFC503);
				writer.WriteTLString(title);
				return "Stickers_SuggestShortName";
			});

		///<summary>See <a href="https://core.telegram.org/method/phone.getCallConfig"/></summary>
		public Task<DataJSON> Phone_GetCallConfig()
			=> CallAsync<DataJSON>(writer =>
			{
				writer.Write(0x55451FA9);
				return "Phone_GetCallConfig";
			});

		///<summary>See <a href="https://core.telegram.org/method/phone.requestCall"/></summary>
		public Task<Phone_PhoneCall> Phone_RequestCall(InputUserBase user_id, int random_id, byte[] g_a_hash, PhoneCallProtocol protocol, bool video = false)
			=> CallAsync<Phone_PhoneCall>(writer =>
			{
				writer.Write(0x42FF96ED);
				writer.Write(video ? 0x1 : 0);
				writer.WriteTLObject(user_id);
				writer.Write(random_id);
				writer.WriteTLBytes(g_a_hash);
				writer.WriteTLObject(protocol);
				return "Phone_RequestCall";
			});

		///<summary>See <a href="https://core.telegram.org/method/phone.acceptCall"/></summary>
		public Task<Phone_PhoneCall> Phone_AcceptCall(InputPhoneCall peer, byte[] g_b, PhoneCallProtocol protocol)
			=> CallAsync<Phone_PhoneCall>(writer =>
			{
				writer.Write(0x3BD2B4A0);
				writer.WriteTLObject(peer);
				writer.WriteTLBytes(g_b);
				writer.WriteTLObject(protocol);
				return "Phone_AcceptCall";
			});

		///<summary>See <a href="https://core.telegram.org/method/phone.confirmCall"/></summary>
		public Task<Phone_PhoneCall> Phone_ConfirmCall(InputPhoneCall peer, byte[] g_a, long key_fingerprint, PhoneCallProtocol protocol)
			=> CallAsync<Phone_PhoneCall>(writer =>
			{
				writer.Write(0x2EFE1722);
				writer.WriteTLObject(peer);
				writer.WriteTLBytes(g_a);
				writer.Write(key_fingerprint);
				writer.WriteTLObject(protocol);
				return "Phone_ConfirmCall";
			});

		///<summary>See <a href="https://core.telegram.org/method/phone.receivedCall"/></summary>
		public Task<bool> Phone_ReceivedCall(InputPhoneCall peer)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x17D54F61);
				writer.WriteTLObject(peer);
				return "Phone_ReceivedCall";
			});

		///<summary>See <a href="https://core.telegram.org/method/phone.discardCall"/></summary>
		public Task<UpdatesBase> Phone_DiscardCall(InputPhoneCall peer, int duration, PhoneCallDiscardReason reason, long connection_id, bool video = false)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xB2CBC1C0);
				writer.Write(video ? 0x1 : 0);
				writer.WriteTLObject(peer);
				writer.Write(duration);
				writer.WriteTLObject(reason);
				writer.Write(connection_id);
				return "Phone_DiscardCall";
			});

		///<summary>See <a href="https://core.telegram.org/method/phone.setCallRating"/></summary>
		public Task<UpdatesBase> Phone_SetCallRating(InputPhoneCall peer, int rating, string comment, bool user_initiative = false)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x59EAD627);
				writer.Write(user_initiative ? 0x1 : 0);
				writer.WriteTLObject(peer);
				writer.Write(rating);
				writer.WriteTLString(comment);
				return "Phone_SetCallRating";
			});

		///<summary>See <a href="https://core.telegram.org/method/phone.saveCallDebug"/></summary>
		public Task<bool> Phone_SaveCallDebug(InputPhoneCall peer, DataJSON debug)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x277ADD7E);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(debug);
				return "Phone_SaveCallDebug";
			});

		///<summary>See <a href="https://core.telegram.org/method/phone.sendSignalingData"/></summary>
		public Task<bool> Phone_SendSignalingData(InputPhoneCall peer, byte[] data)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0xFF7A9383);
				writer.WriteTLObject(peer);
				writer.WriteTLBytes(data);
				return "Phone_SendSignalingData";
			});

		///<summary>See <a href="https://core.telegram.org/method/phone.createGroupCall"/></summary>
		public Task<UpdatesBase> Phone_CreateGroupCall(InputPeer peer, int random_id, string title = null, DateTime? schedule_date = null)
			=> CallAsync<UpdatesBase>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/phone.joinGroupCall"/></summary>
		public Task<UpdatesBase> Phone_JoinGroupCall(InputGroupCall call, InputPeer join_as, DataJSON params_, bool muted = false, bool video_stopped = false, string invite_hash = null)
			=> CallAsync<UpdatesBase>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/phone.leaveGroupCall"/></summary>
		public Task<UpdatesBase> Phone_LeaveGroupCall(InputGroupCall call, int source)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x500377F9);
				writer.WriteTLObject(call);
				writer.Write(source);
				return "Phone_LeaveGroupCall";
			});

		///<summary>See <a href="https://core.telegram.org/method/phone.inviteToGroupCall"/></summary>
		public Task<UpdatesBase> Phone_InviteToGroupCall(InputGroupCall call, InputUserBase[] users)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x7B393160);
				writer.WriteTLObject(call);
				writer.WriteTLVector(users);
				return "Phone_InviteToGroupCall";
			});

		///<summary>See <a href="https://core.telegram.org/method/phone.discardGroupCall"/></summary>
		public Task<UpdatesBase> Phone_DiscardGroupCall(InputGroupCall call)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x7A777135);
				writer.WriteTLObject(call);
				return "Phone_DiscardGroupCall";
			});

		///<summary>See <a href="https://core.telegram.org/method/phone.toggleGroupCallSettings"/></summary>
		public Task<UpdatesBase> Phone_ToggleGroupCallSettings(InputGroupCall call, bool reset_invite_hash = false, bool? join_muted = null)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x74BBB43D);
				writer.Write((reset_invite_hash ? 0x2 : 0) | (join_muted != null ? 0x1 : 0));
				writer.WriteTLObject(call);
				if (join_muted != null)
					writer.Write(join_muted.Value ? 0x997275B5 : 0xBC799737);
				return "Phone_ToggleGroupCallSettings";
			});

		///<summary>See <a href="https://core.telegram.org/method/phone.getGroupCall"/></summary>
		public Task<Phone_GroupCall> Phone_GetGroupCall(InputGroupCall call, int limit)
			=> CallAsync<Phone_GroupCall>(writer =>
			{
				writer.Write(0x041845DB);
				writer.WriteTLObject(call);
				writer.Write(limit);
				return "Phone_GetGroupCall";
			});

		///<summary>See <a href="https://core.telegram.org/method/phone.getGroupParticipants"/></summary>
		public Task<Phone_GroupParticipants> Phone_GetGroupParticipants(InputGroupCall call, InputPeer[] ids, int[] sources, string offset, int limit)
			=> CallAsync<Phone_GroupParticipants>(writer =>
			{
				writer.Write(0xC558D8AB);
				writer.WriteTLObject(call);
				writer.WriteTLVector(ids);
				writer.WriteTLVector(sources);
				writer.WriteTLString(offset);
				writer.Write(limit);
				return "Phone_GetGroupParticipants";
			});

		///<summary>See <a href="https://core.telegram.org/method/phone.checkGroupCall"/></summary>
		public Task<int[]> Phone_CheckGroupCall(InputGroupCall call, int[] sources)
			=> CallAsync<int[]>(writer =>
			{
				writer.Write(0xB59CF977);
				writer.WriteTLObject(call);
				writer.WriteTLVector(sources);
				return "Phone_CheckGroupCall";
			});

		///<summary>See <a href="https://core.telegram.org/method/phone.toggleGroupCallRecord"/></summary>
		public Task<UpdatesBase> Phone_ToggleGroupCallRecord(InputGroupCall call, bool start = false, bool video = false, string title = null, bool? video_portrait = null)
			=> CallAsync<UpdatesBase>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/phone.editGroupCallParticipant"/></summary>
		public Task<UpdatesBase> Phone_EditGroupCallParticipant(InputGroupCall call, InputPeer participant, bool? muted = null, int? volume = null, bool? raise_hand = null, bool? video_stopped = null, bool? video_paused = null, bool? presentation_paused = null)
			=> CallAsync<UpdatesBase>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/phone.editGroupCallTitle"/></summary>
		public Task<UpdatesBase> Phone_EditGroupCallTitle(InputGroupCall call, string title)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x1CA6AC0A);
				writer.WriteTLObject(call);
				writer.WriteTLString(title);
				return "Phone_EditGroupCallTitle";
			});

		///<summary>See <a href="https://core.telegram.org/method/phone.getGroupCallJoinAs"/></summary>
		public Task<Phone_JoinAsPeers> Phone_GetGroupCallJoinAs(InputPeer peer)
			=> CallAsync<Phone_JoinAsPeers>(writer =>
			{
				writer.Write(0xEF7C213A);
				writer.WriteTLObject(peer);
				return "Phone_GetGroupCallJoinAs";
			});

		///<summary>See <a href="https://core.telegram.org/method/phone.exportGroupCallInvite"/></summary>
		public Task<Phone_ExportedGroupCallInvite> Phone_ExportGroupCallInvite(InputGroupCall call, bool can_self_unmute = false)
			=> CallAsync<Phone_ExportedGroupCallInvite>(writer =>
			{
				writer.Write(0xE6AA647F);
				writer.Write(can_self_unmute ? 0x1 : 0);
				writer.WriteTLObject(call);
				return "Phone_ExportGroupCallInvite";
			});

		///<summary>See <a href="https://core.telegram.org/method/phone.toggleGroupCallStartSubscription"/></summary>
		public Task<UpdatesBase> Phone_ToggleGroupCallStartSubscription(InputGroupCall call, bool subscribed)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x219C34E6);
				writer.WriteTLObject(call);
				writer.Write(subscribed ? 0x997275B5 : 0xBC799737);
				return "Phone_ToggleGroupCallStartSubscription";
			});

		///<summary>See <a href="https://core.telegram.org/method/phone.startScheduledGroupCall"/></summary>
		public Task<UpdatesBase> Phone_StartScheduledGroupCall(InputGroupCall call)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x5680E342);
				writer.WriteTLObject(call);
				return "Phone_StartScheduledGroupCall";
			});

		///<summary>See <a href="https://core.telegram.org/method/phone.saveDefaultGroupCallJoinAs"/></summary>
		public Task<bool> Phone_SaveDefaultGroupCallJoinAs(InputPeer peer, InputPeer join_as)
			=> CallAsync<bool>(writer =>
			{
				writer.Write(0x575E1F8C);
				writer.WriteTLObject(peer);
				writer.WriteTLObject(join_as);
				return "Phone_SaveDefaultGroupCallJoinAs";
			});

		///<summary>See <a href="https://core.telegram.org/method/phone.joinGroupCallPresentation"/></summary>
		public Task<UpdatesBase> Phone_JoinGroupCallPresentation(InputGroupCall call, DataJSON params_)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0xCBEA6BC4);
				writer.WriteTLObject(call);
				writer.WriteTLObject(params_);
				return "Phone_JoinGroupCallPresentation";
			});

		///<summary>See <a href="https://core.telegram.org/method/phone.leaveGroupCallPresentation"/></summary>
		public Task<UpdatesBase> Phone_LeaveGroupCallPresentation(InputGroupCall call)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x1C50D144);
				writer.WriteTLObject(call);
				return "Phone_LeaveGroupCallPresentation";
			});

		///<summary>See <a href="https://core.telegram.org/method/langpack.getLangPack"/></summary>
		public Task<LangPackDifference> Langpack_GetLangPack(string lang_pack, string lang_code)
			=> CallAsync<LangPackDifference>(writer =>
			{
				writer.Write(0xF2F2330A);
				writer.WriteTLString(lang_pack);
				writer.WriteTLString(lang_code);
				return "Langpack_GetLangPack";
			});

		///<summary>See <a href="https://core.telegram.org/method/langpack.getStrings"/></summary>
		public Task<LangPackStringBase[]> Langpack_GetStrings(string lang_pack, string lang_code, string[] keys)
			=> CallAsync<LangPackStringBase[]>(writer =>
			{
				writer.Write(0xEFEA3803);
				writer.WriteTLString(lang_pack);
				writer.WriteTLString(lang_code);
				writer.WriteTLVector(keys);
				return "Langpack_GetStrings";
			});

		///<summary>See <a href="https://core.telegram.org/method/langpack.getDifference"/></summary>
		public Task<LangPackDifference> Langpack_GetDifference(string lang_pack, string lang_code, int from_version)
			=> CallAsync<LangPackDifference>(writer =>
			{
				writer.Write(0xCD984AA5);
				writer.WriteTLString(lang_pack);
				writer.WriteTLString(lang_code);
				writer.Write(from_version);
				return "Langpack_GetDifference";
			});

		///<summary>See <a href="https://core.telegram.org/method/langpack.getLanguages"/></summary>
		public Task<LangPackLanguage[]> Langpack_GetLanguages(string lang_pack)
			=> CallAsync<LangPackLanguage[]>(writer =>
			{
				writer.Write(0x42C6978F);
				writer.WriteTLString(lang_pack);
				return "Langpack_GetLanguages";
			});

		///<summary>See <a href="https://core.telegram.org/method/langpack.getLanguage"/></summary>
		public Task<LangPackLanguage> Langpack_GetLanguage(string lang_pack, string lang_code)
			=> CallAsync<LangPackLanguage>(writer =>
			{
				writer.Write(0x6A596502);
				writer.WriteTLString(lang_pack);
				writer.WriteTLString(lang_code);
				return "Langpack_GetLanguage";
			});

		///<summary>See <a href="https://core.telegram.org/method/folders.editPeerFolders"/></summary>
		public Task<UpdatesBase> Folders_EditPeerFolders(InputFolderPeer[] folder_peers)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x6847D0AB);
				writer.WriteTLVector(folder_peers);
				return "Folders_EditPeerFolders";
			});

		///<summary>See <a href="https://core.telegram.org/method/folders.deleteFolder"/></summary>
		public Task<UpdatesBase> Folders_DeleteFolder(int folder_id)
			=> CallAsync<UpdatesBase>(writer =>
			{
				writer.Write(0x1C295881);
				writer.Write(folder_id);
				return "Folders_DeleteFolder";
			});

		///<summary>See <a href="https://core.telegram.org/method/stats.getBroadcastStats"/></summary>
		public Task<Stats_BroadcastStats> Stats_GetBroadcastStats(InputChannelBase channel, bool dark = false)
			=> CallAsync<Stats_BroadcastStats>(writer =>
			{
				writer.Write(0xAB42441A);
				writer.Write(dark ? 0x1 : 0);
				writer.WriteTLObject(channel);
				return "Stats_GetBroadcastStats";
			});

		///<summary>See <a href="https://core.telegram.org/method/stats.loadAsyncGraph"/></summary>
		public Task<StatsGraphBase> Stats_LoadAsyncGraph(string token, long? x = null)
			=> CallAsync<StatsGraphBase>(writer =>
			{
				writer.Write(0x621D5FA0);
				writer.Write(x != null ? 0x1 : 0);
				writer.WriteTLString(token);
				if (x != null)
					writer.Write(x.Value);
				return "Stats_LoadAsyncGraph";
			});

		///<summary>See <a href="https://core.telegram.org/method/stats.getMegagroupStats"/></summary>
		public Task<Stats_MegagroupStats> Stats_GetMegagroupStats(InputChannelBase channel, bool dark = false)
			=> CallAsync<Stats_MegagroupStats>(writer =>
			{
				writer.Write(0xDCDF8607);
				writer.Write(dark ? 0x1 : 0);
				writer.WriteTLObject(channel);
				return "Stats_GetMegagroupStats";
			});

		///<summary>See <a href="https://core.telegram.org/method/stats.getMessagePublicForwards"/></summary>
		public Task<Messages_MessagesBase> Stats_GetMessagePublicForwards(InputChannelBase channel, int msg_id, int offset_rate, InputPeer offset_peer, int offset_id, int limit)
			=> CallAsync<Messages_MessagesBase>(writer =>
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

		///<summary>See <a href="https://core.telegram.org/method/stats.getMessageStats"/></summary>
		public Task<Stats_MessageStats> Stats_GetMessageStats(InputChannelBase channel, int msg_id, bool dark = false)
			=> CallAsync<Stats_MessageStats>(writer =>
			{
				writer.Write(0xB6E0A3F5);
				writer.Write(dark ? 0x1 : 0);
				writer.WriteTLObject(channel);
				writer.Write(msg_id);
				return "Stats_GetMessageStats";
			});
	}
}
