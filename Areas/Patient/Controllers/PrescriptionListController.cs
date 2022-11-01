using E_prescription.Areas.Patient.Models;
using E_prescription.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace E_prescription.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class PrescriptionListController : Controller
    {

        private readonly IConfiguration configuration;
        DataAccess data;
        DataTable dt;

        public PrescriptionListController(IConfiguration config)
        {
            this.configuration = config;
        }
        public IActionResult Display()
        {
            data = new DataAccess(configuration);
            dt = new DataTable();

            dt = data.GetPatientPrescriptions(4);

            List<PatientPrescriptionDetailsModel> patientPrescriptionDetails = new List<PatientPrescriptionDetailsModel>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PatientPrescriptionDetailsModel patientPrescriptionDetail = new PatientPrescriptionDetailsModel();

                patientPrescriptionDetail.PatientId = int.Parse(dt.Rows[i]["PatientID"].ToString());
                patientPrescriptionDetail.Idnumber = dt.Rows[i]["Idnumber"].ToString();
                patientPrescriptionDetail.Date = dt.Rows[i]["Date"].ToString();
                patientPrescriptionDetail.DoctorId = int.Parse(dt.Rows[i]["DoctorId"].ToString());
                patientPrescriptionDetail.DoctorName = dt.Rows[i]["DoctorName"].ToString();


                patientPrescriptionDetails.Add(patientPrescriptionDetail);
            }

            ViewBag.Patients = patientPrescriptionDetails.ToList();
            dt.Clear();
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            data = new DataAccess(configuration);
            dt = new DataTable();

            dt = data.GetPrescriptionDetails(id);

            List<PatientPrescriptionDetailsModel> patientPrescriptionDetails = new List<PatientPrescriptionDetailsModel>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PatientPrescriptionDetailsModel patientPrescriptionDetail = new PatientPrescriptionDetailsModel();
                patientPrescriptionDetail.PatientId = int.Parse(dt.Rows[i]["PatientID"].ToString());
                patientPrescriptionDetail.Idnumber = dt.Rows[i]["Idnumber"].ToString();
                patientPrescriptionDetail.Date = dt.Rows[i]["Date"].ToString();
                patientPrescriptionDetail.DoctorId = int.Parse(dt.Rows[i]["DoctorId"].ToString());
                patientPrescriptionDetail.DoctorName = dt.Rows[i]["DoctorName"].ToString();

                patientPrescriptionDetails.Add(patientPrescriptionDetail);
            }
            dt.Clear();
            ViewBag.Details = patientPrescriptionDetails.ToList();


            return View();
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
