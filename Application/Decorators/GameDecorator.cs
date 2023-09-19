using Application.ConstNamingCashes;
using Application.DTO;
using Application.InterfaceServices;
using Application.Utilits;
using Azure;
using IdentityModel.Client;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Decorators
{
    public class GameDecorator : IGameService
    {
        private readonly IGameService _gameService;
        private readonly IDistributedCache _cache;

        public GameDecorator(IGameService gameService,
            IDistributedCache cache)
        {
            _gameService = gameService;
            _cache = cache;
        }

        public async Task<List<GameDTO>> GamesByTagsAsync(string tag)
        {
            var cachedData = await _cache.GetAsync(CachesNaming.GamesByTags);

            if(cachedData != null)
            {
                return CachedData.DeserializeCachedData<List<GameDTO>>(cachedData);
            }

            var games = await _gameService.GamesByTagsAsync(tag);

            var serializedData = CachedData.SerializeData(games);
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                SlidingExpiration = TimeSpan.FromMinutes(1),
            };

            await _cache.SetAsync(CachesNaming.GamesByTags, serializedData, options);

            return games;
        }

        public async Task<List<GameDTO>> GetAllGamesAsync()
        {
            var cachedData = await _cache.GetAsync(CachesNaming.GetAllGames);

            if (cachedData != null)
            {
                return CachedData.DeserializeCachedData<List<GameDTO>>(cachedData);
            }

            var games = await _gameService.GetAllGamesAsync();

            var serializedData = CachedData.SerializeData(games);
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                SlidingExpiration = TimeSpan.FromMinutes(1),
            };

            await _cache.SetAsync(CachesNaming.GetAllGames, serializedData, options);

            return games;
        }

        public Task<List<TagDTO>> GetAllTagsAsync()
        {
            return _gameService.GetAllTagsAsync();
        }

        public Task<List<GameDTO>> GetCarouselGamesAsync()
        {
            return _gameService.GetCarouselGamesAsync();
        }

        public async Task<GamesViewDTO> GetGameAsync(int id)
        {
            var cachedData = await _cache.GetAsync(CachesNaming.Game);

            if (cachedData != null)
            {
                return CachedData.DeserializeCachedData<GamesViewDTO>(cachedData);
            }

            var game = await _gameService.GetGameAsync(id);

            var serializedData = CachedData.SerializeData(game);
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                SlidingExpiration = TimeSpan.FromMinutes(1),
            };

            await _cache.SetAsync(CachesNaming.Game, serializedData, options);

            return game;
        }

        public Task<List<GameDTO>> GetPagingGame()
        {
            return _gameService.GetPagingGame();
        }

        public async Task<List<GameDTO>> SearchGameAsync(string name)
        {
            var cachedData = await _cache.GetAsync(CachesNaming.SearchGame);

            if (cachedData != null)
            {
                return CachedData.DeserializeCachedData<List<GameDTO>>(cachedData);
            }

            var games = await _gameService.SearchGameAsync(name);

            var serializedData = CachedData.SerializeData(games);
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                SlidingExpiration = TimeSpan.FromMinutes(1),
            };

            await _cache.SetAsync(CachesNaming.SearchGame, serializedData, options);

            return games;
        }
    }
}
