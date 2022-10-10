using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace E_prescription.Models
{
    public class ScheduleVM
    {
        public int ScheduleID { get; set; }
        [Required(ErrorMessage ="Please add medication schedule.")]
        public string ScheduleDescription { get; set; }

        public string Status { get; set; }
    }
}
