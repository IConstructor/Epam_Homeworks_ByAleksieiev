namespace Epam_MVCTask1_ByAleksieiev_DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GENRE")]
    public partial class GENRE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GENRE()
        {
            GENRE1 = new HashSet<GENRE>();
            GAME = new HashSet<GAME>();
        }

        [Key]
        public int GenrePK { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? ParentGenre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GENRE> GENRE1 { get; set; }

        public virtual GENRE GENRE2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GAME> GAME { get; set; }
    }
}
