using Application.DTO;
using Application.InterfaceServices;
using Domain.Entities;
using Infrastructure.Context;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class HomeService : IHomeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GameDTO>> GetCarouselGamesAsync()
        {
            List<GameDTO> gameDTOsForCarousel = new List<GameDTO>();

            var games = await _unitOfWork.GetRepository<GamesEntity>()
        .ListAsync(x => x.AddedByStatus.Owned > 4000);

            foreach (var game in games)
            {
                gameDTOsForCarousel.Add(new GameDTO()
                {
                    Id = (int)game.Id,
                    Name = game.Name,
                    Image = game.BackgroundImage,
                    Owned = game.AddedByStatus?.Owned ?? 4000,
                    Price = game.Price,
                });
            }

            return gameDTOsForCarousel;
        }

        public async Task<List<GameDTO>> GetAllGamesAsync()
        {
            List<GameDTO> gameDTOs = new List<GameDTO>();
            var games = await _unitOfWork.GetRepository<GamesEntity>().TakeAsync(0, 12);
            foreach (var game in games)
            {
                gameDTOs.Add(new GameDTO()
                {
                    Id = (int)game.Id,
                    Name = game.Name,
                    Image = game.BackgroundImage,
                    Owned = game.AddedByStatus?.Owned ?? 4000,
                    Price = game.Price,
                });
            }
            return gameDTOs;
        }

        public async Task<List<GameDTO>> GetGamesAsync()
        {
            List<GameDTO> gameDTOs = new List<GameDTO>();

            var games = await _unitOfWork.GetRepository<GamesEntity>().GetAllAsync();

            foreach (var item in games)
            {
                gameDTOs.Add(new GameDTO()
                {
                    Id = (int)item.Id,
                    Name = item.Name,
                    Image = item.BackgroundImage,
                    Price = item.Price,
                });
            }

            return gameDTOs;
        }

        public async Task<List<TagDTO>> GetAllTagsAsync()
        {
            List<TagDTO> tags = new List<TagDTO>();

            var dbTags = await _unitOfWork.GetRepository<TagEntity>().GetAllAsync();

            foreach (var tag in dbTags)
            {
                tags.Add(new TagDTO()
                {
                    Name = tag.Name,
                    ImageBackground = tag.ImageBackground,
                });
            }

            return tags;
        }
    }
}
