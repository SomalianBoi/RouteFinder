using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Domain.Entities
{
    public class Airport
    {
        public Guid AirportId { get; set; }          // Unique OpenFlights identifier for the airport
        public required string Name { get; set; }            // Name of the airport
        public required string City { get; set; }            // City where the airport is located
        public required string Country { get; set; }         // Country where the airport is located
        public required string IataCode { get; set; }        // 3-letter IATA code
        public required string IcaoCode { get; set; }        // 4-letter ICAO code
        public double Latitude { get; set; }        // Latitude coordinate
        public double Longitude { get; set; }       // Longitude coordinate
        public int Altitude { get; set; }           // Altitude in feet
        public double Timezone { get; set; }        // Hours offset from UTC
        public string? Dst { get; set; }             // Daylight savings time (E, A, S, O, Z, N, U)
        public string? TzDatabaseTimezone { get; set; } // Timezone in Olson format (e.g., "America/Los_Angeles")
        public string? Type { get; set; }  //Type of the airport. Value "airport" for air terminals, "station" for train stations, "port" for ferry terminals and "unknown" if not known
        public string? Source { get; set; }   //Source of this data. "OurAirports" for data sourced from OurAirports, "Legacy" for old data not matched to OurAirports (mostly DAFIF), "User" for unverified user contributions
        public ICollection<Flight>? DepartingFlights { get; set; } // Flights where this airport is the source
        public ICollection<Flight>? ArrivingFlights { get; set; }  // Flights where this airport is the destination
    }
}
