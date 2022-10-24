using MongoDB.Driver;
using SceneCrimeApi.Datas.Models;
using SceneCrimeApi.Mongo;

namespace SceneCrimeApi.Datas.Services
{
    public class CrimeEventService : ICrimeEventService
    {
        private readonly IMongoCollection<CrimeEvent> _crimeEvents;
        public CrimeEventService(IDbClient dbClient)
        {
            _crimeEvents = dbClient.GetCrimesCollection();
        }

        public async Task AddCrimeEvent(CrimeEvent crimeEvent)
        {
            await _crimeEvents.InsertOneAsync(crimeEvent);
        }

        public async Task DeleteBook(string id)
        {
            await _crimeEvents.DeleteOneAsync(crime => crime.Id == id);
        }

        public async Task<CrimeEvent> GetCrimeEvent(string id)
        {
            return await _crimeEvents.Find(crime => crime.Id == id).FirstAsync();
        }

        public async Task<List<CrimeEvent>> GetEvents()
        {
            return await _crimeEvents.Find(crime => true).ToListAsync();
        }

        public async Task UpdateStatusIsAssigned(string id)
        {
            var crimeEvent = await GetCrimeEvent(id);
            crimeEvent.isAssigend = true;
            await _crimeEvents.ReplaceOneAsync(x => x.Id == crimeEvent.Id, crimeEvent);
        }

        public async Task UpdateStatusIsFinished(string id)
        {
            var crimeEvent = await GetCrimeEvent(id);
            crimeEvent.isFinished = true;
            await _crimeEvents.ReplaceOneAsync(x => x.Id == crimeEvent.Id, crimeEvent);
        }
    }
}
