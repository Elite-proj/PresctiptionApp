using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace E_prescription.Models.Account
{
    public class PatientAccount:UserAccount
    {
        [Required(ErrorMessage ="Please enter ID number.")]
        public string IDnumber { get; set; }

        [Required(ErrorMessage ="Please enter date of birth")]
        public string DateOfBith { get; set; }

        [Required(ErrorMessage = "Please enter postal code")]
        public string PostalCode { get; set; }

        public string FirstVisit { get; set; } 
        
    }
}
