using E_prescription.Areas.Doctor.Models;
using E_prescription.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class MedicalHistoryController : Controller
    {
        private readonly IConfiguration configuration;
        DataAccess data;
        DataTable dt;

        public MedicalHistoryController(IConfiguration config)
        {
            this.configuration = config;
        }


        [HttpGet]
        public IActionResult Diagnosis()
        {
            data = new DataAccess(configuration);
            dt = new DataTable();

            int id = Convert.ToInt32(HttpContext.Session.GetInt32("PatientID"));
            //Get Medications
            dt = data.GetPatientDiagnosis(id);

            List<PatientCondition> patients = new List<PatientCondition>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PatientCondition patient = new PatientCondition();

                patient.ConditionID = int.Parse(dt.Rows[i]["ConditionID"].ToString());
                patient.PatientID = int.Parse(dt.Rows[i]["PatientID"].ToString());
                patient.DoctorID = int.Parse(dt.Rows[i]["DoctorID"].ToString());
                patient.ConditionName = dt.Rows[i]["ConditionDecription"].ToString();

                patients.Add(patient);
            }
            dt.Clear();

            ViewBag.Conditions = patients.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Medications()
        {
            data = new DataAccess(configuration);
            dt = new DataTable();

            int id = Convert.ToInt32(HttpContext.Session.GetInt32("PatientID"));

            dt = data.GetPatientMedications(id);

            List<MedicationListVm> medications = new List<MedicationListVm>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MedicationListVm medication = new MedicationListVm();
                medication.MedicationID = int.Parse(dt.Rows[i]["MedicationID"].ToString());
                medication.MedicationName = dt.Rows[i]["MedicationName"].ToString();
                medication.DosageDescription = dt.Rows[i]["DosageDescription"].ToString();

                medications.Add(medication);
            }
            dt.Clear();
            ViewBag.Medications = medications.ToList();

            return View();
        }

        [HttpGet]
        public IActionResult Allergies()
        {
            data = new DataAccess(configuration);
            dt = new DataTable();

            int id = Convert.ToInt32(HttpContext.Session.GetInt32("PatientID"));

            dt = data.GetPatientAllergies(id);

            List<AllergyViewModel> allergies = new List<AllergyViewModel>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                AllergyViewModel allergy = new AllergyViewModel();

                allergy.AllergyID = int.Parse(dt.Rows[i]["AllergyID"].ToString());
                allergy.IngredientID = int.Parse(dt.Rows[i]["IngredientID"].ToString());
                allergy.IngredientDescription = dt.Rows[i]["IngredientDescription"].ToString();

                allergies.Add(allergy);
            }

            ViewBag.Allergies = allergies.ToList();

            return View();
        }
    }
}
