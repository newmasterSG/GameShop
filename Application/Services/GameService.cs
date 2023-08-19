﻿using Application.DTO;
using Domain.Entities;
using Domain.Entities.GamesToStore;
using Infrastructure.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GameService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GameService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GamesViewDTO> GetGame(int id)
        {
            if (id == null)
            {
                return null;
            }

            var game = await _unitOfWork.GetRepository<GamesEntity>().GetByIdAsync(id);

            var screenShoots = await _unitOfWork.GetRepository<ShortScreenshotEntity>().ListAsync(x => x.Game.Id == game.Id);

            var developers = await _unitOfWork.GetRepository<DevelopersEntity>()
                .ListAsync(x => x.GamesToDevelopers.Any(gtd => gtd.GameId == game.Id));

            var tags = await _unitOfWork.GetRepository<TagEntity>()
                .ListAsync(x => x.ToTagsModels.Any(gtd => gtd.GamesId == game.Id));

            var store = await _unitOfWork.GetRepository<StoreEntity>()
                .ListAsync(x => x.GamesToStores.Any(gtd => gtd.GameId == game.Id));

            GamesViewDTO gamesView = new GamesViewDTO()
            {
                Name = game.Name,
                Price = (decimal)new Random().NextDouble(),
                Developers = developers.Select(x => x.Name).ToList(),
                ScrenShoots = screenShoots.Select(x => x.Image).ToList(),
                Tags = tags.Select(x => x.Name).ToList(),
                Image = game.Background_Image,
                Stores = store.Select(x => x.Store?.Name).ToList(),
            };

            return gamesView;
        }

        public async Task<List<GameDTO>> SearchGame(string name)
        {
            var dbGames =  await _unitOfWork.GetRepository<GamesEntity>().ListAsync(g => g.Name == name);
            var games = new List<GameDTO>();
            foreach(var game in dbGames)
            {
                games.Add(new GameDTO
                {
                    Id = (int)game.Id,
                    Name = game.Name,
                    Image = game.Background_Image,
                    Owned = game.Added_By_Status?.Owned ?? 4000,
                    Price = (decimal)new Random().NextDouble(),
                });
            }

            return games;
        }
    }
}
