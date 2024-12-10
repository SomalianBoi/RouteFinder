using Finder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Domain.RepoInterfaces
{
    public interface IAirlineRepository
    {
        Task<IEnumerable<Airline>> GetAirlinesAsync();
        Task addAsync  (Airline airline);
        Task<Airline> GetAirlineByIdAsync(Guid AirlineId);
        Task DeleteAirlineAsync(Guid AirlineId);
    }
}
