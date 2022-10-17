using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Areas.Doctor.Models
{
    public class PrescribeMedication
    {
        public int MedicationID { get; set; }
        public int PrescriptionID { get; set; }
        public int RepeatID { get; set; }
        public int ConditionID { get; set; }
        public int IngredientID { get; set; }
        public int AllergyID { get; set; }
        public int ContraIndicationID { get; set; }
        public int MedInteractionID { get; set; }
        public string Instruction { get; set; }
        public int Quantity { get; set; }
        public string ContraIgnoreReason { get; set; }
        public string WarningIgnoreReason { get; set; }
        public string AllergyIgnoreReason { get; set; }
        public string Status { get; set; }
        public string DispensedStatus { get; set; }
    }
}
