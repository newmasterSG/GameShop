using Application.DTO;
using Application.InterfaceServices;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ApiSteam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameContoller: ControllerBase
    {
        private readonly GameService _gameService;
        private readonly IMemoryCache _cache;
        private readonly IHomeService _unitOfWork;
        public GameContoller(GameService gameService, IMemoryCache cache, IHomeService homeService)
        {
            _gameService = gameService;
            _cache = cache;
            _unitOfWork = homeService;
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

        [HttpGet]
        [Route("GetCarouselGames")]
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
                var games = await _unitOfWork.GetCarouselGames();
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
        [Route("GetAllGames")]
        public async Task<ActionResult<List<GameDTO>>> GetAllGames()
        {
            if (_cache.TryGetValue("AllGames", out List<GameDTO> cachedAllGames))
            {
                return new JsonResult(cachedAllGames);
            }

            var games = await _unitOfWork.GetAllGames();
            _cache.Set("AllGames", games, TimeSpan.FromMinutes(30));

            return new JsonResult(games);
        }

        [HttpGet]
        [Route("GetAllTags")]
        public async Task<ActionResult<List<TagDTO>>> GetAllTags()
        {
            var tags = await _unitOfWork.GetAllTags();

            return new JsonResult(tags);
        }
    }
}
