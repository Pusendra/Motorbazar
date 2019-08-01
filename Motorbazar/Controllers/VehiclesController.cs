using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Motorbazar.Models;
using Motorbazar.ViewModels;

namespace Motorbazar.Controllers
{
    public class VehiclesController : Controller
    {
        private ApplicationDbContext _context;
        public VehiclesController()
        {
            _context = new ApplicationDbContext();
        }
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageVehicles))
                return View("List");

            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageVehicles)]
        public ViewResult New()
        {
            var vehicleTypes = _context.VehicleTypes.ToList();

             var viewModel = new VehicleFormViewModel
            {
                Vehicle = new Vehicle(),
                VehicleTypes = vehicleTypes
            };

             return View("VehicleForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageVehicles)]
        public ActionResult Edit(int id)
        {
            var vehicle = _context.Vehicles.SingleOrDefault(c => c.Id == id);

             if (vehicle == null)
                return HttpNotFound();

             var viewModel = new VehicleFormViewModel
            {
                Vehicle = vehicle,
                VehicleTypes = _context.VehicleTypes.ToList()
            };

             return View("VehicleForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var vehicle = _context.Vehicles.Include(v => v.VehicleType).SingleOrDefault(v => v.Id == id);

            if (vehicle == null)
                return HttpNotFound();

            return View(vehicle);
        }
        // GET: Vehicles/Random
        public ActionResult Random()
        {
            var vehicle = new Vehicle { Name = "Safari" };
            var customers = new List<Customer>
            {
                new Customer{ Name= "Customer 1"},
                new Customer{ Name = "Customer 2"}
            };
            var viewModel = new RandomVehicleViewModel
            {
                Vehicle = vehicle,
                Customers = customers
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageVehicles)]
        public ActionResult Save(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new VehicleFormViewModel
                {
                    Vehicle = vehicle,
                    VehicleTypes = _context.VehicleTypes.ToList()
                };
                return View("VehicleForm", viewModel);
            }
            if (vehicle.Id == 0)
            {
                vehicle.NumberAvailable = vehicle.NumberInStock;
                _context.Vehicles.Add(vehicle);
            }
            else
            {
                vehicle.NumberAvailable = vehicle.NumberInStock;
                var vehicleInDb = _context.Vehicles.Single(v => v.Id == vehicle.Id);
                vehicleInDb.Name = vehicle.Name;
                vehicleInDb.Model = vehicle.Model;
                vehicleInDb.YearOfRelease = vehicle.YearOfRelease;
                vehicleInDb.Price = vehicle.Price;
                vehicleInDb.Mileage = vehicle.Mileage;
                vehicleInDb.AdditionalInformation = vehicle.AdditionalInformation;
                vehicleInDb.VehicleTypeId = vehicle.VehicleTypeId;
                vehicleInDb.NumberInStock = vehicle.NumberInStock;
                vehicleInDb.NumberAvailable = vehicle.NumberAvailable;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Vehicles");
        }

        //GET: Vehicles/Released/Year/Month
        [Route("vehicles/released/{year:regex(\\d{4}):range(1000,2019)}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int Year, int Month)
        {
            return Content(Year + "/" + Month);
        }
    }
}