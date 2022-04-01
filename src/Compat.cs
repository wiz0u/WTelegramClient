using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Security.Cryptography;

#if NETCOREAPP2_1_OR_GREATER
namespace WTelegram
{
	static class Compat
	{
		internal static BigInteger BigEndianInteger(byte[] value) => new(value, true, true);
		internal static IPEndPoint IPEndPoint_Parse(string addr) => IPEndPoint.Parse(addr);
	}
}
#else
namespace WTelegram
{
	static class Compat
	{
		internal static BigInteger BigEndianInteger(byte[] value)
		{
			var data = new byte[value.Length + 1];
			value.CopyTo(data, 1);
			Array.Reverse(data);
			return new BigInteger(data);
		}

		internal static byte[] ToByteArray(this BigInteger bigInteger, bool isUnsigned, bool isBigEndian)
		{
			if (!isBigEndian || !isUnsigned) throw new ArgumentException("Unexpected parameters to ToByteArray");
			var result = bigInteger.ToByteArray();
			if (result[^1] == 0) result = result[0..^1];
			Array.Reverse(result);
			return result;
		}

		internal static long GetBitLength(this BigInteger bigInteger)
		{
			var bytes = bigInteger.ToByteArray();
			var length = bytes.LongLength * 8L;
			int lastByte = bytes[^1];
			while ((lastByte & 0x80) == 0) { length--; lastByte = (lastByte << 1) + 1; }
			return length;
		}

		public static V GetValueOrDefault<K, V>(this Dictionary<K, V> dictionary, K key, V defaultValue = default)
			=> dictionary.TryGetValue(key, out V value) ? value : defaultValue;

		public static void Deconstruct<K, V>(this KeyValuePair<K, V> kvp, out K key, out V value) { key = kvp.Key; value = kvp.Value; }

		internal static IPEndPoint IPEndPoint_Parse(string addr)
		{
			int colon = addr.LastIndexOf(':');
			return new IPEndPoint(IPAddress.Parse(addr[0..colon]), int.Parse(addr[(colon + 1)..]));
		}

		internal static void ImportFromPem(this RSA rsa, string pem)
		{
			var header = pem.IndexOf("-----BEGIN RSA PUBLIC KEY-----");
			var footer = pem.IndexOf("-----END RSA PUBLIC KEY-----");
			if (header == -1 || footer <= header) throw new ArgumentException("Invalid RSA Public Key");
			byte[] bytes = System.Convert.FromBase64String(pem[(header+30)..footer]);
			if (bytes.Length != 270 || BinaryPrimitives.ReadInt64BigEndian(bytes) != 0x3082010A02820101 || bytes[265] != 0x02 || bytes[266] != 0x03)
				throw new ArgumentException("Unrecognized sequence in RSA Public Key");
			rsa.ImportParameters(new RSAParameters { Modulus = bytes[8..265], Exponent = bytes[267..270] });
		}
	}
}

static class Convert
{
	internal static string ToHexString(byte[] data) => BitConverter.ToString(data).Replace("-", "");
	internal static byte[] FromHexString(string hex) => Enumerable.Range(0, hex.Length / 2).Select(i => System.Convert.ToByte(hex.Substring(i * 2, 2), 16)).ToArray();
}
#endif

#if NETSTANDARD2_0
namespace System.Runtime.CompilerServices
{
	internal static class RuntimeHelpers
	{
		public static T[] GetSubArray<T>(T[] array, Range range)
		{
			if (array == null) throw new ArgumentNullException();
			var (offset, length) = range.GetOffsetAndLength(array.Length);
			if (length == 0) return Array.Empty<T>();
			var dest = typeof(T).IsValueType || typeof(T[]) == array.GetType() ? new T[length]
				: (T[])Array.CreateInstance(array.GetType().GetElementType()!, length);
			Array.Copy(array, offset, dest, 0, length);
			return dest;
		}
	}
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal class IsExternalInit { }
}
#endif