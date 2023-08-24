using Application.DTO;
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
    public class ReviewsService
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

        public async Task<List<ReviewDto>> GetAllReviews()
        {
            var reviewDtos = new List<ReviewDto>();
            var reviews = await _unitOfWork.GetRepository<ReviewEntity>().GetAllAsync();

            foreach(var review in reviews)
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
