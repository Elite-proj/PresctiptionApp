using System.Collections.Generic;
using System.Text;
using System;
using E_prescription.Models;

namespace E_prescription.Services.MedicalPracticeRec
{//interface classes
    public interface IMedicalPracticeRecService
    {
        bool Add(MedicalPracticeRecModel model);
        bool Update(MedicalPracticeRecModel model);
        bool Delete(int MedicalPracticeId);
        MedicalPracticeRecModel GetMedicalPractice(int MedicalPracticeId);

        //List<MedicalPracticeRecModel> GetAllMedicalPractices();
        List<MedicalPracticeRecModel> List();
        List<MedicalPracticeRecModel> ListByCity(int DoctorId);
    }
}
