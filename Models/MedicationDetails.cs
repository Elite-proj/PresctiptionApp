using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Models
{
    public class MedicationDetails
    {
        public int MedicationIngredientID { get; set; }
        public int MedicationID { get; set; }
        public int IngredientID { get; set; }
        public string Strength { get; set; }


    }
}
