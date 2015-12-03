using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_homeworkDI_ByAleksieiev_DAL
{
    public interface ICustomerRepository
    {
        List<CustomerEntity> GetAllCustomers();

        void AddComputer(int index, ComputerEntity computer);
        void UpdateUser(CustomerEntity customer);
    }
}
