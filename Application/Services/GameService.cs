﻿using Application.DTO;
using Application.InterfaceServices;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GameService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GamesViewDTO> GetGameAsync(int id)
        {
            if (id == null)
            {
                return null;
            }

            var game = _unitOfWork.GetRepository<GamesEntity>()
                .AsNoTracking()
                .Include(item => item.Stores)
                .ThenInclude(store => store.Store)
                .Include(item => item.Developer)
                .Include(item => item.ShortScreenshots)
                .Include(item => item.Tags)
                .FirstOrDefault(item => item.Id == id);

            GamesViewDTO gamesView = new GamesViewDTO();

            if (game != null)
            {
                GamesViewDTO gamesViewDTO = new GamesViewDTO()
                {
                    Name = game.Name,
                    Price = game.Price,
                    Developers = game.Developer?.Select(x => x.Name).ToList(),
                    ScrenShoots = game.ShortScreenshots?.Select(x => x.Image).ToList(),
                    Tags = game.Tags?.Select(x => x.Name).ToList(),
                    Image = game.BackgroundImage,
                    Stores = game.Stores?.Select(x => x.Store?.Name).ToList(),
                };

                gamesView = gamesViewDTO;
            }

            return gamesView;
        }

        public async Task<SearchResult<GameDTO>> SearchGameAsync(string name, int pageNumber, int pageSize)
        {
            // Calculate the number of elements to skip based on the page number and page size
            int skipElements = (pageNumber - 1) * pageSize;

            var dbGames = _unitOfWork.GetRepository<GamesEntity>()
                .Where(item => item.Name.ToUpper().Contains(name.ToUpper()));

            int totalCount = dbGames.Count();

            var pagingGames = dbGames
                .Skip(skipElements)
                .Take(pageSize)
                .ToList();

            var games = new List<GameDTO>();

            if(pagingGames.Count() > 0)
            {
                foreach (var game in pagingGames)
                {
                    games.Add(new GameDTO
                    {
                        Id = (int)game.Id,
                        Name = game.Name,
                        Image = game.BackgroundImage,
                        Owned = game.AddedByStatus?.Owned ?? 4000,
                        Price = game.Price,
                    });
                }
            }

            var searchResult = new SearchResult<GameDTO>
            {
                Data = games,
                GameName = name,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return searchResult;
        }

        public async Task<List<GameDTO>> GamesByTagsAsync(string tag)
        {
            var games = new List<GameDTO>();

            // Find the tag entity in the database
            var dbTag = _unitOfWork.GetRepository<TagEntity>().List(t => t.Name == tag).FirstOrDefault();

            if (dbTag != null)
            {
                // Get the games associated with the tag
                var gamesToTagsRepo = _unitOfWork.GetRepository<GamesToTagsEntity>();
                var dbGamesToTags = await gamesToTagsRepo.ListAsync(gt => gt.Tag.Name == dbTag.Name);

                // Extract the Game entities from GamesToTagsEntity
                var dbGamesId = dbGamesToTags.Select(gt => gt.GamesId);
                var gameRepo = _unitOfWork.GetRepository<GamesEntity>();

                foreach (var game in dbGamesId)
                {
                    var g = await gameRepo.GetByIdAsync(game.Value);
                    if(g != null)
                    {
                        games.Add(new GameDTO
                        {
                            Id = (int)g.Id,
                            Image = g.BackgroundImage,
                            Name = g.Name,
                            Owned = g.AddedByStatus?.Owned ?? 4000,
                            Price = g.Price,
                        });
                    }
                }
            }

            return games;
        }

        public async Task<List<GameDTO>> GetAllGamesAsync()
        {
            var DbGames = await _unitOfWork.GetRepository<GamesEntity>()
                        .GetAllAsync();
            
            var games = DbGames.Select(game => new GameDTO
            {
                Id = (int)game.Id,
                Name = game.Name,
                Image = game.BackgroundImage,
                Owned = game.AddedByStatus?.Owned ?? 4000,
                Price = game.Price,
            })
            .ToList();

            return games;
        }

        public async Task<List<GameDTO>> GetCarouselGamesAsync()
        {
            List<GameDTO> gameDTOsForCarousel = new List<GameDTO>();

            var games = _unitOfWork.GetRepository<GamesEntity>()
                .SelectInclude(a => a.AddedByStatus)
                .Where(item => (int)item.AddedByStatus.Owned > 4000);

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

        public async Task<List<GameDTO>> GetPagingGame()
        {
            List<GameDTO> gameDTOs = new List<GameDTO>();
            var games = _unitOfWork.GetRepository<GamesEntity>().SelectInclude(a => a.AddedByStatus).Take(12);
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
