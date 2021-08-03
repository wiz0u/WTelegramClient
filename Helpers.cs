using System;
using System.Collections.Generic;

namespace WTelegram
{
	public static class Helpers
	{
		public static readonly System.Text.Json.JsonSerializerOptions JsonOptions = new(System.Text.Json.JsonSerializerDefaults.Web) { IncludeFields = true };

		public static V GetOrCreate<K, V>(this Dictionary<K, V> dictionary, K key) where V : new()
			=> dictionary.TryGetValue(key, out V value) ? value : dictionary[key] = new V();

		public static void LittleEndian(byte[] buffer, int offset, int value)
		{
			buffer[offset + 0] = (byte)value;
			buffer[offset + 1] = (byte)(value >> 8);
			buffer[offset + 2] = (byte)(value >> 16);
			buffer[offset + 3] = (byte)(value >> 24);
		}

		public static void LittleEndian(byte[] buffer, int offset, long value)
		{
			buffer[offset + 0] = (byte)value;
			buffer[offset + 1] = (byte)(value >> 8);
			buffer[offset + 2] = (byte)(value >> 16);
			buffer[offset + 3] = (byte)(value >> 24);
			buffer[offset + 4] = (byte)(value >> 32);
			buffer[offset + 5] = (byte)(value >> 40);
			buffer[offset + 6] = (byte)(value >> 48);
			buffer[offset + 7] = (byte)(value >> 56);
		}

		public static byte[] ToBigEndian(ulong value)
		{
			int i;
			var temp = value;
			for (i = 1; (temp >>= 8) != 0; i++);
			var result = new byte[i];
			while (--i >= 0) { result[i] = (byte)value; value >>= 8; }
			return result;
		}

		public static ulong FromBigEndian(byte[] bytes)
		{
			if (bytes.Length > 8) throw new ArgumentException($"expected bytes length <=8 but got {bytes.Length}");
			ulong result = 0;
			foreach (byte b in bytes)
				result = (result << 8) + b;
			return result;
		}

		public static ulong PQFactorize(ulong pq)
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
					ulong a = x;
					ulong b = x;
					ulong c = q;

					// c += a * b
					while (b != 0)
					{
						if ((b & 1) != 0)
						{
							c += a;
							if (c >= pq)
								c -= pq;
						}
						a += a;
						if (a >= pq)
							a -= pq;
						b >>= 1;
					}

					x = c;
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

			static ulong gcd(ulong a, ulong b)
			{
				if (a == 0) return b;
				if (b == 0) return a;

				int shift = 0;
				while ((a & 1) == 0 && (b & 1) == 0)
				{
					a >>= 1;
					b >>= 1;
					shift++;
				}

				while (true)
				{
					while ((a & 1) == 0)
						a >>= 1;
					while ((b & 1) == 0)
						b >>= 1;
					if (a > b)
						a -= b;
					else if (b > a)
						b -= a;
					else
						return a << shift;
				}
			}
		}
	}
}
