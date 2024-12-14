using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Application.DTOs.FlightDtos
{
    public class PlaneCreateFlightDto
    {
        public Guid PlaneId { get; set; }
        public string Model { get; set; } // Or other relevant properties
    }
}
