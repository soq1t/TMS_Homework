using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6_1
{
    public abstract class Person
    {
        protected ConsoleColor _color;
        public string Name { get; }

        public int Age { get; }

        protected Person(string name, int age, ConsoleColor color = ConsoleColor.Green)
        {
            Name = name;
            Age = age;
            _color = color;
        }

        public virtual void Introduce()
        {
            ConsoleColor current = Console.ForegroundColor;
            Console.ForegroundColor = _color;

            Console.WriteLine($"{Name}, Возраст: {Age}");
            Console.ForegroundColor = current;
        }
    }
}
