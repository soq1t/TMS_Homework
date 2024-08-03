using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHomeworkToolkit;
using static MyHomeworkToolkit.ConsoleUtility;

namespace Homework13_1.Squad
{
    [Serializable]
    public class SuperHero
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string SecretIdentity { get; set; }
        public List<string> Powers { get; private set; }

        public SuperHero()
        {
            Name = "Неизвестно";
            Age = -1;
            SecretIdentity = "Неизвестно";
            Powers = new List<string>();
        }

        public SuperHero(string name, int age, string secretIdentity, List<string> powers)
        {
            Name = name;
            Age = age;
            SecretIdentity = secretIdentity;
            Powers = powers;
        }

        public void AddPower(string power) => Powers.Add(power);

        public void PrintInfo()
        {
            WriteLineColored(
                new Colored("Имя: ", ConsoleColor.Cyan),
                new Colored(Name, ConsoleColor.Blue)
            );
            WriteLineColored(
                new Colored("Позывной: ", ConsoleColor.Cyan),
                new Colored(SecretIdentity, ConsoleColor.Blue)
            );
            WriteLineColored(
                new Colored("Возраст: ", ConsoleColor.Cyan),
                new Colored(Age, ConsoleColor.Blue)
            );
            Console.WriteLine();
            WriteColored("Суперспособности: ", ConsoleColor.Yellow);
            if (Powers.Count > 0)
            {
                Console.WriteLine();
                foreach (var power in Powers)
                {
                    WriteLineColored(power, ConsoleColor.Green);
                }
            }
            else
            {
                WriteLineColored("Отсутствуют", ConsoleColor.Red);
            }
        }
    }
}
