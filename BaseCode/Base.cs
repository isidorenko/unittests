using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Chrome;
using System;
using System.Security.Cryptography.X509Certificates;

namespace WebUITestAutomation
{

    [TestFixture]
    //[SetUpFixture]
    public class Base
    {

        protected WindowsDriver<WindowsElement> session;
        protected ChromeDriver driver;

        

        public NUnit.Framework.TestContext TestContext;
        public static ExtentReports extent;
        public ExtentTest test;


       


        [SetUp]
        //[TestInitialize]
        public void StartBrowser()
        {
            test = extent.CreateTest(NUnit.Framework.TestContext.CurrentContext.Test.Name);

        }




        [TearDown]
        //[TestCleanup]
        public void AfterTest()
        {

            var status = NUnit.Framework.TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = NUnit.Framework.TestContext.CurrentContext.Result.StackTrace;

            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("hh_mm_ss") + ".png";

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                test.Fail("Test Failed", driver is null ? null : captureScreenshot(driver, fileName));
                //test.Fail("Test Failed");
                test.Log(Status.Fail, "test failed with logtrace" + stacktrace);
            }
            else if (status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                test.Pass("Test Passed");
            }

            

        }

        

        public MediaEntityModelProvider captureScreenshot(ChromeDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();

        }







    }
}
