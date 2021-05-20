using System.Collections.Generic;
using NewBookModelsApiTests.Models.Client;
using Newtonsoft.Json;
using RestSharp;

namespace NewBookModelsApiTests.ApiRequests.Client
{
    public static class ClientRequests
    {
        public static ResponseModel<ChangeEmailResponse> SendRequestChangeClientEmailPost(string password, string email, string token)
        {
            var client = new RestClient("https://api.newbookmodels.com/api/v1/client/change_email/");
            var request = new RestRequest(Method.POST);
            var newEmailModel = new Dictionary<string, string>
            {
                { "email", email },
                { "password", password },
            };

            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddJsonBody(newEmailModel);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            var changeEmailResponse = JsonConvert.DeserializeObject<ChangeEmailResponse>(response.Content);

            return new ResponseModel<ChangeEmailResponse> { Model = changeEmailResponse, Response = response };
        }
    }

    public class ResponseModel<T>
    {
        public T Model { get; set; }
        public IRestResponse Response { get; set; }
    }
}