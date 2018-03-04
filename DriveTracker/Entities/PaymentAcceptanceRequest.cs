using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DriveTracker.Entities
{
    public class PaymentAcceptanceRequest
    {
        public PaymentAcceptanceRequest()
        {
            DateTime = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        [ForeignKey("Payment")]
        public int PaymentId { get; set; }
        
        public Payment Payment { get; set; }
    }
}