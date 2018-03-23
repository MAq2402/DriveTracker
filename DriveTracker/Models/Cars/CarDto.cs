using DriveTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveTracker.Models.Cars
{
    public class CarDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public double FuelConsumption100km { get; set; }
        public string FuelType { get; set; }
        public List<Journey> Journeys { get; set; } = new List<Journey>();
    }
}