using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TL;
using static WTelegram.Compat;

namespace WTelegram
{
	internal static class Encryption
	{
		internal static readonly RNGCryptoServiceProvider RNG = new();
		internal static readonly SHA1 Sha1 = SHA1.Create();
		internal static readonly SHA256 Sha256 = SHA256.Create();
#if MTPROTO1
		internal static readonly SHA1 Sha1Recv = SHA1.Create();
#else
		internal static readonly SHA256 Sha256Recv = SHA256.Create();
#endif
		private static readonly Dictionary<long, RSAPublicKey> PublicKeys = new();

		internal static async Task CreateAuthorizationKey(Client client, Session.DCSession session)
		{
			if (PublicKeys.Count == 0) LoadDefaultPublicKeys();

			//1)
			var nonce = new Int128(RNG);
#if MTPROTO1
			var resPQ = await client.ReqPQ(nonce);
#else
			var resPQ = await client.ReqPqMulti(nonce); 
#endif
			//2)
			if (resPQ.nonce != nonce) throw new ApplicationException("Nonce mismatch");
			var fingerprint = resPQ.server_public_key_fingerprints.FirstOrDefault(PublicKeys.ContainsKey);
			if (fingerprint == 0) throw new ApplicationException("Couldn't match any server_public_key_fingerprints");
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
			byte[] encrypted_data = null;
			{
#if OLDKEY
				using var clearStream = new MemoryStream(255);
				clearStream.Position = 20; // skip SHA1 area (to be patched)
				using var writer = new BinaryWriter(clearStream, Encoding.UTF8);
				writer.WriteTLObject(pqInnerData);
				int clearLength = (int)clearStream.Length;  // length before padding (= 20 + message_data_length)
				if (clearLength > 255) throw new ApplicationException("PQInnerData too big");
				byte[] clearBuffer = clearStream.GetBuffer();
				RNG.GetBytes(clearBuffer, clearLength, 255 - clearLength);
				Sha1.ComputeHash(clearBuffer, 20, clearLength - 20).CopyTo(clearBuffer, 0); // patch with SHA1
				encrypted_data = BigInteger.ModPow(BigEndianInteger(clearBuffer), // encrypt with RSA key
					BigEndianInteger(publicKey.e), BigEndianInteger(publicKey.n)).ToByteArray(true, true);
#else
				//4.1) RSA_PAD(data, server_public_key)
				using var clearStream = new MemoryStream(256);
				using var writer = new BinaryWriter(clearStream, Encoding.UTF8);
				byte[] aes_key = new byte[32], zero_iv = new byte[32];
				var n = BigEndianInteger(publicKey.n);
				while (encrypted_data == null)
				{
					RNG.GetBytes(aes_key);
					clearStream.Position = 0;
					clearStream.Write(aes_key, 0, 32); // write aes_key as prefix for initial Sha256 computation
					writer.WriteTLObject(pqInnerData);
					int clearLength = (int)clearStream.Position - 32;  // length before padding
					if (clearLength > 144) throw new ApplicationException("PQInnerData too big");
					byte[] clearBuffer = clearStream.GetBuffer();
					RNG.GetBytes(clearBuffer, 32 + clearLength, 192 - clearLength);
					Sha256.ComputeHash(clearBuffer, 0, 32 + 192).CopyTo(clearBuffer, 224); // append Sha256
					Array.Reverse(clearBuffer, 32, 192);
					var aes_encrypted = AES_IGE_EncryptDecrypt(clearBuffer.AsSpan(32, 224), aes_key, zero_iv, true);
					var hash_aes = Sha256.ComputeHash(aes_encrypted);
					for (int i = 0; i < 32; i++) // prefix aes_encrypted with temp_key_xor
						clearBuffer[i] = (byte)(aes_key[i] ^ hash_aes[i]);
					aes_encrypted.CopyTo(clearBuffer, 32);
					var x = BigEndianInteger(clearBuffer);
					if (x < n) // if good result, encrypt with RSA key:
						encrypted_data = BigInteger.ModPow(x, BigEndianInteger(publicKey.e), n).To256Bytes();
				} // otherwise, repeat the steps
#endif
			}
			var serverDHparams = await client.ReqDHParams(pqInnerData.nonce, pqInnerData.server_nonce, pqInnerData.p, pqInnerData.q, fingerprint, encrypted_data);
			//5)
			var localTime = DateTimeOffset.UtcNow;
			if (serverDHparams is not ServerDHParamsOk serverDHparamsOk) throw new ApplicationException("not server_DH_params_ok");
			if (serverDHparamsOk.nonce != nonce) throw new ApplicationException("Nonce mismatch");
			if (serverDHparamsOk.server_nonce != resPQ.server_nonce) throw new ApplicationException("Server Nonce mismatch");
			var (tmp_aes_key, tmp_aes_iv) = ConstructTmpAESKeyIV(resPQ.server_nonce, pqInnerData.new_nonce);
			var answer = AES_IGE_EncryptDecrypt(serverDHparamsOk.encrypted_answer, tmp_aes_key, tmp_aes_iv, false);

			using var encryptedReader = new TL.BinaryReader(new MemoryStream(answer), client);
			var answerHash = encryptedReader.ReadBytes(20);
			var answerObj = encryptedReader.ReadTLObject();
			if (answerObj is not ServerDHInnerData serverDHinnerData) throw new ApplicationException("not server_DH_inner_data");
			long padding = encryptedReader.BaseStream.Length - encryptedReader.BaseStream.Position;
			if (padding >= 16) throw new ApplicationException("Too much pad");
			if (!Enumerable.SequenceEqual(Sha1.ComputeHash(answer, 20, answer.Length - (int)padding - 20), answerHash))
				throw new ApplicationException("Answer SHA1 mismatch");
			if (serverDHinnerData.nonce != nonce) throw new ApplicationException("Nonce mismatch");
			if (serverDHinnerData.server_nonce != resPQ.server_nonce) throw new ApplicationException("Server Nonce mismatch");
			var g_a = BigEndianInteger(serverDHinnerData.g_a);
			var dh_prime = BigEndianInteger(serverDHinnerData.dh_prime);
			ValidityChecks(dh_prime, serverDHinnerData.g);
			Helpers.Log(1, $"Server time: {serverDHinnerData.server_time} UTC");
			session.ServerTicksOffset = (serverDHinnerData.server_time - localTime).Ticks;
			//6)
			var bData = new byte[256];
			RNG.GetBytes(bData);
			var b = BigEndianInteger(bData);
			var g_b = BigInteger.ModPow(serverDHinnerData.g, b, dh_prime);
			ValidityChecksDH(g_a, g_b, dh_prime);
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
				using var writer = new BinaryWriter(clearStream, Encoding.UTF8);
				writer.WriteTLObject(clientDHinnerData);
				int clearLength = (int)clearStream.Length;  // length before padding (= 20 + message_data_length)
				int paddingToAdd = (0x7FFFFFF0 - clearLength) % 16;
				clearStream.SetLength(clearLength + paddingToAdd);
				byte[] clearBuffer = clearStream.GetBuffer();
				RNG.GetBytes(clearBuffer, clearLength, paddingToAdd);
				Sha1.ComputeHash(clearBuffer, 20, clearLength - 20).CopyTo(clearBuffer, 0);

				encrypted_data = AES_IGE_EncryptDecrypt(clearBuffer.AsSpan(0, clearLength + paddingToAdd), tmp_aes_key, tmp_aes_iv, true);
			}
			var setClientDHparamsAnswer = await client.SetClientDHParams(clientDHinnerData.nonce, clientDHinnerData.server_nonce, encrypted_data);
			//7)
			var gab = BigInteger.ModPow(g_a, b, dh_prime);
			var authKey = gab.ToByteArray(true, true);
			//8)
			var authKeyHash = Sha1.ComputeHash(authKey);
			retry_id = BinaryPrimitives.ReadInt64LittleEndian(authKeyHash); // (auth_key_aux_hash)
			//9)
			if (setClientDHparamsAnswer is not DhGenOk dhGenOk) throw new ApplicationException("not dh_gen_ok");
			if (dhGenOk.nonce != nonce) throw new ApplicationException("Nonce mismatch");
			if (dhGenOk.server_nonce != resPQ.server_nonce) throw new ApplicationException("Server Nonce mismatch");
			var expected_new_nonceN = new byte[32 + 1 + 8];
			pqInnerData.new_nonce.raw.CopyTo(expected_new_nonceN, 0);
			expected_new_nonceN[32] = 1;
			Array.Copy(authKeyHash, 0, expected_new_nonceN, 33, 8); // (auth_key_aux_hash)
			if (!Enumerable.SequenceEqual(dhGenOk.new_nonce_hash1.raw, Sha1.ComputeHash(expected_new_nonceN).Skip(4)))
				throw new ApplicationException("setClientDHparamsAnswer.new_nonce_hashN mismatch");

			session.AuthKeyID = BinaryPrimitives.ReadInt64LittleEndian(authKeyHash.AsSpan(12));
			session.AuthKey = authKey;
			session.Salt = BinaryPrimitives.ReadInt64LittleEndian(pqInnerData.new_nonce.raw) ^ BinaryPrimitives.ReadInt64LittleEndian(resPQ.server_nonce.raw);

			static (byte[] key, byte[] iv) ConstructTmpAESKeyIV(Int128 server_nonce, Int256 new_nonce)
			{
				byte[] tmp_aes_key = new byte[32], tmp_aes_iv = new byte[32];
				Sha1.Initialize();
				Sha1.TransformBlock(new_nonce, 0, 32, null, 0);
				Sha1.TransformFinalBlock(server_nonce, 0, 16);
				Sha1.Hash.CopyTo(tmp_aes_key, 0);                   // tmp_aes_key := SHA1(new_nonce + server_nonce)
				Sha1.Initialize();
				Sha1.TransformBlock(server_nonce, 0, 16, null, 0);
				Sha1.TransformFinalBlock(new_nonce, 0, 32);
				Array.Copy(Sha1.Hash, 0, tmp_aes_key, 20, 12);      //              + SHA1(server_nonce, new_nonce)[0:12]
				Array.Copy(Sha1.Hash, 12, tmp_aes_iv, 0, 8);        // tmp_aes_iv  != SHA1(server_nonce, new_nonce)[12:8]
				Sha1.Initialize();
				Sha1.TransformBlock(new_nonce, 0, 32, null, 0);
				Sha1.TransformFinalBlock(new_nonce, 0, 32);
				Sha1.Hash.CopyTo(tmp_aes_iv, 8);                    //              + SHA(new_nonce + new_nonce)
				Array.Copy(new_nonce, 0, tmp_aes_iv, 28, 4);        //              + new_nonce[0:4]
				return (tmp_aes_key, tmp_aes_iv);
			}
		}

		private static void ValidityChecks(BigInteger p, int g)
		{
			Helpers.Log(2, "Verifying encryption key safety... (this should happen only once per DC)");
			// check that 2^2047 <= p < 2^2048
			if (p.GetBitLength() != 2048) throw new ApplicationException("p is not 2048-bit number");
			// check that g generates a cyclic subgroup of prime order (p - 1) / 2, i.e. is a quadratic residue mod p.
			BigInteger mod_r;
			if (g switch
			{
				2 => p % 8 != 7,
				3 => p % 3 != 2,
				4 => false,
				5 => (mod_r = p % 5) != 1 && mod_r != 4,
				6 => (mod_r = p % 24) != 19 && mod_r != 23,
				7 => (mod_r = p % 7) != 3 && mod_r != 5 && mod_r != 6,
				_ => true,
			})
				throw new ApplicationException("Bad prime mod 4g");
			// check whether p is a safe prime (meaning that both p and (p - 1) / 2 are prime)
			if (!p.IsProbablePrime()) throw new ApplicationException("p is not a prime number");
			if (!((p - 1) / 2).IsProbablePrime()) throw new ApplicationException("(p - 1) / 2 is not a prime number");
		}

		private static void ValidityChecksDH(BigInteger g_a, BigInteger g_b, BigInteger dh_prime)
		{
			// check that g, g_a and g_b are greater than 1 and less than dh_prime - 1.
			// We recommend checking that g_a and g_b are between 2^{2048-64} and dh_prime - 2^{2048-64} as well.
			var l = BigInteger.One << (2048 - 64);
			var r = dh_prime - l;
			if (g_a < l || g_a > r || g_b < l || g_b > r)
				throw new ApplicationException("g^a or g^b is not between 2^{2048-64} and dh_prime - 2^{2048-64}");
		}

		[TLDef(0x7A19CB76)] //RSA_public_key#7a19cb76 n:bytes e:bytes = RSAPublicKey
		public partial class RSAPublicKey : ITLObject { public byte[] n, e; }

		public static void LoadPublicKey(string pem)
		{
			using var rsa = RSA.Create();
			rsa.ImportFromPem(pem);
			var rsaParam = rsa.ExportParameters(false);
			var publicKey = new RSAPublicKey { n = rsaParam.Modulus, e = rsaParam.Exponent };
			var bareData = publicKey.Serialize(); // bare serialization
			var fingerprint = BinaryPrimitives.ReadInt64LittleEndian(Sha1.ComputeHash(bareData, 4, bareData.Length - 4).AsSpan(12)); // 64 lower-order bits of SHA1
			PublicKeys[fingerprint] = publicKey;
			Helpers.Log(1, $"Loaded a public key with fingerprint {fingerprint:X}");
		}

		private static void LoadDefaultPublicKeys() 
		{
#if OLDKEY
			// Old Public Key (C3B42B026CE86B21)
			LoadPublicKey(@"-----BEGIN RSA PUBLIC KEY-----
MIIBCgKCAQEAwVACPi9w23mF3tBkdZz+zwrzKOaaQdr01vAbU4E1pvkfj4sqDsm6
lyDONS789sVoD/xCS9Y0hkkC3gtL1tSfTlgCMOOul9lcixlEKzwKENj1Yz/s7daS
an9tqw3bfUV/nqgbhGX81v/+7RFAEd+RwFnK7a+XYl9sluzHRyVVaTTveB2GazTw
Efzk2DWgkBluml8OREmvfraX3bkHZJTKX4EQSjBbbdJ2ZXIsRrYOXfaA+xayEGB+
8hdlLmAjbCVfaigxX0CDqWeR1yFL9kwd9P0NsZRPsmoqVwMbMu7mStFai6aIhc3n
Slv8kg9qv1m6XHVQY3PnEw+QQtqSIXklHwIDAQAB
-----END RSA PUBLIC KEY-----");
#else
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
#endif
		}

		internal static byte[] EncryptDecryptMessage(Span<byte> input, bool encrypt, byte[] authKey, byte[] msgKey, int msgKeyOffset)
		{
			// first, construct AES key & IV
			byte[] aes_key = new byte[32], aes_iv = new byte[32];
			int x = encrypt ? 0 : 8;
#if MTPROTO1
			var sha1 = encrypt ? Sha1 : Sha1Recv;
			sha1.Initialize();
			sha1.TransformBlock(msgKey, msgKeyOffset, 16, null, 0);     // msgKey
			sha1.TransformFinalBlock(authKey, x, 32);                   // authKey[x:32]
			var sha1_a = sha1.Hash;
			sha1.Initialize();
			sha1.TransformBlock(authKey, 32 + x, 16, null, 0);          // authKey[32+x:16]
			sha1.TransformBlock(msgKey, msgKeyOffset, 16, null, 0);     // msgKey
			sha1.TransformFinalBlock(authKey, 48 + x, 16);              // authKey[48+x:16]
			var sha1_b = sha1.Hash;
			sha1.Initialize();
			sha1.TransformBlock(authKey, 64 + x, 32, null, 0);          // authKey[64+x:32]
			sha1.TransformFinalBlock(msgKey, msgKeyOffset, 16);         // msgKey
			var sha1_c = sha1.Hash;
			sha1.Initialize();
			sha1.TransformBlock(msgKey, msgKeyOffset, 16, null, 0);     // msgKey
			sha1.TransformFinalBlock(authKey, 96 + x, 32);              // authKey[96+x:32]
			var sha1_d = sha1.Hash;
			Array.Copy(sha1_a, 0, aes_key, 0, 8);
			Array.Copy(sha1_b, 8, aes_key, 8, 12);
			Array.Copy(sha1_c, 4, aes_key, 20, 12);
			Array.Copy(sha1_a, 8, aes_iv, 0, 12);
			Array.Copy(sha1_b, 0, aes_iv, 12, 8);
			Array.Copy(sha1_c, 16, aes_iv, 20, 4);
			Array.Copy(sha1_d, 0, aes_iv, 24, 8);
#else
			var sha256 = encrypt ? Sha256 : Sha256Recv;
			sha256.Initialize();
			sha256.TransformBlock(msgKey, msgKeyOffset, 16, null, 0);   // msgKey
			sha256.TransformFinalBlock(authKey, x, 36);                 // authKey[x:36]
			var sha256_a = sha256.Hash;
			sha256.Initialize();
			sha256.TransformBlock(authKey, 40 + x, 36, null, 0);        // authKey[40+x:36]
			sha256.TransformFinalBlock(msgKey, msgKeyOffset, 16);       // msgKey
			var sha256_b = sha256.Hash;
			Array.Copy(sha256_a, 0, aes_key, 0, 8);
			Array.Copy(sha256_b, 8, aes_key, 8, 16);
			Array.Copy(sha256_a, 24, aes_key, 24, 8);
			Array.Copy(sha256_b, 0, aes_iv, 0, 8);
			Array.Copy(sha256_a, 8, aes_iv, 8, 16);
			Array.Copy(sha256_b, 24, aes_iv, 24, 8);
#endif
			return AES_IGE_EncryptDecrypt(input, aes_key, aes_iv, encrypt);
		}

		private static byte[] AES_IGE_EncryptDecrypt(Span<byte> input, byte[] aes_key, byte[] aes_iv, bool encrypt)
		{
			using var aes = Aes.Create();
			aes.Mode = CipherMode.ECB;
			aes.Padding = PaddingMode.Zeros;
			if (aes.BlockSize != 128) throw new ApplicationException("AES Blocksize is not 16 bytes");
			if (input.Length % 16 != 0) throw new ApplicationException("intput size not divisible by 16");

			// code adapted from PHP implementation found at https://mgp25.com/AESIGE/
			var output = new byte[input.Length];
			var xPrev = aes_iv.AsSpan(encrypt ? 16 : 0, 16);
			var yPrev = aes_iv.AsSpan(encrypt ? 0 : 16, 16);
			var aesCrypto = encrypt ? aes.CreateEncryptor(aes_key, null) : aes.CreateDecryptor(aes_key, null);
			using (aesCrypto)
			{
				byte[] yXOR = new byte[16];
				for (int i = 0; i < input.Length; i += 16)
				{
					var x = input.Slice(i, 16);
					var y = output.AsSpan(i, 16);
					for (int j = 0; j < 16; j++)
						yXOR[j] = (byte)(x[j] ^ yPrev[j]);
					var yFinal = aesCrypto.TransformFinalBlock(yXOR, 0, 16);
					for (int j = 0; j < 16; j++)
						y[j] = (byte)(yFinal[j] ^ xPrev[j]);
					xPrev = x;
					yPrev = y;
				}
			}
			return output;
		}

		internal static InputCheckPasswordSRPBase Check2FA(Account_Password accountPassword, string password)
		{
			if (accountPassword.current_algo is not PasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow algo)
				throw new ApplicationException("2FA authentication uses an unsupported algo: " + accountPassword.current_algo?.GetType().Name);

			var passwordBytes = Encoding.UTF8.GetBytes(password);
			var g = new BigInteger(algo.g);
			var p = BigEndianInteger(algo.p);
			var g_b = BigEndianInteger(accountPassword.srp_B);
			var g_b_256 = g_b.To256Bytes();
			var g_256 = g.To256Bytes();
			ValidityChecks(p, algo.g);

			Sha256.Initialize();
			Sha256.TransformBlock(algo.salt1, 0, algo.salt1.Length, null, 0);
			Sha256.TransformBlock(passwordBytes, 0, passwordBytes.Length, null, 0);
			Sha256.TransformFinalBlock(algo.salt1, 0, algo.salt1.Length);
			var hash = Sha256.Hash;
			Sha256.Initialize();
			Sha256.TransformBlock(algo.salt2, 0, algo.salt2.Length, null, 0);
			Sha256.TransformBlock(hash, 0, 32, null, 0);
			Sha256.TransformFinalBlock(algo.salt2, 0, algo.salt2.Length);
			hash = Sha256.Hash;
#if NETCOREAPP2_0_OR_GREATER
			using var derive = new Rfc2898DeriveBytes(hash, algo.salt1, 100000, HashAlgorithmName.SHA512);
			var pbkdf2 = derive.GetBytes(64);
#else
			var pbkdf2 = PBKDF2_SHA512(hash, algo.salt1, 100000, 64);
#endif
			Sha256.Initialize();
			Sha256.TransformBlock(algo.salt2, 0, algo.salt2.Length, null, 0);
			Sha256.TransformBlock(pbkdf2, 0, 64, null, 0);
			Sha256.TransformFinalBlock(algo.salt2, 0, algo.salt2.Length);
			var x = BigEndianInteger(Sha256.Hash);

			Sha256.Initialize();
			Sha256.TransformBlock(algo.p, 0, 256, null, 0);
			Sha256.TransformFinalBlock(g_256, 0, 256);
			var k = BigEndianInteger(Sha256.Hash);

			var v = BigInteger.ModPow(g, x, p);
			var k_v = (k * v) % p;
			var a = BigEndianInteger(new Int256(RNG).raw);
			var g_a = BigInteger.ModPow(g, a, p);
			var g_a_256 = g_a.To256Bytes();

			Sha256.Initialize();
			Sha256.TransformBlock(g_a_256, 0, 256, null, 0);
			Sha256.TransformFinalBlock(g_b_256, 0, 256);
			var u = BigEndianInteger(Sha256.Hash);

			var t = (g_b - k_v) % p; //(positive modulo, if the result is negative increment by p)
			if (t.Sign < 0) t += p;
			var s_a = BigInteger.ModPow(t, a + u * x, p);
			var k_a = Sha256.ComputeHash(s_a.To256Bytes());

			hash = Sha256.ComputeHash(algo.p);
			var h2 = Sha256.ComputeHash(g_256);
			for (int i = 0; i < 32; i++) hash[i] ^= h2[i];
			var hs1 = Sha256.ComputeHash(algo.salt1);
			var hs2 = Sha256.ComputeHash(algo.salt2);
			Sha256.Initialize();
			Sha256.TransformBlock(hash, 0, 32, null, 0);
			Sha256.TransformBlock(hs1, 0, 32, null, 0);
			Sha256.TransformBlock(hs2, 0, 32, null, 0);
			Sha256.TransformBlock(g_a_256, 0, 256, null, 0);
			Sha256.TransformBlock(g_b_256, 0, 256, null, 0);
			Sha256.TransformFinalBlock(k_a, 0, 32);
			var m1 = Sha256.Hash;

			return new InputCheckPasswordSRP { A = g_a_256, M1 = m1, srp_id = accountPassword.srp_id };
		}

#if !NETCOREAPP2_0_OR_GREATER
		// adapted from https://github.com/dotnet/aspnetcore/blob/main/src/DataProtection/Cryptography.KeyDerivation/src/PBKDF2/ManagedPbkdf2Provider.cs
		public static byte[] PBKDF2_SHA512(byte[] password, byte[] salt, int iterationCount, int numBytesRequested)
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
}
