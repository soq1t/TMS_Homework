using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHomeworkToolkit;
using MyHomeworkToolkit.ObjectSelecting;

namespace Homework8_3
{
    internal class Company : ISelectableObject
    {
        public string CompanyName { get; private set; }

        private Dictionary<int, Employee> _employers;
        private int _employeeId = 0;

        public int? EmployersAmount => _employers?.Count;

        public string DisplayedName => $"Компания \"{CompanyName}\"";

        public void PrintInfo()
        {
            ConsoleUtility.WriteColored("Название компании: ", ConsoleColor.Cyan);
            ConsoleUtility.WriteLineColored(CompanyName, ConsoleColor.Green);
        }

        public Company(string companyName)
        {
            CompanyName = companyName;
            _employers = new Dictionary<int, Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            if (!HasEmployee(employee))
                _employers.Add(_employeeId++, employee);
        }

        public void PrintEmployers()
        {
            PrintInfo();
            ConsoleUtility.WriteColored("Кол-во сотрудников: ", ConsoleColor.Cyan);
            ConsoleUtility.WriteLineColored(_employers.Count.ToString(), ConsoleColor.Green);

            foreach (var e in _employers)
            {
                Console.WriteLine();
                ConsoleUtility.WriteColored("ID сотрудника: ", ConsoleColor.Cyan);
                ConsoleUtility.WriteLineColored(e.Key.ToString(), ConsoleColor.Green);
                e.Value.PrintInfo();
            }
        }

        public bool HasEmployee(Employee employee) => _employers.Values.Contains(employee);
    }
}
