using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using System.Drawing.Printing;
using UI.Models.Search;

namespace UI.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        private readonly GameService _gameService;
        public GameController(GameService gameService, 
            ILogger<GameController> logger)
        {
            _logger = logger;
            _gameService = gameService;
        }
        public IActionResult Index()
        {
            return View();
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
