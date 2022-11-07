using E_prescription.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Controllers.MedicationInteraction
{
    public class MedicationInteractionController : Controller
    {
        private readonly IConfiguration configuration;
        DataAccess data;
        DataTable dt;

        public MedicationInteractionController(IConfiguration config)
        {
            this.configuration = config;
        }

        [HttpGet]
        public IActionResult Add()
        {
            data = new DataAccess(configuration);
            dt = new DataTable();

            dt = data.GetIngredients();

            List<ActiveIngredientVM> ingredients = new List<ActiveIngredientVM>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ActiveIngredientVM ingredient = new ActiveIngredientVM();
                ingredient.IngredientID = int.Parse(dt.Rows[i]["IngredientID"].ToString());
                ingredient.IngredientDescription = dt.Rows[i]["Name"].ToString();

                ingredients.Add(ingredient);
            }

            ViewBag.Ingredients = new SelectList(ingredients.ToList(), "IngredientID", "IngredientDescription");

            return View();
        }

        [HttpPost]
        public IActionResult Add(MedinteractionVM medinteraction)
        {
            if (ModelState.IsValid)
            {
                data = new DataAccess(configuration);
                data.AddMedicationInteraction(medinteraction);

                return RedirectToAction("Add", "MedicationInteraction");
            }
            else
                return View(medinteraction);
        }

        //[HttpGet]
        //public IActionResult List()
        //{
        //    data = new DataAccess(configuration);
        //    dt = new DataTable();

        //    dt = data.GetMedicationInteractions();

        //    List<MedinteractionVM> medinteractions = new List<MedinteractionVM>();

        //    for(int i=0;i<dt.Rows.Count;i++)
        //    {
        //        MedinteractionVM medinteraction = new MedinteractionVM();
        //        medinteraction.Ingredient1= dt
        //    }

        //    return View();
        //}
    }
}
