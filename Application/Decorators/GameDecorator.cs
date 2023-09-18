using Application.DTO;
using Application.InterfaceServices;
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
        public GameDecorator(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task<List<GameDTO>> GamesByTagsAsync(string tag)
        {
            return await _gameService.GamesByTagsAsync(tag);
        }

        public async Task<List<GameDTO>> GetAllGamesAsync()
        {
            return await _gameService.GetAllGamesAsync();
        }

        public async Task<GamesViewDTO> GetGameAsync(int id)
        {
            return await _gameService.GetGameAsync(id);
        }

        public async Task<List<GameDTO>> SearchGameAsync(string name)
        {
            return await _gameService.SearchGameAsync(name);
        }
    }
}
