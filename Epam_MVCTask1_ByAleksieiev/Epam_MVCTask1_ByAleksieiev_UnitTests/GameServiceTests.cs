using System;
using Epam_MVCTask1_ByAleksieiev_BLL;
using Moq;
using Epam_MVCTask1_ByAleksieiev_DAL;
using System.Collections.Generic;
using AutoMapper;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epam_MVCTask1_ByAleksieiev_UnitTests
{
    [TestClass]
    public class GameServiceTests
    {
        public GameServiceTests()
        {
            Mapper.CreateMap<GAME, GameDTO>();
            Mapper.CreateMap<COMMENT, CommentDTO>();
            Mapper.CreateMap<GENRE, GenreDTO>();
            Mapper.CreateMap<PLATFORMTYPE, PlatformtypeDTO>();
        }
        
        [TestMethod]
        public void GetAllGamesTest_ByDefault_ShouldReturnAllGames()
        {
            List<GAME> games = new List<GAME>();
            var game = new GAME();
            game.Name = "Deus ex";
            game.GamePK = 1;
            game.Description = "The best game";
            games.Add(game);
            GameService gameService = new GameService(Mock.Of<IUnitOfWork>(t => t.Games.GetItems() == games));

            var resultGames = Mapper.Map<List<GAME>, List<GameDTO>>(games);
            Assert.IsTrue(gameService.GetAllGames()[0].GamePK == resultGames[0].GamePK);
        }

        [TestMethod]
        public void GetGameByIdTest_WithGamesId_ShouldReturnGame()
        {
            List<GAME> games = new List<GAME>();
            var game = new GAME();
            game.Name = "Deus ex";
            game.GamePK = 1;
            game.Description = "The best game";
            games.Add(game);
            GameService gameService = new GameService(Mock.Of<IUnitOfWork>(t => t.Games.GetItems() == games));

            var result= Mapper.Map<GAME, GameDTO>(game);
            Assert.IsTrue(gameService.GetGameById(1).GamePK == result.GamePK);
        }


        [TestMethod]
        public void CreateGameTest_WithGameToCreate_ShouldInvokeMethodAddInRepository()
        {
            List<GAME> games = new List<GAME>();
            var game = new GAME();
            game.Name = "Deus ex";
            game.GamePK = 1;
            game.Description = "The best game";
            games.Add(game);
            Mock<IRepository<GAME>> rep = new Mock<IRepository<GAME>>();
             
            var mock = Mock.Of<IUnitOfWork>(t=>t.Games == rep.Object);
            GameService gameService = new GameService(mock);
            
            var result = Mapper.Map<GAME, GameDTO>(game);
            gameService.CreateGame(result);
            rep.Verify(r => r.Add(It.IsAny<GAME>()));
        }

        [TestMethod]
        public void DeleteGameTest_WithGameToDelete_ShouldInvokeRepositoryMethodRemove()
        {
            List<GAME> games = new List<GAME>();
            var game = new GAME();
            game.Name = "Deus ex";
            game.GamePK = 1;
            game.Description = "The best game";
            games.Add(game);
            Mock<IRepository<GAME>> rep = new Mock<IRepository<GAME>>();

            var mock = Mock.Of<IUnitOfWork>(t => t.Games == rep.Object);
            GameService gameService = new GameService(mock);

            var result = Mapper.Map<GAME, GameDTO>(game);
            gameService.DeleteGame(result);
            rep.Verify(r => r.Remove(It.IsAny<GAME>()));
        }

        [TestMethod]
        public void UpdateGameTest_WithGameToUpdate_ShouldInvokeRepositoryMethodModify()
        {
            List<GAME> games = new List<GAME>();
            var game = new GAME();
            game.Name = "Deus ex";
            game.GamePK = 1;
            game.Description = "The best game";
            games.Add(game);
            Mock<IRepository<GAME>> rep = new Mock<IRepository<GAME>>();

            var mock = Mock.Of<IUnitOfWork>(t => t.Games == rep.Object);
            GameService gameService = new GameService(mock);

            var result = Mapper.Map<GAME, GameDTO>(game);
            gameService.ModifyGame(result);
            rep.Verify(r => r.Update(It.IsAny<GAME>()));
        }
    }
}
