using DriveTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTracker.Repositories
{
    public interface IPassengerRouteRepository
    {
        
        bool UsersExistForRoutes(IEnumerable<PassengerRoute> passengerRoutes);

        void SetUsersForRoutes(IEnumerable<PassengerRoute> passengerRoutes);

    }
}
