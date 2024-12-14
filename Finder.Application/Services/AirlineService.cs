using Finder.Application.DTOs.AirlineDtos;
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
    public class AirlineService : IAirlineService
    {
        private readonly IAirlineRepository _airlineRepository;
        private readonly IFlightRepository _flightRepository;

        public AirlineService(IAirlineRepository airlineRepository, IFlightRepository flightRepository)
        {
            _airlineRepository = airlineRepository;
            _flightRepository = flightRepository;
        }
        public async Task<IEnumerable<AirlineViewModel>> GetAirlines()
        {
            var airlines =await _airlineRepository.GetAirlinesAsync();

            return airlines.Select(f => new AirlineViewModel
            {
                AirlineId = f.AirlineId,
                Name = f.Name,
                Alias = f.Alias,
                Country = f.Country,
                IsActive = f.IsActive,
                Flights = f.Flights?.ToList() ?? new List<Flight>()
            }).ToList();
        }
        public async Task CreateAirlineAsync(CreateAirlineViewModel airlineView)
        {
            var airline = new Airline
            {
                AirlineId = airlineView.AirlineId,
                Name = airlineView.Name,
                Alias = airlineView.Alias,
                IATA = airlineView.IATA,
                ICAO = airlineView.ICAO,
                Callsign = airlineView.Callsign,
                Country = airlineView.Country,
                IsActive = airlineView.IsActive,
                Flights = new List<Flight>()
            };
            await _airlineRepository.addAsync(airline);
        }
        public async Task<AirlineDetailsDto> GetDetailsForIdAsync(Guid id)
        {
            var airline =await _airlineRepository.GetAirlineByIdAsync(id);

            if (airline == null)
            {
                return null; // Handle null case appropriately
            }
            var airlineDto = new AirlineDetailsDto
            {
                AirlineId = airline.AirlineId,
                Name = airline.Name,
                Alias = airline.Alias,
                IATA = airline.IATA,
                ICAO = airline.ICAO,
                Callsign = airline.Callsign,
                Country = airline.Country,
                IsActive = airline.IsActive,
                Flights = airline.Flights ?? new List<Flight>()
            };
            return airlineDto;
        }
        public async Task DeleteAirlineAsync(Guid id)
        {
            try
            {
                await _airlineRepository.DeleteAirlineAsync(id);
            }catch(KeyNotFoundException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public async Task EditAirlineAsync(EditAirlineViewModel editAirlineDto)
        {
            var airline = await _airlineRepository.GetAirlineByIdAsync(editAirlineDto.AirlineId);

            if (airline == null)
            {
                throw new ArgumentException("Airline not found.", nameof(editAirlineDto.AirlineId));
            }

            // Check if the status is being changed
            if (airline.IsActive != editAirlineDto.IsActive)
            {
                if (!editAirlineDto.IsActive) // Transitioning to inactive
                {
                    if (airline.Flights != null && airline.Flights.Any())
                    {
                        foreach (var flight in airline.Flights.ToList())
                        {
                            await _flightRepository.DeleteFlightAsync(flight.FlightId); // Remove associated flights
                        }
                    }
                }

                // Update airline status
                airline.IsActive = editAirlineDto.IsActive;
                await _airlineRepository.UpdateAirlineAsync(airline);
            }
        }

    }
}
