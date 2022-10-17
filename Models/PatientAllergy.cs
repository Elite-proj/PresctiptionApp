using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class PatientAllergy
    {
        public PatientAllergy()
        {
            PrescriptionMedications = new HashSet<PrescriptionMedication>();
        }

        public int AllergyId { get; set; }
        public int? IngredientId { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public string Date { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual ActiveIngredient Ingredient { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<PrescriptionMedication> PrescriptionMedications { get; set; }
    }
}
