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
            for (int i = 0; i < 4; i++)
            {
                
            }
        }
    }
}
