using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace SeleniumTests
{
    public class ProfileTests
    {
        [Test]
        public void Test1()
        {
            var user = CreateUserViaApi();
            var _webDriver = new ChromeDriver("/Users/MaBelle/Downloads/");
            
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            IJavaScriptExecutor js = _webDriver;

            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");

            js.ExecuteScript($"localStorage.setItem('access_token','{user.TokenData.Token}');");

            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/profile/edit");
        }

        public ClientAuthModel CreateUserViaApi()
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/client/signup/");
            var request = new RestRequest(Method.POST);
            var user = new Dictionary<string, string>
            {
                { "email", $"asda2sd2asd{DateTime.Now:ddyyyymmHHssmm}@asdasd.ert" },
                { "first_name", "asdasdasd" },
                { "last_name", "asdasdasd" },
                { "password", "123qweQWE" },
                { "phone_number", "3453453454" }
            };


            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(user);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var createdUser = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return createdUser;
        }
    }

    public class UserSignUpModel
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("first_name")] 
        public string FirstName { get; set; }
        [JsonProperty("last_name")] 
        public string LastName { get; set; }
        [JsonProperty("password")] 
        public string Password { get; set; }
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}