using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DriveTracker.Services;
using DriveTracker.Entities;

namespace DriveTracker.Tests.Services
{
    [TestClass]
    public class PassengerRouteServiceTests
    {
        [TestMethod]
        public void SameUserForRoutesTest_ShouldReturnFalse()
        {
            //Arrange
            var routeService = new PassengerRouteService();

            var routes = new List<PassengerRoute>
            {
                new PassengerRoute
                {
                    UserId=3
                },
                new PassengerRoute
                {
                    UserId=2
                },
                new PassengerRoute
                {
                    UserId=4
                },
                 new PassengerRoute
                {
                    UserId=1
                }
            };

            //Act
            var expected = false;
            var actual = routeService.SameUserForRoutes(routes);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SameUserForRoutesTest_ShouldReturnTrue1()
        {
            var routeService = new PassengerRouteService();

            var routes = new List<PassengerRoute>
            {
                new PassengerRoute
                {
                    UserId=2
                },
                new PassengerRoute
                {
                    UserId=2
                },
                new PassengerRoute
                {
                    UserId=4
                },
                 new PassengerRoute
                {
                    UserId=1
                }
            };
            //Act
            var expected = true;
            var actual = routeService.SameUserForRoutes(routes);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SameUserForRoutesTest_ShouldReturnTrue2()
        {
            var routeService = new PassengerRouteService();

            var routes = new List<PassengerRoute>
            {
                new PassengerRoute
                {
                    UserId=3
                },
                new PassengerRoute
                {
                    UserId=2
                },
                new PassengerRoute
                {
                    UserId=2
                },
                 new PassengerRoute
                {
                    UserId=1
                }
            };

            //Act
            var expected = true;
            var actual = routeService.SameUserForRoutes(routes);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        public void SameUserForRoutesTest_ShouldReturnTrue3()
        {
            var routeService = new PassengerRouteService();

            var routes = new List<PassengerRoute>
            {
                new PassengerRoute
                {
                    UserId=3
                },
                new PassengerRoute
                {
                    UserId=2
                },
                new PassengerRoute
                {
                    UserId=4
                },
                 new PassengerRoute
                {
                    UserId=3
                }

            };

            //Act
            var expected = true;
            var actual = routeService.SameUserForRoutes(routes);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
