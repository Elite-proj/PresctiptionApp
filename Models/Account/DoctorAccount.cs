using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace E_prescription.Models.Account
{
    public class DoctorAccount: UserAccount
    {
        [Required(ErrorMessage ="Please enter HCRN.")]
        public string HCRN { get; set; }

        [Required(ErrorMessage ="Please select qualification.")]
        public int QualificationID { get; set; }

        [Required(ErrorMessage ="Please select medical practice")]
        public int MedicalPracticeID { get; set; }
    }
}
