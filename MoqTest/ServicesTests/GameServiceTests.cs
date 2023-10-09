using Application.DTO;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UI.Seedings;

namespace MoqTest.ServicesTests
{
    public class GameServiceTests
    {
        [Fact]
        public async Task SearchGame_ReturnsGames()
        {
            // Arrange
            var gameRepositoryMock = new Mock<IRepository<GamesEntity>>();
            gameRepositoryMock.Setup(repo => repo.Where(It.IsAny<Expression<Func<GamesEntity, bool>>>()))
                .Returns(new List<GamesEntity>
                {
                    new GamesEntity { Id = 1, Name = "GameName", Price = 10.0m },
                    new GamesEntity { Id = 2, Name = "AnotherGame", Price = 15.0m }
                }.AsQueryable());

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(uow => uow.GetRepository<GamesEntity>(false)).Returns(gameRepositoryMock.Object);

            var gameService = new GameService(unitOfWorkMock.Object);

            // Act
            var result = await gameService.SearchGameAsync("GameName", 1 , 12);

            // Assert
            Assert.Equal("GameName", result.Data[0].Name);
            Assert.Equal(10.0m, result.Data[0].Price);
        }

        [Fact]
        public async Task GetGamesByTags_ValidTag_ReturnsGamesDTO()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var gameRepositoryMock = new Mock<IRepository<GamesEntity>>();
            var tagsRepositoryMock = new Mock<IRepository<TagEntity>>();
            var gamesToTagsRepositoryMock = new Mock<IRepository<GamesToTagsEntity>>();

            unitOfWorkMock.Setup(uow => uow.GetRepository<GamesEntity>(false))
                .Returns(gameRepositoryMock.Object);
            unitOfWorkMock.Setup(uow => uow.GetRepository<TagEntity>(false))
                .Returns(tagsRepositoryMock.Object);
            unitOfWorkMock.Setup(uow => uow.GetRepository<GamesToTagsEntity>(false))
                .Returns(gamesToTagsRepositoryMock.Object);

            var tags = new List<TagEntity>
            {
                new TagEntity { Id = 1, Name = "Tag1" },
                new TagEntity { Id = 2, Name = "Tag2" }

            };

            gameRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int gameId) =>
                {
                    var game = new GamesEntity
                    {
                        Id = gameId,
                        Name = "GameName",
                        Price = 10.0m,
                        BackgroundImage = "image.jpg",
                        Tags = tags,
                    };
                    return game;
                });

            tagsRepositoryMock.Setup(repo => repo.List(It.IsAny<Expression<Func<TagEntity, bool>>>()))
              .Returns(tags);

            gamesToTagsRepositoryMock.Setup(repo => repo.ListAsync(It.IsAny<Expression<Func<GamesToTagsEntity, bool>>>()))
            .ReturnsAsync(new List<GamesToTagsEntity>
            {
                new GamesToTagsEntity { GamesId = 1, Tag = tags[0] },
                new GamesToTagsEntity { GamesId = 2, Tag = tags[0] },
            });

            var gameService = new GameService(unitOfWorkMock.Object);

            var result = await gameService.GamesByTagsAsync("Tag1");

            Assert.NotNull(result);
            Assert.Equal("GameName", result[0].Name);
        }
    }
}
