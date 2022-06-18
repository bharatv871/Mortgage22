using OpenQA.Selenium;
using System;

namespace MortgageCalculator.PageObjects
{
    class UserExpensesSection
    {
        private IWebDriver _driver;
        private readonly By _monthlyExpenses = By.Id("expenses");
        private readonly By _homeLoanRepayments = By.Id("homeloans");
        private readonly By _otherLoanRepayments = By.Id("otherloans");
        private readonly By _otherMonthlyCommitments = By.CssSelector("#q3q4i1+ input");
        private readonly By _creditCardLimits = By.Id("credit");

        public UserExpensesSection(IWebDriver driver)
        {
            _driver = driver;
        }

        public UserExpensesSection EnterMonthlyLivingExpenses(int monthlyLivingExpenses)
        {


            _driver.FindElement(_monthlyExpenses).SendKeys(Convert.ToString(monthlyLivingExpenses));
            return this;
        }

        public UserExpensesSection EnterCurrentRepayments(int currentRepayments)
        {

            _driver.FindElement(_homeLoanRepayments).SendKeys(Convert.ToString(currentRepayments));
            return this;
        }

        public UserExpensesSection EnterLoanRepayments(int otherLoanRepayments)
        {

            _driver.FindElement(_otherLoanRepayments).SendKeys(Convert.ToString(otherLoanRepayments));
            return this;
        }

        public UserExpensesSection EnterMonthylCommitments(int monthlyCommitments)
        {
            _driver.FindElement(_otherMonthlyCommitments).SendKeys(Convert.ToString(monthlyCommitments));
            return this;
        }

        public UserExpensesSection EnterCreditCardLimits(int creditCardLimits)
        {

            _driver.FindElement(_creditCardLimits).SendKeys(Convert.ToString(creditCardLimits));
            return this;
        }

        public int GetMonthlyLivingExpenses()
        {
            return Convert.ToInt32(_driver.FindElement(_monthlyExpenses).GetAttribute("value"));

        }
        public int GetCurrentHomeLoanRepayment()
        {
            return Convert.ToInt32(_driver.FindElement(_homeLoanRepayments).GetAttribute("value"));

        }
        public int GetOtherHomeLoanRepayment()
        {
            return Convert.ToInt32(_driver.FindElement(_otherLoanRepayments).GetAttribute("value"));

        }
        public int GetMonthlyCommitments()
        {
            return Convert.ToInt32(_driver.FindElement(_otherMonthlyCommitments).GetAttribute("value"));

        }
        public int GetCreditCardLimits()
        {
            return Convert.ToInt32(_driver.FindElement(_creditCardLimits).GetAttribute("value"));

        }
    }
}
