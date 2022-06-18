using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.PageObjects
{
    class UserExpensesSection
    {
        private IWebDriver _driver;

        public UserExpensesSection(IWebDriver driver)
        {
            _driver = driver;
        }

        public UserExpensesSection EnterMonthlyLivingExpenses(int monthlyLivingExpenses)
        {
            _driver.FindElement(By.Id("expenses")).SendKeys(Convert.ToString(monthlyLivingExpenses));
            return this;
        }

        public UserExpensesSection EnterCurrentRepayments(int currentRepayments)
        {
            _driver.FindElement(By.Id("homeloans")).SendKeys(Convert.ToString(currentRepayments));
            return this;
        }

        public UserExpensesSection EnterLoanRepayments(int otherLoanRepayments)
        {
            _driver.FindElement(By.Id("otherloans")).SendKeys(Convert.ToString(otherLoanRepayments));
            return this;
        }

        public UserExpensesSection EnterMonthylCommitments(int monthlyCommitments)
        {
            _driver.FindElement(By.CssSelector("#q3q4i1+ input")).SendKeys(Convert.ToString(monthlyCommitments));
            return this;
        }

        public UserExpensesSection EnterCreditCardLimits(int creditCardLimits)
        {
            _driver.FindElement(By.Id("credit")).SendKeys(Convert.ToString(creditCardLimits));
            return this;
        }

        public int GetMonthlyLivingExpenses()
        {
            return Convert.ToInt32(_driver.FindElement(By.Id("expenses")).GetAttribute("value"));

        }
        public int GetCurrentHomeLoanRepayment()
        {
            return Convert.ToInt32(_driver.FindElement(By.Id("homeloans")).GetAttribute("value"));

        }
        public int GetOtherHomeLoanRepayment()
        {
            return Convert.ToInt32(_driver.FindElement(By.Id("otherloans")).GetAttribute("value"));

        }
        public int GetMonthlyCommitments()
        {
            return Convert.ToInt32(_driver.FindElement(By.CssSelector("#q3q4i1+ input")).GetAttribute("value"));

        }
        public int GetCreditCardLimits()
        {
            return Convert.ToInt32(_driver.FindElement(By.Id("credit")).GetAttribute("value"));

        }
    }
}
