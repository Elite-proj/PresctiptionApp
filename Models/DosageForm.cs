using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class DosageForm
    {
        public DosageForm()
        {
            DispensedMedications = new HashSet<DispensedMedication>();
            MedicationRecords = new HashSet<MedicationRecord>();
            PrescriptionMedications = new HashSet<PrescriptionMedication>();
            Prescriptions = new HashSet<Prescription>();
        }

        public int DosageId { get; set; }
        public string DosageDescription { get; set; }
        public string Status { get; set; }

        public virtual ICollection<DispensedMedication> DispensedMedications { get; set; }
        public virtual ICollection<MedicationRecord> MedicationRecords { get; set; }
        public virtual ICollection<PrescriptionMedication> PrescriptionMedications { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
