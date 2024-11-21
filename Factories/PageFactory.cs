using Microsoft.Playwright;
using PlaywrightFramework.Pages;

namespace PlaywrightFramework.Factories
{
    public class PageFactory
    {
        private readonly IPage _page;

        public PageFactory(IPage page)
        {
            _page = page;
        }

        public LoginPage GetLoginPage() => new(_page);

        public DashboardPage GetDashboardPage() => new (_page);

        public MainMenu GetMainMenuPage() => new (_page);

        public AccountSetupPage GetAccountSetupPage() => new(_page);

        public AddTeamMemberPage GetAddTeamMemberPage() => new(_page);

        public SearchTeamMemberPage GetTeamMemberPage() => new(_page);

        public EditTeamMemberPage GetEditTeamMemberPage() => new(_page);
    }
}