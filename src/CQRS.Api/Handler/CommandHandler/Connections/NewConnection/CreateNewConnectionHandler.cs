using CQRS.Api.Repositories.Connections;
using CQRS.Api.RequestModel.Newconnection;
using CQRS.Api.ResponseModel.NewConnectionData;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Api.Handler.CommandHandler.Connections.NewConnection
{
    public class CreateNewConnectionHandler : IRequestHandler<CreateConnectionRequestModel, CreateConnectionResponseModel>
    {
        private readonly IConnectionsRepository _newConnectionsRepository;
        public CreateNewConnectionHandler(IConnectionsRepository newConnectionsRepository)
        {       
            _newConnectionsRepository = newConnectionsRepository;
        }
        public async Task<CreateConnectionResponseModel> Handle(CreateConnectionRequestModel request, CancellationToken cancellationToken)
        {
           string result =  await _newConnectionsRepository.CrateNewConnection(new ConnectionEntity());
            if(result != null )
            {
                return null;
            }
            return new CreateConnectionResponseModel() { id=Guid.NewGuid().ToString()};            
        }
    }
}
