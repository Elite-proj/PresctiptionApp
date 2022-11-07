using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Models
{
    public class SearchPrescriptionVM
    {
        public int PatientID { get; set; }

        [Required(ErrorMessage ="Enter something to search.")]
        public string Search { get; set; }
    }
}
