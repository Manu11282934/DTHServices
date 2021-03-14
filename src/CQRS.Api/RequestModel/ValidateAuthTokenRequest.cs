using CQRS.Api.ResponseModels.CommandResponseModels;
using MediatR;

namespace CQRS.Api.RequestModels.CommandRequestModels
{
    public class ValidateAuthTokenRequest :  IRequest<ValidateAuthTokenResponse>
    {
        public string AuthToken { get; set; }
    }
}
