using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Application.DTOs.AirportDtos
{
    public class EditAirportDto
    {
        public Guid AirportId { get; set; }
        public double Latitude { get; set; }        // Latitude coordinate
        public double Longitude { get; set; }       // Longitude coordinate
        public int Altitude { get; set; }           // Altitude in feet
        public double Timezone { get; set; }        // Hours offset from UTC
        public string? Dst { get; set; }            // Daylight savings time
        public string? TzDatabaseTimezone { get; set; } // Timezone in Olson format
        public string? Type { get; set; }           // Type of the airport
        public string? Source { get; set; }         // Source of this data
    }
}
