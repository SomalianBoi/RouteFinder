using Finder.Application.DTOs.AirlineDtos;
using Finder.Application.DTOs.AirportDtos;
using Finder.Application.Interfaces;
using Finder.Application.Services;
using Finder.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finder.Web.Controllers
{
    public class AirlineController : Controller
    {
        private readonly IAirlineService _airlineService;    

        public AirlineController(IAirlineService airlineService)
        {
           _airlineService = airlineService;
        }
        public async Task<IActionResult> index()
        {
            var airlines = await _airlineService.GetAirlines();
            return View(airlines);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAirlineViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _airlineService.CreateAirlineAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var airlineDto =await _airlineService.GetDetailsForIdAsync(id);
            if(airlineDto == null)
            {
                return NotFound();
            }
            return View(airlineDto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _airlineService.DeleteAirlineAsync(id);
                TempData["SuccessMessage"] = "Airline deleted successfully";
                return RedirectToAction("Index");
            }catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Details", new {id});
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid airlineId)
        {
            var airline = await _airlineService.GetDetailsForIdAsync(airlineId);

            if (airline == null)
            {
                return NotFound(); // If no airline is found, return 404
            }

            var editAirlineDto = new EditAirlineViewModel
            {
                AirlineId = airline.AirlineId,
                IsActive = airline.IsActive // Pass the current 'IsActive' state
            };

            return View(editAirlineDto); // Return the edit view with the airline data
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditAirlineViewModel editAirlineDto)
        {
            if (!ModelState.IsValid)
            {
                return View(editAirlineDto); // Return to view with validation errors
            }

            try
            {
                await _airlineService.EditAirlineAsync(editAirlineDto); // Update the airline
                return RedirectToAction("Index"); // Redirect back to the index
            }
            catch (KeyNotFoundException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message); // Handle not found error
                return View(editAirlineDto); // Return with error message
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An unexpected error occurred."); // Handle unexpected errors
                return View(editAirlineDto); // Return with error message
            }
        }

    }

}
