﻿using Microsoft.AspNetCore.Mvc;

namespace E_prescription.Controllers
{
    public class MedicationInteractionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
