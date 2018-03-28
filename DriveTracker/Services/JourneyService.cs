using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriveTracker.Entities;

namespace DriveTracker.Services
{
    public class JourneyService : IJourneyService
    {
        //Counts total price for journey and single user journey
        public void GiveTotalPrice(Journey journey, double priceForLiter)
        {
            journey.TotalPrice = Convert.ToDecimal((journey.Car.FuelConsumption100km * journey.Length * priceForLiter / 100));

            foreach(var item in journey.SingleUserJourneys)
            {
               

            }
        }
    }
}