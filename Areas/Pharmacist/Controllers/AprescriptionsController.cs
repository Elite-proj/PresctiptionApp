using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Areas.Pharmacist.Controllers
{
    public class AprescriptionsController : Controller
    {
        [Area("Pharmacist")]
        public IActionResult Display()
        {
            return View();
        }
    }
}
