using CQRS.Api.Models;

namespace CQRS.Api.ResponseModels
{
    public class RegisteredUserResponse
    {        
        public ApplicationUser User { get; set; }
        public string Token { get; set; }
    }
}
