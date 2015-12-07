using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_MVCTask1_ByAleksieiev_BLL
{
    public class GameDTO
    {
        public GameDTO()
        {
            COMMENT = new List<CommentDTO>();
            GENRE = new List<GenreDTO>();
            PLATFORMTYPE = new List<PlatformtypeDTO>();
        }

        public int GamePK { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CommentDTO> COMMENT { get; set; }
        public List<GenreDTO> GENRE { get; set; }
        public List<PlatformtypeDTO> PLATFORMTYPE { get; set; }
    }
}
