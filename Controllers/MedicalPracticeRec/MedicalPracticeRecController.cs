using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_prescription.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using E_prescription.Services.MedicalPracticeRec;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Mvc.Formatters;
using E_prescription.Services;

namespace E_prescription.Controllers
{
    public class MedicalPracticeRecController : Controller
    {
        private readonly IMedicalPracticeRecService _medicalPracticeRecService;

        private readonly GRP42EPrescriptionContext _context = new GRP42EPrescriptionContext();

        private readonly IConfiguration configuration;
        DataAccess data;
        DataTable dt;

        //public MedicalPracticeRecController(IConfiguration config)
        //{
        //    this.configuration = config;
        //}

        public MedicalPracticeRecController(IMedicalPracticeRecService medicalPracticeRecService, IConfiguration config)
        {
            _medicalPracticeRecService = medicalPracticeRecService;
            this.configuration = config;
        }

        public IActionResult MedicalPracticeRecs()
        {
            data = new DataAccess(configuration);
            dt = new DataTable();
            dt = data.GetMedicalPractices();

            List<MedicalPractice> medicalPractices = new List<MedicalPractice>();
            if(dt.Rows.Count>0)
            {
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    MedicalPractice medicalPractice = new MedicalPractice();

                    medicalPractice.MedicalPracticeId = int.Parse(dt.Rows[i]["MedicalPracticeID"].ToString());
                    medicalPractice.PracticeName = dt.Rows[i]["PracticeName"].ToString();
                    medicalPractice.AddressLine1= dt.Rows[i]["AddressLine1"].ToString();
                    medicalPractice.AddressLine2 = dt.Rows[i]["AddressLine2"].ToString();
                    medicalPractice.PracticeEmail = dt.Rows[i]["PracticeEmail"].ToString();
                    medicalPractice.PracticeContactNo = dt.Rows[i]["PracticeContactNo"].ToString();
                    medicalPractice.PracticeNo= dt.Rows[i]["PracticeNo"].ToString();

                    medicalPractices.Add(medicalPractice);
                }

                
            }
            ViewBag.Practices = medicalPractices.ToList();
            //var medicalPracticeRecs = _medicalPracticeRecService.List();
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            var provinces = _medicalPracticeRecService.GetProvinceList();

            ViewBag.Provinces = new SelectList(provinces, "ProvinceId", "ProvinceName");


            return View();
        }


        [HttpPost]
        public IActionResult Add(MedicalPractice medicalPracticeRec)
        {
            if(ModelState.IsValid)
            {
                data = new DataAccess(configuration);

                data.AddMedicalPractice(medicalPracticeRec);

                return RedirectToAction("MedicalPracticeRecs", "MedicalPracticeRec");
            }
            else
            {
                var provinces = _medicalPracticeRecService.GetProvinceList();

                ViewBag.Provinces = new SelectList(provinces, "ProvinceId", "ProvinceName");
                return View(medicalPracticeRec);
            }
            
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            data = new DataAccess(configuration);
            dt = new DataTable();
            dt = data.GetMedicalPracticeById(id);

            MedicalPractice medicalPractice = new MedicalPractice();
            if (dt.Rows.Count > 0)
            {
                

                medicalPractice.MedicalPracticeId = int.Parse(dt.Rows[0]["MedicalPracticeID"].ToString());
                medicalPractice.PracticeName = dt.Rows[0]["PracticeName"].ToString();
                medicalPractice.AddressLine1 = dt.Rows[0]["AddressLine1"].ToString();
                medicalPractice.AddressLine2 = dt.Rows[0]["AddressLine2"].ToString();
                medicalPractice.PracticeEmail = dt.Rows[0]["PracticeEmail"].ToString();
                medicalPractice.PracticeContactNo = dt.Rows[0]["PracticeContactNo"].ToString();
                medicalPractice.PracticeNo = dt.Rows[0]["PracticeNo"].ToString();

            }
            dt.Clear();

            var provinces = _medicalPracticeRecService.GetProvinceList();

            ViewBag.Provinces = new SelectList(provinces, "ProvinceId", "ProvinceName");

            return View(medicalPractice);
        }

        [HttpPost]
        public IActionResult Update(MedicalPractice medicalpractice)
        {
            if(ModelState.IsValid)
            {
                data = new DataAccess(configuration);
                data.UpdateMedicalPractice(medicalpractice);

                TempData["PracticeEdit"] = $"Successfully updated medical practice records.";
                return RedirectToAction("MedicalPracticeRecs", "MedicalPracticeRec");
            }
            else
            {
                var provinces = _medicalPracticeRecService.GetProvinceList();

                ViewBag.Provinces = new SelectList(provinces, "ProvinceId", "ProvinceName");

                return View(medicalpractice);
            }
        }

        [HttpDelete]
        public IActionResult DeleteMedicalPracticeRec(int id)
        {
            try
            {
                var result = _medicalPracticeRecService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
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

            list.Add(new SelectListItem { Text = "-- Select City --", Value = "0" });
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

    }
}
