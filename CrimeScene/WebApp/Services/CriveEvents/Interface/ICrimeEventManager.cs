using CrimeScene.Datas.Models;
using CrimeScene.DTO;
using SceneCrimeApi.DTOs;

namespace WebApp.Services
{
    public interface ICrimeEventManager
    {
        public Task<List<ReadCrimeEventDTO>> FetchAllCrimes();
        public Task AddEventCrime(CreateCrimeEventDTO eventCrime);
        public Task<ReadCrimeEventDTO> GetById(string id);
        public Task ChangeAssignStatus(string id, string lawEnforcementId);
        public Task UpdateStatusIsFinished(string id);
        public Task AddEventCrimeToSQL(CreateCrimeSQLDTO createCrimeToSQL);

        public Task AddEventToPoliceman(string policemanId, string eventId);

        public Task<LawEnforcement> GetPolicemanById(string policemanId);

    }
}
