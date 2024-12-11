using Finder.Application.Interfaces;
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
    }
}
