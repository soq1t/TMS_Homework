using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9_2
{
    internal class Teacher : Person
    {
        public Teacher(string name, int age)
            : base(name, age) { }

        public Teacher(string name)
            : base(name) { }

        public Teacher(int age)
            : base(age) { }

        public Teacher() { }

        public void Explain() => Say("Объясняю новую тему");
    }
}
