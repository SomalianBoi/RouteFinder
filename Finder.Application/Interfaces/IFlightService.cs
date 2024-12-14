using Finder.Application.DTOs.AirlineDtos;
using Finder.Application.DTOs.FlightDtos;
using Finder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Application.Interfaces
{
    public interface IFlightService
    {
        Task<IEnumerable<Flight>> GetAllFlightsAsync();
        Task CreateFlightAsync(CreateFlightDto flightDto);
        Task DeleteFlightAsync(Guid flightId);
    }
}
