// This file is generated automatically using the Generator class
using System;

namespace TL
{
	using BinaryWriter = System.IO.BinaryWriter;
	using Client = WTelegram.Client;

	///<summary>See <a href="https://core.telegram.org/type/DecryptedMessage"/></summary>
	public abstract partial class DecryptedMessageBase : ITLObject { }

	///<summary>See <a href="https://core.telegram.org/type/DecryptedMessageMedia"/></summary>
	///<remarks>a <c>null</c> value means <a href="https://core.telegram.org/constructor/decryptedMessageMediaEmpty">decryptedMessageMediaEmpty</a></remarks>
	public abstract partial class DecryptedMessageMedia : ITLObject { }

	///<summary>See <a href="https://core.telegram.org/type/DecryptedMessageAction"/></summary>
	public abstract partial class DecryptedMessageAction : ITLObject { }

	///<summary>See <a href="https://core.telegram.org/type/FileLocation"/></summary>
	public abstract partial class FileLocationBase : ITLObject { }

	namespace Layer8
	{
		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessage"/></summary>
		[TLDef(0x1F814F1F)]
		public partial class DecryptedMessage : DecryptedMessageBase
		{
			public long random_id;
			public byte[] random_bytes;
			public string message;
			public DecryptedMessageMedia media;
		}
		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageService"/></summary>
		[TLDef(0xAA48327D)]
		public partial class DecryptedMessageService : DecryptedMessageBase
		{
			public long random_id;
			public byte[] random_bytes;
			public DecryptedMessageAction action;
		}

		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageMediaPhoto"/></summary>
		[TLDef(0x32798A8C)]
		public partial class DecryptedMessageMediaPhoto : DecryptedMessageMedia
		{
			public byte[] thumb;
			public int thumb_w;
			public int thumb_h;
			public int w;
			public int h;
			public int size;
			public byte[] key;
			public byte[] iv;
		}
		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageMediaVideo"/></summary>
		[TLDef(0x4CEE6EF3)]
		public partial class DecryptedMessageMediaVideo : DecryptedMessageMedia
		{
			public byte[] thumb;
			public int thumb_w;
			public int thumb_h;
			public int duration;
			public int w;
			public int h;
			public int size;
			public byte[] key;
			public byte[] iv;
		}
		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageMediaGeoPoint"/></summary>
		[TLDef(0x35480A59)]
		public partial class DecryptedMessageMediaGeoPoint : DecryptedMessageMedia
		{
			public double lat;
			public double long_;
		}
		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageMediaContact"/></summary>
		[TLDef(0x588A0A97)]
		public partial class DecryptedMessageMediaContact : DecryptedMessageMedia
		{
			public string phone_number;
			public string first_name;
			public string last_name;
			public int user_id;
		}
		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageMediaDocument"/></summary>
		[TLDef(0xB095434B)]
		public partial class DecryptedMessageMediaDocument : DecryptedMessageMedia
		{
			public byte[] thumb;
			public int thumb_w;
			public int thumb_h;
			public string file_name;
			public string mime_type;
			public int size;
			public byte[] key;
			public byte[] iv;
		}
		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageMediaAudio"/></summary>
		[TLDef(0x6080758F)]
		public partial class DecryptedMessageMediaAudio : DecryptedMessageMedia
		{
			public int duration;
			public int size;
			public byte[] key;
			public byte[] iv;
		}

		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageActionSetMessageTTL"/></summary>
		[TLDef(0xA1733AEC)]
		public partial class DecryptedMessageActionSetMessageTTL : DecryptedMessageAction { public int ttl_seconds; }
		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageActionReadMessages"/></summary>
		[TLDef(0x0C4F40BE)]
		public partial class DecryptedMessageActionReadMessages : DecryptedMessageAction { public long[] random_ids; }
		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageActionDeleteMessages"/></summary>
		[TLDef(0x65614304)]
		public partial class DecryptedMessageActionDeleteMessages : DecryptedMessageAction { public long[] random_ids; }
		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageActionScreenshotMessages"/></summary>
		[TLDef(0x8AC1F475)]
		public partial class DecryptedMessageActionScreenshotMessages : DecryptedMessageAction { public long[] random_ids; }
		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageActionFlushHistory"/></summary>
		[TLDef(0x6719E45C)]
		public partial class DecryptedMessageActionFlushHistory : DecryptedMessageAction { }
	}

	namespace Layer17
	{
		///<summary>See <a href="https://core.telegram.org/constructor/sendMessageUploadVideoAction"/></summary>
		[TLDef(0x92042FF7)]
		public partial class SendMessageUploadVideoAction : SendMessageAction { }
		///<summary>See <a href="https://core.telegram.org/constructor/sendMessageUploadAudioAction"/></summary>
		[TLDef(0xE6AC8A6F)]
		public partial class SendMessageUploadAudioAction : SendMessageAction { }
		///<summary>See <a href="https://core.telegram.org/constructor/sendMessageUploadPhotoAction"/></summary>
		[TLDef(0x990A3C1A)]
		public partial class SendMessageUploadPhotoAction : SendMessageAction { }
		///<summary>See <a href="https://core.telegram.org/constructor/sendMessageUploadDocumentAction"/></summary>
		[TLDef(0x8FAEE98E)]
		public partial class SendMessageUploadDocumentAction : SendMessageAction { }

		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessage"/></summary>
		[TLDef(0x204D3878)]
		public partial class DecryptedMessage : DecryptedMessageBase
		{
			public long random_id;
			public int ttl;
			public string message;
			public DecryptedMessageMedia media;
		}
		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageService"/></summary>
		[TLDef(0x73164160)]
		public partial class DecryptedMessageService : DecryptedMessageBase
		{
			public long random_id;
			public DecryptedMessageAction action;
		}

		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageMediaVideo"/></summary>
		[TLDef(0x524A415D)]
		public partial class DecryptedMessageMediaVideo : DecryptedMessageMedia
		{
			public byte[] thumb;
			public int thumb_w;
			public int thumb_h;
			public int duration;
			public string mime_type;
			public int w;
			public int h;
			public int size;
			public byte[] key;
			public byte[] iv;
		}
		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageMediaAudio"/></summary>
		[TLDef(0x57E0A9CB)]
		public partial class DecryptedMessageMediaAudio : DecryptedMessageMedia
		{
			public int duration;
			public string mime_type;
			public int size;
			public byte[] key;
			public byte[] iv;
		}

		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageActionResend"/></summary>
		[TLDef(0x511110B0)]
		public partial class DecryptedMessageActionResend : DecryptedMessageAction
		{
			public int start_seq_no;
			public int end_seq_no;
		}
		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageActionNotifyLayer"/></summary>
		[TLDef(0xF3048883)]
		public partial class DecryptedMessageActionNotifyLayer : DecryptedMessageAction { public int layer; }
		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageActionTyping"/></summary>
		[TLDef(0xCCB27641)]
		public partial class DecryptedMessageActionTyping : DecryptedMessageAction { public SendMessageAction action; }

		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageLayer"/></summary>
		[TLDef(0x1BE31789)]
		public partial class DecryptedMessageLayer : ITLObject
		{
			public byte[] random_bytes;
			public int layer;
			public int in_seq_no;
			public int out_seq_no;
			public DecryptedMessageBase message;
		}
	}

	namespace Layer45
	{
		///<summary>See <a href="https://core.telegram.org/constructor/documentAttributeSticker"/></summary>
		[TLDef(0x3A556302)]
		public partial class DocumentAttributeSticker : DocumentAttribute
		{
			public string alt;
			public InputStickerSet stickerset;
		}
		///<summary>See <a href="https://core.telegram.org/constructor/documentAttributeAudio"/></summary>
		[TLDef(0xDED218E0)]
		public partial class DocumentAttributeAudio : DocumentAttribute
		{
			public int duration;
			public string title;
			public string performer;
		}

		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessage"/></summary>
		[TLDef(0x36B091DE)]
		public partial class DecryptedMessage : DecryptedMessageBase
		{
			[Flags] public enum Flags { has_reply_to_random_id = 0x8, has_entities = 0x80, has_media = 0x200, has_via_bot_name = 0x800 }
			public Flags flags;
			public long random_id;
			public int ttl;
			public string message;
			[IfFlag(9)] public DecryptedMessageMedia media;
			[IfFlag(7)] public MessageEntity[] entities;
			[IfFlag(11)] public string via_bot_name;
			[IfFlag(3)] public long reply_to_random_id;
		}

		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageMediaPhoto"/></summary>
		[TLDef(0xF1FA8D78)]
		public partial class DecryptedMessageMediaPhoto : DecryptedMessageMedia
		{
			public byte[] thumb;
			public int thumb_w;
			public int thumb_h;
			public int w;
			public int h;
			public int size;
			public byte[] key;
			public byte[] iv;
			public string caption;
		}
		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageMediaVideo"/></summary>
		[TLDef(0x970C8C0E)]
		public partial class DecryptedMessageMediaVideo : DecryptedMessageMedia
		{
			public byte[] thumb;
			public int thumb_w;
			public int thumb_h;
			public int duration;
			public string mime_type;
			public int w;
			public int h;
			public int size;
			public byte[] key;
			public byte[] iv;
			public string caption;
		}
		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageMediaDocument"/></summary>
		[TLDef(0x7AFE8AE2)]
		public partial class DecryptedMessageMediaDocument : DecryptedMessageMedia
		{
			public byte[] thumb;
			public int thumb_w;
			public int thumb_h;
			public string mime_type;
			public int size;
			public byte[] key;
			public byte[] iv;
			public DocumentAttribute[] attributes;
			public string caption;
		}
		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageMediaVenue"/></summary>
		[TLDef(0x8A0DF56F)]
		public partial class DecryptedMessageMediaVenue : DecryptedMessageMedia
		{
			public double lat;
			public double long_;
			public string title;
			public string address;
			public string provider;
			public string venue_id;
		}
		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageMediaWebPage"/></summary>
		[TLDef(0xE50511D8)]
		public partial class DecryptedMessageMediaWebPage : DecryptedMessageMedia { public string url; }
	}

	namespace Layer73
	{
		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessage"/></summary>
		[TLDef(0x91CC4674)]
		public partial class DecryptedMessage : DecryptedMessageBase
		{
			[Flags] public enum Flags { has_reply_to_random_id = 0x8, has_entities = 0x80, has_media = 0x200, has_via_bot_name = 0x800, 
				has_grouped_id = 0x20000 }
			public Flags flags;
			public long random_id;
			public int ttl;
			public string message;
			[IfFlag(9)] public DecryptedMessageMedia media;
			[IfFlag(7)] public MessageEntity[] entities;
			[IfFlag(11)] public string via_bot_name;
			[IfFlag(3)] public long reply_to_random_id;
			[IfFlag(17)] public long grouped_id;
		}
	}

	namespace Layer20
	{
		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageActionRequestKey"/></summary>
		[TLDef(0xF3C9611B)]
		public partial class DecryptedMessageActionRequestKey : DecryptedMessageAction
		{
			public long exchange_id;
			public byte[] g_a;
		}
		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageActionAcceptKey"/></summary>
		[TLDef(0x6FE1735B)]
		public partial class DecryptedMessageActionAcceptKey : DecryptedMessageAction
		{
			public long exchange_id;
			public byte[] g_b;
			public long key_fingerprint;
		}
		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageActionAbortKey"/></summary>
		[TLDef(0xDD05EC6B)]
		public partial class DecryptedMessageActionAbortKey : DecryptedMessageAction { public long exchange_id; }
		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageActionCommitKey"/></summary>
		[TLDef(0xEC2E0B9B)]
		public partial class DecryptedMessageActionCommitKey : DecryptedMessageAction
		{
			public long exchange_id;
			public long key_fingerprint;
		}
		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageActionNoop"/></summary>
		[TLDef(0xA82FDD63)]
		public partial class DecryptedMessageActionNoop : DecryptedMessageAction { }
	}

	namespace Layer23
	{
		///<summary>See <a href="https://core.telegram.org/constructor/photoSize"/></summary>
		[TLDef(0x77BFB61B)]
		public partial class PhotoSize : PhotoSizeBase
		{
			public string type;
			public FileLocationBase location;
			public int w;
			public int h;
			public int size;
		}
		///<summary>See <a href="https://core.telegram.org/constructor/photoCachedSize"/></summary>
		[TLDef(0xE9A734FA)]
		public partial class PhotoCachedSize : PhotoSizeBase
		{
			public string type;
			public FileLocationBase location;
			public int w;
			public int h;
			public byte[] bytes;
		}

		///<summary>See <a href="https://core.telegram.org/constructor/documentAttributeSticker"/></summary>
		[TLDef(0xFB0A5727)]
		public partial class DocumentAttributeSticker : DocumentAttribute { }
		///<summary>See <a href="https://core.telegram.org/constructor/documentAttributeVideo"/></summary>
		[TLDef(0x5910CCCB)]
		public partial class DocumentAttributeVideo : DocumentAttribute
		{
			public int duration;
			public int w;
			public int h;
		}
		///<summary>See <a href="https://core.telegram.org/constructor/documentAttributeAudio"/></summary>
		[TLDef(0x051448E5)]
		public partial class DocumentAttributeAudio : DocumentAttribute { public int duration; }

		///<summary>See <a href="https://core.telegram.org/constructor/decryptedMessageMediaExternalDocument"/></summary>
		[TLDef(0xFA95B0DD)]
		public partial class DecryptedMessageMediaExternalDocument : DecryptedMessageMedia
		{
			public long id;
			public long access_hash;
			public DateTime date;
			public string mime_type;
			public int size;
			public PhotoSizeBase thumb;
			public int dc_id;
			public DocumentAttribute[] attributes;
		}

		///<summary>See <a href="https://core.telegram.org/constructor/fileLocationUnavailable"/></summary>
		[TLDef(0x7C596B46)]
		public partial class FileLocationUnavailable : FileLocationBase
		{
			public long volume_id;
			public int local_id;
			public long secret;
		}
		///<summary>See <a href="https://core.telegram.org/constructor/fileLocation"/></summary>
		[TLDef(0x53D69076)]
		public partial class FileLocation : FileLocationBase
		{
			public int dc_id;
			public long volume_id;
			public int local_id;
			public long secret;
		}
	}

	namespace Layer66
	{
		///<summary>See <a href="https://core.telegram.org/constructor/sendMessageUploadRoundAction"/></summary>
		[TLDef(0xBB718624)]
		public partial class SendMessageUploadRoundAction : SendMessageAction { }
	}

	namespace Layer46
	{	}
}
