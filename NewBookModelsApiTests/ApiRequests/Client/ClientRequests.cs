using System.Collections.Generic;
using NewBookModelsApiTests.Models.Auth;
using NewBookModelsApiTests.Models.Client;
using Newtonsoft.Json;
using RestSharp;

namespace NewBookModelsApiTests.ApiRequests.Client
{
    public class ClientRequests
    {
        public static ResponseModel<ChangeEmailResponse> SendRequestChangeClientEmailPost(string password, string email, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/change_email/");
            var request = new RestRequest(Method.POST);
            
            var newEmailModel = new Dictionary<string, string>
            {
                {"email", email},
                {"password", password}
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newEmailModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changeEmailResponse = JsonConvert.DeserializeObject<ChangeEmailResponse>(response.Content);

            return new ResponseModel<ChangeEmailResponse>{Model = changeEmailResponse, Response = response};
        }

        public static ResponseModel<ChangePhoneResponse> SendRequestChangeClientPhonePost(string password, string phoneNumber, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/change_phone/");
            var request = new RestRequest(Method.POST);
            
            var newPhoneModel = new Dictionary<string, string>
            {
                {"phone_number", phoneNumber},
                {"password", password}
            };
            
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            
            request.AddJsonBody(newPhoneModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changePhoneResponse = JsonConvert.DeserializeObject<ChangePhoneResponse>(response.Content);

            return new ResponseModel<ChangePhoneResponse>{Model = changePhoneResponse, Response = response};
        }
        
        public static string SendRequestChangeClientPasswordPost(string password, string newPassword, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/password/change/");
            var request = new RestRequest(Method.POST);
            
            var newPasswordModel = new Dictionary<string, string>
            {
                {"new_password", newPassword},
                {"old_password", "Mabel123!"}
            };
            
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            
            request.AddJsonBody(newPasswordModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changePasswordResponse = JsonConvert.DeserializeObject<ChangePasswordResponse>(response.Content);

            return changePasswordResponse.NewPassword;
        }

        public static ResponseModel<ChangePersonalInfoResponse> SendRequestChangeClientPersonalInfoPost(string firstName, string lastName, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/self/");
            var request = new RestRequest(Method.PATCH);
            
            var newPersonalInfoModel = new Dictionary<string, string>
            {
                {"first_name", firstName},
                {"last_name", lastName}
            };
            
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            
            request.AddJsonBody(newPersonalInfoModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changePersonalInfoResponse = JsonConvert.DeserializeObject<ChangePersonalInfoResponse>(response.Content);

            return new ResponseModel<ChangePersonalInfoResponse>{Model = changePersonalInfoResponse, Response = response};
        }
        
        public static ResponseModel<ChangeIndustryAndLocationResponse> SendRequestChangeClientIndustryAndLocationPost
            (string industry, string locationCode, string locationCity, string locationLatitude, string locationLongitude, string locationName, string locationTime, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/profile/");
            var request = new RestRequest(Method.PATCH);
            
            var newIndustryAndLocationModel = new Dictionary<string, string>
            {
                {"industry", industry},
                {"location_admin1_code", locationCode},
                {"location_city_name", locationCity},
                {"location_latitude", locationLatitude},
                {"location_longitude", locationLongitude},
                {"location_name", locationName},
                {"location_timezone", locationTime}
            };
            
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            
            request.AddJsonBody(newIndustryAndLocationModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changeIndustryAndLocationResponse = JsonConvert.DeserializeObject<ChangeIndustryAndLocationResponse>(response.Content);

            return new ResponseModel<ChangeIndustryAndLocationResponse>{Model = changeIndustryAndLocationResponse, Response = response};
        }
        
        public static ResponseModel<ChangeCompanyInfoResponse> SendRequestChangeClientCompanyInfoPost(string description, string companyName, string website, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/profile/");
            var request = new RestRequest(Method.PATCH);
            
            var newCompanyInfoModel = new Dictionary<string, string>
            {
                {"company_description", description},
                {"company_name", companyName},
                {"company_website", website}
            };
            
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            
            request.AddJsonBody(newCompanyInfoModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changeCompanyInfoResponse = JsonConvert.DeserializeObject<ChangeCompanyInfoResponse>(response.Content);

            return new ResponseModel<ChangeCompanyInfoResponse>{Model = changeCompanyInfoResponse, Response = response};
        }
        
        public static ResponseModel<ClientAuthModel> SendRequestClientLogInPost(Dictionary<string, string> user)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/auth/signin/");
            var request = new RestRequest(Method.POST);

            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(user);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var authUser = JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);

            return new ResponseModel<ClientAuthModel> { Model = authUser, Response = response };
        }

        public class ResponseModel<T>
        {
            public T Model { get; set; }
            public IRestResponse Response { get; set; }
        }
    }
}