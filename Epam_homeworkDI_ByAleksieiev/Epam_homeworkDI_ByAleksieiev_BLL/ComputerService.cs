using Epam_homeworkDI_ByAleksieiev_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_homeworkDI_ByAleksieiev_BLL
{
    public class ComputerService
    {
        IComputerRepository database;
        public ComputerService(IComputerRepository repository)
        {
            database = repository;
        }

        public List<ComputerEntity> GetAllComputers()
        {
            return database.GetAllComputers();
        }

        public List<ComputerEntity> GetComputersByProducerName(string producer)
        {
            var computers = database.GetAllComputers().Where(c => c.Producer == producer);
            return computers.ToList();
        }

        public List<ComputerEntity> GetComputersByKeyWord(string keyWord)
        {
            var computers = database.GetAllComputers().Where(c => ((c.HardDrive == keyWord) || (c.CPU == keyWord) || (c.Model == keyWord) || (c.Producer == keyWord) || (c.RAM == keyWord) || (c.System == keyWord)));
            return computers as List<ComputerEntity>;
        }

        public void DeleteComputer(ComputerEntity computer)
        {
            database.DeleteComputer(computer);
        }
    }
}
