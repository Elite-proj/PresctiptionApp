using E_prescription.Models;
using E_prescription.Services.ConditionDiagnosisRec;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Controllers
{
    public class ConditionDiagnosisRecController : Controller
    {
        private readonly IConditionDiagnosisRecService _conditionDiagnosisRecService;
       
        public ConditionDiagnosisRecController(IConditionDiagnosisRecService conditionDiagnosisRecService)
        {
            _conditionDiagnosisRecService = conditionDiagnosisRecService;
        }
       
        public IActionResult Conditions()
        {
            var conditions = _conditionDiagnosisRecService.List();
            return View(conditions);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new ConditionDiagnosisModel());
        }

      
        [HttpPost]
        public IActionResult Add(ConditionDiagnosisModel conditionDiagnosisRec)
        {
            var isSuccess = _conditionDiagnosisRecService.Add(conditionDiagnosisRec);

            if (isSuccess)
                return Redirect("Conditions");

            return View(conditionDiagnosisRec);
        }

        [HttpGet]
        public IActionResult Update(int ConditionId)
        {
            var conditionDiagnosisRec = _conditionDiagnosisRecService.GetCondition(ConditionId);
            return View();
        }

        [HttpPost]
        public IActionResult Update(ConditionDiagnosisModel conditiondiagnosis)
        {
            var isSuccess = _conditionDiagnosisRecService.Update(conditiondiagnosis);

            if (isSuccess)
                return Redirect("ConditionDiagnosisRec");

            return View(conditiondiagnosis);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _conditionDiagnosisRecService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
