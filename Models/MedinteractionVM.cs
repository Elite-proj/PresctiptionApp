using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Models
{
    public class MedinteractionVM
    {
        public int MedInteractionID { get; set; }
        public int Ingredient1 { get; set; }
        public string Description { get; set; }
        public int Ingredient2 { get; set; }

        public string Ingredient2Name { get; set; }

    }
}
