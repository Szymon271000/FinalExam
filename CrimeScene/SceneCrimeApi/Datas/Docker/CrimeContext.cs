using MongoDB.Driver;
using SceneCrimeApi.Datas.Models;
using SceneCrimeApi.Mongo;

namespace SceneCrimeApi.Datas.Docker
{
    public class CrimeContext: ICrimeContext
    {
        private readonly IMongoDatabase _db;
        public CrimeContext(MongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
        }
        public IMongoCollection<CrimeEvent> CrimeEvents => _db.GetCollection<CrimeEvent>("Todos");
    }
}
