using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Areas.Doctor.Models
{
    public class AllergyViewModel
    {
        public int AllergyID { get; set; }
        public int IngredientID { get; set; }
        public string IngredientDescription { get; set; }
    }
}
