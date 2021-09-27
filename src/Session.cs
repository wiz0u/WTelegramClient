using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text.Json;

namespace WTelegram
{
	internal class Session
	{
		public TL.User User;
		public int MainDC;
		public Dictionary<int, DCSession> DCSessions = new();
		public long Id;

		public class DCSession
		{
			public long AuthKeyID;
			public byte[] AuthKey;      // 2048-bit = 256 bytes
			public long UserId;
			public long Salt;
			public int Seqno;
			public long ServerTicksOffset;
			public long LastSentMsgId;
			public TL.DcOption DataCenter;

			internal IPEndPoint EndPoint => DataCenter == null ? null : new(IPAddress.Parse(DataCenter.ip_address), DataCenter.port);
		}

		public DateTime SessionStart => _sessionStart;
		internal DCSession CurrentDCSession;
		private readonly DateTime _sessionStart = DateTime.UtcNow;
		private string _pathname;
		private byte[] _apiHash;	// used as AES key for encryption of session file

		private static readonly JsonSerializerOptions JsonOptions = new(Helpers.JsonOptions)
		{
			Converters = {
				new Helpers.PolymorphicConverter<TL.UserProfilePhotoBase>(),
				new Helpers.PolymorphicConverter<TL.UserStatus>()
			}
		};

		internal static Session LoadOrCreate(string pathname, byte[] apiHash)
		{
			if (File.Exists(pathname))
			{
				try
				{
					var session = Load(pathname, apiHash);
					session._pathname = pathname;
					session._apiHash = apiHash;
					Helpers.Log(2, "Loaded previous session");
					return session;
				}
				catch (Exception ex)
				{
					throw new ApplicationException($"Exception while reading session file: {ex.Message}\nDelete the file to start a new session", ex);
				}
			}
			return new Session { _pathname = pathname, _apiHash = apiHash, Id = Helpers.RandomLong() };
		}

		internal static Session Load(string pathname, byte[] apiHash)
		{
			var input = File.ReadAllBytes(pathname);
			using var aes = Aes.Create();
			using var decryptor = aes.CreateDecryptor(apiHash, input[0..16]);
			var utf8Json = decryptor.TransformFinalBlock(input, 16, input.Length - 16);
			if (!Encryption.Sha256.ComputeHash(utf8Json, 32, utf8Json.Length - 32).SequenceEqual(utf8Json[0..32]))
				throw new ApplicationException("Integrity check failed in session loading");
			return JsonSerializer.Deserialize<Session>(utf8Json.AsSpan(32), JsonOptions);
		}

		internal void Save()
		{
			var utf8Json = JsonSerializer.SerializeToUtf8Bytes(this, JsonOptions);
			var finalBlock = new byte[16];
			var output = new byte[(16 + 32 + utf8Json.Length + 16) & ~15];
			Encryption.RNG.GetBytes(output, 0, 16);
			using var aes = Aes.Create();
			using var encryptor = aes.CreateEncryptor(_apiHash, output[0..16]);
			encryptor.TransformBlock(Encryption.Sha256.ComputeHash(utf8Json), 0, 32, output, 16);
			encryptor.TransformBlock(utf8Json, 0, utf8Json.Length & ~15, output, 48);
			utf8Json.AsSpan(utf8Json.Length & ~15).CopyTo(finalBlock);
			encryptor.TransformFinalBlock(finalBlock, 0, utf8Json.Length & 15).CopyTo(output.AsMemory(48 + utf8Json.Length & ~15));
			if (!File.Exists(_pathname))
				File.WriteAllBytes(_pathname, output);
			else
			{
				string tempPathname = _pathname + ".tmp";
				File.WriteAllBytes(tempPathname, output);
				File.Replace(tempPathname, _pathname, null);
			}
		}

		internal (long msgId, int seqno) NewMsg(bool isContent)
		{
			int seqno;
			long msgId = DateTime.UtcNow.Ticks + CurrentDCSession.ServerTicksOffset - 621355968000000000L;
			msgId = msgId * 428 + (msgId >> 24) * 25110956; // approximately unixtime*2^32 and divisible by 4
			lock (this)
			{
				if (msgId <= CurrentDCSession.LastSentMsgId) msgId = CurrentDCSession.LastSentMsgId += 4; else CurrentDCSession.LastSentMsgId = msgId;

				seqno = isContent ? CurrentDCSession.Seqno++ * 2 + 1 : CurrentDCSession.Seqno * 2;
				Save();
			}
			return (msgId, seqno);
		}

		internal DateTime MsgIdToStamp(long serverMsgId)
			=> new((serverMsgId >> 32) * 10000000 - CurrentDCSession.ServerTicksOffset + 621355968000000000L, DateTimeKind.Utc);

		internal void ChangeDC(int dc)
		{
			if (dc == 0) dc = MainDC;
			CurrentDCSession = dc != 0 ? DCSessions[dc] : new();
		}
	}
}