using Application.DTO;

namespace Application.InterfaceServices
{
    public interface IGameService
    {
        Task<List<GameDTO>> GamesByTagsAsync(string tag);
        Task<GamesViewDTO> GetGameAsync(int id);
        Task<SearchResult<GameDTO>> SearchGameAsync(string name, int pageNumber, int pageSize, string attribute = "", string order = "asc");

        Task<List<GameDTO>> GetAllGamesAsync();

        Task<List<GameDTO>> GetCarouselGamesAsync();
        Task<List<GameDTO>> GetPagingGame();
        Task<List<TagDTO>> GetAllTagsAsync();
    }
}