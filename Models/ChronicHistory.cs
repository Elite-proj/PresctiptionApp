using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class ChronicHistory
    {
        public int ChronicId { get; set; }
        public int? ConditionId { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime? Date { get; set; }

        public virtual ConditionDiagnosis Condition { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
