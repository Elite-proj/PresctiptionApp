using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class Prescription
    {
        public int PrescriptionId { get; set; }
        public int? ConditionId { get; set; }
        public DateTime? Date { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }

        public virtual ConditionDiagnosis Condition { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
