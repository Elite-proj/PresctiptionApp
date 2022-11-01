using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Areas.Doctor.Models
{
    public class UpdatePrescriptionVM
    {
        public int PrescriptionID { get; set; }
        public int MedicationID { get; set; }
        public string MedicationName { get; set; }
        [Required(ErrorMessage ="Please enter instructions.")]
        public string Instruction { get; set; }
        [Required(ErrorMessage ="Please enter quantity.")]
        public int Quantity { get; set; }
    }
}
