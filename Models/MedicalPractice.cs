using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class MedicalPractice
    {
        public MedicalPractice()
        {
            Doctors = new HashSet<Doctor>();
        }
        public string Status { get; set; }
        public string PostalCode { get; set; }
        public int MedicalPracticeId { get; set; }
        public string PracticeName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int? SuburbId { get; set; }
        public string PracticeEmail { get; set; }
        public string PracticeContactNo { get; set; }
        public string PracticeNo { get; set; }
        public int? CityId { get; set; }
        public int? ProvinceId { get; set; }

        public virtual City City { get; set; }
        public virtual Province Province { get; set; }
        public virtual Suburb Suburb { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
