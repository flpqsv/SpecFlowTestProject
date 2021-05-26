using System.Threading;
using OpenQA.Selenium;

namespace SeleniumTests.POM
{
    public class AccountSettingsPage
    {
        private readonly IWebDriver _webDriver;

        private static readonly By _genInfoEditButton = By.XPath("//div[1]/nb-account-info-general-information[1]/form[1]/div[1]/div[1]/nb-edit-switcher[1]/div[1]/div[1]");
        private static readonly By _firstNameField = By.XPath("div[1]/nb-account-info-general-information[1]/form[1]/div[2]/div[1]/common-input[1]/label[1]/input[1]");
        private static readonly By _lastNameField = By.XPath("//div[1]/nb-account-info-general-information[1]/form[1]/div[2]/div[1]/common-input[2]/label[1]/input[1]");
        private static readonly By _companyLocationField = By.XPath("//div[1]/nb-account-info-general-information[1]/form[1]/div[2]/div[1]/common-google-maps-autocomplete[1]/label[1]/input[1]");
        private static readonly By _companyLocationMatch = By.CssSelector("[class='pac-matched']");
        private static readonly By _industryField = By.XPath("//div[1]/nb-account-info-general-information[1]/form[1]/div[2]/div[1]/common-input[3]/label[1]/input[1]");
        
        private static readonly By _emailStatus = By.XPath("//nb-paragraph[1]/div[1]/div[1]/div[2]/span[1]");
        private static readonly By _changeEmailButton = By.XPath("//div[1]/nb-account-info-email-address[1]/form[1]/div[1]/div[1]/nb-edit-switcher[1]/div[1]/div[1]");
        private static readonly By _currentPasswordForEmailField = By.XPath("//div[1]/nb-account-info-email-address[1]/form[1]/div[2]/div[1]/common-input[1]/label[1]/input[1]");
        private static readonly By _newEmailField = By.XPath("//div[1]/nb-account-info-email-address[1]/form[1]/div[2]/div[1]/common-input[2]/label[1]/input[1]");
        
        private static readonly By _changePasswordButton = By.XPath("//div[1]/nb-account-info-password[1]/form[1]/div[1]/div[1]/nb-edit-switcher[1]/div[1]/div[1]");
        private static readonly By _currentPasswordForPasswordChangeField = By.XPath("//div[1]/nb-account-info-password[1]/form[1]/div[2]/div[1]/common-input[1]/label[1]/input[1]");
        private static readonly By _newPasswordField = By.XPath("//div[1]/nb-account-info-password[1]/form[1]/div[2]/div[1]/common-input[2]/label[1]/input[1]");
        private static readonly By _confirmNewPasswordField = By.XPath("//div[1]/nb-account-info-password[1]/form[1]/div[2]/div[1]/common-input[3]/label[1]/input[1]");
        
        private static readonly By _cardNameField = By.XPath("//nb-stripe-card-bind[1]/div[1]/form[1]/common-input[1]/label[1]/input[1]");
        private static readonly By _cardNumberField = By.XPath("//div[1]/form[1]/common-input[1]/label[1]/input[1]");
        private static readonly By _cardYearField = By.XPath("//div[1]/form[1]/common-input[1]/label[1]/input[1]");
        private static readonly By _cardCVVField = By.XPath("//div[1]/form[1]/common-input[1]/label[1]/input[1]");
       
        private static readonly By _editPhoneNumberButton = By.XPath("//div[1]/nb-account-info-phone[1]/div[1]/div[1]/nb-edit-switcher[1]/div[1]/div[1]");
        private static readonly By _currentPasswordForNumberChangeField = By.XPath("//div[1]/nb-account-info-phone[1]/div[2]/div[1]/form[1]/common-input[1]/label[1]/input[1]");
        private static readonly By _newNumberField = By.XPath("//div[1]/form[1]/common-input-phone[1]/label[1]/input[1]");
        
        private static readonly By _saveChangesButton = By.XPath("//button[contains(text(),'Save Changes')]");
        private static readonly By _logOutButton = By.XPath("//div[contains(text(),'Log out of your account')]");
        
        private static readonly By _profileButton = By.XPath("//div[contains(text(),'PROFILE')]");
        private static readonly By _editProfileButton = By.XPath("//nb-profile-settings[1]/div[1]/div[1]/div[1]");
        private static readonly By _companyNameField = By.XPath("//div[1]/div[2]/common-input[1]/label[1]/input[1]");
        private static readonly By _companyWebsiteField = By.XPath("//div[2]/div[2]/common-input[1]/label[1]/input[1]");
        private static readonly By _descriptionField = By.XPath("//div[1]/div[1]/common-textarea[1]/label[1]/textarea[1]");
        
        private static readonly By _companyName = By.XPath("//nb-profile-settings-view[1]/div[1]/div[2]/div[1]/div[1]");
        private static readonly By _companyWebsite = By.XPath("//a[@target='_blank']");
        private static readonly By _description = By.XPath("//nb-profile-settings-view[1]/div[1]/div[3]");
        
        private static readonly By _newFirstName = By.XPath("//div[1]/nb-account-info-general-information[1]/form[1]/div[2]/div[1]/common-input[1]/label[1]/input[1]");
        private static readonly By _newLastName = By.XPath("//div[1]/nb-account-info-general-information[1]/form[1]/div[2]/div[1]/common-input[2]/label[1]/input[1]");
        private static readonly By _newLocation = By.XPath("//div[1]/nb-account-info-general-information[1]/form[1]/div[2]/div[1]/common-google-maps-autocomplete[1]/label[1]/input[1]");
        private static readonly By _newIndustry = By.XPath("//div[1]/nb-account-info-general-information[1]/form[1]/div[2]/div[1]/common-input[3]/label[1]/input[1]");
        private static readonly By _newEmail = By.XPath("//div[1]/nb-account-info-email-address[1]/form[1]/div[2]/div[1]/nb-paragraph[1]/div[1]/div[1]/div[1]/span[1]");
        private static readonly By _newNumber = By.XPath("//div[2]/div[1]/nb-paragraph[2]/div[1]/span[1]");
        
        private static readonly By _errorMessageWrongPassword = By.XPath("//span[contains(text(),'Invalid old password.')]");

        public AccountSettingsPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AccountSettingsPage GoToEditPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/account-info/edit");
            Thread.Sleep(1000);
            return this;
        }

        public AccountSettingsPage ClickEditGenInfo()
        {
            _webDriver.FindElement(_genInfoEditButton).Click();
            Thread.Sleep(2000);
            return this;
        }
        
        public AccountSettingsPage ClickChangeEmail()
        {
            _webDriver.FindElement(_changeEmailButton).Click();
            return this;
        }
        
        public AccountSettingsPage ClickChangePassword()
        {
            _webDriver.FindElement(_changePasswordButton).Click();
            return this;
        }
        
        public AccountSettingsPage ClickChangeNumber()
        {
            _webDriver.FindElement(_editPhoneNumberButton).Click();
            return this;
        }
        
        public AccountSettingsPage ClickProfile()
        {
            _webDriver.FindElement(_profileButton).Click();
            return this;
        }
        
        public AccountSettingsPage ClickEditProfile()
        {
            _webDriver.FindElement(_editProfileButton).Click();
            return this;
        }
        
        public AccountSettingsPage ClickSave()
        {
            _webDriver.FindElement(_saveChangesButton).Click();
            return this;
        }

        public AccountSettingsPage ClickLogOut()
        {
            _webDriver.FindElement(_logOutButton).Click();
            return this;
        }

        public AccountSettingsPage SetNewFirstName(string name)
        {
            _webDriver.FindElement(_firstNameField).Clear();
            _webDriver.FindElement(_firstNameField).SendKeys(name);
            return this;
        }
        
        public AccountSettingsPage SetNewLastName(string name)
        {
            _webDriver.FindElement(_lastNameField).Clear();
            _webDriver.FindElement(_lastNameField).SendKeys(name);
            return this;
        }

        public AccountSettingsPage SetNewCompanyLocation(string location)
        {
            _webDriver.FindElement(_companyLocationField).Clear();
            _webDriver.FindElement(_companyLocationField).SendKeys(location);
            Thread.Sleep(1500);
            _webDriver.FindElement(_companyLocationMatch).Click();
            return this;
        }
        
        public AccountSettingsPage SetNewIndustry(string industry)
        {
            _webDriver.FindElement(_industryField).Clear();
            _webDriver.FindElement(_industryField).SendKeys(industry);
            return this;
        }

        public string GetNewFirstName()
        {
            var name = _webDriver.FindElement(_newFirstName).Text;
            return name;
        }
        
        public string GetNewLastName()
        {
            var name = _webDriver.FindElement(_newLastName).Text;
            return name;
        }
        
        public string GetNewLocation()
        {
            var name = _webDriver.FindElement(_newLocation).Text;
            return name;
        }
        
        public string GetNewIndustry()
        {
            var name = _webDriver.FindElement(_newIndustry).Text;
            return name;
        }
        
        public string GetNewEmail()
        {
            var name = _webDriver.FindElement(_newEmail).Text;
            return name;
        }
        
        public string GetEmailStatus()
        {
            var name = _webDriver.FindElement(_emailStatus).Text;
            return name;
        }
        
        public string GetNewNumber()
        {
            var name = _webDriver.FindElement(_newNumber).Text;
            return name;
        }
        
        public AccountSettingsPage SetNewEmail(string newEmail)
        {
            _webDriver.FindElement(_newEmailField).SendKeys(newEmail);
            return this;
        }

        public AccountSettingsPage SetNewPassword(string newPassword)
        {
            _webDriver.FindElement(_newPasswordField).SendKeys(newPassword);
            return this;
        }
        
        public AccountSettingsPage ConfirmNewPassword(string newPassword)
        {
            _webDriver.FindElement(_confirmNewPasswordField).SendKeys(newPassword);
            return this;
        }
        
        public AccountSettingsPage ConfirmPasswordForEmailChange(string password)
        {
            _webDriver.FindElement(_currentPasswordForEmailField).SendKeys(password);
            return this;
        }
        
        public AccountSettingsPage ConfirmPasswordForPasswordChange(string password)
        {
            _webDriver.FindElement(_currentPasswordForPasswordChangeField).SendKeys(password);
            return this;
        }
        
        public AccountSettingsPage ConfirmPasswordForNumberChange(string password)
        {
            _webDriver.FindElement(_currentPasswordForNumberChangeField).SendKeys(password);
            return this;
        }
        
        public AccountSettingsPage SetCardholderName()
        {
            _webDriver.FindElement(_cardNameField).SendKeys("MaBelle S Parker");
            return this;
        }
        
        public AccountSettingsPage SetCardNumber()
        {
            _webDriver.FindElement(_cardNumberField).SendKeys("4000 0200 0000 0000");
            return this;
        }
        
        public AccountSettingsPage SetExpirationDate()
        {
            _webDriver.FindElement(_cardYearField).SendKeys("0330");
            return this;
        }
        
        public AccountSettingsPage SetCVV()
        {
            _webDriver.FindElement(_cardCVVField).SendKeys("737");
            return this;
        }
        
        public AccountSettingsPage SetNewNumber()
        {
            _webDriver.FindElement(_newNumberField).SendKeys("999.111.9999");
            return this;
        }

        public AccountSettingsPage SetNewCompanyName(string companyName)
        {
            _webDriver.FindElement(_companyNameField).Clear();
            _webDriver.FindElement(_companyNameField).SendKeys(companyName);
            return this;
        }
        
        public AccountSettingsPage SetNewCompanyWebsite(string companyWebsite)
        {
            _webDriver.FindElement(_companyWebsiteField).Clear();
            _webDriver.FindElement(_companyWebsiteField).SendKeys(companyWebsite);
            return this;
        }
        
        public AccountSettingsPage SetDescription(string description)
        {
            _webDriver.FindElement(_descriptionField).Clear();
            _webDriver.FindElement(_descriptionField).SendKeys(description);
            return this;
        }

        public string GetCompanyName()
        {
            var companyName = _webDriver.FindElement(_companyName).Text;
            return companyName;
        }
        
        public string GetCompanyWebsite()
        {
            var companyWebsite = _webDriver.FindElement(_companyWebsite).Text;
            return companyWebsite;
        }
        
        public string GetDescription()
        {
            var description = _webDriver.FindElement(_description).Text;
            return description;
        }
        
        public string GetErrorMessage()
        {
            var errorMessage = _webDriver.FindElement(_errorMessageWrongPassword).Text;
            return errorMessage;
        }
    }
}