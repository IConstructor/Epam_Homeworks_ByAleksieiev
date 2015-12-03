using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_homeworkDI_ByAleksieiev_DAL
{
    public interface IComputerRepository
    {
        List<ComputerEntity> GetAllComputers();

        void DeleteComputer(ComputerEntity computer);
    }
}
