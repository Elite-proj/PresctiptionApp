using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Areas.Pharmacist.Models
{
    public class DispensedMedsVM
    {
        public int MedicationID { get; set; }

        public string MedicationName { get; set; }

        public int DosageID { get; set; }

        public string DosageDescription { get; set; }
        public int Quantity { get; set; }
        public string Date { get; set; }

    }
}
