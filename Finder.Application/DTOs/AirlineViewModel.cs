using Finder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Application.DTOs
{
    public class AirlineViewModel
    {
        public Guid AirlineId { get; set; }
        public required string Name { get; set; }
        public required string Alias { get; set; }
        public string? Country { get; set; }
        public bool IsActive { get; set; }
        public List<Flight>? Flights { get; set; }
    }
}
