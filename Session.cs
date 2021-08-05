using System;
using System.Globalization;
using System.IO;
using System.Reflection;
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
		public byte[] User;		// serialization of TL.User

		public DateTime SessionStart => _sessionStart;
		private readonly DateTime _sessionStart = DateTime.UtcNow;
		private string _pathname;

		internal static Session LoadOrCreate(string pathname)
		{
			if (File.Exists(pathname))
			{
				try
				{
					var json = File.ReadAllText(pathname);
					var session = JsonSerializer.Deserialize<Session>(json, Helpers.JsonOptions);
					session._pathname = pathname;
					Helpers.Log(2, "Loaded previous session");
					return session;
				}
				catch (Exception ex)
				{
					Helpers.Log(4, $"Exception while reading session file: {ex.Message}");
				}
			}
			return new Session { _pathname = pathname, Id = Helpers.RandomLong() };
		}

		internal void Save()
		{
			//TODO: Add some encryption (with prepended SHA256) to prevent from stealing the key
			File.WriteAllText(_pathname, JsonSerializer.Serialize(this, Helpers.JsonOptions));
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
	}
}