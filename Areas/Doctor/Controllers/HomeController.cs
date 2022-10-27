using E_prescription.Areas.Doctor.Models;
using E_prescription.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using E_prescription.Models.Account;

namespace E_prescription.Areas.Doctor.Controllers
{
    [Area("Doctor")]
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
            return View();
        }

        [HttpGet]
        public IActionResult FirstTime()
        {
            data = new DataAccess(configuration);
            dt = new DataTable();

            //Get Medications
            dt = data.GetMedication();
            List<MedicationVM> medications = new List<MedicationVM>();

            for(int i=0;i<dt.Rows.Count;i++)
            {
                MedicationVM medication = new MedicationVM();

                medication.MedicationID = int.Parse(dt.Rows[i]["MedicationID"].ToString());
                medication.MedicationName = dt.Rows[i]["MedicationName"].ToString();

                medications.Add(medication);
            }
            dt.Clear();
            ViewBag.Medications = new SelectList(medications.ToList(), "MedicationID", "MedicationName");

            //Get Ingredients

            dt = data.GetIngredients();

            List<ActiveIngredientVM> activeIngredients = new List<ActiveIngredientVM>();

            for(int i=0;i<dt.Rows.Count;i++)
            {
                ActiveIngredientVM activeIngredient = new ActiveIngredientVM();

                activeIngredient.IngredientID = int.Parse(dt.Rows[i]["IngredientID"].ToString());
                activeIngredient.IngredientDescription = dt.Rows[i]["IngredientDescription"].ToString();

                activeIngredients.Add(activeIngredient);
            }
            dt.Clear();
            ViewBag.Ingredients = new SelectList(activeIngredients.ToList(), "IngredientID", "IngredientDescription");

            //Get Disease

            dt = data.GetConditionDiagnosis();

            List<ConditionDiagnosis> conditions = new List<ConditionDiagnosis>();

            for(int i=0;i<dt.Rows.Count;i++)
            {
                ConditionDiagnosis condition = new ConditionDiagnosis();

                condition.ConditionId = int.Parse(dt.Rows[i]["ConditionID"].ToString());
                condition.ConditionDecription = dt.Rows[i]["ConditionDecription"].ToString();

                conditions.Add(condition);
            }

            ViewBag.Conditions = new SelectList(conditions.ToList(), "ConditionId", "ConditionDecription");


            return View();
        }

        [HttpPost]
        public IActionResult FirstTime(HistoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                data = new DataAccess(configuration);
                dt = new DataTable();

                model.DoctorID = Convert.ToInt32(HttpContext.Session.GetInt32("DoctorID")); ;
                model.PatientID = 4;
                model.date = DateTime.Now.ToString();
                List<HistoryViewModel> histories = new List<HistoryViewModel>();

                histories = model.listOfMedicalHistory;

               

                foreach (HistoryViewModel history in histories)
                {
                    HistoryViewModel historyViewModel = new HistoryViewModel();
                    if(history.ConditionID!=0)
                    {
                        historyViewModel.ConditionID = history.ConditionID;
                        historyViewModel.DoctorID = Convert.ToInt32(HttpContext.Session.GetInt32("DoctorID"));
                        historyViewModel.PatientID = 4;
                        historyViewModel.date = DateTime.Now.ToString();

                        data.AddPatientCondition(historyViewModel);   
                    }
                    else if(history.IngredientID!=0)
                    {
                        historyViewModel.IngredientID = history.IngredientID;
                        historyViewModel.DoctorID = Convert.ToInt32(HttpContext.Session.GetInt32("DoctorID"));
                        historyViewModel.PatientID = 4;
                        historyViewModel.date = DateTime.Now.ToString();

                        data.AddPatientAllergy(historyViewModel);
                    }
                    else if(history.MedicationID!=0)
                    {
                        historyViewModel.MedicationID = history.MedicationID;
                        historyViewModel.DoctorID = Convert.ToInt32(HttpContext.Session.GetInt32("DoctorID"));
                        historyViewModel.PatientID = 4;
                        historyViewModel.date = DateTime.Now.ToString();

                        data.AddPatientMedication(historyViewModel);
                    }
                    

                }

                return RedirectToAction("Index", "Home", new { area = "Doctor" });
            }
            else
                return View(model);
        }

        [HttpGet]
        public IActionResult SearchPatient()
        {
            if(HttpContext.Session.GetInt32("PatientID")!=null)
            {
                HttpContext.Session.Remove("PatientID");
            }
           
            return View();
        }

        [HttpGet]
        public IActionResult SearchResult(int id)
        {
            data = new DataAccess(configuration);
            dt = new DataTable();

            dt = data.GetPatientById(id);

            PatientAccount patient = new PatientAccount();
            patient.UserID = int.Parse(dt.Rows[0]["PatientID"].ToString());
            patient.FirstName = dt.Rows[0]["Name"].ToString();
            patient.Surname = dt.Rows[0]["Surname"].ToString();
            patient.IDnumber = dt.Rows[0]["IDNumber"].ToString();
            patient.AddressLine1 = dt.Rows[0]["AddressLine1"].ToString();
            patient.AddressLine2 = dt.Rows[0]["AddressLine2"].ToString();
            patient.Email = dt.Rows[0]["Email"].ToString();


            return View(patient);
        }

        [HttpPost]
        public IActionResult SearchPatient(SearchPatientVM patient)
        {
            if (ModelState.IsValid)
            {

                data = new DataAccess(configuration);
                dt = new DataTable();

                dt = data.SearchPatientByIdNumber(patient);

                if (dt.Rows.Count > 0)
                {
                   
                    return RedirectToAction("SearchResult", "Home", new { area = "Doctor", id = int.Parse(dt.Rows[0]["PatientID"].ToString()) });
                }
                else
                {
                    ModelState.AddModelError("NotFoundError", "Patient Not found!");
                    return View(patient);
                }
                   
            }
            else
            {
                ModelState.AddModelError("NotFoundError", "Patient Not found!");
                ModelState["NotFoundError"].Errors.Clear();
                return View(patient);
            }
                
        }
    }
}
