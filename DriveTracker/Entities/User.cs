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
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }
        public List<Balance> Balances { get; set; } = new List<Balance>();

        [InverseProperty("Receiver")]
        public List<Payment> ReceivedPayments { get; set; } = new List<Payment>();

        [InverseProperty("Payer")]
        public List<Payment> PayedPayments { get; set; } = new List<Payment>();
        public List<SingleUserJourney> UserJourneys { get; set; } = new List<SingleUserJourney>();
        public List<Car> Cars { get; set; } =  new List<Car>();

        [InverseProperty("NotifiedUser")]
        public List<Notification> ReceivedNotifications { get; set; } = new List<Notification>();

        [InverseProperty("NotifyingUser")]
        public List<Notification> SentNotifications { get; set; } = new List<Notification>();
    }
}