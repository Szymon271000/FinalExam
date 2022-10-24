using CrimeScene.Datas.Context;
using CrimeScene.Datas.Models;
using Microsoft.EntityFrameworkCore;
using SceneCrimeApi.Datas.Models;

namespace CrimeScene.Repository
{
    public class LawEnforcementRepository : ILawEnforcementRepository
    {
        private readonly LawEnforcementContext _lawEnforcementContext;
        public LawEnforcementRepository(LawEnforcementContext lawEnforcementContext)
        {
            _lawEnforcementContext = lawEnforcementContext;
        }
        public async Task AddCrimeToPolicemen(Guid policemenId, CrimeEvent crimeEvent)
        {
            var policeMan = await GetById(policemenId);
            policeMan.crimeEvents.Add(crimeEvent);
            await Save();
        }

        public async Task<List<LawEnforcement>> GetAll()
        {
            return await _lawEnforcementContext.lawEnforcements.Include(x=> x.RankEnforcement).Include(x=> x.crimeEvents).ToListAsync();   
        }

        public async Task<LawEnforcement> GetById(Guid id)
        {
            return await _lawEnforcementContext.lawEnforcements.Include(x => x.RankEnforcement).Include(x => x.crimeEvents).FirstOrDefaultAsync();
        }

        public async Task Save()
        {
            await _lawEnforcementContext.SaveChangesAsync();
        }
    }
}
