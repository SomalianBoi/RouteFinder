using Finder.Application.DTOs.FlightDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Application.DTOs
{
    public class FilterFlightsByPlaneAndAirlineViewModel
    {
        public List<AirlineCreateFlightDto> Airlines { get; set; }
        public List<PlaneCreateFlightDto> Planes { get; set; }
        public List<FlightDto> Flights { get; set; }
        public Guid? SelectedAirlineId { get; set; }
        public Guid? SelectedPlaneId { get; set; }
    }

}
