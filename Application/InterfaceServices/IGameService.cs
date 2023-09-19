using Application.DTO;

namespace Application.InterfaceServices
{
    public interface IGameService
    {
        Task<List<GameDTO>> GamesByTagsAsync(string tag);
        Task<GamesViewDTO> GetGameAsync(int id);
        Task<List<GameDTO>> SearchGameAsync(string name);

        Task<List<GameDTO>> GetAllGamesAsync();

        Task<List<GameDTO>> GetCarouselGamesAsync();
        Task<List<GameDTO>> GetPagingGame();
        Task<List<TagDTO>> GetAllTagsAsync();
    }
}