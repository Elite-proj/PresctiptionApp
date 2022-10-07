using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class MedicationRecord
    {
        public MedicationRecord()
        {
            ChronicMedications = new HashSet<ChronicMedication>();
            DispensedMedications = new HashSet<DispensedMedication>();
            MedicationActiveIngredients = new HashSet<MedicationActiveIngredient>();
            PrescriptionMedications = new HashSet<PrescriptionMedication>();
            Prescriptions = new HashSet<Prescription>();
        }

        public int MedicationId { get; set; }
        public string MedicationName { get; set; }
        public int? ScheduleId { get; set; }
        public int? DosageId { get; set; }

        public virtual DosageForm Dosage { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual ICollection<ChronicMedication> ChronicMedications { get; set; }
        public virtual ICollection<DispensedMedication> DispensedMedications { get; set; }
        public virtual ICollection<MedicationActiveIngredient> MedicationActiveIngredients { get; set; }
        public virtual ICollection<PrescriptionMedication> PrescriptionMedications { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
