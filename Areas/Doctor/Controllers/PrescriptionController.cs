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

namespace E_prescription.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class PrescriptionController : Controller
    {
        private readonly IConfiguration configuration;
        DataAccess data;
        DataTable dt;

        public PrescriptionController(IConfiguration config)
        {
            this.configuration = config;
        }

        public IActionResult PatientDiagnosis(int id)
        {
            data = new DataAccess(configuration);
            dt = new DataTable();

           
            //Get Medications
            dt = data.GetPatientDiagnosis(id);

            List<PatientCondition> patients = new List<PatientCondition>();
            if(dt.Rows.Count>0)
            {
                HttpContext.Session.SetInt32("PatientID", id);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PatientCondition patient = new PatientCondition();

                patient.ConditionID = int.Parse(dt.Rows[i]["ConditionID"].ToString());
                patient.PatientID = int.Parse(dt.Rows[i]["PatientID"].ToString());
                patient.DoctorID = int.Parse(dt.Rows[i]["DoctorID"].ToString());
                patient.ConditionName = dt.Rows[i]["ConditionDecription"].ToString();

                patients.Add(patient);
            }
            //dt.Clear();

            ViewBag.Conditions = patients.ToList();

            return View();
        }

        [HttpGet]
        public IActionResult Prescribe()
        {
            data = new DataAccess(configuration);
            dt = new DataTable();
            int id= Convert.ToInt32(HttpContext.Session.GetInt32("DoctorID"));
            dt = data.GetMaximumPrescription(id);

            PrescribeMedication prescribe = new PrescribeMedication();
            prescribe.PrescriptionID = int.Parse(dt.Rows[0]["PrescriptionID"].ToString());
           

            dt.Clear();

            dt = data.GetMedication();

            List<MedicationRecord> medications = new List<MedicationRecord>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MedicationRecord medication = new MedicationRecord();
                medication.MedicationId = int.Parse(dt.Rows[i]["MedicationID"].ToString());
                medication.MedicationName = dt.Rows[i]["MedicationName"].ToString();

                medications.Add(medication);
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

           // prescribe.RepeatID = 6;
            ViewBag.ContraError = prescribe;
            
            return View(prescribe);
        }

        [HttpGet]
        public IActionResult ListMedications(int id)
        {
            data = new DataAccess(configuration);
            dt = new DataTable();
            dt = data.GetPrescriptionMedications(id);

            List<MedicationListVm> medications = new List<MedicationListVm>();

            for(int i=0;i<dt.Rows.Count;i++)
            {
                MedicationListVm medication = new MedicationListVm();
                medication.MedicationID = int.Parse(dt.Rows[i]["MedicationID"].ToString());
                medication.DosageID = int.Parse(dt.Rows[i]["DosageID"].ToString());
                medication.MedicationName = dt.Rows[i]["MedicationName"].ToString();
                medication.DosageDescription = dt.Rows[i]["DosageDescription"].ToString();

                medications.Add(medication);
            }
            dt.Clear();
            ViewBag.Medications = medications.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Prescribe(PrescribeMedication prescribe)
        {
            int id = Convert.ToInt32(HttpContext.Session.GetInt32("ConditionID"));
            prescribe.ConditionID = id;

            data = new DataAccess(configuration);
            dt = new DataTable();

            if (prescribe.ContraIndicationID == null)
            {
                DataTable conditionDt = new DataTable();
                DataTable IngredientDt = new DataTable();
                IngredientDt = data.GetActiveIngredientsByMedicationID(prescribe);
                conditionDt = data.GetPatientDiagnosis(Convert.ToInt32(HttpContext.Session.GetInt32("PatientID")));

                for(int i=0;i<IngredientDt.Rows.Count;i++)
                {
                    for(int j=0;j<conditionDt.Rows.Count;j++)
                    {
                        int IngredientID = int.Parse(IngredientDt.Rows[i]["IngredientID"].ToString());
                        int ConditionID = int.Parse(conditionDt.Rows[j]["ConditionID"].ToString());

                        dt = data.CheckContraIndications(IngredientID,ConditionID);

                        if (dt.Rows.Count > 0)
                        {
                            ModelState.AddModelError("ContraIndication", "Contra indication found");
                            prescribe.ContraIndicationID = dt.Rows[0]["ContraIndicationID"].ToString();

                            //break;
                            //*********************************************
                            DataTable meds = new DataTable();
                            DataTable rep = new DataTable();
                            meds = data.GetMedication();

                            List<MedicationRecord> medications = new List<MedicationRecord>();

                            for (int k = 0; k < meds.Rows.Count; k++)
                            {
                                MedicationRecord medication = new MedicationRecord();
                                medication.MedicationId = int.Parse(meds.Rows[k]["MedicationID"].ToString());
                                medication.MedicationName = meds.Rows[k]["MedicationName"].ToString();

                                medications.Add(medication);
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

                            ViewBag.ContraError = prescribe;

                            return View(prescribe);
                        }
                    }
                }
                dt.Clear();
            }  
            

            if(prescribe.MedInteractionID==null)
            {
                DataTable patientDt = new DataTable();
                DataTable IngredientDt = new DataTable();

                IngredientDt = data.GetActiveIngredientsByMedicationID(prescribe);
                patientDt = data.GetMedicationsByPatientID(Convert.ToInt32(HttpContext.Session.GetInt32("PatientID")));

                for(int i=0;i<IngredientDt.Rows.Count;i++)
                {
                    for(int j=0;j<patientDt.Rows.Count;j++)
                    {
                        int Ingredient1 = int.Parse(IngredientDt.Rows[i]["IngredientID"].ToString());
                        int Ingredient2 = int.Parse(patientDt.Rows[j]["IngredientID"].ToString());

                        dt = data.CheckMedicationInteraction(Ingredient1, Ingredient2);

                        if(dt.Rows.Count>0)
                        {
                            ModelState.AddModelError("MedInteraction", "Medication Interaction found.");
                            ModelState.AddModelError("ContraIndication", "Contra indication found");
                            ModelState["ContraIndication"].Errors.Clear();
                            prescribe.MedInteractionID = dt.Rows[0]["MedInteractionID"].ToString();

                            //break;
                            //*******************************************
                            DataTable meds = new DataTable();
                            DataTable rep = new DataTable();
                            meds = data.GetMedication();

                            List<MedicationRecord> medications = new List<MedicationRecord>();

                            for (int k = 0; k < meds.Rows.Count; k++)
                            {
                                MedicationRecord medication = new MedicationRecord();
                                medication.MedicationId = int.Parse(meds.Rows[k]["MedicationID"].ToString());
                                medication.MedicationName = meds.Rows[k]["MedicationName"].ToString();

                                medications.Add(medication);
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

                            ViewBag.ContraError = prescribe;

                            return View(prescribe);
                        }
                    }
                }
                dt.Clear();
            }


            if(prescribe.AllergyID==null)
            {
                DataTable IngredientDt = new DataTable();
                DataTable Allergies = new DataTable();

                IngredientDt = data.GetActiveIngredientsByMedicationID(prescribe);
                //Allergies = data.GetPatientAllergies(4);

                for(int i=0;i<IngredientDt.Rows.Count;i++)
                {
                    int IngredientID = int.Parse(IngredientDt.Rows[i]["IngredientID"].ToString());
                    int PatientID = Convert.ToInt32(HttpContext.Session.GetInt32("PatientID"));
                    dt = data.CheckDrugAllergy(IngredientID,PatientID);

                    if(dt.Rows.Count>0)
                    {
                        ModelState.AddModelError("MedInteraction", "Medication Interaction found.");
                        ModelState.AddModelError("ContraIndication", "Contra indication found");
                        ModelState["ContraIndication"].Errors.Clear();
                        ModelState["MedInteraction"].Errors.Clear();

                        ModelState.AddModelError("Allergy", "Drug allergy found");

                        prescribe.AllergyID = dt.Rows[0]["AllergyID"].ToString();

                        //break;
                        //***********************************************************

                        DataTable meds = new DataTable();
                        DataTable rep = new DataTable();
                        meds = data.GetMedication();

                        List<MedicationRecord> medications = new List<MedicationRecord>();

                        for (int k = 0; k < meds.Rows.Count; k++)
                        {
                            MedicationRecord medication = new MedicationRecord();
                            medication.MedicationId = int.Parse(meds.Rows[k]["MedicationID"].ToString());
                            medication.MedicationName = meds.Rows[k]["MedicationName"].ToString();

                            medications.Add(medication);
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

                        ViewBag.ContraError = prescribe;

                        return View(prescribe);

                    }
                }
            }

            if (ModelState.IsValid)
            {
                prescribe.DoctorID = Convert.ToInt32(HttpContext.Session.GetInt32("DoctorID"));
                prescribe.PatientID = Convert.ToInt32(HttpContext.Session.GetInt32("PatientID"));

                data.AddMedicationPrescription(prescribe);
                return RedirectToAction("ListMedications", "Prescription", new { id=prescribe.PrescriptionID});
            }
            else
            {
                
                dt.Clear();

                dt = data.GetMedication();

                List<MedicationRecord> medications = new List<MedicationRecord>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MedicationRecord medication = new MedicationRecord();
                    medication.MedicationId = int.Parse(dt.Rows[i]["MedicationID"].ToString());
                    medication.MedicationName = dt.Rows[i]["MedicationName"].ToString();

                    medications.Add(medication);
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

                ViewBag.ContraError = prescribe;

                return View(prescribe);
            }

        }

        [HttpPost]
        public IActionResult Add(int id)
        {
            data = new DataAccess(configuration);
            PatientCondition patient = new PatientCondition();


            patient.ConditionID = id;

            HttpContext.Session.SetInt32("ConditionID", id);

            patient.DoctorID = Convert.ToInt32( HttpContext.Session.GetInt32("DoctorID"));
            patient.PatientID = Convert.ToInt32(HttpContext.Session.GetInt32("PatientID"));
            patient.Date = DateTime.Now;

            

            data.AddPrescription(patient);
            return RedirectToAction("Prescribe", "Prescription");

        }

        [HttpGet]
        public IActionResult PrescriptionList()
        {
            data = new DataAccess(configuration);
            int id = Convert.ToInt32(HttpContext.Session.GetInt32("PatientID"));
            dt = data.GetPatientPrescriptions(id);
            
            List<PatientPrescriptionVM> patientPrescriptions = new List<PatientPrescriptionVM>();

            for (int i = 0; i < dt.Rows.Count; i++)
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

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PatientPrescriptionVM patient = new PatientPrescriptionVM();
                patient.PrescriptionID = int.Parse(dt.Rows[i]["PrescriptionID"].ToString());
                patient.MedicationID = int.Parse(dt.Rows[i]["MedicationID"].ToString());
                patient.MedicationName = dt.Rows[i]["MedicationName"].ToString();
                patient.DosageDescription = dt.Rows[i]["DosageDescription"].ToString();
                patient.Quantity = dt.Rows[i]["Quantity"].ToString();
                patient.Instruction = dt.Rows[i]["Instruction"].ToString();
                patient.RepeatDescription = dt.Rows[i]["RepeatDescription"].ToString();
                patient.DespensedStatus = dt.Rows[i]["DispensedStatus"].ToString();
                patient.DoctorName = dt.Rows[i]["Name"].ToString();
                patient.DoctorSurname = dt.Rows[i]["Surname"].ToString();
                patient.Date = dt.Rows[i]["Date"].ToString();
                patient.DoctorID = int.Parse(dt.Rows[i]["UserID"].ToString());

                if (dt.Rows[i]["ContraIgnoreReason"]!=null)
                {
                    patient.ContraIndicationReason = dt.Rows[i]["ContraIgnoreReason"].ToString();
                }

                if (dt.Rows[i]["AllergyIgnoreReason"] != null)
                {
                    patient.AllergyRejection = dt.Rows[i]["AllergyIgnoreReason"].ToString();
                }

                if (dt.Rows[i]["WarningIgnoreReason"] != null)
                {
                    patient.MedInteractionReason = dt.Rows[i]["WarningIgnoreReason"].ToString();
                }



                patients.Add(patient);
            }
            dt.Clear();
            ViewBag.Details = patients.ToList();

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

                medsVMs.Add(medsVM);
            }

            ViewBag.DispensedMeds = medsVMs.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult UpdatePrescription(int prescription,int medication)
        {
            data = new DataAccess(configuration);
            dt = new DataTable();

            //DispenseMedication medication1 = new DispenseMedication();
            dt = data.GetMedicationToDispense(prescription, medication);


            UpdatePrescriptionVM medications = new UpdatePrescriptionVM();
            medications.MedicationID = int.Parse(dt.Rows[0]["MedicationID"].ToString());
            medications.PrescriptionID = int.Parse(dt.Rows[0]["PrescriptionID"].ToString());
            medications.Quantity = int.Parse(dt.Rows[0]["Quantity"].ToString());
            medications.MedicationName = dt.Rows[0]["MedicationName"].ToString();
            medications.Instruction = dt.Rows[0]["Instruction"].ToString();

           
            //ViewBag.ContraError = dispense;
            return View(medications);
        }

        [HttpPost]
        public IActionResult UpdatePrescription(UpdatePrescriptionVM prescribe)
        {
            if (ModelState.IsValid)
            {
                data = new DataAccess(configuration);

                data.UpdatePrescription(prescribe);

                return RedirectToAction("Details", "Prescription", new { area = "Doctor", id = prescribe.PrescriptionID });
            }
            else
            {
                return View(prescribe);
            }
        }


        [HttpPost]
        public IActionResult DeletePrescription(int prescrption,int medication)
        {
            data = new DataAccess(configuration);

            data.DeletePrescription(prescrption, medication);

            return RedirectToAction("Details", "Prescription", new { area = "Doctor", id = prescrption });
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchResults(SearchPrescriptionVM searchPrescription)
        {
            if (ModelState.IsValid)
            {
                data = new DataAccess(configuration);
                DataSet set = new DataSet();
                dt = new DataTable();

                searchPrescription.PatientID = Convert.ToInt32(HttpContext.Session.GetInt32("PatientID"));

                set = data.SearchPrescription(searchPrescription);

                List<PatientPrescriptionVM> patientPrescriptions = new List<PatientPrescriptionVM>();


                for (int i = 0; i < set.Tables.Count; i++)
                {
                    dt = set.Tables[i];
                    PatientPrescriptionVM patientPrescription = new PatientPrescriptionVM();
                    if (dt.Rows.Count > 0)
                    {
                        patientPrescription.DoctorName = dt.Rows[0]["Name"].ToString();
                        patientPrescription.DoctorSurname = dt.Rows[0]["Surname"].ToString();
                        patientPrescription.ConditionDescription = dt.Rows[0]["ConditionDecription"].ToString();
                        patientPrescription.Date = dt.Rows[0]["Date"].ToString();
                        patientPrescription.PrescriptionID = int.Parse(dt.Rows[0]["PrescriptionID"].ToString());

                        dt.Clear();
                        patientPrescriptions.Add(patientPrescription);
                    }

                }

                dt.Clear();
                ViewBag.Prescriptions = patientPrescriptions.ToList();
                set.Clear();

                if (ViewBag.Prescriptions.Count == 0)
                {
                    ModelState.AddModelError("", "No results found");
                    return View("Search", searchPrescription);
                }

                return View("SearchResults", new { area = "Pharmacist" });
            }
            else
            {

                return View("Search", searchPrescription);
            }
        }

        [HttpGet]
        public IActionResult SearchResults()
        {
            return View();
        }
    }
}
