using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SceneCrimeApi.Datas.Models;

namespace SceneCrimeApi.Mongo
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<CrimeEvent> _crimeEvents;
        public DbClient(IOptions<CrimeDbConfig> crimeDbConfig)
        {
            var client = new MongoClient(crimeDbConfig.Value.Connection_String);
            var database = client.GetDatabase(crimeDbConfig.Value.Database_Name);
            _crimeEvents = database.GetCollection<CrimeEvent>(crimeDbConfig.Value.Crimes_Collection_Name);

        }
        public IMongoCollection<CrimeEvent> GetCrimesCollection() => _crimeEvents; 

    }
}
