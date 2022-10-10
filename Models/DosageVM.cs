using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace E_prescription.Models
{
    public class DosageVM
    {
        public int DosageID { get; set; }
        [Required(ErrorMessage ="Please enter dosage form.")]
        public string DosageDescription { get; set; }
        public string Status { get; set; }
    }
}
