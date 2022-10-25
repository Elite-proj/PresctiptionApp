using E_prescription.Models;
using System;
using System.Collections.Generic;

namespace E_prescription.Areas.Patient.Models
{
    public class PrescriptionListModel
    {
     
        public int PatientId { get; set; }
        public string Idnumber { get; set; }
        public string Dob { get; set; }
        public DateTime? Date { get; set; }
        public int PrescriptionId { get; set; }
        public int? DoctorId { get; set; }

        public virtual TblUser PatientNavigation { get; set; }
        public virtual ICollection<ChronicHistory> ChronicHistories { get; set; }
        public virtual ICollection<ChronicMedication> ChronicMedications { get; set; }
        public virtual ICollection<DispensedMedication> DispensedMedications { get; set; }
        public virtual ICollection<PatientAllergy> PatientAllergies { get; set; }
        public virtual ICollection<PatientDoctorVisit> PatientDoctorVisits { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
