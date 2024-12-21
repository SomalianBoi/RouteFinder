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
    public class FlightRepository : IFlightRepository
    {
        private readonly ApplicationDbContext _context;

        public FlightRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<Flight>> GetAllFlightsAsync()
        {
            return await _context.Flights
                             .Include(f => f.airline)                      // Include airline details (if needed)
                             .Include(f => f.SourceAirportNavigation)       // Include source airport details (if needed)
                             .Include(f => f.DestinationAirportNavigation)  // Include destination airport details (if needed)
                             .Include(f => f.plane)                         // Include plane details (if needed)
                             .ToListAsync();
        }
        public async Task CreateFlight(Flight flight)
        {
            await _context.AddAsync(flight);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteFlightAsync(Guid id)
        {
            var flight = await _context.Flights.FirstOrDefaultAsync(a => a.FlightId == id);

            if (flight == null)
            {
                throw new KeyNotFoundException($"Flight with id {id} not found");
            }
            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Flight>> GetDirectFlightAsync(Guid sourceAirportId, Guid destinationAirportId)
        {
            return await _context.Flights
                .Include(f => f.airline)                     // Assuming you want to include airline details
                .Include(f => f.SourceAirportNavigation)     // Include source airport details
                .Include(f => f.DestinationAirportNavigation) // Include destination airport details
                .Where(f => f.SourceAirportId == sourceAirportId && f.DestinationAirportId == destinationAirportId)
                .ToListAsync(); // Retrieves all flights, not just the first one
        }
        public async Task<List<Flight>> GetFlightsByAirlineAndPlaneAsync(Guid airlineId, Guid planeId)
        {
            return await _context.Flights
                .Include(f => f.airline)                     // Include airline details
                .Include(f => f.SourceAirportNavigation)     // Include source airport details
                .Include(f => f.DestinationAirportNavigation) // Include destination airport details
                .Include(f => f.plane)                       // Include plane details
                .Where(f => f.AirlineId == airlineId && f.PlaneId == planeId)
                .ToListAsync();
        }


    }
}
