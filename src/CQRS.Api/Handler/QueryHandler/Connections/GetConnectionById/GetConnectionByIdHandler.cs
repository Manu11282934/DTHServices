using CQRS.Api.Repositories.Connections;
using CQRS.Api.RequestModel.GetConnections;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Api.Handler.QueryHandler.Connections.GetConnectionById
{
    public class GetConnectionByIdHandler : IRequestHandler<GetConnectionByIdRequestModel, GetConnectionByIdResponseModel>
    {
        private readonly IConnectionsRepository _newConnectionsRepository;
        public GetConnectionByIdHandler(IConnectionsRepository newConnectionsRepository)
        {
            _newConnectionsRepository = newConnectionsRepository;
        }
        public async Task<GetConnectionByIdResponseModel> Handle(GetConnectionByIdRequestModel request, CancellationToken cancellationToken)
        {
           var response= await _newConnectionsRepository.GetNewConnectionById(request.Id);
            if (response== null)
            {
                return null;
            }
            return new GetConnectionByIdResponseModel() { Id=response.id,FirstName=response.FirstName,LastName=response.LastName};
        }
    }
}
