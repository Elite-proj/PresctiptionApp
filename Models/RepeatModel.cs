using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_prescription.Models
{
    public class RepeatModel
    {
        public int RepeatId { get; set; }
        [Required(ErrorMessage = "Please enter Repeat Description name.")]
        public string RepeatDescription { get; set; }

        public virtual ICollection<PrescriptionMedication> PrescriptionMedications { get; set; }
    }
}
