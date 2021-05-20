using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace SpecflowTestProject
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario("ui")]
        public void BeforeScenario()
        {
            var _webDriver = new ChromeDriver("/Users/MaBelle/Downloads/");
            
            _webDriver.Manage().Window.Maximize();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            _scenarioContext.Add(Context.WebDriver, _webDriver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _scenarioContext.Get<IWebDriver>(Context.WebDriver).Quit();
        }
    }
}