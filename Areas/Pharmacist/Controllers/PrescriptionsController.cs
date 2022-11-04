using E_prescription.Areas.Doctor.Models;
using E_prescription.Areas.Pharmacist.Models;
using E_prescription.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Areas.Pharmacist.Controllers
{
    [Area("Pharmacist")]
    public class PrescriptionsController : Controller
    {
        private readonly IConfiguration configuration;
        DataAccess data;
        DataTable dt;

        public PrescriptionsController(IConfiguration config)
        {
            this.configuration = config;
        }

        public IActionResult Display(int id)
        {
            data = new DataAccess(configuration);
            dt = new DataTable();

            

            dt = data.GetPatientPrescriptions(id);
            if(dt.Rows.Count>0)
            {
                HttpContext.Session.SetInt32("PatientID", id);
            }
            List<PatientPrescriptionVM> patientPrescriptions = new List<PatientPrescriptionVM>();

            for(int i=0;i<dt.Rows.Count;i++)
            {
                PatientPrescriptionVM patientPrescription = new PatientPrescriptionVM();

                patientPrescription.PrescriptionID = int.Parse(dt.Rows[i]["PrescriptionID"].ToString());
                patientPrescription.ConditionDescription = dt.Rows[i]["ConditionDecription"].ToString();
                patientPrescription.Date = dt.Rows[i]["Date"].ToString();
                patientPrescription.DoctorName = dt.Rows[i]["Name"].ToString();
                patientPrescription.DoctorSurname = dt.Rows[i]["Surname"].ToString();

                patientPrescriptions.Add(patientPrescription);
            }

            ViewBag.Prescriptions = patientPrescriptions.ToList();
            dt.Clear();
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            data = new DataAccess(configuration);
            dt = new DataTable();

            dt = data.GetPrescriptionDetails(id);

            List<PatientPrescriptionVM> patients = new List<PatientPrescriptionVM>();

            for(int i=0;i<dt.Rows.Count;i++)
            {
                PatientPrescriptionVM patient = new PatientPrescriptionVM();
                patient.PrescriptionID = int.Parse(dt.Rows[i]["PrescriptionID"].ToString());
                patient.MedicationID = int.Parse(dt.Rows[i]["MedicationID"].ToString());
                patient.MedicationName = dt.Rows[i]["MedicationName"].ToString();
                patient.DosageDescription = dt.Rows[i]["DosageDescription"].ToString();
                patient.Quantity= dt.Rows[i]["Quantity"].ToString();
                patient.Instruction = dt.Rows[i]["Instruction"].ToString();
                patient.RepeatDescription = dt.Rows[i]["RepeatDescription"].ToString();
                patient.DespensedStatus= dt.Rows[i]["DispensedStatus"].ToString();
                patient.DoctorName= dt.Rows[i]["Name"].ToString();
                patient.DoctorSurname= dt.Rows[i]["Surname"].ToString();
                patient.Date= dt.Rows[i]["Date"].ToString();

                patients.Add(patient);
            }
            dt.Clear();
            ViewBag.Details = patients.ToList();

            dt = data.GetDispensedMedication(id);

            List<DispensedMedsVM> medsVMs = new List<DispensedMedsVM>();

            for(int i=0;i<dt.Rows.Count;i++)
            {
                DispensedMedsVM medsVM = new DispensedMedsVM();
                medsVM.MedicationID = int.Parse(dt.Rows[i]["PrescriptionID"].ToString());
                //medsVM.DosageID = int.Parse(dt.Rows[i]["DosageID"].ToString());
                medsVM.Quantity = int.Parse(dt.Rows[i]["Quantity"].ToString());
                medsVM.MedicationName = dt.Rows[i]["MedicationName"].ToString();
                medsVM.DosageDescription = dt.Rows[i]["DosageDescription"].ToString();
                medsVM.Date = dt.Rows[i]["Date"].ToString();

                medsVMs.Add(medsVM);
            }

            ViewBag.DispensedMeds = medsVMs.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Dispense(int prescription,int medication)
        {
            data = new DataAccess(configuration);
            dt = new DataTable();

            //DispenseMedication medication1 = new DispenseMedication();
            dt = data.GetMedicationToDispense(prescription, medication);
            

            DispenseMedication dispense = new DispenseMedication();
            dispense.MedicationID = int.Parse(dt.Rows[0]["MedicationID"].ToString());
            dispense.PrescriptionID = int.Parse(dt.Rows[0]["PrescriptionID"].ToString());
            dispense.Quantity = int.Parse(dt.Rows[0]["Quantity"].ToString());
            dispense.MedicationName = dt.Rows[0]["MedicationName"].ToString();
            dispense.RepeatID = dt.Rows[0]["RepeatID"].ToString();
            dispense.PatientID = int.Parse(dt.Rows[0]["PatientID"].ToString());

            ViewBag.ContraError = dispense;
            return View(dispense);
        }

        [HttpPost]
        public IActionResult Dispense(DispenseMedication medication)
        {
            data = new DataAccess(configuration);
            dt = new DataTable();

            if (medication.ContraIndicationID == 0)
            {
                DataTable conditionDt = new DataTable();
                DataTable IngredientDt = new DataTable();
                IngredientDt = data.GetActiveIngredientsByDispensedMed(medication);
                conditionDt = data.GetPatientDiagnosis(4);

                for (int i = 0; i < IngredientDt.Rows.Count; i++)
                {
                    for (int j = 0; j < conditionDt.Rows.Count; j++)
                    {
                        int IngredientID = int.Parse(IngredientDt.Rows[i]["IngredientID"].ToString());
                        int ConditionID = int.Parse(conditionDt.Rows[j]["ConditionID"].ToString());

                        dt = data.CheckContraIndications(IngredientID, ConditionID);

                        if (dt.Rows.Count > 0)
                        {
                            ModelState.AddModelError("ContraIndication", "Contra indication found");
                            medication.ContraIndicationID = int.Parse(dt.Rows[0]["ContraIndicationID"].ToString());

                            //break;
                            //*********************************************
                            DataTable meds = new DataTable();
                            DataTable rep = new DataTable();
                            meds = data.GetMedication();

                            List<MedicationRecord> medications = new List<MedicationRecord>();

                            for (int k = 0; k < meds.Rows.Count; k++)
                            {
                                MedicationRecord medication1 = new MedicationRecord();
                                medication1.MedicationId = int.Parse(meds.Rows[k]["MedicationID"].ToString());
                                medication1.MedicationName = meds.Rows[k]["MedicationName"].ToString();

                                medications.Add(medication1);
                            }
                            dt.Clear();
                            ViewBag.Medications = new SelectList(medications.ToList(), "MedicationId", "MedicationName");

                            rep = data.GetReapet();

                            List<Repeat> repeats = new List<Repeat>();

                            for (int l = 0; l < rep.Rows.Count; l++)
                            {
                                Repeat repeat = new Repeat();
                                repeat.RepeatId = int.Parse(rep.Rows[l]["RepeatID"].ToString());
                                repeat.RepeatDescription = rep.Rows[l]["RepeatDescription"].ToString();

                                repeats.Add(repeat);
                            }

                            ViewBag.Repeats = new SelectList(repeats.ToList(), "RepeatId", "RepeatDescription");

                            ViewBag.ContraError = medication;

                            return View(medication);
                        }
                    }
                }
                dt.Clear();
            }


            if (medication.MedInteractionID == 0)
            {
                DataTable patientDt = new DataTable();
                DataTable IngredientDt = new DataTable();

                IngredientDt = data.GetActiveIngredientsByDispensedMed(medication);
                patientDt = data.GetMedicationsByPatientID(4);

                for (int i = 0; i < IngredientDt.Rows.Count; i++)
                {
                    for (int j = 0; j < patientDt.Rows.Count; j++)
                    {
                        int Ingredient1 = int.Parse(IngredientDt.Rows[i]["IngredientID"].ToString());
                        int Ingredient2 = int.Parse(patientDt.Rows[j]["IngredientID"].ToString());

                        dt = data.CheckMedicationInteraction(Ingredient1, Ingredient2);

                        if (dt.Rows.Count > 0)
                        {
                            ModelState.AddModelError("MedInteraction", "Medication Interaction found.");
                            ModelState.AddModelError("ContraIndication", "Contra indication found");
                            ModelState["ContraIndication"].Errors.Clear();
                            medication.MedInteractionID = int.Parse(dt.Rows[0]["MedInteractionID"].ToString());

                            //break;
                            //*******************************************
                            DataTable meds = new DataTable();
                            DataTable rep = new DataTable();
                            meds = data.GetMedication();

                            List<MedicationRecord> medications = new List<MedicationRecord>();

                            for (int k = 0; k < meds.Rows.Count; k++)
                            {
                                MedicationRecord medication1 = new MedicationRecord();
                                medication1.MedicationId = int.Parse(meds.Rows[k]["MedicationID"].ToString());
                                medication1.MedicationName = meds.Rows[k]["MedicationName"].ToString();

                                medications.Add(medication1);
                            }
                            dt.Clear();
                            ViewBag.Medications = new SelectList(medications.ToList(), "MedicationId", "MedicationName");

                            rep = data.GetReapet();

                            List<Repeat> repeats = new List<Repeat>();

                            for (int l = 0; l < rep.Rows.Count; l++)
                            {
                                Repeat repeat = new Repeat();
                                repeat.RepeatId = int.Parse(rep.Rows[l]["RepeatID"].ToString());
                                repeat.RepeatDescription = rep.Rows[l]["RepeatDescription"].ToString();

                                repeats.Add(repeat);
                            }

                            ViewBag.Repeats = new SelectList(repeats.ToList(), "RepeatId", "RepeatDescription");

                            ViewBag.ContraError = medication;

                            return View(medication);
                        }
                    }
                }
                dt.Clear();
            }


            if (medication.AllergyID == 0)
            {
                DataTable IngredientDt = new DataTable();
                DataTable Allergies = new DataTable();

                IngredientDt = data.GetActiveIngredientsByDispensedMed(medication);
                //Allergies = data.GetPatientAllergies(4);

                for (int i = 0; i < IngredientDt.Rows.Count; i++)
                {
                    int IngredientID = int.Parse(IngredientDt.Rows[i]["IngredientID"].ToString());
                    int PatientID = 4;
                    dt = data.CheckDrugAllergy(IngredientID, PatientID);

                    if (dt.Rows.Count > 0)
                    {
                        ModelState.AddModelError("MedInteraction", "Medication Interaction found.");
                        ModelState.AddModelError("ContraIndication", "Contra indication found");
                        ModelState["ContraIndication"].Errors.Clear();
                        ModelState["MedInteraction"].Errors.Clear();

                        ModelState.AddModelError("Allergy", "Drug allergy found");

                        medication.AllergyID = int.Parse(dt.Rows[0]["AllergyID"].ToString());

                        //break;
                        //***********************************************************

                        DataTable meds = new DataTable();
                        DataTable rep = new DataTable();
                        meds = data.GetMedication();

                        List<MedicationRecord> medications = new List<MedicationRecord>();

                        for (int k = 0; k < meds.Rows.Count; k++)
                        {
                            MedicationRecord medication1 = new MedicationRecord();
                            medication1.MedicationId = int.Parse(meds.Rows[k]["MedicationID"].ToString());
                            medication1.MedicationName = meds.Rows[k]["MedicationName"].ToString();

                            medications.Add(medication1);
                        }
                        dt.Clear();
                        ViewBag.Medications = new SelectList(medications.ToList(), "MedicationId", "MedicationName");

                        rep = data.GetReapet();

                        List<Repeat> repeats = new List<Repeat>();

                        for (int l = 0; l < rep.Rows.Count; l++)
                        {
                            Repeat repeat = new Repeat();
                            repeat.RepeatId = int.Parse(rep.Rows[l]["RepeatID"].ToString());
                            repeat.RepeatDescription = rep.Rows[l]["RepeatDescription"].ToString();

                            repeats.Add(repeat);
                        }

                        ViewBag.Repeats = new SelectList(repeats.ToList(), "RepeatId", "RepeatDescription");

                        ViewBag.ContraError =medication;

                        return View(medication);

                    }
                }
            }

            if (ModelState.IsValid)
            {
                int? Repeat = int.Parse(medication.RepeatID);

                if(Repeat>=9)
                {
                    Repeat = Repeat-1;

                    medication.RepeatID = Repeat.ToString();
                }
                medication.PharmacistID = Convert.ToInt32(HttpContext.Session.GetInt32("PharmacistID"));
                medication.Date = DateTime.Now;
                data.DispenseMedication(medication);

                return RedirectToAction("Details", "Prescriptions", new { id = medication.PrescriptionID });
            }
            else
            {

                dt.Clear();

                dt = data.GetMedication();

                List<MedicationRecord> medications = new List<MedicationRecord>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MedicationRecord medication1 = new MedicationRecord();
                    medication1.MedicationId = int.Parse(dt.Rows[i]["MedicationID"].ToString());
                    medication1.MedicationName = dt.Rows[i]["MedicationName"].ToString();

                    medications.Add(medication1);
                }
                dt.Clear();
                ViewBag.Medications = new SelectList(medications.ToList(), "MedicationId", "MedicationName");

                dt = data.GetReapet();

                List<Repeat> repeats = new List<Repeat>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Repeat repeat = new Repeat();
                    repeat.RepeatId = int.Parse(dt.Rows[i]["RepeatID"].ToString());
                    repeat.RepeatDescription = dt.Rows[i]["RepeatDescription"].ToString();

                    repeats.Add(repeat);
                }
                dt.Clear();
                ViewBag.Repeats = new SelectList(repeats.ToList(), "RepeatId", "RepeatDescription");

                ViewBag.ContraError = medication;

                return View(medication);
            }
        }


        [HttpGet]
        public IActionResult RejectPrescription(int id)
        {   
            data = new DataAccess(configuration);
            dt = new DataTable();

            dt = data.GetPrescriptionById(id);
            RejectPrescriptionVM reject = new RejectPrescriptionVM();
            if (dt.Rows.Count > 0)
            {
                
                reject.DoctorName = dt.Rows[0]["Name"].ToString();
                reject.DoctorSurname = dt.Rows[0]["Surname"].ToString();
                reject.ConditionName = dt.Rows[0]["ConditionDecription"].ToString();
                reject.PrescriptionID = int.Parse(dt.Rows[0]["PrescriptionID"].ToString());


                return View(reject);
            }
            else
                return View();
            
        }

        [HttpGet]
        public IActionResult RejectPrescriptionItem(int prescription,int medication)
        {
            data = new DataAccess(configuration);
            dt = new DataTable();

            dt = data.GetPrescriptionItemById(medication);

            RejectPrescriptionItemVM item = new RejectPrescriptionItemVM();

            item.MedicationID = int.Parse(dt.Rows[0]["MedicationID"].ToString());
            item.MedicationName = dt.Rows[0]["MedicationName"].ToString();
            item.PrescriptionID = prescription;


            return View(item);
        }

        [HttpPost]
        public IActionResult RejectPrescriptionItem(RejectPrescriptionItemVM item)
        {
            if (ModelState.IsValid)
            {
                data = new DataAccess(configuration);
                item.PharmacistID = Convert.ToInt32(HttpContext.Session.GetInt32("PharmacistID"));
                data.RejectPrescriptionItems(item);

                return RedirectToAction("Details", "Prescriptions", new { area = "Pharmacist", id = item.PrescriptionID });
            }
            else
                return View(item);
        }


        [HttpPost]
        public IActionResult RejectPrescription(RejectPrescriptionVM reject)
        {
            if (ModelState.IsValid)
            {
                data = new DataAccess(configuration);
                reject.PharmacistID = Convert.ToInt32(HttpContext.Session.GetInt32("PharmacistID"));

                data.RejectEntirePrescription(reject);

                return RedirectToAction("Display", "Prescriptions", new { area = "Pharmacist", id = HttpContext.Session.GetInt32("PatientID") });
            }
            else
            {
                return View(reject);
            }
        }
    }
}
