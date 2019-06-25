using BikeForLife.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace BikeForLife.Dal
{
    public class BikeRouteRepository : BaseRepository
    {
        public List<BikeRoute> GetAll()
        {
            string sql = "SELECT * FROM BikeRoutes";
            DataTable dataTable = ExecuteQuery(sql);
            if (dataTable == null)
                throw new InvalidOperationException($"DataTable was null. SQL string is: {sql}");
            return HandleData(dataTable);
        }

        public bool AddToDB(BikeRoute bikeRoute) // Adds a BikeRoute to the database
        {
            string sql = $"INSERT INTO BikeRoutes VALUES('{bikeRoute.Name}', {bikeRoute.Length}, {(int)bikeRoute.Difficulty}, '{bikeRoute.Country}', '{bikeRoute.City}')"; // Creates the SQL query used to add the BikeRoute to the database
            try
            {
                ExecuteNonQuery(sql); // Tries to run the query
            }
            catch (Exception) // If the query fails, an exception is cast
            {
                return false; // Returns false if the code casts an exception
            }
            return true; // Returns true if the code runs succesfully with no exceptions
        }

        private List<BikeRoute> HandleData(DataTable dataTable)
        {
            if (dataTable == null)
                return null;

            List<BikeRoute> routes = new List<BikeRoute>();
            
            foreach (DataRow row in dataTable.Rows)
            {
                routes.Add(new BikeRoute()
                {
                    Id = (int)row["BikeRouteId"],
                    Name = (string)row["Name"],
                    Difficulty = (Difficulty)row["Difficulty"],
                    Length = (double)row["Length"],
                    Country = (string)row["Country"],
                    City = (string)row["City"]
                });
            }
            return routes;
        }
    }
}
