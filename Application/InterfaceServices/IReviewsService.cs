using Application.DTO;

namespace Application.InterfaceServices
{
    public interface IReviewsService
    {
        Task<bool> AddReview(int gameId, string userId, string reviewText, int rating);
        Task<List<ReviewDto>> GetAllReviews(int page, int pageSize);
    }
}