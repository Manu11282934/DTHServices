using CQRS.Api.Security.AuthToken;

namespace CQRS.Api.ResponseModels.CommandResponseModels
{
    public class ValidateAuthTokenResponse
    {
        public AccessTokenValidationResult ValidationResult { get; set; }
    }
}
