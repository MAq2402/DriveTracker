using DriveTracker.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DriveTracker.Models.Cars
{
    public class CarForCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(1,200)]
        public double FuelConsumption100km { get; set; }

        [Required]
        public FuelType FuelType { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}