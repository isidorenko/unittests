using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUITestAutomation;

namespace WebUITestAutomation
{
    [SetUpFixture]
    public class Setup
    {
        string BaseDirectory_Path = AppDomain.CurrentDomain.BaseDirectory;

        [OneTimeSetUp]
        //[ClassInitialize]
        public void SetUp()
        {

            //string workingDirectory = Environment.CurrentDirectory;
            //string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            //String reportPath = projectDirectory + "\\index.html";
            String reportPath = BaseDirectory_Path; //+ "\\TestReport.html";
            //String reportPath = BaseDirectory_Path + "\\TestReport.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            Base.extent = new ExtentReports();
            Base.extent.AttachReporter(htmlReporter);
            Base.extent.AddSystemInfo("Host name", "Local host");
            Base.extent.AddSystemInfo("Environment", "QA");
            Base.extent.AddSystemInfo("User name", "Vafa Abadi");



        }

        [OneTimeTearDown]
        //[TestCleanup]
        public void AfterAllTests()
        {


            Base.extent.Flush();



        }
    }
}
