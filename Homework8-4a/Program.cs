using Homework8_4a.Models;
using Homework8_4a.Models.Documents;
using MyHomeworkToolkit;
using MyHomeworkToolkit.ObjectSelecting;

namespace Homework8_4a
{
    internal class Program
    {
        private static Register[] _registers = [new Register(), new Register(), new Register()];
        private static Register? _selectetRegister;

        private static ActionSelector _actions;
        private static ActionSelector _registerActions;

        static Program()
        {
            _actions = new ActionSelector();
            _actions.AddAction("Выбрать реестр", ChooseRegister);
            _actions.AddSeparator();
            _actions.AddExitProgramAction();

            _actions.SelectionAborted += () =>
            {
                _actions.AbortSelectActionRepeated();
                ConsoleUtility.WriteLineColored("Завершение программы...", ConsoleColor.Yellow);
                ConsoleUtility.PressToContinue();
                Environment.Exit(0);
            };

            _registerActions = new ActionSelector();
            _registerActions.AddAction("Показать информацию о документе", PrintDocumentInfo);
            _registerActions.AddAction(
                "Вернуться к выбору реестров",
                _registerActions.AbortSelectActionRepeated
            );

            _registerActions.SelectionAborted += () =>
            {
                _registerActions.AbortSelectActionRepeated();
                ConsoleUtility.WriteLineColored(
                    "Возвращаемся к выбору реестров",
                    ConsoleColor.Yellow
                );
                ConsoleUtility.PressToContinue();
            };

            _registers[0].AddDocument(new Contract("Василий", new DateOnly(2024, 07, 10)));
            _registers[0].AddDocument(new Financial());
            _registers[0]
                .AddDocument(
                    new GoodsDocument("Ананасы", 5000, DateOnly.FromDateTime(DateTime.Now))
                );

            _registers[1].AddDocument(new Contract());
            _registers[1].AddDocument(new Financial(15000, 15, new DateOnly(2022, 05, 11)));
            _registers[1].AddDocument(new GoodsDocument("Ананасы", 5000));

            _registers[2].AddDocument(new Contract());
            _registers[2].AddDocument(new Financial());
            _registers[2].AddDocument(new GoodsDocument());
        }

        static void Main(string[] args)
        {
            _actions.SelectActionRepeated(PrintMainMessage, pressKeyAfterActionCompleted: false);
        }

        private static void PrintMainMessage()
        {
            ConsoleUtility.WriteLineColored(
                new Colored("Количество реестров: ", ConsoleColor.Yellow),
                new Colored(_registers.Length, ConsoleColor.Green)
            );
            Console.WriteLine();
            ConsoleUtility.WriteLineColored("Выберите желаемое действие:");
        }

        private static void PrintDocumentInfo()
        {
            bool isDocumentSelected = true;

            do
            {
                isDocumentSelected = _selectetRegister?.PrintDocumentInfo() ?? false;
                ConsoleUtility.PressToContinue();
            } while (isDocumentSelected);
        }

        private static void PrintRegisterMessage()
        {
            _selectetRegister?.PrintRegisterInfo();
            Console.WriteLine();
            ConsoleUtility.WriteLineColored("Выберите дальнейшее действие:", ConsoleColor.Yellow);
        }

        private static void ChooseRegister()
        {
            _selectetRegister = ObjectSelector<Register>.SelectFromList(
                _registers.ToList(),
                PrintMainMessage
            );

            if (_selectetRegister != null)
            {
                _registerActions.SelectActionRepeated(
                    PrintRegisterMessage,
                    pressKeyAfterActionCompleted: false
                );
            }
        }
    }
}
