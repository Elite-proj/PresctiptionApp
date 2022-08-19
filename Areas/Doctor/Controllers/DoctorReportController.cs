using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class DoctorReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
