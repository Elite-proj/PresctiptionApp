using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Models
{
    public class CityModel
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string PostalCode { get; set; }
        public int ProvinceID { get; set; }

        public ProvinceModel province { get; set; }

        public ICollection<SuburbModel> suburbs { get; set; }

    }
}
