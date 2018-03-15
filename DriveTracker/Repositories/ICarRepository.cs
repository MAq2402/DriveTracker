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
        IEnumerable<Car> GetCarsForUser(int userId);
        Car GetCarForUser(int userId,int id);
        void AddCarForUser(int userId,Car car);
        void UpdateCar();
    }
}
