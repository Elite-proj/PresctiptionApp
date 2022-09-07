using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_prescription.Services;
using E_prescription.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace E_prescription.Controllers
{
    public class MedicalPracticeRecController : Controller
    {
        private readonly IMedicalPracticeRecService _medicalPracticeRecService;

        public MedicalPracticeRecController(IMedicalPracticeRecService medicalPracticeRecService)
        {
            _medicalPracticeRecService = medicalPracticeRecService;
        }

        public IActionResult MedicalPracticeRecs()
        {
            var medicalPracticeRec = _medicalPracticeRecService.List();
            return View(medicalPracticeRec);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new MedicalPractice());
        }

        [HttpPost]
        public IActionResult Add(MedicalPractice medicalPractiseRec)
        {
            var isSuccess = _medicalPracticeRecService.Add(medicalPractiseRec);

            if (isSuccess)
                return Redirect("MedicalPracticeRecs");

            return View(medicalPractiseRec);
        }

        [HttpGet]
        public IActionResult UpdateMedicalPracticeRec(int MedicalPracticeId)
        {
            var medicalPracticeRec = _medicalPracticeRecService.GetMedicalPractice(MedicalPracticeId);
            return View();
        }

        [HttpPost]
        public IActionResult UpdateCenter(MedicalPractice medicalpractice)
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

    }
}
