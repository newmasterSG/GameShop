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

        public async Task<List<GameDTO>> GamesByTags(string tag)
        {
            return await _gameService.GamesByTags(tag);
        }

        public async Task<GamesViewDTO> GetGame(int id)
        {
            return await _gameService.GetGame(id);
        }

        public async Task<List<GameDTO>> SearchGame(string name)
        {
            return await _gameService.SearchGame(name);
        }
    }
}
