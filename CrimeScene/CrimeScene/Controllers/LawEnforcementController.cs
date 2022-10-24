using CrimeScene.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SceneCrimeApi.Datas.Models;

namespace CrimeScene.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LawEnforcementController : ControllerBase
    {
        private readonly ILawEnforcementRepository _lawEnforcementRepository;
        public LawEnforcementController(ILawEnforcementRepository lawEnforcementRepository)
        {
            _lawEnforcementRepository = lawEnforcementRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllPolicemen()
        {
            var policemen = await _lawEnforcementRepository.GetAll();
            return Ok(policemen);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var policeman = await _lawEnforcementRepository.GetById(id);
            return Ok(policeman);
        }

        [HttpPost]
        [Route("AddEvent/{policemenId}")]
        public async Task<IActionResult> AddCrimeToPolicemen(Guid policemenId, CrimeEvent crimeEvent)
        {
            _lawEnforcementRepository.AddCrimeToPolicemen(policemenId, crimeEvent);
            return NoContent();
        }
    }
}
