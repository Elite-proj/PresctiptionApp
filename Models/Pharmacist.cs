using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class Pharmacist
    {
        public Pharmacist()
        {
            DispensedMedications = new HashSet<DispensedMedication>();
        }

        public int PharmacistId { get; set; }
        public string RegNumber { get; set; }
        public int? PharmacyId { get; set; }

        public virtual TblUser PharmacistNavigation { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }
        public virtual ICollection<DispensedMedication> DispensedMedications { get; set; }
    }
}
