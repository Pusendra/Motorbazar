using Motorbazar.Dtos;
using Motorbazar.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace Motorbazar.Controllers.Api
{
    public class NewTransactionsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewTransactionsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewTransactions(NewTransactionDto newTransaction)
        {
            var customer = _context.Customers.Single(
                c => c.Id == newTransaction.CustomerId);

            var vehicles = _context.Vehicles.Where(
               v => newTransaction.VehicleIds.Contains(v.Id)).ToList();

            foreach (var vehicle in vehicles)
            {
                if (vehicle.NumberAvailable == 0)
                    return BadRequest("Vehicle is not available.");

                vehicle.NumberAvailable--;

                var transaction = new Transaction
                {
                    Customer = customer,
                    Vehicle = vehicle,
                    DateBought = DateTime.Now
                };

                _context.Transactions.Add(transaction);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
