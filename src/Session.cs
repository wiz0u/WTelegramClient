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
		public long UserId;
		public int MainDC;
		public Dictionary<int, DCSession> DCSessions = new();
		public TL.DcOption[] DcOptions;

		public UserShim User; // obsolete, to be removed
		public class UserShim { public long id; } // to be removed

		public class DCSession
		{
			public long Id;
			public long AuthKeyID;
			public byte[] AuthKey;      // 2048-bit = 256 bytes
			public long UserId;
			public long Salt;
			public int Seqno;
			public long ServerTicksOffset;
			public long LastSentMsgId;
			public TL.DcOption DataCenter;

			internal Client Client;
			internal int DcID => DataCenter?.id ?? 0;
			internal IPEndPoint EndPoint => DataCenter == null ? null : new(IPAddress.Parse(DataCenter.ip_address), DataCenter.port);
			internal void Renew() { Helpers.Log(3, $"Renewing session on DC {DcID}..."); Id = Helpers.RandomLong(); Seqno = 0; LastSentMsgId = 0; }
		}

		public DateTime SessionStart => _sessionStart;
		private readonly DateTime _sessionStart = DateTime.UtcNow;
		private readonly SHA256 _sha256 = SHA256.Create();
		private string _pathname;
		private byte[] _apiHash;	// used as AES key for encryption of session file

		internal static Session LoadOrCreate(string pathname, byte[] apiHash)
		{
			if (File.Exists(pathname))
			{
				try
				{
					var session = Load(pathname, apiHash);
					if (session.User != null) { session.UserId = session.User.id; session.User.id = 0; session.User = null; }
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
			return new Session { _pathname = pathname, _apiHash = apiHash };
		}

		internal static Session Load(string pathname, byte[] apiHash)
		{
			var input = File.ReadAllBytes(pathname);
			using var sha256 = SHA256.Create();
			using var aes = Aes.Create();
			using var decryptor = aes.CreateDecryptor(apiHash, input[0..16]);
			var utf8Json = decryptor.TransformFinalBlock(input, 16, input.Length - 16);
			if (!sha256.ComputeHash(utf8Json, 32, utf8Json.Length - 32).SequenceEqual(utf8Json[0..32]))
				throw new ApplicationException("Integrity check failed in session loading");
			return JsonSerializer.Deserialize<Session>(utf8Json.AsSpan(32), Helpers.JsonOptions);
		}

		internal void Save()
		{
			var utf8Json = JsonSerializer.SerializeToUtf8Bytes(this, Helpers.JsonOptions);
			var finalBlock = new byte[16];
			var output = new byte[(16 + 32 + utf8Json.Length + 16) & ~15];
			Encryption.RNG.GetBytes(output, 0, 16);
			using var aes = Aes.Create();
			using var encryptor = aes.CreateEncryptor(_apiHash, output[0..16]);
			encryptor.TransformBlock(_sha256.ComputeHash(utf8Json), 0, 32, output, 16);
			encryptor.TransformBlock(utf8Json, 0, utf8Json.Length & ~15, output, 48);
			utf8Json.AsSpan(utf8Json.Length & ~15).CopyTo(finalBlock);
			encryptor.TransformFinalBlock(finalBlock, 0, utf8Json.Length & 15).CopyTo(output.AsMemory(48 + utf8Json.Length & ~15));
			string tempPathname = _pathname + ".tmp";
			lock (this)
			{
				File.WriteAllBytes(tempPathname, output);
				File.Copy(tempPathname, _pathname, true);
				File.Delete(tempPathname);
			}
		}
	}
}