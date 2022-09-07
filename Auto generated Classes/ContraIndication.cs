﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace E_prescription
{
    public partial class ContraIndication
    {
        public ContraIndication()
        {
            DispensedMedication = new HashSet<DispensedMedication>();
            PrescriptionMedication = new HashSet<PrescriptionMedication>();
        }

        public int ContraIndicationId { get; set; }
        public int? IngredientId { get; set; }
        public int? ConditionId { get; set; }
        public string ContraIndicationName { get; set; }

        public virtual ConditionDiagnosis Condition { get; set; }
        public virtual ActiveIngredient Ingredient { get; set; }
        public virtual ICollection<DispensedMedication> DispensedMedication { get; set; }
        public virtual ICollection<PrescriptionMedication> PrescriptionMedication { get; set; }
    }
}