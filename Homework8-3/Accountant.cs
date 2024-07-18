using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8_3
{
    internal class Accountant : Employee
    {
        public Accountant(string name, Company company)
            : base("Бухгалтер", name, company) { }
    }
}
