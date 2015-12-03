using Epam_homeworkDI_ByAleksieiev_BLL;
using Epam_homeworkDI_ByAleksieiev_DAL;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLUnitTests
{
    [TestFixture]
    class ProducerServiceTest
    {
        [Test]
        public void GetProducers()
        {
            var producers = new List<ProducerEntity>();
            ProducerService producerService = new ProducerService(Mock.Of<IProducerRepository>(t => t.GetAllProducers() == producers));
            Assert.AreEqual(producers, producerService.GetAllProducers());
        }
    }
}
