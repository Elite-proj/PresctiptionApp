using System.Collections.Generic;
using System.Text;
using System;
using E_prescription.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_prescription.Services.MedicalPracticeRec
{//interface classes
    public interface IMedicalPracticeRecService
    {
        bool Add(MedicalPractice model);
        bool Update(MedicalPractice model);
        bool Delete(int MedicalPracticeId);
        MedicalPractice GetMedicalPractice(int MedicalPracticeId);

        List<Province> GetProvinceList();
        //List<City> GetCities(int ProvinceId);
        //List<Suburb> GetSuburbs(int CityId);
        List<MedicalPractice> List();
        List<MedicalPractice> ListByCity(int CityID);
        List<MedicalPractice> ListByProvince(int ProvinceID);
    }
}
