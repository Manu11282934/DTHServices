using CQRS.Api.Extensions;
using CQRS.Api.Repositories.Connections;
using CQRS.Api.RequestModel.GetConnections;
using CQRS.Api.RequestModel.Newconnection;
using CQRS.Api.ResponseModel.GetConnections;
using CQRS.Api.ResponseModel.NewConnectionData;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Api.Handler.QueryHandler.Connections.GetAllConnections
{
    public class GetAllConnectionDataListHandler : IRequestHandler<GetAllConnectionsRequestModel, GetAllConnectionsResponseModel>
    {
        private readonly IConnectionsRepository _newConnectionsRepository;
        public GetAllConnectionDataListHandler(IConnectionsRepository newConnectionsRepository)
        {
            _newConnectionsRepository = newConnectionsRepository;
        }
        public async Task<GetAllConnectionsResponseModel> Handle(GetAllConnectionsRequestModel request, CancellationToken cancellationToken)
        {
          
                var response = await _newConnectionsRepository.GetAllNewConnections();
                if (response == null)
                {
                    return null;
                }
                var result = new GetAllConnectionsResponseModel() { list = response };
                return result;         
            }

        private Task<GetAllConnectionsResponseModel> HandleExceptionAsync(Func<Task<IActionResult>> p, GetAllConnectionsRequestModel request)
        {
            throw new NotImplementedException();
        }
    }

   
}
