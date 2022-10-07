using E_prescription.Models;
using E_prescription.Services.DoctorRec;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E_prescription.Services.DoctorRec
{

    public class DoctorRecService : IDoctorRecService
    {
        private readonly GRP42EPrescriptionContext _context;
        public DoctorRecService(GRP42EPrescriptionContext context)
        {
            _context = context;
        }
        //add
        public bool Add(Doctor model)
        {
            try
            {
                _context.Doctors.Add(new Doctor
                {
                    DoctorId = model.DoctorId,
                    Hcrn = model.Hcrn,
                    //Qualification = model.Qualification,
                    //MedicalPracticeId = model.MedicalPracticeId,
                    DoctorNavigation = model.DoctorNavigation,

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
            var doctor = _context.Doctors.Find(DoctorId);

            if (doctor == null)
                throw new KeyNotFoundException($"Doctor with ID: {DoctorId} was not found.");

            _context.Doctors.Remove(doctor);
            return _context.SaveChanges() > 0;
        }
        public Doctor GetDoctor(int DoctorId)
        {

            var doctor = _context.Doctors.Find(DoctorId);

            if (doctor == null)
                throw new KeyNotFoundException($"Doctor with ID: {DoctorId} was not found.");


            Doctor model = new Doctor
            {
                DoctorId = doctor.DoctorId,
                Hcrn = doctor.Hcrn,
                //Qualification = doctor.Qualification,
                //MedicalPracticeId = doctor.MedicalPracticeId,
                DoctorNavigation = doctor.DoctorNavigation,

            };

            return model;
        }
        public List<Doctor> List()
        {
            return _context.Doctors.Select(b => new Doctor
            {
                DoctorId = b.DoctorId,
                Hcrn = b.Hcrn,
                //Qualification = b.Qualification,
                //MedicalPracticeId = b.MedicalPracticeId,
                DoctorNavigation = b.DoctorNavigation,

            }).ToList();

        }

        public bool Update(Doctor model)
        {
            var doctor = _context.Doctors.Find(model.DoctorId);

            if (doctor == null)
                throw new KeyNotFoundException($"Doctor with ID: {model.DoctorId} was not found.");

            doctor.DoctorId = model.DoctorId;
            doctor.Hcrn = model.Hcrn;
            //doctor.Qualification = model.Qualification;
            //doctor.MedicalPracticeId = model.MedicalPracticeId;
            doctor.DoctorNavigation = model.DoctorNavigation;

            return _context.SaveChanges() > 0;
        }
    }
}