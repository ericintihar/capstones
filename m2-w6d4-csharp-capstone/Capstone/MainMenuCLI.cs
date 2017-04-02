using Capstone.Models;
using Capstone.Models.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    public class MainMenuCLI
    {
        const string Command_Acadia = "1";
        const string Command_Arches = "2";
        const string Command_CuyahogaNationalValleyPark = "3";
        const string Command_Nothing = "4";
        const string Command_Quit = "q";
        const string Command_View = "1";
        const string Command_Search = "2";
        const string Command_Return = "3";
        const string Command_MM = "4";
        const string DatabaseConnection = @"Data Source=.\SQLEXPRESS;Initial Catalog=capstone2;User ID=te_student;Password=sqlserver1";

        public void RunCLI()
        {
            GetHeader();
            PrintMenu();
            while (true)
            {
                string command = Console.ReadLine();

                Console.Clear();

                switch (command.ToLower())
                {
                    case Command_Acadia:
                        GetAcadia();
                        break;

                    case Command_Arches:
                        GetArches();
                        break;

                    case Command_CuyahogaNationalValleyPark:
                        GetCuyahoga();
                        break;

                    case Command_Nothing:

                        Console.WriteLine("why would you hit the button that has ...?");

                        break;

                    case Command_Quit:
                        Console.WriteLine("Thanks, bye");
                        return;

                    default:
                        Console.WriteLine("The command provided was not a valid command, please try again.");
                        PrintMenu();
                        break;

                }

            }
        }

        public void GetAcadia()
        {
            AcadiaDAL dal = new AcadiaDAL(DatabaseConnection);
            List<Park> parks = dal.GetAcadiaInfo();
            int id = dal.getId();
            if (parks.Count > 0)
            {
                parks.ForEach(dept =>
                {
                    Console.WriteLine(dept);
                });
            }
            else
            {
                Console.WriteLine("**** NO RESULTS ****");
            }
            Console.WriteLine();
            DisplaySubMenu(id);

        }

        public void GetArches()
        {
            ArchesDAL dal = new ArchesDAL(DatabaseConnection);
            List<Park> parks = dal.GetArchesInfo();
            int id = dal.getId();
            if (parks.Count > 0)
            {
                parks.ForEach(dept =>
                {
                    Console.WriteLine(dept);
                });
            }
            else
            {
                Console.WriteLine("**** NO RESULTS ****");
            }
            Console.WriteLine();
            DisplaySubMenu(id);
        }

        public void GetCuyahoga()
        {
            CuyahogaDAL dal = new CuyahogaDAL(DatabaseConnection);
            List<Park> parks = dal.GetCuyahogaInfo();
            int id = dal.getId();
            if (parks.Count > 0)
            {
                parks.ForEach(dept =>
                {
                    Console.WriteLine(dept);
                });
            }
            else
            {
                Console.WriteLine("**** NO RESULTS ****");
            }
            Console.WriteLine();
            DisplaySubMenu(id);
        }

        public void DisplaySubMenu(int id)
        {
            Console.WriteLine("Select A Command");
            Console.WriteLine(" 1) View Campgrounds");
            Console.WriteLine(" 2) Search for Reservation");
            Console.WriteLine(" 3) Return to Previous Screen");
            Console.WriteLine(" 4) Return to Main Menu");

            while (true)
            {
                string command = Console.ReadLine();

                Console.Clear();

                switch (command.ToLower())
                {
                    case Command_View:
                        Console.WriteLine($"            Name                            Open         Close        Daily Fee");
                        GetCampgrounds(id);
                        break;

                    case Command_Search:
                        WhatsAvailable();
                        break;

                    case Command_Return:
                        PrintMenu();  //might need to change this to main menu
                        break;

                    case Command_MM:
                        PrintMenu();
                        break;

                    case Command_Quit:
                        Console.WriteLine("Thanks, bye");
                        return;

                    default:
                        Console.WriteLine("The command provided was not a valid command, please try again.");
                        PrintMenu();
                        break;

                }
            }
        }

        public void GetCampgrounds(int id)
        {

            CampgroundDAL campgroundDal = new CampgroundDAL(DatabaseConnection);
            List<Campground> campground = campgroundDal.GetCampground(id);

            if (campground.Count > 0)
            {
                campground.ForEach(dept =>
                {
                    Console.WriteLine(dept);
                });
            }
            else
            {
                Console.WriteLine("**** NO RESULTS ****");
            }
            Console.WriteLine();
            DisplaySubMenu(id);
        }

        public void GetHeader()
        {
            Console.WriteLine("Select a Park for Further Details");

        }
        public void PrintMenu()
        {
            Console.WriteLine(" 1) Acadia");
            Console.WriteLine(" 2) Arches");
            Console.WriteLine(" 3) Cuyahoga National Valley Park");
            Console.WriteLine(" 4) ...");
            Console.WriteLine(" Q) quit");

            while (true)
            {
                string command = Console.ReadLine();

                Console.Clear();

                switch (command.ToLower())
                {
                    case Command_Acadia:
                        GetAcadia();
                        break;

                    case Command_Arches:
                        GetArches();
                        break;

                    case Command_CuyahogaNationalValleyPark:
                        GetCuyahoga();
                        break;

                    case Command_Nothing:

                        Console.WriteLine("why would you hit the button that has ...?");

                        break;

                    case Command_Quit:
                        Console.WriteLine("Thanks, bye");
                        return;

                    default:
                        Console.WriteLine("The command provided was not a valid command, please try again.");
                        PrintMenu();
                        break;

                }
            }
        }
        //
        //
        public void WhatsAvailable()
        {

            Console.WriteLine("Select A Command");
            Console.WriteLine(" 1) Search for Available Reservation");
            Console.WriteLine(" 2) Return to the Previous Screen");
            while (true)
            {
                string command = Console.ReadLine();

                Console.Clear();

                if (command == "1")
                {
                    AvailabilitySearch();
                }
                else if (command == "2")
                {
                    PrintMenu();
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }

            }
        }

        public void AvailabilitySearch()
        {

            Console.WriteLine("Which campground (enter 0 to cancel)? ____");
            string pId = Console.ReadLine();
            Console.WriteLine("What is the arrival date?");
            string arrival = Console.ReadLine();
            DateTime arrivalDt = DateTime.Parse(arrival).Date;
            Console.WriteLine("What is the departure date?");
            string departure = Console.ReadLine();
            DateTime departureDt = DateTime.Parse(departure).Date;

            ReservationAvailableDAL dal = new ReservationAvailableDAL(DatabaseConnection);
            List<ReservationAvailable> reserve = dal.GetReservationAvailable(pId, arrivalDt, departureDt);
            Console.WriteLine("Site No. Max Occup Accessible?      Max RV Length      Utility             Cost");
            if (reserve.Count > 0)
            {
                reserve.ForEach(dept =>
                {
                    Console.WriteLine(dept);
                });
            }
            else
            {
                Console.WriteLine("**** NO RESULTS ****");
            }
            Console.WriteLine();
            ConfirmReservation(arrivalDt, departureDt);
        }

        public void ConfirmReservation(DateTime arrivalDt, DateTime departureDt)
        {

            Console.WriteLine("Which site should be reserved?");
            string reservationId = Console.ReadLine();
            int reservationIdInt = int.Parse(reservationId);
            Console.WriteLine("What name should the reservation be made under?");
            string userName = Console.ReadLine();

            ReservationDAL dal = new ReservationDAL(DatabaseConnection);
            dal.PlaceReservation(reservationIdInt, userName, arrivalDt, departureDt);
            Console.WriteLine("The reservation has been made and the confirmation ID is " + dal.PlaceReservation(reservationIdInt, userName, arrivalDt, departureDt));
            
        
            }
        }
    }







