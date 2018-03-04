using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DriveTracker.Entities
{
    public class Payment
    {
        public Payment()
        {
            DateTime = DateTime.Now;
        }
        public int Id { get; set; }
        [Required,ForeignKey("Payer")]
        public int PayerId { get; set; }
        [Required]
        public User Payer { get; set; }
        [Required,ForeignKey("Receiver")]
        public int ReceiverId { get; set; }
        [Required]
        public User Receiver { get; set; }
        [Required, ForeignKey("Journey")]
        public int JourneyId { get; set; }
        [Required]
        public Journey Journey { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsPayed { get; set; } = false;
        [Required,ForeignKey("PaymentAcceptanceRequest")]
        public int PaymentAcceptanceRequestId { get; set; }
        [Required]
        public PaymentAcceptanceRequest PaymentAcceptanceRequest { get; set; }
    }
}