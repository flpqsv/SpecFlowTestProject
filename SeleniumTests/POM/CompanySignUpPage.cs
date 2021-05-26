using System.Threading;
using OpenQA.Selenium;

namespace SeleniumTests.POM
{
    public class CompanySignUpPage
    {
        private readonly IWebDriver _webDriver;
        
        private static readonly By _firstNameField = By.CssSelector("[name=first_name]");
        private static readonly By _lastNameField = By.CssSelector("[name=last_name]");
        private static readonly By _phoneField = By.CssSelector("[name=phone_number]");
        private static readonly By _emailField = By.CssSelector("input[type=email]");
        private static readonly By _passwordField = By.CssSelector("input[type=password]");
        private static readonly By _confirmPasswordField = By.CssSelector("[name=password_confirm]");
        private static readonly By _submitButton = By.CssSelector("[type=submit]");
        private static readonly By _finishButton = By.XPath("//button[contains(text(),'Finish')]");
        private static readonly By _companyNameField = By.CssSelector("[name=company_name]");
        private static readonly By _companyWebsiteField = By.CssSelector("[name=company_website]");
        private static readonly By _industryNameField = By.CssSelector("[name=industry]");
        private static readonly By _industryMatch = By.CssSelector("[class=Select__optionText--OxKln]");
        private static readonly By _locationField = By.CssSelector("[name=location]");
        private static readonly By _locationMatch = By.CssSelector("[class=pac-matched]");

        private static readonly By _emptyFirstNameMessage = By.XPath("//div[1]/div[1]/label[1]/div[2]/div[1]");
        private static readonly By _emptyLastNameMessage = By.XPath("//div[1]/div[2]/label[1]/div[2]/div[1]");
        private static readonly By _wrongEmailMessage = By.XPath("//div[contains(text(),'Invalid Email')]");
        private static readonly By _wrongPasswordMessage = By.XPath("//div[contains(text(),'Invalid password format')]");
        private static readonly By _wrongConfPasswordMessage = By.XPath("//div[contains(text(),'Passwords must match')]");
        private static readonly By _emptyPhoneMessage = By.XPath("//div[contains(text(),'Invalid phone format')]");
        private static readonly By _emailAlreadyExists = By.XPath("//div[contains(text(),'user with this email already exists.')]");

        public CompanySignUpPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public bool IsPageTitleVisible()
        {
            return true;
        }

        public CompanySignUpPage GoToRegistrationPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/");
            _webDriver.FindElement(By.CssSelector("[class*=Navbar__signUp]")).Click();
            return this;
        }

        public CompanySignUpPage SetEmail(string email)
        {
            _webDriver.FindElement(_emailField).SendKeys(email);
            return this;
        }

        public CompanySignUpPage SetPassword(string password)
        {
            _webDriver.FindElement(_passwordField).SendKeys(password);
            return this;
        }
        
        public CompanySignUpPage SetConfirmPassword(string password)
        {
            _webDriver.FindElement(_confirmPasswordField).SendKeys(password);
            return this;
        }

        public CompanySignUpPage SetFirstName(string firstName)
        {
            _webDriver.FindElement(_firstNameField).SendKeys(firstName);
            return this;
        }
        
        public CompanySignUpPage SetLastName(string lastName)
        {
            _webDriver.FindElement(_lastNameField).SendKeys(lastName);
            return this;
        }

        public CompanySignUpPage SetPhone(string phone)
        {
            _webDriver.FindElement(_phoneField).SendKeys(phone);
            return this;
        }

        public CompanySignUpPage SetCompanyName(string companyName)
        {
            _webDriver.FindElement(_companyNameField).SendKeys(companyName);
            return this;
        }
        
        public CompanySignUpPage SetCompanyWebsite(string companyWebsite)
        {
            _webDriver.FindElement(_companyWebsiteField).SendKeys(companyWebsite);
            return this;
        }

        public CompanySignUpPage ClickCompanyIndustry()
        {
            _webDriver.FindElement(_industryNameField).Click();
            _webDriver.FindElement(_industryMatch).Click();
            Thread.Sleep(1000);
            return this;
        }

        public CompanySignUpPage ClickLocation(string location)
        {
            _webDriver.FindElement(_locationField).SendKeys(location);
            Thread.Sleep(2000);
            _webDriver.FindElement(_locationMatch).Click();
            return this;
        }

        public CompanySignUpPage ClickSubmitButton()
        {
            _webDriver.FindElement(_submitButton).Click();
            return this;
        }

        public CompanySignUpPage ClickFinishButton()
        {
            _webDriver.FindElement(_finishButton).Click();
            return this;
        }

        public string GetWrongFirstNameMessage()
        {
            string errorMessage = _webDriver.FindElement(_emptyFirstNameMessage).Text;
            return errorMessage;
        }
        
        public string GetWrongLastNameMessage()
        {
            string errorMessage = _webDriver.FindElement(_emptyLastNameMessage).Text;
            return errorMessage;
        }
        
        public string GetWrongEmailMessage()
        {
            string errorMessage = _webDriver.FindElement(_wrongEmailMessage).Text;
            return errorMessage;
        }
       
        public string GetWrongPasswordMessage()
        {
            string errorMessage = _webDriver.FindElement(_wrongPasswordMessage).Text;
            return errorMessage;
        }
        
        public string GetWrongConfirmPasswordMessage()
        {
            string errorMessage = _webDriver.FindElement(_wrongConfPasswordMessage).Text;
            return errorMessage;
        }
        
        public string GetWrongPhoneMessage()
        {
            string errorMessage = _webDriver.FindElement(_emptyPhoneMessage).Text;
            return errorMessage;
        }
        
        public string GetEmailAlreadyExistsMessage()
        {
            string errorMessage = _webDriver.FindElement(_emailAlreadyExists).Text;
            return errorMessage;
        }
    }
}