using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;

// I really respect Wizou's work on this library, but the session workflow is poorly disigned (ridiculous)
//	with no way to swap session/store implementation
// So I have removed the encryption stuff completely.
// Now the session is stored as plain JSON, and Wizou can continue inventing bicycles on his own 

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
			public long OldSalt;        // still accepted for a further 1800 seconds
			public long Salt;
			public SortedList<DateTime, long> Salts;
			public int Seqno;
			public long ServerTicksOffset;
			public long LastSentMsgId;
			public TL.DcOption DataCenter;
			public bool WithoutUpdates;

			internal Client Client;
			internal int DcID => DataCenter?.id ?? 0;
			internal IPEndPoint EndPoint => DataCenter == null ? null : new(IPAddress.Parse(DataCenter.ip_address), DataCenter.port);
			internal void Renew() { Helpers.Log(3, $"Renewing session on DC {DcID}..."); Id = Helpers.RandomLong(); Seqno = 0; LastSentMsgId = 0; }
			public void DisableUpdates(bool disable = true) { if (WithoutUpdates != disable) { WithoutUpdates = disable; Renew(); } }

			const int MsgIdsN = 512;
			private long[] _msgIds;
			private int _msgIdsHead;
			internal bool CheckNewMsgId(long msg_id)
			{
				if (_msgIds == null)
				{
					_msgIds = new long[MsgIdsN];
					_msgIds[0] = msg_id;
					msg_id -= 300L << 32; // until the array is filled with real values, allow ids up to 300 seconds in the past
					for (int i = 1; i < MsgIdsN; i++) _msgIds[i] = msg_id;
					return true;
				}
				int newHead = (_msgIdsHead + 1) % MsgIdsN;
				if (msg_id > _msgIds[_msgIdsHead])
					_msgIds[_msgIdsHead = newHead] = msg_id;
				else if (msg_id <= _msgIds[newHead])
					return false;
				else
				{
					int min = 0, max = MsgIdsN - 1;
					while (min <= max)  // binary search (rotated at newHead)
					{
						int mid = (min + max) / 2;
						int sign = msg_id.CompareTo(_msgIds[(mid + newHead) % MsgIdsN]);
						if (sign == 0) return false;
						else if (sign < 0) max = mid - 1;
						else min = mid + 1;
					}
					_msgIdsHead = newHead;
					for (min = (min + newHead) % MsgIdsN; newHead != min;)
						_msgIds[newHead] = _msgIds[newHead = newHead == 0 ? MsgIdsN - 1 : newHead - 1];
					_msgIds[min] = msg_id;
				}
				return true;
			}
		}

		public DateTime SessionStart => _sessionStart;
		private readonly DateTime _sessionStart = DateTime.UtcNow;
		private Stream _store;
		private byte[] _encrypted = new byte[16];
		private Utf8JsonWriter _jsonWriter;
		private readonly MemoryStream _jsonStream = new(4096);

		public void Dispose()
		{
			_store.Dispose();
			_jsonWriter.Dispose();
			_jsonStream.Dispose();
		}

		internal static Session LoadOrCreate(Stream store)
		{
			Session session = null;
			
			try
			{
				var length = (int)store.Length;
			
				if (length > 0)
				{
					var utf8Json = new byte[length];

					if (store.Read(utf8Json, 0, length) != length)
					{
						throw new WTException($"Can't read session block ({store.Position}, {length})");
					}

					session = JsonSerializer.Deserialize<Session>(utf8Json.AsSpan(32), Helpers.JsonOptions);
					Helpers.Log(2, "Loaded previous session");
				}
				
				session ??= new Session();
				session._store = store;
				session._jsonWriter = new Utf8JsonWriter(session._jsonStream, default);
				
				return session;
			}
			catch (Exception ex)
			{
				store.Dispose();
				throw new WTException($"Exception while reading session file: {ex.Message}\nUse the correct api_hash/id/key, or delete the file to start a new session", ex);
			}
		}

		internal void Save() // must be called with lock(session)
		{
			JsonSerializer.Serialize(_jsonWriter, this, Helpers.JsonOptions);
			var utf8Json = _jsonStream.GetBuffer();
			var utf8JsonLen = (int)_jsonStream.Position;

			lock (_store) // while updating _encrypted buffer and writing to store
			{
				_store.Write(utf8Json, 0, utf8JsonLen);
				_store.SetLength(utf8JsonLen);
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