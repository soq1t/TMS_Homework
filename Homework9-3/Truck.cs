using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9_3
{
    internal class Truck : Car
    {
        public Truck(int initFuel = 0)
            : base(initFuel, 15, 300)
        {
            _velocity = 800;
        }
    }
}
