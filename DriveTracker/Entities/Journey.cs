using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DriveTracker.Entities
{
    public class Journey
    {
        public Journey()
        {
            DateTime = DateTime.Now;
        }

        [Required]
        public int Id { get; set; }

        [Required,MaxLength(50)]
        public string Destination { get; set; }

        [Required, MaxLength(50)]
        public string Start { get; set; }

        [Required,Range(0,40000)]
        public int Length { get; set; }

        [Required,ForeignKey("Car")]
        public int CarId { get; set; }
        [Required]
        public Car Car { get; set; }
        List<UserJourney> UserJourneys { get; set; } = new List<UserJourney>();

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public decimal PricePerKm { get; set; }
    }
}