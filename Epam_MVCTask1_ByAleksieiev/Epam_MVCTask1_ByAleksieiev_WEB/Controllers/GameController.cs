using AutoMapper;
using Epam_MVCTask1_ByAleksieiev_BLL;
using Epam_MVCTask1_ByAleksieiev_DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Epam_MVCTask1_ByAleksieiev_WEB.Controllers
{
    [System.Web.Http.RoutePrefix("api/game")]
    public class GameController : ApiController
    {
        IGameService gameService;
        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }
        // GET api/values/5
        [System.Web.Http.HttpPost]
        public void New([FromBody]Game value)
        {
            var result = Mapper.Map<Game, GameDTO>(value);
            gameService.CreateGame(result);
        }


        // GET api/values/5
        [System.Web.Http.HttpPost]
        public void Remove([FromBody]Game value)
        {
            var result = Mapper.Map<Game, GameDTO>(value);
            gameService.DeleteGame(result);
        }


        // GET api/values/5
        [System.Web.Http.HttpPost]
        public void Update([FromBody]Game value)
        {
            var result = Mapper.Map<Game, GameDTO>(value);
            gameService.ModifyGame(result);
        }


        // GET api/values/5
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("{id}/newcomment")]
        public void Newcomment(int id, Comment comment)
        {
            var game = gameService.GetGameById(id);
            var com = Mapper.Map<Comment, CommentDTO>(comment);
            game.COMMENT.Add(com);
            gameService.ModifyGame(game);
        }

        // GET api/values/5
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("{id}/comments")]
        public List<Comment> Comments(int id)
        {
            var game = gameService.GetGameById(id);
            var result = Mapper.Map<List<CommentDTO>, List<Comment>>(game.COMMENT);
            return result;
        }


        //get all games
        public IEnumerable<Game> Get()
        {
            var result = Mapper.Map<List<GameDTO>, List<Game>>(gameService.GetAllGames()); 
            return result;
        }

        //GET api/values/5 //get details
        public Game Get(int id)
        {
            var game = gameService.GetGameById(id);
            var result = Mapper.Map<GameDTO, Game>(game);
            return result;
        }


        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("{id}/download")]
        public HttpResponseMessage Download(int id)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
            string filePath = HttpContext.Current.Server.MapPath("~/Content/") + @"file.txt";
            MemoryStream memoryStream = new MemoryStream();
            FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[file.Length];
            file.Read(bytes, 0, (int)file.Length);
            memoryStream.Write(bytes, 0, (int)file.Length);
            file.Close();
            httpResponseMessage.Content = new ByteArrayContent(memoryStream.ToArray());
            httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            httpResponseMessage.StatusCode = HttpStatusCode.OK;
            return httpResponseMessage;
        }
    }
}
