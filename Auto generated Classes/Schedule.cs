﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace E_prescription
{
    public partial class Schedule
    {
        public Schedule()
        {
            MedicationRecord = new HashSet<MedicationRecord>();
        }

        public int ScheduleId { get; set; }
        public string ScheduleDescription { get; set; }

        public virtual ICollection<MedicationRecord> MedicationRecord { get; set; }
    }
}