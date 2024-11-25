using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using Microsoft.Playwright;
using NUnit.Framework;

namespace Playwright_PageTest001
{
    public class ExtentReport
    {
        public static ExtentReports extentReports;
        public static ExtentTest exParentTest;
        public static ExtentTest exChildTest;
        public static string dirpath;
        public static string pathWithFileNameExtension;
        //private readonly IPage _page;

        public static void LogReport(string testcase)
        {
            extentReports = new ExtentReports();
            dirpath = @"D:\Playwright\PlaywrightFramework\Reports\" + testcase + DateTime.Now.ToString("yyyyMMddHHmmss") + ".html";
            ExtentSparkReporter spark = new ExtentSparkReporter(dirpath);          
            spark.Config.Theme = Theme.Standard;
            extentReports.AttachReporter(spark);
        }

        public static async Task TakeScreenshot(IPage page, string stepDetail, Status status = Status.Pass)
        {
            string path = @"D:\Playwright\PlaywrightFramework\images\" + "TestExecLog_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            pathWithFileNameExtension = @path + ".png";
            await page.Locator("body").ScreenshotAsync(new LocatorScreenshotOptions { Path = pathWithFileNameExtension});
            TestContext.AddTestAttachment(pathWithFileNameExtension);
            exChildTest.Log(status, stepDetail, MediaEntityBuilder.CreateScreenCaptureFromPath(path + ".png").Build());
        }
    }
}