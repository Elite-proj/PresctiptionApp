using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class Prescription
    {
        public int PrescriptionId { get; set; }
        public int? ConditionId { get; set; }
        public int? MedicationId { get; set; }
        public int? DosageId { get; set; }
        public string Instruction { get; set; }

        public virtual ConditionDiagnosis Condition { get; set; }
        public virtual DosageForm Dosage { get; set; }
        public virtual MedicationRecord Medication { get; set; }
    }
}
