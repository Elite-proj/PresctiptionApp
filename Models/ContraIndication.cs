using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace E_prescription.Models
{
    public partial class ContraIndication
    {
        public ContraIndication()
        {
            DispensedMedications = new HashSet<DispensedMedication>();
            PrescriptionMedications = new HashSet<PrescriptionMedication>();
        }

        public int ContraIndicationId { get; set; }
        [Required(ErrorMessage ="Please select Ingredient.")]
        public int IngredientId { get; set; }
        [Required(ErrorMessage = "Please select Condition.")]
        public int ConditionId { get; set; }
        [Required(ErrorMessage = "Enter description")]
        public string ContraIndicationName { get; set; }

        public virtual ConditionDiagnosis Condition { get; set; }
        public virtual ActiveIngredient Ingredient { get; set; }
        public virtual ICollection<DispensedMedication> DispensedMedications { get; set; }
        public virtual ICollection<PrescriptionMedication> PrescriptionMedications { get; set; }
    }
}
