using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using Motorbazar.Dtos;
using Motorbazar.Models;

namespace Vidly.Controllers.Api
{
    public class VehiclesController : ApiController
    {
        private ApplicationDbContext _context;

        public VehiclesController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<VehicleDto> GetVehicles(string query = null)
        {
            var vehiclesQuery = _context.Vehicles
                .Include(v => v.VehicleType)
                .Where(v => v.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                vehiclesQuery = vehiclesQuery.Where(v => v.Name.Contains(query));

            return vehiclesQuery
               .ToList()
                .Select(Mapper.Map<Vehicle, VehicleDto>);
        }

        public IHttpActionResult GetVehicle(int id)
        {
            var vehicle = _context.Vehicles.SingleOrDefault(c => c.Id == id);

            if (vehicle == null)
                return NotFound();

            return Ok(Mapper.Map<Vehicle, VehicleDto>(vehicle));
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageVehicles)]
        public IHttpActionResult CreateVehicle(VehicleDto vehicleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var vehicle = Mapper.Map<VehicleDto, Vehicle>(vehicleDto);
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();

            vehicleDto.Id = vehicle.Id;
            return Created(new Uri(Request.RequestUri + "/" + vehicle.Id), vehicleDto);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageVehicles)]
        public IHttpActionResult UpdateVehicle(int id, VehicleDto vehicleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var vehicleInDb = _context.Vehicles.SingleOrDefault(c => c.Id == id);

            if (vehicleInDb == null)
                return NotFound();

            Mapper.Map(vehicleDto, vehicleInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageVehicles)]
        public IHttpActionResult DeleteVehicle(int id)
        {
            var vehicleInDb = _context.Vehicles.SingleOrDefault(c => c.Id == id);

            if (vehicleInDb == null)
                return NotFound();

            _context.Vehicles.Remove(vehicleInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}