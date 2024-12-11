using Finder.Application.DTOs.PlaneDtos;
using Finder.Application.Interfaces;
using Finder.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Finder.Web.Controllers
{
    public class PlaneController : Controller
    {
        private readonly IPlaneService _laneService;

        public PlaneController(IPlaneService planeService)
        {
            _laneService = planeService;
        }
        public async Task<IActionResult> Index()
        {
            var planes = await _laneService.GetAllPlanes();
            return View(planes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePlaneDto dto)
        {
            if(ModelState.IsValid)
            {
                await _laneService.CreatePlaneAsync(dto);
                return RedirectToAction("Index");
            }
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _laneService.DeletePlaneAsync(id);
                TempData["SuccessMessage"] = "Plane deleted successfully";
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
