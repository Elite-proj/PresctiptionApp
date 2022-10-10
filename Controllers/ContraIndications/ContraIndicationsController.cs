using E_prescription.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Controllers.ContraIndications
{
    public class ContraIndicationsController : Controller
    {
        private readonly IConfiguration configuration;
        DataAccess data;

        public ContraIndicationsController(IConfiguration config)
        {
            this.configuration = config;
        }

        [HttpGet]
        public IActionResult Add()
        {
            data = new DataAccess(configuration);
            DataTable dt = new DataTable();

            dt = data.GetIngredients();
            List<ActiveIngredient> ingredients = new List<ActiveIngredient>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ActiveIngredient ingredient = new ActiveIngredient();

                ingredient.IngredientId = int.Parse(dt.Rows[i]["IngredientID"].ToString());
                ingredient.IngredientDescription = dt.Rows[i]["IngredientDescription"].ToString();

                ingredients.Add(ingredient);
            }

            dt.Clear();

            ViewBag.Ingredients = new SelectList(ingredients.ToList(), "IngredientId", "IngredientDescription");

            List<ConditionDiagnosis> conditions = new List<ConditionDiagnosis>();

            dt = data.GetConditionDiagnosis();

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

        [HttpGet]
        public IActionResult List()
        {
            data = new DataAccess(configuration);

            DataTable dt = new DataTable();
            dt = data.GetContraIndication();

            List<ContraIndication> contraIndications = new List<ContraIndication>();

            for(int i=0;i<dt.Rows.Count;i++)
            {
                ContraIndication contraIndication = new ContraIndication();

                contraIndication.ContraIndicationName = dt.Rows[i]["ContraIndicationName"].ToString();

                contraIndications.Add(contraIndication);
            }

            ViewBag.ContraIndications = contraIndications.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Add(ContraIndication indication)
        {
            if(ModelState.IsValid)
            {
                data = new DataAccess(configuration);
                data.AddContraIndication(indication);

                return RedirectToAction("List", "ContraIndications");
            }
            else
            {
                data = new DataAccess(configuration);
                DataTable dt = new DataTable();

                dt = data.GetIngredients();
                List<ActiveIngredient> ingredients = new List<ActiveIngredient>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ActiveIngredient ingredient = new ActiveIngredient();

                    ingredient.IngredientId = int.Parse(dt.Rows[i]["IngredientID"].ToString());
                    ingredient.IngredientDescription = dt.Rows[i]["IngredientDescription"].ToString();

                    ingredients.Add(ingredient);
                }

                dt.Clear();

                ViewBag.Ingredients = new SelectList(ingredients.ToList(), "IngredientId", "IngredientDescription");

                List<ConditionDiagnosis> conditions = new List<ConditionDiagnosis>();

                dt = data.GetConditionDiagnosis();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ConditionDiagnosis condition = new ConditionDiagnosis();
                    condition.ConditionId = int.Parse(dt.Rows[i]["ConditionID"].ToString());
                    condition.ConditionDecription = dt.Rows[i]["ConditionDescription"].ToString();

                    conditions.Add(condition);
                }

                ViewBag.Conditions = new SelectList(conditions.ToList(), "ConditionId", "ConditionDescription");

                return View(indication);
            }
        }
    }
}
