using Application.DTO;
using Application.InterfaceServices;
using Domain.Entities;
using Domain.Entities.Games;
using Infrastructure.Context;
using Infrastructure.Repository.Interfaces;
using Infrastructure.UnitOfWork.Interface;
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

            var games = await _unitOfWork.GetRepository<GamesModel>()
        .ListAsync(x => x.Added_By_Status.Owned > 4000);

            foreach (var game in games)
            {
                gameDTOsForCarousel.Add(new GameDTO()
                {
                    Name = game.Name,
                    Image = game.Background_Image,
                    Owned = game.Added_By_Status?.Owned ?? 4000,
                    Price = (decimal)new Random().NextDouble(),
                });
            }

            return gameDTOsForCarousel;
        }

        public async Task<List<GameDTO>> GetAllGames()
        {
            List<GameDTO> gameDTOs = new List<GameDTO>();
            var games = await _unitOfWork.GetRepository<GamesModel>().TakeAsync(0, 12);
            foreach (var game in games)
            {
                gameDTOs.Add(new GameDTO()
                {
                    Name = game.Name,
                    Image = game.Background_Image,
                    Owned = game.Added_By_Status?.Owned ?? 4000,
                    Price = (decimal)new Random().NextDouble(),
                });
            }
            return gameDTOs;
        }

        public async Task<List<GameDTO>> GetGames()
        {
            List<GameDTO> gameDTOs = new List<GameDTO>();

            var games = await _unitOfWork.GetRepository<GamesModel>().GetAllAsync();

            foreach (var item in games)
            {
                gameDTOs.Add(new GameDTO()
                {
                    Name = item.Name,
                    Image = item.Background_Image,
                    Price = (decimal)new Random().NextDouble(),
                });
            }

            return gameDTOs;
        }
    }
}
