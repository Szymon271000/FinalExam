﻿using Microsoft.AspNetCore.Mvc;
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

        public ActionResult AddCrime()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCrimeToDatabase([Bind("type", "shortDescription", "city", "address", "postalCode")] CreateCrimeEventDTO crime)
        {
            if (ModelState.IsValid)
            {
                await _eventCrimeManager.AddEventCrime(crime);
            }
            return RedirectToAction("Index", "EventCrime");
        }
    }
}
