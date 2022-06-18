using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.PageObjects
{
    class UserDetailsSection
    {
        private IWebDriver _driver;

        public UserDetailsSection(IWebDriver driver)
        {
            _driver = driver;
        }

        public UserDetailsSection SelectApplicationType(string applicationType)
        {
            if (string.Equals(applicationType, "joint", StringComparison.OrdinalIgnoreCase))
            { _driver.FindElement(By.Id("application_type_joint")).Click(); }
            else { _driver.FindElement(By.Id("application_type_single")).Click(); }


            return this;
        }

        public bool SingleApplicationTypeIsSelected()
        {
            return _driver.FindElement(By.CssSelector("#q1q1 +ul > li")).GetAttribute("class").Contains("selected");
        }


        public bool PropertyTypeHomeIsSelected()
        {
            return _driver.FindElement(By.CssSelector("#q1q3 +ul > li")).GetAttribute("class").Contains("selected");
        }

        public UserDetailsSection SelectNumberOfDependants(int numberOfDependants)
        {
            _driver.FindElement(By.CssSelector("#q1q2 + div")).Click();
            _driver.FindElement(By.XPath("//option[" + numberOfDependants + 1 + "]")).Click();
            return this;
        }

        public UserDetailsSection SelectTypeOfProperty(string propertyType)
        {
            if (string.Equals(propertyType, "investment", StringComparison.OrdinalIgnoreCase))
            { _driver.FindElement(By.Id("borrow_type_investment")).Click(); }
            else { _driver.FindElement(By.Id("borrow_type_home")).Click(); }
            return this;
        }

        public int GetNumberOfDependants()
        {
            return Convert.ToInt32(_driver.FindElement(By.CssSelector("#q1q2 + div select")).GetAttribute("value"));

        }
    }
}
