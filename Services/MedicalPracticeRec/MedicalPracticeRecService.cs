using E_prescription.Models;
using E_prescription.Services.MedicalPracticeRec;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace E_prescription.Services
{
    public class MedicalPracticeRecService : IMedicalPracticeRecService
    {
        private readonly GRP42EPrescriptionContext _context;
        public MedicalPracticeRecService(GRP42EPrescriptionContext context)
        {
            _context = context;
        }

        public bool Add(MedicalPractice model)
        {
            try
            {
                _context.MedicalPractices.Add(new MedicalPractice
                {
                    MedicalPracticeId = model.MedicalPracticeId,
                    PracticeName = model.PracticeName,
                    AddressLine1 = model.AddressLine1,
                    AddressLine2 = model.AddressLine2,
                    PracticeEmail = model.PracticeEmail,
                    PracticeContactNo = model.PracticeContactNo,
                    PracticeNo = model.PracticeNo,
                    ProvinceId = model.ProvinceId,
                    SuburbId = model.SuburbId,
                    CityId = model.CityId,
                });

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int MedicalPracticeId)
        {
            var medicalpractice = _context.MedicalPractices.Find(MedicalPracticeId);

            if (medicalpractice == null)
                throw new KeyNotFoundException($"Center with ID: {MedicalPracticeId} was not found.");

            _context.MedicalPractices.Remove(medicalpractice);
            return _context.SaveChanges() > 0;
        }
        public MedicalPractice GetMedicalPractice(int MedicalPracticeId)
        {
            var medicalpractice = _context.MedicalPractices.Find(MedicalPracticeId);

            if (medicalpractice == null)
                throw new KeyNotFoundException($"Medical with ID: {MedicalPracticeId} was not found.");


            MedicalPractice model = new MedicalPractice
            {
                MedicalPracticeId = medicalpractice.MedicalPracticeId,
                PracticeName = medicalpractice.PracticeName,
                AddressLine1 = medicalpractice.AddressLine1,
                AddressLine2 = medicalpractice.AddressLine2,
                PracticeEmail = medicalpractice.PracticeEmail,
                PracticeContactNo = medicalpractice.PracticeContactNo,
                PracticeNo = medicalpractice.PracticeNo,
                Province = medicalpractice.Province,
                Suburb = medicalpractice.Suburb,
                City = medicalpractice.City,
            };

            return model;
        }
        public List<MedicalPractice> List()
        {
            return _context.MedicalPractices.Select(b => new MedicalPractice
            {
                MedicalPracticeId = b.MedicalPracticeId,
                PracticeName = b.PracticeName,
                AddressLine1 = b.AddressLine1,
                AddressLine2 = b.AddressLine2,
                PracticeEmail = b.PracticeEmail,
                PracticeContactNo = b.PracticeContactNo,
                PracticeNo = b.PracticeNo,
                Province = b.Province,
                Suburb = b.Suburb,
                City = b.City,

            }).ToList();

        }
        public List<MedicalPractice> ListByCity(int cityID)
        {
            throw new NotImplementedException();
        }

        public List<MedicalPractice> ListByProvince(int ProvinceId)
        {
            throw new NotImplementedException();
        }
        public bool Update(MedicalPractice model)
        {
            var medicalpractice = _context.MedicalPractices.Find(model.MedicalPracticeId);

            if (medicalpractice == null)
                throw new KeyNotFoundException($"Medical with ID: {model.MedicalPracticeId} was not found.");

            medicalpractice.MedicalPracticeId = model.MedicalPracticeId;
            medicalpractice.PracticeName = model.PracticeName;
            medicalpractice.AddressLine1 = model.AddressLine1;
            medicalpractice.AddressLine2 = model.AddressLine2;
            medicalpractice.PracticeEmail = model.PracticeEmail;
            medicalpractice.PracticeContactNo = model.PracticeContactNo;
            medicalpractice.PracticeNo = model.PracticeNo;
            medicalpractice.Province = model.Province;
            medicalpractice.Suburb = model.Suburb;
            medicalpractice.City = model.City;

            return _context.SaveChanges() > 0;
        }

        public List<Province> GetProvinceList()
        {

            return _context.Provinces.Select(b => new Province
            {
                ProvinceId = b.ProvinceId,
                ProvinceName = b.ProvinceName,

            }).ToList();
        }


        public List<City> GetCities(int ProvinceId)
        {
            var Cities = _context.Cities.Where(c => c.ProvinceId == ProvinceId).ToList();
            return Cities;
        }
        public List<Suburb> GetSuburbs(int CityId)
        {
            var Suburbs = _context.Suburbs.Where(c => c.CityId == CityId).ToList();
            return Suburbs;
        }
    }
}
