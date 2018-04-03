using DriveTracker.Models.PassengerRoute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DriveTracker.Models.Journeys
{
    public class JourneyForCreationDto
    {
        [Required,MaxLength(50)]
        public string Destination { get; set; }

        [Required, MaxLength(50)]
        public string Start { get; set; }

        [Required,Range(1,400000)]
        public int Length { get; set; }

        //[Required]
        //public int CarId { get; set; }

        //[Required]
        //public int UserId { get; set; }

        [Required,Range(0,200)]
        public decimal PriceForLiter { get; set; }
        PassangerRouteForCreationDto[] Routes { get; set; } = new PassangerRouteForCreationDto[10];
        //public PassangerRouteForCreationDto Routes { get; set; }
    }
}