using CQRS.Api.Repositories.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Api.Repositories.Connections
{
    public class ConnectionRepository : IConnectionsRepository
    {
        private readonly IMongoDbClientConfigurations _mongoClient;
        public ConnectionRepository(IMongoDbClientConfigurations mongoClient)
        {
            _mongoClient = mongoClient;
        }

        public async Task<string> CrateNewConnection(ConnectionEntity obj)
        {
             await _mongoClient.Insert(obj);
            return "Inserted";
        }

        public async Task<string> UpdateNewConnection(ConnectionEntity obj)
        {
            await _mongoClient.Update(obj);
            return "updated";
        }

        public async Task<ConnectionEntity> GetNewConnectionById(string id)
        {
           return await _mongoClient.GetById(id);
        }
        public async Task<ICollection<ConnectionEntity>> GetAllNewConnections()
        {
            var Result =new  List<ConnectionEntity>();
            Result.Add(new ConnectionEntity());
            Result.Add(new ConnectionEntity());

            var result = await _mongoClient.Get();
            return result;
        }
    }
}
