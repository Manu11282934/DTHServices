using CQRS.Api.RequestModels;
using CQRS.Api.Security.AuthToken;
using LDI.AuthService.FunctionApp.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Api.Behaviours.Behaviours
{
    public class ValidateAuthTokenBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : SecureClientAwareRequest
    {
        private readonly IUserAuthTokenValidator _userAuthTokenValidator;
       

        public ValidateAuthTokenBehavior(IUserAuthTokenValidator userAuthTokenValidator)
        {
            _userAuthTokenValidator = userAuthTokenValidator;           
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //var clientConfiguration = _clientConfigurationProvider.GetClientConfiguration(request.ClientId);
            //var secureTokenConfiguration = clientConfiguration.SecureTokenConfiguration;
            //if (secureTokenConfiguration == null) { throw new ArgumentNullException(nameof(secureTokenConfiguration)); }

            AccessTokenValidationResult validationResult = _userAuthTokenValidator.ValidateToken("secureTokenConfiguration.PrivateKey", request.AuthToken, "secureTokenConfiguration.TokenIssuer");
            
            if (validationResult.Status == AccessTokenStatus.Valid)
            {
              //  request.UserId = validationResult.;
                return next();
            }
            throw new AuthTokenValidationException();
        }
    }
}
