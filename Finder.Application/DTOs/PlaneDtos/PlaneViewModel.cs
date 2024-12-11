using Finder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Application.DTOs.PlaneDtos
{
    public class PlaneViewModel
    {
        public Guid PlaneId { get; set; } // Unique identifier for the plane (Primary Key in the database)
        public required string Name { get; set; } // Full name of the aircraft
        public required string IATACode { get; set; } // IATA identifier, nullable
        public required string ICAOCode { get; set; } // ICAO identifier, nullable

        public ICollection<Flight>? Flights { get; set; } // Flights carried out by the airline
    }
}
