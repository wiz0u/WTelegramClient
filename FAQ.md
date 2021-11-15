## FAQ

#### 1. How to remove the Console logs ?

Writing the library logs to the Console is the default behavior of the `WTelegram.Helpers.Log` delegate.  
You can change the delegate with the `+=` operator to **also** write them somewhere else, or with the `=` operator to prevent them from being printed to screen and instead write them somewhere (file, logger, ...).
In any case, it is not recommended to totally ignore those logs because you wouldn't be able to analyze a problem after it happens.  

Read the [example about logging settings](EXAMPLES.md#change-logging-settings) for how to write logs to a file.

#### 2. How to handle multiple user accounts

The WTelegram.session file contains the authentication keys negociated for the current user.

You could switch the current user via an `Auth_Logout` followed by a `LoginUserIfNeeded` but that would require the user to sign in with a verification_code each time.

Instead, if you want to deal with multiple users, the recommended solution is to have a different session file for each user. This can be done by having your Config callback reply with a different filename (or folder) for "**session_pathname**" for each user.
This way, you can keep separate session files (each with their authentication keys) for each user.

If you need to manage these user accounts in parallel, you can create multiple instances of WTelegram.Client, and give them a Config callback that will select a different session file.

Also please note that the session files are encrypted with your api_hash, so if you change it, the existing session files can't be read anymore.
Your api_id/api_hash represents your application, and shouldn't change with each user account the application will manage.

#### 3. How to use the library in a WinForms or WPF application

The library should work without a problem in a GUI application.
The difficulty might be in your Config callback when the user must enter the verification code or password, as you can't use `Console.ReadLine` here.

An easy solution is to call `Interaction.InputBox("Enter verification code")` instead.  
This might require adding a reference *(and `using`)* to the Microsoft.VisualBasic assembly.

#### 4. I get the error `CHAT_ID_INVALID` or `CHANNEL_INVALID`

First, you should distinguish between Chat, Channel and Group/Supergroup: See Terminology in [ReadMe](README.md#Terminology-in-Telegram-Client-API)  
Most chat groups are in fact not a simple `Chat` but rather a (super)group (= a `Channel` without the `broadcast` flag)  
Some TL methods only applies to simple Chat, and some only applies to Channels.

A simple `Chat` can be queried using their `chat_id` only.  
But a `Channel` must be queried using an `InputChannel` or `InputPeerChannel` object that specifies the `channel_id` as well as an `access_hash` that proves you are allowed to access it.

To construct these `InputChannel` or `InputPeerChannel` objects, the simplest way is to start your session with a call to `Messages_GetAllChats`.
The resulting list contains both Chat and Channel instances, that can be converted implicitly to the adequate `InputPeer`.
A Channel instance can also be converted implicitly to `InputChannel`.
So usually you can just pass the Chat or Channel instance directly to the API method expecting an InputPeer/InputChannel argument.

You can also construct an `InputChannel` or `InputPeerChannel` object manually, but then you must specify the `access_hash`.
This hash is fixed for a given user account and a given channel, so if you often access the same, you may save it or hardcode it, along with the channel_id.  
To obtain it in the first place, you can extract it manually from the `access_hash` field in Channel object instances,
or you can use WTelegramClient experimental system `client.CollectAccessHash = true` that will automatically extract all `access_hash` fields from the API responses it encountered so far.
Then you can use `client.GetAccessHashFor<Channel>(channel_id)` to retrieve it, but this will work only if that access_hash was collected during the session.
A way to force the collection of the user's Channel access_hash is to call `Messages_GetAllChats` once.
For a more thourough example showing how to use this system and to save/remember all access_hash between session, see the [Program_CollectAccessHash.cs example](Examples/Program_CollectAccessHash.cs).

#### 5. I need to test a feature that has been developed but not yet release in WTelegramClient nuget

The developmental versions of the library are available through Azure DevOps as part of the Continuous Integration builds after each Github commit.

You can access these versions for testing in your program by going to our [private nuget feed](https://dev.azure.com/wiz0u/WTelegramClient/_packaging?_a=package&feed=WTelegramClient&view=overview&package=WTelegramClient&protocolType=NuGet), then click on "Connect to feed" and follow the steps.
After that, you should be able to see/install the pre-release versions in your Nuget package manager and install them in your application. *(make sure you enable the **pre-release** checkbox)*

#### 6. WTelegramClient asks me to signup (firstname, lastname) even for an existing account and can't find any chats
This happens when you connect to Telegram Test servers instead of Production servers.
On these separate test servers, created accounts and chats are periodically deleted, so you shouldn't use them under normal circumstances.

This wrong-server problem typically happens when you use the Github source project in your application in DEBUG builds.  
It is **not recommended** to use WTelegramClient in source code form.
Instead, you should use the Nuget manager to **import the WTelegramClient Nuget package** into your application.

If you use the Github source project in an old .NET Framework 4.x or .NET Core x.x application, you may also experience the following error
> System.TypeInitializationException (FileNotFoundException for "System.Text.Json Version=5.0.0.0 ...")

To fix this, you should also switch to using the [WTelegramClient Nuget package](https://www.nuget.org/packages/WTelegramClient) as it will install the required dependencies for it to work.

#### 7. I can't import phone numbers. I get error PHONE_NUMBER_BANNED or FLOOD_WAIT_84200

You can get these kind of problems if you abuse Telegram [Terms of Service](https://telegram.org/tos) or make excessive requests.

You can try to wait more between the requests, wait for a day or two to see if the requests become possible again.

If you think your phone number was banned for a bad reason, you may try to contact [recover@telegram.org](mailto:recover@telegram.org)

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
