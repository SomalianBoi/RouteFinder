using Finder.Domain.Entities;
using Finder.Domain.RepoInterfaces;
using Finder.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Infrastructure.Repository
{
    public class AirportRepository : IAirportRepository
    {
        private readonly ApplicationDbContext _context;

        public AirportRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Airport>> GetAllAirportsAsync()
        {
            return await _context.Airports
                .Include(a => a.ArrivingFlights)
                .ThenInclude(f => f.SourceAirportNavigation)
                .Include(a => a.DepartingFlights)
                .ThenInclude(f => f.DestinationAirportNavigation)
                .ToListAsync();
        }
        public async Task AddAirport(Airport airport)
        {
            await _context.AddAsync(airport);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAirportAsync(Guid id)
        {
            var airport = await _context.Airports.FirstOrDefaultAsync(a => a.AirportId == id);

            if (airport == null)
            {
                throw new KeyNotFoundException($"Airport with id {id} not found");
            }
            _context.Airports.Remove(airport);
            await _context.SaveChangesAsync();
        }
    }
}
