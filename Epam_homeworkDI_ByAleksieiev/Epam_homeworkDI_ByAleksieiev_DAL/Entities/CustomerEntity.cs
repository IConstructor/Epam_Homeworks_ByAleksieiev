using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_homeworkDI_ByAleksieiev_DAL
{
    public class CustomerEntity
    {
        public string Name;
        public string Surname;
        public int Age;
        public string PhoneNumber;
        public string Email;
        public List<ComputerEntity> Computers;
        public decimal Money;

        public override string ToString()
        {
            return Name + " " + Surname;
        }

        public override bool Equals(object obj)
        {
            CustomerEntity entity = obj as CustomerEntity;
            return entity != null && this.Email == entity.Email;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
