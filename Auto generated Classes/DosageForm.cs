﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace E_prescription
{
    public partial class DosageForm
    {
        public DosageForm()
        {
            DispensedMedication = new HashSet<DispensedMedication>();
            Prescription = new HashSet<Prescription>();
            PrescriptionMedication = new HashSet<PrescriptionMedication>();
        }

        public int DosageId { get; set; }
        public string DosageDescription { get; set; }

        public virtual ICollection<DispensedMedication> DispensedMedication { get; set; }
        public virtual ICollection<Prescription> Prescription { get; set; }
        public virtual ICollection<PrescriptionMedication> PrescriptionMedication { get; set; }
    }
}