using Application.DTO;
using Domain.Entities.Developer;
using Domain.Entities.Games;
using Domain.Entities.GamesToStore;
using Domain.Entities.ShortScreenshot;
using Domain.Entities.Store;
using Domain.Entities.Tags;
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

            var game = await _unitOfWork.GetRepository<GamesModel>().GetByIdAsync(id);

            var screenShoots = await _unitOfWork.GetRepository<ShortScreenshotModel>().ListAsync(x => x.Game.Id == game.Id);

            var developers = await _unitOfWork.GetRepository<DevelopersModel>()
                .ListAsync(x => x.GamesToDevelopers.Any(gtd => gtd.GameId == game.Id));

            var tags = await _unitOfWork.GetRepository<TagModel>()
                .ListAsync(x => x.ToTagsModels.Any(gtd => gtd.GamesId == game.Id));

            var store = await _unitOfWork.GetRepository<StoreModel>()
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
    }
}
