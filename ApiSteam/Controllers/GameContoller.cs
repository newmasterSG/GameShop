using Application.DTO;
using Application.InterfaceServices;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ApiSteam.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController: ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IMemoryCache _cache;
        public GameController(IGameService gameService, IMemoryCache cache)
        {
            _gameService = gameService;
            _cache = cache;
        }

        [HttpGet("{id?}")]
        public async Task<ActionResult<GamesViewDTO>> GetGame(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _gameService.GetGameAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return new JsonResult(game);
        }
    }
}
