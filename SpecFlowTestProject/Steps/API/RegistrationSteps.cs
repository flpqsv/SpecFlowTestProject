using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using NewBookModelsApiTests.ApiRequests.Auth;
using NewBookModelsApiTests.Models.Auth;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowTestProject.Steps.API
{
    [Binding]
    public sealed class RegistrationSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public RegistrationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Client is created")]
        public void GivenClientIsCreated()
        {
            var createUser = AuthRequests.SendRequestClientSignUpPost(new Dictionary<string, string>
            {
                {"email", $"asda2sd2asd{DateTime.Now:ddyyyymmHHmmssffff}@asdasd.ert"},
                {"first_name", "asdasdasd"},
                {"last_name", "asdasdasd"},
                {"password", Constants.Password},
                {"phone_number", "3453453454"}
            });

            _scenarioContext.Add(Context.User, createUser);
        }
        
        [When(@"I send POST request for registration with valid data")]
        public void WhenISendPostRequestWithValidData()
        {
            var createUser = AuthRequests.SendRequestClientSignUpPost(new Dictionary<string, string>
            {
                {"email", $"asda2sd2asd{DateTime.Now:ddyyyymmHHmmssffff}@asdasd.ert"},
                {"first_name", "asdasdasd"},
                {"last_name", "asdasdasd"},
                {"password", Constants.Password},
                {"phone_number", "3453453454"}
            });

            _scenarioContext.Add(Context.User, createUser);
        }
        
        [When(@"I send POST request with already existing email")]
        public void WhenISendPostRequestWithAlreadyExistingEmail()
        {
            var createUser = AuthRequests.SendRequestClientSignUpPost(new Dictionary<string, string>
            {
                {"email", "godedo6298@cnxingye.com"},
                {"first_name", "asdasdasd"},
                {"last_name", "asdasdasd"},
                {"password", Constants.Password},
                {"phone_number", "3453453454"}
            });

            _scenarioContext.Add(Context.User, createUser);
        }
        
        [When(@"I send POST request with invalid data")]
        public void WhenISendPostRequestWithInvalidData()
        {
            var createUser = AuthRequests.SendRequestClientSignUpPost(new Dictionary<string, string>
            {
                {"email", ""},
                {"first_name", ""},
                {"last_name", ""},
                {"password", ""},
                {"phone_number", ""}
            });

            _scenarioContext.Add(Context.User, createUser);
        }
        
        [When(@"I send POST request with data")]
        public void WhenISendPostRequestWithData(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            var email = CreateUniqueEmail();

            var createUser = AuthRequests.SendRequestClientSignUpPost(new Dictionary<string, string>
            {
                {"email", email},
                {"first_name", (string)data.first_name},
                {"last_name", (string)data.last_name},
                {"password", (string)data.password},
                {"phone_number", (string)data.phone}
            });
            
            _scenarioContext.Add(Context.User, createUser);
        }
        
        private string CreateUniqueEmail()
        {
            var date = DateTime.Now.ToString("yyyy.MM.dd.hh.mm.ss");
            var email = $"mabel.{date}@gmail.com";

            return email;
        }

        [Then(@"Successful response about created account is provided")]
        public void ThenSuccessfulResponseAboutCreatedAccount()
        {
            var status = _scenarioContext.Get<AuthRequests.ResponseModel<ClientAuthModel>>(Context.User).Response.StatusCode;
            Assert.AreEqual(HttpStatusCode.Created, status);
        }

        [Then(@"Failed response about created account is provided")]
        public void ThenFailedResponseAboutCreatedAccountIsProvided()
        {
            var status = _scenarioContext.Get<AuthRequests.ResponseModel<ClientAuthModel>>(Context.User).Response.StatusCode;
            Assert.AreNotEqual(HttpStatusCode.Created, status);
        }
    }
}