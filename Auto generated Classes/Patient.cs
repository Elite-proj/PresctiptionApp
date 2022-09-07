﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace E_prescription
{
    public partial class Patient
    {
        public Patient()
        {
            ChronicHistory = new HashSet<ChronicHistory>();
            ChronicMedication = new HashSet<ChronicMedication>();
            DispensedMedication = new HashSet<DispensedMedication>();
            PatientAllergy = new HashSet<PatientAllergy>();
            PatientDoctorVisit = new HashSet<PatientDoctorVisit>();
        }

        public int PatientId { get; set; }
        public string Idnumber { get; set; }
        public string Dob { get; set; }

        public virtual ICollection<ChronicHistory> ChronicHistory { get; set; }
        public virtual ICollection<ChronicMedication> ChronicMedication { get; set; }
        public virtual ICollection<DispensedMedication> DispensedMedication { get; set; }
        public virtual ICollection<PatientAllergy> PatientAllergy { get; set; }
        public virtual ICollection<PatientDoctorVisit> PatientDoctorVisit { get; set; }
    }
}