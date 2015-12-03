using Epam_homeworkDI_ByAleksieiev_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_homeworkDI_ByAleksieiev_BLL
{
    public class CustomerService
    {
        ICustomerRepository database;
        public CustomerService(ICustomerRepository repository)
        {
            database = repository;
        }

        public List<CustomerEntity> GetAllCustomers()
        {
            return database.GetAllCustomers();
        }

        public void AddComputer(int customerIndex, ComputerEntity computer)
        {
            database.AddComputer(customerIndex, computer);
        }

        public void ModificateUser(CustomerEntity customer)
        {
            database.UpdateUser(customer);
        }
    }
}
