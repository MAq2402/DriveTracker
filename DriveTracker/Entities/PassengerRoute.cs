using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DriveTracker.Entities
{
    public class PassengerRoute
    {

        [Required]
        public int Id { get; set; }

        [Required,MaxLength(50)]
        public string Destination { get; set; }
        [Required, MaxLength(50)]

        public string Start { get; set; }

        [Required,Range(0,40000)]
        public int Length { get; set; }

        [Required, ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public User User { get; set; }

        [Required,ForeignKey("Journey")]
        public int JourneyId { get; set; }

        [Required]
        public Journey Journey { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

    }
}