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
	class TlsStream : Helpers.IndirectStream
	{
		public TlsStream(Stream innerStream) : base(innerStream) { }
		private int _tlsFrameleft;
		private readonly byte[] _tlsSendHeader = new byte[] { 0x17, 0x03, 0x03, 0, 0 };
		private readonly byte[] _tlsReadHeader = new byte[5];
		static readonly byte[] TlsServerHello3 = new byte[] { 0x14, 0x03, 0x03, 0x00, 0x01, 0x01, 0x17, 0x03, 0x03 };
		static readonly byte[] TlsClientPrefix = new byte[] { 0x14, 0x03, 0x03, 0x00, 0x01, 0x01 };

		public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken ct)
		{
			if (_tlsFrameleft == 0)
			{
				if (await _innerStream.FullReadAsync(_tlsReadHeader, 5, ct) != 5)
					return 0;
				if (_tlsReadHeader[0] != 0x17 || _tlsReadHeader[1] != 0x03 || _tlsReadHeader[2] != 0x03)
					throw new ApplicationException("Could not read frame data : Invalid TLS header");
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
			throw new ApplicationException("TLS Handshake failed");
		}

		static readonly byte[] TlsClientHello1 = new byte[11] {
			0x16, 0x03, 0x01, 0x02, 0x00, 0x01, 0x00, 0x01, 0xfc, 0x03, 0x03 };
		//	digest[32]
		//	0x20
		//	random[32]
		//	0x00, 0x20, grease(0)					GREASE are two identical bytes ending with nibble 'A'
		static readonly byte[] TlsClientHello2 = new byte[34] {
			0x13, 0x01, 0x13, 0x02, 0x13, 0x03, 0xc0, 0x2b, 0xc0, 0x2f, 0xc0, 0x2c, 0xc0, 0x30, 0xcc, 0xa9,
			0xcc, 0xa8, 0xc0, 0x13, 0xc0, 0x14, 0x00, 0x9c, 0x00, 0x9d, 0x00, 0x2f, 0x00, 0x35, 0x01, 0x00, 0x01, 0x93 };
		//	grease(2),  0x00, 0x00, 0x00, 0x00
		//	len { len { 0x00 len { domain } } }		len is 16-bit big-endian length of the following block of data
		static readonly byte[] TlsClientHello3 = new byte[101] {
			0x00, 0x17, 0x00, 0x00, 0xff, 0x01, 0x00, 0x01, 0x00, 0x00, 0x0a, 0x00, 0x0a, 0x00, 0x08,
			0x4A, 0x4A, // = grease(4)
			0x00, 0x1d, 0x00, 0x17, 0x00, 0x18, 0x00, 0x0b, 0x00, 0x02, 0x01, 0x00, 0x00, 0x23, 0x00, 0x00,
			0x00, 0x10, 0x00, 0x0e, 0x00, 0x0c, 0x02, 0x68, 0x32, 0x08, 0x68, 0x74, 0x74, 0x70, 0x2f, 0x31,
			0x2e, 0x31, 0x00, 0x05, 0x00, 0x05, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0d, 0x00, 0x12, 0x00,
			0x10, 0x04, 0x03, 0x08, 0x04, 0x04, 0x01, 0x05, 0x03, 0x08, 0x05, 0x05, 0x01, 0x08, 0x06, 0x06,
			0x01, 0x00, 0x12, 0x00, 0x00, 0x00, 0x33, 0x00, 0x2b, 0x00, 0x29,
			0x4A, 0x4A, // = grease(4)
			0x00, 0x01, 0x00, 0x00, 0x1d, 0x00, 0x20 };
		//	random[32] = public key
		static readonly byte[] TlsClientHello4 = new byte[35] {
			0x00, 0x2d, 0x00, 0x02, 0x01, 0x01, 0x00, 0x2b, 0x00, 0x0b, 0x0a,
			0x6A, 0x6A, // = grease(6)
			0x03, 0x04, 0x03, 0x03, 0x03, 0x02, 0x03, 0x01, 0x00, 0x1b, 0x00, 0x03, 0x02, 0x00, 0x02,
			0x3A, 0x3A, // = grease(3)
			0x00, 0x01, 0x00, 0x00, 0x15 };
		//	len { padding }							padding with NUL bytes to reach 517 bytes

		static byte[] TlsClientHello(byte[] key, byte[] domain)
		{
			int dlen = domain.Length;
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
			buffer[121] = (byte)(dlen + 5);
			buffer[123] = (byte)(dlen + 3);
			buffer[126] = (byte)dlen;
			domain.CopyTo(buffer, 127);
			TlsClientHello3.CopyTo(buffer, 127 + dlen);
			buffer[142 + dlen] = buffer[143 + dlen] = greases[4];
			buffer[219 + dlen] = buffer[220 + dlen] = greases[4];
			Encryption.RNG.GetBytes(buffer, 228 + dlen, 32); // public key
			buffer[228 + dlen + 31] &= 0x7F; // must be positive
			TlsClientHello4.CopyTo(buffer, 260 + dlen);
			buffer[271 + dlen] = buffer[272 + dlen] = greases[6];
			buffer[288 + dlen] = buffer[289 + dlen] = greases[3];
			buffer[296 + dlen] = (byte)(220 - dlen);

			// patch-in digest with timestamp
			using var hmac = new HMACSHA256(key);
			var digest = hmac.ComputeHash(buffer);
			var stamp = BinaryPrimitives.ReadInt32LittleEndian(digest.AsSpan(28));
			stamp ^= (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
			BinaryPrimitives.WriteInt32LittleEndian(digest.AsSpan(28), stamp);
			digest.CopyTo(buffer, 11);
			return buffer;
		}
	}
}
