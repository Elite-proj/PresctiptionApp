using E_prescription.Areas.Doctor.Models;
using E_prescription.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class PatientMedHistoryController : Controller
    {
        private readonly IConfiguration configuration;
        DataAccess data;
        DataTable dt;

        public PatientMedHistoryController(IConfiguration config)
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

            for(int i=0;i<dt.Rows.Count;i++)
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

            for(int i=0;i<dt.Rows.Count;i++)
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


        [HttpGet]
        public IActionResult AddMedication()
        {
            data = new DataAccess(configuration);
            dt = new DataTable();

            //Get Medications
            dt = data.GetMedication();
            List<MedicationVM> medications = new List<MedicationVM>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MedicationVM medication = new MedicationVM();

                medication.MedicationID = int.Parse(dt.Rows[i]["MedicationID"].ToString());
                medication.MedicationName = dt.Rows[i]["MedicationName"].ToString();

                medications.Add(medication);
            }
            dt.Clear();
            ViewBag.Medications = new SelectList(medications.ToList(), "MedicationID", "MedicationName");

            return View();

        }

        [HttpGet]
        public IActionResult AddAllergy()
        {
            data = new DataAccess(configuration);
            dt = new DataTable();

            dt = data.GetIngredients();

            List<ActiveIngredientVM> activeIngredients = new List<ActiveIngredientVM>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ActiveIngredientVM activeIngredient = new ActiveIngredientVM();

                activeIngredient.IngredientID = int.Parse(dt.Rows[i]["IngredientID"].ToString());
                activeIngredient.IngredientDescription = dt.Rows[i]["IngredientDescription"].ToString();

                activeIngredients.Add(activeIngredient);
            }
            dt.Clear();
            ViewBag.Ingredients = new SelectList(activeIngredients.ToList(), "IngredientID", "IngredientDescription");

            return View();

        }

        [HttpGet]
        public IActionResult AddCondition()
        {
            data = new DataAccess(configuration);
            dt = new DataTable();

            dt = data.GetConditionDiagnosis();

            List<ConditionDiagnosis> conditions = new List<ConditionDiagnosis>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ConditionDiagnosis condition = new ConditionDiagnosis();

                condition.ConditionId = int.Parse(dt.Rows[i]["ConditionID"].ToString());
                condition.ConditionDecription = dt.Rows[i]["ConditionDecription"].ToString();

                conditions.Add(condition);
            }
            dt.Clear();
            ViewBag.Conditions = new SelectList(conditions.ToList(), "ConditionId", "ConditionDecription");

            return View();

        }


        [HttpPost]
        public IActionResult AddMedication(HistoryViewModel medication)
        {
            if(ModelState.IsValid)
            {
                data = new DataAccess(configuration);
                medication.DoctorID = Convert.ToInt32(HttpContext.Session.GetInt32("DoctorID"));
                medication.PatientID = Convert.ToInt32(HttpContext.Session.GetInt32("PatientID"));
                medication.date = DateTime.Now.ToString();

                data.AddPatientMedication(medication);

                return RedirectToAction("Medications", "PatientMedHistory", new { area = "Doctor" });
            }
            else
            {
                data = new DataAccess(configuration);
                dt = new DataTable();

                //Get Medications
                dt = data.GetMedication();
                List<MedicationVM> medications = new List<MedicationVM>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MedicationVM medication1 = new MedicationVM();

                    medication1.MedicationID = int.Parse(dt.Rows[i]["MedicationID"].ToString());
                    medication1.MedicationName = dt.Rows[i]["MedicationName"].ToString();

                    medications.Add(medication1);
                }
                dt.Clear();
                ViewBag.Medications = new SelectList(medications.ToList(), "MedicationID", "MedicationName");

                return View(medication);
            }
        }

        [HttpPost]
        public IActionResult AddAllergy(HistoryViewModel allergy)
        {
            if (ModelState.IsValid)
            {
                data = new DataAccess(configuration);

                allergy.DoctorID = Convert.ToInt32(HttpContext.Session.GetInt32("DoctorID"));
                allergy.PatientID = Convert.ToInt32(HttpContext.Session.GetInt32("PatientID"));
                allergy.date = DateTime.Now.ToString();

                data.AddPatientAllergy(allergy);

                return RedirectToAction("Allergies", "PatientMedHistory", new { area = "Doctor" });
            }
            else
            {
                data = new DataAccess(configuration);
                dt = new DataTable();

                dt = data.GetIngredients();

                List<ActiveIngredientVM> activeIngredients = new List<ActiveIngredientVM>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ActiveIngredientVM activeIngredient = new ActiveIngredientVM();

                    activeIngredient.IngredientID = int.Parse(dt.Rows[i]["IngredientID"].ToString());
                    activeIngredient.IngredientDescription = dt.Rows[i]["IngredientDescription"].ToString();

                    activeIngredients.Add(activeIngredient);
                }
                dt.Clear();
                ViewBag.Ingredients = new SelectList(activeIngredients.ToList(), "IngredientID", "IngredientDescription");

                return View(allergy);
            }
        }

        [HttpPost]
        public IActionResult AddCondition(HistoryViewModel condition)
        {
            if(ModelState.IsValid)
            {
                data = new DataAccess(configuration);

                condition.DoctorID = Convert.ToInt32(HttpContext.Session.GetInt32("DoctorID"));
                condition.PatientID = Convert.ToInt32(HttpContext.Session.GetInt32("PatientID"));
                condition.date = DateTime.Now.ToString();

                data.AddPatientCondition(condition);

                return RedirectToAction("Diagnosis", "PatientMedHistory", new { area = "Doctor" });
            }
            else
            {
                data = new DataAccess(configuration);
                dt = new DataTable();

                dt = data.GetConditionDiagnosis();

                List<ConditionDiagnosis> conditions = new List<ConditionDiagnosis>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ConditionDiagnosis condition1 = new ConditionDiagnosis();

                    condition1.ConditionId = int.Parse(dt.Rows[i]["ConditionID"].ToString());
                    condition1.ConditionDecription = dt.Rows[i]["ConditionDecription"].ToString();

                    conditions.Add(condition1);
                }
                dt.Clear();
                ViewBag.Conditions = new SelectList(conditions.ToList(), "ConditionId", "ConditionDecription");

                return View();
            }
        }
    }
}
