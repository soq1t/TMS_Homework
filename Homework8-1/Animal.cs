using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8_1
{
    internal abstract class Animal
    {
        protected string Name { get; private set; }

        protected Animal(string Name) { }

        public void SetName() { }

        public void GetName() { }

        public void Eat() { }
    }
}
