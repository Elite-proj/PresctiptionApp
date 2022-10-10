using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Data;
using E_prescription.Models;
using E_prescription.Areas.Pharmacist.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_prescription.Areas.Pharmacist.Controllers
{
    [Area("Pharmacist")]
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;
        DataAccess data;

        public HomeController(IConfiguration config)
        {
            this.configuration = config;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchPatient()
        {
            data = new DataAccess(configuration);

            //Get provinces
            DataTable dt = new DataTable();

            dt = data.GetProvinces();

            List<PatientDetailsVM> patients = new List<PatientDetailsVM>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PatientDetailsVM patient = new PatientDetailsVM();
                patient.PatientID = Convert.ToInt32(dt.Rows[i]["PatientID"].ToString());
                patient.IdNumber = Convert.ToInt32(dt.Rows[i]["IDNumber"].ToString());

                patients.Add(patient);
            }

            ViewBag.Provinces = patients.ToList();

            return View();
        }

        
    }
}
