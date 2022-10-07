using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class PostalCode
    {
        public int PostalCodeId { get; set; }
        public string PostalCodeName { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
}
