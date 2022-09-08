using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace E_prescription.Models.Account
{
    public class PharmacistAccount: UserAccount
    {
        [Required(ErrorMessage ="Please enter registration number.")]
        public int RegNumber { get; set; }

        public int? PharmacyID { get; set; }
    }
}
