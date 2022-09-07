﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace E_prescription
{
    public partial class MedicationInteraction
    {
        public MedicationInteraction()
        {
            DispensedMedication = new HashSet<DispensedMedication>();
            MedInteractionActiveIngredient = new HashSet<MedInteractionActiveIngredient>();
            PrescriptionMedication = new HashSet<PrescriptionMedication>();
        }

        public int MedInteractionId { get; set; }
        public string ActiveIngredient1 { get; set; }
        public string ActiveIngredient2 { get; set; }
        public int? IngredientId { get; set; }

        public virtual ActiveIngredient Ingredient { get; set; }
        public virtual ICollection<DispensedMedication> DispensedMedication { get; set; }
        public virtual ICollection<MedInteractionActiveIngredient> MedInteractionActiveIngredient { get; set; }
        public virtual ICollection<PrescriptionMedication> PrescriptionMedication { get; set; }
    }
}