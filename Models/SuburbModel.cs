using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Models
{
    public class SuburbModel
    {
        public int SuburbId { get; set; }
        public string SuburbName { get; set; }
        public int CityID { get; set; }

        public CityModel City { get; set; }
    }
}
