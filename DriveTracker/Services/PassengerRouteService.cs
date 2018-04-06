using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriveTracker.Entities;

namespace DriveTracker.Services
{
    public class PassengerRouteService : IPassengerRouteService
    {
        public bool SameUserForRoutes(IEnumerable<PassengerRoute> passengerRoutes)
        {
            var userIds = new List<int>();

            foreach (var route in passengerRoutes)
            {

                if (userIds.Any(x => x == route.UserId))
                {
                    return true;
                }

                userIds.Add(route.UserId);
            }
            return false;
        }
    }
}