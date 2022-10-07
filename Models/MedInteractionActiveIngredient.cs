using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class MedInteractionActiveIngredient
    {
        public int MedInteractionActiveIngredientId { get; set; }
        public int? MedInteractionId { get; set; }
        public int? IngredientId { get; set; }
        public int? InteractionLevelId { get; set; }

        public virtual ActiveIngredient Ingredient { get; set; }
        public virtual InteractionLevel InteractionLevel { get; set; }
        public virtual MedicationInteraction MedInteraction { get; set; }
    }
}
