using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_MVCTask1_ByAleksieiev_DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<GAME> Games { get; }
        void Commit();
    }
}
