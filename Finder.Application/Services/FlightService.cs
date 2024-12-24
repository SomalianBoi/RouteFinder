using Finder.Application.DTOs;
using Finder.Application.DTOs.FlightDtos;
using Finder.Application.Interfaces;
using Finder.Domain.Entities;
using Finder.Domain.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Application.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IAirlineRepository _airlineRepository;
        private readonly IAirportRepository _airportRepository;
        private readonly IPlaneRepository _planeRepository;

        public FlightService(IFlightRepository flightRepository, IAirlineRepository airlineRepository, IAirportRepository airportRepository, IPlaneRepository planeRepository)
        {
            _flightRepository = flightRepository;
            _airlineRepository = airlineRepository;
            _airportRepository = airportRepository;
            _planeRepository = planeRepository;
        }
        // Service method to get all flights
        public async Task<IEnumerable<Flight>> GetAllFlightsAsync()
        {
            return await _flightRepository.GetAllFlightsAsync();
        }
        public async Task CreateFlightAsync(CreateFlightDto flightDto)
        {
            // Fetch related entities from repositories
            var airline = await _airlineRepository.GetAirlineByIdAsync(flightDto.AirlineId);
            var sourceAirport = await _airportRepository.GetAirportByIdAsync(flightDto.SourceAirportId);
            var destinationAirport = await _airportRepository.GetAirportByIdAsync(flightDto.DestinationAirportId);
            var plane = await _planeRepository.GetPlaneByIdAsync(flightDto.PlaneId);

            if (airline == null || sourceAirport == null || destinationAirport == null || plane == null)
            {
                throw new ArgumentException("Invalid data provided for creating the flight.");
            }

            // Create the flight entity
            var flight = new Flight
            {
                AirlineId = flightDto.AirlineId,
                SourceAirportId = flightDto.SourceAirportId,
                DestinationAirportId = flightDto.DestinationAirportId,
                PlaneId = flightDto.PlaneId,
                Stops = 0, // Assuming no stops
                DurationInMinutes = flightDto.DurationInMinutes
            };

            // Add the flight to the repository
            await _flightRepository.CreateFlight(flight);
        }

        public async Task DeleteFlightAsync(Guid id)
        {
            try
            {
                await _flightRepository.DeleteFlightAsync(id);
            }
            catch (KeyNotFoundException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public async Task<List<DirectFlightDto>> GetDirectFlightAsync(Guid sourceAirportId, Guid destinationAirportId)
        {
            var flights = await _flightRepository.GetDirectFlightAsync(sourceAirportId, destinationAirportId);

            if (flights == null || !flights.Any())
            {
                return new List<DirectFlightDto>(); // No flights found
            }

            return flights.Select(flight => new DirectFlightDto
            {
                FlightId = flight.FlightId,
                AirlineName = flight.airline.Name,
                SourceAirport = flight.SourceAirportNavigation.Name,
                DestinationAirport = flight.DestinationAirportNavigation.Name,
                DurationInMinutes = flight.DurationInMinutes
            }).ToList();
        }
        public async Task<List<FlightDto>> GetFlightsByAirlineAndPlaneAsync(Guid airlineId, Guid planeId)
        {
            // Fetch flights from the repository
            var flights = await _flightRepository.GetFlightsByAirlineAndPlaneAsync(airlineId, planeId);

            // Map the flights to FlightDto
            var flightDtos = flights.Select(f => new FlightDto
            {
                FlightId = f.FlightId,
                AirlineName = f.airline.Name,
                SourceAirportIataCode = f.SourceAirportNavigation.IataCode,
                DestinationAirportIataCode = f.DestinationAirportNavigation.IataCode,
                PlaneModel = f.plane.Name,
                DurationInMinutes = f.DurationInMinutes,
                Stops = f.Stops
            }).ToList();

            return flightDtos;
        }
        public async Task<List<RouteDto>> FindRoutesBetweenAirportsAsync(Guid sourceAirportId, Guid destinationAirportId)
        {
            var routes = await _flightRepository.GetConnectingFlightsAsync(sourceAirportId, destinationAirportId);

            return routes.Select(route => new RouteDto
            {
                TotalDuration = route.Sum(f => f.DurationInMinutes),
                Stops = route.Count - 1,
                Flights = route.Select(f => new ConnectingFlightDto
                {
                    FlightId = f.FlightId,
                    AirlineName = f.airline?.Name,
                    SourceAirport = f.SourceAirportNavigation?.Name,
                    DestinationAirport = f.DestinationAirportNavigation?.Name,
                    PlaneModel = f.plane?.Name,
                    DurationInMinutes = f.DurationInMinutes
                }).ToList()
            }).OrderBy(r => r.TotalDuration).ToList();
        }

    }
}
