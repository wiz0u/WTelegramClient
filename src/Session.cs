using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text.Json;

namespace WTelegram
{
	internal class Session : IDisposable
	{
		public int ApiId;
		public long UserId;
		public int MainDC;
		public Dictionary<int, DCSession> DCSessions = new();
		public TL.DcOption[] DcOptions;

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
			
			const int msgIdsN = 512;
			private long[] msgIds;
			private int msgIdsHead;
			internal bool CheckNewMsgId(long msg_id)
			{
				if (msgIds == null)
				{
					msgIds = new long[msgIdsN];
					for (int i = 0; i < msgIdsN; i++) msgIds[i] = msg_id;
					return true;
				}
				int newHead = (msgIdsHead + 1) % msgIdsN;
				if (msg_id > msgIds[msgIdsHead])
					msgIds[msgIdsHead = newHead] = msg_id;
				else if (msg_id <= msgIds[newHead])
					return false;
				else
				{
					int min = 0, max = msgIdsN - 1;
					while (min <= max)  // binary search (rotated at newHead)
					{
						int mid = (min + max) / 2;
						int sign = msg_id.CompareTo(msgIds[(mid + newHead) % msgIdsN]);
						if (sign == 0) return false;
						else if (sign < 0) max = mid - 1;
						else min = mid + 1;
					}
					msgIdsHead = newHead;
					for (min = (min + newHead) % msgIdsN; newHead != min;)
						msgIds[newHead] = msgIds[newHead = newHead == 0 ? msgIdsN - 1 : newHead - 1];
					msgIds[min] = msg_id;
				}
				return true;
			}
		}

		public DateTime SessionStart => _sessionStart;
		private readonly DateTime _sessionStart = DateTime.UtcNow;
		private readonly SHA256 _sha256 = SHA256.Create();
		private Stream _store;
		private byte[] _reuseKey;   // used only if AES Encryptor.CanReuseTransform = false (Mono)
		private byte[] _encrypted = new byte[16];
		private ICryptoTransform _encryptor;
		private Utf8JsonWriter _jsonWriter;
		private readonly MemoryStream _jsonStream = new(4096);

		public void Dispose()
		{
			_sha256.Dispose();
			_store.Dispose();
			_encryptor.Dispose();
			_jsonWriter.Dispose();
			_jsonStream.Dispose();
		}

		internal static Session LoadOrCreate(Stream store, byte[] rgbKey)
		{
			using var aes = Aes.Create();
			Session session = null;
			try
			{
				var length = (int)store.Length;
				if (length > 0)
				{
					var input = new byte[length];
					if (store.Read(input, 0, length) != length)
						throw new ApplicationException($"Can't read session block ({store.Position}, {length})");
					using var sha256 = SHA256.Create();
					using var decryptor = aes.CreateDecryptor(rgbKey, input[0..16]);
					var utf8Json = decryptor.TransformFinalBlock(input, 16, input.Length - 16);
					if (!sha256.ComputeHash(utf8Json, 32, utf8Json.Length - 32).SequenceEqual(utf8Json[0..32]))
						throw new ApplicationException("Integrity check failed in session loading");
					session = JsonSerializer.Deserialize<Session>(utf8Json.AsSpan(32), Helpers.JsonOptions);
					Helpers.Log(2, "Loaded previous session");
				}
			}
			catch (Exception ex)
			{
				store.Dispose();
				throw new ApplicationException($"Exception while reading session file: {ex.Message}\nDelete the file to start a new session", ex);
			}
			session ??= new Session();
			session._store = store;
			Encryption.RNG.GetBytes(session._encrypted, 0, 16);
			session._encryptor = aes.CreateEncryptor(rgbKey, session._encrypted);
			if (!session._encryptor.CanReuseTransform) session._reuseKey = rgbKey;
			session._jsonWriter = new Utf8JsonWriter(session._jsonStream, default);
			return session;
		}

		internal void Save() // must be called with lock(session)
		{
			JsonSerializer.Serialize(_jsonWriter, this, Helpers.JsonOptions);
			var utf8Json = _jsonStream.GetBuffer();
			var utf8JsonLen = (int)_jsonStream.Position;
			int encryptedLen = 64 + (utf8JsonLen & ~15);
			lock (_store) // while updating _encrypted buffer and writing to store
			{
				if (encryptedLen > _encrypted.Length)
					Array.Copy(_encrypted, _encrypted = new byte[encryptedLen + 256], 16);
				_encryptor.TransformBlock(_sha256.ComputeHash(utf8Json, 0, utf8JsonLen), 0, 32, _encrypted, 16);
				_encryptor.TransformBlock(utf8Json, 0, encryptedLen - 64, _encrypted, 48);
				_encryptor.TransformFinalBlock(utf8Json, encryptedLen - 64, utf8JsonLen & 15).CopyTo(_encrypted, encryptedLen - 16);
				if (!_encryptor.CanReuseTransform) // under Mono, AES encryptor is not reusable
					using (var aes = Aes.Create())
						_encryptor = aes.CreateEncryptor(_reuseKey, _encrypted[0..16]);
				_store.Position = 0;
				_store.Write(_encrypted, 0, encryptedLen);
				_store.SetLength(encryptedLen);
			}
			_jsonStream.Position = 0;
			_jsonWriter.Reset();
		}
	}

	internal class SessionStore : FileStream
	{
		public override long Length { get; }
		public override long Position { get => base.Position; set { } }
		public override void SetLength(long value) { }
		private readonly byte[] _header = new byte[8];
		private int _nextPosition = 8;

		public SessionStore(string pathname)
			: base(pathname, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, 1) // no in-app buffering
		{
			if (base.Read(_header, 0, 8) == 8)
			{
				var position = BinaryPrimitives.ReadInt32LittleEndian(_header);
				var length = BinaryPrimitives.ReadInt32LittleEndian(_header.AsSpan(4));
				if (position < 0 || length < 0 || position >= 65536 || length >= 32768) { position = 0; length = (int)base.Length; }
				base.Position = position;
				Length = length;
				_nextPosition = position + length;
			}
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			if (_nextPosition > count * 3) _nextPosition = 8;
			base.Position = _nextPosition;
			base.Write(buffer, offset, count);
			BinaryPrimitives.WriteInt32LittleEndian(_header, _nextPosition);
			BinaryPrimitives.WriteInt32LittleEndian(_header.AsSpan(4), count);
			_nextPosition += count;
			base.Position = 0;
			base.Write(_header, 0, 8);
		}
	}
}