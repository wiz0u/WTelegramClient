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
		private FileStream _fileStream;
		private int _nextPosition;
		private byte[] _rgbKey;	// 32-byte encryption key
		private static readonly Aes aes = Aes.Create();

		internal static Session LoadOrCreate(string pathname, byte[] rgbKey)
		{
			var header = new byte[8];
			var fileStream = new FileStream(pathname, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, 1); // no buffering
			try
			{
				if (fileStream.Read(header, 0, 8) == 8)
				{
					var position = BinaryPrimitives.ReadInt32LittleEndian(header);
					var length = BinaryPrimitives.ReadInt32LittleEndian(header.AsSpan(4));
					if (position < 0 || length < 0 || position >= 65536 || length >= 32768) { position = 0; length = (int)fileStream.Length; }
					var input = new byte[length];
					fileStream.Position = position;
					if (fileStream.Read(input, 0, length) != length)
						throw new ApplicationException($"Can't read session block ({position}, {length})");
					var session = Load(input, rgbKey);
					session._fileStream = fileStream;
					session._nextPosition = position + length;
					session._rgbKey = rgbKey;
					Helpers.Log(2, "Loaded previous session");
					return session;
				}
			}
			catch (Exception ex)
			{
				fileStream.Dispose();
				throw new ApplicationException($"Exception while reading session file: {ex.Message}\nDelete the file to start a new session", ex);
			}
			return new Session { _fileStream = fileStream, _nextPosition = 8, _rgbKey = rgbKey };
		}

		internal void Dispose() => _fileStream.Dispose();

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
			lock (this)
			{
				if (_nextPosition > output.Length * 3) _nextPosition = 8;
				_fileStream.Position = _nextPosition;
				_fileStream.Write(output, 0, output.Length);
				BinaryPrimitives.WriteInt32LittleEndian(finalBlock, _nextPosition);
				BinaryPrimitives.WriteInt32LittleEndian(finalBlock.AsSpan(4), output.Length);
				_nextPosition += output.Length;
				_fileStream.Position = 0;
				_fileStream.Write(finalBlock, 0, 8);
			}
		}
	}
}