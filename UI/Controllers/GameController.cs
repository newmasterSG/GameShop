using Application.DTO;
using Application.InterfaceServices;
using Application.Services;
using Azure.Core;
using Domain.Entities;
using Duende.IdentityServer.Extensions;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using PagedList;
using System.Drawing.Printing;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using UI.Models.Search;

namespace UI.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        private readonly IGameService _gameService;
        private readonly IReviewsService _reviewService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHtmlLocalizer<GameController> _localizer;
        public GameController(IGameService gameService, 
            ILogger<GameController> logger,
            IReviewsService reviewService,
            IHttpClientFactory httpClientFactory,
            IHtmlLocalizer<GameController> localizer)
        {
            _logger = logger;
            _gameService = gameService;
            _reviewService = reviewService;
            _httpClientFactory = httpClientFactory;
            _localizer = localizer;
        }

        public async Task<IActionResult> GameDetails(int id)
        {
            if(User.IsAuthenticated())
            {
                ViewBag.Token = await HttpContext.GetTokenAsync("access_token") ?? "";
            }
            ViewBag.GameId = id;
            return View();
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [Authorize(Policy = "DateRegistrationPolicy")]
        public IActionResult Sales()
        {

            return View();
        }

        [HttpGet]
        public async Task<ActionResult<GamesViewDTO>> GetGame(int id)
        {
            if (id == null)
            {
                return NotFound(); // Возвращаем 404 Not Found, если id не передан
            }

            var game = await _gameService.GetGame(id);

            if (game == null)
            {
                return NotFound(); // Возвращаем 404 Not Found, если игра не найдена
            }

            return Json(game);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchViewModel viewModel, int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 12;

            var games = await _gameService.SearchGame(viewModel.GameName);

            if (games == null || games.Count == 0)
            {
                ModelState.AddModelError("", "No such games");
            }
            else
            {
                ViewBag.GameName = viewModel.GameName;
                viewModel.PagedSearchResults = new StaticPagedList<GameDTO>(games, pageNumber, pageSize, games.Count);
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews(int page = 1, int pageSize = 12)
        {
            var reviews = await _reviewService.GetAllReviews(page,pageSize);
            return Ok(reviews);
        }

        [HttpGet]
        public async Task<IActionResult> GamesByTag(string tag, int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 12;

            var games = await _gameService.GamesByTags(tag);

            if (games == null || games.Count == 0)
            {
                ModelState.AddModelError("", "No such games");
            }

            return View(games);
        }
    }
}
