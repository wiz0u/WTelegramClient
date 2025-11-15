using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TL;
using static WTelegram.Compat;

namespace WTelegram
{
	public static class Encryption
	{
		private static readonly Dictionary<long, RSAPublicKey> PublicKeys = [];
		internal static readonly RandomNumberGenerator RNG = RandomNumberGenerator.Create();
		internal static readonly Aes AesECB = Aes.Create();

		static Encryption()
		{
			AesECB.Mode = CipherMode.ECB;
			AesECB.Padding = PaddingMode.Zeros;
			if (AesECB.BlockSize != 128) throw new WTException("AES Blocksize is not 16 bytes");
		}

		internal static async Task CreateAuthorizationKey(Client client, Session.DCSession session)
		{
			if (PublicKeys.Count == 0) LoadDefaultPublicKeys();
			var sha1 = SHA1.Create();
			var sha256 = SHA256.Create();

			//1)
			var nonce = new TL.Int128(RNG);
			var resPQ = await client.ReqPqMulti(nonce);
			//2)
			if (resPQ.nonce != nonce) throw new WTException("Nonce mismatch");
			var fingerprint = resPQ.server_public_key_fingerprints.FirstOrDefault(PublicKeys.ContainsKey);
			if (fingerprint == 0) throw new WTException("Couldn't match any server_public_key_fingerprints");
			var publicKey = PublicKeys[fingerprint];
			Helpers.Log(2, $"Selected public key with fingerprint {fingerprint:X}");
			//3)
			long retry_id = 0;
			ulong pq = Helpers.FromBigEndian(resPQ.pq);
			ulong p = Helpers.PQFactorize(pq);
			ulong q = pq / p;
			//4)
			var pqInnerData = new PQInnerDataDc
			{
				pq = resPQ.pq,
				p = Helpers.ToBigEndian(p),
				q = Helpers.ToBigEndian(q),
				nonce = nonce,
				server_nonce = resPQ.server_nonce,
				new_nonce = new Int256(RNG),
				dc = session.DataCenter?.id ?? 0
			};
			if (client.TLConfig?.test_mode == true) pqInnerData.dc += 10000;
			if (session.DataCenter?.flags.HasFlag(DcOption.Flags.media_only) == true) pqInnerData.dc = -pqInnerData.dc;
			byte[] encrypted_data = null;
			{
				//4.1) RSA_PAD(data, server_public_key)
				using var clearStream = new MemoryStream(256);
				using var writer = new BinaryWriter(clearStream);
				byte[] aes_key = new byte[32], zero_iv = new byte[32];
				var n = BigEndianInteger(publicKey.n);
				do
				{
					RNG.GetBytes(aes_key);
					clearStream.Position = 0;
					clearStream.Write(aes_key, 0, 32); // write aes_key as prefix for initial Sha256 computation
					writer.WriteTLObject(pqInnerData);
					int clearLength = (int)clearStream.Position - 32;  // length before padding
					if (clearLength > 144) throw new WTException("PQInnerData too big");
					byte[] clearBuffer = clearStream.GetBuffer();
					RNG.GetBytes(clearBuffer, 32 + clearLength, 192 - clearLength);
					sha256.ComputeHash(clearBuffer, 0, 32 + 192).CopyTo(clearBuffer, 224); // append Sha256
					Array.Reverse(clearBuffer, 32, 192);
					var aes_encrypted = AES_IGE_EncryptDecrypt(clearBuffer.AsSpan(32, 224), aes_key, zero_iv, true);
					var hash_aes = sha256.ComputeHash(aes_encrypted);
					for (int i = 0; i < 32; i++) // prefix aes_encrypted with temp_key_xor
						clearBuffer[i] = (byte)(aes_key[i] ^ hash_aes[i]);
					aes_encrypted.CopyTo(clearBuffer, 32);
					var x = BigEndianInteger(clearBuffer);
					if (x < n) // if good result, encrypt with RSA key:
						encrypted_data = BigInteger.ModPow(x, BigEndianInteger(publicKey.e), n).To256Bytes();
				} while (encrypted_data == null); // otherwise, repeat the steps
			}
			var serverDHparams = await client.ReqDHParams(pqInnerData.nonce, pqInnerData.server_nonce, pqInnerData.p, pqInnerData.q, fingerprint, encrypted_data);
			//5)
			var localTime = DateTimeOffset.UtcNow;
			if (serverDHparams is not ServerDHParamsOk serverDHparamsOk) throw new WTException("not server_DH_params_ok");
			if (serverDHparamsOk.nonce != nonce) throw new WTException("Nonce mismatch");
			if (serverDHparamsOk.server_nonce != resPQ.server_nonce) throw new WTException("Server Nonce mismatch");
			var (tmp_aes_key, tmp_aes_iv) = ConstructTmpAESKeyIV(sha1, resPQ.server_nonce, pqInnerData.new_nonce);
			var answer = AES_IGE_EncryptDecrypt(serverDHparamsOk.encrypted_answer, tmp_aes_key, tmp_aes_iv, false);

			using var answerReader = new BinaryReader(new MemoryStream(answer));
			var answerHash = answerReader.ReadBytes(20);
			var answerObj = answerReader.ReadTLObject();
			if (answerObj is not ServerDHInnerData serverDHinnerData) throw new WTException("not server_DH_inner_data");
			long padding = answerReader.BaseStream.Length - answerReader.BaseStream.Position;
			if (padding >= 16) throw new WTException("Too much pad");
			if (!Enumerable.SequenceEqual(sha1.ComputeHash(answer, 20, answer.Length - (int)padding - 20), answerHash))
				throw new WTException("Answer SHA1 mismatch");
			if (serverDHinnerData.nonce != nonce) throw new WTException("Nonce mismatch");
			if (serverDHinnerData.server_nonce != resPQ.server_nonce) throw new WTException("Server Nonce mismatch");
			var g_a = BigEndianInteger(serverDHinnerData.g_a);
			var dh_prime = BigEndianInteger(serverDHinnerData.dh_prime);
			CheckGoodPrime(dh_prime, serverDHinnerData.g);
			session.lastSentMsgId = 0;
			session.serverTicksOffset = (serverDHinnerData.server_time - localTime).Ticks;
			Helpers.Log(1, $"Time offset: {session.serverTicksOffset} | Server: {serverDHinnerData.server_time.TimeOfDay} UTC | Local: {localTime.TimeOfDay} UTC");
			//6)
			var salt = new byte[256];
			RNG.GetBytes(salt);
			var b = BigEndianInteger(salt);
			var g_b = BigInteger.ModPow(serverDHinnerData.g, b, dh_prime);
			CheckGoodGaAndGb(g_a, dh_prime);
			CheckGoodGaAndGb(g_b, dh_prime);
			var clientDHinnerData = new ClientDHInnerData
			{
				nonce = nonce,
				server_nonce = resPQ.server_nonce,
				retry_id = retry_id,
				g_b = g_b.ToByteArray(true, true)
			};
			{
				using var clearStream = new MemoryStream(384);
				clearStream.Position = 20; // skip SHA1 area (to be patched)
				using var writer = new BinaryWriter(clearStream);
				writer.WriteTLObject(clientDHinnerData);
				int clearLength = (int)clearStream.Length;  // length before padding (= 20 + message_data_length)
				int paddingToAdd = (0x7FFFFFF0 - clearLength) % 16;
				clearStream.SetLength(clearLength + paddingToAdd);
				byte[] clearBuffer = clearStream.GetBuffer();
				RNG.GetBytes(clearBuffer, clearLength, paddingToAdd);
				sha1.ComputeHash(clearBuffer, 20, clearLength - 20).CopyTo(clearBuffer, 0);

				encrypted_data = AES_IGE_EncryptDecrypt(clearBuffer.AsSpan(0, clearLength + paddingToAdd), tmp_aes_key, tmp_aes_iv, true);
			}
			var setClientDHparamsAnswer = await client.SetClientDHParams(clientDHinnerData.nonce, clientDHinnerData.server_nonce, encrypted_data);
			//7)
			var gab = BigInteger.ModPow(g_a, b, dh_prime);
			var authKey = gab.ToByteArray(true, true);
			//8)
			var authKeyHash = sha1.ComputeHash(authKey);
			retry_id = BinaryPrimitives.ReadInt64LittleEndian(authKeyHash); // (auth_key_aux_hash)
			//9)
			if (setClientDHparamsAnswer is not DhGenOk dhGenOk) throw new WTException("not dh_gen_ok");
			if (dhGenOk.nonce != nonce) throw new WTException("Nonce mismatch");
			if (dhGenOk.server_nonce != resPQ.server_nonce) throw new WTException("Server Nonce mismatch");
			var expected_new_nonceN = new byte[32 + 1 + 8];
			pqInnerData.new_nonce.raw.CopyTo(expected_new_nonceN, 0);
			expected_new_nonceN[32] = 1;
			Array.Copy(authKeyHash, 0, expected_new_nonceN, 33, 8); // (auth_key_aux_hash)
			if (!Enumerable.SequenceEqual(dhGenOk.new_nonce_hash1.raw, sha1.ComputeHash(expected_new_nonceN).Skip(4)))
				throw new WTException("setClientDHparamsAnswer.new_nonce_hashN mismatch");

			session.authKeyID = BinaryPrimitives.ReadInt64LittleEndian(authKeyHash.AsSpan(12));
			session.AuthKey = authKey;
			session.Salt = BinaryPrimitives.ReadInt64LittleEndian(pqInnerData.new_nonce.raw) ^ BinaryPrimitives.ReadInt64LittleEndian(resPQ.server_nonce.raw);
			session.OldSalt = session.Salt;
		}

		public static (byte[] key, byte[] iv) ConstructTmpAESKeyIV(SHA1 sha1, TL.Int128 server_nonce, Int256 new_nonce)
		{
			byte[] tmp_aes_key = new byte[32], tmp_aes_iv = new byte[32];
			sha1.TransformBlock(new_nonce, 0, 32, null, 0);
			sha1.TransformFinalBlock(server_nonce, 0, 16);
			sha1.Hash.CopyTo(tmp_aes_key, 0);                   // tmp_aes_key := SHA1(new_nonce + server_nonce)
			sha1.Initialize();
			sha1.TransformBlock(server_nonce, 0, 16, null, 0);
			sha1.TransformFinalBlock(new_nonce, 0, 32);
			Array.Copy(sha1.Hash, 0, tmp_aes_key, 20, 12);      //              + SHA1(server_nonce, new_nonce)[0:12]
			Array.Copy(sha1.Hash, 12, tmp_aes_iv, 0, 8);        // tmp_aes_iv  != SHA1(server_nonce, new_nonce)[12:8]
			sha1.Initialize();
			sha1.TransformBlock(new_nonce, 0, 32, null, 0);
			sha1.TransformFinalBlock(new_nonce, 0, 32);
			sha1.Hash.CopyTo(tmp_aes_iv, 8);                    //              + SHA(new_nonce + new_nonce)
			Array.Copy(new_nonce, 0, tmp_aes_iv, 28, 4);        //              + new_nonce[0:4]
			sha1.Initialize();
			return (tmp_aes_key, tmp_aes_iv);
		}

		internal static void CheckGoodPrime(BigInteger p, int g)
		{
			Helpers.Log(2, "Verifying encryption key safety... (this should happen only once per DC)");
			// check that 2^2047 <= p < 2^2048
			if (p.GetBitLength() != 2048) throw new WTException("p is not 2048-bit number");
			// check that g generates a cyclic subgroup of prime order (p - 1) / 2, i.e. is a quadratic residue mod p.
			if (g switch
			{
				2 => p % 8 != 7,
				3 => p % 3 != 2,
				4 => false,
				5 => (int)(p % 5) is not 1 and not 4,
				6 => (int)(p % 24) is not 19 and not 23,
				7 => (int)(p % 7) is not 3 and not 5 and not 6,
				_ => true,
			})
				throw new WTException("Bad prime mod 4g");
			// check whether p is a safe prime (meaning that both p and (p - 1) / 2 are prime)
			if (SafePrimes.Contains(p)) return;
			if (!p.IsProbablePrime()) throw new WTException("p is not a prime number");
			if (!((p - 1) / 2).IsProbablePrime()) throw new WTException("(p - 1) / 2 is not a prime number");
			SafePrimes.Add(p);
		}

		private static readonly HashSet<BigInteger> SafePrimes = [ new( // C71CAEB9C6B1C904...
		[
			0x5B, 0xCC, 0x2F, 0xB9, 0xE3, 0xD8, 0x9C, 0x11, 0x03, 0x04, 0xB1, 0x34, 0xF0, 0xAD, 0x4F, 0x6F,
			0xBF, 0x54, 0x24, 0x4B, 0xD0, 0x15, 0x4E, 0x2E, 0xEE, 0x05, 0xB1, 0x35, 0xF6, 0x15, 0x81, 0x0D,
			0x1F, 0x85, 0x29, 0xE9, 0x0C, 0x85, 0x56, 0xD9, 0x59, 0xF9, 0x7B, 0xF4, 0x49, 0x28, 0xED, 0x0D,
			0x05, 0x70, 0xED, 0x5E, 0xFF, 0xA9, 0x7F, 0xF8, 0xA0, 0xBE, 0x3E, 0xE8, 0x15, 0xFC, 0x18, 0xE4,
			0xE4, 0x9A, 0x5B, 0xEF, 0x8F, 0x92, 0xA3, 0x9C, 0xFF, 0xD6, 0xB0, 0x65, 0xC4, 0x6B, 0x9C, 0x16,
			0x8D, 0x17, 0xB1, 0x2D, 0x58, 0x46, 0xDD, 0xB9, 0xB4, 0x65, 0x59, 0x0D, 0x95, 0xED, 0x17, 0xFD,
			0x54, 0x47, 0x28, 0xF1, 0x0E, 0x4E, 0x14, 0xB3, 0x14, 0x2A, 0x4B, 0xA8, 0xD8, 0x74, 0xBA, 0x0D,
			0x41, 0x6B, 0x0F, 0x6B, 0xB5, 0x53, 0x27, 0x16, 0x7E, 0x90, 0x51, 0x10, 0x81, 0x95, 0xA6, 0xA4,
			0xA4, 0xF9, 0x7C, 0xE6, 0xBE, 0x60, 0x90, 0x3A, 0x4F, 0x3C, 0x8E, 0x37, 0x9B, 0xFA, 0x08, 0x07,
			0x88, 0x49, 0xCC, 0xC8, 0x4A, 0x1D, 0xCD, 0x5B, 0x1D, 0x94, 0x2A, 0xBB, 0x96, 0xFE, 0x77, 0x24,
			0x64, 0x5F, 0x59, 0x8C, 0xAF, 0x8F, 0xF1, 0x54, 0x84, 0x32, 0x69, 0x29, 0x51, 0x46, 0x97, 0xDC,
			0xAB, 0x13, 0x6B, 0x6B, 0xFE, 0xD4, 0x8C, 0xC6, 0x5A, 0x70, 0x58, 0x94, 0xF6, 0x51, 0xFD, 0x20,
			0x37, 0x7C, 0xCE, 0x4C, 0xD4, 0xAE, 0x43, 0x95, 0x13, 0x25, 0xC9, 0x0A, 0x6E, 0x6F, 0x33, 0xFA,
			0xDB, 0xF4, 0x30, 0x25, 0xD2, 0x93, 0x94, 0x22, 0x58, 0x40, 0xC1, 0xA7, 0x0A, 0x8A, 0x19, 0x48,
			0x0F, 0x93, 0x3D, 0x56, 0x37, 0xD0, 0x34, 0x49, 0xC1, 0x21, 0x3E, 0x8E, 0x23, 0x40, 0x0D, 0x98,
			0x73, 0x3F, 0xF1, 0x70, 0x2F, 0x52, 0x6C, 0x8E, 0x04, 0xC9, 0xB1, 0xC6, 0xB9, 0xAE, 0x1C, 0xC7, 0x00
		])];

		internal static void CheckGoodGaAndGb(BigInteger g, BigInteger dh_prime)
		{
			// check that g, g_a and g_b are greater than 1 and less than dh_prime - 1.
			// We recommend checking that g_a and g_b are between 2^{2048-64} and dh_prime - 2^{2048-64} as well.
			if (g.GetBitLength() < 2048 - 64 || (dh_prime - g).GetBitLength() < 2048 - 64)
				throw new WTException("g^a or g^b is not between 2^{2048-64} and dh_prime - 2^{2048-64}");
		}

		/// <summary>Load a specific Telegram server public key</summary>
		/// <param name="pem">A string starting with <c>-----BEGIN RSA PUBLIC KEY-----</c></param>
		public static void LoadPublicKey(string pem)
		{
			using var rsa = RSA.Create();
			using var sha1 = SHA1.Create();
			rsa.ImportFromPem(pem);
			var rsaParam = rsa.ExportParameters(false);
			if (rsaParam.Modulus[0] == 0) rsaParam.Modulus = rsaParam.Modulus[1..];
			var publicKey = new RSAPublicKey { n = rsaParam.Modulus, e = rsaParam.Exponent };
			var bareData = publicKey.ToBytes();
			var fingerprint = BinaryPrimitives.ReadInt64LittleEndian(sha1.ComputeHash(bareData, 4, bareData.Length - 4).AsSpan(12)); // 64 lower-order bits of SHA1
			PublicKeys[fingerprint] = publicKey;
			Helpers.Log(1, $"Loaded a public key with fingerprint {fingerprint:X}");
		}

		private static void LoadDefaultPublicKeys()
		{
			// Production Public Key (D09D1D85DE64FD85)
			LoadPublicKey(@"-----BEGIN RSA PUBLIC KEY-----
MIIBCgKCAQEA6LszBcC1LGzyr992NzE0ieY+BSaOW622Aa9Bd4ZHLl+TuFQ4lo4g
5nKaMBwK/BIb9xUfg0Q29/2mgIR6Zr9krM7HjuIcCzFvDtr+L0GQjae9H0pRB2OO
62cECs5HKhT5DZ98K33vmWiLowc621dQuwKWSQKjWf50XYFw42h21P2KXUGyp2y/
+aEyZ+uVgLLQbRA1dEjSDZ2iGRy12Mk5gpYc397aYp438fsJoHIgJ2lgMv5h7WY9
t6N/byY9Nw9p21Og3AoXSL2q/2IJ1WRUhebgAdGVMlV1fkuOQoEzR7EdpqtQD9Cs
5+bfo3Nhmcyvk5ftB0WkJ9z6bNZ7yxrP8wIDAQAB
-----END RSA PUBLIC KEY-----");
			// Test Public Key (B25898DF208D2603)
			LoadPublicKey(@"-----BEGIN RSA PUBLIC KEY-----
MIIBCgKCAQEAyMEdY1aR+sCR3ZSJrtztKTKqigvO/vBfqACJLZtS7QMgCGXJ6XIR
yy7mx66W0/sOFa7/1mAZtEoIokDP3ShoqF4fVNb6XeqgQfaUHd8wJpDWHcR2OFwv
plUUI1PLTktZ9uW2WE23b+ixNwJjJGwBDJPQEQFBE+vfmH0JP503wr5INS1poWg/
j25sIWeYPHYeOrFp/eXaqhISP6G+q2IeTaWTXpwZj4LzXq5YOpk4bYEQ6mvRq7D1
aHWfYmlEGepfaYR8Q0YqvvhYtMte3ITnuSJs171+GDqpdKcSwHnd6FudwGO4pcCO
j4WcDuXc2CTHgH8gFTNhp/Y8/SpDOhvn9QIDAQAB
-----END RSA PUBLIC KEY-----");
		}

		public static byte[] EncryptDecryptMessage(Span<byte> input, bool encrypt, int x, byte[] authKey, byte[] msgKey, int msgKeyOffset, SHA256 sha256)
		{
			// first, construct AES key & IV
			byte[] aes_key = new byte[32], aes_iv = new byte[32];
			sha256.TransformBlock(msgKey, msgKeyOffset, 16, null, 0);   // msgKey
			sha256.TransformFinalBlock(authKey, x, 36);                 // authKey[x:36]
			var sha256_a = sha256.Hash;
			sha256.Initialize();
			sha256.TransformBlock(authKey, 40 + x, 36, null, 0);        // authKey[40+x:36]
			sha256.TransformFinalBlock(msgKey, msgKeyOffset, 16);       // msgKey
			var sha256_b = sha256.Hash;
			sha256.Initialize();
			Array.Copy(sha256_a, 0, aes_key, 0, 8);
			Array.Copy(sha256_b, 8, aes_key, 8, 16);
			Array.Copy(sha256_a, 24, aes_key, 24, 8);
			Array.Copy(sha256_b, 0, aes_iv, 0, 8);
			Array.Copy(sha256_a, 8, aes_iv, 8, 16);
			Array.Copy(sha256_b, 24, aes_iv, 24, 8);
			return AES_IGE_EncryptDecrypt(input, aes_key, aes_iv, encrypt);
		}

		public static byte[] AES_IGE_EncryptDecrypt(Span<byte> input, byte[] aes_key, byte[] aes_iv, bool encrypt)
		{
			if (input.Length % 16 != 0) throw new WTException("AES_IGE input size not divisible by 16");

			using var aesCrypto = encrypt ? AesECB.CreateEncryptor(aes_key, null) : AesECB.CreateDecryptor(aes_key, null);
			var output = new byte[input.Length];
			var prevBytes = (byte[])aes_iv.Clone();
			var span = MemoryMarshal.Cast<byte, long>(input);
			var sout = MemoryMarshal.Cast<byte, long>(output.AsSpan());
			var prev = MemoryMarshal.Cast<byte, long>(prevBytes.AsSpan());
			if (!encrypt) { (prev[2], prev[0]) = (prev[0], prev[2]); (prev[3], prev[1]) = (prev[1], prev[3]); }
			for (int i = 0, count = input.Length / 8; i < count;)
			{
				sout[i] = span[i] ^ prev[0]; sout[i + 1] = span[i + 1] ^ prev[1];
				aesCrypto.TransformBlock(output, i * 8, 16, output, i * 8);
				prev[0] = sout[i] ^= prev[2]; prev[1] = sout[i + 1] ^= prev[3];
				prev[2] = span[i++]; prev[3] = span[i++];
			}
			return output;
		}

#if OBFUSCATION
		public sealed class AesCtr(byte[] key, byte[] ivec) : IDisposable
		{
			readonly ICryptoTransform _encryptor = AesECB.CreateEncryptor(key, null);
			readonly byte[] _ecount = new byte[16];
			int _num;

			public void Dispose() => _encryptor.Dispose();

			public void EncryptDecrypt(Span<byte> buffer)
			{
				for (int i = 0; i < buffer.Length; i++)
				{
					if (_num == 0)
					{
						_encryptor.TransformBlock(ivec, 0, 16, _ecount, 0);
						for (int n = 15; n >= 0; n--) // increment big-endian counter
							if (++ivec[n] != 0) break;
					}
					buffer[i] ^= _ecount[_num];
					_num = (_num + 1) % 16;
				}
			}
		}

		// see https://core.telegram.org/mtproto/mtproto-transports#transport-obfuscation
		internal static (AesCtr, AesCtr, byte[]) InitObfuscation(byte[] secret, byte protocolId, int dcId)
		{
			byte[] preamble = new byte[64];
			do
				RNG.GetBytes(preamble, 0, 58);
			while (preamble[0] == 0xef ||
				BinaryPrimitives.ReadUInt32LittleEndian(preamble) is 0x44414548 or 0x54534f50 or 0x20544547 or 0x4954504f or 0x02010316 or 0xdddddddd or 0xeeeeeeee ||
				BinaryPrimitives.ReadInt32LittleEndian(preamble.AsSpan(4)) == 0);
			preamble[62] = preamble[56];  preamble[63] = preamble[57];
			preamble[56] = preamble[57] = preamble[58] = preamble[59] = protocolId;
			preamble[60] = (byte)dcId; preamble[61] = (byte)(dcId >> 8);

			byte[] recvKey = preamble[8..40], recvIV = preamble[40..56];
			Array.Reverse(preamble, 8, 48);
			byte[] sendKey = preamble[8..40], sendIV = preamble[40..56];
			if (secret != null)
			{
				using var sha256 = SHA256.Create();
				sha256.TransformBlock(sendKey, 0, 32, null, 0);
				sha256.TransformFinalBlock(secret, 0, 16);
				sendKey = sha256.Hash;
				sha256.Initialize();
				sha256.TransformBlock(recvKey, 0, 32, null, 0);
				sha256.TransformFinalBlock(secret, 0, 16);
				recvKey = sha256.Hash;
			}
			var sendCtr = new AesCtr(sendKey, sendIV);
			var recvCtr = new AesCtr(recvKey, recvIV);
			var encrypted = (byte[])preamble.Clone();
			sendCtr.EncryptDecrypt(encrypted);
			for (int i = 56; i < 64; i++)
				preamble[i] = encrypted[i];
			return (sendCtr, recvCtr, preamble);
		}
#endif

		internal static async Task<InputCheckPasswordSRP> Check2FA(Account_Password accountPassword, Func<Task<string>> getPassword)
		{
			if (accountPassword.current_algo is not PasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow algo)
				if (accountPassword.current_algo == null && (algo = accountPassword.new_algo as PasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow) != null)
				{
					int salt1len = algo.salt1.Length;
					Array.Resize(ref algo.salt1, salt1len + 32);
					RNG.GetBytes(algo.salt1, salt1len, 32);
				}
				else
					throw new WTException("2FA authentication uses an unsupported algo: " + accountPassword.current_algo?.GetType().Name);

			var g = new BigInteger(algo.g);
			var p = BigEndianInteger(algo.p);
			var validTask = Task.Run(() => CheckGoodPrime(p, algo.g));

			System.Threading.Thread.Sleep(100);
			Helpers.Log(3, $"This account has enabled 2FA. A password is needed. {accountPassword.hint}");
			var passwordBytes = Encoding.UTF8.GetBytes(await getPassword());

			using var sha256 = SHA256.Create();
			sha256.TransformBlock(algo.salt1, 0, algo.salt1.Length, null, 0);
			sha256.TransformBlock(passwordBytes, 0, passwordBytes.Length, null, 0);
			sha256.TransformFinalBlock(algo.salt1, 0, algo.salt1.Length);
			var hash = sha256.Hash;
			sha256.Initialize();
			sha256.TransformBlock(algo.salt2, 0, algo.salt2.Length, null, 0);
			sha256.TransformBlock(hash, 0, 32, null, 0);
			sha256.TransformFinalBlock(algo.salt2, 0, algo.salt2.Length);
			hash = sha256.Hash;
#if NETCOREAPP2_0_OR_GREATER
			using var derive = new Rfc2898DeriveBytes(hash, algo.salt1, 100000, HashAlgorithmName.SHA512);
			var pbkdf2 = derive.GetBytes(64);
#else
			var pbkdf2 = PBKDF2_SHA512(hash, algo.salt1, 100000, 64);
#endif
			sha256.Initialize();
			sha256.TransformBlock(algo.salt2, 0, algo.salt2.Length, null, 0);
			sha256.TransformBlock(pbkdf2, 0, 64, null, 0);
			sha256.TransformFinalBlock(algo.salt2, 0, algo.salt2.Length);
			var x = BigEndianInteger(sha256.Hash);

			var v = BigInteger.ModPow(g, x, p);
			if (accountPassword.current_algo == null) // we're computing a new password
			{
				await validTask;
				return new InputCheckPasswordSRP { A = v.To256Bytes() };
			}

			var g_b = BigEndianInteger(accountPassword.srp_B);
			var g_b_256 = g_b.To256Bytes();
			var g_256 = g.To256Bytes();

			sha256.Initialize();
			sha256.TransformBlock(algo.p, 0, 256, null, 0);
			sha256.TransformFinalBlock(g_256, 0, 256);
			var k = BigEndianInteger(sha256.Hash);

			var k_v = (k * v) % p;
			var a = BigEndianInteger(new Int256(RNG).raw);
			var g_a = BigInteger.ModPow(g, a, p);
			var g_a_256 = g_a.To256Bytes();

			sha256.Initialize();
			sha256.TransformBlock(g_a_256, 0, 256, null, 0);
			sha256.TransformFinalBlock(g_b_256, 0, 256);
			var u = BigEndianInteger(sha256.Hash);

			var t = (g_b - k_v) % p; //(positive modulo, if the result is negative increment by p)
			if (t.Sign < 0) t += p;
			var s_a = BigInteger.ModPow(t, a + u * x, p);
			sha256.Initialize();
			var k_a = sha256.ComputeHash(s_a.To256Bytes());

			hash = sha256.ComputeHash(algo.p);
			var h2 = sha256.ComputeHash(g_256);
			for (int i = 0; i < 32; i++) hash[i] ^= h2[i];
			var hs1 = sha256.ComputeHash(algo.salt1);
			var hs2 = sha256.ComputeHash(algo.salt2);
			sha256.Initialize();
			sha256.TransformBlock(hash, 0, 32, null, 0);
			sha256.TransformBlock(hs1, 0, 32, null, 0);
			sha256.TransformBlock(hs2, 0, 32, null, 0);
			sha256.TransformBlock(g_a_256, 0, 256, null, 0);
			sha256.TransformBlock(g_b_256, 0, 256, null, 0);
			sha256.TransformFinalBlock(k_a, 0, 32);
			var m1 = sha256.Hash;

			await validTask;
			return new InputCheckPasswordSRP { A = g_a_256, M1 = m1, srp_id = accountPassword.srp_id };
		}

#if !NETCOREAPP2_0_OR_GREATER
		// adapted from https://github.com/dotnet/aspnetcore/blob/main/src/DataProtection/Cryptography.KeyDerivation/src/PBKDF2/ManagedPbkdf2Provider.cs
		private static byte[] PBKDF2_SHA512(byte[] password, byte[] salt, int iterationCount, int numBytesRequested)
		{
			// PBKDF2 is defined in NIST SP800-132, Sec. 5.3: http://csrc.nist.gov/publications/nistpubs/800-132/nist-sp800-132.pdf
			byte[] retVal = new byte[numBytesRequested];
			int numBytesWritten = 0;
			int numBytesRemaining = numBytesRequested;

			// For each block index, U_0 := Salt || block_index
			byte[] saltWithBlockIndex = new byte[checked(salt.Length + sizeof(uint))];
			Buffer.BlockCopy(salt, 0, saltWithBlockIndex, 0, salt.Length);

			using var hashAlgorithm = new HMACSHA512(password);
			for (uint blockIndex = 1; numBytesRemaining > 0; blockIndex++)
			{
				// write the block index out as big-endian
				saltWithBlockIndex[^4] = (byte)(blockIndex >> 24);
				saltWithBlockIndex[^3] = (byte)(blockIndex >> 16);
				saltWithBlockIndex[^2] = (byte)(blockIndex >> 8);
				saltWithBlockIndex[^1] = (byte)blockIndex;

				// U_1 = PRF(U_0) = PRF(Salt || block_index)
				// T_blockIndex = U_1
				byte[] U_iter = hashAlgorithm.ComputeHash(saltWithBlockIndex); // this is U_1
				byte[] T_blockIndex = U_iter;

				for (int iter = 1; iter < iterationCount; iter++)
				{
					U_iter = hashAlgorithm.ComputeHash(U_iter);
					for (int j = U_iter.Length - 1; j >= 0; j--)
						T_blockIndex[j] ^= U_iter[j];
					// At this point, the 'U_iter' variable actually contains U_{iter+1} (due to indexing differences).
				}

				// At this point, we're done iterating on this block, so copy the transformed block into retVal.
				int numBytesToCopy = Math.Min(numBytesRemaining, T_blockIndex.Length);
				Buffer.BlockCopy(T_blockIndex, 0, retVal, numBytesWritten, numBytesToCopy);
				numBytesWritten += numBytesToCopy;
				numBytesRemaining -= numBytesToCopy;
			}
			return retVal; // retVal := T_1 || T_2 || ... || T_n, where T_n may be truncated to meet the desired output length
		}
#endif
	}

	internal sealed class AES_IGE_Stream : Helpers.IndirectStream
	{
		private readonly ICryptoTransform _aesCrypto;
		private readonly byte[] _prevBytes;

		public AES_IGE_Stream(Stream stream, long size, byte[] key, byte[] iv) : this(stream, key, iv, false) { ContentLength = size; }
		public AES_IGE_Stream(Stream stream, byte[] key, byte[] iv, bool encrypt) : base(stream)
		{
			_aesCrypto = encrypt ? Encryption.AesECB.CreateEncryptor(key, null) : Encryption.AesECB.CreateDecryptor(key, null);
			if (encrypt) _prevBytes = (byte[])iv.Clone();
			else { _prevBytes = new byte[32]; Array.Copy(iv, 0, _prevBytes, 16, 16); Array.Copy(iv, 16, _prevBytes, 0, 16); }
		}

		public override long Length => base.Length + 15 & ~15;
		public override bool CanSeek => false;
		public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

		public override int Read(byte[] buffer, int offset, int count)
		{
			count = _innerStream.Read(buffer, offset, count);
			if (count == 0) return 0;
			Process(buffer, offset, count);
			if (ContentLength.HasValue && _innerStream.Position == _innerStream.Length)
				return count - (int)(_innerStream.Position - ContentLength.Value);
			return count + 15 & ~15;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			Process(buffer, offset, count);
			if (ContentLength.HasValue && _innerStream.Position + count > ContentLength)
				count -= (int)(_innerStream.Position + count - ContentLength.Value);
			_innerStream.Write(buffer, offset, count);
		}

		public void Process(byte[] buffer, int offset, int count)
		{
			count = count + 15 & ~15;
			var span = MemoryMarshal.Cast<byte, long>(buffer.AsSpan(offset, count));
			var prev = MemoryMarshal.Cast<byte, long>(_prevBytes.AsSpan());
			for (offset = 0, count /= 8; offset < count;)
			{
				prev[0] ^= span[offset]; prev[1] ^= span[offset + 1];
				_aesCrypto.TransformBlock(_prevBytes, 0, 16, _prevBytes, 0);
				prev[0] ^= prev[2]; prev[1] ^= prev[3];
				prev[2] = span[offset]; prev[3] = span[offset + 1];
				span[offset++] = prev[0]; span[offset++] = prev[1];
			}
		}
	}
}
