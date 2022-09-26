using System.Collections.Generic;
using System.Text;
using System;
using E_prescription.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_prescription.Services.MedicalPracticeRec
{//interface classes
    public interface IMedicalPracticeRecService
    {
        bool Add(MedicalPracticeRecModel model);
        bool Update(MedicalPracticeRecModel model);
        bool Delete(int MedicalPracticeId);
        MedicalPracticeRecModel GetMedicalPractice(int MedicalPracticeId);

        //bool GetAllProvinces(int Province);
        //MedicalPracticeRecModel GetCitiesByProvinceId(int CityId);
        //MedicalPracticeRecModel GetSuburbsByCityId(int SuburbId);

        List<MedicalPracticeRecModel> List();
        List<MedicalPracticeRecModel> ListByCity(int CityID);
        List<MedicalPracticeRecModel> ListByProvince(int ProvinceID);
    }
}
