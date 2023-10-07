using ApiSteam.Model;
using Application.InterfaceServices;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiSteam.Controllers
{
    [EnableCors("fromUI")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ILogger<ReviewsController> _logger;
        private readonly IReviewsService _reviewService;
        public ReviewsController(IReviewsService reviewService, 
            ILogger<ReviewsController> logger)
        {
            _reviewService = reviewService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews(int page = 1, int pageSize = 12)
        {
            var reviews = await _reviewService.GetAllReviewsAsync(page, pageSize);
            return Ok(reviews);
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> AddReview([FromBody] Review review)
        {
            _logger.LogDebug("Start");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { success = false, message = "You must be logged in to add a review." });
            }

            var success = await _reviewService.AddReviewAsync(review.gameId, userId, review.reviewText, review.rating);

            if (success)
            {
                return Ok(new { success = true, message = "Review added successfully." });
            }
            else
            {
                return NotFound(new { success = false, message = "Game not found." });
            }
        }

    }
}
