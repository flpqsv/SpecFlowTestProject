using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using NewBookModelsApiTests.ApiRequests.Auth;
using NewBookModelsApiTests.ApiRequests.Client;
using NewBookModelsApiTests.Models.Auth;
using NewBookModelsApiTests.Models.Client;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Steps.API
{
    [Binding]
    public sealed class AccSettingsSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public AccSettingsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I send POST request with valid data for email change")]
        public void WhenISendPostRequestWithValidDataForEmailChange()
        {
            var userModel = _scenarioContext.Get<AuthRequests.ResponseModel<ClientAuthModel>>(Context.User).Model.TokenData;
            
            var newEmail = $"mabel{DateTime.Now:ddyymmHHssmm}@gmail.com";
            
            var editRequest =
                ClientRequests.SendRequestChangeClientEmailPost(Constants.Password, newEmail,
                    userModel.Token);
            
            _scenarioContext.Add("Edit", editRequest);
        }
        
        [When(@"I send POST request with valid data for phone number change")]
        public void WhenISendPostRequestWithValidDataForPChange()
        {
            var userModel = _scenarioContext.Get<AuthRequests.ResponseModel<ClientAuthModel>>(Context.User).Model.TokenData;
            
            var newPhone = "1453453454";

            var editRequest = ClientRequests.SendRequestChangeClientPhonePost(Constants.Password, newPhone, userModel.Token);
            
            _scenarioContext.Add("Edit", editRequest);
        }
        
        [When(@"I send PATCH request with valid data for company information change")]
        public void WhenISendPatchRequestWithValidDataForCompanyInformationChange()
        {
            var userModel = _scenarioContext.Get<AuthRequests.ResponseModel<ClientAuthModel>>(Context.User).Model.TokenData;
            
            var description = "My description."; 
            var companyName = "Henlo World Inc";
            var website = "http://henloworld.com";
            
            var editRequest = ClientRequests.SendRequestChangeClientCompanyInfoPost
                (description, companyName, website, userModel.Token);
            
            _scenarioContext.Add("Edit", editRequest);
        }
        
        [When(@"I send POST request with invalid data for email change")]
        public void WhenISendPostRequestWithInvalidDataForEmailChange()
        {
            var userModel = _scenarioContext.Get<AuthRequests.ResponseModel<ClientAuthModel>>(Context.User).Model.TokenData;
            
            var newEmail = $"mabel{DateTime.Now:ddyymmHHssmm}@gmail.com";
            
            var editRequest =
                ClientRequests.SendRequestChangeClientEmailPost("random", newEmail,
                    userModel.Token);
            
            _scenarioContext.Add("Edit", editRequest);
        }

        [Then(@"Successful response about changed email is provided")]
        public void ThenSuccessfulResponseAboutChangedEmailIsProvided()
        {
            var status = _scenarioContext.Get<ClientRequests.ResponseModel<ChangeEmailResponse>>("Edit").Response.StatusCode;

            Assert.AreEqual(HttpStatusCode.OK, status);
        }
        
        [Then(@"Successful response about changed phone number is provided")]
        public void ThenSuccessfulResponseAboutChangedPasswordIsProvided()
        {
            var status = _scenarioContext.Get<ClientRequests.ResponseModel<ChangePhoneResponse>>("Edit").Response.StatusCode;

            Assert.AreEqual(HttpStatusCode.OK, status);
        }

        [Then(@"Successful response about changed company information is provided")]
        public void ThenSuccessfulResponseAboutChangedCompanyInformationIsProvided()
        {
            var status = _scenarioContext.Get<ClientRequests.ResponseModel<ChangeCompanyInfoResponse>>("Edit").Response.StatusCode;

            Assert.AreEqual(HttpStatusCode.OK, status);
        }

        [Then(@"Failed response about changed email is provided")]
        public void ThenFailedResponseAboutChangedEmailIsProvided()
        {
            var status = _scenarioContext.Get<ClientRequests.ResponseModel<ChangeEmailResponse>>("Edit").Response.StatusCode;

            Assert.AreNotEqual(HttpStatusCode.OK, status);
        }
    }
}