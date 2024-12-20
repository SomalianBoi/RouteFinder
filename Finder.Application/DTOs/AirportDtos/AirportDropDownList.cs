using Finder.Application.DTOs.FlightDtos;
using Finder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Application.DTOs.AirportDtos
{
    public class AirportDropDownList
    {
        public List<AirportCreateFlightDto> Airports { get; set; }

        // Selected source airport ID
        public Guid SourceAirportId { get; set; }

        // Selected destination airport ID
        public Guid DestinationAirportId { get; set; }
    }
}
