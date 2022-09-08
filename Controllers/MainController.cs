using Microsoft.AspNetCore.Mvc;

namespace E_prescription.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
