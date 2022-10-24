using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Areas.Doctor.Models
{
    public class MedicationListVm
    {
        public int MedicationID { get; set; }
        public string MedicationName { get; set; }
        public int DosageID { get; set; }
        public string DosageDescription { get; set; }
    }
}
