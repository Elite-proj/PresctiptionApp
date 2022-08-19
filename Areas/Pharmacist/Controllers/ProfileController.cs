using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace E_prescription.Areas.Pharmacist.Controllers
{
    [Area("Pharmacist")]
    public class ProfileController : Controller
    {
        public IActionResult Display()
        {
            return View();
        }
    }
}
