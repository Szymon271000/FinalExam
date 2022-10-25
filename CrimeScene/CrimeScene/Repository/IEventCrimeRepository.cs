using CrimeScene.Datas.Models;

namespace CrimeScene.Repository
{
    public interface IEventCrimeRepository
    {
        public Task Add(CrimeEventSQL crime);
        public Task<CrimeEventSQL> GetById(string id);
    }
}
