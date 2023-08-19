using Application.DTO;
using Application.InterfaceServices;
using Domain.Entities.Games;
using Infrastructure.UnitOfWork.Interface;
using Infrastructure.UnitOfWork.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using System.Diagnostics;
using UI.Models;

namespace UI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _unitOfWork;
        private readonly IHtmlLocalizer<HomeController> _localizer;

        public HomeController(ILogger<HomeController> logger, 
            IHomeService unitOfWork,
            IHtmlLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<ActionResult<List<GameDTO>>> GetCarouselGames()
        {
            var games = await _unitOfWork.GetCarouselGames();

            return Json(games);
        }

        [HttpGet]
        public async Task<ActionResult<List<GameDTO>>> GetAllGames()
        {
            var games = await _unitOfWork.GetAllGames();

            return Json(games);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult ChangeLanguage(string lang, string returnUrl)
        {
            Response.Cookies.Append(
                            CookieRequestCultureProvider.DefaultCookieName,
                            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(lang)),
                            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                            );

            if (!string.IsNullOrEmpty(returnUrl))
            {
                return LocalRedirect(returnUrl);
            }

            // Если returnUrl пустой, выполните действие по умолчанию.
            return RedirectToAction("Index", "Home");
        }
    }
}