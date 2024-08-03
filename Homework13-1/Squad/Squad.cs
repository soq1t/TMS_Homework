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
    public class Squad
    {
        public string SquadName { get; set; }
        public string HomeTown { get; set; }
        public int Formed { get; set; }
        public string SecretBase { get; set; }
        public bool Active { get; set; }
        public List<SuperHero> Members { get; private set; }

        public Squad()
        {
            SquadName = "Отсутствует";
            HomeTown = "Отсутствует";
            SecretBase = "Отсутствует";
            Formed = DateTime.Now.Year;
            Active = false;

            Members = new List<SuperHero>();
        }

        public Squad(
            string squadName,
            string homeTown,
            int formed,
            string secretBase,
            bool active,
            List<SuperHero> members
        )
        {
            SquadName = squadName;
            HomeTown = homeTown;
            Formed = formed;
            SecretBase = secretBase;
            Active = active;
            Members = members;
        }

        public void AddMember(SuperHero member)
        {
            if (Members.Contains(member))
            {
                ConsoleUtility.WriteLineColored(
                    "Такой супергерой уже состоит в команде",
                    ConsoleColor.Yellow
                );
            }
            else
            {
                Members.Add(member);
            }
        }

        public void PrintInfo()
        {
            WriteLineColored(
                new Colored("Команда ", ConsoleColor.Cyan),
                new Colored($"[{SquadName}]", ConsoleColor.Yellow)
            );
            WriteLineColored(
                new Colored("Статус: ", ConsoleColor.Cyan),
                new Colored(
                    Active ? "Активна" : "Неактивна",
                    Active ? ConsoleColor.Green : ConsoleColor.Red
                )
            );
            Console.WriteLine();
            WriteLineColored(
                new Colored("Дата формирования: ", ConsoleColor.Cyan),
                new Colored($"{Formed} г.", ConsoleColor.Blue)
            );
            Console.WriteLine();
            WriteLineColored(
                new Colored("Секретная база: ", ConsoleColor.Cyan),
                new Colored(SecretBase, ConsoleColor.Blue)
            );
            WriteLineColored(
                new Colored("Расположение базы: ", ConsoleColor.Cyan),
                new Colored(HomeTown, ConsoleColor.Blue)
            );
            Console.WriteLine();
            if (Members.Any())
            {
                WriteLineColored("Состав команды: ");
                foreach (var member in Members)
                {
                    WriteLineColored(new string('=', 35), ConsoleColor.Magenta);
                    member.PrintInfo();
                    WriteLineColored(new string('=', 35), ConsoleColor.Magenta);
                    if (Members.Last() != member)
                        Console.WriteLine();
                }
            }
            else
            {
                WriteLineColored("Команда не укомплектована!", ConsoleColor.Red);
            }
        }
    }
}
