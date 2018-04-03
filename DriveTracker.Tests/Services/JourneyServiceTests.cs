using System;
using System.Collections.Generic;
using DriveTracker.Entities;
using DriveTracker.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DriveTracker.Tests.Services
{
    [TestClass]
    public class JourneyServiceTests
    {
        [TestMethod]
        public void GiveTotalPricesTest_JourneyTotalPrice()
        {
            //Arrange
            var journeyService = new JourneyService();
            var journey = new Journey
            {
                Car = new Car
                {
                    FuelConsumption100km = 10
                },
                Length = 100

            };
            var priceForLiter = 2;

            //Act
            journeyService.GiveTotalPrices(journey, priceForLiter);
            var expected = 20;
            var actual = journey.TotalPrice;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GiveTotalPricesTest_PassengerRouteTotalPrice_1()
        {
            //Arrange
            var journeyService = new JourneyService();
            var journey = new Journey
            {
                Car = new Car
                {
                    FuelConsumption100km = 10
                },
                Length = 100,
                PassengerRoutes = new List<PassengerRoute>
                {
                    new PassengerRoute
                    {
                        Length = 100,
                    }
                }

            };
            var priceForLiter = 2;

            //Act
            journeyService.GiveTotalPrices(journey, priceForLiter);
            var expected = 10;
            var actual = journey.PassengerRoutes[0].TotalPrice;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GiveTotalPricesTest_PassengerRouteTotalPrice_3()
        {
            //Arrange
            var journeyService = new JourneyService();
            var journey = new Journey
            {
                Car = new Car
                {
                    FuelConsumption100km = 10
                },
                Length = 100,
                PassengerRoutes = new List<PassengerRoute>
                {
                    new PassengerRoute
                    {
                        Length = 100,
                    },
                    new PassengerRoute
                    {
                        Length = 100,
                    },
                    new PassengerRoute
                    {
                        Length = 100,
                    }
                }

            };
            var priceForLiter = 2;

            //Act
            journeyService.GiveTotalPrices(journey, priceForLiter);
            var expected = 5;
            var actual1 = journey.PassengerRoutes[0].TotalPrice;
            var actual2 = journey.PassengerRoutes[1].TotalPrice;
            var actual3 = journey.PassengerRoutes[2].TotalPrice;

            //Assert
            Assert.AreEqual(expected, actual1);
            Assert.AreEqual(expected, actual2);
            Assert.AreEqual(expected, actual3);
        }

        [TestMethod]
        public void GiveTotalPricesTest_PassengerRouteTotalPrice_4()
        {
            //Arrange
            var journeyService = new JourneyService();
            var journey = new Journey
            {
                Car = new Car
                {
                    FuelConsumption100km = 10
                },
                Length = 100,
                PassengerRoutes = new List<PassengerRoute>
                {
                    new PassengerRoute
                    {
                        Length = 100,
                    },
                    new PassengerRoute
                    {
                        Length = 50,
                    },
                    new PassengerRoute
                    {
                        Length = 50,
                    }
                }

            };
            var priceForLiter = 2;

            //Act
            journeyService.GiveTotalPrices(journey, priceForLiter);
            var expected1 = 7.5m;
            var expected2 = 2.5m;
            var expected3 = 2.5m;
            var actual1 = journey.PassengerRoutes[0].TotalPrice;
            var actual2 = journey.PassengerRoutes[1].TotalPrice;
            var actual3 = journey.PassengerRoutes[2].TotalPrice;

            //Assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
        }

        [TestMethod]
        public void GiveTotalPricesTest_PassengerRouteTotalPrice_5()
        {
            //Arrange
            var journeyService = new JourneyService();
            var journey = new Journey
            {
                Car = new Car
                {
                    FuelConsumption100km = 10
                },
                Length = 100,
                PassengerRoutes = new List<PassengerRoute>
                {
                    new PassengerRoute
                    {
                        Length = 75,
                    },
                    new PassengerRoute
                    {
                        Length = 50,
                    },
                    new PassengerRoute
                    {
                        Length = 25,
                    },
                     new PassengerRoute
                    {
                        Length = 10,
                    }
                }

            };
            var priceForLiter = 2;

            //Act
            journeyService.GiveTotalPrices(journey, priceForLiter);
            var expected1 = 5.32m;
            var expected2 = 2.82m;
            var expected3 = 1.15m;
            var expected4 = 0.4m;
            var actual1 = Decimal.Round(journey.PassengerRoutes[0].TotalPrice,2);
            var actual2 = Decimal.Round(journey.PassengerRoutes[1].TotalPrice,2);
            var actual3 = Decimal.Round(journey.PassengerRoutes[2].TotalPrice,2);
            var actual4 = Decimal.Round(journey.PassengerRoutes[3].TotalPrice,2);

            //Assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
            Assert.AreEqual(expected4, actual4);
        }
    }
}
