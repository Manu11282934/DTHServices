using CQRS.Api.RequestModels;
using CQRS.Api.ResponseModel.GetConnections;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Api.RequestModel.GetConnections
{
    public class GetAllConnectionsRequestModel : SecureClientAwareRequest, IRequest<GetAllConnectionsResponseModel>
    {
    }
}
