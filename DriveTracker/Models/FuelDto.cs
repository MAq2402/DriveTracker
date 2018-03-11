using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveTracker.Models
{
    public class FuelDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal PriceForLiter { get; set; }
    }
}