using E_prescription.Models;
using E_prescription.Services.DoctorRec;
using E_prescription.Services.MedicalPracticeRec;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Controllers.DoctorRec
{
    public class DoctorController : Controller
    {
        private readonly IDoctorRecService _doctorService;

        public DoctorController(IDoctorRecService doctorService)
        {
            _doctorService = doctorService;
        }

        public IActionResult Doctors()
        {
            var doctor = _doctorService.List();

            return View(doctor);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new DoctorModel());
        }

        [HttpPost]
        public IActionResult Add(DoctorModel doctor)
        {
            var isSuccess = _doctorService.Add(doctor);

            if (isSuccess)
                return Redirect("Doctors");

            return View(doctor);
        }

        [HttpGet]
        public IActionResult UpdateDoctor(int DoctorId)
        {
            var model = _doctorService.GetDoctor(DoctorId);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(DoctorModel doctor)
        {
            var isSuccess = _doctorService.Update(doctor);

            if (isSuccess)
                return Redirect("Doctors");

            return View(doctor);
        }

        [HttpDelete]
        public IActionResult DeleteDoctor(int id)
        {
            try
            {
                var result = _doctorService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

