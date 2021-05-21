using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.POM;
using SpecflowTestProject;
using TechTalk.SpecFlow;

namespace SpecFlowTestProject.Steps.UI
{
    [Binding]
    public class CompanySignUpSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;
        private readonly CompanySignUpPage _companySignUpPage;
        private readonly SignInPage _signInPage;

        public CompanySignUpSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _companySignUpPage = new CompanySignUpPage(_webDriver);
            _signInPage = new SignInPage(_webDriver);
        }

        [Then(@"Successfully logged in NewBookModels as created client")]
        public void ThenSuccessfullyLoggedInNewBookModelAsCreatedClient()
        {
            Assert.IsTrue(_companySignUpPage.IsPageTitleVisible());
        }
        
        [Then(@"Error message wrong email is displayed on Login page")]
        public void ThenErrorMessageWrongEmailIsDisplayedOnLoginPage()
        {
            Assert.AreEqual("Invalid Email", _signInPage.GetWrongEmailMessage());
        }
        
        [Then(@"Error message wrong password is displayed on Login page")]
        public void ThenErrorMessageWrongPasswordIsDisplayedOnLoginPage()
        {
            Assert.AreEqual("Please enter a correct email and password.", _signInPage.GetWrongPasswordMessage());
        }
        
        [Then(@"Error message account is blocked is displayed on Login page")]
        public void ThenErrorMessageAccountIsBlockedIsDisplayedOnLoginPage()
        {
            Assert.AreEqual("User account is blocked.", _signInPage.GetUserAccountBlockMessage());
        }
        
        [Then(@"Successfully created account")]
        public void SuccessfullyCreatedAccount()
        {
            Assert.AreEqual("https://newbookmodels.com/join/company", _webDriver.Url);
        }
        
        [Then(@"Account is not created")]
        public void AccountIsNotCreated()
        {
            Assert.AreNotEqual("https://newbookmodels.com/join/company", _webDriver.Url);
        }
    }
}