using E_prescription.Areas.Doctor.Models;
using E_prescription.Models;
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

                model.DoctorID = 7;
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
                        historyViewModel.DoctorID = 7;
                        historyViewModel.PatientID = 4;
                        historyViewModel.date = DateTime.Now.ToString();

                        data.AddPatientCondition(historyViewModel);   
                    }
                    else if(history.IngredientID!=0)
                    {
                        historyViewModel.IngredientID = history.IngredientID;
                        historyViewModel.DoctorID = 7;
                        historyViewModel.PatientID = 4;
                        historyViewModel.date = DateTime.Now.ToString();

                        data.AddPatientAllergy(historyViewModel);
                    }
                    else if(history.MedicationID!=0)
                    {
                        historyViewModel.MedicationID = history.MedicationID;
                        historyViewModel.DoctorID = 7;
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
    }
}
