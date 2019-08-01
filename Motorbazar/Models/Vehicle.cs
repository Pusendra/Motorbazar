using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Motorbazar.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Model { get; set; }

        [Display(Name = "Release Date (YYYY/MM/DD)")]
        public DateTime YearOfRelease { get; set; }

        [Display(Name = "Price (Lakhs Nrs)")]
        public short Price { get; set; }

        [Display(Name = "Mileage (Kmpl)")]
        public short Mileage { get; set; }
        public string AdditionalInformation { get; set; }
        public VehicleType VehicleType { get; set; }

        [Display(Name = "Vehicle Type")]
        [Required]
        public byte VehicleTypeId { get; set; }

        public byte NumberAvailable { get; set; }

        [Required]
        public byte NumberInStock { get; set; }
    }
}