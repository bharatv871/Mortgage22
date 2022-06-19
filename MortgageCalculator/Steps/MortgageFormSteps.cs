using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MortgageCalculator.PageObjects;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MortgageCalculator
{
    [Binding]
    public class MortgageFormSteps
    {
        private IWebDriver _driver;

        public MortgageFormSteps(IWebDriver driver) 
        {
            _driver = driver;
        }

        [Given(@"I am on the mortgage form")]
        public void GivenIAmOnTheMortgageForm()
        {
  
            _driver.Navigate().GoToUrl("https://www.anz.com.au/personal/home-loans/calculators-tools/much-borrow/");
            new MortgageFormSection(_driver).NavigateToElement();
        }

        [When(@"I enter the following user details in the form")]
        public void WhenIEnterTheFollowingUserDetailsInTheForm(Table table)
        {
            dynamic row = table.CreateDynamicInstance(false);

            new UserDetailsSection(_driver).SelectApplicationType(Convert.ToString(row.ApplicationType));
            new UserDetailsSection(_driver).SelectNumberOfDependants(Convert.ToInt32(row.NumberOfDependants));
            new UserDetailsSection(_driver).SelectTypeOfProperty(Convert.ToString(row.TypeOfProperty));

            Console.WriteLine("User Details in the form is filled");
        }

        [When(@"I enter the following earning details in the form")]
        public void WhenIEnterTheFollowingEarningDetailsInTheForm(Table table)
        {
            dynamic row = table.CreateDynamicInstance(false);

            new UserEarningsSection(_driver).EnterAnnualIncome(Convert.ToInt32(row.AnnualIncome));
            new UserEarningsSection(_driver).EnterOtherIncome(Convert.ToInt32(row.OtherIncome));

            Console.WriteLine("Earning Details in the form is filled");

        }

        [When(@"I enter the following expense details in the form")]
        public void WhenIEnterTheFollowingExpenseDetailsInTheForm(Table table)
        {
            dynamic row = table.CreateDynamicInstance(false);

            new UserExpensesSection(_driver).EnterMonthlyLivingExpenses(Convert.ToInt32(row.MonthlyLivingExpenses));
                new UserExpensesSection(_driver).EnterCurrentRepayments(Convert.ToInt32(row.CurrentRepayments));
                new UserExpensesSection(_driver).EnterLoanRepayments(Convert.ToInt32(row.LoanRepayments));
                new UserExpensesSection(_driver).EnterMonthylCommitments(Convert.ToInt32(row.MonthlyCommitments));
                new UserExpensesSection(_driver).EnterCreditCardLimits(Convert.ToInt32(row.CreditCardLimits));

            Console.WriteLine("Expense Details in the form is filled");
        }

        [When(@"I click on the workout loan button")]
        public void WhenIClickOnTheWorkoutButton()
        {
            new MortgageFormSection(_driver).ClickOnWorkoutButton();

            Console.WriteLine("Loan Calculation Button Clicked");
        }

        [Then(@"the borrowing estimate should be \$(.*)")]
        public void ThenTheBorrowingEstimateShouldBe(Decimal p0)
        {
            var estimate = new MortgageFormSection(_driver).GetBorrowingEstimate();
            estimate.Equals(p0);

        }

        [When(@"I click on the start over button")]
        public void WhenIClickOnTheStartOverButton()
        {
            new MortgageFormSection(_driver).ClickOnStartOverButton();

            Console.WriteLine("Start Over Button Clicked");
        }

        [Then(@"the form is cleared")]
        public void ThenTheFormIsCleared()
        {
            new UserDetailsSection(_driver).SingleApplicationTypeIsSelected();
            new UserDetailsSection(_driver).GetNumberOfDependants().Equals(0);
            new UserDetailsSection(_driver).PropertyTypeHomeIsSelected();

            new UserEarningsSection(_driver).GetAnnualIncome().Equals(0);
            new UserEarningsSection(_driver).GetAnnualIncome().Equals(0);

            new UserEarningsSection(_driver).GetAnnualIncome().Equals(0);
            new UserEarningsSection(_driver).GetOtherIncome().Equals(0);
            new UserExpensesSection(_driver).GetMonthlyLivingExpenses().Equals(0);
            new UserExpensesSection(_driver).GetCurrentHomeLoanRepayment().Equals(0);
            new UserExpensesSection(_driver).GetOtherHomeLoanRepayment().Equals(0);
            new UserExpensesSection(_driver).GetMonthlyCommitments().Equals(0);
            new UserExpensesSection(_driver).GetCreditCardLimits().Equals(0);
            new MortgageFormSection(_driver).GetBorrowingEstimate().Equals(0);
        }



       

    }
}
