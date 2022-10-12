using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Areas.Doctor.Models
{
    public class HistoryViewModel
    {
        public int ConditionID { get; set; }
        public int IngredientID { get; set; }
        public int MedicationID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public string date { get; set; }

        public List<HistoryViewModel> listOfMedicalHistory { get; set; }
    }
}
