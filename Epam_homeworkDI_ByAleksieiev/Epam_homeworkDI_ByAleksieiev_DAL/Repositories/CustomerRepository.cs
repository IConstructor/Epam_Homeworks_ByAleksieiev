using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_homeworkDI_ByAleksieiev_DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        static List<CustomerEntity> customers = new List<CustomerEntity>();

        static CustomerRepository()
        {
            customers.Add(new CustomerEntity()
            {
                Name = "Anton",
                Surname = "Ishakov",
                Age = 25,
                Email = "Ishak@epam.com",
                PhoneNumber = "380934457328",
                Computers = new List<ComputerEntity>(),
                Money = 2000
                });

            customers.Add(new CustomerEntity()
            {
                Name = "Denys",
                Surname = "Aleksieiev",
                Age = 21,
                Email = "Denys_aleksieiev@epam.com",
                PhoneNumber = "380934457254",
                Computers = new List<ComputerEntity>(),
                Money = 1500
            });

            customers.Add(new CustomerEntity()
            {
                Name = "Artem",
                Surname = "Koshkin",
                Age = 23,
                Email = "Artem_Koskin@epam.com",
                PhoneNumber = "380934457210",
                Computers = new List<ComputerEntity>(),
                Money = 2500
            });
        }

        
        public List<CustomerEntity> GetAllCustomers()
        {
            return customers;
        }

        public void AddComputer(int index, ComputerEntity computer)
        {
            customers[0].Computers.Add(computer);
        }

        public void UpdateUser(CustomerEntity customer)
        {
            int id = customers.FindIndex(t => t.Equals(customer));
            customers[id] = customer;
        }
    }
}
