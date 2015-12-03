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
    class CustomerServiceTest
    {
        [Test]
        public void GetAllCustomersTest()
        {
            var customers = new List<CustomerEntity>();
            var customer = new CustomerEntity();
            customer.Email = "Test@epam.com";
            customers.Add(customer);

            var customerService = new CustomerService(Mock.Of<ICustomerRepository>(r => r.GetAllCustomers() == customers));

            Assert.AreEqual(customers, customerService.GetAllCustomers());
        }

        [Test]
        public void AddComputerTest()
        {
            var computer = new ComputerEntity();
            computer.Model = "ThinkPad";
            computer.Producer = "Lenovo";

            Mock<ICustomerRepository> mock = new Mock<ICustomerRepository>();
            var customerService = new CustomerService(mock.Object);

            customerService.AddComputer(0, computer);
            mock.Verify(r => r.AddComputer(It.IsAny<int>(), It.IsAny<ComputerEntity>()));
        }

    }
}
