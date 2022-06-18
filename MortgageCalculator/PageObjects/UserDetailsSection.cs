using OpenQA.Selenium;
using System;

namespace MortgageCalculator.PageObjects
{
    class UserDetailsSection
    {
        private IWebDriver _driver;

        private readonly By _singleApplicationType = By.CssSelector("#q1q1 +ul > li");
        private readonly By _applicationTypeJoint = By.Id("application_type_joint");
        private readonly By _applicationTypeSingle = By.Id("application_type_single");
        private readonly By _propertyTypeHome = By.CssSelector("#q1q3 +ul > li");
        private readonly By _dependantsDropdown = By.CssSelector("#q1q2 + div");
        private readonly By _borrowTypeInvestment = By.Id("borrow_type_investment");
        private readonly By _borrowTypeHome = By.Id("borrow_type_home");
        private readonly By _numberOfDependantsCount = By.CssSelector("#q1q2 + div select");


        public UserDetailsSection(IWebDriver driver)
        {
            _driver = driver;
        }

        public UserDetailsSection SelectApplicationType(string applicationType)
        {
            if (string.Equals(applicationType, "joint", StringComparison.OrdinalIgnoreCase))
            {

                _driver.FindElement(_applicationTypeJoint).Click();
            }
            else { _driver.FindElement(_applicationTypeSingle).Click(); }


            return this;
        }

        public bool SingleApplicationTypeIsSelected()
        {
            return _driver.FindElement(_singleApplicationType).GetAttribute("class").Contains("selected");
        }


        public bool PropertyTypeHomeIsSelected()
        {

            return _driver.FindElement(_propertyTypeHome).GetAttribute("class").Contains("selected");
        }

        public UserDetailsSection SelectNumberOfDependants(int numberOfDependants)
        {
            _driver.FindElement(_dependantsDropdown).Click();
            _driver.FindElement(By.XPath("//option[" + numberOfDependants + 1 + "]")).Click();
            return this;
        }

        public UserDetailsSection SelectTypeOfProperty(string propertyType)
        {
            if (string.Equals(propertyType, "investment", StringComparison.OrdinalIgnoreCase))
            {

                _driver.FindElement(_borrowTypeInvestment).Click();
            }
            else { _driver.FindElement(_borrowTypeHome).Click(); }
            return this;
        }

        public int GetNumberOfDependants()
        {
            return Convert.ToInt32(_driver.FindElement(_numberOfDependantsCount).GetAttribute("value"));

        }
    }
}
