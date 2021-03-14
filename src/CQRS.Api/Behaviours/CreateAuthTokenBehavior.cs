using CQRS.Api.RequestModels;
using CQRS.Api.ResponseModels;
using CQRS.Api.Security.AuthToken;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Api.Behaviours
{
    public class CreateAuthTokenBehavior : IPipelineBehavior<GetRegisteredUserRequest, RegisteredUserResponse>
    {
        private readonly IUserAuthTokenBuilder _userAuthTokenBuilder;

        public CreateAuthTokenBehavior(IUserAuthTokenBuilder userAuthTokenBuilder)
        {
            _userAuthTokenBuilder = userAuthTokenBuilder;
        }

        public async Task<RegisteredUserResponse> Handle(GetRegisteredUserRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<RegisteredUserResponse> next)
        {
            RegisteredUserResponse registeredUserResponse = await next();
            if (registeredUserResponse == null) { return registeredUserResponse; }
            registeredUserResponse.Token = _userAuthTokenBuilder.IssueToken(registeredUserResponse.User);
            return registeredUserResponse;
        }
    }    
}
