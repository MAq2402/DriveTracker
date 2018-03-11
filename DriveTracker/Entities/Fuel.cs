using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveTracker.Entities
{
    public enum FuelType
    {
        benzine,
        diesel,
        lpg,
        hybrid,
        electric
    }
    public class Fuel
    {
        public int Id { get; set; }
        public FuelType Type { get; set; }
        public decimal PriceForLiter { get; set; }

        public List<Car> Cars { get; set; } = new List<Car>();
    }
}