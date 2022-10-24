using CrimeScene.Datas.Context;
using CrimeScene.Datas.Models;
using SceneCrimeApi.Datas.Models;

namespace CrimeScene.Repository
{
    public interface ILawEnforcementRepository
    {
        public Task<List<LawEnforcement>> GetAll();
        public Task<LawEnforcement> GetById(Guid id);

        public Task Save();
        public Task AddCrimeToPolicemen(Guid policemenId, CrimeEvent crimeEvent);
    }
}
