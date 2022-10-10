using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace E_prescription.Models
{
    public class StrengthVM
    {
        public int strengthID { get; set; }
        [Required(ErrorMessage ="Please enter medication strength.")]
        public string description { get; set; }

        public string Status { get; set; }
    }
}
