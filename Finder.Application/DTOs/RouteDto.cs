using Finder.Application.DTOs.FlightDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Application.DTOs
{
    public class RouteDto
    {
        public int TotalDuration { get; set; }
        public int Stops { get; set; }
        public List<ConnectingFlightDto> Flights { get; set; }
    }
}
