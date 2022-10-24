using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SceneCrimeApi.Datas.Models;
using SceneCrimeApi.Datas.Services;
using SceneCrimeApi.DTOs;

namespace SceneCrimeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrimeEventController : ControllerBase
    {
        private readonly ICrimeEventService _crimeEventService;
        private IMapper _mapper;

        public CrimeEventController(ICrimeEventService crimeEventService, IMapper mapper)
        {
            _crimeEventService = crimeEventService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllCrimes")]
        public async Task <IActionResult> GetCrimeEvents()
        {
            var crimeEvents = await _crimeEventService.GetEvents();
            if (crimeEvents == null)
            {
                return this.NotFound("There is no crime events in context");
            }
            return Ok(_mapper.Map<IEnumerable<ReadCrimeEventDTO>>(crimeEvents));

        }

        [HttpGet]
        [Route("GetAllCrimesOfGivenPolicemen/{id}")]
        public async Task<IActionResult> GetCrimeEventsOfPoliceman(string id)
        {
            var crimeEvents = await _crimeEventService.GetAllEventsOfGivenPoliceMan(id);
            if (crimeEvents == null)
            {
                return this.NotFound("There is no crime events in context");
            }
            return Ok(_mapper.Map<IEnumerable<ReadCrimeEventDTO>>(crimeEvents));

        }

        [HttpGet]
        [Route("GetCrimeEventById/{id}")]
        public async Task<IActionResult> GetCrimeEventById(string id)
        {
            var crimeEvent = await _crimeEventService.GetCrimeEvent(id);
            if (crimeEvent == null)
            {
                return this.NotFound("This crime event does not exist");
            }
            return Ok(_mapper.Map<ReadCrimeEventDTO>(crimeEvent));

        }

        [HttpPost]
        [Route("CreateNewCrimeEvent")]
        public async Task<IActionResult> AddEvent(CreateCrimeEventDTO crimeEvent)
        {
            if (ModelState.IsValid)
            {
                var crimeEventToAdd = _mapper.Map<CrimeEvent>(crimeEvent);
                await _crimeEventService.AddCrimeEvent(crimeEventToAdd);
                return Ok(_mapper.Map<ReadCrimeEventDTO>(crimeEventToAdd));
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteEvent(string id)
        {
            await _crimeEventService.DeleteBook(id);
            return NoContent();
        }

        [HttpPut]
        [Route("UpdateIsAssinged/{id}/{lawEnforcementId}")]
        public async Task<IActionResult> UpdateStatusIsAssigned(string id, string lawEnforcementId)
        {
            await _crimeEventService.UpdateStatusIsAssigned(id, lawEnforcementId);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateIsFinished/{id}")]
        public async Task<IActionResult> UpdateStatusIsFinished(string id)
        {
            await _crimeEventService.UpdateStatusIsFinished(id);
            return Ok();
        }
    }
}
