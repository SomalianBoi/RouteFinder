using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Application.DTOs.FlightDtos
{
    public class AirportCreateFlightDto
    {
        public Guid AirportId { get; set; }
        public string Name { get; set; } // Or include Code like "Name (Code)"
        public string IcaoCode { get; set; }
    }
}
