using E_prescription.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Controllers.MedicationInteraction
{
    public class MedicationInteractionController : Controller
    {
        private readonly IConfiguration configuration;
        DataAccess data;

        public MedicationInteractionController(IConfiguration config)
        {
            this.configuration = config;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
