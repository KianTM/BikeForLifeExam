using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BikeForLife.Entities
{
    public class Member
    {
        private List<Ride> rides = new List<Ride>();

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Difficulty RideLevel
        {
            get
            {
                return CalculateRideLevel();
            }
        }
        public IReadOnlyList<Ride> Rides
        {
            get
            {
                return rides.OrderBy(r => r.RideDate).ToList().AsReadOnly();
            }
        }

        public bool Add(Ride ride) // Tests if the member is of the right RideLevel to add a Ride to their Rides list
        {
            if ((int)ride.Route.Difficulty > (int)RideLevel) // If the Member has a lower RideLevel than the Ride difficulty, the method returns false
            {
                return false;
            }
            rides.Add(ride); 
            return true;
        }

        private Difficulty CalculateRideLevel() // Uses the list of rides to find out what the member's RideLevel is, then returns it as a Difficulty enum
        {
            int difficultyEasy = 0;   // Variables used for counting
            int difficultyNormal = 0; //   how many rides of specific
            int difficultyHard = 0;   //   difficulties the member
            int difficultyExpert = 0; //   has been a part of

            foreach (Ride ride in Rides) // Runs through each ride in the IReadOnlyList and adds +1 to the corresponding variable based on the Ride's difficulty
            {
                switch (ride.Route.Difficulty)
                {
                    case Difficulty.Easy:
                        difficultyEasy++;
                        break;
                    case Difficulty.Normal:
                        difficultyNormal++;
                        break;
                    case Difficulty.Hard:
                        difficultyHard++;
                        break;
                    case Difficulty.Expert:
                        difficultyExpert++;
                        break;
                    default:
                        break;
                }
            }

            int timeAsMember = (DateTime.Today - EnrollmentDate.Date).Days; // Uses the EnrollmentDate and DateTime.Today to calculate how many days the Member has been a member for

            // Returns a difficulty based on different criteria
            if (Rides.Count >= 30 && difficultyHard >= 10 && timeAsMember >= 365) // If the member has been on 30 rides, where at least 10 are of difficulty hard AND has been a member for at least a year, the method returns Difficulty.Expert
                return Difficulty.Expert;
            else if (Rides.Count >= 12 && difficultyNormal >= 5) // If the member has been on 12 rides where at least 5 are of difficulty normal, the method returns Difficulty.Hard
                return Difficulty.Hard;
            else if (Rides.Count >= 5) // If the member has been on 5 rides, the method returns Difficulty.Easy
                return Difficulty.Normal;
            else // In every other case, the method returns Difficulty.Easy
                return Difficulty.Easy;
        }
    }
}
