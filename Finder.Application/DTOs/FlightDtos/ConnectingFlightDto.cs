using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Application.DTOs.FlightDtos
{
    public class ConnectingFlightDto
    {
        public Guid FlightId { get; set; }
        public string? AirlineName { get; set; } // Airline operating the flight
        public string? SourceAirport { get; set; } // Name of the source airport
        public string? DestinationAirport { get; set; } // Name of the destination airport
        public string? PlaneModel { get; set; } // Aircraft model used for the flight
        public int DurationInMinutes { get; set; } // Duration of the flight in minutes
    }
}
