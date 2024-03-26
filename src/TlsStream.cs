using System;
using System.Buffers.Binary;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

// necessary for .NET Standard 2.0 compilation:
#pragma warning disable CA1835 // Prefer the 'Memory'-based overloads for 'ReadAsync' and 'WriteAsync'

namespace WTelegram
{
	internal sealed class TlsStream(Stream innerStream) : Helpers.IndirectStream(innerStream)
	{
		private int _tlsFrameleft;
		private readonly byte[] _tlsSendHeader = [0x17, 0x03, 0x03, 0, 0];
		private readonly byte[] _tlsReadHeader = new byte[5];
		static readonly byte[] TlsServerHello3 = [0x14, 0x03, 0x03, 0x00, 0x01, 0x01, 0x17, 0x03, 0x03];
		static readonly byte[] TlsClientPrefix = [0x14, 0x03, 0x03, 0x00, 0x01, 0x01];

		public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken ct)
		{
			if (_tlsFrameleft == 0)
			{
				if (await _innerStream.FullReadAsync(_tlsReadHeader, 5, ct) != 5)
					return 0;
				if (_tlsReadHeader[0] != 0x17 || _tlsReadHeader[1] != 0x03 || _tlsReadHeader[2] != 0x03)
					throw new WTException("Could not read frame data : Invalid TLS header");
				_tlsFrameleft = (_tlsReadHeader[3] << 8) + _tlsReadHeader[4];
			}
			var read = await _innerStream.ReadAsync(buffer, offset, Math.Min(count, _tlsFrameleft), ct);
			_tlsFrameleft -= read;
			return read;
		}

		public override async Task WriteAsync(byte[] buffer, int start, int count, CancellationToken ct)
		{
			for (int offset = 0; offset < count;)
			{
				int len = Math.Min(count - offset, 2878);
				_tlsSendHeader[3] = (byte)(len >> 8);
				_tlsSendHeader[4] = (byte)len;
				await _innerStream.WriteAsync(_tlsSendHeader, 0, _tlsSendHeader.Length, ct);
				await _innerStream.WriteAsync(buffer, start + offset, len, ct);
				offset += len;
			}
		}

		public static async Task<TlsStream> HandshakeAsync(Stream stream, byte[] key, byte[] domain, CancellationToken ct)
		{
			var clientHello = TlsClientHello(key, domain);
			await stream.WriteAsync(clientHello, 0, clientHello.Length, ct);

			var part1 = new byte[5];
			if (await stream.FullReadAsync(part1, 5, ct) == 5)
				if (part1[0] == 0x16 && part1[1] == 0x03 && part1[2] == 0x03)
				{
					var part2size = BinaryPrimitives.ReadUInt16BigEndian(part1.AsSpan(3));
					var part23 = new byte[part2size + TlsServerHello3.Length + 2];
					if (await stream.FullReadAsync(part23, part23.Length, ct) == part23.Length)
						if (TlsServerHello3.SequenceEqual(part23.Skip(part2size).Take(TlsServerHello3.Length)))
						{
							var part4size = BinaryPrimitives.ReadUInt16BigEndian(part23.AsSpan(part23.Length - 2));
							var part4 = new byte[part4size];
							if (await stream.FullReadAsync(part4, part4size, ct) == part4size)
							{
								var serverDigest = part23[6..38];
								Array.Clear(part23, 6, 32);     // clear server digest from received parts
								var hmc = new HMACSHA256(key);  // hash the client digest + all received parts
								hmc.TransformBlock(clientHello, 11, 32, null, 0);
								hmc.TransformBlock(part1, 0, part1.Length, null, 0);
								hmc.TransformBlock(part23, 0, part23.Length, null, 0);
								hmc.TransformFinalBlock(part4, 0, part4.Length);
								if (serverDigest.SequenceEqual(hmc.Hash))
								{
									Helpers.Log(2, "TLS Handshake succeeded");
									await stream.WriteAsync(TlsClientPrefix, 0, TlsClientPrefix.Length, ct);
									return new TlsStream(stream);
								}
							}
						}
				}
			throw new WTException("TLS Handshake failed");
		}

		static readonly byte[] TlsClientHello1 = [					// https://tls13.xargs.org/#client-hello/annotated
			0x16, 0x03, 0x01, 0x02, 0x00, 0x01, 0x00, 0x01, 0xfc, 0x03, 0x03 ];
		//	digest[32]
		//	0x20
		//	random[32]
		//	0x00, 0x20
		//	grease(0)					GREASE are two identical bytes ending with nibble 'A'
		static readonly byte[] TlsClientHello2 = [
			0x13, 0x01, 0x13, 0x02, 0x13, 0x03, 0xc0, 0x2b, 0xc0, 0x2f, 0xc0, 0x2c, 0xc0, 0x30, 0xcc, 0xa9,
			0xcc, 0xa8, 0xc0, 0x13, 0xc0, 0x14, 0x00, 0x9c, 0x00, 0x9d, 0x00, 0x2f, 0x00, 0x35, 
			0x01, 0x00, 0x01, 0x93 ];
		//	grease(2)
		//	0x00, 0x00
		static readonly byte[] TlsClientHello3 = [
		//	0x00, 0x00, len { len { 0x00 len { domain } } }		len is 16-bit big-endian length of the following block of data
			0x00, 0x05, 0x00, 0x05, 0x01, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x0a, 0x00, 0x0a, 0x00, 0x08, 0x4A, 0x4A,/*=grease(4)*/ 0x00, 0x1d, 0x00, 0x17, 0x00, 0x18,
			0x00, 0x0b, 0x00, 0x02, 0x01, 0x00,
			0x00, 0x0d, 0x00, 0x12, 0x00, 0x10, 0x04, 0x03, 0x08, 0x04, 0x04, 0x01, 0x05, 0x03, 0x08, 0x05, 0x05, 0x01, 0x08, 0x06, 0x06, 0x01,
			0x00, 0x10, 0x00, 0x0e, 0x00, 0x0c, 0x02, 0x68, 0x32, 0x08, 0x68, 0x74, 0x74, 0x70, 0x2f, 0x31, 0x2e, 0x31,
			0x00, 0x12, 0x00, 0x00,
			0x00, 0x17, 0x00, 0x00,
			0x00, 0x1b, 0x00, 0x03, 0x02, 0x00, 0x02,
			0x00, 0x23, 0x00, 0x00,
			0x00, 0x2b, 0x00, 0x07, 0x06, 0x6A, 0x6A,/*=grease(6) */ 0x03, 0x04, 0x03, 0x03,
			0x00, 0x2d, 0x00, 0x02, 0x01, 0x01,
			0x00, 0x33, 0x00, 0x2b, 0x00, 0x29, 0x4A, 0x4A,/*=grease(4) */ 0x00, 0x01, 0x00, 0x00, 0x1d, 0x00, 0x20, /* random[32] */
			0x44, 0x69, 0x00, 0x05, 0x00, 0x03, 0x02, 0x68, 0x32,
			0xff, 0x01, 0x00, 0x01, 0x00,
		];
		//	grease(3)
		static readonly byte[] TlsClientHello4 = [
			0x00, 0x01, 0x00, 0x00, 0x15 ];
		//	len { padding }							padding with NUL bytes to reach 517 bytes

		static byte[] TlsClientHello(byte[] key, byte[] domain)
		{
			var greases = new byte[7];
			Encryption.RNG.GetBytes(greases);
			for (int i = 0; i < 7; i++) greases[i] = (byte)((greases[i] & 0xF0) + 0x0A);
			if (greases[3] == greases[2]) greases[3] ^= 0x10;

			var buffer = new byte[517];
			TlsClientHello1.CopyTo(buffer, 0);
			Encryption.RNG.GetBytes(buffer, 44, 32);
			buffer[43] = buffer[77] = 0x20;
			buffer[78] = buffer[79] = greases[0];
			TlsClientHello2.CopyTo(buffer, 80);
			buffer[114] = buffer[115] = greases[2];

			int dlen = domain.Length;
			var server_name = new byte[dlen + 9];
			server_name[3] = (byte)(dlen + 5);
			server_name[5] = (byte)(dlen + 3);
			server_name[8] = (byte)dlen;
			domain.CopyTo(server_name, 9);

			var key_share = new byte[47];
			Array.Copy(TlsClientHello3, 105, key_share, 0, 15);
			key_share[6] = key_share[7] = greases[4];
			Encryption.RNG.GetBytes(key_share, 15, 32); // public key
			key_share[46] &= 0x7F; // must be positive

			var random = new Random();
			var permutations = new ArraySegment<byte>[15];
			for (var i = 0; i < permutations.Length; i++)
			{
				var j = random.Next(0, i + 1);
				if (i != j) permutations[i] = permutations[j];
				permutations[j] = i switch
				{
					0 => new(server_name),
					1 => new(TlsClientHello3, 0, 9),
					2 => PatchGrease(TlsClientHello3[9..23], 6, greases[4]),
					3 => new(TlsClientHello3, 23, 6),
					4 => new(TlsClientHello3, 29, 22),
					5 => new(TlsClientHello3, 51, 18),
					6 => new(TlsClientHello3, 69, 4),
					7 => new(TlsClientHello3, 73, 4),
					8 => new(TlsClientHello3, 77, 7),
					9 => new(TlsClientHello3, 84, 4),
					10 => PatchGrease(TlsClientHello3[88..99], 5, greases[6]),
					11 => new(TlsClientHello3, 99, 6),
					12 => new(key_share),
					13 => new(TlsClientHello3, 120, 9),
					_ => new(TlsClientHello3, 129, 5),
				};
			}
			int offset = 118;
			foreach (var perm in permutations)
			{
				Array.Copy(perm.Array, perm.Offset, buffer, offset, perm.Count);
				offset += perm.Count;
			}
			buffer[offset++] = buffer[offset++] = greases[3];
			TlsClientHello4.CopyTo(buffer, offset);
			buffer[offset + 6] = (byte)(510 - offset);

			// patch-in digest with timestamp
			using var hmac = new HMACSHA256(key);
			var digest = hmac.ComputeHash(buffer);
			var stamp = BinaryPrimitives.ReadInt32LittleEndian(digest.AsSpan(28));
			stamp ^= (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
			BinaryPrimitives.WriteInt32LittleEndian(digest.AsSpan(28), stamp);
			digest.CopyTo(buffer, 11);
			return buffer;

			static ArraySegment<byte> PatchGrease(byte[] buffer, int offset, byte grease)
			{
				buffer[offset] = buffer[offset + 1] = grease;
				return new(buffer);
			}
		}
	}
}
