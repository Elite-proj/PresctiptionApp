using E_prescription.Services.Repeat;
using Microsoft.AspNetCore.Mvc;
using System;
using E_prescription.Models;

namespace E_prescription.Controllers
{
    public class RepeatController : Controller
    {
        private readonly IRepeatRecService _repeatRecService;

        public RepeatController(IRepeatRecService repeatRecService)
        {
            _repeatRecService = repeatRecService;
        }

        public IActionResult Repeats()
        {
            var repeats = _repeatRecService.List();
            return View(repeats);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Repeat());
        }

        [HttpPost]
        public IActionResult Add(RepeatModel repeat)
        {
            var isSuccess = _repeatRecService.Add(repeat);

            if (isSuccess)
                return Redirect("Repeats");

            return View(repeat);
        }

        [HttpGet]
        public IActionResult Update(int RepeatId)
        {
            var repeat = _repeatRecService.GetRepeat(RepeatId);
            return View();
        }

        [HttpPost]
        public IActionResult Update(RepeatModel repeat)
        {
            var isSuccess = _repeatRecService.Update(repeat);

            if (isSuccess)
                return Redirect("Repeat");

            return View(repeat);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _repeatRecService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
