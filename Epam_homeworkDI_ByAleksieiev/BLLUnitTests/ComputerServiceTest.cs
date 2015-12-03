using Epam_homeworkDI_ByAleksieiev_BLL;
using Epam_homeworkDI_ByAleksieiev_DAL;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BLLUnitTests
{
    [TestFixture]
    public class ComputerServiceTest
    {
        [Test]
        public void GetAllComputersTest()
        {
            var computers = new List<ComputerEntity>();
            computers.Add(new ComputerEntity());
            ComputerService computerService = new ComputerService(Mock.Of<IComputerRepository>(c => c.GetAllComputers() == computers));
            Assert.AreEqual(computerService.GetAllComputers(),computers);
        }

        [Test]
        public void GetComputerByProducerNameTest()
        {
            var computers = new List<ComputerEntity>();
            var computer = new ComputerEntity();
            computer.Producer = "Apple";
            computers.Add(computer);
            ComputerService computerService = new ComputerService(Mock.Of<IComputerRepository>(c => c.GetAllComputers() == computers));
            Assert.AreEqual(computerService.GetComputersByProducerName("Apple"), computers);

        }
    }
}
