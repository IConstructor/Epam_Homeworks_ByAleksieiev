using AutoMapper;
using Epam_MVCTask1_ByAleksieiev_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_MVCTask1_ByAleksieiev_BLL
{
    public class GameService : IGameService
    {
        private IUnitOfWork database;
        public GameService(IUnitOfWork database)
        {
            this.database = database;
        }
        public void CreateGame(GameDTO game)
        {
            Mapper.CreateMap<GameDTO, GAME>();
            var result = Mapper.Map<GameDTO, GAME>(game);
            database.Games.Add(result);
            database.Save();
        }

        public void DeleteGame(GameDTO game)
        {
            Mapper.CreateMap<GameDTO, GAME>();
            var result = Mapper.Map<GameDTO, GAME>(game);
            database.Games.Remove(result);
            database.Save();
        }

        public List<GameDTO> GetAllGames()
        {
            Mapper.CreateMap<GAME, GameDTO>();
            Mapper.CreateMap<COMMENT, CommentDTO>();
            Mapper.CreateMap<GENRE, GenreDTO>();
            Mapper.CreateMap<PLATFORMTYPE, PlatformtypeDTO>();
            var result = new List<GameDTO>();
            result = Mapper.Map(database.Games.GetItems().ToList(),result);
            return result;
        }

        public GameDTO GetGameById(int id)
        {
            Mapper.CreateMap<GAME, GameDTO>();
            Mapper.CreateMap<COMMENT, CommentDTO>();
            Mapper.CreateMap<GENRE, GenreDTO>();
            Mapper.CreateMap<PLATFORMTYPE, PlatformtypeDTO>();
            var result = Mapper.Map<GAME, GameDTO>(database.Games.GetItems().FirstOrDefault(t => t.GamePK == id));
            return result;
        }

        public void ModifyGame(GameDTO game)
        {
            Mapper.CreateMap<GameDTO, GAME>();
            Mapper.CreateMap<GenreDTO, GENRE>();
            Mapper.CreateMap<CommentDTO, COMMENT>();
            Mapper.CreateMap<PlatformtypeDTO, PLATFORMTYPE>();
            var result = Mapper.Map<GameDTO, GAME>(game);
            database.Games.Update(result);
            database.Save();
        }
    }
}
