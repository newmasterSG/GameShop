using Application.DTO;

namespace Application.InterfaceServices
{
    public interface IHomeService
    {
        Task<List<GameDTO>> GetGamesAsync();
        Task<List<GameDTO>> GetCarouselGamesAsync();
        Task<List<GameDTO>> GetAllGamesAsync();

        Task<List<TagDTO>> GetAllTagsAsync();
    }
}