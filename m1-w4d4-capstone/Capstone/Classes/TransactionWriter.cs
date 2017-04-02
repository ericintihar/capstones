using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class TransactionWriter
    {
        public void WriteTransactionItem(string DateTime, string Product, string Slot, string Balance, string ChangeTendered)
        {
             using (StreamWriter sw = new StreamWriter(@"C:\Users\Eric Intihar\Exercises\week4-team3-c-week4-pair-exercises\m1-w4d4-capstone\transactionlog.txt",true))
            {
                sw.WriteLine($"{DateTime} {Product} {Slot} {Balance} {ChangeTendered}");
            }
        }
    }
}
