using CrimeScene.Datas.Context;
using CrimeScene.Datas.Models;
using Microsoft.EntityFrameworkCore;

namespace CrimeScene.Repository
{
    public class LawEnforcementRepository : ILawEnforcementRepository
    {
        private readonly LawEnforcementContext _lawEnforcementContext;
        public LawEnforcementRepository(LawEnforcementContext lawEnforcementContext)
        {
            _lawEnforcementContext = lawEnforcementContext;
        }

        public async Task<List<LawEnforcement>> GetAll()
        {
            return await _lawEnforcementContext.lawEnforcements.Include(x=> x.Events).Include(x=> x.RankEnforcement).ToListAsync();   
        }

        public async Task<LawEnforcement> GetById(Guid id)
        {
            return await _lawEnforcementContext.lawEnforcements.Where(x=> x.Id == id).Include(x=> x.Events).Include(x => x.RankEnforcement).FirstOrDefaultAsync();
        }

        public async Task Save()
        {
            await _lawEnforcementContext.SaveChangesAsync();
        }
    }
}
