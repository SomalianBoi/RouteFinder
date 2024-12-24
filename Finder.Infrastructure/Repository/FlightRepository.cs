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

        public async Task<List<List<Flight>>> GetConnectingFlightsAsync(Guid sourceAirportId, Guid destinationAirportId)
        {
            var allFlights = await _context.Flights
                .Include(f => f.airline)                     // Include airline details
                .Include(f => f.SourceAirportNavigation)     // Include source airport details
                .Include(f => f.DestinationAirportNavigation) // Include destination airport details
                .Include(f => f.plane)                       // Include plane details
                .ToListAsync();

            // Build adjacency list for the graph
            var graph = allFlights
                .GroupBy(f => f.SourceAirportId)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(f => new { f.DestinationAirportId, Flight = f }).ToList()
                );

            // Perform BFS/Dijkstra to find routes
            var result = new List<List<Flight>>();
            var queue = new Queue<(Guid Current, List<Flight> Path)>();
            queue.Enqueue((sourceAirportId, new List<Flight>()));

            while (queue.Count > 0)
            {
                var (current, path) = queue.Dequeue();

                if (current == destinationAirportId)
                {
                    result.Add(path);
                    continue;
                }

                if (!graph.ContainsKey(current)) continue;

                foreach (var edge in graph[current])
                {
                    if (!path.Any(f => f.DestinationAirportId == edge.DestinationAirportId))
                    {
                        var newPath = new List<Flight>(path) { edge.Flight };
                        queue.Enqueue((edge.DestinationAirportId, newPath));
                    }
                }
            }

            return result;
        }
    }
}
