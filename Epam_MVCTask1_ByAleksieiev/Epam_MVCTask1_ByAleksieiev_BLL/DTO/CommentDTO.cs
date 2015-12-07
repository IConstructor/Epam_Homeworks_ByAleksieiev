using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_MVCTask1_ByAleksieiev_BLL
{
    public class CommentDTO
    {
        public CommentDTO()
        {
            COMMENT1 = new List<CommentDTO>();
        }

        public int CommentPK { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public int? ParentComment { get; set; }
        public int? GameFK { get; set; }
        public GameDTO GAME { get; set; }
        public List<CommentDTO> COMMENT1 { get; set; }
    }
}
