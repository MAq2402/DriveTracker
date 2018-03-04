using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DriveTracker.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        public List<Balance> Balances { get; set; } = new List<Balance>();
        [InverseProperty("Receiver")]
        public List<Payment> Received { get; set; } = new List<Payment>();
        [InverseProperty("Payer")]
        public List<Payment> Payed { get; set; } = new List<Payment>();
        public List<UserJourney> UserJourneys { get; set; } = new List<UserJourney>();
    }
}