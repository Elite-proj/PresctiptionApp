using E_prescription.Models;
using E_prescription.Services.DoctorRec;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E_prescription.Services.DoctorRec
{
 
        public class DoctorRecService : IDoctorRecService
        {
            private readonly EPrescriptiondbContext _context;
            public DoctorRecService(EPrescriptiondbContext context)
            {
                _context = context;
            }
            //add
            public bool Add(DoctorModel model)
            {
                try
                {
                    _context.Doctor.Add(new Doctor
                    {
                        DoctorId = model.DoctorId,
                        Hcrn = model.Hcrn,
                        Qualification = model.Qualification,
                        //MedicalPracticeId = model.MedicalPracticeId,
                        User = model.User,

                    });

                    return _context.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            //delete
            public bool Delete(int DoctorId)
            {
                var doctor = _context.Doctor.Find(DoctorId);

                if (doctor == null)
                    throw new KeyNotFoundException($"Doctor with ID: {DoctorId} was not found.");

                _context.Doctor.Remove(doctor);
                return _context.SaveChanges() > 0;
            }
            public DoctorModel GetDoctor(int DoctorId)
            {

                var doctor = _context.Doctor.Find(DoctorId);

                if (doctor == null)
                    throw new KeyNotFoundException($"Doctor with ID: {DoctorId} was not found.");


                DoctorModel model = new DoctorModel
                {
                    DoctorId = doctor.DoctorId,
                    Hcrn = doctor.Hcrn,
                    Qualification = doctor.Qualification,
                    //MedicalPracticeId = doctor.MedicalPracticeId,
                    User = doctor.User

                };

                return model;
            }
            public List<DoctorModel> List()
            {
                return _context.Doctor.Select(b => new DoctorModel
                {
                    DoctorId = b.DoctorId,
                    Hcrn = b.Hcrn,
                    Qualification = b.Qualification,
                    //MedicalPracticeId = b.MedicalPracticeId,
                    User = b.User,

                }).ToList();

            }
           
            public bool Update(DoctorModel model)
            {
                var doctor = _context.Doctor.Find(model.DoctorId);

                if (doctor == null)
                    throw new KeyNotFoundException($"Doctor with ID: {model.DoctorId} was not found.");

                doctor.DoctorId = model.DoctorId;
                doctor.Hcrn = model.Hcrn;
                doctor.Qualification = model.Qualification;
             //doctor.MedicalPracticeId = model.MedicalPracticeId;
            doctor.User = model.User;

            return _context.SaveChanges() > 0;
            }
        }
    }