using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Data;
using E_prescription.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_prescription.Controllers.Medication
{
    public class MedicationController : Controller
    {
        private readonly IConfiguration configuration;
        DataAccess data;

        public MedicationController(IConfiguration config)
        {
            this.configuration = config;
        }

        [HttpGet]
        public IActionResult Add()
        {
            data = new DataAccess(configuration);
            DataTable dt = new DataTable();
            DataTable dosageDt = new DataTable();

            dt = data.GetSchedule();

            List<ScheduleVM> schedules = new List<ScheduleVM>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ScheduleVM schedule = new ScheduleVM();
                schedule.ScheduleID = int.Parse(dt.Rows[i]["ScheduleID"].ToString());
                schedule.ScheduleDescription = dt.Rows[i]["ScheduleDescription"].ToString();

                schedules.Add(schedule);
            }

            ViewBag.Schedules = new SelectList(schedules.ToList(), "ScheduleID", "ScheduleDescription");

            dosageDt = data.GetDosageForm();

            List<DosageVM> dosages = new List<DosageVM>();

            for(int j=0;j<dosageDt.Rows.Count;j++)
            {
                DosageVM dosage = new DosageVM();

                dosage.DosageID = int.Parse(dosageDt.Rows[j]["DosageID"].ToString());
                dosage.DosageDescription = dosageDt.Rows[j]["DosageDescription"].ToString();

                dosages.Add(dosage);
            }
            ViewBag.Dosages = new SelectList(dosages.ToList(), "DosageID", "DosageDescription");

            return View();
        }

        [HttpGet]
        public IActionResult Details()
        {
            data = new DataAccess(configuration);
            DataTable dt = new DataTable();
            DataTable ingredientDT = new DataTable();

            dt = data.GetMedicationByMaxId();

            MedicationVM medication = new MedicationVM();

            medication.MedicationID = int.Parse(dt.Rows[0]["MedicationID"].ToString());
            medication.MedicationName = dt.Rows[0]["MedicationName"].ToString();

            ingredientDT = data.GetIngredients();

            List<ActiveIngredientVM> ingredients = new List<ActiveIngredientVM>();

            for(int i=0;i<ingredientDT.Rows.Count;i++)
            {
                ActiveIngredientVM ingredient = new ActiveIngredientVM();
                ingredient.IngredientID = int.Parse(ingredientDT.Rows[i]["IngredientID"].ToString());
                ingredient.IngredientDescription = ingredientDT.Rows[i]["Name"].ToString();

                ingredients.Add(ingredient);
            }

            ViewBag.Ingredients = new SelectList(ingredients.ToList(), "IngredientID", "IngredientDescription");

            return View(medication);
        }

        [HttpGet]
        public IActionResult List()
        {
            data = new DataAccess(configuration);
            DataTable dt = new DataTable();

            dt = data.GetMedicationIngredient();

            List<MedicationIngredientModel> medicationIngredients = new List<MedicationIngredientModel>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MedicationIngredientModel medicationIngredient = new MedicationIngredientModel();
                medicationIngredient.MedicationID = int.Parse(dt.Rows[i]["MedicationID"].ToString());
                medicationIngredient.IngredientID= int.Parse(dt.Rows[i]["IngredientID"].ToString());
                medicationIngredient.MedicationIngredientID= int.Parse(dt.Rows[i]["MedicationIngredientID"].ToString());
                medicationIngredient.MedicationName = dt.Rows[i]["MedicationName"].ToString();
                medicationIngredient.IngredientDecription= dt.Rows[i]["IngredientDescription"].ToString();
                medicationIngredient.DosageDescription= dt.Rows[i]["DosageDescription"].ToString();
                medicationIngredient.StrengthDescription= dt.Rows[i]["StrengthDescription"].ToString();

                medicationIngredients.Add(medicationIngredient);
            }
            ViewBag.Medications = medicationIngredients.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Details(MedicationVM medication)
        {
            if (ModelState.IsValid)
            {
                data = new DataAccess(configuration);
                DataTable dt = new DataTable();
               
                List<MedicationDetails> medications = new List<MedicationDetails>();

                medications = medication.listOfmedicationDetails;

                foreach(MedicationDetails details in medications)
                {
                    MedicationDetails medicationDetails = new MedicationDetails();
                    medicationDetails.MedicationID = medication.MedicationID;
                    medicationDetails.IngredientID = details.IngredientID;

                    data.AddMedicationIngredient(medicationDetails);
                }

                TempData["MedIngredients"] = $"Successfully added medication.";

                return RedirectToAction("List", "Medication");
            }
            else
                return View(medication);

        }

        [HttpPost]
        public  IActionResult Add(MedicationVM medication)
        {
            if (ModelState.IsValid)
            {
                data = new DataAccess(configuration);
                data.AddMedication(medication);

                return RedirectToAction("Details", "Medication");
            }
            else
                return View(medication);
        }
    }
}
