using CrimeScene.Datas.Models;
using CrimeScene.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrimeScene.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LawEnforcementController : ControllerBase
    {
        private readonly ILawEnforcementRepository _lawEnforcementRepository;
        private readonly IEventCrimeRepository _eventCrimeRepository;
        public LawEnforcementController(ILawEnforcementRepository lawEnforcementRepository, IEventCrimeRepository eventCrimeRepository)
        {
            _lawEnforcementRepository = lawEnforcementRepository;
            _eventCrimeRepository = eventCrimeRepository;
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
        public async Task<IActionResult> AddCrime(CrimeEvent crimeEvent)
        {
            await _eventCrimeRepository.Add(crimeEvent);
            return Ok();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var policeman = await _lawEnforcementRepository.GetById(id);
            return Ok(policeman);
        }
    }
}
