using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class MainMenu
    {
        public void Display(VendingMachine vm)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine(" _____▄▄███████▄                             Welcome to the Vendo-Matic 500");
                Console.WriteLine(" ___▄▄████████████▄");
                Console.WriteLine(" __▄████████████████▄");
                Console.WriteLine("_▄███████████████████");
                Console.WriteLine(" ___________█▌");
                Console.WriteLine("____________█");
                Console.WriteLine("____________█");
                Console.WriteLine("____________█");
                Console.WriteLine("____________█");
                Console.WriteLine("____________█▄▄█ ");

                Console.SetCursorPosition(30, 10);
                Console.WriteLine("(1) Display Vending Machine Items");

                Console.SetCursorPosition(30, 12);
                Console.WriteLine("(2) Purchase");

                Console.CursorVisible = false;
                Console.SetCursorPosition(30, 14);

                string choice = Console.ReadLine();

                if (choice != "1" && choice != "2" && choice != "0")
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input.  Please try again.");
                }

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        vm.DisplayInventory();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        SubMenu sm = new SubMenu();
                        Console.Clear();
                        sm.Display(vm);
                        break;
                    case "0":
                        SalesReport sr = new SalesReport();
                        sr.MakeSalesReport(vm);
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
