using MongoDB.Driver;
using SceneCrimeApi.Datas.Models;

namespace SceneCrimeApi.Mongo
{
    public interface IDbClient
    {
        IMongoCollection<CrimeEvent> GetCrimesCollection();
    }
}
