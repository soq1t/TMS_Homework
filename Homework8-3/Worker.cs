using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8_3
{
    internal class Worker : Employee
    {
        public Worker(string name, Company company)
            : base("Работник", name, company) { }
    }
}
