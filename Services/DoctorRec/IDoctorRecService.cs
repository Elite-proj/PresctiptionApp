using E_prescription.Models;
using System.Collections.Generic;

namespace E_prescription.Services.DoctorRec
{
    public interface IDoctorRecService
    {
        bool Add(DoctorModel model);
        bool Update(DoctorModel model);
        bool Delete(int DoctorId);
        DoctorModel GetDoctor(int DoctorId);

        List<DoctorModel> List();
    }
}
