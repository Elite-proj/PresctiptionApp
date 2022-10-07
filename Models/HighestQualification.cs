using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class HighestQualification
    {
        public HighestQualification()
        {
            Doctors = new HashSet<Doctor>();
        }

        public int QualificationId { get; set; }
        public string QualificationName { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
