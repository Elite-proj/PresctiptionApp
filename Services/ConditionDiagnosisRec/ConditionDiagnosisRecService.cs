﻿using E_prescription.Models;
using E_prescription.Services.ConditionDiagnosisRec;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.EntityFrameworkCore;
using System.Text;


namespace E_prescription.Services
{
    public class ConditionDiagnosisRecService : IConditionDiagnosisRecService
    {
        private readonly GRP42EPrescriptionContext _context;
        public ConditionDiagnosisRecService(GRP42EPrescriptionContext context)
        {
            _context = context;
        }
        public bool Add(ConditionDiagnosisModel model)
        {
            try
            {


                _context.ConditionDiagnoses.Add(new ConditionDiagnosis
                {
                    ConditionId = model.ConditionId,
                    ConditionDecription = model.ConditionDecription,

                });

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(int ConditionId)
        {
            var conditiondiagnosis = _context.ConditionDiagnoses.Find(ConditionId);

            if (conditiondiagnosis == null)
                throw new KeyNotFoundException($"Condition with ID: {ConditionId} was not found.");

            _context.ConditionDiagnoses.Remove(conditiondiagnosis);
            return _context.SaveChanges() > 0;
        }

        public ConditionDiagnosisModel GetCondition(int ConditionId)
        {
            var conditiondiagnosis = _context.ConditionDiagnoses.Find(ConditionId);

            if (conditiondiagnosis == null)
                throw new KeyNotFoundException($"Condition with ID: {ConditionId} was not found.");


            ConditionDiagnosisModel model = new ConditionDiagnosisModel
            {
                ConditionId = conditiondiagnosis.ConditionId,
                ConditionDecription = conditiondiagnosis.ConditionDecription,
            };

            return model;
        }
        public List<ConditionDiagnosisModel> List()
        {
            return _context.ConditionDiagnoses.Select(b => new ConditionDiagnosisModel
            {
                ConditionId = b.ConditionId,
                ConditionDecription = b.ConditionDecription,

            }).ToList();
        }
        public List<ConditionDiagnosisModel> ListByDoctor(int DoctorID)
        {
            throw new NotImplementedException();
        }
        public bool Update(ConditionDiagnosisModel model)
        {
            var conditiondiagnosis = _context.ConditionDiagnoses.Find(model.ConditionId);

            if (conditiondiagnosis == null)
                throw new KeyNotFoundException($"Conditon with ID: {model.ConditionId} was not found.");

            conditiondiagnosis.ConditionId = model.ConditionId;
            conditiondiagnosis.ConditionDecription = model.ConditionDecription;

            return _context.SaveChanges() > 0;
        }

    }

}
