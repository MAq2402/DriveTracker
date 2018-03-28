
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveTracker.Models.SingleUserJourneys
{
    public class SingleUserJourneyDto
    {
        public int Id { get; set; }

        public string Destination { get; set; }

        public string Start { get; set; }

        public int Length { get; set; }

        public int UserId { get; set; }

        public int JourneyId { get; set; }

        public decimal TotalPrice { get; set; }

    }
}