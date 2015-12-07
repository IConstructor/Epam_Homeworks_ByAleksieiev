using AutoMapper;
using Epam_MVCTask1_ByAleksieiev_BLL;
using Epam_MVCTask1_ByAleksieiev_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Mapper.CreateMap<Game, GameDTO>();
            var result = Mapper.Map<Game, GameDTO>(value);
            gameService.CreateGame(result);
        }


        // GET api/values/5
        [System.Web.Http.HttpPost]
        public void Remove([FromBody]Game value)
        {
            Mapper.CreateMap<Game, GameDTO>();
            Mapper.CreateMap<Comment, CommentDTO>();
            Mapper.CreateMap<Genre, GenreDTO>();
            Mapper.CreateMap<Platformtype, PlatformtypeDTO>();
            var result = Mapper.Map<Game, GameDTO>(value);
            gameService.DeleteGame(result);
        }


        // GET api/values/5
        [System.Web.Http.HttpPost]
        public void Update([FromBody]Game value)
        {
            Mapper.CreateMap<Game, GameDTO>();
            Mapper.CreateMap<Comment, CommentDTO>();
            Mapper.CreateMap<Genre, GenreDTO>();
            Mapper.CreateMap<Platformtype, PlatformtypeDTO>();
            var result = Mapper.Map<Game, GameDTO>(value);
            gameService.ModifyGame(result);
        }


        // GET api/values/5
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("{id}/newcomment")]
        public void Newcomment(int id, Comment comment)
        {
            var game = gameService.GetGameById(id);
            Mapper.CreateMap<Comment, CommentDTO>();
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
            Mapper.CreateMap<GameDTO, Game>();
            Mapper.CreateMap<CommentDTO, Comment>();
            Mapper.CreateMap<GenreDTO, Genre>();
            Mapper.CreateMap<PlatformtypeDTO, Platformtype>();
            var result = Mapper.Map<List<CommentDTO>, List<Comment>>(game.COMMENT);
            return result;
        }


        //get all games
        public IEnumerable<Game> Get()
        {
            Mapper.CreateMap<GameDTO, Game>();
            Mapper.CreateMap<CommentDTO, Comment>();
            Mapper.CreateMap<GenreDTO, Genre>();
            Mapper.CreateMap<PlatformtypeDTO, Platformtype>();
            var result = Mapper.Map<List<GameDTO>, List<Game>>(gameService.GetAllGames()); 
            return result;
        }

        //GET api/values/5 //get details
        public Game Get(int id)
        {
            var game = gameService.GetGameById(id);
            Mapper.CreateMap<GameDTO, Game>();
            Mapper.CreateMap<CommentDTO, Comment>();
            Mapper.CreateMap<GenreDTO, Genre>();
            Mapper.CreateMap<PlatformtypeDTO, Platformtype>();
            var result = Mapper.Map<GameDTO, Game>(game);
            return result;
        }
    }
}
