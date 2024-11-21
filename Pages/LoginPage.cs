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
            await _page.GotoAsync("https://rta-edu-stg-web-03.azurewebsites.net/core", pgo);
        }

        public async Task LoginAsync(string userName, string password)
        {
            await _signInName.FillAsync(userName);
            await _password.FillAsync(password);
            await _signIn.ClickAsync();
        }
    }
}