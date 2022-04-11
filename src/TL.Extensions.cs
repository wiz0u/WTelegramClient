using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace TL
{
	public static class Extensions
	{
		private class CollectorPeer : Peer
		{
			public override long ID => 0;
			internal Dictionary<long, User> _users;
			internal Dictionary<long, ChatBase> _chats;
			internal override IPeerInfo UserOrChat(Dictionary<long, User> users, Dictionary<long, ChatBase> chats)
			{
				lock (_users)
					foreach (var user in users.Values)
						if (user != null)
							if (!user.flags.HasFlag(User.Flags.min) || !_users.TryGetValue(user.id, out var prevUser) || prevUser.flags.HasFlag(User.Flags.min))
								_users[user.id] = user;
				lock (_chats)
					foreach (var kvp in chats)
						if (kvp.Value is not Channel channel)
							_chats[kvp.Key] = kvp.Value;
						else if (!channel.flags.HasFlag(Channel.Flags.min) || !_chats.TryGetValue(channel.id, out var prevChat) || prevChat is not Channel prevChannel || prevChannel.flags.HasFlag(Channel.Flags.min))
							_chats[kvp.Key] = channel;
				return null;
			}
		}

		/// <summary>Accumulate users/chats found in this structure in your dictionaries, ignoring <see href="https://core.telegram.org/api/min">Min constructors</see> when the full object is already stored</summary>
		/// <param name="structure">The structure having a <c>users</c></param>
		public static void CollectUsersChats(this IPeerResolver structure, Dictionary<long, User> users, Dictionary<long, ChatBase> chats)
			=>  structure.UserOrChat(new CollectorPeer { _users = users, _chats = chats });
	}

	public static class Markdown
	{
		/// <summary>Converts a <a href="https://core.telegram.org/bots/api/#markdownv2-style">Markdown text</a> into the (plain text + entities) format used by Telegram messages</summary>
		/// <param name="client">Client, used for getting access_hash for <c>tg://user?id=</c> URLs</param>
		/// <param name="text">[in] The Markdown text<br/>[out] The same (plain) text, stripped of all Markdown notation</param>
		/// <returns>The array of formatting entities that you can pass (along with the plain text) to <see cref="WTelegram.Client.SendMessageAsync">SendMessageAsync</see> or  <see cref="WTelegram.Client.SendMediaAsync">SendMediaAsync</see></returns>
		public static MessageEntity[] MarkdownToEntities(this WTelegram.Client client, ref string text)
		{
			var entities = new List<MessageEntity>();
			var sb = new StringBuilder(text);
			for (int offset = 0; offset < sb.Length;)
			{
				switch (sb[offset])
				{
					case '\r': sb.Remove(offset, 1); break;
					case '\\': sb.Remove(offset++, 1); break;
					case '*': ProcessEntity<MessageEntityBold>(); break;
					case '~': ProcessEntity<MessageEntityStrike>(); break;
					case '_':
						if (offset + 1 < sb.Length && sb[offset + 1] == '_')
						{
							sb.Remove(offset, 1);
							ProcessEntity<MessageEntityUnderline>();
						}
						else
							ProcessEntity<MessageEntityItalic>();
						break;
					case '|':
						if (offset + 1 < sb.Length && sb[offset + 1] == '|')
						{
							sb.Remove(offset, 1);
							ProcessEntity<MessageEntitySpoiler>();
						}
						else
							offset++;
						break;
					case '`':
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
						break;
					case '[':
						entities.Add(new MessageEntityTextUrl { offset = offset, length = -1 });
						sb.Remove(offset, 1);
						break;
					case ']':
						if (offset + 2 < sb.Length && sb[offset + 1] == '(')
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
								if (textUrl.url.StartsWith("tg://user?id=") && long.TryParse(textUrl.url[13..], out var user_id) && client.GetAccessHashFor<User>(user_id) is long hash)
									entities[lastIndex] = new InputMessageEntityMentionName { offset = textUrl.offset, length = textUrl.length, user_id = new InputUser(user_id, hash) };
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
					if (entities.LastOrDefault(e => e.length == -1) is T prevEntity)
						prevEntity.length = offset - prevEntity.offset;
					else
						entities.Add(new T { offset = offset, length = -1 });
					sb.Remove(offset, 1);
				}
			}
			text = sb.ToString();
			return entities.Count == 0 ? null : entities.ToArray();
		}

		/// <summary>Converts the (plain text + entities) format used by Telegram messages into a <a href="https://core.telegram.org/bots/api/#markdownv2-style">Markdown text</a></summary>
		/// <param name="client">Client, used only for getting current user ID in case of <c>InputMessageEntityMentionName+InputUserSelf</c></param>
		/// <param name="message">The plain text, typically obtained from <see cref="TL.Message.message"/></param>
		/// <param name="entities">The array of formatting entities, typically obtained from <see cref="TL.Message.entities"/></param>
		/// <returns>The message text with MarkdownV2 formattings</returns>
		public static string EntitiesToMarkdown(this WTelegram.Client client, string message, MessageEntity[] entities)
		{
			if (entities == null || entities.Length == 0) return Escape(message);
			var closings = new List<(int offset, string md)>();
			var sb = new StringBuilder(message);
			int entityIndex = 0;
			var nextEntity = entities[entityIndex];
			for (int offset = 0, i = 0; ; offset++, i++)
			{
				while (closings.Count != 0 && offset == closings[0].offset)
				{
					var md = closings[0].md;
					if (i > 0 && md[0] == '_' && sb[i - 1] == '_') md = '\r' + md;
					sb.Insert(i, md); i += md.Length;
					closings.RemoveAt(0);
				}
				if (i == sb.Length) break;
				while (offset == nextEntity?.offset)
				{
					if (entityToMD.TryGetValue(nextEntity.GetType(), out var md))
					{
						var closing = (nextEntity.offset + nextEntity.length, md);
						if (md[0] == '[')
						{
							if (nextEntity is MessageEntityTextUrl metu)
								closing.md = $"]({metu.url.Replace("\\", "\\\\").Replace(")", "\\)").Replace(">", "%3E")})";
							else if (nextEntity is MessageEntityMentionName memn)
								closing.md = $"](tg://user?id={memn.user_id})";
							else if (nextEntity is InputMessageEntityMentionName imemn)
								closing.md = $"](tg://user?id={imemn.user_id.UserId ?? client.UserId})";
						}
						else if (nextEntity is MessageEntityPre mep)
							md = $"```{mep.language}\n";
						int index = ~closings.BinarySearch(closing, Comparer<(int, string)>.Create((x, y) => x.Item1.CompareTo(y.Item1) | 1));
						closings.Insert(index, closing);
						if (i > 0 && md[0] == '_' && sb[i - 1] == '_') md = '\r' + md;
						sb.Insert(i, md); i += md.Length;
					}
					nextEntity = ++entityIndex < entities.Length ? entities[entityIndex] : null;
				}
				switch (sb[i])
				{
					case '_': case '*': case '~': case '`': case '#': case '+': case '-': case '=': case '.': case '!':
					case '[': case ']': case '(': case ')': case '{': case '}': case '>': case '|': case '\\':
						sb.Insert(i, '\\'); i++;
						break;
				}
			}
			return sb.ToString();
		}

		static readonly Dictionary<Type, string> entityToMD = new()
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
		};

		/// <summary>Insert backslashes in front of Markdown reserved characters</summary>
		/// <param name="text">The text to escape</param>
		/// <returns>The escaped text, ready to be used in <see cref="MarkdownToEntities">MarkdownToEntities</see> without problems</returns>
		public static string Escape(string text)
		{
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
		/// <param name="client">Client, used for getting access_hash for <c>tg://user?id=</c> URLs</param>
		/// <param name="text">[in] The HTML-formatted text<br/>[out] The same (plain) text, stripped of all HTML tags</param>
		/// <returns>The array of formatting entities that you can pass (along with the plain text) to <see cref="WTelegram.Client.SendMessageAsync">SendMessageAsync</see> or  <see cref="WTelegram.Client.SendMediaAsync">SendMediaAsync</see></returns>
		public static MessageEntity[] HtmlToEntities(this WTelegram.Client client, ref string text)
		{
			var entities = new List<MessageEntity>();
			var sb = new StringBuilder(text);
			int end;
			for (int offset = 0; offset < sb.Length;)
			{
				char c = sb[offset];
				if (c == '&')
				{
					for (end = offset + 1; end < sb.Length; end++)
						if (sb[end] == ';') break;
					if (end >= sb.Length) break;
					var html = HttpUtility.HtmlDecode(sb.ToString(offset, end - offset + 1));
					if (html.Length == 1)
					{
						sb[offset] = html[0];
						sb.Remove(++offset, end - offset + 1);
					}
					else
						offset = end + 1;
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
						case "span" when closing:
						case "tg-spoiler": ProcessEntity<MessageEntitySpoiler>(); break;
						case "code": ProcessEntity<MessageEntityCode>(); break;
						case "pre": ProcessEntity<MessageEntityPre>(); break;
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
							else if (tag.StartsWith("a href=\"") && tag.EndsWith("\""))
							{
								tag = tag[8..^1];
								if (tag.StartsWith("tg://user?id=") && long.TryParse(tag[13..], out var user_id) && client.GetAccessHashFor<User>(user_id) is long hash)
									entities.Add(new InputMessageEntityMentionName { offset = offset, length = -1, user_id = new InputUser(user_id, hash) });
								else
									entities.Add(new MessageEntityTextUrl { offset = offset, length = -1, url = tag });
							}
							else if (tag.StartsWith("code class=\"language-") && tag.EndsWith("\""))
							{
								if (entities.LastOrDefault(e => e.length == -1) is MessageEntityPre prevEntity)
									prevEntity.language = tag[21..^1];
							}
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
			text = sb.ToString();
			return entities.Count == 0 ? null : entities.ToArray();
		}

		/// <summary>Converts the (plain text + entities) format used by Telegram messages into an <a href="https://core.telegram.org/bots/api/#html-style">HTML-formatted text</a></summary>
		/// <param name="client">Client, used only for getting current user ID in case of <c>InputMessageEntityMentionName+InputUserSelf</c></param>
		/// <param name="message">The plain text, typically obtained from <see cref="TL.Message.message"/></param>
		/// <param name="entities">The array of formatting entities, typically obtained from <see cref="TL.Message.entities"/></param>
		/// <returns>The message text with HTML formatting tags</returns>
		public static string EntitiesToHtml(this WTelegram.Client client, string message, MessageEntity[] entities)
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
				while (offset == nextEntity?.offset)
				{
					if (entityToTag.TryGetValue(nextEntity.GetType(), out var tag))
					{
						var closing = (nextEntity.offset + nextEntity.length, $"</{tag}>");
						if (tag[0] == 'a')
						{
							if (nextEntity is MessageEntityTextUrl metu)
								tag = $"<a href=\"{metu.url}\">";
							else if (nextEntity is MessageEntityMentionName memn)
								tag = $"<a href=\"tg://user?id={memn.user_id}\">";
							else if (nextEntity is InputMessageEntityMentionName imemn)
								tag = $"<a href=\"tg://user?id={imemn.user_id.UserId ?? client.UserId}\">";
						}
						else if (nextEntity is MessageEntityPre mep && !string.IsNullOrEmpty(mep.language))
						{
							closing.Item2 = "</code></pre>";
							tag = $"<pre><code class=\"language-{mep.language}\">";
						}
						else
							tag = $"<{tag}>";
						int index = ~closings.BinarySearch(closing, Comparer<(int, string)>.Create((x, y) => x.Item1.CompareTo(y.Item1) | 1));
						closings.Insert(index, closing);
						sb.Insert(i, tag); i += tag.Length;
					}
					nextEntity = ++entityIndex < entities.Length ? entities[entityIndex] : null;
				}
				switch (sb[i])
				{
					case '&': sb.Insert(i + 1, "amp;"); i += 4; break;
					case '<': sb.Remove(i, 1).Insert(i, "&lt;"); i += 3; break;
					case '>': sb.Remove(i, 1).Insert(i, "&gt;"); i += 3; break;
				}
			}
			return sb.ToString();
		}

		static readonly Dictionary<Type, string> entityToTag = new()
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
		};

		/// <summary>Replace special HTML characters with their &amp;xx; equivalent</summary>
		/// <param name="text">The text to make HTML-safe</param>
		/// <returns>The HTML-safe text, ready to be used in <see cref="HtmlToEntities">HtmlToEntities</see> without problems</returns>
		public static string Escape(string text)
			=> text.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
	}
}
