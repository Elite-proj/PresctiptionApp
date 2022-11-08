using E_prescription.Areas.Patient.Models;
using E_prescription.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace E_prescription.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;
        DataAccess data;
        DataTable dt;

        public HomeController(IConfiguration config)
        {
            this.configuration = config;
        }
        public IActionResult Index()
        {
            data = new DataAccess(configuration);
            dt = new DataTable();
            int patientId = Convert.ToInt32(HttpContext.Session.GetInt32("PatientID"));

            dt = data.GetPatientPrescriptions(patientId);

            List<PatientPrescriptionDetailsModel> patientPrescriptionDetails = new List<PatientPrescriptionDetailsModel>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PatientPrescriptionDetailsModel patientPrescriptionDetail = new PatientPrescriptionDetailsModel();

                patientPrescriptionDetail.Date = dt.Rows[i]["Date"].ToString();
                patientPrescriptionDetail.DoctorName = dt.Rows[i]["Name"].ToString();
                patientPrescriptionDetail.DoctorSurname = dt.Rows[i]["Surname"].ToString();
                patientPrescriptionDetail.PrescriptionId = int.Parse(dt.Rows[i]["PrescriptionID"].ToString());
                patientPrescriptionDetail.ConditionDescription = dt.Rows[i]["ConditionDecription"].ToString();


                patientPrescriptionDetails.Add(patientPrescriptionDetail);
            }

            ViewBag.Patients = patientPrescriptionDetails.ToList();
            dt.Clear();

            PatientPrescriptionDetailsModel patientPres = new PatientPrescriptionDetailsModel();
            dt = data.CountPatientPrescriptions(patientId);

            if (dt.Rows.Count > 0)
            {
                patientPres.PrescriptionCount = double.Parse(dt.Rows[0]["NumberOfPrescriptions"].ToString());
            }
            else
                patientPres.PrescriptionCount = 0;

            dt.Clear();

            dt = data.CountRejectedPrescriptions(patientId);

            if (dt.Rows.Count > 0)
            {
                patientPres.RejectedCount = double.Parse(dt.Rows[0]["RejectedPrescriptions"].ToString());
            }
            else
                patientPres.RejectedCount = 0;

            dt.Clear();

            dt = data.CountDispensedPrescriptions(patientId);

            if (dt.Rows.Count > 0)
            {
                patientPres.DispensedCount = double.Parse(dt.Rows[0]["DispensedPrescriptions"].ToString());
            }
            else
                patientPres.DispensedCount = 0;

            patientPres.DispensedPercentage = Math.Round((patientPres.DispensedCount / patientPres.PrescriptionCount) * 100,1);
            

            return View(patientPres);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            data = new DataAccess(configuration);
            dt = new DataTable();
            int patientId = Convert.ToInt32(HttpContext.Session.GetInt32("PatientID"));

            dt = data.GetPrescriptionDetails(id);

            List<PatientPrescriptionDetailsModel> patientPrescriptionDetails = new List<PatientPrescriptionDetailsModel>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PatientPrescriptionDetailsModel patientPrescriptionDetail = new PatientPrescriptionDetailsModel();
                patientPrescriptionDetail.PatientId = int.Parse(dt.Rows[i]["PatientID"].ToString());
                patientPrescriptionDetail.Date = dt.Rows[i]["Date"].ToString();
                patientPrescriptionDetail.DoctorId = int.Parse(dt.Rows[i]["DoctorID"].ToString());
                patientPrescriptionDetail.DoctorName = dt.Rows[i]["Name"].ToString();

                //on second page (view more details)
                patientPrescriptionDetail.MedicationName = dt.Rows[i]["MedicationName"].ToString();
                patientPrescriptionDetail.DosageDescription = dt.Rows[i]["DosageDescription"].ToString();
                //patientPrescriptionDetail.StrengthDescription = dt.Rows[i]["StrengthDescription"].ToString();
                patientPrescriptionDetail.Quantity = dt.Rows[i]["Quantity"].ToString();
                patientPrescriptionDetail.Instruction = dt.Rows[i]["Instruction"].ToString();
                patientPrescriptionDetail.RepeatDescription = dt.Rows[i]["RepeatDescription"].ToString();
                patientPrescriptionDetail.DespensedStatus = dt.Rows[i]["DispensedStatus"].ToString();

               
                patientPrescriptionDetails.Add(patientPrescriptionDetail);
            }
            dt.Clear();
            ViewBag.Details = patientPrescriptionDetails.ToList();


            return View();
        }

        [HttpGet]
        public IActionResult Condition(int id)
        {
            data = new DataAccess(configuration);
            dt = new DataTable();

            dt = data.GetPatientDiagnosis(id);

            List<PatientPrescriptionDetailsModel> GetPatientDiagnosis = new List<PatientPrescriptionDetailsModel>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PatientPrescriptionDetailsModel patientDiagnosisCondition = new PatientPrescriptionDetailsModel();
                patientDiagnosisCondition.ConditionDescription = dt.Rows[i]["ConditionDecription"].ToString();
                

                GetPatientDiagnosis.Add(patientDiagnosisCondition);
            }
            dt.Clear();
            ViewBag.Condition = GetPatientDiagnosis.ToList();


            return View();

        }
        //[HttpGet]
        public IActionResult Profile()
        {

            return View();
        }

        public IActionResult MedicalHistory(int id)
        {
            data = new DataAccess(configuration);
            dt = new DataTable();

            dt = data.GetPrescriptionDetails(id);

            List<PatientPrescriptionDetailsModel> patientPrescriptionDetails = new List<PatientPrescriptionDetailsModel>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PatientPrescriptionDetailsModel patientPrescriptionDetail = new PatientPrescriptionDetailsModel();
                patientPrescriptionDetail.Date = dt.Rows[i]["Date"].ToString();
                patientPrescriptionDetail.DoctorName = dt.Rows[i]["Name"].ToString();
                patientPrescriptionDetail.DoctorSurname = dt.Rows[i]["Surname"].ToString();
                patientPrescriptionDetail.PrescriptionId = int.Parse(dt.Rows[i]["PrescriptionID"].ToString());
                patientPrescriptionDetail.ConditionDescription = dt.Rows[i]["ConditionDecription"].ToString();
                patientPrescriptionDetail.MedicationName = dt.Rows[i]["MedicationName"].ToString();
                patientPrescriptionDetail.DespensedStatus = dt.Rows[i]["DespensedStatus"].ToString();

                patientPrescriptionDetails.Add(patientPrescriptionDetail);
            }
            dt.Clear();
            ViewBag.Details = patientPrescriptionDetails.ToList();


            return View();

        }
    }
}
