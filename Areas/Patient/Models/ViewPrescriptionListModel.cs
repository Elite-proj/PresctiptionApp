﻿using E_prescription.Models;
using System.Collections.Generic;
using System;

namespace E_prescription.Areas.Patient.Models
{
    public class ViewPrescriptionListModel
    {
        public int PatientId { get; set; }
        public string Idnumber { get; set; }
        public string Dob { get; set; }
        public string Date { get; set; }
        public int PrescriptionId { get; set; }
        public int DoctorId { get; set; }

        public int ConditionId { get; set; }
        public int MedicationId { get; set; }
        public int DosageId { get; set; }
        public int RepeatId { get; set; }

      
        public string MedicationName { get; set; }
        public string DosageDescription { get; set; }
        public string RepeatDescription { get; set; }
        public string Quantity { get; set; }
        public string Instruction { get; set; }
        public string DespensedStatus { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public string ConditionDescription { get; set; }
       

    }
}