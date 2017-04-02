using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Change
    {
        public string MakeChange(int changeInCents)
        {
            int quarters = 0;
            int dimes = 0;
            int nickles = 0;

            while (changeInCents >= 25)
            {
                quarters++;
                changeInCents -= 25;
            }
            while (changeInCents >= 10)
            {
                dimes++;
                changeInCents -= 10;
            }
            while (changeInCents >= 5)
            {
                nickles++;
                changeInCents -= 5;
            }

            string result = "Your change is ";

            if (quarters > 0)
            {
                if (quarters == 1)
                {
                    result += quarters + " quarter ";
                }
                else
                {
                    result += quarters + " quarters ";
                }
            }
            if (dimes > 0)
            {
                if (dimes == 1)
                {
                    result += dimes + " dime ";
                }
                else
                {
                    result += dimes + " dimes ";
                }
            }
            if (nickles > 0)
            {
                result += nickles + " nickle ";

            }
            return result;
        }
    }
}




