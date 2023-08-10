using Application.DTO;

namespace Application.Services
{
    public interface IHomeService
    {
        Task<List<GameDTO>> GetGames();
        Task<List<GameDTO>> GetCarouselGames();
        Task<List<GameDTO>> GetAllGames();
    }
}