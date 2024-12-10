using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Domain.Entities
{
    public class Airline
    {
        public Guid AirlineId { get; set; } // Unique OpenFlights identifier for this airline
        public required string Name { get; set; } // Name of the airline
        public required string Alias { get; set; } // Alias of the airline, e.g., "ANA"
        public required string IATA { get; set; } // 2-letter IATA code, nullable
        public required string ICAO { get; set; } // 3-letter ICAO code, nullable
        public required string Callsign { get; set; } // Airline callsign, nullable
        public string? Country { get; set; } // Country where the airline is based
        public bool IsActive { get; set; } // Active status: true for "Y", false for "N"

        public ICollection<Flight>? Flights { get; set; } // Flights carried out by the airline
    }
}
