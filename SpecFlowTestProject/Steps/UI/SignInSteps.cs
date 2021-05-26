using System.Linq;
using System.Threading;
using NewBookModelsApiTests.Models.Auth;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.POM;
using SpecflowTestProject;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowTestProject.Steps.UI
{
    [Binding]
    public class SignInSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly SignInPage _signInPage;
        private readonly AccountSettingsPage _accountSettingsPage;
        private readonly IWebDriver _webDriver;

        public SignInSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _signInPage = new SignInPage(_webDriver);
            _accountSettingsPage = new AccountSettingsPage(_webDriver);
        }

        [Given(@"Sign in page is opened")]
        public void GivenSignInPageIsOpened()
        {
            _signInPage.OpenPage();
        }

        [When(@"I input valid email in email field")]
        public void WhenIInputEmailOfCreatedClientInEmailField()
        {
            var user = _scenarioContext.Get<ClientAuthModel>(Context.User);
            _signInPage.SetEmail(user.User.Email);
        }

        [When(@"I input valid password in password field")]
        public void WhenIInputPasswordOfCreatedClientInEmailField()
        {
            _signInPage.SetPassword(Constants.Password);
        }

        [When(@"I click Log in button")]
        public void WhenIClickLogInButton()
        {
            _signInPage.ClickLoginButton();
        }

        [When(@"I login with data")]
        public void ILoginWithData(Table table)
        {
            var loginModels = table.CreateSet<LoginModel>().ToList();

            _signInPage.SetEmail(loginModels[0].Email);
            _signInPage.SetPassword(loginModels[0].Password);
            _signInPage.ClickLoginButton();
        }
        
        [When(@"I login with invalid email")]
        public void ILoginWithInvalidEmail(Table table)
        {
            var loginModels = table.CreateSet<LoginModel>().ToList();

            _signInPage.SetEmail(loginModels[0].Email);
            _signInPage.SetPassword(loginModels[0].Password);
            _signInPage.ClickLoginButton();
        }
        
        [When(@"I login with invalid password")]
        public void ILoginWithInvalidPassword(Table table)
        {
            var loginModels = table.CreateSet<LoginModel>().ToList();

            _signInPage.SetEmail(loginModels[0].Email);
            _signInPage.SetPassword(loginModels[0].Password);
            _signInPage.ClickLoginButton();
        }
        
        [Then(@"Successfully logged in NewBookModels as created client")]
        public void ThenSuccessfullyLoggedInNewBookModelAsCreatedClient()
        {
            Thread.Sleep(2000);
            _accountSettingsPage.GoToEditPage();
            Assert.AreEqual("https://newbookmodels.com/account-settings/account-info/edit", _webDriver.Url);
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

        public class LoginModel
        {
            public string Email{ get; set; }
            public string Password { get; set; }
        }
    }
}