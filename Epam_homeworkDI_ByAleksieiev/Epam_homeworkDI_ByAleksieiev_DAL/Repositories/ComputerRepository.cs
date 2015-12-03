using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_homeworkDI_ByAleksieiev_DAL
{
    public class ComputerRepository : IComputerRepository
    {
        static private  List<ComputerEntity> computers = new List<ComputerEntity>();

        static ComputerRepository()
        {
            computers.Add(new ComputerEntity()
            {
                Model = "IdeaPad",
                Producer = "Lenovo",
                HardDrive = "500 GB HDD",
                RAM = "8 GB",
                System = "Windows 10",
                CPU = "Intel Core i7",
                Price = 750
            });
            computers.Add(new ComputerEntity()
            {
                Model = "Mac Pro",
                Producer = "Apple",
                HardDrive = "500 GB HDD",
                RAM = "8 GB",
                System = "Windows 10",
                CPU = "Intel Core i7",
                Price = 800
            });
            computers.Add(new ComputerEntity()
            {
                Model = "Mac Pro 2",
                Producer = "Apple",
                HardDrive = "500 GB HDD",
                RAM = "8 GB",
                System = "Windows 10",
                CPU = "Intel Core i7",
                Price = 1000
            });
            computers.Add(new ComputerEntity()
            {
                Model = "ThinkPad E530",
                Producer = "Lenovo",
                HardDrive = "500 GB HDD",
                RAM = "8 GB",
                System = "Windows 10",
                CPU = "Intel Core i7",
                Price = 600
            });
            computers.Add(new ComputerEntity()
            {
                Model = "Mac2",
                Producer = "Apple",
                HardDrive = "500 GB HDD",
                RAM = "8 GB",
                System = "Windows 10",
                CPU = "Intel Core i7",
                Price = 1000
            });
            computers.Add(new ComputerEntity()
            {
                Model = "IdeaPad E660",
                Producer = "DELL",
                HardDrive = "500 GB HDD",
                RAM = "8 GB",
                System = "Windows 10",
                CPU = "Intel Core i7",
                Price = 750
            });
            computers.Add(new ComputerEntity()
            {
                Model = "HD432",
                Producer = "DELL",
                HardDrive = "500 GB HDD",
                RAM = "8 GB",
                System = "Windows 10",
                CPU = "Intel Core i7",
                Price = 800
            });
            computers.Add(new ComputerEntity()
            {
                Model = "BusinessPad",
                Producer = "Lenovo",
                HardDrive = "500 GB HDD",
                RAM = "8 GB",
                System = "Windows 10",
                CPU = "Intel Core i7",
                Price = 750
            });
        }

        public List<ComputerEntity> GetAllComputers()
        {
            return computers;
        }

        public void DeleteComputer(ComputerEntity computer)
        {
            computers.Remove(computer);
        }
    }
}
