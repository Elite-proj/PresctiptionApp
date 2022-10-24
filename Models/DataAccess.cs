using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using E_prescription.Models.Account;
using E_prescription.Areas.Pharmacist.Models;
using E_prescription.Areas.Doctor.Models;

namespace E_prescription.Models
{
    public class DataAccess
    {
        public readonly IConfiguration configuration;

        public DataAccess(IConfiguration config)
        {
            this.configuration = config;
        }

        SqlConnection dbconn;
        SqlCommand dbComm;
        SqlDataAdapter dbAdapter;
        DataTable dt;

        //User Registreation
        public int RegisterPatient(PatientAccount patient)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_RegisterPatient", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            patient.UserStatus = "Active";
            patient.UserType = "Patient";

            dbComm.Parameters.AddWithValue("@Name", patient.FirstName);
            dbComm.Parameters.AddWithValue("@Surname", patient.Surname);
            dbComm.Parameters.AddWithValue("@Password", patient.Password);
            dbComm.Parameters.AddWithValue("@Contacts", patient.ContactNo.ToString());
            dbComm.Parameters.AddWithValue("@Email", patient.Email);
            dbComm.Parameters.AddWithValue("@AddressLine1", patient.AddressLine1);
            dbComm.Parameters.AddWithValue("@AddressLine2", patient.AddressLine2);
            dbComm.Parameters.AddWithValue("@Usertype", patient.UserType);
            dbComm.Parameters.AddWithValue("@SuburbID", patient.SuburbID);
            dbComm.Parameters.AddWithValue("@UserStatus", patient.UserStatus);
            dbComm.Parameters.AddWithValue("@IdNumber", patient.IDnumber.ToString());
            dbComm.Parameters.AddWithValue("@DOB", patient.DateOfBith);

            int x = dbComm.ExecuteNonQuery();
            dbconn.Close();

            return x;

        }

        public int RegisterDoctor(DoctorAccount doctor)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_RegisterDoctor", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            doctor.UserStatus = "Active";
            doctor.UserType = "Doctor";

            dbComm.Parameters.AddWithValue("@Name", doctor.FirstName);
            dbComm.Parameters.AddWithValue("@Surname", doctor.Surname);
            dbComm.Parameters.AddWithValue("@Contacts", doctor.ContactNo.ToString());
            dbComm.Parameters.AddWithValue("@Email", doctor.Email);
            dbComm.Parameters.AddWithValue("@AddressLine1", doctor.AddressLine1);
            dbComm.Parameters.AddWithValue("@AddressLine2", doctor.AddressLine2);
            dbComm.Parameters.AddWithValue("@Usertype", doctor.UserType);
            dbComm.Parameters.AddWithValue("@SuburbID", doctor.SuburbID);
            dbComm.Parameters.AddWithValue("@UserStatus", doctor.UserStatus);
            dbComm.Parameters.AddWithValue("@HCRN", doctor.HCRN);
            dbComm.Parameters.AddWithValue("@QualificationID", doctor.QualificationID);
            dbComm.Parameters.AddWithValue("@MedicalPracticeID", doctor.MedicalPracticeID);

            int x = dbComm.ExecuteNonQuery();
            dbconn.Close();

            return x;
        }

        public int RegisterPharmacist(PharmacistAccount pharmacist)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_RegisterPharmacist", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            pharmacist.UserStatus = "Active";
            pharmacist.UserType = "Pharmacist";

            dbComm.Parameters.AddWithValue("@Name", pharmacist.FirstName);
            dbComm.Parameters.AddWithValue("@Surname", pharmacist.Surname);
           
            dbComm.Parameters.AddWithValue("@Contacts", pharmacist.ContactNo.ToString());
            dbComm.Parameters.AddWithValue("@Email", pharmacist.Email);
            dbComm.Parameters.AddWithValue("@AddressLine1", pharmacist.AddressLine1);
            dbComm.Parameters.AddWithValue("@AddressLine2", pharmacist.AddressLine2);
            dbComm.Parameters.AddWithValue("@Usertype", pharmacist.UserType);
            dbComm.Parameters.AddWithValue("@SuburbID", pharmacist.SuburbID);
            dbComm.Parameters.AddWithValue("@UserStatus", pharmacist.UserStatus);
            dbComm.Parameters.AddWithValue("@RegNumber", pharmacist.RegNumber.ToString());
            dbComm.Parameters.AddWithValue("@PharmacyID", pharmacist.PharmacyID);
           
            int x = dbComm.ExecuteNonQuery();
            dbconn.Close();

            return x;
        }

        public DataTable GetDoctors()
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetDoctor", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }
        //Get addresses

        public DataTable GetProvinces()
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetProvinces", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt; 
        }

        public DataTable GetCities(CityModel city)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetCities", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@ProvinceID", city.ProvinceID);

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;

        }

        public DataTable GetSuburbs(SuburbModel suburb)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetSuburbs", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@CityID",suburb.CityID);

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        //Get suburb by ID
        public DataTable GetSuburbById(int id)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetSuburbById", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Id", id);

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        // Get city by ID
        public DataTable GetCityById(int id)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetCityById", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Id", id);

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        //Get Province by ID
        public DataTable GetProvinceById(int id)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetProvinceById", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Id", id);

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }


        // Get Highest qualification, pharmacy and medical practice
        public DataTable GetQualifications()
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetQualifications", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        public DataTable GetMedicalPractice()
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetMedicalPractice", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }


        //Login
        public DataTable Login(LoginViewModel login)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_UserLogin", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Email", login.Email);
            dbComm.Parameters.AddWithValue("@Password", login.Password);

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        //Pharmacy records
        public int AddPharmacyRecords(PharmacyRecordsVM pharmacy)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_AddPharmacyRecords", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            pharmacy.Status = "Active";
            

            dbComm.Parameters.AddWithValue("@Name", pharmacy.PharmacyName);
            dbComm.Parameters.AddWithValue("@Contacts", pharmacy.PharmacyContactNo.ToString());
            dbComm.Parameters.AddWithValue("@Email", pharmacy.PharmacyEmail);
            dbComm.Parameters.AddWithValue("@LicenseNo", pharmacy.LicenseNo.ToString());
            dbComm.Parameters.AddWithValue("@Suburb", pharmacy.SuburbID);
            dbComm.Parameters.AddWithValue("@AddressLine1", pharmacy.AddressLine1);
            dbComm.Parameters.AddWithValue("@AddressLine2", pharmacy.AddressLine2);
            dbComm.Parameters.AddWithValue("@Status", pharmacy.Status);

            
            int x = dbComm.ExecuteNonQuery();
            dbconn.Close();

            return x;
        }

        public DataTable GetPharmacyRecords()
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetPharmacy", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        public DataTable GetPharmacyById(int id)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetPharmacyById", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Id", id);

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        public int DeletePharmacy(int id)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_DeletePharmacy", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Id", id);

            int x = dbComm.ExecuteNonQuery();
            dbconn.Close();

            return x;
        }

        public int UpdatePharmacy(PharmacyRecordsVM pharmacy)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_UpdatePharmacy", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;


            dbComm.Parameters.AddWithValue("@Name", pharmacy.PharmacyName);
            dbComm.Parameters.AddWithValue("@Contacts", pharmacy.PharmacyContactNo.ToString());
            dbComm.Parameters.AddWithValue("@Email", pharmacy.PharmacyEmail);
            dbComm.Parameters.AddWithValue("@LicenseNo", pharmacy.LicenseNo.ToString());
            dbComm.Parameters.AddWithValue("@Suburb", pharmacy.SuburbID);
            dbComm.Parameters.AddWithValue("@AddressLine1", pharmacy.AddressLine1);
            dbComm.Parameters.AddWithValue("@AddressLine2", pharmacy.AddressLine2);
            dbComm.Parameters.AddWithValue("@Id", pharmacy.PharmacyId);


            int x = dbComm.ExecuteNonQuery();
            dbconn.Close();

            return x;
        }

        //Medication records

        public int AddActiveIngredient(ActiveIngredientVM ingredient)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_AddActiveIngredients", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;
            ingredient.Status = "Active";

            dbComm.Parameters.AddWithValue("@Description", ingredient.IngredientDescription);
            dbComm.Parameters.AddWithValue("@StrengthID", ingredient.StrengthID);
            dbComm.Parameters.AddWithValue("@Status", ingredient.Status);


            int x = dbComm.ExecuteNonQuery();
            dbconn.Close();

            return x;
        }
        public int AddSchedule(ScheduleVM schedule)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_AddMedicationSchedule", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;
            schedule.Status = "Active";

            dbComm.Parameters.AddWithValue("@ScheduleDescription",schedule.ScheduleDescription);
            dbComm.Parameters.AddWithValue("@Status", schedule.Status);


            int x = dbComm.ExecuteNonQuery();
            dbconn.Close();

            return x;
        }
        public int AddStrength(StrengthVM strength)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_AddActiveIngredientStrength", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;
            strength.Status = "Active";

            dbComm.Parameters.AddWithValue("@Description",strength.description);
            dbComm.Parameters.AddWithValue("@Status",strength.Status);



            int x = dbComm.ExecuteNonQuery();
            dbconn.Close();

            return x;

        }

        public int AddMedication(MedicationVM medication)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_AddMedication", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;
            

            dbComm.Parameters.AddWithValue("@MedicationName",medication.MedicationName);
            dbComm.Parameters.AddWithValue("@ScheduleID",medication.ScheduleID);
            dbComm.Parameters.AddWithValue("@DosageID",medication.DosageID);


            int x = dbComm.ExecuteNonQuery();
            dbconn.Close();

            return x;
        }
        public int AddMedicationIngredient(MedicationDetails medication)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_AddMedicationIngredient", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;


            dbComm.Parameters.AddWithValue("@MedicationID", medication.MedicationID);
            dbComm.Parameters.AddWithValue("@IngredientID", medication.IngredientID);
            

            int x = dbComm.ExecuteNonQuery();
            dbconn.Close();

            return x;
        }

        public DataTable GetIngredients()
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetActiveIngredients", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        public DataTable GetMedicationIngredient()
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetMedicationIngredient", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        public DataTable GetSchedule()
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetMedicationSchedule", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        public DataTable GetStrength()
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetStrength", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        public DataTable GetMedicationByMaxId()
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetMedicationByID", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

           

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }
        public DataTable GetMedication()
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetMedications", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        public int AddDosageForm(DosageVM dosage)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_AddDosageForm", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;
            dosage.Status = "Active";

            dbComm.Parameters.AddWithValue("@DosageDescription", dosage.DosageDescription);
            dbComm.Parameters.AddWithValue("@Status",dosage.Status);



            int x = dbComm.ExecuteNonQuery();
            dbconn.Close();

            return x;

        }

        public DataTable GetDosageForm()
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetDosage", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        //Pharmacist Records

        public DataTable GetPhamacists()
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetPharmacists", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        public DataTable GetPharmacistById(int id)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetPharmacistById", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Id", id);

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        public DataTable GetPatientById(PatientDetailsVM patient)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetPatientByIdNumber", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@IDNumber", patient.IdNumber.ToString());

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }


        //Contra-indications Records

        public int AddContraIndication(ContraIndication indication)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_AddContraIndication", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;
           

            dbComm.Parameters.AddWithValue("@IngredientID", indication.IngredientId);
            dbComm.Parameters.AddWithValue("@ConditionID", indication.ConditionId);
            dbComm.Parameters.AddWithValue("@ContraIndicationName", indication.ContraIndicationName);



            int x = dbComm.ExecuteNonQuery();
            dbconn.Close();

            return x;
        }

        public DataTable GetContraIndication()
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetContraIndication", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        public DataTable GetConditionDiagnosis()
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetConditionDiagnosis", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }


        //Patient Records
        public int AddPatientMedication(HistoryViewModel model)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_AddChronicMedication", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@MedicationID", model.MedicationID);
            dbComm.Parameters.AddWithValue("@PatientID", model.PatientID);
            dbComm.Parameters.AddWithValue("@DoctorID", model.DoctorID);
            dbComm.Parameters.AddWithValue("@Date", model.date);

            int x = dbComm.ExecuteNonQuery();
            dbconn.Close();
            return x;

        }

        public int AddPatientAllergy(HistoryViewModel model)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_AddPatientAllergy", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@IngredientID", model.IngredientID);
            dbComm.Parameters.AddWithValue("@PatientID", model.PatientID);
            dbComm.Parameters.AddWithValue("@DoctorID", model.DoctorID);
            dbComm.Parameters.AddWithValue("@Date", model.date);

            int x = dbComm.ExecuteNonQuery();
            dbconn.Close();
            return x;

        }

        public int AddPatientCondition(HistoryViewModel model)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_AddChronicHistory", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@ConditionID", model.ConditionID);
            dbComm.Parameters.AddWithValue("@PatientID", model.PatientID);
            dbComm.Parameters.AddWithValue("@DoctorID", model.DoctorID);
            dbComm.Parameters.AddWithValue("@Date", model.date);

            int x = dbComm.ExecuteNonQuery();
            dbconn.Close();
            return x;

        }

        //Get Patient diagnosis

        public DataTable GetPatientDiagnosis(int id)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetPatientDiagnosis", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;
            dbComm.Parameters.AddWithValue("@PatientID", id);

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        public int AddPrescription(PatientCondition model)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_AddPrescription", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@CondtionID", model.ConditionID);
            dbComm.Parameters.AddWithValue("@PatientID", model.PatientID);
            dbComm.Parameters.AddWithValue("@DoctorID", model.DoctorID);
            dbComm.Parameters.AddWithValue("@Date", model.Date);

            int x = dbComm.ExecuteNonQuery();
            dbconn.Close();
            return x;
        }

        public DataTable GetMaximumPrescription(int id)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetMaximumPrescription", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@DoctorID",id);

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        public DataTable GetReapet()
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetRepeat", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        public int AddMedicationPrescription(PrescribeMedication prescribe)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_AddPrescriptionMedication", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;
            prescribe.Status = "Active";
            prescribe.DispensedStatus = "Not Dispensed";

            if (prescribe.ContraIndicationID == 0)
            {
                //Represents null
                prescribe.ContraIndicationID = 3;
            }

            if (prescribe.MedInteractionID == 0)
            {
                //represents null
                prescribe.MedInteractionID = 1;
            }

            if (prescribe.AllergyID == 0)
            {
                //Represents Null
                prescribe.AllergyID = 4;
            }

            dbComm.Parameters.AddWithValue("@MedicationID", prescribe.MedicationID);
            dbComm.Parameters.AddWithValue("@PrescriptionID", prescribe.PrescriptionID);
            dbComm.Parameters.AddWithValue("@RepeatID", prescribe.RepeatID);
            dbComm.Parameters.AddWithValue("@ContraIndicationID", prescribe.ContraIndicationID);
            dbComm.Parameters.AddWithValue("@MedInteractionID", prescribe.MedInteractionID);
            dbComm.Parameters.AddWithValue("@AllergyID", prescribe.AllergyID);
            dbComm.Parameters.AddWithValue("@Instruction", prescribe.Instruction);
            dbComm.Parameters.AddWithValue("@Quantity", prescribe.Quantity.ToString());
            dbComm.Parameters.AddWithValue("@ContraIgnoreReason", prescribe.ContraIgnoreReason);
            dbComm.Parameters.AddWithValue("@WarningIgnoreReason", prescribe.WarningIgnoreReason);
            dbComm.Parameters.AddWithValue("@AllergyIgnoreReason", prescribe.AllergyIgnoreReason);
            dbComm.Parameters.AddWithValue("@Status", prescribe.Status);
            dbComm.Parameters.AddWithValue("@DispensedStatus", prescribe.DispensedStatus);

            int x = dbComm.ExecuteNonQuery();
            dbconn.Close();
            return x;
        }

        public DataTable CheckContraIndications(int IngredientID,int ConditionID)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_CheckContraIndications", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@IngredientID",IngredientID);
            dbComm.Parameters.AddWithValue("@ConditionID", ConditionID);

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        public DataTable CheckMedicationInteraction(int Ingredient1, int Ingredient2)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_CheckMedicationInteraction", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Ingredient1", Ingredient1);
            dbComm.Parameters.AddWithValue("@Ingredient2", Ingredient2);

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        public DataTable GetMedicationsByPatientID(int id)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetMedicationsByPatientID", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@PatientID",id);

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        public DataTable GetPrescriptionMedications(int PrescriptionID)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetPrescriptionMedications ", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        public DataTable GetPatientAllergies(int id)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetPatientAllergies", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@PatientID", id);

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        public DataTable CheckDrugAllergy(int IngredientID,int PatientID)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_CheckDrugAllergy", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@PatientID", PatientID);
            dbComm.Parameters.AddWithValue("@IngredientID", IngredientID);

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        public DataTable GetActiveIngredientsByMedicationID(PrescribeMedication medication)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetActiveIngredientByMedicationID", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@MedicationID", medication.MedicationID);
            

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }
        public DataTable GetActiveIngredientsByDispensedMed(DispenseMedication medication)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetActiveIngredientByMedicationID", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@MedicationID", medication.MedicationID);


            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        //Pharmacy and pharmacist methods

        public DataTable GetPatientPrescriptions(int patientId)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetPatientPrescriptions", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@PatientID",patientId);
            

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        public DataTable GetPrescriptionDetails(int PrescriptionId)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_PrescriptionDetails", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@PrescriptionID", PrescriptionId);


            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        public int DispenseMedication(DispenseMedication medication)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_DispenseMedication", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            if (medication.ContraIndicationID == 0)
            {
                //Represents null
               medication.ContraIndicationID = 3;
            }

            if (medication.MedInteractionID == 0)
            {
                //represents null
                medication.MedInteractionID = 1;
            }

            if (medication.AllergyID == 0)
            {
                //Represents Null
                medication.AllergyID = 4;
            }

            dbComm.Parameters.AddWithValue("@MedicationID", medication.MedicationID);
            dbComm.Parameters.AddWithValue("@PrescriptionID", medication.PrescriptionID);
            dbComm.Parameters.AddWithValue("@ContraIndicationID", medication.ContraIndicationID);
            dbComm.Parameters.AddWithValue("@MedInteractionID", medication.MedInteractionID);
            dbComm.Parameters.AddWithValue("@AllergyID", medication.AllergyID);
            dbComm.Parameters.AddWithValue("@Quantity", medication.Quantity.ToString());
            dbComm.Parameters.AddWithValue("@ContraIgnoreReason", medication.ContraIgnoreReason);
            dbComm.Parameters.AddWithValue("@WarningIgnoreReason", medication.WarningIgnoreReason);
            dbComm.Parameters.AddWithValue("@AllergyIgnoreReason", medication.AllergyIgnoreReason);
            dbComm.Parameters.AddWithValue("@PharmacistID", medication.PharmacistID);
            dbComm.Parameters.AddWithValue("@RepeatID", int.Parse(medication.RepeatID));
            dbComm.Parameters.AddWithValue("@Date", medication.Date);


            int x = dbComm.ExecuteNonQuery();
            dbconn.Close();
            return x;
        }

        public DataTable GetMedicationToDispense(int prescriptionID, int medicationID)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetMedicationToDispense", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@PrescriptionID", prescriptionID);
            dbComm.Parameters.AddWithValue("@MedicationID", medicationID);


            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

        public DataTable GetDispensedMedication(int prescriptionId)
        {
            string connString = configuration.GetConnectionString("connString");

            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetDispensedMedication", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@PrescriptionID", prescriptionId);


            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbconn.Close();

            return dt;
        }

    }
}