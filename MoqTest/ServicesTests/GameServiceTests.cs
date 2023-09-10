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
            gameRepositoryMock.Setup(repo => repo.ListAsync(It.IsAny<Expression<Func<GamesEntity, bool>>>()))
                .ReturnsAsync(new List<GamesEntity>
                {
                    new GamesEntity { Id = 1, Name = "GameName", Price = 10.0m },
                    new GamesEntity { Id = 2, Name = "AnotherGame", Price = 15.0m }
                });

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(uow => uow.GetRepository<GamesEntity>(false)).Returns(gameRepositoryMock.Object);

            var gameService = new GameService(unitOfWorkMock.Object);

            // Act
            List<GameDTO> result = await gameService.SearchGame("GameName");

            // Assert
            Assert.Equal("GameName", result[0].Name);
            Assert.Equal(10.0m, result[0].Price);
        }

        [Fact]
        public async Task GetGame_ValidId_ReturnsGamesViewDTO()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var gameRepositoryMock = new Mock<IRepository<GamesEntity>>();
            var shortScreenshotRepositoryMock = new Mock<IRepository<ShortScreenshotEntity>>();
            var developersRepositoryMock = new Mock<IRepository<DevelopersEntity>>();
            var tagsRepositoryMock = new Mock<IRepository<TagEntity>>();
            var storeRepositoryMock = new Mock<IRepository<StoreEntity>>();
            var storeInfoRepositoryMock = new Mock<IRepository<StoreInfoEntity>>();

            unitOfWorkMock.Setup(uow => uow.GetRepository<GamesEntity>(false))
                .Returns(gameRepositoryMock.Object);

            unitOfWorkMock.Setup(uow => uow.GetRepository<ShortScreenshotEntity>(false))
                .Returns(shortScreenshotRepositoryMock.Object);

            unitOfWorkMock.Setup(uow => uow.GetRepository<DevelopersEntity>(false))
                .Returns(developersRepositoryMock.Object);

            unitOfWorkMock.Setup(uow => uow.GetRepository<TagEntity>(false))
                .Returns(tagsRepositoryMock.Object);

            unitOfWorkMock.Setup(uow => uow.GetRepository<StoreEntity>(false))
                .Returns(storeRepositoryMock.Object);

            unitOfWorkMock.Setup(uow => uow.GetRepository<StoreInfoEntity>(false))
                .Returns(storeInfoRepositoryMock.Object);

            var game = new GamesEntity
            {
                Id = 2,
                Name = "AnotherGame",
                Price = 15.0m,
                BackgroundImage = "image.jpg"
            };

            gameRepositoryMock.Setup(repo => repo.GetByIdAsync(2))
                .ReturnsAsync(game);

            var shortScreenshots = new List<ShortScreenshotEntity>
            {
                new ShortScreenshotEntity { Id = 1, Image = "screenshot1.jpg", Game = game },
                 new ShortScreenshotEntity { Id = 2, Image = "screenshot2.jpg", Game = game }
            };

            shortScreenshotRepositoryMock.Setup(repo => repo.ListAsync(It.IsAny<Expression<Func<ShortScreenshotEntity, bool>>>()))
                .ReturnsAsync(shortScreenshots);

            var developers = new List<DevelopersEntity>
            {
                new DevelopersEntity { Id = 1, Name = "Developer1" },
                new DevelopersEntity { Id = 2, Name = "Developer2" }
            
            };

            developersRepositoryMock.Setup(repo => repo.ListAsync(It.IsAny<Expression<Func<DevelopersEntity, bool>>>()))
                .ReturnsAsync(developers);

            var tags = new List<TagEntity>
            {
                new TagEntity { Id = 1, Name = "Tag1" },
                new TagEntity { Id = 2, Name = "Tag2" }
            
            };

            tagsRepositoryMock.Setup(repo => repo.ListAsync(It.IsAny<Expression<Func<TagEntity, bool>>>()))
                .ReturnsAsync(tags);

            var storeInfo = new StoreInfoEntity
            {
                Id = 1,
                Name = "Store1",
                Slug = "store1",
                Domain = "store1.com",
                GamesCount = 10,
                ImageBackground = "store1.jpg"
            };

            var store = new StoreEntity
            {
                Id = 1,
                Store = storeInfo,
            };

            storeRepositoryMock.Setup(repo => repo.ListAsync(It.IsAny<Expression<Func<StoreEntity, bool>>>()))
                .ReturnsAsync(new List<StoreEntity> { store });

            var gameService = new GameService(unitOfWorkMock.Object);

            // Act
            var result = await gameService.GetGame(2);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("AnotherGame", result.Name);
            Assert.Equal(15.0m, result.Price);
            Assert.Collection(result.Developers,
                name => Assert.Equal("Developer1", name),
                name => Assert.Equal("Developer2", name));
            Assert.Collection(result.Tags,
                tag => Assert.Equal("Tag1", tag),
                tag => Assert.Equal("Tag2", tag));
            Assert.Collection(result.Stores,
                storeName => Assert.Equal("Store1", storeName));
            Assert.Collection(result.ScrenShoots,
                screenshot => Assert.Equal("screenshot1.jpg", screenshot),
                screenshot => Assert.Equal("screenshot2.jpg", screenshot));
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

            var result = await gameService.GamesByTags("Tag1");

            Assert.NotNull(result);
            Assert.Equal("GameName", result[0].Name);
        }
    }
}
