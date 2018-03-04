using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DriveTracker.Entities
{
    public class UserJourney
    {
        public UserJourney()
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
        [Required, ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
        [Required,ForeignKey("Journey")]
        public int JourneyId { get; set; }
        [Required]
        public Journey Journey { get; set; }
        public DateTime DateTime { get; set; }
    }
}