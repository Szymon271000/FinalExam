using CrimeScene.Datas.Context;
using CrimeScene.Datas.Models;

namespace CrimeScene.Repository
{
    public class EventCrimeRepository : IEventCrimeRepository
    {
        private readonly LawEnforcementContext _lawEnforcementContext;
        public EventCrimeRepository(LawEnforcementContext lawEnforcementContext)
        {
            _lawEnforcementContext = lawEnforcementContext;
        }

        public async Task Add(CrimeEvent crime)
        {
            await _lawEnforcementContext.crimeEvents.AddAsync(crime);
            await _lawEnforcementContext.SaveChangesAsync();
        }
    }
}
