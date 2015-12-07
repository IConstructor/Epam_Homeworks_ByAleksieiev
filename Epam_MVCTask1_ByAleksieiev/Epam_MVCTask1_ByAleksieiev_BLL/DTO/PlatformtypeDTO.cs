using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_MVCTask1_ByAleksieiev_BLL
{
    public class PlatformtypeDTO
    {
        public PlatformtypeDTO()
        {
            GAME = new List<GameDTO>();
        }

        public int PlatformtypePK { get; set; }

        public string Name { get; set; }
        public List<GameDTO> GAME { get; set; }
    }
}
