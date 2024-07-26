using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9_3
{
    internal class SportsCar : Car
    {
        public SportsCar(int initFuel = 0)
            : base(initFuel, 8, 100)
        {
            _velocity = 300;
        }
    }
}
