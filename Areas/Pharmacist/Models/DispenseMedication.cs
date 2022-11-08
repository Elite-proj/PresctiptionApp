using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Areas.Pharmacist.Models
{
    public class DispenseMedication
    {
        public int DispensedMedicationID { get; set; }
        public int MedicationID { get; set; }
        public int PatientID { get; set; }
        public int DosageID { get; set; }
        public string ContraIndicationID { get; set; }
        public string MedInteractionID { get; set; }
        public string AllergyID { get; set; }
        public int PharmacistID { get; set; }
        public int PrescriptionID { get; set; }
        public string MedicationName { get; set; }
        public string RepeatID { get; set; }
        public int Quantity { get; set; }
        public string ContraIgnoreReason { get; set; }
        public string WarningIgnoreReason { get; set; }
        public string AllergyIgnoreReason { get; set; }
        public DateTime Date { get; set; }

    }
}
