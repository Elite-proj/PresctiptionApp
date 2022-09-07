using System.Collections.Generic;
using System.Text;
using System;
using E_prescription.Models;

namespace E_prescription.Services
{//interface classes
    public interface IMedicalPracticeRecService
    {
        bool Add(MedicalPractice model);
        bool Update(MedicalPractice model);
        bool Delete(int MedicalPracticeId);
        MedicalPractice GetMedicalPractice(int MedicalPracticeId);

        List<MedicalPractice> GetAllMedicalPractices();
        List<MedicalPractice> List();
        List<MedicalPractice> ListByCity(int DoctorId);
    }
}
