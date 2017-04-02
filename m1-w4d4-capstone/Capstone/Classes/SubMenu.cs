using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;


namespace Capstone.Classes
{
    public class SubMenu
    {
        public void Display(VendingMachine vm)
        {
            while (true)
            {
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                Console.WriteLine("Current Money Provided: " + vm.Balance.ToString("C"));
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("Enter whole dollar amount");
                    vm.FeedMoney(int.Parse(Console.ReadLine()));
                    Console.Clear();
                }
                if (input == "2")
                {
                    Console.WriteLine("Please enter slot location");
                    string slotLocationInput = Console.ReadLine();
                    if (vm.LocationExists(slotLocationInput) == false)
                    {
                        Console.WriteLine("The product does not exist");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (vm.Inventory[slotLocationInput].Quantity > 0 && vm.Inventory[slotLocationInput].Price < vm.Balance)
                    {
                        TransactionWriter tw = new TransactionWriter();
                        tw.WriteTransactionItem(DateTime.Now.ToString(), vm.Inventory[slotLocationInput].ProductName
                            , slotLocationInput, vm.Balance.ToString("C"), (vm.Balance - vm.Inventory[slotLocationInput].Price).ToString("C"));
                        vm.Inventory[slotLocationInput].Quantity -= 1;
                        vm.Inventory[slotLocationInput].QuantitySold++;
                        vm.Balance -= vm.Inventory[slotLocationInput].Price;
                        Console.WriteLine("Enjoy your " + vm.Inventory[slotLocationInput].ProductName);
                        Console.WriteLine("Press any key to continue");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (vm.Inventory[slotLocationInput].Price > vm.Balance)
                    {
                        Console.WriteLine("Insufficient funds");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (vm.Inventory[slotLocationInput].Quantity == 0)
                    {
                        Console.WriteLine("Out of Stock");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                if (input == "3")
                {
                    Change c = new Change();
                    Console.WriteLine(c.MakeChange((int)(vm.Balance * 100)));
                    vm.Balance = 0;
                    Console.WriteLine("Press a key to continue");
                    Console.ReadLine();
                    Console.Clear();
                    return;
                }
            }
        }
    }
}
