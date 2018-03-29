using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DriveTracker.Entities;

namespace DriveTracker.Services
{
    public class JourneyService : IJourneyService
    {
        public void GiveTotalPrices(Journey journey, double priceForLiter)
        {
            var fuelConsumption100km = journey.Car.FuelConsumption100km;

            journey.TotalPrice = Convert.ToDecimal(fuelConsumption100km * journey.Length * priceForLiter / 100);

            var listOfRoutes = journey.PassengerRoutes.OrderBy(pr => pr.Length).ToList();

            int numberOfPassengers = listOfRoutes.Count();

            var currentCost = 0m;// represents cost of current length

            var previousLength = 0; //represents length for which we have already calculated TotalPrice 

            int i = 0;

            while(numberOfPassengers>i)
            {
                var currentLength = listOfRoutes[i].Length;

                var listOfRoutesWithSameLength = listOfRoutes.Skip(i).TakeWhile(pr => pr.Length == currentLength).ToList();

                currentLength -= previousLength;

                currentCost += Convert.ToDecimal((fuelConsumption100km * currentLength * priceForLiter) / (100 * (numberOfPassengers - i + 1)));

                foreach(var route in listOfRoutesWithSameLength)
                {
                    route.TotalPrice = currentCost;
                }

                i += listOfRoutesWithSameLength.Count();

                previousLength += currentLength; 
            }
        }
    }
}