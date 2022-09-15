using E_prescription.Models;
using E_prescription.Services.MedicalPracticeRec;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E_prescription.Services
{
    public class MedicalPracticeRecService: IMedicalPracticeRecService
    {
        private readonly EPrescriptiondbContext _context;
        public MedicalPracticeRecService(EPrescriptiondbContext context)
        {
            _context = context;
        }
        //add
        public bool Add(MedicalPracticeRecModel model)
        {
            try
            {
                _context.MedicalPractice.Add(new MedicalPractice
                {
                    MedicalPracticeId = model.MedicalPracticeId,
                    PracticeName = model.PracticeName,
                    AddressLine1 = model.AddressLine1,
                    AddressLine2 = model.AddressLine2,
                    PracticeEmail = model.PracticeEmail,
                    PracticeContactNo = model.PracticeContactNo,
                    PracticeNo = model.PracticeNo,
                    //Province = model.Province,
                    //Suburb = model.Suburb,
                    //City = model.City,
                });

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //delete
        public bool Delete(int MedicalPracticeId)
        {
            var medicalpractice = _context.MedicalPractice.Find(MedicalPracticeId);

            if (medicalpractice == null)
                throw new KeyNotFoundException($"Center with ID: {MedicalPracticeId} was not found.");

            _context.MedicalPractice.Remove(medicalpractice);
            return _context.SaveChanges() > 0;
        }
        public MedicalPracticeRecModel GetMedicalPractice(int MedicalPracticeId)
        {

            var medicalpractice = _context.MedicalPractice.Find(MedicalPracticeId);

            if (medicalpractice == null)
                throw new KeyNotFoundException($"Medical with ID: {MedicalPracticeId} was not found.");


            MedicalPracticeRecModel model = new MedicalPracticeRecModel
            {
                MedicalPracticeId = medicalpractice.MedicalPracticeId,
                PracticeName = medicalpractice.PracticeName,
                AddressLine1 = medicalpractice.AddressLine1,
                AddressLine2 = medicalpractice.AddressLine2,
                PracticeEmail = medicalpractice.PracticeEmail,
                PracticeContactNo = medicalpractice.PracticeContactNo,
                PracticeNo = medicalpractice.PracticeNo,
                //Province = medicalpractice.Province,
                //Suburb = medicalpractice.Suburb,
                //City = medicalpractice.City,
            };

            return model;
        }
        public List<MedicalPracticeRecModel> List()
        {
            return _context.MedicalPractice.Select(b => new MedicalPracticeRecModel
            {
                MedicalPracticeId = b.MedicalPracticeId,
                PracticeName = b.PracticeName,
                AddressLine1 = b.AddressLine1,
                AddressLine2 = b.AddressLine2,
                PracticeEmail = b.PracticeEmail,
                PracticeContactNo = b.PracticeContactNo,
                PracticeNo = b.PracticeNo,
                //Province = b.Province,
                //Suburb = b.Suburb,
                //City = b.City,

            }).ToList();

        }
        public List<MedicalPracticeRecModel> ListByCity(int cityID)
        {
            throw new NotImplementedException();
        }

        public List<MedicalPracticeRecModel> ListByRegionalManger(int regionalID)
        {
            throw new NotImplementedException();
        }
        public bool Update(MedicalPracticeRecModel model)
        {
            var medicalpractice = _context.MedicalPractice.Find(model.MedicalPracticeId);

            if (medicalpractice == null)
                throw new KeyNotFoundException($"Center with ID: {model.MedicalPracticeId} was not found.");

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
    }
}
