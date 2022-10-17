using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            ChronicHistories = new HashSet<ChronicHistory>();
            ChronicMedications = new HashSet<ChronicMedication>();
            PatientAllergies = new HashSet<PatientAllergy>();
            PatientDoctorVisits = new HashSet<PatientDoctorVisit>();
            Prescriptions = new HashSet<Prescription>();
        }

        public int DoctorId { get; set; }
        public string Hcrn { get; set; }
        public int? QualificationId { get; set; }
        public int? MedicalPracticeId { get; set; }

        public virtual TblUser DoctorNavigation { get; set; }
        public virtual MedicalPractice MedicalPractice { get; set; }
        public virtual HighestQualification Qualification { get; set; }
        public virtual ICollection<ChronicHistory> ChronicHistories { get; set; }
        public virtual ICollection<ChronicMedication> ChronicMedications { get; set; }
        public virtual ICollection<PatientAllergy> PatientAllergies { get; set; }
        public virtual ICollection<PatientDoctorVisit> PatientDoctorVisits { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
