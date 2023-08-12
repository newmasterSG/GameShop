using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

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
    }
}
