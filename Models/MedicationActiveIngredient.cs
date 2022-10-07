using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class MedicationActiveIngredient
    {
        public int MedicationIngredientId { get; set; }
        public int? IngredientId { get; set; }
        public int? MedicationId { get; set; }

        public virtual ActiveIngredient Ingredient { get; set; }
        public virtual MedicationRecord Medication { get; set; }
    }
}
