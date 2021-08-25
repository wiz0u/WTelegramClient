using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Net;
using System.Numerics;
using System.Security.Cryptography;

namespace WTelegram
{
	static class Compat
	{
		// see also https://github.com/dotnet/runtime/issues/2036 and https://github.com/dotnet/runtime/pull/53623
		internal static readonly Func<uint, byte[], int, int, uint> UpdateCrc32 = (Func<uint, byte[], int, int, uint>)
			typeof(System.IO.Compression.ZipArchive).Assembly.GetType("System.IO.Compression.Crc32Helper")
			.GetMethod("UpdateCrc32", new[] { typeof(uint), typeof(byte[]), typeof(int), typeof(int) })
			.CreateDelegate(typeof(Func<uint, byte[], int, int, uint>));

#if NETCOREAPP2_1_OR_GREATER
		internal static IPEndPoint IPEndPoint_Parse(string addr) => IPEndPoint.Parse(addr);
		internal static BigInteger BigEndianInteger(byte[] value) => new(value, true, true);
#else
		internal static BigInteger BigEndianInteger(byte[] value)
		{
			var data = new byte[value.Length + 1];
			value.CopyTo(data, 1);
			Array.Reverse(data);
			return new BigInteger(data);
		}

		internal static byte[] ToByteArray(this BigInteger bigInteger, bool isUnsigned = false, bool isBigEndian = false)
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

		public static void Deconstruct<K, V>(this KeyValuePair<K, V> kvp, out K key, out V value)
		{
			key = kvp.Key;
			value = kvp.Value;
		}

		internal static IPEndPoint IPEndPoint_Parse(string addr)
		{
			int colon = addr.IndexOf(':');
			return new IPEndPoint(IPAddress.Parse(addr[0..colon]), int.Parse(addr[(colon + 1)..]));
		}

		internal static void ImportFromPem(this RSA rsa, string pem)
		{
			var header = pem.IndexOf("-----BEGIN RSA PUBLIC KEY-----");
			var footer = pem.IndexOf("-----END RSA PUBLIC KEY-----");
			if (header == -1 || footer <= header) throw new ArgumentException("Invalid RSA Public Key");
			byte[] bytes = System.Convert.FromBase64String(pem[(header+30)..footer]);
			var reader = new AsnReader(bytes, AsnEncodingRules.BER);
			reader = reader.ReadSequence(Asn1Tag.Sequence);
			var m = reader.ReadIntegerBytes();
			var e = reader.ReadIntegerBytes();
			rsa.ImportParameters(new RSAParameters { Modulus = m.ToArray(), Exponent = e.ToArray() });
		}
	}

	static class Convert
	{
		internal static byte[] FromHexString(string hex)
		{
			int NumberChars = hex.Length;
			byte[] bytes = new byte[NumberChars / 2];
			for (int i = 0; i < NumberChars; i += 2)
				bytes[i / 2] = System.Convert.ToByte(hex.Substring(i, 2), 16);
			return bytes;
		}
#endif
	}
}
