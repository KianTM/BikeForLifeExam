using System;
using System.Collections.Generic;
using System.Text;

namespace BikeForLife.Entities
{
    public class Ride
    {
        private BikeRoute route;
        private Member member;

        public int Id { get; set; }
        public BikeRoute Route
        {
            get => route;
            set
            {
                if (Member == null) // If no Member exists, then the route is added
                {
                    route = value;
                }
                else if ((int)Member.RideLevel >= (int)route.Difficulty) // If a Member exists, but their RideLevel is higher than or equal to the route's difficulty, then the route is added
                {
                    route = value;
                }
                else if ((int)route.Difficulty > (int)Member.RideLevel) // If a Member exists, but their RideLevel is lower than the route's difficulty, then an exception is thrown.
                {
                    throw new InvalidOperationException("Cannot add Route because a Member exists with a too low RideLevel.");
                }
            }
        }
        public Member Member
        {
            get => member;
            set
            {
                if (Route == null) // If no BikeRoute exists, then the member is added
                {
                    member = value;
                }
                else if ((int)member.RideLevel >= (int)Route.Difficulty) // If a BikeRoute exists, but the member's RideLevel is higher than or equal to the Route's difficulty, then the member is added
                {
                    member = value;
                }
                else if ((int)Route.Difficulty > (int)member.RideLevel) // If a Route exists, but the member's RideLevel is lower than the Route's Difficulty, then an exception is thrown.
                {
                    throw new InvalidOperationException("Cannot add Member because a Route exists with a too high Difficulty.");
                }
            }
        }
        public DateTime RideDate { get; set; }
        public (bool, string) IsValidRide
        {
            get
            {
                return ValidateRide();
            }
        }

        private (bool, string) ValidateRide()
        {
            if (Route == null) // Returns false if no Route exists
            {
                string errMsg = "There is no route added";
                return (false, errMsg);
            }
            else if (Member == null) // Returns false if no Member exists
            {
                string errMsg = "There is no member added";
                return (false, errMsg);
            }
            else if (RideDate == null) // Returns false if no DateTime exists
            {
                string errMsg = "There is no date added";
                return (false, errMsg);
            }
            else if (RideDate == default(DateTime)) // Returns false if a DateTime exists with the default value unchanged
            {
                string errMsg = "Date added without a value or with default value";
                return (false, errMsg);
            }
            else if ((int)Route.Difficulty > (int)Member.RideLevel) // Returns false if the defined Member's RideLevel is lower than the Route's Difficulty
            {
                string errMsg = "Member is too low ride level";
                return (false, errMsg);
            }
            return (true, ""); // Returns true if none of the above conditions are met
        }
    }
}
