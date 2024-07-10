using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6_1
{
    public class Patient : Person
    {
        private string _diagnose;

        public Patient(
            string name,
            int age,
            string diagnose = "Здоров как бык",
            ConsoleColor color = ConsoleColor.Cyan
        )
            : base(name, age, color)
        {
            _diagnose = diagnose;
        }

        public override void Introduce()
        {
            base.Introduce();
            ConsoleColor current = Console.ForegroundColor;
            Console.ForegroundColor = _color;

            Console.WriteLine($"Пациент клиники");
            Console.ForegroundColor = current;

            CheckDiagnose();
            Console.WriteLine();
        }

        public void Heal()
        {
            ConsoleColor current = Console.ForegroundColor;
            Console.ForegroundColor = _color;
            Console.WriteLine($"Выполняется лечение пациента: {Name}");
            _diagnose = "Здоров как бык";
            Console.ForegroundColor = current;
            Console.WriteLine();
        }

        public void SetDiagnose(string diagnose) => _diagnose = diagnose;

        public void CheckDiagnose()
        {
            ConsoleColor current = Console.ForegroundColor;
            Console.ForegroundColor = _color;

            Console.WriteLine($"Диагноз пациента: {_diagnose}");
            Console.ForegroundColor = current;
        }
    }
}
