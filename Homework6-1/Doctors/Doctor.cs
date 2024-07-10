using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6_1.Doctors
{
    public abstract class Doctor
    {
        private ConsoleColor _color;
        public string Name { get; }
        public string Type { get; }

        protected Doctor(string name, string type, ConsoleColor color = ConsoleColor.Green)
        {
            Name = name;
            Type = type;
            _color = color;
        }

        public abstract void PerformHealing();

        protected void Say(string message)
        {
            ConsoleColor current = Console.ForegroundColor;
            Console.ForegroundColor = _color;

            Console.WriteLine($"{Name}, {Type}: {message}");
            Console.ForegroundColor = current;
            Thread.Sleep(500);
        }

        protected void Action(string action, bool useLoading = true)
        {
            Say($"*{action}*");

            if (useLoading)
                Loading();
        }

        protected void Loading()
        {
            ConsoleColor current = Console.ForegroundColor;
            Console.ForegroundColor = _color;
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(random.Next(100, 500));
                Console.Write("*");
            }

            Console.ForegroundColor = current;
        }
    }
}
