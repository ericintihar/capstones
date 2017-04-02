using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Park
    {
        public int parkId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime EstablishedDate { get; set; }
        public int Area { get; set; }
        public int Visitors { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $" {Name} National Park \n Location: { Location} \n Established: { EstablishedDate.ToShortDateString()} \n Area: {Area} \n Annual Visitors: {Visitors} \n {Description}";
        }

    }
}
