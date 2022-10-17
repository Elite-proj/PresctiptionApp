using System;
using System.Collections.Generic;

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
        public string RepeatDescription { get; set; }

        public virtual ICollection<PrescriptionMedication> PrescriptionMedications { get; set; }
    }
}
