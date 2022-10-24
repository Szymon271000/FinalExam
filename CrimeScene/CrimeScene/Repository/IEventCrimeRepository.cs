using CrimeScene.Datas.Models;

namespace CrimeScene.Repository
{
    public interface IEventCrimeRepository
    {
        public Task Add(CrimeEvent crime);
    }
}
