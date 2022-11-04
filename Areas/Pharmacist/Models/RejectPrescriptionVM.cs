using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Areas.Pharmacist.Models
{
    public class RejectPrescriptionVM
    {
        public int PrescriptionID { get; set; }
        public int PharmacistID { get; set; }
        [Required(ErrorMessage ="Enter rejection reason.")]
        public string RejectionReason { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public string ConditionName { get; set; }


    }
}
