using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_homeworkDI_ByAleksieiev_DAL
{
    public class ProducerEntity
    {
        public string Name;
        public string Country;
        public double Popularity;

        public override string ToString()
        {
            return Name;
        }
    }
}
