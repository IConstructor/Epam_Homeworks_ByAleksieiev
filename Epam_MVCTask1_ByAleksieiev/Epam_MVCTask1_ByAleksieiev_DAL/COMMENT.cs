namespace Epam_MVCTask1_ByAleksieiev_DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COMMENT")]
    public partial class COMMENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COMMENT()
        {
            COMMENT1 = new HashSet<COMMENT>();
        }
        [Key]
        public int CommentPK { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public string Body { get; set; }

        public int? ParentComment { get; set; }

        public int? GameFK { get; set; }

        public virtual GAME GAME { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMMENT> COMMENT1 { get; set; }
        public virtual COMMENT COMMENT2 { get; set; }
    }
}
