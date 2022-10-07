using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class PrescriptionMedication
    {
        public int PrescriptionMedicationId { get; set; }
        public int? MedicationId { get; set; }
        public int? DosageId { get; set; }
        public int? PatientDoctorVisitId { get; set; }
        public string Instruction { get; set; }
        public string Quantity { get; set; }
        public int? RepeatId { get; set; }
        public int? ContraIndicationId { get; set; }
        public int? MedInteractionId { get; set; }
        public string WarningIgnoreReason { get; set; }
        public string Status { get; set; }
        public DateTime? PrescriptionDate { get; set; }
        public int? PrescriptionId { get; set; }

        public virtual ContraIndication ContraIndication { get; set; }
        public virtual DosageForm Dosage { get; set; }
        public virtual MedicationInteraction MedInteraction { get; set; }
        public virtual MedicationRecord Medication { get; set; }
        public virtual PatientDoctorVisit PatientDoctorVisit { get; set; }
        public virtual Repeat Repeat { get; set; }
    }
}
