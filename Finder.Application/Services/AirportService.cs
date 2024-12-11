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
    }
}
