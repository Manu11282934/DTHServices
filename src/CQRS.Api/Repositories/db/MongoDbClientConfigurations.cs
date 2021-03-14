using CQRS.Api.Repositories.Connections;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Api.Repositories.db
{
    public class MongoDbClientConfigurations : IMongoDbClientConfigurations
    {

        private readonly MongoClient _mongoClient;
        //private readonly IMongoDatabase _mongoDatabase;

        //  private readonly MongoClient _mongoClient;
      
        public MongoDbClientConfigurations()
        {
            string connectionString = "mongodb+srv://Manoj:manu1128@manojprojects-s4fkn.mongodb.net/DTH?retryWrites=true&w=majority";
            _mongoClient = new MongoClient(connectionString);           
            //_mongoDatabase = mongoDatabase;
            // _mongoDatabase = _mongoClient.GetDatabase("DTH");

        }
        public async Task<string> Insert<T>(T obj)
        {
            var _mongoDatabase = _mongoClient.GetDatabase("DTH");
            ConnectionEntity insert = new ConnectionEntity();
            var collection = _mongoDatabase.GetCollection<ConnectionEntity>("connections");
            collection.InsertOne(insert);
            return "Success";
        }

        public async Task<ICollection<ConnectionEntity>> Get()
        {
            var _mongoDatabase = _mongoClient.GetDatabase("DTH");
            ConnectionEntity insert = new ConnectionEntity();
            var collection = _mongoDatabase.GetCollection<ConnectionEntity>("connections");
            var result =  collection.AsQueryable().OrderByDescending(x=>x.RequestedDate).ToList();
            return result;
        }

        public async Task<ConnectionEntity> GetById(string id)
        {
            var _mongoDatabase = _mongoClient.GetDatabase("DTH");
            ConnectionEntity insert = new ConnectionEntity();
            var collection = _mongoDatabase.GetCollection<ConnectionEntity>("connections");
            var result = collection.AsQueryable().Where(x=>x.id==id).FirstOrDefault();
            return result;
        }

        public async Task<string> Update<T>(T obj)
        {
            var _mongoDatabase = _mongoClient.GetDatabase("DTH");
            ConnectionEntity update =obj as ConnectionEntity;
            var collection = _mongoDatabase.GetCollection<ConnectionEntity>("connections");
              collection.ReplaceOne(x => x.id == update.id, update);
            return "Success";
        }
    }
}
