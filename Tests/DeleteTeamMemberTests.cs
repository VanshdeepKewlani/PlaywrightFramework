using System.Globalization;
using CsvHelper;
using PlaywrightFramework.Pages;
using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightFramework.Factories;
using Playwright_PageTest001;

namespace PlaywrightFramework.Tests
{
    [TestFixture]
    public class DeleteTeamMemberTests
    {
        protected SearchTeamMemberPage _searchPage;
        protected EditTeamMemberPage _editPage;
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IPage _page;
        private int searchCount = 0;

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

        public DeleteTeamMemberTests()
        {
            
        }

        public DeleteTeamMemberTests(SearchTeamMemberPage searchPage, EditTeamMemberPage editPage)
        {
            _searchPage = searchPage;
            _editPage = editPage;
        }

        [Test]
        [Category("Extent")]
        public async Task DeleteTeamMemberTest()
        {
            ExtentReport.exChildTest = ExtentReport.exParentTest.CreateNode("Delete a team member");
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

            string fname = await searchTeamMemberPage.SearchingTeamMember();

            await searchTeamMemberPage.GetCountOfSearchResults();

            searchCount = searchTeamMemberPage.CountOfSearchResults();

            await searchTeamMemberPage.ClickOnEditTeamMember();

            var editTeamMemberPage = pageFactory.GetEditTeamMemberPage();

            await editTeamMemberPage.VerifyTeamMemberHeading();


            await editTeamMemberPage.DeleteMember();

            await searchTeamMemberPage.SearchingTeamMemberAfterDelete(fname);

            await searchTeamMemberPage.GetCountOfSearchResults();

            Assert.That(searchCount > searchTeamMemberPage.CountOfSearchResults());

            await ExtentReport.TakeScreenshot(_page, "Team member deleted successfully");

        }
    }
}