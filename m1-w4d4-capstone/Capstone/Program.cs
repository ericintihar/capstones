using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Capstone.Classes;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            FileRead fr = new FileRead();
            VendingMachine vm = new VendingMachine(fr.ReadFile());
            MainMenu mm = new MainMenu();
            mm.Display(vm);
        }
    }
}
