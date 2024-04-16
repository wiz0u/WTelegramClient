using System;
using System.Threading.Tasks;
using TL;

namespace WTelegramClientTest
{
	static class Program_ReactorError
	{
		static WTelegram.Client Client;

		// go to Project Properties > Debug > Launch Profiles > Environment variables and add at least these: api_id, api_hash, phone_number
		static async Task Main(string[] _)
		{
			Console.WriteLine("The program demonstrate how to handle ReactorError. Press any key to terminate");
			WTelegram.Helpers.Log = (l, s) => System.Diagnostics.Debug.WriteLine(s);
			try
			{
				await CreateAndConnect();
				Console.ReadKey();
			}
			finally
			{
				Client?.Dispose();
			}
		}

		private static async Task CreateAndConnect()
		{
			Client = new WTelegram.Client(Environment.GetEnvironmentVariable);
			Client.OnUpdates += Client_OnUpdates;
			Client.OnOther += Client_OnOther;
			var my = await Client.LoginUserIfNeeded();
			Console.WriteLine($"We are logged-in as " + my);
		}

		private static async Task Client_OnOther(IObject arg)
		{
			if (arg is ReactorError err)
			{
				// typically: network connection was totally lost
				Console.WriteLine($"Fatal reactor error: {err.Exception.Message}");
				while (true)
				{
					Console.WriteLine("Disposing the client and trying to reconnect in 5 seconds...");
					Client?.Dispose();
					Client = null;
					await Task.Delay(5000);
					try
					{
						await CreateAndConnect();
						break;
					}
					catch (Exception ex)
					{
						Console.WriteLine("Connection still failing: " + ex.Message);
					}
				}
			}
			else
				Console.WriteLine("Other: " + arg.GetType().Name);
		}

		private static Task Client_OnUpdates(UpdatesBase updates)
		{
			foreach (var update in updates.UpdateList)
				Console.WriteLine(update.GetType().Name);
			return Task.CompletedTask;
		}
	}
}
