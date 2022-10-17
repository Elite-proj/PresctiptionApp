using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class ChronicMedication
    {
        public int ChronicMedicationId { get; set; }
        public int? MedicationId { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public string Date { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual MedicationRecord Medication { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
