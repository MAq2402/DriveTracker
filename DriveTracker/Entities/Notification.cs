using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DriveTracker.Entities
{
    public enum NotificationType
    {

    }
    public class Notification
    {
        public Notification()
        {
            DateTime = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        [ForeignKey("NotifiedUser"),Required]
        public int NotifiedUserId { get; set; }
        [Required]
        public User NotifiedUser { get; set; }
        [ForeignKey("NotifyingUser"),Required]
        public int NotifyingUserId { get; set; }
        [Required]
        public User NotifyingUser { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public NotificationType NotificationType { get; set; }
    }
}