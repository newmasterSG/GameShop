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

        public async Task<List<GameDTO>> GetCarouselGames()
        {
            List<GameDTO> gameDTOsForCarousel = new List<GameDTO>();

            var games = await _unitOfWork.GetRepository<GamesEntity>()
        .ListAsync(x => x.Added_By_Status.Owned > 4000);

            foreach (var game in games)
            {
                gameDTOsForCarousel.Add(new GameDTO()
                {
                    Id = (int)game.Id,
                    Name = game.Name,
                    Image = game.Background_Image,
                    Owned = game.Added_By_Status?.Owned ?? 4000,
                    Price = game.Price,
                });
            }

            return gameDTOsForCarousel;
        }

        public async Task<List<GameDTO>> GetAllGames()
        {
            List<GameDTO> gameDTOs = new List<GameDTO>();
            var games = await _unitOfWork.GetRepository<GamesEntity>().TakeAsync(0, 12);
            foreach (var game in games)
            {
                gameDTOs.Add(new GameDTO()
                {
                    Id = (int)game.Id,
                    Name = game.Name,
                    Image = game.Background_Image,
                    Owned = game.Added_By_Status?.Owned ?? 4000,
                    Price = game.Price,
                });
            }
            return gameDTOs;
        }

        public async Task<List<GameDTO>> GetGames()
        {
            List<GameDTO> gameDTOs = new List<GameDTO>();

            var games = await _unitOfWork.GetRepository<GamesEntity>().GetAllAsync();

            foreach (var item in games)
            {
                gameDTOs.Add(new GameDTO()
                {
                    Id = (int)item.Id,
                    Name = item.Name,
                    Image = item.Background_Image,
                    Price = item.Price,
                });
            }

            return gameDTOs;
        }
    }
}
