using CQRS.Api.ResponseModels;
using MediatR;
using Newtonsoft.Json;

namespace CQRS.Api.RequestModels
{
    public class GetRegisteredUserRequest :  IRequest<RegisteredUserResponse>
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("accessCode")]
        public string AccessCode { get; set; }
    }
}
