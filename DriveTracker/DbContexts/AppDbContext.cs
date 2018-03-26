using DriveTracker.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DriveTracker.DbContexts
{
    public class AppDbContext:DbContext
    {
        public DbSet<Balance> Balanaces { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SingleUserJourney> UserJourneys { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<Balance>().HasRequired(b => b.User).WithOptional(u => u.Balance);
            modelBuilder.Entity<User>().HasOptional(u => u.Balance).WithRequired(b => b.User);
             //modelBuilder.Entity<Balance>().HasOptional(b => b.User).WithRequired(u => u.Balance);
        }

    }
}