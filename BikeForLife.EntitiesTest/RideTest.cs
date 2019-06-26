using BikeForLife.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BikeForLife.EntitiesTest
{
    public class RideTest
    {
        [Fact]
        public void IsValidRide_ReturnsTrueWithValidRide()
        {
            Member member = new Member();
            BikeRoute route = new BikeRoute();
            route.Difficulty = Difficulty.Easy;
            Ride ride = new Ride();
            DateTime date = DateTime.Today.AddDays(-10);
            ride.Member = member;
            ride.Route = route;
            ride.RideDate = date;

            (bool isValid, string errMsg) result = ride.IsValidRide;

            Assert.True(result.isValid, result.errMsg);
        }

        [Fact]
        public void IsValidRide_ReturnsFalseWithNoMember()
        {
            BikeRoute route = new BikeRoute();
            route.Difficulty = Difficulty.Easy;
            Ride ride = new Ride();
            DateTime date = DateTime.Today.AddDays(-10);
            ride.Route = route;
            ride.RideDate = date;

            (bool isValid, string errMsg) result = ride.IsValidRide;

            Assert.False(result.isValid, result.errMsg);
        }

        [Fact]
        public void IsValidRide_ReturnsFalseWithNoRoute()
        {
            Member member = new Member();
            Ride ride = new Ride();
            DateTime date = DateTime.Today.AddDays(-10);
            ride.Member = member;
            ride.RideDate = date;

            (bool isValid, string errMsg) result = ride.IsValidRide;

            Assert.False(result.isValid, result.errMsg);
        }

        [Fact]
        public void IsValidRide_ReturnsFalseWithNoDate()
        {
            Member member = new Member();
            BikeRoute route = new BikeRoute();
            route.Difficulty = Difficulty.Easy;
            Ride ride = new Ride();
            ride.Member = member;
            ride.Route = route;

            (bool isValid, string errMsg) result = ride.IsValidRide;

            Assert.False(result.isValid, result.errMsg);
        }
    }
}
