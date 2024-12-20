using Finder.Application.DTOs.AirportDtos;
using Finder.Application.DTOs.PlaneDtos;
using Finder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Application.Interfaces
{
    public interface IAirportService
    {
        Task<IEnumerable<AirportViewModel>> GetAllAirports();
        Task CreateAirportAsync(CreateAirportDto planeDto);
        Task DeleteAirportAsync(Guid planeId);
        Task UpdateAirportAsync(EditAirportDto airportDto);
        Task<EditAirportDto> GetAirportByIdAsync(Guid id);
        Task<AirportDetailsDto> GetAirportDetails(Guid id);
        Task<AirportDropDownList> PrepareSearchDirectFlightViewModelAsync();
    }
}
