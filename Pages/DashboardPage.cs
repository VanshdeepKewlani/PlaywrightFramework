using System.Linq.Expressions;
using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightFramework.Pages
{
    public class DashboardPage
    {
        private readonly IPage _page;

        public DashboardPage(IPage page) => _page = page;
        private ILocator _bodyLocator => _page.Locator("body");

        public async Task GetWelcomeMessageAsync()
        {
            await Task.Delay(70000); // Wait for 70 seconds
            
            // Wait for navigation to the new page after login
            await _page.WaitForURLAsync("https://rta-edu-stg-web-03.azurewebsites.net/core/reports/overview");

            // Wait for the page to load completely
            
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await _page.WaitForLoadStateAsync(LoadState.Load);
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            //await Task.Delay(70000); // Wait for 70 seconds

            try
            {
                // Check for the presence of inner text "Welcome"
                string bodyText = await _bodyLocator.InnerTextAsync();

               if (bodyText.Contains("Welcome"))
                {
                    Assert.Pass("The page contains 'Welcome, Roman Dev-db1'.");
                }
                else
                {
                    Assert.Fail("The page does not contain 'Welcome, Roman Dev-db1'.");
                }
            }
            catch(NUnit.Framework.SuccessException excep)
            {
                Console.WriteLine("The page contains 'Welcome, Roman Dev-db1'.");
            }
            
        }

    }
}