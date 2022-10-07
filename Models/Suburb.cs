using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class Suburb
    {
        public Suburb()
        {
            MedicalPractices = new HashSet<MedicalPractice>();
            TblUsers = new HashSet<TblUser>();
        }

        public int SuburbId { get; set; }
        public int? CityId { get; set; }
        public string SuburbName { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<MedicalPractice> MedicalPractices { get; set; }
        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
