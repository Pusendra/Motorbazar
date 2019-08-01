using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Motorbazar.Dtos
{
    public class NewTransactionDto
    {
        public int CustomerId { get; set; }
        public List<int> VehicleIds { get; set; }
    }
}