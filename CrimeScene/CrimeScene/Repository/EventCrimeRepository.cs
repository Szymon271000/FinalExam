using CrimeScene.Datas.Context;
using CrimeScene.Datas.Models;
using Microsoft.EntityFrameworkCore;

namespace CrimeScene.Repository
{
    public class EventCrimeRepository : IEventCrimeRepository
    {
        private readonly LawEnforcementContext _lawEnforcementContext;
        public EventCrimeRepository(LawEnforcementContext lawEnforcementContext)
        {
            _lawEnforcementContext = lawEnforcementContext;
        }

        public async Task Add(CrimeEventSQL crime)
        {
            await _lawEnforcementContext.crimeEvents.AddAsync(crime);
            await _lawEnforcementContext.SaveChangesAsync();
        }

        public async Task<CrimeEventSQL> GetById(string id)
        {
            return await _lawEnforcementContext.crimeEvents.Where(x => x.EventId == id).FirstOrDefaultAsync();
        }
    }
}
