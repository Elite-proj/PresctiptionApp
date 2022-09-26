using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_prescription.Models
{
    public class ConditionDiagnosisModel
    {
        public int ConditionId { get; set; }
        [Required(ErrorMessage = "Please enter Condition Diagnosis Description.")]
        public string ConditionDecription { get; set; }

        public virtual ICollection<ChronicHistory> ChronicHistory { get; set; }
        public virtual ICollection<ContraIndication> ContraIndication { get; set; }
        public virtual ICollection<Prescription> Prescription { get; set; }
    }
}
