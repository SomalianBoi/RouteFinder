using Finder.Application.DTOs.FlightDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Application.DTOs
{
    public class CreateFlightViewModel
    {
        public List<AirlineCreateFlightDto> Airlines { get; set; } = new();
        public List<AirportCreateFlightDto> Airports { get; set; } = new();
        public List<PlaneCreateFlightDto> Planes { get; set; } = new();
        public CreateFlightDto FlightDto { get; set; } = new();
    }
}
