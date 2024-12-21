using Finder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Domain.RepoInterfaces
{
    public interface IFlightRepository
    {
        Task<IEnumerable<Flight>> GetAllFlightsAsync();
        Task CreateFlight(Flight flight);
        Task DeleteFlightAsync(Guid flightId);
        Task<List<Flight>> GetDirectFlightAsync(Guid sourceAirportId, Guid destinationAirportId);
        Task<List<Flight>> GetFlightsByAirlineAndPlaneAsync(Guid airlineId, Guid planeId);
    }
}
