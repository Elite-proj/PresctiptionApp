using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class DispensedMedication
    {
        public int DispensedMedicationId { get; set; }
        public int MedicationId { get; set; }
        public string Quantity { get; set; }
        public int? DosageId { get; set; }
        public int? ContraIndicationId { get; set; }
        public int? MedInteractionId { get; set; }
        public string WarningIgnoreReason { get; set; }
        public int? PharmacistId { get; set; }
        public int? PatientId { get; set; }
        public DateTime? Date { get; set; }

        public virtual ContraIndication ContraIndication { get; set; }
        public virtual DosageForm Dosage { get; set; }
        public virtual MedicationInteraction MedInteraction { get; set; }
        public virtual MedicationRecord Medication { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Pharmacist Pharmacist { get; set; }
    }
}
