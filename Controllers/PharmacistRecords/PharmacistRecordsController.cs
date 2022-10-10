using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using E_prescription.Models.Account;
using E_prescription.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_prescription.Controllers.PharmacistRecords
{
    public class PharmacistRecordsController : Controller
    {
        private readonly IConfiguration configuration;
        DataAccess data;

        public PharmacistRecordsController(IConfiguration config)
        {
            this.configuration = config;
        }

        [HttpGet]
        public IActionResult Add()
        {
            data = new DataAccess(configuration);

            //Get provinces
            DataTable dt = new DataTable();
            DataTable pharmacistsDt = new DataTable();

            pharmacistsDt = data.GetPharmacyRecords();
            List<PharmacyRecordsVM> pharmacies = new List<PharmacyRecordsVM>();

            for(int j=0;j<pharmacistsDt.Rows.Count;j++)
            {
                PharmacyRecordsVM pharmacy = new PharmacyRecordsVM();

                pharmacy.PharmacyId= int.Parse(pharmacistsDt.Rows[j]["PharmacyID"].ToString());
                pharmacy.PharmacyName = pharmacistsDt.Rows[j]["PharmacyName"].ToString();

                pharmacies.Add(pharmacy);
            }

            
            var getPharmacies= pharmacies.ToList();
            ViewBag.Pharmacies = new SelectList(getPharmacies, "PharmacyId", "PharmacyName");

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

            return View();
        }
        [HttpGet]
        public IActionResult List()
        {
            data = new DataAccess(configuration);
            DataTable dt = new DataTable();

            dt = data.GetPhamacists();

            List<PharmacistAccount> pharmacists = new List<PharmacistAccount>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PharmacistAccount pharmacist = new PharmacistAccount();
                pharmacist.PharmacistId = Convert.ToInt32(dt.Rows[i]["PharmacistID"]);
                pharmacist.FirstName = dt.Rows[i]["Name"].ToString();
                pharmacist.Surname = dt.Rows[i]["Surname"].ToString();
                pharmacist.Email = dt.Rows[i]["Email"].ToString();
                pharmacist.ContactNo = int.Parse(dt.Rows[i]["ContactNo"].ToString());
                pharmacist.AddressLine1 = dt.Rows[i]["AddressLine1"].ToString();
                pharmacist.AddressLine2 = dt.Rows[i]["AddressLine2"].ToString();
                pharmacist.SuburbID = int.Parse(dt.Rows[i]["SuburbID"].ToString());
                pharmacist.RegNumber = int.Parse(dt.Rows[i]["RegNumber"].ToString());
                pharmacist.PharmacyID = int.Parse(dt.Rows[i]["PharmacyID"].ToString());

                pharmacists.Add(pharmacist);
            }
            ViewBag.Pharmacists = pharmacists.ToList();

            return View();

        }

        public IActionResult Edit(int id)
        {
            data = new DataAccess(configuration);


            //Get provinces
            DataTable dt = new DataTable();
            DataTable city = new DataTable();
            DataTable suburb = new DataTable();
            DataTable province = new DataTable();
            DataTable getProv = new DataTable();
            DataTable pharmacyDt = new DataTable();

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

            dt = data.GetPharmacistById(id);

            PharmacistAccount pharmacist = new PharmacistAccount();

            pharmacist.PharmacyID = Convert.ToInt32(dt.Rows[0]["PharmacistID"]);
            pharmacist.FirstName = dt.Rows[0]["Name"].ToString();
            pharmacist.Surname = dt.Rows[0]["Surname"].ToString();
            pharmacist.Email = dt.Rows[0]["Email"].ToString();
            pharmacist.ContactNo = int.Parse(dt.Rows[0]["ContactNo"].ToString());
            pharmacist.AddressLine1 = dt.Rows[0]["AddressLine1"].ToString();
            pharmacist.AddressLine2 = dt.Rows[0]["AddressLine2"].ToString();
            pharmacist.SuburbID = int.Parse(dt.Rows[0]["SuburbID"].ToString());
            city = data.GetSuburbById(int.Parse(pharmacist.SuburbID.ToString()));
            pharmacist.CityID = int.Parse(city.Rows[0]["CityID"].ToString());
            province = data.GetCityById(int.Parse(pharmacist.CityID.ToString()));
            pharmacist.ProvinceID = int.Parse(province.Rows[0]["ProvinceID"].ToString());
            pharmacist.RegNumber = int.Parse(dt.Rows[0]["RegNumber"].ToString());
            pharmacist.PharmacyID = int.Parse(dt.Rows[0]["PharmacyID"].ToString());

            LoadSuburbs(pharmacist.CityID);
            //Get pharmacy By ID
            pharmacyDt = data.GetPharmacyById(int.Parse(pharmacist.PharmacyID.ToString()));

            List<PharmacyRecordsVM> pharmacies = new List<PharmacyRecordsVM>();

            for(int j = 0; j < pharmacyDt.Rows.Count; j++)
            {
                PharmacyRecordsVM pharmacy = new PharmacyRecordsVM();

                pharmacy.PharmacyId= int.Parse(pharmacyDt.Rows[j]["PharmacyID"].ToString());
                pharmacy.PharmacyName = pharmacyDt.Rows[j]["PharmacyName"].ToString();

                pharmacies.Add(pharmacy);
            }

            ViewBag.Pharmacies = new SelectList(pharmacies.ToList(), "PharmacyId", "PharmacyName");
            return View(pharmacist);
        }
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


        [HttpPost]
        public IActionResult Add(PharmacistAccount pharmacist)
        {
            if(ModelState.IsValid)
            {
                data = new DataAccess(configuration);

                data.RegisterPharmacist(pharmacist);

                return RedirectToAction("List", "PharmacistRecords");
            }
            else
            {
                data = new DataAccess(configuration);

                //Get provinces
                DataTable dt = new DataTable();

                DataTable pharmacistsDt = new DataTable();

                pharmacistsDt = data.GetPharmacyRecords();
                List<PharmacyRecordsVM> pharmacies = new List<PharmacyRecordsVM>();

                for (int j = 0; j < pharmacistsDt.Rows.Count; j++)
                {
                    PharmacyRecordsVM pharmacy = new PharmacyRecordsVM();

                    pharmacy.PharmacyId = int.Parse(pharmacistsDt.Rows[j]["PharmacyID"].ToString());
                    pharmacy.PharmacyName = pharmacistsDt.Rows[j]["PharmacyName"].ToString();

                    pharmacies.Add(pharmacy);
                }


                var getPharmacies = pharmacies.ToList();
                ViewBag.Pharmacies = new SelectList(getPharmacies, "PharmacyId", "PharmacyName");


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

                return View(pharmacist);
            }
        }
    }
}
