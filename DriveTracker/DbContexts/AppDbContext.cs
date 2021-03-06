﻿using DriveTracker.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DriveTracker.DbContexts
{
    public class AppDbContext:DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PassengerRoute> PassengerRoutes { get; set; }
        public DbSet<Notification> Notifications { get; set; }

    }
}