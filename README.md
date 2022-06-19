# MortgageCalculator
 

#Setup#

1. Download repo to local folder. Open solution file "..\Mortgage22\MortgageCalculator.sln" in visual studio . Run a "Restore all Nuget packages". Rebuild solution. Solution should build without errors.
2. The repo is using MSBuild and VSTest. Need VSTest to run tests through command line.

#Test#

1. The tests can be run on IDE using test explorer.
2. The tests can be run through command line by running the following command :

C:\...\Mortgage22\MortgageCalculator\bin\Debug>"c:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" MortgageCalculator.dll

#Generate Reports#

Two types of reports can be generated :

1. Using Vstest by adding //logger:trx at the end.  This generates trx reports which are xml based and can be opened in an IDE like visual studio. They can be found in C:\...\Mortgage22\MortgageCalculator\bin\Debug\TestResults

eg:

C:\...\Mortgage22\MortgageCalculator\bin\Debug>"c:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" MortgageCalculator.dll /logger:trx

2. The solution uses a 3rd party library intergartion Extent Reports.  These reports are set to be generated everytime the tests run from both command line or the IDE.
These reports can be found in C:\...\Mortgage22\MortgageCalculator\Reports.  The reports can be opened on any browser.

#Results#

1. The TRX results can be found in :

C:\...\Mortgage22\MortgageCalculator\bin\Debug\TestResults

2. The extent report results can be found in :

C:\...\Mortgage22\MortgageCalculator\Reports

The results are not overwritten. They produce new results every time and are marked by time to be unique.

Screen recordings can be found in the C:\...\Mortgage22\Screen Recordings folder .
