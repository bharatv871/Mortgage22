using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using BoDi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MortgageCalculator
{
    [Binding]
    public class ScenarioHooks
    {
        private IWebDriver _driver;
        ExtentTest test = null;
        public static ExtentReports extent;
        public TestContext TestContext { get; set; }

        private readonly IObjectContainer _container;

        public ScenarioHooks(IObjectContainer container)
        {
            _container = container;
        }

        public ScenarioHooks()
        {
        }

        [BeforeTestRun]
        public static void ExtentStart()
        {
            extent = new ExtentReports();
            var dateTime = DateTime.Now.ToString("dd MMMM yyyy HH mm ss").ToString();
            var htmlreporter = new ExtentHtmlReporter(@"C:\Users\bhara\OneDrive\Documents\MortgageCal\Mortgage22\MortgageCalculator\Reports\" + dateTime + "\\");

            extent.AttachReporter(htmlreporter);
        }

        [BeforeScenario]
        public void StartWebDriver()
        {
            _driver = new ChromeDriver();

            _container.RegisterInstanceAs<IWebDriver>(_driver);
            _driver.Manage().Window.Maximize();

            var title = ScenarioContext.Current.ScenarioInfo.Title;

            test = extent.CreateTest(DateTime.Today.ToString() + title);
            test.Log(Status.Info, "Navigated to the mortgage form");
        }

         [AfterScenario]
        public void DisposeWebDriver()
        {


            test.Log(Status.Pass, "Test Pass");

            _driver.Close();
            _driver.Quit();
            _driver.Dispose();

            extent.Flush();
        }

    }
}
