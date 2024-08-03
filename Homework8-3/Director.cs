using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8_3
{
    internal class Director : Employee
    {
        public Director(string name, Company company)
            : base("Директор", name, company) { }
    }
}
