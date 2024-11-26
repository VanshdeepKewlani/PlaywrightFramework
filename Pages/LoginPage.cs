using Microsoft.Playwright;

namespace PlaywrightFramework.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page) => _page = page;

        private ILocator _signInName => _page.Locator("#signInName");

        private ILocator _password => _page.Locator("#password");

        private ILocator _signIn => _page.Locator("#next");


        public async Task GoToAsync(PageGotoOptions pgo)
        {
            await _page.GotoAsync(ConfigurationManager.GetBaseUrl(), pgo);
        }

        public async Task LoginAsync()
        {
            // Wait for the page to load before interacting with elements
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

            // Fetch login credentials from the configuration
            var creds = ConfigurationManager.GetLoginCreds();
            string username = creds.Username;
            string password = creds.Password;
            await _signInName.FillAsync(username);
            await _password.FocusAsync();
            await _password.FillAsync(password);
            await _signIn.ClickAsync();
        }
    }
}