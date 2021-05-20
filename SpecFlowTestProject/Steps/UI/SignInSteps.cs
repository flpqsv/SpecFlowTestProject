using System.Linq;
using NewBookModelsApiTests.Models.Auth;
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

        public SignInSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _signInPage = new SignInPage(webDriver);
        }

        [Given(@"Sign in page is opened")]
        public void GivenSignInPageIsOpened()
        {
            _signInPage.OpenPage();
        }

        [When(@"I input email of created client in email field")]
        public void WhenIInputEmailOfCreatedClientInEmailField()
        {
            var user = _scenarioContext.Get<ClientAuthModel>(Context.User);
            _signInPage.SetEmail(user.User.Email);
        }

        [When(@"I input password of created client in password field")]
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

        public class LoginModel
        {
            public string Email{ get; set; }
            public string Password { get; set; }
        }
    }
}