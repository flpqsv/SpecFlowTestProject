using OpenQA.Selenium;

namespace SeleniumTests.POM
{
    public class SignInPage
    {
        private readonly IWebDriver _webDriver;

        private static readonly By _emailField = By.CssSelector("input[type=email]");
        private static readonly By _passwordField = By.CssSelector("input[type=password]");
        private static readonly By _loginButton = By.CssSelector("[class^=SignInForm__submitButton]");
        private static readonly By _wrongEmailErrorMessage = By.XPath("//div[contains(text(),'Invalid Email')]");
        private static readonly By _wrongPasswordErrorMessage = By.XPath("//div[contains(text(),'Please enter')]");
        private static readonly By _accountBlockMessage = By.XPath("//div[contains(text(),'User account is blocked.')]");

        public SignInPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SignInPage OpenPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            return this;
        }

        public SignInPage SetEmail(string email)
        {
            _webDriver.FindElement(_emailField).SendKeys(email);
            return this;
        }

        public SignInPage SetPassword(string password)
        {
            _webDriver.FindElement(_passwordField).SendKeys(password);
            return this;
        }

        public void ClickLoginButton() =>
            _webDriver.FindElement(_loginButton).Click();

        public string GetUserAccountBlockMessage() => 
            _webDriver.FindElement(_accountBlockMessage).Text;
        
        public string GetWrongEmailMessage()
        {
            var message = _webDriver.FindElement(_wrongEmailErrorMessage).Text;
            return message;
        }
        
        public string GetWrongPasswordMessage()
        {
            var message = _webDriver.FindElement(_wrongPasswordErrorMessage).Text;
            return message;
        }
    }
}