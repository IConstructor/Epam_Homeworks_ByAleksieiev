using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_MVCTask1_ByAleksieiev_WEB
{
    public class Genre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Genre()
        {
            GENRE1 = new HashSet<Genre>();
            GAME = new HashSet<Game>();
        }

        public int GenrePK { get; set; }
        public string Name { get; set; }
        public int? ParentGenre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Genre> GENRE1 { get; set; }

        public virtual Genre GENRE2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Game> GAME { get; set; }
    }
}
