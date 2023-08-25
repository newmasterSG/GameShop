using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiSteam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameContoller: ControllerBase
    {
        private readonly GameService _gameService;
        public GameContoller(GameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        [Route("GetGame")]
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

            return new JsonResult(game);
        }
    }
}
