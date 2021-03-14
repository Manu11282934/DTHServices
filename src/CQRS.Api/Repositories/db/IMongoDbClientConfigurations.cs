using CQRS.Api.Repositories.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Api.Repositories.db
{
   public interface IMongoDbClientConfigurations
    {
        Task<string> Insert<T>(T obj);
        Task<ICollection<ConnectionEntity>> Get();
        Task<ConnectionEntity> GetById(string id);
        Task<string> Update<T>(T obj);
    }
}
