using SceneCrimeApi.DTOs;
using Newtonsoft.Json;
using SceneCrimeApi.Datas.Models;

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
            return await _httpClient.GetFromJsonAsync<List<ReadCrimeEventDTO>>("http://localhost:5296/api/CrimeEvent/GetAllCrimes");
        }
        public async Task AddEventCrime(CreateCrimeEventDTO eventCrime)
        {
            JsonContent content = JsonContent.Create(eventCrime);
            var result = await _httpClient.PostAsync("http://localhost:5296/api/CrimeEvent/CreateNewCrimeEvent", content);
        }

        public async Task<ReadCrimeEventDTO> GetById(string id)
        {
            var response = await _httpClient.GetAsync("http://localhost:5296/api/CrimeEvent/GetCrimeEventById/" + id);
            if (response.IsSuccessStatusCode)
            {
                Newtonsoft.Json.JsonSerializer serializer = new();
                return serializer.Deserialize<ReadCrimeEventDTO>(new JsonTextReader(new StringReader(await response.Content.ReadAsStringAsync())));
            }
            return null;
        }

        public async Task ChangeAssignStatus(string id, string lawEnforcementId)
        {
            var response = await GetById(id);
            response.isAssigend = true;
            response.lawEnforcementId = lawEnforcementId;
            var updatedCrime = _httpClient.PutAsJsonAsync($"http://localhost:5296/api/CrimeEvent/UpdateIsAssinged/{id}/{lawEnforcementId}", response);
        }

        public async Task UpdateStatusIsFinished(string id)
        {
            var response = await GetById(id);
            if (response.isAssigend == true)
            {
                response.isFinished = true;
                var updatedCrime = _httpClient.PutAsJsonAsync($"http://localhost:5296/api/CrimeEvent/UpdateIsFinished/{id}", response);
            }
        }
    }
}
