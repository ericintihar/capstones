using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Capstone.Models;

//namespace Capstone.Models.DAL.Tests
//{
//    [TestClass()]
//    public class ReservationAvailableDALTests
//    {

//        private TransactionScope tran;      //<-- used to begin a transaction during initialize and rollback during cleanup
//        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=capstone2;User ID=te_student;Password=sqlserver1";
//        private int reservationId;                 //<-- used to hold the city id of the row created for our test

//        [TestInitialize]
//        public void Initialize()
//        {
//            Initialize a new transaction scope.This automatically begins the transaction.
//          tran = new TransactionScope();

//            Open a SqlConnection object using the active transaction
//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                SqlCommand cmd;

//                conn.Open();

//                Insert a Dummy Record for Reservation
//                cmd = new SqlCommand("select site.site_id, site.max_occupancy, site.accessible, site.max_rv_length, site.utilities, campground.daily_fee from site join campground on site.campground_id = campground.campground_id where site.site_id in (select site.site_id from site join reservation on site.site_id = reservation_idwhere (site.campground_id = 1) and('2/20/17' not between reservation.from_date and reservation.to_date and '2/27/17' not between reservation.from_date and reservation.to_date) and(reservation.from_date not between '2/20/17' and '2/27/17') and(reservation.to_date not between '2/20/17' and '2/27/17'));", conn);
//                cmd.ExecuteNonQuery();

//                Insert a Dummy Record for City that belongs to 'ABC Country'
//                If we want to the new id of the record inserted we can use
//                 SELECT CAST(SCOPE_IDENTITY() as int) as a work - around
//                 This will get the newest identity value generated for the record most recently inserted
//                cmd = new SqlCommand("INSERT INTO City VALUES ('Test City', 'ABC', 'Test District', 1); SELECT CAST(SCOPE_IDENTITY() AS int);", conn);
//                reservationId = (int)cmd.ExecuteScalar();
//            }
//        }

//        Cleanup runs after every single test
//       [TestCleanup]
//        public void Cleanup()
//        {
//            tran.Dispose(); //<-- disposing the transaction without committing it means it will get rolled back
//        }



//    }
//}