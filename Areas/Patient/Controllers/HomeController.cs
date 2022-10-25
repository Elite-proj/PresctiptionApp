using E_prescription.Models;
using E_prescription.Models.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class HomeController : Controller
    {
        private readonly GRP42EPrescriptionContext _context = new GRP42EPrescriptionContext();

        private readonly IConfiguration configuration;
        DataAccess data;
        public HomeController(IConfiguration config)
        {
            this.configuration = config;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

       //[HttpPost]
        //public IActionResult PrescriptionList()
        //{
          
        //}
    }
}
