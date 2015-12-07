using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_MVCTask1_ByAleksieiev_WEB
{
    public class Comment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comment()
        {
            COMMENT1 = new HashSet<Comment>();
        }

        public int CommentPK { get; set; }

        public string Name { get; set; }

        public string Body { get; set; }

        public int? ParentComment { get; set; }

        public int? GameFK { get; set; }

        public virtual Game GAME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> COMMENT1 { get; set; }

        public virtual Comment COMMENT2 { get; set; }
    }
}
