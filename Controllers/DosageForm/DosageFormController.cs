using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Data;
using E_prescription.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_prescription.Controllers.DosageForm
{
    public class DosageFormController : Controller
    {
        private readonly IConfiguration configuration;
        DataAccess data;

        public DosageFormController(IConfiguration config)
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

            dt = data.GetDosageForm();

            List<DosageVM> dosages = new List<DosageVM>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DosageVM dosage = new DosageVM(); ;
                dosage.DosageID = Convert.ToInt32(dt.Rows[i]["DosageID"].ToString());
                dosage.DosageDescription = dt.Rows[i]["DosageDescription"].ToString();
                dosage.Status = dt.Rows[i]["Status"].ToString();

                dosages.Add(dosage);
            }
            ViewBag.Dosages = dosages.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Add(DosageVM dosage)
        {
            if (ModelState.IsValid)
            {
                data = new DataAccess(configuration);
                data.AddDosageForm(dosage);

                return RedirectToAction("List", "DosageForm");
            }
            else
                return View(dosage);
        }
    }
}
