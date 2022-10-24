using SceneCrimeApi.Datas.Models;

namespace SceneCrimeApi.Datas.Services
{
    public interface ICrimeEventService
    {
        Task<List<CrimeEvent>> GetEvents();
        Task AddCrimeEvent (CrimeEvent crimeEvent);
        Task<CrimeEvent> GetCrimeEvent(string id);

        Task DeleteBook(string id);

        Task<List<CrimeEvent>> GetAllEventsOfGivenPoliceMan(string policemanId);
        Task UpdateStatusIsAssigned(string id);
        Task UpdateStatusIsFinished(string id);
    }
}
