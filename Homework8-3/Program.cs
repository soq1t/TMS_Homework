using MyHomeworkToolkit;
using MyHomeworkToolkit.ObjectSelecting;

namespace Homework8_3
{
    internal class Program
    {
        private static ActionSelector _actions;
        private static ActionSelector _companiesActions;

        private static List<Company> _companies;
        private static Company _selectedCompany;

        static Program()
        {
            _companies = new List<Company>()
            {
                { new Company("Google") },
                { new Company("Yandex") },
            };

            Company active = _companies.First();
            active.AddEmployee(new Director("John", active));
            active.AddEmployee(new Worker("Bill", active));
            active.AddEmployee(new Worker("Soul", active));
            active.AddEmployee(new Worker("Jack", active));
            active.AddEmployee(new Accountant("Nelly", active));

            active = _companies.Last();
            active.AddEmployee(new Director("Иван", active));
            active.AddEmployee(new Worker("Сергей", active));
            active.AddEmployee(new Worker("Василиса", active));
            active.AddEmployee(new Worker("Анатолий", active));
            active.AddEmployee(new Accountant("Светлана", active));

            _actions = new ActionSelector();
            _actions.AddAction("Выбор компании", SelectCompany);
            _actions.AddSeparator();
            _actions.AddExitProgramAction();

            _companiesActions = new ActionSelector();

            _companiesActions.AddAction("Показать работников компании", PrintEmployers);
            _companiesActions.AddSeparator();
            _companiesActions.AddAction(
                "Вернуться на главную",
                () =>
                    _actions.SelectActionRepeated(MainMessage, pressKeyAfterActionCompleted: false)
            );
        }

        static void Main(string[] args)
        {
            _actions.SelectActionRepeated(MainMessage, pressKeyAfterActionCompleted: false);
        }

        private static void MainMessage()
        {
            ConsoleUtility.WriteColored(
                "Количество зарегистрированных компаний: ",
                ConsoleColor.Cyan
            );
            ConsoleUtility.WriteLineColored(_companies.Count.ToString(), ConsoleColor.Yellow);

            int employersAmount = 0;

            foreach (Company company in _companies)
                employersAmount += company.EmployersAmount ?? 0;

            ConsoleUtility.WriteColored(
                "Суммарное количество работников в компании: ",
                ConsoleColor.Cyan
            );
            ConsoleUtility.WriteLineColored(employersAmount.ToString(), ConsoleColor.Yellow);
            Console.WriteLine();
            ConsoleUtility.WriteLineColored("Выберите желаемое действие:", ConsoleColor.Yellow);
        }

        private static void CompaniesMessage()
        {
            _selectedCompany?.PrintInfo();
            ConsoleUtility.WriteLineColored("Выберите желаемое действие:", ConsoleColor.Yellow);
        }

        private static void SelectCompany()
        {
            _selectedCompany = ObjectSelector<Company>.SelectFromList(
                _companies,
                "Выберите компанию из списка ниже:"
            );

            if (_selectedCompany != null)
            {
                _companiesActions.SelectAction(CompaniesMessage);
            }
        }

        private static void PrintEmployers()
        {
            _selectedCompany.PrintEmployers();
        }
    }
}
