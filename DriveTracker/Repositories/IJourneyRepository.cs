using DriveTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTracker.Repositories
{
    public interface IJourneyRepository
    {
        void AddJourneyForUserAndCar(int userId, int carId,Journey journey);
        IQueryable<Journey> GetJourneysForUser(int userId,bool singleUserJourney);
        IQueryable<Journey> GetJourneysForUserAndCar(int userId, int carId, bool singleUserJourney);
        Journey GetJourneyForUser(int userId,int id,bool singleUserJourney);
        Journey GetJourneyForUserAndCar(int userId, int carId,int id, bool singleUserJourney);
        void DeleteJourneyForUser(int userId, int id);
        void DeleteJourneyForUserAndCar(int userId, int carId, int id);
        bool JourneyExistsForUser(int userId, int id);

    }
}
