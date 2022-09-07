﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace E_prescription.Models
{
    public class MedicalPractice
    {
        public int MedicalPracticeId { get; set; }
        public string PracticeName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int? CityId { get; set; }
        public string PracticeEmail { get; set; }
        public string PracticeContactNo { get; set; }
        public string PracticeNo { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Doctor> Doctor { get; set; }
    }
}
