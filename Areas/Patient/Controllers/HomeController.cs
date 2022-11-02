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
            return View();
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
    }
}
