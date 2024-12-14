using Finder.Application.DTOs.AirportDtos;
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
    public class AirportService : IAirportService
    {
        private readonly IAirportRepository _airportInterface;
        public AirportService(IAirportRepository airportInterface)
        {
            _airportInterface = airportInterface;
        }

        public async Task<IEnumerable<AirportViewModel>> GetAllAirports()
        {
            var airports = await _airportInterface.GetAllAirportsAsync();
            
            return airports.Select(a => new AirportViewModel
            {
                AirportId = a.AirportId,
                Name = a.Name,
                City = a.City,
                Country = a.Country,
                IataCode = a.IataCode,
                IcaoCode = a.IcaoCode,
                ArrivingFlights = a.ArrivingFlights?.ToList() ?? new List<Flight>(),
                DepartingFlights = a.DepartingFlights?.ToList() ?? new List<Flight>()
            }).ToList();
        }
        public async Task DeleteAirportAsync(Guid id)
        {
            try
            {
                await _airportInterface.DeleteAirportAsync(id);
            }
            catch (KeyNotFoundException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public async Task CreateAirportAsync(CreateAirportDto dto)
        {
            var airport = new Airport
            {
                AirportId = dto.AirportId,
                Name = dto.Name,
                City = dto.City,
                Country = dto.Country,
                IataCode = dto.IataCode,
                IcaoCode = dto.IcaoCode,
                ArrivingFlights = new List<Flight>(),
                DepartingFlights = new List<Flight>()
            };
            await _airportInterface.AddAirport(airport);
        }
        public async Task UpdateAirportAsync(EditAirportDto editAirport)
        {
            var airport = await _airportInterface.GetAirportByIdAsync(editAirport.AirportId);

            if (airport == null)
            {
                throw new KeyNotFoundException($"Airport with ID {editAirport.AirportId} not found.");
            }
            airport.AirportId = editAirport.AirportId;
            airport.Latitude = editAirport.Latitude;
            airport.Longitude = editAirport.Longitude;
            airport.Timezone = editAirport.Timezone;
            airport.Dst = editAirport.Dst;
            airport.TzDatabaseTimezone = editAirport.TzDatabaseTimezone;
            airport.Type = editAirport.Type;
            airport.Source = editAirport.Source;
            
            await _airportInterface.UpdateAirportAsync(airport);
        }
        public async Task<EditAirportDto> GetAirportByIdAsync(Guid id)
        {
            var airport = await _airportInterface.GetAirportByIdAsync(id);
            if (airport == null)
            {
                return null;
            }
            return new EditAirportDto
            {
                AirportId = airport.AirportId,
                Latitude = airport.Latitude,
                Longitude = airport.Longitude,
                Timezone = airport.Timezone,
                Dst = airport.Dst,
                TzDatabaseTimezone = airport.TzDatabaseTimezone,
                Type = airport.Type,
                Source = airport.Source
            };
        }
        public async Task<AirportDetailsDto> GetAirportDetails(Guid id)
        {
            var airport = await _airportInterface.GetAirportByIdAsync(id);
            if (airport == null)
            {
                return null;
            }
            var airportDetails = new AirportDetailsDto
            {
                AirportId = airport.AirportId,
                Name = airport.Name,
                City = airport.City,
                Country = airport.Country,
                IataCode = airport.IataCode,
                IcaoCode = airport.IcaoCode,
                Latitude = airport.Latitude,
                Longitude = airport.Longitude,
                Altitude = airport.Altitude,
                Timezone = airport.Timezone,
                Dst = airport.Dst,
                TzDatabaseTimezone = airport.TzDatabaseTimezone,
                Type = airport.Type,
                Source = airport.Source,
                DepartingFlights = (airport.DepartingFlights ?? new List<Flight>())
                .Where(f => f.airline != null && f.airline.IsActive)
                .Select(f => new FlightDetailsViewModel
                {
                    SourceAirport = airport.Name,
                    DestinationAirport = f.DestinationAirportNavigation?.Name ?? "Unknown",
                    Airline = f.airline?.Name ?? "Unknown"
                }).ToList(),

                ArrivingFlights = (airport.ArrivingFlights ?? new List<Flight>())
                .Where(f => f.airline != null && f.airline.IsActive) 
                .Select(f => new FlightDetailsViewModel
                {
                    SourceAirport = f.SourceAirportNavigation?.Name ?? "Unknown",
                    DestinationAirport = airport.Name,
                    Airline = f.airline?.Name ?? "Unknown"
                }).ToList()
            };
            return airportDetails;
        }
    }
}
