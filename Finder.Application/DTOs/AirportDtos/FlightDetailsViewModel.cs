using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Application.DTOs.AirportDtos
{
    public class FlightDetailsViewModel
    {
        public string SourceAirport { get; set; }
        public string DestinationAirport { get; set; }
        public string Airline { get; set; }
    }
}
