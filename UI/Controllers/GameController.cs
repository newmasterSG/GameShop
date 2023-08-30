using Application.DTO;
using Application.Services;
using Domain.Entities;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        private readonly GameService _gameService;
        private readonly ReviewsService _reviewService;
        private readonly IHttpClientFactory _httpClientFactory;
        public GameController(GameService gameService, 
            ILogger<GameController> logger,
            ReviewsService reviewService,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _gameService = gameService;
            _reviewService = reviewService;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult GameDetails(int id)
        {
            ViewBag.GameId = id;
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

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddReview(int gameId, string reviewText, int rating)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest(new { success = false, message = "You must be logged in to add a review." });
            }

            var success = await _reviewService.AddReview(gameId, userId, reviewText, rating);

            if (success)
            {
                return Ok(new { success = true, message = "Review added successfully." });
            }
            else
            {
                return NotFound(new { success = false, message = "Game not found." });
            }
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
