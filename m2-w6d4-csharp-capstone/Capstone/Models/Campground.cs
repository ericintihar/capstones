using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace Capstone.Models
{
    public class Campground
    {
        public int CampgroundId { get; set; }
        public int ParkId { get; set; }
        public string Name { get; set; }
        public int OpenFromMM { get; set; }
        public int OpenToMM { get; set; }
        public double DailyFee { get; set; }
        
        public string ConvertToMonthFrom(int OpenFromMM)
        {
            if(OpenFromMM == 1)
            {
                return "January";
            }
            if (OpenFromMM == 2)
            {
                return "February";
            }
            if (OpenFromMM == 3)
            {
                return "March";
            }
            if (OpenFromMM == 4)
            {
                return "April";
            }
            if (OpenFromMM == 5)
            {
                return "May";
            }
            if (OpenFromMM == 6)
            {
                return "June";
            }
            if (OpenFromMM == 7)
            {
                return "July";
            }
            if (OpenFromMM == 8)
            {
                return "August";
            }
            if (OpenFromMM == 9)
            {
                return "September";
            }
            if (OpenFromMM == 10)
            {
                return "October";
            }
            if (OpenFromMM == 11)
            {
                return "November";
            }
            if (OpenFromMM == 12)
            {
                return "December";
            }
            return null;

        }

        public override string ToString()
        {

           
            return CampgroundId.ToString().PadRight(7) + Name.PadRight(35) + ConvertToMonthFrom(OpenFromMM).PadRight(15) + ConvertToMonthFrom(OpenToMM).PadRight(15) + DailyFee.ToString().PadRight(7);
        }

    }
}
