using E_prescription.Areas.Pharmacist.Models;
using E_prescription.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Areas.Pharmacist.Controllers
{
    [Area("Pharmacist")]
    public class RejectedController : Controller
    {
        private readonly IConfiguration configuration;
        DataAccess data;
        DataTable dt;

        public RejectedController(IConfiguration config)
        {
            this.configuration = config;
        }

        [HttpGet]
        public IActionResult Display(int id)
        {
            data = new DataAccess(configuration);
            dt = new DataTable();
            DataSet dtset = new DataSet();

            dtset = data.GetRejectedPrescriptions(id);
            List<PatientPrescriptionVM> patientPrescriptions = new List<PatientPrescriptionVM>();

            //for(int i=0;i<dtset.Tables.Count;i++)
            //{

            //}
            dt = dtset.Tables[0];
            if (dt.Rows.Count>0)
            {
                for (int i = 0; i < dtset.Tables.Count; i++)
                {
                    dt = dtset.Tables[i];
                    PatientPrescriptionVM patientPrescription = new PatientPrescriptionVM();

                    if (dt.Columns.Contains("MedicationID"))
                    {
                        
                        patientPrescription.DoctorName = dt.Rows[0]["Name"].ToString();
                        patientPrescription.DoctorSurname = dt.Rows[0]["Surname"].ToString();
                        patientPrescription.ConditionDescription = dt.Rows[0]["ConditionDecription"].ToString();
                        patientPrescription.Date = dt.Rows[0]["Date"].ToString();
                        patientPrescription.PrescriptionID = int.Parse(dt.Rows[0]["PrescriptionID"].ToString());

                    }
                    else
                    {
                        patientPrescription.DoctorName = dt.Rows[0]["Name"].ToString();
                        patientPrescription.DoctorSurname = dt.Rows[0]["Surname"].ToString();
                        patientPrescription.ConditionDescription = dt.Rows[0]["ConditionDecription"].ToString();
                        patientPrescription.Date = dt.Rows[0]["Date"].ToString();
                        patientPrescription.PrescriptionID = int.Parse(dt.Rows[0]["PrescriptionID"].ToString());
                    }
                    dt.Clear();
                    patientPrescriptions.Add(patientPrescription);
                }

                dt.Clear();
                ViewBag.Prescriptions = patientPrescriptions.ToList();
            }

            //dtset.Clear();
            return View();
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            data = new DataAccess(configuration);
            dt = new DataTable();
            DataSet set = new DataSet();

            set = data.GetRejectedPrescriptionDetails(id);

            List<PatientPrescriptionVM> patientPrescriptions = new List<PatientPrescriptionVM>();

            for(int i=0;i<set.Tables.Count;i++)
            {
                dt = set.Tables[i];
                PatientPrescriptionVM patientPrescription = new PatientPrescriptionVM();

                if (dt.Columns.Contains("MedicationID"))
                {
                    if (dt.Rows.Count>0)
                    {
                        patientPrescription.PharmacistName = dt.Rows[0]["Name"].ToString();
                        patientPrescription.PharmacistSurname = dt.Rows[0]["Surname"].ToString();
                        patientPrescription.ConditionDescription = dt.Rows[0]["ConditionDecription"].ToString();
                        patientPrescription.Date = dt.Rows[0]["Date"].ToString();
                        patientPrescription.MedicationID = int.Parse(dt.Rows[0]["MedicationID"].ToString());
                        patientPrescription.MedicationName = dt.Rows[0]["MedicationName"].ToString();
                        patientPrescription.RejectReason = dt.Rows[0]["RejectionReason"].ToString();
                        patientPrescription.Instruction = dt.Rows[0]["Instruction"].ToString();
                    }
                   
                }
                else
                {
                    if(dt.Rows.Count>0)
                    {
                        patientPrescription.PharmacistName = dt.Rows[0]["Name"].ToString();
                        patientPrescription.PharmacistSurname = dt.Rows[0]["Surname"].ToString();
                        patientPrescription.ConditionDescription = dt.Rows[0]["ConditionDecription"].ToString();
                        patientPrescription.Date = dt.Rows[0]["Date"].ToString();
                        patientPrescription.RejectReason = dt.Rows[0]["RejectionReason"].ToString();
                    }
                    
                }
                dt.Clear();
                patientPrescriptions.Add(patientPrescription);
            }

            ViewBag.Details = patientPrescriptions.ToList();

            return View();
        }
    }
}
