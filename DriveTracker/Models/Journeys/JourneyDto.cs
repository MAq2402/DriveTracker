
using DriveTracker.Models.SingleUserJourneys;
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

        List<SingleUserJourneyDto> UserJourneys { get; set; } = new List<SingleUserJourneyDto>();

        public DateTime DateTime { get; set; }

        public decimal TotalPrice { get; set; }
    }
}