using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Application.DTOs.FlightDtos
{
    public class FlightDto
    {
        public Guid FlightId { get; set; }
        public string AirlineName { get; set; }  // Airline name for easy display
        public string SourceAirportIataCode { get; set; }  // IATA Code of the source airport
        public string DestinationAirportIataCode { get; set; }  // IATA Code of the destination airport
        public string PlaneModel { get; set; }  // Plane model for display
        public int DurationInMinutes { get; set; }  // Duration of the flight in minutes
        public int Stops { get; set; }  // Number of stops (could be zero if non-stop)

        // Optional: Calculate the formatted duration directly in the DTO if needed for display purposes
        public string DurationFormatted => $"{DurationInMinutes / 60}h {DurationInMinutes % 60}m";
    }
}
