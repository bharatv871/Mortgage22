using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator
{
    class MortgageFormSection
    {
        private IWebDriver _driver;

        public MortgageFormSection(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateToElement()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(_driver.FindElement(By.Id("btnBorrowCalculater")));
            actions.Perform();
        }
       

        public MortgageFormSection ClickOnWorkoutButton()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(_driver.FindElement(By.Id("btnBorrowCalculater")));
            _driver.FindElement(By.Id("btnBorrowCalculater")).Click();
            return this;
        }

        internal void SingleApplicationTypeIsSelected()
        {
            throw new NotImplementedException();
        }



        public MortgageFormSection ClickOnStartOverButton()
        {
            _driver.FindElement(By.XPath("//button[contains(.,'Start over')]")).Click();
            return this;
        }

        

        public int GetBorrowingEstimate()
        {
            var text = _driver.FindElement(By.Id("borrowResultTextAmount")).Text.Substring(1);
            int estimate = int.Parse(text,System.Globalization.NumberStyles.Currency);
            return estimate;
        }

        
    }
}
