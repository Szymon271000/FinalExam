using SceneCrimeApi.DTOs;
using Newtonsoft.Json;

namespace WebApp.Services
{
    public class CrimeEventManager: ICrimeEventManager
    {
        private readonly HttpClient _httpClient;

        public CrimeEventManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ReadCrimeEventDTO>> FetchAllCrimes()
        {
            var response = await _httpClient.GetAsync("http://localhost:5296/api/CrimeEvent/GetAllCrimes");
            if (response.IsSuccessStatusCode)
            {
                Newtonsoft.Json.JsonSerializer serializer = new();
                return serializer.Deserialize<List<ReadCrimeEventDTO>>(new JsonTextReader(new StringReader(await response.Content.ReadAsStringAsync())));

            }
            return null;
        }
        public async Task AddEventCrime(CreateCrimeEventDTO eventCrime)
        {
            JsonContent content = JsonContent.Create(eventCrime);
            var result = await _httpClient.PostAsync("http://localhost:5296/api/CrimeEvent/CreateNewCrimeEvent", content);
        }
    }
}
