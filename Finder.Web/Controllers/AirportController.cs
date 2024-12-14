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
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var editAirportDto = await _airportService.GetAirportByIdAsync(id);

            if (editAirportDto == null)
            {
                return NotFound($"Airport with ID {id} not found.");
            }
            return View(editAirportDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditAirportDto editAirportDto)
        {
            if (!ModelState.IsValid)
            {
                return View(editAirportDto);
            }
            try
            {
                await _airportService.UpdateAirportAsync(editAirportDto);
                return RedirectToAction("Index");
            }catch (KeyNotFoundException ex) 
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(editAirportDto);
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                ModelState.AddModelError(string.Empty, "An unexpected error occurred.");
                return View(editAirportDto);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            // Retrieve the airport details from the service
            var airport = await _airportService.GetAirportDetails(id);

            if (airport == null)
            {
                // Return a 404 Not Found view if the airport is not found
                return NotFound($"Airport with ID {id} not found.");
            }

            // Pass the airport details to the view
            return View(airport);
        }
    }
}
