using Microsoft.Playwright;

namespace PlaywrightFramework.Pages
{
    public class MainMenu
    {
        private readonly IPage _page;

        public MainMenu(IPage page) => _page = page;

        public async Task navigateToSetup(PageClickOptions pco)
        {
            await _page.ClickAsync("a[href='/core/setup']", pco);

            // Wait for navigation to the new page after setup
            await _page.WaitForURLAsync("https://rta-edu-stg-web-03.azurewebsites.net/core/setup");

        }
    }
}