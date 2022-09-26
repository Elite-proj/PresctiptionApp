using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using E_prescription.Models;
using E_prescription.Services;
using E_prescription.Services.MedicalPracticeRec;
using E_prescription.Services.DoctorRec;
using E_prescription.Services.ConditionDiagnosisRec;



namespace E_prescription
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            this.env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<EPrescriptiondbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("connString")));

            services.AddTransient<IDoctorRecService, DoctorRecService>();
            services.AddTransient<IMedicalPracticeRecService, MedicalPracticeRecService>();
            services.AddTransient<ConditionDiagnosisRecService, ConditionDiagnosisRecService>();
            services.AddScoped<IViewRenderService, ViewRenderService>();

            services.AddScoped<IViewRenderService, ViewRenderService>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc(options => options.EnableEndpointRouting = false);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "doctor",
                    areaName: "Doctor",
                    pattern: "Doctor/{controller=Home}/{action=index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "pharmacist",
                    areaName: "Pharmacist",
                    pattern: "Pharmacist/{controller=Home}/{action=index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "patient",
                    areaName: "Patient",
                    pattern: "Patient/{controller=Home}/{action=index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
