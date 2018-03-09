using DriveTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTracker.Repositories
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetCars(int userId);

        Car GetCar(int userId,int id);
    }
}
