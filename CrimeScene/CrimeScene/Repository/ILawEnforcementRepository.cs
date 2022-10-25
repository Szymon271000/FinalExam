using CrimeScene.Datas.Models;

namespace CrimeScene.Repository
{
    public interface ILawEnforcementRepository
    {
        public Task<List<LawEnforcement>> GetAll();
        public Task<LawEnforcement> GetById(Guid id);

        public Task Save();

    }
}
