using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace E_prescription.Models
{
    public class ActiveIngredientVM
    {
        
        public int IngredientID { get; set; }
        [Required(ErrorMessage ="Please enter active ingredient name.")]
        public string IngredientDescription { get; set; }

        //[Required(ErrorMessage ="Please select active ingredient strength.")]
        //public int StrengthID { get; set; }

        public string Status { get; set; }
        
    }
}
