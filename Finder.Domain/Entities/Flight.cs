using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Domain.Entities
{
    public class Flight
    {
        public Guid FlightId { get; set; }                  // Unique identifier for the flight route
        public Airline? airline { get; set; }               // Airline code
        public Guid AirlineId { get; set; }                // Unique identifier for the airline
        public Airport? SourceAirportNavigation { get; set; }          // 3-letter (IATA) or 4-letter (ICAO) code of the source airport
        public Guid SourceAirportId { get; set; }           // Unique OpenFlights identifier for source airport
        public Airport? DestinationAirportNavigation { get; set; }     // 3-letter (IATA) or 4-letter (ICAO) code of the destination airport
        public Guid DestinationAirportId { get; set; }      // Unique OpenFlights identifier for destination airport
        public int Stops { get; set; }                     // Number of stops on the route    
        public Guid PlaneId { get; set; }
        public Plane? plane { get; set; } // Reference to the plane
    }
}
