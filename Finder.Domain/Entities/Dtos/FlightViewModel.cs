using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Domain.Entities.Dtos
{
    public class FlightViewModel
    {
        public Guid FlightId { get; set; }
        public string SourceAirportName { get; set; } = string.Empty;
        public string DestinationAirportName { get; set; } = string.Empty;
    }
}
