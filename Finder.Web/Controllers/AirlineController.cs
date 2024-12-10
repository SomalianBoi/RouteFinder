using Finder.Domain.Entities;
using Finder.Domain.Entities.Dtos;
using Finder.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finder.Web.Controllers
{
    public class AirlineController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AirlineController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var airlines = _context.Airlines
                .Include(a=>a.Flights).ThenInclude(f=>f.SourceAirportNavigation)
                .Include(a=>a.Flights).ThenInclude(f=>f.DestinationAirportNavigation)
                .ToList();

            var viewModel = airlines.Select(f => new AirlineViewModel
            {
                AirlineId = f.AirlineId,
                Name = f.Name,
                Alias = f.Alias,
                Country = f.Country,
                IsActive = f.IsActive,
                Flights = f.Flights?.ToList() ?? new List<Flight>()
            }).ToList();

            return View(viewModel);
        }
    }
}
