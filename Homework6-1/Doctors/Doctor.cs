using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6_1.Doctors
{
    public abstract class Doctor : Person
    {
        public string Type { get; }

        protected Doctor(string name, int age, string type, ConsoleColor color = ConsoleColor.Green)
            : base(name, age, color)
        {
            Type = type;
        }

        public override string DisplayedName => $"[{Type}] {Name}, Возраст: {Age}";

        public abstract void PerformHealing();

        public override void Introduce()
        {
            base.Introduce();
            ConsoleColor current = Console.ForegroundColor;
            Console.ForegroundColor = _color;

            Console.WriteLine($"Профессия: {Type}");
            Console.ForegroundColor = current;
        }

        protected void Say(string message)
        {
            ConsoleColor current = Console.ForegroundColor;
            Console.ForegroundColor = _color;

            Console.WriteLine();
            Console.WriteLine($"[{Type}] {Name}: {message}");
            Console.ForegroundColor = current;
            Thread.Sleep(500);
        }

        protected void Action(string action, bool useLoading = true)
        {
            Say($"*{action}*");

            if (useLoading)
                Loading();
        }

        protected void Loading(int length = 10)
        {
            ConsoleColor current = Console.ForegroundColor;
            Console.ForegroundColor = _color;
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                Thread.Sleep(random.Next(1, 300));
                Console.Write("><><");
            }
            Console.WriteLine();

            Console.ForegroundColor = current;
        }
    }
}
