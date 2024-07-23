using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHomeworkToolkit;

namespace Homework8_3
{
    internal abstract class Employee : IPositionInfo
    {
        public string Position { get; private set; }

        public string Name { get; private set; }

        public Company Company { get; private set; }

        public void PrintPosition()
        {
            ConsoleUtility.WriteColored($"Должность: ", ConsoleColor.Cyan);
            ConsoleUtility.WriteLineColored(Position, ConsoleColor.Green);
        }

        public void PrintInfo()
        {
            ConsoleUtility.WriteColored($"Имя: ", ConsoleColor.Cyan);
            ConsoleUtility.WriteLineColored(Name, ConsoleColor.Green);
            PrintPosition();
            Company.PrintInfo();
        }

        protected Employee(string position, string name, Company company)
        {
            Position = position;
            Name = name;
            Company = company;

            if (!company.HasEmployee(this))
                Company.AddEmployee(this);
        }
    }
}
