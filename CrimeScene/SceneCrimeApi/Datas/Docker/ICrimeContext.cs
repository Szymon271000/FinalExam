using MongoDB.Driver;
using SceneCrimeApi.Datas.Models;

namespace SceneCrimeApi.Datas.Docker
{
    public interface ICrimeContext
    {
        IMongoCollection<CrimeEvent> CrimeEvents { get; }
    }
}
