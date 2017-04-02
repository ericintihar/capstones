using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Capstone.Classes
{
    public class SalesReport
    {
        public void MakeSalesReport(VendingMachine vm)
        {
            double totalGrossSales = 0; 

            foreach (KeyValuePair<string, Product> kvp in vm.Inventory)
            {
                totalGrossSales += kvp.Value.QuantitySold * kvp.Value.Price; //totalGrossSales will equal quantitysold times the price
            }

            using (StreamWriter sw = new StreamWriter(@"C:\Users\Eric Intihar\Exercises\week4-team3-c-week4-pair-exercises\m1-w4d4-capstone\Vendo-Matic-Sales.csv", true))
            {
                foreach (KeyValuePair<string, Product> kvp in vm.Inventory)
                {
                    sw.WriteLine(kvp.Value.ProductName.PadRight(30) + kvp.Value.QuantitySold.ToString());
                }
                sw.WriteLine();
                sw.WriteLine();
                sw.WriteLine("Total Gross Sales: " + totalGrossSales.ToString("C"));
                sw.WriteLine();
                sw.WriteLine();
            }
        }
    }
}


