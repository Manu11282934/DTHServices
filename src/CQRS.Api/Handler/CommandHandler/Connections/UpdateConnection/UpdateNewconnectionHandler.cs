using CQRS.Api.Repositories.Connections;
using CQRS.Api.RequestModel.Newconnection;
using CQRS.Api.RequestModel.UpdateConnection;
using CQRS.Api.ResponseModel.NewConnectionData;
using CQRS.Api.ResponseModel.UpdateConnection;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Api.Handler.CommandHandler.Connections.UpdateConnection
{
    public class UpdateNewconnectionHandler : IRequestHandler<UpdateConnectionRequestModel, UpdateConnectionResponseModel>
    {
        private readonly IConnectionsRepository _newConnectionsRepository;
        public UpdateNewconnectionHandler(IConnectionsRepository newConnectionsRepository)
        {
            _newConnectionsRepository = newConnectionsRepository;
        }
        public async Task<UpdateConnectionResponseModel> Handle(UpdateConnectionRequestModel request, CancellationToken cancellationToken)
        {
            string result = await _newConnectionsRepository.UpdateNewConnection(new ConnectionEntity() { id=request.id,
            FirstName=request.FirstName,LastName=request.LastName,OperatorName=request.OperatorName});
            if (result != null)
            {
                return null;
            }
            return new UpdateConnectionResponseModel() { Id = Guid.NewGuid().ToString() };
        }
    }
}
