using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.PageObjects
{
    class UserEarningsSection
    {
        private IWebDriver _driver;

        public UserEarningsSection(IWebDriver driver)
        {
            _driver = driver;
        }

        public UserEarningsSection EnterAnnualIncome(int annualIncome)
        {
            _driver.FindElement(By.CssSelector("#q2q1i1 + input")).SendKeys(Convert.ToString(annualIncome));
            return this;
        }

        public UserEarningsSection EnterOtherIncome(int otherIncome)
        {
            _driver.FindElement(By.CssSelector("#q2q2i1 + input")).SendKeys(Convert.ToString(otherIncome));
            return this;
        }

        public int GetAnnualIncome()
        {
            return Convert.ToInt32(_driver.FindElement(By.CssSelector("#q2q1i1 + input")).GetAttribute("value"));

        }
        public int GetOtherIncome()
        {
            return Convert.ToInt32(_driver.FindElement(By.CssSelector("#q2q2i1 + input")).GetAttribute("value"));

        }
    }
}
