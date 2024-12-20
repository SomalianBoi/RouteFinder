using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Application.DTOs.FlightDtos
{
    public class DirectFlightDto
    {
        public Guid FlightId { get; set; }
        public string AirlineName { get; set; }
        public string SourceAirport { get; set; }
        public string DestinationAirport { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
