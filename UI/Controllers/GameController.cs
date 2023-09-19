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
using UI.Models.Game;
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

            var game = await _gameService.GetGameAsync(id);

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

            var games = await _gameService.SearchGameAsync(viewModel.GameName);

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
            var reviews = await _reviewService.GetAllReviewsAsync(page,pageSize);
            return Ok(reviews);
        }

        [HttpGet]
        public async Task<IActionResult> GamesByTag(string tag, int page = 1, int pageSize = 10)
        {
            var games = await _gameService.GamesByTagsAsync(tag);

            if (games != null)
            {
                int totalCount = games.Count;
                int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                var gamesOnPage = games.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                var viewModel = new GamesViewModel
                {
                    Games = gamesOnPage,
                    PageNumber = page,
                    PageSize = pageSize,
                    TotalCount = totalCount,
                    TotalPages = totalPages
                };

                return View(viewModel);
            }

            if (games == null || games.Count == 0)
            {
                ModelState.AddModelError("", "No such games");
            }

            return View();
        }

        public async Task<IActionResult> AllGames(int page = 1, int pageSize = 10)
        {
            var allGames = await _gameService.GetAllGamesAsync();

            if(allGames != null)
            {
                int totalCount = allGames.Count;
                int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                // Выбираем игры для текущей страницы
                var gamesOnPage = allGames.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                var viewModel = new GamesViewModel
                {
                    Games = gamesOnPage,
                    PageNumber = page,
                    PageSize = pageSize,
                    TotalCount = totalCount,
                    TotalPages = totalPages
                };

                return View(viewModel);
            }


            return View();
        }

        public async Task<IActionResult> ListTags(int page = 1, int pageSize = 10)
        {
            var tags = await _gameService.GetAllTagsAsync();

            if (tags != null)
            {
                int totalCount = tags.Count;
                int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                // Выбираем игры для текущей страницы
                var tagsOnPage = tags.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                var viewModel = new TagsViewModel
                {
                    Tags = tagsOnPage,
                    PageNumber = page,
                    PageSize = pageSize,
                    TotalCount = totalCount,
                    TotalPages = totalPages
                };

                return View(viewModel);
            }

            return View();
        }
    }
}
