using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using E_prescription.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_prescription.Controllers.PharmacyRecords
{
    public class PharmacyRecordsController : Controller
    {
        private readonly IConfiguration configuration;
        DataAccess data;

        public PharmacyRecordsController(IConfiguration config)
        {
            this.configuration = config;
        }

        //display add pharmacy page
        [HttpGet]
        public IActionResult Add()
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

            return View("Add");
        }

        //Get City by province
        public JsonResult LoadCities(int id)
        {
            data = new DataAccess(configuration);

            //Get Cities
            DataTable dtCities = new DataTable();
            CityModel city = new CityModel();
            city.ProvinceID = id;

            dtCities = data.GetCities(city);


            List<SelectListItem> list = new List<SelectListItem>();

            for (int i = 0; i < dtCities.Rows.Count; i++)
            {
                list.Add(new SelectListItem { Text = dtCities.Rows[i]["CityName"].ToString(), Value = Convert.ToInt32(dtCities.Rows[i]["CityID"]).ToString() });
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

            dtSuburbs = data.GetSuburbs(suburb);

            List<SelectListItem> list = new List<SelectListItem>();

            for (int i = 0; i < dtSuburbs.Rows.Count; i++)
            {
                list.Add(new SelectListItem { Text = dtSuburbs.Rows[i]["SuburbName"].ToString(), Value = Convert.ToInt32(dtSuburbs.Rows[i]["SuburbID"]).ToString() });
            }

            return Json(list);
        }

        //display list pharmacies page
        [HttpGet]
        public IActionResult List()
        {
            data = new DataAccess(configuration);
            DataTable dt = new DataTable();

            dt=data.GetPharmacyRecords();

            List<PharmacyRecordsVM> pharmacies = new List<PharmacyRecordsVM>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PharmacyRecordsVM pharmacy = new PharmacyRecordsVM();
                pharmacy.PharmacyId = Convert.ToInt32(dt.Rows[i]["PharmacyID"]);
                pharmacy.PharmacyName = dt.Rows[i]["PharmacyName"].ToString();
                pharmacy.PharmacyEmail = dt.Rows[i]["PharmacyEmail"].ToString();
                pharmacy.PharmacyContactNo = int.Parse(dt.Rows[i]["PharmacyContactNo"].ToString());

                pharmacies.Add(pharmacy);
            }
            ViewBag.Pharmacies = pharmacies.ToList();

            return View();
        }

        //Submit add pharmacy page

        [HttpPost]
        public IActionResult Add(PharmacyRecordsVM pharmacy)
        {
            if(ModelState.IsValid)
            {
                data = new DataAccess(configuration);
                data.AddPharmacyRecords(pharmacy);

                return RedirectToAction("List", "PharmacyRecords");
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

                return View(pharmacy);
            }
        }
    }
}
