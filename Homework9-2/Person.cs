using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHomeworkToolkit;

namespace Homework9_2
{
    internal class Person
    {
        private static List<string> _greetings = new List<string>()
        {
            "Привет!",
            "Здравствуйте!",
            "Доброе утро!",
            "Добрый день!",
            "Добрый вечер!",
            "Как дела?",
            "Рад вас видеть!",
            "Приветствую!",
            "Доброго времени суток!",
            "Салют!"
        };

        private string RandomGreeting()
        {
            Random random = new Random();
            return _greetings[random.Next(0, _greetings.Count)];
        }

        private string _name;
        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrEmpty(_name))
                    ConsoleUtility.PrintError("Имя не может быть пустым!");
                else
                    _name = value;
            }
        }
        private int _age;
        public int Age
        {
            get => _age;
            private set
            {
                if (_age < 0)
                    ConsoleUtility.PrintError("Возраст не может быть отрицательным значением!");
                else
                    _age = value;
            }
        }

        public Person(string name, int age)
        {
            Name = !string.IsNullOrEmpty(name) ? name : "Аноним";
            Age = age > 0 ? age : 0;
        }

        public Person()
            : this(null, 0) { }

        public Person(string name)
            : this(name, 0) { }

        public Person(int age)
            : this(null, age) { }

        protected void Say(string message) =>
            ConsoleUtility.WriteLineColored(
                new Colored($"[{Name}]: ", ConsoleColor.Green),
                new Colored(message, ConsoleColor.Yellow)
            );

        public void Greet() => Say(RandomGreeting());

        public void SetAge(int age) => Age = age;
    }
}
