## FAQ

#### 1. How to remove the Console logs?

Writing the library logs to the Console is the default behavior of the `WTelegram.Helpers.Log` delegate.  
You can change the delegate with the `+=` operator to **also** write them somewhere else, or with the `=` operator to prevent them from being printed to screen and instead write them somewhere (file, logger, ...).
In any case, it is not recommended to totally ignore those logs because you wouldn't be able to analyze a problem after it happens.  

Read the [example about logging settings](EXAMPLES.md#change-logging-settings) for how to write logs to a file.

#### 2. How to handle multiple user accounts

The WTelegram.session file contains the authentication keys negociated for the current user.

You could switch the current user via an `Auth_Logout` followed by a `LoginUserIfNeeded` but that would require the user to sign in with a verification_code each time.

Instead, if you want to deal with multiple users from the same machine, the recommended solution is to have a different session file for each user. This can be done by having your Config callback reply with a different filename (or folder) for "**session_pathname**" for each user.
This way, you can keep separate session files (each with their authentication keys) for each user.

If you need to manage these user accounts in parallel, you can create multiple instances of WTelegram.Client, and give them a Config callback that will select a different session file.

Also please note that the session files are encrypted with your api_hash, so if you change it, the existing session files can't be read anymore.
Your api_id/api_hash represents your application, and shouldn't change with each user account the application will manage.

#### 3. How to use the library in a WinForms or WPF application

The library should work without a problem in a GUI application.
The difficulty might be in your Config callback when the user must enter the verification code or password, as you can't use `Console.ReadLine` here.

An easy solution is to call `Interaction.InputBox("Enter verification code")` instead.  
This might require adding a reference *(and `using`)* to the Microsoft.VisualBasic assembly.

#### 4. Where to get the access_hash? Why the error `CHANNEL_INVALID` or `USER_ID_INVALID`?

An `access_hash` is required by Telegram when dealing with a channel, user, photo, document, etc...  
This serves as a proof that you are entitled to access it (otherwise, anybody with the ID could access it)

> A small private `Chat` don't need an access_hash and can be queried using their `chat_id` only.
However most common chat groups are not `Chat` but a `Channel` supergroup (without the `broadcast` flag). See Terminology in [ReadMe](README.md#Terminology-in-Telegram-Client-API).  
Some TL methods only applies to private `Chat`, some only applies to `Channel` and some to both.

The `access_hash` must usually be provided within the `Input...` structure you pass in argument to an API method (`InputPeer`, `InputChannel`, `InputUser`, etc...).  
You obtain the `access_hash` through **description structures** like `Channel`, `User`, `Photo`, `Document` that you receive through updates or when you query them through API methods like `Messages_GetAllChats`, `Messages_GetDialogs`, `Contacts_ResolveUsername`, etc...

Once you obtained the description structure, there are 3 methods for building your `Input...` structure:
* **Recommended:** If you take a look at the **description structure** class or `ChatBase/UserBase`, 
you will see that they have conversion implicit operators or methods that can create the `Input...` structure for you automatically.  
So you can just pass that structure you already have, in place of the `Input...` argument, it will work!
* Alternatively, you can manually create the `Input...` structure yourself by extracting the `access_hash` from the **description structure**
* If you have enabled the [CollectAccessHash system](EXAMPLES.md#collect-access-hash-and-save-them-for-later-use) at the start of your session, it will have collected the `access_hash`.
You can then retrieve it with `client.GetAccessHashFor<User/Channel/Photo/Document>(id)`

#### 5. I need to test a feature that has been developed but not yet released in WTelegramClient nuget

The developmental versions of the library are available through Azure DevOps as part of the Continuous Integration builds after each Github commit.

You can access these versions for testing in your program by going to our [private nuget feed](https://dev.azure.com/wiz0u/WTelegramClient/_packaging?_a=package&feed=WTelegramClient&view=overview&package=WTelegramClient&protocolType=NuGet), then click on "Connect to feed" and follow the steps.
After that, you should be able to see/install the pre-release versions in your Nuget package manager and install them in your application. *(make sure you enable the **pre-release** checkbox)*

#### 6. Telegram can't find any chats and asks me to signup (firstname, lastname) even for an existing account
This happens when you connect to Telegram Test servers instead of Production servers.
On these separate test servers, all created accounts and chats are periodically deleted, so you shouldn't use them under normal circumstances.

This wrong-server problem typically happens when you use WTelegramClient Github source project in your application in DEBUG builds.  
It is **not recommended** to use WTelegramClient in source code form.
Instead, you should use the Nuget manager to **import the WTelegramClient Nuget package** into your application.

If you use the Github source project in an old .NET Framework 4.x or .NET Core x.x application, you may also experience the following error
> System.TypeInitializationException (FileNotFoundException for "System.Text.Json Version=5.0.0.0 ...")

To fix this, you should also switch to using the [WTelegramClient Nuget package](https://www.nuget.org/packages/WTelegramClient) as it will install the required dependencies for it to work.

#### 7. How to not get banned from Telegram?

**Do not share publicly your app's ID and hash!** They cannot be regenerated and are bound to your Telegram account.

From the [official documentation](https://core.telegram.org/api/obtaining_api_id):

> Note that all API client libraries are strictly monitored to prevent abuse.  
> If you use the Telegram API for flooding, spamming, faking subscriber and view counters of channels, you **will be banned forever**.  
> Due to excessive abuse of the Telegram API, **all accounts that sign up or log in using unofficial Telegram clients are automatically
> put under observation** to avoid violations of the [Terms of Service](https://core.telegram.org/api/terms).

Here are some key points:

1. This client is unofficial, Telegram treats such clients suspiciously, especially fresh ones.
2. Use regular bots instead of userbots whenever possible.
3. If you still want to automate things with a user, use it passively (i.e. receive more than sending).
4. When using it with a user:
   * Do not use QR code login, this will result in permaban.
   * Do it with extreme care.
   * Do not use VoIP numbers.
   * Do not abuse, spam or use it for other suspicious activities.
   * Implement a rate limiting system.

*(the above section is derived from [gotd SUPPORT.md](https://github.com/gotd/td/blob/main/.github/SUPPORT.md))*

If your client displays Telegram channels to the user, you have to support and display [official sponsored messages](https://core.telegram.org/api/sponsored-messages).

#### 8. I can't import phone numbers. I get error PHONE_NUMBER_BANNED or FLOOD_WAIT_8xxxx

You can get these kind of problems if you abuse Telegram [Terms of Service](https://telegram.org/tos) or https://core.telegram.org/api/terms or make excessive requests.

You can try to wait more between the requests, wait for a day or two to see if the requests become possible again.

If you think your phone number was banned for a wrong reason, you may try to contact [recover@telegram.org](mailto:recover@telegram.org), explaining what you were doing.

In any case, WTelegramClient is not responsible for the bad usage of the library and we are not affiliated to Telegram teams, so there is nothing we can do.


## Troubleshooting guide

Here is a list of common issues and how to fix them so that your program work correctly:
1) Are you using the Nuget package or the library source code?  
It is not recommended to copy/compile the source code of the library for a normal usage.  
When built in DEBUG mode, the source code connects to Telegram test servers. So you can either:
    - **Recommended:** Use the [official Nuget package](https://www.nuget.org/packages/WTelegramClient) or the [private nuget feed of development builds](https://dev.azure.com/wiz0u/WTelegramClient/_packaging?_a=package&feed=WTelegramClient&package=WTelegramClient&protocolType=NuGet)
    - Build your code in RELEASE mode
    - Modify your config callback to reply to "server_address" with the IP address of Telegram production servers (as found on your API development tools)

2) After `ConnectAsync()`, are you calling `LoginUserIfNeeded()`?  
If you don't authenticate as a user (or bot), you have access to a very limited subset of Telegram APIs

3) Did you use `await` with every Client methods?  
This library is completely Task-based and you should learn, understand and use the [asynchronous model of C# programming](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/) before proceeding further.

4) Are you keeping a live reference to the Client instance and dispose it only at the end of your program?  
If you create the instance in a submethod and don't store it somewhere permanent, it might be destroyed by the garbage collector at some point. So as long as the client must be running, make sure the reference is stored in a (static) field or somewhere appropriate.  
Also, as the Client class inherits `IDisposable`, remember to call `client.Dispose()` when your program ends (or exit a `using` scope).

5) Is your program ending immediately instead of waiting for Updates?  
Your program must be running/waiting continuously in order for the background Task to receive and process the Updates. So make sure your main program doesn't end immediately. For a console program, this is typical done by waiting for a key or some close event.

6) Is every Telegram API call rejected? (typically with an exception message like `AUTH_RESTART`)  
The user authentification might have failed at some point (or the user revoked the authorization). It is therefore necessary to go through the authentification again. This can be done by deleting the WTelegram.session file, or at runtime by calling `client.Reset()`
