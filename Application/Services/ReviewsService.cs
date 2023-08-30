using Application.DTO;
using Application.InterfaceServices;
using Domain.Entities;
using Domain.Interfaces;
using Domain.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ReviewsService : IReviewsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReviewsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddReview(int gameId, string userId, string reviewText, int rating)
        {
            var game = _unitOfWork.GetRepository<GamesEntity>().Find(g => g.Id == gameId);

            if (game == null)
            {
                return false;
            }

            var review = new ReviewEntity
            {
                Content = reviewText,
                Rating = rating,
                DatePosted = DateTime.Now,
                UserId = userId,
                GameId = gameId
            };

            await _unitOfWork.GetRepository<ReviewEntity>().InsertAsync(review);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<List<ReviewDto>> GetAllReviews(int page, int pageSize)
        {
            var reviewDtos = new List<ReviewDto>();
            var reviews = await _unitOfWork.GetRepository<ReviewEntity>().GetAllAsync();
            reviews = reviews.Skip((page - 1) * pageSize)
                             .Take(pageSize)
                             .ToList();

            foreach (var review in reviews)
            {
                var user = _unitOfWork.GetRepository<UserEntity>().Find(u => u.Id == review.UserId);

                reviewDtos.Add(new ReviewDto
                {
                    Content = review.Content,
                    UserName = user.UserName,
                });
            }

            return reviewDtos;
        }
    }
}
