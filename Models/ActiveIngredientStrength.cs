using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class ActiveIngredientStrength
    {
        public ActiveIngredientStrength()
        {
            ActiveIngredients = new HashSet<ActiveIngredient>();
        }

        public int StrengthId { get; set; }
        public string StrengthDescription { get; set; }
        public string Status { get; set; }

        public virtual ICollection<ActiveIngredient> ActiveIngredients { get; set; }
    }
}
