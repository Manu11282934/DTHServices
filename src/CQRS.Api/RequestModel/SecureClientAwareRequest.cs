using Newtonsoft.Json;

namespace CQRS.Api.RequestModels
{
    public class SecureClientAwareRequest 
    {
        [JsonIgnore]
        public string AuthToken { get; set; }
        
        [JsonProperty("userId")]

        public string UserId { get; set; }
    }
}
