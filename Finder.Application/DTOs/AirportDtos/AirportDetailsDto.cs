using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Application.DTOs.AirportDtos
{
    public class AirportDetailsDto
    {
        public Guid AirportId { get; set; }
        public required string Name { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }
        public required string IataCode { get; set; }
        public required string IcaoCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Altitude { get; set; }
        public double Timezone { get; set; }
        public string? Dst { get; set; }
        public string? TzDatabaseTimezone { get; set; }
        public string? Type { get; set; }
        public string? Source { get; set; }

        // Departing Flights
        public IEnumerable<FlightDetailsViewModel> DepartingFlights { get; set; }

        // Arriving Flights
        public IEnumerable<FlightDetailsViewModel> ArrivingFlights { get; set; }
    }
}
