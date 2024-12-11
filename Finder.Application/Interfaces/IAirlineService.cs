using Finder.Application.DTOs.AirlineDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Application.Interfaces
{
    public interface IAirlineService
    {
        Task<IEnumerable<AirlineViewModel>> GetAirlines();
        Task CreateAirlineAsync(CreateAirlineViewModel airline);
        Task<AirlineDetailsDto> GetDetailsForIdAsync(Guid id);
        Task DeleteAirlineAsync(Guid airlineId);
    }
}
