using Microsoft.AspNetCore.Mvc;

namespace AnimalsMvc.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string name, string email, string message)
        {
            // TODO: Implement contact form logic here
            return RedirectToAction("Index", "Home");
        }
    }
}