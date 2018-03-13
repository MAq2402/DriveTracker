﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveTracker.Models
{
    public class CarForCreationDto
    {
        public string Name { get; set; }
        public double FuelConsumption100km { get; set; }
        public int FuelId { get; set; }
        public int UserId { get; set; }
    }
}