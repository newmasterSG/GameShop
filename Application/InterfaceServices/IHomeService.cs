using Application.DTO;

namespace Application.InterfaceServices
{
    public interface IHomeService
    {
        Task<List<GameDTO>> GetGames();
        Task<List<GameDTO>> GetCarouselGames();
        Task<List<GameDTO>> GetAllGames();

        Task<List<TagDTO>> GetAllTags();
    }
}