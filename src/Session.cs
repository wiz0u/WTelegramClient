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
	internal class Session
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
		}

		public DateTime SessionStart => _sessionStart;
		private readonly DateTime _sessionStart = DateTime.UtcNow;
		private readonly SHA256 _sha256 = SHA256.Create();
		private Stream _store;
		private byte[] _rgbKey;	// 32-byte encryption key
		private static readonly Aes aes = Aes.Create();

		internal static Session LoadOrCreate(Stream store, byte[] rgbKey)
		{
			try
			{
				var length = (int)store.Length;
				if (length > 0)
				{
					var input = new byte[length];
					if (store.Read(input, 0, length) != length)
						throw new ApplicationException($"Can't read session block ({store.Position}, {length})");
					var session = Load(input, rgbKey);
					session._store = store;
					session._rgbKey = rgbKey;
					Helpers.Log(2, "Loaded previous session");
					return session;
				}
			}
			catch (Exception ex)
			{
				store.Dispose();
				throw new ApplicationException($"Exception while reading session file: {ex.Message}\nDelete the file to start a new session", ex);
			}
			return new Session { _store = store, _rgbKey = rgbKey };
		}

		internal void Dispose() => _store.Dispose();

		internal static Session Load(byte[] input, byte[] rgbKey)
		{
			using var sha256 = SHA256.Create();
			using var decryptor = aes.CreateDecryptor(rgbKey, input[0..16]);
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
			using var encryptor = aes.CreateEncryptor(_rgbKey, output[0..16]);
			encryptor.TransformBlock(_sha256.ComputeHash(utf8Json), 0, 32, output, 16);
			encryptor.TransformBlock(utf8Json, 0, utf8Json.Length & ~15, output, 48);
			utf8Json.AsSpan(utf8Json.Length & ~15).CopyTo(finalBlock);
			encryptor.TransformFinalBlock(finalBlock, 0, utf8Json.Length & 15).CopyTo(output.AsMemory(48 + utf8Json.Length & ~15));
			lock (_store)
			{
				_store.Position = 0;
				_store.Write(output, 0, output.Length);
				_store.SetLength(output.Length);
			}
		}
	}

	internal class SessionStore : FileStream
	{
		public override long Length { get; }
		private readonly byte[] _header = new byte[8];
		private int _nextPosition = 8;
		public override long Position { get => base.Position; set { } }
		public override void SetLength(long value) { }

		public SessionStore(string pathname)
			: base(pathname, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, 1) // no buffering
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