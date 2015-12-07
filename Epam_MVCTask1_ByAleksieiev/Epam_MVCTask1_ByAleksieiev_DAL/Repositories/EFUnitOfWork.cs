using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_MVCTask1_ByAleksieiev_DAL
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private OnlineGameStoreContext context = new OnlineGameStoreContext();
        IRepository<GAME> gameRepository;
        public IRepository<GAME> Games
        {
            get
            {
                if (gameRepository == null)
                {
                    gameRepository = new GameRepository(context);
                }
                return gameRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
