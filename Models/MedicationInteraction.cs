using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class MedicationInteraction
    {
        public MedicationInteraction()
        {
            DispensedMedications = new HashSet<DispensedMedication>();
            MedInteractionActiveIngredients = new HashSet<MedInteractionActiveIngredient>();
            PrescriptionMedications = new HashSet<PrescriptionMedication>();
        }

        public int MedInteractionId { get; set; }
        public string ActiveIngredient1 { get; set; }
        public string ActiveIngredient2 { get; set; }
        public int? IngredientId { get; set; }

        public virtual ActiveIngredient Ingredient { get; set; }
        public virtual ICollection<DispensedMedication> DispensedMedications { get; set; }
        public virtual ICollection<MedInteractionActiveIngredient> MedInteractionActiveIngredients { get; set; }
        public virtual ICollection<PrescriptionMedication> PrescriptionMedications { get; set; }
    }
}
