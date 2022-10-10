using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Data;
using E_prescription.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_prescription.Controllers.Strength
{
    public class StrengthController : Controller
    {
        private readonly IConfiguration configuration;
        DataAccess data;

        public StrengthController(IConfiguration config)
        {
            this.configuration = config;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult List()
        {
            data = new DataAccess(configuration);
            DataTable dt = new DataTable();

            dt = data.GetStrength();

            List<StrengthVM> strengths = new List<StrengthVM>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StrengthVM strength = new StrengthVM();
                strength.strengthID = Convert.ToInt32(dt.Rows[i]["StrengthID"].ToString());
                strength.description = dt.Rows[i]["StrengthDescription"].ToString();
                strength.Status = dt.Rows[i]["Status"].ToString();

                strengths.Add(strength);
            }
            ViewBag.Strengths = strengths.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Add(StrengthVM strength)
        {
            if (ModelState.IsValid)
            {
                data = new DataAccess(configuration);
                data.AddStrength(strength);

                return RedirectToAction("List", "Strength");
            }
            else
                return View(strength);
        }
    }
}
