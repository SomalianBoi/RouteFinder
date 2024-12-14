using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Application.DTOs.FlightDtos
{
    public class AirlineCreateFlightDto
    {
        public Guid AirlineId { get; set; }
        public string Name { get; set; } // Or other relevant properties
    }
}
