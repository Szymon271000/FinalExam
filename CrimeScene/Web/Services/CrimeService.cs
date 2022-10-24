using SceneCrimeApi.DTOs;

namespace Web.Services
{
    public class CrimeService
    {
        private readonly HttpClient _httpClient;
        public CrimeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ReadCrimeEventDTO>> GetAppointmenstAsync()
        {
            var crimes = await _httpClient.GetAsync("https://localhost:5296/api/CrimeEvent/GetAllCrimes");
            if (crimes.IsSuccessStatusCode)
            {

            }
            return new List<ReadCrimeEventDTO>();
        }
    }
}
