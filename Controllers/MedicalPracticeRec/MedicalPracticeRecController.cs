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

namespace E_prescription.Controllers
{
    public class MedicalPracticeRecController : Controller
    {
        private readonly IMedicalPracticeRecService _medicalPracticeRecService;
        //private readonly IConfiguration configuration;
        //DataAccess data;

        public MedicalPracticeRecController(IMedicalPracticeRecService medicalPracticeRecService)
        {
            _medicalPracticeRecService = medicalPracticeRecService;
        }
        //public MedicalPracticeRecController(IConfiguration config)
        //{
        //    this.configuration = config;
        //}

        public IActionResult MedicalPracticeRecs()
        {
            var medicalPracticeRecs = _medicalPracticeRecService.List();
            return View(medicalPracticeRecs);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new MedicalPracticeRecModel());
        }

        //[HttpGet]

        //public IActionResult  GetAllProvinces(int ProvinceID)
        //{
        //    DataTable dt = new DataTable();
        //    dt = data.GetProvinces();

        //    List<ProvinceModel> provinces = new List<ProvinceModel>();

        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        ProvinceModel province = new ProvinceModel();
        //        province.ProvinceID = Convert.ToInt32(dt.Rows[i]["ProvinceID"]);
        //        province.ProvinceName = dt.Rows[i]["ProvinceName"].ToString();

        //        provinces.Add(province);
        //    }
        //    var getProvinces = provinces.ToList();
        //    ViewBag.Provinces = new SelectList(getProvinces, "ProvinceID", "ProvinceName");

        //    return View(ViewBag);
        //}

        [HttpPost]
        public IActionResult Add(MedicalPracticeRecModel medicalPracticeRec)
        {
            var isSuccess = _medicalPracticeRecService.Add(medicalPracticeRec);

            if (isSuccess)
                return Redirect("MedicalPracticeRecs");

            return View(medicalPracticeRec);
        }

        [HttpGet]
        public IActionResult UpdateMedicalPracticeRec(int MedicalPracticeId)
        {
            var medicalPracticeRec = _medicalPracticeRecService.GetMedicalPractice(MedicalPracticeId);
            return View();
        }

        [HttpPost]
        public IActionResult Update(MedicalPracticeRecModel medicalpractice)
        {
            var isSuccess = _medicalPracticeRecService.Update(medicalpractice);

            if (isSuccess)
                return Redirect("MedicalPracticeRec");

            return View(medicalpractice);
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

        //[HttpGet]
        //public JsonResult LoadCities(int id)
        //{
        //    data = new DataAccess(configuration);

        //    //Get Cities
        //    DataTable dtCities = new DataTable();
        //    CityModel city = new CityModel();
        //    city.ProvinceID = id;

        //    dtCities = data.GetCities(city);


        //    List<SelectListItem> list = new List<SelectListItem>();

        //    for (int i = 0; i < dtCities.Rows.Count; i++)
        //    {
        //        list.Add(new SelectListItem { Text = dtCities.Rows[i]["CityName"].ToString(), Value = Convert.ToInt32(dtCities.Rows[i]["CityID"]).ToString() });
        //    }

        //    return Json(list);
        //}
        //[HttpGet]
        //public JsonResult LoadSuburbs(int id)
        //{
        //    data = new DataAccess(configuration);

        //    //Get Cities
        //    DataTable dtSuburbs = new DataTable();
        //    SuburbModel suburb = new SuburbModel();
        //    suburb.CityID = id;

        //    dtSuburbs = data.GetSuburbs(suburb);

        //    List<SelectListItem> list = new List<SelectListItem>();

        //    for (int i = 0; i < dtSuburbs.Rows.Count; i++)
        //    {
        //        list.Add(new SelectListItem { Text = dtSuburbs.Rows[i]["SuburbName"].ToString(), Value = Convert.ToInt32(dtSuburbs.Rows[i]["SuburbID"]).ToString() });
        //    }

        //    return Json(list);
        //}

    }
}
