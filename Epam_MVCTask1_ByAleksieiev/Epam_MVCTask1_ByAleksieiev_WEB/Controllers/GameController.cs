using AutoMapper;
using Epam_MVCTask1_ByAleksieiev_BLL;
using Epam_MVCTask1_ByAleksieiev_DAL;
using log4net;
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
    [PerformanceLogger]
    [OutputCache(Location = System.Web.UI.OutputCacheLocation.Client, NoStore = true)]
    [System.Web.Http.RoutePrefix("api/game")]
    public class GameController : ApiController
    {
        readonly IGameService _gameService;
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public GameController(IGameService gameService)
        {
            this._gameService = gameService;
        }
        // GET api/values/5
        [System.Web.Http.HttpPost]
        public void New([FromBody]Game value)
        {
            try
            {
                var result = Mapper.Map<Game, GameDTO>(value);
                _gameService.CreateGame(result);
                Log.Info(String.Format("New game was created. ID = {1}, Name = {0}", value.Name, value.GamePK));
            }
            catch(Exception exc)
            {
                Log.ErrorFormat(exc.ToString());
            }
        }


        // GET api/values/5
        [System.Web.Http.HttpPost]
        public void Remove([FromBody]Game value)
        {
            try{
                var result = Mapper.Map<Game, GameDTO>(value);
                _gameService.DeleteGame(result);
                Log.InfoFormat("Game:{0}, Id={1} was deleted by Remove(Game value) method.", value.Name, value.GamePK);
            }
            catch (Exception exc)
            {
                Log.ErrorFormat(exc.ToString());
            }
        }


        // GET api/values/5
        [System.Web.Http.HttpPost]
        public void Update([FromBody]Game value)
        {
            try {
                var result = Mapper.Map<Game, GameDTO>(value);
                _gameService.ModifyGame(result);
                Log.InfoFormat("Game:{0}, Id={1} was updated by Update(value) method.", value.Name, value.GamePK);
            }
            catch (Exception exc)
            {
                Log.ErrorFormat(exc.ToString());
            }
        }

        // GET api/values/5
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("{id}/newcomment")]
        public void Newcomment(int id, Comment comment)
        {
            try {
                var game = _gameService.GetGameById(id);
                var com = Mapper.Map<Comment, CommentDTO>(comment);
                game.COMMENT.Add(com);
                _gameService.ModifyGame(game);
                Log.InfoFormat("A new comment for game:{0}, Id={1} was addeded by Newcomment(int id, Comment comment) method.", game.Name, game.GamePK);
            }
            catch (Exception exc)
            {
                Log.ErrorFormat(exc.ToString());
            }
            
        }

        // GET api/values/5
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("{id}/comments")]
        public List<Comment> Comments(int id)
        {
            List<Comment> result = null;
            try
            {
                var game = _gameService.GetGameById(id);
                result = Mapper.Map<List<CommentDTO>, List<Comment>>(game.COMMENT);
                Log.InfoFormat("All comments of game:{0} were returned by Comments(int id) method. There are {0} comments", result.Count);

                for (int i = 0; i < result.Count; i++)
                {
                    Log.InfoFormat("COMMENT{2}: ID = {1}, Name = {0}", result[i].Name, result[i].CommentPK, i);
                }
            }
            catch (Exception exc)
            {
                Log.ErrorFormat(exc.ToString());
            }
                return result;
        }


        //get all games
        public IEnumerable<Game> Get()
        {
            List<Game> result = null;
            try {
                result = Mapper.Map<List<GameDTO>, List<Game>>(_gameService.GetAllGames());
                Log.InfoFormat("All games returned by Get() method. There are {0} games", result.Count);
                for (int i = 0; i < result.Count; i++)
                {
                    Log.InfoFormat("GAME{2}: ID = {1}, Name = {0}", result[i].Name, result[i].GamePK, i);
                }
            }
            catch (Exception exc)
            {
                Log.ErrorFormat(exc.ToString());
            }
            
            return result;
        }

        //GET api/values/5 //get details
        public Game Get(int id)
        {
            Game result = null;
            try {
                var game = _gameService.GetGameById(id);
                result = Mapper.Map<GameDTO, Game>(game);
                Log.InfoFormat("Game ID = {1}, Name = {0}", result.Name, result.GamePK);
            }
            catch (Exception exc)
            {
                Log.ErrorFormat(exc.ToString());
            }
            return result;
        }

        /// <summary>
        /// This method cannot be covered fully because of HttpContext which is not available from unit tests.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("{id}/download")]
        public HttpResponseMessage Download(int id)
        {
            HttpResponseMessage httpResponseMessage = null;
            try {
                httpResponseMessage = new HttpResponseMessage();
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
                Log.InfoFormat("Game with ID = {0} was downloaded", id);
            }
            catch (Exception exc)
            {
                Log.ErrorFormat(exc.ToString());
            }
            return httpResponseMessage;
        }
    }
}
