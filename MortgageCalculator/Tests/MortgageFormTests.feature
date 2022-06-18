Feature: MortgageFormTests
	Simple calculator for calculating


Scenario: Calculate Mortgage
	Given I am on the mortgage form
	When I enter the following user details in the form
	| Application type | Number of dependants | Type of property |
	| Single           | 0                    | Home             |
	And I enter the following earning details in the form
	| Annual income | Other income |
	| 80000         | 10000        |
	And I enter the following expense details in the form
	| Monthly living expenses | Current repayments | Loan repayments | Monthly commitments | Credit card limits |
	| 500                     | 0                  | 100             | 0                   | 10000              |
	And I click on the workout loan button
	Then the borrowing estimate should be $501,000


Scenario: Clear Form after Loan is calculated
	Given I am on the mortgage form
	When I enter the following user details in the form
	| Application type | Number of dependants | Type of property |
	| Single           | 0                    | Home             |
	And I enter the following earning details in the form
	| Annual income | Other income |
	| 80000         | 10000        |
	And I enter the following expense details in the form
	| Monthly living expenses | Current repayments | Loan repayments | Monthly commitments | Credit card limits |
	| 500                     | 0                  | 100             | 0                   | 10000              |
	And I click on the workout loan button
	And I click on the start over button
	Then the form is cleared

	Scenario: Clear Form before Loan is calculated
	Given I am on the mortgage form
	When I enter the following user details in the form
	| Application type | Number of dependants | Type of property |
	| Single           | 0                    | Home             |
	And I enter the following earning details in the form
	| Annual income | Other income |
	| 80000         | 10000        |
	And I enter the following expense details in the form
	| Monthly living expenses | Current repayments | Loan repayments | Monthly commitments | Credit card limits |
	| 500                     | 0                  | 100             | 0                   | 10000              |
	And I click on the start over button
	Then the form is cleared