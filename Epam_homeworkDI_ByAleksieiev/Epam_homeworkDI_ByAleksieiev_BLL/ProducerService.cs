using Epam_homeworkDI_ByAleksieiev_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_homeworkDI_ByAleksieiev_BLL
{
    public class ProducerService
    {
        IProducerRepository database;
        public ProducerService(IProducerRepository repository)
        {
            database = repository;
        }

        public List<ProducerEntity> GetAllProducers()
        {
            return database.GetAllProducers();
        }
    }
}
