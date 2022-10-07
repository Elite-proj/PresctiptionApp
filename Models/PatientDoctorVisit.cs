using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class PatientDoctorVisit
    {
        public PatientDoctorVisit()
        {
            PrescriptionMedications = new HashSet<PrescriptionMedication>();
        }

        public int PatientDoctorVisitId { get; set; }
        public DateTime? VisitDate { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<PrescriptionMedication> PrescriptionMedications { get; set; }
    }
}
