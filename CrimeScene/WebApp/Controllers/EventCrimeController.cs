using Microsoft.AspNetCore.Mvc;
using SceneCrimeApi.DTOs;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class EventCrimeController : Controller
    {
        private readonly ICrimeEventManager _eventCrimeManager;

        public EventCrimeController(ICrimeEventManager eventCrimeManager)
        {
            _eventCrimeManager = eventCrimeManager;
        }
        public async Task<IActionResult> Index(List<ReadCrimeEventDTO> crimes)
        {
            var result = await _eventCrimeManager.FetchAllCrimes();
            return View(result);
        }
    }
}
