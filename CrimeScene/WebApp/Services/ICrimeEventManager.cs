using SceneCrimeApi.DTOs;

namespace WebApp.Services
{
    public interface ICrimeEventManager
    {
        public Task<List<ReadCrimeEventDTO>> FetchAllCrimes();
        public Task AddEventCrime(CreateCrimeEventDTO eventCrime);

    }
}
