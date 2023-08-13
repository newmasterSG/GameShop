using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class MyOfficeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Card()
        {
            return View();
        }
    }
}
