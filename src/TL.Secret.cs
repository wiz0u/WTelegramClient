// This file is (mainly) generated automatically using the Generator class
using System;

namespace TL
{
	namespace Layer8
	{
		public abstract class DecryptedMessageBase : ITLObject { }
		[TLDef(0x1F814F1F)] //decryptedMessage#1f814f1f random_id:long random_bytes:bytes message:string media:DecryptedMessageMedia = DecryptedMessage
		public class DecryptedMessage : DecryptedMessageBase
		{
			public long random_id;
			public byte[] random_bytes;
			public string message;
			public DecryptedMessageMedia media;
		}
		[TLDef(0xAA48327D)] //decryptedMessageService#aa48327d random_id:long random_bytes:bytes action:DecryptedMessageAction = DecryptedMessage
		public class DecryptedMessageService : DecryptedMessageBase
		{
			public long random_id;
			public byte[] random_bytes;
			public DecryptedMessageAction action;
		}

		public abstract class DecryptedMessageMedia : ITLObject { }
		[TLDef(0x089F5C4A)] //decryptedMessageMediaEmpty#089f5c4a = DecryptedMessageMedia
		public class DecryptedMessageMediaEmpty : DecryptedMessageMedia { }
		[TLDef(0x32798A8C)] //decryptedMessageMediaPhoto#32798a8c thumb:bytes thumb_w:int thumb_h:int w:int h:int size:int key:bytes iv:bytes = DecryptedMessageMedia
		public class DecryptedMessageMediaPhoto : DecryptedMessageMedia
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
		[TLDef(0x4CEE6EF3)] //decryptedMessageMediaVideo#4cee6ef3 thumb:bytes thumb_w:int thumb_h:int duration:int w:int h:int size:int key:bytes iv:bytes = DecryptedMessageMedia
		public class DecryptedMessageMediaVideo : DecryptedMessageMedia
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
		[TLDef(0x35480A59)] //decryptedMessageMediaGeoPoint#35480a59 lat:double long:double = DecryptedMessageMedia
		public class DecryptedMessageMediaGeoPoint : DecryptedMessageMedia
		{
			public double lat;
			public double long_;
		}
		[TLDef(0x588A0A97)] //decryptedMessageMediaContact#588a0a97 phone_number:string first_name:string last_name:string user_id:int = DecryptedMessageMedia
		public class DecryptedMessageMediaContact : DecryptedMessageMedia
		{
			public string phone_number;
			public string first_name;
			public string last_name;
			public int user_id;
		}
		[TLDef(0xB095434B)] //decryptedMessageMediaDocument#b095434b thumb:bytes thumb_w:int thumb_h:int file_name:string mime_type:string size:int key:bytes iv:bytes = DecryptedMessageMedia
		public class DecryptedMessageMediaDocument : DecryptedMessageMedia
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
		[TLDef(0x6080758F)] //decryptedMessageMediaAudio#6080758f duration:int size:int key:bytes iv:bytes = DecryptedMessageMedia
		public class DecryptedMessageMediaAudio : DecryptedMessageMedia
		{
			public int duration;
			public int size;
			public byte[] key;
			public byte[] iv;
		}

		public abstract class DecryptedMessageAction : ITLObject { }
		[TLDef(0xA1733AEC)] //decryptedMessageActionSetMessageTTL#a1733aec ttl_seconds:int = DecryptedMessageAction
		public class DecryptedMessageActionSetMessageTTL : DecryptedMessageAction { public int ttl_seconds; }
		[TLDef(0x0C4F40BE)] //decryptedMessageActionReadMessages#0c4f40be random_ids:Vector<long> = DecryptedMessageAction
		public class DecryptedMessageActionReadMessages : DecryptedMessageAction { public long[] random_ids; }
		[TLDef(0x65614304)] //decryptedMessageActionDeleteMessages#65614304 random_ids:Vector<long> = DecryptedMessageAction
		public class DecryptedMessageActionDeleteMessages : DecryptedMessageAction { public long[] random_ids; }
		[TLDef(0x8AC1F475)] //decryptedMessageActionScreenshotMessages#8ac1f475 random_ids:Vector<long> = DecryptedMessageAction
		public class DecryptedMessageActionScreenshotMessages : DecryptedMessageAction { public long[] random_ids; }
		[TLDef(0x6719E45C)] //decryptedMessageActionFlushHistory#6719e45c = DecryptedMessageAction
		public class DecryptedMessageActionFlushHistory : DecryptedMessageAction { }
	}

	namespace Layer17
	{
		public abstract class DecryptedMessageBase : ITLObject { }
		[TLDef(0x204D3878)] //decryptedMessage#204d3878 random_id:long ttl:int message:string media:DecryptedMessageMedia = DecryptedMessage
		public class DecryptedMessage : DecryptedMessageBase
		{
			public long random_id;
			public int ttl;
			public string message;
			public DecryptedMessageMedia media;
		}
		[TLDef(0x73164160)] //decryptedMessageService#73164160 random_id:long action:DecryptedMessageAction = DecryptedMessage
		public class DecryptedMessageService : DecryptedMessageBase
		{
			public long random_id;
			public DecryptedMessageAction action;
		}

		public abstract class DecryptedMessageMedia : ITLObject { }
		[TLDef(0x524A415D)] //decryptedMessageMediaVideo#524a415d thumb:bytes thumb_w:int thumb_h:int duration:int mime_type:string w:int h:int size:int key:bytes iv:bytes = DecryptedMessageMedia
		public class DecryptedMessageMediaVideo : DecryptedMessageMedia
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
		[TLDef(0x57E0A9CB)] //decryptedMessageMediaAudio#57e0a9cb duration:int mime_type:string size:int key:bytes iv:bytes = DecryptedMessageMedia
		public class DecryptedMessageMediaAudio : DecryptedMessageMedia
		{
			public int duration;
			public string mime_type;
			public int size;
			public byte[] key;
			public byte[] iv;
		}

		[TLDef(0x1BE31789)] //decryptedMessageLayer#1be31789 random_bytes:bytes layer:int in_seq_no:int out_seq_no:int message:DecryptedMessage = DecryptedMessageLayer
		public class DecryptedMessageLayer : ITLObject
		{
			public byte[] random_bytes;
			public int layer;
			public int in_seq_no;
			public int out_seq_no;
			public DecryptedMessageBase message;
		}

		[TLDef(0x92042FF7)] //sendMessageUploadVideoAction#92042ff7 = SendMessageAction
		public class SendMessageUploadVideoAction : SendMessageAction { }
		[TLDef(0xE6AC8A6F)] //sendMessageUploadAudioAction#e6ac8a6f = SendMessageAction
		public class SendMessageUploadAudioAction : SendMessageAction { }
		[TLDef(0x990A3C1A)] //sendMessageUploadPhotoAction#990a3c1a = SendMessageAction
		public class SendMessageUploadPhotoAction : SendMessageAction { }
		[TLDef(0x8FAEE98E)] //sendMessageUploadDocumentAction#8faee98e = SendMessageAction
		public class SendMessageUploadDocumentAction : SendMessageAction { }

		public abstract class DecryptedMessageAction : ITLObject { }
		[TLDef(0x511110B0)] //decryptedMessageActionResend#511110b0 start_seq_no:int end_seq_no:int = DecryptedMessageAction
		public class DecryptedMessageActionResend : DecryptedMessageAction
		{
			public int start_seq_no;
			public int end_seq_no;
		}
		[TLDef(0xF3048883)] //decryptedMessageActionNotifyLayer#f3048883 layer:int = DecryptedMessageAction
		public class DecryptedMessageActionNotifyLayer : DecryptedMessageAction { public int layer; }
		[TLDef(0xCCB27641)] //decryptedMessageActionTyping#ccb27641 action:SendMessageAction = DecryptedMessageAction
		public class DecryptedMessageActionTyping : DecryptedMessageAction { public SendMessageAction action; }
	}

	namespace Layer20
	{
		public abstract class DecryptedMessageAction : ITLObject { }
		[TLDef(0xF3C9611B)] //decryptedMessageActionRequestKey#f3c9611b exchange_id:long g_a:bytes = DecryptedMessageAction
		public class DecryptedMessageActionRequestKey : DecryptedMessageAction
		{
			public long exchange_id;
			public byte[] g_a;
		}
		[TLDef(0x6FE1735B)] //decryptedMessageActionAcceptKey#6fe1735b exchange_id:long g_b:bytes key_fingerprint:long = DecryptedMessageAction
		public class DecryptedMessageActionAcceptKey : DecryptedMessageAction
		{
			public long exchange_id;
			public byte[] g_b;
			public long key_fingerprint;
		}
		[TLDef(0xDD05EC6B)] //decryptedMessageActionAbortKey#dd05ec6b exchange_id:long = DecryptedMessageAction
		public class DecryptedMessageActionAbortKey : DecryptedMessageAction { public long exchange_id; }
		[TLDef(0xEC2E0B9B)] //decryptedMessageActionCommitKey#ec2e0b9b exchange_id:long key_fingerprint:long = DecryptedMessageAction
		public class DecryptedMessageActionCommitKey : DecryptedMessageAction
		{
			public long exchange_id;
			public long key_fingerprint;
		}
		[TLDef(0xA82FDD63)] //decryptedMessageActionNoop#a82fdd63 = DecryptedMessageAction
		public class DecryptedMessageActionNoop : DecryptedMessageAction { }
	}

	namespace Layer23
	{
		[TLDef(0xFB0A5727)] //documentAttributeSticker#fb0a5727 = DocumentAttribute
		public class DocumentAttributeSticker : DocumentAttribute { }
		[TLDef(0x5910CCCB)] //documentAttributeVideo#5910cccb duration:int w:int h:int = DocumentAttribute
		public class DocumentAttributeVideo : DocumentAttribute
		{
			public int duration;
			public int w;
			public int h;
		}
		[TLDef(0x051448E5)] //documentAttributeAudio#051448e5 duration:int = DocumentAttribute
		public class DocumentAttributeAudio : DocumentAttribute { public int duration; }

		[TLDef(0x7C596B46)] //fileLocationUnavailable#7c596b46 volume_id:long local_id:int secret:long = FileLocation
		public class FileLocationUnavailable : FileLocation
		{
			public long volume_id;
			public int local_id;
			public long secret;
		}
		[TLDef(0x53D69076)] //fileLocation#53d69076 dc_id:int volume_id:long local_id:int secret:long = FileLocation
		public class FileLocation_ : FileLocation
		{
			public int dc_id;
			public long volume_id;
			public int local_id;
			public long secret;
		}

		public abstract class DecryptedMessageMedia : ITLObject { }
		[TLDef(0xFA95B0DD)] //decryptedMessageMediaExternalDocument#fa95b0dd id:long access_hash:long date:int mime_type:string size:int thumb:PhotoSize dc_id:int attributes:Vector<DocumentAttribute> = DecryptedMessageMedia
		public class DecryptedMessageMediaExternalDocument : DecryptedMessageMedia
		{
			public long id;
			public long access_hash;
			public DateTime date;
			public string mime_type;
			public int size;
			public PhotoSize thumb;
			public int dc_id;
			public DocumentAttribute[] attributes;
		}
	}

	namespace Layer45
	{
		[TLDef(0x36B091DE)] //decryptedMessage#36b091de flags:# random_id:long ttl:int message:string media:flags.9?DecryptedMessageMedia entities:flags.7?Vector<MessageEntity> via_bot_name:flags.11?string reply_to_random_id:flags.3?long = DecryptedMessage
		public class DecryptedMessage : ITLObject
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

		public abstract class DecryptedMessageMedia : ITLObject { }
		[TLDef(0xF1FA8D78)] //decryptedMessageMediaPhoto#f1fa8d78 thumb:bytes thumb_w:int thumb_h:int w:int h:int size:int key:bytes iv:bytes caption:string = DecryptedMessageMedia
		public class DecryptedMessageMediaPhoto : DecryptedMessageMedia
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
		[TLDef(0x970C8C0E)] //decryptedMessageMediaVideo#970c8c0e thumb:bytes thumb_w:int thumb_h:int duration:int mime_type:string w:int h:int size:int key:bytes iv:bytes caption:string = DecryptedMessageMedia
		public class DecryptedMessageMediaVideo : DecryptedMessageMedia
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
		[TLDef(0x7AFE8AE2)] //decryptedMessageMediaDocument#7afe8ae2 thumb:bytes thumb_w:int thumb_h:int mime_type:string size:int key:bytes iv:bytes attributes:Vector<DocumentAttribute> caption:string = DecryptedMessageMedia
		public class DecryptedMessageMediaDocument : DecryptedMessageMedia
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
		[TLDef(0x8A0DF56F)] //decryptedMessageMediaVenue#8a0df56f lat:double long:double title:string address:string provider:string venue_id:string = DecryptedMessageMedia
		public class DecryptedMessageMediaVenue : DecryptedMessageMedia
		{
			public double lat;
			public double long_;
			public string title;
			public string address;
			public string provider;
			public string venue_id;
		}
		[TLDef(0xE50511D8)] //decryptedMessageMediaWebPage#e50511d8 url:string = DecryptedMessageMedia
		public class DecryptedMessageMediaWebPage : DecryptedMessageMedia { public string url; }

		[TLDef(0x3A556302)] //documentAttributeSticker#3a556302 alt:string stickerset:InputStickerSet = DocumentAttribute
		public class DocumentAttributeSticker : DocumentAttribute
		{
			public string alt;
			public InputStickerSet stickerset;
		}
		[TLDef(0xDED218E0)] //documentAttributeAudio#ded218e0 duration:int title:string performer:string = DocumentAttribute
		public class DocumentAttributeAudio : DocumentAttribute
		{
			public int duration;
			public string title;
			public string performer;
		}
	}

	namespace Layer46
	{	}

	namespace Layer66
	{
		[TLDef(0xBB718624)] //sendMessageUploadRoundAction#bb718624 = SendMessageAction
		public class SendMessageUploadRoundAction : SendMessageAction { }
	}

	namespace Layer73
	{
		[TLDef(0x91CC4674)] //decryptedMessage#91cc4674 flags:# random_id:long ttl:int message:string media:flags.9?DecryptedMessageMedia entities:flags.7?Vector<MessageEntity> via_bot_name:flags.11?string reply_to_random_id:flags.3?long grouped_id:flags.17?long = DecryptedMessage
		public class DecryptedMessage : ITLObject
		{
			[Flags] public enum Flags { has_reply_to_random_id = 0x8, has_entities = 0x80, has_media = 0x200, has_via_bot_name = 0x800, 
				has_grouped_id = 0x20000 }
			public Flags flags;
			public long random_id;
			public int ttl;
			public string message;
			[IfFlag(9)] public Layer45.DecryptedMessageMedia media;
			[IfFlag(7)] public MessageEntity[] entities;
			[IfFlag(11)] public string via_bot_name;
			[IfFlag(3)] public long reply_to_random_id;
			[IfFlag(17)] public long grouped_id;
		}
	}
}
