using E_prescription.Models;
using System;
using System.Collections.Generic;

namespace E_prescription.Areas.Patient.Models
{
    public class PatientPrescriptionDetailsModel
    {
     
        public int PatientId { get; set; }
        public string Idnumber { get; set; }
        public string Date { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }

    }
}
