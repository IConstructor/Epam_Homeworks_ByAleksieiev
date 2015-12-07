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
            Mapper.CreateMap<GAME, GameDTO>();
            Mapper.CreateMap<COMMENT, CommentDTO>();
            Mapper.CreateMap<GENRE, GenreDTO>();
            Mapper.CreateMap<PLATFORMTYPE, PlatformtypeDTO>();

            Mapper.CreateMap<GameDTO, GAME>();
            Mapper.CreateMap<GenreDTO, GENRE>();
            Mapper.CreateMap<CommentDTO, COMMENT>();
            Mapper.CreateMap<PlatformtypeDTO, PLATFORMTYPE>();
        }
        public void CreateGame(GameDTO game)
        {
            var result = Mapper.Map<GameDTO, GAME>(game);
            database.Games.Add(result);
            database.Save();
        }

        public void DeleteGame(GameDTO game)
        {
            var result = Mapper.Map<GameDTO, GAME>(game);
            database.Games.Remove(result);
            database.Save();
        }

        public List<GameDTO> GetAllGames()
        {
            var result = new List<GameDTO>();
            result = Mapper.Map(database.Games.GetItems().ToList(),result);
            return result;
        }

        public GameDTO GetGameById(int id)
        {
            var result = Mapper.Map<GAME, GameDTO>(database.Games.GetItems().FirstOrDefault(t => t.GamePK == id));
            return result;
        }

        public void ModifyGame(GameDTO game)
        {
            var result = Mapper.Map<GameDTO, GAME>(game);
            database.Games.Update(result);
            database.Save();
        }
    }
}
