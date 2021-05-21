using System;
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
    public class SignUpSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly CompanySignUpPage _companySignUpPage;

        public SignUpSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _companySignUpPage = new CompanySignUpPage(webDriver);
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
        }

        [When(@"I registrate with valid data")]
        public void IRegistrateWithValidData(Table table)
        {
            var registrationModels = table.CreateInstance<RegistrationModel>();

            _companySignUpPage.SetFirstName(registrationModels.FirstName);
            _companySignUpPage.SetLastName(registrationModels.LastName);
            _companySignUpPage.SetEmail(registrationModels.Email);
            _companySignUpPage.SetPassword(registrationModels.Password);
            _companySignUpPage.SetConfirmPassword(registrationModels.ConfirmPassword);
            _companySignUpPage.SetPhone(registrationModels.PhoneNumber);
        }
        
        [When(@"I registrate with data")]
        public void IRegistrateWithData(Table table)
        {
            var registrationModels = table.CreateInstance<RegistrationModel>();

            _companySignUpPage.SetFirstName(registrationModels.FirstName);
            _companySignUpPage.SetLastName(registrationModels.LastName);
            _companySignUpPage.SetEmail(registrationModels.Email);
            _companySignUpPage.SetPassword(registrationModels.Password);
            _companySignUpPage.SetConfirmPassword(registrationModels.ConfirmPassword);
            _companySignUpPage.SetPhone(registrationModels.PhoneNumber);
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