
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
        public Balance()
        {
            ToPay = 0;
            ToReceive = 0;
            Payed = 0;
            Received = 0;
        }

        [Key]
        public int Id { get; set; }

        //[Required]
        public decimal ToPay { get; set; }

        //[Required]
        public decimal ToReceive { get; set; }

        //[Required]
        public decimal Payed { get; set; }

        //[Required]
        public decimal Received { get; set; }

        [Required,Key,ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public User User { get; set; }
    }
}