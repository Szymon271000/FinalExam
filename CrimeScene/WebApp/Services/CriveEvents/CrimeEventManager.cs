using SceneCrimeApi.DTOs;
using Newtonsoft.Json;
using CrimeScene.DTO;
using CrimeScene.Datas.Models;

namespace WebApp.Services
{
    public class CrimeEventManager: ICrimeEventManager
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public CrimeEventManager(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<List<ReadCrimeEventDTO>> FetchAllCrimes()
        {
            return await _httpClient.GetFromJsonAsync<List<ReadCrimeEventDTO>>(_configuration.GetValue<string>("ApiMethods:GetAllCrimes"));
        }
        public async Task AddEventCrime(CreateCrimeEventDTO eventCrime)
        {
            JsonContent content = JsonContent.Create(eventCrime);
            var result = await _httpClient.PostAsync(_configuration.GetValue<string>("ApiMethods:CreateNewCrime"), content);
        }

        public async Task AddEventCrimeToSQL(CreateCrimeSQLDTO createCrimeToSQL)
        {
            JsonContent content = JsonContent.Create(createCrimeToSQL);
            var result = await _httpClient.PostAsync(_configuration.GetValue<string>("ApiMethods:AddEventCrimeToSQL"), content);
        }

        public async Task<ReadCrimeEventDTO> GetById(string id)
        {
            var response = await _httpClient.GetAsync(_configuration.GetValue<string>("ApiMethods:GetById") + id);
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
            var updatedCrime = _httpClient.PutAsJsonAsync($"{_configuration.GetValue<string>("ApiMethods:ChangeAssignStatus")}{id}/{lawEnforcementId}", response);
        }

        public async Task UpdateStatusIsFinished(string id)
        {
            var response = await GetById(id);
            if (response.isAssigend == true)
            {
                response.isFinished = true;
                var updatedCrime = _httpClient.PutAsJsonAsync($"{_configuration.GetValue<string>("ApiMethods:UpdateStatusIsFinished")}{id}", response);
            }
        }

        public async Task AddEventToPoliceman(string policemanId, string eventId)
        {
            var policeman = await GetPolicemanById(policemanId);
            var result = _httpClient.PostAsJsonAsync($"{_configuration.GetValue<string>("ApiMethods:AddEventToPoliceman")}{policemanId}/{eventId}", policeman);
        }

        public async Task<LawEnforcement> GetPolicemanById(string policemanId)
        {
            Guid idGuid = Guid.Parse(policemanId);
            var response = await _httpClient.GetAsync($"{_configuration.GetValue<string>("ApiMethods:GetPolicemanById")}" + idGuid);
            if (response.IsSuccessStatusCode)
            {
                Newtonsoft.Json.JsonSerializer serializer = new();
                return serializer.Deserialize<LawEnforcement>(new JsonTextReader(new StringReader(await response.Content.ReadAsStringAsync())));
            }
            return null;
        }
    }
}
