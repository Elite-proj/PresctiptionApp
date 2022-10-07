using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class City
    {
        public City()
        {
            MedicalPractices = new HashSet<MedicalPractice>();
            PostalCodes = new HashSet<PostalCode>();
            Suburbs = new HashSet<Suburb>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public string PostalCode { get; set; }
        public int? ProvinceId { get; set; }

        public virtual Province Province { get; set; }
        public virtual ICollection<MedicalPractice> MedicalPractices { get; set; }
        public virtual ICollection<PostalCode> PostalCodes { get; set; }
        public virtual ICollection<Suburb> Suburbs { get; set; }
    }
}
