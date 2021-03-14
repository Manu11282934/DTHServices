using CQRS.Api.RequestModels.CommandRequestModels;
using CQRS.Api.ResponseModels.CommandResponseModels;
using CQRS.Api.Security.AuthToken;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Api.Handlers.CommandHandlers
{
    // TODO create a base class to check if client configuration is valid

    public class ValidateAuthTokenCommandHandler : IRequestHandler<ValidateAuthTokenRequest, ValidateAuthTokenResponse>
    {
        private readonly IUserAuthTokenValidator _userAuthTokenValidator;


        public ValidateAuthTokenCommandHandler(IUserAuthTokenValidator userAuthTokenValidator)
        {
            _userAuthTokenValidator = userAuthTokenValidator;           
        }

        public async Task<ValidateAuthTokenResponse> Handle(ValidateAuthTokenRequest request, CancellationToken cancellationToken)
        {
            
            var validationResult = _userAuthTokenValidator.ValidateToken("secureTokenConfiguration.PrivateKey", "request.AuthToken", "secureTokenConfiguration.TokenIssuer");
            var response = new ValidateAuthTokenResponse { ValidationResult = validationResult };
            return await Task.FromResult(response);
        }
    }
}
