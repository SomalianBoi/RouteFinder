﻿using Finder.Domain.Entities;
using Finder.Domain.RepoInterfaces;
using Finder.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Infrastructure.Repository
{
    public class PlaneRepository : IPlaneRepository
    {
        private readonly ApplicationDbContext _context;
        public PlaneRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Plane>> GetAllPlanes()
        {
            return await _context.Planes
                .Include(a => a.Flights)
                .ThenInclude(f => f.SourceAirportNavigation)
                .Include(f => f.Flights)
                .ThenInclude(f => f.DestinationAirportNavigation)
                .Include(a => a.Flights)
                .ThenInclude(f => f.airline)
                .ToListAsync();
        }
    }
}
