﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace E_prescription
{
    public partial class Repeat
    {
        public Repeat()
        {
            PrescriptionMedication = new HashSet<PrescriptionMedication>();
        }

        public int RepeatId { get; set; }
        public string RepeatDescription { get; set; }

        public virtual ICollection<PrescriptionMedication> PrescriptionMedication { get; set; }
    }
}