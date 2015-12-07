using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_MVCTask1_ByAleksieiev_DAL
{
    public interface IRepository<T>
    {
        List<T> GetItems();
        void Add(T item);
        void Remove(T item);
        void Update(T item);
        void Save();
    }
}
