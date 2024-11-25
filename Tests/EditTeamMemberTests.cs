using PlaywrightFramework.Pages;
using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightFramework.Factories;
using Playwright_PageTest001;

namespace PlaywrightFramework.Tests
{
    public class EditTeamMemberTests
    {
        protected SearchTeamMemberPage _searchPage;
        protected EditTeamMemberPage _editPage;
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IPage _page;

        [SetUp]
        public async Task Setup()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            _page = await _browser.NewPageAsync();
            ExtentReport.exParentTest = ExtentReport.extentReports.CreateTest(TestContext.CurrentContext.Test.MethodName);
        }


        [TearDown]
        public async Task TearDown()
        {
            await _page.CloseAsync();
        }

        public EditTeamMemberTests()
        {

        }

        public EditTeamMemberTests(SearchTeamMemberPage searchPage, EditTeamMemberPage editPage)
        {
            _searchPage = searchPage;
            _editPage = editPage;
        }

        // public class SearchData
        // {
        //     public string FirstName { get; set; }
        //     public string LastName { get; set; }
        //     public string Email { get; set; }
        //     public string CellPhone { get; set; }
        //     public string Username { get; set; }
        //     public string Password { get; set; }
        // }

        [Test]
        [Category("Extent")]     
        public async Task EditTeamMemberTest()
        {
         ExtentReport.exChildTest = ExtentReport.exParentTest.CreateNode("Edit a team member");
           // Set a custom timeout for navigation
            var navigationOptions = new PageGotoOptions
            {
                Timeout = 60000 // 60 seconds for navigation timeout
            };

            // Set a custom timeout for click
            var clickOptions = new PageClickOptions
            {
                Timeout = 60000 // 60 seconds for navigation timeout
            };
           
           var pageFactory = new PageFactory(_page);

            var loginPage = pageFactory.GetLoginPage();

            await loginPage.GoToAsync(navigationOptions);

            await loginPage.LoginAsync();

            var mainMenuPage = pageFactory.GetMainMenuPage();

            await mainMenuPage.navigateToSetup(clickOptions);

            Console.WriteLine("Setup done");

            var accountSetupPage = pageFactory.GetAccountSetupPage();

            await accountSetupPage.ManageTeamMember();

            var searchTeamMemberPage = pageFactory.GetTeamMemberPage();

            string firstName = await searchTeamMemberPage.SearchingTeamMember("firstName");

            Console.WriteLine("FirstName before editing is " + firstName);         

            await searchTeamMemberPage.ClickOnEditTeamMember();

            var editTeamMemberPage = pageFactory.GetEditTeamMemberPage();

            await editTeamMemberPage.VerifyTeamMemberHeading();

            await editTeamMemberPage.Edit_Team_Member();

            string fname = editTeamMemberPage.GetFirstName();

            Console.WriteLine("FirstName after editing is " + fname);

            await editTeamMemberPage.SubmitEditedDetails();

            await searchTeamMemberPage.SearchingTeamMemberAfterEdit(fname);

            Assert.That(firstName != fname);

            await ExtentReport.TakeScreenshot(_page, "A Team member updated successfully");          

        }
    }
}
