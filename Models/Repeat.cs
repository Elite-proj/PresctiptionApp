using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace E_prescription.Models
{
    public partial class Repeat
    {
        public Repeat()
        {
            PrescriptionMedications = new HashSet<PrescriptionMedication>();
        }

        public int RepeatId { get; set; }
       // [Required(ErrorMessage = "Please enter Repeat Description name.")]
        public string RepeatDescription { get; set; }

        public virtual ICollection<PrescriptionMedication> PrescriptionMedications { get; set; }
    }
}
