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

        public MortgageFormSection SelectApplicationType(string applicationType)
        {
            NavigateToElement();
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

        public MortgageFormSection SelectNumberOfDependants(int numberOfDependants)
        {
            _driver.FindElement(By.CssSelector("#q1q2 + div")).Click();
            _driver.FindElement(By.XPath("//option[" + numberOfDependants + 1 + "]")).Click();
            return this;
        }

        public MortgageFormSection SelectTypeOfProperty(string propertyType)
        {
            if (string.Equals(propertyType, "investment", StringComparison.OrdinalIgnoreCase))
            { _driver.FindElement(By.Id("borrow_type_investment")).Click(); }
            else { _driver.FindElement(By.Id("borrow_type_home")).Click(); }
            return this;
        }

        public MortgageFormSection EnterAnnualIncome(int annualIncome)
        {
            _driver.FindElement(By.CssSelector("#q2q1i1 + input")).SendKeys(Convert.ToString(annualIncome));
            return this;
        }

        public MortgageFormSection EnterMonthlyLivingExpenses(int monthlyLivingExpenses)
        {
            _driver.FindElement(By.Id("expenses")).SendKeys(Convert.ToString(monthlyLivingExpenses));
            return this;
        }

        public MortgageFormSection EnterCurrentRepayments(int currentRepayments)
        {
            _driver.FindElement(By.Id("homeloans")).SendKeys(Convert.ToString(currentRepayments));
            return this;
        }

        public MortgageFormSection EnterLoanRepayments(int otherLoanRepayments)
        {
            _driver.FindElement(By.Id("otherloans")).SendKeys(Convert.ToString(otherLoanRepayments));
            return this;
        }

        public MortgageFormSection EnterMonthylCommitments(int monthlyCommitments)
        {
            _driver.FindElement(By.CssSelector("#q3q4i1+ input")).SendKeys(Convert.ToString(monthlyCommitments));
            return this;
        }

        public MortgageFormSection EnterCreditCardLimits(int creditCardLimits)
        {
            _driver.FindElement(By.Id("credit")).SendKeys(Convert.ToString(creditCardLimits));
            return this;
        }

        public MortgageFormSection EnterOtherIncome(int otherIncome)
        {
            _driver.FindElement(By.CssSelector("#q2q2i1 + input")).SendKeys(Convert.ToString(otherIncome));
            return this;
        }

        public MortgageFormSection ClickOnWorkoutButton()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(_driver.FindElement(By.Id("btnBorrowCalculater")));
            _driver.FindElement(By.Id("btnBorrowCalculater")).Click();
            return this;
        }
        public int GetNumberOfDependants()
        {
            return Convert.ToInt32(_driver.FindElement(By.CssSelector("#q1q2 + div select")).GetAttribute("value"));

        }
        

        public int GetAnnualIncome() {
          return Convert.ToInt32(_driver.FindElement(By.CssSelector("#q2q1i1 + input")).GetAttribute("value"));
        
        }
        public int GetOtherIncome() {
            return Convert.ToInt32(_driver.FindElement(By.CssSelector("#q2q2i1 + input")).GetAttribute("value"));

        }
        public int GetMonthlyLivingExpenses() {
            return Convert.ToInt32(_driver.FindElement(By.Id("expenses")).GetAttribute("value"));
       
        }
        public int GetCurrentHomeLoanRepayment() {
            return Convert.ToInt32(_driver.FindElement(By.Id("homeloans")).GetAttribute("value"));
           
        }
        public int GetOtherHomeLoanRepayment() {
            return Convert.ToInt32(_driver.FindElement(By.Id("otherloans")).GetAttribute("value"));
            
        }
        public int GetMonthlyCommitments() {
            return Convert.ToInt32(_driver.FindElement(By.CssSelector("#q3q4i1+ input")).GetAttribute("value"));
            
        }
        public int GetCreditCardLimits() {
            return Convert.ToInt32(_driver.FindElement(By.Id("credit")).GetAttribute("value"));
            
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
