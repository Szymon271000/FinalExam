using CrimeScene.DTO;
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
        public async Task<IActionResult> Index()
        {
            var result = await _eventCrimeManager.FetchAllCrimes();
            var crimesToDisplay = result.Where(x=> x.isFinished == false).ToList();
            return View(crimesToDisplay);
        }

        public ActionResult AddCrime()
        {
            return View();
        }

        public ActionResult AddPoliceman()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddPolicemanToDatabase([Bind("Id")] CreatePolicemanDTO policeman)
        {
            if (ModelState.IsValid)
            {
                await _eventCrimeManager.AddPoliceman(policeman);
            }
            return RedirectToAction("Index", "EventCrime");
        }


        [HttpPost]
        public async Task<IActionResult> AddCrimeToDatabase([Bind("type", "shortDescription", "city", "address", "postalCode", "rapportPerson")] CreateCrimeEventDTO crime)
        {
            if (ModelState.IsValid)
            {
                await _eventCrimeManager.AddEventCrime(crime);
            }
            return RedirectToAction("Index", "EventCrime");
        }

        public async Task<ActionResult> Details(string crimeId)
        {
            var crime = await _eventCrimeManager.GetById(crimeId);
            return View(crime);
        }


        public async Task<ActionResult> ChangeAssignStatus(string crimeId, string lawEnforcementId, string EventId, string Description)
        {
            CreateCrimeSQLDTO crimeSceneToSql = new CreateCrimeSQLDTO
            {
                EventId = EventId,
                Description = Description
            };
            await _eventCrimeManager.AddEventCrimeToSQL(crimeSceneToSql);
            await _eventCrimeManager.ChangeAssignStatus(crimeId, lawEnforcementId);
            await _eventCrimeManager.AddEventToPoliceman(lawEnforcementId, crimeId);
            return RedirectToAction("Index", "EventCrime");
        }

        public async Task<ActionResult> ChangeStatusIsFinished(string crimeId)
        {
            await _eventCrimeManager.UpdateStatusIsFinished(crimeId);
            return RedirectToAction("Index", "EventCrime");
        }
    }
}
