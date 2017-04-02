using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Models
{
    class Site
    {
        public int SiteId { get; set; }
        public int CampgroundId { get; set; }
        public int SiteNumber { get; set; }
        public int MaxOccupancy { get; set; }
        public bool Accessible { get; set; }
        public int maxRVLength { get; set; }
        public bool Utilities { get; set; }

        public override string ToString()
        {
            return SiteNumber.ToString().PadRight(5) + MaxOccupancy.ToString().PadRight(5) + Accessible.ToString().PadRight(7)+ maxRVLength.ToString().PadRight(5)+ Utilities.ToString().PadRight(5);
        }

    }
}