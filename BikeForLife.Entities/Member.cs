using System;
using System.Collections.Generic;
using System.Text;

namespace BikeForLife.Entities
{
    class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Difficulty RideLevel { get; }
        public IReadOnlyList<Ride> Rides { get; }

        public bool Add(Ride ride)
        {
            throw new NotImplementedException();
        }
    }
}
