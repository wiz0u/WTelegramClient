using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TL;

namespace WTelegram
{
	public class UpdateManager
	{
		/// <summary>Collected info about Users <i>(only if using the default collector)</i></summary>
		public readonly Dictionary<long, User> Users;
		/// <summary>Collected info about Chats <i>(only if using the default collector)</i></summary>
		public readonly Dictionary<long, ChatBase> Chats;
		/// <summary>Timout to detect lack of updates and force refetch them</summary>
		public TimeSpan InactivityThreshold { get; set; } = TimeSpan.FromMinutes(15);
		/// <summary>Logging callback (defaults to WTelegram.Helpers.Log ; can be null for performance)</summary>
		public Action<int, string> Log { get; set; } = Helpers.Log;
		/// <summary>Current set of update states (for saving and later resume)</summary>
		public ImmutableDictionary<long, MBoxState> State
		{
			get
			{
				_sem.Wait();
				try { return _local.ToImmutableDictionary(); }
				finally { _sem.Release(); }
			}
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006")]
		public sealed class MBoxState { public int pts { get; set; } public long access_hash { get; set; } }

		private readonly Client _client;
		private readonly Func<Update, Task> _onUpdate;
		private readonly IPeerCollector _collector;
		private readonly bool _reentrant;
		private readonly TaskScheduler _scheduler;
		private readonly SemaphoreSlim _sem = new(1);
		private readonly List<(Update update, UpdatesBase updates, bool own, DateTime stamp)> _pending = [];
		private readonly Dictionary<long, MBoxState> _local; // -2 for seq/date, -1 for qts, 0 for common pts, >0 for channel pts
		private const int L_SEQ = -2, L_QTS = -1, L_PTS = 0;
		private const long UndefinedSeqDate = 3155378975999999999L; // DateTime.MaxValue.Ticks
		private static readonly TimeSpan HalfSec = new(TimeSpan.TicksPerSecond / 2);
		private Task _recoveringGaps;
		private DateTime _lastUpdateStamp = DateTime.UtcNow;

		/// <summary>Manager ensuring that you receive Telegram updates in correct order, without missing any</summary>
		/// <param name="client">the WTelegram Client to manage</param>
		/// <param name="onUpdate">Event to be called on sequential individual update</param>
		/// <param name="state">(optional) Resume session by recovering all updates that occured since this state</param>
		/// <param name="collector">Custom users/chats collector. By default, those are collected in properties Users/Chats</param>
		/// <param name="reentrant"><see langword="true"/> if your <paramref name="onUpdate"/> method can be called again even when last async call didn't return yet</param>
		public UpdateManager(Client client, Func<Update, Task> onUpdate, IDictionary<long, MBoxState> state = null, IPeerCollector collector = null, bool reentrant = false)
		{
			_client = client;
			_onUpdate = onUpdate;
			_collector = collector ?? new Services.CollectorPeer(Users = [], Chats = []);
			_scheduler = SynchronizationContext.Current == null ? TaskScheduler.Current : TaskScheduler.FromCurrentSynchronizationContext();

			if (state == null || state.Count < 3)
				_local = new() { [L_SEQ] = new() { access_hash = UndefinedSeqDate }, [L_QTS] = new(), [L_PTS] = new() };
			else
				_local = state as Dictionary<long, MBoxState> ?? new Dictionary<long, MBoxState>(state);
			_reentrant = reentrant;
			client.OnOther += OnOther;
			client.OnUpdates += u => OnUpdates(u, false);
			client.OnOwnUpdates += u => OnUpdates(u, true);
		}

		private async Task OnOther(IObject obj)
		{
			switch (obj)
			{
				case Pong when DateTime.UtcNow - _lastUpdateStamp > InactivityThreshold:
					if (_local[L_PTS].pts != 0) await ResyncState();
					break;
				case User user when user.flags.HasFlag(User.Flags.self):
					_collector.Collect([user]);
					goto newSession;
				case NewSessionCreated when _client.User != null:
				newSession:
					await Task.Delay(HalfSec); // let the opportunity to call DropPendingUpdates/StopResync before a big resync
					if (_local[L_PTS].pts != 0) await ResyncState();
					else await ResyncState(await _client.Updates_GetState());
					break;
				case Updates_State state:
					await ResyncState(state);
					break;
			}
		}

		private async Task ResyncState(Updates_State state = null)
		{
			if (state != null) state.qts = 0; // for some reason Updates_GetState returns an invalid qts, so better consider we have no qts.
			else state = new() { qts = int.MaxValue };
			await _sem.WaitAsync();
			try
			{
				var local = _local[L_PTS];
				Log?.Invoke(2, $"Got Updates_State {local.pts}->{state.pts}, date={new DateTime(_local[L_SEQ].access_hash, DateTimeKind.Utc)}->{state.date}, seq={_local[L_SEQ].pts}->{state.seq}");
				if (local.pts == 0 || local.pts >= state.pts && _local[L_SEQ].pts >= state.seq && _local[L_QTS].pts >= state.qts)
					await HandleDifference(null, null, state, null);
				else if (await GetDifference(L_PTS, state.pts, local))
					await ApplyFilledGaps();
			}
			finally { _sem.Release(); }
		}

		private async Task OnUpdates(UpdatesBase updates, bool own)
		{
			RaiseCollect(updates.Users, updates.Chats);
			await _sem.WaitAsync();
			try
			{
				await HandleUpdates(updates, own);
			}
			finally { _sem.Release(); }
		}

		private async Task HandleUpdates(UpdatesBase updates, bool own)
		{
			var now = _lastUpdateStamp = DateTime.UtcNow;
			var updateList = updates.UpdateList;
			if (updates is UpdateShortSentMessage sent)
				updateList = [new UpdateNewMessage { pts = sent.pts, pts_count = sent.pts_count, message = new Message {
					flags = (Message.Flags)sent.flags,
					id = sent.id, date = sent.date, entities = sent.entities, media = sent.media, ttl_period = sent.ttl_period,
				} }];
			else if (updates is UpdateShortMessage usm && !_collector.HasUser(usm.user_id))
				RaiseCollect(await _client.Updates_GetDifference(usm.pts - usm.pts_count, usm.date, 0));
			else if (updates is UpdateShortChatMessage uscm && (!_collector.HasUser(uscm.from_id) || !_collector.HasChat(uscm.chat_id)))
				RaiseCollect(await _client.Updates_GetDifference(uscm.pts - uscm.pts_count, uscm.date, 0));

			bool ptsChanged = false, gotUPts = false;
			int seq = 0;
			try
			{
				if (updates is UpdatesTooLong)
				{
					var local_pts = _local[L_PTS];
					ptsChanged = await GetDifference(L_PTS, local_pts.pts, local_pts);
					return;
				}
				foreach (var update in updateList)
				{
					if (update == null) continue;
					var (mbox_id, pts, pts_count) = update.GetMBox();
					if (pts == 0) (mbox_id, pts, pts_count) = updates.GetMBox();
					MBoxState local = null;
					if (pts != 0)
					{
						local = _local.GetOrCreate(mbox_id);
						if (mbox_id > 0 && local.access_hash == 0)
							if (updates.Chats.TryGetValue(mbox_id, out var chat) && chat is Channel channel && !channel.flags.HasFlag(Channel.Flags.min))
								local.access_hash = channel.access_hash;
						var diff = local.pts + pts_count - pts;
						if (diff > 0 && pts_count != 0) // the update was already applied, and must be ignored.
						{
							Log?.Invoke(1, $"({mbox_id,10}, {local.pts,6}+{pts_count}->{pts,-6}) {update,-30} ignored {ExtendedLog(update)}");
							continue;
						}
						if (diff < 0) // there's an update gap that must be filled.
						{
							Log?.Invoke(1, $"({mbox_id,10}, {local.pts,6}+{pts_count}->{pts,-6}) {update,-30} pending {ExtendedLog(update)}");
							_pending.Add((update, updates, own, now + HalfSec));
							_recoveringGaps ??= Task.Delay(HalfSec).ContinueWith(RecoverGaps, _scheduler);
							continue;
						}
						// the update can be applied.
					}
					Log?.Invoke(1, $"({mbox_id,10}, {local?.pts,6}+{pts_count}->{pts,-6}) {update,-30} applied {ExtendedLog(update)}");
					if (mbox_id == L_SEQ && update is UpdatePtsChanged) gotUPts = true;
					if (pts_count > 0 && pts != 0)
					{
						ptsChanged = true;
						if (mbox_id == L_SEQ)
							seq = pts;
						else if (pts_count != 0)
							local.pts = pts;
					}
					if (!own) await RaiseUpdate(update);
				}
			}
			finally
			{
				if (seq > 0) // update local_seq & date after the updates were applied
				{
					var local_seq = _local[L_SEQ];
					local_seq.pts = seq;
					local_seq.access_hash = updates.Date.Ticks;
				}
				if (gotUPts) ptsChanged = await GetDifference(L_PTS, _local[L_PTS].pts = 1, _local[L_PTS]);
				if (ptsChanged) await ApplyFilledGaps();
			}
		}

		private async Task<int> ApplyFilledGaps()
		{
			if (_pending.Count != 0) Log?.Invoke(2, $"Trying to apply {_pending.Count} pending updates after filled gaps");
			int removed = 0;
			for (int i = 0; i < _pending.Count; )
			{
				var (update, updates, own, _) = _pending[i];
				var (mbox_id, pts, pts_count) = update.GetMBox();
				if (pts == 0) (mbox_id, pts, pts_count) = updates.GetMBox();
				var local = _local[mbox_id];
				var diff = local.pts + pts_count - pts;
				if (diff < 0)
					++i; // there's still a gap, skip it
				else
				{
					_pending.RemoveAt(i);
					++removed;
					if (diff > 0) // the update was already applied, remove & ignore
						Log?.Invoke(1, $"({mbox_id,10}, {local.pts,6}+{pts_count}->{pts,-6}) {update,-30} obsolete {ExtendedLog(update)}");
					else
					{
						Log?.Invoke(1, $"({mbox_id,10}, {local.pts,6}+{pts_count}->{pts,-6}) {update,-30} applied now {ExtendedLog(update)}");
						// the update can be applied.
						local.pts = pts;
						if (mbox_id == L_SEQ) local.access_hash = updates.Date.Ticks;
						if (!own) await RaiseUpdate(update);
						i = 0; // rescan pending updates from start
					}
				}
			}
			return removed;
		}

		private async Task RecoverGaps(Task _) // https://corefork.telegram.org/api/updates#recovering-gaps
		{
			await _sem.WaitAsync();
			try
			{
				_recoveringGaps = null;
				if (_pending.Count == 0) return;
				Log?.Invoke(2, $"Trying to recover gaps for {_pending.Count} pending updates");
				var now = DateTime.UtcNow;
				while (_pending.Count != 0)
				{
					var (update, updates, own, stamp) = _pending[0];
					if (stamp > now)
					{
						_recoveringGaps = Task.Delay(stamp - now).ContinueWith(RecoverGaps, _scheduler);
						return;
					}
					var (mbox_id, pts, pts_count) = update.GetMBox();
					if (pts == 0) (mbox_id, pts, pts_count) = updates.GetMBox();
					var local = _local[mbox_id];
					bool getDiffSuccess = false;
					if (local.pts == 0)
						Log?.Invoke(2, $"({mbox_id,10},  new  +{pts_count}->{pts,-6}) {update,-30} First appearance of MBox {ExtendedLog(update)}");
					else if (local.access_hash == -1) // no valid access_hash for this channel, so just raise this update
						Log?.Invoke(3, $"({mbox_id,10}, {local.pts,6}+{pts_count}->{pts,-6}) {update,-30} No access_hash to recover {ExtendedLog(update)}");
					else if (local.pts + pts_count - pts >= 0)
						getDiffSuccess = true;
					else
					{
						Log?.Invoke(1, $"({mbox_id,10}, {local.pts,6}+{pts_count}->{pts,-6}) {update,-30} Calling GetDifference {ExtendedLog(update)}");
						getDiffSuccess = await GetDifference(mbox_id, pts, local);
					}
					if (!getDiffSuccess) // no getDiff => just raise received pending updates in order
					{
						local.pts = pts - pts_count;
						for (int i = 1; i < _pending.Count; i++) // find lowest pending pts-pts_count for this mbox
						{
							var pending = _pending[i];
							var mbox = pending.update.GetMBox();
							if (mbox.pts == 0) mbox = pending.updates.GetMBox();
							if (mbox.mbox_id == mbox_id) local.pts = Math.Min(local.pts, mbox.pts - mbox.pts_count);
						}
					}

					if (await ApplyFilledGaps() == 0)
					{
						Log?.Invoke(3, $"({mbox_id,10}, {local.pts,6}+{pts_count}->{pts,-6}) {update,-30} forcibly removed!");
						_pending.RemoveAt(0);
						local.pts = pts;
						if (!own) await RaiseUpdate(update);
					}
				}
			}
			finally { _sem.Release(); }
		}

		public async Task StopResync()
		{
			await _sem.WaitAsync();
			try
			{
				foreach (var local in _local.Values)
					local.pts = 0;
				_pending.Clear();
			}
			finally { _sem.Release(); }
		}

		private async Task<InputChannel> GetInputChannel(long channel_id, MBoxState local)
		{
			if (channel_id <= 0) return null;
			if (local?.access_hash is not null and not 0)
				return new InputChannel(channel_id, local.access_hash);
			var inputChannel = new InputChannel(channel_id, 0);
			try
			{
				var mc = await _client.Channels_GetChannels(inputChannel);
				if (mc.chats.TryGetValue(channel_id, out var chat) && chat is Channel channel)
					inputChannel.access_hash = channel.access_hash;
			}
			catch (Exception)
			{
				inputChannel.access_hash = -1; // no valid access_hash available
			}
			local ??= _local[channel_id] = new();
			local.access_hash = inputChannel.access_hash;
			return inputChannel;
		}

		private async Task<bool> GetDifference(long mbox_id, int expected_pts, MBoxState local)
		{
			try
			{
			moreDiffNeeded:
				if (mbox_id <= 0)
				{
					Log?.Invoke(0, $"Local states {string.Join(" ", _local.Select(l => $"{l.Key}:{l.Value.pts}"))}");
					var local_seq = _local[L_SEQ];
					var diff = await _client.Updates_GetDifference(_local[L_PTS].pts, qts: _local[L_QTS].pts,
						date: new DateTime(local_seq.access_hash, DateTimeKind.Utc));
					Log?.Invoke(1, $"{diff.GetType().Name[8..]}: {diff.NewMessages.Length} msg, {diff.OtherUpdates.Length} upd, pts={diff.State?.pts}, date={diff.State?.date}, seq={diff.State?.seq}, msgIDs={string.Join(" ", diff.NewMessages.Select(m => m.ID))}");
					switch (diff)
					{
						case Updates_Difference ud:
							await HandleDifference(ud.new_messages, ud.new_encrypted_messages, ud.state,
								new UpdatesCombined { updates = ud.other_updates, users = ud.users, chats = ud.chats,
									date = ud.state.date, seq_start = local_seq.pts + 1, seq = ud.state.seq });
							break;
						case Updates_DifferenceSlice uds:
							await HandleDifference(uds.new_messages, uds.new_encrypted_messages, uds.intermediate_state,
								new UpdatesCombined { updates = uds.other_updates, users = uds.users, chats = uds.chats,
									date = uds.intermediate_state.date, seq_start = local_seq.pts + 1, seq = uds.intermediate_state.seq });
							goto moreDiffNeeded;
						case Updates_DifferenceTooLong udtl:
							_local[L_PTS].pts = udtl.pts;
							goto moreDiffNeeded;
						case Updates_DifferenceEmpty ude:
							local_seq.pts = ude.seq;
							local_seq.access_hash = ude.date.Ticks;
							_lastUpdateStamp = DateTime.UtcNow;
							break;
					}
				}
				else
				{
					var channel = await GetInputChannel(mbox_id, local);
					if (channel.access_hash == -1) return false;
					try
					{
						var diff = await _client.Updates_GetChannelDifference(channel, null, local.pts);
						Log?.Invoke(1, $"{diff.GetType().Name[8..]}({mbox_id}): {diff.NewMessages.Length} msg, {diff.OtherUpdates.Length} upd, pts={diff.Pts}, msgIDs={string.Join(" ", diff.NewMessages.Select(m => m.ID))}");
						switch (diff)
						{
							case Updates_ChannelDifference ucd:
								local.pts = ucd.pts;
								await HandleDifference(ucd.new_messages, null, null,
									new UpdatesCombined { updates = ucd.other_updates, users = ucd.users, chats = ucd.chats });
								if (!ucd.flags.HasFlag(Updates_ChannelDifference.Flags.final)) goto moreDiffNeeded;
								break;
							case Updates_ChannelDifferenceTooLong ucdtl:
								if (ucdtl.dialog is Dialog dialog) local.pts = dialog.pts;
								await HandleDifference(ucdtl.messages, null, null,
									new UpdatesCombined { updates = null, users = ucdtl.users, chats = ucdtl.chats });
								break;
							case Updates_ChannelDifferenceEmpty ucde:
								local.pts = ucde.pts;
								break;
						}
					}
					catch (RpcException ex) when (ex.Message is "CHANNEL_PRIVATE" or "CHANNEL_INVALID")
					{
						local.access_hash = -1; // access_hash is no longer valid
						throw;
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				Log?.Invoke(4, $"GetDifference({mbox_id}, {local.pts}->{expected_pts}) raised {ex}");
				if (ex.Message == "PERSISTENT_TIMESTAMP_INVALID") // oh boy, we're lost!
					if (mbox_id <= 0)
						await HandleDifference(null, null, await _client.Updates_GetState(), null);
					else if ((await _client.Channels_GetFullChannel(await GetInputChannel(mbox_id, local))).full_chat is ChannelFull full)
						local.pts = full.pts;
			}
			finally
			{
				if (local.pts < expected_pts) local.pts = expected_pts;
			}
			return false;
		}

		private async Task HandleDifference(MessageBase[] new_messages, EncryptedMessageBase[] enc_messages, Updates_State state, UpdatesCombined updates)
		{
			if (updates != null)
				RaiseCollect(updates.users, updates.chats);
			try
			{
				int updatesCount = updates?.updates.Length ?? 0;
				if (updatesCount != 0)
					for (int i = 0; i < updates.updates.Length; i++)
					{
						var update = updates.updates[i];
						if (update is UpdateMessageID or UpdateStoryID)
						{
							await RaiseUpdate(update);
							updates.updates[i] = null;
							--updatesCount;
						}
					}
				if (new_messages?.Length > 0)
				{
					var update = state == null ? new UpdateNewChannelMessage() : new UpdateNewMessage() { pts = state.pts, pts_count = 1 };
					foreach (var msg in new_messages)
					{
						if (_pending.Any(p => p is { own: true, update: UpdateNewMessage { message: { Peer.ID: var peer_id, ID: var msg_id } } }
							&& peer_id == msg.Peer.ID && msg_id == msg.ID))
							continue;
						update.message = msg;
						await RaiseUpdate(update);
					}
				}
				if (enc_messages?.Length > 0)
				{
					var update = new UpdateNewEncryptedMessage();
					if (state != null) update.qts = state.qts;
					foreach (var msg in enc_messages)
					{
						if (_pending.Any(p => p is { own: true, update: UpdateNewEncryptedMessage { message: { ChatId: var chat_id, RandomId: var random_id } } }
							&& chat_id == msg.ChatId && random_id == msg.RandomId))
							continue;
						update.message = msg;
						await RaiseUpdate(update);
					}
				}
				if (updatesCount != 0)
				{
					// try to remove matching pending OwnUpdates from this updates list (starting from most-recent)
					for (int p = _pending.Count - 1, u = updates.updates.Length; p >= 0 && u > 0; p--)
					{
						if (_pending[p].own == false) continue;
						var updateP = _pending[p].update;
						var (mbox_idP, ptsP, pts_countP) = updateP.GetMBox();
						if (ptsP == 0) (mbox_idP, ptsP, pts_countP) = _pending[p].updates.GetMBox();
						Type updatePtype = null;
						while (--u >= 0)
						{
							var update = updates.updates[u];
							if (update == null) continue;
							var (mbox_id, pts, pts_count) = update.GetMBox();
							if (pts == 0) (mbox_id, pts, pts_count) = updates.GetMBox();
							if (mbox_idP == mbox_id && ptsP <= pts)
							{
								updatePtype ??= updateP.GetType();
								if (updatePtype == (update is UpdateDeleteMessages ? typeof(UpdateAffectedMessages) : update.GetType()))
								{
									updates.updates[u] = null;
									--updatesCount;
									break;
								}
							}
						}
					}
					if (updatesCount != 0)
						await HandleUpdates(updates, false);
				}
			}
			finally
			{
				if (state != null)
				{
					_local[L_PTS].pts = state.pts;
					_local[L_QTS].pts = state.qts;
					var local_seq = _local[L_SEQ];
					local_seq.pts = state.seq;
					local_seq.access_hash = state.date.Ticks;
				}
			}
		}

		private void RaiseCollect(Updates_DifferenceBase diff)
		{
			if (diff is Updates_DifferenceSlice uds)
				RaiseCollect(uds.users, uds.chats);
			else if (diff is Updates_Difference ud)
				RaiseCollect(ud.users, ud.chats);
		}

		private void RaiseCollect(Dictionary<long, User> users, Dictionary<long, ChatBase> chats)
		{
			try
			{
				foreach (var chat in chats.Values)
					if (chat is Channel channel && !channel.flags.HasFlag(Channel.Flags.min))
						if (_local.TryGetValue(channel.id, out var local))
							local.access_hash = channel.access_hash;
				_collector.Collect(users.Values);
				_collector.Collect(chats.Values);
			}
			catch (Exception ex)
			{
				Log?.Invoke(4, $"Collect({users?.Count},{chats?.Count}) raised {ex}");
			}
		}

		private async Task RaiseUpdate(Update update)
		{
			try
			{
				var task = _onUpdate(update);
				if (!_reentrant) await task;
			}
			catch (Exception ex)
			{
				Log?.Invoke(4, $"onUpdate({update?.GetType().Name}) raised {ex}");
			}
		}

		private static string ExtendedLog(Update update) => update switch
		{
			UpdateNewMessage unm => $"| msgID={unm.message.ID}",
			UpdateEditMessage uem => $"| msgID={uem.message.ID}",
			UpdateDeleteMessages udm => $"| count={udm.messages.Length}",
			_ => null
		};

		/// <summary>Load latest dialogs states, checking for missing updates</summary>
		/// <param name="dialogs">structure returned by Messages_Get*Dialogs calls</param>
		/// <param name="fullLoadNewChans">Dangerous! Load full history of unknown new channels as updates</param>
		public async Task LoadDialogs(Messages_Dialogs dialogs, bool fullLoadNewChans = false)
		{
			await _sem.WaitAsync();
			try
			{
				foreach (var dialog in dialogs.dialogs.OfType<Dialog>())
				{
					if (dialog.peer is not PeerChannel pc) continue;
					var local = _local.GetOrCreate(pc.channel_id);
					if (dialogs.chats.TryGetValue(pc.channel_id, out var chat) && chat is Channel channel)
						local.access_hash = channel.access_hash;
					if (local.pts is 0)
						if (fullLoadNewChans) local.pts = 1;
						else local.pts = dialog.pts;
					if (local.pts < dialog.pts)
					{
						Log?.Invoke(1, $"LoadDialogs {pc.channel_id} has {local.pts} < {dialog.pts} ({dialog.folder_id})");
						await GetDifference(pc.channel_id, dialog.pts, local);
					}
				}
			}
			finally { _sem.Release(); }
		}

		/// <summary>Save the current state of the manager to JSON file</summary>
		/// <param name="statePath">File path to write</param>
		/// <remarks>Note: This does not save the content of collected Users/Chats dictionaries</remarks>
		public void SaveState(string statePath)
			=> System.IO.File.WriteAllText(statePath, System.Text.Json.JsonSerializer.Serialize(State, Helpers.JsonOptions));
		public static Dictionary<long, MBoxState> LoadState(string statePath) => !System.IO.File.Exists(statePath) ? null
			: System.Text.Json.JsonSerializer.Deserialize<Dictionary<long, MBoxState>>(System.IO.File.ReadAllText(statePath), Helpers.JsonOptions);
		/// <summary>returns a <see cref="User"/> or <see cref="ChatBase"/> for the given Peer <i>(only if using the default collector)</i></summary>
		public IPeerInfo UserOrChat(Peer peer) => peer?.UserOrChat(Users, Chats);
	}

	public interface IPeerCollector
	{
		void Collect(IEnumerable<User> users);
		void Collect(IEnumerable<ChatBase> chats);
		bool HasUser(long id);
		bool HasChat(long id);
	}
}

namespace TL
{
	using WTelegram;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class UpdateManagerExtensions
	{
		/// <summary>Manager ensuring that you receive Telegram updates in correct order, without missing any</summary>
		/// <param name="onUpdate">Event to be called on sequential individual update</param>
		/// <param name="statePath">Resume session by recovering all updates that occured since the state saved in this file</param>
		/// <param name="collector">Custom users/chats collector. By default, those are collected in properties Users/Chats</param>
		/// <param name="reentrant"><see langword="true"/> if your <paramref name="onUpdate"/> method can be called again even when last async call didn't return yet</param>
		public static UpdateManager WithUpdateManager(this Client client, Func<TL.Update, Task> onUpdate, string statePath, IPeerCollector collector = null, bool reentrant = false)
			=> new(client, onUpdate, UpdateManager.LoadState(statePath), collector, reentrant);

		/// <summary>Manager ensuring that you receive Telegram updates in correct order, without missing any</summary>
		/// <param name="onUpdate">Event to be called on sequential individual update</param>
		/// <param name="state">(optional) Resume session by recovering all updates that occured since this state</param>
		/// <param name="collector">Custom users/chats collector. By default, those are collected in properties Users/Chats</param>
		/// <param name="reentrant"><see langword="true"/> if your <paramref name="onUpdate"/> method can be called again even when last async call didn't return yet</param>
		public static UpdateManager WithUpdateManager(this Client client, Func<TL.Update, Task> onUpdate, IDictionary<long, UpdateManager.MBoxState> state = null, IPeerCollector collector = null, bool reentrant = false)
			=> new(client, onUpdate, state, collector, reentrant);
	}
}