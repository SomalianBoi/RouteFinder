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
    }
}
