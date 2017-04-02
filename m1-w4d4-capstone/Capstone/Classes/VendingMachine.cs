using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public Dictionary<string, Product> Inventory { get; set; }
        public double Balance { get; set; }

        public VendingMachine(Dictionary<string, Product> file)
        {
            Inventory = file;
            Balance = 0;
        }

        public void FeedMoney(int moneyIn)
        {
            Balance += (Double)moneyIn;
        }

        public void DisplayInventory()
        {
            Console.Clear();
            Console.WriteLine("Slot        Product Name            Price             Quantity Remaining");
            Console.WriteLine();
            foreach (KeyValuePair<string, Product> kvp in Inventory)
            {
                Console.WriteLine(kvp.Key.PadRight(12) + kvp.Value.ProductName.PadRight(24) + (kvp.Value.Price).ToString("C").PadRight(20) + kvp.Value.Quantity);                
            }
            Console.WriteLine("Press any key to continue");
            return;
        }

        public bool LocationExists(string slotLocationInput)
        {
            return Inventory.ContainsKey(slotLocationInput);
        }
    }
}
        
