using DriveTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveTracker.Models.Users
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }


        //        public decimal ToPay { get; set; }
        public decimal ToPay { get; set; }
        public decimal ToReceive { get; set; }
        public decimal Payed { get; set; }
        public decimal Received { get; set; }

        //public List<Payment> Received { get; set; } = new List<Payment>();
        //public List<Payment> Payed { get; set; } = new List<Payment>();
        //public List<UserJourney> UserJourneys { get; set; } = new List<UserJourney>();
        // public List<Cars> Cars { get; set; } = new List<Cars>();
    }
}