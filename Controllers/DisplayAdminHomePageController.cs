﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Controllers
{
    public class DisplayAdminHomePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
