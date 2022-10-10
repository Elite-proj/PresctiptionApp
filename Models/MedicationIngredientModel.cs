using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Models
{
    public class MedicationIngredientModel
    {
        public int MedicationIngredientID { get; set; }
        public int IngredientID { get; set; }
        public int MedicationID { get; set; }
        public string IngredientDecription { get; set; }
        public string MedicationName { get; set; }
        public string DosageDescription { get; set; }
        public string StrengthDescription { get; set; }
        
    }
}
