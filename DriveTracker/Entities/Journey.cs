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
        public List<SingleUserJourney> SingleUserJourneys { get; set; } = new List<SingleUserJourney>();

        [Required, ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }
    }
}