using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace E_prescription.Models
{
    public class MedicationVM
    {
        public int MedicationID { get; set; }
        //[Required(ErrorMessage ="Please enter medication name.")]
        public string MedicationName { get; set; }
        //[Required(ErrorMessage ="Please select medication schedule.")]
        public int ScheduleID { get; set; }
       // [Required(ErrorMessage ="Please select dosage form.")]
        public int DosageID { get; set; }

        public List<MedicationDetails> listOfmedicationDetails { get; set; }

        
    }
}
