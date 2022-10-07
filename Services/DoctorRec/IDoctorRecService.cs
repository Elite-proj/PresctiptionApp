using E_prescription.Models;
using System.Collections.Generic;

namespace E_prescription.Services.DoctorRec
{
    public interface IDoctorRecService
    {
        bool Add(Doctor model);
        bool Update(Doctor model);
        bool Delete(int DoctorId);
        Doctor GetDoctor(int DoctorId);

        List<Doctor> List();
    }
}
