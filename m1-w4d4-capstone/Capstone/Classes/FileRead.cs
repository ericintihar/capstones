using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class FileRead
    {
        public Dictionary<string, Product> ReadFile()
        {
            string[] fileLine = new string[3];
            Dictionary<string, Product> rF = new Dictionary<string, Product>();

            using (StreamReader sr = new StreamReader(@"C:\Users\Eric Intihar\Exercises\week4-team3-c-week4-pair-exercises\m1-w4d4-capstone\productinput.txt"))
            {
                while (!sr.EndOfStream)
                {
                    Product newProduct = new Product();
                    fileLine = sr.ReadLine().Split('|');
                    newProduct.ProductName = fileLine[1];
                    newProduct.Price = Math.Round(double.Parse(fileLine[2]), 2);
                    newProduct.Quantity = 5;
                    newProduct.QuantitySold = 0;
                    rF.Add(fileLine[0], newProduct);
                }
                return rF;
            }
        }
    }
}
            

