// using Microsoft.Playwright;
// using System;
// using NUnit.Framework;

// /// <summary>
// /// Base class for tests that handles Playwright initialization, browser setup, and page navigation.
// /// </summary>
// // public abstract class BaseTest : IDisposable
// public abstract class BaseTest
// {
//     protected IPlaywright _playwright;
//     protected IBrowser _browser;
//     protected IPage _page;

//     [SetUp]
//     public async Task Initialize()
//     {
//         await InitializeAsync();

//     }

//     /// <summary>
//     /// Initializes Playwright, opens a Chromium browser instance, and sets up page objects.
//     /// </summary>
//     public async Task InitializeAsync()
//     {
//         _playwright = await Playwright.CreateAsync();
//         _browser = await _playwright.Chromium.LaunchAsync(new()
//         {
//             Headless = ConfigurationManager.GetHeadless(),
//         });
//         _page = await _browser.NewPageAsync();
//         _page.SetDefaultTimeout(ConfigurationManager.GetTimeout());

//     }

//     /// <summary>
//     /// Disposes the Playwright browser and resources.
//     /// </summary>
//     // public void Dispose()
//     // {
//     //     _browser.CloseAsync();
//     //     _playwright.Dispose();
//     // }
// }