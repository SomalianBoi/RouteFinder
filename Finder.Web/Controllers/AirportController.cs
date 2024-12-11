using Finder.Application.DTOs.AirlineDtos;
using Finder.Application.DTOs.AirportDtos;
using Finder.Application.Interfaces;
using Finder.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Finder.Web.Controllers
{
    public class AirportController : Controller
    {
        private readonly IAirportService _airportService;

        public AirportController(IAirportService airportService)
        {
            _airportService = airportService;
        }
        public async Task<IActionResult> Index()
        {
            var airports = await _airportService.GetAllAirports();
            return View(airports);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAirportDto model)
        {
            if (ModelState.IsValid)
            {
                await _airportService.CreateAirportAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _airportService.DeleteAirportAsync(id);
                TempData["SuccessMessage"] = "Airport deleted successfully";
                return RedirectToAction("Index");
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", new { id });
            }
        }
    }
}
