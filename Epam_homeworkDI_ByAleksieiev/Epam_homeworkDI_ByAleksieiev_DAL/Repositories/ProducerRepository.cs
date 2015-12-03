using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_homeworkDI_ByAleksieiev_DAL.Repositories
{
    public class ProducerRepository : IProducerRepository
    {
        private static List<ProducerEntity> producers;

        static ProducerRepository()
        {
            producers = new List<ProducerEntity>();
            producers.Add(new ProducerEntity()
            {
                Name = "Apple",
                Country = "USA",
                Popularity = 10
            });
            producers.Add(new ProducerEntity()
            {
                Name = "Lenovo",
                Country = "India",
                Popularity = 6
            });
            producers.Add(new ProducerEntity()
            {
                Name = "DELL",
                Country = "USA",
                Popularity = 8
            });
        }
        public List<ProducerEntity> GetAllProducers()
        {
            return producers;
        }
    }
}
