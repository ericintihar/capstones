using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Models.DAL
{
    public class CampgroundDAL
    {
        private string connectionString;

        public CampgroundDAL(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Campground> GetCampground(int pId)
        {
            List<Campground> output = new List<Campground>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select * from campground where park_id = @parkId;", conn);
                    cmd.Parameters.AddWithValue("@parkId", pId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string campgroundId = Convert.ToString(reader["campground_id"]);
                        string parkId = Convert.ToString(reader["park_id"]);
                        string name = Convert.ToString(reader["name"]);
                        string openFrom = Convert.ToString(reader["open_from_mm"]);
                        string openTo = Convert.ToString(reader["open_to_mm"]);
                        string dailyFee = Convert.ToString(reader["daily_fee"]);
                        

                        Campground C = new Campground();
                        int campgroundIdint = int.Parse(campgroundId);
                        int parkIdint = int.Parse(parkId);

                        C.CampgroundId = int.Parse(campgroundId);
                        C.ParkId = int.Parse(parkId);
                        C.Name = name;
                        C.OpenFromMM = int.Parse(openFrom);
                        C.OpenToMM = int.Parse(openTo);
                        C.DailyFee = double.Parse(dailyFee);

                        output.Add(C);

                    }
                }
            }

            catch (SqlException ex)
            {
                throw;
            }

            return output;
        }

    }
}
