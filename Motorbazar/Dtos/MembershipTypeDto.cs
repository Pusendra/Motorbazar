using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Motorbazar.Dtos
{
    public class MembershipTypeDto
    {
        public byte Id { get; set; }
        public string Name1 { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInYears { get; set; }
        public byte DiscountRate { get; set; }
    }
}