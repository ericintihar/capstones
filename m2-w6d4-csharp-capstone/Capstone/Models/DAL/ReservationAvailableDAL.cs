using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Models.DAL
{
    public class ReservationAvailableDAL
    {
        private string connectionString;

        public ReservationAvailableDAL(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<ReservationAvailable> GetReservationAvailable(string pId, DateTime arrival, DateTime departure)
        {
            List<ReservationAvailable> output = new List<ReservationAvailable>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select site.site_id, site.max_occupancy, site.accessible, site.max_rv_length, site.utilities, campground.daily_fee from site join campground on site.campground_id = campground.campground_id where site.site_id in (select site.site_id from site join reservation on site.site_id = reservation_id where (site.campground_id = @campgroundSelect) and (@arrivalDate not between reservation.from_date and reservation.to_date and @departureDate not between reservation.from_date and reservation.to_date) and(reservation.from_date not between @arrivalDate and @departureDate) and(reservation.to_date not between @arrivalDate and @departureDate))", conn);
                    cmd.Parameters.AddWithValue("@arrivalDate", arrival);
                    cmd.Parameters.AddWithValue("@departureDate", departure);
                    cmd.Parameters.AddWithValue("@campgroundSelect", pId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string siteId = Convert.ToString(reader["site_id"]);
                        string maxOccupancy = Convert.ToString(reader["max_occupancy"]);
                        string accessible = Convert.ToString(reader["accessible"]);
                        string maxRvLength = Convert.ToString(reader["max_rv_length"]);
                        string utilities = Convert.ToString(reader["utilities"]);
                        string cost = Convert.ToString(reader["daily_fee"]);


                        ReservationAvailable rA = new ReservationAvailable();
                        int siteIdInt = int.Parse(siteId);
                        int maxOccupancyInt = int.Parse(maxOccupancy);
                        int maxRvLengthInt = int.Parse(maxRvLength);
                        bool accessibleBool = bool.Parse(accessible);
                        double costDouble = double.Parse(cost);
                        bool utilitiesBool = bool.Parse(utilities);

                        rA.SiteId = siteIdInt;
                        rA.MaxOccupancy = maxOccupancyInt;
                        rA.Accesible = accessibleBool;
                        rA.MaxRvLength = maxRvLengthInt;
                        rA.Utilities = utilitiesBool;
                        rA.Cost = costDouble;

                        output.Add(rA);

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
