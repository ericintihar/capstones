using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Models.DAL
{
    public class CuyahogaDAL
    {
        private string connectionString;

        public CuyahogaDAL(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Park> GetCuyahogaInfo()
        {
            List<Park> output = new List<Park>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select * from park where park_id = 3;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string parkId = Convert.ToString(reader["park_id"]);
                        string Name = Convert.ToString(reader["name"]);
                        string Location = Convert.ToString(reader["location"]);
                        string EstablishedDate = Convert.ToString(reader["establish_date"]);
                        string Area = Convert.ToString(reader["area"]);
                        string Visitors = Convert.ToString(reader["visitors"]);
                        string Description = Convert.ToString(reader["description"]);

                        Park P = new Park();
                        int parkIdint = int.Parse(parkId);
                        P.parkId = parkIdint;
                        P.Name = Name;
                        P.Location = Location;
                        DateTime dt = DateTime.Parse(EstablishedDate);

                        P.EstablishedDate = dt.Date;
                        int areaInt = int.Parse(Area);
                        P.Area = areaInt;
                        int visitorsInt = int.Parse(Visitors);
                        P.Visitors = visitorsInt;
                        P.Description = Description;


                        output.Add(P);

                    }
                }
            }

            catch (SqlException ex)
            {
                throw;
            }

            return output;
        }

        public int getId()
        {
            List<Park> output = new List<Park>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select * from park where park_id = 3;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string parkId = Convert.ToString(reader["park_id"]);
                        string Name = Convert.ToString(reader["name"]);
                        string Location = Convert.ToString(reader["location"]);
                        string EstablishedDate = Convert.ToString(reader["establish_date"]);
                        string Area = Convert.ToString(reader["area"]);
                        string Visitors = Convert.ToString(reader["visitors"]);
                        string Description = Convert.ToString(reader["description"]);

                        Park P = new Park();
                        int parkIdint = int.Parse(parkId);
                   
                        return parkIdint;

                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return 0;
        }
    }
}



