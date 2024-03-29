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
using static WTelegram.Encryption;

namespace WTelegram
{
	public interface ISecretChat
	{
		int ChatId { get; }
		long RemoteUserId { get; }
		InputEncryptedChat Peer { get; }
		int RemoteLayer { get; }
	}

	[TLDef(0xFEFEFEFE)] [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles")]
	internal sealed partial class SecretChat : IObject, ISecretChat
	{
		[Flags] public enum Flags : uint { requestChat = 1, renewKey = 2, acceptKey = 4, originator = 8, commitKey = 16 }
		public Flags flags;
		public InputEncryptedChat peer = new();
		public byte[] salt;             // contains future/discarded authKey during acceptKey/commitKey
		public byte[] authKey;
		public DateTime key_created;
		public int key_useCount;
		public long participant_id;
		public int remoteLayer = 46;
		public int in_seq_no = -2, out_seq_no = 0;
		public long exchange_id;

		public int ChatId => peer.chat_id;
		public long RemoteUserId => participant_id;
		public InputEncryptedChat Peer => peer;
		public int RemoteLayer => remoteLayer;

		internal long key_fingerprint;
		internal SortedList<int, TL.Layer23.DecryptedMessageLayer> pendingMsgs = [];
		internal void Discarded() // clear out fields for more security
		{
			Array.Clear(authKey, 0, authKey.Length);
			key_fingerprint = participant_id = peer.access_hash = peer.chat_id = in_seq_no = out_seq_no = remoteLayer = 0;
		}
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles")]
	public sealed class SecretChats : IDisposable
	{
		public event Action OnChanged;

		private readonly Client client;
		private readonly FileStream storage;
		private readonly Dictionary<int, SecretChat> chats = [];
		private Messages_DhConfig dh;
		private BigInteger dh_prime;
		private readonly SHA256 sha256 = SHA256.Create();
		private readonly SHA1 sha1 = SHA1.Create();
		private readonly Random random = new();
		private const int ThresholdPFS = 100;

		/// <summary>Instantiate a Secret Chats manager</summary>
		/// <param name="client">The Telegram client</param>
		/// <param name="filename">File path to load/save secret chats keys/status (optional)</param>
		public SecretChats(Client client, string filename = null)
		{
			this.client = client;
			if (filename != null)
			{
				storage = File.Open(filename, FileMode.OpenOrCreate);
				if (storage.Length != 0) Load(storage);
				OnChanged = () => { storage.SetLength(0); Save(storage); };
			}
		}
		public void Dispose() { OnChanged?.Invoke(); storage?.Dispose(); sha256.Dispose(); sha1.Dispose(); }

		public List<ISecretChat> Chats => [.. chats.Values];

		public bool IsChatActive(int chat_id) => !(chats.GetValueOrDefault(chat_id)?.flags.HasFlag(SecretChat.Flags.requestChat) ?? true);

		public void Save(Stream output)
		{
			using var writer = new BinaryWriter(output, Encoding.UTF8, true);
			writer.Write(0);
			writer.WriteTLObject(dh);
			writer.Write(chats.Count);
			foreach (var chat in chats.Values)
				writer.WriteTLObject(chat);
		}
		public void Load(Stream input)
		{
			using var reader = new BinaryReader(input, Encoding.UTF8, true);
			if (reader.ReadInt32() != 0) throw new WTException("Unrecognized Secrets format");
			dh = (Messages_DhConfig)reader.ReadTLObject();
			if (dh?.p != null) dh_prime = BigEndianInteger(dh.p);
			int count = reader.ReadInt32();
			for (int i = 0; i < count; i++)
			{
				var chat = (SecretChat)reader.ReadTLObject();
				if (chat.authKey?.Length > 0) chat.key_fingerprint = BinaryPrimitives.ReadInt64LittleEndian(sha1.ComputeHash(chat.authKey).AsSpan(12));
				chats[chat.ChatId] = chat;
			}
		}

		/// <summary>Terminate the secret chat</summary>
		/// <param name="chat_id">Secret Chat ID</param>
		/// <param name="delete_history">Whether to delete the entire chat history for the other user as well</param>
		public async Task Discard(int chat_id, bool delete_history = false)
		{
			if (chats.TryGetValue(chat_id, out var chat))
			{
				chats.Remove(chat_id);
				chat.Discarded();
			}
			try
			{
				await client.Messages_DiscardEncryption(chat_id, delete_history);
			}
			catch (RpcException ex) when (ex.Code == 400 && ex.Message == "ENCRYPTION_ALREADY_DECLINED") { }
		}

		private async Task<byte[]> UpdateDHConfig()
		{
			var mdhcb = await client.Messages_GetDhConfig(dh?.version ?? 0, 256);
			if (mdhcb is Messages_DhConfigNotModified { random: var random })
				_ = dh ?? throw new WTException("DhConfigNotModified on zero version");
			else if (mdhcb is Messages_DhConfig dhc)
			{
				var p = BigEndianInteger(dhc.p);
				CheckGoodPrime(p, dhc.g);
				(dh, dh_prime, random, dh.random) = (dhc, p, dhc.random, null);
			}
			else throw new WTException("Unexpected DHConfig response: " + mdhcb?.GetType().Name);
			if (random.Length != 256) throw new WTException("Invalid DHConfig random");
			var salt = new byte[256];
			RNG.GetBytes(salt);
			for (int i = 0; i < 256; i++) salt[i] ^= random[i];
			return salt;
		}

		/// <summary>Initiate a secret chat with the given user.<br/>(chat must be acknowledged by remote user before being active)</summary>
		/// <param name="user">The remote user</param>
		/// <returns>Secret Chat ID</returns>
		/// <exception cref="WTException"></exception>
		public async Task<int> Request(InputUserBase user)
		{
			int chat_id;
			do chat_id = (int)Helpers.RandomLong(); while (chats.ContainsKey(chat_id));
			var chat = chats[chat_id] = new SecretChat
			{
				flags = SecretChat.Flags.requestChat | SecretChat.Flags.originator,
				peer = { chat_id = chat_id },
				participant_id = user.UserId ?? 0,
				salt = await UpdateDHConfig(),
				out_seq_no = 1,
			};
			var a = BigEndianInteger(chat.salt);
			var g_a = BigInteger.ModPow(dh.g, a, dh_prime);
			CheckGoodGaAndGb(g_a, dh_prime);
			var ecb = await client.Messages_RequestEncryption(user, chat_id, g_a.To256Bytes());
			if (ecb is not EncryptedChatWaiting ecw || ecw.id != chat_id || ecw.participant_id != chat.participant_id)
				throw new WTException("Invalid " + ecb?.GetType().Name);
			chat.peer.access_hash = ecw.access_hash;
			return chat_id;
		}

		/// <summary>Processes the <see cref="UpdateEncryption"/> you received from Telegram (<see cref="Client.OnUpdates"/>).</summary>
		/// <param name="update">If update.chat is <see cref="EncryptedChatRequested"/>, you might want to first make sure you want to accept this secret chat initiated by user <see cref="EncryptedChatRequested.admin_id"/></param>
		/// <param name="acceptChatRequests">Incoming requests for secret chats are automatically: accepted (<see langword="true"/>), rejected (<see langword="false"/>) or ignored (<see langword="null"/>)</param>
		/// <returns><see langword="true"/> if the update was handled successfully</returns>
		/// <exception cref="WTException"></exception>
		public async Task<bool> HandleUpdate(UpdateEncryption update, bool? acceptChatRequests = true)
		{
			try
			{
				if (chats.TryGetValue(update.chat.ID, out var chat))
				{
					if (update.chat is EncryptedChat ec && chat.flags.HasFlag(SecretChat.Flags.requestChat)) // remote accepted our request
					{
						var a = BigEndianInteger(chat.salt);
						var g_b = BigEndianInteger(ec.g_a_or_b);
						CheckGoodGaAndGb(g_b, dh_prime);
						var gab = BigInteger.ModPow(g_b, a, dh_prime);
						chat.flags &= ~SecretChat.Flags.requestChat;
						SetAuthKey(chat, gab.To256Bytes());
						if (ec.key_fingerprint != chat.key_fingerprint) throw new WTException("Invalid fingerprint on accepted secret chat");
						if (ec.access_hash != chat.peer.access_hash || ec.participant_id != chat.participant_id) throw new WTException("Invalid peer on accepted secret chat");
						await SendNotifyLayer(chat);
						return true;
					}
					else if (update.chat is EncryptedChatDiscarded ecd)
					{
						chats.Remove(chat.ChatId);
						chat.Discarded();
						return true;
					}
					Helpers.Log(3, $"Unexpected {update.chat.GetType().Name} for secret chat {chat.ChatId}");
					return false;
				}
				else if (update.chat is EncryptedChatRequested ecr) // incoming request
				{
					switch (acceptChatRequests)
					{
						case null: return false;
						case false: await client.Messages_DiscardEncryption(ecr.id, false); return true;
						case true:
							var salt = await UpdateDHConfig();
							var b = BigEndianInteger(salt);
							var g_b = BigInteger.ModPow(dh.g, b, dh_prime);
							var g_a = BigEndianInteger(ecr.g_a);
							CheckGoodGaAndGb(g_a, dh_prime);
							CheckGoodGaAndGb(g_b, dh_prime);
							var gab = BigInteger.ModPow(g_a, b, dh_prime);
							chat = chats[ecr.id] = new SecretChat
							{
								flags = 0,
								peer = { chat_id = ecr.id, access_hash = ecr.access_hash },
								participant_id = ecr.admin_id,
								in_seq_no = -1,
							};
							SetAuthKey(chat, gab.To256Bytes());
							var ecb = await client.Messages_AcceptEncryption(chat.peer, g_b.ToByteArray(true, true), chat.key_fingerprint);
							if (ecb is not EncryptedChat ec || ec.id != ecr.id || ec.access_hash != ecr.access_hash ||
								ec.admin_id != ecr.admin_id || ec.key_fingerprint != chat.key_fingerprint)
								throw new WTException("Inconsistent accepted secret chat");
							await SendNotifyLayer(chat);
							return true;
					}
				}
				else if (update.chat is EncryptedChatDiscarded) // unknown chat discarded
					return true;
				Helpers.Log(3, $"Unexpected {update.chat.GetType().Name} for unknown secret chat {update.chat.ID}");
				return false;
			}
			catch
			{
				await Discard(update.chat.ID);
				throw;
			}
			finally
			{
				OnChanged?.Invoke();
			}
		}

		private void SetAuthKey(SecretChat chat, byte[] key)
		{
			chat.authKey = key;
			chat.key_fingerprint = BinaryPrimitives.ReadInt64LittleEndian(sha1.ComputeHash(key).AsSpan(12));
			chat.exchange_id = 0;
			chat.key_useCount = 0;
			chat.key_created = DateTime.UtcNow;
		}

		private async Task SendNotifyLayer(SecretChat chat)
		{
			await SendMessage(chat.ChatId, new TL.Layer23.DecryptedMessageService { random_id = Helpers.RandomLong(),
				action = new TL.Layer23.DecryptedMessageActionNotifyLayer { layer = Layer.SecretChats } });
			if (chat.remoteLayer < Layer.MTProto2) chat.remoteLayer = Layer.MTProto2;
		}

		/// <summary>Encrypt and send a message on a secret chat</summary>
		/// <remarks>You would typically pass an instance of <see cref="TL.Layer73.DecryptedMessage"/> or <see cref="TL.Layer23.DecryptedMessageService"/> that you created and filled
		/// <br/>Remember to fill <c>random_id</c> with <see cref="WTelegram.Helpers.RandomLong"/>, and the <c>flags</c> field if necessary</remarks>
		/// <param name="chatId">Secret Chat ID</param>
		/// <param name="msg">The pre-filled <see cref="TL.Layer73.DecryptedMessage">DecryptedMessage</see> or <see cref="TL.Layer23.DecryptedMessageService">DecryptedMessageService </see> to send</param>
		/// <param name="silent">Send encrypted message without a notification</param>
		/// <param name="file">Optional file attachment. See method <see cref="UploadFile">UploadFile</see></param>
		/// <returns>Confirmation of sent message</returns>
		public async Task<Messages_SentEncryptedMessage> SendMessage(int chatId, DecryptedMessageBase msg, bool silent = false, InputEncryptedFileBase file = null)
		{
			if (!chats.TryGetValue(chatId, out var chat)) throw new WTException("Secret chat not found");
			try
			{
				var dml = new TL.Layer23.DecryptedMessageLayer
				{
					layer = Math.Min(chat.remoteLayer, Layer.SecretChats),
					random_bytes = new byte[15],
					in_seq_no = chat.in_seq_no < 0 ? chat.in_seq_no + 2 : chat.in_seq_no,
					out_seq_no = chat.out_seq_no,
					message = msg
				};
				//Debug.WriteLine($">\t\t\t\t{dml.in_seq_no}\t{dml.out_seq_no}");
				var result = await SendMessage(chat, dml, silent, file);
				chat.out_seq_no += 2;
				return result;
			}
			finally
			{
				OnChanged?.Invoke();
			}
		}

		private async Task<Messages_SentEncryptedMessage> SendMessage(SecretChat chat, TL.Layer23.DecryptedMessageLayer dml, bool silent = false, InputEncryptedFileBase file = null)
		{
			RNG.GetBytes(dml.random_bytes);
			int x = 8 - (int)(chat.flags & SecretChat.Flags.originator);
			using var memStream = new MemoryStream(1024);
			using var writer = new BinaryWriter(memStream);

			using var clearStream = new MemoryStream(1024);
			using var clearWriter = new BinaryWriter(clearStream);
			clearWriter.Write(chat.authKey, 88 + x, 32);
			clearWriter.Write(0);                   // int32 message_data_length (to be patched)
			clearWriter.WriteTLObject(dml);         // bytes message_data
			int clearLength = (int)clearStream.Length - 32;  // length before padding (= 4 + message_data_length)
			int padding = (0x7FFFFFF0 - clearLength) % 16;
			padding += random.Next(2, 16) * 16;        // MTProto 2.0 padding must be between 12..1024 with total length divisible by 16
			clearStream.SetLength(32 + clearLength + padding);
			byte[] clearBuffer = clearStream.GetBuffer();
			BinaryPrimitives.WriteInt32LittleEndian(clearBuffer.AsSpan(32), clearLength - 4);    // patch message_data_length
			RNG.GetBytes(clearBuffer, 32 + clearLength, padding);
			var msgKeyLarge = sha256.ComputeHash(clearBuffer, 0, 32 + clearLength + padding);
			const int msgKeyOffset = 8; // msg_key = middle 128-bits of SHA256(authkey_part+plaintext+padding)
			byte[] encrypted_data = EncryptDecryptMessage(clearBuffer.AsSpan(32, clearLength + padding), true, x, chat.authKey, msgKeyLarge, msgKeyOffset, sha256);

			writer.Write(chat.key_fingerprint);             // int64 key_fingerprint
			writer.Write(msgKeyLarge, msgKeyOffset, 16);    // int128 msg_key
			writer.Write(encrypted_data);                   // bytes encrypted_data
			var data = memStream.ToArray();

			CheckPFS(chat);
			if (file != null)
				return await client.Messages_SendEncryptedFile(chat.peer, dml.message.RandomId, data, file, silent);
			else if (dml.message is TL.Layer23.DecryptedMessageService or TL.Layer8.DecryptedMessageService)
				return await client.Messages_SendEncryptedService(chat.peer, dml.message.RandomId, data);
			else
				return await client.Messages_SendEncrypted(chat.peer, dml.message.RandomId, data, silent);
		}

		private IObject Decrypt(SecretChat chat, byte[] data, int dataLen)
		{
			if (dataLen < 32) // authKeyId+msgKey+(length+ctorNb)
				throw new WTException($"Encrypted packet too small: {data.Length}");
			var authKey = chat.authKey;
			long authKeyId = BinaryPrimitives.ReadInt64LittleEndian(data);
			if (authKeyId == chat.key_fingerprint)
				if (!chat.flags.HasFlag(SecretChat.Flags.commitKey)) CheckPFS(chat);
				else { chat.flags &= ~SecretChat.Flags.commitKey; Array.Clear(chat.salt, 0, chat.salt.Length); }
			else if (chat.flags.HasFlag(SecretChat.Flags.commitKey) && authKeyId == BinaryPrimitives.ReadInt64LittleEndian(sha1.ComputeHash(chat.salt).AsSpan(12))) authKey = chat.salt;
			else throw new WTException($"Received a packet encrypted with unexpected key {authKeyId:X}");
			int x = (int)(chat.flags & SecretChat.Flags.originator);
			byte[] decrypted_data = EncryptDecryptMessage(data.AsSpan(24, dataLen - 24), false, x, authKey, data, 8, sha256);
			var length = BinaryPrimitives.ReadInt32LittleEndian(decrypted_data);
			var success = length >= 4 && length <= decrypted_data.Length - 4;
			if (success)
			{
				sha256.Initialize();
				sha256.TransformBlock(authKey, 88 + x, 32, null, 0);
				sha256.TransformFinalBlock(decrypted_data, 0, decrypted_data.Length);
				if (success = data.AsSpan(8, 16).SequenceEqual(sha256.Hash.AsSpan(8, 16)))
					if (decrypted_data.Length - 4 - length is < 12 or > 1024) throw new WTException($"Invalid MTProto2 padding length: {decrypted_data.Length - 4}-{length}");
					else if (chat.remoteLayer < Layer.MTProto2) chat.remoteLayer = Layer.MTProto2;
			}
			if (!success) throw new WTException("Could not decrypt message");
			if (length % 4 != 0) throw new WTException($"Invalid message_data_length: {length}");
			using var reader = new BinaryReader(new MemoryStream(decrypted_data, 4, length));
			return reader.ReadTLObject();
		}

		/// <summary>Decrypt an encrypted message obtained in <see cref="UpdateNewEncryptedMessage"/></summary>
		/// <param name="msg">Encrypted <see cref="UpdateNewEncryptedMessage.message"/></param>
		/// <param name="fillGaps">If messages are missing or received in wrong order, automatically request to resend missing messages</param>
		/// <returns>An array of <see cref="TL.Layer73.DecryptedMessage">DecryptedMessage</see> or <see cref="TL.Layer23.DecryptedMessageService">DecryptedMessageService </see> from various TL.LayerXX namespaces.<br/>
		/// You can use the generic properties to access their fields
		/// <para>May return an empty array if msg was already previously received or is not the next message in sequence.
		/// <br/>May return multiple messages if missing messages are finally received (using <paramref name="fillGaps"/> = true)</para></returns>
		/// <exception cref="WTException"></exception>
		public ICollection<DecryptedMessageBase> DecryptMessage(EncryptedMessageBase msg, bool fillGaps = true)
		{
			if (!chats.TryGetValue(msg.ChatId, out var chat)) throw new WTException("Secret chat not found");
			try
			{
				var obj = Decrypt(chat, msg.Bytes, msg.Bytes.Length);
				if (obj is not TL.Layer23.DecryptedMessageLayer dml) throw new WTException("Decrypted object is not DecryptedMessageLayer");
				if (dml.random_bytes.Length < 15) throw new WTException("Not enough random_bytes");
				if (((dml.out_seq_no ^ dml.in_seq_no) & 1) != 1 || ((dml.out_seq_no ^ chat.in_seq_no) & 1) != 0) throw new WTException("Invalid seq_no parities");
				if (dml.layer > chat.remoteLayer) chat.remoteLayer = dml.layer;
				//Debug.WriteLine($"<\t{dml.in_seq_no}\t{dml.out_seq_no}\t\t\t\t\t\texpected:{chat.out_seq_no}/{chat.in_seq_no + 2}");
				if (dml.out_seq_no <= chat.in_seq_no) return []; // already received message
				var pendingMsgSeqNo = chat.pendingMsgs.Keys;
				if (fillGaps && dml.out_seq_no > chat.in_seq_no + 2)
				{
					var lastPending = pendingMsgSeqNo.LastOrDefault();
					if (lastPending == 0) lastPending = chat.in_seq_no;
					chat.pendingMsgs[dml.out_seq_no] = dml;
					if (dml.out_seq_no > lastPending + 2) // send request to resend missing gap asynchronously
						_ = SendMessage(chat.ChatId, new TL.Layer23.DecryptedMessageService { random_id = Helpers.RandomLong(),
							action = new TL.Layer23.DecryptedMessageActionResend { start_seq_no = lastPending + 2, end_seq_no = dml.out_seq_no - 2 } });
					return []; 
				}
				chat.in_seq_no = dml.out_seq_no;
				if (pendingMsgSeqNo.Count == 0 || pendingMsgSeqNo[0] != dml.out_seq_no + 2)
					if (HandleAction(chat, dml.message.Action)) return []; 
					else return [dml.message];
				else // we have pendingMsgs completing the sequence in order
				{
					var list = new List<DecryptedMessageBase>();
					if (!HandleAction(chat, dml.message.Action))
						list.Add(dml.message);
					do
					{
						dml = chat.pendingMsgs.Values[0];
						chat.pendingMsgs.RemoveAt(0);
						chat.in_seq_no += 2;
						if (!HandleAction(chat, dml.message.Action))
							list.Add(dml.message);
					} while (pendingMsgSeqNo.Count != 0 && pendingMsgSeqNo[0] == chat.in_seq_no + 2);
					return list;
				}
			}
			catch (Exception)
			{
				_ = Discard(msg.ChatId);
				throw;
			}
			finally
			{
				OnChanged?.Invoke();
			}
		}

		private bool HandleAction(SecretChat chat, DecryptedMessageAction action)
		{
			switch (action)
			{
				case TL.Layer23.DecryptedMessageActionNotifyLayer dmanl:
					chat.remoteLayer = dmanl.layer;
					return true;
				case TL.Layer23.DecryptedMessageActionResend resend:
					Helpers.Log(1, $"SC{(short)chat.ChatId:X4}> Resend {resend.start_seq_no}-{resend.end_seq_no}");
					var msgSvc = new TL.Layer23.DecryptedMessageService { action = new TL.Layer23.DecryptedMessageActionNoop() };
					var dml = new TL.Layer23.DecryptedMessageLayer
					{
						layer = Math.Min(chat.remoteLayer, Layer.SecretChats),
						random_bytes = new byte[15],
						in_seq_no = chat.in_seq_no,
						message = msgSvc
					};
					for (dml.out_seq_no = resend.start_seq_no; dml.out_seq_no <= resend.end_seq_no; dml.out_seq_no += 2)
					{
						msgSvc.random_id = Helpers.RandomLong();
						_ = SendMessage(chat, dml);
					}
					return true;
				case TL.Layer23.DecryptedMessageActionNoop:
					Helpers.Log(1, $"SC{(short)chat.ChatId:X4}> Noop");
					return true;
				case TL.Layer23.DecryptedMessageActionRequestKey:
				case TL.Layer23.DecryptedMessageActionAcceptKey:
				case TL.Layer23.DecryptedMessageActionCommitKey:
				case TL.Layer23.DecryptedMessageActionAbortKey:
					Helpers.Log(1, $"SC{(short)chat.ChatId:X4}> PFS {action.GetType().Name[22..]}");
					HandlePFS(chat, action);
					return true;
			}
			return false;
		}

		private async void CheckPFS(SecretChat chat)
		{
			if (++chat.key_useCount < ThresholdPFS && chat.key_created >= DateTime.UtcNow.AddDays(-7)) return;
			if (chat.key_useCount < ThresholdPFS) chat.key_useCount = ThresholdPFS;
			if ((chat.flags & (SecretChat.Flags.requestChat | SecretChat.Flags.renewKey | SecretChat.Flags.acceptKey)) != 0)
				if (chat.key_useCount < ThresholdPFS * 2) return;
				else { Helpers.Log(4, "SC{(short)chat.ChatId:X4}> PFS Failure"); _ = Discard(chat.ChatId); return; }
			try
			{
				chat.flags |= SecretChat.Flags.renewKey;
				Helpers.Log(1, $"SC{(short)chat.ChatId:X4}> PFS RenewKey");
				await Task.Delay(100);
				chat.salt = new byte[256];
				RNG.GetBytes(chat.salt);
				var a = BigEndianInteger(chat.salt);
				var g_a = BigInteger.ModPow(dh.g, a, dh_prime);
				CheckGoodGaAndGb(g_a, dh_prime);
				chat.exchange_id = Helpers.RandomLong();
				await SendMessage(chat.ChatId, new TL.Layer23.DecryptedMessageService { random_id = Helpers.RandomLong(),
					action = new TL.Layer23.DecryptedMessageActionRequestKey { exchange_id = chat.exchange_id, g_a = g_a.To256Bytes() } });
			}
			catch (Exception ex)
			{
				Helpers.Log(4, "Error in CheckRenewKey: " + ex);
				chat.flags &= ~SecretChat.Flags.renewKey;
			}
		}

		private async void HandlePFS(SecretChat chat, DecryptedMessageAction action)
		{
			try
			{
				switch (action)
				{
					case TL.Layer23.DecryptedMessageActionRequestKey request:
						switch (chat.flags & (SecretChat.Flags.requestChat | SecretChat.Flags.renewKey | SecretChat.Flags.acceptKey))
						{
							case SecretChat.Flags.renewKey: // Concurrent Re-Keying
								if (chat.exchange_id > request.exchange_id) return; // we won, ignore the smaller exchange_id RequestKey
								chat.flags &= ~SecretChat.Flags.renewKey;
								if (chat.exchange_id == request.exchange_id) // equal => silent abort both re-keing
								{
									Array.Clear(chat.salt, 0, chat.salt.Length);
									chat.exchange_id = 0;
									return;
								}
								break; // we lost, process with the larger exchange_id RequestKey
							case 0: break;
							default: throw new WTException("Invalid RequestKey");
						}
						var g_a = BigEndianInteger(request.g_a);
						var salt = new byte[256];
						RNG.GetBytes(salt);
						var b = BigEndianInteger(salt);
						var g_b = BigInteger.ModPow(dh.g, b, dh_prime);
						CheckGoodGaAndGb(g_a, dh_prime);
						CheckGoodGaAndGb(g_b, dh_prime);
						var gab = BigInteger.ModPow(g_a, b, dh_prime);
						chat.flags |= SecretChat.Flags.acceptKey;
						chat.salt = gab.To256Bytes();
						chat.exchange_id = request.exchange_id;
						var key_fingerprint = BinaryPrimitives.ReadInt64LittleEndian(sha1.ComputeHash(chat.salt).AsSpan(12));
						await SendMessage(chat.ChatId, new TL.Layer23.DecryptedMessageService { random_id = Helpers.RandomLong(),
							action = new TL.Layer23.DecryptedMessageActionAcceptKey { exchange_id = request.exchange_id, g_b = g_b.To256Bytes(), key_fingerprint = key_fingerprint } });
						break;
					case TL.Layer23.DecryptedMessageActionAcceptKey accept: 
						if ((chat.flags & (SecretChat.Flags.requestChat | SecretChat.Flags.renewKey | SecretChat.Flags.acceptKey)) != SecretChat.Flags.renewKey)
							throw new WTException("Invalid AcceptKey");
						if (accept.exchange_id != chat.exchange_id)
							throw new WTException("AcceptKey: exchange_id mismatch");
						var a = BigEndianInteger(chat.salt);
						g_b = BigEndianInteger(accept.g_b);
						CheckGoodGaAndGb(g_b, dh_prime);
						gab = BigInteger.ModPow(g_b, a, dh_prime);
						var authKey = gab.To256Bytes();
						key_fingerprint = BinaryPrimitives.ReadInt64LittleEndian(sha1.ComputeHash(authKey).AsSpan(12));
						if (accept.key_fingerprint != key_fingerprint)
							throw new WTException("AcceptKey: key_fingerprint mismatch");
						_ = SendMessage(chat.ChatId, new TL.Layer23.DecryptedMessageService { random_id = Helpers.RandomLong(),
							action = new TL.Layer23.DecryptedMessageActionCommitKey { exchange_id = accept.exchange_id, key_fingerprint = accept.key_fingerprint } });
						chat.salt = chat.authKey; // A may only discard the previous key after a message encrypted with the new key has been received.
						SetAuthKey(chat, authKey);
						chat.flags = chat.flags & ~SecretChat.Flags.renewKey | SecretChat.Flags.commitKey;
						break;
					case TL.Layer23.DecryptedMessageActionCommitKey commit: 
						if ((chat.flags & (SecretChat.Flags.requestChat | SecretChat.Flags.renewKey | SecretChat.Flags.acceptKey)) != SecretChat.Flags.acceptKey)
							throw new WTException("Invalid RequestKey");
						key_fingerprint = BinaryPrimitives.ReadInt64LittleEndian(sha1.ComputeHash(chat.salt).AsSpan(12));
						if (commit.exchange_id != chat.exchange_id | commit.key_fingerprint != key_fingerprint)
							throw new WTException("CommitKey: data mismatch");
						chat.flags &= ~SecretChat.Flags.acceptKey;
						authKey = chat.authKey;
						SetAuthKey(chat, chat.salt);
						Array.Clear(authKey, 0, authKey.Length); // the old key must be securely discarded
						await SendMessage(chat.ChatId, new TL.Layer23.DecryptedMessageService { random_id = Helpers.RandomLong(),
							action = new TL.Layer23.DecryptedMessageActionNoop() });
						break;
					case TL.Layer23.DecryptedMessageActionAbortKey abort:
						if ((chat.flags & (SecretChat.Flags.renewKey | SecretChat.Flags.acceptKey)) == 0 ||
							chat.flags.HasFlag(SecretChat.Flags.commitKey) || abort.exchange_id != chat.exchange_id)
							return;
						chat.flags &= ~(SecretChat.Flags.renewKey | SecretChat.Flags.acceptKey);
						Array.Clear(chat.salt, 0, chat.salt.Length);
						chat.exchange_id = 0;
						break;
				}
			}
			catch (Exception ex)
			{
				Helpers.Log(4, $"Error handling {action}: {ex}");
				_ = Discard(chat.ChatId);
			}
		}

		/// <summary>Upload a file to Telegram in encrypted form</summary>
		/// <param name="stream">Content of the file to upload. This method close/dispose the stream</param>
		/// <param name="media">The associated media structure that will be updated with file size and the random AES key/iv</param>
		/// <param name="progress">(optional) Callback for tracking the progression of the transfer</param>
		/// <returns>the uploaded file info that should be passed to method <see cref="SendMessage">SendMessage</see></returns>
		public async Task<InputEncryptedFileBase> UploadFile(Stream stream, DecryptedMessageMedia media, Client.ProgressCallback progress = null)
		{
			byte[] aes_key = new byte[32], aes_iv = new byte[32];
			RNG.GetBytes(aes_key);
			RNG.GetBytes(aes_iv);
			media.SizeKeyIV = (stream.Length, aes_key, aes_iv);

			using var md5 = MD5.Create();
			md5.TransformBlock(aes_key, 0, 32, null, 0);
			var res = md5.TransformFinalBlock(aes_iv, 0, 32);
			long fingerprint = BinaryPrimitives.ReadInt64LittleEndian(md5.Hash);
			fingerprint ^= fingerprint >> 32;

			using var ige = new AES_IGE_Stream(stream, aes_key, aes_iv, true);
			var inputFile = await client.UploadFileAsync(ige, null, progress);
			return inputFile.ToInputEncryptedFile((int)fingerprint);
		}

		/// <summary>Download and decrypt an encrypted file from Telegram Secret Chat into the outputStream</summary>
		/// <param name="encryptedFile">The encrypted file to download &amp; decrypt</param>
		/// <param name="media">The associated message media structure</param>
		/// <param name="outputStream">Stream to write the decrypted file content to. This method does not close/dispose the stream</param>
		/// <param name="progress">(optional) Callback for tracking the progression of the transfer</param>
		/// <returns>The mime type of the decrypted file, <see langword="null"/> if unknown</returns>
		public async Task<string> DownloadFile(EncryptedFile encryptedFile, DecryptedMessageMedia media, Stream outputStream, Client.ProgressCallback progress = null)
		{
			var (size, key, iv) = media.SizeKeyIV;
			if (key == null || iv == null) throw new ArgumentException("Media has no information about encrypted file", nameof(media));
			using var md5 = MD5.Create();
			md5.TransformBlock(key, 0, 32, null, 0);
			var res = md5.TransformFinalBlock(iv, 0, 32);
			long fingerprint = BinaryPrimitives.ReadInt64LittleEndian(md5.Hash);
			fingerprint ^= fingerprint >> 32;
			if (encryptedFile.key_fingerprint != (int)fingerprint) throw new WTException("Encrypted file fingerprint mismatch");
			
			using var decryptStream = new AES_IGE_Stream(outputStream, size, key, iv);
			var fileLocation = encryptedFile.ToFileLocation();
			await client.DownloadFileAsync(fileLocation, decryptStream, encryptedFile.dc_id, encryptedFile.size, progress);
			return media.MimeType;
		}
	}
}
