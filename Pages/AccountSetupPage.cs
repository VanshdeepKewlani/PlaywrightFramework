using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightFramework.Pages
{
    public class AccountSetupPage
    {
        private readonly IPage _page;

        public AccountSetupPage(IPage page) => _page = page;

        private ILocator manageTeamMember => _page.Locator("a[href='/core/setup/team-members']");
        private ILocator teamMembersHeading => _page.Locator("team-members h2");
        private ILocator addTeamMember => _page.Locator("a[href='/core/setup/team-members/add']");
        

        public async Task ManageTeamMember()
        {
            await manageTeamMember.ClickAsync();

            // Wait for navigation to the new page on invoking manage team members
            await _page.WaitForURLAsync("https://rta-edu-stg-web-03.azurewebsites.net/core/setup/team-members");

            try
            {
                // Check for the presence of header "Team Members"
                string locatorText = await teamMembersHeading.InnerTextAsync();

                if (locatorText.Contains("Team Members"))
                {
                    Assert.Pass("The page contains 'Team Members'.");
                }
                else
                {
                    Assert.Fail("The page does not contain 'Team Members'.");
                }
            }
            catch (NUnit.Framework.SuccessException excep)
            {
                Console.WriteLine("The page contains 'Team Members'");
            }
        }

        public async Task AddTeamMember()
        {
            await addTeamMember.ClickAsync();
            // Wait for navigation to the new page on invoking manage team members
            await _page.WaitForURLAsync("https://rta-edu-stg-web-03.azurewebsites.net/core/setup/team-members/add");
        }
    }
}