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
        IEnumerable<Car> GetCarsForUser(int userId,bool journeys);
        Car GetCarForUser(int userId,int id,bool journeys);
        void AddCarForUser(int userId,Car car);
        void UpdateCar();
        void DeleteCar(Car car);
    }
}
