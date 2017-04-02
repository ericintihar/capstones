using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Models.DAL
    {
        public class ReservationDAL
        {
            private string connectionString;

            public ReservationDAL(string dbConnectionString)
            {
                connectionString = dbConnectionString;
            }

            public string PlaceReservation(int locationID, string name, DateTime arrival, DateTime departure)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("INSERT into reservation (site_id, name, from_date, to_date) VALUES (@siteid, @name, @arrival_date, @departure_date) SELECT reservation_id FROM reservation WHERE name = @name", conn);
                        cmd.Parameters.AddWithValue("@siteid", locationID);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@arrival_date", arrival);
                        cmd.Parameters.AddWithValue("@departure_date", departure);
                        SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                        {
                            string reservationId = Convert.ToString(reader["reservation_id"]);

                            return reservationId;
                        }
                    }
                }

                catch (SqlException ex)
                {
                    throw;
                }

                return null;
            }


        }
    }
