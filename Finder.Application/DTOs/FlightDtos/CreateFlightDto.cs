using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Application.DTOs.FlightDtos
{
    public class CreateFlightDto
    {
        public Guid AirlineId { get; set; }
        public Guid SourceAirportId { get; set; }
        public Guid DestinationAirportId { get; set; }
        public Guid PlaneId { get; set; }
        public int DurationInMinutes { get; set; }

    }
}
