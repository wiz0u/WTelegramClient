using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

#if NET8_0_OR_GREATER
[JsonSerializable(typeof(WTelegram.Session))]
[JsonSerializable(typeof(Dictionary<long, WTelegram.UpdateManager.MBoxState>))]
[JsonSerializable(typeof(IDictionary<long, WTelegram.UpdateManager.MBoxState>))]
[JsonSerializable(typeof(System.Collections.Immutable.ImmutableDictionary<long, WTelegram.UpdateManager.MBoxState>))]
internal partial class WTelegramContext : JsonSerializerContext { }
#endif

namespace WTelegram
{
	public static class Helpers
	{
		/// <summary>Callback for logging a line (string) with its associated <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loglevel">severity level</see> (int)</summary>
		public static Action<int, string> Log { get; set; } = DefaultLogger;

		/// <summary>For serializing indented Json with fields included</summary>
		public static readonly JsonSerializerOptions JsonOptions = new() { IncludeFields = true, WriteIndented = true,
#if NET8_0_OR_GREATER
			TypeInfoResolver = JsonSerializer.IsReflectionEnabledByDefault ? null : WTelegramContext.Default,
			Converters = { new TLJsonConverter(), new JsonStringEnumConverter() },
#endif
			IgnoreReadOnlyProperties = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };

#if NET8_0_OR_GREATER
		public sealed class TLJsonConverter : JsonConverter<object>
		{
			public override bool CanConvert(Type typeToConvert)
				=> typeToConvert.IsAbstract || typeToConvert == typeof(Dictionary<long, TL.User>) || typeToConvert == typeof(Dictionary<long, TL.ChatBase>);
			public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
			{
				if (typeToConvert == typeof(Dictionary<long, TL.User>))
				{
					if (reader.TokenType != JsonTokenType.StartArray) throw new JsonException("Expected array for users dictionary");
					var users = new Dictionary<long, TL.User>();
					while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
					{
						var user = JsonSerializer.Deserialize<TL.User>(ref reader, options);
						if (user != null) users[user.id] = user;
					}
					return users;
				}
				else if (typeToConvert == typeof(Dictionary<long, TL.ChatBase>))
				{
					if (reader.TokenType != JsonTokenType.StartArray) throw new JsonException("Expected array for chats dictionary");
					var chats = new Dictionary<long, TL.ChatBase>();
					while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
					{
						var chat = (TL.ChatBase)Read(ref reader, typeof(TL.ChatBase), options);
						if (chat != null) chats[chat.ID] = chat;
					}
					return chats;
				}
				else if (reader.TokenType == JsonTokenType.Null)
					return null;
				else if (reader.TokenType == JsonTokenType.StartObject)
				{
					var typeReader = reader;
					if (!typeReader.Read() || typeReader.TokenType != JsonTokenType.PropertyName || typeReader.GetString() != "$")
						throw new JsonException("Expected $ type property");
					if (!typeReader.Read() || typeReader.TokenType != JsonTokenType.String)
						throw new JsonException("Invalid $ type property");
					var type = typeReader.GetString();
					var actualType = typeToConvert.Assembly.GetType("TL." + type);
					if (!typeToConvert.IsAssignableFrom(actualType))
						throw new JsonException($"Incompatible $ type: {type} -> {typeToConvert}");
					return JsonSerializer.Deserialize(ref reader, actualType, options);
				}
				throw new JsonException($"Unexpected token type: {reader.TokenType}");
			}
			public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
			{
				if (value is Dictionary<long, TL.User> users)
				{
					writer.WriteStartArray();
					foreach (var element in users.Values)
						JsonSerializer.Serialize(writer, element, options);
					writer.WriteEndArray();
				}
				else if (value is Dictionary<long, TL.ChatBase> chats)
				{
					writer.WriteStartArray();
					foreach (var element in chats.Values)
						Write(writer, element, options);
					writer.WriteEndArray();
				}
				else if (value is null)
					writer.WriteNullValue();
				else
				{
					var actualType = value.GetType();
					var jsonObject = JsonSerializer.SerializeToElement(value, actualType, options);
					writer.WriteStartObject();
					writer.WriteString("$", actualType.Name);
					foreach (var property in jsonObject.EnumerateObject())
						if (char.IsLower(property.Name[0]))
							property.WriteTo(writer);
					writer.WriteEndObject();
				}
			}
		}
#endif

		private static readonly ConsoleColor[] LogLevelToColor = [ ConsoleColor.DarkGray, ConsoleColor.DarkCyan,
			ConsoleColor.Cyan, ConsoleColor.Yellow, ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.DarkBlue ];
		private static void DefaultLogger(int level, string message)
		{
			Console.ForegroundColor = LogLevelToColor[level];
			Console.WriteLine(message);
			Console.ResetColor();
		}

		public static V GetOrCreate<K, V>(this Dictionary<K, V> dictionary, K key) where V : new()
			=> dictionary.TryGetValue(key, out V value) ? value : dictionary[key] = new V();

		/// <summary>Get a cryptographic random 64-bit value</summary>
		public static long RandomLong()
		{
#if NETCOREAPP2_1_OR_GREATER
			long value = 0;
			System.Security.Cryptography.RandomNumberGenerator.Fill(System.Runtime.InteropServices.MemoryMarshal.AsBytes(
				System.Runtime.InteropServices.MemoryMarshal.CreateSpan(ref value, 1)));
			return value;
#else
			var span = new byte[8];
			Encryption.RNG.GetBytes(span);
			return BitConverter.ToInt64(span, 0);
#endif
		}

		public static async Task<int> FullReadAsync(this Stream stream, byte[] buffer, int length, CancellationToken ct)
		{
			for (int offset = 0; offset < length;)
			{
#pragma warning disable CA1835
				var read = await stream.ReadAsync(buffer, offset, length - offset, ct);
#pragma warning restore CA1835
				if (read == 0) return offset;
				offset += read;
			}
			return length;
		}

		internal static byte[] ToBigEndian(ulong value) // variable-size buffer
		{
			int i = 1;
			for (ulong temp = value; (temp >>= 8) != 0; ) i++;
			var result = new byte[i];
			for (; --i >= 0; value >>= 8)
				result[i] = (byte)value;
			return result;
		}

		internal static ulong FromBigEndian(byte[] bytes) // variable-size buffer
		{
			if (bytes.Length > 8) throw new ArgumentException($"expected bytes length <= 8 but got {bytes.Length}");
			ulong result = 0;
			foreach (byte b in bytes)
				result = (result << 8) + b;
			return result;
		}

		internal static byte[] To256Bytes(this BigInteger bi)
		{
			var bigEndian = bi.ToByteArray(true, true);
			if (bigEndian.Length == 256) return bigEndian;
			var result = new byte[256];
			bigEndian.CopyTo(result, 256 - bigEndian.Length);
			return result;
		}

		internal static ulong PQFactorize(ulong pq) // ported from https://github.com/tdlib/td/blob/master/tdutils/td/utils/crypto.cpp#L103
		{
			if (pq < 2) return 1;
			var random = new Random();
			ulong g = 0;
			for (int i = 0, iter = 0; i < 3 || iter < 1000; i++)
			{
				ulong q = (ulong)random.Next(17, 32) % (pq - 1);
				ulong x = ((ulong)random.Next() + (ulong)random.Next() << 31) % (pq - 1) + 1;
				ulong y = x;
				int lim = 1 << (Math.Min(5, i) + 18);
				for (int j = 1; j < lim; j++)
				{
					iter++;
					// x = (q + x * x) % pq
					ulong res = q, a = x;
					while (x != 0)
					{
						if ((x & 1) != 0)
							res = (res + a) % pq;
						a = (a + a) % pq;
						x >>= 1;
					}
					x = res;
					ulong z = x < y ? pq + x - y : x - y;
					g = gcd(z, pq);
					if (g != 1)
						break;

					if ((j & (j - 1)) == 0)
						y = x;
				}
				if (g > 1 && g < pq)
					break;
			}
			if (g != 0)
			{
				ulong other = pq / g;
				if (other < g)
					g = other;
			}
			return g;

			static ulong gcd(ulong left, ulong right)
			{
				while (right != 0)
				{
					ulong num = left % right;
					left = right;
					right = num;
				}
				return left;
			}
		}

		public static int MillerRabinIterations { get; set; } = 64; // 64 is OpenSSL default for 2048-bits numbers
		/// <summary>Miller–Rabin primality test</summary>
		/// <param name="n">The number to check for primality</param>
		public static bool IsProbablePrime(this BigInteger n)
		{
			var n_minus_one = n - BigInteger.One;
			if (n_minus_one.Sign <= 0) return false;

			int s;
			var d = n_minus_one;
			for (s = 0; d.IsEven; s++) d >>= 1;

			var bitLen = n.GetBitLength();
			var randomBytes = new byte[bitLen / 8 + 1];
			var lastByteMask = (byte)((1 << (int)(bitLen % 8)) - 1);
			BigInteger a;
			if (MillerRabinIterations < 15) // 15 is the minimum recommended by Telegram
				Log(3, $"MillerRabinIterations ({MillerRabinIterations}) is below the minimal level of safety (15)");
			for (int i = 0; i < MillerRabinIterations; i++)
			{
				do
				{
					Encryption.RNG.GetBytes(randomBytes);
					randomBytes[^1] &= lastByteMask; // we don't want more bits than necessary
					a = new BigInteger(randomBytes);
				}
				while (a < 3 || a >= n_minus_one);
				a--;

				var x = BigInteger.ModPow(a, d, n);
				if (x.IsOne || x == n_minus_one) continue;

				int r;
				for (r = s - 1; r > 0; r--)
				{
					x = BigInteger.ModPow(x, 2, n);
					if (x.IsOne) return false;
					if (x == n_minus_one) break;
				}
				if (r == 0) return false;
			}
			return true;
		}

		internal static readonly byte[] StrippedThumbJPG = // see https://core.telegram.org/api/files#stripped-thumbnails
		[
			0xff, 0xd8, 0xff, 0xe0, 0x00, 0x10, 0x4a, 0x46, 0x49,
			0x46, 0x00, 0x01, 0x01, 0x00, 0x00, 0x01, 0x00, 0x01, 0x00, 0x00, 0xff, 0xdb, 0x00, 0x43, 0x00, 0x28, 0x1c,
			0x1e, 0x23, 0x1e, 0x19, 0x28, 0x23, 0x21, 0x23, 0x2d, 0x2b, 0x28, 0x30, 0x3c, 0x64, 0x41, 0x3c, 0x37, 0x37,
			0x3c, 0x7b, 0x58, 0x5d, 0x49, 0x64, 0x91, 0x80, 0x99, 0x96, 0x8f, 0x80, 0x8c, 0x8a, 0xa0, 0xb4, 0xe6, 0xc3,
			0xa0, 0xaa, 0xda, 0xad, 0x8a, 0x8c, 0xc8, 0xff, 0xcb, 0xda, 0xee, 0xf5, 0xff, 0xff, 0xff, 0x9b, 0xc1, 0xff,
			0xff, 0xff, 0xfa, 0xff, 0xe6, 0xfd, 0xff, 0xf8, 0xff, 0xdb, 0x00, 0x43, 0x01, 0x2b, 0x2d, 0x2d, 0x3c, 0x35,
			0x3c, 0x76, 0x41, 0x41, 0x76, 0xf8, 0xa5, 0x8c, 0xa5, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8,
			0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8,
			0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xf8,
			0xf8, 0xf8, 0xf8, 0xf8, 0xf8, 0xff, 0xc0, 0x00, 0x11, 0x08, 0x00, 0x00, 0x00, 0x00, 0x03, 0x01, 0x22, 0x00,
			0x02, 0x11, 0x01, 0x03, 0x11, 0x01, 0xff, 0xc4, 0x00, 0x1f, 0x00, 0x00, 0x01, 0x05, 0x01, 0x01, 0x01, 0x01,
			0x01, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
			0x09, 0x0a, 0x0b, 0xff, 0xc4, 0x00, 0xb5, 0x10, 0x00, 0x02, 0x01, 0x03, 0x03, 0x02, 0x04, 0x03, 0x05, 0x05,
			0x04, 0x04, 0x00, 0x00, 0x01, 0x7d, 0x01, 0x02, 0x03, 0x00, 0x04, 0x11, 0x05, 0x12, 0x21, 0x31, 0x41, 0x06,
			0x13, 0x51, 0x61, 0x07, 0x22, 0x71, 0x14, 0x32, 0x81, 0x91, 0xa1, 0x08, 0x23, 0x42, 0xb1, 0xc1, 0x15, 0x52,
			0xd1, 0xf0, 0x24, 0x33, 0x62, 0x72, 0x82, 0x09, 0x0a, 0x16, 0x17, 0x18, 0x19, 0x1a, 0x25, 0x26, 0x27, 0x28,
			0x29, 0x2a, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3a, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4a, 0x53,
			0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5a, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6a, 0x73, 0x74, 0x75,
			0x76, 0x77, 0x78, 0x79, 0x7a, 0x83, 0x84, 0x85, 0x86, 0x87, 0x88, 0x89, 0x8a, 0x92, 0x93, 0x94, 0x95, 0x96,
			0x97, 0x98, 0x99, 0x9a, 0xa2, 0xa3, 0xa4, 0xa5, 0xa6, 0xa7, 0xa8, 0xa9, 0xaa, 0xb2, 0xb3, 0xb4, 0xb5, 0xb6,
			0xb7, 0xb8, 0xb9, 0xba, 0xc2, 0xc3, 0xc4, 0xc5, 0xc6, 0xc7, 0xc8, 0xc9, 0xca, 0xd2, 0xd3, 0xd4, 0xd5, 0xd6,
			0xd7, 0xd8, 0xd9, 0xda, 0xe1, 0xe2, 0xe3, 0xe4, 0xe5, 0xe6, 0xe7, 0xe8, 0xe9, 0xea, 0xf1, 0xf2, 0xf3, 0xf4,
			0xf5, 0xf6, 0xf7, 0xf8, 0xf9, 0xfa, 0xff, 0xc4, 0x00, 0x1f, 0x01, 0x00, 0x03, 0x01, 0x01, 0x01, 0x01, 0x01,
			0x01, 0x01, 0x01, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
			0x09, 0x0a, 0x0b, 0xff, 0xc4, 0x00, 0xb5, 0x11, 0x00, 0x02, 0x01, 0x02, 0x04, 0x04, 0x03, 0x04, 0x07, 0x05,
			0x04, 0x04, 0x00, 0x01, 0x02, 0x77, 0x00, 0x01, 0x02, 0x03, 0x11, 0x04, 0x05, 0x21, 0x31, 0x06, 0x12, 0x41,
			0x51, 0x07, 0x61, 0x71, 0x13, 0x22, 0x32, 0x81, 0x08, 0x14, 0x42, 0x91, 0xa1, 0xb1, 0xc1, 0x09, 0x23, 0x33,
			0x52, 0xf0, 0x15, 0x62, 0x72, 0xd1, 0x0a, 0x16, 0x24, 0x34, 0xe1, 0x25, 0xf1, 0x17, 0x18, 0x19, 0x1a, 0x26,
			0x27, 0x28, 0x29, 0x2a, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3a, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4a,
			0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5a, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6a, 0x73, 0x74,
			0x75, 0x76, 0x77, 0x78, 0x79, 0x7a, 0x82, 0x83, 0x84, 0x85, 0x86, 0x87, 0x88, 0x89, 0x8a, 0x92, 0x93, 0x94,
			0x95, 0x96, 0x97, 0x98, 0x99, 0x9a, 0xa2, 0xa3, 0xa4, 0xa5, 0xa6, 0xa7, 0xa8, 0xa9, 0xaa, 0xb2, 0xb3, 0xb4,
			0xb5, 0xb6, 0xb7, 0xb8, 0xb9, 0xba, 0xc2, 0xc3, 0xc4, 0xc5, 0xc6, 0xc7, 0xc8, 0xc9, 0xca, 0xd2, 0xd3, 0xd4,
			0xd5, 0xd6, 0xd7, 0xd8, 0xd9, 0xda, 0xe2, 0xe3, 0xe4, 0xe5, 0xe6, 0xe7, 0xe8, 0xe9, 0xea, 0xf2, 0xf3, 0xf4,
			0xf5, 0xf6, 0xf7, 0xf8, 0xf9, 0xfa, 0xff, 0xda, 0x00, 0x0c, 0x03, 0x01, 0x00, 0x02, 0x11, 0x03, 0x11, 0x00,
			0x3f, 0x00
		];

		internal static string GetSystemVersion()
		{
			var os = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
			int space = os.IndexOf(' ') + 1, dot = os.IndexOf('.');
			return os[(os.IndexOf(' ', space) < 0 ? 0 : space)..(dot < 0 ? os.Length : dot)];
		}

		internal static string GetAppVersion()
			=> (Assembly.GetEntryAssembly() ?? Array.Find(AppDomain.CurrentDomain.GetAssemblies(), a => a.EntryPoint != null))?.GetName().Version.ToString() ?? "0.0";

		public class IndirectStream(Stream innerStream) : Stream
		{
			public long? ContentLength;
			protected readonly Stream _innerStream = innerStream;
			public override bool CanRead => _innerStream.CanRead;
			public override bool CanSeek => ContentLength.HasValue || _innerStream.CanSeek;
			public override bool CanWrite => _innerStream.CanWrite;
			public override long Length => ContentLength ?? _innerStream.Length;
			public override long Position { get => _innerStream.Position; set => _innerStream.Position = value; }
			public override void Flush() => _innerStream.Flush();
			public override long Seek(long offset, SeekOrigin origin) => _innerStream.Seek(offset, origin);
			public override void SetLength(long value) => _innerStream.SetLength(value);
			public override void Write(byte[] buffer, int offset, int count) => _innerStream.Write(buffer, offset, count);
			public override int Read(byte[] buffer, int offset, int count) => _innerStream.Read(buffer, offset, count);
			protected override void Dispose(bool disposing) => _innerStream.Dispose();
		}
	}

	public class WTException : ApplicationException
	{
		public WTException(string message) : base(message) { }
		public WTException(string message, Exception innerException) : base(message, innerException) { }
	}
}
