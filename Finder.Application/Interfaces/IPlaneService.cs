using Finder.Application.DTOs.PlaneDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Application.Interfaces
{
    public interface IPlaneService
    {
        Task<IEnumerable<PlaneViewModel>> GetAllPlanes();
        Task CreatePlaneAsync(CreatePlaneDto planeDto);
        Task DeletePlaneAsync(Guid planeId);
    }
}
