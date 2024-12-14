using Finder.Domain.Entities;
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
    public class AirlineRepository : IAirlineRepository
    {
        private readonly ApplicationDbContext _context;
        public AirlineRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Airline>> GetAirlinesAsync()
        {
            return await _context.Airlines
                .Include(a => a.Flights).ThenInclude(f => f.SourceAirportNavigation)
                .Include(a => a.Flights).ThenInclude(f => f.DestinationAirportNavigation)
                .ToListAsync();
        }
        public async Task addAsync(Airline airline)
        {
            await _context.AddAsync(airline);
            await _context.SaveChangesAsync();
        }
        public async Task<Airline> GetAirlineByIdAsync(Guid id)
        {
            return await _context.Airlines
        .Include(a => a.Flights)
            .ThenInclude(f => f.SourceAirportNavigation)  // Include SourceAirport
        .Include(a => a.Flights)
            .ThenInclude(f => f.DestinationAirportNavigation)  // Include DestinationAirport
        .FirstOrDefaultAsync(a => a.AirlineId == id);
        }
        public async Task DeleteAirlineAsync(Guid id)
        {
            var airline = await _context.Airlines.FirstOrDefaultAsync(a => a.AirlineId == id);

            if (airline == null)
            {
                throw new KeyNotFoundException($"Airline with id {id} not found");
            }
            _context.Airlines.Remove(airline);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAirlineAsync(Airline airline)
        {
            _context.Airlines.Update(airline);
            await _context.SaveChangesAsync();
        }
        public async Task<Airline> GetAirlineById(Guid airlineId)
        {
            return await _context.Airlines
                                 .Include(a => a.Flights) // Include related flights if necessary
                                 .FirstOrDefaultAsync(a => a.AirlineId == airlineId);
        }
    }
}
