using Finder.Application.DTOs.AirlineDtos;
using Finder.Application.Interfaces;
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
    }

}
