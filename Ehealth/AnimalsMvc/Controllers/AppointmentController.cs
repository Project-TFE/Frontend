using Microsoft.AspNetCore.Mvc;

namespace AnimalsMvc.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}