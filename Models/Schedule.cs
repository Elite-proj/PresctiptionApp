using System;
using System.Collections.Generic;

#nullable disable

namespace E_prescription.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            MedicationRecords = new HashSet<MedicationRecord>();
        }

        public int ScheduleId { get; set; }
        public string ScheduleDescription { get; set; }
        public string Status { get; set; }

        public virtual ICollection<MedicationRecord> MedicationRecords { get; set; }
    }
}
