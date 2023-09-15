using Application.DTO;

namespace Application.InterfaceServices
{
    public interface IGameService
    {
        Task<List<GameDTO>> GamesByTags(string tag);
        Task<GamesViewDTO> GetGame(int id);
        Task<List<GameDTO>> SearchGame(string name);

        Task<List<GameDTO>> GetAllGames();
    }
}