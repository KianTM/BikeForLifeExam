using System;
using System.Collections.Generic;
using System.Text;

namespace BikeForLife.Entities
{
    class Ride
    {
        public int Id { get; set; }
        public BikeRoute Route { get; set; }
        public Member Member { get; set; }
        public DateTime RideDate { get; set; }
        public (bool, string) IsValidRoute { get; }
    }
}
