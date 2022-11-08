using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Data;
using E_prescription.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using E_prescription.Models.Account;

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
            dt.Clear();


            dt = data.GetPhamacists();

            List<PharmacistAccount> pharmacists = new List<PharmacistAccount>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PharmacistAccount pharmacist = new PharmacistAccount();
                pharmacist.PharmacistId = Convert.ToInt32(dt.Rows[i]["PharmacistID"]);
                pharmacist.FirstName = dt.Rows[i]["NAMES"].ToString();
        
                pharmacists.Add(pharmacist);
            }

            ViewBag.Pharmacists = new SelectList(pharmacists.ToList(), "PharmacistId", "FirstName");

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
            list.Add(new SelectListItem { Text = "-- Select City --", Value = "0" });
            for (int i = 0; i < dtCities.Rows.Count; i++)
            {
                list.Add(new SelectListItem { Text = dtCities.Rows[i]["CityName"].ToString(), Value = Convert.ToInt32(dtCities.Rows[i]["CityID"]).ToString() });
            }

            return Json(list);
        }
        //Get province by ID

        public JsonResult LoadProvince(int id)
        {
            data = new DataAccess(configuration);

            DataTable dt = new DataTable();

            dt = data.GetProvinces();

            List<ProvinceModel> provinces = new List<ProvinceModel>();
            List<SelectListItem> list = new List<SelectListItem>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(new SelectListItem { Text = dt.Rows[i]["ProvinceName"].ToString(), Value = Convert.ToInt32(dt.Rows[i]["ProvinceID"]).ToString() });
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
                pharmacy.PharmacyContactNo = dt.Rows[i]["PharmacyContactNo"].ToString();

                pharmacies.Add(pharmacy);
            }
            ViewBag.Pharmacies = pharmacies.ToList();

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            data = new DataAccess(configuration);

           
            //Get provinces
            DataTable dt = new DataTable();
            DataTable city = new DataTable();
            DataTable suburb = new DataTable();
            DataTable province = new DataTable();
            DataTable getProv = new DataTable();

            getProv = data.GetProvinces();

            List<ProvinceModel> provinces = new List<ProvinceModel>();

            for (int i = 0; i < getProv.Rows.Count; i++)
            {
                ProvinceModel prov = new ProvinceModel();
                prov.ProvinceID = Convert.ToInt32(getProv.Rows[i]["ProvinceID"]);
                prov.ProvinceName = getProv.Rows[i]["ProvinceName"].ToString();

                provinces.Add(prov);
            }
            var getProvinces = provinces.ToList();
            ViewBag.Provinces = new SelectList(getProvinces, "ProvinceID", "ProvinceName");

            dt.Clear();


            dt = data.GetPhamacists();

            List<PharmacistAccount> pharmacists = new List<PharmacistAccount>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PharmacistAccount pharmacist = new PharmacistAccount();
                pharmacist.PharmacistId = Convert.ToInt32(dt.Rows[i]["PharmacistID"]);
                pharmacist.FirstName = dt.Rows[i]["NAMES"].ToString();

                pharmacists.Add(pharmacist);
            }

            ViewBag.Pharmacists = new SelectList(pharmacists.ToList(), "PharmacistId", "FirstName");
            dt.Clear();

            dt = data.GetPharmacyById(id);

            PharmacyRecordsVM pharmacy = new PharmacyRecordsVM();

            if (dt.Rows.Count>0)
            {
                
                pharmacy.PharmacyId = Convert.ToInt32(dt.Rows[0]["PharmacyID"]);
                pharmacy.PharmacyName = dt.Rows[0]["PharmacyName"].ToString();
                pharmacy.PharmacyEmail = dt.Rows[0]["PharmacyEmail"].ToString();
                pharmacy.PharmacyContactNo = dt.Rows[0]["PharmacyContactNo"].ToString();
                pharmacy.LicenseNo = dt.Rows[0]["LicenseNo"].ToString();
                pharmacy.AddressLine1 = dt.Rows[0]["AddressLine1"].ToString();
                pharmacy.AddressLine2 = dt.Rows[0]["AddressLine2"].ToString();
                pharmacy.SuburbID = int.Parse(dt.Rows[0]["SuburbID"].ToString());
                pharmacy.PostalCode = dt.Rows[0]["PostalCode"].ToString();
                city = data.GetSuburbById(int.Parse(pharmacy.SuburbID.ToString()));
                pharmacy.CityId = int.Parse(city.Rows[0]["CityID"].ToString());
                province = data.GetCityById(int.Parse(pharmacy.CityId.ToString()));
                pharmacy.ProvinceId = int.Parse(province.Rows[0]["ProvinceID"].ToString());

                city.Clear();
                suburb.Clear();
                city = data.GetCityByCityId(pharmacy.CityId);
                suburb = data.GetSuburbBySuburbId(int.Parse(dt.Rows[0]["SuburbID"].ToString()));

                ViewBag.City = new SelectList(city.AsEnumerable(), "CityID", "CityName");

                ViewBag.Suburb= new SelectList(suburb.AsEnumerable(), "SubrbID", "SuburbName");


            }

            ViewBag.City = new SelectList(city.AsEnumerable(), "CityID", "CityName");

            ViewBag.Suburb = new SelectList(suburb.AsEnumerable(), "SubrbID", "SuburbName");

            return View(pharmacy);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            data = new DataAccess(configuration);

            //Get provinces
            DataTable dt = new DataTable();

            int x= data.DeletePharmacy(id);

            TempData["PharmacyDelete"] = $"Pharmacy successfully removed";

            return RedirectToAction("List", "PharmacyRecords");
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

                dt.Clear();


                dt = data.GetPhamacists();

                List<PharmacistAccount> pharmacists = new List<PharmacistAccount>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PharmacistAccount pharmacist = new PharmacistAccount();
                    pharmacist.PharmacistId = Convert.ToInt32(dt.Rows[i]["PharmacistID"]);
                    pharmacist.FirstName = dt.Rows[i]["NAMES"].ToString();

                    pharmacists.Add(pharmacist);
                }

                ViewBag.Pharmacists = new SelectList(pharmacists.ToList(), "PharmacistId", "FirstName");


                return View(pharmacy);
            }
        }

        [HttpPost]
        public IActionResult Edit(PharmacyRecordsVM pharmacyRecords)
        {
            if(ModelState.IsValid)
            {
                data = new DataAccess(configuration);
                data.UpdatePharmacy(pharmacyRecords);
                TempData["PharmacyEdit"] = $"Successfully updated pharmacy records.";
                return RedirectToAction("List", "PharmacyRecords");
            }
            else
            {
                data = new DataAccess(configuration);


                //Get provinces
                DataTable dt = new DataTable();
                DataTable city = new DataTable();
                DataTable suburb = new DataTable();
                DataTable province = new DataTable();
                DataTable getProv = new DataTable();

                getProv = data.GetProvinces();

                List<ProvinceModel> provinces = new List<ProvinceModel>();

                for (int i = 0; i < getProv.Rows.Count; i++)
                {
                    ProvinceModel prov = new ProvinceModel();
                    prov.ProvinceID = Convert.ToInt32(getProv.Rows[i]["ProvinceID"]);
                    prov.ProvinceName = getProv.Rows[i]["ProvinceName"].ToString();

                    provinces.Add(prov);
                }
                var getProvinces = provinces.ToList();
                ViewBag.Provinces = new SelectList(getProvinces, "ProvinceID", "ProvinceName");

                dt.Clear();


                dt = data.GetPhamacists();

                List<PharmacistAccount> pharmacists = new List<PharmacistAccount>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PharmacistAccount pharmacist = new PharmacistAccount();
                    pharmacist.PharmacistId = Convert.ToInt32(dt.Rows[i]["PharmacistID"]);
                    pharmacist.FirstName = dt.Rows[i]["NAMES"].ToString();

                    pharmacists.Add(pharmacist);
                }

                ViewBag.Pharmacists = new SelectList(pharmacists.ToList(), "PharmacistId", "FirstName");
                dt.Clear();

                
               

                return View(pharmacyRecords);
            }
        }
    }
}
