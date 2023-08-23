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
    }
}
