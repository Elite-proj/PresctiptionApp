using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class Province
    {
        public Province()
        {
            Cities = new HashSet<City>();
            MedicalPractices = new HashSet<MedicalPractice>();
        }

        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<MedicalPractice> MedicalPractices { get; set; }
    }
}
