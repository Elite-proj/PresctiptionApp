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

        public MedicalPracticeRecController(IMedicalPracticeRecService medicalPracticeRecService)
        {
            _medicalPracticeRecService = medicalPracticeRecService;
        }

        public IActionResult MedicalPracticeRecs()
        {
            var medicalPracticeRecs = _medicalPracticeRecService.List();
            return View(medicalPracticeRecs);
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
        public IActionResult Update(MedicalPractice medicalpractice)
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

        [HttpGet]
        public JsonResult LoadCities(int id)
        {

            List<SelectListItem> list = new List<SelectListItem>();
            List<City> Clist = new List<City>();
            Clist = _medicalPracticeRecService.GetCities(id);

            for (int i = 0; i < Clist.Count; i++)
            {
                list.Add(new SelectListItem { Text = Clist[i].CityName.ToString(), Value = Clist[i].CityId.ToString() });
            }

            return Json(list);
        }
        [HttpGet]
        public JsonResult LoadSuburbs(int id)
        {

            List<SelectListItem> list = new List<SelectListItem>();
            List<Suburb> Slist = new List<Suburb>();
            Slist = _medicalPracticeRecService.GetSuburbs(id);

            for (int i = 0; i < Slist.Count; i++)
            {
                list.Add(new SelectListItem { Text = Slist[i].SuburbName.ToString(), Value = Slist[i].SuburbId.ToString() });
            }

            return Json(list);
        }

    }
}
