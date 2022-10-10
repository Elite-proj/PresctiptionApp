using System.Collections.Generic;
using E_prescription.Models;

namespace E_prescription.Services.Repeat
{
    public interface IRepeatRecService
    {
        bool Add(RepeatModel model);
        bool Update(RepeatModel model);
        bool Delete(int RepeatId);
        RepeatModel GetRepeat(int RepeatId);

        List<RepeatModel> List();
        List<RepeatModel> ListByDoctor(int DoctorId);
    }
}
