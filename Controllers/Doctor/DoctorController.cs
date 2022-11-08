using E_prescription.Models;
using E_prescription.Models.Account;
using E_prescription.Services.DoctorRec;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IConfiguration configuration;
        DataAccess data;
        public DoctorController(IConfiguration config)
        {
            this.configuration = config;
        }

        public IActionResult Doctors()
        {
            data = new DataAccess(configuration);
            DataTable dt = new DataTable();

            dt = data.GetDoctors();

            List<DoctorAccount> doctors = new List<DoctorAccount>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DoctorAccount doctor = new DoctorAccount();
                doctor.DoctorID = Convert.ToInt32(dt.Rows[i]["DoctorID"]);
                doctor.FirstName = dt.Rows[i]["Name"].ToString();
                doctor.Surname = dt.Rows[i]["Surname"].ToString();
                doctor.Email = dt.Rows[i]["Email"].ToString();
                doctor.ContactNo = dt.Rows[i]["ContactNo"].ToString();
                doctor.AddressLine1 = dt.Rows[i]["AddressLine1"].ToString();
                doctor.AddressLine2 = dt.Rows[i]["AddressLine2"].ToString();
                doctor.SuburbID = int.Parse(dt.Rows[i]["SuburbID"].ToString());
                doctor.HCRN = dt.Rows[i]["HCRN"].ToString();

                doctors.Add(doctor);
            }
            ViewBag.Doctors = doctors.ToList();

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            data = new DataAccess(configuration);

            //Get provinces
            DataTable dt = new DataTable();
            List<ProvinceModel> provinces = new List<ProvinceModel>();
            dt = data.GetProvinces();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ProvinceModel province = new ProvinceModel();
                province.ProvinceID = Convert.ToInt32(dt.Rows[i]["ProvinceID"]);
                province.ProvinceName = dt.Rows[i]["ProvinceName"].ToString();

                provinces.Add(province);
            }
            var getProvinces = provinces.ToList();
            ViewBag.Provinces = new SelectList(getProvinces, "ProvinceID", "ProvinceName");

            DataTable PracDt = new DataTable();

            PracDt = data.GetMedicalPractice();
            List<MedicalPractice> medicalPractices = new List<MedicalPractice>();

            for (int i = 0; i < PracDt.Rows.Count; i++)
            {
                MedicalPractice medicalPractice = new MedicalPractice();
                medicalPractice.MedicalPracticeId = Convert.ToInt32(PracDt.Rows[i]["MedicalPracticeID"]);
                medicalPractice.PracticeName = PracDt.Rows[i]["PracticeName"].ToString();

                medicalPractices.Add(medicalPractice);
            }

            ViewBag.MedicalPractices = new SelectList(medicalPractices.ToList(), "MedicalPracticeId", "PracticeName");

            DataTable QuaDt = new DataTable();

            QuaDt = data.GetQualifications();
            List<HighestQualification> qualifications = new List<HighestQualification>();

            for (int j = 0; j < QuaDt.Rows.Count; j++)
            {
                HighestQualification qualification = new HighestQualification();

                qualification.QualificationId = int.Parse(QuaDt.Rows[j]["QualificationID"].ToString());
                qualification.QualificationName = QuaDt.Rows[j]["QualificationName"].ToString();

                qualifications.Add(qualification);
            }

            ViewBag.Qualifications = new SelectList(qualifications.ToList(), "QualificationId", "QualificationName");

            return View();
        }

        [HttpPost]
        public IActionResult Add(DoctorAccount doctor)
        {
            if (ModelState.IsValid)
            {
                data = new DataAccess(configuration);
                data.RegisterDoctor(doctor);

                return RedirectToAction("Doctors", "Doctor");
            }
            else
                return View(doctor);
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

        //[HttpGet]
        //public IActionResult UpdateDoctor(int DoctorId)
        //{
        //    var doctor = _doctorService.GetDoctor(DoctorId);
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Update(Doctor doctor)
        //{
        //    var isSuccess = _doctorService.Update(doctor);

        //    if (isSuccess)
        //        return Redirect("Doctor");

        //    return View(doctor);
        //}

        //[HttpDelete]
        //public IActionResult DeleteDoctor(int id)
        //{
        //    try
        //    {
        //        var result = _doctorService.Delete(id);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}

