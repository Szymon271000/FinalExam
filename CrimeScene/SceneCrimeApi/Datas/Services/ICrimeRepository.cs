using SceneCrimeApi.Datas.Models;

namespace SceneCrimeApi.Datas.Services
{
    public interface ICrimeRepository
    {
        Task<List<CrimeEvent>> GetEvents();
        Task AddCrimeEvent (CrimeEvent crimeEvent);
        Task<CrimeEvent> GetCrimeEvent(string id);

        Task DeleteBook(string id);

        Task<List<CrimeEvent>> GetAllEventsOfGivenPoliceMan(string policemanId);
        Task UpdateStatusIsAssigned(string id, string lawEnforcementId);
        Task UpdateStatusIsFinished(string id);
    }
}
