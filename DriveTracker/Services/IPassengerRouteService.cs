using DriveTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriveTracker.Services
{
    public interface IPassengerRouteService
    {
        bool SameUserForRoutes(IEnumerable<PassengerRoute> passengerRoutes);
    }
}