using System.Collections.Generic;
using System;
using System.Linq;
using E_prescription.Models;
using E_prescription.Services.Repeat;

namespace E_prescription.Services
{
    public class RepeatRecService : IRepeatRecService
    {
        private readonly GRP42EPrescriptionContext _context;
        public RepeatRecService(GRP42EPrescriptionContext context)
        {
            _context = context;
        }
        public bool Add(RepeatModel model)
        {
            try
            {


                _context.Repeats.Add(new Models.Repeat
                {
                    RepeatId = model.RepeatId,
                    RepeatDescription = model.RepeatDescription,

                });

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(int RepeatId)
        {
            var repeat = _context.Repeats.Find(RepeatId);

            if (repeat == null)
                throw new KeyNotFoundException($"Repeat with ID: {RepeatId} was not found.");

            _context.Repeats.Remove(repeat);
            return _context.SaveChanges() > 0;
        }

        public RepeatModel GetRepeat(int RepeatId)
        {
            var repeat = _context.Repeats.Find(RepeatId);

            if (repeat == null)
                throw new KeyNotFoundException($"Repeat with ID: {RepeatId} was not found.");


            RepeatModel model = new RepeatModel
            {
                RepeatId = repeat.RepeatId,
                RepeatDescription = repeat.RepeatDescription,
            };

            return model;
        }
        public List<RepeatModel> List()
        {
            return _context.Repeats.Select(b => new RepeatModel
            {
                RepeatId = b.RepeatId,
                RepeatDescription = b.RepeatDescription,

            }).ToList();
        }
        public List<RepeatModel> ListByDoctor(int DoctorID)
        {
            throw new NotImplementedException();
        }
        public bool Update(RepeatModel model)
        {
            var repeat = _context.Repeats.Find(model.RepeatId);

            if (repeat == null)
                throw new KeyNotFoundException($"Repeat with ID: {model.RepeatId} was not found.");

            repeat.RepeatId = model.RepeatId;
            repeat.RepeatDescription = model.RepeatDescription;

            return _context.SaveChanges() > 0;
        }

    }

}
