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
        public int Id { get; set; }
        [Required,ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double FuelConsumption100km { get; set; }
        public List<Journey> Journeys { get; set; } = new List<Journey>();
        public FuelType FuelType { get; set; }
    }
}