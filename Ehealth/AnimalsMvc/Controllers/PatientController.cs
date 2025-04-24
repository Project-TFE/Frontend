using Microsoft.AspNetCore.Mvc;

namespace AnimalsMvc.Controllers
{
    public class PatientController : Controller
    {
        // Temporarily remove [Authorize] attribute
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}