
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DriveTracker.Entities
{

    public enum Month
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
    public class Balance
    {
        public Balance()
        {
            Year = DateTime.Now.Year;
            Month = (Month)DateTime.Now.Month;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public decimal ToPay { get; set; }

        [Required]
        public decimal ToReceive { get; set; }

        [Required]
        public decimal Payed { get; set; }

        [Required]
        public decimal Received { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public Month Month{ get; set; }
        [Required,ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
    }
}