using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_MVCTask1_ByAleksieiev_DAL
{
    public class GameRepository : IRepository<GAME>
    {
        private OnlineGameStoreContext context;
        public GameRepository(OnlineGameStoreContext context)
        {
            this.context = context;
        }
        public void Add(GAME item)
        {
            context.GAME.Add(item);
        }

        public List<GAME> GetItems()
        {
            return context.GAME.Include("GENRE").Include("COMMENT").Include("PLATFORMTYPE").ToList();
        }

        public void Remove(GAME item)
        {
            context.GAME.Remove(item);
        }

        public void Update(GAME item)
        {
            var original = context.GAME.SingleOrDefault(p => p.GamePK == item.GamePK);
            if (original != null)
            {
                context.GAME.Remove(original);
                context.GAME.Add(item);
            }
        }
    }
}
