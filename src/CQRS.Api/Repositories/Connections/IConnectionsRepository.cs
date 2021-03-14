using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Api.Repositories.Connections
{
   public interface IConnectionsRepository
    {
        Task<string> CrateNewConnection(ConnectionEntity obj);
        Task<string> UpdateNewConnection(ConnectionEntity obj);
        Task<ConnectionEntity> GetNewConnectionById(string id);
        Task<ICollection<ConnectionEntity>> GetAllNewConnections();
    }
}
