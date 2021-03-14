using CQRS.Api.RequestModels;
using MediatR;

namespace CQRS.Api.RequestModel.GetConnections
{
    public class GetConnectionByIdRequestModel : SecureClientAwareRequest, IRequest<GetConnectionByIdResponseModel> 
    {
        public string Id { get; set; }
    }
}
