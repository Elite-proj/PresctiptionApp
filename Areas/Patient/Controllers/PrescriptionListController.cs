using E_prescription.Areas.Patient.Models;
using E_prescription.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace E_prescription.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class PrescriptionListController : Controller
    {
        private readonly IConfiguration configuration;
        DataAccess data;
        DataTable dt;

        public PrescriptionListController(IConfiguration config)
        {
            this.configuration = config;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
