using Finder.Application.DTOs;
using Finder.Application.DTOs.AirportDtos;
using Finder.Application.DTOs.FlightDtos;
using Finder.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Finder.Web.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightService _flightService;
        private readonly IAirlineService _airlineService;
        private readonly IAirportService _airportService;
        private readonly IPlaneService _planeService;

        public FlightController(
        IFlightService flightService,
        IAirlineService airlineService,
        IAirportService airportService,
        IPlaneService planeService)
        {
            _flightService = flightService;
            _airlineService = airlineService;
            _airportService = airportService;
            _planeService = planeService;
        }
        public async Task<IActionResult> Index()
        {
            var flights = await _flightService.GetAllFlightsAsync();
            return View(flights);  // Pass the list of flights to the view
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            // Fetch data
            var model = new CreateFlightViewModel();

            // Fetch the list of airlines from the service or repository
            var airlines = await _airlineService.GetAirlines();
            model.Airlines = airlines.Select(a => new AirlineCreateFlightDto
            {
                AirlineId = a.AirlineId,
                Name = a.Name // Assuming Name is the property to display
            }).ToList();

            // Fetch the list of airports from the service or repository
            var airports = await _airportService.GetAllAirports();
            model.Airports = airports.Select(a => new AirportCreateFlightDto
            {
                AirportId = a.AirportId,
                Name = a.Name, // Assuming Name is the property to display
                IcaoCode = a.IcaoCode // Assuming Code is the code of the airport (e.g., IATA or ICAO code)
            }).ToList();

            // Fetch the list of planes from the service or repository
            var planes = await _planeService.GetAllPlanes();
            model.Planes = planes.Select(p => new PlaneCreateFlightDto
            {
                PlaneId = p.PlaneId,
                Model = p.Name // Assuming Model is the property to display for planes
            }).ToList();

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateFlightViewModel model)
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                // Reload dropdowns to send back to the view in case of an error
                model.Airlines = (await _airlineService.GetAirlines())
                    .Select(a => new AirlineCreateFlightDto { AirlineId = a.AirlineId, Name = a.Name })
                    .ToList();

                model.Airports = (await _airportService.GetAllAirports())
                    .Select(a => new AirportCreateFlightDto { AirportId = a.AirportId, Name = $"{a.Name} ({a.IataCode})" })
                    .ToList();

                model.Planes = (await _planeService.GetAllPlanes())
                    .Select(p => new PlaneCreateFlightDto { PlaneId = p.PlaneId, Model = p.Name })
                    .ToList();

                return View(model);
            }

            // Map the DTO to the service's CreateFlightDto
            var flightDto = model.FlightDto;

            try
            {
                // Call the service to create the flight
                await _flightService.CreateFlightAsync(flightDto);
                return RedirectToAction("Index"); // Redirect to the list of flights after successful creation
            }
            catch (Exception ex)
            {
                // Handle errors (e.g., invalid foreign key IDs)
                ModelState.AddModelError(string.Empty, ex.Message);

                // Reload dropdowns to send back to the view
                model.Airlines = (await _airlineService.GetAirlines())
                    .Select(a => new AirlineCreateFlightDto { AirlineId = a.AirlineId, Name = a.Name })
                    .ToList();

                model.Airports = (await _airportService.GetAllAirports())
                    .Select(a => new AirportCreateFlightDto { AirportId = a.AirportId, Name = $"{a.Name} ({a.IataCode})" })
                    .ToList();

                model.Planes = (await _planeService.GetAllPlanes())
                    .Select(p => new PlaneCreateFlightDto { PlaneId = p.PlaneId, Model = p.Name })
                    .ToList();

                return View(model);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _flightService.DeleteFlightAsync(id);
                TempData["SuccessMessage"] = "Flight deleted successfully";
                return RedirectToAction("Index");
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", new { id });
            }
        }
        [HttpGet]
        public async Task<IActionResult> SearchDirectFlight()
        {
            var model = await _airportService.PrepareSearchDirectFlightViewModelAsync();
            return View(model);  // Return the search form with airports
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchDirectFlight(Guid sourceAirportId, Guid destinationAirportId)
        {
            // Get the dropdown model
            var model = await _airportService.PrepareSearchDirectFlightViewModelAsync();

            // Set selected airport ids to the model for maintaining state
            model.SourceAirportId = sourceAirportId;
            model.DestinationAirportId = destinationAirportId;

            // Get the list of direct flights between the selected airports
            var directFlights = await _flightService.GetDirectFlightAsync(sourceAirportId, destinationAirportId);

            if (directFlights == null || !directFlights.Any())
            {
                // If no direct flights found, show a message and return the dropdown view with selected airports
                TempData["Message"] = "No direct flights found between the specified airports.";
                return View(model);  // Return the dropdown model with the message
            }

            // If direct flights are found, pass them to the view
            ViewData["SearchDirectFlight"] = directFlights;

            // Return the same view (or a new one if you want) with the direct flight details
            return View("DirectFlights", directFlights);  // Show direct flight details in the "DirectFlights" view
        }

    }
}
