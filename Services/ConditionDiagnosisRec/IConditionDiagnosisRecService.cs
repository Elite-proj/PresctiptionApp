using E_prescription.Models;
using System.Collections.Generic;


namespace E_prescription.Services.ConditionDiagnosisRec
{
    public interface IConditionDiagnosisRecService
    {
        bool Add(ConditionDiagnosisModel model);
        bool Update(ConditionDiagnosisModel model);
        bool Delete(int ConditonId);
        ConditionDiagnosisModel GetCondition(int ConditionId);

        List<ConditionDiagnosisModel> List();
        List<ConditionDiagnosisModel> ListByDoctor(int ConditionId);
    }
}
