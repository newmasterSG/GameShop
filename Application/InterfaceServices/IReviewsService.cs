using Application.DTO;

namespace Application.InterfaceServices
{
    public interface IReviewsService
    {
        Task<bool> AddReviewAsync(int gameId, string userId, string reviewText, int rating);
        Task<List<ReviewDto>> GetAllReviewsAsync(int page, int pageSize);
    }
}