using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class Pharmacy
    {
        public Pharmacy()
        {
            Pharmacists = new HashSet<Pharmacist>();
        }

        public int PharmacyId { get; set; }
        public string PharmacyName { get; set; }
        public string PharmacyContactNo { get; set; }
        public string PharmacyEmail { get; set; }
        public string LicenseNo { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int? SuburbId { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Pharmacist> Pharmacists { get; set; }
    }
}
