using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Motorbazar.Models;

namespace Motorbazar.ViewModels
{
    public class VehicleFormViewModel
    {
        public IEnumerable<VehicleType> VehicleTypes { get; set; }
        public Vehicle Vehicle { get; set; }
        public string Title
        {
            get
            {
                if (Vehicle != null && Vehicle.Id != 0)
                    return "Edit Vehicle";

                return "New Vehicle";
            }
        }
    }
}