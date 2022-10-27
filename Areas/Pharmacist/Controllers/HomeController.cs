using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Data;
using E_prescription.Models;
using E_prescription.Areas.Pharmacist.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using E_prescription.Areas.Doctor.Models;
using E_prescription.Models.Account;

namespace E_prescription.Areas.Pharmacist.Controllers
{
    [Area("Pharmacist")]
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;
        DataAccess data;
        DataTable dt;

        public HomeController(IConfiguration config)
        {
            this.configuration = config;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult SearchPatient()
        {
            if (HttpContext.Session.GetInt32("PatientID") != null)
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

                    return RedirectToAction("SearchResult", "Home", new { area = "Pharmacist", id = int.Parse(dt.Rows[0]["PatientID"].ToString()) });
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
