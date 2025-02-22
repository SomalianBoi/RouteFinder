﻿using Finder.Application.DTOs;
using Finder.Application.DTOs.AirlineDtos;
using Finder.Application.DTOs.FlightDtos;
using Finder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Application.Interfaces
{
    public interface IFlightService
    {
        Task<IEnumerable<Flight>> GetAllFlightsAsync();
        Task CreateFlightAsync(CreateFlightDto flightDto);
        Task DeleteFlightAsync(Guid flightId);
        Task<List<DirectFlightDto>> GetDirectFlightAsync(Guid sourceAirportId, Guid destinationAirportId);
        Task<List<FlightDto>> GetFlightsByAirlineAndPlaneAsync(Guid airlineId, Guid planeId);
        Task<List<RouteDto>> FindRoutesBetweenAirportsAsync(Guid sourceAirportId, Guid destinationAirportId);
    }
}
