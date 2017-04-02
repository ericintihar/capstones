using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class ReservationAvailable
    {
        public int SiteId { get; set; }
        public int MaxOccupancy { get; set; }
        public bool Accesible { get; set; }
        public int MaxRvLength { get; set; }
        public bool Utilities { get; set; }
        public double Cost { get; set; }
        
        public string ConvertToString()
        {
            if(Accesible)
            {
                return "yes";
            }
            return "no";
        }

        public string ConvertToStringUtilities()
        {
            if (Utilities)
            {
                return "yes";
            }
            return "no";
        }





        public override string ToString()
        {
            return SiteId.ToString().PadRight(10) + MaxOccupancy.ToString().PadRight(10) + ConvertToString().PadRight(20) + MaxRvLength.ToString().PadRight(15) + ConvertToStringUtilities().PadRight(20) + Cost.ToString("C").PadRight(15);
        }
    }
}
