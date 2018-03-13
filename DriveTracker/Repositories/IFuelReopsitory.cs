using DriveTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTracker.Repositories
{
    public interface IFuelRepository
    {
        IEnumerable<Fuel> GetFuels();
        Fuel GetFuel(int id);
        bool FuelExists(int id);
    }
}
