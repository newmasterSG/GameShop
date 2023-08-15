using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Authorize]
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
