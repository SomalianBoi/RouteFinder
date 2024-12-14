using Finder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Domain.RepoInterfaces
{
    public interface IPlaneRepository
    {
        Task<IEnumerable<Plane>> GetAllPlanes();
        Task AddPlaneAsync(Plane plane);
        Task DeletePlaneAsync(Guid planeId);
        Task<Plane> GetPlaneByIdAsync(Guid Airport);
    }
}
