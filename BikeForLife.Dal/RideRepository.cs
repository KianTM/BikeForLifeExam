using System;
using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json;
using System.Text;
using BikeForLife.Entities;

namespace BikeForLife.Dal
{
    class RideRepository : BaseRepository
    {
        public List<Ride> GetAll()
        {
            string sql = "SELECT * FROM Rides";
            DataTable dataTable = ExecuteQuery(sql);
            if (dataTable == null)
                throw new InvalidOperationException($"DataTable was null. SQL string is: {sql}");
            return HandleData(dataTable);
        }

        public List<Ride> GetAllWithMemberId(int memberId)
        {
            string sql = $"SELECT * FROM Rides WHERE MemberId={memberId}";
            DataTable dataTable = ExecuteQuery(sql);
            if (dataTable == null)
                throw new InvalidOperationException($"DataTable was null. SQL string is: {sql}");
            return HandleData(dataTable);
        }

        private List<Ride> HandleData(DataTable dataTable)
        {
            if (dataTable == null)
                return null;

            List<Ride> Rides = new List<Ride>();

            foreach (DataRow row in dataTable.Rows)
            {
                BikeRouteRepository bikeRouteRepository = new BikeRouteRepository();
                MemberRepository memberRepository = new MemberRepository();
                int routeId = (int)row["BikeRouteId"];
                int memberId = (int)row[""];
                Rides.Add(new Ride()
                {
                    Id = (int)row["RideId"],
                    Route = bikeRouteRepository.GetWithId(routeId),
                    Member = memberRepository.GetWithId(memberId),
                    RideDate = (DateTime)row["RideDate"]
                });
            }
            return Rides;
        }
    }
}
