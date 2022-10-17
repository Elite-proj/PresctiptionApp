using System;
using System.Collections.Generic;

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
        public int? IngredientId { get; set; }
        public int? ConditionId { get; set; }
        public string ContraIndicationName { get; set; }

        public virtual ConditionDiagnosis Condition { get; set; }
        public virtual ActiveIngredient Ingredient { get; set; }
        public virtual ICollection<DispensedMedication> DispensedMedications { get; set; }
        public virtual ICollection<PrescriptionMedication> PrescriptionMedications { get; set; }
    }
}
