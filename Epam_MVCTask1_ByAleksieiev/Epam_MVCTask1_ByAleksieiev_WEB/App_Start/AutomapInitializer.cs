using AutoMapper;
using Epam_MVCTask1_ByAleksieiev_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_MVCTask1_ByAleksieiev_WEB
{
    public static class AutomapInitializer
    {
        public static void Initialize()
        {
            Mapper.CreateMap<Game, GameDTO>();
            Mapper.CreateMap<Comment, CommentDTO>();
            Mapper.CreateMap<Genre, GenreDTO>();
            Mapper.CreateMap<Platformtype, PlatformtypeDTO>();

            Mapper.CreateMap<GameDTO, Game>();
            Mapper.CreateMap<CommentDTO, Comment>();
            Mapper.CreateMap<GenreDTO, Genre>();
            Mapper.CreateMap<PlatformtypeDTO, Platformtype>();
        }
    }
}
