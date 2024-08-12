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
        private Dictionary<Type, string> _personTypeMapper = new Dictionary<Type, string>()
        {
            { typeof(Person), "Человек" },
            { typeof(Teacher), "Преподаватель" },
            { typeof(Student), "Студент" },
        };

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
                if (string.IsNullOrEmpty(value))
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
                if (value < 0)
                    ConsoleUtility.PrintError("Возраст не может быть отрицательным значением!");
                else
                    _age = value;
            }
        }

        public Person(string name, int age)
        {
            Name = !string.IsNullOrEmpty(name) ? name : "Аноним";
            Age = age > 0 ? age : 0;

            ConsoleUtility.WriteLineColored(
                new Colored("К нам пришёл "),
                new Colored(_personTypeMapper[GetType()], ConsoleColor.Blue),
                new Colored(" , которого(ю) звать "),
                new Colored(Name, ConsoleColor.Green)
            );
        }

        public Person()
            : this(null, 0) { }

        public Person(string name)
            : this(name, 0) { }

        public Person(int age)
            : this(null, age) { }

        protected void Say(string message) =>
            ConsoleUtility.WriteLineColored(
                new Colored($"[{_personTypeMapper[GetType()]} {Name}]: ", ConsoleColor.Green),
                new Colored(message, ConsoleColor.Yellow)
            );

        public void Greet() => Say(RandomGreeting());

        public void SetAge(int age) => Age = age;
    }
}
