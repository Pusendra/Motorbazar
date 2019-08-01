using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Motorbazar.Dtos
{
    public class VehicleDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Model { get; set; }
        
        public DateTime YearOfRelease { get; set; }
        public short Price { get; set; }
        
        public short Mileage { get; set; }
        public string AdditionalInformation { get; set; }

        public VehicleTypeDto VehicleType { get; set; }

        [Required]
        public byte VehicleTypeId { get; set; }

        public byte NumberAvailable { get; set; }

        [Required]
        public byte NumberInStock { get; set; }
    }
}