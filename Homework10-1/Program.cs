using MyHomeworkToolkit;
using MyHomeworkToolkit.ObjectSelecting;

namespace Homework10_1
{
    internal class Program
    {
        private static readonly ActionSelector _actions;

        static Program()
        {
            _actions = new ActionSelector();

            _actions.AddAction("Произвести расчёт", PerformOperation);
            _actions.AddExitProgramAction();
        }

        private static void PerformOperation()
        {
            string? input = InputDataHandler.GetTextData(
                "Введите математическое выражение:",
                MathOperations.CheckInput
            );

            if (input == null)
            {
                ConsoleUtility.WriteLineColored(
                    "Вы не ввели никакого выражения!",
                    ConsoleColor.Yellow
                );
            }
            else
            {
                TextOption? answer = ObjectSelector<TextOption>.SelectFromList(
                    new List<TextOption>() { new TextOption("Да"), new TextOption("Нет") },
                    "Хотите выводить на консоль результаты всех вычислений?"
                );

                bool printOperations = (answer?.DisplayedName == "Да");

                try
                {
                    Console.Clear();
                    ConsoleUtility.WriteLineColored(
                        new Colored("Ваше выражение: "),
                        new Colored(input, ConsoleColor.Green)
                    );

                    ConsoleUtility.WriteLineColored(
                        new Colored("Результат Вашего выражения: ", ConsoleColor.Yellow),
                        new Colored(
                            MathOperations.GetOperationResult(input, printOperations),
                            ConsoleColor.Green
                        )
                    );
                    ConsoleUtility.PressToContinue();
                }
                catch (DivideByZeroException)
                {
                    ConsoleUtility.PrintError("В Вашем выражении присутствует деление на 0!");
                }
            }
        }

        static void Main(string[] args)
        {
            _actions.SelectActionRepeated(pressKeyAfterActionCompleted: false);
        }
    }
}
