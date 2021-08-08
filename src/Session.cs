using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace WTelegram
{
	internal class Session
	{
		public long AuthKeyID;
		public byte[] AuthKey;
		public long Salt;
		public long Id;
		public int Seqno;
		public long ServerTicksOffset;
		public long LastSentMsgId;
		public TL.DcOption DataCenter;
		public byte[] User;     // serialization of TL.User

		public DateTime SessionStart => _sessionStart;
		private readonly DateTime _sessionStart = DateTime.UtcNow;
		private string _pathname;
		private byte[] _apiHash;	// used as AES key for encryption of session file

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
			if (!SHA.SHA256.ComputeHash(utf8Json, 32, utf8Json.Length - 32).SequenceEqual(utf8Json[0..32]))
				throw new ApplicationException("Integrity check failed in session loading");
			return JsonSerializer.Deserialize<Session>(utf8Json.AsSpan(32), Helpers.JsonOptions);
		}

		internal void Save()
		{
			var utf8Json = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(this, Helpers.JsonOptions));
			var finalBlock = new byte[16];
			var output = new byte[(16 + 32 + utf8Json.Length + 15) & ~15];
			Encryption.RNG.GetBytes(output, 0, 16);
			using var aes = Aes.Create();
			using var encryptor = aes.CreateEncryptor(_apiHash, output[0..16]);
			encryptor.TransformBlock(SHA.SHA256.ComputeHash(utf8Json), 0, 32, output, 16);
			encryptor.TransformBlock(utf8Json, 0, utf8Json.Length & ~15, output, 48);
			utf8Json.AsSpan(utf8Json.Length & ~15).CopyTo(finalBlock);
			encryptor.TransformFinalBlock(finalBlock, 0, utf8Json.Length & 15).CopyTo(output.AsMemory(48 + utf8Json.Length & ~15));
			File.WriteAllBytes(_pathname, output);
		}

		internal (long msgId, int seqno) NewMsg(bool isContent)
		{
			long msgId = DateTime.UtcNow.Ticks + ServerTicksOffset - 621355968000000000L;
			msgId = msgId * 428 + (msgId >> 24) * 25110956; // approximately unixtime*2^32 and divisible by 4
			if (msgId <= LastSentMsgId) msgId = LastSentMsgId += 4; else LastSentMsgId = msgId;

			int seqno = isContent ? Seqno++ * 2 + 1 : Seqno * 2;
			Save();
			return (msgId, seqno);
		}

		internal DateTime MsgIdToStamp(long serverMsgId)
			=> new((serverMsgId >> 32) * 10000000 - ServerTicksOffset + 621355968000000000L, DateTimeKind.Utc);

		internal void Reset(TL.DcOption newDC = null)
		{
			DataCenter = newDC;
			AuthKeyID = Salt = Seqno = 0;
			AuthKey = User = null;
		}
	}
}