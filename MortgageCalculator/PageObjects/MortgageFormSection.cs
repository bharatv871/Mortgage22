using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace MortgageCalculator
{
    class MortgageFormSection
    {
        private IWebDriver _driver;
        private readonly By _workoutLoanButton = By.Id("btnBorrowCalculater");
        private readonly By _startOverButton = By.XPath("//button[contains(.,'Start over')]");
        private readonly By _borrowingEstimate = By.Id("borrowResultTextAmount");
        ExtentTest test = null;
        public static ExtentReports extent;

        public MortgageFormSection(IWebDriver driver)
        {
            _driver = driver;
        }

        

        public void NavigateToElement()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(_driver.FindElement(_workoutLoanButton));
            actions.Perform();
        }


        public MortgageFormSection ClickOnWorkoutButton()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(_driver.FindElement(_workoutLoanButton));
            _driver.FindElement(_workoutLoanButton).Click();
            return this;
        }

        public MortgageFormSection ClickOnStartOverButton()
        {
            _driver.FindElement(_startOverButton).Click();
            return this;
        }



        public int GetBorrowingEstimate()
        {
            var text = _driver.FindElement(_borrowingEstimate).Text.Substring(1);
            int estimate = int.Parse(text, System.Globalization.NumberStyles.Currency);
            return estimate;
        }


    }
}
