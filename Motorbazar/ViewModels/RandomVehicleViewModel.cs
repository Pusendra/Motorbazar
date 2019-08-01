using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Motorbazar.Models;

namespace Motorbazar.ViewModels
{
    public class RandomVehicleViewModel
    {
        public Vehicle Vehicle { get; set; }
        public List<Customer> Customers { get; set; }
    }
}