using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    public class Car
    {
        [Required]
        public int Id { get; set; }

        [Required,ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public User User { get; set; }

        [Required,MaxLength(50)]
        public string Name { get; set; }

        [Required,Range(1,100)]
        public double FuelConsumption100km { get; set; }
        public List<Journey> Journeys { get; set; } = new List<Journey>();

        [Required]
        public FuelType FuelType { get; set; }
    }
}