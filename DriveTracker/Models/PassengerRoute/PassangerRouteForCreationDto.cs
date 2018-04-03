using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DriveTracker.Models.PassengerRoute
{
    public class PassangerRouteForCreationDto
    {
        [Required, MaxLength(50)]
        public string Destination { get; set; }

        [Required, MaxLength(50)]
        public string Start { get; set; }

        [Required, Range(1, 400000)]
        public int Length { get; set; }
    }
}