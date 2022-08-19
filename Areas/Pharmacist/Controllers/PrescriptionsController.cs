using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Areas.Pharmacist.Controllers
{
    [Area("Pharmacist")]
    public class PrescriptionsController : Controller
    {
        public IActionResult Display()
        {
            return View();
        }
    }
}
