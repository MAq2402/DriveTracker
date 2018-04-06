
using DriveTracker.Models.PassengerRoute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveTracker.Models.Journeys
{
    public class JourneyDto
    {

        public int Id { get; set; }

        public string Destination { get; set; }

        public string Start { get; set; }

        public int Length { get; set; }

        public int CarId { get; set; }
        public int UserId { get; set; }

        List<PassengerRouteDto> PassengerRoutes { get; set; } = new List<PassengerRouteDto>();

        public DateTime DateTime { get; set; }

        public decimal TotalPrice { get; set; }
    }
}