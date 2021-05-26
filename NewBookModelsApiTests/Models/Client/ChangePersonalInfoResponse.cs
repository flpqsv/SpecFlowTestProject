using Newtonsoft.Json;

namespace NewBookModelsApiTests.Models.Client
{
    public class ChangePersonalInfoResponse
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
    }
}