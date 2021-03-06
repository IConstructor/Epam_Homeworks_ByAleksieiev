﻿using Epam_MVCTask1_ByAleksieiev_BLL;
using Moq;
using Epam_MVCTask1_ByAleksieiev_DAL;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Epam_MVCTask1_ByAleksieiev_WEB.Controllers;
using Epam_MVCTask1_ByAleksieiev_WEB;
using System.Net.Http;
using System;

namespace Epam_MVCTask1_ByAleksieiev_UnitTests
{
    [TestClass]
    public class GameControllerTests
    {
        public GameControllerTests()
        {
            AutomapInitializer.Initialize();
        }
        [TestMethod]
        public void NewTest_WithGameToCreated_ShouldCreate()
        {
            Mock<IGameService> mock = new Mock<IGameService>();
            GameController controller = new GameController(mock.Object);
            controller.New(new Epam_MVCTask1_ByAleksieiev_WEB.Game());

            mock.Verify(a => a.CreateGame(It.IsAny<GameDTO>()));
        }

        [TestMethod]
        public void RemoveTest_WithGameToRemove_ShouldRemove()
        {
            Mock<IGameService> mock = new Mock<IGameService>();
            GameController controller = new GameController(mock.Object);
            controller.Remove(new Epam_MVCTask1_ByAleksieiev_WEB.Game());

            mock.Verify(a => a.DeleteGame(It.IsAny<GameDTO>()));
        }

        [TestMethod]
        public void UpdateTest_WithModificatedGame_ShouldUpdate()
        {
            Mock<IGameService> mock = new Mock<IGameService>();
            GameController controller = new GameController(mock.Object);
            controller.Update(new Epam_MVCTask1_ByAleksieiev_WEB.Game());

            mock.Verify(a => a.ModifyGame(It.IsAny<GameDTO>()));
        }

        [TestMethod]
        public void NewcommentTest_WithGamesId_ShouldCreateNewComment()
        {
            Mock<IGameService> mock = new Mock<IGameService>();
            Mock<GameDTO> game = new Mock<GameDTO>();
            mock.Setup(t => t.GetGameById(It.IsAny<int>())).Returns(game.Object);
            GameController controller = new GameController(mock.Object);

            controller.Newcomment(It.IsAny<int>(),It.IsAny<Comment>());

            mock.Verify(a => a.GetGameById(It.IsAny<int>()));
            mock.Verify(a => a.ModifyGame(It.IsAny<GameDTO>()));

        }

        [TestMethod]
        public void CommentsTest_WithGamesId_ShouldReturnComments()
        {
            Mock<IGameService> mock = new Mock<IGameService>();
            Mock<GameDTO> game = new Mock<GameDTO>();
            mock.Setup(t => t.GetGameById(It.IsAny<int>())).Returns(game.Object);
            GameController controller = new GameController(mock.Object);

            List<Comment> comments = controller.Comments(It.IsAny<int>());
            mock.Verify(a => a.GetGameById(It.IsAny<int>()));
        }


        [TestMethod]
        public void GetTest_ByDefault_SHouldReturnGames()
        {
            Mock<IGameService> mock = new Mock<IGameService>();
            GameController controller = new GameController(mock.Object);
            var list = controller.Get();
            mock.Verify(a => a.GetAllGames());
        }

        [TestMethod]
        public void GetByIdTest_WithGamesId_ShouldReturnGame()
        {
            Mock<IGameService> mock = new Mock<IGameService>();
            GameController controller = new GameController(mock.Object);
            var list = controller.Get(It.IsAny<int>());
            mock.Verify(a => a.GetGameById(It.IsAny<int>()));
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(NullReferenceException))]
        public void DownloadTest_SimpleSituation_ExpectedException()
        {
            Mock<IGameService> mock = new Mock<IGameService>();
            GameController controller = new GameController(mock.Object);
            HttpResponseMessage response = controller.Download(It.IsAny<int>());
        }
    }
}
