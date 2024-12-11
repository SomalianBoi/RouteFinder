using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Application.DTOs.AirportDtos
{
    public class CreateAirportDto
    {
        public Guid AirportId { get; set; }          // Unique OpenFlights identifier for the airport
        public required string Name { get; set; }            // Name of the airport
        public required string City { get; set; }            // City where the airport is located
        public required string Country { get; set; }         // Country where the airport is located
        public required string IataCode { get; set; }        // 3-letter IATA code
        public required string IcaoCode { get; set; }        // 4-letter ICAO code
    }
}
