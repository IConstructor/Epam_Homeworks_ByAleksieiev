using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_MVCTask1_ByAleksieiev_BLL
{
    public class GenreDTO
    {
        public GenreDTO()
        {
            GENRE1 = new List<GenreDTO>();
            GAME = new List<GameDTO>();
        }

        public int GenrePK { get; set; }
        public string Name { get; set; }
        public int? ParentGenre { get; set; }
        public List<GenreDTO> GENRE1 { get; set; }
        public GenreDTO GENRE2 { get; set; }
        public List<GameDTO> GAME { get; set; }
    }
}
