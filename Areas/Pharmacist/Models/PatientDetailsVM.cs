using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace E_prescription.Areas.Pharmacist.Models
{
    public class PatientDetailsVM
    {
        public int PatientID { get; set; }
        public int IdNumber { get; set; }

    }
}
