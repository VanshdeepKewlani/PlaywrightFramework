using PlaywrightFramework.Pages;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Microsoft.Playwright;
using PlaywrightFramework.Factories;
using Playwright_PageTest001;

namespace PlaywrightFramework.Tests
{
    [TestFixture]
    public class AddTeamMemberTests
    {

        // private readonly AddTeamMemberPage _addTeamMemberPage;
        private IPage _page;
        private IPlaywright _playwright;
        private IBrowser _browser;
        private int searchCount = 0;

        public AddTeamMemberTests()
        {
            
        }

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


        [Test]
        [Category("Extent")]
        public async Task AddTeamMemberTest()
        {
            ExtentReport.exChildTest = ExtentReport.exParentTest.CreateNode("Add new team member");
            // Set a custom timeout for navigation
            var navigationOptions = new PageGotoOptions
            {
                Timeout = 60000 // 60 seconds for navigation timeout
            };

            // Set a custom timeout for click
            var clickOptions = new PageClickOptions
            {
                Timeout = 60000 // 60 seconds for click timeout
            };

            var pageFactory = new PageFactory(_page);

            var loginPage = pageFactory.GetLoginPage();

            await loginPage.GoToAsync(navigationOptions);

            await loginPage.LoginAsync();

            var mainMenuPage = pageFactory.GetMainMenuPage();

            await mainMenuPage.navigateToSetup(clickOptions);

            var accountSetupPage = pageFactory.GetAccountSetupPage();

            await accountSetupPage.ManageTeamMember();

            var searchTeamMemberPage = pageFactory.GetTeamMemberPage();

            string firstName = await searchTeamMemberPage.SearchingTeamMemberByFirstName();

            await searchTeamMemberPage.GetCountOfSearchResults();

            searchCount = searchTeamMemberPage.CountOfSearchResults();

            await accountSetupPage.AddTeamMember();

            var AddTeamMemberPage = pageFactory.GetAddTeamMemberPage();

            await AddTeamMemberPage.Add_Team_Member(firstName);

            await searchTeamMemberPage.SearchingTeamMember();

            await searchTeamMemberPage.GetCountOfSearchResults();

            Assert.That(searchCount != searchTeamMemberPage.CountOfSearchResults());

            await ExtentReport.TakeScreenshot(_page, "New Team member added successfully");
        }

    }
}