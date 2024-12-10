using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Domain.Entities.Dtos
{
    public class AirlineViewModel
    {
        public Guid AirlineId { get; set; }
        public required string Name { get; set; }
        public required string Alias { get; set; }
        public string? Country { get; set; }
        public List<Flight> Flights { get; set; } = new();
        public bool IsActive { get; set; } // Active status

        // Derived property for total number of flights
        public int TotalFlights => Flights.Count;
    }
}
