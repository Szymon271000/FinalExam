using SceneCrimeApi.DTOs;
using Newtonsoft.Json;
using SceneCrimeApi.Datas.Models;
using CrimeScene.DTO;
using CrimeScene.Datas.Models;

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

        public async Task AddEventCrimeToSQL(CreateCrimeSQLDTO createCrimeToSQL)
        {
            JsonContent content = JsonContent.Create(createCrimeToSQL);
            var result = await _httpClient.PostAsync("http://localhost:5260/api/LawEnforcement/AddCrime", content);
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

        public async Task AddEventToPoliceman(string policemanId, string eventId)
        {
            var policeman = await GetPolicemanById(policemanId);
            var result = _httpClient.PostAsJsonAsync($"http://localhost:5260/api/LawEnforcement/AddCrimeToPoliceman/{policemanId}/{eventId}", policeman);
        }

        public async Task<LawEnforcement> GetPolicemanById(string policemanId)
        {
            Guid idGuid = Guid.Parse(policemanId);
            var response = await _httpClient.GetAsync("http://localhost:5260/api/LawEnforcement/GetById/" + idGuid);
            if (response.IsSuccessStatusCode)
            {
                Newtonsoft.Json.JsonSerializer serializer = new();
                return serializer.Deserialize<LawEnforcement>(new JsonTextReader(new StringReader(await response.Content.ReadAsStringAsync())));
            }
            return null;
        }
    }
}
