﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace E_prescription
{
    public partial class City
    {
        public City()
        {
            MedicalPractice = new HashSet<MedicalPractice>();
            Pharmacy = new HashSet<Pharmacy>();
            Suburb = new HashSet<Suburb>();
            User = new HashSet<User>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public string PostalCode { get; set; }

        public virtual ICollection<MedicalPractice> MedicalPractice { get; set; }
        public virtual ICollection<Pharmacy> Pharmacy { get; set; }
        public virtual ICollection<Suburb> Suburb { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}