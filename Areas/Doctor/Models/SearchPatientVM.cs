using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Areas.Doctor.Models
{
    public class SearchPatientVM
    {
        [Required(ErrorMessage ="Please enter Patient ID number.")]
        public string IDNumber { get; set; }
    }
}
