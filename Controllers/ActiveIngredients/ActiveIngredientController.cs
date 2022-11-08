using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Data;
using E_prescription.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_prescription.Controllers.ActiveIngredients
{
    public class ActiveIngredientController : Controller
    {
        private readonly IConfiguration configuration;
        DataAccess data;

        public ActiveIngredientController(IConfiguration config)
        {
            this.configuration = config;
        }

        [HttpGet]
        public IActionResult Add()
        {
            //data = new DataAccess(configuration);
            //DataTable dt = new DataTable();

            //dt = data.GetStrength();

            //List<StrengthVM> strengths = new List<StrengthVM>();

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    StrengthVM strength = new StrengthVM();
            //    strength.strengthID = Convert.ToInt32(dt.Rows[i]["StrengthID"].ToString());
            //    strength.description = dt.Rows[i]["StrengthDescription"].ToString();
            //    strength.Status = dt.Rows[i]["Status"].ToString();

            //    strengths.Add(strength);
            //}
            //ViewBag.Strengths = new SelectList(strengths.ToList(), "strengthID", "description");

           
            return View();
        }

        [HttpGet]
        public IActionResult List()
        {
            data = new DataAccess(configuration);
            DataTable dt = new DataTable();

            dt = data.GetIngredients();

            List<ActiveIngredientVM> activeIngredients = new List<ActiveIngredientVM>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ActiveIngredientVM activeIngredient = new ActiveIngredientVM();
                activeIngredient.IngredientID = Convert.ToInt32(dt.Rows[i]["IngredientID"].ToString());
                activeIngredient.IngredientDescription = dt.Rows[i]["IngredientDescription"].ToString();
                activeIngredient.Status = dt.Rows[i]["Status"].ToString();

                activeIngredients.Add(activeIngredient);
            }
            ViewBag.Ingredients = activeIngredients.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Add(ActiveIngredientVM ingredient)
        {
            if (ModelState.IsValid)
            {
                data = new DataAccess(configuration);
                data.AddActiveIngredient(ingredient);

                return RedirectToAction("List", "ActiveIngredient");
            }
            else
                return View(ingredient);
        }
    }
}
