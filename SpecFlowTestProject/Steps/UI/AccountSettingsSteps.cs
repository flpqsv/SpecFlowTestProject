using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NewBookModelsApiTests.Models.Auth;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.POM;
using SpecflowTestProject;
using TechTalk.SpecFlow;

namespace SpecFlowTestProject.Steps.UI
{
    [Binding]
    public sealed class AccountSettingsSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly AccountSettingsPage _accountSettingsPage;
        private readonly SignInPage _signInPage;
        private readonly IWebDriver _webDriver;

        public AccountSettingsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _signInPage = new SignInPage(_webDriver);
            _accountSettingsPage = new AccountSettingsPage(_webDriver);
        }
        
        [Given(@"Account settings page is open")]
        public void GivenAccountSettingsPageIsOpen()
        {
            _accountSettingsPage.GoToEditPage();
        }
        
        [Given(@"Client is authorized")]
        public void GivenClientIsAuthorized()
        {
            var user = _scenarioContext.Get<ClientAuthModel>(Context.User);

            _signInPage.OpenPage();
            _signInPage.SetEmail(user.User.Email);
            _signInPage.SetPassword(Constants.Password);
            _signInPage.ClickLoginButton();
            Thread.Sleep(1000);
        }

        [When(@"I click on edit email button")]
        public void WhenIClickOnEditEmailButton()
        {
            _accountSettingsPage.ClickChangeEmail();
            Thread.Sleep(1000);
        }

        [When(@"I insert valid password for changing email")]
        public void WhenInsertValidPasswordForChangingEmail()
        {
            _accountSettingsPage.ConfirmPasswordForEmailChange(Constants.Password);
        }

        [When(@"I insert unique email in email field")]
        public void WhenInsertUniqueEmailInEmailField()
        {
            _accountSettingsPage.SetNewEmail(CreateUniqueEmail());
        }
        
        private string CreateUniqueEmail()
        {
            var user = _scenarioContext.Get<ClientAuthModel>(Context.User);
            var email = $"new{user.User.Email}";

            return email;
        }

        [When(@"I click on save button")]
        public void WhenIClickOnSaveButton()
        {
            _accountSettingsPage.ClickSave();
            Thread.Sleep(1000);
        }

        [When(@"I click on edit phone number button")]
        public void WhenIClickOnEditPhoneNumberButton()
        {
            _accountSettingsPage.ClickChangeNumber();
            Thread.Sleep(1000);
        }

        [When(@"I insert valid password for changing phone number")]
        public void WhenIInsertValidPasswordForChangingPhoneN()
        {
            _accountSettingsPage.ConfirmPasswordForNumberChange(Constants.Password);
        }

        [When(@"I insert new phone number in phone field")]
        public void WhenIInsertNewPhoneNumberInPhoneField()
        {
            _accountSettingsPage.SetNewNumber();
        }
        
        [When(@"I click on log out button")]
        public void WhenIClickOnLogOutButton()
        {
            _accountSettingsPage.ClickLogOut();
        }
        
        [When(@"I click on profile tab")]
        public void WhenIClickOnProfileTab()
        {
            _accountSettingsPage.ClickProfile();
        }

        [When(@"I click on profile edit button")]
        public void WhenIClickOnProfileEditButton()
        {
            _accountSettingsPage.ClickEditProfile();
        }

        [When(@"I insert company name")]
        public void WhenIInsertCompanyName()
        {
            _accountSettingsPage.SetNewCompanyName("My Company");
        }

        [When(@"I insert conpany website")]
        public void WhenIInsertConpanyWebsite()
        {
            _accountSettingsPage.SetNewCompanyWebsite("mycompany.com");
        }

        [When(@"I isert description")]
        public void WhenIIsertDescription()
        {
            _accountSettingsPage.SetDescription("My description.");
        }
        
        [Then(@"New email is being saved")]
        public void ThenNewEmailIsBeingSaved()
        {
            var user = _scenarioContext.Get<ClientAuthModel>(Context.User);
            
            Assert.AreEqual($"new{user.User.Email}", _accountSettingsPage.GetNewEmail());
        }

        [Then(@"New phone number is being saved")]
        public void ThenNewPhoneNumberIsBeingSaved()
        {
            Assert.AreEqual("999.111.9999", _accountSettingsPage.GetNewNumber());
        }

        [Then(@"Client is not authorized")]
        public void ThenClientIsNotAuthorized()
        {
            Assert.AreEqual("https://newbookmodels.com/auth/signin", _webDriver.Url);
        }

        [Then(@"Company information is being saved")]
        public void ThenCompanyInformationIsBeingSaved()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual("My Company", _accountSettingsPage.GetCompanyName());
                Assert.AreEqual("HTTP://MYCOMPANY.COM", _accountSettingsPage.GetCompanyWebsite());
                Assert.AreEqual("My description.", _accountSettingsPage.GetDescription());
            });
        }
    }
}