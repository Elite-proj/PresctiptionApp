using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Areas.Pharmacist.Models
{
    public class RejectPrescriptionItemVM
    {
        public int MedicationID { get; set; }
        public string MedicationName { get; set; }
        public int PrescriptionID { get; set; }
        public int PharmacistID { get; set; }
        [Required(ErrorMessage ="Enter rejection reason")]
        public string RejectionReason { get; set; }
    }
}
