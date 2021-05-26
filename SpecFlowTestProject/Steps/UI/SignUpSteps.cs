using System;
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
    public class SignUpSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly CompanySignUpPage _companySignUpPage;
        private readonly SignInPage _signInPage;
        private readonly IWebDriver _webDriver;

        public SignUpSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _companySignUpPage = new CompanySignUpPage(_webDriver);
            _signInPage = new SignInPage(_webDriver);
        }

        [Given(@"Sign up page is opened")]
        public void GivenSignInPageIsOpened()
        {
            _companySignUpPage.GoToRegistrationPage();
        }

        [When(@"I click Submit button")]
        public void WhenIClickLogInButton()
        {
            _companySignUpPage.ClickSubmitButton();
            
            Thread.Sleep(2000);
        }

        [When(@"I register with valid data")]
        public void IRegistrateWithValidData(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            SignUp((string)data.first_name, (string)data.last_name, (string)data.email, (string)data.password, 
                (string)data.confirm_password, (string)data.phone);
        }

        public void SignUp(string firstName, string lastName, string email, string password, string confirmPassword,
            string phone)
        {
            email = CreateUniqueEmail();
            
            _companySignUpPage.SetFirstName(firstName);
            _companySignUpPage.SetLastName(lastName);
            _companySignUpPage.SetEmail(email);
            _companySignUpPage.SetPassword(password);
            _companySignUpPage.SetConfirmPassword(confirmPassword);
            _companySignUpPage.SetPhone(phone);
        }

        private string CreateUniqueEmail()
        {
            var date = DateTime.Now.ToString("yyyy.MM.dd.hh.mm.ss");
            var email = $"mabel.{date}@gmail.com";

            return email;
        }

        [When(@"I register with data")]
        public void IRegistrateWithData(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            SignUp((string)data.first_name, (string)data.last_name, (string)data.email, (string)data.password, 
                (string)data.confirm_password, (string)data.phone);
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
        
        public class RegistrationModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword{ get; set; }
            public string PhoneNumber { get; set; }

            public RegistrationModel()
            {
                var date = DateTime.Now.ToString("yyyy.MM.dd.hh.mm.ss");
                Email = $"mabel.{date}@gmail.com";
            }
        }
    }
}