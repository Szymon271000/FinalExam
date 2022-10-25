using MongoDB.Driver;
using SceneCrimeApi.Datas.Docker;
using SceneCrimeApi.Datas.Models;
using SceneCrimeApi.Mongo;

namespace SceneCrimeApi.Datas.Services
{
    public class CrimeRepository : ICrimeRepository
    {
        //private readonly IMongoCollection<CrimeEvent> _crimeEvents;
        //public CrimeEventService(IDbClient dbClient)
        //{
        //    _crimeEvents = dbClient.GetCrimesCollection();
        //}
        private readonly ICrimeContext _crimeEvents;
        public CrimeRepository(ICrimeContext context)
        {
            _crimeEvents = context;
        }

        public async Task AddCrimeEvent(CrimeEvent crimeEvent)
        {
            await _crimeEvents.CrimeEvents.InsertOneAsync(crimeEvent);
        }

        public async Task DeleteBook(string id)
        {
            await _crimeEvents.CrimeEvents.DeleteOneAsync(crime => crime.Id == id);
        }

        public async Task<List<CrimeEvent>> GetAllEventsOfGivenPoliceMan(string policemanId)
        {
            return await _crimeEvents.CrimeEvents.Find(crime => crime.lawEnforcementId == policemanId).ToListAsync();
        }

        public async Task<CrimeEvent> GetCrimeEvent(string id)
        {
            return await _crimeEvents.CrimeEvents.Find(crime => crime.Id == id).FirstAsync();
        }

        public async Task<List<CrimeEvent>> GetEvents()
        {
            return await _crimeEvents.CrimeEvents.Find(crime => true).ToListAsync();
        }

        public async Task UpdateStatusIsAssigned(string id, string lawEnforcementId)
        {
            var crimeEvent = await GetCrimeEvent(id);
            crimeEvent.isAssigend = true;
            crimeEvent.lawEnforcementId = lawEnforcementId;
            await _crimeEvents.CrimeEvents.ReplaceOneAsync(x => x.Id == crimeEvent.Id, crimeEvent);
        }

        public async Task UpdateStatusIsFinished(string id)
        {
            var crimeEvent = await GetCrimeEvent(id);
            crimeEvent.isFinished = true;
            await _crimeEvents.CrimeEvents.ReplaceOneAsync(x => x.Id == crimeEvent.Id, crimeEvent);
        }
    }
}
