using NewBookModelsApiTests.ApiRequests.Auth;
using System;
using System.Collections.Generic;
using System.Net;
using NewBookModelsApiTests.ApiRequests.Client;
using NewBookModelsApiTests.Models.Auth;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Steps.API
{
    [Binding]
    public class AuthSingInSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public AuthSingInSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [When(@"I send POST request with valid data")]
        public void WhenISendPostRequestWithValidData()
        {
            var userModel = _scenarioContext.Get<AuthRequests.ResponseModel<ClientAuthModel>>(Context.User).Model.User;
            
            var user = new Dictionary<string, string>
            {
                {"email", userModel.Email},
                {"password", Constants.Password}
            };

            var loginRequest = ClientRequests.SendRequestClientLogInPost(user);
            _scenarioContext.Add("Auth", loginRequest);
        }
        
        [When(@"I send POST request with invalid email")]
        public void WhenISendPostRequestWithInvalidEmail()
        {
            var userModel = _scenarioContext.Get<AuthRequests.ResponseModel<ClientAuthModel>>(Context.User).Model.User;
            
            var user = new Dictionary<string, string>
            {
                {"email", "random"},
                {"password", Constants.Password}
            };

            var loginRequest = ClientRequests.SendRequestClientLogInPost(user);
            _scenarioContext.Add("Auth", loginRequest);
        }

        [When(@"I send POST request with invalid password")]
        public void WhenISendPostRequestWithInvalidPassword()
        {
            var userModel = _scenarioContext.Get<AuthRequests.ResponseModel<ClientAuthModel>>(Context.User).Model.User;
            
            var user = new Dictionary<string, string>
            {
                {"email", userModel.Email},
                {"password", "random"}
            };

            var loginRequest = ClientRequests.SendRequestClientLogInPost(user);
            _scenarioContext.Add("Auth", loginRequest);
        }

        [When(@"I send POST request with blocked data")]
        public void WhenISendPostRequestWithBlockedData()
        {
            var user = new Dictionary<string, string>
            {
                {"email", "godedo6298@cnxingye.com"},
                {"password", "Mabel123!"}
            };

            var loginRequest = ClientRequests.SendRequestClientLogInPost(user);
            _scenarioContext.Add("Auth", loginRequest);
        }

        [Then(@"Successful response about authorization is provided")]
        public void ThenSuccessfulResponseAboutAuthorizationIsProvided()
        {
            var status = _scenarioContext.Get<ClientRequests.ResponseModel<ClientAuthModel>>("Auth").Response.StatusCode;

            Assert.AreEqual(HttpStatusCode.OK, status);
        }

        [Then(@"Failed response about authorization is provided")]
        public void ThenFailedResponseAboutAuthorizationIsProvided()
        {
            var status = _scenarioContext.Get<ClientRequests.ResponseModel<ClientAuthModel>>("Auth").Response.StatusCode;

            Assert.AreNotEqual(HttpStatusCode.OK, status);
        }
    }
}