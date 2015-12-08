using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_MVCTask1_ByAleksieiev_DAL
{
    class ContextInitializer : CreateDatabaseIfNotExists<OnlineGameStoreContext>
    {
        protected override void Seed(OnlineGameStoreContext context)
        {
            var genre = new List<GENRE>();
            var g = new GENRE();
            g.Name = "Cyber Pank";

            var comments = new List<COMMENT>();
            var comment = new COMMENT();
            comment.Name = "First comment";
            comment.Body = "Cool game";
            comments.Add(comment);

            var platforms = new List<PLATFORMTYPE>();
            var plat = new PLATFORMTYPE();
            plat.Name = "PC";
            platforms.Add(plat);

            genre.Add(g);
            GAME game1 = new GAME {Name = "Deus Ex", Description = "This is the first game of Deus Ex created in July of 2000", GENRE = genre, COMMENT = comments, PLATFORMTYPE = platforms };

            context.GAME.Add(game1);
            context.SaveChanges();
        }
    }
}

