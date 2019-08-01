using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Motorbazar.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Vehicle Vehicle { get; set; }

        public DateTime DateBought { get; set; }

    }
}