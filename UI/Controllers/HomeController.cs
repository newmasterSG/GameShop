using Application.ConstNamingCashes;
using Application.DTO;
using Application.InterfaceServices;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.UnitOfWork.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
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
        private readonly IMemoryCache _cache;

        public HomeController(ILogger<HomeController> logger, 
            IHomeService unitOfWork,
            IHtmlLocalizer<HomeController> localizer,
            IMemoryCache cache)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _localizer = localizer;
            _cache = cache;
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
            if (_cache.TryGetValue(CachesNaming.CarouselGames, out List<GameDTO> cachedCarouselGames))
            {
                return Json(cachedCarouselGames);
            }

            var cancellationTokenSource = new CancellationTokenSource();
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30),
            };

            try
            {
                var games = await _unitOfWork.GetCarouselGames();
                _cache.Set(CachesNaming.CarouselGames, games, cacheEntryOptions);

                return Json(games);
            }
            catch (Exception)
            {
                cancellationTokenSource.Cancel();
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<GameDTO>>> GetAllGames()
        {
            if (_cache.TryGetValue(CachesNaming.AllGames, out List<GameDTO> cachedAllGames))
            {
                return Json(cachedAllGames);
            }

            var games = await _unitOfWork.GetAllGames();
            _cache.Set(CachesNaming.AllGames, games, TimeSpan.FromMinutes(30));

            return Json(games);
        }

        [HttpGet]
        public async Task<ActionResult<List<TagDTO>>> GetAllTags()
        {
            var tags = await _unitOfWork.GetAllTags();

            return Json(tags);
        }

        [HttpPost]
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