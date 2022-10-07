using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class ActiveIngredient
    {
        public ActiveIngredient()
        {
            ContraIndications = new HashSet<ContraIndication>();
            MedInteractionActiveIngredients = new HashSet<MedInteractionActiveIngredient>();
            MedicationActiveIngredients = new HashSet<MedicationActiveIngredient>();
            MedicationInteractions = new HashSet<MedicationInteraction>();
            PatientAllergies = new HashSet<PatientAllergy>();
        }

        public int IngredientId { get; set; }
        public string IngredientDescription { get; set; }
        public int? StrengthId { get; set; }
        public string Status { get; set; }

        public virtual ActiveIngredientStrength Strength { get; set; }
        public virtual ICollection<ContraIndication> ContraIndications { get; set; }
        public virtual ICollection<MedInteractionActiveIngredient> MedInteractionActiveIngredients { get; set; }
        public virtual ICollection<MedicationActiveIngredient> MedicationActiveIngredients { get; set; }
        public virtual ICollection<MedicationInteraction> MedicationInteractions { get; set; }
        public virtual ICollection<PatientAllergy> PatientAllergies { get; set; }
    }
}
