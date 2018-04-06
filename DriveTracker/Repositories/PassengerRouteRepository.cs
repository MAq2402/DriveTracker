using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriveTracker.DbContexts;
using DriveTracker.Entities;

namespace DriveTracker.Repositories
{
    public class PassengerRouteRepository : IPassengerRouteRepository
    {
        private AppDbContext _context;

        public PassengerRouteRepository(AppDbContext context)
        {
            _context = context;
        }

        public void SetUsersForRoutes(IEnumerable<PassengerRoute> passengerRoutes)
        {
            foreach(var route in passengerRoutes)
            {
                route.User = _context.Users.FirstOrDefault(u => u.Id == route.UserId);
            }
        }

        public bool UsersExistForRoutes(IEnumerable<PassengerRoute> passengerRoutes)
        {
            foreach(var route in passengerRoutes)
            {
                if(!_context.Users.Any(u => u.Id == route.UserId))
                {
                    return false;
                }
            }
            return true;
        }
    }
}