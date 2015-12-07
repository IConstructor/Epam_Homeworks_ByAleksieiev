namespace Epam_MVCTask1_ByAleksieiev_DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OnlineGameStoreContext : DbContext
    {
        public OnlineGameStoreContext()
            : base("name=OnlineGameStoreContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<COMMENT> COMMENT { get; set; }
        public virtual DbSet<GAME> GAME { get; set; }
        public virtual DbSet<GENRE> GENRE { get; set; }
        public virtual DbSet<PLATFORMTYPE> PLATFORMTYPE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<COMMENT>()
                .HasMany(e => e.COMMENT1)
                .WithOptional(e => e.COMMENT2)
                .HasForeignKey(e => e.ParentComment);

            modelBuilder.Entity<GAME>()
                .HasMany(e => e.COMMENT)
                .WithOptional(e => e.GAME)
                .HasForeignKey(e => e.GameFK)
                .WillCascadeOnDelete();

            modelBuilder.Entity<GAME>()
                .HasMany(e => e.GENRE)
                .WithMany(e => e.GAME)
                .Map(m => m.ToTable("GENREGAME").MapLeftKey("GameFK").MapRightKey("GenreFK"));

            modelBuilder.Entity<GAME>()
                .HasMany(e => e.PLATFORMTYPE)
                .WithMany(e => e.GAME)
                .Map(m => m.ToTable("PLATFORMTYPESGAMES").MapLeftKey("GameFK").MapRightKey("PlatformtypeFK"));

            modelBuilder.Entity<GENRE>()
                .HasMany(e => e.GENRE1)
                .WithOptional(e => e.GENRE2)
                .HasForeignKey(e => e.ParentGenre);
        }
    }
}
