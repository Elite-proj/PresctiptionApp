using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Areas.Pharmacist.Models
{
    public class PatientPrescriptionVM
    {
        public int PrescriptionID { get; set; }
        public int ConditionID { get; set; }
        public int DoctorID { get; set; }
        public int MedicationID { get; set; }
        public int DosageID { get; set; }
        public int RepeatID { get; set; }

        public int PatientID { get; set; }
        public string MedicationName { get; set; }
        public int DispensedMedicationID { get; set; }
        public string PharmacistName { get; set; }
        public string PharmacistSurname { get; set; }
        public string RejectReason { get; set; }
        public string DosageDescription { get; set; }
        public string RepeatDescription { get; set; }
        public string Quantity { get; set; }
        public string Instruction { get; set; }
        public string DespensedStatus { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public string ConditionDescription { get; set; }
        public string Date { get; set; }

        public string ContraIndicationReason { get; set; }
        public string MedInteractionReason { get; set; }
        public string AllergyRejection { get; set; }
        
    }
}
