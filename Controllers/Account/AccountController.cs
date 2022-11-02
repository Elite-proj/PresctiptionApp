using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_prescription.Models.Account;
using Microsoft.Extensions.Configuration;
using E_prescription.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace E_prescription.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly IConfiguration configuration;
        DataAccess data;

        public AccountController(IConfiguration config)
        {
            this.configuration = config;
        }

        //Display login page
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //Display regitration page
        [HttpGet]
        public IActionResult Register()
        {
            data = new DataAccess(configuration);

            //Get provinces
            DataTable dt = new DataTable();

            dt=data.GetProvinces();

            List<ProvinceModel> provinces = new List<ProvinceModel>();

            for(int i=0;i<dt.Rows.Count;i++)
            {
                ProvinceModel province = new ProvinceModel();
                province.ProvinceID= Convert.ToInt32(dt.Rows[i]["ProvinceID"]);
                province.ProvinceName= dt.Rows[i]["ProvinceName"].ToString();

                provinces.Add(province);
            }
            dt.Clear();
            var getProvinces= provinces.ToList();
            ViewBag.Provinces = new SelectList(getProvinces,"ProvinceID","ProvinceName");

            dt = data.GetGender();

            List<GenderVM> genders = new List<GenderVM>();

            for(int i=0;i<dt.Rows.Count;i++)
            {
                GenderVM gender = new GenderVM();
                gender.GenderID = int.Parse(dt.Rows[i]["GenderID"].ToString());
                gender.GenderName = dt.Rows[i]["GenderName"].ToString();

                genders.Add(gender);
            }
            dt.Clear();
            ViewBag.Genders = new SelectList(genders.ToList(), "GenderID", "GenderName");

           return View();
        }

        //Get City by province
        public JsonResult LoadCities(int id)
        {
            data = new DataAccess(configuration);

            //Get Cities
            DataTable dtCities = new DataTable();
            CityModel city = new CityModel();
            city.ProvinceID = id;

            dtCities=data.GetCities(city);

            
            List<SelectListItem> list = new List<SelectListItem>();

            for (int i = 0; i < dtCities.Rows.Count; i++)
            {
                list.Add(new SelectListItem { Text = dtCities.Rows[i]["CityName"].ToString(), Value = Convert.ToInt32(dtCities.Rows[i]["CityID"]).ToString()});
            }

            return Json(list);
        }
        //Get Suburbs by city
        public JsonResult LoadSuburbs(int id)
        {
            data = new DataAccess(configuration);

            //Get Cities
            DataTable dtSuburbs = new DataTable();
            SuburbModel suburb = new SuburbModel();
            suburb.CityID = id;

            dtSuburbs=data.GetSuburbs(suburb);

            List<SelectListItem> list = new List<SelectListItem>();

            for (int i = 0; i < dtSuburbs.Rows.Count; i++)
            {
                list.Add(new SelectListItem { Text = dtSuburbs.Rows[i]["SuburbName"].ToString(), Value = Convert.ToInt32(dtSuburbs.Rows[i]["SuburbID"]).ToString() });
            }

            return Json(list);
        }

        //Submit registration
        [HttpPost]
        public IActionResult Register(PatientAccount patient)
        {
            if(ModelState.IsValid)
            {
                data = new DataAccess(configuration);
                data.RegisterPatient(patient);

                return RedirectToAction("Login", "Account");
            }
            else
            {
                data = new DataAccess(configuration);

                //Get provinces
                DataTable dt = new DataTable();

                dt = data.GetProvinces();

                List<ProvinceModel> provinces = new List<ProvinceModel>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ProvinceModel province = new ProvinceModel();
                    province.ProvinceID = Convert.ToInt32(dt.Rows[i]["ProvinceID"]);
                    province.ProvinceName = dt.Rows[i]["ProvinceName"].ToString();

                    provinces.Add(province);
                }
                var getProvinces = provinces.ToList();
                ViewBag.Provinces = new SelectList(getProvinces, "ProvinceID", "ProvinceName");

                return View(patient);
            }

        }

        //submit login
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                data = new DataAccess(configuration);
                DataTable dt = new DataTable();
                dt = data.Login(login);

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["UserType"].ToString() == "Doctor")
                    {
                        HttpContext.Session.SetInt32("DoctorID", int.Parse(dt.Rows[0]["UserID"].ToString()));
                        return RedirectToAction("SearchPatient", "Home", new { area = "Doctor" });
                    }
                    else if (dt.Rows[0]["UserType"].ToString() == "Pharmacist")
                    {
                        HttpContext.Session.SetInt32("PharmacistID", int.Parse(dt.Rows[0]["UserID"].ToString()));
                        return RedirectToAction("SearchPatient", "Home", new { area = "Pharmacist" });
                    }
                    else if (dt.Rows[0]["UserType"].ToString() == "Patient")
                    {
                        HttpContext.Session.SetInt32("PatientID", int.Parse(dt.Rows[0]["UserID"].ToString()));
                        return RedirectToAction("Index", "Home", new { area = "Patient" });
                    }
                    else if(dt.Rows[0]["UserType"].ToString() == "Admin")
                    {
                        return RedirectToAction("Welcome", "Home");
                    }
                    else
                        return Invalid();
                }
                else
                    return Invalid();
            }
            else
            {
                ModelState.AddModelError("", "Invalid username/password");

                return View(login);
            }
        }

        //inva;id login error
        private ActionResult Invalid()
        {
            ModelState.AddModelError("", "Invalid username/password");
            return View("Login");
        }
    }
}
