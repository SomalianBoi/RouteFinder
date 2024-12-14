using Finder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Domain.RepoInterfaces
{
    public interface IAirportRepository
    {
        Task<IEnumerable<Airport>> GetAllAirportsAsync();
        Task AddAirport (Airport airport);
        Task DeleteAirportAsync (Guid airportId);
        Task UpdateAirportAsync(Airport airport);
        Task<Airport> GetAirportByIdAsync(Guid Airport);
        Task<Airport> GetAirportDetailsAsync(Guid Airport);

    }
}
