using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class ConditionDiagnosis
    {
        public ConditionDiagnosis()
        {
            ChronicHistories = new HashSet<ChronicHistory>();
            ContraIndications = new HashSet<ContraIndication>();
            Prescriptions = new HashSet<Prescription>();
        }

        public int ConditionId { get; set; }
        public string ConditionDecription { get; set; }

        public virtual ICollection<ChronicHistory> ChronicHistories { get; set; }
        public virtual ICollection<ContraIndication> ContraIndications { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
