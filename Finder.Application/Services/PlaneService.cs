﻿using Finder.Application.DTOs.PlaneDtos;
using Finder.Application.Interfaces;
using Finder.Domain.Entities;
using Finder.Domain.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finder.Application.Services
{
    public class PlaneService : IPlaneService
    {
        private readonly IPlaneRepository _laneRepository;
        public PlaneService(IPlaneRepository planeRepository)
        {
            _laneRepository = planeRepository;
        }
        public async Task<IEnumerable<PlaneViewModel>> GetAllPlanes()
        {
            var planes = await _laneRepository.GetAllPlanes();

            return planes.Select(f => new PlaneViewModel
            {
                PlaneId = f.PlaneId,
                Name = f.Name,
                IATACode = f.IATACode,
                ICAOCode = f.ICAOCode,
                Flights = f.Flights?.ToList() ?? new List<Flight>()
            }).ToList();
        }
        public async Task CreatePlaneAsync(CreatePlaneDto dto)
        {
            var plane = new Plane
            {
                PlaneId = dto.PlaneId,
                Name = dto.Name,
                IATACode = dto.IATACode,
                ICAOCode = dto.ICAOCode,
                Flights = new List<Flight>()
            };
            await _laneRepository.AddPlaneAsync(plane);
        }
        public async Task DeletePlaneAsync(Guid planeId)
        {
            try
            {
                await _laneRepository.DeletePlaneAsync(planeId);
            }catch(KeyNotFoundException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
