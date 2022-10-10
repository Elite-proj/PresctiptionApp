using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Data;
using E_prescription.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_prescription.Controllers.Schedule
{
    public class ScheduleController : Controller
    {
        private readonly IConfiguration configuration;
        DataAccess data;

        public ScheduleController(IConfiguration config)
        {
            this.configuration = config;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult List()
        {
            data = new DataAccess(configuration);
            DataTable dt = new DataTable();

            dt = data.GetSchedule();
            List<ScheduleVM> schedules = new List<ScheduleVM>();

            for(int i=0;i<dt.Rows.Count;i++)
            {
                ScheduleVM schedule = new ScheduleVM();

                schedule.ScheduleID = int.Parse(dt.Rows[i]["ScheduleID"].ToString());
                schedule.ScheduleDescription = dt.Rows[i]["ScheduleDescription"].ToString();
                schedule.Status = dt.Rows[i]["Status"].ToString();

                schedules.Add(schedule);
            }

            ViewBag.Schedules = schedules.ToList();

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Add(ScheduleVM schedule)
        {
            if (ModelState.IsValid)
            {
                data = new DataAccess(configuration);
                data.AddSchedule(schedule);

                return RedirectToAction("List", "Schedule");
            }
            else
                return View(schedule);
        }
    }
}
