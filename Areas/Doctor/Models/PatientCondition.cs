using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Areas.Doctor.Models
{
    public class PatientCondition
    {
        public int ChronicID { get; set; }
        public int ConditionID { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public DateTime Date { get; set; }

        public string ConditionName { get; set; }
    }
}
