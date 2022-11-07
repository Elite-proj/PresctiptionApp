using E_prescription.Areas.Pharmacist.Models;
using E_prescription.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Areas.Pharmacist.Controllers
{
    [Area("Pharmacist")]
    public class HistoryController : Controller
    {
        private readonly IConfiguration configuration;
        DataAccess data;
        DataTable dt;

        public HistoryController(IConfiguration config)
        {
            this.configuration = config;
        }

        [HttpGet]
        public IActionResult Display(int id)
        {
            data = new DataAccess(configuration);
            dt = new DataTable();

            dt = data.GetDispensedPrescriptions(id);

            List<PatientPrescriptionVM> patientPrescriptions = new List<PatientPrescriptionVM>();

            for(int i=0;i<dt.Rows.Count;i++)
            {
                PatientPrescriptionVM patientPrescription = new PatientPrescriptionVM();
                patientPrescription.PrescriptionID = int.Parse(dt.Rows[i]["PrescriptionID"].ToString());
                patientPrescription.ConditionDescription = dt.Rows[i]["ConditionDecription"].ToString();
                patientPrescription.Date = dt.Rows[i]["Date"].ToString();
                patientPrescription.PharmacistName = dt.Rows[i]["Name"].ToString();
                patientPrescription.PharmacistSurname = dt.Rows[i]["Surname"].ToString();
                patientPrescription.DispensedMedicationID = int.Parse(dt.Rows[i]["DispensedMedicationID"].ToString());


                patientPrescriptions.Add(patientPrescription);
            }
            ViewBag.Prescriptions = patientPrescriptions.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            data = new DataAccess(configuration);
            dt = new DataTable();

            dt = data.GetDispensedMedication(id);

            List<DispensedMedsVM> medsVMs = new List<DispensedMedsVM>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DispensedMedsVM medsVM = new DispensedMedsVM();
                medsVM.MedicationID = int.Parse(dt.Rows[i]["PrescriptionID"].ToString());
                //medsVM.DosageID = int.Parse(dt.Rows[i]["DosageID"].ToString());
                medsVM.Quantity = int.Parse(dt.Rows[i]["Quantity"].ToString());
                medsVM.MedicationName = dt.Rows[i]["MedicationName"].ToString();
                medsVM.DosageDescription = dt.Rows[i]["DosageDescription"].ToString();
                medsVM.Date = dt.Rows[i]["Date"].ToString();
                medsVM.PharmacistName = dt.Rows[i]["Name"].ToString();
                medsVM.PharmacistSurname= dt.Rows[i]["Surname"].ToString();

                medsVMs.Add(medsVM);
            }

            ViewBag.DispensedMeds = medsVMs.ToList();

            return View();
        }
    }
}
