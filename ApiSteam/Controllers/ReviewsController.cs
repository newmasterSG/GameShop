﻿using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiSteam.Controllers
{
    [ApiController]
    public class ReviewsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAllReviews(int page = 1, int pageSize = 12)
        {
            var reviews = await _reviewService.GetAllReviews(page, pageSize);
            return Ok(reviews);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddReview(int gameId, string reviewText, int rating)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest(new { success = false, message = "You must be logged in to add a review." });
            }

            var success = await _reviewService.AddReview(gameId, userId, reviewText, rating);

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