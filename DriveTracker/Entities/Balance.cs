using DriveTracker.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DriveTracker.Entities
{
    public class Balance
    {
        public int Id { get; set; }
        public decimal ToPay { get; set; }
        public decimal ToReceive { get; set; }
        public decimal Payed { get; set; }
        public decimal Received { get; set; }
        public Month Month{ get; set; }
        [Required,ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
    }
}