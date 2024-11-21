using NUnit.Framework;
using Playwright_PageTest001;

[SetUpFixture]
public class Setup
{
    [OneTimeSetUp]
    public static void AssemblyLevelSetup()
    {
        //Create Extent Report
        ExtentReport.LogReport("Test Report");
    }

    [OneTimeTearDown]
    public static void AssemblyLevelTearDown()
    {
        ExtentReport.extentReports.Flush();
    }
}