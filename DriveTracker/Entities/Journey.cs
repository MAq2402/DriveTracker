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
        public int Id { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public string Start { get; set; }
        [Required]
        public int Length { get; set; }
        [Required,ForeignKey("Car")]
        public int CarId { get; set; }
        [Required]
        public Car Car { get; set; }
        List<UserJourney> UserJourneys { get; set; } = new List<UserJourney>();
        public DateTime DateTime { get; set; }
    }
}