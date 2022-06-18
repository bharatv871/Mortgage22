using OpenQA.Selenium;
using System;

namespace MortgageCalculator.PageObjects
{
    class UserEarningsSection
    {
        private IWebDriver _driver;
        By _annualIncome = By.CssSelector("#q2q1i1 + input");
        By _otherIncome = By.CssSelector("#q2q2i1 + input");


        public UserEarningsSection(IWebDriver driver)
        {
            _driver = driver;
        }

        public UserEarningsSection EnterAnnualIncome(int annualIncome)
        {
            _driver.FindElement(_annualIncome).SendKeys(Convert.ToString(annualIncome));
            return this;
        }

        public UserEarningsSection EnterOtherIncome(int otherIncome)
        {
            _driver.FindElement(_otherIncome).SendKeys(Convert.ToString(otherIncome));
            return this;
        }

        public int GetAnnualIncome()
        {
            return Convert.ToInt32(_driver.FindElement(_annualIncome).GetAttribute("value"));

        }
        public int GetOtherIncome()
        {
            return Convert.ToInt32(_driver.FindElement(_otherIncome).GetAttribute("value"));

        }
    }
}
