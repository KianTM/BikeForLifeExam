using System;
using System.Collections.Generic;
using System.Text;
using BikeForLife.Entities;
using Xunit;

namespace BikeForLife.EntitiesTest
{
    public class MemberTest
    {
        [Fact]
        public void GetRideLevel_ReturnsEasyWith0Rides()
        {
            Member member = new Member();
            Difficulty expectedLevel = Difficulty.Easy;

            Difficulty actualDifficulty = member.RideLevel;

            Assert.Equal<Difficulty>(expectedLevel, actualDifficulty);
        }

        [Fact]
        public void GetRideLevel_ReturnsEasyWith4Rides()
        {
            Member member = new Member();
            BikeRoute route = new BikeRoute();
            route.Difficulty = Difficulty.Easy;
            for (int i = 0; i < 4; i++)
            {
                Ride ride = new Ride();
                ride.Route = route;
                member.Add(ride);
            }
            Difficulty expectedDifficulty = Difficulty.Easy;

            Difficulty actualDifficulty = member.RideLevel;

            Assert.Equal<Difficulty>(expectedDifficulty, actualDifficulty);
        }

        [Fact]
        public void GetRideLevel_ReturnsNormalWith5Rides()
        {
            Member member = new Member();
            BikeRoute route = new BikeRoute();
            route.Difficulty = Difficulty.Easy;
            for (int i = 0; i < 5; i++)
            {
                Ride ride = new Ride();
                ride.Route = route;
                member.Add(ride);
            }
            Difficulty expectedDifficulty = Difficulty.Normal;

            Difficulty actualDifficulty = member.RideLevel;

            Assert.Equal<Difficulty>(expectedDifficulty, actualDifficulty);
        }

        [Fact]
        public void GetRideLevel_ReturnsNormalWith11Rides()
        {
            Member member = new Member();
            BikeRoute route = new BikeRoute();
            route.Difficulty = Difficulty.Easy;
            for (int i = 0; i < 11; i++)
            {
                Ride ride = new Ride();
                ride.Route = route;
                member.Add(ride);
            }
            Difficulty expectedDifficulty = Difficulty.Normal;

            Difficulty actualDifficulty = member.RideLevel;

            Assert.Equal<Difficulty>(expectedDifficulty, actualDifficulty);
        }

        [Fact]
        public void GetRideLevel_ReturnsNormalWith12Rides4IsNormal()
        {
            Member member = new Member();
            BikeRoute route = new BikeRoute();
            BikeRoute route2 = new BikeRoute();
            route.Difficulty = Difficulty.Easy;
            route2.Difficulty = Difficulty.Normal;
            for (int i = 0; i < 8; i++)
            {
                Ride ride = new Ride();
                ride.Route = route;
                member.Add(ride);
            }
            for (int i = 0; i < 4; i++)
            {
                Ride ride = new Ride();
                ride.Route = route2;
                member.Add(ride);
            }
            Difficulty expectedDifficulty = Difficulty.Normal;

            Difficulty actualDifficulty = member.RideLevel;

            Assert.Equal<Difficulty>(expectedDifficulty, actualDifficulty);
        }
        [Fact]
        public void GetRideLevel_ReturnsHardWith12Rides5IsNormal()
        {
            Member member = new Member();
            BikeRoute route = new BikeRoute();
            BikeRoute route2 = new BikeRoute();
            route.Difficulty = Difficulty.Easy;
            route2.Difficulty = Difficulty.Normal;
            for (int i = 0; i < 7; i++)
            {
                Ride ride = new Ride();
                ride.Route = route;
                member.Add(ride);
            }
            for (int i = 0; i < 5; i++)
            {
                Ride ride = new Ride();
                ride.Route = route2;
                member.Add(ride);
            }
            Difficulty expectedDifficulty = Difficulty.Hard;

            Difficulty actualDifficulty = member.RideLevel;

            Assert.Equal<Difficulty>(expectedDifficulty, actualDifficulty);
        }

        [Fact]
        public void GetRideLevel_ReturnsHardWith30Rides9IsHard()
        {
            Member member = new Member();
            BikeRoute route = new BikeRoute();
            BikeRoute route2 = new BikeRoute();
            BikeRoute route3 = new BikeRoute();
            route.Difficulty = Difficulty.Easy;
            route2.Difficulty = Difficulty.Normal;
            route3.Difficulty = Difficulty.Hard;
            for (int i = 0; i < 7; i++)
            {
                Ride ride = new Ride();
                ride.Route = route;
                member.Add(ride);
            }
            for (int i = 0; i < 5; i++)
            {
                Ride ride = new Ride();
                ride.Route = route2;
                member.Add(ride);
            }
            for (int i = 0; i < 9; i++)
            {
                Ride ride = new Ride();
                ride.Route = route3;
                member.Add(ride);
            }
            Difficulty expectedDifficulty = Difficulty.Hard;

            Difficulty actualDifficulty = member.RideLevel;

            Assert.Equal<Difficulty>(expectedDifficulty, actualDifficulty);
        }

        [Fact]
        public void GetRideLevel_ReturnsHardWith30Rides10IsHardLessThan1Year()
        {
            Member member = new Member();
            member.EnrollmentDate = DateTime.Today;
            BikeRoute route = new BikeRoute();
            BikeRoute route2 = new BikeRoute();
            BikeRoute route3 = new BikeRoute();
            route.Difficulty = Difficulty.Easy;
            route2.Difficulty = Difficulty.Normal;
            route3.Difficulty = Difficulty.Hard;
            for (int i = 0; i < 10; i++)
            {
                Ride ride = new Ride();
                ride.Route = route;
                member.Add(ride);
            }
            for (int i = 0; i < 10; i++)
            {
                Ride ride = new Ride();
                ride.Route = route2;
                member.Add(ride);
            }
            for (int i = 0; i < 10; i++)
            {
                Ride ride = new Ride();
                ride.Route = route3;
                member.Add(ride);
            }
            Difficulty expectedDifficulty = Difficulty.Hard;

            Difficulty actualDifficulty = member.RideLevel;

            Assert.Equal<Difficulty>(expectedDifficulty, actualDifficulty);
        }

        [Fact]
        public void GetRideLevel_ReturnsExpertWith30Rides() // Partial solution to an issue suggested by Morten
        {
            Member member = new Member();
            member.EnrollmentDate = DateTime.Today.AddYears(-2);
            BikeRoute route = new BikeRoute();
            BikeRoute route2 = new BikeRoute();
            BikeRoute route3 = new BikeRoute();
            route.Difficulty = Difficulty.Easy;
            route2.Difficulty = Difficulty.Normal;
            route3.Difficulty = Difficulty.Hard;
            for (int i = 0; i < 10; i++)
            {
                Ride ride = new Ride();
                ride.Route = route;
                member.Add(ride);
            }
            for (int i = 0; i < 10; i++)
            {
                Ride ride = new Ride();
                ride.Route = route2;
                member.Add(ride);
            }
            for (int i = 0; i < 10; i++)
            {
                Ride ride = new Ride();
                ride.Route = route3;
                member.Add(ride);
            }
            Difficulty expectedDifficulty = Difficulty.Expert;

            Difficulty actualDifficulty = member.RideLevel;

            Assert.Equal<Difficulty>(expectedDifficulty, actualDifficulty);
        }

        [Fact]
        public void AddRide_ReturnsTrueRideWasAdded()
        {
            Member member = new Member();
            BikeRoute route = new BikeRoute();
            route.Difficulty = Difficulty.Easy;
            Ride ride = new Ride();
            ride.Route = route;

            Assert.True(member.Add(ride));
        }

        [Fact]
        public void AddRide_ReturnsFalseRideWasntAdded()
        {
            Member member = new Member();
            BikeRoute route = new BikeRoute();
            route.Difficulty = Difficulty.Normal;
            Ride ride = new Ride();
            ride.Route = route;

            Assert.False(member.Add(ride));
        }
    }
}
