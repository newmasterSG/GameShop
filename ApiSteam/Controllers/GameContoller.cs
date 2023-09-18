using Application.DTO;
using Application.InterfaceServices;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ApiSteam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController: ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IMemoryCache _cache;
        private readonly IHomeService _unitOfWork;
        public GameController(IGameService gameService, IMemoryCache cache, IHomeService homeService)
        {
            _gameService = gameService;
            _cache = cache;
            _unitOfWork = homeService;
        }

        [HttpGet]
        [Route("GetGameAsync")]
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

            return new JsonResult(game);
        }

        [HttpGet]
        [Route("GetCarouselGamesAsync")]
        public async Task<ActionResult<List<GameDTO>>> GetCarouselGames()
        {
            string cacheKey = "CarouselGames";

            if (_cache.TryGetValue(cacheKey, out List<GameDTO> cachedCarouselGames))
            {
                return new JsonResult(cachedCarouselGames);
            }

            var cancellationTokenSource = new CancellationTokenSource();
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30),
            };

            try
            {
                var games = await _unitOfWork.GetCarouselGamesAsync();
                _cache.Set(cacheKey, games, cacheEntryOptions);

                return new JsonResult(games);
            }
            catch (Exception)
            {
                cancellationTokenSource.Cancel();
                throw;
            }
        }

        [HttpGet]
        [Route("GetAllGamesAsync")]
        public async Task<ActionResult<List<GameDTO>>> GetAllGames()
        {
            if (_cache.TryGetValue("AllGames", out List<GameDTO> cachedAllGames))
            {
                return new JsonResult(cachedAllGames);
            }

            var games = await _unitOfWork.GetAllGamesAsync();
            _cache.Set("AllGames", games, TimeSpan.FromMinutes(30));

            return new JsonResult(games);
        }

        [HttpGet]
        [Route("GetAllTagsAsync")]
        public async Task<ActionResult<List<TagDTO>>> GetAllTags()
        {
            var tags = await _unitOfWork.GetAllTagsAsync();

            return new JsonResult(tags);
        }
    }
}
