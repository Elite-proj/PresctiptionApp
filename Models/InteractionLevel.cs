using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class InteractionLevel
    {
        public InteractionLevel()
        {
            MedInteractionActiveIngredients = new HashSet<MedInteractionActiveIngredient>();
        }

        public int InteractionLevelId { get; set; }
        public string InteractionLevelDecsription { get; set; }

        public virtual ICollection<MedInteractionActiveIngredient> MedInteractionActiveIngredients { get; set; }
    }
}
