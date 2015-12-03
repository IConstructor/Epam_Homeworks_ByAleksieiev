using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_homeworkDI_ByAleksieiev_DAL
{
    public class ComputerEntity 
    {
        public string Model;
        public string Producer;
        public string System;
        public string HardDrive;
        public string RAM;
        public string CPU;
        public decimal Price;

        public override string ToString()
        {
            return Model + " " + Producer;
        }
    }
}
