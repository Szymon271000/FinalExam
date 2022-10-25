using AutoMapper;
using CrimeScene.Datas.Models;
using CrimeScene.DTO;
using CrimeScene.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CrimeScene.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LawEnforcementController : ControllerBase
    {
        private readonly ILawEnforcementRepository _lawEnforcementRepository;
        private readonly IEventCrimeRepository _eventCrimeRepository;
        private readonly IMapper _mapper;
        public LawEnforcementController(ILawEnforcementRepository lawEnforcementRepository, IEventCrimeRepository eventCrimeRepository, IMapper mapper)
        {
            _lawEnforcementRepository = lawEnforcementRepository;
            _eventCrimeRepository = eventCrimeRepository;
            _mapper = mapper;   
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllPolicemen()
        {
            var policemen = await _lawEnforcementRepository.GetAll();
            return Ok(policemen);
        }


        [HttpPost]
        [Route("AddCrime")]
        public async Task<IActionResult> AddCrime(CreateCrimeSQLDTO crimeEvent)
        {
            var crimeEventToAdd = _mapper.Map<CrimeEventSQL>(crimeEvent);
            await _eventCrimeRepository.Add(crimeEventToAdd);
            return Ok();
        }

        [HttpPost]
        [Route("AddPoliceman")]
        public async Task<IActionResult> AddPoliceman(CreatePolicemanDTO lawEnforcement)
        {
            var policemanToAdd = _mapper.Map<LawEnforcement>(lawEnforcement);
            await _lawEnforcementRepository.Add(policemanToAdd);
            return Ok();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var policeman = await _lawEnforcementRepository.GetById(id);
            return Ok(policeman);
        }

        [HttpPost]
        [Route("AddCrimeToPoliceman/{id}/{eventId}")]
        public async Task<IActionResult> AddCrimeToPoliceman(Guid id, string eventId)
        {
            var crimeEvent = await _eventCrimeRepository.GetById(eventId);
            var policeMan = await _lawEnforcementRepository.GetById(id);
            policeMan.Events.Add(crimeEvent);
            await _lawEnforcementRepository.Save();
            return Ok();
        }

    }
}
