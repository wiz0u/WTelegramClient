using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TL;

// This is an example userbot designed to run on a free Heroku account with a free PostgreSQL database for session storage
// This userbot simply answer "Pong" when someone sends him a "Ping" private message (or in Saved Messages)
// To use/install/deploy this userbot, follow the steps at the end of this file
// When run locally, close the window or type ALT-F4 to exit cleanly and save session (similar to Heroku SIGTERM)

namespace WTelegramClientTest
{
	static class Program_Heroku
	{
		static WTelegram.Client Client;
		static User My;
		static readonly Dictionary<long, User> Users = new();
		static readonly Dictionary<long, ChatBase> Chats = new();

		// See steps at the end of this file to setup required Environment variables
		static async Task Main(string[] _)
		{
			var exit = new SemaphoreSlim(0);
			AppDomain.CurrentDomain.ProcessExit += (s, e) => exit.Release(); // detect SIGTERM to exit gracefully
			var store = new PostgreStore(Environment.GetEnvironmentVariable("DATABASE_URL"), Environment.GetEnvironmentVariable("SESSION_NAME"));
			// if DB does not contain a session yet, client will be run in interactive mode
			Client = new WTelegram.Client(store.Length == 0 ? null : Environment.GetEnvironmentVariable, store);
			using (Client)
			{
				Client.Update += Client_Update;
				My = await Client.LoginUserIfNeeded();
				Console.WriteLine($"We are logged-in as {My.username ?? My.first_name + " " + My.last_name} (id {My.id})");
				var dialogs = await Client.Messages_GetAllDialogs();
				dialogs.CollectUsersChats(Users, Chats);
				await exit.WaitAsync();
			}
		}

		private static async void Client_Update(IObject arg)
		{
			if (arg is not UpdatesBase updates) return;
			updates.CollectUsersChats(Users, Chats);
			foreach (var update in updates.UpdateList)
			{
				Console.WriteLine(update.GetType().Name);
				if (update is UpdateNewMessage { message: Message { peer_id: PeerUser { user_id: var user_id } } msg }) // private message
					if (Users.TryGetValue(user_id, out var user))
					{
						Console.WriteLine($"New message from {user}: {msg.message}");
						if (msg.message.Equals("Ping", StringComparison.OrdinalIgnoreCase))
							await Client.SendMessageAsync(user, "Pong");
					}
			}
		}
	}

	#region PostgreSQL session store
	class PostgreStore : Stream
	{
		private readonly NpgsqlConnection _sql;
		private readonly string _sessionName;
		private byte[] _data;
		private int _dataLen;
		private DateTime _lastWrite;
		private Task _delayedWrite;

		/// <param name="databaseUrl">Heroku DB URL of the form "postgres://user:password@host:port/database"</param>
		/// <param name="sessionName">Entry name for the session data in the WTelegram_sessions table (default: "Heroku")</param>
		public PostgreStore(string databaseUrl, string sessionName = null)
		{
			_sessionName = sessionName ?? "Heroku";
			var parts = databaseUrl.Split(':', '/', '@');
			_sql = new NpgsqlConnection($"User ID={parts[3]};Password={parts[4]};Host={parts[5]};Port={parts[6]};Database={parts[7]};Pooling=true;SSL Mode=Require;Trust Server Certificate=True;");
			_sql.Open();
			using (var create = new NpgsqlCommand($"CREATE TABLE IF NOT EXISTS WTelegram_sessions (name text NOT NULL PRIMARY KEY, data bytea)", _sql))
				create.ExecuteNonQuery();
			using var cmd = new NpgsqlCommand($"SELECT data FROM WTelegram_sessions WHERE name = '{_sessionName}'", _sql);
			using var rdr = cmd.ExecuteReader();
			if (rdr.Read())
				_dataLen = (_data = rdr[0] as byte[]).Length;
		}

		protected override void Dispose(bool disposing)
		{
			_delayedWrite?.Wait();
			_sql.Dispose();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			Array.Copy(_data, 0, buffer, offset, count);
			return count;
		}

		public override void Write(byte[] buffer, int offset, int count) // Write call and buffer modifications are done within a lock()
		{
			_data = buffer; _dataLen = count;
			if (_delayedWrite != null) return;
			var left = 1000 - (int)(DateTime.UtcNow - _lastWrite).TotalMilliseconds;
			if (left < 0)
			{
				using var cmd = new NpgsqlCommand($"INSERT INTO WTelegram_sessions (name, data) VALUES ('{_sessionName}', @data) ON CONFLICT (name) DO UPDATE SET data = EXCLUDED.data", _sql);
				cmd.Parameters.AddWithValue("data", count == buffer.Length ? buffer : buffer[offset..(offset + count)]);
				cmd.ExecuteNonQuery();
				_lastWrite = DateTime.UtcNow;
			}
			else // delay writings for a full second
				_delayedWrite = Task.Delay(left).ContinueWith(t => { lock (this) { _delayedWrite = null; Write(_data, 0, _dataLen); } });
		}

		public override long Length => _dataLen;
		public override long Position { get => 0; set { } }
		public override bool CanSeek => false;
		public override bool CanRead => true;
		public override bool CanWrite => true;
		public override long Seek(long offset, SeekOrigin origin) => 0;
		public override void SetLength(long value) { }
		public override void Flush() { }
	}
	#endregion
}

/******************************************************************************************************************************
HOW TO USE AND DEPLOY THIS EXAMPLE HEROKU USERBOT:
- From your free Heroku.com account dashboard, create a new app (Free)
- Navigate to the app Resources and add the add-on "Heroku Postgres" (Hobby Dev - Free)
- Navigate to the app Settings, click Reveal Config Vars and save the Heroku git URL and the value of DATABASE_URL
- Add a new var named "api_hash" with your api hash obtained from https://my.telegram.org/apps
- Add a new var named "phone_number" with the phone_number of the user this userbot will manage
- Scroll down to Buildpacks and add this URL: https://github.com/jincod/dotnetcore-buildpack.git
- In Visual Studio, Clone the Heroku git repository and add some standard .gitignore .gitattributes files
- In this repository folder, create a new .NET Console project with this Program.cs file
- Add these Nuget packages: WTelegramClient and Npgsql
- In Project properties > Debug > Environment variables, configure the same values for DATABASE_URL, api_hash, phone_number
- Run the project in Visual Studio. The first time, it should ask you interactively for elements to complete the connection
- On the following runs, the PostgreSQL database contains the session data and it should connect automatically
- You can test the userbot by sending him "Ping" in private message (or saved messages). It should respond with "Pong"
- You can now commit & push your git sources to Heroku, they will be compiled and deployed/run as a web app
- The userbot should work fine for 1 minute, but it will be taken down because it is not a web app. Let's fix that
- Navigate to the app Resources, copy the line starting with: web cd $HOME/.......
- Back in Visual Studio (or Explorer), at the root of the repository create a Procfile text file (without extension)
- Paste inside the line you copied, and replace the initial "web" with "worker:" (don't forget the colon)
- Commit and push the Git changes to Heroku. Wait until the deployment is complete.
- Verify that the Resources "web" line has changed to "worker" and is enabled (use the pencil icon if necessary)
- Now your userbot should be running 24/7. Note however that a full month of usage is 31*24 = 744 dyno hours.
  By default a free account gets 550 free dyno hours per month after which your app is stopped. If you register
  a credit card with your account, 450 additional free dyno hours are offered at no charge, which should be enough for 24/7
- To prevent AUTH_KEY_DUPLICATED issues, set a SESSION_NAME env variable in your local VS project with a value like "PC"
DISCLAIMER: I'm not affiliated nor expert with Heroku, so if you have any problem with the above I might not be able to help
******************************************************************************************************************************/
