using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WTelegram;

namespace TL
{
	public static class Services
	{
		public sealed partial class CollectorPeer(IDictionary<long, User> _users, IDictionary<long, ChatBase> _chats) : Peer, IPeerCollector
		{
			public override long ID => 0;
			protected internal override IPeerInfo UserOrChat(Dictionary<long, User> users, Dictionary<long, ChatBase> chats)
			{
				if (users != null) Collect(users.Values);
				if (chats != null) Collect(chats.Values);
				return null;
			}

			public void Collect(IEnumerable<TL.User> users)
			{
				lock (_users)
					foreach (var user in users)
						if (user != null)
							if (!user.flags.HasFlag(User.Flags.min) || !_users.TryGetValue(user.id, out var prevUser) || prevUser.flags.HasFlag(User.Flags.min))
								_users[user.id] = user;
							else
							{   // update previously full user from min user:
								// see https://github.com/tdlib/td/blob/master/td/telegram/UserManager.cpp#L2689
								// and https://github.com/telegramdesktop/tdesktop/blob/dev/Telegram/SourceFiles/data/data_session.cpp#L515
								const User.Flags updated_flags = User.Flags.deleted | User.Flags.bot | User.Flags.bot_chat_history |
									User.Flags.bot_nochats | User.Flags.verified | User.Flags.restricted | User.Flags.has_bot_inline_placeholder |
									User.Flags.bot_inline_geo | User.Flags.support | User.Flags.scam | User.Flags.fake | User.Flags.bot_attach_menu |
									User.Flags.premium | User.Flags.has_emoji_status;
								const User.Flags2 updated_flags2 = User.Flags2.has_usernames | User.Flags2.stories_unavailable |
									User.Flags2.has_color | User.Flags2.has_profile_color | User.Flags2.contact_require_premium |
									User.Flags2.bot_business | User.Flags2.bot_has_main_app | User.Flags2.bot_forum_view;
								// tdlib updated flags: deleted | bot | bot_chat_history | bot_nochats | verified | bot_inline_geo
								//  | support | scam | fake | bot_attach_menu | premium
								// tdesktop non-updated flags:    bot | bot_chat_history | bot_nochats | bot_attach_menu
								// updated flags2:    stories_unavailable | main_app | bot_business | bot_forum_view (tdlib) | contact_require_premium (tdesktop)
								prevUser.flags = (prevUser.flags & ~updated_flags) | (user.flags & updated_flags);
								prevUser.flags2 = (prevUser.flags2 & ~updated_flags2) | (user.flags2 & updated_flags2);
								prevUser.first_name ??= user.first_name;				// tdlib: not updated ; tdesktop: updated only if unknown
								prevUser.last_name ??= user.last_name;					// tdlib: not updated ; tdesktop: updated only if unknown
								//prevUser.username ??= user.username;					// tdlib/tdesktop: not updated
								prevUser.phone ??= user.phone;							// tdlib: updated only if unknown ; tdesktop: not updated
								if (prevUser.flags.HasFlag(User.Flags.apply_min_photo) && user.photo != null)
								{
									prevUser.photo = user.photo;						// tdlib/tdesktop: updated on apply_min_photo
									prevUser.flags |= User.Flags.has_photo;
								}
								prevUser.bot_info_version = user.bot_info_version;		// tdlib: updated ; tdesktop: not updated
								prevUser.restriction_reason = user.restriction_reason;	// tdlib: updated ; tdesktop: not updated
								prevUser.bot_inline_placeholder = user.bot_inline_placeholder;// tdlib: updated ; tdesktop: ignored
								if (user.lang_code != null)
									prevUser.lang_code = user.lang_code;				// tdlib: updated if present ; tdesktop: ignored
								prevUser.emoji_status = user.emoji_status;				// tdlib/tdesktop: updated
								//prevUser.usernames = user.usernames;					// tdlib/tdesktop: not updated
								if (user.stories_max_id != null)
									prevUser.stories_max_id = user.stories_max_id;		// tdlib: updated if > 0 ; tdesktop: not updated
								prevUser.color = user.color;							// tdlib/tdesktop: updated
								prevUser.profile_color = user.profile_color;			// tdlib/tdesktop: unimplemented yet
								_users[user.id] = prevUser;
							}
			}

			public void Collect(IEnumerable<ChatBase> chats)
			{
				lock (_chats)
					foreach (var chat in chats)
						if (chat is not Channel channel)
							_chats[chat.ID] = chat;
						else if (!_chats.TryGetValue(channel.id, out var prevChat) || prevChat is not Channel prevChannel)
							_chats[channel.id] = channel;
						else if (!channel.flags.HasFlag(Channel.Flags.min) || prevChannel.flags.HasFlag(Channel.Flags.min))
						{
							if (channel.participants_count == 0) channel.participants_count = prevChannel.participants_count; // non-min channel can lack this info
							_chats[channel.id] = channel;
						}
						else
						{   // update previously full channel from min channel:
							const Channel.Flags updated_flags = (Channel.Flags)0x7FDC0BE0;
							const Channel.Flags2 updated_flags2 = (Channel.Flags2)0x781;
							// tdesktop updated flags: broadcast | verified | megagroup | signatures | scam | has_link | slowmode_enabled
							//	| call_active | call_not_empty | fake | gigagroup | noforwards | join_to_send | join_request | forum
							// tdlib nonupdated flags: broadcast | signatures | call_active | call_not_empty | noforwards
							prevChannel.flags = (prevChannel.flags & ~updated_flags) | (channel.flags & updated_flags);
							prevChannel.flags2 = (prevChannel.flags2 & ~updated_flags2) | (channel.flags2 & updated_flags2);
							prevChannel.title = channel.title;                                  // tdlib/tdesktop: updated
							prevChannel.username = channel.username;                            // tdlib/tdesktop: updated
							prevChannel.photo = channel.photo;                                  // tdlib: updated if not banned ; tdesktop: updated
							prevChannel.restriction_reason = channel.restriction_reason;        // tdlib: updated ; tdesktop: not updated
							prevChannel.default_banned_rights = channel.default_banned_rights;  // tdlib/tdesktop: updated
							if (channel.participants_count > 0)
								prevChannel.participants_count = channel.participants_count;    // tdlib/tdesktop: updated if present
							prevChannel.usernames = channel.usernames;                          // tdlib/tdesktop: updated
							prevChannel.color = channel.color;                                  // tdlib: not updated ; tdesktop: updated
							prevChannel.profile_color = channel.profile_color;                  // tdlib/tdesktop: ignored
							prevChannel.emoji_status = channel.emoji_status;                    // tdlib: not updated ; tdesktop: updated
							prevChannel.level = channel.level;                                  // tdlib: not updated ; tdesktop: updated
							_chats[channel.id] = prevChannel;
						}
			}

			public bool HasUser(long id) { lock (_users) return _users.ContainsKey(id); }
			public bool HasChat(long id) { lock (_chats) return _chats.ContainsKey(id); }
		}

		/// <summary>Accumulate users/chats found in this structure in your dictionaries, ignoring <see href="https://core.telegram.org/api/min">Min constructors</see> when the full object is already stored</summary>
		/// <param name="structure">The structure having a <c>users</c></param>
		public static void CollectUsersChats(this IPeerResolver structure, IDictionary<long, User> users, IDictionary<long, ChatBase> chats)
			=>  structure.UserOrChat(new CollectorPeer(users, chats));

		[EditorBrowsable(EditorBrowsableState.Never)][Obsolete("The method you're looking for is Messages_GetAllChats", true)]
		public static Task<Messages_Chats> Messages_GetChats(this Client _) => throw new WTException("The method you're looking for is Messages_GetAllChats");
		[EditorBrowsable(EditorBrowsableState.Never)][Obsolete("The method you're looking for is Messages_GetAllChats", true)]
		public static Task<Messages_Chats> Channels_GetChannels(this Client _) => throw new WTException("The method you're looking for is Messages_GetAllChats");
		[EditorBrowsable(EditorBrowsableState.Never)][Obsolete("The method you're looking for is Messages_GetAllDialogs", true)]
		public static Task<UserBase[]> Users_GetUsers(this Client _) => throw new WTException("The method you're looking for is Messages_GetAllDialogs");
		[EditorBrowsable(EditorBrowsableState.Never)][Obsolete("If you want to get all messages from a chat, use method Messages_GetHistory", true)]
		public static Task<Messages_MessagesBase> Messages_GetMessages(this Client _) => throw new WTException("If you want to get all messages from a chat, use method Messages_GetHistory");
	}

	public static class Markdown
	{
		/// <summary>Converts a <a href="https://core.telegram.org/bots/api/#markdownv2-style">Markdown text</a> into the (plain text + entities) format used by Telegram messages</summary>
		/// <param name="_">not used anymore, you can pass null</param>
		/// <param name="text">[in] The Markdown text<br/>[out] The same (plain) text, stripped of all Markdown notation</param>
		/// <param name="premium">Generate premium entities if any</param>
		/// <param name="users">Dictionary used for <c>tg://user?id=</c> notation</param>
		/// <returns>The array of formatting entities that you can pass (along with the plain text) to <see cref="Client.SendMessageAsync">SendMessageAsync</see> or  <see cref="Client.SendMediaAsync">SendMediaAsync</see></returns>
		public static MessageEntity[] MarkdownToEntities(this Client _, ref string text, bool premium = false, IReadOnlyDictionary<long, User> users = null)
		{
			var entities = new List<MessageEntity>();
			MessageEntityBlockquote lastBlockQuote = null;
			int offset, inCode = 0;
			var sb = new StringBuilder(text);
			for (offset = 0; offset < sb.Length;)
			{
				switch (sb[offset])
				{
					case '\r': sb.Remove(offset, 1); break;
					case '\\': sb.Remove(offset++, 1); break;
					case '*' when inCode == 0: ProcessEntity<MessageEntityBold>(); break;
					case '~' when inCode == 0: ProcessEntity<MessageEntityStrike>(); break;
					case '_' when inCode == 0:
						if (offset + 1 < sb.Length && sb[offset + 1] == '_')
						{
							sb.Remove(offset, 1);
							ProcessEntity<MessageEntityUnderline>();
						}
						else
							ProcessEntity<MessageEntityItalic>();
						break;
					case '|':
						if (inCode == 0 && offset + 1 < sb.Length && sb[offset + 1] == '|')
						{
							sb.Remove(offset, 1);
							ProcessEntity<MessageEntitySpoiler>();
						}
						else
							offset++;
						break;
					case '`':
						int count = entities.Count;
						if (offset + 2 < sb.Length && sb[offset + 1] == '`' && sb[offset + 2] == '`')
						{
							int len = 3;
							if (entities.FindLast(e => e.length == -1) is MessageEntityPre pre)
								pre.length = offset - pre.offset;
							else
							{
								while (offset + len < sb.Length && !char.IsWhiteSpace(sb[offset + len]))
									len++;
								entities.Add(new MessageEntityPre { offset = offset, length = -1, language = sb.ToString(offset + 3, len - 3) });
								if (sb[offset + len] == '\n') len++;
							}
							sb.Remove(offset, len);
						}
						else
							ProcessEntity<MessageEntityCode>();
						if (entities.Count > count) inCode++; else inCode--;
						break;
					case '>' when inCode == 0 && offset == 0 || sb[offset - 1] == '\n':
						sb.Remove(offset, 1);
						if (lastBlockQuote == null)
							entities.Add(lastBlockQuote = new MessageEntityBlockquote { offset = offset, length = -1 });
						break;
					case '\n' when lastBlockQuote != null:
						if (offset + 1 >= sb.Length || sb[offset + 1] != '>') CloseBlockQuote();
						offset++;
						break;
					case '!' when inCode == 0 && offset + 1 < sb.Length && sb[offset + 1] == '[':
						sb.Remove(offset, 1);
						break;
					case '[' when inCode == 0:
						entities.Add(new MessageEntityTextUrl { offset = offset, length = -1 });
						sb.Remove(offset, 1);
						break;
					case ']':
						if (inCode == 0 && offset + 2 < sb.Length && sb[offset + 1] == '(')
						{
							var lastIndex = entities.FindLastIndex(e => e.length == -1);
							if (lastIndex >= 0 && entities[lastIndex] is MessageEntityTextUrl textUrl)
							{
								textUrl.length = offset - textUrl.offset;
								int offset2 = offset + 2;
								while (offset2 < sb.Length)
								{
									char c = sb[offset2++];
									if (c == '\\') sb.Remove(offset2 - 1, 1);
									else if (c == ')') break;
								}
								textUrl.url = sb.ToString(offset + 2, offset2 - offset - 3);
								if (textUrl.url.StartsWith("tg://user?id=") && long.TryParse(textUrl.url[13..], out var id) && users?.GetValueOrDefault(id)?.access_hash is long hash)
									entities[lastIndex] = new InputMessageEntityMentionName { offset = textUrl.offset, length = textUrl.length, user_id = new InputUser(id, hash) };
								else if ((textUrl.url.StartsWith("tg://emoji?id=") || textUrl.url.StartsWith("emoji?id=")) && long.TryParse(textUrl.url[(textUrl.url.IndexOf('=') + 1)..], out id))
									if (premium) entities[lastIndex] = new MessageEntityCustomEmoji { offset = textUrl.offset, length = textUrl.length, document_id = id };
									else entities.RemoveAt(lastIndex);
								sb.Remove(offset, offset2 - offset);
								break;
							}
						}
						offset++;
						break;
					default: offset++; break;
				}

				void ProcessEntity<T>() where T : MessageEntity, new()
				{
					sb.Remove(offset, 1);
					if (entities.LastOrDefault(e => e.length == -1) is T prevEntity)
						if (offset == prevEntity.offset)
							entities.Remove(prevEntity);
						else
							prevEntity.length = offset - prevEntity.offset;
					else
						entities.Add(new T { offset = offset, length = -1 });
				}
			}
			if (lastBlockQuote != null) CloseBlockQuote();
			HtmlText.FixUps(sb, entities);
			text = sb.ToString();
			return entities.Count == 0 ? null : [.. entities];

			void CloseBlockQuote()
			{
				if (entities[^1] is MessageEntitySpoiler { length: -1 } mes && mes.offset == offset)
				{
					entities.RemoveAt(entities.Count - 1);
					lastBlockQuote.flags = MessageEntityBlockquote.Flags.collapsed;
				}
				lastBlockQuote.length = offset - lastBlockQuote.offset;
				lastBlockQuote = null;
			}
		}

		/// <summary>Converts the (plain text + entities) format used by Telegram messages into a <a href="https://core.telegram.org/bots/api/#markdownv2-style">Markdown text</a></summary>
		/// <param name="client">Client, used only for getting current user ID in case of <c>InputMessageEntityMentionName+InputUserSelf</c></param>
		/// <param name="message">The plain text, typically obtained from <see cref="Message.message"/></param>
		/// <param name="entities">The array of formatting entities, typically obtained from <see cref="Message.entities"/></param>
		/// <param name="premium">Convert premium entities (might lead to non-standard markdown)</param>
		/// <returns>The message text with MarkdownV2 formattings</returns>
		public static string EntitiesToMarkdown(this Client client, string message, MessageEntity[] entities, bool premium = false)
		{
			if (entities == null || entities.Length == 0) return Escape(message);
			var closings = new List<(int offset, string md)>();
			var sb = new StringBuilder(message);
			int entityIndex = 0;
			var nextEntity = entities[entityIndex];
			bool inBlockQuote = false;
			char lastCh = '\0';
			for (int offset = 0, i = 0; ; offset++, i++)
			{
				while (closings.Count != 0 && offset == closings[0].offset)
				{
					var md = closings[0].md;
					closings.RemoveAt(0);
					if (i > 0 && md[0] == '_' && sb[i - 1] == '_') md = '\r' + md;
					if (md[0] == '>') { inBlockQuote = false; md = md[1..]; if (lastCh != '\n' && i < sb.Length && sb[i] != '\n') md += '\n'; }
					sb.Insert(i, md); i += md.Length;
				}
				if (i == sb.Length) break;
				if (lastCh == '\n' && inBlockQuote) sb.Insert(i++, '>');
				for (; offset == nextEntity?.offset; nextEntity = ++entityIndex < entities.Length ? entities[entityIndex] : null)
				{
					if (EntityToMD.TryGetValue(nextEntity.GetType(), out var md))
					{
						var closing = (nextEntity.offset + nextEntity.length, md);
						if (md[0] is '[' or '!')
						{
							if (nextEntity is MessageEntityTextUrl metu)
								closing.md = $"]({metu.url.Replace("\\", "\\\\").Replace(")", "\\)").Replace(">", "%3E")})";
							else if (nextEntity is MessageEntityMentionName memn)
								closing.md = $"](tg://user?id={memn.user_id})";
							else if (nextEntity is InputMessageEntityMentionName imemn)
								closing.md = $"](tg://user?id={imemn.user_id.UserId ?? client.UserId})";
							else if (nextEntity is MessageEntityCustomEmoji mecu)
								if (premium) closing.md = $"](tg://emoji?id={mecu.document_id})";
								else continue;
						}
						else if (nextEntity is MessageEntityBlockquote mebq)
						{ inBlockQuote = true; if (lastCh is not '\n' and not '\0') md = "\n>";
						  if (mebq.flags == MessageEntityBlockquote.Flags.collapsed) closing.md = ">||"; }
						else if (nextEntity is MessageEntityPre mep)
							md = $"```{mep.language}\n";
						int index = ~closings.BinarySearch(closing, Comparer<(int, string)>.Create((x, y) => x.Item1.CompareTo(y.Item1) | 1));
						closings.Insert(index, closing);
						if (i > 0 && md[0] == '_' && sb[i - 1] == '_') md = '\r' + md;
						sb.Insert(i, md); i += md.Length;
					}
				}
				switch (lastCh = sb[i])
				{
					case '_': case '*': case '~': case '#': case '+': case '-': case '=': case '.': case '!':
					case '[': case ']': case '(': case ')': case '{': case '}': case '>': case '|': case '\\':
						if (closings.Count != 0 && closings[0].md[0] == '`') break;
						goto case '`';
					case '`':
						sb.Insert(i++, '\\');
						break;
				}
			}
			return sb.ToString();
		}

		static readonly Dictionary<Type, string> EntityToMD = new()
		{
			[typeof(MessageEntityBold)] = "*",
			[typeof(MessageEntityItalic)] = "_",
			[typeof(MessageEntityCode)] = "`",
			[typeof(MessageEntityPre)] = "```",
			[typeof(MessageEntityTextUrl)] = "[",
			[typeof(MessageEntityMentionName)] = "[",
			[typeof(InputMessageEntityMentionName)] = "[",
			[typeof(MessageEntityUnderline)] = "__",
			[typeof(MessageEntityStrike)] = "~",
			[typeof(MessageEntitySpoiler)] = "||",
			[typeof(MessageEntityCustomEmoji)] = "![",
			[typeof(MessageEntityBlockquote)] = ">",
		};

		/// <summary>Insert backslashes in front of Markdown reserved characters</summary>
		/// <param name="text">The text to escape</param>
		/// <returns>The escaped text, ready to be used in <see cref="MarkdownToEntities">MarkdownToEntities</see> without problems</returns>
		public static string Escape(string text)
		{
			if (text == null) return null;
			StringBuilder sb = null;
			for (int index = 0, added = 0; index < text.Length; index++)
			{
				switch (text[index])
				{
					case '_': case '*': case '~': case '`': case '#': case '+': case '-': case '=': case '.': case '!':
					case '[': case ']': case '(': case ')': case '{': case '}': case '>': case '|': case '\\':
						sb ??= new StringBuilder(text, text.Length + 32);
						sb.Insert(index + added++, '\\');
						break;
				}
			}
			return sb?.ToString() ?? text;
		}
	}

	public static class HtmlText
	{
		/// <summary>Converts an <a href="https://core.telegram.org/bots/api/#html-style">HTML-formatted text</a> into the (plain text + entities) format used by Telegram messages</summary>
		/// <param name="_">not used anymore, you can pass null</param>
		/// <param name="text">[in] The HTML-formatted text<br/>[out] The same (plain) text, stripped of all HTML tags</param>
		/// <param name="premium">Generate premium entities if any</param>
		/// <param name="users">Dictionary used for <c>tg://user?id=</c> notation</param>
		/// <returns>The array of formatting entities that you can pass (along with the plain text) to <see cref="Client.SendMessageAsync">SendMessageAsync</see> or  <see cref="Client.SendMediaAsync">SendMediaAsync</see></returns>
		public static MessageEntity[] HtmlToEntities(this Client _, ref string text, bool premium = false, IReadOnlyDictionary<long, User> users = null)
		{
			var entities = new List<MessageEntity>();
			var sb = new StringBuilder(text);
			int end;
			for (int offset = 0; offset < sb.Length;)
			{
				char c = sb[offset];
				if (c == '&')
				{
					end = offset + 1;
					if (end < sb.Length && sb[end] == '#') end++;
					while (end < sb.Length && sb[end] is >= 'a' and <= 'z' or >= 'A' and <= 'Z' or >= '0' and <= '9') end++;
					var html = HttpUtility.HtmlDecode(end >= sb.Length || sb[end] != ';'
						? sb.ToString(offset, end - offset) + ";" : sb.ToString(offset, ++end - offset));
					if (html.Length == 1)
					{
						sb[offset] = html[0];
						sb.Remove(++offset, end - offset);
					}
					else
						offset = end;
				}
				else if (c == '<')
				{
					for (end = ++offset; end < sb.Length; end++)
						if (sb[end] == '>') break;
					if (end >= sb.Length) break;
					bool closing = sb[offset] == '/';
					var tag = closing ? sb.ToString(offset + 1, end - offset - 1) : sb.ToString(offset, end - offset);
					sb.Remove(--offset, end + 1 - offset);
					switch (tag)
					{
						case "b": case "strong": ProcessEntity<MessageEntityBold>(); break;
						case "i": case "em": ProcessEntity<MessageEntityItalic>(); break;
						case "u": case "ins": ProcessEntity<MessageEntityUnderline>(); break;
						case "s": case "strike": case "del": ProcessEntity<MessageEntityStrike>(); break;
						case "span class=\"tg-spoiler\"":
						case "span class='tg-spoiler'":
						case "span" when closing:
						case "tg-spoiler": ProcessEntity<MessageEntitySpoiler>(); break;
						case "code": ProcessEntity<MessageEntityCode>(); break;
						case "pre": ProcessEntity<MessageEntityPre>(); break;
						case "tg-emoji" when closing: ProcessEntity<MessageEntityCustomEmoji>(); break;
						case "blockquote": ProcessEntity<MessageEntityBlockquote>(); break;
						case "blockquote expandable": 
							entities.Add(new MessageEntityBlockquote { offset = offset, length = -1, flags = MessageEntityBlockquote.Flags.collapsed });
							break;
						default:
							if (closing)
							{
								if (tag == "a")
								{
									var prevEntity = entities.LastOrDefault(e => e.length == -1);
									if (prevEntity is InputMessageEntityMentionName or MessageEntityTextUrl)
										prevEntity.length = offset - prevEntity.offset;
								}
							}
							else if ((tag[^1] == '"' && tag.StartsWith("a href=\""))
								  || (tag[^1] == '\'' && tag.StartsWith("a href='")))
							{
								tag = HttpUtility.HtmlDecode(tag[8..^1]);
								if (tag.StartsWith("tg://user?id=") && long.TryParse(tag[13..], out var user_id) && users?.GetValueOrDefault(user_id)?.access_hash is long hash)
									entities.Add(new InputMessageEntityMentionName { offset = offset, length = -1, user_id = new InputUser(user_id, hash) });
								else
									entities.Add(new MessageEntityTextUrl { offset = offset, length = -1, url = tag });
							}
							else if ((tag[^1] == '"' && tag.StartsWith("code class=\"language-"))
								  || (tag[^1] == '\'' && tag.StartsWith("code class='language-")))
							{
								if (entities.LastOrDefault(e => e.length == -1) is MessageEntityPre prevEntity)
									prevEntity.language = tag[21..^1];
							}
							else if (premium && (tag.StartsWith("tg-emoji emoji-id=\"") || tag.StartsWith("tg-emoji emoji-id='")))
								entities.Add(new MessageEntityCustomEmoji { offset = offset, length = -1, document_id = long.Parse(tag[(tag.IndexOf('=') + 2)..^1]) });
							break;
					}

					void ProcessEntity<T>() where T : MessageEntity, new()
					{
						if (!closing)
							entities.Add(new T { offset = offset, length = -1 });
						else if (entities.LastOrDefault(e => e.length == -1) is T prevEntity)
							prevEntity.length = offset - prevEntity.offset;
					}
				}
				else
					offset++;
			}
			FixUps(sb, entities);
			text = sb.ToString();
			return entities.Count == 0 ? null : [.. entities];
		}

		internal static void FixUps(StringBuilder sb, List<MessageEntity> entities)
		{
			int newlen = sb.Length;
			while (--newlen >= 0 && char.IsWhiteSpace(sb[newlen]));
			if (++newlen != sb.Length) sb.Length = newlen;
			for (int i = 0; i < entities.Count; i++)
			{
				var entity = entities[i];
				if (entity.offset + entity.length > newlen) entity.length = newlen - entity.offset;
				if (entity.length == 0) entities.RemoveAt(i--);
			}
		}

		/// <summary>Converts the (plain text + entities) format used by Telegram messages into an <a href="https://core.telegram.org/bots/api/#html-style">HTML-formatted text</a></summary>
		/// <param name="client">Client, used only for getting current user ID in case of <c>InputMessageEntityMentionName+InputUserSelf</c></param>
		/// <param name="message">The plain text, typically obtained from <see cref="Message.message"/></param>
		/// <param name="entities">The array of formatting entities, typically obtained from <see cref="Message.entities"/></param>
		/// <param name="premium">Convert premium entities</param>
		/// <returns>The message text with HTML formatting tags</returns>
		public static string EntitiesToHtml(this Client client, string message, MessageEntity[] entities, bool premium = false)
		{
			if (entities == null || entities.Length == 0) return Escape(message);
			var closings = new List<(int offset, string tag)>();
			var sb = new StringBuilder(message);
			int entityIndex = 0;
			var nextEntity = entities[entityIndex];
			for (int offset = 0, i = 0; ; offset++, i++)
			{
				while (closings.Count != 0 && offset == closings[0].offset)
				{
					var tag = closings[0].tag;
					sb.Insert(i, tag); i += tag.Length;
					closings.RemoveAt(0);
				}
				if (i == sb.Length) break;
				for (; offset == nextEntity?.offset; nextEntity = ++entityIndex < entities.Length ? entities[entityIndex] : null)
				{
					if (EntityToTag.TryGetValue(nextEntity.GetType(), out var tag))
					{
						var closing = (nextEntity.offset + nextEntity.length, $"</{tag}>");
						if (tag[0] == 'a')
						{
							if (nextEntity is MessageEntityTextUrl metu)
								tag = $"<a href=\"{Escape(metu.url)}\">";
							else if (nextEntity is MessageEntityMentionName memn)
								tag = $"<a href=\"tg://user?id={memn.user_id}\">";
							else if (nextEntity is InputMessageEntityMentionName imemn)
								tag = $"<a href=\"tg://user?id={imemn.user_id.UserId ?? client.UserId}\">";
						}
						else if (nextEntity is MessageEntityCustomEmoji mecu)
							if (premium) tag = $"<tg-emoji emoji-id=\"{mecu.document_id}\">";
							else continue;
						else if (nextEntity is MessageEntityPre mep && !string.IsNullOrEmpty(mep.language))
						{
							closing.Item2 = "</code></pre>";
							tag = $"<pre><code class=\"language-{mep.language}\">";
						}
						else if (nextEntity is MessageEntityBlockquote { flags: MessageEntityBlockquote.Flags.collapsed })
							tag = "<blockquote expandable>";
						else
							tag = $"<{tag}>";
						int index = ~closings.BinarySearch(closing, Comparer<(int, string)>.Create((x, y) => x.Item1.CompareTo(y.Item1) | 1));
						closings.Insert(index, closing);
						sb.Insert(i, tag); i += tag.Length;
					}
				}
				switch (sb[i])
				{
					case '&': sb.Insert(i + 1, "amp;"); i += 4; break;
					case '<': sb.Insert(i, "&lt"); sb[i += 3] = ';'; break;
					case '>': sb.Insert(i, "&gt"); sb[i += 3] = ';'; break;
				}
			}
			return sb.ToString();
		}

		static readonly Dictionary<Type, string> EntityToTag = new()
		{
			[typeof(MessageEntityBold)] = "b",
			[typeof(MessageEntityItalic)] = "i",
			[typeof(MessageEntityCode)] = "code",
			[typeof(MessageEntityPre)] = "pre",
			[typeof(MessageEntityTextUrl)] = "a",
			[typeof(MessageEntityMentionName)] = "a",
			[typeof(InputMessageEntityMentionName)] = "a",
			[typeof(MessageEntityUnderline)] = "u",
			[typeof(MessageEntityStrike)] = "s",
			[typeof(MessageEntitySpoiler)] = "tg-spoiler",
			[typeof(MessageEntityCustomEmoji)] = "tg-emoji",
			[typeof(MessageEntityBlockquote)] = "blockquote",
		};

		/// <summary>Replace special HTML characters with their &amp;xx; equivalent</summary>
		/// <param name="text">The text to make HTML-safe</param>
		/// <returns>The HTML-safe text, ready to be used in <see cref="HtmlToEntities">HtmlToEntities</see> without problems</returns>
		public static string Escape(string text)
			=> text?.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
	}
}
