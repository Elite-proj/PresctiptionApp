﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace E_prescription
{
    public partial class Pharmacy
    {
        public Pharmacy()
        {
            Pharmacist = new HashSet<Pharmacist>();
        }

        public int PharmacyId { get; set; }
        public string PharmacyName { get; set; }
        public string PharmacyContactNo { get; set; }
        public string PharmacyEmail { get; set; }
        public string LicenseNo { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int? CityId { get; set; }

        public virtual City City { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Pharmacist> Pharmacist { get; set; }
    }
}