using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using E_prescription.Models.Account;

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
            dbComm.Parameters.AddWithValue("@Password", doctor.Password);
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

    }
}