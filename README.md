instantbuy-sample-csharp
========================

A CSharp Web Application that implements the Instant Buy Web API


Requirements
=============

  * [Visual Studio 2012 or higher](http://msdn.microsoft.com/vstudio/)
  * [The NuGet package manager](http://nuget.org/)

Setting up the Sample
=====================

The InstantBuy C# Sample is setup in the following steps:

  1. Create an OAuth2 ClientId
  2. Add the Merchant credentials in the app.
  3. Set up & run the project in Visual Studio.


Step 1: Create an OAuth2 Client ID
-----------------------------------

You need to create an oauth2 client Id for your app. You can do this by creating a project for your app in Google APIs console.

1. In the [Google APIs Console](http://cloud.google.com), select Create from the pull-down and enter a project name.
2. Under APIs&Auth click on "Credentials" and "Create new OAuth ClientId".
3. Select Web Application for the Application type.
4. Add "http://localhost:8080/" to the Authorized JavaScript Origins field.

Step 2: Add the Merchant credentials in the app.
---------------------------------------------------
If you do not already have a merchant_id and secret, fill the [interest form](http://getinstantbuy.withgoogle.com/). 
Once you are granted access, you should have an id and a secret. 
Edit Web.config and replace the SANDBOX_MERCHANT_ID and SANDBOX_AUTH_KEY with the values.

    <add key="sandbox_merchant_id" value="SANDBOX_MERCHANT_ID"/>
    <add key="sandbox_merchant_auth_key" value="SANDBOX_AUTH_KEY"/>

Also replace the OAUTH_CLIENT_ID with the value created in Step 1 above.

    <add key="oauth_client_id" value="OAUTH_CLIENT_ID"/>

Step 3: Set up & run the project in Visual Studio
--------------------------------------------
 1. Open the Solution file instantbuy-sample-csharp.sln, and the project will open in Visual Studio.
 2. Click Project &gt; Enable NuGet Package Restore &gt; answer Yes in the dialog.
 3. Right-click on the instantbuy-sample-csharp project and selct Manage NuGet Packages.
 4. Click __Restore__ on the Manage NuGet Packages window. This will install the necessary packages.
 5. Close and try to build the project. The project should build successfully.
 6. Run the project by pressing the F5 key. This should bring up the Default.cshtml in a browser.

 
