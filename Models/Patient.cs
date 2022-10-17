using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class Patient
    {
        public Patient()
        {
            ChronicHistories = new HashSet<ChronicHistory>();
            ChronicMedications = new HashSet<ChronicMedication>();
            DispensedMedications = new HashSet<DispensedMedication>();
            PatientAllergies = new HashSet<PatientAllergy>();
            PatientDoctorVisits = new HashSet<PatientDoctorVisit>();
            Prescriptions = new HashSet<Prescription>();
        }

        public int PatientId { get; set; }
        public string Idnumber { get; set; }
        public string Dob { get; set; }

        public virtual TblUser PatientNavigation { get; set; }
        public virtual ICollection<ChronicHistory> ChronicHistories { get; set; }
        public virtual ICollection<ChronicMedication> ChronicMedications { get; set; }
        public virtual ICollection<DispensedMedication> DispensedMedications { get; set; }
        public virtual ICollection<PatientAllergy> PatientAllergies { get; set; }
        public virtual ICollection<PatientDoctorVisit> PatientDoctorVisits { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
