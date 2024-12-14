using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Application.DTOs.AirlineDtos
{
    public class EditAirlineViewModel
    {
        public Guid AirlineId { get; set; }
        public bool IsActive { get; set; } // Only this property is editable
    }
}
